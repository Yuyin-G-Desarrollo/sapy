Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports DevExpress.XtraPrinting

Public Class DetallesFolioInspeccionFormvb

    Public FolioInspeccionId As Integer = 0
    Public ParesFolio As Integer = 0
    Public ParesIncidencias As Integer = 0
    Public ParesDevueltos As Integer = 0
    Public Nave As String = String.Empty
    Public ParesInspeccionados As Integer = 0

    Dim ObjBU As New Negocios.InspeccionCalidadBU

    Private Sub DetallesFolioInspeccionFormvb_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            lblFolioInspeccion.Text = FolioInspeccionId.ToString
            lblParesInspeccionados.Text = CDbl(ParesInspeccionados).ToString("N0")
            lblNave.Text = Nave
            lblParesIncidencias.Text = CDbl(ParesIncidencias).ToString("N0")
            lblParesDevueltos.Text = CDbl(ParesDevueltos).ToString("N0")

            CargarDetallesFolio()
            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar los detalles.")
        End Try

    End Sub

    Private Sub CargarDetallesFolio()
        Dim DtResultado As New DataTable

        Try
            DtResultado = ObjBU.ReporteDetallesFolioInspeccion(FolioInspeccionId)
            grdInspeccionDetalle.DataSource = DtResultado

            DiseñoGrid.DiseñoBaseGrid(viewInspeccionDetalle)
            viewInspeccionDetalle.IndicatorWidth = 30
            viewInspeccionDetalle.OptionsView.ColumnAutoWidth = True

            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "NumeroAtado", "Número Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Par", "Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "MarcaSAY", "Marca SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "ColeccionSAY", "Colección SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Piel", "Piel", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Color", "Color", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Talla", "Corrida", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Calce", "Punto", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "incidencia", "Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "DescripcionIncidencia", "Descripción Incidencia", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Departamento", "Departamento", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "clasificacion", "Clasificación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "estatus", "Estatus", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "fechadevolucion", "Fecha Devolución", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "fechaentrega", "Fecha Entrega", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Foto1", "Foto1", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "Foto2", "Foto2", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")
            DiseñoGrid.EstiloColumna(viewInspeccionDetalle, "DevolverAtado", "DevolverAtado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Like, False, True, 60, False, Nothing, "")

            lblTotalRegistros.Text = CDbl(DtResultado.Rows.Count).ToString("N0")

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al mostrar los datos.")
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub viewInspeccionDetalle_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles viewInspeccionDetalle.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Cursor = Cursors.WaitCursor
        ExportarExcel(viewInspeccionDetalle)
        Cursor = Cursors.Default
    End Sub

    Private Sub ExportarExcel(ByVal ViewGrid As GridView)
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
                        ViewGrid.ExportToXlsx(.SelectedPath + "\Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        ViewGrid.ExportToXlsx(.SelectedPath + "\Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_DetallesFolio_" + FolioInspeccionId.ToString() + "_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub


    Private Sub viewInspeccionDetalle_RowClick(sender As Object, e As RowClickEventArgs) Handles viewInspeccionDetalle.RowClick
        Dim Form As New VerFotosInspeccionForm
        Dim Foto1 As String = String.Empty
        Dim Foto2 As String = String.Empty
        Dim Incidencia As String = String.Empty
        Dim Departamento As String = String.Empty
        Dim Clasificacion As String = String.Empty
        Dim NumeroAtado As String = String.Empty
        Dim CodigoPar As String = String.Empty
        Dim Modelo As String = String.Empty
        Dim Coleccion As String = String.Empty
        Dim Corrida As String = String.Empty
        Dim Talla As String = String.Empty
        Dim Color As String = String.Empty
        Dim Devuelto As String = String.Empty
        Dim Piel As String = String.Empty
        Dim Lote As String = String.Empty
        Dim Calce As String = String.Empty

        Try
            If e.Clicks = 2 Then
                Foto1 = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Foto1").ToString()
                Foto2 = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Foto2").ToString()
                Incidencia = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "DescripcionIncidencia").ToString()
                Departamento = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Departamento").ToString()
                Clasificacion = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "clasificacion").ToString()
                NumeroAtado = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "NumeroAtado").ToString()
                CodigoPar = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Par").ToString()
                Modelo = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "ModeloSAY").ToString()
                Coleccion = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "ColeccionSAY").ToString()
                Corrida = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Talla").ToString()
                Color = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Color").ToString()
                Devuelto = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "DevolverAtado").ToString()
                Piel = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Piel").ToString()
                Lote = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Lote").ToString()
                Calce = viewInspeccionDetalle.GetRowCellValue(viewInspeccionDetalle.GetVisibleRowHandle(e.RowHandle), "Calce").ToString()

                With Form
                    .Foto1 = Foto1
                    .Foto2 = Foto2
                    .Incidencia = Incidencia
                    .Departamento = Departamento
                    .Clasificacion = Clasificacion
                    .NumeroAtado = NumeroAtado
                    .CodigoPar = CodigoPar
                    .Modelo = Modelo
                    .Coleccion = Coleccion
                    .Corrida = Corrida
                    .Talla = Calce
                    .Color = Color
                    .Devuelto = Devuelto
                    .Lote = Lote
                    .Piel = Piel
                    .ShowDialog()
                End With




            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub viewInspeccionDetalle_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles viewInspeccionDetalle.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        Try
            Cursor = Cursors.WaitCursor

            If e.Column.FieldName = "DevolverAtado" Then
                If e.CellValue = "SI" Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "clasificacion" Then
                If e.CellValue = "CRITICO" Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            End If


            If e.Column.FieldName = "incidencia" Then
                If e.CellValue = "CON INCIDENCIA" Then
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Green
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)


        Dim DevolverAtado As String = viewInspeccionDetalle.GetRowCellValue(e.RowHandle, "DevolverAtado")
        Dim Clasificacion As String = viewInspeccionDetalle.GetRowCellValue(e.RowHandle, "clasificacion")
        Dim Incidencia As String = viewInspeccionDetalle.GetRowCellValue(e.RowHandle, "incidencia")


        Try

            If e.ColumnFieldName = "DevolverAtado" Then
                If DevolverAtado = "SI" Then
                    e.Formatting.Font.Color = Color.Red
                End If
            End If

            If e.ColumnFieldName = "clasificacion" Then
                If Clasificacion = "CRITICO" Then
                    e.Formatting.Font.Color = Color.Red
                End If

            End If

            If e.ColumnFieldName = "incidencia" Then
                If Incidencia = "CON INCIDENCIA" Then
                    e.Formatting.Font.Color = Color.Red
                Else
                    e.Formatting.Font.Color = Color.Green
                End If
            End If

        Catch ex As Exception

        End Try

        e.Handled = True
    End Sub

    Private Sub lblTitulo_Click(sender As Object, e As EventArgs) Handles lblTitulo.Click

    End Sub
End Class