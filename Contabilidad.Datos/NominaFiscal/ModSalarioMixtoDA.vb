Imports System.Data.SqlClient
Public Class ModSalarioMixtoDA
    Public Function consultarListaSolicitudesModificacionSalario(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal colaboradoresId As String,
                                                                 ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusId"
        parametro.Value = estatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradores"
        parametro.Value = colaboradoresId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "periodo"
        parametro.Value = periodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaInicio"
        parametro.Value = fechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_ConsultarListaSolicitudes", listaParametros)
    End Function

    Public Function validarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcEstatus"
        parametro.Value = opcEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_ValidarEstatus", listaParametros)
    End Function

    Public Function consultarInformacionIDSE(ByVal solicitudIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudIds"
        parametro.Value = solicitudIds
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_ConsultarInformacionIDSE", listaParametros)
    End Function

    Public Function cambiarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer, ByVal motivoRechazo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcEstatus"
        parametro.Value = opcEstatus
        listaParametros.Add(parametro)

        If motivoRechazo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "motivoRechazo"
            parametro.Value = motivoRechazo
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_CambiarEstatus", listaParametros)
    End Function
    Public Function editarModificacionSalario(ByVal solicitudId As Integer, ByVal fechaMovimiento As Date, ByVal salarioNuevo As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaMovimiento"
        parametro.Value = fechaMovimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioNuevo"
        parametro.Value = salarioNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_EditarSolicitud", listaParametros)
    End Function

    Public Function consultarSolicitudModificacionSalario(ByVal solicitudId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_ConsultarSolicitud", listaParametros)
    End Function

    Public Function aplicarSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = archivo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_AplicarSolicitud", listaParametros)
    End Function

    Public Function rechazarIdseSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String,
                                          ByVal motivoRechazo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "carpeta"
        parametro.Value = carpeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "archivo"
        parametro.Value = archivo
        listaParametros.Add(parametro)

        If motivoRechazo <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "motivoRechazo"
            parametro.Value = motivoRechazo
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_RechazarIdseSolicitud", listaParametros)
    End Function

    Public Function consultaDatosCorreo(ByVal solicitudId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ModSalario_ConsultaDatosCorreo", listaParametros)
    End Function
End Class
