Imports System.Data.SqlClient

Public Class Form6
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As DataSet



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

    Private Sub Form6_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Items.Add("Present")
        ComboBox2.Items.Add("Absent")

        ComboBox3.Items.Add("Good")
        ComboBox3.Items.Add("Poor")
        ComboBox3.Items.Add("Not Applicable")
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As System.EventArgs) Handles ComboBox1.Click

        'for fetching Player Id into Chipping session
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=playerinfo;Integrated Security=True")
        con.Open()
        ComboBox1.Items.Clear()
        cmd = New SqlCommand("select Player_Id from playerinfo", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            ComboBox1.Items.Add(dr("Player_Id").ToString())

        End While
        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        'for fetching Player Name & Batch No into Chipping Session
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

        'for fetching Coach Id and Coach Name into Chipping Session
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
End Class