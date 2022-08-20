<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserActivityLog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStripA = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_ReportUserActivity = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ReportCourses = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboDepts = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxFaculty = New System.Windows.Forms.CheckBox()
        Me.CheckBoxDepts = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCoursetype = New System.Windows.Forms.ComboBox()
        Me.cboProglevel = New System.Windows.Forms.ComboBox()
        Me.cboTerms = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Radio5 = New System.Windows.Forms.RadioButton()
        Me.Radio4 = New System.Windows.Forms.RadioButton()
        Me.Radio1 = New System.Windows.Forms.RadioButton()
        Me.Radio3 = New System.Windows.Forms.RadioButton()
        Me.Radio2 = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ContextMenuStripA.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripA
        '
        Me.ContextMenuStripA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ContextMenuStripA.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_ReportUserActivity, Me.Menu_ReportCourses, Me.ToolStripMenuItem1, Me.Menu_Exit})
        Me.ContextMenuStripA.Name = "ContextMenuStrip1"
        Me.ContextMenuStripA.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStripA.Size = New System.Drawing.Size(238, 76)
        '
        'Menu_ReportUserActivity
        '
        Me.Menu_ReportUserActivity.Name = "Menu_ReportUserActivity"
        Me.Menu_ReportUserActivity.Size = New System.Drawing.Size(237, 22)
        Me.Menu_ReportUserActivity.Text = "فعاليت کاربران"
        '
        'Menu_ReportCourses
        '
        Me.Menu_ReportCourses.Name = "Menu_ReportCourses"
        Me.Menu_ReportCourses.Size = New System.Drawing.Size(237, 22)
        Me.Menu_ReportCourses.Text = "گزارش درس هاي برنامه ريزي شده"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(234, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(237, 22)
        Me.Menu_Exit.Text = "خروج"
        '
        'cboDepts
        '
        Me.cboDepts.BackColor = System.Drawing.SystemColors.Window
        Me.cboDepts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepts.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboDepts.FormattingEnabled = True
        Me.cboDepts.Location = New System.Drawing.Point(146, 7)
        Me.cboDepts.Name = "cboDepts"
        Me.cboDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cboDepts.Size = New System.Drawing.Size(240, 25)
        Me.cboDepts.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel1.Controls.Add(Me.CheckBoxFaculty)
        Me.Panel1.Controls.Add(Me.CheckBoxDepts)
        Me.Panel1.Controls.Add(Me.cboDepts)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(533, 62)
        Me.Panel1.TabIndex = 7
        '
        'CheckBoxFaculty
        '
        Me.CheckBoxFaculty.AutoSize = True
        Me.CheckBoxFaculty.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckBoxFaculty.Location = New System.Drawing.Point(405, 35)
        Me.CheckBoxFaculty.Name = "CheckBoxFaculty"
        Me.CheckBoxFaculty.Size = New System.Drawing.Size(67, 19)
        Me.CheckBoxFaculty.TabIndex = 6
        Me.CheckBoxFaculty.Text = "دانشکده"
        Me.CheckBoxFaculty.UseVisualStyleBackColor = True
        '
        'CheckBoxDepts
        '
        Me.CheckBoxDepts.AutoSize = True
        Me.CheckBoxDepts.Checked = True
        Me.CheckBoxDepts.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxDepts.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CheckBoxDepts.Location = New System.Drawing.Point(405, 11)
        Me.CheckBoxDepts.Name = "CheckBoxDepts"
        Me.CheckBoxDepts.Size = New System.Drawing.Size(48, 19)
        Me.CheckBoxDepts.TabIndex = 5
        Me.CheckBoxDepts.Text = "گروه"
        Me.CheckBoxDepts.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel2.ContextMenuStrip = Me.ContextMenuStripA
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cboCoursetype)
        Me.Panel2.Controls.Add(Me.cboProglevel)
        Me.Panel2.Controls.Add(Me.cboTerms)
        Me.Panel2.Location = New System.Drawing.Point(3, 79)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(320, 185)
        Me.Panel2.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "درس هاي برنامه ريزي شده"
        '
        'cboCoursetype
        '
        Me.cboCoursetype.BackColor = System.Drawing.SystemColors.Window
        Me.cboCoursetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoursetype.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboCoursetype.FormattingEnabled = True
        Me.cboCoursetype.Items.AddRange(New Object() {"دروس عملي", "دروس تئوري"})
        Me.cboCoursetype.Location = New System.Drawing.Point(43, 135)
        Me.cboCoursetype.Name = "cboCoursetype"
        Me.cboCoursetype.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cboCoursetype.Size = New System.Drawing.Size(240, 25)
        Me.cboCoursetype.TabIndex = 6
        '
        'cboProglevel
        '
        Me.cboProglevel.BackColor = System.Drawing.SystemColors.Window
        Me.cboProglevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProglevel.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboProglevel.FormattingEnabled = True
        Me.cboProglevel.Items.AddRange(New Object() {"فوق ديپلم", "کارشناسي", "کارشناسي ارشد", "دکتري عمومي", "دکتري تخصصي"})
        Me.cboProglevel.Location = New System.Drawing.Point(43, 87)
        Me.cboProglevel.Name = "cboProglevel"
        Me.cboProglevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cboProglevel.Size = New System.Drawing.Size(240, 25)
        Me.cboProglevel.TabIndex = 5
        '
        'cboTerms
        '
        Me.cboTerms.BackColor = System.Drawing.SystemColors.Window
        Me.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerms.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboTerms.FormattingEnabled = True
        Me.cboTerms.Location = New System.Drawing.Point(188, 45)
        Me.cboTerms.Name = "cboTerms"
        Me.cboTerms.Size = New System.Drawing.Size(95, 25)
        Me.cboTerms.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.ContextMenuStrip = Me.ContextMenuStripA
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Radio5)
        Me.Panel3.Controls.Add(Me.Radio4)
        Me.Panel3.Controls.Add(Me.Radio1)
        Me.Panel3.Controls.Add(Me.Radio3)
        Me.Panel3.Controls.Add(Me.Radio2)
        Me.Panel3.Location = New System.Drawing.Point(329, 79)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel3.Size = New System.Drawing.Size(205, 185)
        Me.Panel3.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "فعاليت کاربران - به ترتيب"
        '
        'Radio5
        '
        Me.Radio5.AutoSize = True
        Me.Radio5.BackColor = System.Drawing.Color.Transparent
        Me.Radio5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Radio5.ForeColor = System.Drawing.Color.IndianRed
        Me.Radio5.Location = New System.Drawing.Point(98, 147)
        Me.Radio5.Name = "Radio5"
        Me.Radio5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Radio5.Size = New System.Drawing.Size(76, 21)
        Me.Radio5.TabIndex = 4
        Me.Radio5.Text = "پاک کردن"
        Me.Radio5.UseVisualStyleBackColor = False
        '
        'Radio4
        '
        Me.Radio4.AutoSize = True
        Me.Radio4.BackColor = System.Drawing.Color.Transparent
        Me.Radio4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Radio4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Radio4.Location = New System.Drawing.Point(90, 120)
        Me.Radio4.Name = "Radio4"
        Me.Radio4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Radio4.Size = New System.Drawing.Size(84, 21)
        Me.Radio4.TabIndex = 5
        Me.Radio4.Text = "نام مستعار"
        Me.Radio4.UseVisualStyleBackColor = False
        '
        'Radio1
        '
        Me.Radio1.AutoSize = True
        Me.Radio1.BackColor = System.Drawing.Color.Transparent
        Me.Radio1.Checked = True
        Me.Radio1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Radio1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Radio1.Location = New System.Drawing.Point(86, 36)
        Me.Radio1.Name = "Radio1"
        Me.Radio1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Radio1.Size = New System.Drawing.Size(88, 21)
        Me.Radio1.TabIndex = 3
        Me.Radio1.TabStop = True
        Me.Radio1.Text = "تاريخ - زمان"
        Me.Radio1.UseVisualStyleBackColor = False
        '
        'Radio3
        '
        Me.Radio3.AutoSize = True
        Me.Radio3.BackColor = System.Drawing.Color.Transparent
        Me.Radio3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Radio3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Radio3.Location = New System.Drawing.Point(70, 93)
        Me.Radio3.Name = "Radio3"
        Me.Radio3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Radio3.Size = New System.Drawing.Size(104, 21)
        Me.Radio3.TabIndex = 1
        Me.Radio3.Text = "سرويس گيرنده"
        Me.Radio3.UseVisualStyleBackColor = False
        '
        'Radio2
        '
        Me.Radio2.AutoSize = True
        Me.Radio2.BackColor = System.Drawing.Color.Transparent
        Me.Radio2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Radio2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Radio2.Location = New System.Drawing.Point(78, 63)
        Me.Radio2.Name = "Radio2"
        Me.Radio2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Radio2.Size = New System.Drawing.Size(96, 21)
        Me.Radio2.TabIndex = 2
        Me.Radio2.Text = "گروه آموزشي"
        Me.Radio2.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel4.ContextMenuStrip = Me.ContextMenuStripA
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(539, 287)
        Me.Panel4.TabIndex = 8
        '
        'UserActivityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Goldenrod
        Me.ClientSize = New System.Drawing.Size(539, 287)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserActivityLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش"
        Me.ContextMenuStripA.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStripCOURSES As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents cboDepts As ComboBox
    Friend WithEvents RadioButton10 As RadioButton
    Friend WithEvents RadioButton11 As RadioButton
    Friend WithEvents cboSort As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cboTerms As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ContextMenuSEARCH As ContextMenuStrip
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Menu_UserActivicy_Date As ToolStripMenuItem
    Friend WithEvents Menu_UserActivicy_Dept As ToolStripMenuItem
    Friend WithEvents Menu_UserActivicy_Client As ToolStripMenuItem
    Friend WithEvents Menu_UserActivicy_Nick As ToolStripMenuItem
    Friend WithEvents Menu_ReportCourses As ToolStripMenuItem
    Friend WithEvents cboTerm As ComboBox
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents تهيهگزارشفعاليتکاربرانToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Menu_Cbo As ToolStripComboBox
    Friend WithEvents Menu_UserActivityReportSorted As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox2 As ToolStripComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents RadioButton8 As RadioButton
    Friend WithEvents RadioButton9 As RadioButton
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cboCoursetype As ComboBox
    Friend WithEvents cboProglevel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuStrip_USERS As ContextMenuStrip
    Friend WithEvents فعاليتکاربرانToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents خروجToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStripA As ContextMenuStrip
    Friend WithEvents Menu_ReportUserActivity As ToolStripMenuItem
    Friend WithEvents Radio5 As RadioButton
    Friend WithEvents Radio4 As RadioButton
    Friend WithEvents Radio1 As RadioButton
    Friend WithEvents Radio3 As RadioButton
    Friend WithEvents Radio2 As RadioButton
    Friend WithEvents CheckBoxFaculty As CheckBox
    Friend WithEvents CheckBoxDepts As CheckBox
End Class
