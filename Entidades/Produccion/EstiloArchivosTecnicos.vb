Public Class EstiloArchivosTecnicos

    Private IdEstilo As Integer
    Private EstiloProducto As String
    Public Property PIdEstilo As Integer
        Get
            Return IdEstilo
        End Get
        Set(value As Integer)
            IdEstilo = value
        End Set
    End Property

    Public Property PEstiloProducto As String
        Get
            Return EstiloProducto
        End Get
        Set(value As String)
            EstiloProducto = value
        End Set
    End Property



End Class
