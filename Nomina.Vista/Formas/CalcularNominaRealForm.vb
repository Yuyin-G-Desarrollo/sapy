Imports Framework.Negocios
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Tools

Public Class CalcularNominaRealForm

    Dim listaNegativos As New List(Of Integer)
    Dim SemanaNominaID As Integer = Nothing
    Dim NoSemanaNomina As Integer = Nothing
    Dim ConceptoSemana As String = Nothing
    Dim EstatusSemana As String = Nothing
    Dim FechaInicio As DateTime
    Dim fechaFinal As DateTime
    Dim IdNaveSelected As Int32

    Private Sub CalcularNominaRealForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        pnlCerrarSemana.Visible = PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_REAL", "NOM_GUARDAR")
        pnlCalcular.Visible = PermisosUsuarioBU.ConsultarPermiso("NOM_CAL_REAL", "NOM_CALCULAR")

        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            txtColaborador.Visible = False
            lblcolaborador.Visible = False
            btnGuardar.Enabled = False

            If cmbNave.SelectedValue > 0 Then
                'cmbNaveDrop()
                Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        Try
            If Not IsDBNull(cmbNave.SelectedValue) Then
                Controles.ComboPeriodoSegunNaveSegunAsistencia(cmbPeriodoNomina, cmbNave.SelectedValue)
                ImprimirReporteGeneralAgrupadoToolStripMenuItem.Visible = True
                grdNomina.DataSource = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SemanaNomina() 'Revisar
        Try
            Dim objNomBU As New Nomina.Negocios.CalcularNominaRealBU
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            Dim dtSemanaNomina As DataTable
            dtSemanaNomina = objNomBU.ConsultaSemanaNominaBU(cmbNave.SelectedValue)
            SemanaNominaID = Nothing
            ConceptoSemana = Nothing
            NoSemanaNomina = Nothing

            If Not IsNothing(dtSemanaNomina) Then
                If dtSemanaNomina.Rows.Count > 0 Then
                    If dtSemanaNomina.Rows(0).Item("mensaje").ToString = "" Then
                        SemanaNominaID = CInt(dtSemanaNomina.Rows(0).Item("semanaNominaId"))
                        ConceptoSemana = dtSemanaNomina.Rows(0).Item("ConceptoSemana")
                        FechaInicio = dtSemanaNomina.Rows(0).Item("FechaInicial")
                        fechaFinal = dtSemanaNomina.Rows(0).Item("FechaFinal")
                        NoSemanaNomina = dtSemanaNomina.Rows(0).Item("NoSemanaNomina")
                        btnGuardar.Enabled = True
                        btnBuscar.Enabled = True
                    Else
                        objMensajeAdv.mensaje = dtSemanaNomina.Rows(0).Item("mensaje").ToString
                        objMensajeAdv.ShowDialog()

                        btnGuardar.Enabled = False
                        btnBuscar.Enabled = False
                        btnCalcular.Enabled = False
                    End If
                End If
            End If

        Catch ex As Exception
            Dim objMensajeErr As New Tools.ErroresForm
            objMensajeErr.mensaje = "No se pudo validar la semana de nómina. Ocurrió el siguiente error: " + Environment.NewLine + ex.ToString
            objMensajeErr.ShowDialog()

            btnGuardar.Enabled = False
            btnBuscar.Enabled = False

        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim objMensajeErr As New Tools.ErroresForm
        IdNaveSelected = cmbNave.SelectedValue
        Try
            Me.Cursor = Cursors.WaitCursor
            grdNomina.DataSource = Nothing

            If Not IsDBNull(SemanaNominaID) AndAlso SemanaNominaID > 0 Then
                consultarNominaCerrada(SemanaNominaID)
            End If
        Catch ex As Exception
            objMensajeErr.mensaje = "Ocurrió un error al intentar consultar el cierre de nómina."
            objMensajeErr.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub consultarNominaCerrada(ByVal IdPeriodo As Integer)
        If SemanaNominaID > 0 Then
            Dim dtSemana As New DataTable
            Dim ObjBU As New Nomina.Negocios.CalcularNominaRealBU
            Dim objMensajeAdv As New Tools.AdvertenciaForm

            dtSemana = ObjBU.obtenerSemanaCerradaBU(IdPeriodo)

            If Not dtSemana Is Nothing AndAlso dtSemana.Rows.Count > 0 Then

                If dtSemana.Rows(0).Item("pnom_stPeriodoNomina") = "C" Then
                    Dim dtDatos As New DataTable
                    dtDatos = ObjBU.consultarCierreNomina(SemanaNominaID, txtColaborador.Text.Trim)
                    If Not dtDatos Is Nothing AndAlso dtDatos.Rows.Count > 0 Then
                        grdNomina.DataSource = dtDatos
                        formatoGrid(1)
                        agregaSumatoriasGrid()
                    End If
                Else
                    objMensajeAdv.mensaje = "Aún no se ha cerrado el periodo de nómina."
                    objMensajeAdv.ShowDialog()
                End If
            Else
                objMensajeAdv.mensaje = "No fue posible obtener la información de la semana, favor de reportarlo a sistemas."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If grdNomina.Rows.Count > 0 Then
            Try
                Dim ObjEnvio As New EnvioDepositoNuevoForm
                Dim ContadorDepositos As Integer = 0
                Me.Cursor = Cursors.WaitCursor

                Dim Cuentas = New DataTable("Cuentas")
                With Cuentas
                    .Columns.Add("Numero")
                    .Columns.Add("Cuenta")
                    .Columns.Add("Titular")
                    .Columns.Add("Total", Type.GetType("System.Decimal"))
                End With

                For Each row As UltraGridRow In grdNomina.Rows
                    If row.Cells("TipoSueldo").Value = "DEPOSITO" Then
                        ContadorDepositos += 1

                        Cuentas.Rows.Add(
                        ContadorDepositos,
                        row.Cells("Cuenta").Value,
                        row.Cells("Colaborador").Value,
                        row.Cells("TotalEntregar").Value)
                    End If
                Next

                If cmbNave.SelectedValue <> 53 And cmbNave.SelectedValue <> 57 Then ''para la nave suelas no se realiza solicitud de caja chica

                    If GenerarSolicitudNomina() Then
                        btnGuardar.Enabled = False

                        If ContadorDepositos > 0 Then
                            With ObjEnvio
                                .ListaDepositosEfectivo = Cuentas
                                .NaveID = cmbNave.SelectedValue
                                .ShowDialog()
                                ContadorDepositos = 0
                            End With
                        End If

                        GuardarNomina()

                    End If
                ElseIf cmbNave.SelectedValue = 53 Or cmbNave.SelectedValue = 57 Then

                    ''cierre suelas
                    btnGuardar.Enabled = False
                    Dim mensajeExito As New ConfirmarForm
                    mensajeExito.mensaje = "¿ Está seguro de querer guardar la nómina ? " + vbNewLine + "No podrá hacer modificaciones" + vbNewLine + " después del guardado."

                    If mensajeExito.ShowDialog = DialogResult.OK Then

                        If ContadorDepositos > 0 Then
                            With ObjEnvio
                                .ListaDepositosEfectivo = Cuentas
                                .NaveID = cmbNave.SelectedValue
                                .ShowDialog()
                                ContadorDepositos = 0
                            End With
                        End If

                        GuardarNomina()

                    End If

                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Public Sub GuardarNomina()
        Dim naves As New Entidades.Naves
        Dim corteNomina2 As New Entidades.CorteNominaReal
        Dim ObjCorteBU As New Nomina.Negocios.CorteNominaRealBU
        Dim ObjBU As New Nomina.Negocios.DeduccionesBU

        For Each row As UltraGridRow In grdNomina.Rows
            ''Guardar Nómina Real
            Dim objCierreNomina As New Entidades.CierreNominaReal
            Dim resultado As String = ""

            If row.Cells("ColaboradorId").Value.ToString <> "" Then

                ''ACTUALIZAR PRESTAMO Y CAJA DE AHORRO
                If row.Cells("modificacaja").Value <> 0 OrElse row.Cells("modificaprestamo").Value <> 0 OrElse row.Cells("modificadeduccion").Value <> 0 Then
                    resultado = String.Empty
                    Dim modificaCaja As Boolean
                    Dim modificaPrestamo As Boolean
                    Dim modificaDeducciones As Boolean
                    Dim objMensajeAdv As New AdvertenciaForm

                    modificaCaja = row.Cells("modificacaja").Value <> 0
                    modificaPrestamo = row.Cells("modificaprestamo").Value <> 0
                    modificaDeducciones = row.Cells("modificadeduccion").Value <> 0

                    resultado = ObjBU.CambiaDeduccionesNegativos(row.Cells("ColaboradorId").Value, modificaCaja, modificaPrestamo, modificaDeducciones, SemanaNominaID)
                    If resultado <> "EXITO" Then
                        ObjCorteBU.GuardarBitacoraError(row.Cells("ColaboradorId").Value, SemanaNominaID, "Modificar Negativos", resultado)
                        objMensajeAdv.mensaje = "No fue posible modificar las deducciones."
                        objMensajeAdv.ShowDialog()
                    End If
                End If

                With objCierreNomina
                    .PcolaboradorId = row.Cells("ColaboradorId").Value
                    .PperiodoNomina = SemanaNominaID
                    .PsalarioDiario = row.Cells("SalarioDiarioReal").Value
                    .PsalarioSemanal = row.Cells("PagoBruto").Value
                    .PpuntualidadAsistencia = row.Cells("Extras").Value
                    .Pgratificaciones = Math.Round(CDbl(row.Cells("Gratificaciones").Value), 0) - Math.Round(CDbl(row.Cells("GratificacionFechaNac").Value), 0)
                    .PgratificacionCumple = row.Cells("GratificacionFechaNac").Value
                    .PmontoInfonavit = row.Cells("Infonavit").Value
                    .PmontoIMSS = row.Cells("IMSS").Value
                    .PmontoISR = row.Cells("ISR").Value
                    .PdiasLaborados = 7 - row.Cells("NumeroFaltas").Value
                    .Pfaltas = row.Cells("NumeroFaltas").Value
                    .PmontoAustentismos = row.Cells("Faltas").Value
                    .PIncapacidad = row.Cells("Incapacidad").Value
                    .PpagoPrestamos = row.Cells("Prestamo").Value
                    .PcajaAhorro = row.Cells("CajaAhorro").Value
                    .PotrasDeducciones = row.Cells("OtrasDedu").Value
                    .PtotalPagado = row.Cells("TotalEntregar").Value
                    .PfiniquitoId = row.Cells("FiniquitoId").Value
                    .PtipoPago = row.Cells("TipoSueldo").Value
                    .PtipoSueldo = row.Cells("TipoColaborador").Value
                End With

                resultado = "EXITO" 'String.Empty
                resultado = ObjCorteBU.GuardarNominaReal(objCierreNomina)

                If resultado <> "EXITO" Then
                    ObjCorteBU.GuardarBitacoraError(row.Cells("ColaboradorId").Value, SemanaNominaID, "Guardar Nómina", resultado)
                End If

            End If
        Next

        naves.PNaveId = cmbNave.SelectedValue
        corteNomina2.PNave = naves
        ObjCorteBU.CambiarSemanaNomina(corteNomina2)

        Dim EntidadNave As New Entidades.Naves
        EntidadNave = TryCast(cmbNave.SelectedItem, Entidades.Naves)
        EnviarCorreoCambioDeNave(EntidadNave)

        Dim mensajeExito As New ExitoForm
        mensajeExito.mensaje = "Se ha generado la nómina correctamente."
        mensajeExito.ShowDialog()

        ObjCorteBU.GuardarReporteGeneralDeducciones(SemanaNominaID)
        ObjCorteBU.GuardarReportePrestamos(SemanaNominaID)

        grdNomina.DataSource = Nothing
        btnCalcular.Enabled = False
        ConceptoSemana = Nothing
        cmbPeriodoNomina.SelectedIndex = 0 ''¿si? 'Revisar
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        ContextMenuStrip1.Show(btnReporte, 0, btnReporte.Height)
    End Sub

    Private Sub ImprimirReporteGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteGeneralToolStripMenuItem.Click
        imprimirReporteNomina("REPO_NOM_DEPOSITOSINFILTRO", "GENERAL")
    End Sub

    Private Sub ImprimirReporteEfectivoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteEfectivoToolStripMenuItem.Click
        imprimirReporteNomina("REPO_NOM_DEPOSITO", "EFECTIVO")
    End Sub

    Private Sub ImprimirReporteDepósitoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirReporteDepósitoToolStripMenuItem.Click
        imprimirReporteNomina("REPO_NOM_DEPOSITO", "DEPOSITO")
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub cmbNaveDrop()
        grdNomina.DataSource = Nothing
        SemanaNominaID = Nothing
        ConceptoSemana = Nothing
        SemanaNomina()
    End Sub

    Private Function obtenerInfoReportes() As DataTable
        Dim dtDatos As New DataTable

        With dtDatos
            .Columns.Add("Colaborador", Type.GetType("System.String"))
            .Columns.Add("Departamento", Type.GetType("System.String"))
            .Columns.Add("Puesto", Type.GetType("System.String"))
            .Columns.Add("NumeroFaltas", Type.GetType("System.Double"))
            .Columns.Add("PagoBruto", Type.GetType("System.Double"))
            .Columns.Add("Extras", Type.GetType("System.Double"))
            .Columns.Add("Gratificaciones", Type.GetType("System.Double"))
            .Columns.Add("Faltas", Type.GetType("System.Double"))
            .Columns.Add("IMSS", Type.GetType("System.Double"))
            .Columns.Add("ISR", Type.GetType("System.Double"))
            .Columns.Add("Infonavit", Type.GetType("System.Double"))
            .Columns.Add("Prestamo", Type.GetType("System.Double"))
            .Columns.Add("CajaAhorro", Type.GetType("System.Double"))
            .Columns.Add("OtrasDedu", Type.GetType("System.Double"))
            .Columns.Add("TotalEntregar", Type.GetType("System.Double"))
            .Columns.Add("tipoSueldo", Type.GetType("System.String"))
        End With

        For Each fila As UltraGridRow In grdNomina.Rows
            dtDatos.Rows.Add(
                fila.Cells("Colaborador").Value,
                fila.Cells("Departamento").Value,
                fila.Cells("Puesto").Value,
                fila.Cells("NumeroFaltas").Value,
                fila.Cells("PagoBruto").Value,
                fila.Cells("Extras").Value,
                fila.Cells("Gratificaciones").Value,
                fila.Cells("Faltas").Value,
                fila.Cells("IMSS").Value,
                fila.Cells("ISR").Value,
                fila.Cells("Infonavit").Value,
                fila.Cells("Prestamo").Value,
                fila.Cells("CajaAhorro").Value,
                fila.Cells("OtrasDedu").Value,
                fila.Cells("TotalEntregar").Value,
                fila.Cells("tipoSueldo").Value
            )
        Next

        Return dtDatos
    End Function

    Private Sub imprimirReporteNomina(ByVal nombreReporte As String, ByVal tipoSueldo As String)
        Try
            If cmbNave.SelectedIndex > 0 Then
                Cursor = Cursors.WaitCursor
                Dim dtDatosReporte As New DataTable
                Dim advertencia As New Tools.AdvertenciaForm
                Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                dtDatosReporte = obtenerInfoReportes()
                dtDatosReporte.TableName = "Nomina"

                If Not dtDatosReporte Is Nothing AndAlso dtDatosReporte.Columns.Count > 0 Then

                    Dim objBUReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    Dim dsDatosReporte As New DataSet("ReporteGeneralNomina")

                    dsDatosReporte.Tables.Add(dtDatosReporte)

                    EntidadReporte = objBUReporte.LeerReporteporClave(nombreReporte)
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("Usuario") = Usuario
                    reporte("tipoSueldoV") = tipoSueldo
                    reporte("ConceptoSemana") = ConceptoSemana
                    reporte("NoSemana") = "Semana " & NoSemanaNomina.ToString
                    reporte.Dictionary.Clear()

                    reporte.RegData(dsDatosReporte)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()

                Else
                    advertencia.mensaje = "No hay información para imprimir."
                    advertencia.ShowDialog()
                End If
            End If
        Catch ex As Exception
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimirRecibosDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirRecibosDeNóminaToolStripMenuItem.Click

        If grdNomina.Rows.Count > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                Dim Recibos = New DataTable("Recibos")

                With Recibos
                    .Columns.Add("IDColaborador")
                    .Columns.Add("NombreColaborador")
                    .Columns.Add("FechaDePago")
                    .Columns.Add("FechaInicioNomina")
                    .Columns.Add("FechaFinNomina")
                    .Columns.Add("PagoBruto")
                    .Columns.Add("Extras")
                    .Columns.Add("Otros")
                    .Columns.Add("Faltas")
                    .Columns.Add("Ausentismo")
                    '.Columns.Add("SeguroInfonavit")                
                    .Columns.Add("CajaAhorro")
                    .Columns.Add("PrestamosDeduccionesExtraordinarias")
                    .Columns.Add("TotalIngresos")
                    .Columns.Add("TotalDeducciones")
                    .Columns.Add("PagoNeto")
                    .Columns.Add("ISR")
                    .Columns.Add("NaveID")
                    .Columns.Add("Concepto")
                    .Columns.Add("ConsecutivoReciboEfectivo")
                    .Columns.Add("NUMRECIBO")
                    .Columns.Add("IMSS")
                    .Columns.Add("Infonavit")
                End With

                Dim consReciboNominaeEFECTIVO As Int32 = 0
                Dim consDEPOSITO As Int32 = 0
                Dim datoConsEnviar As String = ""
                Dim NUMRECIBO As String = ""
                Dim contadorEmpleados As Integer = 1


                For Each row As UltraGridRow In grdNomina.Rows 'For Each row As DataGridViewRow In grdDeducciones.Rows
                    If row.Cells("ColaboradorId").Value.ToString <> "" Then

                        If row.Cells("TipoSueldo").Value = "EFECTIVO" Then
                            consReciboNominaeEFECTIVO += 1
                            datoConsEnviar = consReciboNominaeEFECTIVO.ToString
                            NUMRECIBO = "E No. "
                        Else
                            consDEPOSITO += 1
                            datoConsEnviar = consDEPOSITO.ToString
                            NUMRECIBO = "D No. "
                        End If

                        Dim TotalIngresos As Double = 0
                        Dim TotalDeducciones As Double = 0
                        Dim PagoNeto As Double = 0
                        Dim FechaPagoCondicion As Date


                        If IdNaveSelected = 1 Or IdNaveSelected = 2 Or IdNaveSelected = 3 Or IdNaveSelected = 4 Or IdNaveSelected = 5 Or IdNaveSelected = 6 Or IdNaveSelected = 51 Or IdNaveSelected = 76 Then
                            FechaPagoCondicion = fechaFinal.AddDays(2)
                        ElseIf IdNaveSelected = 43 Or IdNaveSelected = 53 Or IdNaveSelected = 57 Or IdNaveSelected = 64 Or IdNaveSelected = 73 Or IdNaveSelected = 82 Or IdNaveSelected = 87 Or IdNaveSelected = 99 Or IdNaveSelected = 61 Then
                            FechaPagoCondicion = fechaFinal.AddDays(1)
                        Else
                            FechaPagoCondicion = fechaFinal
                        End If

                        TotalIngresos = CDbl(row.Cells("PagoBruto").Value) + CDbl(row.Cells("Extras").Value) + CDbl(row.Cells("Gratificaciones").Value)
                        TotalDeducciones = CDbl(row.Cells("Faltas").Value) + CDbl(row.Cells("IMSS").Value) + CDbl(row.Cells("Infonavit").Value) + CDbl(row.Cells("CajaAhorro").Value) + CDbl(row.Cells("Prestamo").Value) + CDbl(row.Cells("OtrasDedu").Value) + CDbl(row.Cells("ISR").Value)
                        PagoNeto = TotalIngresos - TotalDeducciones
                        Recibos.Rows.Add(
                            contadorEmpleados,
                            row.Cells("Colaborador").Value,
                            FechaPagoCondicion.ToShortDateString,
                            FechaInicio.ToShortDateString,
                            fechaFinal.ToShortDateString,
                            row.Cells("PagoBruto").Value,
                            row.Cells("Extras").Value,
                            row.Cells("Gratificaciones").Value,
                            row.Cells("NumeroFaltas").Value,' row.Cells("clmDiasTrabajados").Value,
                            row.Cells("Faltas").Value,
                            row.Cells("CajaAhorro").Value,
                            (CDbl(row.Cells("Prestamo").Value) + CDbl(row.Cells("OtrasDedu").Value)),
                            TotalIngresos,
                            TotalDeducciones,
                            PagoNeto,
                            CDbl(row.Cells("ISR").Value),
                            "",
                            row.Cells("ConceptoGratificaciones").Value,
                            datoConsEnviar,
                            NUMRECIBO,
                            CDbl(row.Cells("IMSS").Value),
                            CDbl(row.Cells("Infonavit").Value)
                        )
                        contadorEmpleados = contadorEmpleados + 1
                    End If
                Next

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_RECB_NOM_NUEVO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte("DiaFestivo") = ""
                reporte.Compile()
                reporte.RegData(Recibos)
                reporte.Show()

            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub ImprimirRecibosDiaFestivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirRecibosDiaFestivoToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim Fecha As String = String.Empty
            Dim ObjDate As New DateForm
            'Dim diaFestivo As String = ""
            With ObjDate
                .mensaje = "SELECCIONAR EL DIA A PAGAR."
                .ShowDialog()
                Fecha = .Dia
            End With

            'diaFestivo = Fecha.ToLongDateString.ToUpper.ToString

            If Fecha <> "" Then
                If grdNomina.Rows.Count > 0 Then
                    Dim Recibos = New DataTable("Recibos")
                    With Recibos
                        .Columns.Add("IDColaborador")
                        .Columns.Add("NombreColaborador")
                        .Columns.Add("FechaDePago")
                        .Columns.Add("FechaInicioNomina")
                        .Columns.Add("FechaFinNomina")
                        .Columns.Add("PagoBruto")
                        .Columns.Add("Extras")
                        .Columns.Add("Otros")
                        .Columns.Add("Faltas")
                        .Columns.Add("Ausentismo")
                        '.Columns.Add("SeguroInfonavit")                
                        .Columns.Add("CajaAhorro")
                        .Columns.Add("PrestamosDeduccionesExtraordinarias")
                        .Columns.Add("TotalIngresos")
                        .Columns.Add("TotalDeducciones")
                        .Columns.Add("PagoNeto")
                        .Columns.Add("ISR")
                        .Columns.Add("NaveID")
                        .Columns.Add("Concepto")
                        .Columns.Add("ConsecutivoReciboEfectivo")
                        .Columns.Add("NUMRECIBO")
                        .Columns.Add("IMSS")
                        .Columns.Add("Infonavit")
                    End With

                    Dim consReciboNominaeEFECTIVO As Int32 = 0
                    Dim consDEPOSITO As Int32 = 0
                    Dim datoConsEnviar As String = ""
                    Dim NUMRECIBO As String = ""
                    Dim consecutivo = 1

                    For Each row As UltraGridRow In grdNomina.Rows
                        If row.Cells("ColaboradorId").Value.ToString <> "" Then

                            If row.Cells("TipoSueldo").Value = "EFECTIVO" Then
                                consReciboNominaeEFECTIVO += 1
                                datoConsEnviar = consReciboNominaeEFECTIVO.ToString
                                NUMRECIBO = "E No. "
                            Else
                                consDEPOSITO += 1
                                datoConsEnviar = consDEPOSITO.ToString
                                NUMRECIBO = "D No. "
                            End If

                            Dim TotalIngresos As Double = 0
                            Dim TotalDeducciones As Double = 0
                            Dim PagoNeto As Double = 0
                            Dim FechaPagoCondicion As Date


                            If IdNaveSelected = 1 Or IdNaveSelected = 2 Or IdNaveSelected = 3 Or IdNaveSelected = 4 Or IdNaveSelected = 5 Or IdNaveSelected = 6 Or IdNaveSelected = 51 Or IdNaveSelected = 76 Then
                                FechaPagoCondicion = fechaFinal.AddDays(2)
                            ElseIf IdNaveSelected = 43 Or IdNaveSelected = 53 Or IdNaveSelected = 57 Or IdNaveSelected = 64 Or IdNaveSelected = 73 Or IdNaveSelected = 82 Or IdNaveSelected = 87 Or IdNaveSelected = 99 Or IdNaveSelected = 61 Then
                                FechaPagoCondicion = fechaFinal.AddDays(1)
                            Else
                                FechaPagoCondicion = fechaFinal
                            End If

                            TotalIngresos = CDbl(row.Cells("PagoBruto").Value) + CDbl(row.Cells("Extras").Value) + CDbl(row.Cells("Gratificaciones").Value)
                            TotalDeducciones = CDbl(row.Cells("Faltas").Value) + CDbl(row.Cells("IMSS").Value) + CDbl(row.Cells("Infonavit").Value) + CDbl(row.Cells("CajaAhorro").Value) + CDbl(row.Cells("Prestamo").Value) + CDbl(row.Cells("OtrasDedu").Value) + CDbl(row.Cells("ISR").Value)

                            PagoNeto = TotalIngresos - TotalDeducciones
                            Recibos.Rows.Add(
                            consecutivo,
                            row.Cells("Colaborador").Value,
                            FechaPagoCondicion.ToShortDateString,
                            FechaInicio.ToShortDateString,
                            fechaFinal.ToShortDateString,
                            CDbl(row.Cells("PagoBruto").Value),
                            CDbl(row.Cells("Extras").Value),
                            CDbl(row.Cells("Gratificaciones").Value),
                            row.Cells("NumeroFaltas").Value,
                            CDbl(row.Cells("Faltas").Value),
                            CDbl(row.Cells("CajaAhorro").Value),
                            (CDbl(row.Cells("Prestamo").Value) + CDbl(row.Cells("OtrasDedu").Value)),
                            TotalIngresos,
                            TotalDeducciones,
                            PagoNeto,
                            CDbl(row.Cells("ISR").Value),
                            "",'naveSICYID,
                            row.Cells("ConceptoGratificaciones").Value,
                            datoConsEnviar,
                            NUMRECIBO,
                            CDbl(row.Cells("IMSS").Value),
                            CDbl(row.Cells("Infonavit").Value)
                        )
                            consecutivo = consecutivo + 1
                        End If
                    Next

                    Dim OBJBU As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJBU.LeerReporteporClave("NOM_RECB_NOM_NUEVO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("DiaFestivo") = "* RECIBI PAGO DE DIA FESTIVO CORRESPONDIENTE AL " & Fecha
                    reporte.RegData(Recibos)
                    reporte.Show()


                End If
            End If

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimirSobrePorEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirSobrePorEfectivoToolStripMenuItem.Click
        Try
            If grdNomina.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Dim Recibos = New DataTable("Recibos")

                With Recibos
                    .Columns.Add("iDColaborador")
                    .Columns.Add("Colaborador")
                End With

                For Each fila As UltraGridRow In grdNomina.Rows
                    If fila.Cells("TipoSueldo").Value = "EFECTIVO" Then
                        Recibos.Rows.Add(fila.Cells("IdAnual").Value, fila.Cells("Colaborador").Value)
                    End If
                Next

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_IMP_SOBRES")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(Recibos)
                reporte.Show()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimirResumenDeNóminaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirResumenDeNóminaToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
            Dim totalNominaFiscal As Double = 0
            Dim dtRevisareporte As New DataTable
            Dim naveID As Integer = 0

            naveID = cmbNave.SelectedValue

            If naveID <> 0 Then
                dtRevisareporte = nomina.ObtieneRevisaReporte(cmbNave.SelectedValue)
            Else
                naveID = 0
            End If

            totalNominaFiscal = nomina.ConsultaTotalNominaFiscal(CInt(SemanaNominaID))


            If grdNomina.Rows.Count > 0 Then
                Dim Resumen = New DataSet("Resumen")
                Dim Deposito = New DataTable("Deposito")
                Dim Efectivo = New DataTable("Efectivo")
                Dim PagoBruto As Double = 0
                Dim Extras As Double = 0
                Dim Otros As Double = 0
                Dim Ausentismos As Double = 0
                Dim Seguro As Double = 0
                Dim Prestamos As Double = 0
                Dim CajaAhorro As Double = 0
                Dim PagoNeto As Double = 0
                Dim TotalDeducciones As Double = 0
                Dim TotalPercepciones As Double = 0

                With Deposito
                    .Columns.Add("PagoBruto")
                    .Columns.Add("Extras")
                    .Columns.Add("Otros")
                    .Columns.Add("Ausentismos")
                    .Columns.Add("Seguro")
                    .Columns.Add("Prestamos")
                    .Columns.Add("CajaAhorro")
                    .Columns.Add("PagoNeto")
                    .Columns.Add("FechaInicio")
                    .Columns.Add("FechaFin")
                    .Columns.Add("TotalPercepciones")
                    .Columns.Add("TotalDeducciones")

                End With

                For Each fila As UltraGridRow In grdNomina.Rows
                    If fila.Cells("TipoSueldo").Value = "DEPOSITO" Then
                        PagoBruto += fila.Cells("PagoBruto").Value
                        Extras += fila.Cells("Extras").Value
                        Otros += fila.Cells("Gratificaciones").Value
                        Ausentismos += fila.Cells("Faltas").Value
                        Seguro += CDbl(fila.Cells("IMSS").Value) + CDbl(fila.Cells("ISR").Value) + CDbl(fila.Cells("Infonavit").Value)
                        Prestamos += CDbl(fila.Cells("Prestamo").Value) + CDbl(fila.Cells("OtrasDedu").Value)
                        CajaAhorro += fila.Cells("CajaAhorro").Value
                        PagoNeto += fila.Cells("TotalEntregar").Value
                    End If
                Next

                TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos - Seguro
                TotalDeducciones = Prestamos + CajaAhorro
                'PagoNeto = TotalPercepciones - TotalDeducciones
                Deposito.Rows.Add(PagoBruto, Extras, Otros, Ausentismos, Seguro, Prestamos, CajaAhorro, PagoNeto, FechaInicio.ToLongDateString.ToUpper, fechaFinal.ToLongDateString.ToUpper, TotalPercepciones, TotalDeducciones)

                With Efectivo
                    .Columns.Add("PagoBruto")
                    .Columns.Add("Extras")
                    .Columns.Add("Otros")
                    .Columns.Add("Ausentismos")
                    .Columns.Add("Seguro")
                    .Columns.Add("Prestamos")
                    .Columns.Add("CajaAhorro")
                    .Columns.Add("PagoNeto")
                    .Columns.Add("FechaInicio")
                    .Columns.Add("FechaFin")
                    .Columns.Add("TotalPercepciones")
                    .Columns.Add("TotalDeducciones")

                End With

                PagoBruto = 0
                Extras = 0
                Otros = 0
                Ausentismos = 0
                Seguro = 0
                Prestamos = 0
                CajaAhorro = 0
                PagoNeto = 0
                TotalPercepciones = 0

                For Each fila As UltraGridRow In grdNomina.Rows
                    If fila.Cells("TipoSueldo").Value = "EFECTIVO" Then
                        PagoBruto += fila.Cells("PagoBruto").Value
                        Extras += fila.Cells("Extras").Value
                        Otros += fila.Cells("Gratificaciones").Value
                        Ausentismos += fila.Cells("Faltas").Value
                        Seguro += CDbl(fila.Cells("IMSS").Value) + CDbl(fila.Cells("ISR").Value) + CDbl(fila.Cells("Infonavit").Value)
                        Prestamos += CDbl(fila.Cells("Prestamo").Value) + CDbl(fila.Cells("OtrasDedu").Value)
                        CajaAhorro += fila.Cells("CajaAhorro").Value
                        PagoNeto += fila.Cells("TotalEntregar").Value
                    End If
                Next

                TotalPercepciones = PagoBruto + Extras + Otros - Ausentismos - Seguro
                TotalDeducciones = Prestamos + CajaAhorro
                'PagoNeto = TotalPercepciones - TotalDeducciones
                Efectivo.Rows.Add(PagoBruto, Extras, Otros, Ausentismos, Seguro, Prestamos, CajaAhorro, PagoNeto, FechaInicio.ToLongDateString.ToUpper, fechaFinal.ToLongDateString.ToUpper, TotalPercepciones, TotalDeducciones)
                Resumen.Tables.Add(Deposito)
                Resumen.Tables.Add(Efectivo)


                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_RES_NOM")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("Elaboro") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
                reporte("Reviso") = dtRevisareporte.Rows(0).Item("Revisa")


                'If cmbNave.SelectedValue = 43 Then
                '    reporte("Reviso") = "ALMA VILLAGRANA"
                'ElseIf cmbNave.SelectedValue = 3 Then
                '    reporte("Reviso") = "RAFAEL ORTIZ LOPEZ"
                'End If

                reporte("ChequeFiscal") = totalNominaFiscal

                reporte.RegData(Resumen)
                reporte.Show()

            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimirReporteGeneralAgrupadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirReporteGeneralAgrupadoToolStripMenuItem.Click
        Try
            Dim advertencia As New Tools.AdvertenciaForm

            If cmbNave.SelectedIndex > 0 Then
                If grdNomina.Rows.Count > 0 Then

                    Me.Cursor = Cursors.WaitCursor
                    Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
                    Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                    Dim Resumen = New DataSet("Colaboradores")
                    Dim Colaborador = New DataTable("Colaborador")
                    Dim objCelulas As New Negocios.CelulasBU
                    Dim celulasTBL As New DataTable
                    Dim celulas = New DataTable("Celulas")

                    With celulas
                        .Columns.Add("CelulasID")
                        .Columns.Add("CelulasNombre")
                    End With

                    celulasTBL = objCelulas.listaCelulasActivas()

                    For Each row As DataRow In celulasTBL.Rows
                        celulas.Rows.Add(row.Item("celu_celulaid"), row.Item("celu_nombre"))
                    Next

                    With Colaborador
                        .Columns.Add("Colaborador")
                        .Columns.Add("Puesto")
                        .Columns.Add("NumeroFaltas")
                        .Columns.Add("Pagobruto")
                        .Columns.Add("Extras")
                        .Columns.Add("Gratificaciones")
                        .Columns.Add("Faltas")
                        .Columns.Add("IMSS")
                        .Columns.Add("ISR")
                        .Columns.Add("Infonavit")
                        .Columns.Add("Prestamo")
                        .Columns.Add("CajaAhorro")
                        .Columns.Add("OtrasDedu")
                        .Columns.Add("TotalEntregar")
                        .Columns.Add("CelulaID")
                        .Columns.Add("OrdenPuesto")
                        .Columns.Add("finiquitoid")
                        .Columns.Add("incapacidad")
                    End With

                    For Each row As UltraGridRow In grdNomina.Rows
                        Colaborador.Rows.Add(
                            row.Cells("Colaborador").Value,
                            row.Cells("Puesto").Value,
                            row.Cells("NumeroFaltas").Value,
                            row.Cells("Pagobruto").Value,
                            row.Cells("Extras").Value,
                            row.Cells("Gratificaciones").Value,
                            row.Cells("Faltas").Value,
                            row.Cells("IMSS").Value,
                            row.Cells("ISR").Value,
                            row.Cells("Infonavit").Value,
                            row.Cells("Prestamo").Value,
                            row.Cells("CajaAhorro").Value,
                            row.Cells("OtrasDedu").Value,
                            row.Cells("TotalEntregar").Value,
                            row.Cells("CelulaID").Value,
                            row.Cells("OrdenPuesto").Value,
                            row.Cells("finiquitoid").Value,
                            row.Cells("incapacidad").Value
                        )
                    Next

                    Dim objBUReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    Dim dsDatosReporte As New DataSet("ReporteGeneralNomina")

                    Resumen.Tables.Add(celulas)
                    Resumen.Tables.Add(Colaborador)

                    EntidadReporte = objBUReporte.LeerReporteporClave("REP_AGRUP_NUEVO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("Usuario") = Usuario
                    reporte("PeriodoNomina") = ConceptoSemana
                    reporte("semana") = "Semana " & NoSemanaNomina.ToString
                    reporte.Dictionary.Clear()

                    reporte.RegData(Resumen)
                    reporte.Dictionary.Synchronize()
                    reporte.Show()


                Else
                    advertencia.mensaje = "No hay información para imprimir."
                    advertencia.ShowDialog()
                End If
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function GenerarSolicitudNomina() As Boolean
        Dim TotalDeducciones As Double = 0
        Dim PagoNetoE As Double = 0
        Dim PagoNeto As Double = 0

        'variable que obtiene el monto de nómina fiscal 
        Dim totalNominaFiscal As Double = 0

        Dim banderaG As Boolean = False
        Dim formSolicitudF As New SolicitudFinanzasNomina
        Dim nave As New Entidades.Naves

        For Each fila As UltraGridRow In grdNomina.Rows
            TotalDeducciones += CDbl(fila.Cells("Prestamo").Value) + CDbl(fila.Cells("OtrasDedu").Value) + fila.Cells("CajaAhorro").Value

            If fila.Cells("TipoSueldo").Value = "DEPOSITO" Then
                PagoNeto += CDbl(fila.Cells("TotalEntregar").Value)

            ElseIf fila.Cells("TipoSueldo").Value = "EFECTIVO" Then
                PagoNetoE += CDbl(fila.Cells("TotalEntregar").Value)

            End If
        Next

        ''obtener caja asignada a usuario
        Dim dtCajas As New DataTable
        Dim objCajas As New Negocios.CajasBU
        dtCajas = objCajas.listaCajas(CInt(cmbNave.SelectedValue))

        'Se obtiene el total de nómina fiscal 
        Dim nomina As New Nomina.Negocios.CalcularNominaRealBU
        totalNominaFiscal = nomina.ConsultaTotalNominaFiscal(SemanaNominaID)

        With formSolicitudF
            formSolicitudF.idNave = (Int(cmbNave.SelectedValue))
            nave = cmbNave.SelectedItem
            formSolicitudF.nave = nave.PNombre
            formSolicitudF.totDeducciones = TotalDeducciones
            formSolicitudF.totNominaEfectivo = PagoNetoE
            formSolicitudF.totNominaDeposito = PagoNeto
            formSolicitudF.idSemanaN = SemanaNominaID
            formSolicitudF.semanaNomina = ConceptoSemana
            formSolicitudF.totalNominaFiscal = totalNominaFiscal

            If dtCajas.Rows.Count > 0 Then
                formSolicitudF.idCaja = CInt(dtCajas.Rows(0).Item("Id_Caja").ToString)
                formSolicitudF.caja = dtCajas.Rows(0).Item("Nombre").ToString
            Else
                formSolicitudF.idCaja = 0
            End If

            formSolicitudF.ShowDialog()
            banderaG = formSolicitudF.banderaGuardar

        End With
        Dim bandera As Boolean = False
        If banderaG = True Then
            bandera = True
        Else
            bandera = False
        End If
        Return bandera
    End Function

    Private Sub EnviarCorreoCambioDeNave(Nave As Entidades.Naves)
        Dim ObjCorteBU As New Nomina.Negocios.CorteNominaRealBU
        Dim dtCorreos As DataTable
        Dim dtCorreosColaboradores As DataTable
        Dim Remitente As String
        Dim Destinatarios As String
        Dim NaveDestinoID As Integer
        Dim NaveDestino As String
        Dim CadenaCorreo As String
        Dim correo As New Tools.Correo
        Dim asuntoCorreo As String
        Dim FechaCorte As String

        Try
            Dim accion As Integer = 1
            dtCorreos = ObjCorteBU.ObtenerDatosCorreos(Nave, 1) 'OBTIENE LAS NAVES Y CORREOS DE LOS DESTINATARIOS

            If dtCorreos.Rows.Count > 0 Then

                Remitente = dtCorreos.Rows(0).Item("Remitente")

                For Each row As DataRow In dtCorreos.Rows
                    Destinatarios = row.Item("Destinos").ToString
                    NaveDestinoID = CInt(row.Item("naveDestinoID"))
                    NaveDestino = row.Item("naveDestino")
                    FechaCorte = row.Item("Fecha")

                    dtCorreosColaboradores = ObjCorteBU.ObtenerDatosCorreos(Nave, 2, NaveDestinoID) 'OBTIENE LOS COLABORADORES

                    If dtCorreosColaboradores.Rows.Count > 0 Then

                        CadenaCorreo = GenerarCadenaCorreo(Nave.PNombre, NaveDestino, dtCorreosColaboradores, FechaCorte)
                        asuntoCorreo = "Movimiento de ALTA por Cambio de Nave"
                        correo.EnviarCorreoHtml(Destinatarios, Remitente, asuntoCorreo, CadenaCorreo)

                    End If

                Next

            End If

        Catch ex As Exception
            Dim msg_Error As New Tools.ErroresForm
            msg_Error.mensaje = ex.Message
            msg_Error.ShowDialog()
        End Try

    End Sub

    Private Function GenerarCadenaCorreo(NaveOrigen As String, NaveDestino As String, ListaColaboradores As DataTable, FechaCorte As String) As String

        Dim CadenaCorreo As String
        Dim CadenaColaboradores As String = ""
        Dim CadenaDiseño As String

        For Each row As DataRow In ListaColaboradores.Rows
            CadenaColaboradores = CadenaColaboradores + " <tr><td class='centro'> " + row.Item("rfc") + " </td> "
                    CadenaColaboradores = CadenaColaboradores + " <td> " + row.Item("Colaborador") + " </td></tr> "
        Next

        CadenaDiseño = <CadenaDiseño>                   
                            body {}

                                    .encabezado {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      background: #536EBE;
                                      color: white;
                                      text-align: center;
                                    }

                                    h2 {
                                      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, "Helvetica Neue", Arial, sans-serif, "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol";
                                      font-weight: 200;
                                      line-height: 1.0;
                                      font-size: 1.5rem;
                                    }

                                    .cuerpo {
                                      margin-top: 25px;
                                      margin-left: 25px;
                                      margin-right: 250px;
                                      font-family: arial, sans-serif;
                                      color: black;
                                    }

                                    .cuerpo-tabla {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      margin: 20px;
                                    }

                                    table {
                                      /*margin: 0 auto;*/
                                      margin-top: 10px;
                                      border-collapse: collapse;
                                      width: 75%;
                                    }        

                                    table th{
                                      border-bottom: 2px solid #212529;
                                    }

                                    th {
                                      text-align: center;
                                    }                                   

                                    .centro {
                                      text-align: center;
                                    }

                                    .cuerpo-pie {
                                      display: flex;
                                      justify-content: center;
                                      align-items: center;
                                      margin-top: 25px;
                                      font-family: arial, sans-serif;
                                      background: #CDCDCD;
                                      color: black;
                                    }

                                    .cuerpo-pie label {
                                      margin-left: 25px;
                                      margin-bottom: 25px;
                                    }

                       </CadenaDiseño>.Value
        CadenaCorreo = " <html> " +
                            " <head> " +
                               " <meta charset ='utf-8'/> " +
                               " <style type='text/css'>" + CadenaDiseño + "</style> " +
                            " </head> " +
                            " <body> " +
                                " <div Class='encabezado'> " +
                                        " <h2> NOTIFICACIÓN PARA CAMBIO DE NAVE </h2> " +
                                " </div> " +
                                " <div Class='cuerpo'> " +
                                    " <div> " +
                                        " <Label> Se ha realizado el cambio desde " +
                                            " <b>" + NaveOrigen + "</b> a nave <b>" + NaveDestino + "</b> de los siguientes colaboradores: " +
                                        " </label> " +
                                    " </div> " +
                                    " <div Class='cuerpo-tabla'> " +
                                        " <table> " +
                                            " <thead> " +
                                                " <tr Class='encabezado-tabla'>" +
                                                   " <th> RFC </th>" +
                                                   " <th> NOMBRE </th> " +
                                                " </tr> " +
                                            " </thead> " +
                                            " <tbody> " +
                                                   CadenaColaboradores +
                                            " </tbody> " +
                                        " </table> " +
                                    " </div> " +
                                " </div> " +
                                " <div Class='cuerpo-pie'> " +
                                            " <Label> Favor de ingresar al sistemas SAY y registrar las solicitudes de altas al IMSS y reimprimir las credenciales</label> " +
                                            " <Label> " +
                                                "<br><b> Nota : </b> A partir del Miercoles " + FechaCorte + " debe registrar en dicha nave</label> " +
                                " </div> " +
                            " </body> " +
                        " </html> "

        Return CadenaCorreo
    End Function

    Private Sub cmbPeriodoNomina_DropDownClosed(sender As Object, e As EventArgs) Handles cmbPeriodoNomina.DropDownClosed

        Dim destBU As New Nomina.Negocios.CalcularNominaRealBU
        Dim dtSemana As New DataTable
        Dim blnSemCerrada As Boolean = False
        If Not IsDBNull(cmbPeriodoNomina.SelectedValue) Then
            dtSemana = destBU.obtenerSemanaCerradaBU(cmbPeriodoNomina.SelectedValue)

            If Not dtSemana Is Nothing AndAlso dtSemana.Rows.Count > 0 Then
                blnSemCerrada = (dtSemana.Rows(0).Item("pnom_stPeriodoNomina") = "C") 'destBU.validaSemanaCerradaBU(cmbPeriodoNomina.SelectedValue) = "C")
                SemanaNominaID = CInt(dtSemana.Rows(0).Item("pnom_PeriodoNomId"))
                ConceptoSemana = dtSemana.Rows(0).Item("pnom_Concepto")
                FechaInicio = dtSemana.Rows(0).Item("pnom_FechaInicial")
                fechaFinal = dtSemana.Rows(0).Item("pnom_FechaFinal")
                NoSemanaNomina = dtSemana.Rows(0).Item("pnom_NoSemanaNomina")

                'If (cmbPeriodoNomina.SelectedValue) = 7000 Or (cmbPeriodoNomina.SelectedValue) = 6745 Then
                '    blnSemCerrada = False
                'End If

                btnCalcular.Enabled = Not (blnSemCerrada)
                ImprimirDepósitoACuentasToolStripMenuItem.Visible = blnSemCerrada
                lblcolaborador.Visible = blnSemCerrada
                txtColaborador.Visible = blnSemCerrada
                btnGuardar.Enabled = Not (blnSemCerrada)
                btnBuscar.Enabled = blnSemCerrada
                pnlEtiquetas.Visible = Not (blnSemCerrada)
            Else
                blnSemCerrada = False
            End If

            If blnSemCerrada = False Then
                cmbNaveDrop() ''Revisar
            End If

            grdNomina.DataSource = Nothing
        End If

    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        CalcularNomina()
    End Sub

    Private Sub CalcularNomina()
        grdNomina.DataSource = Nothing

        If Not IsDBNull(SemanaNominaID) Then
            Dim msjAdv As New AdvertenciaForm

            If SemanaNominaID > 0 Then
                Dim msjErr As New ErroresForm

                Me.Cursor = Cursors.WaitCursor
                Dim objNomRealBU As New Nomina.Negocios.CalcularNominaRealBU
                Dim dtNomina As New DataTable

                Try
                    dtNomina = objNomRealBU.calcularNominaRealBU(SemanaNominaID, cmbNave.SelectedValue)
                    If Not dtNomina Is Nothing AndAlso dtNomina.Rows.Count > 0 Then
                        grdNomina.DataSource = dtNomina
                        formatoGrid(0)
                        formatoFila()
                        validaNegativos()
                        agregaSumatoriasGrid()
                    End If
                Catch ex As Exception
                    msjErr.mensaje = "Ocurrió un error al intentar calcular la nómina."
                    msjErr.ShowDialog()
                Finally
                    Me.Cursor = Cursors.Default
                End Try

            Else
                msjAdv.mensaje = "Favor de elegir un periodo de nómina correcto."
                msjAdv.ShowDialog()
            End If
        End If
    End Sub

    Public Sub formatoGrid(ByVal tipoConsulta As Integer)

        'grdNomina.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grdNomina.DisplayLayout.UseFixedHeaders = True
        grdNomina.DisplayLayout.Bands(0).Columns("Colaborador").Header.Fixed = True
        grdNomina.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None

        '
        grdNomina.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdNomina.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

        grdNomina.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdNomina.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNomina.DisplayLayout.Override.RowSelectorWidth = 35
        grdNomina.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grdNomina.DisplayLayout.Override.AllowMultiCellOperations = AllowMultiCellOperation.CopyWithHeaders

        grdNomina.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        grdNomina.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True


        With grdNomina.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.RowSelect

            .Columns("ColaboradorId").Hidden = True
            .Columns("TipoSueldo").Hidden = False
            .Columns("Cuenta").Hidden = True
            .Columns("GratificacionFechaNac").Hidden = True
            .Columns("finiquitoid").Hidden = True
            .Columns("tipoColaborador").Hidden = True
            .Columns("ConceptoGratificaciones").Hidden = True
            .Columns("IdAnual").Hidden = True
            .Columns("CelulaId").Hidden = True
            .Columns("Departamentoid").Hidden = True
            .Columns("OrdenPuesto").Hidden = True
            .Columns("numSS").Hidden = True
            .Columns("salarioDiarioReal").Hidden = True
            .Columns("sexo").Hidden = True
            .Columns("celulanombre").Hidden = True
            .Columns("celulaorden").Hidden = True

            If tipoConsulta = 0 Then
                .Columns("interesPrestamo").Hidden = True
                .Columns("real_fecha").Hidden = True
                .Columns("modificacaja").Hidden = True
                .Columns("modificaprestamo").Hidden = True
                .Columns("modificadeduccion").Hidden = True
            End If

            .Columns("NumeroFaltas").Header.Caption = "No. de Faltas"
            .Columns("Incapacidad").Header.Caption = "Incapacidades"
            .Columns("PagoBruto").Header.Caption = "Pago Bruto"
            .Columns("Faltas").Header.Caption = "Ausentismos"
            .Columns("Prestamo").Header.Caption = "Préstamos"
            .Columns("CajaAhorro").Header.Caption = "Caja de Ahorro"
            .Columns("OtrasDedu").Header.Caption = "Otras Deducciones"
            .Columns("TotalEntregar").Header.Caption = "Pago Neto"
            .Columns("TipoSueldo").Header.Caption = "Tipo Sueldo"


            .Columns("NumeroFaltas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Incapacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("PagoBruto").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Extras").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Gratificaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Faltas").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("IMSS").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ISR").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Infonavit").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Prestamo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("CajaAhorro").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("OtrasDedu").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TotalEntregar").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("TipoSueldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("Colaborador").Width = 300
            .Columns("Departamento").Width = 130
            .Columns("Puesto").Width = 170
            .Columns("NumeroFaltas").Width = 60
            .Columns("Incapacidad").Width = 80
            .Columns("PagoBruto").Width = 75
            .Columns("Extras").Width = 75
            .Columns("Gratificaciones").Width = 90
            .Columns("Faltas").Width = 75
            .Columns("IMSS").Width = 75
            .Columns("ISR").Width = 75
            .Columns("Infonavit").Width = 75
            .Columns("Prestamo").Width = 80
            .Columns("CajaAhorro").Width = 75
            .Columns("OtrasDedu").Width = 75
            .Columns("TotalEntregar").Width = 75
            .Columns("TipoSueldo").Width = 75

            .Columns("NumeroFaltas").Format = "##,##0.0"
            .Columns("Incapacidad").Format = "##,##0"
            .Columns("PagoBruto").Format = "##,##0"
            .Columns("Extras").Format = "##,##0"
            .Columns("Gratificaciones").Format = "##,##0"
            .Columns("Faltas").Format = "##,##0"
            .Columns("IMSS").Format = "##,##0"
            .Columns("ISR").Format = "##,##0"
            .Columns("Infonavit").Format = "##,##0"
            .Columns("Prestamo").Format = "##,##0"
            .Columns("CajaAhorro").Format = "##,##0"
            .Columns("OtrasDedu").Format = "##,##0"
            .Columns("TotalEntregar").Format = "##,##0"

        End With

    End Sub

    Private Sub formatoFila()
        For Each row As UltraGridRow In grdNomina.Rows
            If row.Cells("TotalEntregar").Value >= 0 Then
                row.Cells("TotalEntregar").Appearance.BackColor = Color.LightGreen
                row.Cells("TotalEntregar").Value = Math.Round(row.Cells("TotalEntregar").Value, 0)
            Else
                row.Cells("TotalEntregar").Appearance.BackColor = Color.Salmon
            End If
        Next
    End Sub

    Private Sub validaNegativos()
        listaNegativos.Clear()

        For Each row As UltraGridRow In grdNomina.Rows
            If row.Cells("TotalEntregar").Value < 0 Then

                If row.Cells("CajaAhorro").Value > 0 Then
                    row.Cells("TotalEntregar").Value = row.Cells("TotalEntregar").Value + row.Cells("CajaAhorro").Value
                    row.Cells("CajaAhorro").Value = 0
                    row.Cells("CajaAhorro").Appearance.BackColor = Color.LightBlue
                    row.Cells("modificacaja").Value = 1
                    row.Cells("TotalEntregar").Appearance.BackColor = Color.LightGray
                End If

                'Si sigue siendo negativo quita el préstamo
                If row.Cells("Prestamo").Value > 0 And row.Cells("TotalEntregar").Value < 0 Then
                    row.Cells("TotalEntregar").Value = row.Cells("TotalEntregar").Value + row.Cells("Prestamo").Value
                    row.Cells("Prestamo").Value = 0
                    row.Cells("Prestamo").Appearance.BackColor = Color.LightBlue
                    row.Cells("modificaprestamo").Value = 1
                    row.Cells("TotalEntregar").Appearance.BackColor = Color.LightGray
                End If

                'Si sigue siendo negativo quita las deducciones extraordinarias
                If row.Cells("OtrasDedu").Value > 0 And row.Cells("TotalEntregar").Value < 0 Then
                    row.Cells("TotalEntregar").Value = row.Cells("TotalEntregar").Value + row.Cells("OtrasDedu").Value
                    row.Cells("OtrasDedu").Value = 0
                    row.Cells("OtrasDedu").Appearance.BackColor = Color.LightBlue
                    row.Cells("modificadeduccion").Value = 1
                    row.Cells("TotalEntregar").Appearance.BackColor = Color.LightGray
                End If

                'Si ya se elminó pago de préstamo y caja de ahorro se elimina el imms en caso de que siga siendo negativo
                If row.Cells("CajaAhorro").Value = 0 And row.Cells("Prestamo").Value = 0 And row.Cells("TotalEntregar").Value < 0 Then

                    If row.Cells("IMSS").Value > 0 Or row.Cells("ISR").Value > 0 Then
                        'clmIMMS contiene IMSS e ISR
                        row.Cells("TotalEntregar").Value = row.Cells("TotalEntregar").Value + row.Cells("IMSS").Value + row.Cells("ISR").Value
                        row.Cells("IMSS").Appearance.BackColor = Color.LightBlue
                        row.Cells("ISR").Appearance.BackColor = Color.LightBlue
                        row.Cells("IMSS").Value = 0
                        row.Cells("ISR").Value = 0
                        row.Cells("TotalEntregar").Appearance.BackColor = Color.LightGray
                    End If

                    ''SI AUN SI SIGUE SIENDO NEGATIVO SE ELIMINA EL INFONAVIT
                    If row.Cells("TotalEntregar").Value < 0 And row.Cells("Infonavit").Value > 0 Then

                        row.Cells("TotalEntregar").Value = row.Cells("TotalEntregar").Value + row.Cells("Infonavit").Value
                        row.Cells("Infonavit").Value = 0
                        row.Cells("Infonavit").Appearance.BackColor = Color.LightBlue
                        row.Cells("TotalEntregar").Appearance.BackColor = Color.LightGray

                    End If

                End If

                If row.Cells("TotalEntregar").Value < 0 Then
                    row.Cells("TotalEntregar").Appearance.BackColor = Color.Salmon
                    listaNegativos.Add(CInt(row.Cells("ColaboradorId").Value))
                End If

            End If

        Next

        If listaNegativos.Count > 0 Then
            pnlCerrarSemana.Enabled = False
        Else
            pnlCerrarSemana.Enabled = True
        End If

    End Sub

    Private Sub agregaSumatoriasGrid()

        Dim sumPagoBruto As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("PagoBruto"))
        Dim sumExtras As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("Extras"))
        Dim sumGrat As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("Gratificaciones"))
        Dim sumFaltas As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("Faltas"))
        Dim sumIMSS As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("IMSS"))
        Dim sumISR As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("ISR"))
        Dim sumInf As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("Infonavit"))
        Dim sumPrestamo As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("Prestamo"))
        Dim sumCaja As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("CajaAhorro"))
        Dim sumDedExt As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("OtrasDedu"))
        Dim sumNeto As SummarySettings = grdNomina.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdNomina.DisplayLayout.Bands(0).Columns("TotalEntregar"))

        sumPagoBruto.DisplayFormat = "{0:#,##0}"
        sumPagoBruto.Appearance.TextHAlign = HAlign.Right
        sumPagoBruto.Appearance.BackColor = Color.GreenYellow
        sumExtras.DisplayFormat = "{0:#,##0}"
        sumExtras.Appearance.TextHAlign = HAlign.Right
        sumExtras.Appearance.BackColor = Color.GreenYellow
        sumGrat.DisplayFormat = "{0:#,##0}"
        sumGrat.Appearance.TextHAlign = HAlign.Right
        sumGrat.Appearance.BackColor = Color.GreenYellow
        sumFaltas.DisplayFormat = "{0:#,##0}"
        sumFaltas.Appearance.TextHAlign = HAlign.Right
        sumFaltas.Appearance.BackColor = Color.GreenYellow
        sumIMSS.DisplayFormat = "{0:#,##0}"
        sumIMSS.Appearance.TextHAlign = HAlign.Right
        sumIMSS.Appearance.BackColor = Color.GreenYellow
        sumISR.DisplayFormat = "{0:#,##0}"
        sumISR.Appearance.TextHAlign = HAlign.Right
        sumISR.Appearance.BackColor = Color.GreenYellow
        sumInf.DisplayFormat = "{0:#,##0}"
        sumInf.Appearance.TextHAlign = HAlign.Right
        sumInf.Appearance.BackColor = Color.GreenYellow
        sumPrestamo.DisplayFormat = "{0:#,##0}"
        sumPrestamo.Appearance.TextHAlign = HAlign.Right
        sumPrestamo.Appearance.BackColor = Color.GreenYellow
        sumCaja.DisplayFormat = "{0:#,##0}"
        sumCaja.Appearance.TextHAlign = HAlign.Right
        sumCaja.Appearance.BackColor = Color.GreenYellow
        sumDedExt.DisplayFormat = "{0:#,##0}"
        sumDedExt.Appearance.TextHAlign = HAlign.Right
        sumDedExt.Appearance.BackColor = Color.GreenYellow
        sumNeto.DisplayFormat = "{0:#,##0}"
        sumNeto.Appearance.TextHAlign = HAlign.Right
        sumNeto.Appearance.BackColor = Color.GreenYellow

        grdNomina.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


    End Sub

    Private Sub grdNomina_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdNomina.InitializeRow
        Try
            If e.Row.Cells("FiniquitoId").Value > 0 Then
                e.Row.CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImprimirDepósitoACuentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirDepósitoACuentasToolStripMenuItem.Click
        ''Se visualiza cuando la nómina ya esté guardada
        Try
            Dim Total As Double = 0
            Dim nomina As New Nomina.Negocios.CalcularNominaRealBU

            If grdNomina.Rows.Count > 0 Then
                Me.Cursor = Cursors.WaitCursor

                Dim ContadorFila As Integer = 0
                Dim Cuentas = New DataTable("Cuentas")
                With Cuentas
                    .Columns.Add("Numero")
                    .Columns.Add("Cuenta")
                    .Columns.Add("Titular")
                    .Columns.Add("Total", Type.GetType("System.Decimal"))
                End With

                For Each row As UltraGridRow In grdNomina.Rows
                    ContadorFila += 1
                    If row.Cells("TipoSueldo").Value = "DEPOSITO" Then
                        Total += row.Cells("TotalEntregar").Value
                        Cuentas.Rows.Add(
                        ContadorFila,
                        row.Cells("Cuenta").Value,
                        row.Cells("Colaborador").Value,
                        row.Cells("TotalEntregar").Value)
                    End If
                Next
                Cuentas.Rows.Add("", "", "", Total.ToString("N0"))

                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("NOM_ENV_CUEN_NUEVO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(Cuentas)
                reporte.Show()

            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdNomina_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdNomina.DoubleClickCell
        Select Case e.Cell.Column.Key
            Case "CajaAhorro"
                Dim ObjCaja As New CierreSemanalForm
                ObjCaja.Nave = cmbNave.SelectedValue
                ObjCaja.IdPeriodoNomina = CLng(SemanaNominaID)
                ObjCaja.listaNegativos = listaNegativos
                ObjCaja.ShowDialog()

                CalcularNomina()

            Case "Prestamo"
                Dim ObjPres As New EditarCobranzaPrestamos
                ObjPres.PLISTAID = listaNegativos
                ObjPres.ShowDialog()

                CalcularNomina()
            Case "OtrasDedu"
                Dim ObjDeducciones As New EditarDeduccionesExtraordinarias
                ObjDeducciones.PLISTAID2 = listaNegativos
                ObjDeducciones.ShowDialog()

                CalcularNomina()
        End Select
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        exportarExcel()
    End Sub

    Private Sub exportarExcel()
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm

        If grdNomina.Rows.Count > 0 Then
            Try
                Dim fbdUbicacionArchivo As New FolderBrowserDialog
                Dim archivo As String = String.Empty

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        Dim fecha_hora As String = Date.Now.ToString("yyyyMMdd_Hmmss")

                        archivo = "NÓMINA_SEMANA" & NoSemanaNomina & "_" & fecha_hora & ".xlsx"
                        UltraGridExcelExporter1.Export(grdNomina, .SelectedPath & "\" & archivo)

                        objMensajeExito.mensaje = "Los datos se exportaron correctamente al archivo " & archivo
                        objMensajeExito.ShowDialog()
                        Try
                            Process.Start(.SelectedPath & "\" & archivo)
                        Catch ex As Exception
                        Finally
                            Me.Cursor = Cursors.Default
                        End Try

                    End If
                    .Dispose()
                End With

            Catch ex As Exception
                objMensajeError.mensaje = "Error al exportar."
                objMensajeError.ShowDialog()
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            objMensajeAdv.mensaje = "No hay información para exportar."
            objMensajeAdv.ShowDialog()
        End If

    End Sub

    Private Sub UltraGridExcelExporter1_InitializeColumn(sender As Object, e As ExcelExport.InitializeColumnEventArgs) Handles UltraGridExcelExporter1.InitializeColumn
        e.ExcelFormatStr = e.Column.Format
    End Sub

End Class