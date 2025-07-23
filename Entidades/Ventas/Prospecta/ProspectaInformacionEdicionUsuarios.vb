Public Class ProspectaInformacionEdicionUsuarios


    Private PUsuarioID As Int32
    Private PClienteSayID As Int32
    Private PUserName As String
    Private PHora As String
    Private PFechaActividad As Date
  
#Region "Propiedaes"

    Public Property UsuarioID As Integer
        Get
            Return PUsuarioID
        End Get
        Set(value As Integer)
            PUsuarioID = value
        End Set
    End Property

    Public Property ClienteSayID As Integer
        Get
            Return PClienteSayID
        End Get
        Set(value As Integer)
            PClienteSayID = value
        End Set
    End Property

    Public Property UserName As String
        Get
            Return PUserName
        End Get
        Set(value As String)
            PUserName = value
        End Set
    End Property

    Public Property Hora As String
        Get
            Return PHora
        End Get
        Set(value As String)
            PHora = value
        End Set
    End Property

    Public Property FechaActividad As Date
        Get
            Return PFechaActividad
        End Get
        Set(value As Date)
            PFechaActividad = value
        End Set
    End Property

#End Region

End Class
