Public Class frmDepts
    ' GRID DEPARTMENT
    Private Sub frmShowTables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "NexTerm  |  " & Userx & "  Connected to :  " & Server2Connect
        WriteLOG(0)
        Show_DeptTable()
        EnableDisableMenus()

        Dim hlp As String = ""
        hlp = hlp & "acc1: Courses(امکان ويرايش درس ها)" & vbCrLf
        hlp = hlp & "acc2: Staff(امکان ويرايش نام استاد / کارشناس)" & vbCrLf
        hlp = hlp & "acc3: Class (امکان تخصيص کلاس)" & vbCrLf
        hlp = hlp & "acc4: all Terms(مشاهده همه ترم هاي يک ورودي + حذف برنامه يک ورودي در يک ترم)" & vbCrLf
        hlp = hlp & "acc5: Pass (فعال بودن اکانت براي برنامه ريزي و امکان تغيير کلمه عبور)"
        lblHelp.Text = hlp
    End Sub
    Private Sub Show_DeptTable()
        DS.Tables("tblDepartments").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT ID, DepartmentName AS DEPT, DepartmentActive, Notes, DepartmentPass, acc1, acc2, acc3, acc4, acc5 FROM Departments ORDER BY Departments.DepartmentName"
                DASS.Fill(DS, "tblDepartments")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT ID, DepartmentName AS DEPT, DepartmentActive, Notes, DepartmentPass, acc1, acc2, acc3, acc4, acc5 FROM Departments ORDER BY Departments.DepartmentName"
                DAAC.Fill(DS, "tblDepartments")
        End Select

        Grid1.DataSource = DS.Tables("tblDepartments")
        Grid1.Refresh()
        If Userx = "USER Faculty" And UserAccessControls And (2 ^ 4) = (2 ^ 4) Then
            Grid1.Columns(0).Visible = False      'ID
            Grid1.Columns(4).Visible = True      'Pass
            Grid1.Columns(4).Width = 35          'Pass
        Else
            Grid1.Columns(0).Visible = False      'ID
            Grid1.Columns(4).Visible = False      'Pass
        End If

        Grid1.Columns(0).Width = 0        'ID
        Grid1.Columns(1).Width = 230      'DepartmentName
        Grid1.Columns(2).Width = 43       'Active
        Grid1.Columns(3).Width = 50       'Notes
        Grid1.Columns(5).Width = 40       'Access-1 : Add/Edit Courses
        Grid1.Columns(6).Width = 40       'Access-2 : Add/Edit Staff & Techs
        Grid1.Columns(7).Width = 40       'Access-3 : Add/Edit Use/Set Class
        Grid1.Columns(8).Width = 40       'Access-4 : Add/Edit Re-Prog & See All Terms
        Grid1.Columns(9).Width = 40       'Access-5 : Change Pwd 

        For i = 0 To Grid1.Columns.Count - 1
            Grid1.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

    End Sub
    Private Sub EnableDisableMenus()
        Try
            Dim boolENBL As Boolean
            'A: strictly for each user
            Select Case Userx
                Case "USER Faculty"
                    If (UserAccessControls And (2 ^ 4)) = (2 ^ 4) Then boolENBL = True Else boolENBL = False
                    Menu_ChangePassDept.Enabled = boolENBL
                    Menu_AddStaff.Enabled = boolENBL
                    Menu_EditStaff.Enabled = boolENBL
                    Menu_AddEntry.Enabled = boolENBL
                    Menu_EditEntry.Enabled = boolENBL
                    Menu_AddDept.Enabled = boolENBL
                    Menu_AddBioProg.Enabled = boolENBL
                    Menu_EditBioProg.Enabled = boolENBL
                    Menu_ProgramSpecs.Enabled = boolENBL
                    Menu_AddCourse.Enabled = boolENBL
                    Menu_EditCourseNumber.Enabled = boolENBL
                    Menu_EditCourseSpecs.Enabled = boolENBL
                    Menu_ExportCourseList.Enabled = boolENBL
                    If (UserAccessControls And (2 ^ 4)) = (2 ^ 4) Then
                        Grid1.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
                        Menu_AddCourseFromList.Enabled = True
                    Else
                        Grid1.EditMode = DataGridViewEditMode.EditProgrammatically
                        Menu_AddCourseFromList.Enabled = False
                    End If
                Case "USER Department" ' Userx: Department | quit
                    Menu_AddDept.Enabled = False
                    Menu_AddBioProg.Enabled = False
                    Menu_EditBioProg.Enabled = False
                    Menu_EditCourseNumber.Enabled = True
                    Grid1.EditMode = DataGridViewEditMode.EditProgrammatically
                    If (UserAccessControls And (2 ^ 4)) = (2 ^ 4) Then
                        ' acc1: Courses
                        If (UserAccessControls And (2 ^ 0)) = 0 Then
                            Menu_AddEntry.Enabled = False
                            Menu_AddCourse.Enabled = False
                            Menu_EditEntry.Enabled = False
                            Menu_AddCourseFromList.Enabled = False
                            Menu_ProgramSpecs.Enabled = False
                            Menu_EditCourseSpecs.Enabled = False
                        Else
                            Menu_AddEntry.Enabled = True
                            Menu_AddCourse.Enabled = True
                            Menu_EditEntry.Enabled = True
                            Menu_AddCourseFromList.Enabled = True
                            Menu_ProgramSpecs.Enabled = True
                            Menu_EditCourseSpecs.Enabled = True
                        End If
                        ' acc2: staff
                        If (UserAccessControls And (2 ^ 1)) = 0 Then Menu_EditStaff.Enabled = False Else Menu_EditStaff.Enabled = True
                        If (UserAccessControls And (2 ^ 1)) = 0 Then Menu_AddStaff.Enabled = False Else Menu_AddStaff.Enabled = True
                        ' acc5: pass
                        If (UserAccessControls And (2 ^ 4)) = 0 Then Menu_ChangePassDept.Enabled = False Else Menu_ChangePassDept.Enabled = True
                        Menu_ExportCourseList.Enabled = True
                    Else
                        ' acc1: Courses
                        Menu_EditEntry.Enabled = False
                        Menu_AddEntry.Enabled = False
                        Menu_AddCourse.Enabled = False
                        Menu_ExportCourseList.Enabled = False
                        Menu_AddCourseFromList.Enabled = False
                        ' acc2: staff
                        Menu_EditStaff.Enabled = False
                        Menu_AddStaff.Enabled = False
                        ' acc5: pass
                        Menu_ChangePassDept.Enabled = False
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString, vbOKOnly, "گزارش خطا در اجراي نکسترم")
        End Try

    End Sub
    Private Sub Grid1_CellClick() Handles Grid1.CellClick
        DS.Tables("tblBioProgs").Clear()
        DS.Tables("tblStaff").Clear()
        DS.Tables("tblEntries").Clear()
        DS.Tables("tblCourses").Clear()

        ' A: populate BioProgs list
        Dim r As Integer = Grid1.CurrentCell.RowIndex
        If r < 0 Then Exit Sub
        intDept = Val(Grid1(0, r).Value)
        If ((Userx = "USER Department") And (intDept <> intUser)) Then
            Exit Sub
        End If

        ' READ FROM DATABASE
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT BioProgs.ID, ProgramName, ProgramSpecs, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & intDept.ToString & " ORDER BY ProgramName"
                DASS.Fill(DS, "tblBioProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT BioProgs.ID, ProgramName, ProgramSpecs, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & intDept.ToString & " ORDER BY ProgramName"
                DAAC.Fill(DS, "tblBioProgs")
        End Select
        ListBioProg.DataSource = DS.Tables("tblBioProgs")
        ListBioProg.DisplayMember = "ProgramName"
        ListBioProg.ValueMember = "ID"
        ListBioProg.Refresh()
        ListBioProg.SelectedIndex = -1
        ListBioProg.SelectedValue = 0

        ' B: populate Staff list
        'READ FROM DATABASE
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" & intDept.ToString & " ORDER BY StaffName"
                DASS.Fill(DS, "tblStaff")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT Staff.ID, StaffName, Affiliation FROM Staff INNER JOIN Departments ON Staff.Affiliation = Departments.ID WHERE Affiliation =" & intDept.ToString & " ORDER BY StaffName"
                DAAC.Fill(DS, "tblStaff")
        End Select

        ListStaff.DataSource = DS.Tables("tblStaff")
        ListStaff.DisplayMember = "StaffName"
        ListStaff.ValueMember = "ID"
        ListStaff.Refresh()
        ListStaff.SelectedIndex = -1
        ListStaff.SelectedValue = 0

    End Sub
    Private Sub Grid1_CellValueChanged() Handles Grid1.CellValueChanged
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If Userx <> "USER Faculty" Then
            MsgBox("Changes discarded", vbOK, "کاربر : گروه آموزشي")
            Exit Sub
        Else
            WriteLOG(Grid1.CurrentCell.ColumnIndex) ' cols> 1:name 2:act 3: note 4:pass 5-9:acc
            SaveChanges_Departments()
        End If

    End Sub
    Private Sub SaveChanges_Departments()

        If Grid1.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid1.CurrentCell.RowIndex
        If r < 0 Then Exit Sub

        Dim strDept As String = Grid1.Rows(r).Cells(1).Value.ToString
        DS.Tables("tblDepartments").Rows(r).Item(1) = strDept

        Dim boolActive As Boolean = Grid1.Rows(r).Cells(2).Value
        DS.Tables("tblDepartments").Rows(r).Item(2) = boolActive

        Dim strNotes As String = Grid1.Rows(r).Cells(3).Value.ToString
        DS.Tables("tblDepartments").Rows(r).Item(3) = strNotes

        Dim strPass As String = Grid1.Rows(r).Cells(4).Value.ToString
        DS.Tables("tblDepartments").Rows(r).Item(4) = strPass

        Dim bullAcc1 As Boolean = Grid1.Rows(r).Cells(5).Value
        DS.Tables("tblDepartments").Rows(r).Item(5) = bullAcc1

        Dim bullAcc2 As Boolean = Grid1.Rows(r).Cells(6).Value
        DS.Tables("tblDepartments").Rows(r).Item(6) = bullAcc2

        Dim bullAcc3 As Boolean = Grid1.Rows(r).Cells(7).Value
        DS.Tables("tblDepartments").Rows(r).Item(7) = bullAcc3

        Dim bullAcc4 As Boolean = Grid1.Rows(r).Cells(8).Value
        DS.Tables("tblDepartments").Rows(r).Item(8) = bullAcc4

        Dim bullAcc5 As Boolean = Grid1.Rows(r).Cells(9).Value
        DS.Tables("tblDepartments").Rows(r).Item(9) = bullAcc5

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Departments SET DepartmentName = @dept, DepartmentActive = @departmentactive, Notes = @notes, DepartmentPass = @departmentpass, acc1 = @acc1, acc2 = @acc2, acc3 = @acc3, acc4 = @acc4, acc5 = @acc5 WHERE ID = @ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@dept", strDept)
                cmd.Parameters.AddWithValue("@departmentactive", boolActive)
                cmd.Parameters.AddWithValue("@notes", strNotes)
                cmd.Parameters.AddWithValue("@departmentpass", strPass)
                cmd.Parameters.AddWithValue("@acc1", bullAcc1)
                cmd.Parameters.AddWithValue("@acc2", bullAcc2)
                cmd.Parameters.AddWithValue("@acc3", bullAcc3)
                cmd.Parameters.AddWithValue("@acc4", bullAcc4)
                cmd.Parameters.AddWithValue("@acc5", bullAcc5)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblDepartments").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "UPDATE Departments SET DepartmentName = @dept, DepartmentActive = @departmentactive, Notes = @notes, DepartmentPass = @departmentpass, acc1 = @acc1, acc2 = @acc2, acc3 = @acc3, acc4 = @acc4, acc5 = @acc5 WHERE ID = @ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@dept", strDept)
                cmd.Parameters.AddWithValue("@departmentactive", boolActive)
                cmd.Parameters.AddWithValue("@notes", strNotes)
                cmd.Parameters.AddWithValue("@departmentpass", strPass)
                cmd.Parameters.AddWithValue("@acc1", bullAcc1)
                cmd.Parameters.AddWithValue("@acc2", bullAcc2)
                cmd.Parameters.AddWithValue("@acc3", bullAcc3)
                cmd.Parameters.AddWithValue("@acc4", bullAcc4)
                cmd.Parameters.AddWithValue("@acc5", bullAcc5)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblDepartments").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
        End Select

    End Sub
    Private Sub Menu_AddDept_Click(sender As Object, e As EventArgs) Handles Menu_AddDept.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If Userx <> "USER Faculty" Then MsgBox("Changes discarded", vbOK, "کاربر : گروه آموزشي") : Exit Sub
        Dim myansw As DialogResult = MsgBox("يک گروه آموزشي جديد افزوده شود؟", vbQuestion + vbYesNo + vbDefaultButton2, "NexTerm")
        If myansw = vbNo Then Exit Sub

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "INSERT INTO Departments (DepartmentName, Notes) VALUES ('گروه آموزشي جديد', '-')"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "INSERT INTO Departments (DepartmentName, Notes) VALUES ('گروه آموزشي جديد', '-')"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.ExecuteNonQuery()
        End Select
        Grid1.Refresh()

        Show_DeptTable()

    End Sub
    Private Sub Menu_ChangePassDept_Click(sender As Object, e As EventArgs) Handles Menu_ChangePassDept.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Try
            Dim r As Integer = Grid1.CurrentCell.RowIndex
            If r < 0 Then MsgBox("select a row!", vbOKOnly, "NexTerm") : Exit Sub
            If (Grid1(0, Grid1.CurrentCell.RowIndex).Value = intUser Or intUser = 0) Then
                Dim strOldPass As String = Grid1(4, r).Value
                Dim strNewPass As String = InputBox("کلمه عبور جديد را وارد کنيد", "تغيير کلمه عبور", strOldPass)
                If Trim(strNewPass) = "" Then MsgBox("انصراف توسط کاربر", vbOKOnly, "نکسترم") : Exit Sub
                strOldPass = InputBox("کلمه عبور جديد را (مجددا) وارد کنيد", "تغيير کلمه عبور", "")
                If strOldPass <> strNewPass Then MsgBox("تکرار کلمه عبور نادرست بود", vbInformation + vbOKOnly, "تغيير کلمه عبور انجام نشد") : Exit Sub
                Grid1(4, r).Value = strOldPass
                MsgBox("Password changed to :   " & strOldPass, vbOKOnly, "NexTerm")
            Else
                MsgBox("نمي توانيد کلمه عبور ساير گروه ها را تغيير دهيد", vbOKOnly, "نکسترم")
            End If
        Catch ex As Exception
            'MsgBox("select a row!", vbOKOnly, "NexTerm")
        End Try

    End Sub
    Private Sub Menu_GuideDept_Click(sender As Object, e As EventArgs) Handles Menu_GuideDept.Click
        Dim hlp As String = ""
        hlp = hlp & "acc1: Courses(امکان ويرايش درس ها)" & vbCrLf
        hlp = hlp & "acc2: Staff(امکان ويرايش نام استاد / کارشناس)" & vbCrLf
        hlp = hlp & "acc3: Class (امکان تخصيص کلاس)" & vbCrLf
        hlp = hlp & "acc4: all Terms(مشاهده همه ترم هاي يک ورودي + حذف برنامه يک ورودي در يک ترم)" & vbCrLf
        hlp = hlp & "acc5: Pass (فعال بودن اکانت براي برنامه ريزي و امکان تغيير کلمه عبور)" & vbCrLf & vbCrLf & vbCrLf
        hlp = hlp & "نياز به راهنمايي بيشتر؟" & vbCrLf

        Dim myansw As DialogResult = MsgBox(hlp.ToString, vbInformation + vbYesNo + vbDefaultButton2, "نکسترم")
        If myansw = vbYes Then
            Try
                Dim pWeb As Process = New Process()
                pWeb.StartInfo.UseShellExecute = True
                pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir"
                pWeb.Start()
            Catch ex As Exception
                MsgBox("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", vbOKOnly, "مرورگر اج پيدا نشد") 'MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub Menu_OKDept_Click(sender As Object, e As EventArgs) Handles Menu_OKDept.Click
        btnExit.Focus()
        Dim r As Integer = Grid1.SelectedCells(0).RowIndex
        intDept = Val(Grid1(0, r).Value)
        strDept = Grid1(1, r).Value

        Me.Dispose()

    End Sub
    Private Sub Menu_CancelDept_Click(sender As Object, e As EventArgs) Handles Menu_CancelDept.Click
        btnExit.Focus()
        intDept = 0
        strDept = ""

        Me.Dispose()

    End Sub

    ' STAFF
    Private Sub ListStaff_DoubleClick(sender As Object, e As EventArgs) Handles ListStaff.DoubleClick
        Menu_OKStaff_Click(sender, e)
    End Sub
    Private Sub Menu_AddStaff_Click(sender As Object, e As EventArgs) Handles Menu_AddStaff.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If Grid1.CurrentCell.RowIndex < 0 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("استاد جديد به اين گروه افزوده شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        If myansw = vbYes Then
            strStaff = InputBox("نام استاد را وارد کنيد", "NexTerm", " استاد جديد ")
            If Trim(strStaff) = "" Then
                Exit Sub
            Else
                Try
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            strSQL = "INSERT INTO Staff (StaffName, StaffCode, Affiliation, Notes) VALUES (@staffname, 0, @affiliation, '-')"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@staffname", strStaff).ToString()
                            cmd.Parameters.AddWithValue("@affiliation", intDept).ToString()
                            Dim i As Integer
                            i = cmd.ExecuteNonQuery()
                        Case "Access"
                            strSQL = "INSERT INTO Staff (StaffName, StaffCode, Affiliation, Notes) VALUES (@staffname, 0, @affiliation, '-')"
                            Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@staffname", strStaff.ToString)
                            cmd.Parameters.AddWithValue("@affiliation", intDept.ToString)
                            Dim i As Integer
                            i = cmd.ExecuteNonQuery()
                    End Select
                    ListStaff.Refresh()
                    Grid1_CellClick()
                    WriteLOG(10)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If

    End Sub
    Private Sub Menu_EditStaff_Click(sender As Object, e As EventArgs) Handles Menu_EditStaff.Click
        'Edit
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim myansw As DialogResult = MsgBox("نام استاد ويرايش شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        strStaff = ListStaff.Text
        Dim r As Integer = ListStaff.SelectedValue
        If myansw = vbYes Then
            strStaff = InputBox("نام استاد را تصحيح کنيد", "NexTerm", strStaff)
            If strStaff = "" Then
                Exit Sub
            Else
                Try
                    DS.Tables("tblStaff").Rows(ListStaff.SelectedIndex).Item(1) = strStaff
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            strSQL = "UPDATE Staff SET StaffName = @staffname WHERE ID = @id"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@staffname", strStaff.ToString)
                            cmd.Parameters.AddWithValue("@id", r.ToString)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Case "Access"
                            strSQL = "UPDATE Staff SET StaffName = @staffname WHERE ID = @id"
                            Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@staffname", strStaff.ToString)
                            cmd.Parameters.AddWithValue("@id", r.ToString)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                    End Select
                    Grid1_CellClick()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            End If
            WriteLOG(11)
        End If

    End Sub
    Private Sub Menu_DelStaff_Click(sender As Object, e As EventArgs) Handles Menu_DelStaff.Click
        MsgBox("امکان حذف نام استاد اکنون وجود ندارد", vbOKOnly, "نکسترم")

    End Sub
    Private Sub Menu_OKStaff_Click(sender As Object, e As EventArgs) Handles Menu_OKStaff.Click
        strStaff = ListStaff.Text
        intStaff = ListStaff.SelectedValue
        Me.Dispose()
    End Sub
    Private Sub Menu_CancelStaff_Click(sender As Object, e As EventArgs) Handles Menu_CancelStaff.Click
        strStaff = ""
        intStaff = 0
        Me.Dispose()

    End Sub


    ' BIOPROG 
    Private Sub ListBioProg_DoubleClick(sender As Object, e As EventArgs) Handles ListBioProg.DoubleClick
        Menu_OKBioProg_Click(sender, e)
    End Sub
    Private Sub Menu_AddBioProg_Click(sender As Object, e As EventArgs) Handles Menu_AddBioProg.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If Grid1.CurrentCell.RowIndex < 0 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("دوره آموزشي جديد به اين گروه افزوده شود؟", vbYesNo + vbDefaultButton2, "نکسترم")
        If myansw = vbYes Then
            strBioProg = InputBox("نام دوره را وارد کنيد", "NexTerm", " دوره جديد ")
            If Trim(strBioProg) = "" Then
                Exit Sub
            Else
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO BioProgs (ProgramName, Department_ID) VALUES (@programname, @departmentid)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@programname", strBioProg.ToString)
                        cmd.Parameters.AddWithValue("@departmentid", intDept.ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "INSERT INTO BioProgs (ProgramName, Department_ID) VALUES (@programname, @departmentid)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@programname", strBioProg.ToString)
                        cmd.Parameters.AddWithValue("@departmentid", intDept.ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select
                ListBioProg.Refresh()
                WriteLOG(12)
            End If
        End If
        Grid1_CellClick()

    End Sub
    Private Sub Menu_EditBioProg_Click(sender As Object, e As EventArgs) Handles Menu_EditBioProg.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim r As Integer = ListBioProg.SelectedIndex
        If r = -1 Then Exit Sub
        intBioProg = ListBioProg.SelectedValue
        strBioProg = ListBioProg.Text
        strBioProg = InputBox("نام دوره آموزشی", "وارد کنید", strBioProg)
        If strBioProg.Trim = "" Then
            Exit Sub
        End If
        Try
            DS.Tables("tblBioProgs").Rows(r).Item(1) = strBioProg
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE BioProgs SET ProgramName = @programname WHERE ID = @id"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@programname", strBioProg.ToString)
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblBioProgs").Rows(r).Item(0))
                    Dim i As Integer = cmd.ExecuteNonQuery
                Case "Access"
                    strSQL = "UPDATE BioProgs SET ProgramName = @programname WHERE ID = @id"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@programname", strBioProg.ToString)
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblBioProgs").Rows(r).Item(0))
                    Dim i As Integer = cmd.ExecuteNonQuery
            End Select
            WriteLOG(13)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Grid1_CellClick()

    End Sub
    Private Sub Menu_ProgramSpecs_Click(sender As Object, e As EventArgs) Handles Menu_ProgramSpecs.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim r As Integer = ListBioProg.SelectedIndex
        If r = -1 Then Exit Sub

        Retval1 = 1                                          '{1:BioProgs | 2:Courses}
        Retval2 = DS.Tables("tblBioProgs").Rows(r).Item(2)   '{data : in bits}

        frmSpecs.ShowDialog()

        If Retval1 = 1 Then 'retval1 {0:Cancelled , 1:OK}
            DS.Tables("tblBioProgs").Rows(r).Item(2) = Retval2
            Try
                DS.Tables("tblBioProgs").Rows(r).Item(1) = strBioProg
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE BioProgs SET ProgramSpecs = @programspecs WHERE ID = @id"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@programspecs", Retval2.ToString)
                        cmd.Parameters.AddWithValue("@id", DS.Tables("tblBioProgs").Rows(r).Item(0))
                        Dim i As Integer = cmd.ExecuteNonQuery
                    Case "Access"
                        strSQL = "UPDATE BioProgs SET ProgramSpecs = @programspecs WHERE ID = @id"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@programspecs", Retval2.ToString)
                        cmd.Parameters.AddWithValue("@id", DS.Tables("tblBioProgs").Rows(r).Item(0))
                        Dim i As Integer = cmd.ExecuteNonQuery
                End Select
                WriteLOG(13)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Grid1_CellClick()
        Else
            Exit Sub
        End If

    End Sub
    Private Sub Menu_OKBioProg_Click(sender As Object, e As EventArgs) Handles Menu_OKBioProg.Click
        'BioProg
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        strBioProg = ListBioProg.Text
        intBioProg = ListBioProg.SelectedValue
        'Department
        strDept = Grid1(1, Retval1).Value
        'intDept = ... already set
        Me.Dispose()

    End Sub
    Private Sub Menu_CancelBioProg_Click(sender As Object, e As EventArgs) Handles Menu_CancelBioProg.Click
        strBioProg = ""
        intBioProg = 0
        Me.Dispose()

    End Sub

    Private Sub ListBioProg_Click() Handles ListBioProg.Click
        ' populate Grid_Entry
        If ListBioProg.SelectedIndex < 0 Then Exit Sub
        ShowEntries()
        ShowCourses()
    End Sub
    Private Sub ShowEntries()
        ' populate Grid_Entry
        If Grid1.CurrentCell.RowIndex < 0 Then Exit Sub
        Dim i As String = ListBioProg.GetItemText(ListBioProg.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        'READ FROM DATABASE
        Try
            DS.Tables("tblEntries").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS = New SqlClient.SqlDataAdapter("SELECT Entries.ID AS EntID, CONCAT(Entries.EntYear , ' - ' , BioProgs.ProgramName) AS Prog, Entries.BioProg_ID, Entries.EntYear As Yr, Entries.StudentCount As STDs, Entries.Active, Entries.Notes FROM (Entries INNER JOIN  BioProgs ON Entries.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & i.ToString & " ORDER BY EntYear, ProgramName", CnnSS)
                    DASS.Fill(DS, "tblEntries")
                Case "Access"
                    DAAC = New OleDb.OleDbDataAdapter("SELECT Entries.ID AS EntID, Entries.EntYear & ' - ' & BioProgs.ProgramName AS Prog, Entries.BioProg_ID, Entries.EntYear As Yr, Entries.StudentCount As STDs, Entries.Active, Entries.Notes FROM (Entries INNER JOIN  BioProgs ON Entries.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & i.ToString & " ORDER BY EntYear, ProgramName", CnnAC)
                    DAAC.Fill(DS, "tblEntries")
            End Select

            GridEntries.DataSource = DS.Tables("tblEntries")
            GridEntries.Refresh()
            GridEntries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            GridEntries.Columns(0).Width = 0   'EntID
            GridEntries.Columns(1).Width = 0   'TEXT
            GridEntries.Columns(2).Width = 0   'BioProgID
            GridEntries.Columns(3).Width = 50  'EntYear
            GridEntries.Columns(4).Width = 50  'StudentCount
            GridEntries.Columns(5).Width = 50  'Active
            GridEntries.Columns(6).Width = 200 'Notes

            GridEntries.Columns(0).Visible = False
            GridEntries.Columns(1).Visible = False
            GridEntries.Columns(2).Visible = False

            For k = 0 To GridEntries.Columns.Count - 1
                GridEntries.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
            Next k

        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Err was in ShowEntries")
            Exit Sub
        End Try
        GridEntries.Focus()

    End Sub
    Private Sub ShowCourses()
        'ComboBioProg -> Populates GridCourse
        If Grid1.CurrentCell.RowIndex < 0 Then Exit Sub
        Dim i As String = ListBioProg.GetItemText(ListBioProg.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        'READ FROM DATABASE
        intBioProg = Val(i)
        'READ FROM DATABASE
        DS.Tables("tblCourses").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT Courses.ID, CourseName, CourseNumber, CourseSpecs, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & intBioProg.ToString & " ORDER BY CourseName"
                DASS.Fill(DS, "tblCourses")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT Courses.ID, CourseName, CourseNumber, CourseSpecs, Units FROM (Courses INNER JOIN BioProgs ON Courses.BioProg_ID = BioProgs.ID) WHERE BioProg_ID =" & intBioProg.ToString & " ORDER BY CourseName"
                DAAC.Fill(DS, "tblCourses")
        End Select

        GridCourse.DataSource = DS.Tables("tblCourses")
        GridCourse.Refresh()

        GridCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridCourse.Columns(0).Width = 0    'ID
        GridCourse.Columns(1).Width = 220  'Course
        GridCourse.Columns(2).Width = 80   'Number
        GridCourse.Columns(3).Width = 0    'Specs
        GridCourse.Columns(4).Width = 40   'Units

        GridCourse.Columns(0).Visible = False 'ID
        GridCourse.Columns(3).Visible = False 'Specs

        For k = 0 To GridCourse.Columns.Count - 1
            GridCourse.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
        Next k

    End Sub


    ' ENTRY
    Private Sub GridEntries_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridEntries.CellValueChanged
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridEntries.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridEntries.CurrentCell.RowIndex   'count from 0
        Dim c As Integer = GridEntries.CurrentCell.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub

        GridEntries.CurrentCell = GridEntries(3, r)

        Dim intYear As Integer = GridEntries.Rows(r).Cells(3).Value
        DS.Tables("tblEntries").Rows(r).Item(3) = intYear

        Dim intStudents As Integer = GridEntries.Rows(r).Cells(4).Value
        DS.Tables("tblEntries").Rows(r).Item(4) = intStudents

        Dim boolActive As Integer = GridEntries.Rows(r).Cells(5).Value
        DS.Tables("tblEntries").Rows(r).Item(5) = boolActive

        Dim strNotes As String = GridEntries.Rows(r).Cells(6).Value.ToString
        DS.Tables("tblEntries").Rows(r).Item(6) = strNotes
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE Entries SET EntYear = @entyear, StudentCount = @studentcount, Active = @active, Notes = @notes WHERE ID = @ID"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@entyear", Val(intYear))
                    cmd.Parameters.AddWithValue("@studentcount", intStudents)
                    cmd.Parameters.AddWithValue("@active", boolActive)
                    cmd.Parameters.AddWithValue("@notes", strNotes)
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblEntries").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "UPDATE Entries SET EntYear = @entyear, StudentCount = @studentcount, Active = @active, Notes = @notes WHERE ID = @ID"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@entyear", intYear)
                    cmd.Parameters.AddWithValue("@studentcount", intStudents)
                    cmd.Parameters.AddWithValue("@active", boolActive)
                    cmd.Parameters.AddWithValue("@notes", strNotes)
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblEntries").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Menu_AddEntry_Click(sender As Object, e As EventArgs) Handles Menu_AddEntry.Click
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If Grid1.CurrentCell.RowIndex < 0 Then Exit Sub
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        intBioProg = Int(Val(ListBioProg.SelectedValue))
        Dim intEntYear As Integer = Val(InputBox("سال ورود به دوره آموزشي", "NexTerm", "1401"))
        If intEntYear = 0 Then
            MsgBox("سال معتبر نيست", vbInformation, "توجه")
            Exit Sub
        End If

        ' //ADD CODES HERE TO CHECK IF EntYear IS NEW FOR THIS Entry IN THIS BioProg ----------- do it -----------

        Dim intStudentCount As Integer = 5
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "INSERT INTO Entries (BioProg_ID, EntYear, StudentCount) VALUES (@bioprogid, @entyear, @studentcount)"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@bioprogid", Val(intBioProg))
                cmd.Parameters.AddWithValue("@entyear", Val(intEntYear))
                cmd.Parameters.AddWithValue("@studentcount", Val(intStudentCount))
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    ShowEntries()
                End Try
            Case "Access"
                strSQL = "INSERT INTO Entries (BioProg_ID, EntYear, StudentCount) VALUES (@bioprogid, @entyear, @studentcount)"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@bioprogid", Val(intBioProg))
                cmd.Parameters.AddWithValue("@entyear", Val(intEntYear))
                cmd.Parameters.AddWithValue("@studentcount", Val(intStudentCount))
                Try
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    ShowEntries()
                End Try
        End Select
        WriteLOG(14)

    End Sub
    Private Sub GridEntries_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridEntries.CellDoubleClick
        Select Case Userx
            Case "USER Department"
                Menu_EditEntry_Click(sender, e)
                '//Menu_OKEntry_Click(sender, e)
                Exit Sub
            Case "USER Faculty"
                If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
                Menu_EditEntry_Click(sender, e)
        End Select

    End Sub
    Private Sub Menu_EditEntry_Click(sender As Object, e As EventArgs) Handles Menu_EditEntry.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridEntries.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridEntries.SelectedCells(0).RowIndex    'count from 0
        Dim c As Integer = GridEntries.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Try
            Select Case c
                Case 3, 4 ' Yr, Cnt
                    Dim strValue As String = GridEntries(c, r).Value
                    strValue = InputBox("مقدار جديد را وارد کنيد", "نکسترم", strValue)
                    If Val(strValue) = 0 Then Exit Sub
                    GridEntries(c, r).Value = Trim(strValue)
                    WriteLOG(15)
                Case 5 'ACTIVE
                    If GridEntries(c, r).Value = True Then
                        GridEntries(c, r).Value = False
                    Else
                        GridEntries(c, r).Value = True
                    End If
                    WriteLOG(16)
                Case 6 ' Note
                    Dim strValue As String = GridEntries(c, r).Value
                    strValue = InputBox("يادداشت جديد را وارد کنيد", "نکسترم", strValue)
                    If Trim(strValue) = "" Then Exit Sub
                    GridEntries(c, r).Value = Trim(strValue)
                    WriteLOG(17)
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Menu_OKEntry_Click(sender As Object, e As EventArgs) Handles Menu_OKEntry.Click
        If GridEntries.Rows.Count > 0 Then
            Dim r As Integer = GridEntries.CurrentRow.Index
            ' Department
            intDept = Grid1(0, r).Value
            strDept = Grid1(1, r).Value
            ' BioProg
            ListBioProg.Focus() 'to save changes
            intBioProg = ListBioProg.SelectedValue
            strBioProg = ListBioProg.Text
            ' Entry
            intEntry = DS.Tables("tblEntries").Rows(r).Item(0)
            strEntry = DS.Tables("tblEntries").Rows(r).Item(1)
            intYearEntered = DS.Tables("tblEntries").Rows(r).Item(3)

            Me.Close()
            Me.Dispose()
        Else
            Exit Sub
        End If

    End Sub
    Private Sub Menu_CancelEntry_Click(sender As Object, e As EventArgs) Handles Menu_CancelEntry.Click
        ListBioProg.Focus() 'to save changes
        intEntry = 0
        strEntry = ""
        Me.Close()
        Me.Dispose()
    End Sub

    ' COURSE
    Private Sub GridCourse_CellDoubleClick() Handles GridCourse.CellDoubleClick
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim r As Integer = GridCourse.SelectedCells(0).RowIndex    'count from 0
        Dim c As Integer = GridCourse.SelectedCells(0).ColumnIndex 'count from 0
        If GridCourse.RowCount < 1 Then Exit Sub
        If r < 0 Or c < 0 Then Exit Sub

        If Userx = "USER Department" And c = 1 Then
            Menu_OKCourse_Click() 'Return A COURSE
            Exit Sub
        Else
            Dim strValue As String = GridCourse(c, r).Value
            strValue = InputBox("مقدار جديد را وارد کنيد", "نکسترم", strValue)
            Try
                Select Case c
                    Case 1 'Course Name
                        If Trim(strValue) = "" Then Exit Sub
                        Dim myansw As DialogResult = MsgBox("نام درس را به " & vbCrLf & strValue & vbCrLf & "تغيير مي دهيد؟", vbYesNo + vbDefaultButton2, "نکسترم: توجه: در حال ويرايش نام درس هستيد")
                        If myansw = vbNo Then Exit Sub
                        GridCourse(c, r).Value = strValue
                        WriteLOG(18)
                    Case 2, 4 ' Number, Unit
                        If Val(strValue) = 0 Then Exit Sub
                        GridCourse(c, r).Value = strValue
                        If c = 2 Then
                            WriteLOG(19)
                        ElseIf c = 4 Then
                            WriteLOG(20)
                        End If
                End Select
                GridCourse_CellValueChanged()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub GridCourse_CellValueChanged()
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridCourse.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCourse.CurrentCell.RowIndex   'count from 0
        If r < 0 Then Exit Sub
        GridCourse.CurrentCell = GridCourse(1, r)

        Dim strCourseName As String = GridCourse.Rows(r).Cells(1).Value
        DS.Tables("tblCourses").Rows(r).Item(1) = strCourseName

        Dim intCourseNumber As Integer = GridCourse.Rows(r).Cells(2).Value
        DS.Tables("tblCourses").Rows(r).Item(2) = intCourseNumber

        Dim intCourseSpecs As Integer = GridCourse.Rows(r).Cells(3).Value
        DS.Tables("tblCourses").Rows(r).Item(3) = intCourseSpecs

        Dim intCourseUnits As Integer = GridCourse.Rows(r).Cells(4).Value
        DS.Tables("tblCourses").Rows(r).Item(4) = intCourseUnits
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Coursespecs = @coursespecs, Units = @units WHERE ID = @ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@coursename", strCourseName)
                cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber)
                cmd.Parameters.AddWithValue("@coursespecs", intCourseSpecs)
                cmd.Parameters.AddWithValue("@units", intCourseUnits)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblCourses").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "UPDATE Courses SET CourseName = @coursename, CourseNumber = @coursenumber, Coursespecs = @coursespecs, Units = @units WHERE ID = @ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@coursename", strCourseName)
                cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber)
                cmd.Parameters.AddWithValue("@coursespecs", intCourseSpecs)
                cmd.Parameters.AddWithValue("@units", intCourseUnits)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblCourses").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
        End Select

    End Sub
    Private Sub Menu_AddCourse_Click() Handles Menu_AddCourse.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("درس جديد به اين دوره آموزشي افزوده شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        If myansw = vbYes Then
            intCourseNumber = Val(InputBox("شماره درس", "NexTerm", "123456789"))
            strCourse = InputBox("نام درس را وارد کنيد", "NexTerm", " درس جديد " & ListBioProg.Text)
            If strCourse = "" Then
                Exit Sub
            Else
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, CourseSpecs, Units) VALUES (@bioprogid, @coursename, @coursenumber, 2, 2)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@bioprogid", ListBioProg.SelectedValue)
                        cmd.Parameters.AddWithValue("@coursename", strCourse)
                        cmd.Parameters.AddWithValue("@coursenumber", Str(intCourseNumber))
                        Dim i As Integer
                        Try
                            i = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("error: " & ex.ToString)
                        End Try
                    Case "Access"
                        strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, CourseSpecs, Units) VALUES (@bioprogid, @coursename, @coursenumber, 2, 2)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@bioprogid", ListBioProg.SelectedValue)
                        cmd.Parameters.AddWithValue("@coursename", strCourse)
                        cmd.Parameters.AddWithValue("@coursenumber", Str(intCourseNumber))
                        Dim i As Integer
                        Try
                            i = cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("error: " & ex.ToString)
                        End Try
                End Select
            End If
            ListBioProg_Click()
            '//GridCourse.Refresh()
        End If

    End Sub
    Private Sub Menu_AddCourseFromList_Click(sender As Object, e As EventArgs) Handles Menu_AddCourseFromList.Click
        'Add List of Courses from textfile to a BioProg
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        intBioProg = ListBioProg.SelectedValue

        TempList.ShowDialog()

        ListBioProg_Click()
        GridCourse.Refresh()

    End Sub
    Private Sub Menu_EditCourseNumber_Click(sender As Object, e As EventArgs) Handles Menu_EditCourseNumber.Click
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        If GridCourse.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCourse.CurrentCell.RowIndex   'count from 0
        If r < 0 Then Exit Sub
        strCourse = ""
        intCourseNumber = 0
        intCourseNumber = Val(InputBox("شماره درس را تصحيح کنيد", "نکسترم", GridCourse(2, r).Value))
        If intCourseNumber = 0 Then
            Exit Sub
        Else
            GridCourse(2, r).Value = intCourseNumber
            GridCourse_CellValueChanged()
            WriteLOG(19)
        End If

    End Sub
    Private Sub Menu_EditCourseSpecs_Click(sender As Object, e As EventArgs) Handles Menu_EditCourseSpecs.Click
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        If GridCourse.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCourse.CurrentCell.RowIndex   'count from 0
        If r < 0 Then Exit Sub
        Retval1 = 2 '{1:BioProgs | 2:Courses}
        Retval2 = DS.Tables("tblCourses").Rows(r).Item(3)    '{data : in bits}
        frmSpecs.ShowDialog()
        'Retval2: data , Retval1:{OK|Cancel}
        If Retval1 = 1 Then
            GridCourse(3, r).Value = Retval2.ToString
            DS.Tables("tblCourses").Rows(r).Item(3) = Retval2
            GridCourse_CellValueChanged()
            ListBioProg_Click()
        Else
            Exit Sub
        End If

    End Sub
    Private Sub Menu_ExportCourseList_Click(sender As Object, e As EventArgs) Handles Menu_ExportCourseList.Click
        'Export
        FileClose(1)
        Using dialog As New SaveFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "Nexterm Course List|*.txt"}
            If dialog.ShowDialog = DialogResult.OK Then
                strFilename = dialog.FileName
            Else
                Me.Dispose()
                Exit Sub
            End If
        End Using
        FileOpen(1, strFilename, OpenMode.Output)
        PrintLine(1, "NexTerm Courses")
        For i As Integer = 0 To GridCourse.Rows.Count - 1
            PrintLine(1, GridCourse.Item(1, i).Value) 'CourseName
            PrintLine(1, GridCourse.Item(2, i).Value) 'CourseNumber
            PrintLine(1, GridCourse.Item(3, i).Value) 'CourseSpecs
            PrintLine(1, GridCourse.Item(4, i).Value) 'CourseUnits
        Next i
        FileClose(1)
        MsgBox("ليست درس ذخيره شد" & vbCrLf & strFilename, vbOKOnly, "نکسترم")

    End Sub
    Private Sub Menu_OKCourse_Click() Handles Menu_OKCourse.Click
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
    Private Sub Menu_CancelCourse_Click(sender As Object, e As EventArgs) Handles Menu_CancelCourse.Click
        strCourse = ""
        intCourse = 0
        Me.Dispose()

    End Sub

    'remember: ADD trigger to subs
    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG
            'Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
            Dim timeZoneInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
            Dim strDateTime As String = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo).ToString("yyyy.MM.dd - HH:mm:ss")

            Dim intUserID As Integer = intUser
            Dim strNickName As String = UserNickName
            Dim strClientName As String = LCase(Environment.MachineName)
            Dim strFrontEnd As String = LCase(strBuildInfo)
            Dim strLog As String = ""
            Select Case intActivity
                Case 0 : strLog = "resources"
                Case 1 : strLog = "dpt.name?; dpt:" & intDept.ToString
                Case 2 : strLog = "dpt.actv?; dpt:" & intDept.ToString
                Case 3 : strLog = "dpt.note?; dpt:" & intDept.ToString
                Case 4 : strLog = "dpt.pswd?; dpt:" & intDept.ToString
                Case 5 : strLog = "dpt.acc1?; dpt:" & intDept.ToString
                Case 6 : strLog = "dpt.acc2?; dpt:" & intDept.ToString
                Case 7 : strLog = "dpt.acc3?; dpt:" & intDept.ToString
                Case 8 : strLog = "dpt.acc4?; dpt:" & intDept.ToString
                Case 9 : strLog = "dpt.acc5?; dpt:" & intDept.ToString

                Case 10 : strLog = "staff+; dpt:" & intDept.ToString
                Case 11 : strLog = "staff?; dpt:" & intDept.ToString

                Case 12 : strLog = "prg+; prg:" & intBioProg.ToString
                Case 13 : strLog = "prg?; prg:" & intBioProg.ToString

                Case 14 : strLog = "ent?; ent:" & intEntry.ToString
                Case 15 : strLog = "ent.yr/cnt?; ent:" & intEntry.ToString
                Case 16 : strLog = "ent.actv?; ent:" & intEntry.ToString
                Case 17 : strLog = "ent.note?; ent:" & intEntry.ToString

                Case 18 : strLog = "crs?:" & strCourse
                Case 19 : strLog = "crs.nr?:" & intCourseNumber.ToString
                Case 20 : strLog = "crs.unt?:" & intCourseNumber.ToString
            End Select

            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Try
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", intUserID.ToString)
                        cmdx.Parameters.AddWithValue("@nickname", strNickName)
                        cmdx.Parameters.AddWithValue("@clientname", strClientName)
                        cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                        cmdx.Parameters.AddWithValue("@strlog", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString) 'Do Nothing!
                    End Try
                Case "Access"
                    Try
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", intUserID.ToString)
                        cmdx.Parameters.AddWithValue("@nickname", strNickName)
                        cmdx.Parameters.AddWithValue("@clientname", strClientName)
                        cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                        cmdx.Parameters.AddWithValue("@strlog", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString) 'Do Nothing!
                    End Try
            End Select

        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        btnExit.Focus()
        intDept = 0
        strDept = ""
        intStaff = 0
        intBioProg = 0
        intEntry = 0
        Me.Dispose()

    End Sub

End Class