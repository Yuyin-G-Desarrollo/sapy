Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class InventarioIdealForm

    Dim AlturaMaximaPanel As Int32 = 0

    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        LlenarTabla()
    End Sub






    Private Sub btnAutorizar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
        ImportarExcel()
    End Sub

    Private Sub LlenarTabla()
        Dim vInventarioIdealBU As New InventarioIdealBU
        Dim vErrorForm As New ErroresForm
        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = Nothing
            grdDatos.DataSource = vInventarioIdealBU.obtenerDatosInventarioIdeal
            disenotabla(vInventarioIdealBU, 2)

        Catch ex As Exception
            vErrorForm.Text = "Inventario Ideal"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub ImportarExcel()

        Dim vInventarioIdealBU As New InventarioIdealBU
        Dim vBitacora As New BitacoraImportacionBU
        Dim hoja As String = ""
        Dim listaHojas As New List(Of String)
        Dim file As String = ""
        Dim vSeleccionarHoja As New SeleccionarHojaExcel
        Dim vDialogResult As New DialogResult
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Dim t_datos_excel As New DataTable

        Try
            vConfirmarForm.Text = "Inventario Ideal"
            vConfirmarForm.mensaje = "¿ Desea importar un archivo de inventario ideal ? (Se eliminarán todos los registros actuales)"
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                Dim ofd As New OpenFileDialog
                ofd.Filter = "*.xlsm|*.xlsm|Excel|*.xlsx|Excel|*.xls"

                ofd.ShowDialog()
                If ofd.FileName.Length > 5 Then
                    file = ofd.FileName
                    listaHojas = vInventarioIdealBU.obtenerHojasExcel(file)
                    For Each hoja In listaHojas
                        vSeleccionarHoja.cmbHojaExcel.Items.Add(hoja.ToString)
                    Next
                    vSeleccionarHoja.cmbHojaExcel.SelectedIndex = 0
                    vDialogResult = vSeleccionarHoja.ShowDialog
                    If vDialogResult = Windows.Forms.DialogResult.OK Then
                        btnImportar.Enabled = False
                        Me.Cursor = Cursors.WaitCursor
                        t_datos_excel = vInventarioIdealBU.obtenerDatosHojaExcel(file, vSeleccionarHoja.cmbHojaExcel.Text)
                        If t_datos_excel.Columns.Contains("COLECCIÓN") Then
                            grdDatos.DataSource = Nothing
                            vInventarioIdealBU.InicializarTablaExcel()
                            grdDatos.DataSource = t_datos_excel
                            disenotabla(vInventarioIdealBU, 1)
                            vBitacora.Agregar("Inventario Ideal", file)
                            vExitoForm.Text = "Inventario Ideal"
                            vExitoForm.mensaje = "Archivo Importado con éxito"
                            vExitoForm.ShowDialog()
                        Else
                            vAdvertenciaForm.Text = "Inventario Ideal"
                            vAdvertenciaForm.mensaje = "Es posible que haya seleccionado un archivo  no válido para importar el inventario ideal"
                            vAdvertenciaForm.ShowDialog()
                            btnImportar.Enabled = True
                        End If
                        btnImportar.Enabled = True
                        Me.Cursor = Cursors.Default

                        Application.DoEvents()
                    Else
                        vAdvertenciaForm.Text = "Inventario Ideal"
                        vAdvertenciaForm.mensaje = "Seleccion de archivo de 'Inventario Ideal' Cancelada"
                        vAdvertenciaForm.ShowDialog()
                    End If
                Else
                    vAdvertenciaForm.Text = "Inventario Ideal"
                    vAdvertenciaForm.mensaje = "Seleccion de archivo de 'Inventario Ideal' Cancelada"
                    vAdvertenciaForm.ShowDialog()
                End If

            Else
                vAdvertenciaForm.Text = "Inventario Ideal"
                vAdvertenciaForm.mensaje = "Seleccione un archivo valido"
                vAdvertenciaForm.ShowDialog()
            End If



        Catch ex As Exception
            'Mensaje de error
            vErrorForm.Text = "Inventario Ideal"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
            btnImportar.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub disenotabla(ByVal vInventarioIdealBU As InventarioIdealBU, ByVal tipo As Integer)
        Dim obj As Entidades.InventarioIdeal


        grdDatos.DisplayLayout.Bands(0).Columns.Add("Renglon", "Renglón")
        grdDatos.DisplayLayout.Bands(0).Columns("Renglon").Header.VisiblePosition = 0
        lblTotal.Text = grdDatos.Rows.Count.ToString("N0")



        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("Renglon").CellActivation = Activation.NoEdit
            .Columns("Renglon").DataType = System.Type.GetType("System.Int64")
            .Columns("RANKING").CellActivation = Activation.NoEdit
            .Columns("MODELO").CellActivation = Activation.NoEdit
            If tipo = 1 Then
                .Columns("COLECCIÓN").CellActivation = Activation.NoEdit
                .Columns("COLECCIÓN").Header.Caption = "Colección"
                .Columns("PIEL/COLOR").CellActivation = Activation.NoEdit
                .Columns("PIEL/COLOR").Header.Caption = "Piel/Color"
            Else
                .Columns("COLECCION").CellActivation = Activation.NoEdit
                .Columns("COLECCION").Header.Caption = "Colección"
                .Columns("PIELCOLOR").CellActivation = Activation.NoEdit
                .Columns("PIELCOLOR").Header.Caption = "Piel/Color"
            End If
            .Columns("CORRIDA").CellActivation = Activation.NoEdit
            .Columns("CANTIDAD").CellActivation = Activation.NoEdit
            .Columns("Renglon").CellAppearance.TextHAlign = HAlign.Right
            .Columns("CANTIDAD").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("CANTIDAD").DataType = System.Type.GetType("System.Int32")
            .Columns("CANTIDAD").Format = "##,##0"
            .Columns("RANKING").Header.Caption = "Ranking"
            .Columns("CORRIDA").Header.Caption = "Corrida"
            .Columns("CANTIDAD").Header.Caption = "Cantidad"
            .Columns("MODELO").Header.Caption = "Modelo"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        'grdDatos.Rows(0).Selected = True
        band.Columns("CANTIDAD").Width = 100
        Try
            If band.Summaries.Exists("sumuno") Then
                Dim tmpSettings As SummarySettings = band.Summaries("sumuno")
                band.Summaries.Remove(tmpSettings)
            End If

        Catch ex As Exception

        End Try
        If tipo = 1 Then

            Dim contarTotalTickets As Integer = 0
            For Each rowGrd As UltraGridRow In grdDatos.Rows
                obj = New Entidades.InventarioIdeal
                contarTotalTickets = contarTotalTickets + 1
                rowGrd.Cells("Renglon").Value = contarTotalTickets
                With obj
                    .Pcantidad = rowGrd.Cells("CANTIDAD").Value
                    .Pcorrida = rowGrd.Cells("CORRIDA").Value
                    .Pcoleccion = rowGrd.Cells("COLECCIÓN").Value
                    .Pmodelo = rowGrd.Cells("MODELO").Value
                    .Ppiel_color = rowGrd.Cells("PIEL/COLOR").Value
                    .Pranking = rowGrd.Cells("RANKING").Value
                End With
                vInventarioIdealBU.InsertarExcel(obj)
            Next
        Else
            Dim contarTotalTickets As Integer = 0
            For Each rowGrd As UltraGridRow In grdDatos.Rows

                contarTotalTickets = contarTotalTickets + 1
                rowGrd.Cells("Renglon").Value = contarTotalTickets

            Next
        End If

        band.SummaryFooterCaption = "Total"
        Dim sumuno As SummarySettings = band.Summaries.Add("sumuno", SummaryType.Sum, band.Columns("CANTIDAD"))
        sumuno.DisplayFormat = "Sum =  {0:##,###}"
        sumuno.Appearance.TextHAlign = HAlign.Right


    End Sub



    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        LlenarTabla()
    End Sub

    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class