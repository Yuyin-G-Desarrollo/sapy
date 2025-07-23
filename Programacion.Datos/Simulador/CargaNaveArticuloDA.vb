Imports System.Data.SqlClient
Public Class CargaNaveArticuloDA
    Public Function CargarProductosNaveNoAsignado(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "IdNave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        Dim dtNoAsignados As DataTable

        Try
            dtNoAsignados = operacion.EjecutarConsultaSP("Programacion.Sp_ConsultaProductoNaveSeleccionar", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtNoAsignados
    End Function
    Public Function CargarProductosNaveAsignado(ByVal nave As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "IdNave"
        ParametroParaLista.Value = nave
        ListaParametros.Add(ParametroParaLista)

        Dim dtAsignados As DataTable

        Try
            dtAsignados = operacion.EjecutarConsultaSP("Programacion.Sp_ConsultaProductoNaveAsignados", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtAsignados
    End Function

    Public Function InsertarModificaNaveArticulo(ByVal Nave As Integer, _
                                               ByVal ProductoId As Integer, _
                                               ByVal Prioridad As Integer, _
                                               ByVal FechaInicio As Object, _
                                               ByVal FechaFin As Object, _
                                               ByVal Usuario As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Nave"
        ParametroParaLista.Value = Nave
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "ProductoId"
        ParametroParaLista.Value = ProductoId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Prioridad"
        ParametroParaLista.Value = Prioridad
        ListaParametros.Add(ParametroParaLista)

        If Not FechaInicio Is DBNull.Value Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "FechaInicio"
            ParametroParaLista.Value = Convert.ToDateTime(FechaInicio)
            ListaParametros.Add(ParametroParaLista)
        Else
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "FechaInicio"
            ParametroParaLista.Value = Today.Date
            ListaParametros.Add(ParametroParaLista)
        End If

        If Not FechaFin Is DBNull.Value Then
            ParametroParaLista = New SqlParameter
            ParametroParaLista.ParameterName = "FechaFin"
            ParametroParaLista.Value = Convert.ToDateTime(FechaFin)
            ListaParametros.Add(ParametroParaLista)
        End If

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "Usuario"
        ParametroParaLista.Value = Usuario
        ListaParametros.Add(ParametroParaLista)
        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_InsertaActualizaNaveArticulo", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
