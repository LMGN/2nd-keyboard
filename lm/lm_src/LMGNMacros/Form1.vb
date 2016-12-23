Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NotifyIcon1.Icon = My.Resources.Windows_9_Icos__452_
        TextBox1.Text = My.Settings.path
        TextBox2.Text = My.Settings.filename
        FileSystemWatcher1.Path = My.Settings.path
        FileSystemWatcher1.Filter = My.Settings.filename
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.path = TextBox1.Text
        My.Settings.filename = TextBox2.Text
        FileSystemWatcher1.Path = TextBox1.Text
        FileSystemWatcher1.Filter = TextBox2.Text
    End Sub
    Function confirm(text)
        Confirmation.Label2.Text = text
        Return Confirmation.ShowDialog()
    End Function
    Function launch(path As String)
        Try
            If confirm("Launch " & My.Computer.FileSystem.GetFileInfo(path).Name & "?") = DialogResult.Yes Then
                Return Process.Start(path)
            End If
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(5000, "Error launching " & path, ex.ToString, ToolTipIcon.Error)
        End Try
    End Function
    Dim run = True
    Dim tempFolder = ""
    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        GC.Collect()

        If run Then
            Try
                Dim mkc = My.Computer.FileSystem.ReadAllText(FileSystemWatcher1.Path & "\" & FileSystemWatcher1.Filter)
                NotifyIcon1.ShowBalloonTip(5000, "Macro Pressed", "Key pressed: " & mkc, ToolTipIcon.Info)
                If mkc = "97" Then
                    SendKeys.Send("{(} ͡° ͜ʖ ͡°{)}")
                ElseIf mkc = "98" Then
                    launch("C:\Users\Leo MG Nesfield\AppData\Local\Vivaldi\Application\vivaldi.exe")
                ElseIf mkc = "27" Then
                    If confirm("Exit the program?") = DialogResult.Yes Then
                        Application.Exit()
                    End If
                ElseIf mkc = "100" Then
                    Dim proc = Process.GetProcessesByName("hl2")
                    For i As Integer = 0 To proc.Count - 1
                        proc(i).Kill()
                    Next i
                    If confirm("Launch TF2?") = DialogResult.Yes Then
                        WebBrowser1.Navigate("steam://run/440")
                    End If
                ElseIf mkc = "102" Then
                    If confirm("Open BigPicture?") = DialogResult.Yes Then
                        WebBrowser1.Navigate("steam://open/bigpicture")
                    End If
                ElseIf mkc = "17" Then
                    Dim webClient As New System.Net.WebClient
                    Dim result As String = webClient.DownloadString("https://autoremotejoaomgcd.appspot.com/sendmessage?key=&message=pM")
                    If Not result = "OK" Then
                        NotifyIcon1.ShowBalloonTip(5000, "Server returned error", result, ToolTipIcon.Error)
                    Else
                        NotifyIcon1.ShowBalloonTip(5000, "Music Playing!", "Music has been started on your phone", ToolTipIcon.Info)
                    End If
                ElseIf mkc = "32" Then
                    If tempFolder = "" Then
                        tempFolder = My.Computer.FileSystem.GetTempFileName()
                        My.Computer.FileSystem.DeleteFile(tempFolder)
                        My.Computer.FileSystem.CreateDirectory(tempFolder)
                        Process.Start(tempFolder)
                        NotifyIcon1.ShowBalloonTip(5000, "Temp Folder Created", "The folder " & tempFolder & " has been created, press Space again to delete it.", ToolTipIcon.Info)

                    Else
                        My.Computer.FileSystem.DeleteDirectory(tempFolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
                        NotifyIcon1.ShowBalloonTip(5000, "Temp Folder Deleted", "The folder " & tempFolder & " has been deleted.", ToolTipIcon.Info)
                        tempFolder = ""
                    End If
                ElseIf mkc = "112" Then
                    If confirm("Shutdown the PC?") = DialogResult.Yes Then
                        Process.Start("shutdown", "-s -t 30 /c ""Shutting down in 30 seconds. Press F3 to cancel.""")
                    End If
                ElseIf mkc = "113" Then
                    If confirm("Reboot the PC?") = DialogResult.Yes Then
                        Process.Start("shutdown", "-r -t 30 /c ""Rebooting in 30 seconds. Press F3 to cancel.""")
                    End If
                ElseIf mkc = "114" Then
                    Process.Start("shutdown", "-s -t 30 /c ""Shutting down in 30 seconds. Press F3 to cancel.""")
                Else
                    SendKeys.Send(Chr(Convert.ToInt32(mkc)))
                End If

            Catch ex As Exception
                NotifyIcon1.ShowBalloonTip(5000, "Error handling macro", ex.ToString, ToolTipIcon.Error)
            End Try
            run = False
        Else
            run = True
        End If
        GC.Collect()
        'Me.
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(sender As Object, e As EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Try
            Process.Start("lm_src/LMGNMacros.sln")
            NotifyIcon1.ShowBalloonTip(5000, "Opened source", "Opened lm_src/LMGNMacros.sln", ToolTipIcon.Info)
        Catch ex As Exception
            NotifyIcon1.ShowBalloonTip(5000, "Error loading source", ex.ToString, ToolTipIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class
