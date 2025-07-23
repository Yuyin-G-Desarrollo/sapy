Imports Proveedores.BU
Imports Tools
Imports Infragistics.Win.UltraWinGrid

Public Class CatalogoCoincidenciasNombresRFC

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objConfirmacionGde As New Tools.confirmarFormGrande
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim idProveedor As Integer

    Public objBu As New ProveedorBU
    Public busqueda As String
    Dim editar As Boolean
    Public naveid As Integer
    Public naveNombre As String
    Public respuesta As Boolean
    Public ID As Integer
    Public idsicy As Integer = 0

    Private FORMU_ As AltaProveedoresForm
    Private FORMU2_ As CatalogoProveedoresForm

    Public Variable As Integer = 0

    Public Sub LlenarTablaCoincidencias()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtLista As New DataTable
        grdCoincidencias.DataSource = Nothing
        ' dtLista = objBU.BuscaCoincidenciaNombreRazonSocial(busqueda)
        dtLista = objBU.BuscaCoincidenciaRazonSocial(busqueda)
        grdCoincidencias.DataSource = dtLista
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdCoincidencias()

        editar = False
        With grdCoincidencias.DisplayLayout.Bands(0)
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            .Columns("NOMBRE COMERCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RAZON SOCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RFC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("RFC").Width = 50
            grdCoincidencias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.Cursor = Windows.Forms.Cursors.Default
        End With
    End Sub

    Private Sub grdCoincidencias_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles grdCoincidencias.DoubleClickRow
        If Variable = 0 Then
            Dim dtLista As New DataTable
            Dim ID As Integer

            If grdCoincidencias.ActiveRow.Cells("SICY ID").Text <> "" Then

                ID = CInt(grdCoincidencias.ActiveRow.Cells("SICY ID").Text)
                objConfirmacion.mensaje = "¿Está seguro de que es el RFC que quiere registrar?"
                If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Try
                        idsicy = ID
                        FORMU_.IDSICY = ID
                        FORMU_.txtSicy.Text = "" & ID
                        'idsicy()

                    Catch ex As Exception
                    End Try
                    Me.Hide()
                Else
                    Me.Hide()
                End If

            Else
                objAdvertencia.mensaje = "Favor de seleccionar un RFC de la lista"
                objAdvertencia.ShowDialog()
            End If
        End If
    End Sub

    Public Sub AsignarNave(ByVal f As AltaProveedoresForm)
        FORMU_ = f
    End Sub


    Private Sub grdCoincidencias_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCoincidencias.ClickCell

        If grdCoincidencias.ActiveRow.Cells("SICY ID").Text <> "" Then
            ID = grdCoincidencias.ActiveRow.Cells("SICY ID").Text
            Dim formul As New AltaProveedoresForm
            formul.txtSicy.Text = grdCoincidencias.ActiveRow.Cells("SICY ID").Text
        End If

    End Sub

    Private Sub CatalogoCoincidenciasNombresRFC_Load(sender As Object, e As EventArgs) Handles Me.Load
        LlenarTablaCoincidencias()
        diseniogrdCoincidencias()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class