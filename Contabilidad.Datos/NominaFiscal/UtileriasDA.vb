Imports System.Data.SqlClient
Imports Persistencia
Public Class UtileriasDA
    Public Function consultarPatronEmpresa() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ConsultarPatronEmpresa", listaParametros)
    End Function

    Public Function consultarPatronEmpresaPorAnio(ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultarPatronEmpresaPorAnio", listaParametros)
    End Function

    Public Function consultarPatronEmpresaComisiones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ConsultarPatronEmpresaComisiones", listaParametros)
    End Function

    Public Function validarPerfilContabilidad() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ValidarPerfilContabilidad", listaParametros)
    End Function

    Public Function consultarColaboradoresAsegurados(ByVal patronId As Integer, ByVal naveId As Integer, ByVal nombre As String, ByVal externo As Boolean, ByVal filtrarActivos As Boolean) As DataTable
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
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "externo"
        parametro.Value = externo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "filtrarActivos"
        parametro.Value = filtrarActivos
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ConsultarColaboradoresAsegurados", listaParametros)
    End Function

    Public Function consultaPuestosFiscales(ByVal idPatron As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = idPatron
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaPuestosFiscales", listaParametros)
    End Function

    Public Function consultaTipoTrabajador(ByVal idPatron As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim parametro As New SqlParameter
        Dim listap As New List(Of SqlParameter)

        parametro.ParameterName = "patronid"
        parametro.Value = idPatron
        listap.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaTipoColaborador", listap)
        'consulta = " EXEC Contabilidad.SP_NF_ConsultaTipoColaborador"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaTipoSalario() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC Contabilidad.SP_NF_ConsultaTipoSalario"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaTipoJornada() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC Contabilidad.SP_NF_ConsultaTipoJornada"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaTipoDescuento() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC Contabilidad.SP_NF_ConsultaTipoDescuento"

        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaSalarioMinimoDF() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NF_ConsultaSalarioMinimoDF"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaSalarioMinimoUMI() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NF_ConsultaSalarioMinimoUMI"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaSalarioMinimo() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NF_ConsultaSalarioMinimo"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaUMA() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NF_ConsultaUMA"
        Return operacion.EjecutaConsulta(consulta)
    End Function
    Public Function consultaFactorIMSS() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NF_ConsultaFactorIMSS"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultaPorcentajePremios(ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaPorcentajePremios", listaParametros)
    End Function

    Public Function consultaTarifa(ByVal sueldo As Double, ByVal opcTipo As Int16) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "sueldo"
        parametro.Value = sueldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcTipo"
        parametro.Value = opcTipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaTarifa", listaParametros)
    End Function

    Public Function consultaSubsidioEmpleo(ByVal sueldo As Double, ByVal opcTipo As Int16) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "sueldo"
        parametro.Value = sueldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcTipo"
        parametro.Value = opcTipo
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaSubsidioEmpleo", listaParametros)
    End Function

    Public Function consultaPuestosReales(ByVal idPuestoFiscal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoFiscal"
        parametro.Value = idPuestoFiscal
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaPuestosReales", listaParametros)
    End Function

    Public Function consultaSalarioDiarioPorPuesto(ByVal idPuestoReal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "idPuestoReal"
        parametro.Value = idPuestoReal
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaSalarioDiario_PorPuesto", listaParametros)
    End Function

    Public Function existePeriodoNomina(ByVal patronId As Integer, ByVal opcOperacion As Int16, ByVal fecha As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcOperacion"
        parametro.Value = opcOperacion
        listaParametros.Add(parametro)

        If fecha <> "" Then
            parametro = New SqlParameter
            parametro.ParameterName = "fecha"
            parametro.Value = fecha
            listaParametros.Add(parametro)
        End If

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ExistePeriodoNomina", listaParametros)
    End Function

    Public Function existeConfiguracionVacaciones(ByVal patronId As Integer, ByVal fechaMovimiento As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaMovimiento"
        parametro.Value = fechaMovimiento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ExisteConfiguracionVacaciones", listaParametros)
    End Function

    Public Function consultaPatronPorNave(ByVal idUsuario As Int32, ByVal idNave As Int32) As DataTable
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_ConsultarPatronPorNave", listaParametros)
    End Function

    Public Function consultaListadoEstatus(ByVal tipoMovimiento As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "tipoMovimiento"
        parametro.Value = tipoMovimiento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaListadoEstatus_Movimientos", listaParametros)
    End Function

    Public Function ConsultaDiasCorrespondenVacaciones(ByVal FechaIngreso As Date, ByVal FechaBaja As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "FechaIngreso"
        parametro.Value = FechaIngreso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = FechaBaja
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_ConsultaDiasVacaciones]", listaParametros)

    End Function

    Public Function ObtenerPeriodoNominaID(ByVal PatronID As Integer, ByVal Fecha As Date) As Integer
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [Contabilidad].[SP_NF_ObtenerPeriodoNominaFiscal] '" + PatronID.ToString() + "', '" + Fecha.ToShortDateString() + "' "

        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function


    Public Function ConsultarPeriodosNomina(ByVal NaveID As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Nave"
        parametro.Value = NaveID
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_ConsultaPeriodoNominaFiscal]", listaParametros)
    End Function

    Public Function ConsultaDiasAguinaldo() As Integer
         Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec [Contabilidad].[SP_NF_ConsultaDiasAguinaldo] "

        Return operacion.EjecutaConsultaEscalar(consulta)
    End Function

    Public Function consultaDepartamentosFiscales(ByVal idPatron As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty
        Dim parametros As New SqlParameter
        Dim listaparametros As New List(Of SqlParameter)

        parametros.ParameterName = "patronid"
        parametros.Value = idPatron
        listaparametros.Add(parametros)

        'consulta = "EXEC [Contabilidad].[SP_NF_ConsultaDepartamentosFiscales]"
        'Return operacion.EjecutaConsulta(consulta)
        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NF_ConsultaDepartamentosFiscales", listaparametros)
    End Function

    Public Function consultaDepartamentosREales(ByVal idDeptoFiscal As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@idDeptoFiscalid"
        parametro.Value = idDeptoFiscal
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NF_ConsultaDepartamentosRealesFiscales]", listaParametros)
    End Function

    Public Function consultaUnidadMedicaFamiliar() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = " EXEC Contabilidad.SP_NF_ConsultaUnidadMedicaFamiliar "

        Return operacion.EjecutaConsulta(consulta)

    End Function

    Public Function validaCurpColaborador(ByVal idColaborador As int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = idColaborador
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].SP_NF_ValidarCURPColaboradorDatos", listaParametros)
    End Function

    Public Function validaCurpRFCAlta(ByVal aPaterno As String, ByVal aMaterno As String, ByVal nombre As String,
                                      ByVal fechaNacimiento As String, ByVal curpCapturada As String, ByVal rfcCapturado As String) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "Apaterno"
        parametro.Value = aPaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Amaterno"
        parametro.Value = aMaterno
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaNacimiento"
        parametro.Value = fechaNacimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "curp"
        parametro.Value = curpCapturada
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rfc"
        parametro.Value = rfcCapturado
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].SP_NF_ValidarCURPColaboradorAlta", listaParametros)
    End Function

    Public Function consultarTipoMovimientos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Return operacion.EjecutaConsulta("EXEC [Contabilidad].[SP_NF_BitacoraMovimientos_ConsultarTipoMovimiento]")

    End Function

    Public Function consultarPeriodosNominaxAnioDA(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_PeriodosxAnio]", listaParametros)
    End Function

    Public Function consultarPeriodosNominaxAnioAlDA(ByVal patronId As Int32, ByVal anio As Int32) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFReportes_Acumulado_PeriodosxAnioAl]", listaParametros)
    End Function

    Public Function consultaPatronPorNaveIMSS(ByVal idUsuario As Int32, ByVal idNave As Int32) As DataTable
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

        Return operacion.EjecutarConsultaSP("Contabilidad.[SP_ConsultarPatronPorNave_imss]", listaParametros)
    End Function
End Class
