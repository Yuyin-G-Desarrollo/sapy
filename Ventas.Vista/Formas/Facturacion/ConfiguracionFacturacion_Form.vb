Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports Tools

Public Class ConfiguracionFacturacion_Form


#Region "VARIABLES GLOBALES"

    Public SesionID As Integer
    Public ClienteID As Integer
    Public OTrabajo As String
    Public OrdenesTrabajoSeleccionadas As String


    Dim dtInformacionCliente As DataTable
    Dim PrimeraConsulta As Integer = 1

    Dim tipo_RazonesSocialesId As String = String.Empty
    Dim porcentajesDocumentoRazonesSociales As String = String.Empty

    Dim OBJBU As New Ventas.Negocios.DocumentosDinamicosBU
    Dim guardando As Boolean = False
    Public ParidadDocumentoExtranjero As String
    Public facturacionAnticipada As Boolean '0 = no, 1 = si

#End Region

#Region "CARGA DATOS PANTALLA"

    Private Sub ConfiguracionFacturacion_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Normal

        If ClienteID = 763 Then
            txtPorcentajeFacturacion.Enabled = False
            txtPorcentajeRemision.Enabled = False
        End If

        CargarInformacionCliente()
        CargarRFCCliente()
        recalcularPorcentajeFacturacionRemisionRazonesSociales("F", -1, False)
        recalcularPorcentajeFacturacionRemisionRazonesSociales("R", -1, False)
        DiseñoGridRazonesSociales()
        bgvRazonesSociales.RefreshData()

        btnAceptar.Focus()

    End Sub

    Private Sub CargarInformacionCliente()

        dtInformacionCliente = OBJBU.ObtenerDatosClienteFacturacion(ClienteID, OTrabajo)

        If dtInformacionCliente.Rows.Count > 0 Then
            lblNombreCliente.Text = dtInformacionCliente.Rows(0).Item("Cliente")
            If IsDBNull(dtInformacionCliente.Rows(0).Item("Restriccion")) = True Then
                lblRestriccion.Text = "---"
            Else
                lblRestriccion.Text = dtInformacionCliente.Rows(0).Item("Restriccion")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("MontoMaximoFactura")) = True Then
                lblMontoMax.Text = "0.00"
            Else
                lblMontoMax.Text = Double.Parse(dtInformacionCliente.Rows(0).Item("MontoMaximoFactura")).ToString("n2")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("FacturarPorMarca")) = True Then
                lblRestriccionMarca.Text = "---"
            Else
                lblRestriccionMarca.Text = dtInformacionCliente.Rows(0).Item("FacturarPorMarca")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("Moneda")) = True Then
                lblMoneda.Text = "---"
            Else
                lblMoneda.Text = dtInformacionCliente.Rows(0).Item("Moneda")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("Plazo")) = True Then
                lblDiasPlazo.Text = "--"
            Else
                lblDiasPlazo.Text = dtInformacionCliente.Rows(0).Item("Plazo")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("PorcentajeFacturacion")) = True Then
                txtPorcentajeFacturacion.Text = "0"
            Else
                txtPorcentajeFacturacion.Text = CInt(dtInformacionCliente.Rows(0).Item("PorcentajeFacturacion").ToString()).ToString("n0")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("PorcentajeRemision")) = True Then
                txtPorcentajeRemision.Text = "0"
            Else
                txtPorcentajeRemision.Text = CInt(dtInformacionCliente.Rows(0).Item("PorcentajeRemision").ToString()).ToString("n0")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("Empresa")) = True Then
                lblRazonSocialEmisor.Text = "---"
            Else
                lblRazonSocialEmisor.Text = dtInformacionCliente.Rows(0).Item("Empresa")
            End If

            If IsDBNull(dtInformacionCliente.Rows(0).Item("EmpresaRFC")) = True Then
                lblRFCEmisor.Text = "---"
            Else
                lblRFCEmisor.Text = dtInformacionCliente.Rows(0).Item("EmpresaRFC")
            End If


        End If

    End Sub

    Private Sub CargarRFCCliente()

        Dim dtRFC As DataTable
        dtRFC = OBJBU.ObtenerRFCOrdenTrabajo(ClienteID, OrdenesTrabajoSeleccionadas)

        dtRFC.Columns.Add(New DataColumn(" ", GetType(Boolean)))
        dtRFC.Columns.Add(New DataColumn("%", GetType(Integer)))

        For Each row As DataRow In dtRFC.Rows
            row.Item("%") = 0
            row.Item(" ") = If(row.Item("RFCPedido") = True, True, False)
            row.Item("razonsocial") = Replace(Replace(row.Item("razonsocial"), "F - ", ""), "R - ", "")
        Next

        grdRazonesSociales.DataSource = dtRFC

    End Sub

