Public Class ProgramacionCatalogoJustificaciones
    Private _id As Int32
    Private _mensaje As String

    Public Property Id As Int32
        Get
            Return _id
        End Get
        Set(value As Int32)
            _id = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value.ToUpper
        End Set
    End Property
End Class
