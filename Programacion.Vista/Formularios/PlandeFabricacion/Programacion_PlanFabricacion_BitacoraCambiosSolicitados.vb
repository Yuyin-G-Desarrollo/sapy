Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_PlanFabricacion_BitacoraCambiosSolicitados
    Public Año As Integer
    Public Semana As Integer
    Public NaveID As Integer
    Dim NumSemana As Integer
    Dim SemanaFin As Integer
    Dim AñoFin As Integer

    Private Sub Programacion_PlanFabricacion_BitacoraCambiosSolicitados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumSemana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        lblSemanaActual.Text = CStr(NumSemana)
        lblUltimaActualizacion.Text = ""

        nudSemanaFinal.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaFinal.TextAlign = HorizontalAlignment.Center

        nudSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaInicio.TextAlign = HorizontalAlignment.Center

        consultaUltimaSemanaDelAñoInicio(DatePart(DateInterval.Year, Now))
        consultaUltimaSemanaDelAñoFin(DatePart(DateInterval.Year, Now))

        CargarNaveSegunUsuario()
    End Sub

    Private Sub CargarNaveSegunUsuario()
        Dim DTNAves As DataTable
        Dim objBU As New MovimientosPPCPBU
        DTNAves = objBU.ConsultarNavesAux()

        If DTNAves.Rows.Count > 0 Then

            DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
            cmbNave.DataSource = DTNAves
            cmbNave.ValueMember = "NaveSAYId"
            cmbNave.DisplayMember = "Nave"

        Else
            show_message("Advertencia", "No hya información para mostrar.")
        End If
    End Sub

    Private Sub consultaUltimaSemanaDelAñoInicio(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            'nudSemanaFinal.Maximum = maximoSemana
            nudSemanaInicio.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub consultaUltimaSemanaDelAñoFin(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaFinal.Maximum = maximoSemana
            'nudSemanaInicio.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New PlanFabricacionBU
        Dim dtObtieneBitacoraCambios As New DataTable


        Try
            Cursor = Cursors.WaitCursor

            grdCambiosSolicitados.DataSource = Nothing
            vwCambiosSolicitados.Columns.Clear()

            Semana = nudSemanaInicio.Value
            Año = nudAño.Value
            SemanaFin = nudSemanaFinal.Value
            AñoFin = nudAñoFin.Value

            NaveID = IIf(cmbNave.SelectedIndex <> 0, cmbNave.SelectedValue, 0)

            dtObtieneBitacoraCambios = objBU.ObtieneBitacoraCambios(NaveID, Semana, Año, SemanaFin, AñoFin)

            If dtObtieneBitacoraCambios.Rows.Count > 0 Then
                grdCambiosSolicitados.DataSource = dtObtieneBitacoraCambios
                lblUltimaActualizacion.Text = Date.Now
                DisenioGrid()
            Else
                show_message("Advertencia", "No existen solicitudes de cambio.")
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwCambiosSolicitados.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        vwCambiosSolicitados.Columns.ColumnByFieldName("Nave").Width = 80
        vwCambiosSolicitados.Columns.ColumnByFieldName("Artículo").Width = 400
        vwCambiosSolicitados.Columns.ColumnByFieldName("Pares").Width = 60
        vwCambiosSolicitados.Columns.ColumnByFieldName("Fecha Solicita").Width = 90
        vwCambiosSolicitados.Columns.ColumnByFieldName("Usuario Solicita").Width = 80
        vwCambiosSolicitados.Columns.ColumnByFieldName("Motivo Cambio").Width = 200
        vwCambiosSolicitados.Columns.ColumnByFieldName("Observaciones").Width = 400

        DiseñoGrid.AlternarColorEnFilas(vwCambiosSolicitados)
        vwCambiosSolicitados.IndicatorWidth = 30
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub vwCambiosSolicitados_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwCambiosSolicitados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If vwCambiosSolicitados.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty


            Try
                nombreReporte = "\Bitácora de cambios solicitados"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If vwCambiosSolicitados.GroupCount > 0 Then
                            vwCambiosSolicitados.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            vwCambiosSolicitados.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

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

    Private Sub nudSemanaFinal_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaFinal.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            nudSemanaInicio.Value = nudSemanaFinal.Value
        End If
    End Sub

    Private Sub nudSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaInicio.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            nudSemanaFinal.Value = nudSemanaInicio.Value
        End If
    End Sub

    Private Sub nudAñoFin_ValueChanged(sender As Object, e As EventArgs) Handles nudAñoFin.ValueChanged
        If nudAño.Value > nudAñoFin.Value Then
            nudAño.Value = nudAñoFin.Value
        End If
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            If nudSemanaFinal.Value <= nudSemanaInicio.Maximum Then
                nudSemanaInicio.Value = nudSemanaFinal.Value
            Else
                nudSemanaInicio.Value = nudSemanaInicio.Maximum
            End If
        End If
        consultaUltimaSemanaDelAñoFin(nudAñoFin.Value)
    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        If nudAño.Value > nudAñoFin.Value Then
            nudAñoFin.Value = nudAño.Value
        End If
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            If nudSemanaInicio.Value <= nudSemanaFinal.Maximum Then
                nudSemanaFinal.Value = nudSemanaInicio.Value
            Else
                nudSemanaFinal.Value = nudSemanaFinal.Maximum
            End If
        End If
        consultaUltimaSemanaDelAñoInicio(nudAño.Value)
    End Sub
End Class