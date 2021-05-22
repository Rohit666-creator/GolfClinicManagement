Public Class Form15

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If (TextBox4.Text = "3,00,000") Then
            ComboBox3.Text = "Yes"
        ElseIf (TextBox4.Text = "10,00,000") Then
            ComboBox3.Text = "Yes"
        End If
    End Sub
End Class