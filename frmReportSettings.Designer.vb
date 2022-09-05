<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportSettings
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
        Me.Menu_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Guide = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadioDaysInCols = New System.Windows.Forms.RadioButton()
        Me.RadioDaysInRows = New System.Windows.Forms.RadioButton()
        Me.CheckBoxDetails = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxExamTable = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSuggest = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFreeTimes = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBG = New System.Windows.Forms.CheckBox()
        Me.cboTerms = New System.Windows.Forms.ComboBox()
        Me.CheckBoxExamDate = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCourseGroup = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCourseNumber = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCourseName = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRememberSettings = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_OK, Me.Menu_Guide, Me.ToolStripMenuItem1, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 76)
        '
        'Menu_OK
        '
        Me.Menu_OK.Name = "Menu_OK"
        Me.Menu_OK.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OK.Text = "تاييد / ادامه"
        '
        'Menu_Guide
        '
        Me.Menu_Guide.Name = "Menu_Guide"
        Me.Menu_Guide.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Guide.Text = "راهنما"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Cancel.Text = "انصراف / خروج"
        '
        'RadioDaysInCols
        '
        Me.RadioDaysInCols.AutoSize = True
        Me.RadioDaysInCols.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioDaysInCols.Location = New System.Drawing.Point(84, 339)
        Me.RadioDaysInCols.Name = "RadioDaysInCols"
        Me.RadioDaysInCols.Size = New System.Drawing.Size(131, 19)
        Me.RadioDaysInCols.TabIndex = 11
        Me.RadioDaysInCols.Text = "روزهاي هفته در ستون"
        Me.RadioDaysInCols.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioDaysInCols.UseVisualStyleBackColor = True
        '
        'RadioDaysInRows
        '
        Me.RadioDaysInRows.AutoSize = True
        Me.RadioDaysInRows.Checked = True
        Me.RadioDaysInRows.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioDaysInRows.Location = New System.Drawing.Point(87, 202)
        Me.RadioDaysInRows.Name = "RadioDaysInRows"
        Me.RadioDaysInRows.Size = New System.Drawing.Size(128, 19)
        Me.RadioDaysInRows.TabIndex = 6
        Me.RadioDaysInRows.TabStop = True
        Me.RadioDaysInRows.Text = "روزهاي هفته در سطر"
        Me.RadioDaysInRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioDaysInRows.UseVisualStyleBackColor = True
        '
        'CheckBoxDetails
        '
        Me.CheckBoxDetails.AutoSize = True
        Me.CheckBoxDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxDetails.Location = New System.Drawing.Point(112, 92)
        Me.CheckBoxDetails.Name = "CheckBoxDetails"
        Me.CheckBoxDetails.Size = New System.Drawing.Size(103, 19)
        Me.CheckBoxDetails.TabIndex = 2
        Me.CheckBoxDetails.Text = "گزارش با جزئيات"
        Me.CheckBoxDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDetails.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.CheckBoxExamTable)
        Me.Panel1.Controls.Add(Me.CheckBoxSuggest)
        Me.Panel1.Controls.Add(Me.CheckBoxFreeTimes)
        Me.Panel1.Controls.Add(Me.CheckBoxBG)
        Me.Panel1.Controls.Add(Me.cboTerms)
        Me.Panel1.Controls.Add(Me.CheckBoxExamDate)
        Me.Panel1.Controls.Add(Me.CheckBoxCourseGroup)
        Me.Panel1.Controls.Add(Me.CheckBoxCourseNumber)
        Me.Panel1.Controls.Add(Me.CheckBoxCourseName)
        Me.Panel1.Controls.Add(Me.CheckBoxRememberSettings)
        Me.Panel1.Controls.Add(Me.RadioDaysInCols)
        Me.Panel1.Controls.Add(Me.RadioDaysInRows)
        Me.Panel1.Controls.Add(Me.CheckBoxDetails)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(291, 424)
        Me.Panel1.TabIndex = 4
        '
        'CheckBoxExamTable
        '
        Me.CheckBoxExamTable.AutoSize = True
        Me.CheckBoxExamTable.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxExamTable.Location = New System.Drawing.Point(90, 167)
        Me.CheckBoxExamTable.Name = "CheckBoxExamTable"
        Me.CheckBoxExamTable.Size = New System.Drawing.Size(125, 19)
        Me.CheckBoxExamTable.TabIndex = 5
        Me.CheckBoxExamTable.Text = "جدول تاريخ امتحانات"
        Me.CheckBoxExamTable.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxExamTable.UseVisualStyleBackColor = True
        '
        'CheckBoxSuggest
        '
        Me.CheckBoxSuggest.AutoSize = True
        Me.CheckBoxSuggest.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxSuggest.Location = New System.Drawing.Point(101, 117)
        Me.CheckBoxSuggest.Name = "CheckBoxSuggest"
        Me.CheckBoxSuggest.Size = New System.Drawing.Size(114, 19)
        Me.CheckBoxSuggest.TabIndex = 3
        Me.CheckBoxSuggest.Text = "پيشنهاد رفع تداخل"
        Me.CheckBoxSuggest.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxSuggest.UseVisualStyleBackColor = True
        '
        'CheckBoxFreeTimes
        '
        Me.CheckBoxFreeTimes.AutoSize = True
        Me.CheckBoxFreeTimes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxFreeTimes.Location = New System.Drawing.Point(86, 142)
        Me.CheckBoxFreeTimes.Name = "CheckBoxFreeTimes"
        Me.CheckBoxFreeTimes.Size = New System.Drawing.Size(129, 19)
        Me.CheckBoxFreeTimes.TabIndex = 4
        Me.CheckBoxFreeTimes.Text = "جدول ساعت هاي آزاد"
        Me.CheckBoxFreeTimes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxFreeTimes.UseVisualStyleBackColor = True
        '
        'CheckBoxBG
        '
        Me.CheckBoxBG.AutoSize = True
        Me.CheckBoxBG.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxBG.Location = New System.Drawing.Point(129, 379)
        Me.CheckBoxBG.Name = "CheckBoxBG"
        Me.CheckBoxBG.Size = New System.Drawing.Size(86, 19)
        Me.CheckBoxBG.TabIndex = 12
        Me.CheckBoxBG.Text = "تصوير زمينه"
        Me.CheckBoxBG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxBG.UseVisualStyleBackColor = True
        '
        'cboTerms
        '
        Me.cboTerms.BackColor = System.Drawing.SystemColors.Window
        Me.cboTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerms.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboTerms.FormattingEnabled = True
        Me.cboTerms.Location = New System.Drawing.Point(166, 12)
        Me.cboTerms.Name = "cboTerms"
        Me.cboTerms.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTerms.Size = New System.Drawing.Size(95, 25)
        Me.cboTerms.TabIndex = 0
        '
        'CheckBoxExamDate
        '
        Me.CheckBoxExamDate.AutoSize = True
        Me.CheckBoxExamDate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxExamDate.Location = New System.Drawing.Point(44, 304)
        Me.CheckBoxExamDate.Name = "CheckBoxExamDate"
        Me.CheckBoxExamDate.Size = New System.Drawing.Size(128, 19)
        Me.CheckBoxExamDate.TabIndex = 10
        Me.CheckBoxExamDate.Text = "ساعت و تاريخ امتحان"
        Me.CheckBoxExamDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxExamDate.UseVisualStyleBackColor = True
        '
        'CheckBoxCourseGroup
        '
        Me.CheckBoxCourseGroup.AutoSize = True
        Me.CheckBoxCourseGroup.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxCourseGroup.Location = New System.Drawing.Point(64, 279)
        Me.CheckBoxCourseGroup.Name = "CheckBoxCourseGroup"
        Me.CheckBoxCourseGroup.Size = New System.Drawing.Size(108, 19)
        Me.CheckBoxCourseGroup.TabIndex = 9
        Me.CheckBoxCourseGroup.Text = "شماره گروه درس"
        Me.CheckBoxCourseGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCourseGroup.UseVisualStyleBackColor = True
        '
        'CheckBoxCourseNumber
        '
        Me.CheckBoxCourseNumber.AutoSize = True
        Me.CheckBoxCourseNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxCourseNumber.Location = New System.Drawing.Point(89, 254)
        Me.CheckBoxCourseNumber.Name = "CheckBoxCourseNumber"
        Me.CheckBoxCourseNumber.Size = New System.Drawing.Size(83, 19)
        Me.CheckBoxCourseNumber.TabIndex = 8
        Me.CheckBoxCourseNumber.Text = "شماره درس"
        Me.CheckBoxCourseNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCourseNumber.UseVisualStyleBackColor = True
        '
        'CheckBoxCourseName
        '
        Me.CheckBoxCourseName.AutoSize = True
        Me.CheckBoxCourseName.Checked = True
        Me.CheckBoxCourseName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCourseName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxCourseName.Location = New System.Drawing.Point(105, 229)
        Me.CheckBoxCourseName.Name = "CheckBoxCourseName"
        Me.CheckBoxCourseName.Size = New System.Drawing.Size(67, 19)
        Me.CheckBoxCourseName.TabIndex = 7
        Me.CheckBoxCourseName.Text = "نام درس"
        Me.CheckBoxCourseName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxCourseName.UseVisualStyleBackColor = True
        '
        'CheckBoxRememberSettings
        '
        Me.CheckBoxRememberSettings.AutoSize = True
        Me.CheckBoxRememberSettings.Checked = True
        Me.CheckBoxRememberSettings.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxRememberSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxRememberSettings.Location = New System.Drawing.Point(112, 53)
        Me.CheckBoxRememberSettings.Name = "CheckBoxRememberSettings"
        Me.CheckBoxRememberSettings.Size = New System.Drawing.Size(149, 19)
        Me.CheckBoxRememberSettings.TabIndex = 1
        Me.CheckBoxRememberSettings.Text = "تنظيمات را به خاطر بسپار"
        Me.CheckBoxRememberSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRememberSettings.UseVisualStyleBackColor = True
        '
        'frmReportSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(291, 445)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportSettings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تنظيمات گزارش"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_OK As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents RadioDaysInCols As RadioButton
    Friend WithEvents RadioDaysInRows As RadioButton
    Friend WithEvents CheckBoxDetails As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckBoxRememberSettings As CheckBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBoxBG As CheckBox
    Friend WithEvents CheckBoxExamDate As CheckBox
    Friend WithEvents CheckBoxCourseGroup As CheckBox
    Friend WithEvents CheckBoxCourseNumber As CheckBox
    Friend WithEvents CheckBoxCourseName As CheckBox
    Friend WithEvents cboTerms As ComboBox
    Friend WithEvents CheckBoxFreeTimes As CheckBox
    Friend WithEvents CheckBoxSuggest As CheckBox
    Friend WithEvents CheckBoxExamTable As CheckBox
    Friend WithEvents Menu_Guide As ToolStripMenuItem
End Class
