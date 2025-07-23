Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing
Imports System.Windows.Forms
Imports Tools
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data

Public Class TarjetaAlmacenForm
    Dim PermisoValidar As Boolean = False
    Dim filtroProductos As String = String.Empty
    Dim registrosEdicion As Integer = 0
    Dim listInicial As New List(Of String)
    Dim dtConfigPorcentaje As DataTable

    Private Sub TarjetaAlmacenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        PermisoValidar = PermisosUsuarioBU.ConsultarPermiso("CONTA_TARJETA_ALMACEN", "CONT_VAL_CVENTA")
        pnlGuardar.Visible = PermisoValidar
        grdProductos.DataSource = listInicial
        dtConfigPorcentaje = New DataTable
        dtConfigPorcentaje = Nothing

        cargarEmpresas()
    End Sub

    Private Sub cmbEmpresa_DropDownClosed(sender As Object, e As EventArgs) Handles cmbEmpresa.DropDownClosed
        limpiarDatos()
        cargarAnios()
        llenarCombosMeses()
    End Sub


    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        If Not cmbEmpresa.DataSource Is Nothing Then
            limpiarDatos()
            cargarAnios()
            llenarCombosMeses()
        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If validarFiltros() Then
            If rdoTarjeta.Checked = True Then
                If registrosEdicion <= 0 Then
                    cargarReporteTarjeta()
                Else
                    Dim objMensajeConf As New Tools.ConfirmarForm
                    objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
                    If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                        cargarReporteTarjeta()
                    End If
                End If
            ElseIf rdoInventario.Checked Then
                cargarInventario()
            End If

            lblFechaActualizacion.Text = Now
        End If
    End Sub

    Private Function validarFiltros() As Boolean
        If Not cmbEmpresa.SelectedIndex > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir una empresa a consultar.")
            Return False
        End If

        If Not cmbMesInicial.SelectedIndex > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir el mes inicial a consultar.")
            Return False
        End If

        If Not cmbMesFinal.SelectedIndex > 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Favor de elegir el mes final a consultar.")
            Return False
        End If

        Return True
    End Function

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        ocultarFiltros()
    End Sub

    Private Sub ocultarFiltros()
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarDatos()

        cmbEmpresa.SelectedIndex = 0
        cargarAnios()
        llenarCombosMeses()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If registrosEdicion <= 0 Then
            Me.Close()
        Else
            Dim objMensajeConf As New Tools.ConfirmarForm
            objMensajeConf.mensaje = "Existen registros en edición, ¿Esta seguro de continuar?"
            If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If rdoTarjeta.Checked = True Then
            imprimirReporteTarjeta()
        ElseIf rdoInventario.Checked = True Then
            imprimirReporteInventario()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If rdoTarjeta.Checked = True Then
            exportarTarjeta("\Tarjeta_Almacen")
        ElseIf rdoInventario.Checked = True Then
            exportarTarjeta("\Inventario")
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If rdoTarjeta.Checked = True Then
            validarPorcentaje()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Esta funcionalidad solamente sirve para la opción Tarjeta.")
        End If
    End Sub


