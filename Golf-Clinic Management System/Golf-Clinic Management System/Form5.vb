
Imports System.Data.SqlClient


Public Class Form5
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet


    Private Sub Form5_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("Present")
        ComboBox2.Items.Add("Absent")

        ComboBox3.Items.Add("Good")
        ComboBox3.Items.Add("Poor")
        ComboBox3.Items.Add("Not Applicable")
       
        'to show datagridview
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=puttinginfo;Integrated Security=True")
        da = New SqlDataAdapter("select * from puttinginfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox3.Text = ""
        TextBox1.Focus()
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form2.Show()
    End Sub



    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        'To Insert Records into database
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=puttinginfo;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("insert into puttinginfo values('" + DateTimePicker1.Text + "'," + ComboBox1.Text + ",'" + TextBox1.Text + "'," + TextBox2.Text + ",'" + ComboBox2.Text + "'," + TextBox3.Text + "," + TextBox4.Text + ",'" + TextBox5.Text + "','" + ComboBox3.Text + "')", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records saved successfully", MsgBoxStyle.Information)
        con.Close()

        'to show in datagrid
        da = New SqlDataAdapter("select * from puttinginfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As System.EventArgs) Handles ComboBox1.Click

        'for fetching Player Id into Putting session
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=playerinfo;Integrated Security=True")
        con.Open()
        ComboBox1.Items.Clear()
        cmd = New SqlCommand("select Player_Id from playerinfo where Golf_Club_Member='Yes'", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            ComboBox1.Items.Add(dr("Player_Id").ToString())

        End While
        con.Close()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        'for fetching Player Name & Batch No into Putting Session
        Dim cmb As String
        cmb = ComboBox1.Text

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=playerinfo;Integrated Security=True")
        con.Open()

        cmd = New SqlCommand("select Player_Name,Batch_No from playerinfo where Player_Id='" + cmb + "'", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            TextBox1.Text = (dr("Player_Name").ToString())
            TextBox3.Text = (dr("Batch_No").ToString())
        End While
        con.Close()

        'for fetching Coach Id and Coach Name into Putting Session
        Dim bno As String
        bno = TextBox3.Text

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=coachinfo;Integrated Security=True")
        con.Open()

        cmd = New SqlCommand("select Coach_Id,Coach_Name from coachinfo where Batch_no='" + bno + "' ", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            TextBox4.Text = (dr("Coach_Id").ToString())
            TextBox5.Text = (dr("Coach_Name").ToString())
        End While
        con.Close()
    End Sub

    Private Sub TextBox4_GotFocus(sender As Object, e As System.EventArgs) Handles TextBox4.GotFocus
       
    End Sub

End Class

