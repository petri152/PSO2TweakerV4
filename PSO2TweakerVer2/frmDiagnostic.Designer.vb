<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDiagnostic
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDiagnostic))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.lblPSO2Test = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 46)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 39)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "System Specs"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(415, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(113, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 39)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "HOSTS file"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(215, 46)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 39)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "PSO2 Install info"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(317, 46)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(96, 39)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Files in pso2_bin"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(11, 91)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(96, 39)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Flush DNS"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(113, 91)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(96, 39)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Ping Test"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'lblPSO2Test
        '
        Me.lblPSO2Test.AutoSize = True
        Me.lblPSO2Test.Location = New System.Drawing.Point(8, 133)
        Me.lblPSO2Test.Name = "lblPSO2Test"
        Me.lblPSO2Test.Size = New System.Drawing.Size(62, 13)
        Me.lblPSO2Test.TabIndex = 9
        Me.lblPSO2Test.Text = "PSO2 Test:"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(215, 91)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(96, 39)
        Me.Button7.TabIndex = 10
        Me.Button7.Text = "Winsock Catalog"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(317, 91)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(96, 39)
        Me.Button8.TabIndex = 11
        Me.Button8.Text = "Dump Autorun"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'FrmDiagnostic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 150)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.lblPSO2Test)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDiagnostic"
        Me.ShowIcon = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents lblPSO2Test As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
