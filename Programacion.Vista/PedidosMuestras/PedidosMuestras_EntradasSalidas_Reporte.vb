Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class PedidosMuestras_EntradasSalidas_Reporte

    Dim objBU As New Negocios.EntradaSalidaMuestrasBU
    Dim ObjSalidasEntradaMuestras As New PedidosMuestras_SalidasEntradas
    Dim NombreUsuario As String
    Dim FolioSeleccionado As Integer
    Dim Fila_Seleccionada As Integer
    Public cedisId As Integer
    Public nombreCedis As String
    Public tipoReporte As String

    Private Sub PedidosMuestras_EntradasSalidas_Reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NombreUsuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

        CargarComboNave(NombreUsuario)
        txtnombrecedis.Text = nombreCedis
        'dtmFechaInicioEnvio.Value = Date.Now
        'dtmFechaFinEnvio.Value = Date.Now
    End Sub

    Private Sub CargarComboNave(NombreUsuario As String)
        Dim dtNaves As New DataTable
        Try

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ENVIO_REC_MUESTRAS", "RESTRICCION_NAVES") Then
                dtNaves = objBU.ConsultarNavesUsuario_EnvioRecepcion(NombreUsuario, 1) 'NAVES ASIGNADAS
            Else
                dtNaves = objBU.ConsultarNavesUsuario_EnvioRecepcion(NombreUsuario, 2) 'TODAS LAS NAVES
            End If

            If dtNaves.Rows.Count > 0 Then
                dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
                cmbNaveMenu.DisplayMember = "NaveNombre"
                cmbNaveMenu.ValueMember = "NaveID"
                cmbNaveMenu.DataSource = dtNaves
                cmbNaveMenu.SelectedIndex = 0
            End If
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub CargarGrid()
        Dim NaveID As Integer
        Dim FechaInicio As String
        Dim FechaFin As String
        Dim dtFolios As DataTable

        NaveID = cmbNaveMenu.SelectedValue
        FechaInicio = dtmFechaInicioEnvio.Text
        FechaFin = dtmFechaFinEnvio.Text
        Cursor = Cursors.WaitCursor
        Try
            If txtnombrecedis.Text = "COMERCIALIZADORA" Then
                cedisId = 43
            Else
                cedisId = 82
            End If

            dtFolios = objBU.ConsultarFoliosEnvioRecepcion_Reporte(NaveID, FechaInicio, FechaFin, cedisId)
            If dtFolios.Rows.Count > 0 Then
                grdFolios.DataSource = dtFolios
                DiseñoGridEditable(GrdVFolios, " ")
            Else
                GrdVFolios.Columns.Clear()
                grdFolios.DataSource = Nothing
                show_message("Aviso", "No se encontró información con los filtros seleccionados.")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)
        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then
            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()
        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm

            mensajeExito.ShowDialog()
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNaveMenu.SelectedIndex > 0 Then
            CargarGrid()
        Else
            show_message("Advertencia", "Seleccione una nave válida.")
        End If
        FolioSeleccionado = 0
        lblFolioSeleccionado.Text = "-"
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If FolioSeleccionado > 0 Then
            ObjSalidasEntradaMuestras.ImprimirReporte(FolioSeleccionado, cedisId, tipoReporte)
        Else
            show_message("Advertencia", "Seleccione un folio.")
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dtmFechaInicioEnvio.Value = Date.Now
        dtmFechaFinEnvio.Value = Date.Now

        grdFolios.DataSource = Nothing
        FolioSeleccionado = 0
        lblFolioSeleccionado.Text = "-"
        Fila_Seleccionada = 0

        CargarComboNave(NombreUsuario)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub DiseñoGridEditable(Grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal ParamArray ColumnasEditables As Object())

        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next

        For i As Integer = 0 To ColumnasEditables.Length - 1
            Grid.Columns.ColumnByFieldName(ColumnasEditables(i)).OptionsColumn.AllowEdit = True
        Next

    End Sub

    Private Sub GrdVFolios_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GrdVFolios.CellValueChanging
        '    GrdVFolios.SetRowCellValue(Fila_Seleccionada, " ", False)
        If e.Column.ToString = " " Then
            SeleccionarFolio(If(e.Value, False, True), e.RowHandle)
        End If
    End Sub

    Private Sub SeleccionarFolio(Valor As Boolean, Fila As Integer)
        GrdVFolios.SetRowCellValue(Fila_Seleccionada, " ", False)

        Valor = If(Valor, False, True)

        GrdVFolios.SetRowCellValue(Fila, " ", Valor)
        If Valor = True Then
            FolioSeleccionado = GrdVFolios.GetRowCellValue(Fila, "Folio Envío")
            lblFolioSeleccionado.Text = FolioSeleccionado
            Fila_Seleccionada = Fila
        Else
            lblFolioSeleccionado.Text = "-"
        End If
    End Sub

    Private Sub GrdVFolios_RowClick(sender As Object, e As RowClickEventArgs) Handles GrdVFolios.RowClick
        Dim valor As Boolean = GrdVFolios.GetRowCellValue(e.RowHandle, " ")
        SeleccionarFolio(valor, e.RowHandle)

    End Sub



End Class