Imports Infragistics.Win.UltraWinGrid
Imports Infragistics

Public Class ListaProveedoresForm
    Dim IDPersona As New Int32
    Dim ClasificacionPersona As New Int32
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)
      
    End Sub

    Private Sub ListaProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        cmbTipo = Tools.Controles.ComboClasePersonaCMB(cmbTipo)
    End Sub

    Private Sub cmbTipo_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            cmbClasificacion = Tools.Controles.ComboClasificacionPersona(cmbClasificacion, CInt(cmbTipo.SelectedValue))

            If cmbTipo.Text.Contains("CONTACTO") Or cmbTipo.Text.Contains("PROVEEDOR") Then


                If cmbTipo.Text.Contains("CONTACTO") Then

                Else


                End If



                If cmbTipo.Text.Contains("PROVEEDOR") Then

                Else

                End If

            Else


            End If


        Catch ex As Exception

        End Try
    End Sub

  
    Private Sub gridListaProveedores_Click(sender As Object, e As EventArgs)
        Try

            IDPersona = CInt(gridListaProveedores.Rows(gridListaProveedores.ActiveRow.Index).Cells("PersonaID").Value)
            ClasificacionPersona = CInt(gridListaProveedores.Rows(gridListaProveedores.ActiveRow.Index).Cells("ClasificacionPersona").Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If IDPersona > 0 Then
            Dim EditarPersona As New AltaPersona
            EditarPersona.PIDPersona = IDPersona
            EditarPersona.PClasificacionPersona = ClasificacionPersona
            Try
                EditarPersona.ptipopersona = CInt(cmbTipo.SelectedValue)
            Catch ex As Exception

            End Try
            EditarPersona.ShowDialog()
        Else
            Dim forma As New AdvertenciaForm
            forma.mensaje = "Selecciona un proveedor para poder editar"
            forma.ShowDialog()
        End If
    End Sub

    Private Sub btnExpExcel_Click(sender As Object, e As EventArgs) Handles btnExpExcel.Click
        Dim ExportExcel As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        SaveAs.Filter = " XLS Excel (*.xls*)|*.xls| XLSX |*.xlsx"
        If gridListaProveedores.Rows.Count > 0 Then
            With SaveAs
                .Title = "Guardar archivo como:"
                .Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
                .ShowDialog()
                If .FileName <> "" Then
                    ExportExcel.Export(gridListaProveedores, .FileName)
                    Dim objExcelWorkBook As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook
                    With objExcelWorkBook
                        .Worksheets.Add("Lista Proveedores")
                        ExportExcel.Export(gridListaProveedores, objExcelWorkBook)
                    End With
                    Try
                        System.Diagnostics.Process.Start(.FileName)
                    Catch ex As Exception
                        MsgBox(ex)
                    End Try
                End If
            End With
        Else
            MessageBox.Show("Seleccionar algo ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If


    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim EditarPersona As New AltaPersona
        EditarPersona.MdiParent = MdiParent
        EditarPersona.Show()
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cmbTipo.SelectedIndex > 0 Then
            lblTipo.ForeColor = Color.Black

            Dim ObjBU As New Framework.Negocios.PersonasBU
            Dim Tipo, Clase As Int32

            If cmbTipo.SelectedIndex > 0 Then
                Tipo = CInt(cmbTipo.SelectedValue)
            Else
                Tipo = 0
            End If
            If cmbClasificacion.SelectedIndex > 0 Then
                Clase = CInt(cmbClasificacion.SelectedValue)
            Else
                Clase = 0
            End If
            Dim Activo As Boolean
            If rdoSiActivo.Checked = True Then
                Activo = True
            Else
                Activo = False
            End If

            gridListaProveedores.DataSource = ObjBU.ListaPersonas(Tipo, Clase, Activo)
            gridListaProveedores.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            gridListaProveedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            gridListaProveedores.DisplayLayout.Bands(0).Columns("Nombre").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("Tipo").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("Clasificacion").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("A Paterno").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("A Materno").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("Razon Social").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("Activo").CellActivation = Activation.NoEdit
            gridListaProveedores.DisplayLayout.Bands(0).Columns("PersonaID").Hidden = True
            gridListaProveedores.DisplayLayout.Bands(0).Columns("ClasificacionPersona").Hidden = True
            Try
                Dim ConsecutivoColumn As UltraGridColumn = gridListaProveedores.DisplayLayout.Bands(0).Columns.Add("Consecutivo", "#")
                ConsecutivoColumn.DataType = GetType(Integer)
                ConsecutivoColumn.Header.VisiblePosition = 1
                ConsecutivoColumn.AutoSizeMode = ColumnAutoSizeMode.VisibleRows
                Dim Consecutivo As New Int32
                Consecutivo = 1
                For Each a As Infragistics.Win.UltraWinGrid.UltraGridRow In gridListaProveedores.Rows
                    a.Cells("Consecutivo").Value = Consecutivo
                    Consecutivo += 1
                Next
            Catch ex As Exception


               
            End Try

        Else

            lblTipo.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridListaProveedores.DataSource = Nothing

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gbxFiltros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gbxFiltros.Height = 156
    End Sub

    Private Sub gridListaProveedores_Click1(sender As Object, e As EventArgs) Handles gridListaProveedores.Click
        Try

            IDPersona = CInt(gridListaProveedores.Rows(gridListaProveedores.ActiveRow.Index).Cells("PersonaID").Value)
            ClasificacionPersona = CInt(gridListaProveedores.Rows(gridListaProveedores.ActiveRow.Index).Cells("ClasificacionPersona").Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
        Try
            cmbClasificacion = Tools.Controles.ComboClasificacionPersona(cmbClasificacion, CInt(cmbTipo.SelectedValue))

            If cmbTipo.Text.Contains("CONTACTO") Or cmbTipo.Text.Contains("PROVEEDOR") Then


                If cmbTipo.Text.Contains("CONTACTO") Then

                Else


                End If



                If cmbTipo.Text.Contains("PROVEEDOR") Then

                Else

                End If

            Else


            End If


        Catch ex As Exception

        End Try
    End Sub
End Class