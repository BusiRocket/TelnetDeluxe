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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Check_MinimTray = New System.Windows.Forms.CheckBox
        Me.Check_LogIP = New System.Windows.Forms.CheckBox
        Me.Check_HoraConsola = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtbox_conf_intervalo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.tab_router = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.label_conf_inirouter = New System.Windows.Forms.Label
        Me.Combo_inirouters = New System.Windows.Forms.ComboBox
        Me.GrupoConfig = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtbox_conf_pass = New System.Windows.Forms.TextBox
        Me.txtbox_conf_puerto = New System.Windows.Forms.TextBox
        Me.txtbox_conf_user = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtbox_conf_iprouter = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
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
        Me.TabOpciones.SuspendLayout()
        Me.Tab_Principal.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tab_router.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GrupoConfig.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabOpciones
        '
        Me.TabOpciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabOpciones.Controls.Add(Me.Tab_Principal)
        Me.TabOpciones.Controls.Add(Me.tab_router)
        Me.TabOpciones.Location = New System.Drawing.Point(2, 2)
        Me.TabOpciones.Name = "TabOpciones"
        Me.TabOpciones.SelectedIndex = 0
        Me.TabOpciones.Size = New System.Drawing.Size(581, 330)
        Me.TabOpciones.TabIndex = 0
        '
        'Tab_Principal
        '
        Me.Tab_Principal.Controls.Add(Me.GroupBox3)
        Me.Tab_Principal.Controls.Add(Me.GroupBox1)
        Me.Tab_Principal.Location = New System.Drawing.Point(4, 22)
        Me.Tab_Principal.Name = "Tab_Principal"
        Me.Tab_Principal.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_Principal.Size = New System.Drawing.Size(573, 304)
        Me.Tab_Principal.TabIndex = 0
        Me.Tab_Principal.Text = "Opciones Principales"
        Me.Tab_Principal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Check_MinimTray)
        Me.GroupBox3.Controls.Add(Me.Check_LogIP)
        Me.GroupBox3.Controls.Add(Me.Check_HoraConsola)
        Me.GroupBox3.Location = New System.Drawing.Point(280, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(287, 112)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "General"
        '
        'Check_MinimTray
        '
        Me.Check_MinimTray.AutoSize = True
        Me.Check_MinimTray.Location = New System.Drawing.Point(6, 66)
        Me.Check_MinimTray.Name = "Check_MinimTray"
        Me.Check_MinimTray.Size = New System.Drawing.Size(176, 17)
        Me.Check_MinimTray.TabIndex = 17
        Me.Check_MinimTray.Text = "Minimizar al área de notificación"
        Me.Check_MinimTray.UseVisualStyleBackColor = True
        '
        'Check_LogIP
        '
        Me.Check_LogIP.AutoSize = True
        Me.Check_LogIP.Location = New System.Drawing.Point(6, 42)
        Me.Check_LogIP.Name = "Check_LogIP"
        Me.Check_LogIP.Size = New System.Drawing.Size(265, 17)
        Me.Check_LogIP.TabIndex = 16
        Me.Check_LogIP.Text = "Guardar las IP's conseguidas en el archivo ""ip.log"""
        Me.Check_LogIP.UseVisualStyleBackColor = True
        '
        'Check_HoraConsola
        '
        Me.Check_HoraConsola.AutoSize = True
        Me.Check_HoraConsola.Location = New System.Drawing.Point(6, 19)
        Me.Check_HoraConsola.Name = "Check_HoraConsola"
        Me.Check_HoraConsola.Size = New System.Drawing.Size(162, 17)
        Me.Check_HoraConsola.TabIndex = 14
        Me.Check_HoraConsola.Text = "&Mostrar la hora en la consola"
        Me.Check_HoraConsola.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtbox_conf_intervalo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 112)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Telnet"
        '
        'txtbox_conf_intervalo
        '
        Me.txtbox_conf_intervalo.BackColor = System.Drawing.Color.White
        Me.txtbox_conf_intervalo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_conf_intervalo.Location = New System.Drawing.Point(121, 27)
        Me.txtbox_conf_intervalo.Name = "txtbox_conf_intervalo"
        Me.txtbox_conf_intervalo.Size = New System.Drawing.Size(29, 13)
        Me.txtbox_conf_intervalo.TabIndex = 7
        Me.txtbox_conf_intervalo.Text = "3"
        Me.txtbox_conf_intervalo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Intervalo Envío (seg):"
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
        Me.GrupoConfig.Controls.Add(Me.Label1)
        Me.GrupoConfig.Controls.Add(Me.Label3)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_pass)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_puerto)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_user)
        Me.GrupoConfig.Controls.Add(Me.Label4)
        Me.GrupoConfig.Controls.Add(Me.txtbox_conf_iprouter)
        Me.GrupoConfig.Controls.Add(Me.Label5)
        Me.GrupoConfig.Location = New System.Drawing.Point(6, 6)
        Me.GrupoConfig.Name = "GrupoConfig"
        Me.GrupoConfig.Size = New System.Drawing.Size(258, 112)
        Me.GrupoConfig.TabIndex = 2
        Me.GrupoConfig.TabStop = False
        Me.GrupoConfig.Text = "&Opciones del router"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Contraseña:"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Puerto:"
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "IP del Router:"
        '
        'boton_aceptar
        '
        Me.boton_aceptar.Location = New System.Drawing.Point(342, 339)
        Me.boton_aceptar.Name = "boton_aceptar"
        Me.boton_aceptar.Size = New System.Drawing.Size(75, 23)
        Me.boton_aceptar.TabIndex = 1
        Me.boton_aceptar.Text = "&Aceptar"
        Me.boton_aceptar.UseVisualStyleBackColor = True
        '
        'boton_cancelar
        '
        Me.boton_cancelar.Location = New System.Drawing.Point(423, 339)
        Me.boton_cancelar.Name = "boton_cancelar"
        Me.boton_cancelar.Size = New System.Drawing.Size(75, 23)
        Me.boton_cancelar.TabIndex = 2
        Me.boton_cancelar.Text = "&Cancelar"
        Me.boton_cancelar.UseVisualStyleBackColor = True
        '
        'boton_aplicar
        '
        Me.boton_aplicar.Location = New System.Drawing.Point(504, 339)
        Me.boton_aplicar.Name = "boton_aplicar"
        Me.boton_aplicar.Size = New System.Drawing.Size(75, 23)
        Me.boton_aplicar.TabIndex = 3
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
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tab_router.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GrupoConfig.ResumeLayout(False)
        Me.GrupoConfig.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabOpciones As System.Windows.Forms.TabControl
    Friend WithEvents Tab_Principal As System.Windows.Forms.TabPage
    Friend WithEvents tab_router As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtbox_conf_intervalo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents boton_aceptar As System.Windows.Forms.Button
    Friend WithEvents boton_cancelar As System.Windows.Forms.Button
    Friend WithEvents boton_aplicar As System.Windows.Forms.Button
    Friend WithEvents GrupoConfig As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_pass As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_conf_puerto As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_conf_user As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_iprouter As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents label_conf_pass As System.Windows.Forms.Label
    Friend WithEvents label_conf_Usuario As System.Windows.Forms.Label
    Friend WithEvents txtbox_conf_password As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_bad2 As System.Windows.Forms.TextBox
    Friend WithEvents txtbox_bad3 As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_puerto As System.Windows.Forms.Label
    Friend WithEvents txtbox_oculto As System.Windows.Forms.TextBox
    Friend WithEvents label_conf_iprouter As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Check_HoraConsola As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents label_conf_inirouter As System.Windows.Forms.Label
    Friend WithEvents Combo_inirouters As System.Windows.Forms.ComboBox
    Friend WithEvents Check_LogIP As System.Windows.Forms.CheckBox
    Friend WithEvents Check_MinimTray As System.Windows.Forms.CheckBox
End Class
