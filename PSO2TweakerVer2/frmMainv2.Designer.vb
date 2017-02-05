<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMainv2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainv2))
        Me.btnMainClose = New System.Windows.Forms.Button()
        Me.btnMainMinimize = New System.Windows.Forms.Button()
        Me.btnTitle = New System.Windows.Forms.Button()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.btnPSO2Settings = New System.Windows.Forms.Button()
        Me.btnTweaks = New System.Windows.Forms.Button()
        Me.btnTweakerSettings = New System.Windows.Forms.Button()
        Me.btnStartPSO2 = New System.Windows.Forms.Button()
        Me.btnALShortcut = New System.Windows.Forms.Button()
        Me.btnPSOWShortcut = New System.Windows.Forms.Button()
        Me.btnALDonate = New System.Windows.Forms.Button()
        Me.btnBumpedShortcut = New System.Windows.Forms.Button()
        Me.btnBumpedDonate = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.rtbDebug = New System.Windows.Forms.RichTextBox()
        Me.cmsTextBarOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyAllTextToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmsORB = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsSelectFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInstallUpdatePatches = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallEnglishPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallEnglishLargeFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallEnglishStoryPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInstallFrenchPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallGermanPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallRussianPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallRussianLargeFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallSpanishPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsRestoreBackups = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRestoreEnglishPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRestoreLargeFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRestoreStoryPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsUninstallPatches = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmUninstallEnglishPatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmUninstallLargeFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmUninstallStory = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRevertECodes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRevertENNames = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdTroubleshooting = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmAnalyzeInstall = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCheckForDeletedOrEmptyFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCheckForOldOrMissingFiles = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCheckForOldOrMissingFilesOldMethod = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFixGameGuardErrors = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFixPSO2EXEs = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFixPSO2Permissions = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmOpenDiagnosticMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmResetPSO2Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmResetTweakerSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmTerminatePSO2Process = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsOtherTasks = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmStartChromeInCompatibilityMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmConfigureTelepipeProxy = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmRevertSettingsToJP = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmClearSymbolArtCache = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInstallPSO2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmCheckForPSO2UpdatesWithQuantum = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmCheckForPrePatchData = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnTelepipe = New System.Windows.Forms.Button()
        Me.btnVisiphoneShortcut = New System.Windows.Forms.Button()
        Me.btnPSO2DiscordShortcut = New System.Windows.Forms.Button()
        Me.btnPlugins = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblAppVersion = New System.Windows.Forms.Label()
        Me.lblDefaults = New System.Windows.Forms.Label()
        Me.lblShipStatus = New System.Windows.Forms.Label()
        Me.txtPSO2DefaultINI = New System.Windows.Forms.TextBox()
        Me.tmrWaitingforPSO2 = New System.Windows.Forms.Timer(Me.components)
        Me.TT = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblShipEQ = New System.Windows.Forms.Label()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTextBarOptions.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsORB.SuspendLayout()
        Me.SuspendLayout()
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
        Me.btnMainClose.TabIndex = 0
        Me.btnMainClose.UseVisualStyleBackColor = False
        '
        'btnMainMinimize
        '
        Me.btnMainMinimize.BackColor = System.Drawing.Color.Transparent
        Me.btnMainMinimize.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.minimize_normal
        Me.btnMainMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMainMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMainMinimize.Location = New System.Drawing.Point(930, 9)
        Me.btnMainMinimize.Name = "btnMainMinimize"
        Me.btnMainMinimize.Size = New System.Drawing.Size(19, 19)
        Me.btnMainMinimize.TabIndex = 1
        Me.btnMainMinimize.UseVisualStyleBackColor = False
        '
        'btnTitle
        '
        Me.btnTitle.BackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatAppearance.BorderSize = 0
        Me.btnTitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTitle.ForeColor = System.Drawing.Color.White
        Me.btnTitle.Location = New System.Drawing.Point(0, 0)
        Me.btnTitle.Name = "btnTitle"
        Me.btnTitle.Size = New System.Drawing.Size(977, 30)
        Me.btnTitle.TabIndex = 2
        Me.btnTitle.Text = "PSO2 Tweaker"
        Me.btnTitle.UseVisualStyleBackColor = True
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.Transparent
        Me.picLogo.Image = Global.PSO2TweakerVer2.My.Resources.Resources.logo
        Me.picLogo.Location = New System.Drawing.Point(30, 55)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(291, 279)
        Me.picLogo.TabIndex = 3
        Me.picLogo.TabStop = False
        Me.TT.SetToolTip(Me.picLogo, "much logo very HD wow")
        '
        'btnPSO2Settings
        '
        Me.btnPSO2Settings.BackColor = System.Drawing.Color.Transparent
        Me.btnPSO2Settings.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.medium_button_normal
        Me.btnPSO2Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPSO2Settings.FlatAppearance.BorderSize = 0
        Me.btnPSO2Settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPSO2Settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPSO2Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPSO2Settings.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPSO2Settings.ForeColor = System.Drawing.Color.White
        Me.btnPSO2Settings.Location = New System.Drawing.Point(88, 345)
        Me.btnPSO2Settings.Name = "btnPSO2Settings"
        Me.btnPSO2Settings.Size = New System.Drawing.Size(171, 40)
        Me.btnPSO2Settings.TabIndex = 4
        Me.btnPSO2Settings.Text = "PSO2 Settings"
        Me.TT.SetToolTip(Me.btnPSO2Settings, "Change certain PSO2 options (Video, Sound, etc)")
        Me.btnPSO2Settings.UseVisualStyleBackColor = False
        '
        'btnTweaks
        '
        Me.btnTweaks.BackColor = System.Drawing.Color.Transparent
        Me.btnTweaks.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.medium_button_normal
        Me.btnTweaks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTweaks.FlatAppearance.BorderSize = 0
        Me.btnTweaks.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTweaks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTweaks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTweaks.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTweaks.ForeColor = System.Drawing.Color.White
        Me.btnTweaks.Location = New System.Drawing.Point(88, 495)
        Me.btnTweaks.Name = "btnTweaks"
        Me.btnTweaks.Size = New System.Drawing.Size(171, 40)
        Me.btnTweaks.TabIndex = 5
        Me.btnTweaks.Text = "Modifications"
        Me.TT.SetToolTip(Me.btnTweaks, "Legacy modifications (Removing/Restoring openings, etc)")
        Me.btnTweaks.UseVisualStyleBackColor = False
        '
        'btnTweakerSettings
        '
        Me.btnTweakerSettings.BackColor = System.Drawing.Color.Transparent
        Me.btnTweakerSettings.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.medium_button_normal
        Me.btnTweakerSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnTweakerSettings.FlatAppearance.BorderSize = 0
        Me.btnTweakerSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTweakerSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTweakerSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTweakerSettings.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTweakerSettings.ForeColor = System.Drawing.Color.White
        Me.btnTweakerSettings.Location = New System.Drawing.Point(88, 445)
        Me.btnTweakerSettings.Name = "btnTweakerSettings"
        Me.btnTweakerSettings.Size = New System.Drawing.Size(171, 40)
        Me.btnTweakerSettings.TabIndex = 6
        Me.btnTweakerSettings.Text = "Tweaker Settings"
        Me.TT.SetToolTip(Me.btnTweakerSettings, "Change options relating to the PSO2 Tweaker")
        Me.btnTweakerSettings.UseVisualStyleBackColor = False
        '
        'btnStartPSO2
        '
        Me.btnStartPSO2.BackColor = System.Drawing.Color.Transparent
        Me.btnStartPSO2.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.big_button_normal
        Me.btnStartPSO2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnStartPSO2.FlatAppearance.BorderSize = 0
        Me.btnStartPSO2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnStartPSO2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnStartPSO2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartPSO2.Font = New System.Drawing.Font("Segoe UI Semibold", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartPSO2.ForeColor = System.Drawing.Color.White
        Me.btnStartPSO2.Location = New System.Drawing.Point(61, 556)
        Me.btnStartPSO2.Name = "btnStartPSO2"
        Me.btnStartPSO2.Size = New System.Drawing.Size(221, 71)
        Me.btnStartPSO2.TabIndex = 7
        Me.btnStartPSO2.Text = "Start PSO2"
        Me.TT.SetToolTip(Me.btnStartPSO2, "Launch the game! o/")
        Me.btnStartPSO2.UseVisualStyleBackColor = False
        '
        'btnALShortcut
        '
        Me.btnALShortcut.BackColor = System.Drawing.Color.Transparent
        Me.btnALShortcut.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.Alayer
        Me.btnALShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnALShortcut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnALShortcut.FlatAppearance.BorderSize = 0
        Me.btnALShortcut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnALShortcut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnALShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnALShortcut.Location = New System.Drawing.Point(899, 338)
        Me.btnALShortcut.Name = "btnALShortcut"
        Me.btnALShortcut.Size = New System.Drawing.Size(64, 64)
        Me.btnALShortcut.TabIndex = 18
        Me.TT.SetToolTip(Me.btnALShortcut, "Click to visit the Arks-Layer homepage!")
        Me.btnALShortcut.UseVisualStyleBackColor = False
        '
        'btnPSOWShortcut
        '
        Me.btnPSOWShortcut.BackColor = System.Drawing.Color.Transparent
        Me.btnPSOWShortcut.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.psow
        Me.btnPSOWShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPSOWShortcut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPSOWShortcut.FlatAppearance.BorderSize = 0
        Me.btnPSOWShortcut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPSOWShortcut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPSOWShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPSOWShortcut.Location = New System.Drawing.Point(899, 113)
        Me.btnPSOWShortcut.Name = "btnPSOWShortcut"
        Me.btnPSOWShortcut.Size = New System.Drawing.Size(64, 64)
        Me.btnPSOWShortcut.TabIndex = 19
        Me.TT.SetToolTip(Me.btnPSOWShortcut, "Click to visit PSO-World.com!")
        Me.btnPSOWShortcut.UseVisualStyleBackColor = False
        '
        'btnALDonate
        '
        Me.btnALDonate.BackColor = System.Drawing.Color.Transparent
        Me.btnALDonate.BackgroundImage = CType(resources.GetObject("btnALDonate.BackgroundImage"), System.Drawing.Image)
        Me.btnALDonate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnALDonate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnALDonate.FlatAppearance.BorderSize = 0
        Me.btnALDonate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnALDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnALDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnALDonate.Location = New System.Drawing.Point(899, 488)
        Me.btnALDonate.Name = "btnALDonate"
        Me.btnALDonate.Size = New System.Drawing.Size(64, 64)
        Me.btnALDonate.TabIndex = 20
        Me.TT.SetToolTip(Me.btnALDonate, "Click to visit the Arks-Layer donation page!")
        Me.btnALDonate.UseVisualStyleBackColor = False
        '
        'btnBumpedShortcut
        '
        Me.btnBumpedShortcut.BackColor = System.Drawing.Color.Transparent
        Me.btnBumpedShortcut.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.bumped
        Me.btnBumpedShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBumpedShortcut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBumpedShortcut.FlatAppearance.BorderSize = 0
        Me.btnBumpedShortcut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBumpedShortcut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBumpedShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBumpedShortcut.Location = New System.Drawing.Point(899, 38)
        Me.btnBumpedShortcut.Name = "btnBumpedShortcut"
        Me.btnBumpedShortcut.Size = New System.Drawing.Size(64, 64)
        Me.btnBumpedShortcut.TabIndex = 21
        Me.TT.SetToolTip(Me.btnBumpedShortcut, "Click to visit the bumped.org homepage!")
        Me.btnBumpedShortcut.UseVisualStyleBackColor = False
        '
        'btnBumpedDonate
        '
        Me.btnBumpedDonate.BackColor = System.Drawing.Color.Transparent
        Me.btnBumpedDonate.BackgroundImage = CType(resources.GetObject("btnBumpedDonate.BackgroundImage"), System.Drawing.Image)
        Me.btnBumpedDonate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBumpedDonate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBumpedDonate.FlatAppearance.BorderSize = 0
        Me.btnBumpedDonate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBumpedDonate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBumpedDonate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBumpedDonate.Location = New System.Drawing.Point(899, 563)
        Me.btnBumpedDonate.Name = "btnBumpedDonate"
        Me.btnBumpedDonate.Size = New System.Drawing.Size(64, 64)
        Me.btnBumpedDonate.TabIndex = 22
        Me.TT.SetToolTip(Me.btnBumpedDonate, "Click to visit the bumped.org donation page!")
        Me.btnBumpedDonate.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.small_log
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(350, 395)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(538, 232)
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'rtbDebug
        '
        Me.rtbDebug.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.rtbDebug.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbDebug.ContextMenuStrip = Me.cmsTextBarOptions
        Me.rtbDebug.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbDebug.ForeColor = System.Drawing.Color.White
        Me.rtbDebug.HideSelection = False
        Me.rtbDebug.Location = New System.Drawing.Point(355, 400)
        Me.rtbDebug.Name = "rtbDebug"
        Me.rtbDebug.ReadOnly = True
        Me.rtbDebug.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.rtbDebug.Size = New System.Drawing.Size(529, 223)
        Me.rtbDebug.TabIndex = 25
        Me.rtbDebug.Text = ""
        '
        'cmsTextBarOptions
        '
        Me.cmsTextBarOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyAllTextToClipboardToolStripMenuItem})
        Me.cmsTextBarOptions.Name = "cmsTextBarOptions"
        Me.cmsTextBarOptions.Size = New System.Drawing.Size(207, 26)
        '
        'CopyAllTextToClipboardToolStripMenuItem
        '
        Me.CopyAllTextToClipboardToolStripMenuItem.Name = "CopyAllTextToClipboardToolStripMenuItem"
        Me.CopyAllTextToClipboardToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.CopyAllTextToClipboardToolStripMenuItem.Text = "Copy all text to clipboard"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.big_log
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(350, 38)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(538, 347)
        Me.PictureBox2.TabIndex = 26
        Me.PictureBox2.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblVersion.Location = New System.Drawing.Point(5, 624)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(0, 21)
        Me.lblVersion.TabIndex = 28
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.__normal
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(12, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(64, 64)
        Me.Button1.TabIndex = 32
        Me.TT.SetToolTip(Me.Button1, "Click this to access various tasks and features")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmsORB
        '
        Me.cmsORB.BackColor = System.Drawing.Color.Transparent
        Me.cmsORB.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.main_menu
        Me.cmsORB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmsORB.DropShadowEnabled = False
        Me.cmsORB.ImageScalingSize = New System.Drawing.Size(0, 0)
        Me.cmsORB.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsSelectFolder, Me.cmsInstallUpdatePatches, Me.cmsRestoreBackups, Me.cmsUninstallPatches, Me.cmdTroubleshooting, Me.cmsOtherTasks, Me.ToolStripSeparator1, Me.tsmCheckForPSO2UpdatesWithQuantum, Me.tsmCheckForPrePatchData})
        Me.cmsORB.Name = "cmsORB"
        Me.cmsORB.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsORB.ShowImageMargin = False
        Me.cmsORB.Size = New System.Drawing.Size(202, 186)
        '
        'cmsSelectFolder
        '
        Me.cmsSelectFolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmsSelectFolder.BackgroundImage = CType(resources.GetObject("cmsSelectFolder.BackgroundImage"), System.Drawing.Image)
        Me.cmsSelectFolder.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.cmsSelectFolder.ForeColor = System.Drawing.Color.White
        Me.cmsSelectFolder.Name = "cmsSelectFolder"
        Me.cmsSelectFolder.Size = New System.Drawing.Size(201, 22)
        Me.cmsSelectFolder.Text = "Select PSO2 Folder"
        Me.cmsSelectFolder.ToolTipText = "Use this to select your pso2_bin folder"
        '
        'cmsInstallUpdatePatches
        '
        Me.cmsInstallUpdatePatches.BackColor = System.Drawing.Color.Gray
        Me.cmsInstallUpdatePatches.BackgroundImage = CType(resources.GetObject("cmsInstallUpdatePatches.BackgroundImage"), System.Drawing.Image)
        Me.cmsInstallUpdatePatches.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmInstallEnglishPatch, Me.tsmInstallEnglishLargeFiles, Me.tsmInstallEnglishStoryPatch, Me.cmsInstallFrenchPatch, Me.tsmInstallGermanPatch, Me.tsmInstallRussianPatch, Me.tsmInstallRussianLargeFiles, Me.InstallSpanishPatch})
        Me.cmsInstallUpdatePatches.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.cmsInstallUpdatePatches.ForeColor = System.Drawing.Color.White
        Me.cmsInstallUpdatePatches.Name = "cmsInstallUpdatePatches"
        Me.cmsInstallUpdatePatches.Size = New System.Drawing.Size(201, 22)
        Me.cmsInstallUpdatePatches.Text = "Install/Update Patches"
        '
        'tsmInstallEnglishPatch
        '
        Me.tsmInstallEnglishPatch.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tsmInstallEnglishPatch.BackgroundImage = CType(resources.GetObject("tsmInstallEnglishPatch.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallEnglishPatch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmInstallEnglishPatch.ForeColor = System.Drawing.Color.White
        Me.tsmInstallEnglishPatch.Name = "tsmInstallEnglishPatch"
        Me.tsmInstallEnglishPatch.Size = New System.Drawing.Size(176, 22)
        Me.tsmInstallEnglishPatch.Text = "English Patch"
        Me.tsmInstallEnglishPatch.ToolTipText = "Install the core English patch"
        '
        'tsmInstallEnglishLargeFiles
        '
        Me.tsmInstallEnglishLargeFiles.BackgroundImage = CType(resources.GetObject("tsmInstallEnglishLargeFiles.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallEnglishLargeFiles.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmInstallEnglishLargeFiles.ForeColor = System.Drawing.Color.White
        Me.tsmInstallEnglishLargeFiles.Name = "tsmInstallEnglishLargeFiles"
        Me.tsmInstallEnglishLargeFiles.Size = New System.Drawing.Size(176, 22)
        Me.tsmInstallEnglishLargeFiles.Text = "English Large Files"
        Me.tsmInstallEnglishLargeFiles.ToolTipText = "Install additional English files to enhance the core patch"
        '
        'tsmInstallEnglishStoryPatch
        '
        Me.tsmInstallEnglishStoryPatch.BackgroundImage = CType(resources.GetObject("tsmInstallEnglishStoryPatch.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallEnglishStoryPatch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmInstallEnglishStoryPatch.ForeColor = System.Drawing.Color.White
        Me.tsmInstallEnglishStoryPatch.Name = "tsmInstallEnglishStoryPatch"
        Me.tsmInstallEnglishStoryPatch.Size = New System.Drawing.Size(176, 22)
        Me.tsmInstallEnglishStoryPatch.Text = "English Story Patch"
        Me.tsmInstallEnglishStoryPatch.ToolTipText = "Install the English story patch, so you can understand the story"
        '
        'cmsInstallFrenchPatch
        '
        Me.cmsInstallFrenchPatch.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.subtab
        Me.cmsInstallFrenchPatch.ForeColor = System.Drawing.Color.White
        Me.cmsInstallFrenchPatch.Name = "cmsInstallFrenchPatch"
        Me.cmsInstallFrenchPatch.Size = New System.Drawing.Size(176, 22)
        Me.cmsInstallFrenchPatch.Text = "French Patch"
        Me.cmsInstallFrenchPatch.Visible = False
        '
        'tsmInstallGermanPatch
        '
        Me.tsmInstallGermanPatch.BackgroundImage = CType(resources.GetObject("tsmInstallGermanPatch.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallGermanPatch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmInstallGermanPatch.ForeColor = System.Drawing.Color.White
        Me.tsmInstallGermanPatch.Name = "tsmInstallGermanPatch"
        Me.tsmInstallGermanPatch.Size = New System.Drawing.Size(176, 22)
        Me.tsmInstallGermanPatch.Text = "German Patch"
        Me.tsmInstallGermanPatch.Visible = False
        '
        'tsmInstallRussianPatch
        '
        Me.tsmInstallRussianPatch.BackgroundImage = CType(resources.GetObject("tsmInstallRussianPatch.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallRussianPatch.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmInstallRussianPatch.ForeColor = System.Drawing.Color.White
        Me.tsmInstallRussianPatch.Name = "tsmInstallRussianPatch"
        Me.tsmInstallRussianPatch.Size = New System.Drawing.Size(176, 22)
        Me.tsmInstallRussianPatch.Text = "Russian Patch"
        Me.tsmInstallRussianPatch.Visible = False
        '
        'tsmInstallRussianLargeFiles
        '
        Me.tsmInstallRussianLargeFiles.BackgroundImage = CType(resources.GetObject("tsmInstallRussianLargeFiles.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallRussianLargeFiles.ForeColor = System.Drawing.Color.White
        Me.tsmInstallRussianLargeFiles.Name = "tsmInstallRussianLargeFiles"
        Me.tsmInstallRussianLargeFiles.Size = New System.Drawing.Size(176, 22)
        Me.tsmInstallRussianLargeFiles.Text = "Russian Large Files"
        Me.tsmInstallRussianLargeFiles.Visible = False
        '
        'InstallSpanishPatch
        '
        Me.InstallSpanishPatch.BackgroundImage = CType(resources.GetObject("InstallSpanishPatch.BackgroundImage"), System.Drawing.Image)
        Me.InstallSpanishPatch.ForeColor = System.Drawing.Color.White
        Me.InstallSpanishPatch.Name = "InstallSpanishPatch"
        Me.InstallSpanishPatch.Size = New System.Drawing.Size(176, 22)
        Me.InstallSpanishPatch.Text = "Spanish Patch"
        Me.InstallSpanishPatch.Visible = False
        '
        'cmsRestoreBackups
        '
        Me.cmsRestoreBackups.BackgroundImage = CType(resources.GetObject("cmsRestoreBackups.BackgroundImage"), System.Drawing.Image)
        Me.cmsRestoreBackups.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmRestoreEnglishPatch, Me.tsmRestoreLargeFiles, Me.tsmRestoreStoryPatch})
        Me.cmsRestoreBackups.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.cmsRestoreBackups.ForeColor = System.Drawing.Color.White
        Me.cmsRestoreBackups.Name = "cmsRestoreBackups"
        Me.cmsRestoreBackups.Size = New System.Drawing.Size(201, 22)
        Me.cmsRestoreBackups.Text = "Restore Backup of JP Files"
        '
        'tsmRestoreEnglishPatch
        '
        Me.tsmRestoreEnglishPatch.BackgroundImage = CType(resources.GetObject("tsmRestoreEnglishPatch.BackgroundImage"), System.Drawing.Image)
        Me.tsmRestoreEnglishPatch.ForeColor = System.Drawing.Color.White
        Me.tsmRestoreEnglishPatch.Name = "tsmRestoreEnglishPatch"
        Me.tsmRestoreEnglishPatch.Size = New System.Drawing.Size(176, 22)
        Me.tsmRestoreEnglishPatch.Text = "English Patch"
        Me.tsmRestoreEnglishPatch.ToolTipText = "Restore a backup of the English patch (if it exists)"
        '
        'tsmRestoreLargeFiles
        '
        Me.tsmRestoreLargeFiles.BackgroundImage = CType(resources.GetObject("tsmRestoreLargeFiles.BackgroundImage"), System.Drawing.Image)
        Me.tsmRestoreLargeFiles.ForeColor = System.Drawing.Color.White
        Me.tsmRestoreLargeFiles.Name = "tsmRestoreLargeFiles"
        Me.tsmRestoreLargeFiles.Size = New System.Drawing.Size(176, 22)
        Me.tsmRestoreLargeFiles.Text = "English Large Files"
        Me.tsmRestoreLargeFiles.ToolTipText = "Restore a backup of the Large Files patch (if it exists)"
        '
        'tsmRestoreStoryPatch
        '
        Me.tsmRestoreStoryPatch.BackgroundImage = CType(resources.GetObject("tsmRestoreStoryPatch.BackgroundImage"), System.Drawing.Image)
        Me.tsmRestoreStoryPatch.ForeColor = System.Drawing.Color.White
        Me.tsmRestoreStoryPatch.Name = "tsmRestoreStoryPatch"
        Me.tsmRestoreStoryPatch.Size = New System.Drawing.Size(176, 22)
        Me.tsmRestoreStoryPatch.Text = "English Story Patch"
        Me.tsmRestoreStoryPatch.ToolTipText = "Restore a backup of the Story patch (if it exists)"
        '
        'cmsUninstallPatches
        '
        Me.cmsUninstallPatches.BackgroundImage = CType(resources.GetObject("cmsUninstallPatches.BackgroundImage"), System.Drawing.Image)
        Me.cmsUninstallPatches.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmUninstallEnglishPatch, Me.tsmUninstallLargeFiles, Me.tsmUninstallStory, Me.tsmRevertECodes, Me.tsmRevertENNames})
        Me.cmsUninstallPatches.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.cmsUninstallPatches.ForeColor = System.Drawing.Color.White
        Me.cmsUninstallPatches.Name = "cmsUninstallPatches"
        Me.cmsUninstallPatches.Size = New System.Drawing.Size(201, 22)
        Me.cmsUninstallPatches.Text = "Redownload Original JP Files"
        '
        'tsmUninstallEnglishPatch
        '
        Me.tsmUninstallEnglishPatch.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.subtab
        Me.tsmUninstallEnglishPatch.ForeColor = System.Drawing.Color.White
        Me.tsmUninstallEnglishPatch.Name = "tsmUninstallEnglishPatch"
        Me.tsmUninstallEnglishPatch.Size = New System.Drawing.Size(215, 22)
        Me.tsmUninstallEnglishPatch.Text = "English Patch"
        Me.tsmUninstallEnglishPatch.ToolTipText = "Uninstall the core English patch"
        '
        'tsmUninstallLargeFiles
        '
        Me.tsmUninstallLargeFiles.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.subtab
        Me.tsmUninstallLargeFiles.ForeColor = System.Drawing.Color.White
        Me.tsmUninstallLargeFiles.Name = "tsmUninstallLargeFiles"
        Me.tsmUninstallLargeFiles.Size = New System.Drawing.Size(215, 22)
        Me.tsmUninstallLargeFiles.Text = "English Large Files"
        Me.tsmUninstallLargeFiles.ToolTipText = "Uninstall the English large files patch"
        '
        'tsmUninstallStory
        '
        Me.tsmUninstallStory.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.subtab
        Me.tsmUninstallStory.ForeColor = System.Drawing.Color.White
        Me.tsmUninstallStory.Name = "tsmUninstallStory"
        Me.tsmUninstallStory.Size = New System.Drawing.Size(215, 22)
        Me.tsmUninstallStory.Text = "English Story Patch"
        Me.tsmUninstallStory.ToolTipText = "Uninstall the English story patch"
        '
        'tsmRevertECodes
        '
        Me.tsmRevertECodes.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.cmsback
        Me.tsmRevertECodes.ForeColor = System.Drawing.Color.White
        Me.tsmRevertECodes.Name = "tsmRevertECodes"
        Me.tsmRevertECodes.Size = New System.Drawing.Size(215, 22)
        Me.tsmRevertECodes.Text = "Revert E-Codes to JP"
        Me.tsmRevertECodes.ToolTipText = """Unpatch"" emergency codes/trials to be in Japanese"
        '
        'tsmRevertENNames
        '
        Me.tsmRevertENNames.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.cmsback
        Me.tsmRevertENNames.ForeColor = System.Drawing.Color.White
        Me.tsmRevertENNames.Name = "tsmRevertENNames"
        Me.tsmRevertENNames.Size = New System.Drawing.Size(215, 22)
        Me.tsmRevertENNames.Text = "Revert Enemy Names to JP"
        Me.tsmRevertENNames.ToolTipText = """Unpatch"" enemy names to be in Japanese"
        '
        'cmdTroubleshooting
        '
        Me.cmdTroubleshooting.BackgroundImage = CType(resources.GetObject("cmdTroubleshooting.BackgroundImage"), System.Drawing.Image)
        Me.cmdTroubleshooting.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAnalyzeInstall, Me.tsmCheckForDeletedOrEmptyFiles, Me.tsmCheckForOldOrMissingFiles, Me.tsmCheckForOldOrMissingFilesOldMethod, Me.tsmFixGameGuardErrors, Me.tsmFixPSO2EXEs, Me.tsmFixPSO2Permissions, Me.tsmOpenDiagnosticMenu, Me.tsmResetPSO2Settings, Me.tsmResetTweakerSettings, Me.tsmTerminatePSO2Process})
        Me.cmdTroubleshooting.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.cmdTroubleshooting.ForeColor = System.Drawing.Color.White
        Me.cmdTroubleshooting.Name = "cmdTroubleshooting"
        Me.cmdTroubleshooting.Size = New System.Drawing.Size(201, 22)
        Me.cmdTroubleshooting.Text = "Troubleshooting"
        '
        'tsmAnalyzeInstall
        '
        Me.tsmAnalyzeInstall.BackgroundImage = CType(resources.GetObject("tsmAnalyzeInstall.BackgroundImage"), System.Drawing.Image)
        Me.tsmAnalyzeInstall.ForeColor = System.Drawing.Color.White
        Me.tsmAnalyzeInstall.Name = "tsmAnalyzeInstall"
        Me.tsmAnalyzeInstall.Size = New System.Drawing.Size(293, 22)
        Me.tsmAnalyzeInstall.Text = "Analyze Install for Issues"
        Me.tsmAnalyzeInstall.ToolTipText = "Analyze your installation for missing files or folders"
        '
        'tsmCheckForDeletedOrEmptyFiles
        '
        Me.tsmCheckForDeletedOrEmptyFiles.BackgroundImage = CType(resources.GetObject("tsmCheckForDeletedOrEmptyFiles.BackgroundImage"), System.Drawing.Image)
        Me.tsmCheckForDeletedOrEmptyFiles.ForeColor = System.Drawing.Color.White
        Me.tsmCheckForDeletedOrEmptyFiles.Name = "tsmCheckForDeletedOrEmptyFiles"
        Me.tsmCheckForDeletedOrEmptyFiles.Size = New System.Drawing.Size(293, 22)
        Me.tsmCheckForDeletedOrEmptyFiles.Text = "Check for Deleted/Empty Files"
        Me.tsmCheckForDeletedOrEmptyFiles.ToolTipText = "Checks to see if any data files are non-existant"
        '
        'tsmCheckForOldOrMissingFiles
        '
        Me.tsmCheckForOldOrMissingFiles.BackgroundImage = CType(resources.GetObject("tsmCheckForOldOrMissingFiles.BackgroundImage"), System.Drawing.Image)
        Me.tsmCheckForOldOrMissingFiles.ForeColor = System.Drawing.Color.White
        Me.tsmCheckForOldOrMissingFiles.Name = "tsmCheckForOldOrMissingFiles"
        Me.tsmCheckForOldOrMissingFiles.Size = New System.Drawing.Size(293, 22)
        Me.tsmCheckForOldOrMissingFiles.Text = "Check for Old/Missing Files"
        Me.tsmCheckForOldOrMissingFiles.ToolTipText = "Checks for deleted files AND out-of-date files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "using the new QUANTUM method"
        '
        'tsmCheckForOldOrMissingFilesOldMethod
        '
        Me.tsmCheckForOldOrMissingFilesOldMethod.BackgroundImage = CType(resources.GetObject("tsmCheckForOldOrMissingFilesOldMethod.BackgroundImage"), System.Drawing.Image)
        Me.tsmCheckForOldOrMissingFilesOldMethod.ForeColor = System.Drawing.Color.White
        Me.tsmCheckForOldOrMissingFilesOldMethod.Name = "tsmCheckForOldOrMissingFilesOldMethod"
        Me.tsmCheckForOldOrMissingFilesOldMethod.Size = New System.Drawing.Size(293, 22)
        Me.tsmCheckForOldOrMissingFilesOldMethod.Text = "Check for Old/Missing Files (Old Method)"
        Me.tsmCheckForOldOrMissingFilesOldMethod.ToolTipText = "Checks for deleted files AND out-of-date files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "using the old updating method"
        '
        'tsmFixGameGuardErrors
        '
        Me.tsmFixGameGuardErrors.BackgroundImage = CType(resources.GetObject("tsmFixGameGuardErrors.BackgroundImage"), System.Drawing.Image)
        Me.tsmFixGameGuardErrors.ForeColor = System.Drawing.Color.White
        Me.tsmFixGameGuardErrors.Name = "tsmFixGameGuardErrors"
        Me.tsmFixGameGuardErrors.Size = New System.Drawing.Size(293, 22)
        Me.tsmFixGameGuardErrors.Text = "Fix Gameguard Errors"
        Me.tsmFixGameGuardErrors.ToolTipText = "Fixes numerous Gameguard issues and errors"
        '
        'tsmFixPSO2EXEs
        '
        Me.tsmFixPSO2EXEs.BackgroundImage = CType(resources.GetObject("tsmFixPSO2EXEs.BackgroundImage"), System.Drawing.Image)
        Me.tsmFixPSO2EXEs.ForeColor = System.Drawing.Color.White
        Me.tsmFixPSO2EXEs.Name = "tsmFixPSO2EXEs"
        Me.tsmFixPSO2EXEs.Size = New System.Drawing.Size(293, 22)
        Me.tsmFixPSO2EXEs.Text = "Fix PSO2 EXEs"
        Me.tsmFixPSO2EXEs.ToolTipText = "Re-downloads the PSO2 EXE files"
        '
        'tsmFixPSO2Permissions
        '
        Me.tsmFixPSO2Permissions.BackgroundImage = CType(resources.GetObject("tsmFixPSO2Permissions.BackgroundImage"), System.Drawing.Image)
        Me.tsmFixPSO2Permissions.ForeColor = System.Drawing.Color.White
        Me.tsmFixPSO2Permissions.Name = "tsmFixPSO2Permissions"
        Me.tsmFixPSO2Permissions.Size = New System.Drawing.Size(293, 22)
        Me.tsmFixPSO2Permissions.Text = "Fix PSO2 Permissions"
        Me.tsmFixPSO2Permissions.ToolTipText = "Fixes PSO2 Permission issues caused by Bill Gates"
        '
        'tsmOpenDiagnosticMenu
        '
        Me.tsmOpenDiagnosticMenu.BackgroundImage = CType(resources.GetObject("tsmOpenDiagnosticMenu.BackgroundImage"), System.Drawing.Image)
        Me.tsmOpenDiagnosticMenu.ForeColor = System.Drawing.Color.White
        Me.tsmOpenDiagnosticMenu.Name = "tsmOpenDiagnosticMenu"
        Me.tsmOpenDiagnosticMenu.Size = New System.Drawing.Size(293, 22)
        Me.tsmOpenDiagnosticMenu.Text = "Open Diagnostic Menu"
        Me.tsmOpenDiagnosticMenu.ToolTipText = "Opens a diagnostic menu to help with troubleshooting"
        '
        'tsmResetPSO2Settings
        '
        Me.tsmResetPSO2Settings.BackgroundImage = CType(resources.GetObject("tsmResetPSO2Settings.BackgroundImage"), System.Drawing.Image)
        Me.tsmResetPSO2Settings.ForeColor = System.Drawing.Color.White
        Me.tsmResetPSO2Settings.Name = "tsmResetPSO2Settings"
        Me.tsmResetPSO2Settings.Size = New System.Drawing.Size(293, 22)
        Me.tsmResetPSO2Settings.Text = "Reset PSO2 Settings"
        Me.tsmResetPSO2Settings.ToolTipText = "Resets your PSO2 Settings to default"
        '
        'tsmResetTweakerSettings
        '
        Me.tsmResetTweakerSettings.BackgroundImage = CType(resources.GetObject("tsmResetTweakerSettings.BackgroundImage"), System.Drawing.Image)
        Me.tsmResetTweakerSettings.ForeColor = System.Drawing.Color.White
        Me.tsmResetTweakerSettings.Name = "tsmResetTweakerSettings"
        Me.tsmResetTweakerSettings.Size = New System.Drawing.Size(293, 22)
        Me.tsmResetTweakerSettings.Text = "Reset Tweaker Settings"
        Me.tsmResetTweakerSettings.ToolTipText = "Resets your PSO2 Tweaker settings to default"
        '
        'tsmTerminatePSO2Process
        '
        Me.tsmTerminatePSO2Process.BackgroundImage = CType(resources.GetObject("tsmTerminatePSO2Process.BackgroundImage"), System.Drawing.Image)
        Me.tsmTerminatePSO2Process.ForeColor = System.Drawing.Color.White
        Me.tsmTerminatePSO2Process.Name = "tsmTerminatePSO2Process"
        Me.tsmTerminatePSO2Process.Size = New System.Drawing.Size(293, 22)
        Me.tsmTerminatePSO2Process.Text = "Terminate PSO2 Process"
        Me.tsmTerminatePSO2Process.ToolTipText = "Attempts to terminate PSO2's process"
        '
        'cmsOtherTasks
        '
        Me.cmsOtherTasks.BackgroundImage = CType(resources.GetObject("cmsOtherTasks.BackgroundImage"), System.Drawing.Image)
        Me.cmsOtherTasks.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmStartChromeInCompatibilityMode, Me.tsmConfigureTelepipeProxy, Me.tsmRevertSettingsToJP, Me.tsmClearSymbolArtCache, Me.tsmInstallPSO2})
        Me.cmsOtherTasks.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.cmsOtherTasks.ForeColor = System.Drawing.Color.White
        Me.cmsOtherTasks.Name = "cmsOtherTasks"
        Me.cmsOtherTasks.Size = New System.Drawing.Size(201, 22)
        Me.cmsOtherTasks.Text = "Other Tasks"
        '
        'tsmStartChromeInCompatibilityMode
        '
        Me.tsmStartChromeInCompatibilityMode.BackgroundImage = CType(resources.GetObject("tsmStartChromeInCompatibilityMode.BackgroundImage"), System.Drawing.Image)
        Me.tsmStartChromeInCompatibilityMode.ForeColor = System.Drawing.Color.White
        Me.tsmStartChromeInCompatibilityMode.Name = "tsmStartChromeInCompatibilityMode"
        Me.tsmStartChromeInCompatibilityMode.Size = New System.Drawing.Size(312, 22)
        Me.tsmStartChromeInCompatibilityMode.Text = "Launch Chrome in PSO2 Compatibility Mode"
        Me.tsmStartChromeInCompatibilityMode.ToolTipText = "Launches Chrome without the built-in sandbox feature"
        '
        'tsmConfigureTelepipeProxy
        '
        Me.tsmConfigureTelepipeProxy.BackgroundImage = CType(resources.GetObject("tsmConfigureTelepipeProxy.BackgroundImage"), System.Drawing.Image)
        Me.tsmConfigureTelepipeProxy.ForeColor = System.Drawing.Color.White
        Me.tsmConfigureTelepipeProxy.Name = "tsmConfigureTelepipeProxy"
        Me.tsmConfigureTelepipeProxy.Size = New System.Drawing.Size(312, 22)
        Me.tsmConfigureTelepipeProxy.Text = "Configure Telepipe/PSO2Proxy settings"
        Me.tsmConfigureTelepipeProxy.ToolTipText = "Configure and set up your Telepipe/PSO2Proxy stuff here"
        '
        'tsmRevertSettingsToJP
        '
        Me.tsmRevertSettingsToJP.BackgroundImage = CType(resources.GetObject("tsmRevertSettingsToJP.BackgroundImage"), System.Drawing.Image)
        Me.tsmRevertSettingsToJP.ForeColor = System.Drawing.Color.White
        Me.tsmRevertSettingsToJP.Name = "tsmRevertSettingsToJP"
        Me.tsmRevertSettingsToJP.Size = New System.Drawing.Size(312, 22)
        Me.tsmRevertSettingsToJP.Text = "Revert PSO2Proxy Settings to JP"
        Me.tsmRevertSettingsToJP.ToolTipText = "Reverts your Telepipe/PSO2Proxy settings back to the original non-proxied setting" &
    "s"
        '
        'tsmClearSymbolArtCache
        '
        Me.tsmClearSymbolArtCache.BackgroundImage = CType(resources.GetObject("tsmClearSymbolArtCache.BackgroundImage"), System.Drawing.Image)
        Me.tsmClearSymbolArtCache.ForeColor = System.Drawing.Color.White
        Me.tsmClearSymbolArtCache.Name = "tsmClearSymbolArtCache"
        Me.tsmClearSymbolArtCache.Size = New System.Drawing.Size(312, 22)
        Me.tsmClearSymbolArtCache.Text = "Clear Symbol Art Cache"
        Me.tsmClearSymbolArtCache.ToolTipText = "Clears out your Symbol Art Cache"
        '
        'tsmInstallPSO2
        '
        Me.tsmInstallPSO2.BackgroundImage = CType(resources.GetObject("tsmInstallPSO2.BackgroundImage"), System.Drawing.Image)
        Me.tsmInstallPSO2.ForeColor = System.Drawing.Color.White
        Me.tsmInstallPSO2.Name = "tsmInstallPSO2"
        Me.tsmInstallPSO2.Size = New System.Drawing.Size(312, 22)
        Me.tsmInstallPSO2.Text = "Install Phantasy Star Online 2"
        Me.tsmInstallPSO2.ToolTipText = "Begins the installation process for the game"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(198, 6)
        '
        'tsmCheckForPSO2UpdatesWithQuantum
        '
        Me.tsmCheckForPSO2UpdatesWithQuantum.BackgroundImage = CType(resources.GetObject("tsmCheckForPSO2UpdatesWithQuantum.BackgroundImage"), System.Drawing.Image)
        Me.tsmCheckForPSO2UpdatesWithQuantum.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.tsmCheckForPSO2UpdatesWithQuantum.ForeColor = System.Drawing.Color.White
        Me.tsmCheckForPSO2UpdatesWithQuantum.Name = "tsmCheckForPSO2UpdatesWithQuantum"
        Me.tsmCheckForPSO2UpdatesWithQuantum.Size = New System.Drawing.Size(201, 22)
        Me.tsmCheckForPSO2UpdatesWithQuantum.Text = "Check for PSO2 Updates"
        Me.tsmCheckForPSO2UpdatesWithQuantum.ToolTipText = "This will check for any files that need to be updated"
        '
        'tsmCheckForPrePatchData
        '
        Me.tsmCheckForPrePatchData.BackgroundImage = CType(resources.GetObject("tsmCheckForPrePatchData.BackgroundImage"), System.Drawing.Image)
        Me.tsmCheckForPrePatchData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsmCheckForPrePatchData.ForeColor = System.Drawing.Color.White
        Me.tsmCheckForPrePatchData.Name = "tsmCheckForPrePatchData"
        Me.tsmCheckForPrePatchData.Size = New System.Drawing.Size(201, 22)
        Me.tsmCheckForPrePatchData.Text = "Check for Pre-Patch data"
        Me.tsmCheckForPrePatchData.ToolTipText = "Checks to see if there are any pre-patches available"
        '
        'btnTelepipe
        '
        Me.btnTelepipe.AutoSize = True
        Me.btnTelepipe.BackColor = System.Drawing.Color.Transparent
        Me.btnTelepipe.BackgroundImage = CType(resources.GetObject("btnTelepipe.BackgroundImage"), System.Drawing.Image)
        Me.btnTelepipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTelepipe.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTelepipe.FlatAppearance.BorderSize = 0
        Me.btnTelepipe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnTelepipe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnTelepipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTelepipe.Location = New System.Drawing.Point(899, 413)
        Me.btnTelepipe.Name = "btnTelepipe"
        Me.btnTelepipe.Size = New System.Drawing.Size(64, 64)
        Me.btnTelepipe.TabIndex = 35
        Me.TT.SetToolTip(Me.btnTelepipe, "Click to visit the Telepipe Proxy's homepage!")
        Me.btnTelepipe.UseVisualStyleBackColor = False
        '
        'btnVisiphoneShortcut
        '
        Me.btnVisiphoneShortcut.BackColor = System.Drawing.Color.Transparent
        Me.btnVisiphoneShortcut.BackgroundImage = CType(resources.GetObject("btnVisiphoneShortcut.BackgroundImage"), System.Drawing.Image)
        Me.btnVisiphoneShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVisiphoneShortcut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVisiphoneShortcut.FlatAppearance.BorderSize = 0
        Me.btnVisiphoneShortcut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnVisiphoneShortcut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnVisiphoneShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVisiphoneShortcut.Location = New System.Drawing.Point(899, 188)
        Me.btnVisiphoneShortcut.Name = "btnVisiphoneShortcut"
        Me.btnVisiphoneShortcut.Size = New System.Drawing.Size(64, 64)
        Me.btnVisiphoneShortcut.TabIndex = 36
        Me.TT.SetToolTip(Me.btnVisiphoneShortcut, "Click to visit the Arks-Visiphone, a PSO2 Wiki!")
        Me.btnVisiphoneShortcut.UseVisualStyleBackColor = False
        '
        'btnPSO2DiscordShortcut
        '
        Me.btnPSO2DiscordShortcut.BackColor = System.Drawing.Color.Transparent
        Me.btnPSO2DiscordShortcut.BackgroundImage = CType(resources.GetObject("btnPSO2DiscordShortcut.BackgroundImage"), System.Drawing.Image)
        Me.btnPSO2DiscordShortcut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPSO2DiscordShortcut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPSO2DiscordShortcut.FlatAppearance.BorderSize = 0
        Me.btnPSO2DiscordShortcut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPSO2DiscordShortcut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPSO2DiscordShortcut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPSO2DiscordShortcut.Location = New System.Drawing.Point(899, 263)
        Me.btnPSO2DiscordShortcut.Name = "btnPSO2DiscordShortcut"
        Me.btnPSO2DiscordShortcut.Size = New System.Drawing.Size(64, 64)
        Me.btnPSO2DiscordShortcut.TabIndex = 37
        Me.TT.SetToolTip(Me.btnPSO2DiscordShortcut, "Click to join the PSO2 Discord server!")
        Me.btnPSO2DiscordShortcut.UseVisualStyleBackColor = False
        '
        'btnPlugins
        '
        Me.btnPlugins.BackColor = System.Drawing.Color.Transparent
        Me.btnPlugins.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.medium_button_normal
        Me.btnPlugins.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnPlugins.FlatAppearance.BorderSize = 0
        Me.btnPlugins.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPlugins.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPlugins.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlugins.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlugins.ForeColor = System.Drawing.Color.White
        Me.btnPlugins.Location = New System.Drawing.Point(88, 395)
        Me.btnPlugins.Name = "btnPlugins"
        Me.btnPlugins.Size = New System.Drawing.Size(171, 40)
        Me.btnPlugins.TabIndex = 38
        Me.btnPlugins.Text = "Plugin Settings"
        Me.TT.SetToolTip(Me.btnPlugins, "Configure plugins to add various extra features to the game")
        Me.btnPlugins.UseVisualStyleBackColor = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(355, 44)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(529, 336)
        Me.WebBrowser1.TabIndex = 39
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblAppVersion
        '
        Me.lblAppVersion.AutoSize = True
        Me.lblAppVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblAppVersion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppVersion.ForeColor = System.Drawing.Color.Gold
        Me.lblAppVersion.Location = New System.Drawing.Point(3, 633)
        Me.lblAppVersion.Name = "lblAppVersion"
        Me.lblAppVersion.Size = New System.Drawing.Size(40, 14)
        Me.lblAppVersion.TabIndex = 42
        Me.lblAppVersion.Text = "1.2.3.4"
        '
        'lblDefaults
        '
        Me.lblDefaults.Location = New System.Drawing.Point(172, 167)
        Me.lblDefaults.Name = "lblDefaults"
        Me.lblDefaults.Size = New System.Drawing.Size(10, 10)
        Me.lblDefaults.TabIndex = 43
        Me.lblDefaults.Text = resources.GetString("lblDefaults.Text")
        Me.lblDefaults.Visible = False
        '
        'lblShipStatus
        '
        Me.lblShipStatus.AutoSize = True
        Me.lblShipStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblShipStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipStatus.ForeColor = System.Drawing.Color.Red
        Me.lblShipStatus.Location = New System.Drawing.Point(809, 633)
        Me.lblShipStatus.Name = "lblShipStatus"
        Me.lblShipStatus.Size = New System.Drawing.Size(161, 14)
        Me.lblShipStatus.TabIndex = 44
        Me.lblShipStatus.Text = "ERROR RETRIEVING SHIP INFO"
        Me.lblShipStatus.Visible = False
        '
        'txtPSO2DefaultINI
        '
        Me.txtPSO2DefaultINI.Location = New System.Drawing.Point(172, 167)
        Me.txtPSO2DefaultINI.Multiline = True
        Me.txtPSO2DefaultINI.Name = "txtPSO2DefaultINI"
        Me.txtPSO2DefaultINI.Size = New System.Drawing.Size(10, 10)
        Me.txtPSO2DefaultINI.TabIndex = 45
        Me.txtPSO2DefaultINI.Text = resources.GetString("txtPSO2DefaultINI.Text")
        Me.txtPSO2DefaultINI.Visible = False
        '
        'tmrWaitingforPSO2
        '
        Me.tmrWaitingforPSO2.Interval = 180000
        Me.tmrWaitingforPSO2.Tag = ""
        '
        'TT
        '
        Me.TT.AutomaticDelay = 0
        Me.TT.AutoPopDelay = 32000
        Me.TT.InitialDelay = 0
        Me.TT.IsBalloon = True
        Me.TT.ReshowDelay = 96
        Me.TT.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.TT.ToolTipTitle = "Information"
        '
        'lblShipEQ
        '
        Me.lblShipEQ.AutoSize = True
        Me.lblShipEQ.BackColor = System.Drawing.Color.Transparent
        Me.lblShipEQ.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipEQ.ForeColor = System.Drawing.Color.Red
        Me.lblShipEQ.Location = New System.Drawing.Point(347, 633)
        Me.lblShipEQ.Name = "lblShipEQ"
        Me.lblShipEQ.Size = New System.Drawing.Size(151, 14)
        Me.lblShipEQ.TabIndex = 46
        Me.lblShipEQ.Text = "ERROR RETRIEVING EQ INFO"
        Me.lblShipEQ.Visible = False
        '
        'frmMainv2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.PSO2TweakerVer2.My.Resources.Resources.background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(975, 653)
        Me.Controls.Add(Me.lblShipEQ)
        Me.Controls.Add(Me.lblShipStatus)
        Me.Controls.Add(Me.lblAppVersion)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.btnPlugins)
        Me.Controls.Add(Me.btnPSO2DiscordShortcut)
        Me.Controls.Add(Me.btnVisiphoneShortcut)
        Me.Controls.Add(Me.btnTelepipe)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.rtbDebug)
        Me.Controls.Add(Me.btnBumpedDonate)
        Me.Controls.Add(Me.btnBumpedShortcut)
        Me.Controls.Add(Me.btnALDonate)
        Me.Controls.Add(Me.btnPSOWShortcut)
        Me.Controls.Add(Me.btnALShortcut)
        Me.Controls.Add(Me.btnStartPSO2)
        Me.Controls.Add(Me.btnTweakerSettings)
        Me.Controls.Add(Me.btnTweaks)
        Me.Controls.Add(Me.btnPSO2Settings)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.btnMainMinimize)
        Me.Controls.Add(Me.btnMainClose)
        Me.Controls.Add(Me.btnTitle)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblDefaults)
        Me.Controls.Add(Me.txtPSO2DefaultINI)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMainv2"
        Me.Text = "`x"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTextBarOptions.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsORB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMainClose As System.Windows.Forms.Button
    Friend WithEvents btnMainMinimize As System.Windows.Forms.Button
    Friend WithEvents btnTitle As System.Windows.Forms.Button
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnPSO2Settings As System.Windows.Forms.Button
    Friend WithEvents btnTweaks As System.Windows.Forms.Button
    Friend WithEvents btnTweakerSettings As System.Windows.Forms.Button
    Friend WithEvents btnStartPSO2 As System.Windows.Forms.Button
    Friend WithEvents btnALShortcut As System.Windows.Forms.Button
    Friend WithEvents btnPSOWShortcut As System.Windows.Forms.Button
    Friend WithEvents btnALDonate As System.Windows.Forms.Button
    Friend WithEvents btnBumpedShortcut As System.Windows.Forms.Button
    Friend WithEvents btnBumpedDonate As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rtbDebug As System.Windows.Forms.RichTextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmsORB As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsSelectFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInstallUpdatePatches As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsUninstallPatches As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsRestoreBackups As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdTroubleshooting As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInstallEnglishPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInstallEnglishLargeFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInstallEnglishStoryPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInstallGermanPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInstallRussianPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUninstallEnglishPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUninstallLargeFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmUninstallStory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestoreEnglishPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestoreLargeFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmRestoreStoryPatch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAnalyzeInstall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCheckForDeletedOrEmptyFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCheckForOldOrMissingFiles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCheckForOldOrMissingFilesOldMethod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFixGameGuardErrors As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFixPSO2EXEs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFixPSO2Permissions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmResetPSO2Settings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmResetTweakerSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTerminatePSO2Process As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmCheckForPSO2UpdatesWithQuantum As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTelepipe As Button
    Friend WithEvents btnVisiphoneShortcut As Button
    Friend WithEvents btnPSO2DiscordShortcut As Button
    Friend WithEvents cmsOtherTasks As ToolStripMenuItem
    Friend WithEvents tsmCheckForPrePatchData As ToolStripMenuItem
    Friend WithEvents btnPlugins As Button
    Friend WithEvents cmsInstallFrenchPatch As ToolStripMenuItem
    Friend WithEvents tsmInstallRussianLargeFiles As ToolStripMenuItem
    Friend WithEvents InstallSpanishPatch As ToolStripMenuItem
    Friend WithEvents tsmRevertECodes As ToolStripMenuItem
    Friend WithEvents tsmRevertENNames As ToolStripMenuItem
    Friend WithEvents tsmOpenDiagnosticMenu As ToolStripMenuItem
    Friend WithEvents tsmStartChromeInCompatibilityMode As ToolStripMenuItem
    Friend WithEvents tsmConfigureTelepipeProxy As ToolStripMenuItem
    Friend WithEvents tsmRevertSettingsToJP As ToolStripMenuItem
    Friend WithEvents tsmClearSymbolArtCache As ToolStripMenuItem
    Friend WithEvents tsmInstallPSO2 As ToolStripMenuItem
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents lblAppVersion As Label
    Friend WithEvents lblDefaults As Label
    Friend WithEvents lblShipStatus As Label
    Friend WithEvents txtPSO2DefaultINI As TextBox
    Friend WithEvents tmrWaitingforPSO2 As Timer
    Friend WithEvents cmsTextBarOptions As ContextMenuStrip
    Friend WithEvents CopyAllTextToClipboardToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TT As ToolTip
    Friend WithEvents lblShipEQ As Label
End Class
