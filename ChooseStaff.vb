Public Class ChooseStaff
    Private Sub ChooseStaff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Userx = "USER Department" Then
            MenuAddNew.Enabled = False
            Menu_DelStaff.Enabled = False
            MenuEdit.Enabled = False
        End If

        ListDepts.DataSource = DS.Tables("tblDepartments")
        ListDepts.DisplayMember = "DEPT"
        ListDepts.ValueMember = "ID"
        ListDepts.SelectedValue = intDept
        ListDepts_Click()

    End Sub

    Private Sub ListDepts_Click() Handles ListDepts.Click
        Try
            'ComboDept -> Populates ListStaff
            Dim i As String = ListDepts.GetItemText(ListDepts.SelectedValue)
            If Val(i) = 0 Then Exit Sub
            If DS.Tables("tblDepartments").Rows(ListDepts.SelectedIndex).Item(6) = True Then MenuEdit.Enabled = True Else MenuEdit.Enabled = False
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

    End Sub
    Private Sub ListStaff_DoubleClick(sender As Object, e As EventArgs) Handles ListStaff.DoubleClick
        MenuOK_Click(sender, e)

    End Sub

    Private Sub MenuOK_Click(sender As Object, e As EventArgs) Handles MenuOK.Click
        strStaff = ListStaff.Text
        intStaff = ListStaff.SelectedValue
        Me.Dispose()

    End Sub

    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        strStaff = ""
        intStaff = 0
        Me.Dispose()

    End Sub

    Private Sub MenuAddNew_Click(sender As Object, e As EventArgs) Handles MenuAddNew.Click
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4) = 0) Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ListDepts.SelectedIndex = -1 Then Exit Sub
        Dim myansw As DialogResult = MsgBox("استاد جديد به اين گروه افزوده شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        If myansw = vbYes Then
            strStaff = InputBox("نام استاد را وارد کنيد", "NexTerm", " استاد جديد ")
            If Trim(strStaff) = "" Then
                Exit Sub
            Else
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO Staff (StaffName, StaffCode, Affiliation, Notes) VALUES (@staffname, 0, @affiliation, '-')"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strStaff)
                        cmd.Parameters.AddWithValue("@affiliation", ListDepts.SelectedValue)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "INSERT INTO Staff (StaffName, StaffCode, Affiliation, Notes) VALUES (@staffname, 0, @affiliation, '-')"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strStaff)
                        cmd.Parameters.AddWithValue("@affiliation", ListDepts.SelectedValue)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                End Select
                ListStaff.Refresh()
                ListDepts_Click()

            End If
        End If

    End Sub

    Private Sub MenuEdit_Click(sender As Object, e As EventArgs) Handles MenuEdit.Click
        'Edit
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4) = 0) Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub

        Dim myansw As DialogResult = MsgBox("نام استاد ويرايش شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        strStaff = ListStaff.Text
        Dim r As Integer = ListStaff.SelectedValue
        If myansw = vbYes Then
            strStaff = InputBox("نام استاد را تصحيح کنيد", "NexTerm", strStaff)
            If strStaff = "" Then
                Exit Sub
            Else
                DS.Tables("tblStaff").Rows(ListStaff.SelectedIndex).Item(1) = strStaff
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE Staff SET StaffName = @staffname WHERE ID = @id"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strStaff)
                        cmd.Parameters.AddWithValue("@id", r.ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE Staff SET StaffName = @staffname WHERE ID = @id"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strStaff)
                        cmd.Parameters.AddWithValue("@id", r.ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select
                ListDepts_Click()
            End If
        End If

    End Sub

    Private Sub Menu_DelStaff_Click(sender As Object, e As EventArgs) Handles Menu_DelStaff.Click
        MsgBox("اين ويژگي براي همه کاربران غير فعال است", vbOKOnly, "نکسترم")

    End Sub

End Class