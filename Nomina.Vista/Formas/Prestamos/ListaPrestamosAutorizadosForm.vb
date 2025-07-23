Imports Tools

Public Class ListaPrestamosAutorizadosForm
    Public idnave As Int32
    Private Sub ListaPrestamosAutorizadosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tools.FormatoCtrls.formato(Me)
        WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        ' cmbCaja = Tools.Controles.ComboCajas(cmbCaja, idNave)
        If cmbCaja.Items.Count = 2 Then
            cmbCaja.SelectedIndex = 1
        End If
        If cmbCaja.Items.Count > 2 Then
            cmbCaja.SelectedIndex = 0
        End If

        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        btnenviar.Enabled = False
        lblenviar.Enabled = False
        lblGerente.Visible = False
        lblDirector.Visible = False


    End Sub
    ''LLENAR LAS NAVER POR USUARIO EN EL COMBO BOX


    'Private Sub cmbFormaPago_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.DropDownClosed
    '    cmbCaja.Enabled = True
    'End Sub

    ''LLENAR PRESTAMOS AUTORIZADOS  
    Public Sub llenarTablaConPrestamosAutorizados()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamos(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosAutorizados(objeto)
            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosAutorizados(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        Dim estatus As String
        estatus = Prestamos.Pestatus

        If lblDirector.Text = "True" Then
            If estatus.Equals("C") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
                fila.Cells.Add(celda)

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = grdPrestamosAutorizados.Rows.Count + 1
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psaldo
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pabono
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psemanas
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pinteres
                fila.Cells.Add(celda)

                If tipoInteres.Equals("I") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "SIN INTERÉS"
                    fila.Cells.Add(celda)
                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERÉS FIJO"
                        fila.Cells.Add(celda)
                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "SOBRE SALDO"
                            fila.Cells.Add(celda)
                        End If
                    End If
                End If

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pestatus
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PColaboradorid
                fila.Cells.Add(celda)

                Me.grdPrestamosAutorizados.Rows.Add(fila)

                ' grdPrestamosAutorizados.DefaultCellStyle.BackColor = Color.LightGreen
            End If
        End If

        If lblGerente.Text = "True" And lblDirector.Text = "False" Then

            If estatus.Equals("B") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
                fila.Cells.Add(celda)

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = grdPrestamosAutorizados.Rows.Count + 1
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PNombre + " " + Prestamos.Pcolaborador.PApaterno + " " + Prestamos.Pcolaborador.PAmaterno
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psaldo
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pabono
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psemanas
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pinteres
                fila.Cells.Add(celda)

                If tipoInteres.Equals("I") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "SIN INTERÉS"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERÉS FIJO"
                        fila.Cells.Add(celda)

                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "SOBRE SALDO"
                            fila.Cells.Add(celda)
                        End If
                    End If
                End If

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pestatus
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PColaboradorid
                fila.Cells.Add(celda)

                Me.grdPrestamosAutorizados.Rows.Add(fila)

                '  grdPrestamosAutorizados.DefaultCellStyle.BackColor = Color.LightGreen
            End If
        End If
    End Sub

    ''LLENAR LA CONFIGURACION DE LOS PRESTAMOS
    Public Sub AgregarDatos(ByVal ConfiguracionPrestamos As Entidades.ConfiguracionPrestamos)
        Dim MaxNave = ConfiguracionPrestamos.PMontoMaximoPorNave
        lblGerente.Text = ConfiguracionPrestamos.PAutorizacionGerente
        lblDirector.Text = ConfiguracionPrestamos.PAutorizacionDirector

    End Sub

    Public Sub llenarconfiguracionPrestamo()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNave.SelectedValue))

            listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(idNave)

            For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
                AgregarDatos(objeto)
            Next

        Catch ex As Exception
        End Try

    End Sub
    ''--------------------------------------------------------------------------------
    Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar.Click
        Dim contadorFilas As Integer = 0
        For Each dato As DataGridViewRow In grdPrestamosAutorizados.Rows
            contadorFilas += 1
            Exit For
        Next
        If contadorFilas > 0 Then
            Dim mensajeExito2 As New ConfirmarForm
            mensajeExito2.mensaje = "¿Estas seguro de querer realizar la solicitud? "

            If mensajeExito2.ShowDialog = DialogResult.OK Then
                Try

                    If cmbCaja.SelectedIndex = 0 Or IsNothing(cmbFormaPago.SelectedItem) Then
                        Dim mensajeExito As New AvisoForm
                        mensajeExito.MdiParent = Me.MdiParent
                        mensajeExito.mensaje = "Debe seleeccionar todos los parámetros de búsqueda."
                        mensajeExito.Show()
                    Else

                        If cmbFormaPago.SelectedItem.Equals("EFECTIVO") Then
                            Dim contadorDeTrue As Integer = 0
                            Dim MontoAutorizar As Double
                            Dim objEnt As New Entidades.SolicitudPrestamo
                            Dim IDSolicitud As DataTable
                            Dim CajasBU As New Negocios.CajasBU
                            Dim objBU As New Negocios.SolicitudPrestamoBU

                            For Each row As DataGridViewRow In grdPrestamosAutorizados.Rows
                                If row.Cells("clmEnviar").Value = True Then
                                    MontoAutorizar += row.Cells("clmMonto").Value
                                    contadorDeTrue += 1
                                End If
                            Next

                            If contadorDeTrue = 0 Then
                                Dim mensajeExito3 As New AvisoForm
                                mensajeExito3.MdiParent = Me.MdiParent
                                mensajeExito3.mensaje = "Debe seleccionar al menos un préstamo."
                                mensajeExito3.Show()
                            Else
                                'If cmbNave.SelectedValue = 43 Then
                                'IDSolicitud = CajasBU.EnviarSolicitudesPrestamoCaja(cmbCaja.SelectedValue, "EFECTIVO", MontoAutorizar, "", "PAGO DE PRESTAMOS")
                                'Else
                                '    IDSolicitud = CajasBU.EnviarSolicitudesPrestamoCajaPruebas(cmbCaja.SelectedValue, "EFECTIVO", MontoAutorizar, "", "PAGO DE PRESTAMOS")
                                'End If

                                For Each row As DataGridViewRow In grdPrestamosAutorizados.Rows
                                    If row.Cells("clmEnviar").Value = True Then
                                        objEnt.Pprestamoid = row.Cells("clmidPrestamo").Value
                                        objEnt.Psolicitudid = IDSolicitud.Rows(0).Item(0).ToString

                                        objBU.guardarIdSolicitudPrestamos(objEnt)

                                    End If
                                Next
                                grdPrestamosAutorizados.Rows.Clear()
                                llenarTablaConPrestamosAutorizados()

                                Dim mensajeExito As New ExitoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje += "El dinero ha sido solicitado."

                                mensajeExito.Show()
                            End If
                        Else
                            ''SI ES CHEQUE
                            If cmbFormaPago.SelectedItem.Equals("CHEQUE") Then
                                Dim contadorDeTrue As Integer = 0
                                Dim MontoAutorizar As Double
                                Dim objEnt As New Entidades.SolicitudPrestamo
                                Dim IDSolicitud As DataTable
                                Dim CajasBU As New Negocios.CajasBU
                                Dim objBU As New Negocios.SolicitudPrestamoBU

                                For Each row As DataGridViewRow In grdPrestamosAutorizados.Rows

                                    If row.Cells("clmEnviar").Value = True Then
                                        MontoAutorizar = row.Cells("clmMonto").Value
                                        If cmbNave.SelectedValue = 43 Then
                                            '       IDSolicitud = CajasBU.EnviarSolicitudesPrestamoCaja(cmbCaja.SelectedValue, "CHEQUE", MontoAutorizar, row.Cells("clmColaborador").Value, "PAGO DE PRESTAMOS")
                                        Else
                                            IDSolicitud = CajasBU.EnviarSolicitudesPrestamoCajaPruebas(cmbCaja.SelectedValue, "CHEQUE", MontoAutorizar, row.Cells("clmColaborador").Value, "PAGO DE PRESTAMOS")
                                        End If

                                        objEnt.Pprestamoid = row.Cells("clmidPrestamo").Value
                                        objEnt.Psolicitudid = IDSolicitud.Rows(0).Item(0).ToString
                                        objBU.guardarIdSolicitudPrestamos(objEnt)
                                        contadorDeTrue += 1
                                    End If
                                Next

                                If contadorDeTrue = 0 Then
                                    Dim mensajeExito4 As New AvisoForm
                                    mensajeExito4.MdiParent = Me.MdiParent
                                    mensajeExito4.mensaje = "Debe seleccionar al menos un préstamo."
                                    mensajeExito4.Show()

                                Else
                                    Dim mensajeExito As New ExitoForm
                                    mensajeExito.MdiParent = Me.MdiParent
                                    mensajeExito.mensaje = "El dinero ha sido solicitado."
                                    mensajeExito.Show()
                                    grdPrestamosAutorizados.Rows.Clear()
                                    llenarTablaConPrestamosAutorizados()
                                End If

                            End If

                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    'Private Sub cmbCaja_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCaja.DropDownClosed
    '    btnenviar.Enabled = True
    '    lblenviar.Enabled = True
    'End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 151
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            grdPrestamosAutorizados.Rows.Clear()
            llenarconfiguracionPrestamo()
            llenarTablaConPrestamosAutorizados()
            cmbFormaPago.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub lblLimpiar_Click(sender As Object, e As EventArgs) Handles lblLimpiar.Click

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdPrestamosAutorizados.Rows.Clear()
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            grdPrestamosAutorizados.Rows.Clear()
            llenarconfiguracionPrestamo()
            llenarTablaConPrestamosAutorizados()
            'cmbFormaPago.Enabled = True
            btnenviar.Enabled = True
            lblenviar.Enabled = True
        Catch ex As Exception
        End Try
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


End Class