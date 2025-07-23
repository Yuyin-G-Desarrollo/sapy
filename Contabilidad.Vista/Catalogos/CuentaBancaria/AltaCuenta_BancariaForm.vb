Imports Tools
Imports System.Windows.Forms

Public Class AltaCuenta_BancariaForm

    Public Editar_Alta As Boolean = False
    Public Carga_Formulario As Boolean = False
    Public NumeroCuentaBancaria As Integer
    Public numeroDeCuenta As String
    Public cuentaHabiente As String
    Public idRazonSocial As String
    Public numeroCuentaSicy As String
    Public idBanco As Integer
    Public idCuentaContpaq As String
    Public idBancoContpaq As String
    Public idMoneda As Integer
    Public clabe As String
    Public incluircotizaciones As Boolean = False
    Public pagoremision As Boolean = False
    Public pagofacturas As Boolean = False

    Private Sub AltaCuenta_BancariaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        chkIncluyeCotizacion.Checked = incluircotizaciones
        chkRemisiones.Checked = pagoremision
        chkFacturas.Checked = pagofacturas

        If Carga_Formulario = False Then
            chkRemisiones.Enabled = False
            chkFacturas.Enabled = False
        ElseIf chkIncluyeCotizacion.Checked Then
            chkRemisiones.Enabled = True
            chkFacturas.Enabled = True
        End If

        If Editar_Alta Then
            If numeroCuentaSicy.ToString <> "" Then
                lista_CuentasBancarias_SICY(CInt(numeroCuentaSicy))
            Else
                lista_CuentasBancarias_SICY(0)
            End If
            If chkRemisiones.Checked = False And chkFacturas.Checked = False Then
                chkIncluyeCotizacion.Checked = False
            End If
        Else
            lista_CuentasBancarias_SICY(0)
        End If


        lista_Empresas()
        lista_Bancos()
        llenarComboMonedas()

        If Editar_Alta Then
            If idRazonSocial.ToString <> "" Then
                cmbRazonSocial.SelectedValue = idRazonSocial
            End If




            cmbBanco.SelectedValue = idBanco
                cmbMoneda.SelectedValue = idMoneda


                Dim indexItem As Integer
                Dim dtTabla As New DataTable
                dtTabla = cmbNumeroCuentaSICY.DataSource

                For CONT = 1 To dtTabla.Rows.Count - 1 Step 1
                    If dtTabla.Rows(CONT).Item(0) = numeroCuentaSicy.ToString Then
                        indexItem = CONT
                        Exit For
                    End If

                Next

                cmbNumeroCuentaSICY.SelectedIndex = indexItem


                txtCuentahabiente.Text = cuentaHabiente
                txtNumeroCuenta.Text = numeroDeCuenta
                txtClabeInterbancaria.Text = clabe.Trim.ToUpper

                btnBancoContpaq.PerformClick()
                btnCuentaContpaq.PerformClick()

            End If
        Carga_Formulario = False
    End Sub

    Private Sub lista_CuentasBancarias_SICY(ByVal IdCuentaSicy As Integer)

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Cuentas_Bancarias_SICY(Editar_Alta, IdCuentaSicy)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbNumeroCuentaSICY.DisplayMember = "Cuenta"
        cmbNumeroCuentaSICY.ValueMember = "IdCuenta"
        cmbNumeroCuentaSICY.DataSource = tabla
    End Sub

    Public Sub llenarComboMonedas()
        Dim mon As New Framework.Negocios.MonedaBU
        Dim dtMon As New DataTable
        dtMon = mon.listaMoneda()

        If Not dtMon Is Nothing Then
            dtMon.Rows.InsertAt(dtMon.NewRow, 0)
            cmbMoneda.DataSource = dtMon
            cmbMoneda.DisplayMember = "mone_nombre"
            cmbMoneda.ValueMember = "mone_monedaid"
        End If

    End Sub

    Private Sub lista_Empresas()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Empresas_Say_Sicy_Contpaq
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbRazonSocial.DisplayMember = "essc_razonsocial"
        cmbRazonSocial.ValueMember = "essc_empresaid"
        cmbRazonSocial.DataSource = tabla
    End Sub

    Private Sub lista_Bancos()

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Bancos
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        cmbBanco.DataSource = tabla
        cmbBanco.DisplayMember = "banc_nombre"
        cmbBanco.ValueMember = "banc_bancoid"


    End Sub

    Private Sub lista_Cuentas_Cheques_Contpaq(empresaID As Integer)

        Dim objBU As New Negocios.PolizaBU
        Dim tabla As New DataTable
        tabla = objBU.Combo_lista_Cuentas_Cheques_Contpaq(empresaID)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        If tabla.Rows.Count > 0 Then
            cmbBanco.DataSource = tabla
            cmbBanco.DisplayMember = "Nombre"
            cmbBanco.ValueMember = "Id"
        End If

    End Sub



    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim objBU As New Negocios.CuentasBancariasBU

        Dim cuentaid As Integer
        Dim numero As String = String.Empty
        Dim cuentahabiente As String = String.Empty
        Dim empresaid As Integer
        Dim cuentasicyid As Integer
        Dim bancoid As Integer
        Dim cuentacontpaqid As Integer
        Dim bancocontpaqid As Integer
        Dim idMonedaG As Integer
        Dim CLABEG As String
        Dim incluircotizaciones As Boolean
        Dim pagoremision As Boolean
        Dim pagofacturas As Boolean


        Dim guardar As Boolean = True

        cuentaid = NumeroCuentaBancaria

        If txtNumeroCuenta.Text.Length > 1 Then
            numero = txtNumeroCuenta.Text
            lblNumeroCuenta.ForeColor = Drawing.Color.Black
        Else
            lblNumeroCuenta.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If txtCuentahabiente.Text.Length > 1 Then
            cuentahabiente = txtCuentahabiente.Text
            lblCuentaHabiente.ForeColor = Drawing.Color.Black
        Else
            lblCuentaHabiente.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cmbRazonSocial.SelectedValue) And Not IsDBNull(cmbRazonSocial.SelectedValue) Then
            empresaid = CInt(cmbRazonSocial.SelectedValue)
            lblRazonSocial.ForeColor = Drawing.Color.Black
        Else
            lblRazonSocial.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cmbNumeroCuentaSICY.SelectedItem.DataValue) Then
            If Not IsDBNull(cmbNumeroCuentaSICY.SelectedItem.DataValue) Then
                cuentasicyid = CInt(cmbNumeroCuentaSICY.SelectedItem.DataValue)
                lblNumeroCuentaSicy.ForeColor = Drawing.Color.Black
            End If
        Else
            lblNumeroCuentaSicy.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cmbBanco.SelectedValue) And Not IsDBNull(cmbBanco.SelectedValue) Then
            bancoid = cmbBanco.SelectedValue
            lblBanco.ForeColor = Drawing.Color.Black
        Else
            lblBanco.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cmbCuentaContpaq.SelectedValue) And Not IsDBNull(cmbCuentaContpaq.SelectedValue) Then
            cuentacontpaqid = cmbCuentaContpaq.SelectedValue
            lblCuentaContpaq.ForeColor = Drawing.Color.Black
        Else
            lblCuentaContpaq.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If Not IsNothing(cmbBancoContpaq.SelectedValue) And Not IsDBNull(cmbBancoContpaq.SelectedValue) Then
            bancocontpaqid = cmbBancoContpaq.SelectedValue
            lblBancoContpaq.ForeColor = Drawing.Color.Black
        Else
            lblBancoContpaq.ForeColor = Drawing.Color.Red
            guardar = False
        End If

        If cmbMoneda.SelectedIndex > 0 Then
            idMonedaG = cmbMoneda.SelectedValue
            lblMoneda.ForeColor = Drawing.Color.Black
        Else
            idMonedaG = 0
            lblMoneda.ForeColor = Drawing.Color.Red
            guardar = False
        End If
        Dim error2 As Boolean = False
        If ValidacionCamposCotizaciones() = True Then
                If chkIncluyeCotizacion.Checked Then
                    incluircotizaciones = True
                    If chkRemisiones.Checked Then
                        pagoremision = True
                    End If

                    If chkFacturas.Checked Then
                        pagofacturas = True
                    End If
                End If
            Else
                show_message("Advertencia", "Es necesario marcar al menos una casilla ('Remisiones','Facturas') y la casilla 'Se incluye en la cotizacion'")
                guardar = False
                error2 = True
            End If




            CLABEG = txtClabeInterbancaria.Text.Trim.ToUpper

        If guardar Then
            Try
                objBU.alta_edicion_CuentaBancaria(cuentaid, numero, cuentahabiente, empresaid, cuentasicyid, bancoid, cuentacontpaqid, bancocontpaqid, 1, idMonedaG, CLABEG, incluircotizaciones, pagoremision, pagofacturas)
                show_message("Exito", "Información guardada con éxito")
            Catch ex As Exception
                show_message("Error", "Algo surgió mal durante el proceso de guardado")
            End Try
        Else
            If error2 <> True Then
                show_message("Advertencia", "Hay datos sin capturar")
            End If

            Me.DialogResult = Windows.Forms.DialogResult.None

            End If



    End Sub

    Public Function ValidacionCamposCotizaciones() As Boolean
        Dim Resultado As Boolean = True
        If chkIncluyeCotizacion.Checked = True Then
            If chkRemisiones.Checked = True Or chkFacturas.Checked Then
                Resultado = True
            Else
                Resultado = False
            End If
        Else 'el checkbox chkIncluyeCotizacion no se encuetra seleccionada pero alguno de los checkbox de chkRemisiones chkFacturas SI ERROR'
            If chkRemisiones.Checked = True Or chkFacturas.Checked Then
                Resultado = False
            End If
        End If
        Return Resultado
    End Function

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub cboxRazonSocial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRazonSocial.SelectedValueChanged

        Dim objBU As New Negocios.PolizaBU
        Dim empresaID As Integer

        If Not IsNothing(cmbRazonSocial.SelectedValue) And Not IsDBNull(cmbRazonSocial.SelectedValue) Then

            If objBU.Existe_Tabla_Contpaq(cmbRazonSocial.SelectedValue, "Cuentas") Then
                empresaID = CInt(cmbRazonSocial.SelectedValue)
                cmbCuentaContpaq.Enabled = True
                btnCuentaContpaq.Enabled = True
                'lista_Cuentas_Cheques_Contpaq(empresaID)
                btnBancoContpaq.Enabled = True
                cmbBancoContpaq.Enabled = True

                cmbBanco.SelectedIndex = 0
                cmbNumeroCuentaSICY.SelectedIndex = 0
                cmbCuentaContpaq.DataSource = Nothing
                cmbBancoContpaq.DataSource = Nothing

            Else
                show_message("Advertencia", "Esta empresa no tiene Cuentas en Contpaq")
                Me.DialogResult = Windows.Forms.DialogResult.None
                cmbCuentaContpaq.Enabled = False
                btnCuentaContpaq.Enabled = False
                btnAceptar.Enabled = False

                cmbBanco.SelectedIndex = 0
                cmbNumeroCuentaSICY.SelectedIndex = 0
                cmbCuentaContpaq.DataSource = Nothing
                cmbBancoContpaq.DataSource = Nothing
            End If

        Else
            cmbCuentaContpaq.Enabled = False
            btnCuentaContpaq.Enabled = False
            btnBancoContpaq.Enabled = False
            cmbBancoContpaq.Enabled = False

            If Not IsNothing(cmbBanco.DataSource) Then
                cmbBanco.SelectedIndex = 0
            End If

            cmbNumeroCuentaSICY.SelectedIndex = 0
            cmbCuentaContpaq.DataSource = Nothing
            cmbBancoContpaq.DataSource = Nothing
        End If

    End Sub

    Private Sub btnBancoContpaq_Click(sender As Object, e As EventArgs) Handles btnBancoContpaq.Click

        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 7

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbBancoContpaq.SelectedValue) And Editar_Alta = False Then
            parametro = String.Empty
        ElseIf IsNothing(cmbBancoContpaq.SelectedValue) And Editar_Alta = True Then
            parametro = idBancoContpaq.ToString
            listado.carga_Automatica = True
        Else
            parametro = cmbBancoContpaq.SelectedValue.ToString
        End If

        listaParametroID.Add(parametro)
        listado.listaParametroID = listaParametroID
        If Not IsNothing(cmbRazonSocial.SelectedValue) Then
            listado.id_parametros = cmbRazonSocial.SelectedValue.ToString
        End If
        listado.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        cmbBancoContpaq.DisplayMember = "Nombre de Banco"
        cmbBancoContpaq.ValueMember = "Parámetro"
        cmbBancoContpaq.DataSource = listado.listParametros

        cmbBancoContpaq.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub


    Private Sub btnCuentaContpaq_Click(sender As Object, e As EventArgs) Handles btnCuentaContpaq.Click
        Dim listado As New ListadoParametrosBusquedaForm
        listado.tipo_busqueda = 8

        Dim listaParametroID As New List(Of String)
        Dim parametro As String
        If IsNothing(cmbCuentaContpaq.SelectedValue) And Editar_Alta = False Then
            parametro = String.Empty
        ElseIf IsNothing(cmbCuentaContpaq.SelectedValue) And Editar_Alta = True Then
            parametro = idCuentaContpaq.ToString
            listado.carga_Automatica = True
        Else
            parametro = cmbCuentaContpaq.SelectedValue.ToString
        End If

            listaParametroID.Add(parametro)
            listado.listaParametroID = listaParametroID
            If Not IsNothing(cmbRazonSocial.SelectedValue) Then
                listado.id_parametros = cmbRazonSocial.SelectedValue.ToString
            End If
            listado.StartPosition = FormStartPosition.CenterScreen
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return

            cmbCuentaContpaq.DisplayMember = "Nombre de Cuenta"
            cmbCuentaContpaq.ValueMember = "Parámetro"
            cmbCuentaContpaq.DataSource = listado.listParametros

            cmbCuentaContpaq.SelectedValue = CInt(listado.listParametros.Rows(0).Item("Parámetro"))
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncluyeCotizacion.CheckedChanged
        If Carga_Formulario <> True Then
            If chkIncluyeCotizacion.Checked = True Then
                chkFacturas.Enabled = True
                chkRemisiones.Enabled = True
            Else
                chkRemisiones.Enabled = False
                chkFacturas.Enabled = False
                chkRemisiones.Checked = False
                chkFacturas.Checked = False
            End If
        End If


    End Sub

    Private Sub chkFacturas_CheckedChanged(sender As Object, e As EventArgs) Handles chkFacturas.CheckedChanged
        If Carga_Formulario <> True Then
            If chkRemisiones.Checked = False Then
                If chkFacturas.Checked = False Then
                    chkIncluyeCotizacion.Checked = False
                    '    Else
                    '        chkIncluyeCotizacion.Checked = True
                    '    End If
                    'Else
                    '    chkIncluyeCotizacion.Checked = True
                End If
            End If
        End If
    End Sub

    Private Sub chkRemisiones_CheckedChanged(sender As Object, e As EventArgs) Handles chkRemisiones.CheckedChanged
        If Carga_Formulario <> True Then
            If chkRemisiones.Checked = False Then
                If chkFacturas.Checked = False Then
                    chkIncluyeCotizacion.Checked = False
                    '    Else
                    '        chkIncluyeCotizacion.Checked = True
                    '    End If
                    'Else
                    '    chkIncluyeCotizacion.Checked = True
                End If
            End If
        End If
    End Sub


End Class