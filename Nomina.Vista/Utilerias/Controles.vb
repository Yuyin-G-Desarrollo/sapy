Imports Framework
Imports Framework.Negocios

Public Class Controles

    'Public Shared Function

    Public Shared Function ComboMotivoFiniquitos(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IdNave As UInt32) As System.Windows.Forms.ComboBox
        ComboMotivoFiniquitos = New ComboBox
        ComboMotivoFiniquitos = comboEntrada
        Dim listaMotivos As New List(Of Entidades.MotivosFiniquito)
        Dim objBU As New Nomina.Negocios.MotivosFiniquitoBU
        listaMotivos = objBU.MotivosFiniquitoSegunNave(IdNave)
        ' listaMotivos.Insert(0, New Entidades.MotivosFiniquito)
        If listaMotivos.Count > 0 Then
            ComboMotivoFiniquitos.DataSource = listaMotivos
            ComboMotivoFiniquitos.DisplayMember = "PNombre"
            ComboMotivoFiniquitos.ValueMember = "PMotivoFiniquitoId"
        End If

    End Function


    Public Shared Function ComboPaises(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPaises = New ComboBox
        ComboPaises = comboEntrada

        Dim listaPaises As New List(Of Entidades.Paises)
        Dim objBU As New Framework.Negocios.PaisesBU
        listaPaises = objBU.ListaPaises("", True)

        listaPaises.Insert(0, New Entidades.Paises)
        If listaPaises.Count > 0 Then
            ComboPaises.DataSource = listaPaises
            ComboPaises.DisplayMember = "PNombre"
            ComboPaises.ValueMember = "PIDPais"
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


    Public Shared Function ComboNaves(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboNaves = New ComboBox
        ComboNaves = comboEntrada
        Dim tablaNaves As New DataTable
        Dim objNavesBu As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBu.listaNavesActivas
        tablaNaves.Rows.InsertAt(tablaNaves.NewRow, 0)
        ComboNaves.DataSource = tablaNaves
        ComboNaves.DisplayMember = "nave_nombre"
        ComboNaves.ValueMember = "nave_naveid"
        Return ComboNaves
    End Function


    Public Shared Function ComboNavesSegunUsuario(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer) As System.Windows.Forms.ComboBox
        ComboNavesSegunUsuario = New ComboBox
        ComboNavesSegunUsuario = ComboEntrada
        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU
        tablaNaves = objNavesBU.ListaNavesSegunUsuario("", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        tablaNaves.Insert(0, New Entidades.Naves)
        If tablaNaves.Count > 0 Then
            ComboNavesSegunUsuario.DataSource = tablaNaves
            ComboNavesSegunUsuario.DisplayMember = "PNombre"
            ComboNavesSegunUsuario.ValueMember = "PNaveId"
        End If

        If tablaNaves.Count = 2 Then
            ComboNavesSegunUsuario.SelectedIndex = 1
            'ComboNavesSegunUsuario.Enabled = False
        End If

        If tablaNaves.Count > 2 Then
            ComboNavesSegunUsuario.SelectedIndex = 0
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


    Public Shared Function ComboMotivosIncentivoSegunNave(ByVal ComboEntrada As System.Windows.Forms.ComboBox, ByVal IDUsuario As Integer, ByVal idNave As Int32) As System.Windows.Forms.ComboBox
        ComboMotivosIncentivoSegunNave = New ComboBox
        ComboMotivosIncentivoSegunNave = ComboEntrada
        Dim tablaIncentivos As New List(Of Entidades.Incentivos)
        Dim objIncentivoBU As New Nomina.Negocios.IncentivosBU
        tablaIncentivos = objIncentivoBU.ListaIncentivosSUsuario(IDUsuario, idNave)

        tablaIncentivos.Insert(0, New Entidades.Incentivos)
        If tablaIncentivos.Count > 0 Then
            ComboMotivosIncentivoSegunNave.DataSource = tablaIncentivos
            ComboMotivosIncentivoSegunNave.DisplayMember = "INombre"
            ComboMotivosIncentivoSegunNave.ValueMember = "IIncentivoId"
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
        comboDepartamentos.DisplayMember = "grup_name".ToUpper
        comboDepartamentos.ValueMember = "grup_grupoid"
        Return comboDepartamentos

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

    Public Shared Function ComboAreasSegunNaves(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal idNave As Int32) As System.Windows.Forms.ComboBox
        Dim comboDepartamentos As New ComboBox
        comboDepartamentos = comboEntrada
        Dim tabladeAreas As New DataTable
        Dim objAreassBU As New Negocios.AreasBU
        tabladeAreas = objAreassBU.listaAreasSegunNave(idNave)
        tabladeAreas.Rows.InsertAt(tabladeAreas.NewRow, 0)
        comboDepartamentos.DataSource = tabladeAreas
        comboDepartamentos.DisplayMember = "area_nombre"
        comboDepartamentos.ValueMember = "area_areaid"
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


    Public Shared Function ComboBancos(ByVal comboentrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboBancos = New ComboBox
        ComboBancos = comboentrada

        Dim objbANCOSBU As New BancosBU
        Dim tablaBancos As New DataTable
        tablaBancos = objbANCOSBU.listaBancosActivos()
        tablaBancos.Rows.InsertAt(tablaBancos.NewRow, 0)
        With ComboBancos
            .DataSource = tablaBancos
            .DisplayMember = "banc_nombre"
            .ValueMember = "banc_bancoid"
        End With
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


    Public Shared Function ComboHorarios(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal NaveId As Int32) As System.Windows.Forms.ComboBox
        ComboHorarios = New ComboBox
        ComboHorarios = comboEntrada
        Dim tablaHorarios As New DataTable
        Dim objHorariosBU As New Negocios.HorariosBU
        tablaHorarios = objHorariosBU.listaHorariosSegunNave(NaveId)
        tablaHorarios.Rows.InsertAt(tablaHorarios.NewRow, 0)
        ComboHorarios.DataSource = tablaHorarios
        ComboHorarios.DisplayMember = "hora_nombre"
        ComboHorarios.ValueMember = "hora_horarioid"
    End Function


    Public Shared Function ComboCelulas(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboCelulas = New ComboBox
        ComboCelulas = comboEntrada
        Dim tablaCelulas As New DataTable
        Dim objCelulasBu As New Negocios.CelulasBU
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
        Dim objCelulasBU As New Negocios.CelulasBU
        tablaCelulas = objCelulasBU.ListaCelulasegunDepartamento(idDepartamento)
        tablaCelulas.Rows.InsertAt(tablaCelulas.NewRow, 0)
        ComboCelulasSegunDepartamento.DataSource = tablaCelulas
        ComboCelulasSegunDepartamento.DisplayMember = "celu_nombre"
        ComboCelulasSegunDepartamento.ValueMember = "celu_celulaid"

    End Function


    Public Shared Function ComboPatrones(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        ComboPatrones = New ComboBox
        ComboPatrones = comboEntrada
        Dim objPatronesBu As New Negocios.PatronesBU
        Dim tablaPatrones As New DataTable
        tablaPatrones = objPatronesBu.listaPatronesActivos()
        tablaPatrones.Rows.InsertAt(tablaPatrones.NewRow, 0)
        ComboPatrones.DataSource = tablaPatrones
        ComboPatrones.DisplayMember = "patr_nombre"
        ComboPatrones.ValueMember = "patr_patronid"
    End Function


    Public Shared Function ComboColaboradoresSegunNave(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal IDNave As Int32) As System.Windows.Forms.ComboBox
        Dim comboColaboradores As New ComboBox
        comboColaboradores = comboEntrada
        Dim tablaColaboradores As New DataTable
        Dim objColaboradorBU As New Nomina.Negocios.ColaboradoresBU
        tablaColaboradores = objColaboradorBU.listaColaboradoresNave(IDNave)
        tablaColaboradores.Rows.InsertAt(tablaColaboradores.NewRow, 0)
        comboColaboradores.DataSource = tablaColaboradores
        comboColaboradores.DisplayMember = "NombreColaborador"
        comboColaboradores.ValueMember = "IdColaborador"
        Return comboColaboradores

    End Function

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

    Public Shared Function ComboColaboradoresSegunCelula(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal celulaID As Integer) As System.Windows.Forms.ComboBox
        Dim comboColaboradores As New ComboBox
        comboColaboradores = comboEntrada
        Dim tablaColaboradores As New DataTable
        Dim objColaboradorBU As New Nomina.Negocios.ColaboradoresBU
        tablaColaboradores = objColaboradorBU.listaColaboradoresCelula(celulaID)
        tablaColaboradores.Rows.InsertAt(tablaColaboradores.NewRow, 0)
        comboColaboradores.DataSource = tablaColaboradores
        comboColaboradores.DisplayMember = "NombreColaborador"
        comboColaboradores.ValueMember = "IdColaborador"
        Return comboColaboradores

    End Function

    Public Shared Function ComboMotivosPermiso(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal NaveId As Int32) As System.Windows.Forms.ComboBox
        Dim comboMotivos As New ComboBox
        comboMotivos = comboEntrada
        Dim tablaMotivosPermisos As New DataTable
        Dim objMotivosPermisoBU As New Nomina.Negocios.ConfiguracionPermisosBU
        tablaMotivosPermisos = objMotivosPermisoBU.listaMotivosPermisosNave(NaveId)
        tablaMotivosPermisos.Rows.InsertAt(tablaMotivosPermisos.NewRow, 0)
        comboMotivos.DataSource = tablaMotivosPermisos
        comboMotivos.DisplayMember = "MotivoDescripcion"
        comboMotivos.ValueMember = "MotivoId"
        Return comboMotivos
    End Function

    Public Shared Function ComboTipoPermiso(ByVal comboEntrada As System.Windows.Forms.ComboBox) As System.Windows.Forms.ComboBox
        Dim comboTiposPermisos As New ComboBox
        comboTiposPermisos = comboEntrada
        Dim tablaTiposPermisos As New DataTable
        Dim objTiposPermisoBU As New Nomina.Negocios.ConfiguracionPermisosBU
        tablaTiposPermisos = objTiposPermisoBU.listaTiposPermisos
        comboTiposPermisos.DataSource = tablaTiposPermisos
        comboTiposPermisos.DisplayMember = "TipoPermisoDescripcion"
        comboTiposPermisos.ValueMember = "TipoPermisoId"
        Return comboTiposPermisos
    End Function

    Public Shared Function ComboPeriodoSegunNaveSegunAsistencia(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal naveID As Int32) As System.Windows.Forms.ComboBox

        Dim comboPeriodosSegunNave As New ComboBox
        comboPeriodosSegunNave = comboEntrada
        Dim tablaPeriodosSegunNave As New DataTable
        Dim objPeriodosSegunNave As New Nomina.Negocios.ControlDePeriodoBU
        tablaPeriodosSegunNave = objPeriodosSegunNave.buscarPeriodoSegunNaveSegunAsistencia(naveID)
        Dim newRow As DataRow = tablaPeriodosSegunNave.NewRow
        tablaPeriodosSegunNave.Rows.InsertAt(newRow, 0)
        comboPeriodosSegunNave.DataSource = tablaPeriodosSegunNave
        comboPeriodosSegunNave.DisplayMember = "pnom_Concepto"
        comboPeriodosSegunNave.ValueMember = "pnom_PeriodoNomId"

        Return comboPeriodosSegunNave

    End Function

    Public Shared Function ComboPeriodoSegunNaveIncentivos(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal naveID As Int32) As System.Windows.Forms.ComboBox

        Dim comboPeriodosSegunNave As New ComboBox
        comboPeriodosSegunNave = comboEntrada
        Dim tablaPeriodosSegunNave As New DataTable
        Dim objPeriodosSegunNave As New Nomina.Negocios.ControlDePeriodoBU
        tablaPeriodosSegunNave = objPeriodosSegunNave.buscarPeriodoSegunNaveSegunAsistencia(naveID)
        tablaPeriodosSegunNave.Rows.InsertAt(tablaPeriodosSegunNave.NewRow, 0)
        comboPeriodosSegunNave.DataSource = tablaPeriodosSegunNave
        comboPeriodosSegunNave.DisplayMember = "pnom_Concepto"
        comboPeriodosSegunNave.ValueMember = "pnom_PeriodoNomId"

        Return comboPeriodosSegunNave

    End Function

    Public Shared Function ComboPeriodoSegunNaveSegunAsistenciaControlAsistencia(ByVal comboEntrada As System.Windows.Forms.ComboBox, ByVal naveID As Int32) As System.Windows.Forms.ComboBox

        Dim comboPeriodosSegunNave As New ComboBox
        comboPeriodosSegunNave = comboEntrada
        Dim tablaPeriodosSegunNave As New DataTable
        Dim objPeriodosSegunNave As New Nomina.Negocios.ControlDePeriodoBU
        tablaPeriodosSegunNave = objPeriodosSegunNave.buscarPeriodoSegunNaveSegunAsistenciaControlAsistencia(naveID)
        comboPeriodosSegunNave.DataSource = tablaPeriodosSegunNave
        comboPeriodosSegunNave.DisplayMember = "pnom_Concepto"
        comboPeriodosSegunNave.ValueMember = "pnom_PeriodoNomId"

        Return comboPeriodosSegunNave

    End Function


End Class

