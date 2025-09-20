' © 2025 Joel Davis. All rights reserved.
' No part of this code may be used, copied, distributed,
' or modified in any form without prior written permission.

Public Class Form2
    Private timeLeft As Integer
    Dim randomizer As New Random
    Dim RM As Resources.ResourceManager
    Dim addend1 As Integer
    Dim addend2 As Integer
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        IO.File.Delete(Application.StartupPath & "/Einstein Movie.wmv")
        IO.File.Delete(Application.StartupPath & "/Congradulations You Win.wmv")
        End
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.Hide()
        Button1.Enabled = False
        Button2.Enabled = False
        Dim Save As String
        Save = Application.StartupPath & "/Congradulations You Win.wmv"
        Dim B() As Byte
        RM = New Resources.ResourceManager("Einstein_Test.Resources", System.Reflection.Assembly.GetExecutingAssembly)
        B = RM.GetObject("Congradulations")
        System.IO.File.WriteAllBytes(Save, B)
    End Sub
    Public Sub Questions()
        If addend1.ToString = "1" Then
            Label1.Text = "What Nobel Prize did I win?"
        ElseIf addend1.ToString = "2" Then
            Label1.Text = "I was offered the Presidency" & vbNewLine _
                        & "of which country? "
        End If
        If addend2.ToString = "1" Then
            Label2.Text = "Did I attend the Nobel Prize" & vbNewLine _
                        & "Award Ceremony?"
        ElseIf addend2.ToString = "2" Then
            Label2.Text = "Did I retain my" & vbNewLine _
                        & "Swiss citizenship?"
        End If
        If addend1.ToString = "1" Then
            Label3.Text = "What did I think was useless" & vbNewLine _
                        & "in helping humanity forward?"
        ElseIf addend1.ToString = "2" Then
            Label3.Text = "What is the most famous theory" & vbNewLine _
                        & "I have made?"
        End If
        If addend2.ToString = "1" Then
            Label4.Text = "What is 3.14 called?"
        ElseIf addend2.ToString = "2" Then
            Label4.Text = "In E=mc^2, what is [c]?"
        End If
        If addend1.ToString = "1" Then
            Label5.Text = "I rejected which physics theory" & vbNewLine _
                        & "by saying [God doesn't play dice.]"
        ElseIf addend1.ToString = "2" Then
            Label5.Text = "What happened to my" & vbNewLine _
                        & "brain when I died?"
        End If
    End Sub
    Public Sub QuestionRegulator()
        addend1 = randomizer.Next(3)
        addend2 = randomizer.Next(3)
        If Label1.Text = "1)" Then
            Questions()
        ElseIf Label2.Text = "2)" Then
            Questions()
        ElseIf Label3.Text = "3)" Then
            Questions()
        ElseIf Label4.Text = "4)" Then
            Questions()
        ElseIf Label5.Text = "5)" Then
            Questions()
        End If
    End Sub
    Public Sub CorrectAnswers()
        If addend1.ToString = "1" Then
            If MaskedTextBox1.Text = "physics" Then
                Label10.Text = "1/5"
            End If
        ElseIf addend1.ToString = "2" Then
            If MaskedTextBox1.Text = "Israel" Then
                Label10.Text = "1/5"
            End If
        End If
        If addend2.ToString = "1" Then
            If MaskedTextBox2.Text = "no" Then
                Label10.Text = "2/5"
            End If
        ElseIf addend2.ToString = "2" Then
            If MaskedTextBox2.Text = "yes" Then
                Label10.Text = "2/5"
            End If
        End If
        If addend1.ToString = "1" Then
            If MaskedTextBox3.Text = "money" Then
                Label10.Text = "3/5"
            End If
        ElseIf addend1.ToString = "2" Then
            If MaskedTextBox3.Text = "relativity" Then
                Label10.Text = "3/5"
            End If
        End If
        If addend2.ToString = "1" Then
            If MaskedTextBox4.Text = "pi" Then
                Label10.Text = "4/5"
            End If
        ElseIf addend2.ToString = "2" Then
            If MaskedTextBox2.Text = "speed of light" Then
                Label10.Text = "4/5"
            End If
        End If
        If addend1.ToString = "1" Then
            If MaskedTextBox5.Text = "quantum mechanics" Then
                Label10.Text = "5/5"
            End If
        ElseIf addend1.ToString = "2" Then
            If MaskedTextBox5.Text = "it was studied by scientists" Then
                Label10.Text = "5/5"
            End If
        End If
    End Sub
    Public Function CheckTheAnswer() As Boolean
        If Label10.Text = "5/5" Then
            Return True
        Else
            QuestionRegulator()
            Return False
        End If
    End Function
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        CorrectAnswers()
        If TextBox1.Text = "6 seconds" Then
            TextBox1.ForeColor = Color.Red
        End If
        If TextBox1.Text = "5 seconds" Then
            TextBox1.ForeColor = Color.Black
        End If
        If TextBox1.Text = "4 seconds" Then
            TextBox1.ForeColor = Color.Red
        End If
        If TextBox1.Text = "3 seconds" Then
            TextBox1.ForeColor = Color.Black
        End If
        If TextBox1.Text = "2 seconds" Then
            TextBox1.ForeColor = Color.Red
        End If
        If TextBox1.Text = Nothing Then
            Button1.Enabled = False
        ElseIf TextBox1.Text = "5" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
            If TextBox1.Text.Contains("seconds") Then
                If CheckTheAnswer() Then
                    Timer1.Stop()
                    MessageBox.Show("You got all of the answers right!", "Congratulations!")
                    TextBox1.Clear()
                    MaskedTextBox1.Clear()
                    MaskedTextBox2.Clear()
                    MaskedTextBox3.Clear()
                    MaskedTextBox4.Clear()
                    MaskedTextBox5.Clear()
                    Label1.Text = "1)"
                    Label2.Text = "2)"
                    Label3.Text = "3)"
                    Label4.Text = "4)"
                    Label5.Text = "5)"
                    TextBox1.Select()
                    Label10.Text = "0/5"
                    Me.Refresh()
                    AxWindowsMediaPlayer1.Show()

                    AxWindowsMediaPlayer1.URL = Application.StartupPath & "/Congradulations You Win.wmv"
                    Timer1.Start()
                ElseIf timeLeft > 0 Then
                    timeLeft -= 1
                    TextBox1.Text = timeLeft & " seconds"
                Else
                    TextBox1.ForeColor = Color.Red
                    Timer1.Stop()
                    TextBox1.ForeColor = Color.Black
                    TextBox1.Text = "Time's up!"
                    MessageBox.Show("You didn't finish in time.", "Sorry")
                    TextBox1.Clear()
                    MaskedTextBox1.Clear()
                    MaskedTextBox2.Clear()
                    MaskedTextBox3.Clear()
                    MaskedTextBox4.Clear()
                    MaskedTextBox5.Clear()
                    TextBox1.Select()
                    Timer1.Start()
                End If
                Button1.Enabled = False
            End If
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label7.Hide()
        timeLeft = TextBox1.Text
        TextBox1.Text = TextBox1.Text & " seconds"
        MaskedTextBox1.Select()
        addend1 = randomizer.Next(3)
        addend2 = randomizer.Next(3)
        Questions()
        Button2.Enabled = True
        Timer1.Start()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Timer1.Stop()
        Me.Hide()
        Form1.Show()
        Form1.AxWindowsMediaPlayer1.Ctlcontrols.pause()
        Form1.AxWindowsMediaPlayer1.Hide()
        Form1.Button2.Text = "< Back"
        Form1.Label1.Show()
        If MaskedTextBox1.Text = Nothing Then
            Form1.Label1.Text = "If you need to watch the video again, click [< Back], when finished click [Instructions], and then [Play] to resume the game." & vbNewLine & vbNewLine _
                    & "          1) Mentioned in video and starts with a [Ph-----] or [Is----]."
        ElseIf MaskedTextBox2.Text = Nothing Then
            Form1.Label1.Text = vbNewLine & vbNewLine & "          2) Yes or no questions."
        ElseIf MaskedTextBox3.Text = Nothing Then
            Form1.Label1.Text = vbNewLine & "If you need to watch the video again, click [< Back], when finished click [Instructions], and then [Play] to resume the game." & vbNewLine & vbNewLine _
                                & "          3) Currency or mentioned in video and starts with [rela------]."
        ElseIf MaskedTextBox4.Text = Nothing Then
            Form1.Label1.Text = vbNewLine & vbNewLine & vbNewLine & vbNewLine & "          4) Something edible and circular or speed of ________"
        ElseIf MaskedTextBox5.Text = Nothing Then
            Form1.Label1.Text = vbNewLine & vbNewLine & vbNewLine & "If you need to watch the video again, click [< Back], when finished click [Instructions], and then [Play] to resume the game." & vbNewLine & vbNewLine _
                                                                  & "5) _______ mechanics was mentioned in video, or it was studied by _______"
        End If
    End Sub
End Class