Public Class ErrorEmbarque
    Private _error As Integer
    Private _mensaje As String

    Public Property [Error] As Integer
        Get
            Return _error
        End Get
        Set(value As Integer)
            _error = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property
End Class
