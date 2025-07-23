Public Class OrdenTrabajoCitaEntrega

    Private usuarioModifica As Integer
    Public Property PusuarioModifica() As Integer
        Get
            Return usuarioModifica
        End Get
        Set(ByVal value As Integer)
            usuarioModifica = value
        End Set
    End Property

    Private ordenesTrabajo As String
    Public Property PordenesTrabajo() As String
        Get
            Return ordenesTrabajo
        End Get
        Set(ByVal value As String)
            ordenesTrabajo = value
        End Set
    End Property

    Private fechaEntrega As String
    Public Property PfechaEntrega() As String
        Get
            Return fechaEntrega
        End Get
        Set(ByVal value As String)
            fechaEntrega = value
        End Set
    End Property

    Private clave As String
    Public Property Pclave() As String
        Get
            Return clave
        End Get
        Set(ByVal value As String)
            clave = value
        End Set
    End Property

    Private personasRequeridas As Integer
    Public Property PpersonasRequeridas() As Integer
        Get
            Return personasRequeridas
        End Get
        Set(ByVal value As Integer)
            personasRequeridas = value
        End Set
    End Property

    Private observaciones As String
    Public Property Pobservaciones() As String
        Get
            Return observaciones
        End Get
        Set(ByVal value As String)
            observaciones = value
        End Set
    End Property

End Class
