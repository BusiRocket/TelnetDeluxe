Option Strict On
Imports System.net
Imports System.Text
Imports System.IO
Namespace Deluxe
    Public Class Sync_telnet
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Crono As New DlxCrono
        Private Eventos As New DlxEventos
        Private CFGRouter As New Estructuras.ConfigRouter
        Private DlxTCP As Sockets.TcpClient
        Private LectorTCP As Sockets.NetworkStream

        Private Const IAC As Byte = 255
        Private Const DONT As Byte = 254
        Private Const [DO] As Byte = 253
        Private Const WONT As Byte = 252
        Private Const WILL As Byte = 251
        Private Const OPTION_ECHO As Byte = 1
        Private Const OPTION_SUPPRESS_GO_AHEAD As Byte = 3

        Private TCPEsperandoRecibir As Boolean = False
        Private TCPEsperandoEnviar As Boolean = False

        Private Enum OpcionesTelnet
            Do_Echo
            Dont_Echo
            Do_SuppressGoAhead
            Dont_SuppressGoAhead
        End Enum

        Public Sub New(ByVal CFGR As Estructuras.ConfigRouter)
            Try
                Me.CFGRouter = CFGR
                ComandosPorTelnet()
            Catch ex As Exception
                Errores.MostrarError(ex)
                Exit Sub
            End Try
        End Sub

        Public Sub ComandosPorTelnet()
            Try
                DlxTCP = Nothing
                DlxTCP = New Sockets.TcpClient
                TD_Principal.OpcionesTD.Estado.Macro_Cancelar = False
                TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = False
                TD_Principal.OpcionesTD.Estado.Info_Progreso = 0
                TD_Principal.OpcionesTD.Estado.Macro_TodoOK = True
                Eventos.ReportarProgreso(TD_Principal.OpcionesTD.Estado.Info_Progreso)

                TD_Principal.OpcionesTD.Estado.Info_ProgresoMax = CFGRouter.Comandos.Length
                TD_Principal.MaxProgreso(TD_Principal.OpcionesTD.Estado.Info_ProgresoMax)

                If TD_Principal.ToolBox.ComprobarRedLocal() = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_NoTarjetaRed"))
                    Eventos.MensajeDisponible()
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                Else
                    TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = True
                End If

                CFGRouter.IpRouter = TD_Principal.ConfigTelnet.IPRouter
                CFGRouter.Puerto = TD_Principal.ConfigTelnet.Puerto
                CFGRouter.Intervalo = TD_Principal.OpcionesTD.Opciones.Telnet_Intervalo

                If TD_Principal.ToolBox.HazPing(CFGRouter.IpRouter) = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPING") & CFGRouter.IpRouter & UniDlxVars.Traduccion("Error_NoPING2"))
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                End If

                If Conectar() Then
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = True
                Else
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                End If
                Crono.Esperar(CFGRouter.Intervalo * 1000)
                For Each ComandoTelnet As String In CFGRouter.Comandos
                    If TD_Principal.OpcionesTD.Estado.Macro_TodoOK = True And TD_Principal.OpcionesTD.Estado.Macro_Cancelar = False Then
                        ComprobarConexionTelnet()

                        While TCPEsperandoEnviar Or TCPEsperandoRecibir
                            Crono.Esperar(1000)
                        End While

                        Eventos.ReportarProgreso(TD_Principal.OpcionesTD.Estado.Info_Progreso + 1, "Enviando Comando: " & ComandoTelnet)

                        If Me.EnviarComando(ComandoTelnet) = False Then
                            TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                        End If

                        Crono.Esperar(CFGRouter.Intervalo * 1000)

                        If ComprobarMensaje() = False Then
                            TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                        End If
                    Else
                        Exit For
                    End If
                Next

                If Desconectar() Then
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                Else
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
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
            Catch sex As Sockets.SocketException
                Errores.MostrarError(sex)
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Macro_General"))
                Errores.MostrarError(oEX)
                Eventos.ReportarProgreso(TD_Principal.OpcionesTD.Estado.Info_ProgresoMax, "Ocurrió un error")
                Desconectar()
                TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = False
                Exit Sub
            End Try
        End Sub

        Public Function ComprobarConexionTelnet() As Boolean
            Try
                If DlxTCP.Connected = False Or DlxTCP.Client.Connected = False Or DlxTCP.Client.Poll(3, Sockets.SelectMode.SelectError) Then
                    Desconectar()
                    If TD_Principal.OpcionesTD.Estado.Macro_Ejecutando Then
                        Eventos.MensajeDisponible()
                        Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_ConexionCerrada"), Deluxe.Estructuras.MensajeConsola.MSG_Error)
                        TD_Principal.OpcionesTD.Estado.Accion_NuevaIP = False
                    End If
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                    TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = False
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                    TD_Principal.OpcionesTD.Estado.Macro_TodoOK = False
                    Return False
                Else
                    Return True
                End If
            Catch sex As Sockets.SocketException
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Return False
            Catch oex As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Errores.MostrarError(oex)
                Return False
            End Try
        End Function

        Public Function Conectar() As Boolean
            Try
                DlxTCP = New Sockets.TcpClient(CFGRouter.IpRouter, CInt(CFGRouter.Puerto))
                If DlxTCP.Connected Then
                    LectorTCP = DlxTCP.GetStream
                    LectorTCP.ReadTimeout = 3
                    LectorTCP.WriteTimeout = 3
                    DlxTCP.ReceiveTimeout = 3
                    DlxTCP.SendTimeout = 3
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = True
                    Eventos.RouterConectado()
                    Return True
                Else
                    TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                    Return False
                End If
            Catch sex As Sockets.SocketException
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Return False
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Public Function Desconectar() As Boolean
            Try
                If DlxTCP.Connected = True Then
                    DlxTCP.Close()
                    DlxTCP = Nothing
                    LectorTCP.Close(30)
                    LectorTCP.Dispose()
                Else
                    ' TODO: Mensaje Ya está desconectado
                End If
                TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                TD_Principal.OpcionesTD.Estado.Macro_Ejecutando = False
                TD_Principal.OpcionesTD.Estado.Conexion_ConectadoaRouter = False
                Eventos.RouterDesconectado()
                Return True
            Catch sex As Sockets.SocketException
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Return False
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoDesconectar"))
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Public Function ComprobarMensaje() As Boolean
            Try
                If DlxTCP.Connected = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_ConexionPerdida"))
                    Desconectar()
                    TCPEsperandoRecibir = True
                    Return False
                End If

                If TD_Principal.OpcionesTD.Estado.Macro_Cancelar = True Then
                    TCPEsperandoRecibir = True
                    Exit Function
                End If

                Dim BytesRecibidos As Integer = 0
                Dim BytesLeidos As Integer = 0
                Dim Bytes As Byte() = New Byte(DlxTCP.ReceiveBufferSize - 1) {}
                Dim DataBytesDevueltos As Byte() = New Byte(DlxTCP.ReceiveBufferSize - 1) {}
                Dim IndiceDestino As Integer = 0
                Dim HoraActual As DateTime
                Dim TimeOut As DateTime

                TimeOut = Now()
                TimeOut = TimeOut.AddMilliseconds(2000)

                If LectorTCP.DataAvailable = False Then
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_EsperandoRespuesta"), Deluxe.Estructuras.MensajeConsola.MSG_Accion)
                    While LectorTCP.DataAvailable = False
                        HoraActual = Now()
                        If HoraActual > TimeOut Or (TD_Principal.OpcionesTD.Estado.Macro_Ejecutando And DlxTCP.Connected = False) Then
                            Eventos.MensajeDisponible()
                            Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_ConexionCerrada"), Deluxe.Estructuras.MensajeConsola.MSG_Error)
                            TD_Principal.OpcionesTD.Estado.Accion_NuevaIP = False
                            Desconectar()
                            BytesRecibidos = Nothing
                            BytesLeidos = Nothing
                            Bytes = Nothing
                            DataBytesDevueltos = Nothing
                            IndiceDestino = Nothing
                            HoraActual = Nothing
                            TimeOut = Nothing
                            Return False
                        End If
                    End While
                    TCPEsperandoRecibir = True
                End If

                While DlxTCP.Available > 0
                    If TD_Principal.OpcionesTD.Estado.Macro_Cancelar = True Then
                        Exit Function
                    ElseIf DlxTCP.Connected = False Then
                        Errores.MostrarError(UniDlxVars.Traduccion("Error_ConexionPerdida"))
                        Desconectar()
                        Return False
                    ElseIf LectorTCP.CanRead Then
                        BytesLeidos = LectorTCP.Read(Bytes, 0, CInt(DlxTCP.ReceiveBufferSize))
                        Array.Copy(Bytes, 0, DataBytesDevueltos, IndiceDestino, BytesLeidos)
                        IndiceDestino = IndiceDestino + BytesLeidos + 1
                        BytesRecibidos += BytesLeidos
                        Eventos.MensajeDisponible(Encoding.UTF8.GetString(Bytes, 0, BytesLeidos), Deluxe.Estructuras.MensajeConsola.MSG_Router)
                        Eventos.ReportarProgreso(-1, "Recibidos " & BytesLeidos.ToString & " Bytes")
                    End If
                End While
                BytesRecibidos = Nothing
                BytesLeidos = Nothing
                Bytes = Nothing
                DataBytesDevueltos = Nothing
                IndiceDestino = Nothing
                HoraActual = Nothing
                TimeOut = Nothing
                TCPEsperandoRecibir = False
                Return True
            Catch sex As Sockets.SocketException
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Return False
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoRespuestaRouter"))
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Public Function EnviarComando(ByVal comandos As String) As Boolean
            Try
                If DlxTCP.Connected = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_ConexionPerdida"))
                    TCPEsperandoEnviar = True
                    Desconectar()
                    Return False
                Else
                    Dim BytesParaEnviar As Byte() = Encoding.UTF8.GetBytes(comandos & "" & Chr(13) & "")
                    If LectorTCP.CanWrite Then
                        LectorTCP.Write(BytesParaEnviar, 0, BytesParaEnviar.Length)
                        BytesParaEnviar = Nothing
                        TCPEsperandoEnviar = False
                        Return True
                    Else
                        TCPEsperandoEnviar = True
                        Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoEnviarComando"))
                        Return False
                    End If
                End If
            Catch sex As Sockets.SocketException
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoConectar"))
                Return False
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_EnviandoComando"))
                Errores.MostrarError(oEX)
                Return False
            End Try
        End Function

        Private Sub ReplyTelnetOption(ByVal netStream As Sockets.NetworkStream, ByVal reply As OpcionesTelnet)
            Select Case reply
                Case OpcionesTelnet.Do_Echo
                    netStream.Write(New Byte(2) {IAC, [DO], OPTION_ECHO}, 0, 3)
                    Exit Select
                Case OpcionesTelnet.Dont_Echo
                    netStream.Write(New Byte(2) {IAC, DONT, OPTION_ECHO}, 0, 3)
                    Exit Select
                Case OpcionesTelnet.Do_SuppressGoAhead
                    netStream.Write(New Byte(2) {IAC, [DO], OPTION_SUPPRESS_GO_AHEAD}, 0, 3)
                    Exit Select
                Case OpcionesTelnet.Dont_SuppressGoAhead
                    netStream.Write(New Byte(2) {IAC, DONT, OPTION_SUPPRESS_GO_AHEAD}, 0, 3)
                    Exit Select
            End Select
        End Sub

    End Class
End Namespace
