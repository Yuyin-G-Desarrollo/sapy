Imports Almacen.Negocios
Imports Tools

Public Class IngresarNumeroFolioEntradaForm

    Public folio As Int64
    Public IdNave As Integer
    Public ComercilizadoraId As Integer = 0
    Public Estado_SalidaNave As String
    Public Nave_Valida As Boolean 'TRUE PARA NAVE VALIDA, FALSE PARA NAVE INVALIDA
    Public EstadoFolioSalidaNaveID As Integer = 0

    Private Sub IngresarNumeroFolioEntradaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtFolio.Select()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        ValidarFolio()
    End Sub

    Private Sub ValidarFolio()
        Try
            Cursor = Cursors.WaitCursor

            If txtFolio.Text = "" Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha capturado un Folio.")
            ElseIf IsNumeric(txtFolio.Text) = False Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El Folio debe de tener solo números.")
            Else
                folio = txtFolio.Text
                If Validar_Folio_De_Lote(folio, IdNave, ComercilizadoraId) = True Then
                    Terminar_Captura_Folio()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El folio introducido no corresponde con un folio para la nave seleccionada, seleccione la nave correcta para este folio o introduzca un folio asignado a la nave seleccionada.")
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Function Validar_Folio_De_Lote(ByVal IdSAlidaNave As Integer, ByVal Id_NAve As Integer, ByVal ComercializadoraId As Integer) As Boolean
        Dim objBU As New EntradaProductoBU
        Dim objBUEntrada As New SalidasAlmacenBU
        Dim dtTabla As DataTable
        dtTabla = objBUEntrada.ValidaFolioEntrada(IdSAlidaNave, Id_NAve, ComercializadoraId)

        If dtTabla.Rows.Count = 0 Then
            EstadoFolioSalidaNaveID = 0
        Else
            EstadoFolioSalidaNaveID = dtTabla.Rows(0).Item(0)
        End If

        If dtTabla.Rows.Count = 0 Then
            Nave_Valida = False
        ElseIf IsDBNull(dtTabla.Rows(0).Item(1)) Then
            Nave_Valida = False
        Else
            Nave_Valida = True
        End If

        Return Nave_Valida

    End Function

    Private Sub Terminar_Captura_Folio()
        If txtFolio.Text = "" Then
            Me.Close()
        Else
            folio = Convert.ToInt64(txtFolio.Text)

            Dim FORMA_ADVERTENCIAS As New AdvertenciaForm
            FORMA_ADVERTENCIAS.StartPosition = FormStartPosition.CenterScreen

            If EstadoFolioSalidaNaveID = 0 Then 'INVALIDO
                FORMA_ADVERTENCIAS.mensaje = "El folio introducido no es valido."
                FORMA_ADVERTENCIAS.ShowDialog()

            ElseIf Nave_Valida = False Then
                FORMA_ADVERTENCIAS.mensaje = "El folio introducido no corresponde con un folio para la nave seleccionada, seleccione la nave correcta para este folio o introduzca un folio asignado a la nave seleccionada."
                FORMA_ADVERTENCIAS.ShowDialog()

            ElseIf EstadoFolioSalidaNaveID = 186 Then 'EN PROCESO
                FORMA_ADVERTENCIAS.mensaje = "El folio introducido pertenece a un proceso de salida de nave que aun no ha sido concluido, para poder darle entrada este proceso debe de ser concluido."
                FORMA_ADVERTENCIAS.ShowDialog()

            ElseIf EstadoFolioSalidaNaveID = 189 Then 'ENTREGADO
                FORMA_ADVERTENCIAS.mensaje = "La mercancia del folio introducido ya fue ingresada al almacen, no es posible volver a darle ingreso."
                FORMA_ADVERTENCIAS.ShowDialog()

            Else
                'Dim FORMA_EXITO As New ExitoForm
                'FORMA_EXITO.StartPosition = FormStartPosition.CenterScreen
                'FORMA_EXITO.mensaje = "Folio valido"
                'FORMA_EXITO.ShowDialog()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End If

    End Sub

    Private Sub IngresarNumeroFolioEntradaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> DialogResult.OK Then
            Me.DialogResult = DialogResult.Cancel
        End If

    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ValidarFolio()
        End If
    End Sub
End Class