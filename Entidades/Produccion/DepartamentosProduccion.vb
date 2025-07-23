Public Class DepartamentosProduccion

    Private IDConfiguracion As Int32
    Private Nombre As String
    Private Dias As Int32
    Private FechaAvance As Date
    Private Celulas As String
    Private CelulasLista As List(Of CelulasProduccion)
    Private Orden As Int32
    Private DptoAnterior As Int32
    Private ConfiguracionDptoAnterior As Int32
    Private ColorDepartamento As String
    Private lotesAtrasados As Int32 = 0
    Private paresAtrasados As Int32 = 0
    Public Property PLotesAtrados As Int32
        Get
            Return lotesAtrasados
        End Get
        Set(value As Int32)
            lotesAtrasados = value
        End Set
    End Property
    Public Property PparesAtrasados As Int32
        Get
            Return paresAtrasados
        End Get
        Set(value As Int32)
            paresAtrasados = value
        End Set
    End Property
    Public Property PColorDepartamento As String
        Get
            Return ColorDepartamento
        End Get
        Set(value As String)
            ColorDepartamento = value
        End Set
    End Property

    Public Property PConfiguracionDptoAnterior As Int32
        Get
            Return ConfiguracionDptoAnterior
        End Get
        Set(value As Int32)
            ConfiguracionDptoAnterior = value
        End Set
    End Property


    Public Property PDptoAnterior As Int32
        Get
            Return DptoAnterior
        End Get
        Set(value As Int32)
            DptoAnterior = value
        End Set
    End Property

    Public Property POrden As Int32
        Get
            Return Orden
        End Get
        Set(value As Int32)
            Orden = value
        End Set
    End Property


    Public Property PCelulasLista As List(Of CelulasProduccion)
        Get
            Return CelulasLista
        End Get
        Set(ByVal value As List(Of CelulasProduccion))
            CelulasLista = value
        End Set
    End Property
    Public Property PCelulas As String
        Get
            Return Celulas
        End Get
        Set(ByVal value As String)
            Celulas = value
        End Set
    End Property

    Public Property PIDConfiguracion As Int32
        Get
            Return IDConfiguracion
        End Get
        Set(ByVal value As Int32)
            IDConfiguracion = value
        End Set
    End Property

    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property PDias As Int32
        Get
            Return Dias
        End Get
        Set(ByVal value As Int32)
            Dias = value
        End Set
    End Property

    Public Property PFechaAvance As DateTime
        Get
            Return FechaAvance
        End Get
        Set(ByVal value As DateTime)
            FechaAvance = value
        End Set
    End Property

End Class
