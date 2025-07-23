Imports System.Drawing
Imports System.Windows.Forms
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Proveedores.DA
Imports Proveedores.BU
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.ComponentModel
Imports Stimulsoft.Report.Export
Imports Stimulsoft.Report

Public Class CapturaOrdenesDeCompraForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim entrega As Integer = 0
    Dim folio As Integer
    Dim Total As Double = 0
    Dim IVA As Double = 0
    Dim Subtotal As Double = 0
    Dim id As Integer
    Dim dt As New DataTable("Datos")
    Dim NUMERO As Integer
    Dim SEMANA As Integer

    Public list As New List(Of Integer)
    Public listaeliminar As New List(Of Integer)
    Private Shared mailSent As Boolean = False
    Dim nave As String
    Dim proveedor As String

    Private Sub CapturaOrdenesDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtObservaciones.AutoSize = False
        txtObservaciones.Size = New Size(680, 40)
        txtObservaciones.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCalle.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtColonia.CharacterCasing = Windows.Forms.CharacterCasing.Upper
        txtCodigoPostal.MaxLength = 5

        llenarComboPais()
        LlenarListasNaves()
        'llenarProveedores(cmbNave.SelectedValue)
        'llenarRazonSocial(cmbNave.SelectedValue)
        'obtenerDireccion(cmbNave.SelectedValue, 1)

        If txtIdOC.Text = "" Then
            dtpProgramaal.MinDate = DateTime.Now.ToString("dd/MM/yyyy")
            dtpProgramadel.MinDate = DateTime.Now.ToString("dd/MM/yyyy")
        End If

        txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")

        If cbxUsarDireccionNave.Checked = True Then
            txtCodigoPostal.Enabled = False
            txtCalle.Enabled = False
            cmbPais.Enabled = False
            cmbEstado.Enabled = False
            cmbCiudad.Enabled = False
        End If

        SEMANA = DatePart("ww", Today)

        dt.Columns.Add("Seleccion", Type.GetType("System.String"))
        dt.Columns.Add("#", Type.GetType("System.String"))
        dt.Columns.Add("Descripción", Type.GetType("System.String"))
        dt.Columns.Add("Clave Proveedor", Type.GetType("System.String"))
        dt.Columns.Add("UMP", Type.GetType("System.String"))
        dt.Columns.Add("UMC", Type.GetType("System.String"))
        dt.Columns.Add("Tiempo Entrega", Type.GetType("System.String"))
        dt.Columns.Add("Precio Unitario", Type.GetType("System.String"))
        dt.Columns.Add("SKU", Type.GetType("System.String"))
        dt.Columns.Add("Clasificación", Type.GetType("System.String"))
        dt.Columns.Add("Cantidad", Type.GetType("System.String"))
        dt.Columns.Add("Total", Type.GetType("System.String"))

        If txtIdOC.Text <> "" And txtModificar.Text = "" Then
            consulta()
        End If

        If txtModificar.Text <> "" And txtIdOC.Text <> "" Then
            modificar()
        End If
        nave = cmbNave.Text
        proveedor = cmbProveedor.Text
    End Sub

    Public Sub consulta()
        lblTitulo.Text = "Consulta de Ordenes de Compra"
        Dim objBU As New Proveedores.BU.OrdenesDeCompra
        Dim dtLista As New DataTable

        dtLista = objBU.consultaFormulario(txtIdOC.Text)
        Try

            Select Case dtLista.Rows(0)("Estatus").ToString()
                Case "C"
                    txtEstatus.Text = "CAPTURADA"
                Case "A"
                    txtEstatus.Text = "AUTORIZADA"
                Case "R"
                    txtEstatus.Text = "RECHAZADA"
                Case "X"
                    txtEstatus.Text = "CANCELADA"
                Case "P"
                    txtEstatus.Text = "POR SURTIR"
                Case "/"
                    txtEstatus.Text = "PARCIAL SURTIDA"
                Case "S"
                    txtEstatus.Text = "SURTIDA"
            End Select
            'txtEstatus.Text = dtLista.Rows(0)("Estatus").ToString()
            cmbNave.SelectedValue = CInt(dtLista.Rows(0)("Nave").ToString())
            cmbProveedor.SelectedValue = dtLista.Rows(0)("Proveedor").ToString()
            txtFecha.Text = dtLista.Rows(0)("Fecha").ToString
            cmbPlazo.SelectedValue = dtLista.Rows(0)("Plazo").ToString()
            Select Case dtLista.Rows(0)("Prioridad").ToString()
                Case "A"
                    cmbPrioridad.Text = "ALTA"
                Case "M"
                    cmbPrioridad.Text = "MEDIA"
                Case "B"
                    cmbPrioridad.Text = "BAJA"
            End Select
            'cmbPrioridad.SelectedValue = dtLista.Rows(0)("Prioridad").ToString()
            cmbRazonSocial.SelectedValue = dtLista.Rows(0)("RazonSocial").ToString()
            If dtLista.Rows(0)("Documento").ToString() = "F" Then
                rdoFactura.Checked = True
            Else
                rdoRemision.Checked = True
            End If

            dtpProgramadel.Value = dtLista.Rows(0)("Del").ToString
            dtpProgramaal.Value = dtLista.Rows(0)("Al").ToString
            Dim total, iva, subtotal As Double
            total = dtLista.Rows(0)("Total").ToString()
            iva = dtLista.Rows(0)("Iva").ToString()
            subtotal = dtLista.Rows(0)("Subtotal").ToString()
            txtTotal.Text = Format(total, "##,##0.00")
            txtSubTotal.Text = Format(subtotal, "##,##0.00")
            txtIVA.Text = Format(iva, "##,##0.00")
            dtpFechaEntregaEstimada.Value = dtLista.Rows(0)("Entrega").ToString
            dtpFechaPagoEstimada.Value = dtLista.Rows(0)("Pago").ToString
            txtCalle.Text = dtLista.Rows(0)("Calle").ToString()
            txtNumero.Text = dtLista.Rows(0)("No").ToString()
            txtColonia.Text = dtLista.Rows(0)("Colonia").ToString()
            txtCodigoPostal.Text = dtLista.Rows(0)("Cp").ToString()
            cmbPais.SelectedValue = dtLista.Rows(0)("Pais").ToString()
            cmbEstado.SelectedValue = dtLista.Rows(0)("Estado").ToString()
            cmbCiudad.SelectedValue = dtLista.Rows(0)("Ciudad").ToString()
            txtObservaciones.Text = dtLista.Rows(0)("Observaciones").ToString()
            lblFolioAsignado.Text = dtLista.Rows(0)("Folio").ToString()

            '''
            '''
            'LLENAR GRID CON ELEMENTOS DE SU PEDIDO
            ''' 
            '''

            Dim listaId As New DataTable("ID")
            listaId = objBU.ListaiDOrdenCompra(txtIdOC.Text)

            Dim tamano = listaId.Rows.Count

            For value As Integer = 0 To tamano - 1
                list.Add(listaId.Rows(value).Item("ID").ToString)
            Next

            LlenarTablaGridConculta(list, cmbProveedor.SelectedValue, cmbNave.SelectedValue, txtIdOC.Text)
            disenioGridConsulta()

            btnAgregar.Visible = False
            btnQuitar.Visible = False
            btnGuardarOrden.Visible = False
            lblAgregar.Visible = False
            lblAMaterial.Visible = False
            lblQMaterial.Visible = False
            lblQuitar.Visible = False
            lblGuardarOrden.Visible = False
            txtEstatus.Enabled = False
            cmbNave.Enabled = False
            cmbProveedor.Enabled = False
            cmbRazonSocial.Enabled = False
            cmbPlazo.Enabled = False
            cmbPrioridad.Enabled = False
            dtpProgramadel.Enabled = False
            dtpProgramaal.Enabled = False

            txtEstatus.Enabled = False
            cmbNave.Enabled = False
            cmbProveedor.Enabled = False
            txtFecha.Enabled = False
            cmbPlazo.Enabled = False
            cmbPrioridad.Enabled = False
            cmbRazonSocial.Enabled = False
            gbxDocumento.Enabled = False
            dtpProgramadel.Enabled = False
            dtpProgramaal.Enabled = False
            txtTotal.Enabled = False
            txtSubTotal.Enabled = False
            txtIVA.Enabled = False
            dtpFechaEntregaEstimada.Enabled = False
            dtpFechaPagoEstimada.Enabled = False
            txtCalle.Enabled = False
            txtNumero.Enabled = False
            txtColonia.Enabled = False
            txtCodigoPostal.Enabled = False
            cmbPais.Enabled = False
            cmbEstado.Enabled = False
            cmbCiudad.Enabled = False
            txtObservaciones.Enabled = False
        Catch ex As Exception
        End Try

    End Sub

    Public Sub modificar()

        lblTitulo.Text = "Modificar Orden de Compra"
        Dim objBU As New Proveedores.BU.OrdenesDeCompra
        Dim dtLista As New DataTable

        dtLista = objBU.consultaFormulario(txtIdOC.Text)
        Try

            Select Case dtLista.Rows(0)("Estatus").ToString()
                Case "C"
                    txtEstatus.Text = "CAPTURADA"
                Case "A"
                    txtEstatus.Text = "AUTORIZADA"
                Case "R"
                    txtEstatus.Text = "RECHAZADA"
                Case "X"
                    txtEstatus.Text = "CANCELADA"
                Case "P"
                    txtEstatus.Text = "POR SURTIR"
                Case "/"
                    txtEstatus.Text = "PARCIAL SURTIDA"
                Case "S"
                    txtEstatus.Text = "SURTIDA"
            End Select
            'txtEstatus.Text = dtLista.Rows(0)("Estatus").ToString()
            cmbNave.SelectedValue = CInt(dtLista.Rows(0)("Nave").ToString())
            cmbProveedor.SelectedValue = dtLista.Rows(0)("Proveedor").ToString()
            txtFecha.Text = dtLista.Rows(0)("Fecha").ToString
            cmbPlazo.SelectedValue = dtLista.Rows(0)("Plazo").ToString()
            Select Case dtLista.Rows(0)("Prioridad").ToString()
                Case "A"
                    cmbPrioridad.Text = "ALTA"
                Case "M"
                    cmbPrioridad.Text = "MEDIA"
                Case "B"
                    cmbPrioridad.Text = "BAJA"
            End Select
            'cmbPrioridad.SelectedValue = dtLista.Rows(0)("Prioridad").ToString()
            cmbRazonSocial.SelectedValue = dtLista.Rows(0)("RazonSocial").ToString()
            If dtLista.Rows(0)("Documento").ToString() = "F" Then
                rdoFactura.Checked = True
            Else
                rdoRemision.Checked = True
            End If

            dtpProgramadel.Value = dtLista.Rows(0)("Del").ToString
            dtpProgramaal.Value = dtLista.Rows(0)("Al").ToString
            Dim total, iva, subtotal As Double
            total = dtLista.Rows(0)("Total").ToString()
            iva = dtLista.Rows(0)("Iva").ToString()
            subtotal = dtLista.Rows(0)("Subtotal").ToString()
            txtTotal.Text = Format(total, "##,##0.00")
            txtSubTotal.Text = Format(subtotal, "##,##0.00")
            txtIVA.Text = Format(iva, "##,##0.00")
            dtpFechaEntregaEstimada.Value = dtLista.Rows(0)("Entrega").ToString
            dtpFechaPagoEstimada.Value = dtLista.Rows(0)("Pago").ToString
            txtCalle.Text = dtLista.Rows(0)("Calle").ToString()
            txtNumero.Text = dtLista.Rows(0)("No").ToString()
            txtColonia.Text = dtLista.Rows(0)("Colonia").ToString()
            txtCodigoPostal.Text = dtLista.Rows(0)("Cp").ToString()
            cmbPais.SelectedValue = dtLista.Rows(0)("Pais").ToString()
            cmbEstado.SelectedValue = dtLista.Rows(0)("Estado").ToString()
            cmbCiudad.SelectedValue = dtLista.Rows(0)("Ciudad").ToString()
            txtObservaciones.Text = dtLista.Rows(0)("Observaciones").ToString()
            lblFolioAsignado.Text = dtLista.Rows(0)("Folio").ToString()
            '''
            '''
            'LLENAR GRID CON ELEMENTOS DE SU PEDIDO
            ''' 
            '''
            Dim listaId As New DataTable("ID")
            listaId = objBU.ListaiDOrdenCompra(txtIdOC.Text)

            Dim tamano = listaId.Rows.Count

            For value As Integer = 0 To tamano - 1
                list.Add(listaId.Rows(value).Item("ID").ToString)
            Next

            LlenarTablaGridConculta(list, cmbProveedor.SelectedValue, cmbNave.SelectedValue, txtIdOC.Text)
            disenioGrid()
        Catch ex As Exception
        End Try

    End Sub

    ''' <summary>
    ''' llenar combos Pais, Estado, Ciudad, naves
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub llenarComboPais()
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable
        lsta = obj.ListaPaises()
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbPais.DataSource = lsta
            cmbPais.DisplayMember = "pais_nombre"
            cmbPais.ValueMember = "pais_paisid"
        End If
    End Sub

    Public Sub llenarProveedores(ByVal idnave As Integer)
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        obj.listaProveedoresNave(idnave)
        Dim lsta As DataTable
        lsta = obj.listaProveedoresNave(idnave)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbProveedor.DataSource = lsta
            cmbProveedor.DisplayMember = "NOMBRE"
            cmbProveedor.ValueMember = "ID"
        End If
    End Sub

    Public Sub llenarRazonSocial(ByVal idnave As Integer)
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        obj.ListaRazonSocial(idnave)
        Dim lsta As DataTable
        lsta = obj.ListaRazonSocial(idnave)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbRazonSocial.DataSource = lsta
            cmbRazonSocial.DisplayMember = "NOMBRE"
            cmbRazonSocial.ValueMember = "ID"
        End If
    End Sub

    Function  ListaPLazoProveedor(ByVal proveedorid As Integer) As DataTable
        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable

        lsta = obj.ListaPLazoProveedor(proveedorid)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbPlazo.DataSource = lsta
            cmbPlazo.DisplayMember = "PLAZO"
            cmbPlazo.ValueMember = "ID"
            If lsta.Rows.Count = 2 Then
                Dim n = lsta.Rows(1).Item(0)
                cmbPlazo.SelectedValue = n
            End If
        ElseIf cmbProveedor.SelectedValue <> 0 Then
            objAdvertencia.mensaje = "Esté proveedor no tiene plazo de pago asignado"
            objAdvertencia.ShowDialog()
            cmbPlazo.Text = ""
        End If
        Return lsta

    End Function

    Public Sub LlenarListasNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Sub llenarComboEstado()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaEstados(cmbPais.SelectedValue)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbEstado.DataSource = lsta
            cmbEstado.DisplayMember = "esta_nombre"
            cmbEstado.ValueMember = "esta_estadoid"
        End If
    End Sub

    Public Sub llenarComboCiudad()
        Dim obj As New ProveedorBU
        Dim lsta As DataTable
        lsta = obj.ListaCiudades(cmbEstado.SelectedValue)
        If Not lsta.Rows.Count = 0 Then
            lsta.Rows.InsertAt(lsta.NewRow, 0)
            cmbCiudad.DataSource = lsta
            cmbCiudad.DisplayMember = "city_nombre"
            cmbCiudad.ValueMember = "city_ciudadid"
        End If
    End Sub

    Public Sub obtenerDireccion(ByVal idnave As Integer, ByVal ciudadid As Integer)

        Dim obj As New Proveedores.BU.OrdenesDeCompra
        Dim lsta As DataTable
        Dim listaPais As DataTable
        lsta = obj.obtenerDireccion(idnave)
        listaPais = obj.obtenerPais(ciudadid)
        If idnave <> 0 Then
            txtCalle.Text = lsta.Rows(0).Item("CALLE").ToString
            txtColonia.Text = lsta.Rows(0).Item("COLONIA").ToString
            txtNumero.Text = lsta.Rows(0).Item("NUMERO").ToString
            txtCodigoPostal.Text = lsta.Rows(0).Item("CP").ToString

            cmbPais.SelectedValue = listaPais.Rows(0).Item("ID p").ToString
            cmbEstado.SelectedValue = listaPais.Rows(0).Item("ID e").ToString
            cmbCiudad.SelectedValue = listaPais.Rows(0).Item("ID c").ToString
        End If

    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        If cmbPais.SelectedIndex > 0 Then
            llenarComboEstado()
        End If
    End Sub

    Public Sub colorearItemCombo()
        If cmbPrioridad.Text = "ALTA" Then
            cmbPrioridad.BackColor = System.Drawing.Color.Red
            cmbPrioridad.ForeColor = System.Drawing.Color.Red
        ElseIf cmbPrioridad.Text = "MEDIA" Then
            cmbPrioridad.BackColor = System.Drawing.Color.Goldenrod
            cmbPrioridad.ForeColor = System.Drawing.Color.Goldenrod
        ElseIf cmbPrioridad.Text = "BAJA" Then
            cmbPrioridad.BackColor = System.Drawing.Color.Green
            cmbPrioridad.ForeColor = System.Drawing.Color.Green

        End If
    End Sub

    ''' <summary>
    ''' Fin llenado Combos Pais, Estado, Ciudad
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        If cmbEstado.SelectedIndex > 0 Then
            llenarComboCiudad()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbProveedor.Text = "" Then
            objAdvertencia.mensaje = "Debe seleccionar primero un proveedor."
            objAdvertencia.ShowDialog()
            lblProveedor.ForeColor = Drawing.Color.Red
        Else
            Dim oc As New ListadeMaterialesdelProveedorForm
            oc.proveevorid = cmbProveedor.SelectedValue
            oc.naveid = cmbNave.SelectedValue
            oc.txtProveedor.Text = cmbProveedor.Text
            'oc.Show()
            If oc.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim lista As New List(Of Integer)
                lista = oc.list
                For value As Integer = 0 To lista.Count - 1
                    list.Add(lista.Item(value))
                Next
                Dim obj As New Proveedores.BU.OrdenesDeCompra
                LlenarTabla(list, cmbProveedor.SelectedValue, cmbNave.SelectedValue)
                disenioGrid()
            End If

        End If
        calcularDias()
    End Sub

    Public Sub LlenarTabla(ByVal lista As List(Of Integer), ByVal idproveedor As Integer, ByVal idnave As Integer)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New Proveedores.BU.OrdenesDeCompra
        Dim dtListaProveedores As New DataTable
        grdListaMateriales.DataSource = Nothing
        dtListaProveedores = objBU.ListaMaterialSeleccionado(list, cmbProveedor.SelectedValue, cmbNave.SelectedValue)
        grdListaMateriales.DataSource = dtListaProveedores
        Me.Cursor = Windows.Forms.Cursors.Default

        Return
    End Sub

    Public Sub LlenarTablaGridConculta(ByVal lista As List(Of Integer), ByVal idproveedor As Integer, ByVal naveid As Integer, ByVal oc As Integer)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New Proveedores.BU.OrdenesDeCompra
        Dim dtListaProveedores As New DataTable
        grdListaMateriales.DataSource = Nothing
        dtListaProveedores = objBU.consultaFormularioGrid(list, cmbProveedor.SelectedValue, cmbNave.SelectedValue, txtIdOC.Text)
        grdListaMateriales.DataSource = dtListaProveedores
        Me.Cursor = Windows.Forms.Cursors.Default
        Return
    End Sub

    Public Sub LlenarTablacONSULTA(ByVal idproveedor As Integer, ByVal idOC As Integer)
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New Proveedores.BU.OrdenesDeCompra
        Dim dtListaProveedores As New DataTable
        grdListaMateriales.DataSource = Nothing
        dtListaProveedores = objBU.LlenarTablacONSULTA(idproveedor, idOC)
        grdListaMateriales.DataSource = dtListaProveedores
        Me.Cursor = Windows.Forms.Cursors.Default

        Return
    End Sub

    Public Sub disenioGrid()

        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        With grdListaMateriales.DisplayLayout.Bands(0)

            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clave Proveedor").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clasificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tiempo Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID").Hidden = True
            .Columns("Id p").Hidden = True
            .Columns("Precio Unitario").Format = "##,##0.00"
            .Columns("Cantidad").Format = "##,##0.00"
            .Columns("Cantidad").MaxLength = 8
            .Columns("Total").Format = "##,##0.00"
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Tiempo Entrega").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio Unitario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Seleccion").Width = 4
            .Columns("#").Width = 20
            .Columns("SKU").Width = 70
            .Columns("Descripción").Width = 150
            .Columns("UMP").Width = 50
            .Columns("UMC").Width = 50
            .Columns("Clasificación").Width = 100
            grdListaMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.Cursor = Windows.Forms.Cursors.Default
        End With

    End Sub

    Public Sub disenioGridConsulta()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        With grdListaMateriales.DisplayLayout.Bands(0)
            '.Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SKU").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descripción").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clasificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMP").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("UMC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tiempo Entrega").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("ID c").Hidden = True
            .Columns("ID").Hidden = True
            .Columns("id p").Hidden = True
            .Columns("Seleccion").Hidden = True
            .Columns("Precio Unitario").Format = "##,##0.00"
            .Columns("Cantidad").Format = "##,##0.00"
            .Columns("Total").Format = "##,##0.00"
            .Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Tiempo Entrega").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Precio Unitario").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            '.Columns("Seleccion").Width = 4
            .Columns("#").Width = 20
            .Columns("SKU").Width = 50
            .Columns("Descripción").Width = 150
            .Columns("UMP").Width = 50
            .Columns("UMC").Width = 50
            .Columns("Clasificación").Width = 70
            grdListaMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.Cursor = Windows.Forms.Cursors.Default
        End With

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cbxUsarDireccionNave_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUsarDireccionNave.CheckedChanged
        If cbxUsarDireccionNave.Checked = True Then
            txtCodigoPostal.Enabled = False
            txtCalle.Enabled = False
            cmbPais.Enabled = False
            cmbEstado.Enabled = False
            cmbCiudad.Enabled = False
            txtColonia.Enabled = False
            txtNumero.Enabled = False
            obtenerDireccion(cmbNave.SelectedValue, 1)
        ElseIf cbxUsarDireccionNave.Checked = False Then
            txtCodigoPostal.Enabled = True
            txtCalle.Enabled = True
            cmbPais.Enabled = True
            cmbEstado.Enabled = True
            cmbCiudad.Enabled = True
            txtColonia.Enabled = True
            txtNumero.Enabled = True
            txtCodigoPostal.Text = ""
            txtCalle.Text = ""
            cmbPais.Text = ""
            cmbEstado.Text = ""
            cmbCiudad.Text = ""
            txtColonia.Text = ""
            txtNumero.Text = ""
        End If

    End Sub

    Private Sub cmbPrioridad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrioridad.SelectedIndexChanged
        'colorearItemCombo()
    End Sub

    Private Sub rdoRemision_CheckedChanged(sender As Object, e As EventArgs) Handles rdoRemision.CheckedChanged
        If grdListaMateriales.Rows.Count <> 0 Then

            If rdoFactura.Checked = True Then
                IVA = Subtotal * 0.16
                Total = IVA + Subtotal

                txtSubTotal.Text = Format(Subtotal, "##,##0.00")
                txtIVA.Text = Format(IVA, "##,##0.00")
                txtTotal.Text = Format(Total, "##,##0.00")
            End If

            If rdoRemision.Checked = True Then

                Total = Subtotal

                txtSubTotal.Text = Format(Subtotal, "##,##0.00")
                txtIVA.Text = 0
                txtTotal.Text = Format(Total, "##,##0.00")
            End If

        End If

    End Sub

    Private Sub permitirSoloNumeros(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPostal.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub GuardarOrdenDeCompra()
        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra
        Dim objbuProveedor As New Proveedores.BU.OrdenesDeCompra
        folio = CInt(objbuProveedor.ObtenerFolioRecienInsertado(cmbProveedor.SelectedValue)) + 1
        Dim oc = CInt(objbuProveedor.ultimaOrdenCompra()) + 1
        Dim SEM As Integer

        EntidadOC.ordc_ordencompraid = oc
        EntidadOC.ordc_proveedorid = cmbProveedor.SelectedValue
        EntidadOC.ordc_plazoid = cmbPlazo.SelectedValue
        EntidadOC.ordc_plazodias = cmbPlazo.SelectedValue
        EntidadOC.ordc_naveid = cmbNave.SelectedValue
        EntidadOC.ordc_fechaleaboracion = txtFecha.Text
        If cmbPrioridad.Text = "ALTA" Then
            EntidadOC.ordc_prioridad = "A"
        ElseIf cmbPrioridad.Text = "MEDIA" Then
            EntidadOC.ordc_prioridad = "M"
        ElseIf cmbPrioridad.Text = "BAJA" Then
            EntidadOC.ordc_prioridad = "B"
        End If
        EntidadOC.ordc_razonsocial = cmbRazonSocial.SelectedValue
        If rdoRemision.Checked = True Then
            EntidadOC.ordc_documento = "R"
        Else
            EntidadOC.ordc_documento = "F"
        End If
        EntidadOC.ordc_programainicio = dtpProgramadel.Text
        EntidadOC.ordc_programafin = dtpProgramaal.Text
        EntidadOC.ordc_fechaentregaestimada = dtpFechaEntregaEstimada.Text
        EntidadOC.ordc_fechapagoestimado = dtpFechaPagoEstimada.Text
        If cmbPlazo.SelectedValue = 1 Then
            SEM = 1
        ElseIf cmbPlazo.SelectedValue = 2 Then
            SEM = 3
        ElseIf cmbPlazo.SelectedValue = 3 Then
            SEM = 6
        End If
        EntidadOC.ordc_semanapago = SEMANA + SEM
        EntidadOC.ordc_calleentrega = txtCalle.Text
        EntidadOC.ordc_coloniaentrega = txtColonia.Text
        EntidadOC.ordc_numeroentrega = txtNumero.Text
        EntidadOC.ordc_ciudadid = cmbEstado.SelectedValue
        EntidadOC.ordc_codigopostal = txtCodigoPostal.Text
        EntidadOC.ordc_observaciones = txtObservaciones.Text
        EntidadOC.ordc_estatus = "C"
        EntidadOC.ordc_autorizacompraid = 0
        EntidadOC.ordc_fechaautorizacion = "00-00-0000"
        EntidadOC.ordc_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadOC.ordc_usuariomodificoid = 0
        EntidadOC.ordc_fechamodificacion = "00-00-0000"
        EntidadOC.ordc_subtotal = txtSubTotal.Text
        EntidadOC.ordc_iva = txtIVA.Text
        EntidadOC.ordc_total = txtTotal.Text
        EntidadOC.ordc_anio = DateTime.Now.ToString("yyyy")
        EntidadOC.ordc_folio = folio
        EntidadOC.ordc_tipocaptura = "MANUAL"
        objBU.AltaOrdenDeCompra(EntidadOC)
    End Sub

    Public Sub GuardarMaterialDeCompra()
        Dim EntidadMaterial As New Entidades.MaterialOrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra
        Dim objbuProveedor As New Proveedores.BU.OrdenesDeCompra

        Dim oc = CInt(objbuProveedor.ultimaOrdenCompra())
        Dim tamanoTabla = grdListaMateriales.Rows.Count()


        For value As Integer = 0 To tamanoTabla - 1
            Dim mat = CInt(objbuProveedor.ultimoMaterial()) + 1
            EntidadMaterial.maoc_materialordendecompraid = mat
            '**********************************************
            EntidadMaterial.maoc_materialpreciosid = grdListaMateriales.Rows(value).Cells("Id p").Text
            'grdListaMateriales.Rows(value).Cells("ID").Text
            EntidadMaterial.maoc_cantidad = grdListaMateriales.Rows(value).Cells("Cantidad").Text
            EntidadMaterial.maoc_preciounitario = grdListaMateriales.Rows(value).Cells("Precio unitario").Text
            EntidadMaterial.maoc_umpid = grdListaMateriales.Rows(value).Cells("UMP").Text
            EntidadMaterial.maoc_umcid = grdListaMateriales.Rows(value).Cells("UMC").Text
            EntidadMaterial.maoc_ordencompraid = oc
            EntidadMaterial.maoc_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            EntidadMaterial.maoc_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            EntidadMaterial.maoc_usuariomodificoid = 0
            EntidadMaterial.maoc_fechamodificacion = "00-00-0000"
            EntidadMaterial.maoc_estatusmaterial = "CAPTURADO"
            EntidadMaterial.maoc_materialid = grdListaMateriales.Rows(value).Cells("ID").Text
            objBU.AltaMaterialOrdenDeCompra(EntidadMaterial)
        Next
    End Sub

    Public Sub modificarOrdenDeCompra()
        Dim EntidadOC As New Entidades.OrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra
        Dim objbuProveedor As New Proveedores.BU.OrdenesDeCompra

        EntidadOC.ordc_ordencompraid = txtIdOC.Text
        EntidadOC.ordc_folio = lblFolioAsignado.Text
        EntidadOC.ordc_prioridad = cmbPrioridad.Text
        EntidadOC.ordc_razonsocial = cmbRazonSocial.SelectedValue
        If rdoFactura.Checked = True Then
            EntidadOC.ordc_documento = "F"
        Else
            EntidadOC.ordc_documento = "R"
        End If
        EntidadOC.ordc_calleentrega = txtCalle.Text
        EntidadOC.ordc_numeroentrega = txtNumero.Text
        EntidadOC.ordc_coloniaentrega = txtColonia.Text
        EntidadOC.ordc_codigopostal = txtCodigoPostal.Text
        EntidadOC.ordc_ciudadid = cmbCiudad.SelectedValue
        EntidadOC.ordc_observaciones = txtObservaciones.Text
        EntidadOC.ordc_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadOC.ordc_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadOC.ordc_subtotal = txtSubTotal.Text
        EntidadOC.ordc_iva = txtIVA.Text
        EntidadOC.ordc_total = txtTotal.Text
        objBU.ModificarOrdenCompra(EntidadOC)
    End Sub

    Public Sub ModificarMaterialDeCompra()
        Dim EntidadMaterial As New Entidades.MaterialOrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra
        Dim objbuProveedor As New Proveedores.BU.OrdenesDeCompra

        Dim oc = CInt(objbuProveedor.ultimaOrdenCompra())
        Dim tamanoTabla = grdListaMateriales.Rows.Count()


        For value As Integer = 0 To tamanoTabla - 1

            EntidadMaterial.maoc_materialordendecompraid = txtIdOC.Text
            '**********************************************************
            EntidadMaterial.maoc_materialpreciosid = 1
            'grdListaMateriales.Rows(value).Cells("ID").Text
            EntidadMaterial.maoc_cantidad = grdListaMateriales.Rows(value).Cells("Cantidad").Text
            EntidadMaterial.maoc_preciounitario = grdListaMateriales.Rows(value).Cells("Precio unitario").Text
            EntidadMaterial.maoc_umpid = grdListaMateriales.Rows(value).Cells("UMP").Text
            EntidadMaterial.maoc_umcid = grdListaMateriales.Rows(value).Cells("UMC").Text
            EntidadMaterial.maoc_ordencompraid = oc
            EntidadMaterial.maoc_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            EntidadMaterial.maoc_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            EntidadMaterial.maoc_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            EntidadMaterial.maoc_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            EntidadMaterial.maoc_estatusmaterial = "CAPTURADO"
            EntidadMaterial.maoc_materialid = grdListaMateriales.Rows(value).Cells("ID").Text
            objBU.AltaMaterialOrdenDeCompra(EntidadMaterial)
        Next
    End Sub

    Public Sub EstatusEliminadoMaterial()
        Dim Material As New Entidades.MaterialOrdenDeCompra
        Dim objBU As New Proveedores.DA.OrdenesDeCompra
        Dim objbuProveedor As New Proveedores.BU.OrdenesDeCompra

        For value As Integer = 0 To grdListaMateriales.Rows.Count - 1
            Material.maoc_materialid = grdListaMateriales.Rows(value).Cells("ID").Text
            Material.maoc_ordencompraid = txtIdOC.Text
            objBU.EstatusEliminadoMaterial(Material)
        Next


    End Sub

    Private Sub btnGuardarOrden_Click(sender As Object, e As EventArgs) Handles btnGuardarOrden.Click
        Dim tamanoTabla = grdListaMateriales.Rows.Count()
        Dim numeroSelecciones As Integer
        Dim materialesSin As Integer = 0
        Dim validacion1, validacion2, validacion3 As Boolean

        If cmbProveedor.Text <> "" And cmbPlazo.Text <> "" And cmbPrioridad.Text <> "" And cmbRazonSocial.Text <> "" Then

            If grdListaMateriales.Rows.Count() = 0 Then
                objAdvertencia.mensaje = "No hay materiales  agregados a la órden de compra."
                objAdvertencia.ShowDialog()
                validacion3 = False
            Else
                validacion3 = True
            End If

            If tamanoTabla > 0 Then
                For value As Integer = 0 To tamanoTabla - 1
                    If grdListaMateriales.Rows(value).Cells("SKU").Text <> "" Then
                        numeroSelecciones = numeroSelecciones + 1
                    End If
                Next

                For value As Integer = 0 To numeroSelecciones - 1
                    If grdListaMateriales.Rows(value).Cells("Cantidad").Text = "" Or grdListaMateriales.Rows(value).Cells("Cantidad").Text = "0" Then
                        materialesSin = materialesSin + 1
                    End If
                Next
                If materialesSin > 0 Then
                    objAdvertencia.mensaje = "Hay " + materialesSin.ToString + " materiales sin cantidad a solicitar, por favor indique la cantidad para todos los materiales de la lista"
                    objAdvertencia.ShowDialog()
                    validacion2 = False
                Else
                    validacion2 = True
                End If

            End If
        Else
            If cmbProveedor.Text = "" Then
                lblProveedor.ForeColor = Drawing.Color.Red
                validacion1 = False
            Else
                validacion1 = True
                lblProveedor.ForeColor = Drawing.Color.Black
            End If
            If cmbPlazo.Text = "" Then
                lblPlazo.ForeColor = Drawing.Color.Red
                validacion1 = False
            Else
                validacion1 = True
                lblPlazo.ForeColor = Drawing.Color.Black
            End If
            If cmbPrioridad.Text = "" Then
                validacion1 = False
                lblPrioridad.ForeColor = Drawing.Color.Red
            Else
                validacion1 = True
                lblPrioridad.ForeColor = Drawing.Color.Black
            End If
            If cmbRazonSocial.Text = "" Then
                lblRazonSocial.ForeColor = Drawing.Color.Red
                validacion1 = False
            Else
                validacion1 = True
                lblRazonSocial.ForeColor = Drawing.Color.Black
            End If
            objAdvertencia.mensaje = "Hay campos obligatorios por capturar"
            objAdvertencia.ShowDialog()

        End If

        If cmbProveedor.Text = "" Then
            lblProveedor.ForeColor = Drawing.Color.Red
            validacion1 = False
        Else
            validacion1 = True
            lblProveedor.ForeColor = Drawing.Color.Black
        End If
        If cmbPlazo.Text = "" Then
            lblPlazo.ForeColor = Drawing.Color.Red
            validacion1 = False
        Else
            validacion1 = True
            lblPlazo.ForeColor = Drawing.Color.Black
        End If
        If cmbPrioridad.Text = "" Then
            validacion1 = False
            lblPrioridad.ForeColor = Drawing.Color.Red
        Else
            validacion1 = True
            lblPrioridad.ForeColor = Drawing.Color.Black
        End If
        If cmbRazonSocial.Text = "" Then
            lblRazonSocial.ForeColor = Drawing.Color.Red
            validacion1 = False
        Else
            validacion1 = True
            lblRazonSocial.ForeColor = Drawing.Color.Black
        End If

        If validacion2 = True And validacion3 = True Then

            '''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''
            'mODIFICAR la orden de compra
            '''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''
            If txtIdOC.Text <> "" And txtModificar.Text <> "" Then
                objConfirmacion.mensaje = "¿Esta seguro que desea guardar la orden de compra?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    calcular()
                    modificarOrdenDeCompra()
                    GuardarMaterialDeCompra()
                    btnAgregar.Visible = False
                    btnQuitar.Visible = False
                    btnGuardarOrden.Visible = False
                    lblAgregar.Visible = False
                    lblAMaterial.Visible = False
                    lblQMaterial.Visible = False
                    lblQuitar.Visible = False
                    lblGuardarOrden.Visible = False
                    txtEstatus.Enabled = False
                    cmbNave.Enabled = False
                    cmbProveedor.Enabled = False
                    cmbRazonSocial.Enabled = False
                    cmbPlazo.Enabled = False
                    cmbPrioridad.Enabled = False
                    dtpProgramadel.Enabled = False
                    dtpProgramaal.Enabled = False
                    gbxDocumento.Enabled = False
                    With grdListaMateriales.DisplayLayout.Bands(0)
                        .Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    End With
                    objExito.mensaje = " Cambios realizados con éxito."
                    objExito.ShowDialog()
                    'lblFolioAsignado.Text = folio
                    'txtEstatus.Text = "CAPTURADA"
                End If
            End If
            '''''''''''''''''''''''''''
            '''''''''''''''''''''''''''
            'Guardar la orden de compra
            '''''''''''''''''''''''''''
            '''''''''''''''''''''''''''
            If txtModificar.Text = "" And txtIdOC.Text = "" Then
                objConfirmacion.mensaje = "¿Esta seguro que desea guardar la orden de compra?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    GuardarOrdenDeCompra()
                    GuardarMaterialDeCompra()
                    '*******************************************
                    Dim objBUU As New Proveedores.DA.OrdenesDeCompra
                    Dim encabezado = New DataTable("Encabezado")
                    Dim tablamateriales = New DataTable("tablamateriales")
                    Dim autorizo = New DataTable("autorizo")
                    Dim idoc = New DataTable
                    lblFolioAsignado.Text = folio
                    idoc = objBUU.idocRegistrado(lblFolioAsignado.Text, cmbNave.SelectedValue)
                    encabezado = objBUU.reporteOrdenDeCompra(idoc.Rows(0).Item(0))
                    tablamateriales = objBUU.reporteOrdenDeCompraMateriales(idoc.Rows(0).Item(0))
                    autorizo = objBUU.autorizo(idoc.Rows(0).Item(0))
                    Dim reporte As New StiReport
                    Dim ruta As String
                    Dim OBJBU As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJBU.LeerReporteporClave("Reporte_Orden_de_Compra")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                   EntidadReporte.Pnombre
                    reporte.Load((archivo + ".mrt"))
                    reporte.Compile()

                    ruta = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                    reporte("log") = ruta.ToUpper.Trim.Replace(" ", "")
                    reporte("folio") = encabezado.Rows(0).Item("Folio").ToString
                    reporte("Id nave") = encabezado.Rows(0).Item("Id nave").ToString
                    Dim fech As Date = DateTime.Now.ToString("dd/MM/yyyy")
                    Dim hora = Now.ToString("HH:mm:ss")
                    reporte("fechadeldia") = fech + " " + hora
                    reporte("fenvio") = encabezado.Rows(0).Item("Fecha").ToString
                    reporte("contacto") = encabezado.Rows(0).Item("Nombre").ToString
                    reporte("fentrega") = encabezado.Rows(0).Item("Fecha entrega").ToString
                    reporte("periodo") = "DEL: " + encabezado.Rows(0).Item("Periodo del").ToString + " AL: " + encabezado.Rows(0).Item("Periodo al").ToString
                    If encabezado.Rows(0).Item("Urgencia").ToString = "M" Then
                        reporte("urgencia") = "MEDIO"
                    ElseIf encabezado.Rows(0).Item("Urgencia").ToString = "B" Then
                        reporte("urgencia") = "BAJO"
                    ElseIf encabezado.Rows(0).Item("Urgencia").ToString = "A" Then
                        reporte("urgencia") = "ALTO"
                    End If
                    reporte("calle") = encabezado.Rows(0).Item("Calle").ToString
                    reporte("colonia") = encabezado.Rows(0).Item("Colonia").ToString
                    reporte("no") = encabezado.Rows(0).Item("No").ToString
                    reporte("telefono") = encabezado.Rows(0).Item("Telefono").ToString
                    reporte("observaciones") = encabezado.Rows(0).Item("Observaciones").ToString
                    reporte("subtotal") = encabezado.Rows(0).Item("Subtotal").ToString
                    reporte("iva") = encabezado.Rows(0).Item("Iva").ToString
                    reporte("total") = encabezado.Rows(0).Item("Total").ToString
                    reporte("cadenacomercial") = encabezado.Rows(0).Item("Cadena comercial").ToString
                    reporte("proveedor") = encabezado.Rows(0).Item("Proveedor").ToString
                    reporte("usuario") = encabezado.Rows(0).Item("Nombre").ToString
                    reporte("numped") = tablamateriales.Rows.Count.ToString
                    reporte("elaboro") = encabezado.Rows(0).Item("Nombre").ToString
                    If encabezado.Rows(0).Item("Estatus").ToString = "X" Then
                        reporte("autorizo") = "ORDEN DE COMPRA CANCELADA"
                    ElseIf encabezado.Rows(0).Item("Estatus").ToString = "R" Then
                        reporte("autorizo") = "ORDEN DE COMPRA RECHAZADA"
                    ElseIf encabezado.Rows(0).Item("Estatus").ToString = "C" Then
                        reporte("autorizo") = "ORDEN DE COMPRA NO AUTORIZADA"
                    ElseIf autorizo.Rows.Count <> 0 Then
                        reporte("autorizo") = autorizo.Rows(0).Item("user_nombrereal").ToString
                    End If
                    reporte.RegData(tablamateriales)
                    reporte.Render()
                   
                    Dim PdfExport As StiPdfExportService = New StiPdfExportService()
                    ruta = crearPDF(PdfExport, 0, archivo, reporte)
                    'EnviarCorreoArchivo(ruta)
                    'EnviarCorreoArchivoProveedor(ruta)
                    btnAgregar.Visible = False
                    btnQuitar.Visible = False
                    btnGuardarOrden.Visible = False
                    lblAgregar.Visible = False
                    lblAMaterial.Visible = False
                    lblQMaterial.Visible = False
                    lblQuitar.Visible = False
                    lblGuardarOrden.Visible = False
                    txtEstatus.Enabled = False
                    cmbNave.Enabled = False
                    cmbProveedor.Enabled = False
                    cmbRazonSocial.Enabled = False
                    cmbPlazo.Enabled = False
                    cmbPrioridad.Enabled = False
                    dtpProgramadel.Enabled = False
                    dtpProgramaal.Enabled = False
                    gbxDocumento.Enabled = False
                    With grdListaMateriales.DisplayLayout.Bands(0)
                        .Columns("Cantidad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                    End With
                    objExito.mensaje = " Se guardó la órden de compra con el folio " + folio.ToString
                    objExito.ShowDialog()
                    lblFolioAsignado.Text = folio
                    txtEstatus.Text = "CAPTURADA"
                End If
            End If

        End If
    End Sub

    Private Function crearPDF(ByVal PdfExport As StiPdfExportService, ByVal num As Integer, ByVal archivo As String, ByVal reporte As StiReport) As String
        Try
            PdfExport.ExportPdf(reporte, (archivo + num.ToString + ".pdf"))
        Catch ex As Exception
            num += 1
            crearPDF(PdfExport, num, archivo, reporte)
        End Try
        Dim ruta As String
        ruta = archivo + num.ToString + ".pdf"
        Return ruta
    End Function

    Public Sub EnviarCorreoArchivoProveedor(ByVal archivo As String)
        Dim mensaje As String = "Mensaje enviado correctamente"
        Dim cliente As New SmtpClient
        Dim smtp As New Entidades.SMTP
        Dim obju As New Proveedores.DA.OrdenesDeCompra
        '*********************************** obtener email del proveedor
        Dim email = obju.telefonoProveedor(cmbProveedor.SelectedValue)
        Dim numeroEmail = email.Rows.Count
        '*******************************************
        Dim autenticacion As New System.Net.NetworkCredential("servicioselectronicos@grupoyuyin.com", "Yservicios2015@")
        cliente.Credentials = autenticacion
        cliente.Host = "pod51010.outlook.com"
        cliente.Port = 25
        cliente.EnableSsl = True
        Dim [from] As New MailAddress("servicioselectronicos@grupoyuyin.com", "servicioselectronicos@grupoyuyin.com", System.Text.Encoding.UTF8)
        'Asigna los destinatarios.
        Dim [to] As New MailAddress(email.Rows(0).Item(0)) 'Direccion de envio ********************************************************
        'Dim [to] As New MailAddress("cdesarrollo.ti@grupoyuyin.com.mx")
        Dim mailMsg As New MailMessage([from], [to])
        mailMsg.BodyEncoding = System.Text.Encoding.UTF8
        mailMsg.Body = "León Guanajuato a " + DateTime.Now.ToString("dd") + " de " + DateTime.Now.ToString("mm") + " del " + DateTime.Now.ToString("yyyy") + vbCr + vbCr + vbCr + vbCr + vbCr
        mailMsg.Body += "Proveedor " + cmbProveedor.Text + " le hacemos de su conocimiento que se ha levantado una orden de compra," + vbCr
        mailMsg.Body += "misma que le estamos adjuntando en este correo en formato PDF" + vbCr + vbCr + vbCr
        mailMsg.Body += "Favor de no responder a este correo, ya que es una generacion automatica de orden de compra" + vbCr + vbCr
        mailMsg.Body += "Archivo adjunto REPORTE_ORDEN_DE_COMPRA.pdf" + vbCr
        mailMsg.Subject = "ORDEN DE COMPRA REGISTRADA AUTOMÁTICAMENTE"
        mailMsg.SubjectEncoding = System.Text.Encoding.UTF8
        Dim data = New Attachment(archivo, MediaTypeNames.Application.Octet)
        Dim disposition As ContentDisposition = data.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(archivo)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(archivo)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(archivo)
        'Agregamos un archivo al correo
        mailMsg.Attachments.Add(data)
        'mailMsg.IsBodyHtml = True
        AddHandler cliente.SendCompleted, AddressOf SendCompletedCallback
        Dim userState As String = "test message1"
        cliente.SendAsync(mailMsg, userState)
        'If Not BackgroundWorker1.IsBusy Then
        '    BackgroundWorker1.RunWorkerAsync()
        'End If
    End Sub

    Public Sub EnviarCorreoArchivo(ByVal archivo As String)
        Dim mensaje As String = "Mensaje enviado correctamente"
        Dim cliente As New SmtpClient
        Dim smtp As New Entidades.SMTP
        Dim autenticacion As New System.Net.NetworkCredential("servicioselectronicos@grupoyuyin.com", "Yservicios2015@")
        cliente.Credentials = autenticacion
        cliente.Host = "pod51010.outlook.com"
        cliente.Port = 25
        cliente.EnableSsl = True
        Dim [from] As New MailAddress("servicioselectronicos@grupoyuyin.com", "servicioselectronicos@grupoyuyin.com", System.Text.Encoding.UTF8)
        'Asigna los destinatarios.
        Dim [to] As New MailAddress("jdesarrollo.ti@grupoyuyin.com.mx")
        'Dim [to] As New MailAddress("cdesarrollo.ti@grupoyuyin.com.mx")
        Dim mailMsg As New MailMessage([from], [to])
        mailMsg.BodyEncoding = System.Text.Encoding.UTF8
        mailMsg.Body = "León Guanajuato a " + DateTime.Now.ToString("dd") + " de " + DateTime.Now.ToString("mm") + " del " + DateTime.Now.ToString("yyyy") + vbCr + vbCr + vbCr + vbCr + vbCr
        mailMsg.Body += "Solicitando de su amable apoyo, ya que se acaba de generar una orden de compra con numero de folio " + lblFolioAsignado.Text + vbCr
        mailMsg.Body += "que requiere de su autorizacion." + vbCr + vbCr + vbCr
        mailMsg.Body += "Favor de ingresar a SAY, para Autorizar o Rechazar esta solicitud." + vbCr + vbCr
        mailMsg.Body += "Archivo adjunto REPORTE_ORDEN_DE_COMPRA.pdf" + vbCr
        mailMsg.Subject = "ORDEN DE COMPRA REGISTRADA AUTOMÁTICAMENTE"
        mailMsg.SubjectEncoding = System.Text.Encoding.UTF8
        Dim data = New Attachment(archivo, MediaTypeNames.Application.Octet)
        Dim disposition As ContentDisposition = data.ContentDisposition
        disposition.CreationDate = System.IO.File.GetCreationTime(archivo)
        disposition.ModificationDate = System.IO.File.GetLastWriteTime(archivo)
        disposition.ReadDate = System.IO.File.GetLastAccessTime(archivo)
        'Agregamos un archivo al correo
        mailMsg.Attachments.Add(data)
        'mailMsg.IsBodyHtml = True
        AddHandler cliente.SendCompleted, AddressOf SendCompletedCallback
        Dim userState As String = "test message1"
        cliente.SendAsync(mailMsg, userState)
        'If Not BackgroundWorker1.IsBusy Then
        '    BackgroundWorker1.RunWorkerAsync()
        'End If
    End Sub

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

    Private Sub cmbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProveedor.SelectedIndexChanged
        Try
            Dim valor As Integer
            valor = CInt(cmbProveedor.SelectedValue)
            'ListaPLazoProveedor(CInt(cmbProveedor.SelectedValue))
            If proveedor = "" Then
                proveedor = cmbProveedor.Text
            ElseIf cmbProveedor.Text <> "" Then
                objConfirmacion.mensaje = "Si cambia de proveedor se borrara la lista de materiales cargada ¿Está seguro de cambiar de proveedor?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    grdListaMateriales.DataSource = Nothing
                End If
            End If
            Dim CONTENIDO As DataTable
            CONTENIDO = ListaPLazoProveedor(valor)
            obtenerDireccion(cmbNave.SelectedValue, cmbProveedor.SelectedValue)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs)

        objConfirmacion.mensaje = "¿Está seguro de quitar los materiales seleccionados?"
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then

        End If

    End Sub

    Public Sub calcular()
        Subtotal = 0
        IVA = 0
        Total = 0

        Dim tamanoTabla = grdListaMateriales.Rows.Count()
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        If tamanoTabla > 0 Then

            For value As Integer = 0 To tamanoTabla - 1
                If grdListaMateriales.Rows(value).Cells("Total").Text <> "" Then
                    Subtotal = Subtotal + grdListaMateriales.Rows(value).Cells("Total").Text
                End If
            Next

            If rdoFactura.Checked = True Then
                IVA = Subtotal * 0.16
                Total = IVA + Subtotal

                txtSubTotal.Text = Format(Subtotal, "##,##0.00")
                txtIVA.Text = Format(IVA, "##,##0.00")
                txtTotal.Text = Format(Total, "##,##0.00")
            End If

            If rdoRemision.Checked = True Then

                Total = Subtotal

                txtSubTotal.Text = Format(Subtotal, "##,##0.00")
                txtIVA.Text = 0
                txtTotal.Text = Format(Total, "##,##0.00")
            End If

            Try
                dtpFechaEntregaEstimada.Value = DateTime.Now.AddDays(NUMERO)
            Catch ex As Exception

            End Try

            Dim lsta As DataTable
            Dim diapago As Integer
            Try
                lsta = objBU.ListaDiasPLazoProveedor(cmbPlazo.SelectedValue)
                diapago = CInt(lsta.Rows(0).Item(0).ToString)
                dtpFechaPagoEstimada.Value = DateTime.Now.AddDays(diapago)
            Catch ex As Exception
            End Try

        End If

    End Sub

    Public Sub calcularTotales()

        Dim tamanoTabla As Integer
        Dim objBU As New Proveedores.DA.OrdenesDeCompra

        tamanoTabla = grdListaMateriales.Rows.Count()

        If tamanoTabla > 0 Then
            For value As Integer = 0 To tamanoTabla - 1
                If grdListaMateriales.Rows(value).Cells("Cantidad").Text <> "" Then
                    Dim multiplicacion = CDbl(grdListaMateriales.Rows(value).Cells("Cantidad").Text) * CDbl(grdListaMateriales.Rows(value).Cells("Precio Unitario").Text)
                    grdListaMateriales.Rows(value).Cells("Total").Value = multiplicacion
                Else
                    grdListaMateriales.Rows(value).Cells("Total").Value = 0
                End If
            Next
        End If
        disenioGrid()
        calcular()
    End Sub

    Private Sub btnQuitar_Click_1(sender As Object, e As EventArgs) Handles btnQuitar.Click

        Try
            Dim tamanoTabla = grdListaMateriales.Rows.Count()
            If tamanoTabla > 0 Then
                'Dim a = grdListaMateriales.Rows(1).Cells(0).Text()
                For value As Integer = 0 To tamanoTabla - 1
                    If grdListaMateriales.Rows(value).Cells("Seleccion").Text = 1 Then
                        list.Remove(grdListaMateriales.Rows(value).Cells("ID").Text())
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
        LlenarTabla(list, cmbProveedor.SelectedValue, cmbNave.SelectedValue)
        'calcularTotales()
        calcular()
        calcularDias()
        disenioGrid()
    End Sub

    Private Sub cmbPlazo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlazo.SelectedIndexChanged
        Dim objBU As New Proveedores.DA.OrdenesDeCompra
        Dim lsta As DataTable
        Dim diapago As Integer
        Try
            lsta = objBU.ListaDiasPLazoProveedor(cmbPlazo.SelectedValue)
            diapago = CInt(lsta.Rows(0).Item(0).ToString)
            dtpFechaPagoEstimada.Value = DateTime.Now.AddDays(diapago)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdoFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rdoFactura.CheckedChanged
        calcular()
        If grdListaMateriales.Rows.Count <> 0 Then
            If rdoFactura.Checked = True Then
                IVA = Subtotal * 0.16
                Total = IVA + Subtotal

                txtSubTotal.Text = Subtotal
                txtIVA.Text = IVA
                txtTotal.Text = Total
            End If

            If rdoRemision.Checked = True Then

                Total = Subtotal

                txtSubTotal.Text = Subtotal
                txtIVA.Text = 0
                txtTotal.Text = Total
            End If
        End If

    End Sub

    Private Sub grdListaMateriales_KeyUp(sender As Object, e As KeyEventArgs)
        'calcularTotales()
    End Sub

    Private Sub grdListaMateriales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdListaMateriales.KeyPress
        If grdListaMateriales.Rows.Count > 0 Then
            If grdListaMateriales.ActiveCell.IsFilterRowCell Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
            If Char.IsDigit(e.KeyChar) Then
                e.Handled = False
            ElseIf Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
        'calcularTotales()
    End Sub

    Public Sub calcularDias()
        Dim tamano As Integer
        tamano = grdListaMateriales.Rows.Count()
        If tamano > 0 Then
            For value As Integer = 0 To tamano - 1
                If grdListaMateriales.Rows(value).Cells("Tiempo Entrega").Text > NUMERO Then
                    NUMERO = grdListaMateriales.Rows(value).Cells("Tiempo Entrega").Text
                End If
            Next
        End If
        calcular()
    End Sub

    Private Sub grdListaMateriales_KeyUp_1(sender As Object, e As KeyEventArgs) Handles grdListaMateriales.KeyUp
        Dim VALUE As String
        VALUE = e.KeyData
        If VALUE = "9" Then
            cmbPrioridad.Focus()
        Else
            calcularTotales()
            calcular()
        End If
    End Sub

    Private Sub grdListaMateriales_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdListaMateriales.AfterCellUpdate
        EstatusEliminadoMaterial()
    End Sub

    Private Sub cmbNave_TextChanged(sender As Object, e As EventArgs) Handles cmbNave.TextChanged
        Try

            If cmbNave.Text = "Entidades.Naves" Or cmbNave.Text = "" Then
            Else
                If nave = "" Then
                    nave = cmbNave.Text
                Else
                    objConfirmacion.mensaje = "Si cambia de nave se borrara lo que ya capturo ¿Está seguro de cambiar de nave?"
                    If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        cmbPlazo.SelectedValue = 0
                        cmbProveedor.SelectedValue = 0
                        cmbRazonSocial.SelectedValue = 0
                        grdListaMateriales.DataSource = Nothing
                        proveedor = ""
                    End If
                End If
                
            End If
        Catch ex As Exception
        End Try
        Try
            llenarProveedores(cmbNave.SelectedValue)
            llenarRazonSocial(cmbNave.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

   
End Class