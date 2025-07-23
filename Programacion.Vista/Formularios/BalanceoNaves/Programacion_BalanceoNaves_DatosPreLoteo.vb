Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_BalanceoNaves_DatosPreLoteo
    Public Semana As Integer
    Public NaveID As Integer
    Public Año As Integer

    Private Sub Programacion_BalanceoNaves_DatosPreLoteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarDatosPreLoteo()
    End Sub

    Private Sub ConsultarDatosPreLoteo()
        Dim dtConsultarPreLoteo As New DataTable
        Dim objBU As New BalanceoNavesBU

        Try

            grdPreLoteo.DataSource = Nothing
            vwPreLoteo.Columns.Clear()

            dtConsultarPreLoteo = objBU.ObtieneDatosPreLoteo(NaveID, Semana, Año)

            If dtConsultarPreLoteo.Rows.Count > 0 Then
                If dtConsultarPreLoteo.Rows.Count = 1 Then
                    show_message("Advertencia", dtConsultarPreLoteo.Rows(0).Item("Mensaje").ToString())
                    Me.Close()
                    Exit Sub
                Else
                    grdPreLoteo.DataSource = dtConsultarPreLoteo
                    lblUltimaActualizacion.Text = Date.Now
                    DisenioGrid()
                End If

            Else
                show_message("Advertencia", "No hay información para mostrar.")
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwPreLoteo.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        vwPreLoteo.Columns.ColumnByFieldName("Nave").Width = 80
        vwPreLoteo.Columns.ColumnByFieldName("PedidoSAYID").Width = 60
        vwPreLoteo.Columns.ColumnByFieldName("PedidoSICYID").Width = 60
        vwPreLoteo.Columns.ColumnByFieldName("Cliente").Width = 250
        vwPreLoteo.Columns.ColumnByFieldName("Descripción").Width = 300
        vwPreLoteo.Columns.ColumnByFieldName("Partida").Width = 60
        vwPreLoteo.Columns.ColumnByFieldName("Pares Totales").Width = 60
        vwPreLoteo.Columns.ColumnByFieldName("Colección Especial").Width = 70
        vwPreLoteo.Columns.ColumnByFieldName("Tamaño Colección Especial").Width = 70
        vwPreLoteo.Columns.ColumnByFieldName("Tamaño Estandar").Width = 70
        vwPreLoteo.Columns.ColumnByFieldName("Distribución").Width = 80
        vwPreLoteo.Columns.ColumnByFieldName("Programa").Width = 80


        vwPreLoteo.Columns.ColumnByFieldName("ProgramaID").Visible = False

        vwPreLoteo.Columns.ColumnByFieldName("Pares Totales").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwPreLoteo.Columns.ColumnByFieldName("Pares Totales").DisplayFormat.FormatString = "N0"
        vwPreLoteo.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(vwPreLoteo.Columns("Pares Totales").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares Totales")) = True Then
            vwPreLoteo.Columns("Pares Totales").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares Totales", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares Totales"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwPreLoteo.GroupSummary.Add(item)
        End If

        DiseñoGrid.AlternarColorEnFilas(vwPreLoteo)
        DiseñoGrid.AlinearTextoEncabezadoColumnas(vwPreLoteo)



        vwPreLoteo.IndicatorWidth = 40
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub vwPreLoteo_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwPreLoteo.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnGenerarPreLoteo_Click(sender As Object, e As EventArgs) Handles btnGenerarPreLoteo.Click
        Dim objBU As New BalanceoNavesBU
        Dim confirmar As New ConfirmarForm
        Dim dtIniciarEjecucionAlgoritmos As New DataTable

        Try
            confirmar.mensaje = "¿Desea generar el preloteo? Este proceso puede durar unos minutos y no se podrá revertir."
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Cursor = Cursors.WaitCursor

                dtIniciarEjecucionAlgoritmos = objBU.EjecutarProcesoDeAlgoritmos(NaveID, Semana, Año)

                If dtIniciarEjecucionAlgoritmos.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                    show_message("Exito", "Proceso de preloteo concluido exitosamente.")
                Else
                    show_message("Advertencia", "Ha ocurrido un error al realizar el proceso de PreLoteo, intente nuevamente.")
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class