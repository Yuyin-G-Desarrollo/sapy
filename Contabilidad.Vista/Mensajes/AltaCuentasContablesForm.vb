Public Class AltaCuentasContablesForm
    Public proveedorDesc As String
    Public proveedorID As Integer
    Public tipoCuenta As String
    Public cuentaSAYID As Integer = 0
    Public cuentaContpaqID As String
    Public cuentaContpaqNueva As String
    Public cuentaDescripcion As String
    Public empresaBD As String
    Public servidorBD As String
    Public empresaSAYContpaqSICY As Integer
    Public proveedorRFC As String
    Dim constante1 As String = ""
    Dim constante2 As String = ""

    Private Sub AltaCuentasContablesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Text = proveedorDesc
        lblNombreRespaldo2.Text = proveedorDesc
        rdbAcredores.Visible = False
        rdbProveedor.Visible = False
        rdbClientes.Visible = False

        If tipoCuenta = "COMPRAS" Then
            rdbAcredores.Visible = True
            rdbProveedor.Visible = True
            rdbProveedor.Checked = True
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "TRANSFERENCIAS" Then
            rdbAcredores.Visible = True
            rdbProveedor.Visible = True
            rdbProveedor.Checked = True
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)

        ElseIf tipoCuenta = "GASTOS" Then
            rdbAcredores.Visible = True
            rdbProveedor.Visible = True
            rdbProveedor.Checked = True
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "GASTOS Y COMPRAS" Then
            rdbAcredores.Visible = True
            rdbProveedor.Visible = True
            rdbProveedor.Checked = True
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "PRODUCTO TERMINADO" Then
            rdbAcredores.Visible = True
            rdbProveedor.Visible = True
            rdbProveedor.Checked = True
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)

        ElseIf tipoCuenta = "GASTO DE TRANSPORTE" Then
            rdbAcredores.Visible = True
            rdbProveedor.Visible = True
            rdbProveedor.Checked = True
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)

        ElseIf tipoCuenta = "DEPÓSITOS POR IDENTIFICAR" Then
            rdbClientes.Visible = True
            rdbClientes.Checked = True
            constante1 = "105"
            constante2 = "1000"

        ElseIf tipoCuenta = "DEPÓSITOS IDENTIFICADOS" Then
            rdbClientes.Visible = True
            rdbClientes.Checked = True
            constante1 = "105"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        If rdbProveedor.Checked = True Then
            constante1 = "201"
            constante2 = "1000"
        ElseIf rdbAcredores.Checked = True Then
            constante1 = "205"
            constante2 = "1000"
        End If

        If tipoCuenta = "COMPRAS" Then
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "TRANSFERENCIAS" Then
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "GASTOS" Then
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "GASTOS Y COMPRAS" Then
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "PRODUCTO TERMINADO" Then
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "GASTO DE TRANSPORTE" Then
            GenerarCuenta(constante1, constante2)
        ElseIf tipoCuenta = "DEPÓSITOS POR IDENTIFICAR" Then

        ElseIf tipoCuenta = "DEPÓSITOS IDENTIFICADOS" Then

        End If
    End Sub

    Public Sub GenerarCuenta(ByVal constante1 As String, ByVal constante2 As String)

        If txtNombre.Text.Trim.Length > 0 Then
            Dim letra As String = ""
            Dim consecutivo As String = ""
            Dim nomenclatura As String = ""
            Dim tabla As New DataTable
            Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
            '  txtNombre.Text = txtNombre.Text.Trim
            proveedorDesc = txtNombre.Text.Trim


            letra = proveedorDesc.Substring(0, 1)
            nomenclatura = constante1 + constante2 + letra
            tabla = objBu.obtenerConsecutivo(servidorBD, empresaBD, nomenclatura)

            If tabla.Rows.Count > 0 Then
                consecutivo = tabla.Rows(0).Item("Cuenta").ToString.Substring(8, 3)
                consecutivo += 1
                If consecutivo < 10 Then
                    consecutivo = "00" + consecutivo.ToString
                ElseIf consecutivo >= 10 And consecutivo <= 99 Then
                    consecutivo = "0" + consecutivo.ToString
                End If
            Else
                consecutivo = "001"
            End If
            txtNumero.Text = constante1.ToString + constante2.ToString + letra.ToString.ToUpper + consecutivo.ToString
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


        Dim mensaje As New ConfirmarForm
        Dim tabla As New DataTable
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim polizas As New Entidades.Polizas
        Dim cuentaContpaqID As String
        Dim tablaSAYID As DataTable
        mensaje.mensaje = "¿Esta seguro querer generar la cuenta?"
        If mensaje.ShowDialog = Windows.Forms.DialogResult.OK Then

            If tipoCuenta = "COMPRAS" Or tipoCuenta = "TRANSFERENCIAS" Or tipoCuenta = "GASTOS" Or tipoCuenta = "GASTOS Y COMPRAS" Or tipoCuenta = "PRODUCTO TERMINADO" Then

                validarProveedoresExisten()
                tabla = objBu.AltaCuentasContablesCONTPAQ(txtNombre.Text, txtNumero.Text, servidorBD, empresaBD)
                cuentaContpaqNueva = tabla.Rows(0).Item("CuentaNueva")
                cuentaContpaqID = tabla.Rows(0).Item("ID")
                cuentaDescripcion = txtNombre.Text
                'INSERTA CUENTA EN SAY
                polizas.Pconstante1 = cuentaContpaqNueva.Substring(0, 3)
                polizas.Pconstante2 = cuentaContpaqNueva.Substring(3, 4)
                polizas.Pletra = cuentaContpaqNueva.Substring(7, 1)
                polizas.Pconsecutivo = cuentaContpaqNueva.Substring(8, 3)
                polizas.PccContpaqID = cuentaContpaqID
                polizas.PproveedorSicyID = proveedorID
                polizas.PclienteID = 0
                polizas.PccTipo = 7
                polizas.PproveedorNombre = cuentaDescripcion
                polizas.PempresaID = empresaSAYContpaqSICY
                polizas.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                tablaSAYID = objBu.AltaCuentasContablesSAY(polizas, servidorBD, empresaBD, "")
                cuentaSAYID = tablaSAYID.Rows(0).Item("cuentaSAYID")
                Me.Close()

            ElseIf tipoCuenta = "DEPÓSITOS POR IDENTIFICAR" Then

            ElseIf tipoCuenta = "DEPÓSITOS IDENTIFICADOS" Then
                tabla = objBu.AltaCuentasContablesCONTPAQ(txtNombre.Text, txtNumero.Text, servidorBD, empresaBD)
                cuentaContpaqNueva = tabla.Rows(0).Item("CuentaNueva")
                cuentaContpaqID = tabla.Rows(0).Item("ID")
                cuentaDescripcion = txtNombre.Text
                polizas.Pconstante1 = cuentaContpaqNueva.Substring(0, 3)
                polizas.Pconstante2 = cuentaContpaqNueva.Substring(3, 4)
                polizas.Pletra = cuentaContpaqNueva.Substring(7, 1)
                polizas.Pconsecutivo = cuentaContpaqNueva.Substring(8, 3)
                polizas.PccContpaqID = cuentaContpaqID
                polizas.PproveedorSicyID = 0
                polizas.PclienteID = proveedorID
                polizas.PclienteID = 0
                polizas.PccTipo = 7
                polizas.PempresaID = empresaSAYContpaqSICY
                polizas.PproveedorNombre = cuentaDescripcion
                polizas.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                tablaSAYID = objBu.AltaCuentasContablesSAY(polizas, servidorBD, empresaBD, "")
                cuentaSAYID = tablaSAYID.Rows(0).Item("cuentaSAYID")
                Me.Close()
            End If
        End If
    End Sub

