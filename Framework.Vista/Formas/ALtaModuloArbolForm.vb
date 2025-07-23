Public Class ALtaModuloArbolForm
    Public idModuloSuperiorArbol As String

    Public Sub llenarComboSuperiores()
        Dim objMod As New Framework.Negocios.ModulosBU
        Dim dtDatosSuperiores As New DataTable
        dtDatosSuperiores = objMod.ListaModulosTodos
        dtDatosSuperiores.Rows.InsertAt(dtDatosSuperiores.NewRow, 0)
        With cmbModSuperior
            .DataSource = dtDatosSuperiores
            .DisplayMember = "modu_nombre"
            .ValueMember = "modu_moduloid"
        End With
        If (idModuloSuperiorArbol <> "") Then
            cmbModSuperior.SelectedValue = idModuloSuperiorArbol
        End If
    End Sub

    Public Sub primeraFilaLectura()
        grdAcciones.Rows.Add(1)
        grdAcciones.Item(0, 0).Value = ""
        grdAcciones.Item(1, 0).Value = "Lectura"
        grdAcciones.Item(2, 0).Value = ""
        grdAcciones.Item(3, 0).Value = "READ"
        grdAcciones.Item(4, 0).Value = "Consultar"
        grdAcciones.Item(1, 0).ReadOnly = True
        grdAcciones.Item(3, 0).ReadOnly = True
        grdAcciones.Item(4, 0).ReadOnly = True
        grdAcciones.Item(5, 0).ReadOnly = True
    End Sub


    Public Sub quitarRegistrosDetalle()
        Dim recorre As Int32 = 0
        Dim tamanoGrid As Int32 = grdAcciones.Rows.Count - 1
        Dim x As Int32 = 0
        For x = (grdAcciones.Rows.Count - 1) To 0 Step -1
            If (Convert.ToBoolean(grdAcciones.Rows(x).Cells(5).Value) = True) Then
                grdAcciones.Rows.RemoveAt(x)
            End If
        Next
    End Sub

    Public Function validaRepetidosModulo() As Boolean
        Dim objMod As New Framework.Negocios.ModulosBU
        Dim dtContadorModulos As New DataTable
        Dim contadorMod As Int32 = 0
        Dim modulo As String = txtNombreModulo.Text
        Dim idSuperior As String = ""
        If (cmbModSuperior.SelectedValue IsNot Nothing) Then
            idSuperior = cmbModSuperior.SelectedValue.ToString
        End If
        dtContadorModulos = objMod.valoidarRepetidos(modulo, idSuperior)
        contadorMod = Convert.ToInt32(dtContadorModulos.Rows(0)(0).ToString)
        If (contadorMod >= 1) Then
            Return False
        End If
        Return True
    End Function
    Public Function validarFilasVacias() As Boolean
        Dim cont As Int32 = 0
        For Each row As DataGridViewRow In grdAcciones.Rows
            If (row.Cells(1).Value Is Nothing Or row.Cells(3).Value Is Nothing Or row.Cells(4).Value Is Nothing) Then
                cont = cont + 1
            End If
        Next
        If cont > 1 Then
            Return False
        End If
        Return True
    End Function

    Public Sub guardarModulo()
        Dim objMod As New Framework.Negocios.ModulosBU
        Dim dtIdMaximoModRegistrado As New DataTable
        Dim idNuevoMod As Int32 = 0
        Dim enModulo As New Entidades.Modulos
        Dim modulo As New Entidades.Modulos
        Dim objAct As New Framework.Negocios.AccionesBU

        If (cmbModSuperior.SelectedValue IsNot Nothing) Then
            modulo.PModuloid = CInt(cmbModSuperior.SelectedValue.ToString)
        Else
            modulo.PModuloid = 0
        End If
        enModulo.PSuperiorid = modulo
        enModulo.PNombre = txtNombreModulo.Text
        enModulo.PIcono = txtIcono.Text
        enModulo.PGuardarHistorial = True
        enModulo.PComponente = txtComponente.Text
        enModulo.PClave = txtClave.Text
        enModulo.PArchivoReporte = ""
        enModulo.PComponenteWeb = txtComponenteWEB.Text
        enModulo.PImagenWeb = txtIconoWEB.Text
        enModulo.PModuloWeb = CBool(chkEsWeb.Checked)
        enModulo.PModuloEscritorio = CBool(chkEscritorio.Checked)

        If (rdoActivo.Checked = True) Then
            enModulo.PActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            enModulo.PActivo = False
        End If
        If (rdoMostrarEnMenu.Checked = True) Then
            enModulo.PMenu = True
        ElseIf (rdoNoMostrar.Checked = True) Then
            enModulo.PMenu = False
        End If

        dtIdMaximoModRegistrado = objMod.AgregarModuloArbol(enModulo)
        idNuevoMod = CInt(dtIdMaximoModRegistrado.Rows(0)(0).ToString)

        Dim enAcciones As New Entidades.Acciones

        For Each row As DataGridViewRow In grdAcciones.Rows
            If (row.Cells(1).Value IsNot Nothing And row.Cells(3).Value IsNot Nothing) Then
                Dim modSuperior As New Entidades.Modulos
                enAcciones.PActivo = True
                enAcciones.PNombre = row.Cells(1).Value.ToString
                If (row.Cells(0).Value IsNot Nothing) Then
                    enAcciones.PComponente = row.Cells(0).Value.ToString
                Else
                    enAcciones.PComponente = ""
                End If
                If (row.Cells(2).Value IsNot Nothing) Then
                    enAcciones.PIcono = row.Cells(2).Value.ToString
                Else
                    enAcciones.PIcono = ""
                End If

                enAcciones.PClave = row.Cells(3).Value.ToString

                If (row.Cells(4).Value.ToString = "Consultar") Then
                    enAcciones.PTipo = 1
                ElseIf (row.Cells(4).Value.ToString = "Altas") Then
                    enAcciones.PTipo = 2
                ElseIf (row.Cells(4).Value.ToString = "Editar") Then
                    enAcciones.PTipo = 3
                ElseIf (row.Cells(4).Value.ToString = "Eliminar") Then
                    enAcciones.PTipo = 4
                ElseIf (row.Cells(4).Value.ToString = "Otros") Then
                    enAcciones.PTipo = 0
                End If
                modSuperior.PModuloid = idNuevoMod
                enAcciones.PModulo = modSuperior

                objAct.AltasAcciones(enAcciones)
            End If
        Next

        'objMod .AgregarModuloArbol (
    End Sub

    Public Function validarCheckBoxPadre() As Boolean
        If (ckbNivelPadre.Checked = False) Then
            If (cmbModSuperior.SelectedValue.ToString = Nothing) Then
                lblSuperior.ForeColor = Color.Red
                Return False
            End If
        End If
        lblSuperior.ForeColor = Color.Black
        Return True
    End Function

    Public Function validarCamprosTextoVacios() As Boolean
        If (txtNombreModulo.Text = Nothing Or txtClave.Text = Nothing) Then
            If (txtNombreModulo.Text = Nothing) Then
                lblModulo.ForeColor = Color.Red
            End If
            If (txtClave.Text = Nothing) Then
                lblClave.ForeColor = Color.Red
            End If
            Return False
        End If
        lblModulo.ForeColor = Color.Black
        lblClave.ForeColor = Color.Black
        Return True
    End Function

    Public Function validaReads() As Boolean
        Dim cont As Int32 = 0
        For Each row As DataGridViewRow In grdAcciones.Rows
            If (row.Cells(3).Value IsNot Nothing) Then
                If (row.Cells(3).Value.ToString = "READ") Then
                    cont = cont + 1
                End If
            End If
        Next
        If (cont > 1) Then
            Return False
        End If
        Return True
    End Function

    Private Sub ALtaModuloArbolForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        rdoMostrarEnMenu.Checked = True
        llenarComboSuperiores()
        primeraFilaLectura()
        grdAcciones.AutoResizeColumns()
        grdAcciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdAcciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        grdAcciones.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    End Sub

    Private Sub ckbNivelPadre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (ckbNivelPadre.Checked = True) Then
            cmbModSuperior.SelectedValue = 0
            cmbModSuperior.Enabled = False
            lblSuperior.ForeColor = Color.Black
        Else
            llenarComboSuperiores()
            cmbModSuperior.Enabled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If (validaReads() = True) Then

            If (validarCamprosTextoVacios() = True) Then

                If (validarFilasVacias() = True) Then

                    If (validaRepetidosModulo() = True) Then

                        If (validarCheckBoxPadre() = True) Then
                            If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                                guardarModulo()
                                Dim objMsExito As New ExitoForm
                                objMsExito.mensaje = "Registro correcto"
                                objMsExito.ShowDialog()
                                Me.Close()
                            End If
                        Else
                            Dim objMsAlerta As New AdvertenciaForm
                            objMsAlerta.mensaje = "Debe especificar si el módulo es nivel padre o tiene módulo superior."
                            objMsAlerta.ShowDialog()
                        End If
                    Else
                        Dim objMsAlerta As New AdvertenciaForm
                        objMsAlerta.mensaje = "El modulo ya existe."
                        objMsAlerta.ShowDialog()
                    End If
                Else
                    MsgBox("Existen datos vacios en la lista de acciones.")
                End If
            Else
                Dim objMsAlerta As New AdvertenciaForm
                objMsAlerta.mensaje = "Existen campos vacios."
                objMsAlerta.ShowDialog()
            End If
        Else
            Dim objMsAlerta As New AdvertenciaForm
            objMsAlerta.mensaje = "Solo debe existir una accion con clave " + Chr(34) + "READ" + Chr(34) + " por módulo."
            objMsAlerta.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        quitarRegistrosDetalle()
    End Sub


    Private Sub grdAcciones_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdAcciones.EditingControlShowing
        Dim columnIndex As Integer = grdAcciones.CurrentCell.ColumnIndex()
        If (columnIndex = 4) Then
            Exit Sub
        ElseIf (columnIndex = 3) Then
            If TypeOf e.Control Is TextBox Then
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            End If
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
        ElseIf (columnIndex = 0 Or columnIndex = 1 Or columnIndex = 2) Then
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
        End If

    End Sub

    Private Sub ValidarEntradaDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columnIndex As Integer = grdAcciones.CurrentCell.ColumnIndex()
        If columnIndex = 0 Or columnIndex = 1 Or columnIndex = 2 Or columnIndex = 3 Then
            Dim caracter As Char = e.KeyChar
            If (Char.IsLetterOrDigit(e.KeyChar)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ChrW(Keys.Space) Or (caracter = "_")) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If

        'Dim txt As TextBox = CType(sender, TextBox)
    End Sub

    Private Sub txtClave_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.C And e.Modifiers = Keys.Control Then
            txtClave.Copy()
        ElseIf e.KeyCode = Keys.V And e.Modifiers = Keys.Control Then
            txtClave.Paste()
        End If
    End Sub


    Private Sub txtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        If (txtClave.Text.Length < 100) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or (caracter = "_") Or caracter = ChrW(Keys.Space)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

            If Char.IsLower(e.KeyChar) Then
                txtClave.SelectedText = Char.ToUpper(e.KeyChar)
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtComponente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComponente.KeyPress
        Dim caracter As Char = e.KeyChar

        If (txtComponente.Text.Length < 200) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-" Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtIcono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIcono.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtIcono.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-" Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtNombreModulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        If (txtNombreModulo.Text.Length < 200) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-" Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtComponenteWEB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComponenteWEB.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtComponenteWEB.Text.Length < 200) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "~" Or caracter = "-" Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtIconoWEB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIconoWEB.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtIconoWEB.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-" Or caracter = "~" Or Char.IsControl(e.KeyChar)) Then
                e.Handled = False
            Else
                e.Handled = True
            End If

        Else
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub chkEscritorio_CheckedChanged(sender As Object, e As EventArgs) Handles chkEscritorio.CheckedChanged
        If chkEscritorio.Checked = True Then
            txtComponente.Enabled = True
            txtIcono.Enabled = True
        Else
            txtComponente.Enabled = False
            txtIcono.Enabled = False
            txtComponente.Text = String.Empty
            txtIcono.Text = String.Empty
        End If
    End Sub

    Private Sub chkEsWeb_CheckedChanged(sender As Object, e As EventArgs) Handles chkEsWeb.CheckedChanged
        If chkEsWeb.Checked = True Then
            txtComponenteWEB.Enabled = True
            txtIconoWEB.Enabled = True
        Else
            txtComponenteWEB.Enabled = False
            txtIconoWEB.Enabled = False
            txtComponenteWEB.Text = String.Empty
            txtIconoWEB.Text = String.Empty
        End If
    End Sub



    Private Sub txtComponente_TextChanged(sender As Object, e As EventArgs) Handles txtComponente.TextChanged

    End Sub
End Class