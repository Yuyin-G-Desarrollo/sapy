Imports System.Globalization
Imports DevExpress.XtraGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Public Class Programacion_ColocacionSemanal_Configuracion_FamiliasForm
    Public IdNaveSay As Integer
    Public NombreNave As String
    Public marcadosActualmente As New List(Of Integer)
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Public Sub disenioGrid()
        With grdListadoFamilias.DisplayLayout

            .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.True
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .Bands(0).Columns("Seleccionar").Width = 30
            .Bands(0).Columns("Seleccionar").AllowRowFiltering = DefaultableBoolean.False
            .Bands(0).Columns("Seleccionar").Header.Caption = ""
            .Bands(0).Columns("fapr_descripcion").Header.Caption = "Familia"
            .Bands(0).Columns("fapr_familiaproyeccionid").Hidden = True
            .Bands(0).Columns("Seleccionar").CellActivation = Activation.AllowEdit
        End With
    End Sub
    Private Sub consultarFamiliasNoAsignadas()
        Dim obj As New Programacion_FamiliaNave_BU
        grdListadoFamilias.DataSource = Nothing
        Try
            Dim dtConsultaFamilias As New DataTable
            dtConsultaFamilias = obj.ObtenerFamiliasNoAsignadasPorNave(IdNaveSay)
            If dtConsultaFamilias.Rows.Count > 0 Then
                grdListadoFamilias.DataSource = dtConsultaFamilias
                disenioGrid()
            Else
                objAdvertencia.mensaje = "No existen familias para asignar a esta nave."
                objAdvertencia.ShowDialog()
                Me.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Programacion_ColocacionSemanal_Configuracion_FamiliasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultarFamiliasNoAsignadas()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        marcadosActualmente = New List(Of Integer)
        If chkSeleccionarTodo.Checked Then
            For Each row In grdListadoFamilias.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = True
                lblAsignar.Enabled = True
                btnAsignar.Enabled = True
            Next
        Else
            For Each row As UltraGridRow In grdListadoFamilias.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = False
                lblAsignar.Enabled = False
                btnAsignar.Enabled = False
            Next
        End If
        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoFamilias.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                marcadosActualmente.Add(row.Cells("fapr_familiaproyeccionid").Value)
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        objConfirmar.mensaje = "Se asignarán " & lblNumFiltrados.Text & " familias a la nave " & NombreNave & ".Este cambio no podrá revertirse ¿Desea continuar?"
        If objConfirmar.ShowDialog = DialogResult.OK Then
            Dim contador As Integer = 0
            Dim UsuarioId As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Dim IdFamilias As String = ""
            For Each x In marcadosActualmente
                If contador = 0 Then
                    IdFamilias = IdFamilias & x
                    contador = contador + 1
                Else
                    IdFamilias = IdFamilias & "," & x
                End If
            Next
            Dim obj As New Programacion_FamiliaNave_BU
            Try
                obj.InsertarFamiliasNave(UsuarioId, IdNaveSay, IdFamilias)
                Me.DialogResult = DialogResult.OK
                Me.Dispose()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Me.DialogResult = DialogResult.None
        End If
    End Sub

    Private Sub grdListadoFamilias_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListadoFamilias.ClickCell
        If Not Me.grdListadoFamilias.ActiveRow.IsDataRow Then Return

        If IsNothing(grdListadoFamilias.ActiveRow) Then Return
        If grdListadoFamilias.ActiveRow.Cells("Seleccionar").Value Then
            grdListadoFamilias.ActiveRow.Cells("Seleccionar").Value = False
            marcadosActualmente.Remove(grdListadoFamilias.ActiveRow.Cells("fapr_familiaproyeccionid").Value)
        Else
            marcadosActualmente.Add(grdListadoFamilias.ActiveRow.Cells("fapr_familiaproyeccionid").Value)
            grdListadoFamilias.ActiveRow.Cells("Seleccionar").Value = True
        End If


        Dim marcados As Integer
        For Each row As UltraGridRow In grdListadoFamilias.Rows
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
End Class