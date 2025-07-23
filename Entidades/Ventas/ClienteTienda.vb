Public Class ClienteTienda

    Private Pclientetipotiendaid As Integer
    Public Property clientetipotiendaid() As Integer
        Get
            Return Pclientetipotiendaid
        End Get
        Set(ByVal value As Integer)
            Pclientetipotiendaid = value
        End Set
    End Property

    Private Pnumtiendas As Integer
    Public Property numtiendasreal() As Integer
        Get
            Return Pnumtiendas
        End Get
        Set(ByVal value As Integer)
            Pnumtiendas = value
        End Set
    End Property

    Private Pmarcaje As Integer
    Public Property marcaje() As Integer
        Get
            Return Pmarcaje
        End Get
        Set(ByVal value As Integer)
            Pmarcaje = value
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

    Private Ptipotienda As TipoTienda
    Public Property tipotienda() As TipoTienda
        Get
            Return Ptipotienda
        End Get
        Set(ByVal value As TipoTienda)
            Ptipotienda = value
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
