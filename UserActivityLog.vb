Public Class UserActivityLog
    'FormLoad
    Private Sub UserActivityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboDepts.DataSource = DS.Tables("tblDepartments")
        cboDepts.DisplayMember = "DEPT"
        cboDepts.ValueMember = "ID"
        cboDepts.SelectedValue = intDept
        If intDept = 0 Then CheckBoxDepts.Checked = False

        Try
            DS.Tables("tblTerms").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM Terms WHERE Terms.Active = 1 ORDER BY Term"
                    DASS.Fill(DS, "tblTerms")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM Terms WHERE Terms.Active = True ORDER BY Term"
                    DAAC.Fill(DS, "tblTerms")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        cboTerms.DataSource = DS.Tables("tblterms")
        cboTerms.DisplayMember = "Term"
        cboTerms.ValueMember = "ID"

        Dim boolENBL As Boolean = True
        Try
            Select Case Userx
                Case "USER Faculty"
                    If (UserAccessControls And (2 ^ 4)) = 0 Then boolENBL = False Else boolENBL = True 'Viewer mode for Faculty
                    Radio5.Enabled = boolENBL
                Case "USER Department"
                    Radio5.Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString, vbOKOnly, "گزارش خطا در اجراي نکسترم")
        End Try

        Radio1.Focus()

    End Sub

    Private Sub CheckBoxDepts_CheckedChanged() Handles CheckBoxDepts.CheckedChanged
        If CheckBoxDepts.Checked = False Then
            intUser = cboDepts.SelectedValue
            cboDepts.SelectedValue = -1
        Else
            cboDepts.SelectedValue = intUser
        End If

    End Sub

    Private Sub cboDepts_Click(sender As Object, e As EventArgs) Handles cboDepts.Click
        Try
            CheckBoxDepts.Checked = True
            intUser = cboDepts.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    ' User Activity
    Private Sub Menu_ReportUserActivity_Click() Handles Menu_ReportUserActivity.Click
        If ((CheckBoxDepts.Checked = True) And (cboDepts.SelectedIndex < 0) And (CheckBoxFaculty.Checked = False)) Then MsgBox("يک گروه از ليست انتخاب کنيد", vbOKOnly, "نکسترم") : Exit Sub
        Dim intSortType As Integer = 0
        Dim strFltr As String = ""
        Dim x As Integer = 0

        If Radio5.Checked = True Then ClearUserActivity() : Exit Sub

        If Radio1.Checked = True Then intSortType = 1
        If Radio2.Checked = True Then intSortType = 2
        If Radio3.Checked = True Then intSortType = 3
        If Radio4.Checked = True Then intSortType = 4
        If intSortType = 0 Then Exit Sub

        DS.Tables("tblLogs").Clear()
        intDept = cboDepts.SelectedValue
        strDept = cboDepts.Text

        strSQL = "SELECT DateTimex, UserID, NickName, ClientName, FrontEnd, strLog From xLog"
        '//Add filter
        If CheckBoxDepts.Checked = True Then x = 1
        If CheckBoxFaculty.Checked = True Then x = x + 2
        Select Case x
            Case 3 : strFltr = "شامل: همه کاربران" & vbCrLf
            Case 2 : strSQL = strSQL & " WHERE UserID=0" : strFltr = "شامل: فقط کاربر دانشکده" & vbCrLf
            Case 1 : strSQL = strSQL & " WHERE userID=" & intDept.ToString : strFltr = "شامل: فقط يک گروه :" & strDept & " " & vbCrLf
            Case 0 : Exit Sub
        End Select
        '//Add order
        Select Case intSortType
            Case 1 : strSQL = strSQL & " ORDER BY DateTimex DESC" : strFltr = strFltr & " - " & "ترتيب: تاريخ و زمان"
            Case 2 : strSQL = strSQL & " ORDER BY UserID, DateTimex DESC" : strFltr = strFltr & " - " & "ترتيب: شناسه گروه"
            Case 3 : strSQL = strSQL & " ORDER BY ClientName, DateTimex DESC" : strFltr = strFltr & " - " & "ترتيب: سرويس گيرنده"
            Case 4 : strSQL = strSQL & " ORDER BY NickName, DateTimex DESC" : strFltr = strFltr & " - " & "ترتيب: نام مستعار"
        End Select
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = strSQL
                    DASS.Fill(DS, "tblLogs") ' tbl Logs
                Case "Access"
                    DAAC.SelectCommand.CommandText = strSQL
                    DAAC.Fill(DS, "tblLogs") ' tbl Logs
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FileOpen(1, Application.StartupPath & "Nexterm_log.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""ltr"">")
        PrintLine(1, "<head><title>فعاليت کاربران</title><style>table, th, td {border: 1px solid;} </style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:darkgray; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h4 style='color:green; font-family:tahoma; text-align: center'>Log for:  " & Server2Connect & "</h4>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>شناسه</th><th>نام گروه آموزشي</th></tr>")
        For i As Integer = 0 To DS.Tables("tblDepartments").Rows.Count - 1
            PrintLine(1, "<tr><td>", DS.Tables("tblDepartments").Rows(i).Item(0), "</td>")           ' 1 :id
            PrintLine(1, "<td>", DS.Tables("tblDepartments").Rows(i).Item(1), "</td></tr>")          ' 2 :DeptName
        Next
        PrintLine(1, "</table>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>فعاليت کاربران </p>")
        PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>" & strFltr & "</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>Date and Time</th><th>Client</th><th>FrontEnd</th><th>Nickname</th><th>usr</th><th>Operation</th></tr>")
        For i As Integer = 0 To DS.Tables("tblLogs").Rows.Count - 1
            PrintLine(1, "<tr><td>", DS.Tables("tblLogs").Rows(i).Item(0), "</td>")      ' Date/Time
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(3), "</td>")          ' clnt
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(4), "</td>")          ' fe
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(2), "</td>")          ' nck
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(1), "</td>")          ' usr
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(5), "</td></tr>")     ' activity
        Next i
        PrintLine(1, "</table>")
        ' //footer
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "Nexterm_log.html")

    End Sub

    Private Sub ClearUserActivity()
        Dim x As Integer = 0
        Dim strFltr As String = ""
        Dim strMsg As String = ""
        If CheckBoxDepts.Checked = True Then
            strDept = cboDepts.Text
            intDept = cboDepts.SelectedValue
        Else
            strDept = ""
            intDept = 0
        End If

        If CheckBoxDepts.Checked = True Then x = 1
        If CheckBoxFaculty.Checked = True Then x = x + 2
        Select Case x
            Case 3 : strFltr = "" : strMsg = "سوابق فعاليت همه کاربران پاک شود؟"
            Case 2 : strFltr = " WHERE userID=0" : strMsg = "سوابق فعاليت کاربر دانشکده پاک شود؟"
            Case 1 : strFltr = " WHERE UserID=" & intDept.ToString : strMsg = "سوابق فعاليت کاربر گروه  " & strDept & "  پاک شود؟  "
            Case 0 : Exit Sub
        End Select

        Dim myansw As DialogResult = MsgBox(strMsg, vbYesNo, "نکسترم")
        If myansw = vbNo Then
            Exit Sub
        Else
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS.SelectCommand.CommandText = "Delete From xLog" & strFltr
                        DASS.Fill(DS, "tblLogs") ' tbl Logs
                    Case "Access"
                        DAAC.SelectCommand.CommandText = "delete * From xLog" & strFltr
                        DAAC.Fill(DS, "tblLogs") ' tbl Logs
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            'WriteLOG(12)
        End If

        MsgBox("انجام شد", vbOKOnly, "نکسترم")
        Radio1.Checked = True
        'Menu_ReportUserActivity_Click()

    End Sub

    ' Report Courses
    Private Sub Menu_ReportCourses_Click() Handles Menu_ReportCourses.Click
        '//Report Courses
        If CheckBoxDepts.Checked = True Then
            strDept = cboDepts.Text
            intDept = cboDepts.SelectedValue
        Else
            strDept = ""
            intDept = 0
        End If
        strTerm = cboTerms.Text
        Dim intProgLevel As Integer = cboProglevel.SelectedIndex       '{Dop, Bsc, Msc, Md, Phd}
        Dim strProgLevel As String = cboProglevel.Text
        Dim intCourseType As Integer = cboCoursetype.SelectedIndex '{theor, exper}
        Dim strCourseType As String = cboCoursetype.Text
        If cboTerms.SelectedIndex = -1 Then strTerm = "" Else strTerm = cboTerms.Text

        Dim strFilter As String = ""
        If intDept > 0 Then strFilter = strFilter & " AND (Departments.ID = " & intDept.ToString & ")"
        If intCourseType >= 0 Then strFilter = strFilter & " AND ((CourseSpecs & " & (2 ^ intCourseType).ToString & ") = " & (2 ^ intCourseType).ToString & ")"
        If intProgLevel >= 0 Then strFilter = strFilter & " AND ((ProgramSpecs & " & (2 ^ intProgLevel).ToString & ") = " & (2 ^ intProgLevel).ToString & ")"
        If strTerm <> "" Then strFilter = strFilter & " AND (Terms.Term = '" & strTerm & "')"
        If strFilter = "" Then MsgBox("گروه آموزشي ويا ترم را مشخص کنيد", vbOKOnly, "نکسترم") : Exit Sub
        'MsgBox(strFilter)
        strFilter = " WHERE (1 = 1) " & strFilter
        DS.Tables("tblReportProgData").Clear()
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT Departments.DepartmentName, Terms.Term, BioProgs.ProgramName, Entries.EntYear, Courses.CourseName, Courses.CourseNumber, Units, [Group], TermProgs.Notes, ProgramSpecs, CourseSpecs FROM Courses INNER JOIN Entries INNER JOIN TermProgs ON  Entries.ID =  TermProgs.Entry_ID INNER JOIN Terms ON  TermProgs.Term_ID =  Terms.ID ON  Courses.ID =  TermProgs.Course_ID INNER JOIN BioProgs ON  Entries.BioProg_ID =  BioProgs.ID INNER JOIN Departments ON  BioProgs.Department_ID =  Departments.ID" & strFilter & " ORDER BY DepartmentName, Term, ProgramName, EntYear, CourseName, [Group]"
                    DASS.Fill(DS, "tblReportProgData")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT Departments.DepartmentName, Terms.Term, BioProgs.ProgramName, Entries.EntYear, Courses.CourseName, Courses.CourseNumber, Units, [Group], TermProgs.Notes, ProgramSpecs, CourseSpecs FROM Courses INNER JOIN Entries INNER JOIN TermProgs ON  Entries.ID =  TermProgs.Entry_ID INNER JOIN Terms ON  TermProgs.Term_ID =  Terms.ID ON  Courses.ID =  TermProgs.Course_ID INNER JOIN BioProgs ON  Entries.BioProg_ID =  BioProgs.ID INNER JOIN Departments ON  BioProgs.Department_ID =  Departments.ID" & strFilter & " ORDER BY DepartmentName, Term, ProgramName, EntYear, CourseName, [Group]"
                    DAAC.Fill(DS, "tblReportProgData")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        '0 Term, 1 DepartmentName, 2 ProgramName, 3 EntYear, 4 CourseName, 5 CourseNumber, 6 Units, 7 Group, 8 Note
        FileOpen(1, Application.StartupPath & "\Nexterm_ReportCourses.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""rtl"">")
        PrintLine(1, "<head><title>گزارش درس ها</title>")
        PrintLine(1, "<style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<p style='color:green; font-family:tahoma; font-size:12px; text-align:center'>گزارش درس هاي برنامه ريزي شده</p><hr>")

        PrintLine(1, "<p style='color:steelblue; font-family:tahoma; font-size:12px'>فيلتر:</p>")
        If strDept <> "" Then PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'> گروه آموزشي: ", strDept, "</p>")
        If strTerm <> "" Then PrintLine(1, "<p style='color:darkgray; font-family:tahoma; font-size:12px'>", strTerm, "</p>")
        If strProgLevel <> "" Then PrintLine(1, "<p style='color:MediumPurple; font-family:tahoma; font-size:12px'> مقطع ", strProgLevel, "</p>")
        If strCourseType <> "" Then PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>", strCourseType, "</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'></p><hr>")
        '//draw table
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>درس هاي برنامه ريزي شده به تفکيک دروه آموزشي در هر گروه</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>")

        Try
            Dim strTermName As String = DS.Tables("tblreportProgData").Rows(0).Item(0)
            Dim strEntryName As String = DS.Tables("tblreportProgData").Rows(0).Item(2)
            Dim intCounter4Term As Integer = 0
            Dim intUnits4Term As Integer = 0
            Dim intCounter4Entry As Integer = 0
            Dim intUnits4Entry As Integer = 0

            For i As Integer = 0 To DS.Tables("tblreportProgData").Rows.Count - 1
                If strEntryName <> DS.Tables("tblreportProgData").Rows(i).Item(2) Then 'reached Next Entry
                    strEntryName = DS.Tables("tblreportProgData").Rows(i).Item(2)      'change  Next Entry
                    PrintLine(1, "<tr><td>^</td><td>" & intCounter4Entry & ":" & intUnits4Entry & "</td></tr>")
                    intCounter4Entry = 0 : intUnits4Entry = 0
                End If
                If strTermName <> DS.Tables("tblreportProgData").Rows(i).Item(0) Then 'reached Next Term
                    strTermName = DS.Tables("tblreportProgData").Rows(i).Item(0)      'change  Next Term
                    PrintLine(1, "<tr><td>^</td><td>" & intCounter4Term & ":" & intUnits4Term & "</td></tr>")
                    PrintLine(1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>")
                    intCounter4Term = 0 : intUnits4Term = 0
                End If
lbl_continue:
                PrintLine(1, "<tr>")
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(0), "</td>")   ' 0 term
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(1), "</td>")   ' 1
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(2), "</td>")   ' 2
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(3), "</td>")   ' 3
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(4), "</td>")   ' 4
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(5), "</td>")   ' 5
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(6), "</td>")   ' 6
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(7), "</td>")   ' 7
                PrintLine(1, "<td>", DS.Tables("tblReportProgData").Rows(i).Item(8), "</td>")   ' 8 notes
                PrintLine(1, "</tr>")
                intCounter4Entry = intCounter4Entry + 1 : intUnits4Entry = intUnits4Entry + DS.Tables("tblReportProgData").Rows(i).Item(6)
                intCounter4Term = intCounter4Term + 1 : intUnits4Term = intUnits4Term + DS.Tables("tblReportProgData").Rows(i).Item(6)
            Next i

            PrintLine(1, "<tr><td>^</td><td>" & intCounter4Entry & ":" & intUnits4Entry & "</td></tr>")
            PrintLine(1, "<tr><td>^</td><td>" & intCounter4Term & ":" & intUnits4Term & "</td></tr>")
            PrintLine(1, "</table><br>")
            'Filter reprint
            PrintLine(1, "<p style='color:steelblue; font-family:tahoma; font-size:12px'>فيلتر - يادآوري:</p>")
            If strDept <> "" Then PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'> گروه آموزشي: ", strDept, "</p>")
            If strTerm <> "" Then PrintLine(1, "<p style='color:darkgray; font-family:tahoma; font-size:12px'>", strTerm, "</p>")
            If strProgLevel <> "" Then PrintLine(1, "<p style='color:MediumPurple; font-family:tahoma; font-size:12px'> مقطع ", strProgLevel, "</p>")
            If strCourseType <> "" Then PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>", strCourseType, "</p>")

            ' //FOOTER
            PrintLine(1, "<br><hr>")
            PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
            PrintLine(1, "</body></html>")
            FileClose(1)
            Shell("explorer.exe " & Application.StartupPath & "Nexterm_ReportCourses.html")
        Catch ex As Exception
            FileClose(1)
            Exit Sub
        End Try

    End Sub

    ' EXIT
    Private Sub Menu_Exit_Click() Handles Menu_Exit.Click
        DS.Tables("tblTerms").Clear()
        Me.Dispose()

    End Sub

End Class