#Region "Validar y dar alta proveedores SAY/Contpaq"

    Public Function ValidarPersonaProveedorExisteContpaq(ByVal proveedorRFC As String, ByVal servidorBD As String, empresaBD As String) As Boolean
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim existe As Boolean = False
        tabla = objBu.ValidarPersonaProveedorExisteContpaq(proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim, servidorBD, empresaBD)
        If tabla.Rows.Count > 0 Then
            existe = True
        End If
        Return existe
    End Function

    Public Function AltaPersonasCompaq(ByVal RFC As String, ByVal Proveedor As String) As Entidades.Polizas
        Dim listaEntidad As New Entidades.Polizas
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim idPersona As Integer = 0
        listaEntidad.PproveedorRFC = RFC.Replace("-", "").Trim
        listaEntidad.PproveedorNombre = Proveedor
        listaEntidad.PempresaBD = empresaBD
        listaEntidad.PservidorBD = servidorBD

        tabla = objBU.AltaPersonasContpaq(listaEntidad)
        idPersona = tabla.Rows(0).Item("personaCodigo")
        listaEntidad.PproveedorPersonaID = idPersona

        Return listaEntidad
    End Function

    Public Function AltaProveedorCompaq(ByVal listaEntidad As Entidades.Polizas) As String
        Dim objBU As New Contabilidad.Negocios.AltaPolizaBU
        Dim tabla As New DataTable
        Dim proveedorContaq As String = ""
        tabla = objBU.AltaProveedoresContpaq(listaEntidad)
        proveedorContaq = tabla.Rows(0).Item("proveedorID")
        Return proveedorContaq
    End Function

    Public Sub validarProveedoresExisten()
        Dim tabla As New DataTable
        Dim objBu As New Contabilidad.Negocios.AltaPolizaBU
        Dim listaEntidades As New Entidades.Polizas
        Dim existe As Boolean = False
        Dim proveedorContpaqID As String
        Dim personaSAYid As Integer

        existe = ValidarPersonaProveedorExisteContpaq(proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim, servidorBD, empresaBD)
        If existe = False Then
            listaEntidades = AltaPersonasCompaq(proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim, txtNombre.Text)
            proveedorContpaqID = AltaProveedorCompaq(listaEntidades)
            tabla = objBu.validarProveedorExisteSAY(proveedorRFC.ToString.Replace("-", "").Replace(" ", "").Trim)

            If tabla.Rows.Count = 0 Then
                tabla = Nothing
                listaEntidades.PproveedorNombre = txtNombre.Text
                tabla = objBu.insertarPersonaSAY(listaEntidades)
                personaSAYid = tabla.Rows(0).Item("id")
                listaEntidades.PproveedorRFC = proveedorRFC.Replace("-", "").Trim
                listaEntidades.PproveedoID = personaSAYid
                listaEntidades.PproveedorSicyID = proveedorID
                tabla = objBu.insertarProveedorSAY(listaEntidades)
            End If
        ElseIf existe = True Then
            tabla = objBu.validarProveedorExisteSAY(proveedorRFC.Replace("-", "").Trim)
            If tabla.Rows.Count = 0 Then
                tabla = Nothing
                listaEntidades.PproveedorNombre = txtNombre.Text
                tabla = objBu.insertarPersonaSAY(listaEntidades)
                personaSAYid = tabla.Rows(0).Item("id")
                listaEntidades.PproveedorRFC = proveedorRFC.Replace("-", "").Trim
                listaEntidades.PproveedoID = personaSAYid
                listaEntidades.PproveedorSicyID = proveedorID
                tabla = objBu.insertarProveedorSAY(listaEntidades)
            End If
        End If
        ''#Fin
    End Sub

#End Region

    Private Sub rdbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles rdbProveedor.CheckedChanged
        If rdbProveedor.Checked = True Then
            constante1 = "201"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)
        End If
    End Sub

    Private Sub rdbAcredores_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAcredores.CheckedChanged
        If rdbAcredores.Checked = True Then
            constante1 = "205"
            constante2 = "1000"
            GenerarCuenta(constante1, constante2)
        End If
    End Sub
End Class