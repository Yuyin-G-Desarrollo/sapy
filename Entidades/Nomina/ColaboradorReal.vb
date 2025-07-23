Public Class ColaboradorReal
    Private ColaboradorRealId As Int32
    Private ColaboradorId As Colaborador
    Private Cantidad As Double
    Private Fecha As Date
    Private Tipo As String
    Private TipoPago As String
    Private Numero As String
    Private Banco As Int32
    Private CostoFraccion As Double
    Private SueldoSemanalAguinaldo As Double


    Public Property PSueldoSemanalAguinaldo As Double
        Get
            Return SueldoSemanalAguinaldo
        End Get
        Set(ByVal value As Double)
            SueldoSemanalAguinaldo = value
        End Set
    End Property

    Public Property PCostoFraccion As Double
        Get
            Return CostoFraccion
        End Get
        Set(ByVal value As Double)
            CostoFraccion = value
        End Set
    End Property

    Public Property PBanco As Int32
        Get
            Return Banco
        End Get
        Set(ByVal value As Int32)
            Banco = value
        End Set
    End Property



    Public Property PNumero As String
        Get
            Return Numero
        End Get
        Set(ByVal value As String)
            Numero = value
        End Set
    End Property

    Public Property PColaboradorRealId As Int32
        Get
            Return ColaboradorRealId
        End Get
        Set(ByVal value As Int32)
            ColaboradorRealId = value
        End Set
    End Property

    Public Property PColaboradorId As Colaborador
        Get
            Return ColaboradorId
        End Get
        Set(ByVal value As Colaborador)
            ColaboradorId = value
        End Set
    End Property

    Public Property PCantidad As Double
        Get
            Return Cantidad
        End Get
        Set(ByVal value As Double)
            Cantidad = value
        End Set
    End Property

    Public Property PFecha As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property

    Public Property PTipo As String
        Get
            Return Tipo
        End Get
        Set(ByVal value As String)
            Tipo = value
        End Set
    End Property

    Public Property PTipoPago As String
        Get
            Return TipoPago
        End Get
        Set(ByVal value As String)
            TipoPago = value
        End Set
    End Property
End Class
