#Const DoubleBuffered = True
Public Class TrackerControl
    Inherits Control
    Public Const TimeBoxHeight As Integer = 12
    Public Shadows ReadOnly Property CanFocus() As Boolean
        Get
            Return True
        End Get
    End Property
    Public Sub New()
        DoubleBuffered = True
        AllowDrop = True
    End Sub
    Public Property TrackHeight As Single = 50
    Public Property ViewXOffsetPercentage As Double = 0
    Public ReadOnly Property ViewXOffsetPixels As Single
        Get
            If WidthPixels <= Width Then Return 0
            Return (WidthPixels - Width) * ViewXOffsetPercentage
        End Get
    End Property
    Public Property ViewYOffsetPixels As Integer
    'Public ReadOnly Property ViewYOffsetPixels As Single
    '    Get
    '        If HeightPixels <= Height Then Return 0
    '        Return (HeightPixels - Height) * ViewYOffsetPercentage
    '    End Get
    'End Property
    Public Shadows Scale As Double = 5
    Public ReadOnly Property WidthPixels As Integer
        Get
            Return frmMain.Length * Scale
        End Get
    End Property
    Public ReadOnly Property HeightPixels As Integer
        Get
            Return TrackCount * TrackHeight
        End Get
    End Property
    Public Function ClipShown(clip As Clip) As Boolean
        Return Not (clip.StartFrame > LastFrameShown AndAlso clip.EndFrame < FirstFrameShown)
    End Function
    Public ReadOnly Property FirstFrameShown As Long
        Get
            Return (frmMain.Length - PixelsToFrames(Width)) * ViewXOffsetPercentage
        End Get
    End Property
    Public ReadOnly Property LastFrameShown As Long
        Get
            Return FirstFrameShown + PixelsToFrames(Width)
        End Get
    End Property
    Public Function FramesToPixels(Frames As Long) As Single
        Return Frames * Scale
    End Function
    Public Function PixelsToFrames(Pixels As Single) As Long
        Return Pixels / Scale
    End Function
    ''' <summary>
    ''' Gets the x of the given frame inside the scroll-compensated viewport.
    ''' </summary>
    ''' <param name="Frame">The frame number requested.</param>
    ''' <returns>The frame's x position.</returns>
    ''' <remarks></remarks>
    Public Function FrameLocation(Frame As Long) As Single
        Return FramesToPixels(Frame) - ViewXOffsetPixels
    End Function
    Public Function PixelLocation(X As Single) As Long
        Return (X + ViewXOffsetPixels) / Scale
    End Function
    Public Property FrameEmphasisInterval As Integer = 6
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics
#If DoubleBuffered Then
        Dim BufferContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
        Dim Buffer As BufferedGraphics = BufferContext.Allocate(e.Graphics, New Rectangle(0, 0, Width, Height))
        g = Buffer.Graphics
#Else
        g = e.Graphics
