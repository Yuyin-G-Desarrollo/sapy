Imports System.Data.SqlClient

Public Class productosCapacidadDA

    Public Function consultaProductosNave(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT prna_prnaID,	prna_naveID,prna_productoID, " & _
        " prna_productoEstiloID, prna_tallaID," & _
        " prna_capacidad, prna_hormaid" & _
        " FROM Programacion.ProductosNave" & _
        " WHERE prna_naveID = " + idNave.ToString & _
        " AND prna_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaProductosNaveCapacidad(ByVal idNave As Int32, ByVal idLinea As Int32, ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT prna_prnaID,	prna_naveID,prna_productoID, " & _
        " prna_productoEstiloID, prna_tallaID," & _
        " prna_capacidad, prna_hormaid" & _
        " FROM Programacion.ProductosNave" & _
        " WHERE prna_naveID = " + idNave.ToString & _
        " AND prna_prnaID NOT IN (SELECT proc_productonaveid " & _
        " FROM Programacion.ProductosCapacidad" & _
        " WHERE proc_linpID = " + idLinea.ToString & _
        " AND proc_año = " + anio.ToString + " )" & _
        " AND prna_activo = 1"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaProductosCelula(ByVal idNave As Int32, ByVal productoEstilo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT" & _
                            " lp.linp_linpID," & _
                            " n.nave_naveid," & _
                            " n.nave_nombre," & _
                            " lp.linp_nombre," & _
                            " lp.linp_capacidad_diaria," & _
                            " pc.proc_año," & _
                            " pc.proc_semanaelimina," & _
                            " pc.proc_activo" & _
                    " FROM Programacion.LineasProduccion lp" & _
                    " JOIN Programacion.ProductosCapacidad pc	ON pc.proc_linpID = lp.linp_linpID" & _
                    " JOIN Programacion.NavesAux n ON lp.linp_idNave = n.nave_naveid" & _
                            " WHERE lp.linp_activo = 1" & _
                    " AND n.nave_activo = 1" & _
                    " AND n.nave_naveid = " + idNave.ToString & _
                    " AND pc.proc_año >= DATEPART(YEAR, GETDATE())" & _
                    " AND pc.proc_productoEstiloId = " + productoEstilo & _
                    " ORDER BY linp_nombre, pc.proc_año"
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaProductosNuevosNOAsignados(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = <cadena>
                     SELECT CAST(0 AS BIT) AS Sel, prod_productoid ID, pstilo idEst, prod_codigo SAY, modeloSICY SICY, Sicy codSICY, idMarca, marca Marca, idColeccion, coleccion,
                idTemporada, temporada, idPiel, idColor, pielColor, idTalla,
                talla, idFamilia,
                idHorma, Horma, psEstatus, nomSts, pres_activo, fechaCreo
                FROM vProductoEstilos v JOIN Programacion.ProductosNave pn ON v.pstilo = pn.prna_productoEstiloID
                WHERE pn.prna_activo = 1 AND psEstatus IN (1, 2, 3)
                AND pn.prna_naveID = <%= idNave.ToString %>
                AND pstilo NOT IN (SELECT prnv_productoestiloid
                FROM Programacion.ProductoNuevo WHERE prnv_naveid = <%= idNave.ToString %> AND prnv_activo = 1)
                ORDER BY fechaCreo DESC</cadena>.Value

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaProductosNuevosAsignados(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = <cadena>
                SELECT CAST(0 AS BIT) AS Sel, pn.prnv_productonuevoid, prod_productoid ID, pstilo idEst, prod_codigo SAY, modeloSICY SICY, Sicy codSICY,
                nx.nave_naveid,	nx.nave_nombre, idMarca, marca Marca, idColeccion, coleccion, idTemporada, temporada, idPiel, idColor, pielColor, idTalla, talla,
                idFamilia, idHorma, Horma, psEstatus, nomSts, pres_activo, fechaCreo, pn.prnv_fechainicioproduccion AS fechaProd 
                FROM Programacion.ProductoNuevo pn
                JOIN vProductoEstilos v	ON pn.prnv_productoestiloid = v.pstilo
                JOIN Programacion.ProductosNave pv ON pn.prnv_productoestiloid = pv.prna_productoEstiloID
                JOIN Programacion.NavesAux nx ON pv.prna_naveID = nx.nave_naveid
                WHERE pn.prnv_activo = 1
                AND pv.prna_activo = 1
                AND v.pres_activo = 1     
                               </cadena>.Value
        If idNave > 0 Then
            cadena += " AND pn.prnv_naveid =" + idNave.ToString +
                " AND pv.prna_naveID = " + idNave.ToString
        End If
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub guardarProductoNuevo(ByVal idArticulo As Int32, ByVal idNave As Int32, ByVal fecha As Date)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
       
        Dim paramatro As New SqlParameter
        paramatro.ParameterName = "@idProductoEstilo"
        paramatro.Value = idArticulo
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idNave"
        paramatro.Value = idNave
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idUsuario"
        paramatro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@fechaProduccion"
        paramatro.Value = fecha
        listaparametros.Add(paramatro)

        operacion.EjecutarSentenciaSP("Programacion.SP_AltaProductoNuevo", listaparametros)
    End Sub

    Public Sub inactivarRegistroProductoNuevo(ByVal idProductoNuevo As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.ProductoNuevo SET prnv_activo = 0, prnv_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", prnv_fechamodifico = GETDATE()  WHERE prnv_productonuevoid = " + idProductoNuevo.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub cambiarFechaRegistroProductoNuevo(ByVal idProductoNuevo As Int32, ByVal fecha As Date)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.ProductoNuevo SET prnv_fechainicioproduccion = '" + fecha.ToShortDateString + "'" +
            ", prnv_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString +
            ", prnv_fechamodifico = GETDATE()  WHERE prnv_productonuevoid = " + idProductoNuevo.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Function consultaListaProductosCapacidadCopiar(ByVal idLinea As Int32, ByVal idHorma As Int32,
                                                          ByVal idTalla As Int32, ByVal idPstilo As Int32,
                                                          ByVal anio As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT TOP 1" & _
        " proc_procID, proc_linpID, proc_hormaid, proc_productoEstiloId, proc_tallaID, proc_prodID, proc_productonaveid," & _
        " proc_año, proc_activo, proc_1, proc_2, proc_3, proc_4, proc_5, proc_6, proc_7, proc_8," & _
        " proc_9, proc_10, proc_11, proc_12, proc_13, proc_14, proc_15, proc_16, proc_17, proc_18, proc_19, proc_20," & _
        " proc_21, proc_22, proc_23, proc_24, proc_25, proc_26, proc_27, proc_28, proc_29, proc_30, proc_31, proc_32," & _
        " proc_33, proc_34, proc_35, proc_36, proc_37, proc_38, proc_39, proc_40, proc_41, proc_42, proc_43, proc_44," & _
        " proc_45, proc_46, proc_47, proc_48, proc_49, proc_50, proc_51, proc_52" & _
        " FROM Programacion.ProductosCapacidad" & _
        " WHERE proc_activo = 1"
        If idLinea > 0 Then
            cadena += " AND proc_linpID = " + idLinea.ToString
        End If

 cadena +=       " AND proc_hormaid = " + idHorma.ToString & _
        " AND proc_tallaID = " + idTalla.ToString & _
        " AND proc_productoEstiloId = " + idPstilo.ToString & _
        " AND proc_año = " + anio.ToString
        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function insertarCapacidadSimulador(ByVal idLinea As Int32, ByVal tipoAlta As Int32, ByVal idCopia As Int32,
                                          ByVal idCambio As Int32, ByVal idSimulacion As Int32,
                                          ByVal entPrdsCap As Entidades.ProductoCapacidad) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim paramatro As New SqlParameter
        paramatro.ParameterName = "@idLinea"
        paramatro.Value = idLinea
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idHorma"
        paramatro.Value = entPrdsCap.HormaId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idProductoEstilo"
        paramatro.Value = entPrdsCap.ProductoEstiloId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idTalla"
        paramatro.Value = entPrdsCap.TallaId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idProducto"
        paramatro.Value = entPrdsCap.ProductoId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@tipoAlta"
        paramatro.Value = tipoAlta

        listaparametros.Add(paramatro)
        paramatro = New SqlParameter
        paramatro.ParameterName = "@Anio"
        paramatro.Value = entPrdsCap.Anio
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idSimulacion"
        paramatro.Value = idSimulacion
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idCopia"
        If idCopia > 0 Then
            paramatro.Value = idCopia
        Else
            paramatro.Value = DBNull.Value
        End If
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@idCambio"
        If idCambio > 0 Then
            paramatro.Value = idCambio
        Else
            paramatro.Value = DBNull.Value
        End If
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana1"
        paramatro.Value = entPrdsCap.Semana1
        listaparametros.Add(paramatro)
      
        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana2"
        paramatro.Value = entPrdsCap.Semana2
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana3"
        paramatro.Value = entPrdsCap.Semana3
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana4"
        paramatro.Value = entPrdsCap.Semana4
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana5"
        paramatro.Value = entPrdsCap.Semana5
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana6"
        paramatro.Value = entPrdsCap.Semana6
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana7"
        paramatro.Value = entPrdsCap.Semana7
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana8"
        paramatro.Value = entPrdsCap.Semana8
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana9"
        paramatro.Value = entPrdsCap.Semana9
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana10"
        paramatro.Value = entPrdsCap.Semana10
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana11"
        paramatro.Value = entPrdsCap.Semana11
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana12"
        paramatro.Value = entPrdsCap.Semana12
        listaparametros.Add(paramatro)
        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana13"
        paramatro.Value = entPrdsCap.Semana13
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana14"
        paramatro.Value = entPrdsCap.Semana14
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana15"
        paramatro.Value = entPrdsCap.Semana15
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana16"
        paramatro.Value = entPrdsCap.Semana16
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana17"
        paramatro.Value = entPrdsCap.Semana17
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana18"
        paramatro.Value = entPrdsCap.Semana18
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana19"
        paramatro.Value = entPrdsCap.Semana19
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana20"
        paramatro.Value = entPrdsCap.Semana20
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana21"
        paramatro.Value = entPrdsCap.Semana21
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana22"
        paramatro.Value = entPrdsCap.Semana22
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana23"
        paramatro.Value = entPrdsCap.Semana23
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana24"
        paramatro.Value = entPrdsCap.Semana24
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana25"
        paramatro.Value = entPrdsCap.Semana25
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana26"
        paramatro.Value = entPrdsCap.Semana26
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana27"
        paramatro.Value = entPrdsCap.Semana27
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana28"
        paramatro.Value = entPrdsCap.Semana28
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana29"
        paramatro.Value = entPrdsCap.Semana29
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana30"
        paramatro.Value = entPrdsCap.Semana30
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana31"
        paramatro.Value = entPrdsCap.Semana31
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana32"
        paramatro.Value = entPrdsCap.Semana32
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana33"
        paramatro.Value = entPrdsCap.Semana33
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana34"
        paramatro.Value = entPrdsCap.Semana34
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana35"
        paramatro.Value = entPrdsCap.Semana35
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana36"
        paramatro.Value = entPrdsCap.Semana36
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana37"
        paramatro.Value = entPrdsCap.Semana37
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana38"
        paramatro.Value = entPrdsCap.Semana38
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana39"
        paramatro.Value = entPrdsCap.Semana39
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana40"
        paramatro.Value = entPrdsCap.Semana40
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana41"
        paramatro.Value = entPrdsCap.Semana41
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana42"
        paramatro.Value = entPrdsCap.Semana42
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana43"
        paramatro.Value = entPrdsCap.Semana43
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana44"
        paramatro.Value = entPrdsCap.Semana44
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana45"
        paramatro.Value = entPrdsCap.Semana45
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana46"
        paramatro.Value = entPrdsCap.Semana46
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana47"
        paramatro.Value = entPrdsCap.Semana47
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana48"
        paramatro.Value = entPrdsCap.Semana48
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana49"
        paramatro.Value = entPrdsCap.Semana49
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana50"
        paramatro.Value = entPrdsCap.Semana50
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana51"
        paramatro.Value = entPrdsCap.Semana51
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Semana52"
        paramatro.Value = entPrdsCap.Semana52
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@Usuario"
        paramatro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString
        listaparametros.Add(paramatro)


        Return operacion.EjecutarConsultaSP("Programacion.SP_InsertarCapacidadProductoSimulador", listaparametros)
    End Function

    Public Function consultaArticulosConfigurados(ByVal idSimulacion As Int32, ByVal idLinea As Int32, ByVal idLineaOrigen As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "SELECT" & _
        " CAST(0 AS bit) as Sel," & _
        " sm.smac_articuloCapacidadId AS articuloCapacidadId," & _
        " sm.smac_hormaid AS horma," & _
        " sm.smac_productoEstiloId AS IdPstilo," & _
        " sm.smac_tallaID AS talla," & _
        " sm.smac_productoId AS IdProducto," & _
        " sm.smac_tipoAlta AS tipoAlta," & _
        " sm.smac_anio AS anio," & _
        " ISNULL(sm.smac_artiuloCapacidadCopiaId,sm.smac_articuloCapacidadCambioId) AS IdLineaOrigen," & _
        " vp.prod_codigo AS codigo," & _
        " vp.prod_descripcion +' ' + vp.pielColor+ ' ' +vp.talla as Descripcion," & _
        " sm.smac_1 AS sm1, sm.smac_2 AS sm2, sm.smac_3 AS sm3, sm.smac_4 AS sm4, sm.smac_5 AS sm5," & _
        " sm.smac_6 AS sm6, sm.smac_7 AS sm7, sm.smac_8 AS sm8, sm.smac_9 AS sm9, sm.smac_10 AS sm10," & _
        " sm.smac_11 AS sm11, sm.smac_12 AS sm12, sm.smac_13 AS sm13, sm.smac_14 AS sm14, sm.smac_15 AS sm15," & _
        " sm.smac_16 AS sm16, sm.smac_17 AS sm17, sm.smac_18 AS sm18, sm.smac_19 AS sm19, sm.smac_20 AS sm20," & _
        " sm.smac_21 AS sm21, sm.smac_22 AS sm22, sm.smac_23 AS sm23, sm.smac_24 AS sm24, sm.smac_25 AS sm25," & _
        " sm.smac_26 AS sm26, sm.smac_27 AS sm27, sm.smac_28 AS sm28, sm.smac_29 AS sm29, sm.smac_30 AS sm30," & _
        " sm.smac_31 AS sm31, sm.smac_32 AS sm32, sm.smac_33 AS sm33, sm.smac_34 AS sm34, sm.smac_35 AS sm35," & _
        " sm.smac_36 AS sm36, sm.smac_37 AS sm37, sm.smac_38 AS sm38, sm.smac_39 AS sm39, sm.smac_40 AS sm40," & _
        " sm.smac_41 AS sm41, sm.smac_42 AS sm42, sm.smac_43 AS sm43, sm.smac_44 AS sm44, sm.smac_45 AS sm45," & _
        " sm.smac_46 AS sm46, sm.smac_47 AS sm47, sm.smac_48 AS sm48, sm.smac_49 AS sm49, sm.smac_50 AS sm50," & _
        " sm.smac_51 AS sm51, sm.smac_52 AS sm52" & _
        " FROM Programacion.simulacionArticuloCapacidad sm JOIN vProductoEstilos vp " & _
        " ON sm.smac_productoEstiloId = vp.pstilo" & _
                " WHERE smac_activo = 1" & _
        " AND smac_simulacionId = " + idSimulacion.ToString
        If idLinea > 0 Then
            cadena += " AND smac_lineaId = " + idLinea.ToString
        End If

        If idLineaOrigen > 0 Then
            cadena += " AND (sm.smac_artiuloCapacidadCopiaId = " + idLineaOrigen.ToString + " OR sm.smac_articuloCapacidadCambioId = " + idLineaOrigen.ToString + ")"
        End If
        cadena += " ORDER BY vp.prod_codigo, talla"

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Function consultaOrdenProductoNaveSimulacion(ByVal idSimulacion As Int32,
                                                        ByVal idPEstilo As Int32,
                                                        ByVal existe As Boolean,
                                                        ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        If existe = True Then
            cadena = " SELECT" & _
          " oran_ordenArtNaveSimId AS ordenArtNaveSimId," & _
          " oran_simulacionId AS simulacionId," & _
          " oran_productoEstiloId AS productoEstiloId," & _
          " nx.nave_nombre nave," & _
          " oran_naveId AS naveId," & _
          " oran_orden AS orden" & _
          " FROM Programacion.OrdenArticuloNaveSimulacion a" & _
          " JOIN Programacion.NavesAux nx on a.oran_naveId = nx.nave_naveid" & _
          " WHERE oran_activo = 1 AND oran_simulacionId = " + idSimulacion.ToString & _
          " AND oran_productoEstiloId  = " + idPEstilo.ToString
            If idNave > 0 Then
                cadena += " AND nx.nave_naveid =  " + idNave.ToString
            End If
            cadena += " ORDER BY oran_orden"

        Else
            cadena = "SELECT" & _
                " 0 AS ordenArtNaveSimId," & _
                " 0 AS simulacionId," & _
                " prna_productoEstiloID AS productoEstiloId," & _
                " nx.nave_nombre nave," & _
                " prna_naveID AS naveId," & _
                " prna_orden AS orden" & _
                    " FROM Programacion.ProductosNave a" & _
                " JOIN Programacion.NavesAux nx on a.prna_naveID = nx.nave_naveid" & _
                    " WHERE prna_productoEstiloID = " + idPEstilo.ToString & _
            " ORDER BY prna_orden"
        End If

        Return operacion.EjecutaConsulta(cadena)
    End Function

    Public Sub insertarOrdenArticuloNaveSimulacion(ByVal simulacionId As Int32,
                                                   ByVal productoEstiloId As Int32,
                                                   ByVal naveId As Int32,
                                                   ByVal orden As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim paramatro As New SqlParameter
        paramatro.ParameterName = "@simulacionId"
        paramatro.Value = simulacionId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@productoEstiloId"
        paramatro.Value = productoEstiloId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@naveId"
        paramatro.Value = naveId
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@orden"
        paramatro.Value = orden
        listaparametros.Add(paramatro)

        paramatro = New SqlParameter
        paramatro.ParameterName = "@usuario"
        paramatro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaparametros.Add(paramatro)
       
        operacion.EjecutarSentenciaSP("Programacion.SP_guardarOrdenArticuloSimulacion", listaparametros)
    End Sub

    Public Sub editarOrdenNaveArticuloSimulacion(ByVal idOrdNvArtSim As Int32, ByVal orden As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.OrdenArticuloNaveSimulacion SET oran_orden = " + orden.ToString & _
        ", oran_usuarioModifico = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
        ", oran_fechaModifico = GETDATE()" & _
        " WHERE oran_ordenArtNaveSimId = " + idOrdNvArtSim.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub inactivarArticuloCapacidadSimulacion(ByVal idSimArtCapacidad As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.simulacionArticuloCapacidad SET smac_activo = 0" & _
            ", smac_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
            ", smac_fechamodificacion = GETDATE() WHERE smac_articuloCapacidadId = " + idSimArtCapacidad.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarCapacidadArticuloSimulacion(ByVal idSimCapArticulo As Int32,
                                                 ByVal semanaInicio As Int32,
                                                 ByVal semanaFin As Int32,
                                                 ByVal cantidad As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.simulacionArticuloCapacidad SET smac_fechamodificacion = GETDATE() "
        For i As Int32 = semanaInicio To semanaFin
            cadena += ", smac_" + i.ToString + " = " + cantidad.ToString
        Next
        cadena += ", smac_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
                " WHERE smac_articuloCapacidadId = " + idSimCapArticulo.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub

    Public Sub editarTipoAltaCapacidadArticuloSimulacion(ByVal idSimCapArticulo As Int32,
                                                 ByVal idTipoAlta As Int32,
                                                 ByVal idLineaOrigen As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = ""
        cadena = "UPDATE Programacion.simulacionArticuloCapacidad" & _
        " SET smac_usuariomodificoid = " + Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString & _
        ", smac_fechamodificacion = GETDATE()"
        If idLineaOrigen = 0 Then
            idTipoAlta = 3
        End If
        cadena += ", smac_tipoAlta = " + idTipoAlta.ToString
        If idTipoAlta = 1 Then
            cadena += ", smac_artiuloCapacidadCopiaId = " + idLineaOrigen.ToString & _
            ", smac_articuloCapacidadCambioId = NULL"
        ElseIf idTipoAlta = 2 Then
            cadena += ", smac_artiuloCapacidadCopiaId = NULL" & _
        ", smac_articuloCapacidadCambioId = " + idLineaOrigen.ToString
        ElseIf idTipoAlta = 3 Then
            cadena += ", smac_artiuloCapacidadCopiaId = NULL" & _
          ", smac_articuloCapacidadCambioId = NULL"
        End If
        cadena += " WHERE smac_articuloCapacidadId = " + idSimCapArticulo.ToString
        operacion.EjecutaSentencia(cadena)
    End Sub


End Class