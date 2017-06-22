<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MessageBoxCustom
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnOther = New System.Windows.Forms.Button()
        Me.btnTitle = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BackColor = System.Drawing.Color.Transparent
        Me.lblMessage.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblMessage.Location = New System.Drawing.Point(0, 17)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(63, 19)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Message"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnYes
        '
        Me.btnYes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnYes.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Cancel_button_normal
        Me.btnYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnYes.FlatAppearance.BorderSize = 0
        Me.btnYes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnYes.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnYes.ForeColor = System.Drawing.Color.White
        Me.btnYes.Location = New System.Drawing.Point(12, 106)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(102, 40)
        Me.btnYes.TabIndex = 32
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = False
        '
        'btnNo
        '
        Me.btnNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnNo.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Cancel_button_normal
        Me.btnNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNo.FlatAppearance.BorderSize = 0
        Me.btnNo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnNo.ForeColor = System.Drawing.Color.White
        Me.btnNo.Location = New System.Drawing.Point(162, 106)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(102, 40)
        Me.btnNo.TabIndex = 33
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = False
        '
        'btnOther
        '
        Me.btnOther.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.btnOther.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Cancel_button_normal_msgbox
        Me.btnOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnOther.FlatAppearance.BorderSize = 0
        Me.btnOther.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOther.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnOther.ForeColor = System.Drawing.Color.White
        Me.btnOther.Location = New System.Drawing.Point(310, 106)
        Me.btnOther.Name = "btnOther"
        Me.btnOther.Size = New System.Drawing.Size(102, 40)
        Me.btnOther.TabIndex = 34
        Me.btnOther.Text = "Configure"
        Me.btnOther.UseVisualStyleBackColor = False
        '
        'btnTitle
        '
        Me.btnTitle.BackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatAppearance.BorderSize = 0
        Me.btnTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold)
        Me.btnTitle.ForeColor = System.Drawing.Color.White
        Me.btnTitle.Location = New System.Drawing.Point(0, -1)
        Me.btnTitle.Name = "btnTitle"
        Me.btnTitle.Size = New System.Drawing.Size(424, 21)
        Me.btnTitle.TabIndex = 35
        Me.btnTitle.Text = "MSGBOX Title"
        Me.btnTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTitle.UseVisualStyleBackColor = True
        '
        'MessageBoxCustom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.background_golden
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(424, 153)
        Me.Controls.Add(Me.btnTitle)
        Me.Controls.Add(Me.btnOther)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblMessage)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MessageBoxCustom"
        Me.Text = "Messagebox notification"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblMessage As Label
    Friend WithEvents btnYes As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents btnOther As Button
    Friend WithEvents btnTitle As Button
End Class
