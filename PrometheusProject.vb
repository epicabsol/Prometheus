
Public Class PrometheusProject
    Public SavedYet As Boolean = False
    Public Dirty As Boolean = True
    Public SourceVideoClips As New List(Of VideoSourceClip)
    Public VideoClips As New List(Of VideoClip)
    Public AudioClips As New List(Of AudioClip)
    Public FinalSize As New Size(640, 480)
    Public Function BuildFrame(number As Long) As Bitmap
        Dim result As New Bitmap(FinalSize.Width, FinalSize.Height)
        Dim g As Graphics = Graphics.FromImage(result)
        Dim OrderedVideoClips As New List(Of VideoClip)(VideoClips)

        OrderedVideoClips.Sort(Clip.Comparer)

        Dim clipframe As Bitmap
        For Each vc As VideoClip In OrderedVideoClips
            If vc.HitTest(number, False) Then
                clipframe = vc.GetFinalFrame(number - vc.StartFrame)
                g.DrawImage(clipframe, vc.Position.X, vc.Position.Y, clipframe.Width, clipframe.Height)
                clipframe.Dispose()
            End If
        Next
        OrderedVideoClips = Nothing

        g.Dispose()
        Return result
    End Function
End Class
