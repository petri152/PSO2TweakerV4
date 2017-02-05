<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTweaksv2
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTweaksv2))
        Me.chkRemoveVita = New System.Windows.Forms.CheckBox()
        Me.chkRemovePC = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.chkRemoveSEGA = New System.Windows.Forms.CheckBox()
        Me.chkRemoveNVidia = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMainClose = New System.Windows.Forms.Button()
        Me.btnTitle = New System.Windows.Forms.Button()
        Me.chkRestoreSEGA = New System.Windows.Forms.CheckBox()
        Me.chkRestoreNVidia = New System.Windows.Forms.CheckBox()
        Me.chkRestoreVita = New System.Windows.Forms.CheckBox()
        Me.chkRestorePC = New System.Windows.Forms.CheckBox()
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkRemoveVita
        '
        Me.chkRemoveVita.AutoSize = True
        Me.chkRemoveVita.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRemoveVita.FlatAppearance.BorderSize = 0
        Me.chkRemoveVita.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveVita.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveVita.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveVita.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemoveVita.ForeColor = System.Drawing.Color.White
        Me.chkRemoveVita.Location = New System.Drawing.Point(78, 162)
        Me.chkRemoveVita.Name = "chkRemoveVita"
        Me.chkRemoveVita.Size = New System.Drawing.Size(188, 25)
        Me.chkRemoveVita.TabIndex = 26
        Me.chkRemoveVita.Text = "Remove Vita Opening"
        Me.chkRemoveVita.UseVisualStyleBackColor = False
        '
        'chkRemovePC
        '
        Me.chkRemovePC.AutoSize = True
        Me.chkRemovePC.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRemovePC.FlatAppearance.BorderSize = 0
        Me.chkRemovePC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRemovePC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRemovePC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRemovePC.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemovePC.ForeColor = System.Drawing.Color.White
        Me.chkRemovePC.Location = New System.Drawing.Point(78, 122)
        Me.chkRemovePC.Name = "chkRemovePC"
        Me.chkRemovePC.Size = New System.Drawing.Size(179, 25)
        Me.chkRemovePC.TabIndex = 25
        Me.chkRemovePC.Text = "Remove PC Opening"
        Me.chkRemovePC.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.tweaks
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Location = New System.Drawing.Point(47, 49)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(225, 40)
        Me.Button1.TabIndex = 24
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.patch_settings_big_box
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.Location = New System.Drawing.Point(41, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(704, 472)
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.medium_button_normal
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(784, 512)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(171, 40)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnReturn
        '
        Me.btnReturn.BackColor = System.Drawing.Color.Transparent
        Me.btnReturn.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.big_button_normal
        Me.btnReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnReturn.FlatAppearance.BorderSize = 0
        Me.btnReturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnReturn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Segoe UI Semibold", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturn.ForeColor = System.Drawing.Color.White
        Me.btnReturn.Location = New System.Drawing.Point(734, 558)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(221, 71)
        Me.btnReturn.TabIndex = 29
        Me.btnReturn.Text = "Save Changes"
        Me.btnReturn.UseVisualStyleBackColor = False
        '
        'chkRemoveSEGA
        '
        Me.chkRemoveSEGA.AutoSize = True
        Me.chkRemoveSEGA.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRemoveSEGA.FlatAppearance.BorderSize = 0
        Me.chkRemoveSEGA.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveSEGA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveSEGA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveSEGA.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemoveSEGA.ForeColor = System.Drawing.Color.White
        Me.chkRemoveSEGA.Location = New System.Drawing.Point(78, 242)
        Me.chkRemoveSEGA.Name = "chkRemoveSEGA"
        Me.chkRemoveSEGA.Size = New System.Drawing.Size(179, 25)
        Me.chkRemoveSEGA.TabIndex = 32
        Me.chkRemoveSEGA.Text = "Remove SEGA Video"
        Me.chkRemoveSEGA.UseVisualStyleBackColor = False
        '
        'chkRemoveNVidia
        '
        Me.chkRemoveNVidia.AutoSize = True
        Me.chkRemoveNVidia.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRemoveNVidia.FlatAppearance.BorderSize = 0
        Me.chkRemoveNVidia.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveNVidia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveNVidia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRemoveNVidia.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRemoveNVidia.ForeColor = System.Drawing.Color.White
        Me.chkRemoveNVidia.Location = New System.Drawing.Point(78, 202)
        Me.chkRemoveNVidia.Name = "chkRemoveNVidia"
        Me.chkRemoveNVidia.Size = New System.Drawing.Size(188, 25)
        Me.chkRemoveNVidia.TabIndex = 31
        Me.chkRemoveNVidia.Text = "Remove NVidia Video"
        Me.chkRemoveNVidia.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(74, 333)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(254, 63)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "＊Note: Removing the videos will" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "display a black screen. Click a few" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "times to ge" &
    "t to the title screen."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(74, 430)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(265, 21)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Currently Selected PSO2 Directory:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(74, 453)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(374, 21)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "C:\FAKEPATH\PHANTASYSTARONLINE2\pso2_bin\"
        '
        'btnMainClose
        '
        Me.btnMainClose.BackColor = System.Drawing.Color.Transparent
        Me.btnMainClose.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.close_normal
        Me.btnMainClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMainClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMainClose.Location = New System.Drawing.Point(952, 9)
        Me.btnMainClose.Name = "btnMainClose"
        Me.btnMainClose.Size = New System.Drawing.Size(19, 19)
        Me.btnMainClose.TabIndex = 43
        Me.btnMainClose.UseVisualStyleBackColor = False
        '
        'btnTitle
        '
        Me.btnTitle.BackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatAppearance.BorderSize = 0
        Me.btnTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTitle.ForeColor = System.Drawing.Color.White
        Me.btnTitle.Location = New System.Drawing.Point(0, 0)
        Me.btnTitle.Name = "btnTitle"
        Me.btnTitle.Size = New System.Drawing.Size(977, 30)
        Me.btnTitle.TabIndex = 44
        Me.btnTitle.Text = "PSO2 Tweaker"
        Me.btnTitle.UseVisualStyleBackColor = True
        '
        'chkRestoreSEGA
        '
        Me.chkRestoreSEGA.AutoSize = True
        Me.chkRestoreSEGA.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRestoreSEGA.FlatAppearance.BorderSize = 0
        Me.chkRestoreSEGA.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreSEGA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreSEGA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreSEGA.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRestoreSEGA.ForeColor = System.Drawing.Color.White
        Me.chkRestoreSEGA.Location = New System.Drawing.Point(516, 242)
        Me.chkRestoreSEGA.Name = "chkRestoreSEGA"
        Me.chkRestoreSEGA.Size = New System.Drawing.Size(176, 25)
        Me.chkRestoreSEGA.TabIndex = 49
        Me.chkRestoreSEGA.Text = "Restore SEGA Video"
        Me.chkRestoreSEGA.UseVisualStyleBackColor = False
        '
        'chkRestoreNVidia
        '
        Me.chkRestoreNVidia.AutoSize = True
        Me.chkRestoreNVidia.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRestoreNVidia.FlatAppearance.BorderSize = 0
        Me.chkRestoreNVidia.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreNVidia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreNVidia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreNVidia.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRestoreNVidia.ForeColor = System.Drawing.Color.White
        Me.chkRestoreNVidia.Location = New System.Drawing.Point(516, 202)
        Me.chkRestoreNVidia.Name = "chkRestoreNVidia"
        Me.chkRestoreNVidia.Size = New System.Drawing.Size(185, 25)
        Me.chkRestoreNVidia.TabIndex = 48
        Me.chkRestoreNVidia.Text = "Restore NVidia Video"
        Me.chkRestoreNVidia.UseVisualStyleBackColor = False
        '
        'chkRestoreVita
        '
        Me.chkRestoreVita.AutoSize = True
        Me.chkRestoreVita.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRestoreVita.FlatAppearance.BorderSize = 0
        Me.chkRestoreVita.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreVita.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreVita.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRestoreVita.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRestoreVita.ForeColor = System.Drawing.Color.White
        Me.chkRestoreVita.Location = New System.Drawing.Point(516, 162)
        Me.chkRestoreVita.Name = "chkRestoreVita"
        Me.chkRestoreVita.Size = New System.Drawing.Size(185, 25)
        Me.chkRestoreVita.TabIndex = 47
        Me.chkRestoreVita.Text = "Restore Vita Opening"
        Me.chkRestoreVita.UseVisualStyleBackColor = False
        '
        'chkRestorePC
        '
        Me.chkRestorePC.AutoSize = True
        Me.chkRestorePC.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkRestorePC.FlatAppearance.BorderSize = 0
        Me.chkRestorePC.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.chkRestorePC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.chkRestorePC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.chkRestorePC.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRestorePC.ForeColor = System.Drawing.Color.White
        Me.chkRestorePC.Location = New System.Drawing.Point(516, 122)
        Me.chkRestorePC.Name = "chkRestorePC"
        Me.chkRestorePC.Size = New System.Drawing.Size(176, 25)
        Me.chkRestorePC.TabIndex = 46
        Me.chkRestorePC.Text = "Restore PC Opening"
        Me.chkRestorePC.UseVisualStyleBackColor = False
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
        'frmTweaksv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(975, 653)
        Me.Controls.Add(Me.chkRestoreSEGA)
        Me.Controls.Add(Me.chkRestoreNVidia)
        Me.Controls.Add(Me.chkRestoreVita)
        Me.Controls.Add(Me.chkRestorePC)
        Me.Controls.Add(Me.btnMainClose)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkRemoveSEGA)
        Me.Controls.Add(Me.chkRemoveNVidia)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.chkRemoveVita)
        Me.Controls.Add(Me.chkRemovePC)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnTitle)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTweaksv2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkRemoveVita As System.Windows.Forms.CheckBox
    Friend WithEvents chkRemovePC As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents chkRemoveSEGA As System.Windows.Forms.CheckBox
    Friend WithEvents chkRemoveNVidia As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMainClose As System.Windows.Forms.Button
    Friend WithEvents btnTitle As System.Windows.Forms.Button
    Friend WithEvents chkRestoreSEGA As CheckBox
    Friend WithEvents chkRestoreNVidia As CheckBox
    Friend WithEvents chkRestoreVita As CheckBox
    Friend WithEvents chkRestorePC As CheckBox
    Friend WithEvents TT As ToolTip
End Class
