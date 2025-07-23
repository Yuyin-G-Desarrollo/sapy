Imports System.Data.SqlClient

Public Class ListaBaseDA

    Public Function listaListasBase() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        '"SELECT" +
        '            " lb.lpba_listapreciosbaseid," +
        '            " lb.lpba_codigolistabase," +
        '            " lb.lpba_nombrelista," +
        '            " lb.lpba_vigenciainicio," +
        '            " lb.lpba_vigenciafin," +
        '            " us.user_username AS ucreo," +
        '            " um.user_username AS umodifico," +
        '                "CASE" +
        '                    " WHEN lb.lpba_estatus = 1 THEN 2" +
        '                    " WHEN lb.lpba_estatus = 2 THEN 1" +
        '                    " ELSE 3" +
        '                " END ORDENAMIENTO," +
        '                   " CASE " +
        '               " WHEN lb.lpba_estatus=1 THEN 'ACTIVA'" +
        '               " WHEN lb.lpba_estatus =2 THEN 'AUTORIZADA'" +
        '               " ELSE 'INACTIVA'" +
        '               " END ESTATUS," +
        '               " lb.lpba_estatus" +
        '        " FROM Ventas.ListaPreciosBase lb" +
        '        " INNER JOIN Framework.Usuarios us" +
        '            " ON lb.lpba_usuariocreo = us.user_usuarioid" +
        '        " LEFT JOIN Framework.Usuarios um" +
        '            " ON lb.lpba_usuariomodifico = um.user_usuarioid" +
        '        " ORDER BY ORDENAMIENTO"
        cadena = <consulta>
        SELECT lb.lpba_listapreciosbaseid, lb.lpba_codigolistabase, lb.lpba_nombrelista, lb.lpba_vigenciainicio, 
        lb.lpba_vigenciafin, us.user_username AS ucreo, um.user_username AS umodifico,CASE WHEN lb.lpba_estatus = 1 
        THEN 2 WHEN lb.lpba_estatus = 2 THEN 1 ELSE 3 END ORDENAMIENTO, CASE  WHEN lb.lpba_estatus=1 THEN 'ACTIVA' 
        WHEN lb.lpba_estatus =2 THEN 'AUTORIZADA' ELSE 'INACTIVA' END ESTATUS, lb.lpba_estatus FROM Ventas.ListaPreciosBase lb 
        INNER JOIN Framework.Usuarios us ON lb.lpba_usuariocreo = us.user_usuarioid 
        LEFT JOIN Framework.Usuarios um ON lb.lpba_usuariomodifico = um.user_usuarioid ORDER BY ORDENAMIENTO
                  </consulta>.Value
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function DatosProductos(ByVal conPrecio As Boolean, ByVal precioCero As Boolean,
                                            ByVal activos As Boolean, ByVal descontinuadosvnt As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@conPrecio"
        parametro.Value = conPrecio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precioCero"
        parametro.Value = precioCero
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activos"
        parametro.Value = activos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@descontinuadosvnt"
        parametro.Value = descontinuadosvnt
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Ventas.SP_PreciosVentaModelos", listaParametros)
    End Function

    Public Function datosListasBase() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Ventas.SP_ListaPreciosVigente")

    End Function

    Public Function listaListasBaseCombo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT * FROM (SELECT lb.lpba_codigolistabase, lb.lpba_codigolistabase + ' - ' + lb.lpba_nombrelista + '(AUTORIZADA)' AS NombreLista" +
            " FROM Ventas.ListaPreciosBase lb INNER JOIN Framework.Usuarios us ON lb.lpba_usuariocreo = us.user_usuarioid " +
            " LEFT JOIN Framework.Usuarios um ON lb.lpba_usuariomodifico = um.user_usuarioid	WHERE lb.lpba_estatus = 2) AS a" +
            " UNION ALL" +
            " SELECT * FROM (SELECT lb.lpba_codigolistabase, lb.lpba_codigolistabase + ' - ' + lb.lpba_nombrelista + '(ACTIVA)' AS NombreLista" +
            " FROM Ventas.ListaPreciosBase lb INNER JOIN Framework.Usuarios us ON lb.lpba_usuariocreo = us.user_usuarioid " +
            " LEFT JOIN Framework.Usuarios um ON lb.lpba_usuariomodifico = um.user_usuarioid WHERE lb.lpba_estatus = 1) AS B" +
            " UNION ALL" +
            " SELECT * FROM (SELECT lb.lpba_codigolistabase, lb.lpba_codigolistabase + ' - ' + lb.lpba_nombrelista + '(INACTIVA)' AS NombreLista" +
            " FROM Ventas.ListaPreciosBase lb INNER JOIN Framework.Usuarios us ON lb.lpba_usuariocreo = us.user_usuarioid " +
            " LEFT JOIN Framework.Usuarios um ON lb.lpba_usuariomodifico = um.user_usuarioid WHERE lb.lpba_estatus = 3) AS C"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consecutivoCod(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " COUNT(*) + 1 consecutivo" +
                                " FROM Ventas.ListaPreciosBase" +
                                " WHERE DatePart(Year, lpba_vigenciainicio) = " + anio.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function guardarListaBaseNueva(ByVal entListaB As Entidades.ListaBase) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@nombreLista"
        parametro.Value = entListaB.PListaBaseNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaVigenciaInicio"
        parametro.Value = entListaB.PVigenciaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaFinVigencia"
        parametro.Value = entListaB.PVigenciaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_AltaListaBase", listaParametros)
    End Function

    Public Sub guardarListaBaseDetalles(ByVal idListaBase As Int32, ByVal productoestiloid As Int32, ByVal precio As Decimal)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listasPrecioid"
        parametro.Value = idListaBase.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloid"
        parametro.Value = productoestiloid.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = precio.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_AltaListaBaseDetalles", listaParametros)

    End Sub

    Public Function verListaPreciosCombo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " lpba_listapreciosbaseid," +
                                " lpba_nombrelista+' ('+ lpba_codigolistabase+ ')' AS LISTABASE" +
                                " FROM Ventas.ListaPreciosBase" +
                        " WHERE lpba_estatus IN (1, 2)"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function datosPrecioBaseEditar(ByVal idListaPrecio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT pe.pres_productoestiloid, pp.prod_codigo, pp.prod_descripcion,cc.cole_coleccionid,cc.cole_descripcion," +
            " mm.marc_marcaid, mm.marc_descripcion, pl.piel_pielid, pl.piel_descripcion,cl.color_colorid, cl.color_descripcion, tt.talla_tallaid,tt.talla_descripcion, pe.pres_codSicy, lp.lpbp_precio as 'precio'" +
            " FROM Programacion .Productos AS pp INNER JOIN Programacion .Marcas  AS mm ON pp.prod_marcaid =mm.marc_marcaid INNER JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid =cc.cole_coleccionid" +
            " INNER JOIN Programacion.ProductoEstilo AS pe ON pp.prod_productoid =pe.pres_productoid INNER JOIN Precios.ListaPreciosBaseProductos as lp ON pe.pres_productoestiloid =lp.lpbp_productoEstiloid" +
            " INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid =ep.espr_estiloproductoid INNER JOIN Programacion.Pieles  AS pl ON ep.espr_pielid =pl.piel_pielid" +
            " INNER JOIN Programacion.Colores AS cl ON ep.espr_colorid =cl.color_colorid INNER JOIN Programacion.Tallas AS tt ON ep .espr_tallaid =TT.talla_tallaid" +
            " where mm.marc_activo =1 and cc.cole_activo =1 and pe.pres_activo =1 and lp.lpbp_activo = 1 and pl.piel_activo =1 and cl.color_activo =1 and tt.talla_activo =1 and pp.prod_activo = 1 ORDER BY pp.prod_codigo"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verificarVigenciaLista() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT DATEDIFF(day, A.lpb_fechaFinVigencia, GETDATE()) AS DiffDate from Precios.ListasPrecioBase as A INNER JOIN Precios.EstatusListasPrecio AS B on A.lpb_estatusListaid =B.elp_estatusListaid where B.elp_nombreEstatus='AUTORIZADA'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verHistorico(ByVal codigos As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@codigos"
        parametro.Value = codigos
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_Historico_ListasBase", listaParametros)
    End Function

    Public Function consultarLimitesVigenciasPorListasVentas(ByVal idlistaBase As Int32) As DataTable
        Dim opercacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                        " MAX(lpvt_vigenciainicio) INICIO," +
                        " MAX(lpvt_vigenciafin) FIN" +
                        " FROM Ventas.ListaPreciosVenta" +
                        " WHERE lpvt_listapreciosbaseid = " + idlistaBase.ToString +
                        " AND lpvt_estemporal = 0"
        Return opercacion.EjecutaConsulta(cadena)
    End Function

    Public Function RecuperarListasBase() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Return operacion.EjecutaConsulta("[Ventas].[SP_ListaPreciosVigente]")
    End Function

    'Public Function idMaxLPB() As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim cadena As String = "select max(lpb_listaPreciosBaseid) from Precios.ListasPrecioBase"
    '    Return operacion.EjecutaConsulta(cadena)
    'End Function

    Public Function editarListaPrecios(ByVal idListaPrecios As Int32, ByVal comentarios As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaPrecios"
        parametro.Value = idListaPrecios
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_EditarEstatusListaPrecios", listaParametros)
    End Function

    Public Function verListaPBase(ByVal idListaB As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
        " lpba_listapreciosbaseid," +
        " lpba_codigolistabase," +
        " lpba_nombreLista," +
        " lpba_vigenciainicio," +
        " lpba_vigenciafin," +
        " lpba_estatus" +
        " FROM Ventas.ListaPreciosBase" +
        " WHERE lpba_listaPreciosBaseid = " + idListaB.ToString
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function InsertPrecioProductoDetalles(ByVal ProductoEstiloId As String, ByVal PrecioVenta As Double, ByVal tppe_productoestiloid As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ProductoEstiloId"
        parametro.Value = ProductoEstiloId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PrecioVenta"
        parametro.Value = PrecioVenta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tppe_productoestiloid"
        parametro.Value = tppe_productoestiloid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_InsertarPrecioVenta", listaParametros)

    End Function

    Public Function verDetallesListaPrecios(ByVal idListaB As Int32, ByVal conPrecio As Boolean, ByVal precioCero As Boolean,
                                            ByVal activos As Boolean, ByVal descontinuadosvnt As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        'MsgBox(idListaB)
        'MsgBox(conPrecio)
        'MsgBox(precioCero)
        'MsgBox(activos)
        'MsgBox(descontinuadosvnt)
        Dim cadena As String = "SELECT * FROM (SELECT" +
            " lpbp_listapreciosbaseid," +
        " lpbp_listapreciobaseproductoid," +
        " marc_marcaid," +
        " marc_descripcion," +
        " cole_coleccionid," +
        " cole_descripcion," +
        " prod_codigo," +
        " pp.prod_modelo," +
        " pres_productoestiloid," +
        " talla_tallaid," +
        " talla_descripcion," +
        " piel_pielid," +
        " piel_descripcion," +
        " prod_descripcion," +
        " color_colorid," +
        " color_descripcion," +
        " fami_familiaid," +
        " fami_descripcion," +
        " linea_lineaid," +
        " linea_descripcion," +
        " stpr_productoStatusId," +
        " stpr_descripcion," +
        " pres_codSicy," +
        " pres_activo, " +
    " CASE" +
        " WHEN lp.lpbp_preciobase IS NOT NULL THEN lp.lpbp_preciobase" +
        " ELSE 0" +
    " END AS PrecioAnterior," +
    " CASE" +
        " WHEN lp.lpbp_preciobase IS NOT NULL THEN lp.lpbp_preciobase" +
        " ELSE 0" +
    " END AS Precio, mm.marc_decimales" +
" FROM Programacion.Productos AS pp" +
" INNER JOIN Programacion.Marcas AS mm ON pp.prod_marcaid = mm.marc_marcaid" +
" INNER JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid = cc.cole_coleccionid" +
" INNER JOIN Programacion.ProductoEstilo AS pe ON pp.prod_productoid = pe.pres_productoid" +
" INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid AND isnull(pe.pres_clavesat_detallada,'' ) <> '' " +
" INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid" +
" INNER JOIN Programacion.Colores AS cl ON ep.espr_colorid = cl.color_colorid" +
" INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid" +
" INNER JOIN Programacion.Familias AS ff ON ff.fami_familiaid = pe.pres_familiaid" +
" INNER JOIN Programacion.Lineas AS ll ON ll.linea_lineaid = pe.pres_lineaid" +
" INNER JOIN Programacion.EstatusProducto AS sp ON sp.stpr_productoStatusId = pe.pres_estatus AND stpr_productoStatusId IN (1, 2, 3, 4, 5, 6)" +
" LEFT OUTER JOIN Ventas.ListaPrecioBaseProducto AS lp ON lp.lpbp_productoestiloid = pe.pres_productoestiloid" +
" AND lp.lpbp_activo = 1 AND lpbp_listapreciosbaseid = " + idListaB.ToString +
" WHERE pp.prod_activo = 1 And pe.pres_activo = 1 And mm.marc_activo = 1 And cc.cole_activo = 1" +
" AND ff.fami_activo = 1 AND ll.linea_activo = 1 AND pl.piel_activo = 1 AND cl.color_activo = 1" +
" AND tt.talla_activo = 1 AND sp.stpr_activo = 1 /*AND pe.pres_estatus <> 1*/) AS CONSULTA"

        Dim primerWhere As Boolean = False


        If conPrecio = True And precioCero = False Then
            If primerWhere = False Then
                cadena += " WHERE PrecioAnterior > 0"
                primerWhere = True
            Else
                cadena += " AND PrecioAnterior > 0"
            End If
        End If

        If conPrecio = False And precioCero = True Then
            If primerWhere = False Then
                cadena += " WHERE PrecioAnterior = 0"
                primerWhere = True
            Else
                cadena += " AND PrecioAnterior = 0"
            End If
        End If

        If activos = True And descontinuadosvnt = False Then
            If primerWhere = False Then
                cadena += " WHERE stpr_productoStatusId <> 6"
                primerWhere = True
            Else
                cadena += " AND stpr_productoStatusId <> 6"
            End If
        End If

        If activos = False And descontinuadosvnt = True Then
            If primerWhere = False Then
                cadena += " WHERE stpr_productoStatusId = 6"
                primerWhere = True
            Else
                cadena += " AND stpr_productoStatusId = 6"
            End If
        End If

        cadena += " ORDER BY prod_codigo, piel_descripcion, color_descripcion, talla_descripcion "

        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function verProductosListasPrecios() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                        " pe.pres_productoestiloid, pp.prod_codigo, pp.prod_descripcion," +
                        " mm.marc_marcaid, mm.marc_descripcion, cc.cole_coleccionid," +
                        " cc.cole_descripcion, ff.fami_familiaid, ff.fami_descripcion," +
                        " ll.linea_lineaid, ll.linea_descripcion, pl.piel_pielid," +
                        " pl.piel_descripcion, cl.color_colorid, cl.color_descripcion," +
                        " tt.talla_tallaid, tt.talla_descripcion, pe.pres_codSicy," +
                        " pe.pres_activo, sp.stpr_productoStatusId, sp.stpr_descripcion," +
                        " 0.0 as Precio, mm.marc_decimales" +
                        " FROM Programacion.Productos AS pp" +
                        " JOIN Programacion.Marcas AS mm ON pp.prod_marcaid = mm.marc_marcaid" +
                        " JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid = cc.cole_coleccionid" +
                        " JOIN Programacion.ProductoEstilo AS pe ON pp.prod_productoid = pe.pres_productoid and isnull(pres_clavesat_detallada,'') <> '' " +
                        " JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid" +
                        " JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid" +
                        " JOIN Programacion.Colores AS cl ON ep.espr_colorid = cl.color_colorid" +
                        " JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid" +
                        " JOIN Programacion.Familias ff ON FF.fami_familiaid = pe.pres_familiaid" +
                        " JOIN Programacion.Lineas ll ON ll.linea_lineaid = pe.pres_lineaid" +
                        " JOIN Programacion.EstatusProducto sp ON sp.stpr_productoStatusId = pe.pres_estatus" +
                        " WHERE pp.prod_activo = 1" +
                        " AND pe.pres_activo = 1 AND mm.marc_activo = 1 AND cc.cole_activo = 1" +
                        " AND FF.fami_activo = 1 AND ll.linea_activo = 1 AND pl.piel_activo = 1" +
                        " AND cl.color_activo = 1 AND tt.talla_activo = 1 AND pe.pres_estatus NOT IN (1, 6, 7)" +
                        " ORDER BY prod_codigo, piel_descripcion, color_descripcion, talla_descripcion "

        '" and pe.pres_activo ='True' " +
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verConsultaListaBaseAgrupada(ByVal ListaBase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idlistaPreciosBase"
        parametro.Value = ListaBase.ToString
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Precios.SP_ConsultaPreciosAgrupados", listaParametros)
    End Function

    Public Function VerTitulosTallas(ByVal idListaBase As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT talla_descripcion" +
                        " FROM Programacion.Tallas WHERE talla_activo = 1" +
                        " AND talla_tallaid IN (SELECT d.talla_tallaid" +
                        " FROM Precios.ListaPreciosBaseProductos a" +
                        " INNER JOIN Programacion.ProductoEstilo b ON a.lpbp_productoEstiloid = b.pres_productoestiloid" +
                        " INNER JOIN Programacion.EstilosProducto c ON b.pres_estiloid = c.espr_estiloproductoid" +
                        " INNER JOIN Programacion.Tallas d ON c.espr_tallaid = d.talla_tallaid" +
                        " WHERE a.lpbp_listasPrecioBaseid = " + idListaBase + ")"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerModelosGrupo(ByVal idListaBase As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select lpbp_precio, prod_descripcion, pp.prod_codigo, mm.marc_descripcion, mm.marc_marcaid," +
        " cc.cole_descripcion, cc.cole_coleccionid," +
        " tt.talla_descripcion" +
            " FROM Programacion.Productos AS pp " +
            " INNER JOIN Programacion.Marcas  AS mm ON pp.prod_marcaid =mm.marc_marcaid" +
            " INNER JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid =cc.cole_coleccionid " +
            " INNER JOIN Programacion.Familias AS FF ON PP.prod_familiaid =FF.fami_familiaid" +
            " INNER JOIN Programacion.Subfamilia AS SF ON PP.prod_subfamilia =SF.subf_subfamiliaid" +
            " INNER JOIN Programacion.Temporadas AS TM ON PP.prod_temporadaid =TM.temp_temporadaid" +
            " INNER JOIN Programacion.Grupos AS GR ON PP.prod_grupo =GR.grpo_grupoid " +
            " INNER JOIN Programacion.ProductoEstilo AS pe ON pp.prod_productoid =pe.pres_productoid " +
            " INNER JOIN Programacion.Hormas AS HH ON PE.pres_horma =HH.horma_hormaid " +
            " INNER JOIN Programacion.EstilosProducto AS ep ON pe .pres_estiloid =ep.espr_estiloproductoid " +
            " INNER JOIN Programacion.Pieles  AS pl ON ep.espr_pielid =pl.piel_pielid " +
            " INNER JOIN Programacion.Colores AS cl ON ep.espr_colorid =cl.color_colorid " +
            " INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid =TT.talla_tallaid" +
            " INNER JOIN Programacion.Forros  AS FO ON ep.espr_forroid =FO.forr_forroid " +
            " INNER JOIN Programacion.PielMuestras AS PM ON EP.espr_pielmuestraid =PM.plmu_pielmuestraid " +
            " INNER JOIN Programacion.Suelas AS SL ON EP.espr_suelaid =SL.suel_suelaid " +
            " INNER join Precios.ListaPreciosBaseProductos A on pe.pres_productoestiloid =A.lpbp_productoEstiloid " +
            " INNER join Precios.ListasPrecioBase B on A.lpbp_listasPrecioBaseid =B.lpb_listaPreciosBaseid " +
            " where mm.marc_activo = 1 And cc.cole_activo = 1 And pe.pres_activo = 1 And pl.piel_activo = 1" +
            " and cl.color_activo =1 and tt.talla_activo =1  and pp.prod_activo = 1 " +
            " AND B.lpb_listaPreciosBaseid=" + idListaBase + "" +
            " GROUP BY lpbp_precio, prod_descripcion, pp.prod_codigo, mm.marc_descripcion, mm.marc_marcaid," +
            " cc.cole_descripcion, cc.cole_coleccionid," +
            " tt.talla_descripcion, tt.talla_tallaid ORDER BY pp.prod_descripcion, pp.prod_codigo"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub EditarListaBase(ByVal entListBase As Entidades.ListaBase, ByVal comentario As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaBase"
        parametro.Value = entListBase.PListaBaseId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = entListBase.PListaBaseNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@feInicio"
        parametro.Value = entListBase.PVigenciaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@feFin"
        parametro.Value = entListBase.PVigenciaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuarioModifico"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_EditarListaPreciosDatos", listaParametros)
    End Sub

    Public Sub EditarListaBasePrecios(ByVal idListaBase As Int32, ByVal productoestiloid As Int32,
                                      ByVal precio As Decimal, ByVal redondeo As Boolean)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listasPrecioid"
        parametro.Value = idListaBase.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@productoEstiloid"
        parametro.Value = productoestiloid.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = precio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@redondeo"
        parametro.Value = redondeo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operacion.EjecutarSentenciaSP("Ventas.SP_EditarPreciosListaBase", listaParametros)
    End Sub

    Public Function verIdListaBase() As Int32
        Dim idListaBase As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtIdLista As DataTable
        dtIdLista = operacion.EjecutaConsulta("SELECT lpb_listaPreciosBaseid from Precios.ListasPrecioBase WHERE lpb_estatusListaid=1")
        idListaBase = CInt(dtIdLista.Rows(0)(0))
        Return idListaBase
    End Function

    Public Function verListaPreciosActivaAutorizada() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        ''Ejecutamos procedimiento almacenado.
        Return operaciones.EjecutarConsultaSP("Ventas.SP_ListasPrecio_MostrarListaBase", listaparametros)
    End Function

    '
    Public Function verDetallesListaPreciosCliente(ByVal idListaB As Int32, ByVal idCliente As Int32,
                                                    ByVal idListaVentasClientePrecio As Int32,
                                                    ByVal vertodo As Boolean, ByVal idListaPreciosVenta As Int32,
                                                    ByVal clienteModelosGeneralesIdLista As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlClient.SqlParameter)

        ' MsgBox(idListaB)
        ' MsgBox(idCliente)
        ' MsgBox(idListaVentasClientePrecio)
        ' MsgBox(vertodo)
        ' MsgBox(idListaPreciosVenta)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idLista"
        parametro.Value = idListaB.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCliente.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idListaVentasClientePrecio"
        parametro.Value = idListaVentasClientePrecio.ToString
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@vertodo"
        parametro.Value = vertodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idListaPreciosVenta"
        parametro.Value = idListaPreciosVenta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ModelosGeneralesidListaVentasCliente"
        parametro.Value = clienteModelosGeneralesIdLista
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultaModelosClientesListaVentas", listaParametros)
    End Function

    'Public Function verDetallesListaPreciosClienteSOLOregistro(ByVal idListaB As Int32, ByVal idCliente As Int32, ByVal idListaCliente As Int32,
    '                                                          ByVal Incremento As Double, ByVal MN_Nacional_Extranjera As Boolean,
    '                                                          ByVal Incremento_Porcentaje_Cantidad As Boolean, ByVal Paridad As Double,
    '                                                          ByVal Marcaje As Integer,
    '                                                          ByVal Modelaje As Integer,
    '                                                          ByVal Marcas As String,
    '                                                          ByVal ListaCompleta_o_Pedido As Boolean,
    '                                                          ByVal FechaInicioPedido As String,
    '                                                          ByVal EchaFinPedido As String
    '                                                          ) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlClient.SqlParameter)

    '    Dim parametro As New SqlParameter
    '    parametro.ParameterName = "@idLista"
    '    parametro.Value = idListaB
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@idCliente"
    '    parametro.Value = idCliente
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@idListaCliente"
    '    parametro.Value = idListaCliente
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@Incremento"
    '    parametro.Value = Incremento
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@MN_Nacional_Extranjera"
    '    parametro.Value = MN_Nacional_Extranjera
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@Incremento_Porcentaje_Cantidad"
    '    parametro.Value = Incremento_Porcentaje_Cantidad
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@Paridad"
    '    parametro.Value = Paridad
    '    listaParametros.Add(parametro)

    '    'parametro = New SqlParameter
    '    'parametro.ParameterName = "@IdPais"
    '    'parametro.Value = IdPais
    '    'listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@contadorMarca"
    '    parametro.Value = Marcaje
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@contadorColeccion"
    '    parametro.Value = Modelaje
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@Marcas"
    '    parametro.Value = Marcas
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@ListaCompleta_o_Pedido"
    '    parametro.Value = ListaCompleta_o_Pedido
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@FechaInicioPedido"
    '    parametro.Value = FechaInicioPedido
    '    listaParametros.Add(parametro)

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "@FechaFinPedido"
    '    parametro.Value = EchaFinPedido
    '    listaParametros.Add(parametro)

    '    Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultaModelosClientesListaVentasRegistro", listaParametros)
    'End Function

    Public Function consultaEstiloPrecio(ByVal idListaBase As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " lpbp_productoestiloid," +
                                " lpbp_preciobase" +
                        " FROM Ventas.ListaPrecioBaseProducto lpb" +
                                " WHERE lpbp_listapreciosbaseid = " + idListaBase.ToString +
                        " AND lpbp_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    ''' <summary>
    ''' RECUPERA EL HISTORIAL DE LOS CAMBIS EN LOS PRODUCTOS DE LAS LSITAS DE BASE SELECCIONADAS
    ''' </summary>
    ''' <param name="CodigosListaBase">CODIGOS DE LAS LSITAS DE BASE DONDE SE BUSCARA LA INFORMACION</param>
    ''' <param name="Productos">PRODUCTOS DE LOS CUALES SE CONSULTARA LA INFORMACION</param>
    ''' <returns>DATATABLE CON LA INFORMACION RECUPERADA CON LA CONSULTA</returns>
    ''' <remarks></remarks>
    Public Function RecuperarHistorialDeProductos(ByVal CodigosListaBase As String, ByVal Productos As String, ByVal IdsEstiloProducto As String) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT " & _
" X.lpba_codigolistabase AS 'Lista Base'," & _
" mm.marc_descripcion AS 'Marca'," & _
" cc.cole_descripcion AS 'Coleccion'," & _
" pp.prod_codigo AS 'Modelo SAY'," & _
" pp.prod_modelo AS 'Modelo SICY'," & _
" tt.talla_descripcion AS 'Corrida'," & _
" pl.piel_descripcion 'Piel', " & _
" cl.color_descripcion AS 'Color'," & _
" temp_nombre AS 'Temporada'," & _
" A.lpbh_preciobase_antes AS 'Precio Anterior'," & _
" A.lpbh_preciobase_despues AS 'Precio Actualizado'," & _
" (A.lpbh_preciobase_despues - A.lpbh_preciobase_antes) AS 'Diferencia'," & _
" A.lpbh_inicioprecio AS 'Inicio Precio Anterior (Hr)'," & _
" A.lpbh_finprecio AS 'Fin Precio Anterior (Hr)'," & _
" u.user_nombrereal AS 'Modifico'," & _
" Convert(varchar(10), A.lpbh_inicioprecio, 103) 'Inicio Precio Anterior'," & _
" CONVERT(varchar(10), A.lpbh_finprecio, 103) AS 'Fin Precio Anterior'" & _
" FROM Ventas.ListaPrecioBaseProducto_Hist AS A" & _
" JOIN Ventas.ListaPrecioBaseProducto AS B ON B.lpbp_listapreciosbaseid = A.lpbh_listapreciosbaseid" & _
" AND b.lpbp_productoestiloid = A.lpbh_productoestiloid" & _
" JOIN Ventas.ListaPreciosBase X ON X.lpba_listapreciosbaseid = A.lpbh_listapreciosbaseid" & _
" JOIN Programacion.ProductoEstilo PE	ON Pe.pres_productoestiloid = A.lpbh_productoestiloid" & _
" JOIN Programacion.Productos PP ON PP.prod_productoid = PE.pres_productoid" & _
" JOIN Programacion.Marcas AS mm ON pp.prod_marcaid = mm.marc_marcaid" & _
" JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid = cc.cole_coleccionid" & _
" JOIN Programacion.Temporadas ON cc.cole_temporadaid = temp_temporadaid" & _
" JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid" & _
" JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid" & _
" JOIN Programacion.Colores AS cl ON ep.espr_colorid = cl.color_colorid" & _
" JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid" & _
" JOIN Framework.Usuarios AS u ON u.user_usuarioid = a.lpbh_usuarioid" & _
" WHERE a.lpbh_productoestiloid IN (" + IdsEstiloProducto + ") and  x.lpba_codigolistabase IN (" + CodigosListaBase + ")  " & _
" ORDER BY lpbp_listapreciosbaseid DESC, A.lpbh_finprecio DESC, pp.prod_codigo ASC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function RecuperarHistorialCliente(ByVal IdCliente As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT Z.lpba_codigolistabase AS 'Lista Base',CLI.clie_nombregenerico AS 'Cliente',mm.marc_descripcion AS 'Marca'," +
        '" cc.cole_descripcion AS 'Colección',pp.prod_codigo AS 'Código',pl.piel_descripcion + ' ' + cl.color_descripcion AS 'Piel/Color'," +
        '" tt.talla_descripcion AS 'Corrida',pe.pres_codSicy AS 'SICY', (SELECT P.lpvt_descripcion FROM Ventas.ListaVentasCliente AS Q" +
        '" JOIN Ventas.ListaPreciosVenta P ON P.lpvt_listaprecioventaid = Q.lvcl_listaprecioventasid " +
        '" WHERE Q.lvcl_listaventasclienteid = [lpch_listaventasclienteid_antes])	AS 'LV Anterior'," +
        '" (SELECT mone_nombre FROM Framework.Moneda WHERE mone_monedaid = A.[lpch_monedaid_antes]) AS 'Moneda ant'," +
        '" (SELECT P.lpvt_descripcion FROM Ventas.ListaVentasCliente AS Q " +
        '" JOIN Ventas.ListaPreciosVenta P ON P.lpvt_listaprecioventaid = Q.lvcl_listaprecioventasid " +
        '" WHERE Q.lvcl_listaventasclienteid = [lpch_listaventasclienteid_despues]) AS 'LV Actualizada', " +
        '" (SELECT mone_nombre FROM Framework.Moneda WHERE mone_monedaid = A.[lpch_monedaid_despues]) AS 'Moneda Act', " +
        '" [lpch_precio_antes] AS 'Precio Ant', [lpch_precio_despues] AS 'Precio Act', ([lpch_precio_despues] - [lpch_precio_antes]) AS 'Diferencia', " +
        '" [lpch_precioextranjero_antes] AS 'Precio Extr Ant', [lpch_precioextranjero_despues] AS 'Precio Extr Act', [lpch_inicioprecio] AS 'Inicio Precio Ant (Hr)', " +
        '" [lpch_finprecio] AS 'Fin Precio Ant (Hr)', user_nombrereal AS 'Modificó', CONVERT(varchar(10), [lpch_inicioprecio], 103) AS 'Inicio Precio Ant', " +
        '" CONVERT(varchar(10), [lpch_finprecio], 103) AS 'Fin Precio Ant'" +
        '" FROM [Ventas].[ListaPrecioClienteProducto_Hist] AS A" +
        '" JOIN Framework.Usuarios AS u ON u.user_usuarioid = a.lpch_usuarioid" +
        '" JOIN Ventas.ListaPrecioClienteProducto AS b ON a.lpch_listaprecioclienteproductoid = b.lpcp_listaprecioclienteproductoid" +
        '" JOIN Ventas.ListaVentasCliente AS V ON V.lvcl_listaventasclienteid = B.lpcp_listaventasclienteid " +
        '" JOIN Cliente.Cliente AS CLI ON CLI.clie_clienteid = V.lvcl_clienteid" +
        '" JOIN Ventas.ListaPreciosVenta AS X ON X.lpvt_listaprecioventaid = V.lvcl_listaprecioventasid" +
        '" JOIN Ventas.ListaPreciosBase Z ON Z.lpba_listapreciosbaseid = X.lpvt_listapreciosbaseid" +
        '" JOIN Programacion.ProductoEstilo PE ON Pe.pres_productoestiloid = A.lpch_productoestiloid" +
        '" JOIN Programacion.Productos PP ON PP.prod_productoid = PE.pres_productoid" +
        '" JOIN Programacion.Marcas AS mm ON pp.prod_marcaid = mm.marc_marcaid" +
        '" JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid = cc.cole_coleccionid" +
        '" JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid" +
        '" JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid" +
        '" JOIN Programacion.Colores AS cl ON ep.espr_colorid = cl.color_colorid" +
        '" JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid" +
        '" WHERE V.lvcl_clienteid = " + IdCliente.ToString + " " +
        '" order by a.lpch_finprecio DESC"

        Dim cadena As String = "SELECT	pb.lpba_codigolistabase AS 'Lista Base',	CLI.clie_nombregenerico AS 'Cliente',	mm.marc_descripcion AS 'Marca',	cc.cole_descripcion AS 'Colección'," +
    " pp.prod_codigo AS 'Código',	pl.piel_descripcion + ' ' + cl.color_descripcion AS 'Piel/Color',	tt.talla_descripcion AS 'Corrida'," +
    " pe.pres_codSicy AS 'SICY',	lv.lpvt_descripcion as 'LV',	mo.mone_nombre as 'Moneda',	[lpch_precio_antes] AS 'Precio Ant'," +
    " [lpch_precio_despues] AS 'Precio Act',	([lpch_precio_despues] - [lpch_precio_antes]) AS 'Diferencia',	[lpch_precioextranjero_antes] AS 'Precio Extr Ant'," +
    " [lpch_precioextranjero_despues] AS 'Precio Extr Act',	[lpch_inicioprecio] AS 'Inicio Precio Ant (Hr)'," +
    " [lpch_finprecio] AS 'Fin Precio Ant (Hr)',	user_nombrereal AS 'Modificó',	CONVERT(varchar(10), [lpch_inicioprecio], 103) AS 'Inicio Precio Ant'," +
    " CONVERT(varchar(10), [lpch_finprecio], 103) AS 'Fin Precio Ant',	'StListaBASE'=" +
    "  case pb.lpba_estatus		when 1 then 'ACTIVA' 		when 2 then 'AUTORIZADA' 		when 3 then 'INACTIVA' 		END,	e.esta_nombre as 'StListaVentas'" +
    " FROM [Ventas].[ListaPrecioClienteProducto_Hist] AS A" +
    " JOIN Framework.Usuarios AS u ON u.user_usuarioid = a.lpch_usuarioid" +
    " join Ventas.ListaPrecioClienteProducto cp on cp.lpcp_listaprecioclienteproductoid=a.lpch_listaprecioclienteproductoid" +
    " join Ventas.ListaVentasClientePrecio vcp on vcp.lvcp_listaventasclienteprecioid=cp.lpcp_listaventasclienteid" +
    " join Ventas.ListaVentasCliente vc on vc.lvcl_listaventasclienteid=vcp.lvcp_listaventasclienteid" +
    " JOIN Ventas.ListaPreciosVenta lv on lv.lpvt_listaprecioventaid=vc.lvcl_listaprecioventasid" +
    " JOIN Ventas.ListaPreciosBase pb on pb.lpba_listapreciosbaseid=lv.lpvt_listapreciosbaseid" +
    " JOIN Framework.Moneda mo on mo.mone_monedaid=a.lpch_monedaid" +
    " JOIN Cliente.Cliente AS CLI	ON CLI.clie_clienteid = vc.lvcl_clienteid" +
    " JOIN Programacion.ProductoEstilo PE 	ON Pe.pres_productoestiloid = A.lpch_productoestiloid" +
    " JOIN Programacion.Productos PP	ON PP.prod_productoid = PE.pres_productoid" +
    " JOIN Programacion.Marcas AS mm	ON pp.prod_marcaid = mm.marc_marcaid" +
    " JOIN Programacion.Colecciones AS cc	ON pp.prod_coleccionid = cc.cole_coleccionid" +
    " JOIN Programacion.EstilosProducto AS ep	ON pe.pres_estiloid = ep.espr_estiloproductoid" +
    " JOIN Programacion.Pieles AS pl	ON ep.espr_pielid = pl.piel_pielid" +
    " JOIN Programacion.Colores AS cl	ON ep.espr_colorid = cl.color_colorid" +
    " JOIN Programacion.Tallas AS tt	ON ep.espr_tallaid = tt.talla_tallaid" +
    " join Framework.Estatus e on e.esta_estatusid=vcp.lvcp_estatusid" +
        " WHERE vc.lvcl_clienteid= " + IdCliente.ToString + " " +
        " order by a.lpch_finprecio DESC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function RecuperarListasBaseExistentes() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT lpba_listapreciosbaseid, case when lpba_estatus = 1 then" +
                            " lpba_codigolistabase + ' - ' + lpba_nombrelista + ' - (ACTIVA)'" +
                            " ELSE case when lpba_estatus = 2 then" +
                            " lpba_codigolistabase + ' - ' + lpba_nombrelista + ' - (AUTORIZADA)'" +
                            " ELSE" +
                            " lpba_codigolistabase + ' - ' + lpba_nombrelista + ' - (INACTIVA)'" +
                            " END END AS LISTABASE" +
                            " FROM Ventas.ListaPreciosBase where lpba_estatus in (1,2)" +
                            " ORDER BY lpba_estatus DESC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function RecuperarMarcaJe_Modelaje(ByVal IdCliente As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim Consulta As String = ""
        Consulta = " Select (SELECT COUNT(clme_clientemarcaid) FROM Programacion.ClienteMarcaEspecial WHERE clme_clienteid = " + IdCliente.ToString + " AND clme_activo = 1) as 'Marca', " +
            " (SELECT COUNT(*) FROM Programacion.ColeccionMarca WHERE  coma_clienteid = " + IdCliente.ToString + " AND coma_activo = 1) as 'Modelos'"
        Return objPersistencia.EjecutaConsulta(Consulta)
    End Function

    Public Function consultarListaPreciosSimulador(ByVal idListaCliente As Int32,
                                     ByVal idCLiente As Int32,
                                     ByVal agentes As String,
                                     ByVal familias As Boolean,
                                     ByVal colecciones As Boolean,
                                     ByVal ArticulosPedidos As Boolean,
                                     ByVal fechaInicio As String,
                                     ByVal fechafIN As String,
                                     ByVal Marcas As String,
                                     ByVal IdMoneda As Integer,
                                     ByVal Paridad As Double,
                                     ByVal Incremento As Double,
                                     ByVal Incremento_Porcentaje_Cantidad As Boolean) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idListaCliente"
        parametro.Value = idListaCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idCliente"
        parametro.Value = idCLiente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idAgente"
        parametro.Value = agentes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@familias"
        parametro.Value = familias
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colecciones"
        parametro.Value = colecciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ArticulosPedidos"
        parametro.Value = ArticulosPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechafIN"
        parametro.Value = fechafIN
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Marcas"
        parametro.Value = Marcas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdMoneda"
        parametro.Value = IdMoneda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Paridad"
        parametro.Value = Paridad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Incremento"
        parametro.Value = Incremento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Incremento_Porcentaje_Cantidad"
        parametro.Value = Incremento_Porcentaje_Cantidad
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Ventas.SP_ConsultarListaVentasSimulador", listaParametros)
    End Function

    Public Function consultaListaPreciosClientesPrecioArticulo(ByVal idListaBase As Int32, ByVal idProductoEstilo As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        ' MsgBox(idListaBase)
        ' MsgBox(idProductoEstilo)

        Dim cadena As String = ""
        cadena = "SELECT CAST(0 AS bit) AS Seleccion, lvcp.lvcp_listaventasclienteprecioid, lb.lpba_listapreciosbaseid, lb.lpba_nombrelista, cl.clie_clienteid, cl.clie_idsicy," +
        " cl.clie_nombregenerico, lvcp.lvcp_descripcion, lv.lpvt_listaprecioventaid, lv.lpvt_incrementoporpar, lv.lpvt_porcentaje, pr.pres_productoestiloid," +
        " lcp.lpcp_preciobase, lcp.lpcp_preciocalculado, lcp.lpcp_precio, lcp.lpcp_precio AS PrecioAnterior, lcp.lpcp_precioextranjero," +
        " lcp.lpcp_preciocalculadoextranjero, m.marc_decimales, lvcp.lvcp_monedaid, lvcp.lvcp_paridad, IC.iccl_calcularpreciocondescuento, lvcp.lvcp_descuento," +
        " CASE " +
        " WHEN lb.lpba_estatus = 1" +
        " THEN" +
        " CAST((SELECT COUNT(cdlv_clientedescuentoid) AS TOTAL FROM Ventas.ClienteDescuentosListaVentas WHERE cdlv_activo = 1 AND" +
        " cdlv_clienteid = cl.clie_clienteid AND cdvl_listaventasid = lv.lpvt_listaprecioventaid) AS varchar(100))" +
        " ELSE" +
        " '0'" +
        " END AS DESCUENTOS" +
        " FROM Programacion.Productos p" +
        " JOIN Programacion.ProductoEstilo pr ON p.prod_productoid = pr.pres_productoid" +
        " JOIN Programacion.Marcas m ON p.prod_marcaid = m.marc_marcaid" +
        " JOIN Ventas.ListaPrecioBaseProducto lpbp ON pr.pres_productoestiloid = lpbp.lpbp_productoestiloid" +
        " JOIN Ventas.ListaPreciosBase lb ON lpbp.lpbp_listapreciosbaseid = lb.lpba_listapreciosbaseid" +
        " JOIN Ventas.ListaPrecioClienteProducto lcp ON pr.pres_productoestiloid = lcp.lpcp_productoestiloid" +
        " JOIN Ventas.ListaVentasClientePrecio lvcp ON lcp.lpcp_listaventasclienteid = lvcp.lvcp_listaventasclienteprecioid" +
        " JOIN Ventas.ListaVentasCliente lvc ON lvcp.lvcp_listaventasclienteid = lvc.lvcl_listaventasclienteid" +
        " JOIN Ventas.ListaPreciosVenta lv ON lvc.lvcl_listaprecioventasid = lv.lpvt_listaprecioventaid" +
        " AND lv.lpvt_listapreciosbaseid = lb.lpba_listapreciosbaseid" +
        " JOIN Cliente.Cliente cl ON lvc.lvcl_clienteid = cl.clie_clienteid" +
        " JOIN Cobranza.InfoCliente IC ON CL.clie_clienteid = IC.iccl_clienteid" +
        " WHERE cl.clie_activo = 1 And lcp.lpcp_activo = 1 And lvc.lvcl_activo = 1 And lvcp.lvcp_activo = 1 And pr.pres_activo = 1" +
        " AND lv.lpvt_activo = 1 AND IC.iccl_activo = 1 AND lvcp.lvcp_estatusid in (25,26)" +
        " AND lb.lpba_listapreciosbaseid = " + idListaBase.ToString +
        " AND pr.pres_productoestiloid = " + idProductoEstilo.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ResumenListaDePreciosBase(ByVal idListaBase As Int16) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ListaPrecioBaseID"
        parametro.Value = idListaBase
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_ListasPrecio_ResumenListaBase]", listaParametros)
    End Function
End Class
