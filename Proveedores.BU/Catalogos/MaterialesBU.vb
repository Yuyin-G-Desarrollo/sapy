Imports Proveedores.DA
Imports Entidades
Imports System.Text.RegularExpressions

Public Class MaterialesBU
    Public Function getMaterialNavesParaAgregarEnInventario(ByVal idMaterial As Integer)
        Dim obj As New MaterialesDA
        Return obj.getMaterialNavesParaAgregarEnInventario(idMaterial)
    End Function

    Public Function getMaterial(ByVal idMaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getMaterial(idMaterial)
    End Function

    Public Sub InsertarMaterialPrecio(ByVal NaveOrigenID As Integer, ByVal MaterialNaveID As Integer, ByVal NaveId As Integer, ByVal MaterialID As Integer, ByVal ProveedorID As Integer, ByVal Precio As Double, ByVal UsuarioID As Integer)
        Dim obj As New MaterialesDA
        obj.InsertarMaterialPrecio(NaveOrigenID, MaterialNaveID, NaveId, MaterialID, ProveedorID, Precio, UsuarioID)
    End Sub

    Public Function ExisteMaterialEnConsumo(ByVal idMaterial As Integer, ByVal ProveedorID As Integer) As Boolean
        Dim ExisteMaterial As Boolean = False
        Dim obj As New MaterialesDA
        Dim Existe As Integer = 0
        Existe = obj.ExisteMaterialEnConsumo(idMaterial, ProveedorID)
        If Existe > 0 Then
            ExisteMaterial = True
        Else
            ExisteMaterial = False
        End If

        Return ExisteMaterial
    End Function

    Public Function ExisteMaterialActivoEnConsumo(ByVal idMaterial As Integer, ByVal idNave As Integer) As Integer
        Dim ExisteMaterial As Boolean = False
        Dim obj As New MaterialesDA
        Dim Existe As Integer = 0
        Existe = obj.ExisteMaterialActivoEnConsumo(idMaterial, idNave)
        If Existe > 0 Then
            ExisteMaterial = True
        Else
            ExisteMaterial = False
        End If

        Return ExisteMaterial
    End Function


    Public Function ExisteMaterialEnInventario(ByVal MAterialNAveID As Integer, ByVal ProveedorID As Integer) As Integer
        Dim obj As New MaterialesDA
        Return obj.ExisteMaterialEnInventario(MAterialNAveID, ProveedorID)
    End Function

    Public Function getEstatusAutorizado(ByVal idMaterial As Integer) As String
        Dim obj As New MaterialesDA
        Return obj.getEstatusAutorizado(idMaterial)
    End Function
    Public Function getMaterialParaAgregarEnInventario(ByVal idMaterialNave As Integer)
        Dim obj As New MaterialesDA
        Return obj.getMaterialParaAgregarEnInventario(idMaterialNave)
    End Function
    Public Function getInventarioTotal(ByVal idMaterialNave As Integer, ByVal idProveedor As Integer) As Double
        Dim obj As New MaterialesDA
        Return obj.getInventarioTotal(idMaterialNave, idProveedor)
    End Function
    Public Function ExisteInventarioMaterialProveedor(ByVal MaterialNaveID As Integer, ByVal ProveedorID As Integer) As String
        Dim obj As New MaterialesDA
        Dim Existe As Boolean = False
        If obj.ExisteInventarioMaterialProveedor(MaterialNaveID, ProveedorID) > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        Return Existe
    End Function

    Public Function ExisteInventarioMaterialProveedorPrecio(ByVal MaterialNaveID As Integer, ByVal ProveedorId As Integer, ByVal Precio As Double) As Boolean
        Dim obj As New MaterialesDA
        Dim Existe As Boolean = False
        If obj.ExisteInventarioMaterialProveedorPrecio(MaterialNaveID, ProveedorId, Precio) > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        Return Existe
    End Function
    Public Function insertarInventarioNave(ByVal material As MaterialInventario) As String
        Dim obj As New MaterialesDA
        Return obj.insertarInventarioNave(material)
    End Function

    Public Sub ActualizarInventarioNave(ByVal material As MaterialInventario)
        Dim obj As New MaterialesDA
        obj.ActualizarInventarioNave(material)
    End Sub

    Public Function getMaterialesParaAgregarEnInventario(ByVal list As List(Of Integer)) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getMaterialesParaAgregarEnInventario(list)
    End Function
    Public Function asignarProveedor(ByVal idNave As Integer, ByVal idProveedor As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.asignarProveedor(idNave, idProveedor)
    End Function
    Public Function getDatosPrecioXIdMaterialNAveDesarrollo(ByVal idMaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getDatosPrecioXIdMaterialNAveDesarrollo(idMaterial)
    End Function
    Public Function getDatosPrecioXIdMaterialNAveDesarrollo2(ByVal idMaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getDatosPrecioXIdMaterialNAveDesarrollo2(idMaterial)
    End Function
    Public Function ObtenerPrecioMaterialNaveDesarrollo(ByVal idMaterial As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.ObtienePrecioMaterialNaveDesarrollo(idMaterial, idNave)
    End Function
    Public Function GetIdUsuario(ByVal usuario As String) As DataTable
        Dim obj As New MaterialesDA
        Return obj.GetIdUsuario(usuario)
    End Function
    Public Function getNaveSAY(ByVal idNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getNaveSAY(idNave)
    End Function
    Public Function validarPrecioActivoMaterialNave(ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.validarPrecioActivoMaterialNave(idMaterialNave)
    End Function
    Public Function getSKUMaterial(ByVal material As Material) As String
        Dim obj As New MaterialesDA
        Return obj.getSKUMaterial(material)
    End Function
    Public Function getTamañosMateriales(ByVal clasificaciones As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getTamañosMateriales(clasificaciones)
    End Function
    Public Function getColoresMateriales(ByVal clasificacion As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getColoresMateriales(clasificacion)
    End Function

    Public Function consultaCaracteristicas(ByVal idmaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.consultaCaracteristicas(idmaterial)
    End Function

    Public Function getDepartamentos(ByVal nave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getDepartamentos(nave)
    End Function
    Public Function getListaTipoMateriales() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getListaTipoMateriales()
    End Function

    Public Function getListaMateriales(ByVal material As Material, ByVal nave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getListaMateriales(material, nave)
    End Function
    Public Function getPreciosMateriales(ByVal idMaterialNave As Integer) As DataTable
        Dim lstProveedores As New DataTable
        Dim obj As New MaterialesDA
        Return obj.getPreciosMateriales(idMaterialNave)
    End Function
    Function getCategorias(ByVal tipo As Integer, ByVal NaveID As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getCategorias(tipo, NaveID)
    End Function

    Function getHormas() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getHormas()
    End Function

    Function getTemporadas() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getTemporadas()
    End Function

    Function getForro() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getForro()
    End Function

    Function getSuelas() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getSuelas()
    End Function

    Function getLineas() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getLineas()
    End Function

    Function getColores() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getColores()
    End Function

    Function getPieles() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getPieles()
    End Function

    Function getFamilias() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getFamilias()
    End Function

    Function eliminarCaracteristica(ByVal idmaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.eliminarCaracteristica(idmaterial)
    End Function

    Public Function eliminarCaracteristica(ByVal idmaterial As Integer, ByVal Caracteristica As String) As DataTable
        Dim obj As New MaterialesDA
        Return obj.eliminarCaracteristica(idmaterial, Caracteristica)
    End Function

    Public Function ActualizarCaracteristica(ByVal IDCaracteristica As Integer, ByVal Caracteristica As String, ByVal UsuarioID As Integer) As DataTable

        Dim obj As New MaterialesDA
        Return obj.ActualizarCaracteristica(IDCaracteristica, Caracteristica, UsuarioID)
    End Function

    Public Function ExisteCaracteristicaMaterial(ByVal IdMaterial As Integer, ByVal Caracteristica As String) As Boolean
        Dim obj As New MaterialesDA
        Dim Existe As Boolean = False
        Dim Count As Integer = 0
        Count = obj.ExisteCaracteristicaMaterial(IdMaterial, Caracteristica)

        If Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If

        Return Existe
    End Function

    Function insertarCaracteristica(ByVal descripcion As String,
                                           ByVal idmaterial As Integer, ByVal activo As Integer,
                                           ByVal usuariocreo As Integer, ByVal usuariomodifico As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.insertarCaracteristica(descripcion, idmaterial, activo, usuariocreo, usuariomodifico)
    End Function

    Function getClasificaciones(ByVal CATEGORIA As Integer, ByVal directo As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getClasificaciones(CATEGORIA, directo)
    End Function
    Function getDatosMaterial(ByVal idMaterial As Integer, ByVal idNave As Integer, ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getDatosMaterial(idMaterial, idNave, idMaterialNave)
    End Function
    Function getProveedores(ByVal idNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getProveedores(idNave)
    End Function
    Function getProveedoresNoEnPrecios(ByVal idNave As Integer, ByVal lista As List(Of Integer)) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getProveedoresNoEnPrecios(idNave, lista)
    End Function

    Public Function getProveedrorDatosGeneralesID(ByVal proveedorid As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getProveedrorDatosGeneralesID(proveedorid)
    End Function

    Public Function getIdUnidadesDeMedidas() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getIdUnidadesDeMedidas()
    End Function

    Function getMoneda() As DataTable
        Dim obj As New MaterialesDA
        Return obj.getMoneda()
    End Function

    Function insertPrecioMaterial(ByVal precioMaterial As PrecioMaterial, ByVal accion As Integer) As DataTable
        Dim lstProveedores As New DataTable
        Dim obj As New MaterialesDA
        Return obj.insertPrecioMaterial(precioMaterial, accion)
    End Function
    Function insertMaterial(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.insertMaterial(material)
    End Function
    Function asignarMaterialNave(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.asignarMaterialNave(material)
    End Function
    Public Function ExisteNaveAsignadaMaterial(ByVal MAterialID As Integer, ByVal NaveId As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.ExisteNaveAsignadaMaterial(MAterialID, NaveId)
    End Function
    Function agregarCaracteristica(ByVal caracteristica As Caracteristicas) As DataTable
        Dim obj As New MaterialesDA
        Return obj.agregarCaracteristica(caracteristica)
    End Function

    Public Function idmaterial()
        Dim OBJDA As New DA.MaterialesDA
        Dim tabla As New DataTable
        tabla = OBJDA.idmaterial()
        Dim idClasificacion As New Int32
        For Each row As DataRow In tabla.Rows
            idClasificacion = CInt(row("mate_materialid"))
        Next
        Return idClasificacion
    End Function
    Function updateMaterialNave(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updateMaterialNave(material)
    End Function

    Function updateCaracteristicasMaterial(ByVal caracteristica As Caracteristicas) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updateCaracteristicasMaterial(caracteristica)
    End Function
    Function updatePrecioMaterial(ByVal precioMaterial As PrecioMaterial) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updatePrecioMaterial(precioMaterial)
    End Function
    Function updateMaterial(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updateMaterial(material)
    End Function

    Function updateMaterial2(ByVal material As Material, ByVal idmaterialnave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updateMaterial2(material, idmaterialnave)
    End Function

    Function removePrecioMaterial(ByVal precioMaterial As PrecioMaterial)
        Dim obj As New MaterialesDA
        Return obj.removePrecioMaterial(precioMaterial)
    End Function
    Function verificarSKU(ByVal sku As String) As DataTable
        Dim obj As New MaterialesDA
        Return obj.verificarSKU(sku)
    End Function
    Function getMateriales(ByVal idNave As Integer, ByVal activo As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getMateriales(idNave, activo)
    End Function
    Function getMaterialesConcidencias(ByVal cadena As String, ByVal idcategoria As Integer, ByVal idclasificacion As Integer, ByVal idcolor As Integer, ByVal idtamano As Integer, ByVal tipomaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Dim consulta As String
        'consulta =
        '"Select dage_materialid 'Código',dage_sku 'SKU',dage_descripcion 'Descripción',dage_nombreMaterial 'Nombre'" +
        '" ,ca.nombre 'Categoría',tm.tipoMaterial'Tipo',c.nombreClas 'Clasificación',mc.color 'Color', t.nombre 'Tamaño'," +
        '" isnull(m.idMaterialSicy,0) 'CódigoSICY', ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + cara_descripcion " +
        '" FROM Materiales.Caracteristicas where cara_idmaterial=dage_materialid ORDER BY cara_descripcion " +
        '" FOR XML PATH('') ), 1, 1, ''),'') as Caracteristicas from materiales.materiales m " +
        '" left join Materiales.Clasificaciones c on m.dage_idClasificacion=c.idClas " +
        '" left join Materiales.Categorias ca on ca.idCat=m.dage_idCategoria " +
        '" left join Materiales.MaterialesColores as mc on mc.idColor=m.idColor " +
        '" left join Materiales.Tamano as t on t.idTam=m.idTam " +
        '"left join Materiales.TiposMateriales as tm on tm.idTipo=m.dage_tipodematerial " +
        '"where m.dage_activo=1  and (dage_descripcion like '"

        'Dim datos As New DataTable
        Dim separators() As String = {",", ".", "!", "?", ";", ":", "#", "-", "/", "\", " Y ", " DE ", " "}
        Dim words() As String = cadena.Split(separators, StringSplitOptions.RemoveEmptyEntries)
        ''Filtro 1 cadena separada con signo % entre palabras
        'For Each word In words
        '    consulta += word + " "
        'Next
        'consulta += "%' "

        'Filtro separado por una palabra
        'For Each word In words
        '    consulta += "or dage_descripcion like '" & word & "%' "
        'Next

        ''Filtro iniciales
        'For Each word In words
        '    If word.Length > 3 Then
        '        consulta += "or dage_descripcion like '" & word.Substring(0, 3) & "%' "
        '        'ElseIf word.Length = 2 Then
        '        '    consulta += "or dage_descripcion like '" & word.Substring(0, 2) & "%' "
        '        'ElseIf word.Length = 1 Then
        '        '    consulta += "or dage_descripcion like '" & word.Substring(0, 1) & "%' "
        '    End If
        'Next

        consulta = <cadena>
                    SELECT DISTINCT
                    m.mate_materialid'ID', m.mate_sku 'SKU', m.mate_descripcion 'Descripción', m.mate_nombreMaterial 'Nombre',
                    cat.cate_nombre 'Categoria',tm.tima_tipomaterial 'Tipo',cl.clas_nombreclas 'Clasificación',c.mcol_color 'Color',
                    t.tama_nombre 'Tamaño',n.nave_nombre'Nave Desarrolla',m.mate_exclusivo 'Exclusivo',

                    ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + cara_descripcion
                    FROM Materiales.Caracteristicas where cara_idmaterial=m.mate_materialid  and cara_eliminada is null
                    ORDER BY cara_descripcion
                    FOR XML PATH('')), 1, 1, ''),'') as Caracteristicas , n.nave_naveid , 
                    CASE WHEN mate_activo = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS Estatus

                    FROM Materiales.Materiales AS m join Materiales.MaterialesColores as c on c.mcol_idcolor= m.mate_idColor
                    join Materiales.Tamano as t on t.tama_idTamano=m.mate_idTamaño join Materiales.Categorias as cat on cat.cate_idCategoria=m.mate_idCategoria
                    join Materiales.TiposMateriales as tm on tm.tima_idtipo=m.mate_tipodematerial
                    join Materiales.Clasificaciones as cl on cl.clas_idclasificacion=m.mate_idClasificacion
					join Framework.Naves as n on n.nave_naveid=m.mate_navedesarrollaid
                   </cadena>
        consulta +=
        "where " +
        "mate_tipodematerial=" + tipomaterial.ToString +
        " and mate_idCategoria=" + idcategoria.ToString +
        " and mate_idClasificacion=" + idclasificacion.ToString +
        " and m.mate_idColor=" + idcolor.ToString +
        " and m.mate_idTamaño=" + idtamano.ToString +
        " and (mate_nombreMaterial like '%" + cadena + "%'"

        ''Filtro separado por una palabra
        'For Each word In words
        '    consulta += "" & word & "%' "
        'Next

        'Filtro iniciales
        For Each word In words
            If word.Length > 3 Then
                consulta += " or mate_nombreMaterial like '%" & word.Substring(0, 3) & "%'"

                'ElseIf word.Length = 2 Then
                '    consulta += "or dage_descripcion like '" & word.Substring(0, 2) & "%' "
                'ElseIf word.Length = 1 Then
                '    consulta += "or dage_descripcion like '" & word.Substring(0, 1) & "%' "
            End If

        Next
        Try
            consulta += ")" 'or( m.dage_descripcion like '" & cadena.Substring(0, 3) & "%'"
        Catch
            'consulta += ")or( m.dage_descripcion like '" & cadena.Substring(0, cadena.Length) & "%'"
        End Try
        'For Each word In words
        '    If word.Length > 3 Then
        '        consulta += " OR  m.dage_descripcion like '" & word.Substring(0, 3) & "%'"

        '        'ElseIf word.Length = 2 Then
        '        '    consulta += "or dage_descripcion like '" & word.Substring(0, 2) & "%' "
        '        'ElseIf word.Length = 1 Then
        '        '    consulta += "or dage_descripcion like '" & word.Substring(0, 1) & "%' "
        '    End If

        'Next
        'consulta += ")"
        'consulta += " union SELECT m.dage_materialid'ID', m.dage_sku 'SKU', mp.prma_descripcionProv 'Descripción', m.dage_nombreMaterial 'Nombre',"
        'consulta += " cat.nombre 'Categoria',tm.tipoMaterial 'Tipo',cl.nombreClas 'Clasificación',c.color 'Color',t.nombre 'Tamaño',"
        'consulta += " ISNULL( STUFF((SELECT CAST(',' AS varchar(MAX)) + cara_descripcion FROM Materiales.Caracteristicas where cara_idmaterial=dage_materialid  and cara_eliminada is null"
        'consulta += " ORDER BY cara_descripcion FOR XML PATH('') ), 1, 1, ''),'') as Caracteristicas "
        'consulta += " FROM Materiales.Materiales AS m join Materiales.MaterialesColores as c on c.idColor= m.idColor"
        'consulta += " join Materiales.Tamano as t on t.idTam=m.idTam join Materiales.Categorias as cat on cat.idCat=m.dage_idCategoria"
        'consulta += " join Materiales.TiposMateriales as tm on tm.idTipo=m.dage_tipodematerial"
        'consulta += " join Materiales.Clasificaciones as cl on cl.idClas=m.dage_idClasificacion"
        'consulta += " join Materiales.MaterialesNave as mn on mn.mn_materialid = m.dage_materialid"
        'consulta += " join Materiales.MaterialesPrecio as mp on mp.prma_idnave=mn.mn_idNave"
        'consulta +=
        '"where " +
        '"dage_tipodematerial=" + tipomaterial.ToString +
        '" and dage_idCategoria=" + idcategoria.ToString +
        '" and dage_idClasificacion=" + idclasificacion.ToString +
        '" and m.idColor=" + idcolor.ToString +
        '" and m.idTam=" + idtamano.ToString
        'Try
        '    consulta += "  and (mp.prma_descripcionProv like '" & cadena.Substring(0, cadena.Length) & "%'"
        'Catch
        '    'consulta += "  where (mp.prma_descripcionProv like '" & cadena.Substring(0, cadena.Length) & "%'"
        'End Try
        ''For Each word In words
        ''    If word.Length > 3 Then

        ''        Try
        ''            consulta += " OR  mp.prma_descripcionProv like '" & word.Substring(0, 3) & "%'"
        ''        Catch
        ''            consulta += " OR  mp.prma_descripcionProv like '" & word.Substring(0, cadena.Length) & "%'"
        ''        End Try

        ''        'ElseIf word.Length = 2 Then
        ''        '    consulta += "or dage_descripcion like '" & word.Substring(0, 2) & "%' "
        ''        'ElseIf word.Length = 1 Then
        ''        '    consulta += "or dage_descripcion like '" & word.Substring(0, 1) & "%' "
        ''    End If
        ''Next
        'consulta += ")"
        Return obj.ejecutarConsulta(consulta)
    End Function

    Function getDecripcionProveedorConcidencias(ByVal cadena As String, ByVal id As Integer) As DataTable
        Dim obj As New MaterialesDA
        Dim consulta As String

        'Dim datos As New DataTable
        Dim separators() As String = {",", ".", "!", "?", ";", ":", "#", "-", "/", "\", " Y ", " DE ", " "}
        Dim words() As String = cadena.Split(separators, StringSplitOptions.RemoveEmptyEntries)
        ''Filtro 1 cadena separada con signo % entre palabras
        consulta = <cadena>
                    select prma_descripcionProv 'Descripción',prma_claveProveedor 'Clave Proveedor',dg.dage_nombrecomercial 'Proveedor',
                    prma_preciounitario 'Precio', prma_umproveedor 'UM-Proveedor', prma_umproduccion 'UM-Produccion', prma_equivalencia 'Equivalenca' 
					from Materiales.MaterialesPrecio  join Proveedor.DatosGenerales as dg on dg.dage_proveedorid= prma_provedorid					 
					where  prma_idMaterialNave=
	                  
                   </cadena>
        consulta += id.ToString
        consulta += " and prma_activo=1 and prma_descripcionProv like"
        consulta += "'" + cadena.ToString + "'"
        'Filtro iniciales
        For Each word In words
            If word.Length > 3 Then
                consulta += " or prma_descripcionProv like '" & word.Substring(0, 3) & "%'"
            End If
        Next

        Return obj.ejecutarConsulta(consulta)
    End Function
    Public Function verificarSKU(ByVal idprov As String, ByVal idMaterialNave As String) As DataTable
        Dim obj As New MaterialesDA
        Return obj.verificarSKU(idprov, idMaterialNave)
    End Function
    Public Function verificaridMaterialEnNave(ByVal idMaterial As Integer, ByVal idNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.verificaridMaterial(idMaterial, idNave)
    End Function
    Public Function removerPreciosConMismoProveedorXnave(ByVal idProveedor As Integer, ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.removerPreciosConMismoProveedorXnave(idProveedor, idMaterialNave)
    End Function
    Public Function updateMaterialSICYidDep(ByVal idDep As Integer, ByVal idMatSicy As String) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updateMaterialSICYidDep(idDep, idMatSicy)
    End Function
    Public Function updateMaterialSICYidUMsRendimiento(ByVal idUMP As String, ByVal idUMC As String, ByVal rendimiento As Double,
                                                       ByVal idMatSicy As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.updateMaterialSICYidUMsRendimiento(idUMP, idUMC, rendimiento, idMatSicy)
    End Function
    Public Function insertMaterialAlmacenSICY(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.insertMaterialAlmacenSICY(material)
    End Function
    Public Function UpdateMaterialesSICY(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.UpdateMaterialesSiCY(material)
    End Function
    Public Sub actualizarEstatusMaterialAlmSIcy(ByVal material As Material)
        Dim obj As New MaterialesDA
        obj.actualizarEstatusMaterialAlmSIcy(material)
    End Sub
    Public Sub addPrecioMaterialSICY(ByVal precioMaterial As PrecioMaterial)
        Dim obj As New MaterialesDA
        obj.addPrecioMaterialSICY(precioMaterial)
    End Sub
    Public Sub ActualizaPrecioFichaTecSICY(ByVal precioMaterial As PrecioMaterial)
        Dim obj As New MaterialesDA
        obj.ActualizaPrecioFichaTecSICY(precioMaterial)
    End Sub
    Public Sub spUpdatePrecioMaterialSICY(ByVal precioMaterial As PrecioMaterial)
        Dim obj As New MaterialesDA
        obj.spUpdatePrecioMaterialSICY(precioMaterial)
    End Sub
    Public Function getNavesUtilizandoMaterial(ByVal idMaterial As Integer) As Integer
        Dim obj As New MaterialesDA
        Return obj.getNavesUtilizandoMaterial(idMaterial)
    End Function
    Public Function getNaveDesarrolla(ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getNaveDesarrolla(idMaterialNave)
    End Function

    Public Function getNaveDesarrolla2(ByVal idMaterialNave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getNaveDesarrolla2(idMaterialNave)
    End Function

    Public Function getidMaterialXidMaterialNave(ByVal materialNaveid As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getidMaterialXidMaterialNave(materialNaveid)
    End Function
    Public Function getidMaterialNavesXidMaterial(ByVal idMaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getidMaterialNavesXidMaterial(idMaterial)
    End Function
    Public Function getProveedorAsignado(ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.getProveedorAsignado(proveedorid, naveid)
    End Function
    Public Function insertProveedorNave(ByVal proveedorid As Integer, ByVal naveid As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.insertProveedorNave(proveedorid, naveid)
    End Function

    Public Function SaberTipoNave(ByVal nave As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.SaberTipoNave(nave)
    End Function

    Public Function GetNaveDesarrollaMaterial(ByVal IdMaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.GetNaveDesarrollaMaterial(IdMaterial)
    End Function

    Public Function AutorizarMaterialProduccion(ByVal listaMateriales As List(Of Integer)) As DataTable
        Dim obj As New MaterialesDA
        Return obj.AutorizarMaterialProduccion(listaMateriales)
    End Function

    Public Function DesactivarPrecioMaterial(ByVal idpreciomaterial As Integer) As DataTable
        Dim obj As New MaterialesDA
        Return obj.DesactivarPrecioMaterial(idpreciomaterial)
    End Function


    Public Sub DesactivarPrecioMaterialxId(ByVal idpreciomaterial As Integer)
        Dim obj As New MaterialesDA
        obj.DesactivarPrecioMaterialxId(idpreciomaterial)
    End Sub

    Public Function ConsultaSiEsNaveDesarrollo(ByVal idNave As Integer) As DataTable
        Dim obj = New MaterialesDA
        Return obj.ConsultaSiEsNaveDesarrollo(idNave)
    End Function

    Function ActualizaMaterialCritico(ByVal material As Material) As DataTable
        Dim obj As New MaterialesDA
        Return obj.ActualizaMaterialCritico(material)
    End Function

    Public Function ActualizaNombreMaterial(ByVal material As Material)
        Dim obj As New MaterialesDA
        Return obj.ActualizaNombreMaterial(material)
    End Function

End Class
