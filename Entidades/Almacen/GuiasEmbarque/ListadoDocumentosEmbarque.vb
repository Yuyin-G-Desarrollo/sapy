Imports Entidades

Public Class ListadoDocumentosEmbarque

    Private _listadoDocumentos As List(Of Entidades.DocumentosEmbarque)
    Private _totalPares As Integer
    Private _error As Boolean
    Private _mensaje As String

    Public Property ListadoDocumentos As List(Of DocumentosEmbarque)
        Get
            Return _listadoDocumentos
        End Get
        Set(value As List(Of DocumentosEmbarque))
            _listadoDocumentos = value
        End Set
    End Property

    Public Property TotalPares As Integer
        Get
            Return _totalPares
        End Get
        Set(value As Integer)
            _totalPares = value
        End Set
    End Property

    Public Property [Error] As Boolean
        Get
            Return _error
        End Get
        Set(value As Boolean)
            _error = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property
End Class
