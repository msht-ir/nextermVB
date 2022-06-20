<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffProgs
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ContextMenu_frmStaff = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Munu_Report = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Munu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ListStaff = New System.Windows.Forms.ListBox()
        Me.Grid4 = New System.Windows.Forms.DataGridView()
        Me.GridTime = New System.Windows.Forms.DataGridView()
        Me.Dayx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t1130 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t1330 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t1430 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t1530 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t1630 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenu_frmStaff.SuspendLayout()
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox2
        '
        Me.ListBox2.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.ContextMenuStrip = Me.ContextMenu_frmStaff
        Me.ListBox2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 20
        Me.ListBox2.Location = New System.Drawing.Point(937, 30)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ListBox2.Size = New System.Drawing.Size(88, 320)
        Me.ListBox2.TabIndex = 33
        '
        'ContextMenu_frmStaff
        '
        Me.ContextMenu_frmStaff.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Munu_Report, Me.ToolStripMenuItem1, Me.Munu_Exit})
        Me.ContextMenu_frmStaff.Name = "ContextMenu_frmStaff"
        Me.ContextMenu_frmStaff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_frmStaff.Size = New System.Drawing.Size(106, 54)
        '
        'Munu_Report
        '
        Me.Munu_Report.Enabled = False
        Me.Munu_Report.Name = "Munu_Report"
        Me.Munu_Report.Size = New System.Drawing.Size(105, 22)
        Me.Munu_Report.Text = "گزارش"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(102, 6)
        '
        'Munu_Exit
        '
        Me.Munu_Exit.Name = "Munu_Exit"
        Me.Munu_Exit.Size = New System.Drawing.Size(105, 22)
        Me.Munu_Exit.Text = "خروج"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ComboBox1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(1036, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(219, 25)
        Me.ComboBox1.TabIndex = 31
        '
        'ListStaff
        '
        Me.ListStaff.BackColor = System.Drawing.SystemColors.Control
        Me.ListStaff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListStaff.ContextMenuStrip = Me.ContextMenu_frmStaff
        Me.ListStaff.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListStaff.ForeColor = System.Drawing.Color.IndianRed
        Me.ListStaff.FormattingEnabled = True
        Me.ListStaff.ItemHeight = 17
        Me.ListStaff.Location = New System.Drawing.Point(1036, 44)
        Me.ListStaff.Name = "ListStaff"
        Me.ListStaff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListStaff.Size = New System.Drawing.Size(219, 306)
        Me.ListStaff.TabIndex = 32
        '
        'Grid4
        '
        Me.Grid4.AllowUserToAddRows = False
        Me.Grid4.AllowUserToDeleteRows = False
        Me.Grid4.AllowUserToResizeColumns = False
        Me.Grid4.AllowUserToResizeRows = False
        Me.Grid4.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Grid4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid4.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Grid4.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Grid4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid4.ContextMenuStrip = Me.ContextMenu_frmStaff
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grid4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid4.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Grid4.Location = New System.Drawing.Point(12, 13)
        Me.Grid4.MultiSelect = False
        Me.Grid4.Name = "Grid4"
        Me.Grid4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Grid4.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Grid4.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.Grid4.RowTemplate.Height = 25
        Me.Grid4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid4.ShowCellToolTips = False
        Me.Grid4.Size = New System.Drawing.Size(912, 337)
        Me.Grid4.TabIndex = 34
        '
        'GridTime
        '
        Me.GridTime.AllowUserToAddRows = False
        Me.GridTime.AllowUserToDeleteRows = False
        Me.GridTime.AllowUserToResizeColumns = False
        Me.GridTime.AllowUserToResizeRows = False
        Me.GridTime.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridTime.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridTime.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dayx, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.t1130, Me.t1330, Me.t1430, Me.t1530, Me.t1630})
        Me.GridTime.ContextMenuStrip = Me.ContextMenu_frmStaff
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.GridTime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridTime.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GridTime.Location = New System.Drawing.Point(12, 359)
        Me.GridTime.Name = "GridTime"
        Me.GridTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridTime.RowHeadersVisible = False
        Me.GridTime.RowTemplate.Height = 25
        Me.GridTime.ShowCellToolTips = False
        Me.GridTime.Size = New System.Drawing.Size(1243, 177)
        Me.GridTime.TabIndex = 35
        '
        'Dayx
        '
        Me.Dayx.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Dayx.HeaderText = "روز"
        Me.Dayx.Name = "Dayx"
        Me.Dayx.Width = 47
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "08:30"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "09:30"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "10:30"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        't1130
        '
        Me.t1130.HeaderText = "11:30"
        Me.t1130.Name = "t1130"
        '
        't1330
        '
        Me.t1330.HeaderText = "13:30"
        Me.t1330.Name = "t1330"
        '
        't1430
        '
        Me.t1430.HeaderText = "14:30"
        Me.t1430.Name = "t1430"
        '
        't1530
        '
        Me.t1530.HeaderText = "15:30"
        Me.t1530.Name = "t1530"
        '
        't1630
        '
        Me.t1630.HeaderText = "16:30"
        Me.t1630.Name = "t1630"
        '
        'frmStaffProgs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(1266, 552)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridTime)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ListStaff)
        Me.Controls.Add(Me.Grid4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStaffProgs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "برنامه استاد"
        Me.ContextMenu_frmStaff.ResumeLayout(False)
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox2 As ListBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ListStaff As ListBox
    Friend WithEvents Grid4 As DataGridView
    Friend WithEvents ContextMenu_frmStaff As ContextMenuStrip
    Friend WithEvents Munu_Exit As ToolStripMenuItem
    Friend WithEvents Label3 As Label
    Friend WithEvents Munu_Report As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents GridTime As DataGridView
    Friend WithEvents Dayx As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents t1130 As DataGridViewTextBoxColumn
    Friend WithEvents t1330 As DataGridViewTextBoxColumn
    Friend WithEvents t1430 As DataGridViewTextBoxColumn
    Friend WithEvents t1530 As DataGridViewTextBoxColumn
    Friend WithEvents t1630 As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents Menu_SelectStaffTech As ToolStripComboBox
End Class
