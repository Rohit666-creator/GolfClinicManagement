Imports System.Data.SqlClient

Public Class Form4
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox1.Focus()
    End Sub


    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
       
        'to insert records into coachinfo
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("insert into coachinfo values('" + DateTimePicker1.Text + "'," + TextBox1.Text + ",'" + TextBox2.Text + "','" + TextBox3.Text + "','" + ComboBox1.Text + "' ,'" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "'," + TextBox7.Text + ")", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records saved successfully", MsgBoxStyle.Information)
        con.Close()

        'to show datagrid
        da = New SqlDataAdapter("select * from coachinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Form4_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ComboBox1.Items.Add("Male")
        ComboBox1.Items.Add("Female")

        'to show datagrid 
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        da = New SqlDataAdapter("select * from coachinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        'for deleting records from coachinfo
        Dim x As String
        x = InputBox("Enter the record to delete")
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("delete from coachinfo where Coach_Id='" + x + "'", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records deleted successfully", MsgBoxStyle.Information)
        con.Close()

        'to show datagrid
        da = New SqlDataAdapter("select * from coachinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

End Class