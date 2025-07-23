Public Class ReporteDeInventarioPrecioBase
    Private _Datos As DataTable
    Private _totalPares As Integer
    Private _ParesSiPrecio As Integer

    Public Property Datos As DataTable
        Get
            Return _Datos
        End Get
        Set(value As DataTable)
            _Datos = value
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

    Public Property ParesSiPrecio As Integer
        Get
            Return _ParesSiPrecio
        End Get
        Set(value As Integer)
            _ParesSiPrecio = value
        End Set
    End Property
End Class
