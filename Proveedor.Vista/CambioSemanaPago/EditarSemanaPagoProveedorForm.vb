Imports System.Drawing
Imports System.Windows.Forms
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Tools

Public Class EditarSemanaPagoProveedorForm

    Public vLstDocumentoSemanaPago As New List(Of Entidades.EditarSemanaPagoProveedor)
    Public registros As Integer
    Public vEditarDocto As EditarSemanaPagoProveedor
    Dim DocumentosSemanaPago As CambioSemanaPagoForm
    Dim inicio As Boolean = True


    Private Sub EditarSemanaPagoProveedorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vEditarDocto = vLstDocumentoSemanaPago.FirstOrDefault()
        registros = vLstDocumentoSemanaPago.Count

        If vEditarDocto.ToString = "" Then
            txtDocto.Text = vEditarDocto.PFactura
        Else
            txtDocto.Text = vEditarDocto.PDocto
        End If

        txtImporte.Text = vEditarDocto.PImporte.ToString("N2")
        txtSemActual.Text = vEditarDocto.PSemanaActual.ToString
        txtSemanaCompraActual.Text = vEditarDocto.PSemanaCompraActual.ToString
        llenarComboSemanaCompra()
        'cmbSemanaCompraNueva.SelectedValue = vEditarDocto.PSemanaCompraActual
        llenarComboAnioPago()
        cmbAño.SelectedValue = vEditarDocto.PAnioActual
        llenarComboSemanaPago()
        llenarComboAnioCompraNuevo()


        If registros = 1 Then
            grdEditarSemanaPago.Visible = False
            If vEditarDocto.PFactura = "" Then
                txtDocto.Text = vEditarDocto.PDocto
            Else
                txtDocto.Text = vEditarDocto.PFactura
            End If

        ElseIf registros > 1 Then
            grdEditarSemanaPago.Visible = True
            lblIDocto.Visible = False
            lblImporte.Visible = False

            grdEditarSemanaPago.DataSource = vLstDocumentoSemanaPago
            disenoGrid()
        End If

    End Sub

    Public Sub llenarComboAnioPago()
        Dim objBU As New CambioSemanaProveedorBU
        Dim dtComboAño As New DataTable
        dtComboAño = objBU.llenarComboAnioPago()
        dtComboAño.Rows.InsertAt(dtComboAño.NewRow, 0)
        cmbAño.DataSource = dtComboAño
        cmbAño.DisplayMember = "año"
        cmbAño.ValueMember = "añoPago"
    End Sub

    Public Sub llenarComboSemanaPago()
        Dim objBU As New CambioSemanaProveedorBU
        Dim dtComboSemana As New DataTable
        dtComboSemana = objBU.llenarComboSemanaPago(cmbAño.SelectedValue)
        dtComboSemana.Rows.InsertAt(dtComboSemana.NewRow, 0)
        cmbSemPagoNueva.DataSource = Nothing
        If dtComboSemana.Rows.Count > 0 Then
            cmbSemPagoNueva.DataSource = dtComboSemana
            cmbSemPagoNueva.DisplayMember = "num"
            cmbSemPagoNueva.ValueMember = "numsem"
            inicio = False
            cmbSemPagoNueva.SelectedIndex = 0
        End If
    End Sub

    Public Sub llenarComboSemanaCompra()
        Dim objBU As New CambioSemanaProveedorBU
        Dim dtComboSemanaActual As New DataTable
        Dim año As Integer = Date.Now.Year
        dtComboSemanaActual = objBU.llenarComboSemanaPago(año)
        dtComboSemanaActual.Rows.InsertAt(dtComboSemanaActual.NewRow, 0)
        cmbSemanaCompraNueva.DataSource = Nothing
        If dtComboSemanaActual.Rows.Count > 0 Then
            cmbSemanaCompraNueva.DataSource = dtComboSemanaActual
            cmbSemanaCompraNueva.DisplayMember = "num"
            cmbSemanaCompraNueva.ValueMember = "numsem"
            cmbSemanaCompraNueva.SelectedIndex = 0
        End If
    End Sub

    Public Sub llenarComboAnioCompraNuevo()
        Dim objBU As New CambioSemanaProveedorBU
        Dim dtComboAño As New DataTable
        dtComboAño = objBU.llenarComboAnioPago()
        dtComboAño.Rows.InsertAt(dtComboAño.NewRow, 0)
        cmbAñoCompraNuevo.DataSource = dtComboAño
        cmbAñoCompraNuevo.DisplayMember = "año"
        cmbAñoCompraNuevo.ValueMember = "añoPago"
    End Sub


    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim objBU As New CambioSemanaProveedorBU
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim confirmar As New ConfirmarForm

        Dim SemanaNueva As Integer = 0
        Dim AnioNuevo As Integer = 0
        Dim ModificadoSemana As Integer = 0
        Dim SemanaCompraNueva As Integer = 0
        Dim AñoCompraNuevo As Integer = 0

        If cmbSemPagoNueva.Text = "" Then
            SemanaNueva = txtSemActual.Text
        Else
            SemanaNueva = cmbSemPagoNueva.Text
        End If

        If cmbSemanaCompraNueva.Text = "" Then
            SemanaCompraNueva = 0
        Else
            SemanaCompraNueva = cmbSemanaCompraNueva.Text
        End If

        If cmbAñoCompraNuevo.Text = "" Then
            AñoCompraNuevo = 0
        Else
            AñoCompraNuevo = cmbAñoCompraNuevo.Text
        End If

        AnioNuevo = cmbAño.Text


        confirmar.mensaje = "¿Está seguro que desea actualizar los datos?"
        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Dim vXmlDocumentos As XElement = New XElement("Documentos")

            If vLstDocumentoSemanaPago.Count > 0 Then

                For Each item In vLstDocumentoSemanaPago
                    Dim vNodo As XElement = New XElement("Documento")
                    vNodo.Add(New XAttribute("PDocto", item.PDocto))
                    vNodo.Add(New XAttribute("PFactura", item.PFactura))
                    vNodo.Add(New XAttribute("PProveedorID", item.PProveedorID))
                    vNodo.Add(New XAttribute("PSemanaActual", item.PSemanaActual))
                    vNodo.Add(New XAttribute("PAnioActual", item.PAnioActual))
                    vNodo.Add(New XAttribute("PSemanaNueva", SemanaNueva))
                    vNodo.Add(New XAttribute("PAnioNuevo", AnioNuevo))
                    vNodo.Add(New XAttribute("PModificadoSemana", 1))
                    vNodo.Add(New XAttribute("PSemanaCompraNueva", SemanaCompraNueva))
                    vNodo.Add(New XAttribute("PAñoCompraNuevo", AñoCompraNuevo))
                    vXmlDocumentos.Add(vNodo)
                Next
            End If

            objBU.ActualizarSemanaPagoProveedor(vXmlDocumentos.ToString())
            exito.mensaje = "Se realizaron con éxito los cambios"
                exito.ShowDialog()
            Else
            advertencia.mensaje = "Se canceló el cambio en la semana de pago."
            advertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub disenoGrid()
        With grdEditarSemanaPago.DisplayLayout.Bands(0)
            .Columns("PDocto").Header.Caption = "Docto"
            .Columns("PDocto").CellActivation = Activation.NoEdit

            .Columns("PFactura").Header.Caption = "Factura"
            .Columns("PFactura").CellActivation = Activation.NoEdit

            .Columns("PSemanaActual").Header.Caption = "Semana Actual"
            .Columns("PSemanaActual").CellActivation = Activation.NoEdit

            .Columns("PImporte").Header.Caption = "Importe"
            .Columns("PImporte").CellActivation = Activation.NoEdit

            .Columns("PProveedorID").Header.Caption = "ProveedorID"
            .Columns("PProveedorID").CellActivation = Activation.NoEdit

            .Columns("PAnioActual").Header.Caption = "Año Actual"
            .Columns("PAnioActual").CellActivation = Activation.NoEdit

        End With

    End Sub

    Private Sub grdEditarSemanaPago_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdEditarSemanaPago.InitializeLayout
        grid_diseño(grdEditarSemanaPago)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub cmbAño_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAño.SelectedValueChanged
        If inicio = False Then
            If cmbAño.SelectedIndex > 0 Then
                llenarComboSemanaPago()
            Else

            End If
        End If
    End Sub


End Class