#Region "Funciones"

    Private Sub limpiarDatos()
        limpiarGrid()
        grdProductos.DataSource = listInicial
        registrosEdicion = 0
    End Sub

    Private Sub cargarEmpresas()
        Dim objBu As New Contabilidad.Negocios.TarjetaAlmacenBU
        Dim dtEmpresa As New DataTable
        dtEmpresa = objBu.consultaEmpresas()
        If dtEmpresa.Rows.Count > 0 Then
            Dim dtRow As DataRow = dtEmpresa.NewRow
            dtRow("Id") = 0
            dtRow("Empresa") = ""
            dtEmpresa.Rows.InsertAt(dtRow, 0)
            cmbEmpresa.DataSource = dtEmpresa
            cmbEmpresa.DisplayMember = "Empresa"
            cmbEmpresa.ValueMember = "Id"
            cmbEmpresa.SelectedIndex = 0
        End If
    End Sub

    Private Sub cargarAnios()
        Dim objMsjError As New Tools.ErroresForm
        Dim objBU As New Negocios.TarjetaAlmacenBU
        Dim dtListado As New DataTable
        cmbAnio.DataSource = Nothing
        Try
            If Not cmbEmpresa Is Nothing Then
                If cmbEmpresa.SelectedIndex <> 0 Then
                    dtListado = objBU.obtenerAniosEmpresa(cmbEmpresa.SelectedValue)
                    If Not dtListado Is Nothing Then
                        If dtListado.Rows.Count > 0 Then
                            cmbAnio.DataSource = dtListado
                            cmbAnio.DisplayMember = "Anios"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            objMsjError.mensaje = ex.Message
            objMsjError.ShowDialog()
        End Try

    End Sub

    Private Sub llenarCombosMeses()

        Dim objBU As New Negocios.DatosSPEMensualBU
        Dim dtLista As New DataTable
        Dim dtListaFin As New DataTable

        dtLista = objBU.consultaListaMeses()
        dtListaFin = dtLista.Copy

        If Not dtLista Is Nothing AndAlso dtLista.Rows.Count > 0 Then
            cmbMesInicial.DataSource = dtLista
            cmbMesInicial.ValueMember = "NumMes"
            cmbMesInicial.DisplayMember = "Descripcion"

            cmbMesFinal.DataSource = dtListaFin
            cmbMesFinal.ValueMember = "NumMes"
            cmbMesFinal.DisplayMember = "Descripcion"
        Else
            cmbMesInicial.DataSource = Nothing
            cmbMesFinal.DataSource = Nothing
        End If

    End Sub

    Private Sub cargarReporteTarjeta()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dtDatos As New DataTable
            Dim objBU As New Contabilidad.Negocios.TarjetaAlmacenBU
            limpiarGrid()
            registrosEdicion = 0

            Dim empresaId As Integer
            Dim anio As Integer
            Dim mesInicio As Integer
            Dim mesFin As Integer

            empresaId = cmbEmpresa.SelectedValue
            anio = CInt(cmbAnio.Text)
            mesInicio = cmbMesInicial.SelectedValue
            mesFin = cmbMesFinal.SelectedValue
            obtenerFiltros()

            Try
                dtConfigPorcentaje = New DataTable
                dtConfigPorcentaje = objBU.obtenerConfigPorcentaje(empresaId)
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la configuración del procentaje de costo de venta para la empresa seleccionada.")
            End Try

            dtDatos = objBU.obtenerTarjetaAlmacen(empresaId, anio, mesInicio, mesFin, filtroProductos)

            If Not IsNothing(dtDatos) AndAlso dtDatos.Rows.Count > 0 Then
                limpiarGrid()

                diseñoGridTarjeta()
                GridTarjeta.DataSource = dtDatos
                ocultarFiltros()
            Else
                Dim objadvertencias As New Tools.AdvertenciaForm
                objadvertencias.mensaje = "No existe información para mostrar."
                objadvertencias.ShowDialog()
            End If

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cargarInventario()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim dtDatos As New DataTable
            Dim objBU As New Contabilidad.Negocios.TarjetaAlmacenBU
            limpiarGrid()
            registrosEdicion = 0

            Dim empresaId As Integer
            Dim anio As Integer
            Dim mesInicio As Integer
            Dim mesFin As Integer

            empresaId = cmbEmpresa.SelectedValue
            anio = CInt(cmbAnio.Text)
            mesInicio = cmbMesInicial.SelectedValue
            mesFin = cmbMesFinal.SelectedValue
            obtenerFiltros()

            dtDatos = objBU.obtenerInventario(empresaId, anio, mesInicio, mesFin, filtroProductos)

            If Not IsNothing(dtDatos) AndAlso dtDatos.Rows.Count > 0 Then
                disenioGridInventario()
                GridTarjeta.DataSource = dtDatos
                ocultarFiltros()
            Else
                Dim objadvertencias As New Tools.AdvertenciaForm
                objadvertencias.mensaje = "No existe información para mostrar."
                objadvertencias.ShowDialog()
            End If

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub validarPorcentaje()

        If grdTarjetaAlmacen.RowCount > 0 Then
            If registrosEdicion > 0 Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "Ésta acción ya no podrá ser revertida, ¿Está seguro de continuar?"
                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        Dim objBu As New Negocios.TarjetaAlmacenBU
                        Dim totalEditar As Integer = 0
                        Dim totalEditados As Integer = 0

                        For index As Integer = 0 To grdTarjetaAlmacen.DataRowCount - 1 Step 1
                            If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(grdTarjetaAlmacen.GetVisibleRowHandle(index), "chaceptar")) AndAlso CBool(grdTarjetaAlmacen.GetRowCellValue(grdTarjetaAlmacen.GetVisibleRowHandle(index), "chaceptar")) = True Then
                                Dim msjResult As String = String.Empty
                                Dim tarjetaId As Integer = 0

                                tarjetaId = grdTarjetaAlmacen.GetRowCellValue(grdTarjetaAlmacen.GetVisibleRowHandle(index), "tarjetaalmacenid")
                                totalEditar += 1
                                msjResult = objBu.validarPorcentajePrecioVenta(tarjetaId)

                                If msjResult = "EXITO" Then
                                    totalEditados += 1
                                End If

                            End If
                        Next

                        If totalEditar = totalEditados Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se actualizaron correctamente los datos.")
                            cargarReporteTarjeta()
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al actualizar la información")
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

    Public Sub exportarTarjeta(ByVal tipoReporte As String)
        If grdTarjetaAlmacen.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim fechasReporte As String = String.Empty

            Try

                If cmbMesInicial.SelectedValue = cmbMesFinal.SelectedValue Then
                    fechasReporte = "_" + cmbMesInicial.Text + "_" + cmbAnio.Text + "_"
                Else
                    fechasReporte = "_" + cmbMesInicial.Text + "_" + cmbMesFinal.Text + "_" + cmbAnio.Text + "_"
                End If

                nombreReporte = tipoReporte + fechasReporte

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If grdTarjetaAlmacen.GroupCount > 0 Then
                            grdTarjetaAlmacen.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            If rdoTarjeta.Checked = True Then
                                grdTarjetaAlmacen.Columns("chaceptar").Visible = False
                            End If

                            GridTarjeta.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        If rdoTarjeta.Checked = True Then
                            cargarReporteTarjeta()
                        End If

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

    Private Sub imprimirReporteTarjeta()
        If grdTarjetaAlmacen.RowCount > 0 Then
            Dim TarjetaAlmacen As New DataSet("TarjetaAlmacen")
            Dim dtDatosTarjeta As New DataTable()
            Dim dtProductos As New DataTable()
            Dim strFechas As String = String.Empty

            Try
                Me.Cursor = Cursors.WaitCursor

                With dtProductos
                    .Columns.Add("productoestiloid")
                    .Columns.Add("descripcioncompleta")
                End With

                Dim vw = New DataView()
                vw = grdTarjetaAlmacen.DataSource
                dtDatosTarjeta = vw.ToTable()

                For index As Integer = dtDatosTarjeta.Rows.Count - 1 To 0 Step -1
                    If dtDatosTarjeta.Rows(index).Item("tipofila").ToString.Trim <> "" Then
                        dtDatosTarjeta.Rows.RemoveAt(index)
                    End If
                Next

                Dim vista = New DataView(dtDatosTarjeta)
                dtProductos = vista.ToTable(True, "productoestiloid", "DescripcionCompleta")

                dtDatosTarjeta.TableName = "dtDatosTarjeta"
                dtProductos.TableName = "dtProductos"

                TarjetaAlmacen.Tables.Add(dtDatosTarjeta)
                TarjetaAlmacen.Tables.Add(dtProductos)

                If cmbMesInicial.SelectedValue = cmbMesFinal.SelectedValue Then
                    strFechas = cmbMesInicial.Text + " DE " + cmbAnio.Text
                Else
                    strFechas = "DE " + cmbMesInicial.Text + " A " + cmbMesFinal.Text + " DE " + cmbAnio.Text
                End If

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("REP_TARJETA_ALMACEN")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte("Empresa") = cmbEmpresa.Text
                reporte("Fechas") = strFechas
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.RegData(TarjetaAlmacen)
                reporte.Render()
                reporte.Show()

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub imprimirReporteInventario()
        If grdTarjetaAlmacen.RowCount > 0 Then
            Dim DatosInventario As New DataSet("dsDatosInventario")
            Dim dtInventario As New DataTable()
            Dim strFechas As String = String.Empty

            Try
                Me.Cursor = Cursors.WaitCursor

                Dim vw = New DataView()
                vw = grdTarjetaAlmacen.DataSource

                dtInventario = vw.ToTable()
                DatosInventario.Tables.Add(dtInventario)

                If cmbMesInicial.SelectedValue = cmbMesFinal.SelectedValue Then
                    strFechas = cmbMesInicial.Text + " DE " + cmbAnio.Text
                Else
                    strFechas = "DE " + cmbMesInicial.Text + " A " + cmbMesFinal.Text + " DE " + cmbAnio.Text
                End If

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("REP_INVENTARIO_TARJETAALM")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre
                My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load((archivo + ".mrt"))
                reporte.Compile()
                reporte("Empresa") = cmbEmpresa.Text
                reporte("Fechas") = strFechas
                reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.RegData(DatosInventario)
                reporte.Render()
                reporte.Show()

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

