
Public Interface IModifierSource
    ReadOnly Property TargetTypeName As String
    ReadOnly Property ID As String
    ReadOnly Property Thumbnail As Bitmap
    Function MakeInstance(Clip As Clip) As IModifierInstance
    Function ApplicableToClip(Clip As Clip) As Boolean
End Interface

Public Interface IModifierInstance
    Sub ApplyModifier(input As Object)
    ReadOnly Property Source As IModifierSource
    Property Properties As Properties
End Interface

Public MustInherit Class ModifierInstance(Of T)
    Implements IModifierInstance
    Protected MustOverride Sub ApplyModifier(input As T)
    Public Sub ApplyModifier(input As Object) Implements IModifierInstance.ApplyModifier
        ApplyModifier(input)
    End Sub
    Public MustOverride ReadOnly Property Source As IModifierSource Implements IModifierInstance.Source
    Private _properties As New Properties
    Public Property Properties As Properties Implements IModifierInstance.Properties
        Get
            Return _properties
        End Get
        Set(value As Properties)
            _properties = value
        End Set
    End Property
End Class

Public MustInherit Class ModifierSource(Of T)
    Implements IModifierSource
    Public FrameNumber As Long
    Public ReadOnly Property ID As String Implements IModifierSource.ID
        Get
            Return _id
        End Get
    End Property
    Public ReadOnly Property TargetTypeName As String Implements IModifierSource.TargetTypeName
        Get
            Return GetType(T).Name
        End Get
    End Property
    Protected MustOverride ReadOnly Property _id As String
    Public MustOverride ReadOnly Property Thumbnail As Bitmap Implements IModifierSource.Thumbnail
    Public MustOverride Function ApplicableToClip(Clip As Clip) As Boolean Implements IModifierSource.ApplicableToClip
    Protected MustOverride Function MakeInstanceInternal(Clip As Clip) As ModifierInstance(Of T)
    Public Function MakeInstance(Clip As Clip) As IModifierInstance Implements IModifierSource.MakeInstance
        Return MakeInstanceInternal(Clip)
    End Function
End Class
