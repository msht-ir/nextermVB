Public Class ChooseDept
    Private Sub ChooseDept_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListDepts.DataSource = DS.Tables("tblDepartments")
        ListDepts.DisplayMember = "DEPT"
        ListDepts.ValueMember = "ID"
        ListDepts.Refresh()
        ListDepts.SelectedIndex = -1
        ListDepts.SelectedValue = 0

    End Sub

    Private Sub MenuCancel_Click() Handles MenuCancel.Click
        strDept = ""
        intDept = 0
        Me.Dispose()

    End Sub

    Private Sub MenuOK_Click() Handles MenuOK.Click
        strDept = ListDepts.Text
        intDept = ListDepts.SelectedValue
        Me.Dispose()

    End Sub

    Private Sub ListDepts_DoubleClick(sender As Object, e As EventArgs) Handles ListDepts.DoubleClick
        MenuOK_Click()

    End Sub
End Class