#End Region 'Termina Region Funciones

#Region "Disenio Grid"
    Private Sub diseñoGridTarjeta()
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        grdTarjetaAlmacen.Columns.Clear()
        grdTarjetaAlmacen.Bands.Clear()
        grdTarjetaAlmacen.Appearance.HeaderPanel.Options.UseBackColor = True
        grdTarjetaAlmacen.OptionsView.AllowCellMerge = True
        grdTarjetaAlmacen.OptionsBehavior.Editable = True

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Fixed = Columns.FixedStyle.Left
        band.Caption = ""

        grdTarjetaAlmacen.Columns.AddField("productoestiloid")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("productoestiloid").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("productoestiloid").Visible = False

        grdTarjetaAlmacen.Columns.AddField("tarjetaalmacenid")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("tarjetaalmacenid").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("tarjetaalmacenid").Visible = False

        grdTarjetaAlmacen.Columns.AddField("fueraderango")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fueraderango").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fueraderango").Visible = False

        grdTarjetaAlmacen.Columns.AddField("DescripcionCompleta")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").Caption = "Artículo"

        grdTarjetaAlmacen.Columns.AddField("fechadocumento")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fechadocumento").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fechadocumento").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fechadocumento").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fechadocumento").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("fechadocumento").Caption = "Fecha"

        grdTarjetaAlmacen.Columns.AddField("numdocto")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("numdocto").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("numdocto").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("numdocto").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("numdocto").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("numdocto").Caption = "No. Factura"

        grdTarjetaAlmacen.Columns.AddField("uuid")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("uuid").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("uuid").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("uuid").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("uuid").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("uuid").Caption = "Folio Fiscal"

        grdTarjetaAlmacen.Columns.AddField("razonsocialdocumento")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("razonsocialdocumento").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("razonsocialdocumento").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("razonsocialdocumento").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("razonsocialdocumento").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("razonsocialdocumento").Caption = "Cliente/Proveedor"

        grdTarjetaAlmacen.Columns.AddField("concepto")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("concepto").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("concepto").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("concepto").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("concepto").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("concepto").Caption = "Concepto"

        grdTarjetaAlmacen.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = ""

        grdTarjetaAlmacen.Columns.AddField("claveproducto")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("claveproducto").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("claveproducto").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("claveproducto").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("claveproducto").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("claveproducto").Caption = "Clave Producto"

        grdTarjetaAlmacen.Columns.AddField("clavedescripcion")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("clavedescripcion").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("clavedescripcion").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("clavedescripcion").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("clavedescripcion").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("clavedescripcion").Caption = "Descripción Clave"

        grdTarjetaAlmacen.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Pares"

        grdTarjetaAlmacen.Columns.AddField("paresentrada")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").Caption = "Entradas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("paressalida")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").Caption = "Salidas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("paresexistencia")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").Caption = "Existencia"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("pendientedecompra")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("pendientedecompra").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("pendientedecompra").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("pendientedecompra").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("pendientedecompra").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("pendientedecompra").Caption = "Pendiente Compra"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("pendientedecompra").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom


        grdTarjetaAlmacen.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Costo"

        grdTarjetaAlmacen.Columns.AddField("costounitario")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitario").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitario").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitario").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitario").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitario").Caption = "Unitario"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitario").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("costopromedio")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costopromedio").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costopromedio").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costopromedio").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costopromedio").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costopromedio").Caption = "Promedio"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costopromedio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "En Importes (Costo Historico)"

        grdTarjetaAlmacen.Columns.AddField("importeentrada")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeentrada").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeentrada").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeentrada").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeentrada").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeentrada").Caption = "Entradas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeentrada").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("importesalida")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importesalida").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importesalida").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importesalida").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importesalida").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importesalida").Caption = "Salidas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importesalida").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("importeexistencia")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").Caption = "Existencia"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Bands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Datos Informativos"

        grdTarjetaAlmacen.Columns.AddField("precioventa")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("precioventa").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("precioventa").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("precioventa").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("precioventa").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("precioventa").Caption = "Precio de Venta"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("precioventa").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("importeventa")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventa").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventa").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventa").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventa").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventa").Caption = "Importe Ventas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventa").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Columns.AddField("prccostoventa")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").OptionsColumn.AllowEdit = False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").Caption = "% Costo Venta"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventa").DisplayFormat.FormatString = "{0:P2}"

        grdTarjetaAlmacen.Columns.AddField("chaceptar")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("chaceptar").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("chaceptar").Visible = PermisoValidar
        grdTarjetaAlmacen.Columns.ColumnByFieldName("chaceptar").OptionsColumn.AllowEdit = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("chaceptar").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        grdTarjetaAlmacen.Columns.ColumnByFieldName("chaceptar").Caption = " "

        grdTarjetaAlmacen.Bands.Add(band)

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In grdTarjetaAlmacen.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            For Each childrenBand In gridband.Children
                childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In grdTarjetaAlmacen.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If Col.Caption = "Importe Ventas" OrElse Col.Caption.ToLower.Contains("entrada") OrElse Col.Caption.ToLower.Contains("salida") OrElse Col.Caption.ToLower.Contains("existencia") Then
                Dim strFormato As String = String.Empty
                If Col.Name.Contains("importe") Then
                    strFormato = "{0:N2}"
                Else
                    strFormato = "{0:N0}"
                End If
                Col.DisplayFormat.FormatString = strFormato
            End If

            Select Case Col.FieldName
                Case "DescripcionCompleta"
                    Col.Width = 300'350
                Case "fechadocumento"
                    Col.Width = 80
                Case "numdocto"
                    Col.Width = 80
                Case "uuid"
                    Col.Width = 80'250
                Case "razonsocialdocumento"
                    Col.Width = 90'350
                Case "claveproducto"
                    Col.Width = 120
                Case "chaceptar"
                    Col.Width = 50
                Case Else
                    Col.Width = 90
            End Select
        Next

        grdTarjetaAlmacen.IndicatorWidth = 40

    End Sub

    Private Sub disenioGridInventario()
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand

        grdTarjetaAlmacen.Columns.Clear()
        grdTarjetaAlmacen.Bands.Clear()
        grdTarjetaAlmacen.Appearance.HeaderPanel.Options.UseBackColor = True
        grdTarjetaAlmacen.OptionsView.AllowCellMerge = False
        grdTarjetaAlmacen.OptionsBehavior.Editable = False
        grdTarjetaAlmacen.OptionsView.ShowFooter = True
        DiseñoGrid.DiseñoBaseGrid(grdTarjetaAlmacen)
        DiseñoGrid.AlternarColorEnFilas(grdTarjetaAlmacen)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = ""

        grdTarjetaAlmacen.Columns.AddField("productoestiloid")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("productoestiloid").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("productoestiloid").Visible = False

        grdTarjetaAlmacen.Columns.AddField("DescripcionCompleta")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("DescripcionCompleta").Caption = "Descripción del Artículo"

        grdTarjetaAlmacen.Columns.AddField("existenciainicial")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("existenciainicial").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("existenciainicial").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("existenciainicial").Caption = "Existencia Inicial"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("existenciainicial").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("paresentrada")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").Caption = "Entradas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresentrada").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("paressalida")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").Caption = "Salidas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paressalida").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("paresexistencia")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").Caption = "Existencia en Pares"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresexistencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("costounitariopromedio")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitariopromedio").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitariopromedio").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitariopromedio").Caption = "Costo Unitario Promedio"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("costounitariopromedio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("importeexistencia")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").Caption = "Existencia en Pesos"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeexistencia").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("prcprecioventa")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prcprecioventa").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prcprecioventa").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prcprecioventa").Caption = "Precio de Venta"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prcprecioventa").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("paresvendidos")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresvendidos").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresvendidos").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresvendidos").Caption = "Pares Vendidos"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("paresvendidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("importeventas")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventas").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventas").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventas").Caption = "Importe Ventas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importeventas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("importecostoventas")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importecostoventas").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importecostoventas").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importecostoventas").Caption = "Importe Costo de Ventas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("importecostoventas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdTarjetaAlmacen.Columns.AddField("prccostoventas")
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventas").OwnerBand = band
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventas").Visible = True
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventas").Caption = "% de Costo de Ventas"
        grdTarjetaAlmacen.Columns.ColumnByFieldName("prccostoventas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

        grdTarjetaAlmacen.Bands.Add(band)

        Dim blnSum As Boolean = False
        Dim strFormat As String = String.Empty

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In grdTarjetaAlmacen.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            For Each childrenBand In gridband.Children
                childrenBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Next
        Next

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In grdTarjetaAlmacen.Columns
            blnSum = False
            strFormat = String.Empty

            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            Select Case Col.FieldName
                Case "DescripcionCompleta"
                    Col.Width = 350
                    blnSum = False
                    strFormat = ""
                Case "existenciainicial", "paresentrada", "paressalida", "paresvendidos", "paresexistencia"
                    blnSum = True
                    strFormat = "{0:N0}"
                Case "costounitariopromedio", "importeexistencia", "prcprecioventa", "importeventas", "importecostoventas"
                    blnSum = True
                    strFormat = "{0:N2}"
                Case "prccostoventas"
                    blnSum = True
                    strFormat = "{0:P2}"
                Case Else
                    Col.Width = 90
                    strFormat = "{0:N2}"
            End Select

            grdTarjetaAlmacen.BestFitColumns()

            If blnSum = True AndAlso IsNothing(grdTarjetaAlmacen.Columns(Col.FieldName).Summary.FirstOrDefault(Function(x) x.FieldName = Col.FieldName)) = True Then
                If Col.FieldName = "costounitariopromedio" Or Col.FieldName = "prcprecioventa" Or Col.FieldName = "prccostoventas" Then
                    grdTarjetaAlmacen.Columns(Col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Custom, Col.FieldName, strFormat) '"{0:P2}") '"{0:N2}")
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = Col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                    item.DisplayFormat = strFormat ' "{0:P2}" '"{0:N2}"
                    grdTarjetaAlmacen.GroupSummary.Add(item)
                Else
                    grdTarjetaAlmacen.Columns(Col.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, strFormat) '"{0:N2}")
                    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                    item.FieldName = Col.FieldName
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    item.DisplayFormat = strFormat ' "{0:N2}"
                    grdTarjetaAlmacen.GroupSummary.Add(item)
                End If
            End If
            Col.DisplayFormat.FormatString = strFormat
        Next

        grdTarjetaAlmacen.IndicatorWidth = 40

    End Sub

    Private Sub vwDatos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdTarjetaAlmacen.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try
            If rdoTarjeta.Checked = True Then

                If grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "tipofila") = "SUBTOTAL" Then
                    e.Formatting.BackColor = Color.FromArgb(189, 215, 238)
                    e.Formatting.Font.Bold = True
                End If

                If grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "tipofila") = "TOTAL" Then
                    e.Formatting.BackColor = Color.FromArgb(217, 217, 217)
                    e.Formatting.Font.Bold = True
                End If

                If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "fueraderango")) AndAlso CBool(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "fueraderango")) Then
                    e.Formatting.Font.Color = Color.White
                    e.Formatting.BackColor = Color.Red
                End If

                If rdoTarjeta.Checked = True Then
                    If e.ColumnFieldName.Contains("paresexistencia") Or e.ColumnFieldName.Contains("precioventa") Or e.ColumnFieldName.Contains("importeventa") Then
                        If Not IsDBNull(e.Value) Then
                            If IsNumeric(e.Value) AndAlso CDbl(e.Value) < 0 Then
                                e.Formatting.Font.Color = Color.Red
                            End If
                        End If
                    End If
                End If
            End If

            e.Handled = True
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " + ex.Message)
        End Try
    End Sub

    Private Sub grdTarjetaAlmacen_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grdTarjetaAlmacen.CustomDrawCell
        Try
            Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

            If rdoTarjeta.Checked = True Then
                If currentView.GetRowCellValue(e.RowHandle, "tipofila") = "SUBTOTAL" Then
                    e.Appearance.BackColor = Color.FromArgb(189, 215, 238)
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)

                ElseIf currentView.GetRowCellValue(e.RowHandle, "tipofila") = "TOTAL" Then
                    e.Appearance.BackColor = Color.FromArgb(217, 217, 217)
                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, FontStyle.Bold)

                End If

                If Not IsDBNull(currentView.GetRowCellValue(e.RowHandle, "fueraderango")) AndAlso CBool(currentView.GetRowCellValue(e.RowHandle, "fueraderango")) Then
                    e.Appearance.ForeColor = Color.White
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió el siguiente error: " & ex.Message)
        End Try
    End Sub

    Private Sub grdTarjetaAlmacen_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles grdTarjetaAlmacen.CellValueChanged
        If rdoTarjeta.Checked = True Then
            Try
                If e.Column.FieldName = "chaceptar" Then
                    If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "concepto")) AndAlso grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "concepto") = "VENTA" Then
                        If CBool(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "chaceptar")) AndAlso CBool(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "fueraderango")) Then
                            grdTarjetaAlmacen.SetRowCellValue(e.RowHandle, "fueraderango", False)
                            registrosEdicion += 1
                        ElseIf CBool(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "chaceptar")) = False Then
                            If Not dtConfigPorcentaje Is Nothing AndAlso dtConfigPorcentaje.Rows.Count > 0 Then
                                If CBool(dtConfigPorcentaje.Rows(0).Item("configurada")) Then
                                    Dim valor As Double = 0
                                    valor = CDbl(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "prccostoventa")) * 100
                                    If valor < CDbl(dtConfigPorcentaje.Rows(0).Item("limiteinferior")) OrElse valor > CDbl(dtConfigPorcentaje.Rows(0).Item("limitesuperior")) Then
                                        grdTarjetaAlmacen.SetRowCellValue(e.RowHandle, "fueraderango", True)
                                        registrosEdicion -= 1
                                    Else
                                        grdTarjetaAlmacen.SetRowCellValue(e.RowHandle, "fueraderango", False)
                                    End If
                                Else
                                    grdTarjetaAlmacen.SetRowCellValue(e.RowHandle, "fueraderango", False)
                                End If
                            Else
                                grdTarjetaAlmacen.SetRowCellValue(e.RowHandle, "fueraderango", False)
                            End If
                        End If
                    Else
                        If CBool(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "chaceptar")) Then
                            grdTarjetaAlmacen.SetRowCellValue(e.RowHandle, "chaceptar", False)
                        End If
                    End If
                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al asignar el formato: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub grdTarjetaAlmacen_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdTarjetaAlmacen.RowCellStyle
        If rdoTarjeta.Checked = True Then
            If e.Column.FieldName = "concepto" Then
                If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, e.Column.FieldName)) AndAlso grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, e.Column.FieldName) = "SALDO INICIAL" Then
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
            ElseIf e.Column.FieldName = "fechadocumento" Then
                If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "concepto")) AndAlso grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, "concepto") = "SALDO INICIAL" Then
                    e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                End If
            End If

            If e.Column.FieldName.Contains("paresexistencia") Or e.Column.FieldName.Contains("precioventa") Or e.Column.FieldName.Contains("importeventa") Then
                If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    If CDbl(grdTarjetaAlmacen.GetRowCellValue(e.RowHandle, e.Column.FieldName)) < 0 Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdTarjetaAlmacen_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles grdTarjetaAlmacen.CustomSummaryCalculate
        Dim view As GridView = sender
        Dim nombrecolumna As String = e.Item.FieldName

        If nombrecolumna = "costounitariopromedio" Or nombrecolumna = "prcprecioventa" Or nombrecolumna = "prccostoventas" Then
            e.TotalValueReady = True
            If (e.SummaryProcess = CustomSummaryProcess.Finalize) Then
                e.TotalValue = CalcAverage(view, e.RowHandle, e.Item.FieldName)
            End If
        End If

    End Sub

    Private Function CalcAverage(view As GridView, eRowHandle As Integer, nombrecolumna As String)
        Dim sum As Decimal = 0
        Dim count As Integer = 0
        For index = 0 To grdTarjetaAlmacen.RowCount
            If Not IsDBNull(grdTarjetaAlmacen.GetRowCellValue(index, nombrecolumna)) Then
                Dim value = CDec(grdTarjetaAlmacen.GetRowCellValue(index, nombrecolumna))
                If Not value = 0 Then
                    count += 1
                    If nombrecolumna = "prccostoventas" Then
                        sum += (value * 100)
                    Else
                        sum += value
                    End If

                End If
            End If
        Next

        Dim resultado As Decimal = 0
        If Not count = 0 Then
            If nombrecolumna = "prccostoventas" Then
                resultado = (sum / count) / 100
            Else
                resultado = sum / count
            End If
        End If

        Return resultado
    End Function

