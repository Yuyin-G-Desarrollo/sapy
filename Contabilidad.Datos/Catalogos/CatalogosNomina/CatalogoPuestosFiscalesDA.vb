Imports System.Data.SqlClient

Public Class PuestosFiscalesDA
    Public Function Consulta_Puestos_Por_Patron(ByVal patron As Integer, estatus As Integer) As DataTable
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

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Puestos_Por_Patron]", listaParametros)
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function InsertarPuesto_PorPatron(ByVal puesto As Entidades.PuestoFiscal) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@patron"
            parametro.Value = puesto.ID_Patron
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@puesto"
            parametro.Value = puesto.NombrePatron
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuario"
            parametro.Value = puesto.UsuarioCreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fecha"
            parametro.Value = puesto.FechaCreo
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Alta_Puesto_Por_Patron]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function Eliminar_ActivarPuesto_PorPatron(ByVal accion As Integer, ByVal puesto As Entidades.PuestoFiscal) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter
        Try
            parametro = New SqlParameter
            parametro.ParameterName = "@puesto"
            parametro.Value = puesto.ID_Patron
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@usuarioM"
            parametro.Value = puesto.UsuarioCreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@fechaM"
            parametro.Value = puesto.FechaCreo
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@accion"
            parametro.Value = accion
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Contabilidad].[SP_Modificar_Estatus_Puesto ]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
