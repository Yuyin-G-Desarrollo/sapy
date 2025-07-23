Public Class FiltrosBloqueos
    Private Activo As Integer
    Public Property PActivo As Integer
        Get
            Return Activo
        End Get
        Set(value As Integer)
            Activo = value
        End Set
    End Property

    Private Inactivo As Integer
    Public Property PInactivo As Integer
        Get
            Return Inactivo
        End Get
        Set(value As Integer)
            Inactivo = value
        End Set
    End Property

    Private Bloqueados As Integer
    Public Property PBloqueados As Integer
        Get
            Return Bloqueados
        End Get
        Set(value As Integer)
            Bloqueados = value
        End Set
    End Property

    Private NoBloqueados As Integer
    Public Property PNoBloqueados As Integer
        Get
            Return NoBloqueados
        End Get
        Set(value As Integer)
            NoBloqueados = value
        End Set
    End Property

    Private Anio As Integer
    Public Property PAnio As Integer
        Get
            Return Anio
        End Get
        Set(value As Integer)
            Anio = value
        End Set
    End Property

    Private NoSemana As Integer
    Public Property PNoSemana As Integer
        Get
            Return NoSemana
        End Get
        Set(value As Integer)
            NoSemana = value
        End Set
    End Property

    Private Clientes As String
    Public Property PClientes As String
        Get
            Return Clientes
        End Get
        Set(value As String)
            Clientes = value
        End Set
    End Property

    Private Agentes As String
    Public Property PAgentes As String
        Get
            Return Agentes
        End Get
        Set(value As String)
            Agentes = value
        End Set
    End Property

End Class
