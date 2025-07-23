Public Class PoliticaEmbarque

    Private Ppoliticaembarqueid As Integer
    Public Property politicaembarqueid() As Integer
        Get
            Return Ppoliticaembarqueid
        End Get
        Set(ByVal value As Integer)
            Ppoliticaembarqueid = value
        End Set
    End Property

    Private Plugarentrega As LugarEntrega
    Public Property lugarentrega() As LugarEntrega
        Get
            Return Plugarentrega
        End Get
        Set(ByVal value As LugarEntrega)
            Plugarentrega = value
        End Set
    End Property

    Private Ptipofleje As TipoFleje
    Public Property tipofleje() As TipoFleje
        Get
            Return Ptipofleje
        End Get
        Set(ByVal value As TipoFleje)
            Ptipofleje = value
        End Set
    End Property

    Private Pprotectorfleje As ProtectorFleje
    Public Property protectorfleje() As ProtectorFleje
        Get
            Return Pprotectorfleje
        End Get
        Set(ByVal value As ProtectorFleje)
            Pprotectorfleje = value
        End Set
    End Property

    Private Ptipoempaque As TipoEmpaque
    Public Property tipoempaque() As TipoEmpaque
        Get
            Return Ptipoempaque
        End Get
        Set(ByVal value As TipoEmpaque)
            Ptipoempaque = value
        End Set
    End Property

    'Private Pparesempaque As Integer
    'Public Property paresempaque() As Integer
    '    Get
    '        Return Pparesempaque
    '    End Get
    '    Set(ByVal value As Integer)
    '        Pparesempaque = value
    '    End Set
    'End Property

    'Private Ptipoentrega As TipoEntrega
    'Public Property tipoentrega() As TipoEntrega
    '    Get
    '        Return Ptipoentrega
    '    End Get
    '    Set(ByVal value As TipoEntrega)
    '        Ptipoentrega = value
    '    End Set
    'End Property

    Private Pimprimircajainfocte As Boolean
    Public Property imprimircajainfocte() As Boolean
        Get
            Return Pimprimircajainfocte
        End Get
        Set(ByVal value As Boolean)
            Pimprimircajainfocte = value
        End Set
    End Property

    'Private Pcitaentrega As Boolean
    'Public Property citaentrega() As Boolean
    '    Get
    '        Return Pcitaentrega
    '    End Get
    '    Set(ByVal value As Boolean)
    '        Pcitaentrega = value
    '    End Set
    'End Property

    'Private Pformaentrega As FormaEntrega
    'Public Property formaentrega() As FormaEntrega
    '    Get
    '        Return Pformaentrega
    '    End Get
    '    Set(ByVal value As FormaEntrega)
    '        Pformaentrega = value
    '    End Set
    'End Property

    'Private Phorascitaentrega As Integer
    'Public Property horascitaentrega() As Integer
    '    Get
    '        Return Phorascitaentrega
    '    End Get
    '    Set(ByVal value As Integer)
    '        Phorascitaentrega = value
    '    End Set
    'End Property

    Private Pvalidarcodigoetiqueta As Boolean
    Public Property validarcodigoetiqueta() As Boolean
        Get
            Return Pvalidarcodigoetiqueta
        End Get
        Set(ByVal value As Boolean)
            Pvalidarcodigoetiqueta = value
        End Set
    End Property

    Private Petiquetaembarque As Boolean
    Public Property etiquetaembarque() As Boolean
        Get
            Return Petiquetaembarque
        End Get
        Set(ByVal value As Boolean)
            Petiquetaembarque = value
        End Set
    End Property

    Private Pnotasembarque As String
    Public Property notasembarque() As String
        Get
            Return Pnotasembarque
        End Get
        Set(ByVal value As String)
            Pnotasembarque = value
        End Set
    End Property


    Private PnotasVentas As String
    Public Property notasVentas() As String
        Get
            Return PnotasVentas
        End Get
        Set(ByVal value As String)
            PnotasVentas = value
        End Set
    End Property

    Private Ppapelenvolvente As PapelEnvolvente
    Public Property papelenvolvente() As PapelEnvolvente
        Get
            Return Ppapelenvolvente
        End Get
        Set(ByVal value As PapelEnvolvente)
            Ppapelenvolvente = value
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

    Private PCitaParaEntrega As Boolean
    Public Property CitaParaEntrega() As Boolean
        Get
            Return PCitaParaEntrega
        End Get
        Set(ByVal value As Boolean)
            PCitaParaEntrega = value
        End Set
    End Property

    Private PHorasAnticipacion As Integer
    Public Property HorasAnticipacion() As Integer
        Get
            Return PHorasAnticipacion
        End Get
        Set(ByVal value As Integer)
            PHorasAnticipacion = value
        End Set
    End Property

    Private PDoceneoEspecial As Boolean
    Public Property DoceneoEspecial() As Boolean
        Get
            Return PDoceneoEspecial
        End Get
        Set(ByVal value As Boolean)
            PDoceneoEspecial = value
        End Set
    End Property

    Private PFormaEntregaMercancia As Boolean
    Public Property FormaEntregaMercancia() As Boolean
        Get
            Return PFormaEntregaMercancia
        End Get
        Set(ByVal value As Boolean)
            PFormaEntregaMercancia = value
        End Set
    End Property

    Private PEntregaLotesCompletos As Boolean
    Public Property EntregaLotesCompletos() As Boolean
        Get
            Return PEntregaLotesCompletos
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos = value
        End Set
    End Property

    Private PEntregaLotesCompletos_Tienda As Boolean
    Public Property EntregaLotesCompletos_Tienda() As Boolean
        Get
            Return PEntregaLotesCompletos_Tienda
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos_Tienda = value
        End Set
    End Property

    Private PEntregaLotesCompletos_Modelo As Boolean
    Public Property EntregaLotesCompletos_Modelo() As Boolean
        Get
            Return PEntregaLotesCompletos_Modelo
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos_Modelo = value
        End Set
    End Property

    Private PEntregaLotesCompletos_Piel As Boolean
    Public Property EntregaLotesCompletos_Piel() As Boolean
        Get
            Return PEntregaLotesCompletos_Piel
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos_Piel = value
        End Set
    End Property

    Private PEntregaLotesCompletos_Color As Boolean
    Public Property EntregaLotesCompletos_Color() As Boolean
        Get
            Return PEntregaLotesCompletos_Color
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos_Color = value
        End Set
    End Property

    Private PEntregaLotesCompletos_Corrida As Boolean
    Public Property EntregaLotesCompletos_Corrida() As Boolean
        Get
            Return PEntregaLotesCompletos_Corrida
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos_Corrida = value
        End Set
    End Property

    Private PEntregaLotesCompletos_Pedido As Boolean
    Public Property EntregaLotesCompletos_Pedido() As Boolean
        Get
            Return PEntregaLotesCompletos_Pedido
        End Get
        Set(ByVal value As Boolean)
            PEntregaLotesCompletos_Pedido = value
        End Set
    End Property

End Class
