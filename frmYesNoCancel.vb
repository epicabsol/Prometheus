Imports System.Windows.Forms

Public Class frmYesNoCancel
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmYesNoCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Overloads Function ShowDialog(Message As String, Title As String) As DialogResult
        Text = Title
        Label1.Text = Message
        Return MyBase.ShowDialog()
    End Function
    'Private TheResult As DialogResult
    'Private Chosen As Boolean

    Private Sub XenonButton1_Click(sender As Object, e As EventArgs) Handles XenonButton1.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class
