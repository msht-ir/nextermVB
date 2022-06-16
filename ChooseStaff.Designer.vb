<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChooseStaff
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChooseStaff))
        Me.ListStaff = New System.Windows.Forms.ListBox()
        Me.ContextMenu_Staff = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuOK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuAddNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_DelStaff = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListDepts = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenu_Staff.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListStaff
        '
        Me.ListStaff.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ListStaff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListStaff.ContextMenuStrip = Me.ContextMenu_Staff
        Me.ListStaff.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListStaff.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListStaff.FormattingEnabled = True
        Me.ListStaff.ItemHeight = 17
        Me.ListStaff.Location = New System.Drawing.Point(0, 0)
        Me.ListStaff.Name = "ListStaff"
        Me.ListStaff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListStaff.Size = New System.Drawing.Size(252, 377)
        Me.ListStaff.TabIndex = 4
        '
        'ContextMenu_Staff
        '
        Me.ContextMenu_Staff.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOK, Me.ToolStripMenuItem2, Me.MenuAddNew, Me.Menu_DelStaff, Me.MenuEdit, Me.ToolStripMenuItem1, Me.MenuCancel})
        Me.ContextMenu_Staff.Name = "ContextMenuStrip1"
        Me.ContextMenu_Staff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_Staff.Size = New System.Drawing.Size(163, 126)
        '
        'MenuOK
        '
        Me.MenuOK.Name = "MenuOK"
        Me.MenuOK.Size = New System.Drawing.Size(162, 22)
        Me.MenuOK.Text = "انتخاب / تاييد"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(159, 6)
        '
        'MenuAddNew
        '
        Me.MenuAddNew.Name = "MenuAddNew"
        Me.MenuAddNew.Size = New System.Drawing.Size(162, 22)
        Me.MenuAddNew.Text = "افزودن استاد جديد"
        '
        'Menu_DelStaff
        '
        Me.Menu_DelStaff.Enabled = False
        Me.Menu_DelStaff.Name = "Menu_DelStaff"
        Me.Menu_DelStaff.Size = New System.Drawing.Size(162, 22)
        Me.Menu_DelStaff.Text = "حذف استاد"
        '
        'MenuEdit
        '
        Me.MenuEdit.Name = "MenuEdit"
        Me.MenuEdit.Size = New System.Drawing.Size(162, 22)
        Me.MenuEdit.Text = "ويرايش"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(159, 6)
        '
        'MenuCancel
        '
        Me.MenuCancel.Name = "MenuCancel"
        Me.MenuCancel.Size = New System.Drawing.Size(162, 22)
        Me.MenuCancel.Text = "انصراف / خروج"
        '
        'ListDepts
        '
        Me.ListDepts.BackColor = System.Drawing.SystemColors.Control
        Me.ListDepts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListDepts.ContextMenuStrip = Me.ContextMenu_Staff
        Me.ListDepts.Dock = System.Windows.Forms.DockStyle.Right
        Me.ListDepts.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListDepts.FormattingEnabled = True
        Me.ListDepts.ItemHeight = 17
        Me.ListDepts.Location = New System.Drawing.Point(258, 0)
        Me.ListDepts.Name = "ListDepts"
        Me.ListDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListDepts.Size = New System.Drawing.Size(255, 377)
        Me.ListDepts.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListStaff)
        Me.Panel1.Controls.Add(Me.ListDepts)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(513, 377)
        Me.Panel1.TabIndex = 6
        '
        'ChooseStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.ClientSize = New System.Drawing.Size(513, 421)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChooseStaff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اساتيد"
        Me.ContextMenu_Staff.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListStaff As ListBox
    Friend WithEvents ContextMenu_Staff As ContextMenuStrip
    Friend WithEvents MenuOK As ToolStripMenuItem
    Friend WithEvents MenuCancel As ToolStripMenuItem
    Friend WithEvents MenuAddNew As ToolStripMenuItem
    Friend WithEvents MenuEdit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_DelStaff As ToolStripMenuItem
    Friend WithEvents ListDepts As ListBox
    Friend WithEvents Panel1 As Panel
End Class
