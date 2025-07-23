Imports Ventas.Negocios
Imports Tools
Public Class EnfoqueVentasSeleccionArticulosForm

    Dim objDa As New ReporteEnfoqueVentasBU


    Private Sub EnfoqueVentasSeleccionArticulosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Mostrar()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Mostrar()
    End Sub

    Public Sub Mostrar()
        Dim DtResultado As New DataTable

        DtResultado = objDa.MostrarModelosEnfoqueVentas()
        grdModelos.DataSource = DtResultado

        DiseñoGrid.DiseñoBaseGrid(vwModelos)

        vwModelos.Columns.ColumnByFieldName("ProductoID").Visible = False
        vwModelos.Columns.ColumnByFieldName("ColeccionId").Visible = False
        vwModelos.Columns.ColumnByFieldName("PielID").Visible = False
        vwModelos.Columns.ColumnByFieldName("ColorID").Visible = False

        lblTotalParesProceso.Text = CDbl(DtResultado.Rows.Count).ToString("N0")

    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim confirmar As New Tools.ConfirmarForm
        Dim NumeroFilas As Integer
        Dim ProductoId As Integer = 0
        Dim ColeccionId As Integer = 0
        Dim ModeloSAY As String = String.Empty
        Dim PielId As Integer = 0
        Dim ColorId As Integer = 0
        Dim objbu As New ReporteEnfoqueVentasBU



        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = vwModelos.DataRowCount

            objbu.BorrarInformacion()

            For index As Integer = 0 To NumeroFilas Step 1


                If CBool(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "Seleccion")) = True Then


                    ProductoId = CInt(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ProductoID"))
                    ColeccionId = CInt(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ColeccionId"))
                    ModeloSAY = vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "Modelo SAY")
                    PielId = CInt(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "PielID"))
                    ColorId = CInt(vwModelos.GetRowCellValue(vwModelos.GetVisibleRowHandle(index), "ColorID"))

                    objbu.GuardarInformacion(ProductoId, ColeccionId, ModeloSAY, PielId, ColorId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


                End If
            Next


            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha guardado la informacion.")

            Mostrar()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnVerDetalles_Click_1(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then



                    grdModelos.ExportToXlsx(.SelectedPath + "\Datos_MdelosEnfoqueVentas_" + fecha_hora + ".xlsx")



                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_MdelosEnfoqueVentas_" & fecha_hora.ToString() & ".xlsx")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_MdelosEnfoqueVentas_" + fecha_hora + ".xlsx")
                End If



            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub


End Class