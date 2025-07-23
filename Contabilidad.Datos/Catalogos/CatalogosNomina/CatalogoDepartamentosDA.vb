Imports System.Data.SqlClient

Public Class CatalogoDepartamentosDA
    Public Function Consulta_Departamento_Por_Patron(ByVal patron As Integer, estatus As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try


            parametro = New SqlParameter
            parametro.ParameterName = "@estatus"
            parametro.Value = estatus
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@patron"
            parametro.Value = patron
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Consulta_Departamentos_Por_Patron]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function InsertarDepartamento_PorPatron(ByVal departamento As Entidades.DepartamentosByPatron) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@patron"
            parametro.Value = departamento.ID_Patron
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@nombre"
            parametro.Value = departamento.NombreDepartamento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = departamento.Usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = departamento.Fecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@c_sueldo"
            parametro.Value = departamento.ClaveSueldo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@c_PremioP"
            parametro.Value = departamento.ClavePremioPuntualidad
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@c_PremioA"
            parametro.Value = departamento.ClavePremioAsistencia
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@clave_V"
            parametro.Value = departamento.ClaveVacaciones
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@c_PrimaV"
            parametro.Value = departamento.ClavePrimaVacacional
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@c_Aguinaldo"
            parametro.Value = departamento.ClaveAguinaldo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Alta_Departamento_Por_Patron]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function Eliminar_ActivarDepartamento_PorPatron(ByVal accion As Integer, ByVal departamento As Entidades.DepartamentosByPatron) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@departamento"
            parametro.Value = departamento.ID_Departamento
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = departamento.Usuario
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = departamento.Fecha
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@accion"
            parametro.Value = accion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Modificar_Estatus_Departamento]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function consultarClaves(ByVal tipoClave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@tipoClave"
            parametro.Value = tipoClave
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Consultar_Claves_Departamentos]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
