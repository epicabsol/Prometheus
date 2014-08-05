Module RenderFormats
    Public RenderFormats As New List(Of RenderFormat)
End Module

Public MustInherit Class RenderFormat
    Public MustOverride Sub InitFile(Path As String, Size As Size)
    Public MustOverride Sub AddFrame(Frame As Bitmap)
    Public MustOverride Sub Cleanup()
End Class