#End Region

#Region "DISEÑO"

    Private Sub DiseñoGridRazonesSociales()
        'bgvRazonesSociales.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvRazonesSociales.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvRazonesSociales.Columns.ColumnByFieldName("id").Visible = False
        bgvRazonesSociales.Columns.ColumnByFieldName("RFCPedido").Visible = False
        bgvRazonesSociales.Columns.ColumnByFieldName("recalcular").Visible = False

        bgvRazonesSociales.Columns.ColumnByFieldName("tipo").Caption = "Tipo"
        bgvRazonesSociales.Columns.ColumnByFieldName("razonsocial").Caption = "Razón Social"
        bgvRazonesSociales.Columns.ColumnByFieldName("domicilio").Caption = "Domicilio"
        bgvRazonesSociales.Columns.ColumnByFieldName("rfc").Caption = "RFC"
        bgvRazonesSociales.Columns.ColumnByFieldName("porcentaje").Caption = "% FTC"

        bgvRazonesSociales.Columns.ColumnByFieldName("tipo").OptionsColumn.AllowEdit = False
        bgvRazonesSociales.Columns.ColumnByFieldName("razonsocial").OptionsColumn.AllowEdit = False
        bgvRazonesSociales.Columns.ColumnByFieldName("domicilio").OptionsColumn.AllowEdit = False
        bgvRazonesSociales.Columns.ColumnByFieldName("rfc").OptionsColumn.AllowEdit = False

        bgvRazonesSociales.Columns.ColumnByFieldName(" ").VisibleIndex = 0

        bgvRazonesSociales.Columns.ColumnByFieldName("%").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        bgvRazonesSociales.Columns.ColumnByFieldName("%").DisplayFormat.FormatString = "N0"

        bgvRazonesSociales.IndicatorWidth = 40
        bgvRazonesSociales.Columns.ColumnByFieldName(" ").Width = 40
        bgvRazonesSociales.Columns.ColumnByFieldName("tipo").Width = 50
        bgvRazonesSociales.Columns.ColumnByFieldName("razonsocial").Width = 250
        bgvRazonesSociales.Columns.ColumnByFieldName("domicilio").Width = 300
        bgvRazonesSociales.Columns.ColumnByFieldName("rfc").Width = 150
        bgvRazonesSociales.Columns.ColumnByFieldName("%").Width = 60

        bgvRazonesSociales.OptionsView.ShowFooter = GroupFooterShowMode.Hidden

    End Sub

    Private Sub bgvRazonesSociales_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles bgvRazonesSociales.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            If IsDBNull(bgvRazonesSociales.GetRowCellValue(e.RowHandle, "RFCPedido")) = False And bgvRazonesSociales.GetRowCellValue(e.RowHandle, "RFCPedido") = True Then
                e.Appearance.BackColor = pnlRFCPedido.BackColor
            End If
        End If
    End Sub

    Private Sub bgvRazonesSociales_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvRazonesSociales.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

#End Region

