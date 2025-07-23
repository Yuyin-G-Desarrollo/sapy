Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ThreadingLlenarCombos

Imports Stimulsoft.Report
Imports Infragistics.Documents.Excel
Imports DevExpress
Imports DevExpress.DashboardCommon
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Imports Tools
Imports Entidades
Imports Programacion.Negocios
Imports DevExpress.XtraEditors.Popup
Imports Produccion.Negocios
Imports System.Threading.Tasks
Imports System.Threading



Public Class AdministradorResumenCostosForm
    Dim objDC_BU As New AdministradorResumenCostosBU
    Dim objTemp_BU As New TemporadasBU


    Private columnaSeleccionadaValorMasivo As GridColumn


    Private dtNaveDesarrolloOriginal As DataTable
    Private dtTemporadasOriginal As DataTable
    Private dtMarcasOriginal As DataTable
    Private dtColeccionesOriginal As DataTable
    Private dtEstatusProductoOriginal As DataTable
    Private dtConsultaFinalOriginal As New DataTable


    Private navesDesarolloSeleccionadasGlobal As String = ""
    Private marcasSeleccionadasGlobal As String = ""
    Private temporadasSeleccionadasGlobal As String = ""
    Private coleccionesSeleccioandasGlobal As String = ""
    Private estatusProductoSeleccioandosGlobal As String = ""

    Private NaveDesarrolloBloqueada As Boolean = False
    Private EsArticulosClientesEspeciales As Boolean = False



    Private Sub AdministradorResumenCostosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' Agregamos toda modificación de los valores de los controles o manejo de la información de la pantalla que lo llama (variables públicas, etc).
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        Me.CenterToParent() 'Alineación al centro del form padre.
        Me.Text = "Administrador de Resumen de Costos"



        ConsultarPermisos()


        charIndicadoresPorNave.Visible = False
        grdAdminResumenCostos.Visible = False
        grdAdminResumenCostosEspeciales.Visible = False
        pnlVigenciaEspecial.Visible = False

        grdVAdminResumenCostos.OptionsView.ColumnAutoWidth = False
        grdVAdminResumenCostos.OptionsView.BestFitMode = GridBestFitMode.Fast
        grdVAdminResumenCostosEspeciales.OptionsView.ColumnAutoWidth = False
        grdVAdminResumenCostosEspeciales.OptionsView.BestFitMode = GridBestFitMode.Fast
    End Sub
    Private Sub AdministradorResumenCostosForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        '' Bloquea el formulario mientras todos los componentes se renderizan correctamente.
        Me.Enabled = False

        Try
            Cursor = Cursors.WaitCursor

            LlenarCombos()


            '' Si no forzamos su invocación, no terminan funcionando.
            BeginInvoke(Sub()
                            AddHandler slueComboNaveDesarrollo.Closed, AddressOf FiltrarInformacionCombos
                            AddHandler lookUpMarca.Closed, AddressOf FiltrarInformacionCombos
                            AddHandler slueComboTemporada.Closed, AddressOf FiltrarInformacionCombos
                            AddHandler slueComboColeccion.Closed, AddressOf FiltrarInformacionColecciones
                            AddHandler slueComboEstatusProductoCosto.Closed, AddressOf FiltrarInformacionCombos

                            AddHandler grdVAdminResumenCostos.ColumnFilterChanged, AddressOf ActualizarRegistros
                            AddHandler grdVAdminResumenCostosEspeciales.ColumnFilterChanged, AddressOf ActualizarRegistros
                        End Sub)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al llenar los combos: " + ex.Message)
        Finally
            Cursor = Cursors.Default
            Me.Enabled = True   '' La volvemos a habilitar.
            Me.Focus()
            Me.ActiveControl = Nothing ' <- Esto es clave para que ProcessCmdKey funcione desde el inicio. Con esto quitamos el foco de algún control, permitiendo que los atajos funcionen desde el inicio.
        End Try
    End Sub



#Region "BOTONES"

    Private Sub btnAutorizarPrecioSKU_Click(sender As Object, e As EventArgs) Handles btnAutorizarPrecioSKU.Click
        If pnlAutorizarPrecioSKU.Visible = True Then
            Dim gridView = ObtenerTablaActual()
            If gridView IsNot Nothing Then
                GuardarCostosArticulos(ObtenerTablaActual(), ProductoCosto.AUT_NAVE_DESARROLLO)
            End If
        End If
    End Sub

    Private Sub btnModificarPrecioSKU_Click(sender As Object, e As EventArgs) Handles btnModificarPrecioSKU.Click
        If pnlModificarPrecioSKU.Visible = True Then
            Dim gridView = ObtenerTablaActual()
            If gridView IsNot Nothing Then
                GuardarCostosArticulos(ObtenerTablaActual(), ProductoCosto.EN_CAPTURA)
            End If
        End If
    End Sub

    Private Sub btnLiberarSKU_Click(sender As Object, e As EventArgs) Handles btnLiberarSKU.Click
        If pnlLiberarSKU.Visible = True Then
            Dim gridView = ObtenerTablaActual()
            If gridView IsNot Nothing Then
                CambiarEstatusPrecioCosto(gridView, ProductoCosto.LIBERADO_DC)
            End If
        End If
    End Sub

    Private Sub btnRechazarSKU_Click(sender As Object, e As EventArgs) Handles btnRechazarSKU.Click
        If pnlRechazarSKU.Visible = True Then
            Dim gridView = ObtenerTablaActual()
            If gridView IsNot Nothing Then
                CambiarEstatusPrecioCosto(gridView, ProductoCosto.RECHAZADO)
            End If
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub

    Private Sub chkMostrarImagenes_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarImagenes.CheckedChanged
    End Sub


#Region "POPUP MENUS"

    Private Sub btnGenerarFormatoPDF_Click(sender As Object, e As EventArgs) Handles btnGenerarFormatoPDF.Click
        PopupTipoReporte_PDF.ShowPopup(MousePosition)
    End Sub
    Private Sub barbtnFormatoGeneral_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles barbtnFormatoGeneral_PDF.ItemClick
        If grdVAdminResumenCostos.RowCount = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "Es necesario consulta información antes de poder generar los reportes.")
            Exit Sub
        End If

        ExportarPdfFormatoReporteDeCostosProductos()
    End Sub
    Private Sub barbtnFormatoClienteEspecial_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles barbtnFormatoClienteEspecial_PDF.ItemClick
        If grdVAdminResumenCostosEspeciales.RowCount = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "Es necesario consulta información antes de poder generar los reportes.")
            Exit Sub
        End If

        ExportarPdfFormatoReporteDeCostosProductos_Especiales()
    End Sub



    Private Sub btnGenerarFormatoExcel_Click(sender As Object, e As EventArgs) Handles btnGenerarFormatoExcel.Click
        PopupTipoReporte_Excel.ShowPopup(MousePosition)
    End Sub
    Private Sub GenerarFormatoGeneral_Excel(sender As Object, e As XtraBars.ItemClickEventArgs) Handles barbtnFormatoGeneral_Excel.ItemClick
        If grdVAdminResumenCostos.RowCount = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "Es necesario consulta información antes de poder generar los reportes.")
            Exit Sub
        End If

        ExportarExcelFormatoReporteDeCostosProductos()
    End Sub
    Private Sub GenerarFormatoClienteEspecial_Excel(sender As Object, e As XtraBars.ItemClickEventArgs) Handles barbtnFormatoClienteEspecial_Excel.ItemClick
        If grdVAdminResumenCostosEspeciales.RowCount = 0 Then
            Tools.MostrarMensaje(Mensajes.Warning, "Es necesario consulta información antes de poder generar los reportes.")
            Exit Sub
        End If

        ExportarExcelFormatoReporteDeCostosProductos_Especiales()
    End Sub

#End Region


    Private Sub chkSimplificarInformacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkSimplificarInformacion.CheckedChanged
        grdVAdminResumenCostos.Columns("FamiliaProyeccion").Visible = If(chkSimplificarInformacion.Checked, False, True)
        grdVAdminResumenCostosEspeciales.Columns("FamiliaProyeccion").Visible = If(chkSimplificarInformacion.Checked, False, True)

        grdVAdminResumenCostos.Columns("ModeloSICY").Visible = If(chkSimplificarInformacion.Checked, False, True)
        grdVAdminResumenCostosEspeciales.Columns("ModeloSICY").Visible = If(chkSimplificarInformacion.Checked, False, True)

        grdVAdminResumenCostos.Columns("EstatusProducto").Visible = If(chkSimplificarInformacion.Checked, False, True)
        grdVAdminResumenCostosEspeciales.Columns("EstatusProducto").Visible = If(chkSimplificarInformacion.Checked, False, True)

        grdVAdminResumenCostos.Columns("NaveDesarrollo").Visible = If(chkSimplificarInformacion.Checked, False, True)
        grdVAdminResumenCostosEspeciales.Columns("NaveDesarrollo").Visible = If(chkSimplificarInformacion.Checked, False, True)

        grdVAdminResumenCostos.Columns("Temporada").Visible = If(chkSimplificarInformacion.Checked, False, True)
        grdVAdminResumenCostosEspeciales.Columns("Temporada").Visible = If(chkSimplificarInformacion.Checked, False, True)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim gridSeleccionado = ObtenerTablaActual()
        If gridSeleccionado IsNot Nothing Then
            ConsultarSolicitudesPrecioCompra(EsArticulosClientesEspeciales)
        End If

        ConsultarIndicadoresPorNave()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

#End Region



#Region "MÉTODOS"

