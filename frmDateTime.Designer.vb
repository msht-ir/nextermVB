﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDateTime
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
        Me.GridEnt = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridStaff = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Entry = New System.Windows.Forms.Label()
        Me.lbl_Staff = New System.Windows.Forms.Label()
        Me.txtExamDate = New System.Windows.Forms.MaskedTextBox()
        Me.lbl_Course = New System.Windows.Forms.Label()
        CType(Me.GridEnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.GridStaff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridEnt
        '
        Me.GridEnt.AllowUserToAddRows = False
        Me.GridEnt.AllowUserToDeleteRows = False
        Me.GridEnt.AllowUserToResizeColumns = False
        Me.GridEnt.AllowUserToResizeRows = False
        Me.GridEnt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridEnt.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridEnt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridEnt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridEnt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridEnt.DefaultCellStyle = DataGridViewCellStyle1
        Me.GridEnt.Dock = System.Windows.Forms.DockStyle.Right
        Me.GridEnt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridEnt.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.GridEnt.Location = New System.Drawing.Point(624, 0)
        Me.GridEnt.MultiSelect = False
        Me.GridEnt.Name = "GridEnt"
        Me.GridEnt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridEnt.RowHeadersVisible = False
        Me.GridEnt.RowTemplate.Height = 25
        Me.GridEnt.ShowCellToolTips = False
        Me.GridEnt.Size = New System.Drawing.Size(617, 371)
        Me.GridEnt.TabIndex = 36
        '
        'Column1
        '
        Me.Column1.HeaderText = "تاريخ"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "درس"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "استاد"
        Me.Column3.Name = "Column3"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_OK, Me.Menu_Cancel})
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuStrip1.Size = New System.Drawing.Size(112, 48)
        '
        'Menu_OK
        '
        Me.Menu_OK.Name = "Menu_OK"
        Me.Menu_OK.Size = New System.Drawing.Size(111, 22)
        Me.Menu_OK.Text = "تاييد"
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(111, 22)
        Me.Menu_Cancel.Text = "انصراف"
        '
        'GridStaff
        '
        Me.GridStaff.AllowUserToAddRows = False
        Me.GridStaff.AllowUserToDeleteRows = False
        Me.GridStaff.AllowUserToResizeColumns = False
        Me.GridStaff.AllowUserToResizeRows = False
        Me.GridStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridStaff.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridStaff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridStaff.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5, Me.Column6})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridStaff.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridStaff.Dock = System.Windows.Forms.DockStyle.Left
        Me.GridStaff.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridStaff.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.GridStaff.Location = New System.Drawing.Point(0, 0)
        Me.GridStaff.MultiSelect = False
        Me.GridStaff.Name = "GridStaff"
        Me.GridStaff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridStaff.RowHeadersVisible = False
        Me.GridStaff.RowTemplate.Height = 25
        Me.GridStaff.ShowCellToolTips = False
        Me.GridStaff.Size = New System.Drawing.Size(617, 371)
        Me.GridStaff.TabIndex = 37
        '
        'Column4
        '
        Me.Column4.HeaderText = "تاريخ"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "درس"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "ورودي"
        Me.Column6.Name = "Column6"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GridEnt)
        Me.Panel1.Controls.Add(Me.GridStaff)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1241, 371)
        Me.Panel1.TabIndex = 38
        '
        'lbl_Entry
        '
        Me.lbl_Entry.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl_Entry.Location = New System.Drawing.Point(624, 370)
        Me.lbl_Entry.Name = "lbl_Entry"
        Me.lbl_Entry.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_Entry.Size = New System.Drawing.Size(605, 23)
        Me.lbl_Entry.TabIndex = 39
        Me.lbl_Entry.Text = "برنامه امتحانات ورودي"
        Me.lbl_Entry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Staff
        '
        Me.lbl_Staff.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl_Staff.Location = New System.Drawing.Point(11, 374)
        Me.lbl_Staff.Name = "lbl_Staff"
        Me.lbl_Staff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_Staff.Size = New System.Drawing.Size(598, 19)
        Me.lbl_Staff.TabIndex = 40
        Me.lbl_Staff.Text = "برنامه امتحانات استاد"
        Me.lbl_Staff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtExamDate
        '
        Me.txtExamDate.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txtExamDate.ContextMenuStrip = Me.MenuStrip1
        Me.txtExamDate.Font = New System.Drawing.Font("Courier New", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.txtExamDate.ForeColor = System.Drawing.Color.Crimson
        Me.txtExamDate.Location = New System.Drawing.Point(509, 458)
        Me.txtExamDate.Mask = "0000.00.00 (00:00)"
        Me.txtExamDate.Name = "txtExamDate"
        Me.txtExamDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtExamDate.Size = New System.Drawing.Size(191, 24)
        Me.txtExamDate.TabIndex = 41
        Me.txtExamDate.Tag = ""
        Me.txtExamDate.Text = "130000000830"
        Me.txtExamDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtExamDate.ValidatingType = GetType(Date)
        '
        'lbl_Course
        '
        Me.lbl_Course.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Course.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lbl_Course.Location = New System.Drawing.Point(708, 459)
        Me.lbl_Course.Name = "lbl_Course"
        Me.lbl_Course.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_Course.Size = New System.Drawing.Size(493, 20)
        Me.lbl_Course.TabIndex = 42
        Me.lbl_Course.Text = "تاريخ امتحان"
        Me.lbl_Course.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmDateTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(1241, 494)
        Me.ContextMenuStrip = Me.MenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_Course)
        Me.Controls.Add(Me.txtExamDate)
        Me.Controls.Add(Me.lbl_Staff)
        Me.Controls.Add(Me.lbl_Entry)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDateTime"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تاريخ و ساعت امتحان"
        CType(Me.GridEnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        CType(Me.GridStaff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridEnt As DataGridView
    Friend WithEvents GridStaff As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Col1 As DataGridViewTextBoxColumn
    Friend WithEvents Col2 As DataGridViewTextBoxColumn
    Friend WithEvents Col3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_OK As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents lbl_Entry As Label
    Friend WithEvents lbl_Staff As Label
    Friend WithEvents txtExamDate As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_Course As Label
End Class
