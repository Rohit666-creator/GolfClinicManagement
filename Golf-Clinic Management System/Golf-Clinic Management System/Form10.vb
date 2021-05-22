Public Class Form10

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Form10_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("Present")
        ComboBox2.Items.Add("Absent")
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub TextBox6_Click(sender As Object, e As System.EventArgs) Handles TextBox6.Click
        Dim a, b, c, r As Integer
        a = TextBox3.Text
        b = TextBox4.Text
        c = TextBox5.Text

        r = a + b + c
        TextBox6.Text = r
        If (r >= 18) Then
            TextBox7.Text = "Yes"
        Else
            TextBox7.Text = "No"
        End If
    End Sub

    Private Sub TextBox6_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox6.TextChanged
        
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As System.EventArgs) Handles ComboBox1.Click
       
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class