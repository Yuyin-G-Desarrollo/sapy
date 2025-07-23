Imports System.Data.SqlClient

Public Class PatronesDA

	Public Function listaPatrones(ByVal nombre As String, ByVal rfc As String, ByVal Npatronal As String, ByVal activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Nomina.Patrones as a  JOIN Framework.Ciudades as b on (a.patr_ciudadid=b.city_ciudadid)"
		consulta += " AND patr_nombre like '%" + nombre + "%'"
		consulta += " AND patr_rfc like '%" + rfc + "%'"
		consulta += " AND patr_nopatronal like '%" + Npatronal + "%'"
		'consulta += " AND patr_domiciliocalle like '%" + calle + "%'"
		'consulta += " AND patr_domicilionumero like '%" + Dnumero + "%'"
		'consulta += " AND patr_domicilioColonia like '%" + colonia + "%'"
		'If (ciudadId > 0) Then
		'consulta += " AND patr_ciudadid='" + ciudadId.ToString + "'"
		'End If
		'consulta += " AND patr_cp like '%" + cp + "%'"
		consulta += " AND patr_activo='" + activo.ToString + "'"

		Return operaciones.EjecutaConsulta(consulta)
	End Function

	' Metodo altas patrones'

	Public Sub guardarPatrones(ByVal patron As Entidades.Patrones)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)


		'Dim parametro As New SqlParameter
		'parametro.ParameterName = " patronid"
		'parametro.Value = patron.Ppatronid
		'listaParametros.Add(parametro)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = patron.Pnombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "rfc"
		parametro.Value = patron.Prfc
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Npatronal"
		parametro.Value = patron.PNpatronal
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "calle"
		parametro.Value = patron.Pcalle
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Dnumero"
		parametro.Value = patron.PDnumero
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Colonia"
		parametro.Value = patron.Pcolonia
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "ciudadid"
		parametro.Value = patron.PciudadId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "cp"
		parametro.Value = patron.Pcp
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = patron.Pactivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "comisiones"
        parametro.Value = patron.Pcomisiones
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_altas_patrones", listaParametros)

	End Sub

	Public Sub editarPatron(ByVal patron As Entidades.Patrones)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "PatronId"
		parametro.Value = patron.Ppatronid
		listaParametros.Add(parametro)



		parametro = New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = patron.Pnombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "rfc"
		parametro.Value = patron.Prfc
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Npatronal"
		parametro.Value = patron.PNpatronal
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "calle"
		parametro.Value = patron.Pcalle
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Dnumero"
		parametro.Value = patron.PDnumero
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "Colonia"
		parametro.Value = patron.Pcolonia
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "ciudadId"
		parametro.Value = patron.PciudadId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "cp"
		parametro.Value = patron.Pcp
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = patron.Pactivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "comisiones"
        parametro.Value = patron.Pcomisiones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porcentajecomision"
        parametro.Value = patron.PporcentajeComision
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_editar_patrones", listaParametros)

	End Sub

	Public Function buscarPatron(ByVal patronid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("select * from Nomina.patrones where patr_patronid=" + patronid.ToString)

	End Function



End Class


