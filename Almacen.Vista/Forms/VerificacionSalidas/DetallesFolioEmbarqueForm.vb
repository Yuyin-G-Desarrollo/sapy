Imports Tools
Imports DevExpress.XtraPrinting

Public Class DetallesFolioEmbarqueForm

    Public FolioVerificacionID As Integer = 0
    Dim ObjBU As New Negocios.VerificacionSalidasBU

    Private Sub DetallesFolioEmbarqueForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblFolioembarque.Text = ""
        lblPares.Text = ""
        lblFolioPaqueteria.Text = ""
        lblMensajeria.Text = ""
        lblValorOperador.Text = ""
        lblTransporte.Text = ""

        CargarPantalla()

    End Sub

    Private Sub CargarPantalla()
        Dim dtResultado As New DataTable

        Try
            Cursor = Cursors.WaitCursor
            CargarEncabezado()

            dtResultado = ObjBU.ConsultaDetallesFolio(FolioVerificacionID)
            grdDetallesFolio.DataSource = dtResultado
            DiseñoGrid.DiseñoBaseGrid(viewConsultaDetalles)

            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "OT", "OT", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Atado", "Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "CodigoPar", "Codigo Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Calce", "Calce", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "StatusID", "StatusID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Nave", "Nave ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "ModeloSAY", "Modelo SAY ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Coleccion", "Colección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Articulo", "Articulo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "DocumentoID", "DocumentoID", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "FechaConfirmación", "Fecha Confirmación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewConsultaDetalles, "Colaborador", "Colaborador", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

            lblTotalRegistros.Text = CDbl(dtResultado.Rows.Count).ToString("N0")

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub CargarEncabezado()
        Dim dtResultado As New DataTable


        Try
            dtResultado = ObjBU.ObtenerInformacionFolio(FolioVerificacionID)

            If IsNothing(dtResultado) = False Then
                If dtResultado.Rows.Count > 0 Then
                    lblFolioembarque.Text = FolioVerificacionID
                    lblPares.Text = CDbl(dtResultado.Rows(0).Item("TotalPares").ToString()).ToString("N0")
                    lblFolioPaqueteria.Text = dtResultado.Rows(0).Item("FolioPaqueteria").ToString()
                    lblMensajeria.Text = dtResultado.Rows(0).Item("Mensajeria").ToString()
                    lblValorOperador.Text = dtResultado.Rows(0).Item("Operador").ToString()
                    lblTransporte.Text = dtResultado.Rows(0).Item("Unidad").ToString()
                End If

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                If ret = Windows.Forms.DialogResult.OK Then
                    If viewConsultaDetalles.GroupCount > 0 Then
                        viewConsultaDetalles.ExportToXlsx(.SelectedPath + "\Datos_FoliosVerificaciónDetalles_" + FolioVerificacionID.ToString + "_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        viewConsultaDetalles.ExportToXlsx(.SelectedPath + "\Datos_FoliosVerificaciónDetalles_" + FolioVerificacionID.ToString + "_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_FoliosVerificaciónDetalles_" + FolioVerificacionID.ToString + "_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_FoliosVerificaciónDetalles_" + FolioVerificacionID.ToString + "_" + fecha_hora + ".xlsx")
                End If
            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        'Dim EstatusID As Integer = grdVentas.GetRowCellValue(e.RowHandle, "EstatusID")
        'Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        'Dim TotalErrores As Integer = 0
        'Dim TotalIncidencias As Integer = 0
        'Dim index As Integer = 0
        'Try



        '    If EstatusID = 130 Then
        '        e.Formatting.BackColor = pnlEstatusRechazada.BackColor
        '    ElseIf Bloqueado = "SI" Then
        '        e.Formatting.BackColor = Color.Salmon
        '    Else
        '        'If e.ColumnFieldName = "ColorEstatus" Then
        '        '    e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

        '        'End If
        '    End If

        '    If e.ColumnFieldName = "ColorEstatus" Then
        '        e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

        '    End If

        '    If TipoPerfil = 2 Then

        '        If chkDetallada.Checked = False Then
        '            If e.ColumnFieldName = "TotalErrores" Then
        '                TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
        '                If TotalErrores > 0 Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Black
        '                End If
        '            End If
        '        End If



        '        If e.ColumnFieldName = "TotalIncidencias" Then
        '            TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

        '            If TotalIncidencias > 0 Then
        '                e.Formatting.Font.Color = Color.Red
        '            Else
        '                e.Formatting.Font.Color = Color.Black
        '            End If
        '        End If

        '        If e.ColumnFieldName = "FechaValidoAlmacen" Then
        '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
        '                If EstatusID = "129" Or EstatusID = "130" Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Green
        '                End If
        '            End If

        '        End If

        '        If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
        '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
        '                If EstatusID = "129" Or EstatusID = "130" Then
        '                    e.Formatting.Font.Color = Color.Red
        '                Else
        '                    e.Formatting.Font.Color = Color.Green
        '                End If
        '            End If

        '        End If


        '    End If

        'Catch ex As Exception
        '    show_message("Error", ex.Message.ToString())
        'End Try



        e.Handled = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class