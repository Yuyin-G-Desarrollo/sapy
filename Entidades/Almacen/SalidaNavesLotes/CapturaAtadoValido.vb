Public Class CapturaAtadoValido

    Private IdAtado As String
    Private IdNAve As Integer
    Private Lote As Integer
    Private Año As Integer
    Private Descripcion As String
    Private N_Pares As Integer
    Private n_AtadoEscaneado As Integer
    Private IdCliente As Integer
    Private n_ParesLeidos As Integer
    Private StatusAtado As Integer
    Private ValidacionSalidaPorPar As Boolean
    Private ValidacionEntradaPorPar As Boolean
    Private LecturaPorCodigoCliente As Boolean
    Private NombreStatusAtado As String
    Private IdCarrito As Integer
    Private Seleccionar As Boolean = False
    Private NumeroAtado As Integer
    Private TipoLectura As String
    Private EtiquetaEspecial As Integer
    Private CartaInformativa As Integer


    Public Property PSeleccionar As Boolean
        Get
            Return Seleccionar
        End Get
        Set(value As Boolean)
            Seleccionar = value
        End Set
    End Property

    Public Property PEtiquetaEspecial As Integer
        Get
            Return EtiquetaEspecial
        End Get
        Set(value As Integer)
            EtiquetaEspecial = value
        End Set
    End Property
    Public Property PCartaInformativa As Integer
        Get
            Return CartaInformativa
        End Get
        Set(value As Integer)
            CartaInformativa = value
        End Set
    End Property


    Public Property PIdCarrito As Integer
        Get
            Return IdCarrito
        End Get
        Set(value As Integer)
            IdCarrito = value
        End Set
    End Property

    Public Property PIdAtado As String
        Get
            Return IdAtado
        End Get
        Set(value As String)
            IdAtado = value
        End Set
    End Property

    Public Property PTipoLectura As String
        Get
            Return TipoLectura
        End Get
        Set(value As String)
            TipoLectura = value
        End Set
    End Property
    Public Property PNumeroAtado As Integer
        Get
            Return NumeroAtado
        End Get
        Set(value As Integer)
            NumeroAtado = value
        End Set
    End Property
    Public Property PLote As Integer
        Get
            Return Lote
        End Get
        Set(value As Integer)
            Lote = value
        End Set
    End Property

    Public Property PIdNAve As Integer
        Get
            Return IdNAve
        End Get
        Set(value As Integer)
            IdNAve = value
        End Set
    End Property

    Public Property PAño As Integer
        Get
            Return Año
        End Get
        Set(value As Integer)
            Año = value
        End Set
    End Property

    Public Property PN_Pares As Integer
        Get
            Return N_Pares
        End Get
        Set(value As Integer)
            N_Pares = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PStatusAtado As Integer
        Get
            Return StatusAtado
        End Get
        Set(value As Integer)
            StatusAtado = value
        End Set
    End Property

    Public Property PNombreStatusAtado As String
        Get
            Return NombreStatusAtado
        End Get
        Set(value As String)
            NombreStatusAtado = value
        End Set
    End Property

    Public Property PLecturaPorCodigoCliente As Boolean
        Get
            Return LecturaPorCodigoCliente
        End Get
        Set(value As Boolean)
            LecturaPorCodigoCliente = value
        End Set

    End Property
    Public Property PValidacionEntradaPorPar As Boolean
        Get
            Return ValidacionEntradaPorPar
        End Get
        Set(value As Boolean)
            ValidacionEntradaPorPar = value
        End Set
    End Property


    Public Property PValidacionSalidaPorPar As Boolean
        Get
            Return ValidacionSalidaPorPar
        End Get
        Set(value As Boolean)
            ValidacionSalidaPorPar = value
        End Set
    End Property



    Public Property Pn_ParesLeidos As Integer
        Get
            Return n_ParesLeidos
        End Get
        Set(value As Integer)
            n_ParesLeidos = value
        End Set
    End Property

    Public Property PIdCliente As Integer
        Get
            Return IdCliente
        End Get
        Set(value As Integer)
            IdCliente = value
        End Set
    End Property


    Public Property PN_AtadoEscaneado As Integer
        Get
            Return n_AtadoEscaneado
        End Get
        Set(value As Integer)
            n_AtadoEscaneado = value
        End Set
    End Property




End Class
