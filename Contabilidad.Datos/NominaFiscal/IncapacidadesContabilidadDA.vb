Imports System.Data.SqlClient

Public Class IncapacidadesContabilidadDA

    Public Function listadoSolicitudesIncapacidades(ByVal idPatron As Int32, ByVal estatusId As Int32, ByVal nombre As String,
                                                    ByVal porfecha As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String,
                                                    ByVal tipoIncapacidadId As Int32) As DataTable
        Dim parametro As New SqlParameter
        Dim listaParametros As New List(Of SqlParameter)
        Dim persistencia As New Persistencia.OperacionesProcedimientos

        parametro.ParameterName = "patronId"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusid"
        parametro.Value = estatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "porFecha"
        parametro.Value = porfecha
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipoIncapacidadId"
        parametro.Value = tipoIncapacidadId
        listaParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ListadoSolicitudesIncapacidades", listaParametros)
    End Function

    Public Function cambiarEstatusIncapacidades(ByVal incapacidadesIds As String, ByVal opcion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidadids"
        parametro.Value = incapacidadesIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcion"
        parametro.Value = opcion
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_CambiarEstatus", listaParametros)
    End Function

    Public Function consultarInformacionSUA(ByVal idIncapcidades As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidadids"
        parametro.Value = idIncapcidades
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ConsultarInformacionSUA", listaParametros)
    End Function

    Public Function validarEstatus(ByVal idIncapacidad As Int32, ByVal opcion As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "incapacidadid"
        parametro.Value = idIncapacidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcEstatus"
        parametro.Value = opcion
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFIncapacidades_ValidarEstatus", listaParametros)
    End Function
End Class
