Public Class PoliticaVenta

    Private Ppoliticaventaid As Integer
    Public Property politicaventaid() As Integer
        Get
            Return Ppoliticaventaid
        End Get
        Set(ByVal value As Integer)
            Ppoliticaventaid = value
        End Set
    End Property

    Private Pconfirmarpedido As Boolean
    Public Property confirmarpedido() As Boolean
        Get
            Return Pconfirmarpedido
        End Get
        Set(ByVal value As Boolean)
            Pconfirmarpedido = value
        End Set
    End Property

    Private Phorasconfirmapedido As Integer
    Public Property horasconfirmapedido() As Integer
        Get
            Return Phorasconfirmapedido
        End Get
        Set(ByVal value As Integer)
            Phorasconfirmapedido = value
        End Set
    End Property

    Private Pimportemaxventa As Decimal
    Public Property importemaxventa() As Decimal
        Get
            Return Pimportemaxventa
        End Get
        Set(ByVal value As Decimal)
            Pimportemaxventa = value
        End Set
    End Property

    Private Punidadventa As UnidadVenta
    Public Property unidadventa() As UnidadVenta
        Get
            Return Punidadventa
        End Get
        Set(ByVal value As UnidadVenta)
            Punidadventa = value
        End Set
    End Property

    Private Pventaminima As Integer
    Public Property ventaminima() As Integer
        Get
            Return Pventaminima
        End Get
        Set(ByVal value As Integer)
            Pventaminima = value
        End Set
    End Property

    Private Pnotasventas As String
    Public Property notasventas() As String
        Get
            Return Pnotasventas
        End Get
        Set(ByVal value As String)
            Pnotasventas = value
        End Set
    End Property

    Private Pcitaentrega As Boolean
    Public Property citaentrega() As Boolean
        Get
            Return Pcitaentrega
        End Get
        Set(ByVal value As Boolean)
            Pcitaentrega = value
        End Set
    End Property

    Private Ptiempoanticipacionentrega As String
    Public Property tiempoanticipacionentrega() As String
        Get
            Return Ptiempoanticipacionentrega
        End Get
        Set(ByVal value As String)
            Ptiempoanticipacionentrega = value
        End Set
    End Property

    Private Pincoterm As String
    Public Property incoterm() As String
        Get
            Return Pincoterm
        End Get
        Set(ByVal value As String)
            Pincoterm = value
        End Set
    End Property

    Private Pvalidarcodigoetiqueta As Boolean
    Public Property validarcodigoetiqueta() As Boolean
        Get
            Return Pvalidarcodigoetiqueta
        End Get
        Set(ByVal value As Boolean)
            Pvalidarcodigoetiqueta = value
        End Set
    End Property

    Private Pentregamercanciasinfacturar As Boolean
    Public Property entregamercanciasinfacturar() As Boolean
        Get
            Return Pentregamercanciasinfacturar
        End Get
        Set(ByVal value As Boolean)
            Pentregamercanciasinfacturar = value
        End Set
    End Property

    Private Pimprimirdirecciontienda As Boolean
    Public Property imprimirdirecciontienda() As Boolean
        Get
            Return Pimprimirdirecciontienda
        End Get
        Set(ByVal value As Boolean)
            Pimprimirdirecciontienda = value
        End Set
    End Property

    Private Pimprimirocfacturar As Boolean
    Public Property imprimirocfacturar() As Boolean
        Get
            Return Pimprimirocfacturar
        End Get
        Set(ByVal value As Boolean)
            Pimprimirocfacturar = value
        End Set
    End Property

    Private Pimprimirtiendafacturar As Boolean
    Public Property imprimirtiendafacturar() As Boolean
        Get
            Return Pimprimirtiendafacturar
        End Get
        Set(ByVal value As Boolean)
            Pimprimirtiendafacturar = value
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


    Private PCodigoAMECE As Boolean
    Public Property CodigoAMECE() As Boolean
        Get
            Return PCodigoAMECE
        End Get
        Set(ByVal value As Boolean)
            PCodigoAMECE = value
        End Set
    End Property


    Private PcorreoConfirmacionPedido As Integer
    Public Property correoConfirmacionPedido() As Integer
        Get
            Return PcorreoConfirmacionPedido
        End Get
        Set(ByVal value As Integer)
            PcorreoConfirmacionPedido = value
        End Set
    End Property

    Private PtipoApartado As Integer
    Public Property tipoApartado() As Integer
        Get
            Return PtipoApartado
        End Get
        Set(ByVal value As Integer)
            PtipoApartado = value
        End Set
    End Property

    Private PnotasApartado As String
    Public Property notasApartado() As String
        Get
            Return PnotasApartado
        End Get
        Set(ByVal value As String)
            PnotasApartado = value
        End Set
    End Property

    Private PrenglonesFacturar As Integer
    Public Property renglonesFacturar() As Integer
        Get
            Return PrenglonesFacturar
        End Get
        Set(ByVal value As Integer)
            PrenglonesFacturar = value
        End Set
    End Property

    Private PDescripcionEspecialDocumento As Boolean
    Public Property DescripcionEspecialDocumento() As Boolean
        Get
            Return PDescripcionEspecialDocumento
        End Get
        Set(ByVal value As Boolean)
            PDescripcionEspecialDocumento = value
        End Set
    End Property

End Class
