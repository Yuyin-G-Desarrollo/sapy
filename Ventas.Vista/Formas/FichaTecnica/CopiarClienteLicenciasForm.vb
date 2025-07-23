Imports Tools

Public Class CopiarClienteLicenciasForm

    Dim ObjBU As New Negocios.ReplicaClientesBU
    Dim ListaClientes As New List(Of Entidades.Cliente)

    Public ClienteSAYID As Integer = 0
    Public ClienteSICYID As Integer = 0
    Public NombreCliente As String = String.Empty
    Dim UsuarioId As Integer = 0

    Dim ListaMarcas As New List(Of Entidades.Marcas)
    Dim ListaMarcasReplica As New List(Of Entidades.Marcas)

    Private Sub CopiarClienteLicenciasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblNombreCliente.Text = NombreCliente
        If NombreCliente.Contains("(M,G)") Then
            NombreCliente = NombreCliente.Replace("(M,G)", "(M,G REEDITION)")
            txtNombreCliente.Text = NombreCliente
        Else
            txtNombreCliente.Text = NombreCliente + " (REEDITION)"
        End If
        UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas replicar el cliente a Reedition?"

        Try
            Me.Cursor = Cursors.WaitCursor
            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If txtNombreCliente.Text <> String.Empty Then
                    If ObjBU.ValidaExisteReplicaClienteReedition(ClienteSAYID) = False Then
                        If ObjBU.ValidarNombreClienteReedition(txtNombreCliente.Text.Trim()) = False Then
                            If ObjBU.ReplicarClienteReedition(ClienteSAYID, ClienteSICYID, txtNombreCliente.Text.Trim(), UsuarioId) = True Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha replicado correctamente el cliente.")
                                Me.DialogResult = DialogResult.OK
                                Me.Close()
                            Else
                                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrio algun error en la replicacion.Favor de comunicarse a sistemas.")
                                btnAceptar.Enabled = False
                            End If
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El nombre del cliente ya existe.")
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El cliente ya se encuentra replicado.")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha capturado el nombre del cliente.")
                End If

            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class