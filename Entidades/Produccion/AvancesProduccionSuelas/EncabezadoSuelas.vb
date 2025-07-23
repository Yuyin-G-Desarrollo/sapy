Public Class EncabezadoSuelas
    Private _Programa As String
    Private _ProgramaSuelas As String
    Private _Pares As Integer
    Private _Nave As String
    Private _Molde As String
    Private _ColorSuela As String
    Private _Acabado As String
    Private _Familia As String
    Private _RutaImagen As String
    Private _MaquinaId As Integer
    Private _TotalAvance As Integer
    Private _ConsecutivoTarjeta As Integer
    Private _FgTarjetaAgrupada As Boolean


    Public Property Programa As String
        Get
            Return _Programa
        End Get
        Set(value As String)
            _Programa = value
        End Set
    End Property

    Public Property ProgramaSuelas As String
        Get
            Return _ProgramaSuelas
        End Get
        Set(value As String)
            _ProgramaSuelas = value
        End Set
    End Property

    Public Property Pares As Integer
        Get
            Return _Pares
        End Get
        Set(value As Integer)
            _Pares = value
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

    Public Property Molde As String
        Get
            Return _Molde
        End Get
        Set(value As String)
            _Molde = value
        End Set
    End Property

    Public Property ColorSuela As String
        Get
            Return _ColorSuela
        End Get
        Set(value As String)
            _ColorSuela = value
        End Set
    End Property

    Public Property Acabado As String
        Get
            Return _Acabado
        End Get
        Set(value As String)
            _Acabado = value
        End Set
    End Property

    Public Property Familia As String
        Get
            Return _Familia
        End Get
        Set(value As String)
            _Familia = value
        End Set
    End Property
    Public Property RutaImagen As String
        Get
            Return _RutaImagen
        End Get
        Set(value As String)
            _RutaImagen = value
        End Set
    End Property

    Public Property MaquinaId As Integer
        Get
            Return _MaquinaId
        End Get
        Set(value As Integer)
            _MaquinaId = value
        End Set
    End Property

    Public Property TotalAvance As Integer
        Get
            Return _TotalAvance
        End Get
        Set(value As Integer)
            _TotalAvance = value
        End Set
    End Property

    Public Property ConsecutivoTarjeta As Integer
        Get
            Return _ConsecutivoTarjeta
        End Get
        Set(value As Integer)
            _ConsecutivoTarjeta = value
        End Set
    End Property

    Public Property FgTarjetaAgrupada As Boolean
        Get
            Return _FgTarjetaAgrupada
        End Get
        Set(value As Boolean)
            _FgTarjetaAgrupada = value
        End Set
    End Property

    Sub New()
        Programa = String.Empty
        ProgramaSuelas = String.Empty
        Pares = 0
        Nave = String.Empty
        Molde = String.Empty
        ColorSuela = String.Empty
        Acabado = String.Empty
        Familia = String.Empty
        RutaImagen = String.Empty
        MaquinaId = 0
        TotalAvance = 0
        ConsecutivoTarjeta = 0
        FgTarjetaAgrupada = False

    End Sub
End Class
