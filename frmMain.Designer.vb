#Const AeroForm = False
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
#If AeroForm Then
    Inherits GlassForm.GlassForm
#Else
    Inherits Form
#End If

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.XenonMenu1 = New Xenon.XenonMenu()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RenderMovieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.VScrollBar2 = New System.Windows.Forms.VScrollBar()
        Me.cmdAddSource = New Xenon.XenonButton()
        Me.XenonTiler1 = New Xenon.XenonTiler()
        Me.XenonToolStrip1 = New Xenon.XenonToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.VScrollBar1 = New System.Windows.Forms.VScrollBar()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.cmdEnd = New Xenon.XenonButton()
        Me.cmdNextFrame = New Xenon.XenonButton()
        Me.cmdPlay = New Xenon.XenonButton()
        Me.cmdBackOneFrame = New Xenon.XenonButton()
        Me.cmdRewind = New Xenon.XenonButton()
        Me.ModifierStackControl1 = New Prometheus.ModifierStackControl()
        Me.PalleteTabStrip1 = New Prometheus.PalleteTabStrip()
        Me.DisplayControl1 = New Prometheus.DisplayControl()
        Me.TrackerControl1 = New Prometheus.TrackerControl()
        Me.cmdREmoveModifier = New Xenon.XenonButton()
        Me.XenonMenu1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.XenonToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XenonMenu1
        '
        Me.XenonMenu1.Dock = System.Windows.Forms.DockStyle.None
        Me.XenonMenu1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.XenonMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ClipToolStripMenuItem, Me.RenderToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.XenonMenu1.Location = New System.Drawing.Point(63, 29)
        Me.XenonMenu1.Name = "XenonMenu1"
        Me.XenonMenu1.Size = New System.Drawing.Size(228, 24)
        Me.XenonMenu1.TabIndex = 5
        Me.XenonMenu1.Text = "XenonMenu1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.ToolStripMenuItem2, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SaveAsToolStripMenuItem.Text = "Save As..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(120, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(120, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ClipToolStripMenuItem
        '
        Me.ClipToolStripMenuItem.Name = "ClipToolStripMenuItem"
        Me.ClipToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.ClipToolStripMenuItem.Text = "Clip"
        '
        'RenderToolStripMenuItem
        '
        Me.RenderToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RenderMovieToolStripMenuItem})
        Me.RenderToolStripMenuItem.Name = "RenderToolStripMenuItem"
        Me.RenderToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.RenderToolStripMenuItem.Text = "Render"
        '
        'RenderMovieToolStripMenuItem
        '
        Me.RenderMovieToolStripMenuItem.Name = "RenderMovieToolStripMenuItem"
        Me.RenderMovieToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.RenderMovieToolStripMenuItem.Text = "Render Movie..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.ToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(108, 22)
        Me.HelpToolStripMenuItem1.Text = "Help..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(105, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(108, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(8, 58)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.XenonToolStrip1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.VScrollBar1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.HScrollBar1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TrackerControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(904, 364)
        Me.SplitContainer1.SplitterDistance = 211
        Me.SplitContainer1.TabIndex = 6
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer2.BackColor = System.Drawing.Color.Black
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer2.Panel2.Controls.Add(Me.DisplayControl1)
        Me.SplitContainer2.Size = New System.Drawing.Size(912, 211)
        Me.SplitContainer2.SplitterDistance = 594
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.cmdREmoveModifier)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ModifierStackControl1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.SplitContainer3.Panel2.Controls.Add(Me.VScrollBar2)
        Me.SplitContainer3.Panel2.Controls.Add(Me.cmdAddSource)
        Me.SplitContainer3.Panel2.Controls.Add(Me.PalleteTabStrip1)
        Me.SplitContainer3.Panel2.Controls.Add(Me.XenonTiler1)
        Me.SplitContainer3.Size = New System.Drawing.Size(594, 211)
        Me.SplitContainer3.SplitterDistance = 130
        Me.SplitContainer3.TabIndex = 1
        '
        'VScrollBar2
        '
        Me.VScrollBar2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar2.Location = New System.Drawing.Point(443, 35)
        Me.VScrollBar2.Name = "VScrollBar2"
        Me.VScrollBar2.Size = New System.Drawing.Size(17, 176)
        Me.VScrollBar2.TabIndex = 3
        '
        'cmdAddSource
        '
        Me.cmdAddSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddSource.Disabled = True
        Me.cmdAddSource.Image = Nothing
        Me.cmdAddSource.LayeringHost = Nothing
        Me.cmdAddSource.Location = New System.Drawing.Point(360, 189)
        Me.cmdAddSource.MouseOver = False
        Me.cmdAddSource.Name = "cmdAddSource"
        Me.cmdAddSource.Size = New System.Drawing.Size(80, 19)
        Me.cmdAddSource.TabIndex = 2
        Me.cmdAddSource.Text = "Add Source..."
        Me.cmdAddSource.UseVisualStyleBackColor = False
        '
        'XenonTiler1
        '
        Me.XenonTiler1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XenonTiler1.BackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.XenonTiler1.Location = New System.Drawing.Point(-1, 39)
        Me.XenonTiler1.MultiSelect = False
        Me.XenonTiler1.Name = "XenonTiler1"
        Me.XenonTiler1.Selection = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.XenonTiler1.SelectionBorder = System.Drawing.Color.Green
        Me.XenonTiler1.Size = New System.Drawing.Size(444, 171)
        Me.XenonTiler1.TabIndex = 1
        Me.XenonTiler1.Text = "XenonTiler1"
        Me.XenonTiler1.TextColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.XenonTiler1.TilePadding = CType(5, Long)
        Me.XenonTiler1.TileSize = New System.Drawing.Size(64, 64)
        Me.XenonTiler1.ViewOffset = CType(0, Long)
        '
        'XenonToolStrip1
        '
        Me.XenonToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.XenonToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.XenonToolStrip1.Name = "XenonToolStrip1"
        Me.XenonToolStrip1.Size = New System.Drawing.Size(904, 25)
        Me.XenonToolStrip1.TabIndex = 3
        Me.XenonToolStrip1.Text = "XenonToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton4.Image = Global.Prometheus.My.Resources.Resources.cog
        Me.ToolStripButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(104, 22)
        Me.ToolStripButton4.Text = "Clip Properties"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'VScrollBar1
        '
        Me.VScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VScrollBar1.LargeChange = 5
        Me.VScrollBar1.Location = New System.Drawing.Point(887, 23)
        Me.VScrollBar1.Maximum = 40
        Me.VScrollBar1.Name = "VScrollBar1"
        Me.VScrollBar1.Size = New System.Drawing.Size(17, 109)
        Me.VScrollBar1.SmallChange = 5
        Me.VScrollBar1.TabIndex = 2
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HScrollBar1.Location = New System.Drawing.Point(0, 132)
        Me.HScrollBar1.Maximum = 1000
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(887, 17)
        Me.HScrollBar1.TabIndex = 1
        '
        'cmdEnd
        '
        Me.cmdEnd.Disabled = True
        Me.cmdEnd.Image = Global.Prometheus.My.Resources.Resources.player_last
        Me.cmdEnd.LayeringHost = Nothing
        Me.cmdEnd.Location = New System.Drawing.Point(120, 429)
        Me.cmdEnd.MouseOver = False
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.Size = New System.Drawing.Size(22, 22)
        Me.cmdEnd.TabIndex = 4
        Me.cmdEnd.UseVisualStyleBackColor = True
        '
        'cmdNextFrame
        '
        Me.cmdNextFrame.Disabled = True
        Me.cmdNextFrame.Image = Global.Prometheus.My.Resources.Resources.player_next
        Me.cmdNextFrame.LayeringHost = Nothing
        Me.cmdNextFrame.Location = New System.Drawing.Point(92, 429)
        Me.cmdNextFrame.MouseOver = False
        Me.cmdNextFrame.Name = "cmdNextFrame"
        Me.cmdNextFrame.Size = New System.Drawing.Size(22, 22)
        Me.cmdNextFrame.TabIndex = 3
        Me.cmdNextFrame.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Disabled = True
        Me.cmdPlay.Image = Global.Prometheus.My.Resources.Resources.player_play
        Me.cmdPlay.LayeringHost = Nothing
        Me.cmdPlay.Location = New System.Drawing.Point(64, 429)
        Me.cmdPlay.MouseOver = False
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(22, 22)
        Me.cmdPlay.TabIndex = 2
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdBackOneFrame
        '
        Me.cmdBackOneFrame.Disabled = True
        Me.cmdBackOneFrame.Image = Global.Prometheus.My.Resources.Resources.player_precious
        Me.cmdBackOneFrame.LayeringHost = Nothing
        Me.cmdBackOneFrame.Location = New System.Drawing.Point(36, 429)
        Me.cmdBackOneFrame.MouseOver = False
        Me.cmdBackOneFrame.Name = "cmdBackOneFrame"
        Me.cmdBackOneFrame.Size = New System.Drawing.Size(22, 22)
        Me.cmdBackOneFrame.TabIndex = 1
        Me.cmdBackOneFrame.UseVisualStyleBackColor = True
        '
        'cmdRewind
        '
        Me.cmdRewind.Disabled = True
        Me.cmdRewind.Image = Global.Prometheus.My.Resources.Resources.player_first
        Me.cmdRewind.LayeringHost = Nothing
        Me.cmdRewind.Location = New System.Drawing.Point(8, 429)
        Me.cmdRewind.MouseOver = False
        Me.cmdRewind.Name = "cmdRewind"
        Me.cmdRewind.Size = New System.Drawing.Size(22, 22)
        Me.cmdRewind.TabIndex = 0
        Me.cmdRewind.UseVisualStyleBackColor = True
        '
        'ModifierStackControl1
        '
        Me.ModifierStackControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ModifierStackControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ModifierStackControl1.ItemHeight = 22
        Me.ModifierStackControl1.Location = New System.Drawing.Point(0, 0)
        Me.ModifierStackControl1.Name = "ModifierStackControl1"
        Me.ModifierStackControl1.ScrollOffsetPercent = 0.0!
        Me.ModifierStackControl1.Size = New System.Drawing.Size(130, 211)
        Me.ModifierStackControl1.TabIndex = 7
        Me.ModifierStackControl1.Text = "ModifierStackControl1"
        '
        'PalleteTabStrip1
        '
        Me.PalleteTabStrip1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PalleteTabStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.PalleteTabStrip1.Location = New System.Drawing.Point(0, 0)
        Me.PalleteTabStrip1.Name = "PalleteTabStrip1"
        Me.PalleteTabStrip1.Size = New System.Drawing.Size(460, 35)
        Me.PalleteTabStrip1.TabIndex = 0
        Me.PalleteTabStrip1.Text = "PalleteTabStrip1"
        '
        'DisplayControl1
        '
        Me.DisplayControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.DisplayControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DisplayControl1.ForeColor = System.Drawing.Color.Magenta
        Me.DisplayControl1.Location = New System.Drawing.Point(0, 0)
        Me.DisplayControl1.Name = "DisplayControl1"
        Me.DisplayControl1.Size = New System.Drawing.Size(314, 211)
        Me.DisplayControl1.TabIndex = 0
        Me.DisplayControl1.Text = "DisplayControl1"
        '
        'TrackerControl1
        '
        Me.TrackerControl1.AllowDrop = True
        Me.TrackerControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackerControl1.FrameEmphasisInterval = 6
        Me.TrackerControl1.Location = New System.Drawing.Point(0, 24)
        Me.TrackerControl1.Name = "TrackerControl1"
        Me.TrackerControl1.Size = New System.Drawing.Size(886, 107)
        Me.TrackerControl1.TabIndex = 0
        Me.TrackerControl1.Text = "TrackerControl1"
        Me.TrackerControl1.TrackHeight = 50.0!
        Me.TrackerControl1.ViewXOffsetPercentage = 0.0R
        Me.TrackerControl1.ViewYOffsetPixels = 0
        '
        'cmdREmoveModifier
        '
        Me.cmdREmoveModifier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdREmoveModifier.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.cmdREmoveModifier.Disabled = False
        Me.cmdREmoveModifier.Image = Nothing
        Me.cmdREmoveModifier.LayeringHost = Nothing
        Me.cmdREmoveModifier.Location = New System.Drawing.Point(72, 189)
        Me.cmdREmoveModifier.MouseOver = False
        Me.cmdREmoveModifier.Name = "cmdREmoveModifier"
        Me.cmdREmoveModifier.Size = New System.Drawing.Size(55, 19)
        Me.cmdREmoveModifier.TabIndex = 7
        Me.cmdREmoveModifier.Text = "Remove"
        Me.cmdREmoveModifier.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(923, 458)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cmdEnd)
        Me.Controls.Add(Me.cmdNextFrame)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.cmdBackOneFrame)
        Me.Controls.Add(Me.cmdRewind)
        Me.Controls.Add(Me.XenonMenu1)
        Me.MainMenuStrip = Me.XenonMenu1
        Me.Name = "frmMain"
        Me.Padding = New System.Windows.Forms.Padding(8, 31, 8, 8)
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.XenonMenu1.ResumeLayout(False)
        Me.XenonMenu1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.XenonToolStrip1.ResumeLayout(False)
        Me.XenonToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdRewind As Xenon.XenonButton
    Friend WithEvents cmdBackOneFrame As Xenon.XenonButton
    Friend WithEvents cmdPlay As Xenon.XenonButton
    Friend WithEvents cmdNextFrame As Xenon.XenonButton
    Friend WithEvents cmdEnd As Xenon.XenonButton
    Friend WithEvents XenonMenu1 As Xenon.XenonMenu
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClipToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RenderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TrackerControl1 As Prometheus.TrackerControl
    Friend WithEvents VScrollBar1 As System.Windows.Forms.VScrollBar
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents XenonToolStrip1 As Xenon.XenonToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DisplayControl1 As Prometheus.DisplayControl
    Friend WithEvents PalleteTabStrip1 As Prometheus.PalleteTabStrip
    Friend WithEvents XenonTiler1 As Xenon.XenonTiler
    Friend WithEvents cmdAddSource As Xenon.XenonButton
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents VScrollBar2 As System.Windows.Forms.VScrollBar
    Friend WithEvents RenderMovieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifierStackControl1 As Prometheus.ModifierStackControl
    Friend WithEvents cmdREmoveModifier As Xenon.XenonButton

End Class
