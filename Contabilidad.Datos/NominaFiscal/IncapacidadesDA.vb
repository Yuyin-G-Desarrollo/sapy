Imports System.Data.SqlClient

Public Class IncapacidadesDA
    Public Function ValidarIncapacidad(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal incapacidadId As Integer) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM Nomina.Incapacidades"
        consulta += " WHERE inc_colaboradorid=" + ColaboradorID.ToString
        consulta += " AND (((inc_fechainicio BETWEEN '" + FechaInicio.ToShortDateString + "' AND '" + FechaFin.ToShortDateString + "')"
        consulta += " OR (inc_fechafin BETWEEN '" + FechaInicio.ToShortDateString + "' AND '" + FechaFin.ToShortDateString + "'))"
        consulta += " OR (('" + FechaInicio.ToShortDateString + "' between inc_fechainicio and inc_fechafin)"
        consulta += " OR ('" + FechaFin.ToShortDateString + "' between inc_fechainicio and inc_fechafin)))"
        consulta += " AND inc_incapacidadid <> " + incapacidadId.ToString
        consulta += " ORDER BY inc_fechafin DESC"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ValidarIncapacidadEditar(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime, ByVal IncapacidadID As Integer) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM Nomina.Incapacidades"
        consulta += " WHERE inc_colaboradorid=" + ColaboradorID.ToString
        consulta += " AND (((inc_fechainicio BETWEEN '" + FechaInicio.ToShortDateString + "' AND '" + FechaFin.ToShortDateString + "')"
        consulta += " OR (inc_fechafin BETWEEN '" + FechaInicio.ToShortDateString + "' AND '" + FechaFin.ToShortDateString + "'))"
        consulta += " OR ('" + FechaInicio.ToShortDateString + "' BETWEEN inc_fechainicio AND inc_fechafin OR '" + FechaFin.ToShortDateString + "' BETWEEN inc_fechainicio AND inc_fechafin))"
        consulta += " AND inc_incapacidadid<>" + IncapacidadID.ToString
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function RamoDelSeguro() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM nomina.IncapacidadRamoSeguro"
        consulta += " WHERE ramo_activo=1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function TipoRiesgo() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM nomina.IncapacidadTipoRiesgo"
        consulta += " WHERE trin_activo=1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ControlIncapacidad(ByVal idTipoIncapacidad As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "tipoincapacidadid"
        parametro.Value = idTipoIncapacidad
        listaParametros.Add(parametro)

        Return objOperaciones.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ControIncapacidad", listaParametros)
    End Function

    Public Function SecuelaOconsecuencia() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from  nomina.IncapacidadSecuelas"
        consulta += " where inse_activo=1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function TipoMaternidad() As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " select * from nomina.IncapacidadTipoMaternidad"
        consulta += " where inma_activo=1"
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    'ALTA INCAPACIDAD
    Public Function AltaIncapacidad(ByVal ListaAltaIncapacidad As Entidades.Incapacidades) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "inc_folio"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadFolio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_colaboradorid"
        parametro.Value = ListaAltaIncapacidad.PColaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_fechainicio"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadFechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_fechafin"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadFechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_diasautorizados"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadDiasAutorizados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_ramoseguroid"
        parametro.Value = ListaAltaIncapacidad.PRamoSeguroID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_tiporiesgoid"
        parametro.Value = ListaAltaIncapacidad.PTipoRiesgoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_controlincapacidadid"
        parametro.Value = ListaAltaIncapacidad.PControlIncapacidadID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_secuelaid"
        parametro.Value = ListaAltaIncapacidad.PSecuelaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_descripcion"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadDescripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_usuariocreoid"
        parametro.Value = ListaAltaIncapacidad.PUsuarioCreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "aceptadorRiesgoTrabajo"
        parametro.Value = ListaAltaIncapacidad.PAceptadoRT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidadAnteriorid"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadAnteirorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "altaIncapacidad"
        parametro.Value = ListaAltaIncapacidad.PCartaIncapacidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "formatost7"
        parametro.Value = ListaAltaIncapacidad.PFormatost7
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "formatost2"
        parametro.Value = ListaAltaIncapacidad.PFormatoSt2
        listaParametros.Add(parametro)


        Return operaciones.EjecutarConsultaSP("Nomina.SP_Alta_Incapacidades", listaParametros)
    End Function

    Public Function ListaIncapacidades(ByVal ColaboradorID As Integer) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM Nomina.Incapacidades"
        consulta += " WHERE inc_colaboradorid = " + ColaboradorID.ToString
        consulta += " AND inc_replicadonominpaq='False'"
        consulta += " order by inc_fechainicio asc"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaIncapacidadesReplicadas(ByVal ColaboradorID As Integer) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT * FROM Nomina.Incapacidades"
        consulta += " WHERE inc_colaboradorid = " + ColaboradorID.ToString
        consulta += " AND inc_replicadonominpaq='True'"
        consulta += " order by inc_fechainicio asc"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaDetalleIncapacidades(ByVal ColaboradorID As Integer, ByVal FechaInicio As DateTime, ByVal FechaFin As DateTime) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = " SELECT *,isnull(inc_incapacidadanteriorid,0) as idAnterior,isnull(inc_aceptadoriesgotrabajo,0)aceptadort,isnull(inc_estatusid,0) as idEstatus FROM Nomina.Incapacidades"
        consulta += " WHERE inc_fechainicio='" + FechaInicio.ToShortDateString + "'"
        consulta += " AND inc_fechafin='" + FechaFin.ToShortDateString + "'"
        consulta += " AND inc_colaboradorid=" + ColaboradorID.ToString
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    'ALTA INCAPACIDAD
    Public Sub EditarIncapacidades(ByVal ListaAltaIncapacidad As Entidades.Incapacidades)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "inc_inc_incapacidadid"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_folio"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadFolio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_fechainicio"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadFechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_fechafin"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadFechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_diasautorizados"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadDiasAutorizados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_ramoseguroid"
        parametro.Value = ListaAltaIncapacidad.PRamoSeguroID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_tiporiesgoid"
        parametro.Value = ListaAltaIncapacidad.PTipoRiesgoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_controlincapacidadid"
        parametro.Value = ListaAltaIncapacidad.PControlIncapacidadID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_secuelaid"
        parametro.Value = ListaAltaIncapacidad.PSecuelaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_tipomaternidadid"
        parametro.Value = ListaAltaIncapacidad.PTipoMaternidadID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_descripcion"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadDescripcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_aceptadoRT"
        parametro.Value = ListaAltaIncapacidad.PAceptadoRT
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_usuariomodificoid"
        parametro.Value = ListaAltaIncapacidad.PUsuarioModificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "inc_anterior"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadAnteirorId
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Editar_Incapacidades", listaParametros)
    End Sub

    Public Sub EliminarIncapacidades(ByVal ListaAltaIncapacidad As Entidades.Incapacidades)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "inc_incapacidadid"
        parametro.Value = ListaAltaIncapacidad.PIncapacidadID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Eliminar_Incapacidades", listaParametros)
    End Sub

    Public Function ListaIncapacidadesFiltro(ByVal NaveID As Integer, ByVal Colaborador As String, ByVal Replicado As String, ByVal patronID As Integer, ByVal fechaInicio As DateTime, ByVal fechafin As DateTime) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim ListaIncapacidades As New List(Of SqlParameter)
        'Dim consulta As String = ""
        'consulta += " select inc_incapacidadid,inc_folio,codr_nombre,codr_apellidopaterno,codr_apellidomaterno,inc_fechainicio,inc_fechafin,inc_diasautorizados,inc_descripcion,d.ramo_descripcion,e.trin_descripcion,f.inco_descripcion,g.inse_descripcion,"
        'consulta += " CASE WHEN cast(A.inc_fechafin as date) < cast(GETDATE() as date) AND (isnull(A.inc_formatoaltaincapacidad,0)=0 or isnull(A.inc_formatost7,0) = 0 or isnull(A.inc_formatost2,0)=0) THEN 1 else 0 END as validaMov"
        'consulta += " from nomina.incapacidades A"
        'consulta += " INNER JOIN Nomina.Colaborador B on B.codr_colaboradorid=A.inc_colaboradorid"
        'consulta += " INNER JOIN Nomina.ColaboradorLaboral C on C.labo_colaboradorid=A.inc_colaboradorid"
        'consulta += " LEFT JOIN Nomina.IncapacidadRamoSeguro D on D.ramo_ramoseguroid=A.inc_ramoseguroid"
        'consulta += " LEFT JOIN Nomina.IncapacidadTipoRiesgo E on E.trin_tiporiesgo=A.inc_tiporiesgoid"
        'consulta += " LEFT JOIN Nomina.IncapacidadControl F on F.inco_controlincapacidadid=A.inc_controlincapacidadid"
        'consulta += " LEFT JOIN Nomina.IncapacidadSecuelas G on G.inse_secuelaid=A.inc_secuelaid"
        ''consulta += " LEFT JOIN Nomina.IncapacidadTipoMaternidad H on H.inma_maternidadid=A.inc_tipomaternidadid"
        'consulta += " JOIN Nomina.ColaboradorNomina as cn on cn.cono_colaboradorid=b.codr_colaboradorid"
        'consulta += " WHERE (codr_nombre+' '+codr_apellidopaterno+' '+codr_apellidomaterno) like '%" + Colaborador.Replace(" ", "%") + "%'"

        'If patronID > 0 Then
        '    consulta += " and cn.cono_patronid=" + patronID.ToString
        'End If

        'If NaveID > 0 Then
        '    consulta += " and C.labo_naveid = " + NaveID.ToString
        'End If

        'consulta += " and (a.inc_fechainicio BETWEEN '" + fechaInicio.ToShortDateString + "' and  '" + fechafin.ToShortDateString + " 23:59:00'  or a.inc_fechafin BETWEEN '" + fechaInicio.ToShortDateString + "' and '" + fechafin.ToShortDateString + " 23:59:00')"

        'If Replicado <> "" Then
        '    consulta += " and inc_replicadonominpaq= '" + Replicado.ToString + "'"
        'End If
        'Return Operaciones.EjecutaConsulta(consulta)

        Dim parametro As New SqlParameter

        parametro.ParameterName = "patronId"
        parametro.Value = patronID
        ListaIncapacidades.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = NaveID
        ListaIncapacidades.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = Colaborador
        ListaIncapacidades.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = "'" + fechaInicio.ToShortDateString + "'"
        ListaIncapacidades.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = "'" + fechafin.ToShortDateString + " 23:59:00'"
        ListaIncapacidades.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "replicado"
        parametro.Value = Replicado
        ListaIncapacidades.Add(parametro)

        Return Operaciones.EjecutarConsultaSP("Nomina.SP_Consulta_ListadoIncapacidades", ListaIncapacidades)
    End Function

    Public Function consultaIncapacidadesAnteriores(ByVal idColaborador As Int32, ByVal idIncapacidad As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "colaboradorid"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidadid"
        parametro.Value = idIncapacidad
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_IncapacidadesAnteriores", listaParametros)
    End Function

    Public Function validarPerfilContabilidad() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ValidarPerfilContabilidad", listaParametros)
    End Function

    Public Function actualizarExpediente(ByVal idColaborador As Int32, ByVal idIncapacidad As Int32, ByVal expedienteid As Int32,
                                         ByVal tituloMovimiento As String, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idIncapacidad"
        parametro.Value = idIncapacidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "expedienteid"
        parametro.Value = expedienteid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tituloMovimiento"
        parametro.Value = tituloMovimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = archivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ActualizarExpediente", listaParametros)
    End Function

    Public Function consultaListadoArchivos(ByVal incapacidadId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidadid"
        parametro.Value = incapacidadId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ListaArchivos", listaParametros)
    End Function

    Public Function consultaListadoEstatus(ByVal tipoMovimiento As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "tipoMovimiento"
        parametro.Value = tipoMovimiento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaListadoEstatus_Movimientos", listaParametros)
    End Function

    Public Function buscarColaboradorGeneral(ByVal col As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Framework.Ciudades join Nomina.Colaborador on (codr_ciudadid = city_ciudadid) where codr_colaboradorid=" + col.ToString
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function buscarInformacionLaboral(ByVal colaboradorId As Int32) As DataTable
        Dim objOperaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "SELECT * FROM Nomina.ColaboradorLaboral as a"
        consulta += " left JOIN Framework.Naves as b on(a.labo_naveid=b.nave_naveid)"
        consulta += " left JOIN Framework.Grupos as c on(a.labo_departamentoid=c.grup_grupoid)"
        consulta += " left JOIN Nomina.Puestos as d on (a.labo_puestoid=d.pues_puestoid)"
        consulta += " left JOIN Nomina.Celulas as e on (labo_celulaid = celu_celulaid)"
        consulta += " left JOIN Nomina.Horarios as f on(hora_horarioid= labo_horarioid)"
        consulta += " WHERE labo_colaboradorid=" + colaboradorId.ToString
        consulta = consulta
        Return objOperaciones.EjecutaConsulta(consulta)
    End Function

    Public Function BuscarCredencialColaborador(ByVal Colaborador As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select * from Nomina.ColaboradorExpediente where cexp_colaboradorid=" + Colaborador.ToString
        consulta += " and cexp_credencial=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function validaIncapacidadIncial(ByVal colaboradorId As Int32, ByVal incapacidaId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorid"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidaId"
        parametro.Value = incapacidaId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ValidaIncapacidadInicial", listaParametros)
    End Function
End Class
