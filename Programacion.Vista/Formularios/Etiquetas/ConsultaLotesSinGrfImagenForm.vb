Imports DevExpress.Export
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Public Class ConsultaLotesSinGrfImagenForm

    Dim fechaDel As Date
    Dim fechaAl As DateTime
    Dim fechasProg As Integer
    Dim sinGrf200 As Integer
    Dim sinGrf300 As Integer
    Dim sinImagen As Integer
    Dim sinLogoMarca As Integer
    Private Sub ConsultaLotesSinGrfImagenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDel.Enabled = False
        dtpFechaAl.Enabled = False
        GrdConsulta.DataSource = Nothing
        GrdVConsulta.Columns.Clear()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim datos As New DataTable
        Dim obj As New Programacion.Negocios.EtiquetasBU
        'Dim registros As Integer
        '02-07-2020
        Try
            Me.Cursor = Cursors.WaitCursor
            GrdConsulta.DataSource = Nothing
            GrdVConsulta.Columns.Clear()
            fechaDel = dtpFechaDel.Value
            fechaAl = dtpFechaAl.Value

            If chkFechasProg.Checked Then
                fechasProg = 1
            Else
                fechasProg = 0
            End If

            If chkGrf200.Checked Then
                sinGrf200 = 1
            Else
                sinGrf200 = 0
            End If

            If chkGrf300.Checked Then
                sinGrf300 = 1
            Else
                sinGrf300 = 0
            End If

            If chkSinImagen.Checked Then
                sinImagen = 1
            Else
                sinImagen = 0
            End If

            If chkSinLogoMarca.Checked Then
                sinLogoMarca = 1
            Else
                sinLogoMarca = 0
            End If

            datos = obj.ConsultaLotesSinGRFImagen(fechaDel, fechaAl, fechasProg, sinGrf200, sinGrf300, sinImagen, sinLogoMarca)
            GrdConsulta.DataSource = datos
            diseñoGrid()
            'registros = GrdVConsulta.RowCount()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Private Sub diseñoGrid()

        'GrdVConsulta.IndicatorWidth = 40

        'GrdVConsulta.Columns("BOTON").Visible = False

        GrdVConsulta.Columns("Nave").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Coleccion").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("ModeloSICY").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("ModeloSAY").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Talla").OptionsColumn.AllowEdit = False
        'GrdVConsulta.Columns("Lote").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Grafico200").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Grafico300").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Imagen").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("LogoMarcaCliente").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Estatus").OptionsColumn.AllowEdit = False
        'GrdVConsulta.Columns("Programa").OptionsColumn.AllowEdit = False
        GrdVConsulta.Columns("Temporada").OptionsColumn.AllowEdit = False

        GrdVConsulta.Columns("Nave").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Coleccion").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("ModeloSICY").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("ModeloSAY").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Talla").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        'GrdVConsulta.Columns("Lote").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Grafico200").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Grafico300").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Imagen").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("LogoMarcaCliente").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Estatus").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        'GrdVConsulta.Columns("Programa").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GrdVConsulta.Columns("Temporada").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        'GrdVConsulta.Columns("Lote").Visible = False
        'GrdVConsulta.Columns("Programa").Visible = False

        'GrdVConsulta.Columns("Programa").Caption = "F.Programa"
        GrdVConsulta.Columns("Grafico200").Caption = "Gráfico200"
        GrdVConsulta.Columns("Grafico300").Caption = "Gráfico300"


        GrdVConsulta.Columns.ColumnByFieldName("Nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Coleccion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("ModeloSICY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("ModeloSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Talla").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'GrdVConsulta.Columns.ColumnByFieldName("Lote").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Grafico200").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Grafico300").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Imagen").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("LogoMarcaCliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Estatus").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'GrdVConsulta.Columns.ColumnByFieldName("Programa").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        GrdVConsulta.Columns.ColumnByFieldName("Temporada").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        GrdVConsulta.OptionsView.EnableAppearanceEvenRow = True
        GrdVConsulta.OptionsView.EnableAppearanceOddRow = True
        GrdVConsulta.OptionsSelection.EnableAppearanceFocusedCell = True
        GrdVConsulta.OptionsSelection.EnableAppearanceFocusedRow = True
        GrdVConsulta.Appearance.SelectedRow.Options.UseBackColor = True

        'grdVDatos.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        GrdVConsulta.Appearance.EvenRow.BackColor = Color.White
        GrdVConsulta.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        GrdVConsulta.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 100, 200)
        GrdVConsulta.Appearance.FocusedRow.ForeColor = Color.White


    End Sub
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim filename As String

        Try
            If GrdVConsulta.RowCount > 0 Then
                'Ask the user where to save the file to
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True
                If SaveFileDialog.ShowDialog() = DialogResult.OK Then

                    'This is required so that excel doesn't make all the grids very small. This will export all grids space out evenly
                    GrdVConsulta.OptionsPrint.AutoWidth = True
                    GrdVConsulta.OptionsPrint.EnableAppearanceEvenRow = True
                    GrdVConsulta.OptionsPrint.PrintPreview = True
                    'Set the selected file as the filename
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    'Export the file via inbuild function
                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    GrdVConsulta.ExportToXlsx(filename, exportOptions)

                    'If the file exists (i.e. export worked), then open it
                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                show_message("Aviso", "No existen registros para exportar")
            End If

        Catch ex As Exception

        End Try
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

    Private Sub chkFechasProg_CheckedChanged(sender As Object, e As EventArgs) Handles chkFechasProg.CheckedChanged
        If chkFechasProg.Checked Then
            dtpFechaDel.Enabled = True
            dtpFechaAl.Enabled = True
        Else
            dtpFechaDel.Enabled = False
            dtpFechaAl.Enabled = False
        End If

    End Sub
End Class