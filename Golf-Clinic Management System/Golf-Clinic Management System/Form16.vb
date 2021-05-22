Imports System.Data.SqlClient

Public Class Form16
    Dim con As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim dt As DataTable
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        'for paymentinfo Crystal Report
        con = New SqlConnection("Data Source=DESKTOP-341EKLB\SQLEXPRESS;Initial Catalog=GolfClinicManagementSystem;Integrated Security=True")
        da = New SqlDataAdapter("select * from paymentinfo", con)
        dt = New DataTable
        da.Fill(dt)
        Dim rpt As New CrystalReport1
        rpt.SetDataSource(dt)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
        rpt.Close()
        rpt.Dispose()
    End Sub
End Class