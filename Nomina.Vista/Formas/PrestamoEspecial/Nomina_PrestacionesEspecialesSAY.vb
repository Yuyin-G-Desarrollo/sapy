Imports System.Globalization
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Nomina.Negocios
Imports Tools

Public Class Nomina_PrestacionesEspecialesSAY
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim NaveID As Integer
    Dim Accion As Integer
    Dim endEdit As Boolean = True


    Private Sub Nomina_PrestacionesEspecialesSAY_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            If cmbNave.SelectedValue > 0 Then
                cmbNaveDrop()
            End If

            txtSemanas.Enabled = False
            txtMontoEmpresa.Enabled = False

        Catch ex As Exception
        End Try
    End Sub

    Public Sub cmbNaveDrop()
        Try
            Tools.Controles.ComboAreaSegunNave(cmbArea, cmbNave.SelectedValue)
            llenarConceptos()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub llenarConceptos()
        Dim objBU As New SolicitudPrestamoBU
        Dim dtConceptosPrestaciones As New DataTable
        NaveID = cmbNave.SelectedValue

        If NaveID <> 0 Then
            dtConceptosPrestaciones = objBU.ObtenerConceptosPrestaciones(NaveID, 1, 0)
            dtConceptosPrestaciones.Rows.InsertAt(dtConceptosPrestaciones.NewRow, 0)
            cmbConcepto.DataSource = Nothing
            If dtConceptosPrestaciones.Rows.Count > 0 Then
                cmbConcepto.DataSource = dtConceptosPrestaciones
                cmbConcepto.DisplayMember = "Concepto"
                cmbConcepto.ValueMember = "ConceptoID"
            End If


        Else
            advertencia.mensaje = "Seleccione una nave para cargar los conceptos."
            advertencia.ShowDialog()
        End If


    End Sub


    Private Sub cmbNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNave.DropDownClosed
        cmbNaveDrop()
    End Sub


    Private Sub cmbArea_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.DropDownClosed
        Try
            Tools.Controles.ComboDepartamentosSegunArea(cmbDepartamento, cmbArea.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        grdPrestaciones.DataSource = Nothing

        Try
            Dim idNave As Integer = CInt(cmbNave.SelectedValue)
            Dim idArea As Integer = 0
            Dim idDepartamento As Integer = 0
            Dim objBU As New SolicitudPrestamoBU
            Dim Colaborador As String = ""
            Dim dtColaboradores As New DataTable


            If txtColaborador.Text = "" Then
                Colaborador = ""
            Else
                Colaborador = txtColaborador.Text
            End If


            If IsDBNull(cmbArea.SelectedValue) Then

            Else
                idArea = cmbArea.SelectedValue
            End If

            If IsDBNull(cmbDepartamento.SelectedValue) Then

            Else
                idDepartamento = cmbDepartamento.SelectedValue
            End If

            dtColaboradores = objBU.llenarTablaPrestaciones(idNave, idArea, idDepartamento, Colaborador)

            If dtColaboradores.Rows.Count > 0 Then

                grdPrestaciones.DataSource = dtColaboradores
                DiseñoGrid()
                endEdit = False
            Else
                advertencia.mensaje = "No hay datos para mostrar."
                advertencia.ShowDialog()

            End If



        Catch ex As Exception

        End Try

    End Sub

    Private Sub DiseñoGrid()
        With grdPrestaciones.DisplayLayout.Bands(0)
            .Columns("Colaborador").CellActivation = Activation.NoEdit
            .Columns("Departamento").CellActivation = Activation.NoEdit
            .Columns("Puesto").CellActivation = Activation.NoEdit

            .Columns("Importe").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Importe").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            .Columns("ColaboradorID").Hidden = True

            Dim sumTotalImportes As SummarySettings = grdPrestaciones.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdPrestaciones.DisplayLayout.Bands(0).Columns("Importe"))
            sumTotalImportes.DisplayFormat = "{0:#,##0}"
            sumTotalImportes.Appearance.TextHAlign = HAlign.Right
            sumTotalImportes.Appearance.BackColor = Color.GreenYellow
            grdPrestaciones.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"


        End With
        grdPrestaciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdPrestaciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdPrestaciones.DisplayLayout.Override.RowSelectorWidth = 15
        grdPrestaciones.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdPrestaciones.Rows(0).Selected = True


    End Sub


    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub cmbConcepto_DropDownClosed(sender As Object, e As EventArgs) Handles cmbConcepto.DropDownClosed
        cmbConceptoDrop()
    End Sub

    Public Sub cmbConceptoDrop()
        Dim objBU As New SolicitudPrestamoBU
        Dim Concepto As Integer = 0
        Dim dtSemanasSegunConcepto As New DataTable
        Dim Semanas As Integer = 0
        Dim PorcentajeEmpresa As Integer = 0

        If cmbConcepto.SelectedIndex = 0 Then
            Concepto = 0
        Else
            Concepto = cmbConcepto.SelectedValue


            dtSemanasSegunConcepto = objBU.ObtenerConceptosPrestaciones(NaveID, 2, Concepto)

            If dtSemanasSegunConcepto.Rows.Count > 0 Then
                For Each row As DataRow In dtSemanasSegunConcepto.Rows
                    Semanas = dtSemanasSegunConcepto.Rows(0).Item("Semanas")
                    PorcentajeEmpresa = dtSemanasSegunConcepto.Rows(0).Item("PorcentajeEmpresa")

                    If Semanas = 0 Then
                        advertencia.mensaje = "No tiene registrada semanas en la configuración para este concepto."
                        advertencia.ShowDialog()
                    Else
                        txtSemanas.Text = Semanas

                    End If
                Next
                txtPorcentajeEmpresa.Text = PorcentajeEmpresa
                txtPorcentajeEmpresa.Enabled = False
            Else
                advertencia.mensaje = "No tiene registrada semanas en la configuración para este concepto."
                advertencia.ShowDialog()
            End If
        End If
    End Sub


    Private Sub grdPrestaciones_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdPrestaciones.AfterCellUpdate

    End Sub


    Private Sub txtPagoTotal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagoTotal.LostFocus

        Try
            txtPagoTotal.Text = Format(CType(Me.txtPagoTotal.Text, Decimal), "c")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalColaboradores_TextChanged(sender As Object, e As EventArgs)
        Dim PagoTotal As Integer = 0
        Dim TotalColaboradores As Integer = 0
        Dim PorcentajeEmpresa As Integer = 0

        PagoTotal = txtPagoTotal.Text
        PorcentajeEmpresa = txtPorcentajeEmpresa.Text

        If PagoTotal <> 0 Then
            If PorcentajeEmpresa = 0 Then
                txtMontoEmpresa.Text = 0
                txtTotalColaboradores.Text = PagoTotal

            Else

                TotalColaboradores = txtTotalColaboradores.Text
                txtMontoEmpresa.Text = PagoTotal - TotalColaboradores
            End If

        Else
            txtMontoEmpresa.Text = 0
        End If
    End Sub

    Private Sub txtPagoTotal_TextChanged(sender As Object, e As EventArgs) Handles txtPagoTotal.TextChanged
        Dim PorcentajeEmpresa As Integer = 0
        Dim PagoTotal As Integer = 0
        Dim TotalPagoColaboradores As Integer = 0

        PorcentajeEmpresa = txtPorcentajeEmpresa.Text

        If PorcentajeEmpresa = 0 Then
            txtPorcentajeEmpresa.Text = "0"
        Else
            PorcentajeEmpresa = txtPorcentajeEmpresa.Text
        End If

        PagoTotal = txtPagoTotal.Text

        If PagoTotal = 0 Then
            txtPagoTotal.Text = "0"
        Else
            PagoTotal = txtPagoTotal.Text
        End If


        If PagoTotal <> 0 Then

            If PorcentajeEmpresa = 0 Then
                TotalPagoColaboradores = PagoTotal
                txtTotalColaboradores.Text = TotalPagoColaboradores
                txtMontoEmpresa.Text = 0
            Else
                TotalPagoColaboradores = (PorcentajeEmpresa * PagoTotal) / 100
                If PorcentajeEmpresa = 100 Then
                    txtMontoEmpresa.Text = TotalPagoColaboradores
                    txtTotalColaboradores.Text = 0
                ElseIf PorcentajeEmpresa <> 0 Then
                    txtMontoEmpresa.Text = TotalPagoColaboradores
                    txtTotalColaboradores.Text = TotalPagoColaboradores
                Else
                    txtTotalColaboradores.Text = TotalPagoColaboradores
                End If

            End If
        Else
            txtTotalColaboradores.Text = 0
        End If
    End Sub

    Private Sub txtTotalColaboradores_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPagoTotal.LostFocus

        Try
            txtTotalColaboradores.Text = Format(CType(Me.txtTotalColaboradores.Text, Decimal), "c")
            txtMontoEmpresa.Text = Format(CType(Me.txtMontoEmpresa.Text, Decimal), "c")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        Calcular()
    End Sub

    Public Sub Calcular()
        Dim ObjCalculoPrestacion As New Nomina_TablaCalculoPrestacionesSAY


        With grdPrestaciones
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        For Each rowGrd As UltraGridRow In grdPrestaciones.Rows
            If rowGrd.Cells("Seleccionar").Value Then
                ObjCalculoPrestacion.Monto = rowGrd.Cells("Importe").Value
                ObjCalculoPrestacion.Semanas = txtSemanas.Text
            End If
        Next

        ObjCalculoPrestacion.ShowDialog()
    End Sub

    Private Sub btnCargarImporteMultiple_Click(sender As Object, e As EventArgs) Handles btnCargarImporteMultiple.Click
        asignarMontoTotalMultiple()
    End Sub

    Public Sub asignarMontoTotalMultiple()
        Dim contFilasCambio As Int32 = 0
        For Each rowGR As UltraGridRow In grdPrestaciones.Rows.GetFilteredInNonGroupByRows
            If CBool(rowGR.Cells("Seleccionar").Text) = True Then
                contFilasCambio += 1
            End If
        Next

        If contFilasCambio > 0 Then
            Dim objCaptcha As New Tools.frmCaptcha

            For Each rowLB As UltraGridRow In grdPrestaciones.Rows.GetFilteredInNonGroupByRows

                If CBool(rowLB.Cells("Seleccionar").Value) = True Then

                    rowLB.Cells("Importe").Value = Math.Round(CDbl(txtPrecioMultiple.Text))

                End If
            Next

            Dim contadorPrecio As Int32 = 0
            For Each rowGR As UltraGridRow In grdPrestaciones.Rows
                If rowGR.Cells("Importe").Value > 0 Then
                    contadorPrecio += 1
                End If
            Next

            For Each rowGr As UltraGridRow In grdPrestaciones.Rows
                rowGr.Cells("Seleccionar").Value = False
            Next
            lblTotalSeleccionados.Text = "0"

        Else
            MsgBox("Debe seleccionar al menos un registro", MsgBoxStyle.Information, "Atención")
        End If

    End Sub

    Private Sub grdPrestaciones_CellChange(sender As Object, e As CellEventArgs) Handles grdPrestaciones.CellChange
        If e.Cell.Column.Key = "Seleccionar" And e.Cell.Row.Index <> grdPrestaciones.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdPrestaciones.Rows
                If CBool(rowGR.Cells("Seleccionar").Text) = True Then
                    contadorSeleccion += 1
                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtPagoTotal.Text = 0
        txtTotalColaboradores.Text = 0
        txtSemanas.Text = ""
        txtPrecioMultiple.Text = ""
        txtColaborador.Text = ""
        grdPrestaciones.DataSource = Nothing
        txtMontoEmpresa.Text = 0
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarPrestaciones()
    End Sub

    Private Sub GuardarPrestaciones()
        Dim objBU As New SolicitudPrestamoBU
        Dim dtPrestacionesGuardar As New DataTable
        Dim usuarioCreo As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim filas As Integer = grdPrestaciones.Rows.Count
        Dim contador As Integer = 0
        Dim Semanas As Integer = txtSemanas.Text
        Dim abono As Integer = 0
        Dim monto As Double = 0
        Dim totalMontoColaborador As Double = txtTotalColaboradores.Text
        Dim totalGrid As Double = 0
        Dim ConceptoPrestacion As Integer = cmbConcepto.SelectedValue
        Dim MontoEmpresa As Integer = txtMontoEmpresa.Text

        For Each rowGrd As UltraGridRow In grdPrestaciones.Rows
            If CBool(rowGrd.Cells("Seleccionar").Value) = True Then
                totalGrid += rowGrd.Cells("importe").Value
            End If

        Next

        Try

            If totalMontoColaborador > totalGrid Then
                advertencia.mensaje = "El importe de los colaboradores no coincide con el importe total."
                advertencia.ShowDialog()
                lblMonto.ForeColor = Color.Red
            Else
                Dim vXmlCeldas As XElement = New XElement("Celdas")
                For Each rowGrd As UltraGridRow In grdPrestaciones.Rows
                    If CBool(rowGrd.Cells("Seleccionar").Value) = True Then

                        If rowGrd.Cells("importe").Value > 0 Then

                            'If contador < filas Then

                            Dim vNodo As XElement = New XElement("Celda")
                            vNodo.Add(New XAttribute("PColaboradorID", rowGrd.Cells(5).Value))
                            vNodo.Add(New XAttribute("PUsuarioID", usuarioCreo))
                            vNodo.Add(New XAttribute("PMontoPrestamo", rowGrd.Cells("importe").Value))
                            vNodo.Add(New XAttribute("PInteres", 0))
                            vNodo.Add(New XAttribute("PMotivoPrestamoID", 0))
                            vNodo.Add(New XAttribute("PSemanas", Semanas))
                            vNodo.Add(New XAttribute("PEstatus", "A"))
                            vNodo.Add(New XAttribute("PSaldo", rowGrd.Cells("importe").Value))
                            vNodo.Add(New XAttribute("PJustificacion", "PRESTACION ESPECIAL SAY"))
                            monto = rowGrd.Cells("importe").Value
                            abono = monto / Semanas
                            vNodo.Add(New XAttribute("PAbono", abono))
                            vNodo.Add(New XAttribute("PTipoInteres", "I"))
                            vNodo.Add(New XAttribute("PNaveID", cmbNave.SelectedValue))
                            vNodo.Add(New XAttribute("PPrestacionSAY", 1))
                            vNodo.Add(New XAttribute("PConceptoPrestacionID", ConceptoPrestacion))
                            vNodo.Add(New XAttribute("PMontoEmpresa", MontoEmpresa))

                            vXmlCeldas.Add(vNodo)

                        End If
                        ' End If
                        'contador += 1
                    End If
                Next
                dtPrestacionesGuardar = objBU.GuardarPrestacionesSAY(vXmlCeldas.ToString())

                exito.mensaje = "Se guardaron correctamente las prestaciones."
                exito.ShowDialog()
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtPagoTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPagoTotal.KeyPress
        Dim pagoTotal As String = txtPagoTotal.Text
        Dim caracter As Char = e.KeyChar
        If pagoTotal.IndexOf(".") > 0 Then
            txtPagoTotal.MaxLength = pagoTotal.IndexOf(".") + 3
        End If
        If pagoTotal.Contains(".") = False Or (caracter = ChrW(Keys.Back)) Then
            e.Handled = False
        Else
            If Not IsNumeric(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged

        If chboxSeleccionarTodo.Checked Then
            For Each row In grdPrestaciones.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdPrestaciones.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = False
            Next
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In grdPrestaciones.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                marcados += 1
            End If
        Next
        lblTotalSeleccionados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)

    End Sub
End Class