#Region "CONSULTAS Y LLENADO DE DATOS"

    Private Sub ConsultarPermisos()
        pnlLiberarSKU.Visible = False
        pnlRechazarSKU.Visible = False
        pnlModificarPrecioSKU.Visible = False
        pnlAutorizarPrecioSKU.Visible = False

        slueComboNaveDesarrollo.Enabled = False

        grdVAdminResumenCostos.OptionsBehavior.Editable = False
        grdVAdminResumenCostosEspeciales.OptionsBehavior.Editable = False



        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "CONSULTA_NAVES_POR_GRUPO") Then
            '' Usuario que puede ver todas las naves, pero no editar precios.
            slueComboNaveDesarrollo.Enabled = True
            Exit Sub
        End If



        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "DISEÑO_CONCEPTUAL") Then
            pnlLiberarSKU.Visible = True
            pnlRechazarSKU.Visible = True

            slueComboNaveDesarrollo.Enabled = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "NAVE_DESARROLLO_MODIFICAR") Then
            pnlModificarPrecioSKU.Visible = True

            grdVAdminResumenCostos.OptionsBehavior.Editable = True
            grdVAdminResumenCostosEspeciales.OptionsBehavior.Editable = True

            AddHandler barbtnAplicarValoresMasivos.ItemClick, AddressOf AplicarValorMasivo
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "NAVE_DESARROLLO_AUTORIZAR") Then
            pnlAutorizarPrecioSKU.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "ACCESO_TOTAL") Then
            pnlLiberarSKU.Visible = True
            pnlRechazarSKU.Visible = True
            pnlModificarPrecioSKU.Visible = True
            pnlAutorizarPrecioSKU.Visible = True

            slueComboNaveDesarrollo.Enabled = True

            grdVAdminResumenCostos.OptionsBehavior.Editable = True
            grdVAdminResumenCostosEspeciales.OptionsBehavior.Editable = True

            AddHandler barbtnAplicarValoresMasivos.ItemClick, AddressOf AplicarValorMasivo
        End If
    End Sub

    Private Sub LlenarCombos()
        Dim dtNavesDesarrollo As DataTable
        Dim dtTemporadas As DataTable
        Dim dtMarcas As DataTable
        Dim dtColecciones As DataTable
        Dim dtEstatusProducto As DataTable
        Dim dtNaveLabora As DataTable

        Try

            dtNaveLabora = objDC_BU.ConsultarNaveLabora()

            dtNavesDesarrollo = objDC_BU.ConsultarNavesDesarrollo()
            dtNavesDesarrollo.Columns.Add("Sel")

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "CONSULTA_NAVES_POR_GRUPO") Then
                Dim usuarioGrupo = dtNaveLabora.Rows(0).Item("nave_grupo")

                Dim lstNavesPorUsuario = dtNavesDesarrollo.AsEnumerable().
                   Where(Function(nave) nave("nave_grupo") = usuarioGrupo).
                   ToList()

                If lstNavesPorUsuario.Count > 0 Then
                    dtNaveDesarrolloOriginal = lstNavesPorUsuario.CopyToDataTable()
                Else
                    dtNaveDesarrolloOriginal = dtNavesDesarrollo.Copy()
                End If
            Else
                dtNaveDesarrolloOriginal = dtNavesDesarrollo.Copy()
            End If


            dtMarcas = objDC_BU.ConsultarMarcas()
            dtMarcasOriginal = dtMarcas.Copy()

            dtTemporadas = objTemp_BU.verListaTemporadas("", "", "", True)
            dtTemporadas.Columns.Add("Sel")
            dtTemporadasOriginal = dtTemporadas.Copy()

            dtColecciones = objDC_BU.ConsultarColecciones()
            dtColeccionesOriginal = dtColecciones.Copy() ' Guarda original sin filtro

            dtEstatusProducto = objDC_BU.ConsultarEstatusProductoCosto()



            '' Marcamos los estatus por defecto.
            For Each estatus As DataRow In dtEstatusProducto.Rows
                If estatus.Item("Estatus") <> "SIN SOLICITAR" AndAlso estatus.Item("Estatus") <> "CANCELADO" Then
                    estatus.Item("Sel") = True
                End If
            Next


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "NAVE_DESARROLLO_MODIFICAR") Or Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("APA_ADMIN_RESUMEN_COSTO", "NAVE_DESARROLLO_AUTORIZAR") Then
                '' Seleccionamos la nave del usuario en la que trabaja.
                Dim NaveUsuarioId As Integer = CInt(dtNaveLabora.Rows(0).Item("nave_naveid"))
                For Each fila As DataRow In dtNavesDesarrollo.Rows
                    If CInt(fila("nave_naveid")) = NaveUsuarioId Then
                        fila("Sel") = True
                        dtNaveDesarrolloOriginal = dtNavesDesarrollo.Copy()
                        Exit For
                    End If
                Next
            End If


            slueComboNaveDesarrollo.Properties.DataSource = dtNaveDesarrolloOriginal
            slueComboTemporada.Properties.DataSource = dtTemporadas
            lookUpMarca.Properties.DataSource = dtMarcas
            slueComboColeccion.Properties.DataSource = dtColecciones
            slueComboEstatusProductoCosto.Properties.DataSource = dtEstatusProducto


            FiltrarColecciones(Nothing, Nothing)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al llenar los combos de la pantalla:  " + ex.Message)
        End Try
    End Sub

    Private Async Sub ConsultarSolicitudesPrecioCompra(ByVal EsArticulosClientesEspeciales As Boolean)
        Dim dtResumenPrecioCompraOriginal As New DataTable
        Dim dtResumenPrecioCompraFinal As New DataTable
        Dim lstProductosFiltrados As New List(Of DataRow)
        Dim dtImagenes As Task(Of DataTable) = Nothing



        Try
            Cursor = Cursors.WaitCursor

            If navesDesarolloSeleccionadasGlobal = "" AndAlso marcasSeleccionadasGlobal = "" AndAlso temporadasSeleccionadasGlobal = "" AndAlso coleccionesSeleccioandasGlobal = "" AndAlso estatusProductoSeleccioandosGlobal = "" Then
                Dim formaConfirmacion As New ConfirmarForm
                formaConfirmacion.StartPosition = FormStartPosition.CenterParent
                formaConfirmacion.mensaje = "No ha seleccionado ningún filtro, esto podría aumentar el tiempo de carga ¿Quieres continuar?"

                Dim respuestaUsuario = formaConfirmacion.ShowDialog()

                If respuestaUsuario = Windows.Forms.DialogResult.OK Then
                    dtResumenPrecioCompraOriginal = objDC_BU.ConsultarResumenCostosPorNave("", "", "", "", "", EsArticulosClientesEspeciales)
                Else
                    Exit Sub
                End If
            Else
                dtResumenPrecioCompraOriginal = objDC_BU.ConsultarResumenCostosPorNave(navesDesarolloSeleccionadasGlobal, marcasSeleccionadasGlobal, temporadasSeleccionadasGlobal, coleccionesSeleccioandasGlobal, estatusProductoSeleccioandosGlobal, EsArticulosClientesEspeciales)
            End If



            Dim gridView = ObtenerTablaActual()

            If dtResumenPrecioCompraOriginal Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se ha encontrado información de los SKUS.")

                gridView.GridControl.Visible = False
                Exit Sub
            ElseIf dtResumenPrecioCompraOriginal.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se hah encontrador SKUs en PROTOTIPO con los filtros seleccionados.")

                gridView.GridControl.Visible = False
                Exit Sub
            Else
                dtConsultaFinalOriginal = dtResumenPrecioCompraOriginal.Copy()
                dtResumenPrecioCompraFinal = dtResumenPrecioCompraOriginal.Copy()

                gridView.GridControl.Visible = True
            End If



            Dim ordenado = dtResumenPrecioCompraFinal.AsEnumerable().
                        OrderBy(Function(r) r.Field(Of String)("EstatusProductoCosto")).
                        ThenBy(Function(r) r.Field(Of String)("Marca")).
                        ThenBy(Function(r) r.Field(Of String)("FamiliaProyeccion")).
                        ThenBy(Function(r) r.Field(Of String)("Coleccion")).
                        ThenBy(Function(r) r.Field(Of String)("ModeloSAY")).
                        ThenBy(Function(r) r.Field(Of String)("Piel")).
                        ThenBy(Function(r) r.Field(Of String)("Color")).
                        ThenBy(Function(r) r.Field(Of String)("Talla"))

            If ordenado.Any() Then
                dtResumenPrecioCompraFinal = ordenado.CopyToDataTable()
            End If



            If Not dtResumenPrecioCompraFinal.Columns.Contains("Foto") Then   '' Se agrega la columna si no existe.
                dtResumenPrecioCompraFinal.Columns.Add("Foto", GetType(System.Drawing.Image))
                dtResumenPrecioCompraFinal.Columns("Foto").SetOrdinal(0)
            End If

            If chkMostrarImagenes.Checked Then
                AgregarImagenesDT.cancelarProcesoCargaImagenes = New CancellationTokenSource()
                dtImagenes = AgregarImagenesDT.AgregarImagenesTabla(Me, dtResumenPrecioCompraFinal, "FotoModelo", "Foto", AgregarImagenesDT.cancelarProcesoCargaImagenes.Token)

                dtResumenPrecioCompraFinal = Await dtImagenes
            End If


            If EsArticulosClientesEspeciales = True Then
                grdAdminResumenCostosEspeciales.DataSource = dtResumenPrecioCompraFinal
                FormatoGrid(grdVAdminResumenCostosEspeciales)
            Else
                grdAdminResumenCostos.DataSource = dtResumenPrecioCompraFinal
                FormatoGrid(grdVAdminResumenCostos)
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al consultar los SKUs " + ex.Message)
        Finally
            Cursor = Cursors.Default

            Dim gridView = ObtenerTablaActual()
            If gridView IsNot Nothing Then
                If gridView.RowCount > 0 Then
                    btnArriba_Click(Nothing, Nothing)
                    chkSimplificarInformacion_CheckedChanged(Nothing, Nothing)
                    ObtenerTotalRegistros()
                End If
            End If
        End Try
    End Sub

    Private Sub ConsultarIndicadoresPorNave()
        Dim dtIndicadoresPorNave As DataTable

        Try
            Cursor = Cursors.WaitCursor


            dtIndicadoresPorNave = objDC_BU.ConsultarIndicadoresPorNave(navesDesarolloSeleccionadasGlobal, marcasSeleccionadasGlobal, temporadasSeleccionadasGlobal, coleccionesSeleccioandasGlobal)


            If dtIndicadoresPorNave Is Nothing Then
                'Tools.MostrarMensaje(Mensajes.Warning, "No se ha encontrado información de los SKUS.")
                Exit Sub
            ElseIf dtIndicadoresPorNave.Rows.Count = 0 Then
                'Tools.MostrarMensaje(Mensajes.Warning, "No se ha encontrado información de los SKUS.")
                Exit Sub
            End If



            ' Limpia el chart antes de cargar nueva información
            charIndicadoresPorNave.Visible = True
            charIndicadoresPorNave.Series.Clear()


            Dim listTipoIndicador = dtIndicadoresPorNave.AsEnumerable().
                                    Select(Function(tipo) tipo.Item("TipoIndicador").ToString()).
                                    Distinct()


            For Each indicador In listTipoIndicador

                Dim listNaves = dtIndicadoresPorNave.AsEnumerable().
                        Where(Function(nave) nave.Item("tipoIndicador") = indicador).
                        Select(Function(nave) nave.Item("NaveDesarrollo")).
                        Distinct()


                For Each nave In listNaves

                    Dim listEstatusNave = dtIndicadoresPorNave.AsEnumerable().
                        Where(Function(estatus) estatus.Item("tipoIndicador") = indicador AndAlso   '' Cuando se use como comparador usar item o Field.
                                                estatus.Item("NaveDesarrollo") = nave).
                        Select(Function(estatus) New With {
                                                .NaveDesarrollo = estatus.Field(Of String)("NaveDesarrollo"),
                                                .Estatus = estatus.Field(Of String)("Estatus"),
                                                .TotalArticulos = estatus.Field(Of Integer)("TotalArticulos")   '' Cuando se consulte usar Field.
                                                }).Distinct()


                    Dim serieNaveDesarrollo As New DevExpress.XtraCharts.Series(nave, DevExpress.XtraCharts.ViewType.Doughnut)
                    serieNaveDesarrollo.DataSource = listEstatusNave
                    serieNaveDesarrollo.ArgumentDataMember = "Estatus"
                    serieNaveDesarrollo.ValueDataMembers.AddRange("TotalArticulos")
                    serieNaveDesarrollo.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True
                    serieNaveDesarrollo.Label.TextPattern = " {A} " + Environment.NewLine + " {V} SKUs"
                    serieNaveDesarrollo.Label.DXFont = New System.Drawing.Font("Segoe UI", 10, FontStyle.Regular)


                    '' Configurar las etiquetas con los valores.
                    Dim label As DevExpress.XtraCharts.DoughnutSeriesLabel = CType(serieNaveDesarrollo.Label, DevExpress.XtraCharts.DoughnutSeriesLabel)
                    label.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns
                    label.TextAlignment = StringAlignment.Center


                    '' Configurar el texto central de la gráfica de dona.
                    Dim viewTextoCentralGrafico = CType(serieNaveDesarrollo.View, DevExpress.XtraCharts.DoughnutSeriesView)
                    viewTextoCentralGrafico.TotalLabel.TextPattern = indicador + " - " + nave + Environment.NewLine + "Total: {TV}"
                    viewTextoCentralGrafico.TotalLabel.Font = New System.Drawing.Font("Segoe UI", 12, FontStyle.Bold)
                    viewTextoCentralGrafico.TotalLabel.Visible = True


                    '' Agregamos la nueva serie al gráfico.
                    charIndicadoresPorNave.Series.Add(serieNaveDesarrollo)
                Next
            Next


            '' Ocultamos la leyenda, no la necesitamos ya que explicamos todo en cada serie.
            charIndicadoresPorNave.Legend.Visibility = Utils.DefaultBoolean.False


            '' Actualizamos la información del gráfico por si acaso.
            charIndicadoresPorNave.RefreshData()
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al consultar los indicadores: " + ex.Message)
        Finally
            Cursor = Cursors.Default
            ObtenerTotalRegistros()
        End Try
    End Sub

#End Region


#Region "OBTENER DATOS CONSULTADOS"

    Private Function ObtenerCostosArticulosSeleccionados(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal dtResumenPrecioCompraArticulos As DataTable, ByVal estatusProductoCostoNuevoId As ProductoCosto) As String
        Dim vXmlResumenPrecioCompraArticulos = New XElement("ResumenCostoArticulos")

        Dim articulosOmitidosInfo As New List(Of Integer)
        Dim articulosErroresEstatus As New List(Of Integer)
        Dim articulosRechazados As New List(Of Integer)
        Dim articulosSeleccionados As Integer()

        Try
            If dtResumenPrecioCompraArticulos Is Nothing OrElse dtResumenPrecioCompraArticulos.Rows.Count = 0 Then
                Return ""
            End If

            articulosSeleccionados = gridView.GetSelectedRows()

            If articulosSeleccionados.Count() = 0 Then
                Return ""
            End If



            For Each articuloSeleccionado As Integer In articulosSeleccionados
                Dim precioVentaArticulo As Decimal = gridView.GetRowCellValue(articuloSeleccionado, "PrecioVentaComercializadora")
                Dim productoEstiloId As Integer = gridView.GetRowCellValue(articuloSeleccionado, "ProductoEstiloId")
                Dim naveDesarrolloId As Integer = gridView.GetRowCellValue(articuloSeleccionado, "NaveDesarrolloId")
                Dim estatusProductoCostoActualId As ProductoCosto = gridView.GetRowCellValue(articuloSeleccionado, "EstatusProductoCostoId")

                If precioVentaArticulo > 0 Then
                    Dim costoMaterialDirecto As Decimal = gridView.GetRowCellValue(articuloSeleccionado, "CostoMaterialDirecto")
                    Dim costoOverhead As Decimal = gridView.GetRowCellValue(articuloSeleccionado, "CostoOverhead")
                    Dim clasificacion As String = gridView.GetRowCellValue(articuloSeleccionado, "Clasificacion").ToString()
                    Dim costoFabricacion As Decimal = gridView.GetRowCellValue(articuloSeleccionado, "CostoFabricacion")
                    Dim utilidadPorcentaje As Decimal = gridView.GetRowCellValue(articuloSeleccionado, "UtilidadPorcentaje")
                    Dim utilidadPesos As Decimal = gridView.GetRowCellValue(articuloSeleccionado, "UtilidadPesos")


                    If ValidarArticulo(costoMaterialDirecto, costoOverhead, clasificacion, costoFabricacion, utilidadPorcentaje, utilidadPesos) Then
                        Dim sePuedeActualizar As Boolean = False

                        Select Case estatusProductoCostoActualId
                            Case ProductoCosto.SOLICITADO, ProductoCosto.EN_CAPTURA
                                sePuedeActualizar = True

                            Case ProductoCosto.RECHAZADO
                                If estatusProductoCostoNuevoId = ProductoCosto.EN_CAPTURA Then
                                    sePuedeActualizar = True
                                Else
                                    articulosRechazados.Add(productoEstiloId)
                                End If

                            Case ProductoCosto.AUT_NAVE_DESARROLLO, ProductoCosto.LIBERADO_DC
                                articulosErroresEstatus.Add(productoEstiloId)
                        End Select

                        If sePuedeActualizar Then
                            Dim vNodoPrecioCompra As XElement = New XElement("PrecioCompraArticulo")
                            vNodoPrecioCompra.Add(New XAttribute("ProductoEstiloId", productoEstiloId))
                            vNodoPrecioCompra.Add(New XAttribute("NaveDesarrolloId", naveDesarrolloId))

                            vNodoPrecioCompra.Add(New XAttribute("CostoMaterialDirecto", costoMaterialDirecto))
                            vNodoPrecioCompra.Add(New XAttribute("CostoOverhead", costoOverhead))
                            vNodoPrecioCompra.Add(New XAttribute("Clasificacion", clasificacion))
                            vNodoPrecioCompra.Add(New XAttribute("CostoFabricacion", costoFabricacion))
                            vNodoPrecioCompra.Add(New XAttribute("UtilidadPorcentaje", utilidadPorcentaje))
                            vNodoPrecioCompra.Add(New XAttribute("UtilidadPesos", utilidadPesos))
                            vNodoPrecioCompra.Add(New XAttribute("PrecioVentaComercializadora", precioVentaArticulo))

                            vNodoPrecioCompra.Add(New XAttribute("EstatusProductoCostoActualId", CInt(estatusProductoCostoActualId)))
                            vXmlResumenPrecioCompraArticulos.Add(vNodoPrecioCompra)
                        ElseIf estatusProductoCostoNuevoId = ProductoCosto.EN_CAPTURA AndAlso estatusProductoCostoActualId = ProductoCosto.AUT_NAVE_DESARROLLO Then
                            articulosErroresEstatus.Add(productoEstiloId)
                        End If
                    Else
                        articulosOmitidosInfo.Add(productoEstiloId)
                    End If
                Else
                    articulosOmitidosInfo.Add(productoEstiloId)
                End If
            Next



            If articulosErroresEstatus.Count > 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, CStr(articulosErroresEstatus.Count) + " artículo(s) fueron omitidos porque no se MODIFICAR un artículos ya AUTORIZADO. Solicitar cambio a Diseño Conceptual.")
            End If
            If articulosRechazados.Count > 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, CStr(articulosErroresEstatus.Count) + " artículo(s) fueron omitidos porque no se pueden AUTORIZAR los artículos RECHAZADOS. Primero modificalos antes de volver a intentar.")
            End If
            If articulosOmitidosInfo.Count > 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, CStr(articulosOmitidosInfo.Count) + " artículo(s) fueron omitidos por FALTA DE INFORMACIÓN COSTOS.")
            End If

            If vXmlResumenPrecioCompraArticulos.Elements().Count() = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se pudo guardar ningún artículo. Verifique los campos de COSTOS OBLIGATORIOS.")
                Return ""
            End If



            Return vXmlResumenPrecioCompraArticulos.ToString()
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al consultar la información de los artículos: " + ex.Message)
            Return ""
        End Try
    End Function

    Private Sub ObtenerColecciones(sender As Object, e As EventArgs)
        If dtColeccionesOriginal Is Nothing Then
            Exit Sub
        End If



        Dim dtColecciones As DataTable = CType(slueComboColeccion.Properties.DataSource, DataTable)



        Dim coleccionesSeleccionadas = dtColecciones.AsEnumerable().
                    Where(Function(cole) Not IsDBNull(cole("Sel")) AndAlso CBool(cole("Sel")) = True).
                    Select(Function(cole) New With {
                                                    .Id = cole.Field(Of Integer)("ColeccionId"),
                                                    .Nombre = cole.Field(Of String)("Coleccion")}).
                    ToList()



        If coleccionesSeleccionadas.Count > 1 Then
            txtColeccion.Text = "MÚLTIPLES COLECCIONES"
        ElseIf coleccionesSeleccionadas.Count = 1 Then
            txtColeccion.Text = coleccionesSeleccionadas(0).Nombre
        Else
            txtColeccion.Text = "SELECCIONE UNA COLECCIÓN"
        End If



        coleccionesSeleccioandasGlobal = String.Join(",", coleccionesSeleccionadas.Select(Function(c) c.Id))
    End Sub

    Private Function ObtenerDataTableView(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView) As DataTable
        If gridView IsNot Nothing Then
            Dim dvInformacion As DataView = CType(gridView.DataSource, DataView)  ' Creamos un DataView para acceder a los datos del gridControl
            Dim dtInformacion As DataTable
            dtInformacion = dvInformacion.Table.Copy()

            Return dtInformacion
        Else
            Return Nothing
        End If
    End Function

    Private Function ObtenerTablaActual() As GridView
        If tabCtrlResumenCostos.SelectedTabPage Is tabPageResumenCostosEspeciales Then
            Return grdVAdminResumenCostosEspeciales
        ElseIf tabCtrlResumenCostos.SelectedTabPage Is tabPageResumenCostos Then
            Return grdVAdminResumenCostos
        Else
            Return Nothing
        End If
    End Function

    Private Sub ObtenerTotalRegistros()
        If ObtenerTablaActual() IsNot Nothing Then
            lblTotalRegistros.Text = CStr(ObtenerTablaActual().RowCount)
        Else
            lblTotalRegistros.Text = CStr(charIndicadoresPorNave.Series.Count)
        End If
    End Sub

#End Region


