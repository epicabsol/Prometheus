Public Module Loaders
    Private Loaders As New Dictionary(Of String, SourceLoader)
    Public Sub RegisterLoader(Extension As String, Loader As SourceLoader)
        If Not Loaders.ContainsKey(Extension) Then Loaders.Add(Extension, Loader)
    End Sub
    Public Function GetLoader(Extension As String) As SourceLoader
        If Loaders.ContainsKey(Extension) Then
            Return Loaders(Extension)
        Else
            Return Nothing
        End If
    End Function
    Public Sub RegisterDefaultLoaders()

    End Sub
End Module

Public MustInherit Class SourceLoader
    Public Path As String
    Public MustOverride Function GetFrame(Frame As Long) As Bitmap
End Class
