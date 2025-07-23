Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios

Public Class AsignarEtiquetaClienteColeccionForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objError As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Public marcadosActualmente As New List(Of Integer)
    'Dim clienteId As Integer
    Public etiquetaId As Integer = 0
    Public clienteId As Integer = 0
    Public Sub disenioGrid()
        With grdListadoArticulos.DisplayLayout
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.CellSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowUpdate = DefaultableBoolean.False
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Bands(0).Columns("Seleccionar").Width = 30
            .Bands(0).Columns("Seleccionar").Header.Caption = ""
            .Bands(0).Columns("ColeccionId").Hidden = True
            .Bands(0).Columns("Coleccion").Width = 30
            .Bands(0).Columns("Marca").Hidden = True

        End With
    End Sub
    Private Sub consultarColeccionesNoAsignadas()
        'clienteId = 763 'Coppel
        Dim obj As New EtiquetasBU
        grdListadoArticulos.DataSource = Nothing
        Try
            Dim dtConsultaColecciones As New DataTable
            dtConsultaColecciones = obj.ObtenerColeccionesNoAsignadasPorCliente(clienteId, etiquetaId)
            If dtConsultaColecciones.Rows.Count > 0 Then
                grdListadoArticulos.DataSource = dtConsultaColecciones
                disenioGrid()
            Else
                objAdvertencia.mensaje = "No existen colecciones para asignar a este cliente."
                objAdvertencia.ShowDialog()
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AsignarEtiquetaClienteColeccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultarColeccionesNoAsignadas()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        marcadosActualmente = New List(Of Integer)
        If chkSeleccionarTodo.Checked Then
            For Each row In grdListadoArticulos.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = True
                lblAsignar.Enabled = True
                btnAsignar.Enabled = True
            Next
        Else
            For Each row As UltraGridRow In grdListadoArticulos.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = False
                lblAsignar.Enabled = False
                btnAsignar.Enabled = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoArticulos.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                marcados += 1
                marcadosActualmente.Add(row.Cells("ColeccionId").Value)
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub grdListadoArticulos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListadoArticulos.ClickCell
        If Not Me.grdListadoArticulos.ActiveRow.IsDataRow Then Return

        If IsNothing(grdListadoArticulos.ActiveRow) Then Return
        If grdListadoArticulos.ActiveRow.Cells("Seleccionar").Value Then
            grdListadoArticulos.ActiveRow.Cells("Seleccionar").Value = False
            marcadosActualmente.Remove(grdListadoArticulos.ActiveRow.Cells("ColeccionId").Value)
        Else
            marcadosActualmente.Add(grdListadoArticulos.ActiveRow.Cells("ColeccionId").Value)
            grdListadoArticulos.ActiveRow.Cells("Seleccionar").Value = True
        End If


        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoArticulos.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
        If (lblNumFiltrados.Text <> "0") Then
            btnAsignar.Enabled = True
            lblAsignar.Enabled = True
        Else
            btnAsignar.Enabled = False
            lblAsignar.Enabled = False
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        objConfirmar.mensaje = "Se asignarán " & lblNumFiltrados.Text & " colecciones. Este cambio no podrá revertirse ¿Desea continuar?"
        If objConfirmar.ShowDialog = DialogResult.OK Then
            Dim contador As Integer = 0
            Dim UsuarioId As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Dim obj As New EtiquetasBU
            Try
                obj.AsignarEtiquetaClienteCollecion(clienteId, etiquetaId, String.Join(",", marcadosActualmente), UsuarioId)
                objExito.mensaje = "Datos guardados correctamente."
                objExito.ShowDialog()
                Me.DialogResult = DialogResult.OK
                Me.Dispose()
            Catch ex As Exception
                objError.mensaje = "Se produjo un error al procesar la solicitud."
                objError.ShowDialog()
                Me.DialogResult = DialogResult.None
            End Try
        Else
            Me.DialogResult = DialogResult.None
        End If
    End Sub


End Class