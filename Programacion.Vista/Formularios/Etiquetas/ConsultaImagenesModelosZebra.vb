Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository

Public Class ConsultaImagenesModelosZebra

    Private fila_Seleccionada As Integer = 0

    Dim emptyEditor As RepositoryItemButtonEdit


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Cargar_Datos()
    End Sub



    Private Sub Cargar_Datos()
        Dim form As New AltaImagenesModelosZebraForm
        Dim entidadModelos As New Entidades.ModeloTallas
        'Dim objNeg As New Negocios.EtiquetasBU
        'Dim dt As DataTable
        'Dim idModelo As String = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdModelo").ToString
        'Dim idTalla As String = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdLinea")
        'Dim idLinea As String = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdTalla")

        'dt = objNeg.COnsultarModeloSeleccionado(idLinea, idTalla, idModelo)

        fila_Seleccionada = GrdVConsultaGrificoZebra.FocusedRowHandle

        If fila_Seleccionada >= 0 Then

            entidadModelos.IdModelo = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdModelo").ToString
            entidadModelos.IdLinea = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdLinea")
            entidadModelos.IdTalla = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdTalla")
            entidadModelos.SiluetaZebra = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("SiluetaZebra")
            entidadModelos.IdMarca = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("IdMarca")
            entidadModelos.Marca = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("Marca")
            entidadModelos.Talla = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("Talla")
            entidadModelos.Coleccion = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("Coleccion")

            form.EntidadModeloTallas = entidadModelos

            form.ShowDialog()

            Cargar_Grid()
        End If
    End Sub

    Private Sub ConsultaImagenesModelosZebra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Location = New Point(0, 0)
        rdbActivos.Checked = True
        rdbTodos.Checked = True

        Me.Cursor = Cursors.WaitCursor
        Cargar_Grid()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Cargar_Grid()

        Dim objNegocio As New Programacion.Negocios.EtiquetasBU
        Dim msgError As New Tools.ErroresForm
        Dim activo As Boolean = rdbActivos.Checked
        Dim inactivo As Boolean = rdbInactivos.Checked
        Dim dt As New DataTable
        Try
            If rdbTodos.Checked Then
                If activo Then
                    dt = objNegocio.ConsultarTodoModelosImagenes("S")
                Else
                    dt = objNegocio.ConsultarTodoModelosImagenes("N")
                End If
            ElseIf rdbConGraficos.Checked Then
                If activo Then
                    dt = objNegocio.ConsultarModelosImagenesConGraficos("S")
                Else
                    dt = objNegocio.ConsultarModelosImagenesConGraficos("N")
                End If
            ElseIf rdbSinGraficos.Checked Then
                If activo Then
                    dt = objNegocio.ConsultarModelosImagenesSinGraficos("S")
                Else
                    dt = objNegocio.ConsultarModelosImagenesSinGraficos("N")
                End If
            End If

            GrdConsultaGrificoZebra.DataSource = dt

            DiseñoColumnasGrids(GrdVConsultaGrificoZebra)

            GrdVConsultaGrificoZebra.FocusedRowHandle = fila_Seleccionada

        Catch ex As Exception
            msgError.mensaje = ex.Message
            msgError.ShowDialog()
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cargar_Grid()
    End Sub

    Private Sub DiseñoColumnasGrids(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)

        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf GrdVConsultaGrificoZebra_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If

        Grid.OptionsView.ColumnAutoWidth = True
        Grid.OptionsView.BestFitMaxRowCount = -1

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        Grid.OptionsView.EnableAppearanceEvenRow = True
        Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = True
        Grid.OptionsSelection.EnableAppearanceFocusedRow = True

        Grid.Appearance.EvenRow.BackColor = Color.White
        Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        Grid.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedCell.ForeColor = Color.White

        Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        Grid.Appearance.FocusedRow.ForeColor = Color.White

        Grid.Columns.ColumnByFieldName("IdLinea").Visible = False
        Grid.Columns.ColumnByFieldName("IdTalla").Visible = False
        Grid.Columns.ColumnByFieldName("SiluetaZebra").Visible = False
        Grid.Columns.ColumnByFieldName("IdMarca").Visible = False

        Grid.Columns.ColumnByFieldName("#").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ArchivoZebra").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Talla").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Marca").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("ArchivoZebra300").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("user_username").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("fechamodificacion").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Activo").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("FotoSAY").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Foto").OptionsColumn.AllowEdit = False


        Grid.Columns.ColumnByFieldName("FotoSAY").Visible = False


        Grid.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
        Grid.Columns.ColumnByFieldName("IdModelo").Caption = "Modelo SICY"
        Grid.Columns.ColumnByFieldName("ArchivoZebra").Caption = "Gráfico 203DPI"
        Grid.Columns.ColumnByFieldName("Talla").Caption = "Talla"
        Grid.Columns.ColumnByFieldName("Marca").Caption = "Marca"
        Grid.Columns.ColumnByFieldName("ArchivoZebra300").Caption = "Gráfico 300DPI"
        Grid.Columns.ColumnByFieldName("user_username").Caption = "Modificó"
        Grid.Columns.ColumnByFieldName("fechamodificacion").Caption = "F Modificación"

        Grid.Columns.ColumnByFieldName("fechamodificacion").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        Grid.Columns.ColumnByFieldName("Marca").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("IdModelo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Coleccion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Grid.Columns.ColumnByFieldName("Talla").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        Grid.BestFitColumns()


    End Sub

    Private Sub GrdVConsultaGrificoZebra_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GrdVConsultaGrificoZebra.CustomRowCellEdit
        If e.Column.FieldName = "Foto" Then
            If e.RowHandle >= 0 Then
                If GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "FotoSAY").ToString = "" Then
                    Exit Sub
                End If
                emptyEditor = New RepositoryItemButtonEdit
                'emptyEditor.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton())
                emptyEditor.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
                emptyEditor.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
                emptyEditor.Buttons(0).Image = Global.Programacion.Vista.My.Resources.Resources.Camara
                e.RepositoryItem = emptyEditor
            End If
        End If
    End Sub

    Private Sub GrdVConsultaGrificoZebra_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles GrdVConsultaGrificoZebra.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = GrdVConsultaGrificoZebra.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub GrdVConsultaGrificoZebra_RowClick(sender As Object, e As RowClickEventArgs) Handles GrdVConsultaGrificoZebra.RowClick
        If e.Clicks = 2 Then
            Cargar_Datos()
        End If
    End Sub
    'Private Sub GrdVConsultaGrificoZebra_DoubleClick(sender As Object, e As EventArgs) Handles GrdVConsultaGrificoZebra.DoubleClick
    '    Dim MostrarFoto As New FotoModeloForm
    '    MostrarFoto.NombreFoto = GrdVConsultaGrificoZebra.GetFocusedRowCellValue("FotoSAY")
    '    MostrarFoto.ShowDialog()


    'End Sub

    ' private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e) {
    '    MessageBox.Show("Click!");
    '}


    'Private Sub emptyEditor_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    MsgBox("Click")
    'End Sub




    Private Sub GrdVConsultaGrificoZebra_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GrdVConsultaGrificoZebra.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "Foto" Then
                Dim MostrarFoto As New FotoModeloForm
                MostrarFoto.NombreFoto = GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "FotoSAY")
                MostrarFoto.Marca = GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "Marca")
                MostrarFoto.Coleccion = GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "Coleccion")
                MostrarFoto.ModeloSicy = GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "IdModelo")
                MostrarFoto.ModleoSay = GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "ModeloSay")
                MostrarFoto.Talla = GrdVConsultaGrificoZebra.GetRowCellValue(e.RowHandle, "Talla")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnLotesGrfImagen_Click(sender As Object, e As EventArgs) Handles btnLotesGrfImagen.Click
        Dim form As New ConsultaLotesSinGrfImagenForm
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class