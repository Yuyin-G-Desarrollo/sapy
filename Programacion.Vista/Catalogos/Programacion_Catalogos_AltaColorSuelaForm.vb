Imports Tools

Public Class Programacion_Catalogos_AltaColorSuelaForm


    Public Sub Programacion_Catalogos_AltaColorSuelaForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdbSI.Checked = True
        txtNombre.Text = String.Empty
        GenerarCodigo()
    End Sub

    Public Sub GenerarCodigo()
        Dim objBU As New Programacion.Negocios.ColoresSuelaBU
        Dim dtContador As DataTable = objBU.ContarFilasColoresSuelas
        Dim dtIdMaximo As DataTable = objBU.VerMaximoIdColorSuela
        Dim contador As Int32 = Convert.ToInt32(dtContador.Rows(0)(0).ToString)
        Dim idMaximo As Int32 = 0
        Dim idNuevo As Int32 = 0
        Dim idNuevoCadena As String = String.Empty

        If contador >= 1 Then
            idMaximo = Convert.ToInt32(dtIdMaximo.Rows(0)(0).ToString)
            If idMaximo < 99 Then
                idNuevo = idMaximo + 1
                If idNuevo >= 1 And idNuevo <= 9 Then
                    idNuevoCadena = "" + idNuevo.ToString
                    txtCodigo.Text = idNuevoCadena
                Else
                    txtCodigo.Text = idNuevo.ToString
                End If
            ElseIf idMaximo >= 99 Then
                Dim dtCodigosDisponibles As DataTable
                dtCodigosDisponibles = objBU.VerCodigosDisponibles
                idNuevoCadena = dtCodigosDisponibles.Rows(0)(0)
                txtCodigo.Text = idNuevoCadena
            End If
        Else
            idNuevoCadena = "1"
            txtCodigo.Text = idNuevoCadena
        End If

    End Sub

    Public Function validaVacio() As Boolean
        If txtNombre.Text = Nothing Then
            lblNombre.ForeColor = Drawing.Color.Red
            Return False
        End If
        Return True
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim dtColorSuela As New DataTable

        If validaVacio() = True Then
            Dim mensaje

            If MsgBox("¿Está seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                dtColorSuela = registrarColorSuela()
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
            mensaje.mensaje = "Los campos marcados en rojo deben ser completados."
            mensaje.ShowDialog()
        End If
    End Sub

    Private Function registrarColorSuela() As DataTable
        Dim objBU As New Programacion.Negocios.ColoresSuelaBU
        Dim EntidadColorSuela As New Entidades.ColorSuela
        Dim dtColorSuela As New DataTable
        EntidadColorSuela.PColorSuelaId = txtCodigo.Text
        EntidadColorSuela.PNombreColor = txtNombre.Text

        If rdbSI.Checked = True Then
            EntidadColorSuela.PActivo = "True"
        ElseIf rdbNO.Checked = True Then
            EntidadColorSuela.PActivo = "False"
        End If
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        dtColorSuela = objBU.registrarSuela(EntidadColorSuela, usuario)
        Return dtColorSuela
    End Function


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



End Class