Imports Persistencia
Imports System.Data.SqlClient

Public Class AsignacionDeCelulasDA

    Public Function totalLotesPares(ByVal NaveId As Integer, ByVal FechaProg As Date) As DataTable
        Dim Obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaProg"
        parametro.Value = FechaProg
        listaParametros.Add(parametro)

        Return Obj.EjecutarConsultaSP("[Produccion].[SP_ProgramacionLotes]", listaParametros)
    End Function


    Public Function Celulas(ByVal NaveId As Integer, ByVal Celula As String) As DataTable
        Dim Obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Celula"
        parametro.Value = Celula
        listaParametros.Add(parametro)

        Return Obj.EjecutarConsultaSP("[Produccion].[SP_ConsultaCelulas]", listaParametros)

    End Function

    Public Function departamentosNave(ByVal NaveId As Integer)
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_DepartamentosporNaveSicy]", listaParametros)

    End Function

    Public Function paresPorDepto(ByVal NaveId As Integer, ByVal Fecha As Date, ByVal DeptoId As Integer, ByVal Estado As String) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Fecha"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DeptoId"
        parametro.Value = DeptoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estado"
        parametro.Value = Estado
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_ParesPorDepartamento]", listaParametros)

    End Function


    Public Function configuracionXNave(ByVal NaveId As Integer, ByVal FehaP As Date) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaP"
        parametro.Value = FehaP
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_ConfiguracionXNave]", listaParametros)

    End Function

    Public Function fechasEmbarque(ByVal NaveId As Integer, ByVal FehaP As Date) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaP"
        parametro.Value = FehaP
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_FechaEmbarque]", listaParametros)

    End Function


    Public Function paresPorCelula(ByVal NaveId As Integer, ByVal Fecha As Date, ByVal DeptoId As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Fecha"
        parametro.Value = Fecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@DeptoId"
        parametro.Value = DeptoId
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_ParesPorCelula]", listaParametros)

    End Function

    Public Function InsertaAvanceCelula(ByVal Año As Integer, ByVal NaveId As Integer, ByVal LoteId As Integer, ByVal IdConfiguracion As Integer,
                                        ByVal IdCelula As Integer, ByVal Pares As Integer, ByVal Estado As String) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@Año"
        parametro.Value = Año
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = NaveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@LoteId"
        parametro.Value = LoteId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdConfiguracion"
        parametro.Value = IdConfiguracion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdCelula"
        parametro.Value = IdCelula
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Pares"
        parametro.Value = Pares
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Estado"
        parametro.Value = Estado
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_InsertaAvanceCelula]", listaParametros)

    End Function

    Public Function ActualizaAvanceCelula(ByVal IdCelula As Integer, ByVal IdAvance As Integer) As DataTable
        Dim obj As New Persistencia.OperacionesProcedimientosSICY
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@IdCelula"
        parametro.Value = IdCelula
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdAvance"
        parametro.Value = IdAvance
        listaParametros.Add(parametro)

        Return obj.EjecutarConsultaSP("[Produccion].[SP_ActualizaAvanceCelula]", listaParametros)

    End Function

End Class
