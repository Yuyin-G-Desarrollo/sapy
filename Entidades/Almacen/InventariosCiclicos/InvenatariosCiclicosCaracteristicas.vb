Public Class InvenatariosCiclicosCaracteristicas

    'INVENTARIO CICLICO CARACTERISTICAS
#Region "INVENTARIO CICLICO CARACTERISTICAS"
    Private IdInventarioCiclico As Integer
    Private IdCaracteristicaInventarioCiclico As Integer
    Private IdInventarioCiclicoConfCaracteristica As Integer
    Private CaracteristicaId As String

    Public Property PIDCaracteriticaInventarioCiclico As Int32
        Get
            Return IdCaracteristicaInventarioCiclico
        End Get
        Set(value As Int32)
            IdCaracteristicaInventarioCiclico = value
        End Set
    End Property

    Public Property PIdInventarioCiclico As Int32
        Get
            Return IdInventarioCiclico
        End Get
        Set(value As Int32)
            IdInventarioCiclico = value
        End Set
    End Property

    Public Property PIdConfiguracionCaracteristicaInventarioCiclico As Int32
        Get
            Return IdInventarioCiclicoConfCaracteristica
        End Get
        Set(value As Int32)
            IdInventarioCiclicoConfCaracteristica = value
        End Set
    End Property

    Public Property PCaracteristicaId As String
        Get
            Return CaracteristicaId
        End Get
        Set(value As String)
            CaracteristicaId = value
        End Set
    End Property
#End Region



End Class