#Region "FILTROS"

    Private Sub FiltrarColecciones(sender As Object, e As EventArgs)
        If dtColeccionesOriginal Is Nothing Then
            Exit Sub
        End If


        Dim dtColeccionesFiltradas As DataTable = dtColeccionesOriginal.Clone() '' Tabla clonada pero sin información.
        Dim dtNaves As DataTable = CType(slueComboNaveDesarrollo.Properties.DataSource, DataTable)
        Dim dtMarcas As DataTable = CType(lookUpMarca.Properties.DataSource, DataTable)
        Dim dtTemporadas As DataTable = CType(slueComboTemporada.Properties.DataSource, DataTable)
        Dim dtEstatusProductoCosto As DataTable = CType(slueComboEstatusProductoCosto.Properties.DataSource, DataTable)



        Dim navesSeleccionadas = dtNaves.AsEnumerable().
                    Where(Function(nave) Not IsDBNull(nave("Sel")) AndAlso CBool(nave("Sel")) = True).
                    Select(Function(nave) New With {
                                                .Id = nave.Field(Of Integer)("nave_naveid"),
                                                .Nombre = nave.Field(Of String)("nave_nombre")}).
                    ToList()

        Dim marcasSeleccionadas = dtMarcas.AsEnumerable().
                    Where(Function(temp) Not IsDBNull(temp("Sel")) AndAlso CBool(temp("Sel")) = True).
                    Select(Function(temp) New With {
                                                .Id = temp.Field(Of Integer)("MarcaId"),
                                                .Nombre = temp.Field(Of String)("MarcaNombre")}).
                    ToList()

        Dim temporadasSeleccionadas = dtTemporadas.AsEnumerable().
                    Where(Function(temp) Not IsDBNull(temp("Sel")) AndAlso CBool(temp("Sel")) = True).
                    Select(Function(temp) New With {
                                                .Id = temp.Field(Of Integer)("temp_temporadaid"),
                                                .Nombre = temp.Field(Of String)("temp_nombre")}).
                    ToList()

        Dim estatusProductoCostoSeleccionados = dtEstatusProductoCosto.AsEnumerable().
                    Where(Function(estatus) Not IsDBNull(estatus("Sel")) AndAlso CBool(estatus("Sel")) = True).
                    Select(Function(estatus) New With {
                                                .Id = estatus.Field(Of Integer)("EstatusId"),
                                                .Nombre = estatus.Field(Of String)("Estatus")}).
                    ToList()



        If navesSeleccionadas.Count > 1 Then
            txtNaveDesarrollo.Text = "MÚLTIPLES NAVES"
        ElseIf navesSeleccionadas.Count = 1 Then
            txtNaveDesarrollo.Text = navesSeleccionadas(0).Nombre
        Else
            txtNaveDesarrollo.Text = "SELECCIONE UNA NAVE"
        End If

        If marcasSeleccionadas.Count > 1 Then
            txtMarca.Text = "MÚLTIPLES MARCAS"
        ElseIf marcasSeleccionadas.Count = 1 Then
            txtMarca.Text = marcasSeleccionadas(0).Nombre
        Else
            txtMarca.Text = "SELECCIONE UNA MARCA"
        End If

        If temporadasSeleccionadas.Count > 1 Then
            txtTemporada.Text = "MÚLTIPLES TEMPORADAS"
        ElseIf temporadasSeleccionadas.Count = 1 Then
            txtTemporada.Text = temporadasSeleccionadas(0).Nombre
        Else
            txtTemporada.Text = "SELECCIONE UNA TEMPORADA"
        End If

        If estatusProductoCostoSeleccionados.Count > 1 Then
            txtEstatusProductoCosto.Text = "MÚLTIPLES ESTATUS"
        ElseIf estatusProductoCostoSeleccionados.Count = 1 Then
            txtEstatusProductoCosto.Text = estatusProductoCostoSeleccionados(0).Nombre
        Else
            txtEstatusProductoCosto.Text = "SELECCIONE UN ESTATUS"
        End If



        Dim idsNaveSeleccionadas = navesSeleccionadas.Select(Function(n) n.Id).ToList()
        Dim idsMarcasSeleccionadas = marcasSeleccionadas.Select(Function(m) m.Id).ToList()
        Dim idsTemporadaSeleccionadas = temporadasSeleccionadas.Select(Function(t) t.Id).ToList()

        Dim coleccionesFiltradas = dtColeccionesOriginal.AsEnumerable().
            Where(Function(cole)
                      Dim coincideNave = (idsNaveSeleccionadas.Count = 0 OrElse idsNaveSeleccionadas.Contains(cole.Field(Of Integer)("NaveDesarrollaId")))
                      Dim coincideMarca = (idsMarcasSeleccionadas.Count = 0 OrElse idsMarcasSeleccionadas.Contains(cole.Field(Of Integer)("MarcaId")))
                      Dim coincideTemporada = (idsTemporadaSeleccionadas.Count = 0 OrElse idsTemporadaSeleccionadas.Contains(cole.Field(Of Integer)("TemporadaId")))
                      Return coincideNave AndAlso coincideMarca AndAlso coincideTemporada
                  End Function)

        dtColeccionesFiltradas = dtColeccionesOriginal.Clone()

        For Each fila In coleccionesFiltradas
            Dim nuevaFila = dtColeccionesFiltradas.NewRow()
            nuevaFila.ItemArray = fila.ItemArray.Clone()

            ' Preserva la selección si existía
            If dtColeccionesOriginal.Columns.Contains("Sel") Then
                nuevaFila("Sel") = fila("Sel")
            End If

            dtColeccionesFiltradas.Rows.Add(nuevaFila)
        Next

        If dtColeccionesFiltradas.Rows.Count > 0 Then
            slueComboColeccion.Properties.DataSource = dtColeccionesFiltradas
        Else
            slueComboColeccion.Properties.DataSource = dtColeccionesOriginal.Clone()
        End If



        ' === Variables globales para consulta posterior ===
        navesDesarolloSeleccionadasGlobal = String.Join(",", navesSeleccionadas.Select(Function(n) n.Id))
        marcasSeleccionadasGlobal = String.Join(",", marcasSeleccionadas.Select(Function(m) m.Id))
        temporadasSeleccionadasGlobal = String.Join(",", temporadasSeleccionadas.Select(Function(t) t.Id))
        estatusProductoSeleccioandosGlobal = String.Join(",", estatusProductoCostoSeleccionados.Select(Function(es) es.Id))
    End Sub

#End Region


#Region "VALIDACIONES"

    Private Function VerificarCarpetaDestinoNave(ByVal RutaSeleccionada As String, ByVal TipoModelos As String, ByVal NombreNave As String, ByVal TipoReporte As String) As String
        Dim rutaCompleta As String = System.IO.Path.Combine(RutaSeleccionada, "REPORTES DE RESUMEN DE COSTOS", TipoModelos, TipoReporte, NombreNave)

        Try
            If Not Directory.Exists(rutaCompleta) Then
                Directory.CreateDirectory(rutaCompleta)
            End If

            Return rutaCompleta
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrió un problema al generar las carpetas de los reportes.")
            Return ""
        End Try
    End Function

    Private Function ValidarInformacionCombos_ReportesGenerales() As Boolean
        Dim formaConfirmacion As New ConfirmarForm

        Dim dtNavesSeleccionadas As DataTable = CType(slueComboNaveDesarrollo.Properties.DataSource, DataTable)
        Dim dtTemporadasSeleccionadas As DataTable = CType(slueComboTemporada.Properties.DataSource, DataTable)
        Dim dtColeccionesSeleccionadas As DataTable = CType(slueComboColeccion.Properties.DataSource, DataTable)


        Try

            Dim navesSeleccionadas = dtNavesSeleccionadas.AsEnumerable().
                                                Where(Function(nave) Not IsDBNull(nave("Sel")) AndAlso CBool(nave("Sel")) = True).
                                                Select(Function(nave) New With {
                                                                                .NaveId = nave.Field(Of Integer)("nave_naveid"),
                                                                                .Nave = nave.Field(Of String)("nave_nombre")
                                                                               }).
                                                ToList()
            Dim temporadasSeleccionadas = dtTemporadasSeleccionadas.AsEnumerable().
                                                Select(Function(nave) New With {
                                                                                .Temporada = nave.Field(Of String)("temp_nombre"),
                                                                                .Vigencia = If(nave.IsNull("temp_vigencia"), "", nave.Field(Of Date)("temp_vigencia").ToString("dd/MM/yyyy"))
                                                                                }).
                                                ToList()
            Dim coleccionesSeleccionadas = dtColeccionesSeleccionadas.AsEnumerable().
                                                Where(Function(cole) Not IsDBNull(cole("Sel")) AndAlso CBool(cole("Sel")) = True).
                                                Select(Function(cole) New With {
                                                                                .Temporada = cole.Field(Of String)("Temporada"),
                                                                                .Coleccion = cole.Field(Of String)("Coleccion"),
                                                                                .NaveDesarrolla = cole.Field(Of String)("NaveDesarrolla")
                                                                                }).
                                                ToList()


            If navesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos una nave para generar el reporte.")
                Return False
                Exit Function
            End If

            If coleccionesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos una colección para generar el reporte.")
                Return False
                Exit Function
            End If

            If coleccionesSeleccionadas.Count > 40 Then
                formaConfirmacion.StartPosition = FormStartPosition.CenterParent
                formaConfirmacion.mensaje = "Se van a generar muchos formatos por las colecciones seleccionadas, ¿Estás seguro?"

                Dim respuestaUsuario = formaConfirmacion.ShowDialog()

                If respuestaUsuario <> Windows.Forms.DialogResult.OK Then
                    Return False
                    Exit Function
                End If
            End If


            Return True
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al validar la información del reporte: " + ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidarInformacionCombos_ReportesEspeciales() As Boolean
        Dim formaConfirmacion As New ConfirmarForm

        Dim dtNavesSeleccionadas As DataTable = CType(slueComboNaveDesarrollo.Properties.DataSource, DataTable)
        Dim dtResumenCostos As DataTable = ObtenerDataTableView(grdVAdminResumenCostosEspeciales)


        Try

            Dim navesSeleccionadas = dtNavesSeleccionadas.AsEnumerable().
                                                Where(Function(nave) Not IsDBNull(nave("Sel")) AndAlso CBool(nave("Sel")) = True).
                                                Select(Function(nave) New With {
                                                                                .NaveId = nave.Field(Of Integer)("nave_naveid"),
                                                                                .Nave = nave.Field(Of String)("nave_nombre")
                                                                               }).
                                                ToList()

            If navesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar una nave para generar el reporte.")
                Return False
                Exit Function
            End If

            If navesSeleccionadas.Count > 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Solo se puede generar un reporte por nave.")
                Return False
                Exit Function
            End If


            Dim clientesSeleccionados = dtResumenCostos.AsEnumerable().
                                                Where(Function(resumen) Not IsDBNull(resumen("Sel")) AndAlso
                                                                        CBool(resumen("Sel")) = True).
                                                Select(Function(resumen) resumen("Cliente")).
                                                Distinct().
                                                ToList()

            If clientesSeleccionados.Count > 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Solo se pueden crear formatos de un solo cliente.")
                Return False
                Exit Function
            End If


            If dtpVigenciaEspecial.Text = "" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debe agregar una vigencia del formato especial.")
                Return False
                Exit Function
            End If


            Return True
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al validar la información del reporte: " + ex.Message)
            Return False
        End Try
    End Function

    Private Function ValidarArticulo(ByVal costoMaterialDirecto As Decimal,
                                        ByVal costoOverhead As Decimal,
                                        ByVal clasificacion As String,
                                        ByVal costoFabricacion As Decimal,
                                        ByVal utilidadPorcentaje As Decimal,
                                        ByVal utilidadPesos As Decimal) As Boolean
        Dim articuloValido As Boolean = False

        If IIf(Not IsDBNull(costoMaterialDirecto) OrElse Not IsNumeric(costoMaterialDirecto), costoMaterialDirecto, 0) > 0 AndAlso
            IIf(Not IsDBNull(costoOverhead) OrElse Not IsNumeric(costoOverhead), costoOverhead, 0) > 0 AndAlso
            IIf(Not IsDBNull(clasificacion) OrElse Not IsNumeric(clasificacion), clasificacion, "") <> "" AndAlso
            IIf(Not IsDBNull(costoFabricacion) OrElse Not IsNumeric(costoFabricacion), costoFabricacion, 0) > 0 AndAlso
            IIf(Not IsDBNull(utilidadPorcentaje) OrElse Not IsNumeric(utilidadPorcentaje), utilidadPorcentaje, 0) > 0 AndAlso
            IIf(Not IsDBNull(utilidadPesos) OrElse Not IsNumeric(utilidadPesos), utilidadPesos, 0) > 0 Then
            articuloValido = True
        End If

        Return articuloValido
    End Function

