<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCNN
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCNN))
        Me.GridCNN = New System.Windows.Forms.DataGridView()
        Me.MenuStripCNN = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_SelectBE = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_AddCNN = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_FindDB = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Guide = New System.Windows.Forms.ToolStripMenuItem()
        Me.Menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.GridCNN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStripCNN.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridCNN
        '
        Me.GridCNN.AllowUserToAddRows = False
        Me.GridCNN.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridCNN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCNN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridCNN.ContextMenuStrip = Me.MenuStripCNN
        Me.GridCNN.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridCNN.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridCNN.GridColor = System.Drawing.Color.Lavender
        Me.GridCNN.Location = New System.Drawing.Point(0, 0)
        Me.GridCNN.MultiSelect = False
        Me.GridCNN.Name = "GridCNN"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridCNN.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridCNN.RowHeadersWidth = 20
        Me.GridCNN.RowTemplate.Height = 25
        Me.GridCNN.Size = New System.Drawing.Size(864, 177)
        Me.GridCNN.TabIndex = 3
        '
        'MenuStripCNN
        '
        Me.MenuStripCNN.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_SelectBE, Me.ToolStripMenuItem2, Me.Menu_AddCNN, Me.Menu_Edit, Me.Menu_FindDB, Me.ToolStripMenuItem1, Me.Menu_Guide, Me.ToolStripMenuItem3, Me.Menu_Exit})
        Me.MenuStripCNN.Name = "MenuStripCNN"
        Me.MenuStripCNN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.MenuStripCNN.Size = New System.Drawing.Size(181, 176)
        '
        'Menu_SelectBE
        '
        Me.Menu_SelectBE.Name = "Menu_SelectBE"
        Me.Menu_SelectBE.Size = New System.Drawing.Size(180, 22)
        Me.Menu_SelectBE.Text = "تاييد / ادامه ..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_AddCNN
        '
        Me.Menu_AddCNN.Name = "Menu_AddCNN"
        Me.Menu_AddCNN.Size = New System.Drawing.Size(180, 22)
        Me.Menu_AddCNN.Text = "افزودن"
        '
        'Menu_Edit
        '
        Me.Menu_Edit.Name = "Menu_Edit"
        Me.Menu_Edit.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Edit.Text = "ويرايش"
        '
        'Menu_FindDB
        '
        Me.Menu_FindDB.Name = "Menu_FindDB"
        Me.Menu_FindDB.Size = New System.Drawing.Size(180, 22)
        Me.Menu_FindDB.Text = "جستجو ..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(177, 6)
        '
        'Menu_Guide
        '
        Me.Menu_Guide.Name = "Menu_Guide"
        Me.Menu_Guide.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Guide.Text = "راهنما"
        '
        'Menu_Exit
        '
        Me.Menu_Exit.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Exit.Name = "Menu_Exit"
        Me.Menu_Exit.Size = New System.Drawing.Size(180, 22)
        Me.Menu_Exit.Text = "خروج از نکسترم"
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.SystemColors.Control
        Me.btn1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btn1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btn1.Location = New System.Drawing.Point(364, 183)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(137, 23)
        Me.btn1.TabIndex = 41
        Me.btn1.Text = "خروج"
        Me.btn1.UseVisualStyleBackColor = False
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(177, 6)
        '
        'frmCNN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Goldenrod
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(864, 211)
        Me.ContextMenuStrip = Me.MenuStripCNN
        Me.ControlBox = False
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.GridCNN)
        Me.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCNN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NexTerm   |   Build 14010231"
        CType(Me.GridCNN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStripCNN.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridCNN As DataGridView
    Friend WithEvents MenuStripCNN As ContextMenuStrip
    Friend WithEvents Menu_SelectBE As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents Menu_FindDB As ToolStripMenuItem
    Friend WithEvents Menu_AddCNN As ToolStripMenuItem
    Friend WithEvents btn1 As Button
    Friend WithEvents Menu_Edit As ToolStripMenuItem
    Friend WithEvents راهنماToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Menu_Guide As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
