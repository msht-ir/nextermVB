Public Class ChooseEntry

    Private Sub ChooseEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridEntries.EditMode = DataGridViewEditMode.EditProgrammatically
        If Userx = "USER Department" Then
            MenuAddNewEntry.Enabled = False
        End If

        'Fill ComboBox1 (Depts)
        ComboDepts.DataSource = DS.Tables("tblDepartments")
        ComboDepts.DisplayMember = "DEPT"
        ComboDepts.ValueMember = "ID"
        ComboDepts.SelectedValue = intDept
        Try
            ListBioProgs.SelectedValue = intBioProg
            ListBioProgs_Click(sender, e)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub ComboDepts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboDepts.SelectedIndexChanged
        'ComboDept -> Populates ListOfEntries
        Dim i As String = ComboDepts.GetItemText(ComboDepts.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        'READ FROM DATABASE
        DS.Tables("tblBioProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS = New SqlClient.SqlDataAdapter("SELECT BioProgs.ID, ProgramName, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & i.ToString & " ORDER BY ProgramName", CnnSS)
                DASS.Fill(DS, "tblBioProgs")
            Case "Access"
                DAAC = New OleDb.OleDbDataAdapter("SELECT BioProgs.ID, ProgramName, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & i.ToString & " ORDER BY ProgramName", CnnAC)
                DAAC.Fill(DS, "tblBioProgs")
        End Select

        ListBioProgs.DataSource = DS.Tables("tblBioProgs")
        ListBioProgs.DisplayMember = "ProgramName"
        ListBioProgs.ValueMember = "BioProgs.ID"
        ListBioProgs.Refresh()
        ListBioProgs.SelectedIndex = -1
        ListBioProgs.SelectedValue = 0
        DS.Tables("tblEntries").Clear()

    End Sub

    Private Sub ListBioProgs_Click(sender As Object, e As EventArgs) Handles ListBioProgs.Click
        'ComboBioProg -> Populates GridEntry
        ShowEntries()

    End Sub

    Private Sub ShowEntries()
        'ComboBioProg -> Populates GridEntry
        If ComboDepts.SelectedIndex = -1 Then Exit Sub
        Dim i As String = ListBioProgs.GetItemText(ListBioProgs.SelectedValue)
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
            GridEntries.Columns(6).Width = 250 'Notes

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

    Private Sub GridEntries_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridEntries.CellValueChanged
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
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

    Private Sub MenuAddNewEntry_Click(sender As Object, e As EventArgs) Handles MenuAddNewEntry.Click
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ComboDepts.SelectedIndex = -1 Then Exit Sub
        If ListBioProgs.SelectedIndex = -1 Then Exit Sub
        intBioProg = Int(Val(ListBioProgs.SelectedValue))
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

    End Sub

    Private Sub GridEntries_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridEntries.CellDoubleClick
        Select Case Userx
            Case "USER Department"
                MenuOK_Click(sender, e)
                Exit Sub
            Case "USER Faculty"
                If GridEntries.RowCount < 1 Then Exit Sub
                Dim r As Integer = GridEntries.SelectedCells(0).RowIndex    'count from 0
                Dim c As Integer = GridEntries.SelectedCells(0).ColumnIndex 'count from 0
                If r < 0 Or c < 0 Then Exit Sub

                Try
                    Select Case c
                        Case 3, 4 ' Yr, Cnt
                            If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
                            Dim strValue As String = GridEntries(c, r).Value
                            strValue = InputBox("مقدار جديد را وارد کنيد", "نکسترم", strValue)
                            If Val(strValue) = 0 Then Exit Sub
                            GridEntries(c, r).Value = Trim(strValue)
                        Case 5 'ACTIVE
                            If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
                            If GridEntries(c, r).Value = True Then
                                GridEntries(c, r).Value = False
                            Else
                                GridEntries(c, r).Value = True
                            End If
                        Case 6 ' Note
                            Dim strValue As String = GridEntries(c, r).Value
                            strValue = InputBox("يادداشت جديد را وارد کنيد", "نکسترم", strValue)
                            If Trim(strValue) = "" Then Exit Sub
                            GridEntries(c, r).Value = Trim(strValue)
                    End Select
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select


    End Sub
    Private Sub MenuOK_Click(sender As Object, e As EventArgs) Handles MenuOK.Click
        If GridEntries.Rows.Count > 0 Then
            Dim r As Integer = GridEntries.CurrentRow.Index
            ' Department
            intDept = ComboDepts.SelectedValue
            strDept = ComboDepts.Text
            ' BioProg
            ListBioProgs.Focus() 'to save changes
            intBioProg = ListBioProgs.SelectedValue
            strBioProg = ListBioProgs.Text
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

    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        ListBioProgs.Focus() 'to save changes
        intEntry = 0
        strEntry = ""
        Me.Close()
        Me.Dispose()

    End Sub

End Class