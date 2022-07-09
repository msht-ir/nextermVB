Public Class Templates
    Public trm As Integer = 1
    Private Sub Templates_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Fill ComboBox (Depts)
        ComboDepts.DataSource = DS.Tables("tblDepartments")
        ComboDepts.DisplayMember = "DEPT"
        ComboDepts.ValueMember = "ID"
        ComboDepts.SelectedValue = intDept

    End Sub
    Private Sub ComboDepts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboDepts.SelectedIndexChanged
        ShowDepartment()

    End Sub

    Private Sub ShowDepartment()
        'ComboDept -> Populates GridBioProgs
        Dim i As String = ComboDepts.GetItemText(ComboDepts.SelectedValue)
        If Val(i) = 0 Then Exit Sub

        DS.Tables("tblTemplates").Clear()
        DS.Tables("tblTemplateData").Clear()

        If (Userx = "USER Department") And (ComboDepts.SelectedValue <> intUser) Then Exit Sub

        GridTemplates.Focus()
        If (Userx = "USER Department" And DS.Tables("tblDepartments").Rows(ComboDepts.SelectedIndex).Item(2) = False) Then Exit Sub

        'READ FROM DATABASE
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT Templates.ID, ProgramName As Prog, TemplateName As Termic, nTerms As Terms, BioProgs.Department_ID, Templates.BioProg_ID FROM ((Departments INNER JOIN  BioProgs ON Departments.ID = BioProgs.Department_ID) INNER JOIN  Templates ON BioProgs.ID = Templates.BioProg_ID) WHERE BioProgs.Department_ID =" & i.ToString & " ORDER BY ProgramName, TemplateName"
                DASS.Fill(DS, "tblTemplates")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT Templates.ID, ProgramName As Prog, TemplateName As Termic, nTerms As Terms, BioProgs.Department_ID, Templates.BioProg_ID FROM ((Departments INNER JOIN  BioProgs ON Departments.ID = BioProgs.Department_ID) INNER JOIN  Templates ON BioProgs.ID = Templates.BioProg_ID) WHERE BioProgs.Department_ID =" & i.ToString & " ORDER BY ProgramName, TemplateName"
                DAAC.Fill(DS, "tblTemplates")
        End Select
        GridTemplates.DataSource = DS.Tables("tblTemplates")
        GridTemplates.Refresh()

        GridTemplates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridTemplates.RowHeadersVisible = False
        GridTemplates.Columns(0).Width = 0    'ID
        GridTemplates.Columns(1).Width = 230  'Prog
        GridTemplates.Columns(2).Width = 230   'Termic (TemplateName)
        GridTemplates.Columns(3).Width = 45   'nTerm
        GridTemplates.Columns(4).Width = 0    'DeptID
        GridTemplates.Columns(5).Width = 0    'BioProgID

        GridTemplates.Columns(0).Visible = False
        GridTemplates.Columns(4).Visible = False
        GridTemplates.Columns(5).Visible = False

        For k = 0 To GridTemplates.Columns.Count - 1
            GridTemplates.Columns.Item(k).SortMode = DataGridViewColumnSortMode.Programmatic
        Next k


    End Sub
    Private Sub ShowTemplate()
        'Refresh GridData
        Dim r As Integer = GridTemplates.CurrentRow.Index
        If r < 0 Then Exit Sub

        Dim i As Integer = Val(GridTemplates.Item(0, r).Value)
        If Val(i) = 0 Then Exit Sub
        'READ FROM DATABASE
        DS.Tables("tblTemplateData").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT TemplateData.ID, Template_ID, Course_ID, [Term], CourseName, CourseNumber, BioProg_ID FROM (TemplateData INNER JOIN Courses ON TemplateData.Course_ID = Courses.ID) WHERE Template_ID = " & i.ToString & " ORDER BY [Term], CourseName"
                DASS.Fill(DS, "tblTemplateData")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT TemplateData.ID, Template_ID, Course_ID, [Term], CourseName, CourseNumber, BioProg_ID FROM (TemplateData INNER JOIN Courses ON TemplateData.Course_ID = Courses.ID) WHERE Template_ID = " & i.ToString & " ORDER BY [Term], CourseName"
                DAAC.Fill(DS, "tblTemplateData")
        End Select
        GridTemplateData.DataSource = DS.Tables("tblTemplateData")
        GridTemplateData.Refresh()

        GridTemplateData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridTemplateData.RowHeadersVisible = False
        GridTemplateData.Columns(0).Width = 0     'ID
        GridTemplateData.Columns(1).Width = 0     'Template_ID
        GridTemplateData.Columns(2).Width = 0     'Course_ID
        GridTemplateData.Columns(3).Width = 60    'Term
        GridTemplateData.Columns(4).Width = 300   'CourseName
        GridTemplateData.Columns(5).Width = 120   'CourseNumber
        GridTemplateData.Columns(6).Width = 0     'BioProgID

        GridTemplateData.Columns(0).Visible = False
        GridTemplateData.Columns(1).Visible = False
        GridTemplateData.Columns(2).Visible = False
        GridTemplateData.Columns(6).Visible = False

        For i = 0 To GridTemplateData.Columns.Count - 1
            GridTemplateData.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

    End Sub

    Private Sub Grid1(sender As Object, e As DataGridViewCellEventArgs) Handles GridTemplates.CellClick
        'GridTemplates -> Populates GridData
        ShowTemplate()
        trm = 1
    End Sub
    Private Sub Grid1_Dbl(sender As Object, e As DataGridViewCellEventArgs) Handles GridTemplates.CellContentDoubleClick
        If (Userx = "USER Faculty") Then MsgBox("برنامه ريزي ترميک در اختيار مدير گروه است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridTemplates.RowCount < 1 Then Exit Sub
        Dim r As Integer = e.RowIndex 'count from 0
        Dim c As Integer = e.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub

        Select Case c'SELECT BASED ON GRID.COLUMN
            Case 2 'Termic Prog Title
                Dim ProTitle As String = DS.Tables("tblTemplates").Rows(r).Item(2)
                ProTitle = InputBox("Change to  > ", "NexTerm", ProTitle)
                DS.Tables("tblTemPlates").Rows(r).Item(2) = ProTitle
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE Templates SET TemplateName = @ProTitle WHERE ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ProTitle", ProTitle)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplates").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE Templates SET TemplateName = @ProTitle WHERE ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@ProTitle", ProTitle)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplates").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select

            Case 3 'nTerm
                Dim nt As Integer = DS.Tables("tblTemplates").Rows(r).Item(3)
                nt = Val(InputBox("Change to  > ", "NexTerm", nt))
                DS.Tables("tblTemPlates").Rows(r).Item(3) = nt
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE Templates SET nTerms = @nt WHERE Templates.ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@nt", nt)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplates").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE Templates SET nTerms = @nt WHERE Templates.ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@nt", nt)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplates").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select

        End Select
    End Sub
    Private Sub Grid2_DoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridTemplateData.CellDoubleClick
        If (Userx = "USER Faculty") Then MsgBox("برنامه ريزي ترميک در اختيار مدير گروه است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridTemplateData.RowCount < 1 Then Exit Sub
        Dim r As Integer = e.RowIndex 'count from 0
        Dim c As Integer = e.ColumnIndex 'count from 0
        If r < 0 Or c < 0 Then Exit Sub

        Select Case c'SELECT BASED ON GRID.COLUMN
            Case 3 'Term
                trm = DS.Tables("tblTemplateData").Rows(r).Item(3)
                trm = Val(InputBox("انتقال به ترم:", "NexTerm", trm))
                If trm = 0 Then trm = 1
                DS.Tables("tblTemplateData").Rows(r).Item(3) = trm
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TemplateData SET [Term] = @trm WHERE TemplateData.ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@trm", trm)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplateData").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TemplateData SET [Term] = @trm WHERE TemplateData.ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@trm", trm)
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplateData").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select


            Case 4 'Course
                intDept = ComboDepts.GetItemText(ComboDepts.SelectedValue)
                intBioProg = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(5)
                intCourse = DS.Tables("tbltemplateData").Rows(r).Item(2)
                ChooseCourse.ShowDialog()
                If strCourse = "" Then Exit Sub

                DS.Tables("tbltemplateData").Rows(r).Item(4) = strCourse
                DS.Tables("tbltemplateData").Rows(r).Item(5) = intCourseNumber
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE TemplateData SET Course_ID = @courseid WHERE TemplateData.ID = @ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplateData").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE TemplateData SET Course_ID = @courseid WHERE TemplateData.ID = @ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                        cmd.Parameters.AddWithValue("@ID", DS.Tables("tblTemplateData").Rows(r).Item(0).ToString)
                        Dim i As Integer = cmd.ExecuteNonQuery()
                End Select


            Case 5 'CourseNumber
                intCourse = Val(DS.Tables("tblTemplateData").Rows(r).Item(2))
                Dim coursenumber As Double
                Try
                    coursenumber = Val(DS.Tables("tblTemplateData").Rows(r).Item(5))
                Catch
                    coursenumber = 0
                End Try
                coursenumber = Val(InputBox("تصحيح شماره درس", "NexTerm", coursenumber))
                If coursenumber = 0 Then Exit Sub
                DS.Tables("tblTemplateData").Rows(r).Item(5) = coursenumber
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE Courses SET CourseNumber=@coursenumber WHERE ID=@ID"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@coursenumber", coursenumber.ToString)
                        cmd.Parameters.AddWithValue("@ID", intCourse.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch
                            MsgBox("Err... intCourse:" & intCourse & " / CourseNumber: " & coursenumber)
                        End Try
                    Case "Access"
                        strSQL = "UPDATE Courses SET CourseNumber=@coursenumber WHERE ID=@ID"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@coursenumber", coursenumber.ToString)
                        cmd.Parameters.AddWithValue("@ID", intCourse.ToString)
                        Try
                            Dim i As Integer = cmd.ExecuteNonQuery()
                        Catch
                            MsgBox("Err... intCourse:" & intCourse & " / CourseNumber: " & coursenumber)
                        End Try
                End Select
        End Select
        ShowTemplate()

    End Sub

    Private Sub Menu_AddCourse_Click(sender As Object, e As EventArgs) Handles Menu_AddCourse.Click
        If (Userx = "USER Faculty") Then MsgBox("برنامه ريزي ترميک در اختيار مدير گروه است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridTemplates.SelectedCells.Count < 1 Then
            MsgBox("يک برنامه الگو از ليست انتخاب کنيد", vbOKOnly, "نکسترم")
            Exit Sub
        End If

        Try
            intBioProg = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(0)
            'MsgBox(intBioProg.ToString)
            If intBioProg < 1 Then Exit Sub
            intDept = ComboDepts.GetItemText(ComboDepts.SelectedValue)
            strDept = ComboDepts.Text
            intBioProg = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(5)
            strBioProg = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(1)
            ChooseCourse.ShowDialog()
            If strCourse = "" Then Exit Sub
            trm = Val(txtTerm.Text)
            If (trm < 1) Or (trm > 10) Or (chkAsk.Checked = True) Then
                trm = Val(InputBox("در ترم", "برنامه ترميک", trm))
                If trm < 1 Or trm > 10 Then trm = 1
                txtTerm.Text = trm.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "INSERT INTO TemplateData (Template_ID, Course_ID, [Term]) VALUES (@templateid, @courseid, @trm)"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@templateid", Val(DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(0)))
                cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                cmd.Parameters.AddWithValue("@trm", trm)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "INSERT INTO TemplateData (Template_ID, Course_ID, [Term]) VALUES (@templateid, @courseid, @trm)"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@templateid", Val(DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(0)))
                cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                cmd.Parameters.AddWithValue("@trm", trm)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select
        ShowTemplate()

    End Sub
    Private Sub Menu_DelCourse_Click(sender As Object, e As EventArgs) Handles Menu_DelCourse.Click
        If (Userx = "USER Faculty") Then MsgBox("برنامه ريزي ترميک در اختيار مدير گروه است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Try
            If GridTemplateData.SelectedCells.Count < 1 Then
                MsgBox("يک برنامه الگو از ليست انتخاب کنيد", vbOKOnly, "نکسترم")
                Exit Sub
            End If

            Dim r As Integer = GridTemplateData.SelectedCells(0).RowIndex 'count from 0
            If r < 0 Then
                MsgBox("يک درس را انتخاب کنيد", vbOKOnly, "نکسترم")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Dim idDEL As Integer = DS.Tables("tblTemplateData").Rows(GridTemplateData.CurrentRow.Index).Item(0)
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "DELETE From TemplateData WHERE ID = @iddel"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@iddel", idDEL)
                Dim myansw As Integer = MsgBox("اين درس حذف شود؟" & Chr(13) & Chr(13) & DS.Tables("tblTemplateData").Rows(GridTemplateData.CurrentRow.Index).Item(4), vbYesNo + vbDefaultButton2, "تاييد کنيد")
                If myansw = vbNo Then Exit Sub
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "DELETE * From TemplateData WHERE ID = @iddel"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@iddel", idDEL)
                Dim myansw As Integer = MsgBox("اين درس حذف شود؟" & Chr(13) & Chr(13) & DS.Tables("tblTemplateData").Rows(GridTemplateData.CurrentRow.Index).Item(4), vbYesNo + vbDefaultButton2, "تاييد کنيد")
                If myansw = vbNo Then Exit Sub
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select
        ShowTemplate()

    End Sub

    Private Sub Menu_AddNew_Click(sender As Object, e As EventArgs) Handles Menu_AddNew.Click
        If (Userx = "USER Faculty") Then MsgBox("برنامه ريزي ترميک در اختيار مدير گروه است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If ComboDepts.SelectedIndex = -1 Then Exit Sub
        intDept = ComboDepts.SelectedValue
        ChooseBioProg.ShowDialog()
        If strBioProg = "" Then Exit Sub

        Dim strTemplate As String = InputBox("Enter Template Name  >", "NexTerm", "برنامه ترميک")
        If strTemplate = "" Then Exit Sub
        Dim intTerms As Integer = 1
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "INSERT INTO Templates (TemplateName, nTerms, [BioProg_ID]) VALUES (@templatenm, @nt, @progid)"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@templatenm", strTemplate)
                cmd.Parameters.AddWithValue("@nt", Val(intTerms))
                cmd.Parameters.AddWithValue("@progid", Val(intBioProg))
                Try
                    cmd.ExecuteNonQuery()
                    WriteLOG(21)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "INSERT INTO Templates (TemplateName, nTerms, [BioProg_ID]) VALUES (@templatenm, @nt, @progid)"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@templatenm", strTemplate)
                cmd.Parameters.AddWithValue("@nt", Val(intTerms))
                cmd.Parameters.AddWithValue("@progid", Val(intBioProg))
                Try
                    cmd.ExecuteNonQuery()
                    WriteLOG(21)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select

        ShowDepartment()

    End Sub
    Private Sub Menu_Del_Click(sender As Object, e As EventArgs) Handles Menu_Del.Click
        If (Userx = "USER Faculty") Then MsgBox("برنامه ريزي ترميک در اختيار مدير گروه است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridTemplates.RowCount < 1 Then Exit Sub

        Dim myansw As Integer
        If GridTemplateData.RowCount > 0 Then
            myansw = MsgBox("اين الگو برنامه ريزي شده است، حذف شوند؟", vbYesNo + vbDefaultButton2, "تاييد کنيد")
            If myansw = vbNo Then
                Exit Sub
            Else
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "DELETE From TemplateData WHERE Template_ID = @iddel1"
                        Dim cmd1 As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd1.CommandType = CommandType.Text
                        cmd1.Parameters.AddWithValue("@iddel1", Val(DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(0)))
                        Try
                            Dim i As Integer = cmd1.ExecuteNonQuery()
                            ShowTemplate()
                            MsgBox("برنامه ريزي اين الگو پاک شد",, "")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Case "Access"
                        strSQL = "DELETE * From TemplateData WHERE Template_ID = @iddel1"
                        Dim cmd1 As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd1.CommandType = CommandType.Text
                        cmd1.Parameters.AddWithValue("@iddel1", Val(DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(0)))
                        Try
                            Dim i As Integer = cmd1.ExecuteNonQuery()
                            ShowTemplate()
                            MsgBox("برنامه ريزي اين الگو پاک شد",, "")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                End Select

            End If
        End If
        myansw = MsgBox("اين الگو حذف شود؟" & Chr(13) & Chr(13) & DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(2), vbYesNo + vbDefaultButton2, "تاييد کنيد")
        If myansw = vbNo Then Exit Sub
        Dim idDEL As Integer = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(0)
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                strSQL = "DELETE From Templates WHERE ID = @iddel"
                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@iddel", idDEL)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    WriteLOG(22)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Case "Access"
                strSQL = "DELETE * From Templates WHERE ID = @iddel"
                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                cmd.CommandType = CommandType.Text
                cmd.Parameters.AddWithValue("@iddel", idDEL)
                Try
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    WriteLOG(22)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select


        ShowDepartment()

    End Sub
    Private Sub Menu_ReportMe_Click(sender As Object, e As EventArgs) Handles Menu_ReportMe.Click
        If GridTemplateData.Rows.Count < 1 Then Exit Sub
        'MsgBox(GridTemplateData.Rows.Count.ToString)
        strBioProg = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentCell.RowIndex).Item(1)
        FileOpen(1, Application.StartupPath & "\NexTerm_Report_Template.html", OpenMode.Output)
        PrintLine(1, "<html dir=""rtl"">")
        PrintLine(1, "<head>")
        PrintLine(1, "<title>گزارش الگو</title>")
        PrintLine(1, "<style>table, th,td {border: 1px solid;} body {background-image:url('" & strReportBG & "');} </style>")
        PrintLine(1, "</head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h1 style ='color:red; text-align: center'> برنامه ترميک براي دوره آموزشي ", strBioProg, "</h1>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
        PrintLine(1, " برنامه ترميک (الگو) براي ورودي هاي ")
        PrintLine(1, strBioProg)
        PrintLine(1, "<br>")
        PrintLine(1, "</p>")

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr>")
        PrintLine(1, "<th>نيمسال</th>")
        PrintLine(1, "<th>نام درس</th>")
        PrintLine(1, "<th>شماره درس</th>")
        PrintLine(1, "</tr>")
        For i As Integer = 0 To GridTemplateData.Rows.Count - 1
            PrintLine(1, "<tr>")
            PrintLine(1, "<td Style=Text-Align:Center;>", GridTemplateData.Item(3, i).Value, "</td>") ' Term
            PrintLine(1, "<td>", GridTemplateData.Item(4, i).Value, "</td>") ' CourseName
            PrintLine(1, "<td>", GridTemplateData.Item(5, i).Value, "</td>") ' CourseNumber
            PrintLine(1, "</tr>")
        Next
        PrintLine(1, "</table>")

        PrintLine(1, "<br>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
        PrintLine(1, "</body>")
        PrintLine(1, "</html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "NexTerm_Report_Template.html")


    End Sub
    Private Sub Menu_Apply_Click(sender As Object, e As EventArgs) Handles Menu_Apply.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (برنامه ريزي) اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridTemplateData.Rows.Count = 0 Then Exit Sub

        ' A: Get an Entry ID 
        intBioProg = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(5)
        strBioProg = GridTemplates(1, GridTemplates.CurrentRow.Index).Value
        intDept = ComboDepts.SelectedValue
        ChooseEntry.ShowDialog()
        If intEntry = 0 Then Exit Sub
        ' OK, we have: intEntry (ID), intYearEntered (EntYear)

        Dim intNTerms As Integer = DS.Tables("tblTemplates").Rows(GridTemplates.CurrentRow.Index).Item(3) 'Item 3 is nTerms 

        ' B: Check if Entry is already programmed -> Del previous progs in this Entry?
        '                                         -> Confirm: Assign this_Template -> selected_Entry ?
        DS.Tables("tblTermProgs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT ID FROM TermProgs WHERE Entry_ID = " & intEntry.ToString
                DASS.Fill(DS, "tblTermProgs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT ID FROM TermProgs WHERE Entry_ID = " & intEntry.ToString
                DAAC.Fill(DS, "tblTermProgs")
        End Select
        If DS.Tables("tblTermProgs").Rows.Count > 0 Then
            Select Case Userx
                Case "USER Faculty"
                    Dim myansw As DialogResult = MsgBox("ورودي   " & vbCrLf & strEntry & vbCrLf & "قبلا برنامه ريزي شده است" & vbCrLf & "برنامه ريزي قبلي اين ورودي حذف شود؟", vbOKCancel + vbDefaultButton2, "توجه:")
                    If myansw = vbYes Then
                        'DELETE existing TermProgs of this Entry
                        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                            Case "SqlServer"
                                strSQL = "DELETE * From TermProgs WHERE Entry_ID = @id"
                                Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intEntry.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                    MsgBox("برنامه حذف شد", vbOKOnly, "NexTerm")
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                            Case "Access"
                                strSQL = "DELETE * From TermProgs WHERE Entry_ID = @id"
                                Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                                cmd.CommandType = CommandType.Text
                                cmd.Parameters.AddWithValue("@id", intEntry.ToString)
                                Try
                                    Dim i As Integer = cmd.ExecuteNonQuery()
                                    MsgBox("برنامه حذف شد", vbOKOnly, "NexTerm")
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                End Try
                        End Select

                    End If
                Case "USER Department"
                    MsgBox("اين ورودي قبلا برنامه ريزي شده است" & vbCrLf & "براي برنامه ريزي مجدد ورودي" & vbCrLf & strEntry & vbCrLf & "از کاربر دانشکده بخواهيد برنامه ريزي قبلي اين ورودي را حذف نمايد", vbOKOnly, "توجه")
                    Exit Sub
            End Select
        End If

        ' C: Required Terms be created {nTerms, YearEnt -> create required Terms}

        DS.Tables("tblTerms").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT ID, Term FROM Terms"
                DASS.Fill(DS, "tblTerms")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT ID, Term FROM Terms"
                DAAC.Fill(DS, "tblTerms")
        End Select

        Dim Term1, Term2 As String
        Dim ix As Integer
        For i As Integer = 1 To Int(intNTerms / 2 + 0.5)
            Term1 = Trim(Str(intYearEntered + i - 1) & "-1")

            Dim Resultx = From trm In DS.Tables("tblTerms").AsEnumerable() Where trm.Field(Of String)("Term") = Term1 Select trm
            Dim ResultxCount As Integer = Resultx.Count()

            If ResultxCount = 0 Then
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO Terms (Term) VALUES (@term)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@term", Term1)
                        Try
                            ix = cmd.ExecuteNonQuery()
                            'MsgBox(Term1 & " ايجاد شد ")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Case "Access"
                        strSQL = "INSERT INTO Terms (Term) VALUES (@term)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@term", Term1)
                        Try
                            ix = cmd.ExecuteNonQuery()
                            'MsgBox(Term1 & " ايجاد شد ")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                End Select
            End If

            Term2 = Trim(Str(intYearEntered + i - 1) & "-2")
            Dim Resultx2 = From trm In DS.Tables("tblTerms").AsEnumerable() Where trm.Field(Of String)("Term") = Term2 Select trm
            Dim Resultx2Count As Integer = Resultx.Count()

            If ResultxCount = 0 Then
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO Terms (Term) VALUES (@term)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@term", Term2)
                        Try
                            ix = cmd.ExecuteNonQuery()
                            'MsgBox(Term2 & " ايجاد شد ")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    Case "Access"
                        strSQL = "INSERT INTO Terms (Term) VALUES (@term)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@term", Term2)
                        Try
                            ix = cmd.ExecuteNonQuery()
                            'MsgBox(Term2 & " ايجاد شد ")
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                End Select
            End If
        Next i

        ' D: Add Courses in Template to Correct Terms

        DS.Tables("tblTemplateData").Clear()
        Dim intTemplateID As Integer = GridTemplates(0, GridTemplates.CurrentRow.Index).Value
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT ID, TempLate_ID, Course_ID, Term FROM TemPlateData WHERE Template_ID = " & intTemplateID.ToString
                DASS.Fill(DS, "tblTemplateData")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT ID, TempLate_ID, Course_ID, Term FROM TemPlateData WHERE Template_ID = " & intTemplateID.ToString
                DAAC.Fill(DS, "tblTemplateData")
        End Select

        Dim intTemplateDateRecords = DS.Tables("tblTemplateData").Rows.Count
        Dim intThisCourseTerm As Integer
        Dim grp As Integer = 1

        For i = 0 To intTemplateDateRecords - 1
            intCourse = DS.Tables("tblTemplateData").Rows(i).Item(2) ' Course: ID
            intThisCourseTerm = DS.Tables("tblTemplateData").Rows(i).Item(3)   ' Term: int from 1 to 8)

            strTerm = Trim(Str(intYearEntered + Int(intThisCourseTerm / 2 - 0.5)))
            If intThisCourseTerm / 2 = Int(intThisCourseTerm / 2) Then strTerm = strTerm & "-2" Else strTerm = strTerm & "-1"

            DS.Tables("tblTerms").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "Select ID, Term FROM Terms WHERE Term ='" & strTerm & "'"
                    DASS.Fill(DS, "tblTerms")
                    intTerm = DS.Tables("tblTerms").Rows(0).Item(0)
                    strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@entryid, @termid, @courseid, 1)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@entryid", Val(intEntry))
                    cmd.Parameters.AddWithValue("@termid", Val(intTerm))
                    cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                    Try
                        Dim n As Integer = cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                Case "Access"
                    DAAC.SelectCommand.CommandText = "Select ID, Term FROM Terms WHERE Term ='" & strTerm & "'"
                    DAAC.Fill(DS, "tblTerms")
                    intTerm = DS.Tables("tblTerms").Rows(0).Item(0)
                    strSQL = "INSERT INTO TermProgs (Entry_ID, Term_ID, Course_ID, [Group]) VALUES (@entryid, @termid, @courseid, 1)"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@entryid", Val(intEntry))
                    cmd.Parameters.AddWithValue("@termid", Val(intTerm))
                    cmd.Parameters.AddWithValue("@courseid", Val(intCourse))
                    Try
                        Dim n As Integer = cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
            End Select

        Next

        WriteLOG(23)
        MsgBox("ورودي  " & strEntry & " برنامه ريزي شد", vbOKOnly, "نکسترم")
        ShowTemplate()


    End Sub

    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG 'There is a similar SUB() in TermProgs_Form
            If Userx = "USER Faculty" Then intUser = 0
            Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
            Dim intUserID As Integer = intUser
            Dim strNickName As String = UserNickName
            Dim strClientName As String = LCase(Environment.MachineName)
            Dim strFrontEnd As String = LCase(strBuildInfo)
            Dim strLog As String = ""
            Select Case intActivity
                Case 21 : strLog = "tmplt+:" & intBioProg.ToString
                Case 22 : strLog = "tmplt-:" & intBioProg.ToString
                Case 23 : strLog = "tmplt.usd:" & intBioProg.ToString
            End Select
            Try
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO xLog (DateTimex, UserID, NickName, ClientName, FrontEnd, strLog) VALUES (@datetime, @userid, @nickname, @clientname, @frontend, @strlog)"
                        Dim cmdx As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmdx.CommandType = CommandType.Text
                        cmdx.Parameters.AddWithValue("@datetime", strDateTime)
                        cmdx.Parameters.AddWithValue("@userid", intUserID.ToString)
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
                        cmdx.Parameters.AddWithValue("@userid", intUserID.ToString)
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
    Private Sub Menu_ExitBack_Click(sender As Object, e As EventArgs) Handles Menu_ExitBack.Click
        Me.Dispose()

    End Sub

End Class