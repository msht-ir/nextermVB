Public Class frmShowNotes
    Private Sub frmShowNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowNotes()

    End Sub
    Private Sub ShowNotes()
        DS.Tables("tblMSgs").Clear()
        GridNotes.DataBindings.Clear()
        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    If ChkMyNotes.Checked = True Then
                        DASS.SelectCommand.CommandText = "SELECT ID, SentDate As [زمان ارسال], usrFrom As [از طرف], usrTo As [به], usrTo_ID, msgString As [يادداشت], IsActive As [جديد] FROM msgs WHERE usrTo_ID=" & intUser.ToString & " ORDER BY SentDate"
                    Else
                        DASS.SelectCommand.CommandText = "SELECT ID, SentDate As [زمان ارسال], usrFrom As [از طرف], usrTo As [به], usrTo_ID, msgString As [يادداشت], IsActive As [جديد] FROM msgs ORDER BY SentDate"
                    End If
                    DASS.Fill(DS, "tblMsgs")
                Case "Access"
                    If ChkMyNotes.Checked = True Then
                        DAAC.SelectCommand.CommandText = "SELECT ID, SentDate As [زمان ارسال], usrFrom As [از طرف], usrTo As [به], usrTo_ID, msgString As [يادداشت], IsActive As [جديد] FROM msgs WHERE usrTo_ID=" & intUser.ToString & " ORDER BY SentDate"
                    Else
                        DAAC.SelectCommand.CommandText = "SELECT ID, SentDate As [زمان ارسال], usrFrom As [از طرف], usrTo As [به], usrTo_ID, msgString As [يادداشت], IsActive As [جديد] FROM msgs ORDER BY SentDate"
                    End If
                    DAAC.Fill(DS, "tblMsgs")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        GridNotes.DataSource = DS.Tables("tblMsgs")
        GridNotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

        ' hide some cols
        GridNotes.Columns(0).Visible = False    ' ID
        GridNotes.Columns(4).Visible = False    ' usrToID

        GridNotes.Columns(1).Width = 120        'DateSent
        GridNotes.Columns(2).Width = 200        'From
        GridNotes.Columns(3).Width = 180        'To
        GridNotes.Columns(5).Width = 620        'msg
        GridNotes.Columns(6).Width = 35         'active

        For i = 0 To GridNotes.Columns.Count - 1
            GridNotes.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

    End Sub

    Private Sub GridNotes_DoubleClick(sender As Object, e As EventArgs) Handles GridNotes.DoubleClick
        If GridNotes.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridNotes.CurrentCell.RowIndex
        Dim c As Integer = GridNotes.CurrentCell.ColumnIndex
        If r < 0 Or c <> 6 Then Exit Sub ' col 6 = active
        If (Userx = "USER Department") And (DS.Tables("tblMsgs").Rows(r).Item(4) <> intUser.ToString) Then
            MsgBox("اين يادداشت شما نيست؛ نمي توانيد آن را تغيير دهيد", vbOKOnly, "نکسترم")
            Exit Sub
        End If

        Dim boolActive As Boolean = DS.Tables("tblMsgs").Rows(r).Item(6)
        If boolActive = True Then boolActive = False Else boolActive = True 'toggle

        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE msgs SET IsActive = @boolactive WHERE ID = @id"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@boolactive", boolActive)
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblMsgs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "UPDATE msgs SET IsActive = @boolactive WHERE ID = @id"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@boolactive", boolActive)
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblMsgs").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ShowNotes()

    End Sub

    Private Sub Menu_AddNote_Click(sender As Object, e As EventArgs) Handles Menu_AddNote.Click
        ChooseDept.ShowDialog()
        If (intDept = 0 Or strDept = "") Then Exit Sub
        Try
            Dim strDatex As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm") '18 chars
            Dim strMessage As String = Trim(InputBox("يادداشت براي    " & strDept, "يادداشت جديد", ""))
            If strMessage = "" Then Exit Sub
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "INSERT INTO msgs (SentDate, usrFrom, usrTo, usrTo_ID, msgString, IsActive) VALUES (@sentdate, @usrfrom, @usrto, @usrtoid, @msgstring, 1)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sentdate", strDatex)
                    cmd.Parameters.AddWithValue("@usrfrom", strUser & " : " & UserNickName)
                    cmd.Parameters.AddWithValue("@usrto", strDept)
                    cmd.Parameters.AddWithValue("@usrtoid", intDept)
                    cmd.Parameters.AddWithValue("@msgstring", strMessage)
                    cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "INSERT INTO msgs (SentDate, usrFrom, usrTo, usrTo_ID, msgString, IsActive) VALUES (@sentdate, @usrfrom, @usrto, @usrtoid, @msgstring, -1)"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sentdate", strDatex)
                    cmd.Parameters.AddWithValue("@usrfrom", strUser & " : " & UserNickName)
                    cmd.Parameters.AddWithValue("@usrto", strDept)
                    cmd.Parameters.AddWithValue("@usrtoid", intDept)
                    cmd.Parameters.AddWithValue("@msgstring", strMessage)
                    cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ShowNotes()
    End Sub

    Private Sub Menu_Note2Faculty_Click(sender As Object, e As EventArgs) Handles Menu_Note2Faculty.Click
        Try
            Dim strDatex As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm") '18 chars
            Dim strMessage As String = Trim(InputBox("يادداشت براي دانشکده", "يادداشت جديد", ""))
            If strMessage = "" Then Exit Sub
            intDept = 0
            strDept = "دانشکده"
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "INSERT INTO msgs (SentDate, usrFrom, usrTo, usrTo_ID, msgString, IsActive) VALUES (@sentdate, @usrfrom, @usrto, @usrtoid, @msgstring, 1)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sentdate", strDatex)
                    cmd.Parameters.AddWithValue("@usrfrom", UserNickName)
                    cmd.Parameters.AddWithValue("@usrto", strDept)
                    cmd.Parameters.AddWithValue("@usrtoid", intDept)
                    cmd.Parameters.AddWithValue("@msgstring", strMessage)
                    cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "INSERT INTO msgs (SentDate, usrFrom, usrTo, usrTo_ID, msgString, IsActive) VALUES (@sentdate, @usrfrom, @usrto, @usrtoid, @msgstring, -1)"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@sentdate", strDatex)
                    cmd.Parameters.AddWithValue("@usrfrom", UserNickName)
                    cmd.Parameters.AddWithValue("@usrto", strDept)
                    cmd.Parameters.AddWithValue("@usrtoid", intDept)
                    cmd.Parameters.AddWithValue("@msgstring", strMessage)
                    cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ShowNotes()

    End Sub

    Private Sub Menu_Del_Click(sender As Object, e As EventArgs) Handles Menu_Del.Click
        If GridNotes.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridNotes.CurrentCell.RowIndex
        If r < 0 Then Exit Sub
        If (Userx = "USER Department") And (DS.Tables("tblMsgs").Rows(r).Item(4) <> intUser.ToString) Then
            MsgBox("اين يادداشت شما نيست؛ نمي توانيد آن را حذف کنيد", vbOKOnly, "نکسترم")
            Exit Sub
        End If

        Dim myansw As DialogResult = MsgBox("يادداشت انتخاب شده حذف شود؟", vbYesNo, "نکسترم")
        If myansw = vbNo Then Exit Sub

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Try
                    strSQL = "DELETE FROM msgs WHERE ID=@id"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblMsgs").Rows(r).Item(0).ToString)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                Try
                    strSQL = "DELETE FROM msgs WHERE ID=@id"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@id", DS.Tables("tblMsgs").Rows(r).Item(0).ToString)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select

        ShowNotes()

    End Sub

    Private Sub Menu_Exit_Click() Handles Menu_Exit.Click
        Me.Dispose()

    End Sub

    Private Sub ChkMyNotes_Click() Handles ChkMyNotes.Click
        ShowNotes()

    End Sub

    Private Sub Label1_Click() Handles Label1.Click
        MsgBox("پس از مطالعه يادداشت آن را حذف کنيد" & vbCrLf & "يادداشت هاي داراي تيک (جديد) يادآوري مي شوند", vbOKOnly, "نکسترم")

    End Sub
End Class