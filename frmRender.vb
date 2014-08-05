Public Class frmRender

    Private Sub frmRender_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        If cmdClose.Enabled Then
            Close()
        End If
    End Sub
End Class