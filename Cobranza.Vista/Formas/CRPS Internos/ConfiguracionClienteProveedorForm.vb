
Imports System.Windows.Forms
Imports Cobranza.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools

Public Class ConfiguracionClienteProveedorForm
    Dim terminaCarga As Boolean = False
    Private Sub ConfiguracionClienteProveedorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btndesactivar.Visible = False
        lbldesactivar.Visible = False
        btnActivar.Visible = False
        lblactivar.Visible = False
        llenaComboboxProveedores()
        terminaCarga = True
        BtnMostrar.Enabled = False
        LblMostrar.Enabled = False
    End Sub
    Private Sub llenaComboboxProveedores()
        Dim objConfigInterno As New ConfiguracionClienteProveedorInternoBU
        Dim lstObtenerInternos As New DataTable
        lstObtenerInternos = objConfigInterno.ObtenerProveedoresInternos
        lstObtenerInternos.Rows.InsertAt(lstObtenerInternos.NewRow, 0)
        cmbProveedores.DataSource = lstObtenerInternos
        cmbProveedores.ValueMember = "idcuenta"
        cmbProveedores.DisplayMember = "Proveedor"
        txtRFC.Enabled = False
        txtcuentabanco.Enabled = False
        txtIdproveedor.Enabled = False
    End Sub
    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles BtnMostrar.Click
        MostrarClientesInternos()
    End Sub
    Private Sub MostrarClientesInternos()
        Dim objConfiguracion As New Entidades.ConfiguracionClienteProveedorInterno
        Dim objMostrarCtes As New ConfiguracionClienteProveedorInternoBU
        Dim lstMostarCtes As New DataTable
        objConfiguracion.IdProveedorInterno = txtIdproveedor.Text
        If rdbSi.Checked = True Then
            objConfiguracion.ActivoInterno = 1
        Else
            objConfiguracion.ActivoInterno = 0
        End If
        lstMostarCtes = objMostrarCtes.mostrarClientesInternosProveedor(objConfiguracion)
        vwConfiguracionClienteProveedorInterno.Columns.Clear()
        If lstMostarCtes.Rows.Count = 0 Then
            grdConfiguracionClienteProveedorInterno.DataSource = Nothing
            vwConfiguracionClienteProveedorInterno.Columns.Clear()
            Dim ventanaConfirmacion As New Tools.AdvertenciaForm
            ventanaConfirmacion.mensaje = "No se encontraron registros"
            ventanaConfirmacion.ShowDialog()
            btndesactivar.Visible = False
            lbldesactivar.Visible = False
            lblTotalRegistros.Text = 0
        Else
            grdConfiguracionClienteProveedorInterno.DataSource = lstMostarCtes
            txtRFC.Text = lstMostarCtes.Rows(0)(4).ToString
            txtcuentabanco.Text = lstMostarCtes.Rows(0)(5).ToString
            diseñoGridView(lstMostarCtes)
            mostrarBotones()
        End If
    End Sub
    Private Sub diseñoGridView(ByVal lstMostarCtes As DataTable)
        DiseñoGrid.DiseñoBaseGrid(vwConfiguracionClienteProveedorInterno)
        vwConfiguracionClienteProveedorInterno.IndicatorWidth = 35
        vwConfiguracionClienteProveedorInterno.OptionsView.ColumnAutoWidth = False
        DiseñoGrid.EstiloColumna(vwConfiguracionClienteProveedorInterno, "configId", "IdConfig", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 40, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwConfiguracionClienteProveedorInterno, "Id", "Id", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 40, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwConfiguracionClienteProveedorInterno, "cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 345, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwConfiguracionClienteProveedorInterno, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwConfiguracionClienteProveedorInterno, "RFC proveedor", "rfc", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwConfiguracionClienteProveedorInterno, "cuentabanco", "cuenta", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "")
        lblTotalRegistros.Text = lstMostarCtes.Rows.Count
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
    Private Sub vwConfiguracionClienteProveedorInterno_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwConfiguracionClienteProveedorInterno.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub mostrarBotones()
        If rdbSi.Checked = True Then
            btndesactivar.Visible = True
            lbldesactivar.Visible = True
            btnActivar.Visible = False
            lblactivar.Visible = False
        Else
            btnActivar.Visible = True
            lblactivar.Visible = True
            btndesactivar.Visible = False
            lbldesactivar.Visible = False
        End If
    End Sub
    Private Sub btndesactivar_Click(sender As Object, e As EventArgs) Handles btndesactivar.Click
        desactivarClienteInterno()
    End Sub
    Private Sub desactivarClienteInterno()
        Dim idPrincipal As New Entidades.ConfiguracionClienteProveedorInterno
        Dim i As Integer
        For i = 1 To vwConfiguracionClienteProveedorInterno.RowCount
            idPrincipal.IdConfiguracionInterno = vwConfiguracionClienteProveedorInterno.GetRowCellValue(vwConfiguracionClienteProveedorInterno.GetVisibleRowHandle(i), "IdConfig")
        Next i

    End Sub
    Private Sub cmbProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProveedores.SelectedIndexChanged
        If terminaCarga Then
            ConsultaCuentaBancoRFCInterno()
        End If
    End Sub
    Private Sub ConsultaCuentaBancoRFCInterno()
        Dim idCuenta As New Entidades.ConfiguracionClienteProveedorInterno
        Dim objConsultaBanco As New ConfiguracionClienteProveedorInternoBU
        Dim lstCuentaBanco As New DataTable
        idCuenta.IdCuentaBancaria = cmbProveedores.SelectedValue
        lstCuentaBanco = objConsultaBanco.ConsultaCuentarRFCProveedorInterno(idCuenta)
        If lstCuentaBanco.Rows.Count > 0 Then
            txtRFC.Text = lstCuentaBanco.Rows(0)(2).ToString
            txtcuentabanco.Text = lstCuentaBanco.Rows(0)(1).ToString
            txtIdproveedor.Text = lstCuentaBanco.Rows(0)(3).ToString
            BtnMostrar.Enabled = True
            LblMostrar.Enabled = True
        End If
    End Sub
    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim altaProveedorClienteInterno As New AltaProveedorClienteInternoForm
        altaProveedorClienteInterno.ShowDialog()
    End Sub
End Class