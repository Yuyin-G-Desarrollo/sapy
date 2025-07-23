Imports Stimulsoft.Report
Imports System.Globalization
Imports Tools

''' <summary>
''' AUTOR: JUANA GUERRERO GÓMEZ
''' FECHA: 03 ABRIL 2014
''' DESCRIPCION: MUESTRA TODAS LAS SEMANAS DE LA CAJA DE AHORRO (PERDIDAS Y GANADAS)
''' CALCULA EL TOTAL A ENTREGAR AL COLABORADOR CON INTERESES GANADOS Y PERMITE ABONAR A SALDO DE PRESTAMOS PENDIENTES
''' 
''' ACTUALIZACION: YAZMIN ROCHA
''' FECHA: 09/02/2016
''' </summary>
''' <remarks></remarks>
Public Class ReporteCajaForm

    Public IdCajaAhorro As Int32 = 0
    Public cajaAhorro As Entidades.CajaAhorro
    Public Nave As String = ""
    Public idNave As Int32 = 0
    Public Periodo As String = ""
    Public Estatus As String = ""
    Public columnaSaldoPrestamo As Int32 = 0
    Public columnaAbono As Int32 = 0
    Public columnaAbonoResp As Int32 = 0
    Public columnaIdPrestamo As Int32 = 0
    Public columnaNuevoSaldo As Int32 = 0
    Public columnaTotalEntregar As Int32 = 0
    Public columnaTotalEntregarOriginal As Int32 = 0
    Public columnaSalario As Int32 = 0
    Dim cuentaSemanas As Int32 = 0
    Dim idSemanaActiva As Integer

    Dim sumaMontoAhorro As Double = 0
    Dim porcentajeInteresTotal As Double = 0
    Dim sumaAcumulado As Double = 0
    Dim sumaIntereses As Double = 0
    Dim sumaTotalCaja As Double = 0
    Dim sumaSaldoPrestamos As Double = 0
    Dim sumaAbonoPrestamos As Double = 0
    Dim sumaNuevosSaldos As Double = 0
    Dim sumaTotalEntregar As Double = 0

    Dim ContadorFilas As Integer = 0

    Private IdPeriodoNomina As Int32 = -1
    Private _searchfilter As New C1.Win.C1FlexGrid.ConditionFilter
    Private _searchfilterEstatus As New C1.Win.C1FlexGrid.ConditionFilter
    Private listaSemanas As New List(Of Entidades.PeriodosNomina)
    Dim listaPrestamos As New List(Of Entidades.SolicitudPrestamo)

    Public cajaDeAl As String = ""
    Public nombreNave As String = ""

    Public Sub ejecutarReporteResumenAnual()
        If grdCierre2.RowCount <= 0 Then
            Exit Sub
        End If

        Dim objN As New Negocios.CajaAhorroBU
        Dim dtResumen As New DataTable
        dtResumen.TableName = "dtResumen"
        'dtResumen = objN.consultaResumenCajaCerrada(IdCajaAhorro)

        dtResumen.Columns.Add("Nombre")
        dtResumen.Columns.Add("Monto")
        dtResumen.Columns.Add("Ahorradas")
        dtResumen.Columns.Add("Ganadas")
        dtResumen.Columns.Add("Perdidas")
        dtResumen.Columns.Add("Acumulado")
        dtResumen.Columns.Add("Interes")
        dtResumen.Columns.Add("montoInteres")
        dtResumen.Columns.Add("Total")
        dtResumen.Columns.Add("SaldoAnterior")
        dtResumen.Columns.Add("Abono")
        dtResumen.Columns.Add("SaldoNuevo")
        dtResumen.Columns.Add("TotalPagar")

        For Each row As DataGridViewRow In grdCierre2.Rows
            Dim newRow As DataRow



            newRow = dtResumen.NewRow
            newRow.Item("Nombre") = row.Cells("Colaborador").Value.ToString
            newRow.Item("Monto") = Replace(row.Cells("ColMontoAhorro").Value.ToString, ",", "")
            newRow.Item("Ahorradas") = Replace(row.Cells("ColSemanasAhorradas").Value.ToString, ",", "")
            newRow.Item("Ganadas") = Replace(row.Cells("ColSemanasGanadas").Value.ToString, ",", "")
            newRow.Item("Perdidas") = Replace(row.Cells("ColSemanasPerdidas").Value.ToString, ",", "")
            newRow.Item("Acumulado") = Replace(row.Cells("ColMontoAcumulado").Value.ToString, ",", "")
            newRow.Item("Interes") = Replace(Replace(row.Cells("ColInteresGanado").Value.ToString, ",", ""), "%", "")
            newRow.Item("montoInteres") = Replace(row.Cells("ColTotalIntereses").Value.ToString, ",", "")
            newRow.Item("Total") = Replace(row.Cells("ColTotalCaja").Value.ToString, ",", "")
            newRow.Item("SaldoAnterior") = Replace(row.Cells("ColTotalPrestamo").Value.ToString, ",", "")
            newRow.Item("Abono") = Replace(row.Cells("ColAbonoPrestamo").Value.ToString, ",", "")
            newRow.Item("SaldoNuevo") = Replace(row.Cells("ColSaldoPrestamo").Value.ToString, ",", "")
            newRow.Item("TotalPagar") = Replace(row.Cells("ColTotalEntregar").Value.ToString, ",", "")

            dtResumen.Rows.Add(newRow)
        Next

        If dtResumen.Rows.Count > 0 Then
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim entReporte As New Entidades.Reportes
            entReporte = objReporte.LeerReporteporClave("ANUAL_CAJA_AHORRO")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
            Dim reporte As New StiReport
            Dim objCajaAhorroBU As New Negocios.CajaAhorroBU
            Dim entCajaAhorro As New Entidades.CajaAhorro

            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(IdCajaAhorro)
            nombreNave = Nave
            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idNave)
            reporte("nombreNave") = nombreNave
            reporte("nombreReporte") = "SAY: CARTA_CIERRE_CAJA_AHORRO.mrt"

            reporte("NombreUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("concepto") = lblConceptoPeriodo.Text
            entCajaAhorro = objCajaAhorroBU.ObtenerCajaAhorro(IdCajaAhorro)


            reporte.Dictionary.Clear()
            reporte.RegData(dtResumen)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Else

        End If
    End Sub

    Private Sub ReporteCajaForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.WaitCursor
        'BUSCA LOS DATOS DE LA CAJA DE AHORRO
        Dim cajaAhorroBU As New Negocios.CajaAhorroBU
        cajaAhorro = cajaAhorroBU.ObtenerCajaAhorro(IdCajaAhorro)
        idNave = cajaAhorro.pNave.PNaveId
        lblConceptoPeriodo.Text = cajaAhorro.pConcepto
        lblNave.Text = cajaAhorro.pNave.PNombre.ToString
        SemanaNomina()
        'CREA COLUMNAS POR SEMANA
        generarCeldasSemanas()
        If Estatus = "ACTIVA" Then
            'AGREGA LAS PRIMERAS COLUMNAS ESTÁTICAS
            llenarTablaCierre()
        End If

        Dim fechaFin As Date = cajaAhorro.pFechaFinal

        'If DatePart(DateInterval.Year, Date.Now) = DatePart(DateInterval.Year, fechaFin) And DatePart(DateInterval.WeekOfYear, Date.Now) = DatePart(DateInterval.WeekOfYear, fechaFin) Then
        pnlGuardar.Enabled = True
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "BOTON_GUARDAR_ABONOS_AHORROS") Then
            btnGuardar.Visible = True
        Else
            btnGuardar.Visible = False
            lblGuardar.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_CAJA_CAJA", "BOTON_CIERRE_AHORRO") Then
            btnCerrar.Visible = True
        Else
            btnCerrar.Visible = False
            lblAccionCierreAnual.Visible = False
        End If
        'Else
        'pnlGuardar.Enabled = False
        'End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub generarCeldasSemanas()
        Me.grdCierre2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.grdCierre2.ColumnHeadersHeight = Me.grdCierre2.ColumnHeadersHeight * 2

        Dim reporteSemanasBU As New Negocios.ReporteCajaAhorroBU
        Dim prestamosBU As New Negocios.SolicitudPrestamoBU

        listaSemanas = reporteSemanasBU.ConsultaSemanasCaja(IdCajaAhorro)
        'PONE LAS COLUMNAS POR CADA SEMANA DE CAJA DE AHORRO


        For Each semana In listaSemanas
            Dim Colsemana As New DataGridViewTextBoxColumn
            Colsemana.Name = "Sem" + semana.PPeriodoId.ToString
            Colsemana.HeaderText = semana.FechaInicio.ToShortDateString + " al " + semana.FechaFin.ToShortDateString
            Colsemana.DataPropertyName = ""
            Colsemana.ReadOnly = True
            Colsemana.Width = 80
            Colsemana.SortMode = DataGridViewColumnSortMode.NotSortable
            grdCierre2.Columns.Add(Colsemana)
            cuentaSemanas = cuentaSemanas + 1
        Next
        cuentaSemanas = listaSemanas.Count

        'AGREGA COLUMNA PARA TOTAL DE SEMANAS AHORRADAS
        Dim ColMontoAhorro As New DataGridViewTextBoxColumn
        ColMontoAhorro.Name = "ColMontoAhorro"
        ColMontoAhorro.HeaderText = "Monto ahorro"
        ColMontoAhorro.DataPropertyName = ""
        ColMontoAhorro.ReadOnly = True
        ColMontoAhorro.Width = 80
        ColMontoAhorro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColMontoAhorro)

        'AGREGA COLUMNA PARA TOTAL DE SEMANAS AHORRADAS
        Dim ColSemanasAhorradas As New DataGridViewTextBoxColumn
        ColSemanasAhorradas.Name = "ColSemanasAhorradas"
        ColSemanasAhorradas.HeaderText = "Semanas Ahorradas"
        ColSemanasAhorradas.DataPropertyName = ""
        ColSemanasAhorradas.ReadOnly = True
        ColSemanasAhorradas.Width = 80
        ColSemanasAhorradas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColSemanasAhorradas)

        'AGREGA COLUMNA PARA TOTAL DE SEMANAS GANADAS
        Dim ColSemanasGanadas As New DataGridViewTextBoxColumn
        ColSemanasGanadas.Name = "ColSemanasGanadas"
        ColSemanasGanadas.HeaderText = "Semanas Ganadas"
        ColSemanasGanadas.DataPropertyName = ""
        ColSemanasGanadas.ReadOnly = True
        ColSemanasGanadas.Width = 80
        ColSemanasGanadas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColSemanasGanadas)

        'AGREGA COLUMNA PARA TOTAL DE SEMANAS PERDIDAS
        Dim ColSemanasPerdidas As New DataGridViewTextBoxColumn
        ColSemanasPerdidas.Name = "ColSemanasPerdidas"
        ColSemanasPerdidas.HeaderText = "Semanas Perdidas"
        ColSemanasPerdidas.DataPropertyName = ""
        ColSemanasPerdidas.ReadOnly = True
        ColSemanasPerdidas.Width = 80
        ColSemanasPerdidas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColSemanasPerdidas)


        'AGREGA COLUMNA PARA INTERÉS GANADO
        Dim ColInteresGanado As New DataGridViewTextBoxColumn
        ColInteresGanado.Name = "ColInteresGanado"
        ColInteresGanado.HeaderText = "Interés Ganado"
        ColInteresGanado.DataPropertyName = ""
        ColInteresGanado.ReadOnly = True
        ColInteresGanado.Width = 80
        ColInteresGanado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColInteresGanado)

        'AGREGA COLUMNA MONTO ACUMULADO DE CAJA DE AHORRO
        Dim ColMontoAcumulado As New DataGridViewTextBoxColumn
        ColMontoAcumulado.Name = "ColMontoAcumulado"
        ColMontoAcumulado.HeaderText = "Monto Acumulado"
        ColMontoAcumulado.DataPropertyName = ""
        ColMontoAcumulado.ReadOnly = True
        ColMontoAcumulado.Width = 80
        ColMontoAcumulado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColMontoAcumulado)

        'AGREGA COLUMNA TOTAL INTERESES GANADOS
        Dim ColTotalIntereses As New DataGridViewTextBoxColumn
        ColTotalIntereses.Name = "ColTotalIntereses"
        ColTotalIntereses.HeaderText = "Total Intereses"
        ColTotalIntereses.DataPropertyName = ""
        ColTotalIntereses.ReadOnly = True
        ColTotalIntereses.Width = 80
        ColTotalIntereses.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColTotalIntereses)

        'AGREGA COLUMNA SUELDO SEMANAL
        Dim ColTotalCaja As New DataGridViewTextBoxColumn
        ColTotalCaja.Name = "ColTotalCaja"
        ColTotalCaja.HeaderText = "Total Caja"
        ColTotalCaja.DataPropertyName = ""
        ColTotalCaja.ReadOnly = True
        ColTotalCaja.Width = 80
        ColTotalCaja.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColTotalCaja)

        'AGREGA COLUMNA SUELDO SEMANAL
        Dim ColSueldoSemanal As New DataGridViewTextBoxColumn
        ColSueldoSemanal.Name = "ColSueldoSemanal"
        ColSueldoSemanal.HeaderText = "Salario"
        ColSueldoSemanal.DataPropertyName = ""
        ColSueldoSemanal.ReadOnly = True
        ColSueldoSemanal.Width = 80
        ColSueldoSemanal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColSueldoSemanal)

        'AGREGA COLUMNA PARA ID PRESTAMO
        Dim ColIdPrestamo As New DataGridViewTextBoxColumn
        ColIdPrestamo.Name = "ColIdPrestamo"
        ColIdPrestamo.HeaderText = "Id prestamo"
        ColIdPrestamo.DataPropertyName = ""
        ColIdPrestamo.ReadOnly = True
        ColIdPrestamo.Width = 80
        ColIdPrestamo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ColIdPrestamo.Visible = False
        grdCierre2.Columns.Add(ColIdPrestamo)

        'AGREGA COLUMNA PARA TOTAL DE PRÉSTAMOS
        Dim ColTotalPrestamo As New DataGridViewTextBoxColumn
        ColTotalPrestamo.Name = "ColTotalPrestamo"
        ColTotalPrestamo.HeaderText = "Saldo en Préstamos"
        ColTotalPrestamo.DataPropertyName = ""
        ColTotalPrestamo.ReadOnly = True
        ColTotalPrestamo.Width = 80
        ColTotalPrestamo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColTotalPrestamo)

        'AGREGA COLUMNA PARA MONTO QUE SE VA A ABONAR AL PRÉSTAMO
        Dim ColAbonoPrestamo As New DataGridViewTextBoxColumn
        ColAbonoPrestamo.Name = "ColAbonoPrestamo"
        ColAbonoPrestamo.HeaderText = "Abono"
        ColAbonoPrestamo.DataPropertyName = ""
        ColAbonoPrestamo.ReadOnly = False
        ColAbonoPrestamo.Width = 80
        ColAbonoPrestamo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColAbonoPrestamo)

        'AGREGA COLUMNA PARA MONTO ORIGINAL QUE SE VA A ABONAR AL PRÉSTAMO
        Dim ColAbonoPrestamoOriginal As New DataGridViewTextBoxColumn
        ColAbonoPrestamoOriginal.Name = "ColAbonoPrestamoResp"
        ColAbonoPrestamoOriginal.HeaderText = "Abono"
        ColAbonoPrestamoOriginal.DataPropertyName = ""
        ColAbonoPrestamoOriginal.ReadOnly = False
        ColAbonoPrestamoOriginal.Width = 80
        ColAbonoPrestamoOriginal.Visible = False
        ColAbonoPrestamoOriginal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColAbonoPrestamoOriginal)

        'AGREGA COLUMNA PARA IDENTIFICAR SI EL ABONO YA FUE GUARDADO EN LA BD
        Dim ColAbonoGuardado As New DataGridViewTextBoxColumn
        ColAbonoGuardado.Name = "ColAbonoGuardado"
        ColAbonoGuardado.HeaderText = "Estatus Abono"
        ColAbonoGuardado.DataPropertyName = ""
        ColAbonoGuardado.ReadOnly = False
        ColAbonoGuardado.Width = 80
        ColAbonoGuardado.Visible = False
        ColAbonoGuardado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColAbonoGuardado)

        'AGREGA COLUMNA PARA SALDO DEL PRÉSTAMO
        Dim ColSaldoPrestamo As New DataGridViewTextBoxColumn
        ColSaldoPrestamo.Name = "ColSaldoPrestamo"
        ColSaldoPrestamo.HeaderText = "Nuevo Saldo"
        ColSaldoPrestamo.DataPropertyName = ""
        ColSaldoPrestamo.ReadOnly = True
        ColSaldoPrestamo.Width = 80
        ColSaldoPrestamo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColSaldoPrestamo)

        'AGREGA COLUMNA PARA TOTAL A ENTREGAR
        Dim ColTotalEntregar As New DataGridViewTextBoxColumn
        ColTotalEntregar.Name = "ColTotalEntregar"
        ColTotalEntregar.HeaderText = "Total Entregar"
        ColTotalEntregar.DataPropertyName = ""
        ColTotalEntregar.ReadOnly = True
        ColTotalEntregar.Width = 80
        ColTotalEntregar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCierre2.Columns.Add(ColTotalEntregar)

        'AGREGA COLUMNA PARA TOTAL A ENTREGAR ORIGINAL 
        Dim ColTotalEntregarOriginal As New DataGridViewTextBoxColumn
        ColTotalEntregarOriginal.Name = "ColTotalEntregarOriginal"
        ColTotalEntregarOriginal.HeaderText = "Total Entregar Original"
        ColTotalEntregarOriginal.DataPropertyName = ""
        ColTotalEntregarOriginal.ReadOnly = True
        ColTotalEntregarOriginal.Width = 80
        ColTotalEntregarOriginal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        ColTotalEntregarOriginal.Visible = False
        grdCierre2.Columns.Add(ColTotalEntregarOriginal)

        'ESTABLECE EL INDEX DE LAS COLUMNAS QUE SE UTILIZAN PARA EL CALCULO DE SALDO DE PRESTAMOS
        'HAY 3 COLUMNAS ESTATICAS AL INICIO
        'HAY N COLUMNAS DINAMICAS DE LAS SEMANAS DE LA CAJA DE AHORRO
        'HAY 8 COLUMNAS ANTES DEL ID DEL PRESTAMO
        'ID DEL PRESTAMO ES LA 9VENA COLUMNA DESPUES DE LAS 3 ESTATICAS Y LAS N DINÁMICAS
        columnaTotalEntregarOriginal = 3 + cuentaSemanas + 7
        columnaSalario = 3 + cuentaSemanas + 8
        columnaIdPrestamo = 3 + cuentaSemanas + 9
        columnaSaldoPrestamo = columnaIdPrestamo + 1
        columnaAbono = columnaSaldoPrestamo + 1
        columnaAbonoResp = columnaAbono + 1
        columnaNuevoSaldo = columnaAbonoResp + 2
        columnaTotalEntregar = columnaNuevoSaldo + 1

        columnaTotalEntregarOriginal = columnaSalario - 1

    End Sub

    Public Sub llenarTablaCierre()
        btnGuardar.Enabled = True
        grdCierre2.Rows.Clear()
        Dim reporteSemanasBU As New Negocios.ReporteCajaAhorroBU
        Dim prestamosBU As New Negocios.SolicitudPrestamoBU
        Dim colaboradorRealBU As New Negocios.ColaboradorRealBU
        Dim listaColaboradores As New List(Of Entidades.ColaboradorLaboral)
        Dim semanasGanadas As DataTable
        Dim contador As Int32 = 1
        Dim cajasRecorridasInicio As Int32 = 0
        listaSemanas = New List(Of Entidades.PeriodosNomina)

        listaColaboradores = reporteSemanasBU.ConsultaColaboradoresCajaCierre(IdCajaAhorro)
        listaSemanas = reporteSemanasBU.ConsultaSemanasCaja(IdCajaAhorro)
        cajasRecorridasInicio = reporteSemanasBU.consultaCajaAhorroRecorridas(IdCajaAhorro)
        listaPrestamos = prestamosBU.ListaPrestamosCobrar(idNave)

        Dim cuentaColaboradores As Int32 = 1

        For Each col As Entidades.ColaboradorLaboral In listaColaboradores
            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow
            'Dim SemanaIngreso As Integer

            celda = New DataGridViewTextBoxCell
            celda.Value = col.PColaboradorId.PColaboradorid
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = cuentaColaboradores
            cuentaColaboradores = cuentaColaboradores + 1
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = col.PColaboradorId.PNombre.ToUpper + " " + col.PColaboradorId.PApaterno.ToUpper + " " + col.PColaboradorId.PAmaterno.ToUpper
            fila.Cells.Add(celda)

            'POR CADA UNA DE LAS SEMANAS CONSULTA SI ES GANADA O PERDIDA
            Dim cont As Int32 = 0
            'If col.PColaboradorId.PColaboradorid = 147 Then
            '    cont = 0
            'End If

            semanasGanadas = reporteSemanasBU.consultaSemanasGanadasCol(col.PColaboradorId.PColaboradorid, IdCajaAhorro)

            For Each semana As Entidades.PeriodosNomina In listaSemanas
                celda = New DataGridViewTextBoxCell
                Dim var1, var2 As String
                Dim var3 As Int32

                If cont >= semanasGanadas.Rows.Count Then
                    var1 = 0
                    var2 = 0
                    var3 = 0
                Else
                    var1 = semanasGanadas.Rows(cont).Item("ccpc_PeriodoId").ToString
                    var2 = semanasGanadas.Rows(cont).Item("ccheck_caja_ahorro").ToString
                    var3 = CDec(semanasGanadas.Rows(cont).Item("ccpc_MontoAhorro").ToString)
                End If

                If var1 = semana.PPeriodoId.ToString And var2 = True And var3 > 0 Then
                    celda.Value = "SI"
                    cont = cont + 1
                ElseIf var1 = semana.PPeriodoId And var2 = False And var3 > 0 Then
                    celda.Value = "NO"
                    cont = cont + 1
                ElseIf var1 = semana.PPeriodoId And var2 = False And var3 = 0 Then
                    celda.Value = "-"
                    cont = cont + 1
                ElseIf var1 = semana.PPeriodoId And var2 = True And var3 = 0 Then
                    celda.Value = "-"
                    cont = cont + 1
                Else
                    celda.Value = "-"
                End If

                fila.Cells.Add(celda)
            Next


            'AGREGA EL MONTO DE AHORRO SEMANAL POR COLABORADOR
            Dim montoAhorroSemanal As Double = 0
            montoAhorroSemanal = reporteSemanasBU.BuscaMontoAhorroColaborador(IdCajaAhorro, col.PColaboradorId.PColaboradorid)
            sumaMontoAhorro = sumaMontoAhorro + montoAhorroSemanal
            celda = New DataGridViewTextBoxCell
            celda.Value = montoAhorroSemanal.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA SUMA DE SEMANAS AHORRADAS
            Dim SemanasAhorradas = reporteSemanasBU.CountSemanasAhorradas(col.PColaboradorId.PColaboradorid, IdCajaAhorro)
            celda = New DataGridViewTextBoxCell
            celda.Value = SemanasAhorradas
            fila.Cells.Add(celda)

            'AGREGA  SUMATORIA DE SEMANAS GANADAS
            Dim semanasGanadasT As Int32 = 0
            celda = New DataGridViewTextBoxCell
            semanasGanadasT = reporteSemanasBU.CountSemanasGanadas(col.PColaboradorId.PColaboradorid, IdCajaAhorro, 1).ToString
            celda.Value = semanasGanadasT
            fila.Cells.Add(celda)

            Dim semanasPerdidas As Int32 = 0

            'AGREGA  SUMATORIA DE SEMANAS PERDIDAS
            celda = New DataGridViewTextBoxCell
            'celda.Value = sumaSemanasAhorradas - sumaSemanas
            semanasPerdidas = reporteSemanasBU.CountSemanasGanadas(col.PColaboradorId.PColaboradorid, IdCajaAhorro, 2)
            celda.Value = semanasPerdidas
            fila.Cells.Add(celda)

            'AGREGA EL PORCENTAJE GANADO
            'SI EL COLABORADOR NO AHORRÓ TODAS LAS SEMANAS DESDE EL INICIO OBTIENE EL PORCENTAJE MINIMO
            'SI AHORRO DESDE EL INICIO DE LA CAJA DE AHORRO SE BUSCA EL INTERÉS GANADO DE ACUERDO A SUS SEMANAS GANADAS
            Dim interes As Int32 = 0
            celda = New DataGridViewTextBoxCell

            'If ganoInteres = True Then
            interes = reporteSemanasBU.BuscaInteresGanado(IdCajaAhorro, semanasPerdidas)
            'Else
            'interes = reporteSemanasBU.BuscaInteresGanado(IdCajaAhorro, 12)
            'End If
            celda.Value = interes.ToString("N0") + "%"
            porcentajeInteresTotal = porcentajeInteresTotal + interes
            fila.Cells.Add(celda)

            'BUSCA EL MONTO DE AHORRO ACUMULADO
            Dim montoAcumulado As Double = 0
            montoAcumulado = reporteSemanasBU.BuscaMontoAcumulado(IdCajaAhorro, col.PColaboradorId.PColaboradorid)
            sumaAcumulado = sumaAcumulado + montoAcumulado
            celda = New DataGridViewTextBoxCell
            celda.Value = montoAcumulado.ToString("N0")
            fila.Cells.Add(celda)

            'CALCULA EL MONTO DE LOS INTERESES GANADOS EN BASE EL % DE INTERES GANADO
            Dim interesesGanados As Double = 0
            interesesGanados = reporteSemanasBU.CalcularInteresTotal(IdCajaAhorro, col.PColaboradorId.PColaboradorid, interes)
            celda = New DataGridViewTextBoxCell
            sumaIntereses = sumaIntereses + interesesGanados
            celda.Value = interesesGanados.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA COLUMNA PARA MOSTRAR EL TOTAL DE AHORRADO + INTERESES GANADOS
            Dim totalCajaAhorro As Double = 0
            totalCajaAhorro = montoAcumulado + interesesGanados
            sumaTotalCaja = sumaTotalCaja + totalCajaAhorro
            celda = New DataGridViewTextBoxCell
            celda.Value = totalCajaAhorro.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA COLUMNA SALARIO
            Dim salario As Double = 0
            Dim colaboradorReal As New Entidades.ColaboradorReal
            colaboradorReal = colaboradorRealBU.BuscarColaboradorReal(col.PColaboradorId.PColaboradorid)
            salario = colaboradorReal.PCantidad
            celda = New DataGridViewTextBoxCell
            celda.Value = colaboradorReal.PCantidad.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA COLUMNA OCULTA CON ID DEL PRESTAMO
            Dim idprestamo As String
            idprestamo = buscaIdPrestamo(col.PColaboradorId.PColaboradorid)
            celda = New DataGridViewTextBoxCell
            celda.Value = idprestamo.ToString
            fila.Cells.Add(celda)

            'AGREGA COLUMNA CON EL ADEUDO TOTAL DE PRESTAMO
            Dim saldoPrestamo As Double = 0
            saldoPrestamo = buscarPrestamoColaborador(col.PColaboradorId.PColaboradorid)
            sumaSaldoPrestamos = sumaSaldoPrestamos + saldoPrestamo
            celda = New DataGridViewTextBoxCell
            celda.Value = saldoPrestamo.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA COLUMNA DE ABONO CON EL DEFAULT EN CEROS
            Dim abonoPrestamo As Double = 0
            Dim estatusAbono As Int32 = 0
            'BUSCA ABONO GUARDADO TEMPORALMENTE
            abonoPrestamo = reporteSemanasBU.BuscaMontoAbonoTemporal(col.PColaboradorId.PColaboradorid, IdCajaAhorro)
            If abonoPrestamo = -1 Then
                If saldoPrestamo > 0 Then
                    If totalCajaAhorro <= salario + saldoPrestamo Then
                        abonoPrestamo = totalCajaAhorro - salario
                        If abonoPrestamo < 0 Then
                            abonoPrestamo = 0
                        End If
                    Else
                        abonoPrestamo = saldoPrestamo
                    End If
                Else
                    abonoPrestamo = 0
                End If
            Else
                estatusAbono = 1
            End If

            sumaAbonoPrestamos = sumaAbonoPrestamos + abonoPrestamo
            celda = New DataGridViewTextBoxCell
            celda.Value = abonoPrestamo.ToString("N0")
            fila.Cells.Add(celda)
            If abonoPrestamo = 0 Then
                celda.ReadOnly = True
            End If


            celda = New DataGridViewTextBoxCell
            celda.Value = abonoPrestamo
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = estatusAbono
            fila.Cells.Add(celda)

            'AGREGA COLUMNA CON EL NUEVO SALDO DEL PRESTAMO
            Dim nuevoSaldoPrestamo As Double = 0
            nuevoSaldoPrestamo = saldoPrestamo - abonoPrestamo
            sumaNuevosSaldos = sumaNuevosSaldos + nuevoSaldoPrestamo
            celda = New DataGridViewTextBoxCell
            celda.Value = nuevoSaldoPrestamo.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA COLUMNA DE TOTAL A ENTREGAR
            Dim totalEntregar As Double = totalCajaAhorro - abonoPrestamo
            sumaTotalEntregar = sumaTotalEntregar + totalEntregar
            celda = New DataGridViewTextBoxCell
            celda.Value = totalEntregar.ToString("N0")
            fila.Cells.Add(celda)

            'AGREGA NUEVAMENTE EL TOTAL A ENTREGAR
            celda = New DataGridViewTextBoxCell
            celda.Value = totalEntregar
            fila.Cells.Add(celda)

            'AGREGA LA FILA CON TODOS LOS DATOS
            grdCierre2.Rows.Add(fila)
            contador = contador + 1

        Next

        lblInteresGanadoT.Text = (porcentajeInteresTotal / cuentaColaboradores).ToString("N0") + "%"
        lblMontoAcumuladoT.Text = sumaAcumulado.ToString("N0")
        lblTotalInteresesT.Text = sumaIntereses.ToString("N0")
        lblTotalCajaT.Text = sumaTotalCaja.ToString("N0")
        lblSaldoPrestamosT.Text = sumaSaldoPrestamos.ToString("N0")
        lblAbonoT.Text = sumaAbonoPrestamos.ToString("N0")
        lblNuevoSaldoPrestamosT.Text = sumaNuevosSaldos.ToString("N0")
        lblTotalEntregarT.Text = sumaTotalEntregar.ToString("N0")

    End Sub


    Public Sub generarAbonosPrestamos(ByVal prestamo As String, ByVal abonoTotal As Double)
        Dim prestamos() As String
        Dim idPrestamo As Int32
        Dim saldo As Double
        Dim objReporteCajaAhorroBU As New Nomina.Negocios.ReporteCajaAhorroBU
        Dim i As Int32 = 0
        prestamos = prestamo.Split(",")

        For Each pres As Entidades.SolicitudPrestamo In listaPrestamos
            If i < prestamos.Length - 1 Then
                If pres.Pprestamoid.ToString = prestamos(i) Then
                    idPrestamo = prestamos(i)
                    saldo = pres.Psaldo
                    If abonoTotal > saldo Then
                        objReporteCajaAhorroBU.guardarAbonosTemporal(idPrestamo, saldo)
                        abonoTotal = abonoTotal - saldo
                    Else
                        objReporteCajaAhorroBU.guardarAbonosTemporal(idPrestamo, abonoTotal)
                    End If
                    i += 1
                End If
            Else
                Exit Sub
            End If
        Next
    End Sub

    Public Function buscarPrestamoColaborador(ByVal colaboradorId As Int32) As Double
        buscarPrestamoColaborador = 0
        For Each prestamo As Entidades.SolicitudPrestamo In listaPrestamos
            If prestamo.Pcolaborador.PColaboradorid = colaboradorId Then
                buscarPrestamoColaborador += prestamo.Psaldo
            End If
        Next
    End Function

    Public Function buscaIdPrestamo(ByVal colaboradorId As Int32) As String
        buscaIdPrestamo = ""
        For Each prestamo As Entidades.SolicitudPrestamo In listaPrestamos
            If prestamo.Pcolaborador.PColaboradorid = colaboradorId Then
                buscaIdPrestamo += prestamo.Pprestamoid & ","
            End If
        Next
    End Function

    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbGroupCierreAnual.Height = 45


    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbGroupCierreAnual.Height = 143

    End Sub


    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        '1 AGREGAR REGISTRO DEL ABONO AL PRESTAMO
        '2 ACTUALIZAR SALDO DEL PRESTAMO Y NUEVO ESTADO
        '3 GUARDAR DATOS DEL CIERRE DE LA CAJA DE AHORRO

        Dim ObjENTCaja As New Entidades.ReporteCajaAhorro
        Dim OBJENTPrestamos As New Entidades.SolicitudPrestamo
        Dim OBJENTPagoPrestamo As New Entidades.PagosPrestamo
        Dim OBJENTPeriodoNOMINA As New Entidades.PeriodosNomina
        Dim ObjBU As New Negocios.ReporteCajaAhorroBU
        Dim porcentaje As String = ""
        Dim confirmar As New ConfirmarForm
        confirmar.mensaje = "¿Esta seguro que quiere hacer el cierre anual de caja de ahorro? Esta operación será irreversible."
        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                For Each row As DataGridViewRow In grdCierre2.Rows
                    If Not IsNothing(row.Cells("Id").Value) Then
                        ObjENTCaja.pIdColaborador = row.Cells("Id").Value
                        ObjENTCaja.pIdCajaAhorro = IdCajaAhorro
                        ObjENTCaja.pMontoAhorro = CDbl(row.Cells("ColMontoAhorro").Value)
                        ObjENTCaja.PSemanasAhorradas = CDbl(row.Cells("ColSemanasAhorradas").Value)
                        ObjENTCaja.pGanadas = CInt(row.Cells("ColSemanasGanadas").Value)
                        ObjENTCaja.pPerdidas = CInt(row.Cells("ColSemanasPerdidas").Value)
                        porcentaje = row.Cells("ColInteresGanado").Value
                        porcentaje = porcentaje.Replace("%", "")
                        ObjENTCaja.pInteres = CDbl(porcentaje)
                        ObjENTCaja.pAhorrado = CDbl(row.Cells("ColMontoAcumulado").Value)
                        ObjENTCaja.pTotalInteres = CDbl(row.Cells("ColTotalIntereses").Value)
                        ObjENTCaja.pAhorroMasInteres = CDbl(row.Cells("ColTotalCaja").Value)

                        If row.Cells("ColIdPrestamo").Value.trim.ToString <> "" Then
                            OBJENTPrestamos.Pjustificacion = row.Cells("ColIdPrestamo").Value
                            OBJENTPagoPrestamo.PSaldoAnterior = CDbl(row.Cells("ColTotalPrestamo").Value)
                            OBJENTPagoPrestamo.PAbonoCapital = CDbl(row.Cells("ColAbonoPrestamo").Value)
                            OBJENTPagoPrestamo.PSaldoNuevo = row.Cells("ColSaldoPrestamo").Value
                            ObjENTCaja.PPrestamo = True
                        Else

                            OBJENTPrestamos.Pjustificacion = "0"
                            OBJENTPagoPrestamo.PSaldoAnterior = 0
                            OBJENTPagoPrestamo.PAbonoCapital = 0
                            OBJENTPagoPrestamo.PSaldoNuevo = 0
                            ObjENTCaja.PPrestamo = False
                        End If


                        ObjENTCaja.PTotalEntregar = CDbl(row.Cells("ColTotalEntregar").Value)
                        ObjENTCaja.PMontoAcumuladoCajaAnual = CDbl(sumaAcumulado)
                        ObjENTCaja.PMontoAcumuladoInteresCajaAnual = CDbl(sumaIntereses)
                        ObjENTCaja.PMontoAcumuladoCajaMASInteres = CDbl(sumaTotalEntregar)
                        ObjENTCaja.PUsuarioModifico = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        OBJENTPeriodoNOMINA.PPeriodoId = idSemanaActiva

                        ObjENTCaja.PPrestamosPeriodoNomina = OBJENTPeriodoNOMINA
                        ObjENTCaja.PPrestamos = OBJENTPrestamos
                        ObjENTCaja.PPrestamosPago = OBJENTPagoPrestamo

                        ObjBU.CierreAnualCajaAhorro(ObjENTCaja)
                    End If
                Next

                pnlGuardar.Enabled = False

                Dim msj As New ExitoForm
                msj.mensaje = "Se realizó el cierre correctamente"
                msj.ShowDialog()
                Me.Close()
                Dim objCierreAnualCerrada As New frmConsultaCierreAnualCerrada
                objCierreAnualCerrada.idCajaAhorro = IdCajaAhorro
                objCierreAnualCerrada.idNave = idNave
                objCierreAnualCerrada.nombreNave = lblNave.Text
                objCierreAnualCerrada.cajaDeAl = lblConceptoPeriodo.Text
                objCierreAnualCerrada.ShowDialog()
            Catch ex As Exception
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = ex.Message
                mensajeAdvertencia.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub Guardar()
        Try

            Dim objReporteCajaAhorroBU As New Nomina.Negocios.ReporteCajaAhorroBU
            objReporteCajaAhorroBU.CierreAnualCajaAhorro(IdCajaAhorro)

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Registro guardado."
            mensajeExito.ShowDialog()

            Me.Close()

        Catch ex As Exception
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = ex.Message
            mensajeAdvertencia.ShowDialog()
        End Try

    End Sub

    Private Sub btnRegresar_Click(sender As System.Object, e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub


    Private Sub grdCierre2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles grdCierre2.CellEndEdit
        Try
            'RECALCULA EL TOTAL A ENTREGAR
            If (e.ColumnIndex = columnaAbono) Then 'SE HA MODIFICADO LA COLUMNA DE ABONO

                Dim saldoPrestamo As Double = 0
                Dim abonoPrestamo As Double = 0
                Dim abonoPrestamoResp As Double = 0
                Dim nuevoSaldoPrestamo As Double = 0
                Dim totalEntregar As Double = 0
                Dim totalEntregarNuevo As Double = 0
                Dim alerta As New AdvertenciaForm

                'prestamoid = CInt(grdCierre2.Item(columnaIdPrestamo, e.RowIndex).Value.ToString)
                saldoPrestamo = CDbl(grdCierre2.Item(columnaSaldoPrestamo, e.RowIndex).Value.ToString)
                abonoPrestamo = CDbl(grdCierre2.Item(columnaAbono, e.RowIndex).Value.ToString)
                abonoPrestamoResp = CDbl(grdCierre2.Item(columnaAbonoResp, e.RowIndex).Value.ToString)
                nuevoSaldoPrestamo = CDbl(grdCierre2.Item(columnaNuevoSaldo, e.RowIndex).Value.ToString)
                totalEntregar = CDbl(grdCierre2.Item(columnaTotalEntregarOriginal, e.RowIndex).Value.ToString)

                'VALIDA QUE EL ABONO AL PRESTAMO NO SEA MAYOR AL SALDO
                If abonoPrestamo > saldoPrestamo Then
                    alerta.mensaje = "El abono del préstamo es mayor al saldo."
                    alerta.ShowDialog()
                    grdCierre2.Item(columnaAbono, e.RowIndex).Value = abonoPrestamoResp.ToString("N0")
                    nuevoSaldoPrestamo = saldoPrestamo - abonoPrestamoResp
                    totalEntregarNuevo = totalEntregar - abonoPrestamoResp
                Else
                    If abonoPrestamo > totalEntregar Then
                        alerta.mensaje = "El abono del préstamo es mayor al monto de la caja de ahorro."
                        alerta.ShowDialog()
                        grdCierre2.Item(columnaAbono, e.RowIndex).Value = abonoPrestamoResp.ToString("N0")
                        nuevoSaldoPrestamo = saldoPrestamo - abonoPrestamoResp
                        totalEntregarNuevo = totalEntregar - abonoPrestamoResp
                    Else
                        nuevoSaldoPrestamo = saldoPrestamo - abonoPrestamo
                        totalEntregarNuevo = totalEntregar - abonoPrestamo
                    End If

                End If

                grdCierre2.Item(columnaNuevoSaldo, e.RowIndex).Value = nuevoSaldoPrestamo.ToString("N0")
                grdCierre2.Item(columnaTotalEntregar, e.RowIndex).Value = totalEntregarNuevo.ToString("N0")

                ContadorFilas = 0
                sumaAbonoPrestamos = 0
                sumaNuevosSaldos = 0
                sumaTotalEntregar = 0
                For Each row As DataGridViewRow In grdCierre2.Rows
                    If row.Cells("Num").Value.ToString <> " " Then
                        sumaAbonoPrestamos += CDbl(row.Cells("ColAbonoPrestamo").Value)
                        sumaNuevosSaldos += row.Cells("ColSaldoPrestamo").Value
                        sumaTotalEntregar += CDbl(row.Cells("ColTotalEntregar").Value)
                        ContadorFilas += 1
                    End If
                Next

                'grdCierre2.Rows(ContadorFilas).Cells("ColAbonoPrestamo").Value = sumaAbonoPrestamos.ToString("N0")
                'grdCierre2.Rows(ContadorFilas).Cells("ColSaldoPrestamo").Value = sumaNuevosSaldos.ToString("N0")
                'grdCierre2.Rows(ContadorFilas).Cells("ColTotalEntregar").Value = sumaTotalEntregar.ToString("N0")

                lblAbonoT.Text = sumaAbonoPrestamos.ToString("N0")
                lblNuevoSaldoPrestamosT.Text = sumaNuevosSaldos.ToString("N0")
                lblTotalEntregarT.Text = sumaTotalEntregar.ToString("N0")
            Else
                grdCierre2.Item(columnaAbono, e.RowIndex).Value = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Me.grdCierre2.Rows.Clear()
        'Dim confirmar As New ConfirmarForm
        'confirmar.mensaje = "Esta operación puede tardar algunos minutos, ¿Desea continuar?"
        'If confirmar.DialogResult = Windows.Forms.DialogResult.OK Then
        '    Me.Cursor = Cursors.WaitCursor
        '    llenarTablaCierre()
        '    Me.Cursor = Cursors.Default
        'End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim confirmar As New ConfirmarForm
        Dim usuario As Integer
        confirmar.mensaje = "Esta seguro de guardar los cambios. Esta operación no generará el cierre anual."
        If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim objReporteCajaAhorroBU As New Nomina.Negocios.ReporteCajaAhorroBU
            'For Each row As DataGridViewRow In grdCierre2.Rows
            '    If row.Cells("Num").Value.ToString <> " " Then
            '        If CDbl(row.Cells(58).Value) > 0 Then
            '            generarAbonosPrestamos(CInt(row.Cells("ColIdPrestamo").Value), CDbl(row.Cells(58).Value))
            '            'objReporteCajaAhorroBU.guardarAbonosTemporal(CInt(row.Cells("ColIdPrestamo").Value), CDbl(row.Cells(58).Value))
            '        End If
            '    End If
            'Next
            'For Each row As DataGridViewRow In grdCierre2.Rows
            '    If row.Cells("Num").Value.ToString <> " " Then
            '        If CDbl(row.Cells("ColTotalPrestamo").Value) > 0 Then
            '            generarAbonosPrestamos(row.Cells("ColIdPrestamo").Value.ToString, CInt(row.Cells("ColAbonoPrestamo").Value.ToString))
            '        End If
            '    End If
            'Next
            For Each row As DataGridViewRow In grdCierre2.Rows
                If row.Cells("Num").Value.ToString <> " " Then
                    If CDbl(row.Cells("ColTotalPrestamo").Value) > 0 Then
                        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        objReporteCajaAhorroBU.guardarAbonosCierreCaja(CInt(row.Cells("Id").Value), CInt(IdCajaAhorro), CDbl(row.Cells("ColAbonoPrestamo").Value), CInt(row.Cells("ColAbonoGuardado").Value), usuario)
                    End If
                End If
            Next
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Abonos guardados."
            mensajeExito.ShowDialog()
        End If
    End Sub

    Private Sub ReporteAnualDeCajaDeAhorroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteAnualDeCajaDeAhorroToolStripMenuItem.Click
        ejecutarReporteResumenAnual()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        menuImprimir.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub


    Private Sub chkVerDetalleSemanas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerDetalleSemanas.CheckedChanged
        If grdCierre2.Columns.Count > 0 Then
            If chkVerDetalleSemanas.Checked = True Then
                For i As Int32 = 3 To grdCierre2.Columns.Count - 18
                    grdCierre2.Columns(i).Visible = True
                Next
            Else
                For i As Int32 = 3 To grdCierre2.Columns.Count - 18
                    grdCierre2.Columns(i).Visible = False
                Next
            End If
        End If
    End Sub

    Private Sub chkResumen_CheckedChanged(sender As Object, e As EventArgs) Handles chkResumen.CheckedChanged
        If grdCierre2.Columns.Count > 0 Then
            Dim totColumnas As Int32 = 0
            totColumnas = grdCierre2.Columns.Count
            If chkResumen.Checked = True Then
                grdCierre2.Columns(totColumnas - 12).Visible = True
                grdCierre2.Columns(totColumnas - 13).Visible = True
                grdCierre2.Columns(totColumnas - 14).Visible = True
            Else
                grdCierre2.Columns(totColumnas - 12).Visible = False
                grdCierre2.Columns(totColumnas - 13).Visible = False
                grdCierre2.Columns(totColumnas - 14).Visible = False
            End If
        End If
    End Sub

    Private Sub chkTotales_CheckedChanged(sender As Object, e As EventArgs) Handles chkTotales.CheckedChanged
        If grdCierre2.Columns.Count > 0 Then
            Dim totColumnas As Int32 = 0
            totColumnas = grdCierre2.Columns.Count
            If chkTotales.Checked = True Then
                pnlTotales.Visible = True
                'grdCierre2.Columns(totColumnas - 15).Visible = True
                'grdCierre2.Columns(totColumnas - 11).Visible = True
                'grdCierre2.Columns(totColumnas - 10).Visible = True
                'grdCierre2.Columns(totColumnas - 9).Visible = True
                'grdCierre2.Columns(totColumnas - 8).Visible = True
                'grdCierre2.Columns(totColumnas - 7).Visible = True
                'grdCierre2.Columns(totColumnas - 6).Visible = True
                'grdCierre2.Columns(totColumnas - 5).Visible = True
                'grdCierre2.Columns(totColumnas - 4).Visible = True
                'grdCierre2.Columns(totColumnas - 3).Visible = True
                'grdCierre2.Columns(totColumnas - 2).Visible = True
                'grdCierre2.Columns(totColumnas - 1).Visible = True
            Else
                pnlTotales.Visible = False
                'grdCierre2.Columns(totColumnas - 15).Visible = False
                'grdCierre2.Columns(totColumnas - 11).Visible = False
                'grdCierre2.Columns(totColumnas - 10).Visible = False
                'grdCierre2.Columns(totColumnas - 9).Visible = False
                'grdCierre2.Columns(totColumnas - 8).Visible = False
                'grdCierre2.Columns(totColumnas - 7).Visible = False
                'grdCierre2.Columns(totColumnas - 6).Visible = False
                'grdCierre2.Columns(totColumnas - 5).Visible = False
                'grdCierre2.Columns(totColumnas - 4).Visible = False
                'grdCierre2.Columns(totColumnas - 3).Visible = False
                'grdCierre2.Columns(totColumnas - 2).Visible = False
                'grdCierre2.Columns(totColumnas - 1).Visible = False
            End If
        End If
    End Sub

    Private Sub grdCierre2_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles grdCierre2.SortCompare
        If e.Column.Name = "Colaborador" Then
            e.SortResult = System.String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
        Else
            If e.CellValue1.ToString.Trim = "" Or e.CellValue2.ToString.Trim = "" Then
            Else
                If CInt(e.CellValue1) > CInt(e.CellValue2) Then
                    e.SortResult = 1
                ElseIf CInt(e.CellValue1) < CInt(e.CellValue2) Then
                    e.SortResult = -1
                ElseIf CInt(e.CellValue1) = CInt(e.CellValue2) Then
                    e.SortResult = 0
                End If
            End If
        End If

        If (e.SortResult = 0) AndAlso Not (e.Column.Name = "Num") Then
            e.SortResult = System.String.Compare( _
                grdCierre2.Rows(e.RowIndex1).Cells("Num").Value.ToString(), _
                grdCierre2.Rows(e.RowIndex2).Cells("Num").Value.ToString())
        End If

        e.Handled = True

    End Sub

    Public Sub SemanaNomina()
        Try
            Dim SemanaNominaActiva As New List(Of Entidades.CobranzaPrestamos)
            Dim SenamaActivaBu As New Nomina.Negocios.CobranzaPrestamosBU
            'Dim idNave As Integer
            'idNave = (idNave)
            SemanaNominaActiva = SenamaActivaBu.SemanaNominaActiva(idNave)

            For Each objeto As Entidades.CobranzaPrestamos In SemanaNominaActiva
                idSemanaActiva = objeto.PsemanaNominaId
            Next

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub ImpresionDeSobresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpresionDeSobresToolStripMenuItem.Click
    '    Try

    '        Dim dtimpresionsobres As New DataTable
    '        dtimpresionsobres.Columns.Add("#")
    '        dtimpresionsobres.Columns.Add("colaborador")

    '        For Each row As System.Windows.Forms.DataGridViewRow In grdCierre2.Rows
    '            dtimpresionsobres.Rows.Add(row.Cells("Num").Value, row.Cells("Colaborador").Value)
    '        Next

    '        Me.Cursor = Cursors.WaitCursor
    '        Dim OBJBU As New Framework.Negocios.ReportesBU
    '        Dim EntidadReporte As Entidades.Reportes
    '        EntidadReporte = OBJBU.LeerReporteporClave("NOM_IMP_SOBRES")
    '        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
    '        EntidadReporte.Pnombre + ".mrt"
    '        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

    '        Dim reporte As New StiReport
    '        reporte.Load(archivo)
    '        reporte.Compile()
    '        reporte.RegData(dtimpresionsobres)
    '        reporte.Show()
    '        Me.Cursor = Cursors.Default

    '        ImpresionDeSobresToolStripMenuItem.Enabled = False

    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString)
    '    End Try
    'End Sub
End Class