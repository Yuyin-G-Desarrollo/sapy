Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Nomina.Negocios
Imports Stimulsoft.Report
Imports Tools
Public Class CalculoAguinaldoVacacionesForm
    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 31
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 99
    End Sub

    Private Sub CalculoAguinaldoVacacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Dim objDate As Integer = Now.Year - 2
        Dim laños As New List(Of Integer)
        While objDate <= Now.Year
            laños.Add(objDate)
            objDate += 1
        End While
        cmbAnio.DataSource = laños
        disenioGridResumen()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        LlenarTabla()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTabla()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim objFiltros As New Entidades.FiltrosCalculoPercepciones
            Dim objBU As New VacacionesBU
            Dim NaveId = 0
            Dim Agno = 0
            Dim Periodo = "NAVIDAD"

            vwColaboradores.Columns.Clear()
            grdColaboradores.DataSource = Nothing

            If cmbNave.SelectedValue > 0 Then
                NaveId = cmbNave.SelectedValue
            End If
            If cmbAnio.Text <> "" Then
                Agno = cmbAnio.Text
            End If
            If cmbPeriodo.Text <> "" Then
                Periodo = cmbPeriodo.Text
            End If

            Dim UsuarioId = 0
            UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            With objFiltros
                .PNaveId = NaveId
                .PAgno = Agno
                .PPeriodo = Periodo
                .PUsuarioId = UsuarioId
            End With

            Dim dtDatos As New DataTable
            dtDatos = objBU.CalculoPercepcionesLista(objFiltros)

            If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                If (dtDatos.Columns.Count = 1) Then
                    'Quiere decir que hubo un error, enviar mensaje correspondiente
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, dtDatos.Rows(0).Item(0).ToString)
                Else
                    grdColaboradores.DataSource = dtDatos
                    btnCalcular.Enabled = False
                    btnExportar.Enabled = True
                    btnImprimir.Enabled = True
                    btnCheques.Enabled = True
                    Dim dtValidacion As New DataTable
                    Dim Estatus As String = Nothing
                    dtValidacion = objBU.ValidarStatusAguinaldoVacaciones(objFiltros)

                    If dtValidacion.Rows.Count > 0 Then
                        Estatus = dtValidacion.Rows(0).Item("av_estatus").ToString
                    End If

                    If Estatus = "169" Then
                        btnAutorizar.Enabled = True
                    Else
                        btnAutorizar.Enabled = False
                    End If
                    disenioGrid()
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información para mostrar.")
            End If

            Dim dtResumen As New DataTable
            dtResumen = objBU.ResumenAguinaldoVacaciones(objFiltros)
            If Not dtResumen Is Nothing AndAlso dtResumen.Rows.Count > 0 Then
                If (dtResumen.Columns.Count <> 2) Then
                    'Quiere decir que hubo un error, enviar mensaje correspondiente
                    Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Hubo un error en la carga del resumen")
                Else
                    grdResumen.DataSource = dtResumen
                    disenioGridResumen()
                    vwResumen.Columns("Valor").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    vwResumen.Columns("Valor").DisplayFormat.FormatString = "$##,##0"
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontró información para mostrar.")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la información.")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub disenioGrid()
        Tools.DiseñoGrid.AlternarColorEnFilas(vwColaboradores)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwColaboradores)

        vwColaboradores.OptionsView.ShowFooter = True
        vwColaboradores.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwColaboradores.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next
        If Not vwColaboradores.Columns("S BASE") Is Nothing Then
            vwColaboradores.Columns("S BASE").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("S BASE").DisplayFormat.FormatString = "##,##0"
        End If

        'If Not vwColaboradores.Columns("46") Is Nothing Then
        '    vwColaboradores.Columns("46").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    vwColaboradores.Columns("46").DisplayFormat.FormatString = "##,##0"
        'End If

        'If Not vwColaboradores.Columns("47") Is Nothing Then
        '    vwColaboradores.Columns("47").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    vwColaboradores.Columns("47").DisplayFormat.FormatString = "##,##0"
        'End If

        'If Not vwColaboradores.Columns("48") Is Nothing Then
        '    vwColaboradores.Columns("48").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    vwColaboradores.Columns("48").DisplayFormat.FormatString = "##,##0"
        'End If

        'If Not vwColaboradores.Columns("49") Is Nothing Then
        '    vwColaboradores.Columns("49").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '    vwColaboradores.Columns("49").DisplayFormat.FormatString = "##,##0"
        'End If

        If Not vwColaboradores.Columns("7") Is Nothing Then
            vwColaboradores.Columns("7").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("7").DisplayFormat.FormatString = "##,##0"
        End If

        If Not vwColaboradores.Columns("8") Is Nothing Then
            vwColaboradores.Columns("8").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("8").DisplayFormat.FormatString = "##,##0"
        End If

        If Not vwColaboradores.Columns("9") Is Nothing Then
            vwColaboradores.Columns("9").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("9").DisplayFormat.FormatString = "##,##0"
        End If

        If Not vwColaboradores.Columns("10") Is Nothing Then
            vwColaboradores.Columns("10").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("10").DisplayFormat.FormatString = "##,##0"
        End If


        If Not vwColaboradores.Columns("IMPORTE VACACIONES") Is Nothing Then
            vwColaboradores.Columns("IMPORTE VACACIONES").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("IMPORTE VACACIONES").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("IMPORTE VACACIONES").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "IMPORTE VACACIONES", "{0:N0}")
        End If

        If Not vwColaboradores.Columns("IMPORTE AGUINALDO") Is Nothing Then
            vwColaboradores.Columns("IMPORTE AGUINALDO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("IMPORTE AGUINALDO").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("IMPORTE AGUINALDO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "IMPORTE AGUINALDO", "{0:N0}")
        End If

        If Not vwColaboradores.Columns("ISR A y V") Is Nothing Then
            vwColaboradores.Columns("ISR A y V").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("ISR A y V").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("ISR A y V").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ISR A y V", "{0:N0}")
        End If

        If Not vwColaboradores.Columns("TOTAL A y V") Is Nothing Then
            vwColaboradores.Columns("TOTAL A y V").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("TOTAL A y V").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("TOTAL A y V").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL A y V", "{0:N0}")
        End If

        If Not vwColaboradores.Columns("NETO FISCAL") Is Nothing Then
            vwColaboradores.Columns("NETO FISCAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("NETO FISCAL").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("NETO FISCAL").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "NETO FISCAL", "{0:N0}")
        End If

        If Not vwColaboradores.Columns("CHEQUE") Is Nothing Then
            vwColaboradores.Columns("CHEQUE").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("CHEQUE").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("CHEQUE").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CHEQUE", "{0:N0}")
        End If

        If Not vwColaboradores.Columns("EFECTIVO") Is Nothing Then
            vwColaboradores.Columns("EFECTIVO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("EFECTIVO").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("EFECTIVO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "EFECTIVO", "{0:N0}")
        End If


        vwColaboradores.BestFitColumns()
    End Sub
    Private Sub disenioGridResumen()
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwResumen)
        vwResumen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        vwResumen.OptionsView.ShowColumnHeaders = False
        vwResumen.OptionsView.ShowAutoFilterRow = False
        vwResumen.OptionsView.ShowFilterPanelMode = False
        If Not vwColaboradores.Columns("Valor") Is Nothing Then
            vwColaboradores.Columns("Valor").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("Valor").DisplayFormat.FormatString = "##,##0"
        End If
    End Sub

    Private Sub diseñoGridCheques()
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(vwColaboradores)
        If Not vwColaboradores.Columns("TOTAL") Is Nothing Then
            vwColaboradores.Columns("TOTAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            vwColaboradores.Columns("TOTAL").DisplayFormat.FormatString = "##,##0"
            vwColaboradores.Columns("TOTAL").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TOTAL", "{0:N0}")
        End If

    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarGrid()
    End Sub

    Private Sub limpiarGrid()
        grdColaboradores.DataSource = Nothing
        grdResumen.DataSource = Nothing
        vwColaboradores.Columns.Clear()
        cmbNave.Text = ""
        cmbAnio.Text = ""
        cmbPeriodo.Text = ""
        btnCalcular.Enabled = True
        btnExportar.Enabled = False
        btnImprimir.Enabled = False
        btnAutorizar.Enabled = False
        btnCheques.Enabled = False
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim objFiltros As New Entidades.FiltrosCalculoPercepciones
            Dim objBU As New VacacionesBU
            Dim NaveId = 0
            Dim Agno = 0
            Dim Periodo = "NAVIDAD"

            vwColaboradores.Columns.Clear()
            grdColaboradores.DataSource = Nothing

            If cmbNave.SelectedValue > 0 Then
                NaveId = cmbNave.SelectedValue
            End If
            If cmbAnio.Text <> "" Then
                Agno = cmbAnio.Text
            End If
            If cmbPeriodo.Text <> "" Then
                Periodo = cmbPeriodo.Text
            End If

            With objFiltros
                .PNaveId = NaveId
                .PAgno = Agno
                .PPeriodo = Periodo
            End With

            Dim dtTimbrado As New DataTable
            dtTimbrado = objBU.ValidarTimbrado(objFiltros)
            If dtTimbrado.Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Las vacaciones y/o aguinaldo fiscal aun no esta timbrado")
                Me.Cursor = Cursors.Default
                Return
            End If

            Dim dtValidacion As New DataTable
            Dim Estatus As String = Nothing
            dtValidacion = objBU.ValidarStatusAguinaldoVacaciones(objFiltros)

            If dtValidacion.Rows.Count > 0 Then
                Estatus = dtValidacion.Rows(0).Item("av_estatus").ToString
            End If

            If Estatus = "169" Or Estatus = "171" Or Estatus = "" Or Estatus = Nothing Then
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "Se realizará un cálculo nuevo" + vbNewLine + "¿Desea continuar?" + vbNewLine + "(Si existía un cálculo previo se eliminará para crear uno nuevo)"
                If mensajeExito.ShowDialog = DialogResult.OK Then
                    Dim dtDatos As New DataTable
                    dtDatos = objBU.CalculoPercepcionesAgregar(objFiltros)
                End If
            ElseIf Estatus = "170" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, "El periodo para la nave ya fué autorizado" + vbNewLine + "No se permiten cambios.")
            End If
            LlenarTabla()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrió un error al obtener la información.")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If vwColaboradores.RowCount > 0 Then
            exportar()
        End If
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
                    archivo = .SelectedPath + "\Reporte_Percepciones_" + fecha_hora + ".xlsx"

                    vwColaboradores.ExportToXlsx(archivo, exportOptions)
                    LlenarTabla()

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

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        If vwColaboradores.DataRowCount > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim mensajeExito As New ConfirmarForm
                mensajeExito.mensaje = "¿Autorizar los montos de Vacaciones y Aguinaldos para el periodo y nave seleccionados?" + vbNewLine + "(No se podrán realizar cambios a este periodo)"
                If mensajeExito.ShowDialog = DialogResult.OK Then
                    Dim objFiltros As New Entidades.FiltrosCalculoPercepciones
                    Dim objBU As New VacacionesBU
                    Dim NaveId = 0
                    Dim Agno = 0
                    Dim Periodo = "NAVIDAD"

                    If cmbNave.SelectedValue > 0 Then
                        NaveId = cmbNave.SelectedValue
                    End If
                    If cmbAnio.Text <> "" Then
                        Agno = cmbAnio.Text
                    End If
                    If cmbPeriodo.Text <> "" Then
                        Periodo = cmbPeriodo.Text
                    End If

                    With objFiltros
                        .PNaveId = NaveId
                        .PAgno = Agno
                        .PPeriodo = Periodo
                    End With

                    Dim dtDatos As New DataTable
                    Dim dtTimbrado As New DataTable
                    Dim Mensaje As String = Nothing

                    dtTimbrado = objBU.ValidarTimbrado(objFiltros)
                    If dtTimbrado.Rows.Count = 0 Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Las vacaciones y/o aguinaldo fiscal aun no esta timbrado")
                        Me.Cursor = Cursors.Default
                        Return
                    End If

                    dtDatos = objBU.AutorizarPercepciones(objFiltros)

                    If dtDatos.Rows.Count > 0 Then
                        Mensaje = dtDatos.Rows(0).Item("Mensaje").ToString
                    End If

                    If Mensaje = "Exito" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se autorizó correctamente el periodo")
                        limpiarGrid()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Errores, Mensaje)
                    End If

                End If
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        mnuPrint.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub
    Public Function Imprimir()
        Dim dsDatosReporte = Nothing
        Try
            If cmbNave.SelectedIndex > 0 Then
                LlenarTabla()
                Cursor = Cursors.WaitCursor
                Dim dtDatosReporte As New DataTable
                Dim advertencia As New Tools.AdvertenciaForm
                Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                Dim str1 As String
                Dim str2 As String
                Dim str3 As String
                Dim str4 As String

                dtDatosReporte = grdColaboradores.DataSource
                dtDatosReporte.TableName = "Nomina"

                If Not dtDatosReporte Is Nothing AndAlso dtDatosReporte.Columns.Count > 0 Then

                    str1 = dtDatosReporte.Columns(7).ColumnName
                    str2 = dtDatosReporte.Columns(8).ColumnName
                    str3 = dtDatosReporte.Columns(9).ColumnName
                    str4 = dtDatosReporte.Columns(10).ColumnName

                    dtDatosReporte.Columns(7).ColumnName = "46"
                    dtDatosReporte.Columns(8).ColumnName = "47"
                    dtDatosReporte.Columns(9).ColumnName = "48"
                    dtDatosReporte.Columns(10).ColumnName = "49"

                    Dim objBUReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    dsDatosReporte = New DataSet("ReporteGeneralPercepciones")
                    dsDatosReporte.Tables.Add(dtDatosReporte.Copy)

                    If Not vwColaboradores.Columns("IMPORTE VACACIONES") Is Nothing Then
                        If cmbPeriodo.Text = "NAVIDAD" Then
                            EntidadReporte = objBUReporte.LeerReporteporClave("NOM_REP_PERCEPCAJA")
                        Else
                            EntidadReporte = objBUReporte.LeerReporteporClave("NOM_REP_PERCEPCAJA_SEMANA_SANTA")
                        End If

                    Else
                        EntidadReporte = objBUReporte.LeerReporteporClave("NOM_REP_PERCEPDIC_NOVAC")
                    End If

                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    Dim Agno = 0
                    If cmbAnio.Text <> "" Then
                        Agno = cmbAnio.Text
                    End If

                    reporte.Load(archivo)
                    reporte.Compile()
                    Dim NaveId = 0
                    If cmbNave.SelectedValue > 0 Then
                        NaveId = cmbNave.SelectedValue
                    End If

                    reporte("sem1") = str1
                    reporte("sem2") = str2
                    reporte("sem3") = str3
                    reporte("sem4") = str4
                    reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(NaveId)
                    reporte("Usuario") = Usuario
                    reporte("Anio") = Agno
                    reporte.Dictionary.Clear()

                    reporte.RegData(dsDatosReporte)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()

                Else
                    advertencia.mensaje = "No hay información para imprimir."
                    advertencia.ShowDialog()
                End If
            End If
        Catch ex As Exception
        Finally
            Cursor = Cursors.Default
        End Try
    End Function

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub lblLEditarAcciones_Click(sender As Object, e As EventArgs) Handles lblLEditarAcciones.Click

    End Sub

    Private Sub btnCheques_Click(sender As Object, e As EventArgs) Handles btnCheques.Click
        If vwColaboradores.DataRowCount > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim mensajeExito As New ConfirmarForm
                Dim objFiltros As New Entidades.FiltrosCalculoPercepciones
                Dim objBU As New VacacionesBU
                Dim NaveId = 0
                Dim Agno = 0
                Dim Periodo = "NAVIDAD"

                If cmbNave.SelectedValue > 0 Then
                    NaveId = cmbNave.SelectedValue
                End If
                If cmbAnio.Text <> "" Then
                    Agno = cmbAnio.Text
                End If
                If cmbPeriodo.Text <> "" Then
                    Periodo = cmbPeriodo.Text
                End If

                With objFiltros
                    .PNaveId = NaveId
                    .PAgno = Agno
                    .PPeriodo = Periodo
                End With

                Dim dtDatos As New DataTable
                Dim Mensaje As String = Nothing
                dtDatos = objBU.ConsultaChquesAguinaldoVacaciones(objFiltros)
                grdColaboradores.DataSource = Nothing
                vwColaboradores.Columns.Clear()
                grdColaboradores.DataSource = dtDatos
                btnImprimir.Enabled = False
                diseñoGridCheques()
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message)
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub mnuPrnGeneral_Click(sender As Object, e As EventArgs) Handles mnuPrnGeneral.Click
        If vwColaboradores.RowCount > 0 Then
            Imprimir()
        End If
    End Sub

    ''' <summary>
    ''' Se cambio la forma en que muestra la lista de archivos en la vista de impresión para agruparlo por Colaborador
    ''' Modificación: Fernando Morales Castillo: 20 Marzo 2025
    ''' </summary>
    Private Sub imprimirCartas()
        Dim Colaborador As String = ""
        Dim soloVacaciones As Int32 = 0
        Dim objFiltros As New Entidades.FiltrosCalculoPercepciones
        Dim NaveId = 0
        Dim Agno = 0
        Dim Periodo = "NAVIDAD"

        If cmbNave.SelectedIndex > 0 AndAlso cmbAnio.Text <> "" Then

            Try
                'Dim dateForm As New DateForm()
                'Dim fecha As New Date
                'dateForm.mensaje = "Seleccione la fecha deseada."
                'dateForm.ShowDialog()
                'fecha = dateForm.dtpFecha.Value
                Dim dsColaboradores As New DataSet
                Dim dtColaboradoresRelacion As New DataTable
                Dim dtColaboradoresDatos As New DataTable
                Dim obj As New Nomina.Negocios.VacacionesBU
                Dim tool As New Tools.Controles
                dtColaboradoresRelacion = New DataTable("dtColaboradoresRelacion")
                With dtColaboradoresRelacion
                    .Columns.Add("nombre")
                    .Columns.Add("aguinaldo")
                    .Columns.Add("aguinaldoLetra")
                    .Columns.Add("isrAguinaldo")
                    .Columns.Add("totalAguinaldo")

                End With
                dtColaboradoresDatos = New DataTable("dtColaboradoresDatos")
                With dtColaboradoresDatos
                    .Columns.Add("nombreColaborador")
                    .Columns.Add("primVac")
                    .Columns.Add("vacaciones")
                    .Columns.Add("totalVacLetra")
                    .Columns.Add("totalVac")
                    .Columns.Add("isrVac")
                End With

                If cmbNave.SelectedValue > 0 Then
                    NaveId = cmbNave.SelectedValue
                End If
                If cmbAnio.Text <> "" Then
                    Agno = cmbAnio.Text
                End If
                If cmbPeriodo.Text <> "" Then
                    Periodo = cmbPeriodo.Text
                End If

                With objFiltros
                    .PNaveId = NaveId
                    .PAgno = Agno
                    .PPeriodo = Periodo
                End With

                Dim datos As DataTable
                datos = obj.ListaPercepcionesCarta(objFiltros)
                For Each r As DataRow In datos.Rows
                    dtColaboradoresDatos.Rows.Add("" & r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                                                 CDbl(r("prima")),
                                                 CDbl(r("vacaciones")),
                                                 " (" + tool.EnLetras(r("totalVac").ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) ",
                                                 CDbl(r("totalVac")),
                                                 CDbl(r("isrVac"))
                                                 )


                    dtColaboradoresRelacion.Rows.Add(
                        r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                        CDbl(r("Aguinaldo")),
                        " (" + tool.EnLetras(r("totalAguinaldo").ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) ",
                        CDbl(r("isrAguinaldo")),
                        CDbl(r("totalAguinaldo"))
                        )
                Next

                dsColaboradores.Tables.Add(dtColaboradoresRelacion)
                dsColaboradores.Tables.Add(dtColaboradoresDatos)
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                If cmbPeriodo.Text = "SEMANA SANTA" Then
                    EntidadReporte = OBJBU.LeerReporteporClave("NOM_PERCEP_CARTAS_SEMSA")
                Else
                    EntidadReporte = OBJBU.LeerReporteporClave("NOM_PERCEP_CARTAS")
                End If
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                '=========================================================================================
                ''''Inicia modificación
                '=========================================================================================
                If cmbPeriodo.SelectedIndex = 0 Then

                    Dim report As New StiReport
                    report.Load(archivo)
                    report.Render()
                    report.RenderedPages.Clear()

                    For index = 0 To dtColaboradoresRelacion.Rows.Count - 1
                        Dim dsColaboradoresT As New DataSet
                        Dim dtColaboradoresRelacionT As New DataTable
                        dtColaboradoresRelacionT = New DataTable("dtColaboradoresRelacion")
                        With dtColaboradoresRelacionT
                            .Columns.Add("nombre")
                            .Columns.Add("aguinaldo")
                            .Columns.Add("aguinaldoLetra")
                            .Columns.Add("isrAguinaldo")
                            .Columns.Add("totalAguinaldo")

                        End With
                        Dim dtColaboradoresDatosT As New DataTable
                        dtColaboradoresDatosT = New DataTable("dtColaboradoresDatos")
                        With dtColaboradoresDatosT
                            .Columns.Add("nombreColaborador")
                            .Columns.Add("primVac")
                            .Columns.Add("vacaciones")
                            .Columns.Add("totalVacLetra")
                            .Columns.Add("totalVac")
                            .Columns.Add("isrVac")
                        End With

                        dtColaboradoresRelacionT.Rows.Add(dtColaboradoresRelacion.Rows(index).ItemArray)
                        dtColaboradoresDatosT.Rows.Add(dtColaboradoresDatos.Rows(index).ItemArray)
                        dsColaboradoresT.Tables.Add(dtColaboradoresRelacionT)
                        dsColaboradoresT.Tables.Add(dtColaboradoresDatosT)
                        Dim reporte As New StiReport
                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte.RegData(dsColaboradoresT)
                        reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                        If cmbPeriodo.Text = "SEMANA SANTA" Then
                            reporte("fechadeldia") = "viernes, 4 de abril de 2025"
                        Else
                            reporte("fechadeldia") = "viernes, 19 de diciembre de 2025"
                        End If
                        reporte("año") = "" & Year(Now)
                        reporte.Render()

                        For Each page As Object In reporte.CompiledReport.RenderedPages
                            page.Report = report
                            page.NewGuid()
                            report.RenderedPages.Add(page)
                        Next
                    Next

                    report.Show()
                    Me.Cursor = Cursors.Default

                Else
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte.RegData(dsColaboradores)
                    reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                    If cmbPeriodo.Text = "SEMANA SANTA" Then
                        reporte("fechadeldia") = "viernes, 4 de abril de 2025"
                    Else
                        reporte("fechadeldia") = "viernes, 19 de diciembre de 2025"
                    End If
                    reporte("año") = "" & Year(Now)
                    reporte.Show()
                    Me.Cursor = Cursors.Default
                End If
                '=========================================================================================
                '''' Finaliza modificación
                '=========================================================================================

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub mnuPrnFormato_Click(sender As Object, e As EventArgs) Handles mnuPrnFormato.Click
        If vwColaboradores.RowCount > 0 Then
            imprimirCartas()
        End If
    End Sub

    Private Sub ImprimirSobresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirSobresToolStripMenuItem.Click
        Dim objFiltros As New Entidades.FiltrosCalculoPercepciones
        Dim NaveId = 0
        Dim Agno = 0
        Dim Periodo = "NAVIDAD"

        Try
            If vwColaboradores.DataRowCount > 0 Then
                Dim obj As New Nomina.Negocios.VacacionesBU
                Me.Cursor = Cursors.WaitCursor
                Dim Recibos = New DataTable("Recibos")
                With Recibos
                    .Columns.Add("iDColaborador")
                    .Columns.Add("Colaborador")
                End With
                If cmbNave.SelectedValue > 0 Then
                    NaveId = cmbNave.SelectedValue
                End If
                If cmbAnio.Text <> "" Then
                    Agno = cmbAnio.Text
                End If
                If cmbPeriodo.Text <> "" Then
                    Periodo = cmbPeriodo.Text
                End If

                With objFiltros
                    .PNaveId = NaveId
                    .PAgno = Agno
                    .PPeriodo = Periodo
                End With

                Dim datos As DataTable

                datos = obj.ListaPercepcionesCarta(objFiltros)
                For Each r As DataRow In datos.Rows
                    Recibos.Rows.Add(r("NO"), "" & r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString)
                Next

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_IMP_SOBRES")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(Recibos)
                reporte.Show()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class