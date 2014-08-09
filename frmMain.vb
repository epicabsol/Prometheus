Imports GlassForm.DWMBlurBehind
Imports System.Drawing.Drawing2D
#Const AeroEnabled = False
Public Class frmMain
    Public Const UseCoolMenu As Boolean = True
    Public FrameNumber As Long = 0
    Public FPS As Single = 24
    Public Length As Long = 500
    Public Project As PrometheusProject
    Private _displaysize As Size
    Public ReadOnly Property DisplaySize As Size
        Get
            Return _displaysize
        End Get
    End Property
    Private _currentdisplay As Bitmap
    Public Property CurrentDisplay As Bitmap
        Get
            Return _currentdisplay
        End Get
        Set(value As Bitmap)
            _currentdisplay = value
            _displaysize = value.Size
        End Set
    End Property
    Public Sub RefreshPreview()
        If IsNothing(CurrentDisplay) = False Then
            CurrentDisplay.Dispose()
        End If
        CurrentDisplay = Project.BuildFrame(FrameNumber)
        Invoke(Sub() DisplayControl1.Invalidate())
        Invoke(Sub() TrackerControl1.Invalidate())
        'DisplayControl1.Invalidate()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Playing Then StopPlaying()
        If IsNothing(PlayThread) = False Then
            Do While PlayThread.ThreadState = Threading.ThreadState.Running
                Application.DoEvents()
            Loop
        End If
        For Each sc As VideoSourceClip In Project.SourceVideoClips 'we need to flush the cache after the playthread stops adding to it.
            sc.FlushCache()
        Next
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#If AeroEnabled Then
        'Margins = New GlassForm.DWMMargins(27, 0, 0, 27)
        Margins = New GlassForm.DWMMargins(10000, 10000, 100000, 100000)
        Me.BlackenBorders = True
        'Height -= Margins.Bottom
        If DesignMode = True Then
            Size = New Size(675, 526)
        End If
        Xenon.XenonRenderer.ShadowsEnabled = False
#Else
        SplitContainer1.Left = 0
        SplitContainer1.Width = Me.Width - (Padding.Left + Padding.Right)
        DoubleBuffered = True
#End If
        If UseCoolMenu Then
            XenonMenu1.Hide()
        End If
        Project = New PrometheusProject
        Plugins.LoadPlugins()
        SplitContainer3.Panel2MinSize = My.Resources.TabSelected.Width * PalleteTabStrip1.Tabs.Count

        PalleteTabStrip1.SetTab(0)

        RefreshPreview()
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub
    Public MainButtonHover As Boolean = False

    Private Sub frmMain_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        MainButtonHover = False
        Invalidate()
    End Sub

    Private Sub frmMain_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim mousex As Integer = e.X - 32
        Dim mousey As Integer = e.Y - 32
        Dim old As Boolean = MainButtonHover
        MainButtonHover = BenMisc.HitTestCircle(22, mousex, mousey)
        If old <> MainButtonHover Then
#If AeroEnabled Then
            InvalidateNC()
#Else
            Invalidate()
#End If
        End If
    End Sub

#If AeroEnabled Then
    Private Sub frmMain_NonClientPaint(e As PaintEventArgs) Handles Me.NonClientPaint
#Else

    Private Sub frmMain_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        If UseCoolMenu Then
            If MainButtonHover Then
                frmMenu.Show()
                frmMenu.Location = PointToScreen(New Point(8, 40))
            End If
        End If
    End Sub
    Private Sub frmMain_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
#End If
        Dim g As Graphics = e.Graphics
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
#If AeroEnabled Then
        g.Clear(Color.Transparent)
#End If
        If MainButtonHover OrElse (UseCoolMenu = False) OrElse frmMenu.Visible = True Then
            g.DrawImage(My.Resources.Promethean_Button_Filled_x48, 8, 8, 48, 48)
        Else
            g.DrawImage(My.Resources.Promethean_Button_NoGlow_x48, 8, 8, 48, 48)
        End If
        Dim f As New Font(SystemFonts.CaptionFont.FontFamily.Name, 13)
        g.DrawString("Prometheus", f, Brushes.White, 63, 3)
        f.Dispose()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
#If AeroEnabled Then
        cmdRewind.Top = Height - cmdRewind.Height - 8
        cmdBackOneFrame.Top = Height - cmdBackOneFrame.Height - 8
        cmdPlay.Top = Height - cmdPlay.Height - 8
        cmdNextFrame.Top = Height - cmdNextFrame.Height - 8
        cmdEnd.Top = Height - cmdEnd.Height - 8
