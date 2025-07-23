Public Class UltimoAvance
    Private _ParesTerminados As Integer
    Private _Maquina As Integer
    Private _Hora As String
    Private _Fecha As String
    Private _NombreColaborador As String

    Public Property ParesTerminados As Integer
        Get
            Return _ParesTerminados
        End Get
        Set(value As Integer)
            _ParesTerminados = value
        End Set
    End Property

    Public Property Maquina As Integer
        Get
            Return _Maquina
        End Get
        Set(value As Integer)
            _Maquina = value
        End Set
    End Property

    Public Property Hora As String
        Get
            Return _Hora
        End Get
        Set(value As String)
            _Hora = value
        End Set
    End Property

    Public Property Fecha As String
        Get
            Return _Fecha
        End Get
        Set(value As String)
            _Fecha = value
        End Set
    End Property

    Public Property NombreColaborador As String
        Get
            Return _NombreColaborador
        End Get
        Set(value As String)
            _NombreColaborador = value
        End Set
    End Property


End Class
