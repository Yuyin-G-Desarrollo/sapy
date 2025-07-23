
Public Class InfoVerificacionFolio

    Private PColaboradorId As Integer
    Private PMensajeriaId As Integer
    Private PMensajeria As String
    Private POperadorID As Integer
    Private POperador As String
    Private PUnidadID As Integer
    Private PUnidad As String
    Private PFolioPaqueteria As String
    Private PStatusID As Integer
    Private PUsuarioID As Integer
    Private PEsAndrea As Boolean

#Region "Propieddades"
    Public Property ColaboradorId As Integer
        Get
            Return PColaboradorId
        End Get
        Set(value As Integer)
            PColaboradorId = value
        End Set
    End Property

    Public Property MensajeriaId As Integer
        Get
            Return PMensajeriaId
        End Get
        Set(value As Integer)
            PMensajeriaId = value
        End Set
    End Property

    Public Property Mensajeria As String
        Get
            Return PMensajeria
        End Get
        Set(value As String)
            PMensajeria = value
        End Set
    End Property

    Public Property OperadorID As Integer
        Get
            Return POperadorID
        End Get
        Set(value As Integer)
            POperadorID = value
        End Set
    End Property

    Public Property Operador As String
        Get
            Return POperador
        End Get
        Set(value As String)
            POperador = value
        End Set
    End Property


    Public Property UnidadID As Integer
        Get
            Return PUnidadID
        End Get
        Set(value As Integer)
            PUnidadID = value
        End Set
    End Property

    Public Property Unidad As String
        Get
            Return PUnidad
        End Get
        Set(value As String)
            PUnidad = value
        End Set
    End Property

    Public Property FolioPaqueteria As String
        Get
            Return PFolioPaqueteria
        End Get
        Set(value As String)
            PFolioPaqueteria = value
        End Set
    End Property

    Public Property StatusID As Integer
        Get
            Return PStatusID
        End Get
        Set(value As Integer)
            PStatusID = value
        End Set
    End Property


    Public Property UsuarioID As Integer
        Get
            Return PUsuarioID
        End Get
        Set(value As Integer)
            PUsuarioID = value
        End Set
    End Property

    Public Property EsAndrea As Boolean
        Get
            Return PEsAndrea
        End Get
        Set(value As Boolean)
            PEsAndrea = value
        End Set
    End Property

#End Region

    Public Sub New()
        EsAndrea = False
    End Sub

End Class
