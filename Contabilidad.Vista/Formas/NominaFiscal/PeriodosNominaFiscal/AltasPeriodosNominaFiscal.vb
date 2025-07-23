Imports System.Drawing
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class AltasPeriodosNominaFiscal
    Public guardado As Boolean = False
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim mensajeAdv As New Tools.AdvertenciaForm
        Dim dtPeriodos As New DataTable

        If cmbPatron.SelectedIndex = 0 Then
            mensajeAdv.mensaje = "Favor de elegir un patrón correcto."
            mensajeAdv.ShowDialog()
        ElseIf dtpFechaIni.Value >= dtpFechaFin.Value Then
            mensajeAdv.mensaje = "La Fecha Final no puede ser igual o menor a la Fecha Inicial."
            mensajeAdv.ShowDialog()
        'ElseIf dtpFechaPago.Value < dtpFechaFin.Value Then
        '    mensajeAdv.mensaje = "La Fecha de Pago no puede ser menor a la Fecha Final."
        '    mensajeAdv.ShowDialog()
        Else
            If objBU.VerificaPeriodo(cmbPatron.SelectedValue, dtpFechaIni.Value, dtpFechaFin.Value, 0) = False Then

                grdPeriodos.DataSource = Nothing
                dtPeriodos = objBU.calcularPeriodos(cmbPatron.SelectedValue, numSemana.Value, dtpFechaIni.Value, dtpFechaFin.Value, dtpFechaPago.Value, rdoTodos.Checked)
                If Not dtPeriodos Is Nothing AndAlso dtPeriodos.Rows.Count > 0 Then

                    Dim llenar As Boolean = True
                    For Each row As DataRow In dtPeriodos.Rows
                        If objBU.VerificaPeriodo(cmbPatron.SelectedValue, CDate(row.Item("FechaInicio")), CDate(row.Item("FechaFin")), 0) Then
                            llenar = False
                            Exit For
                        End If
                    Next

                    If llenar Then
                        grdPeriodos.DataSource = dtPeriodos
                        formatoGrid()
                    Else
                        mensajeAdv.mensaje = "Ya existen periodos en el rango seleccionado."
                        mensajeAdv.ShowDialog()
                    End If

                End If

            Else
                mensajeAdv.mensaje = "Ya existen periodos en el rango seleccionado."
                mensajeAdv.ShowDialog()
            End If

        End If

    End Sub

    Public Sub formatoGrid()
        grdPeriodos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdPeriodos.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

        With grdPeriodos.DisplayLayout.Bands(0)
            .Override.CellClickAction = CellClickAction.RowSelect

            .Columns("FechaInicio").Header.Caption = "Fecha Inicio"
            .Columns("FechaFin").Header.Caption = "Fecha Fin"
            .Columns("FechaPago").Header.Caption = "Fecha Pago"
            .Columns("BimestreI").Header.Caption = "Bimestre"
            .Columns("BimestreF").Hidden = True

        End With

        grdPeriodos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdPeriodos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPeriodos.DisplayLayout.Override.RowSelectorWidth = 35
        grdPeriodos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        grdPeriodos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdPeriodos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        Me.grdPeriodos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
        Me.grdPeriodos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden
        grdPeriodos.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti

    End Sub


    Private Sub AltasPeriodosNominaFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaIni.Value = Date.Today
        dtpFechaFin.Value = Date.Today
        dtpFechaPago.Value = Date.Today
        numSemana.Value = 1
        numRetardos.Value = 2
        numFaltas.Value = 0
        numFaltasSemana.Value = 6

        cargarPatrones()
    End Sub

    Private Sub cargarPatrones()
        Dim objBU As New Negocios.PeriodosNominaFiscalBU
        Dim dtPatrones As New DataTable

        dtPatrones = objBU.cargarPatrones
        If dtPatrones.Rows.Count > 0 Then
            dtPatrones.Rows.InsertAt(dtPatrones.NewRow, 0)
            cmbPatron.DataSource = dtPatrones
            cmbPatron.DisplayMember = "PATRON"
            cmbPatron.ValueMember = "ID"
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If grdPeriodos.Rows.Count > 0 Then
            Dim mensajeConf As New Tools.ConfirmarForm
            Dim objBU As New Negocios.PeriodosNominaFiscalBU
            Dim filasGuardar As Integer = 0
            Dim filasGuardadas As Integer = 0

            mensajeConf.mensaje = "Es necesario verificar que la configuración de faltas sea correcta. ¿Está seguro de guardar esta configuración?"
            mensajeConf.ShowDialog()

            If mensajeConf.DialogResult = Windows.Forms.DialogResult.OK Then
                For Each row As UltraGridRow In grdPeriodos.Rows
                    Dim objPeriodo As New Entidades.PeriodoNominaFiscal
                    Dim mensaje As String = String.Empty

                    filasGuardar += 1

                    With objPeriodo
                        .PIdPeriodo = 0
                        .PIdPatron = cmbPatron.SelectedValue
                        .PFechaIni = row.Cells("FechaInicio").Value
                        .PFechaFin = row.Cells("FechaFin").Value
                        .PNumSemana = row.Cells("Semana").Value
                        .PFechaPago = row.Cells("FechaPago").Value
                        .PRetardos = numRetardos.Value
                        .PFaltas = numFaltas.Value
                        .PFAltasSem = numFaltasSemana.Value
                        .PDiasNomina = NumDiasNomina.Value
                        .PBimestre = row.Cells("BimestreI").Value
                    End With

                    mensaje = objBU.AltaEdicionPeriodo(objPeriodo)
                    If mensaje = "EXITO" Then
                        filasGuardadas += 1
                    End If

                Next

                If filasGuardadas = filasGuardar Then
                    Dim mensajeExito As New Tools.ExitoForm
                    mensajeExito.mensaje = "Se guardaron correctamente los periodos de nómina fiscal."
                    mensajeExito.ShowDialog()

                    guardado = True
                    Me.Close()
                Else
                    Dim mensajeAdv As New Tools.AdvertenciaForm
                    mensajeAdv.mensaje = "No se guardaron correctamente todos los periodos de nómina fiscal. Favor de consultar a sistemas."
                    mensajeAdv.ShowDialog()
                End If

            End If
        Else
            Dim mensajeAdv As New Tools.AdvertenciaForm
            mensajeAdv.mensaje = "No existe información para guardar."
            mensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

End Class