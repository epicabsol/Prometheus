
Public Interface IModifier

End Interface

Public Class Modifier(Of T)
    Public Target As VideoClip
    Public Delegate Sub ModifierDelegate(Input As T, variables As IDictionary(Of String, Object))
    Public ModifierSub As ModifierDelegate
    Public FrameNumber As Long
    Public Sub ApplyModifier(Input As T)
        SetVar("FrameNumber", FrameNumber)
        ModifierSub.Invoke(Input, Variables)
    End Sub
    Public Sub New(ApplyFunction As ModifierDelegate)
        ModifierSub = ApplyFunction
    End Sub
    Public Variables As IDictionary(Of String, Object) = New Generic.Dictionary(Of String, Object)
    Public Function GetVar(name As String) As Object
        If Variables.ContainsKey(name) Then
            Return Variables(name)
        Else
            Return Nothing
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

Public Class FrameModifier
    Inherits Modifier(Of Bitmap)
    Public Sub New(applyFunction As ModifierDelegate)
        MyBase.New(applyFunction)
    End Sub
End Class

Public Class AudioModifier
    Inherits Modifier(Of Double)
    Public Sub New(applyFunction As ModifierDelegate)
        MyBase.New(applyFunction)
    End Sub
End Class