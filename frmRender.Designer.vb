<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRender
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
        Me.cmdClose = New Xenon.XenonButton()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.cmdRender = New Xenon.XenonButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPath = New Xenon.XenonTextBox()
        Me.XenonButton3 = New Xenon.XenonButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWidth = New Xenon.XenonTextBox()
        Me.txtHeight = New Xenon.XenonTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdFormatOptions = New Xenon.XenonButton()
        Me.XenonProgressBar1 = New Xenon.XenonProgressBar()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.Disabled = True
        Me.cmdClose.Image = Nothing
        Me.cmdClose.LayeringHost = Nothing
        Me.cmdClose.Location = New System.Drawing.Point(103, 3)
        Me.cmdClose.MouseOver = False
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(94, 28)
        Me.cmdClose.TabIndex = 0
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdClose)
        Me.FlowLayoutPanel1.Controls.Add(Me.cmdRender)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(287, 63)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(200, 34)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'cmdRender
        '
        Me.cmdRender.Disabled = True
        Me.cmdRender.Image = Nothing
        Me.cmdRender.LayeringHost = Nothing
        Me.cmdRender.Location = New System.Drawing.Point(3, 3)
        Me.cmdRender.MouseOver = False
        Me.cmdRender.Name = "cmdRender"
        Me.cmdRender.Size = New System.Drawing.Size(94, 28)
        Me.cmdRender.TabIndex = 1
        Me.cmdRender.Text = "Render"
        Me.cmdRender.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Output Path"
        '
        'txtPath
        '
        Me.txtPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPath.Location = New System.Drawing.Point(82, 6)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(389, 20)
        Me.txtPath.TabIndex = 3
        '
        'XenonButton3
        '
        Me.XenonButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XenonButton3.Disabled = True
        Me.XenonButton3.Image = Nothing
        Me.XenonButton3.LayeringHost = Nothing
        Me.XenonButton3.Location = New System.Drawing.Point(469, 7)
        Me.XenonButton3.MouseOver = False
        Me.XenonButton3.Name = "XenonButton3"
        Me.XenonButton3.Size = New System.Drawing.Size(18, 18)
        Me.XenonButton3.TabIndex = 2
        Me.XenonButton3.Text = "..."
        Me.XenonButton3.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(82, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(305, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Format"
        '
        'txtWidth
        '
        Me.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWidth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtWidth.Location = New System.Drawing.Point(82, 59)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(65, 20)
        Me.txtWidth.TabIndex = 6
        '
        'txtHeight
        '
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHeight.Location = New System.Drawing.Point(179, 59)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(65, 20)
        Me.txtHeight.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(155, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "by"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(250, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Pixels"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Output Size"
        '
        'cmdFormatOptions
        '
        Me.cmdFormatOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFormatOptions.Disabled = True
        Me.cmdFormatOptions.Image = Nothing
        Me.cmdFormatOptions.LayeringHost = Nothing
        Me.cmdFormatOptions.Location = New System.Drawing.Point(393, 28)
        Me.cmdFormatOptions.MouseOver = False
        Me.cmdFormatOptions.Name = "cmdFormatOptions"
        Me.cmdFormatOptions.Size = New System.Drawing.Size(94, 29)
        Me.cmdFormatOptions.TabIndex = 2
        Me.cmdFormatOptions.Text = "Format Options..."
        Me.cmdFormatOptions.UseVisualStyleBackColor = True
        '
        'XenonProgressBar1
        '
        Me.XenonProgressBar1.Animate = True
        Me.XenonProgressBar1.AnimationRate = CType(10, Long)
        Me.XenonProgressBar1.AnimationSpeed = 5.0R
        Me.XenonProgressBar1.ColorDark = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.XenonProgressBar1.ColorLight = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.XenonProgressBar1.Location = New System.Drawing.Point(15, 85)
        Me.XenonProgressBar1.Max = CType(100, Long)
        Me.XenonProgressBar1.Name = "XenonProgressBar1"
        Me.XenonProgressBar1.Size = New System.Drawing.Size(266, 11)
        Me.XenonProgressBar1.TabIndex = 11
        Me.XenonProgressBar1.Text = "XenonProgressBar1"
        Me.XenonProgressBar1.Value = CType(0, Long)
        '
        'frmRender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(492, 102)
        Me.Controls.Add(Me.XenonProgressBar1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdFormatOptions)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.XenonButton3)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRender"
        Me.ShowIcon = False
        Me.Text = "Render Project"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdClose As Xenon.XenonButton
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmdRender As Xenon.XenonButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPath As Xenon.XenonTextBox
    Friend WithEvents XenonButton3 As Xenon.XenonButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As Xenon.XenonTextBox
    Friend WithEvents txtHeight As Xenon.XenonTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdFormatOptions As Xenon.XenonButton
    Friend WithEvents XenonProgressBar1 As Xenon.XenonProgressBar
End Class
