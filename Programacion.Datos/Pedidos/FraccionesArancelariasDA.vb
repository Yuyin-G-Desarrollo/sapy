Public Class FraccionesArancelariasDA


    ''' <summary>
    ''' CONSULTA TODOS LOS REGISTROS (ACTIVOS O INACTIVOS) DE LA TABLA DE FRACCIONES ARANCELARIAS DEL SAY
    ''' </summary>
    ''' <param name="Activo">VARIABLE DEL TIPO BOLEANO, 1 = CONSULTAR REGISTROS ACTIVOS, 0 = CONSULTAR REGISTROS INACTIVOS</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCIÓN DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Catalogo_FraccionesArancelarias(ByVal Activo As Boolean) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = " select frar_fraccionarancelariaid AS 'Id', " +
                                " frar_codigo as 'Código', " +
                                " frar_nombre as 'Fracción Arancelaria', " +
                                " case when frar_activo = 1 then 'SI' ELSE 'NO' end AS 'Activo', " +
                                " case when frar_fechamodificacion is not null" +
                                "	then frar_fechamodificacion " +
                                "	else frar_fechacreacion  " +
                                " end as 'Modificación'," +
                                " case when frar_usuariomodificaid is NOT NULL  " +
                                "	then (select user_username from Framework.Usuarios where user_usuarioid = frar_usuariomodificaid) " +
                                "	else (select user_username from Framework.Usuarios where user_usuarioid = frar_usuariocreoid) end  " +
                                " as 'Usuario'" +
                                " from Ventas.FraccionArancelaria where frar_activo = '" + Activo.ToString + "' ORDER BY   frar_codigo asc"

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA INFORMACIÓN DE LA TABLA DE DETALLES DE FRACCIONES ARANCELARIAS EN LA BASE DE DATOS DEL SAY DE ACUERDO A LOS IDS DE LAS FRACCIONES ARANCELARIAS ELEGIDAS
    ''' </summary>
    ''' <param name="Ids_Fracciones">VARIABLE DEL TIPO STRING CON LOS IDS DE LAS FRACCIONES ARANCELARIAS DE LAS CUALES SE CONSULTARAN LOS DETALLES</param>
    ''' <returns>DATATABLE CON LA EL RESULTADO DE LA EJECUCIÓN DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_FraccionesArancelarias_Detalles(ByVal Ids_Fracciones As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = " select frde_fraccionarancelariadetalleid as 'Id', " +
                                    "   frde_fraccionarancelariaid as 'Id_Fraccion', " +
                                    "   frar_codigo as 'Código'," +
                                    "   cast(0 as bit) as ' '," +
                                    "	fami_descripcion AS 'Familia'," +
                                    "   frde_familiaid as 'Id_Familia'," +
                                    "   plmu_descripcion AS 'Corte'," +
                                    "   frde_pielmuestraid as 'Id_Corte'," +
                                    "   forr_descripcion AS 'Forro'," +
                                    "   frde_forroid as 'Id_Forro'," +
                                    "   suel_descripcion AS 'Suela'," +
                                    "   frde_suelaid as 'Id_Suela'," +
                                    "   tica_descripcion AS 'Tipo'," +
                                    "   frde_tipocategoriaid as 'Id_Tipo'," +
                                    "   frde_talla as 'Talla'," +
                                    "   frar_codigo  as 'Código FA'," +
                                    "   frar_nombre as 'Fracción Arancelaria'," +
                                    "   case when frde_fechamodificacion is null " +
                                    " 	    then frde_fechacreacion " +
                                    " 	    else frde_fechamodificacion  " +
                                    " 	    end as 'Modificación'," +
                                    "   case when frde_usuariomodificaid is NOT NULL  " +
                                    " 	    then (select user_username from Framework.Usuarios where user_usuarioid = frde_usuariomodificaid) " +
                                    " 	    else (select user_username from Framework.Usuarios where user_usuarioid = frde_usuariocreoid) " +
                                    "   end as 'Usuario'" +
                                    " from Ventas.FraccionArancelariaDetalle" +
                                    " join Ventas.FraccionArancelaria on frar_fraccionarancelariaid = frde_fraccionarancelariaid" +
                                    " join Programacion.Familias on fami_familiaid = frde_familiaid" +
                                    " join Programacion.PielMuestras on frde_pielmuestraid = plmu_pielmuestraid" +
                                    " join Programacion.Forros on forr_forroid = frde_forroid" +
                                    " join Programacion.Suelas on suel_suelaid = frde_suelaid" +
                                    " join Programacion.TipoCategoria on frde_tipocategoriaid = tica_tipocategoriaid" +
                                    " WHERE frde_fraccionarancelariaid IN (" + Ids_Fracciones + ")" +
                                    " AND frde_activo = 1 order by frar_codigo asc, Familia asc,Corte asc ,Forro asc,Suela asc,Tipo ASC,Talla asc"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA TODOS LOS ARTICULOS QUE CUMPLAN CON LAS CARACTERISTICAS FAMILIA, CORTE, FORRO, SUELA, TIPO-CATEGORIA CON CADA REGISTRO ACTIVOS DE LA TABLA DE DETALLES DE FRACCIONES ARANCELARIAS,
    ''' AGRUPANDO LA INFORMACIÓN POR CADA CAMPO EN EN ORDEN EN QUE SON MOSTRADOS.
    ''' </summary>
    ''' <param name="ids_Fracciones">VARIABLE DEL TIPO CADENA CON LOS IDS DE LAS FRACCIONES ARANCELARIAS DE LAS CUALES SE RECUPERARA LA INFORMACIÓN</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCIÓN DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Articulos(ByVal ids_Fracciones As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = " select * from (" +
                                " select frar_fraccionarancelariaid, marca as 'Marca', prod_codigo as 'Modelo', Sicy as 'SICY', coleccion AS 'Colección', " +
                                "	prod_descripcion as 'Descripción', talla as 'Corrida', Programacion.Fn_ConcatenarTallas_TallasDetalles(idTalla) AS  'Tallas_c',  '' as 'Tallas' ," +
                                "	frar_codigo as 'Código', frar_nombre as 'Fracción Arancelaria', familia as 'Familia', idFamilia as 'Id_Familia', corte as 'Corte', " +
                                "  	idCorte as 'Id_Corte', Forro as 'Forro', idForro as 'Id_Forro', suela as 'Suela', idSuela as 'Id_Suela', tipoCategoria as 'Tipo', idTipo as 'Id_Tipo'" +
                                "        from vProductoEstilos" +
                                " join Ventas.FraccionArancelariaDetalle on frde_familiaid = idFamilia and espr_pielmuestraid = frde_pielmuestraid and frde_activo = 1" +
                                " and frde_forroid = idForro and frde_suelaid = idSuela and frde_tipocategoriaid = idTipo " +
                                " join Ventas.FraccionArancelaria on frar_fraccionarancelariaid = frde_fraccionarancelariaid " +
                                " where frar_fraccionarancelariaid in (" + ids_Fracciones + ")) as Cons" +
                                " GROUP by  frar_fraccionarancelariaid, Marca, Modelo, SICY, Colección, Descripción, Corrida, Cons.Tallas_c, Tallas, Código, Cons.[Fracción Arancelaria], " +
                                       " Familia, Cons.Id_Familia, Corte, Cons.Id_Corte, Forro, Cons.Id_Forro, Suela, Cons.Id_Suela, Tipo, Cons.Id_Tipo" +
                                " order by Cons.SICY "

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' OBTIENE EL ID Y EL CODIGO + DESCIPCION DE TODAS LAS FRACCIONES ARANCELARIAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECICION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_FraccionesArancelariasActivas_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = "  select frar_fraccionarancelariaid as 'Id', frar_codigo + ' - ' +frar_nombre as 'Fraccion' " +
                    " from Ventas.FraccionArancelaria where frar_activo = 1 order by frar_nombre asc"

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODAS LAS FAMILIAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Familias_Activas_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = "  SELECT fami_familiaid AS 'Id', fami_descripcion as 'Familia' " +
                    " FROM Programacion.Familias where fami_activo = 1 order by fami_descripcion asc"

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LA LISTA DEL ID Y LA DESCRIPCION DE TODOS LOS CORTES(TABLA PIELMUESTRA) ACTIVOS DE LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_PielMuestra_o_Corte_Activa_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = "  Select plmu_pielmuestraid as 'Id', plmu_descripcion as 'Corte' " +
                    " from programacion.PielMuestras where plmu_activo = 1 order by plmu_descripcion asc"

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRICION DE TODOS LOS FORROS ACTIVOS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Forros_Activos_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = "  select forr_forroid as 'Id', forr_descripcion as 'Forro' " +
                    " from programacion.Forros where forr_activo = 1 order by forr_descripcion asc "

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODAS LAS SUELAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</remarks>
    Public Function Lista_Suelas_Activas_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = "  select suel_suelaid as 'Id', suel_descripcion as 'Suela' " +
                    " from Programacion.Suelas where suel_activo = 1 order by suel_descripcion asc"

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODOS LOS TIPO DE PRODUCTO(TABLA TIPOCATEGORIA) ACTIVAS DE LA BD DEL SAY
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</remarks>
    Public Function Lista_TipoCategoria_Activos_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = " select tica_tipocategoriaid as 'Id', tica_descripcion as 'Tipo' " +
                   " from Programacion.TipoCategoria where tica_activo = 1 order by  tica_descripcion asc"

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA EL ID Y LA DESCRIPCION DE TODAS LAS CORRIDAS MEXICANAS ACTIVAS EN LA BD DEL SAY
    ''' </summary>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCION DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function Lista_Corridas_Mexicanas_Activas_SAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""

        Consulta = "  select talla_tallaid as 'Id', talla_descripcion as 'Corrida' " +
                    " from Programacion.Tallas  where talla_paisid = 1 and talla_activo = 1 order by talla_descripcion asc  "

        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    ''' <summary>
    ''' RECUPERA LAS TALLAS DE UNA CORRIDA, ESTADO DE LA TALLA(ACTIVO O INACTIVO),  LA FRACCION ARANCELARIA DENTRO DE LA QUE ESTAN(EN CASO DE ESTAR DENTRO DE UNA), EL USUARIO QUE MODIFICO Y LA FECHA DE MODIFICACION,
    ''' </summary>
    ''' <param name="IdCorrida">ID DE LA CORRIDA DE LA CUAL SE RECUPERARAN LAS TALLAS</param>
    ''' <param name="objFraccionArancelariaDetalle">OBJETO DE LA CLASE DEL PROYECTO DE ENTIDADES "FRACCIONES_ARANCELARIAS_DETALLES" CON LA INFORMACIÓN DE LA INFORMACIÓN CON LA CUAL SE COMPARARA SI HAY FRACCIONES 
    ''' ARANCELARIAS CON PRODUCTOS QUE COINCIDAN CON LAS TALLAS A MOSTRAR Y LAS CARACTERISTICAS(FAMILIA, CORTE, TIPO, SUELA, FORRO)</param>
    ''' <returns>DATATABLE CON EL RESULTADO DE LA EJECUCIÓN DE LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function ListaTallas_Para_FraccionArancelariaDetalles(ByVal IdCorrida As Integer, ByVal objFraccionArancelariaDetalle As Entidades.Fracciones_Arancelarias_Detalles) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = " select b as ' ', Tallas.Talla, case when Tallas.Activo is null then cast (1 as bit) else Tallas.Activo end as 'Activo', Tallas.[Fracción Arancelaria], Tallas.Id_Fraccion_Detalle, Tallas.Modificación, Tallas.Usuario  " +
            "from(" +
                    " select cast( 0 as bit) as 'b', tade_talla as 'Talla', cast(frde_activo as bit) as 'Activo', frar_codigo+' - '+" +
                    "    frar_nombre as 'Fracción Arancelaria', frde_fraccionarancelariadetalleid as 'Id_Fraccion_Detalle'," +
                    "    case when frde_fechamodificacion is null then frde_fechacreacion " +
                    "    else frde_fechamodificacion end as 'Modificación' , " +
                    "    case when frde_usuariomodificaid is null then (select user_username from Framework.Usuarios where user_usuarioid = frde_usuariocreoid)" +
                    "    ELSE (select user_username from Framework.Usuarios where user_usuarioid = frde_usuariomodificaid) end as 'Usuario'" +
                    " from Programacion.TallasDetalle" +
                    "    left join Ventas.FraccionArancelariaDetalle on frde_talla = tade_talla" +
                    " and frde_familiaid =  " + objFraccionArancelariaDetalle.PFamiliaId.ToString +
                    "    and frde_pielmuestraid = " + objFraccionArancelariaDetalle.PPielMuestraId.ToString +
                    "    and frde_forroid = " + objFraccionArancelariaDetalle.PForroId.ToString +
                    "    and frde_suelaid = " + objFraccionArancelariaDetalle.PSuelaId.ToString +
                    "    and frde_tipocategoriaid = " + objFraccionArancelariaDetalle.PTipoCategoriaId.ToString +
                    "    left join Ventas.FraccionArancelaria on frde_fraccionarancelariaid = frar_fraccionarancelariaid" +
                    " where tade_tallaid = " + IdCorrida.ToString + ") as Tallas ORDER BY Tallas.Talla asc"

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function

    ''' <summary>
    ''' EJECUTA EL PROCESO INDICADO PARA GUARDAR EL DETALLE DE UNA FRACCION ARANCELARIA, YA SEA SI ES NECESARIA ACTUALIZAR LA RELACION DE UN REGISTRO DE LA TABLA FRACCIONARANCELARIADETALLE CON LA TABLA FRACCION ARANCELARIA
    ''' O BIEN AGREGAR UN REGISTRO NUEVO A LA TABLA FRACCIONARANCELARIADETALLES
    ''' </summary>
    ''' <param name="objFraccionDetalle">OBJETO DE LA ENTIDAD FRACCIONES_ARANCELARIAS_DETALLES CON LA INFORMACION DEL REGISTRO A AGREGAR O MODIFICAR DEPENDIENDO DE SI EXISTE O NO EN LA TABLA, PARA SABER
    ''' SI EL REGISTRO EXISTE BASTA CON OBSERVER EL ATRIBURO "PFRACCIONARANCELARIADETALLEID", SÍ ESTE ES = 0 INDICA QUE NO EXISTE DETALLE DE FRACCION ARANCELARIA CON LAS CARACTERISTICAS A AGREGAR, SÍ ES MAYOR A 0
    ''' INDICA QUE ABRIA QUE ACTUALIZAR UN REGISTRO </param>
    ''' <remarks></remarks>
    Public Sub GuardarFraccionArancelariaDetalles(ByVal objFraccionDetalle As Entidades.Fracciones_Arancelarias_Detalles)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        If objFraccionDetalle.PFraccionArancelariaDetalleID > 0 Then
            ''update
            If objFraccionDetalle.PActivo = True Then
                consulta = "UPDATE [Ventas].[FraccionArancelariaDetalle]" +
                           " SET [frde_fraccionarancelariaid] = " + objFraccionDetalle.PFraccionArancelariaId.ToString +
                           "   ,[frde_familiaid] = " + objFraccionDetalle.PFamiliaId.ToString +
                           "   ,[frde_pielmuestraid] = " + objFraccionDetalle.PPielMuestraId.ToString +
                           "   ,[frde_forroid] = " + objFraccionDetalle.PForroId.ToString +
                           "   ,[frde_suelaid] = " + objFraccionDetalle.PSuelaId.ToString +
                           "   ,[frde_tipocategoriaid] = " + objFraccionDetalle.PTipoCategoriaId.ToString +
                           "   ,[frde_talla] ='" + objFraccionDetalle.PTalla + "'" +
                           "   ,[frde_activo] = 1" +
                           "   ,[frde_usuariomodificaid] = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                           "   ,[frde_fechamodificacion] = getdate() " +
                           " WHERE frde_fraccionarancelariadetalleid = " + objFraccionDetalle.PFraccionArancelariaDetalleID.ToString
            Else
                consulta = "UPDATE [Ventas].[FraccionArancelariaDetalle]" +
                           " SET [frde_activo] =  0" +
                           "   ,[frde_usuariomodificaid] = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                           "   ,[frde_fechamodificacion] = getdate() " +
                           " WHERE frde_fraccionarancelariadetalleid = " + objFraccionDetalle.PFraccionArancelariaDetalleID.ToString
            End If

        Else
            ''insert
            consulta = "INSERT INTO [Ventas].[FraccionArancelariaDetalle]" +
                        "   ([frde_fraccionarancelariaid]" +
                        "   ,[frde_familiaid]" +
                        "   ,[frde_pielmuestraid]" +
                        "   ,[frde_forroid]" +
                        "   ,[frde_suelaid]" +
                        "   ,[frde_tipocategoriaid]" +
                        "   ,[frde_talla]" +
                        "   ,[frde_activo]" +
                        "   ,[frde_usuariocreoid]" +
                        "   ,[frde_fechacreacion])" +
                        " VALUES" +
                        "   (" + objFraccionDetalle.PFraccionArancelariaId.ToString +
                        "   ," + objFraccionDetalle.PFamiliaId.ToString +
                        "   ," + objFraccionDetalle.PPielMuestraId.ToString +
                        "   ," + objFraccionDetalle.PForroId.ToString +
                        "   ," + objFraccionDetalle.PSuelaId.ToString +
                        "   ," + objFraccionDetalle.PTipoCategoriaId.ToString +
                        "   ,'" + objFraccionDetalle.PTalla.ToString + "'" +
                        "   , 1 " +
                        "   ," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                        "   , getdate())"
        End If

        objPersistencia.EjecutaConsulta(consulta)

    End Sub

    ''' <summary>
    ''' INACTIVA UN UNO O VARIOS REGISTROS DE LA TABLA "FRACCIONESARANCELARIASDETALLES"
    ''' </summary>
    ''' <param name="ids_detalles">VARIABLE DEL TIPO STRING CON LOS IDS DE LOS DETALLES DE FRACCIONES ARANCELARIAS A INACTIVAR</param>
    ''' <remarks></remarks>
    Public Sub Eliminar_FraccionesDetalles(ByVal ids_detalles As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "  update Ventas.FraccionArancelariaDetalle" +
                    " set frde_activo = 0, frde_usuariomodificaid =" + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
                    " , frde_fechamodificacion = GETDATE()" +
                    " where frde_fraccionarancelariadetalleid in (" + ids_detalles + ")"

        objPersistencia.EjecutaConsulta(consulta)
    End Sub


    Public Function ListaFracciones_De_Detalle_SoloConsulta(ByVal IdCorrida As Integer, ByVal objFraccionArancelariaDetalle As Entidades.Fracciones_Arancelarias_Detalles) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String

        consulta = "select Tallas.Talla, Tallas.Código, Tallas.[Fracción Arancelaria]" +
                    " from(" +
                    "    select tade_talla as 'Talla', frar_codigo as 'Código', frar_nombre as 'Fracción Arancelaria'" +
                    "        from Programacion.TallasDetalle" +
                    "         left join Ventas.FraccionArancelariaDetalle on frde_talla = tade_talla" +
                    "		 and frde_familiaid =  " + objFraccionArancelariaDetalle.PFamiliaId.ToString +
                    "         and frde_pielmuestraid =  " + objFraccionArancelariaDetalle.PPielMuestraId.ToString +
                    "         and frde_forroid = " + objFraccionArancelariaDetalle.PForroId.ToString +
                    "         and frde_suelaid = " + objFraccionArancelariaDetalle.PSuelaId.ToString +
                    "         and frde_tipocategoriaid = " + objFraccionArancelariaDetalle.PTipoCategoriaId.ToString +
                    "         and frde_activo = 1  " +
                    "         left join Ventas.FraccionArancelaria on frde_fraccionarancelariaid = frar_fraccionarancelariaid" +
                    " where tade_tallaid = " + IdCorrida.ToString + ") as Tallas ORDER BY Talla"

        Return objPersistencia.EjecutaConsulta(consulta)
    End Function
End Class
