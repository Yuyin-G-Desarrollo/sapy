Public Class AltaCuentaContableForm
    Public proveedorDesc As String
    Public proveedorID As Integer
    Public tipoCuenta As String
    Public cuentaContpaqID As String
    Public cuentaContpaqNueva As String
    Public empresaBD As String
    Public servidorBD As String
    Public empresaSAYContpaqSICY As Integer

    Private Sub AltaCuentaContableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNombre.Text = proveedorDesc
        lblNombreRespaldo2.Text = proveedorDesc

        If tipoCuenta = "COMPRAS" Then
            GenerarCuenta("200", "1000")

        ElseIf tipoCuenta = "TRANSFERENCIAS" Then

        ElseIf tipoCuenta = "DEPÓSITOS POR IDENTIFICAR" Then

        ElseIf tipoCuenta = "DEPÓSITOS IDENTIFICADOS" Then

        End If
    End Sub


    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        If tipoCuenta = "COMPRAS" Then
            GenerarCuenta("200", "1000")
        ElseIf tipoCuenta = "TRANSFERENCIAS" Then

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
            txtNombre.Text = txtNombre.Text.Trim
            proveedorDesc = txtNombre.Text


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
        mensaje.mensaje = "¿Esta seguro querer generar la cuenta?"
        If mensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            tabla = objBu.AltaCuentasContablesCONTPAQ(txtNombre.Text, txtNumero.Text, servidorBD, empresaBD)
            cuentaContpaqNueva = tabla.Rows(0).Item("CuentaNueva")
            cuentaContpaqID = tabla.Rows(0).Item("ID")

            'INSERTA CUENTA EN SAY
            polizas.Pconstante1 = cuentaContpaqNueva.Substring(0, 3)
            polizas.Pconstante2 = cuentaContpaqNueva.Substring(3, 4)
            polizas.Pletra = cuentaContpaqNueva.Substring(7, 1)
            polizas.Pconsecutivo = cuentaContpaqNueva.Substring(8, 3)
            polizas.PccContpaqID = cuentaContpaqID
            polizas.PproveedorSicyID = proveedorID
            polizas.PccTipo = 7
            polizas.PempresaID = empresaSAYContpaqSICY
            polizas.PusuarioCreoID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            objBu.AltaCuentasContablesSAY(polizas, servidorBD, empresaBD, "")
            Me.Close()
        End If



    End Sub
End Class