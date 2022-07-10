Public Class Settings

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
                    DS.Tables("tblSettings").Rows(0).Item(2) = sttng
                    UserAccessControls = (UserAccessControls Or (2 ^ 2))
                Else 'Admin Can Class Already YES
                    sttng = "NO"
                    DS.Tables("tblSettings").Rows(0).Item(2) = sttng
                    UserAccessControls = (UserAccessControls And 251) ' (251 = 1111 1011 : 2^2 is off)
                End If
            Case 1 '--------------------------------------------------  Admin Can Prog
                If DS.Tables("tblSettings").Rows(1).Item(2) = "NO" Then
                    sttng = "YES"
                    DS.Tables("tblSettings").Rows(1).Item(2) = sttng
                    UserAccessControls = (UserAccessControls Or (2 ^ 4))
                Else 'Admin Can Prog Already YES
                    sttng = "NO"
                    DS.Tables("tblSettings").Rows(1).Item(2) = sttng
                    UserAccessControls = (UserAccessControls And 239) ' (239 = 1110 1111 : 2^4 is off)
                End If
            Case 3 '--------------------------------------------------  Write Logs?
                If DS.Tables("tblSettings").Rows(3).Item(2) = "NO" Then
                    sttng = "YES"
                    DS.Tables("tblSettings").Rows(3).Item(2) = sttng
                    boolLog = True
                Else 'Admin Can Prog Already YES
                    sttng = "NO"
                    DS.Tables("tblSettings").Rows(3).Item(2) = sttng
                    boolLog = False
                End If
            Case 5 '--------------------------------------------------  bg for reports
                Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "Image files (PNG format)|*.png"}
                    If dialog.ShowDialog = DialogResult.OK Then
                        sttng = dialog.FileName
                    Else
                        Me.Dispose()
                        Exit Sub
                    End If
                End Using
                sttng = sttng.Replace("\", "/")
                DS.Tables("tblSettings").Rows(r).Item(2) = sttng
            Case Else '-------------------------------------------------- Other settings
                sttng = Trim(InputBox("تغيير داده شود به", "تنظيمات نکسترم", sttng))
                If sttng = "" Then Exit Sub
                DS.Tables("tblSettings").Rows(r).Item(2) = sttng
        End Select

        '//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Settings SET iHerbsValue = @sttng WHERE ID = @ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@sttng", sttng)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
                Exit Sub
            Case "Access"
                strSQL = "UPDATE Settings SET iHerbsValue = @sttng WHERE ID = @ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@sttng", sttng)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
                Exit Sub
        End Select

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
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
            If UCase(DS.Tables("tblSettings").Rows(3).Item(2)) = "YES" Then boolLog = True Else boolLog = False
            strReportBG = DS.Tables("tblSettings").Rows(5).Item(2)
            Catch ex As Exception
            MsgBox("خطا در بخش تنظيمات نکسترم", vbOKOnly, "نکسترم") 'MsgBox(ex.ToString)
            boolLog = False

        End Try






        Me.Dispose()

    End Sub
End Class