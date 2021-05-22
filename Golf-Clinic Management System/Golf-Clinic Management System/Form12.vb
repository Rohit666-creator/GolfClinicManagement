Imports System.Data.SqlClient

Public Class Form12
    Dim con As New SqlConnection
    Dim cmd As New SqlCommand
    Dim da As New SqlDataAdapter
    Dim dr As SqlDataReader
    Dim ds As DataSet

    Private Sub Form12_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Panel4.Visible = False
        Button2.Visible = False

        ComboBox3.Items.Add("Yes")
        ComboBox3.Items.Add("No")

        ComboBox4.Items.Add("Temporary")
        ComboBox4.Items.Add("Gold")

        'To show datagrid of memberinfo details

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        da = New SqlDataAdapter("select * from memberinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim amt As String
        amt = TextBox5.Text

        If (ComboBox4.Text = "Temporary") Then
            TextBox5.Text = "3,00,000"
        ElseIf (ComboBox4.Text = "Gold") Then
            TextBox5.Text = "10,00,000"
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Panel3.Visible = True
        TextBox6.Text = TextBox4.Text

        If (TextBox5.Text = "3,00,000") Then
            TextBox7.Text = "Temporary"
        ElseIf (TextBox5.Text = "10,00,000") Then
            TextBox7.Text = "Gold"
        End If

        MsgBox("Membership Applied")

        'If (ComboBox2.Text = "No") Then
        'ComboBox2.Text = "Yes"
        'End If

    End Sub

    Private Sub ComboBox1_Click(sender As Object, e As System.EventArgs) Handles ComboBox1.Click

        'for fetching Player Id into Membership Details
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        ComboBox1.Items.Clear()
        cmd = New SqlCommand("select Player_Id from playerinfo ", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            ComboBox1.Items.Add(dr("Player_Id").ToString())
        End While
        con.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        'for fetching playerinfo details into Membership details
        Dim cmb As String
        cmb = ComboBox1.Text

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()

        cmd = New SqlCommand("select Player_Name,Player_Address,Player_Age,Golf_Club_Member from playerinfo where Player_Id='" + cmb + "'", con)
        dr = cmd.ExecuteReader()
        While dr.Read()
            TextBox1.Text = (dr("Player_Name").ToString())
            TextBox2.Text = (dr("Player_Address").ToString())
            TextBox3.Text = (dr("Player_Age").ToString())
            ComboBox2.Text = (dr("Golf_Club_Member").ToString())
        End While
        con.Close()

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Panel4.Visible = True
    End Sub
   
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'inserting records into memberinfo
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("insert into memberinfo values('" + DateTimePicker1.Text + "','" + ComboBox1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "'," + TextBox3.Text + ",'" + ComboBox2.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + DateTimePicker2.Text + "')", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records Saved Successfully")
        con.Close()

        da = New SqlDataAdapter("select * from memberinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click 
        'Form13.TopLevel = False
        'Form13.TopMost = True
        'Panel1.Controls.Add(Form13)
        Form13.Show()
        Me.Hide()

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Button2.Visible = True

        'For Searching Records
        Dim id As String
        id = InputBox("Enter the record to search")


        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("select * from memberinfo where Player_Id='" + id + "'", con)
        dr = cmd.ExecuteReader()
        dr.Read()

        Try
            DateTimePicker1.Text = dr("Date")
            ComboBox1.Text = dr("Player_Id")
            TextBox1.Text = dr("Player_Name")
            TextBox2.Text = dr("Player_Address")
            TextBox3.Text = dr("Player_Age")
            ComboBox2.Text = dr("Golf_Club_Member")
            TextBox6.Text = dr("Membership_No")
            TextBox7.Text = dr("Membership_Type")
            DateTimePicker2.Text = dr("Valid_Till")
            con.Close()

        Catch dr As Exception
            MsgBox("Records not found")
            Button2.Visible = False
        End Try
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click

        'For Deleting records from Member Details
        Dim x As String
        x = InputBox("Enter the record to delete")

        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("delete from memberinfo where Player_Id=" + x + "", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records deleted successfully")
        con.Close()

        da = New SqlDataAdapter("select * from memberinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Panel4.Visible = False
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        ComboBox4.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox1.Focus()
    End Sub

   
    Private Sub TextBox7_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox7.TextChanged


        If (TextBox7.Text = "Gold") Then
            'DateTimePicker2.Format = DateTimePickerFormat.Custom
            'DateTimePicker2.CustomFormat = " "
            Me.DateTimePicker2.Value = New Date(2070, 6, 18, 0, 0, 0, 0)
        End If

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        'For updating records in memberinfo
        Dim u As String
        u = ComboBox1.Text
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        con.Open()
        cmd = New SqlCommand("update memberinfo set Date='" + DateTimePicker1.Text + "',Player_Id=" + ComboBox1.Text + ",Player_Name='" + TextBox1.Text + "',Player_Address='" + TextBox2.Text + "',Player_Age=" + TextBox3.Text + ",Golf_Club_Member='" + ComboBox2.Text + "',Membership_No='" + TextBox6.Text + "',Membership_Type='" + TextBox7.Text + "',Valid_Till='" + DateTimePicker2.Text + "' where Player_Id=" + u + "", con)
        cmd.ExecuteNonQuery()
        MsgBox("Records updated successfully")
        con.Close()

        da = New SqlDataAdapter("select * from memberinfo", con)
        ds = New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)

    End Sub
End Class