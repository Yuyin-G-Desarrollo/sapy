Imports Framework.Negocios

Public Class ListaEstadosForm
    Dim seleccion As Int32
    Dim PaisSeleccionado As Int32

    Private Sub ListaEstadosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_ESTA", "WRITE") Then
            btnAltaEstados.Visible = True
            lblAltaEstados.Visible = True
        Else
            btnAltaEstados.Visible = False
            lblAltaEstados.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_ESTA", "UPDATE") Then
            btnEditarEstados.Visible = True
            lblEditar.Visible = True
        Else
            btnEditarEstados.Visible = False
            lblEditar.Visible = False
        End If


        cmbEstado = Controles.ComboPaises(cmbEstado)
        grdFiltroEstado.Columns.Add("Nombre", "Nombre")
        grdFiltroEstado.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdFiltroEstado.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroEstado.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroEstado.Columns.Add("Activo", "Activo")
        grdFiltroEstado.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroEstado.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroEstado.Columns.Add("ID_Pais", "ID_Pais")
        grdFiltroEstado.Columns("ID_Pais").Visible = False
        grdFiltroEstado.Columns.Add("ID_Estado", "ID_Estado")
        grdFiltroEstado.Columns("ID_Estado").Visible = False
        grdFiltroEstado.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
        txtAltaEstado.MaxLength = 50
        llenartabla()

    End Sub



    Public Sub AgregarFila(ByVal estados As Entidades.Estados)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = estados.ENombre
        fila.Cells.Add(celda)




        celda = New DataGridViewCheckBoxCell
        celda.Value = estados.EActivo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = estados.EIDPais
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = estados.EIDDEstado
        fila.Cells.Add(celda)


        grdFiltroEstado.Rows.Add(fila)

    End Sub

    Public Sub llenartabla()
        Dim PaisId As Int32 = 0
        If cmbEstado.SelectedIndex > 0 Then
            PaisId = CInt(cmbEstado.SelectedValue)
        End If

        Dim listaEstados As New List(Of Entidades.Estados)
        Dim objBU As New Negocios.EstadosBU
        listaEstados = objBU.ListaEstados(txtAltaEstado.Text, rdoActivoSi.Checked, PaisId)
        For Each objeto As Entidades.Estados In listaEstados
            AgregarFila(objeto)
        Next
    End Sub
    Private Sub btnFiltrarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarEstado.Click
        grdFiltroEstado.Rows.Clear()
        llenartabla()
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroPaises.Height = 44
        grdFiltroEstado.Height = 379
        grdFiltroEstado.Top = 116
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroPaises.Height = 135
        grdFiltroEstado.Height = 288
        grdFiltroEstado.Top = 207
    End Sub
    Private Sub btnLimpiarEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarEstado.Click
        grdFiltroEstado.Rows.Clear()
        cmbEstado.SelectedIndex = 0
        llenartabla()
    End Sub

    Private Sub btnAltaEstados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaEstados.Click
        Dim AltaEstados As New AltaEstadosForm
        AltaEstados.MdiParent = Me.MdiParent
        AltaEstados.Show()
    End Sub

    Private Sub btnEditarEstados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditarEstados.Click
        Dim formaEditar As New EditarEstadoForm
        formaEditar.MdiParent = Me.MdiParent
        formaEditar.paisseleccion = PaisSeleccionado
        formaEditar.estadoid = seleccion
        formaEditar.Show()
    End Sub


    Public Sub grdFiltroPaises_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroEstado.CellClick


        seleccion = CInt(grdFiltroEstado.Rows(e.RowIndex).Cells(3).Value)
        PaisSeleccionado = CInt(grdFiltroEstado.Rows(e.RowIndex).Cells(2).Value)


    End Sub

    Private Sub txtAltaEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAltaEstado.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            txtAltaEstado.SelectedText = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub txtAltaEstado_TextChanged(sender As Object, e As EventArgs) Handles txtAltaEstado.TextChanged

    End Sub

    Private Sub rdoActivoSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivoSi.CheckedChanged

    End Sub
End Class