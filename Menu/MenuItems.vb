Public Class NewButton
    Inherits MenuEntryMain
    Private NewSubItem As New NewSubEntry
    Public Sub New()
        Me.Text = "New Project"
        Me.SubText = "Start from a clean slate!"
        Me.Tooltip = "Clear the current project."
        Me.Image = My.Resources.MenuItem_NewFile
        Me.SubItems.Add(NewSubItem)
    End Sub
    Private Class NewSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Me.Text = "New Project"
            Me.SubText = ""
            Me.ToolTip = "Clears the current project."
            Me.Image = My.Resources.MenuItem_NewFile
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.NewProject()
        End Sub
    End Class
End Class

Public Class OpenMenuButton
    Inherits MenuEntryMain
    Private OpenSubItem As New OpenSubEntry
    Private OpenCopyItem As New OpenCopySubEntry
    Private OpenInternetItem As New OpenInternetSubEntry
    Public Sub New()
        Me.Text = "Open Project"
        Me.SubText = "Restore a previous project."
        Me.Tooltip = "Open a saved project."
        Me.Image = My.Resources.MenuItem_Open
        Me.SubItems.Add(OpenSubItem)
        Me.SubItems.Add(OpenCopyItem)
        Me.SubItems.Add(OpenInternetItem)
    End Sub
    Private Class OpenSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Open Project"
            ToolTip = "Open a saved project."
            Image = My.Resources.MenuItem_Open
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.Open()
        End Sub
    End Class
    Private Class OpenCopySubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Open Copy"
            ToolTip = "Open a copy that won't save over the original."
            Image = My.Resources.MenuItem_OpenCopy
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.OpenCopy()
        End Sub
    End Class
    Private Class OpenInternetSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Open From Internet"
            ToolTip = "Open a copy from a URL."
            Image = My.Resources.MenuItem_OpenInternet
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.OpenFromInternet()
        End Sub
    End Class
End Class

Public Class SaveMenuButton
    Inherits MenuEntryMain
    Private SaveSubItem As New SaveSubEntry
    Private SaveAsSubItem As New SaveAsSubEntry
    Private SaveCopySubItem As New SaveCopySubEntry
    Public Sub New()
        Text = "Save Project"
        SubText = "Save the project."
        Tooltip = "Save the project to a project file (*.pmp)"
        Image = My.Resources.MenuItem_Save
        SubItems.Add(SaveSubItem)
        SubItems.Add(SaveAsSubItem)
        SubItems.Add(SaveCopySubItem)
    End Sub
    Private Class SaveSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Save Project"
            ToolTip = "Save the project."
            Image = My.Resources.MenuItem_Save
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.TrySave()
        End Sub
    End Class
    Private Class SaveAsSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Save Project As..."
            ToolTip = "Save the project to a new location."
            Image = My.Resources.MenuItem_SaveAs
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.SaveAs()
        End Sub
    End Class
    Private Class SaveCopySubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Save Project Copy..."
            ToolTip = "Save a copy of the project to a new location, but keep saving at the old location."
            Image = My.Resources.MenuItem_SaveTo
        End Sub
        Public Overrides Sub OnClicked()
            frmMain.SaveCopy()
        End Sub
    End Class
End Class

Public Class RenderMenuButton
    Inherits MenuEntryMain
    Private RenderSubItem As New RenderSubEntry
    Public Sub New()
        Text = "Render"
        SubText = "Build the video file."
        Tooltip = "Export the project to a video file(s)."
        Image = My.Resources.Render
        SubItems.Add(RenderSubItem)
    End Sub
    Private Class RenderSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Render Movie"
            ToolTip = "Build the video file."
            Image = My.Resources.Render
        End Sub
        Public Overrides Sub OnClicked()
            frmRender.ShowDialog()
        End Sub
    End Class
End Class

Public Class ToolsMenuButton
    Inherits MenuEntryMain
    Private ConvertVideoSubItem As New ConvertVideoSubEntry
    Public Sub New()
        Text = "Tools"
        SubText = "Handy things."
        Tooltip = "Extra stuff, just for you!"
        SubItems.Add(ConvertVideoSubItem)
        Image = My.Resources.MenuItem_Tools
    End Sub
    Private Class ConvertVideoSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Convert Video Files"
            Image = My.Resources.MenuItem_Convert
        End Sub
        Public Overrides Sub OnClicked()
            MsgBox("The video converter has not been completed. =(")
        End Sub
    End Class
End Class

Public Class HelpMenuButton
    Inherits MenuEntryMain
    Private GuideSubItem As New GuideSubEntry
    Private AboutSubItem As New AboutSubEntry
    Private WebsiteSubItem As New WebsiteSubEntry
    Private GitHubSubItem As New GitHubSubEntry
    Public Sub New()
        Text = "Help"
        SubText = "Helpful information here."
        Tooltip = "Prometheus guide and About window."
        Image = My.Resources.MenuItem_Help
        SubItems.Add(GuideSubItem)
        SubItems.Add(AboutSubItem)
        SubItems.Add(WebsiteSubItem)
        SubItems.Add(GitHubSubItem)
    End Sub
    Private Class GuideSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Prometheus Guide"
            ToolTip = "Show the help guide."
            Image = My.Resources.MenuItem_Help
        End Sub
        Public Overrides Sub OnClicked()
            MsgBox("The help guide is not completed. =(")
        End Sub
    End Class
    Private Class WebsiteSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Prometheus Website"
            ToolTip = "Go to the Prometheus website."
            Image = My.Resources.Promethean_Button_Filled_x48
        End Sub
        Public Overrides Sub OnClicked()
            'NOTE I have not gotten around to actually making the website... But when I do, this is where it will be.
            Process.Start("http://epicabsol.us.to/projects/prometheus/")
        End Sub
    End Class
    Private Class GitHubSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "Go To GitHub Page"
            ToolTip = "Go to Prometheus' project at the GitHub website."
            Image = My.Resources.MenuItem_GitHub
        End Sub
        Public Overrides Sub OnClicked()
            Process.Start(New System.Diagnostics.ProcessStartInfo("https://github.com/epicabsol/Prometheus"))
        End Sub
    End Class
    Private Class AboutSubEntry
        Inherits MenuEntryMini
        Public Sub New()
            Text = "About Prometheus"
            ToolTip = "Show information about this program."
            Image = My.Resources.MenuItem_About
        End Sub
        Public Overrides Sub OnClicked()
            frmAbout.ShowDialog()
        End Sub
    End Class
End Class