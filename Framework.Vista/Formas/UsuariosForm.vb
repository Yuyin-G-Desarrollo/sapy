Imports Entidades
Imports Framework.Negocios

Public Class UsuariosForm

    Private Sub btnOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOcultar.Click
        'Modifica el tamaño del panel
        Dim Sz As System.Drawing.Size
        Sz = New System.Drawing.Size(807, 50)
        grpBusqueda.Size = Sz

        'Modifica el tamaño de la tabla
        Dim Sz2 As System.Drawing.Size
        Sz2 = New System.Drawing.Size(807, 476)
        dgvUsuarios.Size = Sz2

        dgvUsuarios.Location = New Point(12, 129)
    End Sub

    Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
        'Modifica el tamaño del panel
        Dim Sz As System.Drawing.Size
        Sz = New System.Drawing.Size(807, 150)
        grpBusqueda.Size = Sz

        'Modifica el tamaño de la tabla
        Dim Sz2 As System.Drawing.Size
        Sz2 = New System.Drawing.Size(807, 376)
        dgvUsuarios.Size = Sz2

        dgvUsuarios.Location = New Point(12, 229)
    End Sub

    Private Sub dgvUsuarios_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentDoubleClick

    End Sub

    Private Sub UsuariosForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'consultar permisos sobre las acciones


        If PermisosUsuarioBU.ConsultarPermiso("FWK_CAT_USER", "WRITE") Then
            btnAltas.Visible = True
            lblAltas.Visible = True
        Else
            btnAltas.Visible = False
            lblAltas.Visible = False
        End If

        llenarTabla()
        initCombos()
    End Sub

    

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        llenarTabla()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtBusquedaNombre.Text = ""
        txtBusquedaUsuario.Text = ""
        txtBusquedaEmail.Text = ""
        cmbBusquedaDepartamento.SelectedIndex = 0
        cmbBusquedaPerfil.SelectedIndex = 0
        cmbBusquedaNave.SelectedIndex = 0
        rdbActivo.Checked = True
        llenarTabla()
    End Sub

    Public Sub llenarTabla()
        Dim NaveSeleccionada As Int32 = 0
        Dim DepartamentoSeleccionado As Int32 = 0
        Dim PerfilSeleccionado As Int32 = 0
        If (cmbBusquedaNave.SelectedIndex > 0) Then
            NaveSeleccionada = CInt(cmbBusquedaNave.SelectedValue)
        End If
        If (cmbBusquedaDepartamento.SelectedIndex > 0) Then
            DepartamentoSeleccionado = CInt(cmbBusquedaDepartamento.SelectedValue)
        End If
        If cmbBusquedaPerfil.SelectedIndex > 0 Then
            PerfilSeleccionado = CInt(cmbBusquedaPerfil.SelectedValue)
        End If

        dgvUsuarios.Rows.Clear()
        Dim listaUsuarios As New List(Of Usuarios)
        Dim objBU As New UsuariosBU
        listaUsuarios = objBU.listaUsuarios(txtBusquedaNombre.Text, txtBusquedaUsuario.Text, txtBusquedaEmail.Text, NaveSeleccionada, DepartamentoSeleccionado, PerfilSeleccionado, rdbActivo.Checked)
        For Each usuario As Usuarios In listaUsuarios
            agregarFila(usuario)
        Next

    End Sub

    ''' <summary>
    ''' Llena el datagridview con los valores contenidos en el objeto usuario
    ''' </summary>
    ''' <param name="usuario">Objeto usuario (fila)</param>
    ''' <remarks></remarks>
    Public Sub agregarFila(ByVal usuario As Usuarios)
        Dim dgvRow As New DataGridViewRow
        Dim dgvCell As DataGridViewCell

        'columna Usuario
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = usuario.PUserUsername
        dgvRow.Cells.Add(dgvCell)

        'Columna Nombre
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = usuario.PUserNombreReal
        dgvRow.Cells.Add(dgvCell)

        'Columna email
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = usuario.PUserEmail
        dgvRow.Cells.Add(dgvCell)

        'Columna activo
        dgvCell = New DataGridViewCheckBoxCell()
        dgvCell.Value = usuario.PUserActive
        dgvRow.Cells.Add(dgvCell)

        'Columna id
        dgvCell = New DataGridViewTextBoxCell()
        dgvCell.Value = usuario.PUserUsuarioid
        dgvRow.Cells.Add(dgvCell)

        'Agrega la fila con los valores al datagridview
        dgvUsuarios.Rows.Add(dgvRow)
    End Sub

    ''' <summary>
    ''' Carga los valores de los combos de los campos de búsqueda
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initCombos()

        'Carga valores para el combo de nave
        Dim objNaveBU As New Negocios.NavesBU 'Declara objeto de la capa de negocios
        Dim tabla As New DataTable 'Declara tabla que se utilizara para llenar los combos
        tabla = objNaveBU.listaNaves() 'trae el DataTable con los valores de la base de datos y los guarda en la variable tabla
        tabla.Rows.InsertAt(tabla.NewRow, 0) 'inserta el primer elemento de la tabla en blanco
        With cmbBusquedaNave
            .DisplayMember = "nave_nombre" 'En la propiedad .DisplayMember se establece el nombre de la columna que se mostrara cada elemento del combo
            .ValueMember = "nave_naveid" 'En la propiedad .Value se establece el valor que tendra cada elemento del combo
            .DataSource = tabla 'En la propiedad DataSource se establece la tabla de donde se tomaran los datos
        End With

        'Carga los valores para el combo de departamentos
        Dim objDepartamentosBU As New Negocios.DepartamentosBU
        tabla = New DataTable
        tabla = objDepartamentosBU.listaDepartamentosActivos
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        With cmbBusquedaDepartamento
            .DisplayMember = "grup_name"
            .ValueMember = "grup_grupoid"
            .DataSource = tabla
        End With

        'Carga los valores para el combo de perfiles dependiendo del elemento seleccionado en el combo de departamentos
        Dim objPerfilesBU As New Negocios.PerfilesBU
        tabla = New DataTable
        tabla = objPerfilesBU.listaPerfilesActivos
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        With cmbBusquedaPerfil
            .DisplayMember = "perf_nombre"
            .ValueMember = "perf_perfilid"
            .DataSource = tabla
        End With

    End Sub

    Private Sub cmbBusquedaDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBusquedaDepartamento.SelectedIndexChanged
        Dim objPerfilesBU As New Negocios.PerfilesBU
        Dim tabla As New DataTable
        If cmbBusquedaDepartamento.SelectedIndex > 0 Then
            tabla = objPerfilesBU.listaPerfilesDepartamento(CInt(cmbBusquedaDepartamento.SelectedValue))
        Else
            tabla = objPerfilesBU.listaPerfilesActivos
        End If

        tabla.Rows.InsertAt(tabla.NewRow, 0)
        With cmbBusquedaPerfil
            .DisplayMember = "perf_nombre"
            .ValueMember = "perf_perfilid"
            .DataSource = tabla
        End With
    End Sub

    Private Sub btnAltas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAltas.Click
		Dim altasForm As New AltasUsuariosForm
		altasForm.MdiParent = Me.MdiParent

		altasForm.Show()
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        For Each row As DataGridViewRow In dgvUsuarios.SelectedRows
            For Each cell As DataGridViewCell In row.Cells
                If (cell.OwningColumn.Name = "id") Then
					Dim editar As New EditarUsuariosForm
					editar.MdiParent = Me.MdiParent
                    editar.usuarioid = CInt(cell.Value)
                    editar.Show()
                End If
            Next
        Next

    End Sub

	Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
		Dim PErfilesForm As New ListaPerfilesForm
		PErfilesForm.MdiParent = Me.MdiParent

		PErfilesForm.Show()
	End Sub

	Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
		Dim excepcionesForm As New ListaExcepcionesForm
		excepcionesForm.MdiParent = Me.MdiParent

		excepcionesForm.Show()
	End Sub

    Private Sub dgvUsuarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsuarios.CellContentClick

    End Sub
End Class