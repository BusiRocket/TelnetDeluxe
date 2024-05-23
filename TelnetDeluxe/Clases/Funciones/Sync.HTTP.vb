Option Strict On
Imports System.net
Imports System.Text
Imports System.IO
Imports System.Security.Cryptography
Namespace Deluxe
    Public Class Sync_http
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Crono As New DlxCrono
        Private Variables As New DlxVariables
        Private Eventos As New DlxEventos
        Public CFGRouter As New Estructuras.ConfigRouter
        Private ClienteHTTP As WebClient

        Public Sub New(ByVal CFGR As Estructuras.ConfigRouter)
            Try
                CFGRouter = CFGR
                ComandosPorHTTP()
            Catch ex As Exception
                Errores.MostrarError(ex)
                Exit Sub
            End Try
        End Sub


        ' ###########################################################
        ' <******************** Funciones HTTP *********************>
        ' ###########################################################

        Public Sub ComandosPorHTTP()
            Try
                TD_Principal.OpcionesTD.Estado.Macro_Cancelar = False
                TD_Principal.OpcionesTD.Estado.Info_Progreso = 0
                TD_Principal.OpcionesTD.Estado.Macro_TodoOK = True
                Eventos.ReportarProgreso(TD_Principal.OpcionesTD.Estado.Info_Progreso)
                ' Cargar la configuración del router si no está cargada
                TD_Principal.OpcionesTD.Estado.Info_ProgresoMax = 3
                TD_Principal.MaxProgreso(3)
                ' Comprueba la tarjeta de red
                If TD_Principal.ToolBox.ComprobarRedLocal() = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_NoTarjetaRed"))
                    Eventos.MensajeDisponible()
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                Else
                    TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = True
                End If

                'Configura la clase FuncionesRouter (FuncRouter)
                CFGRouter.IpRouter = TD_Principal.ConfigTelnet.IPRouter
                CFGRouter.Intervalo = TD_Principal.OpcionesTD.Opciones.Telnet_Intervalo

                ' Comprueba que el router responda
                If TD_Principal.ToolBox.HazPing(CFGRouter.IpRouter) = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPING") & CFGRouter.IpRouter & UniDlxVars.Traduccion("Error_NoPING2"))
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                End If

                If TD_Principal.OpcionesTD.Estado.Macro_TodoOK = True Then
                    ' LOGIN
                    If CFGRouter.http_login.Length >= 1 Then
                        If CFGRouter.http_metodologin.ToUpper <> "DIGEST" Then
                            Eventos.MensajeDisponible("Enviando petición HTTP para iniciar sesión en tu router", Estructuras.MensajeConsola.MSG_Router)
                            Eventos.MensajeDisponible()
                            EnviarHTTP(CFGRouter.http_login)
                            Eventos.ReportarProgreso(1, "Enviando petición HTTP para iniciar sesión en tu router")
                            Crono.Esperar(CFGRouter.Intervalo * 1000)
                        Else
                            Eventos.ReportarProgreso(1, "Petición HTTP para iniciar sesión omitida (se realizará mediante Digest)")
                            Eventos.MensajeDisponible("Petición HTTP para iniciar sesión omitida (se realizará mediante Digest)", Estructuras.MensajeConsola.MSG_Router)
                            Eventos.MensajeDisponible()
                        End If
                    Else
                        Eventos.ReportarProgreso(1, "Petición HTTP para Login omitida (se realizará mediante Digest)")
                        Eventos.MensajeDisponible("Petición HTTP para Login omitida (se realizará mediante Digest)", Estructuras.MensajeConsola.MSG_Router)
                        Eventos.MensajeDisponible()
                    End If

                    ' DESCONECTAR
                    If CFGRouter.http_desconectar.Length >= 1 Then
                        Eventos.MensajeDisponible("Enviando petición HTTP para Desconectar", Estructuras.MensajeConsola.MSG_Router)
                        Eventos.MensajeDisponible()
                        EnviarHTTP(CFGRouter.http_desconectar)
                        Eventos.ReportarProgreso(2, "Enviando petición HTTP para Desconectar")
                        Crono.Esperar(CFGRouter.Intervalo * 1000)
                    Else
                        Eventos.ReportarProgreso(2, "Petición HTTP para Desconectar Omitida (el comando está vacío)")
                        Eventos.MensajeDisponible("Petición HTTP para Desconectar Omitida (el comando está vacío)", Estructuras.MensajeConsola.MSG_Router)
                        Eventos.MensajeDisponible()
                    End If

                    ' CONECTAR
                    If CFGRouter.http_conectar.Length >= 1 Then
                        Eventos.MensajeDisponible("Enviando petición HTTP para Conectar", Estructuras.MensajeConsola.MSG_Router)
                        Eventos.MensajeDisponible()
                        EnviarHTTP(CFGRouter.http_conectar)
                        Eventos.ReportarProgreso(3, "Enviando petición HTTP para Conectar")
                        Crono.Esperar(CFGRouter.Intervalo * 1000)
                    Else
                        Eventos.ReportarProgreso(3, "Petición HTTP para Conectar Omitida (el comando está vacío)")
                        Eventos.MensajeDisponible("Petición HTTP para Conectar Omitida (el comando está vacío)", Estructuras.MensajeConsola.MSG_Router)
                        Eventos.MensajeDisponible()
                    End If
                End If

                Crono.Esperar(CFGRouter.Intervalo * 1000)
                If TD_Principal.OpcionesTD.Estado.Macro_Cancelar Then
                    Eventos.MensajeDisponible()
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_OperacionCancelada"), Deluxe.Estructuras.MensajeConsola.MSG_Error)
                    TD_Principal.OpcionesTD.Estado.Accion_NuevaIP = False
                ElseIf TD_Principal.OpcionesTD.Estado.Macro_TodoOK Then
                    Eventos.MensajeDisponible()
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_ComandosOK"), Deluxe.Estructuras.MensajeConsola.MSG_Accion)
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_ComandosOKWait"), Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    Eventos.MensajeDisponible()
                    Eventos.ReportarProgreso(0, UniDlxVars.Traduccion("Console_Msg_ComandosOK"))
                    Crono.Esperar(CFGRouter.Intervalo * 1000)
                    TD_Principal.OpcionesTD.Estado.Accion_NuevaIP = True
                Else
                    Eventos.MensajeDisponible()
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_Macro"))
                    Eventos.MensajeDisponible()
                    Eventos.ReportarProgreso(TD_Principal.OpcionesTD.Estado.Info_ProgresoMax, UniDlxVars.Traduccion("Error_Macro_General"))
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_Macro_General"))
                    Eventos.MensajeDisponible()
                End If

                TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = False
                Eventos.ReportarProgreso(0, "Telnet Deluxe...")
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Macro_General"))
                Errores.MostrarError(oEX)
                Eventos.ReportarProgreso(TD_Principal.OpcionesTD.Estado.Info_ProgresoMax, "Ocurrió un error")
                TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = False
                Exit Sub
            End Try
        End Sub

        Public Function EnviarHTTP(ByVal URLRaw As String) As Boolean
            Try
                If URLRaw.Length >= 1 Then
                    Dim PreUrl As String = "http://" & CFGRouter.IpRouter & ":" & CFGRouter.Puerto & "/"
                    Dim DatosForm As String = ""
                    Dim URL As String = ""
                    Dim Peticion As HttpWebRequest
                    Dim Respuesta As HttpWebResponse
                    Dim StreamPeticion As IO.Stream
                    Dim BytesPOST As Byte()

                    URLRaw = PonerVariablesHTTP(URLRaw)

                    If URLRaw.Contains("|") = True Then
                        Dim ArrayHttp() As String = Split(URLRaw, "|")
                        If ArrayHttp.Rank >= 1 Then
                            URL = PreUrl & ArrayHttp(0)
                            DatosForm = ArrayHttp(1)
                        Else
                            Eventos.MensajeDisponible("El comando no se ha reconocido correctamente:" & URLRaw)
                        End If
                    Else
                        URL = PreUrl & URLRaw
                    End If

                    Peticion = CType(WebRequest.Create(URL), HttpWebRequest)
                    Peticion.UserAgent = "Cliente HTTP | Telnet Deluxe v" & Variables.Version
                    Peticion.Referer = URL

                    If CFGRouter.http_metodo.ToUpper.Contains("POST") = True Then
                        Peticion.Method = "POST"
                        Peticion.ContentType = "application/x-www-form-urlencoded"
                        Peticion.ContentLength = DatosForm.Length
                    Else
                        Peticion.Method = "GET"
                    End If

                    Peticion.AllowAutoRedirect = True
                    Peticion.Timeout = 15 * 1000

                    If CFGRouter.http_metodologin.ToUpper = "DIGEST" Then
                        Dim Crypt As New DlxCrypt
                        Peticion.Headers.Add(HttpRequestHeader.Authorization, "BASIC " & Crypt.Hash_Base64(TD_Principal.ConfigTelnet.Usuario & ":" & TD_Principal.ConfigTelnet.Pass))
                    End If

                    If CFGRouter.http_metodo.ToUpper.Contains("POST") = True Then
                        StreamPeticion = Peticion.GetRequestStream()
                        BytesPOST = System.Text.Encoding.ASCII.GetBytes(DatosForm)
                        StreamPeticion.Write(BytesPOST, 0, BytesPOST.Length)
                        StreamPeticion.Close()
                    End If

                    Respuesta = CType(Peticion.GetResponse(), HttpWebResponse)
                    Respuesta.Close()

                    Peticion = Nothing
                    Respuesta = Nothing
                    BytesPOST = Nothing
                    StreamPeticion = Nothing
                Else
                    Eventos.MensajeDisponible("Omitiendo envío. Comando vacío. Todo OK", Deluxe.Estructuras.MensajeConsola.MSG_Accion)
                End If
                Return True
            Catch wex As WebException
                Errores.MostrarError(wex)
                Return False
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Public Function PonerVariablesHTTP(ByVal urlproceso As String) As String
            Try
                Dim Crypt As New DlxCrypt
                urlproceso = Replace(urlproceso, "<<usuario>>", TD_Principal.ConfigTelnet.Usuario)
                urlproceso = Replace(urlproceso, "<<contrasena>>", TD_Principal.ConfigTelnet.Pass)
                urlproceso = Replace(urlproceso, "<<cont_md5>>", Crypt.Hash_MD5(TD_Principal.ConfigTelnet.Pass))
                Crypt.Cerrar()
                Crypt = Nothing
                Return urlproceso
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Return "Error"
            End Try
        End Function
    End Class
End Namespace
