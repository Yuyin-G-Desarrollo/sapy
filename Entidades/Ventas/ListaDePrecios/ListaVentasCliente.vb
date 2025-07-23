Public Class ListaVentasCliente

    Private listaventasclienteid As Int32
    Private clienteid As Int32
    Private activo As Boolean

    Public Property Plistaventasclienteid As Int32
        Get
            Return listaventasclienteid
        End Get
        Set(value As Int32)
            listaventasclienteid = value
        End Set
    End Property

    Public Property Pclienteid As Int32
        Get
            Return clienteid
        End Get
        Set(value As Int32)
            clienteid = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return activo
        End Get
        Set(value As Boolean)
            activo = value
        End Set
    End Property

End Class
