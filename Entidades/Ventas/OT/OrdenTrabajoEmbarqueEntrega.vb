Public Class OrdenTrabajoEmbarqueEntrega

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

    Private mensajeriaIdSAY As Integer
    Public Property PmensajeriaIdSAY() As Integer
        Get
            Return mensajeriaIdSAY
        End Get
        Set(ByVal value As Integer)
            mensajeriaIdSAY = value
        End Set
    End Property

    Private unidadIdSICY As Integer
    Public Property PunidadIdSICY() As Integer
        Get
            Return unidadIdSICY
        End Get
        Set(ByVal value As Integer)
            unidadIdSICY = value
        End Set
    End Property

    Private operadorIdSAY As Integer
    Public Property PoperadorIdSAY() As Integer
        Get
            Return operadorIdSAY
        End Get
        Set(ByVal value As Integer)
            operadorIdSAY = value
        End Set
    End Property

    Private fechaRegreso As String
    Public Property PfechaRegreso() As String
        Get
            Return fechaRegreso
        End Get
        Set(ByVal value As String)
            fechaRegreso = value
        End Set
    End Property

End Class
