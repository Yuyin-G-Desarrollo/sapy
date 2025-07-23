Public Class ConfiguracionPorcentajesMaquilas
    Private idNave As Integer
    Public Property cpmIdnave() As Integer
        Get
            Return idNave
        End Get
        Set(ByVal value As Integer)
            idNave = value
        End Set
    End Property
    Private grupo As String
    Public Property cmpGrupo() As String
        Get
            Return grupo
        End Get
        Set(ByVal value As String)
            grupo = value
        End Set
    End Property
    Private addHerramientas As Double
    Public Property cpmHerramientas() As Double
        Get
            Return addHerramientas
        End Get
        Set(ByVal value As Double)
            addHerramientas = value
        End Set
    End Property
    Private financiamiento As Double
    Public Property cpmFinanciamiento() As Double
        Get
            Return financiamiento
        End Get
        Set(ByVal value As Double)
            financiamiento = value
        End Set
    End Property
    Private fabrica As Double
    Public Property cpmFabrica() As Double
        Get
            Return fabrica
        End Get
        Set(ByVal value As Double)
            fabrica = value
        End Set
    End Property
    Private comercial As Double
    Public Property cpmComercial() As Double
        Get
            Return comercial
        End Get
        Set(ByVal value As Double)
            comercial = value
        End Set
    End Property
    Private idUsuario As Integer
    Public Property cpmIdUsaurio() As Integer
        Get
            Return idUsuario
        End Get
        Set(ByVal value As Integer)
            idUsuario = value
        End Set
    End Property
    Private administracion As Double
    Public Property cpmAdministracion() As Double
        Get
            Return administracion
        End Get
        Set(ByVal value As Double)
            administracion = value
        End Set
    End Property
    Private editado As Boolean
    Public Property cpmEditado() As Boolean
        Get
            Return editado
        End Get
        Set(ByVal value As Boolean)
            editado = value
        End Set
    End Property
    Private msrResult As String
    Public Property cpmMsgResult() As String
        Get
            Return msrResult
        End Get
        Set(ByVal value As String)
            msrResult = value
        End Set
    End Property
    Private isr As Double
    Public Property cpmIsr() As Double
        Get
            Return isr
        End Get
        Set(ByVal value As Double)
            isr = value
        End Set
    End Property
End Class
