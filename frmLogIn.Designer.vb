﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class frmLogIn
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
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogIn))
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUser = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBuildInfo = New System.Windows.Forms.Label()
        Me.lblNewVersion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.PasswordTextBox.Location = New System.Drawing.Point(55, 212)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(45)
        Me.PasswordTextBox.Size = New System.Drawing.Size(231, 25)
        Me.PasswordTextBox.TabIndex = 0
        Me.PasswordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Copperplate Gothic Light", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(8, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(328, 69)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "NexTerm"
        '
        'cboUser
        '
        Me.cboUser.BackColor = System.Drawing.Color.White
        Me.cboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUser.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cboUser.FormattingEnabled = True
        Me.cboUser.Location = New System.Drawing.Point(55, 164)
        Me.cboUser.Name = "cboUser"
        Me.cboUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cboUser.Size = New System.Drawing.Size(231, 25)
        Me.cboUser.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label4.ForeColor = System.Drawing.Color.Goldenrod
        Me.Label4.Location = New System.Drawing.Point(154, 398)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(32, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "خروج"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label5.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label5.Location = New System.Drawing.Point(146, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(53, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "نکسترم"
        '
        'lblBuildInfo
        '
        Me.lblBuildInfo.AutoSize = True
        Me.lblBuildInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblBuildInfo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblBuildInfo.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.lblBuildInfo.Location = New System.Drawing.Point(130, 355)
        Me.lblBuildInfo.Name = "lblBuildInfo"
        Me.lblBuildInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblBuildInfo.Size = New System.Drawing.Size(84, 13)
        Me.lblBuildInfo.TabIndex = 9
        Me.lblBuildInfo.Text = "Build 14010402"
        Me.lblBuildInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNewVersion
        '
        Me.lblNewVersion.AutoSize = True
        Me.lblNewVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblNewVersion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblNewVersion.ForeColor = System.Drawing.Color.IndianRed
        Me.lblNewVersion.Location = New System.Drawing.Point(90, 370)
        Me.lblNewVersion.Name = "lblNewVersion"
        Me.lblNewVersion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblNewVersion.Size = New System.Drawing.Size(163, 19)
        Me.lblNewVersion.TabIndex = 10
        Me.lblNewVersion.Text = "newer version is available"
        Me.lblNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Navy
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(344, 433)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblNewVersion)
        Me.Controls.Add(Me.lblBuildInfo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboUser)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.Controls.Add(Me.Label2)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogIn"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NexTerm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents cboUser As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblBuildInfo As Label
    Friend WithEvents lblNewVersion As Label
End Class
