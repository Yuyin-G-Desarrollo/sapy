Imports System.Data.SqlClient
Public Class FiltroParametrosCobranzaDA

    Public Function ListadoParametroProyeccionEntregas(tipo_busqueda As Integer, ColaboradorID As Integer, TipoPerfil As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "TipoConsulta"
        parametro.Value = tipo_busqueda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TipoPerfil"
        parametro.Value = TipoPerfil
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_Proyeccion_ConsultasFiltros_18122018", listaParametros)

    End Function
    Public Function listadoParametrosNotasCredito(ByVal clienteId As String, ByVal tipoNC As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        parametro.ParameterName = "@ClienteId"
        parametro.Value = clienteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipoNC"
        parametro.Value = tipoNC
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Cobranza].[SP_NotasCredito_ConsultaFiltroRFC]", listaParametros)
    End Function
End Class
