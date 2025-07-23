
Public Class TipoValidacion

    Private Ptipovalidacionid As Integer
    Public Property tipovalidacionid() As Integer
        Get
            Return Ptipovalidacionid
        End Get
        Set(ByVal value As Integer)
            Ptipovalidacionid = value
        End Set
    End Property

    Private Pnombre As String
    Public Property nombre() As String
        Get
            Return Pnombre
        End Get
        Set(ByVal value As String)
            Pnombre = value
        End Set
    End Property

    Private Pcolaboradoridvalida As Colaborador
    Public Property colaboradoridvalida() As Colaborador
        Get
            Return Pcolaboradoridvalida
        End Get
        Set(ByVal value As Colaborador)
            Pcolaboradoridvalida = value
        End Set
    End Property

    Private Pactivo As Boolean
    Public Property activo() As Boolean
        Get
            Return Pactivo
        End Get
        Set(ByVal value As Boolean)
            Pactivo = value
        End Set
    End Property


End Class
