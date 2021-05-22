Public Class Form2

    
    Private Sub CHIPPINGSESSIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CHIPPINGSESSIONToolStripMenuItem.Click
        Form5.TopLevel = False
        Form5.TopMost = True
        Panel1.Controls.Add(Form5)
        Form5.Show()
    End Sub

    Private Sub DRIVINGRANGESESSIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DRIVINGRANGESESSIONToolStripMenuItem.Click
        Form6.TopLevel = False
        Form6.TopMost = True
        Panel1.Controls.Add(Form6)
        Form6.Show()
    End Sub

    Private Sub HOLEPLAYINGToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles HOLEPLAYINGToolStripMenuItem.Click
        Form7.TopLevel = False
        Form7.TopMost = True
        Panel1.Controls.Add(Form7)
        Form7.Show()
    End Sub

    Private Sub LOGOUTToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles LOGOUTToolStripMenuItem1.Click
        Form9.TopLevel = True
        Form9.TopMost = False
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub EVALUATIONEXAMToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EVALUATIONEXAMToolStripMenuItem.Click
        Form10.TopLevel = False
        Form10.TopMost = True
        Panel1.Controls.Add(Form10)
        Form10.Show()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Form11.TopLevel = False
        Form11.TopMost = True
        Panel1.Controls.Add(Form11)
        Form11.Show()

    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub REGISTRATIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles REGISTRATIONToolStripMenuItem.Click
        Form3.TopLevel = False
        Form3.TopMost = True
        Panel1.Controls.Add(Form3)
        Form3.Show()
    End Sub

    Private Sub PAYMENTToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PAYMENTToolStripMenuItem.Click
        Form12.TopLevel = False
        Form12.TopMost = True
        Panel1.Controls.Add(Form12)
        Form12.Show()
    End Sub

    Private Sub PLAYERINFODETAILSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PLAYERINFODETAILSToolStripMenuItem.Click
        Form13.TopLevel = False
        Form13.TopMost = True
        Panel1.Controls.Add(Form13)
        Form13.Show()
    End Sub

    Private Sub REGISTRATIONToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles REGISTRATIONToolStripMenuItem1.Click
        Form4.TopLevel = False
        Form4.TopMost = True
        Panel1.Controls.Add(Form4)
        Form4.Show()
    End Sub

    Private Sub MEMBERSHIPToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MEMBERSHIPToolStripMenuItem.Click
        Form14.TopLevel = False
        Form14.TopMost = True
        Panel1.Controls.Add(Form14)
        Form14.Show()
    End Sub

    Private Sub PAYMENTToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles PAYMENTToolStripMenuItem1.Click
        Form15.TopLevel = False
        Form15.TopMost = True
        Panel1.Controls.Add(Form15)
        Form15.Show()
    End Sub

    Private Sub PlayerInformationToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PlayerInformationToolStripMenuItem.Click
        Form3.Hide()
        Form4.Hide()
        Form5.Hide()
        Form6.Hide()
        Form7.Hide()
        Form10.Hide()
        Form11.Hide()
        Form12.Hide()
        Form13.Hide()
        Form14.Hide()
        Form15.Hide()

    End Sub

    Private Sub PUTTINGSESSIONToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PUTTINGSESSIONToolStripMenuItem.Click
        Form3.Hide()
        Form4.Hide()
        Form5.Hide()
        Form6.Hide()
        Form7.Hide()
        Form10.Hide()
        Form11.Hide()
        Form12.Hide()
        Form13.Hide()
        Form14.Hide()
        Form15.Hide()
    End Sub
End Class