#End Region



    Private Sub GuardarCostosArticulos(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EstatusProductoId As ProductoCosto)
        Dim formaConfirmacion As New ConfirmarForm
        'Dim dvResumenPrecioCompraArticulos As DataView = CType(gridView.DataSource, DataView)  ' Creamos un DataView para acceder a los datos del gridControl
        Dim dtResumenPrecioCompraArticulos As DataTable = ObtenerDataTableView(gridView)

        Dim articulosSeleccionados As String = ""
        Dim mensajeFinal As String = ""

        Try

            If dtResumenPrecioCompraArticulos Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Es necesario consultar primero la información.")
                Exit Sub
            ElseIf dtResumenPrecioCompraArticulos.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No hay información disponible")
                Exit Sub
            End If



            'dtResumenPrecioCompraArticulos = dvResumenPrecioCompraArticulos.Table.Copy()
            articulosSeleccionados = ObtenerCostosArticulosSeleccionados(gridView, dtResumenPrecioCompraArticulos, EstatusProductoId)


            If articulosSeleccionados = "" Then
                Tools.MostrarMensaje(Mensajes.Warning, "No hay artículos seleccionados.")
                Exit Sub
            End If


            formaConfirmacion.StartPosition = FormStartPosition.CenterParent
            formaConfirmacion.mensaje = "¿Estás seguro de guardar los costos de los artículos?"
            Dim respuestaUsuario = formaConfirmacion.ShowDialog()


            If respuestaUsuario = Windows.Forms.DialogResult.OK Then
                objDC_BU.GuardarCostoArticulos(articulosSeleccionados, EstatusProductoId)

                If EstatusProductoId = ProductoCosto.AUT_NAVE_DESARROLLO Then
                    mensajeFinal = "Los costos de los artículos seleccionados han sido AUTORIZADOS."
                ElseIf EstatusProductoId = ProductoCosto.EN_CAPTURA Then
                    mensajeFinal = "Los costos de los artículo seleccionados fueron MODIFICADOS."
                End If

                Tools.MostrarMensaje(Mensajes.Success, mensajeFinal)


                btnMostrar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al guardar los costos: " + ex.Message)
        End Try
    End Sub

    Private Sub CambiarEstatusPrecioCosto(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal EstatusProductoId As ProductoCosto)
        Dim formaConfirmacion As New ConfirmarForm
        Dim dvResumenPrecioCompraArticulos As DataView = CType(gridView.DataSource, DataView)  ' Creamos un DataView para acceder a los datos del gridControl
        Dim dtResumenPrecioCompraArticulos As DataTable

        Dim articulosSeleccionados As Integer()
        Dim productosEstilosConcatenados As String = ""
        Dim mensajeFinal As String = ""

        Try

            If dvResumenPrecioCompraArticulos Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Es necesario consultar primero la información.")
                Exit Sub
            ElseIf dvResumenPrecioCompraArticulos.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No hay información disponible")
                Exit Sub
            End If



            dtResumenPrecioCompraArticulos = dvResumenPrecioCompraArticulos.Table.Copy()

            articulosSeleccionados = gridView.GetSelectedRows()
            If articulosSeleccionados.Count() = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No hay artículos seleccionados.")
                Exit Sub
            End If

            Dim lstProductosEstilosAutorizado = dtResumenPrecioCompraArticulos.AsEnumerable().
                    Where(Function(nave) (Not IsDBNull(nave("Sel")) AndAlso CBool(nave("Sel")) = True) AndAlso (CInt(nave("EstatusProductoCostoId")) = ProductoCosto.AUT_NAVE_DESARROLLO)).
                    Select(Function(nave) nave.Field(Of Integer)("ProductoEstiloId")).
                    ToList()



            If lstProductosEstilosAutorizado.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Solo puedes LIBERAR o RECHAZAR artículos que estén autorizados.")
                Exit Sub
            ElseIf articulosSeleccionados.Count > lstProductosEstilosAutorizado.Count Then
                Dim articulosFaltantes As Integer = (articulosSeleccionados.Count - lstProductosEstilosAutorizado.Count)
                Tools.MostrarMensaje(Mensajes.Notice, CStr(articulosFaltantes) + " artículo(s) fueron omitidos por NO estar AUTORIZADOS.")
            End If



            productosEstilosConcatenados = String.Join(",", lstProductosEstilosAutorizado)

            If EstatusProductoId = ProductoCosto.LIBERADO_DC Then
                mensajeFinal = "¿Estas seguro de LIBERAR los artículos seleccionados?"
            Else EstatusProductoId = ProductoCosto.RECHAZADO
                mensajeFinal = "¿Estás seguro de CANCELAR los artículos seleccionados?"
            End If



            formaConfirmacion.StartPosition = FormStartPosition.CenterParent
            formaConfirmacion.mensaje = mensajeFinal
            Dim respuestaUsuario = formaConfirmacion.ShowDialog()

            If respuestaUsuario = Windows.Forms.DialogResult.OK Then
                objDC_BU.CambiarEstatusPrecioCosto(productosEstilosConcatenados, EstatusProductoId)

                If EstatusProductoId = ProductoCosto.LIBERADO_DC Then
                    mensajeFinal = "Los costos de los artículos seleccionados han sido LIBERADOS."
                Else EstatusProductoId = ProductoCosto.RECHAZADO
                    mensajeFinal = "Los costos de los artículo seleccionados fueron CANCELADOS."
                End If

                Tools.MostrarMensaje(Mensajes.Success, mensajeFinal)


                btnMostrar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al guardar los costos: " + ex.Message)
        End Try
    End Sub

    Private Sub AplicarValorMasivo(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim nombreColumna As String = columnaSeleccionadaValorMasivo.FieldName


        Try
            '' ========== Columnas editables a valores masivos ========== ''
            If Not {"CostoMaterialDirecto", "CostoOverhead", "Clasificacion", "UtilidadPorcentaje"}.Contains(nombreColumna) Then
                Exit Sub
            End If



            'Dim nuevoValor As String = InputBox("Introduce el nuevo valor para la columna '" & columnaSeleccionadaValorMasivo.Caption & "'", "Valor masivo")
            Dim formNuevoValor As New TextDialogForm
            formNuevoValor.mensaje = "Introduce el nuevo valor para la columna" + vbCrLf + columnaSeleccionadaValorMasivo.Caption
            formNuevoValor.ShowDialog()

            Dim nuevoValor = formNuevoValor.txtParam.Text



            If String.IsNullOrWhiteSpace(nuevoValor) Then
                Tools.MostrarMensaje(Mensajes.Warning, "No ha introducido un valor válido.")
                Exit Sub
            End If



            ' Validaciones por tipo de columna
            Select Case nombreColumna
                Case "CostoMaterialDirecto"
                    Dim valorDecimal As Decimal
                    If Not Decimal.TryParse(nuevoValor, valorDecimal) OrElse valorDecimal < 0 Then
                        Tools.MostrarMensaje(Mensajes.Warning, "Debe ingresar un número válido mayor o igual a 0.")
                        Exit Sub
                    End If
                    nuevoValor = Math.Round(valorDecimal, 2)

                Case "CostoOverhead"
                    Dim valorDecimal As Decimal
                    If Not Decimal.TryParse(nuevoValor, valorDecimal) OrElse valorDecimal < 0 Then
                        Tools.MostrarMensaje(Mensajes.Warning, "Debe ingresar un número válido mayor o igual a 0.")
                        Exit Sub
                    End If
                    nuevoValor = Math.Round(valorDecimal, 2)

                Case "Clasificacion"
                    nuevoValor = nuevoValor.Trim().ToUpper()
                    If nuevoValor.Length <> 1 OrElse Not {"A"c, "B"c, "C"c}.Contains(nuevoValor(0)) Then
                        Tools.MostrarMensaje(Mensajes.Warning, "Solo se permite un carácter: A, B o C.")
                        Exit Sub
                    End If

                Case "UtilidadPorcentaje"
                    Dim valorDecimal As Decimal
                    If Not Decimal.TryParse(nuevoValor, valorDecimal) OrElse valorDecimal < 0 Then
                        Tools.MostrarMensaje(Mensajes.Warning, "Debe ingresar un número válido mayor o igual a 0.")
                        Exit Sub
                    End If
                    nuevoValor = Math.Round(valorDecimal, 2)
            End Select



            ' Aplicar el nuevo valor a las filas seleccionadas
            Dim gridView = ObtenerTablaActual()
            For Each fila In gridView.GetSelectedRows()
                If gridView.IsDataRow(fila) Then
                    gridView.SetRowCellValue(fila, columnaSeleccionadaValorMasivo, nuevoValor)
                End If
            Next



            Tools.MostrarMensaje(Mensajes.Success, "Valor aplicado correctamente a las filas seleccionadas.")
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al aplicar el valor masivo: " + ex.Message)
        End Try
    End Sub



#Region "FORMATO TABLA GRID VIEW"

    Private Sub FormatoGrid(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        DiseñoGrid.AlinearTextoEncabezadoColumnas(gridView)
        DiseñoGrid.AlternarColorEnFilasTenue(gridView)



        'gridView.ColumnPanelRowHeight = 20
        If chkMostrarImagenes.Checked Then
            gridView.RowHeight = 60
        Else
            gridView.RowHeight = 40
        End If

        gridView.IndicatorWidth = 30
        gridView.OptionsView.RowAutoHeight = False
        gridView.OptionsView.ShowAutoFilterRow = True '' Mostramos el filtro de las columnas (las filas). ''



        DiseñoGrid.EstiloColumna(gridView, "Sel", "Sel", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 40, False, Nothing, "")
        If gridView.Columns.ColumnByFieldName("Foto") IsNot Nothing Then
            DiseñoGrid.EstiloColumna(gridView, "Foto", "FOTO", chkMostrarImagenes.Checked, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        End If
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "FotoModelo", "RUTA", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Marca", "MARCA", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "FamiliaProyeccion", "FAMILIA PROYECCION", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")

        If gridView.Columns.ColumnByFieldName("Cliente") IsNot Nothing Then
            DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Cliente", "CLIENTE", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 150, False, Nothing, "")
        End If

        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "ColeccionId", "COLECCION ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Coleccion", "COLECCION", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "ModeloSAY", "MODELO SAY", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "ModeloSICY", "MODELO SICY", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Piel", "PIEL", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Color", "COLOR", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 120, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Talla", "TALLA", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "ProductoEstiloId", "PRODUCTO ESTILO ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "EstatusProductoId", "ESTATUS PRODUCTO ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "NaveDesarrolloId", "NAVE DESARROLLO ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "NaveDesarrollo", "NAVE DESARROLLO", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "TemporadaId", "TEMPORADA ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Temporada", "TEMPORADA", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")

        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "CostoMaterialDirecto", "COSTO MATERIAL DIRECTO", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "${0:N2}")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "CostoOverhead", "COSTO OVERHEAD", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "${0:N2}")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Clasificacion", "CLASIFICACIÓN", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "CostoFabricacion", "COSTO FABRICACIÓN", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "${0:N2}")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "UtilidadPorcentaje", "% UTILIDAD", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "{0:N0}%")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "UtilidadPesos", "$ UTILIDAD", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "${0:N2}")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "PrecioVentaComercializadora", "PRECIO DE VENTA A COMERCIALIZADORA", True, XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "${0:N2}")

        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "EstatusProductoId", "ESTATUS PRODUCTO ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "EstatusProducto", "PRODUCTO", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "EstatusProductoCostoId", "ESTATUS PRODUCTO COMPRA ID", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "EstatusProductoCosto", "PRODUCTO COMPRA", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")

        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "Observaciones", "OBSERVACIONES", False, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")

        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "UsuarioSolicita", "USUARIO SOLICITÓ", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "FechaSolicita", "FECHA SOLICITÓ", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "UsuarioAutoriza", "USUARIO AUTORIZÓ", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "FechaAutoriza", "FECHA AUTORIZACIÓN", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "UsuarioRechaza", "USUARIO RECHAZÓ", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "FechaRechaza", "FECHA RECHAZÓ", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "UsuarioLibera", "USUARIO LIBERÓ", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")
        DiseñoGrid.EstiloColumnaSinBestFit(gridView, "FechaLibera", "FECHA LIBERACIÓN", True, XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "")

        AgregarFormatoPorcentaje(gridView, {"UtilidadPorcentaje"})
        AgregarFormatoPrecios(gridView, {"CostoMaterialDirecto", "CostoOverhead", "CostoFabricacion", "UtilidadPesos", "PrecioVentaComercializadora"})
        AgregarSaltoLineaColumnas(gridView, {"FamiliaProyeccion", "Coleccion", "Piel", "Color", "Temporada", "EstatusProducto", "EstatusProductoCosto", "FechaSolicita", "FechaAutoriza"})
        If gridView.Columns.ColumnByFieldName("Cliente") IsNot Nothing Then
            AgregarSaltoLineaColumnas(gridView, {"Cliente"})
        End If
        AgregarFormatoClasificacion(gridView, {"Clasificacion"})

        '''''''' -------------------------------------------------------- Configuración de Filtros -------------------------------------------------------- ''
        ''''''gridView.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText
        ''''''gridView.OptionsFilter.ShowAllTableValuesInFilterPopup = True
        ''''''gridView.OptionsCustomization.AllowFilter = True
        ''''''gridView.OptionsView.ShowAutoFilterRow = True '' Mostramos el filtro de las columnas (las filas). ''
        ''''''gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        ''''''gridView.OptionsView.ShowFooter = True
        '''''''' -------------------------------------------------------- Configuración de Filtros -------------------------------------------------------- ''
    End Sub

    Private Sub AgregarFormatoPorcentaje(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, columnas() As String)
        Dim textEdit As New RepositoryItemTextEdit()
        textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        textEdit.Mask.UseMaskAsDisplayFormat = False
        textEdit.Mask.EditMask = "n2"   '' Formato en decimales.
        textEdit.MaxLength = 5

        gridView.GridControl.RepositoryItems.Add(textEdit)

        For Each columnaNombre As String In columnas
            Dim columna As GridColumn = gridView.Columns(columnaNombre)
            columna.ColumnEdit = textEdit

            columna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            columna.DisplayFormat.FormatString = "{0:N2}%"  '' Formato en porcentajes.

            columna.AppearanceCell.Options.UseTextOptions = True
            columna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
    End Sub
    Private Sub AgregarFormatoPrecios(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, columnas() As String)
        Dim textEdit As New RepositoryItemTextEdit()
        textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        textEdit.Mask.UseMaskAsDisplayFormat = False
        textEdit.Mask.EditMask = "n2"   '' Formato en decimales.
        textEdit.MaxLength = 7

        gridView.GridControl.RepositoryItems.Add(textEdit)

        For Each columnaNombre As String In columnas
            Dim columna As GridColumn = gridView.Columns(columnaNombre)
            columna.ColumnEdit = textEdit

            columna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            columna.DisplayFormat.FormatString = "${0:N2}"  '' Formato en dineros.

            columna.AppearanceCell.Options.UseTextOptions = True
            columna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
    End Sub
    Private Sub AgregarFormatoClasificacion(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, columnas() As String)
        Dim textEdit As New RepositoryItemTextEdit()
        textEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx
        textEdit.Mask.UseMaskAsDisplayFormat = False
        textEdit.Mask.EditMask = "[ABC]"   '' Solo las tres clasificaciones cargadas en el sistema.
        textEdit.MaxLength = 1

        gridView.GridControl.RepositoryItems.Add(textEdit)

        For Each columnaNombre As String In columnas
            Dim columna As GridColumn = gridView.Columns(columnaNombre)
            columna.ColumnEdit = textEdit

            'columna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'columna.DisplayFormat.FormatString = ""  '' Formato en dineros.

            columna.AppearanceCell.Options.UseTextOptions = True
            columna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
    End Sub
    Private Sub AgregarSaltoLineaColumnas(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView, columnas() As String)
        Dim memoEdit As New RepositoryItemMemoEdit()
        memoEdit.WordWrap = True
        memoEdit.CharacterCasing = CharacterCasing.Upper
        memoEdit.MaxLength = 140 '' El tamaño de la BD es de 300. Se eligen 140 caracteres para que en lso reportes no se solape la información.

        gridView.GridControl.RepositoryItems.Add(memoEdit)

        For Each columnaNombre As String In columnas
            Dim columna As GridColumn = gridView.Columns(columnaNombre)
            columna.ColumnEdit = memoEdit

            columna.AppearanceCell.Options.UseTextOptions = True
            columna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            columna.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
    End Sub

#End Region


