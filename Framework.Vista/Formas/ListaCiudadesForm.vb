Imports Framework.Negocios

Public Class ListaCiudadesForm

    Dim seleleccionNombreCiudad As String
    Dim seleccionpaises, seleccionestados, CiudadId As Int32
    Private Sub ListaCiudadesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        'consultar permisos sobre las acciones


        If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_CITY", "WRITE") Then
            btnAltaCiudades.Visible = True
            lblAltaCiudad.Visible = True
        Else
            btnAltaCiudades.Visible = False
            lblAltaCiudad.Visible = False
        End If

        'consultar permisos sobre las acciones


        If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_CITY", "UPDATE") Then
            btnEditarCiudades.Visible = True
            lblEditar.Visible = True
        Else
            btnEditarCiudades.Visible = False
            lblEditar.Visible = False
        End If



        cmbPaises = Controles.ComboPaises(cmbPaises)
        grdFiltroCiudades.Columns.Add("Nombre", "Nombre") ''column = 0
        grdFiltroCiudades.Columns("Nombre").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdFiltroCiudades.Columns.Add("Estado", "Estado") ''column = 1
        grdFiltroCiudades.Columns("Estado").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdFiltroCiudades.Columns.Add("Pais", "País") ''Column = 2
        grdFiltroCiudades.Columns("Pais").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        grdFiltroCiudades.Columns.Add("Activo", "Activo") ''Column = 3
        grdFiltroCiudades.Columns.Add("ID", "ID") ''Column = 4
        grdFiltroCiudades.Columns("ID").Visible = False
        grdFiltroCiudades.Columns.Add("ID_Estado", "ID_Estado") ''Column = 5
        grdFiltroCiudades.Columns("ID_Estado").Visible = False
        grdFiltroCiudades.Columns.Add("ID_Pais", "ID_Pais") ''Column = 6
        grdFiltroCiudades.Columns("ID_Pais").Visible = False

        grdFiltroCiudades.Columns(0).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdFiltroCiudades.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue
        llenartabla()
        txtBuscarNombrePais.MaxLength = 50

    End Sub



    Private Sub cmbPaises_ValueMemberChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPaises.ValueMemberChanged
        'cmbEstados = Controles.ComboEstadosAnidado(cmbEstados, CInt(cmbPaises.SelectedValue))
    End Sub

    Private Sub cmbPaises_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaises.SelectedIndexChanged
        If cmbPaises.SelectedIndex <= 0 Then
            cmbEstados = Controles.ComboEstados(cmbEstados)
        Else
            cmbEstados = Controles.ComboEstadosAnidado(cmbEstados, CInt(cmbPaises.SelectedValue))
        End If

    End Sub




    Public Sub AgregarFila(ByVal ciudades As Entidades.Ciudades)


        Dim celda As DataGridViewCell
        Dim fila As New DataGridViewRow

        celda = New DataGridViewTextBoxCell
        celda.Value = ciudades.CNombre
        fila.Cells.Add(celda)



        celda = New DataGridViewTextBoxCell
        celda.Value = ciudades.CNombreEstado.ENombre
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ciudades.CNombreEstado.PPais.PNombre
        fila.Cells.Add(celda)

        celda = New DataGridViewCheckBoxCell
        celda.Value = ciudades.CActivo
        fila.Cells.Add(celda)


        celda = New DataGridViewTextBoxCell
        celda.Value = ciudades.CciudadId
        fila.Cells.Add(celda)




        celda = New DataGridViewTextBoxCell
        celda.Value = ciudades.CIDEstado.EIDDEstado
        fila.Cells.Add(celda)

        celda = New DataGridViewTextBoxCell
        celda.Value = ciudades.CIDEstado.PPais.PIDPais
        fila.Cells.Add(celda)
        grdFiltroCiudades.Rows.Add(fila)

    End Sub


    Public Sub llenartabla()
        Dim EstadoId As Int32 = 0
        If cmbEstados.SelectedIndex > 0 Then
            EstadoId = CInt(cmbEstados.SelectedValue)
        End If
        Dim paisid As Int32 = 0
        If cmbPaises.SelectedIndex > 0 Then
            paisid = CInt(cmbPaises.SelectedValue)
        End If

        Dim listaEstados As New List(Of Entidades.Ciudades)
        Dim objBU As New Negocios.CiudadesBU
        listaEstados = objBU.ListaCiudades(txtBuscarNombrePais.Text, rdoActivoSi.Checked, EstadoId, paisid)
        For Each objeto As Entidades.Ciudades In listaEstados

            AgregarFila(objeto)
        Next
    End Sub

    Private Sub btnFiltrarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrarPais.Click
        grdFiltroCiudades.Rows.Clear()
        llenartabla()
    End Sub

    Private Sub btnLimpiarPais_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarPais.Click
        grdFiltroCiudades.Rows.Clear()
        llenartabla()
    End Sub

    Private Sub btnAltaCiudades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltaCiudades.Click
        Dim AltasCiudades As New AltasCiudadesForm
        AltasCiudades.MdiParent = MdiParent
        AltasCiudades.Show()
    End Sub

    Private Sub btnEditarCiudades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarCiudades.Click

        Dim formaeditarciudades As New EditarCiudadesForm
        formaeditarciudades.ESeleccionestado = seleccionestados
        formaeditarciudades.ESeleccionpais = seleccionpaises
        formaeditarciudades.EseleccionNombreCiudad = seleleccionNombreCiudad
        formaeditarciudades.ECiudadId = CiudadId
        formaeditarciudades.MdiParent = MdiParent
        formaeditarciudades.Show()
    End Sub



    Private Sub grdFiltroCiudades_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdFiltroCiudades.CellClick

        If e.RowIndex > 0 Then
            seleleccionNombreCiudad = CStr(grdFiltroCiudades.Rows(e.RowIndex).Cells(0).Value)
            'seleccionestado = CInt(grdFiltroCiudades.Rows(e.RowIndex).Cells(1).Value)
            CiudadId = CInt(grdFiltroCiudades.Rows(e.RowIndex).Cells(4).Value)
            seleccionpaises = CInt(grdFiltroCiudades.Rows(e.RowIndex).Cells(6).Value)
            seleccionestados = CInt(grdFiltroCiudades.Rows(e.RowIndex).Cells(5).Value)
        End If
    End Sub

    Private Sub txtBuscarNombrePais_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBuscarNombrePais.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArriba.Click
        gpbFiltroCiudades.Height = 41
        grdFiltroCiudades.Height = 417
        grdFiltroCiudades.Top = 113
    End Sub
    Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbajo.Click
        gpbFiltroCiudades.Height = 150
        grdFiltroCiudades.Height = 309
        grdFiltroCiudades.Top = 221
    End Sub
End Class