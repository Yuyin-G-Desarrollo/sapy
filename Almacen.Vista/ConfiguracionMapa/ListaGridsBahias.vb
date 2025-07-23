Public Class ListaGridsBahias

    Private ListaGrids As New C1.Win.C1FlexGrid.C1FlexGrid
    Private ListaBahias As New List(Of Entidades.Bahia)
    Private Bloque As String

    Public Property PBloque As String
        Get
            Return Bloque
        End Get
        Set(value As String)
            Bloque = value
        End Set
    End Property

    Public Property PListaGrids As C1.Win.C1FlexGrid.C1FlexGrid
        Get
            Return ListaGrids
        End Get
        Set(value As C1.Win.C1FlexGrid.C1FlexGrid)
            ListaGrids = value
        End Set
    End Property

    Public Property PlistaBahias As List(Of Entidades.Bahia)
        Get
            Return ListaBahias
        End Get
        Set(value As List(Of Entidades.Bahia))
            ListaBahias = value
        End Set
    End Property

End Class
