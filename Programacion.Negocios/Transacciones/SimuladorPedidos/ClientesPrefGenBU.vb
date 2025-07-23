Public Class ClientesPrefGenBU
#Region "consultas de Grids Preferentes"

    Public Function verColeccionesPreferentesSinFechaEntregaEspecial() As DataTable
        Dim objColeccionesPreferentesSinFechaEntregaEspecial As New Datos.ClientesPrefGenDA
        Return objColeccionesPreferentesSinFechaEntregaEspecial.verColeccionesPreferentesSinFechaEntregaEspecial
    End Function

    Public Function verColeccionesPreferentesConFechaEntregaEspecial() As DataTable
        Dim objColeccionesPreferentesConFechaEntregaEspecial As New Datos.ClientesPrefGenDA
        Return objColeccionesPreferentesConFechaEntregaEspecial.verColeccionesPreferentesConFechaEntregaEspecial
    End Function
#End Region

#Region "Consultas de grids Generales"

    Public Function verColeccionesGeneralesSinFechaEntregaEspecial() As DataTable
        Dim objColeccionesGeneralesSinFechaEntregaEspecial As New Datos.ClientesPrefGenDA
        Return objColeccionesGeneralesSinFechaEntregaEspecial.verColeccionesGeneralesSinFechaEntregaEspecial
    End Function

    Public Function verColeccionesGeneralesConFechaEntregaEspecial() As DataTable
        Dim objColeccionesGeneralesConFechaEntregaEspecial As New Datos.ClientesPrefGenDA

        Return objColeccionesGeneralesConFechaEntregaEspecial.verColeccionesGeneralesConFechaEntregaEspecial
    End Function



#End Region
#Region "insertar Actualizar"

    Public Sub quitarColeccionMarcaFechaEntregaEspecialPreferenteGeneral(coleccionMarcaId As Int16, idUsuario As Int16, generalPreferente As String)
        Dim objQuitarColeccionMarcaFechaEntregaEspecial As New Datos.ClientesPrefGenDA

        objQuitarColeccionMarcaFechaEntregaEspecial.quitarColeccionMarcaFechaEntregaEspecialPreferenteGeneral(coleccionMarcaId, idUsuario, generalPreferente)
    End Sub


    Public Sub insertarActualizarColeccionMarcaFechaentregaEspecial(coleccionMarcaId As Int16, fechaEntregaGeneralPreferente As String, idUsuario As Int16, generalPreferente As String)
        Dim objinsertaActualizaColeccionMarcaFechaEntregaEspecial As New Datos.ClientesPrefGenDA

        objinsertaActualizaColeccionMarcaFechaEntregaEspecial.insertarActualizarColeccionMarcaFechaentregaEspecial(coleccionMarcaId, fechaEntregaGeneralPreferente, idUsuario, generalPreferente)
    End Sub
#End Region

#Region "Consultas de generación de fecha generar"

    Public Function ObtenerPropuestaFechaEntregaGeneral(colaboradorId As Integer) As DataTable

        Dim objDA As New Datos.ClientesPrefGenDA

        Return objDA.ObtenerPropuestaFechaEntregaGeneral(colaboradorId)

    End Function


    Public Function ObtenerPorcentajePromedioActual(colaboradorId As Integer) As DataTable

        Dim objDA As New Datos.ClientesPrefGenDA

        Return objDA.ObtenerPorcentajePromedioActual(colaboradorId)

    End Function


    Public Function GuardarPorcentajePromedio(porcentajePromedioSemana As Double, usuarioId As Integer, colaboradorId As Integer) As DataTable

        Dim objDA As New Datos.ClientesPrefGenDA

        Return objDA.GuardarPorcentajePromedio(porcentajePromedioSemana, usuarioId, colaboradorId)

    End Function

#End Region

End Class