#Else
        cmdRewind.Top = ClientSize.Height - cmdRewind.Height - 8
        cmdBackOneFrame.Top = ClientSize.Height - cmdBackOneFrame.Height - 8
        cmdPlay.Top = ClientSize.Height - cmdPlay.Height - 8
        cmdNextFrame.Top = ClientSize.Height - cmdNextFrame.Height - 8
        cmdEnd.Top = ClientSize.Height - cmdEnd.Height - 8
#End If

    End Sub
#Region "Scrolling"
    Private Sub VScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles VScrollBar1.Scroll
        TrackerControl1.ViewYOffsetPixels = (VScrollBar1.Value / 3) * TrackerControl1.TrackHeight
        TrackerControl1.Invalidate()
    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        TrackerControl1.ViewXOffsetPercentage = HScrollBar1.Value / HScrollBar1.Maximum
        TrackerControl1.Invalidate()
    End Sub
#End Region 'Scrolling

#Region "Playing"
    Public PlayThread As Threading.Thread
    Public StopPlayThread As Boolean = False
    Public Playing As Boolean = False
    Public RealFPS As Single
    Public Watch As New Stopwatch
    Public Sub PlayThreadProc()
        Do While StopPlayThread = False
            Watch.Reset()
            Watch.Start()
            If FrameNumber < Length Then
                FrameNumber += 1
            ElseIf FrameNumber = Length Then
                FrameNumber = 0
            Else
                FrameNumber = 0
            End If
            RefreshPreview()
            Watch.Stop()
            RealFPS = 1000 / Watch.ElapsedMilliseconds
        Loop
    End Sub
    Private Sub cmdPlay_Click(sender As Object, e As EventArgs) Handles cmdPlay.Click
        If Playing = True Then
            StopPlaying()
        Else
            StartPlaying()
        End If
    End Sub
    Public Sub StartPlaying()
        cmdPlay.Image = My.Resources.player_stop
        cmdPlay.Invalidate()
        Playing = True
        If IsNothing(PlayThread) = False Then
            'playthread does not need to be disposed!!
        End If
        PlayThread = New Threading.Thread(AddressOf PlayThreadProc)
        StopPlayThread = False
        PlayThread.Start()
    End Sub
    Public Sub StopPlaying()
        cmdPlay.Image = My.Resources.player_play
        cmdPlay.Invalidate()
        Playing = False
        StopPlayThread = True
    End Sub

    Private Sub cmdNextFrame_Click(sender As Object, e As EventArgs) Handles cmdNextFrame.Click
        If FrameNumber < Length - 1 Then
            FrameNumber += 1
            Invalidate(True)
            RefreshPreview()
        End If
    End Sub

    Private Sub cmdEnd_Click(sender As Object, e As EventArgs) Handles cmdEnd.Click
        FrameNumber = Length - 1
        Invalidate(True)
        RefreshPreview()
    End Sub

    Private Sub cmdRewind_Click(sender As Object, e As EventArgs) Handles cmdRewind.Click
        FrameNumber = 0
        Invalidate(True)
        RefreshPreview()
    End Sub

    Private Sub cmdBackOneFrame_Click(sender As Object, e As EventArgs) Handles cmdBackOneFrame.Click
        If FrameNumber > 0 Then
            FrameNumber -= 1
            Invalidate(True)
            RefreshPreview()
        End If
    End Sub
