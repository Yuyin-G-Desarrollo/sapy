Imports System.Data.SqlClient
Imports Entidades
Public Class ConfiguracionPorcentajesMaquilasDA
    Public Function ObtenerConfiguracionMaquilas() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutaConsulta("[Proveedor].[SP_Configuracion_PorcentajesMaquila]")
    End Function

    Public Function EditaPorcentajesMaquila(ByVal datos As Entidades.ConfiguracionPorcentajesMaquilas) As DataTable
        Dim objEditarPorcentaje As New Persistencia.OperacionesProcedimientos
        Dim parametro = New SqlClient.SqlParameter
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idnave"
        parametro.Value = datos.cpmIdnave
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@isr"
        parametro.Value = datos.cpmIsr
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@dd_herramental"
        parametro.Value = datos.cpmHerramientas
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@financiamiento"
        parametro.Value = datos.cpmFinanciamiento
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@fabrica"
        parametro.Value = datos.cpmFabrica
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@administracion"
        parametro.Value = datos.cpmAdministracion
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@comercial"
        parametro.Value = datos.cpmComercial
        ListaParametros.Add(parametro)

        parametro = New SqlClient.SqlParameter
        parametro.ParameterName = "@idUsuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(parametro)

        Return objEditarPorcentaje.EjecutarConsultaSP("[Proveedor].[SP_Editar_ConfiguracionPorcentajesMaquila]", ListaParametros)
    End Function
End Class
