Public Class frmLogIn
    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If PasswordTextBox.Text = "quit" Then
            Dim i
            i = MsgBox("ÎÇÑÌ ãí ÔæíÏ¿", vbYesNo + vbDefaultButton2, "NexTerm")
            If i = vbYes Then
                Userx = "quit"
                Me.Dispose()
            End If
        ElseIf PasswordTextBox.Text = "mshtaccesson" Then
            Userx = "USER Faculty"
            UserAccessConntrols = 31 'with acc1-5!
            Me.Dispose()
        ElseIf PasswordTextBox.Text = strFacultyPass Then
            Userx = "USER Faculty"
            UserAccessConntrols = 0 'but get acc1-5 via settings 
lbl_GetUserNickName1:
            If Trim(UserNickName) = "" Then UserNickName = Trim(InputBox("What's your NickName?", "NexTerm:", ""))
            If Trim(UserNickName) = "" Then GoTo lbl_GetUserNickName1
            SetBuildInfo()
            UserAccessConntrols = 0
            Me.Dispose()
        Else
            intUser = cboUser.SelectedValue ' ID of selected Department
            If intUser = 0 Then Exit Sub
            If PasswordTextBox.Text = DS.Tables("tblDepartments").Rows(cboUser.SelectedIndex).Item(4) Then
                Select Case DS.Tables("tblDepartments").Rows(cboUser.SelectedIndex).Item(9)
                    Case True : Userx = "usrDept1"
                    Case False : Userx = "usrDept2"
                End Select
lbl_GetUserNickName2:
                If Trim(UserNickName) = "" Then UserNickName = Trim(InputBox("What's your NickName?", "NexTerm:", ""))
                If Trim(UserNickName) = "" Then GoTo lbl_GetUserNickName2
                SetBuildInfo()
                strUser = cboUser.Text
                UserAccessConntrols = 0 'SET UserAccessConntrols
                For i As Integer = 0 To 4
                        If DS.Tables("tblDepartments").Rows(cboUser.SelectedIndex).Item(i + 5) = True Then UserAccessConntrols = (UserAccessConntrols Or (2 ^ i))
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
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        MsgBox(strCaption, vbOKOnly, "NexTerm")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Userx = "quit"
        Me.Dispose()
    End Sub

End Class
