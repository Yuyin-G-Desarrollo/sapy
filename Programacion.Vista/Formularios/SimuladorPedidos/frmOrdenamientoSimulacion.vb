Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmOrdenamientoSimulacion

    'Private hiloProceso As Threading.Thread
    'Private hiloSUBProceso As System.Threading.SynchronizationContext = System.Threading.SynchronizationContext.Current

    Private progressActualGlobal As Int32
    Private filaGrid As Int32
    Private porcentaje As Int32 = 0
    Private dtCapacidadesArticuloGlobal As DataTable
    Private dtCapacidadesHormasGlobal As DataTable
    Private dtCapacidadesGrupoGlobal As DataTable
    Private dtCapacidadesLineaProduccionGlobal As DataTable

    Public Function validarEntradaSimulacion() As Boolean
        Dim objBU As New Negocios.SimulacionBU
        Dim dato As Boolean = objBU.consultaEstatusSimulacionActual
        Return dato
    End Function

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                expTablaSimulacion.Export(grdSimulacion, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Sub guardarCambiosOrdenamientoYConfiguracion()
        Dim objBU As New Negocios.SimulacionBU
        Me.Cursor = Cursors.WaitCursor
        For Each rowGrd As UltraGridRow In grdOrdenamiento.Rows
            Dim idConf As Int32 = 0
            If Not rowGrd.Cells("Configuracion").Value Is Nothing Then
                If rowGrd.Cells("Configuracion").Value > 0 Then
                    idConf = rowGrd.Cells("Configuracion").Value.ToString()
                Else
                    idConf = 0
                End If
            End If

            objBU.guardarOpcionSimulacion(lblIdUltimaConfiguracion.Text, rowGrd.Cells("OpcSim_OpcionSimuladorID").Value, idConf, rowGrd.Cells("Orden").Value)
        Next

        Me.Cursor = Cursors.Default
        Dim objMsjExito As New Tools.ExitoForm
        objMsjExito.mensaje = "Registro exitoso"
        objMsjExito.ShowDialog()
    End Sub

    Public Sub ejecutarOrdenamiento()
        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.SimulacionBU
        Dim tam As Int32 = 0

        objBU.truncarTablaTemporalSimulacion()

        For Each rowGrd As UltraGridRow In grdOrdenamiento.Rows
            If rowGrd.Cells("Sel").Value = True And rowGrd.Cells("OpcSim_OpcionSimuladorID").Value <> 1 And rowGrd.Cells("OpcSim_OpcionSimuladorID").Value <> 12 Then
                'objBU.ordenarTablaTemporalSimulacion(rowGrd.Cells("OpcSim_OpcionSimuladorID").Value, lblIdUltimaConfiguracion.Text)
                tam += 1
            End If
        Next

        If tam > 0 Then
            tam = tam - 1
        End If

        Dim opciones(tam) As Int32

        Dim index As Int32 = 0

        For Each rowGrd As UltraGridRow In grdOrdenamiento.Rows
            If rowGrd.Cells("Sel").Value = True And rowGrd.Cells("OpcSim_OpcionSimuladorID").Value <> 1 And rowGrd.Cells("OpcSim_OpcionSimuladorID").Value <> 12 Then
                opciones(index) = rowGrd.Cells("OpcSim_OpcionSimuladorID").Value
                index += 1
            End If
        Next

        objBU.construirConsulta(opciones, lblIdUltimaConfiguracion.Text)

        'objBU.ordenarTablaTemporalSimulacion(0, lblIdUltimaConfiguracion.Text)
        llenarTabSimulacion()
        Me.Cursor = Cursors.Default
        Dim objMensajeAdv As New Tools.ExitoForm
        objMensajeAdv.mensaje = "Se completó el ordenamiento exitosamente"
        objMensajeAdv.ShowDialog()

    End Sub

    Public Sub cargarFechasRangoTodo()
        Dim objBU As New Negocios.ProgramasBU
        Dim dt As New DataTable
        dt = objBU.consultaRangosFechaTodo
        If dt.Rows.Count > 0 Then
            numInicio.Value = dt.Rows(0).Item(3)
            numFinal.Value = dt.Rows(0).Item(4)
            numAnioInicio.Value = dt.Rows(0).Item(5)
            numAnioFin.Value = dt.Rows(0).Item(6)
        End If
    End Sub

    Public Sub generarSimulacion()
        Dim objBUSim As New Negocios.SimulacionBU
        Dim objBUProg As New Negocios.ProgramasBU
        Dim folio As Int32 = 0
        Dim valorPorcentaje As Int32 = grdSimulacion.Rows.Count
        Dim anioMaximo As Int32 = objBUProg.consultaAnioMaximoCapacidades
        folio = objBUSim.obtenerFolio

        'Me.Cursor = Cursors.WaitCursor

        If grdSimulacion.Rows.Count > 0 Then
            Dim diasProgramados As Int32 = 0
            Dim fechaEntregaOpciones As Date
            Dim contProgress As Int32 = grdSimulacion.Rows.Count
            Dim progressActual As Int32 = 0


            fechaEntregaOpciones = objBUProg.ObtenerOpcionFecha("FECHAENTREGA")
            diasProgramados = objBUProg.ObtenerOpcionValorEntero("DIASPROGRAMA")


            For Each rowDtProgRSim As UltraGridRow In grdSimulacion.Rows

                Dim guardoRenglones As Boolean = False
                Dim semanaPedido As Int32 = 0
                Dim fechaEntregaPedido As Date
                Dim semanaValida As Int32 = 0

                fechaEntregaPedido = CDate(rowDtProgRSim.Cells("tmpSim_FechaPedido").Value.ToString)
                fechaEntregaPedido = DateAdd(DateInterval.Day, -(diasProgramados), fechaEntregaPedido)
                semanaPedido = DatePart(DateInterval.WeekOfYear, fechaEntregaPedido)

                semanaValida = rowDtProgRSim.Cells("tmpSim_ProgSemana").Value.ToString


                If (semanaValida >= numInicio.Value And semanaValida <= numFinal.Value And
                    rowDtProgRSim.Cells("tmpSim_anio").Value.ToString >= numAnioInicio.Value And
                    rowDtProgRSim.Cells("tmpSim_anio").Value.ToString <= numAnioFin.Value) Or
                    (semanaValida <= numFinal.Value And
                     rowDtProgRSim.Cells("tmpSim_anio").Value.ToString >= numAnioInicio.Value And
                     rowDtProgRSim.Cells("tmpSim_anio").Value.ToString <= numAnioFin.Value) Or
                    (semanaValida >= numFinal.Value And
                     rowDtProgRSim.Cells("tmpSim_anio").Value.ToString <= numAnioFin.Value) Then

                    Dim semanasMaximoRecorrerAtras As Int32 = 0
                    Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)

                    If semanaPedido = 53 Then
                        If DatePart(DateInterval.Month, fechaEntregaPedido) = 12 Then
                            semanaPedido = 52
                        ElseIf DatePart(DateInterval.Month, fechaEntregaPedido) = 1 Then
                            semanaPedido = 1
                        End If
                    End If

                    If semanaActual = 53 Then
                        If DatePart(DateInterval.Month, semanaActual) = 12 Then
                            semanaActual = 52
                        ElseIf DatePart(DateInterval.Month, semanaActual) = 1 Then
                            semanaActual = 1
                        End If
                    End If

                    If DatePart(DateInterval.Weekday, Date.Now) < 4 Then
                        semanasMaximoRecorrerAtras = semanaPedido - (semanaActual + 1)
                    Else
                        semanasMaximoRecorrerAtras = semanaPedido - (semanaActual + 2)
                    End If


                    If DatePart(DateInterval.WeekOfYear, CDate(rowDtProgRSim.Cells("tmpSim_FechaPedido").Value.ToString)) >= DatePart(DateInterval.WeekOfYear, fechaEntregaOpciones) Or
                        DatePart(DateInterval.Year, CDate(rowDtProgRSim.Cells("tmpSim_FechaPedido").Value.ToString)) >= DatePart(DateInterval.Year, fechaEntregaOpciones) Then

                        Dim semanaInicio As Int32 = 0, semanaFin As Int32 = 0
                        semanaInicio = numInicio.Value
                        semanaFin = numFinal.Value

                        If semanaPedido >= semanaInicio Then
                            guardoRenglones = importacionPedidosCodEstructura(folio, fechaEntregaPedido, semanaPedido, DatePart(DateInterval.Year, fechaEntregaPedido), semanaInicio, semanaFin,
                                                           rowDtProgRSim.Cells("tmpSim_productoID").Value.ToString, rowDtProgRSim.Cells("tmpSim_productoEstiloID").Value.ToString,
                                                           rowDtProgRSim.Cells("tmpSim_IdPedido").Value.ToString, rowDtProgRSim.Cells("tmpSim_IdRenglon").Value.ToString,
                                                           rowDtProgRSim.Cells("tmpSim_idLote").Value.ToString, rowDtProgRSim.Cells("tmpSim_tallaID").Value.ToString,
                                                           rowDtProgRSim.Cells("tmpSim_idCadena").Value.ToString, (rowDtProgRSim.Cells("tmpSim_Cantidad").Value - rowDtProgRSim.Cells("Programado").Value),
                                                           rowDtProgRSim.Cells("Programado").Value, rowDtProgRSim.Cells("tmpSim_idCliente").Value.ToString,
                                                           rowDtProgRSim.Cells("tmpSim_hormaid").Value.ToString, rowDtProgRSim.Cells("tmpSim_tipo").Value.ToString,
                                                           grdSimulacion.Rows.IndexOf(rowDtProgRSim), rowDtProgRSim.Cells("tmpSim_FechaPedido").Value.ToString,
                                                           lblIdUltimaConfiguracion.Text, rowDtProgRSim.Cells("tmpSim_fechaCliente").Value.ToString, rowDtProgRSim.Cells("idGrupo").Value.ToString)

                        End If
                        If guardoRenglones = False Then
                            Dim semanaPedidoResta As Int32 = semanaPedido
                            Dim guardoOtraSemanaAtras As Boolean = False
                            For i As Int32 = 0 To semanasMaximoRecorrerAtras - 1

                                semanaPedidoResta -= 1
                                If guardoOtraSemanaAtras = False Then
                                    If semanaActual <= semanaPedidoResta Then
                                        guardoOtraSemanaAtras = importacionPedidosCodEstructura(folio, fechaEntregaPedido, semanaPedidoResta, DatePart(DateInterval.Year, fechaEntregaPedido), semanaInicio, semanaFin,
                                                            rowDtProgRSim.Cells("tmpSim_productoID").Value.ToString, rowDtProgRSim.Cells("tmpSim_productoEstiloID").Value.ToString,
                                                            rowDtProgRSim.Cells("tmpSim_IdPedido").Value.ToString, rowDtProgRSim.Cells("tmpSim_IdRenglon").Value.ToString,
                                                            rowDtProgRSim.Cells("tmpSim_idLote").Value.ToString, rowDtProgRSim.Cells("tmpSim_tallaID").Value.ToString,
                                                            rowDtProgRSim.Cells("tmpSim_idCadena").Value.ToString, (rowDtProgRSim.Cells("tmpSim_Cantidad").Value - rowDtProgRSim.Cells("Programado").Value),
                                                            rowDtProgRSim.Cells("Programado").Value, rowDtProgRSim.Cells("tmpSim_idCliente").Value.ToString,
                                                            rowDtProgRSim.Cells("tmpSim_hormaid").Value.ToString, rowDtProgRSim.Cells("tmpSim_tipo").Value.ToString,
                                                            grdSimulacion.Rows.IndexOf(rowDtProgRSim), rowDtProgRSim.Cells("tmpSim_FechaPedido").Value.ToString, lblIdUltimaConfiguracion.Text,
                                                            rowDtProgRSim.Cells("tmpSim_fechaCliente").Value.ToString, rowDtProgRSim.Cells("idGrupo").Value.ToString)
                                    Else
                                        Exit For
                                    End If
                                Else
                                    Exit For
                                End If

                            Next

                            If guardoOtraSemanaAtras = False Then

                                Dim semanaPedidoAumenta As Int32 = semanaPedido
                                ' ''If semanaPedido < semanaActual Then
                                ' ''    semanaPedidoAumenta = semanaActual
                                ' ''End If
                                Dim guardoOtraSemanaAdelante As Boolean = False

                                Dim anioRecorrer As Int32 = DatePart(DateInterval.Year, fechaEntregaPedido)
                                If anioRecorrer = Date.Now.Year Then
                                    If DatePart(DateInterval.Weekday, Date.Now) < 4 Then
                                        semanaPedidoAumenta = (semanaActual + 1)
                                    Else
                                        semanaPedidoAumenta = (semanaActual + 2)
                                    End If
                                End If

                                Do While guardoOtraSemanaAdelante = False

                                    If guardoOtraSemanaAdelante = False Then
                                        If semanaPedidoAumenta < 53 Then
                                            guardoOtraSemanaAdelante = importacionPedidosCodEstructura(folio, fechaEntregaPedido, semanaPedidoAumenta, anioRecorrer, semanaInicio, semanaFin,
                                                                rowDtProgRSim.Cells("tmpSim_productoID").Value.ToString, rowDtProgRSim.Cells("tmpSim_productoEstiloID").Value.ToString,
                                                                rowDtProgRSim.Cells("tmpSim_IdPedido").Value.ToString, rowDtProgRSim.Cells("tmpSim_IdRenglon").Value.ToString,
                                                                rowDtProgRSim.Cells("tmpSim_idLote").Value.ToString, rowDtProgRSim.Cells("tmpSim_tallaID").Value.ToString,
                                                                rowDtProgRSim.Cells("tmpSim_idCadena").Value.ToString, (rowDtProgRSim.Cells("tmpSim_Cantidad").Value - rowDtProgRSim.Cells("Programado").Value),
                                                               rowDtProgRSim.Cells("Programado").Value, rowDtProgRSim.Cells("tmpSim_idCliente").Value.ToString,
                                                                rowDtProgRSim.Cells("tmpSim_hormaid").Value.ToString, rowDtProgRSim.Cells("tmpSim_tipo").Value.ToString,
                                                                grdSimulacion.Rows.IndexOf(rowDtProgRSim), rowDtProgRSim.Cells("tmpSim_FechaPedido").Value.ToString, lblIdUltimaConfiguracion.Text,
                                                                rowDtProgRSim.Cells("tmpSim_fechaCliente").Value.ToString, rowDtProgRSim.Cells("idGrupo").Value.ToString)
                                        End If
                                    End If

                                    semanaPedidoAumenta += 1
                                    'If semanaPedidoAumenta >= 53 And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) + 1 Then
                                    If semanaPedidoAumenta >= 53 And anioRecorrer >= anioMaximo Then
                                        guardoOtraSemanaAdelante = True
                                    ElseIf semanaPedidoAumenta >= 53 And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) Then
                                        If semanaFin <= semanaInicio Then
                                            semanaPedidoAumenta = 1
                                            anioRecorrer += 1
                                            If anioRecorrer > anioMaximo Then
                                                guardoOtraSemanaAdelante = True
                                            End If
                                        Else
                                            guardoOtraSemanaAdelante = True
                                        End If
                                    ElseIf semanaPedidoAumenta > semanaFin And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) + 1 Then
                                        guardoOtraSemanaAdelante = True
                                    ElseIf anioRecorrer > anioMaximo Then
                                        guardoOtraSemanaAdelante = True
                                    End If
                                Loop

                                If rowDtProgRSim.Cells("Programado").Value <= 0 And rowDtProgRSim.Cells("Bitacora").Value.ToString.Trim = "" Then
                                    rowDtProgRSim.Cells("Bitacora").Value = "NO PROGRAMADO"
                                End If

                            Else
                                If rowDtProgRSim.Cells("Programado").Value <= 0 And rowDtProgRSim.Cells("Bitacora").Value.ToString.Trim = "" Then
                                    rowDtProgRSim.Cells("Bitacora").Value = "NO PROGRAMADO"
                                End If
                            End If
                        Else
                            If rowDtProgRSim.Cells("Programado").Value <= 0 And rowDtProgRSim.Cells("Bitacora").Value.ToString.Trim = "" Then
                                rowDtProgRSim.Cells("Bitacora").Value = "NO PROGRAMADO"
                            End If
                        End If
                    Else
                        rowDtProgRSim.Cells("Bitacora").Value = "FECHA RETRASO NO SE SIMULA"
                    End If

                    If rowDtProgRSim.Cells("Programado").Value <= 0 And rowDtProgRSim.Cells("Bitacora").Value.ToString.Trim = "" Then
                        rowDtProgRSim.Cells("Bitacora").Value = "NO PROGRAMADO"
                    End If

                    'progressActual += 1
                    'progressActualGlobal = progressActual
                    'porcentaje = (progressActual / valorPorcentaje) * 100

                    'hiloSUBProceso.Send(AddressOf actualizarProgress, Nothing)
                Else

                    If rowDtProgRSim.Cells("Programado").Value <= 0 And rowDtProgRSim.Cells("Bitacora").Value.ToString.Trim = "" Then
                        rowDtProgRSim.Cells("Bitacora").Value = "NO PROGRAMADO"
                    End If

                    'hiloSUBProceso.Send(AddressOf actualizarProgressNoGuardo, Nothing)
                End If
                Threading.Thread.Sleep(50)
            Next



            objBUSim.moverDatosTablaHist(lblIdUltimaConfiguracion.Text)


            objBUSim.editarEstatusSimulacionActual(False)

            'hiloSUBProceso.Send(AddressOf procesoTerminado, Nothing)
        Else
            'hiloSUBProceso.Send(AddressOf procesoTerminado, Nothing)
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            objMensajeAdv.mensaje = "No existen datos para realizar simulación"
            objMensajeAdv.ShowDialog()
        End If
        'hiloProceso.Ab+ort()
        Me.Cursor = Cursors.Default
    End Sub

    'Public Sub actualizarProgress()
    '    If hiloProceso.IsAlive = True Then
    '        prgProgresoSimulacion.Value = progressActualGlobal
    '        lblPorcentaje.Text = porcentaje.ToString + " %"
    '        grdSimulacion.Rows(filaGrid).Activated = True
    '        grdSimulacion.Rows(filaGrid).Cells("PrSt").Appearance.BackColor = Color.LimeGreen
    '    End If
    'End Sub

    'Public Sub actualizarProgressNoGuardo()
    '    If hiloProceso.IsAlive = True Then
    '        prgProgresoSimulacion.Value = progressActualGlobal
    '        lblPorcentaje.Text = porcentaje.ToString + " %"
    '        grdSimulacion.Rows(filaGrid).Activated = True
    '        grdSimulacion.Rows(filaGrid).Cells("PrSt").Appearance.BackColor = Color.Red
    '    End If
    'End Sub

    'Public Sub procesoTerminado()
    '    If hiloProceso.IsAlive = True Then
    '        Dim horaActual As DateTime = DateTime.Now
    '        lblTiempoFinalizo.Text = horaActual.ToShortTimeString
    '        pnlProgress.Visible = False
    '    End If
    'End Sub

    Public Function importacionPedidosCodEstructura(ByVal folioNuevo As Int32,
                                               ByVal fechaEntregaPedido As Date,
                                               ByVal semanaPedido As Int32,
                                               ByVal anio As Int32,
                                               ByVal semanaInicio As Int32,
                                               ByVal semanaFin As Int32,
                                               ByVal idProducto As Int32,
                                               ByVal idPStilo As Int32,
                                               ByVal idPedido As Int32,
                                               ByVal idPartida As Int32,
                                               ByVal idLote As String,
                                               ByVal idTalla As Int32,
                                               ByVal idCadena As String,
                                               ByVal cantidad As Int32,
                                               ByVal programado As Int32,
                                               ByVal idCliente As String,
                                               ByVal idHorma As Int32,
                                               ByVal tipo As String,
                                              ByVal filaIndex As Int32,
                                              ByVal FechaEntregaPedidoTabla As String,
                                              ByVal idSimulacionMaestro As Int32,
                                              ByVal entregaCliente As String,
                                              ByVal idGrupo As Integer) As Boolean


        Dim objBUProg As New Negocios.ProgramasBU
        Dim objBUSim As New Negocios.SimulacionBU
        Dim dtCapacidadArticulo As New DataTable
        Dim guardoProgramaRenglonSemanaPedido As Boolean = False
        Dim insertoCapacidadCompleta As Boolean = False
        Dim cambioArticulo As Boolean = chkCambioArticulo.Checked

        Dim dtRowsCelulasSeleccionadas As DataRow()

        For Each colCels As DataColumn In dtCapacidadesArticuloGlobal.Columns
            dtCapacidadArticulo.Columns.Add(colCels.ColumnName)
        Next

        'dtCapacidadArticulo = objBUSim.consultaExistenciaCapacidadArticuloAnioSimulacion(anio, semanaPedido, idProducto, idPStilo,
        '                                                                                 idTalla, idSimulacionMaestro, cambioArticulo)

        dtRowsCelulasSeleccionadas = dtCapacidadesArticuloGlobal.Select("proc_año = " + anio.ToString + " AND proc_prodID = " + idProducto.ToString +
                                                                       " AND proc_productoEstiloId = " + idPStilo.ToString + " AND proc_tallaID = " + idTalla.ToString)


        For Each filaCelulas As DataRow In dtRowsCelulasSeleccionadas
            Dim filaNueva As DataRow = dtCapacidadArticulo.NewRow
            filaNueva.Item("Tipo") = filaCelulas.Item("Tipo")
            filaNueva.Item("proc_linpID") = filaCelulas.Item("proc_linpID")
            filaNueva.Item("linp_idNave") = filaCelulas.Item("linp_idNave")
            filaNueva.Item("Nave") = filaCelulas.Item("Nave")
            For i As Int32 = 1 To 52
                filaNueva.Item("Semana_" + i.ToString) = filaCelulas.Item("Semana_" + i.ToString)
            Next
            filaNueva.Item("prna_orden") = filaCelulas.Item("prna_orden")
            filaNueva.Item("prna_muestras") = filaCelulas.Item("prna_muestras")
            filaNueva.Item("proc_prodID") = filaCelulas.Item("proc_prodID")
            filaNueva.Item("proc_productoEstiloId") = filaCelulas.Item("proc_productoEstiloId")
            filaNueva.Item("proc_tallaID") = filaCelulas.Item("proc_tallaID")
            filaNueva.Item("proc_año") = filaCelulas.Item("proc_año")
            filaNueva.Item("filaId") = filaCelulas.Item("filaId")

            If chkCambioArticulo.Checked = True Then
                filaNueva.Item("smac_tipoAlta") = filaCelulas.Item("smac_tipoAlta")
                filaNueva.Item("lineaOrigen") = filaCelulas.Item("lineaOrigen")
            End If

            dtCapacidadArticulo.Rows.Add(filaNueva)
        Next


        Dim textoSemanaPedido As String = ""
        ' ''If anio = DatePart(DateInterval.Year, fechaEntregaPedido).ToString Then
        ' ''    textoSemanaPedido = semanaPedido.ToString + "_" + DatePart(DateInterval.Year, fechaEntregaPedido).ToString
        ' ''Else

        'textoSemanaPedido = semanaPedido.ToString + "_" + anio.ToString
        textoSemanaPedido = "Semana_" + semanaPedido.ToString


        ' ''End If




        If cambioArticulo = True Then
            For Each dtR As DataRow In dtCapacidadArticulo.Rows
                If dtR.Item("smac_tipoAlta") = 2 Then
                    For Each dtD As DataRow In dtCapacidadArticulo.Rows
                        If dtR.Item("lineaOrigen") = dtD.Item("proc_linpID") Then
                            dtD.Item(textoSemanaPedido.ToString) = dtD.Item(textoSemanaPedido.ToString) - dtR.Item(textoSemanaPedido.ToString)
                            Exit For
                        End If
                    Next
                End If
            Next
        End If

        Dim cadenaBitacora As String = String.Empty

        If dtCapacidadArticulo.Rows.Count > 0 Then
            '' INICIA COMPLETO---------------------------------------------------------- {
            If programado = 0 Then
                For Each rwdtArtCapacidad As DataRow In dtCapacidadArticulo.Rows
                    cadenaBitacora = String.Empty
                    Dim capacidadArticulo As Int32 = 0

                    'If rwdtArtCapacidad.Item(textoSemanaPedido.ToString).ToString <> "" Then
                    If rwdtArtCapacidad.Item(textoSemanaPedido.ToString).ToString <> "" Then

                        capacidadArticulo = rwdtArtCapacidad.Item(textoSemanaPedido.ToString)
                        Dim dtCapacidadHorma As New DataTable

                        'dtCapacidadHorma = objBUSim.consultaCapacidadHormaXArticuloSimulacion(anio, semanaPedido, idPStilo, idTalla, rwdtArtCapacidad.Item("proc_linpID"), idHorma.ToString,
                        '                                                                      idSimulacionMaestro, cambioArticulo)


                        For Each colsHorma As DataColumn In dtCapacidadesHormasGlobal.Columns
                            dtCapacidadHorma.Columns.Add(colsHorma.ColumnName)
                        Next


                        Dim dtRowsHormasSeleccionadas As DataRow()
                        dtRowsHormasSeleccionadas = dtCapacidadesHormasGlobal.Select("horc_año = " + anio.ToString +
                                                                                  " AND horc_tallaId = " + idTalla.ToString +
                                                                                  " AND horc_linpID = " + rwdtArtCapacidad.Item("proc_linpID") +
                                                                                  " AND horc_hormaID = " + idHorma.ToString)
                        For Each rowHorma As DataRow In dtRowsHormasSeleccionadas
                            Dim filaHorma As DataRow = dtCapacidadHorma.NewRow
                            filaHorma.Item("filaId") = rowHorma.Item("filaId")
                            filaHorma.Item("horc_tallaId") = rowHorma.Item("horc_tallaId")
                            filaHorma.Item("horc_hormaID") = rowHorma.Item("horc_hormaID")
                            filaHorma.Item("horc_linpID") = rowHorma.Item("horc_linpID")
                            filaHorma.Item("horc_año") = rowHorma.Item("horc_año")
                            For i As Int32 = 1 To 52
                                filaHorma.Item("horc_Semana_" + i.ToString) = rowHorma.Item("horc_Semana_" + i.ToString)
                            Next
                            dtCapacidadHorma.Rows.Add(filaHorma)
                        Next

                        If dtCapacidadHorma.Rows.Count > 0 Then
                            If dtCapacidadHorma.Rows(0).Item("horc_" + textoSemanaPedido).ToString > 0 Then
                                'If dtCapacidadHorma.Rows(0).Item("horc_" + semanaPedido.ToString + "_" + anio.ToString).ToString > 0 Then


                                Dim dtCapacidadGrupo As New DataTable

                                'dtCapacidadGrupo = objBUSim.consultaCapacidadLineaProduccionGruposXArticuloSimulacion(anio,
                                '                                                                                      semanaPedido, idPStilo, idTalla, rwdtArtCapacidad.Item("proc_linpID"), idGrupo, idSimulacionMaestro)

                                For Each dtColGrupo As DataColumn In dtCapacidadesGrupoGlobal.Columns
                                    dtCapacidadGrupo.Columns.Add(dtColGrupo.ColumnName)
                                Next


                                Dim dtRowsGrupoSeleccionados As DataRow()
                                dtRowsGrupoSeleccionados = dtCapacidadesGrupoGlobal.Select("gcap_año = " + anio.ToString +
                                                                                           " AND linp_linpID = " + rwdtArtCapacidad.Item("proc_linpID") +
                                                                                           " AND gcap_grupoID = " + idGrupo.ToString)
                                ',
                                ', , , , ,
                                'prod_descripcion
                                For Each rowGrupo As DataRow In dtRowsGrupoSeleccionados
                                    Dim filaGrupo As DataRow = dtCapacidadGrupo.NewRow
                                    filaGrupo.Item("filaId") = rowGrupo.Item("filaId")
                                    filaGrupo.Item("gcap_grupoID") = rowGrupo.Item("gcap_grupoID")
                                    filaGrupo.Item("linp_linpID") = rowGrupo.Item("linp_linpID")
                                    filaGrupo.Item("gcap_año") = rowGrupo.Item("gcap_año")
                                    For i As Int32 = 1 To 52
                                        filaGrupo.Item("gcap_Semana_" + i.ToString) = rowGrupo.Item("gcap_Semana_" + i.ToString)
                                    Next
                                    dtCapacidadGrupo.Rows.Add(filaGrupo)
                                Next

                                If dtCapacidadGrupo.Rows.Count > 0 Then
                                    If dtCapacidadGrupo.Rows(0).Item("gcap_" + textoSemanaPedido).ToString > 0 Then
                                        'If dtCapacidadGrupo.Rows(0).Item("gcap_" + semanaPedido.ToString + "_" + anio.ToString).ToString > 0 Then


                                        Dim dtCapacidadCelula As New DataTable

                                        'dtCapacidadCelula = objBUSim.consultaCapacidadLineaProduccionCelulaXArticuloSimulacion(anio,
                                        'semanaPedido, rwdtArtCapacidad.Item("proc_linpID"), idSimulacionMaestro, chkLimiteCapacidad.Checked)

                                        For Each dtColLinea As DataColumn In dtCapacidadesLineaProduccionGlobal.Columns
                                            dtCapacidadCelula.Columns.Add(dtColLinea.ColumnName)
                                        Next


                                        Dim dtRowsLineasSeleccionadas As DataRow()
                                        dtRowsLineasSeleccionadas = dtCapacidadesLineaProduccionGlobal.Select("lcap_año = " + anio.ToString +
                                                                                                              " AND lcap_linpID = " + rwdtArtCapacidad.Item("proc_linpID"))

                                        For Each rowLinea As DataRow In dtRowsLineasSeleccionadas
                                            Dim filaLinea As DataRow = dtCapacidadCelula.NewRow
                                            filaLinea.Item("filaId") = rowLinea.Item("filaId")
                                            filaLinea.Item("lcap_año") = rowLinea.Item("lcap_año")
                                            For i As Int32 = 1 To 52
                                                filaLinea.Item("lcap_Semana_" + i.ToString) = rowLinea.Item("lcap_Semana_" + i.ToString)
                                            Next
                                            filaLinea.Item("lcap_linpID") = rowLinea.Item("lcap_linpID")
                                            dtCapacidadCelula.Rows.Add(filaLinea)
                                        Next


                                        If dtCapacidadCelula.Rows.Count > 0 Then
                                            If dtCapacidadCelula.Rows(0).Item("lcap_" + textoSemanaPedido.ToString).ToString <> String.Empty Then
                                                'If dtCapacidadCelula.Rows(0).Item("lcap_" + semanaPedido.ToString + "_" + anio.ToString).ToString <> String.Empty Then

                                                If dtCapacidadCelula.Rows(0).Item("lcap_" + textoSemanaPedido.ToString) > 0 Then
                                                    'If dtCapacidadCelula.Rows(0).Item("lcap_" + semanaPedido.ToString + "_" + anio.ToString) > 0 Then
                                                    If rwdtArtCapacidad.Item(textoSemanaPedido.ToString).ToString <> "" Then
                                                        If capacidadArticulo > 0 Then
                                                            If capacidadArticulo >= cantidad Then

                                                                objBUSim.guardarRenglonSimulacion(0, rwdtArtCapacidad.Item("linp_idNave"), rwdtArtCapacidad.Item("proc_linpID"),
                                                                                                     idProducto, idPStilo, idTalla, idPedido, idPartida, idLote, 0,
                                                                                                     anio, semanaPedido, idCadena, FechaEntregaPedidoTabla, cantidad,
                                                                                                     idCliente, idHorma.ToString, idSimulacionMaestro, entregaCliente)
                                                                grdSimulacion.Rows(filaIndex).Cells("Programado").Value = cantidad

                                                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "COLOCADO SEMANA: " + semanaPedido.ToString + "   -- AÑO:" + anio.ToString + "   -- ID NAVE: " + rwdtArtCapacidad.Item("linp_idNave").ToString
                                                                cadenaBitacora = "COLOCADO SEMANA: " + semanaPedido.ToString + "   -- AÑO:" + anio.ToString + "   -- ID NAVE: " + rwdtArtCapacidad.Item("linp_idNave").ToString

                                                                filaGrid = filaIndex

                                                                programado = cantidad

                                                                For Each rowProdEstiloCap As DataRow In dtCapacidadesArticuloGlobal.Select("proc_linpID = " + rwdtArtCapacidad.Item("proc_linpID").ToString + " AND proc_productoEstiloId = " + idPStilo.ToString + " AND proc_año = " + anio.ToString)
                                                                    'dtCapacidadesArticuloGlobal.Rows(CInt(rowProdEstiloCap.Item("filaId") - 1)).Item(textoSemanaPedido) = (IIf(rowProdEstiloCap.Item(textoSemanaPedido).ToString.Trim <> String.Empty, rowProdEstiloCap.Item(textoSemanaPedido), 0)) - cantidad
                                                                    rowProdEstiloCap.Item(textoSemanaPedido) = CInt((IIf(rowProdEstiloCap.Item(textoSemanaPedido).ToString.Trim <> String.Empty, rowProdEstiloCap.Item(textoSemanaPedido), 0)) - cantidad)

                                                                Next
                                                                'dtCapacidadesArticuloGlobal.Rows((CInt(rwdtArtCapacidad.Item("filaId").ToString) - 1).ToString).Item(textoSemanaPedido) = CInt(dtCapacidadesArticuloGlobal.Rows((CInt(rwdtArtCapacidad.Item("filaId").ToString) - 1).ToString).Item(textoSemanaPedido)) - cantidad

                                                                For Each rowHormaCap As DataRow In dtCapacidadesHormasGlobal.Select("horc_linpID = " + rwdtArtCapacidad.Item("proc_linpID").ToString + " AND horc_hormaID = " + idHorma.ToString + " AND horc_año = " + anio.ToString)
                                                                    rowHormaCap.Item("horc_" + textoSemanaPedido) = CInt((IIf(rowHormaCap.Item("horc_" + textoSemanaPedido).ToString.Trim <> String.Empty, rowHormaCap.Item("horc_" + textoSemanaPedido), 0)) - cantidad)
                                                                Next
                                                                'dtCapacidadesHormasGlobal.Rows((CInt(dtCapacidadHorma.Rows(0).Item("filaId")).ToString - 1).ToString).Item("horc_" + textoSemanaPedido) = CInt(dtCapacidadesHormasGlobal.Rows((CInt(dtCapacidadHorma.Rows(0).Item("filaId")).ToString - 1).ToString).Item("horc_" + textoSemanaPedido)) - cantidad

                                                                For Each rowGrupoCap As DataRow In dtCapacidadesGrupoGlobal.Select("linp_linpID = " + rwdtArtCapacidad.Item("proc_linpID").ToString + " AND gcap_grupoID = " + idGrupo.ToString + " AND gcap_año = " + anio.ToString)
                                                                    rowGrupoCap.Item("gcap_" + textoSemanaPedido) = CInt((IIf(rowGrupoCap.Item("gcap_" + textoSemanaPedido).ToString.Trim <> String.Empty, rowGrupoCap.Item("gcap_" + textoSemanaPedido), 0)) - cantidad)
                                                                Next
                                                                'dtCapacidadesGrupoGlobal.Rows((CInt(dtCapacidadGrupo.Rows(0).Item("filaId")).ToString - 1).ToString).Item("gcap_" + textoSemanaPedido) = CInt(dtCapacidadesGrupoGlobal.Rows((CInt(dtCapacidadGrupo.Rows(0).Item("filaId")).ToString - 1).ToString).Item("gcap_" + textoSemanaPedido)) - cantidad

                                                                For Each rowLineaCap As DataRow In dtCapacidadesLineaProduccionGlobal.Select("lcap_linpID = " + rwdtArtCapacidad.Item("proc_linpID").ToString)
                                                                    rowLineaCap.Item("lcap_" + textoSemanaPedido) = CInt((IIf(rowLineaCap.Item("lcap_" + textoSemanaPedido).ToString.Trim <> String.Empty, rowLineaCap.Item("lcap_" + textoSemanaPedido), 0)) - cantidad)
                                                                Next

                                                                'dtCapacidadesLineaProduccionGlobal.Rows((CInt(dtCapacidadCelula.Rows(0).Item("filaId")).ToString - 1).ToString).Item("lcap_" + textoSemanaPedido) = CInt(dtCapacidadesLineaProduccionGlobal.Rows((CInt(dtCapacidadCelula.Rows(0).Item("filaId")).ToString - 1).ToString).Item("lcap_" + textoSemanaPedido)) - cantidad

                                                                insertoCapacidadCompleta = True
                                                            Else
                                                                insertoCapacidadCompleta = False
                                                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "SIN CAPACIDAD PARA EL ARTÍCULO EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                                cadenaBitacora = "SIN CAPACIDAD PARA EL ARTÍCULO EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                            End If
                                                        Else
                                                            insertoCapacidadCompleta = False
                                                            'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                            cadenaBitacora = "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                        End If
                                                    Else
                                                        insertoCapacidadCompleta = False
                                                        'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                        cadenaBitacora = "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                    End If
                                                Else
                                                    insertoCapacidadCompleta = False
                                                    'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidad.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                    cadenaBitacora = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidad.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                End If
                                            Else
                                                insertoCapacidadCompleta = False
                                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidad.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                cadenaBitacora = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidad.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                            End If
                                        Else
                                            insertoCapacidadCompleta = False
                                            'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                            cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                        End If
                                    Else
                                        insertoCapacidadCompleta = False
                                        'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                        cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                    End If
                                Else
                                    insertoCapacidadCompleta = False
                                    'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "CAPACIDAD INSUFICIENTE DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                    cadenaBitacora = "CAPACIDAD INSUFICIENTE DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                End If
                            Else
                                insertoCapacidadCompleta = False
                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                            End If
                        Else
                            insertoCapacidadCompleta = False
                            'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                            cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                        End If
                    Else
                        insertoCapacidadCompleta = False
                        'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DEL ARTICULO SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                        cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DEL ARTICULO SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                    End If

                    grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = cadenaBitacora
                    If insertoCapacidadCompleta = True Then
                        Exit For
                    End If
                Next
            End If
            '---------------------------------------------------------------------------} TERMINA COMPLETO
            If insertoCapacidadCompleta = False Then
                '' INICIA PARCIAL ----------------------------------------------------
                For Each rwdtArtCapacidadParcial As DataRow In dtCapacidadArticulo.Rows
                    cadenaBitacora = String.Empty
                    If programado < cantidad And insertoCapacidadCompleta = False Then
                        Dim capacidadArticulo As Int32 = 0
                        If rwdtArtCapacidadParcial.Item(textoSemanaPedido.ToString).ToString <> "" Then


                            capacidadArticulo = rwdtArtCapacidadParcial.Item(textoSemanaPedido.ToString)

                            Dim dtCapacidadHorma As New DataTable

                            'dtCapacidadHorma = objBUSim.consultaCapacidadHormaXArticuloSimulacion(anio, semanaPedido, idPStilo, idTalla,
                            '                                                                      rwdtArtCapacidadParcial.Item("proc_linpID"),
                            '                                                                      idHorma.ToString, idSimulacionMaestro, cambioArticulo)


                            For Each colsHorma As DataColumn In dtCapacidadesHormasGlobal.Columns
                                dtCapacidadHorma.Columns.Add(colsHorma.ColumnName)
                            Next


                            Dim dtRowsHormasSeleccionadas As DataRow()
                            dtRowsHormasSeleccionadas = dtCapacidadesHormasGlobal.Select("horc_año = " + anio.ToString +
                                                                                         " AND horc_tallaid = " + idTalla.ToString +
                                                                                      " AND horc_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID") +
                                                                                      " AND horc_hormaID = " + idHorma.ToString)
                            For Each rowHorma As DataRow In dtRowsHormasSeleccionadas
                                Dim filaForma As DataRow = dtCapacidadHorma.NewRow
                                filaForma.Item("filaId") = rowHorma.Item("filaId")
                                filaForma.Item("horc_tallaId") = rowHorma.Item("horc_tallaId")
                                filaForma.Item("horc_hormaID") = rowHorma.Item("horc_hormaID")
                                filaForma.Item("horc_linpID") = rowHorma.Item("horc_linpID")
                                filaForma.Item("horc_año") = rowHorma.Item("horc_año")
                                For i As Int32 = 1 To 52
                                    filaForma.Item("horc_Semana_" + i.ToString) = rowHorma.Item("horc_Semana_" + i.ToString)
                                Next
                                dtCapacidadHorma.Rows.Add(filaForma)
                            Next

                            If dtCapacidadHorma.Rows.Count > 0 Then
                                If dtCapacidadHorma.Rows(0).Item("horc_" + textoSemanaPedido).ToString > 0 Then
                                    ' If dtCapacidadHorma.Rows(0).Item("horc_" + semanaPedido.ToString + "_" + anio.ToString).ToString > 0 Then

                                    Dim dtCapacidadGrupo As New DataTable

                                    'dtCapacidadGrupo = objBUSim.consultaCapacidadLineaProduccionGruposXArticuloSimulacion(anio, semanaPedido, idPStilo,
                                    '                                                                                      idTalla, rwdtArtCapacidadParcial.Item("proc_linpID"),
                                    '                                                                                      idGrupo, idSimulacionMaestro)

                                    For Each dtColGrupo As DataColumn In dtCapacidadesGrupoGlobal.Columns
                                        dtCapacidadGrupo.Columns.Add(dtColGrupo.ColumnName)
                                    Next


                                    Dim dtRowsGrupoSeleccionados As DataRow()
                                    dtRowsGrupoSeleccionados = dtCapacidadesGrupoGlobal.Select("gcap_año = " + anio.ToString +
                                                                                               " AND linp_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID") +
                                                                                               " AND gcap_grupoID = " + idGrupo.ToString)
                                    ',
                                    ', , , , ,
                                    'prod_descripcion
                                    For Each rowGrupo As DataRow In dtRowsGrupoSeleccionados
                                        Dim filaGrupo As DataRow = dtCapacidadGrupo.NewRow
                                        filaGrupo.Item("filaId") = rowGrupo.Item("filaId")
                                        filaGrupo.Item("gcap_grupoID") = rowGrupo.Item("gcap_grupoID")
                                        filaGrupo.Item("linp_linpID") = rowGrupo.Item("linp_linpID")
                                        filaGrupo.Item("gcap_año") = rowGrupo.Item("gcap_año")
                                        For i As Int32 = 1 To 52
                                            filaGrupo.Item("gcap_Semana_" + i.ToString) = rowGrupo.Item("gcap_Semana_" + i.ToString)
                                        Next
                                        dtCapacidadGrupo.Rows.Add(filaGrupo)
                                    Next

                                    If dtCapacidadGrupo.Rows.Count > 0 Then
                                        If dtCapacidadGrupo.Rows(0).Item("gcap_" + textoSemanaPedido).ToString > 0 Then
                                            'If dtCapacidadGrupo.Rows(0).Item("gcap_" + semanaPedido.ToString + "_" + anio.ToString).ToString > 0 Then

                                            Dim dtCapacidadCelula As New DataTable
                                            'dtCapacidadCelula = objBUSim.consultaCapacidadLineaProduccionCelulaXArticuloSimulacion(anio, semanaPedido,
                                            '                                                                          rwdtArtCapacidadParcial.Item("proc_linpID"),
                                            '                                                                          idSimulacionMaestro, chkLimiteCapacidad.Checked)

                                            For Each dtColLinea As DataColumn In dtCapacidadesLineaProduccionGlobal.Columns
                                                dtCapacidadCelula.Columns.Add(dtColLinea.ColumnName)
                                            Next

                                            Dim dtRowsLineasSeleccionadas As DataRow()
                                            dtRowsLineasSeleccionadas = dtCapacidadesLineaProduccionGlobal.Select("lcap_año = " + anio.ToString +
                                                                                                                  " AND lcap_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID"))

                                            For Each rowLinea As DataRow In dtRowsLineasSeleccionadas
                                                Dim filaLinea As DataRow = dtCapacidadCelula.NewRow
                                                filaLinea.Item("filaId") = rowLinea.Item("filaId")
                                                filaLinea.Item("lcap_año") = rowLinea.Item("lcap_año")

                                                For i As Int32 = 1 To 52
                                                    filaLinea.Item("lcap_Semana_" + i.ToString) = rowLinea.Item("lcap_Semana_" + i.ToString)
                                                Next
                                                filaLinea.Item("lcap_linpID") = rowLinea.Item("lcap_linpID")
                                                dtCapacidadCelula.Rows.Add(filaLinea)
                                            Next

                                            If dtCapacidadCelula.Rows.Count > 0 Then
                                                If dtCapacidadCelula.Rows(0).Item("lcap_" + textoSemanaPedido.ToString).ToString <> String.Empty Then
                                                    'If dtCapacidadCelula.Rows(0).Item("lcap_" + semanaPedido.ToString + "_" + anio.ToString).ToString <> String.Empty Then

                                                    If dtCapacidadCelula.Rows(0).Item("lcap_" + textoSemanaPedido.ToString) > 0 Then
                                                        'If dtCapacidadCelula.Rows(0).Item("lcap_" + semanaPedido.ToString + "_" + anio.ToString) > 0 Then

                                                        Dim programadoActual As Int32 = programado
                                                        Dim cantidadProgramar As Int32 = cantidad - programadoActual
                                                        Dim programadoRestante As Int32 = 0
                                                        Dim cantidadParcial As Int32 = 0

                                                        If cantidadProgramar > capacidadArticulo Then
                                                            cantidadParcial = capacidadArticulo
                                                        Else
                                                            cantidadParcial = cantidadProgramar
                                                        End If

                                                        programadoRestante = cantidadProgramar - cantidadParcial

                                                        If rwdtArtCapacidadParcial.Item(textoSemanaPedido.ToString).ToString <> "" Then
                                                            If capacidadArticulo > 0 Then
                                                                If capacidadArticulo >= cantidadParcial Then

                                                                    objBUSim.guardarRenglonSimulacion(0,
                                                                                                      rwdtArtCapacidadParcial.Item("linp_idNave"),
                                                                                                      rwdtArtCapacidadParcial.Item("proc_linpID"),
                                                                                                      idProducto, idPStilo, idTalla, idPedido,
                                                                                                      idPartida, idLote, 0, anio, semanaPedido,
                                                                                                      idCadena, FechaEntregaPedidoTabla, cantidadParcial,
                                                                                                      idCliente, idHorma.ToString, idSimulacionMaestro, entregaCliente)

                                                                    grdSimulacion.Rows(filaIndex).Cells("Programado").Value += cantidadParcial
                                                                    'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "COLOCADO SEMANA: " + semanaPedido.ToString + "   -- AÑO:" + anio.ToString + "   -- ID NAVE: " + rwdtArtCapacidadParcial.Item("linp_idNave").ToString
                                                                    cadenaBitacora = "COLOCADO SEMANA: " + semanaPedido.ToString + "   -- AÑO:" + anio.ToString + "   -- ID NAVE: " + rwdtArtCapacidadParcial.Item("linp_idNave").ToString
                                                                    filaGrid = filaIndex
                                                                    programado += cantidadParcial


                                                                    For Each rowProdEstiloCap As DataRow In dtCapacidadesArticuloGlobal.Select("proc_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " AND proc_productoEstiloId = " + idPStilo.ToString + " AND proc_año = " + anio.ToString)
                                                                        'dtCapacidadesArticuloGlobal.Rows(CInt(rowProdEstiloCap.Item("filaId") - 1)).Item(textoSemanaPedido) = (IIf(rowProdEstiloCap.Item(textoSemanaPedido).ToString.Trim <> String.Empty, rowProdEstiloCap.Item(textoSemanaPedido), 0)) - cantidad
                                                                        rowProdEstiloCap.Item(textoSemanaPedido) = CInt((IIf(rowProdEstiloCap.Item(textoSemanaPedido).ToString.Trim <> String.Empty, rowProdEstiloCap.Item(textoSemanaPedido), 0)) - cantidadParcial)
                                                                    Next
                                                                    'dtCapacidadesArticuloGlobal.Rows((CInt(rwdtArtCapacidad.Item("filaId").ToString) - 1).ToString).Item(textoSemanaPedido) = CInt(dtCapacidadesArticuloGlobal.Rows((CInt(rwdtArtCapacidad.Item("filaId").ToString) - 1).ToString).Item(textoSemanaPedido)) - cantidad

                                                                    For Each rowHormaCap As DataRow In dtCapacidadesHormasGlobal.Select("horc_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " AND horc_hormaID = " + idHorma.ToString + " AND horc_año = " + anio.ToString)
                                                                        rowHormaCap.Item("horc_" + textoSemanaPedido) = CInt((IIf(rowHormaCap.Item("horc_" + textoSemanaPedido).ToString.Trim <> String.Empty, rowHormaCap.Item("horc_" + textoSemanaPedido), 0)) - cantidadParcial)
                                                                    Next
                                                                    'dtCapacidadesHormasGlobal.Rows((CInt(dtCapacidadHorma.Rows(0).Item("filaId")).ToString - 1).ToString).Item("horc_" + textoSemanaPedido) = CInt(dtCapacidadesHormasGlobal.Rows((CInt(dtCapacidadHorma.Rows(0).Item("filaId")).ToString - 1).ToString).Item("horc_" + textoSemanaPedido)) - cantidad

                                                                    For Each rowGrupoCap As DataRow In dtCapacidadesGrupoGlobal.Select("linp_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " AND gcap_grupoID = " + idGrupo.ToString + " AND gcap_año = " + anio.ToString)
                                                                        rowGrupoCap.Item("gcap_" + textoSemanaPedido) = CInt((IIf(rowGrupoCap.Item("gcap_" + textoSemanaPedido).ToString.Trim <> String.Empty, rowGrupoCap.Item("gcap_" + textoSemanaPedido), 0)) - cantidadParcial)
                                                                    Next
                                                                    'dtCapacidadesGrupoGlobal.Rows((CInt(dtCapacidadGrupo.Rows(0).Item("filaId")).ToString - 1).ToString).Item("gcap_" + textoSemanaPedido) = CInt(dtCapacidadesGrupoGlobal.Rows((CInt(dtCapacidadGrupo.Rows(0).Item("filaId")).ToString - 1).ToString).Item("gcap_" + textoSemanaPedido)) - cantidad

                                                                    For Each rowLineaCap As DataRow In dtCapacidadesLineaProduccionGlobal.Select("lcap_linpID = " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString)
                                                                        rowLineaCap.Item("lcap_" + textoSemanaPedido) = CInt((IIf(rowLineaCap.Item("lcap_" + textoSemanaPedido).ToString.Trim <> String.Empty, rowLineaCap.Item("lcap_" + textoSemanaPedido), 0)) - cantidadParcial)
                                                                    Next
                                                                    'dtCapacidadesLineaProduccionGlobal.Rows((CInt(dtCapacidadCelula.Rows(0).Item("filaId")).ToString - 1).ToString).Item("lcap_" + textoSemanaPedido) = CInt(dtCapacidadesLineaProduccionGlobal.Rows((CInt(dtCapacidadCelula.Rows(0).Item("filaId")).ToString - 1).ToString).Item("lcap_" + textoSemanaPedido)) - cantidadParcial
                                                                Else
                                                                    'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "SIN CAPACIDAD PARA EL ARTÍCULO EN LA SEMANA PARCIAL DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                                    cadenaBitacora = "SIN CAPACIDAD PARA EL ARTÍCULO EN LA SEMANA PARCIAL DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                                End If
                                                            Else
                                                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "SIN CAPACIDAD PARA EL ARTÍCULO EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                                cadenaBitacora = "SIN CAPACIDAD PARA EL ARTÍCULO EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                            End If
                                                        Else
                                                            'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                            cadenaBitacora = "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                        End If
                                                    Else
                                                        'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                        cadenaBitacora = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                    End If
                                                Else
                                                    'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                    cadenaBitacora = "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                End If
                                            Else
                                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                                cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                            End If
                                        Else
                                            'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                            cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                        End If
                                    Else
                                        'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                        cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                    End If
                                Else
                                    'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                    cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                End If
                            Else
                                'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                                cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                            End If
                        Else
                            'grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DEL ARTICULO SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                            cadenaBitacora = "INFORMACIÓN DE CAPACIDAD INCOMPLETA DEL ARTICULO SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
                        End If
                        grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = cadenaBitacora
                    Else
                        Exit For
                    End If
                Next
            End If
            '---------------------------------------------------------------------------} TERMINA PARCIAL
            If programado = cantidad Then
                guardoProgramaRenglonSemanaPedido = True
            Else
                guardoProgramaRenglonSemanaPedido = False
            End If
        Else
            insertoCapacidadCompleta = False
            guardoProgramaRenglonSemanaPedido = False
            grdSimulacion.Rows(filaIndex).Cells("Bitacora").Value = "INFORMACIÓN DE CAPACIDAD INCOMPLETA EN SEMANA: " + semanaPedido.ToString + " AÑO: " + anio.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")"
        End If

        Return guardoProgramaRenglonSemanaPedido

    End Function

    Public Sub llenarTabSimulacionNoSimularTodo()
        grdSimulacion.DataSource = Nothing
        Dim objBUSim As New Negocios.SimulacionBU
        Dim dtTmpProgRenglonResumen As New DataTable
        dtTmpProgRenglonResumen = objBUSim.consultaSimulacionTemporalNOProgramados
        If dtTmpProgRenglonResumen.Rows.Count > 0 Then
            grdSimulacion.DataSource = dtTmpProgRenglonResumen
            disenioGridSimulacion()
        End If
    End Sub

    Public Sub llenarTabSimulacion()
        grdSimulacion.DataSource = Nothing
        Dim objBUSim As New Negocios.SimulacionBU
        Dim dtTmpProgRenglonResumen As New DataTable
        dtTmpProgRenglonResumen = objBUSim.consultaSimulacionTemporal
        If dtTmpProgRenglonResumen.Rows.Count > 0 Then
            grdSimulacion.DataSource = dtTmpProgRenglonResumen
            disenioGridSimulacion()
        End If
    End Sub

    Public Sub disenioGridSimulacion()
        Dim band As UltraGridBand = Me.grdSimulacion.DisplayLayout.Bands(0)
        With band
            .Columns("PrSt").Header.Caption = ""
            .Columns("Programado").Header.Caption = "Programado"
            .Columns("tmpSim_programaID").Hidden = True
            .Columns("tmpSim_ProgSemana").Hidden = True
            .Columns("tmpSim_FechaPedido").Header.Caption = "Fecha Ped."
            .Columns("tmpSim_SimBloqueo").Hidden = True
            .Columns("tmpSim_naveID").Hidden = True
            .Columns("tmpSim_productoID").Hidden = True
            .Columns("tmpSim_productoEstiloID").Hidden = True
            .Columns("tmpSim_tallaID").Hidden = True
            .Columns("idGrupo").Hidden = True
            .Columns("tmpSim_IdPedido").Header.Caption = "Pedido"
            .Columns("tmpSim_IdRenglon").Header.Caption = "Id Partida"
            .Columns("tmpSim_idLote").Header.Caption = "Id Lote"
            .Columns("tmpSim_Cantidad").Header.Caption = "Cantidad"
            .Columns("tmpSim_anio").Header.Caption = "Año"
            .Columns("tmpSim_tipo").Hidden = True
            .Columns("tmpSim_idCadena").Hidden = True
            .Columns("tmpSim_cerrado").Hidden = True
            .Columns("tmpSim_idCliente").Hidden = True
            .Columns("tmpSim_hormaid").Hidden = True
            .Columns("prod_codigo").Header.Caption = "Prod. SAY"
            .Columns("modeloSICY").Header.Caption = "Prod. SICY"
            .Columns("Modelo").Header.Caption = "Modelo"
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("tmpSim_fechaCliente").Header.Caption = "F. Entrega Cliente"

            .Columns("tmpSim_IdPedido").CellAppearance.TextHAlign = HAlign.Right
            .Columns("tmpSim_IdRenglon").CellAppearance.TextHAlign = HAlign.Right
            .Columns("tmpSim_idLote").CellAppearance.TextHAlign = HAlign.Right
            .Columns("tmpSim_Cantidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("tmpSim_anio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prod_codigo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("modeloSICY").CellAppearance.TextHAlign = HAlign.Right

            .Columns("tmpSim_FechaPedido").CellActivation = Activation.NoEdit
            .Columns("tmpSim_fechaCliente").CellActivation = Activation.NoEdit

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdSimulacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSimulacion.DisplayLayout.Override.RowSelectorWidth = 35
        grdSimulacion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSimulacion.Rows(0).Selected = True
        grdSimulacion.DisplayLayout.Bands(0).Override.CellClickAction = CellClickAction.RowSelect
        grdSimulacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
    End Sub

    Public Sub llenarDatos()
        Dim objBU As New Negocios.SimulacionBU
        Dim objProgBU As New Negocios.ProgramasBU
        Dim dtOpciones As New DataTable
        Dim dtAnios As New DataTable
        Dim dtDatosUltimaConf As New DataTable


        dtDatosUltimaConf = objBU.consultaDatosUltimaConfiguracion

        dtAnios = objProgBU.consultaRangosFechaTodo

        If dtAnios.Rows.Count > 0 Then
            If dtAnios.Rows(0).Item(0).ToString <> "" And dtAnios.Rows(0).Item(1).ToString <> "" Then
                numAnioInicio.Minimum = dtAnios.Rows(0).Item("eirf_anioinicio")
                numAnioFin.Minimum = dtAnios.Rows(0).Item("eirf_anioinicio")
                numAnioInicio.Maximum = dtAnios.Rows(0).Item("eirf_aniofin")
                numAnioFin.Maximum = dtAnios.Rows(0).Item("eirf_aniofin")
                numInicio.Minimum = dtAnios.Rows(0).Item("eirf_semanainicio")
            End If
        End If

        If dtDatosUltimaConf.Rows.Count > 0 Then
            txtDescripcion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_Descripcion")
            lblIdUltimaConfiguracion.Text = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_ProcSimuladorID")
            dtOpciones = objBU.verOpcionesConfiguradasSimulacion(lblIdUltimaConfiguracion.Text)
            If dtOpciones.Rows.Count > 0 Then
                grdOrdenamiento.DataSource = dtOpciones
                formatoGridOrdenamiento()
            Else
                grdOrdenamiento.DataSource = Nothing
                chkCambioArticulo.Visible = False
                chkLimiteCapacidad.Visible = False
            End If

            If CBool(dtDatosUltimaConf.Rows(0).Item("ProcSimMae_VerTodo")) = False Then
                If dtAnios.Rows(0).Item(0).ToString <> "" And dtAnios.Rows(0).Item(1).ToString <> "" Then
                    If dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoAnioInicio") >= dtAnios.Rows(0).Item(5) And
                        dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoAnioInicio") <= dtAnios.Rows(0).Item(6) Then
                        numAnioInicio.Value = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoAnioInicio")
                    End If
                End If
                If dtAnios.Rows(0).Item(0).ToString <> "" And dtAnios.Rows(0).Item(1).ToString <> "" Then
                    If dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoAnioFin") >= dtAnios.Rows(0).Item(5) And
                      dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoAnioFin") <= dtAnios.Rows(0).Item(6) Then
                        numAnioFin.Value = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoAnioFin")
                    End If
                End If
                If dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoSemanaInicio") >= numInicio.Minimum Then
                    numInicio.Value = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoSemanaInicio")
                End If
                numFinal.Value = dtDatosUltimaConf.Rows(0).Item("ProcSimMae_RangoSemanaFin")
            Else
                chkTodoRangoFechas.Checked = True
            End If

        Else
            lblIdUltimaConfiguracion.Text = "0"
            numInicio.Value = DatePart(DateInterval.WeekOfYear, Date.Now)
            numFinal.Value = 52
        End If

    End Sub

    Public Sub formatoGridOrdenamiento()
        With grdOrdenamiento.DisplayLayout.Bands(0)
            .Columns("OpcSim_OpcionSimuladorID").Hidden = True
            .Columns("OpcSim_Descripcion").Hidden = True
            .Columns("OpcSim_Status").Hidden = True

            .Columns("OpcSim_Nombre").Header.Caption = "Opción"
            .Columns("Sel").Header.Caption = ""
            .Columns("Orden").Header.Caption = ""

            .Columns("OpcSim_Nombre").CellActivation = Activation.NoEdit
            .Columns("Orden").CellActivation = Activation.NoEdit
            .Columns("Orden").Header.Caption = ""

            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            If .Columns.Exists("psmd_OpcionSimConfiguracionId") = True Then
                .Columns("psmd_OpcionSimConfiguracionId").Hidden = True
            End If
            If .Columns.Exists("psmd_SimulacionMaestroId") = True Then
                .Columns("psmd_SimulacionMaestroId").Hidden = True
                .Columns("Sel").CellActivation = Activation.NoEdit
            End If
        End With

        grdOrdenamiento.DisplayLayout.Bands(0).Columns.Add("Configuracion", "Conf.")
        grdOrdenamiento.DisplayLayout.Bands(0).Columns("Configuracion").Style = UltraWinGrid.ColumnStyle.DropDownList

        If grdOrdenamiento.DisplayLayout.Bands(0).Columns.Exists("psmd_SimulacionMaestroId") = True Then
            grdOrdenamiento.DisplayLayout.Bands(0).Columns("Configuracion").CellActivation = Activation.NoEdit
        End If

        Dim objBU As New Negocios.SimulacionBU
        Dim listaConfiguracionOpcion As New ValueList
        Dim dt As New DataTable
        Dim valorSel As Int32 = 0

        For Each rowGrd As UltraGridRow In grdOrdenamiento.Rows
            dt = New DataTable
            dt = objBU.verConfiguracionOpionesSimulacion(rowGrd.Cells("OpcSim_OpcionSimuladorID").Value)
            If dt.Rows.Count Then
                valorSel = 0
                listaConfiguracionOpcion = New ValueList
                listaConfiguracionOpcion.ValueListItems.Add("0", " ")

                For Each rowDt As DataRow In dt.Rows
                    listaConfiguracionOpcion.ValueListItems.Add(rowDt.Item("OpcSimConf_OpcionSimConfigID").ToString, rowDt.Item("OpcSimConf_Nombre").ToString)
                    If rowGrd.Cells.Exists("psmd_OpcionSimConfiguracionId") = True Then
                        If rowGrd.Cells("psmd_OpcionSimConfiguracionId").Value.ToString <> "" Then
                            valorSel = rowGrd.Cells("psmd_OpcionSimConfiguracionId").Value
                        End If
                    End If

                Next

                rowGrd.Cells("Configuracion").ValueList = listaConfiguracionOpcion
                If rowGrd.Cells.Exists("psmd_OpcionSimConfiguracionId") = True Then
                    If valorSel > 0 Then
                        rowGrd.Cells("Configuracion").Value = valorSel
                    End If
                End If
            Else
                rowGrd.Cells("Configuracion").Activation = Activation.NoEdit
                If rowGrd.Cells.Exists("ConfTemp") = True Then
                    rowGrd.Cells("ConfTemp").Activation = Activation.NoEdit
                End If
            End If

        Next

        If grdOrdenamiento.DisplayLayout.Bands(0).Columns.Exists("ConfTemp") = True Then
            Dim colckbCr As UltraGridColumn = grdOrdenamiento.DisplayLayout.Bands(0).Columns("ConfTemp")
            colckbCr.Width = 30
            colckbCr.Header.Caption = ""
            colckbCr.Style = ColumnStyle.Image
        End If

        grdOrdenamiento.DisplayLayout.Bands(0).Columns("Orden").Header.VisiblePosition = grdOrdenamiento.DisplayLayout.Bands(0).Columns.Count - 2
        If grdOrdenamiento.DisplayLayout.Bands(0).Columns.Exists("ConfTemp") = True Then
            grdOrdenamiento.DisplayLayout.Bands(0).Columns("ConfTemp").Header.VisiblePosition = grdOrdenamiento.DisplayLayout.Bands(0).Columns.Count - 1
        End If
        grdOrdenamiento.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenamiento.DisplayLayout.Override.RowSelectorWidth = 35
        grdOrdenamiento.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdOrdenamiento.Rows(0).Selected = True
        grdOrdenamiento.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenamiento.DisplayLayout.Bands(0).Columns("Sel").Width = 25
        grdOrdenamiento.DisplayLayout.Bands(0).Columns("Orden").Width = 25

        If grdOrdenamiento.DisplayLayout.Bands(0).Columns.Exists("psmd_SimulacionMaestroId") = False Then
            grdOrdenamiento.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
            grdOrdenamiento.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            grdOrdenamiento.AllowDrop = True
        Else
            grdOrdenamiento.DisplayLayout.Override.SelectTypeRow = SelectType.None
            grdOrdenamiento.DisplayLayout.Override.AllowAddNew = AllowAddNew.Default
            grdOrdenamiento.AllowDrop = False
        End If
        If grdOrdenamiento.DisplayLayout.Bands(0).Columns.Exists("Configuracion") = True Then
            grdOrdenamiento.DisplayLayout.Bands(0).Columns("Configuracion").Hidden = True
        End If


        Dim mostrarchkCambioArticulo As Boolean = False
        Dim mostrarchkLimiteCapacidad As Boolean = False
        For Each rowGrd As UltraGridRow In grdOrdenamiento.Rows
            If rowGrd.Cells("OpcSim_OpcionSimuladorID").Value = 9 Then
                mostrarchkCambioArticulo = True
            End If
            If rowGrd.Cells("OpcSim_OpcionSimuladorID").Value = 10 Then
                mostrarchkLimiteCapacidad = True
            End If
        Next
        If mostrarchkCambioArticulo = True Then
            chkCambioArticulo.Visible = True
        Else
            chkCambioArticulo.Visible = False
        End If
        If mostrarchkLimiteCapacidad = True Then
            chkLimiteCapacidad.Visible = True
        Else
            chkLimiteCapacidad.Visible = False
        End If


    End Sub

    Public Sub guardarConfiguracion()
        Dim objBU As New Negocios.SimulacionBU
        Dim idNuevaConf As Int32 = 0
        Me.Cursor = Cursors.WaitCursor
        'If lblIdUltimaConfiguracion.Text <> "" Then
        objBU.inactivarConfiguracionAnterior()
        'End If
        objBU.guardarNuevaConfiguracionSimulacion(txtDescripcion.Text, numInicio.Value, numFinal.Value, numAnioInicio.Value, numAnioFin.Value, chkTodoRangoFechas.Checked)
        idNuevaConf = objBU.verIdRegistradoConf
        lblIdUltimaConfiguracion.Text = idNuevaConf.ToString

        objBU.editaConfiguracionesOrden()
        For Each rowGrd As UltraGridRow In grdOrdenamiento.Rows
            If rowGrd.Cells("Orden").Value > 0 Then
                Dim idConf As Int32 = 0

                If Not rowGrd.Cells("Configuracion").Value Is Nothing Then
                    If rowGrd.Cells("Configuracion").Value > 0 Then
                        idConf = rowGrd.Cells("Configuracion").Value.ToString()
                    Else
                        idConf = 0
                    End If
                End If
                objBU.guardarOpcionSimulacion(idNuevaConf, rowGrd.Cells("OpcSim_OpcionSimuladorID").Value, idConf, rowGrd.Cells("Orden").Value)
            End If

        Next
        objBU.cargaInicialCatalogos(idNuevaConf)

        objBU.truncarTablaTemporalSimulacion()

        Me.Cursor = Cursors.Default
        Dim objMsjExito As New Tools.ExitoForm
        objMsjExito.mensaje = "Registro exitoso"
        objMsjExito.ShowDialog()

    End Sub

    Public Function validaDescripcion()
        If txtDescripcion.Text.Trim = "" Then
            Return False
        End If
        Return False
    End Function

    Public Function validaAniosSimulacion()
        If numAnioFin.Value < numAnioInicio.Value Then
            Return False
        End If
        Return False
    End Function

    Public Function validaRangoSemanas() As Boolean
        If numInicio.Value.ToString = "" Then
            Return False
        End If
        If numFinal.Value.ToString = "" Then
            Return False
        End If
        If (numFinal.Value < numInicio.Value) And numAnioFin.Value <= numAnioInicio.Value Then
            Return False
        End If
        Return True
    End Function

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpBotones.Height = 40
        pnlDatos.Visible = False
        pnlRangoFecha.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpBotones.Height = 117
        pnlDatos.Visible = True
        pnlRangoFecha.Visible = True
    End Sub

    Private Sub frmOrdenamientoSimulacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Try
        '    If hiloProceso.IsAlive = True Then
        '        hiloProceso.Abort()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub frmOrdenamientoSimulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        llenarDatos()
        llenarTabSimulacion()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validaDescripcion() = False Then
            If validaAniosSimulacion() = False Then
                Dim objMensaje As New Tools.ConfirmarForm
                objMensaje.mensaje = "¿Esta seguro de guardar la configuración?"
                If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarConfiguracion()
                    chkSeleccionarTodos.Enabled = False
                    chkSeleccionarTodos.Checked = False
                    txtDescripcion.Enabled = False
                    grdOrdenamiento.DataSource = Nothing
                    btnCancelarNueva.Enabled = False
                    btnGuardar.Enabled = False
                    btnNuevaSimulacion.Enabled = True
                    pnlBotones.Enabled = True
                    chkCambioArticulo.Visible = False
                    chkLimiteCapacidad.Visible = False
                    llenarDatos()
                    llenarTabSimulacion()
                End If
            Else
                Dim objAdj As New Tools.AdvertenciaForm
                objAdj.mensaje = "Rango de años incorrecto"
                objAdj.ShowDialog()
            End If
        Else
            Dim objAdj As New Tools.AdvertenciaForm
            objAdj.mensaje = "Falta descripción para la simulación"
            objAdj.ShowDialog()
        End If
    End Sub

    Private Sub grdOrdenamiento_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdOrdenamiento.AfterCellUpdate

    End Sub

    Private Sub grdOrdenamiento_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdOrdenamiento.BeforeCellUpdate

    End Sub

    Private Sub grdOrdenamiento_CellChange(sender As Object, e As CellEventArgs) Handles grdOrdenamiento.CellChange
        If e.Cell.Column.ToString = "SEL" Or e.Cell.Column.ToString = "Sel" Then
            Dim nOrden As Int32 = 1

            For Each fila As UltraGridRow In grdOrdenamiento.Rows
                If e.Cell.Row.Index = fila.Index Then
                    If e.Cell.Text = True Then
                        e.Cell.Row.Cells("Orden").Value = nOrden
                        nOrden += 1
                    Else
                        e.Cell.Row.Cells("Orden").Value = "0"
                    End If
                Else
                    If fila.Cells("Sel").Value = True Then
                        fila.Cells("Orden").Value = nOrden
                        nOrden += 1
                    Else
                        fila.Cells("Orden").Value = "0"
                    End If
                End If
            Next

        End If
    End Sub

    Private Sub grdOrdenamiento_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdOrdenamiento.ClickCell

    End Sub

    Private Sub grdOrdenamiento_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdOrdenamiento.DoubleClickCell
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString = "ConfTemp" Then
                If e.Cell.Row.Cells("OpcSim_OpcionSimuladorID").Value = "2" Then
                    Dim objClntEs As New frmConfClientesEspecialesOrden
                    objClntEs.MdiParent = Me.MdiParent
                    objClntEs.Show()
                    e.Cell.Row.Cells("ConfTemp").Appearance.BackColor = Color.LimeGreen
                ElseIf e.Cell.Row.Cells("OpcSim_OpcionSimuladorID").Value = "4" Then
                    Dim objClntEs As New frmOrdenamientoRankingSimulacion
                    objClntEs.MdiParent = Me.MdiParent
                    objClntEs.Show()
                    e.Cell.Row.Cells("ConfTemp").Appearance.BackColor = Color.LimeGreen
                ElseIf e.Cell.Row.Cells("OpcSim_OpcionSimuladorID").Value = "8" Then
                    Dim objArtPref As New frmArticulosPreferentes
                    objArtPref.MdiParent = Me.MdiParent
                    objArtPref.Show()
                    e.Cell.Row.Cells("ConfTemp").Appearance.BackColor = Color.LimeGreen
                ElseIf e.Cell.Row.Cells("OpcSim_OpcionSimuladorID").Value = "7" Then
                    Dim objArtPref As New frmNavesOrden
                    objArtPref.MdiParent = Me.MdiParent
                    objArtPref.Show()
                    e.Cell.Row.Cells("ConfTemp").Appearance.BackColor = Color.LimeGreen
                ElseIf e.Cell.Row.Cells("OpcSim_OpcionSimuladorID").Value = "10" Then
                    Dim objArtPref As New frmLimiteCapacidad
                    objArtPref.MdiParent = Me.MdiParent
                    objArtPref.Show()
                    e.Cell.Row.Cells("ConfTemp").Appearance.BackColor = Color.LimeGreen
                ElseIf e.Cell.Row.Cells("OpcSim_OpcionSimuladorID").Value = "9" Then
                    Dim objArtPref As New frmMoverHorma
                    objArtPref.MdiParent = Me.MdiParent
                    objArtPref.Show()
                    e.Cell.Row.Cells("ConfTemp").Appearance.BackColor = Color.LimeGreen
                End If
            End If
        End If
    End Sub

    Private Sub grdOrdenamiento_DragDrop(sender As Object, e As DragEventArgs) Handles grdOrdenamiento.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdOrdenamiento.DisplayLayout.UIElement.ElementFromPoint(grdOrdenamiento.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdOrdenamiento.Rows.Move(aRow, dropIndex)
            Next

            Dim nOrden As Int32 = 1
            For Each fila As UltraGridRow In grdOrdenamiento.Rows
                If fila.Cells("Sel").Value = True Then
                    fila.Cells("Orden").Value = nOrden
                    nOrden += 1
                Else
                    fila.Cells("Orden").Value = "0"
                End If
            Next

        End If
    End Sub

    Private Sub grdOrdenamiento_DragOver(sender As Object, e As DragEventArgs) Handles grdOrdenamiento.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdOrdenamiento.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdOrdenamiento.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdOrdenamiento_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOrdenamiento.InitializeLayout

    End Sub

    Private Sub chkTodoRangoFechas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodoRangoFechas.CheckedChanged
        If chkTodoRangoFechas.Checked = True Then
            pnlRango.Enabled = False
            cargarFechasRangoTodo()
        Else
            pnlRango.Enabled = True
        End If
    End Sub

    Private Sub grdOrdenamiento_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdOrdenamiento.InitializeRow
        If e.Row.Cells.Exists("ConfTemp") Then
            e.Row.Cells("ConfTemp").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.seleccionar
        End If
    End Sub

    Private Sub grdOrdenamiento_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdOrdenamiento.SelectionDrag
        grdOrdenamiento.DoDragDrop(grdOrdenamiento.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub btnGuardarSimulacion_Click(sender As Object, e As EventArgs) Handles btnGuardarSimulacion.Click
        If validarEntradaSimulacion() = False Then
            If CInt(lblIdUltimaConfiguracion.Text) > 0 Then
                If validaRangoSemanas() = True Then
                    tbtSimulador.SelectedTab = tbtSimulador.TabPages.Item(1)
                    Dim objMensaje As New Tools.ConfirmarForm
                    objMensaje.mensaje = "Este proceso puede tardar más de lo esperado. Si acepta continuar la información actual de la simulación será remplazada. ¿Está seguro de continuar?"
                    If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then

                        Me.Cursor = Cursors.WaitCursor

                        Dim objBU As New Negocios.SimulacionBU
                        Dim horaActual As DateTime = DateTime.Now
                        lblTiempoFinalizo.Text = "00:00:00"
                        lblPorcentaje.Text = "0 %"
                        prgProgresoSimulacion.Value = 0

                        If chkReacomodarPedidos.Checked = True Then
                            llenarTabSimulacion()

                            Dim contProgress As Int32 = grdSimulacion.Rows.Count

                            prgProgresoSimulacion.Minimum = 0
                            prgProgresoSimulacion.Maximum = contProgress
                            'pnlProgress.Visible = True
                            'lblProceso.Visible = True
                            lblTiempoInicio.Text = horaActual.ToShortTimeString

                            objBU.truncarTablaSimulacionProceso()

                            objBU.editarEstatusSimulacionActual(True)



                            Dim objBuSim As New Negocios.SimulacionBU
                            If grdSimulacion.Rows.Count > 0 Then
                                Me.Cursor = Cursors.WaitCursor
                                dtCapacidadesArticuloGlobal = New DataTable
                                dtCapacidadesArticuloGlobal = objBuSim.consultaExistenciaCapacidadArticuloAnioSimulacion(lblIdUltimaConfiguracion.Text, chkCambioArticulo.Checked)
                                dtCapacidadesHormasGlobal = New DataTable
                                dtCapacidadesHormasGlobal = objBuSim.consultaExistenciaHormasCapacidadSimulacion(lblIdUltimaConfiguracion.Text, chkCambioArticulo.Checked)
                                dtCapacidadesGrupoGlobal = New DataTable
                                dtCapacidadesGrupoGlobal = objBuSim.consultaExistenciaGruposCapacidadSimulacion
                                dtCapacidadesLineaProduccionGlobal = New DataTable
                                dtCapacidadesLineaProduccionGlobal = objBuSim.consultaExistenciaLineaProduccionCapacidadSimulacion(lblIdUltimaConfiguracion.Text, chkLimiteCapacidad.Checked)


                                If chkCambioArticulo.Checked = True Then
                                    For Each rowArtG As DataRow In dtCapacidadesArticuloGlobal.Select("smac_tipoAlta = 2")
                                        For filaArtGlobal As Int32 = dtCapacidadesArticuloGlobal.Rows.Count - 1 To 0 Step -1
                                            If dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_linpID").ToString = rowArtG.Item("lineaOrigen").ToString And
                                                dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_productoEstiloId").ToString = rowArtG.Item("proc_productoEstiloId").ToString And
                                                dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_tallaID").ToString = rowArtG.Item("proc_tallaID").ToString And
                                                dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_año").ToString = rowArtG.Item("proc_año").ToString Then
                                                dtCapacidadesArticuloGlobal.Rows.Remove(dtCapacidadesArticuloGlobal.Rows(filaArtGlobal))

                                            End If
                                        Next
                                    Next
                                End If

                                generarSimulacion()
                                lblTiempoFinalizo.Text = DateTime.Now.ToShortTimeString
                                Me.Cursor = Cursors.Default

                                Dim objMsjExito As New Tools.ExitoForm
                                objMsjExito.mensaje = "Simulación terminada."
                                objMsjExito.ShowDialog()

                                'hiloProceso = New Threading.Thread(AddressOf generarSimulacion)
                                'If hiloProceso.ThreadState <> Threading.ThreadState.Running Then
                                '    hiloProceso.Start()
                                'End If
                            Else
                                objBU.editarEstatusSimulacionActual(False)
                                Dim objMensajeAdv As New Tools.AdvertenciaForm
                                objMensajeAdv.mensaje = "Debe importar el ordenamiento."
                                objMensajeAdv.ShowDialog()
                            End If
                        Else
                            llenarTabSimulacionNoSimularTodo()

                            Dim contProgress As Int32 = grdSimulacion.Rows.Count
                            prgProgresoSimulacion.Minimum = 0
                            prgProgresoSimulacion.Maximum = contProgress
                            prgProgresoSimulacion.Value = 0
                            'pnlProgress.Visible = True
                            'lblProceso.Visible = True
                            lblTiempoInicio.Text = horaActual.ToShortTimeString

                            objBU.truncarTablaSimulacionProceso()
                            objBU.insertarDatosProgramasRenglonSimulador_SinSimular(lblIdUltimaConfiguracion.Text)

                            'Me.Cursor = Cursors.WaitCursor

                            Dim objBuSim As New Negocios.SimulacionBU
                            If grdSimulacion.Rows.Count > 0 Then
                                Me.Cursor = Cursors.WaitCursor
                                dtCapacidadesArticuloGlobal = New DataTable
                                dtCapacidadesArticuloGlobal = objBuSim.consultaExistenciaCapacidadArticuloAnioSimulacion(lblIdUltimaConfiguracion.Text, chkCambioArticulo.Checked)
                                dtCapacidadesHormasGlobal = New DataTable
                                dtCapacidadesHormasGlobal = objBuSim.consultaExistenciaHormasCapacidadSimulacion(lblIdUltimaConfiguracion.Text, chkCambioArticulo.Checked)
                                dtCapacidadesGrupoGlobal = New DataTable
                                dtCapacidadesGrupoGlobal = objBuSim.consultaExistenciaGruposCapacidadSimulacion
                                dtCapacidadesLineaProduccionGlobal = New DataTable
                                dtCapacidadesLineaProduccionGlobal = objBuSim.consultaExistenciaLineaProduccionCapacidadSimulacion(lblIdUltimaConfiguracion.Text, chkLimiteCapacidad.Checked)

                                If chkCambioArticulo.Checked = True Then
                                    For Each rowArtG As DataRow In dtCapacidadesArticuloGlobal.Select("smac_tipoAlta = 2")
                                        For filaArtGlobal As Int32 = dtCapacidadesArticuloGlobal.Rows.Count - 1 To 0 Step -1
                                            If dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_linpID").ToString = rowArtG.Item("lineaOrigen").ToString And
                                                dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_productoEstiloId").ToString = rowArtG.Item("proc_productoEstiloId").ToString And
                                                dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_tallaID").ToString = rowArtG.Item("proc_tallaID").ToString And
                                                dtCapacidadesArticuloGlobal.Rows(filaArtGlobal).Item("proc_año").ToString = rowArtG.Item("proc_año").ToString Then

                                                dtCapacidadesArticuloGlobal.Rows.Remove(dtCapacidadesArticuloGlobal.Rows(filaArtGlobal))

                                            End If
                                        Next
                                    Next
                                End If

                                generarSimulacion()
                                lblTiempoFinalizo.Text = DateTime.Now.ToShortTimeString
                                Me.Cursor = Cursors.Default

                                Dim objMsjExito As New Tools.ExitoForm
                                objMsjExito.mensaje = "Simulación terminada."
                                objMsjExito.ShowDialog()

                                'hiloProceso = New Threading.Thread(AddressOf generarSimulacion)
                                'If hiloProceso.ThreadState <> Threading.ThreadState.Running Then
                                '    hiloProceso.Start()
                                'End If
                            Else
                                objBU.editarEstatusSimulacionActual(False)
                                Dim objMensajeAdv As New Tools.AdvertenciaForm
                                objMensajeAdv.mensaje = "Debe importar el ordenamiento."
                                objMensajeAdv.ShowDialog()
                            End If
                        End If

                    Else
                        'pnlProgress.Visible = False
                    End If
                Else
                    Dim objMensajeAdv As New Tools.AdvertenciaForm
                    objMensajeAdv.mensaje = "Seleccione un rango de semanas correcto"
                    objMensajeAdv.ShowDialog()
                End If
            Else
                Dim objMensajeAdv As New Tools.AdvertenciaForm
                objMensajeAdv.mensaje = "Debe dar de alta la configuración de la simulación"
                objMensajeAdv.ShowDialog()
            End If
        Else
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            objMensajeAdv.mensaje = "El estatus de simulación actual es activo, posiblemente alguien más este realizando una simulación."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'Try
        '    If hiloProceso.IsAlive = True Then

        '        hiloProceso.Abort()
        '        pnlProgress.Visible = False
        '        Dim objBuSim As New Negocios.SimulacionBU
        '        objBuSim.editarEstatusSimulacionActual(False)

        '        Dim objMensajeAdv As New Tools.AvisoForm
        '        objMensajeAdv.mensaje = " La simulación fue cancelada."
        '        objMensajeAdv.ShowDialog()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub grdSimulacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdSimulacion.InitializeLayout

    End Sub

    Private Sub btnEjecutarOrdenamiento_Click(sender As Object, e As EventArgs) Handles btnEjecutarOrdenamiento.Click
        Dim objMsjPregunta As New Tools.ConfirmarForm
        objMsjPregunta.mensaje = "¿Está seguro de cargar los datos?"
        If objMsjPregunta.ShowDialog = Windows.Forms.DialogResult.OK Then
            ejecutarOrdenamiento()
        End If
    End Sub


    Private Sub btnNuevaSimulacion_Click(sender As Object, e As EventArgs) Handles btnNuevaSimulacion.Click
        tbtSimulador.SelectedTab = tbtSimulador.TabPages.Item(0)
        Dim objBU As New Negocios.SimulacionBU
        Dim dtOpciones As New DataTable

        chkSeleccionarTodos.Enabled = True
        txtDescripcion.Enabled = True
        grdOrdenamiento.DataSource = Nothing
        btnGuardar.Enabled = True
        btnCancelarNueva.Enabled = True
        btnNuevaSimulacion.Enabled = False
        pnlBotones.Enabled = False

        txtDescripcion.Text = "SIMULACIÓN " + (CInt(lblIdUltimaConfiguracion.Text) + 1).ToString + " " + Date.Now.Date.ToShortDateString

        dtOpciones = objBU.verOpcionesSimulacion

        If dtOpciones.Rows.Count > 0 Then
            grdOrdenamiento.DataSource = dtOpciones
            formatoGridOrdenamiento()
        Else
            grdOrdenamiento.DataSource = Nothing
        End If
        chkCambioArticulo.Visible = False
        chkLimiteCapacidad.Visible = False
    End Sub

    Private Sub btnCancelarNueva_Click(sender As Object, e As EventArgs) Handles btnCancelarNueva.Click
        chkSeleccionarTodos.Enabled = False
        chkSeleccionarTodos.Checked = False
        txtDescripcion.Enabled = False
        grdOrdenamiento.DataSource = Nothing
        btnCancelarNueva.Enabled = False
        btnGuardar.Enabled = False
        btnNuevaSimulacion.Enabled = True
        pnlBotones.Enabled = True
        txtDescripcion.Text = String.Empty
        chkCambioArticulo.Visible = False
        chkLimiteCapacidad.Visible = False
        llenarDatos()
    End Sub

    Private Sub btnGuardarCambiosOrden_Click(sender As Object, e As EventArgs) Handles btnGuardarCambiosOrden.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Esta seguro de guardar los cambios en el ordenamiento de la simulacion actual?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            guardarCambiosOrdenamientoYConfiguracion()
        End If
    End Sub

    Private Sub cmbSimulacion_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub numFinal_LostFocus(sender As Object, e As EventArgs) Handles numFinal.LostFocus
        If numFinal.Value.ToString = "" Then
            numFinal.Value = numFinal.Maximum
        End If
    End Sub

    Private Sub numFinal_ValueChanged(sender As Object, e As EventArgs) Handles numFinal.ValueChanged

    End Sub

    Private Sub numInicio_LostFocus(sender As Object, e As EventArgs) Handles numInicio.LostFocus
        If numInicio.Value.ToString = "" Then
            Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)

            If semanaActual = 53 Then
                If DatePart(DateInterval.Month, semanaActual) = 12 Then
                    semanaActual = 52
                ElseIf DatePart(DateInterval.Month, semanaActual) = 1 Then
                    semanaActual = 1
                End If
            End If
            If semanaActual >= numInicio.Minimum And semanaActual <= numInicio.Maximum Then
                numInicio.Value = semanaActual
            End If
        End If
    End Sub

    Private Sub numInicio_ValueChanged(sender As Object, e As EventArgs) Handles numInicio.ValueChanged

    End Sub

    Private Sub chkSeleccionarTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodos.CheckedChanged
        Dim cont As Int32 = 1
        For Each rorGrd As UltraGridRow In grdOrdenamiento.Rows
            rorGrd.Cells("Sel").Value = chkSeleccionarTodos.Checked
            rorGrd.Cells("Orden").Value = cont
            If chkSeleccionarTodos.Checked = True Then
                cont += 1
            End If
        Next
    End Sub


    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        tbtSimulador.SelectedTab = tbtSimulador.TabPages.Item(1)
        If grdSimulacion.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub
End Class