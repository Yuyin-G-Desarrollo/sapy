Public Class PlataformaEntrada
    Private PIdPlataforma As Integer
    Private PPlataforma As String
    Private PListaAtados As New List(Of Entidades.CapturaAtadoValido)
    Public Property IdPlataforma As Integer
        Get
            Return PIdPlataforma
        End Get
        Set(value As Integer)
            PIdPlataforma = value
        End Set
    End Property

    Public Property Plataforma As String
        Get
            Return PPlataforma
        End Get
        Set(value As String)
            PPlataforma = value
        End Set
    End Property

    Public Property ListaAtados As List(Of Entidades.CapturaAtadoValido)
        Get
            Return PListaAtados
        End Get
        Set(value As List(Of Entidades.CapturaAtadoValido))
            PListaAtados = value
        End Set
    End Property
End Class
