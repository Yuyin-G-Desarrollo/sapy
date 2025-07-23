Imports Persistencia
Imports System.Data.SqlClient

Public Class ClasificacionesMaterialesDA
    Public Function getClasificaciones(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select c.clas_idclasificacion 'ID',c.clas_nombreclas 'Clasificación',c.clas_sku 'SKU', ca.cate_nombre 'Categoría',case c.clas_directo when 1 then 'DIRECTO' else 'INDIRECTO' end 'Material' ,c.clas_status 'Activo'"
        consulta += " from Materiales.Clasificaciones as c join Materiales.CategoriaClasificacion as cc"
        consulta += " on cc.cacl_idclasificacion= c.clas_idclasificacion join Materiales.Categorias as ca"
        consulta += " on ca.cate_idCategoria=cc.cacl_idcategoria order by Clasificación asc"
        If id > 0 Then
            consulta += " where clas_idClasificacion =" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getClasificacionesid(ByVal id As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "select c.clas_idclasificacion 'ID',c.clas_nombreclas 'Clasificación',c.clas_status 'Activo',c.clas_sku 'SKU', ca.cate_nombre 'Categoría' "
        consulta += " from Materiales.Clasificaciones as c join Materiales.CategoriaClasificacion as cc"
        consulta += " on cc.cacl_idclasificacion= c.clas_idclasificacion join Materiales.Categorias as ca"
        consulta += " on ca.cate_idCategoria=cc.cacl_idcategoria"
        If id > 0 Then
            consulta += " where clas_idclasificacion =" & id
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function updateClasificacion(ByVal id As Integer, ByVal nombre As String, ByVal status As Integer, ByVal sku As String, ByVal directo As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        Dim consulta As String =
            <cadena>
            update Materiales.Clasificaciones set clas_nombreclas=
            </cadena>
        consulta += "'" & nombre & "', clas_status=" & status & ",clas_idSicy=" & getidClasificacionSicy(nombre) & " ,clas_directo=" & directo
        consulta += ", clas_usuariomodificoid=" & usuariomodifico & ", clas_fechamodificacion='" & fechamodificacion & "' where clas_idclasificacion =" & id
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ultimaClasificacion(ByVal id As Integer, ByVal nombre As String, ByVal status As Integer, ByVal sku As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select  top 1 clas_idclasificacion 'idClas' from Materiales.Clasificaciones order BY clas_idclasificacion desc
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function insertClasificacion(ByVal nombre As String, ByVal sku As String, ByVal directo As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim obj As New Tools.Combinaciones
        Dim datos As New DataTable
        Dim usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        Dim usuariomodifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")

        datos = getClasificacionesid(0)
        If datos.Rows.Count > 0 Then
            sku = datos.Rows(datos.Rows.Count - 1).Item(3).ToString
            sku = obj.getNextNumeroAlfaNumerico(sku)
        Else
            sku = "00"
        End If
        Dim consulta As String =
            <cadena>
            insert into Materiales.Clasificaciones(clas_nombreclas,clas_sku,clas_status,clas_idSicy,clas_directo,clas_usuariocreoid,clas_fechacreacion,clas_usuariomodificoid,clas_fechamodificacion)
            </cadena>
        consulta += " values('" & nombre & "','" & sku & "',1," & getidClasificacionSicy(nombre) & "," & directo & "," & usuariocreo & ",'" & fechacreacion & "'," & usuariomodifico & ",'" & fechamodificacion & "')"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Sub insertarCategoriaClasificaciones(ByVal AltaCategoriaClasificacion As Entidades.CategoriaClasificacion)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_idcategoria"
        parametro.Value = AltaCategoriaClasificacion.calc_idcategoria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_idclasificacion"
        parametro.Value = AltaCategoriaClasificacion.calc_idclasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_usuariocreoid"
        parametro.Value = AltaCategoriaClasificacion.calc_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_fechacreacion"
        parametro.Value = AltaCategoriaClasificacion.calc_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_usuariomodificoid"
        parametro.Value = AltaCategoriaClasificacion.calc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_fechamodificacion"
        parametro.Value = AltaCategoriaClasificacion.calc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_estatus"
        parametro.Value = AltaCategoriaClasificacion.calc_estatus
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@cacl_directo"
        'parametro.Value = AltaCategoriaClasificacion.calc_directo
        'listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Materiales.SP_CategoriaClasificacion", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Sub ActualizarCategoriaClasificaciones(ByVal AltaCategoriaClasificacion As Entidades.CategoriaClasificacion)
        Dim operaciones As New OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_idclasificacion"
        parametro.Value = AltaCategoriaClasificacion.calc_idclasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_idcategoria"
        parametro.Value = AltaCategoriaClasificacion.calc_idcategoria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_usuariomodificoid"
        parametro.Value = AltaCategoriaClasificacion.calc_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_fechamodificacion"
        parametro.Value = AltaCategoriaClasificacion.calc_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@cacl_estatus"
        parametro.Value = AltaCategoriaClasificacion.calc_estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Materiales.SP_ActualizarCategoriaClasificacion", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Sub insertarClasificacionColores(ByVal AltaCategoriaClasificacion As Entidades.ClasificacionColores)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "clco_idcolor"
        parametro.Value = AltaCategoriaClasificacion.clco_idcolor
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clco_idclasificacion"
        parametro.Value = AltaCategoriaClasificacion.clco_idclasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clco_usuariocreoid"
        parametro.Value = AltaCategoriaClasificacion.clco_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clco_fechacreacion"
        parametro.Value = AltaCategoriaClasificacion.clco_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clco_usuariomodificoid"
        parametro.Value = AltaCategoriaClasificacion.clco_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clco_fechamodificacion"
        parametro.Value = AltaCategoriaClasificacion.clco_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clco_estatus"
        parametro.Value = AltaCategoriaClasificacion.clco_estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Materiales.SP_ClasificacionesColores", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub

    Public Sub insertarClasificacionTamano(ByVal AltaCategoriaClasificacion As Entidades.ClasificacionTamanovb)
        Dim operaciones As New OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "clta_idtamano"
        parametro.Value = AltaCategoriaClasificacion.clta_idtamano
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clta_idclasificacion"
        parametro.Value = AltaCategoriaClasificacion.clta_idclasificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clta_usuariocreoid"
        parametro.Value = AltaCategoriaClasificacion.clta_usuariocreoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clta_fechacreacion"
        parametro.Value = AltaCategoriaClasificacion.clta_fechacreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clta_usuariomodificoid"
        parametro.Value = AltaCategoriaClasificacion.clta_usuariomodificoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clta_fechamodificacion"
        parametro.Value = AltaCategoriaClasificacion.clta_fechamodificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clta_estatus"
        parametro.Value = AltaCategoriaClasificacion.clta_estatus
        listaParametros.Add(parametro)

        operaciones.EjecutarConsultaSP("Materiales.SP_ClasificacionesTamanos", listaParametros)
        Console.WriteLine("Mando la sentencia")
    End Sub


    Public Function UltimaClasificacion() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "SELECT TOP 1 clas_idclasificacion 'idClas' FROM Materiales.Clasificaciones ORDER BY clas_idclasificacion DESC"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerIdCategoriaClasificacion(ByVal id As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select cacl_categoriaclasificacionid from materiales.CategoriaClasificacion where cacl_idclasificacion=" + id.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerCategoria(ByVal id As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select cc.cacl_categoriaclasificacionid 'ID', cc.cacl_idcategoria 'ID cat', c.cate_nombre 'Categoria'"
        consulta += " from Materiales.CategoriaClasificacion as cc"
        consulta += " join Materiales.Categorias as c on c.cate_idCategoria= cc.cacl_idcategoria where cacl_idclasificacion  = " + id.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerColores(ByVal id As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String =
            <cadena>

            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getidClasificacionSicy(ByVal dep As String) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim id As Integer = 0
        Dim consulta As String =
            <cadena>
            select *FROM catalogos where tipcat = 1 and nomcat like 
            </cadena>
        consulta += " '" & dep & "'"
        Dim datos As New DataTable
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            For Each row As DataRow In datos.Rows
                id = row("Idcat")
            Next
        End If
        Return id
    End Function

    Public Function Clasificaciones() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select 0 ' ' ,c.clas_idclasificacion 'ID', c.clas_nombreclas'CLASIFICACION', ca.cate_nombre 'CATEGORIA'"
        consulta += " from Materiales.Clasificaciones as c join Materiales.CategoriaClasificacion as cc"
        consulta += " on cc.cacl_idclasificacion=c.clas_idclasificacion join Materiales.Categorias as ca on ca.cate_idCategoria=cc.cacl_idcategoria"
        consulta += " WHERE c.clas_status=1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaColores() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select 0 ' ', mcol_idcolor 'ID', mcol_color 'Color' from Materiales.MaterialesColores where mcol_idcolor<>1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ListaTamanos() As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select  0 ' ', tama_idTamano 'ID', tama_nombre 'Tamaño' from Materiales.Tamano where tama_idTamano<>1"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ClasificacionesSeleccionadasColores(ByVal idColor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = "select c.clas_idclasificacion 'ID',c.clas_nombreclas'CLASIFICACION',ca.cate_nombre 'CATEGORIA',cc.clco_clasificacioncoloresid 'idCT',"
        consulta += " ' ' = CASE  when cc.clco_estatus = 0 then 'false' when cc.clco_estatus = 1 then 'true'  when cc.clco_estatus is null then 'false' end "
        consulta += " from Materiales.Clasificaciones as c left join Materiales.ClasificacionColores as cc on c.clas_idclasificacion=cc.clco_idclasificacion"
        consulta += " and cc.clco_idcolor=" + idColor.ToString + " join Materiales.CategoriaClasificacion as ccl on ccl.cacl_idclasificacion=c.clas_idclasificacion "
        consulta += " join Materiales.Categorias as ca on ca.cate_idCategoria=ccl.cacl_idcategoria where c.clas_status=1 order by cc.clco_estatus desc ,c.clas_nombreclas asc "
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function coloresSeleccionados(ByVal clasificacion As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
               select col.mcol_idColor 'ID', col.mcol_color 'Color', cl.clco_estatus ' '
                from Materiales.MaterialesColores as col join Materiales.ClasificacionColores as cl
				on cl.clco_idcolor=col.mcol_idcolor join Materiales.Clasificaciones as cla on cla.clas_idclasificacion=cl.clco_idclasificacion
				where cl.clco_idclasificacion=
            </cadena>
        consulta += " " + clasificacion.ToString + " order by cl.clco_estatus"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function tamanosSeleccionados(ByVal clasificacion As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                select t.tama_idTamano 'ID', t.tama_nombre 'Tamaño', ct.clta_estatus ' '	 
                from Materiales.Tamano as t join Materiales.ClasificacionTamanos as ct
                on ct.clta_idtamano=t.tama_idTamano and ct.clta_idclasificacion=
            </cadena>
        consulta += " " + clasificacion.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ClasificacionesSeleccionadasTamanos(ByVal idtamano As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = String.Empty
        consulta = " select  c.clas_idclasificacion 'ID',c.clas_nombreclas'CLASIFICACION',clta_clasificaciontamanoid 'idCT',ca.cate_nombre 'CATEGORIA',"
        consulta += " ' ' = CASE  when cc.clta_estatus = 0 then 'false'  when cc.clta_estatus = 1 then 'true' when cc.clta_estatus is null then 'false' end "
        consulta += "  from Materiales.Clasificaciones as c left join Materiales.ClasificacionTamanos as cc on c.clas_idclasificacion=cc.clta_idclasificacion"
        consulta += " and cc.clta_idtamano=" + idtamano.ToString + " join Materiales.CategoriaClasificacion as ccl on ccl.cacl_idclasificacion=c.clas_idclasificacion "
        consulta += "  join Materiales.Categorias as ca on ca.cate_idCategoria=ccl.cacl_idcategoria where c.clas_status=1  order by cc.clta_estatus desc , c.clas_nombreclas asc"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function desactivarTamano(ByVal idclas As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update materiales.ClasificacionTamanos"
        consulta += " set clta_estatus=0 where  clta_idclasificacion =" + idclas.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function activarTamano(ByVal idclas As Integer, ByVal idtam As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update materiales.ClasificacionTamanos"
        consulta += " set clta_estatus=1 where  clta_idclasificacion =" + idclas.ToString + " and clta_idtamano=" + idtam.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function desactivarColores(ByVal idclas As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update materiales.ClasificacionColores"
        consulta += " set clco_estatus=0 where  clco_idclasificacion =" + idclas.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function activarColores(ByVal idclas As Integer, ByVal idcol As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String
        consulta = "update materiales.ClasificacionColores"
        consulta += " set clco_estatus=1 where  clco_idclasificacion =" + idclas.ToString + " and clco_idcolor=" + idcol.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ActualizarColorClasificacion(ByVal estatus As Integer, ByVal idclas As Integer, ByVal usumod As Integer,
                                                  ByVal clasificaciontamid As Integer, ByVal fecha As Date, ByVal idcolor As Integer) As DataTable
        Dim operaciones As New OperacionesProcedimientos
        Dim consulta As String = ""

        consulta += "update Materiales.ClasificacionColores"
        consulta += "  set"
        consulta += "  clco_estatus=" + estatus.ToString
        consulta += " , clco_usuariomodificoid=" + usumod.ToString
        consulta += " , clco_fechamodificacion='" + fecha.ToString + "'"
        consulta += "  where clco_clasificacioncoloresid=" + idcolor.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

End Class
