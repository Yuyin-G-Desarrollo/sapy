Imports DevExpress
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports Tools
Imports DevExpress.XtraPrinting
Imports System.IO
Imports System.Net

Public Class CargaProyeccionForm


    Private listCeldasModificadas As New List(Of GridCell)()
    Private listColumnasMostrarExportacion As New List(Of String)
    Private listColumnasOcultarExportacion As New List(Of String)
    Private importando As Boolean = False
    Dim dtAgentes As New DataTable

    Private Sub CargaProyeccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.CargaProyeccionBU
        Dim objBUCombos As New Negocios.EstadisticoPedidosBU
        Dim objBUComboMarcas As New Negocios.CargaProyeccionBU
        Dim dtMarcas As New DataTable
        Dim dtAñosCargados As New DataTable

        'Inicia datos de años y semanas

        dtAñosCargados = objBU.obtenerAñosGuardados()

        nudAño.Minimum = Integer.Parse(dtAñosCargados.Rows(0).Item("MenorAño").ToString())
        nudAño.Maximum = Integer.Parse(dtAñosCargados.Rows(0).Item("MayorAño").ToString())

        If Date.Now.Year >= nudAño.Minimum And Date.Now.Year <= nudAño.Maximum Then
            nudAño.Value = Date.Now.Year
        Else
            nudAño.Value = nudAño.Minimum
        End If

        nudSemanaDe.Value = nudSemanaDe.Minimum
        nudSemanaA.Value = nudSemanaA.Maximum

        'Termina datos de años y semanas

        'Inicia combo de agentes 

        dtAgentes = objBUCombos.ListadoParametrosReportes(1, 0)
        'dtAgentes.Rows.InsertAt(dtAgentes.NewRow, 0)
        cmboxAgente.DataSource = dtAgentes
        cmboxAgente.DisplayMember = "Nombre"
        cmboxAgente.ValueMember = "Parametro"

        cmboxAgente.SelectedIndex = 0

        'Termina combo de agentes 

        'Inicia combo de marcas 


        dtMarcas = objBUComboMarcas.consultarMarcasPorAgente(cmboxAgente.SelectedValue)
        cmboxMarca.DataSource = dtMarcas
        cmboxMarca.DisplayMember = "Marca"
        cmboxMarca.ValueMember = "Parametro"

        If dtMarcas.Rows.Count > 0 Then

            cmboxMarca.SelectedIndex = 0

        End If

        'Termina combo de marcas 


        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        Dim objBU As New Negocios.CargaProyeccionBU
        Dim dtSemanasCargadasPorAño As New DataTable

        dtSemanasCargadasPorAño = objBU.obtenerSemanasPorAño(nudAño.Value)

        nudSemanaDe.Minimum = dtSemanasCargadasPorAño.Rows(0).Item("PrimeraSemana")
        nudSemanaDe.Maximum = dtSemanasCargadasPorAño.Rows(0).Item("UltimaSemana")
        nudSemanaA.Minimum = nudSemanaDe.Minimum
        nudSemanaA.Maximum = nudSemanaDe.Maximum

    End Sub

    Private Sub nudSemanaDe_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaDe.ValueChanged
        nudSemanaA.Minimum = nudSemanaDe.Value
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmboxAgente.Text <> "" And cmboxMarca.Text <> "" Then

            Dim objBU As New Negocios.CargaProyeccionBU
            Dim dtResultadoConsulta As New DataTable
            Dim filtro_Año As Integer
            Dim filtro_SemanaDe As Integer
            Dim filtro_SemanaA As Integer
            Dim filtro_AgenteIdSAY As Integer
            Dim filtro_MarcaIdSAY As Integer
            Dim filtro_NombreAgente As String
            Dim filtro_NombreMarca As String

            Cursor = Cursors.WaitCursor

            importando = False
            grdDatosProyeccion.DataSource = Nothing
            bgvDatosProyeccion.Columns.Clear()
            bgvDatosProyeccion.Bands.Clear()
            listCeldasModificadas.Clear()

            filtro_Año = nudAño.Value
            filtro_SemanaDe = nudSemanaDe.Value
            filtro_SemanaA = nudSemanaA.Value
            filtro_AgenteIdSAY = If(cmboxAgente.SelectedIndex >= 0, cmboxAgente.SelectedValue, 0)
            filtro_MarcaIdSAY = If(cmboxMarca.SelectedIndex >= 0, cmboxMarca.SelectedValue, 0)
            filtro_NombreAgente = If(cmboxAgente.SelectedIndex >= 0, cmboxAgente.Text, 0)
            filtro_NombreMarca = If(cmboxMarca.SelectedIndex >= 0, cmboxMarca.Text, 0)


            dtResultadoConsulta = objBU.consultaDatosProyeccion(filtro_Año, filtro_SemanaDe, filtro_SemanaA, filtro_AgenteIdSAY, filtro_MarcaIdSAY, filtro_NombreAgente, filtro_NombreMarca)

            If dtResultadoConsulta.Rows.Count > 0 Then

                diseñoGrid(dtResultadoConsulta)

                grdDatosProyeccion.DataSource = dtResultadoConsulta

            Else

                show_message("Advertencia", "No hay datos para mostrar")

            End If

            Cursor = Cursors.Default
        Else
            show_message("Advertencia", "Todos los filtros deben tener datos seleccionados.")
        End If

    End Sub

    Private Sub diseñoGrid(ByVal dtResultado As DataTable)
        Dim band As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        grdDatosProyeccion.DataSource = Nothing
        bgvDatosProyeccion.Bands.Clear()
        bgvDatosProyeccion.Columns.Clear()

        band.Caption = ""
        listBands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Semanas de proyección"
        listBands.Add(band)

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                If IsNothing(bgvDatosProyeccion.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
                    bgvDatosProyeccion.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
                    bgvDatosProyeccion.Columns.ColumnByFieldName("#").OwnerBand = gridBand
                    AddHandler bgvDatosProyeccion.CustomUnboundColumnData, AddressOf bgvDatosProyeccion_CustomUnboundColumnData
                    bgvDatosProyeccion.Columns.Item("#").VisibleIndex = 0
                End If
            End If
            For Each col As DataColumn In dtResultado.Columns
                If (IsNumeric(col.ColumnName) Or col.ColumnName = "Total") And gridBand.Caption <> "" Then
                    bgvDatosProyeccion.Columns.AddField(col.ColumnName)
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatString = "N0"
                    If col.ColumnName <> "Total" Then
                        bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = True
                    Else
                        bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = False
                    End If
                ElseIf IsNumeric(col.ColumnName) = False And col.ColumnName <> "Total" And gridBand.Caption = "" Then
                    bgvDatosProyeccion.Columns.AddField(col.ColumnName)
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = False
                End If
            Next
            bgvDatosProyeccion.Bands.Add(gridBand)
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvDatosProyeccion.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvDatosProyeccion.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        listColumnasMostrarExportacion.Add("Id Agente")
        listColumnasMostrarExportacion.Add("Agente")
        listColumnasMostrarExportacion.Add("Id Marca")
        listColumnasMostrarExportacion.Add("MarcaSICY")
        listColumnasMostrarExportacion.Add("Marca")
        listColumnasMostrarExportacion.Add("Año")

        'listColumnasOcultarExportacion.Add("SICY")
        listColumnasOcultarExportacion.Add("Total")

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvDatosProyeccion.Columns
            bgvDatosProyeccion.Columns.ColumnByFieldName(Col.FieldName).OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If Col.FieldName = "#" Then
                Col.Width = 30
                Col.OptionsColumn.AllowEdit = False
            End If
            If IsNumeric(Col.FieldName) Then
                Col.Width = 60
            End If
            If Col.FieldName = "SAY" Then
                Col.Width = 50
            End If
            If Col.FieldName = "SICY" Then
                Col.Width = 50
            End If
            If Col.FieldName = "Total" Then
                Col.Width = 80
            End If
            If Col.FieldName = "Cliente" Or Col.FieldName = "Agente" Then
                Col.Width = 210
            End If
            If Col.FieldName = "Activo" Then
                Col.Width = 50
            End If
            If Col.FieldName = "RutaIdSAY" Or Col.FieldName = "MarcaSICY" Or listColumnasMostrarExportacion.Contains(Col.FieldName) Then
                Col.Visible = False
            End If
            If IsNumeric(Col.FieldName) Or Col.FieldName = "Total" Then
                Col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = Col.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                bgvDatosProyeccion.GroupSummary.Add(item)
            End If
        Next



    End Sub

    Private Sub bgvDatosProyeccion_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = bgvDatosProyeccion.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub


    Private Sub bgvDatosProyeccion_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvDatosProyeccion.RowStyle
        Dim View As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("#"))
            If category Mod 2 > 0 Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If
    End Sub

