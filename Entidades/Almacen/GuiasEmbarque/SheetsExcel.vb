Public Class SheetsExcel
    Private _nombreHoja As String
    Private _numero As Integer

    Public Property NombreHoja As String
        Get
            Return _nombreHoja
        End Get
        Set(value As String)
            _nombreHoja = value
        End Set
    End Property

    Public Property Numero As Integer
        Get
            Return _numero
        End Get
        Set(value As Integer)
            _numero = value
        End Set
    End Property
End Class
