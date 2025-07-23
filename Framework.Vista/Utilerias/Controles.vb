Public Class Controles
    Dim PaisSeleccionado As Int32

    Public Shared Function ComboPaises(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPaises = New ComboBox
        ComboPaises = comboEntrada

        Dim listaPaises As New List(Of Entidades.Paises)
        Dim objBU As New Negocios.PaisesBU
        listaPaises = objBU.ListaPaises("", True)

        listaPaises.Insert(0, New Entidades.Paises)
        If listaPaises.Count > 0 Then
            ComboPaises.DataSource = listaPaises
            ComboPaises.DisplayMember = "PNombre"
            ComboPaises.ValueMember = "PIDPais"

        End If

    End Function
    Public Shared Function ComboEstados(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboEstados = New ComboBox
        ComboEstados = comboEntrada
        Dim listaEstados As New List(Of Entidades.Estados)
        Dim objBU As New Negocios.EstadosBU
        Dim objEN As New Entidades.Paises
        listaEstados = objBU.ListaEstados("", True, 0)

        listaEstados.Insert(0, New Entidades.Estados)
        If listaEstados.Count > 0 Then
            ComboEstados.DataSource = listaEstados
            ComboEstados.DisplayMember = "ENombre"
            ComboEstados.ValueMember = "EIDDEstado"
        End If
    End Function
	'listado grupos por perfil'
	Public Shared Function ComboDepartamentoSegunPerfiles(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idperfil As Integer) As System.Windows.Forms.ComboBox
		ComboDepartamentoSegunPerfiles = New ComboBox
		ComboDepartamentoSegunPerfiles = ComboEntrada
		Dim tabladepartamentos As New List(Of Entidades.Departamentos)
		Dim objdeptoBU As New Framework.Negocios.DepartamentosBU
		tabladepartamentos = objdeptoBU.ListaDepartamentosSegunPerfiles("", idperfil)

		tabladepartamentos.Insert(0, New Entidades.Departamentos)
		If tabladepartamentos.Count > 0 Then
			ComboDepartamentoSegunPerfiles.DataSource = tabladepartamentos
			ComboDepartamentoSegunPerfiles.DisplayMember = "Dnombre"
			ComboDepartamentoSegunPerfiles.ValueMember = "Ddepartamentoid"
		End If



	End Function
	'acciones por modulos'
	
	Public Shared Function ComboAccionesSegunModulo(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal moduloid As Integer) As System.Windows.Forms.ComboBox
		ComboAccionesSegunModulo = New ComboBox
		ComboAccionesSegunModulo = ComboEntrada
		Dim tablaAcciones As New List(Of Entidades.Acciones)
		Dim objAccionesBU As New Framework.Negocios.AccionesBU
		tablaAcciones = objAccionesBU.ListaAccionesSegunModulo(moduloid)

		tablaAcciones.Insert(0, New Entidades.Acciones)
		If tablaAcciones.Count > 0 Then
			ComboAccionesSegunModulo.DataSource = tablaAcciones
			ComboAccionesSegunModulo.DisplayMember = "PNombre"
			ComboAccionesSegunModulo.ValueMember = "PAccionId"
		End If

	End Function
	'PERFILES SEGUN DEPARTAMENTO

	Public Shared Function ComboPerfilSegunDepartamento(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal departamentoid As Integer) As System.Windows.Forms.ComboBox
		ComboPerfilSegunDepartamento = New ComboBox
		ComboPerfilSegunDepartamento = ComboEntrada
		Dim tablaPerfiles As New List(Of Entidades.Perfiles)
		Dim objAccionesBU As New Framework.Negocios.PerfilesBU
		tablaPerfiles = objAccionesBU.ListaPerfilesSegunDepartamentos(departamentoid)

		tablaPerfiles.Insert(0, New Entidades.Perfiles)
		If tablaPerfiles.Count > 0 Then
			ComboPerfilSegunDepartamento.DataSource = tablaPerfiles
			ComboPerfilSegunDepartamento.DisplayMember = "PNombre"
			ComboPerfilSegunDepartamento.ValueMember = "Pperfilid"
		End If

	End Function

	Public Shared Function ComboEstadosAnidado(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal paisid As Integer) As System.Windows.Forms.ComboBox
		ComboEstadosAnidado = New ComboBox
		ComboEstadosAnidado = comboEntrada

		Dim listaEstados As New List(Of Entidades.Estados)
		Dim objBU As New Negocios.EstadosBU
		Dim objEN As New Entidades.Paises

		listaEstados = objBU.ListaEstados("", True, paisid)

		listaEstados.Insert(0, New Entidades.Estados)
		If listaEstados.Count > 0 Then
			ComboEstadosAnidado.DataSource = listaEstados
			ComboEstadosAnidado.DisplayMember = "ENombre"
			ComboEstadosAnidado.ValueMember = "EIDDEstado"
		End If
	End Function


    Public Shared Function ComboCiudades(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal estadoID As Integer) As System.Windows.Forms.ComboBox
        ComboCiudades = New ComboBox
        ComboCiudades = comboEntrada
        Dim listaCiudades As New DataTable
        Dim objBU As New Framework.Negocios.CiudadesBU
        listaCiudades = objBU.listaCiudadesActivas(estadoID)
        listaCiudades.Rows.InsertAt(listaCiudades.NewRow, 0)
        ComboCiudades.DataSource = listaCiudades
        ComboCiudades.DisplayMember = "city_nombre"
        ComboCiudades.ValueMember = "city_ciudadid"

    End Function
	Public Shared Function ComboNaves(ByVal comboentrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
		ComboNaves = New ComboBox
		ComboNaves = comboentrada
		Dim listaNaves As New DataTable
		Dim objBU As New Framework.Negocios.NavesBU
		listaNaves = objBU.listaNavesActivas
		listaNaves.Rows.InsertAt(listaNaves.NewRow, 0)
		ComboNaves.DataSource = listaNaves
		ComboNaves.DisplayMember = "nave_nombre"
		ComboNaves.ValueMember = "nave_naveid"

	End Function
	Public Shared Function ComboDepatamentoSegunArea(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal idArea As Int32) As System.Windows.Forms.ComboBox
		Dim comboDepartamentos As New ComboBox
		comboDepartamentos = comboEntrada
		Dim tabladepartamentos As New DataTable
		Dim objDepartamentosBU As New Framework.Negocios.DepartamentosBU
		tabladepartamentos = objDepartamentosBU.listaDepartamentosSegunArea(idArea)
		tabladepartamentos.Rows.InsertAt(tabladepartamentos.NewRow, 0)
		comboDepartamentos.DataSource = tabladepartamentos
		comboDepartamentos.DisplayMember = "grup_name"
		comboDepartamentos.ValueMember = "grup_grupoid"
		Return comboDepartamentos

	End Function
End Class
