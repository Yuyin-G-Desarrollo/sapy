
Public Class SessionGuiaEmbarque

    Private EmbarqueID As Integer
    Private SessionID As Integer

    Public Property PEmbarqueID As Integer
        Get
            Return EmbarqueID
        End Get
        Set(value As Integer)
            EmbarqueID = value
        End Set
    End Property

    Public Property PSessionID As Integer
        Get
            Return SessionID
        End Get
        Set(value As Integer)
            SessionID = value
        End Set
    End Property

End Class
