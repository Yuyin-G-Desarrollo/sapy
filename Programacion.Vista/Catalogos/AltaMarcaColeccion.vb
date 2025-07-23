Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AltaMarcaColeccion
    Dim coleccionGlobal As String
    Dim cmbClasificacion As New DataGridViewComboBoxColumn()
    Public Sub llenarComboAnios()
        Dim tempBu As New Negocios.TemporadasBU
        Dim dtDatosTemporadas As New DataTable
        dtDatosTemporadas = tempBu.verTemporadasRegistradas()
        dtDatosTemporadas.Rows.InsertAt(dtDatosTemporadas.NewRow(), 0)
        cmbTemporadas.DataSource = dtDatosTemporadas
        cmbTemporadas.ValueMember = "temp_temporadaid"
        cmbTemporadas.DisplayMember = "temp_nombre"
    End Sub

    Public Sub llenarlistaMarcas(ByVal anio As Int32)
        Dim MarcaBU As New Programacion.Negocios.MarcasBU
        Dim objCole As New Programacion.Negocios.ColeccionBU
        Dim dtDatosCheck As DataTable

        dtDatosCheck = New DataTable
        dtDatosCheck = MarcaBU.ComboMarcas()
        dtDatosCheck.Columns.Add("CodigoCole").SetOrdinal(2)
        dtDatosCheck.Columns.Add("Cliente")
        dtDatosCheck.Columns.Add("idCliente")

        For Each rowDt As DataRow In dtDatosCheck.Rows
            Dim dtDatosColeProd As New DataTable
            dtDatosColeProd = objCole.verColeccionesAnio(anio, CInt(rowDt.Item("marc_marcaid").ToString))
            'el valor que tiene es 99, pero el que trae la bd es mayor
            For contCods As Int32 = 1 To 99
                'For contCods As Int32 = 1 To 10000
                Dim codColeccion As String = ""
                Dim existe As Boolean = False
                If contCods <= 9 Then
                    codColeccion = "0" + contCods.ToString
                Else
                    codColeccion = contCods.ToString
                End If

                For Each rowDC As DataRow In dtDatosColeProd.Rows
                    If codColeccion = rowDC.Item("coma_codigo").ToString Then
                        existe = True
                    End If
                Next
                If existe = False Then
                    rowDt.Item("CodigoCole") = codColeccion
                    Exit For
                End If
            Next
        Next

        grdMarcas.DataSource = dtDatosCheck
        For Each rowGrd As DataGridViewRow In grdMarcas.Rows
            If rowGrd.Cells("CodigoCole").Value.ToString = "" Then
                'rowGrd.Cells("CodigoCole").Value = "Sin Código Asignado"
                rowGrd.Cells("CodigoCole").Value = "Sin Código"
                rowGrd.ReadOnly = True
            End If
        Next

        grdMarcas.Columns("marc_marcaid").Visible = False
        grdMarcas.Columns("idCliente").Visible = False
        grdMarcas.Columns("marc_escliente").Visible = False
        grdMarcas.Columns("marc_codigosicy").Visible = False
        grdMarcas.Columns("CodigoCole").Width = 50
        grdMarcas.Columns("Seleccion").Width = 50
        grdMarcas.Columns("Cliente").Width = 200
        grdMarcas.Columns("ColeccionYUYIN").Width = 250
        grdMarcas.Columns("MarcaYUYIN").Width = 100
        grdMarcas.Columns("FamiliaProyeccion").Width = 200
        grdMarcas.Columns("CodigoCole").HeaderText = "Código"
        grdMarcas.Columns("NaveDesarrolla").HeaderText = "Nave Desarrolla"
        grdMarcas.Columns("ColeccionYUYIN").HeaderText = "Colección Yuyin"
        grdMarcas.Columns("FamiliaProyeccion").HeaderText = "Familia Ventas"
        grdMarcas.Columns("MarcaYUYIN").HeaderText = "Marca Yuyin"
        grdMarcas.Columns("Código").Visible = False
        grdMarcas.Columns("CodigoCole").ReadOnly = True
        grdMarcas.Columns("Cliente").ReadOnly = True
        grdMarcas.Columns("Cliente").ReadOnly = True


        grdMarcas.Columns("Cliente").DisplayIndex = grdMarcas.Columns.Count - 4
        For Each rowGrd As DataGridViewRow In grdMarcas.Rows
            If CBool(rowGrd.Cells("marc_escliente").Value) = False Then
                rowGrd.Cells("MarcaYUYIN").ReadOnly = True
                rowGrd.Cells("ColeccionYUYIN").ReadOnly = True
                rowGrd.Cells("MarcaYUYIN").Style.BackColor = SystemColors.ScrollBar
                rowGrd.Cells("ColeccionYUYIN").Style.BackColor = SystemColors.ScrollBar
            End If
        Next

    End Sub

    Public Function ValidarVacio() As Boolean
        If (txtNombre.Text.Trim = Nothing Or cmbTemporadas.SelectedIndex = 0) Then
            If (txtNombre.Text.Trim = Nothing) Then
                lblNombre.ForeColor = Drawing.Color.Red
            Else
                lblNombre.ForeColor = Drawing.Color.Black
            End If

            If (cmbTemporadas.SelectedIndex = 0) Then
                lblAnio.ForeColor = Drawing.Color.Red
            Else
                lblAnio.ForeColor = Drawing.Color.Black
            End If

            Return False
        Else
            lblNombre.ForeColor = Drawing.Color.Black
            lblAnio.ForeColor = Drawing.Color.Black
            Return True
        End If

        Return True
    End Function

    'Public Function ValidarExistencia(ByVal idMarca As Int32) As Boolean
    '    Dim ColeccionNegocios As New Programacion.Negocios.ColeccionBU
    '    Dim dtMaxMarcCole As DataTable
    '    Dim dtMaxMarcDisponible As DataTable
    '    dtMaxMarcCole = New DataTable
    '    dtMaxMarcDisponible = New DataTable

    '   If (idMarca <> Nothing) Then
    '        dtMaxMarcCole = ColeccionNegocios.verMaximaMarcaColecion(idMarca)
    '        If dtMaxMarcCole.Rows(0)("codigo").ToString() = Nothing Then
    '            Return True
    '        Else
    '            If (Convert.ToInt32(dtMaxMarcCole.Rows(0)("codigo").ToString()) > 0 And Convert.ToInt32(dtMaxMarcCole.Rows(0)("codigo").ToString()) < 99) Then
    '                Return True
    '            ElseIf (dtMaxMarcCole.Rows(0)("codigo").ToString() >= 1 And dtMaxMarcCole.Rows(0)("codigo").ToString() >= 99) Then
    '                dtMaxMarcDisponible = ColeccionNegocios.VerCodigosMarcaDisponibles(idMarca)
    '                If (dtMaxMarcDisponible.Rows.Count = 0) Then
    '                    Return False
    '                End If
    '            End If
    '        End If
    '    End If

    '    Return True
    'End Function

    Public Sub DarAltaColeccion()

        Dim objColeBU As New Programacion.Negocios.ColeccionBU
        Dim coleNuevoID As Int32 = 0
        Dim idTemporada As Int32 = cmbTemporadas.SelectedValue
        Dim anio As Int32 = 0
        Dim objTempBu As New Negocios.TemporadasBU
        Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(cmbTemporadas.SelectedValue.ToString)
        Dim EtiquetaLengua As Boolean = False

        anio = CInt(dtAnioCombo.Rows(0).Item(0).ToString)

        Dim Coleccion As String = String.Empty
        Dim CodigoSicy As String = String.Empty
        Dim activo As Boolean = True
        Dim idMarca As Int32 = 0
        Dim idCliente As String = ""
        Coleccion = txtNombre.Text
        CodigoSicy = txtSicy.Text
        activo = CBool(rdoActivo.Checked)
        If RdbEtiquetaLenguaSI.Checked = True Then
            EtiquetaLengua = True
        Else
            EtiquetaLengua = False
        End If


        coleNuevoID = objColeBU.InsertarColeccion(Coleccion, anio, activo, idTemporada, EtiquetaLengua, CodigoSicy)


        If rdbEtiquetaEspecialSI.Checked = True Then
            objColeBU.InsertarColeccionEtiquetaEspecial(13, coleNuevoID, True)
        End If

        For Each fila As DataGridViewRow In grdMarcas.Rows
            If fila.Cells("Seleccion").Value = True Then
                idMarca = Convert.ToInt32(fila.Cells("marc_marcaid").Value.ToString())
                idCliente = fila.Cells("idCliente").Value.ToString()
                Dim marcaYuyin As String = ""
                Dim descripcionYuyin As String = ""
                Dim idFamiliaProyeccion As String = "0"
                Dim idNaveDesarrollo As Integer = 0
                Dim clasificacion As String = String.Empty

                If Not fila.Cells("MarcaYUYIN").Value Is Nothing Then
                    marcaYuyin = fila.Cells("MarcaYUYIN").Value.ToString
                End If

                If Not fila.Cells("ColeccionYUYIN").Value Is Nothing Then
                    descripcionYuyin = fila.Cells("ColeccionYUYIN").Value.ToString
                End If

                If Not fila.Cells("FamiliaProyeccion").Value Is Nothing Then
                    idFamiliaProyeccion = fila.Cells("FamiliaProyeccion").Value.ToString
                End If
                If Not fila.Cells("NaveDesarrolla").Value Is Nothing Then
                    idNaveDesarrollo = fila.Cells("NaveDesarrolla").Value.ToString
                End If

                If Not fila.Cells("Clasificación").Value Is Nothing Then
                    clasificacion = fila.Cells("Clasificación").Value.ToString
                End If


                If idCliente = "" Then
                    idCliente = 0
                End If

                'hay que mandar el valor aqu+i para oinsertar la clasificación
                If idMarca = 6 Or idMarca = 7 Or idMarca = 8 Then
                    If marcaYuyin = "0" Or marcaYuyin = "" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione una marca Yuyin.")
                    Else
                        objColeBU.InsertarColeccionMarca(coleNuevoID, idMarca, fila.Cells("CodigoCole").Value.ToString(), CodigoSicy, activo, anio, idCliente, marcaYuyin, descripcionYuyin, idFamiliaProyeccion, idNaveDesarrollo, clasificacion)
                    End If
                Else
                    objColeBU.InsertarColeccionMarca(coleNuevoID, idMarca, fila.Cells("CodigoCole").Value.ToString(), CodigoSicy, activo, anio, idCliente, marcaYuyin, descripcionYuyin, idFamiliaProyeccion, idNaveDesarrollo, clasificacion)
                End If


                If fila.Cells("marc_codigosicy").Value.ToString <> "0" Then

                    Dim idMarcaSIcy As String = fila.Cells("marc_codigosicy").Value.ToString
                    If CodigoSicy <> "" Then

                        If fila.Cells("FamiliaProyeccion").Value.ToString <> "0" Then
                            'If fila.Cells("FamiliaProyeccion").Value.ToString <> fila.Cells("familiaAntes").Value.ToString Then

                            'hay que insertar clasificación para poder mandar llamar al mnétodo 
                            objColeBU.editarMarcaColeccionMismaFamilia(fila.Cells("marc_marcaid").Value().ToString, CodigoSicy, fila.Cells("FamiliaProyeccion").Value.ToString, fila.Cells("NaveDesarrolla").Value.ToString, clasificacion)

                            'End If
                            'objColeBU = New Negocios.ColeccionBU
                            'objColeBU.inactivarColeccionesClienteSicyCambioFamilia(idMarcaSIcy, CodigoSicy)
                            'objColeBU.ejecutarRegistroCambioFamiliasAgenteColeccionSICY(fila.Cells("marc_marcaid").Value().ToString, fila.Cells("FamiliaProyeccion").Value.ToString)
                        End If

                    End If

                End If
                'End If

            End If
        Next

        Dim mensaje As New ExitoForm
        mensaje.mensaje = "El registro se realizó con éxito."
        mensaje.ShowDialog()
        Me.Close()

    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contadorSeleccionados As Int32 = 0
        Dim clasificacionSeleccionada As Int32 = 0
        For Each rowS As DataGridViewRow In grdMarcas.Rows
            If rowS.Cells("Seleccion").Value = True Then
                contadorSeleccionados = contadorSeleccionados + 1
                If (Not rowS.Cells("Clasificación").Value Is Nothing) And rowS.Cells("FamiliaProyeccion").Value <> Nothing Then
                    clasificacionSeleccionada += 1
                End If
            End If
        Next
        If (contadorSeleccionados >= 1) Then
            If clasificacionSeleccionada = contadorSeleccionados Then

                If (ValidarVacio() = True) Then
                    Dim objMensajeQ As New ConfirmarForm
                    objMensajeQ.mensaje = "¿Está seguro de guardar cambios? (Esta acción puede tardar algunos minutos debido a que actualiza registros del SICY, si decide aceptar el cambio por favor espere.)"
                    If objMensajeQ.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        DarAltaColeccion()
                        Me.Cursor = Cursors.Default
                    End If
                ElseIf (ValidarVacio() = False) Then
                End If
            Else
                Dim adv As New AdvertenciaForm
                adv.mensaje = "Hace falta seleccionar una familia de ventas y/o una clasificación en algún registro seleccionado."
                adv.ShowDialog()
            End If
        Else
            Dim adv As New AdvertenciaForm
            adv.mensaje = "Debe seleccionar al menos una marca."
            adv.ShowDialog()
        End If
    End Sub

    Private Sub AltaMarcaColeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtMarcasYuyin As New DataTable
        Dim objMBU As New Negocios.MarcasBU

        Dim objFamProy As New Negocios.FamiliaProyeccionBU
        Dim dtFamiliasProyeccion As New DataTable

        grdMarcas.AllowUserToAddRows = False
        'grdMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        rdoActivo.Checked = True
        txtNombre.Text = String.Empty
        llenarComboAnios()

        'Llena los combos del grid y añade el título de cada columna         
        dtFamiliasProyeccion = objFamProy.consultaFamiliasProyeccion(True)
        dtFamiliasProyeccion.Rows.InsertAt(dtFamiliasProyeccion.NewRow, 0)
        Dim cmbFamiliaProyeccion As New DataGridViewComboBoxColumn()
        cmbFamiliaProyeccion.Name = "FamiliaProyeccion"
        cmbFamiliaProyeccion.DataSource = dtFamiliasProyeccion
        cmbFamiliaProyeccion.DisplayMember = "fapr_descripcion"
        cmbFamiliaProyeccion.ValueMember = "fapr_familiaproyeccionid"
        grdMarcas.Columns.Add(cmbFamiliaProyeccion)

        Dim dtNaveDes As New DataTable
        dtNaveDes = objFamProy.getNavesDesarrolla()
        dtNaveDes.Rows.InsertAt(dtNaveDes.NewRow, 0)
        Dim cmbNave As New DataGridViewComboBoxColumn()
        cmbNave.Name = "NaveDesarrolla"
        cmbNave.DataSource = dtNaveDes
        cmbNave.DisplayMember = "nave_nombre"
        cmbNave.ValueMember = "nave_naveid"
        grdMarcas.Columns.Add(cmbNave)

        Dim dtclasificacion As New DataTable
        dtclasificacion = objFamProy.getClasificacion()
        dtclasificacion.Rows.InsertAt(dtclasificacion.NewRow, 0)
        'Dim cmbClasificacion As New DataGridViewComboBoxColumn()
        cmbClasificacion.Name = "Clasificación"
        cmbClasificacion.DataSource = dtclasificacion
        cmbClasificacion.DisplayMember = "cocl_clasificacion"
        cmbClasificacion.ValueMember = "cocl_clasificacion"
        grdMarcas.Columns.Add(cmbClasificacion)

        dtMarcasYuyin = objMBU.verMarcasYuyin
        dtMarcasYuyin.Rows.InsertAt(dtMarcasYuyin.NewRow, 0)
        Dim cmb As New DataGridViewComboBoxColumn()
        cmb.Name = "MarcaYUYIN"
        cmb.DataSource = dtMarcasYuyin
        cmb.DisplayMember = "marc_descripcion"
        cmb.ValueMember = "marc_marcaid"
        grdMarcas.Columns.Add(cmb)

        Dim cmtxt As New DataGridViewTextBoxColumn()
        cmtxt.Name = "ColeccionYUYIN"
        grdMarcas.Columns.Add(cmtxt)

        Dim objColeBU As New Negocios.ColeccionBU
        txtSicy.Text = objColeBU.EncontrarColeccionSICY(1)(0)(0)

        grdMarcas.Columns("FamiliaProyeccion").DisplayIndex = grdMarcas.Columns.Count - 4
        grdMarcas.Columns("NaveDesarrolla").DisplayIndex = grdMarcas.Columns.Count - 4
        grdMarcas.Columns("Clasificación").DisplayIndex = grdMarcas.Columns.Count - 3
        grdMarcas.Columns("MarcaYUYIN").DisplayIndex = grdMarcas.Columns.Count - 2
        grdMarcas.Columns("ColeccionYUYIN").DisplayIndex = grdMarcas.Columns.Count - 1
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtNombre.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtNombre.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdMarcas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMarcas.CellDoubleClick
        Try
            If grdMarcas.Columns(e.ColumnIndex).Name = "Cliente" Then
                Dim objClientes As New ListaConsultaClientesForm
                objClientes.accionFormulario = "consultaCColeccion"
                objClientes.idMarca = CInt(grdMarcas.Rows(e.RowIndex).Cells("marc_marcaid").Value)
                objClientes.ShowDialog()
                grdMarcas.Rows(e.RowIndex).Cells("idCliente").Value = CStr(objClientes.pIdClienteList)
                grdMarcas.Rows(e.RowIndex).Cells("Cliente").Value = objClientes.pNombreCliente
            End If
        Catch ex As Exception
            MsgBox("Ocurrió algo inesperado.")
        End Try
    End Sub

    Private Sub grdMarcas_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdMarcas.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
            e.Control.ForeColor = Color.Coral
        End If
    End Sub

    Private Sub ValidarEntradaDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columnIndex As Integer = grdMarcas.CurrentCell.ColumnIndex()
        If columnIndex = 1 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)

            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        ElseIf columnIndex = 9 Then
            Dim caracter As Char = e.KeyChar
            Dim txt As TextBox = CType(sender, TextBox)
            If txt.Text.Length <= 50 Then
                If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If caracter = ChrW(Keys.Back) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        rdoActivo.Checked = True
    End Sub
    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged

    End Sub

    Private Sub txtSicy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSicy.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtSicy.Text.Length < 2) Then
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space)) Or (caracter = ("-")) Or (caracter = ("/")) Or (caracter = (".")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtSicy.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cmbTemporadas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTemporadas.SelectedIndexChanged
        If Not cmbTemporadas.SelectedIndex = 0 Then
            Dim anio As Int32 = 0
            Dim objTempBu As New Negocios.TemporadasBU
            Dim dtAnioCombo As DataTable = objTempBu.consultaAnioTemporada(cmbTemporadas.SelectedValue.ToString)
            anio = CInt(dtAnioCombo.Rows(0).Item(0).ToString)
            llenarlistaMarcas(anio)
            grdMarcas.Columns("FamiliaProyeccion").DisplayIndex = grdMarcas.Columns.Count - 4
            grdMarcas.Columns("NaveDesarrolla").DisplayIndex = grdMarcas.Columns.Count - 4
            grdMarcas.Columns("Clasificación").DisplayIndex = grdMarcas.Columns.Count - 3
            grdMarcas.Columns("MarcaYUYIN").DisplayIndex = grdMarcas.Columns.Count - 2
            grdMarcas.Columns("ColeccionYUYIN").DisplayIndex = grdMarcas.Columns.Count - 1
            grdMarcas.Columns("seleccion").Width = 40


        Else
            grdMarcas.DataSource = Nothing
        End If
    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub grdMarcas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdMarcas.CellContentClick

    End Sub

    Private Sub grdMarcas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdMarcas.KeyPress
        'Dim cadena As String
        'cadena = " " & e.KeyChar
        'If grdMarcas.Rows.Count > 0 Then
        '    Try
        '        If grdMarcas.CurrentCell.ColumnIndex.ToString = "" Then

        '        End If
        '        If Char.IsLetterOrDigit(e.KeyChar) Then
        '            e.Handled = False
        '        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
        '            e.Handled = False
        '        Else
        '            e.Handled = True
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End If
    End Sub

    'Private Sub RdbEtiquetaLenguaSI_CheckedChanged(sender As Object, e As EventArgs) Handles RdbEtiquetaLenguaSI.CheckedChanged
    '    If RdbEtiquetaLenguaSI.Checked = True Then
    '        rdbEtiquetaEspecialSI.Enabled = True
    '        rdbEtiquetaEspecialNO.Enabled = True
    '        lblEtiquetaEspecial.Enabled = True
    '    Else
    '        rdbEtiquetaEspecialSI.Enabled = False
    '        rdbEtiquetaEspecialNO.Enabled = False
    '        lblEtiquetaEspecial.Enabled = False
    '    End If
    'End Sub

    Private Sub RdbEtiquetaLenguaSI_CheckedChanged(sender As Object, e As EventArgs) Handles RdbEtiquetaLenguaSI.CheckedChanged
        rdbEtiquetaEspecialSI.Enabled = True
        rdbEtiquetaEspecialNO.Enabled = True
    End Sub

    Private Sub rdbEtiquetaLenguaNO_CheckedChanged(sender As Object, e As EventArgs) Handles rdbEtiquetaLenguaNO.CheckedChanged
        rdbEtiquetaEspecialNO.Checked = True
        rdbEtiquetaEspecialSI.Enabled = False
        rdbEtiquetaEspecialNO.Enabled = False
    End Sub

End Class