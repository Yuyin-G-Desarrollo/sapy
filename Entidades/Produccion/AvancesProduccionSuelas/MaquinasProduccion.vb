Public Class MaquinasProduccion
    Private _MaquinaProveedorId As Integer
    Private _Maquina As String

    Public Property MaquinaProveedorId As Integer
        Get
            Return _MaquinaProveedorId
        End Get
        Set(value As Integer)
            _MaquinaProveedorId = value
        End Set
    End Property

    Public Property Maquina As String
        Get
            Return _Maquina
        End Get
        Set(value As String)
            _Maquina = value
        End Set
    End Property
End Class
