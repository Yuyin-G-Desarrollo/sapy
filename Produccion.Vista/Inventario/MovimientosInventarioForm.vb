Imports Tools
Imports Produccion.Negocios
Imports Entidades

Public Class MovimientosInventarioForm
    Public datos As New InventarioNave

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validar() Then
            Dim d As New DataTable
            Dim obj As New InventarioBU
            Dim adv As New AdvertenciaForm
            datos.cantidad = CDbl(txtCantidad.Text)
            datos.ordencompraid = 0
            datos.fechaprograma = Now.Date
            datos.movimientoinventarioid = cmbMovimiento.SelectedValue
            Dim row As DataRowView
            row = cmbMovimiento.SelectedItem
            If row(2).ToString = "SALIDA" Then
                datos.inventariofinal = (datos.inventarioinicial - datos.cantidad)
            Else
                datos.inventariofinal = (datos.inventarioinicial + datos.cantidad)
            End If

            datos.invn_observaciones = txtObservaciones.Text
            d = obj.insertarMovimientoInventario(datos)
            If d.Rows.Count > 0 Then
                If d.Rows(0).Item(0).ToString.ToUpper = "TRUE" Then
                    Dim exito As New ExitoForm
                    exito.mensaje = "Movimiento realizado."
                    exito.ShowDialog()
                    Me.Close()
                Else
                    adv.mensaje = "Surgió algo inesperado: " & d.Rows(0).Item(0).ToString
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Surgió algo inesperado intentelo más tarde."
                adv.ShowDialog()
            End If

        End If
    End Sub

    Function validar() As Boolean
        Dim adv As New AdvertenciaForm
        Try
            If cmbMovimiento.SelectedValue > 0 Then

            Else
                adv.mensaje = "Seleccione un movimiento."
                adv.ShowDialog()
                Return False
            End If
        Catch ex As Exception
            adv.mensaje = "Seleccione un movimiento."
            adv.ShowDialog()
            Return False
        End Try
       
        Try
            If CDbl(txtCantidad.Text) > 0 Then

            Else
                adv.mensaje = "Cantidad inválida."
                adv.ShowDialog()
                Return False
            End If
        Catch ex As Exception
            adv.mensaje = "Cantidad inválida."
            adv.ShowDialog()
            Return False
        End Try
       
        Return True
    End Function

    Private Sub MovimientosInventarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboMaterial()
        lblNave.Text = datos.nombreNave
        lblMaterial.Text = datos.nombreMaterial
        lblInventario.Text = Format(datos.inventarioinicial, "##,##0.00") & " " & datos.umcMaterial
        lblPrecio.Text = "$ " & Format(datos.precio, "##,##0.00")
        lblTotalInventario.Text = Format(datos.inventarioinicial, "##,##0.00") & " " & datos.umcMaterial
        txtTotal.Text = "$ " & Format(datos.totalDinero, "##,##0.00")
        txtTotalDinero.Text = "$ " & Format(datos.totalDinero, "##,##0.00")
    End Sub
    Public Sub llenarComboMaterial()
        Dim obj As New InventarioBU
        Dim lst As New DataTable
        Dim movsGerente As Boolean = False
        Dim movsUsuario As Boolean = False
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Inventario Materiales", "MOVIMIENTOSGERENTE") Then
            movsGerente = True
        Else
            movsGerente = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("Inventario Materiales", "MOVIMIENTOSUSUARIO") Then
            movsUsuario = True
        Else
            movsUsuario = False
        End If

        lst = obj.getMovimientos(movsGerente, movsUsuario)

        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbMovimiento.DataSource = lst
            cmbMovimiento.DisplayMember = "movi_movimiento"
            cmbMovimiento.ValueMember = "movi_movimientoinventarioid"
        Else
            lst.Rows.InsertAt(lst.NewRow, 0)
        End If
        Try
            cmbMovimiento.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If (Convert.ToInt32(e.KeyChar) = 8) Then
            ' Se ha pulsado la tecla retroceso 
            Return
        End If
       
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtCantidad.Text.IndexOf(".") Then
            e.Handled = True
            Return
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        Dim separadorDecimal As String = _
      Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator

        Dim index As Integer = txtCantidad.Text.IndexOf(separadorDecimal)

        If (index >= 0) Then
            Dim decimales As String = txtCantidad.Text.Substring(index + 1)
            e.Handled = (decimales.Length = 2)
        End If

        If (txtCantidad.SelectionLength > 0) Then e.Handled = False
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        setTotales()
    End Sub
    Public Sub setTotales()
        Try
            Dim cantidad As Double = 0
            cantidad = CDbl(txtCantidad.Text)
            Dim row As DataRowView
            row = cmbMovimiento.SelectedItem
            If row(2).ToString = "SALIDA" Then
                If cantidad <= datos.inventarioinicial Then
                    txtCantidad.Text = cantidad.ToString
                    cantidad = CDbl(txtCantidad.Text)
                    lblTotalInventario.Text = Format((datos.inventarioinicial - cantidad), "##,##0.00") & " " & datos.umcMaterial
                    txtTotalMovimiento.Text = "$ " & Format((datos.precio * cantidad), "##,##0.00")
                    txtTotal.Text = "$ " & Format((datos.totalDinero - (datos.precio * cantidad)), "##,##0.00")
                Else
                    txtCantidad.Text = datos.inventarioinicial
                    Dim adv As New AdvertenciaForm
                    adv.mensaje = "El límite de tu inventario: " & datos.inventarioinicial
                    adv.ShowDialog()
                End If
            Else
                cantidad = CDbl(txtCantidad.Text)
                lblTotalInventario.Text = Format((datos.inventarioinicial + cantidad), "##,##0.00") & " " & datos.umcMaterial
                txtTotalMovimiento.Text = "$ " & Format((datos.precio * cantidad), "##,##0.00")
                txtTotal.Text = "$ " & Format((datos.totalDinero + (datos.precio * cantidad)), "##,##0.00")
            End If

        Catch ex As Exception
            'txtCantidad.Text = "0.00"
        End Try
    End Sub
    Private Sub txtCantidad_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyUp
       setTotales()
    End Sub

    Private Sub cmbMovimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMovimiento.SelectedIndexChanged
        Try
            If cmbMovimiento.SelectedIndex > 0 Then
                txtCantidad.Enabled = True
                txtCantidad.Text = ""
            Else
                txtCantidad.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class

