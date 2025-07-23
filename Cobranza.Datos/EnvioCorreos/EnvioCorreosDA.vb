Imports System.Collections.Generic
Imports System.Data.SqlClient


Public Class EnvioCorreosDA

    Public Function ConsultaEnvioCorreosFacturas(ByVal StatusCorreo As Integer, ByVal TipoArchivo As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date, ByVal ClienteSICYID As String, ByVal AgenteID As String, ByVal RazonSocial As String, ByVal Usuario As String) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientosSICY
        Dim listaparametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@StatusCorreo"
            parametro.Value = StatusCorreo
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@TipoArchivo"
            parametro.Value = TipoArchivo
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaInicio"
            parametro.Value = FechaInicio
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@FechaFin"
            parametro.Value = FechaFin
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@ClienteSICY"
            parametro.Value = ClienteSICYID
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@AgenteID"
            parametro.Value = AgenteID
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@RazonSocial"
            parametro.Value = RazonSocial
            listaparametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Usuario"
            parametro.Value = Usuario
            listaparametros.Add(parametro)


            Return operaciones.EjecutarConsultaSP("[Almacen].[SP_EnvioCorreo_ConsultaCorreosFacturacionv2]", listaparametros)
        Catch ex As Exception
            Throw ex
        End Try


    End Function


End Class
