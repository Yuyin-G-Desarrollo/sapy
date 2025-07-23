Imports System.Threading

Public Class Consultas_Async
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            For index As Integer = 0 To CInt(txtNumConexiones.Text) Step 1
                Dim obj = New Thread(AddressOf Consulta)
                obj.Start()
            Next
        Catch ex As Exception
            MsgBox("Error de conversión")
        End Try

    End Sub

    Public Function Consulta()
        Dim negocios As New Negocios.DevolucionClientesBU
        'negocios.consulta()
    End Function
    '8989
End Class