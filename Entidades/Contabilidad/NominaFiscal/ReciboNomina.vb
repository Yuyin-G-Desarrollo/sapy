Public Class ReciboNomina
#Region "Panel1:Encabezado"
    Private NombrePatron As String
    Public Property PNombrePatron As String
        Get
            Return NombrePatron
        End Get
        Set(ByVal value As String)
            NombrePatron = value
        End Set
    End Property

    Private RfcEmpresa As String
    Public Property PRfcEmpresa As String
        Get
            Return RfcEmpresa
        End Get
        Set(value As String)
            RfcEmpresa = value
        End Set
    End Property

    Private RegimenFiscal As String
    Public Property PRegimenFiscal As String
        Get
            Return RegimenFiscal
        End Get
        Set(value As String)
            RegimenFiscal = value
        End Set
    End Property

    Private LugarExpedicion As String
    Public Property PLugarExpedicion As String
        Get
            Return LugarExpedicion
        End Get
        Set(value As String)
            LugarExpedicion = value
        End Set
    End Property

    Private curpEmisor As String
    Public Property PCurpEmisor() As String
        Get
            Return curpEmisor
        End Get
        Set(ByVal value As String)
            curpEmisor = value
        End Set
    End Property

    Private RegistroPatronal As String
    Public Property PRegistroPatronal As String
        Get
            Return RegistroPatronal
        End Get
        Set(value As String)
            RegistroPatronal = value
        End Set
    End Property

    Private Fecha As String
    Public Property PFecha As String
        Get
            Return Fecha
        End Get
        Set(value As String)
            Fecha = value
        End Set
    End Property

    Private Hora As String
    Public Property PHora As String
        Get
            Return Hora
        End Get
        Set(value As String)
            Hora = value
        End Set
    End Property

    Private serie As String
    Public Property PSerie() As String
        Get
            Return serie
        End Get
        Set(ByVal value As String)
            serie = value
        End Set
    End Property

    Private folio As Integer
    Public Property PFolio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property
#End Region


#Region "Bloque1"
    Private ClaveColaborador As String
    Public Property PClaveColaborador As String
        Get
            Return ClaveColaborador
        End Get
        Set(value As String)
            ClaveColaborador = value
        End Set
    End Property

    Private NombreColaborador As String
    Public Property PNombreColaborador As String
        Get
            Return NombreColaborador
        End Get
        Set(value As String)
            NombreColaborador = value
        End Set
    End Property

    Private RFCColaborador As String
    Public Property PRFCColaborador As String
        Get
            Return RFCColaborador
        End Get
        Set(value As String)
            RFCColaborador = value
        End Set
    End Property

    Private CURPColaborador As String
    Public Property PCURPColaborador As String
        Get
            Return CURPColaborador
        End Get
        Set(value As String)
            CURPColaborador = value
        End Set
    End Property

    Private FechaInicioRelacion As String
    Public Property PFechaInicioRelacion As String
        Get
            Return FechaInicioRelacion
        End Get
        Set(value As String)
            FechaInicioRelacion = value
        End Set
    End Property

    Private Jornada As String
    Public Property PJornada As String
        Get
            Return Jornada
        End Get
        Set(value As String)
            Jornada = value
        End Set
    End Property

    Private NSS As String
    Public Property PNSS As String
        Get
            Return NSS
        End Get
        Set(value As String)
            NSS = value
        End Set
    End Property

    Private TipoSalario As String
    Public Property PTipoSalario As String
        Get
            Return TipoSalario
        End Get
        Set(value As String)
            TipoSalario = value
        End Set
    End Property

    Private tipoContrato As String
    Public Property PTipoContrato() As String
        Get
            Return tipoContrato
        End Get
        Set(ByVal value As String)
            tipoContrato = value
        End Set
    End Property

    Private tipoRegimen As String
    Public Property PTipoRegimen() As String
        Get
            Return tipoRegimen
        End Get
        Set(ByVal value As String)
            tipoRegimen = value
        End Set
    End Property

    Private periodicidadPago As String
    Public Property PPeriodidadPago() As String
        Get
            Return periodicidadPago
        End Get
        Set(ByVal value As String)
            periodicidadPago = value
        End Set
    End Property

    Private usoCfdi As String
    Public Property PUsoCfdi() As String
        Get
            Return usoCfdi
        End Get
        Set(ByVal value As String)
            usoCfdi = value
        End Set
    End Property

    Private antiguedad As String
    Public Property PAntiguedad() As String
        Get
            Return antiguedad
        End Get
        Set(ByVal value As String)
            antiguedad = value
        End Set
    End Property
