Imports Tools
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.Windows.Forms
Imports Framework.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports System.Net

Public Class AltaColaboradoresIMSSForm
    Dim sPDF As String = String.Empty
    Dim directorio As String = String.Empty

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdColaboradoresImss.Height = 471
        grdColaboradoresImss.Top = 115
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 90
        grdColaboradoresImss.Height = 346
        grdColaboradoresImss.Top = 240
    End Sub

    Public Sub cargarDatosIniciales()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub AltaColaboradoresIMSSForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        cargarDatosIniciales()
        configurarPermisosBotonesEspeciales()
    End Sub

    Public Sub configurarPermisosBotonesEspeciales()
        If PermisosUsuarioBU.ConsultarPermiso("COLABO_AL_IMSS", "ALTA_IMSS") Then
            pnlAltas.Visible = True
        Else
            pnlAltas.Visible = False
        End If
    End Sub

    Public Sub cargarDatosColaboradores()
        Dim idNave As Int32 = 0
        Dim advertencia As New AdvertenciaForm
        Dim nombre As String = String.Empty
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtColaboAlta As New DataTable

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue
            nombre = txtNombre.Text
            dtColaboAlta = objBu.consultaColaboradoresParaALtaImss(idNave, nombre)

            If Not dtColaboAlta Is Nothing Then
                If dtColaboAlta.Rows.Count > 0 Then
                    grdColaboradoresImss.DataSource = Nothing
                    grdColaboradoresImss.DataSource = dtColaboAlta
                    formatoGrid()
                End If
            End If
        Else
            advertencia.mensaje = "Seleccione una nave"
            advertencia.ShowDialog()
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub formatoGrid()
        With grdColaboradoresImss.DisplayLayout.Bands(0)

            .Columns("codr_colaboradorid").Hidden = True
            .Columns("rojo").Hidden = True
            .Columns("codr_fechanacimiento").Hidden = True
            .Columns("umfId").Hidden = True
            .Columns("patronId").Hidden = True
            .Columns("patron").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("codr_apellidopaterno").Header.Caption = "A.Paterno"
            .Columns("aMaterno").Header.Caption = "A.Materno"
            .Columns("codr_nombre").Header.Caption = "Nombre"
            .Columns("codr_curp").Header.Caption = "Curp"
            .Columns("codr_rfc").Header.Caption = "RFC"
            .Columns("cono_nss").Header.Caption = "NSS"
            .Columns("diasantiguedad").Header.Caption = "Días Antiguedad"
            .Columns("puesto").Header.Caption = "Puesto"
            .Columns("sdi").Header.Caption = "SDI"


            .Columns("codr_apellidopaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("aMaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_curp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("codr_rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cono_nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasantiguedad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sdi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("sdi").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasantiguedad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("sdi").Format = "###,###,##0.00"
            '.Columns("diasantiguedad").Format = "###,###,##0.00"

            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            .Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdColaboradoresImss.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdColaboradoresImss.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradoresImss.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradoresImss.DisplayLayout.Override.RowSelectorWidth = 35
        grdColaboradoresImss.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdColaboradoresImss.Rows(0).Selected = True

        'grdSolicitudes.DisplayLayout.Bands(0).Columns("estDsn").Width = 20
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("Seleccion").Width = 20
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaEntrega").Width = 50
        'grdSolicitudes.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdColaboradoresImss.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Public Sub limpiarCampos()
        txtNombre.Text = ""
        cmbNave.SelectedIndex = 0
        grdColaboradoresImss.DataSource = Nothing
    End Sub

    Private Sub grdColaboradoresImss_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdColaboradoresImss.InitializeRow
        If e.Row.Cells("rojo").Value = 1 Then
            e.Row.Cells("cono_nss").Appearance.ForeColor = Color.Red
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
            e.Row.Cells("Seleccion").Value = 0
        End If
        'If validarCurpRFC(e.Row.Cells("codr_apellidopaterno").Value, e.Row.Cells("aMaterno").Value, e.Row.Cells("codr_nombre").Value, e.Row.Cells("codr_fechanacimiento").Value, e.Row.Cells("codr_curp").Value) = False Then
        '    e.Row.Cells("codr_curp").Appearance.ForeColor = Color.Red
        '    e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        'End If
        'If validarCurpRFC(e.Row.Cells("codr_apellidopaterno").Value, e.Row.Cells("aMaterno").Value, e.Row.Cells("codr_nombre").Value, e.Row.Cells("codr_fechanacimiento").Value, e.Row.Cells("codr_rfc").Value) = False Then
        '    e.Row.Cells("codr_rfc").Appearance.ForeColor = Color.Red
        '    e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        'End If

        If validarCurpRFC(e.Row.Cells("codr_colaboradorid").Value, "CURP") = False Then
            e.Row.Cells("codr_curp").Appearance.ForeColor = Color.Red
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        End If
        If validarCurpRFC(e.Row.Cells("codr_colaboradorid").Value, "RFC") = False Then
            e.Row.Cells("codr_rfc").Appearance.ForeColor = Color.Red
            e.Row.Cells("Seleccion").Activation = Activation.NoEdit
        End If

    End Sub

    Public Sub completarDatosAltaImss()
        Dim dtColabo As New DataTable
        Dim completarAlta As New CompletarAltaColaboradorIMSSForm
        Dim dtCartaManifiesto As New DataTable

        dtColabo.Columns.Add("seleccion")
        dtColabo.Columns.Add("idColaborador")
        dtColabo.Columns.Add("aPaterno")
        dtColabo.Columns.Add("aMaterno")
        dtColabo.Columns.Add("nombre")
        dtColabo.Columns.Add("curp")
        dtColabo.Columns.Add("rfc")
        dtColabo.Columns.Add("nss")
        dtColabo.Columns.Add("diasAntiguedad")
        dtColabo.Columns.Add("puesto")
        dtColabo.Columns.Add("sdi")
        dtColabo.Columns.Add("umfId")
        dtColabo.Columns.Add("patronId")
        dtColabo.Columns.Add("patron")

        For Each rowGr As UltraGridRow In grdColaboradoresImss.Rows
            If CBool(rowGr.Cells("Seleccion").Value) = True Then
                Dim filaCol As DataRow = dtColabo.NewRow

                filaCol.Item("seleccion") = "false"
                filaCol.Item("idColaborador") = rowGr.Cells("codr_colaboradorid").Value
                filaCol.Item("aPaterno") = rowGr.Cells("codr_apellidopaterno").Value
                filaCol.Item("aMaterno") = rowGr.Cells("aMaterno").Value
                filaCol.Item("nombre") = rowGr.Cells("codr_nombre").Value
                filaCol.Item("curp") = rowGr.Cells("codr_curp").Value
                filaCol.Item("rfc") = rowGr.Cells("codr_rfc").Value
                filaCol.Item("nss") = rowGr.Cells("cono_nss").Value
                filaCol.Item("diasAntiguedad") = rowGr.Cells("diasantiguedad").Value
                filaCol.Item("puesto") = rowGr.Cells("puesto").Value
                filaCol.Item("sdi") = rowGr.Cells("sdi").Value
                filaCol.Item("umfId") = rowGr.Cells("umfId").Value
                filaCol.Item("patronId") = rowGr.Cells("patronId").Value
                filaCol.Item("patron") = rowGr.Cells("patron").Value

                dtColabo.Rows.Add(filaCol)
            End If
        Next

        ''obtener fecha de alta
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtFecha As New DataTable
        Dim dtPatronNave As New DataTable
        Dim objBuu = New Negocios.UtileriasBU
        Dim idPatron As Int32 = 0
        dtPatronNave = objBuu.consultaPatronPorNaveIMSS(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)

        If dtPatronNave.Rows.Count > 0 Then
            idPatron = dtPatronNave.Rows(1).Item("id")
            dtFecha = objBu.obtenerFechaAlta(idPatron)


            If dtFecha.Rows.Count > 0 Then
                completarAlta.dtColabo = dtColabo
                completarAlta.idNave = cmbNave.SelectedValue
                completarAlta.ShowDialog()
                dtCartaManifiesto = completarAlta.dtNombre
                cargarDatosColaboradores()
                ''imprimir aqui carta manifiesto
                'dtCartaManifiesto.Columns.Add("nombre")
                'dtCartaManifiesto.Columns.Add("idColaborador")
                'dtCartaManifiesto.Columns.Add("idAlta")
                'Dim rowTra As DataRow = dtCartaManifiesto.NewRow
                'rowTra.Item("nombre") = "JESUS ALEJANDRO MENDOZA RAMIREZ"
                'rowTra.Item("idColaborador") = 3152
                'rowTra.Item("idAlta") = 12
                'dtCartaManifiesto.Rows.Add(rowTra)
                For Each row As DataRow In dtCartaManifiesto.Rows
                    generaCartaManifiesto(row.Item("nombre"), row.Item("idColaborador"), row.Item("idAlta"))
                Next
            Else
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "No existe configuración de periodos de nómina para la nave"
                advertencia.ShowDialog()

            End If

        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "No existe un patrón asignado para la nave"
            advertencia.ShowDialog()

        End If



    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        cargarDatosColaboradores()
    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        limpiarCampos()
    End Sub

    Private Sub txtNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            cargarDatosColaboradores()
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        completarDatosAltaImss()
    End Sub

    Public Sub generaCartaManifiesto(ByVal nombreColaborador As String, ByVal idColaborador As Int32, ByVal idAlta As Int32)
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim reporte As New StiReport
        Dim pdfSettings = New StiPdfExportSettings()
        EntidadReporte = objReporte.LeerReporteporClave("CON_CARTA_MANIFIESTO")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        sPDF = rutaTmp & "CARTA_MANIFIESTO" & idColaborador.ToString & "_" & Date.Now.ToString("ddMMyyyHmm") & ".pdf"
        Dim nombreArchivo As String = "CARTA_MANIFIESTO" & idColaborador.ToString & "_" & Date.Now.ToString("ddMMyyyHmm") & ".pdf"
        reporte.Load(archivo)

        reporte.Compile()

        reporte("nombre") = nombreColaborador.ToUpper

        reporte.Show()

        If (System.IO.File.Exists(rutaTmp)) Then

        Else
            My.Computer.FileSystem.CreateDirectory(rutaTmp)
        End If
        reporte.ExportDocument(StiExportFormat.Pdf, sPDF, pdfSettings)

        If subirArchivo(sPDF, idColaborador) Then
            Dim objBuCol As New Negocios.ColaboradoresContabilidadBU
            If objBuCol.actualizaExpedienteCartaManifiesto(idColaborador, idAlta, "CARTA MANIFIESTO", directorio, nombreArchivo) = "EXITO" Then
                eliminaArchivo(sPDF)
            Else
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "No fue posible guardar el archivo en el expediente"
                advertencia.ShowDialog()
            End If


        Else
            eliminaArchivo(sPDF)

        End If
    End Sub

    Private Function subirArchivo(ByVal ruta As String, ByVal colaboradorId As Integer) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & colaboradorId

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorio, ruta)
                rutaArchivo = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(ruta)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    directorio = String.Empty
                    Return False
                End If
            Else
                directorio = String.Empty
                Return False
            End If
        Catch
            directorio = String.Empty
            Return False
        End Try
    End Function
End Class