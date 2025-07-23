Public Class AltaEdicion_TablasTarifasForm

    Public editar As Boolean = False
    Public idtarifa As Integer = 0
    Public guardado As Boolean = False
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If validarDatos() Then
            Dim objTablasTarifas As New Entidades.TablasTarifas
            Dim objBU As New Negocios.TablasTarifasBU
            Dim mensaje As String = String.Empty

            objTablasTarifas.PTarifaId = idtarifa
            objTablasTarifas.PTipo = cmbTipo.Text
            objTablasTarifas.PLimiteInferior = CDbl(txtLimiteInferior.Text)
            objTablasTarifas.PLimiteSuperior = CDbl(txtLimiteSuperior.Text)
            objTablasTarifas.PCuotaFija = CDbl(txtCuotaFija.Text)
            objTablasTarifas.PPorcentaje = CDbl(txtPorcentaje.Text)

            If objBU.existeRango(objTablasTarifas) Then
                Dim mensajeAdv As New Tools.AdvertenciaForm
                mensajeAdv.mensaje = "Ya existe un registro con el rango que intenta ingresar."
                mensajeAdv.Show()
            Else
                mensaje = objBU.guardarTarifas(objTablasTarifas)

                If mensaje = "EXITO" Then
                    guardado = True
                    Me.Close()
                Else
                    Dim msjError As New Tools.ErroresForm
                    msjError.mensaje = "Ocurrió un error al guardar la información."
                    msjError.Show()
                End If
            End If
        Else
            Dim mensajeAdv As New Tools.AdvertenciaForm
            mensajeAdv.mensaje = "Existen datos pendientes de capturar."
            mensajeAdv.Show()
        End If
    End Sub

    Private Function validarDatos() As Boolean
        Dim valida As Boolean = True
        If Trim(cmbTipo.Text).Length = 0 Or cmbTipo.Text = "" Then
            valida = False
            lblTipo.ForeColor = Drawing.Color.Red
        Else
            lblTipo.ForeColor = Drawing.Color.Black
        End If

        If Trim(txtLimiteInferior.Text).Length = 0 Or txtLimiteInferior.Text = "" Then
            valida = False
            lblLimInferior.ForeColor = Drawing.Color.Red
        Else
            lblLimInferior.ForeColor = Drawing.Color.Black
        End If

        If Trim(txtLimiteSuperior.Text).Length = 0 Or txtLimiteSuperior.Text = "" Then
            valida = False
            lblLimSuperior.ForeColor = Drawing.Color.Red
        Else
            lblLimSuperior.ForeColor = Drawing.Color.Black
        End If

        If Trim(txtCuotaFija.Text).Length = 0 Or txtCuotaFija.Text = "" Then
            valida = False
            lblCuotaFija.ForeColor = Drawing.Color.Red
        Else
            lblCuotaFija.ForeColor = Drawing.Color.Black
        End If

        If Trim(txtPorcentaje.Text).Length = 0 Or txtPorcentaje.Text = "" Then
            valida = False
            lblPorcentaje.ForeColor = Drawing.Color.Red
        Else
            lblPorcentaje.ForeColor = Drawing.Color.Black
        End If

        Return valida

    End Function

    Private Sub txtLimiteInferior_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtLimiteInferior.KeyPress, txtLimiteSuperior.KeyPress, txtCuotaFija.KeyPress
        Dim arreglo(2) As String

        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If sender.Text.IndexOf(".") > 0 Then
                arreglo = Split(sender.Text, ".")

                If arreglo(1).Length >= 2 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And sender.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub AltaEdicion_TablasTarifasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If idtarifa > 0 Then
            cargarDatosTarifaEditar()
        End If
    End Sub

    Private Sub cargarDatosTarifaEditar()
        Dim objBu As New Negocios.TablasTarifasBU
        Dim dtTarifa As New DataTable

        dtTarifa = objBu.consultaDatosTarifa(idtarifa)

        If Not IsNothing(dtTarifa) AndAlso dtTarifa.Rows.Count > 0 Then
            txtLimiteInferior.Text = dtTarifa.Rows(0).Item(1)
            txtLimiteSuperior.Text = dtTarifa.Rows(0).Item(2)
            txtCuotaFija.Text = dtTarifa.Rows(0).Item(3)
            txtPorcentaje.Text = dtTarifa.Rows(0).Item(4)
            cmbTipo.Text = dtTarifa.Rows(0).Item(5)
        Else
            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = "Ocurrió un error al obtener los datos de la tarifa a editar."
            mensajeError.Show()
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class