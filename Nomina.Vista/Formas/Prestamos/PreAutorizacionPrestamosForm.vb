Imports Tools

Public Class PreAutorizacionPrestamosForm

    Private Sub PreAutorizacionPrestamosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        LlenarPrestamos()
    End Sub

    Private Sub grdAutorizacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdAutorizacion.CellContentClick

        ''SI DA CLIC EN ACEPTAR
        If e.ColumnIndex = Me.clmAutorizar.Index Then
            Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

            ''SI ACTIVO ACEPTAR
            If value = True Then
                ''LOS QUE ACTIVAN Y DESACTIVAN
                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = True
                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = False

            End If
        End If

        If e.ColumnIndex = Me.clmRechazar.Index Then
            Dim value As Boolean = CType(Me.grdAutorizacion.CurrentCell.EditedFormattedValue, Boolean)

            ''SI ACTIVO rechazar
            If value = True Then
                ''LOS QUE ACTIVAN Y DESACTIVAN
                grdAutorizacion.CurrentRow.Cells("clmAutorizar").Value = False
                grdAutorizacion.CurrentRow.Cells("clmRechazar").Value = True

            End If
        End If


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cmbEstatus.Text = "POR AUTORIZAR" Then
            GuardarPrestamo()
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

            Else

                If Autorizo = True Then
                    ObjEnt.Pestatus = "A"

                    contadorTrue += 1
                End If

                If Rechazo = True Then
                    ObjEnt.Pestatus = "I"

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
            mensajeExito2.ShowDialog()
        Else
            Dim mensajeExito As New ExitoForm
            '  mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Préstamos guardados."
            mensajeExito.ShowDialog()
            grdAutorizacion.Rows.Clear()

        End If
    End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdAutorizacion.Rows.Clear()
        btnGuardar.Enabled = True
        cmbEstatus.SelectedIndex = 0
    End Sub

    Private Sub grdAutorizacion_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdAutorizacion.CellDoubleClick

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''OTRO COTORREO PARA EDITAR UN PRESTAMO'''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''PARA QUE UN GERENTE EDITE UN PRESTAMO
        If e.ColumnIndex = Me.clmColaborador.Index And grdAutorizacion.CurrentRow.Cells("clmestatus").Value = "P" Then
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

            EditarPrestamosForm.IndiceNave = cmbNave.SelectedIndex
            EditarPrestamosForm.IndiceEstatus = cmbEstatus.SelectedIndex

            If EditarPrestamosForm.ShowDialog = DialogResult.OK Then
                grdAutorizacion.Rows.Clear()
                LlenarPrestamos()
            End If
        End If


    End Sub

    Public Sub LlenarPrestamos()
        grdAutorizacion.Rows.Clear()
        If cmbNave.Text <> "" And cmbEstatus.Text <> "" Then
            lblNave.ForeColor = Color.Black
            lblEstatus.ForeColor = Color.Black
            Dim NaveID As Integer = 0

            Dim EstatusBolAU As Boolean = False
            Dim EstatusBolRE As Boolean = False
            Dim Estatus As String = ""
            Dim TipoInteres As String = ""
            Dim listaPresolicitudesPrestamo As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU

            NaveID = (Int(cmbNave.SelectedValue))

            If cmbEstatus.Text = "RECHAZADOS" Then
                Estatus = "I"
                EstatusBolRE = True
                btnGuardar.Enabled = False
            ElseIf cmbEstatus.Text = "AUTORIZADOS" Then
                Estatus = "A"
                btnGuardar.Enabled = False
                EstatusBolAU = True
            ElseIf cmbEstatus.Text = "POR AUTORIZAR" Then
                Estatus = "P"
                btnGuardar.Enabled = True
                EstatusBolAU = False
                EstatusBolRE = False
            End If
            listaPresolicitudesPrestamo = prestamosBU.ListaPreSolicitudesPrestamos(NaveID, Estatus)

            For Each fila As Entidades.SolicitudPrestamo In listaPresolicitudesPrestamo
                TipoInteres = fila.Ptipointeres
                If TipoInteres = "I" Then
                    TipoInteres = "SIN INTERES"
                ElseIf TipoInteres = "S" Then
                    TipoInteres = "INTERES SOBRE SALDO"
                ElseIf TipoInteres = "F" Then
                    TipoInteres = "INTERES FIJO"
                End If
                grdAutorizacion.Rows.Add(fila.Pprestamoid, EstatusBolAU, EstatusBolRE, fila.Pcolaborador.PNombre, fila.Psaldo, fila.Pabono, fila.Psemanas, fila.Pinteres, TipoInteres, fila.Pestatus, fila.Pcolaborador.PColaboradorid, fila.Pjustificacion)

                If Estatus = "A" Then
                    grdAutorizacion.Rows(grdAutorizacion.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightGreen
                    grdAutorizacion.ReadOnly = True
                ElseIf Estatus = "I" Then
                    grdAutorizacion.Rows(grdAutorizacion.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Salmon
                    grdAutorizacion.ReadOnly = True
                ElseIf Estatus = "P" Then
                    grdAutorizacion.Rows(grdAutorizacion.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightYellow
                    grdAutorizacion.ReadOnly = False
                End If


            Next
        Else
            If cmbEstatus.Text = "" Then
                lblEstatus.ForeColor = Color.Red
            Else
                lblEstatus.ForeColor = Color.Black
            End If
            If cmbNave.Text = "" Then
                lblNave.ForeColor = Color.Red
            Else
                lblNave.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 110
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45
    End Sub
End Class