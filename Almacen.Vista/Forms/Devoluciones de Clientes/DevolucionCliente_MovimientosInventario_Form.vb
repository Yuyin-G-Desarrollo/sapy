Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting

Public Class DevolucionCliente_MovimientosInventario_Form

    Dim dtMovimientos As New DataTable
    Dim primerCodigo As Boolean
    Dim FolioDevSAY As String

    Public dtCodigosCorrectos As DataTable
    Public dtCodigosErroneos As DataTable
    Public dtCodigo As DataTable
    Public destinoID As Int32

    Private Sub DevolucionCliente_MovimientosInventario_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtMovimientos = (New Negocios.MovimientosInventario_BU).ConsultaTipoMovimientos()
        cmbMovimiento.DataSource = Nothing
        Dim newRow As DataRow = dtMovimientos.NewRow
        dtMovimientos.Rows.InsertAt(newRow, 0)
        cmbMovimiento.DataSource = dtMovimientos
        cmbMovimiento.DisplayMember = "TipoMovimiento"
        cmbMovimiento.ValueMember = "TipoMovimiento_ID"
        MostrarOcultarEtiquetas(False)
        pnlRestricciones.Visible = True
        'chkMostrarColumnas.Checked = False
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Function ValidarRepetidos(codigo As String)
        Dim NumeroFilas = bgvConsultaLotes.DataRowCount
        If bgvConsultaLotes.DataRowCount = 0 Then Return False

        If bgvConsultaLotes.DataRowCount = 0 Then Return False
        Try
            For index As Integer = 0 To NumeroFilas - 1 Step 1
                Dim codigoEnGrid As String = bgvConsultaLotes.GetRowCellValue(bgvConsultaLotes.GetVisibleRowHandle(index), "Par").ToString
                Dim partesCodigo As List(Of String) = codigoEnGrid.Split("/").ToList
                If bgvConsultaLotes.GetRowCellValue(bgvConsultaLotes.GetVisibleRowHandle(index), "Par").ToString = codigo Or partesCodigo.Last = codigo Then
                    Return True
                End If
            Next
        Catch ex As Exception
            Return False
        End Try

        Return False
    End Function

    Public Sub MostrarOcultarEtiquetas(valor As Boolean)
        lblEtiquetaFolioDev.Visible = valor
        lblFolioDev.Visible = valor
        lblEtiquetaDestino.Visible = valor
        lblDestino.Visible = valor
        lblEtiquetaPares.Visible = valor
        lblPares.Visible = valor
        pnlRestricciones.Visible = valor
        pnlBtnGuardar.Visible = valor
    End Sub

    Public Function GenerarFila(TipoGrid As String, row As DataRow, TipoCodigo As String)
        Dim fila As DataRow

        If TipoGrid = "CORRECTO" Then
            fila = dtCodigosCorrectos.NewRow
        ElseIf TipoGrid = "ERRONEO" Then
            fila = dtCodigosErroneos.NewRow
        End If

        For Each columna As DataColumn In dtCodigo.Columns
            If columna.Caption = "TipoCodigo" And TipoCodigo.ToString.Length > 0 Then
                fila(columna.Caption) = TipoCodigo
            Else
                fila(columna.Caption) = row(columna.Caption)
            End If
        Next
        Return fila
    End Function
    Public Sub ConsultarCodigo(Codigo As String)
        If Codigo.Length = 0 Then Return
        Codigo = Codigo.Replace("PC", "Y-000-")
        dtCodigo = (New Negocios.MovimientosInventario_BU).ConsultaCodigos(Codigo)

        dtCodigosCorrectos = New DataTable
        dtCodigosErroneos = New DataTable

        If grdConsultaLotes.DataSource Is Nothing Then
            dtCodigosCorrectos = dtCodigo.Clone
            dtCodigosErroneos = dtCodigo.Clone
        Else
            dtCodigosCorrectos = grdConsultaLotes.DataSource
            dtCodigosErroneos = grdCodigosErroneos.DataSource
        End If

        For Each row As DataRow In dtCodigo.Rows
            If dtCodigosCorrectos.Rows.Count = 0 And row("TipoCodigo").ToString <> "INCORRECTO" Then
                If row("DevSAY").ToString.Length > 0 Then
                    If row("Status").ToString <> "PRODUCCIÓN" Then
                        dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, "ESTATUS NO VÁLIDO PARA DEVOLUCIÓN"), DataRow))
                    Else
                        Dim infoDev As New DataTable
                        FolioDevSAY = row("DevSAY").ToString

                        infoDev = (New Negocios.MovimientosInventario_BU).ConsultaInfoDevolucion(CInt(FolioDevSAY))
                        If infoDev.Rows.Count > 0 Then
                            dtCodigosCorrectos.Rows.Add(CType(GenerarFila("CORRECTO", row, ""), DataRow))
                            lblFolioDev.Text = FolioDevSAY
                            MostrarOcultarEtiquetas(False)
                            lblDestino.Text = infoDev.Rows(0).Item("Destino")
                            lblPares.Text = infoDev.Rows(0).Item("Pares")
                            destinoID = infoDev.Rows(0).Item("DestinoID")
                            If infoDev.Rows(0).Item("DestinoID") = 338 Or infoDev.Rows(0).Item("DestinoID") = 336 Then
                                cmbMovimiento.SelectedValue = 195
                            ElseIf infoDev.Rows(0).Item("DestinoID") = 337 Then
                                cmbMovimiento.SelectedValue = 196
                            End If
                            MostrarOcultarEtiquetas(True)
                            cmbMovimiento.Enabled = False
                        Else
                            dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, "DEVOLUCIÓN SIN DESTINO ASIGNADO"), DataRow))
                            FolioDevSAY = ""
                            MostrarOcultarEtiquetas(False)
                            cmbMovimiento.SelectedIndex = 0
                        End If
                    End If
                Else
                    dtCodigosCorrectos.Rows.Add(CType(GenerarFila("CORRECTO", row, ""), DataRow))
                    FolioDevSAY = ""
                    MostrarOcultarEtiquetas(False)
                    cmbMovimiento.SelectedIndex = 0
                End If
            ElseIf row("TipoCodigo").ToString = "INCORRECTO" Then
                dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, ""), DataRow))
            ElseIf FolioDevSAY = "" Then
                dtCodigosCorrectos.Rows.Add(CType(GenerarFila("CORRECTO", row, ""), DataRow))
            ElseIf row("DevSAY").ToString.Length > 0 Then
                If row("Status").ToString <> "PRODUCCIÓN" Then
                    dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, "ESTATUS NO VÁLIDO PARA DEVOLUCIÓN"), DataRow))
                ElseIf row("DevSAY").ToString = FolioDevSAY Then
                    If ValidarRepetidos(row("Par")) = True Then
                        dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, "CÓDIGO DUPLICADO"), DataRow))
                    Else
                        dtCodigosCorrectos.Rows.Add(CType(GenerarFila("CORRECTO", row, ""), DataRow))
                    End If
                Else
                    dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, "FOLIO DE DEVOLUCIÓN DIFERENTE"), DataRow))
                End If
            Else
                dtCodigosErroneos.Rows.Add(CType(GenerarFila("ERRONEO", row, "SIN FOLIO DE DEVOLUCIÓN"), DataRow))
            End If

            'If row("DevSAY").ToString.Length > 0 And row("Status").ToString = "PRODUCCIÓN" Then
            '    If ValidarRepetidos(row("Par")) = True Then
            '        Dim fila As DataRow = dtCodigosErroneos.NewRow
            '        For Each columna As DataColumn In dtCodigo.Columns
            '            If columna.Caption = "TipoCodigo" Then
            '                fila(columna.Caption) = "CÓDIGO DUPLICADO"
            '            Else
            '                fila(columna.Caption) = row(columna.Caption)
            '            End If

            '        Next
            '        dtCodigosErroneos.Rows.Add(fila)
            '    Else
            '        Dim fila As DataRow = dtCodigosCorrectos.NewRow
            '        For Each columna As DataColumn In dtCodigo.Columns
            '            fila(columna.Caption) = row(columna.Caption)
            '        Next
            '        dtCodigosCorrectos.Rows.Add(fila)
            '    End If
            'Else
            '    Dim fila As DataRow = dtCodigosErroneos.NewRow
            '    For Each columna As DataColumn In dtCodigo.Columns
            '        fila(columna.Caption) = row(columna.Caption)
            '    Next
            '    dtCodigosErroneos.Rows.Add(fila)
            'End If
        Next
        grdConsultaLotes.DataSource = Nothing
        grdConsultaLotes.DataSource = dtCodigosCorrectos

        grdCodigosErroneos.DataSource = Nothing
        grdCodigosErroneos.DataSource = dtCodigosErroneos
        FormatoGrid()

        contarCantidades(dtCodigosCorrectos)

    End Sub

    Public Sub ExportarGrid(gridView As GridView, grid As GridControl, tipoCodigos As String)
        If gridView.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim exportOptions = New XlsxExportOptionsEx()

            exportOptions.ExportType = DevExpress.Export.ExportType.DataAware

            Try
                nombreReporte = "\MovimientosInventario_" & tipoCodigos & "_"
                nombreReporteParaExportacion = "Movimiento Inventario"
                exportOptions.SheetName = "MovimientosInventario"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = "Seleccione una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If gridView.GroupCount > 0 Then
                            gridView.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            grid.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            'grdReporte.ExportToXlsx()

                        End If
                        Dim ventanaExito As New Tools.ExitoForm
                        ventanaExito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        ventanaExito.ShowDialog()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Dim ventanaError As New Tools.ErroresForm
                ventanaError.mensaje = "Ocurrió un error " + ex.Message
                ventanaError.ShowDialog()
            End Try
        Else
            Dim ventanaAdvertencias As New Tools.AdvertenciaForm
            ventanaAdvertencias.mensaje = "No hay datos para exportar"
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Public Sub contarCantidades(tablaContendio As DataTable)
        Try

            Dim cantidadLotes = From lotes In tablaContendio.AsEnumerable()
                                Group lotes By
                                    Lote = lotes.Field(Of Integer)("Lote"),
                                    Anio = lotes.Field(Of Integer)("Año"),
                                    Nave = lotes.Field(Of String)("Nave")
                                Into resultado = Group, Sum(lotes.Field(Of Integer)("ID"))
                                Select Sum

            Dim cantidadAtados = From atados In tablaContendio.AsEnumerable()
                                 Group atados By
                                    Atado = atados.Field(Of String)("Atado")
                                Into resultado = Group, Count(atados.Field(Of Integer)("ID"))
                                 Select Count

            lblCantidadLotes.Text = cantidadLotes.ToList.Count.ToString
            lblCantidadAtados.Text = cantidadAtados.ToList.Count.ToString
            lblCantidadPares.Text = bgvConsultaLotes.RowCount
            lblCantidadCorrectos.Text = bgvConsultaLotes.RowCount
            lblCantidadConError.Text = bgvCodigosErroneos.RowCount
        Catch ex As Exception

        End Try
    End Sub

    Public Sub MostrarOcultarColumnasGrid()
        If chkMostrarColumnas.Checked = True Then
            bgvCodigosErroneos.OptionsView.ColumnAutoWidth = False

            bgvCodigosErroneos.Columns.Clear()
            grdCodigosErroneos.DataSource = Nothing
            grdCodigosErroneos.DataSource = dtCodigosErroneos

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCodigosErroneos.Columns
                ' Columnas ocultas para el Grid de códigos con error
                col.Visible = True
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            Next

            bgvCodigosErroneos.Columns.ColumnByFieldName("ID").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("CodigoSICY").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("IdTallaSicy").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("FechaEntrada").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("FechaSalida").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("PedidoOrigen").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("Pedido").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("Partida").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("Cliente").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("Apartado").Visible = False
            bgvCodigosErroneos.Columns.ColumnByFieldName("OT").Visible = False

            bgvCodigosErroneos.BestFitColumns()
        Else
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCodigosErroneos.Columns
                If col.FieldName <> "Par" And col.FieldName <> "TipoCodigo" Then
                    ' Columnas ocultas para el Grid de códigos con error
                    col.Visible = False
                Else
                    col.OptionsColumn.AllowEdit = False
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                End If
            Next
            bgvCodigosErroneos.OptionsView.ColumnAutoWidth = True
        End If
    End Sub

    Public Sub FormatoGrid()
        bgvConsultaLotes.OptionsView.ColumnAutoWidth = False
        bgvCodigosErroneos.OptionsView.ColumnAutoWidth = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvConsultaLotes.Columns
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            End If
        Next

        MostrarOcultarColumnasGrid()

        'For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCodigosErroneos.Columns
        '    If col.FieldName <> "Par" And col.FieldName <> "TipoCodigo" Then
        '        ' Columnas ocultas para el Grid de códigos con error
        '        col.Visible = False
        '    Else
        '        col.OptionsColumn.AllowEdit = False
        '        col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        '    End If
        'Next

        ' Columnas ocultas para el Grid de códigos correctos
        bgvConsultaLotes.Columns.ColumnByFieldName("ID").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("CodigoSICY").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("IdTallaSicy").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("FechaEntrada").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("FechaSalida").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("PedidoOrigen").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("Pedido").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("Partida").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("Cliente").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("Apartado").Visible = False
        bgvConsultaLotes.Columns.ColumnByFieldName("OT").Visible = False

        'bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        'bgvDevolucionesClientes.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        'bgvDevolucionesClientes.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"

        'SumarColumnas("CantCG", "{0:N0}")
        'SumarColumnas("Cajas", "{0:N0}")
        'SumarColumnas("Cantidad", "{0:N0}")
        'SumarColumnas("Total", "{0:N2}")


        'bgvDocumentos.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'bgvDocumentos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'bgvDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'bgvDocumentos.Columns.ColumnByFieldName("F Captura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        'bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        'bgvDocumentos.Columns.ColumnByFieldName("Cantidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'bgvDocumentos.Columns.ColumnByFieldName("Cancelados").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'bgvDocumentos.Columns.ColumnByFieldName("Total").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'bgvDocumentos.Columns.ColumnByFieldName("Monto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'bgvDocumentos.Columns.ColumnByFieldName("Tipo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        'bgvDocumentos.Columns.ColumnByFieldName("Notas de Crédito").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        'bgvDocumentos.Columns.ColumnByFieldName("Docto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("OT").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Razón Social").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("RFC Emisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("RFC Receptor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Capturó").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Moneda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Uso").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Fiscal").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Canceló").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Motivo Cancelación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Observación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Producto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Solicita").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Relación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        'bgvDocumentos.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"
        'bgvDocumentos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N0"
        'bgvDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatString = "N2"

        'bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        '        bgvDevolucionesClientes.Columns.ColumnByFieldName("St").Width = 20

        'bgvDocumentos.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Docto").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Factura").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("OT").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Razón Social").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("RFC Emisor").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("RFC Receptor").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("F Captura").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Capturó").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Cantidad").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Cancelados").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Total").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Monto").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Moneda").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Uso").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Fiscal").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Canceló").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Motivo Cancelación").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Observación").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Producto").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Solicita").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Relación").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Correo enviado").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Id SAY").OptionsColumn.AllowEdit = False
        'bgvDocumentos.Columns.ColumnByFieldName("Notas de Crédito").OptionsColumn.AllowEdit = False

        'bgvDocumentos.Columns.ColumnByFieldName("F Captura").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        'bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"


        'bgvDocumentos.Columns.ColumnByFieldName("Folio Rel").Caption = "Folios relacionados"
        'bgvDocumentos.Columns.ColumnByFieldName("Folio Sust").Caption = "Folios que sustituyen"


        bgvConsultaLotes.IndicatorWidth = 40
        bgvCodigosErroneos.IndicatorWidth = 40

        'bgvDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        bgvConsultaLotes.BestFitColumns()
        'bgvCodigosErroneos.BestFitColumns()
        'bgvDevolucionesClientes.Columns.ColumnByFieldName("St").Width = 20
        'bgvDevolucionesClientes.Columns.ColumnByFieldName("Rs").Width = 20
    End Sub

    Private Sub btnIniciarLectura_Click(sender As Object, e As EventArgs) Handles btnIniciarLectura.Click
        txtCodigo.Enabled = True
        txtCodigo.Select()
        btnIniciarLectura.Enabled = False
        btnDetenerLectura.Enabled = True
        btnExportarCorrectos.Enabled = False
        btnExportarErroneos.Enabled = False
        btnLeerArchivo.Enabled = False
        btnCerrar.Enabled = False
        btnGuardar.Enabled = False
        btnLimpiarCodigos.Enabled = False
        btnMostrarOcultarErroneos.Enabled = False
        cmbMovimiento.Enabled = False
    End Sub

    Private Sub btnDetenerLectura_Click(sender As Object, e As EventArgs) Handles btnDetenerLectura.Click
        txtCodigo.Enabled = False
        btnIniciarLectura.Enabled = True
        btnDetenerLectura.Enabled = False
        btnExportarCorrectos.Enabled = True
        btnExportarErroneos.Enabled = True
        btnLeerArchivo.Enabled = True
        btnCerrar.Enabled = True
        btnGuardar.Enabled = True
        'cmbMovimiento.Enabled = True
        btnLimpiarCodigos.Enabled = True
        btnMostrarOcultarErroneos.Enabled = True
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim codigo As String = txtCodigo.Text.Trim
            codigo = codigo.Replace("PC", "Y-000-") 'CarlosMtz (Replace Codigos Coppel)
            IIf(bgvConsultaLotes.DataRowCount = 0, primerCodigo = True, primerCodigo = False)
            ConsultarCodigo(codigo)
            txtCodigo.Text = ""
            txtCodigo.Select()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        e.Handled = Char.IsWhiteSpace(e.KeyChar)
        If e.KeyChar = "'" Then
            e.KeyChar = "-"
            Exit Sub
        End If

        If e.KeyChar = "-" Then
            Exit Sub
        End If

        If Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub bgvConsultaLotes_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvConsultaLotes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub LeerLineasArchivoCargado(ByVal ruta As String)
        Dim reader As New StreamReader(ruta)
        Dim linea As String = ""

        Dim arrArchivo As New ArrayList()
        Dim codigosLectura As String = ""

        Do
            linea = reader.ReadLine()
            If Not linea Is Nothing Then
                arrArchivo.Add(linea)
            End If
        Loop Until linea Is Nothing
        reader.Close()

        For Each elemento In arrArchivo
            If codigosLectura.Length > 0 Then
                codigosLectura += ","
            End If
            codigosLectura += elemento.ToString.Trim
        Next

        ConsultarCodigo(codigosLectura)

    End Sub

    Private Sub btnLeerArchivo_Click(sender As Object, e As EventArgs) Handles btnLeerArchivo.Click
        pgrsPnlCargando.ContentAlignment = ContentAlignment.MiddleCenter
        pgrsPnlCargando.Top = (Me.Height - pgrsPnlCargando.Height) / 2
        pgrsPnlCargando.Left = (Me.Width - pgrsPnlCargando.Width) / 2
        pgrsPnlCargando.Description = "Cargando códigos..."
        pgrsPnlCargando.Show()
        pgrsPnlCargando.Refresh()

        Dim myStream As Stream = Nothing
        Dim openFileDialog As New OpenFileDialog
        Dim MensajeError As New Tools.ErroresForm
        Dim MensajeAviso As New Tools.AvisoForm
        openFileDialog.InitialDirectory = "c:\"
        openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"
        openFileDialog.FilterIndex = 2
        openFileDialog.RestoreDirectory = True

        MensajeAviso.mensaje = "Este proceso puede tardar dependiendo de la cantidad de pares a validar"
        MensajeAviso.ShowDialog()
        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Try
                myStream = openFileDialog.OpenFile()
                If (openFileDialog.FileName IsNot Nothing) Then

                    LeerLineasArchivoCargado(openFileDialog.FileName)

                End If
            Catch Ex As Exception
                MensajeError.mensaje = "No se puede leer el archivo. Ocurrió un error: " & Ex.Message
                MensajeError.ShowDialog()
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
            Me.Cursor = Cursors.Default
        End If
        pgrsPnlCargando.Hide()
    End Sub

    Private Sub bgvCodigosErroneos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvCodigosErroneos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportarCorrectos_Click(sender As Object, e As EventArgs) Handles btnExportarCorrectos.Click
        ExportarGrid(bgvConsultaLotes, grdConsultaLotes, "Correctos")
    End Sub

    Private Sub btnExportarErroneos_Click(sender As Object, e As EventArgs) Handles btnExportarErroneos.Click
        ExportarGrid(bgvCodigosErroneos, grdCodigosErroneos, "Erroneos")
    End Sub

    Private Sub btnOcultarMostrarPedidos_Click(sender As Object, e As EventArgs) Handles btnMostrarOcultarErroneos.Click
        If spltContenedorGridCodigos.Panel2Collapsed = True Then
            spltContenedorGridCodigos.Panel2Collapsed = False
            spltContenedorGridCodigos.Panel2.Show()
        Else
            spltContenedorGridCodigos.Panel2Collapsed = True
            spltContenedorGridCodigos.Panel2.Hide()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbMovimiento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMovimiento.SelectedValueChanged

        If cmbMovimiento.SelectedIndex = 0 Then
            pnlRestricciones.Visible = False
            MostrarOcultarEtiquetas(False)
        ElseIf cmbMovimiento.SelectedValue.ToString.Length > 0 Then
            For Each row As DataRow In dtMovimientos.Rows
                If cmbMovimiento.SelectedValue.ToString = row("TipoMovimiento_ID").ToString Then
                    txtRestricciones.Text = row("Descripcion")
                    pnlRestricciones.Visible = True
                    Return
                End If
            Next
        End If

        txtRestricciones.Text = ""
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        pgrsPnlCargando.ContentAlignment = ContentAlignment.MiddleCenter
        pgrsPnlCargando.Top = (Me.Height - pgrsPnlCargando.Height) / 2
        pgrsPnlCargando.Left = (Me.Width - pgrsPnlCargando.Width) / 2
        pgrsPnlCargando.Description = "Guardando cambios..."
        pgrsPnlCargando.Show()
        pgrsPnlCargando.Refresh()

        If cmbMovimiento.SelectedValue Is Nothing Then Return
        If cmbMovimiento.SelectedValue.ToString.Trim.Length = 0 Then
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Seleccione un movimiento"
            ventanaAdvertencia.ShowDialog()
            Return
        End If

        Dim listaFoliosDev As New List(Of String)
        Dim foliosDev As String = ""
        Dim pares As String = ""
        Dim NumeroFilas = bgvConsultaLotes.DataRowCount

        For index As Integer = 0 To NumeroFilas - 1 Step 1
            Dim repetido As Boolean = False
            If pares.Length > 0 Then pares += ","
            pares += bgvConsultaLotes.GetRowCellValue(index, "Par").ToString
            For Each elemento In listaFoliosDev
                If elemento = bgvConsultaLotes.GetRowCellValue(index, "DevSAY").ToString Then
                    repetido = True
                End If
            Next
            If repetido = False Then
                listaFoliosDev.Add(bgvConsultaLotes.GetRowCellValue(index, "DevSAY").ToString)
                If foliosDev.Length > 0 Then foliosDev += ","
                foliosDev += bgvConsultaLotes.GetRowCellValue(index, "DevSAY").ToString
            End If
        Next

        If lblPares.Text = lblCantidadCorrectos.Text Then
            Dim negocios As New Negocios.MovimientosInventario_BU
            negocios.RegistrarMovimientoInv(cmbMovimiento.SelectedValue, pares, foliosDev, destinoID)

            Dim ventanaExito As New Tools.ExitoForm
            ventanaExito.mensaje = "Movimiento Generado con Éxito"
            ventanaExito.ShowDialog()

            MostrarOcultarEtiquetas(False)
            grdConsultaLotes.DataSource = Nothing
            grdCodigosErroneos.DataSource = Nothing
            cmbMovimiento.SelectedIndex = 0
            cmbMovimiento.Enabled = True
            pnlRestricciones.Visible = True
            lblCantidadLotes.Text = "0"
            lblCantidadAtados.Text = "0"
            lblCantidadPares.Text = "0"
            lblCantidadCorrectos.Text = "0"
            lblCantidadConError.Text = "0"
            chkMostrarColumnas.Checked = False

            pgrsPnlCargando.Hide()
        Else
            Dim ventanaExito As New Tools.AdvertenciaForm
            ventanaExito.mensaje = "La cantidad ingresada no coincide con la cantidad de la devolución"
            ventanaExito.ShowDialog()
        End If

    End Sub

    Private Sub chkMostrarColumnas_CheckedChanged(sender As Object, e As EventArgs) Handles chkMostrarColumnas.CheckedChanged
        MostrarOcultarColumnasGrid()
    End Sub

    Private Sub btnLimpiarCodigos_Click(sender As Object, e As EventArgs) Handles btnLimpiarCodigos.Click
        If bgvConsultaLotes.DataRowCount > 0 Or bgvCodigosErroneos.DataRowCount > 0 Then
            Dim ventanaConfirmacion As New Tools.ConfirmarForm
            ventanaConfirmacion.mensaje = "Se eliminarán los códigos erróneos y correctos" + vbCrLf + "¿Desea continuar?"
            ventanaConfirmacion.ShowDialog()

            If ventanaConfirmacion.DialogResult = DialogResult.OK Then
                grdConsultaLotes.DataSource = Nothing
                grdCodigosErroneos.DataSource = Nothing
                cmbMovimiento.SelectedIndex = 0
                cmbMovimiento.Enabled = True
                pnlRestricciones.Visible = True
                lblCantidadLotes.Text = "0"
                lblCantidadAtados.Text = "0"
                lblCantidadPares.Text = "0"
                lblCantidadCorrectos.Text = "0"
                lblCantidadConError.Text = "0"
                chkMostrarColumnas.Checked = False
            End If
        Else
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "Aún no se han capturado códigos"
            ventanaAdvertencia.ShowDialog()
        End If
    End Sub
End Class