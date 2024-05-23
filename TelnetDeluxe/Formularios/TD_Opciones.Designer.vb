<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TD_Opciones
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TD_Opciones))
        Me.TabOpciones = New System.Windows.Forms.TabControl
        Me.Tab_Principal = New System.Windows.Forms.TabPage
        Me.Grupo_Misc = New System.Windows.Forms.GroupBox
        Me.label_conf_consip = New System.Windows.Forms.Label
        Me.Combo_lstip = New System.Windows.Forms.ComboBox
        Me.Grupo_General = New System.Windows.Forms.GroupBox
        Me.Check_ErroresDetallados = New System.Windows.Forms.CheckBox
        Me.Check_MinimTray = New System.Windows.Forms.CheckBox
        Me.Check_LogIP = New System.Windows.Forms.CheckBox
        Me.Check_HoraConsola = New System.Windows.Forms.CheckBox
        Me.Grupo_Telnet = New System.Windows.Forms.GroupBox
        Me.txtbox_conf_intervalo = New System.Windows.Forms.TextBox
        Me.label_conf_interv = New System.Windows.Forms.Label
        Me.tab_router = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.label_conf_inirouter = New System.Windows.Forms.Label
        Me.Combo_inirouters = New System.Windows.Forms.ComboBox
        Me.GrupoConfig = New System.Windows.Forms.GroupBox
        Me.label_conf_cont = New System.Windows.Forms.Label
        Me.label_conf_susuario = New System.Windows.Forms.Label
        Me.txtbox_conf_pass = New System.Windows.Forms.TextBox
        Me.txtbox_conf_puerto = New System.Windows.Forms.TextBox
        Me.txtbox_conf_user = New System.Windows.Forms.TextBox
        Me.label_conf_port = New System.Windows.Forms.Label
        Me.txtbox_conf_iprouter = New System.Windows.Forms.TextBox
        Me.label_conf_siprouter = New System.Windows.Forms.Label
        Me.tab_colores = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CC_Router = New System.Windows.Forms.PictureBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CC_DirIp = New System.Windows.Forms.PictureBox
        Me.CC_Accion = New System.Windows.Forms.PictureBox
        Me.CC_Error = New System.Windows.Forms.PictureBox
        Me.CC_info = New System.Windows.Forms.PictureBox
        Me.CC_defecto = New System.Windows.Forms.PictureBox
        Me.CC_Fondo = New System.Windows.Forms.PictureBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.boton_aceptar = New System.Windows.Forms.Button
        Me.boton_cancelar = New System.Windows.Forms.Button
        Me.boton_aplicar = New System.Windows.Forms.Button
        Me.label_conf_pass = New System.Windows.Forms.Label
        Me.label_conf_Usuario = New System.Windows.Forms.Label
        Me.txtbox_conf_password = New System.Windows.Forms.TextBox
        Me.txtbox_bad2 = New System.Windows.Forms.TextBox
        Me.txtbox_bad3 = New System.Windows.Forms.TextBox
        Me.label_conf_puerto = New System.Windows.Forms.Label
        Me.txtbox_oculto = New System.Windows.Forms.TextBox
        Me.label_conf_iprouter = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.SelColor = New System.Windows.Forms.ColorDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Check_ErroresLog = New System.Windows.Forms.CheckBox
        Me.TabOpciones.SuspendLayout()
        Me.Tab_Principal.SuspendLayout()
        Me.Grupo_Misc.SuspendLayout()
        Me.Grupo_General.SuspendLayout()
        Me.Grupo_Telnet.SuspendLayout()
        Me.tab_router.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GrupoConfig.SuspendLayout()
        Me.tab_colores.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CC_Router, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CC_DirIp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CC_Accion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CC_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CC_info, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CC_defecto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CC_Fondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabOpciones
        '
        Me.TabOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabOpciones.Controls.Add(Me.Tab_Principal)
        Me.TabOpciones.Controls.Add(Me.tab_router)
        Me.TabOpciones.Controls.Add(Me.tab_colores)
        Me.TabOpciones.Location = New System.Drawing.Point(2, 2)
        Me.TabOpciones.Name = "TabOpciones"
        Me.TabOpciones.SelectedIndex = 0
        Me.TabOpciones.Size = New System.Drawing.Size(581, 330)
        Me.TabOpciones.TabIndex = 1000
        '
        'Tab_Principal
        '
        Me.Tab_Principal.Controls.Add(Me.Grupo_Misc)
        Me.Tab_Principal.Controls.Add(Me.Grupo_General)
        Me.Tab_Principal.Controls.Add(Me.Grupo_Telnet)
        Me.Tab_Principal.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Principal.Name = "Tab_Principal"
        Me.Tab_Principal.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Principal.Size = New System.Drawing.Size(573, 304)
        Me.Tab_Principal.TabIndex = 0
        Me.Tab_Principal.Text = "Opciones Principales"
        Me.Tab_Principal.UseVisualStyleBackColor = True
        '
        'Grupo_Misc
        '
        Me.Grupo_Misc.Controls.Add(Me.label_conf_consip)
        Me.Grupo_Misc.Controls.Add(Me.Combo_lstip)
        Me.Grupo_Misc.Location = New System.Drawing.Point(6, 71)
        Me.Grupo_Misc.Name = "Grupo_Misc"
        Me.Grupo_Misc.Size = New System.Drawing.Size(268, 64)
        Me.Grupo_Misc.TabIndex = 1000
        Me.Grupo_Misc.TabStop = False
        Me.Grupo_Misc.Text = "Miscelánea"
        '
        'label_conf_consip
        '
        Me.label_conf_consip.AutoSize = True
        Me.label_conf_consip.Location = New System.Drawing.Point(9, 18)
        Me.label_conf_consip.Name = "label_conf_consip"
        Me.label_conf_consip.Size = New System.Drawing.Size(156, 13)
        Me.label_conf_consip.TabIndex = 1000
        Me.label_conf_consip.Text = "Conseguir IP pública de la web:"
        '
        'Combo_lstip
        '
        Me.Combo_lstip.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Combo_lstip.FormattingEnabled = True
        Me.Combo_lstip.Location = New System.Drawing.Point(12, 36)
        Me.Combo_lstip.MaxDropDownItems = 15
        Me.Combo_lstip.Name = "Combo_lstip"
        Me.Combo_lstip.Size = New System.Drawing.Size(250, 21)
        Me.Combo_lstip.TabIndex = 20
        '
        'Grupo_General
        '
        Me.Grupo_General.Controls.Add(Me.Check_ErroresLog)
        Me.Grupo_General.Controls.Add(Me.Check_ErroresDetallados)
        Me.Grupo_General.Controls.Add(Me.Check_MinimTray)
        Me.Grupo_General.Controls.Add(Me.Check_LogIP)
        Me.Grupo_General.Controls.Add(Me.Check_HoraConsola)
        Me.Grupo_General.Location = New System.Drawing.Point(280, 6)
        Me.Grupo_General.Name = "Grupo_General"
        Me.Grupo_General.Size = New System.Drawing.Size(287, 129)
        Me.Grupo_General.TabIndex = 1000
        Me.Grupo_General.TabStop = False
        Me.Grupo_General.Text = "General"
        '
        'Check_ErroresDetallados
        '
        Me.Check_ErroresDetallados.AutoSize = True
        Me.Check_ErroresDetallados.Location = New System.Drawing.Point(6, 82)
        Me.Check_ErroresDetallados.Name = "Check_ErroresDetallados"
        Me.Check_ErroresDetallados.Size = New System.Drawing.Size(147, 17)
        Me.Check_ErroresDetallados.TabIndex = 43
        Me.Check_ErroresDetallados.Text = "Mostrar errores detallados"
        Me.Check_ErroresDetallados.UseVisualStyleBackColor = True
        '
        'Check_MinimTray
        '
        Me.Check_MinimTray.AutoSize = True
        Me.Check_MinimTray.Location = New System.Drawing.Point(6, 61)
        Me.Check_MinimTray.Name = "Check_MinimTray"
        Me.Check_MinimTray.Size = New System.Drawing.Size(176, 17)
        Me.Check_MinimTray.TabIndex = 42
        Me.Check_MinimTray.Text = "Minimizar al área de notificación"
        Me.Check_MinimTray.UseVisualStyleBackColor = True
        '
        'Check_LogIP
        '
        Me.Check_LogIP.AutoSize = True
        Me.Check_LogIP.Location = New System.Drawing.Point(6, 40)
        Me.Check_LogIP.Name = "Check_LogIP"
        Me.Check_LogIP.Size = New System.Drawing.Size(265, 17)
        Me.Check_LogIP.TabIndex = 41
        Me.Check_LogIP.Text = "Guardar las IP's conseguidas en el archivo ""ip.log"""
        Me.Check_LogIP.UseVisualStyleBackColor = True
        '
        'Check_HoraConsola
        '
        Me.Check_HoraConsola.AutoSize = True
        Me.Check_HoraConsola.Location = New System.Drawing.Point(6, 19)
        Me.Check_HoraConsola.Name = "Check_HoraConsola"
        Me.Check_HoraConsola.Size = New System.Drawing.Size(162, 17)
        Me.Check_HoraConsola.TabIndex = 40
        Me.Check_HoraConsola.Text = "&Mostrar la hora en la consola"
        Me.Check_HoraConsola.UseVisualStyleBackColor = True
        '
        'Grupo_Telnet
        '
        Me.Grupo_Telnet.Controls.Add(Me.txtbox_conf_intervalo)
        Me.Grupo_Telnet.Controls.Add(Me.label_conf_interv)
        Me.Grupo_Telnet.Location = New System.Drawing.Point(6, 6)
        Me.Grupo_Telnet.Name = "Grupo_Telnet"
        Me.Grupo_Telnet.Size = New System.Drawing.Size(268, 59)
        Me.Grupo_Telnet.TabIndex = 1000
        Me.Grupo_Telnet.TabStop = False
        Me.Grupo_Telnet.Text = "Telnet"
        '
        'txtbox_conf_intervalo
        '
        Me.txtbox_conf_intervalo.BackColor = System.Drawing.Color.White
        Me.txtbox_conf_intervalo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_intervalo.Location = New System.Drawing.Point(121, 27)
        Me.txtbox_conf_intervalo.Name = "txtbox_conf_intervalo"
        Me.txtbox_conf_intervalo.Size = New System.Drawing.Size(29, 13)
        Me.txtbox_conf_intervalo.TabIndex = 1
        Me.txtbox_conf_intervalo.Text = "3"
        Me.txtbox_conf_intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_interv
        '
        Me.label_conf_interv.AutoSize = True
        Me.label_conf_interv.Location = New System.Drawing.Point(9, 27)
        Me.label_conf_interv.Name = "label_conf_interv"
        Me.label_conf_interv.Size = New System.Drawing.Size(109, 13)
        Me.label_conf_interv.TabIndex = 1000
        Me.label_conf_interv.Text = "Intervalo Envío (seg):"
        '
        'tab_router
        '
        Me.tab_router.Controls.Add(Me.GroupBox2)
        Me.tab_router.Controls.Add(Me.GrupoConfig)
        Me.tab_router.Location = New System.Drawing.Point(4, 22)
        Me.tab_router.Name = "tab_router"
        Me.tab_router.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_router.Size = New System.Drawing.Size(573, 304)
        Me.tab_router.TabIndex = 1
        Me.tab_router.Text = "Configuración Router"
        Me.tab_router.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.label_conf_inirouter)
        Me.GroupBox2.Controls.Add(Me.Combo_inirouters)
        Me.GroupBox2.Location = New System.Drawing.Point(270, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 112)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "A&rchivo de Configuración"
        '
        'label_conf_inirouter
        '
        Me.label_conf_inirouter.AutoSize = True
        Me.label_conf_inirouter.Location = New System.Drawing.Point(9, 24)
        Me.label_conf_inirouter.Name = "label_conf_inirouter"
        Me.label_conf_inirouter.Size = New System.Drawing.Size(101, 13)
        Me.label_conf_inirouter.TabIndex = 6
        Me.label_conf_inirouter.Text = "Seleccionar Router:"
        '
        'Combo_inirouters
        '
        Me.Combo_inirouters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Combo_inirouters.FormattingEnabled = True
        Me.Combo_inirouters.Location = New System.Drawing.Point(121, 19)
        Me.Combo_inirouters.MaxDropDownItems = 15
        Me.Combo_inirouters.Name = "Combo_inirouters"
        Me.Combo_inirouters.Size = New System.Drawing.Size(131, 21)
        Me.Combo_inirouters.TabIndex = 1
        '
        'GrupoConfig
        '
        Me.GrupoConfig.Controls.Add(Me.label_conf_cont)
        Me.GrupoConfig.Controls.Add(Me.label_conf_susuario)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_pass)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_puerto)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_user)
        Me.GrupoConfig.Controls.Add(Me.label_conf_port)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_iprouter)
        Me.GrupoConfig.Controls.Add(Me.label_conf_siprouter)
        Me.GrupoConfig.Location = New System.Drawing.Point(6, 6)
        Me.GrupoConfig.Name = "GrupoConfig"
        Me.GrupoConfig.Size = New System.Drawing.Size(258, 112)
        Me.GrupoConfig.TabIndex = 2
        Me.GrupoConfig.TabStop = False
        Me.GrupoConfig.Text = "&Opciones del router"
        '
        'label_conf_cont
        '
        Me.label_conf_cont.AutoSize = True
        Me.label_conf_cont.Location = New System.Drawing.Point(9, 82)
        Me.label_conf_cont.Name = "label_conf_cont"
        Me.label_conf_cont.Size = New System.Drawing.Size(64, 13)
        Me.label_conf_cont.TabIndex = 10
        Me.label_conf_cont.Text = "Contraseña:"
        '
        'label_conf_susuario
        '
        Me.label_conf_susuario.AutoSize = True
        Me.label_conf_susuario.Location = New System.Drawing.Point(9, 63)
        Me.label_conf_susuario.Name = "label_conf_susuario"
        Me.label_conf_susuario.Size = New System.Drawing.Size(46, 13)
        Me.label_conf_susuario.TabIndex = 9
        Me.label_conf_susuario.Text = "Usuario:"
        '
        'txtbox_conf_pass
        '
        Me.txtbox_conf_pass.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_pass.Location = New System.Drawing.Point(112, 82)
        Me.txtbox_conf_pass.Name = "txtbox_conf_pass"
        Me.txtbox_conf_pass.Size = New System.Drawing.Size(78, 13)
        Me.txtbox_conf_pass.TabIndex = 8
        Me.txtbox_conf_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtbox_conf_puerto
        '
        Me.txtbox_conf_puerto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_puerto.Location = New System.Drawing.Point(112, 44)
        Me.txtbox_conf_puerto.Name = "txtbox_conf_puerto"
        Me.txtbox_conf_puerto.Size = New System.Drawing.Size(53, 13)
        Me.txtbox_conf_puerto.TabIndex = 6
        Me.txtbox_conf_puerto.Text = "23"
        Me.txtbox_conf_puerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtbox_conf_user
        '
        Me.txtbox_conf_user.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_user.Location = New System.Drawing.Point(112, 63)
        Me.txtbox_conf_user.Name = "txtbox_conf_user"
        Me.txtbox_conf_user.Size = New System.Drawing.Size(78, 13)
        Me.txtbox_conf_user.TabIndex = 7
        Me.txtbox_conf_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_port
        '
        Me.label_conf_port.AutoSize = True
        Me.label_conf_port.Location = New System.Drawing.Point(9, 44)
        Me.label_conf_port.Name = "label_conf_port"
        Me.label_conf_port.Size = New System.Drawing.Size(41, 13)
        Me.label_conf_port.TabIndex = 2
        Me.label_conf_port.Text = "Puerto:"
        '
        'txtbox_conf_iprouter
        '
        Me.txtbox_conf_iprouter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_iprouter.Location = New System.Drawing.Point(112, 25)
        Me.txtbox_conf_iprouter.Name = "txtbox_conf_iprouter"
        Me.txtbox_conf_iprouter.Size = New System.Drawing.Size(78, 13)
        Me.txtbox_conf_iprouter.TabIndex = 5
        Me.txtbox_conf_iprouter.Text = "192.168.1.1"
        Me.txtbox_conf_iprouter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_siprouter
        '
        Me.label_conf_siprouter.AutoSize = True
        Me.label_conf_siprouter.Location = New System.Drawing.Point(9, 25)
        Me.label_conf_siprouter.Name = "label_conf_siprouter"
        Me.label_conf_siprouter.Size = New System.Drawing.Size(72, 13)
        Me.label_conf_siprouter.TabIndex = 0
        Me.label_conf_siprouter.Text = "IP del Router:"
        '
        'tab_colores
        '
        Me.tab_colores.Controls.Add(Me.GroupBox3)
        Me.tab_colores.Location = New System.Drawing.Point(4, 22)
        Me.tab_colores.Name = "tab_colores"
        Me.tab_colores.Size = New System.Drawing.Size(573, 304)
        Me.tab_colores.TabIndex = 2
        Me.tab_colores.Text = "Colores"
        Me.tab_colores.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CC_Router)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.CC_DirIp)
        Me.GroupBox3.Controls.Add(Me.CC_Accion)
        Me.GroupBox3.Controls.Add(Me.CC_Error)
        Me.GroupBox3.Controls.Add(Me.CC_info)
        Me.GroupBox3.Controls.Add(Me.CC_defecto)
        Me.GroupBox3.Controls.Add(Me.CC_Fondo)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(258, 195)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "&Colores de la consola"
        '
        'CC_Router
        '
        Me.CC_Router.Location = New System.Drawing.Point(19, 84)
        Me.CC_Router.Name = "CC_Router"
        Me.CC_Router.Size = New System.Drawing.Size(41, 13)
        Me.CC_Router.TabIndex = 12
        Me.CC_Router.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(66, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Mensajes del Router:"
        '
        'CC_DirIp
        '
        Me.CC_DirIp.Location = New System.Drawing.Point(19, 141)
        Me.CC_DirIp.Name = "CC_DirIp"
        Me.CC_DirIp.Size = New System.Drawing.Size(41, 13)
        Me.CC_DirIp.TabIndex = 10
        Me.CC_DirIp.TabStop = False
        '
        'CC_Accion
        '
        Me.CC_Accion.Location = New System.Drawing.Point(19, 122)
        Me.CC_Accion.Name = "CC_Accion"
        Me.CC_Accion.Size = New System.Drawing.Size(41, 13)
        Me.CC_Accion.TabIndex = 9
        Me.CC_Accion.TabStop = False
        '
        'CC_Error
        '
        Me.CC_Error.Location = New System.Drawing.Point(19, 103)
        Me.CC_Error.Name = "CC_Error"
        Me.CC_Error.Size = New System.Drawing.Size(41, 13)
        Me.CC_Error.TabIndex = 8
        Me.CC_Error.TabStop = False
        '
        'CC_info
        '
        Me.CC_info.Location = New System.Drawing.Point(19, 65)
        Me.CC_info.Name = "CC_info"
        Me.CC_info.Size = New System.Drawing.Size(41, 13)
        Me.CC_info.TabIndex = 7
        Me.CC_info.TabStop = False
        '
        'CC_defecto
        '
        Me.CC_defecto.Location = New System.Drawing.Point(19, 46)
        Me.CC_defecto.Name = "CC_defecto"
        Me.CC_defecto.Size = New System.Drawing.Size(41, 13)
        Me.CC_defecto.TabIndex = 6
        Me.CC_defecto.TabStop = False
        '
        'CC_Fondo
        '
        Me.CC_Fondo.Location = New System.Drawing.Point(19, 27)
        Me.CC_Fondo.Name = "CC_Fondo"
        Me.CC_Fondo.Size = New System.Drawing.Size(41, 13)
        Me.CC_Fondo.TabIndex = 4
        Me.CC_Fondo.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(66, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Dirección IP:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(66, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Mensajes de Acción:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(66, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Mensajes de Error:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(66, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Mensajes de Información:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(66, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Texto por Defecto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(66, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Color de Fondo:"
        '
        'boton_aceptar
        '
        Me.boton_aceptar.Location = New System.Drawing.Point(342, 339)
        Me.boton_aceptar.Name = "boton_aceptar"
        Me.boton_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.boton_aceptar.TabIndex = 90
        Me.boton_aceptar.Text = "&Aceptar"
        Me.boton_aceptar.UseVisualStyleBackColor = True
        '
        'boton_cancelar
        '
        Me.boton_cancelar.Location = New System.Drawing.Point(423, 339)
        Me.boton_cancelar.Name = "boton_cancelar"
        Me.boton_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.boton_cancelar.TabIndex = 91
        Me.boton_cancelar.Text = "&Cancelar"
        Me.boton_cancelar.UseVisualStyleBackColor = True
        '
        'boton_aplicar
        '
        Me.boton_aplicar.Location = New System.Drawing.Point(504, 339)
        Me.boton_aplicar.Name = "boton_aplicar"
        Me.boton_aplicar.Size = New System.Drawing.Size(75, 23)
        Me.boton_aplicar.TabIndex = 92
        Me.boton_aplicar.Text = "A&plicar"
        Me.boton_aplicar.UseVisualStyleBackColor = True
        '
        'label_conf_pass
        '
        Me.label_conf_pass.AutoSize = True
        Me.label_conf_pass.Location = New System.Drawing.Point(9, 82)
        Me.label_conf_pass.Name = "label_conf_pass"
        Me.label_conf_pass.Size = New System.Drawing.Size(64, 13)
        Me.label_conf_pass.TabIndex = 10
        Me.label_conf_pass.Text = "Contraseña:"
        '
        'label_conf_Usuario
        '
        Me.label_conf_Usuario.AutoSize = True
        Me.label_conf_Usuario.Location = New System.Drawing.Point(9, 63)
        Me.label_conf_Usuario.Name = "label_conf_Usuario"
        Me.label_conf_Usuario.Size = New System.Drawing.Size(46, 13)
        Me.label_conf_Usuario.TabIndex = 9
        Me.label_conf_Usuario.Text = "Usuario:"
        '
        'txtbox_conf_password
        '
        Me.txtbox_conf_password.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_password.Location = New System.Drawing.Point(112, 82)
        Me.txtbox_conf_password.Name = "txtbox_conf_password"
        Me.txtbox_conf_password.Size = New System.Drawing.Size(78, 13)
        Me.txtbox_conf_password.TabIndex = 8
        Me.txtbox_conf_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtbox_bad2
        '
        Me.txtbox_bad2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_bad2.Location = New System.Drawing.Point(112, 44)
        Me.txtbox_bad2.Name = "txtbox_bad2"
        Me.txtbox_bad2.Size = New System.Drawing.Size(53, 13)
        Me.txtbox_bad2.TabIndex = 6
        Me.txtbox_bad2.Text = "23"
        Me.txtbox_bad2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtbox_bad3
        '
        Me.txtbox_bad3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_bad3.Location = New System.Drawing.Point(1, 2)
        Me.txtbox_bad3.Name = "txtbox_bad3"
        Me.txtbox_bad3.Size = New System.Drawing.Size(12378, 13)
        Me.txtbox_bad3.TabIndex = 7
        Me.txtbox_bad3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_puerto
        '
        Me.label_conf_puerto.AutoSize = True
        Me.label_conf_puerto.Location = New System.Drawing.Point(9, 44)
        Me.label_conf_puerto.Name = "label_conf_puerto"
        Me.label_conf_puerto.Size = New System.Drawing.Size(41, 13)
        Me.label_conf_puerto.TabIndex = 2
        Me.label_conf_puerto.Text = "Puerto:"
        '
        'txtbox_oculto
        '
        Me.txtbox_oculto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_oculto.Location = New System.Drawing.Point(312, 25)
        Me.txtbox_oculto.Name = "txtbox_oculto"
        Me.txtbox_oculto.Size = New System.Drawing.Size(578, 13)
        Me.txtbox_oculto.TabIndex = 5
        Me.txtbox_oculto.Text = "192.168.1.1"
        Me.txtbox_oculto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_iprouter
        '
        Me.label_conf_iprouter.AutoSize = True
        Me.label_conf_iprouter.Location = New System.Drawing.Point(9, 25)
        Me.label_conf_iprouter.Name = "label_conf_iprouter"
        Me.label_conf_iprouter.Size = New System.Drawing.Size(72, 13)
        Me.label_conf_iprouter.TabIndex = 0
        Me.label_conf_iprouter.Text = "IP del Router:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Seleccionar Router:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(121, 19)
        Me.ComboBox1.MaxDropDownItems = 15
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(131, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'SelColor
        '
        Me.SelColor.AnyColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Contraseña:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Usuario:"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(112, 82)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 13)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(112, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(53, 13)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = "23"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox3.Location = New System.Drawing.Point(112, 63)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(78, 13)
        Me.TextBox3.TabIndex = 7
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Puerto:"
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(112, 25)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(78, 13)
        Me.TextBox4.TabIndex = 5
        Me.TextBox4.Text = "192.168.1.1"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "IP del Router:"
        '
        'Check_ErroresLog
        '
        Me.Check_ErroresLog.AutoSize = True
        Me.Check_ErroresLog.Location = New System.Drawing.Point(6, 103)
        Me.Check_ErroresLog.Name = "Check_ErroresLog"
        Me.Check_ErroresLog.Size = New System.Drawing.Size(226, 17)
        Me.Check_ErroresLog.TabIndex = 44
        Me.Check_ErroresLog.Text = "Guardar errores en el archivo ""Errores.log"""
        Me.Check_ErroresLog.UseVisualStyleBackColor = True
        '
        'TD_Opciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 366)
        Me.Controls.Add(Me.boton_aplicar)
        Me.Controls.Add(Me.boton_cancelar)
        Me.Controls.Add(Me.boton_aceptar)
        Me.Controls.Add(Me.TabOpciones)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TD_Opciones"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de Telnet Deluxe"
        Me.TopMost = True
        Me.TabOpciones.ResumeLayout(False)
        Me.Tab_Principal.ResumeLayout(False)
        Me.Grupo_Misc.ResumeLayout(False)
        Me.Grupo_Misc.PerformLayout()
        Me.Grupo_General.ResumeLayout(False)
        Me.Grupo_General.PerformLayout()
        Me.Grupo_Telnet.ResumeLayout(False)
        Me.Grupo_Telnet.PerformLayout()
        Me.tab_router.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GrupoConfig.ResumeLayout(False)
        Me.GrupoConfig.PerformLayout()
        Me.tab_colores.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CC_Router, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CC_DirIp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CC_Accion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CC_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CC_info, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CC_defecto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CC_Fondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabOpciones As System.Windows.Forms.TabControl
    Friend WithEvents Tab_Principal As System.Windows.Forms.TabPage
    Friend WithEvents tab_router As System.Windows.Forms.TabPage
    Friend WithEvents Grupo_Telnet As System.Windows.Forms.GroupBox
    Friend WithEvents txtbox_conf_intervalo As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_interv As System.Windows.Forms.Label
    Friend WithEvents boton_aceptar As System.Windows.Forms.Button
    Friend WithEvents boton_cancelar As System.Windows.Forms.Button
    Friend WithEvents boton_aplicar As System.Windows.Forms.Button
    Friend WithEvents GrupoConfig As System.Windows.Forms.GroupBox
    Friend WithEvents label_conf_cont As System.Windows.Forms.Label
    Friend WithEvents label_conf_susuario As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_pass As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_conf_puerto As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_conf_user As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_port As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_iprouter As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_siprouter As System.Windows.Forms.Label
    Friend WithEvents label_conf_pass As System.Windows.Forms.Label
    Friend WithEvents label_conf_Usuario As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_password As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_bad2 As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_bad3 As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_puerto As System.Windows.Forms.Label
    Friend WithEvents txtbox_oculto As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_iprouter As System.Windows.Forms.Label
    Friend WithEvents Grupo_General As System.Windows.Forms.GroupBox
    Friend WithEvents Check_HoraConsola As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents label_conf_inirouter As System.Windows.Forms.Label
    Friend WithEvents Combo_inirouters As System.Windows.Forms.ComboBox
    Friend WithEvents Check_LogIP As System.Windows.Forms.CheckBox
    Friend WithEvents Check_MinimTray As System.Windows.Forms.CheckBox
    Friend WithEvents label_conf_consip As System.Windows.Forms.Label
    Friend WithEvents Combo_lstip As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Grupo_Misc As System.Windows.Forms.GroupBox
    Friend WithEvents tab_colores As System.Windows.Forms.TabPage
    Friend WithEvents SelColor As System.Windows.Forms.ColorDialog
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CC_Fondo As System.Windows.Forms.PictureBox
    Friend WithEvents CC_DirIp As System.Windows.Forms.PictureBox
    Friend WithEvents CC_Accion As System.Windows.Forms.PictureBox
    Friend WithEvents CC_Error As System.Windows.Forms.PictureBox
    Friend WithEvents CC_info As System.Windows.Forms.PictureBox
    Friend WithEvents CC_defecto As System.Windows.Forms.PictureBox
    Friend WithEvents CC_Router As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Check_ErroresDetallados As System.Windows.Forms.CheckBox
    Friend WithEvents Check_ErroresLog As System.Windows.Forms.CheckBox
End Class
