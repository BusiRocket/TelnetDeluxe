<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TelnetDeluxe
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TelnetDeluxe))
        Me.Currante_Ping = New System.ComponentModel.BackgroundWorker
        Me.GrupoConfig = New System.Windows.Forms.GroupBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.label_info_ipant = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.txtbox_info_ipact = New System.Windows.Forms.TextBox
        Me.label_inetconex = New System.Windows.Forms.Label
        Me.label_info_ipact = New System.Windows.Forms.Label
        Me.txtbox_info_ipant = New System.Windows.Forms.TextBox
        Me.label_estado = New System.Windows.Forms.Label
        Me.crono_principal = New System.Windows.Forms.Timer(Me.components)
        Me.GrupoConsola = New System.Windows.Forms.GroupBox
        Me.Consola = New System.Windows.Forms.RichTextBox
        Me.MenuConsola = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuConsola_Copiar = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuConsola_SelTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuConsola_Limpiar = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenovarIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestaurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer_ConexInet = New System.Windows.Forms.Timer(Me.components)
        Me.TDBarraEstado = New System.Windows.Forms.StatusStrip
        Me.TDBE_labelinfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.TDBE_Progreso = New System.Windows.Forms.ToolStripProgressBar
        Me.TDLB_Progreso = New System.Windows.Forms.ToolStripStatusLabel
        Me.Currante_ConseguirIP = New System.ComponentModel.BackgroundWorker
        Me.TD_MenuPrincipal = New System.Windows.Forms.MenuStrip
        Me.TD_MP_Funciones = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_EjecutarComandos = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_Salir = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_Opciones = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_Herramientas = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_MostrarInfoSistema = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_MostrarInfoRed = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_ConseguirIP = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_AcercaDe = New System.Windows.Forms.ToolStripMenuItem
        Me.Currante_Winsock = New System.ComponentModel.BackgroundWorker
        Me.GrupoConfig.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrupoConsola.SuspendLayout()
        Me.MenuConsola.SuspendLayout()
        Me.MenuTray.SuspendLayout()
        Me.TDBarraEstado.SuspendLayout()
        Me.TD_MenuPrincipal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Currante_Ping
        '
        '
        'GrupoConfig
        '
        Me.GrupoConfig.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrupoConfig.Controls.Add(Me.PictureBox2)
        Me.GrupoConfig.Controls.Add(Me.label_info_ipant)
        Me.GrupoConfig.Controls.Add(Me.PictureBox1)
        Me.GrupoConfig.Controls.Add(Me.txtbox_info_ipact)
        Me.GrupoConfig.Controls.Add(Me.label_inetconex)
        Me.GrupoConfig.Controls.Add(Me.label_info_ipact)
        Me.GrupoConfig.Controls.Add(Me.txtbox_info_ipant)
        Me.GrupoConfig.Controls.Add(Me.label_estado)
        Me.GrupoConfig.Location = New System.Drawing.Point(12, 27)
        Me.GrupoConfig.Name = "GrupoConfig"
        Me.GrupoConfig.Size = New System.Drawing.Size(656, 49)
        Me.GrupoConfig.TabIndex = 0
        Me.GrupoConfig.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.TelnetDeluxe.My.Resources.Resources.Gui_Firefox
        Me.PictureBox2.Location = New System.Drawing.Point(183, 11)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'label_info_ipant
        '
        Me.label_info_ipant.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_info_ipant.AutoSize = True
        Me.label_info_ipant.Location = New System.Drawing.Point(463, 19)
        Me.label_info_ipant.Name = "label_info_ipant"
        Me.label_info_ipant.Size = New System.Drawing.Size(62, 13)
        Me.label_info_ipant.TabIndex = 8
        Me.label_info_ipant.Text = "IP Anterior: "
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.TelnetDeluxe.My.Resources.Resources.Gui_Router
        Me.PictureBox1.Location = New System.Drawing.Point(323, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'txtbox_info_ipact
        '
        Me.txtbox_info_ipact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbox_info_ipact.BackColor = System.Drawing.Color.OliveDrab
        Me.txtbox_info_ipact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_info_ipact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_info_ipact.ForeColor = System.Drawing.Color.White
        Me.txtbox_info_ipact.Location = New System.Drawing.Point(71, 19)
        Me.txtbox_info_ipact.Name = "txtbox_info_ipact"
        Me.txtbox_info_ipact.ReadOnly = True
        Me.txtbox_info_ipact.Size = New System.Drawing.Size(106, 13)
        Me.txtbox_info_ipact.TabIndex = 3
        Me.txtbox_info_ipact.TabStop = False
        Me.txtbox_info_ipact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_inetconex
        '
        Me.label_inetconex.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_inetconex.BackColor = System.Drawing.Color.Red
        Me.label_inetconex.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_inetconex.ForeColor = System.Drawing.Color.Transparent
        Me.label_inetconex.Location = New System.Drawing.Point(215, 19)
        Me.label_inetconex.Name = "label_inetconex"
        Me.label_inetconex.Size = New System.Drawing.Size(102, 13)
        Me.label_inetconex.TabIndex = 13
        Me.label_inetconex.Text = "Sin Conexión"
        Me.label_inetconex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_info_ipact
        '
        Me.label_info_ipact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_info_ipact.AutoSize = True
        Me.label_info_ipact.Location = New System.Drawing.Point(9, 19)
        Me.label_info_ipact.Name = "label_info_ipact"
        Me.label_info_ipact.Size = New System.Drawing.Size(56, 13)
        Me.label_info_ipact.TabIndex = 6
        Me.label_info_ipact.Text = "IP Actual: "
        '
        'txtbox_info_ipant
        '
        Me.txtbox_info_ipant.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtbox_info_ipant.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.txtbox_info_ipant.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_info_ipant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_info_ipant.ForeColor = System.Drawing.Color.Silver
        Me.txtbox_info_ipant.Location = New System.Drawing.Point(531, 19)
        Me.txtbox_info_ipant.Name = "txtbox_info_ipant"
        Me.txtbox_info_ipant.ReadOnly = True
        Me.txtbox_info_ipant.Size = New System.Drawing.Size(106, 13)
        Me.txtbox_info_ipant.TabIndex = 4
        Me.txtbox_info_ipant.TabStop = False
        Me.txtbox_info_ipant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_estado
        '
        Me.label_estado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label_estado.BackColor = System.Drawing.Color.Red
        Me.label_estado.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_estado.ForeColor = System.Drawing.Color.Transparent
        Me.label_estado.Location = New System.Drawing.Point(355, 20)
        Me.label_estado.Name = "label_estado"
        Me.label_estado.Size = New System.Drawing.Size(102, 13)
        Me.label_estado.TabIndex = 0
        Me.label_estado.Text = "Desconectado"
        Me.label_estado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'crono_principal
        '
        Me.crono_principal.Interval = 1500
        '
        'GrupoConsola
        '
        Me.GrupoConsola.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrupoConsola.BackColor = System.Drawing.Color.Transparent
        Me.GrupoConsola.Controls.Add(Me.Consola)
        Me.GrupoConsola.Location = New System.Drawing.Point(12, 82)
        Me.GrupoConsola.Name = "GrupoConsola"
        Me.GrupoConsola.Size = New System.Drawing.Size(656, 345)
        Me.GrupoConsola.TabIndex = 4
        Me.GrupoConsola.TabStop = False
        Me.GrupoConsola.Text = "Consola"
        '
        'Consola
        '
        Me.Consola.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Consola.AutoWordSelection = True
        Me.Consola.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Consola.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Consola.ContextMenuStrip = Me.MenuConsola
        Me.Consola.DetectUrls = False
        Me.Consola.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Consola.ForeColor = System.Drawing.Color.DarkOrange
        Me.Consola.Location = New System.Drawing.Point(6, 19)
        Me.Consola.Name = "Consola"
        Me.Consola.ReadOnly = True
        Me.Consola.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.Consola.ShowSelectionMargin = True
        Me.Consola.Size = New System.Drawing.Size(644, 320)
        Me.Consola.TabIndex = 2
        Me.Consola.Text = ""
        '
        'MenuConsola
        '
        Me.MenuConsola.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuConsola_Copiar, Me.MenuConsola_SelTodo, Me.ToolStripMenuItem3, Me.MenuConsola_Limpiar})
        Me.MenuConsola.Name = "MenuConsola"
        Me.MenuConsola.Size = New System.Drawing.Size(156, 76)
        '
        'MenuConsola_Copiar
        '
        Me.MenuConsola_Copiar.Name = "MenuConsola_Copiar"
        Me.MenuConsola_Copiar.Size = New System.Drawing.Size(155, 22)
        Me.MenuConsola_Copiar.Text = "&Copiar"
        '
        'MenuConsola_SelTodo
        '
        Me.MenuConsola_SelTodo.Name = "MenuConsola_SelTodo"
        Me.MenuConsola_SelTodo.Size = New System.Drawing.Size(155, 22)
        Me.MenuConsola_SelTodo.Text = "Seleccionar &Todo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(152, 6)
        '
        'MenuConsola_Limpiar
        '
        Me.MenuConsola_Limpiar.Name = "MenuConsola_Limpiar"
        Me.MenuConsola_Limpiar.Size = New System.Drawing.Size(155, 22)
        Me.MenuConsola_Limpiar.Text = "&Limpiar Consola"
        '
        'TD_Tray
        '
        Me.TD_Tray.ContextMenuStrip = Me.MenuTray
        Me.TD_Tray.Icon = CType(resources.GetObject("TD_Tray.Icon"), System.Drawing.Icon)
        Me.TD_Tray.Text = "Telnet Deluxe"
        Me.TD_Tray.Visible = True
        '
        'MenuTray
        '
        Me.MenuTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenovarIPToolStripMenuItem, Me.RestaurarToolStripMenuItem, Me.ToolStripMenuItem2, Me.SalirToolStripMenuItem})
        Me.MenuTray.Name = "MenuTray"
        Me.MenuTray.Size = New System.Drawing.Size(129, 76)
        '
        'RenovarIPToolStripMenuItem
        '
        Me.RenovarIPToolStripMenuItem.Name = "RenovarIPToolStripMenuItem"
        Me.RenovarIPToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RenovarIPToolStripMenuItem.Text = "&Renovar IP"
        '
        'RestaurarToolStripMenuItem
        '
        Me.RestaurarToolStripMenuItem.Name = "RestaurarToolStripMenuItem"
        Me.RestaurarToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.RestaurarToolStripMenuItem.Text = "Restaurar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(125, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'TD_ToolTip
        '
        Me.TD_ToolTip.IsBalloon = True
        '
        'Timer_ConexInet
        '
        Me.Timer_ConexInet.Interval = 2000
        '
        'TDBarraEstado
        '
        Me.TDBarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TDBE_labelinfo, Me.TDBE_Progreso, Me.TDLB_Progreso})
        Me.TDBarraEstado.Location = New System.Drawing.Point(0, 435)
        Me.TDBarraEstado.Name = "TDBarraEstado"
        Me.TDBarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TDBarraEstado.Size = New System.Drawing.Size(683, 22)
        Me.TDBarraEstado.SizingGrip = False
        Me.TDBarraEstado.TabIndex = 5
        Me.TDBarraEstado.Text = "Barra de Estado"
        '
        'TDBE_labelinfo
        '
        Me.TDBE_labelinfo.AutoSize = False
        Me.TDBE_labelinfo.ForeColor = System.Drawing.Color.Black
        Me.TDBE_labelinfo.Name = "TDBE_labelinfo"
        Me.TDBE_labelinfo.Size = New System.Drawing.Size(250, 17)
        Me.TDBE_labelinfo.Text = "Telnet Deluxe cargado con éxito"
        '
        'TDBE_Progreso
        '
        Me.TDBE_Progreso.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TDBE_Progreso.ForeColor = System.Drawing.Color.Orange
        Me.TDBE_Progreso.Name = "TDBE_Progreso"
        Me.TDBE_Progreso.Size = New System.Drawing.Size(150, 16)
        Me.TDBE_Progreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'TDLB_Progreso
        '
        Me.TDLB_Progreso.AutoSize = False
        Me.TDLB_Progreso.ForeColor = System.Drawing.Color.Black
        Me.TDLB_Progreso.Name = "TDLB_Progreso"
        Me.TDLB_Progreso.Size = New System.Drawing.Size(36, 17)
        Me.TDLB_Progreso.Text = "100%"
        '
        'Currante_ConseguirIP
        '
        '
        'TD_MenuPrincipal
        '
        Me.TD_MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TD_MP_Funciones, Me.TD_MP_Opciones, Me.TD_MP_Herramientas, Me.TD_MP_AcercaDe})
        Me.TD_MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TD_MenuPrincipal.Name = "TD_MenuPrincipal"
        Me.TD_MenuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TD_MenuPrincipal.Size = New System.Drawing.Size(683, 24)
        Me.TD_MenuPrincipal.TabIndex = 0
        Me.TD_MenuPrincipal.Text = "MenuPrincipal"
        '
        'TD_MP_Funciones
        '
        Me.TD_MP_Funciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TD_MP_EjecutarComandos, Me.ToolStripMenuItem1, Me.MToolStripMenuItem, Me.TD_MP_Salir})
        Me.TD_MP_Funciones.Name = "TD_MP_Funciones"
        Me.TD_MP_Funciones.Size = New System.Drawing.Size(67, 20)
        Me.TD_MP_Funciones.Text = "&Funciones"
        '
        'TD_MP_EjecutarComandos
        '
        Me.TD_MP_EjecutarComandos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_EjecutarComandos.Name = "TD_MP_EjecutarComandos"
        Me.TD_MP_EjecutarComandos.Size = New System.Drawing.Size(225, 22)
        Me.TD_MP_EjecutarComandos.Text = "Ejecutar Comandos"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(222, 6)
        '
        'MToolStripMenuItem
        '
        Me.MToolStripMenuItem.Name = "MToolStripMenuItem"
        Me.MToolStripMenuItem.Size = New System.Drawing.Size(225, 22)
        Me.MToolStripMenuItem.Text = "Minimizar al área de notificación"
        '
        'TD_MP_Salir
        '
        Me.TD_MP_Salir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_Salir.Name = "TD_MP_Salir"
        Me.TD_MP_Salir.Size = New System.Drawing.Size(225, 22)
        Me.TD_MP_Salir.Text = "&Salir"
        '
        'TD_MP_Opciones
        '
        Me.TD_MP_Opciones.Name = "TD_MP_Opciones"
        Me.TD_MP_Opciones.Size = New System.Drawing.Size(63, 20)
        Me.TD_MP_Opciones.Text = "&Opciones"
        '
        'TD_MP_Herramientas
        '
        Me.TD_MP_Herramientas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TD_MP_MostrarInfoSistema, Me.TD_MP_MostrarInfoRed, Me.TD_MP_ConseguirIP})
        Me.TD_MP_Herramientas.Name = "TD_MP_Herramientas"
        Me.TD_MP_Herramientas.Size = New System.Drawing.Size(83, 20)
        Me.TD_MP_Herramientas.Text = "&Herramientas"
        '
        'TD_MP_MostrarInfoSistema
        '
        Me.TD_MP_MostrarInfoSistema.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_MostrarInfoSistema.Name = "TD_MP_MostrarInfoSistema"
        Me.TD_MP_MostrarInfoSistema.Size = New System.Drawing.Size(228, 22)
        Me.TD_MP_MostrarInfoSistema.Text = "Mostrar Información del Sistema"
        '
        'TD_MP_MostrarInfoRed
        '
        Me.TD_MP_MostrarInfoRed.Name = "TD_MP_MostrarInfoRed"
        Me.TD_MP_MostrarInfoRed.Size = New System.Drawing.Size(228, 22)
        Me.TD_MP_MostrarInfoRed.Text = "Mostrar Información de Red"
        '
        'TD_MP_ConseguirIP
        '
        Me.TD_MP_ConseguirIP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_ConseguirIP.Name = "TD_MP_ConseguirIP"
        Me.TD_MP_ConseguirIP.Size = New System.Drawing.Size(228, 22)
        Me.TD_MP_ConseguirIP.Text = "Conseguir IP"
        '
        'TD_MP_AcercaDe
        '
        Me.TD_MP_AcercaDe.Name = "TD_MP_AcercaDe"
        Me.TD_MP_AcercaDe.Size = New System.Drawing.Size(68, 20)
        Me.TD_MP_AcercaDe.Text = "Acerca &De"
        '
        'Currante_Winsock
        '
        Me.Currante_Winsock.WorkerReportsProgress = True
        '
        'TelnetDeluxe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(683, 457)
        Me.Controls.Add(Me.TDBarraEstado)
        Me.Controls.Add(Me.TD_MenuPrincipal)
        Me.Controls.Add(Me.GrupoConfig)
        Me.Controls.Add(Me.GrupoConsola)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.TD_MenuPrincipal
        Me.MaximizeBox = False
        Me.Name = "TelnetDeluxe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Telnet Deluxe"
        Me.GrupoConfig.ResumeLayout(False)
        Me.GrupoConfig.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrupoConsola.ResumeLayout(False)
        Me.MenuConsola.ResumeLayout(False)
        Me.MenuTray.ResumeLayout(False)
        Me.TDBarraEstado.ResumeLayout(False)
        Me.TDBarraEstado.PerformLayout()
        Me.TD_MenuPrincipal.ResumeLayout(False)
        Me.TD_MenuPrincipal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrupoConfig As System.Windows.Forms.GroupBox
    Friend WithEvents crono_principal As System.Windows.Forms.Timer
    Friend WithEvents GrupoConsola As System.Windows.Forms.GroupBox
    Friend WithEvents Consola As System.Windows.Forms.RichTextBox
    Friend WithEvents label_info_ipact As System.Windows.Forms.Label
    Friend WithEvents txtbox_info_ipant As System.Windows.Forms.TextBox
    Friend WithEvents label_info_ipant As System.Windows.Forms.Label
    Friend WithEvents txtbox_info_ipact As System.Windows.Forms.TextBox
    Friend WithEvents TD_Tray As System.Windows.Forms.NotifyIcon
    Friend WithEvents MenuTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RenovarIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestaurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Timer_ConexInet As System.Windows.Forms.Timer
    Friend WithEvents label_inetconex As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TDBarraEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents label_estado As System.Windows.Forms.Label
    Friend WithEvents TDBE_labelinfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TDBE_Progreso As System.Windows.Forms.ToolStripProgressBar
    Public WithEvents Currante_Ping As System.ComponentModel.BackgroundWorker
    Friend WithEvents Currante_ConseguirIP As System.ComponentModel.BackgroundWorker
    Friend WithEvents TDLB_Progreso As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TD_MenuPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents TD_MP_Funciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_EjecutarComandos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TD_MP_Salir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_Opciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_Herramientas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_MostrarInfoSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_ConseguirIP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_AcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_MostrarInfoRed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConsola As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuConsola_Copiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuConsola_SelTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuConsola_Limpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Currante_Winsock As System.ComponentModel.BackgroundWorker

End Class
