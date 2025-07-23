Public Class CreditoInfonavit

    Private creditoinfonavitid As Integer
    Public Property CICreditoInfonavitId() As Integer
        Get
            Return creditoinfonavitid
        End Get
        Set(ByVal value As Integer)
            creditoinfonavitid = value
        End Set
    End Property

    Private colaboradorid As Integer
    Public Property CIColaboradorid() As Integer
        Get
            Return colaboradorid
        End Get
        Set(ByVal value As Integer)
            colaboradorid = value
        End Set
    End Property

    Private aPaterno As String
    Public Property CIAPaterno() As String
        Get
            Return aPaterno
        End Get
        Set(ByVal value As String)
            aPaterno = value
        End Set
    End Property

    Private aMaterno As String
    Public Property CIAMaterno() As String
        Get
            Return aMaterno
        End Get
        Set(ByVal value As String)
            aMaterno = value
        End Set
    End Property

    Private nombre As String
    Public Property CINombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private colaborador As String
    Public Property CIColaborador() As String
        Get
            Return colaborador
        End Get
        Set(ByVal value As String)
            colaborador = value
        End Set
    End Property

    Private patronId As Integer
    Public Property CIPatronId() As Integer
        Get
            Return patronId
        End Get
        Set(ByVal value As Integer)
            patronId = value
        End Set
    End Property

    Private empresa As String
    Public Property CIEmpresa() As String
        Get
            Return empresa
        End Get
        Set(ByVal value As String)
            empresa = value
        End Set
    End Property

    Private nss As String
    Public Property CINss() As String
        Get
            Return nss
        End Get
        Set(ByVal value As String)
            nss = value
        End Set
    End Property

    Private rfc As String
    Public Property CIRfc() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private movimientoId As Integer
    Public Property CIMovimientoId() As Integer
        Get
            Return movimientoId
        End Get
        Set(ByVal value As Integer)
            movimientoId = value
        End Set
    End Property

    Private periodonominafiscalid As Integer
    Public Property CIPeriodonominafiscalid() As Integer
        Get
            Return periodonominafiscalid
        End Get
        Set(ByVal value As Integer)
            periodonominafiscalid = value
        End Set
    End Property

    Private numerocredito As String
    Public Property CINumerocredito() As String
        Get
            Return numerocredito
        End Get
        Set(ByVal value As String)
            numerocredito = value
        End Set
    End Property

    Private movimientoinfonavitid As Integer
    Public Property CIMovimientoinfonavitid() As Integer
        Get
            Return movimientoinfonavitid
        End Get
        Set(ByVal value As Integer)
            movimientoinfonavitid = value
        End Set
    End Property

    Private tipodescuentoid As Integer
    Public Property CITipodescuentoid() As Integer
        Get
            Return tipodescuentoid
        End Get
        Set(ByVal value As Integer)
            tipodescuentoid = value
        End Set
    End Property

    Private valordescuento As Double
    Public Property CIValordescuento() As Double
        Get
            Return valordescuento
        End Get
        Set(ByVal value As Double)
            valordescuento = value
        End Set
    End Property

    Private salarioBase As Double
    Public Property CISalarioBase() As Double
        Get
            Return salarioBase
        End Get
        Set(ByVal value As Double)
            salarioBase = value
        End Set
    End Property

    Private salarioBimestral As Double
    Public Property CISalarioBimestral() As Double
        Get
            Return salarioBimestral
        End Get
        Set(ByVal value As Double)
            salarioBimestral = value
        End Set
    End Property

    Private importeretencionmensual As Double
    Public Property CIImporteretencionmensual() As Double
        Get
            Return importeretencionmensual
        End Get
        Set(ByVal value As Double)
            importeretencionmensual = value
        End Set
    End Property

    Private salarioMinimoDF As Double
    Public Property CISalarioMinimoDF() As Double
        Get
            Return salarioMinimoDF
        End Get
        Set(ByVal value As Double)
            salarioMinimoDF = value
        End Set
    End Property

    Private retencionMensual As Double
    Public Property CIRetencionMensual() As Double
        Get
            Return retencionMensual
        End Get
        Set(ByVal value As Double)
            retencionMensual = value
        End Set
    End Property

    Private importeretencionbimestral As Double
    Public Property CIImporteretencionbimestral() As Double
        Get
            Return importeretencionbimestral
        End Get
        Set(ByVal value As Double)
            importeretencionbimestral = value
        End Set
    End Property

    Private importeretenerbimestral As Double
    Public Property CIImporteretenerbimestral() As Double
        Get
            Return importeretenerbimestral
        End Get
        Set(ByVal value As Double)
            importeretenerbimestral = value
        End Set
    End Property

    Private seguroVivienda As Double
    Public Property CISeguroVivienda() As Double
        Get
            Return seguroVivienda
        End Get
        Set(ByVal value As Double)
            seguroVivienda = value
        End Set
    End Property


    Private retenciondiaria As Double
    Public Property CIRetenciondiaria() As Double
        Get
            Return retenciondiaria
        End Get
        Set(ByVal value As Double)
            retenciondiaria = value
        End Set
    End Property

    Private retencionsemanalfiscal As Double
    Public Property CIRetencionsemanalfiscal() As Double
        Get
            Return retencionsemanalfiscal
        End Get
        Set(ByVal value As Double)
            retencionsemanalfiscal = value
        End Set
    End Property

    Private semanasdescontaranual As Double
    Public Property CISemanasdescontaranual() As Double
        Get
            Return semanasdescontaranual
        End Get
        Set(ByVal value As Double)
            semanasdescontaranual = value
        End Set
    End Property

    Private descuentosemanal As Double
    Public Property CIDescuentosemanal() As Double
        Get
            Return descuentosemanal
        End Get
        Set(ByVal value As Double)
            descuentosemanal = value
        End Set
    End Property

    Private descuentoanterior As Double
    Public Property CIDescuentoanterior() As Double
        Get
            Return descuentoanterior
        End Get
        Set(ByVal value As Double)
            descuentoanterior = value
        End Set
    End Property

    Private diferencia As Double
    Public Property CIDiferencia() As Double
        Get
            Return diferencia
        End Get
        Set(ByVal value As Double)
            diferencia = value
        End Set
    End Property

    Private movimientodescontado As Boolean
    Public Property CIMovimientodescontado() As Boolean
        Get
            Return movimientodescontado
        End Get
        Set(ByVal value As Boolean)
            movimientodescontado = value
        End Set
    End Property

    Private fecharecepcion As String
    Public Property CIFecharecepcion() As String
        Get
            Return fecharecepcion
        End Get
        Set(ByVal value As String)
            fecharecepcion = value
        End Set
    End Property

    Private fechamovimiento As String
    Public Property CIFechamovimiento() As String
        Get
            Return fechamovimiento
        End Get
        Set(ByVal value As String)
            fechamovimiento = value
        End Set
    End Property

    Private aplicatabladisminucion As Boolean
    Public Property CIAplicatabladisminucion() As Boolean
        Get
            Return aplicatabladisminucion
        End Get
        Set(ByVal value As Boolean)
            aplicatabladisminucion = value
        End Set
    End Property

    Private rutaarchivoretencion As String
    Public Property CIRutaarchivoretencion() As String
        Get
            Return rutaarchivoretencion
        End Get
        Set(ByVal value As String)
            rutaarchivoretencion = value
        End Set
    End Property

    Private estatusid As Integer
    Public Property CIEstatusid() As Integer
        Get
            Return estatusid
        End Get
        Set(ByVal value As Integer)
            estatusid = value
        End Set
    End Property

    Private usuarioaplicoid As Integer
    Public Property CIUsuarioaplicoid() As Integer
        Get
            Return usuarioaplicoid
        End Get
        Set(ByVal value As Integer)
            usuarioaplicoid = value
        End Set
    End Property

    Private fechaaplicacion As Date
    Public Property CIFechaaplicacion() As Date
        Get
            Return fechaaplicacion
        End Get
        Set(ByVal value As Date)
            fechaaplicacion = value
        End Set
    End Property

    Private usuarioprocesoid As Integer
    Public Property CIUsuarioprocesoid() As Integer
        Get
            Return usuarioprocesoid
        End Get
        Set(ByVal value As Integer)
            usuarioprocesoid = value
        End Set
    End Property

    Private fechaproceso As Date
    Public Property CIFechaproceso() As Date
        Get
            Return fechaproceso
        End Get
        Set(ByVal value As Date)
            fechaproceso = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property CIUsuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private fechacreacion As Date
    Public Property CIFechacreacion() As Date
        Get
            Return fechacreacion
        End Get
        Set(ByVal value As Date)
            fechacreacion = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property CIUsuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechamodificacion As Date
    Public Property CIFechamodificacion() As Date
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As Date)
            fechamodificacion = value
        End Set
    End Property

    Private diasSemana As Integer
    Public Property CIDiasSemana() As Integer
        Get
            Return diasSemana
        End Get
        Set(ByVal value As Integer)
            diasSemana = value
        End Set
    End Property

    Private numSemDescontar As Integer
    Public Property CINumSemDescontar() As Integer
        Get
            Return numSemDescontar
        End Get
        Set(ByVal value As Integer)
            numSemDescontar = value
        End Set
    End Property

    Private logoNave As String
    Public Property CILogoNave() As String
        Get
            Return logoNave
        End Get
        Set(ByVal value As String)
            logoNave = value
        End Set
    End Property

    Private tipoDescuentoStr As String
    Public Property CITipoDescuentoStr() As String
        Get
            Return tipoDescuentoStr
        End Get
        Set(ByVal value As String)
            tipoDescuentoStr = value
        End Set
    End Property

    Private movimientoinfonavitStr As String
    Public Property CIMovimientoinfonavitStr() As String
        Get
            Return movimientoinfonavitStr
        End Get
        Set(ByVal value As String)
            movimientoinfonavitStr = value
        End Set
    End Property

    Private fechaInicioBimestre As Date
    Public Property CIFechaInicioBimestre() As Date
        Get
            Return fechaInicioBimestre
        End Get
        Set(ByVal value As Date)
            fechaInicioBimestre = value
        End Set
    End Property

    Private fechaFinBimestre As Date
    Public Property CIFechaFinBimestre() As Date
        Get
            Return fechaFinBimestre
        End Get
        Set(ByVal value As Date)
            fechaFinBimestre = value
        End Set
    End Property

    Private diasAnio As Integer
    Public Property CIDiasAnio As Integer
        Get
            Return diasAnio
        End Get
        Set(value As Integer)
            diasAnio = value
        End Set
    End Property

    Private diasNoLaborables As Integer
    Public Property CIdiasNoLaborables As Integer
        Get
            Return diasNoLaborables
        End Get
        Set(value As Integer)
            diasNoLaborables = value
        End Set
    End Property
End Class
