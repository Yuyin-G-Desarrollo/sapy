Imports System.Data.SqlClient

Public Class PuestosDA
	Public Function ListaPuestos(ByVal nombre As String, ByVal naveid As Int32, ByVal departamento As Int32, ByVal activo As Boolean, ByVal Area As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "  select * from Nomina.puestos as a join Framework.Grupos as c ON (a.pues_departamentoid=c.grup_grupoid)  JOIN Nomina.Areas as f ON (c.grup_areaid = f.area_areaid) join Framework.Naves as b on (c.grup_naveid=b.nave_naveid)"
		consulta += " AND pues_nombre like '%" + nombre + "%'"
		If (naveid > 0) Then
			consulta += " AND c.grup_naveid=" + naveid.ToString
		End If
		If (departamento > 0) Then
			consulta += " AND grup_grupoid =" + departamento.ToString
		End If
		If (Area > 0) Then
			consulta += " AND area_areaid =" + Area.ToString
		End If

        consulta += " AND pues_activo='" + activo.ToString + "'"
        consulta += " and c.grup_activo='true' ORDER BY a.pues_orden"
		Return operaciones.EjecutaConsulta(consulta)

	End Function

    Public Function ListaPuestos() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = " select * from Nomina.puestos  as a join Framework.Naves as b on (a.pues_nave=b.nave_naveid) join Framework.Grupos as c ON (c.grup_naveid=b.nave_naveid) "
        Return operaciones.EjecutaConsulta(consulta)

    End Function




    Public Function ListaPuestoSegunDepartamento(ByVal idDepartamento As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select pues_puestoid, UPPER(pues_nombre) as pues_nombre from Nomina.Puestos where pues_activo='True' and pues_departamentoid= " + idDepartamento.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function



	' funcion para boton altas'
	Public Sub guardarPuestos(ByVal puesto As Entidades.Puestos)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = puesto.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Nave"
		parametro.Value = puesto.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Departamento"
		parametro.Value = puesto.PDepartamento.Ddepartamentoid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = puesto.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "orden"
        parametro.Value = puesto.POrden
        listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_puestos", listaParametros)

	End Sub

	Public Sub editarPuestos(ByVal puesto As Entidades.Puestos)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = puesto.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "naveId"
		parametro.Value = puesto.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Departamento"
		parametro.Value = puesto.PDepartamento.Ddepartamentoid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = puesto.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "puestoid"
		parametro.Value = puesto.Ppuestosid
		listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "orden"
        parametro.Value = puesto.POrden
        listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_puestos", listaParametros)

	End Sub

	Public Function buscarPuesto(ByVal puestosid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta(" select * from Nomina.puestos as a join Framework.Grupos as c ON (a.pues_departamentoid=c.grup_grupoid)join Framework.Naves as b on (c.grup_naveid=b.nave_naveid) where pues_puestoid=" + puestosid.ToString)
	End Function



End Class

