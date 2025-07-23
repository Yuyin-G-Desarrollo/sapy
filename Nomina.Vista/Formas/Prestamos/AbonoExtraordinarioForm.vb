Imports Nomina.Negocios
Imports Tools

Public Class AbonoExtraordinarioForm
    Dim idColaborador As String
    Dim idPrestamo As String
    Dim idNave As String
    Dim prestamoEspecial As Boolean = False
    Public Property pnave As String
        Get
            Return idNave
        End Get
        Set(value As String)
            idNave = value
        End Set
    End Property

    Public Property pColaborado As String
        Get
            Return idColaborador
        End Get
        Set(value As String)
            idColaborador = value
        End Set
    End Property
    Public Property pPrestamo As String
        Get
            Return idPrestamo
        End Get
        Set(value As String)
            idPrestamo = value
        End Set
    End Property
    Private Sub AbonoExtraordinarioForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarInformacionPrestamo()
    End Sub
    Public Sub cargarInformacionPrestamo()
        Dim objBUPres As New Negocios.SolicitudPrestamoBU
        Dim tablaPrestamo As New DataTable
        Dim Valor As Integer = 0

        Try
            tablaPrestamo = objBUPres.editarPrestamo(pPrestamo, pColaborado)
            Valor = tablaPrestamo.Rows(0).Item("pres_montoautorizado")
            txtMontoSolicitado.Text = Valor.ToString("C0")
            Valor = tablaPrestamo.Rows(0).Item("pres_saldo")
            txtSaldoCapital.Text = Valor.ToString("C0")
            Dim Interes As Double = tablaPrestamo.Rows(0).Item("pres_interesautorizado")
            Dim DiasInteres As Int16 = tablaPrestamo.Rows(0).Item("pres_pagosSemanaQuincenal")
            'Interes = 7 * (Interes / 30.4)
            Interes = DiasInteres * (Interes / 30.4)
            Interes = Interes / 100
            txtInteres.Text = (Valor * Interes).ToString("C0")
            txtSaldoTotal.Text = (CDbl(txtSaldoCapital.Text) + CDbl(txtInteres.Text)).ToString("C0")
            prestamoEspecial = (tablaPrestamo.Rows(0).Item("pres_prestamoEspecial"))
        Catch ex As Exception
            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = ex.Message
            mensajeError.Show()
        End Try
    End Sub

    Private Sub txtTotalAbono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalAbono.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        generarAbonoExtraordinario()
    End Sub
    Public Sub generarAbonoExtraordinario()
        Dim vCobranzaPrestamos As New CobranzaPrestamosBU
        Dim vConfirmarForm As New ConfirmarForm
        Dim vAdvertenciaForm As New AdvertenciaForm
        Dim vExitoForm As New ExitoForm
        Dim vErrores As New ErroresForm
        Try
            If CInt(txtTotalAbono.Text) >= CInt(txtInteres.Text) And CInt(txtTotalAbono.Text) <= (CInt(txtSaldoCapital.Text) + CInt(txtInteres.Text)) Then
                vConfirmarForm.Text = "Prestamos"
                vConfirmarForm.mensaje = "¿ Desea generar el abono extraoridinario ?"
                Dim vDialogResult As New DialogResult
                vDialogResult = vConfirmarForm.ShowDialog
                If vDialogResult = Windows.Forms.DialogResult.OK Then
                    Dim saldonuevo As Integer = 0
                    Dim interes As Integer = 0

                    If prestamoEspecial = True Then
                        saldonuevo = CInt(txtSaldoCapital.Text) - (CInt(txtTotalAbono.Text) - CInt(txtInteres.Text))
                        interes = CInt(txtInteres.Text)
                    Else
                        saldonuevo = CInt(txtSaldoCapital.Text) - (CInt(txtTotalAbono.Text))
                    End If

                    vCobranzaPrestamos.agregarAbonoExtraoridinario(CInt(pPrestamo), CInt(pnave), CInt(txtTotalAbono.Text), interes, CInt(txtSaldoCapital.Text), saldonuevo)

                    vExitoForm.Text = "Prestamos"
                    vExitoForm.mensaje = "Abono extraordinario generado con éxito"
                    vExitoForm.ShowDialog()

                Else
                    Me.DialogResult = Windows.Forms.DialogResult.None
                End If

            Else
                vAdvertenciaForm.Text = "Prestamos"
                vAdvertenciaForm.mensaje = "El abono no puede ser ni menor al interes total, ni mayor al saldo actual"
                vAdvertenciaForm.ShowDialog()
                Me.DialogResult = Windows.Forms.DialogResult.None
            End If

        Catch ex As Exception
            vErrores.Text = "Prestamos"
            vErrores.mensaje = ex.Message
            vErrores.ShowDialog()
        End Try

    End Sub




    Private Sub txtTotalAbono_TextChanged(sender As Object, e As EventArgs) Handles txtTotalAbono.TextChanged
        If txtTotalAbono.Text = "" Then
            txtTotalAbono.Text = 0
        End If

        If prestamoEspecial = True Then
            txtNuevoSaldo.Text = (CInt(txtSaldoTotal.Text) - (CInt(txtTotalAbono.Text))).ToString("C0")
        Else
            txtNuevoSaldo.Text = (CInt(txtSaldoCapital.Text) - (CInt(txtTotalAbono.Text))).ToString("C0")
        End If
    End Sub
End Class