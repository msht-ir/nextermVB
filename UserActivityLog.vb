Public Class UserActivityLog

    'FormLoad
    Private Sub UserActivityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.DataSource = DS.Tables("tblDepartments")
        ComboBox1.DisplayMember = "DEPT"
        ComboBox1.ValueMember = "ID"
        ComboBox1.SelectedValue = intUser

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
        For i As Integer = 0 To DS.Tables("tblTerms").Rows.Count - 1
            Menu_cboTerm.Items.Add(DS.Tables("tblTerms").Rows(i).Item(1))
        Next

        Dim boolENBL As Boolean = True
        Try
            Select Case Userx
                Case "USER Faculty"
                    If (UserAccessControls And (2 ^ 4)) = 0 Then boolENBL = False Else boolENBL = True 'Viewer mode for Faculty
                    Menu_ClearUserActivity.Enabled = boolENBL
                Case "USER Department"
                    Menu_ClearUserActivity.Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString, vbOKOnly, "گزارش خطا در اجراي نکسترم")
        End Try

    End Sub
    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        intDept = ComboBox1.SelectedValue
        RadioButton3.Checked = True
    End Sub


    ' User Activity
    Private Sub Menu_ReportUserActivity_Click(sender As Object, e As EventArgs) Handles Menu_ReportUserActivity.Click
        If Menu_cboSort.SelectedIndex = -1 Then MsgBox("نوع مرتب سازي را مشخص کنيد", vbOKOnly, "نکسترم") : Exit Sub
        ReportUserActivity(Menu_cboSort.SelectedIndex + 1)
    End Sub
    Private Sub ReportUserActivity(intSortType As Integer)
        If ((RadioButton3.Checked = True) And (ComboBox1.SelectedIndex < 0)) Then MsgBox("يک گروه از ليست انتخاب کنيد", vbOKOnly, "نکسترم") : Exit Sub
        Dim strFltr As String = ""
        DS.Tables("tblLogs").Clear()
        intDept = ComboBox1.SelectedValue

        strSQL = "SELECT DateTimex, UserID, NickName, ClientName, FrontEnd, strLog From xLog"
        If RadioButton1.Checked = True Then strFltr = "شامل: همه کاربران" & vbCrLf                                                                 'all users
        If RadioButton2.Checked = True Then strSQL = strSQL & " WHERE UserID=0" : strFltr = "شامل: کاربر دانشکده" & vbCrLf                         'usr faculty
        If RadioButton3.Checked = True Then strSQL = strSQL & " WHERE userID=" & intDept.ToString : strFltr = "شامل: يک گروه" & vbCrLf          'usr dept

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
    Private Sub Menu_ClearUserActivity_Click(sender As Object, e As EventArgs) Handles Menu_ClearUserActivity.Click
        Dim myansw As DialogResult = MsgBox("سوابق فعاليت کاربران پاک شود؟", vbYesNo, "نکسترم")
        If myansw = vbNo Then
            Exit Sub
        Else
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DASS.SelectCommand.CommandText = "Delete From xLog"
                        DASS.Fill(DS, "tblLogs") ' tbl Logs
                    Case "Access"
                        DAAC.SelectCommand.CommandText = "delete * From xLog"
                        DAAC.Fill(DS, "tblLogs") ' tbl Logs
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            'WriteLOG(12)
            'Menu_UserActivityLogs_Click(sender, e)
        End If


    End Sub


    ' Report Courses
    Private Sub Menu_ReportCourses_Click(sender As Object, e As EventArgs) Handles Menu_ReportCourses.Click
        strDept = ComboBox1.Text
        strTerm = Menu_cboTerm.Text
        Dim intProgLevel As Integer = Menu_cboLevel.SelectedIndex       '{Dop, Bsc, Msc, Md, Phd}
        Dim strProgLevel As String = Menu_cboLevel.Text
        Dim intCourseType As Integer = Menu_cboCourseType.SelectedIndex '{theor, exper}
        Dim strCourseType As String = Menu_cboCourseType.Text
        If Menu_cboTerm.SelectedIndex = -1 Then strTerm = "" Else strTerm = Menu_cboTerm.Text
        If RadioButton3.Checked = True Then intDept = ComboBox1.SelectedValue Else intDept = 0

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
        PrintLine(1, "<head><title>گزارش درس هاي ارايه شده</title>")
        PrintLine(1, "<style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<p style='color:green; font-family:tahoma; font-size:12px; text-align:center'>گزارش درس هاي ارايه شده</p><hr>")

        If strDept <> "" Then PrintLine(1, "<p style='color:steelblue; font-family:tahoma; font-size:12px'>فيلتر:</p>")
        If strDept <> "" Then PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'> گروه آموزشي: ", strDept, "</p>")
        If strTerm <> "" Then PrintLine(1, "<p style='color:darkgray; font-family:tahoma; font-size:12px'>", strTerm, "</p>")
        If strProgLevel <> "" Then PrintLine(1, "<p style='color:MediumPurple; font-family:tahoma; font-size:12px'> مقطع ", strProgLevel, "</p>")
        If strCourseType <> "" Then PrintLine(1, "<p style='color:royalblue; font-family:tahoma; font-size:12px'>", strCourseType, "</p><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'></p>")
        '//draw table
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>درس هاي ارايه شده به تفکيک دروه ها آموزشي در هريک از گروه ها</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>")

        Dim strTermName As String = ""
        Dim strEntryName As String = ""

        For i As Integer = 0 To DS.Tables("tblreportProgData").Rows.Count - 1
            If strTermName <> DS.Tables("tblreportProgData").Rows(i).Item(0) Then 'reached Next Term
                strTermName = DS.Tables("tblreportProgData").Rows(i).Item(0)
                PrintLine(1, "<tr><td>^</td></tr>")
                PrintLine(1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>")
            End If
            If strEntryName <> DS.Tables("tblreportProgData").Rows(i).Item(2) Then 'reached Next Entry
                strEntryName = DS.Tables("tblreportProgData").Rows(i).Item(2)
                PrintLine(1, "<tr><td>^</td></tr>")
                PrintLine(1, "<tr><th>گروه آموزشي</th><th>ترم</th><th>دوره آموزشي</th><th>ورودي</th><th>نام درس</th><th>شماره درس</th><th>واحد</th><th>گروه</th><th>يادداشت</th></tr>")
            End If
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
        Next i
        PrintLine(1, "</table><br>")
        ' //FOOTER
        PrintLine(1, "<br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "Nexterm_ReportCourses.html")

    End Sub



    ' EXIT
    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        DS.Tables("tblTerms").Clear()
        Me.Dispose()

    End Sub

End Class