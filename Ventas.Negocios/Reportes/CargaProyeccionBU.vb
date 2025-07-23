Public Class CargaProyeccionBU

    Public Function obtenerAñosGuardados() As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerAñosGuardados()
        Return tabla
    End Function

    Public Function obtenerSemanasPorAño(ByVal Año As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.obtenerSemanasPorAño(Año)
        Return tabla
    End Function

    Public Function consultaDatosProyeccion(ByVal Año As Integer, ByVal SemanaDe As Integer, ByVal SemanaA As Integer, ByVal AgenteId As Integer, ByVal MarcaIdSAY As Integer, ByVal NombreAgente As String, ByVal NombreMarca As String) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.consultaDatosProyeccion(Año, SemanaDe, SemanaA, AgenteId, MarcaIdSAY, NombreAgente, NombreMarca)
        Return tabla
    End Function

    Public Function guardarEditarDatosProyeccion(ByVal DatosGuardarEditar As Entidades.DatosCargarProyeccion) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.guardarEditarDatosProyeccion(DatosGuardarEditar)
        Return tabla
    End Function

    Public Function consultarMarcasPorAgente(ByVal IdAgente As Integer) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.consultarMarcasPorAgente(IdAgente)
        Return tabla
    End Function

    'INICIA CODIGO DE REPORTE Ventas_Reportes_CargaProyeccionForm_Marca_Familia

    Public Function consultaDatosProyeccionMarcaFamilia(ByVal Año As Integer, ByVal SemanaDe As Integer, ByVal SemanaA As Integer, ByVal AgenteId As String, ByVal MarcaIdSAY As String, ByVal FamiliaId As String) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.consultaDatosProyeccionMarcaFamilia(Año, SemanaDe, SemanaA, AgenteId, MarcaIdSAY, FamiliaId)
        Return tabla
    End Function

    Public Function guardarEditarDatosProyeccionFamiliaAgente(ByVal DatosGuardarEditar As Entidades.DatosCargarProyeccion) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.guardarEditarDatosProyeccionFamiliaAgente(DatosGuardarEditar)
        Return tabla
    End Function

    Public Function guardarEditarDatosProyeccionFamiliaAgenteXml(ByVal pXmlCeldas As String) As DataTable
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        Dim tabla As New DataTable
        tabla = objDA.guardarEditarDatosProyeccionFamiliaAgenteXml(pXmlCeldas)
        Return tabla
    End Function

    Public Sub EliminarProyeccionVenta(ByVal Año As Integer, ByVal SemanaInicio As Integer, ByVal SemanaFin As Integer)
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        objDA.EliminarProyeccionVenta(Año, SemanaInicio, SemanaFin)
    End Sub

    Public Sub ReplicarProyeccionVenta()
        Dim objDA As New Ventas.Datos.CargaProyeccionDA
        objDA.ReplicarProyeccionVenta()
    End Sub

    Public Function ConsultaProyeccionAnual(ByVal anio As Integer)
        Dim obj As New Ventas.Datos.CargaProyeccionDA
        Return obj.ConsultaProyeccionAnual(anio)
    End Function


End Class
