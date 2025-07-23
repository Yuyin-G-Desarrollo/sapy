Imports Persistencia
Imports Entidades
Imports System.Data.SqlClient

Public Class MetasProduccionDA

    Public Function TraerNavesComboDatos(ByVal Nave As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = Nave
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_MetasProduccionNavesPorDepartamento]", listaParametros)

    End Function

    Public Function TraerMetasPorHoraAlDia(ByVal idMetasProduccion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@IDMetaProduccion"
        parametro.Value = idMetasProduccion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_MetasPorHoraPorNavePorDia]", listaParametros)

    End Function

    Public Function TraerDepartamentosAltaMetas(ByVal NaveId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@NaveID"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_TraerDepartamentosSegunNave]", listaParametros)

    End Function

    Public Function AgregarActualizarmetaNave(ByVal tipo As String, ByVal cantidad As Integer, Optional ByVal dia As Integer = 0, Optional ByVal idConfiguracion As Integer = 0, Optional idMetaProduccion As Integer = 0) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@DiaMeta"
        parametro.Value = dia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CantidadMeta"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ConfigMeta"
        parametro.Value = idConfiguracion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Tipo"
        parametro.Value = tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@MetaIdProduccion"
        parametro.Value = idMetaProduccion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Insertar_Modificar_MetaNave]", listaParametros)

    End Function

    Public Function MetasProduccionAlta_Baja_Cambio(ByVal tipo As String, Optional Hora As String = "", Optional cantidad As Integer = 0, Optional IdMetaHora As Integer = 0, Optional idMetaProduccion As Integer = 0) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Hora"
        parametro.Value = Hora
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IDMetaProduccion"
        parametro.Value = idMetaProduccion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Accion"
        parametro.Value = tipo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IDMetaHora"
        parametro.Value = IdMetaHora
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_MetasProduccion_Alta_Modificacion_Cancelacion]", listaParametros)

    End Function

    Public Function ConfirmarAgregarOcambiarMetaProduccion(ByVal cantidad As Integer, ByVal hora As String, idMetaProduccion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "@Cantidad"
        parametro.Value = cantidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@hora"
        parametro.Value = hora
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@idMetaProduccion"
        parametro.Value = idMetaProduccion
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_ConfirmarSePuedeAgregaroCambiarMeta]", listaParametros)

    End Function

End Class
