Imports Tools

Public Class ReporteCierreSemanalForm

    Public IdCajaAhorro As Int32 = 40
    Public Nave As String = ""
    Public Periodo As String = ""

    Private semana As String
    Private IdPeriodoNomina As Int32 = -1
    Private _searchfilter As New C1.Win.C1FlexGrid.ConditionFilter


    Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
        grbCierreSemanal.Height = 45

    End Sub

    Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
        grbCierreSemanal.Height = 173

    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click

        txtBuscar.Text = ""
        txtBuscar_TextChanged(sender, e)

        cmbSemanaNomina.Text = ""

        For i = 1 To grdCierreSemanal.Cols.Count - 1
            grdCierreSemanal.ClearFilter(i)
        Next

        grdCierreSemanal.Rows.Count = 1

    End Sub


    Private Sub Inicializa()

        grdCierreSemanal.Rows.Count = 1
        grdCierreSemanal.Cols("CajaAhorroId").Visible = False
        grdCierreSemanal.Cols("ColaboradorId").Visible = False
        grdCierreSemanal.Cols("PeriodoNomId").Visible = False

        Tools.Controles.ComboPeriodosNomina(cmbSemanaNomina, IdCajaAhorro)

    End Sub

    Private Sub CierreSemanalForm_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter And Not (e.Alt Or e.Control) Then

            If Me.ActiveControl.GetType Is GetType(TextBox) Or Me.ActiveControl.GetType Is GetType(CheckBox) Or Me.ActiveControl.GetType Is GetType(DateTimePicker) Then
                If e.Shift Then
                    Me.ProcessTabKey(False)
                Else
                    Me.ProcessTabKey(True)
                End If
            End If
        End If

    End Sub


    Private Sub CierreSemanalForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Inicializa()
        Tools.FormatoCtrls.formato(Me)

    End Sub

    Public Sub AgregarFila(ByVal configuracion As Entidades.ColaboradorPeriodoCaja)

        grdCierreSemanal.AddItem(grdCierreSemanal.Rows.Count & vbTab & configuracion.pColaborador.PColaboradorid & vbTab & configuracion.pColaborador.PNombreCompleto & vbTab & configuracion.pMontoAhorrado & vbTab & configuracion.pCajaAhorro.pCajaAhorroId & vbTab & configuracion.pColaborador.PColaboradorid & vbTab & configuracion.pPeriodo.PPeriodoId)

    End Sub


    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        _searchfilter.Condition1.Operator = C1.Win.C1FlexGrid.ConditionOperator.Contains
        _searchfilter.Condition1.Parameter = txtBuscar.Text

        Dim count As Int32 = 0

        grdCierreSemanal.BeginUpdate()

        For r = grdCierreSemanal.Rows.Fixed To grdCierreSemanal.Rows.Count - 1
            Dim visible As Boolean = False
            For c = grdCierreSemanal.Cols.Fixed To grdCierreSemanal.Cols.Count - 1
                If _searchfilter.Apply(grdCierreSemanal(r, c)) Then
                    visible = True
                    count += 1
                    Exit For
                End If
            Next
            grdCierreSemanal.Rows(r).Visible = visible
        Next
        grdCierreSemanal.EndUpdate()

    End Sub

    Private Sub btnRegresar_Click(sender As System.Object, e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub FijarRenglon()

        Dim renglon As Int32
        renglon = 0
        For i = 1 To grdCierreSemanal.Rows.Count - 1
            If grdCierreSemanal.Rows(i).Visible = True Then
                renglon += 1
                grdCierreSemanal(i, 0) = renglon
            End If
        Next
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

        If cmbSemanaNomina.SelectedIndex <= 0 Then Exit Sub

        txtBuscar.Text = ""
        txtBuscar_TextChanged(sender, e)

        For i = 1 To grdCierreSemanal.Cols.Count - 1
            grdCierreSemanal.ClearFilter(i)
        Next

        Filtro()

    End Sub


    Private Sub Filtro()

        Dim objColaboradorPeriodoCajaBU As New Nomina.Negocios.ColaboradorPeriodoCajaBU
        Dim objColaboradorPeriodoCaja As New List(Of Entidades.ColaboradorPeriodoCaja)

        objColaboradorPeriodoCaja = objColaboradorPeriodoCajaBU.Listar(IdCajaAhorro, cmbSemanaNomina.SelectedValue)

        grdCierreSemanal.Rows.Count = 1

        For Each objeto In objColaboradorPeriodoCaja
            AgregarFila(objeto)
            IdPeriodoNomina = objeto.pPeriodo.PeriodoId
            semana = objeto.pPeriodo.Concepto
        Next

    End Sub


    Private Sub cmbSemanaNomina_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSemanaNomina.SelectedIndexChanged
        txtBuscar.Text = ""
        txtBuscar_TextChanged(sender, e)

        For i = 1 To grdCierreSemanal.Cols.Count - 1
            grdCierreSemanal.ClearFilter(i)
        Next

        grdCierreSemanal.Rows.Count = 1

    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        If cmbSemanaNomina.SelectedIndex > 0 Then
            'Mandar Imprimir
            Dim frmVistaPrevia As New Tools.ReportesVistaPrevia
            Dim vReporte As New ReporteCierreSemanal

            With frmVistaPrevia
                If .Imprimir(vReporte, "@IdCajaAhorro|@PeriodoNomina", IdCajaAhorro & "|" & cmbSemanaNomina.SelectedValue, "Entero|Entero", False, False) Then
                    .ShowDialog()
                    .Close()
                End If
            End With

            frmVistaPrevia = Nothing

        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Debes seleccionar un Periodo de Nomina para imprimir el reporte."
            mensajeAdvertencia.ShowDialog()
        End If
    End Sub
End Class