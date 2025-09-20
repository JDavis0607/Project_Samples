' © 2025 Joel Davis. All rights reserved.
' No part of this code may be used, copied, distributed,
' or modified in any form without prior written permission.

Public Class Form3
    Public ProgName As String = "MCS Alumni Status"
    Dim RM As Resources.ResourceManager
    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim loc As String : Dim os As OperatingSystem
        os = Environment.OSVersion
        If os.Version.Major > 5 Then
            loc = "C:\Users\" & Environment.UserName & "\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Davisbros Technologies\"
        Else
            loc = "C:\Documents and Settings\" & Environment.UserName & "\Start Menu\Programs\Davisbros Technologies\"
        End If
        If My.Computer.FileSystem.FileExists(loc & "MCSAS UnInstall.lnk") Then
            RM = New Resources.ResourceManager("MCS_Alumni_Setup.Resources", System.Reflection.Assembly.GetExecutingAssembly)
            PictureBox1.Image = RM.GetObject("MCSAS_UnInstall")
            RM.ReleaseAllResources()
            If MsgBox("Please UnInstall any Previous Versions of MCS Alumni Status!" & vbNewLine & vbNewLine _
                & "     When your finished close all windows to continue.") = MsgBoxResult.Ok Then
                Process.Start(loc & "MCSAS UnInstall.lnk")
            End If
        Else
            RM = New Resources.ResourceManager("MineCraft_Server_Status_Update.Resources", System.Reflection.Assembly.GetExecutingAssembly)
            PictureBox1.Image = RM.GetObject("MSS_UnInstall")
            RM.ReleaseAllResources()
            Label1.Visible = True
            Label2.Visible = True
            Label1.Text = "How to UnInstall New Versions of " & ProgName & ":"
            Label2.Text = "To UnInstall " & ProgName & vbNewLine _
                        & "1) Click the [Start Menu]" & vbNewLine _
                        & "2) Hover over or click [All Programs]" & vbNewLine _
                        & "3) Click the [" & ProgName & " folder]" & vbNewLine _
                        & "4) Click [UnInstall]."
            If MsgBox("Please UnInstall any Previous Versions of " & ProgName & "!" & vbNewLine & vbNewLine _
                & "     When your finished close all windows to continue.") = MsgBoxResult.Ok Then
            End If
        End If
    End Sub
    Private Sub Form3_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form2.Show()
        Form2.Timer.Start()
    End Sub

End Class
