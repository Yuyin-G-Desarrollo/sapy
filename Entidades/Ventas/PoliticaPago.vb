Public Class PoliticaPago

    Private Ppoliticapagoid As Integer
    Public Property politicapagoid() As Integer
        Get
            Return Ppoliticapagoid
        End Get
        Set(ByVal value As Integer)
            Ppoliticapagoid = value
        End Set
    End Property

    Private Pparcialidades1 As Integer
    Public Property parcialidades1() As Integer
        Get
            Return Pparcialidades1
        End Get
        Set(ByVal value As Integer)
            Pparcialidades1 = value
        End Set
    End Property

    Private Pparcialidadesx As Integer
    Public Property parcialidadesx() As Integer
        Get
            Return Pparcialidadesx
        End Get
        Set(ByVal value As Integer)
            Pparcialidadesx = value
        End Set
    End Property

    Private Pmetodopago As MetodoPago
    Public Property metodopago() As MetodoPago
        Get
            Return Pmetodopago
        End Get
        Set(ByVal value As MetodoPago)
            Pmetodopago = value
        End Set
    End Property

    Private Pformapago As FormaPago
    Public Property formapago() As FormaPago
        Get
            Return Pformapago
        End Get
        Set(ByVal value As FormaPago)
            Pformapago = value
        End Set
    End Property

    Private Pimprimirficharap As Boolean
    Public Property imprimirficharap() As Boolean
        Get
            Return Pimprimirficharap
        End Get
        Set(ByVal value As Boolean)
            Pimprimirficharap = value
        End Set
    End Property

    Private Pplazoreal As Integer
    Public Property plazoreal() As Integer
        Get
            Return Pplazoreal
        End Get
        Set(ByVal value As Integer)
            Pplazoreal = value
        End Set
    End Property

    Private Pnotascobranza As String
    Public Property notascobranza() As String
        Get
            Return Pnotascobranza
        End Get
        Set(ByVal value As String)
            Pnotascobranza = value
        End Set
    End Property

    Private Pnotasdevoluciones As String
    Public Property notasdevoluciones() As String
        Get
            Return Pnotasdevoluciones
        End Get
        Set(ByVal value As String)
            Pnotasdevoluciones = value
        End Set
    End Property

    Private Pcliente As Cliente
    Public Property cliente() As Cliente
        Get
            Return Pcliente
        End Get
        Set(ByVal value As Cliente)
            Pcliente = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property

    Private Pproporcionarcuentaremision As Boolean
    Public Property proporcionarcuentaremision As Boolean
        Get
            Return Pproporcionarcuentaremision
        End Get
        Set(ByVal value As Boolean)
            Pproporcionarcuentaremision = value
        End Set
    End Property


End Class
