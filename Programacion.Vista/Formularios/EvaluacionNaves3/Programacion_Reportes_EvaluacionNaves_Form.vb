Imports Stimulsoft.Report
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports Infragistics.Win
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Columns
Imports Tools.modMensajes

Public Class Programacion_Reportes_EvaluacionNaves_Form


    Dim dtDatosNaves As New DataTable
    Dim dtPromediosEvaluacionNaves As New DataTable
    Dim lstRenglonesEditados As New List(Of String)
    Dim lstSemanaInhabiles As New List(Of Integer)
    Dim puedeEditar As Boolean = False

#Region "CARGA INICIAL DE DATOS"

    Private Sub programacionReportesEvaluacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nsemana As Integer

        Me.WindowState = FormWindowState.Maximized
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PRG_REP_REPORTE_EVAL_NAVES", "PRG_REP_EVAL_NAVES_EDITAR") Then
            puedeEditar = True
        End If

        nudAño.Value = Now.Year

        nsemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1
        'If (Date.Now.Year = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1)Then
        lblSemanaActual.Text = nsemana
        'nudSemanaFinal.Value = nsemana
        DiseñoGridReporte()
        CargarNAves()


    End Sub

#End Region

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 25
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 93
    End Sub

    Private Sub btnImprimirPDF_Click(sender As Object, e As EventArgs) Handles btnImprimirPDF.Click

        Cursor = Cursors.WaitCursor

        If cmbNave.SelectedValue <> 0 And IsNothing(cmbNave.SelectedValue) = False Then

            Dim objBU As New Negocios.Programacion_Reportes_EvaluacionNaves_BU
            Dim dsEvaluacionNaves As New DataSet("dsEvaluacionNaves")
            Dim detalleEvaluacion As New DataTable("EvaluacionNaves")
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            detalleEvaluacion = objBU.obtenerDatosEvaluacionNaveImpresionPDF(cmbNave.SelectedValue, nudAño.Value, nudSemanaInicio.Value, nudSemanaFinal.Value)

            detalleEvaluacion.TableName = "EvaluacionNaves"
            dsEvaluacionNaves.Tables.Add(detalleEvaluacion)


            EntidadReporte = objReporte.LeerReporteporClave("PRG_IMP_EVALUACION_NAVES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport

            Dim urlImagen As String = ""
            Dim horarioEntrega As String = ""

            For Each renglon As DataRow In dtDatosNaves.Rows
                If renglon.Item("IdNave") = cmbNave.SelectedValue Then
                    urlImagen = renglon.Item("UrlLogo").ToString()
                    horarioEntrega = renglon.Item("HorarioEntrega").ToString()
                End If
            Next

            reporte.Load(archivo)
            reporte.Compile()
            reporte("EvaluacionSemanalNave") = "EvaluacionSemanalNave"
            reporte.Dictionary.Clear()
            reporte("Nave") = cmbNave.Text
            reporte("UrlImagen") = urlImagen
            reporte("HorarioEntrega") = horarioEntrega
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("Colaborador") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
            reporte("NumSemanaEncabezado") = If(Integer.Parse(nudSemanaFinal.Value) > Integer.Parse(lblSemanaActual.Text.ToString()), Integer.Parse(lblSemanaActual.Text.ToString()), Integer.Parse(nudSemanaFinal.Value))
            reporte.RegData(dsEvaluacionNaves)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Else
            
            show_message("Advertencia", "Debe seleccionar una nave.")

        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CargarNAves()
        Dim lstNavesCombo As New List(Of Entidades.Naves)
        Dim lstNavesMostrar As New List(Of Integer)
        Dim objBU As New Negocios.Programacion_Reportes_EvaluacionNaves_BU

        dtDatosNaves = objBU.ConsultaDatosNaves()

        For Each nave As DataRow In dtDatosNaves.Rows
            lstNavesMostrar.Add(nave.Item("IdNave"))
        Next

        cmbNave = Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        For Each idNave As Entidades.Naves In cmbNave.Items

            If lstNavesMostrar.Contains(idNave.PNaveSICYid) Or idNave.PNombre = "" Then
                lstNavesCombo.Add(idNave)
            End If

        Next

        cmbNave.DataSource = Nothing
        cmbNave.DataSource = lstNavesCombo
        cmbNave.ValueMember = "PNaveSICYid"
        cmbNave.DisplayMember = "PNombre"

    End Sub

    Private Sub CargarReporteParaExcel()
        Dim objBU As New Negocios.Programacion_Reportes_EvaluacionNaves_BU
        grdReporte.DataSource = objBU.obtenerDatosEvaluacionNave(cmbNave.SelectedValue, nudAño.Value, nudSemanaInicio.Value, nudSemanaFinal.Value)
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Dim nombreReporteParaExportacion As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            'CargarReporteParaExcel()
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "\ReporteEvaluacionSemanalNave"
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

                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        End If
                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                show_message("Advertencia", "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Advertencia", "No se encontro el archivo")
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim numRenglones As Integer = 0
        Dim NumSemana As Integer = 0
        Dim IdNave As Integer = 0
        Dim CapacidadPares As Integer = 0
        Dim DiasProcesoIdeal As Double = 0
        Dim ParesCancelados As Integer = 0
        Dim CalificacionEntregas As Double = 0
        Dim Confirmacion As New Tools.ConfirmarForm
        Dim objBu As New Negocios.Programacion_Reportes_EvaluacionNaves_BU
        Dim lstSemanasEditadas As New List(Of String)

        If lstRenglonesEditados.Count > 0 Then
            Confirmacion.mensaje = "¿Desea guardar los cambios?"
            If Confirmacion.ShowDialog = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                For Each celdaEditada As String In lstRenglonesEditados
                    'If lstSemanasEditadas.Contains(Integer.Parse(Split(celdaEditada, ",")(0))) = False Then
                    If lstSemanasEditadas.Contains(Split(celdaEditada, ",")(0)) = False Then
                        'lstSemanasEditadas.Add(Integer.Parse(Split(celdaEditada, ",")(0)))
                        lstSemanasEditadas.Add(Split(celdaEditada, ",")(0))
                    End If
                Next
                Try
                    numRenglones = vwReporte.RowCount
                    For renglonActual As Integer = 0 To numRenglones
                        NumSemana = vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "NumSemana")
                        IdNave = vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "IdNave")
                        If lstSemanasEditadas.Contains(IdNave.ToString() + "-" + NumSemana.ToString()) Then
                            CapacidadPares = If(IsDBNull(vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "CapacidadPares")), 0, vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "CapacidadPares"))
                            DiasProcesoIdeal = If(IsDBNull(vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "DiasProcesoIdeal")), 0, vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "DiasProcesoIdeal"))
                            ParesCancelados = If(IsDBNull(vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "ParesCancelados")), 0, vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "ParesCancelados"))
                            CalificacionEntregas = If(IsDBNull(vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "CalificacionEntregas")), 0, vwReporte.GetRowCellValue(vwReporte.GetRowHandle(renglonActual), "CalificacionEntregas"))

                            objBu.ActualizarReporte(IdNave, nudAño.Value, NumSemana, CapacidadPares, DiasProcesoIdeal, ParesCancelados, CalificacionEntregas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        End If
                    Next

                    show_message("Exito", "Se actualizaron los datos correctamente")
                    btnMostrar_Click(Nothing, Nothing)

                Catch

                    show_message("Error", "Ocurrió un error al guardar, intente de nuevo")

                End Try

            End If
        Else
            show_message("Advertencia", "No hay datos para guardar")
        End If

        Cursor = Cursors.Default

    End Sub

#Region "FUNCIONES PARA ALERTAS"
    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeAdvertencia As New ExitoForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()
        End If
    End Sub
#End Region

#Region "CONSULTA DATOS"
    Private Sub ConsultaEvaluacionNave()
        Dim objBU As New Negocios.Programacion_Reportes_EvaluacionNaves_BU
        Dim dtEvaluacionNaves As New DataTable
        Dim dtEvaluacionNavesCopia As New DataTable
        Dim dtSemanasInhabiles As New DataTable
        Dim idNavesIds As String = String.Empty
        lstSemanaInhabiles = New List(Of Integer)

        dtSemanasInhabiles = objBU.consultarSemanasInhabilesCompletas(nudAño.Value)

        For Each renglon As DataRow In dtSemanasInhabiles.Rows
            lstSemanaInhabiles.Add(renglon.Item("numSemana"))
        Next

        If cmbNave.SelectedValue <> 0 Then

            idNavesIds = cmbNave.SelectedValue.ToString()

        Else

            For Each item As Entidades.Naves In cmbNave.Items

                If item.PNaveSICYid <> 0 Then

                    If idNavesIds <> "" Then
                        idNavesIds += ","
                    End If

                    idNavesIds += item.PNaveSICYid.ToString()

                End If

            Next

        End If


        dtEvaluacionNaves = objBU.obtenerDatosEvaluacionNave(idNavesIds, nudAño.Value, nudSemanaInicio.Value, nudSemanaFinal.Value)
        grdReporte.DataSource = Nothing

        If dtEvaluacionNaves.Rows.Count > 0 Then

            dtPromediosEvaluacionNaves = objBU.obtenerPromediosEvaluacionNave(idNavesIds, nudAño.Value, nudSemanaInicio.Value, nudSemanaFinal.Value)
            grdReporte.DataSource = dtEvaluacionNaves
            DiseñoGridReporte()

        Else

            show_message("Advertencia", "No hay datos para mostrar.")

        End If

        dtEvaluacionNavesCopia = objBU.obtenerDatosEvaluacionNave(idNavesIds, nudAño.Value, nudSemanaInicio.Value, nudSemanaFinal.Value)
        'dtEvaluacionNavesCopia = dtEvaluacionNaves

        grdReporteCopia.DataSource = Nothing

        If dtEvaluacionNavesCopia.Rows.Count > 0 Then
            grdReporteCopia.DataSource = dtEvaluacionNavesCopia
            'DiseñoGridReporteCopia()
        End If
    End Sub


#End Region

#Region "DISEÑO GRID"
    Private Sub DiseñoGridReporte()
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsView.EnableAppearanceOddRow = True

        vwReporte.OptionsView.ColumnAutoWidth = False
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        vwReporte.Columns.ColumnByFieldName("Año").Visible = False
        vwReporte.Columns.ColumnByFieldName("IdNave").Visible = False

        If cmbNave.SelectedValue <> 0 And IsNothing(cmbNave.SelectedValue) = False Then

            vwReporte.Columns.ColumnByFieldName("NaveNombre").Visible = False

        Else

            vwReporte.Columns.ColumnByFieldName("NaveNombre").Visible = True

        End If

        vwReporte.Columns.ColumnByFieldName("NumSemana").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("CapacidadPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("DiasProcesoIdeal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesProgramados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesRecibidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ArticulosProgramados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("DiasLoteMasAtrasado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("DiasProcesoPromedio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ProgramasAbiertos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesAtrasados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("InventarioDias").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("ParesDevueltosInspeccion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("DevolucionesCliente").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("DevolucionesAndrea").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        vwReporte.Columns.ColumnByFieldName("CalificacionNaveSemana").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        vwReporte.Columns.ColumnByFieldName("CapacidadPares").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwReporte.Columns.ColumnByFieldName("DiasLoteMasAtrasado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        vwReporte.Columns.ColumnByFieldName("CalificacionEntregas").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        vwReporte.Columns.ColumnByFieldName("CapacidadPares").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("ParesProgramados").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("ParesRecibidos").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("DiasLoteMasAtrasado").DisplayFormat.FormatString = "N1"
        vwReporte.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("ParesAtrasados").DisplayFormat.FormatString = "N0"
        vwReporte.Columns.ColumnByFieldName("DiasProcesoIdeal").DisplayFormat.FormatString = "N1"
        vwReporte.Columns.ColumnByFieldName("DiasProcesoPromedio").DisplayFormat.FormatString = "N1"
        vwReporte.Columns.ColumnByFieldName("ProgramasAbiertos").DisplayFormat.FormatString = "N1"
        vwReporte.Columns.ColumnByFieldName("InventarioDias").DisplayFormat.FormatString = "N1"
        vwReporte.Columns.ColumnByFieldName("CalificacionNaveSemana").DisplayFormat.FormatString = "N2"
        vwReporte.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatString = "N0"

        vwReporte.ColumnPanelRowHeight = 60
        vwReporte.IndicatorWidth = 30

        vwReporte.Columns.ColumnByFieldName("NaveNombre").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("NumSemana").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ParesProgramados").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ParesRecibidos").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ArticulosProgramados").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("DiasLoteMasAtrasado").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("DiasProcesoPromedio").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ProgramasAbiertos").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ParesProceso").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ParesAtrasados").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("InventarioDias").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("ParesDevueltosInspeccion").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("DevolucionesCliente").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("DevolucionesAndrea").OptionsColumn.AllowEdit = False
        vwReporte.Columns.ColumnByFieldName("CalificacionNaveSemana").OptionsColumn.AllowEdit = False

        vwReporte.Columns.ColumnByFieldName("NumSemana").Caption = "No. " + vbCrLf + "Semana"
        vwReporte.Columns.ColumnByFieldName("NumSemana").Width = 50
        vwReporte.Columns.ColumnByFieldName("CapacidadPares").Caption = "Capacidad " + vbCrLf + "en Pares*"
        vwReporte.Columns.ColumnByFieldName("CapacidadPares").Width = 71
        vwReporte.Columns.ColumnByFieldName("DiasProcesoIdeal").Caption = "Días de " + vbCrLf + "proceso ideal*"
        vwReporte.Columns.ColumnByFieldName("DiasProcesoIdeal").Width = 80
        vwReporte.Columns.ColumnByFieldName("ParesProgramados").Caption = "Pares " + vbCrLf + "programados"
        vwReporte.Columns.ColumnByFieldName("ParesRecibidos").Caption = "Pares " + vbCrLf + "recibidos"
        vwReporte.Columns.ColumnByFieldName("ParesRecibidos").Width = 65
        vwReporte.Columns.ColumnByFieldName("ArticulosProgramados").Caption = "Cant. " + vbCrLf + "artículos " + vbCrLf + "programados"
        vwReporte.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").Caption = "Prs. a + de " + vbCrLf + "5 días"
        vwReporte.Columns.ColumnByFieldName("DiasLoteMasAtrasado").Caption = "Lote más " + vbCrLf + "atrasado " + vbCrLf + "(en días)"
        vwReporte.Columns.ColumnByFieldName("DiasLoteMasAtrasado").Width = 60
        vwReporte.Columns.ColumnByFieldName("ParesCancelados").Caption = "Pares " + vbCrLf + "cancelados*"
        vwReporte.Columns.ColumnByFieldName("DiasProcesoPromedio").Caption = "Días de " + vbCrLf + "proceso " + vbCrLf + "promedio"
        vwReporte.Columns.ColumnByFieldName("DiasProcesoPromedio").Width = 60
        vwReporte.Columns.ColumnByFieldName("ProgramasAbiertos").Caption = "Programas " + vbCrLf + "abiertos"
        vwReporte.Columns.ColumnByFieldName("ProgramasAbiertos").Width = 68
        vwReporte.Columns.ColumnByFieldName("ParesProceso").Caption = "Pares " + vbCrLf + "proceso"
        vwReporte.Columns.ColumnByFieldName("ParesProceso").Width = 57
        vwReporte.Columns.ColumnByFieldName("ParesAtrasados").Caption = "Pares " + vbCrLf + "atrasados"
        vwReporte.Columns.ColumnByFieldName("ParesAtrasados").Width = 60
        vwReporte.Columns.ColumnByFieldName("InventarioDias").Caption = "Inventario " + vbCrLf + "en días"
        vwReporte.Columns.ColumnByFieldName("InventarioDias").Width = 60
        vwReporte.Columns.ColumnByFieldName("ParesDevueltosInspeccion").Caption = "Pares " + vbCrLf + "devueltos " + vbCrLf + "durante " + vbCrLf + "inspección"
        vwReporte.Columns.ColumnByFieldName("ParesDevueltosInspeccion").Width = 75
        vwReporte.Columns.ColumnByFieldName("DevolucionesCliente").Caption = "Devoluciones " + vbCrLf + "de clientes por" + vbCrLf + " defecto"
        vwReporte.Columns.ColumnByFieldName("DevolucionesCliente").Width = 80
        vwReporte.Columns.ColumnByFieldName("DevolucionesAndrea").Caption = "Devoluciones" + vbCrLf + " Andrea"
        vwReporte.Columns.ColumnByFieldName("DevolucionesAndrea").Width = 80
        vwReporte.Columns.ColumnByFieldName("CalificacionEntregas").Caption = "Calificación de" + vbCrLf + " calidad en " + vbCrLf + "entregas*"
        vwReporte.Columns.ColumnByFieldName("CalificacionEntregas").Width = 80
        vwReporte.Columns.ColumnByFieldName("CalificacionNaveSemana").Caption = "Calificación"
        vwReporte.Columns.ColumnByFieldName("CalificacionNaveSemana").Width = 70

        If IsNothing(vwReporte.Columns("CapacidadPares").Summary.FirstOrDefault(Function(x) x.FieldName = "CapacidadPares")) = True Then
            vwReporte.Columns("CapacidadPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CapacidadPares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "CapacidadPares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("ParesProgramados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesProgramados")) = True Then
            vwReporte.Columns("ParesProgramados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesProgramados", "{0:N0}")
            Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
            item2.FieldName = "ParesProgramados"
            item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item2.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item2)
        End If

        If IsNothing(vwReporte.Columns("ParesRecibidos").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesRecibidos")) = True Then
            vwReporte.Columns("ParesRecibidos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesRecibidos", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ParesRecibidos"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("DiasProcesoPromedio").Summary.FirstOrDefault(Function(x) x.FieldName = "DiasProcesoPromedio")) = True Then
            vwReporte.Columns("DiasProcesoPromedio").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "DiasProcesoPromedio", "{0:N1}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DiasProcesoPromedio"
            item.SummaryType = DevExpress.Data.SummaryItemType.Custom
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("ArticulosProgramados").Summary.FirstOrDefault(Function(x) x.FieldName = "ArticulosProgramados")) = True Then
            vwReporte.Columns("ArticulosProgramados").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "ArticulosProgramados", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ArticulosProgramados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Custom
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("ParesEntregadosMasCincoDias").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesEntregadosMasCincoDias")) = True Then
            vwReporte.Columns("ParesEntregadosMasCincoDias").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesEntregadosMasCincoDias", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ArticulosProgramados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("ParesCancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesCancelados")) = True Then
            vwReporte.Columns("ParesCancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesCancelados", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ParesCancelados"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("ParesDevueltosInspeccion").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesDevueltosInspeccion")) = True Then
            vwReporte.Columns("ParesDevueltosInspeccion").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesDevueltosInspeccion", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "ParesDevueltosInspeccion"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("DevolucionesCliente").Summary.FirstOrDefault(Function(x) x.FieldName = "DevolucionesCliente")) = True Then
            vwReporte.Columns("DevolucionesCliente").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DevolucionesCliente", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DevolucionesCliente"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("DevolucionesAndrea").Summary.FirstOrDefault(Function(x) x.FieldName = "DevolucionesAndrea")) = True Then
            vwReporte.Columns("DevolucionesAndrea").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DevolucionesAndrea", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DevolucionesAndrea"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("CalificacionEntregas").Summary.FirstOrDefault(Function(x) x.FieldName = "CalificacionEntregas")) = True Then
            vwReporte.Columns("CalificacionEntregas").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "CalificacionEntregas", "{0:N1}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "CalificacionEntregas"
            item.SummaryType = DevExpress.Data.SummaryItemType.Custom
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If

        If IsNothing(vwReporte.Columns("CalificacionNaveSemana").Summary.FirstOrDefault(Function(x) x.FieldName = "CalificacionNaveSemana")) = True Then
            vwReporte.Columns("CalificacionNaveSemana").Summary.Add(DevExpress.Data.SummaryItemType.Custom, "CalificacionNaveSemana", "{0:N2}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "CalificacionNaveSemana"
            item.SummaryType = DevExpress.Data.SummaryItemType.Custom
            item.DisplayFormat = "{0}"
            vwReporte.GroupSummary.Add(item)
        End If
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwReporte_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles vwReporte.ShowingEditor
        Dim view As GridView = sender
        If puedeEditar = True Then

            If vwReporte.RowCount > 0 Then
                If (view.FocusedColumn.FieldName = "CapacidadPares" Or view.FocusedColumn.FieldName = "DiasProcesoIdeal" Or view.FocusedColumn.FieldName = "ParesCancelados" Or view.FocusedColumn.FieldName = "CalificacionEntregas") And verificarSemana(view, view.FocusedRowHandle) Then
                    e.Cancel = True
                End If
            End If

        Else
            e.Cancel = True
        End If
    End Sub

    Private Function verificarSemana(ByVal view As GridView, ByVal row As Integer) As Boolean
        Dim col As GridColumn = view.Columns("NumSemana")
        Dim val As Boolean = If(Integer.Parse(view.GetRowCellValue(row, col)) < Integer.Parse(lblSemanaActual.Text) Or nudAño.Value < DatePart(DateInterval.Year, Date.Now) Or lstSemanaInhabiles.Contains(Integer.Parse(view.GetRowCellValue(row, col))), True, False)
        Return val
    End Function

    Private Sub vwReporte_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles vwReporte.RowCellStyle
        Dim view As GridView = sender
        If vwReporte.RowCount > 0 And e.RowHandle >= 0 Then
            If (e.Column.FieldName = "CapacidadPares" Or e.Column.FieldName = "DiasProcesoIdeal" Or e.Column.FieldName = "ParesCancelados" Or e.Column.FieldName = "CalificacionEntregas") And verificarSemana(view, e.RowHandle) = False Then
                If If(IsDBNull(e.CellValue), 0, e.CellValue) = If(IsDBNull(vwReporteCopia.GetRowCellValue(e.RowHandle, e.Column.FieldName)), 0, vwReporteCopia.GetRowCellValue(e.RowHandle, e.Column.FieldName)) Then
                    e.Appearance.ForeColor = Color.Black
                    'If lstRenglonesEditados.Contains(vwReporte.GetRowCellValue(e.RowHandle, "NumSemana").ToString() + "," + e.Column.FieldName) = True Then
                    '    lstRenglonesEditados.Remove(vwReporte.GetRowCellValue(e.RowHandle, "NumSemana").ToString() + "," + e.Column.FieldName)
                    'End If
                    If lstRenglonesEditados.Contains(vwReporte.GetRowCellValue(e.RowHandle, "IdNave").ToString() + "-" + vwReporte.GetRowCellValue(e.RowHandle, "NumSemana").ToString() + "," + e.Column.FieldName) = True Then
                        lstRenglonesEditados.Remove(vwReporte.GetRowCellValue(e.RowHandle, "IdNave").ToString() + "-" + vwReporte.GetRowCellValue(e.RowHandle, "NumSemana").ToString() + "," + e.Column.FieldName)
                    End If
                Else
                    e.Appearance.ForeColor = Color.Purple
                    If lstRenglonesEditados.Contains(vwReporte.GetRowCellValue(e.RowHandle, "IdNave").ToString() + "-" + vwReporte.GetRowCellValue(e.RowHandle, "NumSemana").ToString() + "," + e.Column.FieldName) = False Then
                        lstRenglonesEditados.Add(vwReporte.GetRowCellValue(e.RowHandle, "IdNave").ToString() + "-" + vwReporte.GetRowCellValue(e.RowHandle, "NumSemana").ToString() + "," + e.Column.FieldName)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub vwReporte_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle
        Dim view As GridView = sender
        If lstSemanaInhabiles.Contains(vwReporte.GetRowCellValue(e.RowHandle, "NumSemana")) Then
            'e.Appearance.Font = lblSemanaNoLaboral.Font
            e.Appearance.ForeColor = lblSemanaNoLaboral.ForeColor
        End If
    End Sub

    Private Sub vwReporte_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles vwReporte.CustomSummaryCalculate

        If e.Item.FieldName = "DiasProcesoPromedio" Then
            e.TotalValue = dtPromediosEvaluacionNaves.Rows(0)("PromedioDiasProceso")
        End If

        If e.Item.FieldName = "CalificacionEntregas" Then
            e.TotalValue = dtPromediosEvaluacionNaves.Rows(0)("PromedioCalificacionCalidad")
        End If

        If e.Item.FieldName = "CalificacionNaveSemana" Then
            e.TotalValue = dtPromediosEvaluacionNaves.Rows(0)("PromedioCalificacionNave")
        End If

        If e.Item.FieldName = "CalificacionNaveSemana" Then
            e.TotalValue = dtPromediosEvaluacionNaves.Rows(0)("PromedioCalificacionNave")
        End If

        If e.Item.FieldName = "ArticulosProgramados" Then
            e.TotalValue = dtPromediosEvaluacionNaves.Rows(0)("PromedioArticulosProgramados")
        End If

    End Sub

#End Region

#Region "DISEÑO GRID COPIA"
    Private Sub DiseñoGridReporteCopia()

        'vwReporteCopia.OptionsView.ColumnAutoWidth = False
        'For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporteCopia.Columns
        '    col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        'Next
        'vwReporteCopia.Columns.ColumnByFieldName("Año").Visible = False
        'vwReporteCopia.Columns.ColumnByFieldName("IdNave").Visible = False

        'vwReporteCopia.Columns.ColumnByFieldName("NumSemana").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("CapacidadPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoIdeal").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProgramados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesRecibidos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ArticulosProgramados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("DiasLoteMasAtrasado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesCancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoPromedio").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ProgramasAbiertos").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesAtrasados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("InventarioDias").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("ParesDevueltosInspeccion").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("DevolucionesCliente").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionEntregas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionNaveSemana").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        'vwReporteCopia.Columns.ColumnByFieldName("CapacidadPares").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'vwReporteCopia.Columns.ColumnByFieldName("DiasLoteMasAtrasado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionEntregas").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        'vwReporteCopia.Columns.ColumnByFieldName("CapacidadPares").DisplayFormat.FormatString = "N0"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProgramados").DisplayFormat.FormatString = "N0"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesRecibidos").DisplayFormat.FormatString = "N0"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").DisplayFormat.FormatString = "N0"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProceso").DisplayFormat.FormatString = "N0"
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoIdeal").DisplayFormat.FormatString = "N1"
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoPromedio").DisplayFormat.FormatString = "N1"
        'vwReporteCopia.Columns.ColumnByFieldName("ProgramasAbiertos").DisplayFormat.FormatString = "N1"
        'vwReporteCopia.Columns.ColumnByFieldName("InventarioDias").DisplayFormat.FormatString = "N1"
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionNaveSemana").DisplayFormat.FormatString = "N1"

        'vwReporteCopia.ColumnPanelRowHeight = 45
        'vwReporteCopia.IndicatorWidth = 30

        'vwReporteCopia.Columns.ColumnByFieldName("NumSemana").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProgramados").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ParesRecibidos").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ArticulosProgramados").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("DiasLoteMasAtrasado").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoPromedio").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ProgramasAbiertos").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProceso").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ParesAtrasados").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("InventarioDias").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("ParesDevueltosInspeccion").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("DevolucionesCliente").OptionsColumn.AllowEdit = False
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionNaveSemana").OptionsColumn.AllowEdit = False

        'vwReporteCopia.Columns.ColumnByFieldName("NumSemana").Caption = "No." + vbCrLf + "Semana"
        'vwReporteCopia.Columns.ColumnByFieldName("NumSemana").Width = 50
        'vwReporteCopia.Columns.ColumnByFieldName("CapacidadPares").Caption = "Capacidad" + vbCrLf + "en Pares*"
        'vwReporteCopia.Columns.ColumnByFieldName("CapacidadPares").Width = 75
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoIdeal").Caption = "Días de " + vbCrLf + "proceso ideal*"
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoIdeal").Width = 80
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProgramados").Caption = "Pares" + vbCrLf + "programados"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesRecibidos").Caption = "Pares" + vbCrLf + "recibidos"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesRecibidos").Width = 65
        'vwReporteCopia.Columns.ColumnByFieldName("ArticulosProgramados").Caption = "Cant." + vbCrLf + "artículos" + vbCrLf + "programados"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesEntregadosMasCincoDias").Caption = "Prs. a + de" + vbCrLf + "5 días"
        'vwReporteCopia.Columns.ColumnByFieldName("DiasLoteMasAtrasado").Caption = "Lote más" + vbCrLf + "atrasado" + vbCrLf + "(en días)"
        'vwReporteCopia.Columns.ColumnByFieldName("DiasLoteMasAtrasado").Width = 65
        'vwReporteCopia.Columns.ColumnByFieldName("ParesCancelados").Caption = "Pares" + vbCrLf + "cancelados*"
        'vwReporteCopia.Columns.ColumnByFieldName("DiasProcesoPromedio").Caption = "Días de " + vbCrLf + "proceso" + vbCrLf + "promedio"
        'vwReporteCopia.Columns.ColumnByFieldName("ProgramasAbiertos").Caption = "Programas" + vbCrLf + "abiertos"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProceso").Caption = "Pares" + vbCrLf + "proceso"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesProceso").Width = 60
        'vwReporteCopia.Columns.ColumnByFieldName("ParesAtrasados").Caption = "Pares" + vbCrLf + "atrasados"
        'vwReporteCopia.Columns.ColumnByFieldName("InventarioDias").Caption = "Inventario" + vbCrLf + "en días"
        'vwReporteCopia.Columns.ColumnByFieldName("InventarioDias").Width = 60
        'vwReporteCopia.Columns.ColumnByFieldName("ParesDevueltosInspeccion").Caption = "Pares devueltos" + vbCrLf + "durante" + vbCrLf + "inspección"
        'vwReporteCopia.Columns.ColumnByFieldName("ParesDevueltosInspeccion").Width = 90
        'vwReporteCopia.Columns.ColumnByFieldName("DevolucionesCliente").Caption = "Devoluciones" + vbCrLf + "de clientes por" + vbCrLf + "defecto"
        'vwReporteCopia.Columns.ColumnByFieldName("DevolucionesCliente").Width = 80
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionEntregas").Caption = "Calificación de" + vbCrLf + "calidad en " + vbCrLf + "entregas*"
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionEntregas").Width = 80
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionNaveSemana").Caption = "Calificación" + vbCrLf + "actual"
        'vwReporteCopia.Columns.ColumnByFieldName("CalificacionNaveSemana").Width = 95

        'If IsNothing(vwReporte.Columns("CapacidadPares").Summary.FirstOrDefault(Function(x) x.FieldName = "CapacidadPares")) = True Then
        '    vwReporte.Columns("CapacidadPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CapacidadPares", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "CapacidadPares"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporte.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporte.Columns("ParesProgramados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesProgramados")) = True Then
        '    vwReporte.Columns("ParesProgramados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesProgramados", "{0:N0}")
        '    Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item2.FieldName = "ParesProgramados"
        '    item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item2.DisplayFormat = "{0}"
        '    vwReporte.GroupSummary.Add(item2)
        'End If

        'If IsNothing(vwReporte.Columns("ParesRecibidos").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesRecibidos")) = True Then
        '    vwReporte.Columns("ParesRecibidos").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesRecibidos", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "ParesRecibidos"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporte.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("DiasProcesoPromedio").Summary.FirstOrDefault(Function(x) x.FieldName = "DiasProcesoPromedio")) = True Then
        '    vwReporteCopia.Columns("DiasProcesoPromedio").Summary.Add(DevExpress.Data.SummaryItemType.Average, "DiasProcesoPromedio", "{0:N1}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "DiasProcesoPromedio"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Average
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("ArticulosProgramados").Summary.FirstOrDefault(Function(x) x.FieldName = "ArticulosProgramados")) = True Then
        '    vwReporteCopia.Columns("ArticulosProgramados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ArticulosProgramados", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "ArticulosProgramados"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("ParesEntregadosMasCincoDias").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesEntregadosMasCincoDias")) = True Then
        '    vwReporteCopia.Columns("ParesEntregadosMasCincoDias").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesEntregadosMasCincoDias", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "ArticulosProgramados"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("ParesCancelados").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesCancelados")) = True Then
        '    vwReporteCopia.Columns("ParesCancelados").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesCancelados", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "ParesCancelados"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("ParesDevueltosInspeccion").Summary.FirstOrDefault(Function(x) x.FieldName = "ParesDevueltosInspeccion")) = True Then
        '    vwReporteCopia.Columns("ParesDevueltosInspeccion").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesDevueltosInspeccion", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "ParesDevueltosInspeccion"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("DevolucionesCliente").Summary.FirstOrDefault(Function(x) x.FieldName = "DevolucionesCliente")) = True Then
        '    vwReporteCopia.Columns("DevolucionesCliente").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DevolucionesCliente", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "DevolucionesCliente"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("CalificacionEntregas").Summary.FirstOrDefault(Function(x) x.FieldName = "CalificacionEntregas")) = True Then
        '    vwReporteCopia.Columns("CalificacionEntregas").Summary.Add(DevExpress.Data.SummaryItemType.Average, "CalificacionEntregas", "{0:N1}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "CalificacionEntregas"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Average
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If

        'If IsNothing(vwReporteCopia.Columns("CalificacionNaveSemana").Summary.FirstOrDefault(Function(x) x.FieldName = "CalificacionNaveSemana")) = True Then
        '    vwReporteCopia.Columns("CalificacionNaveSemana").Summary.Add(DevExpress.Data.SummaryItemType.Average, "CalificacionNaveSemana", "{0:N1}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "CalificacionNaveSemana"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Average
        '    item.DisplayFormat = "{0}"
        '    vwReporteCopia.GroupSummary.Add(item)
        'End If
    End Sub

