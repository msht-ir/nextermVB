Public Class frmReportSettings
    Private Sub frmReportSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (ReportSettings And 1) = 1 Then
            CheckBoxRememberSettings.Checked = True
            If (ReportSettings And 2) = 2 Then CheckBoxDetails.Checked = True Else CheckBoxDetails.Checked = False
            If (ReportSettings And 4) = 4 Then RadioDaysInRows.Checked = False Else RadioDaysInRows.Checked = True
            If (ReportSettings And 8) = 8 Then CheckBoxCourseName.Checked = True Else CheckBoxCourseName.Checked = False
            If (ReportSettings And 16) = 16 Then CheckBoxCourseNumber.Checked = True Else CheckBoxCourseNumber.Checked = False
            If (ReportSettings And 32) = 32 Then CheckBoxCourseGroup.Checked = True Else CheckBoxCourseGroup.Checked = False
            If (ReportSettings And 64) = 64 Then CheckBoxExamDate.Checked = True Else CheckBoxExamDate.Checked = False
        Else
            CheckBoxRememberSettings.Checked = False
        End If

    End Sub

    Private Sub SetReportSettings()
        ReportSettings = 0
        '//Flags of ReportSettings Register
        '0  1  : Remember Settings
        '1  2  : Report con Details
        '2  4  : Day in Cols:0/Rows:1
        '3  8  : Show CourseName
        '4  16 : Show CourseNr
        '5  32 : Show Group
        '6  64 : Show ExamDate
        '7  128: //reserved

        If CheckBoxRememberSettings.Checked = True Then ReportSettings = 1 Else ReportSettings = 0
        If CheckBoxDetails.Checked = True Then ReportSettings = ReportSettings + 2
        If RadioDaysInCols.Checked = True Then ReportSettings = ReportSettings + 4  'Cols:1/Rows:0
        If CheckBoxCourseName.Checked = True Then ReportSettings = ReportSettings + 8
        If CheckBoxCourseNumber.Checked = True Then ReportSettings = ReportSettings + 16
        If CheckBoxCourseGroup.Checked = True Then ReportSettings = ReportSettings + 32
        If CheckBoxExamDate.Checked = True Then ReportSettings = ReportSettings + 64

    End Sub
    Private Sub CheckBoxDetails_CheckedChanged() Handles CheckBoxDetails.CheckedChanged
        Dim boolEnable As Boolean = False
        If CheckBoxDetails.Checked = False Then boolEnable = False Else boolEnable = True

        RadioDaysInCols.Enabled = boolEnable
        RadioDaysInRows.Enabled = boolEnable
        CheckBoxCourseName.Enabled = boolEnable
        CheckBoxCourseNumber.Enabled = boolEnable
        CheckBoxCourseGroup.Enabled = boolEnable
        CheckBoxExamDate.Enabled = boolEnable

    End Sub

    'POPMENU
    Private Sub Menu_OK_Click(sender As Object, e As EventArgs) Handles Menu_OK.Click
        SetReportSettings()
        Retval1 = 1 '//make the report
        Me.Dispose()

    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        SetReportSettings()
        Retval1 = 0 ' Cancel
        Me.Dispose()
    End Sub


End Class