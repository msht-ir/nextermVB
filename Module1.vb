Imports System.Data.OleDb
Imports System.Data.SqlClient

Module Module1
    Public DatabaseType As String = ""
    Public Server2Connect As String = ""

    Public CnnAC As New OleDb.OleDbConnection
    Public CnnSS As New SqlClient.SqlConnection

    Public CmdAC As New OleDb.OleDbCommand
    Public CmdSS As New SqlClient.SqlCommand

    Public DAAC As New OleDbDataAdapter
    Public DASS As New SqlDataAdapter

    Public DS As New DataSet
    Public tblDepartments, tblBioProgs, tblCourses, tblEntries, tblRooms As New DataTable
    Public tblStaff, tblTechs, tblTerms, tblTermProgs As New DataTable
    Public tblTemplates, tblTemplateData, tblSettings As New DataTable
    Public tblTermExams, tblLogs, tblMsgs As New DataTable

    Public tblAllProgs As New DataTable 'For frmTadakhols
    Public tblThisCourseTime As New DataTable

    Public Retval1, Retval2, Retval3, Retval4 As Integer
    Public strFacultyPass, strDepartmentPass As String
    Public Userx As String          'USERFaculty | USERDepartment 
    Public intUser As Integer       'ID of Department   (as intUser)
    Public strUser As String        'Name of Department (as strUser)
    Public UserNickName As String   'Name of the User
    Public strBuildInfo As String   'as Build 000.00.00
    Public UserAccessControls As Integer  'acc1-acc5 (user access controls)
    Public strCaption As String
    Public strSQL As String

    Public intDept, intBioProg, intEntry, intCourse, intTerm, intRoom, intStaff, intTech, intTemp As Long
    Public strDept, strBioProg, strEntry, strCourse, strTerm, strRoom, strStaff, strTech, strTemp As String
    Public strExamDateTime As String
    Public intCourseNumber As Long
    Public intYearEntered As Integer
    Public intGridRow As Integer ' used in frm.Choose_Class, showing info of occupied class-times: need row-index of Grid4 
    Public Roomx As Integer ' used in frm.Choose_Class: prog is for Room1 or Room2?
    Public intDefaultTermID As Integer 'a default term id : to show an entry's prog for this term by default (if not zero)

    Public strFilename As String        ' // path of text file for backend.path, user.id, pass strings
    Public strDbBackEnd As String = ""  ' // (read from cnn file) Path of Backend file on local or server 
    Public BackEndPass As String = "NexTermSiliconPower" ' //encryption password of ACCDB Backend file
    Public strserveruid As String = ""
    Public strserverpwd As String = ""
    Public strReportBG As String = "bg1.png" ' //background filename for html reports

    Public intClass1DayData(5) As Integer '5 days for Class 1
    Public intClass2DayData(5) As Integer '5 days for Class 2
    Public strTime() As String = {"08:30", "09:30", "10:30", "11:30", "13:30", "14:30", "15:30", "16:30"}
    Public strDay() As String = {"شنبه", "يکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه"}
    Public intTimeFlag(5, 7) As Integer ' (r:6days, c:8times //begins from 0)
    Public boolLog As Boolean 'Log User Activity (YES/NO) in Setting
    Public strReportsFooter As String = "NexTerm Desktop App [ www.msht.ir ], Faculty of Science, SKU. Developer: Dr. Majid Sharifi-Tehrani (1400-1401)"


    Sub Main()
        frmAbout.ShowDialog()
