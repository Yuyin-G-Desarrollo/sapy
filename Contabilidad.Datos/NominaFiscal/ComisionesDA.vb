Imports System.Data.SqlClient
Imports Persistencia
Public Class ComisionesDA
    Public Function consultarPeriodoNomina(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "patronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ObtenerPeriodosFiscales", listaParametros)
    End Function
    'Public Function obtenerPorcentajePatron(ByVal patronId As Integer) As DataTable
    '    Dim operacion As New Persistencia.OperacionesProcedimientos
    '    Dim listaParametros As New List(Of SqlParameter)
    '    Dim parametro As SqlParameter

    '    parametro = New SqlParameter
    '    parametro.ParameterName = "patronId"
    '    parametro.Value = patronId
    '    listaParametros.Add(parametro)

    '    Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ObtenerPorcentajePatron", listaParametros)
    'End Function

    '
    Public Function obtenerMaximoComision(ByVal colaboradorId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ObtenerMaximoComision", listaParametros)
    End Function

    Public Function consultarColaboradoresAltaComision(ByVal patronId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_MostrarColaboradoresAltaComision", listaParametros)

    End Function

    Public Function validaEstatusPeriodoNominaFiscal(ByVal periodoid As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Dim dtResultado As DataTable
        Dim blnCerrado As Boolean = False

        parametro = New SqlParameter
        parametro.ParameterName = "periodoId"
        parametro.Value = periodoid
        listaParametros.Add(parametro)

        dtResultado = operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ObtenerEstatusPeriodoFiscal", listaParametros)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            If dtResultado.Rows(0).Item(0) = 115 Then
                blnCerrado = True
            End If
        End If

        Return blnCerrado
    End Function

    Public Function guardarComisiones(ByVal comision As Entidades.ComisionMensual) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametro As New List(Of SqlParameter)

        parametro.ParameterName = "comisionId"
        parametro.Value = comision.PComisionId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idColaborador"
        parametro.Value = comision.Pcolaboradorid
        listaParametro.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "sdicolaborardor"
        'parametro.Value = comision.PSDIColaborador
        'listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "patronid"
        parametro.Value = comision.PPatronId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "idPeriodo"
        parametro.Value = comision.PPeriodoId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "montocomision"
        parametro.Value = comision.PMontoComision
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "mescomision"
        parametro.Value = comision.PMesComision
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "aniocomision"
        parametro.Value = comision.PAnioComision
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariocreo"
        parametro.Value = comision.PUsuarioCreo
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifica"
        parametro.Value = comision.PUsuarioModifica
        listaParametro.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "maxcolaborador"
        'parametro.Value = comision.PMaxColaborador
        'listaParametro.Add(parametro)

        'parametro = New SqlParameter
        'parametro.ParameterName = "maxpatron"
        'parametro.Value = comision.PMaxPatron
        'listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_InsertaModificaRegistroComision", listaParametro)
    End Function

    Public Function consultarComisionesMensuales(ByVal patronId As Integer, ByVal periodoId As Integer, ByVal rango As Boolean, ByVal fechaini As Date, ByVal fechafin As Date, ByVal colaboradoresid As String, ByVal estatus As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "PatronId"
        parametro.Value = patronId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "PeriodoId"
        parametro.Value = periodoId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "RangoFechas"
        parametro.Value = rango
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaInicial"
        parametro.Value = fechaini
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "FechaFinal"
        parametro.Value = fechafin
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Colaboradores"
        parametro.Value = colaboradoresid
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "Estatus"
        parametro.Value = estatus
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ConsultarComisionesMensuales", listaParametros)

    End Function

    Public Function obtenerComisionModificar(ByVal comisionId As Integer) As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter

        parametro = New SqlParameter
        parametro.ParameterName = "comisionId"
        parametro.Value = comisionId
        listaParametros.Add(parametro)

        Return operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ObtenerComisionModificar", listaParametros)
    End Function

    Public Function validaExisteComision(ByVal colaboradorId As Integer, ByVal mes As Integer, ByVal anio As Integer) As Boolean
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim listaParametros As New List(Of SqlParameter)
        Dim parametro As SqlParameter
        Dim dtResultado As DataTable
        Dim blnExiste As Boolean = False

        parametro = New SqlParameter
        parametro.ParameterName = "colaboradorId"
        parametro.Value = colaboradorId
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "mesComision"
        parametro.Value = mes
        listaParametros.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "anioComision"
        parametro.Value = anio
        listaParametros.Add(parametro)

        dtResultado = operacion.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_ValidaExisteComision", listaParametros)

        If Not dtResultado Is Nothing AndAlso dtResultado.Rows.Count > 0 Then
            blnExiste = dtResultado.Rows(0).Item(0)
        End If

        Return blnExiste
    End Function

    Public Function obtenerEstatusComisiones() As DataTable
        Dim operacion As New Persistencia.OperacionesProcedimientos
        Dim consulta As String = String.Empty

        consulta = "EXEC Contabilidad.SP_NFComisiones_ObtenerListaEstatus"
        Return operacion.EjecutaConsulta(consulta)
    End Function

    Public Function cancelarComisiones(ByVal usuarioId As Integer, ByVal usuarioCancela As Integer) As DataTable
        Dim persistencia As New Persistencia.OperacionesProcedimientos
        Dim parametro As New SqlParameter
        Dim listaParametro As New List(Of SqlParameter)

        parametro.ParameterName = "comisionId"
        parametro.Value = usuarioId
        listaParametro.Add(parametro)

        parametro = New SqlParameter
        parametro.ParameterName = "usuariomodifica"
        parametro.Value = usuarioCancela
        listaParametro.Add(parametro)

        Return persistencia.EjecutarConsultaSP("Contabilidad.SP_NFComisiones_CancelarComision", listaParametro)
    End Function

End Class
