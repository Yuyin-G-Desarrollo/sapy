Public Class Puestos

    Private Puestosid As Int32
    Private PuestoIDNP As Integer
    Private Nombre As String
    Private Nave As Naves
    Private Activo As Boolean
    Private Departamento As Entidades.Departamentos
    Public areas As Entidades.Areas
    Private Orden As Int32

    Public Property PPuestoIDNP As Integer
        Get
            Return PuestoIDNP
        End Get
        Set(value As Integer)
            PuestoIDNP = value
        End Set
    End Property

    Public Property Pareas As Entidades.Areas
        Get
            Return areas

        End Get
        Set(value As Entidades.Areas)
            areas = value

        End Set
    End Property
    Public Property PDepartamento As Entidades.Departamentos
        Get
            Return Departamento

        End Get
        Set(value As Entidades.Departamentos)
            Departamento = value
        End Set
    End Property

    Public Property Ppuestosid As Int32
        Get
            Return Puestosid
        End Get
        Set(value As Int32)
            Puestosid = value
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

    Public Property PNave As Naves
        Get
            Return Nave
        End Get
        Set(value As Naves)
            Nave = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return Activo
        End Get
        Set(value As Boolean)
            Activo = value
        End Set
    End Property


    Public Property POrden As Int32
        Get
            Return Orden
        End Get
        Set(ByVal value As Int32)
            Orden = value
        End Set
    End Property


End Class
