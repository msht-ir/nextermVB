<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseBioProg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChooseBioProg))
        Me.ListBioProg = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuOK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuAddNewProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuEditThisProg = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListDepts = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBioProg
        '
        Me.ListBioProg.BackColor = System.Drawing.SystemColors.Control
        Me.ListBioProg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBioProg.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListBioProg.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListBioProg.FormattingEnabled = True
        Me.ListBioProg.ItemHeight = 17
        Me.ListBioProg.Location = New System.Drawing.Point(0, 0)
        Me.ListBioProg.Name = "ListBioProg"
        Me.ListBioProg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListBioProg.Size = New System.Drawing.Size(267, 312)
        Me.ListBioProg.TabIndex = 8
        Me.ListBioProg.Tag = "انتخاب دوره آموزشي"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOK, Me.ToolStripMenuItem1, Me.MenuAddNewProg, Me.MenuEditThisProg, Me.ToolStripMenuItem2, Me.MenuCancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 104)
        '
        'MenuOK
        '
        Me.MenuOK.Name = "MenuOK"
        Me.MenuOK.Size = New System.Drawing.Size(158, 22)
        Me.MenuOK.Text = "تاييد / انتخاب"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(155, 6)
        '
        'MenuAddNewProg
        '
        Me.MenuAddNewProg.Name = "MenuAddNewProg"
        Me.MenuAddNewProg.Size = New System.Drawing.Size(158, 22)
        Me.MenuAddNewProg.Text = "افزودن دوره جديد"
        '
        'MenuEditThisProg
        '
        Me.MenuEditThisProg.Name = "MenuEditThisProg"
        Me.MenuEditThisProg.Size = New System.Drawing.Size(158, 22)
        Me.MenuEditThisProg.Text = "ويرايش"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(155, 6)
        '
        'MenuCancel
        '
        Me.MenuCancel.ForeColor = System.Drawing.Color.IndianRed
        Me.MenuCancel.Name = "MenuCancel"
        Me.MenuCancel.Size = New System.Drawing.Size(158, 22)
        Me.MenuCancel.Text = "انصراف / خروج"
        '
        'ListDepts
        '
        Me.ListDepts.BackColor = System.Drawing.SystemColors.Control
        Me.ListDepts.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListDepts.Dock = System.Windows.Forms.DockStyle.Right
        Me.ListDepts.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListDepts.FormattingEnabled = True
        Me.ListDepts.ItemHeight = 17
        Me.ListDepts.Location = New System.Drawing.Point(273, 0)
        Me.ListDepts.Name = "ListDepts"
        Me.ListDepts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListDepts.Size = New System.Drawing.Size(258, 312)
        Me.ListDepts.TabIndex = 9
        Me.ListDepts.Tag = "انتخاب گروه آموزشي"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListBioProg)
        Me.Panel1.Controls.Add(Me.ListDepts)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(531, 312)
        Me.Panel1.TabIndex = 10
        '
        'ChooseBioProg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(531, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChooseBioProg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "دوره آموزشي"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBioProg As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MenuOK As ToolStripMenuItem
    Friend WithEvents MenuAddNewProg As ToolStripMenuItem
    Friend WithEvents MenuCancel As ToolStripMenuItem
    Friend WithEvents MenuEditThisProg As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ListDepts As ListBox
    Friend WithEvents Panel1 As Panel
End Class
