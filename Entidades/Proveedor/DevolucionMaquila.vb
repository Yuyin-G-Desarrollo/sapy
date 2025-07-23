Public Class DevolucionMaquila
    Private idComprobante_ As Integer
    Public Property idComprobante() As Integer
        Get
            Return idComprobante_
        End Get
        Set(ByVal value As Integer)
            idComprobante_ = value
        End Set
    End Property

    Private idDevolucionDetalle_ As Integer
    Public Property idDevolucionDetalle() As Integer
        Get
            Return idDevolucionDetalle_
        End Get
        Set(ByVal value As Integer)
            idDevolucionDetalle_ = value
        End Set
    End Property
    Private pares_ As Integer
    Public Property pares() As Integer
        Get
            Return pares_
        End Get
        Set(ByVal value As Integer)
            pares_ = value
        End Set
    End Property
    Private idcadena_ As Integer
    Public Property idCadena() As Integer
        Get
            Return idcadena_
        End Get
        Set(ByVal value As Integer)
            idcadena_ = value
        End Set
    End Property

    Private precio_ As Double
    Public Property precio() As Double
        Get
            Return precio_
        End Get
        Set(ByVal value As Double)
            precio_ = value
        End Set
    End Property
    Private total_ As Double
    Public Property total() As Double
        Get
            Return precio_
        End Get
        Set(ByVal value As Double)
            precio_ = value
        End Set
    End Property
    Private descripcion_ As String
    Public Property descripcion() As String
        Get
            Return descripcion_
        End Get
        Set(ByVal value As String)
            descripcion_ = value
        End Set
    End Property
    Private codigo_ As String
    Public Property codigo() As String
        Get
            Return codigo_
        End Get
        Set(ByVal value As String)
            codigo_ = value
        End Set
    End Property

    Private usuario_ As String
    Public Property usuario() As String
        Get
            Return usuario_
        End Get
        Set(ByVal value As String)
            usuario_ = value
        End Set
    End Property

End Class
