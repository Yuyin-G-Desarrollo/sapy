Imports System.Windows.Forms
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Proveedores.BU
Imports Tools

Public Class Mercadotecnia_Inventario_MaterialesForm
    Dim listaInicial As New List(Of String)
    Dim advertencia As New AdvertenciaForm

    Private Sub Mercadotecnia_Inventario_MaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        ' grdInventarioPOP.DataSource = listaInicial
        ObtieneListadoMateriales()
    End Sub

    Private Sub btnAltaMaterial_Click(sender As Object, e As EventArgs) Handles btnAltaMaterial.Click
        Dim AltaInventarioMaterial As New Mercadotecnia_AltaEdicion_MaterialesForm
        AltaInventarioMaterial.AltaMaterialPOP = True
        AltaInventarioMaterial.ShowDialog()
        ObtieneListadoMateriales()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As New Mercadotecnia_AltaEdicion_MaterialesForm
        Dim NumeroFilas = MVInventarioPOP.DataRowCount
        Dim lstRenglonesEditados As New List(Of Entidades.EditarMaterialesMercadotecniaPOP)
        Dim lstMaterialId As New List(Of String)

        Cursor = Cursors.WaitCursor

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), " ")) = True Or CBool(MVInventarioPOP.IsRowSelected(MVInventarioPOP.GetVisibleRowHandle(index))) = True Then
                If lstMaterialId.Contains(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MaterialID").ToString()) = False Then
                    lstMaterialId.Add(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MaterialID").ToString())
                End If
            End If
        Next

        Try
            If lstMaterialId.Count > 2 Then
                advertencia.mensaje = "Seleccione solo un material para editar."
                advertencia.ShowDialog()
            End If

            For index As Integer = 0 To NumeroFilas Step 1
                Dim vEditarMaterial As New Entidades.EditarMaterialesMercadotecniaPOP
                If CBool(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), " ")) = True Then
                    vEditarMaterial.PIdMaterial = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MaterialID")
                    vEditarMaterial.PNombreMaterial = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Material")
                    vEditarMaterial.PDescripcion = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Descripcion")
                    vEditarMaterial.PUMC = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "UMC")
                    vEditarMaterial.PMarca = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Marca")
                    vEditarMaterial.PMotivoFabricacion = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MotivoFabricacion")
                    vEditarMaterial.PEstatusM = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Estatus")
                    vEditarMaterial.PPrecio = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Precio")
                    vEditarMaterial.PExistencia = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Existencia")

                    If MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "RutaFoto") = "" Then

                    Else
                        vEditarMaterial.PRutaFoto = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "RutaFoto")
                        vEditarMaterial.PnombreImagen = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "mpop_nombreImagen")
                    End If


                    form.vLstMaterialesPOP.Add(vEditarMaterial)
                End If
            Next

            form.ShowDialog()
            btnMostrar_Click(Nothing, Nothing)
            Cursor = Cursors.Default

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If MVInventarioPOP.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = "Inventario_MaterialesPOP"
            Dim objBU As New MercadotecniaBU
            Dim exportOptions = New XlsxExportOptionsEx()

            Try
                Cursor = Cursors.WaitCursor

                If MVInventarioPOP.DataRowCount > 0 Then

                    With fbdUbicacionArchivo
                        .Reset()
                        .Description = " Seleccione una carpeta "
                        .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                        .ShowNewFolderButton = True

                        Dim ret As DialogResult = .ShowDialog
                        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                        If ret = Windows.Forms.DialogResult.OK Then
                            If MVInventarioPOP.GroupCount > 0 Then
                                MVInventarioPOP.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                            Else
                                Dim mv = New XlsxExportOptionsEx()
                                MVInventarioPOP.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            End If

                            Dim FormaError As New ExitoForm
                            FormaError.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                            FormaError.ShowDialog()

                            .Dispose()
                            Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        End If
                    End With
                Else
                    Dim FormaError As New AdvertenciaForm
                    FormaError.mensaje = "No hay datos para exportar"
                    FormaError.ShowDialog()
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Dim FormaError As New AdvertenciaForm
                FormaError.mensaje = "No se encontro el archivo"
                FormaError.ShowDialog()
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If
    End Sub

    Public Sub ObtieneListadoMateriales()
        Dim objBU As New MercadotecniaBU
        Dim dtObtieneMaterialesPOP As New DataTable
        Dim Estatus As Integer

        If rdoSi.Checked Then
            Estatus = 1
        Else
            Estatus = 0
        End If

        Cursor = Cursors.WaitCursor
        dtObtieneMaterialesPOP = objBU.ObtieneListadoMaterialesPOP(Estatus)

        If dtObtieneMaterialesPOP.Rows.Count > 0 Then
            grdInventarioPOP.DataSource = dtObtieneMaterialesPOP
            DiseñoGrid()
            lblNumFiltrados.Text = CDbl(MVInventarioPOP.RowCount.ToString()).ToString("n0")
            lblFechaUltimaActualización.Text = Date.Now
        Else
            advertencia.mensaje = "No hay datos para mostrar."
            advertencia.ShowDialog()
            grdInventarioPOP.DataSource = Nothing
        End If

        Cursor = Cursors.Default

    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        ObtieneListadoMateriales()
    End Sub

    Public Sub DiseñoGrid()
        MVInventarioPOP.OptionsView.ColumnAutoWidth = False

        If IsNothing(MVInventarioPOP.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            MVInventarioPOP.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler MVInventarioPOP.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            MVInventarioPOP.Columns.Item("#").VisibleIndex = 0
        End If

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVInventarioPOP.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        MVInventarioPOP.Columns.ColumnByFieldName(" ").Fixed = Columns.FixedStyle.Left
        MVInventarioPOP.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True

        MVInventarioPOP.Columns.ColumnByFieldName("Descripcion").Caption = "Descripción"
        MVInventarioPOP.Columns.ColumnByFieldName("FechaCreacion").Caption = "Fecha Creación"
        MVInventarioPOP.Columns.ColumnByFieldName("UsuarioCreo").Caption = "Usuario Creó"
        MVInventarioPOP.Columns.ColumnByFieldName("MotivoFabricacion").Caption = "Motivo Fabricación"

        MVInventarioPOP.Columns.ColumnByFieldName("MaterialID").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        MVInventarioPOP.Columns.ColumnByFieldName("UMC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals
        MVInventarioPOP.Columns.ColumnByFieldName("Existencia").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Equals


        MVInventarioPOP.Columns.ColumnByFieldName("Material").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        MVInventarioPOP.Columns.ColumnByFieldName("Descripcion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        MVInventarioPOP.Columns.ColumnByFieldName("Marca").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        MVInventarioPOP.Columns.ColumnByFieldName("MotivoFabricacion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        MVInventarioPOP.Columns.ColumnByFieldName("RutaFoto").Visible = False
        MVInventarioPOP.Columns.ColumnByFieldName("mpop_nombreImagen").Visible = False


        MVInventarioPOP.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways



        If IsNothing(MVInventarioPOP.Columns("Existencia").Summary.FirstOrDefault(Function(x) x.FieldName = "Existencia")) = True Then
            MVInventarioPOP.Columns("Existencia").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Existencia", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Existencia"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVInventarioPOP.GroupSummary.Add(item)
        End If


        MVInventarioPOP.BestFitColumns()

    End Sub


    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = MVInventarioPOP.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1

        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        grdInventarioPOP.DataSource = Nothing
        lblFechaUltimaActualización.Text = "-"
        MVInventarioPOP.Columns.Clear()
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
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
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub


    Private Sub rdoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNo.CheckedChanged
        ObtieneListadoMateriales()
    End Sub

    Private Sub grdInventarioPOP_MouseClick(sender As Object, e As MouseEventArgs) Handles grdInventarioPOP.MouseClick
        Dim form As New Mercadotecnia_AltaEdicion_MaterialesForm
        Dim NumeroFilas = MVInventarioPOP.DataRowCount
        Dim lstRenglonesEditados As New List(Of Entidades.EditarMaterialesMercadotecniaPOP)
        Dim lstMaterialId As New List(Of String)

        Cursor = Cursors.WaitCursor

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), " ")) = True Or CBool(MVInventarioPOP.IsRowSelected(MVInventarioPOP.GetVisibleRowHandle(index))) = True Then
                If lstMaterialId.Contains(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MaterialID").ToString()) = False Then
                    lstMaterialId.Add(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MaterialID").ToString())
                End If
            End If
        Next

        Try
            If lstMaterialId.Count > 2 Then
                advertencia.mensaje = "Seleccione solo un material para editar."
                advertencia.ShowDialog()
            End If

            For index As Integer = 0 To NumeroFilas Step 1
                Dim vEditarMaterial As New Entidades.EditarMaterialesMercadotecniaPOP
                If CBool(MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), " ")) = True Or CBool(MVInventarioPOP.IsRowSelected(MVInventarioPOP.GetVisibleRowHandle(index))) = True Then
                    vEditarMaterial.PIdMaterial = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MaterialID")
                    vEditarMaterial.PNombreMaterial = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Material")
                    vEditarMaterial.PDescripcion = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Descripcion")
                    vEditarMaterial.PUMC = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "UMC")
                    vEditarMaterial.PMarca = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Marca")
                    vEditarMaterial.PMotivoFabricacion = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "MotivoFabricacion")
                    vEditarMaterial.PEstatusM = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Estatus")
                    vEditarMaterial.PPrecio = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Precio")
                    vEditarMaterial.PExistencia = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "Existencia")

                    If MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "RutaFoto") = "" Then

                    Else
                        vEditarMaterial.PRutaFoto = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "RutaFoto")
                        vEditarMaterial.PnombreImagen = MVInventarioPOP.GetRowCellValue(MVInventarioPOP.GetVisibleRowHandle(index), "mpop_nombreImagen")
                    End If

                    form.VistaDetalles = True
                    form.vLstMaterialesPOP.Add(vEditarMaterial)
                End If
            Next

            form.ShowDialog()
            btnMostrar_Click(Nothing, Nothing)
            Cursor = Cursors.Default

        Catch ex As Exception

        End Try
    End Sub
End Class