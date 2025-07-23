Public Class DetalleHorario

    Private Horario As Entidades.Horarios

    Private id As Integer
    Private hora_check As DateTime
    Private inicio_bloque As DateTime
    Private fin_bloque As DateTime
    Private dia As Integer
    Private check As Integer

    Public Property DH_horario As Entidades.Horarios
        Get
            Return Horario
        End Get
        Set(ByVal value As Entidades.Horarios)
            Horario = value
        End Set
    End Property

    Public Property DH_ID As Integer
        Get
            Return id
        End Get
        Set(ByVal value As Integer)
            id = value
        End Set
    End Property

    Public Property DH_HoraCheck As DateTime
        Get
            Return hora_check
        End Get
        Set(ByVal value As DateTime)
            hora_check = value
        End Set
    End Property

    Public Property DH_InicioBloque As DateTime
        Get
            Return inicio_bloque
        End Get
        Set(ByVal value As DateTime)
            inicio_bloque = value
        End Set
    End Property

    Public Property DH_FinBloque As DateTime
        Get
            Return fin_bloque
        End Get
        Set(ByVal value As DateTime)
            fin_bloque = value
        End Set
    End Property

    Public Property DH_Dia As Integer
        Get
            Return dia
        End Get
        Set(ByVal value As Integer)
            dia = value
        End Set
    End Property

    Public Property DH_TipoCheck As Integer
        Get
            Return check
        End Get
        Set(ByVal value As Integer)
            check = value
        End Set
    End Property

End Class