Public Class GeneracionIncidencia

    Private fechaIncidencia As String
    Private ColaboradOroperadorId As Integer
    Private ParesEntregados As Integer
    Private TipoIncidenciaId As Integer
    Private Observaciones As String
    Private UbicacionMercancia As String
    Private ProximaEntrega As Integer
    Private FechaProximaEntrega As String
    Private SalidaVentasEmbarqueId As Integer
    Private UsuarioCreoId As Integer
    Private Cliente As String

    Public Property PfechaIncidencia As String
        Get
            Return fechaIncidencia
        End Get
        Set(value As String)
            fechaIncidencia = value
        End Set
    End Property

    Public Property PColaboradOroperadorId As Integer
        Get
            Return ColaboradOroperadorId
        End Get
        Set(value As Integer)
            ColaboradOroperadorId = value
        End Set
    End Property

    Public Property PParesEntregados As Integer
        Get
            Return ParesEntregados
        End Get
        Set(value As Integer)
            ParesEntregados = value
        End Set
    End Property

    Public Property PTipoIncidenciaId As Integer
        Get
            Return TipoIncidenciaId
        End Get
        Set(value As Integer)
            TipoIncidenciaId = value
        End Set
    End Property

    Public Property PObservaciones As String
        Get
            Return Observaciones
        End Get
        Set(value As String)
            Observaciones = value
        End Set
    End Property

    Public Property PUbicacionMercancia As String
        Get
            Return UbicacionMercancia
        End Get
        Set(value As String)
            UbicacionMercancia = value
        End Set
    End Property

    Public Property PProximaEntrega As Integer
        Get
            Return ProximaEntrega
        End Get
        Set(value As Integer)
            ProximaEntrega = value
        End Set
    End Property

    Public Property PFechaProximaEntrega As String
        Get
            Return FechaProximaEntrega
        End Get
        Set(value As String)
            FechaProximaEntrega = value
        End Set
    End Property

    Public Property PSalidaVentasEmbarqueId As Integer
        Get
            Return SalidaVentasEmbarqueId
        End Get
        Set(value As Integer)
            SalidaVentasEmbarqueId = value
        End Set
    End Property

    Public Property PUsuarioCreoId As Integer
        Get
            Return UsuarioCreoId
        End Get
        Set(value As Integer)
            UsuarioCreoId = value
        End Set
    End Property

    Public Property PCliente As String
        Get
            Return Cliente
        End Get
        Set(value As String)
            Cliente = value
        End Set
    End Property

End Class
