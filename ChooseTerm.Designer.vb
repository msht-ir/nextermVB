<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseTerm
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
        Me.Grid1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Add = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.Grid1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Grid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Grid1.GridColor = System.Drawing.SystemColors.Control
        Me.Grid1.Location = New System.Drawing.Point(0, 0)
        Me.Grid1.MultiSelect = False
        Me.Grid1.Name = "Grid1"
        Me.Grid1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Grid1.RowHeadersVisible = False
        Me.Grid1.RowTemplate.Height = 25
        Me.Grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Grid1.Size = New System.Drawing.Size(112, 504)
        Me.Grid1.TabIndex = 10
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_OK, Me.ToolStripMenuItem2, Me.Menu_Add, Me.Menu_Edit, Me.ToolStripMenuItem1, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(174, 104)
        '
        'Menu_OK
        '
        Me.Menu_OK.Name = "Menu_OK"
        Me.Menu_OK.Size = New System.Drawing.Size(173, 22)
        Me.Menu_OK.Text = "انتخاب / تاييد"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(170, 6)
        '
        'Menu_Add
        '
        Me.Menu_Add.Name = "Menu_Add"
        Me.Menu_Add.Size = New System.Drawing.Size(173, 22)
        Me.Menu_Add.Text = "افزودن"
        '
        'Menu_Edit
        '
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.Size = New System.Drawing.Size(173, 22)
        Me.Menu_Edit.Text = "ويرايش / تغيير حالت"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(173, 22)
        Me.Menu_Cancel.Text = "انصراف / خروج"
        '
        'ChooseTerm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(112, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.Grid1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChooseTerm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ترم"
        CType(Me.Grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Grid1 As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_Add As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_OK As ToolStripMenuItem
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_Edit As ToolStripMenuItem
End Class
