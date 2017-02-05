Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports PSO2TweakerVer2.My

Public Class frmTweaksv2
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
#Region "Layout stuff"
    Private Sub btnTweaks_Click(sender As Object, e As EventArgs)
        frmOptionsv2.Location = Me.DesktopLocation
        Me.Visible = False
        Me.Close()
        frmOptionsv2.Close()
        frmOptionsv2.ShowDialog(frmMainv2)
    End Sub

    Private Sub btnGraphicSettings_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Close()
    End Sub

    Private Sub btnMainClose_Click(sender As Object, e As EventArgs) Handles btnMainClose.Click
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

    Private Sub btnMainClose_MouseMove(sender As Object, e As MouseEventArgs) Handles btnMainClose.MouseMove
        btnMainClose.BackgroundImage = My.Resources.close_hover
    End Sub
    Private Sub btnReturn_MouseDown(sender As Object, e As MouseEventArgs) Handles btnReturn.MouseDown
        btnReturn.BackgroundImage = My.Resources.big_button_press
    End Sub

    Private Sub btnReturn_MouseHover(sender As Object, e As EventArgs) Handles btnReturn.MouseHover
        btnReturn.BackgroundImage = My.Resources.big_button_hover
    End Sub

    Private Sub btnReturn_MouseLeave(sender As Object, e As EventArgs) Handles btnReturn.MouseLeave
        btnReturn.BackgroundImage = My.Resources.big_button_normal
    End Sub

    Private Sub btnReturn_MouseMove(sender As Object, e As MouseEventArgs) Handles btnReturn.MouseMove
        btnReturn.BackgroundImage = My.Resources.big_button_hover
    End Sub

    Private Sub frmTweaks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoScaleMode = AutoScaleMode.Dpi
        Me.AutoSize = True
        chkRemoveNVidia.Checked = False
        chkRemovePC.Checked = False
        chkRemoveSEGA.Checked = False
        chkRemoveVita.Checked = False
        chkRestoreNVidia.Checked = False
        chkRestorePC.Checked = False
        chkRestoreSEGA.Checked = False
        chkRestoreVita.Checked = False
        Label2.Text = Program.GetSetting("PSO2Dir")
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

    Private Sub frmTweaksv2_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        'Save the stuff here
        Try
            Helper.Log("Restoring/Removing files...")
            If chkRemoveNVidia.Checked AndAlso chkRestoreNVidia.Checked Then
                MsgBox("You cannot restore and remove at the same time.")
                Return
            End If
            If chkRemovePC.Checked AndAlso chkRestorePC.Checked Then
                MsgBox("You cannot restore and remove at the same time.")
                Return
            End If
            If chkRemoveVita.Checked AndAlso chkRestoreVita.Checked Then
                MsgBox("You cannot restore and remove at the same time.")
                Return
            End If
            If chkRemoveSEGA.Checked AndAlso chkRestoreSEGA.Checked Then
                MsgBox("You cannot restore and remove at the same time.")
                Return
            End If

            If Directory.Exists(Program.PSO2WinDir & "\backup\") = False Then
                Helper.Log("Could not find the backup path! Are you sure you have a backup in your win32/backup folder? Let's make one.")
                Directory.CreateDirectory(Program.PSO2WinDir & "\backup\")
                Return
            End If

            'Remove PC Opening Video [Done]
            If chkRemovePC.Checked AndAlso File.Exists((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927")) Then
                If File.Exists((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927"), (Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927"))
                frmMainv2.WriteDebugInfoAndOk("Removing PC Opening Video...")
            ElseIf chkRemovePC.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927"))) Then
                frmMainv2.WriteDebugInfoAndWarning("PC Opening Video File does not exist. Did you already remove it?")
            End If

            'Restore PC Opening Video [Done]
            If chkRestorePC.Checked AndAlso File.Exists((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927")) Then
                If File.Exists((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\" & "a44fbb2aeb8084c5a5fbe80e219a9927"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927"), (Program.PSO2WinDir & "\a44fbb2aeb8084c5a5fbe80e219a9927"))
                frmMainv2.WriteDebugInfoAndOk("Restoring PC Opening Video...")
            ElseIf chkRestorePC.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\backup\a44fbb2aeb8084c5a5fbe80e219a9927"))) Then
                frmMainv2.WriteDebugInfoAndWarning("PC Opening Video File backup does not exist. Did you already restore it?")
            End If

            'Remove Vita Opening Video [Done]
            If chkRemoveVita.Checked AndAlso File.Exists((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585")) Then
                If File.Exists((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585"), (Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585"))
                frmMainv2.WriteDebugInfoAndOk("Removing Vita Opening Video...")
            ElseIf chkRemoveVita.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585"))) Then
                frmMainv2.WriteDebugInfoAndWarning("Vita Opening Video File does not exist. Did you already remove it?")
            End If

            'Restore Vita Opening Video [Done]
            If chkRestoreVita.Checked AndAlso File.Exists((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585")) Then
                If File.Exists((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\" & "a93adc766eb3510f7b5c279551a45585"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585"), (Program.PSO2WinDir & "\a93adc766eb3510f7b5c279551a45585"))
                frmMainv2.WriteDebugInfoAndOk("Restoring Vita Opening Video...")
            ElseIf chkRestoreVita.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\backup\a93adc766eb3510f7b5c279551a45585"))) Then
                frmMainv2.WriteDebugInfoAndWarning("Vita Opening Video File backup does not exist. Did you already restore it?")
            End If

            'Remove NVidia Opening Video [Done]
            If chkRemoveNVidia.Checked AndAlso File.Exists((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75")) Then
                If File.Exists((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75"), (Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75"))
                frmMainv2.WriteDebugInfoAndOk("Removing NVidia Opening Video...")
            ElseIf chkRemoveNVidia.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75"))) Then
                frmMainv2.WriteDebugInfoAndWarning("Vita Opening Video File backup does not exist. Did you already restore it?")
            End If

            'Restore NVidia Opening Video [Done]
            If chkRestoreNVidia.Checked AndAlso File.Exists((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75")) Then
                If File.Exists((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\" & "7f2368d207e104e8ed6086959b742c75"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75"), (Program.PSO2WinDir & "\7f2368d207e104e8ed6086959b742c75"))
                frmMainv2.WriteDebugInfoAndOk("Restoring NVidia Opening Video...")
            ElseIf chkRestoreNVidia.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\backup\7f2368d207e104e8ed6086959b742c75"))) Then
                frmMainv2.WriteDebugInfoAndWarning("NVidia Logo Video File backup does not exist. Did you already restore it?")
            End If

            'Remove SEGA Opening Video [Done]
            If chkRemoveSEGA.Checked AndAlso File.Exists((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771")) Then
                If File.Exists((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771"), (Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771"))
                frmMainv2.WriteDebugInfoAndOk("Removing SEGA Opening Video...")
            ElseIf chkRemoveSEGA.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771"))) Then
                frmMainv2.WriteDebugInfoAndWarning("SEGA Logo Video File does not exist. Did you already remove it?")
            End If

            'Restore SEGA Opening Video [Done]
            If chkRestoreSEGA.Checked AndAlso File.Exists((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771")) Then
                If File.Exists((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771")) Then Computer.FileSystem.DeleteFile((Program.PSO2WinDir & "\" & "009bfec69b04a34576012d50e3417771"), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently)
                File.Move((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771"), (Program.PSO2WinDir & "\009bfec69b04a34576012d50e3417771"))
                frmMainv2.WriteDebugInfoAndOk("Restoring SEGA Opening Video...")
            ElseIf chkRestoreSEGA.Checked AndAlso (Not File.Exists((Program.PSO2WinDir & "\backup\009bfec69b04a34576012d50e3417771"))) Then
                frmMainv2.WriteDebugInfoAndWarning("SEGA Logo Video File backup does not exist. Did you already restore it?")
            End If

        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
        'Closing the form, duh
        frmMainv2.Location = Me.DesktopLocation
        frmMainv2.Visible = True
        Me.Hide()
    End Sub

#End Region
End Class