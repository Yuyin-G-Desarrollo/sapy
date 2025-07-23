Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report
Public Class ConsultaDevolucionesNaveForm


    Dim OBJBU As New Almacen.Negocios.InspeccionCalidadBU
    Dim lstFiltroFoliosInspeccion As New List(Of String)
    Dim lstFiltroFoliosSalida As New List(Of String)
    Dim lstFiltroFoliosDevolucion As New List(Of String)

    Dim lstInicial As New List(Of String)
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ConsultaDevolucionesNaveForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            Cursor = Cursors.WaitCursor
            lblTotalRegistros.Text = "0"
            Me.WindowState = FormWindowState.Maximized
            ObtenerCEDISUsuario()
            CargarEstatusIniciales()
            ObtenerInformacion()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub ObtenerCEDISUsuario()
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

    End Sub

    Public Sub CargarEstatusIniciales()
        Dim dtResultado As New DataTable

        Try
            dtResultado.Columns.Add("Parámetro")
            dtResultado.Columns.Add(" ")
            dtResultado.Columns.Add("Status")

            dtResultado.Rows.Add(210, 0, "ACTIVO")
            dtResultado.Rows.Add(211, 0, "PARCIALMENTE INGRESADO")

            grdStatus.DataSource = dtResultado

            With grdStatus
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function

    Public Function OtenerCadenaFiltro(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If Resultado = String.Empty Then
                Resultado = row.Cells(0).Text
            Else
                Resultado = row.Cells(0).Text + "," + Resultado
            End If
        Next
        Return Resultado
    End Function

    Private Sub ObtenerInformacion()
        Dim DtInformacion As New DataTable
        Dim FiltroFoliosInspeccion As String = String.Empty
        Dim FiltrofolioSalida As String = String.Empty
        Dim FiltrofolioDevolucion As String = String.Empty
        Dim FiltroNave As String = String.Empty
        Dim FiltroStatus As String = String.Empty
        Dim CEDISID As String = String.Empty

        Try
            grdListadoDevoluciones.DataSource = Nothing
            FiltroFoliosInspeccion = ObtenerFiltrosGrid(grdFiltroFolioInspeccion)
            FiltrofolioSalida = ObtenerFiltrosGrid(grdFiltroFolioSalida)
            FiltrofolioDevolucion = ObtenerFiltrosGrid(gridfiltroFolioDevolucion)
            FiltroNave = ObtenerFiltrosGrid(grdNave)
            'FiltroStatus = ObtenerFiltrosGrid(grdStatus)
            FiltroStatus = OtenerCadenaFiltro(grdStatus)
            CEDISID = cmbCEDIS.SelectedValue
            DtInformacion = OBJBU.ConsultarDevolucionesNave(FiltrofolioDevolucion, FiltrofolioSalida, FiltroFoliosInspeccion, FiltroNave, FiltroStatus, chkFechaInspeccion.Checked, dtpFechaInicio.Value.ToShortDateString(), dtpFechaFin.Value.ToShortDateString(), CEDISID)


            grdListadoDevoluciones.DataSource = DtInformacion
            DiseñoGrid.DiseñoBaseGrid(viewListadoDevoluciones)
            viewListadoDevoluciones.IndicatorWidth = 30
            viewListadoDevoluciones.OptionsView.ColumnAutoWidth = True
            'viewListadoDevoluciones.OptionsView.ColumnAutoWidth = True
            If DtInformacion.Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para mostrar.")
            Else


                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "DevolucionNaveID", "Folio Rechazo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "FechaCaptura", "Fecha Captura", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "Colaborador", "Inspector", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "FechaEstimadaRegreso", "Fecha Estimada Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "FechaRegreso", "Fecha Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "CantidadDevuelta", "Cantidad Devuelta", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "CantidadRegreso", "Cantidad Regreso", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "CantidadPendiente", "Cantidad Pendiente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "FechaCancelacion", "Fecha Cancelacion", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "MotivoCancelacion", "Motivo Cancelacion", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "ColaboradorRecibio", "Recibio", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "LCliente", "LCliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "Status", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 20, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "StatusID", "StatusID", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "FolioSalidaID", "Folio Salida", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "FolioInspeccionID", "FolioInspeccionID", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "DiasTranscurridos", "Dias Transcurridos", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 40, False, Nothing, "")
                DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "DiasParaEntrega", "Dias Para Entrega", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 60, False, Nothing, "")
                'If CEDISID = "82" Then
                'DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "lotes", "lotes", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 20, False, Nothing, "")
                'DiseñoGrid.EstiloColumna(viewListadoDevoluciones, "lotes", "lotes", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, False, 20, False, Nothing, "")
                'End If



                viewListadoDevoluciones.Columns("Status").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            End If

            lblTotalRegistros.Text = CDbl(DtInformacion.Rows.Count).ToString("N0")

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar la información.")
        End Try


    End Sub

    Private Sub viewListadoDevoluciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewListadoDevoluciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        ExportarExcel()
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdListadoDevoluciones.ExportToXlsx(.SelectedPath + "\Datos_DevolucionNave_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdListadoDevoluciones.ExportToXlsx(.SelectedPath + "\Datos_DevolucionNave_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    ' Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_DevolucionNave_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_DevolucionNave_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim CantidadPendiente As Integer = viewListadoDevoluciones.GetRowCellValue(e.RowHandle, "CantidadPendiente")
        Dim Status As String = viewListadoDevoluciones.GetRowCellValue(e.RowHandle, "Status")
        Dim statusid As Integer
        Dim DiasParaEntrega As Integer
        Try


            If e.ColumnFieldName = "CantidadPendiente" Then
                If CantidadPendiente > 0 Then
                    e.Formatting.Font.Color = Color.Red
                Else
                    e.Formatting.Font.Color = Color.Black
                End If
            End If

            If e.ColumnFieldName = "Status" Then

                statusid = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "StatusID")

                If statusid = 210 Then
                    e.Formatting.BackColor = Color.LightSeaGreen
                    ' e.Appearance.ForeColor = Color.White
                ElseIf statusid = 211 Then
                    e.Formatting.BackColor = Color.Yellow
                    ' e.Appearance.ForeColor = Color.White
                ElseIf statusid = 212 Then
                    e.Formatting.BackColor = Color.Brown
                    ' e.Appearance.ForeColor = Color.White
                End If
            End If


            If e.ColumnFieldName = "DiasTranscurridos" Then

                DiasParaEntrega = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "DiasParaEntrega")

                If DiasParaEntrega > 0 Then
                    e.Formatting.BackColor = Color.LightSeaGreen
                    'e.Appearance.ForeColor = Color.White
                ElseIf DiasParaEntrega = 0 Then
                    e.Formatting.BackColor = Color.Orange
                Else
                    e.Formatting.BackColor = Color.Tomato
                End If

            End If



        Catch ex As Exception

        End Try

        e.Handled = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 180
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAgregarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroNave.Click
        Dim listado As New ListadoParametrosForm
        listado.tipo_busqueda = 18
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNave.DataSource = listado.listParametros
        With grdNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Nave"
        End With
    End Sub

    Private Sub btnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroNave.Click
        grdNave.DataSource = lstInicial
    End Sub

    Private Sub btnAgregarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroStatus.Click
        Dim listado As New ListadoParametrosForm
        listado.tipo_busqueda = 20
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdStatus.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatus.DataSource = listado.listParametros
        With grdStatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(4).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
        End With
    End Sub

    Private Sub btnLimpiarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click
        grdStatus.DataSource = lstInicial
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub grdStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatus.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroFolioInspeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroFolioInspeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroFolioInspeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFiltroFolioSalida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroFolioSalida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroFolioSalida.DeleteSelectedRows(False)
    End Sub

    Private Sub gridfiltroFolioDevolucion_KeyDown(sender As Object, e As KeyEventArgs) Handles gridfiltroFolioDevolucion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridfiltroFolioDevolucion.DeleteSelectedRows(False)
    End Sub

    Private Sub txtFiltroFolioInspeccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioInspeccion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioInspeccion.Text) Then Return

            lstFiltroFoliosInspeccion.Add(txtFiltroFolioInspeccion.Text)
            grdFiltroFolioInspeccion.DataSource = Nothing
            grdFiltroFolioInspeccion.DataSource = lstFiltroFoliosInspeccion

            txtFiltroFolioInspeccion.Text = String.Empty

        End If
    End Sub

    Private Sub txtFiltroFolioSalida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioSalida.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioSalida.Text) Then Return

            lstFiltroFoliosSalida.Add(txtFiltroFolioSalida.Text)
            grdFiltroFolioSalida.DataSource = Nothing
            grdFiltroFolioSalida.DataSource = lstFiltroFoliosSalida

            txtFiltroFolioSalida.Text = String.Empty

        End If
    End Sub

    Private Sub txtFolioDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioDevolucion.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFolioDevolucion.Text) Then Return

            lstFiltroFoliosDevolucion.Add(txtFolioDevolucion.Text)
            gridfiltroFolioDevolucion.DataSource = Nothing
            gridfiltroFolioDevolucion.DataSource = lstFiltroFoliosDevolucion

            txtFolioDevolucion.Text = String.Empty

        End If
    End Sub

    Private Sub chkFechaInspeccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechaInspeccion.CheckedChanged
        dtpFechaInicio.Enabled = chkFechaInspeccion.Checked
        dtpFechaFin.Enabled = chkFechaInspeccion.Checked
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            chkFechaInspeccion.Checked = False
            grdFiltroFolioInspeccion.DataSource = Nothing
            grdFiltroFolioSalida.DataSource = Nothing
            grdStatus.DataSource = Nothing
            txtFiltroFolioInspeccion.Text = String.Empty
            txtFiltroFolioSalida.Text = String.Empty
            dtpFechaInicio.Value = Date.Now
            dtpFechaFin.Value = Date.Now
            lblTotalRegistros.Text = "0"

            grdNave.DataSource = Nothing

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Calidad_Inpeccion", "FOLIOS_NAVE") = False Then
                grdNave.DataSource = Nothing
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDetalles_Click(sender As Object, e As EventArgs) Handles btnDetalles.Click
        Dim DetFolio As New DetallesDevolucionNaveForm
        Dim FolioDevolucionID As Integer = 0
        Dim Nave As String = String.Empty
        Dim ParesDevueltos As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            For Each Fila As Integer In viewListadoDevoluciones.GetSelectedRows()
                FolioDevolucionID = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "DevolucionNaveID").ToString()
                Nave = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "Nave").ToString()
                ParesDevueltos = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "CantidadDevuelta").ToString()
            Next

            If FolioDevolucionID > 0 Then
                DetFolio.FolioDevolucionId = FolioDevolucionID
                DetFolio.Nave = Nave
                DetFolio.ParesDevueltos = ParesDevueltos
                DetFolio.MdiParent = Me.MdiParent
                DetFolio.Show()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de devolución.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Cursor = Cursors.WaitCursor
            ObtenerInformacion()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub viewListadoDevoluciones_RowClick(sender As Object, e As RowClickEventArgs) Handles viewListadoDevoluciones.RowClick
        Dim DetFolio As New DetallesDevolucionNaveForm
        Dim FolioDevolucionID As Integer = 0
        Dim Nave As String = String.Empty
        Dim ParesDevueltos As Integer = 0

        If e.Clicks = 2 And e.RowHandle >= 0 Then

            Try
                Cursor = Cursors.WaitCursor
                FolioDevolucionID = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "DevolucionNaveID").ToString()
                Nave = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "Nave").ToString()
                ParesDevueltos = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "CantidadDevuelta").ToString()

                If FolioDevolucionID > 0 Then
                    DetFolio.FolioDevolucionId = FolioDevolucionID
                    DetFolio.Nave = Nave
                    DetFolio.ParesDevueltos = ParesDevueltos
                    DetFolio.MdiParent = Me.MdiParent
                    DetFolio.Show()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de inspección.")
                End If

                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            End Try
        End If
    End Sub

    Private Sub btnReingreso_Click(sender As Object, e As EventArgs) Handles btnReingreso.Click
        Dim CapturaFolio As New CapturaFolioDevolucionForm
        Dim dlgResult As New DialogResult


        Try
            Cursor = Cursors.WaitCursor
            CapturaFolio.StartPosition = FormStartPosition.CenterScreen
            dlgResult = CapturaFolio.ShowDialog()

            If dlgResult = DialogResult.OK Then
                Dim ventana As New ReingresoDevolucionForm
                ventana.FolioDevolucion = CapturaFolio.FolioDevolucion
                ' ventana.MdiParent = Me.MdiParent
                ventana.Show()
                ObtenerInformacion()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try




        'Dim ventana As New ReingresoDevolucionForm
        'Dim FolioDevolucionID As Integer = 0
        'Dim Nave As String = String.Empty
        'Dim ParesDevueltos As Integer = 0

        'Try
        '    Cursor = Cursors.WaitCursor

        '    For Each Fila As Integer In viewListadoDevoluciones.GetSelectedRows()
        '        FolioDevolucionID = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "DevolucionNaveID").ToString()
        '    Next

        '    If FolioDevolucionID > 0 Then
        '        ventana.FolioDevolucion = FolioDevolucionID
        '        'ventana.MdiParent = Me.MdiParent
        '        ventana.Show()
        '    Else
        '        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de devolución.")
        '    End If

        '    Cursor = Cursors.Default
        'Catch ex As Exception
        '    Cursor = Cursors.Default
        '    Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        'End Try


    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim DetFolio As New CapturaFechaEstimadaRegresoForm
        Dim FolioDevolucionID As Integer = 0
        Dim Nave As String = String.Empty
        Dim ParesDevueltos As Integer = 0
        Dim FechaEstimadaRegreso As Date
        Dim Tratamiento As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor

            For Each Fila As Integer In viewListadoDevoluciones.GetSelectedRows()
                FolioDevolucionID = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "DevolucionNaveID").ToString()
                FechaEstimadaRegreso = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "FechaEstimadaRegreso").ToString()
                Tratamiento = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "Tratamiemto").ToString()
            Next

            If FolioDevolucionID > 0 Then
                DetFolio.FolioDevolucion = FolioDevolucionID
                DetFolio.FechaEstimadaRegtreso = FechaEstimadaRegreso
                DetFolio.Tratamiento = Tratamiento
                ' DetFolio.MdiParent = Me.MdiParent
                DetFolio.ShowDialog()
                ObtenerInformacion()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de devolución.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub grdFiltroFolioInspeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFolioInspeccion.InitializeLayout
        grid_diseño(grdFiltroFolioInspeccion)
        grdFiltroFolioInspeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Inspección"
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

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next
    End Sub

    Private Sub grdFiltroFolioSalida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFolioSalida.InitializeLayout
        grid_diseño(grdFiltroFolioSalida)
        grdFiltroFolioSalida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Salida"
    End Sub

    Private Sub gridfiltroFolioDevolucion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridfiltroFolioDevolucion.InitializeLayout
        grid_diseño(gridfiltroFolioDevolucion)
        gridfiltroFolioDevolucion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Devolución"
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
    End Sub

    Private Sub grdStatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatus.InitializeLayout
        grid_diseño(grdStatus)
    End Sub

    Private Sub viewListadoDevoluciones_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewListadoDevoluciones.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim StatusID As Integer = 0
        Dim DiasParaEntrega As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "CantidadPendiente" Then
                If e.CellValue > 0 Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If

            If e.Column.FieldName = "Status" Then

                StatusID = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "StatusID")

                If StatusID = 210 Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    ' e.Appearance.ForeColor = Color.White
                ElseIf StatusID = 211 Then
                    e.Appearance.BackColor = Color.Yellow
                    ' e.Appearance.ForeColor = Color.White
                ElseIf StatusID = 212 Then
                    e.Appearance.BackColor = Color.Brown
                    ' e.Appearance.ForeColor = Color.White
                End If
            End If

            '210 DEVOLUCION	1	DEVOLUCION_INSPECCION	ACTIVO
            '211 DEVOLUCION	2	DEVOLUCION_INSPECCION	PARCIALMENTE INGRESADO
            '212 DEVOLUCION	3	DEVOLUCION_INSPECCION	INGRESADO


            If e.Column.FieldName = "DiasTranscurridos" Then

                DiasParaEntrega = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(e.RowHandle), "DiasParaEntrega")

                If DiasParaEntrega > 0 Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    'e.Appearance.ForeColor = Color.White
                ElseIf DiasParaEntrega = 0 Then
                    e.Appearance.BackColor = Color.Orange
                Else
                    e.Appearance.BackColor = Color.Tomato
                End If

            End If


            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim AltaReprocesoForm As New AltaParesReprocesoForm
        AltaReprocesoForm.MdiParent = Me.MdiParent
        AltaReprocesoForm.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim DetFolio As New CapturaFechaEstimadaRegresoForm
        Dim FolioDevolucionID As Integer = 0
        Dim Nave As String = String.Empty
        Dim ParesDevueltos As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            For Each Fila As Integer In viewListadoDevoluciones.GetSelectedRows()
                FolioDevolucionID = viewListadoDevoluciones.GetRowCellValue(viewListadoDevoluciones.GetVisibleRowHandle(Fila), "DevolucionNaveID").ToString()
            Next

            If FolioDevolucionID > 0 Then
                imprimirReporte(FolioDevolucionID)
                ' Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha generado el documento exitosamente.")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado un Folio de devolución.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Public Sub imprimirReporte(ByVal FolioDevolucionID As Integer)
        Dim objbuT As New Almacen.Negocios.AlmacenBU
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsDevoluciones As New DataSet("dsDevolucion")
        Dim dtDevoluciones As New DataTable("dtDevolucion")
        Dim dtDevolucionesAux As New DataTable
        Dim dtDevolucionesEncabezado As New DataTable
        Dim dtInformacionCentroDistribucion As DataTable
        Dim ReporteDevolucion As New StiReport

        Try
            Cursor = Cursors.WaitCursor
            Dim tool As New Tools.Controles

            dtDevolucionesEncabezado = OBJBU.ConsultaEncabezadoDevolucionReporte(FolioDevolucionID)
            dtDevoluciones = OBJBU.ConsultaDetallesDevolucionReporte(FolioDevolucionID)

            dtInformacionCentroDistribucion = objbuT.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            Dim prueba = dtInformacionCentroDistribucion.Rows(0).Item(0)

            If prueba = 43 Then
                entReporte = objReporte.LeerReporteporClave("CALIDAD_REPORTE_DEVOLUCION")
            Else
                entReporte = objReporte.LeerReporteporClave("CALIDAD_REPORTE_DEVOLUCION_RE")
            End If

            dsDevoluciones.Tables.Add(dtDevoluciones)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReporteDevolucion.Load(archivo)
            ReporteDevolucion.Compile()
            ReporteDevolucion.RegData(dsDevoluciones)
            ReporteDevolucion("Nave") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("Nave")).FirstOrDefault()
            ReporteDevolucion("FechaSolicitudRegreso") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("FechaEstimadaRegreso")).FirstOrDefault().ToString
            ReporteDevolucion("FechaRegreso") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("FechaRegreso")).FirstOrDefault().ToString
            ReporteDevolucion("Folio") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("FolioDevolucionID")).FirstOrDefault().ToString
            ReporteDevolucion("FechaImpresion") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("FechaImpresion")).FirstOrDefault().ToString
            ReporteDevolucion("Recibio") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("Recibio")).FirstOrDefault().ToString
            ReporteDevolucion("Entrego") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("Entrego")).FirstOrDefault().ToString
            ReporteDevolucion("Tratamiento") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("Tratamiento")).FirstOrDefault().ToString
            ReporteDevolucion("TotalDevolucion") = dtDevolucionesEncabezado.AsEnumerable.Select(Function(x) x.Item("Pares")).FirstOrDefault().ToString
            ReporteDevolucion.Dictionary.Clear()
            ReporteDevolucion.Dictionary.Synchronize()
            'ReporteDevolucion.Render()
            ReporteDevolucion.Show()

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Public Sub CargarNaves()



    End Sub

    Public Sub CargarOperadorEntrego()

    End Sub


End Class