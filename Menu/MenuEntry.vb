Imports Prometheus.frmMenu

Public MustInherit Class MenuEntryMain
    Public Image As Bitmap
    Public Text As String
    Public SubText As String
    Public Tooltip As String
    Public State As MenuStates
    Public SubItems As New List(Of MenuEntryMini)
    Public Overridable Sub OnClicked()
    End Sub
End Class

Public MustInherit Class MenuEntryMini
    Public Image As Bitmap
    Public Text As String
    Public SubText As String
    Public ToolTip As String
    Public State As MenuStates
    Public MustOverride Sub OnClicked()
End Class