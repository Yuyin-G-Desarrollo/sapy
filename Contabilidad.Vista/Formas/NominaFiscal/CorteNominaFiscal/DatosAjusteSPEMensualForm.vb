Imports System.Windows.Forms
Imports Framework.Negocios
Imports DevExpress.XtraPrinting
Imports System.Data.OleDb
Imports System.Drawing
Imports Tools
Imports Stimulsoft.Report

Public Class DatosAjusteSPEMensualForm
    Dim puedeEditar As Boolean = False
    Dim registrosEdicion As Integer = 0
    Private Sub DatosAjusteSPEMensualForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        If PermisosUsuarioBU.ConsultarPermiso("CARGA_DATOS_SPEM", "IMPORTAR") Then
            pnlImportar.Visible = True
            pnlLayout.Visible = True
        Else
            pnlImportar.Visible = False
            pnlLayout.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CARGA_DATOS_SPEM", "EDITAR_GRID") Then
            puedeEditar = True
            pnlGuardar.Visible = True
        Else
            puedeEditar = False
            pnlGuardar.Visible = False
        End If

        pnlAutorizar.Visible = PermisosUsuarioBU.ConsultarPermiso("CARGA_DATOS_SPEM", "AUTORIZA_MES")

        'Permisos menú 
        DatosAjusteArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("CARGA_DATOS_SPEM", "MODIF_WORD_DATOS")
        DatosAjustePropuestaToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("CARGA_DATOS_SPEM", "PROPUESTA_CARGA_DATOS")

        llenarComboMes()
        llenarComboPatrones()
        numAnio.Value = Now.Year

    End Sub

    Private Sub limpiar()
        registrosEdicion = 0
        vwDatos.Columns.Clear()
        grdDatos.DataSource = Nothing
        txtNombre.Text = ""
    End Sub

    Private Sub llenarComboMes()

        Dim objBU As New Negocios.DatosSPEMensualBU
        Dim dtLista As New DataTable

        dtLista = objBU.consultaListaMeses()

        If Not dtLista Is Nothing AndAlso dtLista.Rows.Count > 0 Then
            cmbMes.DataSource = dtLista
            cmbMes.ValueMember = "NumMes"
            cmbMes.DisplayMember = "Descripcion"
        Else
            cmbMes.DataSource = Nothing
        End If

    End Sub

    Private Sub llenarComboPatrones()
        Dim objBU As New Negocios.UtileriasBU
        Dim dtPatrones As New DataTable

        dtPatrones = objBU.consultarPatronEmpresa()

        If Not dtPatrones Is Nothing AndAlso dtPatrones.Rows.Count > 0 Then
            cmbPatron.DataSource = dtPatrones
            cmbPatron.ValueMember = "ID"
            cmbPatron.DisplayMember = "PATRON"
        Else
            cmbPatron.DataSource = Nothing
        End If

    End Sub

    Private Sub consultarDatos()
        If cmbPatron.SelectedIndex > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim objBu As New Negocios.DatosSPEMensualBU
                Dim dtDatos As New DataTable
                registrosEdicion = 0
                vwDatos.Columns.Clear()
                grdDatos.DataSource = Nothing

                dtDatos = objBu.consultarDatos(cmbPatron.SelectedValue, numAnio.Value, cmbMes.SelectedValue, txtNombre.Text.Trim)

                If datosAutorizados(cmbPatron.SelectedValue, numAnio.Value, cmbMes.SelectedValue) Then
                    pnlAutorizar.Enabled = False
                    pnlLayout.Enabled = False
                    pnlImportar.Enabled = False
                    pnlGuardar.Enabled = False
                    puedeEditar = False
                Else
                    pnlAutorizar.Enabled = True
                    pnlLayout.Enabled = True
                    pnlImportar.Enabled = True
                    pnlGuardar.Enabled = True
                    puedeEditar = PermisosUsuarioBU.ConsultarPermiso("CARGA_DATOS_SPEM", "EDITAR_GRID")
                End If

                If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                    grdDatos.DataSource = dtDatos
                    diseniogrid()
                    totalesGrid()
                    vwDatos.OptionsView.ShowFooter = True
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información.")
                End If



            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de seleccionar un patrón.")

        End If

    End Sub

    Private Sub diseniogrid()
        Tools.DiseñoGrid.AlternarColorEnFilas(vwDatos)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwDatos)

        vwDatos.Columns("colaboradorid").Visible = False
        vwDatos.Columns("EdicionEC").Visible = False
        vwDatos.Columns("EdicionGC").Visible = False
        vwDatos.Columns("EdicionIC").Visible = False
        vwDatos.Columns("NumMes").Visible = False
        vwDatos.Columns("Anio").Visible = False
        vwDatos.Columns("PatronId").Visible = False
        vwDatos.Columns("No").OptionsColumn.AllowEdit = False

        vwDatos.Columns("Clave").OptionsColumn.AllowEdit = False
        vwDatos.Columns("Colaborador").OptionsColumn.AllowEdit = False
        vwDatos.Columns("RFC").OptionsColumn.AllowEdit = False
        vwDatos.Columns("Neto").OptionsColumn.AllowEdit = False
        vwDatos.Columns("Mes").OptionsColumn.AllowEdit = False

        If puedeEditar = False Then
            vwDatos.Columns("ExentoCargado").OptionsColumn.AllowEdit = False
            vwDatos.Columns("GravadoCargado").OptionsColumn.AllowEdit = False
            vwDatos.Columns("ISRCargado").OptionsColumn.AllowEdit = False
        End If

        vwDatos.Columns.ColumnByFieldName("ExentoCargado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("ExentoCargado").DisplayFormat.FormatString = "N2"
        vwDatos.Columns.ColumnByFieldName("GravadoCargado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("GravadoCargado").DisplayFormat.FormatString = "N2"
        vwDatos.Columns.ColumnByFieldName("ISRCargado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("ISRCargado").DisplayFormat.FormatString = "N2"
        vwDatos.Columns.ColumnByFieldName("Neto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("Neto").DisplayFormat.FormatString = "N2"

        vwDatos.Columns.ColumnByFieldName("No").Width = 20
        vwDatos.Columns.ColumnByFieldName("Clave").Width = 30
        vwDatos.Columns.ColumnByFieldName("RFC").Width = 100
        vwDatos.Columns.ColumnByFieldName("Colaborador").Width = 250

        vwDatos.Columns.ColumnByFieldName("ExentoCargado").Width = 120
        vwDatos.Columns.ColumnByFieldName("GravadoCargado").Width = 120
        vwDatos.Columns.ColumnByFieldName("ISRCargado").Width = 120
        vwDatos.Columns.ColumnByFieldName("Neto").Width = 120
        vwDatos.Columns.ColumnByFieldName("Mes").Width = 140

        vwDatos.Columns.ColumnByFieldName("Clave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("Colaborador").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("RFC").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub
    Private Sub totalesGrid()
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwDatos.Columns
            If vColumna.FieldName = "ExentoCargado" OrElse vColumna.FieldName = "GravadoCargado" OrElse vColumna.FieldName = "ISRCargado" OrElse vColumna.FieldName = "Neto" Then

                vColumna.Summary.Add(DevExpress.Data.SummaryItemType.Sum, vColumna.FieldName, "{0:N2}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = vColumna.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:N2}"
                vwDatos.GroupSummary.Add(item)
                vColumna.OptionsFilter.AllowFilter = False
            End If
        Next

    End Sub
    Private Sub exportar(ByVal tipoArchivo As String)
        Me.Cursor = Cursors.WaitCursor
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    Dim exportOptions = New XlsxExportOptionsEx()
                    Dim archivo As String = String.Empty
                    archivo = .SelectedPath + tipoArchivo + fecha_hora + ".xlsx"

                    If tipoArchivo = "\LayoutCargarDatos_" Then
                        vwDatos.OptionsView.ShowFooter = False
                    End If

                    vwDatos.ExportToXlsx(archivo, exportOptions)
                    consultarDatos()

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente.")
                    .Dispose()

                    Process.Start(archivo)

                End If
            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub importarDatos()
        Dim objMensajeConf As New Tools.ConfirmarForm
        objMensajeConf.mensaje = "Al importar el archivo Excel se realizará la actualizacion de los datos del patrón, año y mes seleccionados, ¿Esta seguro de continuar?"
        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Dim myFileDialog As New OpenFileDialog()
                Dim dt As DataTable
                Dim xSheet As String = ""
                Dim blnImportar As Boolean = True
                Dim mes As String

                mes = cmbMes.Text

                With myFileDialog
                    .Filter = "Excel Files |*.xlsx"
                    .Title = "Open File"
                    .ShowDialog()
                End With

                If myFileDialog.FileName.ToString <> "" Then
                    Dim ExcelFile As String = myFileDialog.FileName.ToString
                    Dim listaImportar As New List(Of Entidades.DatosSPEMensual)
                    Dim datosImportar As New Entidades.DatosSPEMensual
                    Dim ds As New DataSet
                    Dim da As New OleDbDataAdapter
                    Dim conn As OleDbConnection
                    xSheet = "Sheet"
                    conn = New OleDbConnection(
                        "Provider=Microsoft.ACE.OLEDB.12.0;" &
                        "data source=" & ExcelFile & "; " &
                        "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

                    Try
                        Me.Cursor = Cursors.WaitCursor
                        da = New OleDbDataAdapter("Select * FROM [" & xSheet & "$]", conn)
                        conn.Open()
                        da.Fill(ds, "MyData")
                        dt = ds.Tables("MyData")

                        For Each Row As DataRow In dt.Rows
                            If String.IsNullOrEmpty(Row.Item(1).ToString) Then
                                Exit For
                            End If
                            datosImportar = New Entidades.DatosSPEMensual
                            With datosImportar
                                .PRFC = Row.Item(3)
                                .PExentoCargado = Row.Item(4)
                                .PGravadoCargado = Row.Item(5)
                                .PISRCargado = Row.Item(6)
                                .PPatronId = cmbPatron.SelectedValue
                                .PAnio = numAnio.Value
                                .PMes = cmbMes.SelectedValue
                            End With

                            listaImportar.Add(datosImportar)

                            If Row.Item(8).ToString.Trim.ToUpper <> mes.Trim.ToUpper Then
                                blnImportar = False
                            End If



                        Next

                        If blnImportar Then
                            Dim msjResult As String = String.Empty
                            Dim objBu As New Negocios.DatosSPEMensualBU

                            msjResult = objBu.importarDatos(listaImportar)

                            If msjResult = "EXITO" Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se han actualizado correctamente.")
                            Else
                                Utilerias.show_message(Utilerias.TipoMensaje.Errores, msjResult)
                            End If

                            consultarDatos()

                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El archivo no puede ser importado, ya que contiene información de meses diferentes al seleccionado.")
                            conn.Close() 'revisar                            
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al intentar importar la información.")
                    Finally
                        conn.Close()
                        Me.Cursor = Cursors.Default
                    End Try
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe seleccionar un archivo para importar.")
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub actualizarDatos()
        If vwDatos.RowCount > 0 Then
            If registrosEdicion > 0 Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "Esta acción modificará los datos existentes, ¿Esta seguro de continuar?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        Me.Cursor = Cursors.WaitCursor

                        Dim listaImportar As New List(Of Entidades.DatosSPEMensual)
                        Dim datosImportar As New Entidades.DatosSPEMensual
                        limpiarfiltros()

                        For index As Integer = 0 To vwDatos.DataRowCount - 1 Step 1
                            datosImportar = New Entidades.DatosSPEMensual
                            With datosImportar
                                .PRFC = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "RFC")
                                .PExentoCargado = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "ExentoCargado")
                                .PGravadoCargado = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "GravadoCargado")
                                .PISRCargado = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "ISRCargado")
                                .PPatronId = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "PatronId")
                                .PAnio = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "Anio")
                                .PMes = vwDatos.GetRowCellValue(vwDatos.GetVisibleRowHandle(index), "NumMes")
                            End With

                            listaImportar.Add(datosImportar)
                        Next

                        Dim msjResult As String = String.Empty
                        Dim objBu As New Negocios.DatosSPEMensualBU

                        msjResult = objBu.importarDatos(listaImportar)

                        If msjResult = "EXITO" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se han actualizado correctamente.")
                            consultarDatos()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, msjResult & Environment.NewLine & "Intente nuevamente.")
                        End If
                    Catch ex As Exception
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
                    Finally
                        Me.Cursor = Cursors.Default
                    End Try
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe haber al menos un registro en edición para guardar la información.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay datos para guardar.")
        End If

    End Sub

    Private Function datosAutorizados(ByVal patronId As Integer, ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim blnAutorizado As Boolean = False
        Dim objBu As New Negocios.DatosSPEMensualBU
        blnAutorizado = objBu.validarEstatusAutorizado(patronId, anio, mes)

        Return blnAutorizado
    End Function

    Private Sub autorizarDatos()
        If registrosEdicion > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen registros en edición, no es posible autorizar.")
        Else
            If datosAutorizados(cmbPatron.SelectedValue, numAnio.Value, cmbMes.SelectedValue) Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Los datos de este patrón, año y mes ya han sido autorizados.")
                consultarDatos()

            Else
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Dim objBu As New Negocios.DatosSPEMensualBU
                    Dim dtResultado As New DataTable

                    dtResultado = objBu.autorizarDatos(cmbPatron.SelectedValue, numAnio.Value, cmbMes.SelectedValue)
                    If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
                        If dtResultado.Rows(0).Item(0) = "EXITO" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se han autorizado correctamente.")
                            consultarDatos()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, dtResultado.Rows(0).Item(0))
                        End If
                    End If
                Catch ex As Exception
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End If
    End Sub

    Private Sub imprimirReporte()
        Try
            Dim objDSBU As New Negocios.DatosSPEMensualBU
            Dim strPatron As String = String.Empty
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim dtReporte As New DataTable
            EntidadReporte = OBJBU.LeerReporteporClave("REP_DATOS_SPEM")

            Dim archivo As String
            archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            dtReporte = vwDatos.GridControl.DataSource
            strPatron = objDSBU.obtieneEncabezadoReporte(cmbPatron.SelectedValue)

            Dim reporte As StiReport = New StiReport()
            reporte.Load(archivo)
            reporte.Compile()
            reporte("Patron") = strPatron
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.Dictionary.Clear()
            reporte.RegData(dtReporte)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
        End Try
    End Sub

    Private Sub limpiarfiltros()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwDatos.Columns
            col.ClearFilter()
        Next
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If registrosEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If registrosEdicion = 0 Then
            consultarDatos()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                consultarDatos()
            End If
        End If

    End Sub

    Private Sub btnLayout_Click(sender As Object, e As EventArgs) Handles btnLayout.Click
        If Not IsNothing(grdDatos.DataSource) AndAlso vwDatos.RowCount > 0 Then
            If registrosEdicion > 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen registros en edición, es necesario guardar los cambios antes de exportar el Layout.")
            Else
                exportar("\LayoutCargarDatos_")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existen datos para expotar.")
        End If

    End Sub

    Private Sub btnImportarDatos_Click(sender As Object, e As EventArgs) Handles btnImportarDatos.Click
        If cmbPatron.SelectedIndex > 0 AndAlso cmbMes.SelectedIndex > 0 Then
            If registrosEdicion > 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existen registros en edición, es necesario guardar los cambios para poder importar el archivo Excel.")
            Else
                If datosAutorizados(cmbPatron.SelectedValue, numAnio.Value, cmbMes.SelectedValue) Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Los datos de este patrón, año y mes ya han sido autorizados.")
                Else
                    importarDatos()
                End If

            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar Patrón y Mes para importar la información.")
        End If

    End Sub

    Private Sub vwDatos_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles vwDatos.CellValueChanged
        If e.Column.FieldName = "ExentoCargado" OrElse e.Column.FieldName = "GravadoCargado" OrElse e.Column.FieldName = "ISRCargado" Then
            Try
                Dim exentoCargado As Double = 0.0
                Dim gravadoCargado As Double = 0.0
                Dim ISRCargado As Double = 0.0
                Dim Neto As Double = 0.0

                Select Case e.Column.FieldName
                    Case "ExentoCargado"
                        vwDatos.SetRowCellValue(e.RowHandle, "EdicionEC", True)
                    Case "GravadoCargado"
                        vwDatos.SetRowCellValue(e.RowHandle, "EdicionGC", True)
                    Case "ISRCargado"
                        vwDatos.SetRowCellValue(e.RowHandle, "EdicionIC", True)
                End Select

                exentoCargado = vwDatos.GetRowCellValue(e.RowHandle, "ExentoCargado")
                gravadoCargado = vwDatos.GetRowCellValue(e.RowHandle, "GravadoCargado")
                ISRCargado = vwDatos.GetRowCellValue(e.RowHandle, "ISRCargado")

                Neto = exentoCargado + gravadoCargado - ISRCargado
                vwDatos.SetRowCellValue(e.RowHandle, "Neto", Neto)

                registrosEdicion += 1

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            End Try
        End If
    End Sub

    Private Sub vwDatos_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles vwDatos.CustomDrawCell
        Try
            If e.Column.FieldName = "ExentoCargado" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EdicionEC")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            ElseIf e.Column.FieldName = "GravadoCargado" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EdicionGC")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            ElseIf e.Column.FieldName = "ISRCargado" AndAlso CBool(sender.GetRowCellValue(e.RowHandle, "EdicionIC")) Then
                e.Appearance.BackColor = Color.FromArgb(35, 177, 77)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        actualizarDatos()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Dim blnLimpiar As Boolean = False
        If registrosEdicion = 0 Then
            blnLimpiar = True
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                blnLimpiar = True
            End If
        End If

        If blnLimpiar Then
            limpiar()
            cmbPatron.SelectedIndex = 0
            cmbMes.SelectedIndex = 0
            numAnio.Value = Now.Year
        End If

    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        If Not IsNothing(grdDatos.DataSource) AndAlso vwDatos.RowCount > 0 Then
            If cmbPatron.SelectedIndex > 0 AndAlso cmbMes.SelectedIndex > 0 Then

                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "Está acción no se puede revertir, ¿Esta seguro de continuar?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    autorizarDatos()
                End If

            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar Patrón y Mes para autorizar la información.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha cargado información.")
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If Not IsNothing(grdDatos.DataSource) AndAlso vwDatos.RowCount > 0 Then
            If registrosEdicion > 0 Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    exportar("\DatosAjusteSPEMensual_")
                End If
            Else
                exportar("\DatosAjusteSPEMensual_")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existen datos para expotar.")
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Not IsNothing(grdDatos.DataSource) AndAlso vwDatos.RowCount > 0 Then
            imprimirReporte()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario cargar los datos para enviar al reporte.")
        End If

    End Sub

    Private Sub cmbPatron_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPatron.DropDownClosed, cmbPatron.SelectedValueChanged
        If Not IsNothing(cmbPatron.DataSource) AndAlso cmbPatron.SelectedIndex > 0 Then
            If registrosEdicion = 0 Then
                limpiar()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No es posible seleccionar otro patrón ya que hay registros en edición.")
                cmbPatron.SelectedValue = vwDatos.GetRowCellValue(vwDatos.GetRowHandle(0), "PatronId")
            End If

        End If

    End Sub

    Private Sub cmbMes_DropDownClosed(sender As Object, e As EventArgs) Handles cmbMes.DropDownClosed, cmbMes.SelectedValueChanged
        If Not IsNothing(cmbMes.DataSource) AndAlso cmbMes.SelectedIndex > 0 Then
            If registrosEdicion = 0 Then
                limpiar()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaDatosAjusteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaDatosAjusteToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_CargaDatosSubsidio_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_CargaDatosSubsidio_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DatosAjusteArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosAjusteArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_CargaDatosSubsidio_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_CargaDatosSubsidio_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DatosAjustePropuestaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DatosAjustePropuestaToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "Contabilidad_SAY_IntegracionDatosAjusteSubsidio_May2020.docx")
            Process.Start("Descargas\Manuales\Contabilidad\Contabilidad_SAY_IntegracionDatosAjusteSubsidio_May2020.docx")
        Catch ex As Exception
        End Try
    End Sub
End Class