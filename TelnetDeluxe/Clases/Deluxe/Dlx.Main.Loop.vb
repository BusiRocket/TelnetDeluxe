Option Strict On
Imports System.Threading
Namespace Deluxe
    Public Class Main_Loop
        Private Errores As New DlxErrores
        Private UniDlxVars As New UniversalDeluxe
        Private CronoTD As New System.Windows.Forms.Timer
        Public CronoConex As New System.Windows.Forms.Timer

        Public Sub New()
            AddHandler CronoTD.Tick, AddressOf CronoTD_Tick
            AddHandler CronoConex.Tick, AddressOf CronoConex_Tick
            TDLoop()
        End Sub

        Private Sub TDLoop()
            Try
                Me.CronoTD.Interval = 3000
                Me.CronoTD.Enabled = True
                Me.CronoTD.Start()
                Me.CronoConex.Interval = 3000
                Me.CronoConex.Enabled = True
                Me.CronoConex.Start()
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub CronoTD_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                CronoTD.Stop()
                ComprobarTray()
                CronoTD.Enabled = True
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub CronoConex_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                CronoConex.Stop()
                If TD_Principal.WindowState = FormWindowState.Minimized = False Then
                    ComprobarConexion()
                End If
                CronoConex.Enabled = True
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub ComprobarTray()
            Try
                If TD_Principal.OpcionesTD.Opciones.GUI_MinimToTray = True Then
                    If TD_Principal.WindowState = FormWindowState.Minimized Then
                        TD_Principal.TD_Tray.Visible = True
                        TD_Principal.ShowInTaskbar = False
                    Else
                        TD_Principal.TD_Tray.Visible = False
                        TD_Principal.ShowInTaskbar = True
                    End If
                End If
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Private Sub ComprobarConexion()
            Try
                Dim CConex As New NetTool_CheckConexion
                CConex.ComprobarConexion()
                CConex.Cerrar()
                CConex = Nothing
            Catch oEX As Exception
                Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub

        Public Sub Cerrar()
            Try
                Me.CronoTD.Stop()
                Me.CronoTD.Dispose()
                Me.CronoTD = Nothing
                Me.Finalize()
            Catch oEX As Exception
                Errores.MostrarError(oEX)
                Exit Sub
            End Try
        End Sub
    End Class
End Namespace