<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepts
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepts))
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenu_Depts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddDept = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ChangePassDept = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_GuideDept = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_OKDept = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CancelDept = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBioProg = New System.Windows.Forms.ListBox()
        Me.ContextMenu_BioProg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddBioProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_EditBioProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ProgramSpecs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_OKBioProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CancelBioProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridEntries = New System.Windows.Forms.DataGridView()
        Me.ContextMenu_Entries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_EditEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_OKEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CancelEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ListStaff = New System.Windows.Forms.ListBox()
        Me.ContextMenu_Staff = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_EditStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_DelStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_OKStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CancelStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.PanelDept = New System.Windows.Forms.Panel()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.GridCourse = New System.Windows.Forms.DataGridView()
        Me.ContextMenuCourses = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddCourseFromList = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_AddCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_EditCourseNumber = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_EditCourseSpecs = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_ExportCourseList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_OKCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_CancelCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PanelCourse = New System.Windows.Forms.Panel()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenu_Depts.SuspendLayout()
        Me.ContextMenu_BioProg.SuspendLayout()
        CType(Me.GridEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenu_Entries.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ContextMenu_Staff.SuspendLayout()
        Me.PanelDept.SuspendLayout()
        CType(Me.GridCourse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuCourses.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.PanelCourse.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.AllowUserToResizeColumns = False
        Me.Grid1.AllowUserToResizeRows = False
        Me.Grid1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid1.ContextMenuStrip = Me.ContextMenu_Depts
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid1.GridColor = System.Drawing.SystemColors.InactiveCaption
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.MultiSelect = False
        Me.Grid1.Name = "Grid1"
        Me.Grid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 25
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid1.Size = New System.Drawing.Size(573, 498)
        Me.Grid1.TabIndex = 10
        '
        'ContextMenu_Depts
        '
        Me.ContextMenu_Depts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddDept, Me.Menu_ChangePassDept, Me.Menu_GuideDept, Me.ToolStripMenuItem1, Me.Menu_OKDept, Me.Menu_CancelDept})
        Me.ContextMenu_Depts.Name = "ContextMenuStripDepts"
        Me.ContextMenu_Depts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_Depts.Size = New System.Drawing.Size(148, 120)
        '
        'Menu_AddDept
        '
        Me.Menu_AddDept.Name = "Menu_AddDept"
        Me.Menu_AddDept.Size = New System.Drawing.Size(147, 22)
        Me.Menu_AddDept.Text = "+  گروه جديد"
        '
        'Menu_ChangePassDept
        '
        Me.Menu_ChangePassDept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_ChangePassDept.Name = "Menu_ChangePassDept"
        Me.Menu_ChangePassDept.Size = New System.Drawing.Size(147, 22)
        Me.Menu_ChangePassDept.Text = "کلمه عبور ..."
        '
        'Menu_GuideDept
        '
        Me.Menu_GuideDept.Name = "Menu_GuideDept"
        Me.Menu_GuideDept.Size = New System.Drawing.Size(147, 22)
        Me.Menu_GuideDept.Text = "راهنما"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_OKDept
        '
        Me.Menu_OKDept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_OKDept.Name = "Menu_OKDept"
        Me.Menu_OKDept.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OKDept.Text = "تاييد / انتخاب"
        '
        'Menu_CancelDept
        '
        Me.Menu_CancelDept.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_CancelDept.Name = "Menu_CancelDept"
        Me.Menu_CancelDept.Size = New System.Drawing.Size(147, 22)
        Me.Menu_CancelDept.Text = "انصراف / خروج"
        '
        'ListBioProg
        '
        Me.ListBioProg.BackColor = System.Drawing.SystemColors.Control
        Me.ListBioProg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBioProg.ContextMenuStrip = Me.ContextMenu_BioProg
        Me.ListBioProg.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListBioProg.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListBioProg.FormattingEnabled = True
        Me.ListBioProg.ItemHeight = 17
        Me.ListBioProg.Location = New System.Drawing.Point(0, 0)
        Me.ListBioProg.Name = "ListBioProg"
        Me.ListBioProg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListBioProg.Size = New System.Drawing.Size(191, 307)
        Me.ListBioProg.TabIndex = 13
        Me.ListBioProg.Tag = "انتخاب دوره آموزشي"
        '
        'ContextMenu_BioProg
        '
        Me.ContextMenu_BioProg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddBioProg, Me.ToolStripMenuItem3, Me.Menu_EditBioProg, Me.Menu_ProgramSpecs, Me.ToolStripSeparator1, Me.Menu_OKBioProg, Me.Menu_CancelBioProg})
        Me.ContextMenu_BioProg.Name = "ContextMenuStrip1"
        Me.ContextMenu_BioProg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_BioProg.Size = New System.Drawing.Size(148, 126)
        '
        'Menu_AddBioProg
        '
        Me.Menu_AddBioProg.Name = "Menu_AddBioProg"
        Me.Menu_AddBioProg.Size = New System.Drawing.Size(147, 22)
        Me.Menu_AddBioProg.Text = "+  دوره جديد"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_EditBioProg
        '
        Me.Menu_EditBioProg.Name = "Menu_EditBioProg"
        Me.Menu_EditBioProg.Size = New System.Drawing.Size(147, 22)
        Me.Menu_EditBioProg.Text = "ويرايش"
        '
        'Menu_ProgramSpecs
        '
        Me.Menu_ProgramSpecs.Name = "Menu_ProgramSpecs"
        Me.Menu_ProgramSpecs.Size = New System.Drawing.Size(147, 22)
        Me.Menu_ProgramSpecs.Text = "مشخصات"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_OKBioProg
        '
        Me.Menu_OKBioProg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_OKBioProg.Name = "Menu_OKBioProg"
        Me.Menu_OKBioProg.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OKBioProg.Text = "تاييد / انتخاب"
        '
        'Menu_CancelBioProg
        '
        Me.Menu_CancelBioProg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_CancelBioProg.Name = "Menu_CancelBioProg"
        Me.Menu_CancelBioProg.Size = New System.Drawing.Size(147, 22)
        Me.Menu_CancelBioProg.Text = "انصراف / خروج"
        '
        'GridEntries
        '
        Me.GridEntries.AllowUserToAddRows = False
        Me.GridEntries.AllowUserToDeleteRows = False
        Me.GridEntries.AllowUserToResizeColumns = False
        Me.GridEntries.AllowUserToResizeRows = False
        Me.GridEntries.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridEntries.ContextMenuStrip = Me.ContextMenu_Entries
        Me.GridEntries.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridEntries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridEntries.Location = New System.Drawing.Point(0, 307)
        Me.GridEntries.Name = "GridEntries"
        Me.GridEntries.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridEntries.RowHeadersVisible = False
        Me.GridEntries.RowTemplate.Height = 25
        Me.GridEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridEntries.Size = New System.Drawing.Size(361, 316)
        Me.GridEntries.TabIndex = 14
        '
        'ContextMenu_Entries
        '
        Me.ContextMenu_Entries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddEntry, Me.Menu_EditEntry, Me.ToolStripSeparator3, Me.Menu_OKEntry, Me.Menu_CancelEntry})
        Me.ContextMenu_Entries.Name = "ContextMenuStrip1"
        Me.ContextMenu_Entries.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_Entries.Size = New System.Drawing.Size(148, 98)
        '
        'Menu_AddEntry
        '
        Me.Menu_AddEntry.Name = "Menu_AddEntry"
        Me.Menu_AddEntry.Size = New System.Drawing.Size(147, 22)
        Me.Menu_AddEntry.Text = "+  ورودي جديد"
        '
        'Menu_EditEntry
        '
        Me.Menu_EditEntry.Name = "Menu_EditEntry"
        Me.Menu_EditEntry.Size = New System.Drawing.Size(147, 22)
        Me.Menu_EditEntry.Text = "ويرايش"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_OKEntry
        '
        Me.Menu_OKEntry.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_OKEntry.Name = "Menu_OKEntry"
        Me.Menu_OKEntry.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OKEntry.Text = "تاييد / انتخاب"
        '
        'Menu_CancelEntry
        '
        Me.Menu_CancelEntry.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_CancelEntry.Name = "Menu_CancelEntry"
        Me.Menu_CancelEntry.Size = New System.Drawing.Size(147, 22)
        Me.Menu_CancelEntry.Text = "انصراف / خروج"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GridEntries)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(361, 623)
        Me.Panel1.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ListStaff)
        Me.Panel2.Controls.Add(Me.ListBioProg)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(361, 307)
        Me.Panel2.TabIndex = 15
        '
        'ListStaff
        '
        Me.ListStaff.BackColor = System.Drawing.SystemColors.Control
        Me.ListStaff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListStaff.ContextMenuStrip = Me.ContextMenu_Staff
        Me.ListStaff.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListStaff.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListStaff.FormattingEnabled = True
        Me.ListStaff.ItemHeight = 17
        Me.ListStaff.Location = New System.Drawing.Point(191, 0)
        Me.ListStaff.Name = "ListStaff"
        Me.ListStaff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListStaff.Size = New System.Drawing.Size(170, 307)
        Me.ListStaff.TabIndex = 14
        '
        'ContextMenu_Staff
        '
        Me.ContextMenu_Staff.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddStaff, Me.ToolStripSeparator2, Me.Menu_EditStaff, Me.Menu_DelStaff, Me.ToolStripSeparator6, Me.Menu_OKStaff, Me.Menu_CancelStaff})
        Me.ContextMenu_Staff.Name = "ContextMenuStrip1"
        Me.ContextMenu_Staff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_Staff.Size = New System.Drawing.Size(148, 126)
        '
        'Menu_AddStaff
        '
        Me.Menu_AddStaff.Name = "Menu_AddStaff"
        Me.Menu_AddStaff.Size = New System.Drawing.Size(147, 22)
        Me.Menu_AddStaff.Text = "+   استاد جديد"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_EditStaff
        '
        Me.Menu_EditStaff.Name = "Menu_EditStaff"
        Me.Menu_EditStaff.Size = New System.Drawing.Size(147, 22)
        Me.Menu_EditStaff.Text = "ويرايش"
        '
        'Menu_DelStaff
        '
        Me.Menu_DelStaff.Enabled = False
        Me.Menu_DelStaff.Name = "Menu_DelStaff"
        Me.Menu_DelStaff.Size = New System.Drawing.Size(147, 22)
        Me.Menu_DelStaff.Text = "حذف استاد"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_OKStaff
        '
        Me.Menu_OKStaff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_OKStaff.Name = "Menu_OKStaff"
        Me.Menu_OKStaff.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OKStaff.Text = "تاييد / انتخاب"
        '
        'Menu_CancelStaff
        '
        Me.Menu_CancelStaff.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Menu_CancelStaff.Name = "Menu_CancelStaff"
        Me.Menu_CancelStaff.Size = New System.Drawing.Size(147, 22)
        Me.Menu_CancelStaff.Text = "انصراف / خروج"
        '
        'PanelDept
        '
        Me.PanelDept.BackColor = System.Drawing.SystemColors.Control
        Me.PanelDept.Controls.Add(Me.lblHelp)
        Me.PanelDept.Controls.Add(Me.Grid1)
        Me.PanelDept.Controls.Add(Me.btnExit)
        Me.PanelDept.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelDept.Location = New System.Drawing.Point(723, 0)
        Me.PanelDept.Name = "PanelDept"
        Me.PanelDept.Size = New System.Drawing.Size(573, 623)
        Me.PanelDept.TabIndex = 20
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BackColor = System.Drawing.SystemColors.Control
        Me.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHelp.Location = New System.Drawing.Point(0, 498)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(41, 15)
        Me.lblHelp.TabIndex = 11
        Me.lblHelp.Text = "Label1"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnExit.Location = New System.Drawing.Point(7, 436)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(102, 25)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "خروج"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'GridCourse
        '
        Me.GridCourse.AllowUserToAddRows = False
        Me.GridCourse.AllowUserToDeleteRows = False
        Me.GridCourse.AllowUserToResizeColumns = False
        Me.GridCourse.AllowUserToResizeRows = False
        Me.GridCourse.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridCourse.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCourse.ContextMenuStrip = Me.ContextMenuCourses
        Me.GridCourse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridCourse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridCourse.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GridCourse.Location = New System.Drawing.Point(0, 0)
        Me.GridCourse.Name = "GridCourse"
        Me.GridCourse.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridCourse.RowHeadersVisible = False
        Me.GridCourse.RowTemplate.Height = 25
        Me.GridCourse.Size = New System.Drawing.Size(362, 623)
        Me.GridCourse.TabIndex = 18
        '
        'ContextMenuCourses
        '
        Me.ContextMenuCourses.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddCourseFromList, Me.Menu_AddCourse, Me.Menu_EditCourseNumber, Me.Menu_EditCourseSpecs, Me.ToolStripSeparator4, Me.Menu_ExportCourseList, Me.ToolStripMenuItem2, Me.Menu_OKCourse, Me.Menu_CancelCourse})
        Me.ContextMenuCourses.Name = "ContextMenuStrip1"
        Me.ContextMenuCourses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuCourses.Size = New System.Drawing.Size(181, 192)
        '
        'Menu_AddCourseFromList
        '
        Me.Menu_AddCourseFromList.Enabled = False
        Me.Menu_AddCourseFromList.Name = "Menu_AddCourseFromList"
        Me.Menu_AddCourseFromList.Size = New System.Drawing.Size(180, 22)
        Me.Menu_AddCourseFromList.Text = "+  از ليست ..."
        '
        'Menu_AddCourse
        '
        Me.Menu_AddCourse.Name = "Menu_AddCourse"
        Me.Menu_AddCourse.Size = New System.Drawing.Size(180, 22)
        Me.Menu_AddCourse.Text = "+  درس جديد"
        '
        'Menu_EditCourseNumber
        '
        Me.Menu_EditCourseNumber.Name = "Menu_EditCourseNumber"
        Me.Menu_EditCourseNumber.Size = New System.Drawing.Size(180, 22)
        Me.Menu_EditCourseNumber.Text = "ويرايش شماره"
        '
        'Menu_EditCourseSpecs
        '
        Me.Menu_EditCourseSpecs.Name = "Menu_EditCourseSpecs"
        Me.Menu_EditCourseSpecs.Size = New System.Drawing.Size(180, 22)
        Me.Menu_EditCourseSpecs.Text = "مشخصات"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_ExportCourseList
        '
        Me.Menu_ExportCourseList.Name = "Menu_ExportCourseList"
        Me.Menu_ExportCourseList.Size = New System.Drawing.Size(180, 22)
        Me.Menu_ExportCourseList.Text = "ذخيره در فايل ..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_OKCourse
        '
        Me.Menu_OKCourse.Name = "Menu_OKCourse"
        Me.Menu_OKCourse.Size = New System.Drawing.Size(180, 22)
        Me.Menu_OKCourse.Text = " تاييد / انتخاب"
        '
        'Menu_CancelCourse
        '
        Me.Menu_CancelCourse.Name = "Menu_CancelCourse"
        Me.Menu_CancelCourse.Size = New System.Drawing.Size(180, 22)
        Me.Menu_CancelCourse.Text = "خروج / انصراف"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.PanelCourse)
        Me.Panel4.Controls.Add(Me.PanelDept)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1296, 623)
        Me.Panel4.TabIndex = 19
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(362, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(361, 623)
        Me.Panel6.TabIndex = 19
        '
        'PanelCourse
        '
        Me.PanelCourse.Controls.Add(Me.GridCourse)
        Me.PanelCourse.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelCourse.Location = New System.Drawing.Point(0, 0)
        Me.PanelCourse.Name = "PanelCourse"
        Me.PanelCourse.Size = New System.Drawing.Size(362, 623)
        Me.PanelCourse.TabIndex = 0
        '
        'frmDepts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1296, 623)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDepts"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گروه هاي آموزشي، دوره ها، ورودي ها و اساتيد"
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenu_Depts.ResumeLayout(False)
        Me.ContextMenu_BioProg.ResumeLayout(False)
        CType(Me.GridEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenu_Entries.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ContextMenu_Staff.ResumeLayout(False)
        Me.PanelDept.ResumeLayout(False)
        Me.PanelDept.PerformLayout()
        CType(Me.GridCourse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuCourses.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.PanelCourse.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents ContextMenu_Depts As ContextMenuStrip
    Friend WithEvents Menu_AddDept As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_OKDept As ToolStripMenuItem
    Friend WithEvents Menu_CancelDept As ToolStripMenuItem
    Friend WithEvents ListBioProg As ListBox
    Friend WithEvents GridEntries As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ContextMenu_BioProg As ContextMenuStrip
    Friend WithEvents Menu_OKBioProg As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Menu_AddBioProg As ToolStripMenuItem
    Friend WithEvents Menu_EditBioProg As ToolStripMenuItem
    Friend WithEvents Menu_CancelBioProg As ToolStripMenuItem
    Friend WithEvents ContextMenu_Entries As ContextMenuStrip
    Friend WithEvents Menu_OKEntry As ToolStripMenuItem
    Friend WithEvents Menu_AddEntry As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Menu_CancelEntry As ToolStripMenuItem
    Friend WithEvents Menu_EditEntry As ToolStripMenuItem
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListStaff As ListBox
    Friend WithEvents ContextMenu_Staff As ContextMenuStrip
    Friend WithEvents Menu_OKStaff As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Menu_AddStaff As ToolStripMenuItem
    Friend WithEvents Menu_DelStaff As ToolStripMenuItem
    Friend WithEvents Menu_EditStaff As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents Menu_CancelStaff As ToolStripMenuItem
    Friend WithEvents PanelDept As Panel
    Friend WithEvents Menu_ChangePassDept As ToolStripMenuItem
    Friend WithEvents Menu_GuideDept As ToolStripMenuItem
    Friend WithEvents btnExit As Button
    Friend WithEvents GridCourse As DataGridView
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PanelCourse As Panel
    Friend WithEvents ContextMenuCourses As ContextMenuStrip
    Friend WithEvents Menu_OKCourse As ToolStripMenuItem
    Friend WithEvents Menu_AddCourse As ToolStripMenuItem
    Friend WithEvents Menu_EditCourseNumber As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents Menu_CancelCourse As ToolStripMenuItem
    Friend WithEvents lblHelp As Label
    Friend WithEvents Menu_AddCourseFromList As ToolStripMenuItem
    Friend WithEvents Menu_ExportCourseList As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents Menu_ProgramSpecs As ToolStripMenuItem
    Friend WithEvents Menu_EditCourseSpecs As ToolStripMenuItem
End Class
