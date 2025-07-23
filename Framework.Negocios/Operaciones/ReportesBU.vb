Public Class ReportesBU
    Public Shared Function ArchivoEnUso(ByVal Ruta As String) As Boolean
        Dim nFileNum As Integer
        nFileNum = FreeFile()

        Try
            FileOpen(nFileNum, Ruta, OpenMode.Binary, OpenAccess.Write)
            FileClose(nFileNum)
            Return False
            Return False
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Sub AltaReporte(ByVal Reporte As Entidades.Reportes)
        Dim OBJDA As New Datos.ReportesDA
        OBJDA.AltaReportes(Reporte)
    End Sub

    Public Sub EditarReporte(ByVal Reporte As Entidades.Reportes)
        Dim OBJDA As New Datos.ReportesDA
        OBJDA.ActualizarReporte(Reporte)
    End Sub

    Public Function ListaReportes(ByVal Esquema As String, ByVal Nombre As String, ByVal clave As String, ByVal activo As Boolean) As DataTable
        Dim OBJDA As New Datos.ReportesDA
        Return OBJDA.ListaReportes(Esquema, Nombre, clave, activo)
    End Function

    Public Shared Sub Mostrar(ex As Exception)
        'MessageBox.Show(ex.Message)
    End Sub

    Public Function LeerReporte(ByVal IDReporte As Int32) As Entidades.Reportes
        Dim OBJBU As New Datos.ReportesDA
        Return OBJBU.LeerReporte(IDReporte)
    End Function

    Public Function LeerReporteporClave(ByVal Clave As String) As Entidades.Reportes
        Dim OBJBU As New Datos.ReportesDA
        Return OBJBU.LeerReporteClave(Clave)
    End Function


End Class
