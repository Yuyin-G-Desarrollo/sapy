Public Class DescuentoCliente

    Private Pdescuentosclienteid As Integer
    Public Property descuentosclienteid() As Integer
        Get
            Return Pdescuentosclienteid
        End Get
        Set(ByVal value As Integer)
            Pdescuentosclienteid = value
        End Set
    End Property

    Private Pmotivodescuento As MotivoDescuento
    Public Property motivodescuento() As MotivoDescuento
        Get
            Return Pmotivodescuento
        End Get
        Set(ByVal value As MotivoDescuento)
            Pmotivodescuento = value
        End Set
    End Property

    Private Plugardescuento As LugarDescuento
    Public Property lugardescuento() As LugarDescuento
        Get
            Return Plugardescuento
        End Get
        Set(ByVal value As LugarDescuento)
            Plugardescuento = value
        End Set
    End Property

    Private Pdiasplazo As Integer
    Public Property diasplazo() As Integer
        Get
            Return Pdiasplazo
        End Get
        Set(ByVal value As Integer)
            Pdiasplazo = value
        End Set
    End Property

    Private Pdescuentoenporcentaje As Boolean
    Public Property descuentoenporcentaje() As Boolean
        Get
            Return Pdescuentoenporcentaje
        End Get
        Set(ByVal value As Boolean)
            Pdescuentoenporcentaje = value
        End Set
    End Property

    Private Pcantidaddescuento As Decimal
    Public Property cantidaddescuento() As Decimal
        Get
            Return Pcantidaddescuento
        End Get
        Set(ByVal value As Decimal)
            Pcantidaddescuento = value
        End Set
    End Property

    Private Paplicaencadenado As Boolean
    Public Property aplicaencadenado() As Boolean
        Get
            Return Paplicaencadenado
        End Get
        Set(ByVal value As Boolean)
            Paplicaencadenado = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property

End Class
