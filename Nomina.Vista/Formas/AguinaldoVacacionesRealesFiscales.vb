Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Infragistics.Win
Imports System.Threading

Public Class AguinaldoVacacionesRealesFiscales
    Public objMensaje As New Tools.AdvertenciaForm
    Dim sumMoney As Double = 0.0
    Dim DTNoEncontrados As DataTable
    Dim ConsultarNoEncontrados As Boolean = False
    Dim ConsultarConcentradoAVRF As Boolean = False

    Private Sub AguinaldoVacacionesRealesFiscales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarPermisos()

        If ConsultarNoEncontrados Then
            btnExterno.Visible = True
            lblExterno.Visible = True
        Else
            btnExterno.Visible = False
            lblExterno.Visible = False
        End If

        WindowState = FormWindowState.Maximized

        'llenarComboAnio()

        llenarComboNaves()
        getDatos()


        DTNoEncontrados = New DataTable
    End Sub

    Public Sub cargarPermisos()
        ConsultarNoEncontrados = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AGUI_VAC_FIS", "NOM_AGVARF_SAY")
        ConsultarConcentradoAVRF = Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("AGUI_VAC_FIS", "NOM_REP_CONCENTRADO")
    End Sub

    Private Function getidCaja()
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim cja As DataTable
        Dim idCaja As Integer = 0
        cja = obj.getidCaja(cmbNave.SelectedValue)
        If cja.Rows.Count > 0 Then
            idCaja = cja.Rows(0).Item(0).ToString
        Else

        End If
        Return idCaja
    End Function

    Private Function getRazonSocial()
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim rzs As DataTable
        Dim razonSocial As String = ""
        rzs = obj.getidCaja(cmbNave.SelectedValue)
        If rzs.Rows.Count > 0 Then
            razonSocial = rzs.Rows(0).Item(1).ToString
        End If
        Return razonSocial.Trim
    End Function

    Public Sub llenarComboAnio(ByVal idNave As Integer)
        Dim objBU As New Negocios.RealesFiscalesBU
        Dim dtComboAño As New DataTable
        dtComboAño = objBU.llenarComboAnio(idNave)
        dtComboAño.Rows.InsertAt(dtComboAño.NewRow, 0)
        cmbAño.DataSource = dtComboAño
        cmbAño.DisplayMember = "año"
        cmbAño.ValueMember = "añoAVRF"
    End Sub

    Public Sub llenarComboNaves()

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub

    Public Sub getDatos()
        If Not IsDBNull(cmbNave.SelectedValue) Then
            Dim obj As New Nomina.Negocios.RealesFiscalesBU
            Dim datos As DataTable
            Dim Colaborador As String = ""
            Dim soloVacaciones As Int32
            'Dim datosE As DataTable

            Colaborador = txtColaborador.Text

            If cmbNave.SelectedIndex <> 0 And cmbAño.SelectedIndex <> 0 Then
                If cmbPeriodo.Text = "SEMANA SANTA" Then
                    soloVacaciones = 1
                Else
                    soloVacaciones = 0
                End If
                datos = obj.getDatos(cmbNave.SelectedValue, cmbAño.SelectedValue, Colaborador, soloVacaciones)
                grdRealesFiscales.DataSource = Nothing
                grdRealesFiscales.DataSource = datos
                disenioGrid()
            End If


        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdRealesFiscales.DataSource = Nothing
        cmbNave.SelectedIndex = 0
        cmbAño.SelectedIndex = 0
        txtColaborador.Text = " "
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        If cmbNave.SelectedIndex > 0 Then
            lblAV.Text = "0.00"
            lblInternos.Text = "0.00"
            lblExternos.Text = "0.00"
            lblTotEfectivo.Text = "0.00"

            If geInfoAguinaldosVacaciones() = 1 Then
                getDatos()


                Dim suma As Double = 0
                For Each row As UltraGridRow In grdRealesFiscales.Rows
                    suma += CDbl(row.Cells("Total F").Value.ToString)
                Next

                If cmbPeriodo.Text = "SEMANA SANTA" Then
                    If obj.validarInfoVacaciones(cmbNave.SelectedValue, CInt(cmbAño.Text)) = True Then
                        btnGuardar.Enabled = True
                    Else
                        btnGuardar.Enabled = False
                    End If

                Else

                    If obj.validarTotalFiscales(cmbAño.SelectedValue, cmbNave.SelectedValue) = 0 Then
                        btnGuardar.Enabled = True
                    Else
                        btnGuardar.Enabled = False
                    End If
                End If

                SUMAS()
                'btnGuardar.Enabled = True
            Else
                grdRealesFiscales.DataSource = Nothing
                btnGuardar.Enabled = False
            End If
        Else
            btnGuardar.Enabled = False
            'btnImpCod.Visible = False
            'lblImportar.Visible = False
            btnImprimir.Enabled = False
            lblImprimir.Enabled = False
            grdRealesFiscales.DataSource = Nothing
            objMensaje.mensaje = "No hay una nave seleccionada."
            objMensaje.ShowDialog()
        End If

    End Sub
    Private Function geInfoAguinaldosVacaciones() As Integer
        Dim objMensaje As New Tools.AdvertenciaForm
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim ban As Integer = 0
        If obj.countVacaciones(cmbNave.SelectedValue, cmbAño.SelectedValue) > 0 Then
            If obj.countAguinaldos(cmbNave.SelectedValue, cmbAño.SelectedValue) > 0 Or (cmbPeriodo.Text = "SEMANA SANTA") Then
                ban = 1
            Else
                ban = 0
            End If
        Else
            ban = 0
        End If
        If ban = 0 Then
            objMensaje.mensaje = "No existe información en vacaciones o en aguinaldos."
            objMensaje.ShowDialog()
        End If
        Return ban
    End Function

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 90
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 41
    End Sub
    Public Sub disenioGrid()
        With grdRealesFiscales.DisplayLayout.Bands(0)
            If cmbPeriodo.Text = "NAVIDAD" Then
                .Columns("agui_aguinaldoid").Hidden = True
            End If
            .Columns("prim_primavacionalid").Hidden = True
            .Columns("prim_subtotal").Hidden = True
            .Columns("prim_primavacacional").Hidden = True
            .Columns("BanderaTotalFiscal").Hidden = True
            .Columns("idColaborador").Hidden = True
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                .Columns("prim_diasxpagar").Hidden = True
                .Columns("Vacaciones").Hidden = True
                .Columns("Retención ISR").Hidden = True
            End If
            .Columns("Apellido Paterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Apellido Materno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If cmbPeriodo.Text = "NAVIDAD" Then
                .Columns("Aguinaldo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If
            .Columns("Vacaciones").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total F").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Diferencia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                .Columns("Retención ISR").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            If cmbPeriodo.Text = "NAVIDAD" Then
                .Columns("Aguinaldo").Format = "##,##0"
            End If
            .Columns("Vacaciones").Format = "##,##0"
            .Columns("Total").Format = "##,##0"
            .Columns("Total F").Format = "##,##0"
            .Columns("Diferencia").Format = "##,##0"
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                .Columns("Retención ISR").Format = "##,##0"
            End If
            If cmbPeriodo.Text = "NAVIDAD" Then
                .Columns("Aguinaldo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End If
            .Columns("Vacaciones").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Total F").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Diferencia").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                .Columns("Retención ISR").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            End If
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With
        Dim sum1 As UltraGridColumn = grdRealesFiscales.DisplayLayout.Bands(0).Columns("Total")
        Dim sum11 As SummarySettings = grdRealesFiscales.DisplayLayout.Bands(0).Summaries.Add("TOTAL1", SummaryType.Sum, sum1)
        sum11.Appearance.BackColor = Color.LightGreen
        sum11.DisplayFormat = "{0:#,##0}"
        sum11.Appearance.TextHAlign = HAlign.Right
        Dim sum2 As UltraGridColumn = grdRealesFiscales.DisplayLayout.Bands(0).Columns("Total F")
        Dim sum22 As SummarySettings = grdRealesFiscales.DisplayLayout.Bands(0).Summaries.Add("TOTAL2", SummaryType.Sum, sum2)
        sum22.DisplayFormat = "{0:#,##0}"
        sum22.Appearance.TextHAlign = HAlign.Right
        If cmbPeriodo.Text = "SEMANA SANTA" Then
            Dim sum6 As UltraGridColumn = grdRealesFiscales.DisplayLayout.Bands(0).Columns("Retención ISR")
            Dim sum66 As SummarySettings = grdRealesFiscales.DisplayLayout.Bands(0).Summaries.Add("TOTAL6", SummaryType.Sum, sum6)
            sum66.DisplayFormat = "{0:#,##0}"
            sum66.Appearance.TextHAlign = HAlign.Right
        End If
        Dim sum3 As UltraGridColumn = grdRealesFiscales.DisplayLayout.Bands(0).Columns("Diferencia")
        Dim sum33 As SummarySettings = grdRealesFiscales.DisplayLayout.Bands(0).Summaries.Add("TOTAL3", SummaryType.Sum, sum3)
        sum33.DisplayFormat = "{0:#,##0}"
        sum33.Appearance.TextHAlign = HAlign.Right
        If cmbPeriodo.Text = "NAVIDAD" Then
            Dim sum4 As UltraGridColumn = grdRealesFiscales.DisplayLayout.Bands(0).Columns("Aguinaldo")
            Dim sum44 As SummarySettings = grdRealesFiscales.DisplayLayout.Bands(0).Summaries.Add("TOTAL4", SummaryType.Sum, sum4)
            sum44.DisplayFormat = "{0:#,##0}"
            sum44.Appearance.TextHAlign = HAlign.Right
        End If
        Dim sum5 As UltraGridColumn = grdRealesFiscales.DisplayLayout.Bands(0).Columns("Vacaciones")
        Dim sum55 As SummarySettings = grdRealesFiscales.DisplayLayout.Bands(0).Summaries.Add("TOTAL5", SummaryType.Sum, sum5)
        sum55.DisplayFormat = "{0:#,##0}"
        sum55.Appearance.TextHAlign = HAlign.Right

        grdRealesFiscales.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False
        grdRealesFiscales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdRealesFiscales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdRealesFiscales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub


    Public Sub guardar()
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim objMensaje As New Tools.AdvertenciaForm
        Dim objMensajeExt As New Tools.ExitoForm
        Dim datos As DataTable
        Dim numCheques As Integer = 0
        'Dim sumMoney As Double = 0.0
        If Not IsDBNull(cmbNave.SelectedValue) Then
            If cmbNave.SelectedIndex > 0 Then
                If obj.countVacaciones(cmbNave.SelectedValue, cmbAño.SelectedValue) > 0 Then
                    If obj.countAguinaldos(cmbNave.SelectedValue, cmbAño.SelectedValue) > 0 Or (cmbPeriodo.Text = "SEMANA SANTA") Then
                        Dim objMensajeConf As New Tools.ConfirmarForm With {
                        .mensaje = "¿Está seguro de guardar la información de Aguinaldos y Vacaciones R y F? Este proceso no se podrá revertir."
                        }
                        If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Try
                                Me.Cursor = Cursors.WaitCursor
                                datos = grdRealesFiscales.DataSource

                                Dim vXmlAguinaldo As XElement = New XElement("DetAguinaldos")
                                Dim vXmlVacaciones As XElement = New XElement("DetVacaciones")
                                Dim dtResultados As New DataTable

                                For Each r As DataRow In datos.Rows
                                    If Convert.ToDouble(r("BanderaTotalFiscal").ToString) <= 0 Then 'Bandera que sirve para saber si ya tiene un total fiscal
                                        If Convert.ToDouble(r("Total F").ToString) <= Convert.ToDouble(r("Total").ToString) Then 'No inserta si el Total fiscal es mayor a la cantidad real

                                            Dim vNodoA As XElement = New XElement("Aguinaldo")
                                            Dim vNodoV As XElement = New XElement("Vacaciones")
                                            If cmbPeriodo.Text = "Navidad" Then
                                                vNodoA.Add(New XAttribute("AguinaldoId", r("agui_aguinaldoid").ToString))
                                                vNodoA.Add(New XAttribute("TotalFAgui", CDbl(r("Total F"))))
                                                vXmlAguinaldo.Add(vNodoA)
                                            End If

                                            vNodoV.Add(New XAttribute("VacacionesId", r("prim_primavacionalid").ToString))
                                            vNodoV.Add(New XAttribute("TotalFVac", CDbl(r("Total F"))))
                                            vXmlVacaciones.Add(vNodoV)

                                            'obj.updateAguinaldo(r("agui_aguinaldoid").ToString, r("Total F").ToString)
                                            'obj.updateVacaciones(r("prim_primavacionalid").ToString, r("Total F").ToString)

                                            'sumMoney += Convert.ToDouble(r("Diferencia").ToString)
                                            'If Convert.ToDouble(r("Total F").ToString) > 0 Then
                                            '    numCheques += 1
                                            '    'obj.altaVacacionesAguinaldos(getidCaja, "CHEQUE", Convert.ToDouble(r("Total F").ToString), r(2).ToString + " " + r(0).ToString + " " + r(1).ToString, "AGUINALDO Y VACACIONES " + txtAnio.Text, getRazonSocial)
                                            'End If
                                        End If
                                    End If
                                Next
                                If cmbPeriodo.Text = "NAVIDAD" Then
                                    dtResultados = obj.updateAguiVacFiscal(vXmlAguinaldo.ToString(), vXmlVacaciones.ToString(), cmbNave.SelectedValue, cmbAño.SelectedValue)
                                Else
                                    dtResultados = obj.updateVacacionesFiscal(vXmlVacaciones.ToString(), cmbNave.SelectedValue, cmbAño.SelectedValue)
                                End If


                                If Not dtResultados Is Nothing AndAlso dtResultados.Rows.Count > 0 Then
                                    If dtResultados.Rows(0).Item("mensaje") = "EXITO" Then
                                        If sumMoney > 0 And cmbPeriodo.Text = "NAVIDAD" Then
                                            obj.altaVacacionesAguinaldos(getidCaja, "EFECTIVO", sumMoney, "", "EFECTIVO AGUINALDO Y VACACIONES " & cmbAño.SelectedValue, getRazonSocial)
                                        ElseIf sumMoney > 0 And cmbPeriodo.Text = "SEMANA SANTA" Then
                                            obj.altaVacacionesAguinaldos(getidCaja, "EFECTIVO", sumMoney, "", "EFECTIVO VACACIONES SEMANA SANTA " & cmbAño.SelectedValue, getRazonSocial)
                                        End If

                                        btnGuardar.Enabled = False
                                        objMensajeExt.mensaje = "• Se guardaron los importes de aguinaldo y vacaciones. " +
                                                            "• Se registró una solicitud de efectivo por " & sumMoney.ToString("C0") & "."
                                        objMensajeExt.ShowDialog()
                                    Else
                                        Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Errores, "Ocurrió un error: " & dtResultados.Rows(0).Item("mensaje"))
                                    End If
                                Else
                                    Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Advertencia, "Ocurrió un problema al guardar, favor de notificar a sistemas.")
                                End If

                            Catch ex As Exception
                                Tools.Utilerias.show_message(Tools.Utilerias.TipoMensaje.Errores, "Ocurrió un error al intentar guardar: " & ex.Message)
                            Finally
                                Me.Cursor = DefaultCursor
                            End Try
                        End If
                    Else
                        objMensaje.mensaje = "No existe información en aguinaldos."
                        objMensaje.ShowDialog()
                    End If
                Else
                    objMensaje.mensaje = "No existe información en vacaciones."
                    objMensaje.ShowDialog()
                End If
            Else
                objMensaje.mensaje = "No hay ninguna nave seleccionada."
                objMensaje.ShowDialog()
            End If
        Else
            objMensaje.mensaje = "No hay ninguna nave seleccionada."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub SUMAS()

        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim objMensaje As New Tools.AdvertenciaForm
        Dim objMensajeExt As New Tools.ExitoForm
        Dim datos As DataTable
        Dim numCheques As Integer = 0

        Dim sumTotalAV As Double = 0.0
        Dim sumInternos As Double = 0.0
        sumMoney = 0
        Dim totalExternos As Integer = 0

        If Not IsDBNull(cmbNave.SelectedValue) Then
            If cmbNave.SelectedIndex > 0 Then
                If obj.countVacaciones(cmbNave.SelectedValue, cmbAño.SelectedValue) > 0 Then
                    If obj.countAguinaldos(cmbNave.SelectedValue, cmbAño.SelectedValue) > 0 Or (cmbPeriodo.Text = "SEMANA SANTA") Then
                        datos = grdRealesFiscales.DataSource
                        For Each r As DataRow In datos.Rows
                            If Convert.ToDouble(r("BanderaTotalFiscal").ToString) <= 0 Then 'Bandera que sirve para saber si ya tiene un total fiscal
                                ' If Convert.ToDouble(r("Total F").ToString) <= Convert.ToDouble(r("Total").ToString) Then 'No inserta si el Total fiscal es mayor a la cantidad real
                                'obj.updateAguinaldo(r("agui_aguinaldoid").ToString, r("Total F").ToString)
                                ' obj.updateVacaciones(r("prim_primavacionalid").ToString, r("Total F").ToString)
                                'sumMoney += Convert.ToDouble(r("Diferencia").ToString)
                                sumMoney += (Convert.ToDouble(r("Total").ToString) - Convert.ToDouble(r("Total F").ToString))
                                sumTotalAV += Convert.ToDouble(r("Total").ToString)
                                sumInternos += Convert.ToDouble(r("Total F").ToString)

                                If Convert.ToDouble(r("Total F").ToString) > 0 Then
                                    numCheques += 1
                                    'obj.altaVacacionesAguinaldos(getidCaja, "CHEQUE", Convert.ToDouble(r("Total F").ToString), r(2).ToString + " " + r(0).ToString + " " + r(1).ToString, "AGUINALDO Y VACACIONES " + txtAnio.Text, getRazonSocial)
                                End If
                                ' End If
                            End If
                        Next
                        If (cmbNave.SelectedValue = 57 Or cmbNave.SelectedValue = 51) Then
                            totalExternos = 0
                        Else
                            'totalExternos = obj.getTotalExternos(Year(Now), cmbNave.SelectedValue)
                            totalExternos = obj.getTotalExternos(cmbAño.SelectedValue, cmbNave.SelectedValue)
                        End If
                        lblExternos.Text = CDbl(totalExternos.ToString).ToString("N0")
                        sumMoney = sumMoney - totalExternos
                        lblAV.Text = CDbl(sumTotalAV.ToString).ToString("N0")
                        lblInternos.Text = CDbl(sumInternos.ToString).ToString("N0")
                        lblTotEfectivo.Text = CDbl(sumMoney.ToString).ToString("N0")


                    Else
                        objMensaje.mensaje = "No existe información en aguinaldos."
                        objMensaje.ShowDialog()
                    End If
                Else
                    objMensaje.mensaje = "No existe información en vacaciones."
                    objMensaje.ShowDialog()
                End If
            Else
                objMensaje.mensaje = "No hay ninguna nave seleccionada."
                objMensaje.ShowDialog()
            End If
        Else
            objMensaje.mensaje = "No hay ninguna nave seleccionada."
            objMensaje.ShowDialog()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        If getidCaja() > 0 Then
            'Me.Cursor = Cursors.WaitCursor
            guardar()
            'validarImportar()
            'InsertarNoEncontrados()
            Me.Cursor = Cursors.Default
        Else
            objMensaje.mensaje = "No tiene asignada una caja chica en SAY."
            objMensaje.ShowDialog()
        End If
    End Sub
    Private Sub pintarGrid(ByVal numsRows As List(Of Integer))
        For Each num As Integer In numsRows
            grdRealesFiscales.Rows(num).Appearance.BackColor = Color.FromArgb(255, 128, 128)
        Next
    End Sub

    Public Function Eliminar_Acentos(ByVal accentedStr As String) As String
        Dim tempBytes As Byte()
        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr)
        Return System.Text.Encoding.UTF8.GetString(tempBytes)
    End Function


    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        menuImprimir.Show(btnImprimir, 0, btnImprimir.Height)
    End Sub


    Private Sub ImprimirCartasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirCartasToolStripMenuItem.Click
        If cmbPeriodo.Text = "SEMANA SANTA" Then
            imprimirCartasSemanaSanta()
        Else
            imprimirCartas()
        End If

    End Sub
    Private Sub imprimirCartas()
        Dim Colaborador As String = ""
        Dim soloVacaciones As Int32 = 0
        If cmbNave.SelectedIndex > 0 Then

            Try
                Dim dateForm As New DateForm()
                Dim fecha As New Date
                dateForm.mensaje = "Seleccione la fecha deseada."
                dateForm.ShowDialog()
                fecha = dateForm.dtpFecha.Value
                Dim dsColaboradores As New DataSet
                Dim dtColaboradoresRelacion As New DataTable
                Dim dtColaboradoresDatos As New DataTable
                Dim obj As New Nomina.Negocios.RealesFiscalesBU
                Dim tool As New Tools.Controles
                dtColaboradoresRelacion = New DataTable("dtColaboradoresRelacion")
                With dtColaboradoresRelacion
                    .Columns.Add("nombre")
                    .Columns.Add("aguinaldo")
                    .Columns.Add("aguinaldoLetra")

                End With
                dtColaboradoresDatos = New DataTable("dtColaboradoresDatos")
                With dtColaboradoresDatos
                    .Columns.Add("nombreColaborador")
                    .Columns.Add("primVac")
                    .Columns.Add("vacaciones")
                    .Columns.Add("totalVacLetra")
                    .Columns.Add("totalVac")
                End With
                Dim datos As DataTable
                datos = obj.getDatos(cmbNave.SelectedValue, cmbAño.SelectedValue, Colaborador, soloVacaciones)
                For Each r As DataRow In datos.Rows
                    dtColaboradoresDatos.Rows.Add("" & r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                                                 CDbl(r("prim_subTotal")),
                                                 CDbl(r("prim_primavacacional")),
                                                 " (" + tool.EnLetras(r("Vacaciones").ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) ",
                                                 CDbl(r("Vacaciones"))
                                                 )


                    dtColaboradoresRelacion.Rows.Add(
                        r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                        CDbl(r("Aguinaldo")),
                        " (" + tool.EnLetras(r("Aguinaldo").ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) "
                        )
                Next

                dsColaboradores.Tables.Add(dtColaboradoresRelacion)
                dsColaboradores.Tables.Add(dtColaboradoresDatos)
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("CARTAS_FINALES")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(dsColaboradores)
                reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("fechadeldia") = fecha.ToLongDateString
                reporte("año") = "" & Year(Now)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub ImprimirSobresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirSobresToolStripMenuItem.Click
        imprimirSobres()
    End Sub
    Private Sub imprimirSobres()
        Try
            Dim dataTable = grdRealesFiscales.DataSource
            Dim contador As Integer = 0
            For Each row As DataRow In dataTable.Rows
                'MessageBox.Show(row("Diferencia (Efectivo)").ToString)
                If Not Convert.ToDouble(row("Total").ToString) = 0 Then
                    contador += 1
                    Exit For
                End If

            Next
            If contador > 0 Then
                Dim Recibos = New DataTable("Recibos")

                With Recibos
                    .Columns.Add("iDColaborador")
                    .Columns.Add("Colaborador")
                End With

                For Each fila As DataRow In dataTable.Rows
                    If Not Convert.ToDouble(fila("Total").ToString) = 0 Then
                        Recibos.Rows.Add(fila("idColaborador").ToString, fila("Nombre").ToString + " " + fila("Apellido Paterno").ToString + " " + fila("Apellido Materno").ToString)
                    End If
                Next
                Me.Cursor = Cursors.WaitCursor
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
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AguinaldosYVacacionesRealesYFiscalesToolStripMenuItem.Click
        Dim soloVacaciones As Integer
        If cmbNave.SelectedIndex > 0 Then
            If cmbPeriodo.Text = "SEMANA SANTA" Then
                soloVacaciones = 1
            Else
                soloVacaciones = 0
            End If
            Try
                Dim obj As New Nomina.Negocios.RealesFiscalesBU
                Dim colaboradores = New DataTable("colaboradores")
                colaboradores = obj.getDatosReporteVacAgui(cmbNave.SelectedValue, cmbAño.SelectedValue, soloVacaciones)
                Dim añoAguinaldos As String = cmbAño.SelectedValue.ToString
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                If soloVacaciones = 1 Then
                    EntidadReporte = OBJBU.LeerReporteporClave("VAC_AGUI_REALESFIS_SANTA")
                Else
                    EntidadReporte = OBJBU.LeerReporteporClave("VAC_AGUI_REALESFISCALES")
                End If
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()
                reporte("NaveNombre") = cmbNave.Text
                reporte("titulo") = "REPORTE AGUINALDOS Y VACACIONES R Y F"
                reporte("UserName") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("año") = añoAguinaldos
                reporte.RegData(colaboradores)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub AguinaldoYVacacionesPorNaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AguinaldoYVacacionesPorNaveToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim dsAguinaldoVacaciones As New DataSet("dsNomAguiVac")
        Dim detalleAguinaldoVacaciones As New DataTable("dtNomAguiVac")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim anio As String
        Dim usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        Dim objMensaje As New Tools.AdvertenciaForm



        If ConsultarConcentradoAVRF Then

            detalleAguinaldoVacaciones = obj.ConsultaAguinaldoVacacionesNave(cmbAño.SelectedValue)

            detalleAguinaldoVacaciones.TableName = "dtNomAguiVac"
            dsAguinaldoVacaciones.Tables.Add(detalleAguinaldoVacaciones)
            anio = cmbAño.SelectedValue


            EntidadReporte = objReporte.LeerReporteporClave("NOM_AGUI_VAC_NAVE")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport

            reporte.Load(archivo)
            reporte.Compile()
            reporte("dsNomAguiVac") = "dsNomAguiVac"
            reporte.Dictionary.Clear()
            reporte("NumSemana") = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
            reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal
            reporte("NbUsuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("Año") = Date.Now.Year
            reporte("AñoAguinaldo") = anio
            reporte("Fecha") = DateTime.Now.ToString("dd") + " " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(DateTime.Now.Month - 1).ToUpper()

            reporte.RegData(dsAguinaldoVacaciones)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Else
            objMensaje.mensaje = "Concentrado disponible para finanzas."
            objMensaje.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExterno_Click(sender As Object, e As EventArgs) Handles btnExterno.Click
        Dim objGridForm As New Tools.ExternosAguinaldo
        Dim obj As New Nomina.Negocios.RealesFiscalesBU
        Dim datos As New DataTable
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        Try
            If grdRealesFiscales.Rows.Count > 0 Then

                datos = obj.ObtenerDatosExterno(cmbNave.SelectedValue, cmbAño.SelectedValue)
                objGridForm.dtExternos = datos
                objGridForm.ShowDialog()
            Else
                objMensajeAdv.mensaje = "No existe información."
                objMensajeAdv.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        If cmbNave.SelectedIndex > 0 Then
            llenarComboAnio(cmbNave.SelectedValue)
        End If
    End Sub

    Private Sub imprimirCartasSemanaSanta()
        Dim Colaborador As String = ""
        If cmbNave.SelectedIndex > 0 Then
            Try
                Dim dateForm As New DateForm()
                Dim fecha As New Date
                dateForm.mensaje = "Seleccione la fecha deseada."
                dateForm.ShowDialog()
                fecha = dateForm.dtpFecha.Value
                Dim dsColaboradores As New DataSet
                Dim dtColaboradoresRelacion As New DataTable
                Dim dtColaboradoresDatos As New DataTable
                Dim obj As New Nomina.Negocios.CalcularPrimaVacacionalBU
                Dim tool As New Tools.Controles

                dtColaboradoresDatos = New DataTable("dtColaboradoresDatos")
                With dtColaboradoresDatos
                    .Columns.Add("nombreColaborador")
                    .Columns.Add("primVac")
                    .Columns.Add("vacaciones")
                    .Columns.Add("totalVacLetra")
                    .Columns.Add("totalVac")
                    .Columns.Add("diasVacaciones")
                    .Columns.Add("retencionISR")
                End With
                Dim datos As DataTable
                datos = obj.obtenerInfoReporteVacacionesCartaFinal(cmbNave.SelectedValue, cmbAño.Text)
                For Each r As DataRow In datos.Rows
                    If CDbl(r("prim_subTotal")) > 0 Then
                        dtColaboradoresDatos.Rows.Add("" & r("Nombre").ToString & " " & r("Apellido Paterno").ToString & " " & r("Apellido Materno").ToString,
                                                 CDbl(r("prim_subTotal")),
                                                 CDbl(r("prim_primavacacional")),
                                                 " (" + tool.EnLetras((r("Vacaciones") - r("vac_ISRRetenido")).ToString.Replace(".0000", "")).ToUpper + " PESOS 00/100 M.N.) ",
                                                 CDbl(r("Vacaciones")) - CDbl(r("vac_ISRRetenido")), CInt(r("prim_diasxpagar")), CDbl(r("vac_ISRRetenido"))
                                                 )
                    End If

                Next

                dsColaboradores.Tables.Add(dtColaboradoresDatos)
                Me.Cursor = Cursors.WaitCursor
                Dim OBJBU As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJBU.LeerReporteporClave("CARTAS_FINALES_VACA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte.RegData(dsColaboradores)
                reporte("rutaImagen") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                reporte("fechadeldia") = fecha.ToLongDateString
                reporte("año") = "" & Year(Now)
                reporte.Show()
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class