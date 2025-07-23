Public Class LimiteCapacidad

    Private limiteCapacidad_ As Int32
    Public Property LimiteCapacidadID As Int32
        Get
            Return limiteCapacidad_
        End Get
        Set(ByVal value As Int32)
            limiteCapacidad_ = value
        End Set
    End Property

    Private lineaId_ As Int32
    Public Property LineaId As Int32
        Get
            Return lineaId_
        End Get
        Set(ByVal value As Int32)
            lineaId_ = value
        End Set
    End Property

    Private simulacionMaestroId_ As Int32
    Public Property SimulacionMaestroId As Int32
        Get
            Return simulacionMaestroId_
        End Get
        Set(ByVal value As Int32)
            simulacionMaestroId_ = value
        End Set
    End Property

    Private porcentaje_ As Boolean
    Public Property Porcentaje As Boolean
        Get
            Return porcentaje_
        End Get
        Set(ByVal value As Boolean)
            porcentaje_ = value
        End Set
    End Property

    Private cantidad_ As Int32
    Public Property Cantidad As Int32
        Get
            Return cantidad_
        End Get
        Set(ByVal value As Int32)
            cantidad_ = value
        End Set
    End Property

    Private semana_ As Int32
    Public Property semana As Int32
        Get
            Return semana_
        End Get
        Set(ByVal value As Int32)
            semana_ = value
        End Set
    End Property

    Private anio_ As Int32
    Public Property Anio As Int32
        Get
            Return anio_
        End Get
        Set(ByVal value As Int32)
            anio_ = value
        End Set
    End Property

    Private dias_ As Double
    Public Property Dias As Double
        Get
            Return dias_
        End Get
        Set(ByVal value As Double)
            dias_ = value
        End Set
    End Property

    Private activo_ As Boolean
    Public Property Activo As Boolean
        Get
            Return activo_
        End Get
        Set(ByVal value As Boolean)
            activo_ = value
        End Set
    End Property

End Class
