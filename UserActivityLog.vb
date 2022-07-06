Public Class UserActivityLog
    Private Sub UserActivityLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.DataSource = DS.Tables("tblDepartments")
        ComboBox1.DisplayMember = "DEPT"
        ComboBox1.ValueMember = "ID"
        ComboBox1.SelectedValue = intUser

    End Sub
    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        intDept = ComboBox1.SelectedValue
    End Sub

    Private Sub Menu_Report_Click(sender As Object, e As EventArgs) Handles Menu_Report.Click
        If ((RadioButton3.Checked = True) And (ComboBox1.SelectedIndex < 0)) Then MsgBox("يک گروه از ليست انتخاب کنيد", vbOKOnly, "نکسترم") : Exit Sub
        Dim strFltr As String = ""
        DS.Tables("tblLogs").Clear()
        intDept = ComboBox1.SelectedValue

        strSQL = "SELECT DateTimex, UserID, NickName, ClientName, FrontEnd, strLog From xLog"
        If RadioButton1.Checked = True Then strFltr = "شامل: همه کاربران" & vbCrLf                                                                 'all users
        If RadioButton2.Checked = True Then strSQL = strSQL & " WHERE UserID=0" : strFltr = "شامل: کاربر دانشکده" & vbCrLf                         'usr faculty
        If RadioButton3.Checked = True Then strSQL = strSQL & " WHERE userID=" & intDept.ToString : strFltr = "شامل: يک گروه" & vbCrLf          'usr dept

        If RadioButton4.Checked = True Then strSQL = strSQL & " ORDER BY DateTimex DESC" : strFltr = strFltr & "ترتيب: تاريخ و زمان"                'Date/Time
        If RadioButton5.Checked = True Then strSQL = strSQL & " ORDER BY UserID, DateTimex DESC" : strFltr = strFltr & "ترتيب: کد کاربر"            'usr ID
        If RadioButton6.Checked = True Then strSQL = strSQL & " ORDER BY NickName, DateTimex DESC" : strFltr = strFltr & "ترتيب: نام مستعار"        'nick name
        If RadioButton7.Checked = True Then strSQL = strSQL & " ORDER BY ClientName, DateTimex DESC" : strFltr = strFltr & "ترتيب: سرويس گيرنده"    'client name

        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = strSQL
                    DASS.Fill(DS, "tblLogs") ' tbl Logs
                Case "Access"
                    DAAC.SelectCommand.CommandText = strSQL
                    DAAC.Fill(DS, "tblLogs") ' tbl Logs
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        FileOpen(1, Application.StartupPath & "Nexterm_log.html", OpenMode.Output)
        PrintLine(1, "<html dir= ""ltr"">")
        PrintLine(1, "<head><title>فعاليت کاربران</title><style>table, th, td {border: 1px solid;} </style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style='color:blue; font-family:tahoma; font-size:12px; text-align: center'>دانشگاه شهرکرد، دانشکده علوم پايه</p>")
        PrintLine(1, "<h4 style='color:red; font-family:tahoma; text-align: center'>Log for:  " & Server2Connect & "</h4>")

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>شناسه</th><th>نام گروه آموزشي</th></tr>")
        For i As Integer = 0 To DS.Tables("tblDepartments").Rows.Count - 1
            PrintLine(1, "<tr><td>", DS.Tables("tblDepartments").Rows(i).Item(0), "</td>")           ' 1 :id
            PrintLine(1, "<td>", DS.Tables("tblDepartments").Rows(i).Item(1), "</td></tr>")          ' 2 :DeptName
        Next
        PrintLine(1, "</table>")
        PrintLine(1, "<hr>")

        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>فعاليت کاربران </p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>" & strFltr & "</p>")

        PrintLine(1, "<table style='font-family:tahoma; font-size:12px; border-collapse:collapse'>")
        PrintLine(1, "<tr><th>Date and Time</th><th>Client</th><th>FrontEnd</th><th>Nickname</th><th>usr</th><th>Operation</th></tr>")
        For i As Integer = 0 To DS.Tables("tblLogs").Rows.Count - 1
            PrintLine(1, "<tr><td>", DS.Tables("tblLogs").Rows(i).Item(0), "</td>")      ' Date/Time
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(3), "</td>")          ' clnt
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(4), "</td>")          ' fe
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(2), "</td>")          ' nck
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(1), "</td>")          ' usr
            PrintLine(1, "<td>", DS.Tables("tblLogs").Rows(i).Item(5), "</td></tr>")     ' activity
        Next i
        PrintLine(1, "</table>")
        ' //footer
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'><br></p><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
        PrintLine(1, "</body></html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "Nexterm_log.html")


    End Sub

    Private Sub Menu_Exit_Click(sender As Object, e As EventArgs) Handles Menu_Exit.Click
        Me.Dispose()

    End Sub
End Class