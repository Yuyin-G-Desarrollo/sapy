Public Class AgregarEditarMotivosCancelacionForm

    Public MotivoCancelacionId As Integer = -1
    Public MotivoNombre As String = String.Empty
    Public MotivoCancelacionDescripcion As String = String.Empty
    Public Activo As Boolean = True
    Public tipoAccion As String



    Private Sub AgregarEditarMotivosCancelacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If MotivoCancelacionId >= 0 Then
            txtNombreMotivo.Text = MotivoNombre.Trim.ToUpper()
            txtDescripcionCancelacion.Text = MotivoCancelacionDescripcion.Trim.ToUpper()


            If Activo = True Then
                rdoSi.Checked = True
                rdoNo.Checked = False
            Else
                rdoSi.Checked = False
                rdoNo.Checked = True
            End If

            lblActivo.Visible = True
            rdoNo.Visible = True
            rdoSi.Visible = True
        Else
            rdoSi.Checked = True
            rdoNo.Checked = False
            txtNombreMotivo.Text = String.Empty
            txtDescripcionCancelacion.Text = String.Empty


        End If

        If tipoAccion = "E" Then
            txtNombreMotivo.Text = MotivoNombre
            txtDescripcionCancelacion.Text = MotivoCancelacionDescripcion
        End If


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Function ValidacionCamposCapturados() As Boolean
        Dim Resultado As Boolean = True

        If String.IsNullOrEmpty(txtNombreMotivo.Text) = True Then
            Resultado = False
            lblMotivoCancelacion.ForeColor = Color.Red
        ElseIf String.IsNullOrEmpty(txtDescripcionCancelacion.Text) = True Then
            Resultado = False
            lblDescripcionCancelacion.ForeColor = Color.Red
        Else
            lblMotivoCancelacion.ForeColor = Color.Black
            lblDescripcionCancelacion.ForeColor = Color.Black
        End If

        Return Resultado
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Ventas.Negocios.CatalogoMotivoCancelacionBU
        Dim objMotivoCancelacionEntidad As New Entidades.CatalogoMotivoCancelacion
        Dim dtRespuesta As New DataTable
        'SE VALIDA QUE TENGA UN VALOR EL CAMPO DE MOTIVO CANCELACION 
        If ValidacionCamposCapturados() = False Then
            show_message("Advertencia", "Los campos en rojo son obligatorios")
            Return
        End If

        objMotivoCancelacionEntidad.Activo = rdosi.Checked
        objMotivoCancelacionEntidad.Nombre = txtNombreMotivo.Text.Trim()
        objMotivoCancelacionEntidad.Descripcion = txtDescripcionCancelacion.Text.Trim()
        'Si el registro ya existe se editará
        If MotivoCancelacionId >= 0 Then
            objMotivoCancelacionEntidad.MotivoCancelacionID = MotivoCancelacionId
            objMotivoCancelacionEntidad.UsuarioModificoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objBU.EditarMotivoCancelacion(objMotivoCancelacionEntidad)
            show_message("Exito", "Se han realizado los cambios en el motivo de cancelación")
        Else
            objMotivoCancelacionEntidad.UsuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            dtRespuesta = objBU.AltaMotivoCancelacion(objMotivoCancelacionEntidad)

            If dtRespuesta.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                show_message("Exito", "Se ha registrado un nuevo motivo de cancelación")
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                'show_message("Aviso", "El registro ya existe")
                show_message("Advertencia", "El registro ya existe")
            End If


        End If

        '' Me.DialogResult = Windows.Forms.DialogResult.OK
        '' Me.Close()
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