Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmReportSettings
    Private Sub frmReportSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (ReportSettings And 1) = 1 Then
            CheckBoxRememberSettings.Checked = True
            If (ReportSettings And 2) = 2 Then CheckBoxDetails.Checked = True Else CheckBoxDetails.Checked = False
            If (ReportSettings And 4) = 4 Then
                RadioDaysInRows.Checked = True
                RadioDaysInCols.Checked = False
            Else
                RadioDaysInRows.Checked = False
                RadioDaysInCols.Checked = True
            End If
            If (ReportSettings And 8) = 8 Then CheckBoxCourseName.Checked = True Else CheckBoxCourseName.Checked = False
            If (ReportSettings And 16) = 16 Then CheckBoxCourseNumber.Checked = True Else CheckBoxCourseNumber.Checked = False
            If (ReportSettings And 32) = 32 Then CheckBoxCourseGroup.Checked = True Else CheckBoxCourseGroup.Checked = False
            If (ReportSettings And 64) = 64 Then CheckBoxExamDate.Checked = True Else CheckBoxExamDate.Checked = False
            If (ReportSettings And 128) = 128 Then CheckBoxBG.Checked = True Else CheckBoxBG.Checked = False
            If (ReportSettings And 256) = 256 Then CheckBoxFreeTimes.Checked = True Else CheckBoxFreeTimes.Checked = False
            If (ReportSettings And 512) = 512 Then CheckBoxSuggest.Checked = True Else CheckBoxSuggest.Checked = False
            If (ReportSettings And 1024) = 1024 Then CheckBoxExamTable.Checked = True Else CheckBoxExamTable.Checked = False
        Else
            CheckBoxRememberSettings.Checked = False
        End If


        Try
            DS.Tables("tblTerms").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM Terms WHERE Terms.Active = 1 ORDER BY Term"
                    DASS.Fill(DS, "tblTerms")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT DISTINCT Terms.ID, Terms.Term, Terms.Active FROM Terms WHERE Terms.Active = True ORDER BY Term"
                    DAAC.Fill(DS, "tblTerms")
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        cboTerms.DataSource = DS.Tables("tblterms")
        cboTerms.DisplayMember = "Term"
        cboTerms.ValueMember = "ID"
        cboTerms.SelectedValue = intTerm

        CheckBoxDetails_CheckedChanged(sender, e)

    End Sub
    Private Sub CheckBoxDetails_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDetails.CheckedChanged
        Dim boolEnable As Boolean = False
        If CheckBoxDetails.Checked = False Then boolEnable = False Else boolEnable = True
        CheckBoxSuggest.Enabled = boolEnable
        CheckBoxFreeTimes.Enabled = True 'allways enabled
        CheckBoxExamTable.Enabled = boolEnable
        CheckBoxSuggest.Enabled = boolEnable
        RadioDaysInCols.Enabled = boolEnable
        RadioDaysInRows.Enabled = boolEnable
        CheckBoxCourseName.Enabled = boolEnable
        CheckBoxCourseNumber.Enabled = boolEnable
        CheckBoxCourseGroup.Enabled = boolEnable
        CheckBoxExamDate.Enabled = boolEnable

        If CheckBoxDetails.Checked = False Then CheckBoxFreeTimes.Checked = True
        RadioDaysInCols_CheckedChanged(sender, e)
    End Sub
    Private Sub CheckBoxFreeTimes_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxFreeTimes.CheckedChanged
        If CheckBoxFreeTimes.Checked = False Then CheckBoxDetails.Checked = True

    End Sub
    Private Sub RadioDaysInCols_CheckedChanged(sender As Object, e As EventArgs) Handles RadioDaysInCols.CheckedChanged
        Dim boolEnable As Boolean = False
        If RadioDaysInRows.Checked = False Then boolEnable = False Else boolEnable = True
        CheckBoxCourseName.Enabled = boolEnable
        CheckBoxCourseNumber.Enabled = boolEnable
        CheckBoxCourseGroup.Enabled = boolEnable
        CheckBoxExamDate.Enabled = boolEnable

    End Sub

    Private Sub SetReportSettings()
        ReportSettings = 0
        '//Flags of ReportSettings Register
        '0  1   : Remember Settings
        '1  2   : Report con Details
        '2  4   : Day in Cols:0/Rows:1
        '3  8   : Show CourseName
        '4  16  : Show CourseNr
        '5  32  : Show Group
        '6  64  : Show ExamDate
        '7  128 : BG 1/0
        '8  256 : Show free times (in Day in Col mode)
        '9  512 : Show suggestion for Tadakhols
        '10 1024: Show ExamDate Table
        If CheckBoxRememberSettings.Checked = True Then ReportSettings = 1 Else ReportSettings = 0
        If CheckBoxDetails.Checked = True Then ReportSettings = ReportSettings + 2
        If RadioDaysInRows.Checked = True Then ReportSettings = ReportSettings + 4  'Cols:0/Rows:1
        If CheckBoxCourseName.Checked = True Then ReportSettings = ReportSettings + 8
        If CheckBoxCourseNumber.Checked = True Then ReportSettings = ReportSettings + 16
        If CheckBoxCourseGroup.Checked = True Then ReportSettings = ReportSettings + 32
        If CheckBoxExamDate.Checked = True Then ReportSettings = ReportSettings + 64
        If CheckBoxBG.Checked = True Then ReportSettings = ReportSettings + 128
        If CheckBoxFreeTimes.Checked = True Then ReportSettings = ReportSettings + 256
        If CheckBoxSuggest.Checked = True Then ReportSettings = ReportSettings + 512
        If CheckBoxExamTable.Checked = True Then ReportSettings = ReportSettings + 1024

    End Sub

    'POPMENU
    Private Sub Menu_OK_Click(sender As Object, e As EventArgs) Handles Menu_OK.Click
        intTerm = cboTerms.SelectedValue
        If intTerm < 1 Then
            MsgBox("يک ترم را انتخاب کنيد", vbOKOnly, "نکسترم")
            cboTerms.Focus()
            Exit Sub
        End If
        strTerm = cboTerms.Text
        SetReportSettings()
        If (ReportSettings And &H2 = &H0) Then ReportSettings = (ReportSettings Or &H100) : Exit Sub ' 0x100= 0b100000000
        Retval1 = 1 '//make the report
        Me.Dispose()

    End Sub
    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        SetReportSettings()
        Retval1 = 0 ' Cancel
        Me.Dispose()
    End Sub
    Private Sub Menu_Guide_Click(sender As Object, e As EventArgs) Handles Menu_Guide.Click
        FileOpen(1, Application.StartupPath & "\NexTerm_Guide.html", OpenMode.Output)
        PrintLine(1, "<html dir=""rtl"">")
        PrintLine(1, "<head><title>راهنماي نکسترم</title><style>table, th,td {border: 1px solid;}</style></head>")
        PrintLine(1, "<body>")
        PrintLine(1, "<p style= 'color:blue; font-family:Tahoma; font-size:12px; Text-Align:Center'>دانشکده علوم پايه، دانشگاه شهرکرد</p>")
        PrintLine(1, "<hr>")
        PrintLine(1, "<p style='color:blue;font-family:tahoma; font-size:14px'>راهنماي گزينه هاي تنظيمات گزارش در نکسترم<br></p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>تنظيمات را به خاطر بسپار</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>با اين گزينه تا وقتي از نکسترم خارج نشده باشيد تنظيمات اين بخش براي گزارش هاي بعد حفظ مي شوند و نيازي به تکرار تنظيمات نيست</p>")


        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>گزارش با جزئيات</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>با غير فعال کردن اين گزينه، فقط محل برنامه ها روي جدول هفتگي با عدد 1 نشان داده مي شوند و تداخل ها با اعداد بزرگتر از 1 نشان داده مي شوند</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>پيشنهاد رفع تداخل</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>با اين گزينه درصورت وجود تداخل در برنامه، يکي از موارد به عنوان پيشنهاد نشان داده مي شود. يعني با تغيير زمانبندي آن درس ويا تغيير کلاس (بنا به مورد) مي توان تداخل را برطرف نمود </p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>جدول ساعت هاي ازاد</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>با انتخاب اين گزينه در زير جدول اصلي جدول برنامه هفتگي نشان داده مي شود که در آن محل برنامه ها با عدد 1 و تداخل ها با اعداد بزرگتر از 1 نشان داده مي شوند </p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>جدول تاريخ امتحانات</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>با انتخاب اين گزينه، جدول برنامه امتحانات که در ان درس ها به ترتيب تاريخ امتخان مرتب شده اند نشان داده مي شود. تاريخ/ساعت امتحانات را مي توان در نمايش (روزهاي هفته در سطر) نيز همراه با نام درس نشان داد</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>روزهاي هفته در سطر</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در اين نوع نمايش برنامه ها، روز هاي هفته در سطرها و ساعات روز در ستون ها هستند و در داخل جدول نام درس همراه با جزييات ديگر نشان داده مي شود</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>نام درس</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) نام درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>شماره درس</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) شماره درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>شماره گروه درس</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) شماره گروه درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>ساعت و تاريخ امتحان</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در نمايش (روزهاي هفته در سطر) ساعت و تاريخ امتحان درس را پس از نام استاد، همراه با ساير جزئيات (که قابل انتخاب هستند) نمايش مي دهد</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>روزهاي هفته در ستون</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در اين نوع نمايش برنامه ها، هر سطر به يک درس از برنامه اختصاص دارد و روزهاي هفته همراه با نام، شماره، واحد، گروه و ... ساير مشخصات درس، در ستون ها قرار دارند. درون جدول در (همان سطر) ساعات ارايه درس در هفته نشان داده مي شودي  </p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>تصوير زمينه</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>در صورت انتخاب اين گزينه، در پس زمينه گزارش يک تصوير (بک گراند) قرار داده مي شود. انتخاب تصوير در بخش تنظيمات توسط کاربر دانشکده صورت گرفته است و توسط ساير کاربران قابل تغيير نيست. براي خواناتر بودن گزارش بهتر است از پس زمينه استفاده نشود</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>منوي پنجره تنظيمات گزارش</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>منوهاي اين پنجره مانند بسياري از بخش هاي ديگر برنامه با راست کليک در پنجره برنامه ظاهر مي شوند. گزينه هاي اين منو عبارتند از</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>تاييد/ادامه</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>تنظيمات مورد نظر شما براي تهيه گزارش مورد استفاده قرار مي گيرند. همچنين در صورت انتخاب گزينه (تنظيمات را به خاطر بسپار) اين تنظيمات براي گزارش هاي بعدي (در همين جلسه کاري) مورد استفاده قرار مي گيرند</p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>راهنما</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>اين راهنما که در حال خواندن آن هستيد را نشان مي دهد </p>")

        PrintLine(1, "<p style='color:red;font-family:tahoma; font-size:14px'>انصراف/خروج</p>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:12px'>از پنجره تنظيمات گزارش خارج مي شود و گزارشي تهيه نمي شود. در صورت انتخاب گزينه (تنظيمات را به خاطر بسپار) اين تنظيمات براي گزارش هاي بعدي (در همين جلسه کاري) مورد استفاده قرار مي گيرند</p>")

        PrintLine(1, "</table><br><hr>")
        PrintLine(1, "<p style='font-family:tahoma; font-size:8px; text-align: center'>" & strReportsFooter & "</p>")
        PrintLine(1, "</body>")
        PrintLine(1, "</html>")
        FileClose(1)
        Shell("explorer.exe " & Application.StartupPath & "NexTerm_Guide.html")



    End Sub

End Class