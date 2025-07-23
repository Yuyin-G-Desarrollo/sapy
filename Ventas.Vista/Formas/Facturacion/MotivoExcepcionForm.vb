Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class MotivoExcepcionForm

#Region "Variables Globales"

    Public Datos As New DataTable
    Public listaDeseleccion As List(Of String)
    Public listaSeleccion As List(Of String)
    Public listaNuevos As List(Of String)
    Public OK As Boolean = False

#End Region

    Private Sub MotivoExcepcionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = (Me.Owner.Height - Me.Height) / 2
        Me.Left = (Me.Owner.Width - Me.Width) / 2
    End Sub

#Region "Panel Pie"

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim solicita = txtSolicita.Text
        Dim motivo = txtMotivo.Text

        If solicita <> "" AndAlso motivo <> "" Then
            For Each row As DataRow In Datos.Rows
                If row.Item(3) <> "DESHABILITAR EXCEPCIÓN" Then
                    row.Item(2) = motivo
                    row.Item(4) = solicita
                End If
            Next

            Dim mensajeConfirmacion = New MensajeConfirmarExcepcionForm With {
                .listaSeleccion = listaSeleccion,
                .listaDeseleccion = listaDeseleccion,
                .listaNuevos = listaNuevos,
                .Datos = Datos
            }
            mensajeConfirmacion.ShowDialog()
            OK = mensajeConfirmacion.OK
            Close()
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "Llene los campos requeridos.")
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

#End Region

End Class