Module CustomCursors
    Private _cursor_addclip As Cursor
    Public ReadOnly Property cursor_addclip As Cursor
        Get
            If IsNothing(_cursor_addclip) Then
                _cursor_addclip = New Cursor("Resources\cursor_addclip.cur")
            End If
            Return _cursor_addclip
        End Get
    End Property
    Private _cursor_deleteclip As Cursor
    Public ReadOnly Property cursor_deleteclip As Cursor
        Get
            If IsNothing(_cursor_deleteclip) Then
                _cursor_deleteclip = New Cursor("Resources\cursor_deleteclip.cur")
            End If
            Return _cursor_deleteclip
        End Get
    End Property
    Private _cursor_leftcrop As Cursor
    Public ReadOnly Property cursor_leftcrop As Cursor
        Get
            If IsNothing(_cursor_leftcrop) Then
                _cursor_leftcrop = New Cursor("Resources\cursor_leftcrop.cur")
            End If
            Return _cursor_leftcrop
        End Get
    End Property
    Private _cursor_leftmove As Cursor
    Public ReadOnly Property cursor_leftmove As Cursor
        Get
            If IsNothing(_cursor_leftmove) Then
                _cursor_leftmove = New Cursor("Resources\cursor_leftmove.cur")
            End If
            Return _cursor_leftmove
        End Get
    End Property
    Private _cursor_rightcrop As Cursor
    Public ReadOnly Property cursor_rightcrop As Cursor
        Get
            If IsNothing(_cursor_rightcrop) Then
                _cursor_rightcrop = New Cursor("Resources\cursor_rightcrop.cur")
            End If
            Return _cursor_rightcrop
        End Get
    End Property
    Private _cursor_rightstretch As Cursor
    Public ReadOnly Property cursor_rightstretch As Cursor
        Get
            If IsNothing(_cursor_rightstretch) Then
                _cursor_rightstretch = New Cursor("Resources\cursor_rightstretch.cur")
            End If
            Return _cursor_rightstretch
        End Get
    End Property
End Module
