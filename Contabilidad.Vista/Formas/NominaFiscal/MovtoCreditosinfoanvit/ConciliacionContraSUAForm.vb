Imports System.Windows.Forms
Imports Framework.Negocios
Imports DevExpress.XtraPrinting
Imports Tools
Imports Stimulsoft.Report
Imports System.Data.OleDb
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Drawing

Public Class ConciliacionContraSUAForm
    Private lstModificados As List(Of String) = New List(Of String)
    Dim objBU As New Negocios.ConciliacionContraSUABU
    Dim colaboradorIds As String = String.Empty
    Dim registrosEdicion As Integer = 0
    Dim permisoEditar As Boolean = False

    Private Sub ConciliaciónContraSUAForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Dim df As Int16 = 0
        permisosBotones()
        llenarComboBimestre()
        llenarComboPatrones()
        numAnio.Value = Now.Year

        'Permisos menú 
        ConciliaciónSUAArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("CCS", "MODIF_WORD_DATOS")
        ConciliaciónSUAPropuestaToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("CCS", "PROPUESTA_CONCILIACION")

    End Sub

    Private Sub permisosBotones()
        If rdoAcumulado.Checked Then
            pnlLayout.Enabled = False
            pnlImportar.Enabled = False
            pnlAutorizar.Enabled = False
        Else
            If PermisosUsuarioBU.ConsultarPermiso("CCS", "AUTORIZAR_MES") Then
                pnlAutorizar.Visible = True
                pnlAutorizar.Enabled = False
            Else
                pnlAutorizar.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("CCS", "IMPORTAR") Then
                pnlImportar.Visible = True
                pnlImportar.Enabled = False
                pnlLayout.Visible = True
                pnlLayout.Enabled = False
            Else
                pnlImportar.Visible = False
                pnlLayout.Visible = False
            End If
        End If

        If PermisosUsuarioBU.ConsultarPermiso("CCS", "EDITAR_GRID") Then
            permisoEditar = True
            pnlGuardar.Enabled = True
        Else
            permisoEditar = False
            pnlGuardar.Visible = False
            lblColorEdicion.Visible = False
            lblEnEdicion.Visible = False
        End If

    End Sub

    Private Sub btnSeleccionarColaborador_Click(sender As Object, e As EventArgs) Handles btnSeleccionarColaborador.Click
        If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de seleccionar un Patrón")
        Else
            Dim objForm As New SeleccionarColaboradoresForm
            If Not CheckForm(objForm) Then
                objForm.colaboradorIds = colaboradorIds
                objForm.patronId = cmbPatron.SelectedValue
                objForm.ShowDialog()
                colaboradorIds = String.Empty
                colaboradorIds = objForm.colaboradorIds

                If colaboradorIds <> "" Then
                    pnlColaboradoresCargados.Visible = True
                Else
                    pnlColaboradoresCargados.Visible = False
                End If
            End If
        End If
    End Sub

