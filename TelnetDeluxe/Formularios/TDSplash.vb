Public NotInheritable Class TDSplash
    Private Sub TDSplash_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Dispose(True)
        Catch oEX As Exception
            Dim DlxToolBox As New Dlx_ToolBox
            DlxToolBox.MostrarError(oEX)
            DlxToolBox = Nothing
            Exit Sub
        End Try
    End Sub
End Class
