Public Class CargaSuelaGlobalBU
    Public Function CargarSuelaGlobal(ByVal Opcion As Integer) As DataTable
        Dim objSuelaGlobal As New Programacion.Datos.CargaSuelaGlobalDA
        Dim tbSuelaGlobal As DataTable
        Try
            tbSuelaGlobal = objSuelaGlobal.CargarSuelaGlobal(Opcion)
        Catch ex As Exception
            tbSuelaGlobal = Nothing
        End Try

        Return tbSuelaGlobal
    End Function

    Public Function RegistraSuelaGlobal(ByVal suelaDescripcion As String, ByVal suelaActivo As Boolean) As Boolean
        Dim objSuelaGlobal As New Programacion.Datos.CargaSuelaGlobalDA
        Dim respuesta As Boolean
        Try
            respuesta = objSuelaGlobal.RegistrarSuelaGlobal(suelaDescripcion, suelaActivo)
        Catch ex As Exception
            respuesta = False
        End Try
        Return respuesta
    End Function
    Public Function ModificarSuelaGlobal(ByVal suelaDescripcion As String, ByVal suelaActivo As Boolean, ByVal idSuela As Integer) As Boolean
        Dim objSuelaGlobal As New Programacion.Datos.CargaSuelaGlobalDA
        Dim respuesta As Boolean
        Try
            respuesta = objSuelaGlobal.ModificarSuelaGlobal(suelaDescripcion, suelaActivo, idSuela)
        Catch ex As Exception
            respuesta = False
        End Try
        Return respuesta
    End Function
End Class
