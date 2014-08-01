
#Const DoubleBuffer = True
Public Class DisplayControl
    Inherits Control
    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        ' MyBase.OnPaintBackground(pevent)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics
#If DoubleBuffer Then
        Dim BufferContext As BufferedGraphicsContext = BufferedGraphicsManager.Current
        Dim Buffer As BufferedGraphics = BufferContext.Allocate(e.Graphics, New Rectangle(0, 0, Width, Height))
        g = Buffer.Graphics
#Else
        g = e.Graphics
#End If

        Try
            'g.Clear(BackColor)
            'MsgBox("true")
            Dim picrect As Rectangle
            If IsNothing(frmMain.CurrentDisplay) Then
                Dim smallervalue As Single = IIf(Width < Height, Width, Height)
                picrect = BenMisc.BestFitCenter(New Rectangle(0, 0, smallervalue, smallervalue), New Rectangle(0, 0, Width, Height))
            Else
                picrect = BenMisc.BestFitCenter(New Rectangle(0, 0, frmMain.DisplaySize.Width, frmMain.DisplaySize.Height), New Rectangle(0, 0, Width, Height), False)
            End If
            If IsNothing(frmMain.CurrentDisplay) = False Then
                g.DrawImage(frmMain.CurrentDisplay, picrect)
            Else
                g.FillRectangle(Brushes.Red, picrect)
            End If
            If frmMain.Playing Then g.DrawString("FPS: " & frmMain.RealFPS, SystemFonts.CaptionFont, Brushes.Red, 4, 10)

#If DoubleBuffer Then
            Buffer.Render()
            g.Dispose()
            Buffer.Dispose()
            BufferContext.Dispose()
#End If
        Catch ex As Exception

        End Try
    End Sub
End Class
