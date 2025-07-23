Imports Tools

Public Class ConfirmacionDineroPrestamoEnNaveForm

    Private Sub ConfirmacionDineroPrestamoEnNaveForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

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

        If cmbEstatus.SelectedItem.Equals("PAGADOS") Then

            If estatus.Equals("F") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
                fila.Cells.Add(celda)


                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psolicitudid
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
                    celda.Value = "Sin interes"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "Interes fijo"
                        fila.Cells.Add(celda)

                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "Sobre saldo"
                            fila.Cells.Add(celda)
                        End If
                    End If
                End If

                celda = New DataGridViewCheckBoxCell
                celda.Value = True
                fila.Cells.Add(celda)


                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pestatus
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PColaboradorid
                fila.Cells.Add(celda)

                Me.grdPrestamos.Rows.Add(fila)

                grdPrestamos.DefaultCellStyle.BackColor = Color.LightGray

                For Each row As DataGridViewRow In grdPrestamos.Rows
                    grdPrestamos.CurrentRow.Cells(8).ReadOnly = True

                Next


            End If
        End If


        If cmbEstatus.SelectedItem.Equals("ENVIADOS") Then

            If estatus.Equals("D") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
                fila.Cells.Add(celda)


                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psolicitudid
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
                    celda.Value = "Sin interes"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "Interes fijo"
                        fila.Cells.Add(celda)

                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "Sobre saldo"
                            fila.Cells.Add(celda)
                        End If
                    End If
                End If

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
                fila.Cells.Add(celda)


                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pestatus
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PColaboradorid
                fila.Cells.Add(celda)

                Me.grdPrestamos.Rows.Add(fila)

                grdPrestamos.DefaultCellStyle.BackColor = Color.LightGreen


            End If

        End If

        If cmbEstatus.SelectedItem.Equals("RECIBIDOS") Then

            If estatus.Equals("E") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
                fila.Cells.Add(celda)


                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Psolicitudid
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
                    celda.Value = "Sin interes"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "Interes fijo"
                        fila.Cells.Add(celda)

                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "Sobre saldo"
                            fila.Cells.Add(celda)
                        End If
                    End If
                End If

                celda = New DataGridViewTextBoxCell
                celda.Value = "Recibido"
                fila.Cells.Add(celda)


                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pestatus
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PColaboradorid
                fila.Cells.Add(celda)

                Me.grdPrestamos.Rows.Add(fila)

                grdPrestamos.DefaultCellStyle.BackColor = Color.LightYellow


            End If

        End If






    End Sub

    Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar.Click

        Dim contadorfilas As Integer = 0
        For Each row As DataGridView In grdPrestamos.Rows
            contadorfilas += 1
        Next
        If contadorfilas > 0 Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Esta seguro de querer pagar los préstamos?. "

            If mensajeExito.ShowDialog = DialogResult.OK Then
                guardarRecibido()

            End If
        End If

    End Sub


    Public Sub guardarRecibido()

        Dim objBU As New Nomina.Negocios.SolicitudPrestamoBU

        Dim ObjSolicitud As New Entidades.SolicitudPrestamo
        Dim ObjColaborador As New Entidades.Colaborador
        Dim idPrestamos As Integer = 0
        Dim recibido As Boolean
        Dim contadorTrue As Integer = 0

        If cmbEstatus.SelectedItem.Equals("ENVIADOS") Then

            For Each row As DataGridViewRow In grdPrestamos.Rows 'Recorro todo el grid fila por fila
                idPrestamos = row.Cells(0).Value

                recibido = row.Cells(8).Value

                If recibido = False Then
                    row.Cells(1).Style.BackColor = Color.LightYellow
                    row.Cells(2).Style.BackColor = Color.LightYellow
                    row.Cells(3).Style.BackColor = Color.LightYellow
                    row.Cells(4).Style.BackColor = Color.LightYellow
                    row.Cells(5).Style.BackColor = Color.LightYellow
                    row.Cells(6).Style.BackColor = Color.LightYellow
                    row.Cells(7).Style.BackColor = Color.LightYellow
                    row.Cells(8).Style.BackColor = Color.LightYellow
                Else

                    If recibido = True Then

                        row.Cells(1).Style.BackColor = Color.LightGreen
                        row.Cells(2).Style.BackColor = Color.LightGreen
                        row.Cells(3).Style.BackColor = Color.LightGreen
                        row.Cells(4).Style.BackColor = Color.LightGreen
                        row.Cells(5).Style.BackColor = Color.LightGreen
                        row.Cells(6).Style.BackColor = Color.LightGreen
                        row.Cells(7).Style.BackColor = Color.LightGreen
                        row.Cells(8).Style.BackColor = Color.LightGreen

                        ObjSolicitud.Pprestamoid = idPrestamos
                        ObjColaborador.PColaboradorid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        ObjSolicitud.Pestatus = "F"
                        ObjSolicitud.Pcolaborador = ObjColaborador

                        objBU.confirmacionPrestamoEnNave(ObjSolicitud)
                        contadorTrue += 1

                    End If


                End If

            Next
            If contadorTrue = 0 Then
                Dim mensajeExito2 As New AvisoForm
                mensajeExito2.MdiParent = Me.MdiParent
                mensajeExito2.mensaje = "Nesesita seleccionar minimo un prestamo"
                mensajeExito2.Show()
            Else
                Dim mensajeExito As New ExitoForm
                mensajeExito.MdiParent = Me.MdiParent
                mensajeExito.mensaje = "Guardado"
                mensajeExito.Show()
                grdPrestamos.Rows.Clear()

                llenarTablaConPrestamosAutorizados()

            End If

        End If

    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        grdPrestamos.Rows.Clear()
        llenarTablaConPrestamosAutorizados()
        Try
            If cmbEstatus.SelectedItem.Equals("PAGADOS") Then
                btnenviar.Enabled = False
                lblenviar.Enabled = False
            Else
                If cmbEstatus.SelectedItem.Equals("ENVIADOS") Then
                    btnenviar.Enabled = True
                    lblenviar.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        grdPrestamos.Rows.Clear()
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 117
    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()

    End Sub
End Class