' © 2025 Joel Davis. All rights reserved.
' No part of this code may be used, copied, distributed,
' or modified in any form without prior written permission.

Imports System.IO
Imports System.Threading
Imports Microsoft.VisualBasic.Devices
Public Class Form2
    Public ProgName As String = "MCS Alumni Status" : Dim ShortName As String = "MCSAS" : Dim Selfolder As String = "C:"
    Dim txt, txt1, loc, sysd As String : Dim os As OperatingSystem
    Public Sub Unzip(ByVal Filename As String, ByVal Folder As String)
        Try
            My.Computer.Network.DownloadFile("ftp://Davisbros:geekmen@Davis.techdweebs.com/MCSAS/Update.zip", "C:\" & ShortName & " Update.zip")

        Catch
            Try
                My.Computer.Network.DownloadFile("ftp://Davisbros:geekmen@Davistech.servequake.com/MCSAS/Update.zip", "C:\" & ShortName & " Update.zip")
            Catch
                Timer.Stop()
                Try
                    File.Delete("C:\" & ShortName & " Update.zip")
                Catch
                End Try
                MsgBox("It appears that you have no Internet Connection or our Server is down temporarily!" & vbNewLine & vbNewLine _
      & "Please Connect to the Internet to use [" & ProgName & " Updater] by the Davis Brothers," & vbNewLine & "                   or we will try to fix the issue on our end as soon as possible." & vbNewLine & vbNewLine _
         & "                                Thank you for being patient!" & vbNewLine _
         & "                                                        - The Davisbros Tech. Team", MsgBoxStyle.Information, ProgName & " Updater: Unable to Connect to the Network!")
                IO.File.Copy(Application.StartupPath & "\" & ProgName & " Update.exe", My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ShortName & " Update.exe")
                MsgBox("A file has been generated to your Desktop titled [" & ShortName & " Update]," & vbNewLine _
                         & "so you can Update later.")
                End
            End Try
        End Try
        Dim unz As New ICSharpCode.SharpZipLib.Zip.FastZip
        unz.ExtractZip(Filename, My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName, "")
    End Sub
    Public Sub CreateShortcut(ByVal MainExe As String)
        Dim txt As String
        txt = "[InternetShortcut]" & vbNewLine & "URL=" & My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ProgName & ".exe" & vbNewLine &
        "IconIndex=0" & vbNewLine & "IconFile=" & My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\MCS Logo.ico"
        Dim ExeName As String = Path.GetFileNameWithoutExtension(MainExe)
        Dim objWriter As New StreamWriter(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ExeName & ".url")
        objWriter.Write(txt)
        objWriter.Close()
    End Sub
    Public Sub CreateUninstaller()
        Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName)
        os = Environment.OSVersion
        If os.Version.Major > 5 Then
            loc = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\StartMenu\Programs\" & ProgName
        Else
            loc = "C:\Documents and Settings\" & Environment.UserName & "\Start Menu\Programs\" & ProgName
        End If
        txt = My.Settings.Bat
        txt = Replace(txt, "PROGNAME", ProgName)
        txt = Replace(txt, "FOLDERLOC1", My.Computer.FileSystem.SpecialDirectories.ProgramFiles)
        txt = Replace(txt, "NAME", ShortName & "_UnInstall.vbs")
        txt1 = My.Settings.Vbs
        txt1 = Replace(txt1, "PROGNAME", ProgName)
        txt1 = Replace(txt1, "FOLDERLOC1", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies")
        txt1 = Replace(txt1, "FOLDERLOC2", loc)
        If Form1.CheckBox2.Checked Then
            txt1 = Replace(txt1, "FOLDERLOC3", My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ProgName & ".url")
        Else
            txt1 = Replace(txt1, "FOLDERLOC3", "")
            txt1 = Replace(txt1, "set demofile = filesys3.GetFile" & "("""")", "")
            txt1 = Replace(txt1, "demofile.Delete", "")
        End If
        If IO.File.Exists(Application.StartupPath & "\" & ProgName & ".manifest") Then
            txt1 = Replace(txt1, "FOLDERLOC5", Application.StartupPath)
        Else
            txt1 = Replace(txt1, "FOLDERLOC5", "")
            txt1 = Replace(txt1, "set demofolder3 = filesys2.GetFolder" & "("""")", "")
            txt1 = Replace(txt1, "demofolder3.Delete", "")
        End If
        txt1 = Replace(txt1, "FOLDERLOC4", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\" & ShortName & "_UnInstall.vbs")
        Dim objWriter As New StreamWriter(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\UnInstall.bat")
        Dim objWriter1 As New StreamWriter(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\" & ShortName & "_UnInstall.vbs")
        objWriter.Write(txt)
        objWriter1.Write(txt1)
        objWriter.Close()
        objWriter1.Close()
    End Sub
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        If Label5.Text = "0%" Then
            Label5.Text = "Loading...."
        End If
        If TimeString.ToString.Contains("20") Then
            Label4.Text = "We hope you enjoy this special version of " & ProgName & "!"
        End If
        If TimeString.Contains("30") Then
            ProgressBar.Style = ProgressBarStyle.Blocks
        End If
        If ProgressBar.Style = ProgressBarStyle.Blocks Then
            ProgressBar.Increment(1)
            Label5.Text = ProgressBar.Value & "%"
        End If
        os = Environment.OSVersion
        If os.Version.Major > 5 Then
            loc = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\"
        Else
            loc = "C:\Documents and Settings\" & Environment.UserName & "\Start Menu\Programs\"
        End If
        If ProgressBar.Value = 10 Then
            Label3.Visible = True
            If ProgName = "MCS Alumni Status" Then
                Label3.Text = "We hope you enjoy your experience with your fellow alumni members!"
            Else
                Label3.Text = "We hope you enjoy your experience with " & ProgName & "!"
            End If
            GroupBox1.Text = vbNewLine & "Checking for Previous Versions..."
            Label4.Text = vbNewLine & "Checking for Previous Versions..."
            If My.Computer.FileSystem.FileExists(loc & "Davisbros Technologies\" & ShortName & " UnInstall.lnk") Then
                Timer.Stop()
                Form3.Show()
            End If
        End If
        If ProgressBar.Value = 15 Then
            Dim RM As Resources.ResourceManager
            Dim B() As Byte
            RM = New Resources.ResourceManager("MCS_Alumni_Setup.Resources", System.Reflection.Assembly.GetExecutingAssembly)
            B = RM.GetObject("ICSharpCode_SharpZipLib")
            If IO.File.Exists(Application.StartupPath & "\ICSharpCode.SharpZipLib.dll") Then
                IO.File.Delete(Application.StartupPath & "\ICSharpCode.SharpZipLib.dll")
                System.IO.File.WriteAllBytes(Application.StartupPath & "\ICSharpCode.SharpZipLib.dll", B)
            Else
                System.IO.File.WriteAllBytes(Application.StartupPath & "\ICSharpCode.SharpZipLib.dll", B)
            End If
            GroupBox1.Text = vbNewLine & "Extracing: " & ProgName & " Update.zip"
            Label4.Text = vbNewLine & "Extracing: " & ProgName & " Update.zip"
            Unzip(Selfolder & "\" & ShortName & " Update.zip", Selfolder)
            My.Computer.FileSystem.DeleteFile(Selfolder & "\" & ShortName & " Update.zip")
        End If
        If ProgressBar.Value = 25 Then
            GroupBox1.Text = vbNewLine & "Creating UnInstaller..."
            Label4.Text = vbNewLine & "Creating UnInstaller..."
            CreateUninstaller()
        End If
        If ProgressBar.Value = 47 Then
            Label5.BackColor = Color.LawnGreen
        End If
        If ProgressBar.Value = 55 Then
            GroupBox1.Text = "Installing: " & loc & ProgName
            Label4.Text = "Installing: " & loc & ProgName
            CreateShortcut(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ProgName & ".exe")
            Directory.CreateDirectory(loc & ProgName)
            My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ProgName & ".url", loc & ProgName & "\" & ProgName & ".url")
            File.Copy(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & "UnInstall.bat", loc & ProgName & "\UnInstall.bat")
            Try
                IO.File.Move(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\credentials.MCSAS", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\credentials.MCSAS")
                IO.File.Move(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Directory.MCSAS", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\Directory.MCSAS")
            Catch
            End Try
        End If
        If ProgressBar.Value = 70 Then
            GroupBox1.Text = vbNewLine & "Almost done with installation!"
            Label4.Text = vbNewLine & "Almost done with installation!"
        ElseIf Form1.CheckBox2.Checked Then
            If ProgressBar.Value = 65 Then
                GroupBox1.Text = vbNewLine & "Creating Desktop Shortcut"
                Label4.Text = vbNewLine & "Creating Desktop Shortcut"
                Try
                    File.Copy(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ProgName & ".url", My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ProgName & ".url")
                Catch
                End Try
            End If
        Else
            Try
                File.Delete(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ProgName & ".url")
            Catch
            End Try
        End If
        If ProgressBar.Value = 75 Then
            GroupBox1.Text = vbNewLine & "Done with Installation of " & ProgName & "!"
            Label4.Text = vbNewLine & "Done with Installation of " & ProgName & "!"
        End If
        If ProgressBar.Value = 90 Then
            GroupBox1.Text = vbNewLine & "Starting Davisbros Software!"
            Label4.Text = vbNewLine & "Starting Davisbros Software!"
        End If
        If ProgressBar.Value = 100 Then
            Timer.Stop()
            Process.Start(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ProgName & ".exe")
            If IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ProgName & " Update Install") Then
                Try
                    My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ProgName & " Update Install", FileIO.DeleteDirectoryOption.DeleteAllContents)
                Catch
                End Try
            Else
                Try
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ShortName & " Update.exe")
                    My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.Desktop & "\ICSharpCode.SharpZipLib.dll")
                Catch
                End Try
            End If
            End
        End If
    End Sub

End Class
