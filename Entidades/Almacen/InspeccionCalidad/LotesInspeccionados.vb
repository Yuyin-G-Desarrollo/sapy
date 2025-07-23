Public Class LotesInspeccionados

    Private _Lote As String
    Private _NaveID As String
    Private _Año As String
    Private _Estilo As String
    Private _Estatus As String
    Private _Pares As String
    Private _Descripcion As String

#Region "Propiedades"

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Lote As String
        Get
            Return _Lote
        End Get
        Set(value As String)
            _Lote = value
        End Set
    End Property

    Public Property NaveID As String
        Get
            Return _NaveID
        End Get
        Set(value As String)
            _NaveID = value
        End Set
    End Property

    Public Property Año As String
        Get
            Return _Año
        End Get
        Set(value As String)
            _Año = value
        End Set
    End Property


    Public Property Estilo As String
        Get
            Return _Estilo
        End Get
        Set(value As String)
            _Estilo = value
        End Set
    End Property


    Public Property Estatus As String
        Get
            Return _Estatus
        End Get
        Set(value As String)
            _Estatus = value
        End Set
    End Property

    Public Property Pares As String
        Get
            Return _Pares
        End Get
        Set(value As String)
            _Pares = value
        End Set
    End Property

#End Region


    Sub New()
        Lote = String.Empty
        NaveID = "0"
        Año = "0"
        Estilo = String.Empty
        Estatus = "0"
        Pares = "0"
    End Sub

End Class
