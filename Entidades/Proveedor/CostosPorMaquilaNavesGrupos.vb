Public Class CostosPorMaquilaNavesGrupos
    Private idcostoMaquila As Int32
    Public Property cpm_IdCostoMaquila() As Int32
        Get
            Return idcostoMaquila
        End Get
        Set(ByVal value As Int32)
            idcostoMaquila = value
        End Set
    End Property
    Private semana As Int32
    Public Property cpmsemana() As Int32
        Get
            Return semana
        End Get
        Set(ByVal value As Int32)
            semana = value
        End Set
    End Property
    Private idNave As Int32
    Public Property cpmIdNave() As Int32
        Get
            Return idNave
        End Get
        Set(ByVal value As Int32)
            idNave = value
        End Set
    End Property
    Private grupo As String
    Public Property cpmgrupo() As String
        Get
            Return grupo
        End Get
        Set(ByVal value As String)
            grupo = value
        End Set
    End Property
    Private paresProducidos As Int32
    Public Property cpmparesProducidos() As Int32
        Get
            Return paresProducidos
        End Get
        Set(ByVal value As Int32)
            paresProducidos = value
        End Set
    End Property
    Private importeCompra As Decimal
    Public Property cpmImporteCompra() As Decimal
        Get
            Return importeCompra
        End Get
        Set(ByVal value As Decimal)
            importeCompra = value
        End Set
    End Property
    Private importeVenta As Decimal
    Public Property cpmImporteVenta() As Decimal
        Get
            Return importeVenta
        End Get
        Set(ByVal value As Decimal)
            importeVenta = value
        End Set
    End Property
    Private precioVentaPar As Decimal
    Public Property cpmprecioVentaPar() As Decimal
        Get
            Return precioVentaPar
        End Get
        Set(ByVal value As Decimal)
            precioVentaPar = value
        End Set
    End Property
    Private utilidadBrutaTotal As Decimal
    Public Property cpmUtilidadBrutaTotal() As Decimal
        Get
            Return utilidadBrutaTotal
        End Get
        Set(ByVal value As Decimal)
            utilidadBrutaTotal = value
        End Set
    End Property
    Private utilidadBrutaPar As Decimal
    Public Property cpmUtilidadBrutaPar() As Decimal
        Get
            Return utilidadBrutaPar
        End Get
        Set(ByVal value As Decimal)
            utilidadBrutaPar = value
        End Set
    End Property
    Private utilidadPorPorcentaje As Decimal
    Public Property cpmUtilidadPorPorcentaje() As Decimal
        Get
            Return utilidadPorPorcentaje
        End Get
        Set(ByVal value As Decimal)
            utilidadPorPorcentaje = value
        End Set
    End Property
    Private isr As Decimal
    Public Property cpmisr() As Decimal
        Get
            Return isr
        End Get
        Set(ByVal value As Decimal)
            isr = value
        End Set
    End Property
    Private financiamiento As Decimal
    Public Property cpmfinanciamiento() As Decimal
        Get
            Return financiamiento
        End Get
        Set(ByVal value As Decimal)
            financiamiento = value
        End Set
    End Property
    Private dd_herramental As Decimal
    Public Property cpmdd_Herramental() As Decimal
        Get
            Return dd_herramental
        End Get
        Set(ByVal value As Decimal)
            dd_herramental = value
        End Set
    End Property
    Private utilidadNetaTotal As Decimal
    Public Property cpmutilidadNetaTotal() As Decimal
        Get
            Return utilidadNetaTotal
        End Get
        Set(ByVal value As Decimal)
            utilidadNetaTotal = value
        End Set
    End Property
    Private utilidadNetaPar As Decimal
    Public Property cpmutilidadNetaPar() As Decimal
        Get
            Return utilidadNetaPar
        End Get
        Set(ByVal value As Decimal)
            utilidadNetaPar = value
        End Set
    End Property
    Private utilidadNetaPorcentaje As Decimal
    Public Property cpmuitlidadNetaPorcentaje() As Decimal
        Get
            Return utilidadNetaPorcentaje
        End Get
        Set(ByVal value As Decimal)
            utilidadNetaPorcentaje = value
        End Set
    End Property
    Private utilidadNetaFabrica As Decimal
    Public Property cpmutilidadNetaFabrica() As Decimal
        Get
            Return utilidadNetaFabrica
        End Get
        Set(ByVal value As Decimal)
            utilidadNetaFabrica = value
        End Set
    End Property
    Private utilidadNetaAdmon As Decimal
    Public Property cpmutilidadNetaAdmon() As Decimal
        Get
            Return utilidadNetaAdmon
        End Get
        Set(ByVal value As Decimal)
            utilidadNetaAdmon = value
        End Set
    End Property
    Private utilidadNetaComercial As Decimal
    Public Property cpmutilidadNetaComercial() As Decimal
        Get
            Return utilidadNetaComercial
        End Get
        Set(ByVal value As Decimal)
            utilidadNetaComercial = value
        End Set
    End Property
    Private semanaIncio As Int32
    Public Property cpmsemanaInicio() As Int32
        Get
            Return semanaIncio
        End Get
        Set(ByVal value As Int32)
            semanaIncio = value
        End Set
    End Property
    Private semanaFinal As Int32
    Public Property cpmsemanaFinal() As Int32
        Get
            Return semanaFinal
        End Get
        Set(ByVal value As Int32)
            semanaFinal = value
        End Set
    End Property
    Private anio As Int32
    Public Property cpmanio() As Int32
        Get
            Return anio
        End Get
        Set(ByVal value As Int32)
            anio = value
        End Set
    End Property
    Private MsgResult As String
    Public Property cpmMsgResult() As String
        Get
            Return MsgResult
        End Get
        Set(ByVal value As String)
            MsgResult = value
        End Set
    End Property
End Class
