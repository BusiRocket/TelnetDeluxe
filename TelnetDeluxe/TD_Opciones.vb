Imports System.Text
Imports System.IO
Public Class TD_Opciones
    Inherits System.Windows.Forms.Form
    'Private WithEvents ClienteWeb As New System.Net.WebClient
    Dim UniDlxVars As New UniversalDeluxe
    Dim DlxToolBox As New Dlx_ToolBox

    Private Sub TD_Opciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Dispose(True)
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ConseguirIniRouters()
            CargarCFG()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub boton_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_aceptar.Click
        Try
            GuardarCFG()
            CargarCFG()
            Me.Close()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub boton_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_cancelar.Click
        Try
            CargarCFG()
            Me.Close()
            Exit Sub
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub boton_aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_aplicar.Click
        Try
            GuardarCFG()
            CargarCFG()
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Sub ConseguirIniRouters()
        Try
            If Directory.Exists(DlxToolBox.CarpetaIniRouters) = False Then
                Directory.CreateDirectory(DlxToolBox.CarpetaIniRouters)
            End If
            Dim ArchivosINIRouters() As String = Directory.GetFiles(DlxToolBox.CarpetaIniRouters, "*.ini")
            Me.Combo_inirouters.Items.Clear()
            If ArchivosINIRouters.Length <> 0 Then
                For Each ArchIniRouter As String In ArchivosINIRouters
                    ArchIniRouter = ArchIniRouter.Substring(DlxToolBox.CarpetaIniRouters.Length + 1)
                    Me.Combo_inirouters.Items.Add(ArchIniRouter)
                Next
                If Me.Combo_inirouters.Items.Count > 0 Then
                    Me.Combo_inirouters.SelectedIndex = 0
                End If
            Else
                Me.Combo_inirouters.Items.Add(UniDlxVars.Traduccion("Gui_Routers_NohayINI"))
            End If
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub GuardarCFG()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr

            ' Configuración General
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_DirIp"), Me.txtbox_conf_iprouter.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Puerto"), TelnetDeluxe.ExtCFG_Puerto)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Refresco"), Me.txtbox_conf_intervalo.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_IniRouter"), TelnetDeluxe.ExtCFG_Archivo)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_User"), Me.txtbox_conf_user.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Pass"), Me.txtbox_conf_pass.Text)


            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPublica"), TelnetDeluxe.txtbox_info_ipact.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_Consola_Hora"), ComprobarCheck(Check_HoraConsola).ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_LoguearIP"), ComprobarCheck(Check_LogIP).ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_MinimizarTray"), ComprobarCheck(Check_MinimTray).ToString)








            'DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPing"), TelnetDeluxe.DirPING)

            DeluxeIniMgr = Nothing
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub GuardarIP()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPublica"), TelnetDeluxe.txtbox_info_ipact.Text)
            DeluxeIniMgr = Nothing
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Public Sub CargarCFG()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr

            ' Configuración General
            Me.txtbox_conf_iprouter.Text = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_DirIp"), "192.168.1.1")
            Me.txtbox_conf_puerto.Text = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Puerto"), "23")
            Me.txtbox_conf_user.Text = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_User"), "1234")
            Me.txtbox_conf_pass.Text = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Pass"), "1234")
            Me.Combo_inirouters.SelectedItem = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_IniRouter"), "")



            TelnetDeluxe.Opciones_Telnet_Intervalo = CType(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Refresco"), TelnetDeluxe.Opciones_Telnet_Intervalo.ToString), Integer)
            Me.txtbox_conf_intervalo.Text = TelnetDeluxe.Opciones_Telnet_Intervalo.ToString





            'Miscelánea
            TelnetDeluxe.txtbox_info_ipact.Text = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPublica"), "")
            TelnetDeluxe.DirPING = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPing"), TelnetDeluxe.DirPING)
            PonerCheck(Check_HoraConsola, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_Consola_Hora"), CStr(False))))
            PonerCheck(Check_LogIP, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_LoguearIP"), CStr(False))))
            PonerCheck(Check_MinimTray, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_MinimizarTray"), CStr(False))))



            TelnetDeluxe.IniSeleccionado = DlxToolBox.CarpetaIniRouters & "\" & Me.Combo_inirouters.SelectedItem.ToString
            TelnetDeluxe.ExtCFG_Archivo = Me.Combo_inirouters.SelectedItem.ToString

            TelnetDeluxe.ExtCFG_Usuario = Me.txtbox_conf_user.Text
            TelnetDeluxe.ExtCFG_Pass = Me.txtbox_conf_pass.Text
            TelnetDeluxe.ExtCFG_Puerto = Me.txtbox_conf_puerto.Text
            TelnetDeluxe.ExtCFG_IPRouter = Me.txtbox_conf_iprouter.Text
            'TelnetDeluxe.ExtCFG_RouterINI = 

            TelnetDeluxe.Opciones_Consola_MostrarHora = ComprobarCheck(Check_HoraConsola)
            TelnetDeluxe.Opciones_LOG_LoguearIPs = ComprobarCheck(Check_LogIP)
            TelnetDeluxe.Opciones_GUI_MinimToTray = ComprobarCheck(Check_MinimTray)


            'Limpiar
            DeluxeIniMgr = Nothing
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub Combo_inirouters_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_inirouters.SelectedIndexChanged
        TelnetDeluxe.IniSeleccionado = DlxToolBox.CarpetaIniRouters & "\" & Me.Combo_inirouters.SelectedItem.ToString
        TelnetDeluxe.ExtCFG_Archivo = Me.Combo_inirouters.SelectedItem.ToString
    End Sub

    Private Function ComprobarCheck(ByVal CajaCheck As CheckBox) As Boolean
        Try
            If CajaCheck.CheckState = CheckState.Checked Then
                ComprobarCheck = True
            Else
                ComprobarCheck = False
            End If
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            ComprobarCheck = False
            Exit Function
        End Try
    End Function

    Private Sub PonerCheck(ByVal CajaCheck As CheckBox, ByVal Valor As Boolean)
        Try
            If Valor = True Then
                CajaCheck.CheckState = CheckState.Checked
            Else
                CajaCheck.CheckState = CheckState.Unchecked
            End If
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub txtbox_conf_intervalo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbox_conf_intervalo.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtbox_conf_intervalo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbox_conf_intervalo.TextChanged
        Try
            If String.IsNullOrEmpty(Me.txtbox_conf_intervalo.Text) Or CType(Me.txtbox_conf_intervalo.Text, Integer) < 1 Then
                TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_IntervaloLow"), "Error")
                TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_IntervaloLowTip"), "Error")
                Me.txtbox_conf_intervalo.Text = TelnetDeluxe.Opciones_Telnet_Intervalo.ToString
            Else
                TelnetDeluxe.Opciones_Telnet_Intervalo = CType(Me.txtbox_conf_intervalo.Text, Integer)
                'TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Console_Config_Intervalo") & TelnetDeluxe.Opciones_Telnet_Intervalo & UniDlxVars.Traduccion("Console_Config_IntervaloFin"), "Info")
                'TelnetDeluxe.MostrarEnConsola()
            End If
        Catch oEX As Exception
            TelnetDeluxe.MostrarEnConsola(UniDlxVars.Traduccion("Error_Generico"), "Error")
            TelnetDeluxe.MostrarEnConsola(oEX.Message, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub txtbox_conf_puerto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbox_conf_puerto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class