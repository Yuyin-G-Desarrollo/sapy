Public Class Credenciales

    Private codr_colaboradorid As Int32
    Private codigo As String
    Private codr_nombre As String
    Private apellidos As String
    Private grup_name As String
    Private area_nombre As String
    Private pues_nombre As String
    Private foto As String
    Private idNave As Integer

    Public Property Pcodr_colaboradorid As Int32
        Get
            Return codr_colaboradorid
        End Get
        Set(value As Int32)
            codr_colaboradorid = value
        End Set
    End Property


    Public Property Pcodigo As String
        Get
            Return codigo
        End Get
        Set(value As String)
            codigo = value
        End Set
    End Property



    Public Property Pcodr_nombre As String
        Get
            Return codr_nombre
        End Get
        Set(value As String)
            codr_nombre = value
        End Set
    End Property


    Public Property Papellidos As String
        Get
            Return apellidos
        End Get
        Set(value As String)
            apellidos = value
        End Set
    End Property

    Public Property Pgrup_name As String
        Get
            Return grup_name
        End Get
        Set(value As String)
            grup_name = value
        End Set
    End Property


    Public Property Parea_nombre As String
        Get
            Return area_nombre
        End Get
        Set(value As String)
            area_nombre = value
        End Set
    End Property



    Public Property Ppues_nombre As String
        Get
            Return pues_nombre
        End Get
        Set(value As String)
            pues_nombre = value
        End Set
    End Property

    Public Property Pfoto As String
        Get
            Return foto
        End Get
        Set(value As String)
            foto = value
        End Set
    End Property

    Public Property PNave As Integer
        Get
            Return idNave
        End Get
        Set(value As Integer)
            idNave = value
        End Set
    End Property



End Class
