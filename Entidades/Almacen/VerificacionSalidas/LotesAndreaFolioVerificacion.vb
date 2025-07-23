
Public Class LotesAndreaFolioVerificacion

    Private PSeleccionar As Boolean
    Private PID As Integer
    Private PLoteAndrea As Integer
    Private PPartida As Integer
    Private POrdenTrabajoID As Integer


#Region "Propiedades"

    Public Property Seleccionar As Boolean
        Get
            Return PSeleccionar
        End Get
        Set(value As Boolean)
            PSeleccionar = value
        End Set
    End Property

    Public Property ID As Integer
        Get
            Return PID
        End Get
        Set(value As Integer)
            PID = value
        End Set
    End Property

    Public Property LoteAndrea As Integer
        Get
            Return PLoteAndrea
        End Get
        Set(value As Integer)
            PLoteAndrea = value
        End Set
    End Property

    Public Property Partida As Integer
        Get
            Return PPartida
        End Get
        Set(value As Integer)
            PPartida = value
        End Set
    End Property

    Public Property OrdenTrabajoID As Integer
        Get
            Return POrdenTrabajoID
        End Get
        Set(value As Integer)
            POrdenTrabajoID = value
        End Set
    End Property


#End Region

End Class
