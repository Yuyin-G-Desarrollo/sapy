Imports Entidades
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools

Public Class Produccion_Suelas_CargarDatosSuelasEnArticulos_Form
    Dim listaInicial As New List(Of String)
    Dim advertencia As New AdvertenciaForm

    Private Sub Produccion_Suelas_CargarDatosSuelasEnArticulos_Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        grdListaProductos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListaProductos.DisplayLayout.Override.RowSelectorWidth = 20
        grdListaProductos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        If grdListaProductos.Rows.Count > 0 Then
            grdListaProductos.Rows(0).Selected = True
        End If
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listaParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listaParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub btnLimpiar2_Click(sender As Object, e As EventArgs) Handles btnLimpiar2.Click
        grdMarca.DataSource = Nothing
        grdColeccion.DataSource = Nothing
        grdListaProductos.DataSource = Nothing
        lblTotalRegistros.Text = 0
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        chboxSeleccionarTodo.Checked = False
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return Resultado
    End Function

    Public Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim FMarca As String = String.Empty
        Dim FColeccion As String = String.Empty
        Dim dtArticulos As New DataTable
        Dim objBU As New Produccion.Negocios.ArticulosSuelaBU
        Dim UsuarioId As Integer

        Try
            Cursor = Cursors.WaitCursor
            grdListaProductos.DataSource = Nothing

            FMarca = ObtenerFiltrosGrid(grdMarca)
            FColeccion = ObtenerFiltrosGrid(grdColeccion)
            UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            dtArticulos = objBU.VerArticulos(FMarca, FColeccion, UsuarioId)
            If dtArticulos.Rows.Count = 0 Then
                advertencia.mensaje = "No hay información para mostrar."
                advertencia.ShowDialog()
            Else
                grdListaProductos.DataSource = dtArticulos
                disenoGrid()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub disenoGrid()
        Dim registros As Integer = grdListaProductos.Rows.Count.ToString

        lblTotalRegistros.Text = grdListaProductos.Rows.Count.ToString
        lblTotalRegistros.Text = Format(registros, "##,##0")

        With grdListaProductos.DisplayLayout.Bands(0)
            .Columns("ProductoId").Hidden = True
            .Columns("pstilo").Hidden = True
            .Columns("idPiel").Hidden = True
            .Columns("idColor").Hidden = True
            .Columns("idTalla").Hidden = True
            .Columns("Sicy").Hidden = True
            .Columns("IdMarcaCasa").Hidden = True
            .Columns("Fracción_Arancelaria").Hidden = True
            .Columns("psEstatus").Hidden = True
            .Columns("nomSts").Hidden = True
            .Columns("Sicy").Hidden = True
            .Columns("Nuevo").Hidden = True
            .Columns("idClaveSAT").Hidden = True
            .Columns("ClaveSAT").Hidden = True
            .Columns("SuelaProgramacionID").Hidden = True
            .Columns("sicyPCOL").Hidden = True
            .Columns("FotoProducto").Hidden = True
            .Columns("FamiliaId").Hidden = True
            .Columns("AcabadoId").Hidden = True
            .Columns("PrimerColorId").Hidden = True
            .Columns("SegundoColorId").Hidden = True

            .Columns("pielColor").Header.Caption = "Piel Color"
            .Columns("talla").Header.Caption = "Corrida"
            .Columns("Marca").Header.Caption = "Marca"
            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("PrimerColor").Header.Caption = "Primer Color"
            .Columns("SegundoColor").Header.Caption = "Segundo Color"
            .Columns("SuelaProgramacion").Header.Caption = "Suela"


            .Columns("Modelo SAY").CellActivation = Activation.NoEdit
            .Columns("Modelo SICY").CellActivation = Activation.NoEdit
            .Columns("talla").CellActivation = Activation.NoEdit
            .Columns("SuelaProgramacion").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Familia").CellActivation = Activation.NoEdit
            .Columns("Acabado").CellActivation = Activation.NoEdit
            .Columns("PrimerColor").CellActivation = Activation.NoEdit
            .Columns("SegundoColor").CellActivation = Activation.NoEdit

            .Override.RowSelectorWidth = 35
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdListaProductos.DisplayLayout.Bands(0).Columns(" ").Width = 20
        grdListaProductos.DisplayLayout.Bands(0).Columns("Marca").Width = 93
        grdListaProductos.DisplayLayout.Bands(0).Columns("Coleccion").Width = 150
        grdListaProductos.DisplayLayout.Bands(0).Columns(" ").AllowRowFiltering = False
        grdListaProductos.DisplayLayout.Bands(0).Columns("Modelo SAY").Width = 70
        grdListaProductos.DisplayLayout.Bands(0).Columns("Modelo SICY").Width = 75
        grdListaProductos.DisplayLayout.Bands(0).Columns("Familia").Width = 130
        grdListaProductos.DisplayLayout.Bands(0).Columns("Acabado").Width = 130
        grdListaProductos.DisplayLayout.Bands(0).Columns("PrimerColor").Width = 130
        grdListaProductos.DisplayLayout.Bands(0).Columns("SegundoColor").Width = 130



    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim form As New EditarArticulo_SuelaForm

        Cursor = Cursors.WaitCursor
        If grdListaProductos.Rows.Count > 0 Then
            If IsNothing(grdListaProductos.ActiveRow) = True Then
                advertencia.mensaje = "Seleccione un artículo."
                advertencia.StartPosition = FormStartPosition.CenterScreen
                advertencia.ShowDialog()
                Return
            End If
            For value = 0 To grdListaProductos.Rows.Count - 1
                If grdListaProductos.Rows(value).Cells(" ").Value = True Then
                    Dim vArticulo As ArticuloCargaSuela = New ArticuloCargaSuela()
                    vArticulo.PIdArticulo = grdListaProductos.Rows(value).Cells("pstilo").Value
                    vArticulo.PIdSuelaProgramacion = grdListaProductos.Rows(value).Cells("SuelaProgramacionID").Value
                    vArticulo.PIdColorSuela = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("PrimerColorId").Value), 0, grdListaProductos.Rows(value).Cells("PrimerColorId").Value)
                    vArticulo.PIdColorSuela2 = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("SegundoColorId").Value), 0, grdListaProductos.Rows(value).Cells("SegundoColorId").Value)
                    vArticulo.PIdAcabadoSuela = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("AcabadoId").Value), 0, grdListaProductos.Rows(value).Cells("AcabadoId").Value)
                    vArticulo.PIdFamiliaSuela = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("FamiliaId").Value), 0, grdListaProductos.Rows(value).Cells("FamiliaId").Value)
                    vArticulo.PIdCorrida = grdListaProductos.Rows(value).Cells("idTalla").Value
                    vArticulo.PCadenaImagen = grdListaProductos.Rows(value).Cells("FotoProducto").Value
                    vArticulo.PArticuloUno = grdListaProductos.Rows(value).Cells("Marca").Value.ToString + " " +
                                             grdListaProductos.Rows(value).Cells("Coleccion").Value.ToString + " " +
                                             grdListaProductos.Rows(value).Cells("Modelo SAY").Value.ToString + " (" +
                                             grdListaProductos.Rows(value).Cells("Modelo SICY").Value.ToString + ")"
                    vArticulo.PArticuloDos = grdListaProductos.Rows(value).Cells("pielColor").Value.ToString + " " +
                                             grdListaProductos.Rows(value).Cells("talla").Value.ToString
                    vArticulo.PCadenaListaArticulo1 = grdListaProductos.Rows(value).Cells("Marca").Value.ToString + " " +
                                                      grdListaProductos.Rows(value).Cells("Coleccion").Value.ToString + " " +
                                                      grdListaProductos.Rows(value).Cells("Modelo SAY").Value.ToString + " (" +
                                                      grdListaProductos.Rows(value).Cells("Modelo SICY").Value.ToString + ")" + " " +
                                                      grdListaProductos.Rows(value).Cells("pielColor").Value.ToString + " " +
                                                      grdListaProductos.Rows(value).Cells("talla").Value.ToString + "  "

                    vArticulo.PCadenaListaArticulo2 = grdListaProductos.Rows(value).Cells("SuelaProgramacion").Value
                    vArticulo.PCadenaListaArticulo5 = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("PrimerColor").Value), "", grdListaProductos.Rows(value).Cells("PrimerColor").Value) + " " +
                                                      IIf(IsDBNull(grdListaProductos.Rows(value).Cells("SegundoColor").Value), "", grdListaProductos.Rows(value).Cells("SegundoColor").Value)
                    vArticulo.PCadenaListaArticulo3 = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("Familia").Value), "", grdListaProductos.Rows(value).Cells("Familia").Value)
                    vArticulo.PCadenaListaArticulo4 = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("Acabado").Value), "", grdListaProductos.Rows(value).Cells("Acabado").Value)
                    vArticulo.PConsumoSuela = IIf(IsDBNull(grdListaProductos.Rows(value).Cells("Consumo").Value), "", grdListaProductos.Rows(value).Cells("Consumo").Value)

                    form.vLstIdArticulo.Add(vArticulo)

                End If
            Next
            form.listaArticulo = Me
            form.Show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Try
            If grdListaProductos.Rows.Count > 0 Then
                Cursor = Cursors.WaitCursor
                If chboxSeleccionarTodo.Checked = True Then
                    For Each row As UltraGridRow In grdListaProductos.Rows.GetFilteredInNonGroupByRows
                        row.Cells(" ").Value = True
                    Next
                Else
                    For Each row As UltraGridRow In grdListaProductos.Rows.GetFilteredInNonGroupByRows
                        row.Cells(" ").Value = False
                    Next
                End If
                Cursor = Cursors.Default
            Else
                chboxSeleccionarTodo.Checked = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdListaProductos.Rows.Count > 0 Then
            ExportarExcel(grdListaProductos)
        End If
    End Sub

    Private Sub ExportarExcel(ByVal grdListaProductos As UltraGrid)
        Dim sfd As New SaveFileDialog

        If IsNothing(grdListaProductos) = False Then
            If grdListaProductos.Rows.Count = 0 Then
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "No hay información para exportar a excel."
                mensaje.ShowDialog()
                Return
            End If
        End If

        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName

        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                UltraGridExcelExporter2.Export(grdListaProductos, fileName)
                Process.Start(fileName)
                Dim mensaje As New ExitoForm
                mensaje.mensaje = "El archivo se ha exportado correctamente en la ruta " + fileName
                mensaje.ShowDialog()

                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 201
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 50
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


End Class