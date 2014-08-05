Public Module BuiltInModifiers
    Public ChromaKeyModifier As FrameModifier
    Public Sub Load()
        ChromaKeyModifier = New FrameModifier(AddressOf ChromaKeyModifierFunction, "chromakey")
        Modifiers.Modifiers.Add(ChromaKeyModifier)
    End Sub
    Public Sub ChromaKeyModifierFunction(Input As Bitmap, Properties As Properties)

    End Sub

End Module