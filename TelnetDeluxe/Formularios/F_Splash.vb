Option Strict On
Option Explicit On
Public NotInheritable Class F_Splash
    Private Sub TDSplash_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Visible = False
            Me.Dispose(True)
        Catch oEX As Exception
            Dim Errores As New Deluxe.DlxErrores
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TDSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

        Catch oEX As Exception
            Dim Errores As New Deluxe.DlxErrores
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub
End Class
