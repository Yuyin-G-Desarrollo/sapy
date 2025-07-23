Imports System.Data.SqlClient
Public Class AsuntosMuestrasDA

    Public Function VerListaAsuntos(ByVal activo As Boolean) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)
        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = activo
        ListaParametros.Add(ParametroParaLista)
        Return operacion.EjecutarConsultaSP("Programacion.SP_Consulta_AsuntosMuestras", ListaParametros)
    End Function
    Public Function obtener(prefixText As String, count As Integer) As List(Of Entidades.AsuntosMuestras)
        Dim EntidadAsuntoMuestras As New List(Of Entidades.AsuntosMuestras)
    End Function




    Public Sub RegistraAsunto(ByVal entidadAsuntosMuestras As Entidades.AsuntosMuestras, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = entidadAsuntosMuestras.Descripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = entidadAsuntosMuestras.Activo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_Alta_AsuntoMuestra", ListaParametros)
    End Sub
    Public Sub EditarAsuntoMuestra(ByVal EntidadAsuntoMuestras As Entidades.AsuntosMuestras, ByVal usuario As Int32)
        Dim operacion As New Persistencia.OperacionesProcedimientos

        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "id"
        ParametroParaLista.Value = EntidadAsuntoMuestras.AsuntoMuestraId
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "descripcion"
        ParametroParaLista.Value = EntidadAsuntoMuestras.Descripcion
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "activo"
        ParametroParaLista.Value = EntidadAsuntoMuestras.Activo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "usuario"
        ParametroParaLista.Value = usuario
        ListaParametros.Add(ParametroParaLista)

        operacion.EjecutarSentenciaSP("Programacion.SP_EditarAsuntoMuestra", ListaParametros)

    End Sub
End Class
