Public Class frmDownloader
    Public Sub CleanupUI()
        ProgressBarX1.Text = ""
        ProgressBarX2.Text = ""
        ProgressBarX3.Text = ""
        ProgressBarX4.Text = ""
        ProgressBarX5.Text = ""
        ProgressBarX6.Text = ""
        ProgressBarX1.Value = 0
        ProgressBarX2.Value = 0
        ProgressBarX3.Value = 0
        ProgressBarX4.Value = 0
        ProgressBarX5.Value = 0
        ProgressBarX6.Value = 0
        LabelX1.Text = ""
        LabelX2.Text = ""
        LabelX3.Text = ""
        LabelX4.Text = ""
        LabelX5.Text = ""
        LabelX6.Text = ""
        lblTotal.Text = "Initializing system, please wait..."
        Application.DoEvents()
    End Sub

    Private Sub frmDownloader_Load(sender As Object, e As EventArgs) Handles Me.Load
        If frmMainv2.Visible = False Then
            Me.Close()
            Application.Exit()
        End If
    End Sub
End Class