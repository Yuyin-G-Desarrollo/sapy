
Public Class InventariosCiclicos

    'INVENTARIO CICLICO
#Region "INVENTARIO CICLICO"
    Private IdInventarioCiclico As Integer
    Private Descripcion As String
    Private IDoperador As Integer
    Private Fechaprogramada As String
    Private TotalPares As Integer
    Private Estado As Integer
    Private Par_Atado As String

    Public Property PPar_Atado As String
        Get
            Return Par_Atado
        End Get
        Set(value As String)
            Par_Atado = value
        End Set
    End Property

    Public Property PEstado As Int32
        Get
            Return Estado
        End Get
        Set(value As Int32)
            Estado = value
        End Set
    End Property

    Public Property PIdInventario As Int32
        Get
            Return IdInventarioCiclico
        End Get
        Set(value As Int32)
            IdInventarioCiclico = value
        End Set
    End Property

    Public Property PDescripcion As String
        Get
            Return Descripcion
        End Get
        Set(value As String)
            Descripcion = value
        End Set
    End Property

    Public Property PIdOPerador As Int32
        Get
            Return IDoperador
        End Get
        Set(value As Int32)
            IDoperador = value
        End Set
    End Property

    Public Property PFechaProgramada As String
        Get
            Return Fechaprogramada
        End Get
        Set(value As String)
            Fechaprogramada = value
        End Set
    End Property

    Public Property PTotalPares As Int32
        Get
            Return TotalPares
        End Get
        Set(value As Int32)
            TotalPares = value
        End Set
    End Property
#End Region

 

End Class
