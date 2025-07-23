Imports Proveedores.BU
Imports Entidades
Imports Tools
Imports Infragistics.Win.UltraWinGrid

Public Class AltaGiroProveedorForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    'Dim objConfirmacion As New Tools.confirmarFormGrande
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Private Sub AltaGiroProveedorForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarTablaGiro()
        diseniogrdGirps()
        txtGiro.CharacterCasing = Windows.Forms.CharacterCasing.Upper

    End Sub

    Public Sub LlenarTablaGiro()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosVentas As New DataTable
        grdGiro.DataSource = Nothing
        dtListaContactosVentas = objBU.ListaDeGiros()
        grdGiro.DataSource = dtListaContactosVentas
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdGirps()
        With grdGiro.DisplayLayout.Bands(0)


            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("GIRO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 10
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdGiro.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdGiro.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Public Sub GuardarGiro()
        Dim EntidadGiro As New Giro
        Dim objbu As New ProveedorBU
        EntidadGiro.girp_descripcion = txtGiro.Text
        EntidadGiro.girp_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadGiro.girp_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadGiro.girp_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadGiro.girp_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadGiro.girp_activo = "SI"
        objbu.AltaGiro(EntidadGiro)
    End Sub

    Public Sub BorrarGiro()
        Dim EntidadGiro As New Giro
        Dim objbu As New ProveedorBU
        Dim idgiro As Integer
        idgiro = txtId.Text
        objbu.BorrarGiro(idgiro)
    End Sub

    Private Sub btnAgregarRazonSocial_Click(sender As Object, e As EventArgs) Handles btnAgregarRazonSocial.Click
        If txtGiro.TextLength > 0 Then
            BuscarGiroRepetido()
        Else
            objAdvertencia.mensaje = "Favor de escribir un giro."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub grdGiro_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdGiro.ClickCell
        txtId.Text = grdGiro.ActiveRow.Cells(0).Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        objConfirmacion.mensaje = "¿Está seguro de eliminar el giro " + grdGiro.ActiveRow.Cells(1).Text + "?"
        If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            BorrarGiro()
            LlenarTablaGiro()
            diseniogrdGirps()
            txtGiro.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Function BuscarGiroRepetido() As Boolean
        Dim objBU As New ProveedorBU
        Dim lista As New DataTable
        Dim noActivo As New DataTable
        Dim similitudes As String = ""
        lista = objBU.BuscaGiroRepetido(txtGiro.Text)
        noActivo = objBU.BuscaGiroRepetidoNoActivo(txtGiro.Text)
        If lista.Rows.Count > 0 Then
            If noActivo.Rows.Count > 0 Then
                objConfirmacion.mensaje = "Ese giro ya fue registrado anteriormente." & vbCrLf & " ¿Desea ponerlo como Activo?"
                If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    objBU.ActivarGiro(txtGiro.Text)
                    objExito.mensaje = "Giro Activado"
                    objExito.ShowDialog()
                End If
                txtGiro.Text = ""
                txtId.Text = ""
            Else
                For value = 0 To lista.Rows.Count - 1
                    If value = 0 Then
                        similitudes = lista.Rows(value).Item(0)
                    Else
                        similitudes = similitudes + ", " + lista.Rows(value).Item(0)
                    End If

                Next
                objExito.mensaje = "Ya hay giros similares a lo que desea capturar" & vbCrLf & similitudes
                objExito.ShowDialog()
            End If
            'objExito.mensaje = "Ya existe el giro capturado"
            'objExito.ShowDialog()
           
        Else
            GuardarGiro()
            objExito.mensaje = "Giro registrado con éxito."
            objExito.ShowDialog()
            LlenarTablaGiro()
            diseniogrdGirps()
            txtGiro.Text = ""
            txtId.Text = ""
        End If
        Return True
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    'Public Sub llenarComboRFCNombre()
    '    Dim obj As New ProveedorBU
    '    Dim lsta As DataTable
    '    lsta = obj.ListaNombresRFC(txtProveedorid.Text)
    '    If Not lsta.Rows.Count = 0 Then
    '        lsta.Rows.InsertAt(lsta.NewRow, 0)
    '        cmbRfcCuenta.DataSource = lsta
    '        cmbRfcCuenta.DisplayMember = "prov_razonsocial"
    '        cmbRfcCuenta.ValueMember = "prov_razonsocial"
    '    End If
    'End Sub



End Class