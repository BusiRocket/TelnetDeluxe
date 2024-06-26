Option Strict On
Namespace Deluxe
    Public Class D_Sync
        Private Errores As New DlxErrores
        Private Eventos As New DlxEventos
        Private UniDlxVars As New UniversalDeluxe
        Private OpcionesMng As New DlxOpcionesManager
        Private Variables As New DlxVariables
        Public CFGRouter As New Estructuras.ConfigRouter

        Public Sub New()
            CFGRouter.Cargado = False
        End Sub

        Public Sub RouterSync()
            Try
                If CFGRouter.Cargado = False Then
                    CargarIniRouter()
                End If
                If CFGRouter.Modo.ToUpper <> "TELNET" Then
                    Dim SyncHTTP As New Sync_http(CFGRouter)
                Else
                    Dim SyncTelnet As New Sync_telnet(CFGRouter)
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Macro_General"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub Cerrar()
            Try
                TD_Principal.EComandos.Image = My.Resources.BotonTelnetON
                TD_Principal.EComandos.Tag = "Ejecutar Comandos Telnet"
                Me.Finalize()
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Sub CargarIniRouter()
            Try
                CFGRouter.ArchivoIni = TD_Principal.ConfigTelnet.IniSeleccionado
                If System.IO.File.Exists(CFGRouter.ArchivoIni) = False Then
                    Errores.MostrarError(UniDlxVars.Traduccion("Error_NoExisteCFG") & CFGRouter.ArchivoIni & ")")
                    Exit Sub
                Else
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_LeyendoCFG"), Deluxe.Estructuras.MensajeConsola.MSG_Accion)
                    Eventos.MensajeDisponible()
                    CFGRouter = OpcionesMng.CargarCFGRouter(CFGRouter)
                    TD_Principal.Text = CFGRouter.NombreRouter & " | INI by " & CFGRouter.Autor & " | " & Variables.TituloForm
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_InfoCFG") & CFGRouter.NombreRouter & UniDlxVars.Traduccion("Console_Msg_InfoCFG2") & CFGRouter.Revision, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_InfoCFG3") & CFGRouter.Autor & UniDlxVars.Traduccion("Console_Msg_InfoCFG4") & CFGRouter.Fecha, Deluxe.Estructuras.MensajeConsola.MSG_Info)
                    Eventos.MensajeDisponible()
                    Eventos.MensajeDisponible(UniDlxVars.Traduccion("Console_Msg_InfoCargOK"), Deluxe.Estructuras.MensajeConsola.MSG_Accion)
                    Eventos.MensajeDisponible()
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_NoPuedoCargarINI"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace