Public Class ColaboradoresReplicar
    Private Colaborador As Colaborador
    Private ColaboradorLaboral As ColaboradorLaboral
    Private ColaboradorNomina As ColaboradorNomina
    Private ColaboradorReal As ColaboradorReal
    Private Ciudades As Ciudades
    Private CiudadesOrigen As Ciudades
    Private Estados As Estados
    Private Puestos As Puestos
    Private Departamentos As Departamentos
    Private Patrones As Patrones

    Public Property PPatrones As Patrones
        Get
            Return Patrones
        End Get
        Set(value As Patrones)
            Patrones = value
        End Set
    End Property

    Public Property PDepartamentos As Departamentos
        Get
            Return Departamentos
        End Get
        Set(value As Departamentos)
            Departamentos = value
        End Set
    End Property

    Public Property PPuestos As Puestos
        Get
            Return Puestos
        End Get
        Set(value As Puestos)
            Puestos = value
        End Set
    End Property

    Public Property PEstados As Estados
        Get
            Return Estados
        End Get
        Set(value As Estados)
            Estados = value
        End Set
    End Property

    Public Property PCiudadesOrigen As Ciudades
        Get
            Return CiudadesOrigen
        End Get
        Set(value As Ciudades)
            CiudadesOrigen = value
        End Set
    End Property

    Public Property PCiudades As Ciudades
        Get
            Return Ciudades
        End Get
        Set(value As Ciudades)
            Ciudades = value
        End Set
    End Property


    Public Property PColaborador As Colaborador
        Get
            Return Colaborador
        End Get
        Set(value As Colaborador)
            Colaborador = value
        End Set
    End Property

    Public Property PColabordorLaboral As ColaboradorLaboral
        Get
            Return ColaboradorLaboral
        End Get
        Set(value As ColaboradorLaboral)
            ColaboradorLaboral = value
        End Set
    End Property

    Public Property PColaboradorNomina As ColaboradorNomina
        Get
            Return ColaboradorNomina
        End Get
        Set(value As ColaboradorNomina)
            ColaboradorNomina = value
        End Set
    End Property

    Public Property PColaboradorReal As ColaboradorReal
        Get
            Return ColaboradorReal
        End Get
        Set(value As ColaboradorReal)
            ColaboradorReal = value
        End Set
    End Property
End Class
