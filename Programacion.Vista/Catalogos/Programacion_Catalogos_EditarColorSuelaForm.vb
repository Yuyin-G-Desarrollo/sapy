Imports Tools

Public Class Programacion_Catalogos_EditarColorSuelaForm

    Dim colorsuelaId As Int32
    Dim activo As Boolean

    Public Sub LlenarDatos(ByVal EntidadColorSuela As Entidades.ColorSuela)
        colorsuelaId = Convert.ToInt32(EntidadColorSuela.PColorSuelaId)
        activo = EntidadColorSuela.PActivo
        txtCodigo.Text = EntidadColorSuela.PColorSuelaId
        txtDescripcion.Text = EntidadColorSuela.PNombreColor
        If EntidadColorSuela.PActivo = True Then
            rdoActivo.Checked = True
        ElseIf EntidadColorSuela.PActivo = False Then
            rdoInactivo.Checked = True
        End If
    End Sub

    Public Function GuardarCambios() As DataTable
        Dim objBU As New Programacion.Negocios.ColoresSuelaBU
        Dim EntidadColorSuela As New Entidades.ColorSuela
        Dim dtColorSuela As New DataTable

        EntidadColorSuela.PColorSuelaId = colorsuelaId.ToString
        EntidadColorSuela.PNombreColor = txtDescripcion.Text

        If rdoActivo.Checked = True Then
            EntidadColorSuela.PActivo = "True"
        ElseIf rdoInactivo.Checked = True Then
            EntidadColorSuela.PActivo = "False"
        End If

        Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        dtColorSuela = objBU.EditarColorSuela(EntidadColorSuela, Usuario)
        Return dtColorSuela
    End Function

    Public Function ValidarRepetidos() As Boolean
        Dim objBU As New Programacion.Negocios.ColoresSuelaBU
        Dim dtContadorRepetidos As DataTable
        Dim contador As Int32 = 0
        Dim colorsuelaId As String = txtCodigo.Text
        dtContadorRepetidos = objBU.ValidarRepetidos(colorsuelaId)
        contador = Convert.ToInt32(dtContadorRepetidos.Rows(0)(0).ToString)
        If contador >= 1 Then
            If activo = False Then
                If rdoInactivo.Checked = True Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
        Return True
    End Function

    Public Function validaVacio() As Boolean
        If (txtDescripcion.Text = Nothing) Then
            lblDescripcion.ForeColor = Drawing.Color.Red
            Return False
        End If
        lblDescripcion.ForeColor = Drawing.Color.Black
        Return True
    End Function

    Private Sub Programacion_Catalogos_EditarColorSuelaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblDescripcion.ForeColor = Drawing.Color.Black
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtColorSuela As New DataTable

        If ValidarRepetidos() = True Then
            If validaVacio() = True Then
                Dim mensaje

                If MsgBox("¿Está seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                    dtColorSuela = GuardarCambios()
                    If dtColorSuela.Rows(0).Item(0) = "exito" Then
                        mensaje = New ExitoForm
                    Else
                        mensaje = New AdvertenciaForm
                    End If
                    mensaje.mensaje = dtColorSuela.Rows(0).Item(1)
                    mensaje.ShowDialog()
                    Me.Close()
                Else
                End If
            Else
                Dim mensaje As New AdvertenciaForm
                mensaje.mensaje = "Los campos en rojo deben ser completados."
                mensaje.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub



End Class