#Region "METODOS"

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub llenarComboBimestre()
        Dim dtBimestres As New DataTable
        Try
            dtBimestres = objBU.listarBimestre()

            If Not dtBimestres Is Nothing AndAlso dtBimestres.Rows.Count > 0 Then
                cmbBimestre.DataSource = dtBimestres
                cmbBimestre.ValueMember = "numerobimestre"
                cmbBimestre.DisplayMember = "bimestre"
            Else
                cmbBimestre.DataSource = Nothing
            End If
        Catch ex As Exception

        End Try


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

    Private Sub btnImportarDatos_Click(sender As Object, e As EventArgs) Handles btnImportarDatos.Click
        If rdoBimestre.Checked Then
            If cmbBimestre.Items.Count > 1 And cmbBimestre.SelectedIndex = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar el bimestre.")
            Else
                importarLayout()
            End If
        End If
    End Sub

    Private Sub importarLayout()
        Dim dt As DataTable
        Dim objMensajeConf As New Tools.ConfirmarForm
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        objMensajeConf.mensaje = "Al importar el archivo excel se realizará la actualizacion de la información del bimestre seleccionado, ¿Está seguro de continuar?"
        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                With myFileDialog
                    .Filter = "Excel Files |*.xlsx"
                    .Title = "Open File"
                    .ShowDialog()
                End With
                If myFileDialog.FileName.ToString <> "" Then
                    Dim resultado As String = String.Empty
                    Dim ExcelFile As String = myFileDialog.FileName.ToString
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

                        Dim vXmlCeldas As XElement = New XElement("Colaboradores")
                        Dim contador As Integer = 0
                        Dim colid As Integer = 0
                        Dim numerocredito As String = ""
                        Dim tipodescuento As String = "0"
                        Dim valordescuentosua As String = "0"
                        Dim amortizacionsua As String = "0"

                        For Each Row As DataRow In dt.Rows
                            If contador >= 2 Then
                                colid = Row.Item(0)
                                numerocredito = Row.Item(4)
                                tipodescuento = Row.Item(5)
                                valordescuentosua = Row.Item(6)
                                amortizacionsua = Row.Item(7)

                                'columnas importar
                                '0   colaboradorid
                                '1   codigoempleado
                                '2   colaborador
                                '3   rfc
                                '4   numerocredito
                                '5   tipodescuento
                                '6   valordescuentosua
                                '7   amortizacionsua

                                'XML!
                                Dim vNodo As XElement = New XElement("Colaborador")
                                vNodo.Add(New XAttribute("colaboradorid", colid))
                                vNodo.Add(New XAttribute("numerocredito", numerocredito))
                                vNodo.Add(New XAttribute("tipodescuento", tipodescuento))
                                vNodo.Add(New XAttribute("valordescuentosua", valordescuentosua))
                                vNodo.Add(New XAttribute("amortizacionsua", amortizacionsua))
                                vXmlCeldas.Add(vNodo)
                            End If
                            contador += 1
                        Next

                        resultado = objBU.importarLayoutSUA(vXmlCeldas.ToString(), cmbPatron.SelectedValue, numAnio.Value, cmbBimestre.SelectedValue)

                        If resultado = "EXITO" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los dato se han actualizados correctamente")
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar los datos: " & resultado)
                        End If

                    Catch ex As Exception
                        MsgBox("El nombre de la hoja de calculo debe ser Sheet", MsgBoxStyle.Information, "Informacion")
                    Finally
                        conn.Close()
                    End Try
                End If
                btnMostrar.PerformClick()
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurió un error al importar el archivo: " & Environment.NewLine & ex.Message)
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        If registrosEdicion = 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderán, ¿Desea continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If continuar() Then
            limpiarGrid()
            permisosBotones()
            cmbPatron.SelectedIndex = 0
            cmbBimestre.SelectedIndex = 0
            numAnio.Value = Now.Year
            pnlColaboradoresCargados.Visible = False
            colaboradorIds = String.Empty

        End If
    End Sub

    Private Sub limpiarGrid()
        grdDatosConciliacion.DataSource = Nothing
        bgvConciliacionSUA.Columns.Clear()
        bgvConciliacionSUA.Bands.Clear()
        registrosEdicion = 0
        lstModificados.Clear()
        lblFechaActualizacion.Text = "-"
    End Sub

    Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            If cmbPatron.Items.Count > 1 And cmbPatron.SelectedIndex = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de seleccionar un Patrón")
            Else
                If continuar() Then
                    Me.Cursor = Cursors.WaitCursor
                    limpiarGrid()
                    permisosBotones()
                    Dim patronid As Integer = cmbPatron.SelectedValue
                    Dim anio As Integer = numAnio.Value

                    If rdoAcumulado.Checked Then
                        mostrarReporteAcumulado(patronid, anio)
                    Else
                        If cmbBimestre.Items.Count > 1 And cmbBimestre.SelectedIndex = 0 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de seleccionar el bimestre a consultar.")
                        Else
                            Dim bimestre As Integer = cmbBimestre.SelectedValue
                            habilitarBotones()
                            mostrarReporteBimestre(patronid, anio, bimestre)
                        End If
                    End If

                    lblFechaActualizacion.Text = Now
                End If
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al consultar el reporte: " & ex.ToString)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function continuar() As Boolean
        If registrosEdicion > 0 Then
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Todos los cambios no guardados se perderán ¿Está seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub mostrarReporteAcumulado(ByVal patronid As Integer, ByVal anio As Integer)
        Dim dtAcumulado As New DataTable
        dtAcumulado = objBU.obtenerReporteAcumulado(patronid, anio, colaboradorIds, txtNombre.Text.Trim)

        If Not dtAcumulado Is Nothing AndAlso dtAcumulado.Rows.Count > 0 Then
            grdDatosConciliacion.DataSource = dtAcumulado
            disenioGridBands("ACUMULADO")
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existe información para mostrar.")
        End If
    End Sub

    Private Sub mostrarReporteBimestre(ByVal patronid As Integer, ByVal anio As Integer, ByVal bimestre As Integer)
        Dim dtBimestre As New DataTable
        dtBimestre = objBU.obtenerReporteBimestre(patronid, anio, bimestre, colaboradorIds, txtNombre.Text.Trim)

        If Not dtBimestre Is Nothing AndAlso dtBimestre.Rows.Count > 0 Then
            grdDatosConciliacion.DataSource = dtBimestre
            disenioGridBands("BIMESTRE")
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No existe información para mostrar.")
        End If
    End Sub

    Private Sub disenioGridBands(ByVal tipoReporte As String)
        bgvConciliacionSUA.IndicatorWidth = 40
        bgvConciliacionSUA.OptionsView.ColumnAutoWidth = False
        Dim dtColumnasEncabezados As New DataTable
        dtColumnasEncabezados = objBU.obtenerColumnasEncabezadosReporte(tipoReporte)
        bgvConciliacionSUA.OptionsView.ShowFooter = True

        If Not dtColumnasEncabezados Is Nothing AndAlso dtColumnasEncabezados.Rows.Count > 0 Then
            Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
            Dim bandChild As DevExpress.XtraGrid.Views.BandedGrid.GridBand
            Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
            Dim ListaBandaPadre = dtColumnasEncabezados.AsEnumerable().Select(Function(x) x.Item("cser_bandapadre")).Distinct.ToList
            Dim ListaBandaHija = dtColumnasEncabezados.AsEnumerable().Select(Function(x) x.Item("cser_bandahija")).Distinct.ToList
            Dim BandaAsignar As DevExpress.XtraGrid.Views.BandedGrid.GridBand
            Dim blnTieneBandasHijas As Boolean = True

            If ListaBandaHija.Count = 1 And ListaBandaHija(0).trim = "" Then
                blnTieneBandasHijas = False
            End If

            For Each item As String In ListaBandaPadre
                Dim listaNombrePadre = dtColumnasEncabezados.AsEnumerable().Where(Function(x) x.Item("cser_bandapadre") = item.Trim()).Select(Function(y) y.Item("cser_nombrebandapadre")).Distinct.ToList

                band = bgvConciliacionSUA.Bands.Add
                band.Name = item.ToString
                band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                band.Caption = listaNombrePadre(0)

                If Not blnTieneBandasHijas Then
                    listBands.Add(band)
                Else
                    Dim listaHijas = dtColumnasEncabezados.AsEnumerable().Where(Function(x) x.Item("cser_bandapadre") = item.Trim()).Select(Function(y) y.Item("cser_bandahija")).Distinct.ToList

                    For Each itemhija As String In listaHijas
                        Dim listaNombre = dtColumnasEncabezados.AsEnumerable().Where(Function(x) x.Item("cser_bandahija") = itemhija.Trim()).Select(Function(y) y.Item("cser_nombrebandahija")).Distinct.ToList

                        bandChild = band.Children.Add()
                        bandChild.Name = itemhija.ToString()
                        If itemhija.ToString().ToUpper.Contains("BIMESTRE") Then
                            bandChild.Caption = cmbBimestre.Text
                        Else
                            bandChild.Caption = listaNombre(0)
                        End If
                        bandChild.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        listBands.Add(bandChild)

                    Next

                End If

            Next

            For Each row As DataRow In dtColumnasEncabezados.Rows
                Dim columnaBanda As String = String.Empty

                If blnTieneBandasHijas Then
                    columnaBanda = "cser_bandahija"
                Else
                    columnaBanda = "cser_bandapadre"
                End If

                BandaAsignar = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Name = row.Item(columnaBanda))

                Dim listaVisible = dtColumnasEncabezados.AsEnumerable().Where(Function(x) x.Item("cser_columna") = row.Item("cser_columna").ToString()).Select(Function(y) y.Item("cser_visible")).Distinct.ToList

                bgvConciliacionSUA.Columns.AddField(row.Item("cser_columna").ToString())
                bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString()).OwnerBand = BandaAsignar
                bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString()).Visible = CBool(listaVisible(0))
                bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Caption = row.Item("cser_nombrecolumna")
                bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Width = CInt(row.Item("cser_anchocolumna"))
                If permisoEditar Then
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).OptionsColumn.AllowEdit = CBool(row.Item("cser_columnaeditable"))
                Else
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).OptionsColumn.AllowEdit = False
                End If


                If row.Item("cser_columna") = "codigoempleado" Then
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Caption = "Código" & Environment.NewLine & "Empleado"
                ElseIf row.Item("cser_columna").contains("alta") Then
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Caption = "Fecha" & Environment.NewLine & "de Alta"
                ElseIf row.Item("cser_columna").contains("baja") Then
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Caption = "Fecha" & Environment.NewLine & "de Baja"
                ElseIf row.Item("cser_columna") = "tipodescuento" Then
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Caption = "Tipo de" & Environment.NewLine & "Descuento"
                ElseIf row.Item("cser_columna") = "diferenciafactores" Then
                    bgvConciliacionSUA.Columns.ColumnByFieldName(row.Item("cser_columna").ToString).Caption = "Diferencia" & Environment.NewLine & "en Factores"
                End If

            Next

            bgvConciliacionSUA.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            bgvConciliacionSUA.ColumnPanelRowHeight = 40
            bgvConciliacionSUA.BandPanelRowHeight = 25

            Dim itemSum As DevExpress.XtraGrid.GridGroupSummaryItem
            Dim blnSumatoria As Boolean = False

            For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvConciliacionSUA.Columns
                Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                blnSumatoria = False

                If Col.FieldName = "diferenciafactores" Or Col.FieldName.ToUpper.Contains("VALORDESCUENTO") Then
                    Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    Col.DisplayFormat.FormatString = "{0:N4}"
                    Col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N4}")
                    blnSumatoria = True
                ElseIf Col.ColumnType() = GetType(Double) Then
                    Col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    Col.DisplayFormat.FormatString = "{0:N2}"
                    Col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N2}")
                    blnSumatoria = True
                End If

                If blnSumatoria = True Then
                    itemSum = New DevExpress.XtraGrid.GridGroupSummaryItem
                    itemSum.FieldName = Col.FieldName
                    itemSum.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    itemSum.DisplayFormat = Col.DisplayFormat.FormatString 'revisar
                    bgvConciliacionSUA.GroupSummary.Add(itemSum)
                End If

            Next

            Tools.DiseñoGrid.AlternarColorEnFilas(bgvConciliacionSUA)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se pudieron obtener los encabezados para el reporte.")
        End If

    End Sub

    Private Sub bgvConciliacionSUA_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvConciliacionSUA.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub imprimirReporte()
        Dim dtAcumulado As New DataTable
        Dim dtDatosEmpresa As New DataTable
        Dim cveReporte As String = String.Empty

        Dim dtBimestre As New DataTable
        Dim empresa As String = String.Empty
        Dim bimestre As String = String.Empty

        Dim mensaje As String = String.Empty
        Dim dtBimestres As New DataTable

        If rdoAcumulado.Checked Then
            dtAcumulado = objBU.obtenerReporteAcumulado(cmbPatron.SelectedValue, numAnio.Value, colaboradorIds, txtNombre.Text.Trim)
            dtDatosEmpresa = objBU.obtenerEncabezadosReporteImprimr(cmbPatron.SelectedValue, 0, numAnio.Value, "A")
            cveReporte = "REP_CISUA_ACUMULADO"
        ElseIf rdoBimestre.Checked Then
            dtAcumulado = objBU.obtenerReporteBimestre(cmbPatron.SelectedValue, numAnio.Value, cmbBimestre.SelectedValue, colaboradorIds, txtNombre.Text.Trim)
            dtDatosEmpresa = objBU.obtenerEncabezadosReporteImprimr(cmbPatron.SelectedValue, cmbBimestre.SelectedValue, numAnio.Value, "B")
            cveReporte = "REP_CISUA_BIMESTRE"
        End If

        If dtAcumulado.Rows.Count > 0 Then
            If dtDatosEmpresa.Rows.Count > 0 Then
                empresa = dtDatosEmpresa.Rows(0).Item("empresa")
                bimestre = dtDatosEmpresa.Rows(0).Item("bimestre")
            End If

            Dim objRepBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            EntidadReporte = objRepBU.LeerReporteporClave(cveReporte)

            Dim archivo As String
            archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As StiReport = New StiReport()
            reporte.Load(archivo)
            reporte.Compile()
            reporte("Empresa") = empresa
            reporte("periodoAl") = bimestre
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.Dictionary.Clear()
            reporte.RegData(dtAcumulado)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay información para imprimir.")
        End If

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If cmbPatron.SelectedValue > 0 Then
                If rdoBimestre.Checked AndAlso cmbBimestre.SelectedValue <= 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar un bimestre")
                Else
                    Me.Cursor = Cursors.WaitCursor
                    imprimirReporte()
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario seleccionar un patrón ")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al imprimir el reporte: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLayout_Click(sender As Object, e As EventArgs) Handles btnLayout.Click
        If rdoBimestre.Checked Then
            If bgvConciliacionSUA.RowCount > 0 Then
                exportarLayout()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario dar clic en el botón mostrar para obtener la información a exportar.")
            End If
        End If
    End Sub

    Private Sub exportarLayout()
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
                    Me.Cursor = Cursors.WaitCursor
                    For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvConciliacionSUA.Columns
                        If Col.FieldName = "colaboradorid" Or Col.FieldName = "codigoempleado" Or Col.FieldName = "colaborador" Or Col.FieldName = "rfc" _
                        Or Col.FieldName = "numerocredito" Or Col.FieldName = "tipodescuento" Or Col.FieldName = "valordescuentosua" Or Col.FieldName = "amortizacionsua" Then
                            Col.Visible = True
                            Col.Width = 200

                            Select Case Col.FieldName
                                Case "valordescuentosua"
                                    Col.Caption = "Valor Descuento SUA"
                                Case "amortizacionsua"
                                    Col.Caption = "Valor Amortizacion SUA"
                            End Select
                        Else
                            Col.Visible = False
                        End If
                    Next

                    bgvConciliacionSUA.OptionsView.ShowFooter = False
                    bgvConciliacionSUA.ExportToXlsx(.SelectedPath + "\LayoutSUA_" + fecha_hora + ".xlsx")
                    bgvConciliacionSUA.Columns.Clear()
                    limpiarGrid()
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente.")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\LayoutSUA_" + fecha_hora + ".xlsx")
                    btnMostrar.PerformClick()
                End If
            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al exportar el layout: " & Environment.NewLine & ex.ToString)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub bgvConciliacionSUA_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles bgvConciliacionSUA.CellValueChanged
        If e.Column.FieldName = "numerocredito" Or e.Column.FieldName = "tipodescuento" Or e.Column.FieldName = "valordescuentosua" Or e.Column.FieldName = "amortizacionsua" Or e.Column.FieldName = "observaciones" Then
            'numerocredito   tipodescuento	valordescuentosua	amortizacionsua
            Try
                bgvConciliacionSUA.SetRowCellValue(e.RowHandle, "editado", True)
                If lstModificados.Contains(e.RowHandle.ToString & "," & e.Column.VisibleIndex) = False Then
                    lstModificados.Add(e.RowHandle.ToString & "," & e.Column.VisibleIndex)
                End If
                registrosEdicion += 1
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            End Try
        End If
    End Sub

    Private Sub bgvConciliacionSUA_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles bgvConciliacionSUA.RowCellStyle
        If lstModificados.Contains(e.RowHandle.ToString & "," & e.Column.VisibleIndex) = True Then
            e.Appearance.BackColor = lblColorEdicion.BackColor
            e.Appearance.ForeColor = Color.White
            e.Appearance.FontStyleDelta = FontStyle.Bold
        End If

        'diferenciafactores diferenciaamortizaciones
        If e.Column.FieldName.ToUpper.Contains("BIMESTRE") Or e.Column.FieldName = "diferenciafactores" Or e.Column.FieldName = "diferenciaamortizaciones" Or e.Column.FieldName = "total" Then
            If Not IsDBNull(bgvConciliacionSUA.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                If CDbl(bgvConciliacionSUA.GetRowCellValue(e.RowHandle, e.Column.FieldName)) < 0 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
        End If


    End Sub

    Private Sub ConciliacionContraSUAForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If continuar() Then
            Me.Dispose()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If bgvConciliacionSUA.RowCount > 0 Then
            If registrosEdicion > 0 Then
                If rdoAcumulado.Checked Then
                    actualizarDatosAcumulado()
                Else
                    actualizarDatosBimestre()
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe haber al menos un registro en edición para guardar la información.")
            End If
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay datos para guardar.")
        End If
    End Sub

    Private Sub actualizarDatosBimestre()
        Dim objMensajeConf As New Tools.ConfirmarForm
        objMensajeConf.mensaje = "Esta acción modificará los datos existentes, ¿Está seguro de continuar?"
        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim vXmlCeldas As XElement = New XElement("Conciliaciones")
                Dim resultado As String = String.Empty

                For index As Integer = 0 To bgvConciliacionSUA.DataRowCount - 1 Step 1
                    If Not IsDBNull(bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "editado")) Then
                        If bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "editado") Then
                            Dim vNodo As XElement = New XElement("Conciliacion")
                            vNodo.Add(New XAttribute("conciliacionid", bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "conciliacionid")))
                            vNodo.Add(New XAttribute("valordescuentosua", bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "valordescuentosua")))
                            vNodo.Add(New XAttribute("amortizacionsua", bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "amortizacionsua")))
                            vNodo.Add(New XAttribute("observaciones", bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "observaciones")))
                            vXmlCeldas.Add(vNodo)
                        End If
                    End If
                Next

                resultado = objBU.actualizaInformacionBimestre(vXmlCeldas.ToString())

                If resultado = "EXITO" Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se actualizó correctamente la información.")
                    registrosEdicion = 0
                    lstModificados.Clear()
                    btnMostrar.PerformClick()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar la información del bimestre: " & Environment.NewLine & resultado)
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & Environment.NewLine & ex.Message)
                Me.Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub actualizarDatosAcumulado()
        Dim objMensajeConf As New Tools.ConfirmarForm
        objMensajeConf.mensaje = "Esta acción modificará los datos existentes, ¿Está seguro de continuar?"
        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim resultado As String = String.Empty
                Dim vXmlCeldas As XElement = New XElement("Conciliaciones")

                For index As Integer = 0 To bgvConciliacionSUA.DataRowCount - 1 Step 1
                    If Not IsDBNull(bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "editado")) Then
                        If bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "editado") Then
                            Dim vNodo As XElement = New XElement("Conciliacion")
                            vNodo.Add(New XAttribute("colaboradorid", bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "colaboradorid")))
                            vNodo.Add(New XAttribute("observaciones", bgvConciliacionSUA.GetRowCellValue(bgvConciliacionSUA.GetVisibleRowHandle(index), "observaciones")))
                            vNodo.Add(New XAttribute("patronid", cmbPatron.SelectedValue))
                            vNodo.Add(New XAttribute("anio", numAnio.Value))
                            vXmlCeldas.Add(vNodo)
                        End If
                    End If
                Next

                resultado = objBU.actualizaInformacionAcumulado(vXmlCeldas.ToString())

                If resultado = "EXITO" Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se actualizó correctamente la información.")
                    registrosEdicion = 0
                    lstModificados.Clear()
                    btnMostrar.PerformClick()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar las observaciones del acumulado: " & Environment.NewLine & resultado)
                End If

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & Environment.NewLine & ex.Message)
                Me.Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        If bgvConciliacionSUA.RowCount > 0 Then
            Dim resultado As String = String.Empty
            Try
                If continuar() Then
                    Dim objMensajeConf As New Tools.ConfirmarForm
                    objMensajeConf.mensaje = "Una vez autorizado el bimestre no se podrán hacer modificaciones ¿Está seguro de continuar?"
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        resultado = objBU.autorizarBimestre(cmbPatron.SelectedValue, numAnio.Value, cmbBimestre.SelectedValue)

                        If resultado = "EXITO" Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se autorizó correctamente el bimestre.")
                            btnMostrar.PerformClick()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al autorizar el bimestre: " & resultado)
                        End If
                    End If
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al autorizar el bimestre: " & ex.Message)
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub rdoBimestre_CheckedChanged(sender As Object, e As EventArgs) Handles rdoBimestre.CheckedChanged, rdoAcumulado.CheckedChanged
        limpiarGrid()

        If rdoAcumulado.Checked Then
            pnlLayout.Enabled = False
            pnlImportar.Enabled = False
            pnlAutorizar.Enabled = False
        Else
            permisosBotones()
        End If
    End Sub

    Private Sub habilitarBotones()
        Dim patronid As Integer = cmbPatron.SelectedValue
        Dim bimestre As Integer = cmbBimestre.SelectedValue
        Dim anio As Integer = numAnio.Value
        Dim autorizado As Boolean = objBU.validaEstatusAutorizado(patronid, anio, bimestre)

        pnlLayout.Enabled = Not autorizado
        pnlImportar.Enabled = Not autorizado
        pnlAutorizar.Enabled = Not autorizado
        pnlGuardar.Enabled = Not autorizado

        If permisoEditar And autorizado Then
            permisoEditar = False
        End If
    End Sub

    Private Sub cmbs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPatron.SelectedIndexChanged, cmbBimestre.SelectedIndexChanged
        limpiarGrid()
        permisosBotones()
    End Sub

    Private Sub numAnio_ValueChanged(sender As Object, e As EventArgs) Handles numAnio.ValueChanged
        limpiarGrid()
        permisosBotones()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaConciliaciónSUAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaConciliaciónSUAToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_ConciliacionSUA_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_ConciliacionSUA_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConciliaciónSUAArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConciliaciónSUAArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_ConciliacionSUA_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_ConciliacionSUA_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ConciliaciónSUAPropuestaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConciliaciónSUAPropuestaToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "Propuesta_Pantallas_Infonavit.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\Propuesta_Pantallas_Infonavit.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        If bgvConciliacionSUA.DataRowCount > 0 Then
            Try
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                If rdoAcumulado.Checked Then
                    Tools.Excel.ExportarExcel(bgvConciliacionSUA, "Reporte_Acumulado_ConciliacionSUA_" & fecha_hora)
                Else
                    Tools.Excel.ExportarExcel(bgvConciliacionSUA, "Reporte_" & cmbBimestre.Text & "_ConciliacionSUA_" & fecha_hora)
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al exportar: " & ex.Message)
            End Try
        End If
    End Sub



#End Region
End Class