<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TD_Principal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TD_Principal))
        Me.Consola = New System.Windows.Forms.RichTextBox
        Me.MenuConsola = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuConsola_Copiar = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuConsola_SelTodo = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuConsola_Separador = New System.Windows.Forms.ToolStripSeparator
        Me.MenuConsola_Limpiar = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenovarIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestaurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TDBarraEstado = New System.Windows.Forms.StatusStrip
        Me.TDBE_labelinfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.TDBE_Progreso = New System.Windows.Forms.ToolStripProgressBar
        Me.TDLB_Progreso = New System.Windows.Forms.ToolStripStatusLabel
        Me.TD_MenuPrincipal = New System.Windows.Forms.MenuStrip
        Me.TD_MP_Funciones = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_EjecutarComandos = New System.Windows.Forms.ToolStripMenuItem
        Me.MToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_Salir = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_Opciones = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_Herramientas = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_MostrarInfoSistema = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_MostrarInfoRed = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_ConseguirIP = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_MP_AcercaDe = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.label_estado = New System.Windows.Forms.Label
        Me.txtbox_info_ipant = New System.Windows.Forms.TextBox
        Me.label_inetconex = New System.Windows.Forms.Label
        Me.txtbox_info_ipact = New System.Windows.Forms.TextBox
        Me.EComandos = New System.Windows.Forms.Button
        Me.lbl_consola = New System.Windows.Forms.Label
        Me.MenuConsola.SuspendLayout()
        Me.MenuTray.SuspendLayout()
        Me.TDBarraEstado.SuspendLayout()
        Me.TD_MenuPrincipal.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Consola
        '
        Me.Consola.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Consola.AutoWordSelection = True
        Me.Consola.BackColor = System.Drawing.Color.Black
        Me.Consola.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Consola.ContextMenuStrip = Me.MenuConsola
        Me.Consola.DetectUrls = False
        Me.Consola.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Consola.ForeColor = System.Drawing.Color.DarkOrange
        Me.Consola.Location = New System.Drawing.Point(10, 108)
        Me.Consola.Margin = New System.Windows.Forms.Padding(4)
        Me.Consola.Name = "Consola"
        Me.Consola.ReadOnly = True
        Me.Consola.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.Consola.ShowSelectionMargin = True
        Me.Consola.Size = New System.Drawing.Size(663, 348)
        Me.Consola.TabIndex = 2
        Me.Consola.Text = ""
        '
        'MenuConsola
        '
        Me.MenuConsola.BackColor = System.Drawing.Color.Black
        Me.MenuConsola.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.MenuConsola.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuConsola_Copiar, Me.MenuConsola_SelTodo, Me.MenuConsola_Separador, Me.MenuConsola_Limpiar})
        Me.MenuConsola.Name = "MenuConsola"
        Me.MenuConsola.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuConsola.ShowImageMargin = False
        Me.MenuConsola.Size = New System.Drawing.Size(131, 76)
        '
        'MenuConsola_Copiar
        '
        Me.MenuConsola_Copiar.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.MenuConsola_Copiar.ForeColor = System.Drawing.Color.GreenYellow
        Me.MenuConsola_Copiar.Name = "MenuConsola_Copiar"
        Me.MenuConsola_Copiar.Size = New System.Drawing.Size(130, 22)
        Me.MenuConsola_Copiar.Text = "&Copiar"
        '
        'MenuConsola_SelTodo
        '
        Me.MenuConsola_SelTodo.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.MenuConsola_SelTodo.ForeColor = System.Drawing.Color.GreenYellow
        Me.MenuConsola_SelTodo.Name = "MenuConsola_SelTodo"
        Me.MenuConsola_SelTodo.Size = New System.Drawing.Size(130, 22)
        Me.MenuConsola_SelTodo.Text = "Seleccionar &Todo"
        '
        'MenuConsola_Separador
        '
        Me.MenuConsola_Separador.ForeColor = System.Drawing.Color.YellowGreen
        Me.MenuConsola_Separador.Name = "MenuConsola_Separador"
        Me.MenuConsola_Separador.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always
        Me.MenuConsola_Separador.Size = New System.Drawing.Size(127, 6)
        '
        'MenuConsola_Limpiar
        '
        Me.MenuConsola_Limpiar.ForeColor = System.Drawing.Color.GreenYellow
        Me.MenuConsola_Limpiar.Name = "MenuConsola_Limpiar"
        Me.MenuConsola_Limpiar.Size = New System.Drawing.Size(130, 22)
        Me.MenuConsola_Limpiar.Text = "&Limpiar Consola"
        '
        'TD_Tray
        '
        Me.TD_Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TD_Tray.BalloonTipText = "Pulsa el botón derecho para ver el menú"
        Me.TD_Tray.BalloonTipTitle = "Telnet Deluxe"
        Me.TD_Tray.ContextMenuStrip = Me.MenuTray
        Me.TD_Tray.Icon = CType(resources.GetObject("TD_Tray.Icon"), System.Drawing.Icon)
        Me.TD_Tray.Text = "Telnet Deluxe"
        '
        'MenuTray
        '
        Me.MenuTray.BackColor = System.Drawing.Color.Black
        Me.MenuTray.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.MenuTray.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenovarIPToolStripMenuItem, Me.RestaurarToolStripMenuItem, Me.ToolStripMenuItem2, Me.SalirToolStripMenuItem})
        Me.MenuTray.Name = "MenuTray"
        Me.MenuTray.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuTray.ShowImageMargin = False
        Me.MenuTray.Size = New System.Drawing.Size(128, 98)
        '
        'RenovarIPToolStripMenuItem
        '
        Me.RenovarIPToolStripMenuItem.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.RenovarIPToolStripMenuItem.ForeColor = System.Drawing.Color.GreenYellow
        Me.RenovarIPToolStripMenuItem.Name = "RenovarIPToolStripMenuItem"
        Me.RenovarIPToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.RenovarIPToolStripMenuItem.Text = "&Renovar IP"
        '
        'RestaurarToolStripMenuItem
        '
        Me.RestaurarToolStripMenuItem.ForeColor = System.Drawing.Color.GreenYellow
        Me.RestaurarToolStripMenuItem.Name = "RestaurarToolStripMenuItem"
        Me.RestaurarToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.RestaurarToolStripMenuItem.Text = "Restaurar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(124, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.ForeColor = System.Drawing.Color.GreenYellow
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'TDBarraEstado
        '
        Me.TDBarraEstado.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TDBarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TDBE_labelinfo, Me.TDBE_Progreso, Me.TDLB_Progreso})
        Me.TDBarraEstado.Location = New System.Drawing.Point(0, 460)
        Me.TDBarraEstado.Name = "TDBarraEstado"
        Me.TDBarraEstado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TDBarraEstado.Size = New System.Drawing.Size(679, 22)
        Me.TDBarraEstado.SizingGrip = False
        Me.TDBarraEstado.TabIndex = 5
        Me.TDBarraEstado.Text = "Barra de Estado"
        '
        'TDBE_labelinfo
        '
        Me.TDBE_labelinfo.AutoSize = False
        Me.TDBE_labelinfo.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TDBE_labelinfo.ForeColor = System.Drawing.Color.GreenYellow
        Me.TDBE_labelinfo.Name = "TDBE_labelinfo"
        Me.TDBE_labelinfo.Size = New System.Drawing.Size(250, 17)
        Me.TDBE_labelinfo.Text = "Telnet Deluxe cargado con éxito"
        '
        'TDBE_Progreso
        '
        Me.TDBE_Progreso.BackColor = System.Drawing.Color.Black
        Me.TDBE_Progreso.ForeColor = System.Drawing.Color.GreenYellow
        Me.TDBE_Progreso.Name = "TDBE_Progreso"
        Me.TDBE_Progreso.Size = New System.Drawing.Size(150, 16)
        Me.TDBE_Progreso.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'TDLB_Progreso
        '
        Me.TDLB_Progreso.AutoSize = False
        Me.TDLB_Progreso.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TDLB_Progreso.ForeColor = System.Drawing.Color.GreenYellow
        Me.TDLB_Progreso.Name = "TDLB_Progreso"
        Me.TDLB_Progreso.Size = New System.Drawing.Size(36, 17)
        Me.TDLB_Progreso.Text = "100%"
        '
        'TD_MenuPrincipal
        '
        Me.TD_MenuPrincipal.BackColor = System.Drawing.Color.Black
        Me.TD_MenuPrincipal.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TD_MP_Funciones, Me.TD_MP_Opciones, Me.TD_MP_Herramientas, Me.TD_MP_AcercaDe})
        Me.TD_MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TD_MenuPrincipal.Name = "TD_MenuPrincipal"
        Me.TD_MenuPrincipal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TD_MenuPrincipal.Size = New System.Drawing.Size(679, 24)
        Me.TD_MenuPrincipal.TabIndex = 0
        Me.TD_MenuPrincipal.Text = "MenuPrincipal"
        '
        'TD_MP_Funciones
        '
        Me.TD_MP_Funciones.BackColor = System.Drawing.Color.Black
        Me.TD_MP_Funciones.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_Funciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TD_MP_EjecutarComandos, Me.MToolStripMenuItem, Me.TD_MP_Salir})
        Me.TD_MP_Funciones.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_Funciones.Name = "TD_MP_Funciones"
        Me.TD_MP_Funciones.Size = New System.Drawing.Size(67, 20)
        Me.TD_MP_Funciones.Text = "&Funciones"
        '
        'TD_MP_EjecutarComandos
        '
        Me.TD_MP_EjecutarComandos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_EjecutarComandos.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_EjecutarComandos.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_EjecutarComandos.Name = "TD_MP_EjecutarComandos"
        Me.TD_MP_EjecutarComandos.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.TD_MP_EjecutarComandos.Size = New System.Drawing.Size(265, 22)
        Me.TD_MP_EjecutarComandos.Text = "Ejecutar Comandos"
        '
        'MToolStripMenuItem
        '
        Me.MToolStripMenuItem.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.MToolStripMenuItem.ForeColor = System.Drawing.Color.GreenYellow
        Me.MToolStripMenuItem.Name = "MToolStripMenuItem"
        Me.MToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.MToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.MToolStripMenuItem.Text = "Minimizar al área de notificación"
        '
        'TD_MP_Salir
        '
        Me.TD_MP_Salir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_Salir.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_Salir.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_Salir.Name = "TD_MP_Salir"
        Me.TD_MP_Salir.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q), System.Windows.Forms.Keys)
        Me.TD_MP_Salir.Size = New System.Drawing.Size(265, 22)
        Me.TD_MP_Salir.Text = "&Salir"
        '
        'TD_MP_Opciones
        '
        Me.TD_MP_Opciones.BackColor = System.Drawing.Color.Black
        Me.TD_MP_Opciones.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_Opciones.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_Opciones.Name = "TD_MP_Opciones"
        Me.TD_MP_Opciones.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.TD_MP_Opciones.Size = New System.Drawing.Size(63, 20)
        Me.TD_MP_Opciones.Text = "&Opciones"
        '
        'TD_MP_Herramientas
        '
        Me.TD_MP_Herramientas.BackColor = System.Drawing.Color.Black
        Me.TD_MP_Herramientas.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_Herramientas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TD_MP_MostrarInfoSistema, Me.TD_MP_MostrarInfoRed, Me.TD_MP_ConseguirIP})
        Me.TD_MP_Herramientas.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_Herramientas.Name = "TD_MP_Herramientas"
        Me.TD_MP_Herramientas.Size = New System.Drawing.Size(83, 20)
        Me.TD_MP_Herramientas.Text = "&Herramientas"
        '
        'TD_MP_MostrarInfoSistema
        '
        Me.TD_MP_MostrarInfoSistema.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_MostrarInfoSistema.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_MostrarInfoSistema.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_MostrarInfoSistema.Name = "TD_MP_MostrarInfoSistema"
        Me.TD_MP_MostrarInfoSistema.Size = New System.Drawing.Size(228, 22)
        Me.TD_MP_MostrarInfoSistema.Text = "Mostrar Información del Sistema"
        '
        'TD_MP_MostrarInfoRed
        '
        Me.TD_MP_MostrarInfoRed.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_MostrarInfoRed.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_MostrarInfoRed.Name = "TD_MP_MostrarInfoRed"
        Me.TD_MP_MostrarInfoRed.Size = New System.Drawing.Size(228, 22)
        Me.TD_MP_MostrarInfoRed.Text = "Mostrar Información de Red"
        '
        'TD_MP_ConseguirIP
        '
        Me.TD_MP_ConseguirIP.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.TD_MP_ConseguirIP.BackgroundImage = Global.TelnetDeluxe.My.Resources.Resources.FondoGeneral
        Me.TD_MP_ConseguirIP.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_ConseguirIP.Name = "TD_MP_ConseguirIP"
        Me.TD_MP_ConseguirIP.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.TD_MP_ConseguirIP.Size = New System.Drawing.Size(228, 22)
        Me.TD_MP_ConseguirIP.Text = "Conseguir IP"
        '
        'TD_MP_AcercaDe
        '
        Me.TD_MP_AcercaDe.BackColor = System.Drawing.Color.Black
        Me.TD_MP_AcercaDe.ForeColor = System.Drawing.Color.GreenYellow
        Me.TD_MP_AcercaDe.Name = "TD_MP_AcercaDe"
        Me.TD_MP_AcercaDe.Size = New System.Drawing.Size(68, 20)
        Me.TD_MP_AcercaDe.Text = "Acerca &De"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(10, 32)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(663, 54)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'label_estado
        '
        Me.label_estado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.label_estado.BackColor = System.Drawing.Color.Red
        Me.label_estado.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_estado.ForeColor = System.Drawing.Color.Transparent
        Me.label_estado.Location = New System.Drawing.Point(560, 64)
        Me.label_estado.Name = "label_estado"
        Me.label_estado.Size = New System.Drawing.Size(106, 13)
        Me.label_estado.TabIndex = 6
        Me.label_estado.Text = "Desconectado"
        Me.label_estado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbox_info_ipant
        '
        Me.txtbox_info_ipant.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtbox_info_ipant.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.txtbox_info_ipant.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_info_ipant.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtbox_info_ipant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_info_ipant.ForeColor = System.Drawing.Color.Silver
        Me.txtbox_info_ipant.Location = New System.Drawing.Point(560, 46)
        Me.txtbox_info_ipant.Name = "txtbox_info_ipant"
        Me.txtbox_info_ipant.ReadOnly = True
        Me.txtbox_info_ipant.Size = New System.Drawing.Size(106, 13)
        Me.txtbox_info_ipant.TabIndex = 4
        Me.txtbox_info_ipant.TabStop = False
        Me.txtbox_info_ipant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_inetconex
        '
        Me.label_inetconex.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.label_inetconex.BackColor = System.Drawing.Color.Red
        Me.label_inetconex.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_inetconex.ForeColor = System.Drawing.Color.Transparent
        Me.label_inetconex.Location = New System.Drawing.Point(22, 64)
        Me.label_inetconex.Name = "label_inetconex"
        Me.label_inetconex.Size = New System.Drawing.Size(106, 13)
        Me.label_inetconex.TabIndex = 5
        Me.label_inetconex.Text = "Sin Conexión"
        Me.label_inetconex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtbox_info_ipact
        '
        Me.txtbox_info_ipact.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtbox_info_ipact.BackColor = System.Drawing.Color.OliveDrab
        Me.txtbox_info_ipact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_info_ipact.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtbox_info_ipact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_info_ipact.ForeColor = System.Drawing.Color.White
        Me.txtbox_info_ipact.Location = New System.Drawing.Point(22, 46)
        Me.txtbox_info_ipact.Name = "txtbox_info_ipact"
        Me.txtbox_info_ipact.ReadOnly = True
        Me.txtbox_info_ipact.Size = New System.Drawing.Size(106, 13)
        Me.txtbox_info_ipact.TabIndex = 3
        Me.txtbox_info_ipact.TabStop = False
        Me.txtbox_info_ipact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'EComandos
        '
        Me.EComandos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.EComandos.BackColor = System.Drawing.Color.Transparent
        Me.EComandos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.EComandos.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.EComandos.FlatAppearance.BorderSize = 0
        Me.EComandos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.EComandos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.EComandos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EComandos.ForeColor = System.Drawing.Color.GreenYellow
        Me.EComandos.Image = Global.TelnetDeluxe.My.Resources.Resources.BotonTelnetON
        Me.EComandos.Location = New System.Drawing.Point(207, 32)
        Me.EComandos.Name = "EComandos"
        Me.EComandos.Size = New System.Drawing.Size(270, 53)
        Me.EComandos.TabIndex = 1
        Me.EComandos.UseVisualStyleBackColor = False
        '
        'lbl_consola
        '
        Me.lbl_consola.AutoSize = True
        Me.lbl_consola.BackColor = System.Drawing.Color.Transparent
        Me.lbl_consola.ForeColor = System.Drawing.Color.GreenYellow
        Me.lbl_consola.Location = New System.Drawing.Point(7, 91)
        Me.lbl_consola.Name = "lbl_consola"
        Me.lbl_consola.Size = New System.Drawing.Size(48, 13)
        Me.lbl_consola.TabIndex = 19
        Me.lbl_consola.Text = "Consola:"
        '
        'TD_Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(679, 482)
        Me.Controls.Add(Me.lbl_consola)
        Me.Controls.Add(Me.Consola)
        Me.Controls.Add(Me.EComandos)
        Me.Controls.Add(Me.txtbox_info_ipact)
        Me.Controls.Add(Me.label_inetconex)
        Me.Controls.Add(Me.txtbox_info_ipant)
        Me.Controls.Add(Me.label_estado)
        Me.Controls.Add(Me.TDBarraEstado)
        Me.Controls.Add(Me.TD_MenuPrincipal)
        Me.Controls.Add(Me.PictureBox1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.TD_MenuPrincipal
        Me.MaximizeBox = False
        Me.Name = "TD_Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Telnet Deluxe"
        Me.MenuConsola.ResumeLayout(False)
        Me.MenuTray.ResumeLayout(False)
        Me.TDBarraEstado.ResumeLayout(False)
        Me.TDBarraEstado.PerformLayout()
        Me.TD_MenuPrincipal.ResumeLayout(False)
        Me.TD_MenuPrincipal.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Consola As System.Windows.Forms.RichTextBox
    Friend WithEvents TD_Tray As System.Windows.Forms.NotifyIcon
    Friend WithEvents MenuTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RenovarIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestaurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TDBarraEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents TDBE_labelinfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TDBE_Progreso As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents TDLB_Progreso As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TD_MenuPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents TD_MP_Funciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_MP_EjecutarComandos As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents MenuConsola_Separador As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuConsola_Limpiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents label_estado As System.Windows.Forms.Label
    Friend WithEvents txtbox_info_ipant As System.Windows.Forms.TextBox
    Friend WithEvents label_inetconex As System.Windows.Forms.Label
    Friend WithEvents txtbox_info_ipact As System.Windows.Forms.TextBox
    Friend WithEvents EComandos As System.Windows.Forms.Button
    Friend WithEvents lbl_consola As System.Windows.Forms.Label

End Class
