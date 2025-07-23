Imports Tools

Public Class AltasExcepcionesHorariosForm
    Dim fecha As Date
    Dim hayfecha As Boolean
    Private Sub MonthCalendar1_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles dtpFecha.DateChanged
        fecha = dtpFecha.SelectionStart
        hayfecha = True
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Dim falla As Boolean = False
        If txtNombre.Text <> "" Then

            lblNombre.ForeColor = Color.Black
        Else


            lblNombre.ForeColor = Color.Red
            falla = True

        End If

        If hayfecha Then

            lblFecha.ForeColor = Color.Black
        Else


            lblFecha.ForeColor = Color.Red
            falla = True

        End If

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
            Excepcion.PFecha = fecha

            If cmbTipo.Text = "Entrada" Then
                Excepcion.PTipo = 1
            Else
                Excepcion.PTipo = 2
            End If

            'Excepcion.PTipo = cmbTipo.Text
            Excepcion.PActivo = btnSi.Checked


            If cmbHorario.SelectedIndex > 0 Then
                horarios.DHorariosid = cmbHorario.SelectedIndex

                Excepcion.PHorario = horarios


            End If
            Dim objexeBU As New Negocios.ExcepcionesHorariosBU
            objexeBU.ALtashexc(Excepcion)
            Me.Close()
            Dim mensajeExito As New ExitoForm
            mensajeExito.MdiParent = Me.MdiParent
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()
            'MsgBox("Transaccion exitosa")
            Me.Close()
        End If

    End Sub
    Public Sub InitCombos()
        Dim objHorariosBU As New Negocios.HorariosBU
        Dim tablaHorarios As New DataTable
        tablaHorarios = objHorariosBU.listaHorariosActivos
        tablaHorarios.Rows.InsertAt(tablaHorarios.NewRow, 0)
        With cmbHorario
            .DisplayMember = "hora_nombre"
            .ValueMember = "hora_horariosid"
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

    End Sub

    Private Sub AltasExcepcionesHorariosForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        InitCombos()
    End Sub

    Private Sub btnCncelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub txtNombre_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbHorario_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbHorario.KeyPress

        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub cmbTipo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTipo.KeyPress
        e.Handled = True
        If Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub
End Class