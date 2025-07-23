Public Class ControlAsistenciaReplicar
    Private ControlAsistenciaRegistroCheck As Entidades.RegistroCheck
    Private CorteChecador As Entidades.CorteChecador
    Private Colaborador As Entidades.Colaborador
    Private periodoID As Integer
    Private fechaPeriodo As DateTime

    Public Property PfechaPeriodo As DateTime
        Get
            Return fechaPeriodo
        End Get
        Set(value As DateTime)
            fechaPeriodo = value
        End Set
    End Property

    Public Property PPeriodoID As Integer
        Get
            Return periodoID
        End Get
        Set(value As Integer)
            periodoID = value
        End Set
    End Property

    Public Property PControlAsistenciaRegistroCheck As Entidades.RegistroCheck
        Get
            Return ControlAsistenciaRegistroCheck
        End Get
        Set(value As Entidades.RegistroCheck)
            ControlAsistenciaRegistroCheck = value
        End Set
    End Property

    Public Property PCorteChecador As Entidades.CorteChecador
        Get
            Return CorteChecador
        End Get
        Set(value As Entidades.CorteChecador)
            CorteChecador = value
        End Set
    End Property

    Public Property PColaborador As Entidades.Colaborador
        Get
            Return Colaborador
        End Get
        Set(value As Entidades.Colaborador)
            Colaborador = value
        End Set
    End Property

End Class
