<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GridSettings = New System.Windows.Forms.DataGridView()
        CType(Me.GridSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(182, 184)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(162, 25)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "بازگشت"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'GridSettings
        '
        Me.GridSettings.AllowUserToAddRows = False
        Me.GridSettings.AllowUserToDeleteRows = False
        Me.GridSettings.AllowUserToOrderColumns = True
        Me.GridSettings.AllowUserToResizeColumns = False
        Me.GridSettings.AllowUserToResizeRows = False
        Me.GridSettings.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridSettings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridSettings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridSettings.Location = New System.Drawing.Point(0, 0)
        Me.GridSettings.Name = "GridSettings"
        Me.GridSettings.RowHeadersVisible = False
        Me.GridSettings.RowTemplate.Height = 25
        Me.GridSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GridSettings.Size = New System.Drawing.Size(532, 175)
        Me.GridSettings.TabIndex = 12
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(532, 214)
        Me.ControlBox = False
        Me.Controls.Add(Me.GridSettings)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Settings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تنظيمات"
        CType(Me.GridSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents GridSettings As DataGridView
End Class
