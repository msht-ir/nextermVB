Public Class ChooseBioProg
    Private Sub ChooseBioProg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Userx = "USER Department") Then
            MenuEditThisProg.Enabled = False
            MenuAddNewProg.Enabled = False
        End If

        'Fill ComboBox (Depts)
        ListDepts.DataSource = DS.Tables("tblDepartments")
        ListDepts.DisplayMember = "DEPT"
        ListDepts.ValueMember = "ID"
        ListDepts.SelectedValue = intDept

    End Sub
    Private Sub ListDepts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListDepts.SelectedIndexChanged
        'ListDepts -> Populates ListStaff
        DS.Tables("tblBioProgs").Clear()
        Dim i As String = ListDepts.GetItemText(ListDepts.SelectedValue)
        If Val(i) = 0 Then Exit Sub
        If (Userx = "USER Department") And (ListDepts.SelectedValue <> intUser) Then Exit Sub

        ' READ FROM DATABASE
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT BioProgs.ID, ProgramName, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & i.ToString & " ORDER BY ProgramName"
                DASS.Fill(DS, "tblBioProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT BioProgs.ID, ProgramName, Department_ID FROM BioProgs INNER JOIN Departments ON BioProgs.Department_ID = Departments.ID WHERE Department_ID =" & i.ToString & " ORDER BY ProgramName"
                DAAC.Fill(DS, "tblBioProgs")
        End Select

        ListBioProg.DataSource = DS.Tables("tblBioProgs")
        ListBioProg.DisplayMember = "ProgramName"
        ListBioProg.ValueMember = "ID"
        ListBioProg.Refresh()
        ListBioProg.SelectedIndex = -1
        ListBioProg.SelectedValue = 0

    End Sub

    Private Sub ListBioProg_DoubleClick(sender As Object, e As EventArgs) Handles ListBioProg.DoubleClick
        MenuOK_Click(sender, e)

    End Sub


    Private Sub MenuEditThisProg_Click(sender As Object, e As EventArgs) Handles MenuEditThisProg.Click
        If (Userx = "USER Department") Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
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
                    cmd.Parameters.AddWithValue("@programname", strBioProg)
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblBioProgs").Rows(r).Item(0))
                    Dim i As Integer = cmd.ExecuteNonQuery
                Case "Access"
                    strSQL = "UPDATE BioProgs SET ProgramName = @programname WHERE ID = @id"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@programname", strBioProg)
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblBioProgs").Rows(r).Item(0))
                    Dim i As Integer = cmd.ExecuteNonQuery
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ListDepts_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub MenuAddNewProg_Click(sender As Object, e As EventArgs) Handles MenuAddNewProg.Click
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ListDepts.SelectedIndex = -1 Then Exit Sub
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
                        cmd.Parameters.AddWithValue("@programname", strBioProg)
                        cmd.Parameters.AddWithValue("@departmentid", ListDepts.SelectedValue)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "INSERT INTO BioProgs (ProgramName, Department_ID) VALUES (@programname, @departmentid)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@programname", strBioProg)
                        cmd.Parameters.AddWithValue("@departmentid", ListDepts.SelectedValue)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select
                ListBioProg.Refresh()
            End If
        End If
        ListDepts_SelectedIndexChanged(sender, e)

    End Sub

    Private Sub MenuOK_Click(sender As Object, e As EventArgs) Handles MenuOK.Click
        'BioProg
        If ListBioProg.SelectedIndex = -1 Then Exit Sub
        strBioProg = ListBioProg.Text
        intBioProg = ListBioProg.SelectedValue
        'Department
        strDept = ListDepts.Text
        intDept = ListDepts.SelectedValue
        Me.Dispose()

    End Sub

    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        strBioProg = ""
        intBioProg = 0
        Me.Dispose()

    End Sub

    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG
            Dim strLog As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss") & " -usr:" & intUser.ToString & " -nck:" & UserNickName & " -clnt:'" & LCase(Environment.MachineName) & "'"
            Select Case intActivity
                Case 3 : strLog = strLog & " > prg+; dpt:" & ListDepts.SelectedValue.ToString
                Case 4 : strLog = strLog & " > prg?; dpt:" & ListDepts.SelectedValue.ToString
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

End Class