Public Class PNGSequenceRenderFormat
    Inherits RenderFormat
    Private _path As String
    Public Overrides Sub AddFrame(Frame As Bitmap, FrameNumber As Long)
        Dim p As String = Strings.Left(_path, Len(_path) - Len(BenMisc.GetExtension(_path))) & FrameNumber.ToString.PadLeft(Properties.GetVar("FrameNumberPadding"), "0") & Extension
        Frame.Save((p))
    End Sub

    Public Overrides Sub Cleanup()
        'no streams to close here! (Am I lazy or what!)
    End Sub

    Public Overrides ReadOnly Property Extension As String
        Get
            Return ".png"
        End Get
    End Property

    Public Overrides ReadOnly Property ExtensionTitle As String
        Get
            Return "Portable Network Graphic"
        End Get
    End Property

    Public Overrides Sub InitFile(Path As String, FrameDimenaions As Size)
        _path = Path
    End Sub

    Public Overrides Sub InitProperties()
        Properties.SetVar("FrameNumberPadding", 10)
    End Sub
End Class