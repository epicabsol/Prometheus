<System.ComponentModel.Composition.Export(GetType(Plugin))> _
Public Class CorePlugin
    Inherits Plugin

    Public Overrides Function GetAuthor() As String
        Return "BenTech"
    End Function

    Public Overrides Function GetName() As String
        Return "Core Plugins"
    End Function

    Public Overrides Sub Init(Registrar As Registrar)
        Dim sequenceloader As New ImageSequenceLoader
        Registrar.RegisterSourceLoader(".png", "PNG Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".bmp", "Bitmap Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".jpg", "JPEG Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".tif", "TIFF Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".avi", "AVI Movie", New AviLoader)
    End Sub
End Class

