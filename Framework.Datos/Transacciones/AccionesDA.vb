Imports System.Data.SqlClient

Public Class AccionesDA

	Public Function listaAcciones() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * from Framework.AccionesModulo"
		Return operaciones.EjecutaConsulta(consulta)
	End Function


	Public Function ListaAccionessegunmodulo(ByVal moduloid As Integer) As DataTable
		Dim opereciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Framework.Modulos AS b JOIN Framework.AccionesModulo as c on (b.modu_moduloid=acmo_moduloid) where acmo_activo = 'true' "

		If moduloid > 0 Then
			consulta += " and acmo_moduloid=" + moduloid.ToString
		End If

		'consulta += " AND acmo_activo='" + activo.ToString + "'"

		Return opereciones.EjecutaConsulta(consulta)
	End Function
	''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

	Public Function listaAccionesModulos(ByVal nombre As String, ByVal clave As String, ByVal Modulo As Int32, ByVal Tipo As Int32, ByVal Activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Framework.AccionesModulo as a JOIN Framework.Modulos as b on (a.acmo_moduloid=b.modu_moduloid)"
		consulta += " AND acmo_nombre like '%" + nombre + "%'"
		consulta += " AND acmo_clave like '%" + clave + "%'"
		If (Modulo > 0) Then
			consulta += " AND acmo_moduloid=" + Modulo.ToString
		End If

		If (Tipo >= 0) Then
			consulta += " AND acmo_tipo=" + Tipo.ToString
		End If

		consulta += " AND acmo_activo='" + Activo.ToString + "'"

		Return operaciones.EjecutaConsulta(consulta)
	End Function


	' funcion para boton altas'
	Public Sub AltasAcciones(ByVal Accion As Entidades.Acciones)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "Nombre"
		parametro.Value = Accion.PNombre
		listaParametros.Add(parametro)

        parametro = New SqlParameter
		parametro.ParameterName = "Clave"
		parametro.Value = Accion.PClave
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Modulo"
		parametro.Value = Accion.PModulo.PModuloid
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "Activo"
		parametro.Value = Accion.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Tipo"
		parametro.Value = Accion.PTipo
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_Acciones", listaParametros)

	End Sub

	Public Sub editarAcciones(ByVal Accion As Entidades.Acciones)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "Nombre"
		parametro.Value = Accion.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Clave"
		parametro.Value = Accion.PClave
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Modulo"
		parametro.Value = Accion.PModulo.PModuloid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Tipo"
		parametro.Value = Accion.PTipo
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "Activo"
		parametro.Value = Accion.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "idAcciones"
		parametro.Value = Accion.PAccionId
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Framework.SP_editar_Acciones", listaParametros)

	End Sub
	Public Function buscarAccionesModulo(ByVal idaccion As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Framework.AccionesModulo as a JOIN Framework.Modulos as b on (a.acmo_moduloid=b.modu_moduloid) where acmo_accionmoduloid=" + idaccion.ToString)
    End Function

    '    Public Function obtenerIdModuloParaAccion(ByVal nomModuloNieto As String, ByVal nomModuloHijo As String, ByVal nomModuloPadre As String) As DataTable
    '        Dim operaciones As New Persistencia.OperacionesProcedimientos
    '        Return operaciones.EjecutaConsulta("select acmo_moduloid  from Framework.AccionesModulo where acmo_moduloid=(select modu_moduloid  from Framework.Modulos where modu_nombre ='" + nomModuloNieto + "'" +
    '" and modu_superiorid =(select modu_moduloid  from Framework.Modulos where modu_nombre ='" + nomModuloHijo + "'" +
    '" and modu_superiorid =(select modu_moduloid  from Framework.Modulos where modu_nombre ='" + nomModuloPadre + "'  and modu_superiorid is null))) group by acmo_moduloid")
    '    End Function

    Public Function verAccionesPorModulo(ByVal idModelo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select acmo_accionmoduloid ,acmo_moduloid , acmo_componente, acmo_nombre, acmo_icono, acmo_clave,acmo_tipo,acmo_activo  from Framework .AccionesModulo where acmo_moduloid =" + idModelo + ""
        Return operaciones.EjecutaConsulta(cadena)
    End Function


    ' ''__________________________________________________________________________________________________


    Public Sub ModificarAcciones(ByVal Accion As Entidades.Acciones)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Accion.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clave"
        parametro.Value = Accion.PClave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Modulo"
        parametro.Value = Accion.PModulo.PModuloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tipo"
        parametro.Value = Accion.PTipo
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "Activo"
        parametro.Value = Accion.PActivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idAcciones"
        parametro.Value = Accion.PAccionId
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_Modificar_Acciones_Modulo", listaParametros)

    End Sub

    Public Function BuscarAcciones(ByVal claveAccion As String, ByVal claveModulo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.AccionesModulo as a join Framework.Modulos as b on a.acmo_moduloid=b.modu_moduloid where UPPER(a.acmo_clave)='" + claveAccion + "' and UPPER(b.modu_clave)='" + claveModulo + "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
   
End Class