#End Region


#Region "Bloque2"
    Private TipoPeriodo As String
    Public Property PTipoPeriodo As String
        Get
            Return TipoPeriodo
        End Get
        Set(value As String)
            TipoPeriodo = value
        End Set
    End Property

    Private RangoPeriodo As String
    Public Property PRangoPeriodo As String
        Get
            Return RangoPeriodo
        End Get
        Set(value As String)
            RangoPeriodo = value
        End Set
    End Property

    Private DiasPago As Double
    Public Property PDiasPago As Double
        Get
            Return DiasPago
        End Get
        Set(value As Double)
            DiasPago = value
        End Set
    End Property

    Private FechaPago As String
    Public Property PFechaPago As String
        Get
            Return FechaPago
        End Get
        Set(value As String)
            FechaPago = value
        End Set
    End Property

    Private Puesto As String
    Public Property PPuesto As String
        Get
            Return Puesto
        End Get
        Set(value As String)
            Puesto = value
        End Set
    End Property

    Private Departamento As String
    Public Property PDepartamento As String
        Get
            Return Departamento
        End Get
        Set(value As String)
            Departamento = value
        End Set
    End Property

    Private SDI As Double
    Public Property PSDI As Double
        Get
            Return SDI
        End Get
        Set(value As Double)
            SDI = value
        End Set
    End Property

    Private salarioBaseCot As Double
    Public Property PSalarioBaseCot() As Double
        Get
            Return salarioBaseCot
        End Get
        Set(ByVal value As Double)
            salarioBaseCot = value
        End Set
    End Property
#End Region


#Region "Bloque3"
    Private claveProdServ As String
    Public Property PClaveProdServ() As String
        Get
            Return claveProdServ
        End Get
        Set(ByVal value As String)
            claveProdServ = value
        End Set
    End Property

    Private cantidad As Double
    Public Property PCantidad() As Double
        Get
            Return cantidad
        End Get
        Set(ByVal value As Double)
            cantidad = value
        End Set
    End Property

    Private unidad As String
    Public Property PUnidad() As String
        Get
            Return unidad
        End Get
        Set(ByVal value As String)
            unidad = value
        End Set
    End Property

    Private descripcion As String
    Public Property PDescripcion() As String
        Get
            Return descripcion
        End Get
        Set(ByVal value As String)
            descripcion = value
        End Set
    End Property

    Private valorUnitario As Double
    Public Property PValorUnitario() As Double
        Get
            Return valorUnitario
        End Get
        Set(ByVal value As Double)
            valorUnitario = value
        End Set
    End Property
#End Region


#Region "Panel2:Percepciones"
    Private SumaPercepcionesGravado As Double
    Public Property PSumaPercepcionesGravado As Double
        Get
            Return SumaPercepcionesGravado
        End Get
        Set(value As Double)
            SumaPercepcionesGravado = value
        End Set
    End Property

    Private SumaPercepcionesExento As Double
    Public Property PSumaPercepcionesExento As Double
        Get
            Return SumaPercepcionesExento
        End Get
        Set(value As Double)
            SumaPercepcionesExento = value
        End Set
    End Property

    Private SumaPercepcionesTotal As Double
    Public Property PSumaPercepcionesTotal As Double
        Get
            Return SumaPercepcionesTotal
        End Get
        Set(value As Double)
            SumaPercepcionesTotal = value
        End Set
    End Property
#End Region


#Region "Panel3:OtrasPercepciones"
    Private SumaOtrasPercepcionesTotal As Double
    Public Property PSumaOtrasPercepcionesTotal As Double
        Get
            Return SumaOtrasPercepcionesTotal
        End Get
        Set(value As Double)
            SumaOtrasPercepcionesTotal = value
        End Set
    End Property
#End Region


#Region "Totales"
    Private Subtotal As Double
    Public Property PSubtotal As Double
        Get
            Return Subtotal
        End Get
        Set(value As Double)
            Subtotal = value
        End Set
    End Property

    Private Descuentos As Double
    Public Property PDescuentos As Double
        Get
            Return Descuentos
        End Get
        Set(value As Double)
            Descuentos = value
        End Set
    End Property

    Private Retenciones As Double
    Public Property PRetenciones As Double
        Get
            Return Retenciones
        End Get
        Set(value As Double)
            Retenciones = value
        End Set
    End Property

    Private Total As Double
    Public Property PTotal As Double
        Get
            Return Total
        End Get
        Set(value As Double)
            Total = value
        End Set
    End Property

    Private NetoRecibo As Double
    Public Property PNetoRecibo As Double
        Get
            Return NetoRecibo
        End Get
        Set(value As Double)
            NetoRecibo = value
        End Set
    End Property

    Private ImporteLetra As String
    Public Property PImporteLetra As String
        Get
            Return ImporteLetra
        End Get
        Set(value As String)
            ImporteLetra = value
        End Set
    End Property
