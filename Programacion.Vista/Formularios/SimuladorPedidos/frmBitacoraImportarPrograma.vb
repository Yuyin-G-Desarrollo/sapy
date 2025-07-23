Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmBitacoraImportarPrograma
    Dim fechaEntregaOpciones As Date

    Public Sub guardarFechas(ByVal folio As Int32, ByVal semanaInicio As Int32, ByVal semanaFin As Int32)
        Dim objBU As New Negocios.ProgramasBU
        objBU.inactivarFechasImportacionAnterior()
        objBU.guardarFechasImportacion(dttInicio.Value.ToShortDateString, dttFin.Value.ToShortDateString, semanaInicio, semanaFin, dttInicio.Value.Year, dttFin.Value.Year, folio)
    End Sub

    Public Sub llenarBitacora(ByVal folioB As Int32)

        Dim objBU As New Negocios.ProgramasBU
        Dim dt As New DataTable
        dt = objBU.consultaBitacora(folioB)
        If dt.Rows.Count > 0 Then
            grdBitacora.DataSource = dt
            grdBitacora.DisplayLayout.Bands(0).Columns("Fecha").Format = "dd/MM/yyyy HH:mm:ss"
            grdBitacora.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = HAlign.Right
            grdBitacora.DisplayLayout.Bands(0).Columns("Folio").CellAppearance.TextHAlign = HAlign.Right
            grdBitacora.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdBitacora.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdBitacora.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdBitacora.DisplayLayout.Override.RowSelectorWidth = 35
            grdBitacora.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdBitacora.Rows(0).Selected = True
        End If

    End Sub

    Public Sub recuperarRangoMeses()
        Dim objBU As New Negocios.ProgramasBU
        Dim semanasMax As Int32 = 0
        Dim diasProgramados As Int32 = 0
        Dim fechaEntregaOpcionesValidacion As Date = Now.Date
        Dim fechaMax As Date = Now.Date
        Dim semanasDiferenciasAdelante As Int32 = 0
        Dim semanasDiferenciasAtras As Int32 = 0

        fechaEntregaOpciones = objBU.ObtenerOpcionFecha("FECHAENTREGA")
        diasProgramados = objBU.ObtenerOpcionValorEntero("DIASPROGRAMA")
        semanasMax = objBU.ObtenerOpcionValorEntero("SemanasProgramacion")

        'If DatePart(DateInterval.Weekday, Date.Now) < 4 Then

        'dttInicio.MinDate = DateAdd(DateInterval.WeekOfYear, 1, Date.Now)
        semanasMax = semanasMax - 1
        dttFin.MaxDate = DateAdd(DateInterval.WeekOfYear, semanasMax - 2, fechaEntregaOpciones)

        Dim fechaLunesMax As Date = DateAdd(DateInterval.Day, 7, Date.Now)
        Dim diaSemanaMaxL As Integer = DatePart(DateInterval.Weekday, fechaLunesMax)

        if diaSemanaMaxL = 1 Then
            fechaLunesMax = DateAdd(DateInterval.Day, 1, fechaLunesMax)
        ElseIf diaSemanaMaxL = 3 Then
            fechaLunesMax = DateAdd(DateInterval.Day, -1, fechaLunesMax)
        ElseIf diaSemanaMaxL = 4 Then
            fechaLunesMax = DateAdd(DateInterval.Day, -2, fechaLunesMax)
        ElseIf diaSemanaMaxL = 5 Then
            fechaLunesMax = DateAdd(DateInterval.Day, -3, fechaLunesMax)
        ElseIf diaSemanaMaxL = 6 Then
            fechaLunesMax = DateAdd(DateInterval.Day, -4, fechaLunesMax)
        ElseIf diaSemanaMaxL = 7 Then
            fechaLunesMax = DateAdd(DateInterval.Day, -5, fechaLunesMax)
        End If

        dttInicio.MinDate = fechaLunesMax
        dttFin.MinDate = fechaLunesMax

        fechaMax = DateAdd(DateInterval.Day, semanasMax, fechaEntregaOpciones)

    End Sub

    Public Sub llenarTablasPelidosLotes()
        Dim objBU As New Negocios.ProgramasBU
        Dim dtPedidos As New DataTable
        Dim dtLotes As New DataTable

        dtPedidos = objBU.consultaPedidosConfirmadosSinApartar
        dtLotes = objBU.consultaPedidosSinProgramaAsignado
        Dim folioAnterior As Int32 = 0
        folioAnterior = objBU.obtenerFolio

        folioAnterior = folioAnterior - 1
        llenarBitacora(folioAnterior)

        If dtPedidos.Rows.Count Then
            grdPedidos.DataSource = dtPedidos
            disenioGriPedios()
        Else
            grdPedidos.DataSource = Nothing
        End If

        If dtLotes.Rows.Count Then
            grdLotes.DataSource = dtLotes
            disenioGriLotes()
        Else
            grdLotes.DataSource = Nothing
        End If

    End Sub

    Public Sub disenioGriPedios()
        With grdPedidos.DisplayLayout.Bands(0)
            '.Columns("IdPartida").Hidden = True
            .Columns("idLote").Hidden = True
            .Columns("Tipo").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("clie_clienteid").Hidden = True
            .Columns("idHorma").Hidden = True
            .Columns("idGrupo").Hidden = True

            .Columns("prod_productoid").Hidden = True
            .Columns("idCadena").Hidden = True

            .Columns("idPedido").Header.Caption = "Pedido"
            .Columns("IdPartida").Header.Caption = "Renglón"
            .Columns("Entrega").Header.Caption = "Entrega"
            .Columns("Producto").Header.Caption = "Artículo"
            .Columns("Programado").Header.Caption = "Programado"

            .Columns("estatus").Header.Caption = "Estatus"
            .Columns("Bloqueo").Header.Caption = "Bloqueado ?"
            .Columns("stLotesA").Header.Caption = " Estatus Lote"
            .Columns("capacidad").Header.Caption = "En Capacidad ?"
            .Columns("cantidad").Header.Caption = "Cantidad"

            .Columns("EntregaCliente").Header.Caption = "F. Entrega Cliente"

            .Columns("idPedido").CellActivation = Activation.NoEdit
            .Columns("Entrega").CellActivation = Activation.NoEdit
            .Columns("SICY").CellActivation = Activation.NoEdit
            .Columns("SAY").CellActivation = Activation.NoEdit
            .Columns("Programado").CellActivation = Activation.NoEdit
            .Columns("prod_productoid").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Ranking").CellActivation = Activation.NoEdit
            .Columns("Especial").CellActivation = Activation.NoEdit
            .Columns("pstilo").CellActivation = Activation.NoEdit
            .Columns("talla_tallaid").CellActivation = Activation.NoEdit
            .Columns("Tipo").CellActivation = Activation.NoEdit
            .Columns("estatus").CellActivation = Activation.NoEdit
            .Columns("Bloqueo").CellActivation = Activation.NoEdit
            .Columns("stLotesA").CellActivation = Activation.NoEdit
            .Columns("capacidad").CellActivation = Activation.NoEdit
            .Columns("cantidad").CellActivation = Activation.NoEdit
            .Columns("Producto").CellActivation = Activation.NoEdit
            .Columns("EntregaCliente").CellActivation = Activation.NoEdit

            .Columns("idPedido").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Ranking").CellAppearance.TextHAlign = HAlign.Right
            .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdPartida").CellAppearance.TextHAlign = HAlign.Right

        End With

        grdPedidos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdPedidos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPedidos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPedidos.DisplayLayout.Override.RowSelectorWidth = 35
        grdPedidos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdPedidos.Rows(0).Selected = True

        'grdPedidos.DisplayLayout.Bands(0).Columns("clie_nombregenerico").Width = 380
        'grdPedidos.DisplayLayout.Bands(0).Columns("incremento").Width = 50
        'grdPedidos.DisplayLayout.Bands(0).Columns("descuento").Width = 50
        'grdPedidos.DisplayLayout.Bands(0).Columns("calculaDesc").Width = 30
        'grdPedidos.DisplayLayout.Bands(0).Columns("ESTATUS").Width = 100
        'grdPedidos.DisplayLayout.Bands(0).Columns("Seleccion").Width = 40

    End Sub

    Public Sub disenioGriLotes()
        With grdLotes.DisplayLayout.Bands(0)
            '.Columns("IdPartida").Hidden = True
            .Columns("idLote").Hidden = True
            .Columns("Tipo").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("clie_clienteid").Hidden = True
            .Columns("idHorma").Hidden = True
            .Columns("idGrupo").Hidden = True

            .Columns("prod_productoid").Hidden = True
            .Columns("idCadena").Hidden = True

            .Columns("idPedido").Header.Caption = "Pedido"
            .Columns("IdPartida").Header.Caption = "Renglón"
            .Columns("Entrega").Header.Caption = "Entrega"
            .Columns("Producto").Header.Caption = "Artículo"
            .Columns("Programado").Header.Caption = "Programado"

            .Columns("estatus").Header.Caption = "Estatus"
            .Columns("Bloqueo").Header.Caption = "Bloqueado ?"
            .Columns("stLotesA").Header.Caption = " Estatus Lote"
            .Columns("capacidad").Header.Caption = "En Capacidad ?"
            .Columns("cantidad").Header.Caption = "Cantidad"

            .Columns("EntregaCliente").Header.Caption = "F. Entrega Cliente"

            .Columns("idPedido").CellActivation = Activation.NoEdit
            .Columns("Entrega").CellActivation = Activation.NoEdit
            .Columns("SICY").CellActivation = Activation.NoEdit
            .Columns("SAY").CellActivation = Activation.NoEdit
            .Columns("Programado").CellActivation = Activation.NoEdit
            .Columns("prod_productoid").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Ranking").CellActivation = Activation.NoEdit
            .Columns("Especial").CellActivation = Activation.NoEdit
            .Columns("pstilo").CellActivation = Activation.NoEdit
            .Columns("talla_tallaid").CellActivation = Activation.NoEdit
            .Columns("Tipo").CellActivation = Activation.NoEdit
            .Columns("estatus").CellActivation = Activation.NoEdit
            .Columns("Bloqueo").CellActivation = Activation.NoEdit
            .Columns("stLotesA").CellActivation = Activation.NoEdit
            .Columns("capacidad").CellActivation = Activation.NoEdit
            .Columns("cantidad").CellActivation = Activation.NoEdit
            .Columns("Producto").CellActivation = Activation.NoEdit

            .Columns("idPedido").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Ranking").CellAppearance.TextHAlign = HAlign.Right
            .Columns("cantidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("IdPartida").CellAppearance.TextHAlign = HAlign.Right

        End With

        grdLotes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdLotes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdLotes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdLotes.DisplayLayout.Override.RowSelectorWidth = 35
        grdLotes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdLotes.Rows(0).Selected = True

    End Sub

    Public Function validarFechas() As Boolean
        If CDate(dttInicio.Value) > CDate(dttFin.Value) Then
            Return False
        End If
        If CDate(dttInicio.Value) > CDate(fechaEntregaOpciones) Then
            Return False
        End If
        Return True
    End Function

    Public Function importarInformacionBaseDatos() As String
        Dim objBU As New Negocios.ProgramasBU
        Dim msjImpRenglones As String = ""
        msjImpRenglones = objBU.importarProgramasRenglon(dttInicio.Value, dttFin.Value)
        Return msjImpRenglones
    End Function

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        Dim gr As New UltraGrid
        If result = Windows.Forms.DialogResult.OK Then
            Try

                If tbtAcciones.SelectedTab.Name = tbtPedido.Name Then
                     gr = grdPedidos
                ElseIf tbtAcciones.SelectedTab.Name = tbtLotes.Name Then
                    gr = grdLotes
                ElseIf tbtAcciones.SelectedTab.Name = tbtBitacora.Name Then
                    If grdBitacora.Rows.Count > 0 Then
                        gr = grdBitacora
                    End If
                End If

                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(gr, fileName)
                Me.Cursor = Cursors.Default
                Me.Cursor = Cursors.WaitCursor
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        If validarFechas() = True Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¡ Atención !  Este proceso puede tardar más de lo esperado." + vbCrLf + "Esta transaccion remplazará la información que existe actualmente.¿Esta seguro de acualizar la información?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                Dim mensaje As String = ""
                mensaje = importarInformacionBaseDatos()
                Dim folio As String = ImportarProgramasPedidos()
                ImportarProgramasLotes(folio)
                llenarBitacora(folio)
                Dim objBU As New Negocios.SimulacionBU
                objBU.truncarTablaTemporalSimulacion()
                Me.Cursor = Cursors.Default
                Dim objMsExito As New Tools.ExitoForm
                objMsExito.mensaje = "Importación completada. " + mensaje
                objMsExito.ShowDialog()

            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.mensaje = "La fecha Inicio no puede ser mayor a la fecha fin, ni mayor a la fecha de entrega configurada."
            objMensaje.ShowDialog()
        End If

    End Sub

    Private Sub frmBitacoraImportarPrograma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        recuperarRangoMeses()
        llenarTablasPelidosLotes()

    End Sub

    Public Function ImportarProgramasPedidos() As String

        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ProgramasBU
        Dim diasProgramados As Int32 = 0

        Dim folioNuevo As Int32 = 1
        'Paso Importar debe ser siempre antes de programar; importar realiza el translado de los datos sin validación
        'ya que se importan los programas que ya existen, en cambio programar realiza valizaciones para las nuevas programaciones.


        folioNuevo = objBU.obtenerFolio
        lblFolio.Text = folioNuevo.ToString

        fechaEntregaOpciones = objBU.ObtenerOpcionFecha("FECHAENTREGA")
        diasProgramados = objBU.ObtenerOpcionValorEntero("DIASPROGRAMA")

        Dim semanaInicio As Int32 = 0, semanaFin As Int32 = 0
        semanaInicio = DatePart(DateInterval.WeekOfYear, dttInicio.Value)
        semanaFin = DatePart(DateInterval.WeekOfYear, dttFin.Value)

        If semanaInicio = 53 Then
            If DatePart(DateInterval.Month, dttInicio.Value) = 12 Then
                semanaInicio = 52
            ElseIf DatePart(DateInterval.Month, dttInicio.Value) = 1 Then
                semanaInicio = 1
            End If
        End If

        If semanaFin = 53 Then
            If DatePart(DateInterval.Month, dttFin.Value) = 12 Then
                semanaFin = 52
            ElseIf DatePart(DateInterval.Month, dttFin.Value) = 1 Then
                semanaFin = 1
            End If
        End If

        guardarFechas(folioNuevo, semanaInicio, semanaFin)

        For Each rowGRDPedidos As UltraGridRow In grdPedidos.Rows
            Dim guardoRenglones As Boolean = False

            Dim semanaPedido As Int32 = 0
            Dim fechaEntregaPedido As Date
            fechaEntregaPedido = CDate(rowGRDPedidos.Cells("Entrega").Value.ToString)
            fechaEntregaPedido = DateAdd(DateInterval.Day, -(diasProgramados), fechaEntregaPedido)
            semanaPedido = DatePart(DateInterval.WeekOfYear, fechaEntregaPedido)


            If semanaPedido = 53 Then
                If DatePart(DateInterval.Month, fechaEntregaPedido) = 12 Then
                    semanaPedido = 52
                ElseIf DatePart(DateInterval.Month, fechaEntregaPedido) = 1 Then
                    semanaPedido = 1
                End If
            End If


            Dim semanasMaximoRecorrerAtras As Int32 = 0
            Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)

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


            If rowGRDPedidos.Cells("capacidad").Value = True And rowGRDPedidos.Cells("Bloqueo").Value = False Then
                objBU.guardarRegistroBItacora(folioNuevo, rowGRDPedidos.Cells("idPedido").Value, CInt(rowGRDPedidos.Index.ToString) + 1, rowGRDPedidos.Cells("prod_productoid").Value,
                                 rowGRDPedidos.Cells("cantidad").Value, CDate(rowGRDPedidos.Cells("Entrega").Value.ToString).ToShortDateString, "INICIO DEL PROCESO", "INICIO", 0, 0,
                                  rowGRDPedidos.Cells("pstilo").Value, rowGRDPedidos.Cells("talla_tallaid").Value, "", 0, 0)
                If DatePart(DateInterval.WeekOfYear, CDate(rowGRDPedidos.Cells("Entrega").Value.ToString)) >= DatePart(DateInterval.WeekOfYear, fechaEntregaOpciones) Then
                    guardoRenglones = importacionPedidosCodEstructura(folioNuevo, fechaEntregaPedido, semanaPedido, semanaInicio, semanaFin,
                                                    rowGRDPedidos.Cells("prod_productoid").Value, rowGRDPedidos.Cells("pstilo").Value,
                                                    rowGRDPedidos.Cells("idPedido").Value, rowGRDPedidos.Cells("idPartida").Value,
                                                    rowGRDPedidos.Cells("idLote").Value, rowGRDPedidos.Cells("talla_tallaid").Value,
                                                    rowGRDPedidos.Cells("idCadena").Value, rowGRDPedidos.Cells("cantidad").Value,
                                                    rowGRDPedidos.Cells("Programado").Value, rowGRDPedidos.Cells("clie_clienteid").Value.ToString,
                                                    rowGRDPedidos.Cells("idHorma").Value, rowGRDPedidos.Cells("Tipo").Value,
                                                    grdPedidos.Rows.IndexOf(rowGRDPedidos), rowGRDPedidos.Cells("Entrega").Value.ToString,
                                                    rowGRDPedidos.Cells("EntregaCliente").Value.ToString, rowGRDPedidos.Cells("idGrupo").Value.ToString)


                    If guardoRenglones = False Then
                        Dim semanaPedidoResta As Int32 = semanaPedido
                        Dim guardoOtraSemanaAtras As Boolean = False
                        For i As Int32 = 0 To semanasMaximoRecorrerAtras - 1
                            semanaPedidoResta -= 1
                            If guardoOtraSemanaAtras = False Then
                                If semanaInicio <= semanaPedidoResta Then
                                    guardoOtraSemanaAtras = importacionPedidosCodEstructura(folioNuevo, fechaEntregaPedido, (semanaPedidoResta), semanaInicio, semanaFin,
                                                            rowGRDPedidos.Cells("prod_productoid").Value, rowGRDPedidos.Cells("pstilo").Value,
                                                            rowGRDPedidos.Cells("idPedido").Value, rowGRDPedidos.Cells("idPartida").Value,
                                                            rowGRDPedidos.Cells("idLote").Value, rowGRDPedidos.Cells("talla_tallaid").Value,
                                                            rowGRDPedidos.Cells("idCadena").Value, rowGRDPedidos.Cells("cantidad").Value,
                                                            rowGRDPedidos.Cells("Programado").Value, rowGRDPedidos.Cells("clie_clienteid").Value.ToString,
                                                            rowGRDPedidos.Cells("idHorma").Value, rowGRDPedidos.Cells("Tipo").Value,
                                                            grdPedidos.Rows.IndexOf(rowGRDPedidos), rowGRDPedidos.Cells("Entrega").Value.ToString,
                                                            rowGRDPedidos.Cells("EntregaCliente").Value.ToString, rowGRDPedidos.Cells("idGrupo").Value.ToString)
                                Else
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Next

                        If guardoOtraSemanaAtras = False Then

                            Dim semanaPedidoAumenta As Int32 = semanaPedido
                            Dim guardoOtraSemanaAdelante As Boolean = False


                            Dim anioRecorrer As Int32 = DatePart(DateInterval.Year, fechaEntregaPedido)
                            Do While guardoOtraSemanaAdelante = False

                                semanaPedidoAumenta += 1
                                If semanaPedidoAumenta >= 53 And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) + 1 Then
                                    guardoOtraSemanaAdelante = True
                                ElseIf semanaPedidoAumenta >= 53 And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) Then
                                    If semanaFin < semanaInicio Then
                                        semanaPedidoAumenta = 1
                                        anioRecorrer += 1
                                    Else
                                        guardoOtraSemanaAdelante = True
                                    End If
                                ElseIf semanaPedidoAumenta = semanaFin And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) + 1 Then
                                    guardoOtraSemanaAdelante = True
                                End If

                                If guardoOtraSemanaAdelante = False Then

                                    If semanaInicio <= semanaPedidoResta Then
                                        guardoOtraSemanaAdelante = importacionPedidosCodEstructura(folioNuevo, fechaEntregaPedido, (semanaPedidoAumenta), semanaInicio, semanaFin,
                                                                rowGRDPedidos.Cells("prod_productoid").Value, rowGRDPedidos.Cells("pstilo").Value,
                                                                rowGRDPedidos.Cells("idPedido").Value, rowGRDPedidos.Cells("idPartida").Value,
                                                                rowGRDPedidos.Cells("idLote").Value, rowGRDPedidos.Cells("talla_tallaid").Value,
                                                                rowGRDPedidos.Cells("idCadena").Value, rowGRDPedidos.Cells("cantidad").Value,
                                                                rowGRDPedidos.Cells("Programado").Value, rowGRDPedidos.Cells("clie_clienteid").Value.ToString,
                                                                rowGRDPedidos.Cells("idHorma").Value, rowGRDPedidos.Cells("Tipo").Value,
                                                                grdPedidos.Rows.IndexOf(rowGRDPedidos), rowGRDPedidos.Cells("Entrega").Value.ToString,
                                                                rowGRDPedidos.Cells("EntregaCliente").Value.ToString, rowGRDPedidos.Cells("idGrupo").Value.ToString)
                                    Else
                                        guardoOtraSemanaAdelante = True
                                    End If

                                End If

                            Loop

                        End If

                    End If

                Else
                    'guardoProgramaRenglonSemanaPedido = False
                    objBU.guardarRegistroBItacora(folioNuevo, rowGRDPedidos.Cells("idPedido").Value, rowGRDPedidos.Cells("idPartida").Value.ToString, rowGRDPedidos.Cells("prod_productoid").Value,
                                 rowGRDPedidos.Cells("cantidad").Value, CDate(fechaEntregaPedido.ToString).ToShortDateString, "NO SE PROGRAMA POR FECHA DE ENTREGA ATRASADA. PEDIDO: " + rowGRDPedidos.Cells("idPedido").Value.ToString, "NO_PROGRAMADOFECHA_PPCP", 0, 0,
                                  rowGRDPedidos.Cells("pstilo").Value, rowGRDPedidos.Cells("talla_tallaid").Value, "", 0, 0)
                End If


            ElseIf rowGRDPedidos.Cells("Bloqueo").Value = True Then
                'guardoProgramaRenglonSemanaPedido = False
                objBU.guardarRegistroBItacora(folioNuevo, rowGRDPedidos.Cells("idPedido").Value, rowGRDPedidos.Cells("idPartida").Value.ToString, rowGRDPedidos.Cells("prod_productoid").Value,
                                  rowGRDPedidos.Cells("cantidad").Value, CDate(fechaEntregaPedido.ToString).ToShortDateString, "CLIENTE BLOQUEADO", "ClienteBloqueado", 0, 0,
                                   rowGRDPedidos.Cells("pstilo").Value, rowGRDPedidos.Cells("talla_tallaid").Value, "", 0, 0)

            ElseIf rowGRDPedidos.Cells("capacidad").Value = False Then
                'guardoProgramaRenglonSemanaPedido = False
                objBU.guardarRegistroBItacora(folioNuevo, rowGRDPedidos.Cells("idPedido").Value, rowGRDPedidos.Index + 1, rowGRDPedidos.Cells("prod_productoid").Value,
                                  rowGRDPedidos.Cells("cantidad").Value, CDate(fechaEntregaPedido.ToString).ToShortDateString, "ARTÍCULO SIN CAPACIDAD ASIGNADA", "ArticuloSinCapacidadAsignada", 0, 0,
                                   rowGRDPedidos.Cells("pstilo").Value, rowGRDPedidos.Cells("talla_tallaid").Value, "", 0, 0)

            End If

        Next


        Return folioNuevo.ToString
    End Function

    Public Function importacionPedidosCodEstructura(ByVal folioNuevo As Int32, ByVal fechaEntregaPedido As Date, ByVal semanaPedido As Int32,
                                               ByVal semanaInicio As Int32, ByVal semanaFin As Int32, ByVal idProducto As Int32,
                                               ByVal idPStilo As Int32, ByVal idPedido As Int32, ByVal idPartida As Int32,
                                               ByVal idLote As String, ByVal idTalla As Int32, ByVal idCadena As String,
                                               ByVal cantidad As Int32, ByVal programado As Int32, ByVal idCliente As String,
                                               ByVal idHorma As Int32, ByVal tipo As String, ByVal filaIndex As Int32,
                                               ByVal FechaEntregaPedidoTabla As String, ByVal entregaCliente As String,
                                               ByVal idGrupo As Int32) As Boolean
        Dim objBU As New Negocios.ProgramasBU
        Dim dtCapacidadArticulo As New DataTable
        Dim dtCapacidadArticuloPares As New DataTable
        Dim guardoProgramaRenglonSemanaPedido As Boolean = False
        Dim tipoReg As String = ""

        If tipo = "Pedido" Then
            tipoReg = "A"
        Else
            tipoReg = "L"
        End If

        If semanaPedido >= semanaInicio And semanaPedido <= semanaFin Then
            dtCapacidadArticulo = objBU.consultaExistenciaCapacidadArticuloAnio(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
                                                                                semanaInicio, semanaFin, idProducto, idPStilo, idTalla)

            dtCapacidadArticuloPares = objBU.consultaExistenciaCapacidadParesXArticuloAnio(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value), semanaInicio, semanaFin,
                                                                           idProducto, idPStilo, idTalla)
            Dim insertoCapacidadCompleta As Boolean = False

            If dtCapacidadArticulo.Rows.Count > 0 Then
                Dim textoSemanaPedido As String = ""
                '' INICIA COMPLETO---------------------------------------------------------- {
                '--------------------------------------------------------------------
                If programado = 0 Then
                    For Each rwdtArtCapacidad As DataRow In dtCapacidadArticulo.Rows

                        If insertoCapacidadCompleta = True Then
                            Exit For
                        End If

                        Dim capacidadArticulo As Int32 = 0

                        textoSemanaPedido = semanaPedido.ToString + "_" + DatePart(DateInterval.Year, fechaEntregaPedido).ToString

                        If rwdtArtCapacidad.Item(textoSemanaPedido.ToString).ToString <> "" Then

                            capacidadArticulo = rwdtArtCapacidad.Item(textoSemanaPedido.ToString)

                            Dim dtCapacidadHorma As New DataTable
                            dtCapacidadHorma = objBU.consultaCapacidadHormaXArticulo(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
                           semanaInicio, semanaFin,
                           idPStilo, idTalla,
                           rwdtArtCapacidad.Item("proc_linpID"),
                           idHorma.ToString)

                            If dtCapacidadHorma.Rows.Count > 0 Then
                                If dtCapacidadHorma.Rows(0).Item("horc_" + textoSemanaPedido).ToString > 0 Then

                                    '' GRUPOS { Proceso actual susana
                                    Dim dtCapacidadGrupo As New DataTable
                                    dtCapacidadGrupo = objBU.consultaCapacidadLineaProduccionGruposXArticulo(DatePart(DateInterval.Year, dttInicio.Value),
                                                                                                             DatePart(DateInterval.Year, dttFin.Value),
                                                                                                              semanaInicio, semanaFin,
                                                                                                             idPStilo, idTalla,
                                                                                                             rwdtArtCapacidad.Item("proc_linpID"), idGrupo)

                                    If dtCapacidadGrupo.Rows.Count > 0 Then

                                        If dtCapacidadGrupo.Rows(0).Item("gcap_" + textoSemanaPedido).ToString > 0 Then

                                            Dim dtCapacidadCelula As New DataTable
                                            Dim linea As String = rwdtArtCapacidad.Item("proc_linpID").ToString
                                            dtCapacidadCelula = objBU.consultaCapacidadLineaProduccionCelulaXArticulo(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
                                                semanaInicio,
                                                semanaFin,
                                                rwdtArtCapacidad.Item("proc_linpID"))

                                            If dtCapacidadCelula.Rows.Count > 0 Then
                                                If dtCapacidadCelula.Rows(0).Item("lcap_" + textoSemanaPedido.ToString) > 0 Then
                                                    If rwdtArtCapacidad.Item(textoSemanaPedido.ToString).ToString <> "" Then
                                                        If capacidadArticulo > 0 Then
                                                            If capacidadArticulo >= cantidad Then

                                                                objBU.guardarProgramaRenglonCompleto(rwdtArtCapacidad.Item("proc_linpID"),
                                                                                                     idProducto,
                                                                                                     idPStilo,
                                                                                                     idPedido,
                                                                                                     idPartida,
                                                                                                     idLote,
                                                                                                     idTalla,
                                                                                                     idCadena,
                                                                                                     cantidad,
                                                                                                     DatePart(DateInterval.Year, CDate(fechaEntregaPedido.ToString)),
                                                                                                     semanaPedido,
                                                                                                     idCliente,
                                                                                                     rwdtArtCapacidad.Item("linp_idNave"),
                                                                                                     idHorma.ToString,
                                                                                                     FechaEntregaPedidoTabla,
                                                                                                     entregaCliente,
                                                                                                     tipoReg)

                                                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                   cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString,
                                                   tipo.ToString.ToUpper + " ASIGNADO COMPLETO EN LA SEMANA: " + semanaPedido.ToString + " LINEA NAVE: " + rwdtArtCapacidad.Item("proc_linpID").ToString + ". CANTIDAD " + cantidad.ToString + " RESTANTE: " + (capacidadArticulo - cantidad).ToString + "[" + tipo.ToString + "]", "PROGRAMADO_COMPLETO", 0, 0,
                                                     idPStilo, idTalla, "", 0, 0)
                                                                If tipo = "Pedido" Then
                                                                    grdPedidos.Rows(filaIndex).Cells("Programado").Value = cantidad
                                                                Else
                                                                    grdLotes.Rows(filaIndex).Cells("Programado").Value = cantidad
                                                                End If

                                                                programado = cantidad
                                                                insertoCapacidadCompleta = True
                                                            Else
                                                                insertoCapacidadCompleta = False
                                                            End If
                                                        Else
                                                            insertoCapacidadCompleta = False
                                                        End If
                                                    Else
                                                        insertoCapacidadCompleta = False
                                                        objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                      cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_CAPACIDAD_VACIA_SEMANA_PEDIDO", 0, 0,
                                                        idPStilo, idTalla, "", 0, 0)

                                                    End If
                                                Else
                                                    '' VALIDAR SI SE SALE E INTENTAR EN OTRA NAVE
                                                    insertoCapacidadCompleta = False
                                                    objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                             cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidad.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                              idPStilo, idTalla, "", 0, 0)
                                                End If


                                            Else
                                                insertoCapacidadCompleta = False
                                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                          cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                           idPStilo, idTalla, "", 0, 0)
                                            End If
                                        Else
                                            'GRUPOS(ESTABLECER)
                                            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                           cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                            idPStilo, idTalla, "", 0, 0)
                                        End If
                                    Else
                                        objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                             cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "SIN CAPACIDAD DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                              idPStilo, idTalla, "", 0, 0)
                                    End If

                                Else
                                    insertoCapacidadCompleta = False
                                    objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                            cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_HORMA", 0, 0,
                                             idPStilo, idTalla, "", 0, 0)
                                End If
                            Else
                                insertoCapacidadCompleta = False
                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                        cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_HORMA", 0, 0,
                                         idPStilo, idTalla, "", 0, 0)
                            End If

                        Else
                            insertoCapacidadCompleta = False
                            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                    cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DEL ARTICULO SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO", 0, 0,
                                     idPStilo, idTalla, "", 0, 0)

                        End If
                    Next
                End If
                '-----------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------} TERMINA COMPLETO

                '' INICIA PARCIAL ----------------------------------------------------
                '-----------------------------------------------------------------------
                For Each rwdtArtCapacidadParcial As DataRow In dtCapacidadArticulo.Rows

                    If programado < cantidad And insertoCapacidadCompleta = False Then
                        If rwdtArtCapacidadParcial.Item(textoSemanaPedido.ToString).ToString <> "" Then


                            Dim capacidadArticulo As Int32 = 0
                            capacidadArticulo = rwdtArtCapacidadParcial.Item(textoSemanaPedido.ToString)

                            Dim dtCapacidadHorma As New DataTable

                            dtCapacidadHorma = objBU.consultaCapacidadHormaXArticulo(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
                           semanaInicio, semanaFin,
                           idPStilo, idTalla,
                           rwdtArtCapacidadParcial.Item("proc_linpID"),
                           idHorma.ToString)

                            If dtCapacidadHorma.Rows.Count > 0 Then

                                If dtCapacidadHorma.Rows(0).Item("horc_" + textoSemanaPedido).ToString > 0 Then

                                    Dim dtCapacidadGrupo As New DataTable
                                    dtCapacidadGrupo = objBU.consultaCapacidadLineaProduccionGruposXArticulo(DatePart(DateInterval.Year, dttInicio.Value),
                                                                                                             DatePart(DateInterval.Year, dttFin.Value),
                                                                                                              semanaInicio, semanaFin,
                                                                                                             idPStilo, idTalla,
                                                                                                             rwdtArtCapacidadParcial.Item("proc_linpID"), idGrupo)

                                    If dtCapacidadGrupo.Rows.Count > 0 Then

                                        If dtCapacidadGrupo.Rows(0).Item("gcap_" + textoSemanaPedido).ToString > 0 Then


                                            Dim dtCapacidadCelula As New DataTable
                                            dtCapacidadCelula = objBU.consultaCapacidadLineaProduccionCelulaXArticulo(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
                                                                                                                      semanaInicio,
                                                                                                                      semanaFin,
                                                                                                                      rwdtArtCapacidadParcial.Item("proc_linpID"))


                                            If dtCapacidadCelula.Rows.Count > 0 Then

                                                If dtCapacidadCelula.Rows(0).Item("lcap_" + textoSemanaPedido.ToString) > 0 Then

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

                                                                objBU.guardarProgramaRenglonCompleto(rwdtArtCapacidadParcial.Item("proc_linpID"), idProducto, idPStilo,
                                                                                                     idPedido, idPartida, idLote, idTalla, idCadena, cantidadParcial,
                                                                                                     DatePart(DateInterval.Year, CDate(fechaEntregaPedido.ToString)),
                                                                                                     semanaPedido, idCliente, rwdtArtCapacidadParcial.Item("linp_idNave"),
                                                                                                     idHorma.ToString, FechaEntregaPedidoTabla, entregaCliente, tipoReg)

                                                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                   cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString,
                                                   tipo.ToString.ToUpper + " ASIGNADO PARCIAL EN LA SEMANA: " + semanaPedido.ToString + " LINEA NAVE: " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + ". CANTIDAD " + cantidadParcial.ToString + " RESTANTE: " + programadoRestante.ToString + "[" + tipo.ToString + "]", "PROGRAMADO_PARCIAL", 0, 0,
                                                     idPStilo, idTalla, "", 0, 0)
                                                                If tipo = "Pedido" Then
                                                                    grdPedidos.Rows(filaIndex).Cells("Programado").Value += cantidadParcial
                                                                Else
                                                                    grdPedidos.Rows(filaIndex).Cells("Programado").Value += cantidadParcial
                                                                End If
                                                                programado += cantidadParcial
                                                            Else
                                                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                                 cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                                  idPStilo, idTalla, "", 0, 0)
                                                            End If
                                                        Else
                                                            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                               cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "SIN CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                                idPStilo, idTalla, "", 0, 0)
                                                        End If
                                                    Else
                                                        objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                      cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_CAPACIDAD_VACIA_SEMANA_PEDIDO", 0, 0,
                                                        idPStilo, idTalla, "", 0, 0)

                                                    End If
                                                Else
                                                    objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                             cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "CAPACIDAD INSUFICIENTE DE CÉLULA " + rwdtArtCapacidadParcial.Item("proc_linpID").ToString + " SEMANA : " + semanaPedido.ToString + " PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                              idPStilo, idTalla, "", 0, 0)
                                                End If
                                            Else
                                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                                                                          cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                                                           idPStilo, idTalla, "", 0, 0)
                                            End If

                                        End If
                                    End If

                                Else
                                    objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                            cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_HORMA", 0, 0,
                                             idPStilo, idTalla, "", 0, 0)
                                End If
                            Else
                                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                        cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_HORMA", 0, 0,
                                         idPStilo, idTalla, "", 0, 0)
                            End If
                        Else

                            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                   cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DEL ARTICULO SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO", 0, 0,
                                    idPStilo, idTalla, "", 0, 0)
                        End If
                    End If
                Next
                '-----------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------} TERMINA PARCIAL
                If programado = cantidad Then
                    guardoProgramaRenglonSemanaPedido = True
                Else
                    guardoProgramaRenglonSemanaPedido = False
                End If
            Else
                '' '' VALIDAR SI SE SALE E INTENTAR EN OTRA NAVE O INTENTAR PARCIAL
                insertoCapacidadCompleta = False
                guardoProgramaRenglonSemanaPedido = False
                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                        cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA PARA EL ARTÍCULO: " + idProducto.ToString + "(ID ESTILO: " + idPStilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO", 0, 0,
                         idPStilo, idTalla, "", 0, 0)

            End If
        Else
            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idPartida.ToString, idProducto,
                                           cantidad, CDate(fechaEntregaPedido.ToString).ToShortDateString,
                                           tipo.ToString.ToUpper + " NO ASIGNADO FECHA PEDIDO FUERA DE RANGO: ", "NO_PROGRAMADO_FECHAFUERARANGO", 0, 0,
                                             idPStilo, idTalla, "", 0, 0)
            guardoProgramaRenglonSemanaPedido = False
        End If

        Return guardoProgramaRenglonSemanaPedido

    End Function

    Public Sub ImportarProgramasLotes(ByVal folioActual As String)

        Me.Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.ProgramasBU
        Dim diasProgramados As Int32 = 0

        'Paso Importar debe ser siempre antes de programar; importar realiza el translado de los datos sin validación
        'ya que se importan los programas que ya existen, en cambio programar realiza valizaciones para las nuevas programaciones.

        fechaEntregaOpciones = objBU.ObtenerOpcionFecha("FECHAENTREGA")
        diasProgramados = objBU.ObtenerOpcionValorEntero("DIASPROGRAMA")

        For Each rowGRDLotes As UltraGridRow In grdLotes.Rows
            Dim guardoRenglones As Boolean = False

            Dim semanaPedido As Int32 = 0
            Dim fechaEntregaPedido As Date
            fechaEntregaPedido = CDate(rowGRDLotes.Cells("Entrega").Value.ToString)
            fechaEntregaPedido = DateAdd(DateInterval.Day, -(diasProgramados), fechaEntregaPedido)
            semanaPedido = DatePart(DateInterval.WeekOfYear, fechaEntregaPedido)


            If semanaPedido = 53 Then
                If DatePart(DateInterval.Month, fechaEntregaPedido) = 12 Then
                    semanaPedido = 52
                ElseIf DatePart(DateInterval.Month, fechaEntregaPedido) = 1 Then
                    semanaPedido = 1
                End If
            End If


            Dim semanasMaximoRecorrerAtras As Int32 = 0
            Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)

            If semanaActual = 53 Then
                If DatePart(DateInterval.Month, semanaActual) = 12 Then
                    semanaActual = 52
                ElseIf DatePart(DateInterval.Month, semanaActual) = 1 Then
                    semanaActual = 1
                End If
            End If
            Dim cosa As String = DatePart(DateInterval.Weekday, Date.Now).ToString

            If DatePart(DateInterval.Weekday, Date.Now) < 4 Then
                semanasMaximoRecorrerAtras = semanaPedido - (semanaActual + 1)
            Else
                semanasMaximoRecorrerAtras = semanaPedido - (semanaActual + 2)
            End If




            If rowGRDLotes.Cells("capacidad").Value = True And rowGRDLotes.Cells("Bloqueo").Value = False Then
                objBU.guardarRegistroBItacora(folioActual, rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Cells("idPartida").Value, rowGRDLotes.Cells("prod_productoid").Value,
                                 rowGRDLotes.Cells("cantidad").Value, CDate(rowGRDLotes.Cells("Entrega").Value.ToString).ToShortDateString, "INICIO DEL PROCESO", "INICIO", 0, 0,
                                  rowGRDLotes.Cells("pstilo").Value, rowGRDLotes.Cells("talla_tallaid").Value, "", 0, 0)


                If DatePart(DateInterval.WeekOfYear, CDate(rowGRDLotes.Cells("Entrega").Value.ToString)) >= DatePart(DateInterval.WeekOfYear, fechaEntregaOpciones) Then

                    Dim semanaInicio As Int32 = 0, semanaFin As Int32 = 0
                    semanaInicio = DatePart(DateInterval.WeekOfYear, dttInicio.Value)
                    semanaFin = DatePart(DateInterval.WeekOfYear, dttFin.Value)

                    If semanaInicio = 53 Then
                        If DatePart(DateInterval.Month, dttInicio.Value) = 12 Then
                            semanaInicio = 52
                        ElseIf DatePart(DateInterval.Month, dttInicio.Value) = 1 Then
                            semanaInicio = 1
                        End If
                    End If


                    If semanaFin = 53 Then
                        If DatePart(DateInterval.Month, dttFin.Value) = 12 Then
                            semanaFin = 52
                        ElseIf DatePart(DateInterval.Month, dttFin.Value) = 1 Then
                            semanaFin = 1
                        End If
                    End If

                    guardoRenglones = importacionPedidosCodEstructura(folioActual, fechaEntregaPedido, semanaPedido, semanaInicio, semanaFin,
                                                    rowGRDLotes.Cells("prod_productoid").Value, rowGRDLotes.Cells("pstilo").Value,
                                                    rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Cells("idPartida").Value,
                                                    rowGRDLotes.Cells("idLote").Value, rowGRDLotes.Cells("talla_tallaid").Value,
                                                    rowGRDLotes.Cells("idCadena").Value, rowGRDLotes.Cells("cantidad").Value,
                                                    rowGRDLotes.Cells("Programado").Value, rowGRDLotes.Cells("clie_clienteid").Value.ToString,
                                                    rowGRDLotes.Cells("idHorma").Value, rowGRDLotes.Cells("Tipo").Value,
                                                    grdLotes.Rows.IndexOf(rowGRDLotes), rowGRDLotes.Cells("Entrega").Value.ToString,
                                                    rowGRDLotes.Cells("EntregaCliente").Value.ToString, rowGRDLotes.Cells("idGrupo").Value.ToString)


                    If guardoRenglones = False Then
                        Dim semanaPedidoResta As Int32 = semanaPedido
                        Dim guardoOtraSemanaAtras As Boolean = False
                        For i As Int32 = 0 To semanasMaximoRecorrerAtras - 1
                            semanaPedidoResta -= 1
                            If guardoOtraSemanaAtras = False Then
                                If semanaInicio <= semanaPedidoResta Then
                                    guardoOtraSemanaAtras = importacionPedidosCodEstructura(folioActual, fechaEntregaPedido, (semanaPedidoResta), semanaInicio, semanaFin,
                                                            rowGRDLotes.Cells("prod_productoid").Value, rowGRDLotes.Cells("pstilo").Value,
                                                            rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Cells("idPartida").Value,
                                                            rowGRDLotes.Cells("idLote").Value, rowGRDLotes.Cells("talla_tallaid").Value,
                                                            rowGRDLotes.Cells("idCadena").Value, rowGRDLotes.Cells("cantidad").Value,
                                                            rowGRDLotes.Cells("Programado").Value, rowGRDLotes.Cells("clie_clienteid").Value.ToString,
                                                            rowGRDLotes.Cells("idHorma").Value, rowGRDLotes.Cells("Tipo").Value,
                                                            grdLotes.Rows.IndexOf(rowGRDLotes), rowGRDLotes.Cells("Entrega").Value.ToString,
                                                            rowGRDLotes.Cells("EntregaCliente").Value.ToString, rowGRDLotes.Cells("idGrupo").Value.ToString)
                                Else
                                    Exit For
                                End If
                            Else
                                Exit For
                            End If
                        Next

                        If guardoOtraSemanaAtras = False Then

                            Dim semanaPedidoAumenta As Int32 = semanaPedido
                            Dim guardoOtraSemanaAdelante As Boolean = False

                            Dim anioRecorrer As Int32 = DatePart(DateInterval.Year, fechaEntregaPedido)
                            Do While guardoOtraSemanaAdelante = False

                                semanaPedidoAumenta += 1
                               
                                If semanaPedidoAumenta >= 53 And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) + 1 Then
                                    guardoOtraSemanaAdelante = True
                                ElseIf semanaPedidoAumenta >= 53 And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) Then
                                    If semanaFin < semanaInicio Then
                                        semanaPedidoAumenta = 1
                                        anioRecorrer += 1
                                    Else
                                        guardoOtraSemanaAdelante = True
                                    End If
                                ElseIf semanaPedidoAumenta = semanaFin And anioRecorrer = DatePart(DateInterval.Year, fechaEntregaPedido) + 1 Then
                                    guardoOtraSemanaAdelante = True
                                End If

                                If guardoOtraSemanaAdelante = False Then
                                    If semanaInicio <= semanaPedidoResta Then
                                        guardoOtraSemanaAdelante = importacionPedidosCodEstructura(folioActual, fechaEntregaPedido, (semanaPedidoAumenta), semanaInicio, semanaFin,
                                                                rowGRDLotes.Cells("prod_productoid").Value, rowGRDLotes.Cells("pstilo").Value,
                                                                rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Cells("idPartida").Value,
                                                                rowGRDLotes.Cells("idLote").Value, rowGRDLotes.Cells("talla_tallaid").Value,
                                                                rowGRDLotes.Cells("idCadena").Value, rowGRDLotes.Cells("cantidad").Value,
                                                                rowGRDLotes.Cells("Programado").Value, rowGRDLotes.Cells("clie_clienteid").Value.ToString,
                                                                rowGRDLotes.Cells("idHorma").Value, rowGRDLotes.Cells("Tipo").Value,
                                                                grdLotes.Rows.IndexOf(rowGRDLotes), rowGRDLotes.Cells("Entrega").Value.ToString,
                                                                rowGRDLotes.Cells("EntregaCliente").Value.ToString, rowGRDLotes.Cells("idGrupo").Value.ToString)
                                    Else
                                        guardoOtraSemanaAdelante = True
                                    End If
                                End If

                            Loop



                        End If




                    End If



                Else
                    'guardoProgramaRenglonSemanaPedido = False
                    objBU.guardarRegistroBItacora(folioActual, rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Cells("idPartida").Value.ToString, rowGRDLotes.Cells("prod_productoid").Value,
                                 rowGRDLotes.Cells("cantidad").Value, CDate(fechaEntregaPedido.ToString).ToShortDateString, "NO SE PROGRAMA POR FECHA DE ENTREGA ATRASADA. PEDIDO: " + rowGRDLotes.Cells("idPedido").Value.ToString, "NO_PROGRAMADOFECHA_PPCP", 0, 0,
                                  rowGRDLotes.Cells("pstilo").Value, rowGRDLotes.Cells("talla_tallaid").Value, "", 0, 0)
                End If


            ElseIf rowGRDLotes.Cells("Bloqueo").Value = True Then
                'guardoProgramaRenglonSemanaPedido = False
                objBU.guardarRegistroBItacora(folioActual, rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Cells("idPartida").Value.ToString, rowGRDLotes.Cells("prod_productoid").Value,
                                  rowGRDLotes.Cells("cantidad").Value, CDate(fechaEntregaPedido.ToString).ToShortDateString, "CLIENTE BLOQUEADO", "ClienteBloqueado", 0, 0,
                                   rowGRDLotes.Cells("pstilo").Value, rowGRDLotes.Cells("talla_tallaid").Value, "", 0, 0)

            ElseIf rowGRDLotes.Cells("capacidad").Value = False Then
                'guardoProgramaRenglonSemanaPedido = False
                objBU.guardarRegistroBItacora(folioActual, rowGRDLotes.Cells("idPedido").Value, rowGRDLotes.Index + 1, rowGRDLotes.Cells("prod_productoid").Value,
                                  rowGRDLotes.Cells("cantidad").Value, CDate(fechaEntregaPedido.ToString).ToShortDateString, "ARTÍCULO SIN CAPACIDAD ASIGNADA", "ArticuloSinCapacidadAsignada", 0, 0,
                                   rowGRDLotes.Cells("pstilo").Value, rowGRDLotes.Cells("talla_tallaid").Value, "", 0, 0)

            End If

        Next

    End Sub

    Public Function ImportarProgramasParcial(ByVal folioNuevo As Int32, ByVal idPedido As Int32,
                                             ByVal idRenglonPartida As Int32, ByVal idProducto As Int32,
                                             ByVal cantidadPares As Int32, ByVal fechaEntrega As Date,
                                             ByVal idPrEstilo As Int32, ByVal idTalla As Int32,
                                             ByVal programadoFila As Int32, ByVal idLote As Int32,
                                             ByVal idCadena As String, ByVal tipo As String,
                                             ByVal producto As String, ByVal idCliente As String,
                                             ByVal semanaPedido As Int32, ByVal capacidadArticulo As String,
                                             ByVal idLinea As Int32, ByVal idNave As Int32,
                                             ByVal indexFila As Int32, ByVal tipoAccion As String,
                                             ByVal idHorma As String, ByVal FechaEntregaPedidoTabla As String,
                                             ByVal entregaCliente As String) As Boolean

        Dim objBU As New Negocios.ProgramasBU
        objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida, idProducto,
                           cantidadPares, fechaEntrega.ToShortDateString, "INICIO DEL PROCESO PARCIAL", "INICIO_INTENTO_PARCIAL", 0, 0,
                              idPrEstilo, idTalla, "", 0, 0)


        If DatePart(DateInterval.WeekOfYear, fechaEntrega) >= DatePart(DateInterval.WeekOfYear, fechaEntregaOpciones) Then


            Dim semanaInicio As Int32 = 0, semanaFin As Int32 = 0
            semanaInicio = DatePart(DateInterval.WeekOfYear, dttInicio.Value)
            semanaFin = DatePart(DateInterval.WeekOfYear, dttFin.Value)

            If semanaInicio = 53 Then
                If DatePart(DateInterval.Month, dttInicio.Value) = 12 Then
                    semanaInicio = 52
                ElseIf DatePart(DateInterval.Month, dttInicio.Value) = 1 Then
                    semanaInicio = 1
                End If
            End If

            If semanaFin = 53 Then
                If DatePart(DateInterval.Month, dttFin.Value) = 12 Then
                    semanaFin = 52
                ElseIf DatePart(DateInterval.Month, dttFin.Value) = 1 Then
                    semanaFin = 1
                End If
            End If

            semanaPedido = DatePart(DateInterval.WeekOfYear, fechaEntrega)
            If semanaPedido = 53 Then
                If DatePart(DateInterval.Month, fechaEntrega) = 12 Then
                    semanaPedido = 52
                ElseIf DatePart(DateInterval.Month, fechaEntrega) = 1 Then
                    semanaPedido = 1
                End If
            End If

            Dim dtCapacidadHorma As New DataTable
            'dtCapacidadHorma = objBU.consultaCapacidadHormaXArticulo(DatePart(DateInterval.Year, fechaEntrega),
            ' semanaInicio, semanaFin,
            ' idPrEstilo, idTalla,
            ' idLinea, idHorma)

            dtCapacidadHorma = objBU.consultaCapacidadHormaXArticulo(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
            semanaInicio, semanaFin,
            idPrEstilo, idTalla,
            idLinea, idHorma)

            If dtCapacidadHorma.Rows.Count > 0 Then

                'Dim dtCapacidadGrupo As New DataTable
                'dtCapacidadGrupo = objBU.consultaCapacidadLineaProduccionGruposXArticulo(DatePart(DateInterval.Year, fechaEntrega), semanaInicio,
                'semanaFin, idLinea)


                'If dtCapacidadGrupo.Rows.Count > 0 Then
                Dim dtCapacidadCelula As New DataTable
                'dtCapacidadCelula = objBU.consultaCapacidadLineaProduccionCelulaXArticulo(DatePart(DateInterval.Year,
                '                                                                                  fechaEntrega), semanaInicio,
                '                                                                               semanaFin,
                '                                                                               idLinea)

                dtCapacidadCelula = objBU.consultaCapacidadLineaProduccionCelulaXArticulo(DatePart(DateInterval.Year, dttInicio.Value), DatePart(DateInterval.Year, dttFin.Value),
                                                                                          semanaInicio,
                                                                                          semanaFin,
                                                                                          idLinea)

                If dtCapacidadCelula.Rows.Count > 0 Then

                    If capacidadArticulo.ToString <> "" Then

                        If capacidadArticulo > 0 Then
                            'If capacidadArticulo >= cantidadPares Then
                            '    Return False
                            'Else

                            Dim programadoActual As Int32 = programadoFila
                            Dim cantidadProgramar As Int32 = cantidadPares - programadoActual
                            Dim programadoRestante As Int32 = cantidadProgramar - capacidadArticulo
                            Dim cantidadParcial As Int32 = 0
                            If cantidadProgramar > capacidadArticulo Then
                                cantidadParcial = capacidadArticulo
                            Else
                                cantidadParcial = cantidadProgramar
                            End If

                            objBU.guardarProgramaRenglonCompleto(idLinea, idProducto, idPrEstilo, idPedido, idRenglonPartida, idLote,
                                                               idTalla, idCadena, cantidadParcial, DatePart(DateInterval.Year, fechaEntrega),
                                                               semanaPedido, idCliente, idNave, idHorma, FechaEntregaPedidoTabla, entregaCliente, tipo)

                            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
               cantidadPares, fechaEntrega.ToShortDateString,
               tipo.ToString.ToUpper + " PROGRAMADO PARCIAL EN LA SEMANA: " + semanaPedido.ToString + " LINEA NAVE: " + idLinea.ToString + ". CANTIDAD " + cantidadParcial.ToString + " PENDIENTE: " + programadoRestante.ToString, "PROGRAMADO_PARCIAL" + programadoRestante.ToString, 0, 0,
                idPrEstilo, idTalla, "", 0, 0)
                            If tipoAccion = "PEDIDOS" Then
                                grdPedidos.Rows(indexFila).Cells("Programado").Value = grdPedidos.Rows(indexFila).Cells("Programado").Value + cantidadParcial
                            ElseIf tipoAccion = "LOTES" Then
                                grdLotes.Rows(indexFila).Cells("Programado").Value = grdLotes.Rows(indexFila).Cells("Programado").Value + cantidadParcial
                            End If

                            Return True
                            'End If
                        Else
                            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
                           cantidadPares, fechaEntrega.ToShortDateString,
                            " se pasa a la otra validacion " + capacidadArticulo.ToString, "Se pasa a la otra validacion", 0, 0,
                            idPrEstilo, idTalla, "", 0, 0)
                            Return False
                        End If
                    Else
                        objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
                     cantidadPares, fechaEntrega.ToShortDateString, "SIN CAPACIDAD EN LA SEMANA DEL PEDIDO (SEMANA : " + semanaPedido.ToString + "): " + producto.ToString + "(ID ESTILO: " + idPrEstilo.ToString + ")", "INFORMACION_CAPACIDAD_VACIA_SEMANA_PEDIDO", 0, 0,
                        idPrEstilo, idTalla, "", 0, 0)
                        Return False
                    End If
                Else
                    objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
                                                              cantidadPares, fechaEntrega.ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE CÉLULA PARA EL ARTÍCULO: " + producto.ToString + "(ID ESTILO: " + idPrEstilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_CELULA", 0, 0,
                                                               idPrEstilo, idTalla, "", 0, 0)
                    Return False
                End If
                'Else
                '    objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
                '         cantidadPares, fechaEntrega.ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE GRUPO PARA EL ARTÍCULO: " + producto.ToString + "(ID ESTILO: " + idPrEstilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_GRUPO", 0, 0,
                '             idPrEstilo, idTalla, "", 0, 0)
                '    Return False
                'End If

            Else
                objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
                       cantidadPares, fechaEntrega.ToShortDateString, "INFORMACIÓN DE CAPACIDAD INCOMPLETA DE HORMA SEMANA: " + semanaPedido.ToString + " --- PARA EL ARTÍCULO: " + producto.ToString + "(ID ESTILO: " + idPrEstilo.ToString + ")", "INFORMACION_INCOMPLETA_ARTICULO_HORMA", 0, 0,
                         idPrEstilo, idTalla, "", 0, 0)
                Return False
            End If
        Else
            objBU.guardarRegistroBItacora(folioNuevo, idPedido, idRenglonPartida.ToString, idProducto,
                        cantidadPares, fechaEntrega.ToShortDateString, "NO SE PROGRAMA POR FECHA DE ENTREGA ATRAZADA. PEDIDO: " + idPedido.ToString, "NoProgramadoFechaPPCP", 0, 0,
                          idPrEstilo, idTalla, "", 0, 0)
            Return False
        End If
        Return False
    End Function

    Private Sub grdBitacora_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdBitacora.InitializeLayout
        grdBitacora.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim exporto As Boolean = False
        If tbtAcciones.SelectedTab.Name = tbtPedido.Name Then
            If grdPedidos.Rows.Count > 0 Then
                exportarExcel()
                exporto = True
            End If
        ElseIf tbtAcciones.SelectedTab.Name = tbtLotes.Name Then
            If grdLotes.Rows.Count > 0 Then
                exportarExcel()
                exporto = True
            End If
        ElseIf tbtAcciones.SelectedTab.Name = tbtBitacora.Name Then
            If grdBitacora.Rows.Count > 0 Then
                exportarExcel()
                exporto = True
            End If
        End If

        If exporto = False Then
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub
End Class