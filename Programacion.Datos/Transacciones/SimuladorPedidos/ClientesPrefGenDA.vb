Imports System.Data.SqlClient


Public Class ClientesPrefGenDA


    Public Function verColeccionesPreferentesSinFechaEntregaEspecial() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Return operacion.EjecutarConsultaSP("Ventas.SP_clientePreferenteSinFechaEspecial", listaParametros)
    End Function


    Public Function verColeccionesPreferentesConFechaEntregaEspecial() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Return operacion.EjecutarConsultaSP("Ventas.SP_clientePreferenteConFechaEspecial", listaParametros)
    End Function

    Public Function verColeccionesGeneralesSinFechaEntregaEspecial() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Return operacion.EjecutarConsultaSP("Ventas.SP_clienteGeneralSinFechaEspecial", listaParametros)
    End Function


    Public Function verColeccionesGeneralesConFechaEntregaEspecial() As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)


        Return operacion.EjecutarConsultaSP("Ventas.SP_clienteGeneralConFechaEspecial", listaParametros)
    End Function

    Public Function quitarColeccionMarcaFechaEntregaEspecialPreferenteGeneral(coleccionMarcaId As Int16, idUsuario As Int16, generalPreferente As String)
        'Ventas.SP_Quitar_ColeccionMarca_FechaEntregaEspecial_Preferente_General
        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@coleccionMarcaId"
        parametro.Value = coleccionMarcaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@generalPreferente"
        parametro.Value = generalPreferente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_Quitar_ColeccionMarca_FechaEntregaEspecial_Preferente_General", listaParametros)
    End Function


    Public Function insertarActualizarColeccionMarcaFechaentregaEspecial(coleccionMarcaId As Int16, fechaEntregaGeneralPreferente As String, idUsuario As Int16, generalPreferente As String)

        Dim consulta As String = String.Empty
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@coleccionMarcaId"
        parametro.Value = coleccionMarcaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@fechaEntregaGeneralPreferente"
        parametro.Value = fechaEntregaGeneralPreferente
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@generalPreferente"
        parametro.Value = generalPreferente
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Ventas.SP_Insertar_Actualizar_ColeccionMarca_FechaEntregaEspecial_Preferente_General", listaParametros)
    End Function

    Public Function ObtenerPropuestaFechaEntregaGeneral(colaboradorId As Integer)
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_GenerarFechaGeneralDeEntregaPropuesta]", listaParametros)
    End Function


    Public Function ObtenerPorcentajePromedioActual(colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@colaboradorid"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_ConsultaPromedioMaximoOcupacionFechaEntrega]", listaParametros)

    End Function


    Public Function GuardarPorcentajePromedio(porcentajePromedioSemana As Double, usuarioId As Integer, colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)

        parametro.ParameterName = "@porcentajePromedioSemana"
        parametro.Value = porcentajePromedioSemana
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorid"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_GuardarPromedioMaximoOcupacionFechaEntrega]", listaParametros)

    End Function

End Class
