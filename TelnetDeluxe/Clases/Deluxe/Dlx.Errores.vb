Option Strict On
Option Explicit On
Namespace Deluxe
    Public Class DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private Variables As New DlxVariables

        Public Sub New()

        End Sub


        ' ###########################################################
        ' <*** Funciones para Mostrar/Registrar Errores ************>
        ' ###########################################################

        Public Sub MostrarError(ByVal DlxError As Exception)
            Try
                If TD_Principal.OpcionesTD.Opciones.LOG_MostrarErrDetallado = True Then
                    MostrarErrorUsuario(DlxError.ToString)
                End If
                If TD_Principal.OpcionesTD.Opciones.LOG_LoguearErrores = True Then
                    GuardarError(DlxError)
                End If
            Catch oEX As Exception
                MostrarErrorUsuario(UniDlxVars.Traduccion("Error_Generico"))
                MostrarErrorUsuario(oEX.Message)
                Exit Sub
            End Try
        End Sub

        Public Sub MostrarError(ByVal DlxError As String)
            Try
                MostrarErrorUsuario(DlxError)
                If TD_Principal.OpcionesTD.Opciones.LOG_LoguearErrores = True Then
                    GuardarError(DlxError)
                End If
            Catch oEX As Exception
                MostrarErrorUsuario(UniDlxVars.Traduccion("Error_Generico"))
                MostrarErrorUsuario(oEX.Message)
                Exit Sub
            End Try
        End Sub

        Public Sub MostrarVError(ByVal DlxError As Exception)
            Try
                Dim mensaje_error As String = DlxError.Message & vbNewLine & DlxError.InnerException.ToString & vbNewLine & DlxError.Source
                MessageBox.Show(mensaje_error, "Error - Telnet Deluxe", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Catch oEX As Exception
                Exit Sub
            End Try
        End Sub

        Public Sub GuardarError(ByVal DlxError As Exception)
            Try
                GuardarError("Error registrado el: " & System.DateTime.Now & vbNewLine & "     Error detallado: ")
                GuardarError(DlxError.Message)
                GuardarError(DlxError.InnerException.ToString)
                GuardarError(DlxError.Source)
                GuardarError(DlxError.StackTrace)
                GuardarError(DlxError.TargetSite.ToString)
            Catch oEX As Exception
                MostrarErrorUsuario(UniDlxVars.Traduccion("Error_Generico"))
                MostrarErrorUsuario(oEX.Message)
                Exit Sub
            End Try
        End Sub

        Public Sub GuardarError(ByVal DlxError As String)
            Try
                Dim infoarchivo As New IO.FileInfo(Variables.ArchivoLog_Errores)
                If infoarchivo.IsReadOnly Then
                    Exit Sub
                Else
                    Dim crono As New DlxCrono
                    Dim EscritorLog As New IO.StreamWriter(Variables.ArchivoLog_Errores, True)
                    Dim errorprep As String = crono.DevolverFecha(False) & DlxError
                    EscritorLog.WriteLine(errorprep)
                    EscritorLog.Close()
                    EscritorLog.Dispose()
                    crono = Nothing
                    EscritorLog = Nothing
                    errorprep = Nothing
                End If
                infoarchivo = Nothing
            Catch oEX As Exception
                MostrarVError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub MostrarErrorUsuario(ByVal mensaje As String)
            Try
                TD_Principal.MostrarEnConsola(mensaje, Deluxe.Estructuras.MensajeConsola.MSG_Error)
            Catch oEX As Exception
                TD_Principal.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), Deluxe.Estructuras.MensajeConsola.MSG_Error)
                TD_Principal.MostrarEnConsola(oEX.Message, Deluxe.Estructuras.MensajeConsola.MSG_Error)
                Exit Sub
            End Try
        End Sub


        ' ###########################################################
        ' #     Errores Específicos
        ' ###########################################################
        Public Sub MostrarError(ByVal serr As System.Net.Sockets.SocketException)
            Try
                Select Case serr.SocketErrorCode
                    Case System.Net.Sockets.SocketError.ConnectionAborted
                        MostrarErrorUsuario("La conexión se ha cerrado")
                        Exit Select
                    Case System.Net.Sockets.SocketError.ConnectionRefused
                        MostrarErrorUsuario("El equipo remoto ha rechazado la conexión")
                        Exit Select
                    Case System.Net.Sockets.SocketError.DestinationAddressRequired
                        MostrarErrorUsuario("No se ha definido una dirección IP")
                        Exit Select
                    Case System.Net.Sockets.SocketError.HostUnreachable
                        MostrarErrorUsuario("El equipo remoto no responde")
                        Exit Select
                    Case System.Net.Sockets.SocketError.NetworkDown
                        MostrarErrorUsuario("La red no está disponible")
                        Exit Select
                    Case System.Net.Sockets.SocketError.NetworkUnreachable
                        MostrarErrorUsuario("No se puede conectar con el equipo")
                        Exit Select
                    Case System.Net.Sockets.SocketError.OperationAborted
                        MostrarErrorUsuario("La operación se ha cancelado debido a que el equipo canceló la conexión")
                        Exit Select
                    Case System.Net.Sockets.SocketError.TimedOut
                        MostrarErrorUsuario("El equipo remoto ha dejado de responder, se ha superado el tiempo límite")
                        Exit Select
                End Select

                MostrarErrorUsuario(serr.ToString)

                If TD_Principal.OpcionesTD.Opciones.LOG_LoguearErrores = True Then
                    GuardarError(serr)
                End If
            Catch oEX As Exception
                MostrarErrorUsuario(UniDlxVars.Traduccion("Error_Generico"))
                MostrarErrorUsuario(oEX.Message)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace