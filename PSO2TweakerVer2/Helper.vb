Imports System.ComponentModel
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
Imports PSO2TweakerVer2.My
Imports PSO2TweakerVer2.VEDA

Public Class Helper
    Private Shared ReadOnly SizeSuffixes As String() = {"bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}
    Private Shared ReadOnly HexTable As String() = {"00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "0A", "0B", "0C", "0D", "0E", "0F", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "1A", "1B", "1C", "1D", "1E", "1F", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "2A", "2B", "2C", "2D", "2E", "2F", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "3A", "3B", "3C", "3D", "3E", "3F", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "4A", "4B", "4C", "4D", "4E", "4F", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "5A", "5B", "5C", "5D", "5E", "5F", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "6A", "6B", "6C", "6D", "6E", "6F", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "7A", "7B", "7C", "7D", "7E", "7F", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "8A", "8B", "8C", "8D", "8E", "8F", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "9A", "9B", "9C", "9D", "9E", "9F", "A0", "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "AA", "AB", "AC", "AD", "AE", "AF", "B0", "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "BA", "BB", "BC", "BD", "BE", "BF", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "CA", "CB", "CC", "CD", "CE", "CF", "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "DA", "DB", "DC", "DD", "DE", "DF", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "EA", "EB", "EC", "ED", "EE", "EF", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "FA", "FB", "FC", "FD", "FE", "FF"}
    Private Shared ReadOnly Md5Provider As New Md5Provider(&H100000)
    Private Shared ReadOnly FolderDownloads As New Guid("374DE290-123F-4565-9164-39C4925E467B")
    Private Shared ReadOnly Generator As Random = New Random()
    Public Shared ReadOnly DefaltCultureInfo As CultureInfo = New CultureInfo("en")

    Public Shared Iterator Function GetLines(path As String) As IEnumerable(Of String)
        Using reader = File.OpenText(path)
            Dim currentLine As String
            Do
                currentLine = reader.ReadLine()
                If (currentLine Is Nothing) Then Exit Do
                Yield currentLine
            Loop

            reader.Close()
        End Using
    End Function

    Public Shared Sub Log(output As String)
        File.AppendAllText(Program.StartPath & "\logfile.txt", DateTime.Now.ToString("G") & ": DEBUG - " & output & vbCrLf)
    End Sub



    Public Shared Sub PasteBinUpload()
        PasteBinUploadFile(Program.StartPath & "\logfile.txt")
    End Sub

    Public Shared Sub DeleteFile(path As String)
        Try
            If File.Exists(path) Then File.Delete(path)
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
    End Sub


    Public Shared Function CheckIfRunning(processName As String) As Boolean
        Try
            Dim currentProcessId = Process.GetCurrentProcess().Id

            If Process.GetProcessesByName(processName).Length > If(processName = "PSO2 Tweaker", 1, 0) Then
                Dim closeItYesNo As MsgBoxResult = MsgBox("It seems that " & processName.Replace(".exe", "") & " is already running. Would you like to close it?", vbYesNo)

                If closeItYesNo = vbYes Then
                    Helper.Log("It seems that " & processName.Replace(".exe", "") & " is already running. Would you like to close it? [Yes]")
                    For Each proc As Process In Process.GetProcessesByName(processName)
                        If proc.Id <> currentProcessId Then proc.Kill()
                    Next
                    If processName = "PSO2 Tweaker" Then
                        Process.Start("PSO2 Tweaker.exe")
                    End If
                End If
                If closeItYesNo = vbNo Then Helper.Log("It seems that " & processName.Replace(".exe", "") & " is already running. Would you like to close it? [No]")
            Else
                Return False
            End If
        Catch ex As Exception
            Helper.LogWithException("ERROR - ", ex)
        End Try
        Return True

    End Function


    Public Shared Function CheckIfOfficialLauncherRunning() As Boolean
        Dim processName As String = "pso2launcher"
        Dim currentProcessId = Process.GetCurrentProcess().Id

        If Process.GetProcessesByName(processName).Length > If(processName = "PSO2 Tweaker", 1, 0) Then
            Dim closeItYesNo As MsgBoxResult = MsgBox("It seems that " & processName.Replace(".exe", "") & " is already running. This can cause various issues with filechecking. Would you like to close it?", vbYesNo)

            If closeItYesNo = vbYes Then
                For Each proc As Process In Process.GetProcessesByName(processName)
                    If proc.Id <> currentProcessId Then proc.Kill()
                Next

            End If
        Else
            Return False
        End If

        Return True
    End Function
    Public Shared Function GetFolderSize(ByVal path As String, Optional recurse As Boolean = False) As Long
        Dim totalSize As Long = 0
        Dim files() As String = Directory.GetFiles(path)
        Parallel.For(0, files.Length,
                 Sub(index As Integer)
                     Dim fi As New FileInfo(files(index))
                     Dim size As Long = fi.Length
                     Interlocked.Add(totalSize, size)
                 End Sub)

        If recurse Then
            Dim subDirs() As String = Directory.GetDirectories(path)
            Dim subTotal As Long = 0
            Parallel.For(0, subDirs.Length,
                     Function(index As Integer)
                         If (File.GetAttributes(subDirs(index)) And FileAttributes.ReparsePoint) <> FileAttributes.ReparsePoint Then
                             Interlocked.Add(subTotal, GetFolderSize(subDirs(index), True))
                             Return subTotal
                         End If
                         Return 0
                     End Function)
            Interlocked.Add(totalSize, subTotal)
        End If

        Return totalSize
    End Function
    Public Shared Function GetFileSize(ByVal myFilePath As String) As Long
        Return New FileInfo(myFilePath).Length
    End Function

    Public Shared Sub DeleteDirectory(path As String)
        If Directory.Exists(path) Then Directory.Delete(path, True)
    End Sub

    Public Shared Function GetRandom(ByVal min As Integer, ByVal max As Integer) As Integer
        Return Generator.Next(min, max)
    End Function

    Public Shared Function IsFileInUse(ByVal path As String) As Boolean
        Try
            Using stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
                stream.Close()
            End Using
        Catch
            Return True
        End Try

        Return False
    End Function

    Public Shared Sub PasteBinUploadFile(fileToUpload As String)
        ServicePointManager.Expect100Continue = False

        Using client As New WebClient()
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
            Dim data As String = "?api_paste_private=1&api_option=paste&api_paste_name=Error Log report&api_paste_format=text&api_paste_expire_date=N&api_dev_key=ddc1e2efaca45d3df87e6b93ceb43c9f&api_paste_code=" & File.ReadAllText(fileToUpload)
            Dim responce = client.UploadString("http://pastebin.com/api/api_post.php", "POST", data)
            MsgBox("Whoops, something went wrong! The Tweaker will now open a pastebin page with your log. Please join the Phantasy Star Fleet Discord chat's (The link is available on the right of the main window) #support and post it there so we can help you/fix the issue. Thanks! - AIDA")
            Process.Start(responce)
        End Using
    End Sub

    Public Shared Sub PasteBinText(TextToUpload As String)
        ServicePointManager.Expect100Continue = False

        Using client As New WebClient()
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
            Dim output As String = ""
            Dim random As New Random()

            Dim val As Integer
            For i As Integer = 0 To 16
                val = random.[Next](1, 36)
                output += ChrW(CInt(IIf(val <= 26, 64 + val, (val - 27) + 48)))
            Next

            Dim data As String = "?api_paste_private=1&api_option=paste&api_paste_name=" & output & "&api_paste_format=text&api_paste_expire_date=N&api_dev_key=ddc1e2efaca45d3df87e6b93ceb43c9f&api_paste_code=" & TextToUpload
            Dim responce = client.UploadString("http://pastebin.com/api/api_post.php", "POST", data)
            Process.Start(responce)
        End Using
    End Sub

    Public Shared Function CheckLink(ByVal url As String) As Boolean
        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            request.Timeout = 5000
            request.Method = "HEAD"

            Using response As WebResponse = request.GetResponse()
                Return (response IsNot Nothing)
            End Using
        Catch
            Return False
        End Try
    End Function

    Public Shared Function GetDownloadsPath() As String
        Dim path1 As String
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim pathPtr As IntPtr
            Dim hr As Integer = External.ShGetKnownFolderPath(FolderDownloads, 0, IntPtr.Zero, pathPtr)
            If hr = 0 Then
                path1 = Marshal.PtrToStringUni(pathPtr)
                Marshal.FreeCoTaskMem(pathPtr)
                Return path1
            End If
        End If
        path1 = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Personal))
        path1 = Path.Combine(path1, "Downloads")
        Return path1
    End Function

    Public Shared Function GetMd5(ByVal path As String) As String
        Try
            Using stream As FileStream = File.Open(path, FileMode.Open)
                Return GetMd5(stream)
            End Using
        Catch
        End Try

        Return ""
    End Function

    Public Shared Function GetMd5(stream As Stream) As String
        Try
            Dim hash = Md5Provider.ComputeHash(stream)
            Return String.Join("", HexTable(hash(0)), HexTable(hash(1)), HexTable(hash(2)), HexTable(hash(3)), HexTable(hash(4)), HexTable(hash(5)), HexTable(hash(6)), HexTable(hash(7)), HexTable(hash(8)), HexTable(hash(9)), HexTable(hash(10)), HexTable(hash(11)), HexTable(hash(12)), HexTable(hash(13)), HexTable(hash(14)), HexTable(hash(15)))
        Catch
        End Try

        Return ""
    End Function

    Public Shared Function SizeSuffix(ByVal value As Long) As String
        If value < 0 Then Return "-" & SizeSuffix(-value)
        If value = 0 Then Return "0 bytes"

        Dim pow As ULong = 1
        Dim index As Integer = 0

        While pow <= value
            pow <<= 10
            index += 1
        End While

        pow >>= 10

        Return String.Format("{0:n2} {1}", value / pow, SizeSuffixes(index - 1))
    End Function

    Public Shared Sub SelectPso2Directory()
        Try
            Log("Selecting PSO2 Directory...")
            Dim myFolderBrowser As New FolderBrowserDialog
            ' Description that displays above the dialog box control. 
            If Not String.IsNullOrEmpty(Program.Pso2RootDir) Then myFolderBrowser.SelectedPath = Program.Pso2RootDir
            myFolderBrowser.Description = "Select your pso2_bin folder"
            ' Sets the root folder where the browsing starts from 
            myFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
            Dim dlgResult As DialogResult = myFolderBrowser.ShowDialog()
            If dlgResult = DialogResult.Cancel Then
                frmMainv2.WriteDebugInfo("pso2_bin folder selection cancelled!")
                Return
            End If

            If myFolderBrowser.SelectedPath.EndsWith("\pso2_bin\data\win32") Then
                If File.Exists(myFolderBrowser.SelectedPath.Replace("\data\win32", "") & "\pso2.exe") Then
                    frmMainv2.WriteDebugInfo("win32 folder selected instead of pso2_bin folder - Fixing!")
                    myFolderBrowser.SelectedPath = myFolderBrowser.SelectedPath.Replace("\data\win32", "")
                End If
            End If

            'If Directory.Exists(myFolderBrowser.SelectedPath & "\pso2_bin\") And File.Exists(myFolderBrowser.SelectedPath & "\pso2_bin\pso2.exe") Then
            'frmMainv2.WriteDebugInfo("Asking if they selected the wrong folder (PHANTASYSTARONLINE2 instead of pso2_bin)")
            'Dim MsgBoxResultSrsly = MsgBox("It looks like you've selected an incorrect folder - Make sure you select the pso2_bin folder, not the PHANTASYSTARONLINE 2 folder." & vbCrLf & "If you're absolutely positively sure you selected the right folder, hit yes. Hit no to return to the folder selection and select your pso2_bin folder.", vbYesNo, "Did you select the right folder?")
            'If MsgBoxResultSrsly = vbNo Then SelectPso2Directory()
            'End If

            If myFolderBrowser.SelectedPath.EndsWith("\pso2_bin") Then
                Program.SaveSetting("PSO2Dir", myFolderBrowser.SelectedPath)
                Program.Pso2RootDir = myFolderBrowser.SelectedPath
                'If Program.MainForm IsNot Nothing Then Program.MainForm.lblDirectory.Text = myFolderBrowser.SelectedPath
                frmMainv2.WriteDebugInfoAndOk(Program.PSO2RootDir & " set as your PSO2 Directory.")
                Helper.DeleteFile("client.json")
            Else
                frmMainv2.WriteDebugInfo("User didn't select a pso2_bin folder...")
                MsgBox("It looks like you've selected an incorrect folder - Make sure you select the pso2_bin folder, not the PHANTASYSTARONLINE 2 folder.", MsgBoxStyle.OkOnly, "Did you select the right folder?")
                SelectPso2Directory()
            End If
        Catch ex As Exception
            LogWithException("ERROR - ", ex)
        End Try
    End Sub

    Public Shared Sub LogWithException(message As String, e As Exception)
        Log(e.Message.ToString & " Stack Trace: " & e.StackTrace)
        frmMainv2.WriteDebugInfo(Helper.ExceptionDump(message, e))
    End Sub

    Public Shared Function ExceptionDump(message As String, e As Exception) As String
        Dim text As String = String.Empty

        text += String.Format("{0} - {1}: {2}", message, e.[GetType](), e)
        If e.InnerException IsNot Nothing Then
            text += String.Format(vbLf & "[Error] Inner Exception: {0}", e.InnerException)
        End If

        Return text
    End Function
End Class