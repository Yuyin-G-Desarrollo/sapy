Imports System.Data.SqlClient

Public Class FiltrosReportesDA

    Public Function ConsultarFiltros(tipoFiltro As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter With {
            .ParameterName = "@TipoFiltro",
            .Value = tipoFiltro
        }
        listaParametros.Add(parametro)

        parametro = New SqlParameter With {
            .ParameterName = "@UsuarioId",
            .Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        }
        listaParametros.Add(parametro)

        Dim dtResultadoConsulta As DataTable = objPersistencia.EjecutarConsultaSP("[Framework].[SP_Proyeccion_ConsultasFiltros]", listaParametros)

        Return dtResultadoConsulta
    End Function

End Class
