Imports System.Data.SqlClient

Public Class CelulasDA
	Public Function listaCelulasActivas() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ""
        'consulta = "SELECT c.*, p.pues_nombre from Nomina.Celulas c inner join Framework.Grupos g on c.celu_grupoid=g.grup_grupoid "
        'consulta += " INNER JOIN Nomina.Puestos p ON p.pues_departamentoid=g.grup_grupoid where c.celu_activo='True' ORDER BY c.celu_orden, p.pues_orden"
        'Return objOperaciones.EjecutaConsulta(consulta)
        'Return objOperaciones.EjecutaConsulta("SELECT * from Nomina.Celulas where celu_activo='True' union ALL select 0,	'INCAPACIDAD',	0,	1, 	0,	0,	'01/01/2018',	'01/01/2018',	0,	10000 order by celu_orden")

        Return objOperaciones.EjecutaConsulta("EXEC Nomina.SP_consulta_CelulasActivas")
    End Function

	Public Function listaCelulas(ByVal nombre As String, ByVal nave As Int32, ByVal departamento As Int32, ByVal activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Nomina.celulas as a" +
		 " JOIN Framework.Grupos as b on (a.celu_grupoid=b.grup_grupoid)" +
		 " JOIN Framework.Naves as c ON (b.grup_naveid=c.nave_naveid)"
		' JOIN Framework.NavesUsuario as d  on (c.nave_naveid=d.naus_naveid)"
		consulta += " WHERE celu_nombre like '%" + nombre + "%'"
		If (nave > 0) Then
			consulta += " AND grup_naveid=" + nave.ToString
		End If
		If (departamento > 0) Then
			consulta += " AND celu_grupoid=" + departamento.ToString
		End If
		consulta += " AND celu_activo='" + activo.ToString + "'"

		Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function CelulaSegunDepartamento(ByVal IdDepartamento As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += "select * from Nomina.Celulas "
        consulta += " where celu_grupoid = " + IdDepartamento.ToString
        consulta += " and celu_activo=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

	Public Sub AltasCelulas(ByVal celula As Entidades.Celulas)

		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaValores As New List(Of SqlParameter)


		Dim valores As New SqlParameter
		valores.ParameterName = "nombre"
		valores.Value = celula.PNombre
		listaValores.Add(valores)

		'valores = New SqlParameter
		'valores.ParameterName = "nave"
		'valores.Value = celula.Pnave
		'listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "departamento"
		valores.Value = celula.PDepartamento.Ddepartamentoid
		listaValores.Add(valores)


		valores = New SqlParameter
		valores.ParameterName = "activo"
		valores.Value = celula.PActivo
		listaValores.Add(valores)

		valores = New SqlParameter
		valores.ParameterName = "usuariocreo"
		valores.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaValores.Add(valores)

        valores = New SqlParameter
        valores.ParameterName = "orden"
        valores.Value = celula.POrden
        listaValores.Add(valores)

		operaciones.EjecutarSentenciaSP("Nomina.SP_altas_Celulas", listaValores)

	End Sub
	Public Sub editarCelulas(ByVal celula As Entidades.Celulas)


		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)


		Dim parametro As New SqlParameter
		parametro.ParameterName = "celulaID"
		parametro.Value = celula.PCelulaid
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = celula.PNombre
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "departamentoID"
		parametro.Value = celula.PDepartamento.Ddepartamentoid
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = celula.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariomodifico"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "orden"
        parametro.Value = celula.POrden
        listaParametros.Add(parametro)


		operaciones.EjecutarSentenciaSP("Nomina.SP_editar_Celulas", listaParametros)

	End Sub

	Public Function buscarCelula(ByVal celulaid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Nomina.celulas as a" +
		 " JOIN Framework.Grupos as b on (a.celu_grupoid=b.grup_grupoid)" +
		 " JOIN Framework.Naves as c ON (b.grup_naveid=c.nave_naveid) where celu_celulaid=" + celulaid.ToString)
		'JOIN Framework.NavesUsuario as d  on (c.nave_naveid=d.naus_naveid)")

	End Function

End Class
