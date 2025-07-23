Imports Nomina.Negocios
Imports Tools

Public Class EditarExcepcionesHorariosForm
    Public idHexc As Int32
    Dim fecha As Date
    'Dim fechaSeleccionada As Boolean
    Dim idhora As Int32
    Public Property PidHexc As Int32
        Get
            Return idHexc

        End Get
        Set(value As Int32)
            idHexc = value
        End Set
    End Property

    Private Sub EditarExcepcionesHorariosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitCombos()

        Dim objexeBU As New ExcepcionesHorariosBU
        Dim excepcion As New Entidades.ExcepcionesHorarios
        Dim horario As New Entidades.Horarios

        excepcion = objexeBU.BuscarHexc(idHexc)
        horario = excepcion.PHorario
        txtNombre.Text = excepcion.Pnombre
        cmbTipo.SelectedValue = excepcion.PTipo
        dtpCalendario.Value = excepcion.PFecha
        'dtpFecha.SelectionRange = (SelectionRange(p.Fecha))

        'If cmbTipo.SelectedValue = 1 Then
        '	cmbTipo.DisplayMember = "Entrada"
        'Else
        '	cmbTipo.DisplayMember = "Salida"
        'End If
        cmbHorario.SelectedValue = excepcion.PHorario.DHorariosid

        excepcion.PHorario.DHorariosid = horario.DHorariosid


        If (excepcion.PActivo) Then
            btnSi.Checked = True
        Else
            btnNo.Checked = True
        End If
        llenartabla()

    End Sub

    Public Sub InitCombos()
        Dim objHorariosBU As New Negocios.HorariosBU
        Dim tablaHorarios As New DataTable
        tablaHorarios = objHorariosBU.listaHorariosActivos
        tablaHorarios.Rows.InsertAt(tablaHorarios.NewRow, 0)
        With cmbHorario
            .DisplayMember = "hora_nombre"
            .ValueMember = "hora_horarioid"
            .DataSource = tablaHorarios

        End With

        cmbTipo.Items.Clear()

        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Descripcion")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr("Codigo") = "0"
        dr("Descripcion") = ""
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "1"
        dr("Descripcion") = "Entrada"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "2"
        dr("Descripcion") = "Salida"
        dt.Rows.Add(dr)

        cmbTipo.DataSource = dt
        cmbTipo.ValueMember = "Codigo"
        cmbTipo.DisplayMember = "Descripcion"


        ''
        cmbTipoHoras.Items.Clear()

        Dim dtt As DataTable = New DataTable("Tabla")

        dtt.Columns.Add("Codigo")
        dtt.Columns.Add("Descripcion")

        Dim drr As DataRow

        drr = dtt.NewRow()
        drr("Codigo") = "0"
        drr("Descripcion") = ""
        dtt.Rows.Add(drr)

        drr = dtt.NewRow()
        drr("Codigo") = "1"
        drr("Descripcion") = "Entrada"
        dtt.Rows.Add(drr)

        drr = dtt.NewRow()
        drr("Codigo") = "2"
        drr("Descripcion") = "Salida"
        dtt.Rows.Add(drr)

        cmbTipoHoras.DataSource = dtt
        cmbTipoHoras.ValueMember = "Codigo"
        cmbTipoHoras.DisplayMember = "Descripcion"
        ''



        'Dim objtipoBU As New Negocios.ExcepcionesHorariosBU
        'Dim tablatipo As New DataTable
        'tablatipo = objtipoBU.listaHorariosExcepcionesActivos
        'tablatipo.Rows.InsertAt(tablatipo.NewRow, 0)
        'With cmbTipo
        '	.DisplayMember = "hexc_tipo"
        '	.ValueMember = "hexc_horarioexcepcionid"

        '	If cmbTipo.DisplayMember = "1" Then
        '		cmbTipo.DisplayMember = "Entrada"
        '	Else
        '		cmbTipo.DisplayMember = "Salida"
        '	End If
        '	.DataSource = tablatipo
        'End With

    End Sub


    'Private Sub dtpFecha_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs)
    '	fecha = dtpFecha.SelectionStart
    '	fechaSeleccionada = True
    'End Sub
    Public Sub llenartabla()

        grdHoras.Rows.Clear()

        Dim listaHorariosHoras As New List(Of Entidades.ExcepcionesHorariosHoras)
        Dim objBU As New Negocios.ExcepcionesHorariosHorasBU
        listaHorariosHoras = objBU.listaExeHorariosHoras(idHexc)
        For Each objeto As Entidades.ExcepcionesHorariosHoras In listaHorariosHoras
            AgregarFila(objeto)

        Next
    End Sub
    Public Sub AgregarFila(ByVal horas As Entidades.ExcepcionesHorariosHoras)
        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = horas.PHorasid
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        If horas.PTipo = 1 Then
            celda.Value = "Entrada"
        Else
            celda.Value = "Salida"
        End If
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = horas.PHoras
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = horas.PMinutos
        fila.Cells.Add(celda)



        grdHoras.Rows.Add(fila)



    End Sub

    Private Sub btnMas_Click(sender As System.Object, e As System.EventArgs) Handles btnMas.Click
        Dim falla As Boolean = False
        If txtHoras.Text <> "" Then
            lblHora.ForeColor = Color.Black
        Else
            lblHora.ForeColor = Color.Red
            falla = True

        End If

        If txtMinutos.Text <> "" Then
            Label2.ForeColor = Color.Black
        Else
            Label2.ForeColor = Color.Red
            falla = True

        End If
        If cmbTipoHoras.Text <> "" Then
            lblTipoHoras.ForeColor = Color.Black
        Else
            lblTipoHoras.ForeColor = Color.Red
            falla = True
        End If


        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()
            'MsgBox("Falta completar campos")
        Else
            Dim Hora As New Entidades.ExcepcionesHorariosHoras

            Hora.PHoras = txtHoras.Text
            Hora.PMinutos = txtMinutos.Text
            '
            Hora.PHorarioId = idHexc
            '
            If cmbTipoHoras.Text = "Entrada" Then
                Hora.PTipo = 1

            Else
                Hora.PTipo = 2
            End If


            Dim objHorasBU As New ExcepcionesHorariosHorasBU
            objHorasBU.guardarHorariosHoras(Hora)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()
            'MsgBox("Transaccion exitosa")


            'Me.Close()

            llenartabla()
            txtHoras.Text = ""
            cmbTipoHoras.SelectedIndex = 0
            txtMinutos.Text = ""
            grdHoras.Rows.Clear()
            llenartabla()


        End If

    End Sub

    Private Sub btnMenos_Click(sender As System.Object, e As System.EventArgs) Handles btnMenos.Click
        'Dim horasid As Int32 = 0
        'For Each fila As DataGridViewRow In grdHoras.SelectedRows
        '	For Each columna As DataGridViewCell In fila.Cells
        '		If (columna.OwningColumn.Name = "ColId") Then
        '			horasid = CInt(columna.Value)
        '		End If
        '	Next
        'Next

        Dim objHorasBU As New ExcepcionesHorariosHorasBU
        objHorasBU.EliminarHorariosHoras(idhora)
        'MsgBox("Transaccion exitosa")


        'InitCombos()
        llenartabla()
        'Me.Close()


    End Sub

    Private Sub grdHoras_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdHoras.CellClick
        idhora = CInt(grdHoras.Rows(e.RowIndex).Cells(0).Value)
    End Sub

    Private Sub btnGuardar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        If txtNombre.Text <> "" Then

            lblNombre.ForeColor = Color.Black
        Else


            lblNombre.ForeColor = Color.Red
            falla = True

        End If

        'If dtpCalendario.Value Then

        '	lblFecha.ForeColor = Color.Black
        'Else


        '	lblFecha.ForeColor = Color.Red
        '	falla = True

        'End If

        If cmbHorario.Text <> "" Then

            lblHorario.ForeColor = Color.Black
        Else


            lblHorario.ForeColor = Color.Red
            falla = True

        End If

        If cmbTipo.Text <> "" Then

            lblTipo.ForeColor = Color.Black
        Else


            lblTipo.ForeColor = Color.Red
            falla = True

        End If


        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.MdiParent = Me.MdiParent

            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()
            'MsgBox("Falta completar campos")
        Else
            Dim Excepcion As New Entidades.ExcepcionesHorarios

            Dim horarios As New Entidades.Horarios




            Excepcion.Pnombre = txtNombre.Text
            Excepcion.PFecha = dtpCalendario.Value
            If cmbTipo.Text = "Entrada" Then
                Excepcion.PTipo = 1
            Else
                Excepcion.PTipo = 2
            End If
            'Excepcion.PTipo = cmbTipo.Text
            Excepcion.PActivo = btnSi.Checked


            If cmbHorario.SelectedIndex > 0 Then
                horarios.DHorariosid = cmbHorario.SelectedValue

                Excepcion.PHorario = horarios

            End If
            Excepcion.PExcepcionesHorarioID = idHexc

            Dim objexeBU As New Negocios.ExcepcionesHorariosBU
            objexeBU.EditarHexc(Excepcion)
            Me.Close()
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()
            'MsgBox("Transaccion exitosa")
            Me.Close()
        End If

    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    'Private Sub dtpFecha_DateChanged_1(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles dtpFecha.DateChanged
    '	fecha = dtpFecha.SelectionStart
    '	fechaSeleccionada = True
    'End Sub

    'Private Function SelectionRange() As Object
    '	Throw New NotImplementedException
    'End Function

    Private Sub txtHoras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoras.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsNumber(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtMinutos_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMinutos.TextChanged

    End Sub

    Private Sub txtMinutos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinutos.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsNumber(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbTipoHoras_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipoHoras.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoHoras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipoHoras.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub
End Class