<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TDSplash
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
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
        Me.Splash = New System.Windows.Forms.PictureBox
        CType(Me.Splash, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Splash
        '
        Me.Splash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Splash.Image = Global.TelnetDeluxe.My.Resources.Resources.Splash
        Me.Splash.Location = New System.Drawing.Point(0, 0)
        Me.Splash.Name = "Splash"
        Me.Splash.Size = New System.Drawing.Size(463, 257)
        Me.Splash.TabIndex = 1
        Me.Splash.TabStop = False
        '
        'TDSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 255)
        Me.ControlBox = False
        Me.Controls.Add(Me.Splash)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TDSplash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.Splash, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Splash As System.Windows.Forms.PictureBox

End Class
