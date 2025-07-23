Public Class Remision
    Private remisionId As Integer
    Public Property RID() As Integer
        Get
            Return remisionId
        End Get
        Set(ByVal value As Integer)
            remisionId = value
        End Set
    End Property

    Private folio As Integer
    Public Property RFolio() As Integer
        Get
            Return folio
        End Get
        Set(ByVal value As Integer)
            folio = value
        End Set
    End Property

    Private anio As Int16
    Public Property RAnio() As Int16
        Get
            Return anio
        End Get
        Set(ByVal value As Int16)
            anio = value
        End Set
    End Property


    Private fecha As Date
    Public Property RFecha() As Date
        Get
            Return fecha
        End Get
        Set(ByVal value As Date)
            fecha = value
        End Set
    End Property

    Private subtotal As Double
    Public Property RSubtotal() As Double
        Get
            Return subtotal
        End Get
        Set(ByVal value As Double)
            subtotal = value
        End Set
    End Property

    Private total As Double
    Public Property RTotal() As Double
        Get
            Return total
        End Get
        Set(ByVal value As Double)
            total = value
        End Set
    End Property

    Private descuento As Double
    Public Property RDescuento() As Double
        Get
            Return descuento
        End Get
        Set(ByVal value As Double)
            descuento = value
        End Set
    End Property

    Private motivoDescuento As String
    Public Property RMotivoDescuento() As String
        Get
            Return motivoDescuento
        End Get
        Set(ByVal value As String)
            motivoDescuento = value
        End Set
    End Property

    Private pdf As String
    Public Property RPdf() As String
        Get
            Return pdf
        End Get
        Set(ByVal value As String)
            pdf = value
        End Set
    End Property

    Private estatus As String
    Public Property REstatus() As String
        Get
            Return estatus
        End Get
        Set(ByVal value As String)
            estatus = value
        End Set
    End Property

    Private observacion As String
    Public Property RObservacion() As String
        Get
            Return observacion
        End Get
        Set(ByVal value As String)
            observacion = value
        End Set
    End Property

    Private clienteId As Integer
    Public Property RClienteId() As Integer
        Get
            Return clienteId
        End Get
        Set(ByVal value As Integer)
            clienteId = value
        End Set
    End Property

    Private sucursalId As Integer
    Public Property RSucursalId() As Integer
        Get
            Return sucursalId
        End Get
        Set(ByVal value As Integer)
            sucursalId = value
        End Set
    End Property

    Private usaurioId As Integer
    Public Property RUsuarioId() As Integer
        Get
            Return usaurioId
        End Get
        Set(ByVal value As Integer)
            usaurioId = value
        End Set
    End Property

    Private usuarioIdCancelacion As Integer
    Public Property CUsuarioIdCancelacion() As Integer
        Get
            Return usuarioIdCancelacion
        End Get
        Set(ByVal value As Integer)
            usuarioIdCancelacion = value
        End Set
    End Property


    Private fechaCancelacion As Date
    Public Property RFechaCancelacion() As Date
        Get
            Return fechaCancelacion
        End Get
        Set(ByVal value As Date)
            fechaCancelacion = value
        End Set
    End Property

    Private motivoCancelacion As String
    Public Property RMotivoCancelacion() As String
        Get
            Return motivoCancelacion
        End Get
        Set(ByVal value As String)
            motivoCancelacion = value
        End Set
    End Property

    Private reporteId As Integer
    Public Property RReporteId() As Integer
        Get
            Return reporteId
        End Get
        Set(ByVal value As Integer)
            reporteId = value
        End Set
    End Property

End Class