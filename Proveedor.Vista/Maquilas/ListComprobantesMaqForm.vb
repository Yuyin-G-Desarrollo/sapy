Imports Tools
Imports Proveedores.DA
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Entidades
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class ListComprobantesMaqForm
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim listaProveedores As New List(Of Integer)
    Dim listaidComprobantes As New List(Of Integer)

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbParametros.Width = 92
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        grbParametros.Width = 31
    End Sub
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub ListComprobantesMaqForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboNaves()
        aplicarPermisos()
    End Sub
    Private Sub aplicarPermisos()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "AUTORIZARCOMPROBANTE") Then
            btnAutorizar.Visible = True
            lblAutorizar.Visible = True
        Else
            btnAutorizar.Visible = False
            lblAutorizar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "RECHAZARCOMPROBANTE") Then
            btnRechazar.Visible = True
            lblRechazar.Visible = True
        Else
            btnRechazar.Visible = False
            lblRechazar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "SUSTITUIRCOMPROBANTE") Then
            btnSustituir.Visible = True
            lblSustituir.Visible = True
        Else
            btnSustituir.Visible = False
            lblSustituir.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "REMPLAZARCOMPROBANTE") Then
            btnRemplazar.Visible = True
            lblRemplazar.Visible = True
        Else
            btnRemplazar.Visible = False
            lblRemplazar.Visible = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ComprobantesMaquilas", "DEVOLUCION") Then
            btnDevolucion.Visible = True
            lblDev.Visible = True
        Else
            btnDevolucion.Visible = False
            lblDev.Visible = False
        End If
    End Sub
    Public Sub llenarComboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        If cmbNave.Items.Count = 2 Then
            cmbNave.SelectedIndex = 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        Dim obj As New AgregarComprobanteBU
        Dim datos As New DataTable
        Dim estatus As String = ""
        Dim tipoFecha As String = ""
        If cmbEstatus.SelectedItem = "CAPTURADO" Then
            estatus = "C"
        ElseIf cmbEstatus.SelectedItem = "AUTORIZADO" Then
            estatus = "A"
        ElseIf cmbEstatus.SelectedItem = "RECHAZADO" Then
            estatus = "R"
        End If
        If rdbFecIngreso.Checked = True Then
            tipoFecha = "FechaIngreso"
        ElseIf rdbFecDoc.Checked = True Then
            tipoFecha = "FechaDocumento"
        ElseIf rdbFecCaptura.Checked = True Then
            tipoFecha = "FechaCreacion"
        ElseIf rdbFechaVenc.Checked = True Then
            tipoFecha = "FechaVencimiento"
        End If
        If cmbNave.SelectedIndex > 0 Then
            datos = obj.getComprobantes(cmbNave.SelectedValue, estatus, tipoFecha, dtpFechaFinal.Value, dtpFechaInicio.Value)
            grdComprobantes.DataSource = datos
            disenioGrid()
        End If

    End Sub

    Public Sub disenioGrid()
        Try
            With grdComprobantes.DisplayLayout.Bands(0)
                .Columns("maco_comprobanteid").Hidden = True
                .Columns("IdNave").Hidden = True
                .Columns("IdProveedor").Hidden = True
                .Columns("maco_estatus").Hidden = True
                .Columns("maco_receptorid").Hidden = True
                '.Columns("Seleccion").Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor
                .Columns("seleccionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("seleccionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("seleccionar").Header.Caption = " "
                .Columns("Vacia").Header.Caption = " "
                .Columns("seleccionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Subtotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("IVA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Descuento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                .Columns("Seleccionar").Width = 12
                .Columns("Descuento").Format = "##,##0.00"
                .Columns("XML").Width = 35
                .Columns("PDF").Width = 35
                .Columns("Vacia").Width = 8
                .Columns("PDF").CellAppearance.ForeColor = Drawing.Color.RoyalBlue
                .Columns("XML").CellAppearance.ForeColor = Drawing.Color.RoyalBlue
                .Columns("Total").Format = "##,##0.00"
                .Columns("Subtotal").Format = "##,##0.00"
                .Columns("IVA").Format = "##,##0.00"
                .Columns("Sem Compra").Format = "##,##0"
                .Columns("Sem Pago").Format = "##,##0"
                .Columns("Vacia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Fecha Ingreso").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Fecha Documento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Fecha Captura").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Tipo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Folio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Razón Social Emisor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Razón Social Receptor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Subtotal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("IVA").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Sem Compra").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Sem Pago").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("XML").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("PDF").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("PDF").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
                .Columns("XML").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
                .Columns("Descuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End With
            grdComprobantes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdComprobantes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            pintarceldas()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub pintarceldas()
        Try
            Dim conPrecio As Integer = 0
            Dim sinPrecio As Integer = 0
            Dim i As Integer = 0
            Do
                If grdComprobantes.Rows(i).Cells("maco_estatus").Value.ToString.Trim = "C" Then
                    grdComprobantes.Rows(i).Cells("Vacia").Appearance.BackColor = Color.Yellow
                ElseIf grdComprobantes.Rows(i).Cells("maco_estatus").Value.ToString.Trim = "A" Then
                    grdComprobantes.Rows(i).Cells("Vacia").Appearance.BackColor = Color.GreenYellow
                ElseIf grdComprobantes.Rows(i).Cells("maco_estatus").Value.ToString.Trim = "R" Then
                    grdComprobantes.Rows(i).Cells("Vacia").Appearance.BackColor = Color.Salmon
                End If
                i += 1
            Loop While i < grdComprobantes.Rows.Count
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdComprobantes_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdComprobantes.DoubleClickCell
        If grdComprobantes.ActiveRow.Index > -1 Then
            Try
                If grdComprobantes.ActiveCell.Column.ToString = "PDF" Or grdComprobantes.ActiveCell.Column.ToString = "XML" Then
                    If grdComprobantes.ActiveCell.Value.ToString.Length > 0 Then
                        Process.Start(grdComprobantes.ActiveCell.Value.ToString)
                    End If
                End If
            Catch ex As Exception
                adv.mensaje = "No se puede localizar el archivo."
                adv.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub btnAddComp_Click(sender As Object, e As EventArgs) Handles btnAddComp.Click
        If cmbNave.SelectedIndex > 0 Then
            Dim obj As New ListaPreciosProdBU
            Dim obj2 As New AgregarComprobanteBU
            If dtpFechaInicio.Value = dtpFechaFinal.Value Then
                If obj2.verificarFecha(dtpFechaInicio.Value, cmbNave.SelectedValue) Then
                    Dim form As New AgregarComprobanteMaquila
                    form.fecha = dtpFechaInicio.Value
                    form.nave = cmbNave.SelectedValue
                    form.nombreNave = obj.getNombreNave(cmbNave.SelectedValue)
                    form.ShowDialog()
                Else
                    adv.mensaje = "Ya existen comprobantes para esta fecha."
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Solo puede subir comprobantes de un solo día, se tomará la primera fecha seleccionada."
                adv.ShowDialog()
                If obj2.verificarFecha(dtpFechaInicio.Value, cmbNave.SelectedValue) Then
                    Dim form As New AgregarComprobanteMaquila
                    form.fecha = dtpFechaInicio.Value
                    form.nave = cmbNave.SelectedValue
                    form.nombreNave = obj.getNombreNave(cmbNave.SelectedValue)
                    form.ShowDialog()
                Else
                    adv.mensaje = "Ya existen comprobantes para esta fecha."
                    adv.ShowDialog()
                End If
            End If
        Else
            adv.mensaje = "Seleccione una nave."
            adv.ShowDialog()
        End If
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        If validarDiferentesNaves() Then
            autorizarFacturas()
            autorizarRemisiones()
            enviarCorreoProveedores()
            llenarGrid()
            listaProveedores.Clear()
            listaidComprobantes.Clear()
        Else
            adv.mensaje = "Tiene seleccionadas remisiones de diferentes naves. Para autorizarlas tiene que seleccionar remisiones de la misma nave"
            adv.ShowDialog()
        End If

    End Sub
    Function validarDiferentesNaves() As Boolean
        Dim tab As New DataTable
        Dim listNaves As New List(Of String)
        tab = grdComprobantes.DataSource
        For Each row As DataRow In tab.Rows
            If CBool(row("Seleccionar")) Then
                If row("Tipo") = "R" Then
                    If row("maco_estatus").ToString.Trim = "C" Then
                        listNaves.Add(row("Nave"))
                        For Each nave As String In listNaves
                            If Not nave = row("Nave") Then
                                Return False
                            End If
                        Next
                    End If
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        If validarDiferentesNaves() Then
            rechazarRemisionesFacturas()
            listaidComprobantes.Clear()
            listaProveedores.Clear()
            llenarGrid()
        Else
            adv.mensaje = "Tiene seleccionadas remisiones de diferentes naves. Para rechazarlas tiene que seleccionar remisiones de la misma nave"
            adv.ShowDialog()
        End If
    End Sub
    Private Sub autorizarFacturas()
        Dim obj As New ConfigProveedorMaquilaBU
        Dim tab As New DataTable
        Dim listComprobante As New List(Of MaquilaComprobante)
        Dim listIdComp As New List(Of Integer)
        Dim listIdProveedores As New List(Of Integer)
        Dim obj2 As New AgregarComprobanteBU
        Dim m As New MaquilaComprobante
        Dim datosPago As New DatosPago
        Dim d As New MaquilaComprobante
        Dim diasCredito As Integer = 0
        tab = grdComprobantes.DataSource
        Dim totalFacturas As Integer = 0
        For Each row As DataRow In tab.Rows
            If CBool(row("Seleccionar")) Then
                If row("Tipo") = "F" Then
                    If row("maco_estatus").ToString.Trim = "C" Then
                        d = New MaquilaComprobante
                        d.folio = row("Folio")
                        d.idComprobante = row("maco_comprobanteid")
                        d.receptorid = row("maco_receptorid")
                        Try
                            d.proveedorid = row("IdProveedor")
                        Catch ex As Exception
                            d.proveedorid = 0
                        End Try
                        d.idNave = row("IdNave")
                        listComprobante.Add(d)
                        totalFacturas += 1
                    End If
                End If
            End If
        Next
        If totalFacturas > 0 Then
            Dim cadena As String = ""
            Dim ban As Integer = 0
            For Each folio As MaquilaComprobante In listComprobante
                If ban = 0 Then
                    cadena += "" & folio.folio
                Else
                    cadena += "," & folio.folio
                End If
                ban += 1
            Next
            Dim form As New ConfirmarRemisionesForm
            form.lblRemisiones.Text = cadena
            form.lblMensaje.Text = "Confirme el registro del proveedor para las siguientes facturas:"
            form.lstProveedores = obj.getProveedoresNaveConfigurados(d.idNave)
            form.ShowDialog()
            If form.cancelado = False Then

                If form.idProveedor > 0 Then
                    agregarProveedor(form.idProveedor)
                    diasCredito = obj2.getDiasCredito(form.idProveedor)
                    datosPago = getFechaPago(Date.Now, diasCredito)
                    m.datosPagoCompra = datosPago
                    For Each comprobante As MaquilaComprobante In listComprobante
                        If comprobante.proveedorid = 0 Then
                            If datosPago.semanaPago > 0 Then
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                diasCredito = obj2.getDiasCredito(form.idProveedor)
                                datosPago = getFechaPago(Date.Now, diasCredito)
                                m.datosPagoCompra = datosPago
                                m.idComprobante = comprobante.idComprobante
                                m.receptorid = comprobante.receptorid
                                m.proveedorid = form.idProveedor
                                listaidComprobantes.Add(comprobante.idComprobante)
                                obj2.updateComprobanteMaquila(m)
                                m.estatus = "A"
                                obj2.updateEstatusComprobanteMaquila(m)
                                obj2.InsertcxpSaldoscxpMovimientos(m)
                                Me.Cursor = Windows.Forms.Cursors.Default
                            End If
                        ElseIf form.idProveedor = comprobante.proveedorid Then
                            If datosPago.semanaPago > 0 Then
                                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                diasCredito = obj2.getDiasCredito(form.idProveedor)
                                datosPago = getFechaPago(Date.Now, diasCredito)
                                m.datosPagoCompra = datosPago
                                m.idComprobante = comprobante.idComprobante
                                listaidComprobantes.Add(comprobante.idComprobante)
                                m.receptorid = comprobante.receptorid
                                m.proveedorid = form.idProveedor
                                obj2.updateComprobanteMaquila(m)
                                m.estatus = "A"
                                obj2.updateEstatusComprobanteMaquila(m)
                                obj2.InsertcxpSaldoscxpMovimientos(m)
                                Me.Cursor = Windows.Forms.Cursors.Default
                            End If
                        Else
                            Dim conf As New Tools.ConfirmarForm
                            conf.mensaje = "El proveedor de la factura-folio: " & comprobante.folio & " es diferente al seleccionado, ¿Desea Rechazarlo?"
                            If conf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                If datosPago.semanaPago > 0 Then
                                    Me.Cursor = Windows.Forms.Cursors.WaitCursor
                                    diasCredito = obj2.getDiasCredito(form.idProveedor)
                                    datosPago = getFechaPago(Date.Now, diasCredito)
                                    m.datosPagoCompra = datosPago
                                    m.idComprobante = comprobante.idComprobante
                                    listaidComprobantes.Add(comprobante.idComprobante)
                                    m.receptorid = comprobante.receptorid
                                    m.proveedorid = form.idProveedor
                                    obj2.updateComprobanteMaquila(m)
                                    m.estatus = "A"
                                    obj2.updateEstatusComprobanteMaquila(m)
                                    obj2.InsertcxpSaldoscxpMovimientos(m)
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                End If
                            End If
                        End If
                    Next
                    Me.Cursor = Windows.Forms.Cursors.Default
                    exito.mensaje = "Facturas autorizadas."
                    exito.ShowDialog()
                End If
            End If
        End If
    End Sub
    Private Sub autorizarRemisiones()
        Dim obj As New ConfigProveedorMaquilaBU
        Dim tab As New DataTable

        Dim listFolios As New List(Of String)
        Dim listIdComp As New List(Of Integer)
        Dim idNave As Integer = 0
        Dim obj2 As New AgregarComprobanteBU
        Dim m As New MaquilaComprobante
        Dim datosPago As New DatosPago
        Dim diasCredito As Integer = 0
        tab = grdComprobantes.DataSource
        Dim totalRemisiones As Integer = 0
        Dim totalFacturas As Integer = 0
        For Each row As DataRow In tab.Rows
            If CBool(row("Seleccionar")) Then
                If row("Tipo") = "R" Then
                    If row("maco_estatus").ToString.Trim = "C" Then
                        listFolios.Add(row("Folio"))
                        listIdComp.Add(row("maco_comprobanteid"))
                        idNave = row("IdNave")
                        totalRemisiones += 1
                    End If
                End If
            End If
        Next
        If totalRemisiones > 0 Then
            Dim cadena As String = ""
            Dim ban As Integer = 0
            For Each folio As String In listFolios
                If ban = 0 Then
                    cadena += "" & folio
                Else
                    cadena += "," & folio
                End If
                ban += 1
            Next
            Dim form As New ConfirmarRemisionesForm
            form.lblRemisiones.Text = cadena
            Dim proveedores As New DataTable
            form.lstProveedores = obj.getProveedoresNaveConfigurados(idNave)
            form.ShowDialog()
            If form.cancelado = False Then
                Me.Cursor = Windows.Forms.Cursors.WaitCursor
                If form.idProveedor > 0 Then
                    Dim remFalsas As Integer = 0
                    agregarProveedor(form.idProveedor)
                    diasCredito = obj2.getDiasCredito(form.idProveedor)
                    datosPago = getFechaPago(Date.Now, diasCredito)
                    m.datosPagoCompra = datosPago

                    For Each idComprobante As Integer In listIdComp
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        If datosPago.semanaPago > 0 Then
                            m.idComprobante = idComprobante
                            listaidComprobantes.Add(idComprobante)
                            m.proveedorid = form.idProveedor                           
                            remFalsas += enviarcxpSaldos(m)
                        End If
                        Me.Cursor = Windows.Forms.Cursors.Default
                    Next
                    Me.Cursor = Windows.Forms.Cursors.Default
                    If remFalsas > 0 Then
                        adv.mensaje = "Algunas Remisiones(" & remFalsas & ") no se autorizaron."
                        adv.ShowDialog()
                    Else
                        exito.mensaje = "Remisiones autorizadas."
                        exito.ShowDialog()
                    End If
                    
                End If
            End If
        End If
    End Sub
    Function enviarcxpSaldos(m As MaquilaComprobante) As Integer
        Dim verffolio As New DataTable
        Dim obj2 As New AgregarComprobanteBU
        verffolio = obj2.verificarFolioCxpagar(m)
        If verffolio.Rows.Count > 0 Then
            adv.mensaje = "El folio ya existe, sustituya el folio para autorizar."
            adv.ShowDialog()
            Dim form As New SustituirDocMaquila
            form.idComprobante = m.idComprobante
            form.accion = "sustituir"
            form.ShowDialog()
            If form.banderaAccion = 1 Then
                enviarcxpSaldos(m)
            Else
                Return 1
            End If
        Else
            obj2.updateComprobanteMaquila(m)
            m.estatus = "A"
            obj2.updateEstatusComprobanteMaquila(m)
            obj2.InsertcxpSaldoscxpMovimientos(m)
            Return 0
        End If
        Return 0
    End Function

    Private Sub rechazarRemisionesFacturas()
        Dim tab As New DataTable
        Dim obj As New ConfigProveedorMaquilaBU
        Dim obj2 As New AgregarComprobanteBU
        Dim m As New MaquilaComprobante
        Dim listFoliosRemisiones As New List(Of String)
        tab = grdComprobantes.DataSource
        Dim totalRemisiones As Integer = 0
        Dim totalFacturas As Integer = 0
        For Each row As DataRow In tab.Rows
            If CBool(row("Seleccionar")) Then
                If row("Tipo") = "R" Then
                    If row("maco_estatus").ToString.Trim = "C" Then
                        listaidComprobantes.Add(row("maco_comprobanteid"))
                        listFoliosRemisiones.Add(row("Folio"))
                        totalRemisiones += 1
                    End If
                ElseIf row("Tipo") = "F" Then
                    If row("maco_estatus").ToString.Trim = "C" Then
                        listaidComprobantes.Add(row("maco_comprobanteid"))
                        agregarProveedor(row("IdProveedor"))
                        totalFacturas += 1
                    End If                
                End If
            End If
        Next
        If totalRemisiones > 0 Or totalFacturas > 0 Then
            Dim conf As New Tools.ConfirmarForm
            conf.mensaje = "Hay (" & totalRemisiones & ") Remisiones y (" & totalFacturas & ") Facturas seleccionadas, ¿Desea Rechazarlas?"
            If conf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim f As New MotivoRechazoForm
                f.ShowDialog()
                If f.cancelado = False Then
                    Dim cadena As String = ""
                    Dim ban As Integer = 0
                    For Each folio As String In listFoliosRemisiones
                        If ban = 0 Then
                            cadena += "" & folio
                        Else
                            cadena += "," & folio
                        End If
                        ban += 1
                    Next
                    Dim estatusCambiado As Boolean = False
                    If totalRemisiones > 0 Then
                        Dim form As New ConfirmarRemisionesForm
                        form.lblRemisiones.Text = cadena
                        form.lblMensaje.Text = "Confirme el proveedor para las siguientes remisiones:"
                        form.lstProveedores = obj.getProveedoresNaveConfigurados(obj.getNaveSIcy(cmbNave.SelectedValue))
                        form.ShowDialog()
                        If form.cancelado = False Then
                            Me.Cursor = Windows.Forms.Cursors.WaitCursor
                            agregarProveedor(form.idProveedor)
                            estatusCambiado = True
                            For Each idComprobante As Integer In listaidComprobantes
                                m.estatus = "R"
                                m.idComprobante = idComprobante
                                m.motivo = f.txtMotivo.Text
                                obj2.updateEstatusComprobanteMaquila(m)
                            Next
                            enviarCorreoRechazoComprobantes(f.txtMotivo.Text.Trim, form.idProveedor)
                        End If
                    End If
                    If totalFacturas > 0 And estatusCambiado = False Then
                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        For Each idComprobante As Integer In listaidComprobantes
                            m.estatus = "R"
                            m.idComprobante = idComprobante
                            m.motivo = f.txtMotivo.Text
                            obj2.updateEstatusComprobanteMaquila(m)
                        Next
                        enviarCorreoRechazoComprobantes(f.txtMotivo.Text.Trim, 0)
                    End If
                    exito.mensaje = "Remisiones y Facturas rechazadas."
                    exito.ShowDialog()
                End If
            End If
        End If
    End Sub
    Function getFechaPago(ByVal fInicio As Date, ByVal DiasCredito As Integer) As DatosPago
        'Domingo=0,Lunes=1, Martes=2,Miercoles=3,Jueves=4,Viernes=5,Sabado=6
        Dim datosPago As New DatosPago
        Dim datosCompra As New DataTable
        Dim diasTotales As Double = 0
        Dim fFin As New Date
        Dim datosFechaPago As New DataTable
        Dim obj As New AgregarComprobanteBU
        fFin = fInicio.AddDays(DiasCredito)
        If obj.validarSiExistenDiasInhabiles(fInicio, fFin).Rows.Count > 5 Then 'Existen Dias no laborables
            fFin = getFechaMasDiasInhabiles(fInicio, fFin)
            datosFechaPago = obj.getSemana(fFin)
            datosCompra = obj.getSemana(fInicio)
            If datosFechaPago.Rows.Count > 0 Then
                datosPago.añoPago = datosFechaPago.Rows(0).Item("numano").ToString
                datosPago.fechaPago = fFin
                datosPago.semanaPago = datosFechaPago.Rows(0).Item("numsem").ToString
                datosPago.semanaCompra = datosCompra.Rows(0).Item("numsem").ToString
                datosPago.añoCompra = datosCompra.Rows(0).Item("numano").ToString
            End If
        Else 'No hay días no laborales
            datosFechaPago = obj.getSemana(fFin)
            datosCompra = obj.getSemana(fInicio)
            If datosFechaPago.Rows.Count > 0 Then
                datosPago.añoPago = datosFechaPago.Rows(0).Item("numano").ToString
                datosPago.fechaPago = fFin
                datosPago.semanaPago = datosFechaPago.Rows(0).Item("numsem").ToString
                datosPago.semanaCompra = datosCompra.Rows(0).Item("numsem").ToString
                datosPago.añoCompra = datosCompra.Rows(0).Item("numano").ToString
            End If
        End If
        Return datosPago
    End Function

    Function getFechaMasDiasInhabiles(ByVal fInicio As Date, ByVal fFin As Date) As Date
        Dim diasNoLaborables As Integer = 0
        Dim dias As Integer = 0
        Dim diasAgregar As Integer = 0
        Dim obj As New AgregarComprobanteBU
        Dim datosInhabiles As New DataTable
        dias = DateDiff(DateInterval.Day, fInicio, fFin) 'dias que existen entre el rango de fechas
        If obj.validarSiExistenDiasInhabiles(fInicio, fFin).Rows.Count > 0 Then 'Existen Dias no laborables
            For index As Integer = 0 To dias
                If Not obj.validarSiesDiaHabil(DateAdd(DateInterval.Day, index, fInicio)) Then
                    diasAgregar += 1
                End If
            Next
            fFin = getFechaMasDiasInhabiles(fFin, DateAdd(DateInterval.Day, diasAgregar, fFin))
        End If
        Return fFin
    End Function
    Private Sub agregarProveedor(ByVal idProveedor As Integer)
        Dim ban As Boolean = False
        If listaProveedores.Count = 0 Then
            listaProveedores.Add(idProveedor)
        End If
        For Each id As Integer In listaProveedores
            If id = idProveedor Then
                ban = False
            End If
        Next
        If ban Then
            listaProveedores.Add(idProveedor)
        End If
    End Sub
    Private Sub enviarCorreoRechazoComprobantes(motivo As String, idProveedorRemisiones As Integer)
        Dim body As String = ""
        Dim datosProv As New DataTable
        Dim obj As New AgregarComprobanteBU
        Dim ids As String = ""
        Dim email As String = ""
        Dim total As String = ""
        body += " <head>"
        body += " <style type='text/css'>"
        body += " td {border: 1px solid black; padding: 8px; }"
        body += " </style>"
        body += " </head>"
        body += " <body style='font-family:arial;'> "
        body += " Se han rechazados los siguientes documentos, favor de ingresar al sistema para reemplazar los comprobantes. </br>"
        body += " <table style='width:100%; border: 0px;   font-family:arial;  border-collapse: collapse;'>"
        body += " <tr><td style='border: 0px;'>Motivo:</td><td style='border: 0px;'> " & motivo & " </td></tr>"
        body += "<tr><td style='border: 0px;'>Usuario:</td><td style='border: 0px;'>" & Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal & " </td></tr>"
        body += "<tr><td style='border: 0px;'>Fecha:</td><td style='border: 0px;'> " & Date.Now.ToString("dd/MM/yyyy mm:HH") & " </td></tr></table>"
        body += " <table style='width:100%; border: 1px solid black; padding: 8px;     font-family:arial;  border-collapse: collapse;'>"
        body += " <tr>"
        body += " <td style='font-weight: bold;'> Folio             </td>"
        body += " <td style='font-weight: bold;'> Tipo              </td> "
        body += " <td style='font-weight: bold;'> Fecha Documento   </td>"
        body += " <td style='font-weight: bold;'> Fecha Ingreso     </td>"
        body += " <td style='font-weight: bold;'> Fecha Captura     </td>"
        body += " <td style='font-weight: bold;'> Emisor            </td>"
        body += " <td style='font-weight: bold;'> Receptor          </td>"
        body += " <td style='font-weight: bold;'> Total             </td>"
        body += " </tr>"
        For Each i As Integer In listaidComprobantes
            ids += "" & i & ","
        Next
        ids += "0"

        Dim registros As String = ""
        For Each i As Integer In listaProveedores
            If i = idProveedorRemisiones Then
                datosProv = obj.getInfoIdCompProveedor("" & i & ",0", ids) 'Aqui estan incluidas las remisiones que aun no tiene proveedor asignado
            Else
                datosProv = obj.getInfoIdCompProveedor(i, ids)
            End If
            email = obj.getEmailProveedor(i).Rows(0).Item("Email").ToString
            registros = ""
            For Each row As DataRow In datosProv.Rows
                registros += " <tr>"
                registros += " <td>" & row("Folio") & "</td>"
                registros += " <td>" & row("Tipo") & "</td>"
                registros += " <td>" & row("Fecha Documento") & "</td>"
                registros += " <td>" & row("Fecha Ingreso") & "</td>"
                registros += " <td>" & Convert.ToDateTime(row("Fecha Captura")).ToString("dd/MM/yyyy") & "</td>"
                registros += " <td>" & row("Emisor") & "</td>"
                registros += " <td>" & row("Receptor") & "</td>"
                total = "" & Convert.ToDouble(row("Total")).ToString("##,##0.00")
                registros += " <td>" & total & "</td>"
                registros += " </tr>"
            Next
            registros += " </table>"
            registros += " <body>"
            If email <> String.Empty Then
                EnviarCorreoArchivo(email, body & registros, "Comprobantes Rechazados.")
            End If
        Next
    End Sub
    Private Sub enviarCorreoProveedores()
        Dim body As String = ""
        Dim datosProv As New DataTable
        Dim obj As New AgregarComprobanteBU
        Dim ids As String = ""
        Dim email As String = ""
        Dim total As String = ""
        body += " <head>"
        body += " <style type='text/css'>"
        body += " td {border: 1px solid black; padding: 8px; }"
        body += " </style>"
        body += " </head>"
        body += " <body style='font-family:arial;'> Se han autorizado los siguientes documentos: </br>"
        body += " <table style='width:100%; border: 1px solid black; padding: 8px;     font-family:arial;  border-collapse: collapse;'>"
        body += " <tr>"
        body += " <td style='font-weight: bold;'> Folio</td>"
        body += " <td style='font-weight: bold;'> Tipo</td> "
        body += " <td style='font-weight: bold;'> Fecha Documento</td>"
        body += " <td style='font-weight: bold;'> Fecha Ingreso</td>"
        body += " <td style='font-weight: bold;'> Fecha Captura</td>"
        body += " <td style='font-weight: bold;'> Emisor</td>"
        body += " <td style='font-weight: bold;'> Receptor</td>"
        body += " <td style='font-weight: bold;'> Total</td>"
        body += " <td style='font-weight: bold;'> Semana Pago</td>"
        body += " </tr>"
        For Each i As Integer In listaidComprobantes
            ids += "" & i & ","
        Next
        ids += "0"
        Dim registros As String = ""
        For Each i As Integer In listaProveedores
            datosProv = obj.getInfoIdCompProveedor(i, ids)
            email = obj.getEmailProveedor(i).Rows(0).Item("Email").ToString
            registros = ""
            For Each row As DataRow In datosProv.Rows
                registros += " <tr>"
                registros += " <td>" & row("Folio") & "</td>"
                registros += " <td>" & row("Tipo") & "</td>"
                registros += " <td>" & row("Fecha Documento") & "</td>"
                registros += " <td>" & row("Fecha Ingreso") & "</td>"
                registros += " <td>" & Convert.ToDateTime(row("Fecha Captura")).ToString("dd/MM/yyyy") & "</td>"
                registros += " <td>" & row("Emisor") & "</td>"
                registros += " <td>" & row("Receptor") & "</td>"
                total = "" & Convert.ToDouble(row("Total")).ToString("##,##0.00")
                registros += " <td>" & total & "</td>"
                registros += " <td>" & row("Semana Pago") & "</td>"
                registros += " </tr>"
            Next
            registros += " </table>"
            registros += " <body>"
            If email <> String.Empty Then
                EnviarCorreoArchivo(email, body & registros, "Autorización de comprobantes de compra de producto terminado")
            End If
        Next       
    End Sub
    Private Shared mailSent As Boolean = False
    Private Shared Sub SendCompletedCallback(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        'Get the unique identifier for this asynchronous operation.
        Dim token As String = CStr(e.UserState)
        Dim a As New AdvertenciaForm
        Dim x As New ExitoForm
        If e.Cancelled Then
            a.mensaje = "Mensaje cancelado."
            a.ShowDialog()
        End If
        If e.Error IsNot Nothing Then
            a.mensaje = " " + e.Error.ToString()
            a.ShowDialog()
        Else
            x.mensaje = "Mensaje enviado."
            x.ShowDialog()
        End If
        mailSent = True
        CType(sender, SmtpClient).Dispose()
    End Sub

    Public Sub EnviarCorreoArchivo(ByVal email As String, ByVal body As String, ByVal asunto As String)
        Dim a As New AdvertenciaForm
        Try
            Dim mensaje As String = "Mensaje enviado correctamente"
            Dim x As New ExitoForm
            Dim destinatarios As String = ""
            Dim cliente As New SmtpClient
            Dim smtp As New Entidades.SMTP
            Dim autenticacion As New System.Net.NetworkCredential("servicioselectronicos4@grupoyuyin.com.mx", "12345")
            cliente.Credentials = autenticacion
            cliente.Host = "smtpout.secureserver.net"
            cliente.Port = 3535
            cliente.EnableSsl = True
            destinatarios = "cdesarrollo.ti@grupoyuyin.com.mx,ge_ti@grupoyuyin.com.mx,proveedores@grupoyuyin.com.mx,ge_administracion@grupoyuyin.com.mx"
            'destinatarios = "cdesarrollo.ti@grupoyuyin.com.mx" 'Aqui va el parametro de email
            'Dim [from] As New MailAddress("servicioselectronicos@grupoyuyin.com","servicioselectronicos@grupoyuyin.com", System.Text.Encoding.UTF8)
            Dim mailMsg As New MailMessage()
            'Asigna los destinatarios.
            For Each mail As String In destinatarios.Split(New Char() {","c})
                mailMsg.To.Add(New System.Net.Mail.MailAddress(mail))
            Next
            mailMsg.From = New System.Net.Mail.MailAddress("servicioselectronicos4@grupoyuyin.com.mx")
            mailMsg.BodyEncoding = System.Text.Encoding.UTF8
            mailMsg.Body = body
            mailMsg.Subject = asunto
            mailMsg.SubjectEncoding = System.Text.Encoding.UTF8
            mailMsg.IsBodyHtml = True
            AddHandler cliente.SendCompleted, AddressOf SendCompletedCallback
            Dim userState As String = "test message1"
            Me.Cursor = Cursors.WaitCursor
            cliente.Send(mailMsg)
            x.mensaje = "Mensaje enviado."
            x.ShowDialog()
            Me.Cursor = Cursors.Default
            'cliente.SendAsync(mailMsg, userState)
            'Me.Cursor = Cursors.WaitCursor
            'If Not BackgroundWorker1.IsBusy Then
            '    BackgroundWorker1.RunWorkerAsync()
            'End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            a.mensaje = "Surgió algo inesperado: " & ex.Message
            a.ShowDialog()
        End Try
        
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Not BackgroundWorker1.IsBusy Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If mailSent = True Then
                mailSent = False
                Me.Cursor = Cursors.Default
                BackgroundWorker1.CancelAsync()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnSustituir.Click

        For Each row As UltraGridRow In grdComprobantes.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                If row.Cells("maco_estatus").Value.ToString.Trim = "C" Then
                    Dim form As New SustituirDocMaquila
                    form.idComprobante = grdComprobantes.ActiveRow.Cells("maco_comprobanteid").Value
                    form.accion = "sustituir"
                    form.ShowDialog()
                    llenarGrid()
                    Return
                End If
            End If
        Next
        adv.mensaje = "Selecciona un comprobante SIN AUTORIZAR para sustituirlo."
        adv.ShowDialog()
    End Sub
   
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles btnRemplazar.Click
        For Each row As UltraGridRow In grdComprobantes.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                If row.Cells("maco_estatus").Value.ToString.Trim <> "A" Then
                    Dim form As New SustituirDocMaquila
                    form.idComprobante = grdComprobantes.ActiveRow.Cells("maco_comprobanteid").Value
                    form.accion = "remplazar"
                    form.ShowDialog()
                    llenarGrid()
                    Return
                Else
                    adv.mensaje = "El documento ya fue autorizado, no puede reemplazarse."
                    adv.ShowDialog()
                    Return
                End If
            End If
        Next
        adv.mensaje = "Selecciona un comprobante con estatus Capturado o Rechazado para remplazarlo."
        adv.ShowDialog()
    End Sub

    Private Sub btnDevolucion_Click(sender As Object, e As EventArgs) Handles btnDevolucion.Click
        Dim form As New AsignarDevolucionesForm
        For Each row As UltraGridRow In grdComprobantes.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                If row.Cells("maco_estatus").Value.ToString.Trim = "C" Then
                    If row.Cells("Tipo").Value.ToString.Trim = "R" Then
                        form.idComprobante = row.Cells("maco_comprobanteid").Value
                        form.fechaInicio = dtpFechaInicio.Value
                        form.fechaFin = dtpFechaFinal.Value
                        form.idNave = row.Cells("IdNave").Value
                        form.totalFinal = row.Cells("Total").Value
                        form.ShowDialog()
                        llenarGrid()
                        Return
                    End If
                End If
            End If
        Next
        adv.mensaje = "Selecciona un comprobante tipo remisión y con estatus Capturado."
        adv.ShowDialog()
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim seleccion As Integer = 0
        Dim msjAdv As New Tools.AdvertenciaForm

        For Each rowSel As UltraGridRow In grdComprobantes.Rows
            If CBool(rowSel.Cells("Seleccionar").Value) = True Then
                seleccion += 1
            End If
        Next

        If seleccion = 0 Then
            msjAdv.mensaje = "Debe seleccionar un registro para ver el detalle."
            msjAdv.Show()
        ElseIf seleccion > 1 Then
            msjAdv.mensaje = "Debe seleccionar solamente un registro para ver el detalle."
            msjAdv.Show()
        Else

            For Each row As UltraGridRow In grdComprobantes.Rows
                If CBool(row.Cells("Seleccionar").Value) = True Then

                    Dim form As New DetalleComprobanteMaquilaForm
                    form.idcomprobante = row.Cells("maco_comprobanteid").Value
                    form.ShowDialog()

                    llenarGrid()

                End If
            Next
        End If
    End Sub
End Class