#End Region


#Region "Bloque4"
    Private QR As String
    Public Property PQR As String
        Get
            Return QR
        End Get
        Set(value As String)
            QR = value
        End Set
    End Property

    Private SerieCertificadoEmisor As String
    Public Property PSerieCertificadoEmisor As String
        Get
            Return SerieCertificadoEmisor
        End Get
        Set(value As String)
            SerieCertificadoEmisor = value
        End Set
    End Property

    Private UUID As String
    Public Property PUUID As String
        Get
            Return UUID
        End Get
        Set(value As String)
            UUID = value
        End Set
    End Property

    Private SerieCertificadoSAT As String
    Public Property PSerieCertificadoSAT As String
        Get
            Return SerieCertificadoSAT
        End Get
        Set(value As String)
            SerieCertificadoSAT = value
        End Set
    End Property

    Private FechaHoraCertificacion As String
    Public Property PFechaHoraCertificacion As String
        Get
            Return FechaHoraCertificacion
        End Get
        Set(value As String)
            FechaHoraCertificacion = value
        End Set
    End Property

    Private FormaPago As String
    Public Property PFormaPago As String
        Get
            Return FormaPago
        End Get
        Set(value As String)
            FormaPago = value
        End Set
    End Property

    Private MetodoPago As String
    Public Property PMetodoPago As String
        Get
            Return MetodoPago
        End Get
        Set(value As String)
            MetodoPago = value
        End Set
    End Property

    Private tipoComprobante As String
    Public Property PTipoComprobante() As String
        Get
            Return tipoComprobante
        End Get
        Set(ByVal value As String)
            tipoComprobante = value
        End Set
    End Property

    Private moneda As String
    Public Property PMoneda() As String
        Get
            Return moneda
        End Get
        Set(ByVal value As String)
            moneda = value
        End Set
    End Property

    Private FechaHoraCancelacion As String
    Public Property PFechaHoraCancelacion() As String
        Get
            Return FechaHoraCancelacion
        End Get
        Set(ByVal value As String)
            FechaHoraCancelacion = value
        End Set
    End Property
#End Region


#Region "Bloque5"
    Private tipoRelacion As String
    Public Property PTipoRelacion() As String
        Get
            Return tipoRelacion
        End Get
        Set(ByVal value As String)
            tipoRelacion = value
        End Set
    End Property

    Private cfdiRelUuid As String
    Public Property PCfdiRelUuid() As String
        Get
            Return cfdiRelUuid
        End Get
        Set(ByVal value As String)
            cfdiRelUuid = value
        End Set
    End Property
#End Region


#Region "Pie"
    Private SelloDigital As String
    Public Property PSelloDigital As String
        Get
            Return SelloDigital
        End Get
        Set(value As String)
            SelloDigital = value
        End Set
    End Property

    Private SelloSAT As String
    Public Property PSelloSAT As String
        Get
            Return SelloSAT
        End Get
        Set(value As String)
            SelloSAT = value
        End Set
    End Property

    Private CadenaOriginal As String
    Public Property PCadenaOriginal As String
        Get
            Return CadenaOriginal
        End Get
        Set(value As String)
            CadenaOriginal = value
        End Set
    End Property
#End Region


#Region "Tablas"
    Private Percepciones As DataTable
    Public Property PPercepciones As DataTable
        Get
            Return Percepciones
        End Get
        Set(value As DataTable)
            Percepciones = value
        End Set
    End Property

    Private OtrasPercepciones As DataTable
    Public Property POtrasPercepciones As DataTable
        Get
            Return OtrasPercepciones
        End Get
        Set(value As DataTable)
            OtrasPercepciones = value
        End Set
    End Property

    Private Deducciones As DataTable
    Public Property PDeducciones As DataTable
        Get
            Return Deducciones
        End Get
        Set(value As DataTable)
            Deducciones = value
        End Set
    End Property

    Private Incapacidades As DataTable
    Public Property PIncapacidades As DataTable
        Get
            Return Incapacidades
        End Get
        Set(value As DataTable)
            Incapacidades = value
        End Set
    End Property
#End Region
End Class