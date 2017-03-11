Imports System.Globalization
Imports System.IO
Imports System.Security.Principal
Imports System.Threading
Imports System.Net
Imports PSO2TweakerVer2.VEDA
Imports Microsoft.Win32
Imports System.Text
Imports Newtonsoft.Json.Linq

Namespace My
    Public Class Program
        Public Shared ReadOnly Args As String() = Environment.GetCommandLineArgs()
        Public Shared ReadOnly StartPath As String = Windows.Forms.Application.StartupPath
        Public Shared ReadOnly Client As MyWebClient = New MyWebClient() With {.Timeout = 10000, .Proxy = Nothing}
        Public Shared ReadOnly AreYouAlive As MyWebClient = New MyWebClient() With {.Timeout = 5000, .Proxy = Nothing}
        Public Shared ReadOnly ItemPatchClient As MyWebClient = New MyWebClient() With {.Timeout = 10000, .Proxy = Nothing}
        Public Shared ReadOnly Client2 As MyWebClient = New MyWebClient() With {.Timeout = 10000, .Proxy = Nothing}
        Public Shared AppData As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Public Shared MainForm As frmMainv2
        Public Shared FreedomUrl As String = "http://arks-layer.com/justice/"
        Public Shared HostsFilePath As String
        Public Shared PSO2RootDir As String
        Public Shared PSO2WinDir As String
        Public Shared NoGNFieldMode As Boolean = False
        Public Shared CloseMe As Boolean = False
        Public Shared GNFieldActive As Boolean = False
        Public Shared ELSActive As Boolean = False
        Public Shared Nodiag As Boolean = False
        Public Shared IsPso2Installed As Boolean = True
        Public Shared transOverride As Boolean = False
        Public Shared GNFieldMD5 As String = ""
        Public Shared GNFieldStatus As String = ""
        Public Shared InfoURL As String = ""
        Public Shared ItemPatchWorking As String = ""
        Public Shared LastPrecedeDate As String = ""
        Public Shared NewPrecedeAvailable As String = ""
        Public Shared ApplyPrecede As String = ""
        Public Shared PluginURL As String = ""
        Public Shared ENPatchOverride As String = ""
        Public Shared ENPatchOverrideURL As String = ""
        Public Shared LargeFilesTransAmDate As String = ""
        Public Shared StoryDate As String = ""
        Public Shared StoryChangelogURL As String = ""
        Public Shared Settings As String = ""
        Public Shared Sub Main()

            Try
                Client.Headers("user-agent") = GetUserAgent()

                Dim locale = "en"

                If Not String.IsNullOrEmpty(locale) Then
                    Thread.CurrentThread.CurrentUICulture = New CultureInfo(locale)
                    Thread.CurrentThread.CurrentCulture = New CultureInfo(locale)
                End If

                If File.Exists(StartPath & "\logfile.txt") AndAlso Helper.GetFileSize(StartPath & "\logfile.txt") > 500000 Then
                    File.WriteAllText(StartPath & "\logfile.txt", "")
                End If

                Helper.Log(vbCrLf)
                Helper.Log("Program started! Hooray! \o/")
                Helper.Log("Reading settings...")
                ReadSettingsInitial()
                Helper.Log("Checking if the PSO2 Tweaker is running")

                If Helper.CheckIfRunning("PSO2 Tweaker") Then Environment.Exit(0)

                If String.IsNullOrEmpty(Program.GetSetting("PSO2Dir")) Or Program.GetSetting("PSO2Dir").Contains("ERROR GETTING VALUE") Then
                    Dim TutorialYesNo As MsgBoxResult = MsgBox("This appears to be the first time you've used the PSO2 Tweaker! Would you like to open a guide to help you through setting it up?", vbYesNo)
                    If TutorialYesNo = vbYes Then Process.Start("http://arks-layer.com/tweaker_tutorial.php")

                    Dim alreadyInstalled As MsgBoxResult = MsgBox("Have you installed PSO2 already? If you select no, the PSO2 Tweaker will install it for you.", MsgBoxStyle.YesNo)
                    If alreadyInstalled = vbNo Then
                        IsPso2Installed = False
                        Return
                    End If
                End If

                If String.IsNullOrEmpty(Program.GetSetting("PSO2Dir")) Or Program.GetSetting("PSO2Dir").Contains("ERROR GETTING VALUE") Then
                    MsgBox("Please select your PSO2's pso2_bin Directory. It will be saved so you don't have to select it again.")
                    Helper.SelectPso2Directory()
                Else
                    PSO2RootDir = Program.GetSetting("PSO2Dir")
                    Helper.Log("Loaded pso2_bin directory from settings")
                End If

                ' This sets up pso2RootDir and pso2WinDir - don't remove it
                If PSO2RootDir.Contains("\pso2_bin\data\win32") Then
                    If File.Exists(PSO2RootDir.Replace("\data\win32", "") & "\pso2.exe") Then
                        Helper.Log("win32 folder selected instead of pso2_bin folder - Fixing!")
                        PSO2RootDir = PSO2RootDir.Replace("\data\win32", "")
                        Program.SaveSetting("PSO2Dir", PSO2RootDir)
                        Helper.Log(PSO2RootDir & " set as your PSO2 Directory.")
                    End If
                End If

                If PSO2RootDir = "lblDirectory" OrElse Not Directory.Exists(PSO2RootDir) Then
                    MsgBox("Please select your PSO's pso2_bin Directory. It will be saved so you don't have to select it again.")
                    Helper.SelectPso2Directory()
                End If

                PSO2WinDir = (PSO2RootDir & "\data\win32")

                If Not Directory.Exists(PSO2WinDir) Then
                    Directory.CreateDirectory(PSO2WinDir)
                    'WriteDebugInfo("Creating win32 directory... Done!")
                End If

                Helper.Log("Reading remote config...")
                Dim JSONClient As New WebClient
                JSONClient.Headers("user-agent") = GetUserAgent()
                Dim remotejson As JObject = JObject.Parse(JSONClient.DownloadString("http://arks-layer.com/remote.json"))
                GNFieldMD5 = remotejson.SelectToken("GNFieldMD5").ToString()
                GNFieldStatus = remotejson.SelectToken("GNFieldStatus").ToString()
                InfoURL = remotejson.SelectToken("InfoURL").ToString()
                FreedomUrl = remotejson.SelectToken("FreedomURL").ToString()
                ItemPatchWorking = remotejson.SelectToken("ItemPatchWorking").ToString()
                LastPrecedeDate = remotejson.SelectToken("LastPrecedeDate").ToString()
                NewPrecedeAvailable = remotejson.SelectToken("NewPrecedeAvailable").ToString()
                ApplyPrecede = remotejson.SelectToken("ApplyPrecede").ToString()
                PluginURL = remotejson.SelectToken("PluginURL").ToString()

                Helper.Log("Checking for patch info...")
                Dim patchesjson As JObject = JObject.Parse(JSONClient.DownloadString(FreedomUrl & "patches.json"))
                ENPatchOverride = patchesjson.SelectToken("ENPatchOverride").ToString()
                ENPatchOverrideURL = patchesjson.SelectToken("ENPatchOverrideURL").ToString()
                LargeFilesTransAmDate = patchesjson.SelectToken("LargeFilesTransAmDate").ToString()
                StoryDate = patchesjson.SelectToken("StoryDate").ToString()
                StoryChangelogURL = patchesjson.SelectToken("StoryChangelogURL").ToString()

                Dim launchPso2 As Boolean = False

                For i As Integer = 1 To (Args.Length - 1)
                    Try
                        Select Case Args(i)
                            Case "-nodllcheck"
                                transOverride = True

                            Case "-nodiag"
                                Helper.Log("Detected command argument -nodiag")
                                Helper.Log("Bypassing OS detection to fix compatibility!")
                                Nodiag = True

                            Case "-disablegn"
                                Helper.Log("Detected command argument -disablegn")
                                Helper.Log("GN Field disabled manually!")
                                Program.NoGNFieldMode = True

                            Case "-reset"
                                Helper.Log("Detected command argument -reset")
                                Dim resetyesno As MsgBoxResult = MsgBox("This will erase all of the PSO2 Tweaker's settings, and will start the initial setup the next time you open it. Continue?", vbYesNo)
                                If resetyesno = vbYes Then
                                    File.WriteAllText(AppData & "/PSO2 Tweaker/settings.json", frmMainv2.lblDefaults.Text)
                                    Helper.Log("All settings reset, closing program!")
                                    Program.CloseMe = True
                                End If

                            Case "-bypass"
                                Helper.Log("Detected command argument -bypass")
                                Helper.Log("Emergency bypass mode activated - Please only use this mode if the Tweaker will not start normally!")
                                MsgBox("Emergency bypass mode activated - Please only use this mode if the Tweaker will not start normally!")
                                If PSO2RootDir = "lblDirectory" OrElse Not Directory.Exists(PSO2RootDir) Then
                                    MsgBox("Please select your PSO2's pso2_bin Directory. It will be saved so you don't have to select it again.")
                                    Helper.SelectPso2Directory()
                                    Continue For
                                End If
                                File.WriteAllBytes(PSO2RootDir & "\ddraw.dll", Resources.ddraw)
                                Helper.Log("Setting environment variable")
                                Environment.SetEnvironmentVariable("-pso2", "+0x01e3f1e9")
                                Helper.Log("Launching PSO2")
                                External.ShellExecute(IntPtr.Zero, "open", (PSO2RootDir & "\pso2.exe"), "+0x33aca2b9 -pso2", "", 0)
                                Do While File.Exists(PSO2RootDir & "\ddraw.dll")
                                    For Each proc As Process In Process.GetProcessesByName("pso2")
                                        If proc.MainWindowTitle = "Phantasy Star Online 2" AndAlso proc.MainModule.ToString() = "ProcessModule (pso2.exe)" Then
                                            If Not transOverride Then Helper.DeleteFile(PSO2RootDir & "\ddraw.dll")
                                        End If
                                    Next
                                    Thread.Sleep(1000)
                                Loop

                            Case "-pso2"
                                launchPso2 = True
                                Helper.Log("Detected command argument -pso2")

                                'Fuck SEGA. Fuck them hard.
                                If Not Directory.Exists(PSO2RootDir) OrElse PSO2RootDir = "lblDirectory" Then
                                    MsgBox("Please select your PSO2's pso2_bin Directory. It will be saved so you don't have to select it again.")
                                    Helper.SelectPso2Directory()
                                    Return
                                End If

                                If File.Exists(GetSetting("PSO2Dir") & "/plugins/translator.dll") Then
                                    'Download the latest translator.dll and translation.bin
                                    Dim dlLink2 As String = FreedomUrl & "translation.bin"
                                    Helper.Log("Downloading latest item translation files...")

                                    ' TODO: WTF is gonig on with this for loop
                                    ' Try up to 4 times to download the translation strings.
                                    For tries As Integer = 1 To 4
                                        Try
                                            Dim DLS As New MyWebClient
                                            DLS.Headers("user-agent") = GetUserAgent()
                                            DLS.DownloadFile(Program.FreedomUrl & "translation.bin", (Program.PSO2RootDir & "\translation.bin"))
                                            Exit For
                                        Catch ex As Exception
                                            If tries = 4 Then
                                                Helper.Log("Failed to download translation files! (" & ex.Message.ToString & "). Try rebooting your computer or making sure PSO2 isn't open.")
                                                frmMainv2.WriteDebugInfo(Helper.ExceptionDump("ERROR - ", ex))
                                                Exit Try
                                            End If
                                        End Try
                                    Next

                                    File.WriteAllBytes(PSO2RootDir & "\ddraw.dll", Resources.ddraw)
                                End If

                                Helper.Log("Setting environment variable")
                                Environment.SetEnvironmentVariable("-pso2", "+0x01e3f1e9")

                                Helper.Log("Launching PSO2")
                                External.ShellExecute(IntPtr.Zero, "open", (PSO2RootDir & "\pso2.exe"), "+0x33aca2b9 -pso2", "", 0)

                                Helper.DeleteFile("LanguagePack.rar")
                                If File.Exists(GetSetting("PSO2Dir") & "/plugins/translator.dll") Then
                                    Do While File.Exists(PSO2RootDir & "\ddraw.dll")
                                        For Each proc As Process In Process.GetProcessesByName("pso2")
                                            If proc.MainWindowTitle = "Phantasy Star Online 2" AndAlso proc.MainModule.ToString() = "ProcessModule (pso2.exe)" Then
                                                If Not transOverride Then Helper.DeleteFile(PSO2RootDir & "\ddraw.dll")
                                            End If
                                        Next
                                        Thread.Sleep(1000)
                                    Loop
                                End If
                        End Select

                        If Not transOverride Then Helper.DeleteFile(PSO2RootDir & "\ddraw.dll")
                        If launchPso2 Then Environment.Exit(0)

                    Catch ex As Exception
                        Helper.LogWithException("ERROR - ", ex)
                    End Try
                Next

                If Not transOverride Then Helper.DeleteFile(PSO2RootDir & "\ddraw.dll")
            Catch ex As Exception
                Helper.LogWithException("ERROR - ", ex)
            End Try

            Try
                Helper.Log("Loading settings...")

                If String.IsNullOrEmpty(Program.GetSetting("Backup")) Then Program.SaveSetting("Backup", "Always")
                If String.IsNullOrEmpty(Program.GetSetting("PreDownloadedRar")) Then Program.SaveSetting("PreDownloadedRar", "Never")
                If String.IsNullOrEmpty(Program.GetSetting("Pastebin")) Then Program.SaveSetting("Pastebin", "True")
                If String.IsNullOrEmpty(Program.GetSetting("LatestStoryBase")) Then Program.SaveSetting("LatestStoryBase", "Unknown")
                If String.IsNullOrEmpty(Program.GetSetting("SteamModeEnabled")) Then Program.SaveSetting("SteamModeEnabled", "False")
                If String.IsNullOrEmpty(Program.GetSetting("UseIcsHost")) Then Program.SaveSetting("UseIcsHost", "False")
                If Convert.ToBoolean(Program.GetSetting("UseIcsHost")) Then
                    HostsFilePath = Environment.SystemDirectory & "\drivers\etc\HOSTS.ics"
                Else
                    HostsFilePath = Environment.SystemDirectory & "\drivers\etc\HOSTS"
                End If
                If String.IsNullOrEmpty(Program.GetSetting("ENPatchVersion")) Then Program.SaveSetting("ENPatchVersion", "Not Installed")
                If String.IsNullOrEmpty(Program.GetSetting("LargeFilesVersion")) Then Program.SaveSetting("LargeFilesVersion", "Not Installed")
                If String.IsNullOrEmpty(Program.GetSetting("StoryPatchVersion")) Then Program.SaveSetting("StoryPatchVersion", "Not Installed")

                Try
                    If File.Exists(StartPath & "\patchlog.txt") Then File.WriteAllText(StartPath & "\patchlog.txt", "")
                Catch ex As Exception
                    Exit Try
                End Try
                If Not File.Exists(Program.PSO2RootDir & "\translation.cfg") Then
                    File.WriteAllText(Program.PSO2RootDir & "\translation.cfg", "TranslationPath:translation.bin")
                End If

                Dim enabledplugins As String = ""
                        Dim disabledplugins As String = ""
                        Application.DoEvents()

                        If Nodiag Then
                            Helper.Log("Diagnostic info skipped due To -nodiag flag!")
                        Else
                            Helper.Log("----------------------------------------")
                            ThreadPool.QueueUserWorkItem(AddressOf GetCountry)
                            Helper.Log("Program opening, running diagnostics...")
                            Helper.Log("Current OS/Version: " & Computer.Info.OSFullName & " (" & Computer.Info.OSVersion & ") [" & Environment.Is64BitOperatingSystem.ToString.Replace("True", "64-bit").Replace("False", "32-bit") & "]")
                            Helper.Log("Directory program is running in: " & StartPath)
                            Helper.Log("Selected PSO2 Directory: " & PSO2RootDir)
                            'Dim identity = WindowsIdentity.GetCurrent()
                            'Dim principal = New WindowsPrincipal(identity)
                            'Dim isElevated As Boolean = principal.IsInRole(WindowsBuiltInRole.Administrator)
                            'Helper.Log("Run as Administrator: " & isElevated)
                            'Dim di = New DirectoryInfo(Pso2RootDir)

                            'If di.Exists() Then
                            '    If di.Attributes.HasFlag(FileAttributes.[ReadOnly]) Then
                            '        Helper.Log("pso2_bin set to read only: Yes")
                            '    Else
                            '        Helper.Log("pso2_bin set to read only: No")
                            '    End If
                            'End If
                            Helper.Log(GetDotNetVersion.Get45PlusFromRegistry)
                            Dim count As Integer = 0
                            If Directory.Exists(PSO2RootDir & "\plugins\") Then
                                For Each file In Directory.GetFiles(PSO2RootDir & "\plugins\")
                                    enabledplugins += file.Replace(PSO2RootDir & "\plugins\", "") + ", "
                                    count += 1
                                Next
                                If count > 0 Then
                                    Helper.Log("Enabled Plugins: " & enabledplugins.Remove(enabledplugins.Length - 2))
                                Else
                                    Helper.Log("Enabled Plugins: None")
                                End If
                            End If
                            count = 0
                            If Directory.Exists(PSO2RootDir & "\plugins\disabled\") Then
                                For Each file In Directory.GetFiles(PSO2RootDir & "\plugins\disabled\")
                                    disabledplugins += file.Replace(PSO2RootDir & "\plugins\disabled\", "") + ", "
                                    count += 1
                                Next
                                If count > 0 Then
                                    Helper.Log("Disabled Plugins: " & disabledplugins.Remove(disabledplugins.Length - 2))
                                Else
                                    Helper.Log("Disabled Plugins: None")
                                End If
                            End If
                            If Program.GetSetting("ProxyJSONURL") = "http://cloud02.cyberkitsune.net:8080/config.json" Then
                                frmMainv2.WriteDebugInfo("Changing PSO2Proxy Public URL -> Alam's URL to avoid GG issues with the hostname")
                                frmMainv2.WriteDebugInfo("New proxy URL is http://alam.srb2.org/PSO2/public_proxy/config-alt.json")
                                Program.SaveSetting("ProxyJSONURL", "http://alam.srb2.org/PSO2/public_proxy/config-alt.json")
                            End If
                            If Program.GetSetting("ProxyJSONURL") <> "" Then Helper.Log("ProxyJSONURL is: " & Program.GetSetting("ProxyJSONURL"))
                            'If File.Exists(Pso2RootDir & "\pso2.exe") Then Helper.Log("PSO2.exe MD5/filesize is: " & Helper.GetMd5(Pso2RootDir & "\pso2.exe").ToUpper & "/" & Helper.SizeSuffix(Helper.GetFileSize(Pso2RootDir & "\pso2.exe")))
                            'If File.Exists(Pso2RootDir & "\publickey.blob") Then Helper.Log("publickey.blob MD5/filesize is: " & Helper.GetMd5(Pso2RootDir & "\publickey.blob").ToUpper & "/" & Helper.SizeSuffix(Helper.GetFileSize(Pso2RootDir & "\publickey.blob")))
                            'If File.Exists(Pso2RootDir & "\proxy.txt") Then Helper.Log("proxy.txt contains: " & File.ReadAllText(Pso2RootDir & "\proxy.txt"))
                            'Try
                            '    Dim host As IPHostEntry = Dns.GetHostEntry("gs016.pso2gs.net")
                            '    Dim ip As IPAddress() = host.AddressList
                            '    Helper.Log("gs016.pso2gs.net (Ship 2) resolves to: " & ip(0).ToString)
                            'Catch ex As Exception
                            '    Helper.Log("Could not resolve gs016.pso2gs.net - " & ex.Message)
                            'End Try


                            Helper.Log("System has been on for: " & Mid((Environment.TickCount / 3600000).ToString(), 1, 5) & " hours")
                            'If Directory.Exists(Pso2WinDir) Then Helper.Log("Size of win32 folder: " & Helper.SizeSuffix(Helper.GetFolderSize(Pso2WinDir)))
                        End If
                        Helper.Log("----------------------------------------" & vbCrLf)

                    Catch ex As Exception
                        Helper.LogWithException("ERROR - ", ex)
                End Try
        End Sub

        Protected Shared Sub GetCountry(state As Object)
            Try
                Using wc As New WebClient()
                    wc.Encoding = Encoding.UTF8
                    Dim json As JObject = JObject.Parse(wc.DownloadString("http://ip-api.com/json/?fields=country"))
                    Helper.Log("User location according to IP: " & json.SelectToken("country").ToString)
                End Using
            Catch ex As Exception
                Helper.Log("Could not find location - " & ex.Message)
            End Try
        End Sub

        Public Shared Sub SaveSetting(ByVal Token As String, ByVal NewSetting As String)
            Try
                Dim rss As JObject = JObject.Parse(Settings)
                rss.SelectToken(Token).Replace(NewSetting)
                File.WriteAllText(AppData & "/PSO2 Tweaker/settings.json", rss.ToString)
                Settings = rss.ToString
            Catch ex As Exception
                Helper.LogWithException("ERROR - ", ex)
            End Try
        End Sub
        Public Shared Function GetSetting(ByVal Token As String) As String
            Try
                Dim rss As JObject = JObject.Parse(Settings)
                Return rss.SelectToken(Token).ToString
            Catch ex As Exception
                'Helper.LogWithException("ERROR - ", ex)
                Helper.Log("Couldn't find a " & Token & " setting. Using default.")
                Dim rss As JObject = JObject.Parse(Settings)
                File.WriteAllText("defaults.txt", frmMainv2.lblDefaults.Text)
                For Each line As String In File.ReadAllLines("defaults.txt")
                    Dim part() As String = line.Split(":")
                    If part(0).Contains(Token) Then
                        'Clipboard.SetText(part(0).Replace("  ", "").Replace("""", ""))
                        'MsgBox(part(0))
                        'Clipboard.SetText(part(1).Replace(" """, "").Replace("""", "").Replace(",", ""))
                        'MsgBox(part(1))
                        rss.Add(part(0).Replace("  ", "").Replace("""", ""), part(1).Replace(" """, "").Replace("""", "").Replace(",", ""))
                        File.WriteAllText(AppData & "/PSO2 Tweaker/settings.json", rss.ToString)
                        Settings = rss.ToString
                        Exit For
                    End If
                    'MsgBox("Default Settings: " & part(0))
                Next
                Helper.DeleteFile("defaults.txt")
                Return GetSetting(Token)
            End Try
        End Function
        Public Shared Sub ReadSettingsInitial()
            If Directory.Exists(AppData & "/PSO2 Tweaker/") = False Then Directory.CreateDirectory(AppData & "/PSO2 Tweaker/")
            If File.Exists(AppData & "/PSO2 Tweaker/settings.json") = False Then File.WriteAllText(AppData & "/PSO2 Tweaker/settings.json", frmMainv2.lblDefaults.Text)
            Settings = File.ReadAllText(AppData & "/PSO2 Tweaker/settings.json")
            'Dim lineCount = File.ReadAllLines(AppData & "/PSO2 Tweaker/settings.json").Length
            Dim JSONData As String = ""
            Try
                Using sr As New StreamReader(AppData & "/PSO2 Tweaker/settings.json")
                    JSONData = sr.ReadToEnd()
                End Using
            Catch ex As FileNotFoundException
                Helper.Log("Couldn't find settings, creating default ones!")
                frmMainv2.WriteDebugInfoAndWarning("Couldn't find settings, creating default ones!")
                File.WriteAllText(AppData & "/PSO2 Tweaker/settings.json", frmMainv2.lblDefaults.Text)
            End Try

            Try
                JObject.Parse(JSONData)
            Catch ex As Exception
                Helper.Log("There appears to be an issue with the settings file... reverting file to default!")
                frmMainv2.WriteDebugInfoAndWarning("There appears to be an issue with the settings file... reverting file to default!")
                File.WriteAllText(AppData & "/PSO2 Tweaker/settings.json", frmMainv2.lblDefaults.Text)
            End Try
            'If lineCount < 26 Then
            '    'Settings = File.ReadAllText(AppData & "/PSO2 Tweaker/settings.json")
            '    Dim UserSettings As New Dictionary(Of String, String)
            '    Dim DefaultSettings As New Dictionary(Of String, String)

            '    For Each line As String In File.ReadAllLines(AppData & "/PSO2 Tweaker/settings.json")
            '        Dim part() As String = line.Split(":")
            '        UserSettings.Add(part(0), line)
            '        'MsgBox("User Settings: " & part(0))
            '    Next

            '    File.WriteAllText("defaults.txt", frmMainv2.lblDefaults.Text)

            '    For Each line As String In File.ReadAllLines("defaults.txt")
            '        Dim part() As String = line.Split(":")
            '        DefaultSettings.Add(part(0), line)
            '        'MsgBox("Default Settings: " & part(0))
            '    Next

            '    Dim TotalAdd As String = ""

            '    For Each key As String In DefaultSettings.Keys
            '        If UserSettings.ContainsKey(key) Then
            '            'AddText(file2(key))
            '        Else
            '            'MsgBox(key)
            '            'Now that we know what line Is missing
            '            'We're going to grab -just- that line from the defaults and add it to the end
            '            'For Each setting As String In key
            '            For Each line As String In File.ReadAllLines("defaults.txt")
            '                If line.Contains(key) Then
            '                    TotalAdd += line & vbCrLf
            '                    'MsgBox(line)
            '                    Exit For
            '                End If
            '            Next
            '            'Next
            '            MsgBox(TotalAdd)
            '        End If
            '    Next

            '    'Gotta delete the last line in the current settings first then add the missing settings (removing the last character, the comma)
            '    'then put a } at the end and save

            '    Dim text() As String
            '    Dim lines As New List(Of String)

            '    text = File.ReadAllLines(AppData & "/PSO2 Tweaker/settings.json")
            '    lines.AddRange(text)
            '    lines.RemoveAt(0)
            '    lines.RemoveAt(lines.Count - 1)
            '    text = lines.ToArray()
            '    File.WriteAllLines("test.txt", text)
            '    MsgBox("test")
            '    'Man, this is probably the shittiest way to do this ever. [AIDA]
            '    Dim TextBeforeAdd As String = File.ReadAllText("test.txt")
            '    TextBeforeAdd += TotalAdd + "}"
            '    File.WriteAllText("test.txt", TextBeforeAdd)
            '    'Doing shitty code again! \ o / [AIDA]
            '    Dim Settings() As String = File.ReadAllLines("test.txt")
            '    Array.Sort(Settings)
            '    File.WriteAllLines("test.txt", Settings)
            '    File.WriteAllText("test.txt", "{" & vbCrLf & File.ReadAllText("test.txt"))
            '    MsgBox("Done!")
            'End If

            If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.ImportedToV4)) Then
                Helper.Log("Found legacy PSO2 Tweaker settings - Importing them now...")
                'Backup
                'EnPatchVersion
                'LargeFilesVersion
                'Pso2Dir
                'Pastebin
                'StoryPatchVersion
                'ProxyJSONURL
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.Backup)) = False Then Program.SaveSetting("Backup", RegKey.GetValue(Of String)(RegKey.Backup))
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.EnPatchVersion)) = False Then Program.SaveSetting("ENPatchVersion", RegKey.GetValue(Of String)(RegKey.EnPatchVersion))
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.LargeFilesVersion)) = False Then Program.SaveSetting("LargeFilesVersion", RegKey.GetValue(Of String)(RegKey.LargeFilesVersion))
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.Pso2Dir)) = False Then Program.SaveSetting("PSO2Dir", RegKey.GetValue(Of String)(RegKey.Pso2Dir))
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.Pastebin)) = False Then Program.SaveSetting("Pastebin", RegKey.GetValue(Of String)(RegKey.Pastebin))
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.StoryPatchVersion)) = False Then Program.SaveSetting("StoryPatchVersion", RegKey.GetValue(Of String)(RegKey.StoryPatchVersion))
                If String.IsNullOrEmpty(RegKey.GetValue(Of String)(RegKey.ProxyJSONURL)) = False Then Program.SaveSetting("ProxyJSONURL", RegKey.GetValue(Of String)(RegKey.ProxyJSONURL))
                RegKey.SetValue(Of String)(RegKey.ImportedToV4, "True")
                Helper.Log("Settings imported, continuing startup!")
            End If
        End Sub
    End Class
    Public Class RegKey
        Public Const Backup = "Backup"
        Public Const EnPatchVersion = "ENPatchVersion"
        Public Const LargeFilesVersion = "LargeFilesVersion"
        Public Const Pso2Dir = "PSO2Dir"
        Public Const Pastebin = "Pastebin"
        Public Const StoryPatchVersion = "StoryPatchVersion"
        Public Const ProxyJSONURL = "ProxyJSONURL"
        Public Const ImportedToV4 = "ImportedToV4"

        Private Shared ReadOnly RegistrySubKey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\AIDA", True)

        Public Shared Function GetValue(Of T)(key As String) As T
            Try
                Dim returnValue As Object = Nothing
                'If RegistryCache.TryGetValue(key, returnValue) Then Return DirectCast(Convert.ChangeType(returnValue, GetType(T)), T)

                returnValue = RegistrySubKey.GetValue(key, Nothing)
                'If returnValue IsNot Nothing Then RegistryCache.Add(key, returnValue)

                Return DirectCast(Convert.ChangeType(returnValue, GetType(T)), T)
            Catch
                Return Nothing
            End Try
        End Function

        Public Shared Sub SetValue(Of T)(key As String, value As T)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\AIDA", key, value)
            'RegistryCache(key) = value
        End Sub

        Public Shared Sub DeleteValue(key As String)
            'This is a dumb way to do this. [AIDA]
            Dim keytodelete = My.Computer.Registry.CurrentUser.OpenSubKey("Software\AIDA", True)
            keytodelete.DeleteValue(key)
            keytodelete.Close()
        End Sub
    End Class
    Public Class MyWebClient
        Inherits WebClient

        Private _timeout As Integer

        Public Property Timeout As Integer
            Get
                Timeout = _timeout
            End Get

            Set(ByVal value As Integer)
                _timeout = value
            End Set
        End Property

        Public Sub New()
            Timeout = 60000
        End Sub

        Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
            Dim result = MyBase.GetWebRequest(address)
            result.Timeout = _timeout
            Return result
        End Function

    End Class
    Public Class GetDotNetVersion
        Public Shared Function Get45PlusFromRegistry() As String
            Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
            Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey)
                If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                    Return ".NET Framework Version: " + CheckFor45PlusVersion(CInt(ndpKey.GetValue("Release")))
                Else
                    Return ".NET Framework Version: 4.5 or later is not detected."
                End If
            End Using
        End Function

        ' Checking the version using >= will enable forward compatibility.
        Private Shared Function CheckFor45PlusVersion(releaseKey As Integer) As String
            If releaseKey >= 394802 Then
                Return "4.6.2 or later"
            ElseIf releaseKey >= 394254 Then
                Return "4.6.1"
            ElseIf releaseKey >= 393295 Then
                Return "4.6"
            ElseIf releaseKey >= 379893 Then
                Return "4.5.2"
            ElseIf releaseKey >= 378675 Then
                Return "4.5.1"
            ElseIf releaseKey >= 378389 Then
                Return "4.5"
            End If
            ' This code should never execute. A non-null release key should mean
            ' that 4.5 or later is installed.
            Return "No 4.5 or later version detected"
        End Function
    End Class
    ' Calling the GetDotNetVersion.Get45PlusFromRegistry method produces 
    ' output like the following:
    '       .NET Framework Version: 4.6.1
End Namespace
