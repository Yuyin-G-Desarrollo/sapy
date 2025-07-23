Public Class ModificacionSalario

    Private modificacionSalarioId As Integer
    Public Property MDID() As Integer
        Get
            Return modificacionSalarioId
        End Get
        Set(ByVal value As Integer)
            modificacionSalarioId = value
        End Set
    End Property

    Private colaboradorId As Integer
    Public Property MDColaboradorId() As Integer
        Get
            Return colaboradorId
        End Get
        Set(ByVal value As Integer)
            colaboradorId = value
        End Set
    End Property

    Private aPaterno As String
    Public Property MDAPaterno() As String
        Get
            Return aPaterno
        End Get
        Set(ByVal value As String)
            aPaterno = value
        End Set
    End Property

    Private aMaterno As String
    Public Property MDAMaterno() As String
        Get
            Return aMaterno
        End Get
        Set(ByVal value As String)
            aMaterno = value
        End Set
    End Property

    Private nombre As String
    Public Property MDNombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private colaborador As String
    Public Property MDColaborador() As String
        Get
            Return colaborador
        End Get
        Set(ByVal value As String)
            colaborador = value
        End Set
    End Property

    Private departamento As String
    Public Property MDDepartamento() As String
        Get
            Return departamento
        End Get
        Set(ByVal value As String)
            departamento = value
        End Set
    End Property

    Private puesto As String
    Public Property MDPuesto() As String
        Get
            Return puesto
        End Get
        Set(ByVal value As String)
            puesto = value
        End Set
    End Property

    Private fechaIngreso As Date
    Public Property MDFechaIngreso() As Date
        Get
            Return fechaIngreso
        End Get
        Set(ByVal value As Date)
            fechaIngreso = value
        End Set
    End Property

    Private antiguedad As String
    Public Property MDAntiguedad() As String
        Get
            Return antiguedad
        End Get
        Set(ByVal value As String)
            antiguedad = value
        End Set
    End Property

    Private NSS As String
    Public Property MDNSS() As String
        Get
            Return NSS
        End Get
        Set(ByVal value As String)
            NSS = value
        End Set
    End Property

    Private patronId As Integer
    Public Property MDPatronId() As Integer
        Get
            Return patronId
        End Get
        Set(ByVal value As Integer)
            patronId = value
        End Set
    End Property

    Private movimientoId As Integer
    Public Property MDovimientoId() As Integer
        Get
            Return movimientoId
        End Get
        Set(ByVal value As Integer)
            movimientoId = value
        End Set
    End Property

    Private periodoNominafiscalId As Integer
    Public Property MDPeriodoNominafiscalId() As Integer
        Get
            Return periodoNominafiscalId
        End Get
        Set(ByVal value As Integer)
            periodoNominafiscalId = value
        End Set
    End Property

    Private salarioAnterior As Double
    Public Property MDSalarioAnterior() As Double
        Get
            Return salarioAnterior
        End Get
        Set(ByVal value As Double)
            salarioAnterior = value
        End Set
    End Property

    Private salarioNuevo As Double
    Public Property MDSalarioNuevo() As Double
        Get
            Return salarioNuevo
        End Get
        Set(ByVal value As Double)
            salarioNuevo = value
        End Set
    End Property

    Private excedenteTabulador As Double
    Public Property MDExcedenteTabulador() As Double
        Get
            Return excedenteTabulador
        End Get
        Set(ByVal value As Double)
            excedenteTabulador = value
        End Set
    End Property

    Private fechaMovimiento As String
    Public Property MDFechaMovimiento() As String
        Get
            Return fechaMovimiento
        End Get
        Set(ByVal value As String)
            fechaMovimiento = value
        End Set
    End Property

    Private numCreditoInfonavit As String
    Public Property MDNumCreditoInfonavit() As String
        Get
            Return numCreditoInfonavit
        End Get
        Set(ByVal value As String)
            numCreditoInfonavit = value
        End Set
    End Property

    Private tipoDescuento As String
    Public Property MDTipoDescuento() As String
        Get
            Return tipoDescuento
        End Get
        Set(ByVal value As String)
            tipoDescuento = value
        End Set
    End Property

    Private valorDescuentoInfonavit As Double
    Public Property MDvalorDescuentoInfonavit() As Double
        Get
            Return valorDescuentoInfonavit
        End Get
        Set(ByVal value As Double)
            valorDescuentoInfonavit = value
        End Set
    End Property

    Private descuentoInfonavitAnterior As Double
    Public Property MDDescuentoInfonavitAnterior() As Double
        Get
            Return descuentoInfonavitAnterior
        End Get
        Set(ByVal value As Double)
            descuentoInfonavitAnterior = value
        End Set
    End Property

    Private descuentoInfonavitNuevo As Double
    Public Property MDDescuentoInfonavitNuevo() As Double
        Get
            Return descuentoInfonavitNuevo
        End Get
        Set(ByVal value As Double)
            descuentoInfonavitNuevo = value
        End Set
    End Property

    Private descuentoInfonavitDiarionuevo As Double
    Public Property MDDescuentoInfonavitDiarionuevo() As Double
        Get
            Return descuentoInfonavitDiarionuevo
        End Get
        Set(ByVal value As Double)
            descuentoInfonavitDiarionuevo = value
        End Set
    End Property

    Private descuentoImssDiario As Double
    Public Property MDDescuentoImssDiario() As Double
        Get
            Return descuentoImssDiario
        End Get
        Set(ByVal value As Double)
            descuentoImssDiario = value
        End Set
    End Property

    Private descuentoImssSem As Double
    Public Property MDDescuentoImssSem() As Double
        Get
            Return descuentoImssSem
        End Get
        Set(ByVal value As Double)
            descuentoImssSem = value
        End Set
    End Property

    Private descuentoISRDiario As Double
    Public Property MDDescuentoISRDiario() As Double
        Get
            Return descuentoISRDiario
        End Get
        Set(ByVal value As Double)
            descuentoISRDiario = value
        End Set
    End Property

    Private descuentoISRSem As Double
    Public Property MDDescuentoISRSem() As Double
        Get
            Return descuentoISRSem
        End Get
        Set(ByVal value As Double)
            descuentoISRSem = value
        End Set
    End Property

    Private estatusId As Integer
    Public Property MDEstatusId() As Integer
        Get
            Return estatusId
        End Get
        Set(ByVal value As Integer)
            estatusId = value
        End Set
    End Property

    Private usuarioCreoId As Integer
    Public Property MDUsuarioCreoId() As Integer
        Get
            Return usuarioCreoId
        End Get
        Set(ByVal value As Integer)
            usuarioCreoId = value
        End Set
    End Property

    Private fechaCreacion As Date
    Public Property MDFechaCreacion() As Date
        Get
            Return fechaCreacion
        End Get
        Set(ByVal value As Date)
            fechaCreacion = value
        End Set
    End Property

    Private motivoCreacion As String
    Public Property MDMotivoCreacion() As String
        Get
            Return motivoCreacion
        End Get
        Set(ByVal value As String)
            motivoCreacion = value
        End Set
    End Property

    Private usuarioModificoId As Integer
    Public Property MDUsuarioModificoId() As Integer
        Get
            Return usuarioModificoId
        End Get
        Set(ByVal value As Integer)
            usuarioModificoId = value
        End Set
    End Property

    Private fechaModificacion As Date
    Public Property MDFechaModificacion() As Date
        Get
            Return fechaModificacion
        End Get
        Set(ByVal value As Date)
            fechaModificacion = value
        End Set
    End Property

    Private usuarioAplicoId As Integer
    Public Property MDUsuarioAplicoId() As Integer
        Get
            Return usuarioAplicoId
        End Get
        Set(ByVal value As Integer)
            usuarioAplicoId = value
        End Set
    End Property

    Private fechaAplicacion As Date
    Public Property MDFechaAplicacion() As Date
        Get
            Return fechaAplicacion
        End Get
        Set(ByVal value As Date)
            fechaAplicacion = value
        End Set
    End Property

    Private usuarioAutorizoId As Integer
    Public Property MDUsuarioAutorizoId() As Integer
        Get
            Return usuarioAutorizoId
        End Get
        Set(ByVal value As Integer)
            usuarioAutorizoId = value
        End Set
    End Property

    Private fechaAutorizacion As Date
    Public Property MDFechaAutorizacion() As Date
        Get
            Return fechaAutorizacion
        End Get
        Set(ByVal value As Date)
            fechaAutorizacion = value
        End Set
    End Property

    Private usuarioRegresoId As Integer
    Public Property MDUsuarioRegresoId() As Integer
        Get
            Return usuarioRegresoId
        End Get
        Set(ByVal value As Integer)
            usuarioRegresoId = value
        End Set
    End Property

    Private fechaRegreso As Date
    Public Property MDFechaRegreso() As Date
        Get
            Return fechaRegreso
        End Get
        Set(ByVal value As Date)
            fechaRegreso = value
        End Set
    End Property

    Private motivoRegreso As String
    Public Property MDMotivoRegreso() As String
        Get
            Return motivoRegreso
        End Get
        Set(ByVal value As String)
            motivoRegreso = value
        End Set
    End Property

    Private usuarioRechazoId As Integer
    Public Property MDUsuarioRechazoId() As Integer
        Get
            Return usuarioRechazoId
        End Get
        Set(ByVal value As Integer)
            usuarioRechazoId = value
        End Set
    End Property

    Private fechaRechazo As Date
    Public Property MDFechaRechazo() As Date
        Get
            Return fechaRechazo
        End Get
        Set(ByVal value As Date)
            fechaRechazo = value
        End Set
    End Property

    Private motivoRechazo As String
    Public Property MDMotivoRechazo() As String
        Get
            Return motivoRechazo
        End Get
        Set(ByVal value As String)
            motivoRechazo = value
        End Set
    End Property

    Private factorIntegracion As Double
    Public Property MDFactorIntegracion() As Double
        Get
            Return factorIntegracion
        End Get
        Set(ByVal value As Double)
            factorIntegracion = value
        End Set
    End Property

End Class