Imports Persistencia
Imports System.Data.SqlClient

Public Class ReplicaClientesDA


    Dim operacionesSICY As New Persistencia.OperacionesProcedimientosSICY
    Dim objPersistencia As New Persistencia.OperacionesProcedimientos

    Public Function ValidarNombreCliente(ByVal NombreCliente As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NombreCliente"
            parametro.Value = NombreCliente
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReplicaCliente_ValidarClienteRepetido]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ValidaExisteReplicaCliente(ByVal ClienteSAYID As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClienteSAYId"
            parametro.Value = ClienteSAYID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_ValidarClienteReplicado]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaClientesSinReplicar(ByVal idcedis As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)

        Try
            Dim parametro As New SqlParameter("@idcedis", idcedis)
            listaParametros.Add(parametro)
            'Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_ConsultaClientesPorReplicar]", listaParametros)
            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_ConsultaClientesPorReplicarXCedis]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ReplicarInformacionSAY(ByVal ClienteSAYID As Integer, ByVal ClienteSICYID As Integer, ByVal NombreCliente As String, ByVal UsuarioId As Integer, ByVal MarcaClienteOriginal As String, ByVal MarcaClienteReplica As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClienteSAYID"
            parametro.Value = ClienteSAYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Cliente_SICYID"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NombreCliente"
            parametro.Value = NombreCliente
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasClienteOriginal"
            parametro.Value = MarcaClienteOriginal
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@MarcasClienteReplica"
            parametro.Value = MarcaClienteReplica
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_InsertarInformacion]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ReplicarInformacionSICY(ByVal ClienteSICY As Integer, ByVal NombreCliente As String, ByVal MarcaSICYOriginalID As String, ByVal MarcaSICYReplicaId As String) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@ClienteSICY_ID"
            parametro.Value = ClienteSICY
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NombreCliente"
            parametro.Value = NombreCliente
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcaSICYOriginalID"
            parametro.Value = MarcaSICYOriginalID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@MarcaSICYReplicaId"
            parametro.Value = MarcaSICYReplicaId
            listaParametros.Add(parametro)

            Return operacionesSICY.EjecutarConsultaSP("[Ventas].[SP_ReplicarCliente_InsertarInformacion]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsultaMarcasCliente(ByVal ClienteId As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try

            parametro.ParameterName = "@ClienteId"
            parametro.Value = ClienteId
            listaParametros.Add(parametro)

            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_ConsultaMarcasCliente]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidaExisteReplicaClienteReedition(ByVal ClienteSAYID As Integer) As DataTable
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClienteSAYId"
            parametro.Value = ClienteSAYID
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_ValidarClienteReplicadoReedition]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ReplicarInformacionSICYSinMarcasReedition(ByVal ClienteSICY As Integer, ByVal NombreCliente As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ClienteSICY_ID", ClienteSICY)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NombreCliente", NombreCliente)
        listaParametros.Add(parametro)

        Return operacionesSICY.EjecutarConsultaSP("[Ventas].[SP_ReplicarCliente_InsertarInformacionreedition]", listaParametros)

    End Function

    Public Function ReplicarInformacionSAYReedition(ByVal ClienteSAYID As Integer, ByVal ClienteSICYID As Integer, ByVal NombreCliente As String, ByVal UsuarioId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@ClienteSAYID"
            parametro.Value = ClienteSAYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Cliente_SICYID"
            parametro.Value = ClienteSICYID
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NombreCliente"
            parametro.Value = NombreCliente
            listaParametros.Add(parametro)


            parametro = New SqlParameter
            parametro.ParameterName = "@UsuarioId"
            parametro.Value = UsuarioId
            listaParametros.Add(parametro)


            'Return objPersistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_InsertarInformacionSAYReedition]", listaParametros)
            'Return persistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_InsertarInformacionSAYReeditionp_RUEBAS]", listaParametros)
            Return persistencia.EjecutarConsultaSP("[Almacen].[SP_ReplicaClientes_InsertarInformacionSAYReedition]", listaParametros)


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ValidarNombreClienteReedition(ByVal NombreCliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Try
            parametro.ParameterName = "@NombreCliente"
            parametro.Value = NombreCliente
            listaParametros.Add(parametro)


            Return objPersistencia.EjecutarConsultaSP("[Ventas].[SP_ReplicaCliente_ValidarClienteRepetidoReedition]", listaParametros)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
