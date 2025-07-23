Imports System.Data.SqlClient
Imports Persistencia
Public Class BajaCambioNaveDA

    Public Function obtenerListaColaboradores(ByVal naveId As Integer, ByVal patronId As Integer, ByVal asegurado As Boolean, ByVal nombre As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "asegurado"
        'parametro.Value = asegurado
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colaborador"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_BuscarColaboradores", listaParametros)
    End Function

    Public Function obtenerNavesDestino(ByVal naveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveOrigenId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_ConsultarNavesDestino", listaParametros)
    End Function

    Public Function obtenerFechaCorteNave(ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer, ByVal colaboradorId As Integer, ByVal patronDestinoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NaveOrigenId"
        parametro.Value = naveOrigenId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "NaveDestinoId"
        parametro.Value = naveDestinoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PatronDestinoId"
        parametro.Value = patronDestinoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_FechaCorteNaves", listaParametros)
    End Function


    Public Function copiarColaborador(ByVal colaboradorId As Integer, ByVal patronOrigenId As Integer, ByVal patronDestinoId As Integer,
                                      ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorID"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PatronOrigenID"
        parametro.Value = patronOrigenId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PatronDestinoID"
        parametro.Value = patronDestinoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveOrigenID"
        parametro.Value = naveOrigenId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveDestinoID"
        parametro.Value = naveDestinoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCreoID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_CopiarColaborador", listaParametros)
    End Function
End Class
