Imports Programacion.Datos
Public Class BalanceoNavesBU

    Public Function GuardarConfiguracionCalendario(ByVal xml As String)
        Dim obj As New BalanceoNavesDA
        Return obj.GuardarConfiguracionCalendario(xml)
    End Function

    Public Function ConsultarGrupo()
        Dim obj As New BalanceoNavesDA
        Return obj.ConsultarGrupo()
    End Function

    Public Function GenerarSemanasDeColocacion(ByVal anio As Integer) As DataTable
        Dim obj As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = obj.GenerarSemanasDeColocacion(anio)
        Return Tabla
    End Function


    Public Function MostrarCalendario(ByVal anio As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.MostrarCalendario(anio)
    End Function

    Public Function ListaProgramas(ByVal grupo As String, ByVal semana As Integer, ByVal año As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.ListaProgramas(grupo, semana, año)
    End Function


    Public Function ConsultarNavesXGrupo(ByVal Grupo As String)
        Dim obj As New BalanceoNavesDA
        Return obj.ConsultarNavesXGrupo(Grupo)
    End Function

    Public Function ConsultaBalanceoXNave(ByVal idNave As Integer, ByVal semana As Integer, ByVal anio As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.ConsultaBalanceoXNave(idNave, semana, anio)
    End Function

    Public Function GuardarProgramasDiasHabilitados(ByVal grupo As String, ByVal semana As Integer, ByVal año As Integer, ByVal xml As String)
        Dim obj As New BalanceoNavesDA
        Return obj.GuardarProgramasDiasHabilitados(grupo, semana, año, xml)
    End Function

    Public Function ConsultarBalanceo(ByVal año As Integer, ByVal semana As Integer, ByVal idnave As Integer, ByVal verDetalles As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.ConsultarBalanceo(año, semana, idnave, verDetalles)
    End Function

    Public Function SP_BalanceoNaves_GenerarSession(ByVal usuarioId As Integer, ByVal idnave As Integer, ByVal semana As Integer, ByVal año As Integer) ' As Integer
        Dim obj As New BalanceoNavesDA
        Return obj.SP_BalanceoNaves_GenerarSession(usuarioId, idnave, semana, año)
    End Function

    Public Function SP_BalanceoNaves_GeneraRegistroSimulador(ByVal idnave As Integer, ByVal semana As Integer, ByVal año As Integer, ByVal sesionId As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.SP_BalanceoNaves_GeneraRegistroSimulador(idnave, semana, año, sesionId)
    End Function

    Public Function BalanceoNaves_GeneraAlgoritmoBalanceo(ByVal sesionId As Integer) As DataTable
        Dim obj As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = obj.BalanceoNaves_GeneraAlgoritmoBalanceo(sesionId)
        Return Tabla
    End Function

    Public Function BalanceoNaves_GeneraRegistroBalanceo(ByVal año As Integer, ByVal semana As Integer, ByVal idnave As Integer, ByVal XmlRegistros As String)
        Dim obj As New BalanceoNavesDA
        Return obj.BalanceoNaves_GeneraRegistroBalanceo(año, semana, idnave, XmlRegistros)
    End Function

    Public Function BalanceoNaves_GeneraRegistroBalanceoDetalle(ByVal idBalanceo As Integer, ByVal usuarioId As Integer, ByVal sesionid As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.BalanceoNaves_GeneraRegistroBalanceoDetalle(idBalanceo, usuarioId, sesionid)
    End Function

    Public Function ObtenerInfoPlanAutorizado(ByVal Grupo As String, ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer,
                                             ByVal FCliente As String, ByVal FPedidoSAY As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerInfoPlanAutorizado(Grupo, NaveID, Semana, Año, FCliente, FPedidoSAY)
        Return Tabla
    End Function

    Public Function ActualizarCambiosPrioridad(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ActualizarCambiosPrioridad(vXmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function ObtenerListadoProgramas() As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerListadoProgramas()
        Return Tabla
    End Function

    Public Function ObtieneClientesBalanceoSemanal(ByVal Grupo As String, ByVal NaveID As Integer, ByVal ProgramaID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneClientesBalanceoSemanal(Grupo, NaveID, ProgramaID)
        Return Tabla
    End Function

    Public Function ActualizarConfiguracionConcentrados(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ActualizarConfiguracionConcentrados(vXmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function ConsultarNavesAux(ByVal Grupo As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim tabla As New DataTable
        tabla = objDA.ConsultarNavesAux(Grupo)
        Return tabla

    End Function

    Public Function ObtenerTodosClientes(ByVal ClienteID As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerTodosClientes(ClienteID)
        Return Tabla
    End Function

    Public Function ActualizarTodosClienteConcentrado(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ActualizarTodosClienteConcentrado(vXmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function CargarFamiliaPorNave(ByVal NaveID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.CargarFamiliaPorNave(NaveID)
        Return Tabla
    End Function

    Public Function ListadoParametroBalanceoNaves(ByVal tipo_busqueda As Integer, ByVal FamiliaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ListadoParametroBalanceoNaves(tipo_busqueda, FamiliaID, NaveID)
        Return Tabla
    End Function

    Public Function ObtenerConfiguracionTamañoLote(ByVal FColeccion As String, ByVal NaveID As Integer, ByVal FamiliaID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerConfiguracionTamañoLote(FColeccion, NaveID, FamiliaID)
        Return Tabla
    End Function


    Public Function ActualizarTamanioLote(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ActualizarTamanioLote(vXmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function ObtieneBalanceoNaves(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal Grupo As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneBalanceoNaves(NaveID, Semana, Año, Grupo)
        Return Tabla
    End Function

    Public Function ObtieneBalanceoNavesReporte(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneBalanceoNavesReporte(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function AutorizarBalanceoNaves(ByVal vXmlCeldasModificadas As String, ByVal Accion As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.AutorizarBalanceoNaves(vXmlCeldasModificadas, Accion)
        Return Tabla
    End Function

    Public Function ObtieneMotivosSolicitudCambio() As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneMotivosSolicitudCambio()
        Return Tabla
    End Function

    Public Function CargarSemanaDato(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.CargarSemanaDato(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function InsertaSolicitudCambios_BalanceoNaves(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.InsertaSolicitudCambios_BalanceoNaves(vXmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function ObtenerCorreosDestinatario(ByVal NaveID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerCorreosDestinatario(NaveID)
        Return Tabla
    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Return objDA.consultaCorreosEnvioFactura(ClaveEnvio)
    End Function

    Public Function ObtenerDistribucionCliente(ByVal FCliente As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerDistribucionCliente(FCliente)
        Return Tabla
    End Function

    Public Function ActualizarConfiguracionDistribucion(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ActualizarConfiguracionDistribucion(vXmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function ObtenerListadoProgramasConcentrado(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtenerListadoProgramasConcentrado(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function PreparacionparaConcentrados(ByVal ProgramaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.PreparacionparaConcentrados(ProgramaID, NaveID)
        Return Tabla
    End Function

    Public Function GenerarConcentradosPorProgramaPorNave(ByVal ProgramaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.GenerarConcentradosPorProgramaPorNave(ProgramaID, NaveID)
        Return Tabla
    End Function

    Public Function CambiaEstatusBalanceo(ByVal idbalanceo As Integer, ByVal cambiosRealizados As Integer)
        Dim obj As New BalanceoNavesDA
        Return obj.CambiaEstatusBalanceo(idbalanceo, cambiosRealizados)
    End Function


    Public Function ObtenerNombreFechaPrograma(ByVal idPrograma As Integer) As String
        Dim obj As New BalanceoNavesDA
        Dim tblRes As New DataTable
        Dim nombredia As String
        tblRes = obj.ObtenerNombreFechaPrograma(idPrograma)
        If tblRes.Rows.Count > 0 Then
            nombredia = tblRes.Rows(0).Item("DiaNombre")
        End If
        Return nombredia
    End Function


    Public Function ReporteNecesidadParesSemanal(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ReporteNecesidadParesSemanal(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function ReporteDesgloseProyeccion(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ReporteDesgloseProyeccion(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function ReporteDistribucionEquivalencias(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ReporteDistribucionEquivalencias(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function ReporteConversionEquivalencias(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ReporteConversionEquivalencias(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function ExisteCalendarioDelAño(ByVal Anio As Integer, ByVal accion As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ExisteCalendarioDelAño(Anio, accion)
        Return Tabla
    End Function

    Public Function VerificarExisteBalanceoSinGuardar(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.VerificarExisteBalanceoSinGuardar(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function MovimientoParesSimulador(ByVal vxmlCeldasModificadas As String) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.MovimientoParesSimulador(vxmlCeldasModificadas)
        Return Tabla
    End Function

    Public Function ObtieneDatosPreLoteo(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.ObtieneDatosPreLoteo(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function EjecutarProcesoDeAlgoritmos(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.EjecutarProcesoDeAlgoritmos(NaveID, Semana, Año)
        Return Tabla
    End Function

    Public Function HabilitarProgramasSICY(ByVal SemanaInicio As Integer, ByVal SemanaFin As Integer, ByVal Año As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.HabilitarProgramasSICY(SemanaInicio, SemanaFin, Año)
        Return Tabla
    End Function

    Public Function GeneracionParesLoteo(ByVal ProgramaID As Integer, ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal Session As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.GeneracionParesLoteo(ProgramaID, NaveID, Semana, Año, Session)
        Return Tabla
    End Function

    Public Function EliminarConcentrados(ByVal CN As Integer, ByVal ProgramaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objDA As New BalanceoNavesDA
        Dim Tabla As New DataTable
        Tabla = objDA.EliminarConcentrados(CN, ProgramaID, NaveID)
        Return Tabla
    End Function

    Public Sub CerrarSesionUsuarioSimulador(ByVal SesionID As Integer)
        Dim objDA As New BalanceoNavesDA
        objDA.CerrarSesionUsuarioSimulador(SesionID)
    End Sub

End Class
