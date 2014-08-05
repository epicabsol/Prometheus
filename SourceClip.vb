Public MustInherit Class SourceClip
    Public Properties As New Properties
    Public Loader As SourceLoader
    Public Property Path As String
        Set(value As String)
            Properties.SetVar("Path", value)
        End Set
        Get
            Return Properties.GetVar("Path")
        End Get
    End Property
    Public Property Length As String
        Set(value As String)
            Properties.SetVar("Length", value)
        End Set
        Get
            Return Properties.GetVar("Length")
        End Get
    End Property
End Class

Public Class VideoSourceClip
    Inherits SourceClip
    Public Cache As New Dictionary(Of Long, Bitmap)
    Public Sub New(path As String)
        Me.Path = path
        Loader = GetLoader(BenMisc.GetExtension(path))
        If IsNothing(Loader) Then
            Throw New Exception("No loader found for the extension <" & BenMisc.GetExtension(path) & ">." & vbNewLine & "You should add a plugin for that extension.")
        End If
        Loader.Init(Properties)
        _thumbnail = New Bitmap(128, 128)
        Dim g As Graphics = Graphics.FromImage(_thumbnail)
        g.DrawImage(GetRawFrame(Length \ 3), BenMisc.BestFitCenter(New Rectangle(0, 0, GetRawFrame(0).Width, GetRawFrame(0).Height), New Rectangle(0, 0, 128, 128)))
        g.Dispose()
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
            Dim b As New Bitmap(Loader.GetFrame(Number, Properties))
            Cache.Add(Number, b)
            Return b
        End If
    End Function
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
    Public Function MakeClip() As AudioClip
        Throw New NotImplementedException
    End Function
End Class


