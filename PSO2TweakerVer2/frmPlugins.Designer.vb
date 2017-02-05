<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPlugins
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
        Me.components = New System.ComponentModel.Container()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnForceCheck = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnConfigure = New System.Windows.Forms.Button()
        Me.btnTitle = New System.Windows.Forms.Button()
        Me.btnMainClose = New System.Windows.Forms.Button()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ListView1.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.cmsback
        Me.ListView1.BackgroundImageTiled = True
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.CheckBoxes = True
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.ForeColor = System.Drawing.Color.White
        Me.ListView1.Location = New System.Drawing.Point(2, 17)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(418, 196)
        Me.ListView1.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Location = New System.Drawing.Point(0, 209)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(421, 121)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Filename: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Author(s):" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description:"
        '
        'btnForceCheck
        '
        Me.btnForceCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.btnForceCheck.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Cancel_button_normal
        Me.btnForceCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnForceCheck.FlatAppearance.BorderSize = 0
        Me.btnForceCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnForceCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnForceCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnForceCheck.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnForceCheck.ForeColor = System.Drawing.Color.White
        Me.btnForceCheck.Location = New System.Drawing.Point(12, 330)
        Me.btnForceCheck.Name = "btnForceCheck"
        Me.btnForceCheck.Size = New System.Drawing.Size(102, 40)
        Me.btnForceCheck.TabIndex = 32
        Me.btnForceCheck.Text = "Plugin Check"
        Me.TT.SetToolTip(Me.btnForceCheck, "Force a plugin check, to make sure you have the latest plugin versions")
        Me.btnForceCheck.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.btnSave.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Cancel_button_normal
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(162, 330)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 40)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Save"
        Me.TT.SetToolTip(Me.btnSave, "Save the above settings")
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnConfigure
        '
        Me.btnConfigure.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.btnConfigure.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Cancel_button_normal
        Me.btnConfigure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnConfigure.FlatAppearance.BorderSize = 0
        Me.btnConfigure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnConfigure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.btnConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConfigure.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnConfigure.ForeColor = System.Drawing.Color.White
        Me.btnConfigure.Location = New System.Drawing.Point(310, 330)
        Me.btnConfigure.Name = "btnConfigure"
        Me.btnConfigure.Size = New System.Drawing.Size(102, 40)
        Me.btnConfigure.TabIndex = 34
        Me.btnConfigure.Text = "Configure"
        Me.btnConfigure.UseVisualStyleBackColor = False
        Me.btnConfigure.Visible = False
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
        Me.btnTitle.Text = "Plugin Menu"
        Me.btnTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTitle.UseVisualStyleBackColor = True
        '
        'btnMainClose
        '
        Me.btnMainClose.BackColor = System.Drawing.Color.Transparent
        Me.btnMainClose.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.close_normal
        Me.btnMainClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMainClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMainClose.Location = New System.Drawing.Point(411, 6)
        Me.btnMainClose.Name = "btnMainClose"
        Me.btnMainClose.Size = New System.Drawing.Size(10, 10)
        Me.btnMainClose.TabIndex = 36
        Me.btnMainClose.UseVisualStyleBackColor = False
        '
        'TT
        '
        Me.TT.AutomaticDelay = 0
        Me.TT.AutoPopDelay = 32000
        Me.TT.BackColor = System.Drawing.SystemColors.HotTrack
        Me.TT.ForeColor = System.Drawing.SystemColors.Highlight
        Me.TT.InitialDelay = 0
        Me.TT.IsBalloon = True
        Me.TT.ReshowDelay = 96
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "Information"
        '
        'frmPlugins
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(424, 382)
        Me.Controls.Add(Me.btnMainClose)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.btnTitle)
        Me.Controls.Add(Me.btnConfigure)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnForceCheck)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPlugins"
        Me.Text = "Plugin Manager (BETA)"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnForceCheck As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnConfigure As Button
    Friend WithEvents btnTitle As Button
    Friend WithEvents btnMainClose As Button
    Friend WithEvents TT As ToolTip
End Class
