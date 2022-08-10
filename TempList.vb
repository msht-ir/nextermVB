Public Class TempList

    Private Sub TempList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 2
            GridCourse.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

        Menu_ReadFromFile_Click()

    End Sub

    Private Sub GridCourse_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCourse.CellClick
        Dim r As Integer = GridCourse.CurrentCell.RowIndex
        Dim c As Integer = GridCourse.CurrentCell.ColumnIndex
        If c = 0 Then
            If GridCourse.Item(0, r).Value = "+" Then
                GridCourse.Item(0, r).Value = ""
            Else
                GridCourse.Item(0, r).Value = "+"
            End If
        End If

    End Sub

    Private Sub GridCourse_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridCourse.CellContentDoubleClick
        Dim r As Integer = GridCourse.CurrentCell.RowIndex
        Dim c As Integer = GridCourse.CurrentCell.ColumnIndex
        If c = 0 Then
            Exit Sub
        Else
            Dim strGridContent As String = GridCourse.Item(c, r).Value.ToString
            strGridContent = Trim(InputBox("مقدار جديد را وارد کنيد", "نکسترم", strGridContent))
            If strGridContent = "" Then
                Exit Sub
            Else
                GridCourse.Item(c, r).Value = strGridContent
            End If
        End If
    End Sub

    'MENU
    Private Sub Menu_ReadFromFile_Click() Handles Menu_ReadFromFile.Click

        While GridCourse.Rows.Count > 0
            GridCourse.Rows.Remove(GridCourse.Rows(0))
        End While

        Dim strIdentifier As String
        Try
            Using dialog As New OpenFileDialog With {.InitialDirectory = Application.StartupPath, .Filter = "Nexterm Course List|*.txt"}
                If dialog.ShowDialog = DialogResult.OK Then
                    strFilename = dialog.FileName
                Else
                    Me.Dispose()
                    Exit Sub
                End If
            End Using

            Dim intCourseUnits As Integer = 0
            Dim intCourseSpecs As Integer = 0
            If IO.File.Exists(strFilename) = True Then
                FileOpen(1, strFilename, OpenMode.Input)
                strIdentifier = LineInput(1)
                If Mid(strIdentifier, 1, 15) = "NexTerm Courses" Then
lbl_Read:
                    strCourse = LineInput(1)
                    intCourseNumber = LineInput(1)
                    intCourseSpecs = LineInput(1)
                    intCourseUnits = LineInput(1)
                    GridCourse.Rows.Add("+", intCourseNumber, strCourse, intCourseSpecs, intCourseUnits)
                End If
                GoTo lbl_Read

                If Not EOF(1) Then GoTo lbl_Read
                FileClose(1)
            Else
                MsgBox("فايل ليست درس ها در فولدر برنامه پيدا نشد", vbOKOnly, "نکسترم")
            End If
            FileClose(1) 'Confirm file is closed
        Catch ex As Exception
            'MsgBox(ex.ToString) 'MsgBox("خطا در فايل ليست دروس ", vbOKOnly, "نکسترم") ' MsgBox(ex.ToString)
            FileClose(1)
        End Try

    End Sub
    Private Sub Menu_All_Click(sender As Object, e As EventArgs) Handles Menu_All.Click
        For i = 0 To GridCourse.Rows.Count - 1
            GridCourse.Item(0, i).Value = "+"
        Next
    End Sub

    Private Sub Menu_None_Click(sender As Object, e As EventArgs) Handles Menu_None.Click
        For i = 0 To GridCourse.Rows.Count - 1
            GridCourse.Item(0, i).Value = ""
        Next

    End Sub

    Private Sub Menu_InvertSelection_Click(sender As Object, e As EventArgs) Handles Menu_InvertSelection.Click
        For i = 0 To GridCourse.Rows.Count - 1
            If GridCourse.Item(0, i).Value = "+" Then
                GridCourse.Item(0, i).Value = ""
            Else
                GridCourse.Item(0, i).Value = "+"
            End If
        Next
    End Sub

    Private Sub Menu_Add_Click(sender As Object, e As EventArgs) Handles Menu_Add.Click
        Dim intCourseUnits As Integer = 0
        Try
            For k As Integer = 0 To GridCourse.Rows.Count - 1
                If GridCourse.Item(0, k).Value = "+" Then
                    intCourseNumber = GridCourse.Item(1, k).Value
                    strCourse = GridCourse.Item(2, k).Value
                    intCourseUnits = GridCourse.Item(3, k).Value
                    Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                        Case "SqlServer"
                            strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units) VALUES (@bioprogid, @coursename, @coursenumber, @units)"
                            Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@bioprogid", intBioProg.ToString)
                            cmd.Parameters.AddWithValue("@coursename", strCourse)
                            cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber.ToString)
                            cmd.Parameters.AddWithValue("@units", intCourseUnits.ToString)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Case "Access"
                            strSQL = "INSERT INTO Courses (BioProg_ID, CourseName, CourseNumber, Units) VALUES (@bioprogid, @coursename, @coursenumber, @units)"
                            Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.AddWithValue("@bioprogid", intBioProg.ToString)
                            cmd.Parameters.AddWithValue("@coursename", strCourse)
                            cmd.Parameters.AddWithValue("@coursenumber", intCourseNumber.ToString)
                            cmd.Parameters.AddWithValue("@units", intCourseUnits.ToString)
                            Dim i As Integer = cmd.ExecuteNonQuery()
                    End Select
                End If
            Next k
        Catch ex As Exception
            MsgBox("error: " & ex.ToString)
        End Try

        Me.Dispose()


    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        Me.Dispose()

    End Sub

End Class