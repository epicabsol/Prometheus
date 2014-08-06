Public Class ChromaKeyModifierInstance
    Inherits ModifierInstance(Of Bitmap)
    Public Property InnerTolerance As Integer
        Set(value As Integer)
            Properties.SetVar("InnerTolerance", value)
        End Set
        Get
            Return Properties.GetVar("InnerTolerance")
        End Get
    End Property
    Public Property OuterTolerance As Integer
        Set(value As Integer)
            Properties.SetVar("OuterTolerance", value)
        End Set
        Get
            Return Properties.GetVar("OuterTolerance")
        End Get
    End Property
    Public Property ChromaColorR As Byte
        Set(value As Byte)
            Properties.SetVar("ChromaColorR", value)
        End Set
        Get
            Return Properties.GetVar("ChromaColorR")
        End Get
    End Property
    Public Property ChromaColorG As Byte
        Set(value As Byte)
            Properties.SetVar("ChromaColorG", value)
        End Set
        Get
            Return Properties.GetVar("ChromaColorG")
        End Get
    End Property
    Public Property ChromaColorB As Byte
        Set(value As Byte)
            Properties.SetVar("ChromaColorB", value)
        End Set
        Get
            Return Properties.GetVar("ChromaColorB")
        End Get
    End Property
    Public Range As Single = 10
    Private Function ProcessPixel(input As Color, chroma As Color, innertolerance As Single, outertolerance As Single) As Byte
        Return 255 * ColorClose(RGB2Cb(input.R, input.G, input.B), RGB2Cr(input.R, input.G, input.B), RGB2Cb(chroma.R, chroma.G, chroma.B), RGB2Cr(chroma.R, chroma.G, chroma.B), innertolerance, outertolerance)
    End Function
    Private Function RGB2Y(r As Byte, g As Byte, b As Byte) As Integer
        Return Math.Round(0.299 * r + 0.587 * g + 0.114 * b)
    End Function
    Private Function RGB2Cb(r As Byte, g As Byte, b As Byte) As Integer
        Return Math.Round(128 + -0.168736 * r - 0.331264 * g + 0.5 * b)
    End Function
    Private Function RGB2Cr(r As Byte, g As Byte, b As Byte) As Integer
        Return Math.Round(128 + 0.5 * r - 0.418688 * g - 0.081312 * b)
    End Function
    Private Function ColorClose(PixelCb As Integer, PixelCr As Integer, ChromaCb As Integer, ChromaCr As Integer, tola As Integer, tolb As Integer) As Double
        'Return 1
        Dim temp As Double = Math.Sqrt((ChromaCb - PixelCb) ^ 2 + (ChromaCr - PixelCr) ^ 2)
        If temp < tola Then
            Return 0
        ElseIf temp < tolb Then
            Return (temp - tola) / (tolb - tola)
        Else
            Return 1
        End If
    End Function

    Protected Overloads Overrides Sub ApplyModifierSpecific(input As Bitmap)
        Dim oldcolor As Color
        For x As Integer = 0 To input.Width - 1
            For y As Integer = 0 To input.Height - 1
                oldcolor = input.GetPixel(x, y)
                input.SetPixel(x, y, Color.FromArgb(ProcessPixel(oldcolor, Color.FromArgb(ChromaColorR, ChromaColorG, ChromaColorB), InnerTolerance, OuterTolerance), oldcolor))
            Next
        Next
    End Sub

    Public Sub New(Source As ChromaKeyModifierSource)
        _source = Source
        InnerTolerance = 6
        OuterTolerance = 15
    End Sub
    Private _source As ChromaKeyModifierSource
    Public Overrides ReadOnly Property Source As IModifierSource
        Get
            Return _source
        End Get
    End Property
End Class

Public Class ChromaKeyModifierSource
    Inherits ModifierSource(Of Bitmap)
    Protected Overrides ReadOnly Property _id As String
        Get
            Return "chromakey"
        End Get
    End Property

    Public Overrides Function ApplicableToClip(Clip As Clip) As Boolean
        Return Clip.Source.Loader.ResourceType = ResourceType.Video Or Clip.Source.Loader.ResourceType = ResourceType.Generator
    End Function

    Protected Overrides Function MakeInstanceInternal(Clip As Clip) As ModifierInstance(Of Bitmap)
        Return New ChromaKeyModifierInstance(Me)
    End Function

    Public Overrides ReadOnly Property Thumbnail As Bitmap
        Get
            Return My.Resources.chromakey
        End Get
    End Property
End Class
