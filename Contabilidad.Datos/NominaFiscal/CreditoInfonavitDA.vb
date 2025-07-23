Imports System.Data.SqlClient
Imports Persistencia
Public Class CreditoInfonavitDA
    Public Function obtenerEstatusCreditoInfonavit() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NFCreditoInfonavit_ObtenerListaEstatus"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function consultarListaMovimientosCreditoInfonavit(ByVal patronId As Integer, ByVal estatusId As Integer, ByVal naveId As Integer, ByVal nombre As String,
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultarListaMovimientos", listaParametros)
    End Function

    Public Function obtenerListaTipoMovimientos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NFCreditoInfonavit_ObtenerListaTipoMovimientos"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerListaTipoDescuentos() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NFCreditoInfonavit_ObtenerListaTipoDescuentos"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerColaboradorCreditoInfonavit(ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ObtenerColaborador", listaParametros)
    End Function

    Public Function obtenerFechaBimestre() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "exec Contabilidad.SP_NFCreditoInfonavit_ObtenerFechaBimestre"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerFechaBimestreFecha(ByVal fechaMov As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "fecha"
        parametro.Value = fechaMov
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ObtenerFechaBimestreMovimiento", listaParametros)
    End Function

    Public Function obtenerDiasSemanaPorTranscurrir(ByVal patronId As Integer, ByVal fechaMovimiento As Date) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechaMovimiento"
        parametro.Value = fechaMovimiento.ToShortDateString
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ObtenerDiasSemanaPorTranscurrir", listaParametros)
    End Function

    Public Function validarColaboradorMovimiento(ByVal colaboradorId As Integer, ByVal descuentoSemanal As Double, ByVal creditoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentoSemanal"
        parametro.Value = descuentoSemanal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "creditoId"
        parametro.Value = creditoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ValidarColaboradorMovimiento", listaParametros)
    End Function

    Public Function altaMovimientoCreditoInfonavit(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = credInfonavit.CIColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = credInfonavit.CIPatronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroCredito"
        parametro.Value = credInfonavit.CINumerocredito
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "movimientoinfonavitid"
        parametro.Value = credInfonavit.CIMovimientoinfonavitid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipodescuentoid"
        parametro.Value = credInfonavit.CITipodescuentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "valordescuento"
        parametro.Value = credInfonavit.CIValordescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioBase"
        parametro.Value = credInfonavit.CISalarioBase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioBimestral"
        parametro.Value = credInfonavit.CISalarioBimestral
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importeretencionmensual"
        parametro.Value = credInfonavit.CIImporteretencionmensual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioMinimoDF"
        parametro.Value = credInfonavit.CISalarioMinimoDF
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retencionMensual"
        parametro.Value = credInfonavit.CIRetencionMensual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importeretencionbimestral"
        parametro.Value = credInfonavit.CIImporteretencionbimestral
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importeretenerbimestral"
        parametro.Value = credInfonavit.CIImporteretenerbimestral
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "seguroVivienda"
        parametro.Value = credInfonavit.CISeguroVivienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retenciondiaria"
        parametro.Value = credInfonavit.CIRetenciondiaria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retencionsemanalfiscal"
        parametro.Value = credInfonavit.CIRetencionsemanalfiscal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "semanasdescontaranual"
        parametro.Value = credInfonavit.CISemanasdescontaranual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numSemanaDescontar"
        parametro.Value = credInfonavit.CINumSemDescontar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentosemanal"
        parametro.Value = credInfonavit.CIDescuentosemanal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fecharecepcion"
        parametro.Value = credInfonavit.CIFecharecepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamovimiento"
        parametro.Value = credInfonavit.CIFechamovimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "aplicatabladisminucion"
        parametro.Value = credInfonavit.CIAplicatabladisminucion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaarchivoretencion"
        parametro.Value = credInfonavit.CIRutaarchivoretencion
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
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_AltaMovimiento", listaParametros)
    End Function

    Public Function consultarMovimientoCreditoInfonavit(ByVal creditoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "creditoId"
        parametro.Value = creditoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultarMovimiento", listaParametros)
    End Function

    Public Function validarEstatus(ByVal creditoId As Integer, ByVal opcEstatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "creditoId"
        parametro.Value = creditoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcEstatus"
        parametro.Value = opcEstatus
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ValidarEstatus", listaParametros)
    End Function

    Public Function editarMovimientoCreditoInfonavit(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "CreditoId"
        parametro.Value = credInfonavit.CICreditoInfonavitId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = credInfonavit.CIColaboradorid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = credInfonavit.CIPatronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numeroCredito"
        parametro.Value = credInfonavit.CINumerocredito
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "movimientoinfonavitid"
        parametro.Value = credInfonavit.CIMovimientoinfonavitid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "tipodescuentoid"
        parametro.Value = credInfonavit.CITipodescuentoid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "valordescuento"
        parametro.Value = credInfonavit.CIValordescuento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioBase"
        parametro.Value = credInfonavit.CISalarioBase
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioBimestral"
        parametro.Value = credInfonavit.CISalarioBimestral
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importeretencionmensual"
        parametro.Value = credInfonavit.CIImporteretencionmensual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "salarioMinimoDF"
        parametro.Value = credInfonavit.CISalarioMinimoDF
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retencionMensual"
        parametro.Value = credInfonavit.CIRetencionMensual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importeretencionbimestral"
        parametro.Value = credInfonavit.CIImporteretencionbimestral
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "importeretenerbimestral"
        parametro.Value = credInfonavit.CIImporteretenerbimestral
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "seguroVivienda"
        parametro.Value = credInfonavit.CISeguroVivienda
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retenciondiaria"
        parametro.Value = credInfonavit.CIRetenciondiaria
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "retencionsemanalfiscal"
        parametro.Value = credInfonavit.CIRetencionsemanalfiscal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "semanasdescontaranual"
        parametro.Value = credInfonavit.CISemanasdescontaranual
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "numSemanaDescontar"
        parametro.Value = credInfonavit.CINumSemDescontar
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "descuentosemanal"
        parametro.Value = credInfonavit.CIDescuentosemanal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fecharecepcion"
        parametro.Value = credInfonavit.CIFecharecepcion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "fechamovimiento"
        parametro.Value = credInfonavit.CIFechamovimiento
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "aplicatabladisminucion"
        parametro.Value = credInfonavit.CIAplicatabladisminucion
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "rutaarchivoretencion"
        parametro.Value = credInfonavit.CIRutaarchivoretencion
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
        parametro.ParameterName = "usuarioid"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_EditarMovimiento", listaParametros)
    End Function

    Public Function consultarInformacionSUA(ByVal creditoIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "creditoIds"
        parametro.Value = creditoIds
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultarInformacionSUA", listaParametros)
    End Function

    Public Function cambiarEstatus(ByVal creditoIds As String, ByVal opcEstatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "creditoIds"
        parametro.Value = creditoIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuarioId"
        parametro.Value = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "opcEstatus"
        parametro.Value = opcEstatus
        listaParametros.Add(parametro)


        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_CambiarEstatus", listaParametros)
    End Function

    Public Function aplicarMovimientoCreditoInfonavit(ByVal creditoId As Integer, ByVal carpeta As String, ByVal archivo As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "creditoId"
        parametro.Value = creditoId
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_AplicarMovimiento", listaParametros)
    End Function

    Public Function consultaDatosCorreo(ByVal creditoId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "creditoId"
        parametro.Value = creditoId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultaDatosCorreo", listaParametros)
    End Function

    Public Function consultarCreditoColaborador(ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultarCreditoColaborador", listaParametros)
    End Function

    Public Function consultarValidacionesCredito(ByVal colaboradorId As Integer, ByVal patronId As Integer, ByVal numeroCredito As String, ByVal tipoMovimiento As Integer, ByVal valorDescuento As Double, ByVal tipoDescuento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter = Nothing

        parametro = New SqlParameter("@colaboradorId", colaboradorId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@patronId", patronId)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@numCredito", numeroCredito)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoMovimiento", tipoMovimiento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@valorDescuento", valorDescuento)
        listaParametros.Add(parametro)

        parametro = New SqlParameter("@tipoDescuentoId", tipoDescuento)
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ConsultarValidacionesMovimiento]", listaParametros)
    End Function

    Public Function consultarListaMovimientosNoDescontados(ByVal patronId As Integer, ByVal nombre As String, ByVal periodo As Boolean, ByVal fechaInicio As String, ByVal fechaFin As String) As DataTable
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

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultarListaMovimientosNoDescontados", listaParametros)
    End Function

    Public Function obtenerMontoMinimo(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ObtenerMontoMinimo", listaParametros)
    End Function

    Public Function consultarListaModificacionDescuento(ByVal naveId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "naveId"
        parametro.Value = naveId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFCreditoInfonavit_ConsultarListaModificacionDescuento", listaParametros)
    End Function

    Public Function obtenerTiposMovimiento() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC [Contabilidad].[SP_NFCreditoInfonavit_ConsultaTiposMovtos]"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function obtenerAcumuladoMovtosInfonavit(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer, ByVal colaboradorIds As String, ByVal tipomovimiento As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periododel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorIds"
        parametro.Value = colaboradorIds
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@tipomovimiento"
        parametro.Value = tipomovimiento
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ConsultaAcumuladoMovtos]", listaParametros)
    End Function

    Public Function obtenerSemanasReporteDetalle(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periododel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ConsultaDetalleObtenerSemanas]", listaParametros)
    End Function

    Public Function obtenerDetalleMovtosInfonavit(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer, ByVal anio As Integer, ByVal colaboradorIds As String) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periododel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoal
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@anio"
        parametro.Value = anio
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@colaboradorIds"
        parametro.Value = colaboradorIds
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ConsultaDetalleMovtos]", listaParametros)
    End Function

    Public Function obtenerEncabezadoRepAcumulado(ByVal patronId As Integer, ByVal periododel As Integer, ByVal periodoal As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "@patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periododel"
        parametro.Value = periododel
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "@periodoal"
        parametro.Value = periodoal
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_EncabezadoRepAcumulado]", listaParametros)
    End Function

    Public Function obtenerMontoDiferencia(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("[Contabilidad].[SP_NFCreditoInfonavit_ConsultaMontoDiferencias]", listaParametros)
    End Function '

End Class
