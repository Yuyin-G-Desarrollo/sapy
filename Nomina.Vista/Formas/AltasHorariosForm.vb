Imports Nomina.Negocios
Imports Tools


Public Class AltasHorariosForm

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click

        Dim falla As Boolean = False
        If txtNombreDeLHorario.Text <> "" Then

            lblNombreDelHorario.ForeColor = Color.Black
        Else


            lblNombreDelHorario.ForeColor = Color.Red
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
            horario.DNombre = txtNombreDeLHorario.Text
            horario.DActivo = btnSi.Checked

            If cmbNave.SelectedIndex > 0 Then
                Nave.PNaveId = CInt(cmbNave.SelectedValue)
                horario.PNaves = Nave

            End If

            Dim objHorariosBU As New HorariosBU
            objHorariosBU.guardarHorarios(horario)

            Me.Close()

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "Transaccion exitosa"
            mensajeExito.Show()

            'MsgBox("Transaccion exitosa")
            'Me.Close()
        End If

        Dim horarios As New Entidades.Horarios

        Dim objHorarioBU As New HorariosBU
        'objHorarioBU.altashorarios(horarios)

        'Mandar llamar el método que trae el MAX id (ultimo registro insertado)
        'Este metodo debe devolver un valor entero que es el id del horario recien insertado

        Dim formaEditarHorarios As New EditarHorariosForm
        formaEditarHorarios.Dhorariosid = objHorarioBU.buscarHorarioId

        formaEditarHorarios.Show()
        'Me.Close()
    End Sub
    Public Sub initCombos()
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

    Private Sub btnCncelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub AltasHorariosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initCombos()
    End Sub

End Class