Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports PSO2TweakerVer2.My

Public Class frmPlugins
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Public pluginEntries As Dictionary(Of String, PluginClass)
    Private Sub btnPSO2Version_Click(sender As Object, e As EventArgs) Handles btnForceCheck.Click
        frmMainv2.CheckForPluginUpdates()
        Me.Close()
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
    Private Sub btnForceCheck_MouseDown(sender As Object, e As MouseEventArgs) Handles btnForceCheck.MouseDown
        btnForceCheck.BackgroundImage = My.Resources.Cancel_button_press
    End Sub

    Private Sub btnForceCheck_MouseHover(sender As Object, e As EventArgs) Handles btnForceCheck.MouseHover
        btnForceCheck.BackgroundImage = My.Resources.Cancel_button_hover
    End Sub

    Private Sub btnForceCheck_MouseLeave(sender As Object, e As EventArgs) Handles btnForceCheck.MouseLeave
        btnForceCheck.BackgroundImage = My.Resources.Cancel_button_normal
    End Sub

    Private Sub btnForceCheck_MouseMove(sender As Object, e As MouseEventArgs) Handles btnForceCheck.MouseMove
        btnForceCheck.BackgroundImage = My.Resources.Cancel_button_hover
    End Sub
    Private Sub btnSave_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSave.MouseDown
        btnSave.BackgroundImage = My.Resources.Cancel_button_press
    End Sub

    Private Sub btnSave_MouseHover(sender As Object, e As EventArgs) Handles btnSave.MouseHover
        btnSave.BackgroundImage = My.Resources.Cancel_button_hover
    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackgroundImage = My.Resources.Cancel_button_normal
    End Sub

    Private Sub btnSave_MouseMove(sender As Object, e As MouseEventArgs) Handles btnSave.MouseMove
        btnSave.BackgroundImage = My.Resources.Cancel_button_hover
    End Sub

    Private Sub frmPlugins_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim JSONClient As New WebClient
        If Program.NewMethodJSON.Contains("pso2.acf.me.uk") Then JSONClient.Headers("user-agent") = VEDA.FuckOffKaze()
        pluginEntries = JsonConvert.DeserializeObject(Of Dictionary(Of String, PluginClass))(JSONClient.DownloadString(Program.PluginURL & "plugins.json"))
        frmMainv2.CheckForPluginUpdates(True)
        ListView1.Clear()
        Dim localfilename As String = "nowhere"
        For Each item As KeyValuePair(Of String, PluginClass) In pluginEntries

            If File.Exists(Program.PSO2RootDir & "\plugins\" & item.Value.Filename) = True Then
                localfilename = Program.PSO2RootDir & "\plugins\" & item.Value.Filename
                ListView1.Items.Add(item.Value.Name)
                ListView1.FindItemWithText(item.Value.Name).Checked = True
            End If

            If File.Exists(Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename) = True Then
                localfilename = Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename
                ListView1.Items.Add(item.Value.Name)
                ListView1.FindItemWithText(item.Value.Name).Checked = False
            End If

            If File.Exists(Program.PSO2RootDir & "\" & item.Value.Filename) = True Then
                localfilename = Program.PSO2RootDir & "\" & item.Value.Filename
            End If

            If localfilename = "nowhere" Then
                If item.Value.StorePath.Contains("plugins") Then
                    JSONClient.DownloadFile(Program.PluginURL & item.Value.Filename, Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename)
                    localfilename = Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename
                    ListView1.Items.Add(item.Value.Name)
                    ListView1.FindItemWithText(item.Value.Name).Checked = False
                Else
                    JSONClient.DownloadFile(Program.PluginURL & item.Value.Filename, Program.PSO2RootDir & item.Value.StorePath & item.Value.Filename)
                    localfilename = Program.PSO2RootDir & item.Value.StorePath & item.Value.Filename
                End If
            End If
            Label1.Text = ""

        Next
    End Sub

    Private Sub btnMainClose_Click(sender As Object, e As EventArgs) Handles btnMainClose.Click
        Me.Close()
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
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.FocusedItem Is Nothing Then Exit Sub
        'Name: 
        'Filename:
        'Author(s)
        'Description: Line 1
        'Line 2
        'Line 3
        For Each item As KeyValuePair(Of String, PluginClass) In pluginEntries
            If item.Value.Name = ListView1.FocusedItem.Text Then
                Label1.Text = "Name: " & item.Value.Name & vbCrLf & "Filename: " & item.Value.Filename & vbCrLf & "Author(s): " & item.Value.Author & vbCrLf & "Description: " & item.Value.Description
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        frmMainv2.CheckForPluginUpdates(True)
        Dim FinalExportString As String = ""
        Dim localfilename As String = "nowhere"
        For l_index As Integer = 0 To ListView1.Items.Count - 1
            localfilename = "nowhere"
            For Each item As KeyValuePair(Of String, PluginClass) In pluginEntries
                If ListView1.Items(l_index).Text = item.Value.Name Then
                    If File.Exists(Program.PSO2RootDir & "\plugins\" & item.Value.Filename) = True Then localfilename = Program.PSO2RootDir & "\plugins\" & item.Value.Filename
                    If File.Exists(Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename) = True Then localfilename = Program.PSO2RootDir & "\plugins\disabled\" & item.Value.Filename
                    If File.Exists(Program.PSO2RootDir & "\" & item.Value.Filename) = True Then localfilename = Program.PSO2RootDir & "\" & item.Value.Filename
                End If
            Next
            If ListView1.Items(l_index).Checked = True Then
                'Enable
                If localfilename.Contains(Program.PSO2RootDir & "\plugins\disabled\") Then
                    File.Move(localfilename, localfilename.Replace("\disabled", ""))
                    Helper.Log("Moving " & localfilename & " to the root plugins folder (" & localfilename.Replace("\disabled", "") & ")")
                End If
                If localfilename = "PSO2ItemTranslator.dll" Then
                    If Not File.Exists(Program.PSO2RootDir & "\translation.cfg") Then
                        File.WriteAllText(Program.PSO2RootDir & "\translation.cfg", "TranslationPath:translation_items.bin")
                    End If

                    'Start the shitstorm
                    Dim builtFile As New List(Of String)
                    For Each line In Helper.GetLines(Program.PSO2RootDir & "\translation.cfg")
                        If line.Contains("TranslationPath:") Then line = "TranslationPath:translation_items.bin"
                        builtFile.Add(line)
                    Next
                    File.WriteAllLines(Program.PSO2RootDir & "\translation.cfg", builtFile.ToArray())

                End If
                'Do nothing! :D
            Else
                'Disable
                If localfilename.Contains(Program.PSO2RootDir & "\plugins\disabled\") = False Then
                    File.Move(localfilename, localfilename.Replace("\plugins", "\plugins\disabled"))
                    Helper.Log("Moving " & localfilename & " to the disabled folder (" & localfilename.Replace("\plugins", "\plugins\disabled") & ")")
                End If
                If localfilename = "PSO2ItemTranslator.dll" Then
                    Dim builtFile As New List(Of String)
                    If Not File.Exists(Program.PSO2RootDir & "\translation.cfg") Then
                        File.WriteAllText(Program.PSO2RootDir & "\translation.cfg", "TranslationPath:translation_items.bin")
                    End If
                    For Each line In Helper.GetLines(Program.PSO2RootDir & "\translation.cfg")
                        If line.Contains("TranslationPath:") Then line = "TranslationPath:"
                        builtFile.Add(line)
                    Next
                    File.WriteAllLines(Program.PSO2RootDir & "\translation.cfg", builtFile.ToArray())
                End If
            End If
        Next
        frmMainv2.WriteDebugInfoAndOk("Plugin changes saved!")
        Dim enabledplugins As String = ""
        Dim disabledplugins As String = ""
        Dim count As Integer = 0
        If Directory.Exists(Program.PSO2RootDir & "\plugins\") Then
            For Each file In Directory.GetFiles(Program.PSO2RootDir & "\plugins\")
                enabledplugins += file.Replace(Program.PSO2RootDir & "\plugins\", "") + ", "
                count += 1
            Next
            If count > 0 Then
                Helper.Log("Enabled Plugins: " & enabledplugins.Remove(enabledplugins.Length - 2))
            Else
                Helper.Log("Enabled Plugins: None")
            End If
        End If
        count = 0
        If Directory.Exists(Program.PSO2RootDir & "\plugins\disabled\") Then
            For Each file In Directory.GetFiles(Program.PSO2RootDir & "\plugins\disabled\")
                disabledplugins += file.Replace(Program.PSO2RootDir & "\plugins\disabled\", "") + ", "
                count += 1
            Next
            If count > 0 Then
                Helper.Log("Disabled Plugins: " & disabledplugins.Remove(disabledplugins.Length - 2))
            Else
                Helper.Log("Disabled Plugins: None")
            End If
        End If
        Me.Close()
    End Sub

    Private Sub ListView1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListView1.ItemCheck
        For Each item As KeyValuePair(Of String, PluginClass) In pluginEntries
            If item.Value.Name = ListView1.Items.Item(e.Index).Text Then
                Label1.Text = "Name: " & item.Value.Name & vbCrLf & "Filename: " & item.Value.Filename & vbCrLf & "Author(s): " & item.Value.Author & vbCrLf & "Description: " & item.Value.Description
            End If
        Next
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class