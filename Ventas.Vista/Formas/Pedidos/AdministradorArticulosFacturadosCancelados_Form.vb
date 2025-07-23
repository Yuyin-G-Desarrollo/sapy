Imports DevExpress
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class AdministradorArticulosFacturadosCancelados_Form
    Private lstInicial As List(Of String)
    Private objBu As New Negocios.ReporteArticulosFacturadosCanceladosBU
    Private tamanioPanelFiltro As Integer = 0
    Private listadoFiltro As New ListadoParametrosProyeccionEntregasForm
    Private listPedidoSAY As New List(Of String)
    Private listPedidoSICY As New List(Of String)

    Private Sub AdministradorArticulosFacturadosCancelados_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tamanioPanelFiltro = pnlFiltrosDos.Height
        ActualizarBusquedaFecha()

        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub OcultarFiltros()
        pnlFiltrosDos.Height = 0
    End Sub

    Private Sub MostrarFiltros()
        pnlFiltrosDos.Height = tamanioPanelFiltro
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Mostrar()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        reiniciarGridTodos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosArticulosFacturados.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdDatosArticulosFacturados.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosArticulosFacturados.OptionsPrint.AutoWidth = False
                            grdDatosArticulosFacturados.OptionsPrint.UsePrintStyles = False

                            Dim FileName As String = .SelectedPath + "\Datos_ArticulosFacturadosCancelados_" + fecha_hora + ".xlsx"

                            Export.ExportSettings.DefaultExportType = Export.ExportType.WYSIWYG
                            grdDatosArticulosFacturados.ExportToXlsx(FileName)

                            Tools.MostrarMensaje(Tools.Mensajes.Success, "Los datos se exportaron correctamente.")

                            Process.Start(FileName)

                        Else
                            Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay registros para exportar.")
                        End If
                    End If
                End With
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No hay datos para exportar")
            End If
        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "No se pudo exportar los datos: " + ex.Message.ToString())
        End Try
    End Sub

    Private Sub reiniciarGrid(grdFiltro As UltraGrid)
        grdFiltro.DataSource = lstInicial
    End Sub

    Private Sub reiniciarGridTodos()
        reiniciarGrid(grdPedidoSAY)
        reiniciarGrid(grdPedidoSICY)
        reiniciarGrid(grdCliente)
        reiniciarGrid(grdRFC)
        reiniciarGrid(grdNave)

        chkBuscarPorFecha.Checked = False
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now

        grdArticulosFacturados.DataSource = Nothing
    End Sub

    Private Sub Mostrar()
        Dim dtResultado As New DataTable()
        Dim buscarPorFecha As Boolean = False
        Dim fechaInicio As DateTime = Now
        Dim fechaFin As DateTime = Now
        Dim pedidoSAY As String = String.Empty
        Dim pedidoSICY As String = String.Empty
        Dim cliente As String = String.Empty
        Dim rFC As String = String.Empty
        Dim nave As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor

            grdArticulosFacturados.DataSource = Nothing

            buscarPorFecha = chkBuscarPorFecha.Checked
            fechaInicio = dtpFechaInicio.Value
            fechaFin = dtpFechaFin.Value

            pedidoSAY = RecuperarFiltroGrid(grdPedidoSAY)
            pedidoSICY = RecuperarFiltroGrid(grdPedidoSICY)
            cliente = RecuperarFiltroGrid(grdCliente)
            rFC = RecuperarFiltroGrid(grdRFC)
            nave = RecuperarFiltroGrid(grdNave)

            dtResultado = objBu.ConsultarArticulosFacturadosCancelados(buscarPorFecha, fechaInicio, fechaFin, pedidoSAY, pedidoSICY, cliente, rFC, nave)

            If dtResultado.Rows.Count > 0 Then
                dtResultado.DefaultView.Sort = "pedidoSAY DESC"
                grdArticulosFacturados.DataSource = dtResultado
                DisenioGrid()
                OcultarFiltros()
            Else
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
            End If

            ActualizarConteoyFechaConsulta()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ActualizarConteoyFechaConsulta()
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "Hubo un error al generar los datos para mostrar, intente de nuevo " + ex.Message)
        End Try
    End Sub

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosArticulosFacturados.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub

    Private Sub DisenioGrid()

        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosArticulosFacturados)

        grdDatosArticulosFacturados.Columns("pedidoSAY").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosArticulosFacturados.Columns("pedidoSAY").Width = 80
        grdDatosArticulosFacturados.Columns("pedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
        grdDatosArticulosFacturados.Columns("cliente").Caption = "Cliente"
        grdDatosArticulosFacturados.Columns("MarcaSAY").Caption = "Marca SAY"
        grdDatosArticulosFacturados.Columns("ModeloSAY").Caption = "Modelo SAY"
        grdDatosArticulosFacturados.Columns("ModeloSICY").Caption = "Modelo SICY"
        grdDatosArticulosFacturados.Columns("ColeccionSAY").Caption = "Colección" + vbCrLf + "SAY"
        grdDatosArticulosFacturados.Columns("Piel").Caption = "Piel"
        grdDatosArticulosFacturados.Columns("Color").Caption = "Color"
        grdDatosArticulosFacturados.Columns("Talla").Caption = "Talla"
        grdDatosArticulosFacturados.Columns("Color").Caption = "Color"
        grdDatosArticulosFacturados.Columns("nave").Caption = "Nave"
        grdDatosArticulosFacturados.Columns("pares").Caption = "Pares"
        grdDatosArticulosFacturados.Columns("FEntradaAlmacen").Caption = "F Entrada" + vbCrLf + "Almacén"
        grdDatosArticulosFacturados.Columns("remision").Caption = "Remisión"
        grdDatosArticulosFacturados.Columns("anioRemision").Caption = "Año"
        grdDatosArticulosFacturados.Columns("folio").Caption = "Folio"
        grdDatosArticulosFacturados.Columns("fVenta").Caption = "FVenta"
        grdDatosArticulosFacturados.Columns("razonSocial").Caption = "Razón Social" + vbCrLf + "Emisor"


        grdDatosArticulosFacturados.Columns("pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosArticulosFacturados.Columns("pares").DisplayFormat.FormatString = "n0"

        CrearSummarAlPiePantalla()

        grdDatosArticulosFacturados.Columns("cliente").Width = 230
        grdDatosArticulosFacturados.Columns("ColeccionSAY").Width = 150
        grdDatosArticulosFacturados.Columns("nave").Width = 80
        grdDatosArticulosFacturados.Columns("razonSocial").Width = 200
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grdDatosArticulosFacturados.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosArticulosFacturados.GroupSummary.Clear()

        For index = 0 To grdDatosArticulosFacturados.Columns.Count - 1
            If grdDatosArticulosFacturados.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grdDatosArticulosFacturados.Columns(index).Name.Replace("col", "")

                grdDatosArticulosFacturados.Columns(index).Summary.Clear()
                grdDatosArticulosFacturados.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grdDatosArticulosFacturados.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grdDatosArticulosFacturados.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grdDatosArticulosFacturados.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Function RecuperarFiltroGrid(grid As UltraGrid) As String
        Dim resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                resultado += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                resultado += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return resultado
    End Function

    Private Sub abrirSeleccionFiltro(grdFiltro As UltraGrid, tipoBusqueda As Integer)
        listadoFiltro.tipo_busqueda = tipoBusqueda
        listadoFiltro.ClientesID = String.Empty
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltro.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listadoFiltro.listaParametroID = listaParametroID
        listadoFiltro.ShowDialog(Me)
        If Not listadoFiltro.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listadoFiltro.listParametros.Rows.Count = 0 Then Return

        grdFiltro.DataSource = listadoFiltro.listParametros

        For i = 0 To grdFiltro.DisplayLayout.Bands(0).Columns.Count - 1
            grdFiltro.DisplayLayout.Bands(0).Columns(IIf(i <> 2, i, 0)).Hidden = True
        Next
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        OcultarFiltros()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        MostrarFiltros()
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        abrirSeleccionFiltro(grdCliente, 1)
    End Sub

    Private Sub btnAgregarFiltroRFC_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroRFC.Click
        'listadoFiltro.ClientesID = String.Empty
        abrirSeleccionFiltro(grdRFC, 16)
    End Sub

    Private Sub btnAgregarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroNave.Click
        abrirSeleccionFiltro(grdNave, 18)
    End Sub

    Private Sub btnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        reiniciarGrid(grdNave)
    End Sub

    Private Sub btnLimpiarFiltroRFC_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroRFC.Click
        reiniciarGrid(grdRFC)
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        reiniciarGrid(grdCliente)
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If

        Next
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "P SAY"
    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "P SICY"
    End Sub

    Private Sub grdRFC_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRFC.InitializeLayout
        grid_diseño(grdRFC)
        grdRFC.DisplayLayout.Bands(0).Columns(0).Header.Caption = "RFC"
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
        grdNave.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub


    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdRFC_KeyDown(sender As Object, e As KeyEventArgs) Handles grdRFC.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdRFC.DeleteSelectedRows(False)
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub btnLimpiarFiltroPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSAY.Click
        reiniciarGrid(grdPedidoSAY)
        listPedidoSAY.Clear()
    End Sub

    Private Sub btnLimpiarFiltroPedidoSICY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSICY.Click
        reiniciarGrid(grdPedidoSICY)
        listPedidoSICY.Clear()
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub chkBuscarPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscarPorFecha.CheckedChanged
        ActualizarBusquedaFecha()
    End Sub

    Private Sub ActualizarBusquedaFecha()
        Dim activo = chkBuscarPorFecha.Checked
        dtpFechaInicio.Enabled = activo
        dtpFechaFin.Enabled = activo
    End Sub

    Private Sub grdDatosArticulosFacturados_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosArticulosFacturados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class