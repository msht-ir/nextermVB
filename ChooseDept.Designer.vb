<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseDept
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
        Me.ListDepts = New System.Windows.Forms.ListBox()
        Me.ContextMenu_Depts = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuOK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Depts.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListDepts
        '
        Me.ListDepts.BackColor = System.Drawing.SystemColors.Control
        Me.ListDepts.ContextMenuStrip = Me.ContextMenu_Depts
        Me.ListDepts.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListDepts.FormattingEnabled = True
        Me.ListDepts.ItemHeight = 17
        Me.ListDepts.Location = New System.Drawing.Point(8, 8)
        Me.ListDepts.Name = "ListDepts"
        Me.ListDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListDepts.Size = New System.Drawing.Size(305, 395)
        Me.ListDepts.TabIndex = 9
        '
        'ContextMenu_Depts
        '
        Me.ContextMenu_Depts.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOK, Me.ToolStripMenuItem1, Me.MenuCancel})
        Me.ContextMenu_Depts.Name = "ContextMenuStrip1"
        Me.ContextMenu_Depts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenu_Depts.Size = New System.Drawing.Size(148, 54)
        '
        'MenuOK
        '
        Me.MenuOK.Name = "MenuOK"
        Me.MenuOK.Size = New System.Drawing.Size(147, 22)
        Me.MenuOK.Text = "انتخاب / تاييد"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(144, 6)
        '
        'MenuCancel
        '
        Me.MenuCancel.Name = "MenuCancel"
        Me.MenuCancel.Size = New System.Drawing.Size(147, 22)
        Me.MenuCancel.Text = "انصراف / خروج"
        '
        'ChooseDept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(319, 439)
        Me.ControlBox = False
        Me.Controls.Add(Me.ListDepts)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChooseDept"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "گروه آموزشي"
        Me.ContextMenu_Depts.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListDepts As ListBox
    Friend WithEvents ContextMenu_Depts As ContextMenuStrip
    Friend WithEvents MenuOK As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents MenuCancel As ToolStripMenuItem
End Class
