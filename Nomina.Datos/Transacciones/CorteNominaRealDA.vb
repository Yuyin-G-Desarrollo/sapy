Imports System.Data.SqlClient

Public Class CorteNominaRealDA

    Public Sub GuardarCorteNomina(ByVal nomina As Entidades.CorteNominaReal)
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "conr_colaboradorid"
        parametro.Value = nomina.Pcolaborador.PColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_periodonominaid"
        parametro.Value = nomina.Pcobranza.PsemanaNominaId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_salariodiario"
        parametro.Value = nomina.PNomina.PSalarioDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_diaslaborados"
        parametro.Value = nomina.PNomina.PDiasLaborados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_salariosemanal"
        parametro.Value = nomina.PNomina.PSalarioSemanal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cont_totalpercepciones"
        parametro.Value = nomina.PPercepciones.PTotalPercepciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cont_totaldeducciones"
        parametro.Value = nomina.PDeducciones.PTotalDeducciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cont_totalentregar"
        parametro.Value = nomina.PTotalEntregar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "cont_ausentismos"
        parametro.Value = nomina.pAusentismos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_TipoPago"
        parametro.Value = nomina.PTipoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_TipoSueldo"
        parametro.Value = nomina.PTipoSueldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_incapacidad"
        parametro.Value = nomina.PIncapacidad
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "conr_usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Alta_CorteNomina", listaParametros)

    End Sub


    Public Sub CambiarSemanaNomina(ByVal nomina As Entidades.CorteNominaReal)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "NaveId"
        parametro.Value = nomina.PNave.PNaveId
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_CambiarSemanaActiva", listaParametros)

    End Sub

    Public Sub LiquidarGratificaciones(ByVal Gratificaciones As Entidades.CalcularNominaReal)
        Dim Operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "idGratificacion"
        parametro.Value = Gratificaciones.PIdGratificacion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = Gratificaciones.PEstatus
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "IdSemanaNomina"
        parametro.Value = Gratificaciones.PSemanaNominaID
        listaParametros.Add(parametro)


        Operaciones.EjecutarSentenciaSP("Nomina.SP_Actualizar_Gratificaciones", listaParametros)
    End Sub

    Public Function obtenerDescripcionGratificaciones(ByVal colaboradorID As String, ByVal periodonomina As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " select a.soin_colaboradorid,a.soin_monto,UPPER(b.moin_nombre) + ISNULL(UPPER(', '+b2.moin_nombre),'') +isnull(UPPER(', '+b3.moin_nombre),'') as 'descripcion' from Nomina.SolicitudIncentivos as a "
        consulta += " left join Nomina.MotivosIncentivos as b on a.soin_motivoincentivoid=b.moin_motivoincentivoid"
        consulta += " left join nomina.MotivosIncentivos as b2 on a.soin_motivoincentivoid2=b2.moin_motivoincentivoid"
        consulta += " left join nomina.MotivosIncentivos as b3 on a.soin_motivoincentivoid3=b3.moin_motivoincentivoid"
        consulta += " where soin_periodonominapagado = " + periodonomina.ToString
        consulta += " and a.soin_colaboradorid=" + colaboradorID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerNaveIDsicy(ByVal naveID As Integer) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = ""
        consulta += " SELECT nave_navesicyid FROM Framework.Naves "
        consulta += " where nave_naveid=" + naveID.ToString
        Return operaciones.EjecutaConsulta(consulta)
    End Function

    Public Function ObtenerDatosCorreos(Nave As Entidades.Naves, Accion As Integer, Optional NaveDestinoID As Integer = 0) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim dt As DataTable
        Try
            Dim parametro As New SqlParameter
            parametro.ParameterName = "@naveCierraID"
            parametro.Value = Nave.PNaveId
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@Accion"
            parametro.Value = Accion
            listaParametros.Add(parametro)

            parametro = New SqlParameter
            parametro.ParameterName = "@NaveDestino"
            parametro.Value = NaveDestinoID
            listaParametros.Add(parametro)

            dt = operaciones.EjecutarConsultaSP("Contabilidad.SP_NF_CambioPatron_CorreoAltasIMSS", listaParametros)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub GuardarReporteGeneralDeducciones(ByVal IdPeriodo As Integer)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "IdPeriodo"
        parametro.Value = IdPeriodo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("CajaAhorro.SP_InsertaPeriodoReporteDeducciones", listaParametros)

    End Sub

    Public Sub GuardarReportePrestamos(ByVal IdPeriodo As Integer)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "PeriodoId"
        parametro.Value = IdPeriodo
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_Prestamos_InsertaReportePrestamosIntereses", listaParametros)

    End Sub

    Public Function GuardarNominaReal(ByVal nominaColaborador As Entidades.CierreNominaReal) As DataTable
        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "noreal_colaboradorid"
        parametro.Value = nominaColaborador.PcolaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_periodonominaid"
        parametro.Value = nominaColaborador.PperiodoNomina
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_salariodiario"
        parametro.Value = nominaColaborador.PsalarioDiario
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_salariosemanal"
        parametro.Value = nominaColaborador.PsalarioSemanal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_puntualidadasistencia"
        parametro.Value = nominaColaborador.PpuntualidadAsistencia
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_gratificaciones"
        parametro.Value = nominaColaborador.Pgratificaciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_gratificacioncumple"
        parametro.Value = nominaColaborador.PgratificacionCumple
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_montoinfonavit"
        parametro.Value = nominaColaborador.PmontoInfonavit
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_montoimss"
        parametro.Value = nominaColaborador.PmontoIMSS
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_montoisr"
        parametro.Value = nominaColaborador.PmontoISR
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_diaslaborados"
        parametro.Value = nominaColaborador.PdiasLaborados
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_faltas"
        parametro.Value = nominaColaborador.Pfaltas
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_incapacidad"
        parametro.Value = nominaColaborador.PIncapacidad
        listaParametros.Add(parametro)
        
        parametro = New SqlParameter
        parametro.ParameterName = "noreal_montoausentismos"
        parametro.Value = nominaColaborador.PmontoAustentismos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_pagototalprestamos"
        parametro.Value = nominaColaborador.PpagoPrestamos
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_cajadeahorro"
        parametro.Value = nominaColaborador.PcajaAhorro
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_otrasdeducciones"
        parametro.Value = nominaColaborador.PotrasDeducciones
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_totalpagado"
        parametro.Value = nominaColaborador.PtotalPagado
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_idfiniquito"
        parametro.Value = nominaColaborador.PfiniquitoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_tipopago"
        parametro.Value = nominaColaborador.PtipoPago
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_tiposueldo"
        parametro.Value = nominaColaborador.PtipoSueldo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "noreal_usuariocreo"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operaciones.EjecutarConsultaSP("Nomina.SP_Alta_CorteNominaReal", listaParametros)
    End Function

    Public Sub GuardarBitacoraError(ByVal colaboradorId As Integer, ByVal IdPeriodo As Integer, ByVal Proceso As String, ByVal mensajeError As String)

        Dim operaciones As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)

        Dim parametro As New SqlParameter
        parametro.ParameterName = "ColaboradorId"
        parametro.Value = IdPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoId"
        parametro.Value = IdPeriodo
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Proceso"
        parametro.Value = Proceso
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "MensajeError"
        parametro.Value = mensajeError
        listaParametros.Add(parametro)

        operaciones.EjecutarSentenciaSP("Nomina.SP_InsertaBitacoraError", listaParametros)

    End Sub

End Class
