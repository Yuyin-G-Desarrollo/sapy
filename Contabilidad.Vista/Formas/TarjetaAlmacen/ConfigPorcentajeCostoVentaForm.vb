Imports System.Drawing
Imports System.Windows.Forms
Imports Tools
Public Class ConfigPorcentajeCostoVentaForm
    Dim blnPuedeEditar As Boolean = False
    Dim registrosEdicion As Integer = 0

    Private Sub ConfigPorcentajeCostoVentaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        blnPuedeEditar = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CONF_PORC_PV", "EDITAR_CONFIG")
        lblGuardar.Visible = blnPuedeEditar
        btnGuardar.Visible = blnPuedeEditar

        cargarDatos()

    End Sub

    Private Sub cargarDatos()
        Try
            Me.Cursor = Cursors.WaitCursor
            registrosEdicion = 0
            grdConfigCostoVenta.DataSource = Nothing
            vwConfigCostoVenta.Columns.Clear()

            Dim obBU As New Negocios.TarjetaAlmacenBU
            Dim dtDatos As New DataTable
            dtDatos = obBU.consultaConfigPrecioVenta()

            If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                grdConfigCostoVenta.DataSource = dtDatos
                diseniogrid()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información para mostrar.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la información.")
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub diseniogrid()
        Tools.DiseñoGrid.AlternarColorEnFilas(vwConfigCostoVenta)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwConfigCostoVenta)

        If IsNothing(vwConfigCostoVenta.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            vwConfigCostoVenta.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.Integer
            AddHandler vwConfigCostoVenta.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            vwConfigCostoVenta.Columns.Item("#").VisibleIndex = 0
        End If

        vwConfigCostoVenta.Columns("configuracionid").Visible = False
        vwConfigCostoVenta.Columns("empresaid").Visible = False
        vwConfigCostoVenta.Columns("EditaLimInf").Visible = False
        vwConfigCostoVenta.Columns("EditaLimSup").Visible = False

        vwConfigCostoVenta.Columns("Empresa").OptionsColumn.AllowEdit = False
        vwConfigCostoVenta.Columns("usuariomodifica").OptionsColumn.AllowEdit = False
        vwConfigCostoVenta.Columns("fechamodificacion").OptionsColumn.AllowEdit = False

        vwConfigCostoVenta.Columns("limiteinferior").OptionsColumn.AllowEdit = blnPuedeEditar
        vwConfigCostoVenta.Columns("limitesuperior").OptionsColumn.AllowEdit = blnPuedeEditar

        vwConfigCostoVenta.Columns.ColumnByFieldName("limiteinferior").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwConfigCostoVenta.Columns.ColumnByFieldName("limiteinferior").DisplayFormat.FormatString = "N2"
        vwConfigCostoVenta.Columns.ColumnByFieldName("limitesuperior").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwConfigCostoVenta.Columns.ColumnByFieldName("limitesuperior").DisplayFormat.FormatString = "N2"
        vwConfigCostoVenta.Columns.ColumnByFieldName("fechamodificacion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        vwConfigCostoVenta.Columns.ColumnByFieldName("fechamodificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        vwConfigCostoVenta.Columns.ColumnByFieldName("#").Width = 20
        vwConfigCostoVenta.Columns.ColumnByFieldName("Empresa").Width = 250
        vwConfigCostoVenta.Columns.ColumnByFieldName("limiteinferior").Width = 120
        vwConfigCostoVenta.Columns.ColumnByFieldName("limitesuperior").Width = 120
        vwConfigCostoVenta.Columns.ColumnByFieldName("usuariomodifica").Width = 140
        vwConfigCostoVenta.Columns.ColumnByFieldName("fechamodificacion").Width = 140

        vwConfigCostoVenta.Columns.ColumnByFieldName("limiteinferior").Caption = "Limite Inferior %"
        vwConfigCostoVenta.Columns.ColumnByFieldName("limitesuperior").Caption = "Limite Superior %"
        vwConfigCostoVenta.Columns.ColumnByFieldName("usuariomodifica").Caption = "Usuario Modifica"
        vwConfigCostoVenta.Columns.ColumnByFieldName("fechamodificacion").Caption = "Fecha Actualización"

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = vwConfigCostoVenta.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If registrosEdicion = 0 Then
            cargarDatos()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                cargarDatos()
            End If
        End If
    End Sub

    Private Sub vwConfigCostoVenta_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles vwConfigCostoVenta.CellValueChanged
        If e.Column.FieldName = "limiteinferior" OrElse e.Column.FieldName = "limitesuperior" Then
            Try
                Select Case e.Column.FieldName
                    Case "limiteinferior"
                        vwConfigCostoVenta.SetRowCellValue(e.RowHandle, "EditaLimInf", True)
                    Case "limitesuperior"
                        vwConfigCostoVenta.SetRowCellValue(e.RowHandle, "EditaLimSup", True)
                End Select

                registrosEdicion += 1
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            End Try
        End If
    End Sub

    Private Sub vwConfigCostoVenta_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles vwConfigCostoVenta.CustomDrawCell
        Try
            If e.Column.FieldName = "limiteinferior" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EditaLimInf")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            ElseIf e.Column.FieldName = "limitesuperior" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EditaLimSup")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        actualizarDatos()
    End Sub

    Private Sub actualizarDatos()
        If vwConfigCostoVenta.RowCount > 0 Then
            If registrosEdicion > 0 Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "Esta acción modificará los datos existentes, ¿Esta seguro de continuar?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        Me.Cursor = Cursors.WaitCursor

                        'limpiarfiltros()
                        Dim objBu As New Negocios.TarjetaAlmacenBU
                        Dim totalEditar As Integer = 0
                        Dim totalEditados As Integer = 0

                        For index As Integer = 0 To vwConfigCostoVenta.DataRowCount - 1 Step 1
                            If CBool(vwConfigCostoVenta.GetRowCellValue(vwConfigCostoVenta.GetVisibleRowHandle(index), "EditaLimInf")) = True Or CBool(vwConfigCostoVenta.GetRowCellValue(vwConfigCostoVenta.GetVisibleRowHandle(index), "EditaLimSup")) = True Then
                                Dim msjResult As String = String.Empty
                                Dim configId As Integer = 0
                                Dim limiteInf As Double = 0.0
                                Dim limiteSup As Double = 0.0

                                configId = CInt(vwConfigCostoVenta.GetRowCellValue(vwConfigCostoVenta.GetVisibleRowHandle(index), "configuracionid"))
                                limiteInf = CDbl(vwConfigCostoVenta.GetRowCellValue(vwConfigCostoVenta.GetVisibleRowHandle(index), "limiteinferior"))
                                limiteSup = CDbl(vwConfigCostoVenta.GetRowCellValue(vwConfigCostoVenta.GetVisibleRowHandle(index), "limitesuperior"))

                                totalEditar += 1
                                msjResult = objBu.actualizarConfigPrecioVenta(configId, limiteInf, limiteSup)

                                If msjResult = "EXITO" Then
                                    totalEditados += 1
                                End If

                            End If
                        Next

                        If totalEditar = totalEditados Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se actualizaron correctamente los datos.")
                            cargarDatos()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar la información")
                        End If

                    Catch ex As Exception
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe haber al menos un registro en edición para guardar la información.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay datos para guardar.")
        End If
    End Sub

    Private Sub limpiarfiltros()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwConfigCostoVenta.Columns
            col.ClearFilter()
        Next
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        If registrosEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub
End Class