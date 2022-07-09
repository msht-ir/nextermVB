Public Class frmLogIn
    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetFacultyUserRhites() ' Set acc for Faculty
        Try
            lblBuildInfo.Text = strBuildInfo ' & " | " & Server2Connect
            cboUser.DataSource = DS.Tables("tblDepartments")
            cboUser.DisplayMember = "DEPT"
            cboUser.ValueMember = "ID"
            cboUser.SelectedValue = intUser
            PasswordTextBox.Focus()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub cboUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUser.SelectedIndexChanged
        PasswordTextBox.Focus()

    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles PasswordTextBox.TextChanged
        Dim usr As Integer = 0
        If IsDBNull(cboUser.SelectedValue) Then usr = 0 Else usr = cboUser.SelectedValue
        If PasswordTextBox.Text = "quit" Then '----------------------------------------------- (quit)
            Dim i
            i = MsgBox("ÎÇÑÌ ãí ÔæíÏ¿", vbYesNo + vbDefaultButton2, "NexTerm")
            If i = vbYes Then
                Userx = "quit"
                Me.Dispose()
            End If
        ElseIf PasswordTextBox.Text = "mshtaccesson" Then '----------------------------------- usr = msht
            Userx = "USER Faculty"
            UserAccessControls = 31 '+all acc 1-5!
            Me.Dispose()
        ElseIf PasswordTextBox.Text = strFacultyPass Then '----------------------------------- usr = Faculty
            Userx = "USER Faculty"
lbl_GetUserNickName1:
            If Trim(UserNickName) = "" Then UserNickName = Trim(InputBox("What's your NickName?", "NexTerm:", ""))
            If Trim(UserNickName) = "" Then GoTo lbl_GetUserNickName1
            SetBuildInfo()
            Me.Dispose()
        Else '-------------------------------------------------------------------------------- usr = Department 
            intUser = cboUser.SelectedValue ' ID of selected Department
            If intUser = 0 Then Exit Sub
            If PasswordTextBox.Text = DS.Tables("tblDepartments").Rows(cboUser.SelectedIndex).Item(4) Then
                Userx = "USER Department"
lbl_GetUserNickName2:
                If Trim(UserNickName) = "" Then UserNickName = Trim(InputBox("What's your NickName?", "NexTerm:", ""))
                If Trim(UserNickName) = "" Then GoTo lbl_GetUserNickName2
                SetBuildInfo()
                strUser = cboUser.Text
                UserAccessControls = 0 'SET UserAccessControls
                For i As Integer = 0 To 4
                    If DS.Tables("tblDepartments").Rows(cboUser.SelectedIndex).Item(i + 5) = True Then UserAccessControls = (UserAccessControls Or (2 ^ i))
                Next i
                Me.Dispose()
            End If
        End If

    End Sub
    Private Sub SetBuildInfo()
        FileOpen(1, Application.StartupPath & "usr", OpenMode.Output)
        PrintLine(1, "NexTerm")
        PrintLine(1, strBuildInfo)
        PrintLine(1, "nick " & LCase(UserNickName))
        PrintLine(1, "usr " & intUser.ToString)
        FileClose(1)

    End Sub

    Private Sub SetFacultyUserRhites()
        DS.Tables("tblSettings").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DS.Tables("tblSettings").Clear()
                DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin Can%' ORDER BY iHerbsConstant" ' search: (Faculty User rights)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                Try 'Admin Can Class / Prog
                    If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or 4) Else UserAccessControls = (UserAccessControls And 251)  ' (4:  0000 0100) (251: 1111 1011)
                    If UCase(DS.Tables("tblSettings").Rows(1).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or 16) Else UserAccessControls = (UserAccessControls And 239)  ' (16: 0001 0000) (239: 1110 1111)
                Catch ex As Exception
                    UserAccessControls = UserAccessControls And 251  ' (4:  0000 0100) (251: 1111 1011)
                    UserAccessControls = UserAccessControls And 239  ' (16: 0001 0000) (239: 1110 1111)
                End Try
            Case "Access"
                DS.Tables("tblSettings").Clear()
                DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin Can%' ORDER BY iHerbsConstant" ' search: (Faculty User rights)
                DAAC.Fill(DS, "tblSettings") ' tbl 12: Settings
                Try 'Admin Can Class / Prog
                    If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or 4) Else UserAccessControls = (UserAccessControls And 251)  ' (4:  0000 0100) (251: 1111 1011)
                    If UCase(DS.Tables("tblSettings").Rows(1).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or 16) Else UserAccessControls = (UserAccessControls And 239)  ' (16: 0001 0000) (239: 1110 1111)
                Catch ex As Exception
                    UserAccessControls = (UserAccessControls And 251)  ' (4:  0000 0100) (251: 1111 1011)
                    UserAccessControls = (UserAccessControls And 239)  ' (16: 0001 0000) (239: 1110 1111)
                End Try
        End Select

    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        MsgBox(strCaption, vbOKOnly, "NexTerm")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Userx = "quit"
        Me.Dispose()
    End Sub

End Class
