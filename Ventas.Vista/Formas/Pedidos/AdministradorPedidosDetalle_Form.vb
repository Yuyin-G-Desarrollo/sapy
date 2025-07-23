Imports System.Text
Imports DevExpress
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class AdministradorPedidosDetalle_Form
#Region "Variables"
    'Iniciales
    Private objBu As New Negocios.AdministradorPedidosEscritorioBU
    Private entPedido As Entidades.InfoPedido
    Private tamanioPanelFiltro As Integer = 0
    Private WithEvents repositorioChkSeleccionar As New RepositoryItemCheckEdit
    Private WithEvents toolTipoEtiquetaTiendaCompleta As New ToolTipController
    Private WithEvents toolTipoItemVerOT As New ToolStripMenuItem
    Private WithEvents toolTipoItemVerFactura As New ToolStripMenuItem
    Private pedidoSeleccionado As Integer = 0
    Private partidaSeleccionado As Integer = 0
    Private DtPedidos As New DataTable
#End Region

    Private Sub AdministradorPedidosDetalle_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DtPedidos.Columns.Add("Pedido")
        DtPedidos.Columns.Add("Partida")
        DtPedidos.Columns.Add("Cancelado", GetType(Boolean))

        BloquearInfoPedido()
        RecuperarInformacionPedido()
        tamanioPanelFiltro = pnlInformacion.Height
        grdPedidoDetalle.ToolTipController = toolTipoEtiquetaTiendaCompleta
        permisos()
    End Sub
#Region "PERMISOS"
    Public Sub permisos()
        'PERMISO PARA NO VER EL BOTON DE CANCELAR PEDIDO
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ADMON_MOD_PEDIDOS", "CANCELAR_PEDIDO") Then
            pnlCancelarPedido.Visible = False
        Else
            pnlCancelarPedido.Visible = True
        End If
    End Sub
#End Region

#Region "Eventos"

    Private Sub grdDatosPedidoDetalles_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdDatosPedidoDetalles.RowCellStyle
        ColorearRegistros(e)
    End Sub

    Private Sub AdministradorPedidosDetalle_Form_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Mostrar()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarExcel()
    End Sub

    Private Sub btnCancelarPartida_Click(sender As Object, e As EventArgs) Handles btnCancelarPartida.Click
        AbrirMotivoCancelacionPedido()
    End Sub

    Private Sub btnVerLotes_Click(sender As Object, e As EventArgs) Handles btnVerLotes.Click
        AbrirConsultaLotes()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub grdDatosPedidoDetalles_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub MarcarSeleccionado(ByVal sender As Object, ByVal e As EventArgs) Handles repositorioChkSeleccionar.CheckedChanged
        Dim fila = IIf(grdDatosPedidoDetalles.GetSelectedRows.Count > 0, grdDatosPedidoDetalles.GetSelectedRows(0), -1)
        Dim seleccionado As Boolean = False
        Dim partida As Integer = grdDatosPedidoDetalles.GetRowCellValue(fila, "partida")
        Dim partidaAnterior As Integer = -1
        Dim estatus As String = String.Empty

        Try
            If fila < 0 Then Return

            'estatus = grdDatosPedidoDetalles.GetRowCellValue(fila, "estatus")

            'If estatus.Equals("DESCARTADO") Or estatus.Equals("CANCELADO") Or estatus.Equals("ENTREGADO") Then
            '    grdDatosPedidoDetalles.SetRowCellValue(fila, "Seleccionar", False)
            'End If

        Catch ex As Exception
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "Ocurrió un error al recuperar los lotes, contacte a TI")
        End Try

    End Sub

    Private Sub grdDatosPedidoDetalles_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs)

    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim estatus As String = String.Empty
        Dim dtResultado As DataTable

        Dim DVListadoOTs As DataView = CType(grdDatosPedidoDetalles.DataSource, DataView)
        dtResultado = DVListadoOTs.Table.Copy()

        Dim lista = dtResultado.AsEnumerable.ToList()

        For Each fila As DataRow In lista
            fila.Item("Seleccionar") = chkSeleccionarTodo.Checked
        Next

        grdPedidoDetalle.DataSource = dtResultado




        'For i = 0 To grdDatosPedidoDetalles.RowCount - 1
        '    grdDatosPedidoDetalles.SetRowCellValue(i, "Seleccionar", chkSeleccionarTodo.Checked)
        'Next
    End Sub

    Private Sub grdDatosPedidoDetalles_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdDatosPedidoDetalles.ShowingEditor
        Dim View As GridView = sender
        Dim fila As Integer = IIf(grdDatosPedidoDetalles.GetSelectedRows.Count > 0, grdDatosPedidoDetalles.GetSelectedRows(0), -1)
        Dim estatus As String = grdDatosPedidoDetalles.GetRowCellValue(fila, "estatus").ToString()

        'If fila >= 0 Then
        '    If estatus.Equals("DESCARTADO") Or estatus.Equals("CANCELADO") Or estatus.Equals("ENTREGADO") Then
        '        e.Cancel = True
        '    Else
        '        e.Cancel = False
        '    End If
        'End If
    End Sub
