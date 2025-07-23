Public Class FacturacionDatosCliente

    Private PClienteID As Integer
    Public Property ClienteID() As Integer
        Get
            Return PClienteID
        End Get
        Set(ByVal value As Integer)
            PClienteID = value
        End Set
    End Property


    Private PCliente As String
    Public Property Cliente() As String
        Get
            Return PCliente
        End Get
        Set(ByVal value As String)
            PCliente = value
        End Set
    End Property


    Private PPorcentajeFacturacion As Integer
    Public Property PorcentajeFacturacion() As Integer
        Get
            Return PPorcentajeFacturacion
        End Get
        Set(ByVal value As Integer)
            PPorcentajeFacturacion = value
        End Set
    End Property

    Private PPorcentajeRemision As Integer
    Public Property PorcentajeRemision() As Integer
        Get
            Return PPorcentajeRemision
        End Get
        Set(ByVal value As Integer)
            PPorcentajeRemision = value
        End Set
    End Property

    Private PMonedaID As Integer
    Public Property MonedaID() As Integer
        Get
            Return PMonedaID
        End Get
        Set(ByVal value As Integer)
            PMonedaID = value
        End Set
    End Property

    Private PMoneda As String
    Public Property Moneda() As String
        Get
            Return PMoneda
        End Get
        Set(ByVal value As String)
            PMoneda = value
        End Set
    End Property

    Private PPlazo As Integer
    Public Property Plazo() As Integer
        Get
            Return PPlazo
        End Get
        Set(ByVal value As Integer)
            PPlazo = value
        End Set
    End Property

    Private PMontoMaximoFacturacion As Double
    Public Property MontoMaximoFacturacion() As Double
        Get
            Return PMontoMaximoFacturacion
        End Get
        Set(ByVal value As Double)
            PMontoMaximoFacturacion = value
        End Set
    End Property

    Private PRestriccionID As Integer
    Public Property RestriccionID() As Integer
        Get
            Return PRestriccionID
        End Get
        Set(ByVal value As Integer)
            PRestriccionID = value
        End Set
    End Property

    Private PRestriccion As String
    Public Property Restriccion() As String
        Get
            Return PRestriccion
        End Get
        Set(ByVal value As String)
            PRestriccion = value
        End Set
    End Property

    Private PFacturarPorMarca As String
    Public Property FacturarPorMarca() As String
        Get
            Return PFacturarPorMarca
        End Get
        Set(ByVal value As String)
            PFacturarPorMarca = value
        End Set
    End Property

    Private PEmpresaID As Integer
    Public Property EmpresaID() As Integer
        Get
            Return PEmpresaID
        End Get
        Set(ByVal value As Integer)
            PEmpresaID = value
        End Set
    End Property

    Private PEmpresa As String
    Public Property Empresa() As String
        Get
            Return PEmpresa
        End Get
        Set(ByVal value As String)
            PEmpresa = value
        End Set
    End Property

    Private PEmpresaRFC As String
    Public Property EmpresaRFC() As String
        Get
            Return PEmpresaRFC
        End Get
        Set(ByVal value As String)
            PEmpresaRFC = value
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

    Private PIVA As String
    Public Property IVA() As String
        Get
            Return PIVA
        End Get
        Set(ByVal value As String)
            PIVA = value
        End Set
    End Property

    Private PImprimirTienda As Boolean
    Public Property ImprimirTienda() As Boolean
        Get
            Return PImprimirTienda
        End Get
        Set(ByVal value As Boolean)
            PImprimirTienda = value
        End Set
    End Property

    Private PImprimirOC As Boolean
    Public Property ImprimirOC() As Boolean
        Get
            Return PImprimirOC
        End Get
        Set(ByVal value As Boolean)
            PImprimirOC = value
        End Set
    End Property

    Private PDescripcionEspecial As Boolean
    Public Property DescripcionEspecial() As Boolean
        Get
            Return PDescripcionEspecial
        End Get
        Set(ByVal value As Boolean)
            PDescripcionEspecial = value
        End Set
    End Property

  
   
End Class
