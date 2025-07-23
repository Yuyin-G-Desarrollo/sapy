Public Class PlanContingenciaBU
    ''''funcion para recuperar las sentencias a insertar
    Public Function generaSentencias(ByVal fechaInicio As DateTime, ByVal fechaFin As DateTime) As DataTable
        Dim objDa As New Datos.PlanContingenciaDA
        Dim dtSentencias As New DataTable

        dtSentencias = objDa.generaSentencias(fechaInicio, fechaFin)

        Return dtSentencias
    End Function

    ''''funcion para consultar la feacha d ela ultima actualizacion 
    Public Function consultaUltimaActualizacion() As DataTable
        Dim objDa As New Datos.PlanContingenciaDA
        Dim dtFecha As New DataTable

        dtFecha = objDa.consultaUltimaActualizacion()

        Return dtFecha
    End Function

    ''consulta de las sentencias temporales
    Public Function consultaSentenciasTemporales() As DataTable
        Dim objDa As New Datos.PlanContingenciaDA
        Dim dtTemporal As New DataTable

        dtTemporal = objDa.consultaSentenciasTemporales()

        Return dtTemporal
    End Function

    ''consulta nombre tabla
    Public Function consultaNombreTabla(ByVal idTabla As Int32) As DataTable
        Dim objDa As New Datos.PlanContingenciaDA
        Dim dtTabla As New DataTable

        dtTabla = objDa.consultaNombreTabla(idTabla)

        Return dtTabla
    End Function

    ''consulta del nombre para la sincronizacion
    Public Function consultaNombreSincronizacion() As DataTable
        Dim objDa As New Datos.PlanContingenciaDA
        Dim dtNombre As New DataTable

        dtNombre = objDa.consultaNombreSincronizacion()

        Return dtNombre
    End Function

    ''Genera el encabezado de la bitacora
    Public Sub insertaBitacoraSentenciasPaso1(ByVal sincronizacion_De As String, ByVal Sincronizacion_A As String,
                                                   ByVal UsuarioGeneraID As Int32, ByVal fechaInicio As DateTime,
                                                   ByVal fechaFin As DateTime)
        Dim objDa As New Datos.PlanContingenciaDA

        objDa.insertaBitacoraSentenciasPaso1(sincronizacion_De, Sincronizacion_A, UsuarioGeneraID, fechaInicio, fechaFin)
    End Sub

    'inserta las sentencias 
    Public Sub insertaSentenciasPaso2(ByVal idUsuario As Int32, ByVal sentencia As String)
        Dim objDa As New Datos.PlanContingenciaDA

        objDa.insertaSentenciasPaso2(idUsuario, sentencia)
    End Sub

    ''consulta para ejecutar las sentencias, paso 3
    Public Sub ejecutaSentenciasPaso3()
        Dim objDa As New Datos.PlanContingenciaDA

        objDa.ejecutaSentenciasPaso3()
    End Sub

    ''consulta del resumen de las sentencias insertadas
    Public Function consultaResumenSentenciasInsertadas() As DataTable
        Dim objDa As New Datos.PlanContingenciaDA
        Dim dtResumen As New DataTable

        dtResumen = objDa.consultaResumenSentenciasInsertadas()

        Return dtResumen
    End Function
End Class
