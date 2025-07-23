Public Class HistorialSalarioBUvb
    Public Sub insertarSalarioDiario(ByVal IdColaborador As Int32, ByVal SalarioDiario As Double)
        Dim objDA As New Datos.HistorialSalariosDA
        objDA.InsertarSalarioDiario(IdColaborador, SalarioDiario)
    End Sub


    Public Function ListaHistorialSueldos(ByVal IDColaborador As Int32) As List(Of Entidades.HistorialSalarios)
        Dim ObjDa As New Datos.HistorialSalariosDA
        Dim tabla As New DataTable

        ListaHistorialSueldos = New List(Of Entidades.HistorialSalarios)
        tabla = ObjDa.ListaHistorialSueldos(IDColaborador)

        For Each fila As DataRow In tabla.Rows
            Dim Historial As New Entidades.HistorialSalarios
            Try
                Historial.PFecha = CDate(fila("hist_fechacreacion"))
            Catch ex As Exception

            End Try

            Try
                Historial.PSueldo = CDbl(fila("hist_sueldo"))
            Catch ex As Exception

            End Try


            ListaHistorialSueldos.Add(Historial)
        Next
        Return ListaHistorialSueldos

    End Function
End Class
