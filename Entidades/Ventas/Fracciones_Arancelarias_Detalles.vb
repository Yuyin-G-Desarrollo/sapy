Public Class Fracciones_Arancelarias_Detalles
    Private frde_fraccionarancelariadetalleid As Integer
    Private frde_fraccionarancelariaid As Integer
    Private frde_familiaid As Integer
    Private frde_pielmuestraid As Integer
    Private frde_forroid As Integer
    Private frde_suelaid As Integer
    Private frde_tipocategoriaid As Integer
    Private frde_talla As String
    Private frde_activo As Boolean

    Public Property PFraccionArancelariaDetalleID As Integer
        Get
            Return frde_fraccionarancelariadetalleid
        End Get
        Set(value As Integer)
            frde_fraccionarancelariadetalleid = value
        End Set
    End Property

    Public Property PFraccionArancelariaId As Integer
        Get
            Return frde_fraccionarancelariaid
        End Get
        Set(value As Integer)
            frde_fraccionarancelariaid = value
        End Set
    End Property

    Public Property PFamiliaId As Integer
        Get
            Return frde_familiaid
        End Get
        Set(value As Integer)
            frde_familiaid = value
        End Set
    End Property

    Public Property PPielMuestraId As Integer
        Get
            Return frde_pielmuestraid
        End Get
        Set(value As Integer)
            frde_pielmuestraid = value
        End Set
    End Property

    Public Property PForroId As Integer
        Get
            Return frde_forroid
        End Get
        Set(value As Integer)
            frde_forroid = value
        End Set
    End Property

    Public Property PSuelaId As Integer
        Get
            Return frde_suelaid
        End Get
        Set(value As Integer)
            frde_suelaid = value
        End Set
    End Property

    Public Property PTipoCategoriaId As Integer
        Get
            Return frde_tipocategoriaid
        End Get
        Set(value As Integer)
            frde_tipocategoriaid = value
        End Set
    End Property

    Public Property PTalla As String
        Get
            Return frde_talla
        End Get
        Set(value As String)
            frde_talla = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return frde_activo
        End Get
        Set(value As Boolean)
            frde_activo = value
        End Set
    End Property

End Class
