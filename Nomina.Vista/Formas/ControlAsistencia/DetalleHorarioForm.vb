Imports Tools

Public Class DetalleHorarioForm

    Dim estadoForm As String = "Searching" 'Searching, Editing, Adding

    Private Sub DetalleHorario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'load_configuracion_Colores()
        cargar_componentesInicio()
        'load_gridDetalleHorario_Custom()
        listado_naves()

    End Sub

    Private Sub load_configuracion_Colores()

        Tools.FormatoCtrls.formato(Me)

    End Sub

    Public Sub cargar_componentesInicio()
        btnCopiar.Visible = False
        lblCopiar.Visible = False
        btnAceptar.Visible = False
        lblAceptar.Visible = False
        btnGuardar.Visible = False
        lblGuardar.Visible = False
        btnCancelar.Visible = False
        lblCancelar.Visible = False
        btnEditar.Visible = False
        lblEditar.Visible = False
        nudRetardo.Value = 0
        nudRetardo.Enabled = False
        rbtnActivo.Checked = True
        btnAgregar.Visible = False
        lblAgregar.Visible = False
        grdDetalleHorario.ReadOnly = True
        clmBloque.ReadOnly = True
        clmRegistro.ReadOnly = True
    End Sub

    Public Sub validar_componentesEjecucion(ByVal boton As String)
        Dim usuario As Integer = 0
        usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If boton.ToString.Equals(btnAceptar.Name.ToString) Then

            estadoForm = "Searching"

            If cboxNave.SelectedValue <> 43 And cboxNave.SelectedValue <> 73 And cboxNave.SelectedValue <> 61 Then
                If cboxNave.SelectedValue = 57 Then
                    If usuario = 21 Then
                        btnEditar.Visible = True
                        lblEditar.Visible = True
                        btnCopiar.Visible = True
                        lblCopiar.Visible = True
                    Else
                        btnEditar.Visible = False
                        lblEditar.Visible = False
                        btnCopiar.Visible = False
                        lblCopiar.Visible = False
                    End If
                Else
                    If usuario = 21 Then
                        btnEditar.Visible = True
                        lblEditar.Visible = True
                        btnCopiar.Visible = True
                        lblCopiar.Visible = True
                    End If
                End If

            Else
                cboxNave.Enabled = False
                cboxHorario.Enabled = False
                btnAceptar.Visible = False
                lblAceptar.Visible = False

                btnAgregar.Visible = False
                lblAgregar.Visible = False
                btnEditar.Visible = True
                lblEditar.Visible = True

                btnGuardar.Visible = False
                lblGuardar.Visible = False
                btnCancelar.Visible = True
                lblCancelar.Visible = True
                rbtnActivo.Enabled = False
                rbtnInactivo.Enabled = False
            End If




        End If

        If boton.ToString.Equals(btnAgregar.Name.ToString) Then

            estadoForm = "Adding"

            btnAceptar.Visible = False
            lblAceptar.Visible = False
            btnAgregar.Visible = False
            lblAgregar.Visible = False
            btnEditar.Visible = False
            lblEditar.Visible = False
            btnGuardar.Visible = True
            lblGuardar.Visible = True
            btnCancelar.Visible = True
            lblCancelar.Visible = True
            cboxNave.SelectedIndex = -1
            cboxHorario.SelectedIndex = -1
            cboxHorario.DropDownStyle = ComboBoxStyle.Simple
            cboxHorario.MaxLength = 48
            nudRetardo.Enabled = True
            nudRetardo.Value = 0
            rbtnActivo.Checked = False
            rbtnInactivo.Checked = False

            grdDetalleHorario.Rows.Clear()
            load_gridDetalleHorario_Custom()

            grdDetalleHorario.ReadOnly = False
            clmBloque.ReadOnly = True
            clmRegistro.ReadOnly = True

        End If

        If boton.ToString.Equals(btnCopiar.Name.ToString) Then

            estadoForm = "Adding"

            btnAgregar.Visible = False
            lblAgregar.Visible = False
            btnEditar.Visible = False
            lblEditar.Visible = False
            btnCopiar.Visible = False
            lblCopiar.Visible = False
            btnGuardar.Visible = True
            lblGuardar.Visible = True
            btnCancelar.Visible = True
            lblCancelar.Visible = True

            cboxNave.Enabled = True
            cboxHorario.Enabled = True
            cboxHorario.DropDownStyle = ComboBoxStyle.Simple

            nudRetardo.Enabled = True

            rbtnActivo.Enabled = True
            rbtnInactivo.Enabled = True

            grdDetalleHorario.ReadOnly = False

            clmBloque.ReadOnly = True
            clmRegistro.ReadOnly = True

        End If

        If boton.ToString.Equals(btnEditar.Name.ToString) Then

            estadoForm = "Edditing"

            btnCopiar.Visible = False
            lblCopiar.Visible = False
            btnAgregar.Visible = False
            lblAgregar.Visible = False
            btnEditar.Visible = False
            lblEditar.Visible = False
            btnGuardar.Visible = True
            lblGuardar.Visible = True
            btnCancelar.Visible = True
            lblCancelar.Visible = True
            cboxNave.Enabled = False

            nudRetardo.Enabled = True

            rbtnActivo.Enabled = True
            rbtnInactivo.Enabled = True

            grdDetalleHorario.ReadOnly = False

            clmBloque.ReadOnly = True
            clmRegistro.ReadOnly = True

        End If

        If boton.ToString.Equals(btnCancelar.Name.ToString) Then

            estadoForm = "Searching"

            btnAceptar.Visible = False
            lblAceptar.Visible = False
            'btnAgregar.Visible = True
            'lblAgregar.Visible = True
            btnAgregar.Visible = False
            lblAgregar.Visible = False
            btnCopiar.Visible = False
            lblCopiar.Visible = False
            btnEditar.Visible = False
            lblEditar.Visible = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            btnCancelar.Visible = False
            lblCancelar.Visible = False
            cboxNave.SelectedIndex = -1
            cboxHorario.SelectedIndex = -1
            cboxNave.Enabled = True
            cboxHorario.Enabled = True
            cboxHorario.DropDownStyle = ComboBoxStyle.DropDownList
            nudRetardo.Value = 0
            nudRetardo.Enabled = False
            rbtnActivo.Checked = True

            rbtnActivo.Enabled = True
            rbtnInactivo.Enabled = True

            grdDetalleHorario.ReadOnly = True

        End If

        If boton.ToString.Equals(btnGuardar.Name.ToString) Then

            estadoForm = "Searching"

            btnAceptar.Visible = True
            lblAceptar.Visible = True
            btnAgregar.Visible = True
            lblAgregar.Visible = True
            btnCopiar.Visible = False
            lblCopiar.Visible = False
            btnEditar.Visible = False
            lblEditar.Visible = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            btnCancelar.Visible = False
            lblCancelar.Visible = False

            cboxNave.SelectedIndex = -1
            cboxHorario.SelectedIndex = -1
            cboxNave.Enabled = True
            cboxHorario.Enabled = True
            cboxHorario.DropDownStyle = ComboBoxStyle.DropDownList

            nudRetardo.Value = 0
            nudRetardo.Enabled = False

            rbtnActivo.Checked = True

            grdDetalleHorario.ReadOnly = True

        End If

    End Sub

    Private Sub load_gridDetalleHorario_Custom()

        ''Carga las columnas
        Dim col1, col2, col3, col4, col5, col6, col7 As New Tools.DateTimePickerColumn() 'Crear columna de tipo CalendarColumn

        Me.grdDetalleHorario.Columns.RemoveAt(4) 'Eliminar la columna especificada
        Me.grdDetalleHorario.Columns.Insert(4, col1) 'Insertar columna de tipo CalendarColumn
        'Me.gridDetalleHorario.Columns(4).DataPropertyName = "dia3" 'Asignar el nombre del campo de la base de datos a la columna especificada
        Me.grdDetalleHorario.Columns(4).HeaderText = "Lunes" 'Asignar el nombre a mostrar en la columna
        Me.grdDetalleHorario.Columns(4).Width = 85
        Me.grdDetalleHorario.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.grdDetalleHorario.Columns.RemoveAt(5)
        Me.grdDetalleHorario.Columns.Insert(5, col2)
        Me.grdDetalleHorario.Columns(5).HeaderText = "Martes"
        Me.grdDetalleHorario.Columns(5).Width = 85
        Me.grdDetalleHorario.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.grdDetalleHorario.Columns.RemoveAt(6)
        Me.grdDetalleHorario.Columns.Insert(6, col3)
        Me.grdDetalleHorario.Columns(6).HeaderText = "Miércoles"
        Me.grdDetalleHorario.Columns(6).Width = 85
        Me.grdDetalleHorario.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.grdDetalleHorario.Columns.RemoveAt(7)
        Me.grdDetalleHorario.Columns.Insert(7, col4)
        Me.grdDetalleHorario.Columns(7).HeaderText = "Jueves"
        Me.grdDetalleHorario.Columns(7).Width = 85
        Me.grdDetalleHorario.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.grdDetalleHorario.Columns.RemoveAt(8)
        Me.grdDetalleHorario.Columns.Insert(8, col5)
        Me.grdDetalleHorario.Columns(8).HeaderText = "Viernes"
        Me.grdDetalleHorario.Columns(8).Width = 85
        Me.grdDetalleHorario.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.grdDetalleHorario.Columns.RemoveAt(9)
        Me.grdDetalleHorario.Columns.Insert(9, col6)
        Me.grdDetalleHorario.Columns(9).HeaderText = "Sábado"
        Me.grdDetalleHorario.Columns(9).Width = 85
        Me.grdDetalleHorario.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        Me.grdDetalleHorario.Columns.RemoveAt(10)
        Me.grdDetalleHorario.Columns.Insert(10, col7)
        Me.grdDetalleHorario.Columns(10).HeaderText = "Domingo"
        Me.grdDetalleHorario.Columns(10).Width = 85
        Me.grdDetalleHorario.Columns(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        ''Pinta las filas
        For contador As Integer = 0 To 11

            If contador >= 0 And contador <= 2 Then

                Me.grdDetalleHorario.Rows.Insert(contador, 0, 0, "ENTRADA")

            End If

            If contador > 2 And contador <= 5 Then

                Me.grdDetalleHorario.Rows.Insert(contador, 0, 0, "COMIDA")

            End If

            If contador > 5 And contador <= 8 Then

                Me.grdDetalleHorario.Rows.Insert(contador, 0, 0, "REGRESO")

            End If

            If contador > 8 And contador <= 11 Then

                Me.grdDetalleHorario.Rows.Insert(contador, 0, 0, "SALIDA")

            End If

        Next

        For Each row As DataGridViewRow In grdDetalleHorario.Rows

            If row.Index = 0 Or row.Index = 3 Or row.Index = 6 Or row.Index = 9 Then

                row.Cells(3).Value = "INICIO"

            End If

            If row.Index = 1 Or row.Index = 4 Or row.Index = 7 Or row.Index = 10 Then

                row.Cells(3).Value = "HORA"

            End If

            If row.Index = 2 Or row.Index = 5 Or row.Index = 8 Or row.Index = 11 Then

                row.Cells(3).Value = "TERMINO"

            End If

        Next

    End Sub

    Private Sub listado_naves()

        Dim objNavesBU As New Framework.Negocios.NavesBU
        Dim tablaNaves As New DataTable

        tablaNaves = objNavesBU.ListaNavesSegunUsuarioTabla("", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)

        With cboxNave

            .DisplayMember = "nave_nombre"
            .ValueMember = "nave_naveid"
            .DataSource = tablaNaves

        End With

    End Sub

    Private Sub listado_horarios(ByVal boton As String)

        nudRetardo.Value = Nothing

        If cboxNave.SelectedIndex > 0 Then

            Dim objBU As New Negocios.HorariosBU
            Dim tablaHorarios As New DataTable

            tablaHorarios = objBU.listaHorariosTabla(cboxNave.SelectedValue, rbtnActivo.Checked)
            tablaHorarios.Rows.InsertAt(tablaHorarios.NewRow, 0)

            With cboxHorario

                .DisplayMember = "hora_nombre"
                .ValueMember = "hora_horarioid"
                .DataSource = tablaHorarios

            End With

            'cboxHorario.Items.RemoveAt(0)
            cboxHorario.Focus()

        End If

        If boton.ToString.Equals(btnAgregar.Name.ToString) _
            Or boton.ToString.Equals(btnCancelar.Name.ToString) _
            Or cboxNave.SelectedIndex <= 0 Or estadoForm.ToString.Equals("Adding") Then

            cboxHorario.DataSource = Nothing
            cboxHorario.Items.Clear()

        End If


    End Sub

    Private Sub obtener_HorarioRetardo(ByVal horarioID As Integer)

        Try

            Dim objBU As New Negocios.HorariosBU
            Dim listaHorarios As New List(Of Entidades.Horarios)
            listaHorarios = objBU.listaHorarios(cboxNave.SelectedValue, rbtnActivo.Checked)

            Dim horario As Entidades.Horarios = listaHorarios.Find(Function(c) c.DHorariosid = horarioID)
            nudRetardo.Value = CInt(horario.DRetardo)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub guardar_horario()

        Dim horario As New Entidades.Horarios
        Dim detalleHorario As New Entidades.DetalleHorario
        Dim horarioBU As New Nomina.Negocios.HorariosBU
        Dim detalleHorarioBU As New Nomina.Negocios.DetalleHorarioBU
        Dim nave As New Entidades.Naves

        'Obtiene los datos de horario
        If IsDBNull(cboxHorario.SelectedValue) Then

            horario.DHorariosid = Nothing

        Else

            If cboxHorario.SelectedValue > 0 Then

                horario.DHorariosid = CInt(cboxHorario.SelectedValue)

            Else

                horario.DHorariosid = Nothing

            End If

        End If

        horario.PNaves = nave
        horario.PNaves.PNombre = CStr(cboxNave.Text.ToString)
        horario.PNaves.PNaveId = CInt(cboxNave.SelectedValue)
        horario.DNombre = CStr(cboxHorario.Text.ToString)
        horario.DActivo = CBool(rbtnActivo.Checked)
        horario.DRetardo = CInt(nudRetardo.Value)

        horarioBU.guardarHorarios(horario)

    End Sub

    Public Sub guardar_detalle_horario()

        Dim horario As New Entidades.Horarios
        Dim detalleHorario As New Entidades.DetalleHorario
        Dim horarioBU As New Nomina.Negocios.HorariosBU
        Dim detalleHorarioBU As New Nomina.Negocios.DetalleHorarioBU
        Dim nave As New Entidades.Naves
        Dim i As Integer
        Dim correcto As Boolean = True

        Try
            For Each col As DataGridViewColumn In grdDetalleHorario.Columns

                ''Lunes
                If col.HeaderText.ToString.Equals("Lunes") Then
                    detalleHorario.DH_Dia = 1
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 2).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 1).Value.ToString.Equals("INICIO") Then

                                Convert.ToDateTime(row.Cells(i).Value)
                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next

                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 2).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 1).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 2).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 1).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 2).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 1).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 1).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                ''Martes
                If col.HeaderText.ToString.Equals("Martes") Then
                    detalleHorario.DH_Dia = 2
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 3).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 2).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 3).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 2).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 3).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 2).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 3).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 2).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 2).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                ''Miercoles
                If col.HeaderText.ToString.Equals("Miércoles") Then
                    detalleHorario.DH_Dia = 3
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 4).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 3).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 4).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 3).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 4).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 3).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 4).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 3).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 3).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                ''Jueves
                If col.HeaderText.ToString.Equals("Jueves") Then
                    detalleHorario.DH_Dia = 4
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 5).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 4).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 5).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 4).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 5).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 4).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 5).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 4).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 4).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                ''Viernes
                If col.HeaderText.ToString.Equals("Viernes") Then
                    detalleHorario.DH_Dia = 5
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 6).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 5).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 6).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 5).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 6).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 5).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 6).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 5).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 5).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                ''Sabado
                If col.HeaderText.ToString.Equals("Sábado") Then
                    detalleHorario.DH_Dia = 6
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 7).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 6).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 7).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 6).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 7).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 6).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 7).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 6).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 6).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                ''Domingo
                If col.HeaderText.ToString.Equals("Domingo") Then
                    detalleHorario.DH_Dia = 7
                    Dim j As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 8).Value.ToString.Equals("ENTRADA") Then

                            detalleHorario.DH_TipoCheck = 1

                            If row.Cells(i - 7).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 8).Value.ToString.Equals("COMIDA") Then

                            detalleHorario.DH_TipoCheck = 2

                            If row.Cells(i - 7).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 8).Value.ToString.Equals("REGRESO") Then

                            detalleHorario.DH_TipoCheck = 3

                            If row.Cells(i - 7).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        If cboxHorario.SelectedValue > 0 Then
                            horario.DHorariosid = CInt(cboxHorario.SelectedValue)
                            detalleHorario.DH_horario = horario
                        Else

                            horario.DHorariosid = CInt(horarioBU.buscarHorarioId)
                            detalleHorario.DH_horario = horario

                        End If

                        If row.Cells(i - 8).Value.ToString.Equals("SALIDA") Then

                            detalleHorario.DH_TipoCheck = 4

                            If row.Cells(i - 7).Value.ToString.Equals("INICIO") Then

                                detalleHorario.DH_InicioBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("HORA") Then

                                detalleHorario.DH_HoraCheck = DateTime.Parse(row.Cells(i).Value)

                            End If

                            If row.Cells(i - 7).Value.ToString.Equals("TERMINO") Then

                                detalleHorario.DH_FinBloque = DateTime.Parse(row.Cells(i).Value)

                            End If

                        End If

                        j += 1

                    Next
                    detalleHorarioBU.guardarDetalleHorario(detalleHorario)

                End If

                i += 1
            Next

        Catch ex As Exception

            show_message("Error", "Falló la operación")

        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        cboxHorario.DataSource = Nothing
        cboxHorario.Items.Clear()
        validar_componentesEjecucion(btnAgregar.Name.ToString)

    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        validar_componentesEjecucion(btnEditar.Name.ToString)

    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim horario As New Entidades.Horarios
        Dim detalleHorario As New Entidades.DetalleHorario
        Dim horarioBU As New Nomina.Negocios.HorariosBU
        Dim detalleHorarioBU As New Nomina.Negocios.DetalleHorarioBU
        Dim nave As New Entidades.Naves
        Dim valorCelda As DateTime
        valorCelda = Nothing
        Dim correcto As Boolean = True


        If IsDBNull(cboxNave.SelectedValue) Or CInt(cboxHorario.Text.Length) <= 0 Or IsDBNull(nudRetardo.Value) Or rbtnActivo.Checked = False And rbtnInactivo.Checked = False Then

            show_message("Advertencia", "Hay campos vacios en la información del horario")

        Else
            Dim mensajeConfirmacion As New ConfirmarForm
            mensajeConfirmacion.mensaje = "¿ Está seguro de guardar el horario de asistencia ? "

            If mensajeConfirmacion.ShowDialog = DialogResult.OK Then

                For Each col As DataGridViewColumn In grdDetalleHorario.Columns
                    'Dim i As Integer
                    For Each row As DataGridViewRow In grdDetalleHorario.Rows

                        'Dim j As Integer

                        If IsDBNull(grdDetalleHorario.Rows(row.Index).Cells(col.Index).Value) Or IsNothing(grdDetalleHorario.Rows(row.Index).Cells(col.Index).Value) Then

                            grdDetalleHorario.Rows(row.Index).Cells(col.Index).Value = "12:00:00 AM"

                        End If


                        If Not IsDBNull(grdDetalleHorario.Rows(row.Index).Cells(col.Index).Value) Or Not IsNothing(grdDetalleHorario.Rows(row.Index).Cells(col.Index).Value) Then

                            If col.Index > 3 Then

                                If Not DateTime.TryParse(grdDetalleHorario.Rows(row.Index).Cells(col.Index).Value.ToString, valorCelda) Then

                                    correcto = False

                                    Exit For

                                End If

                                If Not row.Index > 10 Then

                                    Dim valorCeldamas1 As DateTime


                                    If IsNothing(grdDetalleHorario.Rows(row.Index + 1).Cells(col.Index).Value) Or IsDBNull(grdDetalleHorario.Rows(row.Index + 1).Cells(col.Index).Value) Then

                                        valorCeldamas1 = Date.MinValue

                                    End If


                                    If Not valorCelda.ToLongTimeString = "12:00:00 AM" And Not valorCeldamas1 = "12:00:00 AM" Then

                                        If valorCelda.ToLongTimeString >= valorCeldamas1 Then

                                            grdDetalleHorario.Rows(row.Index + 1).Cells(col.Index).Style.BackColor = Color.Red

                                            correcto = False

                                            Exit For

                                        End If

                                    End If

                                End If

                            End If

                            correcto = True

                        Else

                            correcto = False

                            Exit For

                        End If

                    Next

                    If Not correcto Then

                        Exit For

                    End If


                    'i += 1

                Next

                If correcto Then

                    guardar_horario()
                    guardar_detalle_horario()
                    show_message("Exito", "La información del horario se guardo con exito")
                    validar_componentesEjecucion(btnGuardar.Name.ToString)
                    grdDetalleHorario.Rows.Clear()
                Else

                    show_message("Error", "Verifique la información del detalle de horario")

                End If

            End If

        End If

        'load_gridDetalleHorario_Custom()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        validar_componentesEjecucion(btnCancelar.Name.ToString)
        load_gridDetalleHorario_Custom()
        listado_horarios(btnCancelar.Name.ToString)
        grdDetalleHorario.Rows.Clear()
        'nudRetardo.Enabled = False

    End Sub

    Private Sub cboxNave_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxNave.DropDownClosed
        Dim usuario As Integer = 0
        Dim colaborador As Integer = 0
        Try
            usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            listado_horarios(cboxNave.Name.ToString)

            btnAceptar.Visible = False
            lblAceptar.Visible = False
            nudRetardo.Value = 0
            'gridDetalleHorario.Rows.Clear()

            If cboxNave.SelectedValue <> 43 And cboxNave.SelectedValue <> 73 And cboxNave.SelectedValue <> 82 Then
                If cboxNave.SelectedValue = 57 Then
                    If usuario = 461 Or usuario = 21 Then
                        lblAgregar.Visible = True
                        btnAgregar.Enabled = True
                        btnAgregar.Visible = True
                    Else
                        lblAgregar.Visible = False
                        btnAgregar.Enabled = False
                        btnAgregar.Visible = False
                    End If
                Else
                    If usuario = 21 Then
                        lblAgregar.Visible = True
                        btnAgregar.Enabled = True
                        btnAgregar.Visible = True
                    Else
                        lblAgregar.Visible = False
                        btnAgregar.Enabled = False
                        btnAgregar.Visible = False
                    End If
                End If

            Else
                lblAgregar.Visible = True
                btnAgregar.Enabled = True
                btnAgregar.Visible = True
            End If
        Catch ex As Exception

        End Try




    End Sub

    Private Sub cboxHorario_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboxHorario.DropDownClosed

        grdDetalleHorario.Rows.Clear()

        If cboxHorario.SelectedIndex > 0 Then

            obtener_HorarioRetardo(cboxHorario.SelectedValue)

            btnAceptar.Visible = True
            lblAceptar.Visible = True
        Else

            btnAceptar.Visible = False
            lblAceptar.Visible = False
            nudRetardo.Value = 0

        End If



    End Sub

    Private Sub rbtnActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnActivo.CheckedChanged

        If estadoForm.ToString.Equals("Searching") Then

            listado_horarios(rbtnInactivo.Name.ToString)

        End If

        If estadoForm.ToString.Equals("Editing") Then

            listado_horarios(rbtnInactivo.Name.ToString)

        End If

    End Sub

    Private Sub rbtnInactivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnInactivo.CheckedChanged

        If estadoForm.ToString.Equals("Searching") Then

            listado_horarios(rbtnInactivo.Name.ToString)

        End If

        If estadoForm.ToString.Equals("Editing") Then

            listado_horarios(rbtnInactivo.Name.ToString)

        End If

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)


        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeError As New AdvertenciaForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = mensaje
            mensajeError.Show()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.MdiParent = Me.MdiParent
            'mensajeExito.mensaje = "Configuración Guardada  " & vbNewLine & mensaje.ToString
            mensajeAviso.mensaje = mensaje
            mensajeAviso.Show()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.MdiParent = Me.MdiParent
            mensajeError.mensaje = mensaje
            mensajeError.Show()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = mensaje
            mensajeExito.Show()

        End If

    End Sub

    Private Sub gridDetalleHorario_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles grdDetalleHorario.CellPainting
        'el e.columnindex son las columnas que checara para ver si se pueden combinar las celdas iguales
        ' en este caso checara la 2

        If e.ColumnIndex = 2 AndAlso e.RowIndex <> -1 Then

            Using gridBrush As Brush = New SolidBrush(Me.grdDetalleHorario.GridColor), backColorBrush As Brush = New SolidBrush(e.CellStyle.BackColor)

                Using gridLinePen As Pen = New Pen(gridBrush)

                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

                    If e.RowIndex < grdDetalleHorario.Rows.Count - 2 AndAlso grdDetalleHorario.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value.ToString() <> e.Value.ToString() Then

                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1)

                    End If

                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom)

                    If Not e.Value Is Nothing Then

                        If e.RowIndex > 0 AndAlso grdDetalleHorario.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value.ToString() = e.Value.ToString() Then

                        Else

                            e.Graphics.DrawString(CType(e.Value, String), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault)

                        End If

                    End If

                    e.Handled = True

                End Using

            End Using

        End If

    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click

        validar_componentesEjecucion(btnCopiar.Name.ToString)

    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click

        'gboxParametros.Visible = False
        grbParametros.Height = 51


    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click

        'gboxParametros.Visible = True
        grbParametros.Height = 152

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboxHorario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboxHorario.KeyPress

        If Char.IsLetter(e.KeyChar) Then

            e.KeyChar = Char.ToUpper(e.KeyChar)

        End If

    End Sub


    Private Sub pnlMinimizarParametros_Paint(sender As Object, e As PaintEventArgs) Handles pnlMinimizarParametros.Paint

    End Sub

    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click

        'gridDetalleHorario.Rows().Cells().Value = 


        If cboxHorario.SelectedIndex > 0 Then
            load_gridDetalleHorario_Custom()

            Dim detalleHorarioBU As New Nomina.Negocios.DetalleHorarioBU
            Dim listaDetalleHorario As New List(Of Entidades.DetalleHorario)

            If Not IsDBNull(cboxHorario.SelectedValue) Then
                'Or cboxHorario.SelectedValue > 0 
                listaDetalleHorario = detalleHorarioBU.listaDetalleHorario(cboxHorario.SelectedValue)

                If listaDetalleHorario.Capacity > 0 Then

                    'Dim i As Integer

                    For Each elemento As Entidades.DetalleHorario In listaDetalleHorario

                        ''Lunes
                        If elemento.DH_Dia = 1 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(4).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(4).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(4).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(4).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(4).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(4).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(4).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(4).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(4).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(4).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(4).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(4).Value = elemento.DH_FinBloque

                            End If

                        End If

                        ''Martes
                        If elemento.DH_Dia = 2 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(5).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(5).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(5).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(5).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(5).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(5).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(5).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(5).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(5).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(5).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(5).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(5).Value = elemento.DH_FinBloque

                            End If

                        End If

                        ''Miercoles
                        If elemento.DH_Dia = 3 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(6).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(6).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(6).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(6).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(6).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(6).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(6).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(6).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(6).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(6).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(6).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(6).Value = elemento.DH_FinBloque

                            End If

                        End If

                        ''Jueves
                        If elemento.DH_Dia = 4 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(7).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(7).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(7).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(7).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(7).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(7).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(7).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(7).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(7).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(7).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(7).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(7).Value = elemento.DH_FinBloque

                            End If

                        End If

                        ''Viernes
                        If elemento.DH_Dia = 5 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(8).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(8).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(8).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(8).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(8).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(8).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(8).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(8).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(8).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(8).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(8).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(8).Value = elemento.DH_FinBloque

                            End If

                        End If

                        ''Sabado
                        If elemento.DH_Dia = 6 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(9).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(9).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(9).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(9).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(9).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(9).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(9).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(9).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(9).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(9).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(9).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(9).Value = elemento.DH_FinBloque

                            End If

                        End If

                        ''Domingo
                        If elemento.DH_Dia = 7 Then

                            If elemento.DH_TipoCheck = 1 Then

                                grdDetalleHorario.Rows(0).Cells(10).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(1).Cells(10).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(2).Cells(10).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 2 Then

                                grdDetalleHorario.Rows(3).Cells(10).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(4).Cells(10).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(5).Cells(10).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 3 Then

                                grdDetalleHorario.Rows(6).Cells(10).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(7).Cells(10).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(8).Cells(10).Value = elemento.DH_FinBloque

                            End If

                            If elemento.DH_TipoCheck = 4 Then

                                grdDetalleHorario.Rows(9).Cells(10).Value = elemento.DH_InicioBloque
                                grdDetalleHorario.Rows(10).Cells(10).Value = elemento.DH_HoraCheck
                                grdDetalleHorario.Rows(11).Cells(10).Value = elemento.DH_FinBloque

                            End If

                        End If

                    Next
                Else



                End If

            End If

            validar_componentesEjecucion(btnAceptar.Name.ToString)
        Else
            show_message("Advertencia", "Hay campos vacios en la información del horario")
        End If


    End Sub

    Private Sub btnLimpiarSolicitudes_Click(sender As Object, e As EventArgs) Handles btnLimpiarSolicitudes.Click
        ' grdDetalleHorario.Rows.Clear()

        validar_componentesEjecucion(btnCancelar.Name.ToString)
        load_gridDetalleHorario_Custom()
        listado_horarios(btnCancelar.Name.ToString)
        grdDetalleHorario.Rows.Clear()
        'nudRetardo.Enabled = False
    End Sub
End Class