#Region "FORMATOS"
    Private Async Sub ExportarExcelFormatoReporteDeCostosProductos()
        Dim tamañoColumnas As New List(Of Integer)
        Dim formatoColumnas As New List(Of String)

        Dim formaConfirmacion As New ConfirmarForm
        Dim sfd As New SaveFileDialog 'Creamos variable para guardar la ruta de nuestro archivo

        Dim formatoFechaLarga As String = Date.Now.ToString("dd.MM.yyyy hh.mm")
        Dim formatoFecha As String = Date.Now.ToString("dd.MM.yyyy")
        Dim formatoFechaNormal As String = Date.Now.ToString("dd/MM/yyyy")
        Dim nombreArchivo As String = ""
        Dim reportesGenerados As Integer = 0



        Try
            Dim dtReporteModelosPorColeccionesModelos As DataTable
            Dim dtNavesSeleccionadas As DataTable = CType(slueComboNaveDesarrollo.Properties.DataSource, DataTable)
            Dim dtTemporadasSeleccionadas As DataTable = CType(slueComboTemporada.Properties.DataSource, DataTable)
            Dim dtColeccionesSeleccionadas As DataTable = CType(slueComboColeccion.Properties.DataSource, DataTable)

            Dim navesSeleccionadas = dtNavesSeleccionadas.AsEnumerable().
                                                Where(Function(nave) Not IsDBNull(nave("Sel")) AndAlso CBool(nave("Sel")) = True).
                                                Select(Function(nave) New With {
                                                                                .NaveId = nave.Field(Of Integer)("nave_naveid"),
                                                                                .Nave = nave.Field(Of String)("nave_nombre")
                                                                               }).
                                                ToList()
            Dim temporadasSeleccionadas = dtTemporadasSeleccionadas.AsEnumerable().
                                                Select(Function(nave) New With {
                                                                                .Temporada = nave.Field(Of String)("temp_nombre"),
                                                                                .Vigencia = If(nave.IsNull("temp_vigencia"), "", nave.Field(Of Date)("temp_vigencia").ToString("dd/MM/yyyy"))
                                                                                }).
                                                ToList()
            Dim coleccionesSeleccionadas = dtColeccionesSeleccionadas.AsEnumerable().
                                                Where(Function(cole) Not IsDBNull(cole("Sel")) AndAlso CBool(cole("Sel")) = True).
                                                Select(Function(cole) New With {
                                                                                .Temporada = cole.Field(Of String)("Temporada"),
                                                                                .Coleccion = cole.Field(Of String)("Coleccion"),
                                                                                .NaveDesarrolla = cole.Field(Of String)("NaveDesarrolla")
                                                                                }).
                                                ToList()

            If navesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos una nave para generar el reporte.")
                Exit Sub
            End If

            If coleccionesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos una colección para generar el reporte.")
                Exit Sub
            End If

            If coleccionesSeleccionadas.Count > 40 Then
                formaConfirmacion.StartPosition = FormStartPosition.CenterParent
                formaConfirmacion.mensaje = "Se van a generar muchos formatos por las colecciones seleccionadas, ¿Estás seguro?"

                Dim respuestaUsuario = formaConfirmacion.ShowDialog()

                If respuestaUsuario <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
            End If

            nombreArchivo = "RESUMEN DE COSTOS DE ARTICULOS"

            sfd.DefaultExt = "xlsx" 'Asignamos el formato de salida por defecto
            sfd.Filter = "Archivos EXCEL|*.xlsx" 'Asignamos al cuadro que nos muestre los otros formatos disponibles para guardar
            sfd.FileName = nombreArchivo


            Dim resultado As DialogResult = sfd.ShowDialog(Me) 'Guardamos el resultado de lo que haga el usuario al buscar una ubicacion
            ''Dim rutaArchivo As String = IO.Path.GetDirectoryName(sfd.FileName) 'Guardamos el nombre que eligió el usuario

            If resultado <> System.Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If



            Cursor = Cursors.WaitCursor






            '' ================================================== CONSULTA DE LA INFORMACIÓN DEL REPORTE ================================================== ''

            Dim dtImagenes As Task(Of DataTable) = Nothing
            'Dim dtReporteModelosPorColeccionesModelos As DataTable
            'Dim dtTemporadasSeleccionadas As DataTable = CType(slueComboTemporada.Properties.DataSource, DataTable)


            dtReporteModelosPorColeccionesModelos = objDC_BU.ConsultarReporteModelosPorColecciones_Modelos(navesDesarolloSeleccionadasGlobal, temporadasSeleccionadasGlobal, coleccionesSeleccioandasGlobal, estatusProductoSeleccioandosGlobal)


            If Not dtReporteModelosPorColeccionesModelos.Columns.Contains("Foto") Then   '' Se agrega la columna si no existe.
                dtReporteModelosPorColeccionesModelos.Columns.Add("Foto", GetType(System.Drawing.Image))
                dtReporteModelosPorColeccionesModelos.Columns("Foto").SetOrdinal(0)
            End If


            AgregarImagenesDT.cancelarProcesoCargaImagenes = New CancellationTokenSource()
            dtImagenes = AgregarImagenesDT.AgregarImagenesTabla(Me, dtReporteModelosPorColeccionesModelos, "FotoModelo", "Foto", AgregarImagenesDT.cancelarProcesoCargaImagenes.Token)
            dtReporteModelosPorColeccionesModelos = Await dtImagenes
            dtReporteModelosPorColeccionesModelos.Columns.Remove("FotoModelo")

            '' ================================================== CONSULTA DE LA INFORMACIÓN DEL REPORTE ================================================== ''



            Dim reporteColeccionesPorColeccion = dtReporteModelosPorColeccionesModelos.AsEnumerable().
                                                        GroupBy(Function(row) row.Field(Of Integer)("NumColeccion"))



            For Each coleccion In reporteColeccionesPorColeccion
                Dim reporteExcel As New ReportesExcel
                Dim archivoExcel As New Infragistics.Documents.Excel.Workbook
                Dim hojaExcel As Worksheet
                Dim dtColeccion As DataTable

                Dim numColeccionActual = coleccion.Key

                Dim dtReportePorModelos_Modelos As DataTable
                Dim primeraFilaReporte As DataRow

                Dim cliente As String = ""
                Dim fechaLiberacion As String = ""
                Dim vigenciaTemporada As String = ""
                Dim naveActual As String = ""


                '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''

                dtReportePorModelos_Modelos = coleccion.CopyToDataTable()
                primeraFilaReporte = coleccion.First()


                Dim marcaActual = primeraFilaReporte.Field(Of String)("Marca").Trim.ToUpper
                Dim coleccionActual = primeraFilaReporte.Field(Of String)("Coleccion").Trim.ToUpper
                Dim temporadaActual = primeraFilaReporte.Field(Of String)("Temporada").Trim.ToUpper


                '' ========== INFORMACIÓN ENCABEZADO ========== ''
                naveActual = primeraFilaReporte.Field(Of String)("NaveDesarrollo").Trim.ToUpper
                cliente = primeraFilaReporte.Field(Of String)("Cliente").Trim.ToUpper
                fechaLiberacion = primeraFilaReporte.Field(Of String)("FechaLiberacion").Trim.ToUpper

                Dim fechaVigenciaTemporada As DateTime
                Dim vigenciaTemporadaSeleccionada = temporadasSeleccionadas.AsEnumerable.
                                                            Where(Function(temp) temp.Temporada.Trim.ToUpper = temporadaActual.Trim.ToUpper).
                                                            Select(Function(temp) temp.Vigencia).FirstOrDefault()

                If DateTime.TryParse(vigenciaTemporadaSeleccionada.ToString(), fechaVigenciaTemporada) Then
                    vigenciaTemporada = fechaVigenciaTemporada.ToString("dd MMMM, yyyy").Trim.ToUpper
                Else
                    vigenciaTemporada = "SIN FECHA"
                End If
                '' ========== INFORMACIÓN ENCABEZADO ========== ''


                Dim rutaArchivo = VerificarCarpetaDestinoNave(System.IO.Path.GetDirectoryName(sfd.FileName), "GENERALES", naveActual, "EXCEL")

                nombreArchivo = "RESUMEN DE COSTOS DE ARTICULOS (" + cliente + ") - " + naveActual + " " + marcaActual + " " + coleccionActual + " " + formatoFecha   ''formatoFechaLarga

                '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''



                Dim tallasPorColecciones = coleccion.AsEnumerable().GroupBy(Function(row) row.Field(Of Integer)("NumTalla"))



                For Each tallaPorHoja In tallasPorColecciones
                    dtColeccion = New DataTable


                    Dim registros As List(Of DataRow) = tallaPorHoja.ToList()
                    Dim bloques As Integer = Math.Ceiling(registros.Count / 20.0)   '' Total de bloques de 20 registros para cada hoja.


                    For reporte As Integer = 0 To bloques - 1
                        Dim nombreCorridaOriginal As String = ""
                        Dim nombreCorrida As String = ""
                        Dim contadorVisible As Integer = 1


                        nombreCorridaOriginal = tallaPorHoja.AsEnumerable().Select(Function(cor) cor.Field(Of String)("Talla")).First()
                        If reporte = 0 Then
                            nombreCorrida = nombreCorridaOriginal
                        Else
                            nombreCorrida = nombreCorridaOriginal + " (" + CStr(reporte) + ")"
                        End If


                        dtColeccion = registros.Skip(reporte * 20).Take(20).CopyToDataTable()


                        dtColeccion.Columns.Remove("NumColeccion")
                        dtColeccion.Columns.Remove("NumTalla")
                        dtColeccion.Columns.Remove("NumModelo")
                        dtColeccion.Columns.Remove("Cliente")
                        dtColeccion.Columns.Remove("Marca")
                        dtColeccion.Columns.Remove("FamiliaProyeccion")
                        dtColeccion.Columns.Remove("ModeloSICY")
                        dtColeccion.Columns.Remove("NaveDesarrollo")
                        dtColeccion.Columns.Remove("Temporada")
                        dtColeccion.Columns.Remove("FechaLiberacion")

                        dtColeccion.Columns.Add("No", GetType(Integer))
                        dtColeccion.Columns("No").SetOrdinal(0)


                        For seccion As Integer = 0 To dtColeccion.Rows.Count - 1
                            dtColeccion.Rows(seccion)("No") = contadorVisible

                            If contadorVisible = 4 Then
                                contadorVisible = 1
                            Else
                                contadorVisible += 1
                            End If
                        Next


                        Dim configInicial As New ConfiguracionArchivoExcel With {
                                                                .ExtensionArchivo = ExtensionArchivoExcel.XLSX,
                                                                .NombreArchivo = nombreArchivo,
                                                                .RutaArchivo = rutaArchivo + "\",
                                                                .ArchivoExcel = archivoExcel
                                                            }

                        tamañoColumnas = New List(Of Integer) From {
                                                                          10,     '' ESPACIO (10 px)
                                                                          30,     '' NO.
                                                                          140,    '' FOTO
                                                                          150,    '' COLECCIÓN
                                                                          80,     '' MODELO
                                                                          120,    '' PIEL
                                                                          100,    '' COLOR
                                                                          90,     '' CORRIDA
                                                                          100,    '' MATERIAL DIRECTO
                                                                          110,    '' OVERHEAD
                                                                          110,    '' CLASIFICACION
                                                                          110,    '' COSTO FABRICACIÓN
                                                                          100,    '' UTILIDAD %
                                                                          100,    '' UTILIDAD $
                                                                          110,    '' PRECIO VENTA COMERCIALIZADORA
                                                                          120,    '' PRECIO BASE
                                                                          10      '' ESPACIO
                                                                   }

                        formatoColumnas = New List(Of String) From {
                                                                    "vacio",        '' ESPACIO (10 px)
                                                                    "numero",       '' NO.
                                                                    "foto",         '' FOTO
                                                                    "texto",        '' COLECCIÓN
                                                                    "alfanumerico", '' MODELO
                                                                    "texto",        '' PIEL
                                                                    "texto",        '' COLOR
                                                                    "corrida",      '' CORRIDA
                                                                    "dinero",       '' MATERIAL DIRECTO
                                                                    "dinero",       '' OVERHEAD
                                                                    "caracter",     '' CLASIFICACION
                                                                    "dinero",       '' COSTO FABRICACIÓN
                                                                    "porcentaje",   '' UTILIDAD %
                                                                    "dinero",       '' UTILIDAD $
                                                                    "dinero",       '' PRECIO VENTA COMERCIALIZADORA
                                                                    "vacio",       '' PRECIO BASE
                                                                    "vacio"         '' ESPACIO
                                                                   }

                        Dim configInfoReporte As New ConfiguracionInformacionReporte With {
                                                                .InformacionReporte = dtColeccion,
                                                                .TamañoColumnas = tamañoColumnas,
                                                                .MostrarTotalGeneral = False
                                                            }

                        Dim configHojaExcel As New ConfiguracionHojaExcel With {
                                                                .NombreHoja = nombreCorrida,
                                                                .OcultarCuadricula = True,
                                                                .FijarFila = True,
                                                                .NumeroFilaFija = 9,
                                                                .HojaExcel = hojaExcel,
                                                                .FormatoColumnas = formatoColumnas,
                                                                .Zoom = 80
                                                            }

                        Dim configEncabezado As New ConfiguracionEncabezado With {
                                                                .NombreArea = "F-DC-0922",
                                                                .NombreReporte = "RESUMEN DE COSTOS DE NUEVOS ARTÍCULOS",
                                                                .NombreVersionDocumento = "",
                                                                .NombreResponsable = "Responsable: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername,
                                                                .Mes = CStr(formatoFechaNormal)
                                                            }

                        Dim configSubEncabezados As New ConfiguracionSubEncabezados With {
                                                                .Campo1 = cliente,              '' CLIENTE
                                                                .Campo2 = fechaLiberacion,      '' FECHA DE LIBERACIÓN
                                                                .Campo3 = vigenciaTemporada,    '' VIGENCIA
                                                                .Campo4 = naveActual            '' NAVE DESARROLLO
                                                            }

                        Dim configImpresion As New ConfiguracionImpresion With {
                                                                .TamañoHoja = TamañoHojaImpresion.Carta,
                                                                .OrientacionHoja = OrientacionHoja.Vertical,
                                                                .AjustarMargenesImpresion = True,
                                                                .AjustarContenidoAUnaHoja = True,
                                                                .ModificarAreaImpresion = False,
                                                                .AreaImpresion = "",
                                                                .PreguntarAbrirArchivo = False
                                                            }


                        reporteExcel.GenerarReporteDeCostosProductos(configInfoReporte, configInicial, configHojaExcel, configEncabezado, configSubEncabezados, configImpresion)
                        reportesGenerados += 1


                        '' Limpiamos los recursos usados para la generación del archivo de Excel.
                        GC.Collect()
                        GC.WaitForPendingFinalizers()
                    Next
                Next
            Next



            If reportesGenerados = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No se han generado reportes al no encontrar información de las naves y colecciones indicadas.")
            Else
                Tools.MostrarMensaje(Mensajes.Success, "Los reportes fueron generados de forma exitosa.")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al generar el reporte." + ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Async Sub ExportarExcelFormatoReporteDeCostosProductos_Especiales()
        Dim gridView As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim dtReporteModelosPorColeccionesEspeciales As New DataTable

        Dim tamañoColumnas As New List(Of Integer)
        Dim formatoColumnas As New List(Of String)

        Dim formaConfirmacion As New ConfirmarForm
        Dim sfd As New SaveFileDialog 'Creamos variable para guardar la ruta de nuestro archivo



        Try

            '' ======================================== VALIDACIONES INICIALES ======================================== ''

            gridView = ObtenerTablaActual()

            If gridView Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debe estar en una pantalla de Resumen de Costos para poder exportar reportes.")
                Exit Sub
            End If

            If ValidarInformacionCombos_ReportesEspeciales() = False Then
                Exit Sub
            End If


            Dim modelosEspecialesSeleccionados = gridView.GetSelectedRows()

            If modelosEspecialesSeleccionados.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No ha seleccionado ningún modelo para generar el reporte")
                Exit Sub
            End If

            '' ======================================== VALIDACIONES INICIALES ======================================== ''





            '' ======================================== UBICACIÓN DEL ARCHIVO ======================================== ''

            sfd.DefaultExt = "xlsx" 'Asignamos el formato de salida por defecto
            sfd.Filter = "Archivos EXCEL|*.xlsx" 'Asignamos al cuadro que nos muestre los otros formatos disponibles para guardar
            sfd.FileName = "RESUMEN DE COSTOS DE ARTICULOS ESPECIALES"

            Dim resultado As DialogResult = sfd.ShowDialog(Me) 'Guardamos el resultado de lo que haga el usuario al buscar una ubicacion
            ''Dim rutaArchivo As String = IO.Path.GetDirectoryName(sfd.FileName) 'Guardamos el nombre que eligió el usuario

            If resultado <> System.Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            '' ======================================== UBICACIÓN DEL ARCHIVO ======================================== ''


            Cursor = Cursors.WaitCursor


            '' ================================================== CONSULTA DE LA INFORMACIÓN DEL REPORTE ================================================== ''

            Dim dtResumenCostos = ObtenerDataTableView(gridView)
            Dim dtImagenes As Task(Of DataTable) = Nothing

            Dim modelosSeleccionados As New List(Of Integer)()

            For Each pes In gridView.GetSelectedRows()
                Dim row = gridView.GetDataRow(pes)
                If row IsNot Nothing Then
                    modelosSeleccionados.Add(row("ProductoEstiloId"))
                End If
            Next

            modelosSeleccionados = modelosSeleccionados.Distinct().ToList()


            dtReporteModelosPorColeccionesEspeciales = objDC_BU.ConsultarReporteModelosPorColecciones_Especiales(String.Join(",", modelosSeleccionados))


            If Not dtReporteModelosPorColeccionesEspeciales.Columns.Contains("Foto") Then   '' Se agrega la columna si no existe.
                dtReporteModelosPorColeccionesEspeciales.Columns.Add("Foto", GetType(System.Drawing.Image))
                dtReporteModelosPorColeccionesEspeciales.Columns("Foto").SetOrdinal(1)
            End If


            AgregarImagenesDT.cancelarProcesoCargaImagenes = New CancellationTokenSource()
            dtImagenes = AgregarImagenesDT.AgregarImagenesTabla(Me, dtReporteModelosPorColeccionesEspeciales, "FotoModelo", "Foto", AgregarImagenesDT.cancelarProcesoCargaImagenes.Token)
            dtReporteModelosPorColeccionesEspeciales = Await dtImagenes
            dtReporteModelosPorColeccionesEspeciales.Columns.Remove("FotoModelo")

            '' ================================================== CONSULTA DE LA INFORMACIÓN DEL REPORTE ================================================== ''





            '' ================================================================================ FORMATO EXCEL ================================================================================ ''
            '' ================================================================================ FORMATO EXCEL ================================================================================ ''

            Dim reporteExcel As New ReportesExcel
            Dim archivoExcel As New Infragistics.Documents.Excel.Workbook
            Dim hojaExcel As Worksheet

            Dim cliente As String = ""
            Dim fechaLiberacion As String = ""
            Dim vigenciaTemporada As String = ""
            Dim naveDesarrollo As String = ""
            Dim formatoFecha As String = Date.Now.ToString("dd.MM.yyyy")

            Dim nombreArchivo As String = ""



            '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''

            cliente = dtReporteModelosPorColeccionesEspeciales.AsEnumerable().
                                                Select(Function(resumen) resumen("Cliente")).
                                                Distinct().FirstOrDefault().ToString()
            fechaLiberacion = Date.Now.ToShortDateString().Trim.ToUpper

            Dim vigenciaTemporadaAux = dtpVigenciaEspecial.EditValue.ToString()
            Dim fechaConvertida As Date = Date.Parse(vigenciaTemporadaAux)
            vigenciaTemporada = fechaConvertida.ToString("dd/MM/yyyy")
            '' vigenciaTemporada = fechaConvertida.ToString("MMMM dd, yyyy")

            naveDesarrollo = txtNaveDesarrollo.Text.Trim.ToUpper

            '' Borramos la columna del cliente.
            dtReporteModelosPorColeccionesEspeciales.Columns.Remove("Cliente")

            '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''



            '' ======================================== RUTA ARCHIVO ======================================== ''

            Dim rutaArchivo = VerificarCarpetaDestinoNave(System.IO.Path.GetDirectoryName(sfd.FileName), "ESPECIALES", naveDesarrollo, "EXCEL")
            nombreArchivo = "F-RESUMEN DE COSTEO (MODELOS ESPECIALES) " + cliente + " - " + naveDesarrollo + " " + formatoFecha

            '' ======================================== RUTA ARCHIVO ======================================== ''

            Dim bloquesEspeciales As Integer = Math.Ceiling(dtReporteModelosPorColeccionesEspeciales.Rows.Count / 15)   '' Total de bloques de 15 registros para cada hoja.

            For reporte As Integer = 0 To bloquesEspeciales - 1
                Dim dtReporteModelosPorColeccionesEspeciales_Aux = dtReporteModelosPorColeccionesEspeciales.AsEnumerable.Skip(reporte * 15).Take(15).CopyToDataTable()

                Dim configInicial As New ConfiguracionArchivoExcel With {
                                                               .ExtensionArchivo = ExtensionArchivoExcel.XLSX,
                                                               .NombreArchivo = nombreArchivo,
                                                               .RutaArchivo = rutaArchivo + "\",
                                                               .ArchivoExcel = archivoExcel
                                                           }

                tamañoColumnas = New List(Of Integer) From {
                                                                  10,     '' ESPACIO (10 px)
                                                                  30,     '' NO.
                                                                  140,    '' FOTO
                                                                  150,    '' COLECCIÓN
                                                                  80,     '' MODELO
                                                                  120,    '' PIEL
                                                                  100,    '' COLOR
                                                                  90,     '' CORRIDA
                                                                  100,    '' MATERIAL DIRECTO
                                                                  110,    '' OVERHEAD
                                                                  110,    '' CLASIFICACION
                                                                  110,    '' COSTO FABRICACIÓN
                                                                  100,    '' UTILIDAD %
                                                                  100,    '' UTILIDAD $
                                                                  110,    '' PRECIO VENTA COMERCIALIZADORA
                                                                  120,    '' PRECIO BASE
                                                                  10      '' ESPACIO
                                                           }

                formatoColumnas = New List(Of String) From {
                                                            "vacio",        '' ESPACIO (10 px)
                                                            "numero",       '' NO.
                                                            "foto",         '' FOTO
                                                            "texto",        '' COLECCIÓN
                                                            "alfanumerico", '' MODELO
                                                            "texto",        '' PIEL
                                                            "texto",        '' COLOR
                                                            "corrida",      '' CORRIDA
                                                            "dinero",       '' MATERIAL DIRECTO
                                                            "dinero",       '' OVERHEAD
                                                            "caracter",     '' CLASIFICACION
                                                            "dinero",       '' COSTO FABRICACIÓN
                                                            "porcentaje",   '' UTILIDAD %
                                                            "dinero",       '' UTILIDAD $
                                                            "dinero",       '' PRECIO VENTA COMERCIALIZADORA
                                                            "dinero",       '' PRECIO BASE
                                                            "vacio"         '' ESPACIO
                                                           }

                Dim configInfoReporte As New ConfiguracionInformacionReporte With {
                                                        .InformacionReporte = dtReporteModelosPorColeccionesEspeciales_Aux,
                                                        .TamañoColumnas = tamañoColumnas,
                                                        .MostrarTotalGeneral = False
                                                    }

                Dim configHojaExcel As New ConfiguracionHojaExcel With {
                                                        .NombreHoja = IIf(bloquesEspeciales > 1, "MODELOS ESPECIALES - " + CStr(reporte + 1), "MODELOS ESPECIALES"),
                                                        .OcultarCuadricula = True,
                                                        .FijarFila = True,
                                                        .NumeroFilaFija = 9,
                                                        .HojaExcel = hojaExcel,
                                                        .FormatoColumnas = formatoColumnas,
                                                        .Zoom = 80
                                                    }

                Dim configEncabezado As New ConfiguracionEncabezado With {
                                                        .NombreArea = "F-DC-0922",
                                                        .NombreReporte = "RESUMEN COSTOS MODELOS ESPECIALES",
                                                        .NombreVersionDocumento = "",
                                                        .NombreResponsable = "Responsable: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername,
                                                        .Mes = CStr(fechaLiberacion)
                                                    }

                Dim configSubEncabezados As New ConfiguracionSubEncabezados With {
                                                        .Campo1 = cliente,              '' CLIENTE
                                                        .Campo2 = fechaLiberacion,      '' FECHA DE LIBERACIÓN
                                                        .Campo3 = vigenciaTemporada,    '' VIGENCIA
                                                        .Campo4 = naveDesarrollo        '' NAVE DESARROLLO
                                                    }

                Dim configImpresion As New ConfiguracionImpresion With {
                                                        .TamañoHoja = TamañoHojaImpresion.Carta,
                                                        .OrientacionHoja = OrientacionHoja.Vertical,
                                                        .AjustarMargenesImpresion = True,
                                                        .AjustarContenidoAUnaHoja = True,
                                                        .ModificarAreaImpresion = True,
                                                        .AreaImpresion = "A1:Q33",
                                                        .PreguntarAbrirArchivo = False
                                                    }


                reporteExcel.GenerarReporteDeCostosProductos(configInfoReporte, configInicial, configHojaExcel, configEncabezado, configSubEncabezados, configImpresion, False)

                '' Limpiamos los recursos usados para la generación del archivo de Excel.
                GC.Collect()
                GC.WaitForPendingFinalizers()
            Next

            '' ================================================================================ FORMATO EXCEL ================================================================================ ''
            '' ================================================================================ FORMATO EXCEL ================================================================================ ''


            Tools.MostrarMensaje(Mensajes.Success, "Los reportes fueron generados de forma exitosa.")
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al generar el formato Excel especial: " + ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub



    Private Async Sub ExportarPdfFormatoReporteDeCostosProductos()
        Dim objBU_Reporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim reporteListaPrecios As New StiReport

        Dim dsResumenCostosNuevosArticulos As New DataSet("dsResumenCostosNuevosArticulos")
        Dim dtResumenCostosNuevosArticulosFinal As DataTable

        Dim formaConfirmacion As New ConfirmarForm
        Dim sfd As New SaveFileDialog 'Creamos variable para guardar la ruta de nuestro archivo



        Try
            Dim dtReporteModelosPorColeccionesModelos As DataTable
            Dim dtNavesSeleccionadas As DataTable = CType(slueComboNaveDesarrollo.Properties.DataSource, DataTable)
            Dim dtMarcasSeleccionadas As DataTable = CType(lookUpMarca.Properties.DataSource, DataTable)
            Dim dtTemporadasSeleccionadas As DataTable = CType(slueComboTemporada.Properties.DataSource, DataTable)
            Dim dtColeccionesSeleccionadas As DataTable = CType(slueComboColeccion.Properties.DataSource, DataTable)

            Dim navesSeleccionadas = dtNavesSeleccionadas.AsEnumerable().
                                                Where(Function(nave) Not IsDBNull(nave("Sel")) AndAlso CBool(nave("Sel")) = True).
                                                Select(Function(nave) New With {
                                                                                .NaveId = nave.Field(Of Integer)("nave_naveid"),
                                                                                .Nave = nave.Field(Of String)("nave_nombre")
                                                                               }).
                                                ToList()
            Dim temporadasSeleccionadas = dtTemporadasSeleccionadas.AsEnumerable().
                                                Select(Function(nave) New With {
                                                                                .Temporada = nave.Field(Of String)("temp_nombre"),
                                                                                .Vigencia = If(nave.IsNull("temp_vigencia"), "", nave.Field(Of Date)("temp_vigencia").ToString("dd/MM/yyyy"))
                                                                                }).
                                                ToList()
            Dim coleccionesSeleccionadas = dtColeccionesSeleccionadas.AsEnumerable().
                                                Where(Function(cole) Not IsDBNull(cole("Sel")) AndAlso CBool(cole("Sel")) = True).
                                                Select(Function(cole) New With {
                                                                                .Temporada = cole.Field(Of String)("Temporada"),
                                                                                .Coleccion = cole.Field(Of String)("Coleccion"),
                                                                                .NaveDesarrolla = cole.Field(Of String)("NaveDesarrolla")
                                                                                }).
                                                ToList()

            If navesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos una nave para generar el reporte.")
                Exit Sub
            End If

            If coleccionesSeleccionadas.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar al menos una colección para generar el reporte.")
                Exit Sub
            End If

            If coleccionesSeleccionadas.Count > 40 Then
                formaConfirmacion.StartPosition = FormStartPosition.CenterParent
                formaConfirmacion.mensaje = "Se van a generar muchos formatos por las colecciones seleccionadas, ¿Estás seguro?"

                Dim respuestaUsuario = formaConfirmacion.ShowDialog()

                If respuestaUsuario <> Windows.Forms.DialogResult.OK Then
                    Exit Sub
                End If
            End If



            sfd.DefaultExt = "pdf" 'Asignamos el formato de salida por defecto
            sfd.Filter = "Archivos PDF|*.pdf" 'Asignamos al cuadro que nos muestre los otros formatos disponibles para guardar
            sfd.FileName = "RESUMEN DE COSTOS DE ARTICULOS"

            Dim resultado As DialogResult = sfd.ShowDialog(Me) 'Guardamos el resultado de lo que haga el usuario al buscar una ubicacion
            ''Dim rutaArchivo As String = IO.Path.GetDirectoryName(sfd.FileName) 'Guardamos el nombre que eligió el usuario

            If resultado <> System.Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If



            Cursor = Cursors.WaitCursor



            dtReporteModelosPorColeccionesModelos = objDC_BU.ConsultarReporteModelosPorColecciones_Modelos(navesDesarolloSeleccionadasGlobal, temporadasSeleccionadasGlobal, coleccionesSeleccioandasGlobal, estatusProductoSeleccioandosGlobal)


            Dim dtImagenes As Task(Of DataTable) = Nothing

            If Not dtReporteModelosPorColeccionesModelos.Columns.Contains("Foto") Then   '' Se agrega la columna si no existe.
                dtReporteModelosPorColeccionesModelos.Columns.Add("Foto", GetType(System.Drawing.Image))
                dtReporteModelosPorColeccionesModelos.Columns("Foto").SetOrdinal(0)
            End If


            AgregarImagenesDT.cancelarProcesoCargaImagenes = New CancellationTokenSource()
            dtImagenes = AgregarImagenesDT.AgregarImagenesTabla(Me, dtReporteModelosPorColeccionesModelos, "FotoModelo", "Foto", AgregarImagenesDT.cancelarProcesoCargaImagenes.Token)
            dtReporteModelosPorColeccionesModelos = Await dtImagenes
            dtReporteModelosPorColeccionesModelos.Columns.Remove("FotoModelo")



            Dim reporteColeccionesPorColeccion_Modelos = dtReporteModelosPorColeccionesModelos.AsEnumerable().
                                                        GroupBy(Function(row) row.Field(Of Integer)("NumColeccion"))





            For Each coleccion In reporteColeccionesPorColeccion_Modelos
                objBU_Reporte = New Framework.Negocios.ReportesBU
                EntidadReporte = New Entidades.Reportes
                reporteListaPrecios = New StiReport

                dsResumenCostosNuevosArticulos = New DataSet("dsResumenCostosNuevosArticulos")


                Dim dtReportePorModelos_Modelos As DataTable
                Dim dtReportePorModelos_ModelosSeccion As DataTable
                Dim primeraFilaReporte As DataRow


                Dim numColeccionActual As Integer
                Dim cliente As String = ""
                Dim fechaLiberacion As String = ""
                Dim vigenciaTemporada As String = ""
                Dim naveActual As String = ""



                numColeccionActual = coleccion.Key



                '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''

                dtReportePorModelos_Modelos = coleccion.CopyToDataTable()
                primeraFilaReporte = coleccion.First()


                Dim marcaActual = primeraFilaReporte.Field(Of String)("Marca").Trim.ToUpper
                Dim coleccionActual = primeraFilaReporte.Field(Of String)("Coleccion").Trim.ToUpper
                Dim temporadaActual = primeraFilaReporte.Field(Of String)("Temporada").Trim.ToUpper



                '' ========== INFORMACIÓN ENCABEZADO ========== ''
                If Not IsDBNull(primeraFilaReporte("Cliente")) Then
                    naveActual = primeraFilaReporte.Field(Of String)("NaveDesarrollo").Trim.ToUpper
                End If
                If Not IsDBNull(primeraFilaReporte("Cliente")) Then
                    cliente = primeraFilaReporte.Field(Of String)("Cliente").Trim.ToUpper
                End If
                If Not IsDBNull(primeraFilaReporte("FechaLiberacion")) Then
                    fechaLiberacion = primeraFilaReporte.Field(Of String)("FechaLiberacion").Trim.ToUpper
                End If


                Dim fechaVigenciaTemporada As DateTime
                Dim vigenciaTemporadaSeleccionada = temporadasSeleccionadas.AsEnumerable.
                                                         Where(Function(temp) temp.Temporada.Trim.ToUpper = temporadaActual.Trim.ToUpper).
                                                         Select(Function(temp) temp.Vigencia).FirstOrDefault()

                If Not IsDBNull(vigenciaTemporadaSeleccionada) AndAlso vigenciaTemporadaSeleccionada IsNot Nothing Then
                    If DateTime.TryParse(vigenciaTemporadaSeleccionada.ToString(), fechaVigenciaTemporada) Then
                        vigenciaTemporada = fechaVigenciaTemporada.ToString("dd MMMM, yyyy").Trim.ToUpper
                    Else
                        vigenciaTemporada = "SIN FECHA"
                    End If
                Else
                    vigenciaTemporada = "SIN FECHA"
                End If

                '' ========== INFORMACIÓN ENCABEZADO ========== ''

                Dim rutaArchivo = VerificarCarpetaDestinoNave(System.IO.Path.GetDirectoryName(sfd.FileName), "GENERALES", naveActual, "PDF")

                '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''



                '' ======================================== INFORMACIÓN REPORTE ======================================== ''

                Dim formatoFechaLarga As String = Date.Now.ToString("dd.MM.yyyy hh.mm")
                Dim formatoFecha As String = Date.Now.ToString("dd.MM.yyyy")
                Dim nombreReporte As String = ""

                Dim archivoMrt As String = IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.MyDocuments, LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt")
                nombreReporte = "RESUMEN DE COSTOS DE ARTICULOS (" + cliente + ") - " + naveActual + " " + marcaActual + " " + coleccionActual + " " + formatoFecha + ".pdf"  ''formatoFechaLarga

                Dim archivoPDF As String = IO.Path.Combine(rutaArchivo, nombreReporte)

                EntidadReporte = objBU_Reporte.LeerReporteporClave("REPORTE_DE_RESUMEN_DE_COSTOS_NUEVAS_COLECCIONES")

                '' ======================================== INFORMACIÓN REPORTE ======================================== ''



                '' ======================================== CONTENIDO REPORTE ======================================== ''

                dtResumenCostosNuevosArticulosFinal = New DataTable("dtResumenCostosNuevosArticulos")
                With dtResumenCostosNuevosArticulosFinal
                    .Columns.Add("NumColeccion", GetType(String))
                    .Columns.Add("NumTalla", GetType(String))
                    .Columns.Add("NumModelo", GetType(String))
                    .Columns.Add("Foto", GetType(Image))
                    .Columns.Add("Coleccion", GetType(String))
                    .Columns.Add("ModeloSAY", GetType(String))
                    .Columns.Add("Piel", GetType(String))
                    .Columns.Add("Color", GetType(String))
                    .Columns.Add("Talla", GetType(String))

                    .Columns.Add("CostoMaterialDirecto", GetType(String))
                    .Columns.Add("CostoOverhead", GetType(String))
                    .Columns.Add("Clasificacion", GetType(String))
                    .Columns.Add("CostoFabricacion", GetType(String))
                    .Columns.Add("UtilidadPesos", GetType(String))
                    .Columns.Add("UtilidadPorcentaje", GetType(String))

                    .Columns.Add("PrecioVentaComercializadora", GetType(String))
                    .Columns.Add("PrecioBase", GetType(String))
                End With



                dtReportePorModelos_ModelosSeccion = coleccion.ToList().CopyToDataTable()

                For Each Fila As DataRow In dtReportePorModelos_ModelosSeccion.Rows
                    dtResumenCostosNuevosArticulosFinal.Rows.Add(Fila.Item("NumColeccion").ToString(),
                                                                            Fila.Item("NumTalla").ToString(),
                                                                            Fila.Item("NumModelo").ToString(),
                                                                            IIf(Fila.Item("ModeloSAY").ToString = "", Nothing, Fila.Item("Foto")),
                                                                            Fila.Item("Coleccion").ToString(),
                                                                            Fila.Item("ModeloSAY").ToString(),
                                                                            Fila.Item("Piel").ToString(),
                                                                            Fila.Item("Color").ToString(),
                                                                            Fila.Item("Talla").ToString(),
                                                                            Fila.Item("CostoMaterialDirecto").ToString(),
                                                                            Fila.Item("CostoOverhead").ToString(),
                                                                            Fila.Item("Clasificacion").ToString(),
                                                                            Fila.Item("CostoFabricacion").ToString(),
                                                                            Fila.Item("UtilidadPesos").ToString(),
                                                                            Fila.Item("UtilidadPorcentaje").ToString(),
                                                                            Fila.Item("PrecioVentaComercializadora").ToString(),
                                                                            Fila.Item("PrecioBase").ToString())
                Next

                '' ======================================== CONTENIDO REPORTE ======================================== ''



                My.Computer.FileSystem.WriteAllText(archivoMrt, EntidadReporte.Pxml, False)

                dsResumenCostosNuevosArticulos.Tables.Add(dtResumenCostosNuevosArticulosFinal)

                reporteListaPrecios.Load(archivoMrt)
                reporteListaPrecios.RegData("dsResumenCostosNuevosArticulos", dsResumenCostosNuevosArticulos)
                reporteListaPrecios.Compile()

                reporteListaPrecios("NombreCliente") = cliente
                reporteListaPrecios("FechaLiberacion") = fechaLiberacion
                reporteListaPrecios("Vigencia") = vigenciaTemporada
                reporteListaPrecios("NaveDesarrollo") = naveActual
                reporteListaPrecios("NombreResponsable") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporteListaPrecios("urlImagenNave") = "\\192.168.2.156\Graficos Zebra\LogoGrupoYuyin.png"

                'reporteListaPrecios.Dictionary.Clear()
                reporteListaPrecios.Dictionary.Synchronize()
                'reporteListaPrecios.LoadFromUrl(archivoPDF)
                reporteListaPrecios.Render()



                ' Exportar a PDF sin mostrar el reporte
                Dim exportadorPDF As New Stimulsoft.Report.Export.StiPdfExportSettings()
                Dim servicioExportacion As New Stimulsoft.Report.Export.StiPdfExportService()
                Using stream As New IO.FileStream(archivoPDF, IO.FileMode.Create)
                    servicioExportacion.ExportTo(reporteListaPrecios, stream, exportadorPDF)
                End Using
            Next

            Tools.MostrarMensaje(Mensajes.Success, "Los reportes fueron generados de forma exitosa.")
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al generar el reporte." + ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Async Sub ExportarPdfFormatoReporteDeCostosProductos_Especiales()
        Dim gridView As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim dtReporteModelosPorColeccionesEspeciales As New DataTable

        Dim formaConfirmacion As New ConfirmarForm
        Dim sfd As New SaveFileDialog 'Creamos variable para guardar la ruta de nuestro archivo

        Dim objBU_Reporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim reporteListaPrecios As New StiReport

        Dim dsResumenCostosNuevosArticulos As New DataSet("dsResumenCostosNuevosArticulos")
        Dim dtResumenCostosNuevosArticulos As DataTable



        Try
            '' ======================================== VALIDACIONES INICIALES ======================================== ''

            gridView = ObtenerTablaActual()

            If gridView Is Nothing Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debe estar en una pantalla de Resumen de Costos para poder exportar reportes.")
                Exit Sub
            End If

            If ValidarInformacionCombos_ReportesEspeciales() = False Then
                Exit Sub
            End If


            Dim modelosEspecialesSeleccionados = gridView.GetSelectedRows()

            If modelosEspecialesSeleccionados.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No ha seleccionado ningún modelo para generar el reporte")
                Exit Sub
            End If

            '' ======================================== VALIDACIONES INICIALES ======================================== ''





            '' ======================================== UBICACIÓN DEL ARCHIVO ======================================== ''

            sfd.DefaultExt = "pdf" 'Asignamos el formato de salida por defecto
            sfd.Filter = "Archivos PDF|*.pdf" 'Asignamos al cuadro que nos muestre los otros formatos disponibles para guardar
            sfd.FileName = "RESUMEN DE COSTOS DE ARTICULOS"

            Dim resultado As DialogResult = sfd.ShowDialog(Me) 'Guardamos el resultado de lo que haga el usuario al buscar una ubicacion
            ''Dim rutaArchivo As String = IO.Path.GetDirectoryName(sfd.FileName) 'Guardamos el nombre que eligió el usuario

            If resultado <> System.Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            '' ======================================== UBICACIÓN DEL ARCHIVO ======================================== ''


            Cursor = Cursors.WaitCursor


            '' ================================================== CONSULTA DE LA INFORMACIÓN DEL REPORTE ================================================== ''

            Dim dtResumenCostos = ObtenerDataTableView(gridView)
            Dim dtImagenes As Task(Of DataTable) = Nothing

            ''Dim modelosSeleccionados = dtResumenCostos.AsEnumerable.
            ''                                    Where(Function(prod) Not IsDBNull(prod("Sel")) AndAlso
            ''                                                        CBool(prod("Sel")) = True).
            ''                                    Select(Function(prod) prod("ProductoEstiloId")).
            ''                                    Distinct()

            Dim modelosSeleccionados As New List(Of Integer)()

            For Each pes In gridView.GetSelectedRows()
                Dim row = gridView.GetDataRow(pes)
                If row IsNot Nothing Then
                    modelosSeleccionados.Add(row("ProductoEstiloId"))
                End If
            Next

            modelosSeleccionados = modelosSeleccionados.Distinct().ToList()



            dtReporteModelosPorColeccionesEspeciales = objDC_BU.ConsultarReporteModelosPorColecciones_Especiales(String.Join(",", modelosSeleccionados))



            If Not dtReporteModelosPorColeccionesEspeciales.Columns.Contains("Foto") Then   '' Se agrega la columna si no existe.
                dtReporteModelosPorColeccionesEspeciales.Columns.Add("Foto", GetType(System.Drawing.Image))
                dtReporteModelosPorColeccionesEspeciales.Columns("Foto").SetOrdinal(1)
            End If

            AgregarImagenesDT.cancelarProcesoCargaImagenes = New CancellationTokenSource()
            dtImagenes = AgregarImagenesDT.AgregarImagenesTabla(Me, dtReporteModelosPorColeccionesEspeciales, "FotoModelo", "Foto", AgregarImagenesDT.cancelarProcesoCargaImagenes.Token)
            dtReporteModelosPorColeccionesEspeciales = Await dtImagenes
            dtReporteModelosPorColeccionesEspeciales.Columns.Remove("FotoModelo")

            '' ================================================== CONSULTA DE LA INFORMACIÓN DEL REPORTE ================================================== ''





            '' ================================================================================ FORMATO PDF ================================================================================ ''
            '' ================================================================================ FORMATO PDF ================================================================================ ''

            Dim cliente As String = ""
            Dim fechaLiberacion As String = ""
            Dim vigenciaTemporada As String = ""
            Dim naveDesarrollo As String = ""
            Dim formatoFecha As String = Date.Now.ToString("dd.MM.yyyy")

            Dim nombreArchivo As String = ""



            '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''

            cliente = dtReporteModelosPorColeccionesEspeciales.AsEnumerable().
                                            Select(Function(resumen) resumen("Cliente")).
                                            Distinct().FirstOrDefault().ToString()
            fechaLiberacion = Date.Now.ToShortDateString().Trim.ToUpper

            Dim vigenciaTemporadaAux = dtpVigenciaEspecial.EditValue.ToString()
            Dim fechaConvertida As Date = Date.Parse(vigenciaTemporadaAux)
            vigenciaTemporada = fechaConvertida.ToString("dd/MM/yyyy")
            '' vigenciaTemporada = fechaConvertida.ToString("MMMM dd, yyyy")

            naveDesarrollo = txtNaveDesarrollo.Text.Trim.ToUpper

            '' Borramos la columna del cliente.
            dtReporteModelosPorColeccionesEspeciales.Columns.Remove("Cliente")

            '' ======================================== INFORMACIÓN ENCABEZADO ======================================== ''



            '' ======================================== RUTA ARCHIVO ======================================== ''

            Dim rutaArchivo = VerificarCarpetaDestinoNave(System.IO.Path.GetDirectoryName(sfd.FileName), "ESPECIALES", naveDesarrollo, "PDF")
            nombreArchivo = "F-RESUMEN DE COSTEO (MODELOS ESPECIALES) " + cliente + " - " + naveDesarrollo + " " + formatoFecha

            '' ======================================== RUTA ARCHIVO ======================================== ''



            '' ======================================== REPORTE ======================================== ''

            EntidadReporte = objBU_Reporte.LeerReporteporClave("REPORTE_DE_RESUMEN_DE_COSTOS_NUEVAS_COLECCIONES_ESPECIALES")

            Dim nombreReporte As String = ""
            Dim archivoPDF As String = ""

            If Not Directory.Exists("C:\ProgramData\SAY\Reportes\") Then
                Directory.CreateDirectory("C:\ProgramData\SAY\Reportes\")
            End If
            Dim archivoMrt As String = IO.Path.Combine("C:\ProgramData\SAY\Reportes\", LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt")
            nombreReporte = "F-RESUMEN DE COSTEO (MODELOS ESPECIALES) " + cliente + " - " + naveDesarrollo + " " + formatoFecha + ".pdf"
            archivoPDF = IO.Path.Combine(rutaArchivo, nombreReporte)

            My.Computer.FileSystem.WriteAllText(archivoMrt, EntidadReporte.Pxml, False)

            '' ======================================== REPORTE ======================================== ''





            objBU_Reporte = New Framework.Negocios.ReportesBU
            EntidadReporte = New Entidades.Reportes
            reporteListaPrecios = New StiReport

            '' ======================================== CONTENIDO REPORTE ======================================== ''

            dtResumenCostosNuevosArticulos = New DataTable("dtResumenCostosNuevosArticulos")
            With dtResumenCostosNuevosArticulos
                .Columns.Add("Foto", GetType(Image))
                .Columns.Add("Coleccion", GetType(String))
                .Columns.Add("ModeloSAY", GetType(String))
                .Columns.Add("Piel", GetType(String))
                .Columns.Add("Color", GetType(String))
                .Columns.Add("Talla", GetType(String))

                .Columns.Add("CostoMaterialDirecto", GetType(String))
                .Columns.Add("CostoOverhead", GetType(String))
                .Columns.Add("Clasificacion", GetType(String))
                .Columns.Add("CostoFabricacion", GetType(String))
                .Columns.Add("UtilidadPesos", GetType(String))
                .Columns.Add("UtilidadPorcentaje", GetType(String))

                .Columns.Add("PrecioVentaComercializadora", GetType(String))
                .Columns.Add("PrecioBase", GetType(String))
            End With


            For Each Fila As DataRow In dtReporteModelosPorColeccionesEspeciales.Rows
                dtResumenCostosNuevosArticulos.Rows.Add(IIf(Fila.Item("ModeloSAY").ToString = "", Nothing, Fila.Item("Foto")),
                                                                    Fila.Item("Coleccion").ToString(),
                                                                    Fila.Item("ModeloSAY").ToString(),
                                                                    Fila.Item("Piel").ToString(),
                                                                    Fila.Item("Color").ToString(),
                                                                    Fila.Item("Talla").ToString(),
                                                                    Fila.Item("CostoMaterialDirecto").ToString(),
                                                                    Fila.Item("CostoOverhead").ToString(),
                                                                    Fila.Item("Clasificacion").ToString(),
                                                                Fila.Item("CostoFabricacion").ToString(),
                                                                Fila.Item("UtilidadPesos").ToString(),
                                                                Fila.Item("UtilidadPorcentaje").ToString(),
                                                                Fila.Item("PrecioVentaComercializadora").ToString(),
                                                                Fila.Item("PrecioBase").ToString())
            Next

            '' ======================================== CONTENIDO REPORTE ======================================== ''





            dsResumenCostosNuevosArticulos.Tables.Add(dtResumenCostosNuevosArticulos)


            reporteListaPrecios.Load(archivoMrt)
            reporteListaPrecios.RegData("dsResumenCostosNuevosArticulos", dsResumenCostosNuevosArticulos)
            reporteListaPrecios.Compile()

            reporteListaPrecios("NombreCliente") = cliente
            reporteListaPrecios("FechaLiberacion") = fechaLiberacion
            reporteListaPrecios("Vigencia") = vigenciaTemporada
            reporteListaPrecios("NaveDesarrollo") = naveDesarrollo
            reporteListaPrecios("NombreResponsable") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporteListaPrecios("urlImagenNave") = "\\192.168.2.156\Graficos Zebra\LogoGrupoYuyin.png"

            'reporteListaPrecios.Dictionary.Clear()
            reporteListaPrecios.Dictionary.Synchronize()
            'reporteListaPrecios.LoadFromUrl(archivoPDF)
            reporteListaPrecios.Render()


            ' Exportar a PDF sin mostrar el reporte
            Dim exportadorPDF As New Stimulsoft.Report.Export.StiPdfExportSettings()
            Dim servicioExportacion As New Stimulsoft.Report.Export.StiPdfExportService()
            Using stream As New IO.FileStream(archivoPDF, IO.FileMode.Create)
                servicioExportacion.ExportTo(reporteListaPrecios, stream, exportadorPDF)
            End Using


            Tools.MostrarMensaje(Mensajes.Success, "Los reportes fueron generados de forma exitosa.")
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "A ocurrido un error al generar el reporte." + ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#End Region



#Region "EVENTOS"

#Region "SEARCH LOOK UP EDIT"

    Private Sub FiltrarInformacionCombos(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs)
        FiltrarColecciones(Nothing, Nothing)
    End Sub
    Private Sub FiltrarInformacionColecciones(sender As Object, e As DevExpress.XtraEditors.Controls.ClosedEventArgs)
        ObtenerColecciones(Nothing, Nothing)
    End Sub
    Private Sub limpiarFiltroNaveDesarrollo(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles slueComboNaveDesarrollo.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Dim dtNaves As DataTable = CType(slueComboNaveDesarrollo.Properties.DataSource, DataTable)
            CambiarSeleccionDataTable(dtNaves, False)
            FiltrarColecciones(Nothing, Nothing)
        End If
    End Sub
    Private Sub limpiarFiltroMarca(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lookUpMarca.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Dim dtMarcas As DataTable = CType(lookUpMarca.Properties.DataSource, DataTable)
            CambiarSeleccionDataTable(dtMarcas, False)
            FiltrarColecciones(Nothing, Nothing)
        End If
    End Sub
    Private Sub limpiarFiltroTemporada(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles slueComboTemporada.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Dim dtTemporadas As DataTable = CType(slueComboTemporada.Properties.DataSource, DataTable)
            CambiarSeleccionDataTable(dtTemporadas, False)
            FiltrarColecciones(Nothing, Nothing)
        End If
    End Sub
    Private Sub limpiarFiltroColeccion(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles slueComboColeccion.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Dim dtColeccionesFiltradas As DataTable = CType(slueComboColeccion.Properties.DataSource, DataTable)
            CambiarSeleccionDataTable(dtColeccionesFiltradas, False)
            coleccionesSeleccioandasGlobal = ""
            FiltrarColecciones(Nothing, Nothing)
            txtColeccion.Text = "SELECCIONE UNA COLECCIÓN"
        End If
    End Sub
    Private Sub limpiarFiltroEstatusProducto(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles slueComboEstatusProductoCosto.ButtonClick
        If e.Button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Clear Then
            Dim dtEstatusFiltrados As DataTable = CType(slueComboEstatusProductoCosto.Properties.DataSource, DataTable)
            CambiarSeleccionDataTable(dtEstatusFiltrados, False)
            FiltrarColecciones(Nothing, Nothing)
        End If
    End Sub

    Private Sub CambiarSeleccionDataTable(ByVal dtCombo As DataTable, ByVal valor As Boolean)
        For Each seleccion As DataRow In dtCombo.Rows
            seleccion("Sel") = valor
        Next
    End Sub

#End Region


#Region "ESTILOS Y COLORES"

    Private Sub AplicarColoresEstatusProductoCosto(sender As Object, e As RowCellStyleEventArgs) Handles grdVAdminResumenCostosEspeciales.RowCellStyle, grdVAdminResumenCostos.RowCellStyle
        Try
            '' Con esta condición evitamos que las celdas de los filtros también se editen.
            If e.RowHandle >= 0 Then
                Dim gridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                If e.Column.FieldName = "EstatusProductoCosto" Then
                    Dim estatusProductoCostoId = gridView.GetRowCellValue(e.RowHandle, "EstatusProductoCostoId")   '' El Id del estatus no está agregado a la tabla, por lo que debemos hacer esto para que cambie el color.

                    Select Case CType(estatusProductoCostoId, ProductoCosto)
                        Case ProductoCosto.SIN_SOLICITAR
                            e.Appearance.BackColor = ColoresEstatusCosto.SinSolicitar
                        Case ProductoCosto.SOLICITADO
                            e.Appearance.BackColor = ColoresEstatusCosto.Solicitado
                        Case ProductoCosto.EN_CAPTURA
                            e.Appearance.BackColor = ColoresEstatusCosto.EnCaptura
                        Case ProductoCosto.AUT_NAVE_DESARROLLO
                            e.Appearance.BackColor = ColoresEstatusCosto.AutNaveDesarrollo
                        Case ProductoCosto.RECHAZADO
                            e.Appearance.BackColor = ColoresEstatusCosto.Rechazado
                        Case ProductoCosto.LIBERADO_DC
                            e.Appearance.BackColor = ColoresEstatusCosto.LiberadoDC
                    End Select

                    e.Appearance.Options.UseBackColor = True
                    e.Appearance.BackColor2 = Color.Empty
                End If

                If e.Column.FieldName = "CostoMaterialDirecto" Or
                   e.Column.FieldName = "CostoOverhead" Or
                   e.Column.FieldName = "Clasificacion" Or
                   e.Column.FieldName = "CostoFabricacion" Or
                   e.Column.FieldName = "UtilidadPorcentaje" Or
                   e.Column.FieldName = "UtilidadPesos" Or
                   e.Column.FieldName = "PrecioVentaComercializadora" Then
                    Dim observacion = gridView.GetRowCellValue(e.RowHandle, "Observaciones")   '' El Id del estatus no está agregado a la tabla, por lo que debemos hacer esto para que cambie el color.

                    If observacion Is Nothing Then
                        Exit Sub
                    ElseIf observacion = "" Then
                        Exit Sub
                    End If

                    If observacion = "LA INFORMACIÓN DEL MODELO FUE MODIFICADA (ESTATUS PROTOTIPO)" Then
                        e.Appearance.BackColor = Color.Yellow
                    End If
                End If
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ah ocurrido un error al aplicar los colores a la tabla:" + ex.Message)
            Exit Sub    '' Salimos del evento en caso de que se genere un error al aplicar el estilo.
        End Try
    End Sub

    Private Sub CambiarColoresEstatusProductoCosto(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs)

    End Sub

    Private Sub AgregarContadorIndicator(sender As Object, e As XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVAdminResumenCostosEspeciales.CustomDrawRowIndicator, grdVAdminResumenCostos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1 'Numeramos la columna de indicador
        End If
    End Sub

    Private Sub grdVAdminResumenCostos_CellValueChanged(sender As Object, e As XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdVAdminResumenCostosEspeciales.CellValueChanged, grdVAdminResumenCostos.CellValueChanged
        Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        Dim costoMaterialDirecto As Decimal = 0
        Dim costoOverhead As Decimal = 0
        Dim costoFabricacion As Decimal = 0

        Dim utilidadPorcentaje As Decimal = 0
        Dim utilidadPesos As Decimal = 0

        Dim precioVentaComercializadora As Decimal = 0

        Try
            If e.Column.FieldName = "CostoMaterialDirecto" Or e.Column.FieldName = "CostoOverhead" Then
                costoMaterialDirecto = gridView.GetRowCellValue(e.RowHandle, "CostoMaterialDirecto")
                costoOverhead = gridView.GetRowCellValue(e.RowHandle, "CostoOverhead")
                utilidadPorcentaje = gridView.GetRowCellValue(e.RowHandle, "UtilidadPorcentaje")

                costoMaterialDirecto = Math.Round(costoMaterialDirecto, 2)
                costoOverhead = Math.Round(costoOverhead, 2)
                costoFabricacion = costoMaterialDirecto + costoOverhead

                gridView.SetRowCellValue(e.RowHandle, "CostoFabricacion", costoFabricacion)


                '' Si el usuario ya agregó el porcentaje, calculamos/recalculamos el precio de venta.
                If utilidadPorcentaje > 0 Then
                    utilidadPorcentaje = (utilidadPorcentaje / 100)

                    utilidadPesos = (costoFabricacion * utilidadPorcentaje)
                    utilidadPesos = Math.Round(utilidadPesos, 2)

                    precioVentaComercializadora = (costoFabricacion + utilidadPesos)
                    precioVentaComercializadora = Math.Round(precioVentaComercializadora, 2)

                    gridView.SetRowCellValue(e.RowHandle, "UtilidadPesos", utilidadPesos)
                    gridView.SetRowCellValue(e.RowHandle, "PrecioVentaComercializadora", precioVentaComercializadora)
                End If
            End If

            If e.Column.FieldName = "UtilidadPorcentaje" Then
                costoFabricacion = gridView.GetRowCellValue(e.RowHandle, "CostoFabricacion")
                utilidadPorcentaje = gridView.GetRowCellValue(e.RowHandle, "UtilidadPorcentaje")
                utilidadPorcentaje = (utilidadPorcentaje / 100)

                utilidadPesos = (costoFabricacion * utilidadPorcentaje)
                utilidadPesos = Math.Round(utilidadPesos, 2)

                precioVentaComercializadora = (costoFabricacion + utilidadPesos)
                precioVentaComercializadora = Math.Round(precioVentaComercializadora, 2)

                gridView.SetRowCellValue(e.RowHandle, "UtilidadPesos", utilidadPesos)
                gridView.SetRowCellValue(e.RowHandle, "PrecioVentaComercializadora", precioVentaComercializadora)

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


#Region "CAMBIO DE NOMBRE DE LOS BOTONES DE LOS LOOKUP"

    Private Sub AbrirPopUp(sender As Object, e As EventArgs) Handles slueComboTemporada.Popup, slueComboNaveDesarrollo.Popup, slueComboEstatusProductoCosto.Popup, slueComboColeccion.Popup, lookUpMarca.Popup
        Dim lookUpEdit = TryCast(sender, DevExpress.XtraEditors.SearchLookUpEdit)

        If lookUpEdit Is Nothing Then
            Exit Sub
        End If

        '' Buscamos en todos los formularios abiertos.
        For Each formulario As Form In Application.OpenForms
            '' Buscamos cualquier formulario abierto que sea un PopUp.
            If formulario.GetType().Name.Contains("PopupSearchLookUpEditForm") Then
                '' Obtenemos todos los controles del formulario.
                Dim controlesFormulario As List(Of Control) = ObtenerControles(formulario)

                For Each control In controlesFormulario
                    Dim boton = TryCast(control, DevExpress.XtraEditors.SimpleButton)

                    '' Si el control que estamos revisando es un botón, entramos.
                    If boton IsNot Nothing Then
                        If boton.Text = "Find" Then
                            boton.Text = "Buscar"
                        ElseIf boton.Text = "Clear" OrElse boton.Text = "Vaciar" Then
                            boton.Text = "Aceptar"
                            'ElseIf boton.Text = "Aceptar" Then
                            '    RemoveHandler boton.KeyPress, AddressOf CerrarPopUp '' Evitar múltiples suscripciones.
                            '    AddHandler boton.KeyPress, AddressOf CerrarPopUp
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    ' Función auxiliar para recorrer todos los controles recursivamente
    Private Function ObtenerControles(container As Control) As List(Of Control)
        Dim list As New List(Of Control)
        For Each ctrl As Control In container.Controls
            list.Add(ctrl)
            list.AddRange(ObtenerControles(ctrl))
        Next
        Return list
    End Function

    ''''Private Sub CerrarPopUp(sender As Object, e As KeyPressEventArgs)
    ''''    If e.KeyChar = Convert.ToChar(Keys.Enter) Then
    ''''        For Each control In {slueComboColeccion, slueComboNaveDesarrollo, slueComboTemporada, slueComboEstatusProductoCosto, lookUpMarca}
    ''''            If control IsNot Nothing AndAlso control.IsPopupOpen Then
    ''''                control.ClosePopup()
    ''''            End If
    ''''        Next
    ''''    End If
    ''''End Sub

#End Region


#Region "MISCELÁNEOS"

    Private Sub SeleccionarNuevaPestaña(sender As Object, e As XtraTab.TabPageChangedEventArgs) Handles tabCtrlResumenCostos.SelectedPageChanged
        Dim dtMarcasSeleccionadas As New DataTable
        Dim marcasEspeciales = {1, 5, 6, 7, 8}  '' ========== ANDREA, COPPEL2, COPPEL, CLIENTE, CLIENTE2 ========== ''


        Try
            If tabCtrlResumenCostos.SelectedTabPage Is tabPageResumenCostosEspeciales Then
                EsArticulosClientesEspeciales = True
                pnlVigenciaEspecial.Visible = True

                lblInformativo_General.Visible = False
                lblInformativo_Especial.Visible = False


                Dim lstMarcasClientesEspeciales = dtMarcasOriginal.AsEnumerable().
                                                Where(Function(marc) Not IsDBNull(marc("Sel")) AndAlso marcasEspeciales.Contains(CInt(marc("MarcaId")))).
                                                Select(Function(marc) marc).ToList()
                dtMarcasSeleccionadas = lstMarcasClientesEspeciales.CopyToDataTable()
            ElseIf tabCtrlResumenCostos.SelectedTabPage Is tabPageResumenCostos Then
                EsArticulosClientesEspeciales = False
                pnlVigenciaEspecial.Visible = False

                lblInformativo_General.Visible = False
                lblInformativo_Especial.Visible = False


                Dim lstMarcasClientes = dtMarcasOriginal.AsEnumerable().
                                                Where(Function(marc) Not IsDBNull(marc("Sel")) AndAlso Not marcasEspeciales.Contains(CInt(marc("MarcaId")))).
                                                Select(Function(marc) marc).ToList()
                dtMarcasSeleccionadas = lstMarcasClientes.CopyToDataTable()
            Else
                pnlVigenciaEspecial.Visible = False

                lblInformativo_General.Visible = True
                lblInformativo_Especial.Visible = True

                dtMarcasSeleccionadas = dtMarcasOriginal
            End If


            CambiarSeleccionDataTable(dtMarcasSeleccionadas, True)
            lookUpMarca.Properties.DataSource = dtMarcasSeleccionadas


            FiltrarColecciones(Nothing, Nothing)
        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ha ocurrido un error al cambiar la pestaña: " + ex.Message)
        Finally
            ObtenerTotalRegistros()
        End Try
    End Sub

    Private Sub MostrarFotografiaModelo(sender As Object, e As RowCellClickEventArgs) Handles grdVAdminResumenCostosEspeciales.RowCellClick, grdVAdminResumenCostos.RowCellClick
        If e.Clicks = 2 Then
            If e.Column.FieldName = "Foto" And e.RowHandle >= 0 Then
                Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = gridView.GetRowCellValue(e.RowHandle, "FotoModelo")
                MostrarFoto.Marca = gridView.GetRowCellValue(e.RowHandle, "Marca")
                MostrarFoto.Coleccion = gridView.GetRowCellValue(e.RowHandle, "Coleccion")
                MostrarFoto.ModeloSicy = gridView.GetRowCellValue(e.RowHandle, "ModeloSAY")
                MostrarFoto.ProductoEstiloId = gridView.GetRowCellValue(e.RowHandle, "ProductoEstiloId")

                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub grdVAdminResumenCostos_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdVAdminResumenCostosEspeciales.ShowingEditor, grdVAdminResumenCostos.ShowingEditor
        '' Obtenemos la información de la ubicación actual del mouse.
        Dim gridView = ObtenerTablaActual()
        Dim hitInfo As GridHitInfo = gridView.CalcHitInfo(gridView.GridControl.PointToClient(MousePosition))

        Dim EstatusProductoCostoId As ProductoCosto
        EstatusProductoCostoId = gridView.GetRowCellValue(hitInfo.RowHandle, "EstatusProductoCostoId")

        If EstatusProductoCostoId = ProductoCosto.LIBERADO_DC Or EstatusProductoCostoId = ProductoCosto.AUT_NAVE_DESARROLLO Then
            '' Si el usuario selecciona la columna NaveProduccion, entramos.
            Select Case gridView.FocusedColumn.FieldName
                Case "CostoMaterialDirecto", "CostoOverhead", "Clasificacion", "CostoFabricacion", "UtilidadPorcentaje", "UtilidadPesos", "PrecioVentaComercializadora"
                    e.Cancel = True
            End Select
        End If
    End Sub

    Private Sub AgregarSaltoLineaEnter(sender As Object, e As KeyEventArgs) Handles grdVAdminResumenCostosEspeciales.KeyDown, grdVAdminResumenCostos.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If Not gridView.IsLastVisibleRow Then
                gridView.FocusedColumn = gridView.Columns("CostoMaterialDirecto")   '' Asignamos el focus a la columna Costo Material Directo para más facilidad en la captura.
                gridView.MoveNext()    '' Nos movemos a la siguiente línea.
            End If
        End If
    End Sub

    Private Sub MostrarVentanas(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles grdVAdminResumenCostosEspeciales.PopupMenuShowing, grdVAdminResumenCostos.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            Dim columna = TryCast(e.HitInfo.Column, GridColumn)

            ' Validar solo columnas permitidas
            If columna IsNot Nothing AndAlso {"CostoMaterialDirecto", "CostoOverhead", "Clasificacion", "UtilidadPorcentaje"}.Contains(columna.FieldName) Then
                columnaSeleccionadaValorMasivo = columna
                PopupActualizacionMasiva.ShowPopup(MousePosition)
                e.Allow = False
            End If
        End If
    End Sub

    Private Sub ActualizarRegistros(ByVal sender As Object, ByVal e As EventArgs)
        ObtenerTotalRegistros()
    End Sub

#End Region

#End Region



#Region "ATAJOS DEL TECLADO"

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = (Keys.Control Or Keys.Enter) Then
            btnMostrar_Click(btnMostrar, New EventArgs())

            Return True
        ElseIf keyData = Keys.Escape Then
            AgregarImagenesDT.CancelarCargaImagenes()

            Return True
        ElseIf keyData = (Keys.Control Or Keys.D1) Then
            tabCtrlResumenCostos.SelectedTabPage = tabPageIndicadores

            Return True
        ElseIf keyData = (Keys.Control Or Keys.D2) Then
            tabCtrlResumenCostos.SelectedTabPage = tabPageResumenCostos

            Return True
        ElseIf keyData = (Keys.Control Or Keys.D3) Then
            tabCtrlResumenCostos.SelectedTabPage = tabPageResumenCostosEspeciales

            Return True
        ElseIf keyData = (Keys.Control Or Keys.OemMinus) Then
            btnArriba_Click(btnArriba, New EventArgs())

            Return True
        ElseIf keyData = (Keys.Control Or Keys.Oemplus) Then
            btnAbajo_Click(btnAbajo, New EventArgs())

            Return True
        Else

            Return False
        End If

        'Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub btnGenerarFormatoExcel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnGenerarFormatoExcel.KeyPress

    End Sub


#End Region

End Class



Public Enum ProductoCosto
    SIN_SOLICITAR = 597
    SOLICITADO = 598
    EN_CAPTURA = 599
    AUT_NAVE_DESARROLLO = 600
    RECHAZADO = 601
    LIBERADO_DC = 602
    CANCELADO = 603
End Enum

Public NotInheritable Class ColoresEstatusCosto
    Public Shared ReadOnly SinSolicitar As Color = Color.FromArgb(169, 169, 169)        ' Gris medio
    Public Shared ReadOnly Solicitado As Color = Color.FromArgb(100, 149, 237)          ' CornflowerBlue
    Public Shared ReadOnly AutNaveDesarrollo As Color = Color.FromArgb(102, 205, 170)   ' MediumAquamarine
    Public Shared ReadOnly Rechazado As Color = Color.FromArgb(240, 128, 128)           ' LightCoral
    Public Shared ReadOnly LiberadoDC As Color = Color.FromArgb(143, 188, 143)          ' DarkSeaGreen
    Public Shared ReadOnly EnCaptura As Color = Color.FromArgb(255, 160, 122)           ' LightSalmon

    Private Sub New()
        ' Evita que se instancie esta clase
    End Sub
End Class
