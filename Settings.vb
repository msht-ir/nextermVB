﻿Public Class Settings
    Public cmdLineStatus As Integer = 0
    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'READ FROM DATABASE
        DS.Tables("tblSettings").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsValue, Notes, Header FROM Settings WHERE Header ='pref' ORDER BY iHerbsConstant"
                DASS.Fill(DS, "tblSettings")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsValue, Notes, Header FROM Settings WHERE Header ='pref' ORDER BY iHerbsConstant"
                DAAC.Fill(DS, "tblSettings")
        End Select

        GridSettings.DataSource = DS.Tables("tblSettings")
        GridSettings.Refresh()

        GridSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridSettings.Columns(0).Visible = False    'ID
        GridSettings.Columns(1).Width = 160        'iHerbsConstant
        GridSettings.Columns(2).Width = 130        'iHerbsValue
        GridSettings.Columns(3).Width = 250        'Note (Description)
        GridSettings.Columns(4).Visible = False    'Header

        For k As Integer = 0 To GridSettings.Columns.Count - 1
            GridSettings.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
        Next k

        txtCMD.Text = ""
        txtCMD.Focus()

    End Sub

    Private Sub GridSettings_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridSettings.CellDoubleClick
        If GridSettings.RowCount < 1 Then Exit Sub
        Dim r As Integer = e.RowIndex 'count from 0
        Dim c As Integer = e.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        If c <> 2 Then Exit Sub

        Dim sttng As String = DS.Tables("tblsettings").Rows(r).Item(2)
        Select Case r
            Case 0 '--------------------------------------------------  Admin Can Class
                If DS.Tables("tblSettings").Rows(0).Item(2) = "NO" Then
                    sttng = "YES"
                    DS.Tables("tblSettings").Rows(r).Item(2) = sttng
                    UserAccessControls = (UserAccessControls Or (2 ^ 2))
                    WriteLOG(50)
                Else 'Admin Can Class Already YES
                    sttng = "NO"
                    DS.Tables("tblSettings").Rows(r).Item(2) = sttng
                    UserAccessControls = (UserAccessControls And 251) ' (251 = 1111 1011 : 2^2 is off)
                    WriteLOG(51)
                End If
                SaveSettings()
            Case 1 '--------------------------------------------------  Admin Can Prog
                If DS.Tables("tblSettings").Rows(1).Item(2) = "NO" Then
                    sttng = "YES"
                    DS.Tables("tblSettings").Rows(1).Item(2) = sttng
                    UserAccessControls = (UserAccessControls Or (2 ^ 4))
                    WriteLOG(52)
                Else 'Admin Can Prog Already YES
                    sttng = "NO"
                    DS.Tables("tblSettings").Rows(1).Item(2) = sttng
                    UserAccessControls = (UserAccessControls And 239) ' (239 = 1110 1111 : 2^4 is off)
                    WriteLOG(53)
                End If
                SaveSettings()
            Case 6 '--------------------------------------------------  bg for reports
                Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "Image files (PNG format)|*.png"}
                    If dialog.ShowDialog = DialogResult.OK Then
                        sttng = dialog.FileName
                    Else
                        Me.Dispose()
                        Exit Sub
                    End If
                End Using
                sttng = sttng.Replace("\", "/")
                DS.Tables("tblSettings").Rows(6).Item(2) = sttng
                SaveSettings()
                'Case Else '-------------------------------------------------- Other settings
                '    sttng = Trim(InputBox("تغيير داده شود به", "تنظيمات نکسترم", sttng))
                '    If sttng = "" Then Exit Sub
                '    DS.Tables("tblSettings").Rows(r).Item(2) = sttng
        End Select
        txtCMD.Focus()

    End Sub

    Private Sub txtCMD_TextChanged(sender As Object, e As EventArgs) Handles txtCMD.TextChanged
        'txtCMD.Text = Trim(txtCMD.Text)
        If txtCMD.Text = "" Then Exit Sub
        Try
            Select Case cmdLineStatus
                Case 0 'Ready for Commands
                    Select Case Trim(txtCMD.Text.ToLower)
                        Case "cmd", "help", "guide"
                            cmdHelp_settings()
                            txtCMD.Text = "" : cmdLineStatus = 0
                        Case "class on", "classon"
                            DS.Tables("tblSettings").Rows(0).Item(2) = "YES"
                            txtCMD.Text = "" : cmdLineStatus = 0
                            WriteLOG(50)
                        Case "class off", "classoff"
                            DS.Tables("tblSettings").Rows(0).Item(2) = "NO"
                            txtCMD.Text = "" : cmdLineStatus = 0
                            WriteLOG(51)
                        Case "prog on", "progon"
                            DS.Tables("tblSettings").Rows(1).Item(2) = "YES"
                            txtCMD.Text = "" : cmdLineStatus = 0
                            WriteLOG(52)
                        Case "prog off", "progoff"
                            DS.Tables("tblSettings").Rows(1).Item(2) = "NO"
                            txtCMD.Text = "" : cmdLineStatus = 0
                            WriteLOG(53)
                        Case "log on", "logon"
                            DS.Tables("tblSettings").Rows(4).Item(2) = "YES"
                            txtCMD.Text = "" : cmdLineStatus = 0
                            WriteLOG(56)
                        Case "log off", "logoff"
                            DS.Tables("tblSettings").Rows(4).Item(2) = "NO"
                            txtCMD.Text = "" : cmdLineStatus = 0
                            WriteLOG(57)
                        Case "admin pass", "adminpass"
                            cmdLineStatus = 2 'be ready for input admin pass
                            txtCMD.Text = DS.Tables("tblSettings").Rows(2).Item(2)
                            txtCMD.SelectionStart = Len(txtCMD.Text)
                        Case "version"
                            cmdLineStatus = 3 'be ready for input build info
                            txtCMD.Text = DS.Tables("tblSettings").Rows(3).Item(2)
                            txtCMD.SelectionStart = Len(txtCMD.Text)
                        Case "owner info", "ownerinfo"
                            cmdLineStatus = 5 'be ready for input owner info
                            txtCMD.Text = DS.Tables("tblSettings").Rows(5).Item(2)
                            txtCMD.SelectionStart = Len(txtCMD.Text)
                        Case "quit", "exit"
                            Menu_ExitSetup_Click()
                    End Select

                Case 2 '---------------------------------------------------------- input admin pass
                    If Trim(txtCMD.Text.ToLower) = "quit" Or Trim(txtCMD.Text.ToLower) = "exit" Or Trim(txtCMD.Text.ToLower) = "cancel" Then Exit Sub
                    If Mid(txtCMD.Text, Len(txtCMD.Text), 1) = "#" Then
                        Dim sttng As String = Mid(txtCMD.Text, 1, Len(txtCMD.Text) - 1)
                        DS.Tables("tblSettings").Rows(2).Item(2) = sttng
                        SaveSettings()
                        WriteLOG(54)
                        cmdLineStatus = 0 'reset, ready for commands
                        txtCMD.Text = ""
                    End If

                Case 3 '------------------------------------------------------- input build info
                    If Trim(txtCMD.Text.ToLower) = "quit" Or Trim(txtCMD.Text.ToLower) = "exit" Or Trim(txtCMD.Text.ToLower) = "cancel" Then Exit Sub
                    If Mid(txtCMD.Text, Len(txtCMD.Text), 1) = "#" Then
                        Dim sttng As String = Mid(txtCMD.Text, 1, Len(txtCMD.Text) - 1)
                        DS.Tables("tblSettings").Rows(3).Item(2) = sttng
                        SaveSettings()
                        WriteLOG(55)
                        cmdLineStatus = 0 'reset, ready for commands
                        txtCMD.Text = ""
                    End If

                Case 5 '----------------------------------------------------------- input owner info
                    If Trim(txtCMD.Text.ToLower) = "quit" Or Trim(txtCMD.Text.ToLower) = "exit" Or Trim(txtCMD.Text.ToLower) = "cancel" Then Exit Sub
                    If Mid(txtCMD.Text, Len(txtCMD.Text), 1) = "#" Then
                        Dim sttng As String = Mid(txtCMD.Text, 1, Len(txtCMD.Text) - 1)
                        DS.Tables("tblSettings").Rows(5).Item(2) = sttng
                        SaveSettings()
                        WriteLOG(58)
                        cmdLineStatus = 0 'reset, ready for commands
                        txtCMD.Text = ""
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub cmdHelp_settings()
        FileOpen(1, Application.StartupPath & "\NexTerm_Guide.html", OpenMode.Output)
        PrintLine(1, "<html dir=""ltr"">")
        PrintLine(1, "<head><title>NexTerm Guide</title><style>table, th,td {border: 1px solid;}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>Faculty of Science, SKU</p>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='color:blue;font-family:tahoma; font-size:14px'>Command-line CMDs - Settings<br></p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><Quick list</p>")
        PrintLine(1, "<table style='font-family:tahoma; font-size:14px; border-collapse:collapse'>")
        'Header
        PrintLine(1, "<tr><th>Command > _</th><th>function / notes</th</tr>")
        'Rows
        PrintLine(1, "<tr><td> cmd                     </td> <td>- show this guide (list of commands in settings)           </td></tr>")
        PrintLine(1, "<tr><td> log on                  </td> <td>- log user activities                                       </td></tr>")
        PrintLine(1, "<tr><td> log off                 </td> <td>- disable log                                               </td></tr>")
        PrintLine(1, "<tr><td> class on                </td> <td>- enable faculty-user to set classes                        </td></tr>")
        PrintLine(1, "<tr><td> class off               </td> <td>- disable faculty-user to set classes                       </td></tr>")
        PrintLine(1, "<tr><td> prog on                 </td> <td>- enable faculty-user to programme like a department-user   </td></tr>")
        PrintLine(1, "<tr><td> prog off                </td> <td>- disable faculty-user to programme like a department-user  </td></tr>")
        PrintLine(1, "<tr><td> admin pass -----#       </td> <td>- change admin (faculty-user) password                      </td></tr>")
        PrintLine(1, "<tr><td> version --------#       </td> <td>- change version info on this database                      </td></tr>")
        PrintLine(1, "<tr><td> owner info -----#       </td> <td>- change owner info of this database                        </td></tr>")
        PrintLine(1, "<tr><td> quit                    </td> <td>- exit settings                                             </td></tr>")
        PrintLine(1, "<tr><td> exit                    </td> <td>- exit settings                                             </td></tr>")
        PrintLine(1, "</table><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
        PrintLine(1, "</body>")
        PrintLine(1, "</html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "NexTerm_Guide.html")
        txtCMD.Focus()

    End Sub

    Private Sub SaveSettings()
        For r As Integer = 0 To GridSettings.Rows.Count - 1
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE Settings SET iHerbsValue = @sttng WHERE ID = @ID"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttng", DS.Tables("tblsettings").Rows(r).Item(2))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "UPDATE Settings SET iHerbsValue = @sttng WHERE ID = @ID"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sttng", DS.Tables("tblsettings").Rows(r).Item(2))
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Next r

    End Sub
    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG 'There is a similar SUB() in TermProgs_Form
            If Userx = "USER Faculty" Then intUser = 0
            'Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
            Dim timeZoneInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
            Dim strDateTime As String = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo).ToString("yyyy.MM.dd - HH:mm:ss")

            Dim strUserID As Integer = intUser.ToString
            Dim strNickName As String = UserNickName
            Dim strClientName As String = LCase(Environment.MachineName)
            Dim strFrontEnd As String = LCase(strBuildInfo)
            Dim strLog As String = ""
            Select Case intActivity
                Case 50 : strLog = "admin.class on"
                Case 51 : strLog = "admin.class off"
                Case 52 : strLog = "admin.prog on"
                Case 53 : strLog = "admin.prog off"
                Case 54 : strLog = "admin.pass?"
                Case 55 : strLog = "build.info?"
                Case 56 : strLog = "usr.log on"
                Case 57 : strLog = "usr.log off"
                Case 58 : strLog = "owner.info?"
            End Select
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", strUserID)
                        cmdx.Parameters.AddWithValue("@nickname", strNickName)
                        cmdx.Parameters.AddWithValue("@clientname", strClientName)
                        cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                        cmdx.Parameters.AddWithValue("@strlog", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", strUserID)
                        cmdx.Parameters.AddWithValue("@nickname", strNickName)
                        cmdx.Parameters.AddWithValue("@clientname", strClientName)
                        cmdx.Parameters.AddWithValue("@frontend", strFrontEnd)
                        cmdx.Parameters.AddWithValue("@strlog", strLog)
                        Dim ix As Integer = cmdx.ExecuteNonQuery()
                End Select
            Catch ex As Exception
                MsgBox(ex.ToString) 'Do Nothing!
            End Try
        End If

    End Sub

    Private Sub Menu_ExitSetup_Click() Handles Menu_ExitSetup.Click
        SaveSettings()
        DS.Tables("tblSettings").Clear()
        Try
            ' //Get all prefs//
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE Header = 'Pref' ORDER BY iHerbsConstant"
                    DASS.Fill(DS, "tblSettings")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE Header = 'Pref' ORDER BY iHerbsConstant"
                    DAAC.Fill(DS, "tblSettings")
            End Select
            ' Row 0 Admin Can Class    ----  2^2
            ' Row 1 Admin Can Prog     ----  2^4
            ' Row 2 Admin Password
            ' Row 3 Log User Activity
            ' Row 4 Owner info
            ' Row 5 Report background

            ' Admin Can Class
            If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or 4) Else UserAccessControls = (UserAccessControls And 251)  ' (4: 0000 0100)  (251: 1111 1011)
            ' Admin Can Prog
            If UCase(DS.Tables("tblSettings").Rows(1).Item(2)) = "YES" Then UserAccessControls = (UserAccessControls Or 16) Else UserAccessControls = (UserAccessControls And 239)  ' (16: 0001 0000) (239: 1110 1111)

            strFacultyPass = DS.Tables("tblSettings").Rows(2).Item(2)
            If UCase(DS.Tables("tblSettings").Rows(4).Item(2)) = "YES" Then boolLog = True Else boolLog = False
            strReportBG = DS.Tables("tblSettings").Rows(6).Item(2)
        Catch ex As Exception
            MsgBox("خطا در بخش تنظيمات نکسترم", vbOKOnly, "نکسترم") 'MsgBox(ex.ToString)
            boolLog = False
        End Try

        Me.Dispose()

    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            MsgBox("براي خروج از منو استفاده کنيد ", vbOKOnly, "نکسنرم")
        End If

    End Sub
End Class