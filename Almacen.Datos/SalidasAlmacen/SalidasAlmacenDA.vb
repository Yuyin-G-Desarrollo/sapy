Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class SalidasAlmacenDA

    Public Function ListadoParametroSalidas(tipo_busqueda As Integer) As DataTable

        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        If tipo_busqueda = 1 Then 'Mensajeria Real
            consulta += " select prov_proveedorid AS 'Parámetro', CAST(0 AS BIT) AS ' ', prov_proveedorid AS 'ID', prov_nombregenerico AS 'Nombre' from Proveedor.Proveedor where prov_clasificacionpersonaid IN"
            consulta += " (select clpe_clasificacionpersonaid from Framework.ClasificacionPersona where clpe_nombre like '%PROVEEDOR DE MENSAJERÍA%')"
            consulta += " and prov_activo=1 order by prov_nombregenerico"
        Else
            If tipo_busqueda = 2 Then 'Clientes
                'consulta += " SELECT IdCadena AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdCadena AS 'Cadena', nombre AS 'Nombre' FROM vCadenas  WHERE Activo = 'S' ORDER BY nombre "
                parametro = New SqlParameter
                parametro.ParameterName = "@ColaboradorID"
                parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
                listaParametros.Add(parametro)

                Return operaciones.EjecutarConsultaSP("[Almacen].[SP_EmbarquesSalidasProducto_ConsultarCadenasClientes]", listaParametros)
            Else
                If tipo_busqueda = 3 Then 'Mensajeria de la factura
                    consulta += " SELECT IdMensajeria AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdMensajeria AS 'ID', nombre AS 'Mensajeria' FROM Mensajeria "
                Else
                    If tipo_busqueda = 4 Then 'Naves
                        consulta += " SELECT IdNave AS 'Parámetro', CAST(0 AS BIT) AS ' ', Nave AS 'Nave' FROM Naves WHERE Activo = 1 ORDER BY Nave"
                    Else
                        If tipo_busqueda = 5 Then 'Tiendas
                            'consulta += " SELECT IdDistribucion AS 'Parámetro', CAST(0 AS BIT) AS ' ', IdDistribucion AS 'ID', cadena AS 'Cliente', distribucion AS 'Tienda', ciudad AS 'Ciudad' " +
                            '                        " FROM vCadenasDistribucion" +
                            '                        " ORDER BY cliente, distribucion, Ciudad"
                            parametro = New SqlParameter
                            parametro.ParameterName = "@ColaboradorID"
                            parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
                            listaParametros.Add(parametro)

                            Return operaciones.EjecutarConsultaSP("[Almacen].[Sp_EmbarquesSalidasProducto_COnsultarTiendasClientes]", listaParametros)
                        Else
                            If tipo_busqueda = 6 Then 'Productos
                                consulta += " SELECT IdCodigo AS 'Parámetro',  CAST(0 AS BIT) AS ' ', IdModelo AS 'Modelo',Descripcion AS 'Descripción', Color AS 'Color', Coleccion AS 'Colección', Marca AS 'Marca' FROM vEstilos ORDER BY Descripcion, IdModelo, Color "
                            Else
                                If tipo_busqueda = 7 Then 'Corridas
                                    consulta += " SELECT IdTalla AS 'Parámetro', CAST(0 AS BIT) AS ' ' , IdTalla AS 'Talla ID', Talla AS 'Talla' FROM tallas ORDER BY Talla "
                                Else
                                    If tipo_busqueda = 8 Then 'Tallas
                                        consulta += " SELECT calc_calce AS 'Parámetro', CAST(0 AS BIT) AS ' ', calc_calce AS 'Talla'" +
                                                     " FROM Programacion.Calce" +
                                                     " WHERE calc_activo = 1" +
                                                     " ORDER BY calc_calce"
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        If tipo_busqueda = 1 Then
            Return operaciones.EjecutaConsulta(consulta)
        Else
            Return operaciones_sicy.EjecutaConsulta(consulta)
        End If


    End Function

    Public Function LlenarCombosGenerarEntrega(tipo_busqueda As Integer) As DataTable
        Dim dtInformacionCentroDistribucion As DataTable
        Dim operaciones_sicy As New Persistencia.OperacionesProcedimientosSICY
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter


        'Mensajeria Real
        If tipo_busqueda = 1 Then
            consulta += " select prov_proveedorid AS ID,  LTRIM(RTRIM(prov_nombregenerico  )) AS Nombre from Proveedor.Proveedor where prov_clasificacionpersonaid IN"
            consulta += " (select clpe_clasificacionpersonaid from Framework.ClasificacionPersona where clpe_nombre like '%PROVEEDOR DE MENSAJERÍA%')"
            consulta += " and prov_activo=1 order by prov_nombregenerico"
        Else
            If tipo_busqueda = 2 Then 'Operadores

                Dim comecializadora As String = String.Empty

                parametro.ParameterName = "UsuarioID"
                parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                listaParametros.Add(parametro)

                dtInformacionCentroDistribucion = operaciones_sicy.EjecutarConsultaSP("[Almacen].[SP_Almacen_ConsultaAlmacenesActivos_Usuario]", listaParametros)

                If dtInformacionCentroDistribucion.Rows.Count > 0 Then
                    For index = 0 To dtInformacionCentroDistribucion.Rows.Count - 1
                        comecializadora = dtInformacionCentroDistribucion.Rows(index).Item("NaveSAYID").ToString
                    Next
                End If

                If dtInformacionCentroDistribucion.Rows.Count > 1 Then
                    consulta += " SELECT A.codr_colaboradorid AS ID , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS Operador 
                                    FROM Nomina.Colaborador AS A 
                                    JOIN Nomina.ColaboradorLaboral AS B ON B.labo_colaboradorid = A.codr_colaboradorid 
                                    JOIN Framework.Grupos AS C ON C.grup_grupoid = B.labo_departamentoid 
                                    WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 or C.grup_grupoid = 327  ORDER BY A.codr_nombre "
                Else
                    If comecializadora.Equals("43") Then
                        consulta += " SELECT A.codr_colaboradorid AS ID , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS Operador 
                                    FROM Nomina.Colaborador AS A 
                                    JOIN Nomina.ColaboradorLaboral AS B ON B.labo_colaboradorid = A.codr_colaboradorid 
                                    JOIN Framework.Grupos AS C ON C.grup_grupoid = B.labo_departamentoid 
                                    WHERE A.codr_activo = 1 AND C.grup_grupoid = 97 ORDER BY A.codr_nombre "
                    Else
                        consulta += " SELECT A.codr_colaboradorid AS ID , CAST(A.codr_nombre + ' ' + A.codr_apellidopaterno + ' ' + A.codr_apellidomaterno AS varchar(200)) AS Operador 
                                    FROM Nomina.Colaborador AS A 
                                    JOIN Nomina.ColaboradorLaboral AS B ON B.labo_colaboradorid = A.codr_colaboradorid 
                                    JOIN Framework.Grupos AS C ON C.grup_grupoid = B.labo_departamentoid 
                                    WHERE A.codr_activo = 1 AND C.grup_grupoid = 327 ORDER BY A.codr_nombre "
                    End If
                End If

            Else
                If tipo_busqueda = 3 Then 'Unidades
                    consulta += "SELECT idcat AS ID, nomcat AS Unidad FROM catalogos where tipcat = 43 "
                Else
                    If tipo_busqueda = 4 Then 'Tipos de incidencia
                        consulta += "  select svti_salidaventastipoincidenciaid as ID, UPPER(svti_tipoincidencia) as TipoIncidencia FROM Almacen.SalidaVentas_TipoIncidencia ORDER BY svti_tipoincidencia ASC"
                    End If
                End If
            End If
        End If

        If tipo_busqueda < 3 Then
            Return operaciones.EjecutaConsulta(consulta)
        Else
            Return operaciones_sicy.EjecutaConsulta(consulta)
        End If


    End Function

    Public Function consultaGenerarEmbarques(ByVal FiltrosSalidas As Entidades.FiltrosSalidas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = FiltrosSalidas.PTipoConsulta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Agrupamiento"
        parametro.Value = FiltrosSalidas.PAgrupamiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SepararTienda"
        parametro.Value = FiltrosSalidas.PSepararTienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Status"
        parametro.Value = FiltrosSalidas.PStatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PrimeraFechaDel"
        parametro.Value = FiltrosSalidas.PPrimeraFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PrimeraFechaAl"
        parametro.Value = FiltrosSalidas.PPrimeraFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SegundaFechaDel"
        parametro.Value = FiltrosSalidas.PSegundaFechaDel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SegundaFechaAl"
        parametro.Value = FiltrosSalidas.PSegundaFechaAl
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cliente"
        parametro.Value = FiltrosSalidas.PCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FolioEmbarque"
        parametro.Value = FiltrosSalidas.PFolioEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PedidoSiCY"
        parametro.Value = FiltrosSalidas.PPedidoSiCY
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "OrdenTrabajo"
        parametro.Value = FiltrosSalidas.POrdenTrabajo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Mensajeria"
        parametro.Value = FiltrosSalidas.PMensajeria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsYISTI"
        parametro.Value = FiltrosSalidas.PEsYISTI
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corridas"
        parametro.Value = FiltrosSalidas.PCorridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cedis"
        parametro.Value = FiltrosSalidas.PCedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_ConsultaGenerarEmbarques_v2", listaParametros)

    End Function

    Public Function consultaParesEmbarques(ByVal idSalidasPares As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idSalidasPares"
        parametro.Value = idSalidasPares
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_ConsultarParesEmbarques", listaParametros)

    End Function

    Public Function generarEmbarques(ByVal datosEmbarque As Entidades.GeneracionEmbarque) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idDetalle"
        parametro.Value = datosEmbarque.PIdDetalleEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioEmbarque"
        parametro.Value = datosEmbarque.PUsuarioEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "operadorEmbarqueid"
        parametro.Value = datosEmbarque.POperadorEmbarqueId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "operadorEmbarquenombre"
        parametro.Value = datosEmbarque.POperadorEmbarqueNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "mensajeriarealid"
        parametro.Value = datosEmbarque.PMensajeriaRealId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "mensajeriarealnombre"
        parametro.Value = datosEmbarque.PMensajeriaRealNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "unidadEmbarqueId"
        parametro.Value = datosEmbarque.PUnidadEmbarqueId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "unidadEmbarqueNombre"
        parametro.Value = datosEmbarque.PUnidadEmbarqueNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadParesEmbarque"
        parametro.Value = datosEmbarque.PCantidadParesEmbarque
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_GenerarEmbarques", listaParametros)

    End Function

    Public Function generarSalida(ByVal datosSalida As Entidades.GeneracionSalida) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idDetalle"
        parametro.Value = datosSalida.PIdDetalleEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioSalida"
        parametro.Value = datosSalida.PUsuarioSalida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadParesSalida"
        parametro.Value = datosSalida.PCantidadParesSalida
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "totalParesNoRecibidos"
        parametro.Value = datosSalida.PCantidadParesNoRecibidos
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_GenerarSalidas", listaParametros)

    End Function

    Public Function generarIncidencia(ByVal datosIncidencia As Entidades.GeneracionIncidencia) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "fechaincidencia"
        parametro.Value = datosIncidencia.PfechaIncidencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradoroperadorid"
        parametro.Value = datosIncidencia.PColaboradOroperadorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "paresentregados"
        parametro.Value = datosIncidencia.PParesEntregados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoincidenciaid"
        parametro.Value = datosIncidencia.PTipoIncidenciaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "observaciones"
        parametro.Value = datosIncidencia.PObservaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ubicacionmercancia"
        parametro.Value = datosIncidencia.PUbicacionMercancia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "proximaentrega"
        parametro.Value = datosIncidencia.PProximaEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaproximaentrega"
        parametro.Value = datosIncidencia.PFechaProximaEntrega
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salidaventasembarqueid"
        parametro.Value = datosIncidencia.PSalidaVentasEmbarqueId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cliente"
        parametro.Value = datosIncidencia.PCliente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = datosIncidencia.PUsuarioCreoId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_GenerarIncidencias", listaParametros)

    End Function

    Public Function seleccionarIncidencias(ByVal embarque As Integer, ByVal cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "salidaventasembarqueid"
        parametro.Value = embarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_SeleccionarIncidencias", listaParametros)

    End Function

    Public Function seleccionarParesDevueltos(ByVal embarque As Integer, ByVal cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idEmbarque"
        parametro.Value = embarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_ConsultarParesDevueltosEmbarques", listaParametros)

    End Function

    Public Function seleccionarDatosEmbarque(ByVal embarque As Integer, ByVal cliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idEmbarque"
        parametro.Value = embarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cliente"
        parametro.Value = cliente
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_SeleccionarDatosEmbarque", listaParametros)

    End Function

    Public Sub actualizarParesDevueltos(ByVal idSalidaDetalle As Integer, ByVal totalParesDevueltos As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idSalidaDetalle"
        parametro.Value = idSalidaDetalle
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalParesDevueltos"
        parametro.Value = totalParesDevueltos
        listaParametros.Add(parametro)

        objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_ActualizarParesDevueltosEmbarques", listaParametros)

    End Sub

    Public Function cancelarSalidas(ByVal idSalidaDetalle As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idDetalle"
        parametro.Value = idSalidaDetalle
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_CancelarSalidas", listaParametros)

    End Function

    Public Function seleccionarEmbarqueAEditar(ByVal embarque As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "salidaventasembarqueid"
        parametro.Value = embarque
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_EmbarquesConSalidaCancelada", listaParametros)

    End Function

    Public Function editarEmbarques(ByVal datosEmbarque As Entidades.GeneracionEmbarque) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idEmbarque"
        parametro.Value = datosEmbarque.PIdEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioEmbarque"
        parametro.Value = datosEmbarque.PUsuarioEmbarque
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "operadorEmbarqueid"
        parametro.Value = datosEmbarque.POperadorEmbarqueId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "operadorEmbarquenombre"
        parametro.Value = datosEmbarque.POperadorEmbarqueNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "mensajeriarealid"
        parametro.Value = datosEmbarque.PMensajeriaRealId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "mensajeriarealnombre"
        parametro.Value = datosEmbarque.PMensajeriaRealNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "unidadEmbarqueId"
        parametro.Value = datosEmbarque.PUnidadEmbarqueId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "unidadEmbarqueNombre"
        parametro.Value = datosEmbarque.PUnidadEmbarqueNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadParesEmbarque"
        parametro.Value = datosEmbarque.PCantidadParesEmbarque
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_EditarEmbarques", listaParametros)

    End Function

    Public Function imprimirOrdenEmbarque(ByVal idEmbarquesSeleccionados As String, ByVal tipoConsulta As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idEmbarque"
        parametro.Value = idEmbarquesSeleccionados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoConsulta"
        parametro.Value = tipoConsulta
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_SeleccionarEmbarquesImprimir", listaParametros)

    End Function

    Public Function consultaParesEmbarquesConFiltros(ByVal FiltrosParesEmbarquesSalidas As Entidades.FiltrosParesEmbarquesSalidas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "CodigosPar"
        parametro.Value = FiltrosParesEmbarquesSalidas.PCodigosPar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CodigosAtado"
        parametro.Value = FiltrosParesEmbarquesSalidas.PCodigosAtado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Lotes"
        parametro.Value = FiltrosParesEmbarquesSalidas.PLotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AñosLotes"
        parametro.Value = FiltrosParesEmbarquesSalidas.PAñosLotes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Naves"
        parametro.Value = FiltrosParesEmbarquesSalidas.PNaves
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Pedidos"
        parametro.Value = FiltrosParesEmbarquesSalidas.PPedidos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Clientes"
        parametro.Value = FiltrosParesEmbarquesSalidas.PClientes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tiendas"
        parametro.Value = FiltrosParesEmbarquesSalidas.PTiendas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Productos"
        parametro.Value = FiltrosParesEmbarquesSalidas.PProductos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Corridas"
        parametro.Value = FiltrosParesEmbarquesSalidas.PCorridas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Tallas"
        parametro.Value = FiltrosParesEmbarquesSalidas.PTallas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltroY_O"
        parametro.Value = FiltrosParesEmbarquesSalidas.PFiltroY_O
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Cedis"
        parametro.Value = FiltrosParesEmbarquesSalidas.PCedis
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_ConsultarParesEmbarquesConFiltros", listaParametros)

    End Function


    Public Function consultaBitacoraEmbarques(ByVal idEmbarques As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "idEmbarque"
        parametro.Value = idEmbarques
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Almacen.SP_SalidasVentas_ConsultarBitacoraEmbarques", listaParametros)

    End Function

    Public Function actualizarDatosSAY() As Boolean
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim resultado As Boolean = False
        Dim tabla As DataTable

        Try
            tabla = objPersistencia.EjecutaConsulta("exec Almacen.SP_SalidaVentas_GenerarDetallesPares")
            If tabla.Rows(0).Item("tipoResultado") = "EXITO" Then
                resultado = True
            Else
                resultado = False
            End If
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado

    End Function

    Public Function obtenerFechaUltimaActualizacionDatosSAY() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY

        Return objPersistencia.EjecutaConsulta("EXEC Almacen.SP_SalidasVentas_ConsultarUltimaActualizacionDatos")

    End Function

    Public Sub actualizarParesEntregadosEnRuta()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_PedidosWeb_ConsultaReporte_ActualizarParesEntregadosEnRuta]")

    End Sub

    'INICIA ACTUALIZACION DE STATUS DE OT SAY
    Public Sub actualizarStatusOTSAYParesEnRuta()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Almacen].[SP_SalidasVentas_ActualizarStatusParesOTSAY_EnRuta_Optimizado]")

    End Sub

    Public Sub actualizarStatusOTSAYParesEntregado()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Almacen].[SP_SalidasVentas_ActualizarStatusParesOTSAY_Entregado_optimizado]")

    End Sub

    Public Sub actualizarStatusOTSAYPartidasEnRuta()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Almacen].[SP_SalidasVentas_ActualizarStatusOTSAY_EnRuta]")

    End Sub

    Public Sub actualizarStatusOTSAYPartidasEntregadas()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Almacen].[SP_SalidasVentas_ActualizarStatusOTSAY_Entregado]")

    End Sub

    Public Sub ActualizaParesSalidaApartado()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos

        objPersistencia.EjecutaConsulta("EXEC [Ventas].[SP_Apartados_ActualizarParesSalidas]")

    End Sub

    'TERMINA ACTUALIZACION DE STATUS DE OT SAY


    '****************************************************************************************************

#Region "Salidas Nave Lotes V2"

    Public Function ObtenerInformacionNave(ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaveLotes_Informacion_Nave]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ValidarSalidaPendienteNave(ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNave_ValidarSalidaPendienteNave]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidarAtado(ByVal CodigoAtado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNave_ValidarAtado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function InsertarInformacionDelLote(ByVal CodigoAtado As String, ByVal NaveSICYId As Integer, ByVal NaveMaquila As Integer, ByVal SalidaNaveProduccionID As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveIDSicy"
            parametro.Value = NaveSICYId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveEsMaquila"
            parametro.Value = NaveMaquila
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@SalidaNavesProduccionID"
            parametro.Value = SalidaNaveProduccionID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_PrimerAtadoDelLotev6]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerInformacionLote(ByVal IdSalidaNave As Integer, ByVal Lote As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_ObtenerLote]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConfirmacionPorPar(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_TipoConfirmacionLote]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertarFolioSalida(ByVal NaveSICY As Integer, ByVal OperadorID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@OperadorID"
            parametro.Value = OperadorID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaveProduccion_Salida_IniciarSalidaNave]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RecuperarParesFolio(ByVal IdSalidaNave As Integer, ByVal Lote As Integer, ByVal NaveSICYId As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_RecuperarPares]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RecuperarAtadosFolio(ByVal IdSalidaNave As Integer, ByVal Lote As Integer, ByVal NaveSICYId As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_RecuperarAtados]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub ActualizarStatusAtado(ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal StatusID As Integer, ByVal Lote As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Atado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StatusID"
            parametro.Value = StatusID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_ActualizarAtado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Sub ActualizarStatusSalida(ByVal IdSalidaNave As Integer, ByVal IdUsuario As String, ByVal NaveSICYID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdUsuario"
            parametro.Value = IdUsuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IdNave"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaveProduccion_Salida_ActualizaStatusSalida]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function RecuperarAtadosFolioSalida(ByVal IdSalidaNave As Integer, ByVal TipoProceso As String, ByVal AlmacenId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoProceso"
            parametro.Value = TipoProceso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenID"
            parametro.Value = AlmacenId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_RecuperarAtadosFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function RecuperarLotesFolioSalida(ByVal IdSalidaNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_RecuperarLotesFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function RecuperarParesFolioSalida(ByVal IdSalidaNave As Integer, ByVal AlmacenId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenID"
            parametro.Value = AlmacenId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_RecuperarParesFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub RegistrarErrorLectura(ByVal IdSalidaNave As Integer, ByVal CodigoLeido As String, ByVal CodigoAtado As String, ByVal Lote As Integer, ByVal año As Integer, ByVal NaveSICYID As Integer, ByVal UsuarioId As Integer, ByVal Proceso As String, ByVal DescripcionError As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = IdSalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoLeido"
            parametro.Value = CodigoLeido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Proceso"
            parametro.Value = Proceso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Error"
            parametro.Value = DescripcionError
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_RecuperarParesFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ReporteObtenerResumenPares(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_Reporte_ResumenLote]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteObtenerResumenFolio(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_Reporte_ResumenFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub ActualizarStatusFolioIngresando(ByVal FolioSalidaID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ActualizarFolioStatusIngresando]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ValidaFolioEntrada(ByVal FolioSalidaID As Integer, ByVal NaveSICYID As Integer, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraId"
            parametro.Value = ComercializadoraID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ValidaFolio_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function RecuperarAtadosFolioEntrada(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_RecuperarAtadosFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub ActualizaStatusAtadoEntrada(ByVal FolioSalidaID As Integer, ByVal Atado As String, ByVal StatusID As Integer, ByVal Lote As Integer, ByVal CarritoID As Integer, ByVal AlmacenId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Atado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@StatusID"
            parametro.Value = StatusID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CarritoId"
            parametro.Value = CarritoID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenID"
            parametro.Value = AlmacenId
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ActualizarAtado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ObtenerPlataformasFolio(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ObtenerCarritosFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function FinalizarEntradaLote(ByVal FolioSalidaID As Integer, ByVal AlmacenID As Integer, ByVal UsuarioId As Integer, ByVal Tipo_Nave As Boolean, ByVal IdNaveSICY As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenID"
            parametro.Value = AlmacenID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Tipo_Nave"
            parametro.Value = Tipo_Nave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@IDNaveSICY"
            parametro.Value = IdNaveSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraID"
            parametro.Value = ComercializadoraId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_FinalizarFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub DescartarLotes(ByVal FolioSalidaID As Integer, ByVal Lote As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_DescartarLotes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ActualizarEstatus(ByVal FolioSalidaID As Integer, ByVal Nave As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@idNave"
            parametro.Value = Nave
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_actualizarlotes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ValidarEntradaPendienteNave(ByVal NaveSICYId As Integer, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter("@NaveSICYID", NaveSICYId)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@ComercializadoraID", ComercializadoraID)
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNaveProduccion_Entrada_ValidarEntradaPendienteNave]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNaveProduccion_Entrada_ValidarEntradaPendienteNave_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertarFolioEntradaNaveMaquila(ByVal NaveSICYId As Integer, ByVal UsuarioID As Integer, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter("@NaveId", NaveSICYId)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@OperadorID", UsuarioID)
            listaParametros.Add(parametro)

            parametro = New SqlParameter("@ComercializadoraID", ComercializadoraID)
            listaParametros.Add(parametro)

            'Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaveProduccion_Entrada_IniciarEntradaNave]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNaveProduccion_Entrada_IniciarEntradaNave_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerPlataformasFolioEntrada(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaId"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_InformacionPlataformas]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub InsertarErrorDeLectura(ByVal CodigoError As Entidades.CodigosErroneos)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaId"
            parametro.Value = CodigoError.FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@CodigoLeido"
            parametro.Value = CodigoError.CodigoLeido
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Atado"
            parametro.Value = CodigoError.Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = CodigoError.Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = CodigoError.Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSICYID"
            parametro.Value = CodigoError.NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioID"
            parametro.Value = CodigoError.UsuarioID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Proceso"
            parametro.Value = CodigoError.Proceso
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@DescripcionError"
            parametro.Value = CodigoError.DescripcionError
            listaParametros.Add(parametro)


            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_RegistroErrores]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub LimpiarCodigoErrorAtado(ByVal FolioSalidaID As Integer, ByVal Atado As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaId"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Atado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_LimpiarRegistroErroresAtado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DescartarLotesEntrada(ByVal FolioSalidaID As Integer, ByVal Lote As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_DescartarLotes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ValidarExisteAtado(ByVal Atado As String, ByVal NaveSicyId As Integer) As DataTable '' OAMB CAMBIOS (03/07/2024)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveSicyId"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_ValidaExisteAtado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function EnviarAHistoricoFolio(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_EnviarHistoricoFolio]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerParesDescartados(ByVal FolioSalidaID As Integer, ByVal AlmacenId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AlmacenID"
            parametro.Value = AlmacenId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_ParesDescartados]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerListaLotesReporteSalida(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_ListaLotesReporte]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerTotalParesRecibidos(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = NumeroAlmacen
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraID"
            parametro.Value = ComercializadoraId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ReporteTotalParesRecibidos_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ObtenerTotalParesFacturados_o_Remisionados(ByVal NaveSICYID As Integer, ByVal Fecha As Date, ByVal tipo As Integer, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Fecha"
            parametro.Value = Format(CDate(Fecha), "dd/MM/yyyy")
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@tipo"
            parametro.Value = tipo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = NumeroAlmacen
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraId"
            parametro.Value = ComercializadoraId
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_EntradaySalidaLotes_Pares_Facturados_Remision_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ObtenerTotalParesNoEmbarcados(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = NumeroAlmacen
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraID"
            parametro.Value = ComercializadoraId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ReporteTotalParesNoEmbarcados_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerTotalParesFaltantes(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAlmacen"
            parametro.Value = NumeroAlmacen
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ComercializadoraID"
            parametro.Value = ComercializadoraID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ReporteTotalParesFaltantes_v2]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerNombreOperadorReporteEntrada(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdNaveSICY"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaInicio"
            parametro.Value = FechaSalidaInicio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaSalidaFin"
            parametro.Value = FechaSalidaFin
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Entrada_ObtenerNombreOperador]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidarAtadoEntrada(ByVal CodigoAtado As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoAtado"
            parametro.Value = CodigoAtado
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNaveProduccion_Entrada_ValidarAtado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertarAtadoNoEmbarcado(ByVal IdsalidaNave As Integer, ByVal Atado As String, ByVal Año As Integer, ByVal Descripcion As String, ByVal ClienteID As Integer, ByVal NaveID As Integer, ByVal Lote As Integer, ByVal NumeroAtado As Integer, ByVal Pares As Integer, ByVal StatusID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNave"
            parametro.Value = IdsalidaNave
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Atado"
            parametro.Value = Atado
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Año"
            parametro.Value = Año
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Descripcion"
            parametro.Value = Descripcion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteID"
            parametro.Value = ClienteID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Lote"
            parametro.Value = Lote
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NumeroAtado"
            parametro.Value = NumeroAtado
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@Pares"
            parametro.Value = Pares
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@StatusId"
            parametro.Value = StatusID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNaveProduccion_Atados_Erroneos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaAtadosErroneos(ByVal IdsalidaNave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@IdSalidaNAve"
            parametro.Value = IdsalidaNave
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNaveProduccion_Entrada_ConsultaAtadosErroneos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        dtResultadoConsulta = objPersistencia.EjecutarConsultaSP("Ventas.SP_Perfil_Usuario_Tablero", listaParametros)

        Return dtResultadoConsulta

    End Function

    Public Sub ActuallizarPrecio()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Dim listaParametros As New List(Of SqlParameter)

        Try
            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_ActualizarPrecios]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub LimpiarParesErrores(ByVal NaveSICYID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@NaveId"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProducccion_LimpiarParesErrores]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ValidaParesNave(ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Genera_Nave_tmpDocenasPares_ValidaDatos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GeneraParesNave(ByVal NaveSICYID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim dtResultadoConsulta As New DataTable

        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@NaveID"
            parametro.Value = NaveSICYID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Genera_Nave_tmpDocenasPares]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CorregirErrores()
        Dim operaciones = New Persistencia.OperacionesProcedimientosSICY
        Return operaciones.EjecutarConsultaSP("[Almacen].[SP_SalidaVentas_CorregirErroresEmbarque]", New List(Of SqlParameter))
    End Function

    Public Function Colaboradores() As DataTable
        Dim operaciones = New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = "
            SELECT distinct cb.codr_colaboradorid, RTRIM( cb.codr_nombre) +' '+ RTRIM(cb.codr_apellidopaterno)+' '+ RTRIM(cb.codr_apellidomaterno) as nombre, cbe.cexp_carpeta, cbe.cexp_nombrearchivo, cbe.cexp_carpeta+'/'+ cbe.cexp_nombrearchivo
            from Nomina.Colaborador cb
            inner join Nomina.ColaboradorLaboral cbl on  cb.codr_colaboradorid = cbl.labo_colaboradorid
            LEFT join Nomina.ColaboradorExpediente cbe on cbe.cexp_colaboradorid = cb.codr_colaboradorid
            and cbe.cexp_credencial =1
            where codr_activo =1
            and cbl.labo_naveid = 43
            and cb.codr_colaboradorid not in (2962)
            "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function actualizar(ByVal colabodiorid As String) As DataTable
        Dim operaciones = New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""

        consulta = "
            update cb set cb.Gano =1
from Work.dbo.TBL_Sorteo_Colaboradores cb
where cb.ColaboradorID = " & colabodiorid & "
            "

        Return operaciones.EjecutaConsulta(consulta)

    End Function

    Public Function ConsultarSi_Es_Maquila(ByVal naveSICY As Integer) As DataTable
        Dim operaciones = New Persistencia.OperacionesProcedimientosSICY
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@nave"
            parametro.Value = naveSICY
            listaParametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Almacen].[SP_SalidaNaves_Es_Maquila]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function LeerReporteClave(ByVal ClaveReporte As String) As Entidades.Reportes
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim EntidadReporte As New Entidades.Reportes
        Dim tabla As DataTable
        tabla = operaciones.EjecutaConsulta("select repo_reporteid,repo_esquema,RTRIM(repo_nombrereporte) as 'repo_nombrereporte',repo_xml,repo_activo,repo_clavereporte from Framework.Reportes where repo_clavereporte='" + ClaveReporte + "' and repo_activo=1")
        For Each row As DataRow In tabla.Rows

            EntidadReporte.Pactivo = CBool(row("repo_activo"))
            EntidadReporte.Pesquema = CStr(row("repo_esquema"))
            EntidadReporte.Pnombre = CStr(row("repo_nombrereporte"))
            EntidadReporte.Preporteid = CInt(row("repo_reporteid"))
            EntidadReporte.Pxml = CStr(row("repo_xml"))
        Next
        Return EntidadReporte
    End Function

    Public Function ObtenerLogotipoSICYNave(ByVal naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select nave_logotipourl from Framework.Naves where nave_navesicyid = " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ObtenerLogotipoNave(ByVal naveid As Int32) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = "select nave_logotipourl from Framework.Naves where nave_naveid = " + naveid.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function
    Public Function ConsultarParesSalidaDestructiva(ByVal anio As Integer, ByVal cedis As Integer) As DataTable
        Dim operaciones = New Persistencia.OperacionesProcedimientosSICY
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@anio"
            parametro.Value = anio
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@cedis"
            parametro.Value = cedis
            listaParametros.Add(parametro)

            Return operaciones.EjecutarConsultaSP("[Almacen].[SP_ConsultarParesConSalidaDestructiva]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub ActualizarEstatusPedido(ByVal PedidoSICY As String)
        Dim operaciones = New Persistencia.OperacionesProcedimientos
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@pedidoSICY"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)


            operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ActualizarParesEntregadosPedidos]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub ReplicarEstatusPedidoSAY_SICY(ByVal PedidoSICY As String)
        Dim operaciones = New Persistencia.OperacionesProcedimientosSICY
        Try
            Dim listaParametros As New List(Of SqlParameter)
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@PedidoSICY"
            parametro.Value = PedidoSICY
            listaParametros.Add(parametro)


            operaciones.EjecutarConsultaSP("[Ventas].[SP_Pedidos_ReplicarEstatusPedidos_SAY_SICY]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Public Function ReporteObtenerResumenParesLotesPiloto(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_Reporte_ResumenLotesPiloto]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ReporteObtenerResumeLotes(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidaNavesProduccion_Salida_Reporte_Lotes]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ObtenerLotesPilotoFolio(ByVal FolioSalidaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@FolioSalidaId"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_SalidasNave_ObtenerLotesPiloto]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ''Laura 14/07/2023
    Public Sub ActualizacionTipoLotesSalidasNaves(ByVal FolioSalidaID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@FolioSalidaID"
            parametro.Value = FolioSalidaID
            listaParametros.Add(parametro)


            objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ActualizacionTipoLotesSalidasNaves]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub





    '' CAMBIOS (10/08/2024) - Se agerga una validación para la solución de los códigos de par con misma configuración de atado.
    Public Function ValidarAtadoNuevo(ByVal CodigoLeido As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@CodigoLeido"
            parametro.Value = CodigoLeido
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_SalidasNave_VerificacionAtadoPar]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub LimpiarTablaParesErroneos(ByVal NaveSicyId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NaveSicyId"
            parametro.Value = NaveSicyId
            listaParametros.Add(parametro)

            objPersistencia.EjecutarConsultaSP("[Programacion].[SP_SalidasNave_LimpiarTablaParesErroneos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