#Region "PORCENTAJES POR RAZÓN SOCIAL"

    Private Sub bgvRazonesSociales_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles bgvRazonesSociales.CellValueChanging

        If e.Column.FieldName = " " Then

            'If CBool(bgvRazonesSociales.GetRowCellValue(e.RowHandle, "recalcular")) = True Then
            recalcularPorcentajeFacturacionRemisionRazonesSociales(bgvRazonesSociales.GetRowCellValue(e.RowHandle, "tipo"), e.RowHandle, e.Value)
            'Else
            '    bgvRazonesSociales.SetRowCellValue(e.RowHandle, "%", (bgvRazonesSociales.GetRowCellValue(e.RowHandle, "porcentaje")))
            ' End If

            If CBool(e.Value) = False Then
                bgvRazonesSociales.SetRowCellValue(e.RowHandle, "%", 0)
            End If


            sumarPorcentajeFacturacionRemisionRazonesSociales()
        End If

    End Sub

    Private Sub recalcularPorcentajeFacturacionRemisionRazonesSociales(ByVal tipoRazon As String, ByVal indiceSeleccionado As Integer, ByVal valorSeleccion As Boolean)
        Dim numeroFilas As Integer = 0
        Dim sumaPorcentajes As Integer = 0
        Dim porcentajeFila As Integer = 0
        Dim listIndexRazonesSeleccionadas As New List(Of Integer)
        numeroFilas = bgvRazonesSociales.DataRowCount

        If indiceSeleccionado >= 0 Then
            If CBool(bgvRazonesSociales.GetRowCellValue(indiceSeleccionado, "recalcular")) = True Then
                For index As Integer = 0 To numeroFilas Step 1
                    If bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "tipo") = tipoRazon And CBool(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ")) = True Then
                        listIndexRazonesSeleccionadas.Add(bgvRazonesSociales.GetVisibleRowHandle(index))
                    End If
                Next

                If valorSeleccion = True Then
                    If listIndexRazonesSeleccionadas.Contains(indiceSeleccionado) = False Then
                        listIndexRazonesSeleccionadas.Add(indiceSeleccionado)
                    End If
                Else
                    If listIndexRazonesSeleccionadas.Contains(indiceSeleccionado) = True Then
                        listIndexRazonesSeleccionadas.Remove(indiceSeleccionado)
                    End If
                End If

                If listIndexRazonesSeleccionadas.Count > 0 Then

                    porcentajeFila = Math.Truncate(100 / listIndexRazonesSeleccionadas.Count)

                    For Each indice As Integer In listIndexRazonesSeleccionadas

                        bgvRazonesSociales.SetRowCellValue(indice, "%", porcentajeFila)

                        If listIndexRazonesSeleccionadas.IndexOf(indice) = listIndexRazonesSeleccionadas.Count - 1 Then
                            bgvRazonesSociales.SetRowCellValue(indice, "%", 100 - sumaPorcentajes)
                        End If

                        sumaPorcentajes += bgvRazonesSociales.GetRowCellValue(indice, "%")

                    Next

                End If

            Else


                If valorSeleccion = True Then
                    bgvRazonesSociales.SetRowCellValue(indiceSeleccionado, "%", (bgvRazonesSociales.GetRowCellValue(indiceSeleccionado, "porcentaje")))
                Else
                    bgvRazonesSociales.SetRowCellValue(indiceSeleccionado, "%", 0)
                End If
            End If

        Else
            For index As Integer = 0 To numeroFilas Step 1
                If bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "tipo") = tipoRazon And CBool(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ")) = True Then
                    listIndexRazonesSeleccionadas.Add(bgvRazonesSociales.GetVisibleRowHandle(index))
                End If
            Next

            If valorSeleccion = True Then
                If listIndexRazonesSeleccionadas.Contains(indiceSeleccionado) = False Then
                    listIndexRazonesSeleccionadas.Add(indiceSeleccionado)
                End If
            Else
                If listIndexRazonesSeleccionadas.Contains(indiceSeleccionado) = True Then
                    listIndexRazonesSeleccionadas.Remove(indiceSeleccionado)
                End If
            End If

            If listIndexRazonesSeleccionadas.Count > 0 Then

                porcentajeFila = Math.Truncate(100 / listIndexRazonesSeleccionadas.Count)

                For Each indice As Integer In listIndexRazonesSeleccionadas

                    bgvRazonesSociales.SetRowCellValue(indice, "%", porcentajeFila)

                    If listIndexRazonesSeleccionadas.IndexOf(indice) = listIndexRazonesSeleccionadas.Count - 1 Then
                        bgvRazonesSociales.SetRowCellValue(indice, "%", 100 - sumaPorcentajes)
                    End If

                    sumaPorcentajes += bgvRazonesSociales.GetRowCellValue(indice, "%")

                Next

            End If
        End If

        If tipoRazon = "R" Then
            txtPorcentajeRemisionSeleccionRazones.Text = If(listIndexRazonesSeleccionadas.Count = 0, 0, sumaPorcentajes.ToString())
        End If
        If tipoRazon = "F" Then
            txtPorcentajeFacturacionSeleccionRazones.Text = If(listIndexRazonesSeleccionadas.Count = 0, 0, sumaPorcentajes.ToString())
        End If

    End Sub

    Private Sub sumarPorcentajeFacturacionRemisionRazonesSociales()
        Dim numeroFilas As Integer = 0
        Dim sumaPorcentajeRemision As Integer = 0
        Dim sumaPorcentajeFacturacion As Integer = 0

        numeroFilas = bgvRazonesSociales.DataRowCount

        For index As Integer = 0 To numeroFilas Step 1

            If IsNothing(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%")) = False Then
                If bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%").ToString() = "" Then
                    bgvRazonesSociales.SetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%", 0)
                End If
            End If
            If bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "tipo") = "R" Then 'And CBool(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ")) = True Then
                sumaPorcentajeRemision += bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%")
            End If
            If bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "tipo") = "F" Then 'And CBool(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ")) = True Then
                sumaPorcentajeFacturacion += bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%")
            End If
        Next

        txtPorcentajeRemisionSeleccionRazones.Text = sumaPorcentajeRemision
        txtPorcentajeFacturacionSeleccionRazones.Text = sumaPorcentajeFacturacion

    End Sub

    Private Sub txtPorcentajeFacturacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentajeFacturacion.KeyPress
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> Microsoft.VisualBasic.ChrW(8) And e.KeyChar <> Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPorcentajeRemision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPorcentajeRemision.KeyPress
        If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> Microsoft.VisualBasic.ChrW(8) And e.KeyChar <> Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPorcentajeFacturacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPorcentajeFacturacion.KeyDown
        Dim numeroFilas As Integer = 0

        If e.KeyValue = 13 Then
            If txtPorcentajeFacturacion.Text = "" Then
                txtPorcentajeFacturacion.Text = "0"
            End If
            If Integer.Parse(txtPorcentajeFacturacion.Text) >= 100 Then
                txtPorcentajeFacturacion.Text = "100"
            End If
            txtPorcentajeRemision.Text = (100 - Integer.Parse(txtPorcentajeFacturacion.Text)).ToString()
            bgvRazonesSociales.RefreshData()
            sumarPorcentajeFacturacionRemisionRazonesSociales()
        End If
    End Sub

    Private Sub txtPorcentajeRemision_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPorcentajeRemision.KeyDown
        If e.KeyValue = 13 Then
            If txtPorcentajeRemision.Text = "" Then
                txtPorcentajeRemision.Text = "0"
            End If
            If Integer.Parse(txtPorcentajeRemision.Text) >= 100 Then
                txtPorcentajeRemision.Text = "100"
            End If
            txtPorcentajeFacturacion.Text = (100 - Integer.Parse(txtPorcentajeRemision.Text)).ToString()
            bgvRazonesSociales.RefreshData()
            sumarPorcentajeFacturacionRemisionRazonesSociales()
        End If
    End Sub

    Private Sub bgvRazonesSociales_CustomRowFilter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles bgvRazonesSociales.CustomRowFilter
        If PrimeraConsulta = 0 Then
            If txtPorcentajeFacturacion.Text = "100" Then
                If bgvRazonesSociales.GetRowCellValue(e.ListSourceRow, "tipo") = "R" Then
                    e.Visible = False
                    e.Handled = True
                    txtPorcentajeRemisionSeleccionRazones.Text = "0"
                End If
                If bgvRazonesSociales.GetRowCellValue(e.ListSourceRow, "tipo") = "F" Then
                    e.Visible = True
                    e.Handled = True
                End If
            End If
            If txtPorcentajeRemision.Text = "100" Then
                If bgvRazonesSociales.GetRowCellValue(e.ListSourceRow, "tipo") = "F" Then
                    e.Visible = False
                    e.Handled = True
                    txtPorcentajeFacturacionSeleccionRazones.Text = "0"
                End If
                If bgvRazonesSociales.GetRowCellValue(e.ListSourceRow, "tipo") = "R" Then
                    e.Visible = True
                    e.Handled = True
                End If
            End If
        Else
            If e.ListSourceRow = bgvRazonesSociales.RowCount - 1 Then
                PrimeraConsulta = 0
            End If
        End If
    End Sub

    Private Sub bgvRazonesSociales_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles bgvRazonesSociales.ShowingEditor

        Dim view As GridView = sender

        If view.FocusedColumn.FieldName = "%" And verificarRenglonSeleccionado(view, view.FocusedRowHandle) = False Then

            e.Cancel = True

        End If

    End Sub

    Private Function verificarRenglonSeleccionado(ByVal view As GridView, ByVal row As Integer) As Boolean

        Dim col As GridColumn = view.Columns(" ")

        Dim val As Boolean = CBool(view.GetRowCellValue(row, col))

        Return val

    End Function

    Private Sub bgvRazonesSociales_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles bgvRazonesSociales.CellValueChanged
        If e.Column.FieldName = "%" Then
            sumarPorcentajeFacturacionRemisionRazonesSociales()
        End If
    End Sub

    Private Function validarPorcentajesFacturacionRemision() As Boolean
        Dim resultadoFacturacion As Boolean = False
        Dim resultadoRemision As Boolean = False
        Dim resultado As Boolean = False
        Dim porcentajeFacturacion As Integer = If(txtPorcentajeFacturacion.Text = "", 0, CInt(txtPorcentajeFacturacion.Text))
        Dim porcentajeRemision As Integer = If(txtPorcentajeRemision.Text = "", 0, CInt(txtPorcentajeRemision.Text))
        Dim porcentajeFacturacionRazonesSociales As Integer = If(txtPorcentajeFacturacionSeleccionRazones.Text = "", 0, CInt(txtPorcentajeFacturacionSeleccionRazones.Text))
        Dim porcentajeRemisionRazonesSociales As Integer = If(txtPorcentajeRemisionSeleccionRazones.Text = "", 0, CInt(txtPorcentajeRemisionSeleccionRazones.Text))

        If porcentajeFacturacion > 0 Then
            If porcentajeFacturacionRazonesSociales = 100 Then
                resultadoFacturacion = True
            End If
        Else
            resultadoFacturacion = True
        End If
        If porcentajeRemision > 0 Then
            If porcentajeRemisionRazonesSociales = 100 Then
                resultadoRemision = True
            End If
        Else
            resultadoRemision = True
        End If

        If resultadoFacturacion = True And resultadoRemision = True Then
            resultado = True
        End If

        Return resultado

    End Function

    Private Sub obtenerDatosRazonesSocialesUsar()

        Dim numeroFilas As Integer = 0
        Dim sumaPorcentajeRemision As Integer = 0
        Dim sumaPorcentajeFacturacion As Integer = 0

        numeroFilas = bgvRazonesSociales.DataRowCount

        For index As Integer = 0 To numeroFilas Step 1

            If IsNothing(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ")) = False Then

                If bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ") = True Then

                    If tipo_RazonesSocialesId <> "" Then
                        tipo_RazonesSocialesId += ","
                    End If

                    tipo_RazonesSocialesId += bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "tipo").ToString() + "-" + bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "id").ToString()

                    If porcentajesDocumentoRazonesSociales <> "" Then
                        porcentajesDocumentoRazonesSociales += ","
                    End If

                    porcentajesDocumentoRazonesSociales += bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%").ToString()


                End If

            End If

        Next

    End Sub

