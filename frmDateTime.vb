Public Class frmDateTime
    Private Sub frmDateTime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' // table of Exams dates for Entry
            DS.Tables("tblTermExams").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt, Entry_ID FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Entry_ID = " & intEntry.ToString & " ORDER BY ExamDate"
                    DASS.Fill(DS, "tblTermExams")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, [ProgramName] & ' - ' & [Entyear] AS strEnt, Entry_ID FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Entry_ID = " & intEntry.ToString & " ORDER BY ExamDate"
                    DAAC.Fill(DS, "tblTermExams")
            End Select

            For i As Integer = 0 To DS.Tables("tblTermExams").Rows.Count - 1
                GridEnt.Rows.Add("d_ " & DS.Tables("tblTermExams").Rows(i).Item(1).ToString & " _t", DS.Tables("tblTermExams").Rows(i).Item(2).ToString, DS.Tables("tblTermExams").Rows(i).Item(5).ToString)
            Next i
            GridEnt.Columns(0).Width = 110 'Exam
            GridEnt.Columns(1).Width = 200 'Course
            GridEnt.Columns(2).Width = 180 'Staff

            ' // table of Exams dates for Staff
            DS.Tables("tblTermExams").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, CONCAT([ProgramName] , ' - ' , [Entyear]) AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY ExamDate"
                    DASS.Fill(DS, "tblTermExams")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, ExamDate, CourseName, Course_ID, [Group], StaffName, Staff_ID, [ProgramName] & ' - ' & [Entyear] AS strEnt FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN (((TermProgs LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) ON Entries.ID = TermProgs.Entry_ID WHERE Term_ID = " & intTerm.ToString & " AND Staff_ID = " & intStaff.ToString & " ORDER BY ExamDate"
                    DAAC.Fill(DS, "tblTermExams")
            End Select

            For i As Integer = 0 To DS.Tables("tblTermExams").Rows.Count - 1
                GridStaff.Rows.Add("d_ " & DS.Tables("tblTermExams").Rows(i).Item(1).ToString & "_t", DS.Tables("tblTermExams").Rows(i).Item(2).ToString, DS.Tables("tblTermExams").Rows(i).Item(7).ToString)
            Next i
            GridStaff.Columns(0).Width = 110 'Exam
            GridStaff.Columns(1).Width = 150 'Course
            GridStaff.Columns(2).Width = 230 'Entry

            txtExamDate.Text = strExamDateTime
            lbl_Entry.Text = "برنامه امتحانات   " & strEntry
            lbl_Staff.Text = "برنامه استاد   " & strStaff
            lbl_Course.Text = strCourse
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub GridEnt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridEnt.CellClick
        Dim r As Integer = GridEnt.CurrentRow.Index
        If r < 0 Then Exit Sub
        txtExamDate.Text = Mid(GridEnt.Item(0, r).Value.ToString, 4)
    End Sub

    Private Sub GridStaff_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridStaff.CellClick
        Dim r As Integer = GridStaff.CurrentRow.Index
        If r < 0 Then Exit Sub
        txtExamDate.Text = Mid(GridStaff.Item(0, r).Value.ToString, 4)

    End Sub

    Private Sub Menu_OK_Click(sender As Object, e As EventArgs) Handles Menu_OK.Click
        strExamDateTime = txtExamDate.Text
        Me.Dispose()

    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        strExamDateTime = ""
        Me.Dispose()

    End Sub

    Private Sub Menu_Guide_Click(sender As Object, e As EventArgs) Handles Menu_Guide.Click
        Dim myansw As DialogResult = MsgBox("ار تاريخ هاي جداول فوق براي تعيين تاريخ اين درس کمک بگيريد" & vbCrLf & "پس از تاييد، در پنجره اصلي برنامه ها، تغييرات را ذخيره کنيد" & vbCrLf & "کمک بيشتري لازم است؟", vbYesNo, "نکسترم")
        If myansw = vbYes Then
            FileOpen(1, Application.StartupPath & "\NexTerm_Guide.html", OpenMode.Output)
            PrintLine(1, "<html dir=""rtl"">")
            PrintLine(1, "<head><title>راهنما</title><style>table, th,td {border: 1px solid;} body {background-image:url('" & strReportBG & "');} </style></head>")
            PrintLine(1, "<body>")
            PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>دانشکده علوم پايه دانشگاه شهرکرد</p>")
            PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>راهنماي نرم افزار نکسترم</p>")
            PrintLine(1, "<hr>")
            PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:12px'> راهنماي تعيين تاريخ امتحانات <br></p>")
            PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>")
            PrintLine(1, "تاريخ ساير امتحانات دانشجويان در پانل سمت راست ديده مي شود <br>")
            PrintLine(1, "تاريخ ساير امتحانات استاد در پانل سمت چپ ديده مي شود <br>")
            PrintLine(1, "تاريخ امتحان اين درس را در کادر پايين صفحه وارد کنيد  <br>")
            PrintLine(1, "اگر اين درس همزمان با درس ديگري امتحان گرفته مي شود، روي آن تاريخ موجود کليک کنيد <br>")
            PrintLine(1, "تاريخ امتحانات درس هاي ديگر فقط براي مشاهده هستند <br>")
            PrintLine(1, "پس از درج تاريخ امتحان درس آن را تاييد و در پنجره اصلي آن را ذخيره کنيد<br>")
            PrintLine(1, "توجه: حتما تاريخ امتحان درس را در پنجره اصلي برنامه ريزي، ذخيره کنيد<br>")
            PrintLine(1, "<br>")
            PrintLine(1, "موفق باشيد<br>")
            PrintLine(1, "<br></p>")
            PrintLine(1, "<br>")
            PrintLine(1, "<hr>")
            PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
            PrintLine(1, "</body>")
            PrintLine(1, "</html>")
            FileClose(1)
            Shell("explorer.exe " & Application.StartupPath & "NexTerm_Guide.html")


        End If
    End Sub
End Class