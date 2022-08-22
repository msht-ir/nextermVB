<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowTables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShowTables))
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuCourses = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_AddNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOkExit = New System.Windows.Forms.Button()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuCourses.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid1
        '
        Me.Grid1.AllowUserToAddRows = False
        Me.Grid1.AllowUserToDeleteRows = False
        Me.Grid1.AllowUserToResizeColumns = False
        Me.Grid1.AllowUserToResizeRows = False
        Me.Grid1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Grid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid1.ContextMenuStrip = Me.ContextMenuCourses
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Grid1.GridColor = System.Drawing.SystemColors.Control
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.MultiSelect = False
        Me.Grid1.Name = "Grid1"
        Me.Grid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 25
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid1.Size = New System.Drawing.Size(529, 536)
        Me.Grid1.TabIndex = 0
        '
        'ContextMenuCourses
        '
        Me.ContextMenuCourses.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_AddNew, Me.ToolStripMenuItem1, Me.Menu_Exit, Me.Menu_Cancel})
        Me.ContextMenuCourses.Name = "ContextMenuStrip1"
        Me.ContextMenuCourses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuCourses.Size = New System.Drawing.Size(161, 76)
        '
        'Menu_AddNew
        '
        Me.Menu_AddNew.Name = "Menu_AddNew"
        Me.Menu_AddNew.Size = New System.Drawing.Size(160, 22)
        Me.Menu_AddNew.Text = "افزودن درس جديد"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(157, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(160, 22)
        Me.Menu_Exit.Text = "انتخاب / تاييد"
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(160, 22)
        Me.Menu_Cancel.Text = "انصراف / خروج"
        '
        'btnOkExit
        '
        Me.btnOkExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnOkExit.Location = New System.Drawing.Point(192, 544)
        Me.btnOkExit.Name = "btnOkExit"
        Me.btnOkExit.Size = New System.Drawing.Size(143, 25)
        Me.btnOkExit.TabIndex = 9
        Me.btnOkExit.Text = "انتخاب / تاييد"
        Me.btnOkExit.UseVisualStyleBackColor = False
        '
        'frmShowTables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(529, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOkExit)
        Me.Controls.Add(Me.Grid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShowTables"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "درس ها"
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuCourses.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents ContextMenuCourses As ContextMenuStrip
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents Menu_AddNew As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents btnOkExit As Button
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
End Class
