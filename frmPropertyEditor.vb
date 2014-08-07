Public Class frmPropertyEditor
    Public Sub ReList()
        Dim oldsel As Integer = List.SelectedIndex
        List.Items.Clear()
        For Each entry As KeyValuePair(Of String, Object) In Properties.Variables
            List.Items.Add(entry.Key & " = " & entry.Value)
        Next
        If oldsel < List.Items.Count Then
            List.SelectedIndex = oldsel
        End If
    End Sub
    Public Properties As Properties
    Public Shadows Function ShowDialog(Target As Properties, Name As String) As DialogResult
        Properties = Target
        lblName.Text = Name
        Text = "Property Editor: " & Name
        ReList()
        Return MyBase.ShowDialog
    End Function

    Private Sub XenonButton2_Click(sender As Object, e As EventArgs) Handles XenonButton2.Click
        Close()
    End Sub

    Private Sub List_Resize(sender As Object, e As EventArgs) Handles List.Resize
        List.Invalidate()
    End Sub

    Private Sub List_SelectedIndexChanged(sender As Object, e As EventArgs) Handles List.SelectedIndexChanged
        freezetext = True
        If List.SelectedIndex >= 0 Then
            txtValue.Visible = True
            txtValue.Text = Properties.Variables.ElementAt(List.SelectedIndex).Value
        Else
            txtValue.Text = ""
            txtValue.Visible = False
        End If
        freezetext = False
    End Sub
    Private freezetext As Boolean = False

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged
        If Not freezetext Then
            Try
                Dim name As String = Properties.Variables.ElementAt(List.SelectedIndex).Key
                Properties.Variables.Remove(name)
                Properties.Variables.Add(name, txtValue.Text)
                ReList()
                List.Invalidate()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class