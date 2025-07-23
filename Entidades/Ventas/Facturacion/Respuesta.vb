Public Class Respuesta
    Private _resp As Integer
    Private _mensaje As String

    Public Property Resp As Integer
        Get
            Return _resp
        End Get
        Set(value As Integer)
            _resp = value
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