#Region "FORMATO CELDAS AL MODIFICAR VALOR"

    Private Sub bgvDatosProyeccion_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles bgvDatosProyeccion.CellValueChanged
        If (Not ExisteCelda(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
            listCeldasModificadas.Add(New GridCell(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column))
        End If
    End Sub

    Private Function ExisteCelda(ByVal sourceRowIndex As Integer, ByVal col As GridColumn) As Boolean
        Dim Resultado As GridCell = listCeldasModificadas.Where(Function(c) c.Column Is col AndAlso c.RowHandle = sourceRowIndex).FirstOrDefault()
        Return Resultado IsNot Nothing
    End Function

    Private Sub bgvDatosProyeccion_RowCellStyle(sender As Object, e As Grid.RowCellStyleEventArgs) Handles bgvDatosProyeccion.RowCellStyle
        If ExisteCelda(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column) Then
            e.Appearance.ForeColor = lblTextoCambiosNoGuardados.ForeColor
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        End If
    End Sub

#End Region

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Cursor = Cursors.WaitCursor
        grdDatosProyeccion.DataSource = Nothing
        bgvDatosProyeccion.Bands.Clear()
        bgvDatosProyeccion.Columns.Clear()
        cmboxAgente.SelectedIndex = 0
        cmboxMarca.SelectedIndex = 0
        If Date.Now.Year >= nudAño.Minimum And Date.Now.Year <= nudAño.Maximum Then
            nudAño.Value = Date.Now.Year
        Else
            nudAño.Value = nudAño.Minimum
        End If

        nudSemanaDe.Value = nudSemanaDe.Minimum
        nudSemanaA.Value = nudSemanaA.Maximum

        listCeldasModificadas.Clear()

        Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim datosProyeccionGuardar As Entidades.DatosCargarProyeccion
        Dim dtResultadoGuardado As New DataTable
        Dim objBU As New Negocios.CargaProyeccionBU
        Dim confirmacion As New Tools.ConfirmarForm
        Dim totalCeldasConDatos As Integer = 0

        Try
            For Each celda As GridCell In listCeldasModificadas
                If IsDBNull(bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, celda.Column)) = False Then
                    totalCeldasConDatos += 1
                End If
            Next

            If totalCeldasConDatos > 0 And importando = False Then
                confirmacion.mensaje = "¿Desea guardar los cambios realizados?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Cursor = Cursors.WaitCursor

                    If importando = False Then
                        For Each celda As GridCell In listCeldasModificadas
                            If IsDBNull(bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, celda.Column)) = False Then
                                datosProyeccionGuardar = New Entidades.DatosCargarProyeccion
                                datosProyeccionGuardar.semana = Integer.Parse(celda.Column.FieldName.ToString)
                                datosProyeccionGuardar.año = nudAño.Value
                                datosProyeccionGuardar.marcaSAY = cmboxMarca.SelectedValue
                                datosProyeccionGuardar.colaboradorAgenteId = cmboxAgente.SelectedValue
                                datosProyeccionGuardar.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "SAY")
                                datosProyeccionGuardar.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "SICY")
                                datosProyeccionGuardar.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "RutaIdSAY")
                                datosProyeccionGuardar.paresProyectar = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, celda.Column)
                                datosProyeccionGuardar.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                datosProyeccionGuardar.marcaSICY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "MarcaSICY")
                                objBU.guardarEditarDatosProyeccion(datosProyeccionGuardar)
                            End If
                        Next
                    End If
                    show_message("Exito", "Datos guardados correctamente")
                    btnMostrar_Click(sender, e)
                End If
            ElseIf importando = True Then
                Cursor = Cursors.WaitCursor
                For x As Integer = 0 To bgvDatosProyeccion.DataRowCount - 1 Step 1
                    For Each col As GridColumn In bgvDatosProyeccion.Columns
                        If IsNumeric(col.FieldName.ToString) Then
                            If IsDBNull(bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), col)) = False Then
                                datosProyeccionGuardar = New Entidades.DatosCargarProyeccion
                                datosProyeccionGuardar.semana = Integer.Parse(col.FieldName.ToString)
                                datosProyeccionGuardar.año = nudAño.Value
                                datosProyeccionGuardar.marcaSAY = cmboxMarca.SelectedValue
                                datosProyeccionGuardar.colaboradorAgenteId = cmboxAgente.SelectedValue
                                datosProyeccionGuardar.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "SAY")
                                datosProyeccionGuardar.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "SICY")
                                datosProyeccionGuardar.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "RutaIdSAY")
                                datosProyeccionGuardar.paresProyectar = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), col)
                                datosProyeccionGuardar.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                                datosProyeccionGuardar.marcaSICY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "MarcaSICY")
                                objBU.guardarEditarDatosProyeccion(datosProyeccionGuardar)
                            End If
                        End If
                    Next
                Next
                show_message("Exito", "Datos guardados correctamente")
                btnMostrar_Click(sender, e)
            Else
                show_message("Advertencia", "No hay datos para guardar.")
            End If

        Catch ex As Exception
            show_message("Error", "Hubo un error al guardar, intente de nuevo.")
        End Try
        Cursor = Cursors.Default
    End Sub


