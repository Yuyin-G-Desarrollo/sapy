Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ModelosSpeedTrackForm

    Public objInstancia As New Negocios.SpeedTrackBU
    Dim confirmar As New Tools.ConfirmarForm
    Dim FilasSeleccionadas As Integer = 0
    Private Sub ReporteSpeedTrackForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarModelosGrid()
    End Sub


    Private Sub ConsultarModelosGrid()
        Me.WindowState = FormWindowState.Maximized
        Cursor = Cursors.WaitCursor
        Dim dataTable = objInstancia.ConsultarModelosSpeedTrack()
        grdModelos.DataSource = Nothing
        vwModelos.Columns.Clear()
        grdModelos.DataSource = dataTable
        DiseñoGrid.DiseñoBaseGrid(vwModelos)
        vwModelos.OptionsView.ColumnAutoWidth = True
        vwModelos.IndicatorWidth = 35
        DiseñoGrid.EstiloColumna(vwModelos, "Seleccion", "SELECCIÓN", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 50, False, Nothing, "")
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwModelos.Columns
            If (col.FieldName <> "MODELO SAY" And col.FieldName <> "Seleccion" And col.FieldName <> "PIEL" And col.FieldName <> "FAMILIA" And col.FieldName <> "COLOR" And col.FieldName <> "COLECCIÓN" And col.FieldName <> "CAPTURO" And col.FieldName <> "FECHACAPTURA") Then

                DiseñoGrid.EstiloColumna(vwModelos, col.FieldName, col.FieldName, False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")
            End If
        Next

        lblTotalParesProceso.Text = String.Format("{0:N0}", dataTable.Rows.Count)
        lblFechaUltimaActualizacion.Text = Date.Now
        Cursor = Cursors.Default

    End Sub

    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwModelos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        ConsultarModelosGrid()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Dim objAdd As New AgregarModelosForm
        objAdd.ShowDialog()
        ConsultarModelosGrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        confirmar.mensaje = "¿Está seguro de borrar todos los modelos?"
        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                objInstancia.EliminarTodosLosModelosSpeedTrack()
                show_message("Exito", "Se eliminaron los modelos correctamente")
                ConsultarModelosGrid()
            Catch ex As Exception
                show_message("Error", ex.Message)
            End Try
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim modelos = obtenerModelosSeleccionados()
            If modelos = "" Then
                show_message("Advertencia", "Selecciona por lo menos un modelos")
            Else
                confirmar.mensaje = "¿Está seguro de eliminar el modelo seleccionado?"
                If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                    objInstancia.EliminarSoloUnModelo(modelos)
                    show_message("Exito", "Se eliminaron los modelos correctamente")
                    ConsultarModelosGrid()
                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Function obtenerModelosSeleccionados() As String
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        FilasSeleccionadas = 0

        Cursor = Cursors.WaitCursor

        Try

            NumeroFilas = vwModelos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "Seleccion")) = True Then
                    FilasSeleccionadas += 1

                    If documentosSeleccionados = String.Empty Then
                        documentosSeleccionados = vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ID").ToString()
                    Else
                        documentosSeleccionados = documentosSeleccionados & "," & vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ID").ToString()
                    End If
                End If
            Next

        Catch ex As Exception

            show_message("Error", ex.Message)

        End Try

        Cursor = Cursors.Default

        Return documentosSeleccionados

    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = vwModelos.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                vwModelos.SetRowCellValue(vwModelos.GetVisibleRowHandle(index), "Seleccion", CheckBox1.Checked)

                If CBool(CheckBox1.Checked) = False Then
                    vwModelos.SetRowCellValue(vwModelos.GetVisibleRowHandle(index), "%", 0)
                End If

            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        DiseñoGrid.EstiloColumna(vwModelos, "Seleccion", "Fcapturo", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then


                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                    grdModelos.ExportToXlsx(.SelectedPath + "\Datos_Modelos_SpeedTrack" + fecha_hora + ".xlsx", exportOptions)

                    show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_Modelos_SpeedTrack" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_Modelos_SpeedTrack" + fecha_hora + ".xlsx")
                End If



            End With
            DiseñoGrid.EstiloColumna(vwModelos, "Seleccion", "Fcapturo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 200, False, Nothing, "")

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        Dim objform As New ActualizarParesAutorizadosForm
        objform.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Dim obj As New ReporteSpeedTrackForm()
        obj.Show()

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_SPEEDTRACK.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_SPEEDTRACK.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class