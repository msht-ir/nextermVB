Public Class ChooseTech
    Private Sub ChooseTech_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Userx = "USER Department" Then
            MenuAddNew.Enabled = False
            MenuEdit.Enabled = False
        End If
        'READ FROM DATABASE
        DS.Tables("tblTechs").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS.SelectCommand.CommandText = "SELECT ID, StaffName FROM Technecians ORDER BY StaffName"
                DASS.Fill(DS, "tblTechs")
            Case "Access"
                DAAC.SelectCommand.CommandText = "SELECT ID, StaffName FROM Technecians ORDER BY StaffName"
                DAAC.Fill(DS, "tblTechs")
        End Select

        ListTechs.DataSource = DS.Tables("tblTechs")
        ListTechs.DisplayMember = "StaffName"
        ListTechs.ValueMember = "ID"
        ListTechs.Refresh()
        ListTechs.SelectedIndex = -1
        ListTechs.SelectedValue = 0

    End Sub
    Private Sub ListTechs_DoubleClick(sender As Object, e As EventArgs) Handles ListTechs.DoubleClick
        MenuOK_Click(sender, e)
    End Sub

    Private Sub MenuOK_Click(sender As Object, e As EventArgs) Handles MenuOK.Click
        strTech = ListTechs.Text
        intTech = ListTechs.SelectedValue
        Me.Dispose()

    End Sub

    Private Sub MenuAddNew_Click(sender As Object, e As EventArgs) Handles MenuAddNew.Click
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4) = 0) Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim myansw As DialogResult = MsgBox("کارشناس جديد افزوده شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        If myansw = vbYes Then
            strTech = InputBox("نام کارشناس را وارد کنيد", "NexTerm", " کارشناس جديد " & ListTechs.Text)
            If strTech = "" Then
                Exit Sub
            Else
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "INSERT INTO Technecians (StaffName, TechCode) VALUES (@staffname, 0)"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strTech)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "INSERT INTO Technecians (StaffName, TechCode) VALUES (@staffname, 0)"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strTech)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                End Select
                ChooseTech_Load(sender, e)
            End If
        End If


    End Sub
    Private Sub MenuEdit_Click(sender As Object, e As EventArgs) Handles MenuEdit.Click
        'Edit
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessConntrols And (2 ^ 4) = 0) Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim myansw As DialogResult = MsgBox("نام کارشناس ويرايش شود؟", vbYesNo + vbDefaultButton2, "NexTerm")
        strTech = ListTechs.Text
        Dim r As Integer = ListTechs.SelectedValue
        If myansw = vbYes Then
            strStaff = InputBox("نام کارشناس را تصحيح کنيد", "NexTerm", strTech)
            If Trim(strTech) = "" Then
                Exit Sub
            Else
                DS.Tables("tblTechs").Rows(ListTechs.SelectedIndex).Item(1) = strTech
                Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                    Case "SqlServer"
                        strSQL = "UPDATE Technecians SET StaffName = @staffname WHERE ID = @id"
                        Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strStaff)
                        cmd.Parameters.AddWithValue("@id", r.ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                    Case "Access"
                        strSQL = "UPDATE Technecians SET StaffName = @staffname WHERE ID = @id"
                        Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@staffname", strStaff)
                        cmd.Parameters.AddWithValue("@id", r.ToString)
                        Dim i As Integer
                        i = cmd.ExecuteNonQuery()
                End Select
                ListTechs.Refresh()
                ChooseTech_Load(sender, e)
            End If
        End If

    End Sub

    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        strTech = ""
        intTech = 0
        Me.Dispose()

    End Sub
End Class