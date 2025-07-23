Public Class LotesAvances

    Private Año As Int32
    Private Nave As Int16
    Private Lote As Int32
    Private Modelo As String
    Private Coleccion As String
    Private Marca As String
    Private Talla As String
    Private Color As String
    Private Pares As Int32
    Private Observacion As String
    Private IdD1 As Int16
    Private D1 As String
    Private FD1 As DateTime
    Private IdD2 As Int16
    Private D2 As String
    Private FD2 As DateTime
    Private IdD3 As Int16
    Private D3 As String
    Private FD3 As DateTime
    Private IdD4 As Int16
    Private D4 As String
    Private FD4 As DateTime
    Private IdD5 As Int16
    Private D5 As String
    Private FD5 As DateTime
    Private Embarque As DateTime
    Private FechaLote As DateTime
    Private avanceDepartamento1 As DateTime
    Private avanceDepartamento2 As DateTime
    Private avanceDepartamento3 As DateTime
    Private avanceDepartamentos As New List(Of DepartamentosProduccion)
    Private Celula As Int32
    Private motivoDepartamento1 As String
    Private motivoDepartamento2 As String
    Private motivoDepartamento3 As String
    Private clienteTexto As String
    Private idPedido As String
    Private diasAtrasados1 As Double
    Private diasAtrasados2 As Double
    Private diasAtrasados3 As Double

    Public Property PDiasAtrasados1 As Double
        Get
            Return diasAtrasados1
        End Get
        Set(ByVal value As Double)
            diasAtrasados1 = value
        End Set
    End Property
    Public Property PDiasAtrasados2 As Double
        Get
            Return diasAtrasados2
        End Get
        Set(ByVal value As Double)
            diasAtrasados2 = value
        End Set
    End Property
    Public Property PDiasAtrasados3 As Double
        Get
            Return diasAtrasados3
        End Get
        Set(ByVal value As Double)
            diasAtrasados3 = value
        End Set
    End Property
    Public Property PCelula As Int32
        Get
            Return Celula
        End Get
        Set(ByVal value As Int32)
            Celula = value
        End Set
    End Property



    Public Property PAvanceDepartamentos As List(Of DepartamentosProduccion)
        Get
            Return avanceDepartamentos
        End Get
        Set(ByVal value As List(Of DepartamentosProduccion))
            avanceDepartamentos = value
        End Set
    End Property

    Public Property PavanceDepartamento3 As DateTime
        Get
            Return avanceDepartamento3
        End Get
        Set(ByVal value As DateTime)
            avanceDepartamento3 = value
        End Set
    End Property

    Public Property PavanceDepartamento2 As DateTime
        Get
            Return avanceDepartamento2
        End Get
        Set(ByVal value As DateTime)
            avanceDepartamento2 = value
        End Set
    End Property

    Public Property PavanceDepartamento1 As DateTime
        Get
            Return avanceDepartamento1
        End Get
        Set(ByVal value As DateTime)
            avanceDepartamento1 = value
        End Set
    End Property

    Public Property PAño As Int32
        Get
            Return Año
        End Get
        Set(ByVal value As Int32)
            Año = value
        End Set
    End Property

    Public Property PNave As Int16
        Get
            Return Nave
        End Get
        Set(ByVal value As Int16)
            Nave = value
        End Set
    End Property

    Public Property PLote As Int32
        Get
            Return Lote
        End Get
        Set(ByVal value As Int32)
            Lote = value
        End Set
    End Property

    Public Property PModelo As String
        Get
            Return Modelo
        End Get
        Set(ByVal value As String)
            Modelo = value
        End Set
    End Property

    Public Property PColeccion As String
        Get
            Return Coleccion
        End Get
        Set(ByVal value As String)
            Coleccion = value
        End Set
    End Property

    Public Property PTalla As String
        Get
            Return Talla
        End Get
        Set(ByVal value As String)
            Talla = value
        End Set
    End Property

    Public Property PColor As String
        Get
            Return Color
        End Get
        Set(ByVal value As String)
            Color = value
        End Set
    End Property

    Public Property PPares As Int32
        Get
            Return Pares
        End Get
        Set(ByVal value As Int32)
            Pares = value
        End Set
    End Property

    Public Property PFechaEmbarque As DateTime
        Get
            Return Embarque
        End Get
        Set(ByVal value As DateTime)
            Embarque = value
        End Set
    End Property

    Public Property PFechaLote As DateTime
        Get
            Return FechaLote
        End Get
        Set(ByVal value As DateTime)
            FechaLote = value
        End Set
    End Property

    Public Property PObservaciones As String
        Get
            Return Observacion
        End Get
        Set(ByVal value As String)
            Observacion = value
        End Set
    End Property

    Public Property PIdD1 As Int16
        Get
            Return IdD1
        End Get
        Set(ByVal value As Int16)
            IdD1 = value
        End Set
    End Property

    Public Property PD1 As String
        Get
            Return D1
        End Get
        Set(ByVal value As String)
            D1 = value
        End Set
    End Property

    Public Property PFD1 As DateTime
        Get
            Return FD1
        End Get
        Set(ByVal value As DateTime)
            FD1 = value
        End Set
    End Property

    Public Property PIdD2 As Int16
        Get
            Return IdD2
        End Get
        Set(ByVal value As Int16)
            IdD2 = value
        End Set
    End Property

    Public Property PD2 As String
        Get
            Return D2
        End Get
        Set(ByVal value As String)
            D2 = value
        End Set
    End Property

    Public Property PFD2 As DateTime
        Get
            Return FD2
        End Get
        Set(ByVal value As DateTime)
            FD2 = value
        End Set
    End Property

    Public Property PIdD3 As Int16
        Get
            Return IdD3
        End Get
        Set(ByVal value As Int16)
            IdD3 = value
        End Set
    End Property

    Public Property PD3 As String
        Get
            Return D3
        End Get
        Set(ByVal value As String)
            D3 = value
        End Set
    End Property

    Public Property PFD3 As DateTime
        Get
            Return FD3
        End Get
        Set(ByVal value As DateTime)
            FD3 = value
        End Set
    End Property

    Public Property PIdD4 As Int16
        Get
            Return IdD4
        End Get
        Set(ByVal value As Int16)
            IdD4 = value
        End Set
    End Property

    Public Property PD4 As String
        Get
            Return D4
        End Get
        Set(ByVal value As String)
            D4 = value
        End Set
    End Property

    Public Property PFD4 As DateTime
        Get
            Return FD4
        End Get
        Set(ByVal value As DateTime)
            FD4 = value
        End Set
    End Property

    Public Property PIdD5 As Int16
        Get
            Return IdD5
        End Get
        Set(ByVal value As Int16)
            IdD5 = value
        End Set
    End Property

    Public Property PD5 As String
        Get
            Return D5
        End Get
        Set(ByVal value As String)
            D5 = value
        End Set
    End Property

    Public Property PFD5 As DateTime
        Get
            Return FD5
        End Get
        Set(ByVal value As DateTime)
            FD5 = value
        End Set
    End Property
    Public Property pmotivoDepartamento1 As String
        Get
            Return motivoDepartamento1
        End Get
        Set(ByVal value As String)
            motivoDepartamento1 = value
        End Set
    End Property
    Public Property pmotivoDepartamento2 As String
        Get
            Return motivoDepartamento2
        End Get
        Set(ByVal value As String)
            motivoDepartamento2 = value
        End Set
    End Property
    Public Property pmotivoDepartamento3 As String
        Get
            Return motivoDepartamento3
        End Get
        Set(ByVal value As String)
            motivoDepartamento3 = value
        End Set
    End Property
    Public Property pclienteTexto As String
        Get
            Return clienteTexto
        End Get
        Set(ByVal value As String)
            clienteTexto = value
        End Set
    End Property
    Public Property pidPedido As String
        Get
            Return idPedido
        End Get
        Set(ByVal value As String)
            idPedido = value
        End Set
    End Property

    Public Property PMarca As String
        Get
            Return Marca
        End Get
        Set(ByVal value As String)
            Marca = value
        End Set
    End Property
End Class
