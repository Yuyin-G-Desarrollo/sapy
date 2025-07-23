Imports System.Threading
Imports Tools

Public Class AutorizacionPrestamoForm
    Dim Autorizado As Double = 0

    Private Sub AutorizacionPrestamo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        Tools.FormatoCtrls.formato(Me)
        lblGerente.Visible = False
        lblDirector.Visible = False

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then

            'Entra si es gerente

            '' NavesUsuarioGerente()
            Controles.ComboNavesSegunUsuario(cmbNavesGerente, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

            If cmbNavesGerente.SelectedValue > 0 Then
                cmbNavesGerenteDrop()
            End If
            cmbEstatusGerente.Enabled = False
            cmbEstatusDirector.Visible = False
            cmbNaveDirector.Visible = False
            btnGuardarDirector.Visible = False
        ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then

            'Entra si es director

            ''NavesUsuarioDirector()
            Controles.ComboNavesSegunUsuario(cmbNaveDirector, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            If cmbNaveDirector.SelectedValue > 0 Then
                NavesDirectorDrop()
            End If

            cmbEstatusDirector.Enabled = False
            cmbEstatusGerente.Visible = False
            cmbNavesGerente.Visible = False
            btnGuardarGerente.Visible = False
        Else
            cmbEstatusDirector.Enabled = False
            cmbEstatusGerente.Enabled = False
            cmbNavesGerente.Enabled = False
            cmbNaveDirector.Enabled = False

            btnBuscar.Enabled = False
            btnGuardarDirector.Enabled = False
            btnGuardarGerente.Enabled = False
        End If

    End Sub

    ''METODO POARA GUARDAR
    Public Sub GuardarPrestamo()
        Dim objBU = New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjEnt = New Entidades.SolicitudPrestamo
        Dim idPrestamos As Integer = 0
        Dim contadorTrue As Integer = 0
        Dim Autorizo As Boolean
        Dim Rechazo As Boolean
        For Each row As DataGridViewRow In grdAutorizacion.Rows 'Recorro todo el grid fila por fila
            idPrestamos = row.Cells("clmidPrestamo").Value
            Autorizo = row.Cells("clmAutorizar").Value
            Rechazo = row.Cells("clmRechazar").Value

            If Autorizo = False And Rechazo = False Then
                row.Cells(1).Style.BackColor = Color.LightYellow
                row.Cells(2).Style.BackColor = Color.LightYellow
                row.Cells(3).Style.BackColor = Color.LightYellow
                row.Cells(4).Style.BackColor = Color.LightYellow
                row.Cells(5).Style.BackColor = Color.LightYellow
                row.Cells(6).Style.BackColor = Color.LightYellow
                row.Cells(7).Style.BackColor = Color.LightYellow
                row.Cells(8).Style.BackColor = Color.LightYellow
            Else

                If Autorizo = True Then
                    ObjEnt.Pestatus = "B"
                    row.Cells(1).Style.BackColor = Color.LightGreen
                    row.Cells(2).Style.BackColor = Color.LightGreen
                    row.Cells(3).Style.BackColor = Color.LightGreen
                    row.Cells(4).Style.BackColor = Color.LightGreen
                    row.Cells(5).Style.BackColor = Color.LightGreen
                    row.Cells(6).Style.BackColor = Color.LightGreen
                    row.Cells(7).Style.BackColor = Color.LightGreen
                    row.Cells(8).Style.BackColor = Color.LightGreen
                    contadorTrue += 1
                End If

                If Rechazo = True Then
                    ObjEnt.Pestatus = "J"
                    row.Cells(1).Style.BackColor = Color.Salmon
                    row.Cells(2).Style.BackColor = Color.Salmon
                    row.Cells(3).Style.BackColor = Color.Salmon
                    row.Cells(4).Style.BackColor = Color.Salmon
                    row.Cells(5).Style.BackColor = Color.Salmon
                    row.Cells(6).Style.BackColor = Color.Salmon
                    row.Cells(7).Style.BackColor = Color.Salmon
                    row.Cells(8).Style.BackColor = Color.Salmon
                    contadorTrue += 1
                End If

                ObjEnt.Pprestamoid = idPrestamos
                ObjEnt.PgerenteId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                objBU.guardarAutorizacionPrestamosGerente(ObjEnt)


            End If
        Next

        If contadorTrue = 0 Then
            Dim mensajeExito2 As New AvisoForm
            mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Debe seleccionar al menos un préstamo."
            mensajeExito2.Show()
        Else
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Prestamo guardado."
            mensajeExito.Show()
            enviar_correo(cmbNavesGerente.SelectedValue, "ENVIO_NOTIFICACION_AUTORIZACION_PRESTAMOS")
            grdAutorizacion.Rows.Clear()
            Autorizado = 0
            llenarTablaConPrestamosPorAutorizar()
            cmbEstatusGerente.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarGerente.Click
        Dim ContadorDefilas As Integer = 0
        For Each row As DataGridViewRow In grdAutorizacion.Rows
            ContadorDefilas += 1
        Next
        If ContadorDefilas = 0 Then

        Else
            GuardarPrestamo()
        End If
    End Sub

    ''--------------------------------------------------------------------------------
    ''LLENAR LAS NAVER POR USUARIO EN EL COMBO BOX
    Public Sub NavesUsuarioGerente()

        Dim objMotivosBU As New Nomina.Negocios.SolicitudPrestamoBU
        Dim tablaMotivos As New DataTable
        Dim IdColaborador As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        tablaMotivos = objMotivosBU.NavesColaborador(IdColaborador)
        tablaMotivos.Rows.InsertAt(tablaMotivos.NewRow, 0)
        With cmbNavesGerente
            .DisplayMember = "nave_nombre"
            .ValueMember = "nave_naveid"
            .DataSource = tablaMotivos
        End With
    End Sub
    ''--------------------------------------------------------------------------------

    ''LLENAR LA CONFIGURACION DE LOS PRESTAMOS
    Public Sub AgregarDatos(ByVal ConfiguracionPrestamos As Entidades.ConfiguracionPrestamos)
        Dim MaxNave = ConfiguracionPrestamos.PMontoMaximoPorNave
        lblGerente.Text = ConfiguracionPrestamos.PAutorizacionGerente
        lblDirector.Text = ConfiguracionPrestamos.PAutorizacionDirector
        If MaxNave = 0 Then
            lblMaximoPorNave2.Text = "Sin límite"
            lblDisponible2.Text = "Sin límite"
        Else
            lblMaximoPorNave2.Text = ConfiguracionPrestamos.PMontoMaximoPorNave.ToString("n2")
        End If
    End Sub

    Public Sub llenarconfiguracionPrestamo()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNavesGerente.SelectedValue))

            listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(idNave)

            For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
                AgregarDatos(objeto)
            Next

        Catch ex As Exception

        End Try

    End Sub
    ''--------------------------------------------------------------------------------

    ''LLENAR PRESTAMOS POR AUTORIZAR
    Public Sub llenarTablaConPrestamosPorAutorizar()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNavesGerente.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamos(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosPorAutorizar(objeto)

            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosPorAutorizar(ByVal Prestamos As Entidades.SolicitudPrestamo)


        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        Dim estatus As String
        estatus = Prestamos.Pestatus

        If estatus.Equals("A") Then

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pprestamoid
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = False
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = False
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pcolaborador.PNombre.ToUpper + " " + Prestamos.Pcolaborador.PApaterno.ToUpper + " " + Prestamos.Pcolaborador.PAmaterno.ToUpper
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
                celda.Value = "SIN INTERES"
                fila.Cells.Add(celda)

            Else
                If tipoInteres.Equals("F") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "INTERES FIJO"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("S") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES SOBRE SALDO"
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

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pjustificacion
            fila.Cells.Add(celda)

            Me.grdAutorizacion.Rows.Add(fila)
            grdAutorizacion.DefaultCellStyle.BackColor = Color.LightYellow
        End If

        If estatus.Equals("B") Then
            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
            Else
                Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
                lblDisponible2.Text = maximoNave.ToString("n2") - Autorizado.ToString("n2")
                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
            End If
        End If


        If estatus.Equals("C") And lblGerente.Text = True Then
            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
            Else
                Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
                lblDisponible2.Text = maximoNave.ToString("n2") - Autorizado.ToString("n2")
                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
            End If
        End If

    End Sub
    ''--------------------------------------------------------------------------------

    ''LLENAR PRESTAMOS RECHAZADOS
    Public Sub llenarTablaConPrestamosrechazados()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNavesGerente.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamos(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosRechazados(objeto)

            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosRechazados(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        Dim estatus As String
        estatus = Prestamos.Pestatus

        If estatus.Equals("J") Then

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pprestamoid
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = False
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = True
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pcolaborador.PNombre.ToUpper + " " + Prestamos.Pcolaborador.PApaterno.ToUpper + " " + Prestamos.Pcolaborador.PAmaterno.ToUpper
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
                celda.Value = "SIN INTERES"
                fila.Cells.Add(celda)

            Else
                If tipoInteres.Equals("F") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "INTERES FIJO"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("S") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES SOBRE SALDO"
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

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pjustificacion
            fila.Cells.Add(celda)

            Me.grdAutorizacion.Rows.Add(fila)

            grdAutorizacion.DefaultCellStyle.BackColor = Color.Salmon

        End If

        If estatus.Equals("B") Or (estatus.Equals("C") And lblGerente.Text = "True") Then
            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
            Else
                Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)

                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
                lblDisponible2.Text = maximoNave.ToString("n2") - Autorizado.ToString("n2")
                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
            End If
        End If

        For Each row As DataGridViewRow In grdAutorizacion.Rows
            row.Cells("clmAutorizar").ReadOnly = True
            row.Cells("clmRechazar").ReadOnly = True
        Next

    End Sub
    ''--------------------------------------------------------------------------------

    ''LLENAR PRESTAMOS AUTORIZADOS  
    Public Sub llenarTablaConPrestamosAutorizados()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNavesGerente.SelectedValue))
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

        If estatus.Equals("B") Then

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pprestamoid
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = True
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = False
            fila.Cells.Add(celda)

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pcolaborador.PNombre.ToUpper + " " + Prestamos.Pcolaborador.PApaterno.ToUpper + " " + Prestamos.Pcolaborador.PAmaterno.ToUpper
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
                celda.Value = "SIN INTERES"
                fila.Cells.Add(celda)

            Else
                If tipoInteres.Equals("F") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "INTERES FIJO"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("S") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES SOBRE SALDO"
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

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pjustificacion
            fila.Cells.Add(celda)

            Me.grdAutorizacion.Rows.Add(fila)

            grdAutorizacion.DefaultCellStyle.BackColor = Color.LightGreen

        End If

        If estatus.Equals("B") Or (estatus.Equals("C") And lblGerente.Text = "True") Then
            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
            Else
                Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)

                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
                lblDisponible2.Text = maximoNave.ToString("n2") - Autorizado.ToString("n2")
                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
            End If
        End If

    End Sub
    ''--------------------------------------------------------------------------------

    Private Sub cmbNavesGerente_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNavesGerente.DropDownClosed
        cmbNavesGerenteDrop()
    End Sub

    Private Sub grdAutorizacion_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAutorizacion.CellContentClick
        Dim SumaDePrestamosAutorizados As Double = Convert.ToDouble(lblAutorizado2.Text)
        Dim MaxPorNave As String = lblMaximoPorNave2.Text

        ''AUTORIZADOS POR GERENTE
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then

            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "B" Then

                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")

                                End If
                            Next

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR

                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                            End If

                        End If
                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then
                            Dim contadorDeTrue As Integer = 0

                            SumaDePrestamosAutorizados = 0

                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                        Else

                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            Dim contadorDeTrue As Integer = 0
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False

                                If lblAutorizado2.Text < 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = "Sin límite"
                                Else

                                    If row.Cells("clmAutorizar").Value = True Then
                                        SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                        lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                        contadorDeTrue += 1
                                    Else
                                        ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                        If contadorDeTrue = 0 Then
                                            lblAutorizado2.Text = 0.0
                                        End If
                                    End If
                                End If
                            Next

                            ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                        Else

                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                            ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then

                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")

                                End If
                            Next
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

                        Else

                            ''NAVE CON LIMITE open (SI DESACTIVA RECHAZAR)
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                            End If
                            ''NAVE CON LIMITE close (SI DESACTIVA RECHAZAR)
                        End If
                    End If
                End If
            End If
            ''-------------------HACIA ARRIBA---------VALIDACIONES DE PRESTAMOS AUTORIZADOS---------------------------------------------------

            ''-------------------HACIA ABAJO---------VALIDACIONES DE PRESTAMOS POR AUTORIZAR---------------------------------------------------

            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "A" Then

                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then
                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                End If
                            Next
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--CLOSE
                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                            If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            End If
                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE
                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--OPEN
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True

                                End If

                            End If
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--CLOSE
                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE
                        End If
                    End If
                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0

                            Dim contadorDeTrue As Integer = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next
                        Else
                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else
                                Dim contadorDeTrue As Integer = 0
                                SumaDePrestamosAutorizados = 0
                                For Each row As DataGridViewRow In grdAutorizacion.Rows
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False

                                    If lblAutorizado2.Text < 0 Then
                                        lblAutorizado2.Text = 0.0
                                        lblDisponible2.Text = "Sin límite"
                                    Else
                                        If row.Cells("clmAutorizar").Value = True Then
                                            SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                            contadorDeTrue += 1
                                        Else
                                            ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                            If contadorDeTrue = 0 Then
                                                lblAutorizado2.Text = 0.0
                                            End If
                                        End If
                                    End If
                                Next
                                ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                                End If
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE
                            End If
                        Else
                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else
                                If lblAutorizado2.Text <= 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = lblMaximoPorNave2.Text
                                Else
                                    SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                    ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                    If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                        grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                        grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                                    End If
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE
                                End If
                            End If
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then
                        Else
                        End If
                    End If
                End If
            End If
        End If
        '''''''''''''''ARRIBA VALIDACIONES DEL GERENTE
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''}'
        '''''''''''''''ABAJO VALIDACIONES DEL DIRECTOR
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then
            ''-------------------HACIA ABAJO---------VALIDACIONES DE PRESTAMOS POR AUTORIZAR---------------------------------------------------
            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "B" Or grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "A" Then
                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    'SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then

                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                End If
                            Next
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--CLOSE

                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                            If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True

                            End If
                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE
                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--OPEN
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else
                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True

                                End If

                            End If
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--CLOSE

                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE
                        End If
                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0

                            Dim contadorDeTrue As Integer = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next
                        Else
                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then
                            Else
                                Dim contadorDeTrue As Integer = 0
                                SumaDePrestamosAutorizados = 0
                                For Each row As DataGridViewRow In grdAutorizacion.Rows
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False

                                    If lblAutorizado2.Text < 0 Then
                                        lblAutorizado2.Text = 0.0
                                        lblDisponible2.Text = "Sin límite"
                                    Else
                                        If row.Cells("clmAutorizar").Value = True Then
                                            SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                            contadorDeTrue += 1
                                        Else
                                            ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                            If contadorDeTrue = 0 Then
                                                lblAutorizado2.Text = 0.0
                                            End If
                                        End If
                                    End If
                                Next
                                ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                                End If
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE
                            End If
                        Else
                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else
                                If lblAutorizado2.Text <= 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = lblMaximoPorNave2.Text
                                Else

                                    SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                    ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                    If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                        grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                        grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                                    End If
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE
                                End If
                            End If
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then
                        Else
                        End If
                    End If
                End If
            End If
            '''''''AUTORIZADOS POR DIRECTOR
            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "C" Then
                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")

                                End If
                            Next

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR

                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                            End If

                        End If
                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then
                            Dim contadorDeTrue As Integer = 0

                            SumaDePrestamosAutorizados = 0

                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                        Else

                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            Dim contadorDeTrue As Integer = 0
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False

                                If lblAutorizado2.Text < 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = "Sin límite"
                                Else

                                    If row.Cells("clmAutorizar").Value = True Then
                                        SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                        lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                        contadorDeTrue += 1
                                    Else
                                        ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                        If contadorDeTrue = 0 Then
                                            lblAutorizado2.Text = 0.0
                                        End If
                                    End If
                                End If
                            Next

                            ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                        Else
                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                            ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then

                        If MaxPorNave.Equals("Sin limite") Then
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                End If
                            Next
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

                        Else
                            ''NAVE CON LIMITE open (SI DESACTIVA RECHAZAR)
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                            End If
                            ''NAVE CON LIMITE close (SI DESACTIVA RECHAZAR)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdAutorizacion_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAutorizacion.CellContentDoubleClick
        Dim SumaDePrestamosAutorizados As Double = Convert.ToDouble(lblAutorizado2.Text)
        Dim MaxPorNave As String = lblMaximoPorNave2.Text

        ''AUTORIZADOS POR GERENTE
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then

            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "B" Then

                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")

                                End If
                            Next
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR

                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                            End If
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        End If

                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then
                            Dim contadorDeTrue As Integer = 0

                            SumaDePrestamosAutorizados = 0

                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        Else

                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True


                        End If
                        grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                        Thread.Sleep(500)
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            Dim contadorDeTrue As Integer = 0
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False


                                If lblAutorizado2.Text < 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = "Sin límite"
                                Else

                                    If row.Cells("clmAutorizar").Value = True Then
                                        SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                        lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                        contadorDeTrue += 1
                                    Else
                                        ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                        If contadorDeTrue = 0 Then
                                            lblAutorizado2.Text = 0.0
                                        End If
                                    End If
                                End If
                            Next

                            ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        Else

                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                            ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then

                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados

                                End If
                            Next
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        Else

                            ''NAVE CON LIMITE open (SI DESACTIVA RECHAZAR)
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                Thread.Sleep(500)
                            End If
                            ''NAVE CON LIMITE close (SI DESACTIVA RECHAZAR)
                        End If
                    End If
                End If
            End If
            ''-------------------HACIA ARRIBA---------VALIDACIONES DE PRESTAMOS AUTORIZADOS---------------------------------------------------


            ''-------------------HACIA ABAJO---------VALIDACIONES DE PRESTAMOS POR AUTORIZAR---------------------------------------------------

            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "A" Then

                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then
                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados

                                End If
                            Next
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--CLOSE

                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                            If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True

                            End If
                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE

                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--OPEN
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True

                                End If

                            End If
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--CLOSE

                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE

                        End If
                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0

                            Dim contadorDeTrue As Integer = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next

                        Else

                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else

                                Dim contadorDeTrue As Integer = 0
                                SumaDePrestamosAutorizados = 0
                                For Each row As DataGridViewRow In grdAutorizacion.Rows
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False


                                    If lblAutorizado2.Text < 0 Then
                                        lblAutorizado2.Text = 0.0
                                        lblDisponible2.Text = "Sin límite"
                                    Else

                                        If row.Cells("clmAutorizar").Value = True Then
                                            SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                            contadorDeTrue += 1
                                        Else
                                            ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                            If contadorDeTrue = 0 Then
                                                lblAutorizado2.Text = 0.0
                                            End If
                                        End If
                                    End If
                                Next

                                ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)

                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                                End If
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE
                            End If
                        Else
                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else
                                If lblAutorizado2.Text <= 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = lblMaximoPorNave2.Text
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                Else

                                    SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                    ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                    If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                        grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                        grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                                    End If
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE

                                End If
                            End If
                        End If
                        grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                        Thread.Sleep(500)
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then


                        If MaxPorNave.Equals("Sin límite") Then
                        Else
                        End If
                    End If
                End If
            End If


        End If
        '''''''''''''''ARRIBA VALIDACIONES DEL GERENTE
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''}'
        '''''''''''''''ABAJO VALIDACIONES DEL DIRECTOR
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then


            ''-------------------HACIA ABAJO---------VALIDACIONES DE PRESTAMOS POR AUTORIZAR---------------------------------------------------

            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "B" Or grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "A" Then


                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then
                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")

                                End If
                            Next

                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--CLOSE

                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                            If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                Thread.Sleep(500)
                            End If
                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE

                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--OPEN
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                    grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                    Thread.Sleep(500)
                                End If

                            End If
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR--CLOSE

                            ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA AUTORIZAR--CLOSE

                        End If
                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0

                            Dim contadorDeTrue As Integer = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)

                        Else

                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else

                                Dim contadorDeTrue As Integer = 0
                                SumaDePrestamosAutorizados = 0
                                For Each row As DataGridViewRow In grdAutorizacion.Rows
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False


                                    If lblAutorizado2.Text < 0 Then
                                        lblAutorizado2.Text = 0.0
                                        lblDisponible2.Text = "Sin límite"
                                    Else

                                        If row.Cells("clmAutorizar").Value = True Then
                                            SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                            contadorDeTrue += 1
                                        Else
                                            ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                            If contadorDeTrue = 0 Then
                                                lblAutorizado2.Text = 0.0
                                            End If
                                        End If
                                    End If
                                Next
                                grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                Thread.Sleep(500)
                                ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)

                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                    grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                    grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                                    grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                    Thread.Sleep(500)
                                End If
                                ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE
                            End If
                        Else
                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False Then

                            Else
                                If lblAutorizado2.Text <= 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = lblMaximoPorNave2.Text
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                Else

                                    SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                    ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--OPEN
                                    If grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True Then
                                        grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                        grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                                        grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                        Thread.Sleep(500)
                                    End If
                                    ''CAMBIE LA PALOMA DEL CHECK SI ACTIVA RECHAZAR--CLOSE

                                End If
                            End If
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then


                        If MaxPorNave.Equals("Sin límite") Then
                        Else
                        End If
                    End If
                End If
            End If

            '''''''AUTORIZADOS POR DIRECTOR

            If grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "C" Then

                ''SI DA CLIC EN ACEPTAR
                If e.ColumnIndex = Me.clmAutorizar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO ACEPTAR
                    If value = True Then
                        ''NAVE SIN LIMITE ''SI ACTIVO ACEPTAR
                        If MaxPorNave.Equals("Sin límite") Then

                            SumaDePrestamosAutorizados = 0
                            ''SI ACTIVO ACEPTAR NAVE SIN LIMITE--OPEN
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")

                                End If
                            Next

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        Else
                            ''NAVE CON LIMITE''SI ACTIVO ACEPTAR

                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

                                grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                Thread.Sleep(500)
                            End If

                        End If
                    End If

                    ''NAVE SIN LIMITE'  ''SI DESACTIVO ACEPTAR
                    If value = False Then
                        If MaxPorNave.Equals("Sin límite") Then
                            Dim contadorDeTrue As Integer = 0

                            SumaDePrestamosAutorizados = 0

                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                    contadorDeTrue += 1
                                Else
                                    'SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                    If contadorDeTrue = 0 Then
                                        lblAutorizado2.Text = 0.0
                                    End If
                                End If
                            Next
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True
                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        Else

                            ''NAVE CON LIMITE SI DESACTIVO ACEPTAR 
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                        End If
                    End If
                End If
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                ''---------------------------SI DA CLICK EN RECHAZAR------------------------------------
                If e.ColumnIndex = Me.clmRechazar.Index Then
                    Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

                    ''SI ACTIVO RECHAZAR
                    If value = True Then
                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            ''NAVE SIN LIMITE open (SI ACTIVO RECHAZAR)
                            Dim contadorDeTrue As Integer = 0
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False


                                If lblAutorizado2.Text < 0 Then
                                    lblAutorizado2.Text = 0.0
                                    lblDisponible2.Text = "Sin límite"
                                Else

                                    If row.Cells("clmAutorizar").Value = True Then
                                        SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                        lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                        contadorDeTrue += 1
                                    Else
                                        ''SI TODOS LOS CHECK ESTAN DESACTIVADOS
                                        If contadorDeTrue = 0 Then
                                            lblAutorizado2.Text = 0.0
                                        End If
                                    End If
                                End If
                            Next

                            ''NAVE SIN LIMITE close (SI ACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)

                        Else

                            ''NAVE CON LIMITE open (SI ACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados -= grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                            lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                            lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)
                            ''NAVE CON LIMITE close (SI ACTIVO RECHAZAR)
                        End If
                    End If

                    ''SI DESACTIVO RECHAZAR
                    If value = False Then

                        If MaxPorNave.Equals("Sin límite") Then
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)
                            SumaDePrestamosAutorizados = 0
                            For Each row As DataGridViewRow In grdAutorizacion.Rows
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                If row.Cells("clmAutorizar").Value = True Then
                                    SumaDePrestamosAutorizados += row.Cells("clmMonto").Value
                                    lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                End If
                            Next
                            ''NAVE SIN LIMITE open (SI DESACTIVO RECHAZAR)

                            ''LOS QUE ACTIVAN Y DESACTIVAN
                            grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                            grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

                            grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                            Thread.Sleep(500)

                        Else
                            ''NAVE CON LIMITE open (SI DESACTIVA RECHAZAR)
                            SumaDePrestamosAutorizados += grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                            If SumaDePrestamosAutorizados > lblMaximoPorNave2.Text Then
                                Dim mensajeExito As New AvisoForm
                                mensajeExito.MdiParent = Me.MdiParent
                                mensajeExito.mensaje = "Ha alcanzado el monto límite para préstamos de la nave."
                                mensajeExito.Show()
                                grdAutorizacion.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
                            Else

                                lblAutorizado2.Text = SumaDePrestamosAutorizados.ToString("n2")
                                lblDisponible2.Text = lblMaximoPorNave2.Text - lblAutorizado2.Text
                                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                                ''LOS QUE ACTIVAN Y DESACTIVAN
                                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

                                grdAutorizacion.CurrentCell = grdAutorizacion.Item(7, 0) ''Cambia el foto del dataGrid
                                Thread.Sleep(500)
                            End If
                            ''NAVE CON LIMITE close (SI DESACTIVA RECHAZAR)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdAutorizacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAutorizacion.CellDoubleClick

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''OTRO COTORREO PARA EDITAR UN PRESTAMO'''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''PARA QUE UN GERENTE EDITE UN PRESTAMO
        If e.ColumnIndex = Me.clmColaborador.Index And grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "A" And lblGerente.Text = "True" Then
            Dim EditarPrestamosForm As New EditarPrestamoForm

            Dim EditarPrestamosEntidad As New Entidades.SolicitudPrestamo

            EditarPrestamosForm.PrestamoEditar = grdAutorizacion.CurrentRow.Cells("clmidPrestamo").Value
            EditarPrestamosForm.ColaboradorEditar = grdAutorizacion.CurrentRow.Cells("clmidColaborador").Value
            EditarPrestamosForm.MontoEditar = grdAutorizacion.CurrentRow.Cells("clmMonto").Value
            EditarPrestamosForm.abonoEditar = grdAutorizacion.CurrentRow.Cells("clmAbono").Value
            EditarPrestamosForm.semanasEditar = grdAutorizacion.CurrentRow.Cells("clmSemanas").Value
            EditarPrestamosForm.TipoDeInteresEditar = grdAutorizacion.CurrentRow.Cells("clmTipoInteres").Value
            EditarPrestamosForm.TasaDeInteresEditar = grdAutorizacion.CurrentRow.Cells("clmTasaDeInteres").Value
            EditarPrestamosForm.justificacionEditar = grdAutorizacion.CurrentRow.Cells("clmjustificacion").Value

            EditarPrestamosForm.IndiceNave = cmbNavesGerente.SelectedIndex
            EditarPrestamosForm.IndiceEstatus = cmbEstatusGerente.SelectedIndex

            If EditarPrestamosForm.ShowDialog = DialogResult.OK Then
                grdAutorizacion.Rows.Clear()
                llenarTablaConPrestamosPorAutorizar()
            End If

        Else

            'DIRECTOR EDITA PRESTAMO SI NO HAY GERENTE OPEN
            If e.ColumnIndex = Me.clmColaborador.Index And lblGerente.Text = "False" And grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "A" Then
                Dim EditarPrestamosForm As New EditarPrestamoForm

                Dim EditarPrestamosEntidad As New Entidades.SolicitudPrestamo

                EditarPrestamosForm.PrestamoEditar = grdAutorizacion.CurrentRow.Cells("clmidPrestamo").Value
                EditarPrestamosForm.ColaboradorEditar = grdAutorizacion.CurrentRow.Cells("clmidColaborador").Value
                EditarPrestamosForm.MontoEditar = grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                EditarPrestamosForm.abonoEditar = grdAutorizacion.CurrentRow.Cells("clmAbono").Value
                EditarPrestamosForm.semanasEditar = grdAutorizacion.CurrentRow.Cells("clmSemanas").Value
                EditarPrestamosForm.TipoDeInteresEditar = grdAutorizacion.CurrentRow.Cells("clmTipoInteres").Value
                EditarPrestamosForm.TasaDeInteresEditar = grdAutorizacion.CurrentRow.Cells("clmTasaDeInteres").Value
                EditarPrestamosForm.justificacionEditar = grdAutorizacion.CurrentRow.Cells("clmjustificacion").Value

                EditarPrestamosForm.IndiceNave = cmbNavesGerente.SelectedIndex
                EditarPrestamosForm.IndiceEstatus = cmbEstatusGerente.SelectedIndex

                If EditarPrestamosForm.ShowDialog = DialogResult.OK Then
                    grdAutorizacion.Rows.Clear()
                    llenarTablaConPrestamosPorAutorizarDirector()
                End If
                ' Me.Close()

            Else
                'DIRECTOR EDITA PRESTAMO SI NO HAY GERENTE CLOSE

                'DIRECTOR EDITA PRESTAMO SI HAY GERENTE OPEN
                If e.ColumnIndex = Me.clmColaborador.Index And lblGerente.Text = "True" And grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "B" Then
                    Dim EditarPrestamosForm As New EditarPrestamoForm
                    Dim EditarPrestamosEntidad As New Entidades.SolicitudPrestamo

                    EditarPrestamosForm.PrestamoEditar = grdAutorizacion.CurrentRow.Cells("clmidPrestamo").Value
                    EditarPrestamosForm.ColaboradorEditar = grdAutorizacion.CurrentRow.Cells("clmidColaborador").Value
                    EditarPrestamosForm.MontoEditar = grdAutorizacion.CurrentRow.Cells("clmMonto").Value
                    EditarPrestamosForm.abonoEditar = grdAutorizacion.CurrentRow.Cells("clmAbono").Value
                    EditarPrestamosForm.semanasEditar = grdAutorizacion.CurrentRow.Cells("clmSemanas").Value
                    EditarPrestamosForm.TipoDeInteresEditar = grdAutorizacion.CurrentRow.Cells("clmTipoInteres").Value
                    EditarPrestamosForm.TasaDeInteresEditar = grdAutorizacion.CurrentRow.Cells("clmTasaDeInteres").Value
                    EditarPrestamosForm.justificacionEditar = grdAutorizacion.CurrentRow.Cells("clmjustificacion").Value

                    EditarPrestamosForm.IndiceNave = cmbNavesGerente.SelectedIndex
                    EditarPrestamosForm.IndiceEstatus = cmbEstatusGerente.SelectedIndex

                    If EditarPrestamosForm.ShowDialog = DialogResult.OK Then
                        grdAutorizacion.Rows.Clear()
                        llenarTablaConPrestamosPorAutorizarDirector()
                    End If
                    'DIRECTOR EDITA PRESTAMO SI NO HAY GERENTE CLOSE
                End If
            End If
        End If
    End Sub

    ''EL COTORREO DEL DIRECTOR--------------------------------------------
    ''EL COTORREO DEL DIRECTOR--------------------------------------------
    ''EL COTORREO DEL DIRECTOR--------------------------------------------
    ''EL COTORREO DEL DIRECTOR--------------------------------------------

    Public Sub NavesUsuarioDirector()

        Dim objMotivosBU As New Nomina.Negocios.SolicitudPrestamoBU
        Dim tablaMotivos As New DataTable
        Dim IdColaborador As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        tablaMotivos = objMotivosBU.NavesColaborador(IdColaborador)
        tablaMotivos.Rows.InsertAt(tablaMotivos.NewRow, 0)
        With cmbNaveDirector
            .DisplayMember = "nave_nombre"
            .ValueMember = "nave_naveid"
            .DataSource = tablaMotivos
        End With
    End Sub

    Public Sub llenarconfiguracionPrestamoDirector()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.ConfiguracionPrestamos)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNaveDirector.SelectedValue))

            listaConfiguracionPrestamos = prestamosBU.ListaConfiguracionPrestamos(idNave)

            For Each objeto As Entidades.ConfiguracionPrestamos In listaConfiguracionPrestamos
                AgregarDatos(objeto)
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbNaveDirector_DropDownClosed1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNaveDirector.DropDownClosed
        NavesDirectorDrop()
    End Sub

    ''LLENAR PRESTAMOS POR AUTORIZAR
    Public Sub llenarTablaConPrestamosPorAutorizarDirector()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNaveDirector.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamos(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosPorAutorizarDirector(objeto)

            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosPorAutorizarDirector(ByVal Prestamos As Entidades.SolicitudPrestamo)
        If lblGerente.Text = "True" Then

            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow

            Dim tipoInteres As String
            tipoInteres = Prestamos.Ptipointeres

            Dim estatus As String
            estatus = Prestamos.Pestatus

            If estatus.Equals("B") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
                fila.Cells.Add(celda)

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
                fila.Cells.Add(celda)

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
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
                    celda.Value = "SIN INTERES"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES FIJO"
                        fila.Cells.Add(celda)

                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "INTERES SOBRE SALDO"
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

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pjustificacion
                fila.Cells.Add(celda)

                Me.grdAutorizacion.Rows.Add(fila)
                grdAutorizacion.DefaultCellStyle.BackColor = Color.LightYellow
            End If

            If estatus.Equals("C") Then
                If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                    Autorizado += Prestamos.Psaldo
                    lblAutorizado2.Text = Autorizado.ToString("n2")
                Else
                    Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)
                    Autorizado += Prestamos.Psaldo
                    lblAutorizado2.Text = Autorizado.ToString("n2")
                    lblDisponible2.Text = maximoNave - Autorizado.ToString("n2")
                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                End If
            End If
        End If

        If lblGerente.Text = "False" Then

            Dim celda As DataGridViewCell
            Dim fila As New DataGridViewRow

            Dim tipoInteres As String
            tipoInteres = Prestamos.Ptipointeres

            Dim estatus As String
            estatus = Prestamos.Pestatus

            If estatus.Equals("B") Or estatus.Equals("A") Then

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pprestamoid
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
                    celda.Value = "SIN INTERES"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("F") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES FIJO"
                        fila.Cells.Add(celda)

                    Else
                        If tipoInteres.Equals("S") Then
                            celda = New DataGridViewTextBoxCell
                            celda.Value = "INTERES SOBRE SALDO"
                            fila.Cells.Add(celda)
                        End If
                    End If
                End If

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
                fila.Cells.Add(celda)

                celda = New DataGridViewCheckBoxCell
                celda.Value = False
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pestatus
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pcolaborador.PColaboradorid
                fila.Cells.Add(celda)

                celda = New DataGridViewTextBoxCell
                celda.Value = Prestamos.Pjustificacion
                fila.Cells.Add(celda)

                Me.grdAutorizacion.Rows.Add(fila)
                grdAutorizacion.DefaultCellStyle.BackColor = Color.LightYellow
            End If

            If estatus.Equals("C") Then
                If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                    Autorizado += Prestamos.Psaldo
                    lblAutorizado2.Text = Autorizado.ToString("n2")
                Else
                    Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)
                    Autorizado += Prestamos.Psaldo
                    lblAutorizado2.Text = Autorizado.ToString("n2")
                    lblDisponible2.Text = maximoNave - Autorizado.ToString("n2")
                    lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
                End If
            End If
        End If

    End Sub
    ''--------------------------------------------------------------------------------

    ''LLENAR PRESTAMOS RECHAZADOS
    Public Sub llenarTablaConPrestamosrechazadosDirector()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNaveDirector.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamos(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosRechazadosDirector(objeto)

            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosRechazadosDirector(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        Dim estatus As String
        estatus = Prestamos.Pestatus

        If estatus.Equals("K") Then

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pprestamoid
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = False
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = True
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
                celda.Value = "SIN INTERES"
                fila.Cells.Add(celda)

            Else
                If tipoInteres.Equals("F") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "INTERES FIJO"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("S") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES SOBRE SALDO"
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

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pjustificacion
            fila.Cells.Add(celda)

            Me.grdAutorizacion.Rows.Add(fila)

            grdAutorizacion.DefaultCellStyle.BackColor = Color.Salmon

        End If

        If estatus.Equals("C") Then
            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
            Else
                Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)

                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
                lblDisponible2.Text = maximoNave - Autorizado.ToString("n2")
                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
            End If
        End If

        For Each row As DataGridViewRow In grdAutorizacion.Rows
            row.Cells("clmAutorizar").ReadOnly = True
            row.Cells("clmRechazar").ReadOnly = True
        Next
    End Sub
    ''--------------------------------------------------------------------------------

    ''LLENAR PRESTAMOS AUTORIZADOS  
    Public Sub llenarTablaConPrestamosAutorizadosDirector()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNaveDirector.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamos(idNave)

            For Each objeto As Entidades.SolicitudPrestamo In listaConfiguracionPrestamos
                AgregarFilaDePrestamosAutorizadosDirector(objeto)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Public Sub AgregarFilaDePrestamosAutorizadosDirector(ByVal Prestamos As Entidades.SolicitudPrestamo)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        Dim tipoInteres As String
        tipoInteres = Prestamos.Ptipointeres

        Dim estatus As String
        estatus = Prestamos.Pestatus

        If estatus.Equals("C") Then

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pprestamoid
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = True
            fila.Cells.Add(celda)

            celda = New DataGridViewCheckBoxCell
            celda.Value = False
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
                celda.Value = "SIN INTERES"
                fila.Cells.Add(celda)

            Else
                If tipoInteres.Equals("F") Then
                    celda = New DataGridViewTextBoxCell
                    celda.Value = "INTERES FIJO"
                    fila.Cells.Add(celda)

                Else
                    If tipoInteres.Equals("S") Then
                        celda = New DataGridViewTextBoxCell
                        celda.Value = "INTERES SOBRE SALDO"
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

            celda = New DataGridViewTextBoxCell
            celda.Value = Prestamos.Pjustificacion
            fila.Cells.Add(celda)

            Me.grdAutorizacion.Rows.Add(fila)

            grdAutorizacion.DefaultCellStyle.BackColor = Color.LightGreen

        End If

        If estatus.Equals("C") Then
            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
            Else
                Dim maximoNave As Double = Convert.ToDouble(lblMaximoPorNave2.Text)

                Autorizado += Prestamos.Psaldo
                lblAutorizado2.Text = Autorizado.ToString("n2")
                lblDisponible2.Text = maximoNave - Autorizado.ToString("n2")
                lblDisponible2.Text = FormatNumber(lblDisponible2.Text, 2)
            End If
        End If
    End Sub
    ''--------------------------------------------------------------------------------

    Private Sub btnGuardarDirector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarDirector.Click
        Dim ContadorDefilas As Integer = 0
        For Each row As DataGridViewRow In grdAutorizacion.Rows
            ContadorDefilas += 1
        Next
        If ContadorDefilas = 0 Then

        Else
            GuardarPrestamoDirector()
        End If
    End Sub

    Public Sub GuardarPrestamoDirector()
        Dim objBU As New Nomina.Negocios.SolicitudPrestamoBU
        Dim ObjSolicitud As New Entidades.SolicitudPrestamo
        Dim idPrestamos As Integer = 0
        Dim contadorTrue As Integer = 0
        Dim Autorizo As Boolean
        Dim Rechazo As Boolean
        For Each row As DataGridViewRow In grdAutorizacion.Rows 'Recorro todo el grid fila por fila
            idPrestamos = row.Cells("clmidPrestamo").Value
            Autorizo = row.Cells("clmAutorizar").Value
            Rechazo = row.Cells("clmRechazar").Value


            If Autorizo = False And Rechazo = False Then
                row.Cells(1).Style.BackColor = Color.LightYellow
                row.Cells("clmMonto").Style.BackColor = Color.LightYellow
                row.Cells(3).Style.BackColor = Color.LightYellow
                row.Cells(4).Style.BackColor = Color.LightYellow
                row.Cells(5).Style.BackColor = Color.LightYellow
                row.Cells(6).Style.BackColor = Color.LightYellow
                row.Cells(7).Style.BackColor = Color.LightYellow
                row.Cells("clmRechazar").Style.BackColor = Color.LightYellow
            Else

                If Autorizo = True Then
                    ObjSolicitud.Pestatus = "C"

                    row.Cells(1).Style.BackColor = Color.LightGreen
                    row.Cells("clmMonto").Style.BackColor = Color.LightGreen
                    row.Cells(3).Style.BackColor = Color.LightGreen
                    row.Cells(4).Style.BackColor = Color.LightGreen
                    row.Cells(5).Style.BackColor = Color.LightGreen
                    row.Cells(6).Style.BackColor = Color.LightGreen
                    row.Cells(7).Style.BackColor = Color.LightGreen
                    row.Cells("clmRechazar").Style.BackColor = Color.LightGreen
                    contadorTrue += 1
                End If

                If Rechazo = True Then
                    ObjSolicitud.Pestatus = "K"

                    row.Cells(1).Style.BackColor = Color.Salmon
                    row.Cells("clmMonto").Style.BackColor = Color.Salmon
                    row.Cells(3).Style.BackColor = Color.Salmon
                    row.Cells(4).Style.BackColor = Color.Salmon
                    row.Cells(5).Style.BackColor = Color.Salmon
                    row.Cells(6).Style.BackColor = Color.Salmon
                    row.Cells(7).Style.BackColor = Color.Salmon
                    row.Cells("clmRechazar").Style.BackColor = Color.Salmon
                    contadorTrue += 1
                End If
                ObjSolicitud.Pprestamoid = idPrestamos

                ObjSolicitud.PdirectorId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                objBU.guardarAutorizacionPrestamosDirector(ObjSolicitud)
            End If

        Next
        If contadorTrue = 0 Then
            Dim mensajeExito2 As New AvisoForm
            mensajeExito2.MdiParent = Me.MdiParent
            mensajeExito2.mensaje = "Debe seleccionar al menos un préstamo."
            mensajeExito2.Show()
        Else
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Prestamo guardado"
            mensajeExito.Show()
            enviar_correo(cmbNavesGerente.SelectedValue, "ENVIO_NOTIFICACION_AUTORIZACION_PRESTAMOS")
            grdAutorizacion.Rows.Clear()
            Autorizado = 0
            llenarTablaConPrestamosPorAutorizar()
            cmbEstatusGerente.SelectedIndex = 0
        End If
    End Sub


    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 110
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then
            Try

                Dim EstatusCombo As String
                EstatusCombo = cmbEstatusGerente.SelectedItem.ToString

                grdAutorizacion.Rows.Clear()
                lblAutorizado2.Text = 0.0
                lblDisponible2.Text = 0.0
                Autorizado = 0


                If EstatusCombo.Equals("RECHAZADOS") Then

                    llenarconfiguracionPrestamo()
                    llenarTablaConPrestamosrechazados()

                End If

                If EstatusCombo.Equals("AUTORIZADOS") Then

                    llenarconfiguracionPrestamo()
                    llenarTablaConPrestamosAutorizados()

                End If

                If EstatusCombo.Equals("POR AUTORIZAR") Then
                    llenarconfiguracionPrestamo()
                    llenarTablaConPrestamosPorAutorizar()

                End If

                'If EstatusCombo.Equals("Todos") Then
                '    llenarTablaConPrestamosTodos()
                'End If

            Catch ex As Exception
            End Try

            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin límite"

            End If
        End If

        'Entra si es director
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then

            Try
                Dim EstatusCombo As String
                EstatusCombo = cmbEstatusDirector.SelectedItem.ToString

                grdAutorizacion.Rows.Clear()
                lblAutorizado2.Text = 0.0
                lblDisponible2.Text = 0.0
                Autorizado = 0

                If EstatusCombo.Equals("RECHAZADOS") Then

                    llenarTablaConPrestamosrechazadosDirector()
                End If

                If EstatusCombo.Equals("AUTORIZADOS") Then

                    llenarTablaConPrestamosAutorizadosDirector()
                End If

                If EstatusCombo.Equals("POR AUTORIZAR") Then

                    llenarTablaConPrestamosPorAutorizarDirector()
                End If
            Catch ex As Exception

            End Try

            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin límite"

            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Public Sub NavesDirectorDrop()
        Try
            If lblMaximoPorNave2.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin Límite"
            Else
                lblDisponible2.Text = 0.0
            End If

            lblMaximoPorNave2.Text = 0.0
            lblAutorizado2.Text = 0.0

            llenarconfiguracionPrestamoDirector()
            grdAutorizacion.Rows.Clear()
            cmbEstatusDirector.SelectedIndex = 0
            Autorizado = 0
            llenarTablaConPrestamosPorAutorizarDirector()

            cmbEstatusDirector.Enabled = True

        Catch ex As Exception
            grdAutorizacion.Rows.Clear()
            lblAutorizado2.Text = 0.0
            If lblMaximoPorNave2.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin Límite"
            Else
                lblDisponible2.Text = 0.0
            End If
        End Try

        Try
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then
                If lblGerente.Text = False Then
                    cmbEstatusGerente.Enabled = False
                    grdAutorizacion.Rows.Clear()
                End If
                If lblGerente.Text = True Then
                    cmbEstatusGerente.Enabled = True
                End If

            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then
                If lblDirector.Text = False Then
                    cmbEstatusDirector.Enabled = False
                    grdAutorizacion.Rows.Clear()
                End If
                If lblDirector.Text = True Then
                    cmbEstatusDirector.Enabled = True
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub cmbNavesGerenteDrop()
        Try
            If lblMaximoPorNave2.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin Límite"
            Else
                lblDisponible2.Text = 0.0
            End If

            lblMaximoPorNave2.Text = 0.0
            lblAutorizado2.Text = 0.0

            llenarconfiguracionPrestamo()
            grdAutorizacion.Rows.Clear()
            cmbEstatusGerente.SelectedIndex = 0
            Autorizado = 0
            llenarTablaConPrestamosPorAutorizar()

            cmbEstatusGerente.Enabled = True

        Catch ex As Exception
            grdAutorizacion.Rows.Clear()
            lblAutorizado2.Text = 0.0
            If lblMaximoPorNave2.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin Límite"
            Else
                lblDisponible2.Text = 0.0
            End If
        End Try

        Try


            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then
                If lblGerente.Text = False Then
                    cmbEstatusGerente.Visible = False
                    grdAutorizacion.Rows.Clear()
                End If
                If lblGerente.Text = True Then
                    cmbEstatusGerente.Visible = True
                End If

            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then
                If lblDirector.Text = False Then
                    cmbEstatusDirector.Visible = False
                    grdAutorizacion.Rows.Clear()
                End If
                If lblDirector.Text = True Then
                    cmbEstatusDirector.Visible = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub pnlMinimizarParametros_Paint(sender As Object, e As PaintEventArgs) Handles pnlMinimizarParametros.Paint

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "GERENTE") Then
            Try

                Dim EstatusCombo As String
                EstatusCombo = cmbEstatusGerente.SelectedItem.ToString

                grdAutorizacion.Rows.Clear()
                lblAutorizado2.Text = 0.0
                lblDisponible2.Text = 0.0
                Autorizado = 0


                If EstatusCombo.Equals("RECHAZADOS") Then

                    llenarconfiguracionPrestamo()
                    llenarTablaConPrestamosrechazados()

                End If

                If EstatusCombo.Equals("AUTORIZADOS") Then

                    llenarconfiguracionPrestamo()
                    llenarTablaConPrestamosAutorizados()

                End If

                If EstatusCombo.Equals("POR AUTORIZAR") Then
                    llenarconfiguracionPrestamo()
                    llenarTablaConPrestamosPorAutorizar()

                End If

                'If EstatusCombo.Equals("Todos") Then
                '    llenarTablaConPrestamosTodos()
                'End If

            Catch ex As Exception
            End Try

            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin límite"

            End If
        End If

        'Entra si es director
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("NOM_PRES_AUT", "DIRECTOR") Then

            Try
                Dim EstatusCombo As String
                EstatusCombo = cmbEstatusDirector.SelectedItem.ToString

                grdAutorizacion.Rows.Clear()
                lblAutorizado2.Text = 0.0
                lblDisponible2.Text = 0.0
                Autorizado = 0

                If EstatusCombo.Equals("RECHAZADOS") Then

                    llenarTablaConPrestamosrechazadosDirector()
                End If

                If EstatusCombo.Equals("AUTORIZADOS") Then

                    llenarTablaConPrestamosAutorizadosDirector()
                End If

                If EstatusCombo.Equals("POR AUTORIZAR") Then

                    llenarTablaConPrestamosPorAutorizarDirector()
                End If
            Catch ex As Exception

            End Try

            If lblMaximoPorNave2.Text.Equals("Sin límite") Then
                lblDisponible2.Text = "Sin límite"

            End If
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdAutorizacion.Rows.Clear()
    End Sub

    Private Sub enviar_correo(ByVal naveID As Integer, ByVal clave As String)

        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim destinatarios As String
        Dim correo As New Tools.Correo
        Dim fecha As DateTime = Now.Date
        destinatarios = enviosCorreoBU.consulta_destinatarios_email(naveID, clave)

        Dim Email As String = ""
        Email += " <!DOCTYPE html>"
        Email += " <html>  "
        Email += " <head>  "
        Email += " <style> "
        Email += " #Header{"
        Email += " color:#003366;"
        Email += " font-family: Arial, Helvetica, sans-serif;"
        Email += " }"
        Email += " table, th, td { border: 1px solid black; text-align: center; } "
        Email += " th{ background-color:#003366; "
        Email += " color:#FFFFFF; "
        Email += " font-weight:bold;"
        Email += " height:30px;"
        Email += " font-size:10px;"
        Email += " font-family: Arial, Helvetica, sans-serif;"
        Email += " text-align: center; "
        Email += " } "
        Email += " td{ "
        Email += " font-family: Arial, Helvetica, sans-serif; "
        Email += " text-align: center; "
        Email += " color:#003363;"
        Email += " font-size:10px;"
        Email += " font-weight:bold;"
        Email += " } "
        Email += " </style>"
        Email += " <div id='Header'>"
        Email += " <img src='" + "http://grupoyuyin.com.mx/images/SAY170.jpg" + "' height='" + "60" + "' width='" + "60" + "'alt='" + "logo" + "'>"
        Email += " <h1>"
        Email += " <strong>"
        Email += " Pr&eacute;stamos autorizados."
        Email += " </strong>"
        Email += " </h1>"
        Email += "<h5>Usuario autorizó: " + Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString + " <h5>"
        Email += "<h5>Fecha creación: " + Now.Date.ToLongDateString + "<h5>"
        Email += " </div>"
        Email += " </head>"
        Email += "<body>"
        Email += "<table style='border:1px;'>"
        Email += "<thead>"
        Email += "<tr>"
        Email += "<th>"
        Email += "Colaborador"
        Email += "</th>"
        Email += "<th>"
        Email += "Monto autorizado"
        Email += "</th>"
        Email += "</tr>"
        Email += "</thead>"
        Email += "<tbody>"
        For Each row As DataGridViewRow In grdAutorizacion.Rows
            If row.Cells("clmAutorizar").Value = True Then
                Email += "<tr>"
                Email += "<td>"
                Email += row.Cells("clmColaborador").Value
                Email += "</td>"
                Email += "<td>$"
                Email += CStr(row.Cells("clmMonto").Value).ToString()
                Email += ".00</td>"
                Email += "</tr>"
            End If
        Next
        Email += "</tbody>"
        Email += "</table>"
        Email += "</body> "
        Email += "</html> "
        correo.EnviarCorreoHtml(destinatarios, "say_nomina@grupoyuyin.com.mx", "Autorizacion de prestamo", Email)

    End Sub
End Class