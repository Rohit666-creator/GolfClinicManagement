Imports System.Data.SqlClient
Public Class Form3
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As DataSet

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        DateTimePicker1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = ""
        ComboBox1.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox2.Focus()
    End Sub


    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("Male")
        ComboBox2.Items.Add("Female")
        ComboBox1.Items.Add("Yes")
        ComboBox1.Items.Add("No")

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        da = New SqlDataAdapter("select * from playerinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        'for inserting records
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("insert into playerinfo values('" + DateTimePicker1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + TextBox4.Text + "'," + TextBox5.Text + ",'" + ComboBox2.Text + "','" + ComboBox1.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "'," + TextBox9.Text + ")", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records Saved Successfully",MsgBoxStyle.Information)
        con.Close()

        'to show in datagrid
        da = New SqlDataAdapter("select * from playerinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim x As String
        x = InputBox("Enter the record to delete")
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("delete from playerinfo where Player_id='" + x + "'", con)
        cmd.ExecuteNonQuery()
        MsgBox("Record deleted successfully", MsgBoxStyle.Information)
        con.Close()

        da = New SqlDataAdapter("select * from playerinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click


        'For Searching Records
        Dim id As String
        id = InputBox("Enter the record to search")


        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("select * from playerinfo where Player_Id='" + id + "' ", con)
        dr = cmd.ExecuteReader()
        dr.Read()
        Try
            DateTimePicker1.Text = dr("Date")
            TextBox2.Text = dr("Player_Id")
            TextBox3.Text = dr("Player_Name")
            TextBox4.Text = dr("Player_Address")
            TextBox5.Text = dr("Player_Age")
            ComboBox2.Text = dr("Gender")
            ComboBox1.Text = dr("Golf_Club_Member")
            TextBox6.Text = dr("Contact_No")
            TextBox7.Text = dr("Aadhaar_No")
            TextBox8.Text = dr("Email_Id")
            TextBox9.Text = dr("Batch_No")
            con.Close()
        Catch dr As Exception
            MsgBox("Record not found")
        End Try

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'updating data in playerinfo
        Dim u As String
        u = TextBox2.Text
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("update playerinfo set Date='" + DateTimePicker1.Text + "',Player_Id=" + TextBox2.Text + ",Player_Name='" + TextBox3.Text + "',Player_Address='" + TextBox4.Text + "',Player_Age=" + TextBox5.Text + ",Gender='" + ComboBox2.Text + "',Golf_Club_Member='" + ComboBox1.Text + "',Contact_No='" + TextBox6.Text + "',Aadhaar_No='" + TextBox7.Text + "',Email_Id='" + TextBox8.Text + "',Batch_No=" + TextBox9.Text + " where Player_Id=" + u + "", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records updated successfully")
        con.Close()

        'To show in data grid
        da = New SqlDataAdapter("select * from playerinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
End Class