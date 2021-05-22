Public Class Form9


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If (TextBox1.Text = "par4") And (TextBox2.Text = "par4") Then
            MsgBox("Login Successful",MsgBoxStyle.Information)
            Me.Hide()
            Form2.ShowDialog()
        Else
            MsgBox("Username or Password Invalid", MsgBoxStyle.Critical)
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class