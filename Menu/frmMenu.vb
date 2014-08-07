Public Class frmMenu
    Public Enum MenuStates
        Normal
        Hover
        Pressed
    End Enum
    Public MainItems As New List(Of MenuEntryMain)
    Public SelectedMainItem As MenuEntryMain
    Public Const MainItemHeight As Integer = 55
    Public Const SubItemHeight As Integer = 40
    'Main Items
    Public NewMenuItem As New NewButton
    Public OpenMenuItem As New OpenMenuButton
    Public SaveMenuItem As New SaveMenuButton
    Public RenderMenuItem As New RenderMenuButton
    Public ToolsMenuItem As New ToolsMenuButton
    Public HelpMenuItem As New HelpMenuButton
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainItems.Add(NewMenuItem)
        MainItems.Add(OpenMenuItem)
        MainItems.Add(SaveMenuItem)
        MainItems.Add(RenderMenuItem)
        MainItems.Add(ToolsMenuItem)
        MainItems.Add(HelpMenuItem)
    End Sub
    Private Sub frmMenu_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Hide()
        frmMain.MainButtonHover = False
        frmMain.Invalidate()
    End Sub

    Private Sub frmMenu_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Dim y As Integer
        Dim i As Integer
        Dim r As Rectangle
        Dim HasHitAnything As Boolean = False
        For Each item As MenuEntryMain In MainItems
            y = 50 + (i * MainItemHeight)
            r = New Rectangle(5, y + 5, Width / 2 - 10, MainItemHeight - 10)
            If r.Contains(e.Location) Then
                item.State = MenuStates.Pressed
                SelectedMainItem = item
                HasHitAnything = True
                item.OnClicked()
            Else
                If item.State = MenuStates.Pressed And e.X <= Width / 2 Then item.State = MenuStates.Normal
            End If
            i += 1
        Next
        If Not HasHitAnything And e.X <= Width / 2 Then SelectedMainItem = Nothing
        If IsNothing(SelectedMainItem) = False Then
            i = 0
            For Each item As MenuEntryMini In SelectedMainItem.SubItems
                y = 50 + (i * SubItemHeight)
                r = New Rectangle(Width / 2 + 5, y + 5, Width / 2 - 10, SubItemHeight - 10)
                If r.Contains(e.Location) Then
                    item.State = MenuStates.Pressed
                Else
                    If item.State = MenuStates.Pressed Then item.State = MenuStates.Normal
                End If
                i += 1
            Next
        End If

        Invalidate()
    End Sub

    Private Sub frmMenu_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Dim cursor As New Point(PointToClient(MousePosition))
        Dim y As Integer
        Dim i As Integer
        Dim r As Rectangle
        For Each item As MenuEntryMain In MainItems
            y = 50 + (i * MainItemHeight)
            r = New Rectangle(5, y + 5, Width / 2 - 10, MainItemHeight - 10)
            If r.Contains(cursor) Then
                'show a tooltip
            End If
            i += 1
        Next
        If IsNothing(SelectedMainItem) = False Then
            i = 0
            For Each item As MenuEntryMini In SelectedMainItem.SubItems
                y = 50 + (i * SubItemHeight)
                r = New Rectangle(Width / 2 + 5, y + 5, Width / 2 - 10, SubItemHeight - 10)
                If r.Contains(cursor) Then
                    'show a tooltip
                End If
                i += 1
            Next
        End If

    End Sub

    Private Sub frmMenu_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        For Each item As MenuEntryMain In MainItems
            If item.State = MenuStates.Hover Then item.State = MenuStates.Normal
        Next
        If IsNothing(SelectedMainItem) = False Then
            For Each item As MenuEntryMini In SelectedMainItem.SubItems
                If item.State = MenuStates.Hover Then item.State = MenuStates.Normal
            Next
        End If
        Invalidate()
    End Sub

    Private Sub frmMenu_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Dim y As Integer
        Dim i As Integer
        Dim r As Rectangle
        For Each item As MenuEntryMain In MainItems
            y = 50 + (i * MainItemHeight)
            r = New Rectangle(5, y + 5, Width / 2 - 10, MainItemHeight - 10)
            If r.Contains(e.Location) Then
                If item.State = MenuStates.Normal Then item.State = MenuStates.Hover
            Else
                If item.State = MenuStates.Hover Then item.State = MenuStates.Normal
            End If
            i += 1
        Next
        If IsNothing(SelectedMainItem) = False Then
            i = 0
            For Each item As MenuEntryMini In SelectedMainItem.SubItems
                y = 50 + (i * SubItemHeight)
                r = New Rectangle(Width / 2 + 5, y + 5, Width / 2 - 10, SubItemHeight - 10)
                If r.Contains(e.Location) Then
                    If item.State = MenuStates.Normal Then item.State = MenuStates.Hover
                Else
                    If item.State = MenuStates.Hover Then item.State = MenuStates.Normal
                End If
                i += 1
            Next
        End If

        Invalidate()
    End Sub

    Private Sub frmMenu_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Dim exitrect As New Rectangle(Width - 89, Height - 17, 89, 17)
        If exitrect.Contains(e.Location) Then
            Close()
            frmMain.Close()
        End If
        Dim i As Integer
        Dim r As Rectangle
        Dim y As Integer
        If IsNothing(SelectedMainItem) = False Then
            i = 0
            For Each item As MenuEntryMini In SelectedMainItem.SubItems
                y = 50 + (i * SubItemHeight)
                r = New Rectangle(Width / 2 + 5, y + 5, Width / 2 - 10, SubItemHeight - 10)
                If r.Contains(e.Location) Then
                    item.OnClicked()
                    item.State = MenuStates.Normal
                Else
                    If item.State = MenuStates.Pressed Then item.State = MenuStates.Normal
                End If
                i += 1
            Next
        End If

    End Sub

    Private Sub frmMenu_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.DrawImage(My.Resources.MenuHeader, 0, 0, 400, 50)
        BenMisc.DrawElement(e.Graphics, My.Resources.MenuLeftPanel, 0, 50, Width / 2, Height - 100, 3)
        BenMisc.DrawElement(e.Graphics, My.Resources.MenuRightPanel, Width / 2, 50, Width / 2, Height - 100, 3)
        e.Graphics.DrawImage(My.Resources.MenuFooter, 0, Height - 50, 400, 50)
        Dim y As Integer
        Dim i As Integer
        Dim r As Rectangle
        For Each item As MenuEntryMain In MainItems
            y = 50 + (i * MainItemHeight)
            r = New Rectangle(5, y + 5, Width / 2 - 10, MainItemHeight - 10)
            Select Case item.State
                Case MenuStates.Normal

                Case MenuStates.Hover
                    BenMisc.DrawElement(e.Graphics, My.Resources.MenuItemMainHover, r.X, r.Y, r.Width, r.Height, 7)
                Case MenuStates.Pressed
                    BenMisc.DrawElement(e.Graphics, My.Resources.MenuItemMainPressed, r.X, r.Y, r.Width, r.Height, 7)
            End Select
            If IsNothing(item.Image) = False Then
                e.Graphics.DrawImage(item.Image, r.X + 4, r.Y + 4, MainItemHeight - 18, MainItemHeight - 18)
            End If
            e.Graphics.DrawString(item.Text, SystemFonts.CaptionFont, Brushes.White, MainItemHeight, r.Y + 4)
            e.Graphics.DrawString(item.SubText, SystemFonts.IconTitleFont, Brushes.LightGray, MainItemHeight, r.Y + 24)
            i += 1
        Next
        'draw sub items if there is a selection
        i = 0
        If IsNothing(SelectedMainItem) = False Then
            For Each item As MenuEntryMini In SelectedMainItem.SubItems

                y = 50 + (i * SubItemHeight)
                r = New Rectangle(Width / 2 + 2, y + 5, Width / 2 - 4, SubItemHeight - 10)
                Select Case item.State
                    Case MenuStates.Normal

                    Case MenuStates.Hover
                        BenMisc.DrawElement(e.Graphics, My.Resources.MenuItemSubHover, r.X, r.Y, r.Width, r.Height, 7)
                    Case MenuStates.Pressed
                        BenMisc.DrawElement(e.Graphics, My.Resources.MenuItemSubPressed, r.X, r.Y, r.Width, r.Height, 7)
                End Select
                If IsNothing(item.Image) = False Then
                    e.Graphics.DrawImage(item.Image, r.X + 2, r.Y + 2, SubItemHeight - 14, SubItemHeight - 14)
                End If
                e.Graphics.DrawString(item.Text, SystemFonts.CaptionFont, Brushes.White, Width / 2 + SubItemHeight, r.Y + 4)
                e.Graphics.DrawString(item.SubText, SystemFonts.IconTitleFont, Brushes.LightGray, Width / 2 + SubItemHeight, r.Y + 24)
                i += 1
            Next
        End If

    End Sub

    Private Sub frmMenu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'SelectedMainItem = OpenMenuItem
        'OpenMenuItem.State = MenuStates.Pressed
    End Sub
End Class