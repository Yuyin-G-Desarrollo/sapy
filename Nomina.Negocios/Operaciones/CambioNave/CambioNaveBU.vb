Public Class CambioNaveBU
    Public Function obtenerListaColaboradores(ByVal Filtros As Entidades.FiltrosFichaColaborador) As DataTable
        Dim objDatos As New Datos.CambioNaveDA
        Return objDatos.obtenerListaColaboradoresFiltros(Filtros)
    End Function

    Public Function validarColaborador(ByVal colaborador As Integer, ByVal asegurado As Integer) As DataTable
        Dim objDatos As New Datos.CambioNaveDA
        Return objDatos.validarColaborador(colaborador, asegurado)
    End Function

    Public Function copiarColaboradorSinSeguro(ByVal colaboradorId As Integer, ByVal patronOrigenId As Integer, ByVal patronDestinoId As Integer,
                                      ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer) As String
        Dim objDatos As New Datos.CambioNaveDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.copiarColaboradorSinSeguro(colaboradorId, patronOrigenId, patronDestinoId, naveOrigenId, naveDestinoId)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function

    Public Function copiarColaboradorConSeguro(ByVal colaboradorId As Integer, ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer) As String
        Dim objDatos As New Datos.CambioNaveDA
        Dim dtResultado As New DataTable
        Dim resultado As String = String.Empty

        dtResultado = objDatos.copiarColaboradorConSeguro(colaboradorId, naveOrigenId, naveDestinoId)
        If Not dtResultado Is Nothing Then
            resultado = dtResultado.Rows(0)("mensaje").ToString
        End If

        Return resultado
    End Function



    Public Function obtenerFechaCorteNave(ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer, ByVal colaboradorId As Integer, ByVal patronDestinoId As Integer) As DataTable
        Dim objDatos As New Datos.CambioNaveDA
        Return objDatos.obtenerFechaCorteNave(naveOrigenId, naveDestinoId, colaboradorId, patronDestinoId)
    End Function


End Class
