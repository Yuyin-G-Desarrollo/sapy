Public Class Cliente

    Private Pclienteid As Integer
    Public Property clienteid() As Integer
        Get
            Return Pclienteid
        End Get
        Set(ByVal value As Integer)
            Pclienteid = value
        End Set
    End Property

    Private Pidsicy As Integer
    Public Property idsicy() As Integer
        Get
            Return Pidsicy
        End Get
        Set(ByVal value As Integer)
            Pidsicy = value
        End Set
    End Property


    Private Pstatuscliente As String
    Public Property statuscliente() As String
        Get
            Return Pstatuscliente
        End Get
        Set(ByVal value As String)
            Pstatuscliente = value
        End Set
    End Property

    Private Pclienteespecial As Boolean
    Public Property clienteespecial() As Boolean
        Get
            Return Pclienteespecial
        End Get
        Set(ByVal value As Boolean)
            Pclienteespecial = value
        End Set
    End Property

    Private PClientePreferente As Boolean
    Public Property clientepreferente() As Boolean
        Get
            Return PClientePreferente
        End Get
        Set(ByVal value As Boolean)
            PClientePreferente = value
        End Set
    End Property

    Private Pprecioespecial As Boolean
    Public Property precioespecial() As Boolean
        Get
            Return Pprecioespecial
        End Get
        Set(ByVal value As Boolean)
            Pprecioespecial = value
        End Set
    End Property

    Private Pnombregenerico As String
    Public Property nombregenerico() As String
        Get
            Return Pnombregenerico
        End Get
        Set(ByVal value As String)
            Pnombregenerico = value
        End Set
    End Property

    Private Prazonsocial As String
    Public Property razonsocial() As String
        Get
            Return Prazonsocial
        End Get
        Set(ByVal value As String)
            Prazonsocial = value
        End Set
    End Property

    Private Pranking As String
    Public Property ranking() As String
        Get
            Return Pranking
        End Get
        Set(ByVal value As String)
            Pranking = value
        End Set
    End Property

    Private Pclaveyuyinproveedor As String
    Public Property claveyuyinproveedor() As String
        Get
            Return Pclaveyuyinproveedor
        End Get
        Set(ByVal value As String)
            Pclaveyuyinproveedor = value
        End Set
    End Property

    Private Pclasificacionpersona As ClasificacionPersona
    Public Property clasificacionpersona() As ClasificacionPersona
        Get
            Return Pclasificacionpersona
        End Get
        Set(ByVal value As ClasificacionPersona)
            Pclasificacionpersona = value
        End Set
    End Property

    Private Pclasificacioncliente As String
    Public Property clasificacioncliente() As String
        Get
            Return Pclasificacioncliente
        End Get
        Set(ByVal value As String)
            Pclasificacioncliente = value
        End Set
    End Property

    Private Ppersonacliente As Persona
    Public Property personacliente() As Persona
        Get
            Return Ppersonacliente
        End Get
        Set(ByVal value As Persona)
            Ppersonacliente = value
        End Set
    End Property

    Private Pruta As Ruta
    Public Property ruta() As Ruta
        Get
            Return Pruta
        End Get
        Set(ByVal value As Ruta)
            Pruta = value
        End Set
    End Property

    Private Pcolaborador_atnc As Colaborador
    Public Property colaborador_atnc() As Colaborador
        Get
            Return Pcolaborador_atnc
        End Get
        Set(ByVal value As Colaborador)
            Pcolaborador_atnc = value
        End Set
    End Property

    Private Pcolaborador_vendedor As Colaborador
    Public Property colaborador_vendedor() As Colaborador
        Get
            Return Pcolaborador_vendedor
        End Get
        Set(ByVal value As Colaborador)
            Pcolaborador_vendedor = value
        End Set
    End Property

    Private Pcomentarios As String
    Public Property comentarios() As String
        Get
            Return Pcomentarios
        End Get
        Set(ByVal value As String)
            Pcomentarios = value
        End Set
    End Property

    Private Pempresa As Empresa
    Public Property empresa() As Empresa
        Get
            Return Pempresa
        End Get
        Set(ByVal value As Empresa)
            Pempresa = value
        End Set
    End Property

    Private Ptipocliente As TipoCliente
    Public Property tipocliente() As TipoCliente
        Get
            Return Ptipocliente
        End Get
        Set(ByVal value As TipoCliente)
            Ptipocliente = value
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

    Private PPedidoStockWeb As Boolean
    Public Property PedidoStockWeb As Boolean
        Get
            Return PPedidoStockWeb
        End Get
        Set(value As Boolean)
            PPedidoStockWeb = value
        End Set
    End Property

    Private PPuedeApartar As Boolean
    Public Property PuedeApartar() As Boolean
        Get
            Return PPuedeApartar
        End Get
        Set(ByVal value As Boolean)
            PPuedeApartar = value
        End Set
    End Property

    Private PPMoneda As Entidades.Moneda
    Public Property Moneda() As Entidades.Moneda
        Get
            Return PPMoneda
        End Get
        Set(ByVal value As Entidades.Moneda)
            PPMoneda = value
        End Set
    End Property

    Private PTipoIVA As Integer
    Public Property TipoIVA() As Integer
        Get
            Return PTipoIVA
        End Get
        Set(ByVal value As Integer)
            PTipoIVA = value
        End Set
    End Property

    Private PTipoArchivoDistribucionTiendas As String
    Public Property TipoArchivoDistribucionTiendas() As String
        Get
            Return PTipoArchivoDistribucionTiendas
        End Get
        Set(ByVal value As String)
            PTipoArchivoDistribucionTiendas = value
        End Set
    End Property

    Private PComercializadoraId As Integer
    Public Property ComercializadoraId() As Integer
        Get
            Return PComercializadoraId
        End Get
        Set(ByVal value As Integer)
            PComercializadoraId = value
        End Set
    End Property

End Class
