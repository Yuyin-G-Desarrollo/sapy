Public Class frmConsultaSimulacion

    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                exportExcelDetalle.Export(grdPedidos, fileName)
                Process.Start(fileName)
                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")
            End Try
        End If
    End Sub

    Public Sub llenarComboFoliosSimulacion()
        Dim objSimBU As New Negocios.SimulacionBU
        Dim dt As New DataTable
        dt = objSimBU.consultaFoliosSimulacion
        If dt.Rows.Count > 0 Then
            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbFoliosSimulacion.DataSource = dt
            cmbFoliosSimulacion.DisplayMember = "Descripcion"
            cmbFoliosSimulacion.ValueMember = "sprf_simulacionFolioId"
        End If
    End Sub

    Public Sub llenarComboNavesLineas()
        Dim objBu As New Negocios.LineasProduccionBU
        Dim dt As New DataTable
        dt = objBu.comboLineas(True)
        If dt.Rows.Count > 0 Then
            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbNavesLineas.DataSource = dt
            cmbNavesLineas.ValueMember = "ID"
            cmbNavesLineas.DisplayMember = "Descripcion"
        End If
    End Sub

    Public Sub llenarTabla()
        Me.Cursor = Cursors.WaitCursor
        Dim dt As New DataTable
        Dim sInicio As Int32 = 1, sfin As Int32 = 52, idNave As Int32 = 0, idLinea As Int32 = 0

        grdPedidos.DataSource = Nothing

        If chkConCantidad.Checked = True Then
            sInicio = numSemanaInicio.Value
            sfin = numSemanaFin.Value
        End If
        If cmbNavesLineas.SelectedIndex > 0 Then
            idNave = cmbNavesLineas.SelectedItem("idNave")
            idLinea = cmbNavesLineas.SelectedValue
        End If

        If chkSimulador.Checked = False Then
            Dim objProgsBU As New Negocios.ProgramasBU
            dt = objProgsBU.consultaProgramaRenglonPorSemana(sInicio, sfin, numAnioInicio.Value, numAnioFin.Value, idNave, idLinea, chkConCantidad.Checked)
        Else
            If cmbFoliosSimulacion.SelectedIndex > 0 Then
                Dim objSimBU As New Negocios.SimulacionBU
                dt = objSimBU.consultaSimulacionPorSemana(sInicio, sfin, numAnioInicio.Value, numAnioFin.Value, idNave, idLinea, cmbFoliosSimulacion.SelectedItem("sprf_folio"), cmbFoliosSimulacion.SelectedItem("ProcSimMae_ProcSimuladorID"), chkConCantidad.Checked)
            Else
                Dim objMensajeAdv As New Tools.AdvertenciaForm
                objMensajeAdv.mensaje = "Seleccione una simulación."
                objMensajeAdv.ShowDialog()
            End If
        End If

        If dt.Rows.Count > 0 Then
            grdPedidos.DataSource = dt
            grdPedidos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            With grdPedidos.DisplayLayout.Bands(0)
                .Columns("clie_clienteid").Hidden = True
                .Columns("prog_idCadena").Hidden = True
                .Columns("prog_naveID").Hidden = True
                .Columns("prog_linpID").Hidden = True
                .Columns("prog_productoID").Hidden = True
                .Columns("prog_productoEstiloID").Hidden = True
                .Columns("prog_tallaID").Hidden = True
                .Columns("prog_hormaId").Hidden = True

                .Columns("clie_nombregenerico").Header.Caption = "Cliente"
                .Columns("prog_IdPedido").Header.Caption = "Pedido"
                .Columns("Nave").Header.Caption = "Nave"
                .Columns("Linea").Header.Caption = "Linea"
                .Columns("prog_semana").Header.Caption = "Semana"
                .Columns("Producto").Header.Caption = "Artículo"
                .Columns("Horma").Header.Caption = "Horma"
                .Columns("prog_fechaEntregaPedido").Header.Caption = "Fecha Entrega"
                .Columns("prog_fechaCliente").Header.Caption = "Fecha Cliente"
                .Columns("prog_año").Header.Caption = "Año"
                .Columns("prog_IdPedido").Header.Caption = "Pedido"
                .Columns("prog_idLote").Header.Caption = "Lote"

                .Columns("clie_nombregenerico").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Linea").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_semana").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Producto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Horma").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_fechaEntregaPedido").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_fechaCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("prog_año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

                .Columns("prog_IdPedido").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("prog_semana").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("prog_año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("prog_idLote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                .Columns("prog_año").Width = 40
                .Columns("prog_semana").Width = 40
                .Columns("prog_fechaEntregaPedido").Width = 80
                .Columns("prog_fechaCliente").Width = 80

                Dim j As Int32 = 1
                If chkConCantidad.Checked = True Then
                    j = numSemanaInicio.Value
                End If
                For i = j To 52
                    If i < numSemanaInicio.Value Or i > numSemanaFin.Value Then
                        .Columns("prog_" + i.ToString).Hidden = True
                    Else
                        .Columns("prog_" + i.ToString).Header.Caption = i.ToString
                        .Columns("prog_" + i.ToString).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                        .Columns("prog_" + i.ToString).Width = 25
                        .Columns("prog_" + i.ToString).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                    End If
                Next
            End With
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmConsultaSimulacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Dim semanaActual As Int32 = DatePart(DateInterval.WeekOfYear, Date.Now)
        If semanaActual = 53 Then
            If DatePart(DateInterval.Month, Date.Now) = 1 Then
                semanaActual = 1
            ElseIf DatePart(DateInterval.Month, Date.Now) = 12 Then
                semanaActual = 52
            End If
        End If

        numSemanaInicio.Value = semanaActual

        llenarComboNavesLineas()
        llenarComboFoliosSimulacion()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) 
    
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        llenarTabla()
    End Sub

    Private Sub chkSimulador_CheckedChanged(sender As Object, e As EventArgs) Handles chkSimulador.CheckedChanged
        llenarComboFoliosSimulacion()
        cmbFoliosSimulacion.Enabled = chkSimulador.Checked
    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        If grdPedidos.Rows.Count > 0 Then
            exportarExcel()
        Else
            MsgBox("No hay registros que exportar", MsgBoxStyle.Information, "")
        End If
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        grpAnios.Visible = False
        grpSemanas.Visible = False
        grpBotones.Height = 44
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grpAnios.Visible = True
        grpSemanas.Visible = True
        grpBotones.Height = 112
    End Sub

    Private Sub grdPedidos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidos.InitializeLayout

    End Sub
End Class