#End Region

#Region "OTRAS FUNCIONES"

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If validarPorcentajesFacturacionRemision() = True Then

            obtenerDatosRazonesSocialesUsar()

            Dim ventana As New VistaPreviaFacturacion_Form
            ventana.MdiParent = Me.MdiParent
            ventana.dtDatosCliente = dtInformacionCliente
            ventana.tipo_RazonSocial = tipo_RazonesSocialesId
            ventana.sesionFacturacionId = SesionID
            ventana.porcentajePorRazonsocial = porcentajesDocumentoRazonesSociales
            ventana.ordenesTrabajoSeleccionadas = OrdenesTrabajoSeleccionadas
            ventana.porcentajeFacturacionCapturadoUsuario = CInt(txtPorcentajeFacturacion.Text)
            ventana.porcentajeRemisionCapturadoUsuario = CInt(txtPorcentajeRemision.Text)
            ventana.generacionAutomatica = 1
            ventana.descripcionEspecial = CBool(dtInformacionCliente.Rows(0).Item("DescripcionEspecial"))
            ventana.ParidadDocumentoExtranjero = ParidadDocumentoExtranjero
            ventana.facturacionAnticipada = facturacionAnticipada
            guardando = True
            Me.Close()
            ventana.Show()

        Else

            show_message("Advertencia", "La suma de porcentajes de las razones sociales por tipo de documento debe ser 100%")

        End If

    End Sub


    Private Sub ConfiguracionFacturacion_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        If guardando = False Then
            Dim confirmar As New Tools.ConfirmarForm
            Dim ObjBU As New Negocios.VistaPreviaDocumentosBU

            confirmar.mensaje = "¿Está seguro de cerrar la pantalla?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then

                ObjBU.limpiarSesionFacturacion(SesionID)

            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub txtPorcentajeFacturacion_Leave(sender As Object, e As EventArgs) Handles txtPorcentajeFacturacion.Leave
        If txtPorcentajeFacturacion.Text = "" Then
            txtPorcentajeFacturacion.Text = "0"
        End If
        If Integer.Parse(txtPorcentajeFacturacion.Text) >= 100 Then
            txtPorcentajeFacturacion.Text = "100"
        End If
        txtPorcentajeRemision.Text = (100 - Integer.Parse(txtPorcentajeFacturacion.Text)).ToString()
        bgvRazonesSociales.RefreshData()
        sumarPorcentajeFacturacionRemisionRazonesSociales()
    End Sub

    Private Sub txtPorcentajeRemision_Leave(sender As Object, e As EventArgs) Handles txtPorcentajeRemision.Leave
        If txtPorcentajeRemision.Text = "" Then
            txtPorcentajeRemision.Text = "0"
        End If
        If Integer.Parse(txtPorcentajeRemision.Text) >= 100 Then
            txtPorcentajeRemision.Text = "100"
        End If
        txtPorcentajeFacturacion.Text = (100 - Integer.Parse(txtPorcentajeRemision.Text)).ToString()
        bgvRazonesSociales.RefreshData()
        sumarPorcentajeFacturacionRemisionRazonesSociales()
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = bgvRazonesSociales.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                bgvRazonesSociales.SetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)

                If CBool(chboxSeleccionarTodo.Checked) = False Then
                    bgvRazonesSociales.SetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "%", 0)
                End If

                recalcularPorcentajeFacturacionRemisionRazonesSociales(bgvRazonesSociales.GetRowCellValue(bgvRazonesSociales.GetVisibleRowHandle(index), "tipo"), bgvRazonesSociales.GetVisibleRowHandle(index), chboxSeleccionarTodo.Checked)

            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub


#End Region

End Class