Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class CatalogoInsidencias_Form
    Dim ObjBU As New Negocios.CatalogoInsidencias
    Public IdDepa As Integer
    Dim filasSeleccionadas As Integer
    Private Sub CatalogoInsidencias_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        cmbDepartamentos = ObjBU.llenarcmbDepartamento(cmbDepartamentos)
        cmbDepartamentos.SelectedIndex = 0
        lblTotalRegistros.Text = "0"
        actualizarGrid()
    End Sub

    Private Sub ConsultarInsidencias(ByVal status As Integer, ByVal depa As Integer)
        Dim DatosInsidencias = ObjBU.ConsultarInsidencias(status, depa)
        Cursor = Cursors.WaitCursor
        If DatosInsidencias.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontraron datos.")
            btnExportarExcel.Enabled = False
            grdInsidencias.DataSource = DatosInsidencias
            lblTotalRegistros.Text = DatosInsidencias.Rows.Count
        Else
            grdInsidencias.DataSource = DatosInsidencias
            DiseñoGrid.DiseñoBaseGrid(viewInsidencias)
            viewInsidencias.IndicatorWidth = 35
            viewInsidencias.OptionsView.ColumnAutoWidth = True
            For Each col As DevExpress.XtraGrid.Columns.GridColumn In viewInsidencias.Columns
                If (col.FieldName = "IDIncidencias" Or col.FieldName = "IdDepa") Then
                    DiseñoGrid.EstiloColumna(viewInsidencias, col.FieldName, col.FieldName, False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")
                ElseIf (col.FieldName = "Selección") Then
                    col.OptionsColumn.AllowSize = False
                    DiseñoGrid.EstiloColumna(viewInsidencias, col.FieldName, col.FieldName, True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 80, False, Nothing, "")
                End If
            Next
            lblTotalRegistros.Text = String.Format("{0:N0}", DatosInsidencias.Rows.Count)
            btnExportarExcel.Enabled = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub viewInsidencias_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewInsidencias.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 74
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        actualizarGrid()
    End Sub

    Private Sub actualizarGrid()
        If rdbactivos.Checked Then
            ConsultarInsidencias(1, cmbDepartamentos.SelectedValue)

            btndesa.Visible = True
            lbldesa.Visible = True
            Button2.Visible = False
            Label1.Visible = False
        Else
            ConsultarInsidencias(0, cmbDepartamentos.SelectedValue)
            btndesa.Visible = False
            lbldesa.Visible = False
            Button2.Visible = True
            Label1.Visible = True
        End If
    End Sub
    Private Sub button_delete_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)

    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        addIncidencia()
        actualizarGrid()
    End Sub
    Private Sub addIncidencia()
        Dim add As New AgregarIncidencia_Form
        add.StartPosition = FormStartPosition.CenterParent
        add.ShowDialog()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim filas = obtenerModelosSeleccionados()
        If filasSeleccionadas > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Selecciona solo un registro")
        ElseIf filasSeleccionadas = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Selecciona minimo un registro")
        Else

            editarInciencia()
            actualizarGrid()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        activarIncidencia("activar")
        actualizarGrid()
    End Sub

    Private Sub editarInciencia()
        Dim edit As New EditarIncidencia_Form
        Dim NumeroFilas As Integer = 0
        Dim DepaID As String = String.Empty

        Try

            NumeroFilas = viewInsidencias.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "Selección")) = True Then
                    DepaID = viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "IDIncidencias").ToString()
                    If DepaID <> String.Empty Then
                        edit.txtid.Text = DepaID
                        edit.txtpuesto.Text = viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "Incidencia").ToString()
                        edit.Depa = Convert.ToInt16(viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "IdDepa"))
                        edit.StartPosition = FormStartPosition.CenterParent
                        edit.ShowDialog()

                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un departamento")
                    End If
                End If
            Next
            If DepaID = String.Empty Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Selecciona por lo menos un registro")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "ERROR" + ex.Message)
        End Try
    End Sub

    Private Sub activarIncidencia(ByVal accion As String)
        Dim entidad As New Entidades.CatalogoInsidencias
        Dim NumeroFilas As Integer = 0
        Dim DepaID As String = String.Empty
        Dim articulos As Integer = 0
        Dim success As DataTable
        Try
            Dim modelos = obtenerModelosSeleccionados()
            If modelos <> "" Then
                Dim ventanaConfirmacion As New Tools.ConfirmarForm
                ventanaConfirmacion.mensaje = "¿Está seguro de " & accion & " la incidencia?"
                ventanaConfirmacion.ShowDialog()
                If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return

                If accion = "activar" Then
                    success = ObjBU.ModificarEstatusInsidencias(modelos, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 1)
                Else
                    success = ObjBU.ModificarEstatusInsidencias(modelos, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0)
                End If
                If success.Rows(0).Item("Respuesta") > 0 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Rows(0).Item("mensaje"))
                    actualizarGrid()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Rows(0).Item("mensaje"))
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Selecciona por lo menos un registro")
            End If



        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "ERROR" + ex.Message)
        End Try
    End Sub

    Private Function obtenerModelosSeleccionados() As String
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        FilasSeleccionadas = 0

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = viewInsidencias.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "Selección")) = True Then
                    filasSeleccionadas += 1

                    If documentosSeleccionados = String.Empty Then
                        documentosSeleccionados = viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "IDIncidencias").ToString & ","

                    Else
                        documentosSeleccionados = documentosSeleccionados & viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "IDIncidencias").ToString & ","
                    End If
                End If
            Next
        Catch ex As Exception

            Utilerias.show_message("Error", ex.Message.ToString())
        End Try
        Cursor = Cursors.Default
        Return documentosSeleccionados

    End Function


    'Private Sub DesactivarIncidencia()
    '    Dim entidad As New Entidades.CatalogoInsidencias
    '    Dim NumeroFilas As Integer = 0
    '    Dim DepaID As String = String.Empty
    '    Dim articulos As Integer = 0
    '    Try
    '        NumeroFilas = viewInsidencias.DataRowCount
    '        For index As Integer = 0 To NumeroFilas Step 1
    '            If CBool(viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "SELECCIÓN")) = True Then
    '                DepaID = viewInsidencias.GetRowCellValue(viewInsidencias.GetVisibleRowHandle(index), "IDIncidencias").ToString()
    '                If DepaID <> String.Empty Then
    '                    Dim ventanaConfirmacion As New Tools.ConfirmarForm
    '                    ventanaConfirmacion.mensaje = "¿Está seguro de desactivar la incidencia?"
    '                    ventanaConfirmacion.ShowDialog()
    '                    If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
    '                    entidad.IDIncidencias = DepaID
    '                    entidad.Fecha = Date.Now
    '                    entidad.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    '                    Dim success = ObjBU.ModificarEstatusInsidencias(entidad, 0)
    '                    If success.Rows(0).Item("Respuesta") > 0 Then
    '                        articulos = articulos + 1
    '                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Rows(0).Item("mensaje"))
    '                        actualizarGrid()
    '                    Else
    '                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Rows(0).Item("mensaje"))
    '                    End If
    '                End If
    '            End If
    '        Next
    '        If articulos = 0 Then
    '            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Selecciona un articulo")
    '        End If
    '    Catch ex As Exception
    '        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "ERROR" + ex.Message)
    '    End Try
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btndesa.Click
        activarIncidencia("Desactivar")
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        exportaExel()
    End Sub
    Private Sub exportaExel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog


        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If GridView1.GroupCount > 0 Then
                        grdInsidencias.ExportToXlsx(.SelectedPath + "\Incidencias_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        grdInsidencias.ExportToXlsx(.SelectedPath + "\Incidencias_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_Incidencias_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Incidencias_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub
End Class