Imports System.Data.SqlClient

Public Class RecalculosDA
    Public Function obtenerAniosPatron(ByVal patronId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_Recalculos_ObtenerAniosPatron", listaParametros)
    End Function

    Public Function consultarRecalculosDescuentos(ByVal patronId As Int32, ByVal anio As Integer, ByVal tipo As Int16) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipo"
        parametro.Value = tipo
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_Recalculos_Consultar", listaParametros)
    End Function

    Public Function recalcularDescuentos(ByVal patronId As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_Recalculos_Calcular", listaParametros)
    End Function

    Public Function datosEmpresa(ByVal patronid As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = patronid
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_Recalculos_ConsultaDatosEmpresa", listaParametro)
    End Function

    Public Function autorizarRealculo(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NF_Recalculos_Autorizar]", listaParametro)
    End Function

    Public Function validaAutorizado(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_Recalculos_ValidarEstatus]", listaParametro)
    End Function

    Public Function obtieneDestinosCorreo(ByVal patronId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametro As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronid"
        parametro.Value = patronId
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[Contabilidad].[SP_NF_Recalculos_obtenerCorreos]", listaParametro)
    End Function

End Class
