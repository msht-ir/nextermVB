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

        If c = 2 And r = 0 Then 'AdminCanProg
            If DS.Tables("tblSettings").Rows(0).Item(2) = "NO" Then
                DS.Tables("tblSettings").Rows(0).Item(2) = "YES"
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE Settings SET iHerbsValue = 'YES' WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        Exit Sub
                    Case "Access"
                        strSQL = "UPDATE Settings SET iHerbsValue = 'YES' WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblSettings").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                        Exit Sub
                End Select
            Else 'AdminCanProg Already YES
                Exit Sub
            End If
        Else ' now, other Settings
            Select Case c 'SELECT BASED ON GRID.COLUMN
                Case 2 'iHerbsValue
                    Dim sttng As String = DS.Tables("tblsettings").Rows(r).Item(2)

                    sttng = Trim(InputBox("تغيير داده شود به", "تنظيمات نکسترم", sttng))
                    If sttng = "" Then Exit Sub
                    DS.Tables("tblSettings").Rows(r).Item(2) = sttng
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
            End Select
        End If
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
            ' Rows 0 Admin Can Progremme
            ' Rows 1 Admin Password
            ' Rows 2 Log User Activity
            ' Rows 3 Owner info
            ' Rows 4 Report background

            If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then AdminCanProg = True Else AdminCanProg = False
            strFacultyPass = DS.Tables("tblSettings").Rows(1).Item(2)
            If UCase(DS.Tables("tblSettings").Rows(2).Item(2)) = "YES" Then boolLog = True Else boolLog = False
            strReportBG = DS.Tables("tblSettings").Rows(4).Item(2)
        Catch ex As Exception
            MsgBox("خطا در بخش تنظيمات نکسترم", vbOKOnly, "نکسترم") 'MsgBox(ex.ToString)
            boolLog = False

        End Try






        Me.Dispose()

    End Sub
End Class