<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShowNotes
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
        Me.GridNotes = New System.Windows.Forms.DataGridView()
        Me.ContextMenuNotes = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Note2Faculty = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_AddNote = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Del = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChkMyNotes = New System.Windows.Forms.CheckBox()
        CType(Me.GridNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuNotes.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridNotes
        '
        Me.GridNotes.AllowUserToAddRows = False
        Me.GridNotes.AllowUserToDeleteRows = False
        Me.GridNotes.AllowUserToResizeColumns = False
        Me.GridNotes.AllowUserToResizeRows = False
        Me.GridNotes.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridNotes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridNotes.ContextMenuStrip = Me.ContextMenuNotes
        Me.GridNotes.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridNotes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridNotes.GridColor = System.Drawing.Color.LightSeaGreen
        Me.GridNotes.Location = New System.Drawing.Point(0, 0)
        Me.GridNotes.Name = "GridNotes"
        Me.GridNotes.RowHeadersVisible = False
        Me.GridNotes.RowTemplate.Height = 25
        Me.GridNotes.Size = New System.Drawing.Size(1107, 402)
        Me.GridNotes.TabIndex = 0
        '
        'ContextMenuNotes
        '
        Me.ContextMenuNotes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Note2Faculty, Me.Menu_AddNote, Me.Menu_Del, Me.ToolStripMenuItem2, Me.Menu_Exit})
        Me.ContextMenuNotes.Name = "ContextMenuNotes"
        Me.ContextMenuNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuNotes.Size = New System.Drawing.Size(192, 98)
        '
        'Menu_Note2Faculty
        '
        Me.Menu_Note2Faculty.Name = "Menu_Note2Faculty"
        Me.Menu_Note2Faculty.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Note2Faculty.Text = "يادداشت براي دانشکده"
        '
        'Menu_AddNote
        '
        Me.Menu_AddNote.Name = "Menu_AddNote"
        Me.Menu_AddNote.Size = New System.Drawing.Size(191, 22)
        Me.Menu_AddNote.Text = "يادداشت براي گروه ها ..."
        '
        'Menu_Del
        '
        Me.Menu_Del.Name = "Menu_Del"
        Me.Menu_Del.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Del.Text = "حذف يادداشت"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(188, 6)
        '
        'Menu_Exit
        '
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(191, 22)
        Me.Menu_Exit.Text = "خروج"
        '
        'ChkMyNotes
        '
        Me.ChkMyNotes.AutoSize = True
        Me.ChkMyNotes.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.ChkMyNotes.Location = New System.Drawing.Point(501, 410)
        Me.ChkMyNotes.Name = "ChkMyNotes"
        Me.ChkMyNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkMyNotes.Size = New System.Drawing.Size(110, 19)
        Me.ChkMyNotes.TabIndex = 1
        Me.ChkMyNotes.Text = "يادداشت هاي من"
        Me.ChkMyNotes.UseVisualStyleBackColor = True
        '
        'frmShowNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(1107, 441)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkMyNotes)
        Me.Controls.Add(Me.GridNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShowNotes"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "يادداشت"
        CType(Me.GridNotes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuNotes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridNotes As DataGridView
    Friend WithEvents ContextMenuNotes As ContextMenuStrip
    Friend WithEvents Menu_AddNote As ToolStripMenuItem
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents Menu_Del As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ChkMyNotes As CheckBox
    Friend WithEvents Menu_Note2Faculty As ToolStripMenuItem
End Class
