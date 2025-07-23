Imports Framework.Negocios
Imports System.Windows.Forms
Imports Tools
Imports Stimulsoft.Report
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report.Export

Public Class BitacoraMovimientosForm
    Private Sub BitacoraMovimientosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        BitacoraMovimientosArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("NF_BITACORA_MOV", "EDITAR_WORD")
        cargarCombos()

    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        cmbEmpresa.DataSource = Nothing
        limpiarDatos()

        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbEmpresa.DataSource = dtEmpresa
                cmbEmpresa.DisplayMember = "Patron"
                cmbEmpresa.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbEmpresa.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        limpiarDatos()
        llenarComboPeriodo()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        limpiarDatos()
        cargarDatos()
    End Sub

    Private Sub rdoRango_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRango.CheckedChanged
        limpiarDatos()
        dtpFechaInicio.Enabled = True
        dtpFechaFin.Enabled = True
        If cmbPeriodo.Items.Count > 0 Then
            cmbPeriodo.SelectedIndex = 0
        End If
        cmbPeriodo.Enabled = False
    End Sub

    Private Sub rdoPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPeriodo.CheckedChanged
        limpiarDatos()
        dtpFechaInicio.Enabled = False
        dtpFechaFin.Enabled = False
        cmbPeriodo.Enabled = True
        If cmbPeriodo.Items.Count > 0 Then
            cmbPeriodo.SelectedIndex = 1
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbNave.SelectedIndex = 0
        cmbTipoMovimiento.SelectedIndex = 0
        limpiarDatos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If Not IsNothing(grdDatos.DataSource) AndAlso vwDatos.RowCount > 0 Then
            imprimirReporte("Imprimir")
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario cargar los datos para enviar al reporte.")
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If vwDatos.RowCount > 0 Then
            exportar()
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        If Not IsNothing(grdDatos.DataSource) AndAlso vwDatos.RowCount > 0 Then
            imprimirReporte("Enviar")
        End If
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub AyudaBitácoraMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaBitacoraMovimientosToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_BitacoraMovimientos_NominaFiscal_V1.pdf")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_BitacoraMovimientos_NominaFiscal_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DatosAjusteArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitacoraMovimientosArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Contabilidad/", "Descargas\Manuales\Contabilidad", "CONTA_MAUS_BitacoraMovimientos_NominaFiscal_V1.docx")
            Process.Start("Descargas\Manuales\Contabilidad\CONTA_MAUS_BitacoraMovimientos_NominaFiscal_V1.docx")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub vwDatos_DoubleClick(sender As Object, e As EventArgs) Handles vwDatos.DoubleClick
        Dim idColaborador As Integer = 0
        Dim carpeta As String = String.Empty
        Dim archivo As String = String.Empty

        If vwDatos.SelectedRowsCount = 1 Then
            Dim Fila As Integer = vwDatos.DataRowCount
            Me.Cursor = Cursors.WaitCursor

            For item As Integer = 0 To Fila Step 1
                If CBool(vwDatos.IsRowSelected(vwDatos.GetVisibleRowHandle(item))) = True Then
                    idColaborador = vwDatos.GetRowCellValue(item, "colaboradorid")
                    carpeta = vwDatos.GetRowCellValue(item, "carpeta")
                    archivo = vwDatos.GetRowCellValue(item, "nombrearchivo")
                End If
            Next
            Try
                If carpeta.Length > 0 And archivo.Length > 0 Then
                    Dim objTransferencias As New Tools.TransferenciaFTP
                    objTransferencias.DescargarArchivo(carpeta, "Descargas\Acuses\Contabilidad", archivo)
                    Process.Start("Descargas\Acuses\Contabilidad\" + archivo)

                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al intentar descargar al acuse.")
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

#Region "Funciones"

    Private Sub cargarCombos()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        Dim dtTipoMov As New DataTable

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        dtTipoMov = objBu.consultarTipoMovimientos()
        If Not dtTipoMov Is Nothing AndAlso dtTipoMov.Rows.Count > 0 Then
            cmbTipoMovimiento.DataSource = dtTipoMov
            cmbTipoMovimiento.DisplayMember = "Descripcion"
            cmbTipoMovimiento.ValueMember = "Id"
        End If

    End Sub

    Private Sub llenarComboPeriodo()
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            cmbPeriodo.DataSource = Nothing
            If cmbEmpresa.SelectedIndex > 0 Or cmbEmpresa.Items.Count = 1 And IsNumeric(cmbEmpresa.SelectedValue) Then
                Dim objBU As New Negocios.ControlAsistenciaBU
                Dim dtListado As New DataTable

                dtListado = objBU.consultarPeriodoNomina(CInt(cmbEmpresa.SelectedValue.ToString))
                If Not dtListado Is Nothing Then
                    If dtListado.Rows.Count > 0 Then
                        cmbPeriodo.DataSource = dtListado
                        cmbPeriodo.ValueMember = "ID"
                        cmbPeriodo.DisplayMember = "DESCRIPCION"

                        If dtListado.Rows.Count > 1 Then
                            Dim dtRow As DataRow = dtListado.NewRow
                            dtRow("ID") = 0
                            dtRow("DESCRIPCION") = ""
                            dtListado.Rows.InsertAt(dtRow, 0)
                        End If

                        If rdoRango.Checked Then
                            cmbPeriodo.SelectedIndex = 0
                        End If
                    Else
                        objMensajeAdv.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                        objMensajeAdv.ShowDialog()
                    End If
                Else
                    objMensajeAdv.mensaje = "No hay periodos de nómina para la empresa seleccionada."
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al consultar los periodos de nómina"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub cargarDatos()
        Try
            If cmbEmpresa.SelectedIndex > 0 Then
                Dim obBU As New Negocios.BitacoraMovimientosBU
                Dim dtDatos As New DataTable

                Me.Cursor = Cursors.WaitCursor

                dtDatos = obBU.consultarBitacoraMovimientos(cmbNave.SelectedValue, cmbEmpresa.SelectedValue, cmbTipoMovimiento.SelectedValue, cmbPeriodo.SelectedValue, dtpFechaInicio.Value, dtpFechaFin.Value)

                If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                    grdDatos.DataSource = dtDatos
                    diseniogrid()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información para mostrar.")
                End If

            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Es necesario elegir una empresa para consultar la información.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la información.")
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub limpiarDatos()
        vwDatos.Columns.Clear()
        grdDatos.DataSource = Nothing
    End Sub

    Private Sub diseniogrid()
        DiseñoGrid.AlternarColorEnFilas(vwDatos)
        DiseñoGrid.AlinearTextoEncabezadoColumnas(vwDatos)
        DiseñoGrid.DeshabilitarEdicion(vwDatos)
        DiseñoGrid.DiseñoBaseGrid(vwDatos)
        DiseñoGrid.AjustarAnchoColumnas(vwDatos)

        If IsNothing(vwDatos.Columns.FirstOrDefault(Function(x) x.FieldName = "No.")) = True Then
            vwDatos.Columns.AddVisible("No.").UnboundType = DevExpress.Data.UnboundColumnType.Integer
            AddHandler vwDatos.CustomUnboundColumnData, AddressOf GridView1_CustomUnboundColumnData
            vwDatos.Columns.Item("No.").VisibleIndex = 0
        End If

        vwDatos.Columns("colaboradorid").Visible = False
        vwDatos.Columns("movimientoid").Visible = False
        vwDatos.Columns("idtabla").Visible = False
        vwDatos.Columns("usuarioaplicoid").Visible = False
        vwDatos.Columns("carpeta").Visible = False

        vwDatos.Columns.ColumnByFieldName("sbc").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("sbc").DisplayFormat.FormatString = "N2"
        vwDatos.Columns.ColumnByFieldName("montoinfonavit").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("montoinfonavit").DisplayFormat.FormatString = "N2"
        vwDatos.Columns.ColumnByFieldName("descuentoanterior").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwDatos.Columns.ColumnByFieldName("descuentoanterior").DisplayFormat.FormatString = "N2"

        vwDatos.Columns.ColumnByFieldName("clave").Caption = "Código Empleado"
        vwDatos.Columns.ColumnByFieldName("colaborador").Caption = "Colaborador"
        vwDatos.Columns.ColumnByFieldName("nss").Caption = "NSS"
        vwDatos.Columns.ColumnByFieldName("rfc").Caption = "RFC"
        vwDatos.Columns.ColumnByFieldName("curp").Caption = "CURP"
        vwDatos.Columns.ColumnByFieldName("movimiento").Caption = "Tipo de Movimiento"
        vwDatos.Columns.ColumnByFieldName("fechamovimiento").Caption = "Fecha del" & Environment.NewLine & "Movimiento (IDSE)"
        vwDatos.Columns.ColumnByFieldName("sbc").Caption = "SBC"
        vwDatos.Columns.ColumnByFieldName("montoinfonavit").Caption = "Monto a descontar " & Environment.NewLine & "de INFONAVIT"
        vwDatos.Columns.ColumnByFieldName("descuentoanterior").Caption = "Descuento Anterior"
        vwDatos.Columns.ColumnByFieldName("folioincapacidad").Caption = "Folio de Incapacidad"
        vwDatos.Columns.ColumnByFieldName("diasautorizados").Caption = "Días Autorizados"
        vwDatos.Columns.ColumnByFieldName("nombrearchivo").Caption = "PDF Acuse"
        vwDatos.Columns.ColumnByFieldName("fechasolicitud").Caption = "Fecha de Solicitud"
        vwDatos.Columns.ColumnByFieldName("fechaautorizacion").Caption = "Fecha de Autorización"
        vwDatos.Columns.ColumnByFieldName("fechaaplicacion").Caption = "Fecha de Aplicación"
        vwDatos.Columns.ColumnByFieldName("usuarioaplico").Caption = "Usuario Aplicó"

        vwDatos.Columns.ColumnByFieldName("No.").Width = 40
        vwDatos.Columns.ColumnByFieldName("clave").Width = 70

        vwDatos.Columns.ColumnByFieldName("clave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("colaborador").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("nss").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("rfc").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("curp").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwDatos.Columns.ColumnByFieldName("nombrearchivo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

    End Sub

    Private Sub GridView1_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = vwDatos.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub imprimirReporte(ByVal accion As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim objDSBU As New Negocios.DatosSPEMensualBU
            Dim strEmpresa As String = String.Empty
            Dim strPerido As String = String.Empty
            Dim OBJBU As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim dtReporte As New DataTable
            EntidadReporte = OBJBU.LeerReporteporClave("REP_BITACORA_MOV")

            Dim archivo As String
            archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) '+ ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo + ".mrt", EntidadReporte.Pxml, False)

            dtReporte = vwDatos.GridControl.DataSource
            strEmpresa = objDSBU.obtieneEncabezadoReporte(cmbEmpresa.SelectedValue)

            If rdoRango.Checked = True Then
                strPerido = "PERIODO DEL " & CDate(dtpFechaInicio.Value).ToString("dd/MM/yyyy") & " AL " & CDate(dtpFechaFin.Value).ToString("dd/MM/yyyy")
            Else
                strPerido = "PERIODO DE " & cmbPeriodo.Text
            End If

            Dim reporte As StiReport = New StiReport()
            reporte.Load(archivo + ".mrt")
            reporte.Compile()
            reporte("Empresa") = strEmpresa
            reporte("Nave") = cmbNave.Text
            reporte("Periodo") = strPerido
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte.Dictionary.Clear()
            reporte.RegData(dtReporte)
            reporte.Dictionary.Synchronize()
            reporte.Render()
            If accion = "Imprimir" Then
                reporte.Show()
            ElseIf accion = "Enviar" Then
                Try
                    Dim PdfExport As StiPdfExportService = New StiPdfExportService()
                    Dim nombreArchivo As String = String.Empty
                    nombreArchivo = archivo + ".pdf"
                    Try
                        My.Computer.FileSystem.DeleteFile(nombreArchivo)
                    Catch ex As Exception
                    End Try

                    PdfExport.ExportPdf(reporte, nombreArchivo)
                    enviarcorreo(nombreArchivo)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Mensaje enviado.")

                Catch ex As Exception
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Surgió algo inesperado. Detalle: " & ex.ToString)
                Finally
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub enviarcorreo(ByVal nombreArchivo As String)
        System.Threading.Thread.Sleep(3000)

        'enviar_correo(NaveID, "ENVIO_DEPOSITO_CUENTAS")               
        Dim archivoAdjunto = New System.Net.Mail.Attachment(nombreArchivo)

        Dim objBU As New Negocios.BitacoraMovimientosBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        destinatarios = objBU.obtieneDestinosCorreo(cmbEmpresa.SelectedValue)

        If destinatarios <> "" Then
            Dim Email As String = ""
            Email = "SE ENVÍA EL REPORTE DE MOVIMIENTOS REALIZADOS."
            correo.EnviarCorreoHtmlArchivoAdjunto(destinatarios, "say_contabilidad@grupoyuyin.com.mx", "NOTIFICACIÓN DE BITÁCORA DE MOVIMIENTOS", Email, archivoAdjunto)
        End If

        Try
            My.Computer.FileSystem.DeleteFile(nombreArchivo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub exportar()
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
                    archivo = .SelectedPath + "\Bitácora_Movimientos_" + fecha_hora + ".xlsx"

                    vwDatos.ExportToXlsx(archivo, exportOptions)
                    cargarDatos()

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

    Private Sub cmbTipoMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMovimiento.SelectedIndexChanged
        limpiarDatos()
    End Sub

#End Region '"Funciones"


End Class