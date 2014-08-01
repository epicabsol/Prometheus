Public MustInherit Class SourceClip
    Public Path As String
    Public MustOverride ReadOnly Property Length As Long
End Class

Public Class VideoSourceClip
    Inherits SourceClip
    Public PaddingLength As Integer = 10
    Public Cache As New Dictionary(Of Long, Bitmap)
    Public Sub New(path As String, FileNumberPadding As Integer)
        Me.Path = path
        Me.PaddingLength = FileNumberPadding
        _thumbnail = New Bitmap(128, 128)
        Dim g As Graphics = Graphics.FromImage(_thumbnail)
        g.DrawImage(GetRawFrame(Length \ 3), BenMisc.BestFitCenter(New Rectangle(0, 0, GetRawFrame(0).Width, GetRawFrame(0).Height), New Rectangle(0, 0, 128, 128)))
        g.Dispose()
        Dim i As Long = -1
        Dim s As Boolean = False
        Do While s = False
            Try
                i += 1
                If i = 440 Then
                    BenMisc.Foo()
                End If
                s = Not System.IO.File.Exists(GetFileName(i))
                If s = True Then s -= 1
            Catch ex As Exception
                s = True
                s -= 1
            End Try
        Loop
        _length = i
    End Sub
    Public Sub FlushCache()
        For Each pair As KeyValuePair(Of Long, Bitmap) In Cache
            pair.Value.Dispose()
        Next
        Cache.Clear()
    End Sub
    Public Function GetRawFrame(Number As Long) As Bitmap
        If Cache.ContainsKey(Number) Then
            Return Cache(Number)
        Else
            Dim b As New Bitmap(GetFileName(Number))
            Cache.Add(Number, b)
            Return b
        End If
    End Function
    Public Function GetFileName(Frame As Long) As String
        Return Strings.Left(Path, Len(Path) - Len(BenMisc.GetExtension(Path))) & "_" & Frame.ToString.PadLeft(PaddingLength, "0") & BenMisc.GetExtension(Path)
    End Function
    Private _length As Long
    Public Overrides ReadOnly Property Length As Long
        Get
            Return _length
        End Get
    End Property
    Public Function MakeClip(StartFrame As Long) As VideoClip
        Return New VideoClip(Me, StartFrame)
    End Function
    Private _thumbnail As Bitmap
    Public ReadOnly Property Thumbnail As Bitmap
        Get
            Return _thumbnail
        End Get
    End Property
End Class

Public Class AudioSourceClip
    Inherits SourceClip

    Public Overrides ReadOnly Property Length As Long
        Get
            Throw New NotImplementedException
        End Get
    End Property
    Public Function MakeClip() As AudioClip
        Throw New NotImplementedException
    End Function
End Class


