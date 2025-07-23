Public Class BitacoraCancelaciones

    Private _naveIdSAY As String
    Private _pedidoIdSAY As String
    Private _pedidoIdSICY As String
    Private _filtroFechaCancelacion As Boolean
    Private _fechaCancelacionDe As String
    Private _fechaCancelacionA As String
    Private _filtroSemanas As Boolean
    Private _añoSemanaLiberadaDe As Integer
    Private _semanaLiberadaDe As Integer
    Private _añoSemanaLiberadaA As Integer
    Private _semanaLiberadaA As Integer

    Public Property naveIdSAY As String
        Get
            Return _naveIdSAY
        End Get
        Set(value As String)
            _naveIdSAY = value
        End Set
    End Property


    Public Property pedidoIdSAY As String
        Get
            Return _pedidoIdSAY
        End Get
        Set(value As String)
            _pedidoIdSAY = value
        End Set
    End Property



    Public Property pedidoIdSICY As String
        Get
            Return _pedidoIdSICY
        End Get
        Set(value As String)
            _pedidoIdSICY = value
        End Set
    End Property


    Public Property filtroFechaCancelacion As Boolean
        Get
            Return _filtroFechaCancelacion
        End Get
        Set(value As Boolean)
            _filtroFechaCancelacion = value
        End Set
    End Property


    Public Property fechaCancelacionDe As String
        Get
            Return _fechaCancelacionDe
        End Get
        Set(value As String)
            _fechaCancelacionDe = value
        End Set
    End Property


    Public Property fechaCancelacionA As String
        Get
            Return _fechaCancelacionA
        End Get
        Set(value As String)
            _fechaCancelacionA = value
        End Set
    End Property


    Public Property filtroSemanas As Boolean
        Get
            Return _filtroSemanas
        End Get
        Set(value As Boolean)
            _filtroSemanas = value
        End Set
    End Property


    Public Property añoSemanaLiberadaDe As Integer
        Get
            Return _añoSemanaLiberadaDe
        End Get
        Set(value As Integer)
            _añoSemanaLiberadaDe = value
        End Set
    End Property


    Public Property semanaLiberadaDe As Integer
        Get
            Return _semanaLiberadaDe
        End Get
        Set(value As Integer)
            _semanaLiberadaDe = value
        End Set
    End Property


    Public Property añoSemanaLiberadaA As Integer
        Get
            Return _añoSemanaLiberadaA
        End Get
        Set(value As Integer)
            _añoSemanaLiberadaA = value
        End Set
    End Property


    Public Property semanaLiberadaA As Integer
        Get
            Return _semanaLiberadaA
        End Get
        Set(value As Integer)
            _semanaLiberadaA = value
        End Set
    End Property


End Class
