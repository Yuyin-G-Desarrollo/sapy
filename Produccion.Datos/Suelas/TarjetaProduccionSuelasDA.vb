
Imports System.Data.SqlClient
Imports Entidades

Public Class TarjetaProduccionSuelasDA

    Public Function ObtenerProgramaPorDia(ByVal fechainicio As String, ByVal fechaFin As String, estatusTarjeta As String, naveid As String, usuarioId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicio"
        parametro.Value = fechainicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFin"
        parametro.Value = fechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@EstatusTarjeta"
        parametro.Value = estatusTarjeta
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@NaveId"
        parametro.Value = naveid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioId"
        parametro.Value = usuarioId
        listaParametros.Add(parametro)

        'Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Obtiene_TarjetaDeProduccion]", listaParametros)
        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Obtiene_TarjetaProduccion_Suelas_AGR]", listaParametros)


    End Function

    Public Function FinalizarTarjetaProduccion(ByVal TarjetaID As String, ByVal UsuarioID As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@TarjetaID"
        parametro.Value = TarjetaID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@UsuarioID"
        parametro.Value = UsuarioID
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ActualizaEstatus_TarjetaProduccionSuela]", listaparametros)

    End Function

    Public Function ActualizarTarjetaPrioridadMaquina(ByVal pXmlCeldas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XMLCeldas"
        parametro.Value = pXmlCeldas
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ActualizaPrioridadMaquina_TarjetaProduccionSuela]", listaparametros)

    End Function
    Public Function ObtenerIdNavePorColaborador(ByVal colaboradorid As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@colaboradorid"
        parametro.Value = colaboradorid
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_ObtenerNave_PorColaborador]", listaparametros)

    End Function
    Public Function ConsultaAvanceProduccionSuelas(objEntidad As AvanceProduccionSuelas) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@FechaInicioAvance"
        parametro.Value = objEntidad.AP_FechaAvanceInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinAvance"
        parametro.Value = objEntidad.AP_FechaAvanceFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaInicioPrograma"
        parametro.Value = objEntidad.AP_FechaProgramaInicio
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FechaFinPrograma"
        parametro.Value = objEntidad.AP_FechaProgramaFin
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Maquina"
        parametro.Value = objEntidad.AP_MaquinasID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Operador"
        parametro.Value = objEntidad.AP_OperadoresID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Suela"
        parametro.Value = objEntidad.AP_SuelasID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Nave"
        parametro.Value = objEntidad.AP_NavesID
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@FoliosTarjetas"
        parametro.Value = objEntidad.AP_FolioTarjetas
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoReporte"
        parametro.Value = objEntidad.AP_TipoReporte
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@TipoConsulta"
        parametro.Value = objEntidad.AP_TipoReporteFecha
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Produccion_PantallasProduccionSuelas_ConsultaAvanceProduccion]", listaparametros)

    End Function

    Public Function ObtenerDetallesTarjetasProduccionSuelas(ByVal TarjetasId As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@TarjetasIdXml"
        parametro.Value = TarjetasId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_Obtiene_DetallesTarjetaProduccion_SuelasXml]", listaparametros)

    End Function

    Public Function ObtenerConcentradoTarjetasProduccionSuelas(ByVal FechaDe As String, ByVal FechaA As String, ByVal ProveedorSuelaId As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@ProgramaDe"
        parametro.Value = FechaDe
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProgramaA"
        parametro.Value = FechaA
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@ProveedorSuelas"
        parametro.Value = ProveedorSuelaId
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[Produccion_Suelas_ConsultarConcentradoSuelas]", listaparametros)

    End Function

    Public Function InsertarAgrupamientoTarjetaSuela(ByVal pXmlTarjetas As String, ByVal pUsuario As Integer) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XmlTarjetas"
        parametro.Value = pXmlTarjetas
        listaparametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@Usuario"
        parametro.Value = pUsuario
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_TarjetaProduccionSuela_InsertaAgrupamiento]", listaparametros)

    End Function

    Public Function DesagruparTarjetaSuela(ByVal pXmlTarjetas As String) As DataTable
        Dim objPersistencia As New Persistencia.OperacionesProcedimientos
        Dim listaparametros As New List(Of SqlParameter)
        Dim parametro As New SqlParameter

        parametro.ParameterName = "@XmlTarjetas"
        parametro.Value = pXmlTarjetas
        listaparametros.Add(parametro)

        Return objPersistencia.EjecutarConsultaSP("[Produccion].[SP_TarjetaProduccionSuela_Desagrupa]", listaparametros)

    End Function

End Class
