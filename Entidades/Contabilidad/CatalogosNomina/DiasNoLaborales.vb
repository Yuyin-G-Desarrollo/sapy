Public Class DiasNoLaborales
    Private _ID_Dia As Integer
    Private _Fecha As DateTime
    Private patron As Integer
    Private _fechaISS As Date
    Private _fechaFSS As Date
    Private _fechaIN As Date
    Private _fechaFN As Date
    Private _descripción As String
    Private _usuario As Integer
    Private _fechaC As DateTime
    Private _resp As Integer
    Private _mensaje As String
    Private _anio As Integer

    Public Property ID_Dia As Integer
        Get
            Return _ID_Dia
        End Get
        Set(value As Integer)
            _ID_Dia = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Descripción As String
        Get
            Return _descripción
        End Get
        Set(value As String)
            _descripción = value
        End Set
    End Property

    Public Property Usuario As Integer
        Get
            Return _usuario
        End Get
        Set(value As Integer)
            _usuario = value
        End Set
    End Property

    Public Property FechaC As Date
        Get
            Return _fechaC
        End Get
        Set(value As Date)
            _fechaC = value
        End Set
    End Property

    Public Property Resp As Integer
        Get
            Return _resp
        End Get
        Set(value As Integer)
            _resp = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(value As String)
            _mensaje = value
        End Set
    End Property

    Public Property Anio As Integer
        Get
            Return _anio
        End Get
        Set(value As Integer)
            _anio = value
        End Set
    End Property

    Public Property Patron1 As Integer
        Get
            Return patron
        End Get
        Set(value As Integer)
            patron = value
        End Set
    End Property

    Public Property FechaISS As Date
        Get
            Return _fechaISS
        End Get
        Set(value As Date)
            _fechaISS = value
        End Set
    End Property

    Public Property FechaFSS As Date
        Get
            Return _fechaFSS
        End Get
        Set(value As Date)
            _fechaFSS = value
        End Set
    End Property

    Public Property FechaIN As Date
        Get
            Return _fechaIN
        End Get
        Set(value As Date)
            _fechaIN = value
        End Set
    End Property

    Public Property FechaFN As Date
        Get
            Return _fechaFN
        End Get
        Set(value As Date)
            _fechaFN = value
        End Set
    End Property
End Class
