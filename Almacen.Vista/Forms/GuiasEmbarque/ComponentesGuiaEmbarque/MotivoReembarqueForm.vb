Imports Tools
Imports Tools.Utilerias

Public Class MotivoReembarqueForm
    Public motivo As String
    Dim obj As New Negocios.AdministradorDocumentosBU


    Private Sub llenarComboMotivos()
        Dim resultado = obj.ConsultarMotivosRembarque()
        Try

            With cbmotivo
                .DataSource = resultado
                .DisplayMember = "Descripcion"
                .ValueMember = "ID"
            End With
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE TRASPORTE por favor comunicate con TI")
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        motivo = cbmotivo.SelectedValue
        If motivo = "" Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Ingresa el motivo por el cual sera el reembarque")
            Me.DialogResult = DialogResult.None
        Else
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()

    End Sub

    Private Sub MotivoReembarqueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboMotivos()
    End Sub
End Class