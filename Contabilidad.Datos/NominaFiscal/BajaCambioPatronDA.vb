Imports System.Data.SqlClient
Imports Persistencia
Public Class BajaCambioPatronDA

    Public Function obtenerListaColaboradores(ByVal patronId As Integer, ByVal nombre As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colaborador"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_BuscarColaboradoresPatron", listaParametros)
    End Function

    Public Function obtenerFechasMovimientos(ByVal patronDestinoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronDestinoId"
        parametro.Value = patronDestinoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_ObtieneFechasMovimientos", listaParametros)
    End Function

    Public Function copiarColaborador(ByVal cambioColaborador As Entidades.ColaboradorCambioPatron) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorId"
        parametro.Value = cambioColaborador.PColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PatronOrigenId"
        parametro.Value = cambioColaborador.PPatronOrigenId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PatronDestinoId"
        parametro.Value = cambioColaborador.PPatronDestinoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveOrigenId"
        parametro.Value = cambioColaborador.PNaveOrigenId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveDestinoId"
        parametro.Value = cambioColaborador.PNaveDestinoId
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@Infonavit"
        'parametro.Value = cambioColaborador.PTieneInfonavit
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaBaja"
        parametro.Value = cambioColaborador.PFechaBaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaAlta"
        parametro.Value = cambioColaborador.PFechaAlta
        listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@SDIAlta"
        'parametro.Value = cambioColaborador.PSDIAlta
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@DeptoFiscalId"
        'parametro.Value = cambioColaborador.PDeptoFiscal
        'listaParametros.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "@PuestoFiscalId"
        'parametro.Value = cambioColaborador.PPuestoFiscal
        'listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioCreoID"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_CopiarColaboradorPatron", listaParametros)
    End Function

    Public Function obtenerDatosAlta(ByVal colaboradorId As Integer, ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@ColaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@PatronDestinoId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_obtenerDatosAlta", listaParametros)
    End Function

    Public Function consultaPatrones(ByVal idUsuario As Int32, ByVal idNave As Int32, ByVal idPatron As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = idUsuario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_ConsultaPatrones", listaParametros)
    End Function

    Public Function validaFechaCierreNominaReal(ByVal idNave As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveid"
        parametro.Value = idNave
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_ValidaFechaCierreNominaReal", listaParametros)
    End Function

End Class
