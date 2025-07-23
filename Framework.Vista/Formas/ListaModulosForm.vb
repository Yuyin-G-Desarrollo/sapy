Imports Framework.Negocios
Imports Entidades

Public Class ListaModulosForm

    Private Sub txtNombreDelModulo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreDelModulo.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtModuloSuperior_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) Then

            e.Handled = False
        End If
    End Sub

    Private Sub txtClave_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) _
        Or e.KeyChar = "." _
        Or e.KeyChar = "_" _
        Or e.KeyChar = "-" Then

            e.Handled = False
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtComponente.KeyPress
        e.Handled = True
        If Char.IsSeparator(e.KeyChar) _
        Or Char.IsLetterOrDigit(e.KeyChar) _
        Or Char.IsControl(e.KeyChar) _
        Or e.KeyChar = "." _
        Or e.KeyChar = "_" _
        Or e.KeyChar = "-" Then

            e.Handled = False
        End If

    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        grbBusqueda.Height = 40
        grdModulos.Height = 495
        grdModulos.Top = 128
        'grbBusqueda.Visible = (False)

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click

    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        'grbBusqueda.Visible = (True)
        grbBusqueda.Height = 177
        grdModulos.Height = 364
        grdModulos.Top = 265
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
        AltasModulosForm.Show()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        For Each row As DataGridViewRow In grdModulos.SelectedRows
            For Each cell As DataGridViewCell In row.Cells
                If (cell.OwningColumn.Name = "colId") Then
                    Dim editar As New EditarModulosForm
                    editar.ModuloId = CInt(cell.Value)
                    editar.Show()
                End If
            Next
        Next
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenarTabla()
    End Sub

    Private Sub btnAcciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcciones.Click
        ListaAccionesForm.Show()
    End Sub

    Private Sub ListaModulosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initCombos()
        LlenarTabla()
    End Sub

    Private Sub initCombos()
        'INIT combo Modulo superior
        Dim objModulosBU As New ModulosBU
        Dim tablaModulos As New DataTable
        tablaModulos = objModulosBU.ListaModulosTodos
        tablaModulos.Rows.InsertAt(tablaModulos.NewRow, 0)
        With cmbModuloSuperior
            .DataSource = tablaModulos
            .DisplayMember = "modu_nombre"
            .ValueMember = "modu_moduloid"
        End With
    End Sub

    Private Sub LlenarTabla()
        grdModulos.Rows.Clear()
        Dim superiorid As Int32 = 0
        If cmbModuloSuperior.SelectedIndex > 0 Then
            superiorid = CInt(cmbModuloSuperior.SelectedValue)
        End If
        Dim objModulosBU As New ModulosBU
        Dim listaModulos As New List(Of Modulos)
        listaModulos = objModulosBU.ListaModulos(txtNombreDelModulo.Text, txtClave.Text, txtComponente.Text, rdoMenu.Checked, rdoActivo.Checked, rdoGuardarHistorial.Checked, txtArchivo.Text, superiorid)
        For Each modulo As Modulos In listaModulos
            AgregarFila(modulo)
        Next
    End Sub

    Private Sub AgregarFila(ByVal modulo As Modulos)
        Dim dgvRow As New DataGridViewRow
        Dim dgvCell As DataGridViewCell

        'columna Nombre
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = modulo.PNombre
        dgvRow.Cells.Add(dgvCell)

        'columna superior
        dgvCell = New DataGridViewTextBoxCell()
        If IsNothing(modulo.PSuperiorid) Then
            dgvCell.Value = ""
        Else
            dgvCell.Value = modulo.PSuperiorid.PNombre
        End If
        dgvRow.Cells.Add(dgvCell)

        'columna Clave
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = modulo.PClave
        dgvRow.Cells.Add(dgvCell)

        'columna Componente
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = modulo.PComponente
        dgvRow.Cells.Add(dgvCell)

        'columna en menu
        dgvCell = New DataGridViewCheckBoxCell()
        dgvCell.Value = modulo.PMenu
        dgvRow.Cells.Add(dgvCell)

        'columna guardar historial
        dgvCell = New DataGridViewCheckBoxCell()
        dgvCell.Value = modulo.PGuardarHistorial
        dgvRow.Cells.Add(dgvCell)

        'columna activo
        dgvCell = New DataGridViewCheckBoxCell()
        dgvCell.Value = modulo.PActivo
        dgvRow.Cells.Add(dgvCell)

        'columna id
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = modulo.PModuloid
        dgvRow.Cells.Add(dgvCell)

        grdModulos.Rows.Add(dgvRow)
    End Sub

    Private Sub lblActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblActivo.Click

    End Sub
End Class