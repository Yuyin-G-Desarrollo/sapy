Public Class HistorialSalarios

    Private IDHistorial As Int32
    Private IDColaborador As Colaborador
    Private Fecha As Date
    Private Sueldo As Double

    Public Property PIDHistorial As Int32
        Get
            Return IDHistorial
        End Get
        Set(ByVal value As Int32)
            IDHistorial = value
        End Set
    End Property

    Public Property PIDColaborador As Colaborador
        Get
            Return IDColaborador
        End Get
        Set(ByVal value As Colaborador)
            IDColaborador = value
        End Set
    End Property

    Public Property PFecha As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property

    Public Property PSueldo As Double
        Get
            Return Sueldo
        End Get
        Set(ByVal value As Double)
            Sueldo = value
        End Set
    End Property
End Class
