Imports Tools

Public Class CancelarPrestamosForm
    Dim idNave As Integer = 0
    Private Sub CancelarPrestamosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        WindowState = FormWindowState.Maximized
        'llenarTablaConPrestamosPorAutorizar()
        Tools.FormatoCtrls.formato(Me)
        '' NavesUsuario()
        Controles.ComboNavesSegunUsuario(cmbNaves, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

    ''METODO PARA GUARDAR

    ''LLENAR LAS NAVER POR USUARIO EN EL COMBO BOX
    Public Sub NavesUsuario()

        'Dim objMotivosBU As New Nomina.Negocios.SolicitudPrestamoBU
        'Dim tablaMotivos As New DataTable
        'Dim IdColaborador As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        'tablaMotivos = objMotivosBU.NavesColaborador(IdColaborador)
        'tablaMotivos.Rows.InsertAt(tablaMotivos.NewRow, 0)
        'With cmbNaves
        '    .DisplayMember = "nave_nombre"
        '    .ValueMember = "nave_naveid"
        '    .DataSource = tablaMotivos
        'End With

        Try

            Controles.ComboNavesSegunUsuario(cmbNaves, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))

        Catch ex As Exception

        End Try

        If cmbNaves.Items.Count < 2 Then
            cmbNaves.SelectedIndex = 1
        Else
            'cmbNave.SelectedIndex = 4
        End If

    End Sub

    ''LLENAR PRESTAMOS POR AUTORIZAR
    Public Sub llenarTablaConPrestamosPorAutorizar()
        Try
            Dim listaConfiguracionPrestamos As New List(Of Entidades.SolicitudPrestamo)
            Dim prestamosBU As New Nomina.Negocios.SolicitudPrestamoBU
            Dim idNave As Integer
            idNave = (Int(cmbNaves.SelectedValue))
            listaConfiguracionPrestamos = prestamosBU.ListaPrestamosCancelar(idNave)

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

            Me.grdCancelar.Rows.Add(fila)
            grdCancelar.DefaultCellStyle.BackColor = Color.LightYellow
        End If

    End Sub

    Public Sub GuardarPrestamo()
        Dim objBU As New Nomina.Negocios.SolicitudPrestamoBU

        Dim ObjSolicitud As New Entidades.SolicitudPrestamo
        Dim ObjColaborador As New Entidades.Colaborador
        Dim idPrestamos As Integer = 0
        Dim Cancelar As Boolean

        For Each row As DataGridViewRow In grdCancelar.Rows 'Recorro todo el grid fila por fila
            idPrestamos = row.Cells("clmidPrestamo").Value

            Cancelar = row.Cells("clmCancelar").Value

            If Cancelar = False Then
                row.Cells(1).Style.BackColor = Color.LightYellow
                row.Cells(2).Style.BackColor = Color.LightYellow
                row.Cells(3).Style.BackColor = Color.LightYellow
                row.Cells(4).Style.BackColor = Color.LightYellow
                row.Cells(5).Style.BackColor = Color.LightYellow
                row.Cells(6).Style.BackColor = Color.LightYellow
                row.Cells(7).Style.BackColor = Color.LightYellow
                row.Cells(8).Style.BackColor = Color.LightYellow
            Else

                If Cancelar = True Then

                    row.Cells(1).Style.BackColor = Color.Salmon
                    row.Cells(2).Style.BackColor = Color.Salmon
                    row.Cells(3).Style.BackColor = Color.Salmon
                    row.Cells(4).Style.BackColor = Color.Salmon
                    row.Cells(5).Style.BackColor = Color.Salmon
                    row.Cells(6).Style.BackColor = Color.Salmon
                    row.Cells(7).Style.BackColor = Color.Salmon
                    row.Cells(8).Style.BackColor = Color.Salmon

                    ObjSolicitud.Pprestamoid = idPrestamos
                    ObjSolicitud.Pestatus = "I"
                    ObjColaborador.PColaboradorid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    ObjSolicitud.Pcolaborador = ObjColaborador

                    objBU.guardarCancelarPrestamos(ObjSolicitud)

                End If


            End If

        Next
        Dim mensajeExito As New ExitoForm
        mensajeExito.MdiParent = Me.MdiParent
        mensajeExito.mensaje = "Prestamos cancelados."
        mensajeExito.Show()
        grdCancelar.Rows.Clear()
        llenarTablaConPrestamosPorAutorizar()

    End Sub



    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorfilas As Integer = 0
        For Each row As DataGridViewRow In grdCancelar.Rows
            contadorfilas += 1
        Next

        If contadorfilas > 0 Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = "¿Esta seguro de querer cancelar el préstamo?."

            If mensajeExito.ShowDialog = DialogResult.OK Then
                GuardarPrestamo()
            End If
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        grdCancelar.Rows.Clear()

    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbParametros.Height = 45

    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 115
    End Sub

    Private Sub lblCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCancelar.Click

    End Sub

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub


    Private Sub btnLimpiar_Click_1(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCancelar.Rows.Clear()
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        grdCancelar.Rows.Clear()
        llenarTablaConPrestamosPorAutorizar()
    End Sub
End Class