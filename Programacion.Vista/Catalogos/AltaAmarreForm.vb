Imports Tools

Public Class AltaAmarreForm
    Dim dtDatosAmarre As DataTable
    Public IdTalla As Int32
    Dim ValidaTam As Int32
    Dim dtValidaAmarreExiste As DataTable
    Dim MIint As Int32 = 0
    Dim MIotroint As Int32 = 4

    Public Sub TraerDatosTallaEditar()
        Dim TallaNegocio As New Programacion.Negocios.TallasBU
        grdTablaAmarre.DataSource = Nothing
        dtDatosAmarre = New DataTable
        dtValidaAmarreExiste = New DataTable
        dtValidaAmarreExiste = TallaNegocio.VerAmarreExisteTalla(IdTalla)
        dtDatosAmarre = TallaNegocio.verDatosTallaEditar(IdTalla)
        Dim nuevaRow As DataRow = dtDatosAmarre.NewRow
        Dim contMedias As Int32 = 0
        dtDatosAmarre.Rows.InsertAt(nuevaRow, 2)
        nuevaRow = dtDatosAmarre.NewRow
        dtDatosAmarre.Rows.InsertAt(nuevaRow, 3)
        nuevaRow = dtDatosAmarre.NewRow
        dtDatosAmarre.Rows.InsertAt(nuevaRow, 4)
        ValidaTam = dtValidaAmarreExiste.Rows.Count
        txtCodigo.Text = dtDatosAmarre.Rows(0)(0).ToString
        txtNumeracion.Text = dtDatosAmarre.Rows(0)(1).ToString
        txtTallaInicial.Text = dtDatosAmarre.Rows(0)(2).ToString
        txtTallaFinal.Text = dtDatosAmarre.Rows(0)(3).ToString
        txtTallaCentral.Text = dtDatosAmarre.Rows(0)(25).ToString
        ckbEnteros.Checked = CBool(dtDatosAmarre.Rows(0)(27).ToString)


        For Each rowDtAmr As DataRow In dtValidaAmarreExiste.Rows
            If Not (rowDtAmr.Item(0).ToString = Nothing) Then
                contMedias = contMedias + 1
            End If
            If Not (rowDtAmr.Item(1).ToString = Nothing) Then
                contMedias = contMedias + 1
            End If
        Next

        If (contMedias > 0) Then
            ckbMedias.Checked = True
        Else
            ckbMedias.Checked = False
        End If

        grdTablaAmarre.DataSource = dtDatosAmarre
        Me.grdTablaAmarre.Rows(0).HeaderCell.Value = "Talla"
        Me.grdTablaAmarre.Rows(1).HeaderCell.Value = "Total"
        Me.grdTablaAmarre.Rows(2).HeaderCell.Value = "Media 1"
        Me.grdTablaAmarre.Rows(3).HeaderCell.Value = "Media 2"
        grdTablaAmarre.Columns("talla_sicy").Visible = False

        Dim CampoRecorre As Int32 = 0
        Dim recorre As Int32 = 0
        Dim espacioGrid As Int32 = 4

        For CampoRecorre = 0 To 29
            grdTablaAmarre.Item(CampoRecorre, 0).ReadOnly = True
            grdTablaAmarre.Rows(1).DefaultCellStyle.BackColor = Drawing.SystemColors.ControlLight

            If (dtDatosAmarre.Rows(0)(CampoRecorre).ToString <> Nothing) Then
                If (recorre > ValidaTam - 1) Then

                ElseIf (ValidaTam >= 1) Then
                    'grdTablaAmarre.Item(espacioGrid, 1).Value = Convert.ToInt32(dtValidaAmarreExiste.Rows(recorre)(0).ToString) + Convert.ToInt32(dtValidaAmarreExiste.Rows(recorre)(1).ToString)
                    If (ckbMedias.Checked = True) Then
                        grdTablaAmarre.Item(espacioGrid, 2).Value = dtValidaAmarreExiste.Rows(recorre)(0).ToString
                        grdTablaAmarre.Item(espacioGrid, 3).Value = dtValidaAmarreExiste.Rows(recorre)(1).ToString
                    End If

                    grdTablaAmarre.Item(espacioGrid, 1).Value = dtValidaAmarreExiste.Rows(recorre)(2).ToString
                    recorre = recorre + 1
                    espacioGrid = espacioGrid + 1
                End If
            End If
            If (dtDatosAmarre.Rows(0)(CampoRecorre).ToString = Nothing) Then
                grdTablaAmarre.Columns(CampoRecorre).Visible = False
            End If
        Next

        If (ckbMedias.Checked = False) Then
            grdTablaAmarre.Rows(2).Visible = False
            grdTablaAmarre.Rows(3).Visible = False
        End If

        For n As Int32 = 0 To 29
            If (grdTablaAmarre.Item(n, 1).Value.ToString = Nothing) Then
                grdTablaAmarre.Item(n, 1).Value = 0
            End If
            If (grdTablaAmarre.Item(n, 2).Value.ToString = Nothing) Then
                grdTablaAmarre.Item(n, 2).Value = 0
            End If
            If (grdTablaAmarre.Item(n, 3).Value.ToString = Nothing) Then
                grdTablaAmarre.Item(n, 3).Value = 0
            End If
        Next

        grdTablaAmarre.Columns("Talla").Visible = False
        grdTablaAmarre.Columns("Inicio").Visible = False
        grdTablaAmarre.Columns("Fin").Visible = False
        grdTablaAmarre.Columns("Tallabase").Visible = False
        grdTablaAmarre.Columns("talla_tallaid").Visible = False
        grdTablaAmarre.Columns("talla_tallacentral").Visible = False
        grdTablaAmarre.Columns("Grupo").Visible = False
        grdTablaAmarre.Columns("pais").Visible = False
        grdTablaAmarre.Columns("activo").Visible = False
        grdTablaAmarre.Columns("EnterosT").Visible = False
        Dim alinea As Int32 = 4
        For alinea = 4 To 24
            CType(Me.grdTablaAmarre.Columns(alinea), DataGridViewTextBoxColumn).MaxInputLength = 1
            Me.grdTablaAmarre.Columns(alinea).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        Next
    End Sub

    Public Sub ValidarVacio()
        Dim CampoRecorreUno As Int32 = 0
        Dim CampoRecorreDos As Int32 = 0
        Dim sumaUno As Int32 = 0
        Dim sumaDos As Int32 = 0
        Dim resultado As Int32 = 0
        Dim ValidaCantidad As Boolean = True
        Dim espacioGrid As Int32 = 0
        Dim RecorreRegistra As Int32 = 4
        Dim mensaje As New AdvertenciaForm
        Dim TallaBU As New Programacion.Negocios.TallasBU
        For CampoRecorreUno = 0 To 29
            If (grdTablaAmarre.Item(CampoRecorreUno, 2).Value.ToString = Nothing) Then
                grdTablaAmarre.Item(CampoRecorreUno, 2).Value = 0
            End If
            If (grdTablaAmarre.Item(CampoRecorreUno, 3).Value.ToString = Nothing) Then
                grdTablaAmarre.Item(CampoRecorreUno, 3).Value = 0
            End If
        Next


        For CampoRecorreDos = 0 To 29
            sumaUno = sumaUno + grdTablaAmarre.Item(CampoRecorreDos, 2).Value
            If (sumaUno > 6) Then
                mensaje.mensaje = "Media 1 excede los 6 amarres."
                mensaje.ShowDialog()
                ValidaCantidad = False
                Exit Sub
            End If
            sumaDos = sumaDos + grdTablaAmarre.Item(CampoRecorreDos, 3).Value
            If (sumaDos > 6) Then
                mensaje.mensaje = "Media 2 excede los 6 amarres."
                mensaje.ShowDialog()
                ValidaCantidad = False
                Exit Sub
            End If
        Next
        resultado = sumaUno + sumaDos

        If (resultado > 12) Then
            mensaje.mensaje = "La cantidad de amarres por talla no puede revasar los 12 pares."
            mensaje.ShowDialog()
            ValidaCantidad = False
        ElseIf (resultado < 12) Then

            mensaje.mensaje = "La cantidad de amarres no puede ser menor a 12 pares."
            mensaje.ShowDialog()
            ValidaCantidad = False
        ElseIf (resultado = 12) Then
            ValidaCantidad = True
        End If

        If (ValidaCantidad = True) Then
            TallaBU.AlterarAmarresBU(IdTalla)

            For RecorreRegistra = 4 To 25
                If (dtDatosAmarre.Rows(0)(RecorreRegistra).ToString <> Nothing Or dtDatosAmarre.Rows(0)(RecorreRegistra).ToString <> "0") Then
                    If (grdTablaAmarre.Columns(RecorreRegistra).Visible = False) Then
                        Exit For
                    End If
                    'MsgBox("IdTalla: " + IdTalla.ToString + "    descripcion: " + grdTablaAmarre.Item(RecorreRegistra, 0).Value.ToString + "    Amarre 1: " + grdTablaAmarre.Item(RecorreRegistra, 2).Value.ToString + "    Amarre2: " + grdTablaAmarre.Item(RecorreRegistra, 3).Value.ToString)
                    TallaBU.AltaAmarreBU(IdTalla, grdTablaAmarre.Item(RecorreRegistra, 0).Value.ToString, Convert.ToInt32(grdTablaAmarre.Item(RecorreRegistra, 2).Value.ToString), Convert.ToInt32(grdTablaAmarre.Item(RecorreRegistra, 3).Value.ToString), Convert.ToInt32(grdTablaAmarre.Item(RecorreRegistra, 1).Value.ToString))
                End If
            Next

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = "El registro se realizó con éxito."
            mensajeExito.ShowDialog()
            Me.Close()
        ElseIf (ValidaCantidad = False) Then

        End If
    End Sub


    Public Sub LlenarSumas()
        Dim CampoRecorreUno As Int32 = 4
        For CampoRecorreUno = 4 To 29

            If (grdTablaAmarre.Item(CampoRecorreUno, 1).Selected = True) Then
                If (grdTablaAmarre.Item(CampoRecorreUno, 1).Value < grdTablaAmarre.Item(CampoRecorreUno, 3).Value) Then
                    grdTablaAmarre.Item(CampoRecorreUno, 3).Value = 0
                End If
                If (grdTablaAmarre.Item(CampoRecorreUno, 1).Value < grdTablaAmarre.Item(CampoRecorreUno, 2).Value) Then
                    grdTablaAmarre.Item(CampoRecorreUno, 2).Value = 0
                End If
                grdTablaAmarre.Item(CampoRecorreUno, 2).Value = (Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 1).Value) - Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 3).Value)).ToString
                grdTablaAmarre.Item(CampoRecorreUno, 3).Value = (Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 1).Value) - Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 2).Value)).ToString
            End If

            If (grdTablaAmarre.Item(CampoRecorreUno, 2).Selected = True) Then
                grdTablaAmarre.Item(CampoRecorreUno, 1).Value = (Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 2).Value) + Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 3).Value)).ToString
                grdTablaAmarre.Item(CampoRecorreUno, 3).Value = (Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 1).Value) - Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 2).Value)).ToString
            End If

            If (grdTablaAmarre.Item(CampoRecorreUno, 3).Selected = True) Then
                grdTablaAmarre.Item(CampoRecorreUno, 1).Value = (Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 2).Value) + Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 3).Value)).ToString
                grdTablaAmarre.Item(CampoRecorreUno, 2).Value = (Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 1).Value) - Convert.ToInt32(grdTablaAmarre.Item(CampoRecorreUno, 3).Value)).ToString
            End If
        Next

    End Sub


    Private Sub AltaAmarreForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub



    Private Sub AltaAmarreForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdTablaAmarre.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdTablaAmarre.AllowUserToAddRows = False
        TraerDatosTallaEditar()
    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub



    Private Sub grdTablaAmarre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdTablaAmarre.CellEndEdit

        'If (grdTablaAmarre.IsCurrentCellDirty) Then
        '    grdTablaAmarre.CommitEdit(DataGridViewDataErrorContexts.Commit)
        'End If

        If (e.ColumnIndex >= 4 And e.ColumnIndex < 29) Then


            If (ValidaTam >= 1) Then
            ElseIf (ValidaTam <= 0) Then
                lblMensaje.Text = "Talla sin amarre registrado."
            End If

            If (e.RowIndex = 1) Then
                grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                If (grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value <> 0) Then

                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0) Then
                        If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value < grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                            grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value)
                            'Else
                            '    grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value
                        End If
                    End If
                    If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0) Then
                        If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value < grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                            grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                            'Else
                            '    grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value
                        End If
                    End If
                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <> 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <> 0) Then
                        grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                    End If
                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0 And grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0) Then
                        grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value)
                    End If
                Else
                    grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                    grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                End If
            ElseIf (e.RowIndex = 2) Then
                If (grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value <> 0) Then
                    If (grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value <= grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                        grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value)
                    Else
                        grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) + CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                    End If
                Else
                    grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                    grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value = 0
                End If

            ElseIf (e.RowIndex = 3) Then

                If (grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value <> 0) Then
                    If (grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value <= grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) Then
                        grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value) - CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)
                    Else
                        grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value = CInt(grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value) + CInt(grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value)

                    End If
                Else
                    grdTablaAmarre.Rows(1).Cells(e.ColumnIndex).Value = grdTablaAmarre.Rows(3).Cells(e.ColumnIndex).Value
                    grdTablaAmarre.Rows(2).Cells(e.ColumnIndex).Value = 0
                End If

            End If

        End If
    End Sub


    Private Sub grdTablaAmarre_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdTablaAmarre.EditingControlShowing
        Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
        AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidaCaracteresGRD_KeyPress

    End Sub

    Private Sub ValidaCaracteresGRD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdTablaAmarre.KeyPress
        Dim columnIndex As Integer = grdTablaAmarre.CurrentCell.ColumnIndex()
        Try
            If columnIndex = 4 Or columnIndex = 5 Or columnIndex = 6 Or columnIndex = 7 Or columnIndex = 8 Or columnIndex = 9 Or columnIndex = 10 Or columnIndex = 11 Or columnIndex = 12 Or
            columnIndex = 13 Or columnIndex = 14 Or columnIndex = 15 Or columnIndex = 16 Or columnIndex = 17 Or columnIndex = 18 Or columnIndex = 19 Or
            columnIndex = 20 Or columnIndex = 21 Or columnIndex = 22 Or columnIndex = 23 Or columnIndex = 24 Or columnIndex = 25 Then
                Dim caracter As Char = e.KeyChar
                Dim txt As TextBox = CType(sender, TextBox)
                If (Char.IsDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class