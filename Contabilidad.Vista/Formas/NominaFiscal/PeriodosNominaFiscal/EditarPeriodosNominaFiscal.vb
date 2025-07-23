Public Class EditarPeriodosNominaFiscal

    Public idPeriodo As Integer = 0
    Public guardado As Boolean = False
    Dim idPatron As Integer = 0

    Private Sub EditarPeriodosNominaFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim dtPeriodo As New DataTable
        dtPeriodo = objBU.consultarPeriodoEditar(idPeriodo)
        If Not dtPeriodo Is Nothing AndAlso dtPeriodo.Rows.Count > 0 Then
            idPatron = CInt(dtPeriodo.Rows(0).Item("penof_patronId").ToString)
            dtpFechaIni.Value = CDate(dtPeriodo.Rows(0).Item("penof_fechaInicial").ToString)
            dtpFechaFin.Value = CDate(dtPeriodo.Rows(0).Item("penof_fechaFinal").ToString)
            dtpFechaPago.Value = CDate(dtPeriodo.Rows(0).Item("penof_fechaPago").ToString)
            numSemana.Value = CInt(dtPeriodo.Rows(0).Item("penof_numerosemana").ToString)
            NumDiasNomina.Value = CInt(dtPeriodo.Rows(0).Item("penof_diaslaborados").ToString)
            numBimestre.Value = CInt(dtPeriodo.Rows(0).Item("penof_bimestre").ToString)
            numRetardos.Value = CInt(dtPeriodo.Rows(0).Item("penof_retardosPermitidos").ToString)
            numFaltas.Value = CInt(dtPeriodo.Rows(0).Item("penof_faltasPermitidas").ToString)
            numFaltasSemana.Value = CInt(dtPeriodo.Rows(0).Item("penof_diasFaltasCompletas").ToString)

        Else
            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = "Ocurrió un error al cargar los datos del periodo."
            mensajeError.ShowDialog()

        End If

    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim mensajeAdv As New Tools.AdvertenciaForm

        If dtpFechaIni.Value >= dtpFechaFin.Value Then
            mensajeAdv.mensaje = "La Fecha Final no puede ser igual o menor a la Fecha Inicial."
            mensajeAdv.ShowDialog()
        ElseIf dtpFechaPago.Value < dtpFechaFin.Value Then
            mensajeAdv.mensaje = "La Fecha de Pago no puede ser menor a la Fecha Final."
            mensajeAdv.ShowDialog()
        Else

            If objBU.VerificaPeriodo(idPatron, dtpFechaIni.Value, dtpFechaFin.Value, idPeriodo) = False Then

                Dim objPeriodo As New Entidades.PeriodoNominaFiscal
                Dim mensaje As String = String.Empty

                With objPeriodo
                    .PIdPeriodo = idPeriodo
                    .PIdPatron = idPatron
                    .PFechaIni = dtpFechaIni.Value
                    .PFechaFin = dtpFechaFin.Value
                    .PNumSemana = numSemana.Value
                    .PFechaPago = dtpFechaPago.Value
                    .PRetardos = numRetardos.Value
                    .PFaltas = numFaltas.Value
                    .PFAltasSem = numFaltasSemana.Value
                    .PDiasNomina=NumDiasNomina.Value
                    .PBimestre = numBimestre.Value
                End With

                mensaje = objBU.AltaEdicionPeriodo(objPeriodo)
                If mensaje = "EXITO" Then
                    Dim mensajeExito As New Tools.ExitoForm
                    mensajeExito.mensaje = "Se modificó correctamente la información del periodo."
                    mensajeExito.ShowDialog()

                    guardado = True
                    Me.Close()
                Else
                    Dim mensajeError As New Tools.ErroresForm
                    mensajeError.mensaje = "Ocurrió un error al intentar modficar el periodo: " + Environment.NewLine + mensaje
                    mensajeError.ShowDialog()

                    guardado = False

                End If
            Else
                mensajeAdv.mensaje = "Ya existen periodos en el rango seleccionado."
                mensajeAdv.ShowDialog()
            End If

        End If


    End Sub

End Class