#End Region


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        'If cmbNave.SelectedIndex > 0 Then
        Cursor.Current = Cursors.WaitCursor
        lstRenglonesEditados = New List(Of String)
        'If ValidarFormulario() Then
        ConsultaEvaluacionNave()
        'End If
        Cursor.Current = Cursors.Default
        'Else
        'show_message("Advertencia", "Debe seleccionar una nave.")
        'End If
    End Sub



    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        Dim nsemana As Integer
        nsemana = DateDiff(DateInterval.WeekOfYear, CDate("31/12/" + nudAño.Value.ToString()), New DateTime(nudAño.Value, 1, 1)) * -1
        nudSemanaInicio.Minimum = 1
        nudSemanaInicio.Maximum = nsemana
        nudSemanaFinal.Minimum = 1
        nudSemanaFinal.Maximum = nsemana
        nudSemanaFinal.Value = nsemana - 1
    End Sub

    Private Sub nudSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaInicio.ValueChanged
        nudSemanaFinal.Minimum = nudSemanaInicio.Value
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged

        grdReporte.DataSource = Nothing
        grdReporteCopia.DataSource = Nothing

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/PPCP/", "Descargas\Manuales\PPCP", "PPCP_MAUS_Reporte_Evaluacion_Naves_V1.pdf")
            Process.Start("Descargas\Manuales\PPCP\PPCP_MAUS_Reporte_Evaluacion_Naves_V1.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnActualizarTodasNaves_Click(sender As Object, e As EventArgs) Handles btnActualizarTodasNaves.Click
        Dim ConfirmarAccion As New Tools.ConfirmarForm
        ConfirmarAccion.mensaje = "El proceso de actualización puede tardar varios minutos ¿Desea continuar?"
        If ConfirmarAccion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor.Current = Cursors.WaitCursor
            Dim objBU As New Negocios.Programacion_Reportes_EvaluacionNaves_BU
            Dim dtResultado As New DataTable()
            dtResultado = objBU.actualizaTodaslasNaves()
            show_message(dtResultado.Rows(0).Item("TipoMensaje"), dtResultado.Rows(0).Item("Mensaje"))
            btnMostrar_Click(sender, e)
        End If
        Cursor.Current = Cursors.Default
    End Sub

End Class

