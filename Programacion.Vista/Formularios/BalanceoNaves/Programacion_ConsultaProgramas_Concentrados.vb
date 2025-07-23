Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ConsultaProgramas_Concentrados
    Dim confirmar As New ConfirmarForm
    Dim ProgramaID As Integer = 0
    Dim NaveID As Integer = 0
    Dim Semana As Integer = 0
    Dim Año As Integer = 0

    Private Sub Programacion_ConsultaProgramas_Concentrados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        NSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        NSemanaInicio.TextAlign = HorizontalAlignment.Center
        NAñoInicio.Value = DatePart(DateInterval.Year, Now)
        NAñoInicio.TextAlign = HorizontalAlignment.Center

    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGrupo.SelectedIndexChanged
        If cmbGrupo.Text <> "" Then
            CargarNaveAuxiliar(cmbGrupo.Text)
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex <> 0 Then
            CargarProgramas(cmbNave.SelectedValue)
        End If
    End Sub

    Private Sub CargarNaveAuxiliar(ByVal Grupo As String)
        Dim dtNaves As New DataTable
        Dim objBU As New BalanceoNavesBU

        dtNaves = objBU.ConsultarNavesAux(Grupo)

        If dtNaves.Rows.Count > 0 Then
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            cmbNave.DataSource = dtNaves
            cmbNave.ValueMember = "NaveSAYId"
            cmbNave.DisplayMember = "Nave"

        Else
            show_message("Advertencia", "No existe información de naves.")
        End If
    End Sub

    Private Sub CargarProgramas(ByVal NaveID As Integer)
        Dim objBU As New BalanceoNavesBU
        Dim dtCargarProgramas As New DataTable

        Semana = NSemanaInicio.Value
        Año = NAñoInicio.Value


        dtCargarProgramas = objBU.ObtenerListadoProgramasConcentrado(NaveID, Semana, Año)

        If dtCargarProgramas.Rows.Count > 0 Then
            dtCargarProgramas.Rows.InsertAt(dtCargarProgramas.NewRow, 0)
            cmbPrograma.DataSource = dtCargarProgramas
            cmbPrograma.ValueMember = "ProgramaID"
            cmbPrograma.DisplayMember = "Programa"
        Else
            show_message("Advertencia", "No existen programas para mostrar.")
        End If
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtInfoConcentra As New DataTable


        Try
            vwConsultarPrograma.Columns.Clear()
            grdConsultarPrograma.DataSource = Nothing

            If IsDBNull(cmbNave.SelectedValue) Then
                NaveID = 0
            Else
                NaveID = cmbNave.SelectedValue
            End If

            If IsDBNull(cmbPrograma.SelectedValue) Then
                show_message("Advertencia", "Seleccione un programa.")
                Exit Sub
            Else
                ProgramaID = cmbPrograma.SelectedValue
            End If

            dtInfoConcentra = objBU.PreparacionparaConcentrados(ProgramaID, NaveID)

            If dtInfoConcentra.Rows.Count > 0 Then
                grdConsultarPrograma.DataSource = dtInfoConcentra
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()
                lblRegistros.Text = CDbl(vwConsultarPrograma.RowCount.ToString()).ToString("n0")
            Else
                show_message("Advertencia", "No hay información para mostrar")
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwConsultarPrograma.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwConsultarPrograma.Columns.ColumnByFieldName(" ").Width = 40
        vwConsultarPrograma.Columns.ColumnByFieldName("Cliente").Width = 260
        vwConsultarPrograma.Columns.ColumnByFieldName("Partida").Width = 60
        vwConsultarPrograma.Columns.ColumnByFieldName("Pedido SAY").Width = 70
        vwConsultarPrograma.Columns.ColumnByFieldName("Pedido SICY").Width = 70
        vwConsultarPrograma.Columns.ColumnByFieldName("Modelo SAY").Width = 70
        vwConsultarPrograma.Columns.ColumnByFieldName("Descripción").Width = 420
        vwConsultarPrograma.Columns.ColumnByFieldName("Pares").Width = 60
        vwConsultarPrograma.Columns.ColumnByFieldName("Numeración").Width = 60
        vwConsultarPrograma.Columns.ColumnByFieldName("F Entrega").Width = 80
        vwConsultarPrograma.Columns.ColumnByFieldName("Lote").Width = 60
        vwConsultarPrograma.Columns.ColumnByFieldName("CN").Width = 60

        vwConsultarPrograma.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
        vwConsultarPrograma.Columns.ColumnByFieldName("Numeración").Caption = "N"

        vwConsultarPrograma.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwConsultarPrograma.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"
        vwConsultarPrograma.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(vwConsultarPrograma.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            vwConsultarPrograma.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwConsultarPrograma.GroupSummary.Add(item)
        End If

        vwConsultarPrograma.IndicatorWidth = 30
        DiseñoGrid.AlternarColorEnFilas(vwConsultarPrograma)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtGeneracionPares As New DataTable
        Dim confirmar As New ConfirmarForm
        Dim Session As Integer = 0

        Try
            If vwConsultarPrograma.DataRowCount > 0 Then
                confirmar.mensaje = "¿Se realizará el proceso de Loteo, puede tomar unos minutos y no se podrá revertir, ¿Desea Continuar?"
                If confirmar.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    dtGeneracionPares = objBU.GeneracionParesLoteo(ProgramaID, NaveID, Semana, Año, Session)

                    If dtGeneracionPares.Rows(0).Item("respuesta").ToString() <> "ERROR" Then
                        show_message("Exito", "Datos actualizados correctamente.")
                        btnMostrar_Click(Nothing, Nothing)
                    Else
                        show_message("Advertencia", "Ocurrió un error al generar los lotes, intente nuevamente")
                        Exit Sub
                    End If

                End If
            Else
                show_message("Advertencia", "No existen datos para actualizar.")
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)


        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnGenerarConcentrado_Click(sender As Object, e As EventArgs) Handles btnGenerarConcentrado.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtGenerarConcentrado As New DataTable

        Try

            If vwConsultarPrograma.DataRowCount > 0 Then
                If IsDBNull(cmbNave.SelectedValue) Then
                    NaveID = 0
                Else
                    NaveID = cmbNave.SelectedValue
                End If

                If IsDBNull(cmbPrograma.SelectedValue) Then
                    show_message("Advertencia", "Seleccione un programa.")
                    Exit Sub
                Else
                    ProgramaID = cmbPrograma.SelectedValue
                End If


                confirmar.mensaje = "¿Desea generar los concentrados del programa seleccionado.?"
                If confirmar.ShowDialog() = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    dtGenerarConcentrado = objBU.GenerarConcentradosPorProgramaPorNave(ProgramaID, NaveID)

                    If dtGenerarConcentrado.Rows(0).Item("respuesta").ToString = "No hay concentrados por Generar." Then
                        show_message("Advertencia", "No hay concentrados por generar, puede proceder al Loteo.")
                        btnMostrar_Click(Nothing, Nothing)
                    Else
                        show_message("Exito", "Concentrados Generados Correctamente.")
                        btnMostrar_Click(Nothing, Nothing)
                    End If


                End If
            Else
                show_message("Advertencia", "No existen datos para concentrar.")
            End If


        Catch ex As Exception
            show_message("Advertencia", "No hay información para mostrar")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnConfConcentrados_Click(sender As Object, e As EventArgs) Handles btnConfConcentrados.Click
        Dim confConcentrado As New Programacion_Configuracion_ConcentradoClientes
        confConcentrado.Show()
    End Sub

    Private Sub btnEliminarConcentrados_Click(sender As Object, e As EventArgs) Handles btnEliminarConcentrados.Click
        Dim objBU As New BalanceoNavesBU
        Dim dtEliminarConcentrados As New DataTable
        Dim NumeroFilas As Integer = vwConsultarPrograma.DataRowCount
        Dim Lote As Integer = 0
        Dim CN As Integer = 0
        Dim confirmar As New ConfirmarForm

        Try

            If vwConsultarPrograma.DataRowCount > 0 Then

                With vwConsultarPrograma
                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") And .GetRowCellValue(index, "CN").ToString() <> "0" And .GetRowCellValue(index, "Lote") = "0" Then
                            CN = .GetRowCellValue(index, "CN")

                            dtEliminarConcentrados = objBU.EliminarConcentrados(CN, ProgramaID, NaveID)

                            If dtEliminarConcentrados.Rows(0).Item("respuesta").ToString() = "ERROR" Then
                                show_message("Advertencia", "Ocurrió un error al eliminar los concentrados, intente nuevamente.")
                                Exit Sub
                            End If
                        Else
                            show_message("Advertencia", "Únicamente se pueden eliminar los que no se encuentran loteados.")
                            Exit Sub
                        End If
                    Next
                End With

            Else
                show_message("Advertencia", "Seleccione un concentrado para eliminar.")
            End If

        Catch ex As Exception
            show_message("Advertencia", "Ocurrió un error al eliminar los concentrados, intente nuevamente.")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub vwConsultarPrograma_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwConsultarPrograma.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub


End Class