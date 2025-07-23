Imports System.Net
Imports Framework
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors.UltraComboEditor

Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Infragistics.Win.UltraWinGrid



Public Class Controles

    Dim PaisSeleccionado As Int32
    ''' <summary>
    ''' Genera combo con la lista de paises del sistema
    ''' </summary>
    ''' <param name="comboEntrada">Combo con las propiedades que heredará el nuevo combo</param>
    ''' <returns>Combo con el catálogo de paises activos y propiedades heredadas</returns>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' Genera combo con la lista de estados del sistema
    ''' </summary>
    ''' <param name="comboEntrada">Combo con las propiedades que heredará el nuevo combo</param>
    ''' <returns>Combo con el catálogo de estados activos y propiedades heredadas</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboEstados(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal paisID As Integer) As System.Windows.Forms.ComboBox
        ComboEstados = New ComboBox
        ComboEstados = comboEntrada
        Dim listaEstados As New List(Of Entidades.Estados)
        Dim objBU As New Negocios.EstadosBU
        Dim objEN As New Entidades.Paises
        listaEstados = objBU.ListaEstadosPais("", True, paisID)

        listaEstados.Insert(0, New Entidades.Estados)
        If listaEstados.Count > 0 Then
            ComboEstados.DisplayMember = "ENombre"
            ComboEstados.ValueMember = "EIDDEstado"
            ComboEstados.DataSource = listaEstados
        End If
    End Function

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

    Public Shared Function ComboCiudadesMayusculas(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal estadoID As Integer) As System.Windows.Forms.ComboBox
        ComboCiudadesMayusculas = New ComboBox
        ComboCiudadesMayusculas = comboEntrada
        Dim listaCiudades As New DataTable
        Dim objBU As New Framework.Negocios.CiudadesBU
        listaCiudades = objBU.listaCiudadesActivasMayusculas(estadoID)
        listaCiudades.Rows.InsertAt(listaCiudades.NewRow, 0)
        ComboCiudadesMayusculas.DisplayMember = "city_nombre"
        ComboCiudadesMayusculas.ValueMember = "city_ciudadid"
        ComboCiudadesMayusculas.DataSource = listaCiudades
    End Function

    Public Shared Function ComboPoblaciones(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal ciudadID As Integer) As System.Windows.Forms.ComboBox
        ComboPoblaciones = New ComboBox
        ComboPoblaciones = comboEntrada
        Dim listaPoblaciones As New DataTable
        Dim objBU As New Framework.Negocios.PoblacionBU
        listaPoblaciones = objBU.listaPoblacion(ciudadID)
        listaPoblaciones.Rows.InsertAt(listaPoblaciones.NewRow, 0)
        ComboPoblaciones.DataSource = listaPoblaciones
        ComboPoblaciones.DisplayMember = "pobl_nombre"
        ComboPoblaciones.ValueMember = "pobl_poblacionid"

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

    Public Shared Function ComboCadenasSicy(ByVal comboentrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboCadenasSicy = New ComboBox
        ComboCadenasSicy = comboentrada
        Dim dtListaCadenasClientes As New DataTable
        Dim objBU As New Almacen.Negocios.EntradaProductoBU
        dtListaCadenasClientes = objBU.ListaDeCadenasActivas
        dtListaCadenasClientes.Rows.InsertAt(dtListaCadenasClientes.NewRow, 0)
        ComboCadenasSicy.DataSource = dtListaCadenasClientes
        ComboCadenasSicy.DisplayMember = "Nombre"
        ComboCadenasSicy.ValueMember = "idCadena"

    End Function

    Public Shared Function UltraComboEditorsCadenasSicy(ByVal comboEntrada As UltraWinEditors.UltraComboEditor) As UltraWinEditors.UltraComboEditor
        UltraComboEditorsCadenasSicy = New UltraWinEditors.UltraComboEditor
        UltraComboEditorsCadenasSicy = comboEntrada
        Dim dtListaCadenasClientes As New DataTable
        Dim objBU As New Almacen.Negocios.EntradaProductoBU
        dtListaCadenasClientes = objBU.ListaDeCadenasActivas
        'dtListaCadenasClientes.Rows.InsertAt(dtListaCadenasClientes.NewRow, 0)
        UltraComboEditorsCadenasSicy.DataSource = dtListaCadenasClientes
        UltraComboEditorsCadenasSicy.DisplayMember = "Nombre"
        UltraComboEditorsCadenasSicy.ValueMember = "idCadena"

    End Function

    Public Shared Function UltraComboCadenasSicy(ByVal comboEntrada As UltraWinGrid.UltraCombo) As UltraWinGrid.UltraCombo
        UltraComboCadenasSicy = New UltraWinGrid.UltraCombo
        UltraComboCadenasSicy = comboEntrada
        Dim dtListaCadenasClientes As New DataTable
        Dim objBU As New Almacen.Negocios.EntradaProductoBU
        dtListaCadenasClientes = objBU.ListaDeCadenasActivas
        dtListaCadenasClientes.Rows.InsertAt(dtListaCadenasClientes.NewRow, 0)
        UltraComboCadenasSicy.DataSource = dtListaCadenasClientes
        UltraComboCadenasSicy.DisplayMember = "Nombre"
        UltraComboCadenasSicy.ValueMember = "idCadena"

    End Function


    Public Shared Function ComboMotivoFiniquitos(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IdNave As UInt32) As System.Windows.Forms.ComboBox
        ComboMotivoFiniquitos = New ComboBox
        ComboMotivoFiniquitos = comboEntrada
        Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
        Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
        listaMotivos = objBU.MotivosFiniquitoSegunNave(IdNave)
        listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
        If listaMotivos.Count > 0 Then
            ComboMotivoFiniquitos.DataSource = listaMotivos
            ComboMotivoFiniquitos.DisplayMember = "PNombre"
            ComboMotivoFiniquitos.ValueMember = "PMotivoFiniquitoId"
        End If

    End Function


    ''' <summary>
    ''' LISTA DE NAVES A LAS QUE TIENE PERMISO EL USUARIO QUE ESTA LOGUEADO. SELECCIONA POR DEFAULT LA PRIMERA NAVE
    ''' </summary>
    ''' <param name="ComboEntrada">COMBO COMO TAL TODO EL CONTROL</param>
    ''' <param name="IDUsuario">ID DEL USUARIO QUE ESTA EN SESION, SE SACA DE LA CLASE SESIONUSUARIO</param>
    ''' <returns>REGRESA EL COMBO CON LA LISTA DE NAVES</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboNavesSegunUsuario(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer) As System.Windows.Forms.ComboBox
        ComboNavesSegunUsuario = New ComboBox
        ComboNavesSegunUsuario = ComboEntrada
        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesSegunUsuario("", IDUsuario)

        tablaNaves.Insert(0, New Entidades.Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesSegunUsuario.DataSource = tablaNaves
            ComboNavesSegunUsuario.DisplayMember = "PNombre"
            ComboNavesSegunUsuario.ValueMember = "PNaveId"
        End If

        'If tablaNaves.Count = 2 Then
        '    ComboNavesSegunUsuario.SelectedIndex = 1
        '    '  ComboNavesSegunUsuario.Enabled = False
        'End If

        'If tablaNaves.Count > 2 Then
        ComboNavesSegunUsuario.SelectedIndex = 0
        'End If
    End Function


    Public Shared Function ComboNavesSegunUsuario_Especial(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer) As System.Windows.Forms.ComboBox
        ComboNavesSegunUsuario_Especial = New ComboBox
        ComboNavesSegunUsuario_Especial = ComboEntrada
        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesSegunUsuario_Especial(IDUsuario)

        tablaNaves.Insert(0, New Entidades.Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesSegunUsuario_Especial.DataSource = tablaNaves
            ComboNavesSegunUsuario_Especial.DisplayMember = "PNombre"
            ComboNavesSegunUsuario_Especial.ValueMember = "PNaveId"
        End If

        'If tablaNaves.Count = 2 Then
        '    ComboNavesSegunUsuario.SelectedIndex = 1
        '    '  ComboNavesSegunUsuario.Enabled = False
        'End If

        'If tablaNaves.Count > 2 Then
        ComboNavesSegunUsuario_Especial.SelectedIndex = 0
        'End If
    End Function

    Public Shared Function ComboNavesSegunUsuarioMaquilas(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer, ByVal PermisoMaquilas As Boolean) As System.Windows.Forms.ComboBox
        ComboNavesSegunUsuarioMaquilas = New ComboBox
        ComboNavesSegunUsuarioMaquilas = ComboEntrada
        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesSegunUsuarioMaquilas(IDUsuario, PermisoMaquilas)

        tablaNaves.Insert(0, New Entidades.Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesSegunUsuarioMaquilas.DataSource = tablaNaves
            ComboNavesSegunUsuarioMaquilas.DisplayMember = "PNombre"
            ComboNavesSegunUsuarioMaquilas.ValueMember = "PNaveId"
        End If

        'If tablaNaves.Count = 2 Then
        '    ComboNavesSegunUsuario.SelectedIndex = 1
        '    '  ComboNavesSegunUsuario.Enabled = False
        'End If

        'If tablaNaves.Count > 2 Then
        ComboNavesSegunUsuarioMaquilas.SelectedIndex = 0
        'End If
    End Function




    ''' <summary>
    ''' LISTA DE NAVES A LAS QUE TIENE PERMISO EL USUARIO QUE ESTA LOGUEADO. SELECCIONA POR DEFAULT LA PRIMERA NAVE
    ''' </summary>
    ''' <param name="ComboEntrada">COMBO COMO TAL TODO EL CONTROL</param>
    ''' <param name="IDUsuario">ID DEL USUARIO QUE ESTA EN SESION, SE SACA DE LA CLASE SESIONUSUARIO</param>
    ''' <returns>REGRESA EL COMBO CON LA LISTA DE NAVES</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboNavesSegunUsuarioConIdSIcy(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer) As System.Windows.Forms.ComboBox
        ComboNavesSegunUsuarioConIdSIcy = New ComboBox
        ComboNavesSegunUsuarioConIdSIcy = ComboEntrada
        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesConIdSicy_SegunUsuario("", IDUsuario)

        tablaNaves.Insert(0, New Entidades.Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesSegunUsuarioConIdSIcy.DataSource = tablaNaves
            ComboNavesSegunUsuarioConIdSIcy.DisplayMember = "PNombre"
            ComboNavesSegunUsuarioConIdSIcy.ValueMember = "PNaveSICYid"
        End If

        If tablaNaves.Count = 2 Then
            ComboNavesSegunUsuarioConIdSIcy.SelectedIndex = 1
            '  ComboNavesSegunUsuario.Enabled = False
        End If

        If tablaNaves.Count > 2 Then
            ComboNavesSegunUsuarioConIdSIcy.SelectedIndex = 0
        End If
    End Function



    Public Shared Function ComboNavesConAlmacenSegunUsuario(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer) As System.Windows.Forms.ComboBox
        ComboNavesConAlmacenSegunUsuario = New ComboBox
        ComboNavesConAlmacenSegunUsuario = ComboEntrada
        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesConAlmacenSegunUsuario(IDUsuario)

        tablaNaves.Insert(0, New Entidades.Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesConAlmacenSegunUsuario.DataSource = tablaNaves
            ComboNavesConAlmacenSegunUsuario.DisplayMember = "PNombre"
            ComboNavesConAlmacenSegunUsuario.ValueMember = "PNaveId"
        End If

        If tablaNaves.Count = 2 Then
            ComboNavesConAlmacenSegunUsuario.SelectedIndex = 1
            '  ComboNavesSegunUsuario.Enabled = False
        End If

        If tablaNaves.Count > 2 Then
            ComboNavesConAlmacenSegunUsuario.SelectedIndex = 0
        End If

    End Function


    Public Shared Function ComboAlmacenSegunNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal naveID As Integer) As System.Windows.Forms.ComboBox
        ComboAlmacenSegunNave = New ComboBox
        ComboAlmacenSegunNave = ComboEntrada
        Dim tablaAlmacen As New List(Of Integer)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaAlmacen = objNavesBU.ListaAlmacenSegunNave(naveID)

        If tablaAlmacen.Count > 0 Then
            ComboAlmacenSegunNave.DataSource = tablaAlmacen
            'ComboAlmacenSegunNave.DisplayMember = "bahi_almacen"
            'ComboAlmacenSegunNave.ValueMember = "bahi_almacen"
        End If

    End Function


    Public Shared Function ComboTiposCarritos(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTiposCarritos = New ComboBox
        ComboTiposCarritos = ComboEntrada
        Dim tablaTiposCarritos As New DataTable
        Dim objBU As New Almacen.Negocios.ClientesAlmacenBU
        tablaTiposCarritos = objBU.ListaTiposCarritos()

        If tablaTiposCarritos.Rows.Count > 0 Then
            ComboTiposCarritos.DataSource = tablaTiposCarritos
            ComboTiposCarritos.DisplayMember = "tica_descripcion"
            ComboTiposCarritos.ValueMember = "tica_tipocarritoid"
        End If

    End Function


    Public Shared Function ComboMotivosIncentivoSegunUsuario(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer) As System.Windows.Forms.ComboBox
        ComboMotivosIncentivoSegunUsuario = New ComboBox
        ComboMotivosIncentivoSegunUsuario = ComboEntrada
        Dim tablaIncentivos As New List(Of Entidades.Incentivos)
        Dim objIncentivoBU As New Nomina.Negocios.IncentivosBU
        tablaIncentivos = objIncentivoBU.ListaIncentivosSUser(IDUsuario)

        tablaIncentivos.Insert(0, New Entidades.Incentivos)
        If tablaIncentivos.Count > 0 Then
            ComboMotivosIncentivoSegunUsuario.DataSource = tablaIncentivos
            ComboMotivosIncentivoSegunUsuario.DisplayMember = "INombre"
            ComboMotivosIncentivoSegunUsuario.ValueMember = "IIncentivoId"
        End If

    End Function


    Public Shared Function ComboDepartamentos(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboDepartamentos = New ComboBox
        ComboDepartamentos = comboEntrada
        Dim tablaDeptos As New DataTable
        Dim objDeptosBu As New Framework.Negocios.DepartamentosBU
        tablaDeptos = objDeptosBu.listaDepartamentosActivos
        tablaDeptos.Rows.InsertAt(tablaDeptos.NewRow, 0)
        ComboDepartamentos.DataSource = tablaDeptos
        ComboDepartamentos.DisplayMember = "grup_name"
        ComboDepartamentos.ValueMember = "grup_grupoid"
    End Function


    Public Shared Function ComboDepatamentoSegunNave(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IDNave As Int32) As System.Windows.Forms.ComboBox
        Dim comboDepartamentos As New ComboBox
        comboDepartamentos = comboEntrada
        Dim tabladepartamentos As New DataTable
        Dim objDepartamentosBU As New Framework.Negocios.DepartamentosBU
        tabladepartamentos = objDepartamentosBU.listaDepartamentosSegunNave(IDNave)
        tabladepartamentos.Rows.InsertAt(tabladepartamentos.NewRow, 0)
        comboDepartamentos.DataSource = tabladepartamentos
        comboDepartamentos.DisplayMember = "grup_name"
        comboDepartamentos.ValueMember = "grup_grupoid"
        Return comboDepartamentos

    End Function


    ''' <summary>
    ''' REGRESA EL COMBO CON LA LISTA DE AREAS DE LA NAVE SELECCIONADA.
    ''' </summary>
    ''' <param name="comboEntrada">CONTROL DONDE SE QUIERE CARGAR LA LISTA</param>
    ''' <param name="IDNave">NAVE DE DONDE SE QUIERAN OBTENER LAS AREAS</param>
    ''' <returns>COMBO CON LAS AREAS ENCONTRADAS</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboAreaSegunNave(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IDNave As Int32) As System.Windows.Forms.ComboBox
        Dim comboAreas As New ComboBox
        comboAreas = comboEntrada
        Dim tablaAreas As New DataTable
        Dim objAreasBU As New Nomina.Negocios.AreasBU
        tablaAreas = objAreasBU.listaAreasSegunNave(IDNave)
        tablaAreas.Rows.InsertAt(tablaAreas.NewRow, 0)
        comboAreas.DataSource = tablaAreas
        comboAreas.DisplayMember = "area_nombre"
        comboAreas.ValueMember = "area_areaid"
        Return comboAreas

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


    Public Shared Function ComboDepartamentosSegunNavesUsuario(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        Dim ComboDepartamentos As New ComboBox
        ComboDepartamentos = comboEntrada
        Dim tablaDeptos As New DataTable
        Dim objDeptosBu As New Framework.Negocios.DepartamentosBU
        tablaDeptos = objDeptosBu.listaDepartamentosPorNavesUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        tablaDeptos.Rows.InsertAt(tablaDeptos.NewRow, 0)
        ComboDepartamentos.DataSource = tablaDeptos
        ComboDepartamentos.DisplayMember = "grup_name"
        ComboDepartamentos.ValueMember = "grup_grupoid"
        Return ComboDepartamentos
    End Function

    Public Shared Function ComboPuestos(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPuestos = New ComboBox
        ComboPuestos = comboEntrada
        Dim tablaPuestos As New DataTable
        Dim objPuestosBu As New Framework.Negocios.puestosBU
        tablaPuestos = objPuestosBu.listaPuestosActivos
        tablaPuestos.Rows.InsertAt(tablaPuestos.NewRow, 0)
        ComboPuestos.DataSource = tablaPuestos
        ComboPuestos.DisplayMember = "pues_nombre"
        ComboPuestos.ValueMember = "pues_puestoid"
    End Function

    Public Shared Function ComboPuestosSegunDepartamento(ByVal comboentrada As System.Windows.Forms.ComboBox, ByVal idDepartamento As Int32) As System.Windows.Forms.ComboBox
        ComboPuestosSegunDepartamento = New ComboBox
        ComboPuestosSegunDepartamento = comboentrada
        Dim tablapuestos As New DataTable
        Dim objPuestos As New Framework.Negocios.puestosBU
        tablapuestos = objPuestos.listaPuestosSegunDepartamento(idDepartamento)
        tablapuestos.Rows.InsertAt(tablapuestos.NewRow, 0)
        ComboPuestosSegunDepartamento.DataSource = tablapuestos
        ComboPuestosSegunDepartamento.DisplayMember = "pues_nombre"
        ComboPuestosSegunDepartamento.ValueMember = "pues_puestoid"

    End Function

    Public Shared Function ComboHorarios(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboHorarios = New ComboBox
        ComboHorarios = comboEntrada
        Dim tablaHorarios As New DataTable
        Dim objHorariosBU As New Nomina.Negocios.HorariosBU
        tablaHorarios = objHorariosBU.listaHorariosActivos
        tablaHorarios.Rows.InsertAt(tablaHorarios.NewRow, 0)
        ComboHorarios.DataSource = tablaHorarios
        ComboHorarios.DisplayMember = "hora_nombre"
        ComboHorarios.ValueMember = "hora_horarioid"
    End Function

    Public Shared Function ComboCelulas(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboCelulas = New ComboBox
        ComboCelulas = comboEntrada
        Dim tablaCelulas As New DataTable
        Dim objCelulasBu As New Nomina.Negocios.CelulasBU
        tablaCelulas = objCelulasBu.listaCelulasActivas
        tablaCelulas.Rows.InsertAt(tablaCelulas.NewRow, 0)
        ComboCelulas.DataSource = tablaCelulas
        ComboCelulas.DisplayMember = "celu_nombre"
        ComboCelulas.ValueMember = "celu_celulaid"
    End Function

    Public Shared Function ComboCelulasSegunDepartamento(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal idDepartamento As Int32) _
     As System.Windows.Forms.ComboBox
        ComboCelulasSegunDepartamento = New ComboBox
        ComboCelulasSegunDepartamento = ComboEntrada
        Dim tablaCelulas As New DataTable
        Dim objCelulasBU As New Nomina.Negocios.CelulasBU
        tablaCelulas = objCelulasBU.ListaCelulasegunDepartamento(idDepartamento)
        tablaCelulas.Rows.InsertAt(tablaCelulas.NewRow, 0)
        ComboCelulasSegunDepartamento.DataSource = tablaCelulas
        ComboCelulasSegunDepartamento.DisplayMember = "celu_nombre"
        ComboCelulasSegunDepartamento.ValueMember = "celu_celulaid"

    End Function

    Public Shared Function ComboPatrones(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPatrones = New ComboBox
        ComboPatrones = comboEntrada
        Dim objPatronesBu As New Nomina.Negocios.PatronesBU
        Dim tablaPatrones As New DataTable
        tablaPatrones = objPatronesBu.listaPatronesActivos()
        tablaPatrones.Rows.InsertAt(tablaPatrones.NewRow, 0)
        ComboPatrones.DataSource = tablaPatrones
        ComboPatrones.DisplayMember = "patr_nombre"
        ComboPatrones.ValueMember = "patr_patronid"
    End Function

    ''' <summary>
    ''' REGRESA EL COMBO CON LOS DEPARTAMENTOS DEL AREA SELECCIONADA
    ''' </summary>
    ''' <param name="comboEntrada">EL CONTROL DONDE SE QUIERE CARGAR LA LISTA</param>
    ''' <param name="idArea">EL AREA SELECCIONADA EN EL COMBO DE AREAS</param>
    ''' <returns>EL COMBO LLENO CON LA LISTA DE DEPARTAMENTOS DEL AREA SELECCIONADA</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboDepartamentosSegunArea(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal idArea As Int32) As System.Windows.Forms.ComboBox
        ComboDepartamentosSegunArea = New ComboBox
        ComboDepartamentosSegunArea = comboEntrada
        Dim objtabladepartamentosBU As New Framework.Negocios.DepartamentosBU
        Dim tablaDepartamentos As New DataTable
        tablaDepartamentos = objtabladepartamentosBU.listaDepartamentosSegunArea(idArea)
        tablaDepartamentos.Rows.InsertAt(tablaDepartamentos.NewRow, 0)
        ComboDepartamentosSegunArea.DataSource = tablaDepartamentos
        ComboDepartamentosSegunArea.DisplayMember = "grup_name"
        ComboDepartamentosSegunArea.ValueMember = "grup_grupoid"

    End Function


    ''' <summary>
    ''' REGRESA EL COMBO CON LA LISTA DE LOS COLABORADORES POR DEPARTAMENTO
    ''' </summary>
    ''' <param name="comboEntrada">EL CONTROL COMBOBOX DONDE SE REQUIERE CARGAR LA LISTA </param>
    ''' <param name="IDDepto">ID DEPARTAMENTO PARA FILTRAR LOS COLABORADORES</param>
    ''' <returns>EL COMBO CON LA LISTA DE LOS COLABORADPRES POR DEPARTAMENTO</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboColaboradoresSegunDepto(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IDDepto As Int32) As System.Windows.Forms.ComboBox
        Dim comboColaboradores As New ComboBox
        comboColaboradores = comboEntrada
        Dim tablaColaboradores As New DataTable
        Dim objColaboradorBU As New Nomina.Negocios.ColaboradoresBU
        tablaColaboradores = objColaboradorBU.listaColaboradoresDepto(IDDepto)
        tablaColaboradores.Rows.InsertAt(tablaColaboradores.NewRow, 0)
        comboColaboradores.DataSource = tablaColaboradores
        comboColaboradores.DisplayMember = "NombreColaborador"
        comboColaboradores.ValueMember = "IdColaborador"
        Return comboColaboradores
    End Function


    Public Shared Function ComboEstatusCajaAhorro(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboEstatusCajaAhorro = New ComboBox
        ComboEstatusCajaAhorro = comboEntrada

        Dim objCajaAhorroBU As New Nomina.Negocios.CajaAhorroBU
        Dim tablaEstatus As New DataTable

        tablaEstatus = objCajaAhorroBU.ListarEstatusCajaAhorro()
        tablaEstatus.Rows.InsertAt(tablaEstatus.NewRow, 0)

        ComboEstatusCajaAhorro.DataSource = tablaEstatus
        ComboEstatusCajaAhorro.DisplayMember = "Estatus"
        ComboEstatusCajaAhorro.ValueMember = "Caja_Estado"


    End Function


    Public Shared Function ComboPeriodosNomina(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IdCajaAhorro As Int32) As System.Windows.Forms.ComboBox
        ComboPeriodosNomina = New ComboBox
        ComboPeriodosNomina = comboEntrada

        Dim objPeriodosNominaBU As New Nomina.Negocios.ControlDePeriodoBU
        Dim tabla As New DataTable

        tabla = objPeriodosNominaBU.ListarPeriodosdeNomina(IdCajaAhorro)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboPeriodosNomina.DataSource = tabla
        ComboPeriodosNomina.DisplayMember = "pnom_concepto"
        ComboPeriodosNomina.ValueMember = "pnom_periodonomid"
    End Function


    Public Shared Function ComboOperadoresAlmacen(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboOperadoresAlmacen = New ComboBox
        ComboOperadoresAlmacen = comboEntrada

        Dim objOperadoresPCiclicoBU As New Almacen.Negocios.InventarioCiclicoBU
        Dim tabla As New DataTable

        tabla = objOperadoresPCiclicoBU.ListaOperadoresAlmacenSicy()
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboOperadoresAlmacen.DataSource = tabla
        ComboOperadoresAlmacen.ValueMember = "Parámetro"
        ComboOperadoresAlmacen.DisplayMember = "Operador"
    End Function



    Public Shared Function ComboNombreComercialCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal clienteID As Integer) As System.Windows.Forms.ComboBox
        ComboNombreComercialCliente = New ComboBox
        ComboNombreComercialCliente = comboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.buscarClientesNombreComercial(clienteID)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboNombreComercialCliente.DataSource = tabla
        ComboNombreComercialCliente.DisplayMember = "clie_nombregenerico"
        ComboNombreComercialCliente.ValueMember = "clie_clienteid"

        'Dim strCol As New AutoCompleteStringCollection

        'For Each row As DataRow In tabla.Rows
        '    strCol.Add(row("clie_nombregenerico").ToString)
        'Next

        'ComboNombreComercialCliente.AutoCompleteCustomSource = strCol
        'ComboNombreComercialCliente.AutoCompleteMode = AutoCompleteMode.Suggest
        'ComboNombreComercialCliente.AutoCompleteSource = AutoCompleteSource.CustomSource


    End Function




    ''' <summary>
    ''' RECUPERA LAS LISTAS DE PRECIOS ASIGNADAS A UN CLIENTE Y LA ASIGNA A UN COMBO BOX
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX AL QUE SE LE ASIGNARALA INFORMACION RECUPERADA</param>
    ''' <param name="clienteID">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LAS LISTAS DE PRECIOS</param>
    ''' <returns>COMBO BOX CON LA LISTA DE PRECIOS ASIGNADA AL DATASOURSE</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboListasDePrecios(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal clienteID As Integer, ByVal NoAsignadas As Boolean, ByVal LVAsignada As Boolean) As System.Windows.Forms.ComboBox
        ComboListasDePrecios = New ComboBox
        ComboListasDePrecios = ComboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.buscarListasDePreciosDeCliente(clienteID, NoAsignadas, LVAsignada)

        If clienteID > 0 And NoAsignadas = True Then
            tabla.Rows.InsertAt(tabla.NewRow, 0)
        End If

        ComboListasDePrecios.DataSource = tabla
        ComboListasDePrecios.DisplayMember = "Lista"
        ComboListasDePrecios.ValueMember = "Id"
        ComboListasDePrecios.DropDownStyle = ComboBoxStyle.DropDownList
    End Function


    Public Shared Function ComboNombreVendedorSegunCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboNombreVendedorSegunCliente = New ComboBox
        ComboNombreVendedorSegunCliente = comboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.ListaVendedor()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboNombreVendedorSegunCliente.DataSource = tabla
        ComboNombreVendedorSegunCliente.DisplayMember = "codr_nombre_completo"
        ComboNombreVendedorSegunCliente.ValueMember = "codr_colaboradorid"

    End Function

    Public Shared Function ComboAtnCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboAtnCliente = New ComboBox
        ComboAtnCliente = comboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.ListaAtnClientes()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboAtnCliente.DataSource = tabla
        ComboAtnCliente.DisplayMember = "codr_nombre_completo"
        ComboAtnCliente.ValueMember = "codr_colaboradorid"

    End Function

    Public Shared Function ComboClasificacionCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboClasificacionCliente = New ComboBox
        ComboClasificacionCliente = comboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.ListaClasificacionCliente()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboClasificacionCliente.DataSource = tabla
        ComboClasificacionCliente.DisplayMember = "clas_nombre"
        ComboClasificacionCliente.ValueMember = "clas_clasificacioclientenid"

    End Function

    Public Shared Function ComboEmpresaActiva(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboEmpresaActiva = New ComboBox
        ComboEmpresaActiva = comboEntrada

        Dim empresasBU As New Framework.Negocios.EmpresasBU
        Dim tabla As New DataTable

        tabla = empresasBU.listaEmpresas()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboEmpresaActiva.DataSource = tabla
        ComboEmpresaActiva.DisplayMember = "empr_nombre"
        ComboEmpresaActiva.ValueMember = "empr_empresaid"

    End Function

    Public Shared Function ComboTipoCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoCliente = New ComboBox
        ComboTipoCliente = comboEntrada

        Dim TipoCliente As New Ventas.Negocios.TipoClienteBU
        Dim tabla As New DataTable

        tabla = TipoCliente.ListaTiposCliente()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoCliente.DataSource = tabla
        ComboTipoCliente.DisplayMember = "ticl_nombre"
        ComboTipoCliente.ValueMember = "ticl_tipoclienteid"

    End Function

    Public Shared Function ComboFormaPago(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboFormaPago = New ComboBox
        ComboFormaPago = comboEntrada

        Dim FormaPago As New Ventas.Negocios.FormaPagoBU
        Dim tabla As New DataTable

        tabla = FormaPago.ListadoFormaPago()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboFormaPago.DataSource = tabla
        ComboFormaPago.DisplayMember = "fopa_nombre"
        ComboFormaPago.ValueMember = "fopa_formapagoid"

    End Function


    Public Shared Function ComboMetodoPago(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboMetodoPago = New ComboBox
        ComboMetodoPago = comboEntrada

        Dim MetodoPago As New Ventas.Negocios.MetodoPagoBU
        Dim tabla As New DataTable

        tabla = MetodoPago.ListadoMetodoPago()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboMetodoPago.DataSource = tabla
        ComboMetodoPago.DisplayMember = "mepa_nombre"
        ComboMetodoPago.ValueMember = "mepa_metodopagoid"

    End Function

    Public Shared Function ComboMetodoPago_NotaCredito(ByVal comboEntrada As ComboBox) As ComboBox
        ComboMetodoPago_NotaCredito = New ComboBox
        ComboMetodoPago_NotaCredito = comboEntrada

        Dim metodoPagoBu As New Ventas.Negocios.MetodoPagoBU
        Dim tabla As New DataTable

        tabla = metodoPagoBu.ListaMetodoPago_NotaCredito()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboMetodoPago_NotaCredito.DataSource = tabla
        ComboMetodoPago_NotaCredito.DisplayMember = "MetodoPago"
        ComboMetodoPago_NotaCredito.ValueMember = "fopa_formapagoid"
    End Function

    Public Shared Function CombosCobranzaNotaCredito(ByVal clienteID As Integer)
        Dim metodoPagoBu As New Ventas.Negocios.MetodoPagoBU
        Dim tabla As New DataTable

        tabla = metodoPagoBu.ListaMetodoFormaPago_NotaCredito(clienteID)
        Return tabla
    End Function

    Public Shared Function ComboFormaPago_NotaCredito(ByVal comboEntrada As ComboBox) As ComboBox
        ComboFormaPago_NotaCredito = New ComboBox
        ComboFormaPago_NotaCredito = comboEntrada

        Dim formaPagoBU As New Ventas.Negocios.FormaPagoBU
        Dim tabla As New DataTable

        tabla = formaPagoBU.ListadoFormaPago_NotaCredito()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboFormaPago_NotaCredito.DataSource = tabla
        ComboFormaPago_NotaCredito.DisplayMember = "FormaPago"
        ComboFormaPago_NotaCredito.ValueMember = "mepa_metodopagoid"
    End Function

    Public Shared Function ComboColaboradorValidador(ByVal comboEntrada As System.Windows.Forms.ComboBox, usuarioID As Integer, tipoValidacion As Integer) As System.Windows.Forms.ComboBox

        ComboColaboradorValidador = New ComboBox
        ComboColaboradorValidador = comboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.buscarColaboradorValidador(usuarioID, tipoValidacion)

        ComboColaboradorValidador.DataSource = tabla
        ComboColaboradorValidador.DisplayMember = "codr_nombre_completo"
        ComboColaboradorValidador.ValueMember = "vati_colaboradorid"

    End Function



    Public Shared Function ComboTiposFlete(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTiposFlete = New ComboBox
        ComboTiposFlete = comboEntrada

        Dim objbu As New Framework.Negocios.ProveedorBU
        Dim tabla As New DataTable

        tabla = objbu.ListaTiposFletes

        ComboTiposFlete.DataSource = tabla
        ComboTiposFlete.DisplayMember = "tifl_nombre"
        ComboTiposFlete.ValueMember = "tifl_tipofleteid"

    End Function




    Public Shared Function ComboValidacionCobranza(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal clienteID As Integer) As System.Windows.Forms.ComboBox

        ComboValidacionCobranza = New ComboBox
        ComboValidacionCobranza = comboEntrada

        Dim objClientesBU As New Ventas.Negocios.ClientesBU
        Dim tabla As New DataTable

        tabla = objClientesBU.buscarNombreCobradorSegunCliente(clienteID)
        If clienteID = 0 Then
            tabla.Rows.InsertAt(tabla.NewRow, 0)
        End If

        ComboValidacionCobranza.DataSource = tabla
        ComboValidacionCobranza.DisplayMember = "codr_nombre_completo".Trim
        If clienteID <> 0 Then
            ComboValidacionCobranza.ValueMember = "clie_colaboradorid_vendedor"
        ElseIf clienteID = 0 Then
            ComboValidacionCobranza.ValueMember = "labo_colaboradorlaboralid"
        End If

    End Function

    Public Shared Function ComboTipoIVA(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoIVA = New ComboBox
        ComboTipoIVA = comboEntrada

        Dim objClientesBU As New Negocios.TipoIvaBU
        Dim tabla As New DataTable

        tabla = objClientesBU.listaTipoIVA()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoIVA.DataSource = tabla
        ComboTipoIVA.DisplayMember = "tiva_nombre"
        ComboTipoIVA.ValueMember = "tiva_tipoivaid"

    End Function

    Public Shared Function ComboTipoMoneda(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoMoneda = New ComboBox
        ComboTipoMoneda = comboEntrada

        Dim objClientesBU As New Negocios.MonedaBU
        Dim tabla As New DataTable

        tabla = objClientesBU.listaMoneda()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoMoneda.DataSource = tabla
        ComboTipoMoneda.DisplayMember = "mone_nombre"
        ComboTipoMoneda.ValueMember = "mone_monedaid"

    End Function

    Public Shared Function ComboRutas(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboRutas = New ComboBox
        ComboRutas = comboEntrada

        Dim rutaBU As New Ventas.Negocios.RutaBU
        Dim tabla As New DataTable

        tabla = rutaBU.ListadoRutas()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboRutas.DataSource = tabla
        ComboRutas.DisplayMember = "ruta_nombre"
        ComboRutas.ValueMember = "ruta_rutaid"

    End Function

    Public Shared Function ComboRamos(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboRamos = New ComboBox
        ComboRamos = comboEntrada

        Dim ramosBU As New Ventas.Negocios.RamoBU
        Dim tabla As New DataTable

        tabla = ramosBU.ListadoRamos()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboRamos.DataSource = tabla
        ComboRamos.DisplayMember = "ramo_nombre"
        ComboRamos.ValueMember = "ramo_ramoid"

    End Function

    Public Shared Function ComboTipoTiendas(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoTiendas = New ComboBox
        ComboTipoTiendas = comboEntrada

        Dim tipoTiendaBU As New Ventas.Negocios.TipoTiendaBU
        Dim tabla As New DataTable

        tabla = tipoTiendaBU.ListadoTipoTienda()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoTiendas.DataSource = tabla
        ComboTipoTiendas.DisplayMember = "titi_nombre"
        ComboTipoTiendas.ValueMember = "titi_tipotiendaid"

    End Function

    Public Shared Function ComboClienteRFCSegunCliente(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID As Integer) As System.Windows.Forms.ComboBox

        ComboClienteRFCSegunCliente = New ComboBox
        ComboClienteRFCSegunCliente = comboEntrada

        Dim ClientesDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = ClientesDatosBU.ListadoClienteRFCPersona(clienteID)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboClienteRFCSegunCliente.DataSource = tabla
        ComboClienteRFCSegunCliente.DisplayMember = "pers_razonsocial"
        ComboClienteRFCSegunCliente.ValueMember = "crfc_clienterfcid"

    End Function

    Public Shared Function ComboTECClienteRFC(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteRFCID As Integer) As System.Windows.Forms.ComboBox

        ComboTECClienteRFC = New ComboBox
        ComboTECClienteRFC = comboEntrada

        Dim ClientesDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = ClientesDatosBU.ListadoTECClienteRFC(clienteRFCID)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTECClienteRFC.DataSource = tabla
        ComboTECClienteRFC.DisplayMember = "pers_nombre"
        ComboTECClienteRFC.ValueMember = "pers_personaid"

    End Function

    Public Shared Function ComboClienteRFCSegunClienteFactura(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID As Integer) As System.Windows.Forms.ComboBox

        ComboClienteRFCSegunClienteFactura = New ComboBox
        ComboClienteRFCSegunClienteFactura = comboEntrada

        Dim ClientesDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = ClientesDatosBU.ListadoClienteRFCPersonaFactura(clienteID)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboClienteRFCSegunClienteFactura.DataSource = tabla
        ComboClienteRFCSegunClienteFactura.DisplayMember = "pers_nombre"
        ComboClienteRFCSegunClienteFactura.ValueMember = "crfc_clienterfcid"

    End Function

    Public Shared Function ComboTipoFlete(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoFlete = New ComboBox
        ComboTipoFlete = comboEntrada

        Dim TipoFleteBU As New Ventas.Negocios.TipoFleteBU
        Dim tabla As New DataTable

        tabla = TipoFleteBU.ListadoTipoFlete()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoFlete.DataSource = tabla
        ComboTipoFlete.DisplayMember = "tifl_nombre"
        ComboTipoFlete.ValueMember = "tifl_tipofleteid"

    End Function

    Public Shared Function ComboTipoValor(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoValor = New ComboBox
        ComboTipoValor = comboEntrada

        Dim TipoValorBU As New Ventas.Negocios.TipoValorBU
        Dim tabla As New DataTable

        tabla = TipoValorBU.ListadoTipoValor()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoValor.DataSource = tabla
        ComboTipoValor.DisplayMember = "tiva_nombre"
        ComboTipoValor.ValueMember = "tiva_tipovalorid"

    End Function

    Public Shared Function ComboTipoEmpaque(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoEmpaque = New ComboBox
        ComboTipoEmpaque = comboEntrada

        Dim TipoEmpaqueBU As New Ventas.Negocios.TipoEmpaqueBU
        Dim tabla As New DataTable

        tabla = TipoEmpaqueBU.ListadoTipoEmpaque()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoEmpaque.DataSource = tabla
        ComboTipoEmpaque.DisplayMember = "tiem_nombre"
        ComboTipoEmpaque.ValueMember = "tiem_tipoempaqueid"

    End Function

    Public Shared Function ComboTamanoEmpaque(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTamanoEmpaque = New ComboBox
        ComboTamanoEmpaque = comboEntrada

        Dim TamanoEmpaqueBU As New Ventas.Negocios.TamanoEmpaqueBU
        Dim tabla As New DataTable

        tabla = TamanoEmpaqueBU.ListadoTamanoEmpaque()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTamanoEmpaque.DataSource = tabla
        ComboTamanoEmpaque.DisplayMember = "taem_nombre"
        ComboTamanoEmpaque.ValueMember = "taem_tamanoempaqueid"

    End Function

    Public Shared Function ComboAlmacen(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboAlmacen = New ComboBox
        ComboAlmacen = comboEntrada

        Dim AlmacenBU As New Ventas.Negocios.AlmacenBU
        Dim tabla As New DataTable

        tabla = AlmacenBU.ListadoAlmacen()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboAlmacen.DataSource = tabla
        ComboAlmacen.DisplayMember = "alma_nombre"
        ComboAlmacen.ValueMember = "alma_almacenid"

    End Function

    Public Shared Function ComboTipoFleje(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoFleje = New ComboBox
        ComboTipoFleje = comboEntrada

        Dim TipoFlejeBU As New Ventas.Negocios.TipoFlejeBU
        Dim tabla As New DataTable

        tabla = TipoFlejeBU.ListadoTipoFleje()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoFleje.DataSource = tabla
        ComboTipoFleje.DisplayMember = "tifl_nombre"
        ComboTipoFleje.ValueMember = "tifl_tipoflejeid"

    End Function

    Public Shared Function ComboProtectorFleje(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboProtectorFleje = New ComboBox
        ComboProtectorFleje = comboEntrada

        Dim ProtectorFlejeBU As New Ventas.Negocios.ProtectorFlejeBU
        Dim tabla As New DataTable

        tabla = ProtectorFlejeBU.ListadoProtectorFleje()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboProtectorFleje.DataSource = tabla
        ComboProtectorFleje.DisplayMember = "prfl_nombre"
        ComboProtectorFleje.ValueMember = "prfl_protectorflejeid"

    End Function

    Public Shared Function ComboUnidadVenta(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboUnidadVenta = New ComboBox
        ComboUnidadVenta = comboEntrada

        Dim UnidadVentaBU As New Ventas.Negocios.UnidadVentaBU
        Dim tabla As New DataTable

        tabla = UnidadVentaBU.ListadoUnidadVenta()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboUnidadVenta.DataSource = tabla
        ComboUnidadVenta.DisplayMember = "unve_nombre"
        ComboUnidadVenta.ValueMember = "unve_unidadventaid"

    End Function

    Public Shared Function ComboLugarEntrega(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboLugarEntrega = New ComboBox
        ComboLugarEntrega = comboEntrada

        Dim LugarEntregaBU As New Ventas.Negocios.LugarEntregaBU
        Dim tabla As New DataTable

        tabla = LugarEntregaBU.ListadoLugarEntrega()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboLugarEntrega.DataSource = tabla
        ComboLugarEntrega.DisplayMember = "luen_nombre"
        ComboLugarEntrega.ValueMember = "luen_lugarentregaid"

    End Function

    Public Shared Function ComboRestriccionesFacturacion(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboRestriccionesFacturacion = New ComboBox
        ComboRestriccionesFacturacion = comboEntrada

        Dim RestriccionesBU As New Ventas.Negocios.RestriccionesBU
        Dim tabla As New DataTable

        tabla = RestriccionesBU.ListadoRestriccionesFacturacion()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboRestriccionesFacturacion.DataSource = tabla
        ComboRestriccionesFacturacion.DisplayMember = "rest_nombre"
        ComboRestriccionesFacturacion.ValueMember = "rest_restriccionid"

    End Function

    Public Shared Function ComboTipoEtiqueta(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTipoEtiqueta = New ComboBox
        ComboTipoEtiqueta = comboEntrada

        Dim etiquetabu As New Ventas.Negocios.EtiquetaBU
        Dim tabla As New DataTable

        tabla = etiquetabu.ListadoTipoEtiqueta()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboTipoEtiqueta.DataSource = tabla
        ComboTipoEtiqueta.DisplayMember = "tiet_nombre"
        ComboTipoEtiqueta.ValueMember = "tiet_tipoetiquetaespecialid"

    End Function

    Public Shared Function ComboNivelSocioEconomico(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboNivelSocioEconomico = New ComboBox
        ComboNivelSocioEconomico = comboEntrada

        Dim NivelSocioEconomico As New Ventas.Negocios.NivelSocioEconomicoBU
        Dim tabla As New DataTable

        tabla = NivelSocioEconomico.ListadoNivelSocioEconomico()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboNivelSocioEconomico.DataSource = tabla
        ComboNivelSocioEconomico.DisplayMember = "niso_nombre"
        ComboNivelSocioEconomico.ValueMember = "niso_nivelsocioeconomicoid"

    End Function

    Public Shared Function ComboPaisesMayusculas(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPaisesMayusculas = New ComboBox
        ComboPaisesMayusculas = comboEntrada

        Dim listaPaises As New List(Of Entidades.Paises)
        Dim objBU As New Negocios.PaisesBU
        listaPaises = objBU.ListaPaisesMayusculas()

        listaPaises.Insert(0, New Entidades.Paises)
        If listaPaises.Count > 0 Then
            ComboPaisesMayusculas.DisplayMember = "PNombre"
            ComboPaisesMayusculas.ValueMember = "PIDPais"
            ComboPaisesMayusculas.DataSource = listaPaises
        End If

        ComboPaisesMayusculas.SelectedValue = 1

    End Function

    Public Shared Function ComboIncoterms(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboIncoterms = New ComboBox
        ComboIncoterms = comboEntrada

        Dim Incoterms As New Ventas.Negocios.IncotermsBU
        Dim tabla As New DataTable

        tabla = Incoterms.ListadoIncoterms()
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        ComboIncoterms.DataSource = tabla
        ComboIncoterms.DisplayMember = "inco_nombre"
        ComboIncoterms.ValueMember = "inco_incotermsid"

    End Function

    Public Shared Function Combo_RFC_Sicy(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID As Integer, rfc_sicyID As Integer, editando As Boolean) As System.Windows.Forms.ComboBox
        Combo_RFC_Sicy = New ComboBox
        Combo_RFC_Sicy = comboEntrada

        Dim ClientesDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = ClientesDatosBU.ListaRFC_Sicy(clienteID, rfc_sicyID, editando)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        Combo_RFC_Sicy.DataSource = tabla
        Combo_RFC_Sicy.DisplayMember = "nombre"
        Combo_RFC_Sicy.ValueMember = "IdCliente"

    End Function

    Public Shared Function Combo_ListaTEC_Sicy(ByVal comboEntrada As System.Windows.Forms.ComboBox, clienteID As Integer, distribucion_sicyID As Integer, editando As Boolean) As System.Windows.Forms.ComboBox
        Combo_ListaTEC_Sicy = New ComboBox
        Combo_ListaTEC_Sicy = comboEntrada

        Dim ClientesDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = ClientesDatosBU.ListaTEC_Sicy(clienteID, distribucion_sicyID, editando)
        tabla.Rows.InsertAt(tabla.NewRow, 0)

        Combo_ListaTEC_Sicy.DataSource = tabla
        Combo_ListaTEC_Sicy.DisplayMember = "distribucion"
        Combo_ListaTEC_Sicy.ValueMember = "IdDistribucion"

    End Function

    Public Shared Function ComboClasePersona(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboClasePersona = New ComboBox
        ComboClasePersona = comboEntrada
        Dim OBJBU As New Framework.Negocios.PersonasBU
        Dim tabla As New DataTable
        tabla = OBJBU.ClasePersona()
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboClasePersona.DataSource = tabla
        ComboClasePersona.DisplayMember = "cper_nombre"
        ComboClasePersona.ValueMember = "cper_clasepersonaid"
    End Function

    Public Shared Function ComboClasePersonaCMB(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboClasePersonaCMB = New ComboBox
        ComboClasePersonaCMB = comboEntrada
        Dim OBJBU As New Framework.Negocios.PersonasBU
        Dim tabla As New DataTable
        tabla = OBJBU.ClasePersonaCMB()
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboClasePersonaCMB.DataSource = tabla
        ComboClasePersonaCMB.DisplayMember = "cper_nombre"
        ComboClasePersonaCMB.ValueMember = "cper_clasepersonaid"
    End Function

    Public Shared Function ComboClasificacionPersona(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal idClasePersona As Int32) As System.Windows.Forms.ComboBox
        ComboClasificacionPersona = New ComboBox
        ComboClasificacionPersona = comboEntrada
        Dim OBJBU As New Framework.Negocios.PersonasBU
        Dim tabla As New DataTable
        tabla = OBJBU.ClasificacionPersona(idClasePersona)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboClasificacionPersona.DataSource = tabla
        ComboClasificacionPersona.DisplayMember = "clpe_nombre"
        ComboClasificacionPersona.ValueMember = "clpe_clasificacionpersonaid"
    End Function

    Public Shared Function ComboTipoTelefonos(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoTelefonos = New ComboBox
        ComboTipoTelefonos = comboEntrada
        Dim OBJBU As New Framework.Negocios.ContactosBU
        Dim tabla As New DataTable
        tabla = OBJBU.TablaTipoTelefonos
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboTipoTelefonos.DataSource = tabla
        ComboTipoTelefonos.DisplayMember = "tite_nombre"
        ComboTipoTelefonos.ValueMember = "tite_tipotelefonoid"
    End Function



    Public Shared Function CargaFotoColaboradorFTP(ByVal pictureBox As System.Windows.Forms.PictureBox, ByVal EntidadArchivos As Entidades.ColaboradorExpediente) As System.Windows.Forms.PictureBox
        Try

            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            Dim Carpeta As String = ""

            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next


            Dim Stream As System.IO.Stream
            Stream = objFTP.StreamFile(Carpeta, EntidadArchivos.PNombreArchivo)
            pictureBox.Image = Image.FromStream(Stream)

        Catch ex As Exception

        End Try
        Return pictureBox
    End Function

    Public Shared Function CargaFotoColaboradorHTTP(ByVal pictureBox As System.Windows.Forms.PictureBox, ByVal EntidadArchivos As Entidades.ColaboradorExpediente) As System.Windows.Forms.PictureBox
        Dim Carpeta As String = ""
        Dim tabla() As String
        tabla = Split(EntidadArchivos.PCarpeta, "\")

        For n = 0 To UBound(tabla, 1)
            Carpeta += tabla(n) + "/"
        Next

        Dim url As String = "http://192.168.2.158/nomina/" + Carpeta + EntidadArchivos.PNombreArchivo
        pictureBox.Image = New System.Drawing.Bitmap(New IO.MemoryStream(New System.Net.WebClient().DownloadData(url)))

        Return pictureBox

    End Function

    Public Shared Function CargarFotoColaboradorLocal(ByVal pictureBox As System.Windows.Forms.PictureBox, ByVal EntidadArchivos As Entidades.ColaboradorExpediente) As System.Windows.Forms.PictureBox
        Dim Carpeta As String = ""
        Try
            Dim tabla() As String
            tabla = Split(EntidadArchivos.PCarpeta, "\")

            For n = 0 To UBound(tabla, 1)
                Carpeta += tabla(n) + "/"
            Next

            Dim url As String = "C:/yuyinerp/" + Carpeta + EntidadArchivos.PNombreArchivo
            Dim image1 As Bitmap
            image1 = New Bitmap(url)


            ' Set the PictureBox to display the image.
            pictureBox.Image = image1
        Catch ex As Exception
            pictureBox.Image = My.Resources.YUMPER
        End Try
        Return pictureBox
    End Function

    Public Shared Function CargarFotoProveedorLocal(ByVal pictureBox As System.Windows.Forms.PictureBox, ByVal ruta As String) As System.Windows.Forms.PictureBox
        Dim Carpeta As String
        Try
            'Dim tabla() As String
            'tabla = Split(ruta, "\")

            'For n = 0 To UBound(tabla, 1)
            '    Carpeta += tabla(n) + "/"
            'Next

            Carpeta = ruta.Remove(0, 2).ToString

            Dim url As String = "C:\" + Carpeta
            Dim image1 As Bitmap
            image1 = New Bitmap(url)

            'Dim x, y As Integer

            ' Set the PictureBox to display the image.
            pictureBox.Image = image1
        Catch ex As Exception
            pictureBox.Image = My.Resources.YUMPER
        End Try
        Return pictureBox
    End Function


    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO COMBOBOX CON LA LISTA DE LOS TIPOS DE VALIDACION EXISTENTES
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL COMBOBOX</param>
    ''' <returns>CONTROL CON LA LISTA DE LOS TIPOS DE VALIDACION EXISTENTE</returns>
    ''' <remarks></remarks>
    Public Function ComboTipoValidacion(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboTipoValidacion = New ComboBox
        ComboTipoValidacion = ComboEntrada
        Dim TablaTipo As New List(Of Entidades.ListaTipoValidaciones)
        Dim objTipoBU As New Negocios.CatalogoConfiguracionDeValidacionesBU
        TablaTipo = objTipoBU.ListaTipo()

        TablaTipo.Insert(0, New Entidades.ListaTipoValidaciones)
        If TablaTipo.Count > 0 Then
            ComboTipoValidacion.DataSource = TablaTipo
            ComboTipoValidacion.DisplayMember = "PNombre"
            ComboTipoValidacion.ValueMember = "PId"
        End If

    End Function


    ''' <summary>
    ''' OBTIENE EL LOGO DE LA NAVE
    ''' </summary>
    ''' <param name="naveid">ID DE LA NAVE</param>
    ''' <returns>LOGO DE LA NAVE</returns>
    ''' <remarks></remarks>
    Public Shared Function ObtenerLogoNave(ByVal naveid As Int32) As String
        Dim objbu As New Framework.Negocios.NavesBU
        Dim urllogonave As String = String.Empty
        urllogonave = objbu.ObtenerLogoNave(naveid)
        Return urllogonave
    End Function
    Public Shared Function ObtenerLogoNaveSICY(ByVal naveid As Int32) As String
        Dim objbu As New Framework.Negocios.NavesBU
        Dim urllogonave As String = String.Empty
        urllogonave = objbu.ObtenerLogoNaveSICY(naveid)
        Return urllogonave
    End Function



    ''' <summary>
    ''' REGRESA LA LISTA DE TODOS LOS PERIODOS EXISTENTES EN UN CONTROL DEL TIPO COMBOBOX
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL COMBOBOX </param>
    ''' <returns>LISTA DE LOS PERIODOS DE NOMINA EXISTENTES</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboPeriodosNominaSinFiltro(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPeriodosNominaSinFiltro = New ComboBox
        ComboPeriodosNominaSinFiltro = ComboEntrada
        Dim LsPeriodos As New List(Of Entidades.PeriodosNomina)
        Dim objPeriodosBU As New Nomina.Negocios.NominaDestajosBU
        LsPeriodos = objPeriodosBU.ListaPeriodos()
        LsPeriodos.Insert(0, New Entidades.PeriodosNomina)
        If LsPeriodos.Count > 0 Then
            ComboPeriodosNominaSinFiltro.DataSource = LsPeriodos
            ComboPeriodosNominaSinFiltro.DisplayMember = "PConcepto"
            ComboPeriodosNominaSinFiltro.ValueMember = "PPeriodoId"
        End If
    End Function

    Public Shared Function ComboPeriodosNominaSinFiltroDescendentePeriodoActivo(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdNAve As Integer) As System.Windows.Forms.ComboBox
        ComboPeriodosNominaSinFiltroDescendentePeriodoActivo = New ComboBox
        ComboPeriodosNominaSinFiltroDescendentePeriodoActivo = ComboEntrada
        Dim LsPeriodos As New List(Of Entidades.PeriodosNomina)
        Dim objPeriodosBU As New Nomina.Negocios.NominaDestajosBU
        LsPeriodos = objPeriodosBU.ListaPeriodosDesendentePeriodoActual(IdNAve)
        LsPeriodos.Insert(0, New Entidades.PeriodosNomina)
        If LsPeriodos.Count > 0 Then
            ComboPeriodosNominaSinFiltroDescendentePeriodoActivo.DataSource = LsPeriodos
            ComboPeriodosNominaSinFiltroDescendentePeriodoActivo.DisplayMember = "PConcepto"
            ComboPeriodosNominaSinFiltroDescendentePeriodoActivo.ValueMember = "PPeriodoId"
        End If
    End Function


    Public Shared Function ComboPeriodoActivoPorNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdNave As Integer) As System.Windows.Forms.ComboBox
        ComboPeriodoActivoPorNave = New ComboBox
        ComboPeriodoActivoPorNave = ComboEntrada
        Dim LsPeriodos As New List(Of Entidades.PeriodosNomina)
        Dim objPeriodosBU As New Nomina.Negocios.NominaDestajosBU
        LsPeriodos = objPeriodosBU.ListaPeriodoActivoPorNave(IdNave)
        LsPeriodos.Insert(0, New Entidades.PeriodosNomina)
        If LsPeriodos.Count > 0 Then
            ComboPeriodoActivoPorNave.DataSource = LsPeriodos
            ComboPeriodoActivoPorNave.DisplayMember = "PConcepto"
            ComboPeriodoActivoPorNave.ValueMember = "PPeriodoId"
        End If
    End Function

    Public Shared Function ComboCelulasPorNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdNave As Integer, ByVal modificar As Boolean) As System.Windows.Forms.ComboBox
        ComboCelulasPorNave = New ComboBox
        ComboCelulasPorNave = ComboEntrada
        Dim dlCelulas As New List(Of Entidades.Celulas)
        Dim objCelulasBU As New Nomina.Negocios.NominaDestajosBU
        dlCelulas = objCelulasBU.ListaCelulasporNave(IdNave, modificar)
        dlCelulas.Insert(0, New Entidades.Celulas)
        If dlCelulas.Count > 0 Then
            ComboCelulasPorNave.DataSource = dlCelulas
            ComboCelulasPorNave.DisplayMember = "PNombre"
            ComboCelulasPorNave.ValueMember = "PCelulaid"

        End If
    End Function


    Public Shared Function ComboCelulasMasDepartamentoPorNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdNave As Integer, ByVal modificar As Boolean) As System.Windows.Forms.ComboBox
        ComboCelulasMasDepartamentoPorNave = New ComboBox
        ComboCelulasMasDepartamentoPorNave = ComboEntrada
        Dim dlCelulas As New List(Of Entidades.Celulas)
        Dim objCelulasBU As New Nomina.Negocios.NominaDestajosBU
        dlCelulas = objCelulasBU.ListaCelulasMasDepartamentoPorNave(IdNave, modificar)
        dlCelulas.Insert(0, New Entidades.Celulas)
        If dlCelulas.Count > 0 Then
            ComboCelulasMasDepartamentoPorNave.DataSource = dlCelulas
            ComboCelulasMasDepartamentoPorNave.DisplayMember = "PNombreD"
            ComboCelulasMasDepartamentoPorNave.ValueMember = "PCelulaid"
        End If
    End Function



    ''' <summary>
    ''' FUNCION QUE LLENA UN CONTROL DEL TIPO ULTRACOMBOBOX CON LA LISTA DE LOS OPERADORES DE ALMACEN
    ''' </summary>
    ''' <param name="comboEntrada"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UltraComboOperadoresAlmacen(ByVal comboEntrada As UltraWinEditors.UltraComboEditor) As UltraWinEditors.UltraComboEditor
        UltraComboOperadoresAlmacen = New UltraWinEditors.UltraComboEditor
        UltraComboOperadoresAlmacen = comboEntrada

        Dim objOperadoresPCiclicoBU As New Almacen.Negocios.InventarioCiclicoBU
        Dim tabla As New DataTable

        tabla = objOperadoresPCiclicoBU.ListaOperadoresAlmacenSicy()

        UltraComboOperadoresAlmacen.DataSource = tabla
        UltraComboOperadoresAlmacen.ValueMember = "Parámetro"
        UltraComboOperadoresAlmacen.DisplayMember = "Operador"
    End Function

    ''' <summary>
    ''' AGREGA LOS DIFERENTES TIPOS DE ESTADOS PARA UN INVENTARIO CICLICO EN UN CONTROL DEL TIPO ULTRACONBOBOX
    ''' </summary>
    ''' <param name="comboEntrada">CONTROL DEL TIPO ULTRACOMBO</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UltraComboEstadosInventarioCiclico(ByVal comboEntrada As UltraWinEditors.UltraComboEditor) As UltraWinEditors.UltraComboEditor
        UltraComboEstadosInventarioCiclico = New UltraWinEditors.UltraComboEditor
        UltraComboEstadosInventarioCiclico = comboEntrada

        Dim objOperadoresPCiclicoBU As New Almacen.Negocios.InventarioCiclicoBU
        Dim tabla As New DataTable

        tabla = objOperadoresPCiclicoBU.ListaEstadosInventariosCiclicos()
        'tabla.Rows.InsertAt(tabla.NewRow, 0)
        UltraComboEstadosInventarioCiclico.DataSource = tabla
        UltraComboEstadosInventarioCiclico.ValueMember = "Identificador"
        UltraComboEstadosInventarioCiclico.DisplayMember = "Estado"
    End Function

    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO COMBOBOX CON LA LISTA DE OPERADORES POR NAVE EN LA BASE DE DATOS DEL SICY
    ''' </summary>
    ''' <param name="ComboEntrada"></param>
    ''' <returns>COMBO CON LA LISTA</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboOperadoresSegunNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdNave As Integer) As System.Windows.Forms.ComboBox
        ComboOperadoresSegunNave = New ComboBox
        ComboOperadoresSegunNave = ComboEntrada
        Dim tabla As New DataTable
        Dim objSalidaNavesBU As New Almacen.Negocios.SalidaNavesBU
        tabla = objSalidaNavesBU.ComboOperadoresSegunNave(IdNave)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboOperadoresSegunNave.DataSource = tabla
        ComboOperadoresSegunNave.DisplayMember = "Nombre"
        ComboOperadoresSegunNave.ValueMember = "idOperador"
        Return ComboOperadoresSegunNave
    End Function

    ''' <summary>
    ''' RECUPERA EL NOMBRE DE UNA NAVE DEACUERDO CON SU ID
    ''' </summary>
    ''' <param name="IdNave">ID DE LA NAVE A RECUPERAR EL NOMBRE</param>
    ''' <returns>NOMBRE DE LA NAVE</returns>
    ''' <remarks></remarks>
    Public Shared Function RecuperarNombreNave(ByVal IdNave As Integer)
        Dim objSalidaNavesBU As New Almacen.Negocios.SalidaNavesBU
        Dim NombreNave As String

        NombreNave = objSalidaNavesBU.RecuperarNombreNave(IdNave)

        Return NombreNave
    End Function


    Public Shared Function ComboNaves_IdSicy(ByVal comboentrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboNaves_IdSicy = New ComboBox
        ComboNaves_IdSicy = comboentrada
        Dim dtListaNaves As New DataTable
        Dim objBU As New Framework.Negocios.NavesBU
        dtListaNaves = objBU.listaNavesActivas
        dtListaNaves.Rows.InsertAt(dtListaNaves.NewRow, 0)
        ComboNaves_IdSicy.DataSource = dtListaNaves
        ComboNaves_IdSicy.DisplayMember = "nave_nombre"
        ComboNaves_IdSicy.ValueMember = "nave_navesicyid"

    End Function

    ''' <summary>
    ''' FUNCION QUE LLENA UN CONTROL DEL TIPO ULTRACOMBOBOX CON LA LISTA DE NAVES EXISTENTES CON ID DE SICY
    ''' </summary>
    ''' <param name="comboEntrada"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UltraComboNaves_IdSicy(ByVal comboEntrada As UltraWinEditors.UltraComboEditor) As UltraWinEditors.UltraComboEditor
        UltraComboNaves_IdSicy = New UltraWinEditors.UltraComboEditor
        UltraComboNaves_IdSicy = comboEntrada

        Dim ListaNavesSegunUsuarioConIdSicy = New List(Of Entidades.Naves)
        Dim objBU As New Framework.Negocios.NavesBU

        Dim dtNaves As New DataTable
        Dim ColumnaId As New DataColumn("IdNaveSicy")
        ColumnaId.DataType = GetType(Integer)
        Dim ColumnaNave As New DataColumn("Nave")
        ColumnaNave.DataType = GetType(String)
        dtNaves.Columns.Add(ColumnaId)
        dtNaves.Columns.Add(ColumnaNave)

        ListaNavesSegunUsuarioConIdSicy = objBU.ListaNavesSegunUsuarioConIdSicy(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        For Each item In ListaNavesSegunUsuarioConIdSicy
            Dim newRow As DataRow = dtNaves.NewRow()
            newRow("IdNaveSicy") = item.PNaveSICYid
            newRow("Nave") = item.PNombre

            dtNaves.Rows.Add(newRow)
        Next

        UltraComboNaves_IdSicy.DataSource = dtNaves
        UltraComboNaves_IdSicy.DisplayMember = "Nave"
        UltraComboNaves_IdSicy.ValueMember = "IdNaveSicy"
    End Function


    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO ULTRACOMBO
    ''' </summary>
    ''' <param name="comboEntrada"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function UltraComboRamosConMarcajeRegistradoPorCliente(ByVal comboEntrada As UltraWinEditors.UltraComboEditor, ByVal IdCliente As Integer) As UltraWinEditors.UltraComboEditor
        UltraComboRamosConMarcajeRegistradoPorCliente = New UltraWinEditors.UltraComboEditor
        UltraComboRamosConMarcajeRegistradoPorCliente = comboEntrada

        Dim objRamosConMarcajeClienteBU As New Ventas.Negocios.RamoBU
        Dim tabla As New DataTable

        tabla = objRamosConMarcajeClienteBU.ListaRamosPorCliente_con_Marcaje(IdCliente)

        UltraComboRamosConMarcajeRegistradoPorCliente.DataSource = tabla
        UltraComboRamosConMarcajeRegistradoPorCliente.ValueMember = "Id_Ramo"
        UltraComboRamosConMarcajeRegistradoPorCliente.DisplayMember = "Ramo"
    End Function

    Public Shared Function ComboRamosConMarcajeRegistradoPorCliente(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdCliente As Integer) As System.Windows.Forms.ComboBox
        ComboRamosConMarcajeRegistradoPorCliente = New ComboBox
        ComboRamosConMarcajeRegistradoPorCliente = ComboEntrada
        Dim objRamosConMarcajeClienteBU As New Ventas.Negocios.RamoBU
        Dim tabla As New DataTable

        tabla = objRamosConMarcajeClienteBU.ListaRamosPorCliente_con_Marcaje(IdCliente)

        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboRamosConMarcajeRegistradoPorCliente.DataSource = tabla
        ComboRamosConMarcajeRegistradoPorCliente.ValueMember = "Id_Ramo"
        ComboRamosConMarcajeRegistradoPorCliente.DisplayMember = "Ramo"
        Return ComboRamosConMarcajeRegistradoPorCliente
    End Function

    ''' <summary>
    ''' LLENA UN CONTROL DEL TIPO ULTRACOMBO CON LA MONEDA EXTRANJERA DE UN CLIENTE EN ESPECIFICO Y LA MONEDA PESOS, ESTO EN CASO DE QUE EL CLIENTE TENGA ASIGNADA
    ''' UNA MONEDA EXTRANJERA, DE LO CONTRARIO SOLO TRAERA LA MONEDA DE PESOS MXN
    ''' </summary>
    ''' <param name="comboEntrada">CONTROL DEL TIPO ULTRACOMBOEDITOR</param>
    ''' <returns>ULTRACOMBO CON LA INFORMACION RECUPERADA EN SU DATASOURCE</returns>
    ''' <remarks></remarks>
    Public Shared Function UltraComboMonedaextranjeraMasMonedaPesos(ByVal comboEntrada As UltraWinEditors.UltraComboEditor, ByVal IdMoneda As Integer) As UltraWinEditors.UltraComboEditor
        UltraComboMonedaextranjeraMasMonedaPesos = New UltraWinEditors.UltraComboEditor
        UltraComboMonedaextranjeraMasMonedaPesos = comboEntrada

        Dim objMonedaClienteBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = objMonedaClienteBU.RecuperarMonedaDelClienteMasMonedaPeso(IdMoneda)

        UltraComboMonedaextranjeraMasMonedaPesos.DataSource = tabla
        UltraComboMonedaextranjeraMasMonedaPesos.ValueMember = "mone_monedaid"
        UltraComboMonedaextranjeraMasMonedaPesos.DisplayMember = "mone_nombre"
    End Function


    Public Shared Function ComboMonedaextranjeraMasMonedaPesos(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IdMoneda As Integer) As System.Windows.Forms.ComboBox
        ComboMonedaextranjeraMasMonedaPesos = New ComboBox
        ComboMonedaextranjeraMasMonedaPesos = ComboEntrada
        Dim objMonedaClienteBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = objMonedaClienteBU.RecuperarMonedaDelClienteMasMonedaPeso(IdMoneda)
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboMonedaextranjeraMasMonedaPesos.DataSource = tabla
        ComboMonedaextranjeraMasMonedaPesos.DisplayMember = "mone_nombre"
        ComboMonedaextranjeraMasMonedaPesos.ValueMember = "mone_monedaid"
        Return ComboMonedaextranjeraMasMonedaPesos
    End Function

    Public Shared Function ComboNumeracionPais(ByVal ComboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboNumeracionPais = New ComboBox
        ComboNumeracionPais = ComboEntrada
        Dim objMonedaClienteBU As New Ventas.Negocios.ClientesDatosBU
        Dim tabla As New DataTable

        tabla = objMonedaClienteBU.Recuperar_NumeracionPais()
        tabla.Rows.InsertAt(tabla.NewRow, 0)
        ComboNumeracionPais.DataSource = tabla
        ComboNumeracionPais.DisplayMember = "pais_nombre"
        ComboNumeracionPais.ValueMember = "pais_paisid"
        Return ComboNumeracionPais
    End Function

    ''' <summary>
    ''' ASIGNA A UN COMBOBOX EL DATASOURSE CON LA INFORMACION DE TIPO DE CLIENTE(NACIONAL O EXTRANJERO) DE UN CLIENTE EN ESPECIFICO
    ''' </summary>
    ''' <param name="ComboEntrada">COMBOBOX AL CUAL SE LE ASIGNARA LA FUENTE DE DATOS O DATASOURSE</param>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARA EL TIPO DE CLIENTE</param>
    ''' <returns>COMBOBOX CON LA INFORMACION RECUPERADA EN SU DATASOURSE</returns>
    ''' <remarks></remarks>
    Public Shared Function ComboClienteNacional_extranjero(ByVal ComboEntrada As ComboBox, ByVal IdCliente As Integer) As ComboBox
        ComboClienteNacional_extranjero = New ComboBox
        ComboClienteNacional_extranjero = ComboEntrada
        Dim objClienteDatosBU As New Ventas.Negocios.ClientesDatosBU
        Dim dtTABLA As DataTable

        dtTABLA = objClienteDatosBU.ListaClienteNacional_Extranjero(IdCliente)
        ComboClienteNacional_extranjero.DataSource = dtTABLA
        ComboClienteNacional_extranjero.DisplayMember = "ticl_nombre"
        ComboClienteNacional_extranjero.ValueMember = "clie_tipoclienteid"

        Return ComboClienteNacional_extranjero
    End Function



    Public Shared Function Combo_FraccionesArancelariasActivas_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_FraccionesArancelariasActivas_SAY = New ComboBox
        Combo_FraccionesArancelariasActivas_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_FraccionesArancelariasActivas_SAY()
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_FraccionesArancelariasActivas_SAY.DataSource = dtTABLA
        Combo_FraccionesArancelariasActivas_SAY.DisplayMember = "Fraccion"
        Combo_FraccionesArancelariasActivas_SAY.ValueMember = "Id"

        Return Combo_FraccionesArancelariasActivas_SAY
    End Function


    Public Shared Function Combo_Familias_Activas_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_Familias_Activas_SAY = New ComboBox
        Combo_Familias_Activas_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_Familias_Activas_SAY()
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_Familias_Activas_SAY.DataSource = dtTABLA
        Combo_Familias_Activas_SAY.DisplayMember = "Familia"
        Combo_Familias_Activas_SAY.ValueMember = "Id"

        Return Combo_Familias_Activas_SAY
    End Function


    Public Shared Function Combo_PielMuestra_o_Corte_Activa_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_PielMuestra_o_Corte_Activa_SAY = New ComboBox
        Combo_PielMuestra_o_Corte_Activa_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_PielMuestra_o_Corte_Activa_SAY
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_PielMuestra_o_Corte_Activa_SAY.DataSource = dtTABLA
        Combo_PielMuestra_o_Corte_Activa_SAY.DisplayMember = "Corte"
        Combo_PielMuestra_o_Corte_Activa_SAY.ValueMember = "Id"

        Return Combo_PielMuestra_o_Corte_Activa_SAY
    End Function


    Public Shared Function Combo_Forros_Activos_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_Forros_Activos_SAY = New ComboBox
        Combo_Forros_Activos_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_Forros_Activos_SAY
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_Forros_Activos_SAY.DataSource = dtTABLA
        Combo_Forros_Activos_SAY.DisplayMember = "Forro"
        Combo_Forros_Activos_SAY.ValueMember = "Id"

        Return Combo_Forros_Activos_SAY
    End Function


    Public Shared Function Combo_Suelas_Activas_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_Suelas_Activas_SAY = New ComboBox
        Combo_Suelas_Activas_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_Suelas_Activas_SAY
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_Suelas_Activas_SAY.DataSource = dtTABLA
        Combo_Suelas_Activas_SAY.DisplayMember = "Suela"
        Combo_Suelas_Activas_SAY.ValueMember = "Id"

        Return Combo_Suelas_Activas_SAY
    End Function


    Public Shared Function Combo_TipoCategoria_Activos_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_TipoCategoria_Activos_SAY = New ComboBox
        Combo_TipoCategoria_Activos_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_TipoCategoria_Activos_SAY
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_TipoCategoria_Activos_SAY.DataSource = dtTABLA
        Combo_TipoCategoria_Activos_SAY.DisplayMember = "Tipo"
        Combo_TipoCategoria_Activos_SAY.ValueMember = "Id"

        Return Combo_TipoCategoria_Activos_SAY
    End Function


    Public Shared Function Combo_Corridas_Mexicanas_Activas_SAY(ByVal ComboEntrada As ComboBox) As ComboBox
        Combo_Corridas_Mexicanas_Activas_SAY = New ComboBox
        Combo_Corridas_Mexicanas_Activas_SAY = ComboEntrada
        Dim objFraccionesArancelariasBU As New Programacion.Negocios.FraccionesArtancelariasBU
        Dim dtTABLA As DataTable

        dtTABLA = objFraccionesArancelariasBU.Lista_Corridas_Mexicanas_Activas_SAY
        dtTABLA.Rows.InsertAt(dtTABLA.NewRow, 0)
        Combo_Corridas_Mexicanas_Activas_SAY.DataSource = dtTABLA
        Combo_Corridas_Mexicanas_Activas_SAY.DisplayMember = "Corrida"
        Combo_Corridas_Mexicanas_Activas_SAY.ValueMember = "Id"

        Return Combo_Corridas_Mexicanas_Activas_SAY
    End Function


    Public Shared Function Mensajes_Y_Alertas(ByVal Tipo As String, ByVal Mensaje As String)
        If Tipo = "ADVERTENCIA" Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = Mensaje
            objAdvertencia.ShowDialog()
        ElseIf Tipo = "EXITO" Then
            Dim objExito As New Tools.ExitoForm
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.mensaje = Mensaje
            objExito.ShowDialog()
        ElseIf Tipo = "ERROR" Then
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = Mensaje
            objErrores.ShowDialog()
        ElseIf Tipo = "INFORMACION" Then
            Dim objInformacion As New Tools.AvisoForm
            objInformacion.StartPosition = FormStartPosition.CenterScreen
            objInformacion.mensaje = Mensaje
            objInformacion.ShowDialog()
        ElseIf Tipo = "CONFIRMACION" Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = Mensaje
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        ElseIf Tipo = "CONFIRMACION_G" Then
            Dim objConfirmacion As New Tools.confirmarFormGrande
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = Mensaje
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        End If
    End Function


    Public Function EnLetras(numero As String) As String
        Dim b, paso As Integer
        Dim expresion, entero, deci, flag As String
        expresion = ""
        entero = ""
        deci = ""
        flag = ""

        flag = "N"
        For paso = 1 To Len(numero)
            If Mid(numero, paso, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero
                Else
                    deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero
                End If
            End If
        Next paso

        If Len(deci) = 1 Then
            deci = deci & "0"
        End If

        flag = "N"
        If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "cien "
                                Else
                                    expresion = expresion & "ciento "
                                End If
                            Case "2"
                                expresion = expresion & "doscientos "
                            Case "3"
                                expresion = expresion & "trescientos "
                            Case "4"
                                expresion = expresion & "cuatrocientos "
                            Case "5"
                                expresion = expresion & "quinientos "
                            Case "6"
                                expresion = expresion & "seiscientos "
                            Case "7"
                                expresion = expresion & "setecientos "
                            Case "8"
                                expresion = expresion & "ochocientos "
                            Case "9"
                                expresion = expresion & "novecientos "
                        End Select

                    Case 2, 5, 8
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "diez "
                                End If
                                If Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "once "
                                End If
                                If Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "doce "
                                End If
                                If Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "trece "
                                End If
                                If Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "catorce "
                                End If
                                If Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "quince "
                                End If
                                If Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "dieci"
                                End If

                            Case "2"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "veinte "
                                    flag = "S"
                                Else
                                    expresion = expresion & "veinti"
                                    flag = "N"
                                End If

                            Case "3"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "treinta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "treinta y "
                                    flag = "N"
                                End If

                            Case "4"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cuarenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cuarenta y "
                                    flag = "N"
                                End If

                            Case "5"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cincuenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cincuenta y "
                                    flag = "N"
                                End If

                            Case "6"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "sesenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "sesenta y "
                                    flag = "N"
                                End If

                            Case "7"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "setenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "setenta y "
                                    flag = "N"
                                End If

                            Case "8"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "ochenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "ochenta y "
                                    flag = "N"
                                End If

                            Case "9"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "noventa "
                                    flag = "S"
                                Else
                                    expresion = expresion & "noventa y "
                                    flag = "N"
                                End If
                        End Select

                    Case 1, 4, 7
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "uno "
                                    Else
                                        expresion = expresion & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "dos "
                                End If
                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "tres "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "cuatro "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "cinco "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "seis "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "siete "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "ocho "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "nueve "
                                End If
                        End Select
                End Select
                If paso = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                       Len(entero) <= 6) Then
                        expresion = expresion & "mil "
                    End If
                End If
                If paso = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        expresion = expresion & "millón "
                    Else
                        expresion = expresion & "millones "
                    End If
                End If
            Next paso

            If deci <> "" Then
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion & "con " & deci ' & "/100"
                Else
                    EnLetras = expresion & "con " & deci ' & "/100"
                End If
            Else
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion
                Else
                    EnLetras = expresion
                End If
            End If
        Else 'si el numero a convertir esta fuera del rango superior e inferior
            EnLetras = ""
        End If
    End Function


    Public Shared Function Combo_Cargo_Contacto_Sin_Area_Operativa(ByVal Combo As ComboBox, ByVal permisos As Boolean) As ComboBox
        Dim objbu As New Framework.Negocios.ContactosBU
        Dim dtCargo As New DataTable

        If permisos = True Then
            dtCargo = objbu.consultaClasificacionTipoPersona
        Else
            dtCargo = objbu.TablaCargosSinAreaOperativa
        End If
        dtCargo.Rows.InsertAt(dtCargo.NewRow, 0)
        If dtCargo.Rows.Count > 0 Then
            Combo.DataSource = dtCargo
            Combo.DisplayMember = "clpe_nombre"
            Combo.ValueMember = "CLPE_CLASIFICACIONPERSONAID"
        End If

        Return Combo
    End Function


    ''' <summary>
    ''' REGRESA UN CONTROL DEL TIPO COMBOBOX CON LA LISTA DE LOS CLIENTES CON CODIGOS AMECE
    ''' </summary>
    ''' <param name="ComboEntrada"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function comboClientes_CodigosAMECE(ByVal ComboEntrada As ComboBox) As ComboBox
        Dim objBU As New Programacion.Negocios.CodigosAMECEBU
        Dim dtClientes As New DataTable

        dtClientes = objBU.comboClientes_CodigosAMECE()
        dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)


        comboClientes_CodigosAMECE = New ComboBox
        comboClientes_CodigosAMECE = ComboEntrada

        comboClientes_CodigosAMECE.DataSource = dtClientes
        comboClientes_CodigosAMECE.ValueMember = "clie_clienteid"
        comboClientes_CodigosAMECE.DisplayMember = "clie_nombregenerico"
        Return comboClientes_CodigosAMECE
    End Function

    ''' <summary>
    ''' REGRESA UN CONTROL DEL TIPO COMBOBOX CON LA LISTA DE LOS CLIENTES QUE CUENTAN CON CODIGOS DE CLIENTE
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX AL CUAL SE LE ASIGNARA SU DATASOURSE</param>
    ''' <returns>CONTROL DEL </returns>
    ''' <remarks></remarks>
    Public Shared Function comboClientes_CodigosCliente(ByVal ComboEntrada As ComboBox) As ComboBox
        'Dim objBU As New Programacion.Negocios.CodigosClienteBU
        'Dim dtCodigos As New DataTable

        'dtCodigos = objBU.comboClientes_CodigosCLiente()
        'dtCodigos.Rows.InsertAt(dtCodigos.NewRow, 0)

        'comboClientes_CodigosCliente = New ComboBox
        'comboClientes_CodigosCliente = ComboEntrada

        'comboClientes_CodigosCliente.DataSource = dtCodigos
        'comboClientes_CodigosCliente.ValueMember = ""
        'comboClientes_CodigosCliente.DisplayMember = ""
        Return comboClientes_CodigosCliente
    End Function


    ''' <summary>
    ''' REGRESA UN CONTROL DEL TIPO COMBOBOX CON EL DATASOURSE LLENO CON EL ID Y EL NOMBRE DE LAS LISTAS DE PRECIO DE 
    ''' CLIENTE DE UN CLIENTE EN ESPECIFICO  LAS LISTA QUE REGRESA PUEDEN ESTAR EN ESTATUS CAPTURADA Y ESTATUS ACEPTADA
    ''' 
    ''' </summary>
    ''' <param name="ComboEntrada">CONTROL DEL TIPO COMBOBOX AL QUE SE LE ASIGNARA EL DATASOURCE</param>
    ''' <param name="IdCliente">ID DEL CLIENTE DEL CUAL SE RECUPERARAN LAS LISTAS ACEPTADAS Y CAPTURADAS</param>
    ''' <returns>CONTROL DEL TIPO COMOBOBX CON SU DATASOURSE ASIGNADO</returns>
    ''' <remarks></remarks>
    Public Shared Function comboListaPrecioCliente_SegunClienteSAY(ByVal ComboEntrada As ComboBox, ByVal IdCliente As Integer) As ComboBox
        Dim objBU As New Programacion.Negocios.CodigosAMECEBU
        Dim dtListaPRecio As New DataTable

        dtListaPRecio = objBU.comboListaPrecioDeCliente_CodigosAMECE(IdCliente)
        dtListaPRecio.Rows.InsertAt(dtListaPRecio.NewRow, 0)


        comboListaPrecioCliente_SegunClienteSAY = New ComboBox
        comboListaPrecioCliente_SegunClienteSAY = ComboEntrada
        comboListaPrecioCliente_SegunClienteSAY.ValueMember = "lvcp_listaventasclienteprecioid"
        comboListaPrecioCliente_SegunClienteSAY.DisplayMember = "lvcp_descripcion"
        comboListaPrecioCliente_SegunClienteSAY.DataSource = dtListaPRecio

        Return comboListaPrecioCliente_SegunClienteSAY
    End Function

    ' ''' <summary>
    ' ''' RECUPERA LAS RAZONES SOCIALES(CLIENTES)  DE LAS CADENAS SELECCIONADAS POR EL USUARIOS
    ' ''' </summary>
    ' ''' <param name="comboEntrada">CONTROL DEL TIPO ULTRACOMBO EL CUAL SERA DEVUELTO CON EL SU DATASORSE LLENO CON LA LISTA DE LOS CLIENTES RECUPERADA</param>
    ' ''' <param name="IdsCadenasSicy">CADENA("STRING") CON LOS ID´S DE LAS CADENAS("CLIENTES") SELECCIONADOS POR EL USUARIO PARA RECUPERAR SUS RAZÓNES SOCIALES </param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared Function UltraComboClientesDeCadenasSicy(ByVal comboEntrada As UltraWinEditors.UltraComboEditor, ByVal IdsCadenasSicy As String) As UltraWinEditors.UltraComboEditor
    '    UltraComboClientesDeCadenasSicy = New UltraWinEditors.UltraComboEditor
    '    UltraComboClientesDeCadenasSicy = comboEntrada
    '    Dim dtListaCadenasClientes As New DataTable
    '    Dim objBU As New Contabilidad.Negocios.ComprobantesFiscalesBU
    '    dtListaCadenasClientes = objBU.RecuperarClientesDeCadenaSicy(IdsCadenasSicy)
    '    'dtListaCadenasClientes.Rows.InsertAt(dtListaCadenasClientes.NewRow, 0)
    '    UltraComboClientesDeCadenasSicy.DataSource = dtListaCadenasClientes
    '    UltraComboClientesDeCadenasSicy.DisplayMember = "Nombre"
    '    UltraComboClientesDeCadenasSicy.ValueMember = "IdCliente"
    'End Function

    'Public Shared Function UltraComboEditorsCadenasSicy_Segun_Contribuyente(ByVal comboEntrada As UltraWinEditors.UltraComboEditor, ByVal IdContribuyente As Integer) As UltraWinEditors.UltraComboEditor
    '    UltraComboEditorsCadenasSicy_Segun_Contribuyente = New UltraWinEditors.UltraComboEditor
    '    UltraComboEditorsCadenasSicy_Segun_Contribuyente = comboEntrada
    '    Dim dtListaCadenasClientes As New DataTable
    '    Dim objBU As New Contabilidad.Negocios.ComprobantesFiscalesBU
    '    dtListaCadenasClientes = objBU.CadenasSicy_Segun_Contribuyente(IdContribuyente)
    '    ''dtListaCadenasClientes.Rows.InsertAt(dtListaCadenasClientes.NewRow, 0)
    '    UltraComboEditorsCadenasSicy_Segun_Contribuyente.DataSource = dtListaCadenasClientes
    '    UltraComboEditorsCadenasSicy_Segun_Contribuyente.DisplayMember = "Nombre"
    '    UltraComboEditorsCadenasSicy_Segun_Contribuyente.ValueMember = "idCadena"

    'End Function
    Public Shared Function ComboContenidoEmarque(ByVal comboContenido As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboContenidoEmarque = New ComboBox
        ComboContenidoEmarque = comboContenido

        Dim AdministradorDocumentosBU As New Almacen.Negocios.AdministradorDocumentosBU
        Dim tabla As New DataTable

        tabla = AdministradorDocumentosBU.ConsultarTiposContenidoEmbarque()

        ComboContenidoEmarque.DataSource = tabla
        ComboContenidoEmarque.DisplayMember = "Contenido"
        ComboContenidoEmarque.ValueMember = "ID"

    End Function
    Public Shared Function ComboTransporte(ByVal comboContenido As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox

        ComboTransporte = New ComboBox
        ComboTransporte = comboContenido

        Dim AdministradorDocumentosBU As New Almacen.Negocios.AdministradorDocumentosBU
        Dim tabla As New DataTable

        tabla = AdministradorDocumentosBU.ConsultarTransporte()

        ComboTransporte.DataSource = tabla
        ComboTransporte.DisplayMember = "Unidad"
        ComboTransporte.ValueMember = "ID"

    End Function





End Class




#Region "HACE COLUMNAS DE TIPO DATETIMEPICKER CON FORMATO LONGTIMESTRING"
Public Class DateTimePickerColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
            Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
            Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Select format.
        Me.Style.Format = "HH:mm:ss tt"

    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
    ByVal initialFormattedValue As Object, _
    ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
        dataGridViewCellStyle)

        Dim ctl As CalendarEditingControl = _
        CType(DataGridView.EditingControl, CalendarEditingControl)
        Try
            If Me.Value.ToString <> Nothing Then

                ctl.Value = CType(Me.Value, DateTime)
            Else
                ctl.Value = Today
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing contol that CalendarCell uses.
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CalendarCell contains.
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Custom
        Me.CustomFormat = "HH:mm:ss tt"
    End Sub

    Public Property EditingControlFormattedValue() As Object _
     Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortTimeString()
            '.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
     As DataGridViewDataErrorContexts) As Object _
     Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToLongTimeString()
        'ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
     DataGridViewCellStyle) _
     Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
        Me.ShowUpDown = True

    End Sub

    Public Property EditingControlRowIndex() As Integer _
     Implements IDataGridViewEditingControl.EditingControlRowIndex

        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set

    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, _
     ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
     Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
             Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return False
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
       Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
     As Boolean Implements _
     IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
     Implements IDataGridViewEditingControl.EditingControlDataGridView

        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
     Implements IDataGridViewEditingControl.EditingControlValueChanged

        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
     Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)

    End Sub

End Class
#End Region