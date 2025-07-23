Imports Persistencia
Imports System.Data.SqlClient

Public Class NavesDA
	Public Function listaNaves() As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.Naves where nave_activo='True' order by nave_nombre"
		Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaNavesSegunUsuario(ByVal nombre As String, ByVal IDUsuario As Integer) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT nave_naveid, UPPER(nave_nombre) as nave_nombre, upper(nave_navesicyid) as nave_navesicyid FROM Framework.Naves AS b JOIN Framework.NavesUsuario as c on (b.nave_naveid=naus_naveid)"

        If IDUsuario > 0 Then
            consulta += " where naus_usuarioid=" + IDUsuario.ToString
        End If
        consulta += " ORDER BY nave_nombre"
        Return opereciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaNavesSegunUsuario_Especial(ByVal Usuario As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = Usuario
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Produccion].[SP_ConsultaNaveUsuarioProyeccionMateriales_especial]", listaParametros)
    End Function

    Public Function ListaNavesSegunUsuario_ConIdSicy(ByVal nombre As String, ByVal IDUsuario As Integer) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT nave_naveid, UPPER(nave_nombre) as nave_nombre, upper(ltrim(rtrim(nave_navesicyid))) as nave_navesicyid FROM Framework.Naves AS b JOIN Framework.NavesUsuario as c on (b.nave_naveid=naus_naveid)"

        If IDUsuario > 0 Then
            consulta += " where naus_usuarioid= " + IDUsuario.ToString
        End If
        consulta += " ORDER BY nave_nombre"
        Return opereciones.EjecutaConsulta(consulta)
    End Function

	Public Function listaDeNaves(ByVal nombre As String, activo As Boolean) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = (" Select * from framework.naves ")
		consulta += " where nave_nombre Like '%" + nombre + "%'"
		consulta += " and nave_activo ='" + activo.ToString + "'"
		Return operaciones.EjecutaConsulta(consulta)


	End Function
	
	Public Sub guardarNaves(ByVal nave As Entidades.Naves)
		Dim operaciones As New OperacionesProcedimientos
		Dim listaParametros As New List(Of SqlParameter)

		Dim parametro As New SqlParameter
		parametro.ParameterName = "nombre"
		parametro.Value = nave.PNombre
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "activo"
		parametro.Value = nave.PActivo
		listaParametros.Add(parametro)

		parametro = New SqlParameter
		parametro.ParameterName = "usuariocreo"
		parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listaParametros.Add(parametro)

		operaciones.EjecutarSentenciaSP("Framework.SP_altas_Naves", listaParametros)

	End Sub

	
	Public Sub editarNaves(ByVal nave As Entidades.Naves)
		'a = valor de parametro
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Dim listavalores As New List(Of SqlParameter)


		Dim a As New SqlParameter
		a.ParameterName = "navesid"
		a.Value = nave.PNaveId
		listavalores.Add(a)

		a = New SqlParameter
		a.ParameterName = "nombre"
		a.Value = nave.PNombre
		listavalores.Add(a)

		a = New SqlParameter
		a.ParameterName = "activo"
		a.Value = nave.PActivo
		listavalores.Add(a)

		a = New SqlParameter
		a.ParameterName = "usuariomodifico"
		a.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
		listavalores.Add(a)

		

		operaciones.EjecutarSentenciaSP("Framework.SP_Editar_Naves", listavalores)

	End Sub
	Public Function buscarNaves(ByVal navesid As Int32) As DataTable
		Dim operaciones As New Persistencia.OperacionesProcedimientos
		Return operaciones.EjecutaConsulta("SELECT * FROM Framework.naves where nave_naveid=" + navesid.ToString)
    End Function


    ''' <summary>
    ''' DEVUELVE UNA LISTA DE NAVES ACTIVAS QUE SEAN DIFERENTES A COMERCIALIZADORA. METODO DESARROLLADO PARA PROYECTO DE PROGRAMACION
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function listaDeNavesTabla() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ("select nave_naveid id_,nave_nombre from framework.naves where nave_activo=1 and nave_nombre<>'Comercializadora' order BY 2 ")

        Return operaciones.EjecutaConsulta(consulta)


    End Function
    Public Function listaDeNavesTablaActivas() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ("select nave_naveid id_,nave_nombre from Programacion.NavesAux where nave_activo=1 order by nave_orden asc")

        Return operaciones.EjecutaConsulta(consulta)


    End Function


    Public Function ListaNavesConAlmacenSegunUsuario(ByVal IDUsuario As Integer) As DataTable


        Dim consulta As String = " "

        Dim OperacionesSicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSay As New Persistencia.OperacionesProcedimientos


        If operacionesSay.Servidor = OperacionesSicy.Servidor Then
            consulta = " SELECT DISTINCT bahi_nave, UPPER(nave_nombre) AS nave_nombre, nave_navesicyid " +
                        " FROM Almacen.Bahia JOIN [" + operacionesSay.NombreDB + "].[Framework].[Naves] ON bahi_nave = nave_naveid " +
                        " JOIN [" + operacionesSay.NombreDB + "].[Framework].[NavesUsuario] ON nave_naveid = naus_naveid "
        Else
            consulta = " SELECT DISTINCT bahi_nave, UPPER(nave_nombre) AS nave_nombre, nave_navesicyid " +
                       " FROM Almacen.Bahia JOIN [" + operacionesSay.Servidor + "].[" + operacionesSay.NombreDB + "].[Framework].[Naves] ON bahi_nave = nave_naveid " +
                       " JOIN [" + operacionesSay.Servidor + "].[" + operacionesSay.NombreDB + "].[Framework].[NavesUsuario] ON nave_naveid = naus_naveid "
        End If


        If IDUsuario > 0 Then
            consulta += " WHERE naus_usuarioid =" + IDUsuario.ToString
        End If
        consulta += " ORDER BY nave_nombre"
        Return OperacionesSicy.EjecutaConsulta(consulta)
    End Function

    Public Function ListaAlmacenSegunNave(ByVal naveID As Integer) As DataTable
        Dim opereciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " SELECT DISTINCT bahi_almacen FROM Almacen.Bahia WHERE bahi_nave = " + naveID.ToString + " ORDER BY bahi_almacen "

        Return opereciones.EjecutaConsulta(consulta)
    End Function


    Public Function ObtenerLogotipoNave(ByVal naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select nave_logotipourl from Framework.Naves where nave_naveid = " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerLogotipoSICYNave(ByVal naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select nave_logotipourl from Framework.Naves where nave_navesicyid = " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function TablaNavesAux() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("[Programacion].[SP_Consulta_NavesAuxiliaresProgramacion]")
    End Function
    Public Function TablaNavesAuxOrdena() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Return operaciones.EjecutaConsulta("[Programacion].[SP_Ordena_NavesAuxiliaresProgramacion]")
    End Function
    Public Function actualizarDiaNaveAuxiliar(ByVal columna As String, ByVal valor As Double, ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@dia"
        ParametroParaLista.Value = columna
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@valor"
        ParametroParaLista.Value = valor
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@naveId"
        ParametroParaLista.Value = id
        ListaParametros.Add(ParametroParaLista)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ActualizaDiaNaveAuxiliar]", ListaParametros)
    End Function
    Public Function Actualizar(ByVal id As Integer, ByVal lugar As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@naveId"
        ParametroParaLista.Value = id
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@ordenNave"
        ParametroParaLista.Value = lugar
        ListaParametros.Add(ParametroParaLista)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_OrdenaNavesProgramacion]", ListaParametros)
    End Function
    Public Function obtenerNavesComboAuxiliar() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Return operacion.EjecutaConsulta("[Programacion].[SP_Consulta_NavesAuxiliaresProduccion]")
    End Function
    Public Function ActualizarNaveSicy(ByVal id As Integer, ByVal ID_SICY As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@naveId"
        ParametroParaLista.Value = id
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@naveIdSyci"
        ParametroParaLista.Value = ID_SICY
        ListaParametros.Add(ParametroParaLista)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ActualizaNaveSici_NaveAuxiliar]", ListaParametros)
    End Function
    Public Function ActualizarNaveProduccion(ByVal id As Integer, ByVal activo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@naveId"
        ParametroParaLista.Value = id
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)

        Return operaciones.EjecutarConsultaSP("[Programacion].[SP_ActualizaNaveAuxiliarProgramacion]", ListaParametros)
    End Function
    Public Function TablaNavesAuxAsignar() As DataTable

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim SQL As String = ""
        SQL += " SELECT nave_naveID ID_,nave_nombre Nombre,0 as Orden,cast(0 as bit) Asignar"
        SQL += " FROM Programacion.NavesAux"
        SQL += " wHERE nave_activo=1"
        SQL += " ORDER by nave_orden  "
        Return operaciones.EjecutaConsulta(SQL)


    End Function

    Public Function ListaNavesSegunUsuarioMaquilas(ByVal IDUsuario As Integer, ByVal pPermisoMaquilas As Boolean) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = IDUsuario
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PermisoMaquilas"
        parametro.Value = pPermisoMaquilas
        listaparametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Produccion].[SP_ConsultaListaNavesUsuarioMaquilas]", listaparametros)
    End Function


End Class
