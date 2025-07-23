Public Class AgregarEditarDescuentosForm

    Public IdCliente As Integer
    Public IdDescuento As Integer
    Public IdMotivo As Integer
    Public IdLugar As Integer
    Public Porcentaje As Boolean
    Public Encadenado As Boolean
    Public Activo As Boolean
    Public Cantidad As Double
    Public Dias As Integer
    Public SumatoriaDescuentos As Double
    Public ValorMinimoDescuento As Double
    Public valorMaximoDescuento As Double
    Dim CamposVacios As Boolean = True


    Private Sub AgregarEditarDescuentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PoblarComboMotivos()
        PoblarComboLugar()
        AgregarOEditar()
        chboxPorcentaje.Checked = True
        chboxPorcentaje.Visible = False


    End Sub

    Private Sub PoblarComboMotivos()
        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim dtmotivoDescuento As New DataTable

        dtmotivoDescuento = clientesBU.Datos_TablaMotivoDescuento()

        dtmotivoDescuento.Rows.InsertAt(dtmotivoDescuento.NewRow, 0)
        If dtmotivoDescuento.Rows.Count > 0 Then
            cboxMotivo.DataSource = dtmotivoDescuento
            cboxMotivo.DisplayMember = "mode_nombre"
            cboxMotivo.ValueMember = "mode_motivodescuentoid"
        End If

        If IdMotivo > 0 Then
            cboxMotivo.SelectedValue = IdMotivo
        End If

    End Sub

    Private Sub PoblarComboLugar()
        Dim clientesBU As New Negocios.ClientesDatosBU
        Dim dtlugarDescuento As New DataTable

        dtlugarDescuento = clientesBU.Datos_TablaLugarDescuento()

        dtlugarDescuento.Rows.InsertAt(dtlugarDescuento.NewRow, 0)
        If dtlugarDescuento.Rows.Count > 0 Then
            cboxLugar.DataSource = dtlugarDescuento
            cboxLugar.DisplayMember = "lude_nombre"
            cboxLugar.ValueMember = "lude_lugardescuentoid"
        End If

        If IdLugar > 0 Then
            cboxLugar.SelectedValue = IdLugar
        End If


    End Sub

    Private Sub AgregarOEditar()
        If IdDescuento <= 0 Then Return

        If Porcentaje = True Then
            chboxPorcentaje.Checked = True
        Else
            chboxPorcentaje.Checked = False
        End If

        If Encadenado = True Then
            chboxEncadenado.Checked = True
        Else
            chboxEncadenado.Checked = False
        End If

        If Activo = True Then
            rbtnClienteStatusActivo.Checked = True
        Else
            rbtnClienteStatusInactivo.Checked = True
        End If

        numDescuentoCantidad.Value = Cantidad

        numDias.Value = Dias

        rbtnClienteStatusInactivo.Enabled = True
        rbtnClienteStatusActivo.Enabled = True

    End Sub

    
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        ValidarCamposVacios()

        If CamposVacios = False Then
            If (SumatoriaDescuentos + CDbl(numDescuentoCantidad.Value)) < ValorMinimoDescuento Or (SumatoriaDescuentos + CDbl(numDescuentoCantidad.Value)) > valorMaximoDescuento Then
                Dim objAdvertencia As New Tools.AdvertenciaForm
                objAdvertencia.mensaje = "La sumatoria de los descuentos acumulados no se encuentra dentro del rango permitido en la lista de precios actual."
                objAdvertencia.Tamaño_Letra = 12
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            Else
                Try
                    GuardarDescuentos()

                    Dim objExito As New Tools.ExitoForm
                    objExito.StartPosition = FormStartPosition.CenterParent
                    objExito.mensaje = "La información se guardó con éxito."
                    objExito.ShowDialog()

                    Me.Close()


                Catch ex As Exception

                End Try
            End If
        End If
    End Sub


    Private Sub ValidarCamposVacios()
        Dim objAdvertencias As New Tools.AdvertenciaForm
        objAdvertencias.StartPosition = FormStartPosition.CenterScreen

        CamposVacios = True
        If cboxMotivo.SelectedIndex <= 0 Then
            lblMotivo.ForeColor = Color.Red
            CamposVacios = True
            objAdvertencias.mensaje = "Selecciona el motivo del descuento."
            objAdvertencias.ShowDialog()
        Else
            lblMotivo.ForeColor = Color.Black
            CamposVacios = False
        End If

        If cboxLugar.SelectedIndex <= 0 Then
            lblLugar.ForeColor = Color.Red
            CamposVacios = True
            objAdvertencias.mensaje = "Selecciona el lugar del descuento."
            objAdvertencias.ShowDialog()
        Else
            lblLugar.ForeColor = Color.Black
            If CamposVacios = True Then
                CamposVacios = True
            Else
                CamposVacios = False
            End If
        End If
    End Sub

    Private Sub GuardarDescuentos()
        Dim descuento As New Entidades.DescuentoCliente
        Dim motivoDescuento As New Entidades.MotivoDescuento
        Dim lugarDescuento As New Entidades.LugarDescuento
        Dim cliente As New Entidades.Cliente
        Dim objClientesDatosBU As New Negocios.ClientesDatosBU

        descuento.descuentosclienteid = IdDescuento
        motivoDescuento.motivodescuentoid = cboxMotivo.SelectedValue
        descuento.motivodescuento = motivoDescuento

        lugarDescuento.lugardescuentoid = cboxLugar.SelectedValue
        descuento.lugardescuento = lugarDescuento
        cliente.clienteid = IdCliente
        descuento.cliente = cliente

        descuento.descuentoenporcentaje = chboxPorcentaje.Checked
        descuento.cantidaddescuento = numDescuentoCantidad.Value
        descuento.diasplazo = numDias.Value
        descuento.aplicaencadenado = chboxEncadenado.Checked
        descuento.activo = rbtnClienteStatusActivo.Checked

        If descuento.descuentosclienteid = 0 Then
            objClientesDatosBU.AltaDescuentosCliente(descuento)
        Else
            objClientesDatosBU.EditarDescuentosCliente(descuento)
        End If
        
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chboxPorcentaje_CheckedChanged(sender As Object, e As EventArgs) Handles chboxPorcentaje.CheckedChanged
        If chboxPorcentaje.Checked = True Then
            numDescuentoCantidad.Maximum = 100
        Else
            numDescuentoCantidad.Maximum = 1000
        End If



    End Sub
End Class