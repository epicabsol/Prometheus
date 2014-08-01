Public MustInherit Class Plugin
    Public Shared Sub LoadPlugins()

    End Sub
    Public MustOverride Function GetModifiers() As List(Of IModifier)
    Public MustOverride Function GetAuthor() As String
    Public MustOverride Function GetName() As String
    Public Path As String
End Class

Public Module Modifiers
    Public Modifiers As New List(Of IModifier)
End Module
