Public Class AltaColaboradorIMSS
    Private idColaborador As Int32
    Public Property PColaboradorId() As Int32
        Get
            Return idColaborador
        End Get
        Set(ByVal value As Int32)
            idColaborador = value
        End Set
    End Property

    Private idPatron As Int32
    Public Property PPAtronId() As Int32
        Get
            Return idPatron
        End Get
        Set(ByVal value As Int32)
            idPatron = value
        End Set
    End Property

    Private periodoNominaId As Int32
    Public Property PPeriodoNominaID() As Int32
        Get
            Return periodoNominaId
        End Get
        Set(ByVal value As Int32)
            periodoNominaId = value
        End Set
    End Property

    Private idMovimiento As Int32
    Public Property PMovimientoId() As Int32
        Get
            Return idMovimiento
        End Get
        Set(ByVal value As Int32)
            idMovimiento = value
        End Set
    End Property

    Private fechaAlta As Date
    Public Property PFechaAlta() As Date
        Get
            Return fechaAlta
        End Get
        Set(ByVal value As Date)
            fechaAlta = value
        End Set
    End Property

    Private tieneCredito As Boolean
    Public Property PTieneCredito() As Boolean
        Get
            Return tieneCredito
        End Get
        Set(ByVal value As Boolean)
            tieneCredito = value
        End Set
    End Property

    Private creditoInfonavitid As Int32
    Public Property PCreditoInfonavitId() As Int32
        Get
            Return creditoInfonavitid
        End Get
        Set(ByVal value As Int32)
            creditoInfonavitid = value
        End Set
    End Property

    Private numeroCredito As String
    Public Property PNumeroCredito() As String
        Get
            Return numeroCredito
        End Get
        Set(ByVal value As String)
            numeroCredito = value
        End Set
    End Property

    Private tipoDescuentoid As Int32
    Public Property PTipoDescuentoId() As Int32
        Get
            Return tipoDescuentoid
        End Get
        Set(ByVal value As Int32)
            tipoDescuentoid = value
        End Set
    End Property

    Private aplicaTabla As Boolean
    Public Property PAplicaTabla() As Boolean
        Get
            Return aplicaTabla
        End Get
        Set(ByVal value As Boolean)
            aplicaTabla = value
        End Set
    End Property

    Private cantidadDescontar As Double
    Public Property PCantidadDescontar() As Double
        Get
            Return cantidadDescontar
        End Get
        Set(ByVal value As Double)
            cantidadDescontar = value
        End Set
    End Property

    Private sdi As Double
    Public Property PSDI() As Double
        Get
            Return sdi
        End Get
        Set(ByVal value As Double)
            sdi = value
        End Set
    End Property

    Private idTipoTrabajador As Int32
    Public Property PTipoTrabajadorId() As Int32
        Get
            Return idTipoTrabajador
        End Get
        Set(ByVal value As Int32)
            idTipoTrabajador = value
        End Set
    End Property

    Private idSalario As Int32
    Public Property PTipoSalarioId() As Int32
        Get
            Return idSalario
        End Get
        Set(ByVal value As Int32)
            idSalario = value
        End Set
    End Property

    Private idJornada As Int32
    Public Property PTipoJornadaID() As Int32
        Get
            Return idJornada
        End Get
        Set(ByVal value As Int32)
            idJornada = value
        End Set
    End Property

    Private umf As Int32
    Public Property PUMF() As Int32
        Get
            Return umf
        End Get
        Set(ByVal value As Int32)
            umf = value
        End Set
    End Property

    Private curp As String
    Public Property PCurp() As String
        Get
            Return curp
        End Get
        Set(ByVal value As String)
            curp = value
        End Set
    End Property

    Private rfc As String
    Public Property PRFC() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private nombre As String
    Public Property PNombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private nss As String
    Public Property PNSS() As String
        Get
            Return nss
        End Get
        Set(ByVal value As String)
            nss = value
        End Set
    End Property

    Private valorDescuento As String
    Public Property PValorDescuento() As String
        Get
            Return valorDescuento
        End Get
        Set(ByVal value As String)
            valorDescuento = value
        End Set
    End Property

    Private entidadCreditoInfonavit As CreditoInfonavit
    Public Property PEntidadCreditoInfonavit() As Entidades.CreditoInfonavit
        Get
            Return entidadCreditoInfonavit
        End Get
        Set(ByVal value As Entidades.CreditoInfonavit)
            entidadCreditoInfonavit = value
        End Set
    End Property

    Private idNave As Int32
    Public Property PIdNave() As Int32
        Get
            Return idNave
        End Get
        Set(ByVal value As Int32)
            idNave = value
        End Set
    End Property

    Private aPaterno As String
    Public Property PAPaterno() As String
        Get
            Return aPaterno
        End Get
        Set(ByVal value As String)
            aPaterno = value
        End Set
    End Property

    Private aMaterno As String
    Public Property PAMaterno() As String
        Get
            Return aMaterno
        End Get
        Set(ByVal value As String)
            aMaterno = value
        End Set
    End Property

    Private nombres As String
    Public Property PNombres() As String
        Get
            Return nombres
        End Get
        Set(ByVal value As String)
            nombres = value
        End Set
    End Property

    Private motivoRechazo As String
    Public Property PMotivoRechazo() As String
        Get
            Return motivoRechazo
        End Get
        Set(ByVal value As String)
            motivoRechazo = value
        End Set
    End Property

    Private ArchivoRetencion As String
    Public Property PRutaArchivoRetencion() As String
        Get
            Return ArchivoRetencion
        End Get
        Set(ByVal value As String)
            ArchivoRetencion = value
        End Set
    End Property

    Private cargoRetencion As Boolean
    Public Property PCargoRetencion() As Boolean
        Get
            Return cargoRetencion
        End Get
        Set(ByVal value As Boolean)
            cargoRetencion = value
        End Set
    End Property

    Private salarioBase As Double
    Public Property PSalarioBase() As Double
        Get
            Return salarioBase
        End Get
        Set(ByVal value As Double)
            salarioBase = value
        End Set
    End Property

    Private patron As String
    Public Property PPatron() As String
        Get
            Return patron
        End Get
        Set(ByVal value As String)
            patron = value
        End Set
    End Property

    Private departamentoFiscalId As Integer
    Public Property PDepartamentoFiscalId() As Integer
        Get
            Return departamentoFiscalId
        End Get
        Set(ByVal value As Integer)
            departamentoFiscalId = value
        End Set
    End Property

    Private puestoFiscalId As Integer
    Public Property PPuestoFiscalId() As Integer
        Get
            Return puestoFiscalId
        End Get
        Set(ByVal value As Integer)
            puestoFiscalId = value
        End Set
    End Property
End Class