Imports System.Text
Imports System.IO
Public Class TD_Opciones
    Inherits System.Windows.Forms.Form
    'Private WithEvents ClienteWeb As New System.Net.WebClient
    Dim UniDlxVars As New UniversalDeluxe
    Dim DlxToolBox As New Dlx_ToolBox


    ' ###########################################################
    ' <************ Funciones de los formularios ***************>
    ' ###########################################################

    '////////////////////////////////////////////////////////////////////
    '/// Funciones principales

    Private Sub TD_Opciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.Dispose()
            Me.Finalize()
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CargarOpciones()
            SelColor.AllowFullOpen = True
            SelColor.FullOpen = True

        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Botones para salir

    Private Sub boton_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_aceptar.Click
        Try
            GuardarCFG()
            CargarCFG()
            Me.Close()
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub boton_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_cancelar.Click
        Try
            CargarCFG()
            Me.Close()
            Exit Sub
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub boton_aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_aplicar.Click
        Try
            GuardarCFG()
            CargarCFG()
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Selección de colores

    Private Sub CC_Fondo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_Fondo.Click
        Try
            SelColor.Color = CC_Fondo.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_Fondo.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub CC_defecto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_defecto.Click
        Try
            SelColor.Color = CC_defecto.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_defecto.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub CC_info_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_info.Click
        Try
            SelColor.Color = CC_info.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_info.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub CC_Router_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_Router.Click
        Try
            SelColor.Color = CC_Router.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_Router.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub CC_Error_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_Error.Click
        Try
            SelColor.Color = CC_Error.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_Error.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub CC_Accion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_Accion.Click
        Try
            SelColor.Color = CC_Accion.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_Accion.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub CC_DirIp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CC_DirIp.Click
        Try
            SelColor.Color = CC_DirIp.BackColor
            If SelColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                CC_DirIp.BackColor = SelColor.Color
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Eventos Texbox

    Private Sub txtbox_conf_puerto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtbox_conf_puerto.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_IntervaloLow"))
                DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_IntervaloLowTip"))
                Me.txtbox_conf_intervalo.Text = TelnetDeluxe.OpcionesTD.Telnet_Intervalo.ToString
            Else
                TelnetDeluxe.OpcionesTD.Telnet_Intervalo = CType(Me.txtbox_conf_intervalo.Text, Integer)
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Eventos ComboBox

    Private Sub Combo_inirouters_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_inirouters.SelectedIndexChanged
        Try
            TelnetDeluxe.ConfigTelnet.IniSeleccionado = DlxToolBox.CarpetaIniRouters & "\" & Me.Combo_inirouters.SelectedItem.ToString
            TelnetDeluxe.ConfigTelnet.Archivo = Me.Combo_inirouters.SelectedItem.ToString
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub Combo_lstip_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_lstip.SelectedIndexChanged
        Try
            TelnetDeluxe.OpcionesTD.FUNC_IPShow_Web = Me.Combo_lstip.SelectedItem.ToString
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub



    ' ###########################################################
    ' <*********** Funciones de los archivos CFG ***************>
    ' ###########################################################

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
                MessageBox.Show("Error:" & UniDlxVars.Traduccion("Gui_Routers_NohayINI"), "Error no controlado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub GuardarCFG()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr

            ' Configuración General
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_DirIp"), Me.txtbox_conf_iprouter.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Puerto"), TelnetDeluxe.ConfigTelnet.Puerto)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Refresco"), Me.txtbox_conf_intervalo.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_IniRouter"), TelnetDeluxe.ConfigTelnet.Archivo)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_User"), Me.txtbox_conf_user.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Pass"), Me.txtbox_conf_pass.Text)

            ' Miscelánea
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPublica"), TelnetDeluxe.txtbox_info_ipact.Text)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_Consola_Hora"), DlxToolBox.ComprobarCheck(Check_HoraConsola).ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_LoguearIP"), DlxToolBox.ComprobarCheck(Check_LogIP).ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_MinimizarTray"), DlxToolBox.ComprobarCheck(Check_MinimTray).ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Conf_WebIP"), TelnetDeluxe.OpcionesTD.FUNC_IPShow_Web)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_ErroresDetallados"), DlxToolBox.ComprobarCheck(Check_ErroresDetallados).ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_ErroresLog"), DlxToolBox.ComprobarCheck(Check_ErroresLog).ToString)

            ' Colores
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_Fondo"), CC_Fondo.BackColor.ToArgb.ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_defecto"), CC_defecto.BackColor.ToArgb.ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_info"), CC_info.BackColor.ToArgb.ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_router"), CC_Router.BackColor.ToArgb.ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_accion"), CC_Accion.BackColor.ToArgb.ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_dirip"), CC_DirIp.BackColor.ToArgb.ToString)
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_error"), CC_Error.BackColor.ToArgb.ToString)


            DeluxeIniMgr = Nothing
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Public Sub GuardarIP()
        Try
            Dim DeluxeIniMgr As New Dlx_IniMgr
            DeluxeIniMgr.INIMgr_Escribir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPublica"), TelnetDeluxe.txtbox_info_ipact.Text)
            DeluxeIniMgr = Nothing
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            DlxToolBox.MostrarError(oEX)
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

            TelnetDeluxe.OpcionesTD.Telnet_Intervalo = CType(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Configuracion"), UniDlxVars.VarIniPrincipal("Ini_Conf_Refresco"), TelnetDeluxe.OpcionesTD.Telnet_Intervalo.ToString), Integer)
            Me.txtbox_conf_intervalo.Text = TelnetDeluxe.OpcionesTD.Telnet_Intervalo.ToString


            'Miscelánea
            TelnetDeluxe.txtbox_info_ipact.Text = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPublica"), "")
            TelnetDeluxe.DirPING = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_IpPing"), TelnetDeluxe.DirPING)
            DlxToolBox.PonerCheck(Check_HoraConsola, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_Consola_Hora"), CStr(False))))
            DlxToolBox.PonerCheck(Check_LogIP, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_LoguearIP"), CStr(False))))
            DlxToolBox.PonerCheck(Check_MinimTray, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_MinimizarTray"), CStr(False))))
            DlxToolBox.PonerCheck(Check_ErroresDetallados, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_ErroresDetallados"), CStr(False))))
            DlxToolBox.PonerCheck(Check_ErroresLog, CBool(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Misc_ErroresLog"), CStr(False))))

            Combo_lstip.SelectedItem = DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_Misc"), UniDlxVars.VarIniPrincipal("Ini_Conf_WebIP"), "")

            'Colores
            CC_Fondo.BackColor = Color.FromArgb(CInt(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_Fondo"), TelnetDeluxe.ColorConsola.Color_Fondo.ToArgb.ToString)))
            CC_defecto.BackColor = Color.FromArgb(CInt(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_defecto"), TelnetDeluxe.ColorConsola.Color_defecto.ToArgb.ToString)))
            CC_info.BackColor = Color.FromArgb(CInt(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_info"), TelnetDeluxe.ColorConsola.Color_info.ToArgb.ToString)))
            CC_Router.BackColor = Color.FromArgb(CInt(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_router"), TelnetDeluxe.ColorConsola.Color_router.ToArgb.ToString)))
            CC_Accion.BackColor = Color.FromArgb(CInt(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_accion"), TelnetDeluxe.ColorConsola.Color_accion.ToArgb.ToString)))
            CC_DirIp.BackColor = Color.FromArgb(CInt(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_dirip"), TelnetDeluxe.ColorConsola.Color_DirIP.ToArgb.ToString)))
            CC_Error.BackColor = Color.FromArgb(CType(DeluxeIniMgr.INIMgr_Conseguir(DlxToolBox.ArchivoIni, UniDlxVars.VarIniPrincipal("Ini_ColorCon"), UniDlxVars.VarIniPrincipal("Ini_ColorCon_error"), TelnetDeluxe.ColorConsola.Color_error.ToArgb.ToString), Int32))




            ' Aplicar valores para CFG de los Routers
            TelnetDeluxe.ConfigTelnet.IniSeleccionado = DlxToolBox.CarpetaIniRouters & "\" & Me.Combo_inirouters.SelectedItem.ToString
            TelnetDeluxe.ConfigTelnet.Archivo = Me.Combo_inirouters.SelectedItem.ToString
            TelnetDeluxe.ConfigTelnet.Usuario = Me.txtbox_conf_user.Text
            TelnetDeluxe.ConfigTelnet.Pass = Me.txtbox_conf_pass.Text
            TelnetDeluxe.ConfigTelnet.Puerto = Me.txtbox_conf_puerto.Text
            TelnetDeluxe.ConfigTelnet.IPRouter = Me.txtbox_conf_iprouter.Text

            ' Aplicar Opciones Generales
            TelnetDeluxe.OpcionesTD.Consola_MostrarHora = DlxToolBox.ComprobarCheck(Check_HoraConsola)
            TelnetDeluxe.OpcionesTD.LOG_LoguearIPs = DlxToolBox.ComprobarCheck(Check_LogIP)
            TelnetDeluxe.OpcionesTD.GUI_MinimToTray = DlxToolBox.ComprobarCheck(Check_MinimTray)
            TelnetDeluxe.OpcionesTD.FUNC_IPShow_Web = Me.Combo_lstip.SelectedItem.ToString
            TelnetDeluxe.OpcionesTD.LOG_MostrarErrDetallado = DlxToolBox.ComprobarCheck(Check_ErroresDetallados)
            TelnetDeluxe.OpcionesTD.LOG_LoguearErrores = DlxToolBox.ComprobarCheck(Check_ErroresLog)

            ' Aplicar Colores
            TelnetDeluxe.ColorConsola.Color_Fondo = CC_Fondo.BackColor
            TelnetDeluxe.ColorConsola.Color_defecto = CC_defecto.BackColor
            TelnetDeluxe.ColorConsola.Color_info = CC_info.BackColor
            TelnetDeluxe.ColorConsola.Color_router = CC_Router.BackColor
            TelnetDeluxe.ColorConsola.Color_accion = CC_Accion.BackColor
            TelnetDeluxe.ColorConsola.Color_DirIP = CC_DirIp.BackColor
            TelnetDeluxe.ColorConsola.Color_error = CC_Error.BackColor


            'Aplicar los cambios
            TelnetDeluxe.ConfigCambiada()

            'Limpiar
            DeluxeIniMgr = Nothing
        Catch oEX As Exception
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_CargandoOpciones"))
            DlxToolBox.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    ' ###########################################################
    ' <************ Otros datos ***************>
    ' ###########################################################

    Private Sub CargarListaIPs()
        Try
            If File.Exists(DlxToolBox.ArchivoListaWebsIp) Then
                Dim ListaIps As New System.IO.StreamReader(DlxToolBox.ArchivoListaWebsIp)
                Dim TempBuffer As String
                Me.Combo_lstip.Items.Clear()

                Do While ListaIps.Peek() >= 0
                    TempBuffer = ListaIps.ReadLine()
                    TempBuffer = TempBuffer.ToLower
                    If TempBuffer <> String.Empty Then
                        Me.Combo_lstip.Items.Add(TempBuffer)
                    End If
                    TempBuffer = Nothing
                Loop
                If Me.Combo_lstip.Items.Count > 0 Then
                    Me.Combo_lstip.SelectedIndex = 0
                End If
                ListaIps.Close()
                ListaIps.Dispose()
            Else
                MessageBox.Show("Error:" & UniDlxVars.Traduccion("Gui_Routers_NohaylstIP"), "Error no controlado", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch oEX As Exception
            DlxToolBox.MostrarError(oEX)
            DlxToolBox.MostrarError(UniDlxVars.Traduccion("Error_CargandoListaIPs"))
            Exit Sub
        End Try
    End Sub

    Public Sub CargarOpciones()
        ConseguirIniRouters()
        CargarListaIPs()
        CargarCFG()
    End Sub

End Class