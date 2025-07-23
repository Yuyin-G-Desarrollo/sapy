Imports Tools
Imports Tools.Utilerias

Public Class AsignarNumeroASNForm
    Dim OBjinstancia As New Negocios.OrdenTrabajoBU
    Public OrdenesTrabjo As String

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RegistrarNumeroASN(txtnumeroASN.Text)
    End Sub

    Private Sub RegistrarNumeroASN(numeroASN As String)

        Try
            If OrdenesTrabjo = "" Then
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error vuelve a selecionar las OT´s")
            Else

                Dim result = OBjinstancia.AsignarNumeroASN(OrdenesTrabjo, numeroASN)
                If result.Rows(0).Item("ErrorNumber") = 0 Then
                    Utilerias.show_message(TipoMensaje.Exito, result.Rows(0).Item("Mensaje"))
                    Me.Close()
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, result.Rows(0).Item("Mensaje"))
                End If

            End If

        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class