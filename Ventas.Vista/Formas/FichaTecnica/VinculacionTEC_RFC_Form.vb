Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class VinculacionTEC_RFC_Form

    Public rfcID As Integer
    Public clienteID As Integer
    Public ClienteNombre As String
    Public rfc As String

    Private Sub VinculacionTEC_RFC_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        poblar_gridVinculacionTEC_RFC(rfcID, clienteID, gridVinculacionTEC_RFC)
        txtCliente.Text = ClienteNombre
        txtRFC.Text = rfc
    End Sub


#Region "ACCIONES GRIDS        "


    Private Sub gridVinculacionTEC_RFC_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridVinculacionTEC_RFC.ClickCell
        If e.Cell.Column.ToString = "VINCULADO" Then
            If e.Cell.Value = True Then
                e.Cell.Value = False
            Else
                e.Cell.Value = True
            End If
        End If
    End Sub

    Public Sub poblar_gridVinculacionTEC_RFC(rfcID As Integer, clienteID As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim objBU As New Negocios.ClientesDatosBU
        Dim Tabla_Vinculacion As New DataTable

        Tabla_Vinculacion = objBU.Datos_Vinculacion_TEC_RFC(rfcID, clienteID)

        grid.DataSource = Tabla_Vinculacion

        gridVinculacionTEC_RFCDiseno(grid)

    End Sub

    Private Sub gridVinculacionTEC_RFCDiseno(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        'asignaFormato_Columna(grid)

        grid.DisplayLayout.Bands(0).Columns("tiec_tiendaembarquecedisid").Hidden = True

        grid.DisplayLayout.Bands(0).Columns("clie_clienteid").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("tiec_clasificacionpersonaid").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("rtec_rfc_tiendaembarquecedis_id").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("rtec_clienterfc_id").Hidden = True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        'asignaFormato_Columna(grid)

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


    End Sub

    Private Sub asignar_grid_gridVinculacionTEC_RFC(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        gridVinculacionTEC_RFC = grid
    End Sub

    Private Sub gridVinculacionTEC_RFC_DoubleClickHeader(sender As Object, e As DoubleClickHeaderEventArgs) Handles gridVinculacionTEC_RFC.DoubleClickHeader

        If Me.gridVinculacionTEC_RFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True Then
            Me.gridVinculacionTEC_RFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        Else
            Me.gridVinculacionTEC_RFC.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            Me.gridVinculacionTEC_RFC.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            Me.gridVinculacionTEC_RFC.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            Me.gridVinculacionTEC_RFC.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            Me.gridVinculacionTEC_RFC.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        End If

    End Sub


#End Region


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim clientesDatosBU As New Negocios.ClientesDatosBU

        If Tools.Controles.Mensajes_Y_Alertas("CONFIRMACION", "¿Desea guardar los cambios realizados?") Then
            Try
                For Each ROW As UltraGridRow In gridVinculacionTEC_RFC.Rows
                    If ROW Is Nothing Then Return

                    Dim estatus As Boolean = CBool(ROW.Cells(11).Value)

                    If estatus = False And Not IsDBNull(ROW.Cells(9).Value) Then
                        ''AQUI ACTUALIZA 
                        clientesDatosBU.Vinculacion_RFC_TEC(2, 0, 0, CInt(ROW.Cells(9).Value))
                        ROW.Cells(9).Value = False
                    ElseIf estatus = True Then
                        ''AQUI INSERTA
                        If Not IsDBNull((ROW.Cells(9).Value)) Then
                            clientesDatosBU.Vinculacion_RFC_TEC(1, rfcID, CInt(ROW.Cells(0).Value), CInt(ROW.Cells(9).Value))
                            ROW.Cells(9).Value = True
                        Else
                            clientesDatosBU.Vinculacion_RFC_TEC(1, rfcID, CInt(ROW.Cells(0).Value), 0)
                            ROW.Cells(9).Value = True
                        End If
                    End If
                Next

                Tools.Controles.Mensajes_Y_Alertas("EXITO", "Datos guardados con éxito")

                Me.Dispose()
            Catch ex As Exception
                Tools.Controles.Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        For Each row As UltraGridRow In gridVinculacionTEC_RFC.Rows
            row.Cells("VINCULADO").Value = chkSeleccionarTodo.Checked
        Next
    End Sub
End Class