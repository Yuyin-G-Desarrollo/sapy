Imports Tools
Public Class SeleccionarDevolucionesForm

    Private ObjBU As New Negocios.VerificacionSalidasBU

    Private Sub SeleccionarDevolucionesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarGridFoliosDevolucion()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnGenerarSalida.Click

        Dim confirmar As New Tools.ConfirmarForm
        Cursor = Cursors.WaitCursor
        Try
            confirmar.mensaje = "¿Esta seguro de confirmar la entrega de los folios?"

            If ValidarFoliosSeleccionados() = True Then
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    GenerarSalidaFolios()
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha generado la salida de los folios de devolución.")
                    Me.Close()
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se han seleccionado folios de devolución.")
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

        Cursor = Cursors.Default

    End Sub

    Public Sub CargarGridFoliosDevolucion()
        Dim dtResultado As New DataTable
        dtResultado = ObjBU.ConsultaFolioDevolucionPendienteSalida()
        grdDevoluciones.DataSource = dtResultado
        DiseñoGrid.DiseñoBaseGrid(viewDevoluciones)

    End Sub

    Public Sub GenerarSalidaFolios()
        Dim NumeroFilas As Integer = 0
        Dim FoliosDevolucion As String = String.Empty
        Dim Folio As String = String.Empty

        Cursor = Cursors.WaitCursor
        NumeroFilas = viewDevoluciones.DataRowCount - 1

        Try

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(viewDevoluciones.GetRowCellValue(viewDevoluciones.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    Folio = viewDevoluciones.GetRowCellValue(viewDevoluciones.GetVisibleRowHandle(index), "Folio")

                    If FoliosDevolucion = String.Empty Then
                        FoliosDevolucion = Folio
                    Else
                        FoliosDevolucion = FoliosDevolucion & "," & Folio
                    End If

                End If

            Next

            If FoliosDevolucion <> String.Empty Then
                ObjBU.GenerarSalidaFolioDevolucion(FoliosDevolucion)
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

        Cursor = Cursors.Default

    End Sub

    Public Function ValidarFoliosSeleccionados() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim FilasSeleccionadas As Integer = 0
        Dim Resultado As Boolean = False

        Cursor = Cursors.WaitCursor
        NumeroFilas = viewDevoluciones.DataRowCount - 1

        Try
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(viewDevoluciones.GetRowCellValue(viewDevoluciones.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    FilasSeleccionadas += 1
                End If

            Next

            If FilasSeleccionadas > 0 Then
                FilasSeleccionadas = True
            Else
                FilasSeleccionadas = False
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Return FilasSeleccionadas
        End Try


        Return FilasSeleccionadas

    End Function

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Cursor = Cursors.WaitCursor
        NumeroFilas = viewDevoluciones.DataRowCount - 1

        For index As Integer = 0 To NumeroFilas Step 1
            viewDevoluciones.SetRowCellValue(viewDevoluciones.GetVisibleRowHandle(index), "Seleccionar", chkSeleccionarTodo.Checked)
        Next

        Cursor = Cursors.Default

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class