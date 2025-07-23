Imports System.Windows.Forms
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization

Public Class SeleccionarColaboradoresForm
    Public patronId As Integer = 0
    Public colaboradorIds As String = String.Empty

    Private Sub SeleccionarColaboradoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarListado()
    End Sub

    Private Sub cargarListado()
        If patronId <> 0 Then
            Dim objMensajeError As New Tools.ErroresForm
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            Try
                Dim objBu As New Negocios.UtileriasBU
                Dim dtListado As New DataTable

                Dim nombre As String = txtNombre.Text
                Dim externo As Boolean = rdbExternoSi.Checked

                dtListado = objBu.consultarColaboradoresAsegurados(patronId, 0, nombre, externo, False)
                If dtListado.Rows.Count > 0 Then
                    Dim col As DataColumn = dtListado.Columns.Add("Selección", System.Type.GetType("System.Boolean"))
                    col.SetOrdinal(1)

                    For Each row As DataRow In dtListado.Rows
                        row.Item("Selección") = 0
                    Next

                    grdListado.DataSource = dtListado
                    disenioGrid()
                    recuperarSeleccionados()
                Else
                    objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
                    objMensajeAdv.Show()
                    grdListado.DataSource = Nothing
                End If
            Catch ex As Exception
                objMensajeError.mensaje = "Error al cargar listado de colaboradores."
                objMensajeError.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub grdListado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListado.InitializeLayout
        Me.grdListado.DisplayLayout.Override.HeaderCheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
        Me.grdListado.DisplayLayout.Override.HeaderCheckBoxAlignment = HeaderCheckBoxAlignment.Right
        Me.grdListado.DisplayLayout.Override.HeaderCheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
    End Sub

    Public Sub disenioGrid()
        With grdListado.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("#").Hidden = True
            .Columns("Departamento").Hidden = True
            .Columns("Puesto").Hidden = True
            .Columns("Nave").Hidden = True

            .Columns("Selección").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Colaborador").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdListado.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            '.Columns("Selección").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Colaborador").CharacterCasing = CharacterCasing.Upper
        End With

        grdListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListado.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListado.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grdListado.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdListado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Private Sub recuperarSeleccionados()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If colaboradorIds <> "" Then
                Dim seleccionados() As String = Split(colaboradorIds, ",")
                For item As Integer = 0 To seleccionados.Length - 1
                    For Each row As UltraGridRow In grdListado.Rows
                        If row.Cells("ID").Value.ToString = seleccionados(item) Then
                            row.Cells("Selección").Value = True
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al recuperar los colaboradores seleccionados."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        cargarListado()
    End Sub

    Private Sub rdbExternoSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExternoSi.CheckedChanged
        cargarListado()
    End Sub

    Private Sub rdbExternoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbExternoNo.CheckedChanged
        cargarListado()
    End Sub

    Private Sub grdListado_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListado.ClickCell
        If Not Me.grdListado.ActiveRow.IsDataRow Then Return
        If IsNothing(grdListado.ActiveRow) Then Return

        If grdListado.ActiveRow.Cells("Selección").Value Then
            grdListado.ActiveRow.Cells("Selección").Value = False
        Else
            grdListado.ActiveRow.Cells("Selección").Value = True
        End If

        Dim marcados As Integer = 0
        For Each row As UltraGridRow In grdListado.Rows
            If CBool(row.Cells("Selección").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub grdListado_AfterHeaderCheckStateChanged(sender As Object, e As AfterHeaderCheckStateChangedEventArgs) Handles grdListado.AfterHeaderCheckStateChanged
        Dim marcados As Integer = 0
        For Each row As UltraGridRow In grdListado.Rows
            If CBool(row.Cells("Selección").Value) Then
                marcados += 1
            End If
        Next
        lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click, lblAceptar.Click
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Try
            If CInt(lblNumFiltrados.Text) > 0 Then
                colaboradorIds = String.Empty
                For Each row As UltraGridRow In grdListado.Rows
                    If CBool(row.Cells("Selección").Value) Then
                        colaboradorIds &= row.Cells("ID").Value & ","
                    End If
                Next
                colaboradorIds = colaboradorIds.Substring(0, colaboradorIds.Length - 1)
            Else
                colaboradorIds = String.Empty
                'objMensajeAdv.mensaje = "Favor de seleccionar al menos un registro"
                'objMensajeAdv.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al seleccionar los colaboradores"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        'colaboradorIds = String.Empty
        Me.Close()
    End Sub
End Class