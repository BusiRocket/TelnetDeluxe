<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TD_AcercaDe
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lbl_acercade_version = New System.Windows.Forms.Label
        Me.lbl_acercade_Licencia = New System.Windows.Forms.Label
        Me.enlace_cc = New System.Windows.Forms.LinkLabel
        Me.imagen_cc = New System.Windows.Forms.PictureBox
        Me.lbl_acercade_licenciadlx = New System.Windows.Forms.Label
        Me.lbl_acercade_desarrollo = New System.Windows.Forms.Label
        Me.lbl_acercade_email = New System.Windows.Forms.LinkLabel
        Me.lbl_acercade_dirweb = New System.Windows.Forms.LinkLabel
        Me.boton_dejamesalir = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.imagen_cc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.72414!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_acercade_version, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_acercade_Licencia, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.enlace_cc, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.imagen_cc, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_acercade_licenciadlx, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_acercade_desarrollo, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_acercade_email, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.lbl_acercade_dirweb, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.boton_dejamesalir, 1, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 9)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(551, 250)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lbl_acercade_version
        '
        Me.lbl_acercade_version.AutoSize = True
        Me.lbl_acercade_version.Location = New System.Drawing.Point(3, 0)
        Me.lbl_acercade_version.Name = "lbl_acercade_version"
        Me.lbl_acercade_version.Size = New System.Drawing.Size(73, 13)
        Me.lbl_acercade_version.TabIndex = 1
        Me.lbl_acercade_version.Text = "Telnet Deluxe"
        '
        'lbl_acercade_Licencia
        '
        Me.lbl_acercade_Licencia.AutoSize = True
        Me.lbl_acercade_Licencia.Location = New System.Drawing.Point(3, 23)
        Me.lbl_acercade_Licencia.Name = "lbl_acercade_Licencia"
        Me.lbl_acercade_Licencia.Size = New System.Drawing.Size(382, 39)
        Me.lbl_acercade_Licencia.TabIndex = 2
        Me.lbl_acercade_Licencia.Text = "Telnet Deluxe se distribuye bajo la licencia Creative Commons " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """Atribución-NoCom" & _
            "ercial-LicenciarIgual 3.0 Unported""" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Puede encontrar más información de la licen" & _
            "cia pulsando en el siguiente enlace"
        '
        'enlace_cc
        '
        Me.enlace_cc.AutoSize = True
        Me.enlace_cc.Location = New System.Drawing.Point(3, 70)
        Me.enlace_cc.Name = "enlace_cc"
        Me.enlace_cc.Size = New System.Drawing.Size(252, 13)
        Me.enlace_cc.TabIndex = 3
        Me.enlace_cc.TabStop = True
        Me.enlace_cc.Text = "http://creativecommons.org/licenses/by-nc-sa/3.0/"
        '
        'imagen_cc
        '
        Me.imagen_cc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.imagen_cc.Image = Global.TelnetDeluxe.My.Resources.Resources.iconocc
        Me.imagen_cc.Location = New System.Drawing.Point(401, 26)
        Me.imagen_cc.Name = "imagen_cc"
        Me.TableLayoutPanel1.SetRowSpan(Me.imagen_cc, 2)
        Me.imagen_cc.Size = New System.Drawing.Size(147, 77)
        Me.imagen_cc.TabIndex = 0
        Me.imagen_cc.TabStop = False
        '
        'lbl_acercade_licenciadlx
        '
        Me.lbl_acercade_licenciadlx.AutoSize = True
        Me.lbl_acercade_licenciadlx.Location = New System.Drawing.Point(3, 106)
        Me.lbl_acercade_licenciadlx.Name = "lbl_acercade_licenciadlx"
        Me.lbl_acercade_licenciadlx.Size = New System.Drawing.Size(288, 39)
        Me.lbl_acercade_licenciadlx.TabIndex = 4
        Me.lbl_acercade_licenciadlx.Text = "Abra el archivo ""Leeme.txt"" para encontrar más información" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Gracias por usar Te" & _
            "lnet Deluxe"
        '
        'lbl_acercade_desarrollo
        '
        Me.lbl_acercade_desarrollo.AutoSize = True
        Me.lbl_acercade_desarrollo.Location = New System.Drawing.Point(3, 161)
        Me.lbl_acercade_desarrollo.Name = "lbl_acercade_desarrollo"
        Me.lbl_acercade_desarrollo.Size = New System.Drawing.Size(157, 39)
        Me.lbl_acercade_desarrollo.TabIndex = 5
        Me.lbl_acercade_desarrollo.Text = "Desarrollado por CristianDeluxe." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contacto:"
        '
        'lbl_acercade_email
        '
        Me.lbl_acercade_email.AutoSize = True
        Me.lbl_acercade_email.Location = New System.Drawing.Point(3, 208)
        Me.lbl_acercade_email.Name = "lbl_acercade_email"
        Me.lbl_acercade_email.Size = New System.Drawing.Size(137, 13)
        Me.lbl_acercade_email.TabIndex = 6
        Me.lbl_acercade_email.TabStop = True
        Me.lbl_acercade_email.Text = "djcristiandeluxe@gmail.com"
        '
        'lbl_acercade_dirweb
        '
        Me.lbl_acercade_dirweb.AutoSize = True
        Me.lbl_acercade_dirweb.Location = New System.Drawing.Point(3, 229)
        Me.lbl_acercade_dirweb.Name = "lbl_acercade_dirweb"
        Me.lbl_acercade_dirweb.Size = New System.Drawing.Size(186, 13)
        Me.lbl_acercade_dirweb.TabIndex = 7
        Me.lbl_acercade_dirweb.TabStop = True
        Me.lbl_acercade_dirweb.Text = "http://deluxeworld.googlepages.com/"
        '
        'boton_dejamesalir
        '
        Me.boton_dejamesalir.BackColor = System.Drawing.Color.DimGray
        Me.boton_dejamesalir.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.boton_dejamesalir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.boton_dejamesalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.boton_dejamesalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boton_dejamesalir.ForeColor = System.Drawing.Color.White
        Me.boton_dejamesalir.Location = New System.Drawing.Point(401, 164)
        Me.boton_dejamesalir.Name = "boton_dejamesalir"
        Me.boton_dejamesalir.Size = New System.Drawing.Size(147, 41)
        Me.boton_dejamesalir.TabIndex = 0
        Me.boton_dejamesalir.Text = "&Aceptar"
        Me.boton_dejamesalir.UseVisualStyleBackColor = False
        '
        'TD_AcercaDe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(569, 268)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TD_AcercaDe"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Acerca de Telnet Deluxe"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.imagen_cc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents imagen_cc As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_acercade_version As System.Windows.Forms.Label
    Friend WithEvents lbl_acercade_Licencia As System.Windows.Forms.Label
    Friend WithEvents enlace_cc As System.Windows.Forms.LinkLabel
    Friend WithEvents lbl_acercade_licenciadlx As System.Windows.Forms.Label
    Friend WithEvents lbl_acercade_email As System.Windows.Forms.LinkLabel
    Friend WithEvents lbl_acercade_desarrollo As System.Windows.Forms.Label
    Friend WithEvents lbl_acercade_dirweb As System.Windows.Forms.LinkLabel
    Friend WithEvents boton_dejamesalir As System.Windows.Forms.Button

End Class