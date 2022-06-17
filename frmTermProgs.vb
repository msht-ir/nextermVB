
Public Class frmTermProgs
    '//expand: Ctrl+M+L  / collaps: Ctrl+M+O 

    'Form Load
    Private Sub frmTermProgs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Text = "NexTerm  |  " & Userx & "  Connected to :  " & Server2Connect
            ComboBox1.DataSource = DS.Tables("tblDepartments")
            ComboBox1.DisplayMember = "DEPT"
            ComboBox1.ValueMember = "ID"
            ComboBox1.SelectedValue = intUser

            GridWeek.Rows.Add("ش")
            GridWeek.Rows.Add("ی")
            GridWeek.Rows.Add("د")
            GridWeek.Rows.Add("س")
            GridWeek.Rows.Add("چ")
            GridWeek.Rows.Add("پ")

            GridTime.Rows.Add("شنبه")
            GridTime.Rows.Add("یکشنبه")
            GridTime.Rows.Add("دوشنبه")
            GridTime.Rows.Add("سه شنبه")
            GridTime.Rows.Add("چهارشنبه")
            GridTime.Rows.Add("پنجشنبه")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        For i = 0 To 8
            GridWeek.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            GridTime.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

        EnableMenu()

    End Sub
    Private Sub EnableMenu()
        Try
            Dim boolENBL As Boolean
            Select Case Userx
                Case "USER Faculty"
                    boolENBL = True
                    Menu_Courses.Enabled = True
                    Menu_Staff.Enabled = True
                    Menu_Tech.Enabled = True
                    Menu_ReProgram_ThisEnteryTerm.Enabled = True
                    Menu_ReProgram_ThisEnteryTerm_inclStaff.Enabled = True
                    Menu_ChangePass.Enabled = True

                Case "USER Department" ' Userx: Department | quit
                    boolENBL = False
                    If ComboBox1.SelectedValue > 0 Then
                        If (UserAccessConntrols And (2 ^ 0)) = 0 Then Menu_Courses.Enabled = False Else Menu_Courses.Enabled = True
                        If (UserAccessConntrols And (2 ^ 1)) = 0 Then Menu_Staff.Enabled = False Else Menu_Staff.Enabled = True
                        If (UserAccessConntrols And (2 ^ 1)) = 0 Then Menu_Tech.Enabled = False Else Menu_Tech.Enabled = True
                        If (UserAccessConntrols And (2 ^ 3)) = 0 Then Menu_ReProgram_ThisEnteryTerm.Enabled = False Else Menu_ReProgram_ThisEnteryTerm.Enabled = True
                        If (UserAccessConntrols And (2 ^ 3)) = 0 Then Menu_ReProgram_ThisEnteryTerm_inclStaff.Enabled = False Else Menu_ReProgram_ThisEnteryTerm_inclStaff.Enabled = True
                        If (UserAccessConntrols And (2 ^ 4)) = 0 Then Menu_ChangePass.Enabled = False Else Menu_ChangePass.Enabled = True
                    End If
            End Select

            Menu_Settings.Enabled = boolENBL

            Menu_Classes.Enabled = boolENBL
            Menu_Terms.Enabled = boolENBL

            Menu_Delete_Entry_TermProg.Enabled = boolENBL
            Menu_UserActivityLog_CLEAR.Enabled = boolENBL

            Menu_ReportStaffPrograms.Enabled = False
            Menu_ReportTechPrograms.Enabled = False
            Menu_ReportEntriesPrograms.Enabled = False

            If (Userx = "USER Faculty") And (AdminCanProg = False) Then ContextMenuGrid4.Enabled = False Else ContextMenuGrid4.Enabled = True
            CheckMessages()

        Catch ex As Exception
            MsgBox(ex.ToString, vbOKOnly, "گزارش خطا در اجراي نکسترم")
        End Try

    End Sub
    Private Sub CheckMessages()
        DS.Tables("tblMSgs").Clear()
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "Select ID, SentDate As [زمان ارسال], usrFrom As [از طرف], usrTo As [به], usrTo_ID, msgString As [يادداشت], IsActive As [جديد] FROM msgs WHERE usrTo_ID=" & intUser.ToString & " AND IsActive = 1"
                    DASS.Fill(DS, "tblMsgs")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT ID, SentDate As [زمان ارسال], usrFrom As [از طرف], usrTo As [به], usrTo_ID, msgString As [يادداشت], IsActive As [جديد] FROM msgs WHERE usrTo_ID=" & intUser.ToString & " AND IsActive = True"
                    DAAC.Fill(DS, "tblMsgs")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        If DS.Tables("tblMsgs").Rows.Count > 0 Then
            Dim myansw As DialogResult = MsgBox("يادداشت هايتان را اکنون مي بينيد؟", vbYesNo, "نکسترم")
            If myansw = vbYes Then frmShowNotes.ShowDialog()
        End If

    End Sub
    Private Sub ClrForm()
        ' Clear ListBox 1 , 2 :Entries, Terms
        DS.Tables("tblEntries").Clear()
        ComboBox1.SelectedIndex = -1
        ComboBox1.SelectedValue = intUser
        'ListBox1.SelectedIndex = -1
        DS.Tables("tblTerms").Clear()
        ListBox2.SelectedValue = -1
        ListBox2.SelectedIndex = -1
        Grid4.DataSource = ""
        lblWeek.Visible = False
        txtExamDate.Text = ""
        GridWeek.Hide()
        GridTime_Hide()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        '//ComboBox1(=Departments) : populates ListBox1(=Entries)
        If Userx = "quit" Then Exit Sub

        ' Clear Grid4 :Term_Prog data
        Menu_EntryProg_AllTerms.Enabled = False
        Grid4.DataSource = ""
        txtExamDate.Text = ""
        GridTime_Hide()

        DS.Tables("tblEntries").Clear()
        DS.Tables("tblTerms").Clear()

        Dim i As String = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        Try
            If (Userx = "USER Department") And (ComboBox1.SelectedValue <> intUser) Then Exit Sub
            If (Userx = "USER Department") And (DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(2)) = False Then Exit Sub ' check if department is active  //  Item(2):DepartmentActive
            'READ (from DB) the Entries of the selected Department
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT Entries.ID AS EntID, CONCAT(EntYear , ' - ' , ProgramName) As Prog, BioProg_ID FROM ((BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID) INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) WHERE Department_ID =" & i.ToString & " AND Active = 1 ORDER BY EntYear, ProgramName"
                    DASS.Fill(DS, "tblEntries")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT Entries.ID AS EntID, EntYear & ' - ' & ProgramName As Prog, BioProg_ID FROM ((BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID) INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) WHERE Department_ID =" & i.ToString & " AND Active = True ORDER BY EntYear, ProgramName"
                    DAAC.Fill(DS, "tblEntries")
            End Select

            ' Populate ListBox1(the Entries)
            ListBox1.DataSource = DS.Tables("tblEntries")
            ListBox1.DisplayMember = "Prog"
            ListBox1.ValueMember = "EntID"
            ListBox1.Refresh()
            ListBox1.SelectedIndex = -1
            ListBox1.SelectedValue = 0

            ' Clear ListBox2(the Terms)
            ListBox2.DataSource = Nothing
            ListBox2.Refresh()
            ListBox2.SelectedIndex = -1
            ListBox2.SelectedValue = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ListBox1_Entries(sender As Object, e As EventArgs) Handles ListBox1.Click
        Dim i As String = ListBox1.GetItemText(ListBox1.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        Menu_EntryProg_AllTerms.Enabled = True
        Try
            DS.Tables("tblTerms").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Select Case Userx
                        Case "USER Department" ' show active terms
                            If DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(8) <> True Then
                                DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" & i.ToString & " AND Terms.[Active] = 1 ORDER BY Term"
                            Else
                                DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" & i.ToString & " ORDER BY Term"
                            End If
                            DASS.Fill(DS, "tblTerms")
                        Case "USER Faculty" ' show all terms
                            DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" & i.ToString & " ORDER BY Term"
                            DASS.Fill(DS, "tblTerms")
                    End Select

                Case "Access"
                    Select Case Userx
                        Case "USER Department" ' show active terms
                            If DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(8) <> True Then
                                DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" & i.ToString & " AND Terms.[Active] = True ORDER BY Term"
                            Else
                                DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" & i.ToString & " ORDER BY Term"
                            End If
                            DAAC.Fill(DS, "tblTerms")
                        Case "USER Faculty" ' show all terms
                            DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Entries.ID =" & i.ToString & " ORDER BY Term"
                            DAAC.Fill(DS, "tblTerms")
                    End Select

            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ListBox2.DataSource = DS.Tables("tblTerms")
        ListBox2.DisplayMember = "Term"
        ListBox2.ValueMember = "ID"
        ListBox2.Refresh()
        ListBox2.SelectedIndex = -1
        ListBox2.SelectedValue = 0

        Grid4.DataSource = ""
        txtExamDate.Text = ""
        GridTime_Hide()
    End Sub
    Private Sub ListBox2_Terms(sender As Object, e As EventArgs) Handles ListBox2.Click
        Dim Ent As String = ListBox1.GetItemText(ListBox1.SelectedValue)
        Dim Trm As String = ListBox2.GetItemText(ListBox2.SelectedValue)
        If Val(Ent) = 0 Then Exit Sub
        If Val(Trm) = 0 Then Exit Sub

        ' Check if (Term Active?) OR (User Faculty?)
        Dim boolActiveTerm As Boolean = DS.Tables("tblTerms").Rows(ListBox2.SelectedIndex).Item(2)
        DS.Tables("tblTermProgs").Clear()
        If (Userx = "USER Department") And (boolActiveTerm = False) And (DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(8) <> True) Then
            MsgBox("ويرايش برنامه اين ترم فعال نشده است", vbInformation, "NexTerm")
            Exit Sub
        End If

        Grid4.DataBindings.Clear()
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName AS [درس], Units, [Group] AS [گ], Staff_ID, Staff.StaffName AS [استاد], Tech_ID, Technecians.StaffName AS [کارشناس], SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName AS [کلاس1], SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName AS [کلاس2], Capacity AS [ت], ExamDate, TermProgs.Notes AS [يادداشت]  FROM ((((((Rooms Rooms_1 RIGHT OUTER JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT OUTER JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT OUTER JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT OUTER JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT OUTER JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT OUTER JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) WHERE Term_ID = " & Trm.ToString & " AND Entry_ID = " & Ent.ToString & " ORDER BY CourseName, [Group]"
                    DASS.Fill(DS, "tblTermProgs")

                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName AS [درس], Units, [Group] AS [گ], Staff_ID, Staff.StaffName AS [استاد], Tech_ID, Technecians.StaffName AS [کارشناس], SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName AS [کلاس1], SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName AS [کلاس2], Capacity AS [ت], ExamDate, TermProgs.Notes AS [يادداشت] FROM ((((((Rooms Rooms_1 RIGHT OUTER JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT OUTER JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT OUTER JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT OUTER JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT OUTER JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT OUTER JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) WHERE Term_ID = " & Trm.ToString & " AND Entry_ID = " & Ent.ToString & " ORDER BY CourseName, [Group]"
                    DAAC.Fill(DS, "tblTermProgs")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Grid4.DataSource = DS.Tables("tblTermProgs")
        Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' hide some cols
        Grid4.Columns(0).Visible = False    ' ID
        Grid4.Columns(1).Visible = False    ' Course ID
        Grid4.Columns(2).Visible = False    ' Course Name
        Grid4.Columns(6).Visible = False    ' Staff ID
        Grid4.Columns(8).Visible = False    ' Tech ID
        Grid4.Columns(10).Visible = False   ' SAT 1
        Grid4.Columns(11).Visible = False   ' SUN 1
        Grid4.Columns(12).Visible = False   ' MON 1
        Grid4.Columns(13).Visible = False   ' TUE 1
        Grid4.Columns(14).Visible = False   ' WED 1
        Grid4.Columns(15).Visible = False   ' THR 1
        Grid4.Columns(16).Visible = False   ' Room 1
        Grid4.Columns(18).Visible = False   ' SAT 2
        Grid4.Columns(19).Visible = False   ' SUN 2
        Grid4.Columns(20).Visible = False   ' MON 2
        Grid4.Columns(21).Visible = False   ' TUE 2
        Grid4.Columns(22).Visible = False   ' WED 2
        Grid4.Columns(23).Visible = False   ' THR 2
        Grid4.Columns(24).Visible = False   ' Room 2
        Grid4.Columns(27).Visible = False   ' ExamDate

        Grid4.Columns(3).Width = 200    'CourseName
        Grid4.Columns(4).Width = 25     'Units
        Grid4.Columns(5).Width = 20     'Group
        Grid4.Columns(7).Width = 125    'StaffName
        Grid4.Columns(9).Width = 105    'TechName
        Grid4.Columns(17).Width = 100   'Room1Name
        Grid4.Columns(25).Width = 75    'Room2Name
        Grid4.Columns(26).Width = 32    'Capacity
        Grid4.Columns(28).Width = 180   'Note

        txtExamDate.Text = ""
        GridTime_Hide()
        GridWeek_Show()

        For i = 0 To Grid4.Columns.Count - 1
            Grid4.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

    End Sub

    Private Sub Menu_EntryProg_AllTerms_Click(sender As Object, e As EventArgs) Handles Menu_EntryProg_AllTerms.Click
        'Show all TermProgs for this Entry (all Terms)
        Dim Ent As String = ListBox1.GetItemText(ListBox1.SelectedValue)
        Dim Trm As String = ListBox2.GetItemText(ListBox2.SelectedValue)
        If Val(Ent) = 0 Then Exit Sub
        strEntry = ListBox1.Text
        Try
            DS.Tables("tblAllProgs").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Entry_ID = " & Ent.ToString & ") ORDER BY Term, THR1, WED1, TUE1, MON1, SUN1, SAT1"
                    DASS.Fill(DS, "tblAllProgs")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Entry_ID = " & Ent.ToString & ") ORDER BY Term, THR1, WED1, TUE1, MON1, SUN1, SAT1"
                    DAAC.Fill(DS, "tblAllProgs")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '======================================================================= PRINT
        FileOpen(1, Application.StartupPath & "\Nexterm_Entry.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""rtl"">")
        PrintLine(1, "<head><title>برنامه ورودي</title>")
        PrintLine(1, "<style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h1 style='color:blue; text-align:center'>", strEntry, "</h1>")
        PrintLine(1, "<h2 style='color:Green; text-align:center'>برنامه ترميک</h2>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه ترميک اين ورودي</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")

        Dim strTermName As String = ""
        For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
            If strTermName <> DS.Tables("tblAllProgs").Rows(i).Item(30) Then 'reached Next Term
                strTermName = DS.Tables("tblAllProgs").Rows(i).Item(30)
                PrintLine(1, "<tr><td>^</td></tr>")
                PrintLine(1, "<tr><th>ترم</th><th>شماره</th><th>گ</th><th>نام درس</th><th>واحد</th><th>نام مدرس</th><th>يادداشت</th></tr>")
            End If
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(30), "</td>")  ' 30 :Term
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(2), "</td>")   ' 2  :CourseNumber
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(5), "</td>")   ' 5  :Group
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(3), "</td>")   ' 3  :CourseName
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(4), "</td>")   ' 4  :Unit
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(7), "</td>")   ' 7  :Staff
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(28), "</td>")  ' 28 :Note
            PrintLine(1, "</tr>")
        Next i
        PrintLine(1, "</table><br>")

        ' //FOOTER
        PrintLine(1, "<br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm program, Faculty of Science, SKU. Developer: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "Nexterm_Entry.html")

    End Sub

    ' GridWeek
    Private Sub GridWeek_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridWeek.CellClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            strEntry = ListBox1.Text
            strTerm = ListBox2.Text
            Dim r As Integer = e.RowIndex 'count from 0
            Dim c As Integer = e.ColumnIndex 'count from 0
            If r < 0 Or c < 0 Then Exit Sub
            Dim strTadakholMessage As String = ""
            If Val(GridWeek(c, r).Value) > 0 Then
                For i As Integer = 0 To DS.Tables("tblTermProgs").Rows.Count - 1
                    If ((DS.Tables("tblTermProgs").Rows(i).Item(r + 10) And (2 ^ (c - 1))) = (2 ^ (c - 1))) Or ((DS.Tables("tblTermProgs").Rows(i).Item(r + 18) And (2 ^ (c - 1))) = (2 ^ (c - 1))) Then
                        strTadakholMessage = strTadakholMessage & DS.Tables("tblTermProgs").Rows(i).Item(3) & "    گروه:  " & DS.Tables("tblTermProgs").Rows(i).Item(5) & vbCrLf & " استاد: " & DS.Tables("tblTermProgs").Rows(i).Item(7) & vbCrLf & vbCrLf
                    End If
                Next
                MsgBox(strTadakholMessage, vbOKOnly, "نکسترم")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub MenuGreedWeekReport_Click(sender As Object, e As EventArgs) Handles MenuGreedWeekReport.Click
        ListBox2_Terms(sender, e) ' //enforce  GridWeek_Show() in ListBox2:Terms
        Shell("explorer.exe " & Application.StartupPath & "Nexterm_EntryTerm.html")
    End Sub
    Private Sub GridWeek_Show()
        Dim Ent As String = ListBox1.GetItemText(ListBox1.SelectedValue)
        Dim Trm As String = ListBox2.GetItemText(ListBox2.SelectedValue)
        If Val(Ent) = 0 Then Exit Sub
        If Val(Trm) = 0 Then Exit Sub

        ' Clear GridWeek
        For c As Integer = 1 To 8 ' cols are day_times
            For r As Integer = 0 To 5 ' rows are week_days
                GridWeek(c, r).Value = ""
                GridWeek(c, r).Style.ForeColor = Color.Black
            Next r
        Next c
        GridWeek.Visible = True
        lblWeek.Visible = True

        Dim intTimeFlag(5, 7) As Integer ' (r:5days, c:7times)

        ' Grid4.Cols:  6=SAT ... 11=THR
        Dim strTadakhol As String = ""
        Dim TadakholExists As Boolean = False

        strEntry = ListBox1.Text
        strTerm = ListBox2.Text

        strTadakhol = strTadakhol & "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>"
        strTadakhol = strTadakhol & "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th></tr>"

        For intThisCourse As Integer = 0 To DS.Tables("tblTermProgs").Rows.Count - 1
            For intTime As Integer = 0 To 7 ' for each time of day
                For intDay As Integer = 0 To 5
                    If (DS.Tables("tblTermProgs").Rows(intThisCourse).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime) Then ' if time[2^0] is set //item(10):SAT1
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridWeek(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblTermProgs").Rows(intThisCourse).Item(1) & "</td><td>" & DS.Tables("tblTermProgs").Rows(intThisCourse).Item(5) & "</td></tr>" & vbCrLf : TadakholExists = True
                    End If
                    If (DS.Tables("tblTermProgs").Rows(intThisCourse).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime) Then ' if time[2^0] is set //item(18):SAT2
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridWeek(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblTermProgs").Rows(intThisCourse).Item(1) & "</td><td>" & DS.Tables("tblTermProgs").Rows(intThisCourse).Item(5) & "</td></tr>" & vbCrLf : TadakholExists = True
                    End If
                Next intDay
            Next intTime
        Next intThisCourse
        strTadakhol = strTadakhol & "</table>"

        '======================================================================= OPEN Week()
        FileOpen(1, Application.StartupPath & "\Nexterm_EntryTerm.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""rtl"">")
        PrintLine(1, "<head><title>برنامه ورودي</title>")
        PrintLine(1, "<style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align:center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h1 style='color:blue; text-align:center'>", strEntry, "</h1>")
        PrintLine(1, "<h2 style='color:Green; text-align:center'>", strTerm, "</h2><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>تداخل در برنامه<br></p>")

        ' draw table1: strTadakhol (html)
        If TadakholExists = True Then PrintLine(1, strTadakhol)
        PrintLine(1, "<br><hr>")

        ' draw table2: TermProg (html)
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه آموزشي</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>شماره</th>")
        PrintLine(1, "<th>گ</th>")
        PrintLine(1, "<th>نام درس</th>")
        PrintLine(1, "<th>واحد</th>")
        PrintLine(1, "<th>نام مدرس</th>")
        PrintLine(1, "<th>کارشناس</th>")
        PrintLine(1, "<th>ش</th>")
        PrintLine(1, "<th>ي</th>")
        PrintLine(1, "<th>د</th>")
        PrintLine(1, "<th>س</th>")
        PrintLine(1, "<th>چ</th>")
        PrintLine(1, "<th>پ</th>")
        PrintLine(1, "<th>امتحان</th>")
        PrintLine(1, "<th>کلاس1</th>")
        PrintLine(1, "<th>کلاس2</th>")
        PrintLine(1, "<th>ظرفيت</th>")
        PrintLine(1, "<th>يادداشت</th></tr>")

        For i As Integer = 0 To DS.Tables("tblTermProgs").Rows.Count - 1
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(2), "</td>")   ' 2 :CourseNumber
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(5), "</td>")   ' 5 :Group
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(3), "</td>")   ' 3 :CourseName
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(4), "</td>")   ' 4 :Unit
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(7), "</td>")   ' 7 :Staff
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(9), "</td>")   ' 9 :Tech

            For intday As Integer = 0 To 5
                Dim x As String = ""
                For intTime As Integer = 0 To 7
                    If (DS.Tables("tblTermProgs").Rows(i).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime) Then
                        x = x & strTime(intTime) & "<br>" ' Time
                    End If
                    If (DS.Tables("tblTermProgs").Rows(i).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime) Then
                        x = x & strTime(intTime) & "<br>" ' Time
                    End If
                Next intTime
                PrintLine(1, "<td>", x, "</td>") ' Time
            Next intday

            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(27), "</td>") ' 27:Exam
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(17), "</td>") ' 17:Class1
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(25), "</td>") ' 25:Class2
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(26), "</td>") ' 26:Capacity
            PrintLine(1, "<td>", DS.Tables("tblTermProgs").Rows(i).Item(28), "</td>") ' 28:Notes
            PrintLine(1, "</tr>")
        Next i
        PrintLine(1, "</table><br><hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>")

        ' Draw 3rd Table: Free-Times
        Dim strTableTag As String = ""

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")

        PrintLine(1, "<tr>")
        PrintLine(1, "<th>روز</th>")
        PrintLine(1, "<th>08:30</th>")
        PrintLine(1, "<th>09:30</th>")
        PrintLine(1, "<th>10:30</th>")
        PrintLine(1, "<th>11:30</th>")
        PrintLine(1, "<th>13:30</th>")
        PrintLine(1, "<th>14:30</th>")
        PrintLine(1, "<th>15:30</th>")
        PrintLine(1, "<th>16:30</th>")
        PrintLine(1, "</tr>")

        For d As Integer = 0 To 5
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>" & strDay(d) & "</th>")
            For i As Integer = 1 To 8
                If Val(GridWeek(i, d).Value) > 1 Then
                    strTableTag = "<td style=text-align:center;background-color:yellow;>"
                ElseIf Val(GridWeek(i, d).Value) = 1 Then
                    strTableTag = "<td style=text-align:center;background-color:white;>"
                Else
                    strTableTag = "<td style=text-align:center;>"
                End If
                PrintLine(1, strTableTag, GridWeek(i, d).Value, "</td>") ' 08:30-16:30
            Next i
            PrintLine(1, "</tr>")
        Next d
        PrintLine(1, "</table>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")

        ' // table of Exams dates for GridWeek
        DS.Tables("tblTermExams").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt, Entry_ID FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & Trm.ToString & " AND Entry_ID = " & Ent.ToString & " ORDER BY ExamDate"
                DASS.Fill(DS, "tblTermExams")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, [ProgramName] & ' - ' & [Entyear] AS strEnt, Entry_ID FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & Trm.ToString & " AND Entry_ID = " & Ent.ToString & " ORDER BY ExamDate"
                DAAC.Fill(DS, "tblTermExams")
        End Select

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
        PrintLine(1, "برنامه امتحانات")
        PrintLine(1, "</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr>")
        PrintLine(1, "<th>تاريخ</th><th>درس</th><th>استاد</th></tr>")
        For i As Integer = 0 To DS.Tables("tblTermExams").Rows.Count - 1
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>", DS.Tables("tblTermExams").Rows(i).Item(1), "</td>")  ' 1 :Exam
            PrintLine(1, "<td>", DS.Tables("tblTermExams").Rows(i).Item(2), "</td>")  ' 2 :Course
            PrintLine(1, "<td>", DS.Tables("tblTermExams").Rows(i).Item(5), "</td>")  ' 5 :Staff
            PrintLine(1, "</tr>")
        Next
        PrintLine(1, "</table>")

        ' //FOOTER
        PrintLine(1, "<br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm computer program, Faculty of Science, SKU. Developed by: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
        PrintLine(1, "</body></html>")

        FileClose(1)

        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                If Val(GridWeek(c, r).Value) > 1 Then GridWeek(c, r).Style.ForeColor = Color.Red
            Next r
        Next c

        GridWeek.Visible = True
        lblWeek.Visible = True

    End Sub

    ' Grid4
    Private Sub Grid4_CellDblClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid4.CellDoubleClick
        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = e.RowIndex 'count from 0
        Dim c As Integer = e.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub

        'FILL DATA in WeekTable// 
        Dim rx As Integer = Grid4.CurrentRow.Index
        'Grid4.Col  10=SAT 15=THR
        For intTime As Integer = 0 To 7
            For intday As Integer = 0 To 5
                If ((DS.Tables("tblTermProgs").Rows(rx).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Or ((DS.Tables("tblTermProgs").Rows(rx).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then
                    tblThisCourseTime.Rows(intday).Item(intTime) = "1"
                Else
                    tblThisCourseTime.Rows(intday).Item(intTime) = "0"
                End If
            Next intday
        Next intTime
        '//FILL DATA in WeekTable


        Select Case c'SELECT BASED ON GRID.COLUMN
            Case 3 'Course
                If (Userx = "USER Faculty") And (AdminCanProg = False) Then
                    MsgBox("قابليت (برنامه ريزي) براي (کاربر دانشکده) غير فعال است", vbInformation, "تنظيمات نکسترم")
                    Exit Sub
                End If

                intDept = ComboBox1.GetItemText(ComboBox1.SelectedValue)
                intBioProg = DS.Tables("tblEntries").Rows(ListBox1.SelectedIndex).Item(2)
                intCourse = DS.Tables("tblTermProgs").Rows(r).Item(1)
                ChooseCourse.ShowDialog()
                If strCourse = "" Then Exit Sub
                Dim myansw As DialogResult = MsgBox("در برنامه اين ترم، درس " & vbCrLf & vbCrLf & strCourse & vbCrLf & vbCrLf & "جايگزين درس فعلي شود؟", vbYesNo + vbDefaultButton2, "نکسترم")
                If myansw = vbNo Then Exit Sub

                DS.Tables("tblTermProgs").Rows(r).Item(3) = strCourse
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TermProgs SET Course_ID = @courseid WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TermProgs SET Course_ID = @courseid WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                End Select
                WriteLOG(7)


            Case 7 'Staff
                If (Userx = "USER Faculty") And (AdminCanProg = False) Then
                    MsgBox("قابليت (برنامه ريزي) براي (کاربر دانشکده) غير فعال است", vbInformation, "تنظيمات نکسترم")
                    Exit Sub
                End If

                intDept = ComboBox1.SelectedValue
                ChooseStaff.ShowDialog()
                Dim z As DialogResult
                If strStaff = "" Then
                    z = MsgBox("نام استاد براي اين درس حذف شود؟", vbYesNo, "Confirm:")
                    If z = vbNo Then Exit Sub
                End If
                DS.Tables("tblTermProgs").Rows(r).Item(7) = strStaff
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TermProgs SET Staff_ID = @staffid WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffid", Val(intStaff))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TermProgs SET Staff_ID = @staffid WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffid", Val(intStaff))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                End Select

            Case 5 'Group
                If (Userx = "USER Faculty") And (AdminCanProg = False) Then
                    MsgBox("قابليت (برنامه ريزي) براي (کاربر دانشکده) غير فعال است", vbInformation, "تنظيمات نکسترم")
                    Exit Sub
                End If

                Dim grp As Integer = DS.Tables("tblTermProgs").Rows(r).Item(5)
                grp = Val(InputBox("شماره گروه", "NexTerm", grp))
                DS.Tables("tblTermProgs").Rows(r).Item(5) = grp
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TermProgs SET [Group] = @Grp WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@Grp", grp)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TermProgs SET [Group] = @Grp WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@Grp", grp)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                End Select


            Case 9 'Tech
                If (Userx = "USER Faculty") And (AdminCanProg = False) Then
                    MsgBox("قابليت (برنامه ريزي) براي (کاربر دانشکده) غير فعال است", vbInformation, "تنظيمات نکسترم")
                    Exit Sub
                End If

                ChooseTech.ShowDialog()
                If strTech = "" Then
                    Dim z As DialogResult
                    z = MsgBox("نام کارشناس براي اين درس حذف شود؟", vbYesNo, "Confirm:")
                    If z = vbNo Then Exit Sub
                End If
                DS.Tables("tblTermProgs").Rows(r).Item(9) = strTech
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TermProgs SET Tech_ID = @techid WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@techid", Val(intTech))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()

                    Case "Access"
                        strSQL = "UPDATE TermProgs SET Tech_ID = @techid WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@techid", Val(intTech))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()

                End Select

            Case 26 'Capacity
                Dim cp As Integer
                Try
                    cp = DS.Tables("tblTermProgs").Rows(r).Item(26)
                Catch
                    cp = 0
                Finally
                    cp = Val(InputBox("Change Capacity > ", "NexTerm", cp.ToString))
                    DS.Tables("tblTermProgs").Rows(r).Item(26) = cp
                End Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TermProgs SET Capacity = @Capa WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@Capa", cp)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TermProgs SET Capacity = @Capa WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@Capa", cp)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select

            Case 17, 25 'Room1, Room2 /////////////////////////////////////////////////////////////////////////////////////
                If DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(7) <> True Then
                    MsgBox("تعيين کلاس اکنون (غير فعال) است", vbInformation, "تنظيمات نکسترم")
                    Exit Sub
                End If
                Try
                    intTerm = ListBox2.SelectedValue
                    intRoom = DS.Tables("tblTermProgs").Rows(r).Item(c - 1) 'IDs: 16=Room1, 24=Room2 
                    intGridRow = Grid4.CurrentRow.Index
                    Select Case c
                        Case 17 : Roomx = 1
                        Case 25 : Roomx = 2
                    End Select
                    ChooseClass.ShowDialog()
                    If strRoom = "" Then Exit Sub
                Catch ex As Exception
                    MsgBox("Error: Try Again!" & vbCrLf & ex.ToString, vbOKOnly, "NexTerm")
                End Try

                'save returned data
                DS.Tables("tblTermProgs").Rows(r).Item(c) = strRoom
                Dim i As Integer
                Select Case c
                    Case 17 ' Room1
                        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "UPDATE TermProgs SET SAT1=@sat1, SUN1=@sun1, MON1=@mon1, TUE1=@tue1, WED1=@wed1, THR1=@thr1, Room1 = @room1 WHERE ID = @ID"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@sat1", Val(intClass1DayData(0)))
                                cmd.Parameters.AddWithValue("@sun1", Val(intClass1DayData(1)))
                                cmd.Parameters.AddWithValue("@mon1", Val(intClass1DayData(2)))
                                cmd.Parameters.AddWithValue("@tue1", Val(intClass1DayData(3)))
                                cmd.Parameters.AddWithValue("@wed1", Val(intClass1DayData(4)))
                                cmd.Parameters.AddWithValue("@thr1", Val(intClass1DayData(5)))
                                cmd.Parameters.AddWithValue("@room1", Val(intRoom))
                                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                                i = cmd.ExecuteNonQuery()
                            Case "Access"
                                strSQL = "UPDATE TermProgs SET SAT1=@sat1, SUN1=@sun1, MON1=@mon1, TUE1=@tue1, WED1=@wed1, THR1=@thr1, Room1 = @room1 WHERE ID = @ID"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@sat1", Val(intClass1DayData(0)))
                                cmd.Parameters.AddWithValue("@sun1", Val(intClass1DayData(1)))
                                cmd.Parameters.AddWithValue("@mon1", Val(intClass1DayData(2)))
                                cmd.Parameters.AddWithValue("@tue1", Val(intClass1DayData(3)))
                                cmd.Parameters.AddWithValue("@wed1", Val(intClass1DayData(4)))
                                cmd.Parameters.AddWithValue("@thr1", Val(intClass1DayData(5)))
                                cmd.Parameters.AddWithValue("@room1", Val(intRoom))
                                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                                i = cmd.ExecuteNonQuery()
                        End Select

                    Case 25 ' Room2
                        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "UPDATE TermProgs SET SAT2=@sat2, SUN2=@sun2, MON2=@mon2, TUE2=@tue2, WED2=@wed2, THR2=@thr2, Room2 = @room2 WHERE ID = @ID"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@sat2", Val(intClass2DayData(0)))
                                cmd.Parameters.AddWithValue("@sun2", Val(intClass2DayData(1)))
                                cmd.Parameters.AddWithValue("@mon2", Val(intClass2DayData(2)))
                                cmd.Parameters.AddWithValue("@tue2", Val(intClass2DayData(3)))
                                cmd.Parameters.AddWithValue("@wed2", Val(intClass2DayData(4)))
                                cmd.Parameters.AddWithValue("@thr2", Val(intClass2DayData(5)))
                                cmd.Parameters.AddWithValue("@room2", Val(intRoom))
                                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                                i = cmd.ExecuteNonQuery()
                            Case "Access"
                                strSQL = "UPDATE TermProgs SET SAT2=@sat2, SUN2=@sun2, MON2=@mon2, TUE2=@tue2, WED2=@wed2, THR2=@thr2, Room2 = @room2 WHERE ID = @ID"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@sat2", Val(intClass2DayData(0)))
                                cmd.Parameters.AddWithValue("@sun2", Val(intClass2DayData(1)))
                                cmd.Parameters.AddWithValue("@mon2", Val(intClass2DayData(2)))
                                cmd.Parameters.AddWithValue("@tue2", Val(intClass2DayData(3)))
                                cmd.Parameters.AddWithValue("@wed2", Val(intClass2DayData(4)))
                                cmd.Parameters.AddWithValue("@thr2", Val(intClass2DayData(5)))
                                cmd.Parameters.AddWithValue("@room2", Val(intRoom))
                                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                                i = cmd.ExecuteNonQuery()
                        End Select
                End Select ' //Save Data

            Case 28 'Notes
                Dim strNote As String = ""
                Try
                    strNote = DS.Tables("tblTermProgs").Rows(r).Item(28)
                Catch
                    strNote = ""
                Finally
                    strNote = InputBox("يادداشت ", "نکسترم", strNote.ToString)
                    DS.Tables("tblTermProgs").Rows(r).Item(28) = strNote
                End Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TermProgs SET Notes = @notes WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@notes", strNote)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TermProgs SET Notes = @notes WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@notes", strNote)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select

        End Select
        ListBox2_Terms(sender, e)

    End Sub
    Private Sub Grid4_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid4.CellClick
        For cl As Integer = 1 To 8
            For rw As Integer = 0 To 5
                GridTime(cl, rw).Value = ""
                GridTime(cl, rw).Style.ForeColor = Color.Black
                GridTime(cl, rw).Style.BackColor = Color.White
            Next rw
        Next cl

        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid4.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = Grid4.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Then Exit Sub
        If Grid4.Item(c, r).Value Is Nothing OrElse IsDBNull(Grid4.Item(c, r).Value) Then Exit Sub

        intTerm = ListBox2.SelectedValue
        strTerm = ListBox2.Text

        Select Case c
            Case 3
                strCaption = "Course"
                strCourse = Grid4.Item(c, r).Value
                GridTime_ShowCourse() 'codes in this form (me)
            Case 7
                strCaption = "Staff"
                intStaff = DS.Tables("tblTermProgs").Rows(r).Item(6)
                strStaff = Grid4.Item(c, r).Value
                GridTime_ShowStaff() 'in this form (me)
            Case 9
                strCaption = "Tech"
                intTech = DS.Tables("tblTermProgs").Rows(r).Item(8)
                strTech = Grid4.Item(c, r).Value
                GridTime_ShowTech() 'in this form (me)
            Case 17
                strCaption = "Room"
                Roomx = 1
                If DS.Tables("tblTermProgs").Rows(r).Item(16) Is Nothing OrElse IsDBNull(DS.Tables("tblTermProgs").Rows(r).Item(16)) Then DS.Tables("tblTermProgs").Rows(r).Item(16) = 0
                intRoom = DS.Tables("tblTermProgs").Rows(r).Item(16)
                strRoom = Grid4.Item(c, r).Value
                GridTime_ShowRoom() 'in this form (me)
            Case 25
                strCaption = "Room"
                Roomx = 2
                If DS.Tables("tblTermProgs").Rows(r).Item(24) Is Nothing OrElse IsDBNull(DS.Tables("tblTermProgs").Rows(r).Item(24)) Then DS.Tables("tblTermProgs").Rows(r).Item(24) = 0
                intRoom = DS.Tables("tblTermProgs").Rows(r).Item(24)
                strRoom = Grid4.Item(c, r).Value
                GridTime_ShowRoom() 'in this form (me)
            Case Else
                Exit Sub
        End Select

    End Sub

    ' GridTime
    Private Sub GridTime_ShowCourse()
        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                GridTime(c, r).Value = ""
            Next r
        Next c
        GridTime.Visible = True
        lblCourse.Visible = True
        lblCourse.Text = "برنامه هفتگي درس " & strCourse
        txtExamDate.Visible = True
        lblExamDate.Visible = True
        RadioBtn1.Visible = True
        RadioBtn2.Visible = True
        RadioBtn1.Checked = -1
        Dim ri As Integer = Grid4.SelectedCells(0).RowIndex
        If DS.Tables("tblTermProgs").Rows(ri).Item(27) Is Nothing OrElse IsDBNull(DS.Tables("tblTermProgs").Rows(ri).Item(27)) Then
            txtExamDate.Text = ""
        Else
            txtExamDate.Text = DS.Tables("tblTermProgs").Rows(ri).Item(27)
        End If
        MenuGridTimeReport.Enabled = False
        PopMenu_SaveWeek.Enabled = True
        Dim rx As Integer = Grid4.CurrentRow.Index
        'Grid4.Col  10=SAT 15=THR
        For intTime As Integer = 0 To 7
            For intday As Integer = 0 To 5
                If ((DS.Tables("tblTermProgs").Rows(rx).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Or ((DS.Tables("tblTermProgs").Rows(rx).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then
                    GridTime(intTime + 1, intday).Value = strTime(intTime)
                End If
            Next intday
        Next intTime
        GridWeek.Visible = True
        lblWeek.Visible = True
        HilightGridTime()

    End Sub
    Private Sub GridTime_ShowStaff()
        'Clear the GridTime
        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                GridTime(c, r).Value = ""
                GridTime(c, r).Style.ForeColor = Color.Black
                GridTime(c, r).Style.BackColor = Color.White
            Next r
        Next c

        GridTime.Visible = True
        lblCourse.Visible = True
        lblCourse.Text = "برنامه هفتگي استاد " & strStaff
        txtExamDate.Visible = False
        lblExamDate.Visible = False
        RadioBtn1.Visible = False
        RadioBtn2.Visible = False
        MenuGridTimeReport.Enabled = True
        PopMenu_SaveWeek.Enabled = False

        DS.Tables("tblAllProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                DASS.Fill(DS, "tblAllProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                DAAC.Fill(DS, "tblAllProgs")
        End Select

        Dim intTimeFlag(5, 7) As Integer ' (r:days, c:times //begins from 0)
        Dim strTadakhol As String = ""
        Dim TadakholExists As Boolean = False

        strTadakhol = strTadakhol & "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>"
        strTadakhol = strTadakhol & "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th></tr>"
        For intTime As Integer = 0 To 7 ' for each time of day
            For intDay As Integer = 0 To 5 'each day
                For intThisStaff As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                    If (DS.Tables("tblAllProgs").Rows(intThisStaff).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime) Then
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(5) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(29) & "</td></tr>" & vbCrLf : TadakholExists = True
                    End If
                    If (DS.Tables("tblAllProgs").Rows(intThisStaff).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime) Then
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(5) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(29) & "</td></tr>" & vbCrLf : TadakholExists = True
                    End If
                Next intThisStaff
            Next intDay
        Next intTime
        strTadakhol = strTadakhol & "</table>"

        '=======================================================================OPEN Staff()
        FileOpen(1, Application.StartupPath & "Nexterm_Staff.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""rtl"">")
        PrintLine(1, "<head><title>برنامه استاد</title><style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")

        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h1 style='color:red; text-align: center'>", strStaff, "</h1>")
        PrintLine(1, "<h2 style='color:Green; text-align: center'>", strTerm, "</h2><hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
        If TadakholExists = True Then
            PrintLine(1, "تداخل در برنامه", "<br></p>")
            PrintLine(1, strTadakhol)
            PrintLine(1, "<br><hr>")
        End If

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه استاد</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>شماره</th>")
        PrintLine(1, "<th>گ</th>")
        PrintLine(1, "<th>نام درس</th>")
        PrintLine(1, "<th>واحد</th>")
        PrintLine(1, "<th>نام مدرس</th>")
        PrintLine(1, "<th>کارشناس</th>")
        PrintLine(1, "<th>ش</th>")
        PrintLine(1, "<th>ي</th>")
        PrintLine(1, "<th>د</th>")
        PrintLine(1, "<th>س</th>")
        PrintLine(1, "<th>چ</th>")
        PrintLine(1, "<th>پ</th>")
        PrintLine(1, "<th>امتحان</th>")
        PrintLine(1, "<th>کلاس1</th>")
        PrintLine(1, "<th>کلاس2</th>")
        PrintLine(1, "<th>ظرفيت</th>")
        PrintLine(1, "<th>يادداشت</th>")
        PrintLine(1, "<th>ورودي</th></tr>")

        For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(2), "</td>")   ' 2 :CourseNumber
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(5), "</td>")   ' 5 :Group
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(3), "</td>")   ' 3 :CourseName
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(4), "</td>")   ' 4 :Unit
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(7), "</td>")   ' 7 :Staff
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(9), "</td>")   ' 9 :Tech

            For intday As Integer = 0 To 5
                Dim x As String = ""
                For intTime As Integer = 0 To 7
                    If ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Or ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then
                        x = x & strTime(intTime) & "<br>" ' Time
                    End If
                Next intTime
                PrintLine(1, "<td>", x, "</td>") ' Time
            Next intday

            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(27), "</td>") ' 27:Exam
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(17), "</td>") ' 17:Class1
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(25), "</td>") ' 25:Class2
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(26), "</td>") ' 26:Capacity
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(28), "</td>") ' 28:Notes
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(29), "</td>") ' 29:Ent
            PrintLine(1, "</tr>")
        Next i
        PrintLine(1, "</table><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>")
        'Draw 3rd Table: Weekly
        Dim strTableTag As String = ""

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>روز</th>")
        PrintLine(1, "<th>08:30</th>")
        PrintLine(1, "<th>09:30</th>")
        PrintLine(1, "<th>10:30</th>")
        PrintLine(1, "<th>11:30</th>")
        PrintLine(1, "<th>13:30</th>")
        PrintLine(1, "<th>14:30</th>")
        PrintLine(1, "<th>15:30</th>")
        PrintLine(1, "<th>16:30</th></tr>")

        For d As Integer = 0 To 5
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>" & strDay(d) & "</th>")
            For i As Integer = 1 To 8
                If Val(GridTime(i, d).Value) > 1 Then
                    strTableTag = "<td style=text-align:center;background-color:yellow;>"
                ElseIf Val(GridTime(i, d).Value) = 1 Then
                    strTableTag = "<td style=text-align:center;background-color:white;>"
                Else
                    strTableTag = "<td style=text-align:center;>"
                End If
                PrintLine(1, strTableTag, GridTime(i, d).Value, "</td>") ' 08:30-16:30
            Next i
            PrintLine(1, "</tr>")
        Next d
        PrintLine(1, "</table>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><hr>")

        ' // table of Exams dates for Staff
        DS.Tables("tblTermExams").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY ExamDate"
                DASS.Fill(DS, "tblTermExams")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, [ProgramName] & ' - ' & [Entyear] AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY ExamDate"
                DAAC.Fill(DS, "tblTermExams")
        End Select
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه امتحانات</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>تاريخ</th>")
        PrintLine(1, "<th>درس</th>")
        PrintLine(1, "<th>ورودي</th></tr>")
        For i As Integer = 0 To DS.Tables("tblTermExams").Rows.Count - 1
            PrintLine(1, "<tr><td>", DS.Tables("tblTermExams").Rows(i).Item(1), "</td>")  ' 1 :Exam
            PrintLine(1, "<td>", DS.Tables("tblTermExams").Rows(i).Item(2), "</td>")      ' 2 :Course
            PrintLine(1, "<td>", DS.Tables("tblTermExams").Rows(i).Item(7), "</td></tr>") ' 7 :Entry string
        Next
        PrintLine(1, "</table>")

        ' //footer
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm computer program, Faculty of Science, SKU. Developed by: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)

        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                If Val(GridTime(c, r).Value) > 1 Then
                    GridTime(c, r).Style.ForeColor = Color.Red
                End If
            Next r
        Next c
        HilightGridTime()
    End Sub
    Private Sub GridTime_ShowTech()
        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                GridTime(c, r).Value = ""
                GridTime(c, r).Style.ForeColor = Color.Black
                GridTime(c, r).Style.BackColor = Color.White
            Next r
        Next c

        GridTime.Visible = True
        lblCourse.Visible = True
        lblCourse.Text = "برنامه هفتگي کارشناس " & strTech
        txtExamDate.Visible = False
        lblExamDate.Visible = False
        RadioBtn1.Visible = False
        RadioBtn2.Visible = False
        MenuGridTimeReport.Enabled = True
        PopMenu_SaveWeek.Enabled = False

        DS.Tables("tblAllProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Tech_ID = " & intTech.ToString & " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                DASS.Fill(DS, "tblAllProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Tech_ID = " & intTech.ToString & " ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                DAAC.Fill(DS, "tblAllProgs")
        End Select

        Dim intTimeFlag(5, 7) As Integer ' (r:days, c:times //begins from 0)
        Dim strTadakhol As String = ""
        Dim TadakholExists As Boolean = False

        strTadakhol = strTadakhol & "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>"
        strTadakhol = strTadakhol & "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>ورودي</th></tr>"
        For intTime As Integer = 0 To 7 ' for each time of day
            For intDay As Integer = 0 To 5
                For intThisStaff As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                    If (DS.Tables("tblAllProgs").Rows(intThisStaff).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime) Then
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(29) & "</td></tr>" & vbCrLf : TadakholExists = True
                    End If
                    If (DS.Tables("tblAllProgs").Rows(intThisStaff).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime) Then
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisStaff).Item(29) & "</td></tr>" & vbCrLf : TadakholExists = True
                    End If
                Next intThisStaff
            Next intDay
        Next intTime
        strTadakhol = strTadakhol & "</table>"

        '=======================================================================OPEN Staff()
        FileOpen(1, Application.StartupPath & "Nexterm_Tech.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""rtl"">")
        PrintLine(1, "<head><title>برنامه کارشناس</title><style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")

        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h1 style='color:red; text-align: center'>", strTech, "</h1>")
        PrintLine(1, "<h2 style='color:Green; text-align: center'>", strTerm, "</h2><hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
        PrintLine(1, "تداخل در برنامه", "<br></p>")

        If TadakholExists = True Then PrintLine(1, strTadakhol)
        PrintLine(1, "<br><hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه استاد</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>شماره</th>")
        PrintLine(1, "<th>گ</th>")
        PrintLine(1, "<th>نام درس</th>")
        PrintLine(1, "<th>واحد</th>")
        PrintLine(1, "<th>نام مدرس</th>")
        PrintLine(1, "<th>کارشناس</th>")
        PrintLine(1, "<th>ش</th>")
        PrintLine(1, "<th>ي</th>")
        PrintLine(1, "<th>د</th>")
        PrintLine(1, "<th>س</th>")
        PrintLine(1, "<th>چ</th>")
        PrintLine(1, "<th>پ</th>")
        PrintLine(1, "<th>امتحان</th>")
        PrintLine(1, "<th>کلاس1</th>")
        PrintLine(1, "<th>کلاس2</th>")
        PrintLine(1, "<th>ظرفيت</th>")
        PrintLine(1, "<th>يادداشت</th>")
        PrintLine(1, "<th>ورودي</th></tr>")

        For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(2), "</td>")   ' 2 :CourseNumber
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(5), "</td>")   ' 5 :Group
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(3), "</td>")   ' 3 :CourseName
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(4), "</td>")   ' 4 :Unit
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(7), "</td>")   ' 7 :Staff
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(9), "</td>")   ' 9 :Tech

            For intday As Integer = 0 To 5
                Dim x As String = ""
                For intTime As Integer = 0 To 7
                    If ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Or ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then
                        x = x & strTime(intTime) & "<br>" ' Time
                    End If
                Next intTime
                PrintLine(1, "<td>", x, "</td>") ' Time
            Next intday

            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(27), "</td>") ' 27:Exam
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(17), "</td>") ' 17:Class1
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(25), "</td>") ' 25:Class2
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(26), "</td>") ' 26:Capacity
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(28), "</td>") ' 28:Notes
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(29), "</td>") ' 29:Ent
            PrintLine(1, "</tr>")
        Next i
        PrintLine(1, "</table><br><hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>")
        'Draw 3rd Table: Weekly
        Dim strTableTag As String = ""

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>روز</th>")
        PrintLine(1, "<th>08:30</th>")
        PrintLine(1, "<th>09:30</th>")
        PrintLine(1, "<th>10:30</th>")
        PrintLine(1, "<th>11:30</th>")
        PrintLine(1, "<th>13:30</th>")
        PrintLine(1, "<th>14:30</th>")
        PrintLine(1, "<th>15:30</th>")
        PrintLine(1, "<th>16:30</th></tr>")

        For d As Integer = 0 To 5
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>" & strDay(d) & "</th>")
            For i As Integer = 1 To 8
                If Val(GridTime(i, d).Value) > 1 Then
                    strTableTag = "<td style=text-align:center;background-color:yellow;>"
                ElseIf Val(GridTime(i, d).Value) = 1 Then
                    strTableTag = "<td style=text-align:center;background-color:white;>"
                Else
                    strTableTag = "<td style=text-align:center;>"
                End If
                PrintLine(1, strTableTag, GridTime(i, d).Value, "</td>") ' 08:30-16:30
            Next i
            PrintLine(1, "</tr>")
        Next d
        PrintLine(1, "</table>")

        ' //footer
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm computer program, Faculty of Science, SKU. Developed by: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)

        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                If Val(GridTime(c, r).Value) > 1 Then
                    GridTime(c, r).Style.ForeColor = Color.Red
                End If
            Next r
        Next c
        HilightGridTime()

    End Sub
    Private Sub GridTime_ShowRoom()
        For c As Integer = 1 To 8
            For r As Integer = 0 To 5
                GridTime(c, r).Value = ""
                GridTime(c, r).Style.ForeColor = Color.Black
                GridTime(c, r).Style.BackColor = Color.White
            Next r
        Next c

        GridTime.Visible = True
        lblCourse.Visible = True
        lblCourse.Text = "برنامه هفتگي " & strRoom
        txtExamDate.Visible = False
        lblExamDate.Visible = False
        RadioBtn1.Visible = False
        RadioBtn2.Visible = False
        MenuGridTimeReport.Enabled = True
        PopMenu_SaveWeek.Enabled = False

        DS.Tables("tblAllProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE ((Term_ID = " & intTerm.ToString & ") AND ((Room1 = " & intRoom.ToString & ") OR (Room2 = " & intRoom.ToString & "))) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                DASS.Fill(DS, "tblAllProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE ((Term_ID = " & intTerm.ToString & ") AND ((Room1 = " & intRoom.ToString & ") OR (Room2 = " & intRoom.ToString & "))) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                DAAC.Fill(DS, "tblAllProgs")
        End Select
        Dim intTimeFlag(5, 7) As Integer ' (r:days, c:times //begins from 0)
        Dim strTadakhol As String = ""
        Dim TadakholExists As Boolean = False

        strTadakhol = strTadakhol & "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>"
        strTadakhol = strTadakhol & "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th><th>استاد</th></tr>"
        Try
            For intTime As Integer = 0 To 7 ' for each time of day
                For intDay As Integer = 0 To 5
                    For intThisRoom As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                        If ((DS.Tables("tblAllProgs").Rows(intThisRoom).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime)) And (DS.Tables("tblAllProgs").Rows(intThisRoom).Item(16) = intRoom) Then
                            intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                            GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                            If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(5) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(29) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(7) & "</td></tr>" & vbCrLf : TadakholExists = True
                        End If
                        'If IsDBNull(DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24)) Then DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24) = 0
                        If (((DS.Tables("tblAllProgs").Rows(intThisRoom).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime))) And (Val(DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24)) = intRoom) Then
                            intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                            GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                            If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(5) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(29) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(7) & "</td></tr>" & vbCrLf : TadakholExists = True
                        End If
                    Next intThisRoom
                Next intDay
            Next intTime
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        strTadakhol = strTadakhol & "</table>"

        '=======================================================================OPEN Staff()
        FileOpen(1, Application.StartupPath & "Nexterm_class.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""rtl"">")
        PrintLine(1, "<head><title>برنامه کلاس/آز</title><style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")

        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h1 style='color:red; text-align: center'>", strRoom, "</h1>")
        PrintLine(1, "<h2 style='color:Green; text-align: center'>", strTerm, "</h2><hr>")


        If TadakholExists = True Then
            PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
            PrintLine(1, "تداخل در برنامه", "<br></p>")
            PrintLine(1, strTadakhol)
            PrintLine(1, "<br><hr>")
        End If

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه کلاس</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>شماره</th>")
        PrintLine(1, "<th>گ</th>")
        PrintLine(1, "<th>نام درس</th>")

        PrintLine(1, "<th>واحد</th>")
        PrintLine(1, "<th>نام مدرس</th>")
        PrintLine(1, "<th>کارشناس</th>")
        PrintLine(1, "<th>ش</th>")
        PrintLine(1, "<th>ي</th>")
        PrintLine(1, "<th>د</th>")
        PrintLine(1, "<th>س</th>")
        PrintLine(1, "<th>چ</th>")
        PrintLine(1, "<th>پ</th>")
        PrintLine(1, "<th>امتحان</th>")
        PrintLine(1, "<th>کلاس1</th>")
        PrintLine(1, "<th>کلاس2</th>")
        PrintLine(1, "<th>ظرفيت</th>")
        PrintLine(1, "<th>يادداشت</th>")
        PrintLine(1, "<th>ورودي</th></tr>")

        For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(2), "</td>")   ' 2 :CourseNumber
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(5), "</td>")   ' 5 :Group
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(3), "</td>")   ' 3 :CourseName
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(4), "</td>")   ' 4 :Unit
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(7), "</td>")   ' 7 :Staff
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(9), "</td>")   ' 9 :Tech

            For intday As Integer = 0 To 5
                Dim x As String = ""
                For intTime As Integer = 0 To 7
                    If ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Or ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then
                        x = x & strTime(intTime) & "<br>" ' Time
                    End If
                Next intTime
                PrintLine(1, "<td>", x, "</td>") ' Time
            Next intday

            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(27), "</td>") ' 25:Exam
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(17), "</td>") ' 17:Class1
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(25), "</td>") ' 25:Class2
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(26), "</td>") ' 26:Capacity
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(28), "</td>") ' 28:Notes
            PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(29), "</td>") ' 29:Ent
            PrintLine(1, "</tr>")
        Next i
        PrintLine(1, "</table><br><hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>ساعت هاي آزاد</p>")
        'Draw 3rd Table: Weekly
        Dim strTableTag As String = ""

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>روز</th>")
        PrintLine(1, "<th>08:30</th>")
        PrintLine(1, "<th>09:30</th>")
        PrintLine(1, "<th>10:30</th>")
        PrintLine(1, "<th>11:30</th>")
        PrintLine(1, "<th>13:30</th>")
        PrintLine(1, "<th>14:30</th>")
        PrintLine(1, "<th>15:30</th>")
        PrintLine(1, "<th>16:30</th></tr>")

        For d As Integer = 0 To 5
            PrintLine(1, "<tr>")
            PrintLine(1, "<td>" & strDay(d) & "</th>")
            For i As Integer = 1 To 8
                'If GridTime(i, d).Style.BackColor = Color.LightBlue Then
                If Val(GridTime(i, d).Value) > 1 Then
                    strTableTag = "<td style=text-align:center;background-color:yellow;>"
                ElseIf Val(GridTime(i, d).Value) = 1 Then
                    strTableTag = "<td style=text-align:center;background-color:white;>"
                Else
                    strTableTag = "<td style=text-align:center;>"
                End If
                PrintLine(1, strTableTag, GridTime(i, d).Value, "</td>") ' 08:30-16:30
                'End If
            Next i
            PrintLine(1, "</tr>")
        Next d
        PrintLine(1, "</table>")

        ' //footer
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm computer program, Faculty of Science, SKU. Developed by: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)

        For intTime As Integer = 1 To 8
            For intDay As Integer = 0 To 5
                If Val(GridTime(intTime, intDay).Value) > 1 Then GridTime(intTime, intDay).Style.ForeColor = Color.Red
            Next intDay
        Next intTime

        HilightGridTime()
    End Sub
    Private Sub HilightGridTime()
        Select Case strCaption
            Case "Room"
                For intTime As Integer = 0 To 7
                    For intday As Integer = 0 To 5
                        GridTime(intTime + 1, intday).Style.BackColor = Color.White
                        Select Case Roomx
                            Case 1 : If ((DS.Tables("tblTermProgs").Rows(Grid4.CurrentRow.Index).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Then GridTime(intTime + 1, intday).Style.BackColor = Color.LightCyan
                            Case 2 : If ((DS.Tables("tblTermProgs").Rows(Grid4.CurrentRow.Index).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then GridTime(intTime + 1, intday).Style.BackColor = Color.MistyRose
                        End Select
                    Next intday
                Next intTime
            Case Else
                For intTime As Integer = 0 To 7
                    For intday As Integer = 0 To 5
                        GridTime(intTime + 1, intday).Style.BackColor = Color.White
                        If ((DS.Tables("tblTermProgs").Rows(Grid4.CurrentRow.Index).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Then GridTime(intTime + 1, intday).Style.BackColor = Color.LightCyan
                        If ((DS.Tables("tblTermProgs").Rows(Grid4.CurrentRow.Index).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then GridTime(intTime + 1, intday).Style.BackColor = Color.MistyRose
                    Next intday
                Next intTime

        End Select

        GridTime.CurrentCell = GridTime(0, 0)
    End Sub

    Private Sub MenuGridTimeReport_Click(sender As Object, e As EventArgs) Handles MenuGridTimeReport.Click
        'OPEN REPORT inHTML
        Select Case strCaption
            Case "Staff"
                Shell("explorer.exe " & Application.StartupPath & "Nexterm_Staff.html")
            Case "Tech"
                Shell("explorer.exe " & Application.StartupPath & "Nexterm_Tech.html")
            Case "Room"
                Shell("explorer.exe " & Application.StartupPath & "Nexterm_Class.html")
        End Select

    End Sub
    Private Sub GridTime_Hide()
        GridTime.Visible = False
        lblCourse.Visible = False
        txtExamDate.Visible = False
        lblExamDate.Visible = False
        RadioBtn1.Visible = False
        RadioBtn2.Visible = False
        GridWeek.Visible = False
        lblWeek.Visible = False

    End Sub
    Private Sub GridTime_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridTime.CellClick
        Try
            strEntry = ListBox1.Text
            strTerm = ListBox2.Text
            Dim r As Integer = GridTime.CurrentCell.RowIndex    'count from 0
            Dim c As Integer = GridTime.CurrentCell.ColumnIndex 'count from 0
            Dim strColor As String = "lightCyan"
            Select Case Grid4.CurrentCell.ColumnIndex
                Case 17 : Roomx = 1
                Case 25 : Roomx = 2
            End Select
            If r < 0 Or c < 0 Then Exit Sub

            Select Case strCaption
                Case "Course" ' --------------- course --------------- course --------------- course --------------- course ---------------
                    If (Userx = "USER Faculty") And (AdminCanProg = False) Then Exit Sub
                    If RadioBtn2.Checked = True Then strColor = "MistyRose"
                    If GridTime.Item(c, r).Value = "" Then
                        Select Case c
                            Case 1 : GridTime.Item(c, r).Value = "08:30"
                            Case 2 : GridTime.Item(c, r).Value = "09:30"
                            Case 3 : GridTime.Item(c, r).Value = "10:30"
                            Case 4 : GridTime.Item(c, r).Value = "11:30"
                            Case 5 : GridTime.Item(c, r).Value = "13:30"
                            Case 6 : GridTime.Item(c, r).Value = "14:30"
                            Case 7 : GridTime.Item(c, r).Value = "15:30"
                            Case 8 : GridTime.Item(c, r).Value = "16:30"
                        End Select
                        If RadioBtn1.Checked = True Then GridTime(c, r).Style.BackColor = Color.LightCyan Else GridTime(c, r).Style.BackColor = Color.MistyRose
                    Else
                        If c <> 0 Then
                            GridTime.Item(c, r).Value = ""
                            GridTime(c, r).Style.BackColor = Color.White
                        End If
                    End If
                    GridTime.CurrentCell = GridTime(0, r)



                Case "Staff" '-------------- staff ----------------- staff ----------------- staff ----------------- staff -----------------
                    Try
                        Dim strTadakholMessage As String = ""
                        If Val(GridTime(c, r).Value) > 0 Then
                            For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                                If ((DS.Tables("tblAllProgs").Rows(i).Item(r + 10) And (2 ^ (c - 1))) = (2 ^ (c - 1))) Or ((DS.Tables("tblAllProgs").Rows(i).Item(r + 18) And (2 ^ (c - 1))) = (2 ^ (c - 1))) Then
                                    strTadakholMessage = strTadakholMessage & " درس " & DS.Tables("tblAllProgs").Rows(i).Item(3) & vbCrLf & " ورودي " & DS.Tables("tblAllProgs").Rows(i).Item(29) & vbCrLf & DS.Tables("tblAllProgs").Rows(i).Item(17) & "   " & DS.Tables("tblAllProgs").Rows(i).Item(25) & vbCrLf & vbCrLf & vbCrLf
                                End If
                            Next
                            MsgBox(strTadakholMessage, vbOKOnly, "نکسترم")
                            GridTime.CurrentCell = GridTime(0, r)
                        End If
                    Catch ex As Exception
                        MsgBox("err")
                    End Try

                Case "Tech" ' ----------------- tech ----------------- tech ----------------- tech ----------------- tech -----------------
                    Try
                        Dim strTadakholMessage As String = ""
                        If Val(GridTime(c, r).Value) > 0 Then
                            For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                                If ((DS.Tables("tblAllProgs").Rows(i).Item(r + 10) And (2 ^ (c - 1))) = (2 ^ (c - 1))) Or ((DS.Tables("tblAllProgs").Rows(i).Item(r + 18) And (2 ^ (c - 1))) = (2 ^ (c - 1))) Then
                                    strTadakholMessage = strTadakholMessage & " درس " & DS.Tables("tblAllProgs").Rows(i).Item(3) & vbCrLf & " استاد: " & DS.Tables("tblAllProgs").Rows(i).Item(7) & vbCrLf & " ورودي " & DS.Tables("tblAllProgs").Rows(i).Item(29) & vbCrLf & vbCrLf
                                End If
                            Next
                            MsgBox(strTadakholMessage, vbOKOnly, "نکسترم")
                            GridTime.CurrentCell = GridTime(0, r)
                        End If
                    Catch ex As Exception
                        MsgBox("err")
                    End Try

                Case "Room" ' ----------------- room ----------------- room ----------------- room ----------------- room -----------------
                    Dim strTadakholMessage As String = ""
                    If Val(GridTime(c, r).Value) > 0 Then
                        Try
                            For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                                If ((DS.Tables("tblAllProgs").Rows(i).Item(r + 10) And (2 ^ (c - 1))) = (2 ^ (c - 1))) And (DS.Tables("tblAllProgs").Rows(i).Item(16) = intRoom) Then
                                    strTadakholMessage = strTadakholMessage & " درس " & DS.Tables("tblAllProgs").Rows(i).Item(3) & "    استاد: " & DS.Tables("tblAllProgs").Rows(i).Item(7) & vbCrLf & " ورودي " & DS.Tables("tblAllProgs").Rows(i).Item(29) & vbCrLf & vbCrLf
                                End If
                                If ((DS.Tables("tblAllProgs").Rows(i).Item(r + 18) And (2 ^ (c - 1))) = (2 ^ (c - 1))) And (DS.Tables("tblAllProgs").Rows(i).Item(24) = intRoom) Then
                                    strTadakholMessage = strTadakholMessage & " درس " & DS.Tables("tblAllProgs").Rows(i).Item(3) & "    استاد: " & DS.Tables("tblAllProgs").Rows(i).Item(7) & vbCrLf & " ورودي " & DS.Tables("tblAllProgs").Rows(i).Item(29) & vbCrLf & vbCrLf
                                End If
                            Next
                            MsgBox(strTadakholMessage, vbOKOnly, "نکسترم")
                            GridTime.CurrentCell = GridTime(0, r)
                        Catch ex As Exception
                            MsgBox("err")
                        End Try
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    'Popup Menus
    Private Sub PopMenu_AddGroup(sender As Object, e As EventArgs) Handles MenuAddGroup.Click
        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid4.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = Grid4.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 1 Then Exit Sub
        Dim intGroup As Integer

        intEntry = ListBox1.SelectedValue 'This Entry of This BioProg
        intTerm = ListBox2.SelectedValue 'This Term
        intGroup = DS.Tables("tblTermProgs").Rows(r).Item(5)
        intGroup = intGroup + 1
        intCourse = DS.Tables("tblTermProgs").Rows(r).Item(1)
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@ent, @term, @course, @grp)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ent", Val(intEntry))
                    cmd.Parameters.AddWithValue("@term", Val(intTerm))
                    cmd.Parameters.AddWithValue("@course", Val(intCourse))
                    cmd.Parameters.AddWithValue("@grp", Val(intGroup))
                    cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@ent, @term, @course, @grp)"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ent", Val(intEntry))
                    cmd.Parameters.AddWithValue("@term", Val(intTerm))
                    cmd.Parameters.AddWithValue("@course", Val(intCourse))
                    cmd.Parameters.AddWithValue("@grp", Val(intGroup))
                    cmd.ExecuteNonQuery()
            End Select

            WriteLOG(4)
            ListBox2_Terms(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub PopMenu_AddCourse(sender As Object, e As EventArgs) Handles MenuAddCourse.Click
        If Grid4.RowCount < 1 Then Exit Sub
        intDept = ComboBox1.GetItemText(ComboBox1.SelectedValue)
        intBioProg = DS.Tables("tblEntries").Rows(ListBox1.SelectedIndex).Item(2)
        ChooseCourse.ShowDialog()
        If strCourse = "" Then
            Exit Sub
        Else
            Dim myansw As DialogResult = MsgBox("اين درس به برنامه ترم اضافه شود؟", vbYesNo, strCourse)
            If myansw = vbNo Then Exit Sub
        End If

        Dim intGroup As Integer = 1
        intEntry = ListBox1.SelectedValue 'This Entry of This BioProg
        intTerm = ListBox2.SelectedValue 'This Term
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Try
                    strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@ent, @term, @courseid, 1)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ent", Val(intEntry))
                    cmd.Parameters.AddWithValue("@term", Val(intTerm))
                    cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                    cmd.ExecuteNonQuery()
                    WriteLOG(4)
                    ListBox2_Terms(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                Try
                    strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@ent, @term, @courseid, 1)"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ent", Val(intEntry))
                    cmd.Parameters.AddWithValue("@term", Val(intTerm))
                    cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                    cmd.ExecuteNonQuery()
                    WriteLOG(4)
                    ListBox2_Terms(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select


    End Sub
    Private Sub PopMenu_DelCourse(sender As Object, e As EventArgs) Handles MenuDelCourse.Click
        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid4.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = Grid4.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 1 Then Exit Sub

        Dim myansw = MsgBox("آيا از حذف اين درس مطمئن هستيد؟", vbYesNo + vbDefaultButton2, "NexTerm:")
        If myansw = vbNo Then Exit Sub

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Try
                    strSQL = "DELETE FROM TermProgs WHERE ID=@id"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@id", Grid4.Rows(r).Cells(0).Value)
                    cmd.ExecuteNonQuery()
                    WriteLOG(5)
                    ListBox2_Terms(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                Try
                    strSQL = "DELETE FROM TermProgs WHERE ID=@id"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@id", Grid4.Rows(r).Cells(0).Value)
                    cmd.ExecuteNonQuery()
                    WriteLOG(5)
                    ListBox2_Terms(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select

    End Sub
    Private Sub Menu_ReplaceCourse(sender As Object, e As EventArgs) Handles MenuReplaceCourse.Click
        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid4.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = Grid4.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 1 Then Exit Sub
        Dim newTerm As String = ListBox2.Text
        strCaption = "Terms"
        ChooseTerm.ShowDialog()

        If intTerm = 0 Then
            MsgBox("انصراف از انتقال درس", vbOKOnly, "نکسترم")
        Else
            Dim myansw As DialogResult = MsgBox(" آيا از جابجا کردن اين درس به ترم " & strTerm & "  مطمئن هستيد؟ ", vbYesNo + vbDefaultButton2, "نکسترم")
            If myansw = vbYes Then
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        Try
                            strSQL = "UPDATE TermProgs SET Term_ID=@term WHERE ID=@id"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@term", Val(intTerm))
                            cmd.Parameters.AddWithValue("@id", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                            Dim i As Integer
                            i = cmd.ExecuteNonQuery()
                            WriteLOG(6)
                        Catch ex As Exception
                            MsgBox("Replacing Course : Error", vbOK, "Err")
                        End Try
                    Case "Access"
                        Try
                            strSQL = "UPDATE TermProgs SET Term_ID=@term WHERE ID=@id"
                            Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@term", Val(intTerm))
                            cmd.Parameters.AddWithValue("@id", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                            Dim i As Integer
                            i = cmd.ExecuteNonQuery()
                            WriteLOG(6)
                        Catch ex As Exception
                            MsgBox("Replacing Course : Error", vbOK, "Err")
                        End Try
                End Select
            Else
                Exit Sub
            End If
        End If

        ' Refresh
        ListBox1_Entries(sender, e)
        ListBox2.SelectedIndex = 0
        ListBox2_Terms(sender, e)

    End Sub
    Private Sub MenuDelClass1_Click(sender As Object, e As EventArgs) Handles MenuDelClass1.Click
        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid4.CurrentCell.RowIndex 'count from 0
        Dim c As Integer = Grid4.CurrentCell.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE TermProgs SET Room1=0 WHERE ID = @ID"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "UPDATE TermProgs SET Room1=0 WHERE ID = @ID"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ListBox2_Terms(sender, e)

    End Sub
    Private Sub MenuDelClass2_Click(sender As Object, e As EventArgs) Handles MenuDelClass2.Click
        If Grid4.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid4.CurrentCell.RowIndex 'count from 0
        Dim c As Integer = Grid4.CurrentCell.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE TermProgs SET Room2=0 WHERE ID = @ID"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "UPDATE TermProgs SET Room2=0 WHERE ID = @ID"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ListBox2_Terms(sender, e)

    End Sub
    Private Sub PopMenu_SaveWeekGrid(sender As Object, e As EventArgs) Handles PopMenu_SaveWeek.Click
        Dim r, c As Integer
        r = Grid4.CurrentCell.RowIndex
        c = Grid4.CurrentCell.ColumnIndex
        Try
            DS.Tables("tblTermProgs").Rows(r).Item(27) = txtExamDate.Text
        Catch ex As Exception
            MsgBox("Error in SaveGrid: NOT SAVED !",, "NexTerm")
        End Try

        For intDay As Integer = 0 To 5
            intClass1DayData(intDay) = 0 ' reset a day in class1 and then refill
            intClass2DayData(intDay) = 0 ' reset a day in class2 and then refill
            For intTime As Integer = 1 To 8
                If (GridTime(intTime, intDay).Value <> "") And (GridTime(intTime, intDay).Style.BackColor = Color.LightCyan) Then
                    intClass1DayData(intDay) = (intClass1DayData(intDay) Or (2 ^ (intTime - 1)))
                End If
                If (GridTime(intTime, intDay).Value <> "") And (GridTime(intTime, intDay).Style.BackColor = Color.MistyRose) Then
                    intClass2DayData(intDay) = (intClass2DayData(intDay) Or (2 ^ (intTime - 1)))
                End If
            Next intTime
            DS.Tables("tblTermProgs").Rows(r).Item(intDay + 10) = Val(intClass1DayData(intDay))
            DS.Tables("tblTermProgs").Rows(r).Item(intDay + 18) = Val(intClass2DayData(intDay))
        Next intDay

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE TermProgs SET SAT1=@sat1, SUN1=@sun1, MON1=@mon1, TUE1=@tue1, WED1=@wed1, THR1=@thr1, SAT2=@sat2, SUN2=@sun2, MON2=@mon2, TUE2=@tue2, WED2=@wed2, THR2=@thr2, ExamDate=@ExamDate WHERE ID=@ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@sat1", Val(intClass1DayData(0)))
                cmd.Parameters.AddWithValue("@sun1", Val(intClass1DayData(1)))
                cmd.Parameters.AddWithValue("@mon1", Val(intClass1DayData(2)))
                cmd.Parameters.AddWithValue("@tue1", Val(intClass1DayData(3)))
                cmd.Parameters.AddWithValue("@wed1", Val(intClass1DayData(4)))
                cmd.Parameters.AddWithValue("@thr1", Val(intClass1DayData(5)))
                cmd.Parameters.AddWithValue("@sat2", Val(intClass2DayData(0)))
                cmd.Parameters.AddWithValue("@sun2", Val(intClass2DayData(1)))
                cmd.Parameters.AddWithValue("@mon2", Val(intClass2DayData(2)))
                cmd.Parameters.AddWithValue("@tue2", Val(intClass2DayData(3)))
                cmd.Parameters.AddWithValue("@wed2", Val(intClass2DayData(4)))
                cmd.Parameters.AddWithValue("@thr2", Val(intClass2DayData(5)))
                cmd.Parameters.AddWithValue("@ExamDate", txtExamDate.Text)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    GridWeek_Show()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    'MsgBox("Error Saving Changes", vbOKOnly, "Err")
                End Try
            Case "Access"
                strSQL = "UPDATE TermProgs SET SAT1=@sat1, SUN1=@sun1, MON1=@mon1, TUE1=@tue1, WED1=@wed1, THR1=@thr1, SAT2=@sat2, SUN2=@sun2, MON2=@mon2, TUE2=@tue2, WED2=@wed2, THR2=@thr2, ExamDate=@ExamDate WHERE ID=@ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@sat1", Val(intClass1DayData(0)))
                cmd.Parameters.AddWithValue("@sun1", Val(intClass1DayData(1)))
                cmd.Parameters.AddWithValue("@mon1", Val(intClass1DayData(2)))
                cmd.Parameters.AddWithValue("@tue1", Val(intClass1DayData(3)))
                cmd.Parameters.AddWithValue("@wed1", Val(intClass1DayData(4)))
                cmd.Parameters.AddWithValue("@thr1", Val(intClass1DayData(5)))
                cmd.Parameters.AddWithValue("@sat2", Val(intClass2DayData(0)))
                cmd.Parameters.AddWithValue("@sun2", Val(intClass2DayData(1)))
                cmd.Parameters.AddWithValue("@mon2", Val(intClass2DayData(2)))
                cmd.Parameters.AddWithValue("@tue2", Val(intClass2DayData(3)))
                cmd.Parameters.AddWithValue("@wed2", Val(intClass2DayData(4)))
                cmd.Parameters.AddWithValue("@thr2", Val(intClass2DayData(5)))
                cmd.Parameters.AddWithValue("@ExamDate", txtExamDate.Text)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTermProgs").Rows(r).Item(0).ToString)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    GridWeek_Show()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    'MsgBox("Error Saving Changes", vbOKOnly, "Err")
                End Try
        End Select

    End Sub

    'Menu 1 User (karbar)
    Private Sub Menu_Userx_Click(sender As Object, e As EventArgs) Handles Menu_Userx.Click
        frmLogIn.ShowDialog()

        Select Case Userx
            Case "quit"
                Try
                    WriteLOG(2)
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            CnnSS.Close() : CnnSS.Dispose() : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Me.Dispose() : Application.Exit() : End
                        Case "Access"
                            CnnAC.Close() : CnnAC.Dispose() : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Me.Dispose() : Application.Exit() : End
                    End Select
                Catch
                    MsgBox("Error in Exit module ....")
                End Try
            Case "USER Faculty", "USER Department"
                WriteLOG(3)
                ComboBox1.SelectedValue = intUser
        End Select
        Me.Text = "NexTerm  |  " & Userx & "  Connected to :  " & Server2Connect
        EnableMenu()
        ClrForm()
        GridTime_Hide()

    End Sub
    Private Sub Menu_Settings_Click(sender As Object, e As EventArgs) Handles Menu_Settings.Click
        If Userx = "USER Faculty" Then
            Settings.ShowDialog()
            WriteLOG(10)
            EnableMenu()
            ClrForm()
            GridTime_Hide()
        End If

    End Sub
    Private Sub Menu_About_Click(sender As Object, e As EventArgs) Handles Menu_About.Click
        frmAbout.ShowDialog()

    End Sub
    Private Sub Menu_Help_Click(sender As Object, e As EventArgs) Handles Menu_Help.Click
        Try
            Dim pWeb As Process = New Process()
            pWeb.StartInfo.UseShellExecute = True
            pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir"
            pWeb.Start()

        Catch ex As Exception
            MsgBox("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", vbOKOnly, "مرورگر اج پيدا نشد") 'MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Menu_ChangePass_Click(sender As Object, e As EventArgs) Handles Menu_ChangePass.Click
        If (Userx = "USER Faculty") Or (intUser = 0) Then
            Menu_Settings_Click(sender, e) 'MsgBox("کاربر دانشکده (ادمين) براي تغيير پسورد به بخش تنظيمات مراجعه کنيد", vbOKOnly, "نکسترم")
            Exit Sub
        End If
        If DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(9) <> True Then
            MsgBox("تغيير کلمه عبور اکنون فعال نيست", vbInformation, "تنظيمات نکسترم")
            Exit Sub
        End If
        Dim strOldPass As String = ""
        Dim strNewPass As String = ""
        Dim strcheckPass As String = ""

        strOldPass = DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(4)

        strcheckPass = InputBox("پسورد فعلي را وارد کنيد", "نکسترم", "")
        If strcheckPass <> strOldPass Then
            strcheckPass = InputBox("پسورد فعلي را  - بطور صحيح -  وارد کنيد", "توجه:", "")
            If strcheckPass <> strOldPass Then
                Menu_Userx_Click(sender, e)
                Exit Sub
            End If
        Else
            strNewPass = Trim(InputBox("پسورد جديد را وارد کنيد", "تغيير پسورد", ""))
            If (strNewPass = "") Or (strNewPass = strOldPass) Then
                Exit Sub
            Else
                strOldPass = strNewPass
                strNewPass = Trim(InputBox("پسورد جديد را  ( دوباره )  وارد کنيد", "تغيير پسورد", ""))
                If strNewPass <> strOldPass Then
                    MsgBox("تکرار پسورد جديد نادرست بود", vbOKOnly, "عمليات ناموفق")
                    Exit Sub
                End If
                DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(4) = strNewPass
            End If
        End If


        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Departments SET DepartmentPass=@deptpass WHERE ID=@id"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@deptpass", strNewPass)
                cmd.Parameters.AddWithValue("@id", intUser.ToString)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("خطا در بروزرساني کلمه عبور", vbOKOnly, "نکسترم")
                End Try
            Case "Access"
                strSQL = "UPDATE Departments SET DepartmentPass=@deptpass WHERE ID=@id"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@deptpass", strNewPass)
                cmd.Parameters.AddWithValue("@id", intUser.ToString)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("خطا در بروزرساني کلمه عبور", vbOKOnly, "نکسترم")
                End Try
        End Select

        strDepartmentPass = strNewPass
        WriteLOG(11)
        MsgBox("کلمه عبور تغيير يافت", vbInformation, "نکسترم")
    End Sub
    Private Sub Menu_Quit_Click(sender As Object, e As EventArgs) Handles Menu_Quit.Click
        DoExitNexTerm()
    End Sub

    'Menu 2 Resource
    Private Sub Menu_Departments_Click(sender As Object, e As EventArgs) Handles Menu_Departments.Click
        'Me.Hide()
        frmDepts.ShowDialog()
        ClrForm()
        EnableMenu()

    End Sub
    Private Sub Menu_Courses_Click(sender As Object, e As EventArgs) Handles Menu_Courses.Click
        Dim i As String = ListBox1.GetItemText(ListBox1.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        intBioProg = DS.Tables("tblEntries").Rows(ListBox1.SelectedIndex).Item(2)

        strCaption = "Courses"
        'Me.Hide()
        frmShowTables.ShowDialog()
        ClrForm()

    End Sub
    Private Sub Menu_Classes_Click(sender As Object, e As EventArgs) Handles Menu_Classes.Click
        intTerm = ListBox2.SelectedValue
        For c As Integer = 0 To 7
            For r As Integer = 0 To 5
                tblThisCourseTime.Rows(r).Item(c) = ""
            Next r
        Next c

        ChooseClass.ShowDialog()
        ClrForm()

    End Sub
    Private Sub Menu_Terms_Click(sender As Object, e As EventArgs) Handles Menu_Terms.Click
        strCaption = "Terms"
        ChooseTerm.ShowDialog()
        ClrForm()

    End Sub
    Private Sub Menu_Staff_Click(sender As Object, e As EventArgs) Handles Menu_Staff.Click
        'If ComboBox1.SelectedIndex = -1 Then Exit Sub
        intDept = ComboBox1.SelectedValue
        If ComboBox1.SelectedIndex = -1 Then intDept = 0
        'Me.Hide()
        ChooseStaff.ShowDialog()
        ClrForm()

    End Sub
    Private Sub Menu_Tech_Click(sender As Object, e As EventArgs) Handles Menu_Tech.Click
        ChooseTech.ShowDialog()
        ClrForm()

    End Sub

    'Menu 4 Program
    Private Sub Menu_Templates(sender As Object, e As EventArgs) Handles M2Templates.Click
        If ComboBox1.SelectedIndex = -1 Then Exit Sub
        intDept = ComboBox1.SelectedValue
        Me.Hide()
        Templates.ShowDialog()
        Me.Show()
        ClrForm()

    End Sub
    Private Sub Menu_Delete_Entry_TermProg_Click(sender As Object, e As EventArgs) Handles Menu_Delete_Entry_TermProg.Click
        If ListBox1.SelectedIndex = -1 Then Exit Sub
        Dim myansw As Integer = MsgBox("برنامه آموزشي همه ترم هاي اين ورودي حذف شوند؟", vbYesNo + vbDefaultButton2, "تاييد کنيد")
        If myansw = vbNo Then Exit Sub
        'Again
        myansw = MsgBox("برنامه هاي اين ورودي حذف شوند؟  مطمئن هستيد؟", vbYesNo + vbDefaultButton2, "تاييد کنيد")
        If myansw = vbNo Then Exit Sub

        intEntry = ListBox1.SelectedValue
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "DELETE From TermProgs WHERE Entry_ID = @id"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@id", intEntry.ToString)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    MsgBox("برنامه تمامي ترم هاي ورودي" & vbCrLf & vbCrLf & strEntry & vbCrLf & vbCrLf & "حذف شدند" & vbCrLf & vbCrLf & "بااستفاده از برنامه هاي ترميک مي توانيد اين ورودي را مجددا برنامه ريز کنيد", vbOKOnly, "NexTerm")
                    WriteLOG(9)
                    ListBox1_Entries(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "DELETE * From TermProgs WHERE Entry_ID = @id"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@id", intEntry.ToString)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    MsgBox("برنامه تمامي ترم هاي ورودي" & vbCrLf & vbCrLf & strEntry & vbCrLf & vbCrLf & "حذف شدند" & vbCrLf & vbCrLf & "بااستفاده از برنامه هاي ترميک مي توانيد اين ورودي را مجددا برنامه ريز کنيد", vbOKOnly, "NexTerm")
                    WriteLOG(9)
                    ListBox1_Entries(sender, e)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select

    End Sub
    Private Sub Menu_ReProgram_ThisEnteryTerm_inclStaff_Click(sender As Object, e As EventArgs) Handles Menu_ReProgram_ThisEnteryTerm_inclStaff.Click
        If ListBox2.SelectedIndex = -1 Then Exit Sub
        If Grid4.RowCount < 1 Then Exit Sub

        Dim myansw As DialogResult = MsgBox(" برنامه ريزي درس هاي اين ترم براي ورودي " & vbCrLf & vbCrLf & strEntry & vbCrLf & vbCrLf & "از نو انجام شود؟", vbYesNo + vbDefaultButton2, "Term : " & strTerm)
        If myansw = vbNo Then Exit Sub
        'Agian
        myansw = MsgBox(" برنامه ريزي دروس اين ترم براي  " & vbCrLf & vbCrLf & strEntry & vbCrLf & vbCrLf & "پاک شود؟", vbYesNo + vbDefaultButton2, "Term : " & strTerm)
        If myansw = vbNo Then Exit Sub

        intEntry = ListBox1.SelectedValue
        intTerm = ListBox2.SelectedValue

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE TermProgs SET Staff_ID=0, Tech_ID=0, SAT1=0, SUN1=0, MON1=0, TUE1=0, WED1=0, THR1=0, Room1=0, SAT2=0, SUN2=0, MON2=0, TUE2=0, WED2=0, THR2=0, Room2=0, Capacity=0, ExamDate='', Notes='' WHERE Entry_ID= @entryid AND Term_ID=@termid"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@entryid", Val(intEntry))
                cmd.Parameters.AddWithValue("@termid", Val(intTerm))
                Dim i As Integer
                Try
                    i = cmd.ExecuteNonQuery()
                    WriteLOG(8)
                    ListBox2_Terms(sender, e) 'REFRESH GRID4
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "UPDATE TermProgs SET Staff_ID=0, Tech_ID=0, SAT1=0, SUN1=0, MON1=0, TUE1=0, WED1=0, THR1=0, Room1=0, SAT2=0, SUN2=0, MON2=0, TUE2=0, WED2=0, THR2=0, Room2=0, Capacity=0, ExamDate='', Notes='' WHERE Entry_ID= @entryid AND Term_ID=@termid"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@entryid", Val(intEntry))
                cmd.Parameters.AddWithValue("@termid", Val(intTerm))
                Dim i As Integer
                Try
                    i = cmd.ExecuteNonQuery()
                    WriteLOG(8)
                    ListBox2_Terms(sender, e) 'REFRESH GRID4
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select

    End Sub
    Private Sub Menu_ReProgram_ThisEnteryTerm_Click(sender As Object, e As EventArgs) Handles Menu_ReProgram_ThisEnteryTerm.Click
        If ListBox2.SelectedIndex = -1 Then Exit Sub
        If Grid4.RowCount < 1 Then Exit Sub

        Dim myansw As DialogResult = MsgBox(" برنامه ريزي درس هاي اين ترم براي ورودي " & vbCrLf & vbCrLf & strEntry & vbCrLf & vbCrLf & "از نو انجام شود؟", vbYesNo + vbDefaultButton2, "Term : " & strTerm)
        If myansw = vbNo Then Exit Sub
        'Agian
        myansw = MsgBox(" برنامه ريزي دروس اين ترم براي  " & vbCrLf & vbCrLf & strEntry & vbCrLf & vbCrLf & "پاک شود؟", vbYesNo + vbDefaultButton2, "Term : " & strTerm)
        If myansw = vbNo Then Exit Sub

        intEntry = ListBox1.SelectedValue
        intTerm = ListBox2.SelectedValue

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE TermProgs SET SAT1=0, SUN1=0, MON1=0, TUE1=0, WED1=0, THR1=0, Room1=0, SAT2=0, SUN2=0, MON2=0, TUE2=0, WED2=0, THR2=0, Room2=0, Capacity=0, ExamDate='', Notes='' WHERE Entry_ID= @entryid AND Term_ID=@termid"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@entryid", Val(intEntry))
                cmd.Parameters.AddWithValue("@termid", Val(intTerm))
                Dim i As Integer
                Try
                    i = cmd.ExecuteNonQuery()
                    WriteLOG(8)
                    ListBox2_Terms(sender, e) 'REFRESH GRID4
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "UPDATE TermProgs SET SAT1=0, SUN1=0, MON1=0, TUE1=0, WED1=0, THR1=0, Room1=0, SAT2=0, SUN2=0, MON2=0, TUE2=0, WED2=0, THR2=0, Room2=0, Capacity=0, ExamDate='', Notes='' WHERE Entry_ID= @entryid AND Term_ID=@termid"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@entryid", Val(intEntry))
                cmd.Parameters.AddWithValue("@termid", Val(intTerm))
                Dim i As Integer
                Try
                    i = cmd.ExecuteNonQuery()
                    WriteLOG(8)
                    ListBox2_Terms(sender, e) 'REFRESH GRID4
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select



    End Sub

    'Menu 5 Report

    Private Sub Menu_Notes_Click(sender As Object, e As EventArgs) Handles Menu_Notes.Click
        frmShowNotes.ShowDialog()

    End Sub
    Private Sub Menu_UserActivityLog_CLEAR_Click(sender As Object, e As EventArgs) Handles Menu_UserActivityLog_CLEAR.Click
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
            WriteLOG(12)
            'MsgBox("پاک شد", vbInformation, "Notice:")
            Menu_UserActivityLogs_Click(sender, e)
        End If

    End Sub
    Private Sub Menu_UserActivityLogs_Click(sender As Object, e As EventArgs) Handles Menu_UserActivityLogs.Click
        Try
            DS.Tables("tblLogs").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT LogText From xLog ORDER BY LogText DESC"
                    DASS.Fill(DS, "tblLogs") ' tbl Logs
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT LogText From xLog ORDER BY LogText DESC"
                    DAAC.Fill(DS, "tblLogs") ' tbl Logs
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        FileOpen(1, Application.StartupPath & "Nexterm_log.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""ltr"">")
        PrintLine(1, "<head><title>گزارش ورود کاربران</title><style>table, th, td {border: 1px solid;} </style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h4 style='color:red; font-family:tahoma; text-align: center'>Log for:  " & Server2Connect & "</h4>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:16px'>")
        For i As Integer = 0 To DS.Tables("tblLogs").Rows.Count - 1
            PrintLine(1, DS.Tables("tblLogs").Rows(i).Item(0) & "<br>")
        Next i
        PrintLine(1, "</p><br>")
        ' //footer
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm computer program, Faculty of Science, SKU. Developed by: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "Nexterm_log.html")

    End Sub
    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG
            Try
                If Userx = "USER Faculty" Then intUser = 0
                intEntry = ListBox1.SelectedValue
                intTerm = ListBox2.SelectedValue
                If Grid4.SelectedCells(0).RowIndex >= 0 Then
                    intCourseNumber = Grid4.Item(2, Grid4.SelectedCells(0).RowIndex).Value
                End If
            Catch ex As Exception
                'do nothing
            End Try
            Dim strLog As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss") & " -usr:" & intUser.ToString & " -nick:" & UserNickName & " -pc:" & LCase(Environment.MachineName)
            Select Case intActivity
                Case 2 : strLog = strLog & " > logout"
                Case 3 : strLog = strLog & " > login"
                Case 4 : strLog = strLog & " > course added  : " & intCourseNumber.ToString & ", ent: " & intEntry.ToString & ", trm: " & strTerm
                Case 5 : strLog = strLog & " > course deleted  : " & intCourseNumber.ToString & ", ent: " & intEntry.ToString & ", trm: " & strTerm
                Case 6 : strLog = strLog & " > course term  : " & intCourseNumber.ToString & ", ent: " & intEntry.ToString & ", trm: " & strTerm
                Case 7 : strLog = strLog & " > course changed : " & intCourseNumber.ToString & ", ent: " & intEntry.ToString & ", trm: " & strTerm
                Case 8 : strLog = strLog & " > termProg refresh, ent " & intEntry.ToString & ", trm: " & strTerm.ToString
                Case 9 : strLog = strLog & " > entryPrg deleted, ent " & intEntry.ToString
                Case 10 : strLog = strLog & " > settings"
                Case 11 : strLog = strLog & " > pass " & strDepartmentPass
                Case 12 : strLog = strLog & " > log clr"
            End Select

            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Try
                        strSQL = "INSERT INTO xLog (LogText) VALUES (@logtext)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@logtext", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString) 'Do Nothing!
                    End Try
                Case "Access"
                    Try
                        strSQL = "INSERT INTO xLog (LogText) VALUES (@logtext)"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@logtext", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString) 'Do Nothing!
                    End Try
            End Select
        End If
    End Sub


    Private Sub Menu_ExitNexTerm_Click(sender As Object, e As EventArgs) Handles Menu_ExitNexTerm.Click
        DoExitNexTerm()
    End Sub
    Private Sub DoExitNexTerm()
        Dim i
        i = MsgBox("خارج مي شويد؟", vbYesNo + vbDefaultButton1, "NexTerm")
        If i = vbYes Then
            WriteLOG(2)
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        DS.Tables("tblSettings").Clear()
                        DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin can prog%' ORDER BY iHerbsConstant"
                        DASS.Fill(DS, "tblSettings")
                        DS.Tables("tblSettings").Rows(0).Item(2) = "NO"
                        strSQL = "UPDATE Settings SET iHerbsValue = 'NO' WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(0).Item(0).ToString)
                        Dim k As Integer = cmd.ExecuteNonQuery()

                        CnnSS.Close() : CnnSS.Dispose() : CnnSS = Nothing : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Me.Dispose() : Application.Exit() : End
                    Case "Access"
                        DS.Tables("tblSettings").Clear()
                        DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin can prog%' ORDER BY iHerbsConstant"
                        DAAC.Fill(DS, "tblSettings")
                        DS.Tables("tblSettings").Rows(0).Item(2) = "NO"
                        strSQL = "UPDATE Settings SET iHerbsValue = 'NO' WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(0).Item(0).ToString)
                        Dim k As Integer = cmd.ExecuteNonQuery()

                        CnnAC.Close() : CnnAC.Dispose() : CnnAC = Nothing : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Me.Dispose() : Application.Exit() : End
                End Select
            Catch
                MsgBox("Error in Exit module ....")
            End Try
        End If

    End Sub

    Private Sub Menu_ReportClassPrograms_Click(sender As Object, e As EventArgs) Handles Menu_ReportClassPrograms.Click
        MsgBox("Salam")
        FileOpen(1, Application.StartupPath & "Nexterm_class_All.html", OpenMode.Output)
        PrintLine(1, "NexTerm Reports")
        FileClose(1)
        DS.Tables("tblAllProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE ((Term_ID = " & intTerm.ToString & ") AND ((Room1 = " & intRoom.ToString & ") OR (Room2 = " & intRoom.ToString & "))) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                    DASS.Fill(DS, "tblAllProgs")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE ((Term_ID = " & intTerm.ToString & ") AND ((Room1 = " & intRoom.ToString & ") OR (Room2 = " & intRoom.ToString & "))) ORDER BY THR1, WED1, TUE1, MON1, SUN1, SAT1"
                    DAAC.Fill(DS, "tblAllProgs")
            End Select
        MsgBox(DS.Tables("tblRooms").Rows.Count.ToString)
        Dim intTimeFlag(5, 7) As Integer ' (r:days, c:times //begins from 0)
        Dim strTadakhol As String = ""
            Dim TadakholExists As Boolean = False

        For rm = 1 To DS.Tables("tblRooms").Rows.Count
            strTadakhol = ""
            strTadakhol = strTadakhol & "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>"
            strTadakhol = strTadakhol & "<tr><th>روز</th><th>ساعت</th><th>نام درس</th><th>گ</th><th>ورودي</th><th>استاد</th></tr>"
            Try
                For intTime As Integer = 0 To 7 ' for each time of day
                    For intDay As Integer = 0 To 5
                        For intThisRoom As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                            If ((DS.Tables("tblAllProgs").Rows(intThisRoom).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime)) And (DS.Tables("tblAllProgs").Rows(intThisRoom).Item(16) = intRoom) Then
                                intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                                If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(5) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(29) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(7) & "</td></tr>" & vbCrLf : TadakholExists = True
                            End If
                            If (((DS.Tables("tblAllProgs").Rows(intThisRoom).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime))) And (Val(DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24)) = intRoom) Then
                                intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                                If intTimeFlag(intDay, intTime) > 1 Then strTadakhol = strTadakhol & "<tr><td>" & strDay(intDay) & "</td><td>" & strTime(intTime) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(3) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(5) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(29) & "</td><td>" & DS.Tables("tblAllProgs").Rows(intThisRoom).Item(7) & "</td></tr>" & vbCrLf : TadakholExists = True
                            End If
                        Next intThisRoom
                    Next intDay
                Next intTime
            Catch ex As Exception
            End Try
            strTadakhol = strTadakhol & "</table>"

            '=======================================================================OPEN Staff()
            FileOpen(1, Application.StartupPath & "Nexterm_class_All.html", OpenMode.Append)
            PrintLine(1, "<html dir= ""rtl"">")
            PrintLine(1, "<head><title>برنامه کلاس/آز</title><style>table, th, td {border: 1px solid;} body {background-image:url('" & strReportBG & "');}</style></head>")

            PrintLine(1, "<body>")
            PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
            PrintLine(1, "<h1 style='color:red; text-align: center'>", strRoom, "</h1>")
            PrintLine(1, "<h2 style='color:Green; text-align: center'>", strTerm, "</h2><hr>")


            If TadakholExists = True Then
                PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
                PrintLine(1, "تداخل در برنامه", "<br></p>")
                PrintLine(1, strTadakhol)
                PrintLine(1, "<br><hr>")
            End If

            PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>برنامه کلاس</p>")
            PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
            PrintLine(1, "<tr><th>شماره</th>")
            PrintLine(1, "<th>گ</th>")
            PrintLine(1, "<th>نام درس</th>")

            PrintLine(1, "<th>واحد</th>")
            PrintLine(1, "<th>نام مدرس</th>")
            PrintLine(1, "<th>کارشناس</th>")
            PrintLine(1, "<th>ش</th>")
            PrintLine(1, "<th>ي</th>")
            PrintLine(1, "<th>د</th>")
            PrintLine(1, "<th>س</th>")
            PrintLine(1, "<th>چ</th>")
            PrintLine(1, "<th>پ</th>")
            PrintLine(1, "<th>امتحان</th>")
            PrintLine(1, "<th>کلاس1</th>")
            PrintLine(1, "<th>کلاس2</th>")
            PrintLine(1, "<th>ظرفيت</th>")
            PrintLine(1, "<th>يادداشت</th>")
            PrintLine(1, "<th>ورودي</th></tr>")

            For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                PrintLine(1, "<tr>")
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(2), "</td>")   ' 2 :CourseNumber
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(5), "</td>")   ' 5 :Group
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(3), "</td>")   ' 3 :CourseName
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(4), "</td>")   ' 4 :Unit
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(7), "</td>")   ' 7 :Staff
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(9), "</td>")   ' 9 :Tech

                For intday As Integer = 0 To 5
                    Dim x As String = ""
                    For intTime As Integer = 0 To 7
                        If ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Or ((DS.Tables("tblAllProgs").Rows(i).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then
                            x = x & strTime(intTime) & "<br>" ' Time
                        End If
                    Next intTime
                    PrintLine(1, "<td>", x, "</td>") ' Time
                Next intday

                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(27), "</td>") ' 25:Exam
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(17), "</td>") ' 17:Class1
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(25), "</td>") ' 25:Class2
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(26), "</td>") ' 26:Capacity
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(28), "</td>") ' 28:Notes
                PrintLine(1, "<td>", DS.Tables("tblAllProgs").Rows(i).Item(29), "</td>") ' 29:Ent
                PrintLine(1, "</tr>")
            Next i
            PrintLine(1, "</table><br><hr>")

            ' //footer
            PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
            PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>NexTerm computer program, Faculty of Science, SKU. Developed by: Majid Sharifi-Tehrani (PhD Plant Systematics), 1400</p>")
            PrintLine(1, "</body></html>")
            FileClose(1)

        Next rm

    End Sub
End Class
