Imports Tools
Imports Framework.Negocios
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting

Imports DevExpress.XtraReports.UI

Public Class Nomina_ControlAsistenciaExternos_Form
    Dim idNave As Integer = 0
    Dim dias() As String
    Dim fechaDias() As String
    Dim periodoNomina As Integer = 0
    Private Sub CargarNaves()
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        If cmbNave.SelectedIndex > 0 Then
            idNave = cmbNave.SelectedValue
        End If
    End Sub


    Private Sub listarPeriodosAsistencia()
        Try
            Controles.ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(cmbPeriodo, CInt(cmbNave.SelectedValue.ToString))
            Dim ControlDelPeriodoBu As New Negocios.ControlDePeriodoBU
            Dim PeriodoNominaID As Integer = CInt(ControlDelPeriodoBu.periodoSegunNaveSegunAsistenciaActual(CInt(cmbNave.SelectedValue.ToString)).Rows(0).Item(0).ToString)

            cmbPeriodo.SelectedValue = PeriodoNominaID
            cmbPeriodo.SelectedItem = cmbPeriodo.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        mostrarConsultaRegistros()
    End Sub

    Private Sub mostrarConsultaRegistros()
        Dim periodoRango As New Entidades.PeriodosNomina
        Dim ControlDePeriodoBU As New Negocios.ControlDePeriodoBU
        Dim ControlAsistenciaBU As New Negocios.ControlAsistenciaBU
        Dim dtConsultaRegistros As New DataTable
        Dim periodoNomina As String = ""
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim advertencia As New AdvertenciaForm

        Cursor = Cursors.WaitCursor
        grdCntrlAsistencia.DataSource = Nothing
        MVAsistencia.Columns.Clear()

        If cmbPeriodo.SelectedValue > 0 Then
            Cursor = Cursors.WaitCursor
            grdCntrlAsistencia.DataSource = Nothing
            periodoNomina = cmbPeriodo.SelectedValue
            periodoRango = ControlDePeriodoBU.buscarRangosPeriodoSegunNaveSegunAsistencia(periodoNomina)
            fechaInicio = periodoRango.FechaInicio
            fechaFin = periodoRango.FechaFin
            dtConsultaRegistros = ControlAsistenciaBU.colaboradorExternoListaAsistencia(idNave, periodoNomina)
            If dtConsultaRegistros.Rows.Count > 0 Then
                grdCntrlAsistencia.DataSource = dtConsultaRegistros
                DiseñoGrid()
            End If
        Else
            advertencia.mensaje = "Seleccione una Nave"
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub DiseñoGrid()
        MVAsistencia.OptionsView.ColumnAutoWidth = False
        MVAsistencia.OptionsView.AllowCellMerge = True

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVAsistencia.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center


            If col.FieldName <> "Colaborador" And col.FieldName <> "Tipo" Then
                MVAsistencia.Columns.ColumnByFieldName(col.FieldName).Width = 155
                MVAsistencia.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowEdit = False
            End If

            If col.FieldName <> "Colaborador" Then
                MVAsistencia.Columns.ColumnByFieldName(col.FieldName).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End If
        Next

        MVAsistencia.Columns.ColumnByFieldName("Colaborador").Width = 310
        MVAsistencia.Columns.ColumnByFieldName("Tipo").Width = 100

        MVAsistencia.Columns.ColumnByFieldName("Colaborador").Caption = "Colaborador"
        MVAsistencia.Columns.ColumnByFieldName("Tipo").Caption = "Registro"

        MVAsistencia.Columns.ColumnByFieldName("Colaborador").OptionsColumn.AllowEdit = False
        MVAsistencia.Columns.ColumnByFieldName("Tipo").OptionsColumn.AllowEdit = False



    End Sub

    Private Sub ListaControlAsistenciaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        WindowState = FormWindowState.Maximized
        CargarNaves()
    End Sub

    Private Sub cmbNave_DropDownClosed(sender As Object, e As EventArgs) Handles cmbNave.DropDownClosed
        idNave = cmbNave.SelectedValue
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        listarPeriodosAsistencia()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Cursor = Cursors.WaitCursor
        grdCntrlAsistencia.DataSource = Nothing
        MVAsistencia.Columns.Clear()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs)
        grpParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs)
        grpParametros.Height = 141
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fdbUbicacionArchivo As New FolderBrowserDialog

        Try
            With fdbUbicacionArchivo
                .Reset()
                .Description = "Seleccione una Carpeta"
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    grdCntrlAsistencia.ExportToXlsx(.SelectedPath + "\Datos_Asistencia_" + fecha_hora + ".xlsx")
                Else
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                    grdCntrlAsistencia.ExportToXlsx(.SelectedPath + "\Datos_Asistencia_" + fecha_hora + ".xlsx", exportOptions)
                    show_message("Exito", "Los datos se exportaron correctamente: " & "\Datos_Asistencia_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fdbUbicacionArchivo.SelectedPath + "\Datos_OrdenTrabajo_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

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

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Dim ColaboradorId As String = MVAsistencia.GetRowCellValue(e.RowHandle, "Colaborador")
        Dim Tipo As String = MVAsistencia.GetRowCellValue(e.RowHandle, "Tipo")

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVAsistencia.Columns
            If col.FieldName <> "Colaborador" And col.FieldName <> "Tipo" Then
                MVAsistencia.GetRowCellValue(e.RowHandle, col.FieldName)
            End If
        Next

        Dim index As Integer = 0
        Try

            If e.ColumnFieldName = "Tipo" Then
                e.Formatting.BackColor = obtenerColorTipo(MVAsistencia.GetRowCellValue(e.RowHandle, "Tipo"))
            End If

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
        e.Handled = True
    End Sub

    Private Function obtenerColorTipo(ByVal Tipo As String) As Color
        Dim TipoColor As Color

        If Tipo = "E1" Then
            TipoColor = Color.LightSteelBlue
        ElseIf Tipo = "S1" Then
            TipoColor = Color.LightSeaGreen
        ElseIf Tipo = "E2" Then
            TipoColor = Color.LightSteelBlue
        ElseIf Tipo = "S2" Then
            TipoColor = Color.LightSeaGreen
        End If

        Return TipoColor

    End Function

End Class