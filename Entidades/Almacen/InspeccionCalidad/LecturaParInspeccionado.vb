

Public Class LecturaParInspeccionado


    Private _Folio As String
    Private _ParesFolio As String
    Private _RutaLogoNave As String
    Private _NaveId As Integer
    Private _Nave As String
    Private _UsuarioId As Integer
    Private _FechaInicio As Date
    Private _FechaTermino As Date
    Private _PorcentajeAInspeccionar As String
    Private _PorcentajeInspeccionado As String
    Private _ParesAInspeccionar As String
    Private _ParesInspeccionados As String
    Private _ParesIncidencias As String
    Private _ParesIncidenciasCriticas As String
    Private _ParesLotePiloto As String
    Private _ParesInspeccionadosLotePiloto As String
    Private _ParesDevueltos As String
    Private _InformacionPar As New InformacionParLeido
    Private _LotesPiloto As New List(Of LotesInspeccionados)
    Private _FolioInspeccionID As String


#Region "Propiedades"

    Public Property FolioInspeccionID As String
        Get
            Return _FolioInspeccionID
        End Get
        Set(value As String)
            _FolioInspeccionID = value
        End Set
    End Property

    Public Property LotesPiloto As List(Of LotesInspeccionados)
        Get
            Return _LotesPiloto
        End Get
        Set(value As List(Of LotesInspeccionados))
            _LotesPiloto = value
        End Set
    End Property


    Public Property InformacionPar As InformacionParLeido
        Get
            Return _InformacionPar
        End Get
        Set(value As InformacionParLeido)
            _InformacionPar = value
        End Set
    End Property

    Public Property Folio As String
        Get
            Return _Folio
        End Get
        Set(value As String)
            _Folio = value
        End Set
    End Property
    Public Property ParesFolio As String
        Get
            Return _ParesFolio
        End Get
        Set(value As String)
            _ParesFolio = value
        End Set
    End Property
    Public Property RutaLogoNave As String
        Get
            Return _RutaLogoNave
        End Get
        Set(value As String)
            _RutaLogoNave = value
        End Set
    End Property
    Public Property NaveId As Integer
        Get
            Return _NaveId
        End Get
        Set(value As Integer)
            _NaveId = value
        End Set
    End Property
    Public Property Nave As String
        Get
            Return _Nave
        End Get
        Set(value As String)
            _Nave = value
        End Set
    End Property
    Public Property UsuarioId As Integer
        Get
            Return _UsuarioId
        End Get
        Set(value As Integer)
            _UsuarioId = value
        End Set
    End Property
    Public Property FechaInicio As Date
        Get
            Return _FechaInicio
        End Get
        Set(value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaTermino As Date
        Get
            Return _FechaTermino
        End Get
        Set(value As Date)
            _FechaTermino = value
        End Set
    End Property
    Public Property PorcentajeAInspeccionar As String
        Get
            Return _PorcentajeAInspeccionar
        End Get
        Set(value As String)
            _PorcentajeAInspeccionar = value
        End Set
    End Property
    Public Property PorcentajeInspeccionado As String
        Get
            Return _PorcentajeInspeccionado
        End Get
        Set(value As String)
            _PorcentajeInspeccionado = value
        End Set
    End Property
    Public Property ParesAInspeccionar As String
        Get
            Return _ParesAInspeccionar
        End Get
        Set(value As String)
            _ParesAInspeccionar = value
        End Set
    End Property
    Public Property ParesInspeccionados As String
        Get
            Return _ParesInspeccionados
        End Get
        Set(value As String)
            _ParesInspeccionados = value
        End Set
    End Property
    Public Property ParesIncidencias As String
        Get
            Return _ParesIncidencias
        End Get
        Set(value As String)
            _ParesIncidencias = value
        End Set
    End Property
    Public Property ParesIncidenciasCriticas As String
        Get
            Return _ParesIncidenciasCriticas
        End Get
        Set(value As String)
            _ParesIncidenciasCriticas = value
        End Set
    End Property
    Public Property ParesLotePiloto As String
        Get
            Return _ParesLotePiloto
        End Get
        Set(value As String)
            _ParesLotePiloto = value
        End Set
    End Property
    Public Property ParesInspeccionadosLotePiloto As String
        Get
            Return _ParesInspeccionadosLotePiloto
        End Get
        Set(value As String)
            _ParesInspeccionadosLotePiloto = value
        End Set
    End Property
    Public Property ParesDevueltos As String
        Get
            Return _ParesDevueltos
        End Get
        Set(value As String)
            _ParesDevueltos = value
        End Set
    End Property

#End Region

    Sub New()
        Folio = String.Empty
        ParesFolio = "0"
        RutaLogoNave = String.Empty
        NaveId = 0
        Nave = String.Empty
        UsuarioId = 0
        FechaInicio = Date.Now
        FechaTermino = Date.Now
        PorcentajeAInspeccionar = String.Empty
        PorcentajeInspeccionado = String.Empty
        ParesAInspeccionar = String.Empty
        ParesInspeccionados = String.Empty
        ParesIncidencias = String.Empty
        ParesIncidenciasCriticas = String.Empty
        ParesLotePiloto = String.Empty
        ParesInspeccionadosLotePiloto = String.Empty
        ParesDevueltos = String.Empty


        'Dim lote As New LotesInspeccionados
        'lote.Año = "0"
        'lote.Estatus = ""
        'lote.Estilo = ""
        'lote.Lote = "0"
        'lote.NaveID = "0"
        'lote.Pares = "0"

        'LotesPiloto.Add(lote)

        'Dim lote2 As New LotesInspeccionados
        'lote2.Año = "0"
        'lote2.Estatus = ""
        'lote2.Estilo = ""
        'lote2.Lote = "0"
        'lote2.NaveID = "0"
        'lote2.Pares = "0"

        'LotesPiloto.Add(lote2)




    End Sub

End Class
