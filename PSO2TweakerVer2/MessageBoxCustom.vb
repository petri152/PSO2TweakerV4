Imports System.IO
Imports PSO2TweakerVer2.My
Public Class MessageBoxCustom
    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer
    Public MessageBoxType As Integer

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
    Private Sub btnForceCheck_MouseDown(sender As Object, e As MouseEventArgs) Handles btnYes.MouseDown
        btnYes.BackgroundImage = My.Resources.Cancel_button_press_msgbox
    End Sub

    Private Sub btnForceCheck_MouseHover(sender As Object, e As EventArgs) Handles btnYes.MouseHover
        btnYes.BackgroundImage = My.Resources.Cancel_button_hover_msgbox
    End Sub

    Private Sub btnForceCheck_MouseLeave(sender As Object, e As EventArgs) Handles btnYes.MouseLeave
        btnYes.BackgroundImage = My.Resources.Cancel_button_normal_msgbox
    End Sub

    Private Sub btnForceCheck_MouseMove(sender As Object, e As MouseEventArgs) Handles btnYes.MouseMove
        btnYes.BackgroundImage = My.Resources.Cancel_button_hover_msgbox
    End Sub
    Private Sub btnSave_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNo.MouseDown
        btnNo.BackgroundImage = My.Resources.Cancel_button_press_msgbox
    End Sub

    Private Sub btnSave_MouseHover(sender As Object, e As EventArgs) Handles btnNo.MouseHover
        btnNo.BackgroundImage = My.Resources.Cancel_button_hover_msgbox
    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnNo.MouseLeave
        btnNo.BackgroundImage = My.Resources.Cancel_button_normal_msgbox
    End Sub

    Private Sub btnSave_MouseMove(sender As Object, e As MouseEventArgs) Handles btnNo.MouseMove
        btnNo.BackgroundImage = My.Resources.Cancel_button_hover_msgbox
    End Sub
    Private Sub btnOther_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOther.MouseDown
        btnOther.BackgroundImage = My.Resources.Cancel_button_press_msgbox
    End Sub

    Private Sub btnOther_MouseHover(sender As Object, e As EventArgs) Handles btnOther.MouseHover
        btnOther.BackgroundImage = My.Resources.Cancel_button_hover_msgbox
    End Sub

    Private Sub btnOther_MouseLeave(sender As Object, e As EventArgs) Handles btnOther.MouseLeave
        btnOther.BackgroundImage = My.Resources.Cancel_button_normal_msgbox
    End Sub

    Private Sub btnOther_MouseMove(sender As Object, e As MouseEventArgs) Handles btnOther.MouseMove
        btnOther.BackgroundImage = My.Resources.Cancel_button_hover_msgbox
    End Sub

    Private Sub btnMainClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub


    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    Private Sub btnConfigure_Click(sender As Object, e As EventArgs) Handles btnOther.Click
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub


    Private Sub lblMessage_MouseMove(sender As Object, e As MouseEventArgs) Handles lblMessage.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub lblMessage_MouseDown(sender As Object, e As MouseEventArgs) Handles lblMessage.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub lblMessage_MouseUp(sender As Object, e As MouseEventArgs) Handles lblMessage.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub MessageBoxCustom_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub MessageBoxCustom_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If IsFormBeingDragged Then
            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub MessageBoxCustom_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub MessageBoxCustom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If Parent IsNot Nothing Then
            r = Parent.RectangleToScreen(Parent.ClientRectangle)
        Else
            r = Screen.FromPoint(Me.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - Me.Width) \ 2
        Dim y = r.Top + (r.Height - Me.Height) \ 2
        Me.Location = New Point(x, y)
    End Sub
End Class