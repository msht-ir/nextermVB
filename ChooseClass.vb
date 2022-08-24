Public Class ChooseClass
    Private Sub ChooseClass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Grid5.Rows.Add("ش")
        Grid5.Rows.Add("ی")
        Grid5.Rows.Add("د")
        Grid5.Rows.Add("س")
        Grid5.Rows.Add("چ")
        Grid5.Rows.Add("پ")

        ShowClasses()

        If intTerm < 1 Then
            Dim myansw As DialogResult = MsgBox("يک نيمسال را مشخص مي کنيد؟", vbYesNoCancel, "نکسترم")
            Select Case myansw
                Case vbCancel
                    Me.Dispose()
                Case vbYes
                    strCaption = "Terms"
                    ChooseTerm.ShowDialog()
                Case vbNo 'Do nothing!
            End Select
        End If
    End Sub
    Private Sub ShowClasses()
        If Userx = "USER Department" Then
            MenuAddNewClass.Enabled = False
            Menu_Edit.Enabled = False
        End If
        GridRoom.EditMode = DataGridViewEditMode.EditProgrammatically

        'READ FROM DATABASE
        DS.Tables("tblRooms").Clear()
        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                Select Case Userx
                    Case "USER Faculty"
                        DASS.SelectCommand.CommandText = "SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act FROM Rooms ORDER BY RoomName"
                    Case "USER Department"
                        DASS.SelectCommand.CommandText = "SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act FROM Rooms WHERE Active = 1 ORDER BY RoomName"
                End Select
                DASS.Fill(DS, "tblRooms")
            Case "Access"
                Select Case Userx
                    Case "USER Faculty"
                        DAAC.SelectCommand.CommandText = "SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act FROM Rooms ORDER BY RoomName"
                    Case "USER Department"
                        DAAC.SelectCommand.CommandText = "SELECT ID, RoomName As Class, RoomCapacity As Capa, VideoProjector As AV, Active As Act FROM Rooms WHERE Active = True ORDER BY RoomName"
                End Select
                DAAC.Fill(DS, "tblRooms")
        End Select

        GridRoom.DataSource = DS.Tables("tblRooms")
        GridRoom.Refresh()

        GridRoom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        GridRoom.Columns(0).Visible = False    'ID
        GridRoom.Columns(1).Width = 190        'Room
        GridRoom.Columns(2).Width = 35         'Capa
        GridRoom.Columns(3).Width = 25         'AV
        GridRoom.Columns(4).Width = 30         'Active
        If Userx = "USER Department" Then GridRoom.Columns(4).Visible = False Else GridRoom.Columns(4).Visible = True

        'inactivate columns sort property
        For i = 0 To Grid5.Columns.Count - 1
            Grid5.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i
        For i = 0 To GridRoom.Columns.Count - 1
            GridRoom.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
        Next i

        'select default room
        Try
            If intRoom > 0 Then
                For i = 0 To GridRoom.Rows.Count - 1
                    If GridRoom(0, i).Value = intRoom Then GridRoom.CurrentCell = GridRoom.Rows(i).Cells(1)
                Next i
                GridRoom_CellClick()
            Else
                'GridRoom.CurrentCell = GridRoom.Rows(0).Cells(1)
                GridRoom.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub



    ' //GridRoom
    Private Sub GridRoom_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles GridRoom.CellValueChanged
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridRoom.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridRoom.CurrentCell.RowIndex   'count from 0
        If r < 0 Then Exit Sub
        GridRoom.CurrentCell = GridRoom(1, r)
        Dim strClassName As String = GridRoom.Rows(r).Cells(1).Value
        DS.Tables("tblRooms").Rows(r).Item(1) = strClassName

        Dim intCapa As Integer = GridRoom.Rows(r).Cells(2).Value
        DS.Tables("tblRooms").Rows(r).Item(2) = intCapa

        Dim boolAV As Integer = GridRoom.Rows(r).Cells(3).Value
        DS.Tables("tblRooms").Rows(r).Item(3) = boolAV

        Dim boolActive As Boolean = GridRoom.Rows(r).Cells(4).Value
        DS.Tables("tblRooms").Rows(r).Item(4) = boolActive

        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "UPDATE Rooms SET RoomName = @roomname, RoomCapacity = @roomcapacity, VideoProjector = @videoprojector, Active = @active WHERE ID = @ID"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@roomname", strClassName.ToString)
                    cmd.Parameters.AddWithValue("@roomcapacity", intCapa)
                    cmd.Parameters.AddWithValue("@videoprojector", boolAV)
                    cmd.Parameters.AddWithValue("@active", boolActive)
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblRooms").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "UPDATE Rooms SET RoomName = @roomname, RoomCapacity = @roomcapacity, VideoProjector = @videoprojector, Active = @active WHERE ID = @ID"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@roomname", strClassName.ToString)
                    cmd.Parameters.AddWithValue("@roomcapacity", intCapa)
                    cmd.Parameters.AddWithValue("@videoprojector", boolAV)
                    cmd.Parameters.AddWithValue("@active", boolActive)
                    cmd.Parameters.AddWithValue("@ID", DS.Tables("tblRooms").Rows(r).Item(0).ToString)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
    Private Sub GridRoom_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridRoom.CellDoubleClick
        Dim r As Integer = GridRoom.CurrentCell.RowIndex   'count from 0
        If r < 0 Then Exit Sub
        Try
            If e.ColumnIndex = 4 Then ' toggle Active_Room
                Dim boolActx As Boolean = GridRoom.Rows(r).Cells(4).Value
                If boolActx = True Then GridRoom.Rows(r).Cells(4).Value = False Else GridRoom.Rows(r).Cells(4).Value = True
            Else
                MenuOK_Click(sender, e)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub GridRoom_CellClick() Handles GridRoom.CellClick
        lblInfo.Text = "info"
        Try
            Dim ri As Integer = GridRoom.CurrentRow.Index
            intRoom = GridRoom(0, ri).Value
            For c As Integer = 1 To 8
                For r As Integer = 0 To 5
                    Grid5(c, r).Value = ""
                    Grid5(c, r).Style.ForeColor = Color.Black
                    Grid5(c, r).Style.BackColor = Color.White
                Next r
            Next c
            DS.Tables("tblAllProgs").Clear()
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    DASS.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, CONCAT([ProgramName] , ' - ' , [Entyear]) AS Ent, Terms.Term FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Term_ID = " & intTerm.ToString & ") AND ((Room1 = " & intRoom.ToString & ") OR (Room2 = " & intRoom.ToString & "))"
                    DASS.Fill(DS, "tblAllProgs")
                Case "Access"
                    DAAC.SelectCommand.CommandText = "SELECT TermProgs.ID, Course_ID, CourseNumber, CourseName, Units, [Group], Staff_ID, Staff.StaffName, Tech_ID, Technecians.StaffName, SAT1, SUN1, MON1, TUE1, WED1, THR1, Room1, Rooms.RoomName, SAT2, SUN2, MON2, TUE2, WED2, THR2, Room2, Rooms_1.RoomName, Capacity, ExamDate, TermProgs.Notes, [ProgramName] & ' - ' & [Entyear], Terms.Term AS Ent FROM (BioProgs INNER JOIN Entries ON BioProgs.ID = Entries.BioProg_ID) INNER JOIN ((((((Rooms AS Rooms_1 RIGHT JOIN TermProgs ON Rooms_1.ID = TermProgs.Room2) LEFT JOIN Rooms ON TermProgs.Room1 = Rooms.ID) LEFT JOIN Terms ON TermProgs.Term_ID = Terms.ID) LEFT JOIN Courses ON TermProgs.Course_ID = Courses.ID) LEFT JOIN Staff ON TermProgs.Staff_ID = Staff.ID) LEFT JOIN Technecians ON TermProgs.Tech_ID = Technecians.ID) ON Entries.ID = TermProgs.Entry_ID WHERE (Term_ID = " & intTerm.ToString & ") AND ((Room1 = " & intRoom.ToString & ") OR (Room2 = " & intRoom.ToString & "))"
                    DAAC.Fill(DS, "tblAllProgs")
            End Select
            Array.Clear(intTimeFlag, 0, intTimeFlag.Length) ' clear data in intTimeFlag (r:6days, c:8times //begins from 0)
            For intTime As Integer = 0 To 7 ' for each time of day
                For intDay As Integer = 0 To 5
                    For intThisRoom As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                        If ((DS.Tables("tblAllProgs").Rows(intThisRoom).Item(intDay + 10) And (2 ^ intTime)) = (2 ^ intTime)) And (DS.Tables("tblAllProgs").Rows(intThisRoom).Item(16) = intRoom) Then
                            intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                            Grid5(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        End If
                        If (((DS.Tables("tblAllProgs").Rows(intThisRoom).Item(intDay + 18) And (2 ^ intTime)) = (2 ^ intTime))) And (DS.Tables("tblAllProgs").Rows(intThisRoom).Item(24) = intRoom) Then
                            intTimeFlag(intDay, intTime) = intTimeFlag(intDay, intTime) + 1
                            Grid5(intTime + 1, intDay).Value = intTimeFlag(intDay, intTime)
                        End If
                    Next intThisRoom
                Next intDay
            Next intTime

            'color conflicts in red
            For c As Integer = 0 To 7
                For r As Integer = 0 To 5
                    If Val(Grid5(c + 1, r).Value) > 1 Then Grid5(c + 1, r).Style.ForeColor = Color.Red
                Next r
            Next c

            HilightGrid5()
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub HilightGrid5()
        For intTime As Integer = 0 To 7
            For intday As Integer = 0 To 5
                Grid5(intTime + 1, intday).Style.BackColor = Color.White
                Select Case Roomx
                    Case 1 : If ((DS.Tables("tblTermProgs").Rows(intGridRow).Item(intday + 10) And (2 ^ intTime)) = (2 ^ intTime)) Then Grid5(intTime + 1, intday).Style.BackColor = Color.Khaki
                    Case 2 : If ((DS.Tables("tblTermProgs").Rows(intGridRow).Item(intday + 18) And (2 ^ intTime)) = (2 ^ intTime)) Then Grid5(intTime + 1, intday).Style.BackColor = Color.Khaki
                End Select
            Next intday
        Next intTime
        Grid5.CurrentCell = GridTime(0, 0)

    End Sub

    ' //Menu - GridRoom
    Private Sub MenuAddNewClass_Click(sender As Object, e As EventArgs) Handles MenuAddNewClass.Click
        If Userx = "USER Department" Then Exit Sub
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (افزودن/ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        Dim strClassName As String = Trim(InputBox("نام کلاس/ ازمايشگاه را وارد کنيد", "NexTerm", " کلاس/آز جديد "))
        If strClassName = "" Then Exit Sub
        Dim intCapa As Integer = 0
        Dim boolAV As Integer = False
        Dim boolActive As Boolean = True

        Try
            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    strSQL = "INSERT INTO Rooms (RoomName, RoomCapacity, VideoProjector, Active) VALUES (@roomname, @roomcapacity, @videoprojector, @active)"
                    Dim cmd As New SqlClient.SqlCommand(strSQL, CnnSS)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@roomname", strClassName.ToString)
                    cmd.Parameters.AddWithValue("@roomcapacity", intCapa)
                    cmd.Parameters.AddWithValue("@videoprojector", boolAV)
                    cmd.Parameters.AddWithValue("@active", boolActive)
                    Dim i As Integer = cmd.ExecuteNonQuery()
                Case "Access"
                    strSQL = "INSERT INTO Rooms (RoomName, RoomCapacity, VideoProjector, Active) VALUES (@roomname, @roomcapacity, @videoprojector, @active)"
                    Dim cmd As New OleDb.OleDbCommand(strSQL, CnnAC)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@roomname", strClassName.ToString)
                    cmd.Parameters.AddWithValue("@roomcapacity", intCapa)
                    cmd.Parameters.AddWithValue("@videoprojector", boolAV)
                    cmd.Parameters.AddWithValue("@active", boolActive)
                    Dim i As Integer = cmd.ExecuteNonQuery()
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        ShowClasses()
        WriteLOG(1)

    End Sub
    Private Sub Menu_Edit_Click(sender As Object, e As EventArgs) Handles Menu_Edit.Click
        If (UserAccessControls And (2 ^ 4)) = 0 Then MsgBox("قابليت (ويرايش) اين آيتم اکنون براي شما غير فعال است", vbInformation, "تنظيمات نکسترم") : Exit Sub
        If GridRoom.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridRoom.SelectedCells(0).RowIndex    'count from 0
        Dim c As Integer = GridRoom.SelectedCells(0).ColumnIndex 'count from 0
        If r < 0 Or c < 1 Or c > 4 Then Exit Sub
        Dim strValue As String = GridRoom(c, r).Value
        Try
            Select Case c
                Case 1 'RoomName
                    strValue = InputBox("نام کلاس/آز را وارد کنيد", "مشخصات کلاس", strValue)
                    If Trim(strValue) = "" Then Exit Sub
                    GridRoom(c, r).Value = strValue
                    WriteLOG(2)
                Case 2 'Capa
                    strValue = InputBox("ظرفيت را وارد کنيد", "مشخصات کلاس", strValue)
                    If Trim(strValue) = "" Then Exit Sub
                    GridRoom(c, r).Value = Val(strValue)
                    WriteLOG(3)
                Case 3 'AV
                    If GridRoom(c, r).Value = True Then GridRoom(c, r).Value = False Else GridRoom(c, r).Value = True
                    WriteLOG(4)
                Case 4 'Active
                    If GridRoom(c, r).Value = True Then GridRoom(c, r).Value = False Else GridRoom(c, r).Value = True
                    WriteLOG(5)
            End Select

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


    End Sub



    ' //Grid5
    Private Sub Grid5_CellClick() Handles Grid5.CellClick
        Try
            If GridRoom.CurrentRow.Index < 0 Then Exit Sub
            'strEntry = ? strTerm  = ?
            Dim r As Integer = 0
            Dim c As Integer = 0
            r = Val(Grid5.SelectedCells(0).RowIndex)    'count from 0
            c = Val(Grid5.SelectedCells(0).ColumnIndex) 'count from 0
            If r < 0 Or c < 1 Then Exit Sub


            ' // Show conflicts info
            Dim strTadakholMessage As String = ""
            For i As Integer = 0 To DS.Tables("tblAllProgs").Rows.Count - 1
                If ((DS.Tables("tblAllProgs").Rows(i).Item(r + 10) And (2 ^ (c - 1))) = (2 ^ (c - 1))) And (DS.Tables("tblAllProgs").Rows(i).Item(16) = intRoom) Then
                    strTadakholMessage = strTadakholMessage & " درس " & DS.Tables("tblAllProgs").Rows(i).Item(3) & "    استاد: " & DS.Tables("tblAllProgs").Rows(i).Item(7) & vbCrLf & " ورودي " & DS.Tables("tblAllProgs").Rows(i).Item(29) & vbCrLf & vbCrLf
                End If
                If ((DS.Tables("tblAllProgs").Rows(i).Item(r + 18) And (2 ^ (c - 1))) = (2 ^ (c - 1))) And (DS.Tables("tblAllProgs").Rows(i).Item(24) = intRoom) Then
                    strTadakholMessage = strTadakholMessage & " درس " & DS.Tables("tblAllProgs").Rows(i).Item(3) & "    استاد: " & DS.Tables("tblAllProgs").Rows(i).Item(7) & vbCrLf & " ورودي " & DS.Tables("tblAllProgs").Rows(i).Item(29) & vbCrLf & vbCrLf
                End If
            Next
            lblInfo.Text = strTadakholMessage
            Grid5.Item(0, r).Selected = True


            ' // hilight
            If Grid5(c, r).Value.ToString <> "" Then
                Exit Sub
            Else
                If (UserAccessControls And (2 ^ 4)) = 0 Then Exit Sub
                With Grid5.Item(c, r).Style
                    If .BackColor = Color.Khaki Then .BackColor = Color.White Else .BackColor = Color.Khaki
                End With
                Grid5.Item(0, r).Selected = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Grid5_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Grid5.CellDoubleClick
        Dim r As Integer = 0
        Dim c As Integer = 0
        r = Val(Grid5.CurrentCell.RowIndex)    'count from 0
        c = Val(Grid5.CurrentCell.ColumnIndex) 'count from 0
        If r < 0 Or c < 1 Then Exit Sub

        ' // hilight
        If (UserAccessControls And (2 ^ 4)) = 0 Then Exit Sub
        With Grid5.Item(c, r).Style
            If .BackColor = Color.Khaki Then .BackColor = Color.White Else .BackColor = Color.Khaki
        End With
        Grid5.Item(0, r).Selected = True

    End Sub

    ' //Menu - Grid5
    Private Sub MenuOK_Click(sender As Object, e As EventArgs) Handles MenuOK.Click
        If GridRoom.RowCount < 1 Then Exit Sub
        Dim r As Integer = GridRoom.CurrentRow.Index
        strRoom = DS.Tables("tblRooms").Rows(r).Item(1)
        intRoom = DS.Tables("tblRooms").Rows(r).Item(0)

        SetTiming()
        Me.Dispose()

    End Sub
    Private Sub MenuCancel_Click(sender As Object, e As EventArgs) Handles MenuCancel.Click
        strRoom = ""
        intRoom = 0
        Me.Dispose()

    End Sub
    Private Sub SetTiming()
        Dim intDay, intTime As Integer
        Select Case Roomx
            Case 1 ' class1
                For intDay = 0 To 5
                    intClass1DayData(intDay) = 0 ' reset and then refill
                    For intTime = 1 To 8
                        If Grid5(intTime, intDay).Style.BackColor = Color.Khaki Then intClass1DayData(intDay) = (intClass1DayData(intDay) Or (2 ^ (intTime - 1)))
                    Next intTime
                    DS.Tables("tblTermProgs").Rows(intGridRow).Item(intDay + 10) = Val(intClass1DayData(intDay))
                Next intDay
            Case 2 ' class2
                For intDay = 0 To 5
                    intClass2DayData(intDay) = 0 ' reset and then refill
                    For intTime = 1 To 8
                        If Grid5(intTime, intDay).Style.BackColor = Color.Khaki Then intClass2DayData(intDay) = (intClass2DayData(intDay) Or (2 ^ (intTime - 1)))
                    Next intTime
                    DS.Tables("tblTermProgs").Rows(intGridRow).Item(intDay + 18) = Val(intClass2DayData(intDay))
                Next intDay
        End Select

    End Sub



    ' //WriteLog
    Private Sub WriteLOG(intActivity As Integer)
        If boolLog = True Then
            'WRITE-LOG
            'Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
            Dim timeZoneInfo As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Iran Standard Time")
            Dim strDateTime As String = TimeZoneInfo.ConvertTime(DateTime.Now, timeZoneInfo).ToString("yyyy.MM.dd - HH:mm:ss")

            Dim intUserID As Integer = intUser
            Dim strNickName As String = UserNickName
            Dim strClientName As String = LCase(Environment.MachineName)
            Dim strFrontEnd As String = LCase(strBuildInfo)
            Dim strLog As String = ""
            Select Case intActivity
                Case 1 : strLog = "clss+"
                Case 2 : strLog = "clss?"
                Case 3 : strLog = "clss.capa?"
                Case 4 : strLog = "clss.av?"
                Case 5 : strLog = "clss.actv?"
            End Select

            Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
                Case "SqlServer"
                    Try
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
                    Catch ex As Exception
                        MsgBox(ex.ToString) 'Do Nothing!
                    End Try
                Case "Access"
                    Try
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
                    Catch ex As Exception
                        MsgBox(ex.ToString) 'Do Nothing!
                    End Try
            End Select

        End If

    End Sub

End Class