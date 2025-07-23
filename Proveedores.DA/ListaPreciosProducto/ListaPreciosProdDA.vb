Imports Entidades
Imports System.Data.SqlClient

Public Class ListaPreciosProdDA
    Public Function getPreciosLista(ByVal idLista As String, ByVal idMarca As String, ByVal idColeccion As String, ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                select isnull(pptd_precio,0.00) 'Precio'
                from catProductos inner join Marcas on catProductos.IdMarca=Marcas.IdMarca
                left join Proveedores.PreciosProductoTerminadoDetalles on IdProducto=pptd_productoid
                left join Proveedores.PreciosProductoTerminado on ppt_listaid=pptd_listaid
                where Estatus in('AUTORIZADO') AND ppt_listaid=<%= idLista %> and isnull(pptd_precio,0.00)=0
                UNION
				select isnull(0,0.00) 'Precio'
                from catProductos left join Marcas on catProductos.IdMarca=Marcas.IdMarca		
                where IdProducto not in (select pptd_productoid from Proveedores.PreciosProductoTerminadoDetalles 
				where pptd_listaid=<%= idLista %>)   and Estatus in('AUTORIZADO') AND  catProductos.IdMarca='<%= idMarca %>' and catProductos.IdColeccion='<%= idColeccion %>' and IdNave=<%= idNave %>
            </cadena>
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getDestinatarios(ByVal clave As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
                SELECT        envio_envioid, envio_clave, envio_descripcion, envio_destinos, envio_naveid
                FROM            Framework.EnviosCorreo 
            </cadena>
        consulta += " where envio_clave='" & clave & "'"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getProductoTerminadoMaquila(ByVal idNave As Integer, ByVal inicio As Date, ByVal fin As Date) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim idNaveSicy As Integer = getNaveSIcy(idNave)
        'Dim consulta As String =
        '<cadena>
        '    select
        ' '' 'Vacía',
        ' Marca,
        ' Coleccion 'Colección',
        ' IdModelo 'Modelo',
        ' Tallas.Talla 'Corrida',
        ' Pieles.Piel 'Piel',
        ' Colores.Nombre 'Color',
        ' IdNave,
        ' catProductos.IdMarca,
        ' Colecciones.IdColeccion,
        ' Estatus,
        ' ISNULL(ppt_listaid, 0) 'idLista',
        ' ISNULL(pptd_precioid, 0) 'idPrecio',
        ' IdProducto,
        ' ISNULL(precioMaquila, (ISNULL(pptd_precio, 0))) AS 'Precio',
        ' COUNT(pares) 'ParesF',
        '            0 'ParesR',
        ' (COUNT(pares) * ISNULL(precioMaquila, (ISNULL(pptd_precio, 0)))) 'Total',
        '    0 TotalF

        '    from tmpDocenasPares join
        '</cadena>
        'consulta += " catProductos on IdCodigo=idtblProducto and idtblTalla=IdCorrida and IdNave=" & idNaveSicy & " and Estatus in('AUTORIZADO')"
        'consulta += " left join Proveedores.vPrecioProductoTerminadoDetalles on IdProducto=pptd_productoid"
        'consulta += " left join Proveedores.PreciosProductoTerminado on ppt_listaid=pptd_listaid and ppt_naveid=" & idNaveSicy & " and ppt_estatus='AUTORIZADA'"
        'consulta += " INNER JOIN Marcas"
        'consulta += " ON catProductos.IdMarca = Marcas.IdMarca"
        'consulta += " INNER JOIN Colecciones"
        'consulta += " ON catProductos.IdColeccion = Colecciones.IdColeccion"
        'consulta += " INNER JOIN Tallas"
        'consulta += " ON catProductos.IdCorrida = Tallas.IdTalla"
        'consulta += " INNER JOIN Pieles"
        'consulta += " ON catProductos.IdPiel = Pieles.IdPiel"
        'consulta += " INNER JOIN Colores"
        'consulta += " ON catProductos.IdColor = Colores.IdColor"
        'consulta += " where FechaEntradaAlmacen BETWEEN  '" & inicio.ToString("dd/MM/yyyy") & " 00:00' AND  '" & fin.ToString("dd/MM/yyyy") & " 23:59'  "
        'consulta += " and idtblnave=" & idNaveSicy & " "
        'consulta += " GROUP BY	IdModelo,Marca,	Coleccion,Talla,Colores.Nombre,Pieles.Piel,	IdNave,	catProductos.IdMarca,Colecciones.IdColeccion," +
        '" pptd_precio,Estatus,ppt_listaid,pptd_precioid,IdProducto,pares,	precioMaquila" +
        '" ORDER BY Marca, Colección, Corrida, Piel"
        'Return operaciones.EjecutaConsulta(consulta)

        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim datos As New DataTable

        parametro.ParameterName = "@idNave"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@inicio"
        parametro.Value = inicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fin"
        parametro.Value = fin
        listaparametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ProductoTerminado_ObtieneProductoTerminadoMaquila]", listaparametros)

    End Function
    Public Function getListasDetallesReporte(ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
             SELECT
	ppt_listaid 'id',
	Marca 'marca',
	Coleccion 'coleccion',
	pptd_claveproducto 'modelo',
	Piel 'piel',
	Colores.Nombre 'color',
	Tallas.Talla 'corrida',
	pptd_precio 'precio'
FROM Proveedores.PreciosProductoTerminado
INNER JOIN Marcas
	ON IdMarca = ppt_marca
INNER JOIN Colecciones
	ON IdColeccion = ppt_coleccion
INNER JOIN Proveedores.PreciosProductoTerminadoDetalles
	ON ppt_listaid = pptd_listaid
INNER JOIN catProductos
	ON IdProducto = pptd_productoid
INNER JOIN Tallas
	ON catProductos.IdCorrida = Tallas.IdTalla
INNER JOIN Pieles
	ON catProductos.IdPiel = Pieles.IdPiel
INNER JOIN Colores
	ON catProductos.IdColor = Colores.IdColor
            WHERE ppt_listaid IN (
            </cadena>
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getListasReporte(ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim operacionesSAY As New Persistencia.OperacionesProcedimientos

        Dim consulta As String =
            <cadena>
            select ppt_listaid 'id',ppt_nombre 'nombre',Nave 'nave',
            ppt_inicio 'inicio',ppt_fin 'fin',nave_logotipourl 'url'
            from Proveedores.PreciosProductoTerminado inner join Naves ON IdNave=ppt_naveid 
            inner join [<%= operacionesSAY.Servidor %>].[<%= operacionesSAY.NombreDB %>].[Framework].[Naves] as n
            ON IdNave=n.nave_navesicyid
            WHERE ppt_listaid IN (
            </cadena>
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getComercializadora() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("Proveedor.SP_ConsultarEmpresa")
    End Function

    Public Function rechazarListas(ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            update Proveedores.PreciosProductoTerminado set ppt_estatus='RECHAZADA' 
            WHERE ppt_listaid IN (
            </cadena>
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function revertirListas(ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
            update Proveedores.PreciosProductoTerminado set ppt_estatus='CAPTURADA' 
            WHERE ppt_listaid IN (
            </cadena>
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function autorizarListas(ByVal lista As List(Of Integer)) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = " update Proveedores.PreciosProductoTerminado set ppt_estatus='AUTORIZADA', ppt_usuarioautorizoid='" & Entidades.SesionUsuario.UsuarioSesion.PUserUsername & "',ppt_fechaautorizacion=GETDATE() WHERE ppt_listaid IN ("
        For Each id As Integer In lista
            consulta += " " & id & ","
        Next
        consulta += "0)"
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'Public Function getDatosListasPrecios(ByVal capturada As String, ByVal autorizada As String,
    '                                      ByVal rechazada As String, ByVal vigente As Boolean,
    '                                      ByVal marca As String, ByVal coleccion As String,
    '                                      ByVal idNaveSicy As Integer) As DataTable
    Public Function getDatosListasPrecios(ByVal Estatus As String, ByVal Vigente As Boolean, ByVal IdMarca As String, ByVal Coleccion As String, ByVal idNaveSicy As Integer, ByVal preciocompra_venta As Integer, ByVal idEmpresa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = Estatus
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Vigente",
            .Value = Vigente
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdMarca",
            .Value = IdMarca
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Coleccion",
            .Value = Coleccion
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdNave",
            .Value = idNaveSicy
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@PrecioCompra_venta",
            .Value = preciocompra_venta
        })
        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@idEmpresa",
            .Value = idEmpresa
        })

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ListaPreciosProductoTerminado_ConsultaListasPrecios_ConPrecios_V1]", listaParametros)


        '        Dim estatus As String = ""
        '        If vigente Then
        '            estatus = "AUTORIZADA"
        '        End If
        '        Dim consulta As String =
        '            <cadena>
        '            SELECT
        '	0 seleccion,
        '    '' 'pintar',
        '   Naves.IdNave,
        '	Nave,
        '	ppt_nombre 'Nombre Lista',
        '	ppt_inicio 'Inicio',
        '	ppt_fin 'Fin',
        '	Marcas.IdMarca,
        '	Marca,
        '	Colecciones.IdColeccion,
        '	Coleccion 'Colección',
        '	pptd_claveproducto 'Modelo',
        '	Piel,
        '	Colores.Nombre 'Color',
        '	Tallas.Talla 'Corrida',
        '	pptd_precio 'Precio',
        '	ppt_fechacreacion 'Fecha',
        '	ppt_usuariocreoid 'Creó',
        '	ppt_fechaautorizacion 'Fecha Autoriza',
        '	ISNULL(ppt_usuarioautorizoid, '') 'Autoriza',
        '    ppt_listaid 'IdLista',pptd_precioid 'IdPrecio',
        '    ppt_estatus 'Estatus'
        'FROM Proveedores.PreciosProductoTerminado
        'INNER JOIN naves
        '	ON IdNave = ppt_naveid
        'INNER JOIN Marcas
        '	ON IdMarca = ppt_marca
        'INNER JOIN Colecciones
        '	ON IdColeccion = ppt_coleccion
        'INNER JOIN Proveedores.PreciosProductoTerminadoDetalles
        '	ON ppt_listaid = pptd_listaid
        'INNER JOIN catProductos
        '	ON IdProducto = pptd_productoid
        'INNER JOIN Tallas
        '	ON catProductos.IdCorrida = Tallas.IdTalla
        'INNER JOIN Pieles
        '	ON catProductos.IdPiel = Pieles.IdPiel
        'INNER JOIN Colores
        '	ON catProductos.IdColor = Colores.IdColor
        'WHERE
        '            </cadena>
        '        consulta += " ppt_estatus in('" & capturada & "','" & autorizada & "','" & rechazada & "','" & estatus & "') "
        '        If vigente = True Then
        '            consulta += " and GETDATE() BETWEEN (convert(varchar(10),ppt_inicio,103)+' 00:00') and  (convert(varchar(10),ppt_fin,103)+' 23:59')  "
        '        End If
        '        If marca <> "NA" Then
        '            consulta += "  and ppt_marca='" & marca & "'"
        '        End If
        '        If coleccion <> "NA" Then
        '            consulta += " and ppt_coleccion='" & coleccion & "'"
        '        End If
        '        consulta += " and Naves.IdNave= " & idNaveSicy & " and Estatus in ('AUTORIZADO')"
        '        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function getDatosPreciosVentas(Naves As String, idEmpresa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdNave",
            .Value = Naves
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@idEmpresa",
            .Value = idEmpresa
        })

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ListaPreciosProductoTerminado_ConsultaListasPrecios_ConPrecios_V115052020sinNave]", listaParametros)

    End Function

    Public Function getDatosListasPreciosVenta(ByVal Estatus As String, ByVal Vigente As Boolean, ByVal IdMarca As String, ByVal Coleccion As String, ByVal idNaveSicy As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = Estatus
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Vigente",
            .Value = Vigente
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdMarca",
            .Value = IdMarca
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Coleccion",
            .Value = Coleccion
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdNave",
            .Value = idNaveSicy
        })

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ListaPreciosProductoTerminado_ConsultaListasPrecios_ConPreciosVenta]", listaParametros)
    End Function
    Public Function getDatosListas(ByVal Estatus As String, ByVal idNaveSicy As Integer, ByVal vigente As Boolean, ByVal IdEmpresa As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdNave",
            .Value = idNaveSicy
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Estatus",
            .Value = Estatus
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Vigente",
            .Value = vigente
        })

        listaParametros.Add(New SqlParameter With {
                            .ParameterName = "@IdEmpresa",
                            .Value = IdEmpresa
        })

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ListaPreciosProductoTerminado_ConsultaListasPrecios_V1_coppel]", listaParametros)

        'Dim estatus As String = ""
        'If vigente Then
        '    estatus = "AUTORIZADA"
        'End If
        'Dim consulta As String = "select 0 seleccion,'' 'pintar',IdNave,Nave,Marcas.IdMarca," +
        '"    Marca, IdColeccion, Coleccion 'Colección'," +
        '"    ppt_nombre 'Nombre Lista',ppt_inicio 'Inicio',ppt_fin 'Fin'," +
        '"    ppt_fechacreacion 'Fecha',ppt_usuariocreoid 'Creó',ppt_fechaautorizacion 'Fecha Autoriza'," +
        '"    isnull(ppt_usuarioautorizoid,'') 'Autoriza',ppt_listaid 'IdLista', ppt_estatus 'Estatus'," +
        '"    (select COUNT(pptd_precioid) from Proveedores.PreciosProductoTerminadoDetalles " +
        '"    join catProductos on IdProducto=pptd_productoid where pptd_listaid=ppt.ppt_listaid and pptd_precio<=0 " +
        '"    and Estatus IN ('AUTORIZADO')) 'SinPreciosCapturados'" +
        '"    from Proveedores.PreciosProductoTerminado ppt inner JOIN" +
        '"    naves on IdNave=ppt_naveid inner join Marcas on IdMarca=ppt_marca" +
        '"    inner join Colecciones on IdColeccion=ppt_coleccion   " +
        '"    WHERE "
        'consulta += " ppt_estatus in('" & capturada & "','" & autorizada & "','" & rechazada & "','" & estatus & "') and IdNave= " & idNaveSicy & ""
        'If vigente = True Then
        '    consulta += " and GETDATE() BETWEEN (convert(varchar(10),ppt_inicio,103)+' 00:00') and  (convert(varchar(10),ppt_fin,103)+' 23:59')  "
        'End If
        'Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getValidarLista(ByVal lista As ListaPrecioProd) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
          select *from Proveedores.PreciosProductoTerminado where 
            </cadena>
        consulta += "'" & lista.inicio.Date & "'  BETWEEN ppt_inicio AND  ppt_fin and ppt_marca = '" & lista.marca & "' and ppt_coleccion='" & lista.coleccion & "' and ppt_naveid=" & lista.idNave
        If lista.listaid > 0 Then
            consulta += " and ppt_listaid<>" & lista.listaid & ""
        End If
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    'antterior 03/04/2020

    'Public Function getMarcas(ByVal idNave As Integer) As DataTable
    '    Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
    '    Dim consulta As String =
    '        <cadena>
    '            select DISTINCT(Marca),Marcas.IdMarca from catProductos inner join 
    '            Marcas on catProductos.IdMarca=Marcas.IdMarca where Estatus in('AUTORIZADO','') and IdNave
    '        </cadena>
    '    If idNave > 0 Then
    '        consulta += " =" & getNaveSIcy(idNave)
    '    Else
    '        consulta += " >0"
    '    End If

    '    Return operaciones.EjecutaConsulta(consulta)
    'End Function

    Public Function getMarcas(ByVal idNave As Integer, ByVal idEmpresa As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        idNave = getNaveSIcy(idNave)

        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idEmpresa"
        parametro.Value = idEmpresa
        listaparametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultarMarcaEmpresa_coppel]", listaparametros)
    End Function
    Public Function getMarcasAltas(ByVal idNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        idNave = getNaveSIcy(idNave)

        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedor].[SP_ConsultarMarca]", listaparametros)
    End Function
    Public Function getComercializadoras(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                select DISTINCT(Marca),Marcas.IdMarca from catProductos inner join 
                Marcas on catProductos.IdMarca=Marcas.IdMarca where Estatus in('AUTORIZADO','') and IdNave
            </cadena>
        If idNave > 0 Then
            consulta += " =" & getNaveSIcy(idNave)
        Else
            consulta += " >0"
        End If

        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getColecciones(ByVal idNave As Integer, ByVal idMarca As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String =
            <cadena>
                --select DISTINCT(Coleccion),Colecciones.IdColeccion 
                select DISTINCT Concat(Coleccion,' (',YEAR(Fecha),')') Coleccion,Colecciones.IdColeccion 
                from catProductos  
                inner join Colecciones on catProductos.IdColeccion=Colecciones.IdColeccion 
                where Estatus in('AUTORIZADO','') and
            </cadena>
        consulta += " IdNave=" & getNaveSIcy(idNave) & " and catProductos.IdMarca='" & idMarca & "' "


        If idMarca = "6" Then
            consulta += "
                         union 
                         --select DISTINCT(Coleccion),Colecciones.IdColeccion 
                         select DISTINCT Concat(Coleccion,' (',YEAR(Fecha),')') Coleccion,Colecciones.IdColeccion 
                         from catProductos  cat
                         inner join Colecciones on cat.IdColeccion=Colecciones.IdColeccion 
                         inner join Programacion.vProductoEstilos_Completo vprod
                         on cat.IdCodigo = vprod.CodigoSicy and cat.IdCorrida = vprod.IdTallaSicy and vprod.pres_activo = 1 
                                             and vprod.prod_activo = 1
                         where Estatus in('AUTORIZADO','') and IdNave=" & getNaveSIcy(idNave) & " and vprod.MarcaIdSAY = '6' "
        End If

        consulta += " ORDER BY Coleccion ASC "

        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getPreciosModelos(ByVal idList As Integer, ByVal idNave As Integer, ByVal idMarca As String, ByVal idCol As String, ByVal tipoprecio As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdLista",
            .Value = idList
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@idNave",
            .Value = idNave
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@Marca",
            .Value = idMarca
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@IdColeccion",
            .Value = idCol
        })

        listaParametros.Add(New SqlParameter With {
            .ParameterName = "@TipoPrecio",
            .Value = tipoprecio
        })
        '    Dim consulta2 As String = ""
        '    Dim consulta As String =
        '        <cadena>
        '            select 0 seleccion,'' 'Vacía',Marca,Coleccion 'Colección',IdModelo 'Modelo',
        '            Tallas.Talla 'Corrida',Pieles.NombreCorto 'Piel',
        '            Colores.NombreCorto 'Color',IdNave,
        '            catProductos.IdMarca,Colecciones.IdColeccion, isnull(pptd_precio,0.00) '*Precio',Estatus,
        '            isnull(ppt_listaid,0) 'idLista',isnull(pptd_precioid,0) 'idPrecio',IdProducto 
        '            from catProductos inner join Marcas on catProductos.IdMarca=Marcas.IdMarca
        '            inner join Colecciones on catProductos.IdColeccion=Colecciones.IdColeccion
        '            inner join Tallas on catProductos.IdCorrida=Tallas.IdTalla
        '            inner join Pieles on catProductos.IdPiel=Pieles.IdPiel 
        '            inner join Colores on catProductos.IdColor=Colores.IdColor
        '            left join Proveedores.PreciosProductoTerminadoDetalles on IdProducto=pptd_productoid
        '            left join Proveedores.PreciosProductoTerminado on ppt_listaid=pptd_listaid
        '            where Estatus in('AUTORIZADO') AND ppt_listaid=
        '        </cadena>
        '    consulta += " " & idList
        '    consulta2 = <cadena>
        '            UNION
        'select 0 seleccion,'' 'Vacía',Marca,Coleccion 'Colección',IdModelo 'Modelo',
        'Tallas.Talla 'Corrida',Pieles.NombreCorto 'Piel',
        'Colores.NombreCorto 'Color',IdNave,
        '            catProductos.IdMarca,Colecciones.IdColeccion, isnull(0,0.00) '*Precio',Estatus,
        '            isnull(0,0) 'idLista',isnull(0,0) 'idPrecio',IdProducto 
        '            from catProductos left join Marcas on catProductos.IdMarca=Marcas.IdMarca
        '            left join Colecciones on catProductos.IdColeccion=Colecciones.IdColeccion
        '            left join Tallas on catProductos.IdCorrida=Tallas.IdTalla
        '            left join Pieles on catProductos.IdPiel=Pieles.IdPiel 
        '            left join Colores on catProductos.IdColor=Colores.IdColor

        '            </cadena>
        '    consulta2 += " where IdProducto not in (select pptd_productoid from Proveedores.PreciosProductoTerminadoDetalles where pptd_listaid=" & idList & ")"
        '    consulta2 += "    and Estatus in('AUTORIZADO') AND "
        '    consulta2 += " catProductos.IdMarca='" & idMarca & "' and catProductos.IdColeccion='" & idCol & "' and IdNave=" & idNave & ""
        '    consulta = consulta + consulta2
        'Return operaciones.EjecutaConsulta(consulta)
        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ListaPreciosProductoTerminado_ConsultaPrecios_V1]", listaParametros)

    End Function
    Public Function InsertListaPrecioProducto(ByVal lista As ListaPrecioProd) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = getNaveSIcy(lista.idNave)
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = lista.nombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@inicio"
        parametro.Value = lista.inicio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fin"
        parametro.Value = lista.fin
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@marca"
        parametro.Value = lista.marca
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@coleccion"
        parametro.Value = lista.coleccion
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = lista.usuarioId
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_InsertListaPrecioProducto]", listaparametros)
    End Function
    Public Function InsertListaPrecioProductoDetalles(ByVal lista As ListaPrecioProdDetalles) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@listaid"
        parametro.Value = lista.listaId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@productoid"
        parametro.Value = lista.productoId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@claveproducto"
        parametro.Value = lista.claveProducto
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = lista.usuarioId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = lista.precio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@tipoprecio"
        parametro.Value = lista.tipoprecio
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_InsertListaPrecioProductoDetalles_V1]", listaparametros)
    End Function
    Public Function copiarListaPrecioProducto(ByVal lista As ListaPrecioProd) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = lista.idNave
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@listaId"
        parametro.Value = lista.listaid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioCreoid"
        parametro.Value = lista.usuarioId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@inicio"
        parametro.Value = lista.inicio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fin"
        parametro.Value = lista.fin
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_CopiarListaPrecioProducto]", listaparametros)
    End Function
    Public Function getModelos(ByVal idNave As Integer, ByVal idMarca As String, ByVal idCol As String) As DataTable
        'Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        'Dim consulta As String =
        '    <cadena>
        '        select 0 seleccion,'' 'Vacía',Marca,Coleccion 'Colección',IdModelo 'Modelo',
        '        Tallas.Talla 'Corrida',Pieles.NombreCorto 'Piel',
        '        Colores.NombreCorto 'Color',IdNave,
        '        catProductos.IdMarca,Colecciones.IdColeccion, 0.00 '*Precio' ,IdProducto 
        '        from catProductos inner join Marcas on catProductos.IdMarca=Marcas.IdMarca
        '        inner join Colecciones on catProductos.IdColeccion=Colecciones.IdColeccion
        '        inner join Tallas on catProductos.IdCorrida=Tallas.IdTalla
        '        inner join Pieles on catProductos.IdPiel=Pieles.IdPiel 
        '        inner join Colores on catProductos.IdColor=Colores.IdColor
        '        where  Estatus in('AUTORIZADO') AND
        '    </cadena>
        'consulta += "  catProductos.IdMarca='" & idMarca & "' and catProductos.IdColeccion='" & idCol & "' and IdNave=" & idNave & " "
        'Return operaciones.EjecutaConsulta(consulta)

        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IdNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idMarca"
        parametro.Value = idMarca
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idColeccion"
        parametro.Value = idCol
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_ListaPreciosProductoTerminado_ObtenerModelos]", listaparametros)

    End Function
    Public Function UpdateListaPrecioProducto(ByVal lista As ListaPrecioProd) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idLista"
        parametro.Value = lista.listaid
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@nombre"
        parametro.Value = lista.nombre
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@inicio"
        parametro.Value = lista.inicio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@fin"
        parametro.Value = lista.fin
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = lista.usuarioId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = getNaveSIcy(lista.idNave)
        listaparametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_UpdateListaPrecioProducto]", listaparametros)
    End Function
    Public Function UpdateListaPrecioProductoDetalles(ByVal lista As ListaPrecioProdDetalles) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@idPrecio"
        parametro.Value = lista.precioId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@precio"
        parametro.Value = lista.precio
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@usuariocreoid"
        parametro.Value = lista.usuarioId
        listaparametros.Add(parametro)
        parametro = New SqlParameter
        parametro.ParameterName = "@tipoprecio"
        parametro.Value = lista.tipoprecio
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Proveedores].[SP_UpdateListaPrecioProductoDetalles_V1]", listaparametros)
    End Function
    Public Function getNaveSIcy(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_navesicyid from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function getNaveSAY(ByVal idNave As Integer) As Integer
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
           select nave_naveid,nave_nombre from Framework.Naves where nave_navesicyid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return Convert.ToInt32(datos.Rows(0).Item(0).ToString)
        End If
        Return 0
    End Function
    Public Function getURLNave(ByVal idNave As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String =
            <cadena>
             select nave_logotipourl 'url',nave_nombre
             from Framework.Naves
             where nave_navesicyid=
            </cadena>
        consulta += idNave.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function getNombreNave(ByVal idNave As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim datos As New DataTable
        Dim consulta As String =
            <cadena>
          select nave_nombre from Framework.Naves where nave_naveid=
            </cadena>
        consulta += " " & idNave & " "
        datos = operaciones.EjecutaConsulta(consulta)
        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString
        End If
        Return ""
    End Function
    Public Function getRazSocReceptor(ByVal idNave As Integer) As String
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Dim datos As New DataTable
        Dim idNaveSicy As Integer = getNaveSIcy(idNave)

        parametro.ParameterName = "@idNave"
        parametro.Value = idNaveSicy
        listaparametros.Add(parametro)

        datos = operaciones.EjecutarConsultaSP("[Proveedores].[SP_ProductoTerminado_ObtieneRazonSocialReceptor]", listaparametros)

        If datos.Rows.Count > 0 Then
            Return datos.Rows(0).Item(0).ToString
        End If

        Return ""
    End Function

    Public Function ObtenerNumeroSemanas(ByVal FechaDel As Date, ByVal FechaAl As Date)
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@FechaDel", FechaDel)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaAl", FechaAl)
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("[Proveedores].[SP_ConsultaNumeroSemanasProductoIngresado]", listaParametros)

    End Function


End Class
