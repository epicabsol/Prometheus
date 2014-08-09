Module RenderFormats
    Public RenderFormats As New List(Of RenderFormat)
    Public Sub RegisterRenderFormat(Format As RenderFormat)
        RenderFormats.Add(Format)
        Format.InitProperties()
    End Sub
    Public Function BuildRenderFilter() As String
        Dim s As String = ""
        For Each ext As RenderFormat In RenderFormats
            s &= ext.ExtensionTitle & " (*" & ext.Extension & ")|" & "*" & ext.Extension & "|"
        Next
        s = Strings.Left(s, Len(s) - 1) 'chop off the extra pipe character ("|")
        Return s
    End Function
End Module

Public MustInherit Class RenderFormat
    Public Properties As New Properties
    ''' <summary>
    ''' The extension to append to the file name.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Must include the period.</remarks>
    Public MustOverride ReadOnly Property Extension As String
    ''' <summary>
    ''' The text describing the format in the file browser format combobox.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride ReadOnly Property ExtensionTitle As String
    ''' <summary>
    ''' Sets the default value of the properties that the RenderFormat needs to operate.
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub InitProperties()
    Public MustOverride Sub InitFile(Path As String, FrameDimenaions As Size)
    Public MustOverride Sub AddFrame(Frame As Bitmap, FrameNumber As Long)
    Public MustOverride Sub Cleanup()
End Class
