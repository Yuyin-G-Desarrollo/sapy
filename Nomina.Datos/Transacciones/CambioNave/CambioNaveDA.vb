Imports System.Data.SqlClient
Public Class CambioNaveDA

    Public Function obtenerListaColaboradoresFiltros(ByVal Filtros As Entidades.FiltrosFichaColaborador) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter


        parametro = New SqlParameter
        parametro.ParameterName = "@colaborador"
        parametro.Value = Filtros.PNombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@CURP"
        parametro.Value = Filtros.PCURP
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@RFC"
        parametro.Value = Filtros.PRFC
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@naveid"
        parametro.Value = Filtros.PIdNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@IdDepartamento"
        parametro.Value = Filtros.PIdDepartamento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Puesto"
        parametro.Value = Filtros.PIdPuesto
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "Usuario"
        'parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ConsultaColaboradoresCambioNave", listaParametros)
    End Function


    Public Function validarColaborador(ByVal colaborador As Integer, ByVal asegurado As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idColaborador"
        parametro.Value = colaborador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@asegurado"
        parametro.Value = asegurado
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ValidacionColaboradoresCambioNave", listaParametros)
    End Function

    Public Function copiarColaboradorSinSeguro(ByVal colaboradorId As Integer, ByVal patronOrigenId As Integer, ByVal patronDestinoId As Integer,
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

        parametro = New SqlParameter
        parametro.ParameterName = "@CreaSolicitudBaja"
        parametro.Value = 0
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_CopiarColaborador", listaParametros)
    End Function

    Public Function copiarColaboradorConSeguro(ByVal colaboradorId As Integer, ByVal naveOrigenId As Integer, ByVal naveDestinoId As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorID"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveOrigenID"
        parametro.Value = naveOrigenId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveDestinoID"
        parametro.Value = naveDestinoId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@UsuarioCreoID"
        'parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_CambioNave_CambioNaveManual", listaParametros)
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

End Class
