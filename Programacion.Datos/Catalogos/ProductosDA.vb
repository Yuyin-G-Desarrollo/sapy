Imports System.Data.SqlClient

Public Class ProductosDA
    Public Function actualizarEstatus(ByVal idProducto As Integer, ByVal estilo As Integer, ByVal productoestilo As Integer, ByVal estatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        ParametroParaLista = New SqlParameter("@idProducto", idProducto)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@estilo", estilo)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@productoestilo", productoestilo)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@estatus", estatus)
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Editar_Producto_Estatus]", ListaParametros)
    End Function

    Public Function validarConsumos(ByVal idProducto As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
        select isnull(sum(isnull(pres_totalconsumos,0)),0) 'consumos' from Programacion.ProductoEstilo where pres_productoid=<%= idProducto %>
                                 </cadena>
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function getNaveDesarrolla(ByVal idProducto As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = <cadena>
                                     SELECT isnull(pres_navedesarrollaid,0)'naveDes'  FROM Programacion.ProductoEstilo where pres_productoid=
                                 </cadena>
        consulta += " " & idProducto
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function VerListaProductos(ByVal activo As Boolean, ByVal idcedis As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@idCedis", idcedis)
        ListaParametros.Add(ParametroParaLista)

        'Return operacion.EjecutarConsultaSP("Programacion.SP_ListaProductos", ListaParametros)
        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ListaProductosYLicencias]", ListaParametros)

        'Dim operacion As New Persistencia.OperacionesProcedimientos

        'Dim consulta As String = "SELECT pp.prod_productoid, pp.prod_codigo, pp.prod_modelo, mm.marc_descripcion," +
        '" cc.cole_descripcion, pp.prod_descripcion," +
        '" (SELECT Programacion.FN_ConcatenarSubfamilias(pp.prod_productoid)) AS Subfamilias," +
        '" tc.tica_tipocategoriaid, tc.tica_descripcion, pp.prod_activo," +
        '" pp.prod_foto, tt.temp_nombre, tt.temp_año, pp.prod_dibujo" +
        '" FROM Programacion.Productos AS pp" +
        '" JOIN Programacion.Marcas AS mm ON pp.prod_marcaid = mm.marc_marcaid" +
        '" JOIN Programacion.Colecciones AS cc ON pp.prod_coleccionid = cc.cole_coleccionid" +
        '" JOIN Programacion.Temporadas AS tt ON pp.prod_temporadaid = tt.temp_temporadaid" +
        '" JOIN Programacion.TipoCategoria tc ON pp.prod_categoria = tc.tica_tipocategoriaid" +
        '" WHERE pp.prod_activo = '" + activo.ToString + "'" +
        '" AND mm.marc_activo = 1 AND cc.cole_activo = 1 AND tt.temp_activo = 1" +
        '" GROUP BY	pp.prod_productoid, pp.prod_codigo, pp.prod_modelo, pp.prod_descripcion," +
        '" mm.marc_descripcion, cc.cole_descripcion,tt.temp_nombre,tt.temp_año," +
        '" pp.prod_activo,pp.prod_foto,pp.prod_dibujo," +
        '" tc.tica_tipocategoriaid,tc.tica_descripcion ORDER BY pp.prod_codigo"

        'Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function verDetallesProducto(ByVal idProducto As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "Select pe.pres_productoestiloid, pl.piel_descripcion," +
    " cc.color_descripcion,	tt.talla_descripcion, fa.fami_descripcion, ln.linea_descripcion," +
    " pm.plmu_descripcion, ff.forr_descripcion,	ss.suel_descripcion, hh.horma_descripcion," +
    " pe.pres_codSicy,	st.stpr_descripcion, pe.pres_imagen ,pe.pres_imagenlogomarcacliente" +
                        " FROM Programacion.Productos AS pr" +
                        " INNER JOIN Programacion.ProductoEstilo AS pe" +
                            " ON pr.prod_productoid = pe.pres_productoid" +
                        " LEFT JOIN Programacion.Hormas AS hh" +
                            " ON pe.pres_horma = hh.horma_hormaid" +
                        " INNER JOIN Programacion.EstilosProducto AS ep" +
                            " ON pe.pres_estiloid = ep.espr_estiloproductoid" +
                        " INNER JOIN Programacion.Pieles AS pl" +
                            " ON ep.espr_pielid = pl.piel_pielid" +
                        " LEFT JOIN Programacion.Familias AS fa" +
                            " ON pe.pres_familiaid = fa.fami_familiaid" +
                        " INNER JOIN Programacion.Tallas AS tt" +
                            " ON ep.espr_tallaid = tt.talla_tallaid" +
                        " INNER JOIN Programacion.Colores AS cc" +
                            " ON ep.espr_colorid = cc.color_colorid" +
                        " INNER JOIN Programacion.PielMuestras AS pm" +
                            " ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid" +
                        " INNER JOIN Programacion.Forros AS ff" +
                            " ON ep.espr_forroid = ff.forr_forroid" +
                        " INNER JOIN Programacion.Suelas AS ss" +
                            " ON ep.espr_suelaid = ss.suel_suelaid" +
                        " LEFT JOIN Programacion.Lineas ln" +
                            " ON pe.pres_lineaid = ln.linea_lineaid" +
                        " INNER JOIN Programacion.EstatusProducto st" +
                            " ON pe.pres_estatus = st.stpr_productoStatusId" +
                                " WHERE pr.prod_productoid = " + idProducto +
                        " AND pl.piel_activo = 1" +
                        " AND tt.talla_activo = 1" +
                        " AND cc.color_activo = 1" +
                        " AND pm.plmu_activo = 1" +
                        " AND ff.forr_activo = 1" +
                        " AND ss.suel_activo = 1" +
                        " AND pe.pres_activo = 1" +
                        " AND hh.horma_activo = 1"
        Return operacion.EjecutaConsulta(consulta)
    End Function



    Public Function validarExistenciaFamilia(ByVal codFamilia As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select" +
                                         " fami_familiaid, fami_descripcion from Programacion.Familias" +
                                         " where fami_codigo ='" + codFamilia + "' and fami_activo ='True'")
    End Function

    Public Function validarExistenciaSubfamilia(ByVal idSubfamilia As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select" +
                                         " subf_subfamiliaid, subf_descripcion" +
                                         " from Programacion.Subfamilia where subf_subfamiliaid ='" + idSubfamilia + "' and subf_activo ='True'")
    End Function

    Public Sub RegistrarProducto(ByVal EnProducto As Entidades.Productos, ByVal modelo As String, ByVal idcedis As Integer, ByVal esLicencia As Boolean, cola As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)



        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@descripcion"
        ParametroParaLista.Value = EnProducto.PDescripcionProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = EnProducto.PMarcaProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = EnProducto.PColeccionProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = EnProducto.PTemporadaProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idGrupo"
        ParametroParaLista.Value = EnProducto.PGrupoProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@urlFoto"
        If (EnProducto.PFoto <> "") Then
            ParametroParaLista.Value = EnProducto.PFoto
        Else
            ParametroParaLista.Value = ""
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@urlDibujo"
        If (EnProducto.PDibujo <> "") Then
            ParametroParaLista.Value = EnProducto.PDibujo
        Else
            ParametroParaLista.Value = ""
        End If
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = EnProducto.PActivoProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codcliente"
        ParametroParaLista.Value = EnProducto.PCodCliente
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@categoria"
        ParametroParaLista.Value = EnProducto.PCategoria
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@idCedis", idcedis)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@esLicencia", idcedis)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@modeloSAYLicencia", EnProducto.PmodeloSAYLicencia)
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter("@cola", cola)
        ListaParametros.Add(ParametroParaLista)

        'operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Producto", ListaParametros)
        operacion.EjecutarSentenciaSP("[Programacion].[SP_Alta_ProductoYLicencias]", ListaParametros)

    End Sub

    Public Sub RegistrarDetallesProducto(ByVal idPiel As Int32, ByVal idFamilia As Int32, ByVal idTalla As Int32,
                                        ByVal idColor As Int32, ByVal idCorte As Int32, ByVal idForro As Int32,
                                        ByVal idSuela As Int32, ByVal codSicyP As String, ByVal activo As Boolean,
                                        ByVal idHorma As Int32, ByVal sicyMarca As String, ByVal idProducto As Int32,
                                        ByVal estatusPres As Int32, ByVal idLinea As Int32, ByVal idFamiliaVentas As Int32, idClaveSAT As String, ByVal SuelaProgramacionID As Integer,
                                        ByVal ColorSuelaID As Integer, ByVal modeloreferencia As String)


        Dim codSicyReal As String = ""
        Dim dtValidaSicy As New DataTable
        'Dim BdSicy As New Persistencia.OperacionesProcedimientosSICY

        'dtValidaSicy = BdSicy.EjecutaConsulta("select COUNT(*) from vEstilos where IdCodigo ='" + codSicyP + "'")
        'If (CInt(dtValidaSicy.Rows(0)(0).ToString) > 0) Then
        '    codSicyReal = codSicyP
        'Else
        '    codSicyReal = ""
        'End If

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idPiel"
        ParametroParaLista.Value = idPiel.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamilia"
        ParametroParaLista.Value = idFamilia.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTalla"
        ParametroParaLista.Value = idTalla.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColor"
        ParametroParaLista.Value = idColor.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCorte"
        ParametroParaLista.Value = idCorte.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idForro"
        ParametroParaLista.Value = idForro.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idSuela"
        ParametroParaLista.Value = idSuela.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = activo.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codigoSicy"
        ParametroParaLista.Value = codSicyP
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@horma"
        ParametroParaLista.Value = idHorma.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@sicyMarca"
        ParametroParaLista.Value = sicyMarca
        ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "@idMarca"
        'ParametroParaLista.Value = idMarca.ToString
        'ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "@idColeccion"
        'ParametroParaLista.Value = idColeccion.To2724tring
        'ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = idProducto.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@estatusProd"
        ParametroParaLista.Value = estatusPres.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idLinea"
        ParametroParaLista.Value = idLinea.ToString
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamiliaVentas"
        ParametroParaLista.Value = idFamiliaVentas
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idClaveSAT"
        ParametroParaLista.Value = idClaveSAT
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@SuelaProgramacionID"
        ParametroParaLista.Value = SuelaProgramacionID
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@ColorSuelaID"
        ParametroParaLista.Value = ColorSuelaID
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@ModeloReferencia"
        ParametroParaLista.Value = modeloreferencia
        ListaParametros.Add(ParametroParaLista)


        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Detalles_Producto", ListaParametros)

    End Sub

    Public Function buscarClaveFamiliaProyeccion(familiaVentas As String) As Integer
        Dim objOperacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim clave As Int32 = 0
        Dim dtFamiliaProyeccion As New DataTable

        'consulta = "select pcsc_clavesat_detallada as idClaveSAT,  pcsc_clavesat_detallada  +'-' +d.pcsd_descripciondetallada as 'Clave SAT' from "
        'consulta += " Programacion.ProductoClaveSAT_Configuracion c"
        'consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
        'consulta += " where pcsc_tipocategoriaid = " + categoriaId.ToString + " and pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " "
        'dtFamiliaProyeccion = objOperacionesSay.EjecutaConsulta(consulta)

        If dtFamiliaProyeccion.Rows.Count > 0 Then
            'Sel cambio  para que enviara el id originalmente manda a CLave SAT
            clave = dtFamiliaProyeccion.Rows(0).Item("idFamiliaProyeccion")
            Return clave
            Exit Function
        End If
    End Function

    Public Function ValidarProductoenPedidos(idProducto As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = idProducto
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Modelos_ValidaProductoenPedidos]", ListaParametros)
    End Function

    Public Function validaCodSicy(ByVal codSicy As String) As DataTable

        Dim dtValidaSicy As New DataTable
        Dim BdSicy As New Persistencia.OperacionesProcedimientosSICY

        dtValidaSicy = BdSicy.EjecutaConsulta("select COUNT(*) from vEstilos where IdCodigo ='" + codSicy + "'")
        Return dtValidaSicy

    End Function

    Public Function validarExistenciaProducto(ByVal codigoProducto As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@modeloSAY"
        ParametroParaLista.Value = codigoProducto
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[AltaModelos_ValidarExistenciasDeProductos]", ListaParametros)
    End Function

    Public Function verTallasSeleccionadasProducto(ByVal idProducto As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT tt.talla_tallaid, tt.talla_descripcion, tt.talla_sicy, pp.prod_activo AS selectTalla" +
        " FROM Programacion.Tallas AS tt" +
        " INNER JOIN Framework.Paises AS pa ON tt.talla_paisid = pa.pais_paisid" +
        " INNER JOIN Programacion.EstilosProducto AS sp ON tt.talla_tallaid = sp.espr_tallaid" +
        " INNER JOIN Programacion.ProductoEstilo AS ps ON sp.espr_estiloproductoid = ps.pres_estiloid" +
        " INNER JOIN Programacion.Productos AS pp ON ps.pres_productoid = pp.prod_productoid" +
        " WHERE pp.prod_productoid = " + idProducto.ToUpper +
        " AND pp.prod_activo = 'True'" +
        " AND ps.pres_activo = 'True'" +
        " AND tt.talla_paisid = 1" +
        " AND pa.pais_paisid = 1" +
        " GROUP BY tt.talla_tallaid, tt.talla_descripcion, tt.talla_sicy, pp.prod_activo " +
        " UNION ALL" +
        " SELECT talla_tallaid, talla_descripcion, talla_sicy, 0 AS selectTalla" +
        " FROM Programacion.Tallas" +
        " INNER JOIN Framework.Paises AS pa ON talla_paisid = pa.pais_paisid" +
        " WHERE talla_activo = 'true'" +
        " AND talla_paisid =1" +
        " AND talla_tallaid NOT IN (SELECT tt.talla_tallaid FROM Programacion.Tallas AS tt" +
        " INNER JOIN Framework.Paises AS pa ON tt.talla_paisid = pa.pais_paisid" +
        " INNER JOIN Programacion.EstilosProducto AS sp ON tt.talla_tallaid = sp.espr_tallaid" +
        " INNER JOIN Programacion.ProductoEstilo AS ps ON sp.espr_estiloproductoid = ps.pres_estiloid" +
        " INNER JOIN Programacion.Productos AS pp ON ps.pres_productoid = pp.prod_productoid" +
        " WHERE pp.prod_productoid = " + idProducto.ToUpper +
        " AND pp.prod_activo = 'True' AND ps.pres_activo = 'True' " +
        " GROUP BY tt.talla_tallaid, tt.talla_descripcion, tt.talla_sicy, pp.prod_activo)" +
        " ORDER BY talla_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verPielesSeleccionadasProducto(ByVal idProducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "idProducto"
        ParametroParaLista.Value = idProducto
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Consulta_Piel_Color", ListaParametros)
    End Function

    Public Function verForrosSeleccionadosProducto(ByVal idProducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select fl.forr_forroid , fl.forr_codigo , fl.forr_descripcion , pp.prod_activo as selectForro  from Programacion.Forros as fl" +
                                         " inner join Programacion.EstilosProducto  as sp on fl.forr_forroid   =sp.espr_forroid" +
                                         " inner join Programacion.ProductoEstilo as ps on sp.espr_estiloproductoid =ps.pres_estiloid" +
                                         " inner join Programacion.Productos as pp on ps.pres_productoid =pp.prod_productoid" +
                                         " where pp.prod_productoid =" + idProducto + " and pp.prod_activo ='True' and ps.pres_activo ='True'" +
                                         " group by fl.forr_forroid , fl.forr_codigo , fl.forr_descripcion , pp.prod_activo" +
                                         " union all" +
                                         " select fl.forr_forroid , fl.forr_codigo , fl.forr_descripcion , 0 as selectForro  from Programacion.Forros as fl" +
                                         " where fl.forr_activo  ='True' and fl.forr_forroid  not in (select fl.forr_forroid from Programacion.Forros as fl" +
                                         " inner join Programacion.EstilosProducto  as sp on fl.forr_forroid   =sp.espr_forroid" +
                                         " inner join Programacion.ProductoEstilo as ps on sp.espr_estiloproductoid =ps.pres_estiloid" +
                                         " inner join Programacion.Productos as pp on ps.pres_productoid =pp.prod_productoid" +
                                         " where pp.prod_productoid =" + idProducto + " and pp.prod_activo ='True' and ps.pres_activo ='True'" +
                                         " group by fl.forr_forroid , fl.forr_codigo , fl.forr_descripcion , pp.prod_activo) order by fl.forr_descripcion "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verSuelasSeleccionadasProducto(ByVal idProducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select sl.suel_suelaid, sl.suel_codigo, sl.suel_descripcion, pp.prod_activo as selectSuela from Programacion.Suelas  as sl" +
                                         " inner join Programacion.EstilosProducto  as sp on sl.suel_suelaid   =sp.espr_suelaid" +
                                         " inner join Programacion.ProductoEstilo as ps on sp.espr_estiloproductoid =ps.pres_estiloid" +
                                         " inner join Programacion.Productos as pp on ps.pres_productoid =pp.prod_productoid" +
                                         " where pp.prod_productoid =" + idProducto + " and pp.prod_activo ='True' and ps.pres_activo ='True'" +
                                         " group by suel_suelaid, sl.suel_codigo, sl.suel_descripcion, pp.prod_activo" +
                                         " union all" +
                                         " select suel_suelaid, sl.suel_codigo, sl.suel_descripcion, 0 as selectSuela from Programacion.Suelas as sl" +
                                         " where sl.suel_activo ='True' and sl.suel_suelaid not in(select sl.suel_suelaid from Programacion.Suelas as sl" +
                                         " inner join Programacion.EstilosProducto  as sp on sl.suel_suelaid   =sp.espr_suelaid" +
                                         " inner join Programacion.ProductoEstilo as ps on sp.espr_estiloproductoid =ps.pres_estiloid" +
                                         " inner join Programacion.Productos as pp on ps.pres_productoid =pp.prod_productoid" +
                                         " where pp.prod_productoid =" + idProducto + " and pp.prod_activo ='True' and ps.pres_activo ='True'" +
                                         " group by suel_suelaid , sl.suel_codigo  , sl.suel_descripcion  , pp.prod_activo) order by sl.suel_descripcion "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verCortesSeleccionadasProducto(ByVal idProducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select pl.plmu_pielmuestraid  , pl.plmu_codigo   , pl.plmu_descripcion , pp.prod_activo as selectCorte from Programacion.PielMuestras as pl" +
                                        " inner join Programacion.EstilosProducto  as sp on pl.plmu_pielmuestraid   =sp.espr_pielmuestraid" +
                                        " inner join Programacion.ProductoEstilo as ps on sp.espr_estiloproductoid =ps.pres_estiloid" +
                                        " inner join Programacion.Productos as pp on ps.pres_productoid =pp.prod_productoid" +
                                        " where pp.prod_productoid =" + idProducto + " and pp.prod_activo ='True' and ps.pres_activo ='True'" +
                                        " group by pl.plmu_pielmuestraid  , pl.plmu_codigo   , pl.plmu_descripcion , pp.prod_activo" +
                                        " union all" +
                                        " select pl.plmu_pielmuestraid  , pl.plmu_codigo   , pl.plmu_descripcion , 0 as selectCorte  from Programacion.PielMuestras as pl" +
                                        " where pl.plmu_activo  ='True' and pl.plmu_pielmuestraid  not in(select pl.plmu_pielmuestraid from Programacion.PielMuestras as pl" +
                                        " inner join Programacion.EstilosProducto  as sp on pl.plmu_pielmuestraid   =sp.espr_pielmuestraid" +
                                        " inner join Programacion.ProductoEstilo as ps on sp.espr_estiloproductoid =ps.pres_estiloid" +
                                        " inner join Programacion.Productos as pp on ps.pres_productoid =pp.prod_productoid " +
                                        " where pp.prod_productoid =" + idProducto + " and pp.prod_activo ='True' and ps.pres_activo ='True'" +
                                        " group by pl.plmu_pielmuestraid , pl.plmu_codigo , pl.plmu_descripcion , pp.prod_activo) order by pl.plmu_descripcion "
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verFamiliaSeleccionadasProducto(ByVal idproducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                    " b.fami_familiaid," +
                                    " b.fami_codigo," +
                                    " b.fami_descripcion," +
                                    " a.pres_activo as selectFamilia" +
                            " FROM Programacion.ProductoEstilo a" +
                            " INNER JOIN Programacion.Familias b" +
                                " ON a.pres_familiaid = b.fami_familiaid" +
                                    " WHERE a.pres_productoid = " + idproducto +
                            " AND a.pres_activo = 1" +
                            " AND b.fami_activo = 1" +
                            " GROUP BY	b.fami_familiaid," +
                                    " b.fami_codigo," +
                                    " b.fami_descripcion," +
                                    " a.pres_activo" +
                                    " UNION ALL" +
                            " SELECT fami_familiaid," +
                                    " fami_codigo," +
                                    " fami_descripcion," +
                                    " 0 as selectFamilia" +
                                    " FROM Programacion.Familias" +
                            " WHERE fami_familiaid NOT IN (SELECT" +
                                    " b.fami_familiaid" +
                            " FROM Programacion.ProductoEstilo a" +
                            " INNER JOIN Programacion.Familias b" +
                                " ON a.pres_familiaid = b.fami_familiaid" +
                                    " WHERE a.pres_productoid = " + idproducto +
                            " AND a.pres_activo = 1" +
                            " AND b.fami_activo = 1" +
                            " GROUP BY b.fami_familiaid)" +
                            " AND fami_activo = 1 " +
                            " ORDER by b.fami_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verLineasSeleccionadasProducto(ByVal idproducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " b.linea_lineaid, b.linea_descripcion," +
                                " b.linea_activo, a.pres_activo as selectLinea" +
                        " FROM Programacion.ProductoEstilo a" +
                        " INNER JOIN Programacion.Lineas b" +
                            " ON a.pres_lineaid = b.linea_lineaid" +
                                " WHERE a.pres_productoid = " + idproducto +
                        " AND a.pres_activo = 1" +
                        " AND b.linea_activo = 1" +
                        " GROUP BY	b.linea_lineaid," +
                                " b.linea_descripcion," +
                                " b.linea_activo," +
                                " a.pres_activo" +
                                " UNION ALL" +
                        " SELECT linea_lineaid," +
                                " linea_descripcion, linea_activo," +
                                " 0 as selectLinea" +
                        " FROM Programacion.Lineas" +
                        " WHERE linea_lineaid NOT IN (SELECT" +
                                " b.linea_lineaid" +
                        " FROM Programacion.ProductoEstilo a" +
                        " INNER JOIN Programacion.Lineas b" +
                            " ON a.pres_lineaid = b.linea_lineaid" +
                               " WHERE a.pres_productoid = " + idproducto +
                        " AND a.pres_activo = 1" +
                        " AND b.linea_activo = 1)" +
                        " AND linea_activo = 1 " +
                        " ORDER by b.linea_lineaid"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verDetallesProductoEditar(ByVal idProducto As String) As DataTable

        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro.ParameterName = "@ProductoId"
            parametro.Value = idProducto
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_Modelos_DetallesProducto]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try


        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT pe.pres_productoestiloid AS pstilo," +
        '        "    pl.piel_pielid AS idPiel," +
        '        "    cc.color_colorid AS idColor," +
        '        "    pl.piel_descripcion + ' ' + cc.color_descripcion AS pielColor," +
        '        "    tt.talla_tallaid AS idTalla," +
        '        "    tt.talla_descripcion AS talla," +
        '        "    fm.fami_familiaid AS idFamilia," +
        '        "    fm.fami_descripcion AS familia," +
        '        "    ln.linea_lineaid AS idLinea," +
        '        "    ln.linea_descripcion AS linea," +
        '        "    pe.pres_familiaproyeccionid AS idFamiliaVentas," +
        '        "    fp.fapr_descripcion AS 'familia ventas'," +
        '        "    pm.plmu_pielmuestraid AS idCorte," +
        '        "    pm.plmu_descripcion AS corte," +
        '        "    ff.forr_forroid AS idForro," +
        '        "    ff.forr_descripcion AS forro," +
        '        "    ss.suel_suelaid AS idSuela," +
        '        "    ss.suel_descripcion AS suela," +
        '        "    hh.horma_hormaid AS idHorma," +
        '        "    hh.horma_descripcion AS Horma," +
        '        "    pe.pres_codSicy AS Sicy," +
        '        "    pl.piel_codsicy + cc.color_codsicy AS sicyPCOL," +
        '        "    pe.pres_sicyMarca AS IdMarcaCasa," +
        '        "    [Programacion].[Fn_Concatenar_Fracciones_Arancelarias](tt.talla_tallaid,fm.fami_familiaid,pm.plmu_pielmuestraid,ff.forr_forroid,ss.suel_suelaid,prod_categoria) as 'Fracción_Arancelaria'," +
        '        "    pe.pres_estatus AS psEstatus," +
        '        "    st.stpr_descripcion AS nomSts," +
        '        "    0 AS seleccion," +
        '        "    pp.prod_categoria as IdTipo," +
        '        "    tica.tica_descripcion as Tipo," +
        '        "    pe.pres_articulonuevo as Nuevo," +
        '        "    pres_clavesat_detallada as idClaveSAT, pres_clavesat_detallada + '-' + pcd.pcsd_descripciondetallada 'ClaveSAT'  " +
        '        "    FROM Programacion.Productos AS pp" +
        '        "    INNER JOIN Programacion.ProductoEstilo AS pe ON pp.prod_productoid = pe.pres_productoid" +
        '        "    LEFT JOIN Programacion.ProductoClaveSAT_Detallada AS pcd" +
        '        "    ON pe.pres_clavesat_detallada = pcd.pcsd_clavesat_detallada" +
        '        "    inner join Programacion.TipoCategoria as tica on tica.tica_tipocategoriaid = pp.prod_categoria" +
        '        "    LEFT JOIN Programacion.Hormas AS hh ON pe.pres_horma = hh.horma_hormaid" +
        '        "    INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid" +
        '        "    LEFT JOIN Programacion.Familias AS fm ON pe.pres_familiaid = fm.fami_familiaid" +
        '        " LEFT JOIN Programacion.Lineas AS ln ON pe.pres_lineaid = ln.linea_lineaid" +
        '        " INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid" +
        '        " INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid" +
        '        " INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid" +
        '        " INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid" +
        '        " INNER JOIN Programacion.Suelas AS ss ON ep.espr_suelaid = ss.suel_suelaid" +
        '        " INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid" +
        '        " INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId" +
        '        " LEFT JOIN Programacion.Familias_Proyeccion AS fp ON fp.fapr_familiaproyeccionid=pe.pres_familiaproyeccionid" +
        '        " WHERE pp.prod_productoid = " + idProducto +
        '        " AND tt.talla_activo = 1" +
        '        " AND cc.color_activo = 1" +
        '        " AND pl.piel_activo = 1" +
        '        " AND ff.forr_activo = 1" +
        '        " AND ss.suel_activo = 1" +
        '        " AND pm.plmu_activo = 1" +
        '        " AND pe.pres_activo = 1" +
        '        " AND hh.horma_activo = 1"

        'Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verDatosPrincipalesProdcucto(ByVal idProducto As String, ByVal activo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@ProductoID"
        ParametroParaLista.Value = idProducto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@Activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Productos_verDatosPrincipalesProdcucto]", ListaParametros)
    End Function


    Public Sub EditarProducto(ByVal EnProducto As Entidades.Productos, ByVal modelo As String)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = EnProducto.PidProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codigo"
        ParametroParaLista.Value = EnProducto.PCodigoProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@descripcion"
        ParametroParaLista.Value = EnProducto.PDescripcionProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idMarca"
        ParametroParaLista.Value = EnProducto.PMarcaProd
        ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "idFamilia"
        'ParametroParaLista.Value = EnProducto.PFamiliaProd
        'ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColeccion"
        ParametroParaLista.Value = EnProducto.PColeccionProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTemporada"
        ParametroParaLista.Value = EnProducto.PTemporadaProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@foto"
        ParametroParaLista.Value = EnProducto.PFoto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@dibujo"
        ParametroParaLista.Value = EnProducto.PDibujo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = EnProducto.PActivoProd
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter
        'ParametroParaLista.ParameterName = "@idGrupo"
        'ParametroParaLista.Value = EnProducto.PGrupoProd
        'ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@consecutivo"
        ParametroParaLista.Value = EnProducto.PConsecutivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@modelo"
        ParametroParaLista.Value = modelo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codCliente"
        ParametroParaLista.Value = EnProducto.PCodCliente
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCategoria"
        ParametroParaLista.Value = EnProducto.PCategoria
        ListaParametros.Add(ParametroParaLista)


        'ParametroParaLista = New SqlParameter("@idCedis", idcedis)
        'ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter("@esLicencia", esLicencia)
        'ListaParametros.Add(ParametroParaLista)

        'ParametroParaLista = New SqlParameter("@modeloSAYLicencia", EnProducto.PmodeloSAYLicencia)
        'ListaParametros.Add(ParametroParaLista)


        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Producto", ListaParametros)
    End Sub

    Public Sub EditarDetallesProducto(ByVal idProducto As String, ByVal idPiel As String, ByVal idTalla As String, ByVal idColor As String,
                                      ByVal idCorte As String, ByVal idForro As String, ByVal idSuela As String, ByVal activo As String,
                                      ByVal codigoSicy As String, ByVal horma As String, ByVal sicyMarca As String, ByVal idFamilia As Int32,
                                      ByVal idLinea As Int32, ByVal idPrEstilo As String, ByVal estatusPres As Int32, ByVal idFamiliaVentas As Int32,
                                      idClaveSAT As String, ByVal SuelaProgramacionId As Integer, ByVal ColorSuelaID As Integer, ByVal ModeloReferencia As String)

        Dim codSicyReal As String = ""
        Dim dtValidaSicy As New DataTable
        'Dim BdSicy As New Persistencia.OperacionesProcedimientosSICY

        'dtValidaSicy = BdSicy.EjecutaConsulta("select COUNT(*) from vEstilos where IdCodigo ='" + codigoSicy + "'")
        'If (CInt(dtValidaSicy.Rows(0)(0).ToString) > 0) Then
        '    codSicyReal = codigoSicy
        'Else
        '    codSicyReal = ""
        'End If

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = idProducto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idPiel"
        ParametroParaLista.Value = idPiel
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTalla"
        ParametroParaLista.Value = idTalla
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColor"
        ParametroParaLista.Value = idColor
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idCorte"
        ParametroParaLista.Value = idCorte
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idForro"
        ParametroParaLista.Value = idForro
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idSuela"
        ParametroParaLista.Value = idSuela
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@codSicy"
        ParametroParaLista.Value = codigoSicy
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@horma"
        ParametroParaLista.Value = horma
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@marcaSicy"
        ParametroParaLista.Value = sicyMarca
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idlinea"
        ParametroParaLista.Value = idLinea
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamilia"
        ParametroParaLista.Value = idFamilia
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idPrEstilo"
        ParametroParaLista.Value = idPrEstilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@estatusPRES"
        ParametroParaLista.Value = estatusPres
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamiliaVentas"
        ParametroParaLista.Value = idFamiliaVentas
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idClaveSAT"
        ParametroParaLista.Value = idClaveSAT
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@SuelaProgramacionId"
        ParametroParaLista.Value = SuelaProgramacionId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@ColorSuelaID"
        ParametroParaLista.Value = ColorSuelaID
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@ModeloReferencia"
        ParametroParaLista.Value = ModeloReferencia
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_Producto_Estilo", ListaParametros)

    End Sub

    Public Sub EditarProductoEstilo(ByVal idProducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim cadena As String = "update Programacion.ProductoEstilo set pres_activo='False', pres_usuariomodifico =" + usuario + " , pres_fechamodificacion =GETDATE() where pres_productoid =" + idProducto + ""
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub desactivarSubfamilias(ByVal idProducto As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim cadena As String = "UPDATE Programacion.ProductoSubfamilias" +
                                " SET prsu_activo = 0," +
                                    " prsu_usuarioModifico = " + usuario + "," +
                                        " prsu_fechaModifico = GETDATE()" +
                                "WHERE prsu_productoid =" + idProducto
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function ValidarRepetidos(ByVal Codigo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("select * from Programacion.Productos where prod_codigo ='" + Codigo + "' and prod_activo ='TRUE'")
    End Function

    Public Function verCodigoProductoRegistrado(ByVal marcaId As String, ByVal coleId As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenas As String = "select prod_productoid, prod_codigo" +
                                " from Programacion.Productos" +
                                " where prod_marcaid =" + marcaId +
                                " and prod_coleccionid =" + coleId +
                                " and prod_productoid =(select MAX(prod_productoid)" +
                                " from programacion.Productos" +
                                " where prod_marcaid =" + marcaId +
                                " and prod_coleccionid =" + coleId + ")"
        Return operacion.EjecutaConsulta(cadenas)
    End Function

    Public Function validaSicyEnProducto(ByVal sicy As String, ByVal idProducto As String, ByVal marca As String, ByVal coleccion As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "select COUNT (*) from Programacion .Productos  where prod_modelo ='" + sicy + "'"
        If (idProducto <> "") Then
            cadena += " and prod_productoid <> " + idProducto + ""
        End If
        cadena += " and prod_marcaid =" + marca + " and prod_coleccionid =" + coleccion + ""

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validaExistenciaModeloSicy(ByVal sicy As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim cadena As String = "select COUNT(*) from vEstilos where IdModelo='" + sicy + "'"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validaExisteSicyMarcaColeccion(ByVal sicy As String, ByVal marca As String, ByVal coleccion As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idMarca", marca)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Coleccion", coleccion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Modelo", sicy)
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ValidaExisteSicyMarcaColeccion]", listaParametros)
        'Dim cadena As String = "SELECT COUNT (*) AS 'TOTAL' " +
        '    "FROM Modelos AS MM" +
        '    " INNER JOIN MarcasColecciones AS MC ON MM.IdLinea = MC.IdLinea" +
        '    " INNER JOIN Marcas AS MA ON MC.IdMarca =MA.IdMarca" +
        '    " INNER JOIN Colecciones AS CC ON MC.IdColeccion =CC.IdColeccion" +
        '    " WHERE MA.IdMarca ='" + marca + "' AND CC.IdColeccion ='" + coleccion + "' AND MM.IDMODELO='" + sicy + "'"
        'Return operacion.EjecutaConsulta(cadena)


    End Function

    'Public Function cargacadena() As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim cadena As String = "SELECT" +
    '        " a.prod_productoid, a.prod_codigo, b.pres_productoid, b.pres_codSicy, COUNT(b.pres_codSicy) cs" +
    '        " FROM Programacion.Productos a" +
    '        " INNER JOIN Programacion.ProductoEstilo b ON a.prod_productoid = b.pres_productoid" +
    '        " WHERE b.pres_activo = 1 GROUP BY	a.prod_productoid, a.prod_codigo, b.pres_productoid,  b.pres_codSicy"
    '    Return operacion.EjecutaConsulta(cadena)
    'End Function
    Public Function estatusProductos2() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " stpr_productoStatusId," +
                                " stpr_descripcion," +
                                " stpr_activo" +
                                " FROM Programacion.EstatusProducto" +
                        " WHERE stpr_activo = 1 and stpr_descripcion in ('Prototipo','Muestra')"
        Return operacion.EjecutaConsulta(cadena)
    End Function
    Public Function estatusProductos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " stpr_productoStatusId," +
                                " stpr_descripcion," +
                                " stpr_activo" +
                                " FROM Programacion.EstatusProducto" +
                        " WHERE stpr_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub guardarProductoSubfamilia(ByVal idProducto As String, ByVal idSubfamilia As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = idProducto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idSubfamilia"
        ParametroParaLista.Value = idSubfamilia
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_Relacion_Producto_subfamilia", ListaParametros)

    End Sub

    Public Function consultaProductoSubfamilias(ByVal idProducto As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " a.prsu_productoid," +
                                " b.subf_subfamiliaid," +
                                " b.subf_descripcion," +
                                " a.prsu_activo" +
                        " FROM Programacion.ProductoSubfamilias a" +
                        " INNER JOIN Programacion.Subfamilia b" +
                            " ON a.prsu_subfamiliaid = b.subf_subfamiliaid" +
                                " WHERE prsu_productoid =" + idProducto.ToString +
                                " AND prsu_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub editarProductoSubfamilia(ByVal idProducto As Int32, ByVal idSubfamilia As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = idProducto
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idSubfamilia"
        ParametroParaLista.Value = idSubfamilia
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuario"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Editar_SunfamiliasProducto", ListaParametros)

    End Sub
    Public Function verModelosRegistrador()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("[Programacion].[SP_Modelos_ModelosRegistrados]")
        '  Dim cadena As String = <cadena>
        '                             SELECT
        '                  0 seleccion,
        '                  0 modificado,
        '               pr.prod_codigo,
        '                  prod_modelo,
        '               pr.prod_descripcion,
        '               gr.grpo_descripcion,
        '               tc.tica_descripcion,
        '               (SELECT
        '                Programacion.FN_ConcatenarSubfamilias(pr.prod_productoid))
        '               AS Subfamilia,
        '                  fp.fapr_descripcion 'Familia Ventas',
        '               tm.temp_nombre,
        '               pl.piel_descripcion,
        '               cc.color_descripcion,
        '               fa.fami_descripcion,
        '               tt.talla_descripcion,
        '               pm.plmu_descripcion,
        '               ff.forr_descripcion,
        '               ln.linea_descripcion,
        '               ss.suel_descripcion,
        '               hh.horma_descripcion,
        '               pe.pres_codSicy,
        '               st.stpr_descripcion,
        'st.stpr_productoStatusId,
        'pe.pres_productoid,
        'pe.pres_productoestiloid,
        'pe.pres_estiloid
        '              FROM Programacion.Productos AS pr
        '              LEFT JOIN Programacion.Grupos gr
        '               ON pr.prod_grupo = gr.grpo_grupoid
        '              LEFT JOIN Programacion.TipoCategoria tc
        '               ON pr.prod_categoria = tc.tica_tipocategoriaid
        '              INNER JOIN Programacion.Temporadas tm
        '               ON pr.prod_temporadaid = tm.temp_temporadaid
        '              INNER JOIN Programacion.ProductoEstilo AS pe
        '               ON pr.prod_productoid = pe.pres_productoid
        '              LEFT JOIN Programacion.Familias_Proyeccion fp
        '               ON fp.fapr_familiaproyeccionid=pe.pres_familiaproyeccionid
        '              LEFT JOIN Programacion.Hormas AS hh
        '               ON pe.pres_horma = hh.horma_hormaid
        '              INNER JOIN Programacion.EstilosProducto AS ep
        '               ON pe.pres_estiloid = ep.espr_estiloproductoid
        '              INNER JOIN Programacion.Pieles AS pl
        '               ON ep.espr_pielid = pl.piel_pielid
        '              LEFT JOIN Programacion.Familias AS fa
        '               ON pe.pres_familiaid = fa.fami_familiaid
        '              INNER JOIN Programacion.Tallas AS tt
        '               ON ep.espr_tallaid = tt.talla_tallaid
        '              INNER JOIN Programacion.Colores AS cc
        '               ON ep.espr_colorid = cc.color_colorid
        '              INNER JOIN Programacion.PielMuestras AS pm
        '               ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
        '              INNER JOIN Programacion.Forros AS ff
        '               ON ep.espr_forroid = ff.forr_forroid
        '              INNER JOIN Programacion.Suelas AS ss
        '               ON ep.espr_suelaid = ss.suel_suelaid
        '              LEFT JOIN Programacion.Lineas ln
        '               ON pe.pres_lineaid = ln.linea_lineaid
        '              INNER JOIN Programacion.EstatusProducto st
        '               ON pe.pres_estatus = st.stpr_productoStatusId
        '              WHERE pr.prod_activo = 'True'
        '              AND pl.piel_activo = 1
        '              AND tt.talla_activo = 1
        '              AND cc.color_activo = 1
        '              AND pm.plmu_activo = 1
        '              AND ff.forr_activo = 1
        '              AND ss.suel_activo = 1
        '              AND pe.pres_activo = 1
        '              AND hh.horma_activo = 1
        '              ORDER BY pr.prod_descripcion, pr.prod_codigo, tt.talla_descripcion
        '                         </cadena>
        '  Return operacion.EjecutaConsulta(cadena)


    End Function
    Public Function verModelosRegistrador(ByVal activo As Boolean)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim parametro As SqlClient.SqlParameter
        Try

            parametro = New SqlClient.SqlParameter
            parametro.ParameterName = "@Activo"
            parametro.Value = activo
            ListaParametros.Add(parametro)

            Return operacion.EjecutarConsultaSP("[Programacion].[SP_Modelos_ConsultarModelosRegistrados]", ListaParametros)
        Catch ex As Exception
        End Try
        '   Dim operacion As New Persistencia.OperacionesProcedimientos
        '   Dim cadena As String = <cadena>
        '                              SELECT
        '                pr.prod_codigo ,
        '                   pr.prod_modelo as 'ModeloSICY',
        '                pr.prod_descripcion,
        '                gr.grpo_descripcion,
        '                tc.tica_descripcion,


        '                (SELECT
        '                 Programacion.FN_ConcatenarSubfamilias(pr.prod_productoid))
        '                AS Subfamilia,
        '                   fp.fapr_descripcion 'Familia Ventas',
        '                tm.temp_nombre,
        '                pl.piel_descripcion,
        '                cc.color_descripcion,
        '                fa.fami_descripcion,
        '                tt.talla_descripcion,
        '                pm.plmu_descripcion,
        '                ff.forr_descripcion,
        '                ln.linea_descripcion,
        '                ss.suel_descripcion,
        '                hh.horma_descripcion,
        '                pe.pres_codSicy,
        '                st.stpr_descripcion,
        '                   pres_clavesat_detallada +'-' +pcd.pcsd_descripciondetallada as 'Clave SAT',
        '                   suela.suel_descripcion as SuelaProgramacion, 
        '                   csuela.cosu_nombrecolor as ColorSuela
        '               FROM Programacion.Productos AS pr
        '               LEFT JOIN Programacion.Grupos gr
        '                ON pr.prod_grupo = gr.grpo_grupoid
        '               LEFT JOIN Programacion.TipoCategoria tc
        '                ON pr.prod_categoria = tc.tica_tipocategoriaid
        '               INNER JOIN Programacion.Temporadas tm
        '                ON pr.prod_temporadaid = tm.temp_temporadaid
        '               INNER JOIN Programacion.ProductoEstilo AS pe
        '                ON pr.prod_productoid = pe.pres_productoid
        '               LEFT join Programacion.ProductoClaveSAT_Detallada as pcd
        'on pe.pres_clavesat_detallada=pcd.pcsd_clavesat_detallada
        '               LEFT JOIN Programacion.Familias_Proyeccion fp
        '                ON fp.fapr_familiaproyeccionid=pe.pres_familiaproyeccionid
        '               LEFT JOIN Programacion.Hormas AS hh
        '                ON pe.pres_horma = hh.horma_hormaid
        '               INNER JOIN Programacion.EstilosProducto AS ep
        '                ON pe.pres_estiloid = ep.espr_estiloproductoid
        '               INNER JOIN Programacion.Pieles AS pl
        '                ON ep.espr_pielid = pl.piel_pielid
        '               LEFT JOIN Programacion.Familias AS fa
        '                ON pe.pres_familiaid = fa.fami_familiaid
        '               INNER JOIN Programacion.Tallas AS tt
        '                ON ep.espr_tallaid = tt.talla_tallaid
        '               INNER JOIN Programacion.Colores AS cc
        '                ON ep.espr_colorid = cc.color_colorid
        '               INNER JOIN Programacion.PielMuestras AS pm
        '                ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid
        '               INNER JOIN Programacion.Forros AS ff
        '                ON ep.espr_forroid = ff.forr_forroid
        '               INNER JOIN Programacion.Suelas AS ss
        '                ON ep.espr_suelaid = ss.suel_suelaid
        '               LEFT JOIN Programacion.Lineas ln
        '                ON pe.pres_lineaid = ln.linea_lineaid
        '               INNER JOIN Programacion.EstatusProducto st
        '                ON pe.pres_estatus = st.stpr_productoStatusId
        '               left JOIN Programacion.TBL_SuelaGlobal suela on pe.pres_suelaprogramacionid = suela.suel_suelaid
        '               left join	 Programacion.TBL_ColorSuela csuela on csuela.cosu_colorsuelaid = pe.pres_colorsuelaid
        '               WHERE pr.prod_activo = '<%= activo.ToString %>'
        '               AND pl.piel_activo = 1
        '               AND tt.talla_activo = 1
        '               AND cc.color_activo = 1
        '               AND pm.plmu_activo = 1
        '               AND ff.forr_activo = 1
        '               AND ss.suel_activo = 1
        '               AND pe.pres_activo = 1
        '               AND hh.horma_activo = 1
        '               ORDER BY pr.prod_descripcion, pr.prod_codigo, tt.talla_descripcion
        '                          </cadena>
        '   Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function VerListaProductosWEB(ByVal marca As String, ByVal Coleccion As String, ByVal activo As Boolean, ByVal Cliente As Boolean) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += " SELECT"
        consulta += " pp.prod_productoid,"
        consulta += " pp.prod_codigo,"
        consulta += " mm.marc_descripcion,"
        consulta += " cc.cole_descripcion,"
        consulta += " pp.prod_descripcion,"
        consulta += " (SELECT"
        consulta += " Programacion.FN_ConcatenarSubfamilias(pp.prod_productoid))"
        consulta += " AS subfamilias,"
        consulta += " gg.grpo_descripcion,"
        consulta += " tc.tica_tipocategoriaid,"
        consulta += " tc.tica_descripcion,"
        consulta += " pp.prod_activo,"
        consulta += " pp.prod_foto,"
        consulta += " tt.temp_nombre,"
        consulta += " tt.temp_año,"
        consulta += " pp.prod_dibujo,"
        consulta += " gg.grpo_grupoid"
        consulta += " FROM Programacion.Productos AS pp"
        consulta += " INNER JOIN Programacion.Marcas AS mm"
        consulta += " ON pp.prod_marcaid = mm.marc_marcaid"
        consulta += " INNER JOIN Programacion.Colecciones AS cc"
        consulta += " ON pp.prod_coleccionid = cc.cole_coleccionid"
        consulta += " INNER JOIN Programacion.Temporadas AS tt"
        consulta += " ON pp.prod_temporadaid = tt.temp_temporadaid"
        consulta += " LEFT JOIN Programacion.Grupos AS gg"
        consulta += " ON pp.prod_grupo = gg.grpo_grupoid"
        consulta += " INNER JOIN Programacion.ProductoEstilo AS pe"
        consulta += " ON pp.prod_productoid = pe.pres_productoid"
        consulta += " INNER JOIN Programacion.EstilosProducto AS ep"
        consulta += " ON pe.pres_estiloid = ep.espr_estiloproductoid"
        consulta += " LEFT JOIN Programacion.TipoCategoria tc"
        consulta += " ON pp.prod_categoria = tc.tica_tipocategoriaid"
        consulta += " WHERE pp.prod_activo = 'True'"
        consulta += " AND mm.marc_activo = 1"
        consulta += " AND cc.cole_activo = 1"
        consulta += " AND tt.temp_activo = 1"
        consulta += " AND gg.grpo_activo = 1"
        consulta += " AND mm.marc_esCliente='" + Cliente.ToString + "'"

        If marca <> "" Then
            consulta += " AND mm.marc_marcaid in (" + marca.ToString + ")"
        End If
        If Coleccion <> "" Then
            consulta += "and cc.cole_coleccionid in (" + Coleccion.ToString + ")"
        End If

        consulta += " GROUP BY	pp.prod_productoid,"
        consulta += " pp.prod_codigo,"
        consulta += " pp.prod_descripcion,"
        consulta += " mm.marc_descripcion,"
        consulta += " cc.cole_descripcion,"
        consulta += " tt.temp_nombre,"
        consulta += " tt.temp_año,"
        consulta += " pp.prod_activo,"
        consulta += " pp.prod_foto,"
        consulta += " pp.prod_dibujo,"
        consulta += " gg.grpo_grupoid,"
        consulta += " gg.grpo_descripcion,"
        consulta += " tc.tica_tipocategoriaid,"
        consulta += " tc.tica_descripcion"
        consulta += " ORDER BY pp.prod_codigo"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function VerListaProductosWEB(ByVal marca As String, ByVal Coleccion As String,
                                         ByVal activo As Boolean, ByVal Cliente As Boolean,
                                         ByVal idCliente As Int32) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dtValidaModelosCliente As New DataTable
        Dim modelosConCliente As Boolean = False
        Dim consulta As String = ""
        Dim consultaModelosCliente As String = ""

        consultaModelosCliente = "SELECT" +
                                " COUNT(prod_productoid) AS TOTAL" +
                                " FROM Programacion.Productos" +
                                " WHERE prod_clienteid = " + idCliente.ToString +
                                " AND prod_activo = 1"

        dtValidaModelosCliente = operacion.EjecutaConsulta(consultaModelosCliente)

        consulta += " SELECT"
        consulta += " pp.prod_productoid,"
        consulta += " pp.prod_codigo,"
        consulta += " mm.marc_descripcion,"
        consulta += " cc.cole_descripcion,"
        consulta += " pp.prod_descripcion,"
        consulta += " (SELECT"
        consulta += " Programacion.FN_ConcatenarSubfamilias(pp.prod_productoid))"
        consulta += " AS subfamilias,"
        consulta += " gg.grpo_descripcion,"
        consulta += " tc.tica_tipocategoriaid,"
        consulta += " tc.tica_descripcion,"
        consulta += " pp.prod_activo,"
        consulta += " pp.prod_foto,"
        consulta += " tt.temp_nombre,"
        consulta += " tt.temp_año,"
        consulta += " pp.prod_dibujo,"
        consulta += " gg.grpo_grupoid,"
        consulta += " pp.prod_modelo "
        consulta += " FROM Programacion.Productos AS pp"
        consulta += " INNER JOIN Programacion.Marcas AS mm"
        consulta += " ON pp.prod_marcaid = mm.marc_marcaid"
        consulta += " INNER JOIN Programacion.Colecciones AS cc"
        consulta += " ON pp.prod_coleccionid = cc.cole_coleccionid"
        consulta += " INNER JOIN Programacion.Temporadas AS tt"
        consulta += " ON pp.prod_temporadaid = tt.temp_temporadaid"
        consulta += " LEFT JOIN Programacion.Grupos AS gg"
        consulta += " ON pp.prod_grupo = gg.grpo_grupoid"
        consulta += " INNER JOIN Programacion.ProductoEstilo AS pe"
        consulta += " ON pp.prod_productoid = pe.pres_productoid"
        consulta += " INNER JOIN Programacion.EstilosProducto AS ep"
        consulta += " ON pe.pres_estiloid = ep.espr_estiloproductoid"
        consulta += " LEFT JOIN Programacion.TipoCategoria tc"
        consulta += " ON pp.prod_categoria = tc.tica_tipocategoriaid"
        consulta += " WHERE pp.prod_activo = 'True'"
        consulta += " AND mm.marc_activo = 1"
        consulta += " AND cc.cole_activo = 1"
        consulta += " AND tt.temp_activo = 1"
        consulta += " AND gg.grpo_activo = 1"
        consulta += " AND mm.marc_esCliente='" + Cliente.ToString + "'"

        If marca <> "" Then
            consulta += " AND mm.marc_marcaid in (" + marca.ToString + ")"
        End If
        If Coleccion <> "" Then
            consulta += "and cc.cole_coleccionid in (" + Coleccion.ToString + ")"
        End If
        If dtValidaModelosCliente.Rows(0).Item(0) = 0 Then
            consulta += " AND prod_clienteid IS NULL"
        End If
        consulta += " GROUP BY	pp.prod_productoid,"
        consulta += " pp.prod_codigo,"
        consulta += " pp.prod_descripcion,"
        consulta += " mm.marc_descripcion,"
        consulta += " cc.cole_descripcion,"
        consulta += " tt.temp_nombre,"
        consulta += " tt.temp_año,"
        consulta += " pp.prod_activo,"
        consulta += " pp.prod_foto,"
        consulta += " pp.prod_dibujo,"
        consulta += " gg.grpo_grupoid,"
        consulta += " gg.grpo_descripcion,"
        consulta += " tc.tica_tipocategoriaid,"
        consulta += " tc.tica_descripcion,"
        consulta += " pp.prod_modelo "
        consulta += " ORDER BY pp.prod_codigo"

        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function verDetallesProductoWEB(ByVal idProducto As String, ByVal idTalla As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT"
        consulta += " pr.prod_codigo,"
        consulta += " pe.pres_codSicy, "
        consulta += " pl.piel_descripcion,"
        consulta += " cc.color_descripcion,"
        consulta += " cole.cole_descripcion,"
        consulta += " fa.fami_descripcion,"
        consulta += " ln.linea_descripcion,"
        consulta += " progSF.subf_descripcion,"
        consulta += " mm.marc_descripcion,"
        consulta += " pr.prod_foto,"
        consulta += " tt.talla_descripcion,"
        consulta += " pe.pres_imagen,"
        consulta += " progSF.subf_subfamiliaid,"
        consulta += " fa.fami_familiaid,"
        consulta += " ln.linea_lineaid,"
        consulta += " mm.marc_marcaid,"
        consulta += " cole.cole_coleccionid,"
        consulta += " pr.prod_modelo, "
        consulta += " pe.pres_familiaproyeccionid,"
        consulta += " fp.fapr_descripcion"
        consulta += " FROM Programacion.Productos AS pr"
        consulta += " INNER JOIN Programacion.ProductoEstilo AS pe ON pr.prod_productoid = pe.pres_productoid"
        consulta += " INNER JOIN Programacion.Familias_Proyeccion as fp on pe.pres_familiaproyeccionid = fp.fapr_familiaproyeccionid"
        consulta += " INNER JOIN Programacion.Colecciones AS cole	ON cole.cole_coleccionid = pr.prod_coleccionid"
        consulta += " INNER JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid"
        consulta += " INNER JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid"
        consulta += " LEFT JOIN Programacion.Familias AS fa ON pe.pres_familiaid = fa.fami_familiaid"
        consulta += " INNER JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid"
        consulta += " INNER JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid"
        consulta += " INNER JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid"
        consulta += " INNER JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid"
        consulta += " INNER JOIN Programacion.Suelas AS ss ON ep.espr_suelaid = ss.suel_suelaid"
        consulta += " LEFT JOIN Programacion.Lineas ln ON pe.pres_lineaid = ln.linea_lineaid"
        consulta += " INNER JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId"
        consulta += " INNER JOIN Programacion.ProductoSubfamilias AS po on po.prsu_productoid = pe.pres_productoid"
        consulta += " INNER JOIN programacion.Subfamilia as progSF on progSF.subf_subfamiliaid=po.prsu_subfamiliaid"
        'consulta += " INNER JOIn Programacion.ProductoEstilo as prodE on  prodE.pres_productoid=po.prsu_productoid"
        consulta += " AND pr.prod_productoid = po.prsu_productoid"
        consulta += " INNER JOIN Programacion.Marcas as mm  on mm.marc_marcaid= pr.prod_marcaid"

        consulta += " WHERE pe.pres_codSicy in ('" + idProducto + "')"

        consulta += " AND pl.piel_activo = 1"
        consulta += " AND tt.talla_activo = 1"
        consulta += " AND cc.color_activo = 1"
        consulta += " AND pm.plmu_activo = 1"
        consulta += " AND ff.forr_activo = 1"
        consulta += " AND ss.suel_activo = 1"
        consulta += " AND pe.pres_activo = 1"
        consulta += " AND cole.cole_activo = 1"
        consulta += " AND po.prsu_activo = 1"
        consulta += " and progSF.subf_activo=1"
        consulta += " AND mm.marc_activo=1"
        If idTalla <> "" Then
            consulta += " and tt.talla_tallaid=" + idTalla.ToString
        End If
        consulta += " GROUP BY	pe.pres_codSicy,"
        consulta += " pl.piel_descripcion,"
        consulta += " cc.color_descripcion,"
        consulta += " cole.cole_descripcion,"
        consulta += " fa.fami_descripcion,"
        consulta += " ln.linea_descripcion,"
        consulta += " progSF.subf_descripcion,"
        consulta += " pr.prod_codigo,"
        consulta += " pr.prod_foto,"
        consulta += " mm.marc_descripcion,"
        consulta += " tt.talla_descripcion,"
        consulta += " pe.pres_imagen,"
        consulta += " progSF.subf_subfamiliaid,"
        consulta += " fa.fami_familiaid,"
        consulta += " ln.linea_lineaid,"
        consulta += " mm.marc_marcaid,"
        consulta += " cole.cole_coleccionid,"
        consulta += " pr.prod_modelo, "
        consulta += " pe.pres_familiaproyeccionid,"
        consulta += " fp.fapr_descripcion"
        consulta += " order by prod_codigo, pe.pres_codSicy"

        Return operacion.EjecutaConsulta(consulta)
    End Function


    Public Sub editarImagenesEstilos(ByVal idsEstilos As String, ByVal rutaImagen As String, ImagenModificar As Integer, Renglon As Integer)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idsEstilos"
        ParametroParaLista.Value = idsEstilos
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@rutaImagen"
        ParametroParaLista.Value = rutaImagen
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@usuarioModifico"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@TipoModificacionImagen"
        ParametroParaLista.Value = ImagenModificar
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@Renglon"
        ParametroParaLista.Value = Renglon
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_guardarImagenEstilo", ListaParametros)
    End Sub

    ''' Cambios para correcion en colección
    Public Function validarExistenciaMarca(ByVal CodigoMarc As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " marc_marcaid," +
                                " marc_esCliente," +
                                " marc_codigosicy," +
                                " marc_descripcion" +
                                " FROM Programacion.Marcas" +
                        " WHERE marc_codigo = '" + CodigoMarc + "'" +
                        " AND marc_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function validarExistenciaTemporada(ByVal codTemporada As String)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" +
                                " temp_temporadaid," +
                                " temp_nombre," +
                                " temp_año" +
                                " FROM Programacion.Temporadas" +
                        " WHERE temp_codigo = '" + codTemporada + "'" +
                        " AND temp_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function verClientePropietarioModelo(ByVal idproducto As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim idCliente As String = ""
        Dim nombreCliente As String = ""
        Dim dtConsulta As DataTable
        cadena = "SELECT" +
        " prod_clienteid " +
        " FROM Programacion.Productos" +
        " WHERE prod_productoid=" + idproducto.ToString
        dtConsulta = operacion.EjecutaConsulta(cadena)

        If Not dtConsulta.Rows(0).Item(0).ToString = "" Then
            idCliente = dtConsulta.Rows(0).Item(0).ToString
            Dim dtConsultaNombre As New DataTable
            cadena = "SELECT" +
            " clie_nombregenerico " +
            " FROM Cliente.Cliente" +
            " WHERE clie_clienteid = " + idCliente
            dtConsultaNombre = operacion.EjecutaConsulta(cadena)
            nombreCliente = dtConsultaNombre.Rows(0).Item(0).ToString
        End If


        Return nombreCliente
    End Function

    Public Function consultarExisteEstilo(ByVal productoid As Int32, ByVal pielid As Int32, ByVal colorid As Int32, ByVal tallaid As Int32, ByVal familiaid As Int32, ByVal lineaid As Int32,
                                           ByVal pielmuestraid As Int32, ByVal forroid As Int32,
                                          ByVal suelaid As Int32, ByVal hormaid As Int32, ByVal productoestiloid As String, ByVal importaACtivo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = productoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idPiel"
        ParametroParaLista.Value = pielid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColor"
        ParametroParaLista.Value = colorid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTalla"
        ParametroParaLista.Value = tallaid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idFamilia"
        ParametroParaLista.Value = familiaid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idLinea"
        ParametroParaLista.Value = lineaid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idPielMuestra"
        ParametroParaLista.Value = pielmuestraid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idForro"
        ParametroParaLista.Value = forroid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idSuela"
        ParametroParaLista.Value = suelaid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idHorma"
        ParametroParaLista.Value = hormaid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idPrEstilo"
        ParametroParaLista.Value = productoestiloid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@Activo"
        ParametroParaLista.Value = importaACtivo
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Existe_Producto_Estilo", ListaParametros)


        'Dim operacion As New Persistencia.OperacionesProcedimientos
        'Dim cadena As String = "SELECT" +
        '                        " COUNT(pe.pres_productoestiloid) AS pstilo FROM Programacion.Productos AS pp" +
        '                    " JOIN Programacion.ProductoEstilo AS pe ON pp.prod_productoid = pe.pres_productoid" +
        '                    " JOIN Programacion.Hormas AS hh ON pe.pres_horma = hh.horma_hormaid" +
        '                    " JOIN Programacion.EstilosProducto AS ep ON pe.pres_estiloid = ep.espr_estiloproductoid" +
        '                    " JOIN Programacion.Familias AS fm ON pe.pres_familiaid = fm.fami_familiaid" +
        '                    " JOIN Programacion.Lineas AS ln ON pe.pres_lineaid = ln.linea_lineaid" +
        '                    " JOIN Programacion.Tallas AS tt ON ep.espr_tallaid = tt.talla_tallaid" +
        '                    " JOIN Programacion.Colores AS cc ON ep.espr_colorid = cc.color_colorid" +
        '                    " JOIN Programacion.Pieles AS pl ON ep.espr_pielid = pl.piel_pielid" +
        '                    " JOIN Programacion.Forros AS ff ON ep.espr_forroid = ff.forr_forroid" +
        '                    " JOIN Programacion.Suelas AS ss ON ep.espr_suelaid = ss.suel_suelaid" +
        '                    " JOIN Programacion.PielMuestras AS pm ON ep.espr_pielmuestraid = pm.plmu_pielmuestraid" +
        '                    " JOIN Programacion.EstatusProducto st ON pe.pres_estatus = st.stpr_productoStatusId" +
        '                            " WHERE pp.prod_productoid = " + productoid.ToString +
        '                    " AND pl.piel_pielid =" + pielid.ToString +
        '                    " AND cc.color_colorid =" + colorid.ToString +
        '                    " AND tt.talla_tallaid =" + tallaid.ToString +
        '                    " AND pm.plmu_pielmuestraid =" + pielmuestraid.ToString +
        '                    " AND ff.forr_forroid =" + forroid.ToString +
        '                    " AND ss.suel_suelaid =" + suelaid.ToString +
        '                    " AND hh.horma_hormaid =" + hormaid.ToString +
        '                    " AND fm.fami_familiaid =" + familiaid.ToString +
        '                    " AND ln.linea_lineaid =" + lineaid.ToString
        'If productoestiloid <> "" Then
        '    cadena += " AND pe.pres_productoestiloid <> " + productoestiloid.ToString
        'End If
        'If importaACtivo = True Then
        '    cadena += " AND pe.pres_activo = 0"
        'End If

        'Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultarExisteEstiloConsumos(ByVal idestilo As Int32, ByVal idtalla As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProEstilo"
        ParametroParaLista.Value = idestilo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTalla"
        ParametroParaLista.Value = idtalla
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_ValidarModificarEstiloConsumos", ListaParametros)

    End Function

    Public Function Recuperar_Fracciones_Arancelarias_De_Prodcto(ByVal Fraccion_Detalle As Entidades.Fracciones_Arancelarias_Detalles, ByVal IdCorrida As Integer)
        Dim objOperacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = " declare @IdFamilia as integer, @IdForro as integer, @IdCorte as integer, @IdSuela as integer, @IdTipo as integer, @IdCorrida as integer" +
                    " set @IdFamilia =  " + Fraccion_Detalle.PFamiliaId.ToString +
                    " set @IdForro =  " + Fraccion_Detalle.PForroId.ToString +
                    " set @IdCorte =  " + Fraccion_Detalle.PPielMuestraId.ToString +
                    " set @IdSuela = " + Fraccion_Detalle.PSuelaId.ToString +
                    " set @IdTipo = " + Fraccion_Detalle.PTipoCategoriaId.ToString +
                    " set @IdCorrida= " + IdCorrida.ToString +
                    " select [Programacion].[Fn_Concatenar_Fracciones_Arancelarias](@IdCorrida,@IdFamilia,@IdCorte,@IdForro,@IdSuela,@IdTipo)"

        Return objOperacionesSay.EjecutaConsulta(consulta)
    End Function

    Public Function validarModeloSICY(ByVal prod_codigo As String) As Boolean
        Dim objOperacionesSAY As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim rs As New DataTable

        consulta = "SELECT * FROM Programacion.Productos WHERE prod_codigo = '" + prod_codigo + "' AND prod_modelo <> ''"

        rs = objOperacionesSAY.EjecutaConsulta(consulta)

        If rs.Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Public Function claveSAT() As DataTable
        Dim objOperacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = " select pcsc_clavesat_detallada as ID,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada as 'Clave SAT' from "
        consulta += " Programacion.ProductoClaveSAT_Configuracion c"
        consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada where c.pcsc_activo = 1 UNION"
        consulta += " select pcsc_clavesat_detallada AS ID,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada 'Clave SAT' from "
        consulta += " Programacion.ProductoClaveSAT_Configuracion_Color c"
        consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada where c.pcsc_activo = 1"
        consulta += " group by pcsc_clavesat_detallada,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada"
        consulta += " order by pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada"

        Return objOperacionesSay.EjecutaConsulta(consulta)
    End Function

    'Public Function buscarClaveArticuloAgregado(categoriaId As String, familiaId As String, tallaId As String, colorId As String) As String
    '    Dim objOperacionesSay As New Persistencia.OperacionesProcedimientos
    '    Dim consulta As String = ""
    '    Dim clave As String = String.Empty
    '    Dim dtClaveSAT As New DataTable

    '    'sin color
    '    consulta = "select  pcsc_clavesat_detallada  +'-' +d.pcsd_descripciondetallada as 'Clave SAT' from "
    '    consulta += " Programacion.ProductoClaveSAT_Configuracion c"
    '    consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
    '    consulta += " where pcsc_tipocategoriaid = " + categoriaId.ToString + " and pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " "
    '    dtClaveSAT = objOperacionesSay.EjecutaConsulta(consulta)

    '    If dtClaveSAT.Rows.Count > 0 Then
    '        'Sel cambio  para que enviara el id originalmente manda a CLave SAT
    '        clave = dtClaveSAT.Rows(0).Item("Clave SAT")
    '        Return clave
    '        Exit Function
    '    ElseIf dtClaveSAT.Rows.Count <= 0 Then
    '        ' con color
    '        consulta = String.Empty
    '        consulta = "select pcsc_clavesat_detallada  +'-' +d.pcsd_descripciondetallada 'Clave SAT' from "
    '        consulta += " Programacion.ProductoClaveSAT_Configuracion_Color c"
    '        consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
    '        consulta += " where pcsc_tipocategoriaid = " + categoriaId.ToString + " and pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " and c.pcsc_colorid = " + colorId.ToString + " "
    '        dtClaveSAT = objOperacionesSay.EjecutaConsulta(consulta)
    '        If dtClaveSAT.Rows.Count > 0 Then
    '            clave = dtClaveSAT.Rows(0).Item("Clave SAT")
    '            Return clave
    '            Exit Function
    '        End If

    '        'ElseIf dtClaveSAT.Rows.Count <= 0 Then
    '        '    'si ninguna tiene datos
    '        '    consulta = String.Empty
    '        '    consulta = " select pcsc_clavesat_detallada as ID,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada as 'Clave SAT' from "
    '        '    consulta += " Programacion.ProductoClaveSAT_Configuracion c"
    '        '    consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada UNION"
    '        '    consulta += " select pcsc_clavesat_detallada AS ID,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada 'Clave SAT' from "
    '        '    consulta += " Programacion.ProductoClaveSAT_Configuracion_Color c"
    '        '    consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
    '        '    consulta += " group by pcsc_clavesat_detallada,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada"
    '        '    consulta += " order by pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada"
    '        '    dtClaveSAT = objOperacionesSay.EjecutaConsulta(consulta)
    '        '    clave = dtClaveSAT.Rows(0).Item("Clave SAT")
    '    End If
    '    Return clave
    'End Function


    Public Function buscarClaveArticuloAgregado(categoriaId As String, familiaId As String, tallaId As String, colorId As String) As String
        Dim objOperacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim clave As String = String.Empty
        Dim dtClaveSAT As New DataTable

        'sin color
        consulta = "select pcsc_clavesat_detallada as idClaveSAT,  pcsc_clavesat_detallada  +'-' +d.pcsd_descripciondetallada as 'Clave SAT' from "
        consulta += " Programacion.ProductoClaveSAT_Configuracion c"
        consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
        consulta += " where  pcsc_activo = 1" + " and  pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " "
        dtClaveSAT = objOperacionesSay.EjecutaConsulta(consulta)
        '    consulta += " where pcsc_tipocategoriaid = " + categoriaId.ToString + " and pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " "
        If dtClaveSAT.Rows.Count > 0 Then
            'Sel cambio  para que enviara el id originalmente manda a CLave SAT
            clave = dtClaveSAT.Rows(0).Item("idClaveSAT")
            Return clave
            Exit Function
        ElseIf dtClaveSAT.Rows.Count <= 0 Then
            ' con color
            consulta = String.Empty
            consulta = "select pcsc_clavesat_detallada AS idClaveSAT, pcsc_clavesat_detallada  +'-' +d.pcsd_descripciondetallada 'Clave SAT' from "
            consulta += " Programacion.ProductoClaveSAT_Configuracion_Color c"
            consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
            consulta += " where pcsc_activo = 1" + " and pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " and c.pcsc_colorid = " + colorId.ToString + " "
            dtClaveSAT = objOperacionesSay.EjecutaConsulta(consulta)
            'consulta += " where pcsc_tipocategoriaid = " + categoriaId.ToString + " and pcsc_familiaproyeccionid = " + familiaId.ToString + " and pcsc_tallaid = " + tallaId.ToString + " and c.pcsc_colorid = " + colorId.ToString + " "
            If dtClaveSAT.Rows.Count > 0 Then
                clave = dtClaveSAT.Rows(0).Item("idClaveSAT")
                Return clave
                Exit Function
            End If

            'ElseIf dtClaveSAT.Rows.Count <= 0 Then
            '    'si ninguna tiene datos
            '    consulta = String.Empty
            '    consulta = " select pcsc_clavesat_detallada as ID,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada as 'Clave SAT' from "
            '    consulta += " Programacion.ProductoClaveSAT_Configuracion c"
            '    consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada UNION"
            '    consulta += " select pcsc_clavesat_detallada AS ID,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada 'Clave SAT' from "
            '    consulta += " Programacion.ProductoClaveSAT_Configuracion_Color c"
            '    consulta += " inner join Programacion.ProductoClaveSAT_Detallada d on c.pcsc_clavesat_detallada=d.pcsd_clavesat_detallada"
            '    consulta += " group by pcsc_clavesat_detallada,pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada"
            '    consulta += " order by pcsc_clavesat_detallada  +' - ' +d.pcsd_descripciondetallada"
            '    dtClaveSAT = objOperacionesSay.EjecutaConsulta(consulta)
            '    clave = dtClaveSAT.Rows(0).Item("Clave SAT")
        End If
        Return clave
    End Function
    Public Function buscarFraccionArancelariaArticuloAgregado(tallaId As String, familiaId As String, corteId As String, forroId As String, suelaId As String, categoriaId As String) As String
        Dim objOperacionesSay As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        Dim fraccionArancelaria As String = String.Empty
        Dim dtFraccionArancelaria As New DataTable

        consulta = "select  Programacion.Fn_Concatenar_Fracciones_Arancelarias ("
        consulta += tallaId.ToString + " ," + familiaId.ToString + " , " + corteId.ToString + " ," + forroId.ToString + " ," + suelaId.ToString + " ," + categoriaId.ToString + " )"
        dtFraccionArancelaria = objOperacionesSay.EjecutaConsulta(consulta)

        If dtFraccionArancelaria.Rows.Count > 0 And Not IsDBNull(dtFraccionArancelaria.Rows(0).Item(0)) Then
            fraccionArancelaria = dtFraccionArancelaria.Rows(0).Item(0)
            Return fraccionArancelaria
        End If
        Return fraccionArancelaria
    End Function
    Public Function ObtenerFamiliasProyeccion() As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Programacion_ConsultaFamiliasProyeccion]", listaParametros)

    End Function

    Public Function ObtenerSuelasProgramacion() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@Activo"
        ParametroParaLista.Value = True
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Modelos_ConsultaSuelas]", ListaParametros)

    End Function

    Public Function ObtenerHormas() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@Activo"
        ParametroParaLista.Value = True
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Ventas].[SP_Modelos_ConsultaHormas]", ListaParametros)

    End Function
    Public Function buscarHormaId(hormanuevo) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@NombreHorma"
        ParametroParaLista.Value = hormanuevo
        listaParametros.Add(ParametroParaLista)

        Return operaciones.EjecutarConsultaSP("[Ventas].[SP_Modelos_ConsultaHormasId]", listaParametros)

    End Function
    Public Function ValidarPielColorSICY(PielColor As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@ColorPiel"
        ParametroParaLista.Value = PielColor
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ValidarPielColor]", ListaParametros)
    End Function

    Public Function ValidarArticuloEnPedidoActivo(ProductoEstiloId As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@ProductoEstiloID"
        ParametroParaLista.Value = ProductoEstiloId
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_Modelos_ValidarArticuloEnPedidoActivo]", ListaParametros)
    End Function

    Public Sub CambiarStatusAProductosDescontinuados(ByVal UsuarioID As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@UsuarioID", UsuarioID)
        ListaParametros.Add(parametro)

        operacion.EjecutaConsulta("[Ventas].[SP_ActualizarStatusAProductosDescontinuados]")
    End Sub

    Public Function consultarExisteEstiloModelo(ByVal productoid As Int32, ByVal pielid As String, ByVal colorid As String, ByVal tallaid As String, ByVal importaACtivo As Boolean, ByVal modelosay As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "@idProducto"
        ParametroParaLista.Value = productoid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idPiel"
        ParametroParaLista.Value = pielid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idColor"
        ParametroParaLista.Value = colorid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@idTalla"
        ParametroParaLista.Value = tallaid
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@Activo"
        ParametroParaLista.Value = importaACtivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "@modeloSAY"
        ParametroParaLista.Value = modelosay
        ListaParametros.Add(ParametroParaLista)

        Return operacion.EjecutarConsultaSP("Programacion.SP_Existe_Producto_EstiloMODELO", ListaParametros)

    End Function

    Public Function validaCodigo(codCliente As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientosSICY
        Dim ListaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@codCliente", codCliente)
        ListaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[validaCodigo]", ListaParametros)
    End Function

End Class
