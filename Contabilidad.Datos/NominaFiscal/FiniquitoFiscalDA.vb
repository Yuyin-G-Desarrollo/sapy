

Imports System.Data.SqlClient
Imports Persistencia

Public Class FiniquitoFiscalDA

    Public Function ConsultarFiniquitos(ByVal NaveID As Integer, ByVal EstatusId As Integer, ByVal Nombre As String, ByVal EsFechaBaja As Boolean,
                                        ByVal FiltrarPorFechas As Boolean, ByVal FiltrarPorRangoFechas As Boolean, ByVal FechaInicio As DateTime,
                                        ByVal FechaFin As DateTime, ByVal PeriodoNopminaFiscal As Integer, ByVal EmpresaID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EstatusID"
        parametro.Value = EstatusId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Nombre"
        parametro.Value = Nombre
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EsFechaBaja"
        parametro.Value = EsFechaBaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltrarPorFechas"
        parametro.Value = FiltrarPorFechas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FiltrarPorRangoFechas"
        parametro.Value = FiltrarPorRangoFechas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicio"
        parametro.Value = FechaInicio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFin"
        parametro.Value = FechaFin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoNoiminaFiscal"
        parametro.Value = PeriodoNopminaFiscal
        listaParametros.Add(parametro)

        '@EmpresaID
        parametro = New SqlParameter
        parametro.ParameterName = "EmpresaID"
        parametro.Value = EmpresaID
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFFinquito_ConsultarListaFiniquitos]", listaParametros)

    End Function

    Public Function ObtenerInformacionColaborador(ByVal ColaboradorID As Integer, ByVal FechaBaja As Date) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = FechaBaja
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFFinquito_ConsultaInformacionColaborador]", listaParametros)


    End Function

    Public Function ObtenerInformacionEmpresa(ByVal NaveID As Integer, ByVal EmporesaID As Integer, ByVal PatronID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = NaveID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "EmpresaID"
        parametro.Value = EmporesaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PatronID"
        parametro.Value = PatronID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFFinquito_ConsultarInformacionPatron]", listaParametros)


    End Function



    Public Function ObtenerFiniquitoFiscal(ByVal FiniquitoFiscalID As Integer) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "FiniquitoFiscal"
        parametro.Value = FiniquitoFiscalID
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFFinquito_ConsultaInformacion]", listaParametros)


    End Function


    Public Function GuardarFiniquitoFiscal(ByVal Finiquito As Entidades.FiniquitoFiscal) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "SolicitudBajaID"
        parametro.Value = Finiquito.SolicitudBajaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = Finiquito.ColaboradorID
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = Finiquito.FechaBaja
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoNominaID"
        parametro.Value = Finiquito.PeriodoNomidaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SalarioMinimo"
        parametro.Value = Finiquito.SalarioMinimo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SalarioDiario"
        parametro.Value = Finiquito.InformacionColoaborador.IISalarioDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "InicioCurso"
        parametro.Value = Finiquito.FechaInicioCurso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasVacacinoesCorresponden"
        parametro.Value = Finiquito.DiasVacacionesCorresponden
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasVacaciones"
        parametro.Value = Finiquito.DiasVacacionesAño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalVacaciones"
        parametro.Value = Finiquito.TotalVacaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PrimaVacacional"
        parametro.Value = Finiquito.PrimaVacacional
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasAguinaldoCorresponden"
        parametro.Value = Finiquito.DiasAguinaldoCorresponden
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasAguinaldo"
        parametro.Value = Finiquito.DiasAguinaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalAguinaldo"
        parametro.Value = Math.Round(Finiquito.TotalAguinaldo, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalGravado"
        parametro.Value = Math.Round(Finiquito.TotalGravado, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UltimoSueldoMensual"
        parametro.Value = Math.Round(Finiquito.ISR.UltimoSueldoMensualOrdinario, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "BaseImpuesto"
        parametro.Value = Math.Round(Finiquito.ISR.BaseImpuesto, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TarifaSemana"
        parametro.Value = Finiquito.ISR.TarifaMensualID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LimiteInferior"
        parametro.Value = Math.Round(Finiquito.ISR.LimiteInferior, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ExcedenteLimiteInferior"
        parametro.Value = Math.Round(Finiquito.ISR.ExcedenteLimiteInferior, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeLimiteInferior"
        parametro.Value = Finiquito.ISR.PorcentajeLimiteInferior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoMarginal"
        parametro.Value = Math.Round(Finiquito.ISR.ImpuestoMarginal, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CuotaFija"
        parametro.Value = Finiquito.ISR.CuotaFija
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoDeterminado"
        parametro.Value = Math.Round(Finiquito.ISR.ImpuestoDeterminado, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "SubsidioEmpleo"
        parametro.Value = Math.Round(Finiquito.ISR.SubsidioEmpleo, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "RetencionUSMO"
        parametro.Value = Math.Round(Finiquito.USMO.RentencionUSMO, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoRetener"
        parametro.Value = Math.Round(Finiquito.ISR.ImpuestoRetenido, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "IndemizacionFiniquito"
        parametro.Value = Math.Round(Finiquito.IndemizacionFiniquito, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SubTotal"
        parametro.Value = Finiquito.SubTotalEntregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalEntregar"
        parametro.Value = Finiquito.NetoRecibir
        listaParametros.Add(parametro)



        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = Finiquito.UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCreacion"
        parametro.Value = Finiquito.FechaCreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PatronID"
        parametro.Value = Finiquito.PatronID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaUltimoVacaciones"
        parametro.Value = Finiquito.FechaUltimoPagoVacaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AntiguedadAños"
        parametro.Value = Finiquito.AñosLaborando
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AntiguedadMeses"
        parametro.Value = Finiquito.MesesLaborandoDelAño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasCurso"
        parametro.Value = Finiquito.DiasEnCurso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FactorAguinaldo"
        parametro.Value = Math.Round(Finiquito.FactorAguinaldo, 3)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoRetenerFavor"
        parametro.Value = Math.Round(Finiquito.ImpuestoRetenerFavor, 3)
        listaParametros.Add(parametro)

      
        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFFinquito_GuardarInformacion]", listaParametros)


    End Function



    Public Function EditarFiniquitoFiscal(ByVal Finiquito As Entidades.FiniquitoFiscal) As DataTable

        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "FinquitoFiscalID"
        parametro.Value = Finiquito.FinquitoFiscalID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ColaboradorID"
        parametro.Value = Finiquito.ColaboradorID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoNominaID"
        parametro.Value = Finiquito.PeriodoNomidaID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaBaja"
        parametro.Value = Finiquito.FechaBaja
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "SalarioMinimo"
        parametro.Value = Finiquito.SalarioMinimo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SalarioDiario"
        parametro.Value = Finiquito.InformacionColoaborador.IISalarioDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "InicioCurso"
        parametro.Value = Finiquito.FechaInicioCurso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasVacacinoesCorresponden"
        parametro.Value = Finiquito.DiasVacacionesCorresponden
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasVacaciones"
        parametro.Value = Finiquito.DiasVacacionesAño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalVacaciones"
        parametro.Value = Finiquito.TotalVacaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PrimaVacacional"
        parametro.Value = Finiquito.PrimaVacacional
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasAguinaldoCorresponden"
        parametro.Value = Finiquito.DiasAguinaldoCorresponden
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasAguinaldo"
        parametro.Value = Finiquito.DiasAguinaldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalAguinaldo"
        parametro.Value = Math.Round(Finiquito.TotalAguinaldo, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalGravado"
        parametro.Value = Math.Round(Finiquito.TotalGravado, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UltimoSueldoMensual"
        parametro.Value = Math.Round(Finiquito.ISR.UltimoSueldoMensualOrdinario, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "BaseImpuesto"
        parametro.Value = Math.Round(Finiquito.ISR.BaseImpuesto, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TarifaSemana"
        parametro.Value = Finiquito.ISR.TarifaMensualID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "LimiteInferior"
        parametro.Value = Math.Round(Finiquito.ISR.LimiteInferior, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ExcedenteLimiteInferior"
        parametro.Value = Math.Round(Finiquito.ISR.ExcedenteLimiteInferior, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PorcentajeLimiteInferior"
        parametro.Value = Finiquito.ISR.PorcentajeLimiteInferior
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoMarginal"
        parametro.Value = Math.Round(Finiquito.ISR.ImpuestoMarginal, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "CuotaFija"
        parametro.Value = Finiquito.ISR.CuotaFija
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoDeterminado"
        parametro.Value = Math.Round(Finiquito.ISR.ImpuestoDeterminado, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "SubsidioEmpleo"
        parametro.Value = Math.Round(Finiquito.ISR.SubsidioEmpleo, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "RetencionUSMO"
        parametro.Value = Math.Round(Finiquito.USMO.RentencionUSMO, 2)
        listaParametros.Add(parametro)


        parametro = New SqlParameter
        parametro.ParameterName = "ImpuestoRetener"
        parametro.Value = Math.Round(Finiquito.ISR.ImpuestoRetenido, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IndemizacionFiniquito"
        parametro.Value = Math.Round(Finiquito.IndemizacionFiniquito, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "SubTotal"
        parametro.Value = Math.Round(Finiquito.SubTotalEntregar, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "TotalEntregar"
        parametro.Value = Math.Round(Finiquito.NetoRecibir, 2)
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "UsuarioCreoID"
        parametro.Value = Finiquito.UsuarioCreoID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaCreacion"
        parametro.Value = Finiquito.FechaCreacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PatronID"
        parametro.Value = Finiquito.PatronID
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaUltimoVacaciones"
        parametro.Value = Finiquito.FechaUltimoPagoVacaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AntiguedadAños"
        parametro.Value = Finiquito.AñosLaborando
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "AntiguedadMeses"
        parametro.Value = Finiquito.MesesLaborandoDelAño
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "DiasCurso"
        parametro.Value = Finiquito.DiasEnCurso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FactorAguinaldo"
        parametro.Value = Math.Round(Finiquito.FactorAguinaldo, 3)
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFFinquito_EditarInformacion]", listaParametros)


    End Function


    Public Function consultaDatosCorreo(ByVal colaboradorId As Integer, ByVal naveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFFinquito_ConsultaDatosCorreo", listaParametros)
    End Function
End Class
