Imports System.Data.SqlClient

Public Class ActualizacionMasivaAgentesDA

    Public Function verCoordinadores() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT
	                                c.codr_colaboradorid AS 'ID_COORD'
	                               ,CONCAT(c.codr_nombre, ' ', c.codr_apellidopaterno, ' ', c.codr_apellidomaterno) AS 'NOMBRE_COLABORADOR'
                                FROM Nomina.Colaborador AS c
                                INNER JOIN Nomina.ColaboradorLaboral AS cl
	                                ON cl.labo_colaboradorid = c.codr_colaboradorid
                                LEFT JOIN Nomina.Puestos AS pu
	                                ON pu.pues_puestoid = cl.labo_puestoid
                                WHERE cl.labo_puestoid IN (1056, 1351)
                                AND pu.pues_activo = 1
                                AND c.codr_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verAgentesVentaComision() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("[Ventas].[SP_ActualizacionMasivaAgentes_verAgentesVentaComision]")
    End Function

    Public Function verRutas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " r.ruta_rutaid as idRuta,r.ruta_nombre as Ruta,count(c.clie_clienteid) as Clientes from Ventas.Rutas r " +
                            " inner join Cliente.Cliente c on c.clie_rutaid=r.ruta_rutaid " +
                            " where ruta_activo=1 and c.clie_activo=1 " +
                            " group by r.ruta_nombre, r.ruta_rutaid" +
                            " ORDER by r.ruta_nombre"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verMarcas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " marc_marcaid as idMarca,marc_descripcion as Marca " +
                            " from Programacion.Marcas" +
                            " where marc_activo=1 " +
                            " order by marc_descripcion asc"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verFamiliaVentas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " fapr_familiaproyeccionid as idFamilia,fapr_descripcion as 'Familia de Ventas' " +
                            " from Programacion.Familias_Proyeccion " +
                            " where fapr_activo=1 " +
                            " order by fapr_descripcion asc"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verAgentesAsignados() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                            " col.codr_colaboradorid idAgente,col.codr_nombre + ' ' + col.codr_apellidopaterno + ' '+col.codr_apellidomaterno as AgenteActual," +
                            " count(distinct c.clie_clienteid) as Clientes from Nomina.Colaborador col " +
                            " inner join Cliente.ClienteMarcaFamiliaProyeccionAgente cmae on  " +
                            " col.codr_colaboradorid=cmae.cmfa_colaboradorid_agente" +
                            " inner join Cliente.Cliente c on c.clie_clienteid=cmae.cmfa_clienteid" +
                            " where cmae.cmfa_activo=1" +
                            " group by col.codr_nombre + ' ' + col.codr_apellidopaterno + ' '+col.codr_apellidomaterno,col.codr_colaboradorid"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verListaPrincipal(idRuta As ArrayList, idMarca As ArrayList, idFamiliaVentas As ArrayList, idAgenteAsignado As ArrayList, agente As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim cadenaRuta As String = ""
        Dim cadenaMarca As String = ""
        Dim cadenaFamilia As String = ""
        Dim cadenaAgente As String = ""

        Dim cadena As String = ""
        If agente = "ventas" Then
            cadena = "SELECT" +
                          " c.clie_clienteid as IDSAY" +
                          " ,c.clie_idsicy as IDSICY" +
                          " ,CONCAT(col2.codr_nombre, ' ', col2.codr_apellidopaterno, ' ', col2.codr_apellidomaterno) AS 'Coordinador'" +
                          " ,c.clie_nombregenerico as Cliente,case when c.clie_activo = 1 then 'ACTIVO' else 'INACTIVO' end as Tipo" +
                          " ,r.ruta_nombre as Ruta" +
                          " ,M.marc_marcaid idMarca" +
                          " ,m.marc_descripcion as Marca" +
                          " ,f.fapr_familiaproyeccionid	as idFamilia" +
                          " ,f.fapr_descripcion as 'Familia de Ventas' " +
                          " ,col.codr_nombre + ' '+ col.codr_apellidopaterno + ' '+ col.codr_apellidomaterno as 'Agente de Ventas'" +
                          " ,isnull(u2.user_username,u1.user_username) as Modificó" +
                          " ,isnull(cmae.cmfa_fechamodificacion,cmae.cmfa_fechacreacion) as FModificación" +
                          " from Cliente.ClienteMarcaFamiliaProyeccionAgente cmae" +
                          " inner join Cliente.Cliente c on c.clie_clienteid=cmae.cmfa_clienteid" +
                          " inner join Ventas.Rutas r on r.ruta_rutaid=c.clie_rutaid" +
                          " inner join Nomina.Colaborador col on col.codr_colaboradorid=cmae.cmfa_colaboradorid_agente" +
                          " LEFT JOIN Nomina.Colaborador col2 ON col2.codr_colaboradorid = cmae.cmfa_coordinador" +
                          " inner join Programacion.Marcas m on m.marc_marcaid=cmae.cmfa_marcaid" +
                          " inner join Programacion.Familias_Proyeccion f on f.fapr_familiaproyeccionid=cmae.cmfa_familiaproyeccionid" +
                          " left join Framework.Usuarios u1 on u1.user_usuarioid=cmae.cmfa_usuariocreoid" +
                          " left join Framework.Usuarios u2 on u2.user_usuarioid=cmae.cmfa_usuariomodificoid" +
                          " where cmae.cmfa_activo=1 "

            If (idRuta.Count <> 0) Then

                For x = 0 To idRuta.Count - 1
                    Dim RowRuta As DataRow = CType(idRuta(x), DataRow)
                    cadenaRuta = cadenaRuta + RowRuta("idRuta").ToString + ","

                Next
                cadenaRuta = cadenaRuta.TrimEnd(",")
                cadena += "and r.ruta_rutaid in (" + cadenaRuta.ToString + ")"

            End If
            If idMarca.Count <> 0 Then

                For x = 0 To idMarca.Count - 1
                    Dim RowMarca As DataRow = CType(idMarca(x), DataRow)
                    cadenaMarca = cadenaMarca + RowMarca("idMarca").ToString + ","
                Next
                cadenaMarca = cadenaMarca.TrimEnd(",")
                cadena += "and m.marc_marcaid in (" + cadenaMarca + ")"

            End If
            If (idFamiliaVentas.Count <> 0) Then

                For x = 0 To idFamiliaVentas.Count - 1
                    Dim RowFamiliaVentas As DataRow = CType(idFamiliaVentas(x), DataRow)
                    cadenaFamilia = cadenaFamilia + RowFamiliaVentas("idFamilia").ToString + ","
                Next
                cadenaFamilia = cadenaFamilia.TrimEnd(",")
                cadena += "and f.fapr_familiaproyeccionid in (" + cadenaFamilia + ")"

            End If
            If idAgenteAsignado.Count <> 0 Then

                For x = 0 To idAgenteAsignado.Count - 1
                    Dim RowAgenteAsignado As DataRow = CType(idAgenteAsignado(x), DataRow)
                    cadenaAgente = cadenaAgente + RowAgenteAsignado("idAgente").ToString + ","
                Next
                cadenaAgente = cadenaAgente.TrimEnd(",")
                cadena += "and col.codr_colaboradorid in (" + cadenaAgente + ")"

            End If

            cadena += "ORDER BY c.clie_nombregenerico, m.marc_descripcion, f.fapr_descripcion"

        ElseIf agente = "comision" Then

            cadena += "SELECT" +
               " c.clie_clienteid AS IDSAY," +
               " c.clie_idsicy AS IDSICY," +
               " c.clie_nombregenerico AS Cliente,case when c.clie_activo = 1 then 'ACTIVO' else 'INACTIVO' end as Tipo," +
               " r.ruta_rutaid as idRuta," +
               " r.ruta_nombre AS Ruta," +
               " m.marc_marcaid as idMarca," +
               " m.marc_descripcion AS Marca," +
               " col.codr_colaboradorid as idAgenteVentas," +
               " col.codr_nombre + ' ' + col.codr_apellidopaterno + ' ' + col.codr_apellidomaterno AS 'Agente de Ventas'," +
               " col2.codr_colaboradorid as idAgenteComision," +
               " col2.codr_nombre + ' ' + col2.codr_apellidopaterno + ' ' + col2.codr_apellidomaterno AS 'Agente de Comisión'," +
               " ISNULL(u2.user_username, u1.user_username) AS Modificó," +
               " ISNULL(cmae.cmae_fechamodificacion, cmae.cmae_fechacreacion) AS FModificación" +
               " FROM Cliente.ClienteMarcaAgenteEmpresa cmae" +
               " INNER JOIN Cliente.Cliente c" +
               " ON c.clie_clienteid = cmae.cmae_clienteid" +
               " INNER JOIN Ventas.Rutas r" +
               " ON r.ruta_rutaid = c.clie_rutaid" +
               " INNER JOIN Nomina.Colaborador col" +
               " ON col.codr_colaboradorid = cmae.cmae_colaboradorid_agente" +
               " LEFT JOIN Nomina.Colaborador col2" +
               " ON col2.codr_colaboradorid = cmae.cmae_colaboradorid_agente_comision" +
               " INNER JOIN Programacion.Marcas m" +
               " ON m.marc_marcaid = cmae.cmae_marcaid" +
               " LEFT JOIN Framework.Usuarios u1" +
               " ON u1.user_usuarioid = cmae.cmae_usuariocreoid" +
               " LEFT JOIN Framework.Usuarios u2" +
               " ON u2.user_usuarioid = cmae.cmae_usuariomodificoid" +
               " WHERE " +
               " cmae.cmae_activo = 1"

            If idRuta.Count <> 0 Then

                For x = 0 To idRuta.Count - 1
                    Dim RowRuta As DataRow = CType(idRuta(x), DataRow)
                    cadenaRuta = cadenaRuta + RowRuta("idRuta").ToString + ","

                Next
                cadenaRuta = cadenaRuta.TrimEnd(",")
                cadena += "and r.ruta_rutaid in (" + cadenaRuta.ToString + ")"

            End If
            If idMarca.Count <> 0 Then

                For x = 0 To idMarca.Count - 1
                    Dim RowMarca As DataRow = CType(idMarca(x), DataRow)
                    cadenaMarca = cadenaMarca + RowMarca("idMarca").ToString + ","
                Next
                cadenaMarca = cadenaMarca.TrimEnd(",")
                cadena += "and m.marc_marcaid in (" + cadenaMarca + ")"

            End If

            If idAgenteAsignado.Count <> 0 Then

                For x = 0 To idAgenteAsignado.Count - 1
                    Dim RowAgenteAsignado As DataRow = CType(idAgenteAsignado(x), DataRow)
                    cadenaAgente = cadenaAgente + RowAgenteAsignado("idAgente").ToString + ","
                Next
                cadenaAgente = cadenaAgente.TrimEnd(",")
                cadena += "and col.codr_colaboradorid in (" + cadenaAgente + ")"

            End If

            cadena += " order by c.clie_nombregenerico,m.marc_descripcion"
        Else

        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function actualizaAgenteVentas(idAgenteVentasSAY As Integer, idClienteSAY As Integer, idClientSICY As Integer, idMarcaSAY As Integer, idFamiliaSAY As Integer, usuarioModifica As String, usuarioModificaNombre As String, idCoord As Integer)
        '(idMarcaSAY As Integer, idClienteSAY As Integer, idClienteSICY As Integer, idAgenteComisionSAY As Integer, usuarioModifica As Integer, usuarioModificaNombre As String, idAgenteVentas As Integer)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgente"
        parametro.Value = idAgenteVentasSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idMarca"
        parametro.Value = idMarcaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idFamilia"
        parametro.Value = idFamiliaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = usuarioModifica
        listaParametros.Add(parametro)

        ''actualiza el registro basado en AgenteMarcaFamiliaVentasForm
        parametro = New SqlParameter
        parametro.ParameterName = "@operacion"
        parametro.Value = 0
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCoord"
        parametro.Value = idCoord
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Ventas].[SP_InsertaActualizaRelacionMarcaFamilia]", listaParametros)
    End Function

    Public Function replicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY(nombreUsuario As String)
        '(@idClienteSICY int,@idClienteSAY int,@idMarcaSICY varchar(2),@nombreUsuario varchar(30),@pantallaOperacion as varchar(40))

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@nombreUsuario"
        parametro.Value = nombreUsuario
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_replicacionesClienteMarcaFamiliaProyeccionAgente_ClienteMarcaAgenteEmpresa_SAY_SICY", listaParametros)
    End Function


    Public Function actualizaProspecta()
        '(@idClienteSICY int,@idClienteSAY int,@idMarcaSICY varchar(2),@nombreUsuario varchar(30),@pantallaOperacion as varchar(40))

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return operacion.EjecutarConsultaSP("Ventas.SP_actualizaProspecta", listaParametros)
    End Function

    Public Function quitaAgenteComision(idUsuario As Integer, nombreUsuario As String, idClienteSAY As Integer, idMarcaSAY As Integer, idAgenteSAY As Integer)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nombreUsuario"
        parametro.Value = nombreUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idClienteSAY"
        parametro.Value = idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idMarcaSAY"
        parametro.Value = idMarcaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgenteSAY"
        parametro.Value = idAgenteSAY
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_EliminaAgenteComisionDeAgenteVentas_SAY_SICY", listaParametros)
    End Function



    Public Function actualizaAgenteComision(idMarcaSAY As Integer, idClienteSAY As Integer, idClienteSICY As Integer, idAgenteComisionSAY As Integer, usuarioModifica As Integer, usuarioModificaNombre As String, idAgenteVentas As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idMarcaSAY"
        parametro.Value = idMarcaSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idClienteSAY"
        parametro.Value = idClienteSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idClienteSICY"
        parametro.Value = idClienteSICY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgenteComisionSAY"
        parametro.Value = idAgenteComisionSAY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioModifica"
        parametro.Value = usuarioModifica
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioModificaNombre"
        parametro.Value = usuarioModificaNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgenteVentas"
        parametro.Value = idAgenteVentas
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_actualiza_AgentesComision_SAY_SICY", listaParametros)
    End Function

    Public Function ActualizaColeccionMarcaFamiliaCadenaAgente(ByVal cadenasIds As String)
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "cadenasIds"
        parametro.Value = cadenasIds
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_Ventas_ActualizaColeccionMarcaFamiliaCadenaAgente", listaParametros)
    End Function

    Public Function ActualizarAgentesProyeccionMarcaFamiliaCliente()
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Ventas_ReportesSay_ReporteGeneralVentas_ActualizarAsignacionClienteMarcaAgenteFamilia_Proyeccion]", listaParametros)

    End Function


End Class
