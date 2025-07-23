Imports System.IO

Public Class EtiquetasBU

    ''' <summary>
    ''' Consulta los lotes que se encuentran en un programa para cierta nave
    ''' </summary>
    ''' <param name="NaveSICYID">NaveID del SICY</param>
    ''' <param name="FechaPrograma">Fecha corta del programa</param>
    ''' <remarks></remarks>
    Public Function ConsultarLotesPorPrograma(ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Return objDA.ConsultarLotesPorPrograma(NaveSICYID, FechaPrograma)
    End Function
    ''' <summary>
    ''' Consultar las naves que se encuentran activas en el SICY
    ''' </summary>
    ''' <returns> Datatable con las columnas IdNave, Nave</returns>
    ''' <remarks></remarks>
    Public Function ConsultarNavesSICY() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Return objDA.ConsultarNavesSICY()
    End Function

    Public Function ImprimirEtiquetasSAY(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Return objDA.ImprimirEtiquetasSAY(Lotes, Nave, Año)
    End Function

    Public Function ComandosImprimirEtiquetasSAY(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Return objDA.ComandosImprimirEtiquetasSAY(Lotes, Nave, Año)
    End Function

    Public Function ImprimirEtiquetasSAY300dpi(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Return objDA.ImprimirEtiquetasSAY300dpi(Lotes, Nave, Año)
    End Function
    Public Function ConsultarImpresorasZebra() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarImpresorasZebra()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EtiquetasPedidosCoppel(ByVal FechaInicioPrograma As Date, ByVal NaveSICYID As Int16) As DataTable ' ByVal FechaFinPrograma As Date,
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Try
            Return objDa.EtiquetasPedidosCoppel(FechaInicioPrograma.ToString("dd/MM/yyyy"), NaveSICYID) 'FechaFinPrograma,
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ActualizarImpresorasZebra(ByVal accion As Integer, ByVal entidadImpresora As Entidades.ImpresorasZebra)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ActualizarImpresorasZebra(accion, entidadImpresora)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarEtiquetasEspeciales(ByVal StatusEtiqueta As String)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarEtiquetasEspeciales(StatusEtiqueta)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarEtiquetasEspecialesClientes(ByVal idEtiqueta As Integer) As Entidades.ConfiguracionEtiqueta
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtEtiqueta As DataTable
        Dim objConfiguracionEtiqueta As New Entidades.ConfiguracionEtiqueta
        Try
            dtEtiqueta = objDA.ConsultarEtiquetasEspecialesClientes(idEtiqueta)
            'For Each Fila As DataRow In dtEtiqueta.Rows

            Dim fila As DataRow = dtEtiqueta.Rows.Item(0)
            objConfiguracionEtiqueta.EtiquetaId = fila.Item("EtiquetaID")
            objConfiguracionEtiqueta.EtiquetaClave = fila.Item("Clave")
            objConfiguracionEtiqueta.TipoEtiquetaId = fila.Item("TipoEtiquetaID")
            objConfiguracionEtiqueta.EtiquetaNombre = fila.Item("Nombre")
            objConfiguracionEtiqueta.EtiquetaDescripcion = fila.Item("Descripcion")
            objConfiguracionEtiqueta.CodigoZPL = fila.Item("CodigoZPL200")
            objConfiguracionEtiqueta.EtiquetaCodigoZPL300 = fila.Item("CodigoZPL300")
            objConfiguracionEtiqueta.EtiquetaAncho = fila.Item("Ancho")
            objConfiguracionEtiqueta.EtiquetaAlto = fila.Item("Alto")
            objConfiguracionEtiqueta.EtiquetaUsuarioCreoId = fila.Item("UsuarioCreoID")
            objConfiguracionEtiqueta.FechaCreacion = fila.Item("FechaCreacion")
            objConfiguracionEtiqueta.UsuarioModificoId = fila.Item("UsuarioModificoID")
            objConfiguracionEtiqueta.ClienteId = fila.Item("ClienteID")
            objConfiguracionEtiqueta.EtiquetaImpresionesAlPaso = fila.Item("ImpresionAlPaso")
            objConfiguracionEtiqueta.EtiquetaActiva = fila.Item("Activa")
            objConfiguracionEtiqueta.EtiquetaVistaPrevia = fila.Item("VistaPrevia")

            Return objConfiguracionEtiqueta
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AltaEtiquetaConfiguracion(ByVal EntidadEtiqueta As Entidades.ConfiguracionEtiqueta, ByVal accion As Integer) As Integer
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As DataTable
        Dim EtiquetaID As Integer = 0

        Try
            dtResultado = objDA.AltaEtiquetaConfiguracion(EntidadEtiqueta, accion)
            If dtResultado.Rows.Count > 0 Then
                EtiquetaID = dtResultado.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return EtiquetaID
    End Function

    Public Function ListaImpresoras() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Return objDA.ListaImpresoras()
    End Function

    Public Function ObtenerEtiquetasLote(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ObtenerEtiquetasLote(Lotes, Nave, Año, ImpresoraID, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionEtiquetasLote(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasLote(Lotes, Nave, Año, ImpresoraID, UsuarioID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GuardarBitacoraImpresionLotes(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date, ByVal UsuarioID As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.GuardarBitacoraImpresionLotes(Lotes, NaveSICYID, FechaPrograma, UsuarioID, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetaYuyin(ByVal StatusId As String) As DataTable
        Dim objDatos As New Programacion.Datos.EtiquetasDA

        Try

            Return objDatos.ConsultaEtiquetaYuyin(StatusId)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarParametrosRelacionados() As DataTable
        Dim objDatos As New Programacion.Datos.EtiquetasDA

        Try
            Return objDatos.ConsultarParametrosRelacionados
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ConsultarParametros() As DataTable
        Dim objDatos As New Programacion.Datos.EtiquetasDA

        Try
            Return objDatos.ConsultarParametros
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReporteCOPPEL_ConsultaProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteCOPPEL_ConsultaProgramas(FechaInicio, FechaFin)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaNaveProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.ReporteCOPPEL_ConsultaNaveProgramas(FechaInicio, FechaFin, NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaParesNaveProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.ReporteCOPPEL_ConsultaParesNaveProgramas(FechaInicio, FechaFin, NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaPedidosProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.ReporteCOPPEL_ConsultaPedidosProgramas(FechaInicio, FechaFin, NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReporteCOPPEL_ConsultaParesPedidosProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.ReporteCOPPEL_ConsultaParesPedidosProgramas(FechaInicio, FechaFin, NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteCOPPEL_ConsultaDetallesPedidosProgramas(ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal NaveID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.ReporteCOPPEL_ConsultaDetallesPedidosProgramas(FechaInicio, FechaFin, NaveID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertarParametroEtiqueta(ByVal EtiquetaID As Integer, ByVal ParametroID As Integer, ByVal Resolucion As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            objDA.InsertarParametroEtiqueta(EtiquetaID, ParametroID, Resolucion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LimpiarParametroEtiqueta(ByVal EtiquetaID As Integer, ByVal Resolucion As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            objDA.LimpiarParametroEtiqueta(EtiquetaID, Resolucion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GuardarEncabezadoImpresionEtiquetasCoppel(ByVal PedidoCliente As Integer, ByVal Usuario As String, ByVal PedidoSICY As Integer, ByVal Pares As Integer) As Integer
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim IdArchivoResultado As Integer = 0
        Try
            dtResultado = objDA.GuardarEncabezadoImpresionEtiquetasCoppel(PedidoCliente, Usuario, PedidoSICY, Pares)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    IdArchivoResultado = CInt(dtResultado.Rows(0).Item(0))
                End If
            Else
                IdArchivoResultado = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return IdArchivoResultado

    End Function

    Public Sub GuardaDetalleImpresionEtiquetaCoppel(ByVal IdArchivo As Integer, ByVal Cantidad As Integer, ByVal Precio As String, ByVal CodigoBarras As String, ByVal Codigo As String, ByVal Familia As String, ByVal Bodega As String, ByVal Talla As String, ByVal Descripcion As String, ByVal Pedido As String, ByVal Tipo As String, ByVal Modelo As String, ByVal Color As String, ByVal IdCodigo As String)
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            objDA.GuardarDetalleImpresionEtiquetasCoppel(IdArchivo, Cantidad, Precio, CodigoBarras, Codigo, Familia, Bodega, Talla, Descripcion, Pedido, Tipo, Modelo, Color, IdCodigo)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub GuardaBitacoraEtiquetaLotes(ByVal año As Integer, ByVal nave As Integer, ByVal fechaprograma As Date, ByVal usuarioid As Integer, ByVal fechaimpresion As DateTime, ByVal pedidocliente As String, ByVal pares As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            objDA.GuardaBitacoraEtiquetaLotes(año, nave, fechaprograma, usuarioid, fechaimpresion, pedidocliente, pares)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Public Function ConsultarTodoModelosImagenes(ByVal estatus As String) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Try
            Return objDa.ConsultarTodoModelosImagenes(estatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarModelosImagenesConGraficos(ByVal estatus As String) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Try
            Return objDa.ConsultarModelosImagenesConGraficos(estatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarModelosImagenesSinGraficos(ByVal estatus As String) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Try
            Return objDa.ConsultarModelosImagenesSinGraficos(estatus)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarCadenaRutaJPGOpciones() As String
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable

        Try
            dt = objDatos.ConsultarCadenaRutaJPGOpciones()

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarCadenaRutaCompletaJPGOpciones() As String
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable

        Try
            dt = objDatos.ConsultarCadenaRutaCompletaJPGOpciones()

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function COnsultarModeloSeleccionado(ByVal IdLinea As String, ByVal IdTalla As String, ByVal IdModelo As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA


        Try
            Return objDatos.COnsultarModeloSeleccionado(IdLinea, IdTalla, IdModelo)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarCadenaRutaGRFOpciones() As String
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable

        Try
            dt = objDatos.ConsultarCadenaRutaGRFOpciones()

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "ConfiguracionEtiqueta"
    Public Function VistaPrevia(ByVal etiquetaId As Integer, Optional ByVal ClienteId As Integer = 0, Optional ByVal StatusEtiquetaId As Integer = 0, Optional ByVal ResolucionImpresora As String = "", Optional ByVal UsuarioImprimio As String = "") As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.VistaPrevia(etiquetaId, ClienteId, StatusEtiquetaId, ResolucionImpresora, UsuarioImprimio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "OpcionesAvanzadas"
    Public Function ImprimirAtados(ByVal nave As Integer,
                              ByVal FechaPrograma As Date,
                              ByVal UsuarioId As Integer,
                              ByVal ImpresoraID As Integer,
                              ByVal LoteDe As Integer,
                              ByVal LoteHasta As Integer,
                              ByVal imprimirPares As Boolean,
                              ByVal CadenaAtados As String
                              ) As DataTable

        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirAtados(nave, FechaPrograma, UsuarioId, ImpresoraID, LoteDe, LoteHasta, imprimirPares, CadenaAtados)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirAtados_Devolucion(ByVal FolioDev As Integer,
                                              ByVal nave As Integer,
                                              ByVal UsuarioId As String,
                                              ByVal ImpresoraID As Integer,
                                              ByVal LoteDe As Integer,
                                              ByVal LoteHasta As Integer,
                                              ByVal imprimirPares As Boolean,
                                              ByVal CadenaAtados As String
                                              ) As DataTable
        Dim datos As New Datos.EtiquetasDA
        ImprimirAtados_Devolucion = datos.ImprimirAtados_Devolucion(FolioDev, nave, UsuarioId, ImpresoraID, LoteDe, LoteHasta, imprimirPares, CadenaAtados)
        Return ImprimirAtados_Devolucion
    End Function

    Public Function ImprimirPares(ByVal nave As Integer,
                               ByVal FechaPrograma As Date,
                               ByVal UsuarioId As Integer,
                               ByVal ImpresoraID As Integer,
                               ByVal LoteDe As Integer,
                               ByVal LoteHasta As Integer,
                               ByVal ProgramaCompleto As Boolean,
                               ByVal Lotes As String,
                               ByVal CadenaAtados As String,
                               ByVal CadenaPares As String
                               ) As DataTable

        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirPares(nave, FechaPrograma, UsuarioId, ImpresoraID, LoteDe, LoteHasta, ProgramaCompleto, Lotes, CadenaAtados, CadenaPares)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirPares_Devolucion(ByVal FolioDev As Integer,
                                             ByVal Nave As Int32,
                                             ByVal UsuarioId As Integer,
                                             ByVal ImpresoraID As Integer,
                                             ByVal LoteDe As Integer,
                                             ByVal LoteHasta As Integer,
                                             ByVal CadenaAtados As String,
                                             ByVal CadenaPares As String
                                             ) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirPares_Devolucion(FolioDev, Nave, UsuarioId, ImpresoraID, LoteDe, LoteHasta, CadenaAtados, CadenaPares)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaImpresoraAsignada(ByVal Equipo As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ConsultaImpresoraAsignada(Equipo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function MostrarPares(ByVal naveId As Integer, ByVal sql As String) As List(Of Entidades.Pares)
    '    Dim objDatos As New Datos.EtiquetasDA
    '    Dim dt As New DataTable
    '    Try
    '        Return objDatos.MostrarPares(naveId, sql)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function MostrarPares(ByVal naveId As Integer, ByVal AnioLote As Int16, LoteInicio As Integer, LoteFin As Integer, AtadoInicio As String, AtadoFin As String, ByVal FolioDevSay As Integer) As List(Of Entidades.Pares)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.MostrarPares(naveId, AnioLote, LoteInicio, LoteFin, AtadoInicio, AtadoFin, FolioDevSay)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesEtiqueta() As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ConsultarClientesEtiqueta()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesTipoEtiqueta(ByVal Accion As Int16, ByVal id As Integer) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ConsultarClientesTipoEtiqueta(Accion, id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarClientesApartados(ByVal id As Integer, ByVal fInicial As Date, ByVal fFinal As Date) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ConsultarClientesApartados(id, fInicial, fFinal)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirClientesPrueba(ByVal ImpresoraID As Integer,
                                       ByVal UsuarioID As Integer,
                                       ByVal ClienteID As Integer,
                                       ByVal tipoetiquetaid As Integer,
                                       ByVal MostrarDetalles As Boolean,
                                       ByVal PorLotes As Boolean,
                                       ByVal nave As Integer,
                                       ByVal FechaPrograma As Date,
                                       ByVal LoteDe As Integer,
                                       ByVal LoteHasta As Integer,
                                       ByVal PorPedido As Boolean,
                                       ByVal PedidoSicy As Integer,
                                       ByVal PedidoSay As Integer,
                                       ByVal PorApartados As Boolean,
                                       ByVal CadenaApartados As String)

        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirClientesPrueba(ImpresoraID, UsuarioID, ClienteID, tipoetiquetaid, MostrarDetalles, PorLotes, nave, FechaPrograma, LoteDe,
                                                   LoteHasta, PorPedido, PedidoSicy, PedidoSay, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try

    End Function




    Public Function ImprimirClientesProduccion(ByVal ImpresoraID As Integer,
                                               ByVal UsuarioID As Integer,
                                               ByVal ClienteID As Integer,
                                               ByVal tipoetiquetaid As Integer,
                                               ByVal MostrarDetalles As Boolean,
                                               ByVal PorLotes As Boolean,
                                               ByVal nave As Integer,
                                               ByVal FechaPrograma As Date,
                                               ByVal LoteDe As Integer,
                                               ByVal LoteHasta As Integer,
                                               ByVal PorPedido As Boolean,
                                               ByVal PedidoSicy As Integer,
                                               ByVal PedidoSay As Integer,
                                               ByVal PorApartados As Boolean,
                                               ByVal CadenaApartados As String)

        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirClientesProduccion(ImpresoraID, UsuarioID, ClienteID, tipoetiquetaid, MostrarDetalles, PorLotes, nave, FechaPrograma, LoteDe,
                                                   LoteHasta, PorPedido, PedidoSicy, PedidoSay, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirEtiquetaResumen(ByVal ClienteID As Integer,
                                        ByVal Cliente As String,
                                        ByVal TipoEtiquetaID As Integer,
                                        ByVal ImpresoraID As Int16,
                                        ByVal Imprimio As String,
                                        ByVal fImpresion As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirEtiquetaResumen(ClienteID, Cliente, TipoEtiquetaID, ImpresoraID, Imprimio, fImpresion)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirClientesPruebaDetalles(ByVal ImpresoraID As Integer,
                                                                             ByVal UsuarioID As Integer,
                                                                             ByVal tipoetiquetaid As Integer,
                                                                             ByVal CadenaPares As String,
                                                                             ByVal ClienteID As Integer)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirClientesPruebaDetalles(ImpresoraID, UsuarioID, tipoetiquetaid, CadenaPares, ClienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirClientesProduccionDetalles(ByVal ImpresoraID As Integer,
                                                                         ByVal UsuarioID As Integer,
                                                                         ByVal tipoetiquetaid As Integer,
                                                                         ByVal CadenaPares As String,
                                                                         ByVal ClienteID As Integer)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirClientesProduccionDetalles(ImpresoraID, UsuarioID, tipoetiquetaid, CadenaPares, ClienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarModelosGranel(ByVal ModeloSAY As String)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ConsultarModelosGranel(ModeloSAY)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ColocarNumeracion(ByVal talla As String, Optional ByVal Especial As Boolean = False)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ColocarNumeracion(talla, Especial)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarLoteDocena(ByVal idCodigoSicy As String, ByVal tallaSicy As String)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.BuscarLoteDocena(idCodigoSicy, tallaSicy)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReingresosGranelInsertaDocenasNormales(ByVal NumDocenas As Integer,
                                                       ByVal Nave As Integer,
                                                       ByVal Lote As Integer,
                                                       ByVal idTallaSicy As String,
                                                       ByVal idCodigoSICY As String,
                                                       ByVal idDocena As Integer
                                                       )

        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ReingresosGranelInsertaDocenasNormales(NumDocenas, Nave, Lote, idTallaSicy, idCodigoSICY, idDocena)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ImprimirGranel(ByVal Lote As Integer,
                                ByVal NoDocena As Integer,
                                ByVal Nave As Integer,
                                ByVal Año As Integer,
                                ByVal ImpresoraId As Integer,
                                ByVal UsuarioId As Integer,
                                ByVal FechaPrograma As Date
                               ) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.ImprimirGranel(Lote, NoDocena, Nave, Año, ImpresoraId, UsuarioId, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try


    End Function


    Public Function InsertarLoteGranel(ByVal Lote As Integer, ByVal PielColor As String, ByVal CodigoSicy As String, ByVal tallaSicy As String)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.InsertarLoteGranel(Lote, PielColor, CodigoSicy, tallaSicy)
        Catch ex As Exception
            Throw ex
        End Try

    End Function





    Public Function InsertarLoteDocenaGranel(ByVal LoteDocena As Integer, ByVal Lote As Integer, ByVal año As Integer, ByVal NoDocena As Integer, ByVal NoPares As Integer)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.InsertarLoteDocenaGranel(LoteDocena, Lote, año, NoDocena, NoPares)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarDocenaParGranel(ByVal idDocena As String, ByVal idPar As String, ByVal talla As String, ByVal loteGranel As Integer, ByVal Codigo As String, ByVal tallaSicy As String)
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.InsertarDocenaParGranel(idDocena, idPar, talla, loteGranel, Codigo, tallaSicy)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function BuscarFinTallas(ByVal idTallaSicy As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.BuscarFinTallas(idTallaSicy)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function BuscarTalla(ByVal num As String, ByVal idTallaSicy As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.BuscarTalla(num, idTallaSicy)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EjecutaConsulta(ByVal Tabla As Boolean, ByVal sql As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable
        Try
            Return objDatos.EjecutaConsulta(Tabla, sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    Public Function ConsultaEstatusEtiquetas() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaEstatusEtiquetas()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub PreAutorizarEtiqueta(ByVal EtiquetaID As Integer, ByVal UsuarioId As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            objDA.PreAutorizarEtiqueta(EtiquetaID, UsuarioId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarModeloSiluetaSICY(ByVal Modelo As Entidades.ModeloTallas)
        Dim objDatos As New Datos.EtiquetasDA

        Try
            objDatos.ActualizarModeloSiluetaSICY(Modelo)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub RechazarEtiqueta(ByVal idEtiqueta As Integer, ByVal UsuarioID As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            objDA.RechazarEtiqueta(idEtiqueta, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function AltaEtiquetaPorAutorizar(ByVal Etiqueta As Entidades.ConfiguracionEtiqueta, ByVal accion As Integer) As Integer
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable

        Try
            dt = objDatos.AltaEtiquetaPorAutorizar(Etiqueta, accion)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AutorizarEtiqueta(ByVal idEtiqueta As Integer, ByVal UsuarioID As Integer) As Integer
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtInformacion As DataTable
        Dim EtiquetaAutorizadaID As Integer = 0

        Try
            dtInformacion = objDA.AutorizarEtiqueta(idEtiqueta, UsuarioID)
            If IsNothing(dtInformacion) = False Then
                EtiquetaAutorizadaID = dtInformacion.Rows(0).Item(0)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return EtiquetaAutorizadaID
    End Function
    Public Function InactivarEtiquetaLengua(ByVal idEtiqueta As Integer, ByVal TipoEtiqueta As Integer) As Integer
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim EtiquetaAutorizadaID As Integer = 0

        Try
            objDA.InactivarEtiquetaLengua(idEtiqueta, TipoEtiqueta)
        Catch ex As Exception
            Throw ex
        End Try
        Return EtiquetaAutorizadaID
    End Function

    Public Function ConsultarImpresionLotesPorPrograma(ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarImpresionLotesPorPrograma(NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarInformacionEtiquetaPorAutorizar(ByVal idEtiqueta As Integer) As Entidades.ConfiguracionEtiqueta
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtEtiqueta As DataTable
        Dim objConfiguracionEtiqueta As New Entidades.ConfiguracionEtiqueta
        Try
            dtEtiqueta = objDA.ConsultarInformacionEtiquetaPorAutorizar(idEtiqueta)
            'For Each Fila As DataRow In dtEtiqueta.Rows

            Dim fila As DataRow = dtEtiqueta.Rows.Item(0)
            objConfiguracionEtiqueta.EtiquetaId = fila.Item("EtiquetaID")
            objConfiguracionEtiqueta.EtiquetaClave = fila.Item("Clave")
            objConfiguracionEtiqueta.TipoEtiquetaId = fila.Item("TipoEtiquetaID")
            objConfiguracionEtiqueta.EtiquetaNombre = fila.Item("Nombre")
            objConfiguracionEtiqueta.EtiquetaDescripcion = fila.Item("Descripcion")
            objConfiguracionEtiqueta.CodigoZPL = fila.Item("CodigoZPL200")
            objConfiguracionEtiqueta.EtiquetaCodigoZPL300 = fila.Item("CodigoZPL300")
            objConfiguracionEtiqueta.EtiquetaAncho = fila.Item("Ancho")
            objConfiguracionEtiqueta.EtiquetaAlto = fila.Item("Alto")
            objConfiguracionEtiqueta.EtiquetaUsuarioCreoId = fila.Item("UsuarioCreoID")
            objConfiguracionEtiqueta.FechaCreacion = fila.Item("FechaCreacion")
            objConfiguracionEtiqueta.UsuarioModificoId = fila.Item("UsuarioModificoID")
            objConfiguracionEtiqueta.ClienteId = fila.Item("ClienteID")
            objConfiguracionEtiqueta.EtiquetaImpresionesAlPaso = fila.Item("ImpresionAlPaso")
            objConfiguracionEtiqueta.EtiquetaActiva = fila.Item("Activa")
            objConfiguracionEtiqueta.EtiquetaVistaPrevia = fila.Item("VistaPrevia")
            objConfiguracionEtiqueta.NombreCliente = fila.Item("Cliente")
            objConfiguracionEtiqueta.Coleccion = fila.Item("Coleccion")
            objConfiguracionEtiqueta.ColeccionID = fila.Item("Coleccionid")
            objConfiguracionEtiqueta.RutaLBL = fila.Item("RutaLBL")

            Return objConfiguracionEtiqueta
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesProduccion() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarNavesProduccion()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarEtiquetaPorAutorizar(ByVal ClienteID As Integer, ByVal TipoEtiquetaID As Integer, ByVal ColeccionId As Integer) As Integer
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As New DataTable

        Try
            dt = objDatos.ValidarEtiquetaPorAutorizar(ClienteID, TipoEtiquetaID, ColeccionId)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarRutaLBLOpciones() As String
        Dim objDatos As New Datos.EtiquetasDA
        Dim DT As DataTable
        Try
            DT = objDatos.ConsultarRutaLBLOpciones()
            Return DT.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub AsignarEquípoPorDefecto(ByVal NombreEquipo As String, ByVal IdImpresora As Integer)
        Dim objDatos As New Datos.EtiquetasDA

        Try
            objDatos.AsignarEquípoPorDefecto(NombreEquipo, IdImpresora)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ConsultarClientesTallasExtranjeras() As DataTable
        Dim objDatos As New Datos.EtiquetasDA

        Try
            Return objDatos.ConsultarClientesTallasExtranjeras
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarTallasExtranjeras(ClienteID As Integer) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Try
            Return objDatos.ConsultarTallasExtranjeras(ClienteID)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarPerimisoAgente(UsuarioID As Integer, ClienteID As Integer) As DataTable
        Dim Datos As New Datos.EtiquetasDA
        Try
            Return Datos.ConsultarPerimisoAgente(UsuarioID, ClienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarTallaExtranjeraClienteDetalle(TallasExtranjeras As Entidades.TallasExtranjerasClienteDetalle, UsuarioCreoID As Integer)
        Dim objDatos As New Datos.EtiquetasDA

        Try

            objDatos.GuardarTallaExtranjeraClienteDetalle(TallasExtranjeras, UsuarioCreoID)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultarPerfilUsuario(UsuarioID) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dt As DataTable
        Try
            dt = objDatos.ConsultarPerfilUsuario(UsuarioID)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultarClientesDestinoCopiarTallas(ClienteOrigenID As Integer) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Try
            Return objDatos.ConsultarClientesDestinoCopiarTallas(ClienteOrigenID)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarClientesDestinoCopiarTallasAgente(ClienteOrigenID As Integer, UsuarioID As Integer) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Try
            Return objDatos.ConsultarClientesDestinoCopiarTallasAgente(ClienteOrigenID, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultarPaisesCorridasXCliente(ClienteID As Integer) As DataTable
        Dim objDatos As New Datos.EtiquetasDA

        Try
            Return objDatos.ConsultarPaisesCorridasXCliente(ClienteID)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ConsultarConfiguracionGeneralCorridasExtranjeras(ByVal Licencia As Integer) As DataTable
        Dim objDa As New Datos.EtiquetasDA

        Try
            Return objDa.ConsultarConfiguracionGeneralCorridasExtranjeras(Licencia)
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub GuardarConfiguracionGeneral(ByVal ConfGeneral As Entidades.TallasExtranjerasClienteDetalle, UsuarioID As Integer)
        Dim objDA As New Datos.EtiquetasDA

        Try
            objDA.GuardarConfiguracionGeneral(ConfGeneral, UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function CoosultaCodigoRaidoCoppel(ByVal codigorapido As String, ByVal TallaIni As String, ByVal TallaFin As String) As DataTable 'ByVal Talla As String
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.CoosultaCodigoRapidoCoppel(codigorapido, TallaIni, TallaFin) 'Talla
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ''' <summary>
    ''' Consulta la impresora asignada a un equipo
    ''' </summary>
    ''' <param name="NombreEquipo">Nombre del equipo</param>
    ''' <returns>El identificador de la impresora , 0 => No tiene impresora asignada</returns>
    ''' <remarks></remarks>
    Public Function ConsultarImpresoraEquipo(ByVal NombreEquipo As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Dim dtInformacion As DataTable
        Dim ImpresoraID As Integer = 0

        Try
            dtInformacion = objDatos.ConsultarImpresoraEquipo(NombreEquipo)
            'If IsNothing(dtInformacion) = False Then
            '    If dtInformacion.Rows.Count > 0 Then
            '        ImpresoraID = dtInformacion.Rows(0).Item(0)
            '    Else
            '        ImpresoraID = 0
            '    End If
            'Else
            '    ImpresoraID = 0
            'End If

        Catch ex As Exception
            Throw ex
        End Try

        Return dtInformacion
    End Function

    Public Function ValidaInformacionImpresionLote(ByVal Lotes As String, ByVal Año As Integer, ByVal NaveSICYID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ValidaInformacionImpresionLote(Lotes, Año, NaveSICYID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ComandosImprimirEtiquetasSAY_V2(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ComandosImprimirEtiquetasSAY_V2(Lotes, Nave, Año, ImpresoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ComandosImprimirEtiquetasSAY_Lotes(ByVal LoteDe As Integer, ByVal LoteHasta As Integer, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ComandosImprimirEtiquetasSAY_Lotes(LoteDe, LoteHasta, Nave, Año, ImpresoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ComandosImprimirEtiquetasSAY_Lotes_Devolucion(ByVal FolioDev As Integer, ByVal LoteDe As Integer, ByVal LoteHasta As Integer, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ComandosImprimirEtiquetasSAY_Lotes_Devolucion(FolioDev, LoteDe, LoteHasta, Nave, Año, ImpresoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaDetallesImpresion(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal FechaPrograma As Date, ByVal ImpresoraId As Integer, ByVal EtiquetaId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaDetallesImpresion(Lotes, Nave, Año, FechaPrograma, ImpresoraId, EtiquetaId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarParametrosEtiqueta(ByVal EtiquetaId As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarParametrosEtiqueta(EtiquetaId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidarZplCargado(ByVal Lotes As String, ByVal Año As Integer, ByVal NaveSICYID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ValidarZplCargado(Lotes, Año, NaveSICYID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaLotes(ByVal LoteInicio As String, ByVal LoteFin As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaLotes(LoteInicio, LoteFin)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ConsultaEtiquetasDiferenteTamaño(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaEtiquetasDiferenteTamaño(Lotes, NaveSICYID, Año, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta las etiquetas de Lengua
    ''' </summary>
    ''' <param name="StatusID">'' => Todos los status, 172,173,174,175</param>
    ''' <returns>DataTable con los datos de laas etiquetas de LENGUA</returns>
    ''' <remarks></remarks>
    Public Function ConsultaEtiquetasLengua(ByVal StatusID As String, ByVal etiquetasConDiseño As Boolean) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaEtiquetasLengua(StatusID, etiquetasConDiseño)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ValidarEtiquetasYUYIN(ByVal Lotes As String, ByVal Año As Integer, ByVal NaveSICYID As Integer) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarEtiquetasYUYIN(Lotes, Año, NaveSICYID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0) = 0 Then
                        Resultado = False
                    Else
                        Resultado = True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    Public Function ImpresionEtiquetasLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, TipoImpresion As Integer, ByVal ColeccionId As Integer, ByVal Amarres As String, Optional ByVal MostrarDetalles As Boolean = False, Optional ByVal ClienteSAY As Integer = 0) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasLengua(LoteInicio, LoteFin, NaveSICYID, Año, ImpresoraID, UsuarioId, FechaPrograma, TipoImpresion, ColeccionId, Amarres, MostrarDetalles, ClienteSAY)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta las colecciones que se imprimen para las etiquetas de Lengua
    ''' </summary>
    ''' <returns>DataTable con la informacion de las colecciones.</returns>
    ''' <remarks></remarks>
    Public Function ConsultaColeccionesLengua(ByVal ClienteID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaColeccionesLengua(ClienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta los pares a imprimir de Lengua
    ''' </summary>
    ''' <param name="LoteInicio">Lote Inicio</param>
    ''' <param name="LoteFin">Lote Fin</param>
    ''' <param name="Amarre">Numero de Amarre</param>
    ''' <param name="NaveSICYId">El identificador de la Nave SICY ID</param>
    ''' <param name="Año">Es el año del programa</param>
    ''' <returns>DataTable con la informacion de los pares.</returns>
    ''' <remarks></remarks>
    Public Function ConsultaParesLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal Amarre As String, ByVal NaveSICYId As Integer, ByVal Año As Integer, ByVal ColeccionID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaParesLengua(LoteInicio, LoteFin, Amarre, NaveSICYId, Año, ColeccionID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function InsertarParametroEtiquetaPorAutorizar(ByVal EtiquetaID As Integer, ByVal ParametroID As Integer, ByVal Resolucion As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.InsertarParametroEtiquetaPorAutorizar(EtiquetaID, ParametroID, Resolucion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Generacion de impresion de etiquetas de Lengua por Par
    ''' </summary>
    ''' <param name="Lotes">Lotes a imprimir</param>
    ''' <param name="NaveSICYID">Identificador de la nave SICY</param>
    ''' <param name="Año">>Año del porgrama</param>
    ''' <param name="ParesImpresion">Codigos de par a imprimir</param>
    ''' <param name="ImpresoraID">Identificador de la impresora</param>
    ''' <param name="UsuarioID">Identidicador del usuario a imprimir</param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasPorParLengua(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ParesImpresion As String, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ColeccionId As Integer, Optional ByVal MostrarDetalles As Boolean = False, Optional ByVal ClienteSAY As Integer = 0, Optional ByVal TipoImpresion As Integer = 0) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasPorParLengua(Lotes, NaveSICYID, Año, ParesImpresion, ImpresoraID, UsuarioID, FechaPrograma, ColeccionId, MostrarDetalles, ClienteSAY, TipoImpresion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Valida que exista la etiqueta de Lengua Yuyin
    ''' </summary>
    ''' <returns>True => si existe la etiqueta, False => Si no existe la etiqueta.</returns>
    ''' <remarks></remarks>
    Public Function ValidarExisteEtiquetaLenguaYuyin() As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarExisteEtiquetaLenguaYuyin()
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0) = 0 Then
                        Resultado = True
                    Else
                        Resultado = False
                    End If
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    Public Function ValidarExisteEtiquetaLenguaColeccion(ByVal ColeccionID As Integer, ByVal EsEtiquetaPrueba As Boolean) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarExisteEtiquetaLenguaColeccion(ColeccionID, EsEtiquetaPrueba)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0) > 0 Then
                        Resultado = True
                    Else
                        Resultado = False
                    End If
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    ''' <summary>
    ''' Consulta los clientes que requieren etiqueta de rastreo.
    ''' </summary>
    ''' <returns>DataTable con los clientes que requieren etiqueta rastreo.</returns>
    ''' <remarks></remarks>
    Public Function ConsultarClientesRastreo() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarClientesRastreo()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Genera la impresión de las etiquetas de Rastreo
    ''' </summary>
    ''' <param name="LoteInicio">Lote de inicio.</param>
    ''' <param name="LoteFin">Lote Fin.</param>
    ''' <param name="AmarreInicio">Amarre de inicio</param>
    ''' <param name="AmarreFin">Amarre de fin</param>
    ''' <param name="NaveSICYID">Identificador de la Nave SICY</param>
    ''' <param name="AñoPrograma">Año del programa seleccionado.</param>
    ''' <param name="ImpresoraId">Identidicador de la impresora ID.</param>
    ''' <param name="UsuarioId">Identidicador del usuario que imprime.</param>
    ''' <param name="FechaPrograma">Fecha de programa.</param>
    ''' <returns>Devuelve un DataTable con los ZPL a imprimir.</returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, UsuarioId As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasRastreo(LoteInicio, LoteFin, AmarreInicio, AmarreFin, NaveSICYID, AñoPrograma, ImpresoraId, UsuarioId, FechaPrograma, ClienteSICYID, MostrarDetalles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Consulta los pares para la impresion de las etiquetas de Rastreo.
    ''' </summary>
    ''' <param name="LoteInicio">lote de inicio.</param>
    ''' <param name="LoteFin">Lote Fin.</param>
    ''' <param name="AmarreInicio">Número de Amarre de inicio.</param>
    ''' <param name="AmarreFin">Número de Amarre de fin.</param>
    ''' <param name="NaveSICYID">Identificador de la Nave SICY.</param>
    ''' <param name="AñoPrograma">Año del programa seleccionada.</param>
    ''' <param name="FechaPrograma">Fecha del programa.</param>
    ''' <returns>DataTable con la información de los pares a imprimir.</returns>
    ''' <remarks></remarks>
    Public Function ConsultarParesImprimirRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultarParesImprimirRastreo(LoteInicio, LoteFin, AmarreInicio, AmarreFin, NaveSICYID, AñoPrograma, FechaPrograma, ClienteSICYID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Imprime los pares seleccionados para la etiqueta de Rastreo
    ''' </summary>
    ''' <param name="Pares">Pares seleccionados para su impresión.</param>
    ''' <param name="NaveSICYID">Identidicador de la nave SICY.</param>
    ''' <param name="AñoPrograma">Año del programa seleccionado.</param>
    ''' <param name="ImpresoraId">Identificador de la impresora seleccionada.</param>
    ''' <param name="UsuarioID">Identificador del usuario que imprime.</param>
    ''' <param name="FechaPrograma">Fecha del programa seleccionado.</param>
    ''' <param name="ClienteSICYID">Identificador del cliente del cual sera impresa la etiqueta de rastreo.</param>
    ''' <returns>DataTable con los ZPL a imprimir.</returns>
    ''' <remarks></remarks>
    Public Function ImpresionParesRastreo(ByVal Pares As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionParesRastreo(Pares, NaveSICYID, AñoPrograma, ImpresoraId, UsuarioID, FechaPrograma, ClienteSICYID, MostrarDetalles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Generar la impreison de las etiquetas de rastreo con los diseños de prueba
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="AmarreInicio"></param>
    ''' <param name="AmarreFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="ImpresoraId"></param>
    ''' <param name="UsuarioId"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="ClienteSICYID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasRastreoPrueba(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, UsuarioId As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasRastreoPrueba(LoteInicio, LoteFin, AmarreInicio, AmarreFin, NaveSICYID, AñoPrograma, ImpresoraId, UsuarioId, FechaPrograma, ClienteSICYID, MostrarDetalles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Impresion de las etiquetas de rastreo con el diseño de prueba.
    ''' </summary>
    ''' <param name="Pares"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="ImpresoraId"></param>
    ''' <param name="UsuarioID"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="ClienteSICYID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionParesRastreoPruebas(ByVal Pares As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionParesRastreoPruebas(Pares, NaveSICYID, AñoPrograma, ImpresoraId, UsuarioID, FechaPrograma, ClienteSICYID, MostrarDetalles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Impresion de las etiquetas de lengua con las etiquetas de diseño.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="Año"></param>
    ''' <param name="ImpresoraID"></param>
    ''' <param name="UsuarioId"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="TipoImpresion"></param>
    ''' <param name="ColeccionID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasLenguaPrueba(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, TipoImpresion As Integer, ByVal ColeccionID As Integer, ByVal Amarres As String, Optional ByVal MostrarDetalles As Boolean = False) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasLenguaPrueba(LoteInicio, LoteFin, NaveSICYID, Año, ImpresoraID, UsuarioId, FechaPrograma, TipoImpresion, ColeccionID, Amarres, MostrarDetalles)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''  Impresion de etiquetas de par de Lengua con los diseños de las etiquetas de prueba.
    ''' </summary>
    ''' <param name="Lotes"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="Año"></param>
    ''' <param name="ParesImpresion"></param>
    ''' <param name="ImpresoraID"></param>
    ''' <param name="UsuarioID"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasPorParLenguaPrueba(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ParesImpresion As String, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date, ByVal ColeccionId As Integer, Optional ByVal MostrarDetalles As Boolean = False, Optional ByVal ClienteSAY As Integer = 0) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasPorParLenguaPrueba(Lotes, NaveSICYID, Año, ParesImpresion, ImpresoraID, UsuarioID, FechaPrograma, ColeccionId, MostrarDetalles, ClienteSAY)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Elimnina los registros de los parametros relacionados a una etiqueta.
    ''' </summary>
    ''' <param name="EtiquetaId"></param>
    ''' <param name="Resolucion"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EliminarParametrosEtiquetaPorAutorizar(ByVal EtiquetaId As Integer, ByVal Resolucion As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.EliminarParametrosEtiquetaPorAutorizar(EtiquetaId, Resolucion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Valida que exista la etiqueta cargada.
    ''' </summary>
    ''' <param name="ClienteID"></param>
    ''' <param name="EsEtiquetaPrueba"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarExisteEtiquetaRastreo(ByVal ClienteID As Integer, ByVal EsEtiquetaPrueba As Boolean) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarExisteEtiquetaRastreo(ClienteID, EsEtiquetaPrueba)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0) = 0 Then
                        Resultado = True
                    Else
                        Resultado = False
                    End If
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado

    End Function

    ''' <summary>
    ''' Validar que la información este completa de la etiqueta de Rastreo
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="AmarreInicio"></param>
    ''' <param name="AmarreFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="ImpresoraID"></param>
    ''' <param name="UsuarioId"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="ClienteSICYID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarInformacionEtiquetaRastreo(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal AmarreInicio As String, ByVal AmarreFin As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, ByVal ClienteSICYID As Integer) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarInformacionEtiquetaRastreo(LoteInicio, LoteFin, AmarreInicio, AmarreFin, NaveSICYID, AñoPrograma, ImpresoraID, UsuarioId, FechaPrograma, ClienteSICYID)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item(0) = 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    ''' <summary>
    ''' Valida si toda la información de la etiqueta esta completa.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="Año"></param>
    ''' <param name="ImpresoraID"></param>
    ''' <param name="UsuarioId"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="TipoImpresion"></param>
    ''' <param name="ColeccionID"></param>
    ''' <param name="Amarres"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarImpresionEtiquetasLengua(ByVal LoteInicio As String, ByVal LoteFin As String, ByVal NaveSICYID As Integer, ByVal Año As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date, TipoImpresion As Integer, ByVal ColeccionID As Integer, ByVal Amarres As String, ByVal ClienteSAYID As Integer) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarImpresionEtiquetasLengua(LoteInicio, LoteFin, NaveSICYID, Año, ImpresoraID, UsuarioId, FechaPrograma, TipoImpresion, ColeccionID, Amarres, ClienteSAYID)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item(0) = 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado

    End Function

    ''' <summary>
    ''' Validar si la informacion de las tallas extranjeras esta completa.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="ColeccionID"></param>
    ''' <param name="ClienteSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="EsEtiquetaPrueba"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarTallasExtranjerasEtiquetaLengua(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ColeccionID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarTallasExtranjerasEtiquetaLengua(LoteInicio, LoteFin, NaveSICYID, ColeccionID, AñoPrograma, FechaPrograma, EsEtiquetaPrueba)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item(0) = 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    ''' <summary>
    ''' Validar información de tallas extranjeras de la etiqueta de rastreo.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="ClienteSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="EsEtiquetaPrueba"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarTallasExtranjerasEtiquetaRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ClienteSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarTallasExtranjerasEtiquetaRastreo(LoteInicio, LoteFin, NaveSICYID, ClienteSICYID, AñoPrograma, FechaPrograma, EsEtiquetaPrueba)
            If dtResultado.Rows.Count > 0 Then
                If CBool(dtResultado.Rows(0).Item(0)) = True Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    ''' <summary>
    ''' Validar la información de las tallas extranjeras para la impresion de los lotes.
    ''' </summary>
    ''' <param name="Lotes"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarTallasExtranjerasPorLote(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarTallasExtranjerasPorLote(Lotes, NaveSICYID, AñoPrograma, FechaPrograma)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item(0) = 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    ''' <summary>
    ''' Valida la informacion de las tallas extranjeras de la pestaña de pares.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ValidarTallasExtranjerasPares(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date) As Boolean
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarTallasExtranjerasPares(LoteInicio, LoteFin, NaveSICYID, AñoPrograma, FechaPrograma)
            If dtResultado.Rows.Count > 0 Then
                If dtResultado.Rows(0).Item(0) = 0 Then
                    Resultado = True
                Else
                    Resultado = False
                End If
            Else
                Resultado = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return Resultado
    End Function

    ''' <summary>
    ''' Consulta los detalles de las tallas extranjeras para la informacion que se va a imprimir.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="ColeccionId"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="EsEtiquetaPrueba"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarDetallesTallasExtranjerasLengua(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ColeccionId As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.MostrarDetallesTallasExtranjerasLengua(LoteInicio, LoteFin, NaveSICYID, ColeccionId, AñoPrograma, FechaPrograma, EsEtiquetaPrueba)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Mostrar detalles de las tallas extrajeras para las etiquetas de Rastreo
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="ClienteSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <param name="EsEtiquetaPrueba"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarDetallesTallasExtranjerasRastreo(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal ClienteSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date, ByVal EsEtiquetaPrueba As Boolean) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.MostrarDetallesTallasExtranjerasRastreo(LoteInicio, LoteFin, NaveSICYID, ClienteSICYID, AñoPrograma, FechaPrograma, EsEtiquetaPrueba)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Mostrar detalles de las tallas extranjeras de la pestaña de Pares.
    ''' </summary>
    ''' <param name="LoteInicio"></param>
    ''' <param name="LoteFin"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function MostrarDetallesTallasExtranjerasPares(ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.MostrarDetallesTallasExtranjerasPares(LoteInicio, LoteFin, NaveSICYID, AñoPrograma, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Envia la informacion a imprimir para las etiquetas de BATTA.
    ''' </summary>
    ''' <param name="Lotes"></param>
    ''' <param name="NaveSICYID"></param>
    ''' <param name="AñoPrograma"></param>
    ''' <param name="ImpresoraID"></param>
    ''' <param name="UsuarioID"></param>
    ''' <param name="FechaPrograma"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ImpresionEtiquetasBATTA(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasBATTA(Lotes, NaveSICYID, AñoPrograma, ImpresoraID, UsuarioID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DescargarImagenBatta(ByVal RutaImagenModelo As String) As String
        Dim RutaLogo As String = RutaImagenModelo
        Dim objFTP As New TransferenciaFTPBU
        Dim Directorio As String = String.Empty
        Dim NombreArchivo As String = String.Empty


        If RutaLogo <> String.Empty Then
            RutaLogo = "C:/" & RutaLogo
            Directorio = Path.GetDirectoryName(RutaLogo)
            If System.IO.Directory.Exists(Directorio) = False Then
                System.IO.Directory.CreateDirectory(Directorio)
            End If
            NombreArchivo = Path.GetFileName(RutaLogo)
            Directorio = Replace(Directorio, "C:", "")
            Directorio = Replace(Directorio, "c:", "")
            Directorio = Replace(Directorio, "\", "/")
            objFTP.DescargarArchivo(Directorio, Directorio, NombreArchivo)
        Else
            RutaLogo = String.Empty
        End If

        Return RutaLogo

    End Function

    Public Function ConsultaImagenesBatta(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaImagenesBatta(Lotes, NaveSICYID, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarImagenesBatta(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ValidarImagenesBatta(Lotes, NaveSICYID, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeEtiquetasBattaOpcionesCliente(ByVal ImpresoraID As Integer,
                                           ByVal UsuarioID As Integer,
                                           ByVal ClienteID As Integer,
                                           ByVal TipoEtiquetaID As Int16,
                                           ByVal MostrarDetalle As Boolean,
                                           ByVal PorLotes As Integer,
                                           ByVal Nave As Integer,
                                           ByVal FechaPrograma As Date,
                                           ByVal LoteDe As Integer,
                                           ByVal LoteHasta As Integer,
                                           ByVal PorPedido As Boolean,
                                           ByVal PedidoSICY As Integer,
                                           ByVal PedidoSAY As Integer,
                                           ByVal PorApartados As Boolean,
                                           ByVal CadenaApartados As String) As DataTable

        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeEtiquetasBattaOpcionesCliente(ImpresoraID, UsuarioID, ClienteID, TipoEtiquetaID, MostrarDetalle, PorLotes, Nave, FechaPrograma, LoteDe, LoteHasta, PorPedido, PedidoSICY, PedidoSAY, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaImagenesBattaOpcionesCliente(ByVal PorLote As Boolean, ByVal LoteInicio As Integer, ByVal LoteFin As Integer, ByVal Nave As Integer, ByVal Fechaprograma As Date, ByVal PorPedido As Boolean, ByVal PedidoSAY As Integer, ByVal PedidoSICY As Integer, ByVal PorApartado As Boolean, ByVal CadenaApartados As String, ByVal IdCliente As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaImagenesBattaOpcionesCliente(PorLote, LoteInicio, LoteFin, Nave, Fechaprograma, PorPedido, PedidoSAY, PedidoSICY, PorApartado, CadenaApartados, IdCliente)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeParesBattaOpcionesCliente(ByVal ImpresoraId As Integer, ByVal Pares As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeParesBattaOpcionesCliente(ImpresoraId, Pares)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerEstiloCOPPEL(ByVal CodigoRapido As String, ByVal Calce As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ObtenerEstiloCOPPEL(CodigoRapido, Calce)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimirEtiquetasCOPPEL(ByVal IdArchivoCOPPEL As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimirEtiquetasCOPPEL(IdArchivoCOPPEL)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteCliente(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteTallasLoteCliente(Lote, NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteClienteTienda(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteTallasLoteClienteTienda(Lote, NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLotePartidasTienda(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteTallasLotePartidasTienda(Lote, NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteEncabezadoTallas(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteTallasLoteEncabezadoTallas(Lote, NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteTallasLoteParesPartidaTallas(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteTallasLoteParesPartidaTallas(Lote, NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(ByVal ImpresoraID As Integer,
                                        ByVal UsuarioID As Integer,
                                        ByVal ClienteID As Integer,
                                        ByVal TipoEtiquetaID As Int16,
                                        ByVal MostrarDetalle As Boolean,
                                        ByVal PorLotes As Integer,
                                        ByVal Nave As Integer,
                                        ByVal FechaPrograma As Date,
                                        ByVal LoteDe As Integer,
                                        ByVal LoteHasta As Integer,
                                        ByVal PorPedido As Boolean,
                                        ByVal PedidoSICY As Integer,
                                        ByVal PedidoSAY As Integer,
                                        ByVal PorApartados As Boolean,
                                        ByVal CadenaApartados As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeEtiquetasBattaOpcionesCliente_ConsultaDetalles(ImpresoraID, UsuarioID, ClienteID, TipoEtiquetaID, MostrarDetalle, PorLotes, Nave, FechaPrograma, LoteDe, LoteHasta, PorPedido, PedidoSICY, PedidoSAY, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function ReporteTallasTiendasPartidas(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ReporteTallasTiendasPartidas(Lote, NaveSICYID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionConArchivo(ByVal Serie As String, ByVal Estilo As String, ByVal Color As String, ByVal Marca As String, ByVal Punto As String, ByVal Pedido As String, ByVal UsuarioId As Integer, ByVal ClienteSAYID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionConArchivo(Serie, Estilo, Color, Marca, Punto, Pedido, UsuarioId, ClienteSAYID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EliminarInformacionImpresionArchivo(ByVal UsuarioID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.EliminarInformacionImpresionArchivo(UsuarioID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionArchivo(ByVal UsuarioId As Integer, ByVal ImpresoraID As Integer, ByVal ClienteID As Integer, ByVal TipoEtiquetaID As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionArchivo(UsuarioId, ImpresoraID, ClienteID, TipoEtiquetaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerParesPorCodigo(ByVal FechaPrograma As Date, ByVal NaveSICYID As Integer, ByVal PedidoSICY As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ObtenerParesPorCodigo(FechaPrograma.ToString("dd/MM/yyyy"), NaveSICYID, PedidoSICY)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerClienesEtiquetasEspecialLengua() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ObtenerClienesEtiquetasEspecialLengua()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerColecciones() As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ObtenerColecciones()
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ValidarClienteColeccion(ClienteID As Integer, ColeccionID As Integer) As Integer
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dt As DataTable
        Try
            dt = objDA.ValidarClienteColeccion(ClienteID, ColeccionID)
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GuardarBitacoraImpresion(LoteInicio As Integer, LoteFIn As Integer, Año As Integer, Nave As Integer,
                                                Programa As Integer, FechaPrograma As Date, UsuarioID As Integer,
                                                PedidoCliente As Integer, Pares As String, TipoEtiquetaID As Integer,
                                                PedidoSAY As Integer, PedidoSICY As Integer, ApartadosConfirmados As Integer,
                                                ColeccionID As Integer, ClienteID As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dt As DataTable
        Try
            objDA.GuardarBitacoraImpresion(LoteInicio, LoteFIn, Año, Nave,
                                                Programa, FechaPrograma, UsuarioID,
                                                PedidoCliente, Pares, TipoEtiquetaID,
                                                PedidoSAY, PedidoSICY, ApartadosConfirmados,
                                                ColeccionID, ClienteID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ProveedorPlanta(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal clasificacionProvPlanta As Integer) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA

        Return objDa.ProveedorPlanta(naveid, fechaPrograma, clasificacionProvPlanta)

    End Function

    Public Function ProveedorSuela(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal clasificacionProvSuela As Integer) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA

        Return objDa.ProveedorSuela(naveid, fechaPrograma, clasificacionProvSuela)

    End Function

    Public Function ProveedorPlantilla(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal clasificacionProvPlantilla As Integer) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA

        Return objDa.ProveedorPlantilla(naveid, fechaPrograma, clasificacionProvPlantilla)

    End Function

    Public Function ConsultaEtiquetasConsumos(ByVal naveId As Integer, ByVal fechaPrograma As Date, ByVal impresora As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.ConsultaEtiquetasConsumos(naveId, fechaPrograma, impresora)
    End Function

    Public Function ConsultaEtiquetasPlantaSuela(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        'Return objBu.ConsultaEtiquetasPlantaSuela(naveid, fechaPrograma, idProveedor, idLotes, Clasificacion, Impresora)
        Return objBu.ConsultaEtiquetasPlantaSuela(naveid, fechaPrograma, idProveedor, idLotes, Clasificacion, Impresora, grupo)
    End Function

    Public Function ConsultaEtiquetasPlantilla(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        'Return objBu.ConsultaEtiquetasPlantilla(naveid, fechaPrograma, idProveedor, idLotes, Impresora)
        Return objBu.ConsultaEtiquetasPlantilla(naveid, fechaPrograma, idProveedor, idLotes, Impresora, grupo)
    End Function

    Public Function CmbConsultaEtiquetasCliente(ByVal clienteId As Integer, ByVal tipoEtiqueta As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.CmbConsultaEtiquetasCliente(clienteId, tipoEtiqueta)
    End Function
    Public Function ConsultaEtiquetasClienteColeccion(ByVal etiquetaId As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.ConsultaEtiquetasClienteColeccion(etiquetaId)
    End Function
    Public Function ObtenerColeccionesNoAsignadasPorCliente(ByVal clienteId As Integer, ByVal etiquetaId As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.ObtenerColeccionesNoAsignadasPorCliente(clienteId, etiquetaId)
    End Function
    Public Function AsignarEtiquetaClienteCollecion(ByVal clienteId As Integer, ByVal etiquetaId As Integer, ByVal coleccionIds As String, ByVal UsuarioId As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.AsignarEtiquetaClienteCollecion(clienteId, etiquetaId, coleccionIds, UsuarioId)
    End Function
    Public Function EliminarColeccionesAsignadasPorCliente(ByVal clienteId As Integer, ByVal etiquetaId As Integer, ByVal coleccionIds As String, ByVal UsuarioId As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.EliminarColeccionesAsignadasPorCliente(clienteId, etiquetaId, coleccionIds, UsuarioId)
    End Function

    Public Function cargarGrupoXNave()
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.cargarGrupoXNave()
    End Function

    Public Function ProveedorPlantaPorGrupo(ByVal fechaPrograma As Date, ByVal clasificacionProvPlanta As Integer, ByVal grupo As String) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Return objDa.ProveedorPlantaPorGrupo(fechaPrograma, clasificacionProvPlanta, grupo)
    End Function

    Public Function ProveedorSuelaPorGrupo(ByVal fechaPrograma As Date, ByVal clasificacionProvSuela As Integer, ByVal grupo As String) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Return objDa.ProveedorSuelaPorGrupo(fechaPrograma, clasificacionProvSuela, grupo)
    End Function

    Public Function ProveedorPlantillaPorGrupo(ByVal fechaPrograma As Date, ByVal clasificacionProvPlantilla As Integer, ByVal grupo As String) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Return objDa.ProveedorPlantillaPorGrupo(fechaPrograma, clasificacionProvPlantilla, grupo)
    End Function

    Public Function ConsultaColecciones()
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Return objDa.ConsultaColecciones()
    End Function

    Public Function ValidarImagenesCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ValidarImagenesCoppel(Lotes, NaveSICYID, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaImagenesCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaImagenesCoppel(Lotes, NaveSICYID, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImpresionEtiquetasCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraID As Integer, ByVal UsuarioID As Integer, ByVal FechaPrograma As Date) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImpresionEtiquetasCoppel(Lotes, NaveSICYID, AñoPrograma, ImpresoraID, UsuarioID, FechaPrograma)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeEtiquetasCoppelOpcionesCliente(ByVal ImpresoraID As Integer,
                                           ByVal UsuarioID As Integer,
                                           ByVal ClienteID As Integer,
                                           ByVal TipoEtiquetaID As Int16,
                                           ByVal MostrarDetalle As Boolean,
                                           ByVal PorLotes As Integer,
                                           ByVal Nave As Integer,
                                           ByVal FechaPrograma As Date,
                                           ByVal LoteDe As Integer,
                                           ByVal LoteHasta As Integer,
                                           ByVal PorPedido As Boolean,
                                           ByVal PedidoSICY As Integer,
                                           ByVal PedidoSAY As Integer,
                                           ByVal PorApartados As Boolean,
                                           ByVal CadenaApartados As String) As DataTable

        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeEtiquetasCoppelOpcionesCliente(ImpresoraID, UsuarioID, ClienteID, TipoEtiquetaID, MostrarDetalle, PorLotes, Nave, FechaPrograma, LoteDe, LoteHasta, PorPedido, PedidoSICY, PedidoSAY, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(ByVal ImpresoraID As Integer,
                                        ByVal UsuarioID As Integer,
                                        ByVal ClienteID As Integer,
                                        ByVal TipoEtiquetaID As Int16,
                                        ByVal MostrarDetalle As Boolean,
                                        ByVal PorLotes As Integer,
                                        ByVal Nave As Integer,
                                        ByVal FechaPrograma As Date,
                                        ByVal LoteDe As Integer,
                                        ByVal LoteHasta As Integer,
                                        ByVal PorPedido As Boolean,
                                        ByVal PedidoSICY As Integer,
                                        ByVal PedidoSAY As Integer,
                                        ByVal PorApartados As Boolean,
                                        ByVal CadenaApartados As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeEtiquetasCoppelOpcionesCliente_ConsultaDetalles(ImpresoraID, UsuarioID, ClienteID, TipoEtiquetaID, MostrarDetalle, PorLotes, Nave, FechaPrograma, LoteDe, LoteHasta, PorPedido, PedidoSICY, PedidoSAY, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeParesCoppelOpcionesCliente(ByVal ImpresoraId As Integer, ByVal Pares As String) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeParesCoppelOpcionesCliente(ImpresoraId, Pares)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DescargarNiceLabeCoppel(ByVal tipoEtiqueta As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.DescargarNiceLabeCoppel(tipoEtiqueta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DescargararchivoNiceLabel(ByVal carpetaOrigen As String, ByVal carpetaDestino As String, ByVal archivo As String, ByVal imagenFondo As String)
        Dim respuesta As String = String.Empty
        Dim objFTP As New TransferenciaFTPBU

        If carpetaOrigen <> "" Then
            objFTP.DescargarArchivo(carpetaOrigen, carpetaDestino, archivo)
            objFTP.DescargarArchivo(carpetaOrigen, carpetaDestino, imagenFondo)
            respuesta = "Archivo descargado"
        Else
            respuesta = "Error al descargar el archivo"
        End If
        Return respuesta

    End Function

    Public Function ConsultaLotesSinGRFImagen(ByVal fechaDel As DateTime, ByVal fechaAl As DateTime,
                                              ByVal fechasProg As Integer,
                                              ByVal sinGrf200 As Integer,
                                              ByVal sinGrf300 As Integer,
                                              ByVal sinImagen As Integer,
                                              ByVal sinLogoMarca As Integer)
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ConsultaLotesSinGRFImagen(fechaDel, fechaAl, fechasProg, sinGrf200, sinGrf300, sinImagen, sinLogoMarca)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetasCoppelPantilla(ByVal accion As Integer,
                                                 ByVal idNave As Integer,
                                                 ByVal tipoEtiquetaId As Integer,
                                                 ByVal loteDel As Integer,
                                                 ByVal loteAl As Integer,
                                                 ByVal fechaPrograma As Date,
                                                 ByVal pedidoSAY As Integer,
                                                 ByVal pedidoSICY As Integer,
                                                 ByVal cadenaApartados As String
                                                 ) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Return objDa.ConsultaEtiquetasCoppelPantilla(accion, idNave, tipoEtiquetaId, loteDel, loteAl, fechaPrograma, pedidoSAY, pedidoSICY, cadenaApartados)
    End Function

    Public Function ConsultaArticulosSinImagenCoppel(ByVal accion As Integer,
                                                 ByVal idNave As Integer,
                                                 ByVal tipoEtiquetaId As Integer,
                                                 ByVal loteDel As Integer,
                                                 ByVal loteAl As Integer,
                                                 ByVal fechaPrograma As Date,
                                                 ByVal pedidoSAY As Integer,
                                                 ByVal pedidoSICY As Integer,
                                                 ByVal cadenaApartados As String
                                                 ) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Return objDa.ConsultaArticulosSinImagenCoppel(accion, idNave, tipoEtiquetaId, loteDel, loteAl, fechaPrograma, pedidoSAY, pedidoSICY, cadenaApartados)
    End Function


    Public Function ConsultaNavesXGrupo(ByVal grupo As String)
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Try
            Return objDa.ConsultaNavesXGrupo(grupo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetasPlantaSuela_Naves(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        'Return objBu.ConsultaEtiquetasPlantaSuela(naveid, fechaPrograma, idProveedor, idLotes, Clasificacion, Impresora)
        Return objBu.ConsultaEtiquetasPlantaSuela_Naves(navesId, fechaPrograma, idProveedor, idLotes, Clasificacion, Impresora, grupo)
    End Function

    Public Function ConsultaEtiquetasPlantilla_Naves(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        'Return objBu.ConsultaEtiquetasPlantilla(naveid, fechaPrograma, idProveedor, idLotes, Impresora)
        Return objBu.ConsultaEtiquetasPlantilla_Naves(navesId, fechaPrograma, idProveedor, idLotes, Impresora, grupo)
    End Function

    Public Function BitacoraEtiquetasProveedores(ByVal navesId As String,
                                                ByVal fechaPrograma As Date,
                                                ByVal idProveedor As Integer,
                                                ByVal idLotes As Integer,
                                                ByVal Clasificacion As String,
                                                ByVal Impresora As Integer,
                                                ByVal grupo As String,
                                                ByVal usuario As String)

        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.BitacoraEtiquetasProveedores(navesId, fechaPrograma, idProveedor, idLotes, Clasificacion, Impresora, grupo, usuario)

    End Function

    Public Function CoosultaCodigoRaidoCoppelTalla(ByVal codigorapido As String, ByVal Talla As String) As DataTable 'ByVal Talla As String
        Dim objDA As New Programacion.Datos.EtiquetasDA

        Try
            Return objDA.CoosultaCodigoRapidoCoppelTalla(codigorapido, Talla) 'Talla
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaEtiquetasBattaPantilla(ByVal accion As Integer, ByVal nave As Integer, ByVal FechaPrograma As Date,
                                                   ByVal loteDe As Integer, ByVal loteHasta As Integer, ByVal pedidoSay As Integer,
                                                   ByVal pedidoSICY As Integer, ByVal apartado As String)
        Dim obj As New Programacion.Datos.EtiquetasDA
        Return obj.ConsultaEtiquetasBattaPantilla(accion, nave, FechaPrograma, loteDe, loteHasta, pedidoSay, pedidoSICY, apartado)
    End Function

    Public Function ConsultaArticulosSinImagenBatta(ByVal accion As Integer, ByVal nave As Integer, ByVal FechaPrograma As Date,
                                                  ByVal loteDe As Integer, ByVal loteHasta As Integer, ByVal pedidoSay As Integer,
                                                  ByVal pedidoSICY As Integer, ByVal apartado As String)
        Dim obj As New Programacion.Datos.EtiquetasDA
        Return obj.ConsultaArticulosSinImagenBatta(accion, nave, FechaPrograma, loteDe, loteHasta, pedidoSay, pedidoSICY, apartado)
    End Function

    Public Function ValidacionDiseñoEtiquetaLengua(ByVal LoteInicio As Integer, ByVal Lotefin As Integer, ByVal NaveSICY As Integer, ByVal Año As Integer)
        Dim obj As New Programacion.Datos.EtiquetasDA
        Return obj.ValidacionDiseñoEtiquetaLengua(LoteInicio, Lotefin, NaveSICY, Año)
    End Function

    Public Function ComandosImprimirEtiquetasSAY_V2SINGRF(ByVal Lotes As String, ByVal Nave As Integer, ByVal Año As Int32, ByVal ImpresoraId As Integer) As DataTable
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ComandosImprimirEtiquetasSAY_V2SINGRF(Lotes, Nave, Año, ImpresoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ImprimeEtiquetasPriceShoes(ByVal ImpresoraID As Integer,
                                           ByVal UsuarioID As Integer,
                                           ByVal ClienteID As Integer,
                                           ByVal TipoEtiquetaID As Int16,
                                           ByVal MostrarDetalle As Boolean,
                                           ByVal PorLotes As Integer,
                                           ByVal Nave As Integer,
                                           ByVal FechaPrograma As Date,
                                           ByVal LoteDe As Integer,
                                           ByVal LoteHasta As Integer,
                                           ByVal PorPedido As Boolean,
                                           ByVal PedidoSICY As Integer,
                                           ByVal PedidoSAY As Integer,
                                           ByVal PorApartados As Boolean,
                                           ByVal CadenaApartados As String) As DataTable

        Dim objDA As New Programacion.Datos.EtiquetasDA
        Try
            Return objDA.ImprimeEtiquetasPriceShoes(ImpresoraID, UsuarioID, ClienteID, TipoEtiquetaID, MostrarDetalle, PorLotes, Nave, FechaPrograma, LoteDe, LoteHasta, PorPedido, PedidoSICY, PedidoSAY, PorApartados, CadenaApartados)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetasConsumosFechas(ByVal naveId As Integer, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal impresora As Integer) As DataTable
        Dim objBu As New Programacion.Datos.EtiquetasDA
        Return objBu.ConsultaEtiquetasConsumosFechas(naveId, fechaPrograma, fechaProgramaAl, impresora)
    End Function

    Public Function ConsultaEtiquetasPlantaSuelaFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ConsultaEtiquetasPlantaSuelaFechas(naveid, fechaPrograma, fechaProgramaAl, idProveedor, idLotes, Clasificacion, Impresora, grupo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetasPlantaSuela_NavesFechas(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Clasificacion As String, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ConsultaEtiquetasPlantaSuela_NavesFechas(navesId, fechaPrograma, fechaProgramaAl, idProveedor, idLotes, Clasificacion, Impresora, grupo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetasPlantilla_NavesFechas(ByVal navesId As String, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ConsultaEtiquetasPlantilla_NavesFechas(navesId, fechaPrograma, fechaProgramaAl, idProveedor, idLotes, Impresora, grupo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultaEtiquetasPlantillaFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaProgramaAl As Date, ByVal idProveedor As Integer, ByVal idLotes As Integer, ByVal Impresora As Integer, ByVal grupo As String) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ConsultaEtiquetasPlantillaFechas(naveid, fechaPrograma, fechaProgramaAl, idProveedor, idLotes, Impresora, grupo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ProveedorSuelaPorGrupoFechas(ByVal fechaPrograma As Date, ByVal fechaProgramaAL As Date, ByVal clasificacionProvSuela As Integer, ByVal grupo As String) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ProveedorSuelaPorGrupoFechas(fechaPrograma, fechaProgramaAL, clasificacionProvSuela, grupo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteControlEtiquetasProveedoresSuelas(ByVal fechaDel As Date, ByVal fechaAl As Date, ByVal IdProveedor As Integer)
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ReporteControlEtiquetasProveedoresSuelas(fechaDel, fechaAl, IdProveedor)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ProveedorSuelaRangoFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaAl As Date, ByVal clasificacionProvSuela As Integer) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ProveedorSuelaRangoFechas(naveid, fechaPrograma, fechaAl, clasificacionProvSuela)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ProveedorPlantaRangoFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaAl As Date, ByVal clasificacionProvPlanta As Integer) As DataTable
        Dim obj As New Programacion.Datos.EtiquetasDA
        Try
            Return obj.ProveedorPlantaRangoFechas(naveid, fechaPrograma, fechaAl, clasificacionProvPlanta)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ProveedorPlantillaRangoFechas(ByVal naveid As Integer, ByVal fechaPrograma As Date, ByVal fechaAl As Date, ByVal clasificacionProvPlantilla As Integer) As DataTable
        Dim objDa As New Programacion.Datos.EtiquetasDA
        Try
            Return objDa.ProveedorPlantillaRangoFechas(naveid, fechaPrograma, fechaAl, clasificacionProvPlantilla)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarNavesSAY()
        Dim obj As New Programacion.Datos.EtiquetasDA
        Return obj.ConsultarNavesSAY()
    End Function

    Public Function ConsultaModelosAndrea(ByVal asignados As Integer)
        Dim obj As New Programacion.Datos.EtiquetasDA
        Return obj.ConsultaModelosAndrea(asignados)
    End Function

    Public Function GuardarModelosAndreaRastreo(ByVal xml As String)
        Dim obj As New Programacion.Datos.EtiquetasDA
        Return obj.GuardarModelosAndreaRastreo(xml)
    End Function



    Public Function ObtenerImagenProductoEstilo(ByVal ProductoEstiloId As Integer) As String
        Dim objDA As New Programacion.Datos.EtiquetasDA
        Dim dtRuta As New DataTable
        Dim rutaImagen As String

        Try
            dtRuta = objDA.ObtenerImagenProductoEstilo(ProductoEstiloId)

            If dtRuta IsNot Nothing AndAlso dtRuta.Rows.Count > 0 Then
                rutaImagen = CStr(dtRuta.Rows(0).Item("FotoProducto"))
                Return rutaImagen
            Else
                Return ""
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
