Imports Framework.Datos
Imports Framework.Negocios
Imports Persistencia
Imports Entidades

Module Module1

	'Dim ObjPool As New Pool

	Sub Main()
		'Realizar desde aqui las pruebas a métodos programados en otras capas
		'Console.WriteLine("Inicia prueba - Conexion pool")

		'ObjPool.SQLConn.Open()
		'Console.WriteLine("Conexion pool - Abre conexion")

		'ObjPool.SQLConn.Close()
		'Console.WriteLine("Conexion pool - Cierra conexion")
		Dim ObjString As New UtileriaCadenas
		Dim Parametro As String
		Dim Resultado As String
		Parametro = "password"
		Resultado = ObjString.StringToMd5(Parametro)
		Console.WriteLine(Resultado)

		'Inicializa valor en la sesion
		Try
			'Dim ObjUsuarioBU As New UsuariosBU
			'Dim ObjUsuarios As New Usuarios
			'ObjUsuarios.PUserUsuarioid = 1
			'ObjUsuarios.PUserUsername = "jguerrero"
			'ObjUsuarioBU.login(ObjUsuarios)
			'SesionUsuario.UsuarioSesion = ObjUsuarios

			''Dim obj As New OperacionesProcedimientos
			''obj.EjecutaConsulta("Insert into usuarios (1,1,2,3)")

			'Dim ObjPermisosUsuarioBU As New PermisosUsuarioBU

			'Console.WriteLine(PermisosUsuarioBU.ConsultarPermiso("FWK", "OTRAACCION"))


		Catch Ex As Exception
			Console.WriteLine(HistorialBU.GuardaError(Errores.MensajeInterno(Ex)).ToString)
		End Try
	End Sub

End Module
