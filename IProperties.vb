Public Class Properties
    Public Variables As IDictionary(Of String, Object) = New Generic.Dictionary(Of String, Object)
    Public Function GetVar(name As String) As Object
        If Variables.ContainsKey(name) Then
            Return Variables(name)
        Else
            Return 0
        End If
    End Function
    Public Sub SetVar(name As String, value As Object)
        If Variables.ContainsKey(name) Then
            Variables(name) = value
        Else
            Variables.Add(name, value)
        End If
    End Sub
End Class
