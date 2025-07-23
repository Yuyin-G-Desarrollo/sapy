Imports System.Net
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_Reportes_MaterialesPorArticulo_Form

    Dim vFiltroNaved As String = Nothing
    Dim vFiltroNavep As String = Nothing
    Dim vFiltroProveedor As String = Nothing
    Dim vFiltroTipoMaterial As String = Nothing
    Dim vFiltroMarca As String = Nothing
    Dim vFiltroColeccion As String = Nothing
    Dim vFiltroModelo As String = Nothing
    Dim vFiltroPielColor As String = Nothing
    Dim vFiltroCorrida As String = Nothing
    Dim vFiltroEstatus As String = Nothing
    Dim emptyEditor As RepositoryItemPictureEdit


    Private Sub Programacion_Reportes_MaterialesPorArticulo_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub grdTipoMaterial_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTipoMaterial.InitializeLayout
        grid_diseño(grdTipoMaterial)
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "N0"
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

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 341
    End Sub

    Private Sub btnLimpiarNaved_Click(sender As Object, e As EventArgs) Handles btnLimpiarNaved.Click
        grdNaved.DataSource = Nothing
    End Sub

    Private Sub btnAgregarNaved_Click(sender As Object, e As EventArgs) Handles btnAgregarNaved.Click
        LlenarGridFiltro(grdNaved, "Naves Desarrollo", 11)
    End Sub

    Private Sub btnLimpiarNavep_Click(sender As Object, e As EventArgs) Handles btnLimpiarNavep.Click
        grdNavep.DataSource = Nothing
    End Sub

    Private Sub btnAgregarNavep_Click(sender As Object, e As EventArgs) Handles btnAgregarNavep.Click
        LlenarGridFiltro(grdNavep, "Naves Producción", 10)
    End Sub
    Private Sub btnAgregarEstatus_Click(sender As Object, e As EventArgs) Handles btnAgregarEstatus.Click
        LlenarGridFiltro(grdEstatus, "Estatus", 23)
    End Sub
    Private Sub btnLimpiarEstatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarEstatus.Click
        grdEstatus.DataSource = Nothing
    End Sub
    Private Sub btnLimpiarProveedor_Click(sender As Object, e As EventArgs) Handles btnLimpiarProveedor.Click
        grdProveedor.DataSource = Nothing
    End Sub

    Private Sub btnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles btnAgregarProveedor.Click
        LlenarGridFiltro(grdProveedor, "Proveedor", 9)
    End Sub

    Private Sub btnLimpiarMaterial_Click(sender As Object, e As EventArgs) Handles btnLimpiarMaterial.Click
        grdTipoMaterial.DataSource = Nothing
    End Sub

    Private Sub btnAgregarMaterial_Click(sender As Object, e As EventArgs) Handles btnAgregarMaterial.Click
        LlenarGridFiltro(grdTipoMaterial, "Material", 8)
    End Sub

    Private Sub btnLimpiarMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarMarca.Click
        grdMarca.DataSource = Nothing
    End Sub

    Private Sub btnAgregarMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarMarca.Click
        LlenarGridFiltro(grdMarca, "Marca", 1)
    End Sub

    Private Sub btnLimpiarColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdColeccion.DataSource = Nothing
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        LlenarGridFiltro(grdColeccion, "Colección", 2)
    End Sub

    Private Sub btnLimpiarModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarModelo.Click
        grdModelo.DataSource = Nothing
    End Sub

    Private Sub btnAgregarModelo_Click(sender As Object, e As EventArgs) Handles btnAgregarModelo.Click
        LlenarGridFiltro(grdModelo, "Modelo", 3)
    End Sub

    Private Sub btnLimpiarPielColor_Click(sender As Object, e As EventArgs) Handles btnLimpiarPielColor.Click
        grdPielColor.DataSource = Nothing
    End Sub

    Private Sub btnAgregarPielColor_Click(sender As Object, e As EventArgs) Handles btnAgregarPielColor.Click
        LlenarGridFiltro(grdPielColor, "Piel / Color", 7)
    End Sub

    Private Sub btnLimpiarCorrida_Click(sender As Object, e As EventArgs) Handles btnLimpiarCorrida.Click
        grdCorrida.DataSource = Nothing
    End Sub

    Private Sub btnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        LlenarGridFiltro(grdCorrida, "Corrida", 6)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        Dim obj As New MaterialesPorArticuloBU
        Dim dtResultadoConsulta As New DataTable
        Dim Cont As Integer = 0
        Dim ruta As String = String.Empty
        obtenerFiltros()
        Dim objFTP As New Global.Tools.TransferenciaFTP
        Dim rutaFtp As String = objFTP.obtenerURL
        Dim FtpUser As String = objFTP.obtenerUsuario
        Dim ftppasswd As String = objFTP.obtenerContrasena
        Dim image As Image
        Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
        Dim Carpeta As String = "Programacion/Modelos/"
        Dim StreamFoto As System.IO.Stream

        dtResultadoConsulta = obj.ObtieneMaterialesPorArticulo(vFiltroNaved, vFiltroNavep, vFiltroProveedor, vFiltroTipoMaterial, vFiltroMarca,
                                                               vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroEstatus)

        lblRegistrosNum.Text = dtResultadoConsulta.Rows.Count()

        If dtResultadoConsulta.Rows.Count > 0 Then


            dtResultadoConsulta.Columns.Add("Foto", GetType(Image))

            For Each row As DataRow In dtResultadoConsulta.Rows
                ruta = IIf(IsDBNull(row.Item("Imagen")), "", row.Item("Imagen").ToString.Trim())
                If ruta.Length > 0 Then
                    Try
                        image = Nothing
                        StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                        image = System.Drawing.Image.FromStream(StreamFoto)
                        row.Item("Foto") = image
                    Catch ex As Exception
                        Try
                            image = Nothing
                            StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                            image = System.Drawing.Image.FromStream(StreamFoto)
                            row.Item("Foto") = image
                        Catch exe As Exception

                        End Try
                    End Try
                Else
                    row.Item("Foto") = Nothing

                End If
                Cont += 1
            Next

            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            grdReporte.DataSource = dtResultadoConsulta
            lblRegistrosNum.Text = dtResultadoConsulta.Rows.Count()
            DiseñoGrid()
            btnArriba_Click(Nothing, Nothing)
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "No hay datos para mostrar"
            mensajeAdvertencia.ShowDialog()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        lblRegistrosNum.Text = 0
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If vwReporte.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            ' Dim objBU As New Negocios.EstadisticoPedidosBU
            Dim exportOptions = New XlsxExportOptionsEx()

            exportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG

            Try
                nombreReporte = "\Materiales_Por_Articulo"
                nombreReporteParaExportacion = "MATERIALES POR ARTICULO"
                exportOptions.SheetName = "MaterialesPorArticulo"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If

                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
            End Try
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltradoForm
        listado.tipo_busqueda = pTipoBusqueda

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In pGrid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        pGrid.DataSource = listado.listParametros

        With pGrid
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
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

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNaved.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNaved.DeleteSelectedRows(False)
    End Sub

    Private Sub grdProduccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNavep.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNavep.DeleteSelectedRows(False)
    End Sub

    Private Sub grdProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProveedor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdProveedor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdTipoMaterial_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTipoMaterial.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTipoMaterial.DeleteSelectedRows(False)
    End Sub
    Private Sub grdEstatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEstatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEstatus.DeleteSelectedRows(False)
    End Sub
    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPielColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPielColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPielColor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNaved.InitializeLayout
        grid_diseño(grdNaved)
    End Sub

    Private Sub grdProduccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNavep.InitializeLayout
        grid_diseño(grdNavep)
    End Sub

    Private Sub grdProveedor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProveedor.InitializeLayout
        grid_diseño(grdProveedor)
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
    End Sub

    Private Sub grdPielColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout
        grid_diseño(grdPielColor)
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim vDatosFiltrados As String = Nothing
        For Each Row As UltraGridRow In grid.Rows
            If vDatosFiltrados <> Nothing Then
                vDatosFiltrados += ","
            End If
            vDatosFiltrados += Row.Cells("Parametro").Value.ToString()
        Next
        Return vDatosFiltrados
    End Function

    Private Sub obtenerFiltros()

        vFiltroNaved = Filtros(grdNaved)
        vFiltroNavep = Filtros(grdNavep)
        vFiltroProveedor = Filtros(grdProveedor)
        vFiltroTipoMaterial = Filtros(grdTipoMaterial)
        vFiltroMarca = Filtros(grdMarca)
        vFiltroColeccion = Filtros(grdColeccion)
        vFiltroModelo = Filtros(grdModelo)
        vFiltroPielColor = Filtros(grdPielColor)
        vFiltroCorrida = Filtros(grdCorrida)
        vFiltroEstatus = Filtros(grdEstatus)


    End Sub

    Private Sub DiseñoGrid()

        If chbFoto.Checked = False Then
            vwReporte.RowHeight = -1
        Else
            vwReporte.RowHeight = 60
        End If

        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns

            vColumna.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            If vColumna.FieldName.Contains("Nave") = True Then
                vColumna.Width = 100
                vColumna.Caption = "Nave Desarrollo"


            ElseIf vColumna.FieldName.Contains("Marca") = True Then
                vColumna.Width = 100

            ElseIf vColumna.FieldName.Contains("Coleccion") = True Then
                vColumna.Width = 200
                vColumna.Caption = "Colección"

            ElseIf vColumna.FieldName.Contains("Modelo") = True Then
                vColumna.Width = 80

            ElseIf vColumna.FieldName.Contains("PielColor") = True Then
                vColumna.Width = 200
                vColumna.Caption = "Piel / Color"

            ElseIf vColumna.FieldName.Contains("Corrida") = True Then
                vColumna.Width = 80

            ElseIf vColumna.FieldName.Contains("Proveerdor") = True Then
                vColumna.Width = 350

            ElseIf vColumna.FieldName.Contains("Material") = True Then
                vColumna.Width = 350

            ElseIf vColumna.FieldName.Contains("UnidadMedida") = True Then
                vColumna.Width = 80
                vColumna.Caption = "Unidad de Medida"

            ElseIf vColumna.FieldName.Contains("Foto") = True Then
                vColumna.Width = 140
                vColumna.Caption = "Foto"


                emptyEditor = New RepositoryItemPictureEdit()
                emptyEditor.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
                emptyEditor.NullText = ""
                emptyEditor.CustomHeight = 200
                emptyEditor.AutoHeight = 200
                vColumna.ColumnEdit = emptyEditor

                If chbFoto.Checked = True Then
                    vColumna.Visible = True
                Else
                    vColumna.Visible = False
                End If

            ElseIf vColumna.FieldName.Contains("Imagen") = True Then
                vColumna.Visible = False
            Else
                vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vColumna.DisplayFormat.FormatString = "##,##0.0"

            End If

            vColumna.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            vColumna.OptionsFilter.ImmediateUpdateAutoFilter = False

        Next
    End Sub

    Private Sub vwReporte_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle

        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwReporte.CustomDrawCell

        If e.Column.FieldName = "Foto" Then
            If e.RowHandle >= 0 Then
                emptyEditor = New RepositoryItemPictureEdit()
                emptyEditor.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
                emptyEditor.NullText = ""
                emptyEditor.CustomHeight = 50
                e.Column.ColumnEdit = emptyEditor

            End If
        End If
    End Sub

    Private Sub chbFoto_CheckedChanged(sender As Object, e As EventArgs) Handles chbFoto.CheckedChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub
End Class