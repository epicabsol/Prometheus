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
        Dim sequenceloader As New ImageSequenceLoader
        RegisterLoader(".png", sequenceloader)
        RegisterLoader(".bmp", sequenceloader)
        RegisterLoader(".jpg", sequenceloader)
        RegisterLoader(".tif", sequenceloader)
        RegisterLoader(".avi", New AviLoader)
    End Sub
End Module
Public Class AviLoader
    Inherits SourceLoader

    Public Overrides Function GetFrame(Frame As Long, Properties As Dictionary(Of String, Object)) As Bitmap

    End Function

    Public Overrides Function GetLength(Properties As Dictionary(Of String, Object)) As Long

    End Function

    Public Overrides Sub Init(Properties As Dictionary(Of String, Object))

    End Sub
End Class

Public Class ImageSequenceLoader
    Inherits SourceLoader
    Public Const DefaultFramePadding As Integer = 10
    Public Overloads Overrides Function GetFrame(Frame As Long, Properties As Dictionary(Of String, Object)) As Bitmap
        Return New Bitmap(GetFileName(Frame, Properties))
    End Function
    Public Function GetFileName(Frame As Long, Properties As Dictionary(Of String, Object)) As String
        Return Strings.Left(GetVar("Path", Properties), Len(GetVar("Path", Properties)) - Len(BenMisc.GetExtension(GetVar("Path", Properties)))) & Frame.ToString.PadLeft(GetVar("FramePadding", Properties), "0") & BenMisc.GetExtension(GetVar("Path", Properties))
    End Function
    Public Sub New()

    End Sub
    Public Overrides Function GetLength(Properties As Dictionary(Of String, Object)) As Long
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

    Public Overrides Sub Init(Properties As Dictionary(Of String, Object))
        Dim rawname As String = BenMisc.GetName(GetVar("Path", Properties))
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
        Dim path As String = GetVar("Path", Properties)
        Dim pathlen As Long = Len(path)
        Dim file As String = BenMisc.GetName(path)
        Dim name As String = Strings.Left(rawname, Len(rawname) - i)
        Dim ext As String = BenMisc.GetExtension(path)
        SetVar("FramePadding", i, Properties)
        SetVar("Path", Strings.Left(path, pathlen - Len(file)) & name & ext, Properties)
        SetVar("Length", GetLength(Properties), Properties)
    End Sub
End Class

Public MustInherit Class SourceLoader
    Public MustOverride Function GetFrame(Frame As Long, Properties As Dictionary(Of String, Object)) As Bitmap
    Public MustOverride Function GetLength(Properties As Dictionary(Of String, Object)) As Long
    ''' <summary>
    ''' Sets up the properties of the file outlined in the Properties argument.
    ''' </summary>
    ''' <param name="Properties">The list of properties including the path of the file.</param>
    ''' <remarks>Should read the "Path" variable and set at least the "Length" variable.</remarks>
    Public MustOverride Sub Init(Properties As Dictionary(Of String, Object))
    Public Sub New()

    End Sub
    Public Function GetVar(Name As String, Properties As Dictionary(Of String, Object)) As Object
        If Properties.ContainsKey(Name) Then
            Return Properties(Name)
        Else
            Return Nothing
        End If
    End Function
    Public Sub SetVar(Name As String, Value As Object, Properties As Dictionary(Of String, Object))
        If Properties.ContainsKey(Name) Then
            Properties(Name) = Value
        Else
            Properties.Add(Name, Value)
        End If
    End Sub
End Class
