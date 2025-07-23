Public Class Fracciones_Arancelarias

    Private Id_FraccionArancelaria As Integer
    Private Codigo As String
    Private Nombre As String
    Private Activo As Boolean


    Public Property PIdPraccionArancelaria As Integer
        Get
            Return Id_FraccionArancelaria
        End Get
        Set(value As Integer)
            Id_FraccionArancelaria = value
        End Set
    End Property


    Public Property PCodigo As String
        Get
            Return Codigo
        End Get
        Set(value As String)
            Codigo = value
        End Set
    End Property


    Public Property PNombre As String
        Get
            Return Nombre
        End Get
        Set(value As String)
            Nombre = value
        End Set
    End Property


    Public Property PActivo() As Boolean
        Get
            Return Activo
        End Get
        Set(ByVal value As Boolean)
            Activo = value
        End Set
    End Property



End Class
