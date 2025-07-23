Imports Nomina.Negocios
Imports Tools


Public Class EditarHorariosForm
    Public horariosid As Int32
    Public horas As Integer
    Public Property Dhorariosid As Int32
        Get
            Return horariosid
        End Get
        Set(value As Int32)
            horariosid = value
        End Set
    End Property
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub tbcHoras_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcHoras.SelectedIndexChanged

    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub EditarHorariosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Carga datos para la primer pestaña

        InitCombos()
        Dim objhorariosBu As New HorariosBU
        Dim horario As New Entidades.Horarios
        Dim naves As New Entidades.Naves
        horario = objhorariosBu.buscarHorario(horariosid)

        cmbNave.SelectedValue = horario.PNaves.PNaveId
        horario.PNaves.PNaveId = naves.PNaveId

        txtNombreDelHorario.Text = horario.DNombre
        txtHora.Text = horario.DNombre

        If (horario.DActivo) Then
            btnSi.Checked = True
        Else
            btnNo.Checked = True
        End If

        InitCombos()

        If horas > 0 Then
            cmbTipo.SelectedValue = horas
        End If




        llenartabla()

    End Sub


    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        If txtHora.Text <> "" Then

            hora.ForeColor = Color.Black
        Else


            hora.ForeColor = Color.Red
            falla = True

        End If


        If falla Then



            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()

            'MsgBox("Falta completar campos")
        Else

            Dim horario As New Entidades.Horarios
            Dim Nave As New Entidades.Naves

            horario.DHorariosid = horariosid
            horario.DNombre = txtHora.Text
            horario.DActivo = btnSi.Checked

            If cmbNave.SelectedIndex > 0 Then
                Nave.PNaveId = CInt(cmbNave.SelectedValue)
                horario.PNaves = Nave
            End If


            horario.PNaves = Nave


            Dim objHorarioBU As New HorariosBU
            objHorarioBU.editarHorarios(horario)




            'Dim mensajeExito As New ExitoForm

            'mensajeExito.mensaje = "Falta completar campos"
            'ExitoForm.Show()
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()
            'Me.Close()
            'MsgBox("Transaccion exitosa")
        End If


    End Sub
    Public Sub llenartabla()
        'Dim horarios As Int32 = 0
        'If cmbTipo.SelectedIndex > 0 Then
        '	horarios = CInt(cmbTipo.SelectedValue)
        'End If
        grdHoras.Rows.Clear()

        Dim listaHorariosHoras As New List(Of Entidades.Horas)
        Dim objBU As New Negocios.HorasBU
        listaHorariosHoras = objBU.listaHorariosHoras(horariosid)
        For Each objeto As Entidades.Horas In listaHorariosHoras
            AgregarFila(objeto)

        Next
    End Sub
    Public Sub AgregarFila(ByVal horas As Entidades.Horas)
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
        If cmbTipo.SelectedIndex > 0 Then
            lblTipo.ForeColor = Color.Black
        Else
            lblTipo.ForeColor = Color.Red
            falla = True
        End If

        If falla Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "Faltan campos por completar"
            mensajeAdvertencia.Show()
            'MsgBox("Falta completar campos")
        Else
            Dim Hora As New Entidades.Horas

            Hora.PHoras = txtHoras.Text
            Hora.PMinutos = txtMinutos.Text
            Hora.PHorarioId = horariosid

            If cmbTipo.SelectedIndex > 0 Then
                Hora.PTipo = CInt(cmbTipo.SelectedValue)
            End If


            Dim objHorasBU As New HorasBU
            objHorasBU.guardarHorariosHoras(Hora)
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()
            'MsgBox("Transaccion exitosa")


            'Me.Close()

            llenartabla()
            txtHoras.Text = ""
            cmbTipo.SelectedIndex = 0
            txtMinutos.Text = ""
            grdHoras.Rows.Clear()
            llenartabla()


        End If

    End Sub

    Private Sub txtHoras_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoras.KeyPress
        e.Handled = True

        If Char.IsDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtMinutos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMinutos.KeyPress
        e.Handled = True

        If Char.IsDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub

    Private Sub cmbTipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipo.KeyPress
        e.Handled = True

        If Char.IsDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub TabPage2_Click(sender As System.Object, e As System.EventArgs) Handles TabPage2.Click

    End Sub
    Public Sub InitCombos()



        'cmbTipo.Items.Clear()

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


        Dim objNavesBU As New Framework.Negocios.NavesBU
        Dim tablaNaves As New DataTable
        tablaNaves = objNavesBU.listaNavesActivas
        tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
        With cmbNave
            .DisplayMember = "nave_nombre"
            .ValueMember = "nave_naveid"
            .DataSource = tablaNaves
        End With
    End Sub


    Private Sub btnMenos_Click(sender As System.Object, e As System.EventArgs) Handles btnMenos.Click


        Dim horasid As Int32 = 0
        For Each fila As DataGridViewRow In grdHoras.SelectedRows
            For Each columna As DataGridViewCell In fila.Cells
                If (columna.OwningColumn.Name = "ColId") Then
                    horasid = CInt(columna.Value)
                End If
            Next
        Next
        'Dim formaEliminarHorarios As New EditarHorariosForm
        'formaEliminarHorarios.Dhorariosid = horasid
        'formaEliminarHorarios.Show()

        'Dim Hora As New Entidades.Horas


        'If cmbTipo.SelectedIndex > 0 Then
        '	Hora.PTipo = CInt(cmbTipo.SelectedValue)
        'End If
        Dim objHorasBU As New HorasBU
        objHorasBU.EliminarHorariosHoras(horasid)
        'MsgBox("Transaccion exitosa")


        'InitCombos()
        llenartabla()
        'Me.Close()


    End Sub
    'codigo prueba para eliminar registros


End Class