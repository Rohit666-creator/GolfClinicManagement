Public Class Form14

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Form15.Show()
        Me.Hide()
    End Sub

    Private Sub Form14_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel4.Visible = False

        ComboBox3.Items.Add("Yes")
        ComboBox3.Items.Add("No")

        ComboBox4.Items.Add("Temporary")
        ComboBox4.Items.Add("Gold")


    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim amt As String
        amt = TextBox6.Text

        If (ComboBox4.Text = "Temporary") Then
            TextBox6.Text = "3,00,000"
        ElseIf (ComboBox4.Text = "Gold") Then
            TextBox6.Text = "10,00,000"
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox3.Text = TextBox5.Text

        If (TextBox6.Text = "3,00,000") Then
            TextBox4.Text = "Temporary"
        ElseIf (TextBox6.Text = "10,00,000") Then
            TextBox4.Text = "Gold"
        End If
    End Sub
End Class