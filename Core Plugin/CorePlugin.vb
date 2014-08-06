﻿<System.ComponentModel.Composition.Export(GetType(Plugin))> _
Public Class CorePlugin
    Inherits Plugin

    Public Overrides Function GetAuthor() As String
        Return "BenTech"
    End Function

    Public Overrides Function GetName() As String
        Return "Core Plugins"
    End Function

    Public ChromaKeyModifier As FrameModifier
    Public Overrides Sub Init(Registrar As Registrar)
        Dim sequenceloader As New ImageSequenceLoader
        Registrar.RegisterSourceLoader(".png", "PNG Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".bmp", "Bitmap Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".jpg", "JPEG Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".tif", "TIFF Image Sequence", sequenceloader)
        Registrar.RegisterSourceLoader(".avi", "AVI Movie", New AviLoader)
        ChromaKeyModifier = New FrameModifier(AddressOf ChromaKeyModifierFunction, "chromakey")
        Registrar.RegisterModifier(ChromaKeyModifier)
    End Sub

    Public Sub ChromaKeyModifierFunction(input As Bitmap, properties As Properties)

    End Sub
End Class

