Imports Ventas.Negocios
Imports Tools

Public Class ProspectaNotasRevisionForm

    Public ProspectaID As Integer = -1
    Private TipoPerfil As Integer = -1
    Public EstatusProspecta As String = String.Empty

    Private Sub ProspectaNotasRevisionForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim obj As New ProspectaBU
        Dim DTInformacionComentario As DataTable
        txtFechaCreacion.Enabled = False
        txtUsername.Enabled = False

        ObtenerTipoPerfil()

        If ProspectaID <> -1 Then
            DTInformacionComentario = obj.ConsultaComentarioRevisionProspecta(ProspectaID)
            If DTInformacionComentario.Rows.Count > 0 Then
                txtComentario.Text = DTInformacionComentario.Rows(0).Item("Comentario").ToString
                txtFechaCreacion.Text = DTInformacionComentario.Rows(0).Item("FechaComentario").ToString
                txtUsername.Text = DTInformacionComentario.Rows(0).Item("Usuario").ToString

            Else
                If TipoPerfil = 5 Then
                    txtFechaCreacion.Text = Date.Now.ToShortDateString()
                    txtUsername.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString()
                    txtComentario.Enabled = True
                    btnGuardar.Enabled = True
                Else
                    txtComentario.Enabled = False
                    btnGuardar.Enabled = False
                End If

            End If

            If TipoPerfil = 5 Then
                txtComentario.Enabled = True
                btnGuardar.Enabled = True
            Else
                txtComentario.Enabled = False
                btnGuardar.Enabled = False
            End If

            If EstatusProspecta <> "REVISIÓN" Then
                txtComentario.Enabled = False
                btnGuardar.Enabled = False
            End If
        Else
            txtComentario.Enabled = False
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Sub ObtenerTipoPerfil()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ATENCIONCLIENTEEXTERNO") Then
            TipoPerfil = 4
        End If

        ''Atencion a clientes interno e externo
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ATENCIONCLIENTES") Then
            TipoPerfil = 0
        End If


        'Agente de ventas
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_AGENTEVENTAS") Then
            TipoPerfil = 1
        End If

        'Agente de ventas
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ANALISTAVENTAS") Then
            TipoPerfil = 3
        End If

        'Jefatura Atencion Clientes
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_JEFATURA") Then
            TipoPerfil = 2
        End If


        'Almacén
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_OT_PROSPECTA", "VENT_PROSPECTA_ALMACEN") Then
            TipoPerfil = 5
        End If


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New ProspectaBU
        Try

            If txtComentario.Text.Trim() = String.Empty Then
                show_message("Advertencia", "EL campo de comentario se encuentra vacío.")
                Return
            End If
            Cursor = Cursors.WaitCursor

            obj.InsertarComentario(ProspectaID, txtComentario.Text.Trim(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            txtUsername.Text = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            txtFechaCreacion.Text = Date.Now.ToString()
            Cursor = Cursors.Default
            show_message("Exito", "Se han guardado los comentarios en la prospecta.")
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al guardar.")
        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
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