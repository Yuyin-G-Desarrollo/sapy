Imports System.Data.SqlClient

Public Class VentasSicyDA

    Public Function verListaClasificacionesSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdClasificacion FROM Clasificaciones where st='A' ORDER BY IdClasificacion"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaClientesSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdCadena, nombre FROM Cadenas  ORDER BY nombre"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaClientesSicyPorAgente(ByVal idAgenteColabora As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT" +
                                " a.IdCadena," +
                                " a.nombre" +
                        " FROM Cadenas a" +
                        " JOIN CadenasMarcasAgentes b" +
                            " ON a.IdCadena = b.IdCadena" +
                        " JOIN Agentes c" +
                            " ON b.IdAgente = c.IdAgente" +
                                " WHERE c.codr_colaboradorid =" + idAgenteColabora.ToString +
                        " AND a.Activo = 'S'" +
                        " GROUP BY	a.IdCadena," +
                                " a.nombre" +
                        " ORDER BY a.nombre"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaAgentesSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdAgente, REPLACE(Nombre, ',', '') as Nombre FROM Agentes WHERE Activo=1 ORDER BY Nombre"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaModelosSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT REPLACE(Marca + ' ' + IdModelo, ',', '') AS ModeloDesc FROM vEstilos GROUP BY Marca, IdModelo ORDER BY Marca, IdModelo"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaDescripcionesSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdCodigo, REPLACE(Descripcion,',','') AS Descripcion FROM vEstilos WHERE Activo = 1 ORDER BY Descripcion"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaMarcasSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdMarca, Marca FROM Marcas WHERE Activo='S' ORDER BY Marca"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaColeccionesSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdColeccion, Coleccion FROM Colecciones WHERE Activo='S' ORDER BY Coleccion"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaCorridasSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdTalla, Talla FROM Tallas ORDER BY Talla"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaRutasSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT IdRuta, Ruta FROM Rutas ORDER BY Ruta"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaColoresSicy() As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT" +
                                " a.IdCombinacion," +
                                " b.Piel + ' ' + c.Nombre as PielColor" +
                            " FROM ColoresPiel a" +
                            " JOIN Pieles b" +
                                " ON a.IdPiel = b.IdPiel" +
                            " JOIN Colores c" +
                                " ON a.IdColor = c.IdColor" +
                            " WHERE a.Activo = 'S'" +
                            " AND b.Activo = 'S'" +
                            " AND c.Activo = 'S' ORDER BY B.Piel, c.Nombre"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function verListaCategorias() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT " +
                                    "tica_tipocategoriaid, " +
                                    "tica_descripcion, " +
                                    "tica_activo " +
                                    "FROM Programacion.TipoCategoria " +
                            "WHERE tica_activo = 1 Order by tica_descripcion"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function ListarFamilias() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos

        'consulta de las familas anteriores (5)
        '"Select" +
        ' " fami_familiaid, fami_codigo, fami_descripcioon, fami_activo" +
        ' " from Programacion.Familias" +
        ' " where fami_activo=1" +
        ' " ORDER BY fami_descripcioon"

        Dim cadena As String = "Select" +
                                " fapr_familiaproyeccionid as fami_familiaid,fapr_descripcion as fami_descripcion,fapr_activo as fami_activo" +
                                " from Programacion.Familias_Proyeccion" +
                                " where fapr_activo=1" +
                                " ORDER BY fami_descripcion"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function agenteReporteFiltro(ByVal colaboradorId As Int32) As DataTable
        Dim Operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim consulta As String = "SELECT Ventas.fn_ConcatenarAgentes(" + colaboradorId.ToString + ")"
        Return Operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function generarConsultaDash(ByVal filas As String, ByVal columnas As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal color As String, ByVal ruta As String, ByVal radioYO As String,
                                           ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String, ByVal ubicacion As String) As DataTable
        Dim operPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Dim tablaDashBoard As New DataTable
        Dim filaClasificacion As Boolean = False
        Dim filaCliente As Boolean = False
        Dim filaAgente As Boolean = False
        Dim filaMarca As Boolean = False
        Dim filaCategoria As Boolean = False
        Dim filaColeccion As Boolean = False
        Dim filaModelo As Boolean = False
        Dim filaDescripcion As Boolean = False
        Dim filaFamilia As Boolean = False
        Dim filaCorrida As Boolean = False
        Dim filaColor As Boolean = False
        Dim filaRuta As Boolean = False

        Dim columnaClasificacion As Boolean = False
        Dim columnaCliente As Boolean = False
        Dim columnaAgente As Boolean = False
        Dim columnaMarca As Boolean = False
        Dim columnaCategoria As Boolean = False
        Dim columnaColeccion As Boolean = False
        Dim columnaModelo As Boolean = False
        Dim columnaDescripcion As Boolean = False
        Dim columnaFamilia As Boolean = False
        Dim columnaCorrida As Boolean = False
        Dim columnaColor As Boolean = False
        Dim columnaRuta As Boolean = False
        Dim cadenaSelect As String = "SELECT"
        Dim cadenaGroupBy As String = ""
        Dim consultaGenerada = String.Empty
        Dim cadenaWhereConsulta As String = String.Empty
        Dim totalesArticulosColeccionesColumnas As String = ""
        Dim totalCadenaGroupByColumnas As String = ""
        Dim totalorderByConsultaColumnas As String = ""
        Dim dtTotalesArticulosColumnas As New DataTable
        Dim totalesArticulosColeccionesFilas As String = ""
        Dim totalCadenaGroupByFilas As String = ""
        Dim totalorderByConsultaFilas As String = ""
        Dim dtTotalesArticulosFilas As New DataTable
        Dim dtTablaGeneradaDashboard As New DataTable
        Dim cadenaInnerVistaCategoriaFamilias As String = String.Empty
        Dim opSuma As Boolean = False
        Dim opArticulos As Boolean = False
        Dim opColecciones As Boolean = False
        Dim contadorColumnasFila As Int32 = 0
        Dim contColumnasConsulta As Int32 = 0
        Dim concatAgente As String = String.Empty
        Dim dtTablaFinal As New DataTable
        Dim dtDatosRetornados As New DataTable
        Dim orderByConsulta As String = ""

        If operaciones = "optSuma" Then
            opSuma = True
        ElseIf operaciones = "optCantArt" Then
            opArticulos = True
        ElseIf operaciones = "optCantCole" Then
            opColecciones = True
        End If

        Dim cadenaConsulta As String = " FROM Ventas.vwVentas vn" +
            " INNER JOIN Ventas.vwVentasDetalles vt ON vn.IdRemision = vt.IdRemision AND vn.año = vt.año" +
            " INNER JOIN vEstilos ve ON vt.IdCodigo = ve.IdCodigo" +
            " INNER JOIN Cadenas c	ON vn.IdCadena = c.IdCadena"

        Try
            cadenaWhereConsulta = " WHERE FechaVenta >= '" + fechaUno + "' AND FechaVenta <= '" + fechaDos + "'" + "AND ISNULL(vn.Estatus, '') NOT IN ('cancelado') AND ISNULL(vn.TipoVenta, '') NOT IN ('F')"
            Dim whereConstruido As String = ""
            If Len(agentes) > 0 Then
                Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                cadenaAgenteWhere = "'0'"
                arraycomillasAgente = Strings.Split(agentes, ",")
                For iAgente = 0 To UBound(arraycomillasAgente)
                    cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                Else
                    whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                End If
            End If

            If Len(clasificacion) > 0 Then
                Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                cadenaClasificacionWhere = "'0'"
                arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                For iClas = 0 To UBound(arraycomillasClasificacion)
                    cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                Else
                    whereConstruido += " AND (c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                End If
            End If

            If Len(clientes) > 0 Then
                Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                cadenaClienteWhere = "'0'"
                arraycomillasClientes = Strings.Split(clientes, ",")
                For iCli = 0 To UBound(arraycomillasClientes)
                    cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                Else
                    whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                End If

            End If

            If Len(colecciones) > 0 Then
                Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                cadenaColeccionWhere = "'0'"
                arraycomillasColecciones = Strings.Split(colecciones, ",")
                For iCol = 0 To UBound(arraycomillasColecciones)
                    cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                Else
                    whereConstruido += " AND (REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                End If

            End If

            If Len(marcas) > 0 Then
                Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                cadenaMarcaWhere = "'0'"
                arraycomillasMarca = Strings.Split(marcas, ",")
                For iMar = 0 To UBound(arraycomillasMarca)
                    cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " ve.marca IN (" + cadenaMarcaWhere + ")"
                Else
                    whereConstruido += " AND (ve.marca IN (" + cadenaMarcaWhere + ")"
                End If
            End If

            If Len(modelos) > 0 Then
                Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                cadenaModeloWhere = "'0'"
                arraycomillasModelo = Strings.Split(modelos, ",")
                For idmod = 0 To UBound(arraycomillasModelo)
                    cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                Else
                    whereConstruido += " AND (REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                End If
            End If

            If Len(descripcion) > 0 Then
                Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                cadenaDescripcionWhere = "'0'"
                arraycomillasDescripcion = Strings.Split(descripcion, ",")
                For iDesc = 0 To UBound(arraycomillasDescripcion)
                    cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                Next


                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                Else
                    whereConstruido += " AND (ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                End If

            End If

            If Len(color) > 0 Then
                Dim arraycomillasColor() As String, cadenaColorWhere As String
                cadenaColorWhere = "'0'"
                arraycomillasColor = Strings.Split(clasificacion, ",")
                For iColor = 0 To UBound(arraycomillasColor)
                    cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " ve.Color IN (" + cadenaColorWhere + ")"
                Else
                    whereConstruido += " AND (ve.Color IN (" + cadenaColorWhere + ")"
                End If
            End If

            Dim arrayFilas() As String
            arrayFilas = Strings.Split(filas, ",")
            Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
            For contFila As Int32 = 0 To UBound(arrayFilas)
                If arrayFilas(contFila) = "optClasificacion" Then
                    filaClasificacion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.Clasificacion"
                    Else
                        cadenaSelect += ", c.Clasificacion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.Clasificacion"
                    Else
                        cadenaGroupBy += ", c.Clasificacion"
                    End If


                ElseIf arrayFilas(contFila) = "optCliente" Then
                    filaCliente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.nombre"
                    Else
                        cadenaSelect += ", c.nombre"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.nombre"
                    Else
                        cadenaGroupBy += ", c.nombre"
                    End If

                ElseIf arrayFilas(contFila) = "optAgente" Then
                    filaAgente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " a.Nombre as Agente "
                    Else
                        cadenaSelect += ", a.Nombre as Agente "
                    End If

                    cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " a.Nombre "
                    Else
                        cadenaGroupBy += ", a.Nombre "
                    End If


                ElseIf arrayFilas(contFila) = "optMarca" Then
                    filaMarca = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca"
                    Else
                        cadenaSelect += ", ve.marca"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.marca"
                    Else
                        cadenaGroupBy += ", ve.marca"
                    End If

                ElseIf arrayFilas(contFila) = "optCategoria" Then
                    filaCategoria = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " tica_descripcion as 'NAVE DESARROLLA'"
                    Else
                        cadenaSelect += ", tica_descripcion as 'NAVE DESARROLLA'"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " tica_descripcion"
                    Else
                        cadenaGroupBy += ", tica_descripcion"
                    End If

                    If Len(categoria) > 0 Then
                        Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                        cadenaCategoriaWhere = "'0'"
                        arraycomillasCategoria = Strings.Split(categoria, ",")
                        For idmod = 0 To UBound(arraycomillasCategoria)
                            cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        Else
                            whereConstruido += " AND ( tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        End If

                    End If

                ElseIf arrayFilas(contFila) = "optColeccion" Then
                    filaColeccion = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca+' '+ve.Coleccion AS Coleccion"
                    Else
                        cadenaSelect += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += "ve.marca, ve.Coleccion"
                    Else
                        cadenaGroupBy += ", ve.marca, ve.Coleccion"
                    End If

                ElseIf arrayFilas(contFila) = "optModelo" Then
                    filaModelo = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    Else
                        cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Marca, ve.IdModelo"
                    Else
                        cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                    End If

                ElseIf arrayFilas(contFila) = "optDescripcion" Then
                    filaDescripcion = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Descripcion"
                    Else
                        cadenaSelect += ", ve.Descripcion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Descripcion"
                    Else
                        cadenaGroupBy += ", ve.Descripcion"
                    End If

                ElseIf arrayFilas(contFila) = "optFamilia" Then
                    filaFamilia = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " fami_descripcion AS Familia"
                    Else
                        cadenaSelect += ", fami_descripcion AS Familia"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " fami_descripcion"
                    Else
                        cadenaGroupBy += ", fami_descripcion"
                    End If

                    If Len(familias) > 0 Then
                        Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                        cadenaFamiliaWhere = "'0'"
                        arraycomillasFamilia = Strings.Split(familias, ",")
                        For idFam = 0 To UBound(arraycomillasFamilia)
                            cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        Else
                            whereConstruido += " AND ( fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        End If

                    End If

                ElseIf arrayFilas(contFila) = "optCorrida" Then
                    filaCorrida = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " t.Talla"
                    Else
                        cadenaSelect += ", t.Talla"
                    End If
                    cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " t.Talla"
                    Else
                        cadenaGroupBy += ", t.Talla"
                    End If

                    If Len(corrida) > 0 Then
                        Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                        cadenaCorridaWhere = "'0'"
                        arraycomillasCorrida = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasCorrida)
                            cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                        Else
                            whereConstruido += " AND ( t.Talla IN (" + cadenaCorridaWhere + ")"
                        End If
                    End If

                ElseIf arrayFilas(contFila) = "optColor" Then
                    filaColor = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Color AS COLOR"
                    Else
                        cadenaSelect += ", ve.Color AS COLOR"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Color"
                    Else
                        cadenaGroupBy += ", ve.Color"
                    End If

                ElseIf arrayFilas(contFila) = "optRuta" Then
                    filaRuta = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " r.Ruta AS RUTA"
                    Else
                        cadenaSelect += ", r.Ruta AS RUTA"
                    End If
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " r.Ruta"
                    Else
                        cadenaGroupBy += ", r.Ruta"
                    End If

                    If Len(ruta) > 0 Then
                        Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                        cadenaRutaWhere = "'0'"
                        arraycomillasRuta = Strings.Split(ruta, ",")
                        For iRuta = 0 To UBound(arraycomillasRuta)
                            cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                        Else
                            whereConstruido += " AND ( r.IdRuta IN (" + cadenaRutaWhere + ")"
                        End If

                    End If

                End If
            Next contFila


            Dim arrayColumnas() As String
            arrayColumnas = Strings.Split(columnas, ",")
            Dim tamanoCamposColumnas As Int32 = (CInt(UBound(arrayColumnas))) + 1
            Dim columnasSeleccion As Int32 = UBound(arrayColumnas)
            For contColumna As Int32 = 0 To UBound(arrayColumnas)
                If arrayColumnas(contColumna) = "optClasificacion" Then
                    columnaClasificacion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.Clasificacion"
                    Else
                        cadenaSelect += ", c.Clasificacion"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.Clasificacion"
                    Else
                        cadenaGroupBy += ", c.Clasificacion"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by c.Clasificacion"
                    Else
                        orderByConsulta += ", c.Clasificacion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCliente" Then
                    columnaCliente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.nombre"
                    Else
                        cadenaSelect += ", c.nombre"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.nombre"
                    Else
                        cadenaGroupBy += ", c.nombre"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by c.nombre"
                    Else
                        orderByConsulta += ", c.nombre"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optAgente" Then
                    columnaAgente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " a.Nombre as Agente "
                    Else
                        cadenaSelect += ", a.Nombre as Agente "
                    End If
                    cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " a.Nombre"
                    Else
                        cadenaGroupBy += ", a.Nombre"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by a.Nombre"
                    Else
                        orderByConsulta += ", a.Nombre"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optMarca" Then
                    columnaMarca = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca"
                    Else
                        cadenaSelect += ", ve.marca"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.marca"
                    Else
                        cadenaGroupBy += ", ve.marca"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ve.marca"
                    Else
                        orderByConsulta += ", ve.marca"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCategoria" Then
                    columnaCategoria = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " tica_descripcion as 'NAVE DESARROLLA'"
                    Else
                        cadenaSelect += ", tica_descripcion as 'NAVE DESARROLLA'"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodig AND vt.IdTalla=FC.talla_sicyo"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " tica_descripcion"
                    Else
                        cadenaGroupBy += ", tica_descripcion"
                    End If
                    If Len(categoria) > 0 Then
                        Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                        cadenaCategoriaWhere = "'0'"
                        arraycomillasCategoria = Strings.Split(categoria, ",")
                        For idmod = 0 To UBound(arraycomillasCategoria)
                            cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        Else
                            whereConstruido += " AND ( tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        End If

                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by tica_descripcion"
                    Else
                        orderByConsulta += ", tica_descripcion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optColeccion" Then
                    columnaColeccion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca+' '+ve.Coleccion AS Coleccion"
                    Else
                        cadenaSelect += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += "ve.marca, ve.Coleccion"
                    Else
                        cadenaGroupBy += ", ve.marca, ve.Coleccion"
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ve.Coleccion"
                    Else
                        orderByConsulta += ", ve.Coleccion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optModelo" Then
                    columnaModelo = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    Else
                        cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Marca, ve.IdModelo"
                    Else
                        cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ModeloDesc"
                    Else
                        orderByConsulta += ", ModeloDesc"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optDescripcion" Then
                    columnaDescripcion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Descripcion"
                    Else
                        cadenaSelect += ", ve.Descripcion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Descripcion"
                    Else
                        cadenaGroupBy += ", ve.Descripcion"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ve.Descripcion"
                    Else
                        orderByConsulta += ", ve.Descripcion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optFamilia" Then
                    columnaFamilia = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " fami_descripcion AS Familia"
                    Else
                        cadenaSelect += ", fami_descripcion AS Familia"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " fami_descripcion"
                    Else
                        cadenaGroupBy += ", fami_descripcion"
                    End If

                    If Len(familias) > 0 Then
                        Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                        cadenaFamiliaWhere = "'0'"
                        arraycomillasFamilia = Strings.Split(familias, ",")
                        For idFam = 0 To UBound(arraycomillasFamilia)
                            cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        Else
                            whereConstruido += " AND ( fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by fami_descripcion"
                    Else
                        orderByConsulta += ", fami_descripcion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCorrida" Then
                    columnaCorrida = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " t.Talla"
                    Else
                        cadenaSelect += ", t.Talla"
                    End If
                    cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " t.Talla"
                    Else
                        cadenaGroupBy += ", t.Talla"
                    End If

                    If Len(corrida) > 0 Then
                        Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                        cadenaCorridaWhere = "'0'"
                        arraycomillasCorrida = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasCorrida)
                            cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                        Else
                            whereConstruido += " AND ( t.Talla IN (" + cadenaCorridaWhere + ")"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by t.Talla"
                    Else
                        orderByConsulta += ", t.Talla"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optColor" Then
                    columnaColor = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Color AS COLOR"
                    Else
                        cadenaSelect += ", ve.Color AS COLOR"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Color"
                    Else
                        cadenaGroupBy += ", ve.Color"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by COLOR"
                    Else
                        orderByConsulta += ", COLOR"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optRuta" Then
                    columnaRuta = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " r.Ruta AS RUTA"
                    Else
                        cadenaSelect += ", r.Ruta AS RUTA"
                    End If
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " r.Ruta"
                    Else
                        cadenaGroupBy += ", r.Ruta"
                    End If

                    If Len(ruta) > 0 Then
                        Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                        cadenaRutaWhere = "'0'"
                        arraycomillasRuta = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasRuta)
                            cadenaRutaWhere += ", '" + arraycomillasRuta(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + "))"
                        Else
                            whereConstruido += " AND ( r.IdRuta IN (" + cadenaRutaWhere + "))"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by RUTA"
                    Else
                        orderByConsulta += ", RUTA"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                End If
            Next contColumna

            If opArticulos = True Or opColecciones = True Then

                For contColumnaTot As Int32 = 0 To UBound(arrayColumnas)
                    If arrayColumnas(contColumnaTot) = "optClasificacion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByColumnas += ", c.Clasificacion"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByColumnas += ", c.Clasificacion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by c.Clasificacion"
                        Else
                            totalCadenaGroupByColumnas += ", c.Clasificacion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCliente" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " c.nombre"
                        Else
                            totalesArticulosColeccionesColumnas += ", c.nombre"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " c.nombre"
                        Else
                            totalCadenaGroupByColumnas += ", c.nombre"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by c.nombre"
                        Else
                            totalorderByConsultaColumnas += ", c.nombre"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optAgente" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " a.Nombre as Agente "
                        Else
                            totalesArticulosColeccionesColumnas += ", a.Nombre as Agente "
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " a.Nombre"
                        Else
                            totalCadenaGroupByColumnas += ", a.Nombre"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by a.Nombre"
                        Else
                            totalorderByConsultaColumnas += ", a.Nombre"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optMarca" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.marca"
                        Else
                            totalesArticulosColeccionesColumnas += ", ve.marca"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.marca"
                        Else
                            totalCadenaGroupByColumnas += ", ve.marca"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ve.marca"
                        Else
                            totalorderByConsultaColumnas += ", ve.marca"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCategoria" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " tica_descripcion as 'NAVE DESARROLLA'"
                        Else
                            totalesArticulosColeccionesColumnas += ", tica_descripcion as 'NAVE DESARROLLA'"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " tica_descripcion"
                        Else
                            totalCadenaGroupByColumnas += ", tica_descripcion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by tica_descripcion"
                        Else
                            totalorderByConsultaColumnas += ", tica_descripcion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optColeccion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.marca+' '+ve.Coleccion AS Coleccion"
                        Else
                            totalesArticulosColeccionesColumnas += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += "ve.marca, ve.Coleccion"
                        Else
                            totalCadenaGroupByColumnas += ", ve.marca, ve.Coleccion"
                        End If

                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ve.Coleccion"
                        Else
                            totalorderByConsultaColumnas += ", ve.Coleccion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optModelo" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        Else
                            totalesArticulosColeccionesColumnas += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.Marca, ve.IdModelo"
                        Else
                            totalCadenaGroupByColumnas += ", ve.Marca, ve.IdModelo"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ModeloDesc"
                        Else
                            totalorderByConsultaColumnas += ", ModeloDesc"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optDescripcion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.Descripcion"
                        Else
                            totalesArticulosColeccionesColumnas += ", ve.Descripcion"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.Descripcion"
                        Else
                            totalCadenaGroupByColumnas += ", ve.Descripcion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ve.Descripcion"
                        Else
                            totalorderByConsultaColumnas += ", ve.Descripcion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optFamilia" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " fami_descripcion AS Familia"
                        Else
                            totalesArticulosColeccionesColumnas += ", fami_descripcion AS Familia"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " fami_descripcion"
                        Else
                            totalCadenaGroupByColumnas += ", fami_descripcion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by fami_descripcion"
                        Else
                            totalorderByConsultaColumnas += ", fami_descripcion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCorrida" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " t.Talla"
                        Else
                            totalesArticulosColeccionesColumnas += ", t.Talla"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " t.Talla"
                        Else
                            totalCadenaGroupByColumnas += ", t.Talla"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by t.Talla"
                        Else
                            totalorderByConsultaColumnas += ", t.Talla"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optColor" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.Color AS COLOR"
                        Else
                            totalesArticulosColeccionesColumnas += ", ve.Color AS COLOR"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.Color"
                        Else
                            totalCadenaGroupByColumnas += ", ve.Color"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by COLOR"
                        Else
                            totalorderByConsultaColumnas += ", COLOR"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optRuta" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " r.Ruta AS RUTA"
                        Else
                            totalesArticulosColeccionesColumnas += ", r.Ruta AS RUTA"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " r.Ruta"
                        Else
                            totalCadenaGroupByColumnas += ", r.Ruta"
                        End If

                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by RUTA"
                        Else
                            totalorderByConsultaColumnas += ", RUTA"
                        End If

                    End If
                Next

                For contFilaTot As Int32 = 0 To UBound(arrayFilas)
                    If arrayFilas(contFilaTot) = "optClasificacion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByFilas += ", c.Clasificacion"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByFilas += ", c.Clasificacion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by c.Clasificacion"
                        Else
                            totalCadenaGroupByFilas += ", c.Clasificacion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCliente" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " c.nombre"
                        Else
                            totalesArticulosColeccionesFilas += ", c.nombre"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " c.nombre"
                        Else
                            totalCadenaGroupByFilas += ", c.nombre"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by c.nombre"
                        Else
                            totalorderByConsultaFilas += ", c.nombre"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optAgente" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " a.Nombre as Agente "
                        Else
                            totalesArticulosColeccionesFilas += ", a.Nombre as Agente "
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " a.Nombre"
                        Else
                            totalCadenaGroupByFilas += ", a.Nombre"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by a.Nombre"
                        Else
                            totalorderByConsultaFilas += ", a.Nombre"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optMarca" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.marca"
                        Else
                            totalesArticulosColeccionesFilas += ", ve.marca"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.marca"
                        Else
                            totalCadenaGroupByFilas += ", ve.marca"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ve.marca"
                        Else
                            totalorderByConsultaFilas += ", ve.marca"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCategoria" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " tica_descripcion as 'NAVE DESARROLLA'"
                        Else
                            totalesArticulosColeccionesFilas += ", tica_descripcion as 'NAVE DESARROLLA'"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " tica_descripcion"
                        Else
                            totalCadenaGroupByFilas += ", tica_descripcion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by tica_descripcion"
                        Else
                            totalorderByConsultaFilas += ", tica_descripcion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optColeccion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.marca+' '+ve.Coleccion AS Coleccion"
                        Else
                            totalesArticulosColeccionesFilas += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += "ve.marca, ve.Coleccion"
                        Else
                            totalCadenaGroupByFilas += ", ve.marca, ve.Coleccion"
                        End If

                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ve.Coleccion"
                        Else
                            totalorderByConsultaFilas += ", ve.Coleccion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optModelo" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        Else
                            totalesArticulosColeccionesFilas += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.Marca, ve.IdModelo"
                        Else
                            totalCadenaGroupByFilas += ", ve.Marca, ve.IdModelo"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ModeloDesc"
                        Else
                            totalorderByConsultaFilas += ", ModeloDesc"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optDescripcion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.Descripcion"
                        Else
                            totalesArticulosColeccionesFilas += ", ve.Descripcion"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.Descripcion"
                        Else
                            totalCadenaGroupByFilas += ", ve.Descripcion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ve.Descripcion"
                        Else
                            totalorderByConsultaFilas += ", ve.Descripcion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optFamilia" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " fami_descripcion AS Familia"
                        Else
                            totalesArticulosColeccionesFilas += ", fami_descripcion AS Familia"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " fami_descripcion"
                        Else
                            totalCadenaGroupByFilas += ", fami_descripcion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by fami_descripcion"
                        Else
                            totalorderByConsultaFilas += ", fami_descripcion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCorrida" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " t.Talla"
                        Else
                            totalesArticulosColeccionesFilas += ", t.Talla"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " t.Talla"
                        Else
                            totalCadenaGroupByFilas += ", t.Talla"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by t.Talla"
                        Else
                            totalorderByConsultaFilas += ", t.Talla"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optColor" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.Color AS COLOR"
                        Else
                            totalesArticulosColeccionesFilas += ", ve.Color AS COLOR"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.Color"
                        Else
                            totalCadenaGroupByFilas += ", ve.Color"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by COLOR"
                        Else
                            totalorderByConsultaFilas += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optRuta" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " r.Ruta AS RUTA"
                        Else
                            totalesArticulosColeccionesFilas += ", r.Ruta AS RUTA"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " r.Ruta"
                        Else
                            totalCadenaGroupByFilas += ", r.Ruta"
                        End If

                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by RUTA"
                        Else
                            totalorderByConsultaFilas += ", RUTA"
                        End If

                    End If
                Next

            End If
            If Len(categoria) > 0 And filaCategoria = False And columnaCategoria = False Then
                If cadenaInnerVistaCategoriaFamilias = "" Then
                    cadenaInnerVistaCategoriaFamilias = "Contenido"
                    cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                End If
                Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                cadenaCategoriaWhere = "'0'"
                arraycomillasCategoria = Strings.Split(categoria, ",")
                For idmod = 0 To UBound(arraycomillasCategoria)
                    cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                Else
                    whereConstruido += " AND ( tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                End If
            End If

            If Len(familias) > 0 And filaFamilia = False And columnaFamilia = False Then
                If cadenaInnerVistaCategoriaFamilias = "" Then
                    cadenaInnerVistaCategoriaFamilias = "Contenido"
                    cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                End If

                Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                cadenaFamiliaWhere = "'0'"
                arraycomillasFamilia = Strings.Split(familias, ",")
                For idFam = 0 To UBound(arraycomillasFamilia)
                    cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                Else
                    whereConstruido += " AND ( fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                End If
            End If


            If Len(corrida) > 0 And filaCorrida = False And columnaCorrida = False Then
                cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"

                Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                cadenaCorridaWhere = "'0'"
                arraycomillasCorrida = Strings.Split(corrida, ",")
                For iCor = 0 To UBound(arraycomillasCorrida)
                    cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                Else
                    whereConstruido += " AND ( t.Talla IN (" + cadenaCorridaWhere + ")"
                End If
            End If

            If Len(ruta) > 0 And filaRuta = False And columnaRuta = False Then
                cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                cadenaRutaWhere = "'0'"
                arraycomillasRuta = Strings.Split(ruta, ",")
                For iRuta = 0 To UBound(arraycomillasRuta)
                    cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                Else
                    whereConstruido += " AND ( r.IdRuta IN (" + cadenaRutaWhere + ")"
                End If
            End If

            '---------------------------------------------------------------
            '---------------------------------------------------------------
            '---------------------------------------------------------------

            If whereConstruido.Length > 0 Then
                cadenaWhereConsulta += whereConstruido + ")"
            End If

            If opSuma = True Then
                cadenaSelect += ", SUM(vt.Cantidad) AS PARES"
            End If
            If opColecciones = True Then
                cadenaSelect += ", COUNT(DISTINCT ve.Marca + ve.Coleccion) AS COLECCIONES"
            End If
            If opArticulos = True Then
                cadenaSelect += ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS"
                ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
            End If


            Dim cadenaFinal As String = ""
            Dim cadFinTotArtsColsColumnas As String = ""
            Dim cadFinTotArtsColsFilas As String = ""
            cadenaFinal = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta

            If opColecciones = True Or opArticulos = True Then
                If opColecciones = True Then
                    cadFinTotArtsColsColumnas = "SELECT " + totalesArticulosColeccionesColumnas + ", COUNT(DISTINCT ve.Marca + ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByColumnas + " " + totalorderByConsultaColumnas
                    cadFinTotArtsColsFilas = "SELECT " + totalesArticulosColeccionesFilas + ", COUNT(DISTINCT ve.Marca + ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByFilas + " " + totalorderByConsultaFilas
                End If
                If opArticulos = True Then
                    cadFinTotArtsColsColumnas = "SELECT " + totalesArticulosColeccionesColumnas + ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByColumnas + " " + totalorderByConsultaColumnas
                    cadFinTotArtsColsFilas = "SELECT " + totalesArticulosColeccionesFilas + ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByFilas + " " + totalorderByConsultaFilas
                End If

            End If


            Dim dtTablaContruida As New DataTable
            Dim cadenaSort As String = String.Empty

            For contFilaDT = 0 To UBound(arrayFilas)
                If arrayFilas(contFilaDT) = "optClasificacion" Then
                    dtTablaContruida.Columns.Add("CLASIFICACION")
                    dtTablaContruida.Columns("CLASIFICACION").Caption = "CLASIFICACIÓN"
                    cadenaSort += "CLASIFICACION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCliente" Then
                    dtTablaContruida.Columns.Add("CLIENTE")
                    cadenaSort += "CLIENTE ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optAgente" Then
                    dtTablaContruida.Columns.Add("AGENTE")
                    cadenaSort += "AGENTE ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optMarca" Then
                    dtTablaContruida.Columns.Add("MARCA")
                    cadenaSort += "MARCA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCategoria" Then
                    dtTablaContruida.Columns.Add("NAVE DESARROLLA")
                    dtTablaContruida.Columns("NAVE DESARROLLA").Caption = "NAVE DESARROLLA"
                    cadenaSort += "NAVE DESARROLLA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optColeccion" Then
                    dtTablaContruida.Columns.Add("COLECCION")
                    dtTablaContruida.Columns("COLECCION").Caption = "COLECCIÓN"
                    cadenaSort += "COLECCION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optModelo" Then
                    dtTablaContruida.Columns.Add("MODELO")
                    cadenaSort += "MODELO ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optDescripcion" Then
                    dtTablaContruida.Columns.Add("DESCRIPCION")
                    dtTablaContruida.Columns("DESCRIPCION").Caption = "DESCRIPCIÓN"
                    cadenaSort += "DESCRIPCION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optFamilia" Then
                    dtTablaContruida.Columns.Add("FAMILIA")
                    cadenaSort += "FAMILIA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCorrida" Then
                    dtTablaContruida.Columns.Add("CORRIDA")
                    cadenaSort += "CORRIDA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optColor" Then
                    dtTablaContruida.Columns.Add("COLOR")
                    cadenaSort += "COLOR ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optRuta" Then
                    dtTablaContruida.Columns.Add("RUTA")
                    cadenaSort += "RUTA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1
                End If
            Next contFilaDT

            Dim dtDatosConsulta As New DataTable
            Dim contadorValidador As Int32 = 0
            dtDatosConsulta = operPersistencia.EjecutaConsulta(cadenaFinal)

            contadorValidador = dtDatosConsulta.Rows.Count
            If contadorValidador > 0 Then

                If opArticulos = True Or opColecciones = True Then
                    dtTotalesArticulosColumnas = operPersistencia.EjecutaConsulta(cadFinTotArtsColsColumnas)
                    dtTotalesArticulosFilas = operPersistencia.EjecutaConsulta(cadFinTotArtsColsFilas)
                End If

                Dim contNameColumna As Int32 = 0
                For Each rowdt As DataRow In dtDatosConsulta.Rows
                    dtTablaContruida.Columns.Add("columna" + contNameColumna.ToString)
                    contNameColumna = contNameColumna + 1
                Next

                For contFilaConcatena = 0 To UBound(arrayColumnas)
                    If arrayColumnas(contFilaConcatena) = "optClasificacion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Clasificacion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCliente" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("nombre").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optAgente" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Agente").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optMarca" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Marca").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)


                    ElseIf arrayColumnas(contFilaConcatena) = "optCategoria" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("NAVE DESARROLLA").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optColeccion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Coleccion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optModelo" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("ModeloDesc").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optDescripcion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Descripcion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optFamilia" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Familia").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCorrida" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Talla").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optColor" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Color").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optRuta" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Ruta").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)
                    End If
                Next

                For Each rowDTDT As DataRow In dtDatosConsulta.Rows
                    Dim filaNueva As DataRow = dtTablaContruida.NewRow

                    If filaClasificacion = True Then
                        filaNueva("CLASIFICACION") = rowDTDT.Item("Clasificacion").ToString

                    End If
                    If filaAgente = True Then
                        filaNueva("AGENTE") = rowDTDT.Item("Agente").ToString

                    End If
                    If filaCliente = True Then
                        filaNueva("CLIENTE") = rowDTDT.Item("nombre").ToString

                    End If
                    If filaMarca = True Then
                        filaNueva("MARCA") = rowDTDT.Item("Marca").ToString

                    End If
                    If filaColeccion = True Then
                        filaNueva("COLECCION") = rowDTDT.Item("Coleccion").ToString

                    End If
                    If filaCategoria = True Then
                        filaNueva("NAVE DESARROLLA") = rowDTDT.Item("NAVE DESARROLLA").ToString

                    End If
                    If filaModelo = True Then
                        filaNueva("MODELO") = rowDTDT.Item("ModeloDesc").ToString

                    End If
                    If filaDescripcion = True Then
                        filaNueva("DESCRIPCION") = rowDTDT.Item("Descripcion").ToString

                    End If
                    If filaFamilia = True Then
                        filaNueva("FAMILIA") = rowDTDT.Item("Familia").ToString

                    End If
                    If filaCorrida = True Then
                        filaNueva("CORRIDA") = rowDTDT.Item("Talla").ToString

                    End If
                    If filaColor = True Then
                        filaNueva("COLOR") = rowDTDT.Item("COLOR").ToString
                    End If

                    If filaRuta = True Then
                        filaNueva("RUTA") = rowDTDT.Item("RUTA").ToString
                    End If

                    Dim importarFila As Boolean = True

                    For Each roWdCT As DataRow In dtTablaContruida.Rows
                        Dim comparer As IEqualityComparer(Of DataRow) = DataRowComparer.Default
                        Dim bEqual = comparer.Equals(roWdCT, filaNueva)

                        If (bEqual = True) Then
                            importarFila = False
                        End If
                    Next

                    If importarFila = True Then
                        dtTablaContruida.Rows.Add(filaNueva)
                    End If
                Next

                For consCOl As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1
                    Dim esigual As Boolean = True
                    For Each rowdtCons As DataRow In dtTablaContruida.Rows
                        If rowdtCons.Item(consCOl).ToString <> rowdtCons.Item(consCOl - 1).ToString Then
                            esigual = False
                        End If
                    Next
                    If esigual = True Then
                        dtTablaContruida.Columns.RemoveAt(consCOl)
                    End If
                Next

                ''If filaRuta = True Then
                ''    For tamFils As Int32 = 0 To tamanoCamposFilas - 1
                ''        For consCol As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1
                ''            Dim contadorIgual As Int32 = 0
                ''            For consColDos As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1

                ''                If dtTablaContruida.Rows(tamFils).Item(consCol).ToString = dtTablaContruida.Rows(tamFils).Item(consColDos).ToString Then
                ''                    contadorIgual = contadorIgual + 1
                ''                End If
                ''            Next
                ''            If contadorIgual > 1 Then
                ''                dtTablaContruida.Columns.RemoveAt(consCol)
                ''            End If
                ''        Next
                ''    Next
                ''End If

                Dim contador As Int32 = 0
                For Each rowCNTRA As DataRow In dtTablaContruida.Rows
                    Dim columnaIncrusta As Int32 = 0

                    For Each rowCONS As DataRow In dtDatosConsulta.Rows
                        Dim esIgual As Boolean = True
                        If filaClasificacion = True Then
                            If rowCNTRA.Item("CLASIFICACION").ToString <> rowCONS.Item("Clasificacion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCliente = True Then
                            If rowCNTRA.Item("CLIENTE").ToString <> rowCONS.Item("nombre").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaAgente = True Then
                            If rowCNTRA.Item("AGENTE").ToString <> rowCONS.Item("Agente").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaMarca = True Then
                            If rowCNTRA.Item("MARCA").ToString <> rowCONS.Item("Marca").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCategoria = True Then
                            If rowCNTRA.Item("NAVE DESARROLLA").ToString <> rowCONS.Item("NAVE DESARROLLA").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaColeccion = True Then
                            If rowCNTRA.Item("COLECCION").ToString <> rowCONS.Item("Coleccion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaModelo = True Then
                            If rowCNTRA.Item("MODELO").ToString <> rowCONS.Item("ModeloDesc").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaDescripcion = True Then
                            If rowCNTRA.Item("DESCRIPCION").ToString <> rowCONS.Item("Descripcion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaFamilia = True Then
                            If rowCNTRA.Item("FAMILIA").ToString <> rowCONS.Item("Familia").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCorrida = True Then
                            If rowCNTRA.Item("CORRIDA").ToString <> rowCONS.Item("Talla").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaColor = True Then
                            If rowCNTRA.Item("COLOR").ToString <> rowCONS.Item("COLOR").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaRuta = True Then
                            If rowCNTRA.Item("RUTA").ToString <> rowCONS.Item("RUTA").ToString Then
                                esIgual = False
                            End If
                        End If

                        If esIgual = True Then
                            Dim incrustar As Boolean = True
                            contador = contador + 1
                            For Each columnCTR As DataColumn In dtTablaContruida.Columns
                                Dim dtCon As Int32 = 0
                                Dim inserta As Boolean = True
                                For dtfil As Int32 = tamanoCamposFilas To dtDatosConsulta.Columns.Count - 2
                                    Dim DAM As String = dtTablaContruida.Rows(dtCon).Item(columnCTR.ColumnName.ToString).ToString
                                    If rowCONS.Item(dtfil).ToString <> dtTablaContruida.Rows(dtCon).Item(columnCTR.ColumnName.ToString).ToString Then
                                        inserta = False
                                    End If
                                    dtCon = dtCon + 1
                                Next
                                If inserta = True Then
                                    If opSuma = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("PARES").ToString
                                    ElseIf opColecciones = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("COLECCIONES").ToString
                                    ElseIf opArticulos = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("ARTICULOS").ToString
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next


                Dim viewDtDatos As New DataView(dtTablaContruida)
                viewDtDatos.Sort = cadenaSort.Substring(0, cadenaSort.Length - 1)
                tablaDashBoard = viewDtDatos.ToTable

                For contDTB As Int32 = 0 To tamanoCamposFilas - 1
                    tablaDashBoard.Rows(0).Item(contDTB) = dtTablaContruida.Columns(contDTB).Caption
                Next

                tablaDashBoard.Columns.Add("TOTAL")
                tablaDashBoard.Rows(0).Item("TOTAL") = "TOTAL"

                If opSuma = True Then
                    tablaDashBoard.Rows.Add()
                    Dim columnaTotal As Int32 = tablaDashBoard.Columns.Count - 1
                    For contRowD As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                        Dim total As Int32 = 0
                        For contColD As Int32 = tamanoCamposFilas To tablaDashBoard.Columns.Count - 2
                            If tablaDashBoard.Rows(contRowD).Item(contColD).ToString.ToString <> "" Then
                                total = total + CInt(tablaDashBoard.Rows(contRowD).Item(contColD))
                            End If
                        Next
                        tablaDashBoard.Rows(contRowD).Item("TOTAL") = total
                    Next

                    Dim filaFinal As Int32 = tablaDashBoard.Rows.Count - 1
                    For contColD As Int32 = tamanoCamposFilas To tablaDashBoard.Columns.Count - 1
                        Dim totalR As Int32 = 0

                        For contRowD As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                            If tablaDashBoard.Rows(contRowD).Item(contColD).ToString.ToString <> "" Then
                                totalR = totalR + CInt(tablaDashBoard.Rows(contRowD).Item(contColD))
                            End If
                        Next
                        tablaDashBoard.Rows(filaFinal).Item(contColD) = totalR
                    Next
                    tablaDashBoard.Rows(filaFinal).Item(0) = "TOTAL"

                ElseIf opArticulos = True Or opColecciones = True Then

                    For Each rowDtA As DataRow In tablaDashBoard.Rows
                        For Each rowDtB As DataRow In dtTotalesArticulosFilas.Rows
                            Dim insertar As Boolean = True
                            For columnaRd As Int32 = 0 To tamanoCamposFilas - 1
                                If rowDtA.Item(columnaRd).ToString <> rowDtB.Item(columnaRd).ToString Then
                                    insertar = False
                                End If
                            Next
                            If insertar = True Then
                                rowDtA.Item("TOTAL") = rowDtB.Item(tamanoCamposFilas).ToString
                            End If
                        Next
                    Next

                    Dim filaTotal As DataRow = tablaDashBoard.NewRow
                    For colDash As Int32 = tamanoCamposColumnas - 1 To tablaDashBoard.Columns.Count - 2
                        For Each rowDt As DataRow In dtTotalesArticulosColumnas.Rows
                            Dim insertar As Boolean = True
                            For colsSelect As Int32 = 0 To tamanoCamposColumnas - 1
                                If tablaDashBoard.Rows(colsSelect).Item(colDash).ToString <> rowDt.Item(colsSelect).ToString Then
                                    insertar = False
                                End If
                            Next
                            If insertar = True Then
                                filaTotal.Item(colDash) = rowDt.Item(tamanoCamposColumnas).ToString
                                Exit For
                            End If
                        Next
                    Next
                    filaTotal.Item(0) = "TOTAL"
                    tablaDashBoard.Rows.Add(filaTotal)

                End If

                tablaDashBoard.Columns.Add("index").SetOrdinal(0)
                Dim contFila As Int32 = 1
                For i As Int32 = 0 To tablaDashBoard.Rows.Count - 1
                    If i < tamanoCamposColumnas Then
                        tablaDashBoard.Rows(i).Item("index") = "#"
                    Else
                        tablaDashBoard.Rows(i).Item("index") = contFila
                        contFila += 1
                    End If

                Next

            End If


        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            'dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            dtErrorCatch.Rows(0).Item(0) = ex.Message
            tablaDashBoard = dtErrorCatch
        End Try
        Return tablaDashBoard
    End Function

    Public Function generarConsultaDash(ByVal filas As String, ByVal columnas As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal color As String, ByVal ruta As String, ByVal radioYO As String,
                                           ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String, ByVal ubicacion As String,
                                           ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim operPersistencia As New Persistencia.OperacionesProcedimientosSICY

        ' MsgBox(filas)
        Dim tablaDashBoard As New DataTable
        Dim filaClasificacion As Boolean = False
        Dim filaCliente As Boolean = False
        Dim filaAgente As Boolean = False
        Dim filaMarca As Boolean = False
        Dim filaCategoria As Boolean = False
        Dim filaColeccion As Boolean = False
        Dim filaModelo As Boolean = False
        Dim filaDescripcion As Boolean = False
        Dim filaFamilia As Boolean = False
        Dim filaCorrida As Boolean = False
        Dim filaColor As Boolean = False
        Dim filaRuta As Boolean = False

        Dim columnaClasificacion As Boolean = False
        Dim columnaCliente As Boolean = False
        Dim columnaAgente As Boolean = False
        Dim columnaMarca As Boolean = False
        Dim columnaCategoria As Boolean = False
        Dim columnaColeccion As Boolean = False
        Dim columnaModelo As Boolean = False
        Dim columnaDescripcion As Boolean = False
        Dim columnaFamilia As Boolean = False
        Dim columnaCorrida As Boolean = False
        Dim columnaColor As Boolean = False
        Dim columnaRuta As Boolean = False
        Dim cadenaSelect As String = "SELECT"
        Dim cadenaGroupBy As String = ""
        Dim consultaGenerada = String.Empty
        Dim cadenaWhereConsulta As String = String.Empty
        Dim totalesArticulosColeccionesColumnas As String = ""
        Dim totalCadenaGroupByColumnas As String = ""
        Dim totalorderByConsultaColumnas As String = ""
        Dim dtTotalesArticulosColumnas As New DataTable
        Dim totalesArticulosColeccionesFilas As String = ""
        Dim totalCadenaGroupByFilas As String = ""
        Dim totalorderByConsultaFilas As String = ""
        Dim dtTotalesArticulosFilas As New DataTable
        Dim dtTablaGeneradaDashboard As New DataTable
        Dim cadenaInnerVistaCategoriaFamilias As String = String.Empty
        Dim opSuma As Boolean = False
        Dim opArticulos As Boolean = False
        Dim opColecciones As Boolean = False
        Dim contadorColumnasFila As Int32 = 0
        Dim contColumnasConsulta As Int32 = 0
        Dim concatAgente As String = String.Empty
        Dim dtTablaFinal As New DataTable
        Dim dtDatosRetornados As New DataTable
        Dim orderByConsulta As String = ""

        If operaciones = "optSuma" Then
            opSuma = True
        ElseIf operaciones = "optCantArt" Then
            opArticulos = True
        ElseIf operaciones = "optCantCole" Then
            opColecciones = True
        End If


        Dim cadenaConsulta As String = " FROM Ventas.vwVentas vn" +
            " INNER JOIN Ventas.vwVentasDetalles vt ON vn.IdRemision = vt.IdRemision AND vn.año = vt.año" +
            " INNER JOIN vEstilos ve ON vt.IdCodigo = ve.IdCodigo" +
            " INNER JOIN Cadenas c	ON vn.IdCadena = c.IdCadena"

        If conAgente = True Then
            If vistaAgente = "MisClientes" Then
                cadenaConsulta += " JOIN Ventas.coleccionMarcaFamiliaCadenaAgente cmfa ON vn.IdCadena = cmfa.cmfa_idCadena" &
                                " AND (cmfa.cmfa_marcaSicy + cmfa.cmfa_coleccionSicy) = ve.IdLinea AND cmfa_idAgenteSicy IN (" & agentes & ")"
            End If
        End If

        Try
            cadenaWhereConsulta = " WHERE FechaVenta >= '" + fechaUno + "' AND FechaVenta <= '" + fechaDos + "'" + "AND ISNULL(vn.Estatus, '') NOT IN ('cancelado') AND ISNULL(vn.TipoVenta, '') NOT IN ('F')"
            Dim whereConstruido As String = ""

            If conAgente = True Then
                If vistaAgente = "MisVentas" Then

                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        ' ''cadenaWhereConsulta += "AND vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        cadenaWhereConsulta += " AND vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                    End If

                ElseIf vistaAgente = "MisClientes" Then

                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        'cadenaWhereConsulta += " AND vn.IdCadena IN (SELECT IdCadena FROM CadenasMarcasAgentes cma WHERE cma.IdAgente IN (" + cadenaAgenteWhere + "))"
                    End If

                End If
            Else
                If Len(agentes) > 0 Then
                    Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                    cadenaAgenteWhere = "'0'"
                    arraycomillasAgente = Strings.Split(agentes, ",")
                    For iAgente = 0 To UBound(arraycomillasAgente)
                        cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                    Next
                    '' ''If whereConstruido.Length > 0 Then
                    '' ''    whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                    '' ''Else
                    '' ''    whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                    '' ''End If

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                    Else
                        whereConstruido += " AND (vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                    End If
                End If
            End If

            If Len(clasificacion) > 0 Then
                Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                cadenaClasificacionWhere = "'0'"
                arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                For iClas = 0 To UBound(arraycomillasClasificacion)
                    cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                Else
                    whereConstruido += " AND (c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                End If
            End If

            If Len(clientes) > 0 Then
                Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                cadenaClienteWhere = "'0'"
                arraycomillasClientes = Strings.Split(clientes, ",")
                For iCli = 0 To UBound(arraycomillasClientes)
                    cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                Else
                    whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                End If

            End If

            If Len(colecciones) > 0 Then
                Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                cadenaColeccionWhere = "'0'"
                arraycomillasColecciones = Strings.Split(colecciones, ",")
                For iCol = 0 To UBound(arraycomillasColecciones)
                    cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                Else
                    whereConstruido += " AND (REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                End If

            End If

            If Len(marcas) > 0 Then
                Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                cadenaMarcaWhere = "'0'"
                arraycomillasMarca = Strings.Split(marcas, ",")
                For iMar = 0 To UBound(arraycomillasMarca)
                    cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " ve.marca IN (" + cadenaMarcaWhere + ")"
                Else
                    whereConstruido += " AND (ve.marca IN (" + cadenaMarcaWhere + ")"
                End If
            End If

            If Len(modelos) > 0 Then
                Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                cadenaModeloWhere = "'0'"
                arraycomillasModelo = Strings.Split(modelos, ",")
                For idmod = 0 To UBound(arraycomillasModelo)
                    cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                Else
                    whereConstruido += " AND (REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                End If
            End If

            If Len(descripcion) > 0 Then
                Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                cadenaDescripcionWhere = "'0'"
                arraycomillasDescripcion = Strings.Split(descripcion, ",")
                For iDesc = 0 To UBound(arraycomillasDescripcion)
                    cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                Next


                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                Else
                    whereConstruido += " AND (ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                End If

            End If

            If Len(color) > 0 Then
                Dim arraycomillasColor() As String, cadenaColorWhere As String
                cadenaColorWhere = "'0'"
                arraycomillasColor = Strings.Split(clasificacion, ",")
                For iColor = 0 To UBound(arraycomillasColor)
                    cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " ve.Color IN (" + cadenaColorWhere + ")"
                Else
                    whereConstruido += " AND (ve.Color IN (" + cadenaColorWhere + ")"
                End If
            End If

            Dim arrayFilas() As String
            arrayFilas = Strings.Split(filas, ",")
            Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
            For contFila As Int32 = 0 To UBound(arrayFilas)
                If arrayFilas(contFila) = "optClasificacion" Then
                    filaClasificacion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.Clasificacion"
                    Else
                        cadenaSelect += ", c.Clasificacion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.Clasificacion"
                    Else
                        cadenaGroupBy += ", c.Clasificacion"
                    End If


                ElseIf arrayFilas(contFila) = "optCliente" Then
                    filaCliente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.nombre"
                    Else
                        cadenaSelect += ", c.nombre"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.nombre"
                    Else
                        cadenaGroupBy += ", c.nombre"
                    End If

                ElseIf arrayFilas(contFila) = "optAgente" Then
                    filaAgente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " a.Nombre as Agente "
                    Else
                        cadenaSelect += ", a.Nombre as Agente "
                    End If

                    cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " a.Nombre"
                    Else
                        cadenaGroupBy += ", a.Nombre"
                    End If


                ElseIf arrayFilas(contFila) = "optMarca" Then
                    filaMarca = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca"
                    Else
                        cadenaSelect += ", ve.marca"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.marca"
                    Else
                        cadenaGroupBy += ", ve.marca"
                    End If

                ElseIf arrayFilas(contFila) = "optCategoria" Then
                    filaCategoria = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " tica_descripcion as 'NAVE DESARROLLA'"
                    Else
                        cadenaSelect += ", tica_descripcion as 'NAVE DESARROLLA'"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " tica_descripcion"
                    Else
                        cadenaGroupBy += ", tica_descripcion"
                    End If

                    If Len(categoria) > 0 Then
                        Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                        cadenaCategoriaWhere = "'0'"
                        arraycomillasCategoria = Strings.Split(categoria, ",")
                        For idmod = 0 To UBound(arraycomillasCategoria)
                            cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        Else
                            whereConstruido += " AND ( tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        End If

                    End If

                ElseIf arrayFilas(contFila) = "optColeccion" Then
                    filaColeccion = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca+' '+ve.Coleccion AS Coleccion"
                    Else
                        cadenaSelect += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += "ve.marca, ve.Coleccion"
                    Else
                        cadenaGroupBy += ", ve.marca, ve.Coleccion"
                    End If

                ElseIf arrayFilas(contFila) = "optModelo" Then
                    filaModelo = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    Else
                        cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Marca, ve.IdModelo"
                    Else
                        cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                    End If

                ElseIf arrayFilas(contFila) = "optDescripcion" Then
                    filaDescripcion = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Descripcion"
                    Else
                        cadenaSelect += ", ve.Descripcion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Descripcion"
                    Else
                        cadenaGroupBy += ", ve.Descripcion"
                    End If

                ElseIf arrayFilas(contFila) = "optFamilia" Then

                    filaFamilia = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " fami_descripcion AS Familia"
                    Else
                        cadenaSelect += ", fami_descripcion AS Familia"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " fami_descripcion"
                    Else
                        cadenaGroupBy += ", fami_descripcion"
                    End If

                    If Len(familias) > 0 Then
                        Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                        cadenaFamiliaWhere = "'0'"
                        arraycomillasFamilia = Strings.Split(familias, ",")
                        For idFam = 0 To UBound(arraycomillasFamilia)
                            cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        Else
                            whereConstruido += " AND ( fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        End If

                    End If

                ElseIf arrayFilas(contFila) = "optCorrida" Then
                    filaCorrida = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " t.Talla"
                    Else
                        cadenaSelect += ", t.Talla"
                    End If
                    cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " t.Talla"
                    Else
                        cadenaGroupBy += ", t.Talla"
                    End If

                    If Len(corrida) > 0 Then
                        Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                        cadenaCorridaWhere = "'0'"
                        arraycomillasCorrida = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasCorrida)
                            cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                        Else
                            whereConstruido += " AND ( t.Talla IN (" + cadenaCorridaWhere + ")"
                        End If
                    End If

                ElseIf arrayFilas(contFila) = "optColor" Then
                    filaColor = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Color AS COLOR"
                    Else
                        cadenaSelect += ", ve.Color AS COLOR"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Color"
                    Else
                        cadenaGroupBy += ", ve.Color"
                    End If

                ElseIf arrayFilas(contFila) = "optRuta" Then
                    filaRuta = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " r.Ruta AS RUTA"
                    Else
                        cadenaSelect += ", r.Ruta AS RUTA"
                    End If
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " r.Ruta"
                    Else
                        cadenaGroupBy += ", r.Ruta"
                    End If

                    If Len(ruta) > 0 Then
                        Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                        cadenaRutaWhere = "'0'"
                        arraycomillasRuta = Strings.Split(ruta, ",")
                        For iRuta = 0 To UBound(arraycomillasRuta)
                            cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                        Else
                            whereConstruido += " AND ( r.IdRuta IN (" + cadenaRutaWhere + ")"
                        End If

                    End If

                End If
            Next contFila

            Dim arrayColumnas() As String
            arrayColumnas = Strings.Split(columnas, ",")
            Dim tamanoCamposColumnas As Int32 = (CInt(UBound(arrayColumnas))) + 1
            Dim columnasSeleccion As Int32 = UBound(arrayColumnas)
            For contColumna As Int32 = 0 To UBound(arrayColumnas)
                If arrayColumnas(contColumna) = "optClasificacion" Then
                    columnaClasificacion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.Clasificacion"
                    Else
                        cadenaSelect += ", c.Clasificacion"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.Clasificacion"
                    Else
                        cadenaGroupBy += ", c.Clasificacion"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by c.Clasificacion"
                    Else
                        orderByConsulta += ", c.Clasificacion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCliente" Then
                    columnaCliente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.nombre"
                    Else
                        cadenaSelect += ", c.nombre"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.nombre"
                    Else
                        cadenaGroupBy += ", c.nombre"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by c.nombre"
                    Else
                        orderByConsulta += ", c.nombre"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optAgente" Then
                    columnaAgente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " a.Nombre as Agente "
                    Else
                        cadenaSelect += ", a.Nombre as Agente "
                    End If
                    cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " a.Nombre"
                    Else
                        cadenaGroupBy += ", a.Nombre"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by a.Nombre"
                    Else
                        orderByConsulta += ", a.Nombre"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optMarca" Then
                    columnaMarca = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca"
                    Else
                        cadenaSelect += ", ve.marca"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.marca"
                    Else
                        cadenaGroupBy += ", ve.marca"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ve.marca"
                    Else
                        orderByConsulta += ", ve.marca"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCategoria" Then
                    columnaCategoria = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " tica_descripcion as 'NAVE DESARROLLA'"
                    Else
                        cadenaSelect += ", tica_descripcion as 'NAVE DESARROLLA'"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " tica_descripcion"
                    Else
                        cadenaGroupBy += ", tica_descripcion"
                    End If
                    If Len(categoria) > 0 Then
                        Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                        cadenaCategoriaWhere = "'0'"
                        arraycomillasCategoria = Strings.Split(categoria, ",")
                        For idmod = 0 To UBound(arraycomillasCategoria)
                            cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        Else
                            whereConstruido += " AND ( tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                        End If

                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by tica_descripcion"
                    Else
                        orderByConsulta += ", tica_descripcion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optColeccion" Then
                    columnaColeccion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.marca+' '+ve.Coleccion AS Coleccion"
                    Else
                        cadenaSelect += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += "ve.marca, ve.Coleccion"
                    Else
                        cadenaGroupBy += ", ve.marca, ve.Coleccion"
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ve.Coleccion"
                    Else
                        orderByConsulta += ", ve.Coleccion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optModelo" Then
                    columnaModelo = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    Else
                        cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Marca, ve.IdModelo"
                    Else
                        cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ModeloDesc"
                    Else
                        orderByConsulta += ", ModeloDesc"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optDescripcion" Then
                    columnaDescripcion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Descripcion"
                    Else
                        cadenaSelect += ", ve.Descripcion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Descripcion"
                    Else
                        cadenaGroupBy += ", ve.Descripcion"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ve.Descripcion"
                    Else
                        orderByConsulta += ", ve.Descripcion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optFamilia" Then
                    columnaFamilia = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " fami_descripcion AS Familia"
                    Else
                        cadenaSelect += ", fami_descripcion AS Familia"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " fami_descripcion"
                    Else
                        cadenaGroupBy += ", fami_descripcion"
                    End If

                    If Len(familias) > 0 Then
                        Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                        cadenaFamiliaWhere = "'0'"
                        arraycomillasFamilia = Strings.Split(familias, ",")
                        For idFam = 0 To UBound(arraycomillasFamilia)
                            cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        Else
                            whereConstruido += " AND ( fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by fami_descripcion"
                    Else
                        orderByConsulta += ", fami_descripcion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCorrida" Then
                    columnaCorrida = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " t.Talla"
                    Else
                        cadenaSelect += ", t.Talla"
                    End If
                    cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " t.Talla"
                    Else
                        cadenaGroupBy += ", t.Talla"
                    End If

                    If Len(corrida) > 0 Then
                        Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                        cadenaCorridaWhere = "'0'"
                        arraycomillasCorrida = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasCorrida)
                            cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                        Else
                            whereConstruido += " AND ( t.Talla IN (" + cadenaCorridaWhere + ")"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by t.Talla"
                    Else
                        orderByConsulta += ", t.Talla"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optColor" Then
                    columnaColor = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ve.Color AS COLOR"
                    Else
                        cadenaSelect += ", ve.Color AS COLOR"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ve.Color"
                    Else
                        cadenaGroupBy += ", ve.Color"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by COLOR"
                    Else
                        orderByConsulta += ", COLOR"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optRuta" Then
                    columnaRuta = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " r.Ruta AS RUTA"
                    Else
                        cadenaSelect += ", r.Ruta AS RUTA"
                    End If
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " r.Ruta"
                    Else
                        cadenaGroupBy += ", r.Ruta"
                    End If

                    If Len(ruta) > 0 Then
                        Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                        cadenaRutaWhere = "'0'"
                        arraycomillasRuta = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasRuta)
                            cadenaRutaWhere += ", '" + arraycomillasRuta(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + "))"
                        Else
                            whereConstruido += " AND ( r.IdRuta IN (" + cadenaRutaWhere + "))"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by RUTA"
                    Else
                        orderByConsulta += ", RUTA"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                End If
            Next contColumna

            If opArticulos = True Or opColecciones = True Then

                For contColumnaTot As Int32 = 0 To UBound(arrayColumnas)
                    If arrayColumnas(contColumnaTot) = "optClasificacion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByColumnas += ", c.Clasificacion"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByColumnas += ", c.Clasificacion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by c.Clasificacion"
                        Else
                            totalCadenaGroupByColumnas += ", c.Clasificacion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCliente" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " c.nombre"
                        Else
                            totalesArticulosColeccionesColumnas += ", c.nombre"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " c.nombre"
                        Else
                            totalCadenaGroupByColumnas += ", c.nombre"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by c.nombre"
                        Else
                            totalorderByConsultaColumnas += ", c.nombre"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optAgente" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " a.Nombre as Agente "
                        Else
                            totalesArticulosColeccionesColumnas += ", a.Nombre as Agente "
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " a.Nombre"
                        Else
                            totalCadenaGroupByColumnas += ", a.Nombre"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by a.Nombre"
                        Else
                            totalorderByConsultaColumnas += ", a.Nombre"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optMarca" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.marca"
                        Else
                            totalesArticulosColeccionesColumnas += ", ve.marca"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.marca"
                        Else
                            totalCadenaGroupByColumnas += ", ve.marca"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ve.marca"
                        Else
                            totalorderByConsultaColumnas += ", ve.marca"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCategoria" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " tica_descripcion as 'NAVE DESARROLLA'"
                        Else
                            totalesArticulosColeccionesColumnas += ", tica_descripcion as 'NAVE DESARROLLA'"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " tica_descripcion"
                        Else
                            totalCadenaGroupByColumnas += ", tica_descripcion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by tica_descripcion"
                        Else
                            totalorderByConsultaColumnas += ", tica_descripcion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optColeccion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.marca+' '+ve.Coleccion AS Coleccion"
                        Else
                            totalesArticulosColeccionesColumnas += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += "ve.marca, ve.Coleccion"
                        Else
                            totalCadenaGroupByColumnas += ", ve.marca, ve.Coleccion"
                        End If

                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ve.Coleccion"
                        Else
                            totalorderByConsultaColumnas += ", ve.Coleccion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optModelo" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        Else
                            totalesArticulosColeccionesColumnas += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.Marca, ve.IdModelo"
                        Else
                            totalCadenaGroupByColumnas += ", ve.Marca, ve.IdModelo"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ModeloDesc"
                        Else
                            totalorderByConsultaColumnas += ", ModeloDesc"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optDescripcion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.Descripcion"
                        Else
                            totalesArticulosColeccionesColumnas += ", ve.Descripcion"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.Descripcion"
                        Else
                            totalCadenaGroupByColumnas += ", ve.Descripcion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ve.Descripcion"
                        Else
                            totalorderByConsultaColumnas += ", ve.Descripcion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optFamilia" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " fami_descripcion AS Familia"
                        Else
                            totalesArticulosColeccionesColumnas += ", fami_descripcion AS Familia"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " fami_descripcion"
                        Else
                            totalCadenaGroupByColumnas += ", fami_descripcion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by fami_descripcion"
                        Else
                            totalorderByConsultaColumnas += ", fami_descripcion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCorrida" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " t.Talla"
                        Else
                            totalesArticulosColeccionesColumnas += ", t.Talla"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " t.Talla"
                        Else
                            totalCadenaGroupByColumnas += ", t.Talla"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by t.Talla"
                        Else
                            totalorderByConsultaColumnas += ", t.Talla"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optColor" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ve.Color AS COLOR"
                        Else
                            totalesArticulosColeccionesColumnas += ", ve.Color AS COLOR"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ve.Color"
                        Else
                            totalCadenaGroupByColumnas += ", ve.Color"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by COLOR"
                        Else
                            totalorderByConsultaColumnas += ", COLOR"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optRuta" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " r.Ruta AS RUTA"
                        Else
                            totalesArticulosColeccionesColumnas += ", r.Ruta AS RUTA"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " r.Ruta"
                        Else
                            totalCadenaGroupByColumnas += ", r.Ruta"
                        End If

                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by RUTA"
                        Else
                            totalorderByConsultaColumnas += ", RUTA"
                        End If

                    End If
                Next

                For contFilaTot As Int32 = 0 To UBound(arrayFilas)
                    If arrayFilas(contFilaTot) = "optClasificacion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByFilas += ", c.Clasificacion"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " c.Clasificacion"
                        Else
                            totalCadenaGroupByFilas += ", c.Clasificacion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by c.Clasificacion"
                        Else
                            totalCadenaGroupByFilas += ", c.Clasificacion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCliente" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " c.nombre"
                        Else
                            totalesArticulosColeccionesFilas += ", c.nombre"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " c.nombre"
                        Else
                            totalCadenaGroupByFilas += ", c.nombre"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by c.nombre"
                        Else
                            totalorderByConsultaFilas += ", c.nombre"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optAgente" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " a.Nombre as Agente "
                        Else
                            totalesArticulosColeccionesFilas += ", a.Nombre as Agente "
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " a.Nombre"
                        Else
                            totalCadenaGroupByFilas += ", a.Nombre"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by a.Nombre"
                        Else
                            totalorderByConsultaFilas += ", a.Nombre"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optMarca" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.marca"
                        Else
                            totalesArticulosColeccionesFilas += ", ve.marca"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.marca"
                        Else
                            totalCadenaGroupByFilas += ", ve.marca"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ve.marca"
                        Else
                            totalorderByConsultaFilas += ", ve.marca"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCategoria" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " tica_descripcion as 'NAVE DESARROLLA'"
                        Else
                            totalesArticulosColeccionesFilas += ", tica_descripcion as 'NAVE DESARROLLA'"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " tica_descripcion"
                        Else
                            totalCadenaGroupByFilas += ", tica_descripcion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by tica_descripcion"
                        Else
                            totalorderByConsultaFilas += ", tica_descripcion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optColeccion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.marca+' '+ve.Coleccion AS Coleccion"
                        Else
                            totalesArticulosColeccionesFilas += ",ve.marca+' '+ve.Coleccion AS Coleccion"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += "ve.marca, ve.Coleccion"
                        Else
                            totalCadenaGroupByFilas += ", ve.marca, ve.Coleccion"
                        End If

                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ve.Coleccion"
                        Else
                            totalorderByConsultaFilas += ", ve.Coleccion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optModelo" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        Else
                            totalesArticulosColeccionesFilas += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS ModeloDesc"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.Marca, ve.IdModelo"
                        Else
                            totalCadenaGroupByFilas += ", ve.Marca, ve.IdModelo"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ModeloDesc"
                        Else
                            totalorderByConsultaFilas += ", ModeloDesc"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optDescripcion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.Descripcion"
                        Else
                            totalesArticulosColeccionesFilas += ", ve.Descripcion"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.Descripcion"
                        Else
                            totalCadenaGroupByFilas += ", ve.Descripcion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ve.Descripcion"
                        Else
                            totalorderByConsultaFilas += ", ve.Descripcion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optFamilia" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " fami_descripcion AS Familia"
                        Else
                            totalesArticulosColeccionesFilas += ", fami_descripcion AS Familia"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " fami_descripcion"
                        Else
                            totalCadenaGroupByFilas += ", fami_descripcion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by fami_descripcion"
                        Else
                            totalorderByConsultaFilas += ", fami_descripcion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCorrida" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " t.Talla"
                        Else
                            totalesArticulosColeccionesFilas += ", t.Talla"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " t.Talla"
                        Else
                            totalCadenaGroupByFilas += ", t.Talla"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by t.Talla"
                        Else
                            totalorderByConsultaFilas += ", t.Talla"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optColor" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ve.Color AS COLOR"
                        Else
                            totalesArticulosColeccionesFilas += ", ve.Color AS COLOR"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ve.Color"
                        Else
                            totalCadenaGroupByFilas += ", ve.Color"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by COLOR"
                        Else
                            totalorderByConsultaFilas += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optRuta" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " r.Ruta AS RUTA"
                        Else
                            totalesArticulosColeccionesFilas += ", r.Ruta AS RUTA"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " r.Ruta"
                        Else
                            totalCadenaGroupByFilas += ", r.Ruta"
                        End If

                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by RUTA"
                        Else
                            totalorderByConsultaFilas += ", RUTA"
                        End If

                    End If
                Next

            End If
            If Len(categoria) > 0 And filaCategoria = False And columnaCategoria = False Then
                If cadenaInnerVistaCategoriaFamilias = "" Then
                    cadenaInnerVistaCategoriaFamilias = "Contenido"
                    cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                End If
                Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                cadenaCategoriaWhere = "'0'"
                arraycomillasCategoria = Strings.Split(categoria, ",")
                For idmod = 0 To UBound(arraycomillasCategoria)
                    cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                Else
                    whereConstruido += " AND ( tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                End If
            End If

            If Len(familias) > 0 And filaFamilia = False And columnaFamilia = False Then
                If cadenaInnerVistaCategoriaFamilias = "" Then
                    cadenaInnerVistaCategoriaFamilias = "Contenido"
                    cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                End If

                Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                cadenaFamiliaWhere = "'0'"
                arraycomillasFamilia = Strings.Split(familias, ",")
                For idFam = 0 To UBound(arraycomillasFamilia)
                    cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                Else
                    whereConstruido += " AND ( fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                End If
            End If


            If Len(corrida) > 0 And filaCorrida = False And columnaCorrida = False Then
                cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"

                Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                cadenaCorridaWhere = "'0'"
                arraycomillasCorrida = Strings.Split(corrida, ",")
                For iCor = 0 To UBound(arraycomillasCorrida)
                    cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                Else
                    whereConstruido += " AND ( t.Talla IN (" + cadenaCorridaWhere + ")"
                End If
            End If

            If Len(ruta) > 0 And filaRuta = False And columnaRuta = False Then
                cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                cadenaRutaWhere = "'0'"
                arraycomillasRuta = Strings.Split(ruta, ",")
                For iRuta = 0 To UBound(arraycomillasRuta)
                    cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                Else
                    whereConstruido += " AND ( r.IdRuta IN (" + cadenaRutaWhere + ")"
                End If
            End If

            '---------------------------------------------------------------
            '---------------------------------------------------------------
            '---------------------------------------------------------------

            'MsgBox(cadenaConsulta)

            If whereConstruido.Length > 0 Then
                cadenaWhereConsulta += whereConstruido + ")"
            End If

            If opSuma = True Then
                cadenaSelect += ", SUM(vt.Cantidad) AS PARES"
            End If
            If opColecciones = True Then
                cadenaSelect += ", COUNT(DISTINCT ve.Marca + ve.Coleccion) AS COLECCIONES"
            End If
            If opArticulos = True Then
                cadenaSelect += ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS"
                ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
            End If


            Dim cadenaFinal As String = ""
            Dim cadFinTotArtsColsColumnas As String = ""
            Dim cadFinTotArtsColsFilas As String = ""
            cadenaFinal = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta

            If opColecciones = True Or opArticulos = True Then
                If opColecciones = True Then
                    cadFinTotArtsColsColumnas = "SELECT " + totalesArticulosColeccionesColumnas + ", COUNT(DISTINCT ve.Marca + ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByColumnas + " " + totalorderByConsultaColumnas
                    cadFinTotArtsColsFilas = "SELECT " + totalesArticulosColeccionesFilas + ", COUNT(DISTINCT ve.Marca + ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByFilas + " " + totalorderByConsultaFilas
                End If
                If opArticulos = True Then
                    cadFinTotArtsColsColumnas = "SELECT " + totalesArticulosColeccionesColumnas + ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByColumnas + " " + totalorderByConsultaColumnas
                    cadFinTotArtsColsFilas = "SELECT " + totalesArticulosColeccionesFilas + ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByFilas + " " + totalorderByConsultaFilas
                End If

            End If


            Dim dtTablaContruida As New DataTable
            ' ''Dim cadenaSort As String = String.Empty

            For contFilaDT = 0 To UBound(arrayFilas)
                If arrayFilas(contFilaDT) = "optClasificacion" Then
                    dtTablaContruida.Columns.Add("CLASIFICACION")
                    dtTablaContruida.Columns("CLASIFICACION").Caption = "CLASIFICACIÓN"
                    'cadenaSort += "CLASIFICACION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCliente" Then
                    dtTablaContruida.Columns.Add("CLIENTE")
                    'cadenaSort += "CLIENTE ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optAgente" Then
                    dtTablaContruida.Columns.Add("AGENTE")
                    'cadenaSort += "AGENTE ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optMarca" Then
                    dtTablaContruida.Columns.Add("MARCA")
                    'cadenaSort += "MARCA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCategoria" Then
                    dtTablaContruida.Columns.Add("NAVE DESARROLLA")
                    dtTablaContruida.Columns("NAVE DESARROLLA").Caption = "NAVE DESARROLLA"
                    'cadenaSort += "CATEGORIA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optColeccion" Then
                    dtTablaContruida.Columns.Add("COLECCION")
                    dtTablaContruida.Columns("COLECCION").Caption = "COLECCIÓN"
                    'cadenaSort += "COLECCION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optModelo" Then
                    dtTablaContruida.Columns.Add("MODELO")
                    'cadenaSort += "MODELO ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optDescripcion" Then
                    dtTablaContruida.Columns.Add("DESCRIPCION")
                    dtTablaContruida.Columns("DESCRIPCION").Caption = "DESCRIPCIÓN"
                    'cadenaSort += "DESCRIPCION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optFamilia" Then
                    dtTablaContruida.Columns.Add("FAMILIA")
                    'cadenaSort += "FAMILIA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCorrida" Then
                    dtTablaContruida.Columns.Add("CORRIDA")
                    'cadenaSort += "CORRIDA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optColor" Then
                    dtTablaContruida.Columns.Add("COLOR")
                    'cadenaSort += "COLOR ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optRuta" Then
                    dtTablaContruida.Columns.Add("RUTA")
                    'cadenaSort += "RUTA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1
                End If
            Next contFilaDT

            'MsgBox(cadenaFinal)

            Dim dtDatosConsulta As New DataTable
            Dim contadorValidador As Int32 = 0
            dtDatosConsulta = operPersistencia.EjecutaConsulta(cadenaFinal)

            contadorValidador = dtDatosConsulta.Rows.Count
            If contadorValidador > 0 Then
                If opArticulos = True Or opColecciones = True Then
                    dtTotalesArticulosColumnas = operPersistencia.EjecutaConsulta(cadFinTotArtsColsColumnas)
                    dtTotalesArticulosFilas = operPersistencia.EjecutaConsulta(cadFinTotArtsColsFilas)
                End If

                Dim contNameColumna As Int32 = 0
                For Each rowdt As DataRow In dtDatosConsulta.Rows
                    dtTablaContruida.Columns.Add("columna" + contNameColumna.ToString)
                    contNameColumna = contNameColumna + 1
                Next

                For contFilaConcatena = 0 To UBound(arrayColumnas)
                    If arrayColumnas(contFilaConcatena) = "optClasificacion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Clasificacion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCliente" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("nombre").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optAgente" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Agente").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optMarca" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Marca").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCategoria" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("NAVE DESARROLLA").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optColeccion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Coleccion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optModelo" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("ModeloDesc").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optDescripcion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Descripcion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optFamilia" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Familia").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCorrida" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Talla").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optColor" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Color").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optRuta" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Ruta").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)
                    End If
                Next

                For Each rowDTDT As DataRow In dtDatosConsulta.Rows
                    Dim filaNueva As DataRow = dtTablaContruida.NewRow

                    If filaClasificacion = True Then
                        filaNueva("CLASIFICACION") = rowDTDT.Item("Clasificacion").ToString

                    End If
                    If filaAgente = True Then
                        filaNueva("AGENTE") = rowDTDT.Item("Agente").ToString

                    End If
                    If filaCliente = True Then
                        filaNueva("CLIENTE") = rowDTDT.Item("nombre").ToString

                    End If
                    If filaMarca = True Then
                        filaNueva("MARCA") = rowDTDT.Item("Marca").ToString

                    End If
                    If filaColeccion = True Then
                        filaNueva("COLECCION") = rowDTDT.Item("Coleccion").ToString

                    End If
                    If filaCategoria = True Then
                        filaNueva("NAVE DESARROLLA") = rowDTDT.Item("NAVE DESARROLLA").ToString

                    End If
                    If filaModelo = True Then
                        filaNueva("MODELO") = rowDTDT.Item("ModeloDesc").ToString

                    End If
                    If filaDescripcion = True Then
                        filaNueva("DESCRIPCION") = rowDTDT.Item("Descripcion").ToString

                    End If
                    If filaFamilia = True Then
                        filaNueva("FAMILIA") = rowDTDT.Item("Familia").ToString

                    End If
                    If filaCorrida = True Then
                        filaNueva("CORRIDA") = rowDTDT.Item("Talla").ToString

                    End If
                    If filaColor = True Then
                        filaNueva("COLOR") = rowDTDT.Item("COLOR").ToString
                    End If

                    If filaRuta = True Then
                        filaNueva("RUTA") = rowDTDT.Item("RUTA").ToString
                    End If

                    Dim importarFila As Boolean = True

                    For Each roWdCT As DataRow In dtTablaContruida.Rows
                        Dim comparer As IEqualityComparer(Of DataRow) = DataRowComparer.Default
                        Dim bEqual = comparer.Equals(roWdCT, filaNueva)

                        If (bEqual = True) Then
                            importarFila = False
                        End If
                    Next

                    If importarFila = True Then
                        dtTablaContruida.Rows.Add(filaNueva)
                    End If
                Next

                For consCOl As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1
                    Dim esigual As Boolean = True
                    For Each rowdtCons As DataRow In dtTablaContruida.Rows
                        If rowdtCons.Item(consCOl).ToString <> rowdtCons.Item(consCOl - 1).ToString Then
                            esigual = False
                        End If
                    Next
                    If esigual = True Then
                        dtTablaContruida.Columns.RemoveAt(consCOl)
                    End If
                Next

                ' ''If filaRuta = True Then
                ' ''    For tamFils As Int32 = 0 To tamanoCamposFilas - 1
                ' ''        For consCol As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1
                ' ''            Dim contadorIgual As Int32 = 0
                ' ''            For consColDos As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1

                ' ''                If dtTablaContruida.Rows(tamFils).Item(consCol).ToString = dtTablaContruida.Rows(tamFils).Item(consColDos).ToString Then
                ' ''                    contadorIgual = contadorIgual + 1
                ' ''                End If
                ' ''            Next
                ' ''            If contadorIgual > 1 Then
                ' ''                dtTablaContruida.Columns.RemoveAt(consCol)
                ' ''            End If
                ' ''        Next
                ' ''    Next
                ' ''End If

                Dim contador As Int32 = 0
                For Each rowCNTRA As DataRow In dtTablaContruida.Rows
                    Dim columnaIncrusta As Int32 = 0

                    For Each rowCONS As DataRow In dtDatosConsulta.Rows
                        Dim esIgual As Boolean = True
                        If filaClasificacion = True Then
                            If rowCNTRA.Item("CLASIFICACION").ToString <> rowCONS.Item("Clasificacion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCliente = True Then
                            If rowCNTRA.Item("CLIENTE").ToString <> rowCONS.Item("nombre").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaAgente = True Then
                            If rowCNTRA.Item("AGENTE").ToString <> rowCONS.Item("Agente").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaMarca = True Then
                            If rowCNTRA.Item("MARCA").ToString <> rowCONS.Item("Marca").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCategoria = True Then
                            If rowCNTRA.Item("NAVE DESARROLLA").ToString <> rowCONS.Item("NAVE DESARROLLA").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaColeccion = True Then
                            If rowCNTRA.Item("COLECCION").ToString <> rowCONS.Item("Coleccion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaModelo = True Then
                            If rowCNTRA.Item("MODELO").ToString <> rowCONS.Item("ModeloDesc").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaDescripcion = True Then
                            If rowCNTRA.Item("DESCRIPCION").ToString <> rowCONS.Item("Descripcion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaFamilia = True Then
                            If rowCNTRA.Item("FAMILIA").ToString <> rowCONS.Item("Familia").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCorrida = True Then
                            If rowCNTRA.Item("CORRIDA").ToString <> rowCONS.Item("Talla").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaColor = True Then
                            If rowCNTRA.Item("COLOR").ToString <> rowCONS.Item("COLOR").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaRuta = True Then
                            If rowCNTRA.Item("RUTA").ToString <> rowCONS.Item("RUTA").ToString Then
                                esIgual = False
                            End If
                        End If

                        If esIgual = True Then
                            Dim incrustar As Boolean = True
                            contador = contador + 1
                            For Each columnCTR As DataColumn In dtTablaContruida.Columns
                                Dim dtCon As Int32 = 0
                                Dim inserta As Boolean = True
                                For dtfil As Int32 = tamanoCamposFilas To dtDatosConsulta.Columns.Count - 2
                                    Dim DAM As String = dtTablaContruida.Rows(dtCon).Item(columnCTR.ColumnName.ToString).ToString
                                    If rowCONS.Item(dtfil).ToString <> dtTablaContruida.Rows(dtCon).Item(columnCTR.ColumnName.ToString).ToString Then
                                        inserta = False
                                    End If
                                    dtCon = dtCon + 1
                                Next
                                If inserta = True Then
                                    If opSuma = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("PARES").ToString
                                    ElseIf opColecciones = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("COLECCIONES").ToString
                                    ElseIf opArticulos = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("ARTICULOS").ToString
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next

                ' '' ''Dim viewDtDatos As New DataView(dtTablaContruida)
                ' '' ''viewDtDatos.Sort = cadenaSort.Substring(0, cadenaSort.Length - 1)
                ' '' ''tablaDashBoard = viewDtDatos.ToTable

                tablaDashBoard = dtTablaContruida

                For contDTB As Int32 = 0 To tamanoCamposFilas - 1
                    tablaDashBoard.Rows(0).Item(contDTB) = dtTablaContruida.Columns(contDTB).Caption
                Next

                tablaDashBoard.Columns.Add("TOTAL")
                tablaDashBoard.Rows(0).Item("TOTAL") = "TOTAL"

                ' '' ''If opSuma = True Then
                tablaDashBoard.Rows.Add()
                Dim columnaTotal As Int32 = tablaDashBoard.Columns.Count - 1
                For contRowD As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                    Dim total As Int32 = 0
                    For contColD As Int32 = tamanoCamposFilas To tablaDashBoard.Columns.Count - 2
                        If tablaDashBoard.Rows(contRowD).Item(contColD).ToString.ToString <> "" Then
                            total = total + CInt(tablaDashBoard.Rows(contRowD).Item(contColD))
                        End If
                    Next
                    tablaDashBoard.Rows(contRowD).Item("TOTAL") = total
                Next

                Dim filaFinal As Int32 = tablaDashBoard.Rows.Count - 1
                For contColD As Int32 = tamanoCamposFilas To tablaDashBoard.Columns.Count - 1
                    Dim totalR As Int32 = 0

                    For contRowD As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                        If tablaDashBoard.Rows(contRowD).Item(contColD).ToString.ToString <> "" Then
                            totalR = totalR + CInt(tablaDashBoard.Rows(contRowD).Item(contColD))
                        End If
                    Next
                    tablaDashBoard.Rows(filaFinal).Item(contColD) = totalR
                Next
                tablaDashBoard.Rows(filaFinal).Item(0) = "TOTAL"

                ' '' ''ElseIf opArticulos = True Or opColecciones = True Then

                ' '' ''    For Each rowDtA As DataRow In tablaDashBoard.Rows
                ' '' ''        For Each rowDtB As DataRow In dtTotalesArticulosFilas.Rows
                ' '' ''            Dim insertar As Boolean = True
                ' '' ''            For columnaRd As Int32 = 0 To tamanoCamposFilas - 1
                ' '' ''                If rowDtA.Item(columnaRd).ToString <> rowDtB.Item(columnaRd).ToString Then
                ' '' ''                    insertar = False
                ' '' ''                End If
                ' '' ''            Next
                ' '' ''            If insertar = True Then
                ' '' ''                rowDtA.Item("TOTAL") = rowDtB.Item(tamanoCamposFilas).ToString
                ' '' ''            End If
                ' '' ''        Next
                ' '' ''    Next

                ' '' ''    Dim filaTotal As DataRow = tablaDashBoard.NewRow
                ' '' ''    For colDash As Int32 = tamanoCamposColumnas - 1 To tablaDashBoard.Columns.Count - 2
                ' '' ''        For Each rowDt As DataRow In dtTotalesArticulosColumnas.Rows
                ' '' ''            Dim insertar As Boolean = True
                ' '' ''            For colsSelect As Int32 = 0 To tamanoCamposColumnas - 1
                ' '' ''                If tablaDashBoard.Rows(colsSelect).Item(colDash).ToString <> rowDt.Item(colsSelect).ToString Then
                ' '' ''                    insertar = False
                ' '' ''                End If
                ' '' ''            Next
                ' '' ''            If insertar = True Then
                ' '' ''                filaTotal.Item(colDash) = rowDt.Item(tamanoCamposColumnas).ToString
                ' '' ''                Exit For
                ' '' ''            End If
                ' '' ''        Next
                ' '' ''    Next
                ' '' ''    filaTotal.Item(0) = "TOTAL"
                ' '' ''    tablaDashBoard.Rows.Add(filaTotal)

                ' '' ''End If


                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------

                Dim dtTablaOrdenada As New DataTable
                For contCol As Int32 = 0 To tablaDashBoard.Columns.Count - 1
                    If contCol = tablaDashBoard.Columns.Count - 1 Then
                        dtTablaOrdenada.Columns.Add(tablaDashBoard.Columns(contCol).ColumnName, Type.GetType("System.Int32"))
                    Else
                        dtTablaOrdenada.Columns.Add(tablaDashBoard.Columns(contCol).ColumnName)
                    End If
                Next

                For cont As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                    dtTablaOrdenada.ImportRow(tablaDashBoard.Rows(cont))
                Next

                Dim viewDtDatos As New DataView(dtTablaOrdenada)
                viewDtDatos.Sort = tablaDashBoard.Columns(tablaDashBoard.Columns.Count - 1).ColumnName.ToString + " DESC"
                dtTablaOrdenada = New DataTable
                dtTablaOrdenada = viewDtDatos.ToTable

                Dim dtTraspaso As New DataTable
                For contCol As Int32 = 0 To tablaDashBoard.Columns.Count - 1
                    dtTraspaso.Columns.Add(tablaDashBoard.Columns(contCol).ColumnName)
                Next

                For iCont As Int32 = 0 To tamanoCamposColumnas - 1
                    dtTraspaso.ImportRow(tablaDashBoard.Rows(iCont))
                Next
                For Each rowDt As DataRow In dtTablaOrdenada.Rows
                    dtTraspaso.ImportRow(rowDt)
                Next
                dtTraspaso.ImportRow(tablaDashBoard.Rows(tablaDashBoard.Rows.Count - 1))


                tablaDashBoard = New DataTable
                tablaDashBoard = dtTraspaso
                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------

                tablaDashBoard.Columns.Add("index").SetOrdinal(0)


                Dim contFila As Int32 = 1
                For i As Int32 = 0 To tablaDashBoard.Rows.Count - 2
                    If i < tamanoCamposColumnas Then
                        tablaDashBoard.Rows(i).Item("index") = "#"
                    Else
                        tablaDashBoard.Rows(i).Item("index") = contFila
                        contFila += 1
                    End If

                Next

                Dim ultimaCol As Int32 = tablaDashBoard.Columns.Count - 1
                Dim ultimaFila As Int32 = tablaDashBoard.Rows.Count - 1
                Dim TotalVentas As Double = tablaDashBoard.Rows(ultimaFila).Item(ultimaCol)
                Dim porcentajeFila As Decimal = 0.0
                tablaDashBoard.Columns.Add("Porcentaje")
                tablaDashBoard.Columns("Porcentaje").Caption = "%"

                Dim contPorcent As Int32 = 1
                For x As Int32 = 0 To tamanoCamposColumnas - 1
                    tablaDashBoard.Rows(x).Item("Porcentaje") = "%"
                Next

                For rowTotal As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 1
                    porcentajeFila = (tablaDashBoard.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                    tablaDashBoard.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                Next
                Dim porcentajeColumna As Decimal = 0.0
                Dim rowPorcent As DataRow
                rowPorcent = tablaDashBoard.NewRow
                For Each colDtp As DataColumn In tablaDashBoard.Columns
                    If IsNumeric(tablaDashBoard.Rows(ultimaFila).Item(colDtp.ColumnName.ToString)) And colDtp.ColumnName.ToString <> "index" Then
                        porcentajeColumna = (tablaDashBoard.Rows(ultimaFila).Item(colDtp) * 100) / TotalVentas
                        rowPorcent.Item(colDtp) = porcentajeColumna.ToString("N2") + "%"
                    Else
                        rowPorcent.Item(colDtp) = ""
                    End If
                Next
                rowPorcent.Item(1) = "%"
                tablaDashBoard.Rows.Add(rowPorcent)
            End If


        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            'dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            tablaDashBoard = dtErrorCatch
        End Try
        Return tablaDashBoard
    End Function

    Public Function generarConsultaFechas(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                           ByVal radioYO As String, ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String,
                                           ByVal ubicacion As String) As DataTable
        Dim dtDatosConsultaReporte As New DataTable
        Try
            If filas <> "" Then
                Dim operConsultas As New Persistencia.OperacionesProcedimientosSICY
                Dim dtCantidadAnios As DataTable = operConsultas.EjecutaConsulta("SELECT DATEDIFF(YEAR, '" + fechaUno + "', '" + fechaDos + "');")
                Dim diferenciaAnios As Int32 = CInt(dtCantidadAnios.Rows(0).Item(0).ToString)
                Dim filaClasificacion As Boolean = False
                Dim filaCliente As Boolean = False
                Dim filaAgente As Boolean = False
                Dim filaMarca As Boolean = False
                Dim filaCategoria As Boolean = False
                Dim filaColeccion As Boolean = False
                Dim filaModelo As Boolean = False
                Dim filaDescripcion As Boolean = False
                Dim filaFamilia As Boolean = False
                Dim filaCorrida As Boolean = False
                Dim filaRuta As Boolean = False
                Dim filaColor As Boolean = False
                Dim opSuma As Boolean = False
                Dim opArticulos As Boolean = False
                Dim opColecciones As Boolean = False
                Dim anioInicio As Int32 = Year(fechaUno)
                Dim cadenaSelect As String = "SELECT"
                Dim cadenaSelectOperacion As String = ""
                Dim cadenaGroupBy As String = ""
                Dim cadenaWhereConsulta As String = ""
                Dim cadenaInnerVistaCategoriaFamilias As String = ""
                Dim orderByConsulta As String = ""
                Dim cadenaFinal As String = ""
                Dim cadenaFinalColeccionArticulo As String = ""
                Dim cadenaOperacion As String = ""
                Dim cadenaColor As String = ""
                Dim dtSubtotalesFechas As New DataTable
                Dim totalCadenaArticulosColecciones As String = ""
                Dim dtTotalCadenaArticulosColecciones As New DataTable

                Dim totalCadArtColTOTAL As String = ""
                Dim dtTotalCadArtColTOTAL As New DataTable

                If operaciones = "optSuma" Then
                    opSuma = True
                    cadenaOperacion = "PARES"
                ElseIf operaciones = "optCantArt" Then
                    opArticulos = True
                    cadenaOperacion = "ARTICULOS"
                ElseIf operaciones = "optCantCole" Then
                    opColecciones = True
                    cadenaOperacion = "COLECCIONES"
                End If

                Dim cadenaConsulta As String = " FROM Ventas.vwVentas vn" +
                    " INNER JOIN Ventas.vwVentasDetalles vt ON vn.IdRemision = vt.IdRemision AND vn.año = vt.año" +
                    " INNER JOIN vEstilos ve ON vt.IdCodigo = ve.IdCodigo" +
                    " INNER JOIN Cadenas c	ON vn.IdCadena = c.IdCadena"

                cadenaWhereConsulta = " WHERE FechaVenta >= '" + fechaUno + "' AND FechaVenta <= '" + fechaDos + "'" + "AND ISNULL(vn.Estatus, '') NOT IN ('cancelado') AND ISNULL(vn.TipoVenta, '') NOT IN ('F')"
                Dim whereConstruido As String = ""

                If Len(agentes) > 0 Then
                    Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                    cadenaAgenteWhere = "'0'"
                    arraycomillasAgente = Strings.Split(agentes, ",")
                    For iAgente = 0 To UBound(arraycomillasAgente)
                        cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                    Next
                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                    Else
                        whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                    End If
                End If

                If Len(clasificacion) > 0 Then
                    Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                    cadenaClasificacionWhere = "'0'"
                    arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                    For iClas = 0 To UBound(arraycomillasClasificacion)
                        cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                    Else
                        whereConstruido += " AND (c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                    End If
                End If

                If Len(clientes) > 0 Then
                    Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                    'cadenaClienteWhere = "'0'"
                    cadenaClienteWhere = String.Empty
                    arraycomillasClientes = Strings.Split(clientes, ",")
                    For iCli = 0 To UBound(arraycomillasClientes)
                        If cadenaClienteWhere = String.Empty Then
                            cadenaClienteWhere += " '" + arraycomillasClientes(iCli) + "'"
                        Else
                            cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                        End If
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                    Else
                        whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                    End If

                End If

                If Len(colecciones) > 0 Then
                    Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                    cadenaColeccionWhere = "'0'"
                    arraycomillasColecciones = Strings.Split(colecciones, ",")
                    For iCol = 0 To UBound(arraycomillasColecciones)
                        cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                    End If

                End If

                If Len(marcas) > 0 Then
                    Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                    cadenaMarcaWhere = "'0'"
                    arraycomillasMarca = Strings.Split(marcas, ",")
                    For iMar = 0 To UBound(arraycomillasMarca)
                        cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.marca IN (" + cadenaMarcaWhere + ")"
                    Else
                        whereConstruido += " AND (ve.marca IN (" + cadenaMarcaWhere + ")"
                    End If
                End If

                If Len(modelos) > 0 Then
                    Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                    cadenaModeloWhere = "'0'"
                    arraycomillasModelo = Strings.Split(modelos, ",")
                    For idmod = 0 To UBound(arraycomillasModelo)
                        cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                    End If
                End If

                If Len(descripcion) > 0 Then
                    Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                    cadenaDescripcionWhere = "'0'"
                    arraycomillasDescripcion = Strings.Split(descripcion, ",")
                    For iDesc = 0 To UBound(arraycomillasDescripcion)
                        cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                    Else
                        whereConstruido += " AND ( ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                    End If
                End If

                If Len(Color) > 0 Then
                    Dim arraycomillasColor() As String, cadenaColorWhere As String
                    cadenaColorWhere = "'0'"
                    arraycomillasColor = Strings.Split(Color, ",")
                    For iColor = 0 To UBound(arraycomillasColor)
                        cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.Color IN (" + cadenaColorWhere + ")"
                    Else
                        whereConstruido += " AND (ve.Color IN (" + cadenaColorWhere + ")"
                    End If
                End If

                Dim arrayFilas() As String
                arrayFilas = Strings.Split(filas, ",")

                Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
                For contFila = 0 To UBound(arrayFilas)
                    If arrayFilas(contFila) = "optClasificacion" Then
                        filaClasificacion = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.Clasificacion AS CLASIFICACION"
                        Else
                            cadenaSelect += ", c.Clasificacion AS CLASIFICACION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.Clasificacion"
                        Else
                            cadenaGroupBy += ", c.Clasificacion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLASIFICACION"
                        Else
                            orderByConsulta += ", CLASIFICACION"
                        End If

                    ElseIf arrayFilas(contFila) = "optCliente" Then
                        filaCliente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.nombre AS CLIENTE"
                        Else
                            cadenaSelect += ", c.nombre AS CLIENTE"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.nombre"
                        Else
                            cadenaGroupBy += ", c.nombre"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLIENTE"
                        Else
                            orderByConsulta += ", CLIENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optAgente" Then
                        filaAgente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " a.Nombre as AGENTE "
                        Else
                            cadenaSelect += ", a.Nombre as AGENTE "
                        End If

                        cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " a.Nombre"
                        Else
                            cadenaGroupBy += ", a.Nombre"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by AGENTE"
                        Else
                            orderByConsulta += ", AGENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optMarca" Then
                        filaMarca = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.marca AS MARCA"
                        Else
                            cadenaSelect += ", ve.marca AS MARCA"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.marca"
                        Else
                            cadenaGroupBy += ", ve.marca"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MARCA"
                        Else
                            orderByConsulta += ", MARCA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCategoria" Then
                        filaCategoria = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " tica_descripcion as 'NAVE DESARROLLA'"
                        Else
                            cadenaSelect += ", tica_descripcion as 'NAVE DESARROLLA'"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " tica_descripcion"
                        Else
                            cadenaGroupBy += ", tica_descripcion"
                        End If

                        If Len(categoria) > 0 Then
                            Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                            cadenaCategoriaWhere = "'0'"
                            arraycomillasCategoria = Strings.Split(categoria, ",")
                            For idmod = 0 To UBound(arraycomillasCategoria)
                                cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                            Else
                                whereConstruido += " AND (tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by 'NAVE DESARROLLA'"
                        Else
                            orderByConsulta += ", 'NAVE DESARROLLA'"
                        End If

                    ElseIf arrayFilas(contFila) = "optColeccion" Then
                        filaColeccion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.marca+' '+ve.Coleccion AS COLECCION"
                        Else
                            cadenaSelect += ",ve.marca+' '+ve.Coleccion AS COLECCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += "ve.marca, ve.Coleccion"
                        Else
                            cadenaGroupBy += ", ve.marca, ve.Coleccion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLECCION"
                        Else
                            orderByConsulta += ", COLECCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optModelo" Then
                        filaModelo = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS MODELO"
                        Else
                            cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS MODELO"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Marca, ve.IdModelo"
                        Else
                            cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MODELO"
                        Else
                            orderByConsulta += ", MODELO"
                        End If

                    ElseIf arrayFilas(contFila) = "optDescripcion" Then
                        filaDescripcion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.Descripcion AS DESCRIPCION"
                        Else
                            cadenaSelect += ", ve.Descripcion AS DESCRIPCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Descripcion"
                        Else
                            cadenaGroupBy += ", ve.Descripcion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by DESCRIPCION"
                        Else
                            orderByConsulta += ", DESCRIPCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optFamilia" Then
                        filaFamilia = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " fami_descripcion AS FAMILIA"
                        Else
                            cadenaSelect += ", fami_descripcion AS FAMILIA"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " fami_descripcion"
                        Else
                            cadenaGroupBy += ", fami_descripcion"
                        End If

                        If Len(familias) > 0 Then
                            Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                            cadenaFamiliaWhere = "'0'"
                            arraycomillasFamilia = Strings.Split(familias, ",")
                            For idFam = 0 To UBound(arraycomillasFamilia)
                                cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                            Else
                                whereConstruido += " AND (fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by FAMILIA"
                        Else
                            orderByConsulta += ", FAMILIA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCorrida" Then
                        filaCorrida = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " t.Talla AS CORRIDA"
                        Else
                            cadenaSelect += ", t.Talla AS CORRIDA"
                        End If
                        cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " t.Talla"
                        Else
                            cadenaGroupBy += ", t.Talla"
                        End If

                        If Len(corrida) > 0 Then
                            Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                            cadenaCorridaWhere = "'0'"
                            arraycomillasCorrida = Strings.Split(corrida, ",")
                            For iCor = 0 To UBound(arraycomillasCorrida)
                                cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                            Else
                                whereConstruido += " AND (t.Talla IN (" + cadenaCorridaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CORRIDA"
                        Else
                            orderByConsulta += ", CORRIDA"
                        End If

                    ElseIf arrayFilas(contFila) = "optColor" Then
                        filaColor = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.Color AS COLOR"
                        Else
                            cadenaSelect += ", ve.Color AS COLOR"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Color"
                        Else
                            cadenaGroupBy += ", ve.Color"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLOR"
                        Else
                            orderByConsulta += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFila) = "optRuta" Then
                        filaRuta = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " r.Ruta AS RUTA"
                        Else
                            cadenaSelect += ", r.Ruta AS RUTA"
                        End If
                        cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " r.Ruta"
                        Else
                            cadenaGroupBy += ", r.Ruta"
                        End If

                        If Len(Ruta) > 0 Then
                            Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                            cadenaRutaWhere = "'0'"
                            arraycomillasRuta = Strings.Split(Ruta, ",")
                            For iRuta = 0 To UBound(arraycomillasRuta)
                                cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                            Else
                                whereConstruido += " AND (r.IdRuta IN (" + cadenaRutaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by RUTA"
                        Else
                            orderByConsulta += ", RUTA"
                        End If
                    End If
                Next contFila

                If Len(categoria) > 0 And filaCategoria = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                    cadenaCategoriaWhere = "'0'"
                    arraycomillasCategoria = Strings.Split(categoria, ",")
                    For idmod = 0 To UBound(arraycomillasCategoria)
                        cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                    Else
                        whereConstruido += " AND (tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                    End If

                End If

                If Len(familias) > 0 And filaFamilia = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                    cadenaFamiliaWhere = "'0'"
                    arraycomillasFamilia = Strings.Split(familias, ",")
                    For idFam = 0 To UBound(arraycomillasFamilia)
                        cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                    Else
                        whereConstruido += " AND (fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                    End If
                End If


                If Len(corrida) > 0 And filaCorrida = False Then
                    cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"

                    Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                    cadenaCorridaWhere = "'0'"
                    arraycomillasCorrida = Strings.Split(corrida, ",")
                    For iCor = 0 To UBound(arraycomillasCorrida)
                        cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                    Else
                        whereConstruido += " AND (t.Talla IN (" + cadenaCorridaWhere + ")"
                    End If
                End If

                If Len(Ruta) > 0 And filaRuta = False Then
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                    cadenaRutaWhere = "'0'"
                    arraycomillasRuta = Strings.Split(Ruta, ",")
                    For iRuta = 0 To UBound(arraycomillasRuta)
                        cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                    Else
                        whereConstruido += " AND (r.IdRuta IN (" + cadenaRutaWhere + ")"
                    End If
                End If

                If opSuma = True Then
                    cadenaSelectOperacion += ", SUM(vt.Cantidad) AS PARES"
                End If
                If opColecciones = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES"
                End If
                If opArticulos = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS"
                    ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
                End If



                If whereConstruido.Length > 0 Then
                    cadenaWhereConsulta += whereConstruido + ")"
                End If

                If tipoReporte = "anual" Then
                    Dim anioIncremento As Int32 = anioInicio
                    Dim cadenaCamposPvt As String = ""
                    Dim cadenaCamposPvtCad As String = ""
                    For contCol As Int32 = 0 To diferenciaAnios
                        cadenaCamposPvt += "[" + anioIncremento.ToString + "],"
                        anioIncremento = anioIncremento + 1
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)"

                    cadenaCamposPvtCad = cadenaCamposPvt.Substring(0, cadenaCamposPvt.Length - 1)

                    Dim ListaParametros As New List(Of SqlClient.SqlParameter)

                    Dim ParametroParaLista As New SqlParameter
                    ParametroParaLista.ParameterName = "@cadenaSelect"
                    ParametroParaLista.Value = cadenaFinal
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@aniosPivot"
                    ParametroParaLista.Value = cadenaCamposPvtCad
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@operacion"
                    ParametroParaLista.Value = cadenaOperacion
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@orden"
                    ParametroParaLista.Value = orderByConsulta
                    ListaParametros.Add(ParametroParaLista)
                    dtDatosConsultaReporte = operConsultas.EjecutarConsultaSP("Programacion.SP_ConsultaReporteFechas", ListaParametros)

                    If opArticulos = True Or opColecciones = True Then
                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta)" + " ORDER BY ANIO"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta)" + " ORDER BY ANIO"
                        End If
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                    End If

                ElseIf tipoReporte = "mensual" Then
                    Dim dtDatosTotalesFechas As New DataTable

                    Dim anioIncrementa As Int32 = anioInicio
                    Dim mesesRep As Int32 = ((diferenciaAnios + 1) * 12)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + mesesRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next

                    Dim dtRowTitulosAnios As DataRow = dtDatosConsultaReporte.NewRow
                    Dim dtRowTitulosMeses As DataRow = dtDatosConsultaReporte.NewRow

                    Dim contadorMod As Int32 = 0

                    For contColN As Int32 = 0 To ((tamanoCamposFilas + mesesRep) - 1)
                        If contColN >= tamanoCamposFilas Then
                            If contadorMod = 12 Then
                                anioIncrementa = anioIncrementa + 1
                                contadorMod = 0
                            End If
                            dtRowTitulosAnios.Item(contColN) = anioIncrementa.ToString
                            dtRowTitulosMeses.Item(contColN) = (contadorMod + 1).ToString
                            contadorMod = contadorMod + 1
                        Else
                            dtRowTitulosAnios.Item(contColN) = ""
                            dtRowTitulosMeses.Item(contColN) = ""
                        End If
                    Next

                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosAnios)
                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosMeses)

                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)

                    For Each rowCol As DataRow In dtColumnasGeneral.Rows
                        Dim dtRowColumnas As DataRow = dtDatosConsultaReporte.NewRow
                        For cntFC As Int32 = 0 To tamanoCamposFilas - 1
                            dtRowColumnas.Item(cntFC) = rowCol.Item(cntFC)
                        Next
                        dtDatosConsultaReporte.Rows.Add(dtRowColumnas)
                    Next

                    For colDTtitulos As Int32 = 0 To tamanoCamposFilas - 1
                        dtDatosConsultaReporte.Rows(1).Item(colDTtitulos) = dtColumnasGeneral.Columns(colDTtitulos).ColumnName.ToString
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(MONTH, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO, MES"
                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)

                    If opArticulos = True Or opColecciones = True Then
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO" + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta

                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO,  DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta),  DATEPART(MONTH, vn.FechaVenta)" + " ORDER BY ANIO, MES"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO,  DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta),  DATEPART(MONTH, vn.FechaVenta)" + " ORDER BY ANIO, MES"
                        End If
                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)

                    End If
                    For Each rowDtA As DataRow In dtDatosConsultaReporte.Rows
                        For Each rowDtB As DataRow In dtDatosTotalesFechas.Rows
                            Dim esigual As Boolean = True
                            For contFilasSel As Int32 = 0 To tamanoCamposFilas - 1
                                If rowDtA.Item(contFilasSel).ToString <> rowDtB.Item(contFilasSel).ToString Then
                                    esigual = False
                                End If
                            Next
                            If esigual = True Then
                                For Each colmnDtB As DataColumn In dtDatosConsultaReporte.Columns
                                    If rowDtB.Item("ANIO").ToString = dtDatosConsultaReporte.Rows(0).Item(colmnDtB).ToString And rowDtB.Item("MES").ToString = dtDatosConsultaReporte.Rows(1).Item(colmnDtB).ToString Then
                                        rowDtA.Item(colmnDtB) = rowDtB.Item(cadenaOperacion).ToString
                                    End If
                                Next
                            End If
                        Next
                    Next

                    For Each columnaDT As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "1" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "ENERO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "2" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "FEBRERO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "3" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "MARZO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "4" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "ABRIL"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "5" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "MAYO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "6" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "JUNIO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "7" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "JULIO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "8" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "AGOSTO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "9" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "SEPTIEMBRE"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "10" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "OCTUBRE"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "11" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "NOVIEMBRE"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "12" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "DICIEMBRE"
                        End If
                    Next

                ElseIf tipoReporte = "semanal" Then
                    Dim dtDatosTotalesFechas As New DataTable
                    Dim anioIncrementa As Int32 = anioInicio
                    Dim semanasRep As Int32 = ((diferenciaAnios + 1) * 52)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + semanasRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next

                    Dim dtRowTitulosAnios As DataRow = dtDatosConsultaReporte.NewRow
                    Dim dtRowTitulosSemanas As DataRow = dtDatosConsultaReporte.NewRow
                    Dim contadorMod As Int32 = 0

                    For contColN As Int32 = 0 To ((tamanoCamposFilas + semanasRep) - 1)
                        If contColN >= tamanoCamposFilas Then
                            If contadorMod = 52 Then
                                anioIncrementa = anioIncrementa + 1
                                contadorMod = 0
                            End If
                            dtRowTitulosAnios.Item(contColN) = anioIncrementa.ToString
                            dtRowTitulosSemanas.Item(contColN) = (contadorMod + 1).ToString
                            contadorMod = contadorMod + 1
                        Else
                            dtRowTitulosAnios.Item(contColN) = ""
                            dtRowTitulosSemanas.Item(contColN) = ""
                        End If
                    Next

                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosAnios)
                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosSemanas)

                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)

                    If opArticulos = True Or opColecciones = True Then
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " ORDER BY ANIO, SEMANA"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " ORDER BY ANIO, SEMANA"
                        End If
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)
                    End If

                    For Each rowCol As DataRow In dtColumnasGeneral.Rows
                        Dim dtRowColumnas As DataRow = dtDatosConsultaReporte.NewRow
                        For cntFC As Int32 = 0 To tamanoCamposFilas - 1
                            dtRowColumnas.Item(cntFC) = rowCol.Item(cntFC)
                        Next
                        dtDatosConsultaReporte.Rows.Add(dtRowColumnas)
                    Next

                    For colDTtitulos As Int32 = 0 To tamanoCamposFilas - 1
                        dtDatosConsultaReporte.Rows(1).Item(colDTtitulos) = dtColumnasGeneral.Columns(colDTtitulos).ColumnName.ToString
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO, SEMANA"
                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)

                    For Each rowDtA As DataRow In dtDatosConsultaReporte.Rows
                        For Each rowDtB As DataRow In dtDatosTotalesFechas.Rows
                            Dim esigual As Boolean = True
                            For contFilasSel As Int32 = 0 To tamanoCamposFilas - 1
                                If rowDtA.Item(contFilasSel).ToString <> rowDtB.Item(contFilasSel).ToString Then
                                    esigual = False
                                End If
                            Next
                            If esigual = True Then
                                For Each colmnDtB As DataColumn In dtDatosConsultaReporte.Columns
                                    If rowDtB.Item("ANIO").ToString = dtDatosConsultaReporte.Rows(0).Item(colmnDtB).ToString And rowDtB.Item("SEMANA").ToString = dtDatosConsultaReporte.Rows(1).Item(colmnDtB).ToString Then
                                        rowDtA.Item(colmnDtB) = rowDtB.Item(cadenaOperacion).ToString
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

                Dim validarContenido As Boolean = True

                If tipoReporte = "anual" Then
                    If dtDatosConsultaReporte.Rows.Count > 0 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                Else
                    If dtDatosConsultaReporte.Rows.Count > 2 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                End If

                If validarContenido = True Then
                    Dim mesUno As Int32 = Month(fechaUno)
                    Dim mesDos As Int32 = Month(fechaDos)
                    Dim anioUno As Int32 = Year(fechaUno)
                    Dim anioDos As Int32 = Year(fechaDos)
                    Dim semanaUno As String = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                    Dim semanaDos As String = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                    If semanaUno > 52 Then
                        semanaUno = 52
                    End If
                    If semanaDos > 52 Then
                        semanaDos = 52
                    End If

                    If tipoReporte = "semanal" Then
                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If IsNumeric(dtDatosConsultaReporte.Rows(1).Item(contCol)) = True Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> semanaUno.ToString Then
                                    dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                    contCol = 0
                                Else
                                    Exit For
                                End If
                            End If
                        Next

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas - 1 Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "52" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next

                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> semanaDos.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next

                        If opSuma = True Then

                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next
                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        ElseIf opArticulos = True Or opColecciones = True Then
                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")
                            If opArticulos = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("ARTICULOS").ToString
                                    contFilaTotal += 1
                                Next
                            ElseIf opColecciones = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contCol As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contCol).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                    contFilaTotal += 1
                                Next
                            End If
                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = rowDt.Item("SEMANA").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If

                                Next
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        End If

                    End If


                    If tipoReporte = "mensual" Then
                        Dim mesUnoCadena As String = ""
                        If mesUno = 1 Then
                            mesUnoCadena = "ENERO"
                        ElseIf mesUno = 2 Then
                            mesUnoCadena = "FEBRERO"
                        ElseIf mesUno = 3 Then
                            mesUnoCadena = "MARZO"
                        ElseIf mesUno = 4 Then
                            mesUnoCadena = "ABRIL"
                        ElseIf mesUno = 5 Then
                            mesUnoCadena = "MAYO"
                        ElseIf mesUno = 6 Then
                            mesUnoCadena = "JUNIO"
                        ElseIf mesUno = 7 Then
                            mesUnoCadena = "JULIO"
                        ElseIf mesUno = 8 Then
                            mesUnoCadena = "AGOSTO"
                        ElseIf mesUno = 9 Then
                            mesUnoCadena = "SEPTIEMBRE"
                        ElseIf mesUno = 10 Then
                            mesUnoCadena = "OCTUBRE"
                        ElseIf mesUno = 11 Then
                            mesUnoCadena = "NOVIEMBRE"
                        ElseIf mesUno = 12 Then
                            mesUnoCadena = "DICIEMBRE"
                        End If

                        Dim mesDosCadena As String = ""
                        If mesDos = 1 Then
                            mesDosCadena = "ENERO"
                        ElseIf mesDos = 2 Then
                            mesDosCadena = "FEBRERO"
                        ElseIf mesDos = 3 Then
                            mesDosCadena = "MARZO"
                        ElseIf mesDos = 4 Then
                            mesDosCadena = "ABRIL"
                        ElseIf mesDos = 5 Then
                            mesDosCadena = "MAYO"
                        ElseIf mesDos = 6 Then
                            mesDosCadena = "JUNIO"
                        ElseIf mesDos = 7 Then
                            mesDosCadena = "JULIO"
                        ElseIf mesDos = 8 Then
                            mesDosCadena = "AGOSTO"
                        ElseIf mesDos = 9 Then
                            mesDosCadena = "SEPTIEMBRE"
                        ElseIf mesDos = 10 Then
                            mesDosCadena = "OCTUBRE"
                        ElseIf mesDos = 11 Then
                            mesDosCadena = "NOVIEMBRE"
                        ElseIf mesDos = 12 Then
                            mesDosCadena = "DICIEMBRE"
                        End If

                        For contCol As Int32 = tamanoCamposFilas To 12
                            contCol = tamanoCamposFilas
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> mesUnoCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(tamanoCamposFilas).ColumnName.ToString)
                            Else
                                Exit For
                            End If
                        Next

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "DICIEMBRE" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next
                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> mesDosCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next

                        If opSuma = True Then

                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)


                        ElseIf opArticulos = True Or opColecciones = True Then

                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")
                            If opArticulos = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("ARTICULOS").ToString
                                    contFilaTotal += 1
                                Next
                            ElseIf opColecciones = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contCol As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contCol).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                    contFilaTotal += 1
                                Next
                            End If
                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    Dim textoMes As String = ""
                                    If rowDt.Item("MES").ToString = "1" Then
                                        textoMes = "ENERO"
                                    ElseIf rowDt.Item("MES").ToString = "2" Then
                                        textoMes = "FEBRERO"
                                    ElseIf rowDt.Item("MES").ToString = "3" Then
                                        textoMes = "MARZO"
                                    ElseIf rowDt.Item("MES").ToString = "4" Then
                                        textoMes = "ABRIL"
                                    ElseIf rowDt.Item("MES").ToString = "5" Then
                                        textoMes = "MAYO"
                                    ElseIf rowDt.Item("MES").ToString = "6" Then
                                        textoMes = "JUNIO"
                                    ElseIf rowDt.Item("MES").ToString = "7" Then
                                        textoMes = "JULIO"
                                    ElseIf rowDt.Item("MES").ToString = "8" Then
                                        textoMes = "AGOSTO"
                                    ElseIf rowDt.Item("MES").ToString = "9" Then
                                        textoMes = "SEPTIEMBRE"
                                    ElseIf rowDt.Item("MES").ToString = "10" Then
                                        textoMes = "OCTUBRE"
                                    ElseIf rowDt.Item("MES").ToString = "11" Then
                                        textoMes = "NOVIEMBRE"
                                    ElseIf rowDt.Item("MES").ToString = "12" Then
                                        textoMes = "DICIEMBRE"
                                    End If
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = textoMes Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If
                    End If

                    If tipoReporte = "anual" Then
                        ' ''dtDatosConsultaReporte.Columns.Add("TotalTodo")
                        ' ''dtDatosConsultaReporte.Columns("TotalTodo").Caption = "TOTAL"
                        ' ''For contRow As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                        ' ''    Dim suma As Int32 = 0
                        ' ''    For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                        ' ''        If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(0).Item(contColumn).ToString <> "TOTAL" Then
                        ' ''            suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                        ' ''        Else
                        ' ''            dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                        ' ''        End If
                        ' ''    Next
                        ' ''Next

                        If opSuma = True Then
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        Else
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Columns(coldt).Caption.ToString = rowDt.Item("ANIO").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If

                    End If
                End If

                dtDatosConsultaReporte.Columns.Add("Index").SetOrdinal(0)
                If tipoReporte = "anual" Then
                    dtDatosConsultaReporte.Columns("Index").Caption = "#"
                End If
                Dim contFilaIndex As Int32 = 1
                For i As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                    If tipoReporte = "anual" Then
                        dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                        contFilaIndex += 1
                    Else
                        If i <= 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = "#"
                        Else
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    End If
                Next

            End If
        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            dtDatosConsultaReporte = dtErrorCatch

        End Try
        Return dtDatosConsultaReporte
    End Function

    Public Function generarConsultaFechasAnterior(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                           ByVal radioYO As String, ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String,
                                           ByVal ubicacion As String, ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim dtDatosConsultaReporte As New DataTable

        Try
            If filas <> "" Then
                Dim operConsultas As New Persistencia.OperacionesProcedimientosSICY
                Dim dtCantidadAnios As DataTable = operConsultas.EjecutaConsulta("SELECT DATEDIFF(YEAR, '" + fechaUno + "', '" + fechaDos + "');")
                Dim diferenciaAnios As Int32 = CInt(dtCantidadAnios.Rows(0).Item(0).ToString)
                Dim filaClasificacion As Boolean = False
                Dim filaCliente As Boolean = False
                Dim filaAgente As Boolean = False
                Dim filaMarca As Boolean = False
                Dim filaCategoria As Boolean = False
                Dim filaColeccion As Boolean = False
                Dim filaModelo As Boolean = False
                Dim filaDescripcion As Boolean = False
                Dim filaFamilia As Boolean = False
                Dim filaCorrida As Boolean = False
                Dim filaRuta As Boolean = False
                Dim filaColor As Boolean = False
                Dim opSuma As Boolean = False
                Dim opArticulos As Boolean = False
                Dim opColecciones As Boolean = False
                Dim anioInicio As Int32 = Year(fechaUno)
                Dim cadenaSelect As String = "SELECT"
                Dim cadenaSelectOperacion As String = ""
                Dim cadenaGroupBy As String = ""
                Dim cadenaWhereConsulta As String = ""
                Dim cadenaInnerVistaCategoriaFamilias As String = ""
                Dim orderByConsulta As String = ""
                Dim cadenaFinal As String = ""
                Dim cadenaFinalColeccionArticulo As String = ""
                Dim cadenaOperacion As String = ""
                Dim cadenaColor As String = ""
                Dim dtSubtotalesFechas As New DataTable
                Dim totalCadenaArticulosColecciones As String = ""
                Dim dtTotalCadenaArticulosColecciones As New DataTable

                Dim totalCadArtColTOTAL As String = ""
                Dim dtTotalCadArtColTOTAL As New DataTable

                If operaciones = "optSuma" Then
                    opSuma = True
                    cadenaOperacion = "PARES"
                ElseIf operaciones = "optCantArt" Then
                    opArticulos = True
                    cadenaOperacion = "ARTICULOS"
                ElseIf operaciones = "optCantCole" Then
                    opColecciones = True
                    cadenaOperacion = "COLECCIONES"
                End If

                Dim cadenaConsulta As String = " FROM Ventas.vwVentas vn" +
                    " INNER JOIN Ventas.vwVentasDetalles vt ON vn.IdRemision = vt.IdRemision AND vn.año = vt.año" +
                    " INNER JOIN vEstilos ve ON vt.IdCodigo = ve.IdCodigo" +
                    " INNER JOIN Cadenas c	ON vn.IdCadena = c.IdCadena"

                If conAgente = True Then
                    If vistaAgente = "MisClientes" Then
                        cadenaConsulta += " JOIN Ventas.coleccionMarcaFamiliaCadenaAgente cmfa ON vn.IdCadena = cmfa.cmfa_idCadena" &
                                        " AND (cmfa.cmfa_marcaSicy + cmfa.cmfa_coleccionSicy) = ve.IdLinea AND cmfa_idAgenteSicy IN (" & agentes & ")"
                    End If
                End If

                cadenaWhereConsulta = " WHERE FechaVenta >= '" + fechaUno + "' AND FechaVenta <= '" + fechaDos + "'" + "AND ISNULL(vn.Estatus, '') NOT IN ('cancelado') AND ISNULL(vn.TipoVenta, '') NOT IN ('F')"
                Dim whereConstruido As String = ""

                If conAgente = True Then
                    If vistaAgente = "MisVentas" Then

                        If Len(agentes) > 0 Then
                            Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                            cadenaAgenteWhere = "'0'"
                            arraycomillasAgente = Strings.Split(agentes, ",")
                            For iAgente = 0 To UBound(arraycomillasAgente)
                                cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                            Next
                            ' ''cadenaWhereConsulta += "AND vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                            cadenaWhereConsulta += " AND vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                        End If

                    ElseIf vistaAgente = "MisClientes" Then

                        If Len(agentes) > 0 Then
                            Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                            cadenaAgenteWhere = "'0'"
                            arraycomillasAgente = Strings.Split(agentes, ",")
                            For iAgente = 0 To UBound(arraycomillasAgente)
                                cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                            Next
                            'cadenaWhereConsulta += " AND vn.IdCadena IN (SELECT IdCadena FROM CadenasMarcasAgentes cma WHERE cma.IdAgente IN (" + cadenaAgenteWhere + "))"
                        End If

                    End If
                Else
                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        '' ''If whereConstruido.Length > 0 Then
                        '' ''    whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        '' ''Else
                        '' ''    whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        '' ''End If

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                        Else
                            whereConstruido += " AND (vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                        End If
                    End If
                End If


                If Len(clasificacion) > 0 Then
                    Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                    cadenaClasificacionWhere = "'0'"
                    arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                    For iClas = 0 To UBound(arraycomillasClasificacion)
                        cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                    Else
                        whereConstruido += " AND (c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                    End If
                End If

                If Len(clientes) > 0 Then
                    Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                    cadenaClienteWhere = "'0'"
                    arraycomillasClientes = Strings.Split(clientes, ",")
                    For iCli = 0 To UBound(arraycomillasClientes)
                        cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                    Else
                        whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                    End If

                End If

                If Len(colecciones) > 0 Then
                    Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                    cadenaColeccionWhere = "'0'"
                    arraycomillasColecciones = Strings.Split(colecciones, ",")
                    For iCol = 0 To UBound(arraycomillasColecciones)
                        cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                    End If

                End If

                If Len(marcas) > 0 Then
                    Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                    cadenaMarcaWhere = "'0'"
                    arraycomillasMarca = Strings.Split(marcas, ",")
                    For iMar = 0 To UBound(arraycomillasMarca)
                        cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.marca IN (" + cadenaMarcaWhere + ")"
                    Else
                        whereConstruido += " AND (ve.marca IN (" + cadenaMarcaWhere + ")"
                    End If
                End If

                If Len(modelos) > 0 Then
                    Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                    cadenaModeloWhere = "'0'"
                    arraycomillasModelo = Strings.Split(modelos, ",")
                    For idmod = 0 To UBound(arraycomillasModelo)
                        cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                    End If
                End If

                If Len(descripcion) > 0 Then
                    Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                    cadenaDescripcionWhere = "'0'"
                    arraycomillasDescripcion = Strings.Split(descripcion, ",")
                    For iDesc = 0 To UBound(arraycomillasDescripcion)
                        cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                    Else
                        whereConstruido += " AND ( ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                    End If
                End If

                If Len(Color) > 0 Then
                    Dim arraycomillasColor() As String, cadenaColorWhere As String
                    cadenaColorWhere = "'0'"
                    arraycomillasColor = Strings.Split(Color, ",")
                    For iColor = 0 To UBound(arraycomillasColor)
                        cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.Color IN (" + cadenaColorWhere + ")"
                    Else
                        whereConstruido += " AND (ve.Color IN (" + cadenaColorWhere + ")"
                    End If
                End If

                Dim arrayFilas() As String
                arrayFilas = Strings.Split(filas, ",")

                Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
                For contFila = 0 To UBound(arrayFilas)
                    If arrayFilas(contFila) = "optClasificacion" Then
                        filaClasificacion = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.Clasificacion AS CLASIFICACION"
                        Else
                            cadenaSelect += ", c.Clasificacion AS CLASIFICACION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.Clasificacion"
                        Else
                            cadenaGroupBy += ", c.Clasificacion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLASIFICACION"
                        Else
                            orderByConsulta += ", CLASIFICACION"
                        End If

                    ElseIf arrayFilas(contFila) = "optCliente" Then
                        filaCliente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.nombre AS CLIENTE"
                        Else
                            cadenaSelect += ", c.nombre AS CLIENTE"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.nombre"
                        Else
                            cadenaGroupBy += ", c.nombre"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLIENTE"
                        Else
                            orderByConsulta += ", CLIENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optAgente" Then
                        filaAgente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " a.Nombre as AGENTE "
                        Else
                            cadenaSelect += ", a.Nombre as AGENTE "
                        End If

                        cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " a.Nombre"
                        Else
                            cadenaGroupBy += ", a.Nombre"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by AGENTE"
                        Else
                            orderByConsulta += ", AGENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optMarca" Then
                        filaMarca = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.marca AS MARCA"
                        Else
                            cadenaSelect += ", ve.marca AS MARCA"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.marca"
                        Else
                            cadenaGroupBy += ", ve.marca"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MARCA"
                        Else
                            orderByConsulta += ", MARCA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCategoria" Then
                        filaCategoria = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " nave_nombre as 'NAVE DESARROLLA'"
                        Else
                            cadenaSelect += ", nave_nombre as 'NAVE DESARROLLA'"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " nave_nombre"
                        Else
                            cadenaGroupBy += ", nave_nombre"
                        End If

                        If Len(categoria) > 0 Then
                            Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                            cadenaCategoriaWhere = "'0'"
                            arraycomillasCategoria = Strings.Split(categoria, ",")
                            For idmod = 0 To UBound(arraycomillasCategoria)
                                cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " nave_nombre IN (" + cadenaCategoriaWhere + ")"
                            Else
                                whereConstruido += " AND (nave_nombre IN (" + cadenaCategoriaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by 'NAVE DESARROLLA'"
                        Else
                            orderByConsulta += ", 'NAVE DESARROLLA'"
                        End If

                    ElseIf arrayFilas(contFila) = "optColeccion" Then
                        filaColeccion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.marca+' '+ve.Coleccion AS COLECCION"
                        Else
                            cadenaSelect += ",ve.marca+' '+ve.Coleccion AS COLECCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += "ve.marca, ve.Coleccion"
                        Else
                            cadenaGroupBy += ", ve.marca, ve.Coleccion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLECCION"
                        Else
                            orderByConsulta += ", COLECCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optModelo" Then
                        filaModelo = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS MODELO"
                        Else
                            cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS MODELO"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Marca, ve.IdModelo"
                        Else
                            cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MODELO"
                        Else
                            orderByConsulta += ", MODELO"
                        End If

                    ElseIf arrayFilas(contFila) = "optDescripcion" Then
                        filaDescripcion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.Descripcion AS DESCRIPCION"
                        Else
                            cadenaSelect += ", ve.Descripcion AS DESCRIPCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Descripcion"
                        Else
                            cadenaGroupBy += ", ve.Descripcion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by DESCRIPCION"
                        Else
                            orderByConsulta += ", DESCRIPCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optFamilia" Then
                        filaFamilia = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " fami_descripcion AS FAMILIA"
                        Else
                            cadenaSelect += ", fami_descripcion AS FAMILIA"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " fami_descripcion"
                        Else
                            cadenaGroupBy += ", fami_descripcion"

                        End If

                        If Len(familias) > 0 Then
                            Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                            cadenaFamiliaWhere = "'0'"
                            arraycomillasFamilia = Strings.Split(familias, ",")
                            For idFam = 0 To UBound(arraycomillasFamilia)
                                cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                            Else
                                whereConstruido += " AND (fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by FAMILIA"
                        Else
                            orderByConsulta += ", FAMILIA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCorrida" Then
                        filaCorrida = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " t.Talla AS CORRIDA"
                        Else
                            cadenaSelect += ", t.Talla AS CORRIDA"
                        End If
                        cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " t.Talla"
                        Else
                            cadenaGroupBy += ", t.Talla"
                        End If

                        If Len(corrida) > 0 Then
                            Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                            cadenaCorridaWhere = "'0'"
                            arraycomillasCorrida = Strings.Split(corrida, ",")
                            For iCor = 0 To UBound(arraycomillasCorrida)
                                cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                            Else
                                whereConstruido += " AND (t.Talla IN (" + cadenaCorridaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CORRIDA"
                        Else
                            orderByConsulta += ", CORRIDA"
                        End If

                    ElseIf arrayFilas(contFila) = "optColor" Then
                        filaColor = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.Color AS COLOR"
                        Else
                            cadenaSelect += ", ve.Color AS COLOR"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Color"
                        Else
                            cadenaGroupBy += ", ve.Color"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLOR"
                        Else
                            orderByConsulta += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFila) = "optRuta" Then
                        filaRuta = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " r.Ruta AS RUTA"
                        Else
                            cadenaSelect += ", r.Ruta AS RUTA"
                        End If
                        cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " r.Ruta"
                        Else
                            cadenaGroupBy += ", r.Ruta"
                        End If

                        If Len(Ruta) > 0 Then
                            Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                            cadenaRutaWhere = "'0'"
                            arraycomillasRuta = Strings.Split(Ruta, ",")
                            For iRuta = 0 To UBound(arraycomillasRuta)
                                cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                            Else
                                whereConstruido += " AND (r.IdRuta IN (" + cadenaRutaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by RUTA"
                        Else
                            orderByConsulta += ", RUTA"
                        End If
                    End If
                Next contFila

                If Len(categoria) > 0 And filaCategoria = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                    cadenaCategoriaWhere = "'0'"
                    arraycomillasCategoria = Strings.Split(categoria, ",")
                    For idmod = 0 To UBound(arraycomillasCategoria)
                        cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                    Else
                        whereConstruido += " AND (tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                    End If

                End If

                If Len(familias) > 0 And filaFamilia = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                    cadenaFamiliaWhere = "'0'"
                    arraycomillasFamilia = Strings.Split(familias, ",")
                    For idFam = 0 To UBound(arraycomillasFamilia)
                        cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                    Else
                        whereConstruido += " AND (fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                    End If
                End If


                If Len(corrida) > 0 And filaCorrida = False Then
                    cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"

                    Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                    cadenaCorridaWhere = "'0'"
                    arraycomillasCorrida = Strings.Split(corrida, ",")
                    For iCor = 0 To UBound(arraycomillasCorrida)
                        cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                    Else
                        whereConstruido += " AND (t.Talla IN (" + cadenaCorridaWhere + ")"
                    End If
                End If

                If Len(Ruta) > 0 And filaRuta = False Then
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                    cadenaRutaWhere = "'0'"
                    arraycomillasRuta = Strings.Split(Ruta, ",")
                    For iRuta = 0 To UBound(arraycomillasRuta)
                        cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                    Else
                        whereConstruido += " AND (r.IdRuta IN (" + cadenaRutaWhere + ")"
                    End If
                End If

                If opSuma = True Then
                    cadenaSelectOperacion += ", SUM(vt.Cantidad) AS PARES"
                End If
                If opColecciones = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES"
                End If
                If opArticulos = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS"
                    ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
                End If



                If whereConstruido.Length > 0 Then
                    cadenaWhereConsulta += whereConstruido + ")"
                End If

                If tipoReporte = "anual" Then
                    Dim anioIncremento As Int32 = anioInicio
                    Dim cadenaCamposPvt As String = ""
                    Dim cadenaCamposPvtCad As String = ""
                    For contCol As Int32 = 0 To diferenciaAnios
                        cadenaCamposPvt += "[" + anioIncremento.ToString + "],"
                        anioIncremento = anioIncremento + 1
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)"

                    cadenaCamposPvtCad = cadenaCamposPvt.Substring(0, cadenaCamposPvt.Length - 1)

                    Dim ListaParametros As New List(Of SqlClient.SqlParameter)

                    Dim ParametroParaLista As New SqlParameter
                    ParametroParaLista.ParameterName = "@cadenaSelect"
                    ParametroParaLista.Value = cadenaFinal
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@aniosPivot"
                    ParametroParaLista.Value = cadenaCamposPvtCad
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@operacion"
                    ParametroParaLista.Value = cadenaOperacion
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@orden"
                    ParametroParaLista.Value = orderByConsulta
                    ListaParametros.Add(ParametroParaLista)
                    dtDatosConsultaReporte = operConsultas.EjecutarConsultaSP("Programacion.SP_ConsultaReporteFechas", ListaParametros)

                    If opArticulos = True Or opColecciones = True Then
                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta)" + " ORDER BY ANIO"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta)" + " ORDER BY ANIO"
                        End If
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                    End If

                ElseIf tipoReporte = "mensual" Then
                    Dim dtDatosTotalesFechas As New DataTable

                    Dim anioIncrementa As Int32 = anioInicio
                    Dim mesesRep As Int32 = ((diferenciaAnios + 1) * 12)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + mesesRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next

                    Dim dtRowTitulosAnios As DataRow = dtDatosConsultaReporte.NewRow
                    Dim dtRowTitulosMeses As DataRow = dtDatosConsultaReporte.NewRow

                    Dim contadorMod As Int32 = 0

                    For contColN As Int32 = 0 To ((tamanoCamposFilas + mesesRep) - 1)
                        If contColN >= tamanoCamposFilas Then
                            If contadorMod = 12 Then
                                anioIncrementa = anioIncrementa + 1
                                contadorMod = 0
                            End If
                            dtRowTitulosAnios.Item(contColN) = anioIncrementa.ToString
                            dtRowTitulosMeses.Item(contColN) = (contadorMod + 1).ToString
                            contadorMod = contadorMod + 1
                        Else
                            dtRowTitulosAnios.Item(contColN) = ""
                            dtRowTitulosMeses.Item(contColN) = ""
                        End If
                    Next

                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosAnios)
                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosMeses)

                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)

                    For Each rowCol As DataRow In dtColumnasGeneral.Rows
                        Dim dtRowColumnas As DataRow = dtDatosConsultaReporte.NewRow
                        For cntFC As Int32 = 0 To tamanoCamposFilas - 1
                            dtRowColumnas.Item(cntFC) = rowCol.Item(cntFC)
                        Next
                        dtDatosConsultaReporte.Rows.Add(dtRowColumnas)
                    Next

                    For colDTtitulos As Int32 = 0 To tamanoCamposFilas - 1
                        dtDatosConsultaReporte.Rows(1).Item(colDTtitulos) = dtColumnasGeneral.Columns(colDTtitulos).ColumnName.ToString
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(MONTH, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO, MES"
                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)

                    If opArticulos = True Or opColecciones = True Then
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO" + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta

                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO,  DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta),  DATEPART(MONTH, vn.FechaVenta)" + " ORDER BY ANIO, MES"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO,  DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta),  DATEPART(MONTH, vn.FechaVenta)" + " ORDER BY ANIO, MES"
                        End If
                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)

                    End If
                    ' ''For Each rowDtA As DataRow In dtDatosConsultaReporte.Rows
                    ' ''    For Each rowDtB As DataRow In dtDatosTotalesFechas.Rows
                    ' ''        Dim esigual As Boolean = True
                    ' ''        For contFilasSel As Int32 = 0 To tamanoCamposFilas - 1
                    ' ''            If rowDtA.Item(contFilasSel).ToString <> rowDtB.Item(contFilasSel).ToString Then
                    ' ''                esigual = False
                    ' ''            End If
                    ' ''        Next
                    ' ''        If esigual = True Then
                    ' ''            For Each colmnDtB As DataColumn In dtDatosConsultaReporte.Columns
                    ' ''                If rowDtB.Item("ANIO").ToString = dtDatosConsultaReporte.Rows(0).Item(colmnDtB).ToString And rowDtB.Item("MES").ToString = dtDatosConsultaReporte.Rows(1).Item(colmnDtB).ToString Then
                    ' ''                    rowDtA.Item(colmnDtB) = rowDtB.Item(cadenaOperacion).ToString
                    ' ''                End If
                    ' ''            Next
                    ' ''        End If
                    ' ''    Next
                    ' ''Next
                    'aqui esta susana

                    For Each rowDtA As DataRow In dtDatosConsultaReporte.Rows
                        For Each rowDtB As DataRow In dtDatosTotalesFechas.Rows
                            Dim esigual As Boolean = True
                            For contFilasSel As Int32 = 0 To tamanoCamposFilas - 1
                                If rowDtA.Item(contFilasSel).ToString <> rowDtB.Item(contFilasSel).ToString Then
                                    esigual = False
                                End If
                            Next
                            If esigual = True Then
                                For Each colmnDtB As DataColumn In dtDatosConsultaReporte.Columns
                                    If rowDtB.Item("ANIO").ToString = dtDatosConsultaReporte.Rows(0).Item(colmnDtB).ToString And rowDtB.Item("MES").ToString = dtDatosConsultaReporte.Rows(1).Item(colmnDtB).ToString Then
                                        rowDtA.Item(colmnDtB) = rowDtB.Item(cadenaOperacion).ToString
                                    End If
                                Next
                            End If
                        Next
                    Next

                    For Each columnaDT As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "1" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "ENERO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "2" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "FEBRERO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "3" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "MARZO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "4" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "ABRIL"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "5" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "MAYO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "6" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "JUNIO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "7" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "JULIO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "8" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "AGOSTO"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "9" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "SEPTIEMBRE"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "10" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "OCTUBRE"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "11" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "NOVIEMBRE"
                        ElseIf dtDatosConsultaReporte.Rows(1).Item(columnaDT).ToString = "12" Then
                            dtDatosConsultaReporte.Rows(1).Item(columnaDT) = "DICIEMBRE"
                        End If
                    Next

                ElseIf tipoReporte = "semanal" Then
                    Dim dtDatosTotalesFechas As New DataTable
                    Dim anioIncrementa As Int32 = anioInicio
                    Dim semanasRep As Int32 = ((diferenciaAnios + 1) * 52)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + semanasRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next

                    Dim dtRowTitulosAnios As DataRow = dtDatosConsultaReporte.NewRow
                    Dim dtRowTitulosSemanas As DataRow = dtDatosConsultaReporte.NewRow
                    Dim contadorMod As Int32 = 0

                    For contColN As Int32 = 0 To ((tamanoCamposFilas + semanasRep) - 1)
                        If contColN >= tamanoCamposFilas Then
                            If contadorMod = 52 Then
                                anioIncrementa = anioIncrementa + 1
                                contadorMod = 0
                            End If
                            dtRowTitulosAnios.Item(contColN) = anioIncrementa.ToString
                            dtRowTitulosSemanas.Item(contColN) = (contadorMod + 1).ToString
                            contadorMod = contadorMod + 1
                        Else
                            dtRowTitulosAnios.Item(contColN) = ""
                            dtRowTitulosSemanas.Item(contColN) = ""
                        End If
                    Next

                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosAnios)
                    dtDatosConsultaReporte.Rows.Add(dtRowTitulosSemanas)

                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)

                    If opArticulos = True Or opColecciones = True Then
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " ORDER BY ANIO, SEMANA"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " ORDER BY ANIO, SEMANA"
                        End If
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)
                    End If

                    For Each rowCol As DataRow In dtColumnasGeneral.Rows
                        Dim dtRowColumnas As DataRow = dtDatosConsultaReporte.NewRow
                        For cntFC As Int32 = 0 To tamanoCamposFilas - 1
                            dtRowColumnas.Item(cntFC) = rowCol.Item(cntFC)
                        Next
                        dtDatosConsultaReporte.Rows.Add(dtRowColumnas)
                    Next

                    For colDTtitulos As Int32 = 0 To tamanoCamposFilas - 1
                        dtDatosConsultaReporte.Rows(1).Item(colDTtitulos) = dtColumnasGeneral.Columns(colDTtitulos).ColumnName.ToString
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO, SEMANA"
                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)

                    For Each rowDtA As DataRow In dtDatosConsultaReporte.Rows
                        For Each rowDtB As DataRow In dtDatosTotalesFechas.Rows
                            Dim esigual As Boolean = True
                            For contFilasSel As Int32 = 0 To tamanoCamposFilas - 1
                                If rowDtA.Item(contFilasSel).ToString <> rowDtB.Item(contFilasSel).ToString Then
                                    esigual = False
                                End If
                            Next
                            If esigual = True Then
                                For Each colmnDtB As DataColumn In dtDatosConsultaReporte.Columns
                                    If rowDtB.Item("ANIO").ToString = dtDatosConsultaReporte.Rows(0).Item(colmnDtB).ToString And rowDtB.Item("SEMANA").ToString = dtDatosConsultaReporte.Rows(1).Item(colmnDtB).ToString Then
                                        rowDtA.Item(colmnDtB) = rowDtB.Item(cadenaOperacion).ToString
                                    End If
                                Next
                            End If
                        Next
                    Next
                End If

                Dim validarContenido As Boolean = True

                If tipoReporte = "anual" Then
                    If dtDatosConsultaReporte.Rows.Count > 0 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                Else
                    If dtDatosConsultaReporte.Rows.Count > 2 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                End If

                If validarContenido = True Then
                    Dim mesUno As Int32 = Month(fechaUno)
                    Dim mesDos As Int32 = Month(fechaDos)
                    Dim anioUno As Int32 = Year(fechaUno)
                    Dim anioDos As Int32 = Year(fechaDos)
                    Dim semanaUno As String = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                    Dim semanaDos As String = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                    If semanaUno > 52 Then
                        semanaUno = 52
                    End If
                    If semanaDos > 52 Then
                        semanaDos = 52
                    End If

                    If tipoReporte = "semanal" Then
                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If IsNumeric(dtDatosConsultaReporte.Rows(1).Item(contCol)) = True Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> semanaUno.ToString Then
                                    dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                    contCol = 0
                                Else
                                    Exit For
                                End If
                            End If
                        Next

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas - 1 Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "52" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next

                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> semanaDos.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next

                        If opSuma = True Then

                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next
                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        ElseIf opArticulos = True Or opColecciones = True Then
                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")
                            If opArticulos = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("ARTICULOS").ToString
                                    contFilaTotal += 1
                                Next
                            ElseIf opColecciones = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contCol As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contCol).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                    contFilaTotal += 1
                                Next
                            End If
                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = rowDt.Item("SEMANA").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If

                                Next
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        End If

                    End If


                    If tipoReporte = "mensual" Then
                        Dim mesUnoCadena As String = ""
                        If mesUno = 1 Then
                            mesUnoCadena = "ENERO"
                        ElseIf mesUno = 2 Then
                            mesUnoCadena = "FEBRERO"
                        ElseIf mesUno = 3 Then
                            mesUnoCadena = "MARZO"
                        ElseIf mesUno = 4 Then
                            mesUnoCadena = "ABRIL"
                        ElseIf mesUno = 5 Then
                            mesUnoCadena = "MAYO"
                        ElseIf mesUno = 6 Then
                            mesUnoCadena = "JUNIO"
                        ElseIf mesUno = 7 Then
                            mesUnoCadena = "JULIO"
                        ElseIf mesUno = 8 Then
                            mesUnoCadena = "AGOSTO"
                        ElseIf mesUno = 9 Then
                            mesUnoCadena = "SEPTIEMBRE"
                        ElseIf mesUno = 10 Then
                            mesUnoCadena = "OCTUBRE"
                        ElseIf mesUno = 11 Then
                            mesUnoCadena = "NOVIEMBRE"
                        ElseIf mesUno = 12 Then
                            mesUnoCadena = "DICIEMBRE"
                        End If

                        Dim mesDosCadena As String = ""
                        If mesDos = 1 Then
                            mesDosCadena = "ENERO"
                        ElseIf mesDos = 2 Then
                            mesDosCadena = "FEBRERO"
                        ElseIf mesDos = 3 Then
                            mesDosCadena = "MARZO"
                        ElseIf mesDos = 4 Then
                            mesDosCadena = "ABRIL"
                        ElseIf mesDos = 5 Then
                            mesDosCadena = "MAYO"
                        ElseIf mesDos = 6 Then
                            mesDosCadena = "JUNIO"
                        ElseIf mesDos = 7 Then
                            mesDosCadena = "JULIO"
                        ElseIf mesDos = 8 Then
                            mesDosCadena = "AGOSTO"
                        ElseIf mesDos = 9 Then
                            mesDosCadena = "SEPTIEMBRE"
                        ElseIf mesDos = 10 Then
                            mesDosCadena = "OCTUBRE"
                        ElseIf mesDos = 11 Then
                            mesDosCadena = "NOVIEMBRE"
                        ElseIf mesDos = 12 Then
                            mesDosCadena = "DICIEMBRE"
                        End If

                        For contCol As Int32 = tamanoCamposFilas To 12
                            contCol = tamanoCamposFilas
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> mesUnoCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(tamanoCamposFilas).ColumnName.ToString)
                            Else
                                Exit For
                            End If
                        Next

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "DICIEMBRE" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next
                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> mesDosCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next

                        ' '' ''If opSuma = True Then

                        For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                            Dim suma As Int32 = 0
                            For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                    If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                        If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                            suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                        End If
                                    End If
                                ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                    dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                    suma = 0
                                End If
                            Next
                        Next

                        dtDatosConsultaReporte.Columns.Add("TotalTodo")
                        dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                        For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                            Dim suma As Int32 = 0
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                    suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                Else
                                    dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                End If
                            Next
                        Next

                        Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                        filaResultados.Item(0) = "TOTAL"
                        For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                            Dim sumaFila As Int32 = 0
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                    sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                End If
                            Next
                            filaResultados.Item(contColumn) = sumaFila
                        Next
                        dtDatosConsultaReporte.Rows.Add(filaResultados)


                        ' '' ''ElseIf opArticulos = True Or opColecciones = True Then

                        ' '' ''    For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                        ' '' ''        For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                        ' '' ''            If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                        ' '' ''                For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                        ' '' ''                    Dim inserta As Boolean = True
                        ' '' ''                    For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                        ' '' ''                        If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                        ' '' ''                            inserta = False
                        ' '' ''                            Exit For
                        ' '' ''                        End If
                        ' '' ''                    Next
                        ' '' ''                    If inserta = True Then
                        ' '' ''                        If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                        ' '' ''                            inserta = False
                        ' '' ''                        End If
                        ' '' ''                    End If
                        ' '' ''                    If inserta = True Then
                        ' '' ''                        If opArticulos = True Then
                        ' '' ''                            dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                        ' '' ''                        ElseIf opColecciones = True Then
                        ' '' ''                            dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                        ' '' ''                        End If

                        ' '' ''                    End If
                        ' '' ''                Next
                        ' '' ''            End If
                        ' '' ''        Next
                        ' '' ''    Next

                        ' '' ''    dtDatosConsultaReporte.Columns.Add("TOTAL")
                        ' '' ''    'Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                        ' '' ''    'If opArticulos = True Then
                        ' '' ''    '    Dim contFilaTotal As Int32 = 0
                        ' '' ''    '    For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                        ' '' ''    '        dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("ARTICULOS").ToString
                        ' '' ''    '        contFilaTotal += 1
                        ' '' ''    '    Next
                        ' '' ''    '    filaResultados.Item(dtDatosConsultaReporte.Rows.Count - 2) = contFilaTotal
                        ' '' ''    'ElseIf opColecciones = True Then
                        ' '' ''    '    Dim contFilaTotal As Int32 = 0
                        ' '' ''    '    For contCol As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                        ' '' ''    '        dtDatosConsultaReporte.Rows(contCol).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                        ' '' ''    '        contFilaTotal += 1
                        ' '' ''    '    Next
                        ' '' ''    '    filaResultados.Item(dtDatosConsultaReporte.Rows.Count - 2) = contFilaTotal
                        ' '' ''    'End If

                        ' '' ''    Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                        ' '' ''    filaResultados.Item(0) = "TOTAL"
                        ' '' ''    For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                        ' '' ''        Dim sumaFila As Int32 = 0
                        ' '' ''        For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                        ' '' ''            If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                        ' '' ''                sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                        ' '' ''            End If
                        ' '' ''        Next
                        ' '' ''        filaResultados.Item(contColumn) = sumaFila
                        ' '' ''    Next


                        ' '' ''    dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"


                        ' '' ''    For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                        ' '' ''        For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                        ' '' ''            Dim textoMes As String = ""
                        ' '' ''            If rowDt.Item("MES").ToString = "1" Then
                        ' '' ''                textoMes = "ENERO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "2" Then
                        ' '' ''                textoMes = "FEBRERO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "3" Then
                        ' '' ''                textoMes = "MARZO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "4" Then
                        ' '' ''                textoMes = "ABRIL"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "5" Then
                        ' '' ''                textoMes = "MAYO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "6" Then
                        ' '' ''                textoMes = "JUNIO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "7" Then
                        ' '' ''                textoMes = "JULIO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "8" Then
                        ' '' ''                textoMes = "AGOSTO"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "9" Then
                        ' '' ''                textoMes = "SEPTIEMBRE"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "10" Then
                        ' '' ''                textoMes = "OCTUBRE"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "11" Then
                        ' '' ''                textoMes = "NOVIEMBRE"
                        ' '' ''            ElseIf rowDt.Item("MES").ToString = "12" Then
                        ' '' ''                textoMes = "DICIEMBRE"
                        ' '' ''            End If
                        ' '' ''            If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = textoMes Then
                        ' '' ''                filaResultados.Item(coldt) = rowDt.Item(0).ToString
                        ' '' ''                Exit For
                        ' '' ''            End If
                        ' '' ''        Next
                        ' '' ''    Next
                        ' '' ''    filaResultados.Item(0) = "TOTAL"
                        ' '' ''    dtDatosConsultaReporte.Rows.Add(filaResultados)
                        ' '' ''End If
                    End If

                    If tipoReporte = "anual" Then
                        '' ''dtDatosConsultaReporte.Columns.Add("TotalTodo")
                        '' ''dtDatosConsultaReporte.Columns("TotalTodo").Caption = "TOTAL"
                        '' ''For contRow As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                        '' ''    Dim suma As Int32 = 0
                        '' ''    For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                        '' ''        If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(0).Item(contColumn).ToString <> "TOTAL" Then
                        '' ''            suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                        '' ''        Else
                        '' ''            dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                        '' ''        End If
                        '' ''    Next
                        '' ''Next

                        If opSuma = True Then
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        Else
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Columns(coldt).Caption.ToString = rowDt.Item("ANIO").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If

                    End If
                End If

                If tipoReporte = "anual" Then
                    dtDatosConsultaReporte.Columns.Add("TOTAL")
                    Dim sumaTotal As Int32 = 0
                    For rowTotal As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                        sumaTotal = 0
                        For colTotal As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 2
                            If dtDatosConsultaReporte.Rows(rowTotal).Item(colTotal).ToString <> "" Then
                                sumaTotal = sumaTotal + dtDatosConsultaReporte.Rows(rowTotal).Item(colTotal)
                            End If
                        Next
                        dtDatosConsultaReporte.Rows(rowTotal).Item("TOTAL") = sumaTotal
                    Next
                End If

                Dim dtTablaOrdenada As New DataTable
                For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                    If contCol = dtDatosConsultaReporte.Columns.Count - 1 Then
                        dtTablaOrdenada.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption, Type.GetType("System.Int32"))
                    Else
                        dtTablaOrdenada.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption)
                    End If
                Next

                If tipoReporte <> "anual" Then
                    For cont As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 2
                        dtTablaOrdenada.ImportRow(dtDatosConsultaReporte.Rows(cont))
                    Next
                Else
                    For cont As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 2
                        dtTablaOrdenada.ImportRow(dtDatosConsultaReporte.Rows(cont))
                    Next
                End If

                Dim viewDtDatos As New DataView(dtTablaOrdenada)
                viewDtDatos.Sort = dtDatosConsultaReporte.Columns(dtDatosConsultaReporte.Columns.Count - 1).Caption.ToString + " DESC"
                dtTablaOrdenada = New DataTable
                dtTablaOrdenada = viewDtDatos.ToTable

                Dim dtTraspaso As New DataTable
                For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                    dtTraspaso.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption)
                Next

                If tipoReporte <> "anual" Then
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(0))
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(1))
                    For Each rowDt As DataRow In dtTablaOrdenada.Rows
                        dtTraspaso.ImportRow(rowDt)
                    Next
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1))
                Else
                    For Each rowDt As DataRow In dtTablaOrdenada.Rows
                        dtTraspaso.ImportRow(rowDt)
                    Next
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1))
                End If

                dtDatosConsultaReporte = New DataTable
                dtDatosConsultaReporte = dtTraspaso
                dtDatosConsultaReporte.Columns.Add("Index").SetOrdinal(0)
                dtDatosConsultaReporte.Columns("Index").Caption = "#"
                Dim contFilaIndex As Int32 = 1
                For i As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                    If tipoReporte = "anual" Then
                        If i < dtDatosConsultaReporte.Rows.Count - 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    Else
                        If i <= 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = "#"
                        ElseIf i < dtDatosConsultaReporte.Rows.Count - 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    End If
                Next

                Dim ultimaCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1
                Dim ultimaFila As Int32 = dtDatosConsultaReporte.Rows.Count - 1
                Dim TotalVentas As Double = CInt(dtDatosConsultaReporte.Rows(ultimaFila).Item(ultimaCol))
                Dim porcentajeFila As Decimal = 0.0
                dtDatosConsultaReporte.Columns.Add("Porcentaje")
                dtDatosConsultaReporte.Columns("Porcentaje").Caption = "%"
                If tipoReporte = "anual" Then
                    For rowTotal As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                        If dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol).ToString <> "" Then
                            porcentajeFila = (dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                            dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                        End If
                        ' ''dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = (CDbl((dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100)) / TotalVentas)
                    Next
                Else
                    For rowTotal As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                        porcentajeFila = (dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                        dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                        ' ''dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = (CDbl((dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100)) / TotalVentas)
                    Next
                End If

                Dim porcentajeColumna As Decimal = 0.0
                Dim rowPorcent As DataRow
                rowPorcent = dtDatosConsultaReporte.NewRow
                For Each colDtp As DataColumn In dtDatosConsultaReporte.Columns
                    If IsNumeric(dtDatosConsultaReporte.Rows(ultimaFila).Item(colDtp.ColumnName.ToString)) Then
                        porcentajeColumna = (dtDatosConsultaReporte.Rows(ultimaFila).Item(colDtp) * 100) / TotalVentas
                        rowPorcent.Item(colDtp) = porcentajeColumna.ToString("N2") + "%"
                    End If
                Next
                rowPorcent.Item(1) = "%"
                If tipoReporte <> "anual" Then
                    dtDatosConsultaReporte.Rows(1).Item(ultimaCol + 1) = "%"
                End If


                dtDatosConsultaReporte.Rows.Add(rowPorcent)
            End If

        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            dtDatosConsultaReporte = dtErrorCatch

        End Try
        Return dtDatosConsultaReporte
    End Function

    Public Function generarConsultaFechas(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                       ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                       ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                       ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                       ByVal radioYO As String, ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String,
                                       ByVal ubicacion As String, ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim dtDatosConsultaReporte As New DataTable

        Try
            If filas <> "" Then
                Dim operConsultas As New Persistencia.OperacionesProcedimientosSICY
                Dim dtCantidadAnios As DataTable = operConsultas.EjecutaConsulta("SELECT DATEDIFF(YEAR, '" + fechaUno + "', '" + fechaDos + "');")
                Dim diferenciaAnios As Int32 = CInt(dtCantidadAnios.Rows(0).Item(0).ToString)
                Dim filaClasificacion As Boolean = False
                Dim filaCliente As Boolean = False
                Dim filaAgente As Boolean = False
                Dim filaMarca As Boolean = False
                Dim filaCategoria As Boolean = False
                Dim filaColeccion As Boolean = False
                Dim filaModelo As Boolean = False
                Dim filaDescripcion As Boolean = False
                Dim filaFamilia As Boolean = False
                Dim filaCorrida As Boolean = False
                Dim filaRuta As Boolean = False
                Dim filaColor As Boolean = False
                Dim opSuma As Boolean = False
                Dim opArticulos As Boolean = False
                Dim opColecciones As Boolean = False
                Dim anioInicio As Int32 = Year(fechaUno)
                Dim cadenaSelect As String = "SELECT"
                Dim cadenaSelectOperacion As String = ""
                Dim cadenaGroupBy As String = ""
                Dim cadenaWhereConsulta As String = ""
                Dim cadenaInnerVistaCategoriaFamilias As String = ""
                Dim orderByConsulta As String = ""
                Dim cadenaFinal As String = ""
                Dim cadenaFinalColeccionArticulo As String = ""
                Dim cadenaOperacion As String = ""
                Dim cadenaColor As String = ""
                Dim dtSubtotalesFechas As New DataTable
                Dim totalCadenaArticulosColecciones As String = ""
                Dim dtTotalCadenaArticulosColecciones As New DataTable

                Dim totalCadArtColTOTAL As String = ""
                Dim dtTotalCadArtColTOTAL As New DataTable
                Dim dtTotalFinaARTCOL As New DataTable
                Dim dtTotalesSubtotalesFechas As New DataTable

                If operaciones = "optSuma" Then
                    opSuma = True
                    cadenaOperacion = "PARES"
                ElseIf operaciones = "optCantArt" Then
                    opArticulos = True
                    cadenaOperacion = "ARTICULOS"
                ElseIf operaciones = "optCantCole" Then
                    opColecciones = True
                    cadenaOperacion = "COLECCIONES"
                End If

                Dim cadenaConsulta As String = " FROM Ventas.vwVentas vn" +
                    " INNER JOIN Ventas.vwVentasDetalles vt ON vn.IdRemision = vt.IdRemision AND vn.año = vt.año" +
                    " INNER JOIN vEstilos ve ON vt.IdCodigo = ve.IdCodigo" +
                    " INNER JOIN Cadenas c  ON vn.IdCadena = c.IdCadena " +
                    " INNER JOIN Ventas.EstadVentas_Semana evs ON vn.FechaVenta = evs.evse_fecha "

                If conAgente = True Then
                    If vistaAgente = "MisClientes" Then
                        cadenaConsulta += " JOIN Ventas.coleccionMarcaFamiliaCadenaAgente cmfa ON vn.IdCadena = cmfa.cmfa_idCadena" &
                                        " AND (cmfa.cmfa_marcaSicy + cmfa.cmfa_coleccionSicy) = ve.IdLinea AND cmfa_idAgenteSicy IN (" & agentes & ")"
                    End If
                End If

                cadenaWhereConsulta = " WHERE FechaVenta >= '" + fechaUno + "' AND FechaVenta <= '" + fechaDos + "'" + "AND ISNULL(vn.Estatus, '') NOT IN ('cancelado') AND ISNULL(vn.TipoVenta, '') NOT IN ('F')"
                Dim whereConstruido As String = ""

                If conAgente = True Then
                    If vistaAgente = "MisVentas" Then

                        If Len(agentes) > 0 Then
                            Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                            cadenaAgenteWhere = "'0'"
                            arraycomillasAgente = Strings.Split(agentes, ",")
                            For iAgente = 0 To UBound(arraycomillasAgente)
                                cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                            Next
                            ' ''cadenaWhereConsulta += "AND vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                            cadenaWhereConsulta += " AND vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                        End If

                    ElseIf vistaAgente = "MisClientes" Then

                        If Len(agentes) > 0 Then
                            Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                            cadenaAgenteWhere = "'0'"
                            arraycomillasAgente = Strings.Split(agentes, ",")
                            For iAgente = 0 To UBound(arraycomillasAgente)
                                cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                            Next
                            'cadenaWhereConsulta += " AND vn.IdCadena IN (SELECT IdCadena FROM CadenasMarcasAgentes cma WHERE cma.IdAgente IN (" + cadenaAgenteWhere + "))"
                        End If

                    End If
                Else
                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        '' ''If whereConstruido.Length > 0 Then
                        '' ''    whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        '' ''Else
                        '' ''    whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        '' ''End If

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                        Else
                            whereConstruido += " AND (vt.idCatVendedor IN (" + cadenaAgenteWhere + ")"
                        End If
                    End If
                End If


                If Len(clasificacion) > 0 Then
                    Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                    cadenaClasificacionWhere = "'0'"
                    arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                    For iClas = 0 To UBound(arraycomillasClasificacion)
                        cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                    Else
                        whereConstruido += " AND (c.Clasificacion IN (" + cadenaClasificacionWhere + ")"
                    End If
                End If

                If Len(clientes) > 0 Then
                    Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                    cadenaClienteWhere = "'0'"
                    arraycomillasClientes = Strings.Split(clientes, ",")
                    For iCli = 0 To UBound(arraycomillasClientes)
                        cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                    Else
                        whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                    End If

                End If

                If Len(colecciones) > 0 Then
                    Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                    cadenaColeccionWhere = "'0'"
                    arraycomillasColecciones = Strings.Split(colecciones, ",")
                    For iCol = 0 To UBound(arraycomillasColecciones)
                        cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(ve.Coleccion,',','') IN (" + cadenaColeccionWhere + ")"
                    End If

                End If

                If Len(marcas) > 0 Then
                    Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                    cadenaMarcaWhere = "'0'"
                    arraycomillasMarca = Strings.Split(marcas, ",")
                    For iMar = 0 To UBound(arraycomillasMarca)
                        cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.marca IN (" + cadenaMarcaWhere + ")"
                    Else
                        whereConstruido += " AND (ve.marca IN (" + cadenaMarcaWhere + ")"
                    End If
                End If

                If Len(modelos) > 0 Then
                    Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                    cadenaModeloWhere = "'0'"
                    arraycomillasModelo = Strings.Split(modelos, ",")
                    For idmod = 0 To UBound(arraycomillasModelo)
                        cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') IN (" + cadenaModeloWhere + ")"
                    End If
                End If

                If Len(descripcion) > 0 Then
                    Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                    cadenaDescripcionWhere = "'0'"
                    arraycomillasDescripcion = Strings.Split(descripcion, ",")
                    For iDesc = 0 To UBound(arraycomillasDescripcion)
                        cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                    Else
                        whereConstruido += " AND ( ve.IdCodigo IN (" + cadenaDescripcionWhere + ")"
                    End If
                End If

                If Len(Color) > 0 Then
                    Dim arraycomillasColor() As String, cadenaColorWhere As String
                    cadenaColorWhere = "'0'"
                    arraycomillasColor = Strings.Split(Color, ",")
                    For iColor = 0 To UBound(arraycomillasColor)
                        cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ve.Color IN (" + cadenaColorWhere + ")"
                    Else
                        whereConstruido += " AND (ve.Color IN (" + cadenaColorWhere + ")"
                    End If
                End If

                Dim arrayFilas() As String
                arrayFilas = Strings.Split(filas, ",")

                Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
                For contFila = 0 To UBound(arrayFilas)
                    If arrayFilas(contFila) = "optClasificacion" Then
                        filaClasificacion = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.Clasificacion AS CLASIFICACION"
                        Else
                            cadenaSelect += ", c.Clasificacion AS CLASIFICACION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.Clasificacion"
                        Else
                            cadenaGroupBy += ", c.Clasificacion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLASIFICACION"
                        Else
                            orderByConsulta += ", CLASIFICACION"
                        End If

                    ElseIf arrayFilas(contFila) = "optCliente" Then
                        filaCliente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.nombre AS CLIENTE"
                        Else
                            cadenaSelect += ", c.nombre AS CLIENTE"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.nombre"
                        Else
                            cadenaGroupBy += ", c.nombre"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLIENTE"
                        Else
                            orderByConsulta += ", CLIENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optAgente" Then
                        filaAgente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " a.Nombre as AGENTE "
                        Else
                            cadenaSelect += ", a.Nombre as AGENTE "
                        End If

                        cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " a.Nombre "
                        Else
                            cadenaGroupBy += ", a.Nombre "
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by AGENTE"
                        Else
                            orderByConsulta += ", AGENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optMarca" Then
                        filaMarca = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.marca AS MARCA"
                        Else
                            cadenaSelect += ", ve.marca AS MARCA"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.marca"
                        Else
                            cadenaGroupBy += ", ve.marca"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MARCA"
                        Else
                            orderByConsulta += ", MARCA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCategoria" Then
                        filaCategoria = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " tica_descripcion as 'NAVE DESARROLLA'"
                        Else
                            cadenaSelect += ", tica_descripcion as 'NAVE DESARROLLA'"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " tica_descripcion"
                        Else
                            cadenaGroupBy += ", tica_descripcion"
                        End If

                        If Len(categoria) > 0 Then
                            Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                            cadenaCategoriaWhere = "'0'"
                            arraycomillasCategoria = Strings.Split(categoria, ",")
                            For idmod = 0 To UBound(arraycomillasCategoria)
                                cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                            Else
                                whereConstruido += " AND (tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by 'NAVE DESARROLLA'"
                        Else
                            orderByConsulta += ", 'NAVE DESARROLLA'"
                        End If

                    ElseIf arrayFilas(contFila) = "optColeccion" Then
                        filaColeccion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.marca+' '+ve.Coleccion AS COLECCION"
                        Else
                            cadenaSelect += ",ve.marca+' '+ve.Coleccion AS COLECCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += "ve.marca, ve.Coleccion"
                        Else
                            cadenaGroupBy += ", ve.marca, ve.Coleccion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLECCION"
                        Else
                            orderByConsulta += ", COLECCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optModelo" Then
                        filaModelo = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS MODELO"
                        Else
                            cadenaSelect += ",REPLACE(ve.Marca + ' ' + ve.IdModelo, ',', '') AS MODELO"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Marca, ve.IdModelo"
                        Else
                            cadenaGroupBy += ", ve.Marca, ve.IdModelo"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MODELO"
                        Else
                            orderByConsulta += ", MODELO"
                        End If

                    ElseIf arrayFilas(contFila) = "optDescripcion" Then
                        filaDescripcion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.Descripcion AS DESCRIPCION"
                        Else
                            cadenaSelect += ", ve.Descripcion AS DESCRIPCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Descripcion"
                        Else
                            cadenaGroupBy += ", ve.Descripcion"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by DESCRIPCION"
                        Else
                            orderByConsulta += ", DESCRIPCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optFamilia" Then
                        filaFamilia = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " fami_descripcion AS FAMILIA"
                        Else
                            cadenaSelect += ", fami_descripcion AS FAMILIA"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " fami_descripcion"
                        Else
                            cadenaGroupBy += ", fami_descripcion"
                        End If

                        If Len(familias) > 0 Then
                            Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                            cadenaFamiliaWhere = "'0'"
                            arraycomillasFamilia = Strings.Split(familias, ",")
                            For idFam = 0 To UBound(arraycomillasFamilia)
                                cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                            Else
                                whereConstruido += " AND (fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by FAMILIA"
                        Else
                            orderByConsulta += ", FAMILIA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCorrida" Then
                        filaCorrida = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " t.Talla AS CORRIDA"
                        Else
                            cadenaSelect += ", t.Talla AS CORRIDA"
                        End If
                        cadenaConsulta += " INNER JOIN Tallas t ON vt.IdTalla = t.IdTalla"
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " t.Talla"
                        Else
                            cadenaGroupBy += ", t.Talla"
                        End If

                        If Len(corrida) > 0 Then
                            Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                            cadenaCorridaWhere = "'0'"
                            arraycomillasCorrida = Strings.Split(corrida, ",")
                            For iCor = 0 To UBound(arraycomillasCorrida)
                                cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                            Else
                                whereConstruido += " AND (t.Talla IN (" + cadenaCorridaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CORRIDA"
                        Else
                            orderByConsulta += ", CORRIDA"
                        End If

                    ElseIf arrayFilas(contFila) = "optColor" Then
                        filaColor = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ve.Color AS COLOR"
                        Else
                            cadenaSelect += ", ve.Color AS COLOR"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ve.Color"
                        Else
                            cadenaGroupBy += ", ve.Color"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLOR"
                        Else
                            orderByConsulta += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFila) = "optRuta" Then
                        filaRuta = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " r.Ruta AS RUTA"
                        Else
                            cadenaSelect += ", r.Ruta AS RUTA"
                        End If
                        cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " r.Ruta"
                        Else
                            cadenaGroupBy += ", r.Ruta"
                        End If

                        If Len(Ruta) > 0 Then
                            Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                            cadenaRutaWhere = "'0'"
                            arraycomillasRuta = Strings.Split(Ruta, ",")
                            For iRuta = 0 To UBound(arraycomillasRuta)
                                cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                            Else
                                whereConstruido += " AND (r.IdRuta IN (" + cadenaRutaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by RUTA"
                        Else
                            orderByConsulta += ", RUTA"
                        End If
                    End If
                Next contFila

                If cadenaGroupBy = "" Then
                    cadenaGroupBy += " evs.evse_semana "
                Else
                    cadenaGroupBy += ", evs.evse_semana "
                End If

                If Len(categoria) > 0 And filaCategoria = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                    cadenaCategoriaWhere = "'0'"
                    arraycomillasCategoria = Strings.Split(categoria, ",")
                    For idmod = 0 To UBound(arraycomillasCategoria)
                        cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                    Else
                        whereConstruido += " AND (tica_descripcion IN (" + cadenaCategoriaWhere + ")"
                    End If

                End If

                If Len(familias) > 0 And filaFamilia = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                    cadenaFamiliaWhere = "'0'"
                    arraycomillasFamilia = Strings.Split(familias, ",")
                    For idFam = 0 To UBound(arraycomillasFamilia)
                        cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                    Else
                        whereConstruido += " AND (fami_descripcion IN (" + cadenaFamiliaWhere + ")"
                    End If
                End If


                If Len(corrida) > 0 And filaCorrida = False Then
                    cadenaConsulta += " INNER JOIN Tallas t ON vt.IdTalla = t.IdTalla"

                    Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                    cadenaCorridaWhere = "'0'"
                    arraycomillasCorrida = Strings.Split(corrida, ",")
                    For iCor = 0 To UBound(arraycomillasCorrida)
                        cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " t.Talla IN (" + cadenaCorridaWhere + ")"
                    Else
                        whereConstruido += " AND (t.Talla IN (" + cadenaCorridaWhere + ")"
                    End If
                End If

                If Len(Ruta) > 0 And filaRuta = False Then
                    cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                    cadenaRutaWhere = "'0'"
                    arraycomillasRuta = Strings.Split(Ruta, ",")
                    For iRuta = 0 To UBound(arraycomillasRuta)
                        cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " r.IdRuta IN (" + cadenaRutaWhere + ")"
                    Else
                        whereConstruido += " AND (r.IdRuta IN (" + cadenaRutaWhere + ")"
                    End If
                End If

                If opSuma = True Then
                    cadenaSelectOperacion += ", SUM(vt.Cantidad) AS PARES"
                End If
                If opColecciones = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES"
                End If
                If opArticulos = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT ve.IdCodigo+vt.IdTalla) AS ARTICULOS"
                    ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
                End If



                If whereConstruido.Length > 0 Then
                    cadenaWhereConsulta += whereConstruido + ")"
                End If

                If tipoReporte = "anual" Then
                    Dim anioIncremento As Int32 = anioInicio
                    Dim cadenaCamposPvt As String = ""
                    Dim cadenaCamposPvtCad As String = ""
                    For contCol As Int32 = 0 To diferenciaAnios
                        cadenaCamposPvt += "[" + anioIncremento.ToString + "],"
                        anioIncremento = anioIncremento + 1
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)"

                    'MsgBox(cadenaFinal)
                    cadenaCamposPvtCad = cadenaCamposPvt.Substring(0, cadenaCamposPvt.Length - 1)

                    Dim ListaParametros As New List(Of SqlClient.SqlParameter)

                    Dim ParametroParaLista As New SqlParameter
                    ParametroParaLista.ParameterName = "@cadenaSelect"
                    ParametroParaLista.Value = cadenaFinal
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@aniosPivot"
                    ParametroParaLista.Value = cadenaCamposPvtCad
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@operacion"
                    ParametroParaLista.Value = cadenaOperacion
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@orden"
                    ParametroParaLista.Value = orderByConsulta
                    ListaParametros.Add(ParametroParaLista)
                    dtDatosConsultaReporte = operConsultas.EjecutarConsultaSP("Programacion.SP_ConsultaReporteFechas", ListaParametros)

                    If opArticulos = True Or opColecciones = True Then
                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta)" + " ORDER BY ANIO"
                            dtTotalFinaARTCOL = operConsultas.EjecutaConsulta("SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta)
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta)" + " ORDER BY ANIO"
                            dtTotalFinaARTCOL = operConsultas.EjecutaConsulta("SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta)
                        End If
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        Dim cadenaConsultaTotalArtCol As String = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(cadenaConsultaTotalArtCol)
                    End If

                ElseIf tipoReporte = "mensual" Then
                    Dim aniosMeses As String = ""
                    Dim anioMesCont As Int32 = anioInicio
                    Dim mesContAnio As Int32 = 1

                    Dim dtDatosTotalesFechas As New DataTable
                    Dim anioIncrementa As Int32 = anioInicio
                    Dim mesesRep As Int32 = ((diferenciaAnios + 1) * 12)
                    'SE GENERA UNA TABLA CON 13 COLUMNAS VACIAS 
                    For contCols As Int32 = 0 To ((tamanoCamposFilas + mesesRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next
                    'EN UN ARREGLO(aniosMeses) GUARDAMOS EL AÑO Y EL MES EJEM: [20211][20212]
                    For contCols As Int32 = 1 To mesesRep
                        aniosMeses += "[" + anioMesCont.ToString + mesContAnio.ToString + "],"
                        If contCols Mod 12 = 0 = True Then
                            anioMesCont += 1
                            mesContAnio = 0
                        End If
                        mesContAnio += 1
                    Next
                    aniosMeses = aniosMeses.Substring(0, aniosMeses.Length - 1)

                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)

                    'For Each rowCol As DataRow In dtColumnasGeneral.Rows Comentado 06/05/2016
                    '    Dim dtRowColumnas As DataRow = dtDatosConsultaReporte.NewRow Comentado 06/05/2016
                    '    For cntFC As Int32 = 0 To tamanoCamposFilas - 1 Comentado 06/05/2016
                    '        dtRowColumnas.Item(cntFC) = rowCol.Item(cntFC) Comentado 06/05/2016
                    '    Next Comentado 06/05/2016
                    '    dtDatosConsultaReporte.Rows.Add(dtRowColumnas) Comentado 06/05/2016
                    'Next Comentado 06/05/2016

                    'For colDTtitulos As Int32 = 0 To tamanoCamposFilas - 1 Comentado 06/05/2016
                    '    dtDatosConsultaReporte.Rows(1).Item(colDTtitulos) = dtColumnasGeneral.Columns(colDTtitulos).ColumnName.ToString Comentado 06/05/2016
                    'Next Comentado 06/05/2016

                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(MONTH, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO, MES"
                    Dim cadenaGroupBySinSemana = Replace(cadenaGroupBy, ", evs.evse_semana", "")
                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", CAST(DATEPART(YEAR, vn.FechaVenta) AS varchar(4)) + CAST(DATEPART(MONTH, vn.FechaVenta) AS varchar(2)) AS ANIOMES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(MONTH, vn.FechaVenta)"

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", CAST(DATEPART(YEAR, vn.FechaVenta) AS varchar(4)) + CAST(DATEPART(MONTH, vn.FechaVenta) AS varchar(2)) AS ANIOMES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBySinSemana + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(MONTH, vn.FechaVenta)"


                    If opSuma = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(PARES) FOR ANIOMES IN (" + aniosMeses + ")) AS pvotCLASSUM"
                    ElseIf opArticulos = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(ARTICULOS) FOR ANIOMES IN (" + aniosMeses + ")) AS pvotCLASArt"
                    ElseIf opColecciones = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(COLECCIONES) FOR ANIOMES IN (" + aniosMeses + ")) AS pvotCLASCol"
                    End If
                    ''TENEMOS LA TABLA CLEINTE MES1-MES2-MES3 HASTA MES12 EN CADA MES SE ENCUENTRA LA CANTIDAD DE COLECCIONES QUE COMPRO EL CLIENTE 
                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)


                    If opArticulos = True Or opColecciones = True Then
                        Dim cadenadtTotalFinaARTCOL As String = ""
                        Dim cadenadtTotalesSubtotalesFechas As String = ""
                        'cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4)) AS ANIO" + cadenaConsulta + cadenaWhereConsulta + " Group by " + cadenaGroupBy + ",CAST(evse_año AS VARCHAR(4))" + " " + orderByConsulta + ", ANIO"
                        'ESTA CONSULTA NOS TRAE LAS COLECCIONES QUE SE VENDIERON EN TODO EL AÑO SIN REPETIRSE POR CLIENTE 

                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4)) AS ANIO" + cadenaConsulta + cadenaWhereConsulta + " Group by " + cadenaGroupBySinSemana + ",CAST(evse_año AS VARCHAR(4))" + " " + orderByConsulta + ", ANIO"

                        'ESTA CONSULTA NOS TRAE  TOTAL DE COLECCIIONES POR MES POR CLIENTE 
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + " Group by " + cadenaGroupBy + " " + orderByConsulta

                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO,  DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta),  DATEPART(MONTH, vn.FechaVenta)" + " ORDER BY ANIO, MES"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by DATEPART(YEAR, vn.FechaVenta)"
                        ElseIf opColecciones = True Then
                            'NOS TRAEMOS EL TOTAL DE TODAS LAS COLECCIONES POR  MES SIN REPETIRSE QUE SE VENDIERON   
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES ,DATEPART(YEAR, vn.FechaVenta) AS ANIO,  DATEPART(MONTH, vn.FechaVenta) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta),  DATEPART(MONTH, vn.FechaVenta)" + " ORDER BY ANIO, MES"
                            ''NOS TRAEMOS EL TOTAL DE COLECCIONES QUE SE VENDIERON POR AÑO SIN REPETIRSE 
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta
                            ''NOS TRAEMOS EL TOTAL DE COLECCIONES QUE SE VENDIERON POR AÑO SIN REPETIRSE PERO CON LA COLUMNA AÑO
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by DATEPART(YEAR, vn.FechaVenta)"
                        End If

                        dtTotalFinaARTCOL = operConsultas.EjecutaConsulta(cadenadtTotalFinaARTCOL)
                        dtTotalesSubtotalesFechas = operConsultas.EjecutaConsulta(cadenadtTotalesSubtotalesFechas)


                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)

                    End If

                    dtDatosConsultaReporte = New DataTable
                    For Each colRow As DataColumn In dtDatosTotalesFechas.Columns
                        dtDatosConsultaReporte.Columns.Add(colRow.Caption)
                    Next

                    Dim drowDos As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            drowDos.Item(col) = col.Caption.ToString
                        Else
                            If col.Caption.Substring(4, col.Caption.Length - 4) = "1" Then
                                drowDos.Item(col) = "ENERO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "2" Then
                                drowDos.Item(col) = "FEBRERO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "3" Then
                                drowDos.Item(col) = "MARZO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "4" Then
                                drowDos.Item(col) = "ABRIL"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "5" Then
                                drowDos.Item(col) = "MAYO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "6" Then
                                drowDos.Item(col) = "JUNIO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "7" Then
                                drowDos.Item(col) = "JULIO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "8" Then
                                drowDos.Item(col) = "AGOSTO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "9" Then
                                drowDos.Item(col) = "SEPTIEMBRE"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "10" Then
                                drowDos.Item(col) = "OCTUBRE"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "11" Then
                                drowDos.Item(col) = "NOVIEMBRE"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "12" Then
                                drowDos.Item(col) = "DICIEMBRE"
                            End If
                        End If

                    Next

                    dtDatosConsultaReporte.Rows.InsertAt(drowDos, 0)

                    Dim drowUno As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            'drowUno.Item(col) = col.Caption.ToString
                        Else
                            drowUno.Item(col) = col.Caption.Substring(0, 4)
                        End If

                    Next
                    dtDatosConsultaReporte.Rows.InsertAt(drowUno, 0)

                    For Each rowDt As DataRow In dtDatosTotalesFechas.Rows
                        dtDatosConsultaReporte.ImportRow(rowDt)
                    Next

                    'aqui es por semana
                ElseIf tipoReporte = "semanal" Then
                    Dim dtDatosTotalesFechas As New DataTable
                    Dim anioIncrementa As Int32 = anioInicio
                    Dim semanasRep As Int32 = ((diferenciaAnios + 1) * 52)

                    Dim aniosSemenas As String = ""
                    Dim aniosSemenasCont As Int32 = anioInicio
                    Dim semanaContAnio As Int32 = 1

                    For contCols As Int32 = 1 To semanasRep
                        aniosSemenas += "[" + aniosSemenasCont.ToString + semanaContAnio.ToString + "],"
                        If contCols Mod 52 = 0 = True Then
                            aniosSemenasCont += 1
                            semanaContAnio = 0
                        End If
                        semanaContAnio += 1
                    Next

                    aniosSemenas = aniosSemenas.Substring(0, aniosSemenas.Length - 1)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + semanasRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next


                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    ' ''Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)
                    Dim cadenadtTotalFinaARTCOL As String = ""
                    Dim cadenadtTotalesSubtotalesFechas As String = ""

                    If opArticulos = True Or opColecciones = True Then
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta)" + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                        If opArticulos = True Then

                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " ORDER BY ANIO, SEMANA"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT ve.IdCodigo + vt.IdTalla) AS ARTICULOS , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by DATEPART(YEAR, vn.FechaVenta)"

                        ElseIf opColecciones = True Then

                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO, DATEPART(WEEK, vn.FechaVenta) AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)" + " ORDER BY ANIO, SEMANA"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT ve.Marca+' '+ ve.Coleccion) AS COLECCIONES , DATEPART(YEAR, vn.FechaVenta) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by DATEPART(YEAR, vn.FechaVenta)"

                        End If

                        dtTotalFinaARTCOL = operConsultas.EjecutaConsulta(cadenadtTotalFinaARTCOL)
                        dtTotalesSubtotalesFechas = operConsultas.EjecutaConsulta(cadenadtTotalesSubtotalesFechas)

                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)
                    End If
                    'aquí va el cambio
                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", ANIOSEMANA= CASE DATEPART(YEAR,vn.FechaVenta) WHEN 2017 THEN CAST(DATEPART(YEAR, vn.FechaVenta) AS varchar(4)) + CAST((DATEPART(WEEK,vn.FechaVenta)-1) AS varchar(2)) ELSE CAST(DATEPART(YEAR, vn.FechaVenta) AS varchar(4)) + CAST(DATEPART(WEEK,vn.FechaVenta) AS varchar(2)) END " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)"

                    'If (Now.Year = 2021) Then
                    'End If
                    ''''SE COMENTARA EL 08/03/2021 PARA AGREGAR JOIN DESDE LA CONSULTA INICIAL Y QUE TOME LAS SEMANAS DE LA TABLA Ventas.EstadVentas_Semana QUE LAS TRAER POR DEFECTO
                    ''''Y NO LAS TENGA QUE CALCULAR PORQUE COMO VENTAS SACA SUS PROPIAS SEMANAS ESTÉ SCRIPT TIENE SUS INCONVENIENTES EN CIERTAS PARTES
                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", ANIOSEMANA= CASE DATEPART(YEAR,vn.FechaVenta) WHEN 2021 THEN CAST(DATEPART(YEAR, vn.FechaVenta) AS varchar(4)) + CAST((DATEPART(WEEK,vn.FechaVenta)-1) AS varchar(2)) ELSE CAST(DATEPART(YEAR, vn.FechaVenta) AS varchar(4)) + CAST(DATEPART(WEEK,vn.FechaVenta) AS varchar(2)) END " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)"

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", ANIOSEMANA = (CAST(DATEPART(YEAR, vn.FechaVenta) AS VARCHAR(4)) + CAST(evs.evse_semana AS VARCHAR(2))) " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", DATEPART(YEAR, vn.FechaVenta), DATEPART(WEEK, vn.FechaVenta)"


                    If opSuma = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(PARES) FOR ANIOSEMANA IN (" + aniosSemenas + ")) AS pvotCLASSUM"
                    ElseIf opArticulos = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(ARTICULOS) FOR ANIOSEMANA IN (" + aniosSemenas + ")) AS pvotCLASArt"
                    ElseIf opColecciones = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(COLECCIONES) FOR ANIOSEMANA IN (" + aniosSemenas + ")) AS pvotCLASCol"
                    End If

                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)

                    'se agregan los nombres de columnas al datatable
                    dtDatosConsultaReporte = New DataTable
                    For Each colRow As DataColumn In dtDatosTotalesFechas.Columns
                        dtDatosConsultaReporte.Columns.Add(colRow.Caption)
                    Next

                    Dim drowDos As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            drowDos.Item(col) = col.Caption.ToString
                        Else
                            drowDos.Item(col) = col.Caption.Substring(4, col.Caption.Length - 4)
                        End If

                    Next
                    dtDatosConsultaReporte.Rows.InsertAt(drowDos, 0)

                    Dim drowUno As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            'drowUno.Item(col) = col.Caption.ToString
                        Else
                            drowUno.Item(col) = col.Caption.Substring(0, 4)
                        End If

                    Next
                    dtDatosConsultaReporte.Rows.InsertAt(drowUno, 0)

                    For Each rowDt As DataRow In dtDatosTotalesFechas.Rows
                        dtDatosConsultaReporte.ImportRow(rowDt)
                    Next
                End If

                Dim validarContenido As Boolean = True

                If tipoReporte = "anual" Then
                    If dtDatosConsultaReporte.Rows.Count > 0 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                Else
                    If dtDatosConsultaReporte.Rows.Count > 2 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                End If


                If validarContenido = True Then
                    Dim mesUno As Int32 = Month(fechaUno)
                    Dim mesDos As Int32 = Month(fechaDos)
                    Dim anioUno As Int32 = Year(fechaUno)
                    Dim anioDos As Int32 = Year(fechaDos)
                    Dim semanaUno As String
                    Dim semanaDos As String

                    'se obtiene el año
                    'el sistema y la bd toman como 1er día de la semana a lunes y como 2017 (1/01/2017) fue domingo (para el sistema y bd esa es la primera semana del año se resta aquí semana para poder crear los reportes de forma correcta)
                    If anioUno < 2017 Then
                        semanaUno = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
                        ' a la última semana se le dice que se resté una porque la bd cuenta la semana de diferente forma
                        If fechaDos.ToString = "01/01/2017" Then
                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
                        ElseIf fechaDos.ToString > "01/01/2017" Then
                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)
                        End If

                    ElseIf anioUno = 2017 Then

                        If fechaUno = "01/01/2017" Then
                            semanaUno = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))

                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)

                        Else

                            semanaUno = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)
                            ' a la última semana se le dice que se resté una porque la bd cuenta la semana de diferente forma
                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)
                        End If

                    Else
                        semanaUno = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                        semanaDos = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                    End If

                    If semanaUno > 52 Then
                        semanaUno = 52
                    End If
                    If semanaDos > 52 Then
                        semanaDos = 52
                    End If

                    If tipoReporte = "semanal" Then

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If IsNumeric(dtDatosConsultaReporte.Rows(1).Item(contCol)) = True Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> semanaUno.ToString Then
                                    dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                    contCol = 0
                                Else
                                    Exit For
                                End If
                            End If
                        Next
                        'PRIMERA PARTE SUBTOTAL

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas - 1 Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "52" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next


                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> semanaDos.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next

                        If opSuma = True Then
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next
                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        ElseIf opArticulos = True Or opColecciones = True Then
                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")
                            If opArticulos = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("ARTICULOS").ToString
                                    contFilaTotal += 1
                                Next
                            ElseIf opColecciones = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contCol As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contCol).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                    contFilaTotal += 1
                                Next
                            End If
                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = rowDt.Item("SEMANA").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If

                                Next
                            Next

                            filaResultados.Item("TOTAL") = dtTotalFinaARTCOL.Rows(0).Item(0).ToString

                            Dim contAnio As Int32 = 0
                            For colDT As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                If filaResultados.Item(colDT).ToString = "" And dtDatosConsultaReporte.Rows(0).Item(colDT).ToString = "" Then
                                    filaResultados.Item(colDT) = dtTotalesSubtotalesFechas.Rows(contAnio).Item(0)
                                    contAnio += 1
                                End If
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If
                    End If

                    If tipoReporte = "mensual" Then
                        Dim mesUnoCadena As String = ""
                        If mesUno = 1 Then
                            mesUnoCadena = "ENERO"
                        ElseIf mesUno = 2 Then
                            mesUnoCadena = "FEBRERO"
                        ElseIf mesUno = 3 Then
                            mesUnoCadena = "MARZO"
                        ElseIf mesUno = 4 Then
                            mesUnoCadena = "ABRIL"
                        ElseIf mesUno = 5 Then
                            mesUnoCadena = "MAYO"
                        ElseIf mesUno = 6 Then
                            mesUnoCadena = "JUNIO"
                        ElseIf mesUno = 7 Then
                            mesUnoCadena = "JULIO"
                        ElseIf mesUno = 8 Then
                            mesUnoCadena = "AGOSTO"
                        ElseIf mesUno = 9 Then
                            mesUnoCadena = "SEPTIEMBRE"
                        ElseIf mesUno = 10 Then
                            mesUnoCadena = "OCTUBRE"
                        ElseIf mesUno = 11 Then
                            mesUnoCadena = "NOVIEMBRE"
                        ElseIf mesUno = 12 Then
                            mesUnoCadena = "DICIEMBRE"
                        End If

                        Dim mesDosCadena As String = ""
                        If mesDos = 1 Then
                            mesDosCadena = "ENERO"
                        ElseIf mesDos = 2 Then
                            mesDosCadena = "FEBRERO"
                        ElseIf mesDos = 3 Then
                            mesDosCadena = "MARZO"
                        ElseIf mesDos = 4 Then
                            mesDosCadena = "ABRIL"
                        ElseIf mesDos = 5 Then
                            mesDosCadena = "MAYO"
                        ElseIf mesDos = 6 Then
                            mesDosCadena = "JUNIO"
                        ElseIf mesDos = 7 Then
                            mesDosCadena = "JULIO"
                        ElseIf mesDos = 8 Then
                            mesDosCadena = "AGOSTO"
                        ElseIf mesDos = 9 Then
                            mesDosCadena = "SEPTIEMBRE"
                        ElseIf mesDos = 10 Then
                            mesDosCadena = "OCTUBRE"
                        ElseIf mesDos = 11 Then
                            mesDosCadena = "NOVIEMBRE"
                        ElseIf mesDos = 12 Then
                            mesDosCadena = "DICIEMBRE"
                        End If

                        For contCol As Int32 = tamanoCamposFilas To 12
                            contCol = tamanoCamposFilas
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> mesUnoCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(tamanoCamposFilas).ColumnName.ToString)
                            Else
                                Exit For
                            End If
                        Next

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "DICIEMBRE" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next
                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> mesDosCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next
                        If opSuma = True Then
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        ElseIf opArticulos = True Or opColecciones = True Then

                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")


                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            If opArticulos = True Then

                                'Dim contFilaTotal As Int32 = 0
                                Dim inserta As Boolean = True
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1

                                    For rowdt As Int32 = 0 To dtTotalCadArtColTOTAL.Rows.Count - 1
                                        For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                            If dtDatosConsultaReporte.Rows(contArt).Item(itemDt).ToString <> dtTotalCadArtColTOTAL.Rows(rowdt).Item(itemDt).ToString Then
                                                inserta = False
                                            End If
                                        Next
                                        If inserta = True Then
                                            dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(rowdt).Item("ARTICULOS").ToString
                                            Dim dtRowDelete As DataRow = dtTotalCadArtColTOTAL.Rows(rowdt)
                                            dtTotalCadArtColTOTAL.Rows.Remove(dtRowDelete)
                                            inserta = True
                                            Exit For
                                        Else
                                            inserta = True
                                        End If
                                    Next

                                Next

                            ElseIf opColecciones = True Then

                                Dim contFilaTotal As Int32 = 0
                                Dim inserta As Boolean = True
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    'For Each rowdt As DataRow In dtTotalCadArtColTOTAL.Rows
                                    For Each rowdt As DataRow In dtSubtotalesFechas.Rows
                                        For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                            If dtDatosConsultaReporte.Rows(contArt).Item(itemDt).ToString <> rowdt.Item(itemDt).ToString Then
                                                inserta = False
                                            End If
                                        Next
                                        If inserta = True Then
                                            'dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                            dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtSubtotalesFechas.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                            inserta = True
                                            Exit For
                                        Else
                                            inserta = True
                                        End If
                                    Next
                                    contFilaTotal += 1
                                Next

                                '' ''filaResultados.Item(dtDatosConsultaReporte.Rows.Count - 2) = contFilaTotal


                            End If

                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    Dim textoMes As String = ""
                                    If rowDt.Item("MES").ToString = "1" Then
                                        textoMes = "ENERO"
                                    ElseIf rowDt.Item("MES").ToString = "2" Then
                                        textoMes = "FEBRERO"
                                    ElseIf rowDt.Item("MES").ToString = "3" Then
                                        textoMes = "MARZO"
                                    ElseIf rowDt.Item("MES").ToString = "4" Then
                                        textoMes = "ABRIL"
                                    ElseIf rowDt.Item("MES").ToString = "5" Then
                                        textoMes = "MAYO"
                                    ElseIf rowDt.Item("MES").ToString = "6" Then
                                        textoMes = "JUNIO"
                                    ElseIf rowDt.Item("MES").ToString = "7" Then
                                        textoMes = "JULIO"
                                    ElseIf rowDt.Item("MES").ToString = "8" Then
                                        textoMes = "AGOSTO"
                                    ElseIf rowDt.Item("MES").ToString = "9" Then
                                        textoMes = "SEPTIEMBRE"
                                    ElseIf rowDt.Item("MES").ToString = "10" Then
                                        textoMes = "OCTUBRE"
                                    ElseIf rowDt.Item("MES").ToString = "11" Then
                                        textoMes = "NOVIEMBRE"
                                    ElseIf rowDt.Item("MES").ToString = "12" Then
                                        textoMes = "DICIEMBRE"
                                    End If
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = textoMes Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next
                            filaResultados.Item("TOTAL") = dtTotalFinaARTCOL.Rows(0).Item(0).ToString
                            ''AQUI TENEMOS LA FILA CON LOS TOTALES POR MES
                            Dim contAnio As Int32 = 0
                            For colDT As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                If filaResultados.Item(colDT).ToString = "" And dtDatosConsultaReporte.Rows(0).Item(colDT).ToString = "" Then
                                    filaResultados.Item(colDT) = dtTotalesSubtotalesFechas.Rows(contAnio).Item(0)
                                    contAnio += 1
                                End If
                            Next

                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        End If
                    End If

                    If tipoReporte = "anual" Then

                        If opSuma = True Then
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        Else
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Columns(coldt).Caption.ToString = rowDt.Item("ANIO").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next



                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If

                    End If
                End If

                If tipoReporte = "anual" Then
                    dtDatosConsultaReporte.Columns.Add("TOTAL")
                    If opSuma = True Then
                        Dim sumaTotal As Int32 = 0
                        For rowTotal As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                            sumaTotal = 0
                            For colTotal As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 2
                                If dtDatosConsultaReporte.Rows(rowTotal).Item(colTotal).ToString <> "" Then
                                    sumaTotal = sumaTotal + dtDatosConsultaReporte.Rows(rowTotal).Item(colTotal)
                                End If
                            Next
                            dtDatosConsultaReporte.Rows(rowTotal).Item("TOTAL") = sumaTotal
                        Next

                    ElseIf opArticulos = True Then
                        Dim inserta As Boolean = True
                        For contArt As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                            For Each rowdt As DataRow In dtTotalCadArtColTOTAL.Rows
                                For i As Int32 = 0 To tamanoCamposFilas - 1
                                    If rowdt.Item(i).ToString <> dtDatosConsultaReporte.Rows(contArt).Item(i).ToString Then
                                        inserta = False
                                    End If
                                Next
                                If inserta = True Then
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = rowdt.Item("ARTICULOS").ToString
                                    Exit For
                                End If
                                inserta = True
                            Next
                        Next
                        dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1).Item(dtDatosConsultaReporte.Columns.Count - 1) = dtTotalFinaARTCOL.Rows(0).Item(0).ToString

                    ElseIf opColecciones = True Then
                        Dim inserta As Boolean = True
                        For contArt As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                            For Each rowdt As DataRow In dtTotalCadArtColTOTAL.Rows
                                For i As Int32 = 0 To tamanoCamposFilas - 1
                                    If rowdt.Item(i).ToString <> dtDatosConsultaReporte.Rows(contArt).Item(i).ToString Then
                                        inserta = False
                                    End If
                                Next
                                If inserta = True Then
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = rowdt.Item("COLECCIONES").ToString
                                    Exit For
                                End If
                                inserta = True
                            Next
                        Next
                        dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1).Item(dtDatosConsultaReporte.Columns.Count - 1) = dtTotalFinaARTCOL.Rows(0).Item(0).ToString
                    End If
                End If

                Dim dtTablaOrdenada As New DataTable
                For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                    If contCol = dtDatosConsultaReporte.Columns.Count - 1 Then
                        dtTablaOrdenada.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption, Type.GetType("System.Int32"))
                    Else
                        dtTablaOrdenada.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption)
                    End If
                Next

                If tipoReporte <> "anual" Then
                    For cont As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 2
                        dtTablaOrdenada.ImportRow(dtDatosConsultaReporte.Rows(cont))
                    Next
                Else
                    For cont As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 2
                        dtTablaOrdenada.ImportRow(dtDatosConsultaReporte.Rows(cont))
                    Next
                End If

                Dim viewDtDatos As New DataView(dtTablaOrdenada)
                viewDtDatos.Sort = dtDatosConsultaReporte.Columns(dtDatosConsultaReporte.Columns.Count - 1).Caption.ToString + " DESC"
                dtTablaOrdenada = New DataTable
                dtTablaOrdenada = viewDtDatos.ToTable

                Dim dtTraspaso As New DataTable
                For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                    dtTraspaso.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption)
                Next

                If tipoReporte <> "anual" Then
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(0))
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(1))
                    For Each rowDt As DataRow In dtTablaOrdenada.Rows
                        dtTraspaso.ImportRow(rowDt)
                    Next
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1))
                Else
                    For Each rowDt As DataRow In dtTablaOrdenada.Rows
                        dtTraspaso.ImportRow(rowDt)
                    Next
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1))
                End If

                dtDatosConsultaReporte = New DataTable
                dtDatosConsultaReporte = dtTraspaso
                dtDatosConsultaReporte.Columns.Add("Index").SetOrdinal(0)
                dtDatosConsultaReporte.Columns("Index").Caption = "#"
                Dim contFilaIndex As Int32 = 1
                For i As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                    If tipoReporte = "anual" Then
                        If i < dtDatosConsultaReporte.Rows.Count - 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    Else
                        If i <= 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = "#"
                        ElseIf i < dtDatosConsultaReporte.Rows.Count - 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    End If
                Next

                Dim ultimaCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1
                Dim ultimaFila As Int32 = dtDatosConsultaReporte.Rows.Count - 1
                Dim TotalVentas As Double = CInt(dtDatosConsultaReporte.Rows(ultimaFila).Item(ultimaCol))
                Dim porcentajeFila As Decimal = 0.0
                dtDatosConsultaReporte.Columns.Add("Porcentaje")
                dtDatosConsultaReporte.Columns("Porcentaje").Caption = "%"
                If tipoReporte = "anual" Then
                    For rowTotal As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                        If dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol).ToString <> "" Then
                            porcentajeFila = (dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                            dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                        End If
                        ' ''dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = (CDbl((dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100)) / TotalVentas)
                    Next

                Else

                    For rowTotal As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                        porcentajeFila = (dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                        dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                        ' ''dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = (CDbl((dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100)) / TotalVentas)
                    Next

                End If

                Dim porcentajeColumna As Decimal = 0.0
                Dim rowPorcent As DataRow
                rowPorcent = dtDatosConsultaReporte.NewRow
                For Each colDtp As DataColumn In dtDatosConsultaReporte.Columns
                    If IsNumeric(dtDatosConsultaReporte.Rows(ultimaFila).Item(colDtp.ColumnName.ToString)) Then
                        porcentajeColumna = (dtDatosConsultaReporte.Rows(ultimaFila).Item(colDtp) * 100) / TotalVentas
                        rowPorcent.Item(colDtp) = porcentajeColumna.ToString("N2") + "%"
                    End If
                Next
                rowPorcent.Item(1) = "%"
                If tipoReporte <> "anual" Then
                    dtDatosConsultaReporte.Rows(1).Item(ultimaCol + 1) = "%"
                End If

                dtDatosConsultaReporte.Rows.Add(rowPorcent)



            End If

        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            'dtErrorCatch.Rows(0).Item(0) = ex.Message
            dtDatosConsultaReporte = dtErrorCatch

        End Try
        Return dtDatosConsultaReporte
    End Function

    Public Function listaNavesDesarrolla() As DataTable
        Dim operConsultas As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim dt As DataTable
        Try
            dt = operConsultas.EjecutarConsultaSP("[Ventas].[SP_EstadisticaVentas_ListaNavesDesarrolla]", ListaParametros)
        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema."
            'dtErrorCatch.Rows(0).Item(0) = ex.Message
            dt = dtErrorCatch
        End Try
        Return dt
    End Function

    Public Function generarConsultaFechas_Agentes_SAY(ByVal filas As String, ByVal tipoReporte As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                      ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                      ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                      ByVal familias As String, ByVal categoria As String, ByVal Ruta As String, ByVal Color As String,
                                      ByVal radioYO As String, ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String,
                                      ByVal ubicacion As String, ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim dtDatosConsultaReporte As New DataTable

        Try
            If filas <> "" Then
                Dim operConsultas As New Persistencia.OperacionesProcedimientosSICY
                Dim opeSAY As New Persistencia.OperacionesProcedimientos
                Dim dtCantidadAnios As DataTable = operConsultas.EjecutaConsulta("SELECT DATEDIFF(YEAR, '" + fechaUno + "', '" + fechaDos + "');")
                Dim diferenciaAnios As Int32 = CInt(dtCantidadAnios.Rows(0).Item(0).ToString)
                Dim filaClasificacion As Boolean = False
                Dim filaCliente As Boolean = False
                Dim filaAgente As Boolean = False
                Dim filaMarca As Boolean = False
                Dim filaCategoria As Boolean = False
                Dim filaColeccion As Boolean = False
                Dim filaModelo As Boolean = False
                Dim filaDescripcion As Boolean = False
                Dim filaFamilia As Boolean = False
                Dim filaCorrida As Boolean = False
                Dim filaRuta As Boolean = False
                Dim filaColor As Boolean = False
                Dim opSuma As Boolean = False
                Dim opArticulos As Boolean = False
                Dim opColecciones As Boolean = False
                Dim anioInicio As Int32 = Year(fechaUno)
                Dim cadenaSelect As String = "SELECT"
                Dim cadenaSelectOperacion As String = ""
                Dim cadenaGroupBy As String = ""
                Dim cadenaWhereConsulta As String = ""
                Dim cadenaInnerVistaCategoriaFamilias As String = ""
                Dim orderByConsulta As String = ""
                Dim cadenaFinal As String = ""
                Dim cadenaFinalColeccionArticulo As String = ""
                Dim cadenaOperacion As String = ""
                Dim cadenaColor As String = ""
                Dim dtSubtotalesFechas As New DataTable
                Dim totalCadenaArticulosColecciones As String = ""
                Dim dtTotalCadenaArticulosColecciones As New DataTable

                Dim totalCadArtColTOTAL As String = ""
                Dim dtTotalCadArtColTOTAL As New DataTable
                Dim dtTotalFinaARTCOL As New DataTable
                Dim dtTotalesSubtotalesFechas As New DataTable

                If operaciones = "optSuma" Then
                    opSuma = True
                    cadenaOperacion = "PARES"
                ElseIf operaciones = "optCantArt" Then
                    opArticulos = True
                    cadenaOperacion = "ARTICULOS"
                ElseIf operaciones = "optCantCole" Then
                    opColecciones = True
                    cadenaOperacion = "COLECCIONES"
                End If

                Dim cadenaConsulta As String = " FROM Ventas.EstadVentas_PedidoPartida_Facturado factura " +
                                        "inner join Programacion.vProductoEstilos_Todos prod On prod.ProductoEstiloId = factura.evpf_productoestiloid " +
                                        "inner join Cadenas c on c.IdCadena = factura.evpf_idcadena " +
                                        "inner join Ventas.EstadVentas_Semana evs on evs.evse_fecha = factura.evpf_fechafactura  " +
                                        "inner join Cliente.Cliente cl on cl.clie_idsicy = c.IdCadena " +
                                        "LEFT join [" + opeSAY.Servidor + "]." + opeSAY.NombreDB + ".Nomina.VW_Colaboradores cb on cb.codr_colaboradorid = factura.evpf_idagentesay " +
                                        "left join [" + opeSAY.Servidor + "]." + opeSAY.NombreDB + ".Ventas.Rutas rt on rt.ruta_rutaid= cl.clie_rutaid " +
                                        "left join Agentes agt on agt.codr_colaboradorid = cb.codr_colaboradorid " +
                                        "left join [" + opeSAY.Servidor + "]." + opeSAY.NombreDB + ".Cliente.Clasificaciones clf On clf.clas_clasificacioclientenid = cl.clie_clasificacionclienteid "

                If conAgente = True Then
                    If vistaAgente = "MisClientes" Then
                        'cadenaConsulta += " JOIN Ventas.coleccionMarcaFamiliaCadenaAgente cmfa ON vn.IdCadena = cmfa.cmfa_idCadena" &
                        '                " AND (cmfa.cmfa_marcaSicy + cmfa.cmfa_coleccionSicy) = ve.IdLinea AND cmfa_idAgenteSicy IN (" & agentes & ")"
                    End If
                End If

                cadenaWhereConsulta = " WHERE evpf_fechafactura  >= '" + fechaUno + "' AND evpf_fechafactura  <= '" + fechaDos + "'  and isnull(factura.evpf_notacredito_cancelacion,0) = 0 and isnull(factura.evpf_notacredito_refacturacion,0) =0 "
                Dim whereConstruido As String = ""

                If conAgente = True Then
                    If vistaAgente = "MisVentas" Then

                        If Len(agentes) > 0 Then
                            Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                            cadenaAgenteWhere = "'0'"
                            arraycomillasAgente = Strings.Split(agentes, ",")
                            For iAgente = 0 To UBound(arraycomillasAgente)
                                cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                            Next
                            ' ''cadenaWhereConsulta += "AND vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                            cadenaWhereConsulta += " AND agt.IdAgente  IN (" + cadenaAgenteWhere + ")"
                        End If

                    ElseIf vistaAgente = "MisClientes" Then

                        If Len(agentes) > 0 Then
                            Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                            cadenaAgenteWhere = "'0'"
                            arraycomillasAgente = Strings.Split(agentes, ",")
                            For iAgente = 0 To UBound(arraycomillasAgente)
                                cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                            Next
                            cadenaWhereConsulta += " AND c.IdCadena IN (SELECT IdCadena FROM CadenasMarcasAgentes cma WHERE cma.IdAgente IN (" + cadenaAgenteWhere + "))"
                        End If

                    End If
                Else
                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        '' ''If whereConstruido.Length > 0 Then
                        '' ''    whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        '' ''Else
                        '' ''    whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        '' ''End If

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " agt.IdAgente  IN (" + cadenaAgenteWhere + ")"
                        Else
                            whereConstruido += " AND (agt.IdAgente  IN (" + cadenaAgenteWhere + ")"
                        End If
                    End If
                End If


                If Len(clasificacion) > 0 Then
                    Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                    cadenaClasificacionWhere = "'0'"
                    arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                    For iClas = 0 To UBound(arraycomillasClasificacion)
                        cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " clf.clas_clasificacioclientenid IN (" + cadenaClasificacionWhere + ")"
                    Else
                        whereConstruido += " AND (clf.clas_clasificacioclientenid IN (" + cadenaClasificacionWhere + ")"
                    End If
                End If

                If Len(clientes) > 0 Then
                    Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                    cadenaClienteWhere = "'0'"
                    arraycomillasClientes = Strings.Split(clientes, ",")
                    For iCli = 0 To UBound(arraycomillasClientes)
                        cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                    Else
                        whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                    End If

                End If

                If Len(colecciones) > 0 Then
                    Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                    cadenaColeccionWhere = "'0'"
                    arraycomillasColecciones = Strings.Split(colecciones, ",")
                    For iCol = 0 To UBound(arraycomillasColecciones)
                        cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(prod.ColeccionSAY,',','') IN (" + cadenaColeccionWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(prod.ColeccionSAY,',','') IN (" + cadenaColeccionWhere + ")"
                    End If

                End If

                If Len(marcas) > 0 Then
                    Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                    cadenaMarcaWhere = "'0'"
                    arraycomillasMarca = Strings.Split(marcas, ",")
                    For iMar = 0 To UBound(arraycomillasMarca)
                        cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " prod.MarcaSAY IN (" + cadenaMarcaWhere + ")"
                    Else
                        whereConstruido += " AND (prod.MarcaSAY IN (" + cadenaMarcaWhere + ")"
                    End If
                End If

                If Len(modelos) > 0 Then
                    Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                    cadenaModeloWhere = "'0'"
                    arraycomillasModelo = Strings.Split(modelos, ",")
                    For idmod = 0 To UBound(arraycomillasModelo)
                        cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') IN (" + cadenaModeloWhere + ")"
                    Else
                        whereConstruido += " AND (REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') IN (" + cadenaModeloWhere + ")"
                    End If
                End If

                If Len(descripcion) > 0 Then
                    Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                    cadenaDescripcionWhere = "'0'"
                    arraycomillasDescripcion = Strings.Split(descripcion, ",")
                    For iDesc = 0 To UBound(arraycomillasDescripcion)
                        cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " prod.CodigoSicy IN (" + cadenaDescripcionWhere + ")"
                    Else
                        whereConstruido += " AND ( prod.CodigoSicy IN (" + cadenaDescripcionWhere + ")"
                    End If
                End If

                If Len(Color) > 0 Then
                    Dim arraycomillasColor() As String, cadenaColorWhere As String
                    cadenaColorWhere = "'0'"
                    arraycomillasColor = Strings.Split(Color, ",")
                    For iColor = 0 To UBound(arraycomillasColor)
                        cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " prod.PielColor IN (" + cadenaColorWhere + ")"
                    Else
                        whereConstruido += " AND (prod.PielColor IN (" + cadenaColorWhere + ")"
                    End If
                End If

                Dim arrayFilas() As String
                arrayFilas = Strings.Split(filas, ",")

                Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
                For contFila = 0 To UBound(arrayFilas)
                    If arrayFilas(contFila) = "optClasificacion" Then
                        filaClasificacion = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " clf.clas_clasificacioclientenid AS CLASIFICACION"
                        Else
                            cadenaSelect += ", clf.clas_clasificacioclientenid AS CLASIFICACION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " clf.clas_clasificacioclientenid"
                        Else
                            cadenaGroupBy += ", clf.clas_clasificacioclientenid"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLASIFICACION"
                        Else
                            orderByConsulta += ", CLASIFICACION"
                        End If

                    ElseIf arrayFilas(contFila) = "optCliente" Then
                        filaCliente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " c.nombre AS CLIENTE"
                        Else
                            cadenaSelect += ", c.nombre AS CLIENTE"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " c.nombre"
                        Else
                            cadenaGroupBy += ", c.nombre"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CLIENTE"
                        Else
                            orderByConsulta += ", CLIENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optAgente" Then
                        filaAgente = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " agt.Nombre as AGENTE "
                        Else
                            cadenaSelect += ", agt.Nombre as AGENTE "
                        End If

                        'cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " agt.Nombre "
                        Else
                            cadenaGroupBy += ", agt.Nombre "
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by AGENTE"
                        Else
                            orderByConsulta += ", AGENTE"
                        End If

                    ElseIf arrayFilas(contFila) = "optMarca" Then
                        filaMarca = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.MarcaSAY AS MARCA"
                        Else
                            cadenaSelect += ", prod.MarcaSAY AS MARCA"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.MarcaSAY"
                        Else
                            cadenaGroupBy += ", prod.MarcaSAY"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MARCA"
                        Else
                            orderByConsulta += ", MARCA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCategoria" Then
                        filaCategoria = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                        Else
                            cadenaSelect += ", prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            ' cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                        End If
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.NaveDesarrollo"
                        Else
                            cadenaGroupBy += ", prod.NaveDesarrollo"
                        End If

                        If Len(categoria) > 0 Then
                            Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                            cadenaCategoriaWhere = "'0'"
                            arraycomillasCategoria = Strings.Split(categoria, ",")
                            For idmod = 0 To UBound(arraycomillasCategoria)
                                cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                            Else
                                whereConstruido += " AND (prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by 'NAVE DESARROLLA'"
                        Else
                            orderByConsulta += ", 'NAVE DESARROLLA'"
                        End If

                    ElseIf arrayFilas(contFila) = "optColeccion" Then
                        filaColeccion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.MarcaSAY+' '+prod.ColeccionSAY AS COLECCION"
                        Else
                            cadenaSelect += ",prod.MarcaSAY+' '+prod.ColeccionSAY AS COLECCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += "prod.MarcaSAY, prod.ColeccionSAY"
                        Else
                            cadenaGroupBy += ", prod.MarcaSAY, prod.ColeccionSAY"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLECCION"
                        Else
                            orderByConsulta += ", COLECCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optModelo" Then
                        filaModelo = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS MODELO"
                        Else
                            cadenaSelect += ",REPLACE(prod.MarcaSAY+ ' ' + prod.ModeloSICY, ',', '') AS MODELO"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.MarcaSAY, prod.ModeloSICY"
                        Else
                            cadenaGroupBy += ", prod.MarcaSAY, prod.ModeloSICY"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by MODELO"
                        Else
                            orderByConsulta += ", MODELO"
                        End If

                    ElseIf arrayFilas(contFila) = "optDescripcion" Then
                        filaDescripcion = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.DescripcionCompleta AS DESCRIPCION"
                        Else
                            cadenaSelect += ", prod.DescripcionCompleta AS DESCRIPCION"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.DescripcionCompleta"
                        Else
                            cadenaGroupBy += ", prod.DescripcionCompleta"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by DESCRIPCION"
                        Else
                            orderByConsulta += ", DESCRIPCION"
                        End If

                    ElseIf arrayFilas(contFila) = "optFamilia" Then
                        filaFamilia = True

                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.FamiliaProyeccion AS FAMILIA"
                        Else
                            cadenaSelect += ", prod.FamiliaProyeccion AS FAMILIA"
                        End If
                        If cadenaInnerVistaCategoriaFamilias = "" Then
                            cadenaInnerVistaCategoriaFamilias = "Contenido"
                            'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.FamiliaProyeccion"
                        Else
                            cadenaGroupBy += ", prod.FamiliaProyeccion"
                        End If

                        If Len(familias) > 0 Then
                            Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                            cadenaFamiliaWhere = "'0'"
                            arraycomillasFamilia = Strings.Split(familias, ",")
                            For idFam = 0 To UBound(arraycomillasFamilia)
                                cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                            Else
                                whereConstruido += " AND (prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by FAMILIA"
                        Else
                            orderByConsulta += ", FAMILIA"
                        End If

                    ElseIf arrayFilas(contFila) = "optCorrida" Then
                        filaCorrida = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.Talla AS CORRIDA"
                        Else
                            cadenaSelect += ", prod.Talla AS CORRIDA"
                        End If
                        ' cadenaConsulta += " INNER JOIN Tallas t ON vt.IdTalla = t.IdTalla"
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.Talla"
                        Else
                            cadenaGroupBy += ", prod.Talla"
                        End If

                        If Len(corrida) > 0 Then
                            Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                            cadenaCorridaWhere = "'0'"
                            arraycomillasCorrida = Strings.Split(corrida, ",")
                            For iCor = 0 To UBound(arraycomillasCorrida)
                                cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " prod.Talla IN (" + cadenaCorridaWhere + ")"
                            Else
                                whereConstruido += " AND (prod.Talla IN (" + cadenaCorridaWhere + ")"
                            End If
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by CORRIDA"
                        Else
                            orderByConsulta += ", CORRIDA"
                        End If

                    ElseIf arrayFilas(contFila) = "optColor" Then
                        filaColor = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " prod.PielColor AS COLOR"
                        Else
                            cadenaSelect += ", prod.PielColor AS COLOR"
                        End If

                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " prod.PielColor"
                        Else
                            cadenaGroupBy += ", prod.PielColor"
                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by COLOR"
                        Else
                            orderByConsulta += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFila) = "optRuta" Then
                        filaRuta = True
                        If cadenaSelect = "SELECT" Then
                            cadenaSelect += " ruta_nombre  AS RUTA"
                        Else
                            cadenaSelect += ", ruta_nombre  AS RUTA"
                        End If
                        'cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                        If cadenaGroupBy = "" Then
                            cadenaGroupBy += " ruta_nombre "
                        Else
                            cadenaGroupBy += ", ruta_nombre "
                        End If

                        If Len(Ruta) > 0 Then
                            Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                            cadenaRutaWhere = "'0'"
                            arraycomillasRuta = Strings.Split(Ruta, ",")
                            For iRuta = 0 To UBound(arraycomillasRuta)
                                cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                            Next

                            If whereConstruido.Length > 0 Then
                                whereConstruido += " " + radioYO + " " + " ruta_nombre  IN (" + cadenaRutaWhere + ")"
                            Else
                                whereConstruido += " AND (ruta_nombre  IN (" + cadenaRutaWhere + ")"
                            End If

                        End If

                        If orderByConsulta = "" Then
                            orderByConsulta = "Order by RUTA"
                        Else
                            orderByConsulta += ", RUTA"
                        End If
                    End If
                Next contFila

                If cadenaGroupBy = "" Then
                    cadenaGroupBy += " evs.evse_semana "
                Else
                    cadenaGroupBy += ", evs.evse_semana "
                End If

                If Len(categoria) > 0 And filaCategoria = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                    cadenaCategoriaWhere = "'0'"
                    arraycomillasCategoria = Strings.Split(categoria, ",")
                    For idmod = 0 To UBound(arraycomillasCategoria)
                        cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " prod.NaveDesarrollo  IN (" + cadenaCategoriaWhere + ")"
                    Else
                        whereConstruido += " AND (prod.NaveDesarrollo  IN (" + cadenaCategoriaWhere + ")"
                    End If

                End If

                If Len(familias) > 0 And filaFamilia = False Then
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                    cadenaFamiliaWhere = "'0'"
                    arraycomillasFamilia = Strings.Split(familias, ",")
                    For idFam = 0 To UBound(arraycomillasFamilia)
                        cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                    Else
                        whereConstruido += " AND (prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                    End If
                End If


                If Len(corrida) > 0 And filaCorrida = False Then
                    'cadenaConsulta += " INNER JOIN Tallas t ON vt.IdTalla = t.IdTalla"

                    Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                    cadenaCorridaWhere = "'0'"
                    arraycomillasCorrida = Strings.Split(corrida, ",")
                    For iCor = 0 To UBound(arraycomillasCorrida)
                        cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " prod.Talla IN (" + cadenaCorridaWhere + ")"
                    Else
                        whereConstruido += " AND (prod.Talla IN (" + cadenaCorridaWhere + ")"
                    End If
                End If

                If Len(Ruta) > 0 And filaRuta = False Then
                    'cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                    cadenaRutaWhere = "'0'"
                    arraycomillasRuta = Strings.Split(Ruta, ",")
                    For iRuta = 0 To UBound(arraycomillasRuta)
                        cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                    Next

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " ruta_rutasicyid   IN (" + cadenaRutaWhere + ")"
                    Else
                        whereConstruido += " AND (ruta_rutasicyid   IN (" + cadenaRutaWhere + ")"
                    End If
                End If

                If opSuma = True Then
                    cadenaSelectOperacion += ", SUM(factura.evpf_paresfacturados) AS PARES"
                End If
                If opColecciones = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT prod.MarcaSAY+' '+ prod.ColeccionSAY) AS COLECCIONES"
                End If
                If opArticulos = True Then
                    cadenaSelectOperacion += ", COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS"
                    ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
                End If



                If whereConstruido.Length > 0 Then
                    cadenaWhereConsulta += whereConstruido + ")"
                End If

                If tipoReporte = "anual" Then
                    Dim anioIncremento As Int32 = anioInicio
                    Dim cadenaCamposPvt As String = ""
                    Dim cadenaCamposPvtCad As String = ""
                    For contCol As Int32 = 0 To diferenciaAnios
                        cadenaCamposPvt += "[" + anioIncremento.ToString + "],"
                        anioIncremento = anioIncremento + 1
                    Next

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4))  AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)) "

                    'MsgBox(cadenaFinal)
                    cadenaCamposPvtCad = cadenaCamposPvt.Substring(0, cadenaCamposPvt.Length - 1)

                    Dim ListaParametros As New List(Of SqlClient.SqlParameter)

                    Dim ParametroParaLista As New SqlParameter
                    ParametroParaLista.ParameterName = "@cadenaSelect"
                    ParametroParaLista.Value = cadenaFinal
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@aniosPivot"
                    ParametroParaLista.Value = cadenaCamposPvtCad
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@operacion"
                    ParametroParaLista.Value = cadenaOperacion
                    ListaParametros.Add(ParametroParaLista)

                    ParametroParaLista = New SqlParameter
                    ParametroParaLista.ParameterName = "@orden"
                    ParametroParaLista.Value = orderByConsulta
                    ListaParametros.Add(ParametroParaLista)
                    dtDatosConsultaReporte = operConsultas.EjecutarConsultaSP("Programacion.SP_ConsultaReporteFechas", ListaParametros)

                    If opArticulos = True Or opColecciones = True Then
                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS , CAST(evse_año AS VARCHAR(4))  AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by CAST(evse_año AS VARCHAR(4)) " + " ORDER BY ANIO"
                            dtTotalFinaARTCOL = operConsultas.EjecutaConsulta("SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta)
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+prod.ColeccionSAY) AS COLECCIONES , CAST(evse_año AS VARCHAR(4))  AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by CAST(evse_año AS VARCHAR(4)) " + " ORDER BY ANIO"
                            dtTotalFinaARTCOL = operConsultas.EjecutaConsulta("SELECT COUNT(DISTINCT prod.MarcaSAY+' '+ prod.ColeccionSAY) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta)
                        End If
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        Dim cadenaConsultaTotalArtCol As String = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(cadenaConsultaTotalArtCol)
                    End If

                ElseIf tipoReporte = "mensual" Then
                    Dim aniosMeses As String = ""
                    Dim anioMesCont As Int32 = anioInicio
                    Dim mesContAnio As Int32 = 1

                    Dim dtDatosTotalesFechas As New DataTable
                    Dim anioIncrementa As Int32 = anioInicio
                    Dim mesesRep As Int32 = ((diferenciaAnios + 1) * 12)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + mesesRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next

                    For contCols As Int32 = 1 To mesesRep
                        aniosMeses += "[" + anioMesCont.ToString + mesContAnio.ToString + "],"
                        If contCols Mod 12 = 0 = True Then
                            anioMesCont += 1
                            mesContAnio = 0
                        End If
                        mesContAnio += 1
                    Next
                    aniosMeses = aniosMeses.Substring(0, aniosMeses.Length - 1)

                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)

                    'For Each rowCol As DataRow In dtColumnasGeneral.Rows Comentado 06/05/2016
                    '    Dim dtRowColumnas As DataRow = dtDatosConsultaReporte.NewRow Comentado 06/05/2016
                    '    For cntFC As Int32 = 0 To tamanoCamposFilas - 1 Comentado 06/05/2016
                    '        dtRowColumnas.Item(cntFC) = rowCol.Item(cntFC) Comentado 06/05/2016
                    '    Next Comentado 06/05/2016
                    '    dtDatosConsultaReporte.Rows.Add(dtRowColumnas) Comentado 06/05/2016
                    'Next Comentado 06/05/2016

                    'For colDTtitulos As Int32 = 0 To tamanoCamposFilas - 1 Comentado 06/05/2016
                    '    dtDatosConsultaReporte.Rows(1).Item(colDTtitulos) = dtColumnasGeneral.Columns(colDTtitulos).ColumnName.ToString Comentado 06/05/2016
                    'Next Comentado 06/05/2016

                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4))  AS ANIO, cast(evs.evse_mesid as VARCHAR(5))  AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)) , cast(evs.evse_mesid as VARCHAR(5)) " + " " + orderByConsulta + ", ANIO, MES"

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4)) + cast(evs.evse_mesid as VARCHAR(5)) AS ANIOMES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)), cast(evs.evse_mesid as VARCHAR(5))"

                    If opSuma = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(PARES) FOR ANIOMES IN (" + aniosMeses + ")) AS pvotCLASSUM"
                    ElseIf opArticulos = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(ARTICULOS) FOR ANIOMES IN (" + aniosMeses + ")) AS pvotCLASArt"
                    ElseIf opColecciones = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(COLECCIONES) FOR ANIOMES IN (" + aniosMeses + ")) AS pvotCLASCol"
                    End If

                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)


                    If opArticulos = True Or opColecciones = True Then
                        Dim cadenadtTotalFinaARTCOL As String = ""
                        Dim cadenadtTotalesSubtotalesFechas As String = ""
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4)) AS ANIO" + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ",CAST(evse_año AS VARCHAR(4))" + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta

                        If opArticulos = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS , CAST(evse_año AS VARCHAR(4)) AS ANIO,  cast(evs.evse_mesid as VARCHAR(5)) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by CAST(evse_año AS VARCHAR(4)),  cast(evs.evse_mesid as VARCHAR(5))" + " ORDER BY ANIO, MES"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS , CAST(evse_año AS VARCHAR(4)) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by CAST(evse_año AS VARCHAR(4))"
                        ElseIf opColecciones = True Then
                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+prod.ColeccionSAY) AS COLECCIONES , CAST(evse_año AS VARCHAR(4)) AS ANIO,  cast(evs.evse_mesid as VARCHAR(5)) AS MES " + cadenaConsulta + cadenaWhereConsulta + "Group by CAST(evse_año AS VARCHAR(4)),  cast(evs.evse_mesid as VARCHAR(5))" + " ORDER BY ANIO, MES"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+ prod.ColeccionSAY) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+prod.ColeccionSAY) AS COLECCIONES , CAST(evse_año AS VARCHAR(4)) AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by CAST(evse_año AS VARCHAR(4))"
                        End If

                        dtTotalFinaARTCOL = operConsultas.EjecutaConsulta(cadenadtTotalFinaARTCOL)
                        dtTotalesSubtotalesFechas = operConsultas.EjecutaConsulta(cadenadtTotalesSubtotalesFechas)


                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)

                    End If

                    dtDatosConsultaReporte = New DataTable
                    For Each colRow As DataColumn In dtDatosTotalesFechas.Columns
                        dtDatosConsultaReporte.Columns.Add(colRow.Caption)
                    Next

                    Dim drowDos As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            drowDos.Item(col) = col.Caption.ToString
                        Else
                            If col.Caption.Substring(4, col.Caption.Length - 4) = "1" Then
                                drowDos.Item(col) = "ENERO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "2" Then
                                drowDos.Item(col) = "FEBRERO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "3" Then
                                drowDos.Item(col) = "MARZO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "4" Then
                                drowDos.Item(col) = "ABRIL"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "5" Then
                                drowDos.Item(col) = "MAYO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "6" Then
                                drowDos.Item(col) = "JUNIO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "7" Then
                                drowDos.Item(col) = "JULIO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "8" Then
                                drowDos.Item(col) = "AGOSTO"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "9" Then
                                drowDos.Item(col) = "SEPTIEMBRE"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "10" Then
                                drowDos.Item(col) = "OCTUBRE"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "11" Then
                                drowDos.Item(col) = "NOVIEMBRE"
                            ElseIf col.Caption.Substring(4, col.Caption.Length - 4) = "12" Then
                                drowDos.Item(col) = "DICIEMBRE"
                            End If
                        End If

                    Next

                    dtDatosConsultaReporte.Rows.InsertAt(drowDos, 0)

                    Dim drowUno As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            'drowUno.Item(col) = col.Caption.ToString
                        Else
                            drowUno.Item(col) = col.Caption.Substring(0, 4)
                        End If

                    Next
                    dtDatosConsultaReporte.Rows.InsertAt(drowUno, 0)

                    For Each rowDt As DataRow In dtDatosTotalesFechas.Rows
                        dtDatosConsultaReporte.ImportRow(rowDt)
                    Next

                    'aqui es por semana
                ElseIf tipoReporte = "semanal" Then
                    Dim dtDatosTotalesFechas As New DataTable
                    Dim anioIncrementa As Int32 = anioInicio
                    Dim semanasRep As Int32 = ((diferenciaAnios + 1) * 52)

                    Dim aniosSemenas As String = ""
                    Dim aniosSemenasCont As Int32 = anioInicio
                    Dim semanaContAnio As Int32 = 1

                    For contCols As Int32 = 1 To semanasRep
                        aniosSemenas += "[" + aniosSemenasCont.ToString + semanaContAnio.ToString + "],"
                        If contCols Mod 52 = 0 = True Then
                            aniosSemenasCont += 1
                            semanaContAnio = 0
                        End If
                        semanaContAnio += 1
                    Next

                    aniosSemenas = aniosSemenas.Substring(0, aniosSemenas.Length - 1)

                    For contCols As Int32 = 0 To ((tamanoCamposFilas + semanasRep) - 1)
                        dtDatosConsultaReporte.Columns.Add()
                    Next


                    Dim cadenaColumnas As String = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                    ' ''Dim dtColumnasGeneral As DataTable = operConsultas.EjecutaConsulta(cadenaColumnas)
                    Dim cadenadtTotalFinaARTCOL As String = ""
                    Dim cadenadtTotalesSubtotalesFechas As String = ""

                    If opArticulos = True Or opColecciones = True Then
                        cadenaFinalColeccionArticulo = cadenaSelect + cadenaSelectOperacion + ", CAST(evse_año AS VARCHAR(4))  AS ANIO " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)) " + " " + orderByConsulta + ", ANIO"
                        totalCadArtColTOTAL = cadenaSelect + cadenaSelectOperacion + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta
                        If opArticulos = True Then

                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS , CAST(evse_año AS VARCHAR(4))  AS ANIO, evse_semana AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by CAST(evse_año AS VARCHAR(4)) , evse_semana" + " ORDER BY ANIO, SEMANA"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS , CAST(evse_año AS VARCHAR(4))  AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by CAST(evse_año AS VARCHAR(4)) "

                        ElseIf opColecciones = True Then

                            totalCadenaArticulosColecciones = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+ prod.ColeccionSAY) AS COLECCIONES , CAST(evse_año AS VARCHAR(4))  AS ANIO, evse_semana AS SEMANA " + cadenaConsulta + cadenaWhereConsulta + "Group by CAST(evse_año AS VARCHAR(4)) , evse_semana" + " ORDER BY ANIO, SEMANA"
                            cadenadtTotalFinaARTCOL = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+ prod.ColeccionSAY) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta
                            cadenadtTotalesSubtotalesFechas = "SELECT COUNT(DISTINCT prod.MarcaSAY+' '+ prod.ColeccionSAY) AS COLECCIONES , CAST(evse_año AS VARCHAR(4))  AS ANIO " + cadenaConsulta + cadenaWhereConsulta + " Group by CAST(evse_año AS VARCHAR(4)) "

                        End If

                        dtTotalFinaARTCOL = operConsultas.EjecutaConsulta(cadenadtTotalFinaARTCOL)
                        dtTotalesSubtotalesFechas = operConsultas.EjecutaConsulta(cadenadtTotalesSubtotalesFechas)

                        dtTotalCadenaArticulosColecciones = operConsultas.EjecutaConsulta(totalCadenaArticulosColecciones)
                        dtSubtotalesFechas = operConsultas.EjecutaConsulta(cadenaFinalColeccionArticulo)
                        dtTotalCadArtColTOTAL = operConsultas.EjecutaConsulta(totalCadArtColTOTAL)
                    End If
                    'aquí va el cambio
                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", ANIOSEMANA= CASE DATEPART(YEAR,vn.FechaVenta) WHEN 2017 THEN CAST(CAST(evse_año AS VARCHAR(4))  AS varchar(4)) + CAST((DATEPART(WEEK,vn.FechaVenta)-1) AS varchar(2)) ELSE CAST(CAST(evse_año AS VARCHAR(4))  AS varchar(4)) + CAST(DATEPART(WEEK,vn.FechaVenta) AS varchar(2)) END " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)) , evse_semana"

                    'If (Now.Year = 2021) Then
                    'End If
                    ''''SE COMENTARA EL 08/03/2021 PARA AGREGAR JOIN DESDE LA CONSULTA INICIAL Y QUE TOME LAS SEMANAS DE LA TABLA Ventas.EstadVentas_Semana QUE LAS TRAER POR DEFECTO
                    ''''Y NO LAS TENGA QUE CALCULAR PORQUE COMO VENTAS SACA SUS PROPIAS SEMANAS ESTÉ SCRIPT TIENE SUS INCONVENIENTES EN CIERTAS PARTES
                    'cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", ANIOSEMANA= CASE DATEPART(YEAR,vn.FechaVenta) WHEN 2021 THEN CAST(CAST(evse_año AS VARCHAR(4))  AS varchar(4)) + CAST((DATEPART(WEEK,vn.FechaVenta)-1) AS varchar(2)) ELSE CAST(CAST(evse_año AS VARCHAR(4))  AS varchar(4)) + CAST(DATEPART(WEEK,vn.FechaVenta) AS varchar(2)) END " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)) , evse_semana"

                    cadenaFinal = cadenaSelect + cadenaSelectOperacion + ", ANIOSEMANA = (CAST(CAST(evse_año AS VARCHAR(4))  AS VARCHAR(4)) + CAST(evs.evse_semana AS VARCHAR(2))) " + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + ", CAST(evse_año AS VARCHAR(4)) , evse_semana"


                    If opSuma = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(PARES) FOR ANIOSEMANA IN (" + aniosSemenas + ")) AS pvotCLASSUM"
                    ElseIf opArticulos = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(ARTICULOS) FOR ANIOSEMANA IN (" + aniosSemenas + ")) AS pvotCLASArt"
                    ElseIf opColecciones = True Then
                        cadenaFinal = "SELECT * FROM(" + cadenaFinal + ") AS CONSULTA PIVOT  (SUM(COLECCIONES) FOR ANIOSEMANA IN (" + aniosSemenas + ")) AS pvotCLASCol"
                    End If

                    dtDatosTotalesFechas = operConsultas.EjecutaConsulta(cadenaFinal)

                    'se agregan los nombres de columnas al datatable
                    dtDatosConsultaReporte = New DataTable
                    For Each colRow As DataColumn In dtDatosTotalesFechas.Columns
                        dtDatosConsultaReporte.Columns.Add(colRow.Caption)
                    Next

                    Dim drowDos As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            drowDos.Item(col) = col.Caption.ToString
                        Else
                            drowDos.Item(col) = col.Caption.Substring(4, col.Caption.Length - 4)
                        End If

                    Next
                    dtDatosConsultaReporte.Rows.InsertAt(drowDos, 0)

                    Dim drowUno As DataRow = dtDatosConsultaReporte.NewRow
                    For Each col As DataColumn In dtDatosConsultaReporte.Columns
                        If dtDatosConsultaReporte.Columns.IndexOf(col.Caption) < tamanoCamposFilas Then
                            'drowUno.Item(col) = col.Caption.ToString
                        Else
                            drowUno.Item(col) = col.Caption.Substring(0, 4)
                        End If

                    Next
                    dtDatosConsultaReporte.Rows.InsertAt(drowUno, 0)

                    For Each rowDt As DataRow In dtDatosTotalesFechas.Rows
                        dtDatosConsultaReporte.ImportRow(rowDt)
                    Next
                End If

                Dim validarContenido As Boolean = True

                If tipoReporte = "anual" Then
                    If dtDatosConsultaReporte.Rows.Count > 0 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                Else
                    If dtDatosConsultaReporte.Rows.Count > 2 Then
                        validarContenido = True
                    Else
                        validarContenido = False
                    End If
                End If


                If validarContenido = True Then
                    Dim mesUno As Int32 = Month(fechaUno)
                    Dim mesDos As Int32 = Month(fechaDos)
                    Dim anioUno As Int32 = Year(fechaUno)
                    Dim anioDos As Int32 = Year(fechaDos)
                    Dim semanaUno As String
                    Dim semanaDos As String

                    'se obtiene el año
                    'el sistema y la bd toman como 1er día de la semana a lunes y como 2017 (1/01/2017) fue domingo (para el sistema y bd esa es la primera semana del año se resta aquí semana para poder crear los reportes de forma correcta)
                    If anioUno < 2017 Then
                        semanaUno = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
                        ' a la última semana se le dice que se resté una porque la bd cuenta la semana de diferente forma
                        If fechaDos.ToString = "01/01/2017" Then
                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
                        ElseIf fechaDos.ToString > "01/01/2017" Then
                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)
                        End If

                    ElseIf anioUno = 2017 Then

                        If fechaUno = "01/01/2017" Then
                            semanaUno = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))

                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)

                        Else

                            semanaUno = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)
                            ' a la última semana se le dice que se resté una porque la bd cuenta la semana de diferente forma
                            semanaDos = (DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)
                        End If

                    Else
                        semanaUno = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaUno), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                        semanaDos = DatePart(DateInterval.WeekOfYear, Convert.ToDateTime(fechaDos), FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
                    End If

                    If semanaUno > 52 Then
                        semanaUno = 52
                    End If
                    If semanaDos > 52 Then
                        semanaDos = 52
                    End If

                    If tipoReporte = "semanal" Then

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If IsNumeric(dtDatosConsultaReporte.Rows(1).Item(contCol)) = True Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> semanaUno.ToString Then
                                    dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                    contCol = 0
                                Else
                                    Exit For
                                End If
                            End If
                        Next
                        'PRIMERA PARTE SUBTOTAL

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas - 1 Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "52" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next


                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> semanaDos.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next

                        If opSuma = True Then
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next
                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        ElseIf opArticulos = True Or opColecciones = True Then
                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")
                            If opArticulos = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("ARTICULOS").ToString
                                    contFilaTotal += 1
                                Next
                            ElseIf opColecciones = True Then
                                Dim contFilaTotal As Int32 = 0
                                For contCol As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    dtDatosConsultaReporte.Rows(contCol).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                    contFilaTotal += 1
                                Next
                            End If
                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = rowDt.Item("SEMANA").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If

                                Next
                            Next

                            filaResultados.Item("TOTAL") = dtTotalFinaARTCOL.Rows(0).Item(0).ToString

                            Dim contAnio As Int32 = 0
                            For colDT As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                If filaResultados.Item(colDT).ToString = "" And dtDatosConsultaReporte.Rows(0).Item(colDT).ToString = "" Then
                                    filaResultados.Item(colDT) = dtTotalesSubtotalesFechas.Rows(contAnio).Item(0)
                                    contAnio += 1
                                End If
                            Next
                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If
                    End If

                    If tipoReporte = "mensual" Then
                        Dim mesUnoCadena As String = ""
                        If mesUno = 1 Then
                            mesUnoCadena = "ENERO"
                        ElseIf mesUno = 2 Then
                            mesUnoCadena = "FEBRERO"
                        ElseIf mesUno = 3 Then
                            mesUnoCadena = "MARZO"
                        ElseIf mesUno = 4 Then
                            mesUnoCadena = "ABRIL"
                        ElseIf mesUno = 5 Then
                            mesUnoCadena = "MAYO"
                        ElseIf mesUno = 6 Then
                            mesUnoCadena = "JUNIO"
                        ElseIf mesUno = 7 Then
                            mesUnoCadena = "JULIO"
                        ElseIf mesUno = 8 Then
                            mesUnoCadena = "AGOSTO"
                        ElseIf mesUno = 9 Then
                            mesUnoCadena = "SEPTIEMBRE"
                        ElseIf mesUno = 10 Then
                            mesUnoCadena = "OCTUBRE"
                        ElseIf mesUno = 11 Then
                            mesUnoCadena = "NOVIEMBRE"
                        ElseIf mesUno = 12 Then
                            mesUnoCadena = "DICIEMBRE"
                        End If

                        Dim mesDosCadena As String = ""
                        If mesDos = 1 Then
                            mesDosCadena = "ENERO"
                        ElseIf mesDos = 2 Then
                            mesDosCadena = "FEBRERO"
                        ElseIf mesDos = 3 Then
                            mesDosCadena = "MARZO"
                        ElseIf mesDos = 4 Then
                            mesDosCadena = "ABRIL"
                        ElseIf mesDos = 5 Then
                            mesDosCadena = "MAYO"
                        ElseIf mesDos = 6 Then
                            mesDosCadena = "JUNIO"
                        ElseIf mesDos = 7 Then
                            mesDosCadena = "JULIO"
                        ElseIf mesDos = 8 Then
                            mesDosCadena = "AGOSTO"
                        ElseIf mesDos = 9 Then
                            mesDosCadena = "SEPTIEMBRE"
                        ElseIf mesDos = 10 Then
                            mesDosCadena = "OCTUBRE"
                        ElseIf mesDos = 11 Then
                            mesDosCadena = "NOVIEMBRE"
                        ElseIf mesDos = 12 Then
                            mesDosCadena = "DICIEMBRE"
                        End If

                        For contCol As Int32 = tamanoCamposFilas To 12
                            contCol = tamanoCamposFilas
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString <> mesUnoCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(tamanoCamposFilas).ColumnName.ToString)
                            Else
                                Exit For
                            End If
                        Next

                        For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                            If contCol > tamanoCamposFilas Then
                                If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString = "DICIEMBRE" Then
                                    dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                    dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                End If
                            End If
                        Next
                        For contCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1 To 0 Step -1
                            If dtDatosConsultaReporte.Rows(1).Item(contCol).ToString() <> mesDosCadena.ToString Then
                                dtDatosConsultaReporte.Columns.Remove(dtDatosConsultaReporte.Columns(contCol).ColumnName.ToString)
                                contCol = dtDatosConsultaReporte.Columns.Count
                            Else
                                dtDatosConsultaReporte.Columns.Add("SUBTOTAL" + contCol.ToString).SetOrdinal(contCol + 1)
                                dtDatosConsultaReporte.Rows(1).Item(contCol + 1) = "SUBTOTAL"
                                Exit For
                            End If
                        Next
                        If opSuma = True Then
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For colDt As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() <> "SUBTOTAL" Then
                                        If IsNumeric(dtDatosConsultaReporte.Rows(contRow).Item(colDt)) = True Then
                                            If dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString() <> "" Then
                                                suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(colDt).ToString())
                                            End If
                                        End If
                                    ElseIf dtDatosConsultaReporte.Rows(1).Item(colDt).ToString() = "SUBTOTAL" Then
                                        dtDatosConsultaReporte.Rows(contRow).Item(colDt) = suma.ToString
                                        suma = 0
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TotalTodo")
                            dtDatosConsultaReporte.Rows(1).Item("TotalTodo") = "TOTAL"
                            For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                Dim suma As Int32 = 0
                                For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" And dtDatosConsultaReporte.Rows(1).Item(contColumn).ToString <> "SUBTOTAL" Then
                                        suma = suma + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    Else
                                        dtDatosConsultaReporte.Rows(contRow).Item("TotalTodo") = suma.ToString
                                    End If
                                Next
                            Next

                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        ElseIf opArticulos = True Or opColecciones = True Then

                            For Each dtRow As DataRow In dtDatosConsultaReporte.Rows
                                For Each dtCol As DataColumn In dtDatosConsultaReporte.Columns
                                    If dtDatosConsultaReporte.Rows(1).Item(dtCol).ToString = "SUBTOTAL" Then

                                        For Each rowDtF As DataRow In dtSubtotalesFechas.Rows
                                            Dim inserta As Boolean = True
                                            For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                                If dtRow.Item(itemDt).ToString <> rowDtF.Item(itemDt).ToString Then
                                                    inserta = False
                                                    Exit For
                                                End If
                                            Next
                                            If inserta = True Then
                                                If dtDatosConsultaReporte.Rows(0).Item(CInt(dtDatosConsultaReporte.Columns.IndexOf(dtCol)) - 1).ToString <> rowDtF.Item("ANIO").ToString Then
                                                    inserta = False
                                                End If
                                            End If
                                            If inserta = True Then
                                                If opArticulos = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("ARTICULOS")
                                                ElseIf opColecciones = True Then
                                                    dtRow.Item(dtCol) = rowDtF.Item("COLECCIONES")
                                                End If

                                            End If
                                        Next
                                    End If
                                Next
                            Next

                            dtDatosConsultaReporte.Columns.Add("TOTAL")


                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            If opArticulos = True Then

                                'Dim contFilaTotal As Int32 = 0
                                Dim inserta As Boolean = True
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1

                                    For rowdt As Int32 = 0 To dtTotalCadArtColTOTAL.Rows.Count - 1
                                        For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                            If dtDatosConsultaReporte.Rows(contArt).Item(itemDt).ToString <> dtTotalCadArtColTOTAL.Rows(rowdt).Item(itemDt).ToString Then
                                                inserta = False
                                            End If
                                        Next
                                        If inserta = True Then
                                            dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(rowdt).Item("ARTICULOS").ToString
                                            Dim dtRowDelete As DataRow = dtTotalCadArtColTOTAL.Rows(rowdt)
                                            dtTotalCadArtColTOTAL.Rows.Remove(dtRowDelete)
                                            inserta = True
                                            Exit For
                                        Else
                                            inserta = True
                                        End If
                                    Next

                                Next

                            ElseIf opColecciones = True Then

                                Dim contFilaTotal As Int32 = 0
                                Dim inserta As Boolean = True
                                For contArt As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                                    For Each rowdt As DataRow In dtTotalCadArtColTOTAL.Rows
                                        For itemDt As Int32 = 0 To tamanoCamposFilas - 1
                                            If dtDatosConsultaReporte.Rows(contArt).Item(itemDt).ToString <> rowdt.Item(itemDt).ToString Then
                                                inserta = False
                                            End If
                                        Next
                                        If inserta = True Then
                                            dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = dtTotalCadArtColTOTAL.Rows(contFilaTotal).Item("COLECCIONES").ToString
                                            inserta = True
                                            Exit For
                                        Else
                                            inserta = True
                                        End If
                                    Next
                                    contFilaTotal += 1
                                Next

                                '' ''filaResultados.Item(dtDatosConsultaReporte.Rows.Count - 2) = contFilaTotal


                            End If

                            dtDatosConsultaReporte.Rows(1).Item("TOTAL") = "TOTAL"

                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    Dim textoMes As String = ""
                                    If rowDt.Item("MES").ToString = "1" Then
                                        textoMes = "ENERO"
                                    ElseIf rowDt.Item("MES").ToString = "2" Then
                                        textoMes = "FEBRERO"
                                    ElseIf rowDt.Item("MES").ToString = "3" Then
                                        textoMes = "MARZO"
                                    ElseIf rowDt.Item("MES").ToString = "4" Then
                                        textoMes = "ABRIL"
                                    ElseIf rowDt.Item("MES").ToString = "5" Then
                                        textoMes = "MAYO"
                                    ElseIf rowDt.Item("MES").ToString = "6" Then
                                        textoMes = "JUNIO"
                                    ElseIf rowDt.Item("MES").ToString = "7" Then
                                        textoMes = "JULIO"
                                    ElseIf rowDt.Item("MES").ToString = "8" Then
                                        textoMes = "AGOSTO"
                                    ElseIf rowDt.Item("MES").ToString = "9" Then
                                        textoMes = "SEPTIEMBRE"
                                    ElseIf rowDt.Item("MES").ToString = "10" Then
                                        textoMes = "OCTUBRE"
                                    ElseIf rowDt.Item("MES").ToString = "11" Then
                                        textoMes = "NOVIEMBRE"
                                    ElseIf rowDt.Item("MES").ToString = "12" Then
                                        textoMes = "DICIEMBRE"
                                    End If
                                    If dtDatosConsultaReporte.Rows(0).Item(coldt).ToString = rowDt.Item("ANIO").ToString And dtDatosConsultaReporte.Rows(1).Item(coldt).ToString = textoMes Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next
                            filaResultados.Item("TOTAL") = dtTotalFinaARTCOL.Rows(0).Item(0).ToString

                            Dim contAnio As Int32 = 0
                            For colDT As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                If filaResultados.Item(colDT).ToString = "" And dtDatosConsultaReporte.Rows(0).Item(colDT).ToString = "" Then
                                    filaResultados.Item(colDT) = dtTotalesSubtotalesFechas.Rows(contAnio).Item(0)
                                    contAnio += 1
                                End If
                            Next

                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)

                        End If
                    End If

                    If tipoReporte = "anual" Then

                        If opSuma = True Then
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow()
                            filaResultados.Item(0) = "TOTAL"
                            For contColumn As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                Dim sumaFila As Int32 = 0
                                For contRow As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                                    If dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString <> "" Then
                                        sumaFila = sumaFila + CInt(dtDatosConsultaReporte.Rows(contRow).Item(contColumn).ToString)
                                    End If
                                Next
                                filaResultados.Item(contColumn) = sumaFila
                            Next
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        Else
                            Dim filaResultados As DataRow = dtDatosConsultaReporte.NewRow
                            For Each rowDt As DataRow In dtTotalCadenaArticulosColecciones.Rows
                                For coldt As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 1
                                    If dtDatosConsultaReporte.Columns(coldt).Caption.ToString = rowDt.Item("ANIO").ToString Then
                                        filaResultados.Item(coldt) = rowDt.Item(0).ToString
                                        Exit For
                                    End If
                                Next
                            Next



                            filaResultados.Item(0) = "TOTAL"
                            dtDatosConsultaReporte.Rows.Add(filaResultados)
                        End If

                    End If
                End If

                If tipoReporte = "anual" Then
                    dtDatosConsultaReporte.Columns.Add("TOTAL")
                    If opSuma = True Then
                        Dim sumaTotal As Int32 = 0
                        For rowTotal As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                            sumaTotal = 0
                            For colTotal As Int32 = tamanoCamposFilas To dtDatosConsultaReporte.Columns.Count - 2
                                If dtDatosConsultaReporte.Rows(rowTotal).Item(colTotal).ToString <> "" Then
                                    sumaTotal = sumaTotal + dtDatosConsultaReporte.Rows(rowTotal).Item(colTotal)
                                End If
                            Next
                            dtDatosConsultaReporte.Rows(rowTotal).Item("TOTAL") = sumaTotal
                        Next

                    ElseIf opArticulos = True Then
                        Dim inserta As Boolean = True
                        For contArt As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                            For Each rowdt As DataRow In dtTotalCadArtColTOTAL.Rows
                                For i As Int32 = 0 To tamanoCamposFilas - 1
                                    If rowdt.Item(i).ToString <> dtDatosConsultaReporte.Rows(contArt).Item(i).ToString Then
                                        inserta = False
                                    End If
                                Next
                                If inserta = True Then
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = rowdt.Item("ARTICULOS").ToString
                                    Exit For
                                End If
                                inserta = True
                            Next
                        Next
                        dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1).Item(dtDatosConsultaReporte.Columns.Count - 1) = dtTotalFinaARTCOL.Rows(0).Item(0).ToString

                    ElseIf opColecciones = True Then
                        Dim inserta As Boolean = True
                        For contArt As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                            For Each rowdt As DataRow In dtTotalCadArtColTOTAL.Rows
                                For i As Int32 = 0 To tamanoCamposFilas - 1
                                    If rowdt.Item(i).ToString <> dtDatosConsultaReporte.Rows(contArt).Item(i).ToString Then
                                        inserta = False
                                    End If
                                Next
                                If inserta = True Then
                                    dtDatosConsultaReporte.Rows(contArt).Item("TOTAL") = rowdt.Item("COLECCIONES").ToString
                                    Exit For
                                End If
                                inserta = True
                            Next
                        Next
                        dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1).Item(dtDatosConsultaReporte.Columns.Count - 1) = dtTotalFinaARTCOL.Rows(0).Item(0).ToString
                    End If
                End If

                Dim dtTablaOrdenada As New DataTable
                For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                    If contCol = dtDatosConsultaReporte.Columns.Count - 1 Then
                        dtTablaOrdenada.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption, Type.GetType("System.Int32"))
                    Else
                        dtTablaOrdenada.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption)
                    End If
                Next

                If tipoReporte <> "anual" Then
                    For cont As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 2
                        dtTablaOrdenada.ImportRow(dtDatosConsultaReporte.Rows(cont))
                    Next
                Else
                    For cont As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 2
                        dtTablaOrdenada.ImportRow(dtDatosConsultaReporte.Rows(cont))
                    Next
                End If

                Dim viewDtDatos As New DataView(dtTablaOrdenada)
                viewDtDatos.Sort = dtDatosConsultaReporte.Columns(dtDatosConsultaReporte.Columns.Count - 1).Caption.ToString + " DESC"
                dtTablaOrdenada = New DataTable
                dtTablaOrdenada = viewDtDatos.ToTable

                Dim dtTraspaso As New DataTable
                For contCol As Int32 = 0 To dtDatosConsultaReporte.Columns.Count - 1
                    dtTraspaso.Columns.Add(dtDatosConsultaReporte.Columns(contCol).Caption)
                Next

                If tipoReporte <> "anual" Then
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(0))
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(1))
                    For Each rowDt As DataRow In dtTablaOrdenada.Rows
                        dtTraspaso.ImportRow(rowDt)
                    Next
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1))
                Else
                    For Each rowDt As DataRow In dtTablaOrdenada.Rows
                        dtTraspaso.ImportRow(rowDt)
                    Next
                    dtTraspaso.ImportRow(dtDatosConsultaReporte.Rows(dtDatosConsultaReporte.Rows.Count - 1))
                End If

                dtDatosConsultaReporte = New DataTable
                dtDatosConsultaReporte = dtTraspaso
                dtDatosConsultaReporte.Columns.Add("Index").SetOrdinal(0)
                dtDatosConsultaReporte.Columns("Index").Caption = "#"
                Dim contFilaIndex As Int32 = 1
                For i As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                    If tipoReporte = "anual" Then
                        If i < dtDatosConsultaReporte.Rows.Count - 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    Else
                        If i <= 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = "#"
                        ElseIf i < dtDatosConsultaReporte.Rows.Count - 1 Then
                            dtDatosConsultaReporte.Rows(i).Item("index") = contFilaIndex
                            contFilaIndex += 1
                        End If
                    End If
                Next

                Dim ultimaCol As Int32 = dtDatosConsultaReporte.Columns.Count - 1
                Dim ultimaFila As Int32 = dtDatosConsultaReporte.Rows.Count - 1
                Dim TotalVentas As Double = CInt(dtDatosConsultaReporte.Rows(ultimaFila).Item(ultimaCol))
                Dim porcentajeFila As Decimal = 0.0
                dtDatosConsultaReporte.Columns.Add("Porcentaje")
                dtDatosConsultaReporte.Columns("Porcentaje").Caption = "%"
                If tipoReporte = "anual" Then
                    For rowTotal As Int32 = 0 To dtDatosConsultaReporte.Rows.Count - 1
                        If dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol).ToString <> "" Then
                            porcentajeFila = (dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                            dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                        End If
                        ' ''dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = (CDbl((dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100)) / TotalVentas)
                    Next

                Else

                    For rowTotal As Int32 = 2 To dtDatosConsultaReporte.Rows.Count - 1
                        porcentajeFila = (dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                        dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                        ' ''dtDatosConsultaReporte.Rows(rowTotal).Item("Porcentaje") = (CDbl((dtDatosConsultaReporte.Rows(rowTotal).Item(ultimaCol) * 100)) / TotalVentas)
                    Next

                End If

                Dim porcentajeColumna As Decimal = 0.0
                Dim rowPorcent As DataRow
                rowPorcent = dtDatosConsultaReporte.NewRow
                For Each colDtp As DataColumn In dtDatosConsultaReporte.Columns
                    If IsNumeric(dtDatosConsultaReporte.Rows(ultimaFila).Item(colDtp.ColumnName.ToString)) Then
                        porcentajeColumna = (dtDatosConsultaReporte.Rows(ultimaFila).Item(colDtp) * 100) / TotalVentas
                        rowPorcent.Item(colDtp) = porcentajeColumna.ToString("N2") + "%"
                    End If
                Next
                rowPorcent.Item(1) = "%"
                If tipoReporte <> "anual" Then
                    dtDatosConsultaReporte.Rows(1).Item(ultimaCol + 1) = "%"
                End If

                dtDatosConsultaReporte.Rows.Add(rowPorcent)



            End If

        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            'dtErrorCatch.Rows(0).Item(0) = ex.Message
            dtDatosConsultaReporte = dtErrorCatch

        End Try
        Return dtDatosConsultaReporte
    End Function

    Public Function generarConsultaDashAgente_SAY(ByVal filas As String, ByVal columnas As String, ByVal fechaUno As String, ByVal fechaDos As String,
                                           ByVal clasificacion As String, ByVal clientes As String, ByVal agentes As String, ByVal marcas As String,
                                           ByVal colecciones As String, ByVal modelos As String, ByVal descripcion As String, ByVal corrida As String,
                                           ByVal familias As String, ByVal categoria As String, ByVal color As String, ByVal ruta As String, ByVal radioYO As String,
                                           ByVal operaciones As String, ByVal accionId As Int32, ByVal usuario As String, ByVal ubicacion As String,
                                           ByVal conAgente As Boolean, ByVal vistaAgente As String) As DataTable
        Dim operPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim opeSAY As New Persistencia.OperacionesProcedimientos
        ' MsgBox(filas)
        Dim tablaDashBoard As New DataTable
        Dim filaClasificacion As Boolean = False
        Dim filaCliente As Boolean = False
        Dim filaAgente As Boolean = False
        Dim filaMarca As Boolean = False
        Dim filaCategoria As Boolean = False
        Dim filaColeccion As Boolean = False
        Dim filaModelo As Boolean = False
        Dim filaDescripcion As Boolean = False
        Dim filaFamilia As Boolean = False
        Dim filaCorrida As Boolean = False
        Dim filaColor As Boolean = False
        Dim filaRuta As Boolean = False

        Dim columnaClasificacion As Boolean = False
        Dim columnaCliente As Boolean = False
        Dim columnaAgente As Boolean = False
        Dim columnaMarca As Boolean = False
        Dim columnaCategoria As Boolean = False
        Dim columnaColeccion As Boolean = False
        Dim columnaModelo As Boolean = False
        Dim columnaDescripcion As Boolean = False
        Dim columnaFamilia As Boolean = False
        Dim columnaCorrida As Boolean = False
        Dim columnaColor As Boolean = False
        Dim columnaRuta As Boolean = False
        Dim cadenaSelect As String = "SELECT"
        Dim cadenaGroupBy As String = ""
        Dim consultaGenerada = String.Empty
        Dim cadenaWhereConsulta As String = String.Empty
        Dim totalesArticulosColeccionesColumnas As String = ""
        Dim totalCadenaGroupByColumnas As String = ""
        Dim totalorderByConsultaColumnas As String = ""
        Dim dtTotalesArticulosColumnas As New DataTable
        Dim totalesArticulosColeccionesFilas As String = ""
        Dim totalCadenaGroupByFilas As String = ""
        Dim totalorderByConsultaFilas As String = ""
        Dim dtTotalesArticulosFilas As New DataTable
        Dim dtTablaGeneradaDashboard As New DataTable
        Dim cadenaInnerVistaCategoriaFamilias As String = String.Empty
        Dim opSuma As Boolean = False
        Dim opArticulos As Boolean = False
        Dim opColecciones As Boolean = False
        Dim contadorColumnasFila As Int32 = 0
        Dim contColumnasConsulta As Int32 = 0
        Dim concatAgente As String = String.Empty
        Dim dtTablaFinal As New DataTable
        Dim dtDatosRetornados As New DataTable
        Dim orderByConsulta As String = ""

        If operaciones = "optSuma" Then
            opSuma = True
        ElseIf operaciones = "optCantArt" Then
            opArticulos = True
        ElseIf operaciones = "optCantCole" Then
            opColecciones = True
        End If


        Dim cadenaConsulta As String = " FROM Ventas.EstadVentas_PedidoPartida_Facturado factura " +
                                        "inner join Programacion.vProductoEstilos_Todos prod On prod.ProductoEstiloId = factura.evpf_productoestiloid " +
                                        "inner join Cadenas c on c.IdCadena = factura.evpf_idcadena " +
                                        "inner join Ventas.EstadVentas_Semana sem on sem.evse_fecha = factura.evpf_fechafactura  " +
                                        "inner join Cliente.Cliente cl on cl.clie_idsicy = c.IdCadena " +
                                        "LEFT join [" + opeSAY.Servidor + "]." + opeSAY.NombreDB + ".Nomina.VW_Colaboradores cb on cb.codr_colaboradorid = factura.evpf_idagentesay " +
                                        "left join [" + opeSAY.Servidor + "]." + opeSAY.NombreDB + ".Ventas.Rutas rt on rt.ruta_rutaid= cl.clie_rutaid " +
                                        "left join Agentes agt on agt.codr_colaboradorid = cb.codr_colaboradorid "

        'If conAgente = True Then
        '    If vistaAgente = "MisClientes" Then
        '        cadenaConsulta += " AND agt.IdAgente  IN (" & agentes & ") "
        '    End If

        'End If

        cadenaConsulta += " left join [" + opeSAY.Servidor + "]." + opeSAY.NombreDB + ".Cliente.Clasificaciones clf On clf.clas_clasificacioclientenid = cl.clie_clasificacionclienteid  "

        'If conAgente = True Then
        '    If vistaAgente = "MisClientes" Then
        '        cadenaConsulta += " JOIN Ventas.coleccionMarcaFamiliaCadenaAgente cmfa ON vn.IdCadena = cmfa.cmfa_idCadena" &
        '                        " AND (cmfa.cmfa_marcaSicy + cmfa.cmfa_coleccionSicy) = ve.IdLinea AND cmfa_idAgenteSicy IN (" & agentes & ")"
        '    End If
        'End If

        Try
            cadenaWhereConsulta = " WHERE evpf_fechafactura  >= '" + fechaUno + "' AND evpf_fechafactura  <= '" + fechaDos + "'" + " and isnull(factura.evpf_notacredito_cancelacion,0) = 0 and isnull(factura.evpf_notacredito_refacturacion,0) =0  "
            Dim whereConstruido As String = ""

            If conAgente = True Then
                If vistaAgente = "MisVentas" Then

                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        ' ''cadenaWhereConsulta += "AND vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                        cadenaWhereConsulta += " AND agt.IdAgente IN (" + cadenaAgenteWhere + ")"
                    End If

                ElseIf vistaAgente = "MisClientes" Then

                    If Len(agentes) > 0 Then
                        Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                        cadenaAgenteWhere = "'0'"
                        arraycomillasAgente = Strings.Split(agentes, ",")
                        For iAgente = 0 To UBound(arraycomillasAgente)
                            cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                        Next
                        cadenaWhereConsulta += " AND c.IdCadena IN (SELECT IdCadena FROM CadenasMarcasAgentes cma WHERE cma.IdAgente IN (" + cadenaAgenteWhere + "))"
                    End If

                End If
            Else
                If Len(agentes) > 0 Then
                    Dim arraycomillasAgente() As String, iAgente As Int32, cadenaAgenteWhere As String
                    cadenaAgenteWhere = "'0'"
                    arraycomillasAgente = Strings.Split(agentes, ",")
                    For iAgente = 0 To UBound(arraycomillasAgente)
                        cadenaAgenteWhere += ", '" + arraycomillasAgente(iAgente) + "'"
                    Next
                    '' ''If whereConstruido.Length > 0 Then
                    '' ''    whereConstruido += " " + radioYO + " " + " vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                    '' ''Else
                    '' ''    whereConstruido += " AND (vt.idCatVendedor IN (SELECT ag.IdAgente FROM Agentes ag WHERE REPLACE(ag.Nombre, ',', '') IN (" + cadenaAgenteWhere + "))"
                    '' ''End If

                    If whereConstruido.Length > 0 Then
                        whereConstruido += " " + radioYO + " " + " agt.IdAgente IN (" + cadenaAgenteWhere + ")"
                    Else
                        whereConstruido += " AND (agt.IdAgente IN (" + cadenaAgenteWhere + ")"
                    End If
                End If
            End If

            If Len(clasificacion) > 0 Then
                Dim arraycomillasClasificacion() As String, iClas As Int32, cadenaClasificacionWhere As String
                cadenaClasificacionWhere = "'0'"
                arraycomillasClasificacion = Strings.Split(clasificacion, ",")
                For iClas = 0 To UBound(arraycomillasClasificacion)
                    cadenaClasificacionWhere += ", '" + arraycomillasClasificacion(iClas) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " clf.clas_clasificacioclientenid IN (" + cadenaClasificacionWhere + ")"
                Else
                    whereConstruido += " AND (clf.clas_clasificacioclientenid IN (" + cadenaClasificacionWhere + ")"
                End If
            End If

            If Len(clientes) > 0 Then
                Dim arraycomillasClientes() As String, cadenaClienteWhere As String
                cadenaClienteWhere = "'0'"
                arraycomillasClientes = Strings.Split(clientes, ",")
                For iCli = 0 To UBound(arraycomillasClientes)
                    cadenaClienteWhere += ", '" + arraycomillasClientes(iCli) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " c.IdCadena IN (" + cadenaClienteWhere + ")"
                Else
                    whereConstruido += " AND (c.IdCadena IN (" + cadenaClienteWhere + ")"
                End If

            End If

            If Len(colecciones) > 0 Then
                Dim arraycomillasColecciones() As String, cadenaColeccionWhere As String
                cadenaColeccionWhere = "'0'"
                arraycomillasColecciones = Strings.Split(colecciones, ",")
                For iCol = 0 To UBound(arraycomillasColecciones)
                    cadenaColeccionWhere += ", '" + arraycomillasColecciones(iCol) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " REPLACE(prod.ColeccionSAY,',','') IN (" + cadenaColeccionWhere + ")"
                Else
                    whereConstruido += " AND (REPLACE(prod.ColeccionSAY,',','') IN (" + cadenaColeccionWhere + ")"
                End If

            End If

            If Len(marcas) > 0 Then
                Dim arraycomillasMarca() As String, cadenaMarcaWhere As String
                cadenaMarcaWhere = "'0'"
                arraycomillasMarca = Strings.Split(marcas, ",")
                For iMar = 0 To UBound(arraycomillasMarca)
                    cadenaMarcaWhere += ", '" + arraycomillasMarca(iMar) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " prod.MarcaSAY IN (" + cadenaMarcaWhere + ")"
                Else
                    whereConstruido += " AND (prod.MarcaSAY IN (" + cadenaMarcaWhere + ")"
                End If
            End If

            If Len(modelos) > 0 Then
                Dim arraycomillasModelo() As String, cadenaModeloWhere As String
                cadenaModeloWhere = "'0'"
                arraycomillasModelo = Strings.Split(modelos, ",")
                For idmod = 0 To UBound(arraycomillasModelo)
                    cadenaModeloWhere += ", '" + arraycomillasModelo(idmod) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " REPLACE(prod.MarcaSAY+ ' ' + prod.ModeloSICY, ',', '') IN (" + cadenaModeloWhere + ")"
                Else
                    whereConstruido += " AND (REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') IN (" + cadenaModeloWhere + ")"
                End If
            End If

            If Len(descripcion) > 0 Then
                Dim arraycomillasDescripcion() As String, cadenaDescripcionWhere As String
                cadenaDescripcionWhere = "'0'"
                arraycomillasDescripcion = Strings.Split(descripcion, ",")
                For iDesc = 0 To UBound(arraycomillasDescripcion)
                    cadenaDescripcionWhere += ", '" + arraycomillasDescripcion(iDesc) + "'"
                Next


                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " prod.CodigoSicy IN (" + cadenaDescripcionWhere + ")"
                Else
                    whereConstruido += " AND (prod.CodigoSicy IN (" + cadenaDescripcionWhere + ")"
                End If

            End If

            If Len(color) > 0 Then
                Dim arraycomillasColor() As String, cadenaColorWhere As String
                cadenaColorWhere = "'0'"
                arraycomillasColor = Strings.Split(clasificacion, ",")
                For iColor = 0 To UBound(arraycomillasColor)
                    cadenaColorWhere += ", '" + arraycomillasColor(iColor) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " prod.PielColor IN (" + cadenaColorWhere + ")"
                Else
                    whereConstruido += " AND (prod.PielColor IN (" + cadenaColorWhere + ")"
                End If
            End If

            Dim arrayFilas() As String
            arrayFilas = Strings.Split(filas, ",")
            Dim tamanoCamposFilas As Int32 = (CInt(UBound(arrayFilas))) + 1
            For contFila As Int32 = 0 To UBound(arrayFilas)
                If arrayFilas(contFila) = "optClasificacion" Then
                    filaClasificacion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " clf.clas_clasificacioclientenid"
                    Else
                        cadenaSelect += ", clf.clas_clasificacioclientenid"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " clf.clas_clasificacioclientenid"
                    Else
                        cadenaGroupBy += ", clf.clas_clasificacioclientenid"
                    End If


                ElseIf arrayFilas(contFila) = "optCliente" Then
                    filaCliente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.nombre"
                    Else
                        cadenaSelect += ", c.nombre"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.nombre"
                    Else
                        cadenaGroupBy += ", c.nombre"
                    End If

                ElseIf arrayFilas(contFila) = "optAgente" Then
                    filaAgente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " agt.Nombre as Agente "
                    Else
                        cadenaSelect += ", agt.Nombre as Agente "
                    End If

                    ' cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " agt.Nombre"
                    Else
                        cadenaGroupBy += ", agt.Nombre"
                    End If


                ElseIf arrayFilas(contFila) = "optMarca" Then
                    filaMarca = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.MarcaSAY"
                    Else
                        cadenaSelect += ", prod.MarcaSAY"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.MarcaSAY"
                    Else
                        cadenaGroupBy += ", prod.MarcaSAY"
                    End If

                ElseIf arrayFilas(contFila) = "optCategoria" Then
                    filaCategoria = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                    Else
                        cadenaSelect += ", prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.NaveDesarrollo"
                    Else
                        cadenaGroupBy += ", prod.NaveDesarrollo"
                    End If

                    If Len(categoria) > 0 Then
                        Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                        cadenaCategoriaWhere = "'0'"
                        arraycomillasCategoria = Strings.Split(categoria, ",")
                        For idmod = 0 To UBound(arraycomillasCategoria)
                            cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                        Else
                            whereConstruido += " AND ( prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                        End If

                    End If

                ElseIf arrayFilas(contFila) = "optColeccion" Then
                    filaColeccion = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                    Else
                        cadenaSelect += ",prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += "prod.MarcaSAY, prod.ColeccionSAY"
                    Else
                        cadenaGroupBy += ", prod.MarcaSAY, prod.ColeccionSAY"
                    End If

                ElseIf arrayFilas(contFila) = "optModelo" Then
                    filaModelo = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                    Else
                        cadenaSelect += ",REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.MarcaSAY, prod.ModeloSICY"
                    Else
                        cadenaGroupBy += ", prod.MarcaSAY, prod.ModeloSICY"
                    End If

                ElseIf arrayFilas(contFila) = "optDescripcion" Then
                    filaDescripcion = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.DescripcionCompleta"
                    Else
                        cadenaSelect += ", prod.DescripcionCompleta"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.DescripcionCompleta"
                    Else
                        cadenaGroupBy += ", prod.DescripcionCompleta"
                    End If

                ElseIf arrayFilas(contFila) = "optFamilia" Then

                    filaFamilia = True

                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.FamiliaProyeccion AS Familia"
                    Else
                        cadenaSelect += ", prod.FamiliaProyeccion AS Familia"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.FamiliaProyeccion"
                    Else
                        cadenaGroupBy += ", prod.FamiliaProyeccion"
                    End If

                    If Len(familias) > 0 Then
                        Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                        cadenaFamiliaWhere = "'0'"
                        arraycomillasFamilia = Strings.Split(familias, ",")
                        For idFam = 0 To UBound(arraycomillasFamilia)
                            cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                        Else
                            whereConstruido += " AND ( prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                        End If

                    End If

                ElseIf arrayFilas(contFila) = "optCorrida" Then
                    filaCorrida = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.Talla"
                    Else
                        cadenaSelect += ", prod.Talla"
                    End If
                    'cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.Talla"
                    Else
                        cadenaGroupBy += ", prod.Talla"
                    End If

                    If Len(corrida) > 0 Then
                        Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                        cadenaCorridaWhere = "'0'"
                        arraycomillasCorrida = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasCorrida)
                            cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " prod.Talla IN (" + cadenaCorridaWhere + ")"
                        Else
                            whereConstruido += " AND ( prod.Talla IN (" + cadenaCorridaWhere + ")"
                        End If
                    End If

                ElseIf arrayFilas(contFila) = "optColor" Then
                    filaColor = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.PielColor AS COLOR"
                    Else
                        cadenaSelect += ", prod.PielColor AS COLOR"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.PielColor"
                    Else
                        cadenaGroupBy += ", prod.PielColor"
                    End If

                ElseIf arrayFilas(contFila) = "optRuta" Then
                    filaRuta = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ruta_nombre  AS RUTA"
                    Else
                        cadenaSelect += ", ruta_nombre  AS RUTA"
                    End If
                    'cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ruta_nombre "
                    Else
                        cadenaGroupBy += ", ruta_nombre "
                    End If

                    If Len(ruta) > 0 Then
                        Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                        cadenaRutaWhere = "'0'"
                        arraycomillasRuta = Strings.Split(ruta, ",")
                        For iRuta = 0 To UBound(arraycomillasRuta)
                            cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + "ruta_rutasicyid  IN (" + cadenaRutaWhere + ")"
                        Else
                            whereConstruido += " AND ( ruta_rutasicyid  IN (" + cadenaRutaWhere + ")"
                        End If

                    End If

                End If
            Next contFila

            Dim arrayColumnas() As String
            arrayColumnas = Strings.Split(columnas, ",")
            Dim tamanoCamposColumnas As Int32 = (CInt(UBound(arrayColumnas))) + 1
            Dim columnasSeleccion As Int32 = UBound(arrayColumnas)
            For contColumna As Int32 = 0 To UBound(arrayColumnas)
                If arrayColumnas(contColumna) = "optClasificacion" Then
                    columnaClasificacion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " clf.clas_clasificacioclientenid"
                    Else
                        cadenaSelect += ", clf.clas_clasificacioclientenid"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " clf.clas_clasificacioclientenid"
                    Else
                        cadenaGroupBy += ", clf.clas_clasificacioclientenid"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by clf.clas_clasificacioclientenid"
                    Else
                        orderByConsulta += ", clf.clas_clasificacioclientenid"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCliente" Then
                    columnaCliente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " c.nombre"
                    Else
                        cadenaSelect += ", c.nombre"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " c.nombre"
                    Else
                        cadenaGroupBy += ", c.nombre"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by c.nombre"
                    Else
                        orderByConsulta += ", c.nombre"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optAgente" Then
                    columnaAgente = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " agt.Nombre as Agente "
                    Else
                        cadenaSelect += ", agt.Nombre as Agente "
                    End If
                    ' cadenaConsulta += " INNER JOIN Agentes a ON a.IdAgente =vt.idCatVendedor"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " agt.Nombre"
                    Else
                        cadenaGroupBy += ", agt.Nombre"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by agt.Nombre"
                    Else
                        orderByConsulta += ", agt.Nombre"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optMarca" Then
                    columnaMarca = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.MarcaSAY"
                    Else
                        cadenaSelect += ", prod.MarcaSAY"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.MarcaSAY"
                    Else
                        cadenaGroupBy += ", prod.MarcaSAY"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by prod.MarcaSAY"
                    Else
                        orderByConsulta += ", prod.MarcaSAY"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCategoria" Then
                    columnaCategoria = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                    Else
                        cadenaSelect += ", prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.NaveDesarrollo"
                    Else
                        cadenaGroupBy += ", prod.NaveDesarrollo"
                    End If
                    If Len(categoria) > 0 Then
                        Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                        cadenaCategoriaWhere = "'0'"
                        arraycomillasCategoria = Strings.Split(categoria, ",")
                        For idmod = 0 To UBound(arraycomillasCategoria)
                            cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                        Else
                            whereConstruido += " AND ( prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                        End If

                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by prod.NaveDesarrollo"
                    Else
                        orderByConsulta += ", prod.NaveDesarrollo"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optColeccion" Then
                    columnaColeccion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                    Else
                        cadenaSelect += ",prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += "prod.MarcaSAY, prod.ColeccionSAY"
                    Else
                        cadenaGroupBy += ", prod.MarcaSAY, prod.ColeccionSAY"
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by prod.ColeccionSAY"
                    Else
                        orderByConsulta += ", prod.ColeccionSAY"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optModelo" Then
                    columnaModelo = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                    Else
                        cadenaSelect += ",REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.MarcaSAY, prod.ModeloSICY"
                    Else
                        cadenaGroupBy += ", prod.MarcaSAY, prod.ModeloSICY"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by ModeloDesc"
                    Else
                        orderByConsulta += ", ModeloDesc"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optDescripcion" Then
                    columnaDescripcion = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.DescripcionCompleta"
                    Else
                        cadenaSelect += ", prod.DescripcionCompleta"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.DescripcionCompleta"
                    Else
                        cadenaGroupBy += ", prod.DescripcionCompleta"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by prod.DescripcionCompleta"
                    Else
                        orderByConsulta += ", prod.DescripcionCompleta"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optFamilia" Then
                    columnaFamilia = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.FamiliaProyeccion AS Familia"
                    Else
                        cadenaSelect += ", prod.FamiliaProyeccion AS Familia"
                    End If
                    If cadenaInnerVistaCategoriaFamilias = "" Then
                        cadenaInnerVistaCategoriaFamilias = "Contenido"
                        ' cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                    End If

                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.FamiliaProyeccion"
                    Else
                        cadenaGroupBy += ", prod.FamiliaProyeccion"
                    End If

                    If Len(familias) > 0 Then
                        Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                        cadenaFamiliaWhere = "'0'"
                        arraycomillasFamilia = Strings.Split(familias, ",")
                        For idFam = 0 To UBound(arraycomillasFamilia)
                            cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                        Else
                            whereConstruido += " AND ( prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by prod.FamiliaProyeccion"
                    Else
                        orderByConsulta += ", prod.FamiliaProyeccion"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optCorrida" Then
                    columnaCorrida = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.Talla"
                    Else
                        cadenaSelect += ", prod.Talla"
                    End If
                    'cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.Talla"
                    Else
                        cadenaGroupBy += ", prod.Talla"
                    End If

                    If Len(corrida) > 0 Then
                        Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                        cadenaCorridaWhere = "'0'"
                        arraycomillasCorrida = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasCorrida)
                            cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " prod.Talla IN (" + cadenaCorridaWhere + ")"
                        Else
                            whereConstruido += " AND ( prod.Talla IN (" + cadenaCorridaWhere + ")"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by prod.Talla"
                    Else
                        orderByConsulta += ", prod.Talla"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optColor" Then
                    columnaColor = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " prod.PielColor AS COLOR"
                    Else
                        cadenaSelect += ", prod.PielColor AS COLOR"
                    End If
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " prod.PielColor"
                    Else
                        cadenaGroupBy += ", prod.PielColor"
                    End If
                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by COLOR"
                    Else
                        orderByConsulta += ", COLOR"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                ElseIf arrayColumnas(contColumna) = "optRuta" Then
                    columnaRuta = True
                    If cadenaSelect = "SELECT" Then
                        cadenaSelect += " ruta_nombre  AS RUTA"
                    Else
                        cadenaSelect += ", ruta_nombre  AS RUTA"
                    End If
                    'cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                    If cadenaGroupBy = "" Then
                        cadenaGroupBy += " ruta_nombre "
                    Else
                        cadenaGroupBy += ", ruta_nombre "
                    End If

                    If Len(ruta) > 0 Then
                        Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                        cadenaRutaWhere = "'0'"
                        arraycomillasRuta = Strings.Split(corrida, ",")
                        For iCor = 0 To UBound(arraycomillasRuta)
                            cadenaRutaWhere += ", '" + arraycomillasRuta(iCor) + "'"
                        Next

                        If whereConstruido.Length > 0 Then
                            whereConstruido += " " + radioYO + " " + " ruta_rutasicyid  IN (" + cadenaRutaWhere + "))"
                        Else
                            whereConstruido += " AND ( ruta_rutasicyid  IN (" + cadenaRutaWhere + "))"
                        End If
                    End If

                    If orderByConsulta = "" Then
                        orderByConsulta = "Order by RUTA"
                    Else
                        orderByConsulta += ", RUTA"
                    End If
                    contColumnasConsulta = contColumnasConsulta + 1

                End If
            Next contColumna

            If opArticulos = True Or opColecciones = True Then

                For contColumnaTot As Int32 = 0 To UBound(arrayColumnas)
                    If arrayColumnas(contColumnaTot) = "optClasificacion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " clf.clas_clasificacioclientenid"
                        Else
                            totalCadenaGroupByColumnas += ", clf.clas_clasificacioclientenid"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " clf.clas_clasificacioclientenid"
                        Else
                            totalCadenaGroupByColumnas += ", clf.clas_clasificacioclientenid"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by clf.clas_clasificacioclientenid"
                        Else
                            totalCadenaGroupByColumnas += ", clf.clas_clasificacioclientenid"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCliente" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " c.nombre"
                        Else
                            totalesArticulosColeccionesColumnas += ", c.nombre"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " c.nombre"
                        Else
                            totalCadenaGroupByColumnas += ", c.nombre"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by c.nombre"
                        Else
                            totalorderByConsultaColumnas += ", c.nombre"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optAgente" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " agt.Nombre as Agente "
                        Else
                            totalesArticulosColeccionesColumnas += ", agt.Nombre as Agente "
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " agt.Nombre"
                        Else
                            totalCadenaGroupByColumnas += ", agt.Nombre"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by agt.Nombre"
                        Else
                            totalorderByConsultaColumnas += ", agt.Nombre"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optMarca" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.MarcaSAY"
                        Else
                            totalesArticulosColeccionesColumnas += ", prod.MarcaSAY"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.MarcaSAY"
                        Else
                            totalCadenaGroupByColumnas += ", prod.MarcaSAY"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by prod.MarcaSAY"
                        Else
                            totalorderByConsultaColumnas += ", prod.MarcaSAY"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCategoria" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                        Else
                            totalesArticulosColeccionesColumnas += ", prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.NaveDesarrollo"
                        Else
                            totalCadenaGroupByColumnas += ", prod.NaveDesarrollo"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by prod.NaveDesarrollo"
                        Else
                            totalorderByConsultaColumnas += ", prod.NaveDesarrollo"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optColeccion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                        Else
                            totalesArticulosColeccionesColumnas += ",prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += "prod.MarcaSAY, prod.ColeccionSAY"
                        Else
                            totalCadenaGroupByColumnas += ", prod.MarcaSAY, prod.ColeccionSAYn"
                        End If

                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by prod.ColeccionSAY"
                        Else
                            totalorderByConsultaColumnas += ", prod.ColeccionSAY"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optModelo" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                        Else
                            totalesArticulosColeccionesColumnas += ",REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.MarcaSAY, prod.ModeloSICY"
                        Else
                            totalCadenaGroupByColumnas += ", prod.MarcaSAY, prod.ModeloSICY"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by ModeloDesc"
                        Else
                            totalorderByConsultaColumnas += ", ModeloDesc"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optDescripcion" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.DescripcionCompleta"
                        Else
                            totalesArticulosColeccionesColumnas += ", prod.DescripcionCompleta"
                        End If

                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.DescripcionCompleta"
                        Else
                            totalCadenaGroupByColumnas += ", prod.DescripcionCompleta"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by prod.DescripcionCompleta"
                        Else
                            totalorderByConsultaColumnas += ", prod.DescripcionCompleta"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optFamilia" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.FamiliaProyeccion AS Familia"
                        Else
                            totalesArticulosColeccionesColumnas += ", prod.FamiliaProyeccion AS Familia"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.FamiliaProyeccion"
                        Else
                            totalCadenaGroupByColumnas += ", prod.FamiliaProyeccion"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by prod.FamiliaProyeccion"
                        Else
                            totalorderByConsultaColumnas += ", prod.FamiliaProyeccion"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optCorrida" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.Talla"
                        Else
                            totalesArticulosColeccionesColumnas += ", prod.Talla"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.Talla"
                        Else
                            totalCadenaGroupByColumnas += ", prod.Talla"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by prod.Talla"
                        Else
                            totalorderByConsultaColumnas += ", prod.Talla"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optColor" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " prod.PielColor AS COLOR"
                        Else
                            totalesArticulosColeccionesColumnas += ", prod.PielColor AS COLOR"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " prod.PielColor"
                        Else
                            totalCadenaGroupByColumnas += ", prod.PielColor"
                        End If
                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by COLOR"
                        Else
                            totalorderByConsultaColumnas += ", COLOR"
                        End If

                    ElseIf arrayColumnas(contColumnaTot) = "optRuta" Then
                        If totalesArticulosColeccionesColumnas = "" Then
                            totalesArticulosColeccionesColumnas += " ruta_nombre  AS RUTA"
                        Else
                            totalesArticulosColeccionesColumnas += ", ruta_nombre  AS RUTA"
                        End If
                        If totalCadenaGroupByColumnas = "" Then
                            totalCadenaGroupByColumnas += " ruta_nombre "
                        Else
                            totalCadenaGroupByColumnas += ", ruta_nombre "
                        End If

                        If totalorderByConsultaColumnas = "" Then
                            totalorderByConsultaColumnas = "Order by RUTA"
                        Else
                            totalorderByConsultaColumnas += ", RUTA"
                        End If

                    End If
                Next

                For contFilaTot As Int32 = 0 To UBound(arrayFilas)
                    If arrayFilas(contFilaTot) = "optClasificacion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " clf.clas_clasificacioclientenid"
                        Else
                            totalCadenaGroupByFilas += ", clf.clas_clasificacioclientenid"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " clf.clas_clasificacioclientenid"
                        Else
                            totalCadenaGroupByFilas += ", clf.clas_clasificacioclientenid"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by clf.clas_clasificacioclientenid"
                        Else
                            totalCadenaGroupByFilas += ", clf.clas_clasificacioclientenid"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCliente" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " c.nombre"
                        Else
                            totalesArticulosColeccionesFilas += ", c.nombre"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " c.nombre"
                        Else
                            totalCadenaGroupByFilas += ", c.nombre"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by c.nombre"
                        Else
                            totalorderByConsultaFilas += ", c.nombre"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optAgente" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " agt.Nombre as Agente "
                        Else
                            totalesArticulosColeccionesFilas += ", agt.Nombre as Agente "
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " agt.Nombre"
                        Else
                            totalCadenaGroupByFilas += ", agt.Nombre"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by agt.Nombre"
                        Else
                            totalorderByConsultaFilas += ", agt.Nombre"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optMarca" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.MarcaSAY"
                        Else
                            totalesArticulosColeccionesFilas += ", prod.MarcaSAY"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.MarcaSAY"
                        Else
                            totalCadenaGroupByFilas += ", prod.MarcaSAY"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by prod.MarcaSAY"
                        Else
                            totalorderByConsultaFilas += ", prod.MarcaSAY"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCategoria" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                        Else
                            totalesArticulosColeccionesFilas += ", prod.NaveDesarrollo as 'NAVE DESARROLLA'"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.NaveDesarrollo"
                        Else
                            totalCadenaGroupByFilas += ", prod.NaveDesarrollo"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by prod.NaveDesarrollo"
                        Else
                            totalorderByConsultaFilas += ", prod.NaveDesarrollo"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optColeccion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                        Else
                            totalesArticulosColeccionesFilas += ",prod.MarcaSAY+' '+prod.ColeccionSAY AS Coleccion"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += "prod.MarcaSAY, prod.ColeccionSAY"
                        Else
                            totalCadenaGroupByFilas += ", prod.MarcaSAY, prod.ColeccionSAY"
                        End If

                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by prod.ColeccionSAY"
                        Else
                            totalorderByConsultaFilas += ", prod.ColeccionSAY"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optModelo" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                        Else
                            totalesArticulosColeccionesFilas += ",REPLACE(prod.MarcaSAY + ' ' + prod.ModeloSICY, ',', '') AS ModeloDesc"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.MarcaSAY, prod.ModeloSICY"
                        Else
                            totalCadenaGroupByFilas += ", prod.MarcaSAY, prod.ModeloSICY"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by ModeloDesc"
                        Else
                            totalorderByConsultaFilas += ", ModeloDesc"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optDescripcion" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.DescripcionCompleta"
                        Else
                            totalesArticulosColeccionesFilas += ", prod.DescripcionCompleta"
                        End If

                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.DescripcionCompleta"
                        Else
                            totalCadenaGroupByFilas += ", prod.DescripcionCompleta"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by prod.DescripcionCompleta"
                        Else
                            totalorderByConsultaFilas += ", prod.DescripcionCompleta"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optFamilia" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.FamiliaProyeccion AS Familia"
                        Else
                            totalesArticulosColeccionesFilas += ", prod.FamiliaProyeccion AS Familia"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.FamiliaProyeccion"
                        Else
                            totalCadenaGroupByFilas += ", prod.FamiliaProyeccion"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by prod.FamiliaProyeccion"
                        Else
                            totalorderByConsultaFilas += ", prod.FamiliaProyeccion"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optCorrida" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.Talla"
                        Else
                            totalesArticulosColeccionesFilas += ", prod.Talla"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.Talla"
                        Else
                            totalCadenaGroupByFilas += ", prod.Talla"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by prod.Talla"
                        Else
                            totalorderByConsultaFilas += ", prod.Talla"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optColor" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " prod.PielColor AS COLOR"
                        Else
                            totalesArticulosColeccionesFilas += ", prod.PielColor AS COLOR"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " prod.PielColor"
                        Else
                            totalCadenaGroupByFilas += ", prod.PielColor"
                        End If
                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by COLOR"
                        Else
                            totalorderByConsultaFilas += ", COLOR"
                        End If

                    ElseIf arrayFilas(contFilaTot) = "optRuta" Then
                        If totalesArticulosColeccionesFilas = "" Then
                            totalesArticulosColeccionesFilas += " ruta_nombre  AS RUTA"
                        Else
                            totalesArticulosColeccionesFilas += ", ruta_nombre  AS RUTA"
                        End If
                        If totalCadenaGroupByFilas = "" Then
                            totalCadenaGroupByFilas += " ruta_nombre "
                        Else
                            totalCadenaGroupByFilas += ", ruta_nombre "
                        End If

                        If totalorderByConsultaFilas = "" Then
                            totalorderByConsultaFilas = "Order by RUTA"
                        Else
                            totalorderByConsultaFilas += ", RUTA"
                        End If

                    End If
                Next

            End If
            If Len(categoria) > 0 And filaCategoria = False And columnaCategoria = False Then
                If cadenaInnerVistaCategoriaFamilias = "" Then
                    cadenaInnerVistaCategoriaFamilias = "Contenido"
                    'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo AND vt.IdTalla=FC.talla_sicy"
                End If
                Dim arraycomillasCategoria() As String, cadenaCategoriaWhere As String
                cadenaCategoriaWhere = "'0'"
                arraycomillasCategoria = Strings.Split(categoria, ",")
                For idmod = 0 To UBound(arraycomillasCategoria)
                    cadenaCategoriaWhere += ", '" + arraycomillasCategoria(idmod) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                Else
                    whereConstruido += " AND ( prod.NaveDesarrollo IN (" + cadenaCategoriaWhere + ")"
                End If
            End If

            If Len(familias) > 0 And filaFamilia = False And columnaFamilia = False Then
                If cadenaInnerVistaCategoriaFamilias = "" Then
                    cadenaInnerVistaCategoriaFamilias = "Contenido"
                    'cadenaConsulta += " INNER JOIN VistaModeloCategoriaFamilia  as fc ON vt.IdCodigo = fc.IdCodigo  AND vt.IdTalla=FC.talla_sicy"
                End If

                Dim arraycomillasFamilia() As String, cadenaFamiliaWhere As String
                cadenaFamiliaWhere = "'0'"
                arraycomillasFamilia = Strings.Split(familias, ",")
                For idFam = 0 To UBound(arraycomillasFamilia)
                    cadenaFamiliaWhere += ", '" + arraycomillasFamilia(idFam) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                Else
                    whereConstruido += " AND ( prod.FamiliaProyeccion IN (" + cadenaFamiliaWhere + ")"
                End If
            End If


            If Len(corrida) > 0 And filaCorrida = False And columnaCorrida = False Then
                ' cadenaConsulta += " INNER JOIN Tallas t	ON vt.IdTalla = t.IdTalla"

                Dim arraycomillasCorrida() As String, cadenaCorridaWhere As String
                cadenaCorridaWhere = "'0'"
                arraycomillasCorrida = Strings.Split(corrida, ",")
                For iCor = 0 To UBound(arraycomillasCorrida)
                    cadenaCorridaWhere += ", '" + arraycomillasCorrida(iCor) + "'"
                Next

                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " prod.Talla IN (" + cadenaCorridaWhere + ")"
                Else
                    whereConstruido += " AND ( prod.Talla IN (" + cadenaCorridaWhere + ")"
                End If
            End If

            If Len(ruta) > 0 And filaRuta = False And columnaRuta = False Then
                ' cadenaConsulta += " INNER JOIN Rutas r ON c.IdRuta=r.IdRuta "
                Dim arraycomillasRuta() As String, cadenaRutaWhere As String
                cadenaRutaWhere = "'0'"
                arraycomillasRuta = Strings.Split(ruta, ",")
                For iRuta = 0 To UBound(arraycomillasRuta)
                    cadenaRutaWhere += ", '" + arraycomillasRuta(iRuta) + "'"
                Next
                If whereConstruido.Length > 0 Then
                    whereConstruido += " " + radioYO + " " + " ruta_rutasicyid  IN (" + cadenaRutaWhere + ")"
                Else
                    whereConstruido += " AND ( ruta_rutasicyid  IN (" + cadenaRutaWhere + ")"
                End If
            End If

            '---------------------------------------------------------------
            '---------------------------------------------------------------
            '---------------------------------------------------------------

            'MsgBox(cadenaConsulta)

            If whereConstruido.Length > 0 Then
                cadenaWhereConsulta += whereConstruido + ")"
            End If

            If opSuma = True Then
                cadenaSelect += ", SUM(factura.evpf_paresfacturados) AS PARES"
            End If
            If opColecciones = True Then
                cadenaSelect += ", COUNT(DISTINCT prod.MarcaSAY + prod.ColeccionSAY) AS COLECCIONES"
            End If
            If opArticulos = True Then
                cadenaSelect += ", COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS"
                ' ''cadenaGroupBy += ", ve.IdCodigo, vt.IdTalla"
            End If


            Dim cadenaFinal As String = ""
            Dim cadFinTotArtsColsColumnas As String = ""
            Dim cadFinTotArtsColsFilas As String = ""
            cadenaFinal = cadenaSelect + cadenaConsulta + cadenaWhereConsulta + "Group by " + cadenaGroupBy + " " + orderByConsulta

            If opColecciones = True Or opArticulos = True Then
                If opColecciones = True Then
                    cadFinTotArtsColsColumnas = "SELECT " + totalesArticulosColeccionesColumnas + ", COUNT(DISTINCT prod.MarcaSAY + prod.ColeccionSAY) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByColumnas + " " + totalorderByConsultaColumnas
                    cadFinTotArtsColsFilas = "SELECT " + totalesArticulosColeccionesFilas + ", COUNT(DISTINCT prod.MarcaSAY + prod.ColeccionSAY) AS COLECCIONES " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByFilas + " " + totalorderByConsultaFilas
                End If
                If opArticulos = True Then
                    cadFinTotArtsColsColumnas = "SELECT " + totalesArticulosColeccionesColumnas + ", COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByColumnas + " " + totalorderByConsultaColumnas
                    cadFinTotArtsColsFilas = "SELECT " + totalesArticulosColeccionesFilas + ", COUNT(DISTINCT prod.CodigoSicy+prod.IdTallaSicy) AS ARTICULOS " + cadenaConsulta + cadenaWhereConsulta + "Group by " + totalCadenaGroupByFilas + " " + totalorderByConsultaFilas
                End If

            End If


            Dim dtTablaContruida As New DataTable
            ' ''Dim cadenaSort As String = String.Empty

            For contFilaDT = 0 To UBound(arrayFilas)
                If arrayFilas(contFilaDT) = "optClasificacion" Then
                    dtTablaContruida.Columns.Add("CLASIFICACION")
                    dtTablaContruida.Columns("CLASIFICACION").Caption = "CLASIFICACIÓN"
                    'cadenaSort += "CLASIFICACION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCliente" Then
                    dtTablaContruida.Columns.Add("CLIENTE")
                    'cadenaSort += "CLIENTE ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optAgente" Then
                    dtTablaContruida.Columns.Add("AGENTE")
                    'cadenaSort += "AGENTE ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optMarca" Then
                    dtTablaContruida.Columns.Add("MARCA")
                    'cadenaSort += "MARCA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCategoria" Then
                    dtTablaContruida.Columns.Add("NAVE DESARROLLA")
                    dtTablaContruida.Columns("NAVE DESARROLLA").Caption = "NAVE DESARROLLA"
                    'cadenaSort += "CATEGORIA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optColeccion" Then
                    dtTablaContruida.Columns.Add("COLECCION")
                    dtTablaContruida.Columns("COLECCION").Caption = "COLECCIÓN"
                    'cadenaSort += "COLECCION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optModelo" Then
                    dtTablaContruida.Columns.Add("MODELO")
                    'cadenaSort += "MODELO ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optDescripcion" Then
                    dtTablaContruida.Columns.Add("DESCRIPCION")
                    dtTablaContruida.Columns("DESCRIPCION").Caption = "DESCRIPCIÓN"
                    'cadenaSort += "DESCRIPCION ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optFamilia" Then
                    dtTablaContruida.Columns.Add("FAMILIA")
                    'cadenaSort += "FAMILIA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optCorrida" Then
                    dtTablaContruida.Columns.Add("CORRIDA")
                    'cadenaSort += "CORRIDA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optColor" Then
                    dtTablaContruida.Columns.Add("COLOR")
                    'cadenaSort += "COLOR ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1

                ElseIf arrayFilas(contFilaDT) = "optRuta" Then
                    dtTablaContruida.Columns.Add("RUTA")
                    'cadenaSort += "RUTA ASC,"
                    contadorColumnasFila = contadorColumnasFila + 1
                End If
            Next contFilaDT

            'MsgBox(cadenaFinal)

            Dim dtDatosConsulta As New DataTable
            Dim contadorValidador As Int32 = 0
            dtDatosConsulta = operPersistencia.EjecutaConsulta(cadenaFinal)

            contadorValidador = dtDatosConsulta.Rows.Count
            If contadorValidador > 0 Then
                If opArticulos = True Or opColecciones = True Then
                    dtTotalesArticulosColumnas = operPersistencia.EjecutaConsulta(cadFinTotArtsColsColumnas)
                    dtTotalesArticulosFilas = operPersistencia.EjecutaConsulta(cadFinTotArtsColsFilas)
                End If

                Dim contNameColumna As Int32 = 0
                For Each rowdt As DataRow In dtDatosConsulta.Rows
                    dtTablaContruida.Columns.Add("columna" + contNameColumna.ToString)
                    contNameColumna = contNameColumna + 1
                Next

                For contFilaConcatena = 0 To UBound(arrayColumnas)
                    If arrayColumnas(contFilaConcatena) = "optClasificacion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Clasificacion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCliente" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("nombre").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optAgente" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Agente").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optMarca" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Marca").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCategoria" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("NAVE DESARROLLA").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optColeccion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Coleccion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optModelo" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("ModeloDesc").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optDescripcion" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Descripcion").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optFamilia" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Familia").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optCorrida" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Talla").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optColor" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Color").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)

                    ElseIf arrayColumnas(contFilaConcatena) = "optRuta" Then
                        Dim rowNv As DataRow = dtTablaContruida.NewRow()
                        Dim dato As Int32 = 0
                        For contcols = contadorColumnasFila To ((dtDatosConsulta.Rows.Count + contadorColumnasFila) - 1)
                            rowNv(contcols) = dtDatosConsulta.Rows(dato).Item("Ruta").ToString
                            dato = dato + 1
                        Next
                        dtTablaContruida.Rows.Add(rowNv)
                    End If
                Next

                For Each rowDTDT As DataRow In dtDatosConsulta.Rows
                    Dim filaNueva As DataRow = dtTablaContruida.NewRow

                    If filaClasificacion = True Then
                        filaNueva("CLASIFICACION") = rowDTDT.Item("Clasificacion").ToString

                    End If
                    If filaAgente = True Then
                        filaNueva("AGENTE") = rowDTDT.Item("Agente").ToString

                    End If
                    If filaCliente = True Then
                        filaNueva("CLIENTE") = rowDTDT.Item("nombre").ToString

                    End If
                    If filaMarca = True Then
                        filaNueva("MARCA") = rowDTDT.Item("Marca").ToString

                    End If
                    If filaColeccion = True Then
                        filaNueva("COLECCION") = rowDTDT.Item("Coleccion").ToString

                    End If
                    If filaCategoria = True Then
                        filaNueva("NAVE DESARROLLA") = rowDTDT.Item("NAVE DESARROLLA").ToString

                    End If
                    If filaModelo = True Then
                        filaNueva("MODELO") = rowDTDT.Item("ModeloDesc").ToString

                    End If
                    If filaDescripcion = True Then
                        filaNueva("DESCRIPCION") = rowDTDT.Item("Descripcion").ToString

                    End If
                    If filaFamilia = True Then
                        filaNueva("FAMILIA") = rowDTDT.Item("Familia").ToString

                    End If
                    If filaCorrida = True Then
                        filaNueva("CORRIDA") = rowDTDT.Item("Talla").ToString

                    End If
                    If filaColor = True Then
                        filaNueva("COLOR") = rowDTDT.Item("COLOR").ToString
                    End If

                    If filaRuta = True Then
                        filaNueva("RUTA") = rowDTDT.Item("RUTA").ToString
                    End If

                    Dim importarFila As Boolean = True

                    For Each roWdCT As DataRow In dtTablaContruida.Rows
                        Dim comparer As IEqualityComparer(Of DataRow) = DataRowComparer.Default
                        Dim bEqual = comparer.Equals(roWdCT, filaNueva)

                        If (bEqual = True) Then
                            importarFila = False
                        End If
                    Next

                    If importarFila = True Then
                        dtTablaContruida.Rows.Add(filaNueva)
                    End If
                Next

                For consCOl As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1
                    Dim esigual As Boolean = True
                    For Each rowdtCons As DataRow In dtTablaContruida.Rows
                        If rowdtCons.Item(consCOl).ToString <> rowdtCons.Item(consCOl - 1).ToString Then
                            esigual = False
                        End If
                    Next
                    If esigual = True Then
                        dtTablaContruida.Columns.RemoveAt(consCOl)
                    End If
                Next

                ' ''If filaRuta = True Then
                ' ''    For tamFils As Int32 = 0 To tamanoCamposFilas - 1
                ' ''        For consCol As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1
                ' ''            Dim contadorIgual As Int32 = 0
                ' ''            For consColDos As Int32 = dtTablaContruida.Columns.Count - 1 To contadorColumnasFila Step -1

                ' ''                If dtTablaContruida.Rows(tamFils).Item(consCol).ToString = dtTablaContruida.Rows(tamFils).Item(consColDos).ToString Then
                ' ''                    contadorIgual = contadorIgual + 1
                ' ''                End If
                ' ''            Next
                ' ''            If contadorIgual > 1 Then
                ' ''                dtTablaContruida.Columns.RemoveAt(consCol)
                ' ''            End If
                ' ''        Next
                ' ''    Next
                ' ''End If

                Dim contador As Int32 = 0
                For Each rowCNTRA As DataRow In dtTablaContruida.Rows
                    Dim columnaIncrusta As Int32 = 0

                    For Each rowCONS As DataRow In dtDatosConsulta.Rows
                        Dim esIgual As Boolean = True
                        If filaClasificacion = True Then
                            If rowCNTRA.Item("CLASIFICACION").ToString <> rowCONS.Item("Clasificacion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCliente = True Then
                            If rowCNTRA.Item("CLIENTE").ToString <> rowCONS.Item("nombre").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaAgente = True Then
                            If rowCNTRA.Item("AGENTE").ToString <> rowCONS.Item("Agente").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaMarca = True Then
                            If rowCNTRA.Item("MARCA").ToString <> rowCONS.Item("Marca").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCategoria = True Then
                            If rowCNTRA.Item("NAVE DESARROLLA").ToString <> rowCONS.Item("NAVE DESARROLLA").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaColeccion = True Then
                            If rowCNTRA.Item("COLECCION").ToString <> rowCONS.Item("Coleccion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaModelo = True Then
                            If rowCNTRA.Item("MODELO").ToString <> rowCONS.Item("ModeloDesc").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaDescripcion = True Then
                            If rowCNTRA.Item("DESCRIPCION").ToString <> rowCONS.Item("Descripcion").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaFamilia = True Then
                            If rowCNTRA.Item("FAMILIA").ToString <> rowCONS.Item("Familia").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaCorrida = True Then
                            If rowCNTRA.Item("CORRIDA").ToString <> rowCONS.Item("Talla").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaColor = True Then
                            If rowCNTRA.Item("COLOR").ToString <> rowCONS.Item("COLOR").ToString Then
                                esIgual = False
                            End If
                        End If
                        If filaRuta = True Then
                            If rowCNTRA.Item("RUTA").ToString <> rowCONS.Item("RUTA").ToString Then
                                esIgual = False
                            End If
                        End If

                        If esIgual = True Then
                            Dim incrustar As Boolean = True
                            contador = contador + 1
                            For Each columnCTR As DataColumn In dtTablaContruida.Columns
                                Dim dtCon As Int32 = 0
                                Dim inserta As Boolean = True
                                For dtfil As Int32 = tamanoCamposFilas To dtDatosConsulta.Columns.Count - 2
                                    Dim DAM As String = dtTablaContruida.Rows(dtCon).Item(columnCTR.ColumnName.ToString).ToString
                                    If rowCONS.Item(dtfil).ToString <> dtTablaContruida.Rows(dtCon).Item(columnCTR.ColumnName.ToString).ToString Then
                                        inserta = False
                                    End If
                                    dtCon = dtCon + 1
                                Next
                                If inserta = True Then
                                    If opSuma = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("PARES").ToString
                                    ElseIf opColecciones = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("COLECCIONES").ToString
                                    ElseIf opArticulos = True Then
                                        rowCNTRA.Item(columnCTR.ColumnName.ToString) = rowCONS.Item("ARTICULOS").ToString
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next

                ' '' ''Dim viewDtDatos As New DataView(dtTablaContruida)
                ' '' ''viewDtDatos.Sort = cadenaSort.Substring(0, cadenaSort.Length - 1)
                ' '' ''tablaDashBoard = viewDtDatos.ToTable

                tablaDashBoard = dtTablaContruida

                For contDTB As Int32 = 0 To tamanoCamposFilas - 1
                    tablaDashBoard.Rows(0).Item(contDTB) = dtTablaContruida.Columns(contDTB).Caption
                Next

                tablaDashBoard.Columns.Add("TOTAL")
                tablaDashBoard.Rows(0).Item("TOTAL") = "TOTAL"

                ' '' ''If opSuma = True Then
                tablaDashBoard.Rows.Add()
                Dim columnaTotal As Int32 = tablaDashBoard.Columns.Count - 1
                For contRowD As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                    Dim total As Int32 = 0
                    For contColD As Int32 = tamanoCamposFilas To tablaDashBoard.Columns.Count - 2
                        If tablaDashBoard.Rows(contRowD).Item(contColD).ToString.ToString <> "" Then
                            total = total + CInt(tablaDashBoard.Rows(contRowD).Item(contColD))
                        End If
                    Next
                    tablaDashBoard.Rows(contRowD).Item("TOTAL") = total
                Next

                Dim filaFinal As Int32 = tablaDashBoard.Rows.Count - 1
                For contColD As Int32 = tamanoCamposFilas To tablaDashBoard.Columns.Count - 1
                    Dim totalR As Int32 = 0

                    For contRowD As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                        If tablaDashBoard.Rows(contRowD).Item(contColD).ToString.ToString <> "" Then
                            totalR = totalR + CInt(tablaDashBoard.Rows(contRowD).Item(contColD))
                        End If
                    Next
                    tablaDashBoard.Rows(filaFinal).Item(contColD) = totalR
                Next
                tablaDashBoard.Rows(filaFinal).Item(0) = "TOTAL"

                ' '' ''ElseIf opArticulos = True Or opColecciones = True Then

                ' '' ''    For Each rowDtA As DataRow In tablaDashBoard.Rows
                ' '' ''        For Each rowDtB As DataRow In dtTotalesArticulosFilas.Rows
                ' '' ''            Dim insertar As Boolean = True
                ' '' ''            For columnaRd As Int32 = 0 To tamanoCamposFilas - 1
                ' '' ''                If rowDtA.Item(columnaRd).ToString <> rowDtB.Item(columnaRd).ToString Then
                ' '' ''                    insertar = False
                ' '' ''                End If
                ' '' ''            Next
                ' '' ''            If insertar = True Then
                ' '' ''                rowDtA.Item("TOTAL") = rowDtB.Item(tamanoCamposFilas).ToString
                ' '' ''            End If
                ' '' ''        Next
                ' '' ''    Next

                ' '' ''    Dim filaTotal As DataRow = tablaDashBoard.NewRow
                ' '' ''    For colDash As Int32 = tamanoCamposColumnas - 1 To tablaDashBoard.Columns.Count - 2
                ' '' ''        For Each rowDt As DataRow In dtTotalesArticulosColumnas.Rows
                ' '' ''            Dim insertar As Boolean = True
                ' '' ''            For colsSelect As Int32 = 0 To tamanoCamposColumnas - 1
                ' '' ''                If tablaDashBoard.Rows(colsSelect).Item(colDash).ToString <> rowDt.Item(colsSelect).ToString Then
                ' '' ''                    insertar = False
                ' '' ''                End If
                ' '' ''            Next
                ' '' ''            If insertar = True Then
                ' '' ''                filaTotal.Item(colDash) = rowDt.Item(tamanoCamposColumnas).ToString
                ' '' ''                Exit For
                ' '' ''            End If
                ' '' ''        Next
                ' '' ''    Next
                ' '' ''    filaTotal.Item(0) = "TOTAL"
                ' '' ''    tablaDashBoard.Rows.Add(filaTotal)

                ' '' ''End If


                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------

                Dim dtTablaOrdenada As New DataTable
                For contCol As Int32 = 0 To tablaDashBoard.Columns.Count - 1
                    If contCol = tablaDashBoard.Columns.Count - 1 Then
                        dtTablaOrdenada.Columns.Add(tablaDashBoard.Columns(contCol).ColumnName, Type.GetType("System.Int32"))
                    Else
                        dtTablaOrdenada.Columns.Add(tablaDashBoard.Columns(contCol).ColumnName)
                    End If
                Next

                For cont As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 2
                    dtTablaOrdenada.ImportRow(tablaDashBoard.Rows(cont))
                Next

                Dim viewDtDatos As New DataView(dtTablaOrdenada)
                viewDtDatos.Sort = tablaDashBoard.Columns(tablaDashBoard.Columns.Count - 1).ColumnName.ToString + " DESC"
                dtTablaOrdenada = New DataTable
                dtTablaOrdenada = viewDtDatos.ToTable

                Dim dtTraspaso As New DataTable
                For contCol As Int32 = 0 To tablaDashBoard.Columns.Count - 1
                    dtTraspaso.Columns.Add(tablaDashBoard.Columns(contCol).ColumnName)
                Next

                For iCont As Int32 = 0 To tamanoCamposColumnas - 1
                    dtTraspaso.ImportRow(tablaDashBoard.Rows(iCont))
                Next
                For Each rowDt As DataRow In dtTablaOrdenada.Rows
                    dtTraspaso.ImportRow(rowDt)
                Next
                dtTraspaso.ImportRow(tablaDashBoard.Rows(tablaDashBoard.Rows.Count - 1))


                tablaDashBoard = New DataTable
                tablaDashBoard = dtTraspaso
                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------
                ' ''-------------------------------------------------------------------

                tablaDashBoard.Columns.Add("index").SetOrdinal(0)


                Dim contFila As Int32 = 1
                For i As Int32 = 0 To tablaDashBoard.Rows.Count - 2
                    If i < tamanoCamposColumnas Then
                        tablaDashBoard.Rows(i).Item("index") = "#"
                    Else
                        tablaDashBoard.Rows(i).Item("index") = contFila
                        contFila += 1
                    End If

                Next

                Dim ultimaCol As Int32 = tablaDashBoard.Columns.Count - 1
                Dim ultimaFila As Int32 = tablaDashBoard.Rows.Count - 1
                Dim TotalVentas As Double = tablaDashBoard.Rows(ultimaFila).Item(ultimaCol)
                Dim porcentajeFila As Decimal = 0.0
                tablaDashBoard.Columns.Add("Porcentaje")
                tablaDashBoard.Columns("Porcentaje").Caption = "%"

                Dim contPorcent As Int32 = 1
                For x As Int32 = 0 To tamanoCamposColumnas - 1
                    tablaDashBoard.Rows(x).Item("Porcentaje") = "%"
                Next

                For rowTotal As Int32 = tamanoCamposColumnas To tablaDashBoard.Rows.Count - 1
                    porcentajeFila = (tablaDashBoard.Rows(rowTotal).Item(ultimaCol) * 100) / TotalVentas
                    tablaDashBoard.Rows(rowTotal).Item("Porcentaje") = porcentajeFila.ToString("N2") + "%"
                Next
                Dim porcentajeColumna As Decimal = 0.0
                Dim rowPorcent As DataRow
                rowPorcent = tablaDashBoard.NewRow
                For Each colDtp As DataColumn In tablaDashBoard.Columns
                    If IsNumeric(tablaDashBoard.Rows(ultimaFila).Item(colDtp.ColumnName.ToString)) And colDtp.ColumnName.ToString <> "index" Then
                        porcentajeColumna = (tablaDashBoard.Rows(ultimaFila).Item(colDtp) * 100) / TotalVentas
                        rowPorcent.Item(colDtp) = porcentajeColumna.ToString("N2") + "%"
                    Else
                        rowPorcent.Item(colDtp) = ""
                    End If
                Next
                rowPorcent.Item(1) = "%"
                tablaDashBoard.Rows.Add(rowPorcent)
            End If


        Catch ex As Exception
            Dim dtErrorCatch As New DataTable
            'dtErrorCatch.Columns.Add("Error")
            dtErrorCatch.Rows.Add()
            dtErrorCatch.Rows(0).Item(0) = "Error Inesperado del sistema vuelva a generar la consulta, Se recomienda usar filtros que optimicen la consulta."
            tablaDashBoard = dtErrorCatch
        End Try
        Return tablaDashBoard
    End Function

End Class
