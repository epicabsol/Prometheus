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
    Public Sub RegisterDefaultLoaders()
        Dim sequenceloader As New ImageSequenceLoader
        RegisterLoader(".png", "PNG Image Sequence", sequenceloader)
        RegisterLoader(".bmp", "Bitmap Image Sequence", sequenceloader)
        RegisterLoader(".jpg", "JPEG Image Sequence", sequenceloader)
        RegisterLoader(".tif", "TIFF Image Sequence", sequenceloader)
        RegisterLoader(".avi", "AVI Movie", New AviLoader)
    End Sub
End Module

Public Class BrowsableFormat
    Public Extension As String
    Public Description As String
    Public Sub New(Extension As String, Description As String)
        Me.Extension = Extension
        Me.Description = Description
    End Sub
End Class

Public Class AviLoader
    Inherits SourceLoader
    Public Overrides ReadOnly Property ResourceType As ResourceType
        Get
            Return Loaders.ResourceType.Video
        End Get
    End Property

    Public Overrides Function GetFrame(Frame As Long, Properties As Properties) As Bitmap

    End Function

    Public Overrides Function GetLength(Properties As Properties) As Long

    End Function

    Public Overrides Sub Init(Properties As Properties)

    End Sub
End Class

Public Class ImageSequenceLoader
    Inherits SourceLoader
    Public Const DefaultFramePadding As Integer = 10
    Public Overloads Overrides Function GetFrame(Frame As Long, Properties As Properties) As Bitmap
        Return New Bitmap(GetFileName(Frame, Properties))
    End Function
    Public Function GetFileName(Frame As Long, Properties As Properties) As String
        Return Strings.Left(Properties.GetVar("DisplayPath"), Len(Properties.GetVar("DisplayPath")) - Len(BenMisc.GetExtension(Properties.GetVar("DisplayPath")))) & Frame.ToString.PadLeft(Properties.GetVar("FramePadding"), "0") & BenMisc.GetExtension(Properties.GetVar("DisplayPath"))
    End Function
    Public Sub New()

    End Sub
    Public Overrides Function GetLength(Properties As Properties) As Long
        Dim i As Long = -1
        Dim s As Boolean = False
        Do While s = False
            Try
                i += 1
                If i = 440 Then
                    BenMisc.Foo()
                End If
                s = Not System.IO.File.Exists(GetFileName(i, Properties))
                If s = True Then s -= 1
            Catch ex As Exception
                s = True
                s -= 1
            End Try
        Loop
        Return i
    End Function

    Public Overrides Sub Init(Properties As Properties)
        Dim rawname As String = BenMisc.GetName(Properties.GetVar("Path"))
        rawname = Strings.Left(rawname, Len(rawname) - Len(BenMisc.GetExtension(rawname)))
        Dim bit As String
        Dim i As Long
        For i = 1 To Len(rawname)
            bit = Strings.Right(rawname, i)
            If Not IsNumeric(bit) Then
                Exit For
            End If
        Next
        i -= 1
        Dim path As String = Properties.GetVar("Path")
        Dim pathlen As Long = Len(path)
        Dim file As String = BenMisc.GetName(path)
        Dim name As String = Strings.Left(rawname, Len(rawname) - i)
        Dim ext As String = BenMisc.GetExtension(path)
        Properties.SetVar("FramePadding", i)
        Properties.SetVar("DisplayPath", Strings.Left(path, pathlen - Len(file)) & name & ext)
        Properties.SetVar("Length", GetLength(Properties))
        Dim tempimage As Bitmap = GetFrame(0, Properties)
        Properties.SetVar("Width", tempimage.Width)
        Properties.SetVar("Height", tempimage.Height)
        tempimage.Dispose()
    End Sub

    Public Overrides ReadOnly Property ResourceType As ResourceType
        Get
            Return Loaders.ResourceType.Video
        End Get
    End Property
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