#Region "Otras Funciones"

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

#End Region

#Region "EXPORTACIÓN A EXCEL"

    Private Sub btnExportarExcelProyeccion_Click(sender As Object, e As EventArgs) Handles btnExportarExcelProyeccion.Click
        If bgvDatosProyeccion.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim splitAgente() As String = cmboxAgente.Text.ToString.Split(" ")
            Dim marca As String = cmboxMarca.Text.ToString()

            Try
                If splitAgente.Count > 3 Then
                    nombreReporte = "\Proyeccion_" + splitAgente(0) + "_" + splitAgente(1) + "_" + marca + "_"
                Else
                    nombreReporte = "\Proyeccion_" + splitAgente(0) + "_" + marca + "_"
                End If

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvDatosProyeccion.GroupCount > 0 Then
                            bgvDatosProyeccion.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            For Each col As String In listColumnasMostrarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = True
                            Next
                            For Each col As String In listColumnasOcultarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = False
                            Next

                            bgvDatosProyeccion.Bands(0).Caption = "NO MODIFICAR LA INFORMACIÓN DE LAS COLUMNAS DE AGENTE, CLIENTE Y MARCA"
                            bgvDatosProyeccion.Bands(1).Caption = "Semanas de la proyección NO MODIFICAR"

                            bgvDatosProyeccion.OptionsView.ShowFooter = False

                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            exportOptions.SheetName = "DATOS"


                            grdDatosProyeccion.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)


                            For Each col As String In listColumnasMostrarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = False
                            Next
                            For Each col As String In listColumnasOcultarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = True
                            Next

                            bgvDatosProyeccion.Bands(0).Caption = ""
                            bgvDatosProyeccion.Bands(1).Caption = "Semanas de proyección"
                            bgvDatosProyeccion.OptionsView.ShowFooter = True

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()


                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try
            If (e.RowHandle >= 0) Then
                Dim category As String = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "#")
                If category Mod 2 > 0 Then
                    e.Formatting.BackColor = Color.LightSteelBlue
                End If
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

