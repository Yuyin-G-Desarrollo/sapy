Imports Tools

Public Class MotivosCancelacionForm

    Public PedidoSAYID As String = String.Empty
    Public Partidas As String = String.Empty
    Public CancelarPedidoCompleto As Boolean = False
    Public CancelacionPedidosForm As CancelacionPedidosForm

    Dim objBU As New Ventas.Negocios.CancelacionPedidosBU

    Private Sub MotivosCancelacionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarMotivosCancelacion()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CargarMotivosCancelacion()
        Dim DtMotivosCancelacion As New DataTable
        Try
            Cursor = Cursors.WaitCursor
            DtMotivosCancelacion = objBU.CatalogoMotivosCancelacion()

            DtMotivosCancelacion.Rows.InsertAt(DtMotivosCancelacion.NewRow, 0)
            cmbMotivosCancelacion.DataSource = DtMotivosCancelacion
            cmbMotivosCancelacion.DisplayMember = "MotivoCancelacion"
            cmbMotivosCancelacion.ValueMember = "IdEstatus"

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ha ocurrido un Error al mostrar la información. Vuelva a intentar.")
        End Try

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Dim confirmacion As New Tools.ConfirmarForm
            Dim Split_Pedidos As String() = Split(PedidoSAYID, ",")
            Dim Split_Partidas As String() = Split(Partidas, ",")
            Dim OTGeneradas As Integer = 0
            Dim DTCancelacion As New DataTable
            Dim OTGenerada As String = String.Empty

            If cmbMotivosCancelacion.SelectedIndex = 0 Then
                show_message("Advertencia", "No se seleccionado un motivo de cancelación.")
                Return
            End If

            If CancelarPedidoCompleto = True Then
                confirmacion.mensaje = "Se cancelarán " & Split_Pedidos.Length.ToString & " pedidos, este proceso no se puede revertir. ¿Desea continuar?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor

                    For Each FilaPedido As String In Split_Pedidos
                        DTCancelacion = objBU.CancelarPedido(FilaPedido, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObervacionesCancelacion.Text.Trim, cmbMotivosCancelacion.SelectedValue)
                        If DTCancelacion.Rows.Count > 0 Then
                            If DTCancelacion.Rows(0).Item(0) <> String.Empty Then
                                OTGeneradas += Split(DTCancelacion.Rows(0).Item(0), ",").Length
                                OTGenerada = DTCancelacion.Rows(0).Item(0)
                            End If

                            If CInt(DTCancelacion.Rows(0).Item("PartidasCanceladas")) > 0 Then
                                objBU.ActualizarEstatusEncabezado(PedidoSAYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObervacionesCancelacion.Text, cmbMotivosCancelacion.SelectedValue)
                            End If

                        End If
                        'objBU.ActualizarEstatusEncabezado(FilaPedido, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObervacionesCancelacion.Text, cmbMotivosCancelacion.SelectedValue)
                    Next
                    
                    If OTGeneradas = 0 Then
                        show_message("Exito", "Se ha cancelado el pedido.")                        
                    ElseIf OTGeneradas = 1 And Split_Pedidos.Length = 1 Then
                        show_message("Exito", "Se ha generado la orden de desasignación " & OTGenerada & ". El pedido será cancelado una vez confirmada la orden de desasignación.")
                    Else
                        show_message("Exito", "se han generado " & OTGeneradas.ToString() & " OTs de desasignación. El pedido será cancelado una vez confirmada la orden de desasignación.")
                    End If


                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            Else
                confirmacion.mensaje = "Se cancelarán " & Split_Partidas.Length.ToString & " partidas, este proceso no se puede revertir. ¿Desea continuar?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    DTCancelacion = objBU.CancelarPartidas(PedidoSAYID, Partidas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObervacionesCancelacion.Text.Trim, cmbMotivosCancelacion.SelectedValue)
                    If DTCancelacion.Rows.Count > 0 Then
                        If DTCancelacion.Rows(0).Item(0) <> String.Empty Then
                            OTGeneradas += Split(DTCancelacion.Rows(0).Item(0), ",").Length
                            OTGenerada = DTCancelacion.Rows(0).Item(0)
                        End If

                        If CInt(DTCancelacion.Rows(0).Item("PartidasCanceladas")) > 0 Then
                            objBU.ActualizarEstatusEncabezado(PedidoSAYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObervacionesCancelacion.Text, cmbMotivosCancelacion.SelectedValue)
                        End If

                    End If

                    If OTGeneradas = 0 Then
                        show_message("Exito", "Se ha cancelado el pedido.")
                    ElseIf OTGeneradas = 1 And Split_Pedidos.Length = 1 Then
                        show_message("Exito", "Se ha generado la orden de desasignación " & OTGenerada & ". Las partidas seran canceladas hasta confirmar la orden de desasignación.")
                    Else
                        show_message("Exito", "Se han generado " & OTGeneradas.ToString() & " OTs de desasignación. Las partidas seran canceladas hasta confirmar la orden de desasignación. ")
                    End If


                    'objBU.ActualizarEstatusEncabezado(PedidoSAYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, txtObervacionesCancelacion.Text, cmbMotivosCancelacion.SelectedValue)
                    'If OTGeneradas > 0 Then
                    '    show_message("Exito", "Se han cancelado las partidas, y se ha generado la orden de desasignación  " & OTGenerada.ToString() & ".")
                    '    'CancelacionPedidosForm.CargarPedidos()
                    'Else
                    '    show_message("Exito", "Se han cancelado las partidas.")
                    '    'CancelacionPedidosForm.CargarPedidos()
                    'End If

                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ha ocurrido un error al cancelar.")
        End Try
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

  
End Class