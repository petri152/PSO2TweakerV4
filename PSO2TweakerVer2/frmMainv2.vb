Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Imports System.IO
Imports PSO2TweakerVer2.VEDA
Imports PSO2TweakerVer2.My
Imports PSO2TweakerVer2.Helper
Imports AutoUpdaterDotNET
Imports Microsoft.VisualBasic.FileIO
Imports ArksLayer.Tweaker.Abstractions
Imports System.Net
Imports ArksLayer.Tweaker.UpdateEngine
Imports System.Threading
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports SharpCompress.Archive
Imports SharpCompress.Common
Imports SharpCompress.Reader
Imports Microsoft.Win32

Public Class frmMainv2
    'PSO2 Tweaker version 2 - Programmed by AIDA
    'Layout designed by Gama

    'Some variables for dragging the form
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Private Shared PFC As PrivateFontCollection
    Private Shared NewFont_FF As FontFamily

    ReadOnly _myDocuments As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)

    Dim _cancelled As Boolean
    Dim _cancelledFull As Boolean
    Dim _totalsize2 As Long
    Dim _restartplz As Boolean
    Dim NewInstall As Boolean = False
    Friend WithEvents Downloader As New WebClient
#Region "Layout stuff"
    Private Sub btnMainClose_Click(sender As Object, e As EventArgs) Handles btnMainClose.Click
        'Closing the form, duh
        Me.Close()
        End
    End Sub

    Private Sub btnMainClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMainClose.MouseDown
        btnMainClose.BackgroundImage = My.Resources.close_press
    End Sub

    Private Sub btnMainClose_MouseHover(sender As Object, e As EventArgs) Handles btnMainClose.MouseHover
        btnMainClose.BackgroundImage = My.Resources.close_hover
    End Sub

    Private Sub btnMainClose_MouseLeave(sender As Object, e As EventArgs) Handles btnMainClose.MouseLeave
        btnMainClose.BackgroundImage = My.Resources.close_normal
    End Sub

    Private Sub btnMainMinimize_MouseDown(sender As Object, e As EventArgs) Handles btnMainMinimize.MouseDown
        btnMainMinimize.BackgroundImage = My.Resources.minimize_press
    End Sub

    Private Sub btnMainMinimize_MouseHover(sender As Object, e As EventArgs) Handles btnMainMinimize.MouseHover
        btnMainMinimize.BackgroundImage = My.Resources.minimize_hover
    End Sub

    Private Sub btnMainMinimize_MouseLeave(sender As Object, e As EventArgs) Handles btnMainMinimize.MouseLeave
        btnMainMinimize.BackgroundImage = My.Resources.minimize_normal
    End Sub

    Private Sub btnTitle_MouseDown(sender As Object, e As MouseEventArgs) Handles btnTitle.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub btnTitle_MouseMove(sender As Object, e As MouseEventArgs) Handles btnTitle.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub btnTitle_MouseUp(sender As Object, e As MouseEventArgs) Handles btnTitle.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub btnGraphicSettings_MouseDown(sender As Object, e As EventArgs) Handles btnPSO2Settings.MouseDown
        btnPSO2Settings.BackgroundImage = My.Resources.medium_button_press
    End Sub

    Private Sub btnGraphicSettings_MouseHover(sender As Object, e As EventArgs) Handles btnPSO2Settings.MouseHover
        btnPSO2Settings.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnGraphicSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnPSO2Settings.MouseLeave
        btnPSO2Settings.BackgroundImage = My.Resources.medium_button_normal
    End Sub

    Private Sub btnMainMinimize_Click(sender As Object, e As EventArgs) Handles btnMainMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btnTweaks_MouseDown(sender As Object, e As MouseEventArgs) Handles btnTweaks.MouseDown
        btnTweaks.BackgroundImage = My.Resources.medium_button_press
    End Sub

    Private Sub btnTweaks_MouseHover(sender As Object, e As EventArgs) Handles btnTweaks.MouseHover
        btnTweaks.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnTweaks_MouseLeave(sender As Object, e As EventArgs) Handles btnTweaks.MouseLeave
        btnTweaks.BackgroundImage = My.Resources.medium_button_normal
    End Sub

    Private Sub btnTweaks_MouseMove(sender As Object, e As MouseEventArgs) Handles btnTweaks.MouseMove
        btnTweaks.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnGraphicSettings_MouseMove(sender As Object, e As MouseEventArgs) Handles btnPSO2Settings.MouseMove
        btnPSO2Settings.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnMainMinimize_MouseMove(sender As Object, e As MouseEventArgs) Handles btnMainMinimize.MouseMove
        btnMainMinimize.BackgroundImage = My.Resources.minimize_hover
    End Sub

    Private Sub btnMainClose_MouseMove(sender As Object, e As MouseEventArgs) Handles btnMainClose.MouseMove
        btnMainClose.BackgroundImage = My.Resources.close_hover
    End Sub

    Private Sub btnGraphicSettings_Click(sender As Object, e As EventArgs) Handles btnPSO2Settings.Click
        frmPSO2Settingsv2.Location = Me.DesktopLocation
        Me.Visible = False
        frmPSO2Settingsv2.ShowDialog()
    End Sub

    Private Sub btnTweakerSettings_Click(sender As Object, e As EventArgs) Handles btnTweakerSettings.Click
        'frmOptions.DesktopLocation = Me.DesktopLocation
        frmOptionsv2.Location = Me.DesktopLocation
        Me.Visible = False
        frmOptionsv2.ShowDialog()
    End Sub

    Private Sub btnTweakerSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnTweakerSettings.MouseDown
        btnTweakerSettings.BackgroundImage = My.Resources.medium_button_press
    End Sub

    Private Sub btnTweakerSettings_MouseHover(sender As Object, e As EventArgs) Handles btnTweakerSettings.MouseHover
        btnTweakerSettings.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnTweakerSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnTweakerSettings.MouseLeave
        btnTweakerSettings.BackgroundImage = My.Resources.medium_button_normal
    End Sub

    Private Sub btnTweakerSettings_MouseMove(sender As Object, e As MouseEventArgs) Handles btnTweakerSettings.MouseMove
        btnTweakerSettings.BackgroundImage = My.Resources.medium_button_hover
    End Sub
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Private Sub btnStartPSO2_MouseDown(sender As Object, e As MouseEventArgs) Handles btnStartPSO2.MouseDown
        btnStartPSO2.BackgroundImage = My.Resources.big_button_press
    End Sub

    Private Sub btnStartPSO2_MouseHover(sender As Object, e As EventArgs) Handles btnStartPSO2.MouseHover
        btnStartPSO2.BackgroundImage = My.Resources.big_button_hover
    End Sub

    Private Sub btnStartPSO2_MouseLeave(sender As Object, e As EventArgs) Handles btnStartPSO2.MouseLeave
        btnStartPSO2.BackgroundImage = My.Resources.big_button_normal
    End Sub

    Private Sub btnStartPSO2_MouseMove(sender As Object, e As MouseEventArgs) Handles btnStartPSO2.MouseMove
        btnStartPSO2.BackgroundImage = My.Resources.big_button_hover
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnALShortcut_Click(sender As Object, e As EventArgs) Handles btnALShortcut.Click
        Process.Start("http://arks-layer.com")
    End Sub

    Private Sub btnALShortcut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnALShortcut.MouseDown
        btnALShortcut.BackgroundImage = My.Resources.Alayer_press
    End Sub

    Private Sub btnALShortcut_MouseHover(sender As Object, e As EventArgs) Handles btnALShortcut.MouseHover
        btnALShortcut.BackgroundImage = My.Resources.Alayer_hover
    End Sub

    Private Sub btnALShortcut_MouseLeave(sender As Object, e As EventArgs) Handles btnALShortcut.MouseLeave
        btnALShortcut.BackgroundImage = My.Resources.Alayer
    End Sub

    Private Sub btnALShortcut_MouseMove(sender As Object, e As MouseEventArgs) Handles btnALShortcut.MouseMove
        btnALShortcut.BackgroundImage = My.Resources.Alayer_hover
    End Sub

    Private Sub btnPSOWShortcut_Click(sender As Object, e As EventArgs) Handles btnPSOWShortcut.Click
        Process.Start("http://www.pso-world.com")
    End Sub

    Private Sub btnPSOWShortcut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnPSOWShortcut.MouseDown
        btnPSOWShortcut.BackgroundImage = My.Resources.psow_press
    End Sub

    Private Sub btnPSOWShortcut_MouseHover(sender As Object, e As EventArgs) Handles btnPSOWShortcut.MouseHover
        btnPSOWShortcut.BackgroundImage = My.Resources.psow_hover
    End Sub

    Private Sub btnPSOWShortcut_MouseLeave(sender As Object, e As EventArgs) Handles btnPSOWShortcut.MouseLeave
        btnPSOWShortcut.BackgroundImage = My.Resources.psow
    End Sub

    Private Sub btnPSOWShortcut_MouseMove(sender As Object, e As MouseEventArgs) Handles btnPSOWShortcut.MouseMove
        btnPSOWShortcut.BackgroundImage = My.Resources.psow_hover
    End Sub

    Private Sub btnALDonate_Click(sender As Object, e As EventArgs) Handles btnALDonate.Click
        Process.Start("http://arks-layer.com/donate.php")
    End Sub

    Private Sub btnALDonate_MouseDown(sender As Object, e As MouseEventArgs) Handles btnALDonate.MouseDown
        btnALDonate.BackgroundImage = My.Resources.layerdon2
    End Sub

    Private Sub btnALDonate_MouseHover(sender As Object, e As EventArgs) Handles btnALDonate.MouseHover
        btnALDonate.BackgroundImage = My.Resources.layerdon1
    End Sub

    Private Sub btnALDonate_MouseLeave(sender As Object, e As EventArgs) Handles btnALDonate.MouseLeave
        btnALDonate.BackgroundImage = My.Resources.layerdon0
    End Sub

    Private Sub btnALDonate_MouseMove(sender As Object, e As MouseEventArgs) Handles btnALDonate.MouseMove
        btnALDonate.BackgroundImage = My.Resources.layerdon1
    End Sub
    Private Sub btnBumpedShortcut_Click(sender As Object, e As EventArgs) Handles btnBumpedShortcut.Click
        Process.Start("http://bumped.org/psublog/")
    End Sub

    Private Sub btnBumpedShortcut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBumpedShortcut.MouseDown
        btnBumpedShortcut.BackgroundImage = My.Resources.bumped_press
    End Sub

    Private Sub btnBumpedShortcut_MouseHover(sender As Object, e As EventArgs) Handles btnBumpedShortcut.MouseHover
        btnBumpedShortcut.BackgroundImage = My.Resources.bumped_hover
    End Sub

    Private Sub btnBumpedShortcut_MouseLeave(sender As Object, e As EventArgs) Handles btnBumpedShortcut.MouseLeave
        btnBumpedShortcut.BackgroundImage = My.Resources.bumped
    End Sub

    Private Sub btnBumpedShortcut_MouseMove(sender As Object, e As MouseEventArgs) Handles btnBumpedShortcut.MouseMove
        btnBumpedShortcut.BackgroundImage = My.Resources.bumped_hover
    End Sub

    Private Sub btnBumpedDonate_Click(sender As Object, e As EventArgs) Handles btnBumpedDonate.Click
        Process.Start("http://bumped.org/psublog/about/")
    End Sub

    Private Sub btnBumpedDonate_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBumpedDonate.MouseDown
        btnBumpedDonate.BackgroundImage = My.Resources.bumpdon2
    End Sub

    Private Sub btnBumpedDonate_MouseHover(sender As Object, e As EventArgs) Handles btnBumpedDonate.MouseHover
        btnBumpedDonate.BackgroundImage = My.Resources.bumpdon1
    End Sub

    Private Sub btnBumpedDonate_MouseLeave(sender As Object, e As EventArgs) Handles btnBumpedDonate.MouseLeave
        btnBumpedDonate.BackgroundImage = My.Resources.bumpdon0
    End Sub

    Private Sub btnBumpedDonate_MouseMove(sender As Object, e As MouseEventArgs) Handles btnBumpedDonate.MouseMove
        btnBumpedDonate.BackgroundImage = My.Resources.bumpdon1
    End Sub

    Private Sub btnTweaks_Click(sender As Object, e As EventArgs) Handles btnTweaks.Click
        frmTweaksv2.Location = Me.DesktopLocation
        Me.Visible = False
        frmTweaksv2.ShowDialog()
    End Sub


    Private Sub rtbDebug_TextChanged(sender As Object, e As EventArgs) Handles rtbDebug.TextChanged
        rtbDebug.SelectionStart = rtbDebug.Text.Length
    End Sub

    Private Sub cmsORB_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsORB.Opening

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'cmsORB.Location = New Point(Me.Location.X + 12, Me.Location.Y + 38)
        cmsORB.Show(New Point(Me.Location.X + 13, Me.Location.Y + 39 + 64))
        cmsORB.SendToBack()
        Button1.Show()
        'cmsORB.Location = New Point(Me.Location.X + 12, Me.Location.Y + 38)
    End Sub

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.__clicked
    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        If cmsORB.Visible = False Then Button1.BackgroundImage = My.Resources.__hover
        If cmsORB.Visible = True Then Button1.BackgroundImage = My.Resources.__clicked
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        If cmsORB.Visible = False Then Button1.BackgroundImage = My.Resources.__normal
        If cmsORB.Visible = True Then Button1.BackgroundImage = My.Resources.__clicked
    End Sub

    Private Sub Button1_MouseMove(sender As Object, e As MouseEventArgs) Handles Button1.MouseMove
        If cmsORB.Visible = False Then Button1.BackgroundImage = My.Resources.__hover
        If cmsORB.Visible = True Then Button1.BackgroundImage = My.Resources.__clicked
    End Sub

    Private Sub btnVisiphoneShortcut_Click(sender As Object, e As EventArgs) Handles btnVisiphoneShortcut.Click
        Process.Start("https://pso2.arks-visiphone.com/wiki/Main_Page")
    End Sub

    Private Sub btnVisiphoneShortcut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnVisiphoneShortcut.MouseDown
        btnVisiphoneShortcut.BackgroundImage = My.Resources.visio2
    End Sub

    Private Sub btnVisiphoneShortcut_MouseHover(sender As Object, e As EventArgs) Handles btnVisiphoneShortcut.MouseHover
        btnVisiphoneShortcut.BackgroundImage = My.Resources.visio1
    End Sub

    Private Sub btnVisiphoneShortcut_MouseLeave(sender As Object, e As EventArgs) Handles btnVisiphoneShortcut.MouseLeave
        btnVisiphoneShortcut.BackgroundImage = My.Resources.visio0
    End Sub

    Private Sub btnVisiphoneShortcut_MouseMove(sender As Object, e As MouseEventArgs) Handles btnVisiphoneShortcut.MouseMove
        btnVisiphoneShortcut.BackgroundImage = My.Resources.visio1
    End Sub

    Private Sub btnPSO2DiscordShortcut_Click(sender As Object, e As EventArgs) Handles btnPSO2DiscordShortcut.Click
        Process.Start("https://discord.gg/KYc3Jyn")
    End Sub

    Private Sub btnPSO2DiscordShortcut_MouseDown(sender As Object, e As MouseEventArgs) Handles btnPSO2DiscordShortcut.MouseDown
        btnPSO2DiscordShortcut.BackgroundImage = My.Resources.discor2
    End Sub

    Private Sub btnPSO2DiscordShortcut_MouseHover(sender As Object, e As EventArgs) Handles btnPSO2DiscordShortcut.MouseHover
        btnPSO2DiscordShortcut.BackgroundImage = My.Resources.dicor1
    End Sub

    Private Sub btnPSO2DiscordShortcut_MouseLeave(sender As Object, e As EventArgs) Handles btnPSO2DiscordShortcut.MouseLeave
        btnPSO2DiscordShortcut.BackgroundImage = My.Resources.dicor0
    End Sub

    Private Sub btnPSO2DiscordShortcut_MouseMove(sender As Object, e As MouseEventArgs) Handles btnPSO2DiscordShortcut.MouseMove
        btnPSO2DiscordShortcut.BackgroundImage = My.Resources.dicor1
    End Sub

    Private Sub btnTelepipe_Click(sender As Object, e As EventArgs) Handles btnTelepipe.Click
        Process.Start("http://telepipe.io")
    End Sub

    Private Sub btnTelepipe_MouseDown(sender As Object, e As MouseEventArgs) Handles btnTelepipe.MouseDown
        btnTelepipe.BackgroundImage = My.Resources.tp2
    End Sub

    Private Sub btnTelepipe_MouseHover(sender As Object, e As EventArgs) Handles btnTelepipe.MouseHover
        btnTelepipe.BackgroundImage = My.Resources.tp1
    End Sub

    Private Sub btnTelepipe_MouseLeave(sender As Object, e As EventArgs) Handles btnTelepipe.MouseLeave
        btnTelepipe.BackgroundImage = My.Resources.tp0
    End Sub

    Private Sub btnTelepipe_MouseMove(sender As Object, e As MouseEventArgs) Handles btnTelepipe.MouseMove
        btnTelepipe.BackgroundImage = My.Resources.tp1
    End Sub

    Private Sub btnPlugins_MouseDown(sender As Object, e As MouseEventArgs) Handles btnPlugins.MouseDown
        btnPlugins.BackgroundImage = My.Resources.medium_button_press
    End Sub

    Private Sub btnPlugins_MouseHover(sender As Object, e As EventArgs) Handles btnPlugins.MouseHover
        btnPlugins.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnPlugins_MouseLeave(sender As Object, e As EventArgs) Handles btnPlugins.MouseLeave
        btnPlugins.BackgroundImage = My.Resources.medium_button_normal
    End Sub

    Private Sub btnPlugins_MouseMove(sender As Object, e As MouseEventArgs) Handles btnPlugins.MouseMove
        btnPlugins.BackgroundImage = My.Resources.medium_button_hover
    End Sub
#End Region
#Region "RTB Debug stuff"
    Public Sub WriteDebugInfo(ByVal addThisText As String)
        Try
            If addThisText.Contains("PSO2 Tweaker ver ") Then Exit Sub
            If rtbDebug.InvokeRequired Then
                rtbDebug.Invoke(New Action(Of String)(AddressOf WriteDebugInfo), Text)
            Else
                rtbDebug.Text &= (vbCrLf & addThisText)
            End If
        Catch
        End Try
        File.AppendAllText(Program.StartPath & "\logfile.txt", DateTime.Now.ToString("G") & ": " & addThisText & vbCrLf)
    End Sub

    Public Sub WriteDebugInfoSameLine(ByVal addThisText As String)
        Try
            If rtbDebug.InvokeRequired Then
                rtbDebug.Invoke(New Action(Of String)(AddressOf WriteDebugInfoSameLine), Text)
            Else
                rtbDebug.Text &= (" " & addThisText)
            End If
        Catch
        End Try
        File.AppendAllText(Program.StartPath & "\logfile.txt", DateTime.Now.ToString("G") & ": " & addThisText & vbCrLf)
    End Sub

    Public Sub WriteDebugInfoAndOk(ByVal addThisText As String)
        File.AppendAllText(Program.StartPath & "\logfile.txt", DateTime.Now.ToString("G") & ": " & addThisText & " [OK!]" & vbCrLf)
        Try
            If rtbDebug.InvokeRequired Then
                rtbDebug.Invoke(New Action(Of String)(AddressOf WriteDebugInfoAndOk), Text)
            Else
                If addThisText.Contains("Program opened successfully! Version ") = True Then
                    rtbDebug.Text &= (addThisText)
                Else
                    rtbDebug.Text &= (vbCrLf & addThisText)
                End If
                rtbDebug.Select(rtbDebug.TextLength, 0)
                rtbDebug.SelectionColor = Color.Green
                rtbDebug.AppendText(" [OK!]")
                rtbDebug.SelectionColor = rtbDebug.ForeColor
            End If
        Catch
        End Try
    End Sub

    Public Sub WriteDebugInfoAndWarning(ByVal addThisText As String)
        Try
            If rtbDebug.InvokeRequired Then
                rtbDebug.Invoke(New Action(Of String)(AddressOf WriteDebugInfoAndWarning), Text)
            Else
                rtbDebug.Text &= (vbCrLf & addThisText)
                rtbDebug.Select(rtbDebug.TextLength, 0)
                rtbDebug.SelectionColor = Color.Red
                rtbDebug.AppendText(" [WARNING!]")
                rtbDebug.SelectionColor = rtbDebug.ForeColor
            End If
        Catch
        End Try
        File.AppendAllText(Program.StartPath & "\logfile.txt", DateTime.Now.ToString("G") & ": " & addThisText & " [WARNING!]" & vbCrLf)
    End Sub

    Public Sub WriteDebugInfoAndFailed(ByVal addThisText As String)
        Try
            If rtbDebug.InvokeRequired Then
                rtbDebug.Invoke(New Action(Of String)(AddressOf WriteDebugInfoAndFailed), Text)
            Else
                If addThisText = "ERROR - Index was outside the bounds of the array." Then Return
                If addThisText = "ERROR - Object reference not set to an instance of an object." Then Return
                rtbDebug.Text &= (vbCrLf & addThisText)
                rtbDebug.Select(rtbDebug.TextLength, 0)
                rtbDebug.SelectionColor = Color.Red
                rtbDebug.AppendText("FAILED")
                rtbDebug.SelectionColor = rtbDebug.ForeColor
            End If
        Catch
        End Try
        File.AppendAllText(Program.StartPath & "\logfile.txt", DateTime.Now.ToString("G") & ": " & addThisText & " [FAILED!]" & vbCrLf)
        If Convert.ToBoolean(Program.GetSetting("Pastebin")) Then
            Dim upload As MsgBoxResult = MsgBox("Something went wrong, would you like to upload your logfile so it can be fixed?", vbYesNo)
            If upload = MsgBoxResult.Yes Then
                PasteBinUpload()
            End If
        End If
    End Sub
