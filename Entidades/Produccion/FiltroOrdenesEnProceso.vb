Public Class FiltroOrdenesEnProceso
    Private NaveID As Integer
    Private FechaInicio As String
    Private FechaFin As String
    Private PedidosSAYID As String
    Private PedidosSICYID As String
    Private Lotes As String
    Private GrupoNave As String
    Private ModelosSAY As String
    Private ModelosSICY As String
    Private NavesDesarrolloID As String
    Private HormasID As String
    Private ProveedoresSuelaID As String
    Private TemporadasID As String
    Private Corridas As String
    Private ClientesID As String
    Private SuelasID As String
    Private MarcasID As String
    Private ColeccionesID As String
    Private PielesColoresID As String
    Private FamiliasVentaID As String
    Private FamiliasID As String
    Private TipoConsulta As String
    Private TipoBusqueda As String

    Public Property PNaveID As Integer
        Get
            Return NaveID
        End Get
        Set(ByVal value As Integer)
            NaveID = value
        End Set
    End Property

    Public Property PFechaInicio As String
        Get
            Return FechaInicio
        End Get
        Set(ByVal value As String)
            FechaInicio = value
        End Set
    End Property

    Public Property PFechaFin As String
        Get
            Return FechaFin
        End Get
        Set(ByVal value As String)
            FechaFin = value
        End Set
    End Property

    Public Property PPedidosSAYID As String
        Get
            Return PedidosSAYID
        End Get
        Set(ByVal value As String)
            PedidosSAYID = value
        End Set
    End Property

    Public Property PPedidosSICYID As String
        Get
            Return PedidosSICYID
        End Get
        Set(ByVal value As String)
            PedidosSICYID = value
        End Set
    End Property

    Public Property PLotes As String
        Get
            Return Lotes
        End Get
        Set(ByVal value As String)
            Lotes = value
        End Set
    End Property

    Public Property PGrupoNave As String
        Get
            Return GrupoNave
        End Get
        Set(ByVal value As String)
            GrupoNave = value
        End Set
    End Property

    Public Property PModelosSAY As String
        Get
            Return ModelosSAY
        End Get
        Set(ByVal value As String)
            ModelosSAY = value
        End Set
    End Property

    Public Property PModelosSICY As String
        Get
            Return ModelosSICY
        End Get
        Set(ByVal value As String)
            ModelosSICY = value
        End Set
    End Property

    Public Property PNavesDesarrolloID As String
        Get
            Return NavesDesarrolloID
        End Get
        Set(ByVal value As String)
            NavesDesarrolloID = value
        End Set
    End Property

    Public Property PHormasID As String
        Get
            Return HormasID
        End Get
        Set(ByVal value As String)
            HormasID = value
        End Set
    End Property

    Public Property PProveedoresSuelaID As String
        Get
            Return ProveedoresSuelaID
        End Get
        Set(ByVal value As String)
            ProveedoresSuelaID = value
        End Set
    End Property

    Public Property PTemporadasID As String
        Get
            Return TemporadasID
        End Get
        Set(ByVal value As String)
            TemporadasID = value
        End Set
    End Property

    Public Property PCorridas As String
        Get
            Return Corridas
        End Get
        Set(ByVal value As String)
            Corridas = value
        End Set
    End Property

    Public Property PClientesID As String
        Get
            Return ClientesID
        End Get
        Set(ByVal value As String)
            ClientesID = value
        End Set
    End Property

    Public Property PSuelasID As String
        Get
            Return SuelasID
        End Get
        Set(ByVal value As String)
            SuelasID = value
        End Set
    End Property

    Public Property PMarcasID As String
        Get
            Return MarcasID
        End Get
        Set(ByVal value As String)
            MarcasID = value
        End Set
    End Property

    Public Property PColeccionesID As String
        Get
            Return ColeccionesID
        End Get
        Set(ByVal value As String)
            ColeccionesID = value
        End Set
    End Property

    Public Property PPielesColoresID As String
        Get
            Return PielesColoresID
        End Get
        Set(ByVal value As String)
            PielesColoresID = value
        End Set
    End Property

    Public Property PFamiliasVentaID As String
        Get
            Return FamiliasVentaID
        End Get
        Set(ByVal value As String)
            FamiliasVentaID = value
        End Set
    End Property


    Public Property PFamiliasID As String
        Get
            Return FamiliasID
        End Get
        Set(ByVal value As String)
            FamiliasID = value
        End Set
    End Property

    Public Property PTipoConsulta As String
        Get
            Return TipoConsulta
        End Get
        Set(ByVal value As String)
            TipoConsulta = value
        End Set
    End Property

    Public Property PTipoBusqueda As String
        Get
            Return TipoBusqueda
        End Get
        Set(ByVal value As String)
            TipoBusqueda = value
        End Set
    End Property


End Class
