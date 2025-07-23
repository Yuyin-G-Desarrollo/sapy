Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Produccion.Negocios
Imports Tools

Public Class ConsultaPreOrdenCompraExplosionForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public nave As Integer = 0
    Public programa As String = ""
    Public preorden As Integer = 0
    Public naveNombre As String = ""
    Public proveedor As Integer = 0

    Private Sub ConsultaOrdenCompraExplosionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consulta()
    End Sub

    Public Sub consulta()

        Dim obj As New PreordenCompraBU
        Dim PreOrdenDeCompraDetalle As New DataTable
        Dim PreOrdenDeCompra As New DataTable

        PreOrdenDeCompraDetalle = obj.ConsultaDetallePreOrdenCompra(nave, preorden)
        grdOrdenCompra.DataSource = PreOrdenDeCompraDetalle
        PreOrdenDeCompra = obj.ConsultaPreOrdenCompra(nave, programa, proveedor)

        If PreOrdenDeCompra.Rows.Count > 0 Then
            lblNumeroText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Pre Orden")
            lblNaveText.Text = "- " & naveNombre
            lblFechaText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Fecha Entrega")
            'lblParesText.Text = PreOrdenDeCompra.Rows(0).Item("")
            lblPrioridadText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Prioridad")
            lblProveedorText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Proveedor")

            Try
                lblObservacionesText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Observación")
            Catch ex As Exception
            End Try

            lblEstatusText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Estatus")
            lblPreordenidText.Text = "- " & PreOrdenDeCompra.Rows(0).Item("Idpo")
        Else
            lblMensaje.Visible = True
        End If

        Try
            diseñoGrid()
        Catch ex As Exception
        End Try


    End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor

        With grdOrdenCompra.DisplayLayout.Bands(0)
            .Columns("Material").Width = 70
            .Columns("Proveedor").Width = 50
            .Columns("Precio Unitario").Width = 20
            .Columns("Total solicitado").Width = 20
            .Columns("Fecha Solicito").Width = 20
            .Columns("Solicitado").Width = 20

            .Columns("Idmn").Hidden = True
            .Columns("Idp").Hidden = True

            .Columns("Precio Unitario").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total solicitado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Solicitado").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Activation.NoEdit
            .Columns("Total solicitado").CellActivation = Activation.NoEdit
            .Columns("Fecha Solicito").CellActivation = Activation.NoEdit
            .Columns("Solicitado").CellActivation = Activation.NoEdit

            .Columns("Precio Unitario").Format = "##,##0.00"
            .Columns("Total solicitado").Format = "##,##0.00"
            .Columns("Solicitado").Format = "##,##0.00"

        End With
        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        objConfirmacion.mensaje = "¿Está seguro de autorizar la pre orden de compra?"
        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.Yes Then

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        objConfirmacion.mensaje = "¿Está seguro de cancelar la pre orden de compra?"
        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.Yes Then

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class