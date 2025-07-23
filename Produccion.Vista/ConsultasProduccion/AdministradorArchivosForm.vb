Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports Produccion.Negocios
Imports Tools
Imports DevExpress

Public Class AdministradorArchivosForm
    Dim vIdNave As Integer
    Private Sub AdministradorArchivosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
        CargarNAves()

        If rbFichasTecnicas.Checked = True Then
            grdFichasTecnicas.Visible = True
            pnlOT.Visible = False
        Else
            grdOtrosArchivos.Visible = True
            pnlOT.Visible = True
        End If
    End Sub

    Private Sub CargarNAves()

        Dim lstNavesCombo As New List(Of Entidades.Naves)
        Dim lstNavesMostrar As New List(Of Integer)
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        cmbNave.ValueMember = "PNaveId"
        cmbNave.DisplayMember = "PNombre"

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim vNum = vwOtrosArchivos.DataRowCount
        Dim vIdArchivo As Integer
        Dim vIdNave As Integer
        Dim obj As New AdministradorArchivosBU
        Dim obA As New TransferenciaFTP
        Dim vNumArchivos As Integer
        Dim vNombreArchivo As String
        Cursor = Cursors.WaitCursor

        Try
            vIdNave = IIf(cmbNave.Text <> "", cmbNave.SelectedValue, Nothing)

            If vwOtrosArchivos.FocusedRowHandle >= 0 Then
                For item As Integer = 0 To vNum Step 1
                    If CBool(vwOtrosArchivos.IsRowSelected(vwOtrosArchivos.GetVisibleRowHandle(item))) = True Then
                        vIdArchivo = vwOtrosArchivos.GetRowCellValue(item, "IdArchivo").ToString()
                        vNumArchivos = obj.EliminarArchivosTecnicosOtros(vIdArchivo, vIdNave, Nothing, rbOtrosArchivos.Checked)
                        vNombreArchivo = vwOtrosArchivos.GetRowCellValue(item, "Documento").ToString() + vwOtrosArchivos.GetRowCellValue(item, "TipoDocumento").ToString()

                        If vNumArchivos = 1 Then
                            obA.BorraArchivo("Produccion/OtrosArchivos", vNombreArchivo)
                        End If

                    End If
                Next
            End If



            Dim FormaError As New ExitoForm
            FormaError.mensaje = "El archivo fue eliminado"
            FormaError.ShowDialog()
            Cursor = Cursors.Default
            btnMostrar_Click(Nothing, Nothing)


        Catch ex As Exception
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Error al eliminar archivo"
            FormaError.ShowDialog()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim vNum = vwOtrosArchivos.DataRowCount
        Dim vIdArchivo As Integer = 0
        Dim vDocumento As String = String.Empty
        Dim vIdCategoria As Integer = 0
        Dim vNombreArchivo As String = String.Empty
        Dim vTipoDocumento As String = String.Empty

        If vwOtrosArchivos.FocusedRowHandle >= 0 Then
            For item As Integer = 0 To vNum Step 1
                If CBool(vwOtrosArchivos.IsRowSelected(vwOtrosArchivos.GetVisibleRowHandle(item))) = True Then
                    vIdArchivo = vwOtrosArchivos.GetRowCellValue(item, "IdArchivo").ToString()
                    vDocumento = vwOtrosArchivos.GetRowCellValue(item, "Documento").ToString()
                    vIdCategoria = vwOtrosArchivos.GetRowCellValue(item, "IdCategoria").ToString()
                    vNombreArchivo = vwOtrosArchivos.GetRowCellValue(item, "NombreArchivo").ToString()
                    vTipoDocumento = vwOtrosArchivos.GetRowCellValue(item, "TipoDocumento").ToString()

                End If
            Next
            Dim form As New AltaDocumentosProduccion_Form
            form.vIdArchivo = vIdArchivo
            form.vDocumento = vDocumento
            form.vIdCategoria = vIdCategoria
            form.vEsDepto = IIf(rbOtrosArchivos.Checked = True, False, True)
            form.vNombreDocumento = vNombreArchivo
            form.vTipoDocumento = vTipoDocumento
            form.vAdmonArchivos = Me
            form.ShowDialog()
        Else
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Seleccione un archivo"
            FormaError.ShowDialog()
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Dim vwGrd As XtraGrid.Views.Grid.GridView

        If rbFichasTecnicas.Checked = True Then
            vwGrd = vwFichasTecnicas
            nombreReporte = "AdministradorArchivosTecnicos"
        Else
            nombreReporte = "AdministradorOtrosArchivos"
            vwGrd = vwOtrosArchivos
        End If

        Try
            Cursor = Cursors.WaitCursor

            If vwGrd.DataRowCount > 0 Then

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwGrd.GroupCount > 0 Then
                            vwGrd.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwGrd.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
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

    Public Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        Dim dtArchivos As New DataTable
        Dim obj As New AdministradorArchivosBU
        Dim vIdNave As Integer?

        Try
            vIdNave = IIf(cmbNave.Text <> "", cmbNave.SelectedValue, Nothing)

            If vIdNave IsNot Nothing Then

                If rbOtrosArchivos.Checked = True Then
                    dtArchivos = obj.ObtenerAdministradorArchivos(rbOtrosArchivos.Checked, cmbNave.SelectedValue, Nothing, Nothing)
                Else
                    dtArchivos = obj.ObtenerAdministradorArchivos(rbOtrosArchivos.Checked, cmbNave.SelectedValue, IIf(cmbMarca.Text <> "", cmbMarca.SelectedValue, Nothing), IIf(cmbColeccion.Text <> "", cmbColeccion.SelectedValue, Nothing))
                End If

                If dtArchivos.Rows.Count > 0 Then

                    If rbOtrosArchivos.Checked = True Then
                        grdOtrosArchivos.DataSource = dtArchivos
                        AgregarBoton()
                        grdOtrosArchivos.Visible = True
                        grdFichasTecnicas.Visible = False
                        pnlOT.Visible = True
                    Else
                        grdFichasTecnicas.DataSource = dtArchivos
                        AgregarBotonFT()
                        grdOtrosArchivos.Visible = False
                        grdFichasTecnicas.Visible = True
                        pnlOT.Visible = False
                    End If

                Else

                    If rbOtrosArchivos.Checked = True Then
                        grdOtrosArchivos.DataSource = Nothing
                    Else
                        grdFichasTecnicas.DataSource = Nothing
                    End If

                    Dim FormaError As New AdvertenciaForm
                    FormaError.mensaje = "No hay datos para mostrar"
                    FormaError.ShowDialog()

                End If
            Else
                Dim FormaError As New AdvertenciaForm
                FormaError.mensaje = "Selecciona una nave"
                FormaError.ShowDialog()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AgregarBoton()
        If vwOtrosArchivos Is Nothing Then Exit Sub
        If vwOtrosArchivos.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdOtrosArchivos.RepositoryItems.Add(_RIButton)

        vwOtrosArchivos.Columns("Icono").ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        vwOtrosArchivos.Columns("Icono").UnboundType = DevExpress.Data.UnboundColumnType.Object
        vwOtrosArchivos.Columns("Icono").ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Width = vwOtrosArchivos.Columns("Icono").Width - (vwOtrosArchivos.Columns("Icono").Width / 13)

        AddHandler _RIButton.ButtonClick, AddressOf Icono_Click

    End Sub
    Private Sub AgregarBotonFT()
        If vwFichasTecnicas Is Nothing Then Exit Sub
        If vwFichasTecnicas.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdFichasTecnicas.RepositoryItems.Add(_RIButton)

        vwFichasTecnicas.Columns("Icono").ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        vwFichasTecnicas.Columns("Icono").UnboundType = DevExpress.Data.UnboundColumnType.Object
        vwFichasTecnicas.Columns("Icono").ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Width = vwFichasTecnicas.Columns("Icono").Width - (vwFichasTecnicas.Columns("Icono").Width / 13)

        AddHandler _RIButton.ButtonClick, AddressOf Icono_Click

    End Sub
    Private Sub Icono_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Dim vRutaOrigen As String = String.Empty
        Dim vRutaDestino As String = String.Empty
        Dim vArchivo As String = String.Empty

        Try
            If rbOtrosArchivos.Checked = True Then
                NumeroFilas = vwOtrosArchivos.DataRowCount
                vRutaDestino = "Descargas\Produccion\OtrosArchivos"
                vRutaOrigen = "/Produccion/OtrosArchivos/"
                For index As Integer = 0 To NumeroFilas Step 1
                    If vwOtrosArchivos.IsRowSelected(vwOtrosArchivos.GetVisibleRowHandle(index)) Then
                        vArchivo = vwOtrosArchivos.GetRowCellValue(vwOtrosArchivos.GetVisibleRowHandle(index), "Documento") + vwOtrosArchivos.GetRowCellValue(vwOtrosArchivos.GetVisibleRowHandle(index), "TipoDocumento")
                        Dim objFTP As New Tools.TransferenciaFTP
                        objFTP.DescargarArchivo(vRutaOrigen, vRutaDestino, vArchivo)
                        Process.Start(vRutaDestino + "\" + vArchivo)
                    End If
                Next
            Else
                Dim vForm As New AdministradorArchivosTecnicosForm
                NumeroFilas = vwFichasTecnicas.DataRowCount
                For index As Integer = 0 To NumeroFilas Step 1
                    If vwFichasTecnicas.IsRowSelected(vwFichasTecnicas.GetVisibleRowHandle(index)) Then
                        vForm.vIdProductoEstilo = vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "ProductoEstiloId")
                        vForm.vIdNave = IIf(cmbNave.Text <> "", cmbNave.SelectedValue, Nothing)
                        vForm.vDescripcion = vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "MarcaSAY") & " " & vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "ColeccionSAY") & " " & vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "ModeloSAY") & "(" & vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "ModeloSICY") & ") " & vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "PielColor") & " " & vwFichasTecnicas.GetRowCellValue(vwFichasTecnicas.GetVisibleRowHandle(index), "Talla")
                    End If
                Next

                vForm.vFormAdministradorArchivos = Me
                vForm.MdiParent = Me.MdiParent
                vForm.Show()

            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged

        Try
            If rbFichasTecnicas.Checked = True Then

                If cmbNave.Text <> "" Then

                    Dim dtMarcas As New DataTable
                    Dim obj As New AdministradorArchivosBU
                    Dim IdNave As Integer = cmbNave.SelectedValue

                    dtMarcas = obj.ObtenerCatalogosArchivo(9, Nothing, Nothing, Nothing, IdNave, Nothing, Nothing, Nothing)
                    dtMarcas.Rows.InsertAt(dtMarcas.NewRow, 0)
                    cmbMarca.DataSource = dtMarcas
                    cmbMarca.ValueMember = "MarcaIdSay"
                    cmbMarca.DisplayMember = "MarcaSAY"
                    cmbMarca.Enabled = True
                Else
                    cmbMarca.Enabled = False
                    cmbMarca.SelectedIndex = 0

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        Try
            If cmbMarca.Text <> "" Then

                Dim dtColeccion As New DataTable
                Dim obj As New AdministradorArchivosBU
                Dim IdNave As Integer = cmbNave.SelectedValue
                Dim IdMarca As Integer = cmbMarca.SelectedValue

                dtColeccion = obj.ObtenerCatalogosArchivo(1, Nothing, IdMarca, Nothing, IdNave, IdMarca, Nothing, Nothing)
                dtColeccion.Rows.InsertAt(dtColeccion.NewRow, 0)
                cmbColeccion.DataSource = dtColeccion
                cmbColeccion.ValueMember = "ID"
                cmbColeccion.DisplayMember = "DESCRIPCION"
                cmbColeccion.Enabled = True
            Else
                cmbColeccion.Enabled = False
                cmbColeccion.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbOtrosArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles rbOtrosArchivos.CheckedChanged
        Try
            cmbMarca.Enabled = False
            cmbColeccion.Enabled = False
            pnlEditar.Visible = True
            pnlElimina.Visible = True
            grdFichasTecnicas.DataSource = Nothing
            grdOtrosArchivos.DataSource = Nothing
            cmbNave.SelectedIndex = 0
            cmbColeccion.SelectedIndex = 0
            cmbMarca.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rbFichasTecnicas_CheckedChanged(sender As Object, e As EventArgs) Handles rbFichasTecnicas.CheckedChanged
        Try
            pnlEditar.Visible = False
            pnlElimina.Visible = False
            grdFichasTecnicas.DataSource = Nothing
            grdOtrosArchivos.DataSource = Nothing
            cmbNave.SelectedIndex = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub vwOtrosArchivos_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles vwOtrosArchivos.CustomRowCellEdit
        If (e.Column.FieldName = "Icono") Then
            Dim editor As New RepositoryItemButtonEdit
            editor.Assign(e.RepositoryItem)
            e.RepositoryItem = editor
            editor.Buttons(0).Image = Produccion.Vista.My.Resources.descargab
        End If
    End Sub

    Private Sub vwFichasTecnicas_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles vwFichasTecnicas.CustomRowCellEdit

        If (e.Column.FieldName = "Icono") Then
            Dim editor As New RepositoryItemButtonEdit
            editor.Assign(e.RepositoryItem)
            e.RepositoryItem = editor
            editor.Buttons(0).Image = Produccion.Vista.My.Resources.archivo
        End If
    End Sub

    Private Sub vwOtrosArchivos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwOtrosArchivos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub vwFichasTecnicas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwFichasTecnicas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub grdOtrosArchivos_MouseClick(sender As Object, e As MouseEventArgs) Handles grdOtrosArchivos.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        btnEliminar_Click(Nothing, Nothing)
    End Sub

    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        btnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub vwFichasTecnicas_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwFichasTecnicas.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub

    Private Sub vwOtrosArchivos_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwOtrosArchivos.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If

    End Sub
End Class