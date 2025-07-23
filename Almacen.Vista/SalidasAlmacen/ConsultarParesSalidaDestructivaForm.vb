Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ConsultarParesSalidaDestructivaForm
    Dim objinstancia As New SalidasAlmacenBU
    Private Sub ConsultarParesSalidaDestructivaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim anioActual = Date.Now.Year
        For index = 1 To 5

            cbanio.Items.Add(anioActual - (6 - index))
        Next
        cbanio.Items.Add(anioActual)
        For index = 1 To 5

            cbanio.Items.Add(anioActual + index)
        Next
        cbanio.SelectedIndex = 5
        Utilerias.ComboObtenerCEDISUsuario(cboxNaveAlmacen)
        ConsultarDatos()
    End Sub
    Private Sub ConsultarDatos()
        Dim Cedis As Integer = 0
        Dim anio = cbanio.Text
        Cedis = cboxNaveAlmacen.SelectedValue
        Cursor = Cursors.WaitCursor
        vwParesS.Columns.Clear()
        grdParesS.DataSource = Nothing
        Dim datos = objinstancia.ConsultarParesSalidaDestructiva(CInt(anio), Cedis)
        grdParesS.DataSource = datos
        vwParesS.OptionsView.ColumnAutoWidth = True
        DiseñoGrid.DiseñoBaseGrid(vwParesS)
        vwParesS.IndicatorWidth = 35
        lblTotalParesProceso.Text = Format(datos.Rows.Count, "##,##0.00")
        Cursor = Cursors.Default
    End Sub

    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwParesS.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultarDatos()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
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
                    If vwParesS.GroupCount > 0 Then
                        vwParesS.ExportToXlsx(.SelectedPath + "\ParesSalidasDestructivas_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        vwParesS.ExportToXlsx(.SelectedPath + "\ParesSalidasDestructivas_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "ParesSalidasDestructivas_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\ParesSalidasDestructivas_" + fecha_hora + ".xlsx")

                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 15
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 50
    End Sub
End Class