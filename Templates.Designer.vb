<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Templates
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Templates))
        Me.GridTemplateData = New System.Windows.Forms.DataGridView()
        Me.ContextMenuTempData = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_DelCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridTemplates = New System.Windows.Forms.DataGridView()
        Me.ContextMenuTemp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Del = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Apply = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ReportMe = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_ExitBack = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboDepts = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTerm = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkAsk = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.GridTemplateData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuTempData.SuspendLayout()
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuTemp.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridTemplateData
        '
        Me.GridTemplateData.AllowUserToAddRows = False
        Me.GridTemplateData.AllowUserToDeleteRows = False
        Me.GridTemplateData.AllowUserToOrderColumns = True
        Me.GridTemplateData.AllowUserToResizeColumns = False
        Me.GridTemplateData.AllowUserToResizeRows = False
        Me.GridTemplateData.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridTemplateData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridTemplateData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridTemplateData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTemplateData.ContextMenuStrip = Me.ContextMenuTempData
        Me.GridTemplateData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridTemplateData.Location = New System.Drawing.Point(14, 45)
        Me.GridTemplateData.Name = "GridTemplateData"
        Me.GridTemplateData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridTemplateData.RowTemplate.Height = 25
        Me.GridTemplateData.Size = New System.Drawing.Size(523, 566)
        Me.GridTemplateData.TabIndex = 0
        '
        'ContextMenuTempData
        '
        Me.ContextMenuTempData.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddCourse, Me.ToolStripMenuItem3, Me.Menu_DelCourse})
        Me.ContextMenuTempData.Name = "ContextMenuStrip3"
        Me.ContextMenuTempData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuTempData.Size = New System.Drawing.Size(149, 54)
        '
        'Menu_AddCourse
        '
        Me.Menu_AddCourse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_AddCourse.Name = "Menu_AddCourse"
        Me.Menu_AddCourse.Size = New System.Drawing.Size(148, 22)
        Me.Menu_AddCourse.Text = "+  افزودن درس"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(145, 6)
        '
        'Menu_DelCourse
        '
        Me.Menu_DelCourse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_DelCourse.Name = "Menu_DelCourse"
        Me.Menu_DelCourse.Size = New System.Drawing.Size(148, 22)
        Me.Menu_DelCourse.Text = "-  حذف درس"
        '
        'GridTemplates
        '
        Me.GridTemplates.AllowUserToAddRows = False
        Me.GridTemplates.AllowUserToDeleteRows = False
        Me.GridTemplates.AllowUserToOrderColumns = True
        Me.GridTemplates.AllowUserToResizeColumns = False
        Me.GridTemplates.AllowUserToResizeRows = False
        Me.GridTemplates.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridTemplates.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridTemplates.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTemplates.ContextMenuStrip = Me.ContextMenuTemp
        Me.GridTemplates.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridTemplates.Location = New System.Drawing.Point(549, 45)
        Me.GridTemplates.Name = "GridTemplates"
        Me.GridTemplates.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridTemplates.RowTemplate.Height = 25
        Me.GridTemplates.Size = New System.Drawing.Size(543, 566)
        Me.GridTemplates.TabIndex = 1
        '
        'ContextMenuTemp
        '
        Me.ContextMenuTemp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddNew, Me.Menu_Del, Me.ToolStripMenuItem2, Me.Menu_Apply, Me.Menu_ReportMe, Me.ToolStripMenuItem1, Me.Menu_ExitBack})
        Me.ContextMenuTemp.Name = "ContextMenuStrip3"
        Me.ContextMenuTemp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuTemp.Size = New System.Drawing.Size(129, 126)
        '
        'Menu_AddNew
        '
        Me.Menu_AddNew.Name = "Menu_AddNew"
        Me.Menu_AddNew.Size = New System.Drawing.Size(128, 22)
        Me.Menu_AddNew.Text = "الگوي جديد"
        '
        'Menu_Del
        '
        Me.Menu_Del.Name = "Menu_Del"
        Me.Menu_Del.Size = New System.Drawing.Size(128, 22)
        Me.Menu_Del.Text = "حذف الگو"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(125, 6)
        '
        'Menu_Apply
        '
        Me.Menu_Apply.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_Apply.Name = "Menu_Apply"
        Me.Menu_Apply.Size = New System.Drawing.Size(128, 22)
        Me.Menu_Apply.Text = "بکارگيري"
        '
        'Menu_ReportMe
        '
        Me.Menu_ReportMe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_ReportMe.Name = "Menu_ReportMe"
        Me.Menu_ReportMe.Size = New System.Drawing.Size(128, 22)
        Me.Menu_ReportMe.Text = "گزارش"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(125, 6)
        '
        'Menu_ExitBack
        '
        Me.Menu_ExitBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_ExitBack.Name = "Menu_ExitBack"
        Me.Menu_ExitBack.Size = New System.Drawing.Size(128, 22)
        Me.Menu_ExitBack.Text = "خروج"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExitToolStripMenuItem.Text = "خروج"
        '
        'ComboDepts
        '
        Me.ComboDepts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDepts.FormattingEnabled = True
        Me.ComboDepts.Location = New System.Drawing.Point(798, 6)
        Me.ComboDepts.Name = "ComboDepts"
        Me.ComboDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboDepts.Size = New System.Drawing.Size(296, 23)
        Me.ComboDepts.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(558, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "الگوها"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(483, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "دروس"
        '
        'txtTerm
        '
        Me.txtTerm.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtTerm.Location = New System.Drawing.Point(117, 10)
        Me.txtTerm.Name = "txtTerm"
        Me.txtTerm.Size = New System.Drawing.Size(47, 22)
        Me.txtTerm.TabIndex = 9
        Me.txtTerm.Text = "1"
        Me.txtTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Location = New System.Drawing.Point(169, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 15)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "افزودن درس در ترم"
        '
        'chkAsk
        '
        Me.chkAsk.AutoSize = True
        Me.chkAsk.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.chkAsk.Location = New System.Drawing.Point(31, 10)
        Me.chkAsk.Name = "chkAsk"
        Me.chkAsk.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkAsk.Size = New System.Drawing.Size(52, 19)
        Me.chkAsk.TabIndex = 11
        Me.chkAsk.Text = "بپرس"
        Me.chkAsk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAsk.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel1.Controls.Add(Me.ComboDepts)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.chkAsk)
        Me.Panel1.Controls.Add(Me.txtTerm)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 37)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.GridTemplates)
        Me.Panel2.Controls.Add(Me.GridTemplateData)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1104, 635)
        Me.Panel2.TabIndex = 13
        '
        'Templates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Goldenrod
        Me.ClientSize = New System.Drawing.Size(1104, 635)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Templates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "برنامه هاي ترميک (الگوها)"
        CType(Me.GridTemplateData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuTempData.ResumeLayout(False)
        CType(Me.GridTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuTemp.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridTemplateData As DataGridView
    Friend WithEvents GridTemplates As DataGridView
    Friend WithEvents الگوهاToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboDepts As ComboBox
    Friend WithEvents Menu_Report As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTerm As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkAsk As CheckBox
    Friend WithEvents ContextMenuTempData As ContextMenuStrip
    Friend WithEvents Menu_AddCourse As ToolStripMenuItem
    Friend WithEvents Menu_DelCourse As ToolStripMenuItem
    Friend WithEvents ContextMenuTemp As ContextMenuStrip
    Friend WithEvents Menu_AddNew As ToolStripMenuItem
    Friend WithEvents Menu_Del As ToolStripMenuItem
    Friend WithEvents Menu_Apply As ToolStripMenuItem
    Friend WithEvents Menu_ReportMe As ToolStripMenuItem
    Friend WithEvents Menu_ExitBack As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
