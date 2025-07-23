Imports Tools
Imports Produccion.Negocios
Imports Entidades
Imports System.IO

Public Class RecibirRemisionesForm
    Public idOrdendeCompra As Integer = 0
    Public idProveedor As Integer = 0
    Public idNave As Integer = 0
    Public total As Double = 0
    Dim exito As New ExitoForm
    Dim adv As New AdvertenciaForm
    Dim idmoneda As Integer = 0

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub RecibirRemisionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Private Sub cargarDatos()
        Dim obj As New RecepcionBU
        Dim datos As New DataTable
        datos = obj.getDatosOrdendeCompra(idOrdendeCompra)
        For Each row As DataRow In datos.Rows
            lblFolio.Text = getNumOrden(row("ordc_ordennumero"))
            lblModena.Text = row("mone_nombre")
            lblProveedor.Text = row("prov_razonsocial")
            lblRFC.Text = row("prov_rfc")
            lblSubtotal.Text = Format(row("subtotal"), "##,##0.00")
            lblDescuento.Text = Format(row("subtotal") * ((row("ordc_descuento") / 100)), "##,##0.00")
            idProveedor = row("ordc_proveedorid")
            lblTotal.Text = Format(CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text), "##,##0.00")
            total = (CDbl(lblSubtotal.Text) - CDbl(lblDescuento.Text))
            idNave = row("ordc_naveid")
            idmoneda = row("mone_monedaid")
        Next
        cargarEmpresas()
        cargarPlazos()
        If obj.getPaisProveedor(idProveedor) <> "MÉXICO" Then
            txtRuta.Visible = True
            lblRuta.Visible = True
            btnSeleccionar.Visible = True
            getFolio()
        Else
            getFolio()
            txtRuta.Visible = False
            lblRuta.Visible = False
            btnSeleccionar.Visible = False
        End If

    End Sub
    Private Sub getFolio()
        Dim obj As New RecepcionBU
        Dim dtFolio As String
        dtFolio = obj.getNextFolioRemision(idNave, idProveedor)
        If dtFolio.Contains("$CONTIENE LETRAS") Then
            txtFolio.Enabled = True
            lblFoliour.Text = "Último folio registrado: " & dtFolio.Split("$")(0)
            lblFoliour.Visible = True
        Else
            txtFolio.Text = dtFolio
            txtFolio.Enabled = False
        End If
    End Sub
    Private Sub cargarEmpresas()
        Dim obj As New RecepcionBU
        Dim lst As New DataTable

        lst = obj.getEmpresasXNave(0)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbEmpresa.DataSource = lst
            cmbEmpresa.DisplayMember = "empr_nombre"
            cmbEmpresa.ValueMember = "empr_empresaid"
        End If
        If lst.Rows.Count = 2 Then
            cmbEmpresa.SelectedIndex = 1
            cmbEmpresa.Enabled = False
        End If
    End Sub

    Private Sub cargarPlazos()
        Dim obj As New RecepcionBU
        Dim lst As New DataTable

        lst = obj.getPlazoProveedor(idProveedor)
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbPlazos.DataSource = lst
            cmbPlazos.DisplayMember = "plpa_plazo"
            cmbPlazos.ValueMember = "plpa_plazopagoid"
        End If
    End Sub
    Function getNumOrden(num As String) As String
        If num.Length = 1 Then
            num = "0000" & num
        ElseIf num.Length = 2 Then
            num = "000" & num
        ElseIf num.Length = 3 Then
            num = "00" & num
        ElseIf num.Length = 4 Then
            num = "0" & num
        ElseIf num.Length = 5 Then
            num = num
        End If
        Return num
    End Function

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Me.Cursor = Cursors.WaitCursor
        OpenFileDialog1.Filter = "pdf files (*.pdf)|*.pdf"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtRuta.Text = OpenFileDialog1.FileName
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbPlazos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlazos.SelectedIndexChanged
        Try
            If cmbPlazos.SelectedValue > 0 Then
                Dim c As New CxPSaldos

                c = getDatosSemanadePago(c)
                lblSemanaPago.Text = "" & getFechaPagoMiercoles(c.FECVENTO).ToString("dd/MM/yyyy") & " (SEM " & c.SEMPAGADA.ToString & ")"

            End If
        Catch ex As Exception

        End Try
    End Sub
    Function getFechaPagoMiercoles(ByVal fecha As Date) As Date
        Dim f As New Date

        For i As Integer = 1 To 6
            f = fecha.AddDays(-i)
            Dim s As String
            s = f.DayOfWeek
            If s = "3" Then
                Return f
            End If
        Next
        Return f
    End Function

    Function getdatos() As CxPSaldos
        Dim obj As New RecepcionBU
        Dim c As New CxPSaldos
        Dim factura As New CxPSaldos
        Dim datosProv As New DataTable
        datosProv = obj.getDatosProveedor(idProveedor)
        c = getDatosPago()
        c = getDatosSemanadePago(c)
        With c
            c.TIPODOCTO = 2
            c.CVEPROV = CInt(datosProv.Rows(0).Item("sicy").ToString)
            c.REFERENCIA = datosProv.Rows(0).Item("giro").ToString
            c.USUCAPTURA = ""
        End With
        Return c
    End Function
    Function getDatosSemanadePago(c As CxPSaldos) As CxPSaldos
        Dim obj As New RecepcionBU
        Dim datossemanas As New DataTable
        Dim datossemanas2 As New DataTable
        datossemanas = obj.getSemana(0, Date.Now)
        If datossemanas.Rows.Count > 0 Then
            datossemanas2 = obj.getSemanaPago(datossemanas.Rows(0).Item("sema_semanaid"), cmbPlazos.SelectedValue)
            If datossemanas2.Rows.Count > 0 Then
                datossemanas = obj.getSemana(datossemanas2.Rows(0).Item("secp_semanapagoid"), Date.Now)
            End If
            With c
                c.FECVENTO = datossemanas.Rows(0).Item("sema_fechaFin")
                c.SEMPAGO = datossemanas.Rows(0).Item("sema_noSemana")
                c.SEMPAGADA = datossemanas.Rows(0).Item("sema_noSemana")
                c.AÑOSEMPAGO = datossemanas.Rows(0).Item("sema_anio")
                c.AÑOSEMPAGADA = datossemanas.Rows(0).Item("sema_anio")
            End With
        End If
        Return c
    End Function
    Function getDatosPago() As CxPSaldos
        Dim datos As New DataTable
        Dim obj As New RecepcionBU
        Dim row As DataRowView
        row = cmbEmpresa.SelectedItem
        Dim c As New CxPSaldos
        c.SUBTOT = total
        c.IMPDOCTO = total
        c.SDODOCTO = total
        c.NUMDOCTO = txtFolio.Text.Trim
        c.IMPIVA = 0
        c.FECDOCTO = Date.Now
        c.MONEDA = idmoneda
        c.RfcEmpresa = row("empr_rfc")
        c.RfcProveedor = obj.getRFCProveedor(idProveedor)
        c.IdComprobante = 0
        c.NAVE = idNave 'Nave de say
        c.IdComprobantecfdsOrdenCompra = 0
        Return c
    End Function

    Private Sub btnGuardarRemision_Click(sender As Object, e As EventArgs) Handles btnGuardarRemision.Click
        If validarFolio() Then
            Dim ruta As String = ""
            Dim c As New CxPSaldos
            Dim datos As New DataTable
            Dim obj As New RecepcionBU
            c = getdatos()
            datos = obj.InsertcxpSaldoscxpMovimientos(c)
            If datos.Rows.Count > 0 Then
                If datos.Rows(0).Item(0).ToString.Contains("True") Then
                    If txtRuta.Visible Then
                        Dim datosConfigNave As New DataTable
                        datosConfigNave = obj.getConfiguracionNave(idNave)
                        For Each row2 As DataRow In datosConfigNave.Rows
                            ruta = CopiarArchivos(txtRuta.Text.Trim.ToUpper, txtFolio.Text.Trim.ToUpper, "PDF", row2("fac_rutaFacturas").ToString)
                        Next
                        'ruta = CopiarArchivos(txtRuta.Text.Trim.ToUpper, txtFolio.Text.Trim.ToUpper, "PDF")
                        obj.insertarComprobante(idOrdendeCompra, ruta)
                    End If
                    obj.cerrarDatosOrdenCompraFacturaRecibida(idOrdendeCompra, c.IdComprobantecfdsOrdenCompra)
                    exito.mensaje = "Remisión recibida"
                    exito.ShowDialog()
                    Me.Close()
                Else
                    adv.mensaje = datos.Rows(0).Item(0).ToString
                    adv.ShowDialog()
                End If
            End If
        End If
    End Sub

    Function validarFolio() As Boolean
        Dim obj As New RecepcionBU

        If txtFolio.Text.Trim.Length <= 0 Then
            adv.mensaje = "Ingrese un folio."
            adv.ShowDialog()
            Return False
        End If
        If obj.validarFolio(txtFolio.Text.Trim, idProveedor).Rows.Count > 0 Then
            adv.mensaje = "El folio ya se encuentra registrado para ese proveedor."
            adv.ShowDialog()
            Return False
        End If
        If cmbPlazos.SelectedValue <= 0 Then
            adv.mensaje = "Seleccione un plazo de pago."
            adv.ShowDialog()
            Return False
        End If
        If cmbEmpresa.SelectedValue <= 0 Then
            adv.mensaje = "Seleccione una empresa."
            adv.ShowDialog()
            Return False
        End If
        Return True
    End Function

    Function CopiarArchivos(ByVal ruta As String, ByVal nombreArchivo As String, ByVal ext As String, ByVal rutanombreNave As String) As String
        '\\192.168.2.2\bin\TASFE\COMPRAS\[nave]\mesaño\
        'C:\Users\SISTEMAS13\Desktop\test.pdf
        Try
            Dim fecha As New Date
            Dim obj As New RecepcionBU
            fecha = Date.Today
            Dim fechaCarpeta As String = concatenarFecha(fecha)
            If Not Directory.Exists(rutanombreNave) Then
                Directory.CreateDirectory(rutanombreNave)
                If Not Directory.Exists(rutanombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutanombreNave & "\" & fechaCarpeta)
                    If ruta.Length > 0 Then
                        System.IO.File.Copy(ruta, rutanombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                End If
            Else
                If Not Directory.Exists(rutanombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutanombreNave & "\" & fechaCarpeta)
                    If ruta.Length > 0 Then
                        System.IO.File.Copy(ruta, rutanombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                Else
                    If ruta.Length > 0 Then
                        System.IO.File.Copy(ruta, rutanombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                End If
            End If
            If ruta.Length > 0 Then
                Dim rutatmp As String = fechaCarpeta & "\" & nombreArchivo & "." & ext
                Return rutatmp
            Else
                Return ""
            End If
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado al copiar el XML o PDF. Detalles: " & ex.Message
            adv.ShowDialog()
            Return ""
        End Try
    End Function
    Function concatenarFecha(ByVal fecha As Date)
        Dim cadena As String
        If fecha.Month < 10 Then
            cadena = "0" & fecha.Month & "" & fecha.Year
        Else
            cadena = "" & fecha.Month & "" & fecha.Year
        End If
        Return cadena
    End Function

    Private Sub txtFolio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolio.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

   
End Class