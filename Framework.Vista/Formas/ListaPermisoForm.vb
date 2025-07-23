Imports Framework.Negocios
Imports Entidades.PermisosPerfil
Public Class ListaPermisoForm
	Private moduloid As Int32
	Private perfilid As Int32
	Private accionid As Int32
	Public Property Pmodulloid As Int32
		Get
			Return moduloid
		End Get
		Set(value As Int32)
			moduloid = value

		End Set
	End Property
	Public Property Pperfilid As Int32
		Get
			Return perfilid
		End Get
		Set(value As Int32)
			perfilid = value

		End Set
	End Property
	Public Property Paccionid As Int32
		Get
			Return accionid
		End Get
		Set(value As Int32)
			accionid = value

		End Set
	End Property
	Private Sub btnAltas_Click(sender As System.Object, e As System.EventArgs) Handles btnAltas.Click

		Dim altasForm As New AltasPermisosForm
		altasForm.MdiParent = Me.MdiParent
		altasForm.Show()
		'AltasPermisosForm.Show()
	End Sub

	Private Sub txtModulo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub txtAccion_TextChanged(sender As System.Object, e As System.EventArgs)

	End Sub

	Private Sub txtAccion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
		e.Handled = True
		If Char.IsSeparator(e.KeyChar) _
		Or Char.IsLetterOrDigit(e.KeyChar) _
		Or Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub btnArriba_Click(sender As System.Object, e As System.EventArgs) Handles btnArriba.Click
		grbPermisos.Height = 38
		grdPermisos.Height = 328
		grdPermisos.Top = 124

	End Sub

	Private Sub btnAbajo_Click(sender As System.Object, e As System.EventArgs) Handles btnAbajo.Click
		grbPermisos.Height = 148
		grdPermisos.Height = 217
		grdPermisos.Top = 235

	End Sub

	Private Sub cmbModulo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbModulo.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbAccion_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAccion.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub cmbPerfil_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbPerfil.KeyPress
		e.Handled = True

		If Char.IsControl(e.KeyChar) Then

			e.Handled = False
		End If
	End Sub

	Private Sub ListaPermisoForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		InitCombos()

		If moduloid > 0 Then
			cmbModulo.SelectedValue = moduloid
		End If

		If accionid > 0 Then
			cmbAccion.SelectedValue = accionid
		End If

		If perfilid > 0 Then
			cmbPerfil.SelectedValue = perfilid
		End If

		llenarTabla()
	End Sub
	Public Sub llenarTabla()

		grdPermisos.Rows.Clear()

		Dim modulo As Int32 = 0
		Dim perfil As Int32 = 0
		Dim accion As Int32 = 0

		If cmbModulo.SelectedIndex > 0 Then
			modulo = CInt(cmbModulo.SelectedValue)

		End If

		If cmbAccion.SelectedIndex > 0 Then
			accion = CInt(cmbAccion.SelectedValue)
		End If

		If cmbPerfil.SelectedIndex > 0 Then
			perfil = CInt(cmbPerfil.SelectedValue)
		End If

		Dim listaPermisos As New List(Of Entidades.PermisosPerfil)
		Dim objBU As New Negocios.PermisosPerfilesBU
		listaPermisos = objBU.listaPermisosPerfiles(perfil, accion, modulo)
		For Each permisos As Entidades.PermisosPerfil In listaPermisos

			AgregarFila(permisos)


		Next
	End Sub

	Public Sub AgregarFila(ByVal permisos As Entidades.PermisosPerfil)

		Dim celda As DataGridViewCell
		Dim fila As New DataGridViewRow



		celda = New DataGridViewTextBoxCell
		celda.Value = permisos.Paccionid.PModulo.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = permisos.Paccionid.PModulo.PModuloid
		fila.Cells.Add(celda)


		celda = New DataGridViewTextBoxCell
		celda.Value = permisos.Paccionid.PNombre
		fila.Cells.Add(celda)

		celda = New DataGridViewTextBoxCell
		celda.Value = permisos.Paccionid.PAccionId
		fila.Cells.Add(celda)



		celda = New DataGridViewTextBoxCell
		celda.Value = permisos.Pperfilid.PNombre
		fila.Cells.Add(celda)

	

		celda = New DataGridViewTextBoxCell
		celda.Value = permisos.Pperfilid.Pperfilid
		fila.Cells.Add(celda)




		grdPermisos.Rows.Add(fila)


	End Sub
	Public Sub InitCombos()


		Dim objperfilBU As New Framework.Negocios.PerfilesBU
		Dim tablaperfil As New DataTable
		tablaperfil = objperfilBU.listaPerfilesActivos
		tablaperfil.Rows.InsertAt(tablaperfil.NewRow, 0)
		With cmbPerfil
			.DisplayMember = "perf_nombre"
			.ValueMember = "perf_perfilid"
			.DataSource = tablaperfil
		End With

		'Carga combo de acciones segun el modulo
		If cmbModulo.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbModulo.SelectedValue))
		End If


		Dim objmoduloBU As New Framework.Negocios.ModulosBU
		Dim tablamodulos As New DataTable
		tablamodulos = objmoduloBU.ListaModulosTodos
		tablamodulos.Rows.InsertAt(tablamodulos.NewRow, 0)
		With cmbModulo
			.DisplayMember = "modu_nombre"
			.ValueMember = "modu_moduloid"
			.DataSource = tablamodulos
		End With


	End Sub

	Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
		grdPermisos.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click

		cmbAccion.SelectedIndex = 0
		cmbModulo.SelectedIndex = 0
		cmbPerfil.SelectedIndex = 0

		grdPermisos.Rows.Clear()
		llenarTabla()
	End Sub

	Private Sub cmbModulo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbModulo.SelectedIndexChanged
		If cmbModulo.SelectedIndex > 0 Then
			cmbAccion = Controles.ComboAccionesSegunModulo(cmbAccion, CInt(cmbModulo.SelectedValue))
		End If
	End Sub

	Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click

        If MessageBox.Show("¿Esta seguro que quiere eliminar el permiso?", "Eliminar permisos", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


            Dim permisos As Int32 = 0
            Dim idperfil As Int32 = 0
            Dim idmodulo As Int32 = 0

            For Each fila As DataGridViewRow In grdPermisos.SelectedRows
                For Each columna As DataGridViewCell In fila.Cells
                    If (columna.OwningColumn.Name = "ColModuloid") Then
                        idmodulo = CInt(columna.Value)
                    End If
                    If (columna.OwningColumn.Name = "ColPerfilid") Then
                        idperfil = CInt(columna.Value)
                    End If
                    If (columna.OwningColumn.Name = "ColAccionid") Then
                        permisos = CInt(columna.Value)
                    End If
                Next
            Next

            Dim objpermisoBU As New PermisosPerfilesBU
            objpermisoBU.eliminarPermisos(permisos, idperfil, idmodulo)




            llenarTabla()
        Else



        End If


	End Sub

End Class