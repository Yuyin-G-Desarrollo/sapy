Imports System.Data.SqlClient
Imports Persistencia
Public Class ModificacionSalarioDA
    Public Function obtenerEstatusModificacionSalario() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NFModificacionSalario_ObtenerListaEstatus"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultarListaSolicitudesModificacionSalario(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal naveId As Integer, ByVal nombre As String,
                                                                 ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "estatusId"
        parametro.Value = estatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ConsultarListaSolicitudes", listaParametros)
    End Function

    Public Function obtenerColaboradorModificacionSalario(ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ObtenerColaborador", listaParametros)
    End Function

    Public Function altaModificacionSalario(ByVal modSalario As Entidades.ModificacionSalario) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = modSalario.MDColaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = modSalario.MDPatronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioanterior"
        parametro.Value = modSalario.MDSalarioAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarionuevo"
        parametro.Value = modSalario.MDSalarioNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "excedentetabulador"
        parametro.Value = modSalario.MDExcedenteTabulador
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoinfonavitanterior"
        parametro.Value = modSalario.MDDescuentoInfonavitAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoInfonavitnuevo"
        parametro.Value = modSalario.MDDescuentoInfonavitNuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoInfonavitDiarionuevo"
        parametro.Value = modSalario.MDDescuentoInfonavitDiarionuevo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoImssDiario"
        parametro.Value = modSalario.MDDescuentoImssDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoImssSem"
        parametro.Value = modSalario.MDDescuentoImssSem
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoISRDiario"
        parametro.Value = modSalario.MDDescuentoISRDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoISRSem"
        parametro.Value = modSalario.MDDescuentoISRSem
        listaParametros.Add(parametro)

        If modSalario.MDMotivoCreacion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "motivoCreacion"
            parametro.Value = modSalario.MDMotivoCreacion
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuario"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_AltaSolicitud", listaParametros)
    End Function

    Public Function validarColaboradorSolicitud(ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ValidarColaboradorSolicitud", listaParametros)
    End Function

    Public Function obtenerExedenteTabulador(ByVal colaboradorId As Integer, ByVal salarioAnterior As Double, ByVal salarioNuevo As Double) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioAnterior"
        parametro.Value = salarioAnterior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioNuevo"
        parametro.Value = salarioNuevo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ObtenerExedenteTabulador", listaParametros)
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ValidarEstatus", listaParametros)
    End Function

    Public Function cambiarEstatus(ByVal solicitudId As Integer, ByVal opcEstatus As Integer, ByVal motivoRechazo As String, ByVal descuentoSem As Double, ByVal descuentoDiario As Double) As DataTable
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

        If descuentoSem <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "descuentoSem"
            parametro.Value = descuentoSem
            listaParametros.Add(parametro)
        End If

        If descuentoDiario <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "descuentoDiario"
            parametro.Value = descuentoDiario
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_CambiarEstatus", listaParametros)
    End Function

    Public Function consultarSolicitudModificacionSalario(ByVal solicitudId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ConsultarSolicitud", listaParametros)
    End Function

    Public Function consultarPeriodoNominaSolicitud(ByVal solicitudId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ConsultarPeriodoNominaSolicitud", listaParametros)
    End Function

    Public Function editarModificacionSalario(ByVal solicitudId As Integer, ByVal fechaMovimiento As Date) As DataTable
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
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_EditarModificacionSolicitud", listaParametros)
    End Function

    Public Function consultarInformacionIDSE(ByVal solicitudIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudIds"
        parametro.Value = solicitudIds
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ConsultarInformacionIDSE", listaParametros)
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_AplicarSolicitud", listaParametros)
    End Function

    Public Function rechazarIdseSolicitud(ByVal solicitudId As Integer, ByVal carpeta As String, ByVal archivo As String,
                                          ByVal motivoRechazo As String, ByVal descuentoSem As Double,
                                          ByVal descuentoDiario As Double) As DataTable
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

        If descuentoSem <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "descuentoSem"
            parametro.Value = descuentoSem
            listaParametros.Add(parametro)
        End If

        If descuentoDiario <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "descuentoDiario"
            parametro.Value = descuentoDiario
            listaParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_RechazarIdseSolicitud", listaParametros)
    End Function

    Public Function consultaDatosCorreo(ByVal solicitudId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "solicitudId"
        parametro.Value = solicitudId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ConsultaDatosCorreo", listaParametros)
    End Function

    Public Function obtenerFechaMovimiento(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFModificacionSalario_ObtenerFechaMovimiento", listaParametros)
    End Function
End Class
