Imports BenMisc
Imports Xenon
Public Class ModifierStackControl
    Inherits Control
    Public Sub New()
        DoubleBuffered = True
    End Sub
    Public SelectedModifier As IModifierInstance
    Private ReadOnly Property SelectedClip As Clip
        Get
            Return frmMain.TrackerControl1.SelectedClip
        End Get
    End Property
    Public Property ItemHeight As Integer = 23
    Public Property ScrollOffsetPercent As Single
    Private Property ScrollOffsetPixels As Integer
        Get
            Return ScrollOffsetPercent * GetUnshownHeight()
        End Get
        Set(value As Integer)
            ScrollOffsetPercent = value / GetUnshownHeight()
        End Set
    End Property
    Public Function GetUnshownHeight() As Integer
        If IsNothing(SelectedClip) Then Return 0
        Dim r As Integer = (SelectedClip.Modifiers.Count * ItemHeight) - Height
        Return IIf(r > 0, r, 0)
    End Function
    Public Function IndexToPixel(Index As Integer) As Integer
        Return (Index * ItemHeight) - ScrollOffsetPixels
    End Function
    Public Function PixelToIndex(Pixel As Integer) As Integer
        Return Math.Floor((Pixel + ScrollOffsetPixels) / ItemHeight)
    End Function
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        'g.Clear(BackColor)
        BenMisc.DrawElement(g, My.Resources.ModifierStack, 0, 0, Width, Height, 25)
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        If IsNothing(SelectedClip) = False Then
            If SelectedClip.Modifiers.Count > 0 Then
                Dim y As Long
                Dim i As Long
                Dim r As Rectangle
                Dim SelectedBrush As New Drawing2D.LinearGradientBrush(New Point(0, y), New Point(0, ItemHeight + y), MakeGrey(43), MakeGrey(60))
                Dim NormalBrush As New Drawing2D.LinearGradientBrush(New Point(0, y), New Point(0, ItemHeight + y), Xenon.MakeGrey(Xenon.ButtonNormalTop), Xenon.MakeGrey(Xenon.ButtonNormalBottom))
                Dim ButtonBrush As New Drawing2D.LinearGradientBrush(New Point(0, -ScrollOffsetPixels), New Point(0, ItemHeight - ScrollOffsetPixels), MakeGrey(60), MakeGrey(43))
                Dim b As Brush

                For Each m As IModifierInstance In SelectedClip.Modifiers
                    y = IndexToPixel(i)
                    If m Is SelectedModifier Then
                        b = SelectedBrush
                    Else
                        b = NormalBrush
                    End If
                    r = New Rectangle(0, y, Width - 1, ItemHeight)
                    g.FillRectangle(b, r)
                    g.DrawRectangle(Pens.Black, r)
                    g.DrawImage(m.Source.Thumbnail, 3, y + 3, ItemHeight - 5, ItemHeight - 5)
                    g.FillRectangle(ButtonBrush, Width - (ItemHeight + 8), y + 1, ItemHeight + 7, ItemHeight - 2)
                    g.DrawImage(My.Resources.cog, Width - My.Resources.cog.Width - 3, y + 3, ItemHeight - 5, ItemHeight - 5)
                    g.DrawString(m.Source.ID, SystemFonts.CaptionFont, Brushes.White, ItemHeight, y + 2)
                    i += 1
                Next
                g.DrawLine(Pens.Black, Width - (ItemHeight + 8), 0, Width - (ItemHeight + 8), IndexToPixel(SelectedClip.Modifiers.Count))
                SelectedBrush.Dispose()
                NormalBrush.Dispose()
                ButtonBrush.Dispose()
            Else
                g.DrawString("This clip" & vbNewLine & "has no modifiers.", SystemFonts.CaptionFont, Brushes.White, 10, 5)
            End If
        Else
            g.DrawString("Select a clip" & vbNewLine & "to view it's modifiers.", SystemFonts.CaptionFont, Brushes.White, 10, 5)
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If IsNothing(SelectedClip) = False Then
            Dim i As Integer = PixelToIndex(e.Y)
            If i < SelectedClip.Modifiers.Count Then
                SelectedModifier = SelectedClip.Modifiers(i)
                If e.X > Width - (ItemHeight + 8) Then
                    frmPropertyEditor.ShowDialog(SelectedModifier.Properties, SelectedModifier.Source.ID)
                End If
            Else
                SelectedModifier = Nothing
            End If
            Invalidate()
        End If
    End Sub
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Invalidate()
    End Sub
End Class
