Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports Produccion.Negocios
Imports Tools
Imports DevExpress


Public Class AdministradorArchivosTecnicosForm

    Public vIdProductoEstilo As Integer
    Public vIdNave As Integer
    Public vDescripcion As String
    Public vFormAdministradorArchivos As AdministradorArchivosForm
    Private Sub AdministradorArchivosTecnicosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        lblDes.Text = vDescripcion
        CargarDatos()

    End Sub

    Public Sub CargarDatos()
        Dim obj As New AdministradorArchivosBU
        Dim dtArchivos As DataTable
        Try
            dtArchivos = obj.ObtenerAdministradorArchivosTecnicos(vIdProductoEstilo, vIdNave)
            grdArchivosTecnicos.DataSource = dtArchivos
            AgregarBoton()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub vwArchivosTecnicos_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles vwArchivosTecnicos.CustomRowCellEdit
        If (e.Column.FieldName = "Icono") Then
            Dim editor As New RepositoryItemButtonEdit
            editor.Assign(e.RepositoryItem)
            e.RepositoryItem = editor
            editor.Buttons(0).Image = Produccion.Vista.My.Resources.descargab
        End If
    End Sub

    Private Sub AgregarBoton()
        If vwArchivosTecnicos Is Nothing Then Exit Sub
        If vwArchivosTecnicos.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdArchivosTecnicos.RepositoryItems.Add(_RIButton)

        vwArchivosTecnicos.Columns("Icono").ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        vwArchivosTecnicos.Columns("Icono").UnboundType = DevExpress.Data.UnboundColumnType.Object
        vwArchivosTecnicos.Columns("Icono").ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Width = vwArchivosTecnicos.Columns("Icono").Width - (vwArchivosTecnicos.Columns("Icono").Width / 13)

        AddHandler _RIButton.ButtonClick, AddressOf Icono_Click

    End Sub

    Private Sub Icono_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Dim vRutaOrigen As String = String.Empty
        Dim vRutaDestino As String = String.Empty
        Dim vArchivo As String = String.Empty

        Try
            NumeroFilas = vwArchivosTecnicos.DataRowCount
            vRutaDestino = "Descargas\Produccion\FichasTecnicas"
            vRutaOrigen = "/Produccion/FichasTecnicas/"
            For index As Integer = 0 To NumeroFilas Step 1
                If vwArchivosTecnicos.IsRowSelected(vwArchivosTecnicos.GetVisibleRowHandle(index)) Then
                    vArchivo = vwArchivosTecnicos.GetRowCellValue(vwArchivosTecnicos.GetVisibleRowHandle(index), "Documento") + vwArchivosTecnicos.GetRowCellValue(vwArchivosTecnicos.GetVisibleRowHandle(index), "TipoDocumento")
                    Dim objFTP As New Tools.TransferenciaFTP
                    objFTP.DescargarArchivo(vRutaOrigen, vRutaDestino, vArchivo)
                    Process.Start(vRutaDestino + "\" + vArchivo)
                End If
            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        nombreReporte = "AdministradorArchivosTecnicos"

        Try
            Cursor = Cursors.WaitCursor

            If vwArchivosTecnicos.DataRowCount > 0 Then

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwArchivosTecnicos.GroupCount > 0 Then
                            vwArchivosTecnicos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwArchivosTecnicos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If

                        Dim FormaError As New ExitoForm
                        FormaError.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        FormaError.ShowDialog()

                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Dim FormaError As New AdvertenciaForm
                FormaError.mensaje = "No hay datos para exportar"
                FormaError.ShowDialog()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Dim FormaError As New AdvertenciaForm
            FormaError.mensaje = "No se encontro el archivo"
            FormaError.ShowDialog()
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim vNum = vwArchivosTecnicos.DataRowCount
        Dim vIdArchivo As Integer = 0
        Dim vDocumento As String = String.Empty
        Dim vIdCategoria As Integer = 0
        Dim vNombreArchivo As String = String.Empty
        Dim vTipoDocumento As String = String.Empty

        If vwArchivosTecnicos.FocusedRowHandle >= 0 Then
            For item As Integer = 0 To vNum Step 1
                If CBool(vwArchivosTecnicos.IsRowSelected(vwArchivosTecnicos.GetVisibleRowHandle(item))) = True Then
                    vIdArchivo = vwArchivosTecnicos.GetRowCellValue(item, "IdArchivo").ToString()
                    vDocumento = vwArchivosTecnicos.GetRowCellValue(item, "Documento").ToString()
                    vIdCategoria = vwArchivosTecnicos.GetRowCellValue(item, "IdDepartamento").ToString()
                    vNombreArchivo = vwArchivosTecnicos.GetRowCellValue(item, "NombreArchivo").ToString()
                    vTipoDocumento = vwArchivosTecnicos.GetRowCellValue(item, "TipoDocumento").ToString()
                End If
            Next
            Dim form As New AltaDocumentosProduccion_Form
            form.vIdArchivo = vIdArchivo
            form.vDocumento = vDocumento
            form.vIdCategoria = vIdCategoria
            form.vEsDepto = True
            form.vNombreDocumento = vNombreArchivo
            form.vTipoDocumento = vTipoDocumento
            form.vAdmonArchivosTecnicos = Me
            form.ShowDialog()
        Else
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Seleccione un archivo"
            FormaError.ShowDialog()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim vNum = vwArchivosTecnicos.DataRowCount
        Dim vIdArchivo As Integer
        Dim obj As New AdministradorArchivosBU
        Dim obA As New TransferenciaFTP
        Dim vNumArchivos As Integer
        Dim vNombreArchivo As String
        Cursor = Cursors.WaitCursor

        Try

            If vwArchivosTecnicos.FocusedRowHandle >= 0 Then
                For item As Integer = 0 To vNum Step 1
                    If CBool(vwArchivosTecnicos.IsRowSelected(vwArchivosTecnicos.GetVisibleRowHandle(item))) = True Then
                        vIdArchivo = vwArchivosTecnicos.GetRowCellValue(item, "IdArchivo").ToString()
                        vNumArchivos = obj.EliminarArchivosTecnicosOtros(vIdArchivo, vIdNave, vIdProductoEstilo, False)
                        vNombreArchivo = vwArchivosTecnicos.GetRowCellValue(item, "Documento").ToString() + vwArchivosTecnicos.GetRowCellValue(item, "TipoDocumento").ToString()

                        'If vNumArchivos = 1 Then
                        obA.BorraArchivo("Produccion/FichasTecnicas", vNombreArchivo)
                        'End If

                    End If
                Next
            End If

            Dim FormaError As New ExitoForm
            FormaError.mensaje = "El archivo fue eliminado"
            FormaError.ShowDialog()
            Cursor = Cursors.Default

            CargarDatos()



        Catch ex As Exception
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Error al eliminar archivo"
            FormaError.ShowDialog()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        btnEliminar_Click(Nothing, Nothing)
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        btnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub grdArchivosTecnicos_MouseClick(sender As Object, e As MouseEventArgs) Handles grdArchivosTecnicos.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub vwArchivosTecnicos_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwArchivosTecnicos.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub AdministradorArchivosTecnicosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        vFormAdministradorArchivos.btnMostrar_Click(Nothing, Nothing)
    End Sub


End Class