Imports Tools
Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Entidades

Public Class RecepcionFacturasForm
    Public idOrdendeCompra As Integer = 0
    Public idProveedor As Integer = 0
    Public idNave As Integer = 0
    Public total As Double = 0
    Dim exito As New ExitoForm
    Dim idmoneda As Integer = 0
    Dim adv As New AdvertenciaForm
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub RecepcionFacturasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Private Sub cargarDatos()
        Dim obj As New RecepcionBU
        Dim datos As New DataTable
        datos = obj.getDatosOrdendeCompra(idOrdendeCompra)
        For Each row As DataRow In datos.Rows
            lblFolio.Text = getNumOrden(row("ordc_ordennumero"))
            lblModena.Text = row("mone_nombre")
            lblProveedor.Text = row("prov_razonsocial")
            lblRFC.Text = row("prov_rfc")
            lblSubtotal.Text = Format(row("subtotal"), "##,##0.00")
            lblDescuento.Text = Format(row("subtotal") * ((row("ordc_descuento") / 100)), "##,##0.00")
            idProveedor = row("ordc_proveedorid")
            idmoneda = row("mone_monedaid")

            If idmoneda > 1 Then
                lblIVA.Text = Format(CDbl(0), "##,##0.00")
                lblTotal.Text = Format(CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text), "##,##0.00")
                total = (CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text))
            Else
                lblIVA.Text = Format((CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text)) * 0.16, "##,##0.00")
                lblTotal.Text = Format(CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text) + CDbl(lblIVA.Text), "##,##0.00")
                total = (CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text)) + CDbl(lblIVA.Text)
            End If
            idNave = row("ordc_naveid")

        Next
        cargarEmpresas()
        cargarPlazos()
    End Sub
    Private Sub cargarEmpresas()
        Dim obj As New RecepcionBU
        Dim lst As New DataTable

        lst = obj.getEmpresasXNave(0)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbEmpresa.DataSource = lst
            cmbEmpresa.DisplayMember = "empr_nombre"
            cmbEmpresa.ValueMember = "empr_empresaid"
        End If
        If lst.Rows.Count = 2 Then
            cmbEmpresa.SelectedIndex = 1
            cmbEmpresa.Enabled = False
        End If
    End Sub
    Private Sub cargarPlazos()
        Dim obj As New RecepcionBU
        Dim lst As New DataTable

        lst = obj.getPlazoProveedor(idProveedor)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbPlazos.DataSource = lst
            cmbPlazos.DisplayMember = "plpa_plazo"
            cmbPlazos.ValueMember = "plpa_plazopagoid"
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If validaFacturasSeleccionas() Then
            If cmbPlazos.SelectedValue > 0 Then
                If cmbEmpresa.SelectedValue > 0 Then
                    'Cambiar de estatus orden de compra seleccionada y cambiar estatus de factura a recibida
                    Dim c As New CxPSaldos
                    Dim datos As New DataTable
                    Dim obj As New RecepcionBU
                    c = getdatos()
                    datos = obj.InsertcxpSaldoscxpMovimientos(c)
                    If datos.Rows.Count > 0 Then
                        If datos.Rows(0).Item(0).ToString.Contains("True") Then
                            obj.cerrarDatosOrdenCompraFacturaRecibida(idOrdendeCompra, c.IdComprobantecfdsOrdenCompra)
                            exito.mensaje = "Factura recibida"
                            exito.ShowDialog()
                            Me.Close()
                        Else
                            adv.mensaje = datos.Rows(0).Item(0).ToString
                            adv.ShowDialog()
                        End If
                    End If
                Else
                    adv.mensaje = "Seleccione una empresa."
                    adv.ShowDialog()
                End If
           
            Else
                adv.mensaje = "Selecciona un plazo de pago"
                adv.ShowDialog()
            End If
        End If
    End Sub
    Function getdatos() As CxPSaldos
        Dim obj As New RecepcionBU
        Dim c As New CxPSaldos
        Dim factura As New CxPSaldos
        Dim datosProv As New DataTable
        datosProv = obj.getDatosProveedor(idProveedor)
        c = getDatosFacturaSeleccionada()
        c = getDatosSemanadePago(c)
        With c
            c.TIPODOCTO = 1
            c.CVEPROV = CInt(datosProv.Rows(0).Item("sicy").ToString)
            c.REFERENCIA = datosProv.Rows(0).Item("giro").ToString
            c.USUCAPTURA = ""
        End With
        Return c
    End Function
    Function getDatosSemanadePago(c As CxPSaldos) As CxPSaldos
        Dim obj As New RecepcionBU
        Dim datossemanas As New DataTable
        Dim datossemanas2 As New DataTable
        datossemanas = obj.getSemana(0, Date.Now)
        If datossemanas.Rows.Count > 0 Then
            datossemanas2 = obj.getSemanaPago(datossemanas.Rows(0).Item("sema_semanaid"), cmbPlazos.SelectedValue)
            If datossemanas2.Rows.Count > 0 Then
                datossemanas = obj.getSemana(datossemanas2.Rows(0).Item("secp_semanapagoid"), Date.Now)
            End If
            With c
                c.FECVENTO = datossemanas.Rows(0).Item("sema_fechaFin")
                c.SEMPAGO = datossemanas.Rows(0).Item("sema_noSemana")
                c.SEMPAGADA = datossemanas.Rows(0).Item("sema_noSemana")
                c.AÑOSEMPAGO = datossemanas.Rows(0).Item("sema_anio")
                c.AÑOSEMPAGADA = datossemanas.Rows(0).Item("sema_anio")
            End With
        End If    
        Return c
    End Function
    Function getDatosFacturaSeleccionada() As CxPSaldos
        Dim datos As New DataTable
        Dim c As New CxPSaldos
        datos = grdFacturas.DataSource
        For Each row As DataRow In datos.Rows
            c.SUBTOT = row("SubTotal")
            c.IMPDOCTO = row("Total")
            c.SDODOCTO = row("Total")
            c.NUMDOCTO = row("cfd_Serie").ToString & row("cfd_Folio").ToString
            c.IMPIVA = row("IVA")
            c.FECDOCTO = row("cfd_Fecha")
            c.MONEDA = row("cfd_modenaid")
            c.RfcEmpresa = row("cfd_RfcEmpresa")
            c.RfcProveedor = row("cfd_RfcProveedor")
            c.IdComprobante = row("cfd_IdComprobantesicy")
            c.NAVE = row("cfd_IdNave") 'Nave de say
            c.IdComprobantecfdsOrdenCompra = row("cfd_Id")
        Next
        Return c
    End Function
    Function validaFacturasSeleccionas() As Boolean
        Dim datos As New DataTable
        datos = grdFacturas.DataSource
        Dim contador As Integer = 0
        For Each row As DataRow In datos.Rows
            If CBool(row("seleccion")) Then
                contador += 1
                If contador >= 2 Then
                    adv.mensaje = "Selecciona una sola factura."
                    adv.ShowDialog()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Function getNumOrden(num As String) As String
        If num.Length = 1 Then
            num = "0000" & num
        ElseIf num.Length = 2 Then
            num = "000" & num
        ElseIf num.Length = 3 Then
            num = "00" & num
        ElseIf num.Length = 4 Then
            num = "0" & num
        ElseIf num.Length = 5 Then
            num = num
        End If
        Return num
    End Function

    Private Sub cmbEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        Try
            If cmbEmpresa.SelectedValue > 0 Then
                llenarGrid()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub llenarGrid()
        Dim obj As New RecepcionBU
        Dim datos As New DataTable
        datos = obj.getFacturas(idNave, idProveedor, total, cmbEmpresa.SelectedValue, idmoneda)
        grdFacturas.DataSource = datos
        With grdFacturas.DisplayLayout.Bands(0)
            .Columns("cfd_Id").Hidden = True
            .Columns("cfd_IdComprobantesicy").Hidden = True
            .Columns("cfd_Serie").Hidden = True
            .Columns("cfd_Folio").Hidden = True
            .Columns("cfd_RfcEmpresa").Hidden = True
            .Columns("cfd_RfcProveedor").Hidden = True
            .Columns("cfd_modenaid").Hidden = True
            .Columns("Total").Format = "##,##0.00"
            .Columns("Subtotal").Format = "##,##0.00"
            .Columns("IVA").Format = "##,##0.00"
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("SubTotal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("IVA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Seleccion").Width = 20
            .Columns("cfd_IdNave").Hidden = True
        End With

        grdFacturas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdFacturas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdFacturas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub grdFacturas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdFacturas.ClickCell
        Try
            If e.Cell.Column.ToString <> "seleccion" Then
                grdFacturas.ActiveRow.Selected = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPlazos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlazos.SelectedIndexChanged
        Try
            If cmbPlazos.SelectedValue > 0 Then
                Dim c As New CxPSaldos

                c = getDatosSemanadePago(c)
                lblSemanaPago.Text = "" & getFechaPagoMiercoles(c.FECVENTO).ToString("dd/MM/yyyy") & " (SEM " & c.SEMPAGADA.ToString & ")"

            End If
        Catch ex As Exception

        End Try
    End Sub

    Function getFechaPagoMiercoles(ByVal fecha As Date) As Date
        Dim f As New Date

        For i As Integer = 1 To 6
            f = fecha.AddDays(-i)
            Dim s As String
            s = f.DayOfWeek
            If s = "3" Then
                Return f
            End If
        Next
        Return f
    End Function
End Class