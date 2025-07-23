Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Stimulsoft.Report
Imports Tools

Public Class EntregaPagosProveedorForm
    Dim listaInicial As New List(Of String)
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm

    Dim ProveedorId As Integer = 0
    Dim Recibo As Integer = 0
    Dim Usuario As String = String.Empty

    Private Sub EntregaPagosProveedorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdProveedor.DataSource = listaInicial
        lblTotalSeleccionados.Text = 0
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New EntregarPagosProveedorBU
        Dim FProveedor As String = String.Empty
        Dim dtConsultaEntregaPagos As New DataTable

        grdProveedoresPago.DataSource = Nothing
        MVProveedoresPago.Columns.Clear()


        FProveedor = ObtenerFiltrosGrid(grdProveedor)
        Try
            Cursor = Cursors.WaitCursor
            dtConsultaEntregaPagos = objBU.ObtenerDocumentosaPagar(FProveedor)

            If dtConsultaEntregaPagos.Rows.Count > 0 Then
                grdProveedoresPago.DataSource = dtConsultaEntregaPagos
                lblTotalSeleccionados.Text = "0"
                MVProveedoresPago.OptionsSelection.MultiSelect = True
                lblTotalSeleccionados.Text = CDbl(MVProveedoresPago.RowCount.ToString()).ToString("n0")
                disenioGrid()
                lblFechaUltimaActualización.Text = Date.Now
            Else
                objAdvertencia.mensaje = "No hay información de documentos para pago."
                objAdvertencia.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub


    Public Sub EjecutarEntregaPagos()
        Dim objBU As New EntregarPagosProveedorBU
        Dim lstRenglonesEditados As New List(Of Entidades.EntregaPagosProveedor)
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim confirmar As New ConfirmarForm
        Dim dtResultadoConsulta As New DataTable

        Try
            lstRenglonesEditados = obtenerRenglonesEditadosEntregar()

            If lstRenglonesEditados.Count > 0 Then
                Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                For Each item In lstRenglonesEditados
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("idproveedor", item.PProveedorId))
                    vNodo.Add(New XAttribute("añosemana", item.PAñoPago))
                    vNodo.Add(New XAttribute("semana", item.PSemanaPago))
                    vNodo.Add(New XAttribute("usunombre", item.PUsuarioNombre))
                    vXmlCeldasModificadas.Add(vNodo)
                Next


                dtResultadoConsulta = objBU.ActualizaPagosProveedor(vXmlCeldasModificadas.ToString())

            End If


        Catch ex As Exception

        End Try


    End Sub


    Private Sub btnAplicarPago_Click(sender As Object, e As EventArgs) Handles btnAplicarPago.Click
        Dim objBU As New EntregarPagosProveedorBU
        Dim lstRenglonesEditados As New List(Of Entidades.EntregaPagosProveedor)
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim confirmar As New ConfirmarForm
        Dim NumeroFilas = MVProveedoresPago.DataRowCount
        Dim prueba As Integer = 0
        Dim lstProveedorId As New List(Of String)
        Dim dtActualizaTablasPago As New DataTable

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(MVProveedoresPago.IsRowSelected(MVProveedoresPago.GetVisibleRowHandle(index))) = True Then
                If lstProveedorId.Contains(MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "idproveedor").ToString()) = False Then
                    lstProveedorId.Add(MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "idproveedor").ToString())
                End If
            End If
        Next

        Try
            If lstProveedorId.Count >= 2 Then
                advertencia.mensaje = "Seleccione documentos de un solo proveedor."
                advertencia.ShowDialog()
            Else

                lstRenglonesEditados = obtenerRenglonesEditadosEntregar()

                If lstRenglonesEditados.Count > 0 Then
                    confirmar.mensaje = "¿Está seguro de realizar el pago de los documentos seleccionados.?"
                    If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Cursor = Cursors.WaitCursor
                        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                        For Each item In lstRenglonesEditados
                            Dim vNodo As XElement = New XElement("Celda")
                            vNodo.Add(New XAttribute("idtabla", item.PIdTabla))
                            vNodo.Add(New XAttribute("tipo", item.PTipo))
                            vNodo.Add(New XAttribute("UsuarioId", item.PUsuarioId))
                            vNodo.Add(New XAttribute("idproveedor", item.PProveedorId))
                            vNodo.Add(New XAttribute("semana", item.PSemanaPago))
                            vNodo.Add(New XAttribute("añosemana", item.PAñoPago))
                            vNodo.Add(New XAttribute("nave", item.PNaveId))
                            vNodo.Add(New XAttribute("formaPago", item.PFormaPago))

                            vXmlCeldasModificadas.Add(vNodo)
                        Next
                        dtActualizaTablasPago = objBU.ActualizaTablaEntregaPagos(vXmlCeldasModificadas.ToString())

                        If dtActualizaTablasPago.Rows(0).Item("respuesta").ToString() = "ERROR" Then
                            advertencia.mensaje = "Ocurrió un error al generar los pagos."
                            advertencia.ShowDialog()
                        Else
                            ImprimirReciboPago()
                            confirmar.mensaje = "¿Se imprimieron correctamente los recibos?"
                            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK = True Then
                                objBU.InsertaRecibo(ProveedorId, Usuario, Recibo)
                                EjecutarEntregaPagos()
                                exito.mensaje = "Pagos aplicados correctamente."
                                exito.ShowDialog()
                                btnMostrar_Click(Nothing, Nothing)
                            Else
                                advertencia.mensaje = "Se canceló la entrega de pagos."
                                advertencia.ShowDialog()

                            End If
                        End If
                    End If

                    Else
                    advertencia.mensaje = "No existen pagos que aplicar."
                    advertencia.ShowDialog()
                End If

            End If

        Catch ex As Exception
            objErrores.mensaje = "Ocurrió un error aplicando los pagos."
            objErrores.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub ImprimirReciboPago()
        Dim objBU As New EntregarPagosProveedorBU
        Dim lstRenglonesEditados As New List(Of Entidades.EntregaPagosProveedor)
        Dim dtEncabezadoReporte As New DataTable
        Dim dtEncabezadoPrevio As New DataTable
        Dim dtTiposPago As New DataTable
        Dim dtConcentradoReporte As New DataTable("dtPagosProveedor")
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim confirmar As New ConfirmarForm
        Dim lstEncabezado As New List(Of String)
        Dim lstTiposPago As New List(Of String)
        ' Dim ProveedorId As Integer = 0
        ' Dim Recibo As Integer = 0
        ' Dim Usuario As String = String.Empty
        Dim sumChequeEndosado As Double = 0
        Dim sumCheque As Double = 0
        Dim sumEfectivo As Double = 0
        Dim sumTransferencia As Double = 0
        Dim granTotal As Double = 0
        Dim FechaRecibo As String = Date.Now.ToShortDateString


        Try
            lstRenglonesEditados = obtenerRenglonesEditadosEntregar()

            If lstRenglonesEditados.Count > 0 Then
                For Each item In lstRenglonesEditados
                    ProveedorId = item.PProveedorId.ToString()
                    Recibo = item.PSiguienteFolio.ToString()
                    Usuario = item.PUsuarioNombre.ToString()
                Next

                ' objBU.InsertaRecibo(ProveedorId, Usuario, Recibo)

                dtEncabezadoReporte = objBU.ObtieneReciboPagoEncabezado(ProveedorId, Recibo, Usuario)
                dtConcentradoReporte = objBU.ObtieneReciboPagoDetalles(ProveedorId, Recibo)

                'dtEncabezadoReporte = dtEncabezadoPrevio.Clone()

                If dtEncabezadoReporte.Rows.Count > 0 And dtConcentradoReporte.Rows.Count > 0 Then
                    'For Each Filas As DataRow In dtEncabezadoPrevio.Rows
                    '    If lstEncabezado.Contains((Filas.Item("Recibo").ToString)) = False Then
                    '        dtEncabezadoReporte.ImportRow(Filas)
                    '        lstEncabezado.Add((Filas.Item("Recibo").ToString))
                    '    End If
                    'Next

                    For Each Filas As DataRow In dtEncabezadoReporte.Rows
                        If lstTiposPago.Contains((Filas.Item("FormaPago").ToString)) = False Then
                            lstTiposPago.Add((Filas.Item("FormaPago").ToString))
                        End If
                    Next

                    dtTiposPago.Columns.Add("FormaPago", System.Type.GetType("System.String"))

                    For Each Fila As String In lstTiposPago
                        dtTiposPago.Rows.Add(Fila)
                    Next


                    Dim ObjBUReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    Dim dsPagosProveedor As New DataSet("dsPagosProveedor")

                    Cursor = Cursors.WaitCursor

                    dtConcentradoReporte.TableName = "dtPagosProveedor"
                    dtEncabezadoReporte.TableName = "dtEncabezadoReporte"
                    dtTiposPago.TableName = "dtTiposPago"
                    dsPagosProveedor.Tables.Add(dtConcentradoReporte)
                    dsPagosProveedor.Tables.Add(dtEncabezadoReporte)
                    dsPagosProveedor.Tables.Add(dtTiposPago)

                    For Each fila As DataRow In dtEncabezadoReporte.Rows
                        If fila.Item("FormaPago").ToString = "CHEQUE ENDOSADO" And fila.Item("usuario").ToString <> "" Then
                            sumChequeEndosado += CDbl(fila.Item("ImportePago").ToString)
                        ElseIf fila.Item("FormaPago").ToString = "CHEQUE" And fila.Item("usuario").ToString <> "" Then
                            sumCheque += CDbl(fila.Item("ImportePago").ToString)
                        ElseIf fila.Item("FormaPago").ToString = "EFECTIVO" And fila.Item("usuario").ToString <> "" Then
                            sumEfectivo += CDbl(fila.Item("ImportePago").ToString)
                        ElseIf fila.Item("FormaPago").ToString = "TRANSFERENCIA" And fila.Item("usuario").ToString <> "" Then
                            sumTransferencia += CDbl(fila.Item("ImportePago").ToString)
                        End If
                    Next

                    granTotal = sumCheque + sumChequeEndosado + sumEfectivo + sumTransferencia

                    EntidadReporte = ObjBUReporte.LeerReporteporClave("REC_PAGOPROV")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport



                    reporte.Load(archivo)
                    reporte.Compile()

                    reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                    reporte("NombreEntrega") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
                    reporte("Nave") = dtEncabezadoReporte.Rows(0).Item("Nave").ToString
                    reporte("Recibo") = dtEncabezadoReporte.Rows(0).Item("Recibo").ToString
                    reporte("sumChequeEndosado") = sumChequeEndosado
                    reporte("sumCheque") = sumCheque
                    reporte("sumEfectivo") = sumEfectivo
                    reporte("sumTransferencia") = sumTransferencia
                    reporte("granTotal") = granTotal
                    reporte("Proveedor") = dtEncabezadoReporte.Rows(0).Item("Proveedor").ToString
                    reporte("FechaRecibo") = FechaRecibo
                    reporte.Dictionary.Clear()

                    reporte.RegData(dsPagosProveedor)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()

                    Cursor = Cursors.Default
                End If
            Else
                objAdvertencia.mensaje = "No hay información para imprimir."
                objAdvertencia.ShowDialog()
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            advertencia.mensaje = "Ocurrio un error al imprimir el recibo."
            advertencia.ShowDialog()
        End Try
    End Sub



    Private Function obtenerRenglonesEditadosEntregar() As List(Of Entidades.EntregaPagosProveedor)
        Dim NumeroFilas As Integer = MVProveedoresPago.DataRowCount
        Dim lstRenglonesEditados As New List(Of Entidades.EntregaPagosProveedor)
        Dim datosPago As Entidades.EntregaPagosProveedor
        Dim ultimoRecibo As String = String.Empty
        Dim objBU As New EntregarPagosProveedorBU
        Dim dtUltimoRecibo As New DataTable


        Try


            dtUltimoRecibo = objBU.SiguienteRecibo()
            ultimoRecibo = dtUltimoRecibo.Rows(0).Item(0).ToString

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "Seleccionar")) = True Then


                    datosPago = New Entidades.EntregaPagosProveedor
                    datosPago.PIdTabla = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "idtabla")
                    datosPago.PTipo = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "tipo")
                    datosPago.PUsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    datosPago.PProveedorId = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "idproveedor")
                    datosPago.PSemanaPago = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "semana")
                    datosPago.PAñoPago = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "añosemana")
                    datosPago.PNaveId = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "nave")
                    datosPago.PUsuarioNombre = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    datosPago.PSiguienteFolio = ultimoRecibo
                    datosPago.PFormaPago = MVProveedoresPago.GetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "formapago")
                    lstRenglonesEditados.Add(datosPago)

                    'ultimoRecibo += 1

                End If
            Next

        Catch ex As Exception

        End Try
        Return lstRenglonesEditados
    End Function



    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click
        Dim listado As New ListadoParametrosProveedorForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdProveedor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroId = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdProveedor.DataSource = listado.listaParametros
        With grdProveedor
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Proveedor"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next
        Return Resultado
    End Function

    Public Sub disenioGrid()

        MVProveedoresPago.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVProveedoresPago.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVProveedoresPago.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVProveedoresPago.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVProveedoresPago.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVProveedoresPago.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

        Next


        MVProveedoresPago.Columns.ColumnByFieldName("nombreNave").Caption = "Nave"
        MVProveedoresPago.Columns.ColumnByFieldName("razonsocial").Caption = "Razón Social"
        MVProveedoresPago.Columns.ColumnByFieldName("nomcomercial").Caption = "Nombre Comercial"
        MVProveedoresPago.Columns.ColumnByFieldName("descripcion").Caption = "Forma Pago"
        MVProveedoresPago.Columns.ColumnByFieldName("añosemana").Caption = "Año"
        MVProveedoresPago.Columns.ColumnByFieldName("semana").Caption = "Semana Pago"
        MVProveedoresPago.Columns.ColumnByFieldName("imppago").Caption = "Total a Pagar"
        MVProveedoresPago.Columns.ColumnByFieldName("banco").Caption = "Banco"
        MVProveedoresPago.Columns.ColumnByFieldName("cheque").Caption = "Cheque"
        MVProveedoresPago.Columns.ColumnByFieldName("rfc").Caption = "RFC"
        MVProveedoresPago.Columns.ColumnByFieldName("Seleccionar").Caption = "Entregar"
        MVProveedoresPago.Columns.ColumnByFieldName("registro").Caption = "Último Registro"


        MVProveedoresPago.Columns.ColumnByFieldName("nombreNave").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("razonsocial").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("nomcomercial").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("descripcion").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("añosemana").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("semana").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("imppago").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("banco").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("cheque").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("rfc").OptionsColumn.AllowEdit = False
        MVProveedoresPago.Columns.ColumnByFieldName("registro").OptionsColumn.AllowEdit = False


        MVProveedoresPago.Columns.ColumnByFieldName("razonsocial").Width = 250
        MVProveedoresPago.Columns.ColumnByFieldName("nomcomercial").Width = 150
        MVProveedoresPago.Columns.ColumnByFieldName("Seleccionar").Width = 50
        MVProveedoresPago.Columns.ColumnByFieldName("#").Width = 20

        MVProveedoresPago.Columns.ColumnByFieldName("nombreNave").Width = 100
        MVProveedoresPago.Columns.ColumnByFieldName("rfc").Width = 100
        MVProveedoresPago.Columns.ColumnByFieldName("banco").Width = 100
        MVProveedoresPago.Columns.ColumnByFieldName("descripcion").Width = 150
        MVProveedoresPago.Columns.ColumnByFieldName("registro").Width = 150
        MVProveedoresPago.Columns.ColumnByFieldName("cheque").Width = 50



        MVProveedoresPago.Columns.ColumnByFieldName("tipo").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("idtabla").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("formapago").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("domicilio").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("ciudad").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("nave").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("imprimerecibo").Visible = False
        MVProveedoresPago.Columns.ColumnByFieldName("idproveedor").Visible = False

        MVProveedoresPago.Columns.ColumnByFieldName("cheque").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        MVProveedoresPago.Columns.ColumnByFieldName("#").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        MVProveedoresPago.Columns.ColumnByFieldName("imppago").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVProveedoresPago.Columns.ColumnByFieldName("imppago").DisplayFormat.FormatString = "N0"
        MVProveedoresPago.Columns.ColumnByFieldName("registro").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        MVProveedoresPago.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(MVProveedoresPago.Columns("imppago").Summary.FirstOrDefault(Function(x) x.FieldName = "imppago")) = True Then
            MVProveedoresPago.Columns("imppago").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "imppago", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "imppago"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVProveedoresPago.GroupSummary.Add(item)
        End If





    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVProveedoresPago.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub



    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarProveedor_Click(sender As Object, e As EventArgs) Handles btnLimpiarProveedor.Click
        grdProveedor.DataSource = listaInicial
    End Sub

    Private Sub grdProveedor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProveedor.InitializeLayout
        grid_diseño(grdProveedor)
        grdProveedor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Proveedores"
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim consultaReciboForm As New ConsultaReciboForm
        consultaReciboForm.Show()
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbParametros.Height = 150
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        grbParametros.Height = 30
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = MVProveedoresPago.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                MVProveedoresPago.SetRowCellValue(MVProveedoresPago.GetVisibleRowHandle(index), "Seleccionar", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdProveedor.DataSource = listaInicial
        grdProveedoresPago.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
    End Sub


End Class