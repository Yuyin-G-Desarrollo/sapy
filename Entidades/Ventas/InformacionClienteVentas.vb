Public Class InformacionClienteVentas

    Private Pinfoclienteid As Integer
    Public Property infoclienteid() As Integer
        Get
            Return Pinfoclienteid
        End Get
        Set(ByVal value As Integer)
            Pinfoclienteid = value
        End Set
    End Property

    Private Pfechafundacion As DateTime
    Public Property fechafundacion() As DateTime
        Get
            Return Pfechafundacion
        End Get
        Set(ByVal value As DateTime)
            Pfechafundacion = value
        End Set
    End Property

    Private Pfestejaaniversario As Boolean
    Public Property festejaaniversario() As Boolean
        Get
            Return Pfestejaaniversario
        End Get
        Set(ByVal value As Boolean)
            Pfestejaaniversario = value
        End Set
    End Property

    Private Pfestejadiasfestivos As Boolean
    Public Property festejadiasfestivos() As Boolean
        Get
            Return Pfestejadiasfestivos
        End Get
        Set(ByVal value As Boolean)
            Pfestejadiasfestivos = value
        End Set
    End Property

    Private Pcapacidadcompratotal As Integer
    Public Property capacidadcompratotal() As Integer
        Get
            Return Pcapacidadcompratotal
        End Get
        Set(ByVal value As Integer)
            Pcapacidadcompratotal = value
        End Set
    End Property

    Private Pcapacidadcomprayuyin As Integer
    Public Property capacidadcomprayuyin() As Integer
        Get
            Return Pcapacidadcomprayuyin
        End Get
        Set(ByVal value As Integer)
            Pcapacidadcomprayuyin = value
        End Set
    End Property

    Private Ppublicidadcliente As String
    Public Property publicidadcliente() As String
        Get
            Return Ppublicidadcliente
        End Get
        Set(ByVal value As String)
            Ppublicidadcliente = value
        End Set
    End Property

    Private Pnivelsocioeconomico As NivelSocioEconomico
    Public Property nivelsocioeconomico() As NivelSocioEconomico
        Get
            Return Pnivelsocioeconomico
        End Get
        Set(ByVal value As NivelSocioEconomico)
            Pnivelsocioeconomico = value
        End Set
    End Property

    Private Pcontactoinicial As Boolean
    Public Property contactoinicial() As Boolean
        Get
            Return Pcontactoinicial
        End Get
        Set(ByVal value As Boolean)
            Pcontactoinicial = value
        End Set
    End Property

    Private Pbuscamoscliente As Boolean
    Public Property buscamoscliente() As Boolean
        Get
            Return Pbuscamoscliente
        End Get
        Set(ByVal value As Boolean)
            Pbuscamoscliente = value
        End Set
    End Property

    Private Ptienepedidoinicial As Boolean
    Public Property tienepedidoinicial() As Boolean
        Get
            Return Ptienepedidoinicial
        End Get
        Set(ByVal value As Boolean)
            Ptienepedidoinicial = value
        End Set
    End Property

    Private Particulospedidoinicial As String
    Public Property articulospedidoinicial() As String
        Get
            Return Particulospedidoinicial
        End Get
        Set(ByVal value As String)
            Particulospedidoinicial = value
        End Set
    End Property

    Private Pfechaentregapedidoinicial As DateTime
    Public Property fechaentregapedidoinicial() As DateTime
        Get
            Return Pfechaentregapedidoinicial
        End Get
        Set(ByVal value As DateTime)
            Pfechaentregapedidoinicial = value
        End Set
    End Property

    Private Pparespedidoinicial As Integer
    Public Property parespedidoinicial() As Integer
        Get
            Return Pparespedidoinicial
        End Get
        Set(ByVal value As Integer)
            Pparespedidoinicial = value
        End Set
    End Property

    Private Psitioaccesoproveedor As String
    Public Property sitioaccesoproveedor() As String
        Get
            Return Psitioaccesoproveedor
        End Get
        Set(ByVal value As String)
            Psitioaccesoproveedor = value
        End Set
    End Property

    Private Pusuarioproveedor As String
    Public Property usuarioproveedor() As String
        Get
            Return Pusuarioproveedor
        End Get
        Set(ByVal value As String)
            Pusuarioproveedor = value
        End Set
    End Property

    Private Pcontrasenaproveedor As String
    Public Property contrasenaproveedor() As String
        Get
            Return Pcontrasenaproveedor
        End Get
        Set(ByVal value As String)
            Pcontrasenaproveedor = value
        End Set
    End Property

    Private Palmacen As Almacen
    Public Property almacen() As Almacen
        Get
            Return Palmacen
        End Get
        Set(ByVal value As Almacen)
            Palmacen = value
        End Set
    End Property

    Private Ppersona As Persona
    Public Property persona() As Persona
        Get
            Return Ppersona
        End Get
        Set(ByVal value As Persona)
            Ppersona = value
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
