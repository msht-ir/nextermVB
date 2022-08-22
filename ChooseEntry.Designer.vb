<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChooseEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChooseEntry))
        Me.ComboDepts = New System.Windows.Forms.ComboBox()
        Me.GridEntries = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStripEntries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuOK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuAddNewEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBioProgs = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.GridEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripEntries.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboDepts
        '
        Me.ComboDepts.BackColor = System.Drawing.SystemColors.Control
        Me.ComboDepts.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboDepts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDepts.FormattingEnabled = True
        Me.ComboDepts.Location = New System.Drawing.Point(0, 0)
        Me.ComboDepts.Name = "ComboDepts"
        Me.ComboDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboDepts.Size = New System.Drawing.Size(247, 23)
        Me.ComboDepts.TabIndex = 0
        '
        'GridEntries
        '
        Me.GridEntries.AllowUserToAddRows = False
        Me.GridEntries.AllowUserToDeleteRows = False
        Me.GridEntries.AllowUserToResizeColumns = False
        Me.GridEntries.AllowUserToResizeRows = False
        Me.GridEntries.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridEntries.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridEntries.ContextMenuStrip = Me.ContextMenuStripEntries
        Me.GridEntries.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridEntries.Location = New System.Drawing.Point(12, 12)
        Me.GridEntries.Name = "GridEntries"
        Me.GridEntries.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridEntries.RowHeadersVisible = False
        Me.GridEntries.RowTemplate.Height = 25
        Me.GridEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridEntries.Size = New System.Drawing.Size(430, 332)
        Me.GridEntries.TabIndex = 0
        '
        'ContextMenuStripEntries
        '
        Me.ContextMenuStripEntries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOK, Me.ToolStripMenuItem1, Me.MenuAddNewEntry, Me.ToolStripMenuItem2, Me.MenuCancel})
        Me.ContextMenuStripEntries.Name = "ContextMenuStrip1"
        Me.ContextMenuStripEntries.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStripEntries.Size = New System.Drawing.Size(168, 82)
        '
        'MenuOK
        '
        Me.MenuOK.Name = "MenuOK"
        Me.MenuOK.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.MenuOK.Size = New System.Drawing.Size(167, 22)
        Me.MenuOK.Text = "انتخاب / تاييد"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(164, 6)
        '
        'MenuAddNewEntry
        '
        Me.MenuAddNewEntry.Name = "MenuAddNewEntry"
        Me.MenuAddNewEntry.Size = New System.Drawing.Size(167, 22)
        Me.MenuAddNewEntry.Text = "افزودن ورودي جديد"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(164, 6)
        '
        'MenuCancel
        '
        Me.MenuCancel.Name = "MenuCancel"
        Me.MenuCancel.Size = New System.Drawing.Size(167, 22)
        Me.MenuCancel.Text = "انصراف / خروج"
        '
        'ListBioProgs
        '
        Me.ListBioProgs.BackColor = System.Drawing.SystemColors.Control
        Me.ListBioProgs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBioProgs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBioProgs.FormattingEnabled = True
        Me.ListBioProgs.ItemHeight = 15
        Me.ListBioProgs.Location = New System.Drawing.Point(0, 32)
        Me.ListBioProgs.Name = "ListBioProgs"
        Me.ListBioProgs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListBioProgs.Size = New System.Drawing.Size(247, 300)
        Me.ListBioProgs.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.ComboDepts)
        Me.Panel1.Controls.Add(Me.ListBioProgs)
        Me.Panel1.Location = New System.Drawing.Point(448, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 332)
        Me.Panel1.TabIndex = 17
        '
        'ChooseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(707, 360)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridEntries)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChooseEntry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ورودي"
        CType(Me.GridEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripEntries.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboDepts As ComboBox
    Friend WithEvents GridEntries As DataGridView
    Friend WithEvents ListBioProgs As ListBox
    Friend WithEvents ContextMenuStripEntries As ContextMenuStrip
    Friend WithEvents MenuOK As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents MenuAddNewEntry As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents MenuCancel As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
End Class
