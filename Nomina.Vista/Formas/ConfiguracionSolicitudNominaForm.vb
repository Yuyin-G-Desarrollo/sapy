Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ConfiguracionSolicitudNominaForm

    Public Sub cargarInformacion()
        Dim objBu As New Negocios.ConfiguracionNaveNominaBU
        Dim dtSolicitudes As New DataTable
        grdSolicitudes.DataSource = Nothing
        Dim fechaConf As String = ""
        Dim fecha As Date

        If txtSemana.Text = "" Then
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Debes ingresar un número de semana"
            advertencia.ShowDialog()
        Else
            dtSolicitudes = objBu.ConfiguracionSolicitudFinanzasNomina()
            If dtSolicitudes.Rows.Count > 0 Then
                If dtSolicitudes.Rows(0).Item("fecha").ToString <> "" Then
                    fecha = dtSolicitudes.Rows(0).Item("fecha").ToString
                    fechaConf = fecha.ToLongDateString.ToString
                Else
                    fechaConf = ""
                End If
                lblFecha.Text = fechaConf
                grdSolicitudes.DataSource = dtSolicitudes
                formatoGrid()
            End If
        End If

    End Sub

    Public Sub guardarConfiguracion()
        Dim cont As Int32 = 0
        Dim tipoSolicitud As String = ""


        Dim objBu As New Negocios.ConfiguracionNaveNominaBU
        Dim beneficiario As String = ""
        Dim usuarioModifica As Integer = 0
        Dim dtActualizaConfiguracion As New DataTable
        usuarioModifica = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioCreoId

        Try

            For Each row As UltraGridRow In grdSolicitudes.Rows
                tipoSolicitud = ""
                If CBool(row.Cells("efectivo").Value) = True And
                   CBool(row.Cells("cheque").Value) = False And
                   CBool(row.Cells("ChequeCheque").Value) = True And
                   CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    tipoSolicitud = "B" 'Efectivo y cheque

                ElseIf CBool(row.Cells("efectivo").Value) = True And
                       CBool(row.Cells("cheque").Value) = False And
                       CBool(row.Cells("ChequeCheque").Value) = False And
                       CBool(row.Cells("ChequeEfectivo").Value) = True Then
                    tipoSolicitud = "A" 'efectivo

                    'ElseIf CBool(row.Cells("cheque").Value) = True And
                    '       CBool(row.Cells("efectivo").Value) = False And
                    '       CBool(row.Cells("ChequeCheque").Value) = False And
                    '       CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    '    tipoSolicitud = "B" 'cheque

                ElseIf CBool(row.Cells("ChequeCheque").Value) = True And
                       CBool(row.Cells("cheque").Value) = True And
                       CBool(row.Cells("efectivo").Value) = False And
                       CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    tipoSolicitud = "C" 'Pago Neto Depósito en Cheque y Efectivo en Cheque

                ElseIf CBool(row.Cells("cheque").Value) = True And
                       CBool(row.Cells("ChequeEfectivo").Value) = True And
                       CBool(row.Cells("ChequeCheque").Value) = False And
                       CBool(row.Cells("efectivo").Value) = False Then
                    tipoSolicitud = "D" 'Pago Neto Depósito en Cheque y Pago Neto Efectivo

                ElseIf CBool(row.Cells("efectivo").Value) = False And
                       CBool(row.Cells("cheque").Value) = False And
                       CBool(row.Cells("ChequeCheque").Value) = False And
                       CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    tipoSolicitud = ""
                End If

                If tipoSolicitud.Equals("B") Or tipoSolicitud.Equals("C") Or tipoSolicitud.Equals("D") Then
                    If row.Cells("beneficiario").Value = " " Or row.Cells("beneficiario").Value = "" Then
                        Dim advertencia As New AdvertenciaForm
                        advertencia.mensaje = "Es necesario ingresar un beneficiario para la configuración en cheque. La configuración no será guardada"
                        advertencia.ShowDialog()
                        Exit Sub
                    End If
                End If
            Next

            For Each row As UltraGridRow In grdSolicitudes.Rows

                If CBool(row.Cells("efectivo").Value) = True And
                   CBool(row.Cells("cheque").Value) = False And
                   CBool(row.Cells("ChequeCheque").Value) = True And
                   CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    tipoSolicitud = "B" 'Efectivo y cheque

                ElseIf CBool(row.Cells("efectivo").Value) = True And
                       CBool(row.Cells("cheque").Value) = False And
                       CBool(row.Cells("ChequeCheque").Value) = False And
                       CBool(row.Cells("ChequeEfectivo").Value) = True Then
                    tipoSolicitud = "A" 'efectivo

                    'ElseIf CBool(row.Cells("cheque").Value) = True And
                    '       CBool(row.Cells("efectivo").Value) = False And
                    '       CBool(row.Cells("ChequeCheque").Value) = False And
                    '       CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    '    tipoSolicitud = "B" 'cheque

                ElseIf CBool(row.Cells("ChequeCheque").Value) = True And
                       CBool(row.Cells("cheque").Value) = True And
                       CBool(row.Cells("efectivo").Value) = False And
                       CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    tipoSolicitud = "C" 'Pago Neto Depósito en Cheque y Efectivo en Cheque

                ElseIf CBool(row.Cells("cheque").Value) = True And
                       CBool(row.Cells("ChequeEfectivo").Value) = True And
                       CBool(row.Cells("ChequeCheque").Value) = False And
                       CBool(row.Cells("efectivo").Value) = False Then
                    tipoSolicitud = "D" 'Pago Neto Depósito en Cheque y Pago Neto Efectivo

                ElseIf CBool(row.Cells("efectivo").Value) = False And
                       CBool(row.Cells("cheque").Value) = False And
                       CBool(row.Cells("ChequeCheque").Value) = False And
                       CBool(row.Cells("ChequeEfectivo").Value) = False Then
                    tipoSolicitud = ""
                End If


                beneficiario = row.Cells("beneficiario").Value.ToString
                dtActualizaConfiguracion = objBu.actualizarConfiguracionSolicitudes(row.Cells("pnom_PeriodoNomId").Value, tipoSolicitud, row.Cells("pnom_naveid").Value, beneficiario, usuarioModifica)
            Next


            Dim exito As New ExitoForm
            exito.mensaje = "Configuración de naves guardada correctamente"
            exito.ShowDialog()
        Catch ex As Exception
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Algo surgio mal durante el proceso"
            advertencia.ShowDialog()
        End Try

    End Sub

    Public Sub obtenerNumeroSemanaActual()
        Dim dtSemana As New DataTable
        Dim objBu As New Negocios.ConfiguracionNaveNominaBU
        Dim noSemana As String = ""
        Dim fechaConf As String = ""
        Dim fecha As Date
        dtSemana = objBu.obtenerSemanaActualConfiguracionNomina
        If dtSemana.Rows.Count > 0 Then
            noSemana = dtSemana.Rows(0).Item("pnom_NoSemanaNomina").ToString
            If dtSemana.Rows(0).Item("fecha").ToString <> "" Then
                fecha = dtSemana.Rows(0).Item("fecha").ToString
                fechaConf = fecha.ToLongDateString.ToString
            Else
                fechaConf = ""
            End If

        End If
        txtSemana.Text = noSemana
        lblFecha.Text = fechaConf
        cargarInformacion()
    End Sub
    Public Sub formatoGrid()
        With grdSolicitudes.DisplayLayout.Bands(0)
            .Columns("pnom_FechaInicial").Hidden = True
            .Columns("anioNomina").Hidden = True
            .Columns("anioActual").Hidden = True
            .Columns("tipoPago").Hidden = True
            'Nuevo
            '.Columns("tipoPagoEfectivo").Hidden = True
            .Columns("pnom_PeriodoNomId").Hidden = True
            .Columns("pnom_NaveId").Hidden = True
            .Columns("Inicial").Hidden = True
            .Columns("pnom_FechaFinal").Hidden = True
            '.Columns("fecha").Hidden = True

            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("Efectivo").Header.Caption = "Depósito Efectivo"
            .Columns("cheque").Header.Caption = "Depósito Cheque"
            .Columns("beneficiario").Header.Caption = "Beneficiario"
            .Columns("fecha").Header.Caption = "Fecha Actualización"

            'Nuevo
            .Columns("ChequeCheque").Header.Caption = "Efectivo Cheque "
            .Columns("ChequeEfectivo").Header.Caption = "Efectivo"


            .Columns("nave_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tipoPago").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'Nuevo
            '.Columns("tipoPagoEfectivo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit



            .Columns("cheque").Style = ColumnStyle.CheckBox
            .Columns("efectivo").Style = ColumnStyle.CheckBox

            .Columns("cheque").AllowRowFiltering = DefaultableBoolean.False
            .Columns("efectivo").AllowRowFiltering = DefaultableBoolean.False

            'Nuevo
            .Columns("ChequeCheque").Style = ColumnStyle.CheckBox
            .Columns("ChequeEfectivo").Style = ColumnStyle.CheckBox
            .Columns("ChequeCheque").AllowRowFiltering = DefaultableBoolean.False
            .Columns("ChequeEfectivo").AllowRowFiltering = DefaultableBoolean.False



            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdSolicitudes.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdSolicitudes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdSolicitudes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSolicitudes.DisplayLayout.Override.RowSelectorWidth = 35
        grdSolicitudes.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSolicitudes.Rows(0).Selected = True

        grdSolicitudes.DisplayLayout.Bands(0).Columns("nave_nombre").Width = 65
        grdSolicitudes.DisplayLayout.Bands(0).Columns("cheque").Width = 30
        grdSolicitudes.DisplayLayout.Bands(0).Columns("efectivo").Width = 30
        grdSolicitudes.DisplayLayout.Bands(0).Columns("beneficiario").Width = 70
        grdSolicitudes.DisplayLayout.Bands(0).Columns("fecha").Width = 40

        'Nuevo
        grdSolicitudes.DisplayLayout.Bands(0).Columns("ChequeCheque").Width = 30
        grdSolicitudes.DisplayLayout.Bands(0).Columns("ChequeEfectivo").Width = 30

        grdSolicitudes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        SeleccionarChecks()

    End Sub

    Public Sub SeleccionarChecks()
        For cont = 0 To grdSolicitudes.Rows.Count - 1
            If grdSolicitudes.Rows(cont).Cells("tipoPago").Value = "A" Then ' Efectivo
                grdSolicitudes.Rows(cont).Cells("efectivo").Value = True
                grdSolicitudes.Rows(cont).Cells("ChequeEfectivo").Value = True

            ElseIf grdSolicitudes.Rows(cont).Cells("tipoPago").Value = "B" Then 'cheque
                grdSolicitudes.Rows(cont).Cells("efectivo").Value = True
                grdSolicitudes.Rows(cont).Cells("ChequeCheque").Value = True

            ElseIf grdSolicitudes.Rows(cont).Cells("tipoPago").Value = "C" Then 'Cheque ambos conceptos
                grdSolicitudes.Rows(cont).Cells("cheque").Value = True
                grdSolicitudes.Rows(cont).Cells("ChequeCheque").Value = True

            ElseIf grdSolicitudes.Rows(cont).Cells("tipoPago").Value = "D" Then 'Cheque/Efectivo
                grdSolicitudes.Rows(cont).Cells("cheque").Value = True
                grdSolicitudes.Rows(cont).Cells("ChequeEfectivo").Value = True

            ElseIf grdSolicitudes.Rows(cont).Cells("tipoPago").Value = "" Then 'Configuración Vacía 
                grdSolicitudes.Rows(cont).Cells("cheque").Value = False
                grdSolicitudes.Rows(cont).Cells("ChequeEfectivo").Value = False
                grdSolicitudes.Rows(cont).Cells("efectivo").Value = False
                grdSolicitudes.Rows(cont).Cells("ChequeCheque").Value = False
            End If
        Next
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltroSolicitudes.Height = 97
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltroSolicitudes.Height = 40
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdSolicitudes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdSolicitudes.InitializeRow
        If e.Row.Cells("cheque").Value = True Then
            e.Row.Cells("cheque").Value = True
            e.Row.Cells("efectivo").Value = False

        End If

        If e.Row.Cells("ChequeCheque").Value = True Then
            e.Row.Cells("ChequeCheque").Value = True
            e.Row.Cells("ChequeEfectivo").Value = False
        End If

    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        grdSolicitudes.DataSource = Nothing
        txtSemana.Text = ""
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        cargarInformacion()
    End Sub

    Private Sub txtSemana_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSemana.KeyDown
        If (e.KeyValue = Keys.Enter) Then
            cargarInformacion()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarConfiguracion()
    End Sub

    Private Sub ConfiguracionSolicitudNominaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Top = 0
        Me.Left = 0
        obtenerNumeroSemanaActual()
    End Sub


End Class