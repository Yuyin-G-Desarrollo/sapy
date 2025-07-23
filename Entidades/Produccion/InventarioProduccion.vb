Public Class InventarioProduccion
    Private Fecha As Date
    Private LotesProg As Int32
    Private ParesProg As Int32
    Private LotesTerminados As Int32
    Private ParesTerminados As Int32
    Private IDDepartamento As Int32
    Private Inventario As Double
    Private Programas As Double
    Private ParesProceso As Int32
    Private ParesTerminadosnave As Int32
    Private PrimerFechaNave As Date
    Private PrimerFechaDepartamento As Date

    'PROPIEDAD AGREGADA POR LUIS MARIO 14/05/2018 PARA OBTENER LA CANTIDAD DE DIAS POR PROGRAMA DESDE LA BD
    Private CantidadDiaslote As Double

    Public Property PPrimerFechaNave As Date
        Get
            Return PrimerFechaNave
        End Get
        Set(ByVal value As Date)
            PrimerFechaNave = value
        End Set
    End Property

    Public Property PPrimerFechaDepartamento As Date
        Get
            Return PrimerFechaDepartamento
        End Get
        Set(ByVal value As Date)
            PrimerFechaDepartamento = value
        End Set
    End Property


    Public Property PParesTerminadosnave As Int32
        Get
            Return ParesTerminadosnave
        End Get
        Set(ByVal value As Int32)
            ParesTerminadosnave = value
        End Set
    End Property

    Public Property PParesProceso As Int32
        Get
            Return ParesProceso
        End Get
        Set(ByVal value As Int32)
            ParesProceso = value
        End Set
    End Property


    Public Property PProgramas As Double
        Get
            Return Programas
        End Get
        Set(value As Double)
            Programas = value
        End Set
    End Property

    Public Property PInventario As Double
        Get
            Return Inventario
        End Get
        Set(value As Double)
            Inventario = value
        End Set
    End Property

    Public Property PIDDepartamento As Int32
        Get
            Return IDDepartamento
        End Get
        Set(ByVal value As Int32)
            IDDepartamento = value
        End Set
    End Property

    Public Property PFecha As Date
        Get
            Return Fecha
        End Get
        Set(ByVal value As Date)
            Fecha = value
        End Set
    End Property

    Public Property PLotesProg As Int32
        Get
            Return LotesProg
        End Get
        Set(ByVal value As Int32)
            LotesProg = value
        End Set
    End Property
    Public Property PParesProg As Int32
        Get
            Return ParesProg
        End Get
        Set(ByVal value As Int32)
            ParesProg = value
        End Set
    End Property
    Public Property PLotesTerminados As Int32
        Get
            Return LotesTerminados
        End Get
        Set(ByVal value As Int32)
            LotesTerminados = value
        End Set
    End Property
    Public Property PParesTerminados As Int32
        Get
            Return ParesTerminados
        End Get
        Set(ByVal value As Int32)
            ParesTerminados = value
        End Set
    End Property

    'PROPIEDAD AGREGADA POR LUIS MARIO 14/05/2018 PARA OBTENER LA CANTIDAD DE DIAS POR PROGRAMA DESDE LA BD
    Public Property PCantidadDiaslote As Double
        Get
            Return CantidadDiaslote
        End Get
        Set(ByVal value As Double)
            CantidadDiaslote = value
        End Set
    End Property

End Class
