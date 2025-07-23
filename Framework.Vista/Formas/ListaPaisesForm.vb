Imports Framework.Negocios

Public Class ListaPaisesForm

    Dim seleccion As Int32

    Private Sub ListaPaisesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'consultar permisos sobre las acciones


        If PermisosUsuarioBU.ConsultarPermiso("FWKCATPAIS", "WRITE") Then
            btnAltaPaises.Visible = True
            lblAltaPais.Visible = True
        Else
            btnAltaPaises.Visible = False
            lblAltaPais.Visible = False
        End If
        If PermisosUsuarioBU.ConsultarPermiso("FWKCATPAIS", "UPDATE") Then
            btnEditarPaises.Visible = True
            lblEditar.Visible = True
        Else
            btnEditarPaises.Visible = False
            lblEditar.Visible = False
        End If


        grdFiltroPaises.Columns.Add("Nombre", "Nombre")
        grdFiltroPaises.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdFiltroPaises.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroPaises.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        grdFiltroPaises.Columns.Add("Activo", "Activo")
        grdFiltroPaises.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroPaises.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroPaises.Columns.Add("ID", "ID")
        grdFiltroPaises.Columns("ID").Visible = False
        txtBuscarNombrePais.MaxLength = 50
        llenartabla()


    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroPaises.Height = 44
        grdFiltroPaises.Height = 379
        grdFiltroPaises.Top = 116
    End Sub

    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroPaises.Height = 135
        grdFiltroPaises.Height = 288
        grdFiltroPaises.Top = 207
    End Sub

    Private Sub btnAltaPaises_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaPaises.Click
        Dim formaAltas As New AltasPaisesForm
        formaAltas.MdiParent = Me.MdiParent
        formaAltas.Show()
    End Sub

    Private Sub btnFiltrarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarPais.Click
        grdFiltroPaises.Rows.Clear()
        llenartabla()
    End Sub


    Public Sub AgregarFila(ByVal paises As Entidades.Paises)

        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = paises.PNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = paises.PActivo
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = paises.PIDPais
        fila.Cells.Add(celda)
        grdFiltroPaises.Columns("ID").Visible = False

        grdFiltroPaises.Rows.Add(fila)

    End Sub

    Public Sub llenartabla()

        Dim listaPaises As New List(Of Entidades.Paises)
        Dim objBU As New Negocios.PaisesBU
        listaPaises = objBU.ListaPaises(txtBuscarNombrePais.Text, rdoActivoSi.Checked)
        For Each objeto As Entidades.Paises In listaPaises
            AgregarFila(objeto)
        Next
    End Sub







    Private Sub btnLimpiarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarPais.Click
        grdFiltroPaises.Rows.Clear()
        txtBuscarNombrePais.Text = ""
        rdoActivoSi.Checked = True
        llenartabla()
    End Sub

    Private Sub btnEditarPaises_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarPaises.Click


        Dim formaEditar As New EditarPaisesForm
        formaEditar.MdiParent = Me.MdiParent
        formaEditar.paisid = seleccion
        formaEditar.Show()



    End Sub

    Public Sub grdFiltroPaises_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroPaises.CellClick

        If e.RowIndex > 0 Then
            seleccion = CInt(grdFiltroPaises.Rows(e.RowIndex).Cells(2).Value)
        End If


    End Sub


    Private Sub txtBuscarNombrePais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarNombrePais.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            txtBuscarNombrePais.SelectedText = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub gpbFiltroPaises_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpbFiltroPaises.Enter

    End Sub

    Private Sub lblEncabezado_Click(sender As Object, e As EventArgs) Handles lblEncabezado.Click

    End Sub

    Private Sub txtBuscarNombrePais_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarNombrePais.TextChanged

    End Sub

    Private Sub rdoActivoSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivoSi.CheckedChanged

    End Sub
End Class