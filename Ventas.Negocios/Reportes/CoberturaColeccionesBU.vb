
Public Class CoberturaColeccionesBU

    Public Function ReporteCoberturaColecciones(ByVal FechaInicio As String, ByVal FechaFin As String, ByVal Agente As String, ByVal Marca As String, ByVal Cliente As String, ByVal MarcasColeccionSay As String, ByVal IdUsuario As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CoberturaColeccionesDA
        Dim tabla As New DataTable
        tabla = objDA.ReporteCoberturaColecciones(FechaInicio, FechaFin, Agente, Marca, Cliente, MarcasColeccionSay, IdUsuario)
        Return tabla
    End Function

    Public Function CoberturaColeccionesObtenerEncabezadosTabla(ByVal Spid As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CoberturaColeccionesDA
        Dim tabla As New DataTable
        tabla = objDA.CoberturaColeccionesObtenerEncabezadosTabla(Spid)
        CoberturaColeccionesLimpiarEncabezadosTabla(Spid)
        Return tabla
    End Function

    Public Sub CoberturaColeccionesLimpiarEncabezadosTabla(ByVal Spid As Integer)
        Dim objDA As New Ventas.Datos.CoberturaColeccionesDA        
        objDA.CoberturaColeccionesLimpiarEncabezadosTabla(Spid)
    End Sub

End Class
