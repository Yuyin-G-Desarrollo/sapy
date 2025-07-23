Imports Tools
Imports Infragistics.Win.UltraWinGrid

Public Class Editar_StatusClienteForm


    Public clienteID_SAY As Integer
    Public clienteID_SICY As Integer
    Public personaid As Integer
    Public status As Boolean


    Private Sub Editar_StatusClienteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recuperar_datos_Panel_Cliente(clienteID_SAY)
        poblar_gridHistorialValidaciones(clienteID_SAY, 3, gridHistorial)
        Dim objBU As New Framework.Negocios.ValidacionBU
        Dim mensaje As String = String.Empty
        If objBU.verifica_Pedidos_Pendientes(clienteID_SICY) And status = True Then
            mensaje += "El cliente cuenta con pedidos pendientes " + Environment.NewLine + "No se podrá modificar su status actual"
            show_message("Aviso", mensaje)
            gboxModificacionStatusCliente.Enabled = False
            btnGuardarCliente.Enabled = False
            Return
        End If
        If objBU.verifica_Saldo_Pendiente(clienteID_SICY) And status = True Then
            mensaje += "El cliente cuenta con saldo pendiente " + Environment.NewLine + "No se podrá modificar su status actual"
            show_message("Aviso", mensaje)
            btnGuardarCliente.Enabled = False
            gboxModificacionStatusCliente.Enabled = False
            Return
        End If

    End Sub

    Private Sub Editar_StatusClienteForm_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Dim caracter As Char = e.KeyChar

        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If caracter = "|" Or caracter = "~" Or caracter = "'" Then
            e.Handled = True
        End If
    End Sub

    Private Sub recuperar_datos_Panel_Cliente(clienteID As Integer)

        cboxClienteCliente.Enabled = False
        txtClienteRazonSocial.Enabled = False
        cboxClienteEstatus.Enabled = False

        If clienteID > 0 Then

            Dim ClientesBU As New Ventas.Negocios.ClientesBU
            Dim Cliente As New DataTable

            Cliente = ClientesBU.Datos_TablaCliente(clienteID)

            If Cliente.Rows.Count > 0 Then

                ListaClientes()
                cboxClienteCliente.SelectedValue = clienteID

                If IsDBNull(Cliente.Rows(0).Item("clie_razonsocial")) Then
                    txtClienteRazonSocial.Text = String.Empty
                Else
                    txtClienteRazonSocial.Text = CStr(Cliente.Rows(0).Item("clie_razonsocial"))
                End If

                If IsDBNull(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) Then
                    cboxClienteEstatus.SelectedIndex = -1
                Else
                    If CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 1 Then
                        cboxClienteEstatus.SelectedIndex = 0
                        rbtnClienteStatusActivo.Checked = False
                        rbtnClienteStatusInactivo.Checked = True
                        Me.Text = "Inactivación de cliente"
                        lblTitulo.Text = "Inactivación de cliente"
                    ElseIf CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 2 Then
                        cboxClienteEstatus.SelectedIndex = 0
                        rbtnClienteStatusActivo.Checked = True
                        rbtnClienteStatusInactivo.Checked = False
                        Me.Text = "Activación de cliente"
                        lblTitulo.Text = "Activación de cliente"
                    ElseIf CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 3 Then
                        cboxClienteEstatus.SelectedIndex = 1
                        rbtnClienteStatusActivo.Checked = False
                        rbtnClienteStatusInactivo.Checked = True
                        Me.Text = "Inactivación de cliente"
                        lblTitulo.Text = "Inactivación de cliente"
                    ElseIf CInt(Cliente.Rows(0).Item("clie_clasificacionpersonaid")) = 4 Then
                        cboxClienteEstatus.SelectedIndex = 0
                        rbtnClienteStatusActivo.Checked = True
                        rbtnClienteStatusInactivo.Checked = False
                        Me.Text = "Activación de cliente"
                        lblTitulo.Text = "Activación de cliente"
                    End If
                End If

            End If
        End If


        ListaValidador(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, 3)
        cboxValidador.Enabled = False
        dateModificacionFecha.Value = Now
        dateModificacionFecha.Enabled = False
        txtValidacionComentarios.Enabled = True

    End Sub

    Private Sub ListaClientes()
        Try

            Controles.ComboNombreComercialCliente(cboxClienteCliente, 0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListaValidador(usuarioID As Integer, tipoValidacion As Integer)
        Try
            Controles.ComboColaboradorValidador(cboxValidador, usuarioID, tipoValidacion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardarCliente_Click(sender As Object, e As EventArgs) Handles btnGuardarCliente.Click
        Dim validacionStatus As Integer

        If rbtnClienteStatusActivo.Checked Then
            validacionStatus = 3
        Else
            validacionStatus = 4
        End If

        Try
            alta_Ventas_Ventas_ValidacionCliente(validacionStatus)
            show_message("Exito", "Cambios guardados con éxito")
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelarCliente_Click(sender As Object, e As EventArgs) Handles btnCancelarCliente.Click
        Me.Close()
    End Sub

    Public Sub alta_Ventas_Ventas_ValidacionCliente(validacionStatus As Integer)

        Dim clientesBU As New Negocios.ClientesBU
        Dim validacion As New Entidades.Validacion
        Dim validaciontipo As New Entidades.ValidacionTipo
        Dim colaborador As New Entidades.Colaborador
        Dim cliente As New Entidades.Cliente

        If cboxValidador.SelectedValue = 0 Then
            Return
        Else
            Dim NuevoClasificacionPersonaID As Integer
            Dim status_cliente_sicy As String = String.Empty

            '   CLASIFICACION PERSONA DE CLIENTE - OBLIGATORIO PARA AMBOS
            If cboxClienteEstatus.SelectedIndex > -1 Then

                If cboxClienteEstatus.Text.ToUpperInvariant.Equals("PROSPECTO") Then
                    cliente.statuscliente = "P"
                    If rbtnClienteStatusActivo.Checked Then
                        NuevoClasificacionPersonaID = 3
                        status_cliente_sicy = "S"
                    Else
                        NuevoClasificacionPersonaID = 4
                        status_cliente_sicy = "N"
                    End If
                    'clasificacionPersonas.clasificacionpersonaid = 3

                ElseIf cboxClienteEstatus.Text.ToUpperInvariant.Equals("CLIENTE") Then
                    cliente.statuscliente = "C"
                    If rbtnClienteStatusActivo.Checked Then
                        NuevoClasificacionPersonaID = 1
                        status_cliente_sicy = "S"
                    Else
                        NuevoClasificacionPersonaID = 2
                        status_cliente_sicy = "N"
                    End If
                    'clasificacionPersonas.clasificacionpersonaid = 1

                End If
                lblClienteEstatus.ForeColor = Color.Black
            End If

            ' @clienteid AS INTEGER
            cliente.clienteid = clienteID_SAY
            validacion.registro = cliente
            ',@colaboradorid AS INTEGER
            colaborador.PColaboradorid = cboxValidador.SelectedValue
            validacion.colaborador = colaborador
            ',@validacionstatusid AS INTEGER
            validacion.validacionestatus = validacionStatus
            ',@validaciontipoid AS INTEGER
            validaciontipo.validaciontipoid = 3 'vati_validaciontipoid	= 1	, vati_nombre = INFORMACIÓN VENTAS EN FICHA TÉCNICA DE CLIENTE                                                      
            validacion.validaciontipo = validaciontipo
            ',@validacionfecha_ventas AS DATETIME
            validacion.fechavalidacion = dateModificacionFecha.Value
            ',@comentario AS VARCHAR(150)
            If txtValidacionComentarios.TextLength < 1 Then
                show_message("Advertencia", "Falta información")
                lblVentasValidacionComentarios.ForeColor = Color.Red
                Return
            Else
                validacion.comentario = txtValidacionComentarios.Text
                lblVentasValidacionComentarios.ForeColor = Color.Black
            End If

            Try
                clientesBU.AltaValidacionCliente(validacion, NuevoClasificacionPersonaID)
                clientesBU.Modificacion_Status_Cliente_SICY(clienteID_SICY, status_cliente_sicy)
            Catch ex As Exception
                show_message("Error", ex.ToString)
            End Try

        End If

    End Sub

    'Muestra el form de mensaje
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

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Public Sub poblar_gridHistorialValidaciones(clienteID As Integer, tipoValidacion As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DataSource = Nothing

        Dim validacionBU As New Framework.Negocios.ValidacionBU
        Dim historialValidaciones As New DataTable

        historialValidaciones = validacionBU.Datos_TablaValidacion_Cliente(clienteID, tipoValidacion)

        grid.DataSource = historialValidaciones

        gridHistorialValidacionesDiseno(tipoValidacion, grid)

    End Sub

    Private Sub gridHistorialValidacionesDiseno(tipoValidacion As Integer, grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns(0).Header.Caption = "STATUS"
        grid.DisplayLayout.Bands(0).Columns(1).Header.Caption = "VALIDADOR"
        grid.DisplayLayout.Bands(0).Columns(2).Header.Caption = "FECHA"
        grid.DisplayLayout.Bands(0).Columns(3).Header.Caption = "COMENTARIO"
        grid.DisplayLayout.Bands(0).Columns(2).Style = ColumnStyle.DateTime
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No

    End Sub


End Class