Imports System.Windows.Forms
Imports Tools
Imports DevExpress.XtraGrid.Views.Grid

Public Class Cobranza_NC_PendientesTimbrarForm

    Private Sub Cobranza_NC_PendientesTimbrarForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOTAS_CRETIDO_XTIMBRAR", "TIMBRAR_NC") Then
            pnlTimbrar.Visible = True
        Else
            pnlTimbrar.Visible = False
        End If
        lblActualiza.Text = ""
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        cargarNCPendientes()
        'grdNCPendientes.DataSource = Nothing
    End Sub

    Private Sub cargarNCPendientes()
        Dim objBU As New Negocios.NotasCreditoBU
        Dim dtNCPendientes As New DataTable
        Cursor = Cursors.WaitCursor
        Try
            grdNCPendientes.DataSource = Nothing
            grdDetalles.Columns.Clear()
            lblTotalRegistros.Text = "0"

            lblActualiza.Text = "Última actualización: " + Date.Now.ToString()
            dtNCPendientes = objBU.consultaNCPendientesTimbrar

            If Not dtNCPendientes Is Nothing AndAlso dtNCPendientes.Rows.Count > 0 Then
                grdNCPendientes.DataSource = dtNCPendientes
                disenioGrid()
                lblTotalRegistros.Text = dtNCPendientes.Rows.Count.ToString()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La consulta no devolvió resultados.")
            End If

        Catch ex As Exception
            lblActualiza.Text = "Última actualización: " + Date.Now.ToString()
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al consultar las notas de crédito pendientes de timbrar.")
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub disenioGrid()

        DiseñoGrid.DiseñoBaseGrid(grdDetalles)
        grdDetalles.Columns.ColumnByFieldName("Seleccion").OptionsColumn.AllowEdit = True
        grdDetalles.Columns.ColumnByFieldName("Seleccion").OptionsFilter.AllowFilter = False
        grdDetalles.Columns.ColumnByFieldName("IdNotaCredito").Visible = False
        grdDetalles.Columns.ColumnByFieldName("Idcadena").Visible = False
        grdDetalles.Columns.ColumnByFieldName("IdCliente").Visible = False
        grdDetalles.Columns.ColumnByFieldName("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        grdDetalles.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdDetalles.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"

        grdDetalles.Columns.ColumnByFieldName("Seleccion").Width = 70
        grdDetalles.Columns.ColumnByFieldName("Cliente").Width = 300
        grdDetalles.Columns.ColumnByFieldName("RazonSocial").Width = 300
        grdDetalles.Columns.ColumnByFieldName("Folio").Width = 70
        grdDetalles.Columns.ColumnByFieldName("NC").Width = 70
        grdDetalles.Columns.ColumnByFieldName("Fecha").Width = 140
        grdDetalles.Columns.ColumnByFieldName("RFC").Width = 120
        grdDetalles.Columns.ColumnByFieldName("Total").Width = 100
        grdDetalles.Columns.ColumnByFieldName("Capturo").Width = 100
        grdDetalles.IndicatorWidth = 40
    End Sub
    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = grdDetalles.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                grdDetalles.SetRowCellValue(grdDetalles.GetVisibleRowHandle(index), "Seleccion", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub grdDetalles_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDetalles.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnTimbrar_Click(sender As Object, e As EventArgs) Handles btnTimbrar.Click
        Dim filas As Integer
        Dim NotasCreditoTimbradas As Integer = 0
        Dim NotasCreditoNoTimbradas As Integer = 0
        Dim contadorDoctosSeleccionados As Integer = 0
        Dim doctosTimbrados As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            filas = grdDetalles.DataRowCount - 1
            For index As Integer = 0 To filas Step 1
                If CBool(grdDetalles.GetRowCellValue(grdDetalles.GetVisibleRowHandle(index), "Seleccion")) = True Then
                    contadorDoctosSeleccionados += 1
                    'Proceso de timbrado :S
                    Dim objComplemento As New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU
                    Dim objNegociospdf As New Libreria_CFDI_33.Negocios.GenerarFacturaElectronicaBU

                    Dim IdNotaCredito As Integer = 0
                    If Not IsDBNull(grdDetalles.GetRowCellValue(grdDetalles.GetVisibleRowHandle(index), "IdNotaCredito")) Then
                        IdNotaCredito = CInt(grdDetalles.GetRowCellValue(grdDetalles.GetVisibleRowHandle(index), "IdNotaCredito"))
                    End If

                    If IdNotaCredito > 0 Then
                        Dim objBU As New Negocios.NotasCreditoBU
                        Dim aviso As String = ""
                        Dim respuesta As Integer = 0

                        If Not objBU.validarTimbrado(IdNotaCredito) Then
                            objComplemento.Folio(IdNotaCredito)

                            If objComplemento.Respuesta = 1 Then
                                objComplemento.CopiarDocumento()

                                objNegociospdf.GenerarPdf(IdNotaCredito)
                                objNegociospdf.CopiarDocumento()


                                NotasCreditoTimbradas += 1
                            Else
                                NotasCreditoNoTimbradas += 1
                            End If
                        Else
                            doctosTimbrados += 1
                        End If
                    End If
                End If
            Next
            If NotasCreditoTimbradas = contadorDoctosSeleccionados Then
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Todos los documentos se han timbrado exitosamente.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Documentos timbrados: " + NotasCreditoTimbradas.ToString + vbNewLine +
                                   "Documentos no timbrados: " + NotasCreditoNoTimbradas.ToString + vbNewLine +
                                   "Documentos timbrados anteriormente: " + doctosTimbrados.ToString + vbNewLine)
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString)
        Finally
            cargarNCPendientes()
            Cursor = Cursors.Default
        End Try

    End Sub
End Class