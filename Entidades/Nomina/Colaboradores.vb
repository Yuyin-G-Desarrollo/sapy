Imports Entidades

Public Class Colaborador
    Private celulas As Celulas
    Private colaboradorId As Int32
    Private ColaboradoridNP As Integer
    Private curp As String
    Private rfc As String
    Private fechaNacimiento As Date
    Private aPaterno As String
    Private aMaterno As String
    Private nombre As String
    Private estadoCivil As String
    Private calle As String
    Private numero As String
    Private colonia As String
    Private ciudadId As Ciudades
    Private ciudadOrigenId As Ciudades
    Private telefonoCasa As String
    Private telefonoCel As String
    Private cp As String
    Private activo As Boolean
    Private email As String
    Private IDpartamento As Departamentos
    Private FechaCreacion As String
    Private Sexo As String
    Private ClaveElector As String
    Private Finiquitos As Finiquitos
    Private MotivoFiniquito As MotivosFiniquito
    Public Salario As ColaboradorReal
    Public Estatus As CajaColaborador
    Private IdAnual As Int32
    Private CurpI As String
    Private CurpF As String
    Private Homoclave As String
    Private CodigoEmpleadoNP As String
    Private NombreCorto As String
    Private NaveID As Integer

    Public Property Pcelulas As Celulas
        Get
            Return celulas
        End Get
        Set(value As Celulas)
            celulas = value
        End Set
    End Property


    Public Property PNaveID As Integer
        Get
            Return NaveID
        End Get
        Set(value As Integer)
            NaveID = value
        End Set
    End Property

    Public Property PNombreCorto As String
        Get
            Return NombreCorto
        End Get
        Set(value As String)
            NombreCorto = value
        End Set
    End Property

    Public Property PCodigoEmpleadoNp As String
        Get
            Return CodigoEmpleadoNP
        End Get
        Set(value As String)
            CodigoEmpleadoNP = value
        End Set
    End Property

    Public Property PHomoclave As String
        Get
            Return Homoclave
        End Get
        Set(value As String)
            Homoclave = value
        End Set
    End Property

    Public Property PCurpI As String
        Get
            Return CurpI
        End Get
        Set(value As String)
            CurpI = value
        End Set
    End Property

    Public Property PCurpF As String
        Get
            Return CurpF
        End Get
        Set(value As String)
            CurpF = value
        End Set
    End Property

    Public Property PColaboradoridNP As Integer
        Get
            Return ColaboradoridNP
        End Get
        Set(value As Integer)
            ColaboradoridNP = value
        End Set
    End Property

    Public Property PEstatus As CajaColaborador
        Get
            Return Estatus
        End Get
        Set(value As CajaColaborador)
            Estatus = value
        End Set
    End Property
    Public Property Psalario As ColaboradorReal
        Get
            Return Salario
        End Get
        Set(value As ColaboradorReal)
            Salario = value
        End Set
    End Property
    Public Property PMotivosFiniquito As MotivosFiniquito
        Get
            Return MotivoFiniquito
        End Get
        Set(ByVal value As MotivosFiniquito)
            MotivoFiniquito = value
        End Set
    End Property

    Public Property PFiniquitos As Finiquitos
        Get
            Return Finiquitos
        End Get
        Set(ByVal value As Finiquitos)
            Finiquitos = value
        End Set
    End Property




    Public Property PClaveElector As String
        Get
            Return ClaveElector
        End Get
        Set(ByVal value As String)
            ClaveElector = value
        End Set
    End Property

    Public Property PSexo As String
        Get
            Return Sexo

        End Get
        Set(ByVal value As String)
            Sexo = value
        End Set
    End Property

    Public Property PFechaCreacion As String
        Get
            Return FechaCreacion
        End Get
        Set(ByVal value As String)
            FechaCreacion = value
        End Set
    End Property

    Public Property PIDepartamento As Departamentos
        Get
            Return IDpartamento
        End Get
        Set(ByVal value As Departamentos)
            IDpartamento = value
        End Set
    End Property


    Public Property PColaboradorid As Int32
        Get
            Return colaboradorId
        End Get
        Set(ByVal value As Int32)
            colaboradorId = value
        End Set
    End Property

    Public Property pCurp As String
        Get
            Return curp
        End Get
        Set(ByVal value As String)
            curp = value
        End Set
    End Property

    Public Property PRfc As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Public Property PFechaNacimiento As Date
        Get
            Return fechaNacimiento
        End Get
        Set(ByVal value As Date)
            fechaNacimiento = value
        End Set
    End Property

    Public Property PApaterno As String
        Get
            Return aPaterno
        End Get
        Set(ByVal value As String)
            aPaterno = value
        End Set
    End Property

    Public Property PAmaterno As String
        Get
            Return aMaterno
        End Get
        Set(ByVal value As String)
            aMaterno = value
        End Set
    End Property

    Public Property PNombre As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Public Property PEstadoCivil As String
        Get
            Return estadoCivil
        End Get
        Set(ByVal value As String)
            estadoCivil = value
        End Set
    End Property

    Public Property PCalle As String
        Get
            Return calle
        End Get
        Set(ByVal value As String)
            calle = value
        End Set
    End Property

    Public Property Pnumero As String
        Get
            Return numero
        End Get
        Set(ByVal value As String)
            numero = value
        End Set
    End Property

    Public Property Pcolonia As String
        Get
            Return colonia
        End Get
        Set(ByVal value As String)
            colonia = value
        End Set
    End Property

    Public Property PCiudad As Ciudades
        Get
            Return ciudadId
        End Get
        Set(ByVal value As Ciudades)
            ciudadId = value
        End Set
    End Property


    Public Property PCiudadOrigen As Ciudades
        Get
            Return ciudadOrigenId
        End Get
        Set(ByVal value As Ciudades)
            ciudadOrigenId = value
        End Set
    End Property


    Public Property PTelefonoCasa As String
        Get
            Return telefonoCasa
        End Get
        Set(ByVal value As String)
            telefonoCasa = value
        End Set
    End Property

    Public Property PTelefonoCel As String
        Get
            Return telefonoCel
        End Get
        Set(ByVal value As String)
            telefonoCel = value
        End Set
    End Property

    Public Property PCP As String
        Get
            Return cp
        End Get
        Set(ByVal value As String)
            cp = value
        End Set
    End Property

    Public Property PActivo As Boolean
        Get
            Return activo
        End Get
        Set(ByVal value As Boolean)
            activo = value
        End Set
    End Property

    Public Property PEmail As String
        Get
            Return email
        End Get
        Set(ByVal value As String)
            email = value
        End Set
    End Property

    Public ReadOnly Property PNombreCompleto As String
        Get
            Return PNombre + " " + PApaterno + " " + PAmaterno
        End Get
    End Property

    Public Property pIdAnual As Int32
        Get
            Return IdAnual
        End Get
        Set(ByVal value As Int32)
            IdAnual = value
        End Set
    End Property

    Private entreCalles As String
    Public Property PEntreCalles() As String
        Get
            Return entreCalles
        End Get
        Set(ByVal value As String)
            entreCalles = value
        End Set
    End Property

    Private referencia As String
    Public Property PReferencia() As String
        Get
            Return referencia
        End Get
        Set(ByVal value As String)
            referencia = value
        End Set
    End Property
End Class