lbl_SelectDB:
        frmCNN.ShowDialog()
        Try
            Select Case Server2Connect
                '--------------------------------------------------------- Server on Host
                Case "NexTerm DB-1"
                    CnnSS = New SqlClient.SqlConnection("Server=setareh.r1host.com\sqlserver2019; Initial Catalog=mshtir_NexTerm; User ID=mshtir_db; Password=nExTeRm_1401_uSr6x;")
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                Case "NexTerm DB-2"
                    CnnSS = New SqlClient.SqlConnection("Server=setareh.r1host.com\sqlserver2019; Initial Catalog=mshtir_NX2; User ID=mshtir_nx2user; Password=SiliconPower_740;")
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                Case "NexTerm DB-3"
                    CnnSS = New SqlClient.SqlConnection("Server=setareh.r1host.com\sqlserver2019; Initial Catalog=mshtir_NX3; User ID=mshtir_nx3user; Password=nExTeRm_1401_uSr3;")
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                    '--------------------------------------------------------- LOCAL Server
                Case "Local Server 1" ' sql server on ThisPC NX1
                    CnnSS = New SqlClient.SqlConnection(strDbBackEnd)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                Case "Local Server 2" ' sql server on ThisPC NX2
                    CnnSS = New SqlClient.SqlConnection(strDbBackEnd)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                Case "Local Server 3" ' sql server on ThisPC NX3
                    CnnSS = New SqlClient.SqlConnection(strDbBackEnd)
                    CnnSS.Open()
                    DatabaseType = "SqlServer"
                    '--------------------------------------------------------- NAS
                Case "SKU.NAS Server DB-1:msht" ' SKU.NAS (msht)
                    NexTerm.connectnetworkdrive.ConnectToNetwork.PinvokeWindowsNetworking.connectToRemote("\\185.105.121.99", $"sharifi-m@sku.ac.ir", "1289463557")
                    strDbBackEnd = "\\185.105.121.99\sharifi-m@sku.ac.ir\NexTerm.accdb"
                    CnnAC = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDbBackEnd & ";Jet OLEDB:Database Password=" & BackEndPass & ";")
                    CnnAC.Open()
                    DatabaseType = "Access"
                Case "SKU.NAS Server DB-2" ' SKU.NAS +uid/pwd
                    NexTerm.connectnetworkdrive.ConnectToNetwork.PinvokeWindowsNetworking.connectToRemote("\\185.105.121.99", strserveruid, strserverpwd)
                    CnnAC = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDbBackEnd & ";Jet OLEDB:Database Password=" & BackEndPass & ";")
                    CnnAC.Open()
                    DatabaseType = "Access"
                    '--------------------------------------------------------- ACCDB
                Case Else ' Local DB
                    strCaption = "Connected to Local ACCDB ; " & strDbBackEnd
                    CnnAC = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strDbBackEnd & ";Jet OLEDB:Database Password=" & BackEndPass & ";")
                    CnnAC.Open()
                    DatabaseType = "Access"
            End Select
            strCaption = "Connected to " & Server2Connect

        Catch ex As Exception
            Dim myansw As DialogResult = MsgBox("خطا: نکسترم به ديتابيس زير متصل نشد" & vbCrLf & strDbBackEnd & vbCrLf & vbCrLf & "جزييات خطا نشان داده شود؟", vbYesNo + vbDefaultButton2, "خطا در اتصال به ديتابيس")
            If myansw = vbYes Then MsgBox(ex.ToString)
            GoTo lbl_SelectDB  'Application.Exit() : End
        End Try

        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Columns.Add() : tblThisCourseTime.Columns.Add()
        tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1") : tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1")
        tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1") : tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1")
        tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1") : tblThisCourseTime.Rows.Add("1", "1", "1", "1", "1", "1", "1", "1")

        DS.Tables.Add("tblDepartments")
        DS.Tables.Add("tblBioProgs")
        DS.Tables.Add("tblCourses")
        DS.Tables.Add("tblEntries")
        DS.Tables.Add("tblRooms")
        DS.Tables.Add("tblStaff")
        DS.Tables.Add("tblTechs")
        DS.Tables.Add("tblTerms")
        DS.Tables.Add("tblTermProgs")
        DS.Tables.Add("tblTemplates")
        DS.Tables.Add("tblTemplateData")
        DS.Tables.Add("tblSettings")
        DS.Tables.Add("tblAllProgs")
        DS.Tables.Add("tblTermExams")
        DS.Tables.Add("tblMsgs")

        Select Case DatabaseType ' ----  SqlServer ---- / ---- Access ----
            Case "SqlServer"
                DASS = New SqlClient.SqlDataAdapter("Select ID, DepartmentName As DEPT, DepartmentActive, Notes, DepartmentPass, acc1, acc2, acc3, acc4, acc5 FROM Departments ORDER BY DepartmentName", CnnSS)
                DASS.Fill(DS, "tblDepartments") ' tbl 1: Depts
                DASS.SelectCommand.CommandText = "SELECT ID FROM BioProgs"
                DASS.Fill(DS, "tblBioProgs") ' tbl 2: BioProgs
                DASS.SelectCommand.CommandText = "Select ID FROM Courses"
                DASS.Fill(DS, "tblCourses") ' tbl 3: Courses
                DASS.SelectCommand.CommandText = "Select ID FROM Staff"
                DASS.Fill(DS, "tblStaff") ' tbl 4: Staff
                DASS.SelectCommand.CommandText = "Select ID FROM Technecians"
                DASS.Fill(DS, "tblTechs") ' tbl 5: Techs
                DASS.SelectCommand.CommandText = "SELECT ID, RoomName AS Class FROM Rooms ORDER BY RoomName"
                DASS.Fill(DS, "tblRooms") ' tbl 6: Rooms
                DASS.SelectCommand.CommandText = "SELECT ID As EntID FROM Entries"
                DASS.Fill(DS, "tblEntries") ' tbl 7: Entries
                DASS.SelectCommand.CommandText = "Select ID FROM Terms"
                DASS.Fill(DS, "tblTerms") ' tbl 8: Terms
                DASS.SelectCommand.CommandText = "Select ID FROM Templates"
                DASS.Fill(DS, "tblTemplates") ' tbl 9: Templates
                DASS.SelectCommand.CommandText = "Select ID FROM TemplateData"
                DASS.Fill(DS, "tblTemplateData") ' tbl 10: TemplateData
                DASS.SelectCommand.CommandText = "SELECT ID From TermProgs"
                DASS.Fill(DS, "tblTermProgs") ' tbl 11: TermProgs
                DS.Tables("tblSettings").Clear()
                DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Log User%' ORDER BY iHerbsConstant" ' search: (Log User Activity)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                Try '//boolLog
                    If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then boolLog = True Else boolLog = False
                Catch ex As Exception
                    boolLog = False
                End Try
                DS.Tables("tblSettings").Clear()
                DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Report background%' ORDER BY iHerbsConstant" ' search: (bg)
                DASS.Fill(DS, "tblSettings") ' tbl 12: Settings
                Try '//strReportBG
                    strReportBG = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    strReportBG = "bg1.png"
                End Try
                DS.Tables("tblSettings").Clear()
                DASS.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin Password%' ORDER BY iHerbsConstant" ' search: (Password for Admin)
                DASS.Fill(DS, "tblSettings")
                Try '//strFacultyPass
                    strFacultyPass = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    Try
                        MsgBox("خطا: ديتابيس خراب است")
                        CnnSS.Close() : CnnSS.Dispose() : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Application.Exit() : End
                    Catch
                        MsgBox("Error in Exit module ....")
                    End Try
                End Try
                DASS.SelectCommand.CommandText = "SELECT ID From TermProgs"
                DASS.Fill(DS, "tblAllProgs") ' tbl 13: AllProgs
                DASS.SelectCommand.CommandText = "SELECT ID From TermProgs"
                DASS.Fill(DS, "tblTermExams") ' tbl 14: Exams
                DASS.SelectCommand.CommandText = "SELECT DateTimex From xLog"
                DASS.Fill(DS, "tblLogs") ' tbl Logs
                DASS.SelectCommand.CommandText = "SELECT ID FROM msgs"
                DASS.Fill(DS, "tblMsgs") ' tbl notes (messages)

            '--------- access --------- access --------- access --------- access --------- access --------- access --------- access --------- access ---------
            Case "Access"
                DAAC = New OleDb.OleDbDataAdapter("Select ID, DepartmentName As DEPT, DepartmentActive, Notes, DepartmentPass, acc1, acc2, acc3, acc4, acc5 FROM Departments ORDER BY DepartmentName", CnnAC)
                DAAC.Fill(DS, "tblDepartments") ' tbl 1: Depts
                DAAC.SelectCommand.CommandText = "SELECT ID FROM BioProgs"
                DAAC.Fill(DS, "tblBioProgs") ' tbl 2: BioProgs
                DAAC.SelectCommand.CommandText = "Select ID FROM Courses"
                DAAC.Fill(DS, "tblCourses") ' tbl 3: Courses
                DAAC.SelectCommand.CommandText = "Select ID FROM Staff"
                DAAC.Fill(DS, "tblStaff") ' tbl 4: Staff
                DAAC.SelectCommand.CommandText = "Select ID FROM Technecians"
                DAAC.Fill(DS, "tblTechs") ' tbl 5: Techs
                DAAC.SelectCommand.CommandText = "SELECT ID, RoomName AS Class FROM Rooms ORDER BY RoomName"
                DAAC.Fill(DS, "tblRooms") ' tbl 6: Rooms
                DAAC.SelectCommand.CommandText = "SELECT ID As EntID FROM Entries"
                DAAC.Fill(DS, "tblEntries") ' tbl 7: Entries
                DAAC.SelectCommand.CommandText = "Select ID FROM Terms"
                DAAC.Fill(DS, "tblTerms") ' tbl 8: Terms
                DAAC.SelectCommand.CommandText = "Select ID FROM Templates"
                DAAC.Fill(DS, "tblTemplates") ' tbl 9: Templates
                DAAC.SelectCommand.CommandText = "Select ID FROM TemplateData"
                DAAC.Fill(DS, "tblTemplateData") ' tbl 10: TemplateData
                DAAC.SelectCommand.CommandText = "SELECT ID From TermProgs"
                DAAC.Fill(DS, "tblTermProgs") ' tbl 11: TermProgs
                DS.Tables("tblSettings").Clear()
                DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Log User%' ORDER BY iHerbsConstant" ' search: (Log User Activity)
                DAAC.Fill(DS, "tblSettings") ' tbl 12: Settings
                Try
                    If UCase(DS.Tables("tblSettings").Rows(0).Item(2)) = "YES" Then boolLog = True Else boolLog = False
                Catch ex As Exception
                    boolLog = False
                End Try
                DS.Tables("tblSettings").Clear()
                DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Report background%' ORDER BY iHerbsConstant" ' search: (bg)
                DAAC.Fill(DS, "tblSettings") ' tbl 12: Settings
                Try
                    strReportBG = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    strReportBG = "bg1.png"
                End Try
                DS.Tables("tblSettings").Clear()
                DAAC.SelectCommand.CommandText = "SELECT ID, iHerbsConstant, iHerbsvalue From Settings WHERE iHerbsConstant LIKE 'Admin Password%' ORDER BY iHerbsConstant" ' search: (Password for Admin)
                DAAC.Fill(DS, "tblSettings")
                Try
                    strFacultyPass = DS.Tables("tblSettings").Rows(0).Item(2)
                Catch ex As Exception
                    Try
                        MsgBox("خطا: ديتابيس خراب است")
                        CnnAC.Close() : CnnAC.Dispose() : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Application.Exit() : End
                    Catch
                        MsgBox("Error in Exit module ....")
                    End Try
                End Try
                DAAC.SelectCommand.CommandText = "SELECT ID From TermProgs"
                DAAC.Fill(DS, "tblAllProgs") ' tbl 13: AllProgs
                DAAC.SelectCommand.CommandText = "SELECT ID From TermProgs"
                DAAC.Fill(DS, "tblTermExams") ' tbl 14: Exams
                DAAC.SelectCommand.CommandText = "SELECT DateTimex From xLog"
                DAAC.Fill(DS, "tblLogs") ' tbl Logs
                DAAC.SelectCommand.CommandText = "SELECT ID FROM msgs"
                DAAC.Fill(DS, "tblMsgs") ' tbl notes (messages)
        End Select
        '--------- end select --------- end select --------- end select --------- end select --------- end select --------- end select --------- end select


        frmLogIn.ShowDialog() ' // LOGIN:set Userx
        If Userx = "quit" Then
            Try
                CnnSS.Close() : CnnSS.Dispose() : CnnSS = Nothing : frmLogIn.Dispose() : ChooseStaff.Dispose() : ChooseTech.Dispose() : Application.Exit() : End
            Catch
                MsgBox("خطا در ماژول خروج", vbOKOnly, "نکسترم")
                End
            End Try
        Else
            If boolLog = True Then ' -----------------------WRITE-LOG
                Try
                    If Userx = "USER Faculty" Then intUser = 0
                    Dim strDateTime As String = System.DateTime.Now.ToString("yyyy.MM.dd - HH:mm:ss")
                    Dim intUserID As Integer = intUser
                    Dim strNickName As String = UserNickName
                    Dim strClientName As String = LCase(Environment.MachineName)
                    Dim strFrontEnd As String = LCase(strBuildInfo)
                    Dim strLog As String = "login"
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
            frmTermProgs.ShowDialog()
        End If
    End Sub

End Module
