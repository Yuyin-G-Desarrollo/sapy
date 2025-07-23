Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class CatalogoPeriodosDeVacacionesForm
    Private Sub CatalogoPeriodosDeVacacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjB As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
        cmbpatron = ObjB.llenarcmbPatrón(cmbpatron)
        llenarcomboFechas()
        For index = 0 To cmbAnio.Items.Count - 1
            Dim anio As String = Date.Now.Year
            If cmbAnio.Items.Item(index).Value.Equals(anio) Then
                cmbAnio.SelectedIndex = index

            End If
        Next
        PoblarGrid()
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

    Private Sub PoblarGrid()
        Me.Cursor = Cursors.WaitCursor
        Dim objBu As New Negocios.CatalogoDiasNoLaboralesBU
        Dim dtperidoVacaciones As New DataTable
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbpatron.Text.Equals("") Then
            dtperidoVacaciones = objBu.Consulta_PeriodoVacacional(cmbAnio.Text, 0)
        Else
            dtperidoVacaciones = objBu.Consulta_PeriodoVacacional(cmbAnio.Text, cmbpatron.SelectedValue)
        End If


        If dtperidoVacaciones.Rows.Count > 0 Then
            grdDiasFestivos.DataSource = dtperidoVacaciones
            DiseñoGrid.DiseñoBaseGrid(viewDiasFestivos)
            viewDiasFestivos.IndicatorWidth = 35
            viewDiasFestivos.OptionsView.ColumnAutoWidth = False
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "Periodo", "Periodo", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "Patron", "Patron", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 250, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "Tipo", "Tipo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "FechaISS", "Fecha Inicio " & vbCrLf & "Semana Santa", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 169, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "FechaFSS", "Fecha Fin" & vbCrLf & " Semana Santa", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "DiasSS", "Dias Semana" & vbCrLf & " Santa", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 169, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "FechaIN", "Fecha Inicio" & vbCrLf & " Navidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "FechaFN", "Fecha Fin" & vbCrLf & " Navidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 169, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "DiasNavidad", "Dias Navidad", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 300, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewDiasFestivos, "anio", "anio", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 300, False, Nothing, "")



        Else
            objMensajeAdv.mensaje = "La consulta no devolvió ningún resultado"
            objMensajeAdv.Show()
            grdDiasFestivos.DataSource = dtperidoVacaciones
        End If
        Me.Cursor = Cursors.Default
        lblTotalRegistros.Text = dtperidoVacaciones.Rows.Count
        Me.cmbAnio.Select()

    End Sub


    Private Sub grdDiasFestivos_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewDiasFestivos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        PoblarGrid()
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim listado As New AltaPeriodoVacacionesForm
        Dim anio = cmbAnio.Text

        listado.StartPosition = FormStartPosition.CenterScreen
        listado.itemn = cmbAnio.SelectedIndex
        listado.ShowDialog()
        PoblarGrid()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 25
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 62
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim NumeroFilas As Integer = 0
        Try
            NumeroFilas = viewDiasFestivos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(viewDiasFestivos.IsRowSelected(viewDiasFestivos.GetVisibleRowHandle(index))) = True Then
                    Dim departamentoID = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Periodo").ToString()
                    If departamentoID <> String.Empty Then
                        Dim fechaISS As String = String.Empty
                        Dim fechaFSS As String = String.Empty
                        Dim fechaIN As String = String.Empty
                        Dim fechaFN As String = String.Empty

                        Dim anio = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "anio").ToString()

                        fechaISS = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "FechaISS").ToString()
                        fechaFSS = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "FechaFSS").ToString()
                        fechaIN = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "FechaIN").ToString()
                        fechaFN = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "FechaFN").ToString()

                        If fechaISS.Contains("----") Then
                            fechaISS = "1900-01-01"
                        End If
                        If fechaFSS.Contains("----") Then
                            fechaFSS = "1900-01-01"
                        End If
                        If fechaIN.Contains("----") Then
                            fechaIN = "1900-01-01"
                        End If
                        If fechaFN.Contains("----") Then
                            fechaFN = "1900-01-01"
                        End If

                        Dim listado As New EditarPeriodoVacacionesForm
                        listado.StartPosition = FormStartPosition.CenterScreen
                        listado.txtPatron.Text = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Patron").ToString()
                        listado.txtidpatron.Text = cmbpatron.SelectedValue
                        listado.anio = cmbAnio.SelectedIndex
                        listado.txtidpatron.Text = viewDiasFestivos.GetRowCellValue(viewDiasFestivos.GetVisibleRowHandle(index), "Periodo").ToString()
                        listado.fechaISS = fechaISS
                        listado.fechaFSS = fechaFSS
                        listado.fechaIN = fechaIN
                        listado.fechaFN = fechaFN
                        listado.ShowDialog()
                        PoblarGrid()
                    End If

                End If
            Next

        Catch ex As Exception

            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El Patron  no es valido" + ex.Message)
        End Try
    End Sub
End Class