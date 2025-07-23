Public Class Programacion_Reportes_EvaluacionNaves_BU

    ''' <summary>
    ''' CONECTA CON LA CAPA DE DATOS Y RECUPERA UN DATATABLE CON LA EVALUACION SEMANAL DE LAS NAVES 
    ''' </summary>
    ''' <param name="nave">VARIABLE DEL TIPO ENTERO, CONSULTA LAS NAVES</param>
    ''' <param name="año">VARIABLE DEL TIPO ENTERO, CONSULTA EL AÑO</param>
    ''' <param name="semanaInicio">VARIABLE DEL TIPO ENTERO, 1 = CONSULTA LA SEMANA DE INCIO</param>
    ''' <param name="semanaFin">VARIABLE DEL TIPO ENTERO,  CONSULTA LA SEMANA FINAL,</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN RECUPERADA  </returns>
    ''' <remarks></remarks>
    Public Function obtenerDatosEvaluacionNave(ByVal Nave As String, ByVal Año As Integer, ByVal SemanaInicio As Integer,
                                  ByVal SemanaFin As Integer) As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        obtenerDatosEvaluacionNave = New DataTable
        Try

            obtenerDatosEvaluacionNave = objDA.obtenerDatosEvaluacionNave(Nave, Año, SemanaInicio, SemanaFin)


        Catch ex As Exception
            If ex.Message.Contains("interbloqueo") Then
                obtenerDatosEvaluacionNave(Nave, Año, SemanaInicio, SemanaFin)
            End If
        End Try

        Return obtenerDatosEvaluacionNave

    End Function

    Public Function ActualizarReporte(ByVal Nave As Integer, ByVal Año As Integer, ByVal NumSemana As Integer,
                                  ByVal CapacidadPares As Integer, ByVal DiasProcesoIdeal As Double, ByVal ParesCancelados As Integer,
                                  ByVal CalificacionEntregas As Integer, ByVal UsuarioId As Integer) As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        ActualizarReporte = New DataTable

        ActualizarReporte = objDA.ActualizarReporte(Nave, Año, NumSemana, CapacidadPares, DiasProcesoIdeal, ParesCancelados, CalificacionEntregas, UsuarioId)

        Return ActualizarReporte
    End Function

    'Public Function actualizarReporte(ByVal Nave As Integer, ByVal Año As Integer, ByVal NumSemana As Integer, ByVal CapacidadPares As Integer, ByVal DiasProcesoIdeal As Integer, ByVal ParesCancelados As Integer, ByVal CalificacionEntregas As Integer) As DataTable
    '    Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
    '    Dim tabla As New DataTable
    '    tabla = objDA.ActualizarReporte(Nave, Año, NumSemana, CapacidadPares, DiasProcesoIdeal, ParesCancelados, CalificacionEntregas)
    '    Return tabla
    'End Function

    Public Function ConsultaDatosNaves() As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        Dim tabla As New DataTable
        tabla = objDA.ConsultaDatosNaves()
        Return tabla
    End Function
    Public Function obtenerDatosEvaluacionNaveImpresionPDF(ByVal Nave As Integer, ByVal Año As Integer, ByVal SemanaInicio As Integer,
                                  ByVal SemanaFin As Integer) As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        obtenerDatosEvaluacionNaveImpresionPDF = New DataTable

        obtenerDatosEvaluacionNaveImpresionPDF = objDA.obtenerDatosEvaluacionNaveImpresionPDF(Nave, Año, SemanaInicio, SemanaFin)

        Return obtenerDatosEvaluacionNaveImpresionPDF
    End Function

    Public Function obtenerPromediosEvaluacionNave(ByVal Nave As String, ByVal Año As Integer, ByVal SemanaInicio As Integer,
                                 ByVal SemanaFin As Integer) As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        obtenerPromediosEvaluacionNave = New DataTable

        obtenerPromediosEvaluacionNave = objDA.obtenerPromediosEvaluacionNave(Nave, Año, SemanaInicio, SemanaFin)

        Return obtenerPromediosEvaluacionNave
    End Function

    Public Function consultarSemanasInhabilesCompletas(ByVal Año As Integer) As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        consultarSemanasInhabilesCompletas = New DataTable

        consultarSemanasInhabilesCompletas = objDA.consultarSemanasInhabilesCompletas(Año)

        Return consultarSemanasInhabilesCompletas
    End Function

    Public Function actualizaTodaslasNaves() As DataTable
        Dim objDA As New Datos.Programacion_Reportes_EvaluacionNaves_DA
        actualizaTodaslasNaves = New DataTable

        actualizaTodaslasNaves = objDA.actualizaTodaslasNaves()

        Return actualizaTodaslasNaves
    End Function

End Class
