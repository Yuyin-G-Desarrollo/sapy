Imports System.Data.SqlClient
Public Class BalanceoNavesDA

    Public Function GuardarConfiguracionCalendario(ByVal xml As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@xmlRegistros", xml)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GuardarConfiguracionCalendario]", listaParametros)

    End Function

    Public Function ConsultarGrupo()
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_Etiquetas_ConsultarGrupo]", New List(Of SqlParameter))
    End Function

    Public Function GenerarSemanasDeColocacion(ByVal anio As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@año", anio)
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_ColocacionSemanal_GeneraSemanasDeColocacionNuevo]", listaparametros)

    End Function


    Public Function MostrarCalendario(ByVal anio As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@año", anio)
        ListaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_MostrarCalendarioAño]", ListaParametros)

    End Function

    Public Function ListaProgramas(ByVal grupo As String, ByVal semana As Integer, ByVal año As Integer)
        Dim objPersistencia = New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Grupo", grupo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@semana", semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@año", año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ListaProgramas]", listaParametros)

    End Function



    Public Function ConsultarNavesXGrupo(ByVal Grupo As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Grupo", Grupo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ConsultaNavesAux]", listaParametros)

    End Function

    Public Function ConsultaBalanceoXNave(ByVal idNave As Integer, ByVal semana As Integer, ByVal anio As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idNave", idNave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@semana", semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@anio", anio)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ConsultaBalanceoXNave]", listaParametros)

    End Function


    Public Function GuardarProgramasDiasHabilitados(ByVal grupo As String, ByVal semana As Integer, ByVal año As Integer, ByVal xml As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@Grupo", grupo)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@semana", semana)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@año", año)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@xmlRegistros", xml)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GuardarDiasHabilitadosProgramas]", listaParametros)
    End Function


    Public Function ConsultarBalanceo(ByVal año As Integer, ByVal semana As Integer, ByVal idnave As Integer, ByVal verDetalles As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@año", año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@semana", semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idnave", idnave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@verDetalles", verDetalles)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ConsultaBalanceoNaves_Detalles]", listaParametros)
    End Function




    Public Function SP_BalanceoNaves_GenerarSession(ByVal usuarioId As Integer, ByVal idnave As Integer, ByVal semana As Integer, ByVal año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@Usuario", usuarioId)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@NaveId", idnave)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@Semana", semana)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@Año", año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GenerarSession]", listaParametros)
    End Function

    Public Function SP_BalanceoNaves_GeneraRegistroSimulador(ByVal idnave As Integer, ByVal semana As Integer, ByVal año As Integer, ByVal sesionId As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro = New SqlParameter("@NaveID", idnave)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@Semana", semana)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@Año", año)
        listaParametros.Add(parametro)
        parametro = New SqlParameter("@Sesion", sesionId)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GeneraRegistroSimulador]", listaParametros)

    End Function

    Public Function BalanceoNaves_GeneraAlgoritmoBalanceo(ByVal sesionId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@SesionID", sesionId)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GeneraAlgoritmoBalanceo]", listaParametros)
    End Function

    Public Function BalanceoNaves_GeneraRegistroBalanceo(ByVal año As Integer, ByVal semana As Integer, ByVal idnave As Integer, ByVal XmlRegistros As String)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@año", año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@semana", semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@idnave", idnave)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@xmlRegistros", XmlRegistros)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GeneraRegistroBalanceo]", listaParametros)

    End Function

    Public Function BalanceoNaves_GeneraRegistroBalanceoDetalle(ByVal idBalanceo As Integer, ByVal usuarioId As Integer, ByVal sesionid As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@IdBalanceo", idBalanceo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@usuarioid", usuarioId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@sesionId", sesionid)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GeneraRegistroBalanceoDetalle]", listaParametros)

    End Function

    Public Function ObtenerInfoPlanAutorizado(ByVal Grupo As String, ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer,
                                            ByVal FCliente As String, ByVal FPedidoSAY As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim ListaParametros As New List(Of SqlParameter)
        Dim Parametro As New SqlParameter

        Parametro = New SqlParameter("@Grupo", Grupo)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@NaveID", NaveID)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@Semana", Semana)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@Año", Año)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@FCliente", FCliente)
        ListaParametros.Add(Parametro)

        Parametro = New SqlParameter("@FPedidoSAY", FPedidoSAY)
        ListaParametros.Add(Parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_Consulta_AsignaPrioridadPedido]", ListaParametros)
    End Function


    Public Function ActualizarCambiosPrioridad(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim ObjPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vxmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return ObjPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizarCambiosPrioridad]", listaParametros)

    End Function

    Public Function ObtenerListadoProgramas() As DataTable
        Dim objPersitencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersitencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtenerListadoProgramas]", listaParametros)

    End Function

    Public Function ObtieneClientesBalanceoSemanal(ByVal Grupo As String, ByVal NaveID As Integer, ByVal ProgramaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Grupo", Grupo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProgramaID", ProgramaID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtieneClientes_ConfConcentrado]", listaParametros)
    End Function

    Public Function ActualizarConfiguracionConcentrados(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizarConfiguracionConcentrados]", listaParametros)

    End Function

    Public Function ConsultarNavesAux(ByVal Grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Grupo", Grupo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ConsultaNavesAux]", listaParametros)
    End Function

    Public Function ObtenerTodosClientes(ByVal ClienteID As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ClienteID", ClienteID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ConsultaClientesTodos]", listaParametros)

    End Function

    Public Function ActualizarTodosClienteConcentrado(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizaTodosClienteConcentrado]", listaParametros)

    End Function

    Public Function CargarFamiliaPorNave(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_CargarFamiliaNave]", listaParametros)

    End Function

    Public Function ListadoParametroBalanceoNaves(ByVal tipo_busqueda As Integer, ByVal FamiliaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Parametro", tipo_busqueda)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FamiliaID", FamiliaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)


        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ListadoParametros]", listaParametros)

    End Function

    Public Function ObtenerConfiguracionTamañoLote(ByVal FColeccion As String, ByVal NaveID As Integer, ByVal FamiliaID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FColeccionID", FColeccion)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@FamiliaID", FamiliaID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtieneConfTamanioLote]", listaParametros)
    End Function

    Public Function ActualizarTamanioLote(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizaTamanioLote_Pares]", listaParametros)

    End Function

    Public Function ObtieneBalanceoNaves(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal Grupo As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Grupo", Grupo)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_AdmBalanceo_Consulta]", listaParametros)
    End Function

    Public Function ObtieneBalanceoNavesReporte(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_SolicitaCambios]", listaParametros)
    End Function

    Public Function AutorizarBalanceoNaves(ByVal vXmlCeldasModificadas As String, ByVal Accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Accion", Accion)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_CambiaEstatusAdmBalanceo]", listaParametros)
    End Function

    Public Function ObtieneMotivosSolicitudCambio() As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_MotivosSolicitudCambios]", listaParametros)
    End Function

    Public Function CargarSemanaDato(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_CargarSemanaDato]", listaParametros)
    End Function

    Public Function InsertaSolicitudCambios_BalanceoNaves(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizaSolicitudModificaciones]", listaParametros)
    End Function

    Public Function ObtenerCorreosDestinatario(ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtieneDestinatariosCorreo]", listaParametros)
    End Function

    Public Function consultaCorreosEnvioFactura(ByVal ClaveEnvio As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("ClaveEnvio", ClaveEnvio)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("Ventas.SP_FacturacionCalzado_ConsultaDatosCorreosFacturacion", listaParametros)

    End Function

    Public Function ObtenerDistribucionCliente(ByVal FCliente As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@FCliente", FCliente)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ConsultaDistribucionClientes]", listaParametros)
    End Function

    Public Function ActualizarConfiguracionDistribucion(ByVal vXmlCeldasModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vXmlCeldasModificadas", vXmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizarConfDistribucion]", listaParametros)
    End Function

    Public Function ObtenerListadoProgramasConcentrado(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtenerListadoProgramas_Concentrado]", listaParametros)
    End Function

    Public Function PreparacionparaConcentrados(ByVal ProgramaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProgramaID", ProgramaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_InfoParaGenerarConcentrados]", listaParametros)
    End Function

    Public Function GenerarConcentradosPorProgramaPorNave(ByVal ProgramaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProgramaID", ProgramaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GenerarConcentradosPorNavePorPrograma]", listaParametros)
    End Function

    Public Function CambiaEstatusBalanceo(ByVal idbalanceo As Integer, ByVal cambiosRealizados As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idBalanceo", idbalanceo)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@CambiosRealizados", cambiosRealizados)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ActualizaEstatusBalanceo]", listaParametros)
    End Function

    Public Function ObtenerNombreFechaPrograma(ByVal idPrograma As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter("@idprograma", idPrograma)
        listaParametros.Add(parametro)
        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtenerNombreFechaPrograma]", listaParametros)

    End Function

    Public Function ReporteNecesidadParesSemanal(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ReporteNecesidadParesSemanal]", listaParametros)
    End Function

    Public Function ReporteDesgloseProyeccion(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ReporteDesgloseProyeccion]", listaParametros)
    End Function

    Public Function ReporteDistribucionEquivalencias(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ReporteDistribucionEquivalencias]", listaParametros)
    End Function

    Public Function ReporteConversionEquivalencias(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ReporteConversionEquivalencias]", listaParametros)

    End Function


    Public Function ExisteCalendarioDelAño(ByVal Anio As Integer, ByVal accion As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@Año", Anio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@accion", accion)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ExisteCalendarioDelAño]", listaParametros)
    End Function


    Public Function VerificarExisteBalanceoSinGuardar(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_VerificaBalanceoGeneradoSinGuardar]", listaParametros)
    End Function

    Public Function MovimientoParesSimulador(ByVal vxmlCeldasModificadas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@vxmlCeldasModificadas", vxmlCeldasModificadas)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_MovimientoParesSimulador]", listaParametros)
    End Function


    Public Function ObtieneDatosPreLoteo(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_ObtieneDatosPreLoteo]", listaParametros)
    End Function

    Public Function EjecutarProcesoDeAlgoritmos(ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_EjecutaAlgoritmosPreLoteo]", listaParametros)
    End Function

    Public Function HabilitarProgramasSICY(ByVal SemanaInicio As Integer, ByVal SemanaFin As Integer, ByVal Año As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@SemanaInicio", SemanaInicio)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@SemanaFin", SemanaFin)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_HabilitarProgramasSICY]", listaParametros)
    End Function


    Public Function GeneracionParesLoteo(ByVal ProgramaID As Integer, ByVal NaveID As Integer, ByVal Semana As Integer, ByVal Año As Integer, ByVal Session As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@ProgramaID", ProgramaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Semana", Semana)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Año", Año)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@Session", Session)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_GeneracionDePares_LoteoPorProgramaPorNave]", listaParametros)
    End Function

    Public Function EliminarConcentrados(ByVal CN As Integer, ByVal ProgramaID As Integer, ByVal NaveID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@CN", CN)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@ProgramaID", ProgramaID)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@NaveID", NaveID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_EliminarConcentrados]", listaParametros)
    End Function

    Public Function CerrarSesionUsuarioSimulador(ByVal SesionID As Integer)
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro = New SqlParameter("@SesionID", SesionID)
        listaParametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Programacion].[SP_BalanceoNaves_EliminarSesionUsuarioSimulador]", listaParametros)
    End Function
End Class