#End If
        g.Clear(BackColor)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim darkpen As New Pen(Xenon.MakeGrey(40))
        Dim lightpen As New Pen(Xenon.MakeGrey(80))
        Dim x As Long
        Dim f As Long
        If Scale >= 3 Then

            For f = FirstFrameShown To Math.Min(LastFrameShown, frmMain.Length - 1)
                x = FrameLocation(f)
                If DesignMode Then
                    g.DrawLine(IIf(f Mod FrameEmphasisInterval = 0, lightpen, darkpen), x, 0, x, Height - 1)
                Else
                    g.DrawLine(IIf(f Mod FrameEmphasisInterval = 0, lightpen, darkpen), x, -ViewYOffsetPixels, x, (TrackCount * TrackHeight) - ViewYOffsetPixels)
                End If
            Next
        End If

        If DesignMode = False Then
            Dim y As Long
            For i As Long = 0 To TrackCount
                y = (i * TrackHeight) - ViewYOffsetPixels
                g.DrawLine(lightpen, 0, y, Width - 1, y)
            Next

            Dim b As Bitmap
            For Each c As VideoClip In frmMain.Project.VideoClips
                b = BuildVideoClipBitmap(c)
                'please draw the clips at whole pixels to ensure the clarity of the dragging handles.
                g.DrawImage(b, CInt(FrameLocation(c.StartFrame)), (c.Track * TrackHeight) - ViewYOffsetPixels + 1)
                b.Dispose()
            Next

            Dim timeboxbrush As New SolidBrush(ForeColor)
            g.FillRectangle(timeboxbrush, 0, Height - timeboxheight, Width, timeboxheight)
            timeboxbrush.Dispose()

            For f = FirstFrameShown To Math.Min(LastFrameShown, frmMain.Length - 1)
                If f Mod FrameEmphasisInterval = 0 Then
                    g.DrawString(f, SystemFonts.IconTitleFont, Brushes.White, FrameLocation(f) - 4, Height - 14)
                End If
            Next

            Dim TimePen As New Pen(Color.FromArgb(255, 32, 0), 3)
            g.DrawLine(TimePen, FrameLocation(frmMain.FrameNumber), 0, FrameLocation(frmMain.FrameNumber), Height - 1)
            TimePen.Dispose()

            g.DrawImage(My.Resources.timemarker, FrameLocation(frmMain.FrameNumber) - 1, Height - 13, 12, 12)
        End If
        darkpen.Dispose()
        lightpen.Dispose()

#If DoubleBuffered Then
        Buffer.Render()
        g.Dispose()
        Buffer.Dispose()
        BufferContext.Dispose()
