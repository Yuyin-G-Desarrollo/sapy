Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class ListadoMarcasForm

    Public idCliente As Int32

    Public Sub cargarListadoMartcasRestriccion()
        Dim dtRestriccion As New DataTable
        Dim objBu As New Negocios.ClientesDatosBU
        If idCliente <> 0 Then
            dtRestriccion = objBu.consultaRestriccionClienteMarca(idCliente)

            If dtRestriccion.Rows.Count > 0 Then
                grdMarcas.DataSource = dtRestriccion
                formatoGrid()
            End If
        End If

    End Sub

    Public Sub formatoGrid()
        With grdMarcas.DisplayLayout.Bands(0)

            .Columns("idMarca").Hidden = True
            .Columns("restriccionid").Hidden = True

            .Columns("seleccion").Header.Caption = ""
            .Columns("marca").Header.Caption = "Marca"


            .Columns("marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("seleccion").Style = ColumnStyle.CheckBox
            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colSeleccion As UltraGridColumn = grdMarcas.DisplayLayout.Bands(0).Columns("Seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = ""
            colSeleccion.Header.VisiblePosition = 0
            colSeleccion.Style = ColumnStyle.CheckBox
            colSeleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


        End With

        grdMarcas.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdMarcas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMarcas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdMarcas.DisplayLayout.Override.RowSelectorWidth = 35
        grdMarcas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdMarcas.Rows(0).Selected = True
        grdMarcas.DisplayLayout.Bands(0).Columns("seleccion").Width = 18
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If Not grdMarcas.DataSource Is Nothing Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdMarcas.Rows.GetFilteredInNonGroupByRows
                rowGR.Cells("seleccion").Value = CBool(chkSeleccionarTodo.Checked)
                If CBool(rowGR.Cells("seleccion").Text) = True Then
                    contadorSeleccion += 1
                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub grdMarcas_CellChange(sender As Object, e As CellEventArgs) Handles grdMarcas.CellChange
        If e.Cell.Column.Key = "seleccion" And e.Cell.Row.Index <> grdMarcas.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            For Each rowGR As UltraGridRow In grdMarcas.Rows
                If CBool(rowGR.Cells("seleccion").Text) = True Then

                    contadorSeleccion += 1

                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub ListadoMarcasForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarListadoMartcasRestriccion()
    End Sub

    Public Sub guardarMarcasPorFacturar()
        Dim cont As Int32 = 0
        Dim mensajeAdvertencia As New AdvertenciaForm
        Dim objBu As New Negocios.ClientesDatosBU
        Dim operacion As Int32 = 0
        Dim seleccion As Int32 = 0
        Dim errorF As New ErroresForm

        For Each rowgrd In grdMarcas.Rows
            If rowgrd.Cells("seleccion").Value = True Then
                cont = cont + 1
                Exit For
            End If
        Next

        'If cont > 0 Then
        Dim objM As New Tools.ConfirmarForm
        objM.mensaje = "¿Está seguro de guardar la(s) marca(s) por factura?"

        If objM.ShowDialog = Windows.Forms.DialogResult.OK Then
            For Each rowgrd In grdMarcas.Rows
                If rowgrd.Cells("seleccion").Value = True Then
                    seleccion = 1
                Else
                    seleccion = 0
                End If
                If rowgrd.Cells("restriccionid").Value <> 0 Then
                    operacion = 0
                Else
                    operacion = 1
                End If

                Try
                    objBu.insertaActualizaMarcaPorFacturaCliente(idCliente, rowgrd.Cells("idmarca").Value, operacion, seleccion)

                Catch ex As Exception
                    errorF.mensaje = "Algo surgió mal durante el proceso de guardado"
                    errorF.ShowDialog()

                End Try


                'End If
            Next
            Me.Close()
        End If




        'Else
        'mensajeAdvertencia.mensaje = "No existe ningún registro seleccionado"
        'mensajeAdvertencia.ShowDialog()
        'End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarMarcasPorFacturar()
    End Sub
End Class