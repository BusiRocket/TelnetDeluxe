Option Strict On
Option Explicit On
Imports System.Text
Imports System.IO
Imports TelnetDeluxe.Deluxe
Public Class F_Opciones
    Inherits System.Windows.Forms.Form
    'Private WithEvents ClienteWeb As New System.Net.WebClient
    Private Errores As New DlxErrores
    Private UniDlxVars As New UniversalDeluxe
    Private Variables As New DlxVariables
    Private OpcionesMng As New DlxOpcionesManager
    Private CFGRouter As Estructuras.ConfigRouter
    Private OpcionesTD As Deluxe.Estructuras.Opciones_General
    Private BufferUser As String = ""


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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub TD_Opciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            CargarOpciones()
            Me.OpcionesTD = OpcionesMng.OpcionesObj()
            SelColor.AllowFullOpen = True
            SelColor.FullOpen = True

            lv_inforouter.Enabled = False
            lv_inforouter.Columns.Clear()
            lv_inforouter.Columns.Add("Descripción", 110, HorizontalAlignment.Center)
            lv_inforouter.Columns.Add("Valor", 160, HorizontalAlignment.Center)
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    '////////////////////////////////////////////////////////////////////
    '/// Botones para salir

    Private Sub boton_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_aceptar.Click
        Try
            OpcionesMng.CambiarOpciones(Me.OpcionesTD)
            OpcionesMng.GuardarCFG()
            OpcionesMng.CargarCFG()
            Me.OpcionesTD = OpcionesMng.OpcionesObj
            Me.Close()
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub boton_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_cancelar.Click
        Try
            OpcionesMng.CargarCFG()
            Me.Close()
            Exit Sub
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub boton_aplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boton_aplicar.Click
        Try
            OpcionesMng.CambiarOpciones(Me.OpcionesTD)
            OpcionesMng.GuardarCFG()
            OpcionesMng.CargarCFG()
            lv_inforouter.Enabled = False
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
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

    Private Sub txtbox_conf_intervalo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtbox_conf_intervalo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If String.IsNullOrEmpty(Me.txtbox_conf_intervalo.Text) Or CType(Me.txtbox_conf_intervalo.Text, Integer) < 1 Then
                Errores.MostrarError(UniDlxVars.Traduccion("Error_IntervaloLow"))
                Errores.MostrarError(UniDlxVars.Traduccion("Error_IntervaloLowTip"))
                Me.txtbox_conf_intervalo.Text = Me.OpcionesTD.Opciones.Telnet_Intervalo.ToString
            Else
                Me.OpcionesTD.Opciones.Telnet_Intervalo = CType(Me.txtbox_conf_intervalo.Text, Integer)
            End If
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    '////////////////////////////////////////////////////////////////////
    '/// Eventos ComboBox

    Private Sub Combo_inirouters_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_inirouters.SelectedIndexChanged
        Try
            TD_Principal.ConfigTelnet.IniSeleccionado = Variables.CarpetaIniRouters & "\" & Me.Combo_inirouters.SelectedItem.ToString
            TD_Principal.ConfigTelnet.Archivo = Me.Combo_inirouters.SelectedItem.ToString

            Me.CFGRouter = Nothing
            CFGRouter.ArchivoIni = Variables.CarpetaIniRouters & "\" & Me.Combo_inirouters.SelectedItem.ToString
            CFGRouter = OpcionesMng.CargarCFGRouter(CFGRouter)

            lv_inforouter.Enabled = True
            lv_inforouter.Items.Clear()
            lv_inforouter.Items.Add("Autor")
            lv_inforouter.Items(lv_inforouter.Items.Count - 1).SubItems.Add(CFGRouter.Autor)

            lv_inforouter.Items.Add("Fecha")
            lv_inforouter.Items(lv_inforouter.Items.Count - 1).SubItems.Add(CFGRouter.Fecha)

            lv_inforouter.Items.Add("Modelo/Marca Router")
            lv_inforouter.Items(lv_inforouter.Items.Count - 1).SubItems.Add(CFGRouter.NombreRouter)

            lv_inforouter.Items.Add("Modo de Conexión")
            lv_inforouter.Items(lv_inforouter.Items.Count - 1).SubItems.Add(CFGRouter.Modo)

            lv_inforouter.Items.Add("Versión del Archivo")
            lv_inforouter.Items(lv_inforouter.Items.Count - 1).SubItems.Add(CFGRouter.Revision)

        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub Combo_inirouters_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Combo_inirouters.GotFocus
        Try
            lv_inforouter.Enabled = True
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub


    Private Sub Combo_lstip_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_lstip.SelectedIndexChanged
        Try
            Me.OpcionesTD.Opciones.IP_WebConseguir = Me.Combo_lstip.SelectedItem.ToString
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub



    ' ###########################################################
    ' <*********** Funciones de los archivos CFG ***************>
    ' ###########################################################

    Sub CargarBoxRouters()
        Try
            Dim ListaINIs() As String = OpcionesMng.ListaINIs
            Me.Combo_inirouters.Items.Clear()
            If ListaINIs.Length <> 0 Then
                For Each CFGRouter As String In ListaINIs
                    CFGRouter = CFGRouter.Substring(Variables.CarpetaIniRouters.Length + 1)
                    Me.Combo_inirouters.Items.Add(CFGRouter)
                Next
                If Me.Combo_inirouters.Items.Count > 0 Then
                    Me.Combo_inirouters.SelectedIndex = 0
                End If
            Else
                Errores.MostrarError("Error:" & UniDlxVars.Traduccion("Gui_Routers_NohayINI"))
            End If
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub



    ' ###########################################################
    ' <************ Otros datos ***************>
    ' ###########################################################

    Private Sub CargarListaIPs()
        Try
            If File.Exists(Variables.ArchivoListaWebsIp) Then
                Dim ListaIps As New System.IO.StreamReader(Variables.ArchivoListaWebsIp)
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
                Errores.MostrarError("Error:" & UniDlxVars.Traduccion("Gui_Routers_NohaylstIP"))
            End If

        Catch oEX As Exception
            Errores.MostrarError(oEX)
            Errores.MostrarError(UniDlxVars.Traduccion("Error_CargandoListaIPs"))
            Exit Sub
        End Try
    End Sub

    Public Sub CargarOpciones()
        Try
            CargarBoxRouters()
            CargarListaIPs()
            OpcionesMng.CargarCFG()
            OpcionesTD = OpcionesMng.OpcionesObj()
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub

    Private Sub Check_SoloPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_SoloPass.CheckedChanged
        Try
            Dim Formularios As New DlxFormularios
            If Formularios.ComprobarCheck(Check_SoloPass) Then
                BufferUser = txtbox_conf_user.Text
                txtbox_conf_user.Text = ""
                txtbox_conf_user.Enabled = False
                label_conf_susuario.Enabled = False
            Else
                txtbox_conf_user.Text = BufferUser
                txtbox_conf_user.Enabled = True
                label_conf_susuario.Enabled = True
            End If
            Formularios = Nothing
        Catch oEX As Exception
            Errores.MostrarError(UniDlxVars.Traduccion("Error_Generico"))
            Errores.MostrarError(oEX)
            Exit Sub
        End Try
    End Sub
End Class