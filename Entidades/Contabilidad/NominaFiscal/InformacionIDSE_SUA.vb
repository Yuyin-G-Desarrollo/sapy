Public Class InformacionIDSE_SUA
#Region "IDSE"
    Private tablaId As Integer
    Public Property IITablaId() As Integer
        Get
            Return tablaId
        End Get
        Set(ByVal value As Integer)
            tablaId = value
        End Set
    End Property

    Private registroPatronal As String
    Public Property IIRegistroPatronal() As String
        Get
            Return registroPatronal
        End Get
        Set(ByVal value As String)
            registroPatronal = value
        End Set
    End Property

    Private numeroSeguroSocial As String
    Public Property IINumeroSeguroSocial() As String
        Get
            Return numeroSeguroSocial
        End Get
        Set(ByVal value As String)
            numeroSeguroSocial = value
        End Set
    End Property

    Private aPaterno As String
    Public Property IIAPaterno() As String
        Get
            Return aPaterno
        End Get
        Set(ByVal value As String)
            aPaterno = value
        End Set
    End Property

    Private aMaterno As String
    Public Property IIAMaterno() As String
        Get
            Return aMaterno
        End Get
        Set(ByVal value As String)
            aMaterno = value
        End Set
    End Property

    Private nombre As String
    Public Property IINombre() As String
        Get
            Return nombre
        End Get
        Set(ByVal value As String)
            nombre = value
        End Set
    End Property

    Private salarioDiario As String
    Public Property IISalarioDiario() As String
        Get
            Return salarioDiario
        End Get
        Set(ByVal value As String)
            salarioDiario = value
        End Set
    End Property

    Private claveTipoSalario As String
    Public Property IIClaveTipoSalario() As String
        Get
            Return claveTipoSalario
        End Get
        Set(ByVal value As String)
            claveTipoSalario = value
        End Set
    End Property

    Private claveTipoJornada As String
    Public Property IIClaveTipoJornada() As String
        Get
            Return claveTipoJornada
        End Get
        Set(ByVal value As String)
            claveTipoJornada = value
        End Set
    End Property

    Private fechaMovimiento As String
    Public Property IIFechaMovimiento() As String
        Get
            Return fechaMovimiento
        End Get
        Set(ByVal value As String)
            fechaMovimiento = value
        End Set
    End Property

    Private claveTipoMovimiento As String
    Public Property IIClaveMovimiento() As String
        Get
            Return claveTipoMovimiento
        End Get
        Set(ByVal value As String)
            claveTipoMovimiento = value
        End Set
    End Property

    Private claveTrabajador As String
    Public Property IIClaveTrabajador() As String
        Get
            Return claveTrabajador
        End Get
        Set(ByVal value As String)
            claveTrabajador = value
        End Set
    End Property

    Private curp As String
    Public Property IICurp() As String
        Get
            Return curp
        End Get
        Set(ByVal value As String)
            curp = value
        End Set
    End Property

    Private identificador As String
    Public Property IIIdentificador() As String
        Get
            Return identificador
        End Get
        Set(ByVal value As String)
            identificador = value
        End Set
    End Property

    Private rutaDescarga As String
    Public Property IIRutaDescarga() As String
        Get
            Return rutaDescarga
        End Get
        Set(ByVal value As String)
            rutaDescarga = value
        End Set
    End Property

    Private unidadMedicaFamiliar As String
    Public Property IIUnidadMedicaFamiliar() As String
        Get
            Return unidadMedicaFamiliar
        End Get
        Set(ByVal value As String)
            unidadMedicaFamiliar = value
        End Set
    End Property

    Private claveTipoColaborador As String
    Public Property IIClaveTipoColaborador() As String
        Get
            Return claveTipoColaborador
        End Get
        Set(ByVal value As String)
            claveTipoColaborador = value
        End Set
    End Property

    Private existe As Boolean
    Public Property IIExiste() As Boolean
        Get
            Return existe
        End Get
        Set(ByVal value As Boolean)
            existe = value
        End Set
    End Property

#End Region


#Region "SUA"
    Private folioIncapacidad As String
    Public Property IIFolioIncapacidad() As String
        Get
            Return folioIncapacidad
        End Get
        Set(ByVal value As String)
            folioIncapacidad = value
        End Set
    End Property

    Private diasIncidencia As String
    Public Property IIDiasIncidencia() As String
        Get
            Return diasIncidencia
        End Get
        Set(ByVal value As String)
            diasIncidencia = value
        End Set
    End Property

   
#End Region


#Region "SUA EMPLEADO"
    Private rfc As String
    Public Property IIRFC() As String
        Get
            Return rfc
        End Get
        Set(ByVal value As String)
            rfc = value
        End Set
    End Property

    Private nombreCompleto As String
    Public Property IINombreCompleto() As String
        Get
            Return nombreCompleto
        End Get
        Set(ByVal value As String)
            nombreCompleto = value
        End Set
    End Property

    Private puesto As String
    Public Property IIPuesto() As String
        Get
            Return puesto
        End Get
        Set(ByVal value As String)
            puesto = value
        End Set
    End Property

#End Region

#Region "DATOS AFILATORIOS"
    Private cp As String
    Public Property ICodigoPostal() As String
        Get
            Return cp
        End Get
        Set(ByVal value As String)
            cp = value
        End Set
    End Property

    Private lugarNacimiento As String
    Public Property ILugarNacimiento() As String
        Get
            Return lugarNacimiento
        End Get
        Set(ByVal value As String)
            lugarNacimiento = value
        End Set
    End Property

    Private claveLugarNac As String
    Public Property IClaveLugarNacimiento() As String
        Get
            Return claveLugarNac
        End Get
        Set(ByVal value As String)
            claveLugarNac = value
        End Set
    End Property

    Private sexo As String
    Public Property ISexo() As String
        Get
            Return sexo
        End Get
        Set(ByVal value As String)
            sexo = value
        End Set
    End Property

    Private tipoSalario As Int32
    Public Property ITipoSalario() As Int32
        Get
            Return tipoSalario
        End Get
        Set(ByVal value As Int32)
            tipoSalario = value
        End Set
    End Property

    Private hora As String
    Public Property IHora() As String   
        Get
            Return hora
        End Get
        Set(ByVal value As String)
            hora = value
        End Set
    End Property

    Private fechaNacimiento As String
    Public Property IFechaNacimiento() As String
        Get
            Return fechaNacimiento
        End Get
        Set(ByVal value As String)
            fechaNacimiento = value
        End Set
    End Property

    Private ocupacion As String
    Public Property IOcupacion() As String
        Get
            Return ocupacion
        End Get
        Set(ByVal value As String)
            ocupacion = value
        End Set
    End Property

#End Region

End Class
