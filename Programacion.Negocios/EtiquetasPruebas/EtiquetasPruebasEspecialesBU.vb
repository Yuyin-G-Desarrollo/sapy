Imports Programacion.Datos
Public Class EtiquetasPruebasEspecialesBU

    Public Function consultaClientesEtiquetasDiseño(ByVal accion As Integer) As DataTable
        Dim obj = New EtiquetasPruebasEspecialesDA
        Return obj.consultaClientesEtiquetasDiseño(accion)
    End Function

    Public Function consultaEtiquetasClientesDiseño(ByVal accion As Integer, ByVal idCliente As Integer) As DataTable
        Dim obj = New EtiquetasPruebasEspecialesDA
        Return obj.consultaEtiquetasClientesDiseño(accion, idCliente)
    End Function

    Public Function ListaImpresoras() As DataTable
        Dim objDA As New EtiquetasPruebasEspecialesDA
        Return objDA.ListaImpresoras()
    End Function


    Public Function ConsultaImpresoraAsignada(ByVal Equipo As String) As DataTable
        Dim objDatos As New Datos.EtiquetasDA
        Return objDatos.ConsultaImpresoraAsignada(Equipo)
    End Function
    Public Function consultaParametrosPorEtiquetaDiseño(ByVal idEtiqueta As Integer) As DataTable
        Dim obj As New EtiquetasPruebasEspecialesDA
        Return obj.consultaParametrosPorEtiquetaDiseño(idEtiqueta)
    End Function

    Public Function consultaDatosParametrosEtiquetasPrueba(ByVal anio As Integer, ByVal idNave As Integer, ByVal lote As Integer, ByVal usuario As String, ByVal idEtiqueta As Integer) As DataTable
        Dim obj As New EtiquetasPruebasEspecialesDA
        Return obj.consultaDatosParametrosEtiquetasPrueba(anio, idNave, lote, usuario, idEtiqueta)
    End Function

    Public Function ReemplazaParametroGuion(ByVal Zpl As String) As DataTable
        Dim obj As New EtiquetasPruebasEspecialesDA
        Return obj.ReemplazaParametroGuion(Zpl)
    End Function

    Public Function ConsultaGRFPruebaEtiquetasEspecial(ByVal anio As Integer, ByVal idNaveSay As Integer, ByVal lote As Integer) As DataTable
        Dim obj As New EtiquetasPruebasEspecialesDA
        Return obj.ConsultaGRFPruebaEtiquetasEspecial(anio, idNaveSay, lote)
    End Function

End Class
