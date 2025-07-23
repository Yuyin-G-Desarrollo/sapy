Imports Entidades

Public Class DocumentosEmbarque

    Private _factura As String
    Private _documento As Integer
    Private _cliente As String
    Private _clienteID As Integer
    Private _importe As Double
    Private _pares As Integer
    Private _error As ErrorEmbarque
    Public Property Factura As String
        Get
            Return _factura
        End Get
        Set(value As String)
            _factura = value
        End Set
    End Property

    Public Property Documento As Integer
        Get
            Return _documento
        End Get
        Set(value As Integer)
            _documento = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property ClienteID As Integer
        Get
            Return _clienteID
        End Get
        Set(value As Integer)
            _clienteID = value
        End Set
    End Property

    Public Property Importe As Double
        Get
            Return _importe
        End Get
        Set(value As Double)
            _importe = value
        End Set
    End Property

    Public Property Pares As Integer
        Get
            Return _pares
        End Get
        Set(value As Integer)
            _pares = value
        End Set
    End Property


End Class
