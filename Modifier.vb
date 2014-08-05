
Public Interface IModifier
    ReadOnly Property TargetType As String
    ReadOnly Property ID As String
End Interface

Public Class Modifier(Of T)
    Implements IModifier
    Public Target As Clip
    Public Delegate Sub ModifierDelegate(Input As T, Properties As Properties)
    Public ModifierSub As ModifierDelegate
    Public FrameNumber As Long
    Public Sub ApplyModifier(Input As T, Properties As Properties)
        ModifierSub.Invoke(Input, Properties)
    End Sub
    Public Sub New(ApplyFunction As ModifierDelegate, ID As String)
        ModifierSub = ApplyFunction
        _id = ID
    End Sub
    Private _id As String
    Public ReadOnly Property ID As String Implements IModifier.ID
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property TargetType As String Implements IModifier.TargetType
        Get
            Return GetType(T).Name
        End Get
    End Property
End Class

Public Class FrameModifier
    Inherits Modifier(Of Bitmap)
    Public Sub New(applyFunction As ModifierDelegate, id As String)
        MyBase.New(applyFunction, id)
    End Sub
End Class

Public Class AudioModifier
    Inherits Modifier(Of Double)
    Public Sub New(applyFunction As ModifierDelegate, id As String)
        MyBase.New(applyFunction, id)
    End Sub
End Class