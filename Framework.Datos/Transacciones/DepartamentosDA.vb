Imports Persistencia
Imports System.Data.SqlClient

Public Class DepartamentosDA

    Public Function listaDepartamentosActivos() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Return objOperaciones.EjecutaConsulta("select * from framework.Grupos where grup_activo='True'")
    End Function
	Public Function ListaDepartamentossegunperfiles(ByVal nombre As String, ByVal idperfil As Integer) As DataTable
		Dim opereciones As New Persistencia.OperacionesProcedimientos
		Dim consulta As String = "SELECT * FROM Framework.grupos AS b JOIN Framework.perfiles as c on (b.grup_grupoid=perf__grupoid)"

		If idperfil > 0 Then
			consulta += " where perf_grupoid=" + idperfil.ToString
		End If

		Return opereciones.EjecutaConsulta(consulta)
	End Function
	Public Function listaDepartamentos(ByVal nombre As String, ByVal Activo As Boolean, ByVal naves As Integer, ByVal Areas As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
        'Dim consulta As String = ("SELECT * FROM Framework.Grupos AS A JOIN Nomina.Areas AS B ON (A.grup_areaid=B.area_areaid) JOIN Framework.Naves as c ON (B.area_naveid=c.nave_naveid)")
        'consulta += " where grup_name like '%" + nombre + "%'"
        'consulta += " AND grup_activo ='" + Activo.ToString + "'"

        'If (naves > 0) Then
        '	consulta += " AND  nave_naveid=" + naves.ToString
        'End If

        ''consulta += " and ='" + naves.ToString + "'"
        'If (Areas > 0) Then
        '	consulta += " and  area_areaid ='" + Areas.ToString + "'"

        'End If
        '      Return operaciones.EjecutaConsulta(consulta)
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = Activo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nave"
        parametro.Value = naves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "area"
        parametro.Value = Areas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        return operaciones.EjecutarConsultaSP("[Framework].[SP_Consultar_Departamentos]", listaParametros)

    End Function
	
    Public Sub guardarDepartamento(ByVal Departamento As Entidades.Departamentos)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "nombre"
		parametro.Value = Departamento.DNombre
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "departamentoid"
        'parametro.Value = Departamento.Ddepartamentoid
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = Departamento.DActivo
		listaParametros.Add(parametro)


		parametro = New SqlParameter
		parametro.ParameterName = "nave"
		parametro.Value = Departamento.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "area"
		parametro.Value = Departamento.DAreas.PAreaid
		listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_Grupos", listaParametros)

    End Sub
    Public Sub editarDepartamento(ByVal departamento As Entidades.Departamentos)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = departamento.DNombre
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = departamento.DActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "nave"
		parametro.Value = departamento.PNave.PNaveId
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "area"
		parametro.Value = departamento.DAreas.PAreaid
		listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "departamentoid"
        parametro.Value = departamento.Ddepartamentoid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Framework.SP_editar_Grupos", listaParametros)

    End Sub
    Public Function buscarDepartamento(ByVal departamentoid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Framework.Grupos AS A JOIN Nomina.Areas AS B ON (A.grup_areaid=B.area_areaid) JOIN Framework.Naves as c ON (B.area_naveid=c.nave_naveid) where grup_grupoid=" + departamentoid.ToString)
    End Function

    ''' <summary>
    ''' Este metodo ejecuta la consulta para saber los departamentos de las naves a las cuales pertenece algun usuario
    ''' </summary>
    ''' <param name="idUsuario">Id del usuario que se quiere consultar</param>
    ''' <returns>Datatable con los registros de los departamentos</returns>
    Public Function listaDepartamentosPorNavesUsuario(ByVal idUsuario As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "SELECT * FROM Framework.Grupos as a " +
            "JOIN Framework.Naves as b on a.grup_naveid=b.nave_naveid " +
            "JOIN Framework.NavesUsuario as c on b.nave_naveid=c.naus_naveid " +
            "WHERE c.naus_usuarioid=" + idUsuario.ToString + " AND a.grup_activo='True' and b.nave_activo='True'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function



    Public Function listaDepartamentosSegunNave(ByVal idNave As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select g.grup_grupoid, UPPER(grup_name) as grup_name, grup_activo, grup_usuariocreoid, grup_usuariomodificoid, grup_fechacreacion, grup_fechamodificacion, grup_naveid, grup_naveid  FROM Framework.Grupos g INNER JOIN Nomina.Areas a ON g.grup_areaid = a.area_areaid WHERE g.grup_activo = 'true' AND g.grup_naveid =" + idNave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function


	Public Function listaDepartamentosSegunArea(ByVal idArea As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select grup_grupoid, UPPER(grup_name) as grup_name " +
            " from Framework.Grupos where grup_activo = 'true' and grup_areaid =" + idArea.ToString + " order by grup_name"
		Return operaciones.EjecutaConsulta(consulta)
	End Function


End Class
