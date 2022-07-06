<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseCourse
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChooseCourse))
        Me.ComboBioProg = New System.Windows.Forms.ComboBox()
        Me.GridCourse = New System.Windows.Forms.DataGridView()
        Me.ContextMenuCourses = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuOK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuAddCourse = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuCancel = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.GridCourse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuCourses.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBioProg
        '
        Me.ComboBioProg.Dock = System.Windows.Forms.DockStyle.Top
        Me.ComboBioProg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBioProg.FormattingEnabled = True
        Me.ComboBioProg.Location = New System.Drawing.Point(0, 0)
        Me.ComboBioProg.Name = "ComboBioProg"
        Me.ComboBioProg.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBioProg.Size = New System.Drawing.Size(392, 23)
        Me.ComboBioProg.TabIndex = 5
        '
        'GridCourse
        '
        Me.GridCourse.AllowUserToAddRows = False
        Me.GridCourse.AllowUserToDeleteRows = False
        Me.GridCourse.AllowUserToResizeColumns = False
        Me.GridCourse.AllowUserToResizeRows = False
        Me.GridCourse.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.GridCourse.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCourse.ContextMenuStrip = Me.ContextMenuCourses
        Me.GridCourse.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridCourse.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridCourse.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GridCourse.Location = New System.Drawing.Point(0, 23)
        Me.GridCourse.Name = "GridCourse"
        Me.GridCourse.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GridCourse.RowHeadersVisible = False
        Me.GridCourse.RowTemplate.Height = 25
        Me.GridCourse.Size = New System.Drawing.Size(392, 520)
        Me.GridCourse.TabIndex = 8
        '
        'ContextMenuCourses
        '
        Me.ContextMenuCourses.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuOK, Me.ToolStripMenuItem2, Me.MenuAddCourse, Me.Menu_Edit, Me.ToolStripMenuItem1, Me.MenuCancel})
        Me.ContextMenuCourses.Name = "ContextMenuStrip1"
        Me.ContextMenuCourses.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuCourses.Size = New System.Drawing.Size(148, 104)
        '
        'MenuOK
        '
        Me.MenuOK.Name = "MenuOK"
        Me.MenuOK.Size = New System.Drawing.Size(147, 22)
        Me.MenuOK.Text = "انتخاب / تاييد"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(144, 6)
        '
        'MenuAddCourse
        '
        Me.MenuAddCourse.Name = "MenuAddCourse"
        Me.MenuAddCourse.Size = New System.Drawing.Size(147, 22)
        Me.MenuAddCourse.Text = "افزودن"
        '
        'Menu_Edit
        '
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Edit.Text = "ويرايش"
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
        Me.MenuCancel.Text = "خروج / انصراف"
        '
        'ChooseCourse
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.ClientSize = New System.Drawing.Size(392, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridCourse)
        Me.Controls.Add(Me.ComboBioProg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChooseCourse"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "انتخاب درس"
        CType(Me.GridCourse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuCourses.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBioProg As ComboBox
    Friend WithEvents GridCourse As DataGridView
    Friend WithEvents ContextMenuCourses As ContextMenuStrip
    Friend WithEvents MenuOK As ToolStripMenuItem
    Friend WithEvents MenuCancel As ToolStripMenuItem
    Friend WithEvents MenuAddCourse As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Edit As ToolStripMenuItem
End Class
