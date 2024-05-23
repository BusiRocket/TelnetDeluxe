Option Strict On
Imports System.Threading
Imports System.net
Namespace Deluxe
    Public Class NetTool_GetIp
        Private Errores As New DlxErrores
        Private Eventos As New DlxEventos
        Private UniDlxVars As New UniversalDeluxe
        Private WithEvents Currante_ConseguirIP As New System.ComponentModel.BackgroundWorker

        Public Sub New()
            Currante_ConseguirIP = New System.ComponentModel.BackgroundWorker
        End Sub

        Sub LeerIP(Optional ByVal WebIp As String = "false")
            Try
                Dim WebConseguirIp As String = "http://checkip.dyndns.org"
                If WebIp = "false" Then
                    WebConseguirIp = TD_Principal.OpcionesTD.Opciones.IP_WebConseguir
                Else
                    WebConseguirIp = WebIp
                End If

                Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_ConsiguiendoIP"), Estructuras.MensajeConsola.MSG_Accion)
                Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_EsperaLarga"), Estructuras.MensajeConsola.MSG_Info)
                Eventos.MensajeDisponible()
                Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_ConectandoCon") & TD_Principal.OpcionesTD.Opciones.IP_WebConseguir, Estructuras.MensajeConsola.MSG_Accion)
                Eventos.MensajeDisponible()

                Me.Currante_ConseguirIP.WorkerReportsProgress = True
                Me.Currante_ConseguirIP.WorkerSupportsCancellation = True

                If Me.Currante_ConseguirIP.IsBusy = False Then
                    Me.Currante_ConseguirIP.CancelAsync()
                    Me.Currante_ConseguirIP.RunWorkerAsync(WebConseguirIp)
                Else
                    Eventos.MensajeDisponible("Ya se está intentando conseguir la IP, por favor ten paciencia")
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_Nocontrolado"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub Currante_ConseguirIP_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Currante_ConseguirIP.DoWork
            Try
                Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)
                e.Result = DescargarHTML(e.Argument.ToString, worker)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_Nocontrolado"))
                Errores.MostrarError(oEX)
                e.Result = oEX.Message
                Exit Sub
            End Try
        End Sub

        Private Sub Currante_ConseguirIP_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Currante_ConseguirIP.RunWorkerCompleted
            Try
                If e.Cancelled Then
                    Eventos.MensajeDisponible("Operación Cancelada", Estructuras.MensajeConsola.MSG_Info)
                ElseIf (e.Error IsNot Nothing) Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_Nocontrolado"))
                    Errores.MostrarError(e.Error)
                ElseIf (e.Result IsNot Nothing) Then
                    IP_LimpiarHTML(e.Result.ToString)
                    e = Nothing
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_Nocontrolado"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Function IP_LimpiarHTML(ByVal RawHtml As String) As String
            Try
                Dim DirIpActual As String
                RawHtml = Trim(RawHtml)
                If RawHtml <> "" Then
                    DirIpActual = TD_Principal.ToolBox.DevuelveIP(RawHtml)
                    If DirIpActual = "False" Then
                        Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_HTMLNoIp"))
                        Errores.MostrarError(RawHtml)
                        Return "False"
                    Else
                        Eventos.NuevaIPDisponible(DirIpActual)
                        Return DirIpActual
                    End If
                Else
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_ConsiguiendoHTML"))
                    Return "False"
                End If
                DirIpActual = Nothing
                Return "False"
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_Nocontrolado"))
                Errores.MostrarError(oEX)
                Return "False"
            End Try
        End Function

        Private Function DescargarHTML(ByVal URL As String, ByVal Currante As System.ComponentModel.BackgroundWorker) As String
            Try
                If URL.Length >= 1 Then
                    Dim Variables As New DlxVariables
                    Dim Peticion As HttpWebRequest
                    Dim Respuesta As HttpWebResponse
                    Dim CodigoEstado As Integer
                    Dim PeticionUri As System.Uri = New System.Uri(URL)

                    Peticion = CType(WebRequest.Create(PeticionUri), HttpWebRequest)
                    Peticion.KeepAlive = False
                    Peticion.Headers.Set("Pragma", "no-cache")
                    Peticion.UserAgent = "Cliente HTTP | Telnet Deluxe v" & Variables.Version
                    Peticion.Referer = URL
                    Peticion.Method = "GET"
                    Peticion.AllowAutoRedirect = True
                    Peticion.Timeout = 30 * 1000

                    Respuesta = CType(Peticion.GetResponse(), HttpWebResponse)
                    CodigoEstado = Respuesta.StatusCode

                    Dim StreamRespuesta As IO.Stream
                    StreamRespuesta = Respuesta.GetResponseStream()
                    Dim LectorRespuesta As IO.StreamReader = New IO.StreamReader(StreamRespuesta)
                    Dim StrRespuesta As String = LectorRespuesta.ReadToEnd
                    LectorRespuesta.Close()
                    Respuesta.Close()
                    Peticion = Nothing
                    Respuesta = Nothing
                    LectorRespuesta = Nothing
                    Variables = Nothing
                    CodigoEstado = Nothing
                    PeticionUri = Nothing
                    Return StrRespuesta
                Else
                    Eventos.MensajeDisponible("La URL para conseguir la IP está vacia, cámbiala en las opciones", Deluxe.Estructuras.MensajeConsola.MSG_Accion)
                    Return "error"
                End If
            Catch wex As System.Net.WebException
                Errores.MostrarError(wex)
                Return wex.Message
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_PIPC_Nocontrolado"))
                Errores.MostrarError(oEX)
                Return oEX.Message
            Finally
                Currante.Dispose()
            End Try
        End Function

        Public Sub Cerrar()
            Try
                Currante_ConseguirIP.Dispose()
                Me.Finalize()
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace