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
