Public Class GeneracionEmbarque
    Private IdDetalleEntrega As String
    Private UsuarioEmbarque As Integer
    'Private UsuarioEmbarqueNombre As Integer
    Private OperadorEmbarqueId As Integer
    Private OperadorEmbarqueNombre As String
    Private MensajeriaRealId As Integer
    Private MensajeriaRealNombre As String
    Private UnidadEmbarqueId As Integer
    Private UnidadEmbarqueNombre As String
    Private CantidadParesEmbarque As Integer
    Private IdEmbarque As Integer


    Public Property PIdDetalleEntrega As String
        Get
            Return IdDetalleEntrega
        End Get
        Set(value As String)
            IdDetalleEntrega = value
        End Set
    End Property

    Public Property PUsuarioEmbarque As Integer
        Get
            Return UsuarioEmbarque
        End Get
        Set(value As Integer)
            UsuarioEmbarque = value
        End Set
    End Property

    'Public Property PUsuarioEmbarqueNombre As Integer
    '    Get
    '        Return UsuarioEmbarqueNombre
    '    End Get
    '    Set(value As Integer)
    '        UsuarioEmbarqueNombre = value
    '    End Set
    'End Property

    Public Property POperadorEmbarqueId As Integer
        Get
            Return OperadorEmbarqueId
        End Get
        Set(value As Integer)
            OperadorEmbarqueId = value
        End Set
    End Property

    Public Property POperadorEmbarqueNombre As String
        Get
            Return OperadorEmbarqueNombre
        End Get
        Set(value As String)
            OperadorEmbarqueNombre = value
        End Set
    End Property

    Public Property PMensajeriaRealId As Integer
        Get
            Return MensajeriaRealId
        End Get
        Set(value As Integer)
            MensajeriaRealId = value
        End Set
    End Property

    Public Property PMensajeriaRealNombre As String
        Get
            Return MensajeriaRealNombre
        End Get
        Set(value As String)
            MensajeriaRealNombre = value
        End Set
    End Property

    Public Property PUnidadEmbarqueId As Integer
        Get
            Return UnidadEmbarqueId
        End Get
        Set(value As Integer)
            UnidadEmbarqueId = value
        End Set
    End Property

    Public Property PUnidadEmbarqueNombre As String
        Get
            Return UnidadEmbarqueNombre
        End Get
        Set(value As String)
            UnidadEmbarqueNombre = value
        End Set
    End Property

    Public Property PCantidadParesEmbarque As Integer
        Get
            Return CantidadParesEmbarque
        End Get
        Set(value As Integer)
            CantidadParesEmbarque = value
        End Set
    End Property

    Public Property PIdEmbarque As Integer
        Get
            Return IdEmbarque
        End Get
        Set(value As Integer)
            IdEmbarque = value
        End Set
    End Property
End Class
