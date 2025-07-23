Imports DevExpress.XtraGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Ventas.Negocios
Imports Tools
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report

Public Class Ventas_Administrador_VigenciaArticulosForm
    Dim listaInicial As New List(Of String)
    Dim advertencia As New AdvertenciaForm
    Dim dtObtieneArticulos As New DataTable
    Dim exito As New ExitoForm
    Dim confirmar As New ConfirmarForm
    Private Sub Ventas_Administrador_VigenciaArticulosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        lblRegistros.Text = 0
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        aplicarpermisos()
    End Sub

    Public Sub aplicarpermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PRO_ADM_VIG_ARTICULOS", "REVERTIR") Then
            pnlRevertir.Visible = True
        Else
            pnlRevertir.Visible = False

        End If
    End Sub


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Consultar()
        'Dim objBU As New VigenciaArticulosBU

        'Dim FechaInicio As Date = dtpFechaInicio.Value.ToShortDateString()
        'Dim FechaFin As Date = dtpFechaFin.Value.ToShortDateString()
        'Dim FMarca As String = String.Empty
        'Dim FColeccion As String = String.Empty

        'Try
        '    Cursor = Cursors.WaitCursor

        '    If FechaInicio > FechaFin Then
        '        advertencia.mensaje = "La fecha de inicio no puede ser mayor a la de fin."
        '        advertencia.ShowDialog()
        '    Else

        '        vwVigenciaArticulos.Columns.Clear()
        '        grdVigenciaArticulos.DataSource = Nothing

        '        FMarca = ObtenerFiltrosGrid(grdMarca)
        '        FColeccion = ObtenerFiltrosGrid(grdColeccion)


        '        dtObtieneArticulos = objBU.ObtenerInformacionArticulos(FMarca, FColeccion, ObtenerEstatusArticulos(), FechaInicio, FechaFin)

        '        If dtObtieneArticulos.Rows.Count > 0 Then
        '            grdVigenciaArticulos.DataSource = dtObtieneArticulos
        '            DisenioGrid()
        '            lblRegistros.Text = CDbl(vwVigenciaArticulos.RowCount.ToString()).ToString("n0")
        '            lblUltimaActualizacion.Text = Date.Now
        '        Else
        '            advertencia.mensaje = "No hay datos para mostrar."
        '            advertencia.ShowDialog()
        '        End If


        '    End If



        'Catch ex As Exception
        '    Cursor = Cursors.Default
        'End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub Consultar()
        Dim objBU As New VigenciaArticulosBU

        Dim FechaInicio As Date = dtpFechaInicio.Value.ToShortDateString()
        Dim FechaFin As Date = dtpFechaFin.Value.ToShortDateString()
        Dim FMarca As String = String.Empty
        Dim FColeccion As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor

            If FechaInicio > FechaFin Then
                advertencia.mensaje = "La fecha de inicio no puede ser mayor a la de fin."
                advertencia.ShowDialog()
            Else

                vwVigenciaArticulos.Columns.Clear()
                grdVigenciaArticulos.DataSource = Nothing

                FMarca = ObtenerFiltrosGrid(grdMarca)
                FColeccion = ObtenerFiltrosGrid(grdColeccion)


                dtObtieneArticulos = objBU.ObtenerInformacionArticulos(FMarca, FColeccion, ObtenerEstatusArticulos(), FechaInicio, FechaFin)

                If dtObtieneArticulos.Rows.Count > 0 Then
                    grdVigenciaArticulos.DataSource = dtObtieneArticulos
                    DisenioGrid()
                    lblRegistros.Text = CDbl(vwVigenciaArticulos.RowCount.ToString()).ToString("n0")
                    lblUltimaActualizacion.Text = Date.Now
                Else
                    advertencia.mensaje = "No hay datos para mostrar."
                    advertencia.ShowDialog()
                End If


            End If



        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub



    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwVigenciaArticulos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwVigenciaArticulos.IndicatorWidth = 40

        vwVigenciaArticulos.Columns.ColumnByFieldName(" ").Width = 30
        vwVigenciaArticulos.Columns.ColumnByFieldName("Marca").Width = 60
        vwVigenciaArticulos.Columns.ColumnByFieldName("Coleccion").Width = 120
        vwVigenciaArticulos.Columns.ColumnByFieldName("ModeloSAY").Width = 50
        vwVigenciaArticulos.Columns.ColumnByFieldName("ModeloSICY").Width = 50
        vwVigenciaArticulos.Columns.ColumnByFieldName("PielColor").Width = 130
        vwVigenciaArticulos.Columns.ColumnByFieldName("Corrida").Width = 50
        vwVigenciaArticulos.Columns.ColumnByFieldName("Estatus").Width = 35
        vwVigenciaArticulos.Columns.ColumnByFieldName("FechaEntregaProgramacion").Width = 75
        vwVigenciaArticulos.Columns.ColumnByFieldName("FechaVigencia").Width = 70
        vwVigenciaArticulos.Columns.ColumnByFieldName("UsuarioModifico").Width = 70
        vwVigenciaArticulos.Columns.ColumnByFieldName("FechaCreacion").Width = 100
        vwVigenciaArticulos.Columns.ColumnByFieldName("Observaciones").Width = 150

        vwVigenciaArticulos.Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
        vwVigenciaArticulos.Columns.ColumnByFieldName("PielColor").Caption = "Piel Color"
        vwVigenciaArticulos.Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo" + vbCrLf + "SAY"
        vwVigenciaArticulos.Columns.ColumnByFieldName("ModeloSICY").Caption = "Modelo" + vbCrLf + "SICY"
        vwVigenciaArticulos.Columns.ColumnByFieldName("FechaEntregaProgramacion").Caption = "Última" + vbCrLf + "F Entrega" + vbCrLf + "Propuesta" + vbCrLf + "Programación"
        vwVigenciaArticulos.Columns.ColumnByFieldName("FechaVigencia").Caption = "Fecha" + vbCrLf + "Vigencia"
        vwVigenciaArticulos.Columns.ColumnByFieldName("UsuarioModifico").Caption = "Usuario" + vbCrLf + "Modificó"
        vwVigenciaArticulos.Columns.ColumnByFieldName("FechaCreacion").Caption = "Fecha" + vbCrLf + "Creación"



        vwVigenciaArticulos.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False

        DiseñoGrid.AlternarColorEnFilas(vwVigenciaArticulos)

    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function



    Private Function ObtenerEstatusArticulos() As Integer
        Dim Resultado As String = String.Empty

        If rdoAutorizado.Checked = True Then
            Resultado = 1
        ElseIf rdoDescontinuado.Checked = True Then
            Resultado = 2
        Else
            Resultado = 0
        End If

        Return Resultado

    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim editarVigencia As New Ventas_Edicion_FechaVigenciaForm
        Dim NumeroFilas = vwVigenciaArticulos.DataRowCount
        Dim ContadorArticulos As Integer = 0
        Dim ProductoEstiloSeleccionados As String = String.Empty
        Dim EsUpdate As Integer = 0

        Try

            If vwVigenciaArticulos.DataRowCount > 0 Then

                ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()

                If ProductoEstiloSeleccionados <> "" Then
                    For index As Integer = 0 To NumeroFilas Step 1
                        If CBool(vwVigenciaArticulos.GetRowCellValue(vwVigenciaArticulos.GetVisibleRowHandle(index), " ")) = True Then
                            ContadorArticulos = ContadorArticulos + 1
                        End If
                    Next

                    editarVigencia.ArticulosSeleccionados = ContadorArticulos
                    editarVigencia.ProductoEstilosSeleccionados = ProductoEstiloSeleccionados
                    editarVigencia.ShowDialog()
                    Consultar()

                    btnMostrar_Click(Nothing, Nothing)
                    chkSeleccionarTodo.Checked = False
                Else
                    advertencia.mensaje = "Debe seleccionar al menos un artículo."
                    advertencia.ShowDialog()
                End If
            Else
                advertencia.mensaje = "Debe seleccionar al menos un artículo."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception

        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Function ObtenerProductoEstilosSeleccionados() As String
        Dim NumeroFilas As Integer = 0
        Dim productoEstiloSeleccionados As String = String.Empty


        NumeroFilas = vwVigenciaArticulos.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwVigenciaArticulos.GetRowCellValue(vwVigenciaArticulos.GetVisibleRowHandle(index), " ")) = True Then

                If productoEstiloSeleccionados <> "" Then
                    productoEstiloSeleccionados += ","
                End If

                productoEstiloSeleccionados += vwVigenciaArticulos.GetRowCellValue(vwVigenciaArticulos.GetVisibleRowHandle(index), "ProductoEstiloId").ToString

            End If
        Next

        Return productoEstiloSeleccionados
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If vwVigenciaArticulos.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty


            Try
                nombreReporte = "\Vigencia de Artículos"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If vwVigenciaArticulos.GroupCount > 0 Then
                            vwVigenciaArticulos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            vwVigenciaArticulos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If vwVigenciaArticulos.DataRowCount > 0 Then

                If rdoDescontinuado.Checked = True Then

                    Cursor = Cursors.WaitCursor

                    Dim AdministradorArticulos As New DataSet("AdministradorArticulos")

                    Dim dtArticulosDescontinuados As New DataTable("ArticulosVigencia")
                    dtArticulosDescontinuados = CType(grdVigenciaArticulos.DataSource, DataTable).Copy

                    Dim objBUReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes

                    AdministradorArticulos.Tables.Add(dtArticulosDescontinuados)

                    EntidadReporte = objBUReporte.LeerReporteporClave("RPT_VIG_ART_DESC")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                    Dim reporte As New StiReport()

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("AdministradorArticulos") = "AdministradorArticulos"
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                    reporte.Dictionary.Clear()

                    reporte.RegData(AdministradorArticulos)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()
                Else
                    advertencia.mensaje = "Seleccione el filtro de artículos descontinuados."
                    advertencia.ShowDialog()
                End If

            Else
                advertencia.mensaje = "No hay información para imprimir."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial

        grdVigenciaArticulos.DataSource = Nothing

        lblRegistros.Text = "0"

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = vwVigenciaArticulos.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                vwVigenciaArticulos.SetRowCellValue(vwVigenciaArticulos.GetVisibleRowHandle(index), " ", chkSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
        pnlBotonesExpander.AutoSize = True
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
        pnlBotonesExpander.AutoSize = True
    End Sub

    Private Sub btnAgregarMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarMarca.Click
        Dim listado As New ListadoParametrosApartadosForm
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 1

        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiarMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarMarca.Click
        grdMarca.DataSource = listaInicial
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
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

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim listado As New ListadoParametrosApartadosForm
        Dim listaParametroID As New List(Of String)
        listado.tipo_busqueda = 3

        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub btnLimpiarColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub vwVigenciaArticulos_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwVigenciaArticulos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub rdoDescontinuado_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDescontinuado.CheckedChanged

        If rdoDescontinuado.Checked = True Then
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True

        Else
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False

        End If


    End Sub

    Private Sub btnRevertir_Click(sender As Object, e As EventArgs) Handles btnRevertir.Click
        Dim NumeroFilas = vwVigenciaArticulos.DataRowCount
        Dim objBU As New VigenciaArticulosBU
        Dim advertencia As New AdvertenciaForm

        Try
            confirmar.mensaje = "¿Desea reacivar los artículos seleccionados?."
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If vwVigenciaArticulos.DataRowCount > 0 Then
                    Dim ProductoEstiloSeleccionados As String = ObtenerProductoEstilosSeleccionados()
                    Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    Dim dtRevertir As DataTable
                    If ProductoEstiloSeleccionados <> "" Then
                        dtRevertir = objBU.RevertirFechaVigencia_ArticulosSeleccionados(ProductoEstiloSeleccionados, UsuarioID)
                        If dtRevertir.Rows(0).Item("respuesta").ToString = "ERROR" Then
                            advertencia.mensaje = "Ocurrió un error al reasignar la fecha de vigencia, intente de nuevo."
                            advertencia.ShowDialog()
                        Else
                            If dtRevertir.Rows(0).Item("respuesta").ToString = "BITACORA" Then
                                advertencia.mensaje = "No se encuentra historial del articulo."
                                advertencia.ShowDialog()
                            Else
                                exito.mensaje = "Datos guardados correctamente."
                                exito.ShowDialog()
                            End If
                        End If
                    Else
                        advertencia.mensaje = "Debe seleccionar al menos un artículo."
                        advertencia.ShowDialog()
                    End If


                Else
                    advertencia.mensaje = "Debe seleccionar al menos un artículo."
                    advertencia.ShowDialog()
                End If

            End If
            Consultar()
        Catch ex As Exception
            advertencia.mensaje = ex.Message
            advertencia.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyudaReportes.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub ManualDeUsuarioVigenciaDeArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualDeUsuarioVigenciaDeArtículosToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Vigencia de Artículos.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Vigencia de Artículos.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim objBU As New VigenciaArticulosBU
        Dim dtCancelaVigenciaArticulos As New DataTable

        Try
            If vwVigenciaArticulos.DataRowCount > 0 Then
                confirmar.mensaje = "¿Desea cancelar los registros seleccionados?."
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim ProductoEstiloSeleccionados As String = ObtenerProductoEstilosSeleccionados()
                    Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    If ProductoEstiloSeleccionados <> "" Then
                        dtCancelaVigenciaArticulos = objBU.CancelarSolicitudVencimiento(ProductoEstiloSeleccionados, UsuarioID)
                        If dtCancelaVigenciaArticulos.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                            exito.mensaje = "Datos actualizados correctamente"
                            exito.ShowDialog()
                            Consultar()
                        Else
                            advertencia.mensaje = "Ocurrió un error, intente nuevamente."
                            advertencia.ShowDialog()
                        End If
                    Else
                        advertencia.mensaje = "Debe seleccionar al menos un artículo."
                        advertencia.ShowDialog()
                    End If
                End If
            Else
                advertencia.mensaje = "Debe seleccionar al menos un artículo."
                advertencia.ShowDialog()
            End If
        Catch ex As Exception
            advertencia.mensaje = ex.Message
            advertencia.ShowDialog()
        Finally
            Cursor = Cursors.Default
        End Try


    End Sub
End Class