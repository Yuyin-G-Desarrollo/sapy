Public Class InfoAtadosEspeciales

    Dim _FolioDetalle As Integer
    Dim _NumeroAtados As Integer
    Dim _NumeroPares As Integer
    Dim _DtListadoAtadosEspeciales As New DataTable

    Public Property FolioDetalle As Integer
        Get
            Return _FolioDetalle
        End Get
        Set(value As Integer)
            _FolioDetalle = value
        End Set
    End Property

    Public Property NumeroAtados As Integer
        Get
            Return _NumeroAtados
        End Get
        Set(value As Integer)
            _NumeroAtados = value
        End Set
    End Property

    Public Property NumeroPares As Integer
        Get
            Return _NumeroPares
        End Get
        Set(value As Integer)
            _NumeroPares = value
        End Set
    End Property

    Public Property DtListadoAtadosEspeciales As DataTable
        Get
            Return _DtListadoAtadosEspeciales
        End Get
        Set(value As DataTable)
            _DtListadoAtadosEspeciales = value
        End Set
    End Property

End Class
