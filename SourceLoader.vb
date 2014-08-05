Public Module Loaders
    Public Enum ResourceType
        Video = 0
        Audio = 1
        Modifier = 2
        Generator = 3
    End Enum
    Private Loaders As New Dictionary(Of String, SourceLoader)
    Public SourceExtensions As New List(Of BrowsableFormat)
    Public Sub RegisterLoader(Extension As String, FormatDescription As String, Loader As SourceLoader)
        If Not Loaders.ContainsKey(Extension) Then Loaders.Add(Extension, Loader)
        Dim ext As New BrowsableFormat(Extension, FormatDescription)
        If Not SourceExtensions.Contains(ext) Then SourceExtensions.Add(ext)
    End Sub
    Public Function GetLoader(Extension As String) As SourceLoader
        If Loaders.ContainsKey(Extension) Then
            Return Loaders(Extension)
        Else
            Return Nothing
        End If
    End Function
    Public Function GetFileType(path As String) As ResourceType
        Dim loader As SourceLoader = GetLoader(BenMisc.GetExtension(path))
        If Not IsNothing(loader) Then
            Return loader.ResourceType
        Else
            Return -1
        End If
    End Function
    Public Function BuildSourceFilter() As String
        Dim s As String = ""
        For Each ext As BrowsableFormat In SourceExtensions
            s &= ext.Description & " (*" & ext.Extension & ")|" & "*" & ext.Extension & "|"
        Next
        s = Strings.Left(s, Len(s) - 1) 'chop off the extra pipe character ("|")
        Return s
    End Function
    Public Function BuildRenderFilter() As String
        Throw New NotImplementedException()
    End Function
    'Public Sub RegisterDefaultLoaders()
    'End Sub
End Module

Public Class BrowsableFormat
    Public Extension As String
    Public Description As String
    Public Sub New(Extension As String, Description As String)
        Me.Extension = Extension
        Me.Description = Description
    End Sub
End Class

Public MustInherit Class SourceLoader
    Public MustOverride ReadOnly Property ResourceType As ResourceType
    Public MustOverride Function GetFrame(Frame As Long, Properties As Properties) As Bitmap
    Public MustOverride Function GetLength(Properties As Properties) As Long
    ''' <summary>
    ''' Sets up the properties of the file outlined in the Properties argument.
    ''' </summary>
    ''' <param name="Properties">The list of properties including the path of the file.</param>
    ''' <remarks>Should read the "Path" variable and set at least the "Length" and "DisplayPath" variables.</remarks>
    Public MustOverride Sub Init(Properties As Properties)
    Public Sub New()

    End Sub

End Class
