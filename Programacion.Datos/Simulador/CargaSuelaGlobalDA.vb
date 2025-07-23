Imports System.Data.SqlClient
Public Class CargaSuelaGlobalDA
    Public Function CargarSuelaGlobal(ByVal opcion As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "Opcion"
        ParametroParaLista.Value = opcion
        ListaParametros.Add(ParametroParaLista)

        Dim dtSuelaGlobal As DataTable

        Try
            dtSuelaGlobal = operacion.EjecutarConsultaSP("Programacion.Sp_SuelaGlobal_Obt", ListaParametros)
        Catch ex As Exception
            Throw ex
        Finally
            operacion = Nothing
        End Try
        Return dtSuelaGlobal
    End Function
    Public Function RegistrarSuelaGlobal(ByVal suelaDescripcion As String, ByVal suelaActivo As Boolean) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "SuelaDescripcion"
        ParametroParaLista.Value = suelaDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "SuelaActivo"
        ParametroParaLista.Value = suelaActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "SuelaUsuarioId"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "fechaActual"
        ParametroParaLista.Value = Today.Date
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_SuelaGlobal_Ins", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function ModificarSuelaGlobal(ByVal suelaDescripcion As String, ByVal suelaActivo As Boolean, ByVal idSuelaGlobal As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlClient.SqlParameter)

        Dim ParametroParaLista As New SqlParameter
        ParametroParaLista.ParameterName = "IdSuelaGlobal"
        ParametroParaLista.Value = idSuelaGlobal
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "SuelaDescripcion"
        ParametroParaLista.Value = suelaDescripcion
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "SuelaActivo"
        ParametroParaLista.Value = suelaActivo
        ListaParametros.Add(ParametroParaLista)

        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "SuelaUsuarioId"
        ParametroParaLista.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        ListaParametros.Add(ParametroParaLista)


        ParametroParaLista = New SqlParameter
        ParametroParaLista.ParameterName = "fechaActual"
        ParametroParaLista.Value = Today.Date
        ListaParametros.Add(ParametroParaLista)

        Try
            operacion.EjecutarSentenciaSP("Programacion.Sp_SuelaGlobal_Mod", ListaParametros)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
