Imports System.Data.SqlClient

Public Class Administracion_ConsultaInventarioDA

    Public Function PoblarRazonSocial() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim cadena As String = "SELECT empr_empresaid EmpresaID, empr_nombre Empresa FROM Framework.Empresas WHERE empr_activo=1 and empr_empresaid IN (35,36)  ORDER BY empr_nombre"
        Return objPersistencia.EjecutaConsulta(cadena)
    End Function

    Public Function ObtenerInventarioInicial(ByVal RazonSocial As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@RazonSocialID", RazonSocial)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ConsultaInventario_FacturasExternas]", listaParametros)

    End Function


    Public Function ObtieneDetalleInventario(ByVal ProductoEstiloID As Integer, ByVal FechaInicio As Date, ByVal FechaFin As Date) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProductoEstiloID", ProductoEstiloID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaInicio", FechaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FechaFin", FechaFin)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ConsultaInventario_FacturasExternasDetalles]", listaParametros)
    End Function

End Class
