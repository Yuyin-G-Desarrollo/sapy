Public Class EditarModuloArbolForm
    Public idModulo As Int32
    Public idModSuperiorArbol As String
    Private fromIndex As Integer
    Private dragIndex As Integer
    Private dragRect As Rectangle

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
        If (idModSuperiorArbol <> "") Then
            cmbModSuperior.SelectedValue = idModSuperiorArbol
        End If
    End Sub


    Public Sub llenarDatosModulo()
        Dim objMod As New Framework.Negocios.ModulosBU
        Dim dtDatosModulo As DataTable

        dtDatosModulo = objMod.verDatosModulo(idModulo.ToString)
        txtNombreModulo.Text = dtDatosModulo.Rows(0)("modu_nombre").ToString
        txtIcono.Text = dtDatosModulo.Rows(0)("modu_icono").ToString
        txtComponente.Text = dtDatosModulo.Rows(0)("modu_componente").ToString
        txtClave.Text = dtDatosModulo.Rows(0)("modu_clave").ToString
        txtComponenteWEB.Text = dtDatosModulo.Rows(0)("modu_componenteweb").ToString
        txtIconoWEB.Text = dtDatosModulo.Rows(0)("modu_imagenweb").ToString
        If dtDatosModulo.Rows(0)("modu_moduloescritorio").ToString = "" Then
            chkEscritorio.Checked = False
        Else
            chkEscritorio.Checked = CBool(dtDatosModulo.Rows(0)("modu_moduloescritorio"))
        End If

        If dtDatosModulo.Rows(0)("modu_moduloweb").ToString = "" Then
            chkEsWeb.Checked = False
        Else
            chkEsWeb.Checked = CBool(dtDatosModulo.Rows(0)("modu_moduloweb"))
        End If



        If (idModSuperiorArbol = "") Then
            cmbModSuperior.Enabled = False
        End If
        If (Convert.ToBoolean(dtDatosModulo.Rows(0)(7).ToString) = True) Then
            rdoActivo.Checked = True
        ElseIf (Convert.ToBoolean(dtDatosModulo.Rows(0)(7).ToString) = False) Then
            rdoInactivo.Checked = True
        End If

        If (Convert.ToBoolean(dtDatosModulo.Rows(0)(8).ToString) = True) Then
            rdoMostrarEnMenu.Checked = True
        ElseIf (Convert.ToBoolean(dtDatosModulo.Rows(0)(8).ToString) = False) Then
            rdoNoMostrar.Checked = True
        End If

        Dim dtDatosHijodModulo As DataTable = objMod.verSubModulos(idModulo.ToString)
        Dim fila As Int32 = 0

        For Each rowd As DataRow In dtDatosHijodModulo.Rows
            grdOrdenamiento.Rows.Add()
            grdOrdenamiento.Rows(fila).Cells("moduloId").Value = rowd.Item("modu_moduloid")
            grdOrdenamiento.Rows(fila).Cells("nombreModulo").Value = rowd.Item("modu_nombre")
            grdOrdenamiento.Rows(fila).Cells("claveModulo").Value = rowd.Item("modu_clave")
            fila = fila + 1
        Next

    End Sub


    Public Sub llenarGridAcciones()
        Dim objAccion As New Framework.Negocios.AccionesBU
        Dim dtListaAcciones As DataTable
        dtListaAcciones = objAccion.verAccionesPorModulo(idModulo.ToString)
        Dim tamanoConsulta As Int32 = dtListaAcciones.Rows.Count
        Dim recorre As Int32 = 0

        Dim cmb As New DataGridViewComboBoxColumn()
        cmb.Name = "Tipo"
        cmb.Items.Add("Consultar")
        cmb.Items.Add("Altas")
        cmb.Items.Add("Editar")
        cmb.Items.Add("ELiminar")
        cmb.Items.Add("Otros")
        grdAcciones.Columns.Add(cmb)

        For recorre = 0 To tamanoConsulta - 1
            grdAcciones.Rows.Add(1)
            grdAcciones.Item(0, recorre).Value = dtListaAcciones.Rows(recorre)(0).ToString
            grdAcciones.Item(1, recorre).Value = dtListaAcciones.Rows(recorre)(1).ToString
            grdAcciones.Item(2, recorre).Value = dtListaAcciones.Rows(recorre)(2).ToString
            grdAcciones.Item(3, recorre).Value = dtListaAcciones.Rows(recorre)(3).ToString
            grdAcciones.Item(4, recorre).Value = dtListaAcciones.Rows(recorre)(4).ToString
            grdAcciones.Item(5, recorre).Value = dtListaAcciones.Rows(recorre)(5).ToString
            'grdAcciones.Item(6, recorre).Value = dtListaAcciones.Rows(recorre)(6).ToString
            grdAcciones.Item(6, recorre).Value = dtListaAcciones.Rows(recorre)(7).ToString

            If (dtListaAcciones.Rows(recorre)(6).ToString = "1") Then
                grdAcciones.Item(7, recorre).Value = "Consultar"

            ElseIf (dtListaAcciones.Rows(recorre)(6).ToString = "2") Then
                grdAcciones.Item(7, recorre).Value = "Altas"

            ElseIf (dtListaAcciones.Rows(recorre)(6).ToString = "3") Then
                grdAcciones.Item(7, recorre).Value = "Editar"

            ElseIf (dtListaAcciones.Rows(recorre)(6).ToString = "4") Then
                grdAcciones.Item(7, recorre).Value = "Eliminar"

            ElseIf (dtListaAcciones.Rows(recorre)(6).ToString = "0") Then
                grdAcciones.Item(7, recorre).Value = "Otros"
            End If
        Next

        For Each row As DataGridViewRow In grdAcciones.Rows
            If (row.Cells(5).Value IsNot Nothing) Then
                If (row.Cells(5).Value.ToString = "READ") Then
                    row.Cells(5).ReadOnly = True
                    row.Cells(6).ReadOnly = True
                    row.Cells(7).ReadOnly = True
                End If
            End If
        Next

        With grdAcciones
            .Columns("nombre").Width = 147
            .Columns("clave").Width = 147
            .Columns("activo").Width = 50
        End With

    End Sub

    Public Function validarVacio() As Boolean
        Dim cont As Int32 = 0
        For Each row As DataGridViewRow In grdAcciones.Rows
            If (row.Cells(3).Value Is Nothing Or row.Cells(5).Value Is Nothing Or row.Cells(7).Value Is Nothing) Then
                cont = cont + 1
            End If
        Next
        If (cont > 1) Then
            Return False
        End If
        Return True
    End Function

    Public Sub guardarAcciones()
        Dim objAcciones As New Framework.Negocios.AccionesBU
        Dim accion As New Entidades.Acciones
        For x As Int32 = 0 To grdAcciones.Rows.Count - 2
            If (grdAcciones.Item(0, x).Value Is Nothing) Then
                accion.PAccionId = 0
            Else
                accion.PAccionId = CInt(grdAcciones.Item(0, x).Value.ToString)
            End If
            Dim modulo As New Entidades.Modulos
            modulo.PModuloid = idModulo
            accion.PModulo = modulo

            If (grdAcciones.Item(2, x).Value Is Nothing) Then
                accion.PComponente = ""
            Else
                accion.PComponente = grdAcciones.Item(2, x).Value.ToString
            End If

            accion.PNombre = grdAcciones.Item(3, x).Value.ToString

            If (grdAcciones.Item(4, x).Value Is Nothing) Then
                accion.PIcono = ""
            Else
                accion.PIcono = grdAcciones.Item(4, x).Value.ToString
            End If

            accion.PClave = grdAcciones.Item(5, x).Value.ToString

            If (grdAcciones.Item(6, x).Value IsNot Nothing) Then
                accion.PActivo = CBool(grdAcciones.Item(6, x).Value.ToString)
            Else
                accion.PActivo = False
            End If


            If (grdAcciones.Item(7, x).Value.ToString = "Consultar") Then

                accion.PTipo = 1
            ElseIf (grdAcciones.Item(7, x).Value.ToString = "Altas") Then

                accion.PTipo = 2
            ElseIf (grdAcciones.Item(7, x).Value.ToString = "Editar") Then

                accion.PTipo = 3
            ElseIf (grdAcciones.Item(7, x).Value.ToString = "Eliminar") Then

                accion.PTipo = 4
            ElseIf (grdAcciones.Item(7, x).Value.ToString = "Otros") Then

                accion.PTipo = 0
            End If
            objAcciones.ModificarAcciones(accion)
        Next

    End Sub

    Public Function validarRepetido() As Boolean
        Dim objMod As New Framework.Negocios.ModulosBU
        Dim dtContadorModulos As New DataTable
        Dim contadorMod As Int32 = 0
        Dim modulo As String = txtNombreModulo.Text
        Dim idSuperior As String = ""

        If (cmbModSuperior.SelectedValue IsNot Nothing) Then
            idSuperior = cmbModSuperior.SelectedValue.ToString
        End If
        If (idSuperior <> idModSuperiorArbol) Then
            dtContadorModulos = objMod.contarRegistrosCambio(modulo, idModulo.ToString, idSuperior)
        Else
            dtContadorModulos = objMod.contarRegistros(modulo, idModulo.ToString, idSuperior)
        End If


        contadorMod = Convert.ToInt32(dtContadorModulos.Rows(0)(0).ToString)
        If (contadorMod >= 1) Then
            Return False
        End If
        Return True

    End Function

    Public Function validaReads() As Boolean
        Dim cont As Int32 = 0
        For Each row As DataGridViewRow In grdAcciones.Rows
            If (row.Cells(5).Value IsNot Nothing) Then
                If (row.Cells(5).Value.ToString = "READ") Then
                    cont = cont + 1
                End If
            End If
        Next
        If (cont > 1) Then
            Return False
        End If
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

    Public Sub editarModulo()
        If (cmbModSuperior.SelectedValue IsNot Nothing) Then
            idModSuperiorArbol = cmbModSuperior.SelectedValue.ToString
        End If

        Dim objMod As New Framework.Negocios.ModulosBU
        Dim entModulo As New Entidades.Modulos

        entModulo.PNombre = txtNombreModulo.Text

        If (rdoActivo.Checked = True) Then
            entModulo.PActivo = True
            If (rdoInactivo.Checked = True) Then
                entModulo.PActivo = False
            End If
        End If
        If (rdoMostrarEnMenu.Checked = True) Then
            entModulo.PMenu = True
        Else
            rdoNoMostrar.Checked = True
            entModulo.PMenu = False
        End If
        entModulo.PGuardarHistorial = True
        entModulo.PClave = txtClave.Text
        entModulo.PComponente = txtComponente.Text
        entModulo.PIcono = txtIcono.Text
        entModulo.PArchivoReporte = ""
        entModulo.PImagenWeb = txtIconoWEB.Text
        entModulo.PComponenteWeb = txtComponenteWEB.Text
        entModulo.PModuloEscritorio = CBool(chkEscritorio.Checked)
        entModulo.PModuloWeb = CBool(chkEsWeb.Checked)

        Dim modulo As New Entidades.Modulos

        If (idModSuperiorArbol <> "") Then
            modulo.PModuloid = CInt(idModSuperiorArbol)
        Else
            modulo.PModuloid = 0
        End If
        If (rdoActivo.Checked = True) Then
            entModulo.PActivo = True
        ElseIf (rdoInactivo.Checked = True) Then
            entModulo.PActivo = False
        End If

        entModulo.PSuperiorid = modulo
        entModulo.PModuloid = idModulo
        objMod.EditarModulo(entModulo)

    End Sub

    Public Sub guardarOrdenHijos()
        Dim objMod As New Framework.Negocios.ModulosBU
        For Each rowDT As DataGridViewRow In grdOrdenamiento.Rows
            Dim entMod As New Entidades.Modulos
            entMod.PModuloid = CInt(rowDT.Cells("moduloid").Value.ToString)
            entMod.PNombre = rowDT.Cells("nombreModulo").Value.ToString
            entMod.PClave = rowDT.Cells("claveModulo").Value.ToString
            objMod.editarOrdenModulos(entMod, CStr(rowDT.Cells("Orden").Value.ToString))
        Next
    End Sub

    Public Sub cambiarCheckWEB()
        If chkEsWeb.Checked = True Then
            txtComponenteWEB.Enabled = True
            txtIconoWEB.Enabled = True
        Else
            txtComponenteWEB.Enabled = False
            txtIconoWEB.Enabled = False
            'txtComponenteWEB.Text = String.Empty
            'txtIconoWEB.Text = String.Empty
        End If
    End Sub


    Public Sub cambiarCheckEscritorio()
        If chkEscritorio.Checked = True Then
            txtComponente.Enabled = True
            txtIcono.Enabled = True
        Else
            txtComponente.Enabled = False
            txtIcono.Enabled = False
            'txtComponente.Text = String.Empty
            'txtIcono.Text = String.Empty
        End If
    End Sub

    Private Sub EditarModuloArbolForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdAcciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        grdOrdenamiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        llenarDatosModulo()
        cambiarCheckWEB()
        cambiarCheckEscritorio()
        llenarGridAcciones()
        llenarComboSuperiores()
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim contOrd As Int32 = 1
        For Each rowDT As DataGridViewRow In grdOrdenamiento.Rows
            rowDT.Cells("Orden").Value = contOrd
            contOrd = contOrd + 1
        Next

        If (validarCamprosTextoVacios() = True) Then

            If (validaReads() = True) Then

                If (validarRepetido() = True) Then

                    If (validarVacio() = True) Then

                        If MsgBox("¿Esta seguro de guardar cambios?" + Chr(13), vbYesNo, "") = vbYes Then
                            editarModulo()
                            guardarAcciones()
                            guardarOrdenHijos()
                            Me.Close()
                        End If

                    Else
                        MsgBox("Existen datos vacios en la lista de acciones.")
                    End If
                Else
                    Dim objMsAlerta As New AdvertenciaForm
                    objMsAlerta.mensaje = "El modulo ya existe."
                    objMsAlerta.ShowDialog()
                End If
            Else
                Dim objMsAlerta As New AdvertenciaForm
                objMsAlerta.mensaje = "Solo debe existir una accion con clave " + Chr(34) + "READ" + Chr(34) + " por módulo."
                objMsAlerta.ShowDialog()
            End If
        Else
            Dim objMsAlerta As New AdvertenciaForm
            objMsAlerta.mensaje = "Existen campos vacios."
            objMsAlerta.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdAcciones_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grdAcciones.EditingControlShowing
        Dim columnIndex As Integer = grdAcciones.CurrentCell.ColumnIndex()
        If (columnIndex = 7) Then
            Exit Sub
        ElseIf (columnIndex = 5) Then
            If TypeOf e.Control Is TextBox Then
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            End If
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
        ElseIf (columnIndex = 0 Or columnIndex = 1 Or columnIndex = 2 Or columnIndex = 3 Or columnIndex = 4 Or columnIndex = 6) Then
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
        End If

    End Sub

    Private Sub ValidarEntradaDatos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columnIndex As Integer = grdAcciones.CurrentCell.ColumnIndex()
        If columnIndex = 2 Or columnIndex = 3 Or columnIndex = 4 Or columnIndex = 5 Or columnIndex = 6 Then
            Dim caracter As Char = e.KeyChar
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = ChrW(Keys.Space) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-") Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub grdOrdenamiento_DragDrop(sender As Object, e As DragEventArgs) Handles grdOrdenamiento.DragDrop
        Dim p As Point = grdOrdenamiento.PointToClient(New Point(e.X, e.Y))
        dragIndex = grdOrdenamiento.HitTest(p.X, p.Y).RowIndex
        If (e.Effect = DragDropEffects.Move) Then
            Dim dragRow As New DataGridViewRow
            dragRow = CType(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            If dragIndex < 0 Then dragIndex = grdOrdenamiento.RowCount - 1
            grdOrdenamiento.Rows.RemoveAt(fromIndex)
            grdOrdenamiento.Rows.Insert(dragIndex, dragRow)
        End If
    End Sub

    Private Sub grdOrdenamiento_DragOver(sender As Object, e As DragEventArgs) Handles grdOrdenamiento.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub grdOrdenamiento_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles grdOrdenamiento.EditingControlShowing
        Dim columnIndex As Integer = grdOrdenamiento.CurrentCell.ColumnIndex()
        If (columnIndex = 3) Then
            If TypeOf e.Control Is TextBox Then
                DirectCast(e.Control, TextBox).CharacterCasing = CharacterCasing.Upper
            End If
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
        Else
            Dim ValidaEntradaDatos As TextBox = CType(e.Control, TextBox)
            AddHandler ValidaEntradaDatos.KeyPress, AddressOf ValidarEntradaDatos_KeyPress
        End If
    End Sub

    Private Sub grdOrdenamiento_MouseDown(sender As Object, e As MouseEventArgs) Handles grdOrdenamiento.MouseDown
        fromIndex = grdOrdenamiento.HitTest(e.X, e.Y).RowIndex
        If fromIndex > -1 Then
            Dim dragSize As Size = SystemInformation.DragSize
            dragRect = New Rectangle(New Point(CInt(e.X - (dragSize.Width / 2)), CInt(e.Y - (dragSize.Height / 2))), dragSize)
        Else
            dragRect = Rectangle.Empty
        End If
    End Sub

    Private Sub grdOrdenamiento_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles grdOrdenamiento.MouseMove
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            If (dragRect <> Rectangle.Empty AndAlso Not dragRect.Contains(e.X, e.Y)) Then
                grdOrdenamiento.DoDragDrop(grdOrdenamiento.Rows(fromIndex), DragDropEffects.Move)
            End If
        End If
    End Sub

    Private Sub chkEscritorio_CheckedChanged(sender As Object, e As EventArgs) Handles chkEscritorio.CheckedChanged
        cambiarCheckEscritorio()
    End Sub

    Private Sub chkEsWeb_CheckedChanged(sender As Object, e As EventArgs) Handles chkEsWeb.CheckedChanged
        cambiarCheckWEB()
    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        If (txtClave.Text.Length < 50) Then
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-" Or Char.IsControl(e.KeyChar)) Then
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
            If (Char.IsLetterOrDigit(e.KeyChar) Or caracter = ChrW(Keys.Back) Or caracter = "_" Or caracter = "." Or caracter = "/" Or caracter = "-" Or Char.IsControl(e.KeyChar)) Then
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

    Private Sub txtIconoWEB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIconoWEB.KeyPress
        Dim caracter As Char = e.KeyChar
        If (txtIconoWEB.Text.Length < 50) Then
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
 
End Class