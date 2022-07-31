Public Class frmSpecs
    Private Sub frmSpecs_Load() Handles MyBase.Load
        'Retval1 {1:BioProgsSpecs  | 2:CourseSpecs}
        'Retval2 : result are stored in Retval2 when menu_OK is clicked
        Select Case Retval1
            Case 1 'BioProgs
                Chk1.Text = "فوق ديپلم"
                Chk2.Text = "کارشناسي"
                Chk3.Text = "کارشناسي ارشد"
                Chk4.Text = "دکتري عمومي"
                Chk5.Text = "دکتري تخصصي"
                Chk6.Text = "سرويس هاي آموزشي دانشکده"
                Chk7.Text = "برنامه گروه آموزشي"
                Chk8.Text = "امور اجرايي"
            Case 2 'Courses
                Chk1.Text = "درس عملي"
                Chk2.Text = "درس تئوري"
                Chk3.Text = "درس الزامي"
                Chk4.Text = "-" : Chk4.Enabled = False
                Chk5.Text = "-" : Chk5.Enabled = False
                Chk6.Text = "-" : Chk6.Enabled = False
                Chk7.Text = "-" : Chk7.Enabled = False
                Chk8.Text = "-" : Chk8.Enabled = False
        End Select

        If (Retval2 And 1) = 1 Then Chk1.Checked = True
        If (Retval2 And 2) = 2 Then Chk2.Checked = True
        If (Retval2 And 4) = 4 Then Chk3.Checked = True
        If (Retval2 And 8) = 8 Then Chk4.Checked = True
        If (Retval2 And 16) = 16 Then Chk5.Checked = True
        If (Retval2 And 32) = 32 Then Chk6.Checked = True
        If (Retval2 And 64) = 64 Then Chk7.Checked = True
        If (Retval2 And 128) = 128 Then Chk8.Checked = True

    End Sub

    Private Sub Menu_OK_Click(sender As Object, e As EventArgs) Handles Menu_OK.Click
        Retval2 = 0
        Retval1 = 1 '[1: OK | 2: Cancel]
        If Chk1.Checked = True Then Retval2 = (Retval2 Or 1)
        If Chk2.Checked = True Then Retval2 = (Retval2 Or 2)
        If Chk3.Checked = True Then Retval2 = (Retval2 Or 4)
        If Chk4.Checked = True Then Retval2 = (Retval2 Or 8)
        If Chk5.Checked = True Then Retval2 = (Retval2 Or 16)
        If Chk6.Checked = True Then Retval2 = (Retval2 Or 32)
        If Chk7.Checked = True Then Retval2 = (Retval2 Or 64)
        If Chk8.Checked = True Then Retval2 = (Retval2 Or 128)

        Me.Dispose()

    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Retval1 = 0 '[1: OK | 2: Cancel]
        Me.Dispose()

    End Sub

End Class