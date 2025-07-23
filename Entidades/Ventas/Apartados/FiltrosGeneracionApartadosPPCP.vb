Public Class FiltrosGeneracionApartadosPPCP

#Region "FECHAS"

    Private MostrarFechaEntrega As Integer
    Public Property PMostrarFechaEntrega As Integer
        Get
            Return MostrarFechaEntrega
        End Get
        Set(ByVal value As Integer)
            MostrarFechaEntrega = value
        End Set
    End Property

    Private FechaEntregaDel As String
    Public Property PFechaEntregaDel As String
        Get
            Return FechaEntregaDel
        End Get
        Set(ByVal value As String)
            FechaEntregaDel = value
        End Set
    End Property

    Private FechaEntregaAl As String
    Public Property PFechaEntregaAl As String
        Get
            Return FechaEntregaAl
        End Get
        Set(ByVal value As String)
            FechaEntregaAl = value
        End Set
    End Property

    Private MostrarFechaPrograma As Integer
    Public Property PMostrarFechaPrograma As Integer
        Get
            Return MostrarFechaPrograma
        End Get
        Set(ByVal value As Integer)
            MostrarFechaPrograma = value
        End Set
    End Property

    Private FechaProgramaDel As String
    Public Property PFechaProgramaDel As String
        Get
            Return FechaProgramaDel
        End Get
        Set(ByVal value As String)
            FechaProgramaDel = value
        End Set
    End Property

    Private FechaProgramaAl As String
    Public Property PFechaProgramaAl As String
        Get
            Return FechaProgramaAl
        End Get
        Set(ByVal value As String)
            FechaProgramaAl = value
        End Set
    End Property

#End Region

#Region "TIPO ATADO"

    Private AtadoNON As Integer
    Public Property PAtadoNON As Integer
        Get
            Return AtadoNON
        End Get
        Set(ByVal value As Integer)
            AtadoNON = value
        End Set
    End Property

    Private AtadoPAR As Integer
    Public Property PAtadoPAR As Integer
        Get
            Return AtadoPAR
        End Get
        Set(ByVal value As Integer)
            AtadoPAR = value
        End Set
    End Property

    Private AtadoPUNTO As Integer
    Public Property PAtadoPUNTO As Integer
        Get
            Return AtadoPUNTO
        End Get
        Set(ByVal value As Integer)
            AtadoPUNTO = value
        End Set
    End Property

    Private ParesDestallados As Integer
    Public Property PParesDestallados As Integer
        Get
            Return ParesDestallados
        End Get
        Set(ByVal value As Integer)
            ParesDestallados = value
        End Set
    End Property

    Private DestallarNormales As Integer
    Public Property PDestallarNormales As Integer
        Get
            Return DestallarNormales
        End Get
        Set(ByVal value As Integer)
            DestallarNormales = value
        End Set
    End Property

    Private DestallarPuntos As Integer
    Public Property PDestallarPuntos As Integer
        Get
            Return DestallarPuntos
        End Get
        Set(ByVal value As Integer)
            DestallarPuntos = value
        End Set
    End Property

#End Region

#Region "Cantidades Partidas Y Tallas"

    Private CantidadTallas As Integer
    Public Property PCantidadTallas As Integer
        Get
            Return CantidadTallas
        End Get
        Set(ByVal value As Integer)
            CantidadTallas = value
        End Set
    End Property

    Private CantidadPares As Integer
    Public Property PCantidadPares As Integer
        Get
            Return CantidadPares
        End Get
        Set(ByVal value As Integer)
            CantidadPares = value
        End Set
    End Property

    Private Final_o_Descartar As Integer
    Public Property PFinal_o_Descartar As Integer
        Get
            Return Final_o_Descartar
        End Get
        Set(ByVal value As Integer)
            Final_o_Descartar = value
        End Set
    End Property

#End Region

    Private PedidoSAY As String
    Public Property PPedidoSAY As String
        Get
            Return PedidoSAY
        End Get
        Set(ByVal value As String)
            PedidoSAY = value
        End Set
    End Property

    Private PedidoSICY As String
    Public Property PPedidoSICY As String
        Get
            Return PedidoSICY
        End Get
        Set(ByVal value As String)
            PedidoSICY = value
        End Set
    End Property

    Private Cliente As String
    Public Property PCliente As String
        Get
            Return Cliente
        End Get
        Set(ByVal value As String)
            Cliente = value
        End Set
    End Property

    Private Tienda As String
    Public Property PTienda As String
        Get
            Return Tienda
        End Get
        Set(ByVal value As String)
            Tienda = value
        End Set
    End Property

    Private Nave As String
    Public Property PNave As String
        Get
            Return Nave
        End Get
        Set(ByVal value As String)
            Nave = value
        End Set
    End Property

    Private Marca As String
    Public Property PMarca As String
        Get
            Return Marca
        End Get
        Set(ByVal value As String)
            Marca = value
        End Set
    End Property

    Private Coleccion As String
    Public Property PColeccion As String
        Get
            Return Coleccion
        End Get
        Set(ByVal value As String)
            Coleccion = value
        End Set
    End Property

    Private Modelo As String
    Public Property PModelo As String
        Get
            Return Modelo
        End Get
        Set(ByVal value As String)
            Modelo = value
        End Set
    End Property

    Private Corrida As String
    Public Property PCorrida As String
        Get
            Return Corrida
        End Get
        Set(ByVal value As String)
            Corrida = value
        End Set
    End Property

    Private Ranking As String
    Public Property PRanking As String
        Get
            Return Ranking
        End Get
        Set(ByVal value As String)
            Ranking = value
        End Set
    End Property

    Private NaveSICY As String
    Public Property PNaveSICY As String
        Get
            Return NaveSICY
        End Get
        Set(ByVal value As String)
            NaveSICY = value
        End Set
    End Property


End Class
