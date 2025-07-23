Imports Stimulsoft.Report

Public Class SalidasAlmacenBU
    Private reporte2 As New StiReport
    Public Function ListadoParametroSalidas(tipo_busqueda As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.ListadoParametroSalidas(tipo_busqueda)
        Return tabla
    End Function

    Public Function LlenarCombosGenerarEntrega(tipo_busqueda As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.LlenarCombosGenerarEntrega(tipo_busqueda)
        Return tabla
    End Function


    Public Function consultaGenerarEmbarques(ByVal FiltrosSalidas As Entidades.FiltrosSalidas) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.consultaGenerarEmbarques(FiltrosSalidas)
        Return tabla
    End Function

    Public Function consultaParesEmbarques(ByVal idSalidasPares As String) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.consultaParesEmbarques(idSalidasPares)
        Return tabla
    End Function

    Public Function generarEmbarques(ByVal datosEmbarque As Entidades.GeneracionEmbarque) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.generarEmbarques(datosEmbarque)
        Return tabla
    End Function

    Public Function generarSalida(ByVal datosSalida As Entidades.GeneracionSalida) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.generarSalida(datosSalida)
        Return tabla
    End Function

    Public Function generarIncidencia(ByVal datosIncidencia As Entidades.GeneracionIncidencia) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.generarIncidencia(datosIncidencia)
        Return tabla
    End Function

    Public Function seleccionarIncidencias(ByVal embarque As Integer, ByVal cliente As String) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.seleccionarIncidencias(embarque, cliente)
        Return tabla
    End Function

    Public Function seleccionarParesDevueltos(ByVal embarque As Integer, ByVal cliente As String) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.seleccionarParesDevueltos(embarque, cliente)
        Return tabla
    End Function

    Public Function seleccionarDatosEmbarque(ByVal embarque As Integer, ByVal cliente As String) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.seleccionarDatosEmbarque(embarque, cliente)
        Return tabla
    End Function

    Public Sub actualizarParesDevueltos(ByVal idSalidaDetalle As Integer, ByVal totalParesDevueltos As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.actualizarParesDevueltos(idSalidaDetalle, totalParesDevueltos)
    End Sub

    Public Function cancelarSalidas(ByVal idSalidaDetalle As String) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Return objDA.cancelarSalidas(idSalidaDetalle)
    End Function

    Public Function seleccionarEmbarqueAEditar(ByVal embarque As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.seleccionarEmbarqueAEditar(embarque)
        Return tabla
    End Function

    Public Function editarEmbarques(ByVal datosEmbarque As Entidades.GeneracionEmbarque) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.editarEmbarques(datosEmbarque)
        Return tabla
    End Function

    Public Function imprimirOrdenEmbarque(ByVal idEmbarquesSeleccionados As String, ByVal tipoConsulta As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.imprimirOrdenEmbarque(idEmbarquesSeleccionados, tipoConsulta)
        Return tabla
    End Function

    Public Function consultaParesEmbarquesConFiltros(ByVal FiltrosParesEmbarquesSalidas As Entidades.FiltrosParesEmbarquesSalidas) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.consultaParesEmbarquesConFiltros(FiltrosParesEmbarquesSalidas)
        Return tabla
    End Function

    Public Function consultaBitacoraEmbarques(ByVal idEmbarque As String) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.consultaBitacoraEmbarques(idEmbarque)
        Return tabla
    End Function

    Public Function actualizarDatosSAY() As Boolean
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim resultado As New Boolean
        resultado = objDA.actualizarDatosSAY()
        Return resultado
    End Function

    Public Function obtenerFechaUltimaActualizacionDatosSAY() As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerFechaUltimaActualizacionDatosSAY()
        Return tabla
    End Function

    Public Sub actualizarParesEntregadosEnRuta()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.actualizarParesEntregadosEnRuta()
    End Sub

    'INICIA ACTUALIZACION DE STATUS DE OT SAY
    Public Sub actualizarStatusOTSAYParesEnRuta()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.actualizarStatusOTSAYParesEnRuta()
    End Sub

    Public Sub actualizarStatusOTSAYParesEntregado()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.actualizarStatusOTSAYParesEntregado()
    End Sub

    Public Sub actualizarStatusOTSAYPartidasEnRuta()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.actualizarStatusOTSAYPartidasEnRuta()
    End Sub

    Public Sub actualizarStatusOTSAYPartidasEntregadas()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.actualizarStatusOTSAYPartidasEntregadas()
    End Sub

    Public Sub ActualizaParesSalidaApartado()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        objDA.ActualizaParesSalidaApartado()
    End Sub
    'TERMINA ACTUALIZACION DE STATUS DE OT SAY
    '**********************************************************************************************************************************
#Region "Salidas naves Alamcen V2"

    Public Function ObtenerInformacionNave(ByVal NaveSICYID As Integer, ByVal TipoProceso As String) As Entidades.ConfiguracionNaveSalida
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim Ent As New Entidades.ConfiguracionNaveSalida
        Dim dtResultado As New DataTable
        Try
            dtResultado = objDA.ObtenerInformacionNave(NaveSICYID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    Ent.NaveSICYID = dtResultado.Rows(0).Item("NaveSICYID").ToString()
                    Ent.Nave = dtResultado.Rows(0).Item("Nave").ToString()
                    Ent.Externa = CBool(dtResultado.Rows(0).Item("Externa"))
                    Ent.Maquila = CBool(dtResultado.Rows(0).Item("MAQUILA"))
                    Ent.SistemaSay = CBool(dtResultado.Rows(0).Item("TieneSAY"))
                    'Ent.TipoProceso = TipoProceso
                Else
                    Ent.NaveSICYID = 0
                    Ent.Nave = ""
                    Ent.Externa = 0
                    Ent.Maquila = 0
                    'Ent.TipoProceso = TipoProceso
                End If
            Else
                Ent.NaveSICYID = 0
                Ent.Nave = ""
                Ent.Externa = 0
                Ent.Maquila = 0
                'Ent.TipoProceso = TipoProceso
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Ent
    End Function

    Public Function ValidarSalidaPendienteNave(ByVal NaveSICYID As Integer) As Integer
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim IdSalidaNave As Integer = 0
        Dim dtResultado As DataTable
        Try
            dtResultado = objDA.ValidarSalidaPendienteNave(NaveSICYID)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    IdSalidaNave = dtResultado.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return IdSalidaNave
    End Function

    Public Function ValidarAtado(ByVal CodigoAtado As String) As Entidades.CapturaAtadoValido
        Dim AtadoValido As New Entidades.CapturaAtadoValido
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtCodigosAtados As New DataTable

        Try
            dtCodigosAtados = objDA.ValidarAtado(CodigoAtado)

            If dtCodigosAtados.Rows.Count > 0 Then
                For Each row As DataRow In dtCodigosAtados.Rows
                    AtadoValido.PIdAtado = row.Item("Atado")
                    AtadoValido.PIdNAve = row.Item("NaveSICYID")
                    AtadoValido.PLote = row.Item("Lote")
                    AtadoValido.PAño = row.Item("Año")
                    AtadoValido.PN_Pares = row.Item("ParesAtado")
                    AtadoValido.PDescripcion = row.Item("Descripcion")
                    AtadoValido.PIdCliente = row.Item("ClienteSICYID")
                    'AtadoValido.PN_AtadoEscaneado = row.Item("NumeroAtado")
                    AtadoValido.PValidacionEntradaPorPar = row.Item("ValidaEntradaPorPar")
                    AtadoValido.PValidacionSalidaPorPar = row.Item("ValidaSalidaPorPar")
                    AtadoValido.PLecturaPorCodigoCliente = CBool(row.Item("LecturaPorCodigoCliente"))
                    AtadoValido.PNumeroAtado = row.Item("NumeroAtado")
                    AtadoValido.PStatusAtado = 2
                    AtadoValido.PTipoLectura = row.Item("TipoCodigo")
                    AtadoValido.PEtiquetaEspecial = Convert.ToInt32(row.Item("EtiquetaEspecial"))
                    AtadoValido.PCartaInformativa = Convert.ToInt32(row.Item("TipoCodigo"))
                Next
            Else
                AtadoValido.PIdAtado = 0
            End If

        Catch ex As Exception

        End Try

        Return AtadoValido

    End Function


    Public Function InsertarInformacionDelLote(ByVal CodigoAtado As String, ByVal NaveSICYId As Integer, ByVal NaveMaquila As Integer, ByVal SalidaNaveProduccionID As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA

        Try
            Return objDA.InsertarInformacionDelLote(CodigoAtado, NaveSICYId, NaveMaquila, SalidaNaveProduccionID, UsuarioId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerInformacionLote(ByVal IdSalidaNave As Integer, ByVal Lote As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA

        Try
            Return objDA.ObtenerInformacionLote(IdSalidaNave, Lote)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConfirmacionPorPar(ByVal Lote As Integer, ByVal NaveSICYID As Integer, ByVal Año As Integer) As Boolean
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False
        Try
            dtResultado = objDA.ConfirmacionPorPar(Lote, NaveSICYID, Año)

            If dtResultado.Rows.Count > 0 Then
                Resultado = CBool(dtResultado.Rows(0).Item(0))
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Resultado
    End Function

    Public Function InsertarFolioSalida(ByVal NaveSICY As Integer, ByVal OperadorID As Integer) As Integer
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim FolioSalidaID As Integer = 0
        Try
            dtResultado = objDA.InsertarFolioSalida(NaveSICY, OperadorID)

            If dtResultado.Rows.Count > 0 Then
                FolioSalidaID = dtResultado.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return FolioSalidaID
    End Function

    Public Function RecuperarParesFolio(ByVal IdSalidaNave As Integer, ByVal Lote As Integer, ByVal NaveSICYId As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA

        Try
            Return objDA.RecuperarParesFolio(IdSalidaNave, Lote, NaveSICYId, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarAtadosFolio(ByVal IdSalidaNave As Integer, ByVal Lote As Integer, ByVal NaveSICYId As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA

        Try
            Return objDA.RecuperarAtadosFolio(IdSalidaNave, Lote, NaveSICYId, Año)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ActualizarStatusAtado(ByVal IdSalidaNave As Integer, ByVal Atado As String, ByVal StatusID As Integer, ByVal Lote As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.ActualizarStatusAtado(IdSalidaNave, Atado, StatusID, Lote)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarStatusSalida(ByVal IdSalidaNave As Integer, ByVal IdUsuario As String, ByVal NaveSICYID As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.ActualizarStatusSalida(IdSalidaNave, IdUsuario, NaveSICYID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RecuperarAtadosFolioSalida(ByVal IdSalidaNave As Integer, ByVal TipoProceso As String, ByVal AlmacenId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.RecuperarAtadosFolioSalida(IdSalidaNave, TipoProceso, AlmacenId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarLotesFolioSalida(ByVal IdSalidaNave As Integer, ByVal TipoProceso As String) As List(Of Entidades.InformacionLoteSalidaNave)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtREsultado As DataTable
        Dim EntLote As Entidades.InformacionLoteSalidaNave
        Dim ListaLote As New List(Of Entidades.InformacionLoteSalidaNave)
        Try
            dtREsultado = objDA.RecuperarLotesFolioSalida(IdSalidaNave)

            For Each Fila As DataRow In dtREsultado.Rows
                EntLote = New Entidades.InformacionLoteSalidaNave
                With EntLote
                    .Año = Fila.Item("Año")
                    '.ConfirmacionPorPar = Fila.Item("")
                    .Lote = Fila.Item("Lote")
                    .NaveSICYID = Fila.Item("NaveSICYID")
                    .ParesLote = Fila.Item("ParesLote")
                    '.StatusLote = Fila.Item("StatusLote")
                    .ParesConfirmados = Fila.Item("ParesEntrada")
                    If TipoProceso = "SALIDA" Then
                        If Fila.Item("ParesLote").ToString = Fila.Item("ParesSalida").ToString Then
                            .StatusLote = "1"
                        Else
                            .StatusLote = "0"
                        End If

                    ElseIf TipoProceso = "ENTRADA" Then
                        If Fila.Item("ParesLote").ToString = Fila.Item("ParesEntrada").ToString Then
                            .StatusLote = "1"
                        Else
                            .StatusLote = "0"
                        End If
                    End If
                End With
                ListaLote.Add(EntLote)
            Next
            Return ListaLote
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarParesFolioSalida(ByVal IdSalidaNave As Integer, ByVal AlmacenId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.RecuperarParesFolioSalida(IdSalidaNave, AlmacenId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub RegistrarErrorLectura(ByVal IdSalidaNave As Integer, ByVal CodigoLeido As String, ByVal CodigoAtado As String, ByVal Lote As Integer, ByVal año As Integer, ByVal NaveSICYID As Integer, ByVal UsuarioId As Integer, ByVal Proceso As String, ByVal DescripcionError As String)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.RegistrarErrorLectura(IdSalidaNave, CodigoLeido, CodigoAtado, Lote, año, NaveSICYID, UsuarioId, Proceso, DescripcionError)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ReporteObtenerResumenPares(ByVal FolioSalidaID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ReporteObtenerResumenPares(FolioSalidaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReporteObtenerResumenFolio(ByVal FolioSalidaID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ReporteObtenerResumenFolio(FolioSalidaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ActualizarStatusFolioIngresando(ByVal FolioSalidaID As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.ActualizarStatusFolioIngresando(FolioSalidaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ValidaFolioEntrada(ByVal FolioSalidaID As Integer, ByVal NaveSICYID As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ValidaFolioEntrada(FolioSalidaID, NaveSICYID, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarAtadosFolioEntrada(ByVal FolioSalidaID As Integer) As List(Of Entidades.CapturaAtadoValido)
        Dim AtadoValido As New Entidades.CapturaAtadoValido
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtCodigosAtados As New DataTable
        Dim ListaAtados As New List(Of Entidades.CapturaAtadoValido)

        Try
            dtCodigosAtados = objDA.RecuperarAtadosFolioEntrada(FolioSalidaID)

            If dtCodigosAtados.Rows.Count > 0 Then
                For Each row As DataRow In dtCodigosAtados.Rows
                    AtadoValido = New Entidades.CapturaAtadoValido
                    AtadoValido.PIdAtado = row.Item("Atado")
                    AtadoValido.PIdNAve = row.Item("NaveSICYID")
                    AtadoValido.PLote = row.Item("Lote")
                    AtadoValido.PAño = row.Item("Año")
                    AtadoValido.PN_Pares = row.Item("ParesAtado")
                    AtadoValido.PDescripcion = row.Item("Descripcion")
                    AtadoValido.PIdCliente = row.Item("ClienteSICYID")
                    AtadoValido.PN_AtadoEscaneado = row.Item("NumeroAtado")
                    AtadoValido.PValidacionEntradaPorPar = row.Item("ValidaEntradaPorPar")
                    AtadoValido.PValidacionSalidaPorPar = row.Item("ValidaSalidaPorPar")
                    AtadoValido.PLecturaPorCodigoCliente = CBool(row.Item("LecturaPorCodigoCliente"))
                    AtadoValido.PStatusAtado = row.Item("ResultadoAtadoEntrada")
                    'If row.Item("ResultadoAtadoEntrada") = 0 Then
                    '    AtadoValido.PStatusAtado = 2
                    'Else
                    '    AtadoValido.PStatusAtado = row.Item("ResultadoAtadoEntrada")
                    'End If
                    ListaAtados.Add(AtadoValido)
                Next

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return ListaAtados
    End Function

    Public Function RecuperarAtadosFolioEntradaDataTable(ByVal FolioSalidaID As Integer) As DataTable
        Dim AtadoValido As New Entidades.CapturaAtadoValido
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtCodigosAtados As New DataTable
        Dim ListaAtados As New List(Of Entidades.CapturaAtadoValido)

        Try
            dtCodigosAtados = objDA.RecuperarAtadosFolioEntrada(FolioSalidaID)
        Catch ex As Exception
            Throw ex
        End Try

        Return dtCodigosAtados
    End Function

    Public Sub ActualizaStatusAtadoEntrada(ByVal FolioSalidaID As Integer, ByVal Atado As String, ByVal StatusID As Integer, ByVal Lote As Integer, ByVal CarritoID As Integer, ByVal AlmacenId As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.ActualizaStatusAtadoEntrada(FolioSalidaID, Atado, StatusID, Lote, CarritoID, AlmacenId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ObtenerPlataformasFolio(ByVal FolioSalidaID As Integer) As List(Of Entidades.PlataformaEntrada)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim ListaPlataformas As New List(Of Entidades.PlataformaEntrada)
        Dim Plataforma As New Entidades.PlataformaEntrada

        Try
            dtResultado = objDA.ObtenerPlataformasFolio(FolioSalidaID)

            If dtResultado.Rows.Count > 0 Then
                For Each Fila As DataRow In dtResultado.Rows
                    Plataforma = New Entidades.PlataformaEntrada
                    With Plataforma
                        .IdPlataforma = Fila.Item("CarritoId")
                        .Plataforma = Fila.Item("Plataforma")
                    End With
                    ListaPlataformas.Add(Plataforma)
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return ListaPlataformas
    End Function

    Public Function FinalizarEntradaLote(ByVal FolioSalidaID As Integer, ByVal AlmacenID As Integer, ByVal UsuarioId As Integer, ByVal Tipo_Nave As Boolean, ByVal IdNaveSICY As Integer, ByVal ComercializadoraId As Integer) As Boolean
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False
        Try
            dtResultado = objDA.FinalizarEntradaLote(FolioSalidaID, AlmacenID, UsuarioId, Tipo_Nave, IdNaveSICY, ComercializadoraId)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0).ToString.Trim() = "EXITO" Then
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

    Public Sub actualizarEstatus(ByVal FolioSalidaID As Integer, ByVal Nave As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.ActualizarEstatus(FolioSalidaID, Nave)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DescartarLotes(ByVal FolioSalidaID As Integer, ByVal Lote As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.DescartarLotes(FolioSalidaID, Lote)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ValidarEntradaPendienteNave(ByVal NaveSICYId As Integer, ByVal ComercializadoraID As Integer) As Integer
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim FolioSalidaId As Integer = 0
        Try

            dtResultado = objDA.ValidarEntradaPendienteNave(NaveSICYId, ComercializadoraID)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count() > 0 Then
                    FolioSalidaId = dtResultado.Rows(0).Item(0)
                Else
                    FolioSalidaId = 0
                End If
            Else
                FolioSalidaId = 0
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return FolioSalidaId
    End Function

    Public Function InsertarFolioEntradaNaveMaquila(ByVal NaveSICYId As Integer, ByVal UsuarioID As Integer, ByVal ComercializadoraID As Integer) As Integer
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim FolioSalidaId As Integer = 0

        Try
            dtResultado = objDA.InsertarFolioEntradaNaveMaquila(NaveSICYId, UsuarioID, ComercializadoraID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    FolioSalidaId = dtResultado.Rows(0).Item(0)
                Else
                    FolioSalidaId = 0
                End If
            Else
                FolioSalidaId = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return FolioSalidaId
    End Function

    Public Function ObtenerPlataformasFolioEntrada(ByVal FolioSalidaID As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerPlataformasFolioEntrada(FolioSalidaID)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertarErrorDeLectura(ByVal CodigoError As Entidades.CodigosErroneos)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.InsertarErrorDeLectura(CodigoError)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub LimpiarCodigoErrorAtado(ByVal FolioSalidaID As Integer, ByVal Atado As String)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.LimpiarCodigoErrorAtado(FolioSalidaID, Atado)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DescartarLotesEntrada(ByVal FolioSalidaID As Integer, ByVal Lote As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.DescartarLotesEntrada(FolioSalidaID, Lote)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ValidarExisteAtado(ByVal Atado As String, ByVal NaveSicyId As Integer) As Boolean   '' OAMB CAMBIOS (03/07/2024)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.ValidarExisteAtado(Atado, NaveSicyId)
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

    Public Function EnviarAHistoricoFolio(ByVal FolioSalidaID As Integer) As Boolean
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim Resultado As Boolean = False

        Try
            dtResultado = objDA.EnviarAHistoricoFolio(FolioSalidaID)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0).ToString.Trim() = "EXITO" Then
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

    Public Function ObtenerParesDescartados(ByVal FolioSalidaID As Integer, ByVal AlmacenId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerParesDescartados(FolioSalidaID, AlmacenId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerListaLotesReporteSalida(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerListaLotesReporteSalida(NaveSICYID, FechaSalidaInicio, FechaSalidaFin)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTotalParesRecibidos(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesRecibidos(NaveSICYID, FechaSalidaInicio, FechaSalidaFin, NumeroAlmacen, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTotalParesNoEmbarcados(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesNoEmbarcados(NaveSICYID, FechaSalidaInicio, FechaSalidaFin, NumeroAlmacen, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerTotalParesFaltantes(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesFaltantes(NaveSICYID, FechaSalidaInicio, FechaSalidaFin, NumeroAlmacen, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ObtenerNombreOperadorReporteEntrada(ByVal NaveSICYID As Integer, ByVal FechaSalidaInicio As Date, ByVal FechaSalidaFin As Date) As String
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim Nombre As String = ""
        Dim dtResultado As New DataTable

        Try
            dtResultado = objDA.ObtenerNombreOperadorReporteEntrada(NaveSICYID, FechaSalidaInicio, FechaSalidaFin)
            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    Nombre = dtResultado.Rows(0).Item(0).ToString
                Else
                    Nombre = String.Empty
                End If
            Else
                Nombre = String.Empty
            End If
        Catch ex As Exception
            Throw ex
        End Try
        Return Nombre
    End Function

    Public Function ValidarAtadoEntrada(ByVal CodigoAtado As String) As Entidades.CapturaAtadoValido
        Dim AtadoValido As New Entidades.CapturaAtadoValido
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtCodigosAtados As New DataTable

        Try
            dtCodigosAtados = objDA.ValidarAtadoEntrada(CodigoAtado)

            If dtCodigosAtados.Rows.Count > 0 Then
                For Each row As DataRow In dtCodigosAtados.Rows
                    AtadoValido.PIdAtado = row.Item("Atado")
                    AtadoValido.PIdNAve = row.Item("NaveSICYID")
                    AtadoValido.PLote = row.Item("Lote")
                    AtadoValido.PAño = row.Item("Año")
                    AtadoValido.PN_Pares = row.Item("ParesAtado")
                    AtadoValido.PDescripcion = row.Item("Descripcion")
                    AtadoValido.PIdCliente = row.Item("ClienteSICYID")
                    'AtadoValido.PN_AtadoEscaneado = row.Item("NumeroAtado")
                    AtadoValido.PValidacionEntradaPorPar = row.Item("ValidaEntradaPorPar")
                    AtadoValido.PValidacionSalidaPorPar = row.Item("ValidaSalidaPorPar")
                    AtadoValido.PLecturaPorCodigoCliente = CBool(row.Item("LecturaPorCodigoCliente"))
                    AtadoValido.PNumeroAtado = row.Item("NumeroAtado")
                    AtadoValido.PStatusAtado = 2
                    AtadoValido.PTipoLectura = row.Item("TipoCodigo")
                Next
            Else
                AtadoValido.PIdAtado = 0
            End If

        Catch ex As Exception

        End Try

        Return AtadoValido

    End Function

    Public Sub InsertarAtadoNoEmbarcado(ByVal IdsalidaNave As Integer, ByVal Atado As String, ByVal Año As Integer, ByVal Descripcion As String, ByVal ClienteID As Integer, ByVal NaveID As Integer, ByVal Lote As Integer, ByVal NumeroAtado As Integer, ByVal Pares As Integer, ByVal StatusID As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.InsertarAtadoNoEmbarcado(IdsalidaNave, Atado, Año, Descripcion, ClienteID, NaveID, Lote, NumeroAtado, Pares, StatusID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ConsultaAtadosErroneos(ByVal IdsalidaNave As Integer) As List(Of Entidades.CapturaAtadoValido)
        Dim Atado As New Entidades.CapturaAtadoValido
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim DtResultado As New DataTable
        Dim ListaAtados As New List(Of Entidades.CapturaAtadoValido)
        Try
            DtResultado = objDA.ConsultaAtadosErroneos(IdsalidaNave)

            For Each Fila As DataRow In DtResultado.Rows
                Atado = New Entidades.CapturaAtadoValido
                Atado.PIdAtado = Fila.Item("Atado")
                Atado.PIdNAve = Fila.Item("IdNave")
                Atado.PLote = Fila.Item("Lote")
                Atado.PAño = Fila.Item("Año")
                Atado.PN_Pares = Fila.Item("Pares")
                Atado.PDescripcion = Fila.Item("Descripcion")
                Atado.PIdCliente = Fila.Item("ClienteID")
                'AtadoValido.PN_AtadoEscaneado = row.Item("NumeroAtado")
                Atado.PValidacionEntradaPorPar = 0
                Atado.PValidacionSalidaPorPar = 0
                Atado.PLecturaPorCodigoCliente = 0
                Atado.PNumeroAtado = Fila.Item("NumeroAtado")
                Atado.PStatusAtado = 11
                Atado.PTipoLectura = "PARYUYIN"
                ListaAtados.Add(Atado)
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return ListaAtados
    End Function

#End Region

    Public Function consultaPerfilUsuario(ByVal usuarioId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objDA.consultaPerfilUsuario(usuarioId)

        Return tabla

    End Function

    Public Sub ActuallizarPrecio()
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.ActuallizarPrecio()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub LimpiarParesErrores(ByVal NaveSICYID As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            objDA.LimpiarParesErrores(NaveSICYID)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function ValidaParesNave(ByVal NaveSICYID As Integer) As Boolean
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim Resultado As Boolean = False
        Dim dtResultado As DataTable

        Try
            dtResultado = objDA.ValidaParesNave(NaveSICYID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0) > 0 Then
                        Resultado = True
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

    Public Function GeneraParesNave(ByVal NaveSICYID As Integer) As Boolean
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim Resultado As Boolean = False
        Dim dtResultado As DataTable

        Try
            dtResultado = objDA.GeneraParesNave(NaveSICYID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    If dtResultado.Rows(0).Item(0) > 0 Then
                        Resultado = True
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

    Public Function CorregirErrores()
        Dim datos As New Datos.SalidasAlmacenDA
        Return datos.CorregirErrores()
    End Function

    Public Function ObtenerTotalParesFacturados_o_Remisionados(ByVal NaveSICYID As Integer, ByVal Fecha As Date, ByVal tipo As Integer, ByVal numeroAlmacen As Integer, ByVal ComercializadoraId As Integer) As DataTable
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Try
            Return objDA.ObtenerTotalParesFacturados_o_Remisionados(NaveSICYID, Fecha, tipo, numeroAlmacen, ComercializadoraId)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Consultar_Si_Es_Maquila(ByVal naveSICY As Integer) As DataTable
        Dim datos As New Datos.SalidasAlmacenDA
        Return datos.ConsultarSi_Es_Maquila(naveSICY)
    End Function
    Public Function ConsultarParesSalidaDestructiva(ByVal anio As Integer, ByVal cedis As Integer) As DataTable
        Dim datos As New Datos.SalidasAlmacenDA
        Return datos.ConsultarParesSalidaDestructiva(anio, cedis)
    End Function

    Public Function ImprimirReporte_Entrada_Almacen(ByVal NaveID As Integer, ByVal NumeroAlmacen As Integer, ByVal Fecha As String, ByVal usuarioCreo As String, ByVal usuarioRecibio As String, ByVal ComercializadoraId As Integer) As String

        Dim dsTotalesDeSalidas As New DataSet
        Dim dtTotalesEntrada As New DataTable
        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalPares As Integer = 0
        Dim TotalAtados As Integer = 0
        Dim TotalLotes As Integer = 0
        Dim lProgramas As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim nombreArchivo As String
        Try

            Fecha_Inicio = Fecha
            Fecha_Fin = Fecha
            Id_Nave = NaveID
            NumeroAlmacen = NumeroAlmacen


            dsTotalesDeSalidas = Recuperar_Informacion_Reporte_Entradas(Fecha_Inicio, Fecha_Fin, Id_Nave, NumeroAlmacen, ComercializadoraId)

            'Recuperamos los totales
            For Each row As DataRow In dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows
                TotalPares = TotalPares + row.Item("Pares")
                TotalAtados = TotalAtados + row.Item("Atados")
                TotalLotes = TotalLotes + row.Item("lotes")
                lProgramas.Add(row.Item("Programa"))
            Next

            'Recuperar el Nombre del Operador
            Operador = ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsTotalesDeSalidas.Tables("dtTotalesRecibidos"), Fecha_Inicio)
            Dim ParesProgramaBien As Integer = 0
            Dim AtadosProgramaBien As Integer = 0
            Dim LotesProgramaBien As Integer = 0
            Dim ParesProgramaMal As Integer = 0
            Dim AtadosProgramaMal As Integer = 0
            Dim LotesProgramaMal As Integer = 0

            ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
            AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
            LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
            ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
            AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
            LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")

            Dim obj As New SalidaNavesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = LeerReporteporClave("ALM_ENTRADAS_RESUMEN")
            Dim archivo As String = "C:\ReportesIngresos" + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = ObtenerLogoNave(43)
            reporte("nombreNave") = obj.RecuperarNombreNave(Id_Nave)
            reporte("NombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
            reporte("Usuario") = usuarioCreo
            reporte("Recibio") = usuarioRecibio
            reporte("Operador") = Operador
            reporte("fecha_inicio") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte("fecha_fin") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte("TotalPares") = TotalPares
            reporte("TotalAtados") = TotalAtados
            reporte("TotalLotes") = TotalLotes
            reporte("TotalProgramas") = lProgramas.Count
            reporte("ParesProgramaBien") = ParesProgramaBien
            reporte("AtadosProgramaBien") = AtadosProgramaBien
            reporte("LotesProgramaBien") = LotesProgramaBien
            reporte("ParesProgramaMal") = ParesProgramaMal
            reporte("AtadosProgramaMal") = AtadosProgramaMal
            reporte("LotesProgramaMal") = LotesProgramaMal

            reporte.Dictionary.Clear()
            reporte.RegData(dsTotalesDeSalidas)
            reporte.Dictionary.Synchronize()

            reporte.Render()

            Dim JoinReport As StiReport = New StiReport
            JoinReport.NeedsCompiling = False
            JoinReport.IsRendered = True
            JoinReport.RenderedPages.Clear()

            Dim JoinReport2 As StiReport = New StiReport
            JoinReport2.NeedsCompiling = False
            JoinReport2.IsRendered = True
            JoinReport2.RenderedPages.Clear()

            If IsNothing(reporte.CompiledReport) = False Then

                For Each Page2 As Stimulsoft.Report.Components.StiPage In reporte.CompiledReport.RenderedPages
                    Page2.Report = JoinReport2
                    Page2.NewGuid()
                    JoinReport2.RenderedPages.Add(Page2)
                Next
            End If



            Dim isnave = Consultar_Si_Es_Maquila(Id_Nave)

            If isnave.Rows.Count <> 0 Then

                Dim num2 = ImprimirReporte_Facturacion_Remision(Fecha_Inicio, Fecha_Fin, Id_Nave, NumeroAlmacen, ComercializadoraId)
                reporte2.Render()
                If IsNothing(reporte2.CompiledReport) = False Then
                    For Each Page3 As Stimulsoft.Report.Components.StiPage In reporte2.CompiledReport.RenderedPages
                        Page3.Report = JoinReport2
                        Page3.NewGuid()
                        JoinReport2.RenderedPages.Add(Page3)
                    Next
                End If
                nombreArchivo = "C:\ReportesIngresos" + "\" + "EntradaAlmacen_" + isnave.Rows(0).Item("Nave") + "_" + Date.Today.ToString("dd_MM_yyyy") + "_" + Date.Now.ToString("HH-mm-ss") + ".pdf"
                JoinReport2.ExportDocument(StiExportFormat.Pdf, nombreArchivo)
                Return nombreArchivo & "|" & isnave.Rows(0).Item("Correo") & "|" & isnave.Rows(0).Item("Nave")
                ' enviarcorreo(nombreArchivo, isnave.Rows(0).Item("Correo"), isnave.Rows(0).Item("Nave"))
            End If
            Return "N"

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function ImprimirReporte_Facturacion_Remision(ByVal fechaInicio As String, ByVal fechafin As String, ByVal IdNave As Integer, ByVal Numero_Almacen As Integer, ByVal ComercializadoraId As Integer) As Integer

        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalParesf As Integer = 0
        Dim TotalAtadosf As Integer = 0
        Dim TotalLotesf As Integer = 0
        Dim lProgramasf As New HashSet(Of String)
        Dim TotalParesr As Integer = 0
        Dim TotalAtadosr As Integer = 0
        Dim TotalLotesr As Integer = 0
        Dim lProgramasr As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramasF As New DataTable
        Dim dtTablaCantidadesProgramasR As New DataTable
        Dim NumeroAlmacen As Integer = 0

        Try


            Fecha_Inicio = fechaInicio
            Fecha_Fin = fechafin
            Id_Nave = IdNave
            NumeroAlmacen = Numero_Almacen



            'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
            Dim dsFacturacion As New DataSet("dsFacturados")
            Dim dsRemision As New DataSet("dsRemision")
            Dim dtFacturacion As New DataTable("dtFacturados")
            Dim dtRemision As New DataTable("dtRemision")

            dtFacturacion = ObtenerTotalParesFacturados_o_Remisionados(Id_Nave, Fecha_Inicio, 1, NumeroAlmacen, ComercializadoraId)
            dtRemision = ObtenerTotalParesFacturados_o_Remisionados(Id_Nave, Fecha_Inicio, 0, NumeroAlmacen, ComercializadoraId)
            ' dtTotalesFaltantes = ObjBU.ObtenerTotalParesFaltantes(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen)

            dtFacturacion.TableName = "dtFacturados"
            dtRemision.TableName = "dtRemision"
            'dtTotalesFaltantes.TableName = "dtTotalesFaltantes"

            dsFacturacion.Tables.Add(dtFacturacion)
            dsRemision.Tables.Add(dtRemision)

            If dsFacturacion.Tables("dtFacturados").Rows.Count = 0 Then

                Return 0
            End If


            'dsTotalesDeSalidas.Tables.Add(dtTotalesFaltantes)

            'Recuperamos los totales
            For Each row As DataRow In dsFacturacion.Tables("dtFacturados").Rows
                TotalParesf = TotalParesf + row.Item("Pares")
                TotalAtadosf = TotalAtadosf + row.Item("Atados")
                TotalLotesf = TotalLotesf + row.Item("lotes")
                lProgramasf.Add(row.Item("Programa"))
            Next

            'Recuperamos los totales
            For Each row As DataRow In dsRemision.Tables("dtRemision").Rows
                TotalParesr = TotalParesr + row.Item("Pares")
                TotalAtadosr = TotalAtadosr + row.Item("Atados")
                TotalLotesr = TotalLotesr + row.Item("lotes")
                lProgramasr.Add(row.Item("Programa"))
            Next

            'Recuperar el Nombre del Operador
            Operador = ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramasF = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsFacturacion.Tables("dtFacturados"), Fecha_Inicio)
            Dim ParesProgramaBienF As Integer = 0
            Dim AtadosProgramaBienF As Integer = 0
            Dim LotesProgramaBienF As Integer = 0
            Dim ParesProgramaMalF As Integer = 0
            Dim AtadosProgramaMalF As Integer = 0
            Dim LotesProgramaMalF As Integer = 0

            ParesProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Pares")
            AtadosProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Atados")
            LotesProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Lotes")
            ParesProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Pares")
            AtadosProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Atados")
            LotesProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Lotes")

            'Recuperar el Nombre del Operador
            Operador = ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramasR = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsRemision.Tables("dtRemision"), Fecha_Inicio)
            Dim ParesProgramaBienR As Integer = 0
            Dim AtadosProgramaBienR As Integer = 0
            Dim LotesProgramaBienR As Integer = 0
            Dim ParesProgramaMalR As Integer = 0
            Dim AtadosProgramaMalR As Integer = 0
            Dim LotesProgramaMalR As Integer = 0

            ParesProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Pares")
            AtadosProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Atados")
            LotesProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Lotes")
            ParesProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Pares")
            AtadosProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Atados")
            LotesProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Lotes")



            Dim EntidadReporte As Entidades.Reportes
            Dim obj As New SalidaNavesBU
            EntidadReporte = LeerReporteporClave("REPORTE_ENTRADAS_FACT_REM")
            Dim archivo As String = "C:\ReportesIngresos" + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte2.Load(archivo)
            reporte2.Compile()
            reporte2("urlImagenNave") = ObtenerLogoNaveSICY(8)
            reporte2("nombreNave") = obj.RecuperarNombreNave(Id_Nave)
            reporte2("nombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
            'reporte2("nombreCreo") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            'reporte2("nombreRecibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
            reporte2("Operador") = Operador
            reporte2("fecha") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte2("fecha_impresion") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte2("TotalParesF") = TotalParesf
            reporte2("TotalAtadosF") = TotalAtadosf
            reporte2("TotalLotesF") = TotalLotesf
            reporte2("TotalProgramasF") = lProgramasf.Count
            reporte2("ParesProgramadosBienF") = ParesProgramaBienF
            reporte2("AtadosProgramadosBienF") = AtadosProgramaBienF
            reporte2("LotesProgramadosBienF") = LotesProgramaBienF
            reporte2("ParesProgramadosMalF") = ParesProgramaMalF
            reporte2("AtadosProgramadosMalF") = AtadosProgramaMalF
            reporte2("LotesProgramadosMalF") = LotesProgramaMalF
            reporte2("TotalParesR") = TotalParesr
            reporte2("TotalAtadosR") = TotalAtadosr
            reporte2("TotalLotesR") = TotalLotesr
            reporte2("TotalProgramasR") = lProgramasf.Count
            reporte2("ParesProgramadosBienR") = ParesProgramaBienR
            reporte2("AtadosProgramadosBienR") = AtadosProgramaBienR
            reporte2("LotesProgramadosBienR") = LotesProgramaBienR
            reporte2("ParesProgramadosMalR") = ParesProgramaMalR
            reporte2("AtadosProgramadosMalR") = AtadosProgramaMalR
            reporte2("LotesProgramadosMalR") = LotesProgramaMalR

            reporte2.Dictionary.Clear()
            reporte2.RegData(dsFacturacion)
            reporte2.RegData(dsRemision)
            reporte2.Dictionary.Synchronize()

            Return 1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function Recuperar_Informacion_Reporte_Entradas(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraID As Integer) As DataSet

        Dim dsTotalesDeSalidas As New DataSet("dsTotalesDeSalidas")
        Dim dtTotalesRecibidos As New DataTable("dtTotalesRecibidos")
        Dim dtTotalesNoEmbarcadosLeidos As New DataTable("dtTotalesNoEmbarcadosLeidos")
        Dim dtTotalesFaltantes As New DataTable("dtTotalesFaltantes")

        dtTotalesRecibidos = ObtenerTotalParesRecibidos(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen, ComercializadoraID)
        dtTotalesNoEmbarcadosLeidos = ObtenerTotalParesNoEmbarcados(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen, ComercializadoraID)
        dtTotalesFaltantes = ObtenerTotalParesFaltantes(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen, ComercializadoraID)

        dtTotalesRecibidos.TableName = "dtTotalesRecibidos"
        dtTotalesNoEmbarcadosLeidos.TableName = "dtTotalesNoEmbarcadosLeidos"
        dtTotalesFaltantes.TableName = "dtTotalesFaltantes"

        dsTotalesDeSalidas.Tables.Add(dtTotalesRecibidos)
        dsTotalesDeSalidas.Tables.Add(dtTotalesNoEmbarcadosLeidos)
        dsTotalesDeSalidas.Tables.Add(dtTotalesFaltantes)

        Return dsTotalesDeSalidas
    End Function
    Private Function RecuperarCantidadesProgramasEnTiempoYAtrasados(ByVal dtTabla As DataTable, ByVal fecha_Salida As Date) As DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim Dias As Integer
        Dim programa As Date
        Dim ParesBien As Integer = 0
        Dim ParesMal As Integer = 0
        Dim AtadosBien As Integer = 0
        Dim AtadosMal As Integer = 0
        Dim LotesBien As Integer = 0
        Dim LotesMal As Integer = 0
        Dim diasTotales As Double = 0

        For Each row As DataRow In dtTabla.Rows
            programa = row.Item("Programa")
            Dias = (fecha_Salida - programa).TotalDays
            'borrar---------------------------------------------------------------------------
            Dias = DateDiff(DateInterval.Day, programa, fecha_Salida) 'dias que existen entre el rango de fechas
            For index As Integer = 1 To Dias
                If index = 1 Then
                    If programa.Month = 3 Then
                        If programa.Day = 21 Then
                        ElseIf programa.Day = 22 Then
                        ElseIf programa.Day = 23 Then
                        ElseIf programa.Day = 24 Then
                        ElseIf programa.Day = 25 Then
                        ElseIf programa.Day = 26 Then
                        ElseIf programa.Day = 27 Then
                            If Not programa.DayOfWeek = 0 Then
                                diasTotales = diasTotales + 1
                            End If
                        Else
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                End If
                If DateAdd(DateInterval.Day, index, programa).Month = 3 Then
                    If DateAdd(DateInterval.Day, index, programa).Day = 21 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 22 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 23 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 24 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 25 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 26 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 27 Then
                        If Not DateAdd(DateInterval.Day, index, programa).DayOfWeek = 0 Then
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                Else
                    diasTotales = diasTotales + 1
                End If
            Next
            Dias = diasTotales
            'borrar---------------------------------------------------------------------------
            'Dias = 14
            If Dias <= 5 Then
                ParesBien += row.Item("PARES")
                AtadosBien += row.Item("ATADOS")
                LotesBien += 1
            ElseIf Dias = 6 Then
                If (programa.DayOfWeek = 3 And fecha_Salida.DayOfWeek = 1) Or
                    (programa.DayOfWeek = 4 And fecha_Salida.DayOfWeek = 2) Or
                    (programa.DayOfWeek = 5 And fecha_Salida.DayOfWeek = 3) Or
                    (programa.DayOfWeek = 6 And fecha_Salida.DayOfWeek = 4) Then
                    ParesBien += row.Item("PARES")
                    AtadosBien += row.Item("ATADOS")
                    LotesBien += 1
                Else
                    ParesMal += row.Item("PARES")
                    AtadosMal += row.Item("ATADOS")
                    LotesMal += 1
                End If
            Else
                ParesMal += row.Item("PARES")
                AtadosMal += row.Item("ATADOS")
                LotesMal += 1
            End If
            diasTotales = 0
        Next

        Dim columns As DataColumnCollection = dtTablaCantidadesProgramas.Columns
        Dim columna0 As New DataColumn
        columna0.DataType = Type.GetType("System.Double")
        columna0.DefaultValue = 0
        columna0.ColumnName = "Pares"
        columns.Add(columna0)

        Dim columna1 As New DataColumn
        columna1.DataType = Type.GetType("System.Double")
        columna1.DefaultValue = 0
        columna1.ColumnName = "Atados"
        columns.Add(columna1)

        Dim columna2 As New DataColumn
        columna2.DataType = Type.GetType("System.Double")
        columna2.DefaultValue = 0
        columna2.ColumnName = "Lotes"
        columns.Add(columna2)

        Dim newCustomersRow As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow("Pares") = ParesBien
        newCustomersRow("Atados") = AtadosBien
        newCustomersRow("Lotes") = LotesBien
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow)

        Dim newCustomersRow1 As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow1("Pares") = ParesMal
        newCustomersRow1("Atados") = AtadosMal
        newCustomersRow1("Lotes") = LotesMal
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow1)

        dtTablaCantidadesProgramas.TableName = "dtTablaCantidadesProgramas"

        Return dtTablaCantidadesProgramas
    End Function

    Public Function LeerReporteporClave(ByVal Clave As String) As Entidades.Reportes
        Dim OBJBU As New Datos.SalidasAlmacenDA
        Return OBJBU.LeerReporteClave(Clave)
    End Function
    Public Function ObtenerLogoNaveSICY(ByVal naveid As Int32) As String
        Dim objbu As New Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.ObtenerLogotipoSICYNave(naveid)
        Dim url As String = String.Empty
        For Each row As DataRow In tabla.Rows
            url = row("nave_logotipourl").ToString
        Next
        Return url
    End Function
    Public Function ObtenerLogoNave(ByVal naveid As Int32) As String
        Dim objbu As New Datos.SalidasAlmacenDA
        Dim tabla As New DataTable
        tabla = objbu.ObtenerLogotipoNave(naveid)
        Dim url As String = String.Empty
        For Each row As DataRow In tabla.Rows
            url = row("nave_logotipourl").ToString
        Next
        Return url
    End Function

    Public Sub ActualizarEstatusPedido(ByVal PedidoSICY As String)
        Dim objbu As New Datos.SalidasAlmacenDA
        objbu.ActualizarEstatusPedido(PedidoSICY)
    End Sub

    Public Sub ReplicarEstatusPedidoSAY_SICY(ByVal PedidoSICY As String)
        Dim objbu As New Datos.SalidasAlmacenDA
        objbu.ReplicarEstatusPedidoSAY_SICY(PedidoSICY)
    End Sub

    Public Function ReporteObtenerResumenParesLotesPiloto(ByVal FolioSalidaID As Integer) As DataTable
        Dim objbu As New Datos.SalidasAlmacenDA
        Return objbu.ReporteObtenerResumenParesLotesPiloto(FolioSalidaID)
    End Function

    Public Function ReporteObtenerResumeLotes(ByVal FolioSalidaID As Integer) As DataTable
        Dim objbu As New Datos.SalidasAlmacenDA
        Return objbu.ReporteObtenerResumeLotes(FolioSalidaID)
    End Function

    Public Function ObtenerLotesPilotoFolio(ByVal FolioSalidaID As Integer) As List(Of Integer)
        Dim objbu As New Datos.SalidasAlmacenDA
        Dim dtResultado As New DataTable
        Dim ListaLotes As New List(Of Integer)

        dtResultado = objbu.ReporteObtenerResumeLotes(FolioSalidaID)

        If dtResultado.Rows.Count > 0 Then
            For Each Fila As DataRow In dtResultado.Rows
                ListaLotes.Add(CInt(Fila.Item(0)))
            Next

        End If

        Return ListaLotes

    End Function

    'Laura 14/07/2023
    Public Sub ActualizacionTipoLotesSalidasNaves(ByVal FolioSalidaID As Integer)
        Dim objbu As New Datos.SalidasAlmacenDA
        objbu.ActualizacionTipoLotesSalidasNaves(FolioSalidaID)
    End Sub





    '' CAMBIOS (10/08/2024) - Se agerga una validación para la solución de los códigos de par con misma configuración de atado.
    Public Function VerficarAtadoPar(ByVal CodigoLeido As String) As String
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA
        Dim dtCodigos As New DataTable
        Dim CodigoFinal As String = ""

        Try
            dtCodigos = objDA.ValidarAtadoNuevo(CodigoLeido)

            If dtCodigos.Rows.Count > 0 Then
                CodigoFinal = dtCodigos.Rows(0).Item("Codigo")
            End If

        Catch ex As Exception

        End Try

        Return CodigoFinal
    End Function

    Public Sub LimpiarTablaParesErroneos(ByVal NaveSicyId As Integer)
        Dim objDA As New Almacen.Datos.SalidasAlmacenDA

        Try
            objDA.LimpiarTablaParesErroneos(NaveSicyId)

        Catch ex As Exception

        End Try
    End Sub

End Class

