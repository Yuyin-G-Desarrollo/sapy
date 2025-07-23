Imports DevExpress
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReasignarOTAPedido_Form
#Region "Variables"
    Private objBu As New Negocios.ReasignacionOTBU
    Private ordenTrabajoId As Integer = 0
    Private WithEvents repositorioChkSeleccionar As New RepositoryItemCheckEdit
#End Region

    Private Sub ReasignarOTAPedido_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPedidosQueCoinciden()
        lblOT.Text = ordenTrabajoId.ToString
    End Sub

#Region "Metodos"
    Public Sub AsignarOrdenTrabajoId(ordenTrabajoId As Integer)
        Me.ordenTrabajoId = ordenTrabajoId
    End Sub

    Private Sub CargarPedidosQueCoinciden()
        Dim dtResultado As New DataTable()

        Try
            Cursor = Cursors.WaitCursor

            dtResultado = objBu.ValidarReasignacionPedido(ordenTrabajoId)

            If dtResultado.Rows.Count > 0 Then
                dtResultado.DefaultView.Sort = "pedidoSAY DESC"
                grdPedidos.DataSource = dtResultado
                DisenioGrid()
            End If

            ActualizarConteoyFechaConsulta()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ActualizarConteoyFechaConsulta()
        lblRegistros.Text = grdDatosPedidos.RowCount.ToString("n0")
        lblUltimaActualizacion.Text = Now()
    End Sub

    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosPedidos)

        grdDatosPedidos.Columns(0).OptionsColumn.AllowEdit = True

        repositorioChkSeleccionar.DisplayValueChecked = "Sí"
        repositorioChkSeleccionar.DisplayValueUnchecked = "No"
        grdDatosPedidos.Columns("seleccionar").Caption = " "
        grdDatosPedidos.Columns("seleccionar").BestFit()
        grdDatosPedidos.Columns("pedidoSAY").Caption = "Pedido" + vbCrLf + "SAY"
        grdDatosPedidos.Columns("pedidoSAY").Width = 80
        grdDatosPedidos.Columns("pedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
        grdDatosPedidos.Columns("cliente").Caption = "Cliente"
        grdDatosPedidos.Columns("cliente").BestFit()
        grdDatosPedidos.Columns("pares").Caption = "Pares"
        grdDatosPedidos.Columns("estatus").Caption = "Estatus"

        grdDatosPedidos.Columns("pares").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosPedidos.Columns("pares").DisplayFormat.FormatString = "n0"

        CrearSummarAlPiePantalla()

        grdDatosPedidos.Columns("seleccionar").ColumnEdit = repositorioChkSeleccionar
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        Dim item As GridGroupSummaryItem
        Dim str As String = String.Empty

        grdDatosPedidos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosPedidos.GroupSummary.Clear()

        For index = 0 To grdDatosPedidos.Columns.Count - 1
            If grdDatosPedidos.Columns(index).DisplayFormat.FormatType = Utils.FormatType.Numeric Then
                item = New GridGroupSummaryItem

                str = grdDatosPedidos.Columns(index).Name.Replace("col", "")

                grdDatosPedidos.Columns(index).Summary.Clear()
                grdDatosPedidos.Columns(index).Summary.Add(Data.SummaryItemType.Sum, str, "{0:" + grdDatosPedidos.Columns(index).DisplayFormat.FormatString + "}")

                item.FieldName = str
                item.ShowInGroupColumnFooter = grdDatosPedidos.Columns("c")
                item.SummaryType = Data.SummaryItemType.Sum
                item.DisplayFormat = "Total {0:N}"
                grdDatosPedidos.GroupSummary.Add(item)
            End If
        Next

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ActualizarReasignacionPedido()
    End Sub

    Private Sub ActualizarReasignacionPedido()
        Dim pedidoSAY As Integer = 0
        Dim contadorSeleccionados As Integer = 0
        Dim confirmarDialog As New ConfirmarForm
        Dim resultadoDialog As DialogResult

        Try
            Cursor = Cursors.WaitCursor
            For index = 0 To grdDatosPedidos.RowCount - 1
                If CBool(grdDatosPedidos.GetRowCellValue(index, "seleccionar")) Then
                    If pedidoSAY = 0 Then
                        pedidoSAY = CInt(grdDatosPedidos.GetRowCellValue(index, "pedidoSAY"))
                    End If
                    contadorSeleccionados += 1
                End If
            Next

            If contadorSeleccionados > 1 Then
                Throw New Exception("Solo se puede asignar un pedido por OT.")
            End If

            confirmarDialog.mensaje = "¿Confirmar la reasginación de la OT: " + ordenTrabajoId.ToString + " al pedido " + pedidoSAY.ToString + "?" + vbCrLf + vbCrLf + "Esta acción no se puede deshacer."

            resultadoDialog = confirmarDialog.ShowDialog

            If resultadoDialog = DialogResult.OK Then
                objBu.ActualizarReasignacionPedido(ordenTrabajoId, pedidoSAY)
                btnAceptar.Enabled = False
                Tools.MostrarMensaje(Tools.Mensajes.Notice, "Se ha asignado la OT: " + ordenTrabajoId.ToString + " al pedido: " + pedidoSAY.ToString)
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Tools.Mensajes.Notice, ex.Message)
        End Try

    End Sub

    Private Sub grdDatosPedidos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosPedidos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
#End Region
End Class