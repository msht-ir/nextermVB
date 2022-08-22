Public Class frmCNN
    Dim tblConnection As New DataTable

    Private Sub cnn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBuildInfo()
        Me.Text = "NexTerm  |  " & strBuildInfo

        Dim strConnectionName As String = ""
        Dim strConnectionAddress As String = ""
        Dim strConnectionUsername As String = ""
        Dim strConnectionPassword As String = ""


        tblConnection.Columns.Add("انتخاب ديتابيس", GetType(String))
        tblConnection.Columns.Add("مشخصات", GetType(String))
        tblConnection.Columns.Add("uid", GetType(String))
        tblConnection.Columns.Add("pwd", GetType(String))

        strFilename = Application.StartupPath & "cnn"
        If IO.File.Exists(strFilename) = True Then
            FileOpen(1, strFilename, OpenMode.Input)
lbl_Read:
            Try
                Dim strx1 As String = LineInput(1)
                If strx1 = "NexTerm Connection" Then
                    strConnectionName = LineInput(1)
                    strConnectionAddress = LineInput(1)
                    strConnectionUsername = LineInput(1)
                    strConnectionPassword = LineInput(1)
                    tblConnection.Rows.Add(strConnectionName, strConnectionAddress, strConnectionUsername, strConnectionPassword)
                End If
                GoTo lbl_Read
            Catch ex As Exception
                'MsgBox("خطا در فايل تنظيمات اتصال ", vbOKOnly, "نکسترم") ' MsgBox(ex.ToString)
            End Try

            If Not EOF(1) Then GoTo lbl_Read
            FileClose(1)

            GridCNN.DataBindings.Clear()
            GridCNN.DataSource = tblConnection

            GridCNN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            GridCNN.Columns(0).Width = 300   'connection name
            GridCNN.Columns(1).Width = 500   'connection address
            GridCNN.Columns(2).Width = 0     'connection username
            GridCNN.Columns(3).Width = 0     'connection password

            GridCNN.Columns(2).Visible = False     'connection username
            GridCNN.Columns(3).Visible = False     'connection password

            For i As Integer = 0 To GridCNN.Columns.Count - 1 'Disable sort for column_haeders
                GridCNN.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
            GridCNN.Refresh()
        End If

    End Sub

    Private Sub GetBuildInfo()
        strBuildInfo = ""
        UserNickName = ""
        intUser = 0

        strFilename = Application.StartupPath & "usr"
        If IO.File.Exists(strFilename) = True Then
            Try
                FileOpen(1, strFilename, OpenMode.Input)
                Dim strx As String = LineInput(1)
                If Trim(strx) <> "NexTerm" Then
                    FileClose(1) : Exit Sub
                Else
                    strBuildInfo = LineInput(1)
                    If Microsoft.VisualBasic.Left(strBuildInfo, 5) <> "Build" Then strBuildInfo = "n/a"
                    UserNickName = LCase(Trim(Mid(LineInput(1), 6)))
                    If UserNickName = "na" Then UserNickName = ""
                    intUser = Val(Mid(LineInput(1), 5))
                End If
            Catch ex As Exception
                'MsgBox("خطا در فايل تنظيمات اتصال ", vbOKOnly, "نکسترم") '// MsgBox(ex.ToString)
            End Try
            FileClose(1)
        End If

    End Sub

    Private Sub Menu_SelectBE_Click(sender As Object, e As EventArgs) Handles Menu_SelectBE.Click
        If GridCNN.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridCNN.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub

        Server2Connect = Trim(GridCNN(0, r).Value)
        strDbBackEnd = Trim(GridCNN(1, r).Value)
        strserveruid = Trim(GridCNN(2, r).Value)
        strserverpwd = Trim(GridCNN(3, r).Value)

        If Server2Connect = "" Then Exit Sub

        Me.Dispose()

    End Sub

    Private Sub GridCNN_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCNN.CellDoubleClick
        Menu_SelectBE_Click(sender, e)

    End Sub

    Private Sub Menu_AddCNN_Click(sender As Object, e As EventArgs) Handles Menu_AddCNN.Click
        tblConnection.Rows.Add("untitled NEW connection", "Address (DblClick)", "", "")
    End Sub

    Private Sub Menu_FindDB_Click(sender As Object, e As EventArgs) Handles Menu_FindDB.Click
        If GridCNN.RowCount < 1 Then Exit Sub

        Dim r As Integer = GridCNN.SelectedCells(0).RowIndex 'count from 0
        Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Then Exit Sub

        Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "Nexterm DB BackEnd|NexTerm*.accdb"}
            If dialog.ShowDialog = DialogResult.OK Then
                GridCNN(c, r).Value = dialog.FileName
            Else
                Exit Sub
            End If
        End Using

        SaveChanges()

    End Sub

    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        Try
            If GridCNN.RowCount < 1 Then Exit Sub
            Dim r As Integer = GridCNN.SelectedCells(0).RowIndex    'count from 0
            Dim c As Integer = GridCNN.SelectedCells(0).ColumnIndex 'count from 0
            If r < 0 Or c < 0 Then Exit Sub
            Dim strValue As String = GridCNN(c, r).Value
            strValue = InputBox("مقدار جديد را وارد کنيد", "تنظيمات اتصال به ديتابيس", strValue)
            GridCNN(c, r).Value = strValue
            SaveChanges() 'AutoSave

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub SaveChanges()
        Try
            FileOpen(1, Application.StartupPath & "cnn", OpenMode.Output)
            For r As Integer = 0 To GridCNN.Rows.Count - 1
                If IsDBNull(GridCNN(0, r).Value) Then
                    GridCNN(0, r).Value = "untitled Connection"
                End If
                For c As Integer = 0 To 3
                    If IsDBNull(GridCNN(c, r).Value) Then GridCNN(c, r).Value = ""
                Next c
            Next r

            For r As Integer = 0 To GridCNN.Rows.Count - 1
                PrintLine(1, "NexTerm Connection")
                PrintLine(1, GridCNN(0, r).Value)
                PrintLine(1, GridCNN(1, r).Value)
                PrintLine(1, GridCNN(2, r).Value)
                PrintLine(1, GridCNN(3, r).Value)
                PrintLine(1, " ")
            Next r
            FileClose(1)
            'MsgBox("تغييرات ذخيره شد", vbOKOnly, "نکسترم")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Menu_Guide_Click(sender As Object, e As EventArgs) Handles Menu_Guide.Click

        Try
            Dim pWeb As Process = New Process()
            pWeb.StartInfo.UseShellExecute = True
            pWeb.StartInfo.FileName = "microsoft-edge:http://msht.ir"
            pWeb.Start()

        Catch ex As Exception
            MsgBox("توجه: راهنماي نکسترم با مرورگر اج باز مي شود", vbOKOnly, "مرورگر اج پيدا نشد") 'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        Application.Exit() : End

    End Sub


End Class