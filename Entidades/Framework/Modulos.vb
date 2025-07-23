Imports System.Drawing

Public Class Modulos
	Private Moduloid As Int32
	Private Nombre As String
	Private Superiorid As Modulos
	Private Menu As Boolean
	Private GuardarHistorial As Boolean
	Private Icono As String
	Private ArchivoReporte As String
	Private UsuarioCreoId As Int32
	Private UsuarioModificoId As Int32
	Private FechaCreacion As DateTime
	Private FechaModificacion As DateTime
	Private Componente As String
	Private Activo As Boolean
    Private Clave As String
    Private ComponenteWeb As String
    Private ImagenWeb As String
    Private ModuloWeb As Boolean
    Private ModuloEscritorio As Boolean

	Public Property PModuloid As Int32
		Get
			Return Moduloid

		End Get
		Set(value As Int32)
			Moduloid = value
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
	Public Property PSuperiorid As Modulos
		Get
			Return Superiorid
		End Get
		Set(value As Modulos)
			Superiorid = value
		End Set
	End Property
	Public Property PMenu As Boolean
		Get
			Return Menu
		End Get
		Set(value As Boolean)
			Menu = value
		End Set
	End Property
	Public Property PGuardarHistorial As Boolean
		Get
			Return GuardarHistorial
		End Get
		Set(value As Boolean)
			GuardarHistorial = value
		End Set
	End Property
	Public Property PIcono As String
		Get
			Return Icono
		End Get
		Set(value As String)
			Icono = value
		End Set
	End Property
	Public Property PArchivoReporte As String
		Get
			Return ArchivoReporte
		End Get
		Set(value As String)
			ArchivoReporte = value
		End Set
	End Property
	Public Property PUsuarioCreoId As Int32
		Get
			Return UsuarioCreoId
		End Get
		Set(value As Int32)
			UsuarioCreoId = value
		End Set
	End Property
	Public Property PUsuarioModificoId As Int32
		Get
			Return UsuarioModificoId
		End Get
		Set(value As Int32)
			UsuarioModificoId = value
		End Set
	End Property
	Public Property PFechaCreacion As DateTime
		Get
			Return FechaCreacion
		End Get
		Set(value As DateTime)
			FechaCreacion = value
		End Set
	End Property
	Public Property PFechaModificacion As DateTime
		Get
			Return FechaModificacion
		End Get
		Set(value As DateTime)
			FechaModificacion = value
		End Set
	End Property
	Public Property PComponente As String
		Get
			Return Componente
		End Get
		Set(value As String)
			Componente = value
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
	Public Property PClave As String
		Get
			Return Clave
		End Get
		Set(value As String)
			Clave = value
		End Set
    End Property

    Public Property PComponenteWeb As String
        Get
            Return ComponenteWeb
        End Get
        Set(value As String)
            ComponenteWeb = value
        End Set
    End Property

    Public Property PImagenWeb As String
        Get
            Return ImagenWeb
        End Get
        Set(value As String)
            ImagenWeb = value
        End Set
    End Property

    Public Property PModuloWeb As Boolean
        Get
            Return ModuloWeb
        End Get
        Set(value As Boolean)
            ModuloWeb = value
        End Set
    End Property

    Public Property PModuloEscritorio As Boolean
        Get
            Return ModuloEscritorio
        End Get
        Set(value As Boolean)
            ModuloEscritorio = value
        End Set
    End Property

End Class
