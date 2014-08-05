Public Class Clip
    Public Properties As New Properties
    Public Shared Comparer As New ClipTrackComparer
    ''' <summary>
    ''' The first frame of the clip.
    ''' </summary>
    ''' <remarks>Inclusive.</remarks>
    Public StartFrame As Long
    ''' <summary>
    ''' The last frame of the clip.
    ''' </summary>
    ''' <remarks>Inclusive.</remarks>
    Public EndFrame As Long
    Public CropStart As Long
    Public CropEnd As Long
    ''' <summary>
    ''' The length of the clip in frames.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>(EndFrame - StartFrame) + 1</remarks>
    Public Property Length As Long
        Get
            Return (EndFrame - StartFrame) + 1
        End Get
        Set(value As Long)
            EndFrame = StartFrame + value - 1
        End Set
    End Property
    ''' <summary>
    ''' Decides which part of the clip is under the given coordinate.
    ''' </summary>
    ''' <param name="X">Local X-coodinate of the point to test.</param>
    ''' <param name="Y">Local Y-coordinate of the point to test.</param>
    ''' <param name="Scale">Pixels per frame.</param>
    ''' <param name="Height">Height of the clip.</param>
    ''' <returns>A ClipPart value which specifies which area of the clip was hit.</returns>
    ''' <remarks></remarks>
    Public Function HitTestParts(X As Integer, Y As Integer, Scale As Double, Height As Single) As ClipPart
        Dim TopRect As New Rectangle(Scale * CropStart, 0, (Length - CropStart - CropEnd) * Scale - 11, Height / 2)
        If TopRect.Contains(X, Y) Then
            Dim LeftCropRect As New Rectangle(Scale * CropStart, 0, 11, Height \ 2)
            If LeftCropRect.Contains(X, Y) Then
                Return ClipPart.StartCropHandle
            End If
            Dim RightCropRect As New Rectangle(TopRect.Right - 11, 0, 11, Height \ 2)
            If RightCropRect.Contains(X, Y) Then
                Return ClipPart.EndCropHandle
            End If

            Return ClipPart.TopHalf
        End If
        Dim BottomRect As New Rectangle(0, Height \ 2, Length * Scale, Height / 2)
        If BottomRect.Contains(X, Y) Then
            Dim LeftMoveRect As New Rectangle(0, Height \ 2, 11, Height \ 2)
            If LeftMoveRect.Contains(X, Y) Then
                Return ClipPart.StartFrameHandle
            End If
            Dim RightScaleRect As New Rectangle(BottomRect.Right - 11, Height \ 2, 11, Height \ 2)
            If RightScaleRect.Contains(X, Y) Then
                Return ClipPart.ScaleHandle
            End If
            Return ClipPart.BottomHalf
        End If
        Return ClipPart.Void
    End Function
    Public Function HitTest(Frame As Long, Optional IncludeClipped As Boolean = True) As Boolean
        Return ((Frame >= StartFrame + IIf(IncludeClipped, 0, CropStart)) AndAlso (Frame <= EndFrame - 1 - IIf(IncludeClipped, 0, CropEnd)))
    End Function
    Public Track As Long = 0
    Public Enum ClipPart As Byte
        Void = 0
        TopHalf = 10
        StartCrop
        StartCropHandle
        EndCrop
        EndCropHandle
        BottomHalf = 20
        Preview
        Name
        StartFrame
        StartFrameHandle
        Scale
        ScaleHandle
    End Enum
    Public Source As SourceClip
End Class

Public Class ModifierBinding
    Public Modifier As IModifier
    Public Properties As Properties
End Class

Public Class ClipTrackComparer
    Implements IComparer(Of Clip)
    Public Function Compare(x As Clip, y As Clip) As Integer Implements IComparer(Of Clip).Compare
        Return Comparer(Of Long).Default.Compare(x.Track, y.Track) * -1
    End Function
End Class

Public Class VideoClip
    Inherits Clip
    Public Modifiers As New List(Of ModifierBinding)
    Public Speed As Double = 1.0
    Public Property X As Single
        Get
            Return Properties.GetVar("X")
        End Get
        Set(value As Single)
            Properties.SetVar("X", value)
        End Set
    End Property
    Public Property Y As Single
        Get
            Return Properties.GetVar("Y")
        End Get
        Set(value As Single)
            Properties.SetVar("Y", value)
        End Set
    End Property
    Public Property Position As PointF
        Get
            Return New Point(X, Y)
        End Get
        Set(value As PointF)
            X = value.X
            Y = value.Y
        End Set
    End Property
    Public Property Width As Single
        Get
            Return Properties.GetVar(Width)
        End Get
        Set(value As Single)
            Properties.SetVar("Width", value)
        End Set
    End Property
    Public Property Height As Single
        Get
            Return Properties.GetVar("Height")
        End Get
        Set(value As Single)
            Properties.SetVar("Height", value)
        End Set
    End Property
    Public Property Size As Size
        Get
            Return New Size(Width, Height)
        End Get
        Set(value As Size)
            Width = value.Width
            Height = value.Height
        End Set
    End Property
    'Public Source As VideoSourceClip
    Public Sub New(Source As VideoSourceClip, StartFrame As Long)
        Me.StartFrame = StartFrame
        Me.Source = Source
        Me.EndFrame = StartFrame + Source.Length - 1
    End Sub
    Public Shadows Property Source As VideoSourceClip
        Get
            Return MyBase.Source
        End Get
        Set(value As VideoSourceClip)
            MyBase.Source = value
        End Set
    End Property
    Public Function GetFinalFrame(Number As Long) As Bitmap
        Dim b As New Bitmap(Source.GetRawFrame(Math.Floor(Number * Speed)))
        For Each m As ModifierBinding In Modifiers
            m.Properties.SetVar("Frame", Number)
            CType(m.Modifier, FrameModifier).ApplyModifier(b, m.Properties)
        Next
        Return b
    End Function
End Class

Public Class AudioClip
    Inherits Clip
End Class