#End Region 'Playing 

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub XenonTiler1_MouseDown(e As Xenon.TilerMouseEventArgs) Handles XenonTiler1.MouseDown

    End Sub

    Private Sub XenonTiler1_Resize(sender As Object, e As EventArgs) Handles XenonTiler1.Resize
        XenonTiler1.Invalidate()
    End Sub

    Private Sub XenonTiler1_TileMouseUp(tile As Xenon.XenonTile, button As MouseButtons) Handles XenonTiler1.TileMouseUp
        If (Stopwatch.GetTimestamp() - 500000) < (TilerLastClick) Then
            If XenonTiler1.Items.IndexOf(tile) > Project.SourceVideoClips.Count Then
                'it is sound

            Else
                'it is video
                Dim newclip As VideoClip = Project.SourceVideoClips(XenonTiler1.Items.IndexOf(tile)).MakeClip(FrameNumber)
                Project.VideoClips.Add(newclip)
                TrackerControl1.SelectedClip = newclip
            End If
            TrackerControl1.Invalidate()
        End If
        TilerLastClick = Stopwatch.GetTimestamp()

    End Sub
    Public TilerLastClick As Long

    Private Sub DisplayControl1_Resize(sender As Object, e As EventArgs) Handles DisplayControl1.Resize
        DisplayControl1.Invalidate()
    End Sub

    Private Sub PalleteTabStrip1_Resize(sender As Object, e As EventArgs) Handles PalleteTabStrip1.Resize
        PalleteTabStrip1.Invalidate()
    End Sub

    Private Sub SplitContainer3_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer3.SplitterMoved

    End Sub

    Private Sub XenonTiler1_MouseMove(e As Xenon.TilerMouseEventArgs) Handles XenonTiler1.MouseMove
        If MouseButtons = Windows.Forms.MouseButtons.Left Then
            Select Case PalleteTabStrip1.Tabs(PalleteTabStrip1.CurrentTabIndex).Text
                Case "Sources"
                    If XenonTiler1.Items.IndexOf(e.Tile) > Project.SourceVideoClips.Count Then
                        'it is sound

                    Else
                        'it is video
                        Dim newclip As VideoClip = Project.SourceVideoClips(XenonTiler1.Items.IndexOf(e.Tile)).MakeClip(FrameNumber)
                        DoDragDrop(newclip, DragDropEffects.Link)
                    End If

                Case "Modifiers"
                    Dim themod As IModifierSource = Plugins.Modifiers(XenonTiler1.Items.IndexOf(e.Tile))
                    DoDragDrop(themod, DragDropEffects.Link)
                Case "Generators"

            End Select
        End If
    End Sub

    Private Sub cmdAddSource_Click(sender As Object, e As EventArgs) Handles cmdAddSource.Click
        Dim browser As New OpenFileDialog
        browser.Filter = BuildSourceFilter()
        browser.InitialDirectory = Project.SourcePath
        browser.ShowDialog()
        If browser.FileName = "" Then Exit Sub
        Dim type As ResourceType = GetFileType(browser.FileName)
        Select Case type
            Case ResourceType.Video
                Dim newclip As New VideoSourceClip(browser.FileName)
                Project.SourceVideoClips.Add(newclip)
            Case ResourceType.Audio

            Case ResourceType.Modifier

            Case ResourceType.Generator

            Case -1
                MsgBox("No loaders available for that resource type. Sorry. =(" & vbNewLine & "(Hint: Get\Make a plugin for it!)")
        End Select
        Project.SourcePath = IO.Path.GetDirectoryName(browser.FileName)
        PalleteTabStrip1.SetTab(0)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        TrySave()
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        SaveAs()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Open()
    End Sub
#Region "Project IO"

    Public Sub SaveCopy()
        Dim oldsavepath As String = Project.SavePath
        SaveAs()
        Project.SavedYet = False
        Project.SavePath = oldsavepath
    End Sub
    Public Sub TrySave()
        If Project.SavedYet = False Then
            SaveAs()
        Else
            Save()
        End If
    End Sub
    Public Sub SaveAs()
        Dim browser As New SaveFileDialog
        browser.Filter = "Prometheus Project (*.pmp)|*.pmp"
        browser.ShowDialog()
        If browser.FileName <> "" Then
            Project.Save(browser.FileName)
        End If
    End Sub
    Public Sub Save()
        Project.Save(Project.SavePath)
    End Sub
    Public Sub IfSave()
        If Project.Dirty Or Project.SavedYet = False Then
            TrySave()
        End If
    End Sub
    Public Sub Open()
        If Project.Dirty Or Project.SavedYet = False Then

            Dim userchoice As DialogResult = frmYesNoCancel.ShowDialog("Save project before closing?", "Open Project")
            Select Case userchoice
                Case Windows.Forms.DialogResult.Yes
                    IfSave()
                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        Dim browser As New OpenFileDialog
        browser.Filter = "Prometheus Project (*.pmp)|*.pmp"
        browser.ShowDialog()
        If browser.FileName = "" Then Exit Sub
        Project = PrometheusProject.Load(browser.FileName)
        Project.Dirty = False
        Project.SavedYet = True
        PalleteTabStrip1.SetTab(0)
        RefreshPreview()
        Invalidate(True)
    End Sub
    Public Sub OpenCopy()
        Open()
        Project.SavedYet = False
        Project.SavePath = ""
    End Sub
    Public Sub OpenFromInternet()
        Throw New NotImplementedException("Opening from the internet has not been completed yet. =(")
    End Sub
    Public Sub NewProject()
        If Project.Dirty Or Project.SavedYet = False Then

            Dim userchoice As DialogResult = frmYesNoCancel.ShowDialog("Save project before closing?", "Open Project")
            Select Case userchoice
                Case Windows.Forms.DialogResult.Yes
                    IfSave()
                Case Windows.Forms.DialogResult.No

                Case Windows.Forms.DialogResult.Cancel
                    Exit Sub
            End Select
        End If
        Project = New PrometheusProject
        Project.SavedYet = False
        Project.Dirty = False
        PalleteTabStrip1.SetTab(0)
        RefreshPreview()
        Invalidate(True)
    End Sub
#End Region

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        NewProject()
    End Sub

    Private Sub RenderMovieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenderMovieToolStripMenuItem.Click
        frmRender.ShowDialog()
    End Sub
End Class
