Public Class OrdenDeCompra

    Private ordencompraid As Integer
    Public Property ordc_ordencompraid() As Integer
        Get
            Return ordencompraid
        End Get
        Set(ByVal value As Integer)
            ordencompraid = value
        End Set
    End Property

    Private proveedorid As Integer
    Public Property ordc_proveedorid() As Integer
        Get
            Return proveedorid
        End Get
        Set(ByVal value As Integer)
            proveedorid = value
        End Set
    End Property

    Private plazoid As Integer
    Public Property ordc_plazoid() As Integer
        Get
            Return plazoid
        End Get
        Set(ByVal value As Integer)
            plazoid = value
        End Set
    End Property

    Private plazodias As Integer
    Public Property ordc_plazodias() As Integer
        Get
            Return plazodias
        End Get
        Set(ByVal value As Integer)
            plazodias = value
        End Set
    End Property

    Private naveid As Integer
    Public Property ordc_naveid() As Integer
        Get
            Return naveid
        End Get
        Set(ByVal value As Integer)
            naveid = value
        End Set
    End Property

    Private fechaelaboracion As Date
    Public Property ordc_fechaleaboracion() As Date
        Get
            Return fechaelaboracion
        End Get
        Set(ByVal value As Date)
            fechaelaboracion = value
        End Set
    End Property

    Private prioridad As String
    Public Property ordc_prioridad() As String
        Get
            Return prioridad
        End Get
        Set(ByVal value As String)
            prioridad = value
        End Set
    End Property

    Private razonsocial As Integer
    Public Property ordc_razonsocial() As Integer
        Get
            Return razonsocial
        End Get
        Set(ByVal value As Integer)
            razonsocial = value
        End Set
    End Property

    Private documento As String
    Public Property ordc_documento() As String
        Get
            Return documento
        End Get
        Set(ByVal value As String)
            documento = value
        End Set
    End Property

    Private programainicio As Date
    Public Property ordc_programainicio() As Date
        Get
            Return programainicio
        End Get
        Set(ByVal value As Date)
            programainicio = value
        End Set
    End Property

    Private programafin As Date
    Public Property ordc_programafin() As Date
        Get
            Return programafin
        End Get
        Set(ByVal value As Date)
            programafin = value
        End Set
    End Property

    Private fechaentregaestimada As Date
    Public Property ordc_fechaentregaestimada() As Date
        Get
            Return fechaentregaestimada
        End Get
        Set(ByVal value As Date)
            fechaentregaestimada = value
        End Set
    End Property

    Private fechapagoestimado As Date
    Public Property ordc_fechapagoestimado() As Date
        Get
            Return fechapagoestimado
        End Get
        Set(ByVal value As Date)
            fechapagoestimado = value
        End Set
    End Property

    Private semanapago As Integer
    Public Property ordc_semanapago() As Integer
        Get
            Return semanapago
        End Get
        Set(ByVal value As Integer)
            semanapago = value
        End Set
    End Property

    Private calleentrega As String
    Public Property ordc_calleentrega() As String
        Get
            Return calleentrega
        End Get
        Set(ByVal value As String)
            calleentrega = value
        End Set
    End Property

    Private numeroentrega As String
    Public Property ordc_numeroentrega() As String
        Get
            Return numeroentrega
        End Get
        Set(ByVal value As String)
            numeroentrega = value
        End Set
    End Property

    Private coloniaentrega As String
    Public Property ordc_coloniaentrega() As String
        Get
            Return coloniaentrega
        End Get
        Set(ByVal value As String)
            coloniaentrega = value
        End Set
    End Property

    Private ciudadid As Integer
    Public Property ordc_ciudadid() As Integer
        Get
            Return ciudadid
        End Get
        Set(ByVal value As Integer)
            ciudadid = value
        End Set
    End Property

    Private codigopostal As Double
    Public Property ordc_codigopostal() As Double
        Get
            Return codigopostal
        End Get
        Set(ByVal value As Double)
            codigopostal = value
        End Set
    End Property

    Private observaciones As String
    Public Property ordc_observaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

    Private estatus As String
    Public Property ordc_estatus() As String
        Get
            Return estatus
        End Get
        Set(ByVal value As String)
            estatus = value
        End Set
    End Property

    Private autorizacompraid As Integer
    Public Property ordc_autorizacompraid() As Integer
        Get
            Return autorizacompraid
        End Get
        Set(ByVal value As Integer)
            autorizacompraid = value
        End Set
    End Property

    Private fechaautorizacion As String
    Public Property ordc_fechaautorizacion() As String
        Get
            Return fechaautorizacion
        End Get
        Set(ByVal value As String)
            fechaautorizacion = value
        End Set
    End Property

    Private usuariocreoid As Integer
    Public Property ordc_usuariocreoid() As Integer
        Get
            Return usuariocreoid
        End Get
        Set(ByVal value As Integer)
            usuariocreoid = value
        End Set
    End Property

    Private usuariomodificoid As Integer
    Public Property ordc_usuariomodificoid() As Integer
        Get
            Return usuariomodificoid
        End Get
        Set(ByVal value As Integer)
            usuariomodificoid = value
        End Set
    End Property

    Private fechamodificacion As String
    Public Property ordc_fechamodificacion() As String
        Get
            Return fechamodificacion
        End Get
        Set(ByVal value As String)
            fechamodificacion = value
        End Set
    End Property

    Private subtotal As Double
    Public Property ordc_subtotal() As Double
        Get
            Return subtotal
        End Get
        Set(ByVal value As Double)
            subtotal = value
        End Set
    End Property

    Private iva As Double
    Public Property ordc_iva() As Double
        Get
            Return iva
        End Get
        Set(ByVal value As Double)
            iva = value
        End Set
    End Property

    Private total As Double
    Public Property ordc_total() As Double
        Get
            Return total
        End Get
        Set(ByVal value As Double)
            total = value
        End Set
    End Property

    Private anio As Integer
    Public Property ordc_anio() As Integer
        Get
            Return anio
        End Get
        Set(ByVal value As Integer)
            anio = value
        End Set
    End Property

    Private folio As Integer
    Public Property ordc_folio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property

    Private direccion As String
    Public Property ordc_direccion() As String
        Get
            Return direccion
        End Get
        Set(ByVal value As String)
            direccion = value
        End Set
    End Property

    Private paisid As Integer
    Public Property ordc_paisid() As Integer
        Get
            Return paisid
        End Get
        Set(ByVal value As Integer)
            paisid = value
        End Set
    End Property

    Private razonRechazo As String
    Public Property ordc_razonrechazo() As String
        Get
            Return razonRechazo
        End Get
        Set(ByVal value As String)
            razonRechazo = value
        End Set
    End Property

    'Private ciudadid2 As Integer
    'Public Property ordc_ciudadid() As Integer
    '    Get
    '        Return ciudadid
    '    End Get
    '    Set(ByVal value As Integer)
    '        ciudadid = value
    '    End Set
    'End Property

    Private estadoid As Integer
    Public Property ordc_estadoid() As Integer
        Get
            Return estadoid
        End Get
        Set(ByVal value As Integer)
            estadoid = value
        End Set
    End Property

    Private cp As String
    Public Property ordc_cp() As String
        Get
            Return cp
        End Get
        Set(ByVal value As String)
            cp = value
        End Set
    End Property

    Private tipocaptura As String
    Public Property ordc_tipocaptura() As String
        Get
            Return tipocaptura
        End Get
        Set(ByVal value As String)
            tipocaptura = value
        End Set
    End Property


End Class


