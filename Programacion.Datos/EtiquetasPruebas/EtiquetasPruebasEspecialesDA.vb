Imports System.Data.SqlClient
Public Class EtiquetasPruebasEspecialesDA
    Public Function consultaClientesEtiquetasDiseño(ByVal accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Try
            listaParametros.Add(New SqlParameter With {
                    .ParameterName = "@accion",
                    .Value = accion})
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaClientesEtiquasDiseño]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultaEtiquetasClientesDiseño(ByVal accion As Integer, ByVal idCliente As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Try
            listaParametros.Add(New SqlParameter With {
                    .ParameterName = "@accion",
                    .Value = accion})

            listaParametros.Add(New SqlParameter With {
                    .ParameterName = "idCliente",
                    .Value = idCliente})
            Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ConsultaClientesEtiquasDiseño]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ListaImpresoras() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultaImpresoras]", listaParametros)
    End Function

    Public Function ConsultaImpresoraAsignada(ByVal Equipo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@Equipo",
                .Value = Equipo
                 })

            Return objPersistencia.EjecutarConsultaSP("Programacion.SP_Etiquetas_ConsultaImpresoraAsignada", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultaParametrosPorEtiquetaDiseño(ByVal idEtiqueta As Integer) As DataTable
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@idEtiqueta",
                .Value = idEtiqueta})

            Return obj.EjecutarConsultaSP("[Programacion].[SP_ConsultaParametrosPorEtiqueta_Diseño]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultaDatosParametrosEtiquetasPrueba(ByVal anio As Integer, ByVal idNave As Integer, ByVal lote As Integer, ByVal usuario As String, ByVal idEtiqueta As Integer) As DataTable
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@anio",
                .Value = anio})

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@idNaveSAY",
                .Value = idNave})

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@lote",
                .Value = lote})

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@usuario",
                .Value = usuario})

            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@idEtiqueta",
                .Value = idEtiqueta})

            Return obj.EjecutarConsultaSP("[Programacion].[SP_ConsultaDatos-ParametrosEtiquetasPrueba]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReemplazaParametroGuion(ByVal Zpl As String) As DataTable
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Try
            listaParametros.Add(New SqlParameter With {
                .ParameterName = "@Zpl",
                .Value = Zpl})

            Return obj.EjecutarConsultaSP("[Programacion].[SP_ReemplazaParametrosConGuionBajo]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaGRFPruebaEtiquetasEspecial(ByVal anio As Integer, ByVal idNaveSay As Integer, ByVal lote As Integer) As DataTable
        Dim obj = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Try
            listaParametros.Add(New SqlParameter With {
                                .ParameterName = "@anio",
                                .Value = anio
                                 })

            listaParametros.Add(New SqlParameter With {
                                .ParameterName = "@idNaveSay",
                                .Value = idNaveSay
                                 })

            listaParametros.Add(New SqlParameter With {
                                .ParameterName = "@lote",
                                .Value = lote
                                 })

            Return obj.EjecutarConsultaSP("[Programacion].[SP_ConsultaGRFPruebaEtiquetasEspecial]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
