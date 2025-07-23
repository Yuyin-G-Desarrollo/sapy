Imports System.Windows.Forms
Imports Framework.Negocios
Imports Contabilidad.Negocios
Imports Tools
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports System.Globalization
Imports Stimulsoft.Report
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid

Public Class ListaDiasNoLaborablesForm
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 25
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 62
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs)
        limpiarCampos()
    End Sub

    Public Sub limpiarCampos()

    End Sub

    Public Sub llenarcomboFechas()
        Dim valoresCombo As New System.Collections.Generic.Dictionary(Of Integer, String)
        Dim anioActual As Integer = Date.Now.Year

        For index = anioActual - 3 To anioActual + 4
            Dim anio As Integer = index + 1
            Dim fecha = Convert.ToString(anio)
            valoresCombo.Add(anio, fecha)
        Next
        cmbAnio.DisplayMember = "Value"
        cmbAnio.ValueMember = "Key"
        cmbAnio.DataSource = valoresCombo.ToArray

    End Sub

    Private Sub ListaDiasNoLaborables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        configuracionPermisosBotones()
        llenarcomboFechas()
        For index = 0 To cmbAnio.Items.Count - 1
            Dim anio As String = Date.Now.Year
            If cmbAnio.Items.Item(index).Value.Equals(anio) Then
                cmbAnio.SelectedIndex = index

            End If
        Next
        mostrarDiasNoLaborables()
    End Sub

    Private Sub configuracionPermisosBotones()
        If PermisosUsuarioBU.ConsultarPermiso("NF_CAT_DIAS_NLAB", "NF_CAT_DIAS_ALTA") Then
            pnlAltas.Visible = True
        Else
            pnlAltas.Visible = False
        End If

    End Sub

    Private Sub mostrarDiasNoLaborables()
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.CatalogosBU
        Dim dtDiasNoLaborables As New DataTable
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        dtDiasNoLaborables = objBu.consultaDiasNoLaborables(cmbAnio.Text)

        If dtDiasNoLaborables.Rows.Count > 0 Then
            grdDiasFestivos.DataSource = dtDiasNoLaborables
            DiseñoGrid.DiseñoBaseGrid(viewDiasFestivos)
            viewDiasFestivos.IndicatorWidth = 35
            viewDiasFestivos.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "Descripcion", "Descripción", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "Fecha", "Fecha", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 169, False, Nothing, "")
        Else
            objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
            objMensajeAdv.Show()
            grdDiasFestivos.DataSource = dtDiasNoLaborables
        End If
        Me.Cursor = Cursors.Default
        lblTotalRegistros.Text = dtDiasNoLaborables.Rows.Count
        Me.cmbAnio.Select()
    End Sub

    'Metodo que muestra el Numero De Registro en el grid'
    Private Sub grdDiasFestivos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewDiasFestivos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub



    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        mostrarDiasNoLaborables()
    End Sub

    Private Sub GridDiasNoLaborales_DoubleClick(sender As Object, e As EventArgs)
        btnEditar_Click(sender, e)
        mostrarDiasNoLaborables()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If viewDiasFestivos.SelectedRowsCount > 0 Then
            Dim descripcion As String = CStr(viewDiasFestivos.GetFocusedRowCellValue("Descripcion"))
            Dim fecha As Date = CDate(viewDiasFestivos.GetFocusedRowCellValue("Fecha"))
            abrirPantallaEditarDias(fecha, descripcion)
        Else
            objMensajeAdv.mensaje = "Favor de seleccionar un registro en el grid"
            objMensajeAdv.Show()
        End If
        mostrarDiasNoLaborables()
    End Sub

    Private Sub abrirPantallaEditarDias(ByVal fecha As String, ByVal descripcion As String)
        Dim objForm As New EditarDiasNoLaborablesForm
        If Not CheckForm(objForm) Then
            Dim formaAltas As New EditarDiasNoLaborablesForm
            formaAltas.fecha = fecha
            formaAltas.descripcion = descripcion
            formaAltas.ShowDialog()
        End If
    End Sub
    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub txtAnio_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            mostrarDiasNoLaborables()
        End If
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim listado As New AltaDiasNoLaboralesForm
        Dim anio = cmbAnio.Text
        If anio.Equals("") Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un Año")
        Else
            listado.StartPosition = FormStartPosition.CenterScreen
            listado.txtanio.Text = anio
            listado.ShowDialog()
            mostrarDiasNoLaborables()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim listado As New CatalogoPeriodosDeVacacionesForm
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.Show(Me)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EliminarDia()
        mostrarDiasNoLaborables()
    End Sub

    Private Sub EliminarDia()
        Dim ObjBU As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
        Dim entDepartamento As New Entidades.DiasNoLaborales
        Dim NumeroFilas As Integer = 0
        Dim diaID As String = String.Empty

        Try

            NumeroFilas = viewDiasFestivos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(viewDiasFestivos.IsRowSelected(viewDiasFestivos.GetVisibleRowHandle(index))) = True Then
                    diaID = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Descripcion").ToString()
                    If diaID <> String.Empty Then
                        Dim ventanaConfirmacion As New Tools.ConfirmarForm
                        ventanaConfirmacion.mensaje = "¿Está seguro de eliminar permanentemente el registro?"
                        ventanaConfirmacion.ShowDialog()
                        If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                        Dim fechaAn = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Fecha").ToString()
                        Dim description = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Descripcion").ToString()
                        Dim success = ObjBU.EditarDiaNoLaborables(fechaAn, fechaAn, description, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 0)
                        If success.Resp > 0 Then
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se selecciono un día")
                    End If
                End If
            Next

        Catch ex As Exception

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El día no es valido" + ex.Message)
        End Try
    End Sub
End Class