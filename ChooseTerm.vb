Public Class ChooseTerm
    Private Sub ChooseTerm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For k = 0 To Grid1.Columns.Count - 1
            Grid1.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
        Next k
        ShowTerms()
        If Userx = "USER Department" Then Menu_Edit.Enabled = False Else Menu_Edit.Enabled = True

    End Sub
    Private Sub ShowTerms()
        DS.Tables("tblTerms").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                If Userx = "USER Faculty" Then
                    DASS.SelectCommand.CommandText = "SELECT Terms.ID, Terms.Term, Terms.Active, Terms.Notes FROM Terms ORDER BY Active, Term"
                    Menu_Add.Enabled = True
                Else
                    DASS.SelectCommand.CommandText = "SELECT Terms.ID, Terms.Term, Terms.Active, Terms.Notes FROM Terms WHERE Terms.Active = 1 ORDER BY Active, Term"
                    Menu_Add.Enabled = False
                End If
                DASS.Fill(DS, "tblTerms")

            Case "Access"
                If Userx = "USER Faculty" Then
                    DAAC.SelectCommand.CommandText = "SELECT Terms.ID, Terms.Term, Terms.Active, Terms.Notes FROM Terms ORDER BY Active, Term"
                    Menu_Add.Enabled = True
                Else
                    DAAC.SelectCommand.CommandText = "SELECT Terms.ID, Terms.Term, Terms.Active, Terms.Notes FROM Terms WHERE Terms.Active = -1 ORDER BY Active, Term"
                    Menu_Add.Enabled = False
                End If
                DAAC.Fill(DS, "tblTerms")

        End Select

        Grid1.DataSource = DS.Tables("tblTerms")
        Grid1.Refresh()
        Grid1.Columns(0).Width = 0   'ID
        Grid1.Columns(1).Width = 85  'Term
        Grid1.Columns(2).Width = 50  'Active
        Grid1.Columns(3).Width = 0   'Notes

        Grid1.Columns(0).Visible = False
        If Userx = "USER Department" Then Grid1.Columns(2).Visible = False Else Grid1.Columns(2).Visible = True
        Grid1.Columns(3).Visible = False

        For i = 0 To Grid1.Columns.Count - 1
            Grid1.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

    End Sub
    Private Sub Grid1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellValueChanged
        If Userx <> "USER Faculty" Then MsgBox("قابليت (ويرايش) اين آيتم براي کاربر گروه ممکن نيست", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If Grid1.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid1.CurrentCell.RowIndex
        If r < 0 Then Exit Sub

        Dim strTerm As String = Grid1.Rows(r).Cells(1).Value
        DS.Tables("tblTerms").Rows(r).Item(1) = strTerm

        Dim boolActive As Boolean = Grid1.Rows(r).Cells(2).Value
        DS.Tables("tblTerms").Rows(r).Item(2) = boolActive

        Dim strNotes As String = Grid1.Rows(r).Cells(3).Value.ToString
        DS.Tables("tblTerms").Rows(r).Item(3) = strNotes
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "UPDATE Terms SET Term = @term, Active = @active, Notes = @notes WHERE ID = @ID"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@term", strTerm)
                cmd.Parameters.AddWithValue("@active", boolActive)
                cmd.Parameters.AddWithValue("@notes", strNotes)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTerms").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
            Case "Access"
                strSQL = "UPDATE Terms SET Term = @term, Active = @active, Notes = @notes WHERE ID = @ID"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@term", strTerm)
                cmd.Parameters.AddWithValue("@active", boolActive)
                cmd.Parameters.AddWithValue("@notes", strNotes)
                cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTerms").Rows(r).Item(0).ToString)
                Dim i As Integer = cmd.ExecuteNonQuery()
        End Select

    End Sub

    Private Sub Menu_OK_Click(sender As Object, e As EventArgs) Handles Menu_OK.Click
        Dim r As Integer = Grid1.SelectedCells(0).RowIndex
        intTerm = Val(Grid1(0, r).Value)
        strTerm = Grid1(1, r).Value
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Menu_Add_Click(sender As Object, e As EventArgs) Handles Menu_Add.Click
        If Userx <> "USER Faculty" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub

        Dim myansw As DialogResult = MsgBox("يک ترم جديد اضافه شود؟", vbQuestion + vbYesNo + vbDefaultButton2, "نکسترم" & strCaption)
        If myansw = vbNo Then
            Exit Sub
        Else
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "INSERT INTO Terms (Term, [Active], Notes) VALUES ('1300-0', False, '-')"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "INSERT INTO Terms (Term, [Active], Notes) VALUES ('1300-0', False, '-')"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.ExecuteNonQuery()
            End Select
            Grid1.Refresh()
            ShowTerms()
        End If


    End Sub

    Private Sub Grid1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid1.CellDoubleClick
        Menu_OK_Click(sender, e)
    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        intTerm = 0
        strTerm = ""

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        If Grid1.RowCount < 1 Then Exit Sub
        Dim r As Integer = Grid1.SelectedCells(0).RowIndex    'count from 0
        Dim c As Integer = Grid1.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub
        Try
            Select Case c
                Case 1 ' TERM
                    If (Userx = "USER Faculty") And (UserAccessConntrols And (2 ^ 4) = 0) Then MsgBox("مجوز تغيير نام ترم را نداريد", vbOKOnly, "تنظيمات نکسترم") : Exit Sub
                    Dim strValue As String = Grid1(c, r).Value
                    strValue = InputBox("مقدار جديد را وارد کنيد", "نکسترم", strValue)
                    If Trim(strValue) = "" Then Exit Sub
                    Grid1(c, r).Value = Trim(strValue)
                Case 2 'ACTIVE
                    If Grid1(c, r).Value = True Then
                        Grid1(c, r).Value = False
                    Else
                        Grid1(c, r).Value = True
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


End Class