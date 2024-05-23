Option Strict On
Option Explicit On
Imports TelnetDeluxe.Deluxe
Public NotInheritable Class F_AcercaDe
    Private Errores As New DlxErrores
    Private UniDlxVars As New UniversalDeluxe
    Private Variables As New DlxVariables

    Private Sub TD_AcercaDe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbl_acercade_version.Text = "Telnet Deluxe v" & Variables.Version & ". Algunos derechos reservados"
    End Sub

    Private Sub boton_dejamesalir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles boton_dejamesalir.Click
        Me.Close()
    End Sub

    Private Sub ThanksADSLZone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThanksADSLZone.Click
        Try
            System.Diagnostics.Process.Start("http://www.adslzone.net")
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub enlace_cc_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles enlace_cc.LinkClicked
        Try
            enlace_cc.LinkVisited = True
            System.Diagnostics.Process.Start(enlace_cc.Text)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub lbl_acercade_email_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_acercade_email.LinkClicked
        Try
            lbl_acercade_email.LinkVisited = True
            System.Diagnostics.Process.Start("mailto:" & lbl_acercade_email.Text)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub lbl_acercade_dirweb_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lbl_acercade_dirweb.LinkClicked
        Try
            lbl_acercade_dirweb.LinkVisited = True
            System.Diagnostics.Process.Start(lbl_acercade_dirweb.Text)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub imagen_cc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imagen_cc.Click
        Try
            System.Diagnostics.Process.Start("http://creativecommons.org/licenses/by-nc-sa/3.0/")
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub
End Class
