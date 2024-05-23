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
        Me.GrupoConfig = New System.Windows.Forms.GroupBox
        Me.label_inetconex = New System.Windows.Forms.Label
        Me.boton_cargarini = New System.Windows.Forms.Button
        Me.txtbox_conf_refresco = New System.Windows.Forms.TextBox
        Me.Combo_inirouters = New System.Windows.Forms.ComboBox
        Me.label_conf_inirouter = New System.Windows.Forms.Label
        Me.label_conf_refresco = New System.Windows.Forms.Label
        Me.label_estado = New System.Windows.Forms.Label
        Me.boton_actualizar = New System.Windows.Forms.Button
        Me.txtbox_conf_puerto = New System.Windows.Forms.TextBox
        Me.label_conf_puerto = New System.Windows.Forms.Label
        Me.txtbox_conf_iprouter = New System.Windows.Forms.TextBox
        Me.label_conf_iprouter = New System.Windows.Forms.Label
        Me.crono_principal = New System.Windows.Forms.Timer(Me.components)
        Me.GrupoConsola = New System.Windows.Forms.GroupBox
        Me.Consola = New System.Windows.Forms.RichTextBox
        Me.label_info_ipact = New System.Windows.Forms.Label
        Me.txtbox_info_ipact = New System.Windows.Forms.TextBox
        Me.txtbox_info_ipant = New System.Windows.Forms.TextBox
        Me.label_info_ipant = New System.Windows.Forms.Label
        Me.GrupoOtros = New System.Windows.Forms.GroupBox
        Me.boton_ocultar = New System.Windows.Forms.Button
        Me.boton_Acercade = New System.Windows.Forms.Button
        Me.TD_Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MenuTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RenovarIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestaurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TD_ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer_ConexInet = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.GrupoConfig.SuspendLayout()
        Me.GrupoConsola.SuspendLayout()
        Me.GrupoOtros.SuspendLayout()
        Me.MenuTray.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrupoConfig
        '
        Me.GrupoConfig.Controls.Add(Me.PictureBox2)
        Me.GrupoConfig.Controls.Add(Me.PictureBox1)
        Me.GrupoConfig.Controls.Add(Me.label_inetconex)
        Me.GrupoConfig.Controls.Add(Me.boton_cargarini)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_refresco)
        Me.GrupoConfig.Controls.Add(Me.Combo_inirouters)
        Me.GrupoConfig.Controls.Add(Me.label_conf_inirouter)
        Me.GrupoConfig.Controls.Add(Me.label_conf_refresco)
        Me.GrupoConfig.Controls.Add(Me.label_estado)
        Me.GrupoConfig.Controls.Add(Me.boton_actualizar)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_puerto)
        Me.GrupoConfig.Controls.Add(Me.label_conf_puerto)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_iprouter)
        Me.GrupoConfig.Controls.Add(Me.label_conf_iprouter)
        Me.GrupoConfig.Location = New System.Drawing.Point(3, 9)
        Me.GrupoConfig.Name = "GrupoConfig"
        Me.GrupoConfig.Size = New System.Drawing.Size(656, 77)
        Me.GrupoConfig.TabIndex = 0
        Me.GrupoConfig.TabStop = False
        Me.GrupoConfig.Text = "General"
        '
        'label_inetconex
        '
        Me.label_inetconex.BackColor = System.Drawing.Color.Red
        Me.label_inetconex.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_inetconex.ForeColor = System.Drawing.Color.Transparent
        Me.label_inetconex.Location = New System.Drawing.Point(548, 42)
        Me.label_inetconex.Name = "label_inetconex"
        Me.label_inetconex.Size = New System.Drawing.Size(102, 23)
        Me.label_inetconex.TabIndex = 13
        Me.label_inetconex.Text = "Sin Conexión"
        Me.label_inetconex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'boton_cargarini
        '
        Me.boton_cargarini.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.boton_cargarini.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.boton_cargarini.Location = New System.Drawing.Point(253, 14)
        Me.boton_cargarini.Name = "boton_cargarini"
        Me.boton_cargarini.Size = New System.Drawing.Size(78, 23)
        Me.boton_cargarini.TabIndex = 2
        Me.boton_cargarini.Text = "&Cargar INI"
        Me.boton_cargarini.UseVisualStyleBackColor = True
        '
        'txtbox_conf_refresco
        '
        Me.txtbox_conf_refresco.BackColor = System.Drawing.Color.White
        Me.txtbox_conf_refresco.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_refresco.Location = New System.Drawing.Point(440, 46)
        Me.txtbox_conf_refresco.Name = "txtbox_conf_refresco"
        Me.txtbox_conf_refresco.Size = New System.Drawing.Size(29, 13)
        Me.txtbox_conf_refresco.TabIndex = 7
        Me.txtbox_conf_refresco.Text = "3"
        Me.txtbox_conf_refresco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Combo_inirouters
        '
        Me.Combo_inirouters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Combo_inirouters.FormattingEnabled = True
        Me.Combo_inirouters.Location = New System.Drawing.Point(116, 14)
        Me.Combo_inirouters.MaxDropDownItems = 15
        Me.Combo_inirouters.Name = "Combo_inirouters"
        Me.Combo_inirouters.Size = New System.Drawing.Size(131, 21)
        Me.Combo_inirouters.TabIndex = 1
        '
        'label_conf_inirouter
        '
        Me.label_conf_inirouter.AutoSize = True
        Me.label_conf_inirouter.Location = New System.Drawing.Point(9, 19)
        Me.label_conf_inirouter.Name = "label_conf_inirouter"
        Me.label_conf_inirouter.Size = New System.Drawing.Size(101, 13)
        Me.label_conf_inirouter.TabIndex = 6
        Me.label_conf_inirouter.Text = "Seleccionar Router:"
        '
        'label_conf_refresco
        '
        Me.label_conf_refresco.AutoSize = True
        Me.label_conf_refresco.Location = New System.Drawing.Point(357, 46)
        Me.label_conf_refresco.Name = "label_conf_refresco"
        Me.label_conf_refresco.Size = New System.Drawing.Size(77, 13)
        Me.label_conf_refresco.TabIndex = 12
        Me.label_conf_refresco.Text = "Intervalo (seg):"
        '
        'label_estado
        '
        Me.label_estado.BackColor = System.Drawing.Color.Red
        Me.label_estado.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_estado.ForeColor = System.Drawing.Color.Transparent
        Me.label_estado.Location = New System.Drawing.Point(548, 14)
        Me.label_estado.Name = "label_estado"
        Me.label_estado.Size = New System.Drawing.Size(102, 23)
        Me.label_estado.TabIndex = 0
        Me.label_estado.Text = "Desconectado"
        Me.label_estado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'boton_actualizar
        '
        Me.boton_actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.boton_actualizar.Location = New System.Drawing.Point(335, 14)
        Me.boton_actualizar.Name = "boton_actualizar"
        Me.boton_actualizar.Size = New System.Drawing.Size(99, 23)
        Me.boton_actualizar.TabIndex = 3
        Me.boton_actualizar.Text = "&Renovar IP"
        Me.boton_actualizar.UseVisualStyleBackColor = True
        '
        'txtbox_conf_puerto
        '
        Me.txtbox_conf_puerto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_puerto.Location = New System.Drawing.Point(278, 46)
        Me.txtbox_conf_puerto.Name = "txtbox_conf_puerto"
        Me.txtbox_conf_puerto.Size = New System.Drawing.Size(53, 13)
        Me.txtbox_conf_puerto.TabIndex = 6
        Me.txtbox_conf_puerto.Text = "23"
        Me.txtbox_conf_puerto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_puerto
        '
        Me.label_conf_puerto.AutoSize = True
        Me.label_conf_puerto.Location = New System.Drawing.Point(231, 46)
        Me.label_conf_puerto.Name = "label_conf_puerto"
        Me.label_conf_puerto.Size = New System.Drawing.Size(41, 13)
        Me.label_conf_puerto.TabIndex = 2
        Me.label_conf_puerto.Text = "Puerto:"
        '
        'txtbox_conf_iprouter
        '
        Me.txtbox_conf_iprouter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_iprouter.Location = New System.Drawing.Point(135, 46)
        Me.txtbox_conf_iprouter.Name = "txtbox_conf_iprouter"
        Me.txtbox_conf_iprouter.Size = New System.Drawing.Size(78, 13)
        Me.txtbox_conf_iprouter.TabIndex = 5
        Me.txtbox_conf_iprouter.Text = "192.168.1.1"
        Me.txtbox_conf_iprouter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_conf_iprouter
        '
        Me.label_conf_iprouter.AutoSize = True
        Me.label_conf_iprouter.Location = New System.Drawing.Point(9, 46)
        Me.label_conf_iprouter.Name = "label_conf_iprouter"
        Me.label_conf_iprouter.Size = New System.Drawing.Size(120, 13)
        Me.label_conf_iprouter.TabIndex = 0
        Me.label_conf_iprouter.Text = "Dirección IP del Router:"
        '
        'crono_principal
        '
        Me.crono_principal.Interval = 1500
        '
        'GrupoConsola
        '
        Me.GrupoConsola.BackColor = System.Drawing.SystemColors.Control
        Me.GrupoConsola.Controls.Add(Me.Consola)
        Me.GrupoConsola.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GrupoConsola.Location = New System.Drawing.Point(3, 92)
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
        Me.Consola.BackColor = System.Drawing.Color.Black
        Me.Consola.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Consola.DetectUrls = False
        Me.Consola.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Consola.ForeColor = System.Drawing.Color.DarkOrange
        Me.Consola.Location = New System.Drawing.Point(6, 19)
        Me.Consola.Name = "Consola"
        Me.Consola.ReadOnly = True
        Me.Consola.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.Consola.ShowSelectionMargin = True
        Me.Consola.Size = New System.Drawing.Size(644, 320)
        Me.Consola.TabIndex = 9
        Me.Consola.Text = ""
        '
        'label_info_ipact
        '
        Me.label_info_ipact.AutoSize = True
        Me.label_info_ipact.Location = New System.Drawing.Point(9, 16)
        Me.label_info_ipact.Name = "label_info_ipact"
        Me.label_info_ipact.Size = New System.Drawing.Size(56, 13)
        Me.label_info_ipact.TabIndex = 6
        Me.label_info_ipact.Text = "IP Actual: "
        '
        'txtbox_info_ipact
        '
        Me.txtbox_info_ipact.BackColor = System.Drawing.Color.DarkGreen
        Me.txtbox_info_ipact.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_info_ipact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_info_ipact.ForeColor = System.Drawing.Color.White
        Me.txtbox_info_ipact.Location = New System.Drawing.Point(71, 16)
        Me.txtbox_info_ipact.Name = "txtbox_info_ipact"
        Me.txtbox_info_ipact.ReadOnly = True
        Me.txtbox_info_ipact.Size = New System.Drawing.Size(93, 13)
        Me.txtbox_info_ipact.TabIndex = 7
        Me.txtbox_info_ipact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtbox_info_ipant
        '
        Me.txtbox_info_ipant.BackColor = System.Drawing.Color.DarkRed
        Me.txtbox_info_ipant.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_info_ipant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_info_ipant.ForeColor = System.Drawing.Color.White
        Me.txtbox_info_ipant.Location = New System.Drawing.Point(238, 16)
        Me.txtbox_info_ipant.Name = "txtbox_info_ipant"
        Me.txtbox_info_ipant.ReadOnly = True
        Me.txtbox_info_ipant.Size = New System.Drawing.Size(93, 13)
        Me.txtbox_info_ipant.TabIndex = 9
        Me.txtbox_info_ipant.Text = " "
        Me.txtbox_info_ipant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'label_info_ipant
        '
        Me.label_info_ipant.AutoSize = True
        Me.label_info_ipant.Location = New System.Drawing.Point(170, 16)
        Me.label_info_ipant.Name = "label_info_ipant"
        Me.label_info_ipant.Size = New System.Drawing.Size(62, 13)
        Me.label_info_ipant.TabIndex = 8
        Me.label_info_ipant.Text = "IP Anterior: "
        '
        'GrupoOtros
        '
        Me.GrupoOtros.Controls.Add(Me.boton_ocultar)
        Me.GrupoOtros.Controls.Add(Me.boton_Acercade)
        Me.GrupoOtros.Controls.Add(Me.label_info_ipant)
        Me.GrupoOtros.Controls.Add(Me.txtbox_info_ipact)
        Me.GrupoOtros.Controls.Add(Me.label_info_ipact)
        Me.GrupoOtros.Controls.Add(Me.txtbox_info_ipant)
        Me.GrupoOtros.Location = New System.Drawing.Point(3, 443)
        Me.GrupoOtros.Name = "GrupoOtros"
        Me.GrupoOtros.Size = New System.Drawing.Size(656, 39)
        Me.GrupoOtros.TabIndex = 14
        Me.GrupoOtros.TabStop = False
        Me.GrupoOtros.Text = "Otros"
        '
        'boton_ocultar
        '
        Me.boton_ocultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.boton_ocultar.Location = New System.Drawing.Point(455, 11)
        Me.boton_ocultar.Name = "boton_ocultar"
        Me.boton_ocultar.Size = New System.Drawing.Size(93, 23)
        Me.boton_ocultar.TabIndex = 10
        Me.boton_ocultar.Text = "&Ocultar"
        Me.boton_ocultar.UseVisualStyleBackColor = True
        '
        'boton_Acercade
        '
        Me.boton_Acercade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.boton_Acercade.Location = New System.Drawing.Point(554, 11)
        Me.boton_Acercade.Name = "boton_Acercade"
        Me.boton_Acercade.Size = New System.Drawing.Size(93, 23)
        Me.boton_Acercade.TabIndex = 8
        Me.boton_Acercade.Text = "&Acerca De"
        Me.boton_Acercade.UseVisualStyleBackColor = True
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
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.Image = Global.TelnetDeluxe.My.Resources.Resources.Gui_Firefox
        Me.PictureBox2.Location = New System.Drawing.Point(516, 39)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.TelnetDeluxe.My.Resources.Resources.Gui_Router
        Me.PictureBox1.Location = New System.Drawing.Point(516, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(26, 26)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'TelnetDeluxe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 494)
        Me.Controls.Add(Me.GrupoOtros)
        Me.Controls.Add(Me.GrupoConsola)
        Me.Controls.Add(Me.GrupoConfig)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "TelnetDeluxe"
        Me.Text = "Telnet Deluxe"
        Me.GrupoConfig.ResumeLayout(False)
        Me.GrupoConfig.PerformLayout()
        Me.GrupoConsola.ResumeLayout(False)
        Me.GrupoOtros.ResumeLayout(False)
        Me.GrupoOtros.PerformLayout()
        Me.MenuTray.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrupoConfig As System.Windows.Forms.GroupBox
    Friend WithEvents txtbox_conf_iprouter As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_iprouter As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_puerto As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_puerto As System.Windows.Forms.Label
    Friend WithEvents boton_actualizar As System.Windows.Forms.Button
    Friend WithEvents crono_principal As System.Windows.Forms.Timer
    Friend WithEvents GrupoConsola As System.Windows.Forms.GroupBox
    Friend WithEvents Consola As System.Windows.Forms.RichTextBox
    Friend WithEvents label_estado As System.Windows.Forms.Label
    Friend WithEvents label_info_ipact As System.Windows.Forms.Label
    Friend WithEvents txtbox_info_ipant As System.Windows.Forms.TextBox
    Friend WithEvents label_info_ipant As System.Windows.Forms.Label
    Friend WithEvents txtbox_info_ipact As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_conf_refresco As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_refresco As System.Windows.Forms.Label
    Friend WithEvents GrupoOtros As System.Windows.Forms.GroupBox
    Friend WithEvents boton_Acercade As System.Windows.Forms.Button
    Friend WithEvents Combo_inirouters As System.Windows.Forms.ComboBox
    Friend WithEvents label_conf_inirouter As System.Windows.Forms.Label
    Friend WithEvents boton_cargarini As System.Windows.Forms.Button
    Friend WithEvents TD_Tray As System.Windows.Forms.NotifyIcon
    Friend WithEvents MenuTray As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents boton_ocultar As System.Windows.Forms.Button
    Friend WithEvents RenovarIPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestaurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TD_ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Timer_ConexInet As System.Windows.Forms.Timer
    Friend WithEvents label_inetconex As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

End Class
