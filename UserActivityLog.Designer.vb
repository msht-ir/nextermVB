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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_B = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_cboSort = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_ReportUserActivity = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ClearUserActivity = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_A = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_cboTerm = New System.Windows.Forms.ToolStripComboBox()
        Me.Menu_cboLevel = New System.Windows.Forms.ToolStripComboBox()
        Me.Menu_cboCourseType = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_ReportCourses = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_B, Me.ToolStripMenuItem2, Me.Menu_A, Me.ToolStripMenuItem1, Me.Menu_Exit})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 104)
        '
        'Menu_B
        '
        Me.Menu_B.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_cboSort, Me.ToolStripMenuItem4, Me.Menu_ReportUserActivity, Me.Menu_ClearUserActivity})
        Me.Menu_B.Name = "Menu_B"
        Me.Menu_B.Size = New System.Drawing.Size(169, 22)
        Me.Menu_B.Text = "فعاليت کاربران"
        '
        'Menu_cboSort
        '
        Me.Menu_cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Menu_cboSort.Items.AddRange(New Object() {"به ترتيب تاريخ - زمان", "به ترتيب گروه آموزشي", "به ترتيب سرويس گيرنده", "به ترتيب نام مستعار"})
        Me.Menu_cboSort.Name = "Menu_cboSort"
        Me.Menu_cboSort.Size = New System.Drawing.Size(160, 23)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(217, 6)
        '
        'Menu_ReportUserActivity
        '
        Me.Menu_ReportUserActivity.Name = "Menu_ReportUserActivity"
        Me.Menu_ReportUserActivity.Size = New System.Drawing.Size(220, 22)
        Me.Menu_ReportUserActivity.Text = "گزارش فعاليت کاربران"
        '
        'Menu_ClearUserActivity
        '
        Me.Menu_ClearUserActivity.Name = "Menu_ClearUserActivity"
        Me.Menu_ClearUserActivity.Size = New System.Drawing.Size(220, 22)
        Me.Menu_ClearUserActivity.Text = "پاک شود"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(166, 6)
        '
        'Menu_A
        '
        Me.Menu_A.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_cboTerm, Me.Menu_cboLevel, Me.Menu_cboCourseType, Me.ToolStripMenuItem3, Me.Menu_ReportCourses})
        Me.Menu_A.Name = "Menu_A"
        Me.Menu_A.Size = New System.Drawing.Size(169, 22)
        Me.Menu_A.Text = "گزارش ارايه درس ها"
        '
        'Menu_cboTerm
        '
        Me.Menu_cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Menu_cboTerm.Name = "Menu_cboTerm"
        Me.Menu_cboTerm.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Menu_cboTerm.Size = New System.Drawing.Size(80, 23)
        '
        'Menu_cboLevel
        '
        Me.Menu_cboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Menu_cboLevel.Items.AddRange(New Object() {"فوق ديپلم", "کارشناسي", "کارشناسي ارشد", "دکتري عمومي", "دکتري تخصصي"})
        Me.Menu_cboLevel.Name = "Menu_cboLevel"
        Me.Menu_cboLevel.Size = New System.Drawing.Size(160, 23)
        '
        'Menu_cboCourseType
        '
        Me.Menu_cboCourseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Menu_cboCourseType.Items.AddRange(New Object() {"دروس عملي", "دروس تئوري"})
        Me.Menu_cboCourseType.Name = "Menu_cboCourseType"
        Me.Menu_cboCourseType.Size = New System.Drawing.Size(160, 23)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(234, 6)
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
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(166, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(169, 22)
        Me.Menu_Exit.Text = "خروج"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioButton1.Location = New System.Drawing.Point(39, 43)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton1.Size = New System.Drawing.Size(49, 19)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "هردو"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioButton2.Location = New System.Drawing.Point(107, 43)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton2.Size = New System.Drawing.Size(66, 19)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "دانشکده"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioButton3.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadioButton3.Location = New System.Drawing.Point(495, 43)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadioButton3.Size = New System.Drawing.Size(47, 19)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "گروه"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(199, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(240, 25)
        Me.ComboBox1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Navy
        Me.Panel1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(629, 124)
        Me.Panel1.TabIndex = 7
        '
        'UserActivityLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(629, 144)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UserActivityLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گزارش"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_B As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents RadioButton10 As RadioButton
    Friend WithEvents RadioButton11 As RadioButton
    Friend WithEvents cboSort As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ContextMenuSEARCH As ContextMenuStrip
    Friend WithEvents Menu_ReportCourses As ToolStripMenuItem
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Menu_UserActivicy_Date As ToolStripMenuItem
    Friend WithEvents Menu_UserActivicy_Dept As ToolStripMenuItem
    Friend WithEvents Menu_UserActivicy_Client As ToolStripMenuItem
    Friend WithEvents Menu_UserActivicy_Nick As ToolStripMenuItem
    Friend WithEvents Menu_A As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents cboTerm As ComboBox
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents تهيهگزارشفعاليتکاربرانToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Menu_Cbo As ToolStripComboBox
    Friend WithEvents Menu_UserActivityReportSorted As ToolStripMenuItem
    Friend WithEvents Menu_ReportUserActivity As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox2 As ToolStripComboBox
    Friend WithEvents Menu_cboCourseType As ToolStripComboBox
    Friend WithEvents Menu_cboLevel As ToolStripComboBox
    Friend WithEvents Menu_cboTerm As ToolStripComboBox
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents Menu_ClearUserActivity As ToolStripMenuItem
    Friend WithEvents Menu_cboSort As ToolStripComboBox
End Class
