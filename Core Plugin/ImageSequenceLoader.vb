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
