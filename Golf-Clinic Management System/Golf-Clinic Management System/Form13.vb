Imports System.Data.SqlClient


Public Class Form13
    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim dr As SqlDataReader

    Private Sub ComboBox1_Click(sender As Object, e As System.EventArgs) Handles ComboBox1.Click

        'for fetching Player Id into Payment Details
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("select Player_Id from playerinfo", con)
        dr = cmd.ExecuteReader()
        ComboBox1.Items.Clear()
        While dr.Read()
            ComboBox1.Items.Add(dr("Player_Id").ToString())
        End While
        con.Close()

    End Sub




    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        'for fetching memberinfo details into Payment details
        Dim cmb As String
        cmb = ComboBox1.Text

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()

        cmd = New SqlCommand("select Date,Membership_No,Membership_Type,Golf_Club_Member from memberinfo where Player_Id='" + cmb + "'", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            DateTimePicker1.Text = (dr("Date").ToString())
            TextBox1.Text = (dr("Membership_No").ToString())
            TextBox2.Text = (dr("Membership_Type").ToString())
            ComboBox3.Text = (dr("Golf_Club_Member").ToString())
        End While
        con.Close()
       
    End Sub
    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click

        If (TextBox4.Text = "3,00,000") Then
            ComboBox3.Text = "Yes"
        ElseIf (TextBox4.Text = "10,00,000") Then
            ComboBox3.Text = "Yes"
        End If
        MsgBox("***Payment done***", MsgBoxStyle.Information)
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        Me.Close()

    End Sub

    Private Sub Form13_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Button2.Visible = False

        ComboBox2.Items.Add("cash")
        ComboBox2.Items.Add("cheque")

        'to show datagrid
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        da = New SqlDataAdapter("select * from paymentinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'for inserting records in paymentinfo
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("insert into paymentinfo values('" + DateTimePicker1.Text + "','" + ComboBox1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + ComboBox2.Text + "','" + TextBox4.Text + "','" + ComboBox3.Text + "')", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records saved successfully")
        con.Close()

        'to show in datagrid
        da = New SqlDataAdapter("select * from paymentinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

        

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'for deleting records in paymentinfo
        Dim x As String
        x = InputBox("Enter the record to delete")

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("delete from paymentinfo where Player_Id=" + x + "", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records deleted successfully")
        con.Close()

        'to show in datagrid
        da = New SqlDataAdapter("select * from paymentinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Button2.Visible = True

        'For Searching Records
        Dim id As String
        id = InputBox("Enter the record to search")


        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("select * from paymentinfo where Player_Id='" + id + "'", con)
        dr = cmd.ExecuteReader()
        dr.Read()
        Try
            DateTimePicker1.Text = dr("Date")
            ComboBox1.Text = dr("Player_Id")
            TextBox1.Text = dr("Membership_No")
            TextBox2.Text = dr("Membership_Type")
            TextBox3.Text = dr("Payment_For")
            ComboBox2.Text = dr("Payment_Mode")
            TextBox4.Text = dr("Amount_Paid")
            ComboBox3.Text = dr("Golf_Club_Member")
            con.Close()
        Catch dr As Exception
            MsgBox("Record Not found")
            Button2.Visible = False
        End Try

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click

        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        TextBox4.Text = ""
        ComboBox3.Text = ""
        ComboBox1.Focus()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        'For updating records in Paymentinfo
        Dim u As String
        u = ComboBox1.Text
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("update paymentinfo set Date='" + DateTimePicker1.Text + "',Player_Id=" + ComboBox1.Text + ",Membership_No='" + TextBox1.Text + "',Membership_Type='" + TextBox2.Text + "',Payment_For='" + TextBox3.Text + "',Payment_Mode='" + ComboBox2.Text + "',Amount_Paid='" + TextBox4.Text + "',Golf_Club_Member='" + ComboBox3.Text + "' where Player_Id=" + u + "", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records updated successfully")
        con.Close()

        'to show in datagrid
        da = New SqlDataAdapter("select * from paymentinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)


    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        If (TextBox2.Text = "Temporary") Then
            TextBox4.Text = "3,00,000"
        ElseIf (TextBox2.Text = "Gold") Then
            TextBox4.Text = "10,00,000"
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Form16.Show()
        Me.Hide()
    End Sub
End Class