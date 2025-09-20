' © 2025 Joel Davis. All rights reserved.
' No part of this code may be used, copied, distributed,
' or modified in any form without prior written permission.

Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Hide()
        Dim RM As Resources.ResourceManager
        Dim B() As Byte
        RM = New Resources.ResourceManager("Einstein_Test.Resources", System.Reflection.Assembly.GetExecutingAssembly)
        B = RM.GetObject("Einstein_Movie")
            System.IO.File.WriteAllBytes(Application.StartupPath & "/Einstein Movie.wmv", B)
            AxWindowsMediaPlayer1.URL = Application.StartupPath & "/Einstein Movie.wmv"
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not Label1.Text.Contains("Davisbros") Then
            Form2.Timer1.Start()
            Me.Hide()
            Form2.Show()
        End If
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        Me.Hide()
        Form2.Show()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "Instructions" Then
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
            AxWindowsMediaPlayer1.Hide()
            Button2.Text = "< Back"
            Label1.Show()
        Else
            Button2.Text = "Instructions"
            Label1.Hide()
            AxWindowsMediaPlayer1.Show()
        End If
    End Sub
End Class