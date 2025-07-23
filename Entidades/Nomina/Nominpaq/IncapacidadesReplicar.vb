Public Class IncapacidadesReplicar

    Private Incapacidades As Incapacidades
    Private Colaborador As Colaborador


    Public Property PIncapacidades As Incapacidades
        Get
            Return Incapacidades
        End Get
        Set(value As Incapacidades)
            Incapacidades = value
        End Set
    End Property

    Public Property PColaborador As Colaborador
        Get
            Return Colaborador
        End Get
        Set(value As Colaborador)
            Colaborador = value
        End Set
    End Property

End Class