#End Region 'Termina Region Diseño

#Region "Filtros"
    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click
        If cmbEmpresa.SelectedIndex > 0 Then
            Dim listado As New ListadoParametrosBusquedaTarjetaForm
            Dim listaParametroID As New List(Of String)

            For Each row As UltraGridRow In grdProductos.Rows
                Dim parametro As String = row.Cells(0).Text
                listaParametroID.Add(parametro)
            Next

            listado.tipo_busqueda = 1
            listado.empresaId = cmbEmpresa.SelectedValue
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)

            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return

            grdProductos.DataSource = listado.listParametros

            If listado.listParametros.Rows.Count > 0 Then
                cambioValorFiltro()
            End If

            With grdProductos
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Hidden = True
                .DisplayLayout.Bands(0).Columns(4).Hidden = True
                .DisplayLayout.Bands(0).Columns(3).Hidden = False
                .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Artículo"
            End With
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario elegir una empresa para aplicar los filtros.")
        End If
    End Sub

    Private Sub grdProductos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProductos.InitializeLayout
        grid_diseño(grdProductos)
        grdProductos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Artículo"
    End Sub

    Private Sub grdProductos_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles grdProductos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdProductos.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
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

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub obtenerFiltros()
        filtroProductos = ""
        For Each Row As UltraGridRow In grdProductos.Rows
            If filtroProductos <> "" Then
                filtroProductos += ","
            End If
            filtroProductos += Row.Cells("Parametro").Value.ToString()
        Next
    End Sub

    Private Sub btnLimpiarFiltroProducto_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroProducto.Click
        grdProductos.DataSource = listInicial
        cambioValorFiltro()
    End Sub

    Private Sub rdoTarjeta_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTarjeta.CheckedChanged, rdoInventario.CheckedChanged
        limpiarGrid()
        registrosEdicion = 0
    End Sub

    Private Sub limpiarGrid()
        GridTarjeta.DataSource = Nothing
        grdTarjetaAlmacen.Bands.Clear()
        grdTarjetaAlmacen.Columns.Clear()
        lblFechaActualizacion.Text = "-"
    End Sub

    Private Sub cmbMesInicial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMesInicial.SelectedIndexChanged
        If Not cmbMesInicial.DataSource Is Nothing Then
            cambioValorFiltro()
        End If
    End Sub

    Private Sub cmbMesFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMesFinal.SelectedIndexChanged
        If Not cmbMesFinal.DataSource Is Nothing Then
            cambioValorFiltro()
        End If
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged
        If Not cmbAnio.DataSource Is Nothing Then
            cambioValorFiltro()
        End If
    End Sub

    Private Sub cambioValorFiltro()
        limpiarGrid()
        registrosEdicion = 0
    End Sub

#End Region 'Termina Region Filtros

End Class