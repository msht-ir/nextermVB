﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportSettings
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
        Me.Menu_OK = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Menu_Cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadioDaysInCols = New System.Windows.Forms.RadioButton()
        Me.RadioDaysInRows = New System.Windows.Forms.RadioButton()
        Me.CheckBoxDetails = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckBoxRememberSettings = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_OK, Me.ToolStripMenuItem1, Me.Menu_Cancel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 54)
        '
        'Menu_OK
        '
        Me.Menu_OK.Name = "Menu_OK"
        Me.Menu_OK.Size = New System.Drawing.Size(147, 22)
        Me.Menu_OK.Text = "تاييد / ادامه"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(144, 6)
        '
        'Menu_Cancel
        '
        Me.Menu_Cancel.ForeColor = System.Drawing.Color.IndianRed
        Me.Menu_Cancel.Name = "Menu_Cancel"
        Me.Menu_Cancel.Size = New System.Drawing.Size(147, 22)
        Me.Menu_Cancel.Text = "انصراف / خروج"
        '
        'RadioDaysInCols
        '
        Me.RadioDaysInCols.AutoSize = True
        Me.RadioDaysInCols.Checked = True
        Me.RadioDaysInCols.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioDaysInCols.Location = New System.Drawing.Point(244, 23)
        Me.RadioDaysInCols.Name = "RadioDaysInCols"
        Me.RadioDaysInCols.Size = New System.Drawing.Size(131, 19)
        Me.RadioDaysInCols.TabIndex = 1
        Me.RadioDaysInCols.TabStop = True
        Me.RadioDaysInCols.Text = "روزهاي هفته در ستون"
        Me.RadioDaysInCols.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioDaysInCols.UseVisualStyleBackColor = True
        '
        'RadioDaysInRows
        '
        Me.RadioDaysInRows.AutoSize = True
        Me.RadioDaysInRows.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.RadioDaysInRows.Location = New System.Drawing.Point(247, 48)
        Me.RadioDaysInRows.Name = "RadioDaysInRows"
        Me.RadioDaysInRows.Size = New System.Drawing.Size(128, 19)
        Me.RadioDaysInRows.TabIndex = 2
        Me.RadioDaysInRows.Text = "روزهاي هفته در سطر"
        Me.RadioDaysInRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioDaysInRows.UseVisualStyleBackColor = True
        '
        'CheckBoxDetails
        '
        Me.CheckBoxDetails.AutoSize = True
        Me.CheckBoxDetails.Checked = True
        Me.CheckBoxDetails.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxDetails.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxDetails.Location = New System.Drawing.Point(272, 84)
        Me.CheckBoxDetails.Name = "CheckBoxDetails"
        Me.CheckBoxDetails.Size = New System.Drawing.Size(103, 19)
        Me.CheckBoxDetails.TabIndex = 3
        Me.CheckBoxDetails.Text = "گزارش با جزئيات"
        Me.CheckBoxDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxDetails.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.CheckBoxRememberSettings)
        Me.Panel1.Controls.Add(Me.RadioDaysInCols)
        Me.Panel1.Controls.Add(Me.RadioDaysInRows)
        Me.Panel1.Controls.Add(Me.CheckBoxDetails)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 132)
        Me.Panel1.TabIndex = 4
        '
        'CheckBoxRememberSettings
        '
        Me.CheckBoxRememberSettings.AutoSize = True
        Me.CheckBoxRememberSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.CheckBoxRememberSettings.Location = New System.Drawing.Point(27, 24)
        Me.CheckBoxRememberSettings.Name = "CheckBoxRememberSettings"
        Me.CheckBoxRememberSettings.Size = New System.Drawing.Size(149, 19)
        Me.CheckBoxRememberSettings.TabIndex = 4
        Me.CheckBoxRememberSettings.Text = "تنظيمات را به خاطر بسپار"
        Me.CheckBoxRememberSettings.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBoxRememberSettings.UseVisualStyleBackColor = True
        '
        'frmReportSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(418, 164)
        Me.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportSettings"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تنظيمات گزارش"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Menu_OK As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents Menu_Cancel As ToolStripMenuItem
    Friend WithEvents RadioDaysInCols As RadioButton
    Friend WithEvents RadioDaysInRows As RadioButton
    Friend WithEvents CheckBoxDetails As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CheckBoxRememberSettings As CheckBox
End Class
