Public Class AltaEdicion_TablasSPEForm
    Public editar As Boolean = False
    Public idsubsidio As Integer = 0
    Public guardado As Boolean = False

    Private Sub AltaEdicion_TablasSPEForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If idsubsidio > 0 Then
            cargarDatosEditar()
        End If
    End Sub

    Private Sub cargarDatosEditar()
        Dim objBu As New Negocios.TablasSPEBU
        Dim dtSubsidio As New DataTable

        dtSubsidio = objBu.consultaDatosSubsidio(idsubsidio)

        If Not IsNothing(dtSubsidio) AndAlso dtSubsidio.Rows.Count > 0 Then
            txtLimiteInferior.Text = dtSubsidio.Rows(0).Item(1)
            txtLimiteSuperior.Text = dtSubsidio.Rows(0).Item(2)
            txtSubsidio.Text = dtSubsidio.Rows(0).Item(3)
            cmbTipo.Text = dtSubsidio.Rows(0).Item(4)
        Else
            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = "Ocurrió un error al obtener los datos."
            mensajeError.Show()
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

        If Trim(txtSubsidio.Text).Length = 0 Or txtSubsidio.Text = "" Then
            valida = False
            lblSubsidio.ForeColor = Drawing.Color.Red
        Else
            lblSubsidio.ForeColor = Drawing.Color.Black
        End If

        Return valida

    End Function

    Private Sub txtLimiteInferior_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtLimiteInferior.KeyPress, txtLimiteSuperior.KeyPress, txtSubsidio.KeyPress
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

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If validarDatos() Then
            Dim objSPE As New Entidades.TablasSPE
            Dim objBU As New Negocios.TablasSPEBU
            Dim mensaje As String = String.Empty

            objSPE.PTablaId = idsubsidio
            objSPE.PTipo = cmbTipo.Text
            objSPE.PLimiteInferior = CDbl(txtLimiteInferior.Text)
            objSPE.PLimiteSuperior = CDbl(txtLimiteSuperior.Text)
            objSPE.PSPEMensual = CDbl(txtSubsidio.Text)

            If objBU.existeRango(objSPE) Then
                Dim mensajeAdv As New Tools.AdvertenciaForm
                mensajeAdv.mensaje = "Ya existe un registro con el rango que intenta ingresar."
                mensajeAdv.Show()
            Else
                mensaje = objBU.guardarTablaSPE(objSPE)

                If mensaje = "EXITO" Then
                    guardado = True
                    Me.Close()
                Else
                    Dim msjError As New Tools.ErroresForm
                    msjError.mensaje = "Ocurrió un error al guardar la información:" & Environment.NewLine & mensaje
                    msjError.Show()
                End If
            End If
        Else
            Dim mensajeAdv As New Tools.AdvertenciaForm
            mensajeAdv.mensaje = "Existen datos pendientes de capturar."
            mensajeAdv.Show()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class