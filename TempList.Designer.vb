<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TempList
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
        Me.Menu_Guide = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_ReadFromFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_All = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_None = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_InvertSelection = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridCourse = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridCourse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Guide, Me.Menu_ReadFromFile, Me.ToolStripMenuItem2, Me.Menu_All, Me.Menu_None, Me.Menu_InvertSelection, Me.ToolStripMenuItem1, Me.Menu_OK, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 192)
        '
        'Menu_Guide
        '
        Me.Menu_Guide.Name = "Menu_Guide"
        Me.Menu_Guide.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Guide.Text = "راهنما"
        '
        'Menu_ReadFromFile
        '
        Me.Menu_ReadFromFile.Name = "Menu_ReadFromFile"
        Me.Menu_ReadFromFile.Size = New System.Drawing.Size(180, 22)
        Me.Menu_ReadFromFile.Text = "خواندن از فايل ..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_All
        '
        Me.Menu_All.Name = "Menu_All"
        Me.Menu_All.Size = New System.Drawing.Size(180, 22)
        Me.Menu_All.Text = "همه"
        '
        'Menu_None
        '
        Me.Menu_None.Name = "Menu_None"
        Me.Menu_None.Size = New System.Drawing.Size(180, 22)
        Me.Menu_None.Text = "هيچ"
        '
        'Menu_InvertSelection
        '
        Me.Menu_InvertSelection.Name = "Menu_InvertSelection"
        Me.Menu_InvertSelection.Size = New System.Drawing.Size(180, 22)
        Me.Menu_InvertSelection.Text = "برعکس"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_OK
        '
        Me.Menu_OK.Name = "Menu_OK"
        Me.Menu_OK.Size = New System.Drawing.Size(180, 22)
        Me.Menu_OK.Text = "تاييد"
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Cancel.Text = "انصراف / خروج"
        '
        'GridCourse
        '
        Me.GridCourse.AllowUserToAddRows = False
        Me.GridCourse.AllowUserToResizeColumns = False
        Me.GridCourse.AllowUserToResizeRows = False
        Me.GridCourse.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridCourse.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCourse.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column4})
        Me.GridCourse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridCourse.Location = New System.Drawing.Point(9, 8)
        Me.GridCourse.Name = "GridCourse"
        Me.GridCourse.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridCourse.RowHeadersVisible = False
        Me.GridCourse.RowTemplate.Height = 25
        Me.GridCourse.Size = New System.Drawing.Size(441, 513)
        Me.GridCourse.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 18
        '
        'Column2
        '
        Me.Column2.HeaderText = "شماره"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 90
        '
        'Column3
        '
        Me.Column3.HeaderText = "نام درس"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 210
        '
        'Column5
        '
        Me.Column5.HeaderText = "مشخصات"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "واحد"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 35
        '
        'TempList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(460, 557)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.GridCourse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TempList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TempList"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridCourse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_OK As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents Menu_All As ToolStripMenuItem
    Friend WithEvents Menu_None As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_InvertSelection As ToolStripMenuItem
    Friend WithEvents Menu_ReadFromFile As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents GridCourse As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Menu_Guide As ToolStripMenuItem
End Class
