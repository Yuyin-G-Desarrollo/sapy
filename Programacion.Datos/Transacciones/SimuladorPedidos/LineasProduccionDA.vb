Imports System.Data.SqlClient

Public Class LineasProduccionDA


    Public Function tablaLineas(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" & _
            " lp.linp_linpID ID," & _
            " n.nave_nombre nave," & _
            " lp.linp_nombre Nombre," & _
            " lp.linp_capacidad_diaria Capacidad," & _
            " lp.linp_idNave idNave" & _
            " FROM Programacion.LineasProduccion lp" & _
            " INNER JOIN Programacion.NavesAux n" & _
            " ON lp.linp_idNave = n.nave_naveid" & _
            " WHERE n.nave_activo = 1" & _
            " AND linp_activo = '" + activo.ToString + "'" & _
            " ORDER BY n.nave_nombre ASC, lp.linp_nombre ASC"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Function comboLineas(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" & _
            " lp.linp_linpID ID," & _
            " n.nave_nombre +' - '+ lp.linp_nombre as Descripcion," & _
            " lp.linp_capacidad_diaria Capacidad," & _
            " lp.linp_idNave idNave" & _
            " FROM Programacion.LineasProduccion lp" & _
            " INNER JOIN Programacion.NavesAux n" & _
            " ON lp.linp_idNave = n.nave_naveid" & _
            " WHERE n.nave_activo = 1" & _
            " AND linp_activo = '" + activo.ToString + "'" & _
            " ORDER BY n.nave_nombre ASC, lp.linp_nombre ASC"
        Return operacion.EjecutaConsulta(cadena)
    End Function


    Public Sub registrarEditarLinea(ByVal accion As String,
                                    ByVal idLinea As Int32,
                                    ByVal idNave As Int32,
                                    ByVal capacidad As Int32,
                                    ByVal activo As Boolean,
                                    ByVal nombre As String)

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlClient.SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@accion"
        parametro.Value = accion
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idLinea"
        parametro.Value = idLinea
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idNave"
        parametro.Value = idNave
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@capacidad"
        parametro.Value = capacidad
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@activo"
        parametro.Value = activo
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@lineaNombre"
        parametro.Value = nombre
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(parametro)


        operacion.EjecutarSentenciaSP("Programacion.SP_AltaEditarLineaProduccion", listaparametros)

    End Sub

    Public Function validarNombreRepetido(ByVal idNave As Int32, ByVal nombre As String) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT linp_linpID FROM Programacion.LineasProduccion WHERE linp_idNave = " + idNave.ToString + " AND linp_nombre = '" + nombre + "'"
        Dim dt As New DataTable
        Dim id As Int32 = 0
        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            id = CInt(dt.Rows(0).Item(0).ToString)
        End If
        Return id
    End Function

    Public Function consultaValidarCont(ByVal idCelula As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT COUNT(lcap_lcapID) AS TOTAL FROM programacion.LineasProduccionCapacidad WHERE lcap_linpID = " + idCelula.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function TablaSemanaLineas(ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoCelula As Boolean, ByVal inactivoCelula As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT	CAST(0 AS bit) Sel, lcap_lcapID id_, linp_linpID 'idLineaCelula', nave_naveid, nave_nombre 'Nave', linp_nombre 'Celula', linp_activo 'Activo', linp_capacidad_diaria 'Capacidad', lcap_año 'Anio'," & _
        " lcap_1 [1],	lcap_2 [2],	lcap_3 [3],	lcap_4 [4],	lcap_5 [5],	lcap_6 [6],	lcap_7 [7],	lcap_8 [8]," & _
        " lcap_9 [9],	lcap_10 [10],	lcap_11 [11],	lcap_12 [12],	lcap_13 [13],	lcap_14 [14],	lcap_15 [15],	lcap_16 [16]," & _
        " lcap_17 [17],	lcap_18 [18],	lcap_19 [19],	lcap_20 [20],	lcap_21 [21],	lcap_22 [22],	lcap_23 [23],	lcap_24 [24]," & _
        " lcap_25 [25],	lcap_26 [26],	lcap_27 [27],	lcap_28 [28],	lcap_29 [29],	lcap_30 [30],	lcap_31 [31],	lcap_32 [32]," & _
        " lcap_33 [33],	lcap_34 [34],	lcap_35 [35],	lcap_36 [36],	lcap_37 [37],	lcap_38 [38],	lcap_39 [39],	lcap_40 [40]," & _
        " lcap_41 [41],	lcap_42 [42],	lcap_43 [43],	lcap_44 [44],	lcap_45 [45],	lcap_46 [46],	lcap_47 [47],	lcap_48 [48]," & _
        " lcap_49 [49],	lcap_50 [50],	lcap_51 [51],	lcap_52 [52], lcap_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario',	" & _
        " CAST(1 AS bit) Vigente, nave_orden" & _
        " FROM Programacion.LineasProduccionCapacidad" & _
        " INNER JOIN Programacion.LineasProduccion ON linp_linpID = lcap_linpID" & _
        " INNER JOIN Programacion.NavesAux ON nave_naveid = linp_idNave" & _
        " LEFT JOIN Framework.Usuarios u on lcap_usuariomodificoid=u.user_usuarioid" & _
        " WHERE nave_activo = 1" & _
        " AND lcap_activo= 1 "
        If activoCelula = True And inactivoCelula = False Then
            cadena += " AND linp_activo=1 "
        ElseIf activoCelula = False And inactivoCelula = True Then
            cadena += " AND linp_activo=0"
        ElseIf activoCelula = True And inactivoCelula = True Then
            cadena += " AND linp_activo IN (0, 1)"
        ElseIf activoCelula = False And inactivoCelula = False Then
            cadena += " AND linp_activo NOT IN (0, 1)"
        End If

        cadena += " AND lcap_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " UNION" & _
        " SELECT CAST(0 AS bit) Sel, lcap_lcapID id_, linp_linpID 'idLineaCelula', nave_naveid, nave_nombre 'Nave', linp_nombre 'Celula', linp_activo 'Activo', linp_capacidad_diaria 'Capacidad', lcap_año 'Anio'," & _
        " lcap_1 [1],	lcap_2 [2],	lcap_3 [3],	lcap_4 [4],	lcap_5 [5],	lcap_6 [6],	lcap_7 [7],	lcap_8 [8]," & _
        " lcap_9 [9],	lcap_10 [10],	lcap_11 [11],	lcap_12 [12],	lcap_13 [13],	lcap_14 [14],	lcap_15 [15],	lcap_16 [16]," & _
        " lcap_17 [17],	lcap_18 [18],	lcap_19 [19],	lcap_20 [20],	lcap_21 [21],	lcap_22 [22],	lcap_23 [23],	lcap_24 [24]," & _
        " lcap_25 [25],	lcap_26 [26],	lcap_27 [27],	lcap_28 [28],	lcap_29 [29],	lcap_30 [30],	lcap_31 [31],	lcap_32 [32]," & _
        " lcap_33 [33],	lcap_34 [34],	lcap_35 [35],	lcap_36 [36],	lcap_37 [37],	lcap_38 [38],	lcap_39 [39],	lcap_40 [40]," & _
        " lcap_41 [41],	lcap_42 [42],	lcap_43 [43],	lcap_44 [44],	lcap_45 [45],	lcap_46 [46],	lcap_47 [47],	lcap_48 [48]," & _
        " lcap_49 [49],	lcap_50 [50],	lcap_51 [51],	lcap_52 [52], lcap_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario',	" & _
        " CAST(0 AS bit) Vigente, nave_orden" & _
        " FROM Programacion.LineasProduccionCapacidad_Hist" & _
        " INNER JOIN Programacion.LineasProduccion ON linp_linpID = lcap_linpID" & _
        " INNER JOIN Programacion.NavesAux ON nave_naveid = linp_idNave" & _
        " LEFT JOIN Framework.Usuarios u on lcap_usuariomodificoid=u.user_usuarioid" & _
        " WHERE nave_activo=1" & _
        " AND lcap_activo= 1 " '--(columna ACTIVO)
        If activoCelula = True And inactivoCelula = False Then
            ' --(celula activa) 
            cadena += " AND linp_activo=1 "
        ElseIf activoCelula = False And inactivoCelula = True Then
            cadena += " AND linp_activo=0"
        ElseIf activoCelula = True And inactivoCelula = True Then
            cadena += " AND linp_activo IN (0, 1)"
        ElseIf activoCelula = False And inactivoCelula = False Then
            cadena += " AND linp_activo NOT IN (0, 1)"
        End If

        cadena += " AND lcap_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " ORDER BY lcap_año, nave_orden ASC, linp_nombre"
        Return operaciones.EjecutaConsulta(cadena)

    End Function

    Public Function TablaSemanaGruposAnioNave(ByVal idNave As Int32, ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoGrupo As Boolean,
                                              ByVal inactivoGrupo As Boolean, ByVal asignadoGrupo As Boolean, ByVal noAsignadoGrupo As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""

        cadena = "SELECT CAST(0 AS bit) Sel, gcap_gcapID 'id_', nave_nombre 'Nave', linp_nombre 'Celula', grpo_descripcion 'Grupo', grpo_activo 'Activo', " & _
        " linp_activo 'Asignado', gcap_año 'Anio', grpo_grupoid, gcap_linpID," & _
        " gcap_1 [1], gcap_2 [2], gcap_3 [3], gcap_4 [4], gcap_5 [5], gcap_6 [6], gcap_7 [7],	gcap_8 [8],	gcap_9 [9],	gcap_10 [10]," & _
        " gcap_11 [11],	gcap_12 [12],	gcap_13 [13],	gcap_14 [14],	gcap_15 [15],	gcap_16 [16],	gcap_17 [17],	gcap_18 [18],	gcap_19 [19]," & _
        " gcap_20 [20],	gcap_21 [21],	gcap_22 [22],	gcap_23 [23],	gcap_24 [24],	gcap_25 [25],	gcap_26 [26],	gcap_27 [27],	gcap_28 [28]," & _
        " gcap_29 [29],	gcap_30 [30],	gcap_31 [31],	gcap_32 [32],	gcap_33 [33],	gcap_34 [34],	gcap_35 [35],	gcap_36 [36],	gcap_37 [37]," & _
        " gcap_38 [38],	gcap_39 [39],	gcap_40 [40],	gcap_41 [41],	gcap_42 [42],	gcap_43 [43],	gcap_44 [44],	gcap_45 [45],	gcap_46 [46]," & _
        " gcap_47 [47],	gcap_48 [48],	gcap_49 [49],	gcap_50 [50],	gcap_51 [51],	gcap_52 [52],	CAST(1 AS bit) Vigente," & _
        " gcap_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario', n.nave_orden" & _
        " FROM Programacion.GruposCapacidad gc" & _
        " JOIN Programacion.LineasProduccion l ON linp_linpID = gcap_linpID" & _
        " JOIN Programacion.NavesAux n on n.nave_naveid=l.linp_idNave" & _
        " JOIN Programacion.Grupos g on g.grpo_grupoid =gc.gcap_grupoID" & _
        " LEFT JOIN Framework.Usuarios u on gc.gcap_usuariomodificoid=u.user_usuarioid" & _
        " WHERE n.nave_activo=1"
        If idNave <> "0" Then
            cadena += " AND  nave_naveID = " + idNave.ToString
        End If
            If activoGrupo = True And inactivoGrupo = False Then
                cadena += " AND g.grpo_activo= 1"
            ElseIf activoGrupo = False And inactivoGrupo = True Then
                cadena += " AND g.grpo_activo=0"
            ElseIf activoGrupo = True And inactivoGrupo = True Then
                cadena += " AND g.grpo_activo IN (0, 1)"
            ElseIf activoGrupo = False And inactivoGrupo = False Then
                cadena += " AND g.grpo_activo NOT IN (0, 1)"
            End If

            cadena += " AND l.linp_activo = 1"

            If asignadoGrupo = True And noAsignadoGrupo = False Then
                cadena += " AND gc.gcap_activo = 1"
            ElseIf asignadoGrupo = False And noAsignadoGrupo = True Then
                cadena += " AND gc.gcap_activo = 0"
            ElseIf asignadoGrupo = True And noAsignadoGrupo = True Then
                cadena += " AND gc.gcap_activo IN (0, 1)"
            ElseIf asignadoGrupo = False And noAsignadoGrupo = False Then
                cadena += " AND gc.gcap_activo NOT IN (0, 1)"
            End If

        cadena += " AND gc.gcap_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " UNION" & _
        " Select CAST(0 AS bit) Sel, gcap_gcapID 'id_', nave_nombre 'Nave', linp_nombre 'Celula', grpo_descripcion 'Grupo', grpo_activo 'Activo', " & _
        " linp_activo 'Asignado', gcap_año 'Anio', grpo_grupoid, gcap_linpID," & _
        " gcap_1 [1], gcap_2 [2], gcap_3 [3], gcap_4 [4], gcap_5 [5], gcap_6 [6], gcap_7 [7],	gcap_8 [8],	gcap_9 [9],	gcap_10 [10]," & _
        " gcap_11 [11],	gcap_12 [12],	gcap_13 [13],	gcap_14 [14],	gcap_15 [15],	gcap_16 [16],	gcap_17 [17],	gcap_18 [18],	gcap_19 [19]," & _
        " gcap_20 [20],	gcap_21 [21],	gcap_22 [22],	gcap_23 [23],	gcap_24 [24],	gcap_25 [25],	gcap_26 [26],	gcap_27 [27],	gcap_28 [28]," & _
        " gcap_29 [29],	gcap_30 [30],	gcap_31 [31],	gcap_32 [32],	gcap_33 [33],	gcap_34 [34],	gcap_35 [35],	gcap_36 [36],	gcap_37 [37]," & _
        " gcap_38 [38],	gcap_39 [39],	gcap_40 [40],	gcap_41 [41],	gcap_42 [42],	gcap_43 [43],	gcap_44 [44],	gcap_45 [45],	gcap_46 [46]," & _
        " gcap_47 [47],	gcap_48 [48],	gcap_49 [49],	gcap_50 [50],	gcap_51 [51],	gcap_52 [52],	CAST(0 AS bit) Vigente," & _
        " gcap_fechamodificacion, u.user_nombrereal, n.nave_orden" & _
        " FROM Programacion.GruposCapacidad_Hist gch" & _
        " JOIN Programacion.LineasProduccion l ON linp_linpID = gcap_linpID" & _
        " JOIN Programacion.NavesAux n on n.nave_naveid=l.linp_idNave" & _
        " JOIN Programacion.Grupos g on g.grpo_grupoid =gch.gcap_grupoID" & _
        " LEFT JOIN Framework.Usuarios u on gch.gcap_usuariomodificoid=u.user_usuarioid" & _
        " WHERE n.nave_activo = 1"

        If idNave <> "0" Then
            cadena += " AND nave_naveID = " + idNave.ToString
        End If


        If activoGrupo = True And inactivoGrupo = False Then
            cadena += " AND g.grpo_activo = 1"
        ElseIf activoGrupo = False And inactivoGrupo = True Then
            cadena += " AND g.grpo_activo = 0"
        ElseIf activoGrupo = True And inactivoGrupo = True Then
            cadena += " AND g.grpo_activo IN (0, 1)"
        ElseIf activoGrupo = False And inactivoGrupo = False Then
            cadena += " AND g.grpo_activo NOT IN (0, 1)"
        End If

        cadena += " AND l.linp_activo = 1"

        If asignadoGrupo = True And noAsignadoGrupo = False Then
            cadena += " AND gch.gcap_activo = 1"
        ElseIf asignadoGrupo = False And noAsignadoGrupo = True Then
            cadena += " AND gch.gcap_activo = 0"
        ElseIf asignadoGrupo = True And noAsignadoGrupo = True Then
            cadena += " AND gch.gcap_activo IN (0, 1)"
        ElseIf asignadoGrupo = False And noAsignadoGrupo = False Then
            cadena += " AND gch.gcap_activo NOT IN (0, 1)"
        End If

        cadena += " AND gch.gcap_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " ORDER BY gcap_año, nave_orden ASC, linp_nombre, grpo_descripcion"
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function TablaSemanaProductosAnioNave(ByVal idNave As Int32, ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoProd As Boolean,
                                              ByVal inactivoProd As Boolean, ByVal asignadoProd As Boolean, ByVal noAsignadoProd As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = " SELECT	CAST(0 AS bit) Sel, proc_procID ID_, n.nave_nombre 'Nave', linp_nombre 'Celula',"

        cadena += " CASE WHEN p.prod_modelo <> '' " +
        " THEN" +
        " p.prod_modelo" +
        " ELSE" +
        " p.prod_codigo" +
        " END AS 'Modelo',"

        cadena += " t.talla_descripcion 'Corrida'," & _
        " pl.piel_descripcion 'Piel', c.color_descripcion 'Color', cl.cole_descripcion 'Coleccion', mr.marc_descripcion 'Marca', hr.horma_descripcion 'Horma'," & _
        " pe.pres_activo 'Activo', pn.prna_activo 'Asignado', pn.prna_capacidad 'Capacidad', pc.proc_año 'Anio', " & _
        " pc.proc_linpID, pn.prna_hormaid, proc_productoEstiloId, proc_tallaID, proc_productonaveid," & _
        " proc_1 [1],	proc_2 [2],	proc_3 [3],	proc_4 [4],	proc_5 [5],	proc_6 [6],	proc_7 [7],	proc_8 [8]," & _
        " proc_9 [9],	proc_10 [10],	proc_11 [11],	proc_12 [12],	proc_13 [13],	proc_14 [14],	proc_15 [15],	proc_16 [16]," & _
        " proc_17 [17],	proc_18 [18],	proc_19 [19],	proc_20 [20],	proc_21 [21],	proc_22 [22],	proc_23 [23],	proc_24 [24]," & _
        " proc_25 [25],	proc_26 [26],	proc_27 [27],	proc_28 [28],	proc_29 [29],	proc_30 [30],	proc_31 [31],	proc_32 [32]," & _
        " proc_33 [33],	proc_34 [34],	proc_35 [35],	proc_36 [36],	proc_37 [37],	proc_38 [38],	proc_39 [39],	proc_40 [40]," & _
        " proc_41 [41],	proc_42 [42],	proc_43 [43],	proc_44 [44],	proc_45 [45],	proc_46 [46],	proc_47 [47],	proc_48 [48]," & _
        " proc_49 [49],	proc_50 [50],	proc_51 [51],	proc_52 [52],	CAST(1 AS bit) Vigente," & _
        " proc_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario', nave_orden" & _
        " FROM Programacion.ProductosCapacidad pc" & _
        " JOIN Programacion.LineasProduccion l ON l.linp_linpID=pc.proc_linpID" & _
        " JOIN Programacion.NavesAux n ON n.nave_naveid=l.linp_idNave" & _
        " JOIN Programacion.ProductoEstilo pe ON pe.pres_productoestiloid=pc.proc_productoEstiloId" & _
        " JOIN Programacion.EstilosProducto ep ON ep.espr_estiloproductoid=pe.pres_estiloid" & _
        " JOIN Programacion.Productos p ON p.prod_productoid=pe.pres_productoid" & _
        " JOIN Programacion.Marcas mr ON p.prod_marcaid = mr.marc_marcaid" & _
        " JOIN Programacion.Colecciones cl ON p.prod_coleccionid = cl.cole_coleccionid" & _
        " JOIN Programacion.Tallas t ON t.talla_tallaid=pc.proc_tallaID" & _
        " JOIN Programacion.Colores c ON ep.espr_colorid= c.color_colorid" & _
        " JOIN Programacion.Pieles  pl ON ep.espr_pielid = pl.piel_pielid" & _
        " LEFT join Framework.Usuarios u ON pc.proc_usuariomodificoid=u.user_usuarioid" & _
        " JOIN programacion.ProductosNave pn ON pn.prna_naveID=n.nave_naveid " & _
        " AND pn.prna_productoEstiloID=pc.proc_productoEstiloId and pn.prna_tallaID=pc.proc_tallaid " & _
        " JOIN Programacion.Hormas hr ON pn.prna_hormaid= hr.horma_hormaid" & _
        " WHERE n.nave_activo=1 "

        If idNave <> "0" Then
            cadena += " AND n.nave_naveid = " + idNave.ToString
        End If

        If activoProd = True And inactivoProd = False Then
            cadena += " AND pe.pres_activo = 1"
        ElseIf activoProd = False And inactivoProd = True Then
            cadena += " AND pe.pres_activo =0"
        ElseIf activoProd = True And inactivoProd = True Then
            cadena += " AND pe.pres_activo IN (0, 1)"
        ElseIf activoProd = False And inactivoProd = False Then
            cadena += " AND pe.pres_activo NOT IN (0, 1)"
        End If

        cadena += " AND l.linp_activo = 1"

        If asignadoProd = True And noAsignadoProd = False Then
            cadena += " and pn.prna_activo = 1 "
        ElseIf asignadoProd = False And noAsignadoProd = True Then
            cadena += " AND pn.prna_activo = 0"
        ElseIf asignadoProd = True And noAsignadoProd = True Then
            cadena += " AND pn.prna_activo IN (0, 1)"
        ElseIf asignadoProd = False And noAsignadoProd = False Then
            cadena += " AND pn.prna_activo NOT IN (0, 1)"
        End If


        cadena += " AND pc.proc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
       " UNION " & _
       " SELECT	CAST(0 AS bit) Sel, proc_procID ID_, n.nave_nombre 'Nave', linp_nombre 'Celula',"

        cadena += " CASE WHEN p.prod_modelo <> '' " +
                " THEN" +
                " p.prod_modelo" +
                " ELSE" +
                " p.prod_codigo" +
                " END AS 'Modelo',"

        cadena += " t.talla_descripcion 'Corrida'," & _
       " pl.piel_descripcion 'Piel', c.color_descripcion 'Color', cl.cole_descripcion 'Coleccion', mr.marc_descripcion 'Marca', hr.horma_descripcion 'Horma'," & _
       " pe.pres_activo 'Activo', pn.prna_activo 'Asignado', pn.prna_capacidad 'Capacidad', pch.proc_año 'Anio', " & _
       " pch.proc_linpID, pn.prna_hormaid, pch.proc_productoEstiloId, proc_tallaID, pch.proc_productonaveid," & _
       " proc_1 [1],	proc_2 [2],	proc_3 [3],	proc_4 [4],	proc_5 [5],	proc_6 [6],	proc_7 [7],	proc_8 [8]," & _
       " proc_9 [9],	proc_10 [10],	proc_11 [11],	proc_12 [12],	proc_13 [13],	proc_14 [14],	proc_15 [15],	proc_16 [16]," & _
       " proc_17 [17],	proc_18 [18],	proc_19 [19],	proc_20 [20],	proc_21 [21],	proc_22 [22],	proc_23 [23],	proc_24 [24]," & _
       " proc_25 [25],	proc_26 [26],	proc_27 [27],	proc_28 [28],	proc_29 [29],	proc_30 [30],	proc_31 [31],	proc_32 [32]," & _
       " proc_33 [33],	proc_34 [34],	proc_35 [35],	proc_36 [36],	proc_37 [37],	proc_38 [38],	proc_39 [39],	proc_40 [40]," & _
       " proc_41 [41],	proc_42 [42],	proc_43 [43],	proc_44 [44],	proc_45 [45],	proc_46 [46],	proc_47 [47],	proc_48 [48]," & _
       " proc_49 [49],	proc_50 [50],	proc_51 [51],	proc_52 [52],	CAST(0 AS bit) Vigente," & _
       " proc_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario', nave_orden" & _
       " FROM Programacion.ProductosCapacidad_Hist pch" & _
       " JOIN Programacion.LineasProduccion l ON l.linp_linpID=pch.proc_linpID" & _
       " JOIN Programacion.NavesAux n ON n.nave_naveid=l.linp_idNave" & _
       " JOIN Programacion.ProductoEstilo pe ON pe.pres_productoestiloid=pch.proc_productoEstiloId" & _
       " JOIN Programacion.EstilosProducto ep ON ep.espr_estiloproductoid=pe.pres_estiloid" & _
       " JOIN Programacion.Productos p ON p.prod_productoid=pe.pres_productoid" & _
       " JOIN Programacion.Marcas mr ON p.prod_marcaid = mr.marc_marcaid" & _
       " JOIN Programacion.Colecciones cl ON p.prod_coleccionid = cl.cole_coleccionid" & _
       " JOIN Programacion.Tallas t ON t.talla_tallaid=pch.proc_tallaID" & _
       " JOIN Programacion.Colores c ON ep.espr_colorid= c.color_colorid" & _
       " JOIN Programacion.Pieles  pl ON ep.espr_pielid = pl.piel_pielid" & _
       " LEFT join Framework.Usuarios u ON pch.proc_usuariomodificoid=u.user_usuarioid" & _
       " JOIN programacion.ProductosNave pn ON pn.prna_naveID=n.nave_naveid " & _
       " AND pn.prna_productoEstiloID=pch.proc_productoEstiloId and pn.prna_tallaID=pch.proc_tallaid " & _
       " JOIN Programacion.Hormas hr ON pn.prna_hormaid= hr.horma_hormaid" & _
       " WHERE n.nave_activo = 1 "

        If idNave <> "0" Then
            cadena += " AND n.nave_naveid = " + idNave.ToString
        End If

        If activoProd = True And inactivoProd = False Then
            cadena += " AND pe.pres_activo = 1"
        ElseIf activoProd = False And inactivoProd = True Then
            cadena += " AND pe.pres_activo =0"
        ElseIf activoProd = True And inactivoProd = True Then
            cadena += " AND pe.pres_activo IN (0, 1)"
        ElseIf activoProd = False And inactivoProd = False Then
            cadena += " AND pe.pres_activo NOT IN (0, 1)"
        End If

        cadena += " AND l.linp_activo = 1"

        If asignadoProd = True And noAsignadoProd = False Then
            cadena += " and pn.prna_activo = 1 "
        ElseIf asignadoProd = False And noAsignadoProd = True Then
            cadena += " AND pn.prna_activo = 0"
        ElseIf asignadoProd = True And noAsignadoProd = True Then
            cadena += " AND pn.prna_activo IN (0, 1)"
        ElseIf asignadoProd = False And noAsignadoProd = False Then
            cadena += " AND pn.prna_activo NOT IN (0, 1)"
        End If

        cadena += " AND pch.proc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
            "ORDER BY proc_año asc, nave_orden ASC, linp_nombre asc, Modelo, talla_descripcion"

        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Function TablaHormaAnioNave(ByVal idNave As Int32, ByVal anioInicio As Int32, ByVal anioFin As Int32, ByVal activoHorma As Boolean,
                                       ByVal inactivoHorma As Boolean, ByVal asignadoHorma As Boolean, ByVal noAsignadoHorma As Boolean) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT CAST(0 AS bit) Sel, hc.horc_hormasCapacidadID id_, n.nave_nombre 'Nave', linp_nombre 'Celula', horma_descripcion 'Horma'," & _
        " t.talla_descripcion 'Corrida', h.horma_activo 'Activo', hn.hona_activo 'Asignado', hn.hona_capacidad 'Capacidad'," & _
        " hc.horc_año 'Anio', hc.horc_linpID, hn.hona_hormaPorNaveID, horc_hormaID, horc_tallaid," & _
        " horc_1 [1],	horc_2 [2],	horc_3 [3],	horc_4 [4],	horc_5 [5],	horc_6 [6],	horc_7 [7],	horc_8 [8]," & _
        " horc_9 [9],	horc_10 [10],	horc_11 [11],	horc_12 [12],	horc_13 [13],	horc_14 [14],	horc_15 [15],	horc_16 [16]," & _
        " horc_17 [17],	horc_18 [18],	horc_19 [19],	horc_20 [20],	horc_21 [21],	horc_22 [22],	horc_23 [23],	horc_24 [24]," & _
        " horc_25 [25],	horc_26 [26],	horc_27 [27],	horc_28 [28],	horc_29 [29],	horc_30 [30],	horc_31 [31],	horc_32 [32]," & _
        " horc_33 [33],	horc_34 [34],	horc_35 [35],	horc_36 [36],	horc_37 [37],	horc_38 [38],	horc_39 [39],	horc_40 [40]," & _
        " horc_41 [41],	horc_42 [42],	horc_43 [43],	horc_44 [44],	horc_45 [45],	horc_46 [46],	horc_47 [47],	horc_48 [48]," & _
        " horc_49 [49],	horc_50 [50],	horc_51 [51],	horc_52 [52],	CAST(1 AS bit) Vigente, " & _
        " horc_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario', n.nave_orden" & _
        " FROM Programacion.HormasCapacidad hc " & _
        " JOIN Programacion.LineasProduccion l on l.linp_linpID=hc.horc_linpID" & _
        " JOIN Programacion.NavesAux n ON  n.nave_naveid=l.linp_idNave" & _
        " JOIN Programacion.Hormas h ON h.horma_hormaid =hc.horc_hormaID" & _
        " JOIN Programacion.Tallas t ON t.talla_tallaid=hc.horc_tallaid" & _
        " LEFT JOIN Framework.Usuarios u ON hc.horc_usuariomodificoid=u.user_usuarioid" & _
        " JOIN programacion.HormasPorNave hn ON hn.hona_naveID=n.nave_naveid " & _
        " AND hc.horc_hormaID=hn.hona_hormaID and hn.hona_tallaid=hc.horc_tallaid " & _
        " where n.nave_activo = 1"

        If idNave <> "0" Then
            cadena += " AND n.nave_naveid = " + idNave.ToString
        End If


        If activoHorma = True And inactivoHorma = False Then
            cadena += " AND h.horma_activo = 1 "
        ElseIf activoHorma = False And inactivoHorma = True Then
            cadena += " AND h.horma_activo =0"
        ElseIf activoHorma = True And inactivoHorma = True Then
            cadena += " AND h.horma_activo IN (0, 1)"
        ElseIf activoHorma = False And inactivoHorma = False Then
            cadena += " AND h.horma_activo NOT IN (0, 1)"
        End If


        cadena += " AND l.linp_activo=1"

        If asignadoHorma = True And noAsignadoHorma = False Then
            cadena += " AND hn.hona_activo=1"
        ElseIf asignadoHorma = False And noAsignadoHorma = True Then
            cadena += " AND hn.hona_activo = 0"
        ElseIf asignadoHorma = True And noAsignadoHorma = True Then
            cadena += " AND hn.hona_activo IN (0, 1)"
        ElseIf asignadoHorma = False And noAsignadoHorma = False Then
            cadena += " AND hn.hona_activo NOT IN (0, 1)"
        End If

        cadena += " AND hc.horc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " UNION " & _
        " SELECT CAST(0 AS bit) Sel, hch.horc_hormasCapacidadID id_, n.nave_nombre 'Nave', linp_nombre 'Celula', horma_descripcion 'Horma', " & _
        " t.talla_descripcion 'Corrida', h.horma_activo 'Activo', hn.hona_activo 'Asignado', hn.hona_capacidad 'Capacidad'," & _
        " hch.horc_año 'Anio', hch.horc_linpID, hn.hona_hormaPorNaveID, horc_hormaID, horc_tallaid," & _
        " horc_1 [1],	horc_2 [2],	horc_3 [3],	horc_4 [4],	horc_5 [5],	horc_6 [6],	horc_7 [7],	horc_8 [8]," & _
        " horc_9 [9],	horc_10 [10],	horc_11 [11],	horc_12 [12],	horc_13 [13],	horc_14 [14],	horc_15 [15],	horc_16 [16]," & _
        " horc_17 [17],	horc_18 [18],	horc_19 [19],	horc_20 [20],	horc_21 [21],	horc_22 [22],	horc_23 [23],	horc_24 [24]," & _
        " horc_25 [25],	horc_26 [26],	horc_27 [27],	horc_28 [28],	horc_29 [29],	horc_30 [30],	horc_31 [31],	horc_32 [32]," & _
        " horc_33 [33],	horc_34 [34],	horc_35 [35],	horc_36 [36],	horc_37 [37],	horc_38 [38],	horc_39 [39],	horc_40 [40]," & _
        " horc_41 [41],	horc_42 [42],	horc_43 [43],	horc_44 [44],	horc_45 [45],	horc_46 [46],	horc_47 [47],	horc_48 [48]," & _
        " horc_49 [49],	horc_50 [50],	horc_51 [51],	horc_52 [52],	CAST(0 AS bit) Vigente, " & _
        " horc_fechamodificacion 'Modificacion', u.user_nombrereal 'Usuario', n.nave_orden" & _
        " FROM Programacion.HormasCapacidad_Hist hch" & _
        " JOIN Programacion.LineasProduccion l ON l.linp_linpID=hch.horc_linpID" & _
        " JOIN Programacion.NavesAux n ON  n.nave_naveid=l.linp_idNave" & _
        " JOIN Programacion.Hormas h ON h.horma_hormaid =hch.horc_hormaID" & _
        " JOIN Programacion.Tallas t ON t.talla_tallaid=hch.horc_tallaid" & _
        " LEFT JOIN Framework.Usuarios u ON hch.horc_usuariomodificoid=u.user_usuarioid" & _
        " JOIN programacion.HormasPorNave hn ON hn.hona_naveID=n.nave_naveid " & _
        " AND hch.horc_hormaID=hn.hona_hormaID and hn.hona_tallaid=hch.horc_tallaid " & _
        " where n.nave_activo=1 "

        If idNave <> "0" Then
            cadena += " AND n.nave_naveid = " + idNave.ToString
        End If

        If activoHorma = True And inactivoHorma = False Then
            cadena += " AND h.horma_activo = 1 "
        ElseIf activoHorma = False And inactivoHorma = True Then
            cadena += " AND h.horma_activo =0"
        ElseIf activoHorma = True And inactivoHorma = True Then
            cadena += " AND h.horma_activo IN (0, 1)"
        ElseIf activoHorma = False And inactivoHorma = False Then
            cadena += " AND h.horma_activo NOT IN (0, 1)"
        End If

        cadena += " AND l.linp_activo=1"

        If asignadoHorma = True And noAsignadoHorma = False Then
            cadena += " AND hn.hona_activo=1"
        ElseIf asignadoHorma = False And noAsignadoHorma = True Then
            cadena += " AND hn.hona_activo = 0"
        ElseIf asignadoHorma = True And noAsignadoHorma = True Then
            cadena += " AND hn.hona_activo IN (0, 1)"
        ElseIf asignadoHorma = False And noAsignadoHorma = False Then
            cadena += " AND hn.hona_activo NOT IN (0, 1)"
        End If

        cadena += " AND hch.horc_año BETWEEN " + anioInicio.ToString + " AND " + anioFin.ToString & _
        " ORDER BY horc_año asc,n.nave_orden ASC, linp_nombre asc, horma_descripcion, talla_descripcion"

        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Sub editarCapacidadCelula(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idCelula As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE programacion.LineasProduccionCapacidad" +
            " SET lcap_" + semana.ToString + "=" + capacidad.ToString +
            ", lcap_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", lcap_fechamodificacion = GETDATE(),  lcap_activo = 1"
        'cadena += ", lcap_semanaelimina = NULL" 
        cadena += " where lcap_lcapID=" + idCelula.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarCapacidadGrupo(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idGrupCap As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE programacion.GruposCapacidad" +
            " SET gcap_" + semana.ToString + "=" + capacidad.ToString +
            ", gcap_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", gcap_fechamodificacion = GETDATE(), gcap_activo = 1" +
            " where gcap_gcapID=" + idGrupCap.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarCapacidadHorma(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idhormCap As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE programacion.HormasCapacidad" +
            " SET horc_" + semana.ToString + "=" + capacidad.ToString +
            ", horc_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", horc_fechamodificacion = GETDATE(), horc_activo = 1, horc_semanaelimina = NULL" +
            " where horc_hormasCapacidadID=" + idhormCap.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarCapacidadProducto(ByVal semana As Int32, ByVal capacidad As Int32, ByVal idProdCapa As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "UPDATE programacion.ProductosCapacidad" +
            " SET proc_" + semana.ToString + "=" + capacidad.ToString +
            ", proc_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", proc_fechamodificacion = GETDATE(), proc_activo = 1, proc_semanaelimina = NULL" +
            " where proc_procID=" + idProdCapa.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaCelulasNuevas(ByVal anio As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT linp_linpID 'id', linp_idNave 'idNave', linp_nombre 'celula', " & _
        " linp_capacidad_diaria 'capacidad', linp_activo 'activo'" & _
        " FROM Programacion.LineasProduccion WHERE linp_linpID NOT IN (SELECT DISTINCT lcap_linpID " & _
        " FROM Programacion.LineasProduccionCapacidad WHERE lcap_año = " + anio.ToString + ")" & _
        " AND linp_activo = 1"
        Return operaciones.EjecutaConsulta(cadena)
    End Function

    Public Sub insertarCelulaCapacidad(ByVal idCelula As Int32, ByVal anio As Int32, ByVal capacidad As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.LineasProduccionCapacidad (lcap_linpID, lcap_año," +
        " lcap_1, lcap_2, lcap_3, lcap_4," +
        " lcap_5, lcap_6, lcap_7, lcap_8," +
        " lcap_9, lcap_10, lcap_11, lcap_12," +
        " lcap_13, lcap_14, lcap_15, lcap_16," +
        " lcap_17, lcap_18, lcap_19, lcap_20," +
        " lcap_21, lcap_22, lcap_23, lcap_24," +
        " lcap_25, lcap_26, lcap_27, lcap_28," +
        " lcap_29, lcap_30, lcap_31, lcap_32," +
        " lcap_33, lcap_34, lcap_35, lcap_36," +
        " lcap_37, lcap_38, lcap_39, lcap_40," +
        " lcap_41, lcap_42, lcap_43, lcap_44," +
        " lcap_45, lcap_46, lcap_47, lcap_48," +
        " lcap_49, lcap_50, lcap_51, lcap_52," +
        " lcap_usuariocreoid," +
        " lcap_fechacreacion," +
        " lcap_usuariomodificoid," +
        " lcap_fechamodificacion," +
        " lcap_activo)" +
        " VALUES ( " + idCelula.ToString + ", " + anio.ToString + ","

        If anio > Date.Now.Year Then
            For i = 1 To 52
                cadena += capacidad.ToString + ", "
            Next
            ' cadena +=" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL," +
            '" NULL, NULL, NULL, NULL, "
        Else
            Dim semanaActual As Int32 = 0
            semanaActual = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
            For i = 1 To semanaActual - 1
                cadena += " NULL,"
            Next
            For i = semanaActual To 52
                cadena += capacidad.ToString + ", "
            Next
        End If

        cadena += Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", GETDATE()," + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", GETDATE(), 1)"

        operacion.EjecutaSentencia(cadena)

    End Sub

    Public Sub insertarGrupoCapacidad(ByVal idLinea As Int32, ByVal idGrupo As Int32, ByVal anio As Int32, ByVal capacidad As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "INSERT INTO Programacion.GruposCapacidad (gcap_linpID, gcap_grupoID, gcap_año," & _
        " gcap_1, gcap_2, gcap_3, gcap_4, gcap_5, gcap_6, gcap_7," & _
        " gcap_8, gcap_9, gcap_10, gcap_11, gcap_12, gcap_13, gcap_14," & _
        " gcap_15, gcap_16, gcap_17, gcap_18, gcap_19, gcap_20, gcap_21," & _
        " gcap_22, gcap_23, gcap_24, gcap_25, gcap_26, gcap_27, gcap_28," & _
        " gcap_29, gcap_30, gcap_31, gcap_32, gcap_33, gcap_34, gcap_35," & _
        " gcap_36, gcap_37, gcap_38, gcap_39, gcap_40, gcap_41, gcap_42," & _
        " gcap_43, gcap_44, gcap_45, gcap_46, gcap_47, gcap_48, gcap_49," & _
        " gcap_50, gcap_51, gcap_52, " & _
        " gcap_activo, gcap_fechacreacion, gcap_usuariocreoid, gcap_fechamodificacion,	gcap_usuariomodificoid)" & _
        " VALUES ( " + idLinea.ToString + ", " + idGrupo.ToString + ", " + anio.ToString + ","

        If anio > Date.Now.Year Then
            For i = 1 To 52
                cadena += capacidad.ToString + ", "
            Next
        Else
            Dim semanaActual As Int32 = 0
            semanaActual = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
            For i = 1 To semanaActual - 1
                cadena += " NULL,"
            Next
            For i = semanaActual To 52
                cadena += capacidad.ToString + ", "
            Next
        End If

        cadena += "1, GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ")"

        operacion.EjecutaSentencia(cadena)

    End Sub

    Public Sub insertarHormaCapacidadCelula(ByVal idLinea As Int32, ByVal idHorma As Int32,
                                            ByVal idTalla As Int32, ByVal anio As Int32,
                                           ByVal idHormaXNave As Int32, ByVal capacidad As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenaConsExiste As String = ""
        Dim cadena As String = ""
        Dim dtExiste As New DataTable

        cadenaConsExiste = "SELECT count(horc_hormasCapacidadID)" +
            " Ext FROM Programacion.HormasCapacidad WHERE horc_linpID = " + idLinea.ToString +
            " AND horc_hormaID = " + idHorma.ToString +
            " and horc_tallaid = " + idTalla.ToString +
            " AND horc_año = " + anio.ToString +
            " and horc_activo = 1"

        dtExiste = operacion.EjecutaConsulta(cadenaConsExiste)

        If CInt(dtExiste.Rows(0).Item(0)) = 0 Then
            cadena = "INSERT INTO Programacion.HormasCapacidad (horc_linpID, horc_hormaID, horc_año, horc_hormapornaveid," & _
        " horc_1, horc_2, horc_3, horc_4, horc_5, horc_6, horc_7, horc_8," & _
        " horc_9, horc_10, horc_11, horc_12, horc_13, horc_14, horc_15, horc_16," & _
        " horc_17, horc_18, horc_19, horc_20, horc_21, horc_22, horc_23, horc_24," & _
        " horc_25, horc_26, horc_27, horc_28,	horc_29, horc_30, horc_31, horc_32," & _
        " horc_33, horc_34, horc_35, horc_36, horc_37, horc_38, horc_39, horc_40," & _
        " horc_41, horc_42, horc_43, horc_44, horc_45, horc_46, horc_47, horc_48," & _
        " horc_49, horc_50, horc_51, horc_52," & _
        " horc_tallaid, horc_fechacreacion, horc_usuariocreoid, horc_fechamodificacion," & _
        " horc_usuariomodificoid, horc_activo)" & _
        " VALUES ( " + idLinea.ToString + ", " + idHorma.ToString + ", " + anio.ToString + ", " + idHormaXNave.ToString + ","

            If anio > Date.Now.Year Then
                For i = 1 To 52
                    cadena += capacidad.ToString + ", "
                Next
            Else
                Dim semanaActual As Int32 = 0
                semanaActual = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                For i = 1 To semanaActual - 1
                    cadena += " NULL,"
                Next
                For i = semanaActual To 52
                    cadena += capacidad.ToString + ", "
                Next
            End If

            cadena += idTalla.ToString + ", GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", 1)"

            operacion.EjecutaSentencia(cadena)
        End If

    End Sub

    Public Sub insertarProductoCapacidad(ByVal idLinea As Int32, ByVal idProducto As Int32,
                                          ByVal idProductoEstilo As Int32, ByVal idHorma As String,
                                          ByVal idTalla As Int32, ByVal anio As Int32,
                                          ByVal capacidad As Int32, ByVal idProductoNave As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadenaConsExiste As String = ""
        Dim cadena As String = ""
        Dim dtExiste As New DataTable

        cadenaConsExiste = "SELECT" & _
        " COUNT(proc_procID)" & _
        " FROM Programacion.ProductosCapacidad" & _
        " WHERE proc_linpID = " + idLinea.ToString & _
        " AND proc_productoEstiloId = " + idProductoEstilo.ToString & _
        " AND proc_tallaID = " + idTalla.ToString & _
        " AND proc_año = " + anio.ToString & _
        " AND proc_activo = 1"

        dtExiste = operacion.EjecutaConsulta(cadenaConsExiste)

        If CInt(dtExiste.Rows(0).Item(0)) = 0 Then

            cadena = "INSERT INTO Programacion.ProductosCapacidad (proc_linpID, proc_hormaid, proc_productoEstiloId," & _
                    " proc_tallaID, proc_prodID, proc_año, proc_activo, proc_productonaveid," & _
                    " proc_1, proc_2, proc_3, proc_4, proc_5, proc_6, proc_7, proc_8," & _
                    " proc_9, proc_10, proc_11, proc_12, proc_13, proc_14, proc_15, proc_16," & _
                    " proc_17, proc_18, proc_19, proc_20, proc_21, proc_22, proc_23, proc_24," & _
                    " proc_25, proc_26, proc_27, proc_28, proc_29, proc_30, proc_31, proc_32," & _
                    " proc_33, proc_34, proc_35, proc_36, proc_37, proc_38, proc_39, proc_40," & _
                    " proc_41, proc_42, proc_43, proc_44, proc_45, proc_46, proc_47, proc_48," & _
                    " proc_49, proc_50, proc_51, proc_52," & _
                    " proc_fechamodificacion, proc_fechacreacion, proc_usuariocreoid, proc_usuariomodificoid)" & _
                      " VALUES ( " + idLinea.ToString + ", '" + idHorma.ToString + "', " + idProductoEstilo.ToString +
                    ", " + idTalla.ToString + ", " + idProducto.ToString + ", " + anio.ToString + ", 1, " + idProductoNave.ToString + ", "

            If anio > Date.Now.Year Then
                For i = 1 To 52
                    cadena += capacidad.ToString + ", "
                Next
            Else
                Dim semanaActual As Int32 = 0
                semanaActual = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
                For i = 1 To semanaActual - 1
                    cadena += " NULL,"
                Next
                For i = semanaActual To 52
                    cadena += capacidad.ToString + ", "
                Next
            End If

            cadena += " GETDATE(), GETDATE(), " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ", " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString + ")"

            operacion.EjecutaSentencia(cadena)
        End If
    End Sub

    Public Function consultaAniosMaximoRegistrado() As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim anio As Int32 = Date.Now.Year
        Dim cadena As String = ""

        cadena = "SELECT MAX(lcap_año) anio FROM Programacion.LineasProduccionCapacidad WHERE lcap_activo = 1"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                anio = dt.Rows(0).Item(0)
            End If
        End If

        Return anio

    End Function

    Public Function consultaAniosMinimoRegistrado() As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim anio As Int32 = Date.Now.Year
        Dim cadena As String = ""

        cadena = "SELECT MIN(lcap_año) anio FROM Programacion.LineasProduccionCapacidad_Hist WHERE lcap_activo = 1"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                anio = dt.Rows(0).Item(0)
            End If
        End If

        Return anio

    End Function

    Public Function consultaidCapacidadCelulaAnioDiferente(ByVal idLinea As Int32,
                                                           ByVal anio As Int32,
                                                           ByVal semana As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim capacidad As String = ""
        Dim cadena As String = ""

        cadena = "SELECT" & _
        " lcap_" + semana.ToString & _
        " FROM Programacion.LineasProduccionCapacidad"

        If anio < Date.Now.Year Then
            cadena += "_Hist"
        End If

        cadena += " WHERE lcap_activo = 1" & _
        " AND lcap_linpID = " + idLinea.ToString & _
        " AND lcap_año = " + anio.ToString

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                capacidad = dt.Rows(0).Item(0).ToString
            End If
        End If

        Return capacidad
    End Function

    Public Function consultaidCapacidadGrupoAnioDiferente(ByVal idLinea As Int32, ByVal idGrupo As Int32,
                                                          ByVal anio As Int32,
                                                          ByVal semana As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim capacidad As String = ""
        Dim cadena As String = ""

        cadena = "SELECT" & _
        " gcap_" + semana.ToString & _
        " FROM Programacion.GruposCapacidad"
        If anio < Date.Now.Year Then
            cadena += "_Hist"
        End If
        cadena += " WHERE gcap_activo = 1" & _
        " AND gcap_linpID = " + idLinea.ToString & _
        " AND gcap_grupoID = " + idGrupo.ToString & _
        " AND gcap_año = " + anio.ToString

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                capacidad = dt.Rows(0).Item(0).ToString
            End If
        End If

        Return capacidad
    End Function

    Public Function consultaidCapacidadHormaAnioDiferente(ByVal idLinea As Int32,
                                                          ByVal idHorma As Int32,
                                                          ByVal idTalla As Int32,
                                                          ByVal idHormaXNave As Int32,
                                                          ByVal anio As Int32,
                                                          ByVal semana As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim capacidad As String = ""
        Dim cadena As String = ""

        cadena = "SELECT" +
        " horc_" + semana.ToString & _
        " FROM Programacion.HormasCapacidad "
        If anio < Date.Now.Year Then
            cadena += "_Hist"
        End If
        cadena += " WHERE horc_activo = 1" & _
        " AND horc_linpID = " + idLinea.ToString & _
        " AND horc_hormaID = " + idHorma.ToString & _
        " AND horc_tallaid = " + idTalla.ToString & _
        " AND horc_hormapornaveid = " + idHormaXNave.ToString & _
        " AND horc_año =" + anio.ToString

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                capacidad = dt.Rows(0).Item(0).ToString
            End If
        End If

        Return capacidad
    End Function

    Public Function consultaidCapacidadProductoAnioDiferente(ByVal idLinea As Int32,
                                                         ByVal idHorma As Int32,
                                                         ByVal idProdestilo As Int32,
                                                         ByVal idTalla As Int32,
                                                         ByVal idProductoXnave As Int32,
                                                         ByVal anio As Int32,
                                                         ByVal semana As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim capacidad As String = ""
        Dim cadena As String = ""

        cadena = "SELECT" +
        " proc_" + semana.ToString & _
        " FROM Programacion.ProductosCapacidad"
        If anio < Date.Now.Year Then
            cadena += "_Hist"
        End If
        cadena += " WHERE proc_linpID = " + idLinea.ToString & _
        " AND proc_hormaid = " + idHorma.ToString & _
        " AND proc_productoEstiloId = " + idProdestilo.ToString & _
        " AND proc_tallaID = " + idTalla.ToString & _
        " AND proc_productonaveid = " + idProductoXnave.ToString & _
        " AND proc_año =" + anio.ToString

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                capacidad = dt.Rows(0).Item(0)
            End If
        End If

        Return capacidad
    End Function

    Public Function consultaFechaSeleccionSemana(ByVal semanasCambio As Int32, ByVal anio As Int32) As String
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim dt As New DataTable
        Dim fecha As String = Date.Now.ToString

        Dim cadena As String = ""
        cadena = "SELECT DATEADD(WEEK ," + semanasCambio.ToString + ", '01-01-" + anio.ToString + "')"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                fecha = dt.Rows(0).Item(0)
            End If
        End If

        Return fecha

    End Function

    Public Function contadorGruposEnCelula(ByVal idCelula As Int32, ByVal anio As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim cont As Int32 = Date.Now.Year

        cadena = "SELECT COUNT(gcap_gcapID) FROM Programacion.GruposCapacidad" +
            " WHERE gcap_linpID = " + idCelula.ToString & _
            " AND gcap_año = " + anio.ToString & _
            " and gcap_activo =1"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                cont = dt.Rows(0).Item(0)
            End If
        End If

        Return cont

    End Function

    Public Function contadorHormaEnGrupo(ByVal idLinea As Int32, ByVal anio As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        Dim dt As New DataTable
        Dim cont As Int32 = Date.Now.Year

        cadena = "SELECT COUNT(horc_hormasCapacidadID)" & _
        " FROM Programacion.HormasCapacidad" & _
        " WHERE horc_linpID = " + idLinea.ToString & _
        " AND horc_año = " + anio.ToString & _
        " AND horc_activo = 1"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                cont = dt.Rows(0).Item(0)
            End If
        End If

        Return cont
    End Function

    Public Function contadosProductoEnHorma(ByVal idLinea As Int32, ByVal anio As Int32,
                                            ByVal idHorma As Int32, ByVal idTalla As Int32,
                                            ByVal semanaRegistro As Int32) As Int32
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "", cadenaConsD As String = "", cadenaConsB As String = ""
        Dim dt As New DataTable
        Dim cont As Int32 = 0
        Dim contValida As Int32 = 0
        Dim semanaElimina As Int32 = 0
        '  La primer consulta es para contar si tiene productos en capacidad procducto asignados en la célula, horma y corrida
        cadena = "SELECT COUNT(proc_procID)" & _
        " FROM Programacion.ProductosCapacidad" & _
        " WHERE proc_linpID = " + idLinea.ToString & _
        " AND proc_hormaid = " + idHorma.ToString & _
        " AND proc_tallaID = " + idTalla.ToString & _
        " AND proc_año = " + anio.ToString & _
        " AND proc_activo = 1"

        dt = operacion.EjecutaConsulta(cadena)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0).ToString <> "" Then
                cont = dt.Rows(0).Item(0)
            End If
        End If
        ' si tiene productos, cuenta si alguno no tiene semana elimina si es asi, la horma no se podrá eliminar, pero si todos tienen semana elimina podrá pasar al siguiente paso
        If cont > 0 Then
            dt = New DataTable
            cadenaConsD = "SELECT COUNT(proc_procID)" & _
        " FROM Programacion.ProductosCapacidad" & _
        " WHERE proc_linpID = " + idLinea.ToString & _
        " AND proc_hormaid = " + idHorma.ToString & _
        " AND proc_tallaID = " + idTalla.ToString & _
        " AND proc_año = " + anio.ToString & _
        " AND proc_activo = 1 AND proc_semanaelimina IS NULL"
            dt = operacion.EjecutaConsulta(cadenaConsD)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item(0).ToString <> "" Then
                    contValida = dt.Rows(0).Item(0)
                    If contValida > 0 Then
                        semanaElimina = 0
                    Else
                        ' la ultima onsulta selecciona la semana maxima en la que se puede eliminar la horma
                        dt = New DataTable
                        cadenaConsB = "SELECT MAX(proc_semanaelimina) " & _
                        " FROM Programacion.ProductosCapacidad" & _
                        " WHERE proc_linpID = " + idLinea.ToString & _
                        " AND proc_hormaid = " + idHorma.ToString & _
                        " AND proc_tallaID = " + idTalla.ToString & _
                        " AND proc_año = " + anio.ToString & _
                        " AND proc_activo = 1"
                        dt = operacion.EjecutaConsulta(cadenaConsB)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0).Item(0).ToString <> "" Then
                                semanaElimina = dt.Rows(0).Item(0)
                            End If
                        End If
                    End If
                End If
            End If
        Else
            semanaElimina = semanaRegistro
        End If


        Return semanaElimina
    End Function

    'Public Sub inactivarCelula(ByVal idCelulaCapacidad As Int32, ByVal semana As Int32)
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim cadena As String = ""
    '    Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
    '    cadena = "UPDATE programacion.LineasProduccionCapacidad" +
    '            " SET lcap_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
    '    For i As Int32 = semana To 52
    '        cadena += ", lcap_" + i.ToString + " = NULL"
    '    Next
    '    cadena += ", lcap_fechamodificacion = GETDATE()"
    '    If semana = semanaActual Then
    '        cadena += ", lcap_activo = 0"
    '    End If
    '    cadena += ", lcap_semanaelimina = " + semana.ToString +
    '           " WHERE lcap_lcapID = " + idCelulaCapacidad.ToString

    '    operacion.EjecutaSentencia(cadena)

    'End Sub

    'Public Sub inactivarGrupo(ByVal idGrupoCapacidad As Int32, semana As Int32)
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
    '    Dim cadena As String = "UPDATE programacion.GruposCapacidad" +
    '        " SET  gcap_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString

    '    For i As Int32 = semana To 52
    '        cadena += ", gcap_" + i.ToString + "= NULL"
    '    Next
    '    cadena += ", gcap_fechamodificacion = GETDATE()" +
    '        ", gcap_semanaelimina = " + semana.ToString
    '    If semana = semanaActual Then
    '        cadena += ", gcap_activo = 0"
    '    End If
    '    cadena += " WHERE gcap_gcapID=" + idGrupoCapacidad.ToString

    '    operacion.EjecutaSentencia(cadena)
    'End Sub

    Public Sub inactivarHorma(ByVal idHormaCapacidad As Int32, ByVal semana As Int32, ByVal anio As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
        Dim cadena As String = "UPDATE programacion.HormasCapacidad" +
            " SET horc_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString

        For i As Int32 = semana To 52
            cadena += ", horc_" + i.ToString + " = NULL"
        Next

        cadena += ", horc_fechamodificacion = GETDATE()"

        If (semana = semanaActual) Or (semana = 1 And anio > Date.Now.Year) Then
            cadena += ", horc_activo = 0"
        End If

        cadena += ", horc_semanaelimina = " + semana.ToString +
                    " where horc_hormasCapacidadID=" + idHormaCapacidad.ToString

        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub inactivarProducto(ByVal idProductoCapacidad As Int32, ByVal semana As Int32, ByVal anio As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim semanaActual As Int32 = CInt(DatePart(DateInterval.WeekOfYear, Date.Now))
        Dim cadena As String = "UPDATE programacion.ProductosCapacidad" +
            " SET proc_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString

        For i As Int32 = semana To 52
            cadena += ", proc_" + i.ToString + " = NULL"
        Next

        cadena += ", proc_fechamodificacion = GETDATE()"

        If (semana = semanaActual) Or (semana = 1 And anio > Date.Now.Year) Then
            cadena += ", proc_activo = 0"
        End If


        cadena += ", proc_semanaelimina = " + semana.ToString +
            " where proc_procID=" + idProductoCapacidad.ToString

        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub inactivarHormasSemanaActual()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        operacion.EjecutarSentenciaSP("Programacion.SP_InactivarCapacidadHormasSemanaActual", listaParametros)

    End Sub

    Public Sub inactivarProductosSemanaActual()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        operacion.EjecutarSentenciaSP("Programacion.SP_InactivarCapacidadProductosSemanaActual", listaParametros)

    End Sub

    Public Function consultaCapacidadesCelulasHorma(ByVal idNave As Int32,
                                                    ByVal idHorma As Int32,
                                                    ByVal idTalla As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT lp.linp_linpID, n.nave_naveid," & _
        " n.nave_nombre, lp.linp_nombre," & _
        " lp.linp_capacidad_diaria, hc.horc_año," & _
        " hc.horc_semanaelimina, hc.horc_activo" & _
        " FROM Programacion.LineasProduccion lp" & _
        " JOIN Programacion.HormasCapacidad hc ON hc.horc_linpID = lp.linp_linpID" & _
        " JOIN Programacion.NavesAux n ON lp.linp_idNave = n.nave_naveid" & _
        " WHERE lp.linp_activo = 1" & _
        " AND n.nave_activo = 1"
        If idNave > 0 Then
            cadena += " AND n.nave_naveid = " + idNave.ToString
        End If
        cadena += " AND hc.horc_año >= DATEPART(YEAR, GETDATE())" +
        " AND hc.horc_hormaID = " + idHorma.ToString & _
        " AND hc.horc_tallaid = " + idTalla.ToString & _
        " ORDER BY linp_nombre, hc.horc_año"




        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub eliminarAniosAnteriores()
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        operacion.EjecutarSentenciaSP("Programacion.SP_EliminarCapacidadesAniosAnteriores", listaParametros)
    End Sub

    Public Function consultarLineasDiferenteALaSeleccion(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" & _
            " lp.linp_linpID ID," & _
            " n.nave_nombre +' - '+ lp.linp_nombre as Descripcion," & _
            " lp.linp_capacidad_diaria Capacidad," & _
            " lp.linp_idNave idNave" & _
            " FROM Programacion.LineasProduccion lp" & _
            " INNER JOIN Programacion.NavesAux n" & _
            " ON lp.linp_idNave = n.nave_naveid" & _
            " WHERE n.nave_activo = 1" & _
            " AND linp_activo = 1" & _
            " AND n.nave_naveid <> " + idNave.ToString & _
            " ORDER BY n.nave_nombre ASC, lp.linp_nombre ASC"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultarArticulosLineaProduccion(ByVal idNave As Int32,
                                                        ByVal productosExcluir As String,
                                                        ByVal idSimulacion As Int32,
                                                        ByVal idLinea As Int32,
                                                        ByVal idNaveDestino As Int32,
                                                        ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" & _
            " CAST(0 AS BIT) AS Sel," & _
        " prod_codigo as codigo," & _
        " prod_descripcion +' ' + ve.pielColor+ ' ' +ve.talla as Descripcion," & _
        " ve.prod_productoid," & _
        " pstilo, idHorma, idTalla" & _
        " FROM vProductoEstilos ve WHERE ve.pres_activo = 1"

        If idNave > 0 Then
            cadena += " AND ve.pstilo IN (SELECT DISTINCT prna_productoEstiloID FROM Programacion.ProductosNave WHERE prna_activo = 1 AND prna_naveID = " + idNave.ToString + ")"
        End If


        cadena += " AND ve.pstilo NOT IN (SELECT DISTINCT(smac_productoEstiloId) FROM Programacion.simulacionArticuloCapacidad WHERE smac_activo = 1 AND smac_simulacionId = " + idSimulacion.ToString + " AND smac_lineaId = " + idLinea.ToString + " AND smac_anio = " + anio.ToString + ")"

        cadena += " AND ve.pstilo NOT IN (SELECT DISTINCT(smac_productoEstiloId) FROM Programacion.simulacionArticuloCapacidad WHERE smac_activo = 1 AND smac_simulacionId =  " + idSimulacion.ToString + " AND smac_lineaId IN (SELECT linp_linpID FROM Programacion.LineasProduccion WHERE linp_idNave = " + idNaveDestino.ToString + ")  AND smac_anio = " + anio.ToString + ")"

        If productosExcluir <> "0" Then
            cadena += " AND ve.pstilo NOT IN (" + productosExcluir + ")"
        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function


End Class
