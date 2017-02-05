Imports System.IO
Imports System.Runtime.InteropServices
Imports PSO2TweakerVer2.My

Public Class frmPSO2Settingsv2
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    ReadOnly _documents As String = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\")
    ReadOnly _usersettingsfile As String = (_documents & "SEGA\PHANTASYSTARONLINE2\user.pso2")
#Region "Layout stuff"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnWindowMode.Click
        cmbWindowMode.DroppedDown = True
    End Sub

    Private Sub btnMainClose_Click(sender As Object, e As EventArgs) Handles btnMainClose.Click
        'Closing the form, duh
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Closing the form, duh
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnResolution.Click
        cmbResolution.DroppedDown = True
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

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWindowMode.SelectedIndexChanged
        btnWindowMode.Text = cmbWindowMode.Text
    End Sub
    Private Sub btnStartPSO2_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveChanges.MouseDown
        btnSaveChanges.BackgroundImage = My.Resources.big_button_press
    End Sub

    Private Sub btnStartPSO2_MouseHover(sender As Object, e As EventArgs) Handles btnSaveChanges.MouseHover
        btnSaveChanges.BackgroundImage = My.Resources.big_button_hover
    End Sub

    Private Sub btnStartPSO2_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveChanges.MouseLeave
        btnSaveChanges.BackgroundImage = My.Resources.big_button_normal
    End Sub

    Private Sub btnStartPSO2_MouseMove(sender As Object, e As MouseEventArgs) Handles btnSaveChanges.MouseMove
        btnSaveChanges.BackgroundImage = My.Resources.big_button_hover
    End Sub
    Private Sub frmPSO2Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not File.Exists(_usersettingsfile) Then
                File.WriteAllText(_usersettingsfile, frmMainv2.txtPSO2DefaultINI.Text)
                frmMainv2.WriteDebugInfo("Generating new PSO2 Settings file... Done!")
            End If


            Dim devM As External.Devmode
            devM.dmDeviceName = New String(Chr(0), 32)
            devM.dmFormName = New String(Chr(0), 32)
            devM.dmSize = CShort(Marshal.SizeOf(GetType(External.Devmode)))

            Dim modeIndex As Integer = 0
            ' 0 = The first mode
            While External.EnumDisplaySettings(Nothing, modeIndex, devM)
                ' Mode found
                If Not cmbResolution.Items.Contains(devM.dmPelsWidth & "x" & devM.dmPelsHeight) Then cmbResolution.Items.Add(devM.dmPelsWidth & "x" & devM.dmPelsHeight)

                ' The next mode
                modeIndex += 1
            End While

            Dim currentHeight As String = ReadIniSetting("Height3d")
            Dim currentWidth As String = ReadIniSetting("Width3d")
            If currentHeight = "ERROR" Then currentHeight = ReadIniSetting("Height")
            If currentWidth = "ERROR" Then currentWidth = ReadIniSetting("Width")


            Dim fullRes As String = currentWidth & "x" & currentHeight

            cmbResolution.Text = fullRes
            TBSimpleRenderSetting.Value = Convert.ToInt32(ReadIniSetting("DrawLevel"))
            lblSimpleRenderSetting.Text = TBSimpleRenderSetting.Value
            TBBGMVolume.Value = Convert.ToInt32(ReadIniSetting("Bgm"))
            lblBGMVolume.Text = TBBGMVolume.Value
            TBSEVolume.Value = Convert.ToInt32(ReadIniSetting("Se"))
            lblSEVolume.Text = TBSEVolume.Value
            TBVoiceVolume.Value = Convert.ToInt32(ReadIniSetting("Voice"))
            lblVoiceVolume.Text = TBVoiceVolume.Value
            TBMovieVolume.Value = Convert.ToInt32(ReadIniSetting("Movie"))
            lblMovieVolume.Text = TBMovieVolume.Value
            cmbTextureResolution.SelectedIndex = Convert.ToInt32(ReadIniSetting("TextureResolution"))
            btnTextureResolution.Text = cmbTextureResolution.SelectedItem
            If ReadIniSetting("InterfaceSize") = "ERROR" Then
                cmbTextSize.SelectedIndex = 0
            Else
                cmbTextSize.SelectedIndex = Convert.ToInt32(ReadIniSetting("InterfaceSize"))
            End If
            btnTextSize.Text = cmbTextSize.SelectedItem
            cmbMaxFPS.Text = ReadIniSetting("FrameKeep") & " FPS"
            If cmbMaxFPS.Text = "0 FPS" Then cmbMaxFPS.Text = "Unlimited FPS"
            btnMaxFPS.Text = cmbMaxFPS.Text
            If ReadIniSetting("ShaderLevel") = "-1" Then cmbShaderQuality.SelectedIndex = 1
            If ReadIniSetting("ShaderLevel") = "True" Then
                cmbShaderQuality.SelectedIndex = 1
                SaveIniSetting("ShaderLevel", cmbShaderQuality.SelectedIndex.ToString())
            End If
            If ReadIniSetting("ShaderLevel") = "true" Then
                cmbShaderQuality.SelectedIndex = 1
                SaveIniSetting("ShaderLevel", cmbShaderQuality.SelectedIndex.ToString())
            End If
            If ReadIniSetting("ShaderLevel") = "False" Then
                cmbShaderQuality.SelectedIndex = 2
                SaveIniSetting("ShaderLevel", cmbShaderQuality.SelectedIndex.ToString())
            End If
            If ReadIniSetting("ShaderLevel") = "false" Then
                cmbShaderQuality.SelectedIndex = 2
                SaveIniSetting("ShaderLevel", cmbShaderQuality.SelectedIndex.ToString())
            End If
            '            If ReadIniSetting("ShaderLevel") = "0" Or ReadIniSetting("ShaderLevel") = "1" Or ReadIniSetting("ShaderLevel") = "2" Then cmbShaderQuality.SelectedIndex = CInt(ReadIniSetting("ShaderLevel"))
            If ReadIniSetting("ShaderLevel") = "ERROR" Then
                cmbShaderQuality.SelectedIndex = 0
            Else
                cmbShaderQuality.SelectedIndex = CInt(ReadIniSetting("ShaderLevel"))
            End If
            btnShaderQuality.Text = cmbShaderQuality.SelectedItem
            If ReadIniSetting("MoviePlay") = "true" Then chkPlayVideos.Checked = True
            If ReadIniSetting("MoviePlay") = "false" Then chkPlayVideos.Checked = False
            If ReadIniSetting("FullScreen") = "false" Then cmbWindowMode.SelectedIndex = 0
            If ReadIniSetting("FullScreen") = "true" Then cmbWindowMode.SelectedIndex = 1
            If ReadIniSetting("VirtualFullScreen") = "true" Then cmbWindowMode.SelectedIndex = 2
            btnWindowMode.Text = cmbWindowMode.SelectedItem
            'cmbResolution.Text = ReadINISetting("Width", 240) & "x" & ReadINISetting("Height", 240)
            If Not cmbResolution.Items.Contains(cmbResolution.Text) Then cmbResolution.SelectedIndex = 0
            btnResolution.Text = cmbResolution.Text
            chkInvisibleInterface.Checked = False
            If ReadIniSetting("Y") = "99999" Then
                If ReadIniSetting("X") = "99999" Then
                    chkInvisibleInterface.Checked = True
                End If
            End If
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        btnCancel.BackgroundImage = My.Resources.medium_button_press
    End Sub

    Private Sub btnCancel_MouseHover(sender As Object, e As EventArgs) Handles btnCancel.MouseHover
        btnCancel.BackgroundImage = My.Resources.medium_button_hover
    End Sub

    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        btnCancel.BackgroundImage = My.Resources.medium_button_normal
    End Sub

    Private Sub btnCancel_MouseMove(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseMove
        btnCancel.BackgroundImage = My.Resources.medium_button_hover
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbResolution.SelectedIndexChanged
        btnResolution.Text = cmbResolution.Text
    End Sub

    Private Sub btnMainClose_MouseMove(sender As Object, e As MouseEventArgs) Handles btnMainClose.MouseMove
        btnMainClose.BackgroundImage = My.Resources.close_hover
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnTextureResolution.Click
        cmbTextureResolution.DroppedDown = True
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTextureResolution.SelectedIndexChanged
        btnTextureResolution.Text = cmbTextureResolution.Text
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnShaderQuality.Click
        cmbShaderQuality.DroppedDown = True
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbShaderQuality.SelectedIndexChanged
        btnShaderQuality.Text = cmbShaderQuality.Text
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TBSimpleRenderSetting.Scroll
        lblSimpleRenderSetting.Text = TBSimpleRenderSetting.Value
    End Sub
    Private Function ReadIniSetting(settingToRead As String, Optional ByVal lineToStartAt As Integer = 0) As String
        Try
            'Dim returnValue = ""
            'If INICache.TryGetValue(SettingToRead, returnValue) Then Return returnValue

            Dim textLines As String() = File.ReadAllLines(_usersettingsfile)
            For i As Integer = lineToStartAt To (textLines.Length - 1)
                If Not String.IsNullOrEmpty(textLines(i)) Then
                    If textLines(i).Contains(" " & settingToRead & " ") Then
                        Dim strLine As String = textLines(i).Replace(vbTab, "")
                        Dim strReturn As String() = strLine.Split("="c)
                        Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "").Replace(" "c, "")
                        'If FinalString IsNot Nothing Then INICache.Add(SettingToRead, FinalString)
                        Return finalString
                    End If
                End If
            Next
            Helper.Log("Couldn't find this setting - " & settingToRead & "!")
            Return "ERROR"
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
        Return ""
    End Function
    Private Sub frmPSO2Settingsv2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If SystemInformation.HighContrast = True Then
            e.Graphics.DrawImage(New Bitmap(BackgroundImage), 0, 0)
            Dim cControl As Control
            For Each cControl In Me.Controls
                If TypeOf cControl Is PictureBox And cControl.Visible = True Then
                    If cControl.BackgroundImage IsNot Nothing Then
                        e.Graphics.DrawImage(New Bitmap(cControl.BackgroundImage, cControl.Size), cControl.Location.X, cControl.Location.Y)
                        cControl.SendToBack()
                    End If
                End If
                If TypeOf cControl Is Button And cControl.Visible = True Then
                    If cControl.BackgroundImage IsNot Nothing Then
                        e.Graphics.DrawImage(New Bitmap(cControl.BackgroundImage), cControl.Location.X, cControl.Location.Y)
                        cControl.BringToFront()
                    End If
                End If
            Next cControl
        End If
    End Sub

    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        Helper.Log("Looking for user.pso2 file...")
        If File.Exists(_usersettingsfile) = False Then
            frmMainv2.WriteDebugInfoAndFailed("Unable to locate a PSO2 settings file. Creating default and saving changes...")
            File.WriteAllText((_documents & "\" & "SEGA\PHANTASYSTARONLINE2\user.pso2"), frmMainv2.txtPSO2DefaultINI.Text)
            Exit Sub
        End If
        Try
            Helper.Log("Saving Draw Level...")
            SaveIniSetting("DrawLevel", TBSimpleRenderSetting.Value.ToString())
            Helper.Log("Saving Simple Render Setting " & TBSimpleRenderSetting.Value & "!")
            'Probably a much better way to do this, will revisit later. [AIDA]
            Select Case TBSimpleRenderSetting.Value
                Case 1
                    SaveQualitySetting("low")
                    SaveIniSetting("ReflectionQuality", "1")
                    SaveIniSetting("ShadowQuality", "1")
                    SaveIniSetting("DitailModelNum", "5")
                    SaveIniSetting("TextureResolution", "0")
                    SaveIniSetting("Blur", "false")
                    SaveIniSetting("LightGeoGraphy", "false")
                    SaveIniSetting("Depth", "false")
                    SaveIniSetting("Reflection", "false")
                    SaveIniSetting("LightShaft", "false")
                    SaveIniSetting("Bloom", "false")
                    SaveIniSetting("LightEffect", "false")
                    SaveIniSetting("AntiAliasing", "false")
                    SaveIniSetting("ShaderLevel", "0")
                Case 2
                    SaveQualitySetting("low")
                    SaveIniSetting("ReflectionQuality", "2")
                    SaveIniSetting("ShadowQuality", "2")
                    SaveIniSetting("DitailModelNum", "5")
                    SaveIniSetting("TextureResolution", "1")
                    SaveIniSetting("Blur", "false")
                    SaveIniSetting("LightGeoGraphy", "false")
                    SaveIniSetting("Depth", "false")
                    SaveIniSetting("Reflection", "true")
                    SaveIniSetting("LightShaft", "false")
                    SaveIniSetting("Bloom", "false")
                    SaveIniSetting("LightEffect", "false")
                    SaveIniSetting("AntiAliasing", "false")
                    SaveIniSetting("ShaderLevel", "1")
                Case 3
                    SaveQualitySetting("middle")
                    SaveIniSetting("ReflectionQuality", "3")
                    SaveIniSetting("ShadowQuality", "3")
                    SaveIniSetting("DitailModelNum", "12")
                    SaveIniSetting("TextureResolution", "1")
                    SaveIniSetting("Blur", "true")
                    SaveIniSetting("LightGeoGraphy", "false")
                    SaveIniSetting("Depth", "false")
                    SaveIniSetting("Reflection", "true")
                    SaveIniSetting("LightShaft", "false")
                    SaveIniSetting("Bloom", "false")
                    SaveIniSetting("LightEffect", "true")
                    SaveIniSetting("AntiAliasing", "true")
                    SaveIniSetting("ShaderLevel", "1")
                Case 4
                    SaveQualitySetting("middle")
                    SaveIniSetting("ReflectionQuality", "4")
                    SaveIniSetting("ShadowQuality", "4")
                    SaveIniSetting("DitailModelNum", "20")
                    SaveIniSetting("TextureResolution", "1")
                    SaveIniSetting("Blur", "true")
                    SaveIniSetting("LightGeoGraphy", "false")
                    SaveIniSetting("Depth", "true")
                    SaveIniSetting("Reflection", "true")
                    SaveIniSetting("LightShaft", "true")
                    SaveIniSetting("Bloom", "true")
                    SaveIniSetting("LightEffect", "true")
                    SaveIniSetting("AntiAliasing", "true")
                    SaveIniSetting("ShaderLevel", "1")
                Case 5
                    SaveQualitySetting("high")
                    SaveIniSetting("ReflectionQuality", "5")
                    SaveIniSetting("ShadowQuality", "5")
                    SaveIniSetting("DitailModelNum", "30")
                    SaveIniSetting("TextureResolution", "2")
                    SaveIniSetting("Blur", "true")
                    SaveIniSetting("LightGeoGraphy", "true")
                    SaveIniSetting("Depth", "true")
                    SaveIniSetting("Reflection", "true")
                    SaveIniSetting("LightShaft", "true")
                    SaveIniSetting("Bloom", "true")
                    SaveIniSetting("LightEffect", "true")
                    SaveIniSetting("AntiAliasing", "true")
                    SaveIniSetting("ShaderLevel", "1")
                Case 6
                    SaveQualitySetting("high")
                    SaveIniSetting("ReflectionQuality", "5")
                    SaveIniSetting("ShadowQuality", "5")
                    SaveIniSetting("DitailModelNum", "30")
                    SaveIniSetting("TextureResolution", "2")
                    SaveIniSetting("Blur", "true")
                    SaveIniSetting("LightGeoGraphy", "true")
                    SaveIniSetting("Depth", "true")
                    SaveIniSetting("Reflection", "true")
                    SaveIniSetting("LightShaft", "true")
                    SaveIniSetting("Bloom", "true")
                    SaveIniSetting("LightEffect", "true")
                    SaveIniSetting("AntiAliasing", "true")
                    SaveIniSetting("ShaderLevel", "2")
            End Select
            Helper.Log("Saving Texture Resolution...")
            SaveIniSetting("TextureResolution", cmbTextureResolution.SelectedIndex.ToString())
            Helper.Log("Saving Interface Size...")
            SaveIniSetting("InterfaceSize", cmbTextSize.SelectedIndex.ToString())
            Helper.Log("Saving Shader Quality...")
            SaveIniSetting("ShaderLevel", cmbShaderQuality.SelectedIndex.ToString())
            SaveIniSetting("MoviePlay", chkPlayVideos.Checked.ToString.ToLower)

            If cmbWindowMode.SelectedIndex = 0 Then
                Helper.Log("Saving Window Mode (Windowed)...")
                SaveIniSetting("FullScreen", "false")
                SaveIniSetting("VirtualFullScreen", "false")
            End If

            If cmbWindowMode.SelectedIndex = 1 Then
                Helper.Log("Saving Window Mode (Fullscreen)...")
                SaveIniSetting("FullScreen", "true")
                SaveIniSetting("VirtualFullScreen", "false")
            End If

            If cmbWindowMode.SelectedIndex = 2 Then
                Helper.Log("Saving Window Mode (Virtual Fullscreen)...")
                SaveIniSetting("FullScreen", "false")
                SaveIniSetting("VirtualFullScreen", "true")
            End If

            If Not cmbResolution.Items.Contains(cmbResolution.Text) Then
                MsgBox("Please select a supported resolution!")
                Return
            End If

            Helper.Log("Saving Resolution...")
            'If cmbResolution.SelectedText <> "x" Then
            Dim strResolution As String = cmbResolution.SelectedItem.ToString()

            Dim realResolution As String() = strResolution.Split("x"c)
            SaveResolutionWidth(realResolution(0))
            SaveResolutionHeight(realResolution(1))
            SaveResolutionWidth3D(realResolution(0))
            SaveResolutionHeight3D(realResolution(1))
            'End If

            Dim fps As String = cmbMaxFPS.SelectedItem.ToString().Replace(" FPS", "").Replace("Unlimited", "0")

            Helper.Log("Saving FPS...")
            SaveIniSetting("FrameKeep", fps)

            Helper.Log("Saving Volume...")
            SaveIniSetting("Bgm", TBBGMVolume.Value.ToString())
            SaveIniSetting("Voice", TBVoiceVolume.Value.ToString())
            SaveIniSetting("Movie", TBMovieVolume.Value.ToString())
            SaveIniSetting("Se", TBSEVolume.Value.ToString())

            If chkInvisibleInterface.Checked Then
                Helper.Log("Enabling Interface...")
                If ReadIniSetting("X") <> "99999" Then
                    If ReadIniSetting("Y") <> "99999" Then
                        Program.SaveSetting("OldX", ReadIniSetting("X"))
                        Program.SaveSetting("OldY", ReadIniSetting("Y"))
                        SaveIniSetting("X", "99999")
                        SaveIniSetting("Y", "99999")
                    End If
                End If
            End If

            If Not chkInvisibleInterface.Checked Then
                Helper.Log("Disabled Interface...")
                If ReadIniSetting("X") = "99999" Then
                    If ReadIniSetting("Y") = "99999" Then
                        SaveIniSetting("X", Program.GetSetting("OldX"))
                        SaveIniSetting("Y", Program.GetSetting("OldY"))
                    End If
                End If
            End If

            frmMainv2.WriteDebugInfoAndOk("PSO2 settings saved!")
            frmMainv2.Location = Me.DesktopLocation
            frmMainv2.Visible = True
            Me.Close()
        Catch ex As Exception
            frmMainv2.WriteDebugInfoAndFailed(ex.message)
        Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub
    Private Sub SaveIniSetting(settingToSave As String, value As String)
        Try
            'INICache(SettingToSave) = Value

            TextBox1.Text = ""
            Dim settingString As String = File.ReadAllText(_usersettingsfile)
            Dim textLines As String() = settingString.Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer
            Dim j As Integer
            For i = 0 To (textLines.Length - 1)
                If textLines(i).Contains(" " & settingToSave & " ") Then
                    Dim strLine As String = textLines(i).Replace(vbTab, "")
                    Dim strReturn As String() = strLine.Split("="c)
                    Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "")
                    textLines(i) = textLines(i).Replace(finalString, (" " & value))
                    For j = 0 To textLines.Length
                        If j + 1 = textLines.Length Then
                            TextBox1.AppendText("}")
                            File.WriteAllText(_usersettingsfile, TextBox1.Text)
                            Return
                        End If
                        TextBox1.AppendText(textLines(j) & vbCrLf)
                    Next j
                End If
            Next i
            Helper.Log("Couldn't find this setting - " & settingToSave & "!")
            Return
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub SaveQualitySetting(value As String)
        Try
            'INICache(SettingToSave) = Value

            TextBox1.Text = ""
            Dim settingString As String = File.ReadAllText(_usersettingsfile)
            Dim textLines As String() = settingString.Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer
            Dim j As Integer
            For i = 0 To (textLines.Length - 1)
                If textLines(i).Contains("Quality = ") = True And textLines(i).Contains("ShaderQuality") = False And textLines(i).Contains("ReflectionQuality") = False And textLines(i).Contains("ShadowQuality") = False Then
                    Dim strLine As String = textLines(i).Replace(vbTab, "")
                    Dim strReturn As String() = strLine.Split("="c)
                    Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "")
                    textLines(i) = textLines(i).Replace(finalString.Replace(" ", ""), value)
                    For j = 0 To textLines.Length
                        If j + 1 = textLines.Length Then
                            TextBox1.AppendText("}")
                            File.Delete(_usersettingsfile)
                            File.WriteAllText(_usersettingsfile, TextBox1.Text)
                            Return
                        End If
                        TextBox1.AppendText(textLines(j) & vbCrLf)
                    Next j
                End If
            Next i
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub SaveResolutionHeight(value As String)
        Try
            TextBox1.Text = ""
            Dim settingString As String = File.ReadAllText(_usersettingsfile)
            Dim textLines As String() = settingString.Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer
            Dim j As Integer
            Dim contains As Boolean = False
            For i = 0 To (textLines.Length - 1)
                If textLines(i).Contains("Windows = {") Then
                    For x As Integer = 1 To 9
                        If textLines(i + x).Contains("Height =") Then
                            i += x
                            contains = True
                            Exit For
                        End If
                    Next x

                    If Not contains Then
                        frmMainv2.WriteDebugInfo("Couldn't find Height in user settings. This is OKAY. If you notice your resolution not changing, try resetting your PSO2 Settings to default. If everything works, feel free to ignore this error.")
                        Return
                    End If

                    Dim strLine As String = textLines(i).Replace(vbTab, "")
                    Dim strReturn As String() = strLine.Split("="c)
                    Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "")
                    textLines(i) = textLines(i).Replace(finalString, (" " & value))
                    For j = 0 To textLines.Length
                        If j + 1 = textLines.Length Then
                            TextBox1.AppendText("}")
                            File.Delete(_usersettingsfile)
                            File.WriteAllText(_usersettingsfile, TextBox1.Text)
                            Return
                        End If
                        TextBox1.AppendText(textLines(j) & vbCrLf)
                    Next j
                End If
            Next i
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub SaveResolutionWidth(value As String)
        Try
            TextBox1.Text = ""
            Dim settingString As String = File.ReadAllText(_usersettingsfile)
            Dim textLines As String() = settingString.Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer
            Dim j As Integer
            Dim contains As Boolean = False
            For i = 0 To (textLines.Length - 1)
                If textLines(i).Contains("Windows = {") Then
                    For x As Integer = 1 To 9
                        If textLines(i + x).Contains("Width =") Then
                            i += x
                            contains = True
                            Exit For
                        End If
                    Next x

                    If Not contains Then
                        frmMainv2.WriteDebugInfo("Couldn't find Width in user settings. This is OKAY. If you notice your resolution not changing, try resetting your PSO2 Settings to default. If everything works, feel free to ignore this error.")
                        Return
                    End If

                    Dim strLine As String = textLines(i).Replace(vbTab, "")
                    Dim strReturn As String() = strLine.Split("="c)
                    Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "")
                    textLines(i) = textLines(i).Replace(finalString, (" " & value))

                    For j = 0 To textLines.Length
                        If j + 1 = textLines.Length Then
                            TextBox1.AppendText("}")
                            File.Delete(_usersettingsfile)
                            File.WriteAllText(_usersettingsfile, TextBox1.Text)
                            Return
                        End If
                        TextBox1.AppendText(textLines(j) & vbCrLf)
                    Next j

                End If
            Next i
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub SaveResolutionHeight3D(value As String)
        Try
            TextBox1.Text = ""
            Dim settingString As String = File.ReadAllText(_usersettingsfile)
            Dim textLines As String() = settingString.Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer
            Dim j As Integer
            Dim contains As Boolean = False
            For i = 0 To (textLines.Length - 1)
                If textLines(i).Contains("Windows = {") Then
                    For x As Integer = 1 To 9
                        If textLines(i + x).Contains("Height3d =") Then
                            i += x
                            contains = True
                            Exit For
                        End If
                    Next x

                    If Not contains Then
                        frmMainv2.WriteDebugInfo("Couldn't find Height3D in user settings. This is OKAY. If you notice your resolution not changing, try resetting your PSO2 Settings to default. If everything works, feel free to ignore this error.")
                        Return
                    End If

                    Dim strLine As String = textLines(i).Replace(vbTab, "")
                    Dim strReturn As String() = strLine.Split("="c)
                    Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "")
                    textLines(i) = textLines(i).Replace(finalString, (" " & value))
                    For j = 0 To textLines.Length
                        If j + 1 = textLines.Length Then
                            TextBox1.AppendText("}")
                            File.Delete(_usersettingsfile)
                            File.WriteAllText(_usersettingsfile, TextBox1.Text)
                            Return
                        End If
                        TextBox1.AppendText(textLines(j) & vbCrLf)
                    Next j
                End If
            Next i
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub SaveResolutionWidth3D(value As String)
        Try
            TextBox1.Text = ""
            Dim settingString As String = File.ReadAllText(_usersettingsfile)
            Dim textLines As String() = settingString.Split(Environment.NewLine.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
            Dim i As Integer
            Dim j As Integer
            Dim contains As Boolean = False
            For i = 0 To (textLines.Length - 1)
                If textLines(i).Contains("Windows = {") Then
                    For x As Integer = 1 To 9
                        If textLines(i + x).Contains("Width3d =") Then
                            i += x
                            contains = True
                            Exit For
                        End If
                    Next x

                    If Not contains Then
                        frmMainv2.WriteDebugInfo("Couldn't find Width3D in user settings. This is OKAY. If you notice your resolution not changing, try resetting your PSO2 Settings to default. If everything works, feel free to ignore this error.")
                        Return
                    End If

                    Dim strLine As String = textLines(i).Replace(vbTab, "")
                    Dim strReturn As String() = strLine.Split("="c)
                    Dim finalString As String = strReturn(1).Replace("""", "").Replace(","c, "")
                    textLines(i) = textLines(i).Replace(finalString, (" " & value))

                    For j = 0 To textLines.Length
                        If j + 1 = textLines.Length Then
                            TextBox1.AppendText("}")
                            File.Delete(_usersettingsfile)
                            File.WriteAllText(_usersettingsfile, TextBox1.Text)
                            Return
                        End If
                        TextBox1.AppendText(textLines(j) & vbCrLf)
                    Next j

                End If
            Next i
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Private Sub btnMaxFPS_Click(sender As Object, e As EventArgs) Handles btnMaxFPS.Click
        cmbMaxFPS.DroppedDown = True
    End Sub

    Private Sub btnTextSize_Click(sender As Object, e As EventArgs) Handles btnTextSize.Click
        cmbTextSize.DroppedDown = True
    End Sub

    Private Sub cmbTextSize_Click(sender As Object, e As EventArgs) Handles cmbTextSize.SelectedIndexChanged
        btnTextSize.Text = cmbTextSize.Text
    End Sub

    Private Sub cmbShaderQuality_Click(sender As Object, e As EventArgs) Handles cmbShaderQuality.SelectedIndexChanged
        btnShaderQuality.Text = cmbShaderQuality.Text
    End Sub

    Private Sub cmbTextureResolution_Click(sender As Object, e As EventArgs) Handles cmbTextureResolution.SelectedIndexChanged
        btnTextureResolution.Text = cmbTextureResolution.Text
    End Sub

    Private Sub cmbMaxFPS_Click(sender As Object, e As EventArgs) Handles cmbMaxFPS.SelectedIndexChanged
        btnMaxFPS.Text = cmbMaxFPS.Text
    End Sub

    Private Sub TBBGMVolume_ValueChanged(sender As Object, e As EventArgs) Handles TBBGMVolume.ValueChanged
        lblBGMVolume.Text = TBBGMVolume.Value
    End Sub

    Private Sub TBMovieVolume_ValueChanged(sender As Object, e As EventArgs) Handles TBMovieVolume.ValueChanged
        lblMovieVolume.Text = TBMovieVolume.Value
    End Sub

    Private Sub TBSEVolume_ValueChanged(sender As Object, e As EventArgs) Handles TBSEVolume.ValueChanged
        lblSEVolume.Text = TBSEVolume.Value
    End Sub

    Private Sub TBVoiceVolume_ValueChanged(sender As Object, e As EventArgs) Handles TBVoiceVolume.ValueChanged
        lblVoiceVolume.Text = TBVoiceVolume.Value
    End Sub
#End Region

End Class