#End Region

    Private Async Sub frmMainv2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Downloader.Headers("user-agent") = GetUserAgent()

        If Program.CloseMe = True Then
            MsgBox("All done! Please re-run the Tweaker.")
            Close()
        End If

        While Not Program.IsPso2Installed
            Dim installFolder As String = ""
            'Const installYesNo As MsgBoxResult = vbYes
            'If installYesNo = vbNo Then
            '    WriteDebugInfo("You can view more information about the installer at:" & vbCrLf & "http://arks-layer.com/setup.php")
            '    Return
            'End If
            'If installYesNo = vbYes Then
            MsgBox("This will install Phantasy Star Online EPISODE 4! Please select a folder to install into." & vbCrLf & "A folder called PHANTASYSTARONLINE2 will be created inside the folder you choose." & vbCrLf & "(For example, if you choose the C drive, it will install to C:\PHANTASYSTARONLINE2\)" & vbCrLf & "It is HIGHLY RECOMMENDED that you do NOT install into the Program Files folder, but a normal folder like C:\PHANTASYSTARONLINE\")
            Dim installPso2 As Boolean = True
            While installPso2
                Dim myFolderBrowser As New FolderBrowserDialog With {.RootFolder = Environment.SpecialFolder.MyComputer, .Description = "Please select a folder (or drive) to install PSO2 into"}
                Dim dlgResult As DialogResult = myFolderBrowser.ShowDialog()

                If dlgResult = DialogResult.OK Then
                    installFolder = myFolderBrowser.SelectedPath
                End If
                If dlgResult = DialogResult.Cancel Then
                    WriteDebugInfo("Installation cancelled by user!")
                    Return
                End If
                Dim correctYesNo As MsgBoxResult = MsgBox("You wish to install PSO2 into " & (installFolder & "\PHANTASYSTARONLINE2\. Is this correct?").Replace("\\", "\"), vbYesNoCancel)
                If correctYesNo = vbCancel Then
                    WriteDebugInfo("Installation cancelled by user!")
                    Return
                End If
                If correctYesNo = vbNo Then
                    Continue While
                End If
                If correctYesNo = vbYes Then
                    For Each drive In DriveInfo.GetDrives()
                        If (drive.DriveType = DriveType.Fixed) AndAlso (installFolder(0) = drive.Name(0)) Then
                            If drive.TotalSize < 42000000000 Then
                                MsgBox("There is not enough space on the selected disk to install PSO2. Please select a different drive. (Requires 41GB of free space)")
                                Continue While
                            End If
                            If drive.AvailableFreeSpace < 42000000000 Then
                                MsgBox("There is not enough free space on the selected disk to install PSO2. Please free up some space or select a different drive. (Requires 41GB of free space)")
                                Continue While
                            End If
                        End If
                    Next

                    Dim finalYesNo As MsgBoxResult = MsgBox("The program will now install the necessary files, create the folders, and set up the game. Afterwards, the program will automatically begin patching. Click ""OK"" to start.", MsgBoxStyle.OkCancel)
                    If finalYesNo = vbCancel Then
                        WriteDebugInfo("Installation cancelled by user!")
                    Else
                        'set the pso2Dir to the install patch
                        Program.PSO2RootDir = (installFolder & "\PHANTASYSTARONLINE2\pso2_bin").Replace("\\", "\")
                        Helper.DeleteFile("client.json")
                        WriteDebugInfoAndOk(("Program opened successfully! (Installing PSO2 variant) Version " & Application.Info.Version.ToString()))
                        lblAppVersion.Text = Application.Info.Version.ToString()
                        Dim remotejson As JObject = JObject.Parse(DownloadString("http://arks-layer.com/remote.json"))
                        Program.InfoURL = remotejson.SelectToken("InfoURL").ToString()
                        WebBrowser1.Navigate(Program.InfoURL)
                        Show()
                        Focus()
                        Application.DoEvents()
                        WriteDebugInfo("Downloading DirectX setup...")
                        Try
                            DownloadFile("http://arks-layer.com/docs/dxwebsetup.exe", "dxwebsetup.exe")
                            WriteDebugInfoSameLine("Done!")
                            WriteDebugInfo("Checking/Installing DirectX...")
                            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo() With {.FileName = "dxwebsetup.exe", .Verb = "runas", .Arguments = "/Q", .UseShellExecute = True}
                            Process.Start(processStartInfo).WaitForExit()
                            WriteDebugInfoSameLine("Done!")
                        Catch ex As Exception
                            WriteDebugInfo("DirectX installation failed! Please install it later if neccessary!")
                        End Try

                        If File.Exists("dxwebsetup.exe") Then File.Delete("dxwebsetup.exe")
                        'Make a data folder, and a win32 folder under that
                        Directory.CreateDirectory(Program.PSO2RootDir & "\data\win32\")
                        'Download required pso2 stuff
                        WriteDebugInfo("Downloading PSO2 required files...")
                        DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2launcher.exe.pat", Program.PSO2RootDir & "\pso2launcher.exe")
                        DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2updater.exe.pat", Program.PSO2RootDir & "\pso2updater.exe")
                        DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2.exe.pat", Program.PSO2RootDir & "\pso2.exe")
                        DownloadFile("http://download.pso2.jp/patch_prod/patches/PSO2JP.ini.pat", Program.PSO2RootDir & "\PSO2JP.ini")
                        WriteDebugInfoSameLine("Done!")
                        'Download Gameguard.des
                        WriteDebugInfo("Downloading Latest Gameguard file...")
                        DownloadFile("http://download.pso2.jp/patch_prod/patches/GameGuard.des.pat", Program.PSO2RootDir & "\GameGuard.des")
                        WriteDebugInfoSameLine("Done!")
                        Application.DoEvents()

                        If File.Exists(Program.AppData & "/PSO2 Tweaker/settings.json") = False Then File.WriteAllText(Program.AppData & "/PSO2 Tweaker/settings.json", lblDefaults.Text)

                        Program.SaveSetting("PSO2Dir", Program.PSO2RootDir)
                        WriteDebugInfo(Program.PSO2RootDir & " set as your PSO2 Directory.")
                        Program.PSO2WinDir = (Program.PSO2RootDir & "\data\win32")
                        If String.IsNullOrEmpty(Program.GetSetting("StoryPatchVersion")) Then Program.SaveSetting("StoryPatchVersion", "Not Installed")
                        If String.IsNullOrEmpty(Program.GetSetting("ENPatchVersion")) Then Program.SaveSetting("ENPatchVersion", "Not Installed")
                        If String.IsNullOrEmpty(Program.GetSetting("LargeFilesVersion")) Then Program.SaveSetting("LargeFilesVersion", "Not Installed")

                        RegKey.SetValue(Of String)("PSO2Dir", Program.GetSetting("PSO2Dir"))
                        ' Use IOC Container in the main Tweaker project to deal with dependencies.
                        'Dim output As New TweakerTrigger
                        'Dim Settings = New JsonTweakerSettings(Program.AppData & "/PSO2 Tweaker/settings.json")
                        'Dim updater = New UpdateManager(Settings, output)
                        'Dim SkipClient As New WebClient
                        'Helper.Log("Downloading the list of files to skip...")
                        'SkipClient.DownloadFile(Program.FreedomUrl & "skip.txt", "skip.txt")
                        'Await updater.CleanLegacyFiles()

                        'Console.WriteLine(settings.GameDirectory)
                        Try

                            'frmDownloader.TopMost = True
                            'Me.TopMost = False
                        Catch ex As Exception
                            Helper.LogWithException("Error - ", ex)
                        End Try
                        'frmDownloader.CleanupUI()
                        'Await updater.Update(True, False)
                        UpdatePSO2(False)

                        WriteDebugInfo("PSO2 successfully installed!")
                        Refresh()
                    End If
                End If

                installPso2 = False
                Program.IsPso2Installed = True
            End While
        End While

        'lblStatus.Text = ""

        _cancelledFull = False

        'Re-enable this if we do more BETAs in the future
        'If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.EnableBeta.ToString)) Then RegKey.SetValue(Of Boolean)(RegKey.EnableBeta, False)
        'Program.SaveSetting("EnableBeta", "False")

        'Here is what I will call our "idiot handling" code
        '
        If Program.StartPath.Contains(Helper.GetDownloadsPath()) Then
            MsgBox("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in the ""Downloads"" folder (or any folder inside of the ""Downloads"" folder). Please move it to it's own folder NOT IN THE DOWNLOADS FOLDER, like C:\Tweaker\")
            Helper.Log("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in the ""Downloads"" (or any folder inside of the ""Downloads"" folder) folder. Please move it to it's own folder NOT IN THE DOWNLOADS FOLDER, like C:\Tweaker\")
            Environment.Exit(0)
            Stop
        End If

        If Program.StartPath = Program.PSO2RootDir.Replace("\\", "\") Then
            MsgBox("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in the pso2_bin folder. Please move it to it's own folder, like C:\Tweaker\")
            Helper.Log("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in the pso2_bin folder. Please move it to it's own folder, like C:\Tweaker\")
            Environment.Exit(0)
            Stop
        End If
        If Program.StartPath.Contains(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) Then
            MsgBox("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in the ""My Documents"" folder (or any folder inside of the ""My Documents"" folder). Please move it to it's own folder NOT IN MY DOCUMENTS, like C:\Tweaker\")
            Helper.Log("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in the ""My Documents"" folder (or any folder inside of the ""My Documents"" folder). Please move it to it's own folder NOT IN MY DOCUMENTS, like C:\Tweaker\")
            Environment.Exit(0)
            End
        End If
        If Program.StartPath.Contains(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)) Then
            MsgBox("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while on the Desktop (or any folder on the Desktop). Please move it to it's own folder NOT ON THE DESKTOP, like C:\Tweaker\")
            Helper.Log("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while on the Desktop (or any folder on the Desktop). Please move it to it's own folder NOT ON THE DESKTOP, like C:\Tweaker\")
            Environment.Exit(0)
            End
        End If
        If Program.StartPath.Contains(Environment.GetFolderPath(Environment.SpecialFolder.Windows)) Then
            MsgBox("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in a special windows folder (or any folder inside of a special windows folder). Please move it to it's own folder NOT IN A SPECIAL WINDOWS FOLDER, like C:\Tweaker\")
            Helper.Log("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while in a special windows folder (or any folder inside of a special windows folder). Please move it to it's own folder NOT IN A SPECIAL WINDOWS FOLDER, like C:\Tweaker\")
            Environment.Exit(0)
            End
        End If
        If Program.StartPath = Path.GetPathRoot(Environment.SystemDirectory) Then
            MsgBox("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while on the root drive (" & Path.GetPathRoot(Environment.SystemDirectory) & "). Please move it to it's own folder, like C:\Tweaker\")
            Helper.Log("Please be aware - Due to various Windows issues, PSO2 Tweaker will not work correctly while on the root drive (" & Path.GetPathRoot(Environment.SystemDirectory) & "). Please move it to it's own folder, like C:\Tweaker\")
            Environment.Exit(0)
            End
        End If
        If Process.GetCurrentProcess().MainModule.ModuleName <> "PSO2 Tweaker.exe" And Process.GetCurrentProcess().MainModule.ModuleName <> "PSO2 Tweaker.vshost.exe" Then
            MsgBox("Your PSO2 Tweaker is named incorrectly. Please rename the program you just ran to ""PSO2 Tweaker.exe"" exactly, then run it again.")
            Helper.Log("Your PSO2 Tweaker is named incorrectly. Please rename the program you just ran to ""PSO2 Tweaker.exe"" exactly, then run it again.")
            Environment.Exit(0)
            End
        End If
        'string path = Path.GetPathRoot(Environment.SystemDirectory);
        Show()

        WriteDebugInfoAndOk(("Program opened successfully! Version " & Application.Info.Version.ToString()))
        lblAppVersion.Text = Application.Info.Version.ToString()

        WebBrowser1.Navigate(Program.InfoURL)
        AutoUpdater.Start(Program.FreedomUrl & "version2.xml")

        ThreadPool.QueueUserWorkItem(AddressOf GetShipStatus)

        ThreadPool.QueueUserWorkItem(AddressOf GetShipEQs)

        Try

            If String.IsNullOrEmpty(Program.GetSetting("PSO2Dir")) Or Program.GetSetting("PSO2Dir").Contains("ERROR GETTING VALUE") Then
                MsgBox("Please select your PSO2's pso2_bin Directory. It will be saved so you don't have to select it again.")
                Helper.SelectPso2Directory()
            Else
                If Program.GetSetting("PSO2Dir").EndsWith("\pso2_bin") Then
                    Program.PSO2RootDir = Program.GetSetting("PSO2Dir")
                Else
                    MsgBox("It appears your pso2_bin directory was set incorrectly. Please re-select your PSO2's pso2_bin Directory.")
                    Helper.SelectPso2Directory()
                End If
            End If

            Dim GNFieldMD5 As String = Program.GNFieldMD5


            If Program.GNFieldStatus = "Active" And Program.NoGNFieldMode = False Then
                'GN Field needs to be active
                Program.GNFieldActive = True
                If Process.GetProcessesByName("GN Field").Length > 0 Then
                    Helper.Log("GN Field detected, disabling!")
                    For Each proc As Process In Process.GetProcessesByName("GN Field")
                        proc.Kill()
                    Next
                End If
                If Not File.Exists("GN Field.exe") Then
                    WriteDebugInfo("Downloading " & "GN Field...")
                    Application.DoEvents()
                    DownloadFile(Program.FreedomUrl & "GN Field.exe", "GN Field.exe")
                End If

                For index = 1 To 5
                    If Helper.GetMd5("GN Field.exe") <> GNFieldMD5 And String.IsNullOrEmpty(GNFieldMD5) = False Then
                        WriteDebugInfo("Your GN Field appears to be corrupt or outdated, redownloading...")
                        Helper.Log("MD5 of current GN Field is " & Helper.GetMd5("GN Field.exe") & ", should have been " & GNFieldMD5 & ".")
                        Application.DoEvents()
                        DownloadFile(Program.FreedomUrl & "GN Field.exe", "GN Field.exe")
                    Else
                        Exit For
                    End If
                Next
            End If

            If Program.GNFieldStatus = "Random" And Program.NoGNFieldMode = False Then
                'GG trying to disable our GN Field. Time to boost it with ELS!
                Program.GNFieldActive = True
                Program.ELSActive = True
                Dim GNFieldName As String = GenerateELSName() & ".exe"
                Program.SaveSetting("GNFieldName", GNFieldName)
                If File.Exists("GN Field.exe") Then
                    WriteDebugInfo("Removing old GN Field and updating...")
                    Helper.DeleteFile("GN Field.exe")
                    Application.DoEvents()
                End If
                DownloadFile(Program.FreedomUrl & "GN Field.exe", GNFieldName)
                WriteDebugInfo("GN Field downloaded and renamed to " & GNFieldName & " to hide it from GG.")
                For index = 1 To 5
                    If Helper.GetMd5(GNFieldName) <> GNFieldMD5 Then
                        WriteDebugInfo("Your GN Field appears to be corrupt or outdated, redownloading...")
                        Application.DoEvents()
                        DownloadFile(Program.FreedomUrl & "GN Field.exe", GNFieldName)
                    Else
                        Exit For
                    End If
                Next
            End If

            If Program.GNFieldStatus = "Inactive" Then Program.GNFieldActive = False

            Helper.CheckIfOfficialLauncherRunning()

            Helper.DeleteDirectory("TEMPSTORYAIDAFOOL")
            Helper.DeleteFile("launcherlist.txt")
            Helper.DeleteFile("patchlist.txt")
            Helper.DeleteFile("patchlist_old.txt")
            Helper.DeleteFile("7za.exe")
            Helper.DeleteFile("UnRar.exe")

            'Added in precede files. Stupid ass SEGA.
            Helper.DeleteFile("patchlist0.txt")
            Helper.DeleteFile("patchlist1.txt")
            Helper.DeleteFile("patchlist2.txt")
            Helper.DeleteFile("patchlist3.txt")
            Helper.DeleteFile("patchlist4.txt")
            Helper.DeleteFile("patchlist5.txt")
            Helper.DeleteFile("precede.txt")
            Helper.DeleteFile("ServerConfig.txt")
            Helper.DeleteFile("precede_apply.txt")
            Helper.DeleteFile("version.ver")
            Helper.DeleteFile("Story MD5HashList.txt")
            Helper.DeleteFile("PluginMD5HashList.txt")
            Helper.DeleteFile("working.txt")
            Helper.DeleteFile("gnfieldstatus.txt")
            Helper.DeleteFile("gnfieldMD5.txt")
            Helper.DeleteFile("update.bat")
            Helper.DeleteFile("renameme_PSO2 Tweaker.exe")

            Try

                'Added in license file checking. Stupid ass SEGA (x2)
                If Directory.Exists(Program.PSO2RootDir & "\data\license\") Then 'If the license folder exists
                    'Make sure we have all 4 files
                    If File.Exists(Program.PSO2RootDir & "\data\license\boost.txt") = False Then DownloadFile(Program.FreedomUrl & "license/boost.txt", Program.PSO2RootDir & "\data\license\boost.txt")
                    If File.Exists(Program.PSO2RootDir & "\data\license\lua_license.txt") = False Then DownloadFile(Program.FreedomUrl & "license/lua_license.txt", Program.PSO2RootDir & "\data\license\lua_license.txt")
                    If File.Exists(Program.PSO2RootDir & "\data\license\stlport.txt") = False Then DownloadFile(Program.FreedomUrl & "license/stlport.txt", Program.PSO2RootDir & "\data\license\stlport.txt")
                    If File.Exists(Program.PSO2RootDir & "\data\license\tolua++_License.txt") = False Then DownloadFile(Program.FreedomUrl & "license/tolua++_License.txt", Program.PSO2RootDir & "\data\license\tolua++_License.txt")
                Else
                    'Create the directory, and download the four files in there -_-
                    Helper.Log("Didn't find a license folder, creating it and downloading licenses.")
                    Directory.CreateDirectory(Program.PSO2RootDir & "\data\license\")
                    If File.Exists(Program.PSO2RootDir & "\data\license\boost.txt") = False Then DownloadFile(Program.FreedomUrl & "license/boost.txt", Program.PSO2RootDir & "\data\license\boost.txt")
                    If File.Exists(Program.PSO2RootDir & "\data\license\lua_license.txt") = False Then DownloadFile(Program.FreedomUrl & "license/lua_license.txt", Program.PSO2RootDir & "\data\license\lua_license.txt")
                    If File.Exists(Program.PSO2RootDir & "\data\license\stlport.txt") = False Then DownloadFile(Program.FreedomUrl & "license/stlport.txt", Program.PSO2RootDir & "\data\license\stlport.txt")
                    If File.Exists(Program.PSO2RootDir & "\data\license\tolua++_License.txt") = False Then DownloadFile(Program.FreedomUrl & "license/tolua++_License.txt", Program.PSO2RootDir & "\data\license\tolua++_License.txt")
                End If

                'Clean up QUANTUM DLL crap
                'If the file exists in win32, delet this
                If File.Exists(Program.PSO2WinDir & "\cudart32_30_9.dll") Then File.Delete(Program.PSO2WinDir & "\cudart32_30_9.dll")
                If File.Exists(Program.PSO2WinDir & "\D3dx9d_42.dll") Then File.Delete(Program.PSO2WinDir & "\D3dx9d_42.dll")
                If File.Exists(Program.PSO2WinDir & "\D3dx9d_43.dll") Then File.Delete(Program.PSO2WinDir & "\D3dx9d_43.dll")
                If File.Exists(Program.PSO2WinDir & "\sdkencryptedappticket.dll") Then File.Delete(Program.PSO2WinDir & "\sdkencryptedappticket.dll")
                If File.Exists(Program.PSO2WinDir & "\sdkencryptedappticket64.dll") Then File.Delete(Program.PSO2WinDir & "\sdkencryptedappticket64.dll")
                If File.Exists(Program.PSO2WinDir & "\Access to Veda denied") Then File.Delete(Program.PSO2WinDir & "\Access to Veda denied")


            Catch ex As Exception
                Helper.LogWithException("ERROR - ", ex)
            End Try

            If File.Exists((Program.PSO2WinDir & "\ffbff2ac5b7a7948961212cefd4d402c")) Then
                Computer.FileSystem.DeleteFile(Program.PSO2WinDir & "\ffbff2ac5b7a7948961212cefd4d402c", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                WriteDebugInfoAndOk("Removing Censor...")
            End If

            'btnLaunchPSO2.Enabled = False

            If File.Exists("missing.json") Then
                Dim yesNoResume As MsgBoxResult = MsgBox("It seems that the last patching attempt was interrupted. Would you like to resume patching?", vbYesNo)
                If yesNoResume = MsgBoxResult.Yes Then
                    RegKey.SetValue(Of String)("PSO2Dir", Program.GetSetting("PSO2Dir"))
                    ' Use IOC Container in the main Tweaker project to deal with dependencies.
                    Dim output As New TweakerTrigger
                    Dim Settings = New JsonTweakerSettings(Program.AppData & "/PSO2 Tweaker/settings.json")
                    Dim updater = New UpdateManager(Settings, output)
                    Dim SkipClient As New WebClient
                    Helper.Log("Downloading the list of files to skip...")
                    SkipClient.DownloadFile(Program.FreedomUrl & "skip.txt", "skip.txt")
                    'await updater.CleanLegacyFiles();

                    'Console.WriteLine(settings.GameDirectory)
                    Try

                        'frmDownloader.TopMost = True
                        'Me.TopMost = False
                    Catch ex As Exception
                        Helper.LogWithException("ERROR - ", ex)
                    End Try
                    frmDownloader.CleanupUI()
                    Await updater.Update(False, False)
                Else
                    Helper.DeleteFile("missing.json")
                    Helper.DeleteFile("done.log")
                End If
            End If

            WriteDebugInfo("Checking for PSO2 Updates...")
            Application.DoEvents()

            Await CheckForPso2Updates(False)
            Application.DoEvents()


            'Check for PSO2 Updates here, download the version.ver thingie
            'Check for PSO2 EN Patch updates here, parse the URL and see if it's different from the saved one
            'Check for EN Story Patch

            WriteDebugInfo("Checking for updates to patches...")

            'Check for English Patches (Done! :D)
            CheckForEnPatchUpdates()
            WriteDebugInfo("Current EN Patch version is: " & Program.GetSetting("ENPatchVersion"))
            Application.DoEvents()

            'Check for LargeFiles Update (Work-In-Progress!)
            CheckForLargeFilesUpdates()
            WriteDebugInfo("Current Large Files version is: " & Program.GetSetting("LargeFilesVersion"))
            Application.DoEvents()

            'Check for Story Patches (Done! :D)
            Application.DoEvents()
            CheckForStoryUpdates()
            WriteDebugInfo("Current Story Patch version is: " & Program.GetSetting("StoryPatchVersion"))
            Application.DoEvents()

            Helper.DeleteFile("version.ver")

            CheckForPluginUpdates()


        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try

        Helper.DeleteFile("Story MD5HashList.txt")
        Helper.DeleteFile("PSO2 Tweaker Updater.exe")
        'PBMainBar.Value = 0
        'lblStatus.Text = ""
        WriteDebugInfo("All done - System ready!")
    End Sub

    Private Function GenerateELSName() As String
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"
        Dim r As New Random
        Dim sb As New StringBuilder
        For i As Integer = 1 To 8
            Dim idx As Integer = r.Next(0, 35)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function
    Private Sub frmMainv2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If SystemInformation.HighContrast = True Then
            e.Graphics.DrawImage(New Bitmap(BackgroundImage), 0, 0)
            Dim cControl As Control
            For Each cControl In Me.Controls
                If TypeOf cControl Is Button Then
                    If cControl.BackgroundImage IsNot Nothing Then e.Graphics.DrawImage(New Bitmap(cControl.BackgroundImage), cControl.Location.X, cControl.Location.Y)
                End If
                If TypeOf cControl Is PictureBox Then
                    If cControl.BackgroundImage IsNot Nothing Then e.Graphics.DrawImage(New Bitmap(cControl.BackgroundImage, cControl.Size), cControl.Location.X, cControl.Location.Y)
                End If
            Next cControl
        End If
    End Sub
    Public Sub FinalUpdateSteps()
        TweakerTrigger.patchwriter.Close()
        'Final update steps - Set the version file, reset patches. [AIDA]
        'frmMainv2.WriteDebugInfo("Downloading " & "version file...")
        DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")


        If File.Exists((_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver")) Then Helper.DeleteFile((_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver"))
        File.Copy("version.ver", (_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver"))


        'If RegKey.GetValue(Of String)(RegKey.StoryPatchVersion) <> "Not Installed" Then RegKey.SetValue(Of String)(RegKey.StoryPatchVersion, "Not Updated")
        'If Program.GetSetting("ENPatchVersion") <> "Not Installed" Then RegKey.SetValue(Of String)(RegKey.ENPatchVersion, "Not Updated")
        'If Program.GetSetting("LargeFilesVersion") <> "Not Installed" Then RegKey.SetValue(Of String)(RegKey.LargeFilesVersion, "Not Updated")

        WriteDebugInfo("Game updated to the latest version. Don't forget to re-install/update the patches, as some of the files might have been untranslated.")
        Program.SaveSetting("PSO2RemoteVersion", File.ReadAllLines("version.ver")(0))
        Helper.DeleteFile("version.ver")
    End Sub
    Private Async Sub InstallPso2()
        Dim installFolder As String = ""
        'Const installYesNo As MsgBoxResult = vbYes
        'If installYesNo = vbNo Then
        '    WriteDebugInfo("You can view more information about the installer at:" & vbCrLf & "http://arks-layer.com/setup.php")
        '    Return
        'End If
        'If installYesNo = vbYes Then
        MsgBox("This will install Phantasy Star Online EPISODE 4! Please select a folder to install into." & vbCrLf & "A folder called PHANTASYSTARONLINE2 will be created inside the folder you choose." & vbCrLf & "(For example, if you choose the C drive, it will install to C:\PHANTASYSTARONLINE2\)" & vbCrLf & "It is HIGHLY RECOMMENDED that you do NOT install into the Program Files folder, but a normal folder like C:\PHANTASYSTARONLINE\")
        Dim installPso2 As Boolean = True
        While installPso2
            Dim myFolderBrowser As New FolderBrowserDialog With {.RootFolder = Environment.SpecialFolder.MyComputer, .Description = "Please select a folder (or drive) to install PSO2 into"}
            Dim dlgResult As DialogResult = myFolderBrowser.ShowDialog()

            If dlgResult = DialogResult.OK Then
                installFolder = myFolderBrowser.SelectedPath
            End If
            If dlgResult = DialogResult.Cancel Then
                WriteDebugInfo("Installation cancelled by user!")
                Return
            End If
            Dim correctYesNo As MsgBoxResult = MsgBox("You wish to install PSO2 into " & (installFolder & "\PHANTASYSTARONLINE2\. Is this correct?").Replace("\\", "\"), vbYesNoCancel)
            If correctYesNo = vbCancel Then
                WriteDebugInfo("Installation cancelled by user!")
                Return
            End If
            If correctYesNo = vbNo Then
                Continue While
            End If
            If correctYesNo = vbYes Then
                For Each drive In DriveInfo.GetDrives()
                    If (drive.DriveType = DriveType.Fixed) AndAlso (installFolder(0) = drive.Name(0)) Then
                        If drive.TotalSize < 42000000000 Then
                            MsgBox("There is not enough space on the selected disk to install PSO2. Please select a different drive. (Requires 41GB of free space)")
                            Continue While
                        End If
                        If drive.AvailableFreeSpace < 42000000000 Then
                            MsgBox("There is not enough free space on the selected disk to install PSO2. Please free up some space or select a different drive. (Requires 41GB of free space)")
                            Continue While
                        End If
                    End If
                Next

                Dim finalYesNo As MsgBoxResult = MsgBox("The program will now install the necessary files, create the folders, and set up the game. Afterwards, the program will automatically begin patching. Click ""OK"" to start.", MsgBoxStyle.OkCancel)
                If finalYesNo = vbCancel Then
                    WriteDebugInfo("Installation cancelled by user!")
                Else
                    'set the pso2Dir to the install patch
                    Program.PSO2RootDir = (installFolder & "\PHANTASYSTARONLINE2\pso2_bin").Replace("\\", "\")
                    Helper.DeleteFile("client.json")
                    Show()
                    Focus()
                    Application.DoEvents()
                    WriteDebugInfo("Downloading DirectX setup...")
                    Try
                        DownloadFile("http://arks-layer.com/docs/dxwebsetup.exe", "dxwebsetup.exe")
                        WriteDebugInfoSameLine("Done!")
                        WriteDebugInfo("Checking/Installing DirectX...")
                        Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo() With {.FileName = "dxwebsetup.exe", .Verb = "runas", .Arguments = "/Q", .UseShellExecute = True}
                        Process.Start(processStartInfo).WaitForExit()
                        WriteDebugInfoSameLine("Done!")
                    Catch ex As Exception
                        WriteDebugInfo("DirectX installation failed! Please install it later if neccessary!")
                    End Try

                    If File.Exists("dxwebsetup.exe") Then File.Delete("dxwebsetup.exe")
                    'Make a data folder, and a win32 folder under that
                    Directory.CreateDirectory(Program.PSO2RootDir & "\data\win32\")
                    'Download required pso2 stuff
                    WriteDebugInfo("Downloading PSO2 required files...")
                    DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2launcher.exe.pat", Program.PSO2RootDir & "\pso2launcher.exe")
                    DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2updater.exe.pat", Program.PSO2RootDir & "\pso2updater.exe")
                    DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2.exe.pat", Program.PSO2RootDir & "\pso2.exe")
                    DownloadFile("http://download.pso2.jp/patch_prod/patches/PSO2JP.ini.pat", Program.PSO2RootDir & "\PSO2JP.ini")
                    WriteDebugInfoSameLine("Done!")
                    'Download Gameguard.des
                    WriteDebugInfo("Downloading Latest Gameguard file...")
                    DownloadFile("http://download.pso2.jp/patch_prod/patches/GameGuard.des.pat", Program.PSO2RootDir & "\GameGuard.des")
                    WriteDebugInfoSameLine("Done!")
                    Application.DoEvents()

                    If File.Exists(Program.AppData & "/PSO2 Tweaker/settings.json") = False Then File.WriteAllText(Program.AppData & "/PSO2 Tweaker/settings.json", lblDefaults.Text)

                    Program.SaveSetting("PSO2Dir", Program.PSO2RootDir)
                    WriteDebugInfo(Program.PSO2RootDir & " set as your PSO2 Directory.")
                    Program.PSO2WinDir = (Program.PSO2RootDir & "\data\win32")
                    If String.IsNullOrEmpty(Program.GetSetting("StoryPatchVersion")) Then Program.SaveSetting("StoryPatchVersion", "Not Installed")
                    If String.IsNullOrEmpty(Program.GetSetting("ENPatchVersion")) Then Program.SaveSetting("ENPatchVersion", "Not Installed")
                    If String.IsNullOrEmpty(Program.GetSetting("LargeFilesVersion")) Then Program.SaveSetting("LargeFilesVersion", "Not Installed")

                    RegKey.SetValue(Of String)("PSO2Dir", Program.GetSetting("PSO2Dir"))
                    ' Use IOC Container in the main Tweaker project to deal with dependencies.
                    'Dim output As New TweakerTrigger
                    'Dim Settings = New JsonTweakerSettings(Program.AppData & "/PSO2 Tweaker/settings.json")
                    'Dim updater = New UpdateManager(Settings, output)
                    Dim SkipClient As New WebClient
                    Helper.Log("Downloading the list of files to skip...")
                    SkipClient.DownloadFile(Program.FreedomUrl & "skip.txt", "skip.txt")
                    'await updater.CleanLegacyFiles();

                    'Console.WriteLine(settings.GameDirectory)
                    Try

                        'frmDownloader.TopMost = True
                        'Me.TopMost = False
                    Catch ex As Exception
                        Helper.LogWithException("Error - ", ex)
                    End Try
                    'frmDownloader.CleanupUI()
                    'Await updater.Update(True, False)
                    UpdatePSO2(False)

                    WriteDebugInfo("PSO2 successfully installed! It Is now being updated, And will be ready to play once it's finished.")
                    Refresh()
                End If
            End If

            installPso2 = False
            Program.IsPso2Installed = True
        End While
        'End If
    End Sub

    Private Sub CheckForStoryUpdates()
        Try
            If Program.GetSetting("StoryPatchVersion") = "Not Installed" Then Return
            'We're going to comment this out for the moment, but DO NOT REMOVE IT as it may be used again in the future... [AIDA]
            'And we did end up using it again for the plugin system. Thank you past AIDA <3 [AIDA]
            'DownloadFile(Program.FreedomUrl & "patchfiles/Story%20MD5HashList.txt", "Story MD5HashList.txt")

            'Using oReader As StreamReader = File.OpenText("Story MD5HashList.txt")
            'Dim strNewDate As String = oReader.ReadLine()
            'RegKey.SetValue(Of String)(RegKey.NewVersionTemp, strNewDate)
            'RegKey.SetValue(Of String)(RegKey.NewStoryVersion, strNewDate)
            'If strNewDate <> RegKey.GetValue(Of String)(RegKey.StoryPatchVersion) Then
            'A new story patch update is available - Would you like to download and install it? PLEASE NOTE: This update assumes you've already downloaded and installed the latest RAR file available from http://arks-layer.com, which seems to be: 
            ' Create a match using regular exp<b></b>ressions
            'http://arks-layer.com/Story%20Patch%208-8-2013.rar.torrent
            ' Spit out the value plucked from the code

            Dim strDownloadMe = Program.StoryDate
            If Program.GetSetting("LatestStoryBase") <> strDownloadMe Then
                Dim StoryChangeLog As String = DownloadString(Program.StoryChangelogURL)
                Dim mbVisitLink As MsgBoxResult = MsgBox("A new story patch is available! Would you like to download and install it? Here's a list of changes: " & vbCrLf & StoryChangeLog, MsgBoxStyle.YesNo)
                If mbVisitLink = vbYes Then InstallStoryPatchNew()
                Return
            End If

        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub CheckForEnPatchUpdates()
        Try
            If Program.GetSetting("ENPatchVersion") = "Not Installed" Then Return
            Application.DoEvents()
            Dim filename As String = ""
            Dim URL As String = ""
            Dim strVersion As String = ""
            If Program.ENPatchOverride = "No" Then
                Dim LoginClient As New WebClient
                LoginClient.Credentials = New NetworkCredential(GetUsername, GetPassword)
                Dim json As JObject = JObject.Parse(LoginClient.DownloadString("https://pso2.arghlex.net/pso2-authorized/?sort=modtime&order=desc&json"))
                If json.SelectToken("files").First.SelectToken("name").ToString().Contains("large") = False Then
                    filename = json.SelectToken("files").First.SelectToken("name").ToString()
                Else
                    If json.SelectToken("files").First.Next.SelectToken("name").ToString().Contains("large") = False Then
                        filename = json.SelectToken("files").First.Next.SelectToken("name").ToString()
                    Else
                        WriteDebugInfoAndFailed("Unable to get english patch information!")
                        Exit Sub
                    End If
                End If
                URL = "https://pso2.arghlex.net/pso2-authorized/" & filename
                strVersion = filename.Replace(".rar", "").Replace(".zip", "")
            Else
                URL = Program.ENPatchOverrideURL
                Dim filename2 As String() = URL.Split("/")
                strVersion = filename2(filename2.Count - 1).Replace(".rar", "").Replace(".zip", "")
            End If



            Program.SaveSetting("NewENVersion", strVersion)

            If Program.GetSetting("ENPatchVersion") <> strVersion Then
                If MsgBox("A new EN patch update is available - Would you like to download and install it?", vbYesNo) = vbYes Then
                    DownloadPatch(URL, "English Patch", "ENPatchVersion", "Would you like to backup your files before applying the patch? This will erase all previous Pre-EN patch backups.", "Please select the pre-downloaded EN Patch RAR file")
                End If
            End If
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub CheckForLargeFilesUpdates()
        Try
            If Program.GetSetting("LargeFilesVersion") = "Not Installed" Then Return

            Application.DoEvents()
            Dim strVersion As String = Program.LargeFilesTransAmDate

            Program.SaveSetting("NewLargeFilesVersion", strVersion)

            If Program.GetSetting("LargeFilesVersion") <> strVersion Then
                If MsgBox("An update for the Large Files is available. Would you like to install it via TRANSAM?", vbYesNo) = vbYes Then
                    InstallLargeFiles()
                End If
            End If
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub
    Private Sub InstallLargeFiles()
        'Install Large Files with TRANSAM to cut down on net costs for Agrajag and friends.
        'Need to speak with Agrajag and get some files before I can do this, though.
        Try
            If IsPso2WinDirMissing() Then Return

            ' Create a match using regular exp<b></b>ressions
            ' Spit out the value plucked from the code
            Dim backupdir As String = BuildBackupPath("Large Files")

            Dim LFDate As String = Program.LargeFilesTransAmDate.Replace("/", "-")

            WriteDebugInfoAndOk("Downloading Large Files info... ")
            DownloadFile(Program.FreedomUrl & "lf.stripped.zip", "lf.stripped.zip")
            ExtractFiles("lf.stripped.zip", Program.StartPath)
            Dim DBMD5 As String = Helper.GetMd5("lf.stripped.db")
            WriteDebugInfoAndOk("Downloading Trans-Am tool... ")
            DownloadFile(Program.FreedomUrl & "pso2-transam.exe", "pso2-transam.exe")

            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo() With {.FileName = "pso2-transam.exe", .Verb = "runas"}
            If Directory.Exists(backupdir) Then
                Dim counter = Computer.FileSystem.GetFiles(backupdir)
                If counter.Count > 0 Then
                    processStartInfo.Arguments = (TransamCodes2() & "largefiles-" & LFDate & " lf.stripped.db " & """" & Program.PSO2WinDir & """")
                Else
                    Helper.Log("[TRANSAM] Creating backup directory")
                    Directory.CreateDirectory(backupdir)
                    WriteDebugInfo("Creating backup directory...")
                    processStartInfo.Arguments = (TransamCodes1() & """" & backupdir & """ " & TransamCodes2() & "largefiles-" & LFDate & " lf.stripped.db " & """" & Program.PSO2WinDir & """")
                End If
            End If

            'We don't need to make backups anymore
            'Yes we do, shut up past AIDA.
            If Not Directory.Exists(backupdir) Then
                Helper.Log("[TRANSAM] Creating backup directory")
                Directory.CreateDirectory(backupdir)
                WriteDebugInfo("Creating backup directory...")
                processStartInfo.Arguments = (TransamCodes1() & """" & backupdir & """ " & TransamCodes2() & "largefiles-" & LFDate & " lf.stripped.db " & """" & Program.PSO2WinDir & """")
            End If

            TRIALSystem("Request TRANSAM")

            processStartInfo.UseShellExecute = False
            Helper.Log("[TRANSAM] Starting shitstorm")
            processStartInfo.Arguments = processStartInfo.Arguments.Replace("\", "/")
            If Helper.GetMd5("lf.stripped.db") <> DBMD5 Then
                MsgBox("ERROR: Files have been modified since download. Aborting...")
                Exit Sub
            End If
            Process.Start(processStartInfo).WaitForExit()
            Helper.DeleteFile("lf.stripped.db")
            Helper.DeleteFile("lf.stripped.zip")
            Helper.DeleteFile("pso2-transam.exe")
            External.FlashWindow(Handle, True)
            'Story Patch 3-12-2014.rar
            Program.SaveSetting("LargeFilesVersion", LFDate.Replace("-", "/"))
            WriteDebugInfo("Large Files Patch installed!")
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub
    Private Shared Function IsPso2WinDirMissing() As Boolean
        If Program.PSO2RootDir = "lblDirectory" OrElse Not Directory.Exists(Program.PSO2WinDir) Then
            MsgBox("Please select your PSO2's pso2_bin Directory. It will be saved so you don't have to select it again.")
            Helper.SelectPso2Directory()
            Return True
        End If
        Return False
    End Function
    Private Shared Function BuildBackupPath(ByVal patchName As String) As String
        Return Program.PSO2WinDir & "\backup\" & patchName & "\"
    End Function
    Private Sub InstallStoryPatchNew()
        'Don't forget to make GUI changes!
        Try
            If IsPso2WinDirMissing() Then Return

            ' Create a match using regular exp<b></b>ressions
            ' Spit out the value plucked from the code

            Dim backupdir As String = BuildBackupPath("Story Patch")
            Dim strStoryPatchLatestBase As String = Program.StoryDate.Replace("/", "-")
            WriteDebugInfoAndOk("Downloading story patch info... ")
            DownloadFile(Program.FreedomUrl & "pso2.stripped.zip", "pso2.stripped.zip")
            ExtractFiles("pso2.stripped.zip", Program.StartPath)
            Dim DBMD5 As String = Helper.GetMd5("pso2.stripped.db")
            WriteDebugInfoAndOk("Downloading Trans-Am tool... ")
            DownloadFile(Program.FreedomUrl & "pso2-transam.exe", "pso2-transam.exe")

            'execute pso2-transam stuff with -b flag for backup
            Dim processStartInfo As ProcessStartInfo = New ProcessStartInfo() With {.FileName = "pso2-transam.exe", .Verb = "runas"}
            If Directory.Exists(backupdir) Then
                Dim counter = Computer.FileSystem.GetFiles(backupdir)
                If counter.Count > 0 Then
                    processStartInfo.Arguments = (TransamCodes2() & "story-eng-" & strStoryPatchLatestBase & " pso2.stripped.db " & """" & Program.PSO2WinDir & """")
                Else
                    Helper.Log("[TRANSAM] Creating backup directory")
                    Directory.CreateDirectory(backupdir)
                    WriteDebugInfo("Creating backup directory...")
                    processStartInfo.Arguments = (TransamCodes1() & """" & backupdir & """ " & TransamCodes2() & "story-eng-" & strStoryPatchLatestBase & " pso2.stripped.db " & """" & Program.PSO2WinDir & """")
                End If
            End If

            'We don't need to make backups anymore
            'Yes we do, shut up past AIDA.
            If Not Directory.Exists(backupdir) Then
                Helper.Log("[TRANSAM] Creating backup directory")
                Directory.CreateDirectory(backupdir)
                WriteDebugInfo("Creating backup directory...")
                processStartInfo.Arguments = (TransamCodes1() & """" & backupdir & """ " & TransamCodes2() & "story-eng-" & strStoryPatchLatestBase & " pso2.stripped.db " & """" & Program.PSO2WinDir & """")
            End If

            TRIALSystem("Request TRANSAM")

            processStartInfo.UseShellExecute = False
            Helper.Log("[TRANSAM] Starting shitstorm")
            processStartInfo.Arguments = processStartInfo.Arguments.Replace("\", "/")
            'Helper.Log("TRANSM parameters: " & processStartInfo.Arguments & vbCrLf & "TRANSAM Working Directory: " & processStartInfo.WorkingDirectory)
            Helper.Log("[TRANSAM] Program started")
            If Helper.GetMd5("pso2.stripped.db") <> DBMD5 Then
                MsgBox("ERROR: Files have been modified since download. Aborting...")
                Exit Sub
            End If

            Process.Start(processStartInfo).WaitForExit()
            Helper.DeleteFile("pso2.stripped.db")
            Helper.DeleteFile("pso2.stripped.zip")
            Helper.DeleteFile("pso2-transam.exe")
            External.FlashWindow(Handle, True)
            'Story Patch 3-12-2014.rar
            Program.SaveSetting("StoryPatchVersion", strStoryPatchLatestBase.Replace("-", "/"))
            Program.SaveSetting("LatestStoryBase", strStoryPatchLatestBase.Replace("-", "/"))
            WriteDebugInfo("Story Patch Installed!")
            CheckForStoryUpdates()
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub
    Private Async Function CheckForPso2Updates(comingFromPrePatch As Boolean) As Task

        Try
            'Precede file, syntax is Yes/No:<Dateoflastprepatch>



            Dim precedeversionstring As String = Program.LastPrecedeDate
            Helper.DeleteFile("precede.txt")
            If comingFromPrePatch Then
                DownloadPrePatch(precedeversionstring)
            Else
                Dim firstTimechecking As Boolean = String.IsNullOrEmpty(Program.GetSetting("PSO2PrecedeVersion"))
                If firstTimechecking Then Program.SaveSetting("PSO2PrecedeVersion", precedeversionstring)

                If Program.NewPrecedeAvailable = "Yes" AndAlso (Program.GetSetting("PSO2PrecedeVersion") <> precedeversionstring OrElse firstTimechecking) Then
                    Dim downloadPrepatchResult As MsgBoxResult = MsgBox("New pre-patch data is available to download - Would you like to download it? This is optional, and will let you download some of a large patch now, as opposed to having a larger download all at once when it is released.", MsgBoxStyle.YesNo)
                    If downloadPrepatchResult = vbYes Then DownloadPrePatch(precedeversionstring)
                End If
            End If

            'Check whether or not to apply pre-patch shit. Ugh.
            If Directory.Exists(Program.PSO2RootDir & "\_precede\") AndAlso Directory.Exists(Program.PSO2RootDir & "\_precede\data\win32\") Then

                If Program.ApplyPrecede = "Yes" Then
                    InstallPrePatch()
                End If
            End If

            If Not comingFromPrePatch Then
                Try
                    Dim source As String = Program.AreYouAlive.DownloadString("http://arks-layer.com/vanila/version.txt")
                    If String.IsNullOrEmpty(source) Then
                        Helper.Log("ERROR: Wasn't able to contact Arks Layer, help!")
                        WriteDebugInfo("Failed to get the PSO2 Version update information. The rest of the program will work fine, and this error will be fixed shortly.")
                        Exit Function
                    End If
                Catch ex As Exception
                    Helper.LogWithException("ERROR - ", ex)
                    WriteDebugInfo("Failed to get the PSO2 Version information. The rest of the program will work fine, and this error will be fixed shortly.")
                    Exit Function
                End Try
                DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")
                Dim version = File.ReadAllLines("version.ver")(0)
                If String.IsNullOrEmpty(Program.GetSetting("PSO2RemoteVersion")) Then
                    Program.SaveSetting("PSO2RemoteVersion", version)
                End If

                If Program.GetSetting("PSO2RemoteVersion") <> version Then
                    If MsgBox("An update for PSO2 is available - Would you like to download and install it?", vbYesNo) = vbYes Then

                        RegKey.SetValue(Of String)("PSO2Dir", Program.GetSetting("PSO2Dir"))
                        ' Use IOC Container in the main Tweaker project to deal with dependencies.
                        Dim output As New TweakerTrigger
                        Dim Settings = New JsonTweakerSettings(Program.AppData & "/PSO2 Tweaker/settings.json")
                        Dim updater = New UpdateManager(Settings, output)
                        Dim SkipClient As New WebClient
                        Helper.Log("Downloading the list of files to skip...")
                        SkipClient.DownloadFile(Program.FreedomUrl & "skip.txt", "skip.txt")
                        'await updater.CleanLegacyFiles();

                        'Console.WriteLine(settings.GameDirectory)
                        Try

                            'frmDownloader.TopMost = True
                            'Me.TopMost = False
                        Catch ex As Exception
                            Helper.LogWithException("ERROR - ", ex)
                        End Try
                        frmDownloader.CleanupUI()
                        Program.SaveSetting("StoryPatchVersion", "Not Installed")
                        Program.SaveSetting("ENPatchVersion", "Not Installed")
                        Program.SaveSetting("LargeFilesVersion", "Not Installed")
                        Await updater.Update(False, False)
                    End If
                End If
            End If
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Function
    Private Sub InstallPrePatch()
        Dim applyPrePatchYesNo As MsgBoxResult = MsgBox("It appears that it's time to install the pre-patch download - Is this okay? If you select no, the pre-patch will not be installed.", vbYesNo)
        If applyPrePatchYesNo = vbYes Then
            'WriteDebugInfo("Restoring backup of vanilla JP files...")
            '[AIDA] Apply the precede   
            If Directory.Exists(BuildBackupPath("English Patch")) Then RestoreBackup("English Patch")
            If Directory.Exists(BuildBackupPath("Large Files")) Then RestoreBackup("Large Files")
            If Directory.Exists(BuildBackupPath("Story Patch")) Then RestoreBackup("Story Patch")
            WriteDebugInfo("Installing prepatch, please wait...")
            Application.DoEvents()

            'list the names of all files in the specified directory
            Dim files = New DirectoryInfo(Program.PSO2RootDir & "\_precede\data\win32\").GetFiles()
            Dim counter = files.Length
            Dim count As Integer = 0
            WriteDebugInfo("Moved " & count & " files out of " & counter)
            For Each dra As FileInfo In files
                Dim downloadStr As String = dra.Name
                Helper.DeleteFile((Program.PSO2WinDir & "\" & downloadStr))
                File.Move(Program.PSO2RootDir & "\_precede\data\win32\" & downloadStr, (Program.PSO2WinDir & "\" & downloadStr))
                count += 1
                rtbDebug.Text = rtbDebug.Text.Replace("Moved " & count - 1 & " files out of " & counter, "Moved " & count & " files out of " & counter)
                'lblStatus.Text = "Moved " & count & " files out of " & counter
                Application.DoEvents()
            Next
            If File.Exists("win32list_DO_NOT_DELETE_ME.txt") Then File.Delete("win32list_DO_NOT_DELETE_ME.txt")
            WriteDebugInfo("Done!")
            Helper.DeleteDirectory(Program.PSO2RootDir & "\_precede")
            Program.SaveSetting("JustPrepatched", "True")
        End If
    End Sub

    Private Sub DownloadPrePatch(version As String)
        _cancelledFull = False
        'lblStatus.Text = ""
        WriteDebugInfo("Downloading pre-patch filelist...")
        DownloadFile("http://download.pso2.jp/patch_prod/patches_precede/patchlist0.txt", "patchlist0.txt")
        DownloadFile("http://download.pso2.jp/patch_prod/patches_precede/patchlist1.txt", "patchlist1.txt")
        DownloadFile("http://download.pso2.jp/patch_prod/patches_precede/patchlist2.txt", "patchlist2.txt")
        DownloadFile("http://download.pso2.jp/patch_prod/patches_precede/patchlist3.txt", "patchlist3.txt")
        DownloadFile("http://download.pso2.jp/patch_prod/patches_precede/patchlist4.txt", "patchlist4.txt")
        DownloadFile("http://download.pso2.jp/patch_prod/patches_precede/patchlist5.txt", "patchlist5.txt")
        WriteDebugInfoSameLine("Done!")
        If Not Directory.Exists(Program.PSO2RootDir & "\_precede\data\win32") Then Directory.CreateDirectory(Program.PSO2RootDir & "\_precede\data\win32")

        Dim mergedPrePatches = MergePrePatches()
        mergedPrePatches.Remove("GameGuard.des")
        mergedPrePatches.Remove("PSO2JP.ini")
        mergedPrePatches.Remove("script/user_default.pso2")
        mergedPrePatches.Remove("script/user_intel.pso2")
        mergedPrePatches.Remove("")

        WriteDebugInfo("Checking for already existing precede files...")

        Dim missingfiles As New List(Of String)
        Dim truefilename As String
        Dim numberofChecks As Integer = 0
        WriteDebugInfo("Currently checking file # " & numberofChecks & " (Missing files found: " & missingfiles.Count & ")")
        For Each sBuffer In mergedPrePatches
            If _cancelledFull Then Return

            truefilename = sBuffer.Value

            If Not File.Exists(((Program.PSO2RootDir & "\_precede\data\win32") & "\" & truefilename)) Then
                Helper.Log("DEBUG: The file " & truefilename & " is missing.")
                missingfiles.Add(truefilename)
            ElseIf Helper.GetMd5(((Program.PSO2RootDir & "\_precede\data\win32") & "\" & truefilename)) <> sBuffer.Key Then
                Helper.Log("DEBUG: The file " & truefilename & " must be redownloaded.")
                missingfiles.Add(truefilename)
            End If

            numberofChecks += 1
            rtbDebug.Text = rtbDebug.Text.Replace("Currently checking file # " & numberofChecks - 1 & " (Missing files found: " & missingfiles.Count & ")", "Currently checking file # " & numberofChecks & " (Missing files found: " & missingfiles.Count & ")")
            'lblStatus.Text = ("Currently checking file # " & numberofChecks & " (Missing files found: " & missingfiles.Count & ")")
            Application.DoEvents()
        Next

        Dim totaldownload As Long = missingfiles.Count
        Dim downloaded As Long = 0
        Dim totaldownloaded As Long = 0
        WriteDebugInfo("Downloading " & "" & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded) & ")")
        For Each downloadStr As String In missingfiles
            If _cancelledFull Then Return
            'Download the missing files:
            'WHAT THE FUCK IS GOING ON HERE?
            downloaded += 1
            totaldownloaded += _totalsize2

            'lblStatus.Text = "Downloading " & "" & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded) & ")"
            rtbDebug.Text = rtbDebug.Text.Replace("Downloading " & "" & downloaded - 1 & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded - _totalsize2) & ")", "Downloading " & "" & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded) & ")")
            Application.DoEvents()
            _cancelled = False
            DownloadFile(("http://download.pso2.jp/patch_prod/patches_precede/data/win32/" & downloadStr & ".pat"), downloadStr)
            If New FileInfo(downloadStr).Length = 0 Then
                Helper.Log("File appears to be empty, trying to download from secondary SEGA server")
                DownloadFile(("http://download.pso2.jp/patch_prod/patches_precede/data/win32/" & downloadStr & ".pat"), downloadStr)
            End If

            If _cancelled Then Return

            Helper.DeleteFile(((Program.PSO2RootDir & "\_precede\data\win32") & "\" & downloadStr))
            File.Move(downloadStr, ((Program.PSO2RootDir & "\_precede\data\win32") & "\" & downloadStr))
            Helper.Log("DEBUG: Downloaded and installed " & downloadStr & ".")
            Application.DoEvents()
        Next

        If missingfiles.Count = 0 Then WriteDebugInfo("Your precede data is up to date!")
        If missingfiles.Count <> 0 Then
            WriteDebugInfo("Precede data downloaded/updated!")
        End If
        Program.SaveSetting("PSO2PrecedeVersion", version)
    End Sub
    Private Shared Function MergePrePatches() As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)

        For i As Integer = 0 To 5
            Dim patchlist = File.ReadAllLines("patchlist" & i & ".txt")
            'Dim patchlist = DlwuaString("http://download.pso2.jp/patch_prod/patches_precede/patchlist" & i & ".txt").Split(ControlChars.Cr)

            For index As Integer = 0 To (patchlist.Length - 1)
                If String.IsNullOrEmpty(patchlist(index)) Then Continue For

                Dim splitLine = patchlist(index).Split(ControlChars.Tab)
                Dim fileName = Path.GetFileNameWithoutExtension(splitLine(0).Replace("data/win32/", ""))
                Dim hash = splitLine(2)

                If (Not String.IsNullOrEmpty(fileName)) AndAlso (Not result.ContainsKey(hash)) Then
                    result.Add(hash, fileName)
                End If
            Next
        Next

        Return result
    End Function
    Private Sub RestoreBackup(patchName As String)
        Dim backupPath As String = BuildBackupPath(patchName)
        If Directory.Exists(backupPath) = False Then
            WriteDebugInfoAndWarning("Could not find the backup path! Are you sure you have a backup in your win32/backup folder?")
            Return
        End If

        Dim di As New DirectoryInfo(backupPath)
        WriteDebugInfoAndOk("Restoring " & patchName & " backup...")
        Application.DoEvents()

        'list the names of all files in the specified directory
        For Each dra As FileInfo In di.GetFiles()
            If File.Exists(Program.PSO2WinDir & "\" & dra.ToString()) Then
                Helper.DeleteFile(Program.PSO2WinDir & "\" & dra.ToString())
            End If
            File.Move(backupPath & "\" & dra.ToString(), Program.PSO2WinDir & "\" & dra.ToString())
        Next

        Helper.DeleteDirectory(backupPath)
        External.FlashWindow(Handle, True)

        Select Case patchName
            Case "English Patch"
                Program.SaveSetting("ENPatchVersion", "Not Installed")
            Case "Large Files"
                Program.SaveSetting("LargeFilesVersion", "Not Installed")
            Case "Story Patch"
                Program.SaveSetting("StoryPatchVersion", "Not Installed")
        End Select
        'WriteDebugInfoSameLine(" Done!")

    End Sub
    Private Sub OnDownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles Downloader.DownloadProgressChanged
        'Try
        '    If PBMainBar.InvokeRequired = False And lblStatus.InvokeRequired = False Then
        Dim totalSize As Long = e.TotalBytesToReceive
        _totalsize2 = totalSize
        Dim downloadedBytes As Long = e.BytesReceived
        'Dim percentage As Integer = e.ProgressPercentage
        '        Application.DoEvents()
        '        PBMainBar.Value = percentage
        '        Application.DoEvents()
        '        lblStatus.Text = ("Downloaded " & Helper.SizeSuffix(downloadedBytes) & " / " & Helper.SizeSuffix(totalSize) & " (" & percentage & "%)")
        '    End If
        'Catch ex As Exception
        '    Helper.LogWithException("ERROR (ODPC)- ", ex)
        'End Try

        'Put your progress UI here, you can cancel download by uncommenting the line below
    End Sub

    Public Function DownloadString(ByVal address As String) As String
        If address.Contains(".jp") Then
            Downloader.Headers("user-agent") = "AQUA_HTTP"
        Else
            Downloader.Headers("user-agent") = GetUserAgent()
        End If

        While Downloader.IsBusy
            Application.DoEvents()
            Thread.Sleep(16)
        End While

        Return Downloader.DownloadString(New Uri(address))
    End Function
    Public Sub DownloadFile(ByVal address As String, ByVal filename As String)
        Try
            If address.Contains(".jp") Then
                Downloader.Headers("user-agent") = "AQUA_HTTP"
            ElseIf address.Contains("arghlex") Then
                Downloader.Credentials = New NetworkCredential(GetUsername, GetPassword)
            Else
                Downloader.Headers("user-agent") = GetUserAgent()
            End If

            While Downloader.IsBusy
                Application.DoEvents()
                Thread.Sleep(16)
            End While
            AddHandler Downloader.DownloadProgressChanged, AddressOf OnDownloadProgressChanged
            Downloader.DownloadFileAsync(New Uri(address), filename)

            While Downloader.IsBusy
                Application.DoEvents()
                Thread.Sleep(16)
            End While
        Catch ex As Exception
            Helper.LogWithException("ERROR (DF)- ", ex)
        End Try
    End Sub
    Private Sub DownloadPatch(patchUrl As String, patchName As String, versionStr As String, msgBackup As String, msgSelectArchive As String)
        _cancelledFull = False
        Dim patchFile As String = ""
        Try
            If IsPso2WinDirMissing() Then Return

            Dim backupyesno As MsgBoxResult
            Dim predownloadedyesno As MsgBoxResult
            Dim rarLocation As String = ""
            Dim strVersion As String = ""

            ' Check the patch download method preference
            Dim patchPreference As String = Program.GetSetting("PreDownloadedRar")
            Select Case patchPreference
                Case "Ask"
                    predownloadedyesno = MsgBox("Would you like to use a pre-downloaded RAR file containing the patch instead of downloading it now?", vbYesNo)
                Case "Always"
                    predownloadedyesno = MsgBoxResult.Yes
                Case "Never"
                    predownloadedyesno = MsgBoxResult.No
                Case Else
                    predownloadedyesno = MsgBox("Would you like to use a pre-downloaded RAR file containing the patch instead of downloading it now?", vbYesNo)
            End Select

            ' Check the backup preference
            'Why was this changed to never? [AIDA]
            'patchPreference = "Never"
            patchPreference = Program.GetSetting("Backup")
            Select Case patchPreference
                Case "Ask"
                    backupyesno = MsgBox(msgBackup, vbYesNo)
                Case "Always"
                    backupyesno = MsgBoxResult.Yes
                Case "Never"
                    backupyesno = MsgBoxResult.No
                Case Else
                    backupyesno = MsgBox(msgBackup, vbYesNo)
            End Select

            If predownloadedyesno = MsgBoxResult.No Then
                WriteDebugInfo("Downloading " & patchName & "...")
                Application.DoEvents()

                ' Might want to switch to a Uri class.
                ' Get the filename from the downloaded Path
                Dim lastfilename As String() = patchUrl.Split("/"c)
                strVersion = lastfilename(lastfilename.Length - 1)
                patchFile = strVersion
                strVersion = Path.GetFileNameWithoutExtension(strVersion) ' We're using this so that it's not format-specific.

                _cancelled = False

                If patchUrl.Contains("arghlex") = False Then
                    If Not Helper.CheckLink(patchUrl) Then
                        WriteDebugInfoAndFailed("Failed to contact " & patchName & " website - Patch install/update canceled!")
                        WriteDebugInfo("Please visit http://goo.gl/YzCE7 for more information!")
                        Return
                    End If
                End If

                Helper.Log("Attempting to download: " & patchUrl)
                DownloadFile(patchUrl, patchFile)
                If _cancelled Then Return
                WriteDebugInfo(("Download complete!"))

            ElseIf predownloadedyesno = MsgBoxResult.Yes Then
                OpenFileDialog1.Title = msgSelectArchive
                OpenFileDialog1.FileName = "PSO2 " & patchName & " RAR/ZIP file"
                OpenFileDialog1.Filter = "RAR Archives|*.rar|ZIP Archives|*.zip|All Files (*.*) |*.*"
                If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then Return

                rarLocation = OpenFileDialog1.FileName
                strVersion = OpenFileDialog1.SafeFileName
                patchFile = strVersion
                strVersion = Path.GetFileNameWithoutExtension(strVersion)
            End If

            Application.DoEvents()

            Helper.DeleteDirectory("TEMPPATCHAIDAFOOL")
            Directory.CreateDirectory("TEMPPATCHAIDAFOOL")

            ExtractFiles(patchFile, Program.StartPath & "\TEMPPATCHAIDAFOOL")


            If Not Directory.Exists("TEMPPATCHAIDAFOOL") Then
                Directory.CreateDirectory("TEMPPATCHAIDAFOOL")
                WriteDebugInfo("Had to manually make temp folder - Did the patch not extract right?")
            End If
            Dim diar1 As FileInfo() = New DirectoryInfo("TEMPPATCHAIDAFOOL").GetFiles()
            If _cancelledFull Then Return

            Dim backupPath As String = BuildBackupPath(patchName)
            If backupyesno = MsgBoxResult.Yes Then
                If Directory.Exists(backupPath) Then
                    Directory.Delete(backupPath, True)
                    Directory.CreateDirectory(backupPath)
                    WriteDebugInfo("Erasing previous backup...")
                End If
                If Not Directory.Exists(backupPath) Then
                    Directory.CreateDirectory(backupPath)
                    WriteDebugInfo("Creating backup directory...")
                End If
            End If

            Helper.Log("Extracted " & diar1.Length & " files from the patch")
            If diar1.Length = 0 Then
                WriteDebugInfo("Patch failed to extract correctly! Installation failed!")
                Return
            End If

            WriteDebugInfo("Installing patch...")

            For Each dra As FileInfo In diar1
                If _cancelledFull Then Return
                If backupyesno = MsgBoxResult.Yes Then
                    If File.Exists((Program.PSO2WinDir & "\" & dra.ToString())) Then
                        File.Move((Program.PSO2WinDir & "\" & dra.ToString()), (backupPath & "\" & dra.ToString()))
                    End If
                End If
                If backupyesno = MsgBoxResult.No Then
                    If File.Exists((Program.PSO2WinDir & "\" & dra.ToString())) Then
                        Helper.DeleteFile((Program.PSO2WinDir & "\" & dra.ToString()))
                    End If
                End If
                File.Move(("TEMPPATCHAIDAFOOL\" & dra.ToString()), (Program.PSO2WinDir & "\" & dra.ToString()))
            Next

            Helper.DeleteDirectory("TEMPPATCHAIDAFOOL")
            If backupyesno = MsgBoxResult.No Then
                External.FlashWindow(Handle, True)
                WriteDebugInfo("Patch installed/updated!")
                If Not String.IsNullOrEmpty(versionStr) Then Program.SaveSetting(versionStr, strVersion)
            End If
            If backupyesno = MsgBoxResult.Yes Then
                External.FlashWindow(Handle, True)
                WriteDebugInfo(("Patch installed/Updated! Backup is at " & backupPath))
                If Not String.IsNullOrEmpty(versionStr) Then Program.SaveSetting(versionStr, strVersion)
            End If
            Helper.DeleteFile(patchFile)

        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub tsmInstallEnglishPatch_Click(sender As Object, e As EventArgs) Handles tsmInstallEnglishPatch.Click
        WriteDebugInfo("Beginning English Patch installation...")
        Dim filename As String = ""
        Dim URL As String = ""
        If Program.ENPatchOverride = "No" Then
            Dim LoginClient As New WebClient
            LoginClient.Credentials = New NetworkCredential(GetUsername, GetPassword)
            Dim json As JObject = JObject.Parse(LoginClient.DownloadString("https://pso2.arghlex.net/pso2-authorized/?sort=modtime&order=desc&json"))
            If json.SelectToken("files").First.SelectToken("name").ToString().Contains("large") = False Then
                filename = json.SelectToken("files").First.SelectToken("name").ToString()
            Else
                If json.SelectToken("files").First.Next.SelectToken("name").ToString().Contains("large") = False Then
                    filename = json.SelectToken("files").First.Next.SelectToken("name").ToString()
                Else
                    WriteDebugInfoAndFailed("Unable to get english patch information!")
                    Exit Sub
                End If
            End If
            URL = "https://pso2.arghlex.net/pso2-authorized/" & filename
        Else
            URL = Program.ENPatchOverrideURL
        End If

        DownloadPatch(URL, "English Patch", "ENPatchVersion", "Would you like to backup your files before applying the patch? This will erase all previous Pre-EN patch backups.", "Please select the pre-downloaded EN Patch RAR file")

    End Sub

    Private Sub rtbDebug_MouseLeave(sender As Object, e As EventArgs) Handles rtbDebug.MouseLeave
        ActiveControl = Nothing
    End Sub

    Private Sub cmsSelectFolder_Click(sender As Object, e As EventArgs) Handles cmsSelectFolder.Click
        Helper.SelectPso2Directory()
    End Sub

    Public Sub CheckForPluginUpdates(Optional Silent As Boolean = False)
        Dim NewInstall As Boolean = False
        'New method:
        'Have it download the JSON and check the MD5s, looking for the files in pso2_bin, disabled, and enabled. Once it finds them, save the path and check the MD5 - if it fails, replace the file *where it is*. No moving necessary!
        If Silent = False Then WriteDebugInfo("Checking for plugin updates...")
        If Directory.Exists(Program.PSO2RootDir & "\plugins\") = False Then
            NewInstall = True
            Directory.CreateDirectory(Program.PSO2RootDir & "\plugins\")
        End If
        If Directory.Exists(Program.PSO2RootDir & "\plugins\disabled\") = False Then Directory.CreateDirectory(Program.PSO2RootDir & "\plugins\disabled\")
        Dim JSONClient As New WebClient
        Dim pluginEntries As Dictionary(Of String, PluginClass) = JsonConvert.DeserializeObject(Of Dictionary(Of String, PluginClass))(DownloadString(Program.PluginURL & "plugins.json"))
        Dim localfilename As String = "nowhere"
        Dim Count As Integer = 0
        For Each item As KeyValuePair(Of String, PluginClass) In pluginEntries
            localfilename = "nowhere"
            If File.Exists(Program.PSO2RootDir & "\plugins\" & item.Value.Filename) = True Then
                If item.Value.Toggleable = "No" Then
                    Helper.Log("This file (" & item.Value.Filename & ") should not be in the plugins folder. We'll delete it.")
                    File.Delete(Program.PSO2RootDir & "\plugins\" & item.Value.Filename)
                Else
                    localfilename = Program.PSO2RootDir & "\plugins\" & item.Value.Filename
                End If
            End If

            If File.Exists(Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename) = True Then
                If item.Value.Toggleable = "No" Then
                    Helper.Log("This file (" & item.Value.Filename & ") should not be in the plugins folder. We'll delete it.")
                    File.Delete(Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename)
                Else
                    localfilename = Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename
                End If
            End If
            If File.Exists(Program.PSO2RootDir & "\" & item.Value.Filename) = True Then
                If item.Value.Toggleable = "Yes" Then
                    Helper.Log("This file (" & item.Value.Filename & ") should not be in the pso2_bin folder. We'll delete it.")
                    File.Delete(Program.PSO2RootDir & "\" & item.Value.Filename)
                Else
                    localfilename = Program.PSO2RootDir & "\" & item.Value.Filename
                End If
            End If
            If localfilename = "nowhere" Then
                If item.Value.Toggleable = "Yes" And item.Value.MD5Hash <> "No" Then
                    Helper.Log("Couldn't find " & item.Value.Filename & ", but it looks like it's an actual plugin. Let's put it in disabled!")
                    DownloadFile(Program.PluginURL & item.Value.Filename, Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename)
                    localfilename = Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename
                    Count += 1
                End If
                If item.Value.Toggleable = "No" And item.Value.MD5Hash <> "No" Then
                    Helper.Log("Couldn't find " & item.Value.Filename & ", but it looks like it's a plugin-related file. Let's put it in pso2_bin!")
                    DownloadFile(Program.PluginURL & item.Value.Filename, Program.PSO2RootDir & "\" & item.Value.Filename)
                    localfilename = Program.PSO2RootDir & "\" & item.Value.Filename
                    Count += 1
                End If
            End If
            If item.Value.MD5Hash <> "No" Then Helper.Log(item.Value.Filename & " should be: " & item.Value.MD5Hash & ". The local file (" & localfilename & ") is: " & Helper.GetMd5(localfilename).ToUpper)
            If item.Value.MD5Hash = "No" Then Helper.Log(item.Value.Filename & " should NOT be updated/checked. The local file is: " & localfilename & ".")
            If Helper.GetMd5(localfilename).ToUpper <> item.Value.MD5Hash And item.Value.MD5Hash <> "No" Then
                Helper.Log("It didn't match! Downloading " & item.Value.Filename)
                DownloadFile(Program.PluginURL & item.Value.Filename, localfilename)
                Count += 1
            End If
        Next
        If Count = 1 Then
            If Silent = False Then WriteDebugInfoSameLine("(" & Count & " plugin file updated)")
        Else
            If Silent = False Then WriteDebugInfoSameLine("(" & Count & " plugin files updated)")
        End If
        If NewInstall = True Then
            If File.Exists(Program.PSO2RootDir & "\plugins\TelepipeProxy.dll") = False Then
                Helper.Log("Auto enabling item/title patch since we had to recreate the plugin folder (and telepipe is disabled)")
                If File.Exists(Program.PSO2RootDir & "\plugins\disabled\translator.dll") Then File.Move(Program.PSO2RootDir & "\plugins\disabled\translator.dll", Program.PSO2RootDir & "\plugins\translator.dll")
                If File.Exists(Program.PSO2RootDir & "\plugins\disabled\PSO2TitleTranslator.dll") Then File.Move(Program.PSO2RootDir & "\plugins\disabled\PSO2TitleTranslator.dll", Program.PSO2RootDir & "\plugins\PSO2TitleTranslator.dll")
            End If
        End If
    End Sub
    Public Shared Sub ExtractFiles(ByVal FullFilename As String, ByVal DirectoryWithoutTrailingSlash As String)
        Try
            Using stream As Stream = File.OpenRead(FullFilename)
                Dim reader = ReaderFactory.Open(stream)
                While reader.MoveToNextEntry()
                    If Not reader.Entry.IsDirectory Then
                        reader.WriteEntryToDirectory(DirectoryWithoutTrailingSlash, ExtractOptions.Overwrite)
                    End If
                End While
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsmInstallEnglishLargeFiles_Click(sender As Object, e As EventArgs) Handles tsmInstallEnglishLargeFiles.Click
        InstallLargeFiles()
    End Sub

    Private Sub tsmInstallEnglishStoryPatch_Click(sender As Object, e As EventArgs) Handles tsmInstallEnglishStoryPatch.Click
        InstallStoryPatchNew()
    End Sub

    Private Sub rtbDebug_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles rtbDebug.LinkClicked
        Process.Start(e.LinkText)
    End Sub

    Private Sub tsmRestoreEnglishPatch_Click(sender As Object, e As EventArgs) Handles tsmRestoreEnglishPatch.Click
        If IsPso2WinDirMissing() Then Return
        If MsgBox("Are you sure you wish to continue? This will restore your backup from before you applied this patch.", vbYesNo) = MsgBoxResult.Yes Then RestoreBackup("English Patch")
    End Sub

    Private Sub tsmRestoreLargeFiles_Click(sender As Object, e As EventArgs) Handles tsmRestoreLargeFiles.Click
        If IsPso2WinDirMissing() Then Return
        If MsgBox("Are you sure you wish to continue? This will restore your backup from before you applied this patch.", vbYesNo) = MsgBoxResult.Yes Then RestoreBackup("Large Files")
    End Sub
    Private Sub UninstallPatch(patchName As String)
        Try
            If IsPso2WinDirMissing() Then Return
            WriteDebugInfo("Grabbing filelist...")
            Dim JSONClient As New WebClient
            Dim filelistjson As JObject = JObject.Parse(JSONClient.DownloadString(Program.FreedomUrl & "/filelists.json"))

            'DownloadFile(patchListUrl, patchListFile)
            If patchName = "English Patch" Then File.WriteAllText("filelist.txt", filelistjson.SelectToken("ENPatchList").ToString.Replace("\n", vbCrLf))
            If patchName = "Large Files" Then File.WriteAllText("filelist.txt", filelistjson.SelectToken("LargeFilesList").ToString.Replace("\n", vbCrLf))
            If patchName = "Story Patch" Then File.WriteAllText("filelist.txt", filelistjson.SelectToken("StoryList").ToString.Replace("\n", vbCrLf))
            If patchName = "Emergency Codes" Then File.WriteAllText("filelist.txt", "057aa975bdd2b372fe092614b0f4399e" & vbCrLf)
            If patchName = "Enemy Names" Then File.WriteAllText("filelist.txt", "ceffe0e2386e8d39f188358303a92a7d")
            Dim missingfiles = File.ReadAllLines("filelist.txt")

            'Helper.DeleteFile(patchListFile)
            WriteDebugInfo("Uninstalling patch (Downloading 0/" & missingfiles.Length & " files)...")

            For index As Integer = 0 To (missingfiles.Length - 1)
                If _cancelledFull Then Return

                'Download JP file
                'lblStatus.Text = "Redownloading " & index & "/" & missingfiles.Length
                rtbDebug.Text = rtbDebug.Text.Replace("Uninstalling patch (Downloading " & index - 1 & "/" & missingfiles.Length & " files)...", "Uninstalling patch (Downloading " & index & "/" & missingfiles.Length & " files)...")
                DownloadFile(("http://download.pso2.jp/patch_prod/patches/data/win32/" & missingfiles(index) & ".pat"), missingfiles(index))
                If New FileInfo(missingfiles(index)).Length = 0 Then DownloadFile(("http://download.pso2.jp/patch_prod/patches_old/data/win32/" & missingfiles(index) & ".pat"), missingfiles(index))

                'Move JP file to win32
                'Helper.DeleteFile((Program.PSO2WinDir & "\" & missingfiles(index)))
                File.Copy(missingfiles(index), (Program.PSO2WinDir & "\" & missingfiles(index)), True)
                File.Delete(missingfiles(index))
            Next
            rtbDebug.Text = rtbDebug.Text.Replace("Uninstalling patch (Downloading " & missingfiles.Length - 1 & "/" & missingfiles.Length & " files)...", "Uninstalling patch (Downloading " & missingfiles.Length & "/" & missingfiles.Length & " files)...")
            Helper.DeleteDirectory(BuildBackupPath(patchName))
            External.FlashWindow(Handle, True)
            WriteDebugInfo(patchName & " uninstalled!")
            If patchName = "English Patch" Then Program.SaveSetting("ENPatchVersion", "Not Installed")
            If patchName = "Large Files" Then Program.SaveSetting("LargeFilesVersion", "Not Installed")
            If patchName = "Story Patch" Then Program.SaveSetting("StoryPatchVersion", "Not Installed")

        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub
    Private Sub tsmUninstallEnglishPatch_Click(sender As Object, e As EventArgs) Handles tsmUninstallEnglishPatch.Click
        UninstallPatch("English Patch")
    End Sub

    Private Sub tsmUninstallLargeFiles_Click(sender As Object, e As EventArgs) Handles tsmUninstallLargeFiles.Click
        UninstallPatch("Large Files")
    End Sub

    Private Sub tsmUninstallStory_Click(sender As Object, e As EventArgs) Handles tsmUninstallStory.Click
        UninstallPatch("Story Patch")
    End Sub

    Private Sub tsmRevertECodes_Click(sender As Object, e As EventArgs) Handles tsmRevertECodes.Click
        UninstallPatch("Emergency Codes")
    End Sub

    Private Sub tsmRevertENNames_Click(sender As Object, e As EventArgs) Handles tsmRevertENNames.Click
        UninstallPatch("Enemy Names")
    End Sub

    Private Sub tsmAnalyzeInstall_Click(sender As Object, e As EventArgs) Handles tsmAnalyzeInstall.Click
        Dim pso2Launchpath As String = Program.PSO2WinDir.Replace("data\win32", "")
        WriteDebugInfo("Checking for necessary files...")
        If Not File.Exists(pso2Launchpath & "Gameguard.DES") Then WriteDebugInfoAndWarning("Missing GameGuard.DES file! Please run Troubleshooting -> Fix Gameguard issues!")
        If Not File.Exists(pso2Launchpath & "pso2.exe") Then WriteDebugInfoAndWarning("Missing pso2.exe file! Please run Troubleshooting -> Fix PSO2 EXEs!")
        If Not File.Exists(pso2Launchpath & "pso2launcher.exe") Then WriteDebugInfoAndWarning("Missing pso2launcher.exe file! Please run Troubleshooting -> Fix PSO2 EXEs!")
        If Not File.Exists(pso2Launchpath & "pso2updater.exe") Then WriteDebugInfoAndWarning("Missing pso2updater.exe file! Please run Troubleshooting -> Fix PSO2 EXEs!")
        WriteDebugInfoSameLine("Done!")
        WriteDebugInfo("Checking for folders...")
        If Not Directory.Exists(pso2Launchpath & "\Gameguard\") Then WriteDebugInfoAndWarning("Missing Gameguard folder! Please run Troubleshooting -> Fix Gameguard issues!")
        If Not Directory.Exists(pso2Launchpath & "\data\") Then WriteDebugInfoAndWarning("Missing data folder! Please reinstall PSO2 or check that you selected the correct pso2_bin directory!")
        If Not Directory.Exists(pso2Launchpath & "\data\win32\") Then WriteDebugInfoAndWarning("Missing data\win32 folder! Please reinstall PSO2 or check that you selected the correct pso2_bin directory!")
        WriteDebugInfoSameLine("Done!")
        WriteDebugInfo("Done testing! If you received any errors here, please carry out the recommended steps.")
    End Sub

    Private Sub tsmCheckForDeletedOrEmptyFiles_Click(sender As Object, e As EventArgs) Handles tsmCheckForDeletedOrEmptyFiles.Click
        Helper.Log("User click 'Check for deleted or empty files'.")
        If IsPso2WinDirMissing() Then Return
        Dim filename As String()
        Dim truefilename As String
        Dim missingfiles As New List(Of String)
        Dim filename2 As String()
        Dim truefilename2 As String
        Dim missingfiles2 As New List(Of String)
        Dim numberofChecks As Integer = 0

        Helper.Log("Downloading Patch file #1...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/launcherlist.txt", "launcherlist.txt")
        Helper.Log("Downloading Patch file #2...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/patchlist.txt", "patchlist.txt")
        Helper.Log("Downloading Patch file #3...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches_old/patchlist.txt", "patchlist_old.txt")
        Helper.Log("Downloading Patch file #4...")
        Application.DoEvents()
        DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")
        Application.DoEvents()

        Helper.Log("Opening patch file list...")
        WriteDebugInfo("Restoring openings/logos....")
        If _cancelledFull Then Return
        If File.Exists((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927")) Then
            If File.Exists((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927")) Then Helper.DeleteFile((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927"))
            File.Move((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927"), (Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927"))
        End If
        If File.Exists((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75")) Then
            If File.Exists((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75")) Then Helper.DeleteFile((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75"))
            File.Move((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75"), (Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75"))
        End If
        If File.Exists((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771")) Then
            If File.Exists((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771")) Then Helper.DeleteFile((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771"))
            File.Move((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771"), (Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771"))
        End If
        If File.Exists((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585")) Then
            If File.Exists((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585")) Then Helper.DeleteFile((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585"))
            File.Move((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585"), (Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585"))
        End If
        WriteDebugInfo("Checking files... (Currently checking file #" & numberofChecks & ")")
        For Each line In Helper.GetLines("patchlist.txt")
            If _cancelledFull Then Return
            filename = Regex.Split(line, ".pat")
            truefilename = filename(0).Replace("data/win32/", "")
            If CheckFilesAreValid(truefilename) Then
                Dim length2 As Long
                If File.Exists(Program.PSO2WinDir & "\" & truefilename) Then length2 = New FileInfo(Program.PSO2WinDir & "\" & truefilename).Length
                If Not File.Exists((Program.PSO2WinDir & "\" & truefilename)) Then
                    Helper.Log(truefilename & " is missing.")
                    missingfiles.Add(truefilename)
                End If
                If File.Exists(Program.PSO2WinDir & "\" & truefilename) Then length2 = New FileInfo(Program.PSO2WinDir & "\" & truefilename).Length
                If Not File.Exists(Program.PSO2WinDir & "\" & truefilename) Then length2 = 1
                If length2 = 0 Then
                    Helper.Log(truefilename & " has a filesize of 0!")
                    missingfiles.Add(truefilename)
                    Helper.DeleteFile(Program.PSO2WinDir & "\" & truefilename)
                End If
            End If
            numberofChecks += 1
            rtbDebug.Text = rtbDebug.Text.Replace("Checking files... (Currently checking file #" & numberofChecks - 1 & ")", "Checking files... (Currently checking file #" & numberofChecks & ")")
            'lblStatus.Text = ("Currently checking file #" & numberofChecks)
            Application.DoEvents()
        Next

        Helper.Log("Opening Second patch file...")
        For Each line In Helper.GetLines("patchlist_old.txt")
            If _cancelledFull Then Return
            filename2 = Regex.Split(line, ".pat")
            truefilename2 = filename2(0).Replace("data/win32/", "")
            If CheckFilesAreValid(truefilename2) Then
                Dim length2 As Long
                If File.Exists(Program.PSO2WinDir & "\" & truefilename2) Then length2 = New FileInfo(Program.PSO2WinDir & "\" & truefilename2).Length
                If Not File.Exists((Program.PSO2WinDir & "\" & truefilename2)) Then
                    If Not missingfiles.Contains(truefilename2) Then
                        Helper.Log(truefilename2 & " is missing.")
                        missingfiles2.Add(truefilename2)
                    End If
                End If
                If File.Exists(Program.PSO2WinDir & "\" & truefilename2) Then length2 = New FileInfo(Program.PSO2WinDir & "\" & truefilename2).Length
                If Not File.Exists(Program.PSO2WinDir & "\" & truefilename2) Then length2 = 1
                If length2 = 0 Then
                    Helper.Log(truefilename2 & " has a filesize of 0!")
                    missingfiles.Add(truefilename2)
                    Helper.DeleteFile(Program.PSO2WinDir & "\" & truefilename2)
                End If
            End If
            numberofChecks += 1
            'lblStatus.Text = ("Currently checking file #" & numberofChecks) 
            rtbDebug.Text = rtbDebug.Text.Replace("Checking files... (Currently checking file #" & numberofChecks - 1 & ")", "Checking files... (Currently checking file #" & numberofChecks & ")")
            Application.DoEvents()
        Next

        If missingfiles.Count = 0 AndAlso missingfiles2.Count = 0 Then
            WriteDebugInfoAndOk("All files checked out!")
            Return
        End If

        Dim result1 As DialogResult = MessageBox.Show("Would you like to download and install the missing files?", "Download/Install?", MessageBoxButtons.YesNo)

        If result1 = DialogResult.Yes Then
            Helper.Log("Downloading missing files (part 1)")
            Dim totaldownload As Long = missingfiles.Count
            Dim downloaded As Long = 0
            Dim totaldownloaded As Long = 0
            Helper.DeleteFile("resume.txt")

            File.AppendAllLines("resume.txt", missingfiles)
            WriteDebugInfo("Downloading " & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded) & ")")
            For Each downloadStr As String In missingfiles
                'Download the missing files:
                _cancelled = False
                downloaded += 1
                totaldownloaded += _totalsize2
                rtbDebug.Text = rtbDebug.Text.Replace("Downloading " & downloaded - 1 & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded - _totalsize2) & ")", "Downloading " & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded) & ")")
                'lblStatus.Text = "Downloading " & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloaded) & ")"

                DownloadFile(("http://download.pso2.jp/patch_prod/patches/data/win32/" & downloadStr & ".pat"), downloadStr)

                If New FileInfo(downloadStr).Length = 0 Then
                    Helper.Log("File appears to be empty, trying to download from secondary SEGA server")
                    DownloadFile(("http://download.pso2.jp/patch_prod/patches_old/data/win32/" & downloadStr & ".pat"), downloadStr)
                End If

                If _cancelled Then Return
                File.Move(downloadStr, (Program.PSO2WinDir & "\" & downloadStr))
                WriteDebugInfoAndOk(("Downloaded/Installed " & downloadStr & "."))
                Dim linesList As New List(Of String)(File.ReadAllLines("resume.txt"))

                'Remove the line to delete, e.g.
                linesList.Remove(downloadStr)

                File.WriteAllLines("resume.txt", linesList.ToArray())
                If _cancelledFull Then Return
            Next

            Helper.Log("Downloading missing files (part 2)")

            Helper.DeleteFile("resume.txt")

            File.AppendAllLines("resume.txt", missingfiles2)

            Dim totaldownload2 As Long = missingfiles2.Count
            Dim downloaded2 As Long = 0
            Dim totaldownloaded2 As Long = 0

            For Each downloadstring2 In missingfiles2
                If _cancelledFull Then Return
                'Download the missing files:
                If Not File.Exists((Program.PSO2WinDir & "\" & downloadstring2)) Then
                    _cancelled = False
                    downloaded2 += 1
                    totaldownloaded2 += _totalsize2
                    rtbDebug.Text = rtbDebug.Text.Replace("Downloading " & downloaded2 - 1 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded2 - _totalsize2) & ")", "Downloading " & downloaded2 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded2) & ")")
                    'lblStatus.Text = "Downloading " & downloaded2 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded2) & ")"

                    DownloadFile(("http://download.pso2.jp/patch_prod/patches/data/win32/" & downloadstring2 & ".pat"), downloadstring2)

                    If New FileInfo(downloadstring2).Length = 0 Then
                        Helper.Log("File appears to be empty, trying to download from secondary SEGA server")
                        DownloadFile(("http://download.pso2.jp/patch_prod/patches_old/data/win32/" & downloadstring2 & ".pat"), downloadstring2)
                    End If

                    If _cancelled Then Return
                    File.Move(downloadstring2, (Program.PSO2WinDir & "\" & downloadstring2))
                    WriteDebugInfoAndOk(("Downloaded/Installed " & downloadstring2 & "."))
                    Dim linesList As New List(Of String)(File.ReadAllLines("resume.txt"))

                    'Remove the line to delete, e.g.
                    linesList.Remove(downloadstring2)
                    File.WriteAllLines("resume.txt", linesList.ToArray())
                End If
            Next
            WriteDebugInfoAndOk("All done!")
        End If
    End Sub
    Public Shared Function CheckFilesAreValid(trueFilename As String) As Boolean
        If trueFilename.Contains("license") Or trueFilename.Contains(".dll") Then Return False
        If trueFilename = "GameGuard.des" Or trueFilename = "edition.txt" Or trueFilename = "gameversion.ver" Or trueFilename = "pso2.exe" Or trueFilename = "PSO2JP.ini" Or trueFilename = "script/user_default.pso2" Or trueFilename = "script/user_intel.pso2" Then Return False
        If trueFilename = "ffbff2ac5b7a7948961212cefd4d402c" Then Return False
        If trueFilename.Contains("version.ver") Then Return False
        Return True
    End Function

    Private Async Sub tsmCheckForOldOrMissingFiles_Click(sender As Object, e As EventArgs) Handles tsmCheckForOldOrMissingFiles.Click
        Helper.Log("User clicked 'Check for old or missing files files' (QUANTUM)")
        Helper.Log("Deleting the JSONs (if they exists) just in case.")
        If File.Exists("patchlist.json") Then Helper.DeleteFile("patchlist.json")
        If File.Exists("missing.json") Then Helper.DeleteFile("missing.json")
        If File.Exists("client.json") Then Helper.DeleteFile("client.json")
        Dim SkipClient As New WebClient
        Helper.Log("Downloading the list of files to skip...")
        SkipClient.DownloadFile(Program.FreedomUrl & "skip.txt", "skip.txt")

        RegKey.SetValue(Of String)("PSO2Dir", Program.GetSetting("PSO2Dir"))
        ' Use IOC Container in the main Tweaker project to deal with dependencies.
        Dim output As New TweakerTrigger
        Dim Settings = New JsonTweakerSettings(Program.AppData & "/PSO2 Tweaker/settings.json")
        Dim updater = New UpdateManager(Settings, output)
        'await updater.CleanLegacyFiles();

        'Console.WriteLine(settings.GameDirectory)
        frmDownloader.CleanupUI()
        Await updater.Update(True, False)
    End Sub

    Private Sub tsmCheckForOldOrMissingFilesOldMethod_Click(sender As Object, e As EventArgs) Handles tsmCheckForOldOrMissingFilesOldMethod.Click
        Helper.Log("User clicked 'Check for old or missing files files' (NON-QUANTUM)")
        Dim ContinueYesNo As MsgBoxResult = MsgBox("WARNING: Checking with this old method will erase your saved QUANTUM data, and you'll have to recheck everything through QUANTUM next time you run it. Continue?", vbYesNo)
        If ContinueYesNo = vbNo Then Exit Sub

        Helper.Log("Downloading Patch file #1...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/launcherlist.txt", "launcherlist.txt")
        Helper.Log("Downloading Patch file #2...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/patchlist.txt", "patchlist.txt")
        Helper.Log("Downloading Patch file #3...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches_old/patchlist.txt", "patchlist_old.txt")
        Helper.Log("Downloading Patch file #4...")
        Application.DoEvents()
        Program.Client.DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")
        Application.DoEvents()

        WriteDebugInfo("Checking for missing/old files...")
        _cancelledFull = False
        UpdatePSO2(False)
    End Sub
    Private Sub UpdatePSO2(comingFromOldFiles As Boolean)
        btnStartPSO2.Enabled = False
        _cancelledFull = False
        If IsPso2WinDirMissing() Then Return
        Dim missingfiles As New List(Of String)
        Dim missingfiles2 As New List(Of String)
        Dim numberofChecks As Integer = 0
        Dim totalfilesize As Long = 0
        Dim testfilesize As String()
        'lblStatus.Text = ""

        If File.Exists("client.json") Then Helper.DeleteFile("client.json")
        If File.Exists("missing.json") Then Helper.DeleteFile("missing.json")
        If File.Exists("patchlist.json") Then Helper.DeleteFile("patchlist.json")

        If Directory.Exists(BuildBackupPath("English Patch")) Then
            WriteDebugInfo("EN backup found, restoring...")
            RestoreBackup("English Patch")
        End If

        If Directory.Exists(BuildBackupPath("Large Files")) Then
            WriteDebugInfo("Large Files backup found, restoring...")
            RestoreBackup("Large Files")
        End If

        If Directory.Exists(BuildBackupPath("Story Patch")) Then
            WriteDebugInfo("Story patch backup found, restoring...")
            RestoreBackup("Story Patch")
        End If

        Helper.Log("Downloading Patch file #1...")

        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/launcherlist.txt", "launcherlist.txt")
        Helper.Log("Downloading Patch file #2...")

        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/patchlist.txt", "patchlist.txt")
        Helper.Log("Downloading Patch file #3...")

        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches_old/patchlist.txt", "patchlist_old.txt")
        Helper.Log("Downloading Patch file #4...")

        Application.DoEvents()
        Program.Client.DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")
        Application.DoEvents()


        'Const result As MsgBoxResult = MsgBoxResult.No
        'If result = MsgBoxResult.Yes OrElse _comingFromOldFiles Then
        If comingFromOldFiles Then
            numberofChecks = 0
            WriteDebugInfo("Checking for new content... (Checking #" & numberofChecks & ")")

            If _cancelledFull Then Return
            For Each line In Helper.GetLines("patchlist.txt")
                If _cancelledFull Then Return
                Dim filename As String() = Regex.Split(line, ".pat")
                Dim truefilename As String = filename(0).Replace("data/win32/", "")
                Dim trueMd5 As String = filename(1).Split(ControlChars.Tab)(2)
                If CheckFilesAreValid(truefilename) Then
                    If Not File.Exists((Program.PSO2WinDir & "\" & truefilename)) Then
                        missingfiles.Add(truefilename)
                    ElseIf Helper.GetMd5((Program.PSO2WinDir & "\" & truefilename)) <> trueMd5 Then
                        missingfiles.Add(truefilename)
                    End If
                End If

                numberofChecks += 1
                'lblStatus.Text = ("Currently checking file #" & numberofChecks )
                rtbDebug.Text = rtbDebug.Text.Replace("Checking for new content... (Checking #" & numberofChecks - 1 & ")", "Checking for new content... (Checking #" & numberofChecks & ")")
                Application.DoEvents()
            Next

            Helper.DeleteFile("Resume.txt")
            File.AppendAllLines("Resume.txt", missingfiles)
            Dim totaldownload As Long = missingfiles.Count
            Dim downloaded As Long = 0
            Dim totaldownloadedthings As Long = 0
            WriteDebugInfo("Downloading " & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloadedthings) & ")")
            For Each downloadStr In missingfiles
                If _cancelledFull Then Return
                'Download the missing files:
                'WHAT THE FUCK IS GOING ON HERE?
                downloaded += 1
                totaldownloadedthings += _totalsize2
                'lblStatus.Text = "Downloading " & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloadedthings) & ")" 
                rtbDebug.Text = rtbDebug.Text.Replace("Downloading " & downloaded - 1 & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloadedthings - _totalsize2) & ")", "Downloading " & downloaded & "/" & totaldownload & " (" & Helper.SizeSuffix(totaldownloadedthings) & ")")
                Application.DoEvents()
                _cancelled = False
                Try

                    DownloadFile(("http://download.pso2.jp/patch_prod/patches/data/win32/" & downloadStr & ".pat"), downloadStr)

                    If New FileInfo(downloadStr).Length = 0 Then
                        Helper.Log("File appears to be empty, trying to download from secondary SEGA server")
                        DownloadFile(("http://download.pso2.jp/patch_prod/patches_old/data/win32/" & downloadStr & ".pat"), downloadStr)
                    End If

                Catch ex As Exception
                    Helper.LogWithException("Error downloading file - ", ex)
                End Try
                If _cancelled Then Return
                Helper.DeleteFile((Program.PSO2WinDir & "\" & downloadStr))
                File.Move(downloadStr, (Program.PSO2WinDir & "\" & downloadStr))
                Helper.Log(downloadStr & " downloaded and installed! (" & New FileInfo(Program.PSO2WinDir & "\" & downloadStr).Length & ")")
                Dim linesList As New List(Of String)(File.ReadAllLines("resume.txt"))

                'Remove the line to delete, e.g.
                linesList.Remove(downloadStr)

                File.WriteAllLines("resume.txt", linesList.ToArray())
                Application.DoEvents()
            Next

            If missingfiles.Count = 0 Then WriteDebugInfo("You appear to have the latest data files - Running final update steps!")
            Dim directoryStringthing As String = (Program.PSO2RootDir & "\")
            WriteDebugInfo("Downloading version file...")
            Application.DoEvents()
            _cancelled = False
            Program.Client.DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")
            If _cancelled Then Return
            If File.Exists((_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver")) Then Helper.DeleteFile((_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver"))
            File.Copy("version.ver", (_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver"))
            WriteDebugInfoAndOk(("Downloaded And installed version file"))

            WriteDebugInfo("Downloading pso2launcher.exe...")
            Application.DoEvents()
            For Each proc As Process In Process.GetProcessesByName("pso2launcher")
                If proc.MainWindowTitle = "PHANTASY STAR ONLINE 2" AndAlso proc.MainModule.ToString() = "ProcessModule (pso2launcher.exe)" Then proc.Kill()
            Next

            DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2launcher.exe.pat", "pso2launcher.exe")
            If _cancelled Then Return
            If File.Exists((directoryStringthing & "pso2launcher.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryStringthing & "pso2launcher.exe"))
            File.Move("pso2launcher.exe", (directoryStringthing & "pso2launcher.exe"))
            WriteDebugInfoAndOk(("Downloaded And installed pso2launcher.exe"))
            WriteDebugInfo("Downloading pso2updater.exe...")
            Application.DoEvents()
            For Each proc As Process In Process.GetProcessesByName("pso2updater")
                If proc.MainModule.ToString() = "ProcessModule (pso2updater.exe)" Then proc.Kill()
            Next

            DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2updater.exe.pat", "pso2updater.exe")
            If _cancelled Then Return
            If File.Exists((directoryStringthing & "pso2updater.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryStringthing & "pso2updater.exe"))
            File.Move("pso2updater.exe", (directoryStringthing & "pso2updater.exe"))
            WriteDebugInfoAndOk(("Downloaded And installed pso2updater.exe"))
            Application.DoEvents()

            WriteDebugInfo("Downloading pso2.exe...")
            For Each proc As Process In Process.GetProcessesByName("pso2")
                If proc.MainModule.ToString() = "ProcessModule (pso2.exe)" Then proc.Kill()
            Next

            DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2.exe.pat", "pso2.exe")
            If _cancelled Then Return

            If File.Exists((directoryStringthing & "pso2.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryStringthing & "pso2.exe"))
            File.Move("pso2.exe", (directoryStringthing & "pso2.exe"))
            If _cancelledFull Then Return
            WriteDebugInfoAndOk(("Downloaded And installed pso2.exe"))
            Program.SaveSetting("StoryPatchVersion", "Not Installed")
            Program.SaveSetting("ENPatchVersion", "Not Installed")
            Program.SaveSetting("LargeFilesVersion", "Not Installed")
            WriteDebugInfo("Game updated to latest Vanilla JP version. Don't forget to re-install the patches!")
            Helper.DeleteFile("resume.txt")
            Program.SaveSetting("PSO2RemoteVersion", File.ReadAllLines("version.ver")(0))


            WriteDebugInfoAndOk("All done!")
            btnStartPSO2.Enabled = True
            Return
        End If

        If _cancelledFull Then Return
        Dim mergedPatches = MergePatches()
        WriteDebugInfo("Checking for all files...")

        mergedPatches.Remove("GameGuard.des")
        mergedPatches.Remove("PSO2JP.ini")
        mergedPatches.Remove("script/user_default.pso2")
        mergedPatches.Remove("script/user_intel.pso2")
        mergedPatches.Remove("")

        If mergedPatches.ContainsKey("pso2.exe") Then
            mergedPatches.Remove("pso2.exe")
        End If

        Dim dataPath = Program.PSO2RootDir & "\data\win32\"
        Dim length = mergedPatches.Count
        'Dim oldmax = PBMainBar.Maximum
        'PBMainBar.Maximum = length
        _cancelled = False

        Dim fileLengths = New DirectoryInfo(dataPath).EnumerateFiles().ToDictionary(Function(fileinfo) fileinfo.Name, Function(fileinfo) fileinfo.Length)
        Dim fileNames = fileLengths.Keys
        WriteDebugInfo("Currently checking file #0")
        For Each kvp In mergedPatches

            'If _cancelled Then
            '    PBMainBar.Text = ""
            '    PBMainBar.Value = 0
            '    PBMainBar.Maximum = oldmax
            '    _cancelled = False
            '    Return
            'End If

            'lblStatus.Text = "Currently checking file #" & numberofChecks
            'PBMainBar.Text = numberofChecks & " / " & length
            If (numberofChecks Mod 8) = 0 Then Application.DoEvents()
            numberofChecks += 1
            rtbDebug.Text = rtbDebug.Text.Replace("Currently checking file #" & numberofChecks - 1, "Currently checking file #" & numberofChecks)
            'PBMainBar.Value += 1

            If Not fileNames.Contains(kvp.Key) Then
                testfilesize = kvp.Value.Split(ControlChars.Tab)
                totalfilesize += Convert.ToInt32(testfilesize(1))
                missingfiles2.Add(kvp.Key)
                Continue For
            End If

            testfilesize = kvp.Value.Split(ControlChars.Tab)
            Dim fileSize = Convert.ToInt32(testfilesize(1))

            If fileSize <> fileLengths(kvp.Key) Then
                totalfilesize += fileSize
                missingfiles2.Add(kvp.Key)
                Continue For
            End If

            Using stream = New FileStream(dataPath & kvp.Key, FileMode.Open)
                If Helper.GetMd5(stream) <> testfilesize(2) And CheckFilesAreValid(kvp.Key) Then
                    totalfilesize += fileSize
                    missingfiles2.Add(kvp.Key)
                End If
            End Using
        Next

        'PBMainBar.Text = ""
        'PBMainBar.Value = 0
        'PBMainBar.Maximum = oldmax

        Dim totaldownload2 As Long = missingfiles2.Count
        Dim downloaded2 As Long = 0
        Dim totaldownloaded As Long = 0
        WriteDebugInfo("Downloading " & downloaded2 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded) & " / " & Helper.SizeSuffix(totalfilesize) & ")")
        Helper.DeleteFile("Resume.txt")
        File.WriteAllLines("Resume.txt", missingfiles2.ToArray())
        'SON OF A BITCH
        For Each downloadStr In missingfiles2
            If _cancelledFull Then Return
            'Download the missing files:
            'WHAT THE FUCK IS GOING ON HERE?
            downloaded2 += 1
            totaldownloaded += _totalsize2

            'lblStatus.Text = "Downloading " & downloaded2 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded) & " / " & Helper.SizeSuffix(totalfilesize) & ")"
            rtbDebug.Text = rtbDebug.Text.Replace("Downloading " & downloaded2 - 1 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded - _totalsize2) & " / " & Helper.SizeSuffix(totalfilesize) & ")", "Downloading " & downloaded2 & "/" & totaldownload2 & " (" & Helper.SizeSuffix(totaldownloaded) & " / " & Helper.SizeSuffix(totalfilesize) & ")")
            Application.DoEvents()
            DownloadFile(("http://download.pso2.jp/patch_prod/patches/data/win32/" & downloadStr & ".pat"), downloadStr)
            If New FileInfo(downloadStr).Length = 0 Then
                Helper.Log("File appears to be empty, trying to download from secondary SEGA server")
                DownloadFile(("http://download.pso2.jp/patch_prod/patches_old/data/win32/" & downloadStr & ".pat"), downloadStr)
            End If
            If New FileInfo(downloadStr).Length = 0 Then
                Helper.DeleteFile(downloadStr)
                DownloadFile(("http://download.pso2.jp/patch_prod/patches_old/data/win32/" & downloadStr & ".pat"), downloadStr)
            End If

            If File.Exists(downloadStr) Then
                Helper.DeleteFile((Program.PSO2WinDir & "\" & downloadStr))
                File.Move(downloadStr, (Program.PSO2WinDir & "\" & downloadStr))
                Dim linesList As New List(Of String)(File.ReadAllLines("resume.txt"))

                'Remove the line to delete, e.g.
                linesList.Remove(downloadStr)

                File.WriteAllLines("resume.txt", linesList.ToArray())
            End If
            Application.DoEvents()
        Next

        If missingfiles.Count = 0 Then WriteDebugInfo("You appear to have the latest data files - Running final update steps!")
        Dim directoryString As String = (Program.PSO2RootDir & "\")
        WriteDebugInfo("Downloading version file...")
        Application.DoEvents()
        Program.Client.DownloadFile("http://arks-layer.com/vanila/version.txt", "version.ver")
        If File.Exists((_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver")) Then Helper.DeleteFile((_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver"))
        File.Copy("version.ver", (_myDocuments & "\SEGA\PHANTASYSTARONLINE2\version.ver"))
        WriteDebugInfoAndOk(("Downloaded and installed version file"))

        WriteDebugInfo("Downloading pso2launcher.exe...")
        Application.DoEvents()
        DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2launcher.exe.pat", "pso2launcher.exe")
        If File.Exists((directoryString & "pso2launcher.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryString & "pso2launcher.exe"))
        File.Move("pso2launcher.exe", (directoryString & "pso2launcher.exe"))
        WriteDebugInfoAndOk(("Downloaded and installed pso2launcher.exe"))
        WriteDebugInfo("Downloading pso2updater.exe...")
        Application.DoEvents()

        WriteDebugInfo("Downloading pso2.exe...")
        DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2.exe.pat", "pso2.exe")
        If _cancelled Then Return

        If File.Exists((directoryString & "pso2.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryString & "pso2.exe"))
        File.Move("pso2.exe", (directoryString & "pso2.exe"))
        If _cancelledFull Then Return
        WriteDebugInfoAndOk(("Downloaded and installed pso2.exe"))

        Program.SaveSetting("StoryPatchVersion", "Not Installed")
        Program.SaveSetting("ENPatchVersion", "Not Installed")
        Program.SaveSetting("LargeFilesVersion", "Not Installed")
        WriteDebugInfo("Game updated to latest Vanilla JP version. Don't forget to re-install the patches!")
        Helper.DeleteFile("resume.txt")
        Program.SaveSetting("PSO2RemoteVersion", File.ReadAllLines("version.ver")(0))
        Helper.DeleteFile("version.ver")

        WriteDebugInfoAndOk("All done!")
        btnStartPSO2.Enabled = True
    End Sub
    Private Shared Function MergePatches() As Dictionary(Of String, String)
        Dim patchlist As String() = File.ReadAllLines("patchlist.txt")
        Dim patchlistOld As String() = File.ReadAllLines("patchlist_old.txt")

        Dim result = New Dictionary(Of String, String)

        For index As Integer = 0 To (patchlist.Length - 1)
            Dim currentLine = patchlist(index)
            If String.IsNullOrEmpty(currentLine) Then Continue For

            Dim filename = Regex.Split(currentLine, ".pat")
            If String.IsNullOrEmpty(filename(0)) Then Continue For

            Dim key = filename(0).Replace("data/win32/", "")

            If Not result.ContainsKey(key) And CheckFilesAreValid(key) Then
                result.Add(key, currentLine)
            End If
        Next

        For index As Integer = 0 To (patchlistOld.Length - 1)
            Dim currentLine = patchlistOld(index)
            If String.IsNullOrEmpty(currentLine) Then Continue For

            Dim filename = Regex.Split(currentLine, ".pat")
            If String.IsNullOrEmpty(filename(0)) Then Continue For

            Dim key = filename(0).Replace("data/win32/", "")

            If Not result.ContainsKey(key) And CheckFilesAreValid(key) Then
                result.Add(key, currentLine)
            End If
        Next

        Return result
    End Function

    Private Sub tsmFixGameGuardErrors_Click(sender As Object, e As EventArgs) Handles tsmFixGameGuardErrors.Click
        Try
            Dim systempath As String
            MsgBox("Please be aware that this will fix SOME Gameguard errors, but will not fix all of them. Make sure anything that could possibly ""scan"" PSO2 is disabled (Firewalls, debuggers, antivirus, Speed boosters, etc).")

            If Directory.Exists(Program.PSO2RootDir & "\Gameguard\") Then
                WriteDebugInfo("Removing Gameguard Directory...")
                Directory.Delete(Program.PSO2RootDir & "\Gameguard\", True)
                WriteDebugInfoSameLine("Done!")
            End If
            If File.Exists(Program.PSO2RootDir & "\GameGuard.des") Then
                WriteDebugInfo("Removing Gameguard File...")
                Helper.DeleteFile(Program.PSO2RootDir & "\GameGuard.des")
                WriteDebugInfoSameLine("Done!")
            End If
            If Environment.Is64BitOperatingSystem Then
                systempath = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86)
                If File.Exists(systempath & "\npptnt2.sys") Then
                    WriteDebugInfo("Removing Hidden Gameguard Files (1 of 3)...")
                    Helper.DeleteFile(systempath & "\npptnt2.sys")
                    WriteDebugInfoSameLine("Done!")
                End If
                If File.Exists(systempath & "\nppt9x.vxd") Then
                    WriteDebugInfo("Removing Hidden Gameguard Files (2 of 3)...")
                    Helper.DeleteFile(systempath & "\nppt9x.vxd")
                    WriteDebugInfoSameLine("Done!")
                End If
                If File.Exists(systempath & "\GameMon.des") Then
                    WriteDebugInfo("Removing Hidden Gameguard Files (3 of 3)...")
                    Helper.DeleteFile(systempath & "\GameMon.des")
                    WriteDebugInfoSameLine("Done!")
                End If
            End If
            If Not Environment.Is64BitOperatingSystem Then
                systempath = Environment.GetFolderPath(Environment.SpecialFolder.System)
                If File.Exists(systempath & "\npptnt2.sys") Then
                    WriteDebugInfo("Removing Hidden Gameguard Files (1 of 3)...")
                    Helper.DeleteFile(systempath & "\npptnt2.sys")
                    WriteDebugInfoSameLine("Done!")
                End If
                If File.Exists(systempath & "\nppt9x.vxd") Then
                    WriteDebugInfo("Removing Hidden Gameguard Files (2 of 3)...")
                    Helper.DeleteFile(systempath & "\nppt9x.vxd")
                    WriteDebugInfoSameLine("Done!")
                End If
                If File.Exists(systempath & "\GameMon.des") Then
                    WriteDebugInfo("Removing Hidden Gameguard Files (3 of 3)...")
                    Helper.DeleteFile(systempath & "\GameMon.des")
                    WriteDebugInfoSameLine("Done!")
                End If
            End If
            WriteDebugInfo("Downloading Latest Gameguard file...")
            DownloadFile("http://download.pso2.jp/patch_prod/patches/GameGuard.des.pat", Program.PSO2RootDir & "\GameGuard.des")
            WriteDebugInfo("Downloading Latest Gameguard config...")
            DownloadFile("http://download.pso2.jp/patch_prod/patches/PSO2JP.ini.pat", Program.PSO2RootDir & "\PSO2JP.ini")
            WriteDebugInfoSameLine("Done!")
            'File.Move("GameGuard.des", Program.Pso2RootDir & "\GameGuard.des")

            Dim foundKey As RegistryKey = Computer.Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\npggsvc", True)

            If foundKey Is Nothing Then
                WriteDebugInfo("No registry keys to delete. This is OK, they should be created the next time Gameguard launches.")
            Else
                WriteDebugInfo("Deleting Gameguard registry keys...")
                foundKey = Computer.Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services", True)
                foundKey.DeleteSubKeyTree("npggsvc")
                WriteDebugInfoSameLine("Done!")
            End If
            WriteDebugInfoAndOk("GameGuard reset to defaults! Now try running Phantasy Star Online 2 - It should update Gameguard when the PSO2 logo comes up.")
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
            If ex.Message.Contains("Access to the ") Then MsgBox("It looks like Gameguard believes it's open, whether or not it actually is. You'll need to restart your computer to fix this problem. Sorry!")
        End Try
    End Sub

    Private Sub tsmFixPSO2EXEs_Click(sender As Object, e As EventArgs) Handles tsmFixPSO2EXEs.Click
        Try
            If IsPso2WinDirMissing() Then Return
            Dim directoryString As String = (Program.PSO2RootDir & "\")
            _cancelled = False
            WriteDebugInfo("Downloading pso2launcher.exe...")

            Application.DoEvents()
            Dim procs As Process() = Process.GetProcessesByName("pso2launcher")

            For Each proc As Process In procs
                If proc.MainWindowTitle = "PHANTASY STAR ONLINE 2" AndAlso proc.MainModule.ToString() = "ProcessModule (pso2launcher.exe)" Then proc.Kill()
            Next

            DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2launcher.exe.pat", "pso2launcher.exe")
            If _cancelled Then Return

            ' never mind I'll just rewrite it later or something idk
            If File.Exists((directoryString & "pso2launcher.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryString & "pso2launcher.exe"))
            File.Move("pso2launcher.exe", (directoryString & "pso2launcher.exe"))
            WriteDebugInfoAndOk(("Downloaded and installed pso2launcher.exe"))
            WriteDebugInfo("Downloading pso2updater.exe...")
            Application.DoEvents()
            procs = Process.GetProcessesByName("pso2updater")
            For Each proc As Process In procs
                If proc.MainModule.ToString() = "ProcessModule (pso2updater.exe)" Then proc.Kill()
            Next
            DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2updater.exe.pat", "pso2updater.exe")
            If _cancelled Then Return

            If File.Exists((directoryString & "pso2updater.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryString & "pso2updater.exe"))
            File.Move("pso2updater.exe", (directoryString & "pso2updater.exe"))
            WriteDebugInfoAndOk(("Downloaded and installed pso2updater.exe"))
            WriteDebugInfo("Downloading pso2.exe...")
            Application.DoEvents()
            procs = Process.GetProcessesByName("pso2")
            For Each proc As Process In procs
                If proc.MainModule.ToString() = "ProcessModule (pso2.exe)" Then proc.Kill()
            Next
            DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2.exe.pat", "pso2.exe")
            If _cancelled Then Return

            If File.Exists((directoryString & "pso2.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((directoryString & "pso2.exe"))
            File.Move("pso2.exe", (directoryString & "pso2.exe"))
            WriteDebugInfoAndOk(("Downloaded and installed pso2.exe"))
            Application.DoEvents()
            WriteDebugInfo("All necessary files restored!")

        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub tsmFixPSO2Permissions_Click(sender As Object, e As EventArgs) Handles tsmFixPSO2Permissions.Click
        Try
            MsgBox("This will fix permission issues with PSO2. First, open the pso2updater.exe, so that it gives you the error ""has canceled the launch of pso2updater.exe. file is not updated."". Do NOT Hit OK. Leave that screen up, and hit OK here instead. It will perform some fixes. A message will pop up with more information when it's done.")
            Dim directoryString As String = (Program.PSO2RootDir & "\")
            WriteDebugInfo("Fixing permissions for pso2.exe...")
            Application.DoEvents()
            Process.Start("cacls.exe", (directoryString & "pso2.exe") & " /e /g """ & SystemInformation.UserName & """:F")
            WriteDebugInfoSameLine("Done!")
            WriteDebugInfo("Fixing permissions for pso2launcher.exe...")
            Application.DoEvents()
            Process.Start("cacls.exe", (directoryString & "pso2launcher.exe") & " /e /g """ & SystemInformation.UserName & """:F")
            WriteDebugInfoSameLine("Done!")
            WriteDebugInfo("Fixing permissions for pso2download.exe...")
            Application.DoEvents()
            Process.Start("cacls.exe", (directoryString & "pso2download.exe") & " /e /g """ & SystemInformation.UserName & """:F")
            WriteDebugInfoSameLine("Done!")
            WriteDebugInfo("Fixing permissions for pso2updater.exe...")
            Application.DoEvents()
            Process.Start("cacls.exe", (directoryString & "pso2updater.exe") & " /e /g """ & SystemInformation.UserName & """:F")
            WriteDebugInfoSameLine("Done!")
            WriteDebugInfo("Fixing permissions for pso2predownload.exe...")
            Application.DoEvents()
            Process.Start("cacls.exe", (directoryString & "pso2predownload.exe") & " /e /g """ & SystemInformation.UserName & """:F")
            WriteDebugInfoSameLine("Done!")
            MsgBox("Permissions fixed! NOW you can hit OK on the pso2updater.exe message - it should allow the updater to work and fix itself.")
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub tsmOpenDiagnosticMenu_Click(sender As Object, e As EventArgs) Handles tsmOpenDiagnosticMenu.Click
        FrmDiagnostic.TopMost = TopMost
        FrmDiagnostic.Top += 50
        FrmDiagnostic.Left += 50
        FrmDiagnostic.ShowDialog()
    End Sub

    Private Sub tsmResetPSO2Settings_Click(sender As Object, e As EventArgs) Handles tsmResetPSO2Settings.Click
        If MsgBox("Are you sure you want to reset all of PSO2's settings? This includes preferences, auto-login, preferred ships, etc.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            File.WriteAllText((_myDocuments & "\" & "SEGA\PHANTASYSTARONLINE2\user.pso2"), txtPSO2DefaultINI.Text)
            WriteDebugInfoAndOk("All PSO2 settings reset to defaults!")
        End If
    End Sub

    Private Sub tsmResetTweakerSettings_Click(sender As Object, e As EventArgs) Handles tsmResetTweakerSettings.Click
        Dim resetyesno As MsgBoxResult = MsgBox("This will erase all of the PSO2 Tweaker's settings, and restart the program. Continue?", vbYesNo)
        If resetyesno = vbYes Then
            File.WriteAllText(Program.AppData & "/PSO2 Tweaker/settings.json", lblDefaults.Text)
            Helper.Log("All settings reset, restarting program!")
            Windows.Forms.Application.Restart()
        End If
    End Sub

    Private Sub tsmTerminatePSO2Process_Click(sender As Object, e As EventArgs) Handles tsmTerminatePSO2Process.Click
        WriteDebugInfo("Attempting to close PSO2 game processes...")
        Dim procs As Process() = Process.GetProcessesByName("pso2")
        For Each proc As Process In procs
            If proc.MainModule.ToString() = "ProcessModule (pso2.exe)" Then proc.Kill()
            If proc.MainModule.ToString() = "ProcessModule (GameMon.des)" Then proc.Kill()
            If proc.MainModule.ToString() = "ProcessModule (GameMon64.des)" Then proc.Kill()
        Next
        WriteDebugInfoSameLine("Done!")
    End Sub

    Private Async Sub tsmCheckForPSO2UpdatesWithQuantum_Click(sender As Object, e As EventArgs) Handles tsmCheckForPSO2UpdatesWithQuantum.Click
        Helper.Log("User is starting QUANTUM...")

        RegKey.SetValue(Of String)("PSO2Dir", Program.GetSetting("PSO2Dir"))
        ' Use IOC Container in the main Tweaker project to deal with dependencies.
        Dim output As New TweakerTrigger
        Dim Settings = New JsonTweakerSettings(Program.AppData & "/PSO2 Tweaker/settings.json")
        Dim updater = New UpdateManager(Settings, output)
        Dim SkipClient As New WebClient
        Helper.Log("Downloading the list of files to skip...")
        SkipClient.DownloadFile(Program.FreedomUrl & "skip.txt", "skip.txt")
        'await updater.CleanLegacyFiles();

        'Console.WriteLine(settings.GameDirectory)
        Try

            'frmDownloader.TopMost = True
            'Me.TopMost = False
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
        frmDownloader.CleanupUI()
        Await updater.Update(False, False)
    End Sub

    Private Sub tsmCheckForPrePatchData_Click(sender As Object, e As EventArgs) Handles tsmCheckForPrePatchData.Click
        CheckForPso2Updates(True)
    End Sub

    Private Sub tsmStartChromeInCompatibilityMode_Click(sender As Object, e As EventArgs) Handles tsmStartChromeInCompatibilityMode.Click
        Const processName As String = "chrome"
        Dim processes = Process.GetProcessesByName("chrome")
        Dim currentProcess As Process = Process.GetCurrentProcess()
        If processes.Length > 0 Then
            Dim closeItYesNo As MsgBoxResult = MsgBox("You need to have all Chrome windows closed before launching in this mode. Would you like to close all open Chrome windows now?", vbYesNo)
            If closeItYesNo = vbYes Then
                For Each proc As Process In Process.GetProcessesByName(processName)
                    If proc.Id <> currentProcess.Id Then proc.Kill()
                Next
            Else
                WriteDebugInfoAndWarning("You need to have all Chrome windows closed before launching in this mode. Please close all Chrome windows and try again.")
                Return
            End If
        End If
        MsgBox("PLEASE BE AWARE: This will launch Chrome with it's built-in sandbox disabled, which disables a layer of security. Please only use this instance of Chrome to browse trusted sites while playing PSO2. (ie. Bumped, Arks-Visiphone, etc)")
        Process.Start("chrome", "--no-sandbox")
    End Sub

    Private Sub tsmConfigureTelepipeProxy_Click(sender As Object, e As EventArgs) Handles tsmConfigureTelepipeProxy.Click
        Dim jsonurl As String = InputBox("Please input the URL of the configuration JSON:", "Configuration JSON", "")
        Helper.Log("User entered """ & jsonurl & """ as the config URL.")
        If String.IsNullOrEmpty(jsonurl) Or jsonurl.Contains(".json") = False Then
            WriteDebugInfoAndFailed("Invalid URL! Please check the link and try again.")
            Return
        End If

        If jsonurl = "http://cloud02.cyberkitsune.net:8080/config.json" Then
            WriteDebugInfo("Changing PSO2Proxy Public URL -> Alam's URL to avoid GG issues with the hostname")
            WriteDebugInfo("New proxy URL is http://alam.srb2.org/PSO2/public_proxy/config-alt.json")
            jsonurl = "http://alam.srb2.org/PSO2/public_proxy/config-alt.json"
        End If
        Try
            Using wc As New WebClient()
                wc.Encoding = Encoding.UTF8
                Dim json_text = wc.DownloadString(jsonurl)
                Helper.Log("JSON was downloaded as: " & json_text.ToString)
                Dim proxy_conf = JsonConvert.DeserializeObject(Of ProxyConfig)(json_text)
                If File.Exists(Program.PSO2RootDir & "\plugins\disabled\TelepipeProxy.dll") Then
                    WriteDebugInfo("Auto-enabling the Telepipe Proxy plugin...")
                    File.Move(Program.PSO2RootDir & "\plugins\disabled\TelepipeProxy.dll", Path.Combine(Program.PSO2RootDir & "\plugins\TelepipeProxy.dll"))
                    WriteDebugInfoSameLine("Done!")
                End If
                Program.SaveSetting("ProxyJSONURL", jsonurl)

                '[Revert]
                Try
                    Dim builtFile = New List(Of String)
                    If Not File.Exists(Program.HostsFilePath) Then File.Create(Program.HostsFilePath).Dispose()

                    If File.ReadAllText(Program.HostsFilePath).Contains("pso2gs.net") Then
                        For Each line In Helper.GetLines(Program.HostsFilePath)
                            If Not line.Contains("pso2gs.net") Then builtFile.Add(line)
                        Next

                        WriteDebugInfo("Cleaning HOSTS file...")
                        File.WriteAllLines(Program.HostsFilePath, builtFile.ToArray())
                        WriteDebugInfoSameLine(" Done!")
                    End If
                Catch ex As Exception
                    Helper.LogWithException("Error cleaning hosts file - ", ex)
                End Try

                DownloadProxyInformation(jsonurl)
                'If File.Exists(Program.Pso2RootDir & "\publickey.blob") Then Helper.DeleteFile(Program.Pso2RootDir & "\publickey.blob")
                WriteDebugInfo("You can now connect to the " + proxy_conf.name + "!")
                '          End If

                If proxy_conf.version <> "1" And proxy_conf.version <> "2" Then WriteDebugInfoAndFailed("PSO2Proxy version was set incorrectly. Please check your JSON file.")
            End Using
        Catch ex As Exception
            Helper.LogWithException("Error setting proxy information - ", ex)
        End Try
    End Sub
    Private Function DownloadProxyInformation(url As String) As String
        Try
            Using wc As New WebClient()
                wc.Encoding = Encoding.UTF8
                Dim json_text = wc.DownloadString(url)
                Dim proxy_conf = JsonConvert.DeserializeObject(Of ProxyConfig)(json_text)
                If proxy_conf.publickeyurl.Length > 0 AndAlso proxy_conf.host.Length > 0 Then
                    Dim PSO2RootDir As String = Program.GetSetting("PSO2Dir")
                    File.WriteAllText(PSO2RootDir & "\proxy.txt", proxy_conf.host)
                    DownloadFile(proxy_conf.publickeyurl, PSO2RootDir & "\publickey.blob")
                    Return proxy_conf.host
                End If
            End Using
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
            'MsgBox("ERROR - " & ex.Message)
        End Try
    End Function

    Private Sub tsmRevertSettingsToJP_Click(sender As Object, e As EventArgs) Handles tsmRevertSettingsToJP.Click
        '[Revert]
        Dim builtFile = New List(Of String)
        If Not File.Exists(Program.HostsFilePath) Then File.Create(Program.HostsFilePath).Dispose()

        For Each line In Helper.GetLines(Program.HostsFilePath)
            If Not line.Contains("pso2gs.net") Then builtFile.Add(line)
        Next
        Try
            WriteDebugInfo("Cleaning HOSTS file...")
            File.WriteAllLines(Program.HostsFilePath, builtFile.ToArray())
        Catch ex As Exception
            Helper.LogWithException("Error cleaning hosts file - ", ex)
        End Try
        WriteDebugInfoSameLine(" Done!")
        Helper.DeleteFile(Program.PSO2RootDir & "\publickey.blob")
        If File.Exists(Program.PSO2RootDir & "\plugins\PSO2Proxy.dll") Then
            WriteDebugInfo("Auto-disabling the PSO2Proxy plugin...")
            File.Move(Program.PSO2RootDir & "\plugins\PSO2Proxy.dll", Path.Combine(Program.PSO2RootDir & "\plugins\disabled\PSO2Proxy.dll"))
            WriteDebugInfoSameLine("Done!")
        End If
        If File.Exists(Program.PSO2RootDir & "\plugins\TelepipeProxy.dll") Then
            WriteDebugInfo("Auto-disabling the Telepipe Proxy plugin...")
            File.Move(Program.PSO2RootDir & "\plugins\TelepipeProxy.dll", Path.Combine(Program.PSO2RootDir & "\plugins\disabled\TelepipeProxy.dll"))
            WriteDebugInfoSameLine("Done!")
        End If
        Program.SaveSetting("ProxyJSONURL", "")
        WriteDebugInfoAndOk("All normal JP connection settings restored!")
    End Sub

    Private Sub tsmClearSymbolArtCache_Click(sender As Object, e As EventArgs) Handles tsmClearSymbolArtCache.Click
        Dim clearYesNo As MsgBoxResult = MsgBox("This will clear all Symbol Arts from your ""History"" tab. Having 100 pages of Symbol Arts to load can sometimes cause slowdown.", vbYesNo)
        If clearYesNo = vbYes Then
            WriteDebugInfo("Deleting Symbol Art Cache...")
            For Each foundFile As String In Computer.FileSystem.GetFiles((_myDocuments & "\" & "SEGA\PHANTASYSTARONLINE2\symbolarts\cache"), FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                Computer.FileSystem.DeleteFile(foundFile, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
            Next
            WriteDebugInfoSameLine("Done!")
        End If
    End Sub

    Private Sub tsmInstallPSO2_Click(sender As Object, e As EventArgs) Handles tsmInstallPSO2.Click
        InstallPso2()
    End Sub

    Private Sub btnStartPSO2_Click(sender As Object, e As EventArgs) Handles btnStartPSO2.Click
        'Fuck SEGA. Stupid jerks.
        Helper.Log("Check if PSO2 is running")
        If Helper.CheckIfRunning("pso2") Then Return
        Try
            If IsPso2WinDirMissing() Then Return

            If Not File.Exists(Program.PSO2RootDir & "\pso2.exe") Then
                WriteDebugInfoAndFailed("Could not find pso2.exe - This can usually be solved by going to Troubleshooting -> Fix PSO2 EXEs (and making sure you selected the right folder).")
                Return
            End If

            Downloader.CancelAsync()
            _cancelled = True
            WriteDebugInfo("Launching Phantasy Star Online 2...")

            'End Item Translation stuff
            If Not Program.transOverride Then Helper.DeleteFile(Program.PSO2RootDir & "\ddraw.dll")
            If Not Program.transOverride Then File.WriteAllBytes(Program.PSO2RootDir & "\ddraw.dll", Resources.ddraw)
            Dim startInfo As ProcessStartInfo = New ProcessStartInfo With {.FileName = (Program.PSO2RootDir & "\pso2.exe"), .Arguments = "+0x33aca2b9", .UseShellExecute = False}
            startInfo.EnvironmentVariables("-pso2") = "+0x01e3f1e9"
            Dim shell As Process = New Process With {.StartInfo = startInfo}


            TRIALSystem("Request Access")
            Try
                'Solaris [Name is WIP] (and other proxies) stuff here
                Helper.Log("DEBUG - ProxyJSONURL is: " & Program.GetSetting("ProxyJSONURL"))
                If Program.GetSetting("ProxyJSONURL").Contains(".telepipe.io") And File.Exists(Program.PSO2RootDir & "\plugins\TelepipeProxy.dll") Then
                    Helper.Log("Detected Telepipe Proxy usage... Downloading information...")
                    If File.Exists(Program.PSO2RootDir & "\plugins\translator.dll") And DownloadProxyInformation(Program.GetSetting("ProxyJSONURL")).Contains(".telepipe.io") = True Then
                        Helper.Log("Item translation is enabled, let's turn it off, since this proxy supports serverside translations.")
                        File.Move(Program.PSO2RootDir & "\plugins\translator.dll", Program.PSO2RootDir & "\plugins\disabled\translator.dll")
                    End If
                    If File.Exists(Program.PSO2RootDir & "\plugins\PSO2TitleTranslator.dll") And DownloadProxyInformation(Program.GetSetting("ProxyJSONURL")).Contains(".telepipe.io") = True Then
                        Helper.Log("Title translation is enabled, let's turn it off, since this proxy supports serverside translations.")
                        File.Move(Program.PSO2RootDir & "\plugins\PSO2TitleTranslator.dll", Program.PSO2RootDir & "\plugins\disabled\PSO2TitleTranslator.dll")
                    End If
                End If

            Catch ex As Exception
                Helper.LogWithException("ERROR - ", ex)
            End Try

            'This code is no longer run because Gameguard sucks cock.
            'Maybe SEGA doesn't? WHO KNOWS. IT'S BACK IN.
            Helper.Log("Checking for extra GN Fields...")
            Dim processname As String = "GN Field"
            If Process.GetProcessesByName(processname).Length > 0 Then
                For Each proc As Process In Process.GetProcessesByName(processname)
                    proc.Kill()
                Next
            End If
            Helper.Log("Spinning GN Drives...")

            If Program.GNFieldActive = True And Program.ELSActive = False Then
                Helper.Log("GN Field is supposed to be active! Let's start it!")
                Process.Start("GN Field.exe")
                'Maybe the sleep is the problem?
                'Thread.Sleep(100)
            End If

            If Program.GNFieldActive = True And Program.ELSActive = True Then
                Helper.Log("GN Field is supposed to be active, and GG is trying to stop it. Let's start it with a random name - ELS Mode activated!")
                Program.GetSetting("GNFieldName")
                'Maybe the sleep is the problem?
                'Thread.Sleep(100)
            End If

            If Program.GNFieldActive = False Then
                Try
                    Helper.Log("Start PSO2!")
                    shell.Start()
                Catch ex As Exception
                    Helper.Log("EXCEPTION, HELP! ;_;")
                    WriteDebugInfo("It seems there was an issue starting PSO2, attempting to autofix...")
                    DownloadFile("http://download.pso2.jp/patch_prod/patches/pso2.exe.pat", "pso2.exe")
                    If File.Exists((Program.PSO2RootDir & "\pso2.exe")) AndAlso Program.StartPath <> Program.PSO2RootDir Then Helper.DeleteFile((Program.PSO2RootDir & "\pso2.exe"))
                    File.Move("pso2.exe", (Program.PSO2RootDir & "\pso2.exe"))
                    WriteDebugInfoSameLine("Done!")
                    Helper.Log("Starting PSO2 again.")
                    shell.Start()
                End Try
            Else
                Thread.Sleep(100)
                Helper.Log("Waiting for GN Field to activate...")
                Thread.Sleep(60000)
                WriteDebugInfoAndFailed("GN Field failed to launch! Please restart the PSO2 Tweaker.")
                Helper.Log("Slept for 60 seconds, GN Field didn't launch. Exiting PSO2 Launch method.")
                Exit Sub
            End If



            Hide()
            Dim hWnd As IntPtr = External.FindWindow("Phantasy Star Online 2", Nothing)

            tmrWaitingforPSO2.Enabled = True

            Do While hWnd = IntPtr.Zero
                hWnd = External.FindWindow("Phantasy Star Online 2", Nothing)
                Thread.Sleep(10)
                Application.DoEvents()
            Loop

            If Not Program.transOverride Then Helper.DeleteFile(Program.PSO2RootDir & "\ddraw.dll")
            tmrWaitingforPSO2.Enabled = False
            If Program.GetSetting("SteamMode") = "True" Then
                File.Copy(Program.PSO2RootDir & "\pso2.exe", Program.PSO2RootDir & "\pso2.exe_backup", True)
                Do While Helper.IsFileInUse(Program.PSO2RootDir & "\pso2.exe")
                    Thread.Sleep(1000)
                Loop
                File.Copy(Program.PSO2RootDir & "\pso2.exe_backup", Program.PSO2RootDir & "\pso2.exe", True)
                File.Delete(Program.PSO2RootDir & "\pso2.exe_backup")
            End If
            Close()

        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub rtbDebug_MouseClick(sender As Object, e As MouseEventArgs) Handles rtbDebug.MouseClick
        If e.Button = MouseButtons.Right Then
            cmsTextBarOptions.Show(DirectCast(sender, Control), e.Location)
        End If
    End Sub

    Private Sub CopyAllTextToClipboardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyAllTextToClipboardToolStripMenuItem.Click
        Clipboard.SetText(rtbDebug.Text)
        WriteDebugInfo("All text copied to clipboard.")
    End Sub

    Private Sub cmsORB_Opened(sender As Object, e As EventArgs) Handles cmsORB.Opened
        Button1.BackgroundImage = Resources.__clicked
    End Sub

    Private Sub cmsORB_Closed(sender As Object, e As ToolStripDropDownClosedEventArgs) Handles cmsORB.Closed
        Button1.BackgroundImage = Resources.__normal
    End Sub

    Private Sub btnPlugins_Click(sender As Object, e As EventArgs) Handles btnPlugins.Click
        frmPlugins.TopMost = TopMost
        frmPlugins.Top += 50
        frmPlugins.Left += 50
        frmPlugins.ShowDialog()
    End Sub
    Protected Sub GetShipEQs(state As Object)
        Try
            If lblShipEQ.InvokeRequired Then
                lblShipEQ.Invoke(New Action(Of String)(AddressOf GetShipEQs), Text)
            Else
                Dim Ship As String = Program.GetSetting("ShipStatus")
                Dim JSONClient As New WebClient
                JSONClient.Headers("user-agent") = "Tweaker EQ Checker"
                Dim filelistjson As JArray = JArray.Parse(JSONClient.DownloadString("http://pso2.acf.me.uk/api/eq.json"))
                'Check Ship first
                'Check what's coming at :30 next
                'Check in an hour
                'Check in two hours
                'Finally check what's coming in 3 hours
                'If all of the above are blank then there's no EQ for this Ship
                If filelistjson(0).SelectToken("Ship" & Ship).ToString <> "" Then
                    lblShipEQ.Text = "Upcoming EQ: " & filelistjson(0).SelectToken("Ship" & Ship).ToString & " at " & filelistjson(0).SelectToken("JST").ToString & " JST"
                    lblShipEQ.ForeColor = Color.Gold
                    lblShipEQ.Visible = True
                    Exit Sub
                End If
                If filelistjson(0).SelectToken("HalfHour").ToString <> "" Then
                    lblShipEQ.Text = "Upcoming EQ: " & filelistjson(0).SelectToken("HalfHour").ToString & " at half past"
                    lblShipEQ.ForeColor = Color.Gold
                    lblShipEQ.Visible = True
                    Exit Sub
                End If
                If filelistjson(0).SelectToken("OneLater").ToString <> "" Then
                    lblShipEQ.Text = "Upcoming EQ: " & filelistjson(0).SelectToken("OneLater").ToString & " at " & filelistjson(0).SelectToken("JST").ToString & " JST"
                    lblShipEQ.ForeColor = Color.Gold
                    lblShipEQ.Visible = True
                    Exit Sub
                End If
                If filelistjson(0).SelectToken("TwoLater").ToString <> "" Then
                    lblShipEQ.Text = "Upcoming EQ: " & filelistjson(0).SelectToken("TwoLater").ToString & " in two hours"
                    lblShipEQ.ForeColor = Color.Gold
                    lblShipEQ.Visible = True
                    Exit Sub
                End If
                If filelistjson(0).SelectToken("ThreeLater").ToString <> "" Then
                    lblShipEQ.Text = "Upcoming EQ: " & filelistjson(0).SelectToken("ThreeLater").ToString & " in three hours"
                    lblShipEQ.ForeColor = Color.Gold
                    lblShipEQ.Visible = True
                    Exit Sub
                End If
                lblShipEQ.Text = "No upcoming EQs at this time for Ship " & Ship
                lblShipEQ.ForeColor = Color.Gold
                lblShipEQ.Visible = True
            End If
        Catch ex As Exception
            Helper.Log("Error getting EQ status - " & ex.Message)
        End Try
    End Sub
    Protected Sub GetShipStatus(state As Object)
        Try
            If lblShipStatus.InvokeRequired Then
                lblShipStatus.Invoke(New Action(Of String)(AddressOf GetShipStatus), Text)
            Else
                Dim Ship As String = "2"
                Dim JSONClient As New WebClient
                Dim filelistjson As JObject = JObject.Parse(JSONClient.DownloadString("http://kakia.org/pso2_status.json"))
                If filelistjson.SelectToken(Ship).SelectToken("Status").ToString = "Online" Then
                    lblShipStatus.Text = "Servers are online"
                    lblShipStatus.ForeColor = Color.Gold
                    lblShipStatus.Location = New Point(862, 633)
                End If
                If filelistjson.SelectToken(Ship).SelectToken("Status").ToString = "Offline" Then
                    lblShipStatus.Text = "Servers are offline (Maintenance?)"
                    lblShipStatus.ForeColor = Color.Red
                    lblShipStatus.Location = New Point(776, 633)
                End If
                lblShipStatus.Visible = True
            End If
        Catch ex As Exception
            Helper.Log("Error getting ship status - " & ex.Message)
        End Try
    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted

    End Sub

    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        If e.Url.ToString() <> Program.InfoURL And e.Url.AbsoluteUri <> "about:blank" Then
            Process.Start(e.Url.ToString())
            Helper.Log("Trying to load URL for sidebar: " & e.Url.ToString)
            ThreadPool.QueueUserWorkItem(AddressOf LoadSidebar, Nothing)
        End If
    End Sub
    Private Sub LoadSidebar(state As Object)
        Try
            'Change to Tweaker2 to test Sidebar theming.
            WebBrowser1.Navigate(Program.InfoURL)
        Catch ex As Exception
            Helper.LogWithException("Web Browser failed: ", ex)
        End Try
    End Sub

    Private Sub PBMainBar_Click(sender As Object, e As EventArgs)

    End Sub
End Class
Public Class PluginClass
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Filename() As String
        Get
            Return m_Filename
        End Get
        Set
            m_Filename = Value
        End Set
    End Property
    Private m_Filename As String
    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set
            m_Description = Value
        End Set
    End Property
    Private m_Description As String
    Public Property Author() As String
        Get
            Return m_Author
        End Get
        Set
            m_Author = Value
        End Set
    End Property
    Private m_Author As String
    Public Property Homepage() As String
        Get
            Return m_Homepage
        End Get
        Set
            m_Homepage = Value
        End Set
    End Property
    Private m_Homepage As String
    Public Property Version() As String
        Get
            Return m_Version
        End Get
        Set
            m_Version = Value
        End Set
    End Property
    Private m_Version As String
    Public Property MD5Hash() As String
        Get
            Return m_MD5Hash
        End Get
        Set
            m_MD5Hash = Value
        End Set
    End Property
    Private m_MD5Hash As String
    Public Property Toggleable() As String
        Get
            Return m_Toggleable
        End Get
        Set
            m_Toggleable = Value
        End Set
    End Property
    Private m_Toggleable As String
End Class
Friend Class ProxyConfig
    Public publickeyurl As String
    Public host As String
    Public version As String
    Public name As String
End Class