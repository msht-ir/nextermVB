Public Class frmReportSettings
    Private Sub frmReportSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (ReportSettings And 1) = 1 Then
            CheckBoxRememberSettings.Checked = True
            If (ReportSettings And 2) = 2 Then RadioDaysInRows.Checked = True Else RadioDaysInCols.Checked = True
            If (ReportSettings And 4) = 4 Then CheckBoxDetails.Checked = True Else CheckBoxDetails.Checked = False
        Else
            CheckBoxRememberSettings.Checked = False
        End If

    End Sub
    Private Sub Menu_OK_Click(sender As Object, e As EventArgs) Handles Menu_OK.Click
        If CheckBoxRememberSettings.Checked = True Then ReportSettings = 1 Else ReportSettings = 0
        If RadioDaysInRows.Checked = True Then ReportSettings = ReportSettings + 2
        If CheckBoxDetails.Checked = True Then ReportSettings = ReportSettings + 4
        Retval1 = 1 '//make the report
        Me.Dispose()

    End Sub

    Private Sub Menu_Cancel_Click(sender As Object, e As EventArgs) Handles Menu_Cancel.Click
        If CheckBoxRememberSettings.Checked = True Then ReportSettings = 1 Else ReportSettings = 0
        If RadioDaysInRows.Checked = True Then ReportSettings = ReportSettings + 2
        If CheckBoxDetails.Checked = True Then ReportSettings = ReportSettings + 4
        Retval1 = 0 ' Cancel
        Me.Dispose()
    End Sub

    Private Sub CheckBoxDetails_CheckedChanged() Handles CheckBoxDetails.CheckedChanged
        If CheckBoxDetails.Checked = False Then
            RadioDaysInCols.Enabled = False
            RadioDaysInRows.Enabled = False
        Else
            RadioDaysInCols.Enabled = True
            RadioDaysInRows.Enabled = True
        End If
    End Sub
End Class