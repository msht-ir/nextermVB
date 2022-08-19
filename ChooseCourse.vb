Public Class ChooseCourse
    Private Sub ChooseCourse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridCourse.EditMode = DataGridViewEditMode.EditProgrammatically '//DataGridViewEditMode.EditOnKeystrokeOrF2
        If (Userx = "USER Department" And (UserAccessControls And (2 ^ 0)) = 0) Then
            MenuAddCourse.Enabled = False
            Menu_Edit.Enabled = False
        Else
            MenuAddCourse.Enabled = True
            Menu_Edit.Enabled = True
        End If

        'Fill ComboBox (BioProgs)
        If intDept < 1 Then intDept = 2
        DS.Tables("tblBioProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT BioProgs.ID AS ProgID, ProgramName As Prog FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & intDept.ToString & " ORDER BY ProgramName"
                DASS.Fill(DS, "tblBioProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT BioProgs.ID AS ProgID, ProgramName As Prog FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & intDept.ToString & " ORDER BY ProgramName"
                DAAC.Fill(DS, "tblBioProgs")
        End Select

        ComboBioProg.DataSource = DS.Tables("tblBioProgs")
        ComboBioProg.DisplayMember = "Prog"
        ComboBioProg.ValueMember = "ProgID"
        ComboBioProg.SelectedValue = intBioProg
        ComboBioProg.Refresh()

        ComboBioProg_SelectedIndexChanged(sender, e)
        For i As Integer = 0 To GridCourse.Rows.Count - 1
            If GridCourse(0, i).Value = intCourse Then
                GridCourse.CurrentCell = GridCourse.Rows(i).Cells(1)
                Exit Sub
            End If
        Next

    End Sub

    Private Sub ComboBioProg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBioProg.SelectedIndexChanged
        'ComboBioProg -> Populates GridCourse
        Dim i As String = ComboBioProg.GetItemText(ComboBioProg.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        intBioProg = Val(i)
        'READ FROM DATABASE
        DS.Tables("tblCourses").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT Courses.ID, CourseName, CourseNumber, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & intBioProg.ToString & " ORDER BY CourseName"
                DASS.Fill(DS, "tblCourses")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT Courses.ID, CourseName, CourseNumber, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & intBioProg.ToString & " ORDER BY CourseName"
                DAAC.Fill(DS, "tblCourses")
        End Select

        GridCourse.DataSource = DS.Tables("tblCourses")
        GridCourse.Refresh()

        GridCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridCourse.Columns(0).Width = 0    'ID
        GridCourse.Columns(1).Width = 220  'Course
        GridCourse.Columns(2).Width = 80   'Number
        GridCourse.Columns(3).Width = 40   'Units

        GridCourse.Columns(0).Visible = False

        For k = 0 To GridCourse.Columns.Count - 1
            GridCourse.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
        Next k

    End Sub

    Private Sub GridCourse_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridCourse.CellValueChanged
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridCourse.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCourse.CurrentCell.RowIndex   'count from 0
        If r < 0 Then Exit Sub

        GridCourse.CurrentCell = GridCourse(1, r)

        Dim strCourseName As String = GridCourse.Rows(r).Cells(1).Value
        DS.Tables("tblCourses").Rows(r).Item(1) = strCourseName

        Dim intCourseNumber As Integer = GridCourse.Rows(r).Cells(2).Value
        DS.Tables("tblCourses").Rows(r).Item(2) = intCourseNumber

        Dim intCourseUnits As Integer = GridCourse.Rows(r).Cells(3).Value
        DS.Tables("tblCourses").Rows(r).Item(3) = intCourseUnits
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Units = @units WHERE ID = @ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@coursename", strCourseName)
                cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber)
                cmd.Parameters.AddWithValue("@units", intCourseUnits)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblCourses").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Units = @units WHERE ID = @ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@coursename", strCourseName)
                cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber)
                cmd.Parameters.AddWithValue("@units", intCourseUnits)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblCourses").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
        End Select


    End Sub

    Private Sub GridCourse_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCourse.CellDoubleClick
        MenuOK_Click(sender, e) 'Return A COURSE

    End Sub

    Private Sub MenuOK_Click(sender As Object, e As EventArgs) Handles MenuOK.Click
        If GridCourse.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCourse.CurrentRow.Index
        Try
            intCourse = DS.Tables("tblCourses").Rows(r).Item(0)
            strCourse = DS.Tables("tblCourses").Rows(r).Item(1)
            intCourseNumber = DS.Tables("tblCourses").Rows(r).Item(2)
        Catch ex As Exception
            MsgBox("شماره درس؟", vbInformation, "توجه")
            intCourseNumber = 0
        End Try
        Me.Dispose()

    End Sub

    Private Sub MenuAddCourse_Click(sender As Object, e As EventArgs) Handles MenuAddCourse.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ComboBioProg.SelectedIndex = -1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("درس جديد به اين دوره آموزشي افزوده شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        If myansw = vbYes Then
            strCourse = InputBox("نام درس را وارد کنيد", "NexTerm", " درس جديد " & ComboBioProg.Text)
            If strCourse = "" Then
                Exit Sub
            Else
                intCourseNumber = Val(InputBox("شماره درس", "NexTerm", "123456789"))
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units) VALUES (@bioprogid, @coursename, @coursenumber, 2)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@bioprogid", ComboBioProg.SelectedValue)
                        cmd.Parameters.AddWithValue("@coursename", strCourse)
                        cmd.Parameters.AddWithValue("@coursenumber", Str(intCourseNumber))
                        Dim i As Integer
                        Try
                            i = cmd.ExecuteNonQuery()
                            MsgBox(" درس " & strCourse & " افزوده شد ", vbOKOnly, "نکسترم")
                            ComboBioProg_SelectedIndexChanged(sender, e)
                            GridCourse.Refresh()
                        Catch ex As Exception
                            MsgBox("error: " & ex.ToString)
                        End Try
                    Case "Access"
                        strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units) VALUES (@bioprogid, @coursename, @coursenumber, 2)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@bioprogid", ComboBioProg.SelectedValue)
                        cmd.Parameters.AddWithValue("@coursename", strCourse)
                        cmd.Parameters.AddWithValue("@coursenumber", Str(intCourseNumber))
                        Dim i As Integer
                        Try
                            i = cmd.ExecuteNonQuery()
                            MsgBox(" درس " & strCourse & " افزوده شد ", vbOKOnly, "نکسترم")
                            ComboBioProg_SelectedIndexChanged(sender, e)
                            GridCourse.Refresh()
                        Catch ex As Exception
                            MsgBox("error: " & ex.ToString)
                        End Try
                End Select

            End If
        End If

    End Sub

    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        Dim r As Integer = GridCourse.SelectedCells(0).RowIndex    'count from 0
        Dim c As Integer = GridCourse.SelectedCells(0).ColumnIndex 'count from 0
        If GridCourse.RowCount < 1 Then Exit Sub
        If r < 0 Or c < 0 Then Exit Sub
        Dim strValue As String = GridCourse(c, r).Value
        Try
            Select Case c
                Case 1 'Course Name
                    strValue = InputBox("نام جديد درس را وارد کنيد", "نکسترم", strValue)
                    If Trim(strValue) = "" Then Exit Sub
                    If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
                    Dim myansw As DialogResult = MsgBox("نام درس را به " & vbCrLf & strValue & vbCrLf & "تغيير مي دهيد؟", vbYesNo + vbDefaultButton2, "نکسترم: توجه: در حال ويرايش نام درس هستيد")
                    If myansw = vbNo Then Exit Sub
                    GridCourse(c, r).Value = strValue
                    WriteLOG(31)
                Case 2 ' Number
                    strValue = InputBox("شماره جديد درس را وارد کنيد", "نکسترم", strValue)
                    If Val(strValue) = 0 Then Exit Sub
                    GridCourse(c, r).Value = strValue
                    WriteLOG(32)
                Case 3 ' Unit
                    strValue = InputBox("تعداد واحد درس را وارد کنيد", "نکسترم", strValue)
                    If Val(strValue) = 0 Then Exit Sub
                    GridCourse(c, r).Value = strValue
                    WriteLOG(32)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG 'There is a similar SUB() in TermProgs_Form
            If Userx = "USER Faculty" Then intUser = 0
            Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
            Dim strUserID As Integer = intUser.ToString
            Dim strNickName As String = UserNickName
            Dim strClientName As String = LCase(Environment.MachineName)
            Dim strFrontEnd As String = LCase(strBuildInfo)
            Dim strLog As String = ""
            Select Case intActivity
                Case 31 : strLog = "crs? : " & strCourse
                Case 32 : strLog = "crs.nr/unt? : " & intCourseNumber.ToString
            End Select
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", strUserID)
                        cmdx.Parameters.AddWithValue("@nickname", strNickName)
                        cmdx.Parameters.AddWithValue("@clientname", strClientName)
                        cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                        cmdx.Parameters.AddWithValue("@strlog", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", strUserID)
                        cmdx.Parameters.AddWithValue("@nickname", strNickName)
                        cmdx.Parameters.AddWithValue("@clientname", strClientName)
                        cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                        cmdx.Parameters.AddWithValue("@strlog", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString) 'Do Nothing!
            End Try
        End If

    End Sub

    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        strCourse = ""
        intCourse = 0
        Me.Dispose()

    End Sub

End Class