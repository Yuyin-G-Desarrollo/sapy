Imports Almacen.Negocios
Imports Tools
Imports Tools.Utilerias

Public Class AsignarNumeroGuiaEmbarqueForm
    Public Nombrepaqueteria As String
    Public Numeroembarque As String
    Dim objInstancia As New AdministradorDocumentosBU
    Private Sub AsignarNumeroGuiaEmbarqueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        paqueteria.Text = Nombrepaqueteria
        embarqueid.Text = Numeroembarque

        If Replace(paqueteria.Text, " ", "") <> "TRANSPORTECASTORES" Then
            txtcartaporder.Enabled = False
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pasas = validarDatos()
        If pasas Then
            Try
                Dim costo = txtcostoEnvio.Text
                If costo = "" Then
                    costo = 0
                End If

                Dim result = objInstancia.GuardarNumerosRastreos(embarqueid.Text, txtnumero.Text, txtcartaporder.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, costo)
                If result.Error = 0 Then
                    Utilerias.show_message(TipoMensaje.Exito, "Se insertaron los numeros de rastreo")
                    Me.Close()
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, result.Mensaje)
                End If
            Catch ex As Exception
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error comunicate con TI")
            End Try

        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Llena todo los datos para poder guardar")
        End If

    End Sub
    Private Function validarDatos() As Boolean
        Dim pasas As Boolean = True
        If Replace(paqueteria.Text, " ", "") = "TRANSPORTECASTORES" Then
            If txtnumero.Text = "" Then
                errnumeroGuia.SetError(txtnumero, "Ingresa un numero de guía")
                pasas = False
            Else
                errnumeroGuia.Clear()
            End If
            If txtcartaporder.Text = "" Then
                errcartapoder.SetError(txtcartaporder, "Ingresa una carta poder")
                pasas = False
            Else
                errnumeroGuia.Clear()
            End If
        Else
            If txtnumero.Text = "" Then
                errnumeroGuia.SetError(txtnumero, "Ingresa un numero de guía")
                pasas = False
            Else
                errnumeroGuia.Clear()
            End If
        End If
        Return pasas
    End Function


    Private Sub txtcostoEnvio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcostoEnvio.KeyPress
        If Not IsNumeric(e.KeyChar) _
                    AndAlso Not Char.IsControl(e.KeyChar) _
                    AndAlso Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class