#End If
    End Sub
    Public ReadOnly Property TrackCount As Long
        Get
            Dim contender As Long = 0
            For Each c As VideoClip In frmMain.Project.VideoClips
                If c.Track > contender Then contender = c.Track
            Next

            For Each c As AudioClip In frmMain.Project.AudioClips
                If c.Track > contender Then contender = c.Track
            Next

            If DesignMode = False Then
                frmMain.VScrollBar1.Maximum = (contender + 6) * 3 - 6
            End If
            Return contender + 4
        End Get
    End Property
    Public SelectedClip As Clip
    Public Function BuildVideoClipBitmap(Clip As VideoClip) As Bitmap
        Dim b As New Bitmap(CInt((Clip.Length - 2) * Scale), CInt(TrackHeight))
        Dim g As Graphics = Graphics.FromImage(b)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Dim FillBrush As Brush
        Dim BorderPen As Pen
        If Clip.Equals(SelectedClip) Then
            FillBrush = Brushes.CadetBlue
            BorderPen = New Pen(Color.FromArgb(63, 101, 102))
        Else
            FillBrush = Brushes.OliveDrab
            BorderPen = Pens.DarkOliveGreen
        End If
        g.FillRectangle(FillBrush, 0, TrackHeight \ 2, b.Width, b.Height - (TrackHeight \ 2))
        g.FillRectangle(FillBrush, CInt(Clip.CropStart * Scale), 0, CInt((Clip.Length - Clip.CropStart - Clip.CropEnd) * Scale) - 10, CInt(TrackHeight \ 2))
        g.DrawImage(My.Resources.handle_crop, CInt(Clip.CropStart * Scale), 0, 11, TrackHeight \ 2)
        g.DrawImage(My.Resources.handle_leftmove, 0, TrackHeight \ 2, 11, TrackHeight \ 2)
        g.DrawImage(My.Resources.handle_crop, b.Width - FramesToPixels(Clip.CropEnd) - 11, 0, 11, TrackHeight \ 2)
        'g.DrawRectangle(Pens.DarkOliveGreen, 0, 1, b.Width - 1, b.Height - 1) 'old selection rectangle 
        g.DrawString(Clip.StartFrame, SystemFonts.IconTitleFont, Brushes.White, 15, TrackHeight \ 2 + 5)
        g.DrawString(Clip.CropStart, SystemFonts.IconTitleFont, Brushes.White, 15 + CInt(Clip.CropStart * Scale), 5)
        g.DrawString(Clip.CropEnd, SystemFonts.IconTitleFont, Brushes.White, b.Width - FramesToPixels(Clip.CropEnd) - 20 - g.MeasureString(Clip.CropEnd, SystemFonts.IconTitleFont).Width, 5)
        g.DrawString(Clip.Length, SystemFonts.IconTitleFont, Brushes.White, b.Width - 20 - g.MeasureString(Clip.Length, SystemFonts.IconTitleFont).Width, CInt(TrackHeight \ 2) + 5)
        g.FillRectangle(Brushes.Black, g.MeasureString(Clip.StartFrame, SystemFonts.IconTitleFont).Width + 20, CInt(TrackHeight \ 2) + 1, TrackHeight \ 2, TrackHeight \ 2)
        g.DrawImage(Clip.Source.Thumbnail, g.MeasureString(Clip.StartFrame, SystemFonts.IconTitleFont).Width + 20, CInt(TrackHeight \ 2 + 1), TrackHeight \ 2, TrackHeight \ 2)
        g.DrawString(BenMisc.GetName(Clip.Source.Properties.GetVar("DisplayPath")), SystemFonts.CaptionFont, Brushes.White, g.MeasureString(Clip.StartFrame, SystemFonts.IconTitleFont).Width + (TrackHeight \ 2) + 25, CInt(TrackHeight \ 2) + 1)
        g.DrawLine(BorderPen, 0, b.Height - 1, b.Width - 1, b.Height - 1)
        g.DrawLine(BorderPen, 0, b.Height - 1, 0, b.Height \ 2)
        g.DrawLine(BorderPen, b.Width - 1, b.Height - 1, b.Width - 1, b.Height \ 2)
        g.DrawLine(BorderPen, 0, b.Height \ 2, FramesToPixels(Clip.CropStart), b.Height \ 2)
        g.DrawLine(BorderPen, b.Width - 1, b.Height \ 2, b.Width - 1 - FramesToPixels(Clip.CropEnd), b.Height \ 2)
        If Clip.Equals(SelectedClip) Then
            BorderPen.Dispose()
        Else

        End If
        Return b
    End Function
    Public Shadows MouseDown As Boolean
    Public MousePart As Clip.ClipPart
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        SelectedClip = Nothing
        MousePart = Clip.ClipPart.Void
        Dim HitClip As Clip
        HitClip = HitTestClips(e.X, e.Y)
        If IsNothing(HitClip) = False Then
            Dim HitPart As Clip.ClipPart
            HitPart = HitClip.HitTestParts(e.X - FrameLocation(HitClip.StartFrame), e.Y - ((HitClip.Track * TrackHeight) - ViewYOffsetPixels + 1), Scale, TrackHeight)
            Select Case HitPart
                Case Clip.ClipPart.Void

                Case Else
                    MousePart = HitPart
                    SelectedClip = HitClip
            End Select
        End If
        Dim timebarrect As New Rectangle(0, Height - TimeBoxHeight, Width, TimeBoxHeight)
        If timebarrect.Contains(e.Location) Then
            Dim f As Long = PixelLocation(e.X)
            frmMain.FrameNumber = f
            frmMain.RefreshPreview()
        End If
        Invalidate()
        MouseDown = True
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If MouseDown = True Then
            Select Case MousePart
                Case Clip.ClipPart.StartCropHandle
                    SelectedClip.CropStart = Math.Max(Math.Min(PixelLocation(e.X) - SelectedClip.StartFrame, SelectedClip.Length - SelectedClip.CropEnd - 2), 0)
                Case Clip.ClipPart.EndCropHandle
                    SelectedClip.CropEnd = Math.Max(Math.Min((PixelLocation(e.X + 11) - SelectedClip.StartFrame - SelectedClip.Length) * -1, SelectedClip.Length - SelectedClip.CropStart - 2), 0)
                Case Clip.ClipPart.StartFrameHandle
                    SelectedClip.StartFrame = PixelLocation(e.X)
                    SelectedClip.EndFrame = PixelLocation(e.X) + SelectedClip.Source.Length
                    Dim NewTrack As Long
                    NewTrack = (e.Y + ViewYOffsetPixels) \ TrackHeight

                    SelectedClip.Track = NewTrack
                Case Clip.ClipPart.ScaleHandle

            End Select
            Dim timebarrect As New Rectangle(0, Height - TimeBoxHeight, Width, TimeBoxHeight)
            If timebarrect.Contains(e.Location) Then
                Dim f As Long = PixelLocation(e.X)
                frmMain.FrameNumber = f
                frmMain.RefreshPreview()
            End If
        End If
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        MouseDown = False
        frmMain.Invoke(Sub() frmMain.RefreshPreview())
        Dim c As Clip
        If frmMain.Project.VideoClips.Count > 0 Then
            For i As Long = frmMain.Project.VideoClips.Count - 1 To 0
                c = frmMain.Project.VideoClips(i)
                If c.Track < 0 Then frmMain.Project.VideoClips.Remove(c)
            Next
        End If
        If frmMain.Project.AudioClips.Count > 0 Then
            For i As Long = frmMain.Project.AudioClips.Count - 1 To 0
                c = frmMain.Project.AudioClips(i)
                If c.Track < 0 Then frmMain.Project.AudioClips.Remove(c)
            Next
        End If
    End Sub
    Public Function HitTestClips(X As Integer, Y As Integer) As Clip
        Dim r As Rectangle
        For Each v As VideoClip In frmMain.Project.VideoClips
            r = New Rectangle(FrameLocation(v.StartFrame), (v.Track * TrackHeight) - ViewYOffsetPixels + 1, FramesToPixels(v.Length), TrackHeight)
            If r.Contains(X, Y) Then
                Return v
            End If
        Next
        For Each a As AudioClip In frmMain.Project.AudioClips
            r = New Rectangle(FrameLocation(a.StartFrame), (a.Track * TrackHeight) - ViewYOffsetPixels + 1, FramesToPixels(a.Length), TrackHeight)
            If r.Contains(X, Y) Then
                Return a
            End If
        Next
        Return Nothing
    End Function

    Private Sub TrackerControl_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        If e.Data.GetDataPresent("Prometheus.VideoClip") Then
            Dim newclip As VideoClip = e.Data.GetData("Prometheus.VideoClip")
            newclip.StartFrame = PixelLocation(PointToClient(New Point(e.X, e.Y)).X)
            newclip.Track = (PointToClient(New Point(e.X, e.Y)).Y + ViewYOffsetPixels) \ TrackHeight
            frmMain.Project.VideoClips.Add(newclip)
            Exit Sub
        End If

        Dim hitclip As Clip = HitTestClips(PointToClient(New Point(e.X, e.Y)).X, PointToClient(New Point(e.X, e.Y)).Y)
        If Not IsNothing(hitclip) Then
            For Each ms As IModifierSource In Plugins.Modifiers
                If e.Data.GetDataPresent(ms.GetType().FullName) Then
                    Dim source As IModifierSource = CType(e.Data.GetData(ms.GetType().FullName), IModifierSource)

                    If source.ApplicableToClip(hitclip) Then
                        Dim newmod As IModifierInstance = source.MakeInstance(hitclip)
                        hitclip.Modifiers.Add(newmod)
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub TrackerControl_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        For Each ms As IModifierSource In Plugins.Modifiers
            If e.Data.GetDataPresent(ms.GetType().FullName) Then e.Effect = DragDropEffects.Link
        Next
        If e.Data.GetDataPresent("Prometheus.VideoClip") Then
            e.Effect = DragDropEffects.Link
        End If

    End Sub
End Class
