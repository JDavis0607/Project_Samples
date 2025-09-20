' © 2025 Joel Davis. All rights reserved.
' No part of this code may be used, copied, distributed,
' or modified in any form without prior written permission.

Public Class Form1
    Public ProgName As String = "MCS Alumni Status" : Dim ShortName As String = "MCSAS"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Install.Enabled = False
        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\MCS Alumni Status\UnInstall.exe") Then
            Try
                IO.File.Move(Application.StartupPath & "\credentials.MCSAS", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\credentials.MCSAS")
                IO.File.Move(Application.StartupPath & "\Directory.MCSAS", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Directory.MCSAS")
            Catch
            End Try
        End If
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\MCS Alumni Status\Application Files", FileIO.DeleteDirectoryOption.DeleteAllContents)
            IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\MCS Alumni Status\MCS Alumni Status.application")
        Catch
        End Try
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            Install.Enabled = True
        ElseIf CheckBox1.Checked = CheckState.Unchecked Then
            Install.Enabled = False
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://Davis.techdweebs.com/Logs/EULA.htm")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Install.Click
        Dim OpenWindows() As Process = System.Diagnostics.Process.GetProcessesByName("explorer")
        For Each proc In OpenWindows
            proc.Kill()
        Next
        Dim loc As String : Dim os As OperatingSystem
        os = Environment.OSVersion
        If os.Version.Major > 5 Then
            loc = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\" & ProgName
        Else
            loc = "C:\Documents and Settings\" & Environment.UserName & "\Start Menu\Programs\" & ProgName
        End If
        If IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\UnInstall.bat") Then
            Try
                IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ProgName & ".url")
                My.Computer.FileSystem.DeleteDirectory(loc, FileIO.DeleteDirectoryOption.DeleteAllContents)
                IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\" & ProgName & ".exe")
                IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Davisbros Technologies\" & ProgName & "\MCS Logo.ico")
                IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\" & ShortName & "Uns.vbs")
            Catch
            End Try
        End If
        Me.Hide()
        Form2.Show()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        MsgBox("If you do not update now, then the next time you use" & vbNewLine _
                 & "[" & ProgName & "] you will not be able to use previous versions." & vbNewLine & vbNewLine _
                 & "This ensures that you have the best quality security, functionality, and performance.", MsgBoxStyle.Exclamation, ProgName & " Update: Warning - you may want to update now!")
        If MsgBox("Are you sure you want to Cancel a " & ProgName & " Update?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            IO.File.Copy(Application.StartupPath & "\" & ProgName & " Update.exe", My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & ShortName & " Update.exe")
            MsgBox("A file has been generated to your Desktop titled [" & ShortName & " Update]," & vbNewLine _
                     & "so you can Update later.")
            End
        End If
    End Sub
End Class

