Imports PSO2TweakerVer2.My

Public Class frmOptionsv2
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
#Region "Layout stuff"
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Close()
    End Sub
    Private Sub btnMainClose_Click(sender As Object, e As EventArgs) Handles btnMainClose.Click
        'Closing the form, duh
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Close()
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

    Private Sub btnMainClose_MouseMove(sender As Object, e As MouseEventArgs) Handles btnMainClose.MouseMove
        btnMainClose.BackgroundImage = My.Resources.close_hover
    End Sub

    Private Sub btnGraphicSettings_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmOptions_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Visible = False
        Me.AutoScaleMode = AutoScaleMode.Dpi
        Me.AutoSize = True

        If Not String.IsNullOrEmpty(Program.GetSetting("Backup")) Then Button7.Text = Program.GetSetting("Backup")
        If Not String.IsNullOrEmpty(Program.GetSetting("ShipStatus")) Then btnShip.Text = "Ship " & Program.GetSetting("ShipStatus")
        If Not String.IsNullOrEmpty(Program.GetSetting("Pastebin")) Then chkPastebinUploads.Checked = Convert.ToBoolean(Program.GetSetting("Pastebin"))


        'chkUseIcsHost.Checked = Convert.ToBoolean(RegKey.GetValue(Of String)(RegKey.UseIcsHost))
        cmbENPatchOverride.Items.Item(1) = "Latest: " & Program.GetSetting("NewENVersion")
        cmbENPatchOverride.Items.Item(2) = "Last used: " & Program.GetSetting("ENPatchVersion")
        ComboBox1.Items.Item(1) = "Latest: " & Program.GetSetting("NewLargeFilesVersion")
        ComboBox1.Items.Item(2) = "Last used: " & Program.GetSetting("LargeFilesVersion")
        ComboBox2.Items.Item(1) = "Latest: " & Program.StoryDate
        'ComboItem33.Text = "Last used:  " & RegKey.GetValue(Of String)(RegKey.StoryPatchVersion)
        'ComboItem33.Text = "Latest: " & RegKey.GetValue(Of String)(RegKey.NewStoryVersion)
        'ComboItem40.Text = "Last used: " & RegKey.GetValue(Of String)(RegKey.LargeFilesVersion)
        'ComboItem42.Text = "Latest: " & RegKey.GetValue(Of String)(RegKey.NewLargeFilesVersion)
    End Sub
    Public Sub UpdateVersion(Patch As String, Selection As String)
        Dim value As String = Selection.Replace("Latest: ", "").Replace("Last used: ", "")
        Program.SaveSetting(Patch, value)
        MsgBox("Selected patch changed to: " & value)
    End Sub
    Private Sub btnSaveChanges_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveChanges.MouseDown
        btnSaveChanges.BackgroundImage = My.Resources.big_button_press
    End Sub

    Private Sub btnSaveChanges_MouseHover(sender As Object, e As EventArgs) Handles btnSaveChanges.MouseHover
        btnSaveChanges.BackgroundImage = My.Resources.big_button_hover
    End Sub

    Private Sub btnSaveChanges_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveChanges.MouseLeave
        btnSaveChanges.BackgroundImage = My.Resources.big_button_normal
    End Sub

    Private Sub btnSaveChanges_MouseMove(sender As Object, e As MouseEventArgs) Handles btnSaveChanges.MouseMove
        btnSaveChanges.BackgroundImage = My.Resources.big_button_hover
    End Sub


    Private Sub btnPSO2Version_MouseDown(sender As Object, e As MouseEventArgs) Handles btnPSO2Version.MouseDown
        btnPSO2Version.BackgroundImage = My.Resources.Cancel_button_press
    End Sub

    Private Sub btnPSO2Version_MouseHover(sender As Object, e As EventArgs) Handles btnPSO2Version.MouseHover
        btnPSO2Version.BackgroundImage = My.Resources.Cancel_button_hover
    End Sub

    Private Sub btnPSO2Version_MouseLeave(sender As Object, e As EventArgs) Handles btnPSO2Version.MouseLeave
        btnPSO2Version.BackgroundImage = My.Resources.Cancel_button_normal
    End Sub

    Private Sub btnPSO2Version_MouseMove(sender As Object, e As MouseEventArgs) Handles btnPSO2Version.MouseMove
        btnPSO2Version.BackgroundImage = My.Resources.Cancel_button_hover
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ComboBox1.DroppedDown = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ComboBox2.DroppedDown = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ComboBox3.DroppedDown = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        cmbENPatchOverride.DroppedDown = True
    End Sub

    Private Sub cmbENPatchOverride_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbENPatchOverride.SelectedIndexChanged
        Button4.Text = Replace(cmbENPatchOverride.Text, ":", "")
        UpdateVersion("ENPatchVersion", Button4.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button5.Text = Replace(ComboBox1.Text, ":", "")
        UpdateVersion("LargeFilesVersion", Button5.Text)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Button6.Text = Replace(ComboBox2.Text, ":", "")
        UpdateVersion("StoryPatchVersion", Button6.Text)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Button7.Text = ComboBox3.Text
        Program.SaveSetting("Backup", Button7.Text)
    End Sub

    Private Sub frmOptions_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Visible = True
    End Sub

    Private Sub frmOptionsv2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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

    Private Sub btnPSO2Version_Click(sender As Object, e As EventArgs) Handles btnPSO2Version.Click
        Dim yesNo As MsgBoxResult = MsgBox("This will tell the Tweaker you have the latest version of PSO2 installed - Be aware that this cannot be undone, and should only be used if you update the game outside of the Tweaker. Do you want to continue?", vbYesNo)

        If yesNo = vbYes Then
            Dim VersionClient As New Net.WebClient
            Program.SaveSetting("PSO2RemoteVersion", VersionClient.DownloadString("http://arks-layer.com/vanila/version.txt").Replace(" ", ""))
            frmMainv2.WriteDebugInfoAndOk("PSO2 Installed version set to the latest available!")
        End If
    End Sub

    Private Sub chkPastebinUploads_CheckedChanged(sender As Object, e As EventArgs) Handles chkPastebinUploads.CheckedChanged
        If Not chkPastebinUploads.Checked Then
            MsgBox("PLEASE BE AWARE - If you turn this function off, the program will not automatically upload your logfile to pastebin so you can easily report bugs/issues. This means that you'll need to provide the logfile yourself, or the likelyhood of your issue being resolved is very, very, slim.")
        End If
        Program.SaveSetting("Pastebin", chkPastebinUploads.Checked.ToString())
    End Sub

    Private Sub btnSaveChanges_Click(sender As Object, e As EventArgs) Handles btnSaveChanges.Click
        'Closing the form, duh
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Hide()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub btnTitle_Click(sender As Object, e As EventArgs) Handles btnTitle.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub btnShip_Click(sender As Object, e As EventArgs) Handles btnShip.Click
        cmbShip.DroppedDown = True
    End Sub

    Private Sub cmbShip_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbShip.SelectedIndexChanged
        btnShip.Text = cmbShip.Text
        Program.SaveSetting("ShipStatus", btnShip.Text.Replace("Ship ", "").Replace("Ship 1", ""))
    End Sub
#End Region

End Class