#End Region


    Private Sub btnImportarExcelProyeccion_Click(sender As Object, e As EventArgs) Handles btnImportarExcelProyeccion.Click
        Cursor = Cursors.WaitCursor
        ImportarExcel()
        Cursor = Cursors.Default
    End Sub

    Private Sub ImportarExcel()
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumColumna As Integer = 0
        Dim dtDatosMostrar As New DataTable
        Dim NombreColumna As String = ""
        Dim totalRenglon As Integer = 0
        Dim listColumnasEnteros As New List(Of String)
        Try
            Dim hoja As String = "DATOS$"
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablasSinSeleccionarHoja(hoja, "", NombreArchivo)

            Cursor = Cursors.WaitCursor
            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then
                    For Each row As DataRow In datosExcel.Rows
                        If NumRenglon = 0 Then
                            For Each col As DataColumn In datosExcel.Columns
                                Select Case NumColumna
                                    Case 1
                                        NombreColumna = "Id Agente"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 2
                                        NombreColumna = "Agente"
                                    Case 3
                                        NombreColumna = "SAY"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 5
                                        NombreColumna = "Cliente"
                                    Case 6
                                        NombreColumna = "Activo"
                                    Case 7
                                        NombreColumna = "Id Marca"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 9
                                        NombreColumna = "Marca"
                                    Case 10
                                        NombreColumna = "Año"
                                    Case 4
                                        NombreColumna = "SICY"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 8
                                        NombreColumna = "MarcaSICY"
                                    Case Else
                                        NombreColumna = row(col).ToString()
                                        listColumnasEnteros.Add(NombreColumna)
                                End Select
                                If NumColumna > 0 Then
                                    dtDatosMostrar.Columns.Add(NombreColumna)
                                    If listColumnasEnteros.Contains(NombreColumna) Then
                                        dtDatosMostrar.Columns(NombreColumna).DataType = System.Type.GetType("System.Int32")
                                    End If
                                End If
                                NumColumna += 1
                            Next
                            dtDatosMostrar.Columns.Add("Total")
                            dtDatosMostrar.Columns("Total").DataType = System.Type.GetType("System.Int32")
                        ElseIf NumRenglon > 0 Then
                            dtDatosMostrar.Rows.Add()
                            For columna As Integer = 1 To dtDatosMostrar.Columns.Count - 1 Step 1
                                If row(columna).ToString() <> "" Then
                                    dtDatosMostrar.Rows(NumRenglon - 1)(columna - 1) = row(columna)
                                End If
                            Next
                        End If
                        NumRenglon += 1
                    Next

                End If

                If dtDatosMostrar.Rows.Count > 0 Then


                    For Each row As DataRow In dtDatosMostrar.Rows
                        totalRenglon = 0
                        For Each col As DataColumn In dtDatosMostrar.Columns
                            If IsNumeric(col.ColumnName) Then
                                totalRenglon += Integer.Parse(If(row(col).ToString = "", 0, row(col).ToString))
                            End If
                        Next
                        row("Total") = totalRenglon
                    Next

                    bgvDatosProyeccion.Columns.Clear()
                    bgvDatosProyeccion.Bands.Clear()
                    grdDatosProyeccion.DataSource = Nothing

                    diseñoGrid(dtDatosMostrar)

                    grdDatosProyeccion.DataSource = dtDatosMostrar
                    importando = True

                    nudAño.Value = Integer.Parse(dtDatosMostrar.Rows(0)("Año").ToString)
                    nudSemanaDe.Value = Integer.Parse(dtDatosMostrar.Columns(10).ColumnName.ToString)
                    nudSemanaA.Value = Integer.Parse(dtDatosMostrar.Columns(dtDatosMostrar.Columns.Count - 2).ColumnName.ToString)

                    cmboxAgente.SelectedValue = Integer.Parse(dtDatosMostrar.Rows(0)("Id Agente").ToString)
                    For Each row As DataRow In dtAgentes.Rows
                        If row.Item("Parametro") = cmboxAgente.SelectedValue Then
                            cmboxAgente.Text = row.Item("Nombre")
                        End If
                    Next
                    cmboxMarca.SelectedValue = Integer.Parse(dtDatosMostrar.Rows(0)("Id Marca").ToString)

                    listCeldasModificadas.Clear()


                Else

                    show_message("Advertencia", "No hay datos para mostrar.")

                End If
            Else
                show_message("Advertencia", "El nombre del archivo a importar debe iniciar con: ""Proyección"".")
            End If
        Catch ex As Exception
            show_message("Error", "Las cantidades de pares por semana deben ser números enteros. Favor de verificar.")
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub bgvDatosProyeccion_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvDatosProyeccion.CustomDrawCell

        If importando Then
            Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

            Try
                'Cursor = Cursors.WaitCursor

                If IsNumeric(e.Column.FieldName) Then
                    If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False And IsNothing(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = False Then
                        If (Not ExisteCelda(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
                            If importando = False Then
                                listCeldasModificadas.Add(New GridCell(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column))
                            End If
                            e.Appearance.ForeColor = lblTextoCambiosNoGuardados.ForeColor
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                        End If
                    End If
                End If

                'Cursor = Cursors.Default
            Catch ex As Exception
                'Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try
            'End If
        End If


    End Sub


    Private Sub cmboxAgente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmboxAgente.SelectedIndexChanged
        'Inicia combo de marcas 
        If IsNumeric(cmboxAgente.SelectedValue) Then

            Dim objBUCombos As New Negocios.CargaProyeccionBU
            Dim dtMarcas As New DataTable

            cmboxMarca.DataSource = Nothing
            cmboxAgente.Text = ""

            dtMarcas = objBUCombos.consultarMarcasPorAgente(cmboxAgente.SelectedValue)
            cmboxMarca.DataSource = dtMarcas
            cmboxMarca.DisplayMember = "Marca"
            cmboxMarca.ValueMember = "Parametro"

            If dtMarcas.Rows.Count > 0 Then

                cmboxMarca.SelectedIndex = 0

            End If

        End If
        'Termina combo de marcas 
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Carga_Proyeccion_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Carga_Proyeccion_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

   
End Class