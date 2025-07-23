Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports Tools

Public Class ConfiguracionGeneralForm
    Public licencia As Integer
    Private listCeldasModificadas As New List(Of GridCell)()
    Private Editable As Boolean = False

    Private Sub ConfiguracionGeneralForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        CargarGrid()
        If licencia = 1 Then
            pnlEditar.Visible = False
            Label8.Visible = False
            lblTexto.Visible = False
            lblMostrar.Visible = False
            btnMostrar.Visible = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            lblEncabezado.Text = "Configuración Discovery"
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Aplicar_Permisos()
        btnEditar.Visible = False
        lblEditar.Visible = False
        btnGuardar.Visible = False
        lblGuardar.Visible = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_EDITAR_CONFIG_GENERAL") Then
            btnEditar.Visible = True
            lblEditar.Visible = True
            If licencia = 1 Then
                btnEditar.Visible = False
                lblEditar.Visible = False
            End If
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_EXPORTAR_CONFIG_GENERAL") Then
            btnExportar.Visible = True
            lblExportar.Visible = True
            If licencia = 1 Then
                btnEditar.Visible = False
                lblEditar.Visible = False
            End If
        End If
    End Sub


    Private Sub CargarGrid()
        Dim objBu As New Negocios.EtiquetasBU
        Dim dt As DataTable
        Try

            dt = objBu.ConsultarConfiguracionGeneralCorridasExtranjeras(licencia)
            DiseñoGrid_Bands(GrdVConfiguracionGeneral, dt)
            GrdConfiguracionGeneral.DataSource = dt
            DiseñoGrid_Color(GrdVConfiguracionGeneral, licencia)
            Editable = False
            Activar_Inactivar_Grid(Editable)
            GrdConfiguracionGeneral.Select()


        Catch ex As Exception
            Dim msg_error As New ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub DiseñoGrid_Color(Grid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView, ByVal Licencia As Integer)

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        'Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedCell.ForeColor = Color.White

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White
        GrdVConfiguracionGeneral.OptionsView.ColumnAutoWidth = True
        GrdVConfiguracionGeneral.OptionsView.BestFitMaxRowCount = -1

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GrdVConfiguracionGeneral.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        If Licencia = 0 Then
            Grid.Columns.ColumnByFieldName("IdTallaSAY").Caption = "Talla SAY"
            Grid.Columns.ColumnByFieldName("IdTallaSicy").Caption = "Talla SICY"
            Grid.Columns.ColumnByFieldName("Corrida").Caption = "Corrida"
            Grid.Columns.ColumnByFieldName("tallaMex").Caption = "Talla MX"

            Grid.Columns.ColumnByFieldName("IdTallaSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("IdTallaSicy").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("Corrida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("tallaMex").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Else

            Grid.Columns.ColumnByFieldName("tel_idtbl").Visible = False
            Grid.Columns.ColumnByFieldName("tel_IdMarca").Visible = False

            Grid.Columns.ColumnByFieldName("LICENCIA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("MEX").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("USA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("EUR").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        End If


        GrdVConfiguracionGeneral.BestFitColumns()
    End Sub


    Private Sub DiseñoGrid_Bands(Grid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView, ByVal dtResultado As DataTable)

        Dim band As New GridBand
        Dim listBands As New List(Of GridBand)

        GrdConfiguracionGeneral.DataSource = Nothing
        Grid.Bands.Clear()
        Grid.Columns.Clear()

        band.Caption = ""
        listBands.Add(band)
        band = New GridBand
        band.Caption = "Corridas Extranjeras"
        listBands.Add(band)

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                    Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                    Grid.Columns.ColumnByFieldName("#").OwnerBand = gridBand
                    AddHandler Grid.CustomUnboundColumnData, AddressOf GrdVConfiguracionGeneral_CustomUnboundColumnData
                    Grid.Columns.Item("#").VisibleIndex = 0
                    Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
                End If
            End If
            For Each col As DataColumn In dtResultado.Columns
                If col.Ordinal > 3 And gridBand.Caption <> "" Then
                    Grid.Columns.AddField(col.ColumnName)
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    Grid.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = True
                ElseIf col.Ordinal < 4 And gridBand.Caption = "" Then
                    Grid.Columns.AddField(col.ColumnName)
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    Grid.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = False
                End If
            Next
            Grid.Bands.Add(gridBand)
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GrdVConfiguracionGeneral.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

    End Sub


    Private Sub Activar_Inactivar_Grid(ByVal Editable As Boolean)
        For Each bands As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GrdVConfiguracionGeneral.Bands
            If bands.Caption = "Corridas Extranjeras" Then
                For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bands.Columns
                    GrdVConfiguracionGeneral.Columns.ColumnByFieldName(col.GetCaption).OptionsColumn.AllowEdit = Editable
                Next
            End If
        Next
    End Sub

    Private Sub GrdVConfiguracionGeneral_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = GrdVConfiguracionGeneral.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Function ExisteCelda(ByVal sourceRowIndex As Integer, ByVal col As GridColumn) As Boolean
        Dim Resultado As GridCell = listCeldasModificadas.Where(Function(c) c.Column Is col AndAlso c.RowHandle = sourceRowIndex).FirstOrDefault()
        Return Resultado IsNot Nothing
    End Function


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Editable = True
        Activar_Inactivar_Grid(Editable)
        'GrdVConfiguracionGeneral.FocusedRowHandle = 0
        GrdVConfiguracionGeneral.FocusedColumn = GrdVConfiguracionGeneral.Bands.ElementAt(1).Columns.Item(0)
        GrdVConfiguracionGeneral.ShowEditor()
    End Sub

    Private Sub GrdVConfiguracionGeneral_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GrdVConfiguracionGeneral.CellValueChanged
        Dim cell As New GridCell(GrdVConfiguracionGeneral.GetDataSourceRowIndex(e.RowHandle), e.Column)
        listCeldasModificadas.Add(cell)
    End Sub

    Private Sub GrdVConfiguracionGeneral_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GrdVConfiguracionGeneral.CustomDrawCell
        If Editable = True Then
            If IsDBNull(GrdVConfiguracionGeneral.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False And IsNothing(GrdVConfiguracionGeneral.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                If (ExisteCelda(GrdVConfiguracionGeneral.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
                    e.Appearance.ForeColor = lblTexto.ForeColor
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Me.Cursor = Cursors.WaitCursor
        CargarGrid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim OBJbU As New Negocios.EtiquetasBU
        Dim msg_adv As New Tools.AdvertenciaForm
        Dim msg_Exito As New Tools.ExitoForm
        Dim msg_Conf As New Tools.ConfirmarForm
        Dim TallaGeneral As New Entidades.TallasExtranjerasClienteDetalle
        Dim UsuarioID As Integer

        Try
            If listCeldasModificadas.Count > 0 Then
                msg_Conf.mensaje = "¿Desea actualizar los registros? (Una vez realizada esta acción no se podra revertir)"
                If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then

                    UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    GrdVConfiguracionGeneral.ClearColumnsFilter()

                    For Each celda As GridCell In listCeldasModificadas
                        If IsDBNull(GrdVConfiguracionGeneral.GetRowCellValue(celda.RowHandle, celda.Column)) = False Then
                            TallaGeneral = New Entidades.TallasExtranjerasClienteDetalle
                            TallaGeneral.TallaID = GrdVConfiguracionGeneral.GetRowCellValue(celda.RowHandle, "IdTallaSAY")
                            TallaGeneral.PaisAbreviatura = celda.Column.GetCaption
                            TallaGeneral.TallaMexicana = GrdVConfiguracionGeneral.GetRowCellValue(celda.RowHandle, "tallaMex")
                            TallaGeneral.TallaExtranjera = GrdVConfiguracionGeneral.GetRowCellValue(celda.RowHandle, celda.Column)
                            TallaGeneral.Activo = True
                            OBJbU.GuardarConfiguracionGeneral(TallaGeneral, UsuarioID)
                        End If
                    Next
                    msg_Exito.mensaje = "Los cambios se guardaron con éxito"
                    msg_Exito.ShowDialog()
                    listCeldasModificadas.Clear()
                    CargarGrid()
                    Editable = False
                    Activar_Inactivar_Grid(Editable)
                End If

            Else

                msg_adv.mensaje = "No hay cambios para guardar"
                msg_adv.ShowDialog()

            End If

        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        AdministradorTallasExtranjeras.ExportarAExcel(GrdVConfiguracionGeneral, "Configuración_General")
    End Sub
End Class