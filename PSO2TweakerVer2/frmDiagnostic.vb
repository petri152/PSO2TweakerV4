Imports System.IO
Imports System.Net
Imports PSO2TweakerVer2.My

Public Class FrmDiagnostic

    Private Shared Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim totalString As String = ""

        totalString &= "OS: " & Computer.Info.OSFullName & vbCrLf
        totalString &= "64 Bit OS?: " & Environment.Is64BitOperatingSystem.ToString() & vbCrLf
        totalString &= "Tweaker is located at: " & Environment.CurrentDirectory & vbCrLf
        totalString &= ".NET Version: " & Environment.Version.ToString() & vbCrLf
        totalString &= "System has been on for: " & Mid((Environment.TickCount / 3600000).ToString(), 1, 5) & " hours"
        Helper.PasteBinText(totalString)

    End Sub

    Private Shared Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim totalString As String = ""
        For Each line As String In Helper.GetLines(Program.HostsFilePath)
            If line <> "" Then totalString &= line & vbCrLf
        Next
        If totalString = "" Then totalString = "No modified host entries detected!"

        frmMainv2.DownloadFile("http://download.sysinternals.com/files/Handle.zip", "Handle.zip")

        frmMainv2.ExtractFiles("Handle.zip", Program.StartPath)

        Dim start_info As New ProcessStartInfo("cmd.exe", "/c handle %windir%\system32\drivers\etc\hosts -accepteula")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = False
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As IO.StreamReader = proc.StandardOutput()

        ' Display the results.
        Dim OutputText As String = totalString & vbNewLine & "HOSTS Handle stuff:" & vbNewLine & std_out.ReadToEnd()

        ' Clean up.
        std_out.Close()

        proc.Close()
        Helper.PasteBinText(OutputText)
        Helper.DeleteFile("Eula.txt")
        Helper.DeleteFile("handle.exe")
        Helper.DeleteFile("handle64.exe")
        Helper.DeleteFile("Handle.zip")
    End Sub

    Private Shared Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim drInfo As New DirectoryInfo(Program.PSO2WinDir)
        Dim filesInfo As FileInfo() = drInfo.GetFiles("*.*", SearchOption.AllDirectories)
        Dim fileSize As Long = filesInfo.Sum(Function(fileInfo) fileInfo.Length)

        Dim totalString As String = ""
        totalString &= "PSO2 Directory: " & Program.PSO2RootDir & vbCrLf
        totalString &= "Current game version: " & Program.GetSetting("PSO2RemoteVersion") & vbCrLf
        totalString &= "Using RAISER patch: " & Program.GetSetting("NewMethodEnabled") & vbCrLf
        totalString &= "Large Files version installed: " & Program.GetSetting("LargeFilesVersion") & vbCrLf
        totalString &= "Story Patch version installed: " & Program.GetSetting("StoryPatchVersion") & vbCrLf
        totalString &= "Size of PSO2 data/win32 folder: ~" & fileSize.ToString().Remove(2, 9) & "GB"
        Helper.PasteBinText(totalString)

    End Sub

    Private Shared Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim drInfo As New DirectoryInfo(Program.PSO2RootDir)
        Dim filesInfo As FileInfo() = drInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly)
        Dim fileSize As Long
        Dim filename As String
        Dim totalString As String = "Listing of pso2_bin files: "

        For Each fileInfo As FileInfo In filesInfo
            filename = fileInfo.Name
            fileSize = fileInfo.Length
            totalString &= filename
            If filename = "GameGuard.des" OrElse filename = "pso2.exe" OrElse filename = "publickey.blob" OrElse filename = "rsainject.dll" OrElse filename = "translation_items.bin" OrElse filename = "PSO2ItemTranslator.dll" Then totalString &= ": " & fileSize.ToString()

            totalString &= " | "
        Next

        Helper.PasteBinText(totalString)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim start_info As New ProcessStartInfo("cmd.exe", "/c ipconfig /flushdns")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As IO.StreamReader = proc.StandardOutput()

        ' Display the results.
        Helper.PasteBinText(std_out.ReadToEnd())

        ' Clean up.
        std_out.Close()

        proc.Close()

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim start_info As New ProcessStartInfo("cmd.exe", "/c ping -n 5 patch02.pso2gs.net")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As IO.StreamReader = proc.StandardOutput()

        ' Display the results.
        Helper.PasteBinText(std_out.ReadToEnd())

        ' Clean up.
        std_out.Close()

        proc.Close()
    End Sub

    Private Sub FrmDiagnostic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim host As IPHostEntry = Dns.GetHostEntry("gs016.pso2gs.net")

        Dim ip As IPAddress() = host.AddressList

        'Dim index As Integer
        'For index = 0 To ip.Length - 1
        ' Console.WriteLine(ip(index))
        ' Next index
        lblPSO2Test.Text = "gs016.pso2gs.net (Ship 2) resolves to: " & ip(0).ToString
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim start_info As New ProcessStartInfo("cmd.exe", "/c netsh winsock show catalog")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = True
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As IO.StreamReader = proc.StandardOutput()

        ' Display the results.
        Helper.PasteBinText(std_out.ReadToEnd())

        ' Clean up.
        std_out.Close()

        proc.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        frmMainv2.DownloadFile("http://download.sysinternals.com/files/Autoruns.zip", "autoruns.zip")

        frmMainv2.ExtractFiles("autoruns.zip", Program.StartPath)

        Dim start_info As New ProcessStartInfo("cmd.exe", "/c autorunsc.exe -a * -c -s -accepteula")
        start_info.UseShellExecute = False
        start_info.CreateNoWindow = False
        start_info.RedirectStandardOutput = True
        start_info.RedirectStandardError = True

        ' Make the process and set its start information.
        Dim proc As New Process()
        proc.StartInfo = start_info

        ' Start the process.
        proc.Start()

        ' Attach to stdout and stderr.
        Dim std_out As IO.StreamReader = proc.StandardOutput()

        ' Display the results.
        Helper.PasteBinText(std_out.ReadToEnd())

        ' Clean up.
        std_out.Close()

        proc.Close()
        Helper.DeleteFile("autoruns.chm")
        Helper.DeleteFile("Autoruns.exe")
        Helper.DeleteFile("Autoruns64.exe")
        Helper.DeleteFile("autorunsc.exe")
        Helper.DeleteFile("autorunsc64.exe")
        Helper.DeleteFile("Eula.txt")
        Helper.DeleteFile("autoruns.zip")
    End Sub
End Class