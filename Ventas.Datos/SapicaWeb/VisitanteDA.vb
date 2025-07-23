Imports System.Data.SqlClient

Public Class VisitanteDA
    Public Function consultarEventoActivo() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutaConsulta("EXEC [SAPICA].[SP_Visitante_ConsultaEventoActivo]")
    End Function

    Public Function consultarFechaActual() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = <consulta>
                       SELECT DATENAME(WEEKDAY, GETDATE()) + ' ' + 
                        CONVERT(VARCHAR(2), DATEPART(DAY, GETDATE())) + ' de ' + 
                        DATENAME(MONTH, GETDATE()) + ' de ' +
                        CONVERT(VARCHAR(4), YEAR(GETDATE())) + ', ' + 
                        CONVERT(VARCHAR(15),CAST(GETDATE() AS TIME), 100) AS FECHA_ACTUAL
                   </consulta>.Value

        Return persistencia.EjecutaConsulta(consulta)
    End Function

    Public Function consultarTipoVisitante() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutaConsulta("EXEC [SAPICA].[SP_Visitante_ConsultaTipoVisitante]")
    End Function

    Public Function consultarDistribuidores() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutaConsulta("EXEC [SAPICA].[SP_Visitante_ConsultaDistribuidores]")
    End Function

    Public Function consultarAtiende() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutaConsulta("EXEC [SAPICA].[SP_Visitante_ConsultaAtiende]")
    End Function

    Public Function consultarClientesVisitantes(ByVal opcion As Int32, ByVal filtro As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "opcionFiltro"
        parametro.Value = opcion
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtro"
        parametro.Value = filtro
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaClientesVisitantes]", lstParametros)
    End Function

    Public Function consultarDatosVisitanteAnterior(ByVal visitanteId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaDatosVisitanteAnterior]", lstParametros)
    End Function

    Public Function consultarDatosCliente(ByVal clienteId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteId"
        parametro.Value = clienteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaDatosCliente]", lstParametros)
    End Function

    Public Function consultarEmailCliente(ByVal personaId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "personaId"
        parametro.Value = personaId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaEmailCliente]", lstParametros)
    End Function

    Public Function consultarDirectorCliente(ByVal personaId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "personaId"
        parametro.Value = personaId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaDirectorCliente]", lstParametros)
    End Function

    Public Function consultarRamoCliente(ByVal clienteId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteId"
        parametro.Value = clienteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaRamoCliente]", lstParametros)
    End Function

    Public Function consultarTiendasCliente(ByVal clienteId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "clienteId"
        parametro.Value = clienteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaTiendasCliente]", lstParametros)
    End Function

    Public Function consultarTelefonosVisitante(ByVal visitanteId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaTelefonosVisitante]", lstParametros)
    End Function

    Public Function consultarTelefonosCliente(ByVal personaId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "personaId"
        parametro.Value = personaId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaTelefonosCliente]", lstParametros)
    End Function

    Public Function consultarClienteEventosAnteriores(ByVal nombreVisitante As String, ByVal nombreComercial As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "nombreVisitante"
        parametro.Value = nombreVisitante.Trim
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombreComercial"
        parametro.Value = nombreComercial.Trim
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaClienteEventosAnteriores]", lstParametros)
    End Function

    Public Function altaVisitante(ByVal visitante As Entidades.Visitante) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        If visitante.VClienteId <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "clienteId"
            parametro.Value = visitante.VClienteId
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "nombrevisitante"
        parametro.Value = visitante.VNombreVisitante
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = visitante.VClasificacionPersonaId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "eventosanteriores"
        parametro.Value = visitante.VEventosAnteriores
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = visitante.VCalle
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroexterior"
        parametro.Value = visitante.VNumeroExterior
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = visitante.VColonia
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = visitante.VCiudadId
        lstParametros.Add(parametro)

        If visitante.VCiudad <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "ciudad"
            parametro.Value = visitante.VCiudad
            lstParametros.Add(parametro)
        End If

        If visitante.VEstado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "estado"
            parametro.Value = visitante.VEstado
            lstParametros.Add(parametro)
        End If

        If visitante.VPais <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "pais"
            parametro.Value = visitante.VPais
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "correoelectronico"
        parametro.Value = visitante.VCorreoElectronico
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "director"
        parametro.Value = visitante.VDirector
        lstParametros.Add(parametro)

        If visitante.VOtroContacto <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "otrocontacto"
            parametro.Value = visitante.VOtroContacto
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "hacompradoyuyin"
        parametro.Value = visitante.VHaCombradoYuyin
        lstParametros.Add(parametro)

        If visitante.VDistribuidorClienteId <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "distribuidor_clienteid"
            parametro.Value = visitante.VDistribuidorClienteId
            lstParametros.Add(parametro)
        End If

        If visitante.VOtroDistribuidor <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "otrodistribuidor"
            parametro.Value = visitante.VOtroDistribuidor
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "nombrecomercial"
        parametro.Value = visitante.VNombreComercial
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ramoid"
        parametro.Value = visitante.VRamoId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadtiendas"
        parametro.Value = visitante.VCantidadTiendas
        lstParametros.Add(parametro)

        If visitante.VObservaciones <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "observaciones"
            parametro.Value = visitante.VObservaciones
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioatiendeid"
        parametro.Value = visitante.VUsuarioAtiendeId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = visitante.VActivo
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = visitante.VUsuarioCreoId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_AltaVisitante]", lstParametros)
    End Function

    Public Sub altaTelefonoVisitante(ByVal personaId As Integer, ByVal telefono As Entidades.TelefonoVisitante)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "visitanteid"
        parametro.Value = telefono.TVVisitanteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = telefono.TVTelefono
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = telefono.TVActivo
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreoid"
        parametro.Value = telefono.TVUsuarioCreoId
        lstParametros.Add(parametro)

        If personaId <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "personaid"
            parametro.Value = personaId
            lstParametros.Add(parametro)
        End If

        persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_AltaTelefonoVisitante]", lstParametros)
    End Sub

    Public Function consultarEventos() As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Return persistencia.EjecutaConsulta("EXEC [SAPICA].[SP_Visitante_ConsultaEventos]")
    End Function

    Public Function consultarListadoVisitantes(ByVal eventoId As Integer, ByVal visitantesIds As String, ByVal atendioIds As String, ByVal tipos As String, ByVal fechaInicio As String, ByVal fechaFin As String, ByVal condicion As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "eventoId"
        parametro.Value = eventoId
        lstParametros.Add(parametro)

        If visitantesIds <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "visitantesIds"
            parametro.Value = visitantesIds
            lstParametros.Add(parametro)
        End If

        If atendioIds <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "atendioIds"
            parametro.Value = atendioIds
            lstParametros.Add(parametro)
        End If

        If tipos <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "tipos"
            parametro.Value = tipos
            lstParametros.Add(parametro)
        End If

        If fechaInicio <> "" And fechaFin <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "fechaInicio"
            parametro.Value = fechaInicio
            lstParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "fechaFin"
            parametro.Value = fechaFin
            lstParametros.Add(parametro)
        End If

        If condicion <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "condicion"
            parametro.Value = condicion
            lstParametros.Add(parametro)
        End If

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaListado]", lstParametros)
    End Function

    Public Function consultarVisitante(ByVal visitanteId As Int32) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaVisitante]", lstParametros)
    End Function

    Public Function editarVisitante(ByVal visitante As Entidades.Visitante) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "visitanteId"
        parametro.Value = visitante.VId
        lstParametros.Add(parametro)

        If visitante.VClienteId <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "clienteId"
            parametro.Value = visitante.VClienteId
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "nombrevisitante"
        parametro.Value = visitante.VNombreVisitante
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "clasificacionpersonaid"
        parametro.Value = visitante.VClasificacionPersonaId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "eventosanteriores"
        parametro.Value = visitante.VEventosAnteriores
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "calle"
        parametro.Value = visitante.VCalle
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroexterior"
        parametro.Value = visitante.VNumeroExterior
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colonia"
        parametro.Value = visitante.VColonia
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ciudadid"
        parametro.Value = visitante.VCiudadId
        lstParametros.Add(parametro)

        If visitante.VCiudad <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "ciudad"
            parametro.Value = visitante.VCiudad
            lstParametros.Add(parametro)
        End If

        If visitante.VEstado <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "estado"
            parametro.Value = visitante.VEstado
            lstParametros.Add(parametro)
        End If

        If visitante.VPais <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "pais"
            parametro.Value = visitante.VPais
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "correoelectronico"
        parametro.Value = visitante.VCorreoElectronico
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "director"
        parametro.Value = visitante.VDirector
        lstParametros.Add(parametro)

        If visitante.VOtroContacto <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "otrocontacto"
            parametro.Value = visitante.VOtroContacto
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "hacompradoyuyin"
        parametro.Value = visitante.VHaCombradoYuyin
        lstParametros.Add(parametro)

        If visitante.VDistribuidorClienteId <> 0 Then
            parametro = New SqlParameter
            parametro.ParameterName = "distribuidor_clienteid"
            parametro.Value = visitante.VDistribuidorClienteId
            lstParametros.Add(parametro)
        End If

        If visitante.VOtroDistribuidor <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "otrodistribuidor"
            parametro.Value = visitante.VOtroDistribuidor
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "nombrecomercial"
        parametro.Value = visitante.VNombreComercial
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ramoid"
        parametro.Value = visitante.VRamoId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cantidadtiendas"
        parametro.Value = visitante.VCantidadTiendas
        lstParametros.Add(parametro)

        If visitante.VObservaciones <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "observaciones"
            parametro.Value = visitante.VObservaciones
            lstParametros.Add(parametro)
        End If

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioatiendeid"
        parametro.Value = visitante.VUsuarioAtiendeId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = visitante.VActivo
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = visitante.VUsuarioModifico
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_EdicionVisitante]", lstParametros)
    End Function

    Public Sub editarTelefonoVisitante(ByVal telefono As Entidades.TelefonoVisitante)
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "telefonoId"
        parametro.Value = telefono.TVTelefonoId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "visitanteid"
        parametro.Value = telefono.TVVisitanteId
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "telefono"
        parametro.Value = telefono.TVTelefono
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "activo"
        parametro.Value = telefono.TVActivo
        lstParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodificoid"
        parametro.Value = telefono.TVUsuarioModificoId
        lstParametros.Add(parametro)

        persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_EdicionTelefonoVisitante]", lstParametros)
    End Sub

    Public Function consultarListadoFiltroVisitantes(ByVal eventoId As Integer, ByVal filtro As String) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "eventoId"
        parametro.Value = eventoId
        lstParametros.Add(parametro)

        If filtro <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "filtro"
            parametro.Value = filtro
            lstParametros.Add(parametro)
        End If

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaListadoFiltro]", lstParametros)
    End Function

    Public Function consultarFechasEvento(ByVal eventoId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "eventoId"
        parametro.Value = eventoId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaFechasEvento]", lstParametros)
    End Function

    Public Function consultarNumPedidosVisitante(ByVal visitanteId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaNumPedidosVisitante]", lstParametros)
    End Function

    Public Function consultarVisitanteTipoClasificacion(ByVal visitanteId As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim lstParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "visitanteId"
        parametro.Value = visitanteId
        lstParametros.Add(parametro)

        Return persistencia.EjecutarConsultaSP("[SAPICA].[SP_Visitante_ConsultaVisitanteTipoClasificacion]", lstParametros)
    End Function
End Class
