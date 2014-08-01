Public Class PalleteTabStrip
    Inherits Control
    Public ReadOnly Property TabWidth As Integer
        Get
            Return My.Resources.TabSelected.Width
        End Get
    End Property
    Public ReadOnly Property TabHeight As Integer
        Get
            Return My.Resources.TabSelected.Height
        End Get
    End Property
    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        MyBase.OnPaintBackground(pevent)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        g.Clear(BackColor)
        BenMisc.DrawElement(g, My.Resources.TabBase, 0, TabHeight - 1, Width, Height - TabHeight + 1, 2)

        Dim i As Long = 0
        Dim tabrect As Rectangle
        'Dim control As PalleteControl = frmMain.PalleteControl1 'CType(Parent, PalleteControl)
        For Each t As Tab In Me.Tabs
            tabrect = New Rectangle(i * TabWidth, 0, TabWidth, TabHeight)
            If i = CurrentTabIndex Then
                'tab is selected
                'If t.Hover Then
                'g.DrawImage(My.Resources.TabSelectedHover, tabrect)
                'Else
                g.DrawImage(My.Resources.TabSelected, tabrect)
                'End If
                g.DrawString(t.Text, SystemFonts.SmallCaptionFont, Brushes.White, tabrect.X + 15, tabrect.Y + 1)
            Else
                tabrect.Y -= 1
                'tab is not selected
                If t.Hover Then
                    g.DrawImage(My.Resources.TabUnselectedHover, tabrect)
                Else
                    g.DrawImage(My.Resources.TabUnselected, tabrect)
                End If
                g.DrawString(t.Text, SystemFonts.SmallCaptionFont, Brushes.White, tabrect.X + 15, tabrect.Y + 5)
            End If

            i += 1
        Next
    End Sub
    Public CurrentTabIndex As Integer = 0
    Public Sub SetTab(TabIndex As Integer)
        CurrentTabIndex = TabIndex
        frmMain.XenonTiler1.Items.Clear()
        Select Case Tabs(TabIndex).Text
            Case "Sources"
                For Each vsc As VideoSourceClip In frmMain.Project.SourceVideoClips
                    Dim newtile As New Xenon.XenonTile(vsc.Thumbnail, BenMisc.GetName(vsc.Path) & vbNewLine & vsc.Length & " Frames")
                    frmMain.XenonTiler1.Items.Add(newtile)
                Next
            Case "Modifiers"

            Case "Generators"

            Case Else

        End Select
        frmMain.XenonTiler1.Invalidate()
        frmMain.cmdAddSource.Visible = IIf(CurrentTabIndex = 0, True, False)
    End Sub
    Public Class Tab
        Public Text As String
        Public Hover As Boolean = False
    End Class
    Public Tabs As New List(Of Tab)
    Public SourcesTab As Tab
    Public ModifiersTab As Tab
    Public GeneratorsTab As Tab
    Public Sub New()
        SourcesTab = New Tab() With {.Text = "Sources"}
        Tabs.Add(SourcesTab)
        ModifiersTab = New Tab() With {.Text = "Modifiers"}
        Tabs.Add(ModifiersTab)
        GeneratorsTab = New Tab() With {.Text = "Generators"}
        Tabs.Add(GeneratorsTab)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        Dim i As Long = 0
        Dim tabrect As Rectangle
        For Each t As Tab In Tabs
            tabrect = New Rectangle(i * TabWidth, 0, TabWidth, TabHeight)
            If tabrect.Contains(e.X, e.Y) Then
                t.Hover = True
            Else
                t.Hover = False
            End If
            i += 1
        Next
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        Dim i As Long = 0
        Dim tabrect As Rectangle
        For Each t As Tab In Tabs
            tabrect = New Rectangle(i * TabWidth, 0, TabWidth, TabHeight)
            If tabrect.Contains(e.X, e.Y) Then
                SetTab(i)
            End If
            i += 1
        Next
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        For Each t As Tab In Tabs
            t.Hover = False
        Next
        Invalidate()
    End Sub
End Class

