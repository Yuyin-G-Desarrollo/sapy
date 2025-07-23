Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.Utils
Imports Tools
Imports DevExpress.Data
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.Export

Public Class AdministradorTallasExtranjeras


    Private clienteID As Integer = 0
    Private NombreCliente As String
    'Private listaTallas As New List(Of Entidades.TallasExtranjerasClienteDetalle)()
    Private listCeldasSeleccionadas As New List(Of Integer)()
    Private listCeldasModificadas As New List(Of GridCell)()
    Private UsuarioID As Integer
    Dim seleccionados As Integer = 0
    Private Editable As Boolean = False

    Private Editar_Clientes_Todo As Boolean = False


    Private Sub AdministradorTallasExtranjeras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

        If validar_Perfil_Usuario() Then
            CargarComboClientes()
        End If

        UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        lblMostrar.Visible = False
        btnMostrar.Visible = False
    End Sub

    Private Sub CargarComboClientes()
        Dim objNegocios As New Negocios.EtiquetasBU
        Dim dtClientes As DataTable

        Try
            dtClientes = objNegocios.ConsultarClientesTallasExtranjeras
            cmbClientes.DisplayMember = "NombreGenerico"
            cmbClientes.ValueMember = "ClienteID"
            dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
            cmbClientes.DataSource = dtClientes
        Catch ex As Exception
            Dim msg_error As New ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try

    End Sub


    Private Function validar_Perfil_Usuario() As Boolean

        btnCopiarCliente.Visible = False
        btnConfiguracionGeneral.Visible = False
        btnExportar.Visible = False
        btnEditar.Visible = False
        btnGuardar.Visible = False
        btnMostrar.Visible = False
        lblExportar.Visible = False
        lblEditar.Visible = False
        lblCopiarCliente.Visible = False
        lblGuardar.Visible = False
        lblMostrar.Visible = False
        lblConfiguracionGeneral.Visible = False
        Dim UsuarioValido As Boolean = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_EDITAR_ALTA_TALLAS") Then
            btnEditar.Visible = True
            btnGuardar.Visible = True
            btnMostrar.Visible = True
            lblEditar.Visible = True
            lblGuardar.Visible = True
            lblMostrar.Visible = True
            UsuarioValido = True
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_CONSULTAR_CONFIG_GENERAL") Then
            btnConfiguracionGeneral.Visible = True
            lblConfiguracionGeneral.Visible = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_EDITAR_CLIENTES_TODO") Then
            Editar_Clientes_Todo = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_COPIAR_TALLAS_CLIENTE") Then
            btnCopiarCliente.Visible = True
            lblCopiarCliente.Visible = True
            btnMostrar.Visible = True
            lblMostrar.Visible = True
            UsuarioValido = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_EXPORTAR_EXCEL") Then
            btnExportar.Visible = True
            lblExportar.Visible = True
            btnMostrar.Visible = True
            lblMostrar.Visible = True
            UsuarioValido = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_ADMIN_TALLAS", "PROG_ADMIN_CONSULTA_TALLAS") Then
            btnMostrar.Visible = True
            lblMostrar.Visible = True
            UsuarioValido = True
        End If

        Return UsuarioValido

    End Function

    Private Sub Cargar_Grid()
        Me.Cursor = Cursors.WaitCursor
        listCeldasModificadas.Clear()
        listCeldasSeleccionadas.Clear()
        Editable = False
        seleccionados = 0
        lblRegistrosSeleccionados.Text = seleccionados
        cbxSeleccionarTodo.Checked = False

        Dim NegocioEtiquetas As New Negocios.EtiquetasBU
        Dim dt As DataTable
        GrdTallasExtranjerasFamilias.DataSource = Nothing
        If IsDBNull(cmbClientes.SelectedValue) = False Then

            clienteID = cmbClientes.SelectedValue
            NombreCliente = cmbClientes.Text
            GrdVTallasExtranjerasFamilias.Columns.Clear()

            Try
                dt = NegocioEtiquetas.ConsultarTallasExtranjeras(clienteID)
                DiseñoGrid_Bands(GrdVTallasExtranjerasFamilias, dt)
                GrdTallasExtranjerasFamilias.DataSource = dt
                DiseñoGrid_Color(GrdVTallasExtranjerasFamilias)
                Activar_Inactivar_grid(GrdVTallasExtranjerasFamilias, False)
                GrdTallasExtranjerasFamilias.Select()
            Catch ex As Exception
                Dim msg_error As New Tools.ErroresForm
                msg_error.mensaje = ex.Message
                msg_error.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DiseñoGrid_Color(Grid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        'Tools.DiseñoGrid.AlternarColorEnFilas(Grid)

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

        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1



        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Grid.Columns.ColumnByFieldName("IdSAY").Visible = False
        Grid.Columns.ColumnByFieldName("IdFamiliaSAY").Visible = False
        Grid.Columns.ColumnByFieldName("IdTallaSAY").Visible = False

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("TallaMX").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True

        Grid.Columns.ColumnByFieldName("Familia").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Corrida").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("TallaMX").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.BestFitColumns()
    End Sub

    Private Sub DiseñoGrid_Bands(Grid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView, ByVal dtResultado As DataTable)

        Dim band As New GridBand
        Dim listBands As New List(Of GridBand)
        GrdTallasExtranjerasFamilias.DataSource = Nothing
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
                    AddHandler Grid.CustomUnboundColumnData, AddressOf GrdVTallasExtranjerasFamilias_CustomUnboundColumnData
                    Grid.Columns.Item("#").VisibleIndex = 0
                    Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
                End If
            End If
            For Each col As DataColumn In dtResultado.Columns
                If col.Ordinal > 6 And gridBand.Caption <> "" Then
                    Grid.Columns.AddField(col.ColumnName)
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    Grid.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = True
                ElseIf col.Ordinal < 7 And gridBand.Caption = "" Then
                    Grid.Columns.AddField(col.ColumnName)
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    Grid.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    Grid.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = False
                End If
            Next
            Grid.Bands.Add(gridBand)
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GrdVTallasExtranjerasFamilias.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next



    End Sub

    Private Sub GrdVTallasExtranjerasFamilias_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = GrdVTallasExtranjerasFamilias.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cargar_Grid()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Activar_Inactivar_grid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView, Activacion As Boolean)
        For Each bands As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GrdVTallasExtranjerasFamilias.Bands
            If bands.Caption = "Corridas Extranjeras" Then
                For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bands.Columns
                    GrdVTallasExtranjerasFamilias.Columns.ColumnByFieldName(col.GetCaption).OptionsColumn.AllowEdit = Activacion
                Next
            End If
        Next
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim negocios As New Negocios.EtiquetasBU
        Dim dt As DataTable

        Dim msg_adv As New Tools.AdvertenciaForm

        If GrdVTallasExtranjerasFamilias.RowCount = 0 Then
            msg_adv.mensaje = "No hay registros para editar."
            msg_adv.ShowDialog()
            Return
        End If

        If clienteID = 0 Then
            msg_adv.mensaje = "No ha seleccionado un cliente valido."
            msg_adv.ShowDialog()
            Return
        End If

        Try

            dt = negocios.ConsultarPerimisoAgente(UsuarioID, clienteID)

            If dt.Rows.Count > 0 Or Editar_Clientes_Todo Then
                Dim band As List(Of GridBand) = GrdVTallasExtranjerasFamilias.Bands.ToList
                Activar_Inactivar_grid(GrdVTallasExtranjerasFamilias, True)
                GrdVTallasExtranjerasFamilias.FocusedColumn = band.Item(1).Columns.Item(0)
                GrdVTallasExtranjerasFamilias.ShowEditor()
                Editable = True
            Else

                msg_adv.mensaje = "No cuentas con permiso para habilitar el modo edición de este cliente."
                msg_adv.ShowDialog()

            End If

        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objNegocios As New Negocios.EtiquetasBU
        Dim msg_Adv As New Tools.AdvertenciaForm
        Dim msg_Conf As New Tools.ConfirmarForm
        Dim msg_Exito As New Tools.ExitoForm
        Dim DetalleTallas As Entidades.TallasExtranjerasClienteDetalle

        Try
            If listCeldasModificadas.Count > 0 Then
                msg_Conf.mensaje = "¿Desea actualizar los registros? (Una vez realizada esta acción no se podra revertir)"
                If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    GrdVTallasExtranjerasFamilias.ClearColumnsFilter()
                    For Each celda As GridCell In listCeldasModificadas
                        If IsDBNull(GrdVTallasExtranjerasFamilias.GetRowCellValue(celda.RowHandle, celda.Column)) = False Then
                            DetalleTallas = New Entidades.TallasExtranjerasClienteDetalle
                            DetalleTallas.Cliente = clienteID
                            DetalleTallas.TallaID = GrdVTallasExtranjerasFamilias.GetRowCellValue(celda.RowHandle, "IdTallaSAY")
                            DetalleTallas.FamiliaID = GrdVTallasExtranjerasFamilias.GetRowCellValue(celda.RowHandle, "IdFamiliaSAY")
                            DetalleTallas.PaisAbreviatura = celda.Column.GetCaption
                            DetalleTallas.TallaMexicana = GrdVTallasExtranjerasFamilias.GetRowCellValue(celda.RowHandle, "TallaMX")
                            DetalleTallas.TallaExtranjera = GrdVTallasExtranjerasFamilias.GetRowCellValue(celda.RowHandle, celda.Column)
                            DetalleTallas.Activo = True
                            objNegocios.GuardarTallaExtranjeraClienteDetalle(DetalleTallas, UsuarioID)
                        End If
                    Next
                    Me.Cursor = Cursors.Default
                    Cargar_Grid()
                    Activar_Inactivar_grid(GrdVTallasExtranjerasFamilias, False)
                    msg_Exito.mensaje = "Los cambios se guardaron con éxito."
                    msg_Exito.ShowDialog()
                End If
            Else
                msg_Adv.mensaje = "No hay cambios para guardar."
                msg_Adv.ShowDialog()
            End If
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try

    End Sub

    Private Sub btnCopiarCliente_Click(sender As Object, e As EventArgs) Handles btnCopiarCliente.Click
        Me.Cursor = Cursors.WaitCursor
        Dim CopiarCliente As New AdminitradorTallasExtranjeras_CopiarCliente
        Dim Lista As New ArrayList
        Dim DetalleTallas As Entidades.TallasExtranjerasClienteDetalle
        Dim a As Integer = listCeldasSeleccionadas.Count
        Dim msg_adv As New Tools.AdvertenciaForm

        If listCeldasSeleccionadas.Count > 0 Then
            If validarRegistrosExistentes() = 0 Then
                msg_adv.mensaje = "No existen datos para copiar."
                msg_adv.ShowDialog()
                Me.Cursor = Cursors.Default
                Return
            End If

            For Each row In listCeldasSeleccionadas

                For j As Integer = 0 To GrdVTallasExtranjerasFamilias.Columns.Count - 1

                    If j > 6 And GrdVTallasExtranjerasFamilias.Columns.Item(j).GetCaption <> "#" Then
                        DetalleTallas = New Entidades.TallasExtranjerasClienteDetalle
                        With DetalleTallas
                            .TallaID = GrdVTallasExtranjerasFamilias.GetRowCellValue(row, "IdTallaSAY")
                            .FamiliaID = GrdVTallasExtranjerasFamilias.GetRowCellValue(row, "IdFamiliaSAY")
                            .PaisAbreviatura = GrdVTallasExtranjerasFamilias.Columns.Item(j).GetCaption
                            .TallaMexicana = GrdVTallasExtranjerasFamilias.GetRowCellValue(row, "TallaMX")
                            If IsDBNull(GrdVTallasExtranjerasFamilias.GetRowCellValue(row, GrdVTallasExtranjerasFamilias.Columns.Item(j))) = True Then
                                .TallaExtranjera = ""
                            Else
                                .TallaExtranjera = GrdVTallasExtranjerasFamilias.GetRowCellValue(row, GrdVTallasExtranjerasFamilias.Columns.Item(j))
                            End If
                            .Activo = True
                        End With
                        Lista.Add(DetalleTallas)
                    End If
                Next
            Next
            CopiarCliente.Lista = Lista
            CopiarCliente.ClienteOrigen = NombreCliente
            CopiarCliente.ClienteOrigenID = clienteID
            CopiarCliente.ShowDialog()
            'CargarComboClientes()
            'listCeldasSeleccionadas.Clear()
        Else
            msg_adv.mensaje = "No hay registros para copiar."
            msg_adv.ShowDialog()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function validarRegistrosExistentes() As Integer
        Dim Registros As Integer = 0
        GrdVTallasExtranjerasFamilias.ClearColumnsFilter()
        For Each bands As DevExpress.XtraGrid.Views.BandedGrid.GridBand In GrdVTallasExtranjerasFamilias.Bands
            If bands.Caption = "Corridas Extranjeras" Then
                For Each col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bands.Columns
                    For Each row In listCeldasSeleccionadas
                        If IsDBNull(GrdVTallasExtranjerasFamilias.GetRowCellValue(row, col.GetCaption)) = False Or GrdVTallasExtranjerasFamilias.GetRowCellValue(row, col.GetCaption).ToString <> "" Then
                            Registros += 1
                        End If
                    Next
                Next
            End If
        Next
        Return Registros
    End Function

    Private Function ExisteCelda(ByVal sourceRowIndex As Integer, ByVal col As GridColumn) As Boolean
        Dim Resultado As GridCell = listCeldasModificadas.Where(Function(c) c.Column Is col AndAlso c.RowHandle = sourceRowIndex).FirstOrDefault()
        Return Resultado IsNot Nothing
    End Function


    Private Sub btnConfiguracionGeneral_Click(sender As Object, e As EventArgs) Handles btnConfiguracionGeneral.Click
        Dim ConfiguracionGeneralForm As New ConfiguracionGeneralForm
        ConfiguracionGeneralForm.licencia = 0
        ConfiguracionGeneralForm.Show()
    End Sub

    Private Sub GrdVTallasExtranjerasFamilias_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GrdVTallasExtranjerasFamilias.CellValueChanged
        If e.Column.ToString <> " " Then
            Dim cell As New GridCell(GrdVTallasExtranjerasFamilias.GetDataSourceRowIndex(e.RowHandle), e.Column)
            listCeldasModificadas.Add(cell)
        End If

        If e.Column.ToString = " " Then
            Agregar_Quitar_FilasSeleccionadas(e.Value, GrdVTallasExtranjerasFamilias.GetDataSourceRowIndex(e.RowHandle))
        End If
    End Sub

    Private Sub GrdVTallasExtranjerasFamilias_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles GrdVTallasExtranjerasFamilias.CellValueChanging
        Dim valor As Boolean
        Dim familia As String

        If e.Column.ToString = " " Then
            valor = e.Value
            familia = GrdVTallasExtranjerasFamilias.GetFocusedRowCellValue("Familia")

            For i As Integer = 0 To GrdVTallasExtranjerasFamilias.RowCount - 1

                If familia = GrdVTallasExtranjerasFamilias.GetRowCellValue(i, "Familia") Then
                    GrdVTallasExtranjerasFamilias.SetRowCellValue(i, " ", valor)
                    'Agregar_Quitar_FilasSeleccionadas(valor, i)
                End If
            Next
            ContarSeleccionados()
        End If
    End Sub

    Private Sub Agregar_Quitar_FilasSeleccionadas(valor As Boolean, index As Integer)
        If valor = True Then
            If Not listCeldasSeleccionadas.Contains(index) Then
                listCeldasSeleccionadas.Add(index)
            End If
            seleccionados += 1
        Else
            If listCeldasSeleccionadas.Contains(index) Then
                listCeldasSeleccionadas.RemoveAt(listCeldasSeleccionadas.IndexOf(index))
            End If
            seleccionados -= 1
            cbxSeleccionarTodo.Checked = False
        End If

    End Sub

    Private Sub GrdVTallasExtranjerasFamilias_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GrdVTallasExtranjerasFamilias.CustomDrawCell
        If Editable = True Then
            If IsDBNull(GrdVTallasExtranjerasFamilias.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False And IsNothing(GrdVTallasExtranjerasFamilias.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                If (ExisteCelda(GrdVTallasExtranjerasFamilias.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
                    e.Appearance.ForeColor = lblTexto.ForeColor
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
            End If
        End If
    End Sub

    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        Cargar_Grid()
    End Sub



    Private Sub cbxSeleccionarTodo_Click(sender As Object, e As EventArgs) Handles cbxSeleccionarTodo.Click
        Dim check As Boolean

        If CType(sender, CheckBox).Checked Then
            check = True
        Else
            check = False

        End If
        For i As Integer = 0 To GrdVTallasExtranjerasFamilias.RowCount - 1
            GrdVTallasExtranjerasFamilias.SetRowCellValue(i, " ", check)
            Agregar_Quitar_FilasSeleccionadas(check, i)
        Next
        ContarSeleccionados()
    End Sub


    Private Sub ContarSeleccionados()
        seleccionados = 0
        For i As Integer = 0 To GrdVTallasExtranjerasFamilias.RowCount - 1
            If GrdVTallasExtranjerasFamilias.GetRowCellValue(i, " ") = True Then
                seleccionados += 1
            End If
        Next
        lblRegistrosSeleccionados.Text = seleccionados
        GrdVTallasExtranjerasFamilias.CloseEditor()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarAExcel(GrdVTallasExtranjerasFamilias, "Tallas_Extranjeras")
    End Sub


    Public Shared Sub ExportarAExcel(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = True
                Grid.OptionsPrint.EnableAppearanceEvenRow = True
                Grid.OptionsPrint.EnableAppearanceOddRow = True
                Grid.OptionsPrint.PrintHorzLines = False
                Grid.OptionsPrint.PrintVertLines = False

                Grid.OptionsPrint.PrintPreview = True

                Dim FileName As String = SaveFileDialog.FileName

                Dim exportOptions = New XlsxExportOptionsEx()
                DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                Grid.ExportToXlsx(FileName, exportOptions)

                Dim msg_Exito As New ExitoForm
                msg_Exito.mensaje = "Los datos se exportaron correctamente."
                msg_Exito.ShowDialog()

                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            Dim msg_adv As New Tools.AdvertenciaForm
            msg_adv.mensaje = "No hay registros para exportar."
            msg_adv.ShowDialog()
        End If
    End Sub

    Private Sub btnConfiguracionLicencia_Click(sender As Object, e As EventArgs) Handles btnConfiguracionLicencia.Click
        Dim ConfiguracionGeneralForm As New ConfiguracionGeneralForm
        'Licencia Discovery
        ConfiguracionGeneralForm.licencia = 1
        ConfiguracionGeneralForm.Show()
    End Sub
End Class