#End Region

#Region "Acciones Botones Arriba Abajo"
    Private Sub OcultarFiltros()
        pnlInformacion.Height = 0
    End Sub

    Private Sub MostrarFiltros()
        pnlInformacion.Height = tamanioPanelFiltro
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        OcultarFiltros()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        MostrarFiltros()
    End Sub

#End Region

#Region "Diseño Grid"

    Private Sub DisenioGrid_Pedidos()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosPedidoDetalles)


        grdDatosPedidoDetalles.OptionsView.ColumnAutoWidth = False

        repositorioChkSeleccionar.DisplayValueChecked = "Sí"
        repositorioChkSeleccionar.DisplayValueUnchecked = "No"
        grdDatosPedidoDetalles.Columns("Seleccionar").Caption = " "
        grdDatosPedidoDetalles.Columns("pedidoSAY").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosPedidoDetalles.Columns("pedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
        grdDatosPedidoDetalles.Columns("partida").Caption = "Partida"
        grdDatosPedidoDetalles.Columns("articulo").Caption = "Artículo"
        grdDatosPedidoDetalles.Columns("pares").Caption = "Pares"
        grdDatosPedidoDetalles.Columns("tipoNumeracion").Caption = "Tipo" + vbCrLf + "Num."
        grdDatosPedidoDetalles.Columns("paresCancelados").Caption = "Pares" + vbCrLf + "Cancelados"
        grdDatosPedidoDetalles.Columns("paresApartados").Caption = "Pares" + vbCrLf + "Apartados"
        grdDatosPedidoDetalles.Columns("paresEntregados").Caption = "Pares" + vbCrLf + "Entregados"
        grdDatosPedidoDetalles.Columns("paresPendientes").Caption = "Pares" + vbCrLf + "Pendientes"
        grdDatosPedidoDetalles.Columns("tienda").Caption = "Tienda"
        grdDatosPedidoDetalles.Columns("tienda").Width = 200
        grdDatosPedidoDetalles.Columns("tiendaCompleta").Visible = False
        grdDatosPedidoDetalles.Columns("anotacion").Caption = "Anotación"
        grdDatosPedidoDetalles.Columns("fechaEntregaCliente").Caption = "F Entrega" + vbCrLf + "Cliente"
        grdDatosPedidoDetalles.Columns("precio").Caption = "Precio"
        grdDatosPedidoDetalles.Columns("subtotal").Caption = "Subtotal"
        grdDatosPedidoDetalles.Columns("total").Caption = "Total"
        grdDatosPedidoDetalles.Columns("estatusId").Visible = False
        grdDatosPedidoDetalles.Columns("estatus").Caption = "Estatus"

        grdDatosPedidoDetalles.Columns("pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("pares").DisplayFormat.FormatString = "n0"
        grdDatosPedidoDetalles.Columns("paresCancelados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("paresCancelados").DisplayFormat.FormatString = "n0"
        grdDatosPedidoDetalles.Columns("paresApartados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("paresApartados").DisplayFormat.FormatString = "n0"
        grdDatosPedidoDetalles.Columns("paresEntregados").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("paresEntregados").DisplayFormat.FormatString = "n0"
        grdDatosPedidoDetalles.Columns("paresPendientes").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("paresPendientes").DisplayFormat.FormatString = "n0"
        grdDatosPedidoDetalles.Columns("precio").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("precio").DisplayFormat.FormatString = "c2"
        grdDatosPedidoDetalles.Columns("subtotal").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("subtotal").DisplayFormat.FormatString = "c2"
        grdDatosPedidoDetalles.Columns("total").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidoDetalles.Columns("total").DisplayFormat.FormatString = "c2"

        CrearSummarAlPiePantalla(grdDatosPedidoDetalles)

        grdDatosPedidoDetalles.Columns("Seleccionar").ColumnEdit = repositorioChkSeleccionar

        grdDatosPedidoDetalles.BestFitColumns()

        grdDatosPedidoDetalles.Columns("Seleccionar").OptionsColumn.AllowEdit = True

    End Sub

    Private Sub CrearSummarAlPiePantalla(grid As GridView)
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grid.GroupSummary.Clear()

        For index = 0 To grid.Columns.Count - 1
            If grid.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grid.Columns(index).Name.Replace("col", "")

                grid.Columns(index).Summary.Clear()
                grid.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grid.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grid.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grid.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Sub DisenioGrid_Tallas()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosInformacionTallas)

        If grdDatosInformacionTallas.RowCount = 1 Then
            If String.IsNullOrEmpty(grdDatosInformacionTallas.Columns(0).FieldName.Trim) Then
                Return
            End If
        End If

        grdDatosInformacionTallas.OptionsView.ShowFooter = False
        grdDatosInformacionTallas.OptionsView.ShowAutoFilterRow = False
        grdDatosInformacionTallas.Columns("numeracion").Caption = "Numeración"

        For i = 1 To grdDatosInformacionTallas.Columns.Count - 1
            grdDatosInformacionTallas.Columns(i).DisplayFormat.FormatType = Utils.FormatType.Numeric
            grdDatosInformacionTallas.Columns(i).DisplayFormat.FormatString = "n0"
        Next

        grdDatosInformacionTallas.BestFitColumns()
    End Sub


#End Region

#Region "Métodos"
    Public Sub SetEntPedido(entPedido As Entidades.InfoPedido)
        Me.entPedido = entPedido
    End Sub

    Private Sub RecuperarInformacionPedido()
        txtCliente.Text = entPedido.Cliente
        txtPedidoSAY.Text = entPedido.PedidoSAY.ToString
        txtPedidoSICY.Text = entPedido.PedidoSICY.ToString
        txtOC.Text = entPedido.OrdenCliente
        txtFCaptura.Text = entPedido.FechaCaptura.ToShortDateString
        txtFEntregaCliente.Text = IIf(entPedido.FechaEntregaCliente = DateTime.MinValue, "", entPedido.FechaEntregaCliente.ToShortDateString)
        txtEjecutivo.Text = entPedido.Ejecutivo
        txtAgente.Text = entPedido.Agente
    End Sub

    Private Sub BloquearInfoPedido()
        txtCliente.Enabled = False
        txtPedidoSAY.Enabled = False
        txtPedidoSICY.Enabled = False
        txtOC.Enabled = False
        txtFCaptura.Enabled = False
        txtFEntregaCliente.Enabled = False
        txtEjecutivo.Enabled = False
        txtAgente.Enabled = False
    End Sub

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosPedidoDetalles.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub

    Private Sub Mostrar()
        Dim resultado As New DataTable

        Try
            Cursor = Cursors.WaitCursor
            resultado = objBu.ConsultarPedidoDetalle(entPedido.PedidoSAY)

            grdPedidoDetalle.DataSource = resultado

            MostrarInformacionTallas(-1)

            DisenioGrid_Pedidos()

            ActualizarConteoyFechaConsulta()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ActualizarConteoyFechaConsulta()
        End Try

    End Sub

    Private Sub MostrarInformacionTallas(fila As Integer)
        Dim resultado As New DataTable
        Dim partidas As String = String.Empty

        grdInformacionTallas.DataSource = Nothing
        grdDatosInformacionTallas.Columns.Clear()

        If fila > -1 Then
            partidas = grdDatosPedidoDetalles.GetRowCellValue(fila, "partida")
        End If

        resultado = objBu.ConsultarInformacionTallas(entPedido.PedidoSAY, partidas)

        grdInformacionTallas.DataSource = resultado

        DisenioGrid_Tallas()
    End Sub


    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosPedidoDetalles.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdDatosPedidoDetalles.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosPedidoDetalles.OptionsPrint.AutoWidth = False
                            grdDatosPedidoDetalles.OptionsPrint.UsePrintStyles = False

                            Dim FileName As String = .SelectedPath + "\Datos_Pedidos_Detalle" + fecha_hora + ".xlsx"

                            Export.ExportSettings.DefaultExportType = Export.ExportType.WYSIWYG
                            grdDatosPedidoDetalles.ExportToXlsx(FileName)

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
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Fault, "No se pudo exportar los datos: " + ex.Message.ToString())
        End Try
    End Sub


    Private Function ObtenerPartidasParaCancelar() As List(Of String)
        Dim partidasParaCancelar As New List(Of String)

        For index = 0 To grdDatosPedidoDetalles.RowCount - 1
            If CBool(grdDatosPedidoDetalles.GetRowCellValue(index, "Seleccionar")) Then
                partidasParaCancelar.Add(grdDatosPedidoDetalles.GetRowCellValue(index, "partida"))
            End If
        Next

        If partidasParaCancelar.Count = 0 Then Throw New Exception("No se ha seleccionado ninguna partida")

        Return partidasParaCancelar
    End Function

    Private Function ConvertirArrayToString(arrayAConvertir As String()) As String
        Dim resultado As New StringBuilder

        For i = 0 To arrayAConvertir.Count - 1
            resultado.Append(",").Append(arrayAConvertir(i))
        Next

        resultado = resultado.Remove(0, 1)

        Return resultado.ToString
    End Function

    Public Sub AbrirMotivoCancelacionPedido()
        Dim vistaMotivoCancelacion As New CancelacionPedidos_Form
        Dim ResultadoCancelacion As New CancelacionPedidos_ResultadoForm
        Dim partidasParaCancelar As List(Of String)
        Dim dtResultado As New DataTable
        Dim partidas As String = String.Empty
        Dim esValidaParaCancelarSoloPartidasAbiertas As Boolean = False
        Dim noTienePartidasSeleccionadasCanceladas As Boolean = False
        Dim tienePartidasEnDividido As Boolean = False

        Try
            Cursor = Cursors.WaitCursor

            Dim DVListadoOTs As DataView = CType(grdDatosPedidoDetalles.DataSource, DataView)
            dtResultado = DVListadoOTs.Table.Copy()

            If dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Count = 0 Then
                Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una partida.")
                Cursor = Cursors.Default
                Return

            Else
                Dim PartidasEntregadasCanceladas = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True And (x.Item("estatus") = "ENTREGADO" Or x.Item("estatus") = "CANCELADO" Or x.Item("estatus") = "EN DESASIGNACIÓN")).ToList()

                If PartidasEntregadasCanceladas.Count() > 0 Then
                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Aviso, "No se puede cancelar partidas canceladas o entregadas.")
                    Cursor = Cursors.Default
                    Return
                Else
                    'Dim ListaPartidas = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("Partida")).ToList()


                    For Each Fila As String In dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("pedidoSAY")).Distinct.ToList

                        Dim ListaPartidas = dtResultado.AsEnumerable.Where(Function(x) x.Item("pedidoSAY") = Fila And CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("partida")).ToList

                        Dim FilaPArtida As DataRow
                        FilaPArtida = DtPedidos.NewRow

                        FilaPArtida.Item("Pedido") = Fila
                        FilaPArtida.Item("Partida") = String.Join(",", ListaPartidas)
                        FilaPArtida.Item("Cancelado") = False

                        DtPedidos.Rows.Add(FilaPArtida)
                    Next

                    'Dim Lista = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) y.Item("Pedido")).Distinct.Where(Function(z) z)


                    'Dim Lista = dtResultado.AsEnumerable().Where(Function(x) CBool(x.Item("Seleccionar")) = True).Select(Function(y) ObtenerFilaPedido(y)).ToList()

                    vistaMotivoCancelacion.DtPartidasACancelar = DtPedidos
                    vistaMotivoCancelacion.CancelarPorPartidas = True
                    vistaMotivoCancelacion.ShowDialog()

                    'vistaMotivoCancelacion.SetPedidoSAY(entPedido.PedidoSAY)
                    'vistaMotivoCancelacion.listaPedidosParaCancelar.Add(entPedido.PedidoSAY)
                    ''listaPedidosParaCancelar
                    'vistaMotivoCancelacion.SetListaPartidasACancelar(String.Join(",", ListaPartidas))
                    'vistaMotivoCancelacion.ShowDialog()

                    If vistaMotivoCancelacion.DialogResult <> DialogResult.Cancel Then

                        ResultadoCancelacion.PedidoSYAYID = entPedido.PedidoSAY
                        ResultadoCancelacion.Show()

                        Mostrar()
                        chkSeleccionarTodo.Checked = False
                    End If
                End If

            End If

            Cursor = Cursors.Default


            ' partidasParaCancelar = ObtenerPartidasParaCancelar()

            'tienePartidasEnDividido =
            '    partidasParaCancelar.TrueForAll(
            '        Function(a) grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.LocateByValue("partida", CInt(a)), "estatusId").ToString.Equals("132") Or
            '                    grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.LocateByValue("partida", CInt(a)), "estatusId").ToString.Equals("133")) 'DIVIDIDO PRE-CAPTURA, DIVIDIDO ABIERTO

            'esValidaParaCancelarSoloPartidasAbiertas =
            '    partidasParaCancelar.TrueForAll(
            '        Function(a) grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.LocateByValue("partida", CInt(a)), "estatusId").ToString.Equals("1") Or
            '                    grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.LocateByValue("partida", CInt(a)), "estatusId").ToString.Equals("131")) ' ABIERTO, PRE-CAPTURA

            'noTienePartidasSeleccionadasCanceladas =
            '    partidasParaCancelar.TrueForAll(Function(a) Not grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.LocateByValue("partida", CInt(a)), "estatusId").ToString.Equals("15")) ' CANCELADO

            'partidas = ConvertirArrayToString(partidasParaCancelar.ToArray)

            'dtResultado = objBu.ValidarPartidas(entPedido.PedidoSAY, partidas)
            'vistaMotivoCancelacion.SetPedidoSAY(entPedido.PedidoSAY)
            'vistaMotivoCancelacion.SetListaPartidasACancelar(partidas)
            'vistaMotivoCancelacion.ShowDialog()

            'If tienePartidasEnDividido Then
            '    Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se pueden cancelar partidas en DIVIDO.")
            '    Return
            'End If

            'If Not noTienePartidasSeleccionadasCanceladas Then
            '    Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se pueden cancelar partidas canceladas.")
            '    Return
            'End If

            'Dim dialogResult As New DialogResult

            'If esValidaParaCancelarSoloPartidasAbiertas Then
            '    EliminarPartidasAbiertas(partidas)
            'Else
            '    vistaMotivoCancelacion.SetPedidoSAY(entPedido.PedidoSAY)
            '    vistaMotivoCancelacion.SetListaPartidasACancelar(partidas)
            '    dialogResult = vistaMotivoCancelacion.ShowDialog()
            'End If



            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
        End Try


    End Sub

    'Public Function ObtenerFilaPedido(ByVal fila As DataRow) As DataRow
    '    Dim FilaPArtida As DataRow
    '    FilaPArtida = DtPedidos.NewRow

    '    FilaPArtida.Item("Pedido") = fila.Item("pedidoSAY")
    '    FilaPArtida.Item("Partida") = fila.Item("partida")
    '    FilaPArtida.Item("Cancelado") = False

    '    Return FilaPArtida
    'End Function

    Public Function ObtenerFilaPedido(ByVal fila As DataRow) As DataRow
        Dim FilaPArtida As DataRow
        FilaPArtida = DtPedidos.NewRow

        FilaPArtida.Item("Pedido") = fila.Item("pedidoSAY")
        FilaPArtida.Item("Partida") = fila.Item("partida")
        FilaPArtida.Item("Cancelado") = False

        Return FilaPArtida
    End Function


    Private Sub EliminarPartidasAbiertas(partidas As String)
        Dim confirmarDialog As New ConfirmarForm
        Dim resultadoDialog As New DialogResult

        confirmarDialog.mensaje = "¿Cancelar las partidas: " + partidas + " del pedido SAY " + entPedido.PedidoSAY.ToString + "?"

        resultadoDialog = confirmarDialog.ShowDialog

        If resultadoDialog = DialogResult.OK Then
            objBu.EliminarPartidasAbiertas(entPedido.PedidoSAY, partidas)
        End If

    End Sub

    Private Sub AbrirConsultaLotes()
        Dim vistaConsultaLotes As New AdministradorPedidosDetalleLotes_Form
        Dim partidasParaCancelar As New List(Of String)
        Dim partidas As String = String.Empty
        Dim dtInformacionLotes As New DataTable

        Try
            partidasParaCancelar = ObtenerPartidasParaCancelar()
            partidas = ConvertirArrayToString(partidasParaCancelar.ToArray)

            dtInformacionLotes = objBu.Consultar_InformacionLotes(entPedido.PedidoSICY, partidas)

            If dtInformacionLotes.Rows.Count = 0 Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
                Return
            End If

            vistaConsultaLotes.AsignarPedidoSICY(entPedido.PedidoSICY)
            vistaConsultaLotes.AsignarPartidas(partidas)
            vistaConsultaLotes.ShowDialog()
        Catch ex As Exception
            Cursor = Cursors.Default
            If Not String.IsNullOrEmpty(ex.Message) Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
            End If
        End Try

    End Sub

    Private Sub AbrirConsultaLotesDobleClic(fila As Integer)
        Dim vistaConsultaLotes As New AdministradorPedidosDetalleLotes_Form
        Dim partidasParaCancelar As New List(Of String)
        Dim partidas As String = String.Empty
        Dim dtInformacionLotes As New DataTable

        Try
            If fila < 0 Then
                Return
            End If

            partidas = grdDatosPedidoDetalles.GetRowCellValue(fila, "partida")

            dtInformacionLotes = objBu.Consultar_InformacionLotes(entPedido.PedidoSICY, partidas)

            If dtInformacionLotes.Rows.Count = 0 Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "No se encontraron resultados.")
                Return
            End If

            vistaConsultaLotes.AsignarPedidoSICY(entPedido.PedidoSICY)
            vistaConsultaLotes.AsignarPartidas(partidas)
            vistaConsultaLotes.ShowDialog()
        Catch ex As Exception
            Cursor = Cursors.Default
            If Not String.IsNullOrEmpty(ex.Message) Then
                Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
            End If
        End Try

    End Sub

    Private Sub grdDatosPedidoDetalles_CustomDrawRowIndicator_1(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosPedidoDetalles.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub ColorearRegistros(e As RowCellStyleEventArgs)
        Dim filas As Integer = e.RowHandle
        Dim auxEstatus As String = grdDatosPedidoDetalles.GetRowCellValue(filas, "estatus")

        If filas >= 0 Then
            If auxEstatus.Equals("DESCARTADO") Or auxEstatus.Equals("CANCELADO") Then
                e.Appearance.ForeColor = lblCancelado.ForeColor
            ElseIf auxEstatus.Equals("ENTREGADO") Or
                auxEstatus.Equals("FACTURADO") Or
                auxEstatus.Equals("EMBARQUE") Or
                auxEstatus.Equals("PROYECTADO") Then

                e.Appearance.BackColor = Color.LightGray
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub grdDatosPedidoDetalles_RowClick(sender As Object, e As RowClickEventArgs) Handles grdDatosPedidoDetalles.RowClick

        If e.Button = MouseButtons.Right Then
            AbrirFormConsultaDeOrdenTrabajoDocumento()
        ElseIf e.Clicks > 1 Then
            AbrirConsultaLotesDobleClic(e.RowHandle)
        Else
            MostrarInformacionTallas(e.RowHandle)
        End If
    End Sub

    Private Sub MostrarEtiqueta(sender As Object, e As ToolTipControllerGetActiveObjectInfoEventArgs) Handles toolTipoEtiquetaTiendaCompleta.GetActiveObjectInfo
        If Not e.SelectedControl Is grdPedidoDetalle Then Return

        Dim mensaje As ToolTipControlInfo = Nothing

        Dim view As GridView = grdPedidoDetalle.GetViewAt(e.ControlMousePosition)

        If (view Is Nothing) Then Return

        Dim hi As GridHitInfo = view.CalcHitInfo(e.ControlMousePosition)

        If hi.HitTest = GridHitTest.RowCell Then
            If Not hi.Column.Caption.Equals("Tienda") Then Return

            Dim obj As Object = hi.HitTest.ToString() + hi.RowHandle.ToString()
            Dim tiendaCompleta As String = grdDatosPedidoDetalles.GetRowCellValue(hi.RowHandle, "tiendaCompleta")

            mensaje = New ToolTipControlInfo(obj, tiendaCompleta)
        End If

        If (mensaje IsNot Nothing) Then e.Info = mensaje
    End Sub

    Private Sub AbrirFormConsultaDeOrdenTrabajoDocumento()
        Dim cmsVerDocumentoOT As New ContextMenuStrip

        Try
            Cursor = Cursors.WaitCursor
            toolTipoItemVerOT.Text = "Ver OT"
            toolTipoItemVerFactura.Text = "Ver Factura"

            cmsVerDocumentoOT.Items.Add(toolTipoItemVerOT)
            cmsVerDocumentoOT.Items.Add(toolTipoItemVerFactura)

            For i = 0 To grdDatosPedidoDetalles.RowCount - 1
                If grdDatosPedidoDetalles.IsRowSelected(grdDatosPedidoDetalles.GetVisibleRowHandle(i)) = True Then
                    pedidoSeleccionado = grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.GetVisibleRowHandle(i), "pedidoSAY")
                    partidaSeleccionado = grdDatosPedidoDetalles.GetRowCellValue(grdDatosPedidoDetalles.GetVisibleRowHandle(i), "partida")
                End If
            Next

            cmsVerDocumentoOT.Show(MousePosition)

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub VerOt_Click(sender As Object, e As EventArgs) Handles toolTipoItemVerOT.Click
        Dim ventana As New OrdenTrabajoDocumentoPorPedido_Form
        Dim datos As New DataTable
        datos = objBu.Consultar_InformacionOT(pedidoSeleccionado, partidaSeleccionado)
        ventana.tipoVista = 0

        If datos.Rows.Count > 0 Then
            ventana.dtResultado = datos
            ventana.ShowDialog()
        End If

    End Sub

    Private Sub VerFactura_Click(sender As Object, e As EventArgs) Handles toolTipoItemVerFactura.Click
        Dim ventana As New OrdenTrabajoDocumentoPorPedido_Form
        Dim datos As New DataTable
        datos = objBu.Consultar_InformacionFactura(pedidoSeleccionado, partidaSeleccionado)

        ventana.tipoVista = 1

        If datos.Rows.Count > 0 Then
            ventana.dtResultado = datos
            ventana.ShowDialog()
        End If

    End Sub
#End Region


End Class