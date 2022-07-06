Public Class frmShowTables

    Private Sub frmShowTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Show_Table()
        If ((UserAccessConntrols And (2 ^ 0) = 0) And Userx = "USER Department") Then
            Menu_AddNew.Enabled = False
        Else
            Menu_AddNew.Enabled = True
        End If
    End Sub
    Private Sub Show_Table()
        DS.Tables("tblCourses").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT Courses.ID, CourseName, CourseNumber, Units, [Units_equivalent] As Eq FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & intBioProg.ToString & " ORDER BY CourseName"
                DASS.Fill(DS, "tblCourses")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT Courses.ID, CourseName, CourseNumber, Units, [Units_equivalent] As Eq FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & intBioProg.ToString & " ORDER BY CourseName"
                DAAC.Fill(DS, "tblCourses")
        End Select

        Grid1.DataSource = DS.Tables("tblCourses")
        Grid1.Refresh()
        Grid1.Columns(0).Width = 0    'ID
        Grid1.Columns(1).Width = 290  'CourseName
        Grid1.Columns(2).Width = 90   'CourseNumber
        Grid1.Columns(3).Width = 50   'Unit
        Grid1.Columns(4).Width = 50   'Unit-eq

        Grid1.Columns(0).Visible = False     'ID

        For i = 0 To Grid1.Columns.Count - 1
            Grid1.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

    End Sub
    Private Sub Grid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellValueChanged
        If (Userx = "USER Department") And (UserAccessConntrols And (2 ^ 4) = 0) Then ' 2^0 (1-1) is for Courses: acc1
            MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        End If
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub

        SvaeChanges_Courses()

    End Sub

    'Save CHANGES
    Private Sub SvaeChanges_Courses()
        If Grid1.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid1.CurrentCell.RowIndex
        If r < 0 Then Exit Sub

        Dim strCourseName As String = Grid1.Rows(r).Cells(1).Value
        DS.Tables("tblCourses").Rows(r).Item(1) = strCourseName

        Dim intCourseNumber As Integer = Grid1.Rows(r).Cells(2).Value
        DS.Tables("tblCourses").Rows(r).Item(2) = intCourseNumber

        Dim intCourseUnit As Integer = Grid1.Rows(r).Cells(3).Value
        DS.Tables("tblCourses").Rows(r).Item(3) = intCourseUnit

        Dim intCourseUnitEq As Integer = Grid1.Rows(r).Cells(4).Value
        DS.Tables("tblCourses").Rows(r).Item(4) = intCourseUnitEq
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Units = @units, Units_equivalent = @unitsequivalent WHERE ID = @ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@coursename", strCourseName)
                cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber)
                cmd.Parameters.AddWithValue("@units", intCourseUnit)
                cmd.Parameters.AddWithValue("@unitsequivalent", intCourseUnitEq)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblCourses").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Units = @units, Units_equivalent = @unitsequivalent WHERE ID = @ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@coursename", strCourseName)
                cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber)
                cmd.Parameters.AddWithValue("@units", intCourseUnit)
                cmd.Parameters.AddWithValue("@unitsequivalent", intCourseUnitEq)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblCourses").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
        End Select

    End Sub

    Private Sub Menu_AddNewItem(sender As Object, e As EventArgs) Handles Menu_AddNew.Click
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub

        Dim myansw As DialogResult = MsgBox("درس جديد اضافه شود؟", vbQuestion + vbYesNo + vbDefaultButton2, "NexTerm :  " & strCaption)
        If myansw = vbNo Then Exit Sub
        Dim strNewCourse As String = InputBox("نام درس جديد را وارد کنيد" & vbCrLf & vbCrLf & "در اين ليست (جديد) باشد", "تعريف درس جديد", "")
        If Trim(strNewCourse) = "" Then Exit Sub
        Dim intNewCourse As Long = InputBox("شماره درس؟", "تعريف درس جديد", "1234")
        If intNewCourse < 0 Then Exit Sub

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units, Units_equivalent) VALUES (@bioprogid, @newcourse, @coursenumber, 2, 2)"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@bioprogid", intBioProg.ToString)
                cmd.Parameters.AddWithValue("@newcourse", strNewCourse)
                cmd.Parameters.AddWithValue("@newcourse", intNewCourse.ToString)
                cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units, Units_equivalent) VALUES (@bioprogid, @newcourse, @coursenumber, 2, 2)"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@bioprogid", intBioProg.ToString)
                cmd.Parameters.AddWithValue("@newcourse", strNewCourse)
                cmd.Parameters.AddWithValue("@newcourse", intNewCourse.ToString)
                cmd.ExecuteNonQuery()
        End Select
        Grid1.Refresh()
        Show_Table()

    End Sub

    Private Sub PopMenu_Exit(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        btnOkExit.Focus()
        Dim r As Integer = Grid1.SelectedCells(0).RowIndex
        intCourse = Val(Grid1(0, r).Value)
        strCourse = Grid1(1, r).Value

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub btnOkExit_Click(sender As Object, e As EventArgs) Handles btnOkExit.Click
        PopMenu_Exit(sender, e)
    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        btnOkExit.Focus()
        Dim r As Integer = Grid1.SelectedCells(0).RowIndex
        intCourse = 0
        strCourse = ""

        Me.Close()
        Me.Dispose()

    End Sub
End Class