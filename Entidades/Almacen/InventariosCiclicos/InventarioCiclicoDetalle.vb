Public Class InventarioCiclicoDetalle

    'INVENTARIO CILCICO DETALLES
#Region "INVENTARIO CICLICO DETALLE"
    Private IdInventarioDetalle As Integer
    Private IdInventario As Integer
    Private IdPar As String
    Private IdAtado As String
    Private UbicacionVitual As String

    Public Property PInventarioDetalleId As Int32
        Get
            Return IdInventarioDetalle
        End Get
        Set(value As Int32)
            IdInventarioDetalle = value
        End Set
    End Property

    Public Property PInventarioId As Int32
        Get
            Return IdInventario
        End Get
        Set(value As Int32)
            IdInventario = value
        End Set
    End Property

    Public Property PIdPar As String
        Get
            Return IdPar
        End Get
        Set(value As String)
            IdPar = value
        End Set
    End Property

    Public Property PIdAtado As String
        Get
            Return IdAtado
        End Get
        Set(value As String)
            IdAtado = value
        End Set
    End Property

    Public Property PUbicacionVirtual As String
        Get
            Return UbicacionVitual
        End Get
        Set(value As String)
            UbicacionVitual = value
        End Set
    End Property
#End Region





End Class
