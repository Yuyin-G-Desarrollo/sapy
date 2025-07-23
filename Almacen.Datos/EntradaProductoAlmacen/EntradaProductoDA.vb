Imports Persistencia
Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class EntradaProductoDA
    Public Function ActualizarPreciosPares(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer, ByVal Tipo_Nave As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim procedimientoNombre As String = ""
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNave"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IDNAVE"
        parametro.Value = IdNave
        listaparametros.Add(parametro)


        Dim consulta As String
        If Tipo_Nave = True Then
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                consulta = "[Almacen].[SP_ActualizarPreciostmpDocenasParesConSalidaNavesDetalles]"
            Else
                consulta = "[Almacen].[SP_ActualizarPreciostmpDocenasParesConSalidaNavesDetalles_" & IdNave.ToString & "]"
            End If
        Else
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                consulta = "[Almacen].[SP_ActualizarPreciostmpDocenasParesConSalidaNavesDetalles]"
            Else
                consulta = "[Almacen].[SP_ActualizarPreciostmpDocenasParesConSalidaNavesDetalles_" & IdNave.ToString & "]"
            End If

        End If
        Return objPersistencia.EjecutarConsultaSP(consulta, listaparametros)
    End Function
    ''' <summary>
    ''' CONSULTA EL ESTADO DE UNA SALIDA DE NAVE DEACUERDO A SU COLUMNA DE ID
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A CONSULTAR</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CON SULTA</returns>
    ''' <remarks></remarks>
    Public Function VerificarSalidaNaveEmbarcada(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select (select sana_estado from Almacen.SalidaNaves where  sana_salidanavesid = " + IdSalidaNave.ToString + ") as 'ESTADO'" +
            ",(select sana_salidanavesid from almacen.SalidaNaves where sana_naveid = " + IdNave.ToString + " and sana_salidanavesid = " + IdSalidaNave.ToString + ") AS 'NAVE VALIDA'"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' ACTUALIZA EL ESTADO DE DE UNA SALIDA DE NAVE CUANDO COMIENZA SU PROCESO DE INGRESO DE PRODUCTO
    ''' </summary>
    ''' <param name="IdSalidaNaves">ID DE LA SALIDA DE NAVE A ACTUALIZAR</param>
    ''' <remarks></remarks>
    Public Sub ActualizarEstatus_SalidaNave_ParaElComienzoDelEscaneo(ByVal IdSalidaNaves As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "UPDATE ALMACEN.SalidaNaves SET sana_estado = 'INGRESANDO'  WHERE sana_salidanavesid = " + IdSalidaNaves.ToString
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ' ''' <summary>
    ' ''' RECUPERA LA INFORMACION DE TODOS LOS PARES INCUIDOS EN UNA SALIDA DE NAVE EN ESTADO EMBARCADO COMO LO ES, LOTE, NUMERO DE ATADO, ATADO, PAR, DESCRIPCION, TALLA Y UN 0 COMO ESTADO
    ' ''' </summary>
    ' ''' <param name="IdSalidaNave"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function RecuperarInformacionDeLotesEmbarcados_Pares_Leidos(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer) As DataTable
    '    Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
    '    Dim Consulta As String = ""

    '    Consulta = "SELECT snde_lote AS 'Lote',snde_numero_atado AS '#',snde_codigoatado AS 'Atado',snde_codigopar AS 'Par'," +
    '        " b.Descripcion AS 'Descripción',snde_talla AS 'Talla',a.snde_resultadoid_atado_entrada AS 'Estado' "
    '    If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 Then
    '        Consulta += " FROM Almacen.SalidaNavesDetalles as a "
    '    Else
    '        Consulta += " FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + " as a "
    '    End If
    '    Consulta += " JOIN vEstilos b ON b.IdCodigo = a.snde_idproducto" +
    '        " WHERE snde_salidanavesid = " + IdSalidaNave.ToString + " AND a.snde_resultadoid_par_entrada IS NOT NULL ORDER BY snde_numero_atado, snde_codigoatado"
    '    Return objPersistencia.EjecutaConsulta(Consulta)
    'End Function

    ''' <summary>
    ''' RECUPERA UN VALOR NULLO CON EL TITULO DE QUITAR, EL LOTE, NUMERO DE ATADO, ATADO, DESCRIPCION DE ATADO, 0 CON EL TITULO DE ESTADO Y  AÑO DE TODOS LOS SATADOS INCLUIDOS EN UNA SALIDA DE NAVES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarInformacionDeLotesEmbarcados_Atados_Leidos(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = " SELECT CAST(0 AS bit) AS 'Quitar', snde_lote AS 'Lote', snde_numero_atado AS '# En lote', snde_codigoatado AS 'Atado', b.Descripcion AS 'Descripción'," +
                " CASE WHEN a.snde_resultadoid_atado_entrada IS NULL THEN 0 ELSE a.snde_resultadoid_atado_entrada END as 'Estado'," +
                " snde_año AS 'Año'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            Consulta += " FROM Almacen.SalidaNavesDetalles a "
        Else
            Consulta += " FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + " a "
        End If

        Consulta += " JOIN vEstilos b ON b.IdCodigo = a.snde_idproducto WHERE snde_salidanavesid = " + IdSalidaNave.ToString +
                " and snde_tipo_codigo is not null GROUP BY a.snde_año, a.snde_lote,snde_numero_atado, snde_codigoatado, b.Descripcion, a.snde_resultadoid_atado_entrada"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES, AADOS Y LOTES EMBARCADOS EN UNA SALUDA DE NAVES EN ESTADO 'EMBARCADO'
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA CUAL SE RECUPERARAN LOS TOTALES</param>
    ''' <returns>RECULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarTotalesdeSalidaNaveEmbarcada(ByVal IdSalidaNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select sana_totalpares as 'Total pares', sana_totalatados as 'Total atados', sana_totallotes as 'Total lotes' " +
            " from almacen.SalidaNaves where sana_salidanavesid =  " + IdSalidaNave.ToString
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' VERIFICA SÍ UN ATADO SE ENCUENTRA EN LA TABLA SALIDANAVESDETALLES, PARA UNA SALIDA DE NAVE EN ESPECIFICO
    ''' </summary>
    ''' <param name="Atado">ID DE ATADO A VERIFICAR</param>
    ''' <param name="IdSalidaNave">SALIDA DE NAVE EN LA QUE SE VERIFICARA</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ValidarAtadoPertenecienteALaSalidaDeNavesEnProceso(ByVal Atado As String, ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim Consulta As String = ""
        Consulta = "select snde_codigoatado, snde_tipo_codigo"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            Consulta += " from almacen.SalidaNavesDetalles "
        Else
            Consulta += " from almacen.SalidaNavesDetalles_" + IdNave.ToString
        End If
        Consulta += " where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_codigoatado = '" + Atado + "' and snde_tipo_codigo is not null"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS PARES Y CARACTERISTICAS(ATADO, PAR, TALLA, CODIGO CLIENTE, ESTADO, DESCRIPCION, CLAVE DEL PRODUCTO, NUMERO DE PAR) DE LOS MISMOS, DE UN ATADO EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdAtado">ID DEL ATADO DEL CUAL SE RECUPERARA LA INFORMACION</param>
    ''' <param name="snde_salidanavesid">ID LA SALIDA DE NAVE DE LA CUAL SE RECUPERARA LA INFORMACIÓN</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_dtPares_Para_de_tabla_SalidaNavesDetalles(ByVal IdAtado As String, ByVal snde_salidanavesid As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = " SELECT snde_codigoatado AS 'ATADO', snde_codigopar AS 'PAR', snde_talla AS 'TALLA', snde_codigopar AS 'CODIGO_CLIENTE', 1 AS 'Estado', " +
            " vEstilos.Descripcion AS 'Descripcion', snde_idproducto as 'CLAVE_PRODUCTO', snde_numero_par  AS '#' "
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " FROM  almacen.SalidaNavesDetalles "
        Else
            consulta += " FROM  almacen.SalidaNavesDetalles_" + IdNave.ToString
        End If
        consulta += " Join vEstilos ON snde_idproducto = vEstilos.IdCodigo WHERE snde_salidanavesid = " + snde_salidanavesid.ToString + " and snde_codigoatado = '" + IdAtado + "' and snde_tipo_codigo is not null"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' ELIMINA LOS PARES EN ESTADO SOBRANTE DE UN ATADO DETERMINADO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ENCUENTRA EL ATADO EN EL QUE SE ELIMINARAN LOS PARES</param>
    ''' <param name="AtadoActual">CLAVE DEL ATADO EDEL CUAL SE ELIMINARAN LOS PARES SOBRANTES</param>
    ''' <remarks></remarks>
    Public Sub Eliminar_ParesSobrantes_De_Atado_SalidaNavesDetalles(ByVal IdSalidaNave As Integer, ByVal AtadoActual As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        consulta = "DELETE from "
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " Almacen.SalidaNavesDetalles"
        Else
            consulta += " Almacen.SalidaNavesDetalles_" + IdNave.ToString
        End If
        consulta += " WHERE snde_salidanavesid =" + IdSalidaNave.ToString + " AND  snde_codigoatado = '" + AtadoActual + "'  and snde_resultadoid_par_entrada = 3 "
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' ACTUALIZA EL ESTADO DE LOS PARES DE UN ATADO DETERMINADO A NULL
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ENCUENTRA EL ATADO</param>
    ''' <param name="AtadoActual">ID DEL ATADO DEL CUAL SE REINICIARA EL ESTADO DE SUS PARES</param>
    ''' <remarks></remarks>
    Public Sub Eliminar_Estado_De_Pares_Atado_Para_Entrada_De_Producto_SalidaNavesDetalles(ByVal IdSalidaNave As Integer, ByVal AtadoActual As String, ByVal LoteTerminado As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = ""
        If LoteTerminado = "COMPLETO" Then
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                consulta = "UPDATE ALMACEN.SalidaNavesDetalles SET snde_resultadoid_par_entrada = NULL, snde_resultadoid_atado_entrada = 2"
            Else
                consulta = "UPDATE ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " SET snde_resultadoid_par_entrada = NULL, snde_resultadoid_atado_entrada = 2"
            End If
            consulta += " WHERE snde_salidanavesid = " + IdSalidaNave.ToString + " AND snde_codigoatado = '" + AtadoActual + "'"
        ElseIf LoteTerminado = "INCOMPLETO" Then
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                consulta = "UPDATE ALMACEN.SalidaNavesDetalles SET snde_resultadoid_par_entrada = NULL, snde_resultadoid_atado_entrada = 7"
            Else
                consulta = "UPDATE ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " SET snde_resultadoid_par_entrada = NULL, snde_resultadoid_atado_entrada = 7"
            End If
            consulta += " WHERE snde_salidanavesid = " + IdSalidaNave.ToString + " AND snde_codigoatado = '" + AtadoActual + "'"
        End If

        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS PARES DE UNA ENTRADA DE  PRODUCTO EN PROCESO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVES DE LA QUE SE RECUPERARA EL PROCESO</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperaParesDeEntradaLotesEnProceso(ByVal IdSalidaNave As Integer, ByVal IdNAve As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = " SELECT snde_codigoatado AS 'ATADO', snde_codigopar AS 'PAR', snde_lote AS 'LOTE', snde_naveid AS 'IDNAVE', snde_año AS 'AÑO', " +
            " a.snde_resultadoid_par_entrada AS 'R_PAR', a.snde_resultadoid_atado_entrada AS 'R_ATADO', snde_numero_par AS 'N_PAR', snde_numero_atado AS 'N_ATADO'," +
            " b.Descripcion AS 'DESCRIPCION', snde_talla AS 'TALLA', snde_idcarrito as 'ID_CARRITO'"
        If IdNAve <> 1 And IdNAve <> 2 And IdNAve <> 3 And IdNAve <> 7 And IdNAve <> 11 And IdNAve <> 15 And IdNAve <> 10 And IdNAve <> 18 And IdNAve <> 5 And IdNAve <> 14 And IdNAve <> 60 Then
            consulta += " FROM Almacen.SalidaNavesDetalles a JOIN vEstilos b ON b.IdCodigo = a.snde_idproducto "
        Else
            consulta += " FROM Almacen.SalidaNavesDetalles_" + IdNAve.ToString + " a JOIN vEstilos b ON b.IdCodigo = a.snde_idproducto "
        End If
        consulta += " WHERE snde_salidanavesid = " + IdSalidaNave.ToString + " AND a.snde_resultadoid_par_entrada IS NOT NULL ORDER BY a.snde_lote,snde_numero_atado, snde_codigoatado"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LOS ATADOS YA LEEIDOS E INCLUIDOS EN LA TABLA Almacen.SALIDANAVESDETALLES CON SU ESTADO Y SU LOTE CORRESPONDIENTE PARA ACTUALIZAR LA TABLA DE GRID ERRONEOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE A RECUPERAR INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarResultadosDeAtadosLeeidosEnProduccionSalidaNAves_Entrada_De_Producto(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select DISTINCT snde_codigoatado AS 'ATADO', snde_numero_atado AS '#', snde_resultadoid_atado_entrada AS 'RESULTADO', snde_lote AS 'LOTE', Descripcion as 'DESCRIPCION'," +
            " snde_año as 'AÑO'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " from Almacen.SalidaNavesDetalles "
        Else
            consulta += " from Almacen.SalidaNavesDetalles_" + IdNave.ToString
        End If
        consulta += " join vestilos on IdCodigo = snde_idproducto where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_tipo_codigo is not null ORDER BY snde_numero_atado "
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA LA CONSULTA PARA ACTUALIZAR EL CAMPO SNDE_DEVUELTO DE 0 A 1
    ''' </summary>
    ''' <param name="IdSAlidaNave">ID DE LA SALIDA DE NAVE</param>
    ''' <param name="Lote">LOTE A ACTUALIZAR</param>
    ''' <param name="Año">AÑO DEL LOTE A ACTUALIZAR</param>
    ''' <remarks></remarks>
    Public Sub DescarTarPares_Entrada_De_Producto(ByVal IdSAlidaNave As Integer, ByVal Lote As Integer, ByVal Año As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta = "UPDATE ALMACEN.SalidaNavesDetalles SET snde_devuelto = 1, snde_entregado = 0 " +
            " WHERE snde_lote = " + Lote.ToString + " AND snde_año =" + Año.ToString + " AND snde_salidanavesid = " + IdSAlidaNave.ToString +
            " AND snde_resultadoid_par_entrada IS NOT NULL AND snde_resultadoid_atado_entrada not in(0,9,4)"
        Else
            consulta = "UPDATE ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " SET snde_devuelto = 1, snde_entregado = 0 " +
            " WHERE snde_lote = " + Lote.ToString + " AND snde_año =" + Año.ToString + " AND snde_salidanavesid = " + IdSAlidaNave.ToString +
            " AND snde_resultadoid_par_entrada IS NOT NULL AND snde_resultadoid_atado_entrada not in(0,9,4)"
        End If

        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' ACTUALIZA UN CODIGO DE PAR DE UN ATADO DE CODIGO UNICO A CODIGO DE CLIENTE
    ''' </summary>
    ''' <param name="Id_Salida">ID DE LA SALIDA DE NAVE EN LA QUE SE BUSCARA EL PAR</param>
    ''' <param name="Atado">ATADO EN EL QUE SE ENCUENTRA EL PAR</param>
    ''' <param name="Codigo_Unico">CODIGO UNICO QUE TIENE EL PAR</param>
    ''' <param name="Codigo_Cliente">CODIGO DE CLIENTE QUE SE LE ASIGNARA AL PAR</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_TiposDeCodigo_A_Codigos_Cliente_Cuando_En_La_Salida_No_Se_Valido_ParxPar(ByVal Id_Salida As Integer, ByVal Atado As String,
                                                                                                   ByVal Codigo_Unico As String, ByVal Codigo_Cliente As String,
                                                                                                   ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta = "update almacen.SalidaNavesDetalles set snde_codigopar = '" + Codigo_Cliente + "'" +
            " where snde_codigopar = '" + Codigo_Unico + "' and snde_codigoatado = '" + Atado + "' and snde_salidanavesid = " + Id_Salida.ToString
        Else
            consulta = "update almacen.SalidaNavesDetalles_" + IdNave.ToString + " set snde_codigopar = '" + Codigo_Cliente + "'" +
            " where snde_codigopar = '" + Codigo_Unico + "' and snde_codigoatado = '" + Atado + "' and snde_salidanavesid = " + Id_Salida.ToString
        End If
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' ACTUALIZA EL CAMPO SNDE_ENTREGADO A 1 Y EL CAMPO SNDE_DEVUELTO A 0 PARA TODOS LOS PARES QUE PERTENESCAN A UN LOTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE EN LA QUE SE ACTUALIZARA LA INFORMACION</param>
    ''' <param name="Lote">LOTE DE LOS PARES QUE SE LES DARA ENTRADA</param>
    ''' <param name="Año">AÑO DE LOS PARES</param>
    ''' <remarks></remarks>
    Public Sub Actualizar_Estado_De_Pares_Del_Lote_A_Entregado(ByVal IdSalidaNave As Integer, ByVal Lote As Integer, ByVal Año As Integer, ByVal Tipo_Nave As Boolean, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If Tipo_Nave = True Then
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                consulta = " Update almacen.SalidaNavesDetalles"
            Else
                consulta = " Update almacen.SalidaNavesDetalles_" + IdNave.ToString
            End If
            consulta += " set snde_devuelto = 0, snde_entregado = 1, snde_embarcado = 1" +
            " where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_lote = " + Lote.ToString + " and snde_año = " + Año.ToString
        Else
            If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
                consulta = " Update almacen.SalidaNavesDetalles"
            Else
                consulta = " Update almacen.SalidaNavesDetalles_" + IdNave.ToString
            End If
            consulta += " set snde_devuelto = 0, snde_entregado = 1" +
            " where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_lote = " + Lote.ToString + " and snde_año = " + Año.ToString
        End If
        objPersistencia.EjecutaConsulta(consulta)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS TOTALES DE PARES LEIDOS, PARES QUE EN TOTAL SE DEBERIAN LEER, PARES NO LEIDOS, PARES ENTREGADOSM ATADOS ENTREGADOS, LOTES ENTREGADOS, PARES REGRESADOS, ATADOS REGRESADOS Y LOTES REGRESADOS
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA QUE SE RECUPERARA LA INFORMACION</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Entrada_De_Nave_En_Proceso(ByVal IdSalidaNave As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta = "SELECT (SELECT COUNT(snde_resultadoid_atado) FROM ALMACEN.SalidaNavesDetalles WHERE snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'LEIDOS'," +
            "(SELECT COUNT(snde_salidanavesdetallesid) FROM Almacen.SalidaNavesDetalles  WHERE snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'TOTAL A LEER'," +
            "(SELECT COUNT(snde_entregado)  FROM ALMACEN.SalidaNavesDetalles WHERE snde_devuelto = 0 AND snde_entregado = 0  AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'NO LEIDOS'," +
            "(select count(snde_codigopar) as 'PARES'   from almacen.SalidaNavesDetalles where snde_salidanavesid =  " + IdSalidaNave.ToString + " and snde_entregado = 1) AS 'PARES ENTREGADOS'," +
            "(select count(DISTINCT snde_codigoatado) as 'ATADOS'   from almacen.SalidaNavesDetalles where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_entregado = 1) AS  'ATADOS ENTREGADOS'," +
            "(select count(DISTINCT (snde_lote+'-'+snde_año)) as 'LOTES'   from almacen.SalidaNavesDetalles where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_entregado = 1  ) AS 'LOTES ENTREGADOS'," +
            "(select COUNT(snde_codigopar)	FROM ALMACEN.SalidaNavesDetalles WHERE snde_devuelto = 1 AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'PARES DEVUELTOS'," +
            "(select COUNT(DISTINCT snde_codigoatado)	FROM ALMACEN.SalidaNavesDetalles WHERE snde_devuelto = 1 AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'ATADOS DEVUELTOS'," +
            "(select COUNT(DISTINCT (snde_lote+'-'+snde_año)) FROM ALMACEN.SalidaNavesDetalles WHERE snde_devuelto = 1 AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'LOTES DEVUELTOS'"
        Else
            consulta = "SELECT (SELECT COUNT(snde_resultadoid_atado) FROM ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " WHERE snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'LEIDOS'," +
            "(SELECT COUNT(snde_salidanavesdetallesid) FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + "  WHERE snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'TOTAL A LEER'," +
            "(SELECT COUNT(snde_entregado)  FROM ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " WHERE snde_devuelto = 0 AND snde_entregado = 0  AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'NO LEIDOS'," +
            "(select count(snde_codigopar) as 'PARES'   from almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_salidanavesid =  " + IdSalidaNave.ToString + " and snde_entregado = 1) AS 'PARES ENTREGADOS'," +
            "(select count(DISTINCT snde_codigoatado) as 'ATADOS'   from almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_entregado = 1) AS  'ATADOS ENTREGADOS'," +
            "(select count(DISTINCT (snde_lote+'-'+snde_año)) as 'LOTES'   from almacen.SalidaNavesDetalles_" + IdNave.ToString + " where snde_salidanavesid = " + IdSalidaNave.ToString + " and snde_entregado = 1  ) AS 'LOTES ENTREGADOS'," +
            "(select COUNT(snde_codigopar)	FROM ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " WHERE snde_devuelto = 1 AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'PARES DEVUELTOS'," +
            "(select COUNT(DISTINCT snde_codigoatado)	FROM ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " WHERE snde_devuelto = 1 AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'ATADOS DEVUELTOS'," +
            "(select COUNT(DISTINCT (snde_lote+'-'+snde_año)) FROM ALMACEN.SalidaNavesDetalles_" + IdNave.ToString + " WHERE snde_devuelto = 1 AND snde_salidanavesid = " + IdSalidaNave.ToString + ") AS 'LOTES DEVUELTOS'"
        End If

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' PROCEDIMIENTO ALMACENADO EN EL QUE SE ACTUALIZA EL ESTADO DE ENTRADA AL ALMACEN DE 0 A 1 EN LA TABLA TMPDOCENASPARES PARA LOS OARES QUE SE RECIBIERON ADEMAS DE LA FECHA EN LA QUE ESNTRARON
    ''' , TAMBIEN SE ASIGNAN LAS PLATAFORMAS(CARRITOS) CON SU CONTENIDO A LAS TABLAS OCUPACIONCARRITOS Y OCUPACIONCARRITOSLOTES, Y FINALMENNTE SE ACTUALIZA LA TABLA SALIDANAVES PARA CONCLUIR EL 
    ''' PROCESO DE ENTRADA
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="Tipo_Nave">TIPO DE NAVE CON LA QUE SE ESTA TRABAJANDO</param>
    ''' <param name="ParesEntregados">CANTIDAD DE PARES A LOS QUE SE LES DIO ENTRADA</param>
    ''' <param name="AtadosEntregados">CANTIDAD DE ATADOS A LOS QUE SE LES DIO ENTRADA</param>
    ''' <param name="LotesEntregados">CANTIDAD DE LOSTES A LOS QUE SE LES DIO ENTRADA</param>
    ''' <param name="ParesRegresados">CANTIDAD DE PARES QUE SE REGRESARON</param>
    ''' <param name="AtadosRegresados">CANTIDAD DE ATADOS QUE SE REGRESARON</param>
    ''' <param name="LotesRegresados">CANTIDAD DE LOTES REGRESADOS</param>
    ''' <returns>TABLA CON UNA CELDA CON EL MENSAJE "EXITO" O "ERROR", DEPENDIENDO DE SI HUBO O NO ERRORES EN LA EJECUCION DE PROCEDIMIENTO ALMACENADO</returns>
    ''' <remarks></remarks>
    Public Function FinalizarEntradaProducto(ByVal IdSalidaNave As Integer, ByVal Tipo_Nave As Boolean, ByVal ParesEntregados As Integer, ByVal AtadosEntregados As Integer,
                                          ByVal LotesEntregados As Integer, ByVal ParesRegresados As Integer, ByVal AtadosRegresados As Integer,
                                          ByVal LotesRegresados As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim d As New DataTable

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNave"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo_Nave"
        parametro.Value = Tipo_Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalParesEntrada"
        parametro.Value = ParesEntregados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalAtadosEntrada"
        parametro.Value = AtadosEntregados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalLotesEntrada"
        parametro.Value = LotesEntregados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalParesDevueltos"
        parametro.Value = ParesRegresados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalAtadosDevueltos"
        parametro.Value = AtadosRegresados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TotalLotesDevueltos"
        parametro.Value = LotesRegresados
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = IdNave
        listaparametros.Add(parametro)

        d = objPersistencia.EjecutarConsultaSP("[Almacen].[SP_Finalizar_Proceso_Entrada_Producto_Almacen_PB]", listaparametros)
        ActualizarPreciosPares(IdSalidaNave, IdNave, Tipo_Nave)
        Return d
    End Function

    ''' <summary>
    ''' VALIDA QUE UN CODIGO DE CARRITO EXISTA Y ESTE ACTIVO, EN CASO DE NO ESTARLO REGRESA UN 0, DE LO CONTRARIO UN 1
    ''' </summary>
    ''' <param name="IdCarrito">ID DEL CARRITO A VERIFICAR</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarCarritoPerteneciente_a_Nave(ByVal IdCarrito As Integer, ByVal IdNave As Integer, ByVal Id_Almacen As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "SELECT count(carr_carritoid) FROM Almacen.Carrito where carr_carritoid = " + IdCarrito.ToString + " and carr_activo = 1" +
            " AND carr_nave = " + IdNave.ToString + " and carr_almacen = " + Id_Almacen.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA QUE RECUPERA LA CANTIDAD DE ATADOS EMBARCADOS REGISTRADA EN LA TABLA ALMACEN.SALIDANAVES
    ''' </summary>
    ''' <param name="IdSalidaNave">ID DE LA SALIDA DE NAVE DE LA QUE SE PRETENDE RECUPERAR INFORMACION</param>
    ''' <returns>EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarCantidadDeAtadosEmbarcados(ByVal IdSalidaNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "SELECT sana_totalatados FROM ALMACEN.SalidaNaves WHERE sana_salidanavesid = " + IdSalidaNave.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' FUNCION QUE RECUPERA LOS EXISTENTES DE CLIENTES, TIENDAS, CORRIDAS Y PRODUCTOS SEGUN SEA EL CASO REQUERIDO
    ''' </summary>
    ''' <param name="IdParametro">ID DEL CASO PARA LA CONSULTA
    ''' 1.- CLIENTES
    ''' 2.- TIENDAS
    ''' 3.- CORRIDAS
    ''' 4.- PRODUCTOS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarInformacionDelParametro(ByVal IdParametro As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If IdParametro = 1 Then
            consulta = "SELECT IdCadena AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdCadena AS 'Cadena', nombre AS 'Nombre'" +
                " FROM vCadenas  WHERE Activo = 'S' ORDER BY nombre"
        ElseIf IdParametro = 2 Then
            consulta = " SELECT IdDistribucion AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdDistribucion AS 'ID', cadena AS 'Cliente', distribucion AS 'Tienda'," +
                " ciudad AS 'Ciudad'  FROM vCadenasDistribucion ORDER BY cliente, distribucion, Ciudad"
            Return objPersistencia.EjecutaConsulta(consulta)
        ElseIf IdParametro = 3 Then
            consulta = " SELECT IdTalla AS 'Parámetro', CAST(0 AS BIT) AS ' ' , IdTalla AS 'Talla ID', Talla AS 'Talla' FROM tallas ORDER BY Talla"
        ElseIf IdParametro = 4 Then
            consulta = "SELECT IdCodigo AS 'Parámetro',  CAST(0 AS BIT) AS ' ', IdModelo AS 'Modelo',Descripcion AS 'Descripción', Color AS 'Color'," +
                " Coleccion AS 'Colección', Marca AS 'Marca' FROM vEstilos ORDER BY Descripcion, IdModelo, Color "
        ElseIf IdParametro = 5 Then
            consulta += " SELECT calc_calce AS 'Parámetro', CAST(0 AS BIT) AS ' ', calc_calce AS 'Talla'" +
                 " FROM Programacion.Calce" +
                 " WHERE calc_activo = 1" +
                 " ORDER BY calc_calce"
        End If
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LAS SALIDAS DE NAVE DEACUERDO A LOS FILTROS SELECCIONADOS
    ''' </summary>
    ''' <param name="lLotes">LOTES EN LOS QUE SE BUSCARA </param>
    ''' <param name="lAtados"> ATADOS EN LOS QUE SE BUSCARA </param>
    ''' <param name="lPedidos"> PEDIDOS EN LOS QUE SE BUSCARA </param>
    ''' <param name="lProductos"> ID DE LOS PRODUCTOS EN LOS QUE SE BUSCARA </param>
    ''' <param name="lClientes"> IDS DE LOS CLIENTES EN LOS QUE SE BUSCARA </param>
    ''' <param name="lCorridas"> IDS DE LAS CORRIDAS EN LAS QUE SE BUSCARA </param>
    ''' <param name="lTiendas"> IDS DE LAS TIENDAS EN LAS QUE SE BUSCARA </param>
    ''' <param name="lNave"> IDS DE LAS NAVES EN LAS QUE SE BUSCARA</param>
    ''' <param name="fechaInicioEntradas"> FECHA DE INICIO DE ENTRADAS(RANGO) </param>
    ''' <param name="fechaTerminoEntradas"> FECHA DE FIN DE ENTRADAS(RANGO)</param>
    ''' <param name="fechaInicioProgramas"> FECHA DE INICIO DE PROGRAMA(RANGO)</param>
    ''' <param name="fechaTerminoProgramas"> FECHA DE FIN DE PROGRAMA(RANGO)</param>
    ''' <param name="bY_O">BOOLEANO TRUE PARA BUSCAR CON CONDICION AND, FALSE PARA BUSCAR CON CONDICION OR</param>
    ''' <param name="filtroFechaPrograma"> VALOR BOOLEANO, TRUE PARA FILTRAR POR FECHA DE PROGRAMA, FALSE PARA NO. </param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaDeSalidas(ByVal Ubicacion_Y_N As Boolean, ByVal lTallas As String, ByVal lLotes As String, ByVal lAtados As String, ByVal lPedidos As String, ByVal lProductos As String, ByVal lClientes As String,
                                            ByVal lCorridas As String, ByVal lTiendas As String, ByVal lNave As String, ByVal fechaInicioEntradas As String, ByVal fechaTerminoEntradas As String,
                                            ByVal fechaInicioProgramas As String, ByVal fechaTerminoProgramas As String, ByVal bY_O As Boolean, ByVal filtroFechaPrograma As Boolean, ByVal EsPedidoActual As Boolean, ByVal EsClienteActual As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        '---------Cabiar a tmpdocenaspares de tutin cuando este en productivo
        If Ubicacion_Y_N = True Then
            consulta = " SELECT CASE WHEN k.Tipo = 'PAR'  THEN 'P' ELSE  CASE WHEN k.Tipo = 'ATADO'  THEN 'A' ELSE 'E' END END AS 'Tipo', " +
                " CASE WHEN A.Status = 1 THEN 'ALMACÉN' ELSE  CASE WHEN a.STATUS = 2 OR A.Status = '' THEN  'EXTERNO' ELSE CASE WHEN a.STATUS = 0 THEN 'EN PROCESO' END END END AS 'Proceso'" +
                " , A.Disponible AS 'D'," +
                " A.Asignado AS 'A',A.Calidad AS 'C',A.Bloqueado AS 'B',A.Reproceso AS 'R',A.Proyectado AS 'P', a.ID_Par AS 'Par',A.ID_Docena AS 'Atado'," +
                " CASE WHEN (ubpa_estibaid = ''  OR ubpa_estibaid is null ) then 'SIN UBICACIÓN' ELSE LEFT(k.ubpa_estibaid, CHARINDEX('-', k.ubpa_estibaid) -1) END AS 'Estiba'," +
                " CASE WHEN (ubpa_estibaid =''  OR ubpa_estibaid is null) then 'SIN UBICACIÓN' ELSE k.ubpa_estibaid END AS 'ID_ESTIBA'," +
                " CASE WHEN ( M.bahi_bahiaid =''  OR  M.bahi_bahiaid is null) then 'SIN UBICACIÓN' ELSE M.bahi_bahiaid END AS 'Bahía ID'," +
                " m.bahi_bloque as 'Bloque',m.bahi_nivel as 'Nivel',M.bahi_posicion as 'Posicion',m.bahi_color as 'Color'," +
                " A.idtblnave AS 'Id_Nave', n.Nave as 'Nave',A.FechaEntradaAlmacen AS 'Fecha Entrada(Con hr.)', " +
                " isnull(idsalidanave,0) AS 'Folio Salida', " +
                " CONVERT(varchar(10), A.FechaEntradaAlmacen, 103) AS 'Fecha Entrada',B.FechaPrograma AS 'Programa',D.IdModelo AS 'Modelo'," +
                " D.marca as 'Marca', D.Coleccion AS 'Colección',E.Piel AS 'Piel',F.Nombre AS 'Color de Piel',G.Talla AS 'Corrida',a.Calce AS 'Talla'," +
                " I.nombre AS 'Tienda',H.nombre AS 'Cliente',J.Iniciales AS 'Agte',a.idtbllote AS 'Lote',a.idtblPedido AS 'Pedido'," +
                " C.Entrega AS 'Fecha Entrega',C.Orden AS 'Orden de Compra'" +
                " ,	a.pedidoid_origen as 'Pedido Origen',co.nombre as 'Cliente Origen', c.EntregaCliente as 'Entrega Cliente'" +
                " FROM tmpdocenaspares AS A" +
                " JOIN Programas AS B ON a.idtblPrograma = b.IdPrograma" +
                " LEFT JOIN Pedidos AS C ON C.IdPedido = a.idtblPedido" +
                " LEFT JOIN vEstilos AS D ON D.IdCodigo = a.idtblProducto" +
                " LEFT JOIN Pieles AS E ON E.IdPiel = D.IdPiel" +
                " LEFT JOIN Colores AS F ON F.IdColor = d.IdColor" +
                " LEFT JOIN Tallas AS G ON G.IdTalla = a.idtblTalla" +
                " LEFT JOIN vcadenas AS H ON H.IdCadena = a.idtblcte" +
                " LEFT JOIN Distribuciones AS I ON I.IdDistribucion = a.idtblTienda " +
                " LEFT JOIN Agentes AS J ON J.IdAgente = C.IdAgente" +
                " LEFT JOIN vParesUbicacionesErrores AS K ON K.ubpa_codigoatado = A.ID_Docena AND  K.ubpa_codigopar = A.ID_Par" +
                " LEFT JOIN Almacen.Estiba AS L ON L.esti_estibaid = K.ubpa_estibaid" +
                " LEFT JOIN Almacen.Bahia AS M ON  M.bahi_bahiaid = L.esti_bahiaid" +
                " JOIN Naves as n on n.IdNave = a.idtblnave " +
                " left join Cadenas co on co.IdCadena=A.idcadena_origen" +
                " WHERE  FechaEntradaAlmacen BETWEEN '" + fechaInicioEntradas + "' AND '" + fechaTerminoEntradas + "'"



        Else
            consulta = " SELECT CASE WHEN k.Tipo = 'PAR'  THEN 'P' ELSE  CASE WHEN k.Tipo = 'ATADO'  THEN 'A' ELSE 'E' END END AS 'Tipo'," +
            " CASE WHEN A.Status = 1 THEN 'ALMACÉN' ELSE  CASE WHEN a.STATUS = 2 OR A.Status = '' THEN  'EXTERNO' ELSE CASE WHEN a.STATUS = 0 THEN 'EN PROCESO' END END END AS 'Proceso', A.Disponible AS 'D'," +
            " A.Asignado AS 'A',A.Calidad AS 'C',A.Bloqueado AS 'B',A.Reproceso AS 'R',A.Proyectado AS 'P', a.ID_Par AS 'Par', A.ID_Docena AS 'Atado',A.idtblnave AS 'Id_Nave', l.Nave as 'Nave', " +
            " A.FechaEntradaAlmacen AS 'Fecha Entrada(Con hr.)', isnull(idsalidanave,0) AS 'Folio Salida', CONVERT (varchar(10),A.FechaEntradaAlmacen,103) AS 'Fecha Entrada'," +
            " B.FechaPrograma AS 'Programa', D.IdModelo AS 'Modelo',D.marca as 'Marca', D.Coleccion AS 'Colección'," +
            " E.Piel AS 'Piel',F.Nombre AS 'Color',G.Talla AS 'Corrida',a.Calce AS 'Talla', I.nombre AS 'Tienda',H.nombre AS 'Cliente'," +
            " J.Iniciales AS 'Agte',a.idtbllote AS 'Lote',a.idtblPedido AS 'Pedido',C.Entrega AS 'Fecha Entrega',  C.Orden AS 'Orden de Compra'" +
            " ,	a.pedidoid_origen as 'Pedido Origen',co.nombre as 'Cliente Origen', c.EntregaCliente as 'Entrega Cliente'" +
            " FROM tmpdocenaspares AS A " +
            " JOIN Programas AS B ON a.idtblPrograma = b.IdPrograma " +
            " LEFT JOIN Pedidos AS C ON C.IdPedido = a.idtblPedido " +
            " LEFT JOIN vEstilos AS D ON D.IdCodigo = a.idtblProducto " +
            " LEFT JOIN Pieles AS E ON E.IdPiel = D.IdPiel " +
            " LEFT JOIN Colores AS F ON F.IdColor = d.IdColor " +
            " LEFT JOIN Tallas AS G ON G.IdTalla = a.idtblTalla " +
            " LEFT JOIN vcadenas AS H ON H.IdCadena = a.idtblcte " +
            " LEFT JOIN Distribuciones AS I ON I.IdDistribucion = a.idtblTienda " +
            " LEFT JOIN Agentes AS J ON J.IdAgente = C.IdAgente" +
            " LEFT JOIN vParesUbicacionesErrores AS K ON K.ubpa_codigoatado = A.ID_Docena AND  K.ubpa_codigopar = A.ID_Par" +
            " JOIN naves as l on l.IdNave = a.idtblnave" +
            " left join Cadenas co on co.IdCadena=A.idcadena_origen" +
            " WHERE FechaEntradaAlmacen BETWEEN '" + fechaInicioEntradas + "' AND '" + fechaTerminoEntradas + "'"
        End If


        ''NAVES
        If lNave <> String.Empty Or lNave <> "" Then ''"" Then
            If bY_O = True Then
                consulta += " AND A.idtblnave IN (" + lNave + ")"
            Else
                consulta += " OR A.idtblnave IN (" + lNave + ")"
            End If
        End If


        ''LOTES
        If lLotes <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtbllote in (" + lLotes + ")"
            Else
                consulta += " OR  A.idtbllote in (" + lLotes + ")"
            End If
        End If

        ''ATADOS
        If lAtados <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.ID_Docena in (" + lAtados + ")"
            Else
                consulta += " OR A.ID_Docena in (" + lAtados + ")"
            End If
        End If

        ''PEDIDOS

        If EsPedidoActual = True Then
            If lPedidos <> String.Empty Then
                If bY_O = True Then
                    consulta += " AND A.idtblPedido IN (" + lPedidos + ")"
                Else
                    consulta += " OR A.idtblPedido IN (" + lPedidos + ")"
                End If
            End If
        Else
            If lPedidos <> String.Empty Then
                If bY_O = True Then
                    consulta += " AND a.pedidoid_origen IN (" + lPedidos + ")"
                Else
                    consulta += " OR a.pedidoid_origen IN (" + lPedidos + ")"
                End If
            End If
        End If


        ''PRODUCTOS
        If lProductos <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblProducto IN (" + lProductos + ")"
            Else
                consulta += " OR A.idtblProducto IN (" + lProductos + ")"
            End If
        End If


        ''CLIENTES
        If EsClienteActual = True Then
            If lClientes <> String.Empty Then
                If bY_O = True Then
                    consulta += " AND A.idtblcte IN (" + lClientes + ")"
                Else
                    consulta += " OR A.idtblcte IN (" + lClientes + ")"
                End If
            End If
        Else
            If lClientes <> String.Empty Then
                If bY_O = True Then
                    consulta += " AND A.idcadena_origen IN (" + lClientes + ")"
                Else
                    consulta += " OR A.idcadena_origen IN (" + lClientes + ")"
                End If
            End If
        End If


        ''CORRIDA
        If lCorridas <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblTalla IN (" + lCorridas + ")"
            Else
                consulta += " OR A.idtblTalla IN (" + lCorridas + ")"
            End If
        End If

        ''TIENDAS
        If lTiendas <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblTienda IN (" + lTiendas + ")"
            Else
                consulta += " OR A.idtblTienda IN (" + lTiendas + ")"
            End If
        End If

        ''TALLAS
        If lTallas <> String.Empty Then
            If bY_O = True Then
                consulta += " AND a.Calce IN (" + lTallas + ")"
            Else
                consulta += " OR a.Calce IN (" + lTallas + ")"
            End If
        End If

        ''FECHA PROGRAMADA
        If filtroFechaPrograma = True Then
            If bY_O = True Then
                consulta += " AND  B.FechaPrograma  BETWEEN '" + fechaInicioProgramas + "' AND '" + fechaTerminoProgramas + "'"
            Else
                consulta += " OR  B.FechaPrograma  BETWEEN '" + fechaInicioProgramas + "' AND '" + fechaTerminoProgramas + "'"
            End If
        End If

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    Public Function ConsultaEntradasAlmacen(ByVal Filtros As Entidades.EntradasAlmacen)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Filtro",
            .Value = Filtros.Filtro
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Tallas",
            .Value = Filtros.Tallas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Lotes",
            .Value = Filtros.Lotes
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Atados",
            .Value = Filtros.Atados
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Pedidos",
            .Value = Filtros.Pedidos
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Productos",
            .Value = Filtros.Productos
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Clientes",
            .Value = Filtros.Clientes
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Corridas",
            .Value = Filtros.Corridas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Tiendas",
            .Value = Filtros.Tiendas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Nave",
            .Value = Filtros.Nave
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@fechaInicioEntradas",
            .Value = Filtros.FechaInicioEntradas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@fechaTerminoEntradas",
            .Value = Filtros.FechaTerminoEntradas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@fechaInicioProgramas",
            .Value = Filtros.FechaInicioProgramas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@fechaTerminoProgramas",
            .Value = Filtros.FechaTerminoProgramas
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Ubicacion",
            .Value = Filtros.Ubicacion
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@filtroFechaPrograma",
            .Value = Filtros.FiltroFechaPrograma
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@EsPedidoActual",
            .Value = Filtros.EsPedidoActual
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@EsClienteActual",
            .Value = Filtros.EsClienteActual
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@ComercializadoraID",
            .Value = Filtros.ComercializadoraId
        })


        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_Entradas_ConsultaEntradasAlmacen_v2_Direccion]", listaParametros)
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Ubicacion_Y_N"></param>
    ''' <param name="lTallas"></param>
    ''' <param name="lLotes"></param>
    ''' <param name="lAtados"></param>
    ''' <param name="lPedidos"></param>
    ''' <param name="lProductos"></param>
    ''' <param name="lClientes"></param>
    ''' <param name="lCorridas"></param>
    ''' <param name="lTiendas"></param>
    ''' <param name="lNave"></param>
    ''' <param name="fechaInicioEntradas"></param>
    ''' <param name="fechaTerminoEntradas"></param>
    ''' <param name="fechaInicioProgramas"></param>
    ''' <param name="fechaTerminoProgramas"></param>
    ''' <param name="bY_O"></param>
    ''' <param name="filtroFechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaDetallesProductos(ByVal Ubicacion_Y_N As Boolean, ByVal lTallas As String, ByVal lLotes As String, ByVal lAtados As String, ByVal lPedidos As String, ByVal lProductos As String, ByVal lClientes As String,
                                            ByVal lCorridas As String, ByVal lTiendas As String, ByVal lNave As String, ByVal fechaInicioEntradas As String, ByVal fechaTerminoEntradas As String,
                                            ByVal fechaInicioProgramas As String, ByVal fechaTerminoProgramas As String, ByVal bY_O As Boolean, ByVal filtroFechaPrograma As Boolean, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty

        If Ubicacion_Y_N = True Then
            consulta = " select D.Marca,D.Coleccion as Colección, D.IdModelo as 'Modelo', G.Talla as 'Corrida', D.ColorCorto as 'Color Corto', sum(a.pares) as Pares  from tmpDocenasPares  as a" +
                " FROM Almacen.vTmpDocenasPares_Completo AS A" +
                " JOIN Programas AS B ON a.idtblPrograma = b.IdPrograma" +
                " LEFT JOIN Pedidos AS C ON C.IdPedido = a.idtblPedido" +
                " LEFT JOIN vEstilos AS D ON D.IdCodigo = a.idtblProducto" +
                " LEFT JOIN Pieles AS E ON E.IdPiel = D.IdPiel" +
                " LEFT JOIN Colores AS F ON F.IdColor = d.IdColor" +
                " LEFT JOIN Tallas AS G ON G.IdTalla = a.idtblTalla" +
                " LEFT JOIN vcadenas AS H ON H.IdCadena = a.idtblcte" +
                " LEFT JOIN Distribuciones AS I ON I.IdDistribucion = a.idtblTienda " +
                " LEFT JOIN Agentes AS J ON J.IdAgente = C.IdAgente" +
                " LEFT JOIN vParesUbicacionesErrores AS K ON K.ubpa_codigoatado = A.ID_Docena AND  K.ubpa_codigopar = A.ID_Par" +
                " LEFT JOIN Almacen.Estiba AS L ON L.esti_estibaid = K.ubpa_estibaid" +
                " LEFT JOIN Almacen.Bahia AS M ON  M.bahi_bahiaid = L.esti_bahiaid" +
                " JOIN Naves as n on n.IdNave = a.idtblnave " +
                " WHERE Status = 1 and comercializadoraid = " & ComercializadoraID.ToString & "   AND FechaEntradaAlmacen BETWEEN '" + fechaInicioEntradas + "' AND '" + fechaTerminoEntradas + "'"
        Else
            consulta = " select D.Marca,D.Coleccion as Colección, D.IdModelo as 'Modelo', G.Talla as 'Corrida', D.ColorCorto as 'Color Corto', sum(a.pares) as Pares  from Almacen.vTmpDocenasPares_Completo  as a " +
            " JOIN Programas AS B ON a.idtblPrograma = b.IdPrograma " +
            " LEFT JOIN Pedidos AS C ON C.IdPedido = a.idtblPedido " +
            " LEFT JOIN vEstilos AS D ON D.IdCodigo = a.idtblProducto " +
            " LEFT JOIN Pieles AS E ON E.IdPiel = D.IdPiel " +
            " LEFT JOIN Colores AS F ON F.IdColor = d.IdColor " +
            " LEFT JOIN Tallas AS G ON G.IdTalla = a.idtblTalla " +
            " LEFT JOIN vcadenas AS H ON H.IdCadena = a.idtblcte " +
            " LEFT JOIN Distribuciones AS I ON I.IdDistribucion = a.idtblTienda " +
            " LEFT JOIN Agentes AS J ON J.IdAgente = C.IdAgente" +
            " LEFT JOIN vParesUbicacionesErrores AS K ON K.ubpa_codigoatado = A.ID_Docena AND  K.ubpa_codigopar = A.ID_Par" +
            " JOIN naves as l on l.IdNave = a.idtblnave" +
            " WHERE  comercializadoraid = " & ComercializadoraID.ToString & "  and FechaEntradaAlmacen BETWEEN '" + fechaInicioEntradas + "' AND '" + fechaTerminoEntradas + "'"
        End If


        ''NAVES
        If lNave <> String.Empty Or lNave <> "" Then ''"" Then
            If bY_O = True Then
                consulta += " AND A.idtblnave IN (" + lNave + ")"
            Else
                consulta += " OR A.idtblnave IN (" + lNave + ")"
            End If
        End If


        ''LOTES
        If lLotes <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtbllote in (" + lLotes + ")"
            Else
                consulta += " OR  A.idtbllote in (" + lLotes + ")"
            End If
        End If

        ''ATADOS
        If lAtados <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.ID_Docena in (" + lAtados + ")"
            Else
                consulta += " OR A.ID_Docena in (" + lAtados + ")"
            End If
        End If

        ''PEDIDOS
        If lPedidos <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblPedido IN (" + lPedidos + ")"
            Else
                consulta += " OR A.idtblPedido IN (" + lPedidos + ")"
            End If
        End If

        ''PRODUCTOS
        If lProductos <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblProducto IN (" + lProductos + ")"
            Else
                consulta += " OR A.idtblProducto IN (" + lProductos + ")"
            End If
        End If


        ''CLIENTES
        If lClientes <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblcte IN (" + lClientes + ")"
            Else
                consulta += " OR A.idtblcte IN (" + lClientes + ")"
            End If
        End If

        ''CORRIDA
        If lCorridas <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblTalla IN (" + lCorridas + ")"
            Else
                consulta += " OR A.idtblTalla IN (" + lCorridas + ")"
            End If
        End If

        ''TIENDAS
        If lTiendas <> String.Empty Then
            If bY_O = True Then
                consulta += " AND A.idtblTienda IN (" + lTiendas + ")"
            Else
                consulta += " OR A.idtblTienda IN (" + lTiendas + ")"
            End If
        End If

        ''TALLAS
        If lTallas <> String.Empty Then
            If bY_O = True Then
                consulta += " AND a.Calce IN (" + lTallas + ")"
            Else
                consulta += " OR a.Calce IN (" + lTallas + ")"
            End If
        End If

        ''FECHA PROGRAMADA
        If filtroFechaPrograma = True Then
            If bY_O = True Then
                consulta += " AND  B.FechaPrograma  BETWEEN '" + fechaInicioProgramas + "' AND '" + fechaTerminoProgramas + "'"
            Else
                consulta += " OR  B.FechaPrograma  BETWEEN '" + fechaInicioProgramas + "' AND '" + fechaTerminoProgramas + "'"
            End If
        End If

        consulta += " group BY d.marca, d.Coleccion, d.IdModelo, g.Talla, d.ColorCorto"

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="lNave"></param>
    ''' <param name="fechaInicioEntradas"></param>
    ''' <param name="fechaTerminoEntradas"></param>
    ''' <param name="bY_O"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function RecuperarListaDetallesProductosConImporte(ByVal lNave As String, ByVal fechaInicioEntradas As String,
                                                              ByVal fechaTerminoEntradas As String, ByVal bY_O As Boolean, ByVal Coleccion As Boolean,
                                                              ByVal Modelo As Boolean, ByVal Talla As Boolean, ByVal Color As Boolean, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = String.Empty


        'consulta = " select PRECIOS.Nave"
        'If Coleccion = True Then
        '    consulta += " , PRECIOS.Colección"
        'End If
        'If Modelo = True Then
        '    consulta += " , PRECIOS.Modelo"
        'End If
        'If Talla = True Then
        '    consulta += " , PRECIOS.Corrida"
        'End If
        'If Color = True Then
        '    consulta += " , PRECIOS.Color"
        'End If
        'consulta += " ,SUM(PRECIOS.Pares) as 'Pares', " +
        '    "ROUND( ROUND(SUM(PRECIOS.Precio), 2) / ROUND(SUM(PRECIOS.Pares), 2), 2) AS Precio, " +
        '    " ROUND(SUM(PRECIOS.Precio),2) AS Total  " +
        '    " from (" +
        '    " SELECT  l.Nave AS 'Nave' , D.Coleccion AS 'Colección' , D.IdModelo AS 'Modelo' , G.Talla AS 'Corrida' , D.ColorCorto AS 'Color', a.Pares AS 'Pares', " +
        '    " isnull(b.Precio, (select top 1 p.Precio from precios p where p.IdCodigo=a.idtblProducto and p.IdTalla=a.idtblTalla and p.StPrc='A')) as Precio " +
        '    " FROM tmpDocenasPares AS a" +
        '    " LEFT JOIN precios AS b ON a.idtblProducto = b.IdCodigo AND a.idtblTalla = b.IdTalla and b.idcatLista = a.idtblprecios" +
        '    " LEFT JOIN vEstilos AS D ON D.IdCodigo = a.idtblProducto" +
        '    " LEFT JOIN Tallas AS G ON G.IdTalla = a.idtblTalla" +
        '    " JOIN naves AS l ON l.IdNave = a.idtblnave" +
        '    " WHERE FechaEntradaAlmacen BETWEEN '" + fechaInicioEntradas + "' AND '" + fechaTerminoEntradas + "' "

        '    ''NAVES
        'If lNave <> String.Empty Or lNave <> "" Then ''"" Then
        '    If bY_O = True Then
        '        consulta += " AND A.idtblnave IN (" + lNave + ") ) as PRECIOS"
        '    Else
        '        consulta += " OR A.idtblnave IN (" + lNave + ") ) as PRECIOS"
        '    End If
        'Else
        '    consulta += "  ) as PRECIOS"
        'End If

        'consulta += " GROUP BY PRECIOS.Nave "

        'If Coleccion = True Then
        '    consulta += " ,PRECIOS.Colección"
        '    End If
        'If Modelo = True Then
        '    consulta += " , PRECIOS.Modelo "
        '    End If
        'If Talla = True Then
        '    consulta += " ,PRECIOS.Corrida "
        '    End If
        'If Color = True Then
        '    consulta += " ,PRECIOS.Color "
        '    End If

        'consulta += " order BY PRECIOS.Nave "

        'If Coleccion = True Then
        '    consulta += " ,PRECIOS.Colección"
        'End If
        'If Modelo = True Then
        '    consulta += " , PRECIOS.Modelo "
        'End If
        'If Talla = True Then
        '    consulta += " ,PRECIOS.Corrida "
        'End If
        'If Color = True Then
        '    consulta += " ,PRECIOS.Color "
        'End If


        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@coleccion"
        parametro.Value = Coleccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@modelo"
        parametro.Value = Modelo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@corrida"
        parametro.Value = Talla
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@color"
        parametro.Value = Color
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nave"
        If Not lNave Is Nothing Then
            parametro.Value = lNave
        Else
            parametro.Value = DBNull.Value
        End If


        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@YO"
        parametro.Value = bY_O
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicioEntradas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFin"
        parametro.Value = fechaTerminoEntradas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@comercializadoraId"
        parametro.Value = ComercializadoraID
        listaParametros.Add(parametro)



        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_ConsultaPrecioProdctoAlmacenSAY_v2", listaParametros)
        'Return objPersistencia.EjecutaConsulta(consulta)
    End Function



    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES RECIBIDOS EN UUNA NAVE EN ESPECIFICO EN UN RANGO DE FECHAS.
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA QUE SE BUSCARAN LAS ENTRADAS</param>
    ''' <returns>RESULTADO DE LA EJECUCIÓN DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Recibidos(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select snde_lote AS 'Lote', b.Marca+' '+ b.Coleccion as 'Colección', b.IdModelo as'Estilo', b.Color as 'Color'" +
            ", a.snde_Corrida as 'Corrida'" +
            ", sum(a.snde_entregado)as 'Pares', count (DISTINCT snde_codigoatado)as 'Atados', count(DISTINCT (snde_lote+snde_año))as 'lotes',sum(snde_embarcado) as 'Embarcado', sum(snde_entregado) as 'Recibido'" +
            ", CONVERT(char(10), (SELECT DISTINCT x.Fecha FROM LotesDocenas AS x WHERE x.Lote = a.snde_lote AND x.Año = a.snde_año AND x.Nave = a.snde_naveid), 103) AS 'Programa'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " from Almacen.SalidaNavesDetalles as A"
        Else
            consulta += " from Almacen.SalidaNavesDetalles_" + IdNave.ToString + " as A"
        End If
        consulta += " join vEstilos as B on b.IdCodigo = A.snde_idproducto" +
            " join Almacen.SalidaNaves on sana_salidanavesid = a.snde_salidanavesid" +
            " where  A.snde_entregado = 1 and A.snde_devuelto = 0 and A.snde_embarcado = 1  and sana_fechaentrada BETWEEN '" + Fecha_Inicio.ToString + "' and '" + Fecha_Fin.ToString + "'  and A.snde_naveid = " + IdNave.ToString +
            " GROUP by snde_lote, snde_año, snde_naveid, marca,B.Coleccion,B.IdModelo,B.Color, a.snde_Corrida"

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES NO EMBARCADOS ESCANEADOS DURANTE EL PROCESO DE ENTRADA DE LOTES A ALMACÉN DE UNA NAVE EN ESPECIFICO
    ''' DENTRO DE UN RANGO DE FECHAS
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA CUAL SE BUSCARAN LAS ENTRADAS</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_No_Embarcados(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "SELECT * FROM (SELECT snde_lote AS 'Lote', b.Marca + ' ' + b.Coleccion AS 'Colección', b.IdModelo AS 'Estilo', b.Color AS 'Color'," +
            " snde_Corrida AS 'Corrida', COUNT(DISTINCT a.snde_salidanavesdetallesid) AS 'Pares', SUM(snde_embarcado) AS 'Embarcado'," +
            " (SELECT COUNT(DISTINCT (CAST(a1.snde_salidanavesdetallesid AS varchar(10)) + '-' + CAST(A1.snde_devuelto AS varchar(1))))" +
            " FROM Almacen.SalidaNavesDetalles AS a1 WHERE a1.snde_resultadoid_par_entrada IS NOT NULL and A1.snde_devuelto = 1 AND a1.snde_lote = a.snde_lote) AS 'Devuelto'," +
            " CONVERT(char(10), (SELECT DISTINCT x.Fecha FROM LotesDocenas AS x WHERE x.Lote = a.snde_lote AND x.Año = a.snde_año AND x.Nave = a.snde_naveid), 103) AS 'Programa'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " FROM Almacen.SalidaNavesDetalles AS A"
        Else
            consulta += " FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + " AS A"
        End If
        consulta += " JOIN vEstilos AS B ON b.IdCodigo = A.snde_idproducto" +
            " JOIN Almacen.SalidaNaves ON sana_salidanavesid = a.snde_salidanavesid" +
            " WHERE A.snde_embarcado = 0" +
            " AND sana_fechaentrada BETWEEN '" + Fecha_Inicio + "' AND '" + Fecha_Fin + "' AND A.snde_naveid = " + IdNave.ToString +
            " GROUP BY	snde_lote, snde_año, snde_naveid, marca, B.Coleccion, B.IdModelo, B.Color, snde_Corrida) AS Consulta2 ORDER BY Lote ASC"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL TOTAL DE PARES QUE SE EMBARCARON PERO NO SE RECIBIERON EN EL PROCESO DE ENTRADA DE LOTES DE UNA NAVE EN ESPECIFICO DENTRO DE UN 
    ''' RANGO DE FECHAS
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE EN LA QUE SE REALIZARA LA BUSQUEDA</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Totales_Faltantes(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "SELECT snde_lote AS 'Lote',b.Marca + ' ' + b.Coleccion AS 'Colección',b.IdModelo AS 'Estilo',b.Color AS 'Color'," +
            " snde_Corrida AS 'Corrida', COUNT(*) AS 'Pares',SUM(snde_embarcado) AS 'Embarcado',SUM(snde_entregado) AS 'Recibido',CONVERT(char(10), " +
            " (SELECT DISTINCT x.Fecha FROM LotesDocenas AS x WHERE x.Lote = a.snde_lote AND x.Año = a.snde_año AND x.Nave = a.snde_naveid), 103) AS 'Programa'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += " FROM Almacen.SalidaNavesDetalles AS A "
        Else
            consulta += " FROM Almacen.SalidaNavesDetalles_" + IdNave.ToString + " AS A "
        End If
        consulta += "JOIN vEstilos AS B ON b.IdCodigo = A.snde_idproducto JOIN Almacen.SalidaNaves ON sana_salidanavesid = a.snde_salidanavesid" +
        " WHERE A.snde_entregado = 0 AND A.snde_embarcado = 1 AND sana_fechaentrada BETWEEN '" + Fecha_Inicio + "' and '" + Fecha_Fin + "'  and A.snde_naveid = " + IdNave.ToString +
        " GROUP BY snde_lote,snde_año,snde_naveid,marca,B.Coleccion,B.IdModelo,B.Color,snde_Corrida"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL NOMBRE DEL OPERADOR DEACUERDO AL ID DE USUARIO QUE ESTA GUARDADO EN EL ULTIMO REGISTRO GUARDADO EN LA TABLA SALIDANAVES DE LA BASE DE DATOS DEL SISY PARA UNA NAVE EN ESPECIFICO
    ''' </summary>
    ''' <param name="Fecha_Inicio">FECHA DE INICIO DE LA BUSQUEDA</param>
    ''' <param name="Fecha_Fin">FECHA DE FIN DE LA BUSQUEDA</param>
    ''' <param name="IdNave">ID DE LA NAVE DE LA BUSQUEDA</param>
    ''' <returns>RESULTADO DE LA EJECUCION D ELA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Recuperar_Nombre_Operador_ReporteEntradas(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim objPersistenciaSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        If objPersistencia.Servidor = objPersistenciaSAY.Servidor Then
            consulta = "Select top 1 a.user_nombrereal as 'Operador', sana_operadorid as 'Id_Operador' from almacen.salidanaves " +
                " join [" + objPersistenciaSAY.NombreDB + "].Framework.Usuarios as a on a.user_usuarioid = sana_operadorid " +
                " where sana_fechaentrada  BETWEEN  '" + Fecha_Inicio + "' and '" + Fecha_Fin + "'" +
                " and sana_naveid =  " + IdNave.ToString + " order by sana_fechaentrada DESC"
            Return objPersistencia.EjecutaConsulta(consulta)
        Else
            consulta = "Select top 1 a.user_nombrereal as 'Operador', sana_operadorid as 'Id_Operador' from almacen.salidanaves " +
                " join [" + objPersistenciaSAY.Servidor + "].[" + objPersistenciaSAY.NombreDB + "].Framework.Usuarios as a on a.user_usuarioid = sana_operadorid " +
                " where sana_fechaentrada  BETWEEN  '" + Fecha_Inicio + "' and '" + Fecha_Fin + "'" +
                " and sana_naveid =  " + IdNave.ToString + " order by sana_fechaentrada DESC"
            Return objPersistencia.EjecutaConsulta(consulta)
        End If
    End Function

    ''' <summary>
    ''' CONSULTA TODA LA INFORMACION DE LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function PoblarGridConfiguracionDeValidaciones() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select ccve_configuracionid as 'IDCONFIGURACION', ccve_naveid as 'IDNAVE',  b.Nave as 'NAVE'," +
            " a.ccve_cadenaid AS 'IDCLIENTE', c.nombre as 'CLIENTE'," +
            " case when a.ccve_validarsalidaporpar = 'true' THEN 'SI' ELSE 'NO' END AS 'VALIDAR SALIDA'," +
            " case when a.ccve_validarentradaporpar = 'true' THEN 'SI' ELSE 'NO' END AS 'VALIDAR ENTRADA'" +
            " from almacen.ConfiguracionClienteValidacionEmbarque as a " +
            " join naves as b on b.IdNave = a.ccve_naveid" +
            " join Cadenas AS C ON C.IdCadena = A.ccve_cadenaid ORDER BY NAVE, CLIENTE"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' CONSULTA LAS CADENAS ACTIIVAS EN LA TABLA CADENAS
    ''' </summary>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaDeCadenasActivas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select IdCadena, nombre, Activo from  Cadenas where Activo = 'S' ORDER BY nombre"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' REALIZA EL PROCESO PARA ACTUALIZAR LOSDATOS DE LA TABLA ALMACEN.CONFIGURACIONVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdConfiguracionEmbarque">ID DE EL REGISTRO QUE SE ACTUALIZARA</param>
    ''' <param name="Entrada">VALOR BOOLEANO PARA VALIDAR ENTRADAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <param name="Salida">VALOR BOOLEANO PARA VALIDAR SALIDAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <remarks></remarks>
    Public Sub EditarRegistroConfiguracionDeEmbarques(ByVal IdConfiguracionEmbarque As Integer, ByVal Entrada As Boolean, ByVal Salida As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        If Salida Then
            consulta = "update almacen.ConfiguracionClienteValidacionEmbarque " +
            " set ccve_validarsalidaporpar = '" + Salida.ToString + "', " +
            " ccve_validarentradaporpar = '" + Entrada.ToString + "'," +
            " ccve_activo=1" +
            " where ccve_configuracionid = " + IdConfiguracionEmbarque.ToString
        Else
            consulta = "update almacen.ConfiguracionClienteValidacionEmbarque " +
            " set ccve_validarsalidaporpar = '" + Salida.ToString + "', " +
            " ccve_validarentradaporpar = '" + Entrada.ToString + "'" +
            " where ccve_configuracionid = " + IdConfiguracionEmbarque.ToString
        End If


        objPersistencia.EjecutaConsulta(consulta)
    End Sub
    ''' <summary>
    ''' INACTIVA UN REGISTRO EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdRegistro">ID DEL REGISTRO A ACTUALIZAR</param>
    ''' <remarks></remarks>
    Public Sub DesactivarRegistro(ByVal IdRegistro As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "UPDATE ALMACEN.ConfiguracionClienteValidacionEmbarque SET ccve_activo = 'FALSE',ccve_validarsalidaporpar='FALSE' WHERE ccve_configuracionid =  " + IdRegistro.ToString
        objPersistencia.EjecutaConsulta(consulta)
    End Sub
    ''' <summary>
    ''' INSERTA REGISTROS EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE
    ''' </summary>
    ''' <param name="IdCliente">ID CLIENTE QUE SE VALIDARA</param>
    ''' <param name="Entrada">VALOR BOOLEANO PARA VALIDAR ENTRADAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <param name="Salida">VALOR BOOLEANO PARA VALIDAR SALIDAS (TRUE PARA VALIDAR, FALSE PARA NO VALIDAR)</param>
    ''' <param name="NaveId">ID DE LA NAVE EN LA QUE SE VALDIARA EL CLIENTE</param>
    ''' <remarks></remarks>
    Public Sub AgregarRegistroConfiguracionDeEmbarques(ByVal IdCliente As Integer, ByVal Entrada As Boolean, ByVal Salida As Boolean, ByVal NaveId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "INSERT INTO almacen.ConfiguracionClienteValidacionEmbarque(ccve_cadenaid, ccve_validarsalidaporpar,ccve_validarentradaporpar,ccve_naveid, ccve_activo)" +
            " values(" + IdCliente.ToString + ",'" + Salida.ToString + "','" + Entrada.ToString + "'," + NaveId.ToString + ", 1)"
        objPersistencia.EjecutaConsulta(consulta)
    End Sub
    ''' <summary>
    ''' VALIDA SI EXISTE ALGUN REGISTRO DE UN CLIENTE ASIGNADO A UNA NAVE
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A BUSCAR</param>
    ''' <param name="IdCliente">ID DE LA NAVE A BUSCAR</param>
    ''' <returns>RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ValidarRegistrosExistentes(ByVal IdNave As Integer, ByVal IdCliente As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "select ccve_configuracionid as 'ID_CONFIGURACION',ccve_naveid as 'ID_NAVE', ccve_cadenaid AS 'ID_CLIENTE', ccve_activo AS 'ACTIVO' " +
            " from almacen.ConfiguracionClienteValidacionEmbarque WHERE ccve_naveid = " + IdNave.ToString + " AND ccve_cadenaid =" + IdCliente.ToString
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    ''' <summary>
    ''' ACTIVA UN REGISTRO EN LA TABLA ALMACEN.CONFIGURACIONCLIENTEVALIDACIONEMBARQUE Y ACTUALIZA LAS VALIDACIONES DE ENTRADA Y SALIDA PAR POR PAR
    ''' </summary>
    ''' <param name="IdRegistro">ID DEL REGISTRO A ACTUALIZAR</param>
    ''' <param name="Entrada">VALOR DE LA VALIDACION DE ENTRADA</param>
    ''' <param name="Salida">VALOR DE LA VALIDACIOND E SALIDA</param>
    ''' <remarks></remarks>
    Public Sub ActivarRegistroDeValidacion(ByVal IdRegistro As Integer, ByVal Entrada As Boolean, ByVal Salida As Boolean)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "update almacen.ConfiguracionClienteValidacionEmbarque set ccve_activo = 'TRUE', ccve_validarentradaporpar = '" + Entrada.ToString + "'," +
            " ccve_validarsalidaporpar = '" + Salida.ToString + "' WHERE ccve_configuracionid = " + IdRegistro.ToString
        objPersistencia.EjecutaConsulta(consulta)
    End Sub


    ''' <summary>
    ''' CONSULTA LOS CARRITOS LEIDOS EN UNA ENTRADA DE LOTES
    ''' </summary>
    ''' <param name="IdSalidaNaves"> ID DE LA SALIDA DE NAVES EN LA QUE SE BUSCARAN LOS CARRITOS</param>
    ''' <remarks></remarks>
    Public Function PoblarDetalleCarritos(ByVal IdSalidaNaves As Integer, ByVal IdNave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String
        consulta = "SELECT DISTINCT  snde_idcarrito AS 'ID_Plataforma', COUNT(DISTINCT snde_codigoatado) AS 'No. de Atados', COUNT(snde_codigopar) AS 'No. de Pares'"
        If IdNave <> 1 And IdNave <> 2 And IdNave <> 3 And IdNave <> 7 And IdNave <> 11 And IdNave <> 15 And IdNave <> 10 And IdNave <> 18 And IdNave <> 5 And IdNave <> 14 And IdNave <> 60 Then
            consulta += "  FROM ALMACEN.SalidaNavesDetalles "
        Else
            consulta += "  FROM ALMACEN.SalidaNavesDetalles_" + IdNave.ToString
        End If
        consulta += " WHERE snde_salidanavesid = " + IdSalidaNaves.ToString + " and snde_idcarrito is not null" +
            " GROUP BY snde_idcarrito ORDER BY snde_idcarrito"
        Return objPersistencia.EjecutaConsulta(consulta)
    End Function


    Public Function AgregarAtadosDelLote_SalidaNavesDetalle_Para_entrada(ByVal IdSalidaNave As Integer, ByVal Id_Nave As Integer, ByVal Año As Integer,
                                                                         ByVal Lote As Integer, ByVal Proceso As String, ByVal TipoCodigo As String,
                                                                         ByVal Tipo_Nave_Maquila_o_Interna As Boolean, ByVal Atado_Incluido_SalidaNave_en_Curso As Boolean,
                                                                         ByVal ResultadoLoteCompleto As Boolean)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdSalidaNAve"
        parametro.Value = IdSalidaNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = Id_Nave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Lote"
        parametro.Value = Lote
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Proceso"
        parametro.Value = Proceso
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoCodigo"
        parametro.Value = TipoCodigo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoNave"
        parametro.Value = Tipo_Nave_Maquila_o_Interna
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@AtadoIncluidoEnSalida"
        parametro.Value = Atado_Incluido_SalidaNave_en_Curso
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@LoteTerminado"
        parametro.Value = ResultadoLoteCompleto
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_Agregar_Atados_De_Lote_A_SalidaNavesDetalles_en_Entrada_PB", listaparametros)
    End Function



    'Public Sub Agregar_Atados_De_Faltantes_a_Lotes_incompletos_en_Entrada_De_Nave(ByVal IdSalidaNave As Integer, ByVal TipoNave As Boolean)
    '    Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
    '    Dim listaparametros As New List(Of SqlParameter)

    '    Dim parametro As New SqlParameter
    '    parametro.ParameterName = "@Tipo_Nave"
    '    parametro.Value = TipoNave
    '    listaparametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@IdSalidaNave"
    '    parametro.Value = IdSalidaNave
    '    listaparametros.Add(parametro)

    '    objPersistencia.EjecutarConsultaSP("Almacen.SP_Agregar_Atados_No_Agregados_A_La_Entrada_de_Nave", listaparametros)

    'End Sub



    'Public Function ValidarParesCompletos_DeLotesCorrectos(ByVal IdSalidaNave As Integer, ByVal Proceso As String) As DataTable
    '    Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String

    '    If Proceso = "SALIDA" Then
    '        consulta = "select snde_codigoatado, snde_codigopar, snde_lote, snde_año from almacen.SalidaNavesDetalles where snde_salidanavesid = " +
    '                    IdSalidaNave.ToString + "  and snde_resultadoid_atado = 1 and snde_resultadoid_par = null"
    '    Else
    '        consulta = "select snde_codigoatado, snde_codigopar, snde_lote, snde_año from almacen.SalidaNavesDetalles where snde_salidanavesid = " +
    '                    IdSalidaNave.ToString + "  and snde_resultadoid_atado_entrada = 1 and snde_resultadoid_par_entrada = null"
    '    End If

    '    Return objPersistencia.EjecutaConsulta(consulta)
    'End Function







    Public Sub RegistrarBitacora(ByVal ConfiguracionId As Integer, ByVal UsuarioId As Integer, ByVal ValidaEntradaAnterior As Boolean, ByVal ValidaSalidaAnterior As Boolean, ByVal ValidaEntradaNuevo As Boolean, ByVal ValidaSalidaNuevo As Boolean)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@ConfiguracionID"
            parametro.Value = ConfiguracionId
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ValidaEntradaAnterior"
            parametro.Value = ValidaEntradaAnterior
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ValidaSalidaAnterior"
            parametro.Value = ValidaSalidaAnterior
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ValidaEntradaNuevo"
            parametro.Value = ValidaEntradaNuevo
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ValidaSalidaNuevo"
            parametro.Value = ValidaSalidaNuevo
            listaparametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ConfiguracionEmbarque_Bitacora]", listaparametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Sub

End Class




