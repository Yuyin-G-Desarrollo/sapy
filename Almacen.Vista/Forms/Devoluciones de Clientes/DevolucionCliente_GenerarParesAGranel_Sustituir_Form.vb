Imports Tools

'Devuelve como resultado la EntidadProductoEstiloId
Public Class DevolucionCliente_GenerarParesAGranel_Sustituir_Form

    Dim OBJBU As New Negocios.DevolucionCliente_IntegracionInventarioBU
    Public FolioDevolucionId As Integer
    Public FolioDetalleId As String = String.Empty
    Public TallaId As Integer = 0
    Public ProductoEstiloId_Nuevo As Integer = 0
    Public ProductoEstiloId_Anterior As Integer = 0
    Public EntProductoEstilo As New Entidades.ProductoEstilo

    Private Sub DevolucionCliente_GenerarParesAGranel_Sustituir_Form_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub CargarArticulos(ByVal Modelo As String, ByVal Coleccion As String)
        Cursor = Cursors.WaitCursor
        Dim DtModelos As New DataTable
        DtModelos = OBJBU.ConsultarArticulosPorColeccion(Modelo, Coleccion, TallaId)
        cmbArticulos.DataSource = DtModelos
        cmbArticulos.DisplayMember = "DescripcionCompleta"
        cmbArticulos.ValueMember = "ProductoEstiloId"

        If DtModelos.Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay información del modelo de la misma corrida.")

            cmbArticulos.DataSource = Nothing
            cmbArticulos.Text = ""

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Cursor = Cursors.WaitCursor
        If cmbArticulos.SelectedIndex >= 0 Then
            EntProductoEstilo = OBJBU.SustituirArticulo(FolioDetalleId, cmbArticulos.SelectedValue)
            Me.DialogResult = DialogResult.OK
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha realizado la sustitución correctamente.")
            Me.Close()
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado un articulo.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarArticulos()
    End Sub

    Public Sub MostrarArticulos()
        If txtColeccion.Text.Trim = "" And txtModelo.Text.Trim = "" Then
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se han capturado un modelo o una colección.")
        Else
            CargarArticulos(txtModelo.Text.Trim, txtColeccion.Text.Trim())
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtModelo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtModelo.KeyPress
        Dim CadenaCapturada As String = String.Empty
        If e.KeyChar = ChrW(Keys.Enter) Then
            MostrarArticulos()
        End If
    End Sub

    Private Sub txtColeccion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColeccion.KeyPress
        Dim CadenaCapturada As String = String.Empty
        If e.KeyChar = ChrW(Keys.Enter) Then
            MostrarArticulos()
        End If
    End Sub
End Class