Public Class frmStaffProgs
    Private Sub frmStaffProgs_Load() Handles MyBase.Load
        Try
            Me.Text = "NexTerm  |  " & Userx & "  Connected to :  " & Server2Connect
            ComboBox1.DataSource = DS.Tables("tblDepartments")
            ComboBox1.DisplayMember = "DEPT"
            ComboBox1.ValueMember = "ID"
            ComboBox1.SelectedValue = intUser

            GridTime.Rows.Add("ش")
            GridTime.Rows.Add("ي")
            GridTime.Rows.Add("د")
            GridTime.Rows.Add("س")
            GridTime.Rows.Add("چ")
            GridTime.Rows.Add("پ")

            For i = 0 To 8
                GridTime.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged() Handles ComboBox1.SelectedIndexChanged
        Try
            Dim i As String = ComboBox1.GetItemText(ComboBox1.SelectedValue)
            If Val(i) = 0 Then Exit Sub
            'READ FROM DATABASE
            DS.Tables("tblStaff").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" & i.ToString & " ORDER BY StaffName"
                    DASS.Fill(DS, "tblStaff")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" & i.ToString & " ORDER BY StaffName"
                    DAAC.Fill(DS, "tblStaff")
            End Select
            ListStaff.DataSource = DS.Tables("tblStaff")
            ListStaff.DisplayMember = "StaffName"
            ListStaff.ValueMember = "ID"
            ListStaff.Refresh()
            ListStaff.SelectedIndex = -1
            ListStaff.SelectedValue = 0
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'TERMs
        Try
            DS.Tables("tblTerms").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Select Case Userx
                        Case "USER Department" ' show active terms
                            If DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(8) <> True Then
                                DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Terms.[Active] = 1 ORDER BY Term"
                            Else
                                DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) ORDER BY Term"
                            End If
                            DASS.Fill(DS, "tblTerms")
                        Case "USER Faculty" ' show all terms
                            DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) ORDER BY Term"
                            DASS.Fill(DS, "tblTerms")
                    End Select

                Case "Access"
                    Select Case Userx
                        Case "USER Department" ' show active terms
                            If DS.Tables("tblDepartments").Rows(ComboBox1.SelectedIndex).Item(8) <> True Then
                                DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) WHERE Terms.[Active] = True ORDER BY Term"
                            Else
                                DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) ORDER BY Term"
                            End If
                            DAAC.Fill(DS, "tblTerms")
                        Case "USER Faculty" ' show all terms
                            DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM ((Entries INNER JOIN (Terms INNER JOIN TermProgs ON Terms.ID = TermProgs.Term_ID) ON Entries.ID = TermProgs.Entry_ID) INNER JOIN (Departments INNER JOIN BioProgs ON Departments.ID = BioProgs.Department_ID) ON Entries.BioProg_ID = BioProgs.ID) ORDER BY Term"
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

    End Sub

    Private Sub ListStaff_Click() Handles ListStaff.Click
        ListBox2_Click()

    End Sub

    Private Sub ListBox2_Click() Handles ListBox2.Click
        Dim intStaff As String = ListStaff.GetItemText(ListStaff.SelectedValue)
        Dim intTerm As String = ListBox2.GetItemText(ListBox2.SelectedValue)
        If Val(intStaff) = 0 Then Exit Sub
        If Val(intTerm) = 0 Then Exit Sub

        ' Check if (Term Active?) OR (User Faculty?)
        Try
            Grid4.DataBindings.Clear()
            DS.Tables("tblAllProgs").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY CourseName"
                    DASS.Fill(DS, "tblAllProgs")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY CourseName"
                    DAAC.Fill(DS, "tblAllProgs")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Grid4.DataSource = DS.Tables("tblAllProgs")
        Grid4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' hide some cols
        Grid4.Columns(0).Visible = False    ' ID
        Grid4.Columns(1).Visible = False    ' Course ID
        Grid4.Columns(6).Visible = False    ' Staff ID
        Grid4.Columns(7).Visible = False    ' StaffName
        Grid4.Columns(8).Visible = False    ' Tech ID
        Grid4.Columns(9).Visible = False    ' Tech Name
        Grid4.Columns(10).Visible = False   ' SAT 1
        Grid4.Columns(11).Visible = False   ' SUN 1
        Grid4.Columns(12).Visible = False   ' MON 1
        Grid4.Columns(13).Visible = False   ' TUE 1
        Grid4.Columns(14).Visible = False   ' WED 1
        Grid4.Columns(15).Visible = False   ' THR 1
        Grid4.Columns(16).Visible = False   ' Room 1
        Grid4.Columns(17).Visible = False   ' Room 1
        Grid4.Columns(18).Visible = False   ' SAT 2
        Grid4.Columns(19).Visible = False   ' SUN 2
        Grid4.Columns(20).Visible = False   ' MON 2
        Grid4.Columns(21).Visible = False   ' TUE 2
        Grid4.Columns(22).Visible = False   ' WED 2
        Grid4.Columns(23).Visible = False   ' THR 2
        Grid4.Columns(24).Visible = False   ' Room 2
        Grid4.Columns(25).Visible = False   ' Room 2
        Grid4.Columns(26).Visible = False   ' Capa
        Grid4.Columns(27).Visible = False   ' ExamDate
        Grid4.Columns(30).Visible = False   ' Term

        Grid4.Columns(2).Width = 90     'CourseNumber
        Grid4.Columns(3).Width = 220    'CourseName
        Grid4.Columns(4).Width = 35     'Units
        Grid4.Columns(5).Width = 30     'Group
        Grid4.Columns(28).Width = 250   'Note
        Grid4.Columns(29).Width = 250   'Entry-Name

        For i = 0 To Grid4.Columns.Count - 1
            Grid4.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i


        'FILL GRID TIME
        Array.Clear(intTimeFlag, 0, intTimeFlag.Length) ' clear data in intTimeFlag (r:6days, c:8times //begins from 0)
        Dim TadakholExists As Boolean = False

        For intTime As Integer = 0 To 7 ' for each time of day
            For intDay As Integer = 0 To 5 'each day
                GridTime(intTime + 1, intDay).Value = ""
                For intThisStaff As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                    If (DS.Tables("tblAllProgs").Rows(intThisStaff).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime) Then
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        If intTimeFlag(intDay, intTime) > 1 Then
                            TadakholExists = True
                            GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        Else
                            GridTime(intTime + 1, intDay).Value = Grid4(3, intThisStaff).Value
                        End If
                    End If

                    If (DS.Tables("tblAllProgs").Rows(intThisStaff).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime) Then
                        intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                        GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        If intTimeFlag(intDay, intTime) > 1 Then
                            TadakholExists = True
                            GridTime(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        Else
                            GridTime(intTime + 1, intDay).Value = Grid4(3, intThisStaff).Value
                        End If
                    End If
                Next intThisStaff
            Next intDay
        Next intTime

    End Sub

    Private Sub Munu_Exit_Click(sender As Object, e As EventArgs) Handles Munu_Exit.Click
        Me.Dispose()

    End Sub

    Private Sub GridTime_CellClick() Handles GridTime.CellClick
        Try
            strTerm = ListBox2.Text
            Dim r As Integer = GridTime.CurrentCell.RowIndex    'count from 0
            Dim c As Integer = GridTime.CurrentCell.ColumnIndex 'count from 0
            If r < 0 Or c < 0 Then Exit Sub
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
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class