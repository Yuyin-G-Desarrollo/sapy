Imports Tools
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Public Class SeleccionarCFDIForm
#Region "Globales"
    Public idCliente As Integer
    Public idCfdi As Integer
#End Region

#Region "Eventos"
    Private Sub SeleccionarCFDIForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbConAjuste.SelectedIndex = 0
        cargarListado()
    End Sub

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        cargarListado()
    End Sub

    Private Sub txtFolio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFolio.KeyDown
        cargarListado()
    End Sub

    Private Sub cmbConAjuste_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConAjuste.SelectedIndexChanged
        cargarListado()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click, lblAceptar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim filaSeleccionada As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)

        If Not filaSeleccionada Is Nothing Then
            idCfdi = filaSeleccionada.Item("ComplementoId")
            Me.Close()
        Else
            show_message("Advertencia", "Favor de seleccionar un CFDI.")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click, lblCerrar.Click
        'idCfdi = 0
        Me.Close()
    End Sub
#End Region

#Region "Métodos"
    Private Sub cargarListado()
        Me.Cursor = Cursors.WaitCursor
        grdListado.DataSource = Nothing
        Try
            Dim objBU As New Negocios.AdministrarComplementoPagoCompensacionBU
            Dim dtListado As New DataTable

            Dim serie As String = txtSerie.Text
            Dim folio As Integer = 0
            Dim conAjuste As String = cmbConAjuste.Text
            If txtFolio.Text.Trim <> String.Empty Then
                folio = CInt(txtFolio.Text.Trim)
            End If

            dtListado = objBU.obtenerCfdiCliente(idCliente, serie, folio, conAjuste)
            If Not dtListado Is Nothing Then
                If dtListado.Rows.Count > 0 Then
                    grdListado.DataSource = dtListado
                    disenioGrid()
                Else
                    show_message("Advertencia", "La consulta no devolvió ningún resultado")
                End If
            Else
                show_message("Advertencia", "La consulta no devolvió ningún resultado")
            End If
        Catch ex As Exception
            show_message("Error", "Error al cargar listado de CFDI.")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub disenioGrid()
        With GridView1
            .Columns("ComplementoId").Visible = False

            '.Columns("Folio").Width = 45

            .Columns("Folio").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far
            .Columns("Total").AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far

            .Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns.ColumnByFieldName("Fecha").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            .Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"
            .Columns.ColumnByFieldName("Fecha").DisplayFormat.FormatString = "dd/MM/yyyy"

            .OptionsView.EnableAppearanceEvenRow = True
            .OptionsView.EnableAppearanceOddRow = True
        End With
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)
        Dim objMensaje As Object

        Select Case tipo
            Case "Advertencia"
                objMensaje = New AdvertenciaForm
            Case "Aviso"
                objMensaje = New AvisoForm
            Case "Error"
                objMensaje = New ErroresForm
            Case "Exito"
                objMensaje = New ExitoForm
            Case "Confirmar"
                objMensaje = New ConfirmarForm
            Case "AdvertenciaGrande"
                objMensaje = New AdvertenciaFormGrande
            Case Else
                objMensaje = New AvisoForm
        End Select

        objMensaje.mensaje = mensaje
        objMensaje.ShowDialog()
    End Sub
#End Region
End Class