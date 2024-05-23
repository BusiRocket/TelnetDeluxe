Public NotInheritable Class TD_AcercaDe

    Private Sub TD_AcercaDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_acercade_version.Text = "Telnet Deluxe v" & TelnetDeluxe.Version & ". Algunos derechos reservados"
    End Sub

    Private Sub boton_dejamesalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles boton_dejamesalir.Click
        Me.Close()
    End Sub
End Class
