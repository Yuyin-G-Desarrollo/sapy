Imports Framework.Negocios
Imports Entidades
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class OpcionesProgramacionForm

    Dim tabActiva As Integer
    Dim dictionary As Dictionary(Of String, OpcionesProgramacion)
    Dim opcionesProgramacionBU As OpcionesProgramacionBU
    Dim opcionesProgramacion As OpcionesProgramacion
    Dim bandera As Boolean = False
    Dim banderaNume As Boolean = False
    Dim listNumericUpDown As List(Of NumericUpDown)
    Dim listNumericUpDownDown As List(Of NumericUpDown)

    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        'UltraTabPageControl3
        obtenerValoresIniciales()
        tabActiva = datosTab.ActiveTab.Index
        inicializar(tabActiva)
        crearListaDeControles()
        llenarTablaBloqueo()
        bandera = True
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        tabActiva = datosTab.ActiveTab.Index
        editarInformacion(tabActiva)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tabActiva = datosTab.ActiveTab.Index
        inicializar(tabActiva)
    End Sub

    Private Sub datosTab_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles datosTab.SelectedTabChanged
        If bandera Then
            tabActiva = e.Tab.Index
            mostraDatos(tabActiva)
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        tabActiva = datosTab.ActiveTab.Index
        guardaDatos(tabActiva)
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        tabActiva = datosTab.ActiveTab.Index
        mostraDatos(tabActiva)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Public Sub editarInformacion(ByVal tabActiva As Integer)
        Dim total As Integer = datosTab.Tabs.Count
        Dim i As Integer = 0

        While i < total
            If Not i = tabActiva Then
                datosTab.Tabs(i).Enabled = False
            End If
            i += 1
        End While

        groupboxestatus(True, tabActiva)

        botonesEstatus(False, True)
    End Sub
    Public Sub inicializar(ByVal tabActiva As Integer)
        Dim total As Integer = datosTab.Tabs.Count
        Dim i As Integer = 0

        While i < total
            datosTab.Tabs(i).Enabled = True
            i += 1
        End While

        groupboxestatus(False, tabActiva)

        botonesEstatus(True, False)
        mostraDatos(tabActiva)
    End Sub
    Public Sub groupboxestatus(ByVal estatus As Boolean, ByVal tab As Integer)
        Select Case tab
            Case 0
                gpbGenerales.Enabled = estatus
            Case 1
                grpPantallas1.Enabled = estatus
                grpPantallas2.Enabled = estatus
                grpPantallas3.Enabled = estatus
            Case 2
                grpProgramacion.Enabled = estatus
            Case Else
                gpbGenerales.Enabled = False
                grpPantallas1.Enabled = False
                grpPantallas2.Enabled = False
                grpPantallas3.Enabled = False
        End Select
    End Sub
    Public Sub botonesEstatus(ByVal estatusbt1, ByVal estatusbtn2)
        btnEditar.Enabled = estatusbt1
        lblEditar.Enabled = estatusbt1
        btnMostrar.Enabled = estatusbt1
        lblMostrar.Enabled = estatusbt1
        btnCancelar.Enabled = estatusbtn2
        lblCancelar.Enabled = estatusbtn2
        btnGuardar.Enabled = estatusbtn2
        lblGuardar.Enabled = estatusbtn2
    End Sub
    Public Sub mostraDatos(ByVal tab As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Select Case tab
                Case 0
                    mostrarDatosTabGenerales()
                Case 1
                    mostrarDatosTabPantallas()
                Case 2
                    mostrarDatosTabProgramacion()
                Case 3

                Case Else
                    mensajeAdvertencia("Opciones de Configuración", "Pestaña no asignada")
            End Select
        Catch ex As Exception
            mensajeError("Opciones de Configuración", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub mostrarDatosTabGenerales()
        nudTimerEntrega.Value = (dictionary("TimerEntrega").popcionValorEntero / 1000)
        chkMostrarFechasAutorizarPedidos.Checked = dictionary("OcultarColumnasPendientes").popcionValorBooleano
        nudDiasProgramacion.Value = (dictionary("DiasPrograma").popcionValorEntero)
        nudSemanasBloqueo.Value = (dictionary("BloqueoSemanas").popcionValorEntero)
    End Sub
    Public Sub mostrarDatosTabPantallas()
        btnFondoVerde.BackColor = System.Drawing.Color.FromArgb(dictionary("BackgroundVerde").popcionValorEntero)
        btnFondoAmarillo.BackColor = System.Drawing.Color.FromArgb(dictionary("BackgroundAmarillo").popcionValorEntero)
        btnFondoRojo.BackColor = System.Drawing.Color.FromArgb(dictionary("BackgroundRojo").popcionValorEntero)

        btnPanelImpar.BackColor = System.Drawing.Color.FromArgb(dictionary("BackgroundPanel").popcionValorEntero)

        btnSemCap1.BackColor = System.Drawing.Color.FromArgb(dictionary("Sem_ocupacion_1").popcionValorEntero)
        btnSemCap2.BackColor = System.Drawing.Color.FromArgb(dictionary("Sem_ocupacion_2").popcionValorEntero)
        btnSemCap3.BackColor = System.Drawing.Color.FromArgb(dictionary("Sem_ocupacion_3").popcionValorEntero)
        btnSemCap4.BackColor = System.Drawing.Color.FromArgb(dictionary("Sem_ocupacion_4").popcionValorEntero)

        nudSemCap1Inicio.Value = (dictionary("Sem_ocupacion_1").popcionNumericoUno)
        nudSemCap1Final.Value = (dictionary("Sem_ocupacion_1").popcionNumericoDos)
        nudSemCap2Inicio.Value = (dictionary("Sem_ocupacion_2").popcionNumericoUno)
        nudSemCap2Final.Value = (dictionary("Sem_ocupacion_2").popcionNumericoDos)
        nudSemCap3Inicio.Value = (dictionary("Sem_ocupacion_3").popcionNumericoUno)
        nudSemCap3Final.Value = (dictionary("Sem_ocupacion_3").popcionNumericoDos)
        nudSemCap4Inicio.Value = (dictionary("Sem_ocupacion_4").popcionNumericoUno)
        nudSemCap4Final.Value = (dictionary("Sem_ocupacion_4").popcionNumericoDos)

    End Sub
    Public Sub mostrarDatosTabProgramacion()
        btnAgregar.Enabled = False
        lblAgregar.Enabled = False
        btnEliminar.Enabled = False
        lblEliminar.Enabled = False
        llenarCombo()
        llenarTablaUsuarios()
        chkProgramacionAutomática.Checked = dictionary("ProgAutomatica").popcionValorBooleano
        nudProgramacion.Value = (dictionary("ProgTimer").popcionValorEntero / 1000) / 60

    End Sub
    Public Sub llenarCombo()
        opcionesProgramacionBU = New OpcionesProgramacionBU
        Dim tablaUsuarios As New DataTable
        tablaUsuarios = opcionesProgramacionBU.ListarUsuariosSegunPerfil(33)
        tablaUsuarios.Rows.InsertAt(tablaUsuarios.NewRow, 0)
        With cmbUsuario
            .DisplayMember = "user_nombrereal"
            .ValueMember = "user_usuarioid"
            .DataSource = tablaUsuarios
        End With
    End Sub
    Public Sub llenarTablaUsuarios()
        grdUsuarios.DataSource = Nothing
        opcionesProgramacionBU = New OpcionesProgramacionBU
        grdUsuarios.DataSource = opcionesProgramacionBU.tablaUsuarioProgramacion
        formatoGrigUsuario()
    End Sub
    Public Sub formatoGrigUsuario()
        Dim band As UltraGridBand = Me.grdUsuarios.DisplayLayout.Bands(0)
        With band
            .Columns("ID_").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
            .Columns("paus_fechamodificacion").CellActivation = Activation.NoEdit
            .Columns("user_username").CellActivation = Activation.NoEdit
            .Columns("ID_").Hidden = True
            .Columns("paus_fechamodificacion").Header.Caption = "Modificación"
            .Columns("user_username").Header.Caption = "Modificó"
        End With


        grdUsuarios.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdUsuarios.DisplayLayout.Override.RowSelectorWidth = 35
        grdUsuarios.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdUsuarios.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect


        Dim aRowScrollbarUIElement As Infragistics.Win.UltraWinGrid.RowScrollbarUIElement
        aRowScrollbarUIElement = grdUsuarios.DisplayLayout.UIElement.GetDescendant(GetType(Infragistics.Win.UltraWinGrid.RowScrollbarUIElement))


        band.Columns("Usuario").Width = 350
        band.Columns("paus_fechamodificacion").Width = 120
    End Sub
    Public Sub guardaDatos(ByVal tab As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            If mensajeConfirmar("Opciones de Configuración", "¿ Desea guardar los cambios ?") = Windows.Forms.DialogResult.OK Then
                Select Case tab
                    Case 0
                        guardarDatosTabGenerales()
                        mensajeExito("Opciones de Configuración", "Información actualizada con éxito")
                    Case 1
                        guardarDatosTabPantallas()
                        mensajeExito("Opciones de Configuración", "Información actualizada con éxito")
                    Case 2
                        guardarDatosTabProgramacion()
                        mensajeExito("Opciones de Configuración", "Información actualizada con éxito")
                    Case Else
                        mensajeAdvertencia("Opciones de Configuración", "Error al guardar los registros")
                End Select
            End If
            inicializar(tab)
        Catch ex As Exception
            mensajeError("Opciones de Configuración", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub guardarDatosTabGenerales()

        dictionary("TimerEntrega").popcionValorEntero = nudTimerEntrega.Value * 1000
        dictionary("OcultarColumnasPendientes").popcionValorBooleano = chkMostrarFechasAutorizarPedidos.Checked
        dictionary("DiasPrograma").popcionValorEntero = nudDiasProgramacion.Value
        dictionary("BloqueoSemanas").popcionValorEntero = nudSemanasBloqueo.Value

        Dim tabla As New DataTable
        tabla.Columns.Add("set")
        tabla.Columns.Add("valorset")
        tabla.Columns.Add("where")
        tabla.Columns.Add("valorWhere")
        tabla.Rows.Add(New Object() {"opci_valor_entero", dictionary("TimerEntrega").popcionValorEntero, "opci_descripcion", "TimerEntrega"})
        tabla.Rows.Add(New Object() {"opci_valor_booleano", IIf(chkMostrarFechasAutorizarPedidos.Checked, 1, 0), "opci_descripcion", "OcultarColumnasPendientes"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", nudDiasProgramacion.Value, "opci_descripcion", "DiasPrograma"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", nudSemanasBloqueo.Value, "opci_descripcion", "BloqueoSemanas"})
        opcionesProgramacionBU = New OpcionesProgramacionBU
        opcionesProgramacionBU.actualizarOpciones(tabla)

    End Sub
    Public Sub guardarDatosTabPantallas()
        dictionary("BackgroundVerde").popcionValorEntero = btnFondoVerde.BackColor.ToArgb
        dictionary("BackgroundAmarillo").popcionValorEntero = btnFondoAmarillo.BackColor.ToArgb
        dictionary("BackgroundRojo").popcionValorEntero = btnFondoRojo.BackColor.ToArgb
        dictionary("BackgroundPanel").popcionValorEntero = btnPanelImpar.BackColor.ToArgb

        dictionary("Sem_ocupacion_1").popcionValorEntero = btnSemCap1.BackColor.ToArgb
        dictionary("Sem_ocupacion_2").popcionValorEntero = btnSemCap2.BackColor.ToArgb
        dictionary("Sem_ocupacion_3").popcionValorEntero = btnSemCap3.BackColor.ToArgb
        dictionary("Sem_ocupacion_4").popcionValorEntero = btnSemCap4.BackColor.ToArgb

        dictionary("Sem_ocupacion_1").popcionNumericoUno = nudSemCap1Inicio.Value
        dictionary("Sem_ocupacion_1").popcionNumericoDos = nudSemCap1Final.Value
        dictionary("Sem_ocupacion_2").popcionNumericoUno = nudSemCap2Inicio.Value
        dictionary("Sem_ocupacion_2").popcionNumericoDos = nudSemCap2Final.Value
        dictionary("Sem_ocupacion_3").popcionNumericoUno = nudSemCap3Inicio.Value
        dictionary("Sem_ocupacion_3").popcionNumericoDos = nudSemCap3Final.Value
        dictionary("Sem_ocupacion_4").popcionNumericoUno = nudSemCap4Inicio.Value
        dictionary("Sem_ocupacion_4").popcionNumericoDos = nudSemCap4Final.Value

        Dim tabla As New DataTable
        tabla.Columns.Add("set")
        tabla.Columns.Add("valorset")
        tabla.Columns.Add("where")
        tabla.Columns.Add("valorWhere")
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnFondoVerde.BackColor.ToArgb, "opci_descripcion", "BackgroundVerde"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnFondoAmarillo.BackColor.ToArgb, "opci_descripcion", "BackgroundAmarillo"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnFondoRojo.BackColor.ToArgb, "opci_descripcion", "BackgroundRojo"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnPanelImpar.BackColor.ToArgb, "opci_descripcion", "BackgroundPanel"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnSemCap1.BackColor.ToArgb, "opci_descripcion", "Sem_ocupacion_1"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnSemCap2.BackColor.ToArgb, "opci_descripcion", "Sem_ocupacion_2"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnSemCap3.BackColor.ToArgb, "opci_descripcion", "Sem_ocupacion_3"})
        tabla.Rows.Add(New Object() {"opci_valor_entero", btnSemCap4.BackColor.ToArgb, "opci_descripcion", "Sem_ocupacion_4"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico", nudSemCap1Inicio.Value, "opci_descripcion", "Sem_ocupacion_1"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico_2", nudSemCap1Final.Value, "opci_descripcion", "Sem_ocupacion_1"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico", nudSemCap2Inicio.Value, "opci_descripcion", "Sem_ocupacion_2"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico_2", nudSemCap2Final.Value, "opci_descripcion", "Sem_ocupacion_2"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico", nudSemCap3Inicio.Value, "opci_descripcion", "Sem_ocupacion_3"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico_2", nudSemCap3Final.Value, "opci_descripcion", "Sem_ocupacion_3"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico", nudSemCap4Inicio.Value, "opci_descripcion", "Sem_ocupacion_4"})
        tabla.Rows.Add(New Object() {"opci_valor_numerico_2", nudSemCap4Final.Value, "opci_descripcion", "Sem_ocupacion_4"})

        opcionesProgramacionBU.actualizarOpciones(tabla)

    End Sub

    Public Sub guardarDatosTabProgramacion()
        dictionary("ProgAutomatica").popcionValorBooleano = chkProgramacionAutomática.Checked
        dictionary("ProgTimer").popcionValorEntero = (nudProgramacion.Value * 1000) * 60
        Dim tabla As New DataTable
        tabla.Columns.Add("set")
        tabla.Columns.Add("valorset")
        tabla.Columns.Add("where")
        tabla.Columns.Add("valorWhere")
        tabla.Rows.Add(New Object() {"opci_valor_entero", dictionary("ProgTimer").popcionValorEntero, "opci_descripcion", "ProgTimer"})
        tabla.Rows.Add(New Object() {"opci_valor_booleano", IIf(chkProgramacionAutomática.Checked, 1, 0), "opci_descripcion", "ProgAutomatica"})
        opcionesProgramacionBU.actualizarOpciones(tabla)

    End Sub
    Public Sub mensajeAdvertencia(ByVal titulo As String, ByVal mensaje As String)
        Dim vAdvertenciaForm As New AdvertenciaForm
        vAdvertenciaForm.Text = titulo
        vAdvertenciaForm.mensaje = mensaje
        vAdvertenciaForm.ShowDialog()
        vAdvertenciaForm = Nothing
    End Sub
    Public Sub mensajeError(ByVal titulo As String, ByVal mensaje As String)
        Dim vErrorForm As New ErroresForm
        vErrorForm.Text = titulo
        vErrorForm.mensaje = mensaje
        vErrorForm.ShowDialog()
        vErrorForm = Nothing
    End Sub
    Public Sub mensajeExito(ByVal titulo As String, ByVal mensaje As String)
        Dim vExitoForm As New ExitoForm
        vExitoForm.Text = titulo
        vExitoForm.mensaje = mensaje
        vExitoForm.ShowDialog()
        vExitoForm = Nothing
    End Sub
    Public Function mensajeConfirmar(ByVal titulo As String, mensaje As String) As DialogResult
        Dim vConfirmarForm As New ConfirmarForm
        Dim vDialogResult As New DialogResult
        vConfirmarForm.Text = titulo
        vConfirmarForm.mensaje = mensaje
        vDialogResult = vConfirmarForm.ShowDialog
        Return vDialogResult
    End Function
    Public Sub obtenerValoresIniciales()
        opcionesProgramacionBU = New OpcionesProgramacionBU
        dictionary = New Dictionary(Of String, OpcionesProgramacion)
        dictionary = opcionesProgramacionBU.obtnerValoresTabla
    End Sub
    Public Sub crearListaDeControles()
        listNumericUpDown = New List(Of NumericUpDown)
        listNumericUpDown.Add(nudSemCap1Inicio)
        listNumericUpDown.Add(nudSemCap1Final)
        listNumericUpDown.Add(nudSemCap2Inicio)
        listNumericUpDown.Add(nudSemCap2Final)
        listNumericUpDown.Add(nudSemCap3Inicio)
        listNumericUpDown.Add(nudSemCap3Final)
        listNumericUpDown.Add(nudSemCap4Inicio)
        listNumericUpDown.Add(nudSemCap4Final)

        listNumericUpDownDown = New List(Of NumericUpDown)
        listNumericUpDownDown.Add(nudSemCap4Final)
        listNumericUpDownDown.Add(nudSemCap4Inicio)
        listNumericUpDownDown.Add(nudSemCap3Final)
        listNumericUpDownDown.Add(nudSemCap3Inicio)
        listNumericUpDownDown.Add(nudSemCap2Final)
        listNumericUpDownDown.Add(nudSemCap2Inicio)
        listNumericUpDownDown.Add(nudSemCap1Final)
        listNumericUpDownDown.Add(nudSemCap1Inicio)
    End Sub
    Public Sub cambiarValoresControles(ByVal numSemCap As NumericUpDown)
        Try
            Dim posicionValor As Integer = listNumericUpDown.IndexOf(numSemCap)
            Dim valorPosicion As Double = 0.0
            Dim resultado As Double = 0.5
            While posicionValor < (listNumericUpDown.Count - 1)
                resultado = (posicionValor + 1) Mod 2
                valorPosicion = listNumericUpDown.Item(posicionValor).Value
                posicionValor += 1
                If resultado = 0.0 Then
                    If posicionValor < (listNumericUpDown.Count - 1) Then
                        listNumericUpDown.Item(posicionValor).Value = valorPosicion + 0.01
                    End If
                Else
                    If valorPosicion > listNumericUpDown.Item(posicionValor).Value Then
                        listNumericUpDown.Item(posicionValor).Value = valorPosicion + 0.01
                        posicionValor += 1
                        If posicionValor < (listNumericUpDown.Count - 1) Then
                            listNumericUpDown.Item(posicionValor).Value = valorPosicion + 0.02
                        End If
                    Else
                        Exit While
                    End If
                End If


            End While
        Catch ex As Exception
            mensajeError("Opciones de Configuración", ex.Message)
        End Try


    End Sub
    Public Sub cambiarValoresControlesDown(ByVal numSemCap As NumericUpDown)

        Try
            Dim posicionValor As Integer = listNumericUpDownDown.IndexOf(numSemCap)
            Dim valorPosicion As Double = 0.0
            Dim resultado As Double = 0.5
            While posicionValor < listNumericUpDownDown.Count - 1
                resultado = (posicionValor + 1) Mod 2
                valorPosicion = listNumericUpDownDown.Item(posicionValor).Value
                posicionValor += 1
                If resultado = 0.0 Then
                    If posicionValor < (listNumericUpDownDown.Count + 1) Then
                        If Not valorPosicion = 0.0 Then
                            valorPosicion -= 0.01
                        End If
                        listNumericUpDownDown.Item(posicionValor).Value = valorPosicion
                    End If
                Else
                    If valorPosicion < listNumericUpDownDown.Item(posicionValor).Value Then
                        If Not valorPosicion = 0.0 Then
                            valorPosicion -= 0.01
                        End If
                        listNumericUpDownDown.Item(posicionValor).Value = valorPosicion
                        posicionValor += 1
                        If posicionValor < listNumericUpDownDown.Count - 1 Then
                            If Not valorPosicion = 0.0 Then
                                valorPosicion -= 0.01
                            End If
                            listNumericUpDownDown.Item(posicionValor).Value = valorPosicion
                        End If
                    Else
                        Exit While
                    End If
                End If


            End While
        Catch ex As Exception
            mensajeError("Opciones de Configuración", ex.Message)
        End Try

    End Sub
    Private Sub btnFondoVerde_Click(sender As Object, e As EventArgs) Handles btnFondoVerde.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnFondoVerde.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnFondoAmarillo_Click(sender As Object, e As EventArgs) Handles btnFondoAmarillo.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnFondoAmarillo.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnFondoRojo_Click(sender As Object, e As EventArgs) Handles btnFondoRojo.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnFondoRojo.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnSemCap1_Click(sender As Object, e As EventArgs) Handles btnSemCap1.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnSemCap1.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnSemCap2_Click(sender As Object, e As EventArgs) Handles btnSemCap2.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnSemCap2.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnSemCap3_Click(sender As Object, e As EventArgs) Handles btnSemCap3.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnSemCap3.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnSemCap4_Click(sender As Object, e As EventArgs) Handles btnSemCap4.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnSemCap4.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub btnPanelImpar_Click(sender As Object, e As EventArgs) Handles btnPanelImpar.Click
        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.btnPanelImpar.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub nudSemCap1Inicio_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap1Inicio.LostFocus
        If bandera Then
            cambiarValoresControles(nudSemCap1Inicio)
        End If
    End Sub

    Private Sub nudSemCap1Final_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap1Final.LostFocus
        If bandera Then
            cambiarValoresControles(nudSemCap1Final)
            cambiarValoresControlesDown(nudSemCap1Final)
        End If

    End Sub

    Private Sub nudSemCap2Inicio_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap2Inicio.LostFocus
        If bandera Then
            cambiarValoresControles(nudSemCap2Inicio)
            cambiarValoresControlesDown(nudSemCap2Inicio)
        End If
    End Sub

    Private Sub nudSemCap2Final_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap2Final.LostFocus
        If bandera Then
            cambiarValoresControles(nudSemCap2Final)
            cambiarValoresControlesDown(nudSemCap2Final)

        End If
    End Sub

    Private Sub nudSemCap3Inicio_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap3Inicio.LostFocus
        If bandera Then
            cambiarValoresControles(nudSemCap3Inicio)
            cambiarValoresControlesDown(nudSemCap3Inicio)

        End If
    End Sub

    Private Sub nudSemCap3Final_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap3Final.LostFocus
        If bandera Then
            cambiarValoresControles(nudSemCap3Final)
            cambiarValoresControlesDown(nudSemCap3Final)

        End If
    End Sub

    Private Sub nudSemCap4Inicio_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap4Inicio.LostFocus
        If bandera Then

            cambiarValoresControles(nudSemCap4Inicio)
            cambiarValoresControlesDown(nudSemCap4Inicio)


        End If
    End Sub

    Private Sub nudSemCap4Final_LostFocus(sender As Object, e As EventArgs) Handles nudSemCap4Final.LostFocus
        If bandera Then

            cambiarValoresControlesDown(nudSemCap4Final)


        End If
    End Sub

    Private Sub grdUsuarios_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdUsuarios.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdUsuarios_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdUsuarios.ClickCell
        With grdUsuarios
            If .ActiveRow Is Nothing Then
                btnEliminar.Enabled = False
                lblEliminar.Enabled = False
                Exit Sub
            End If

            If .ActiveRow.Index < 0 Then
                btnEliminar.Enabled = False
                lblEliminar.Enabled = False
                Exit Sub
            End If

        End With
        btnEliminar.Enabled = True
        lblEliminar.Enabled = True
    End Sub

    Private Sub grdUsuarios_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdUsuarios.InitializeLayout
        e.Layout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToLastItem
        e.Layout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Deferred
    End Sub

    Private Sub cmbUsuario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUsuario.SelectedIndexChanged
        If Not cmbUsuario.Text = "" Then
            btnAgregar.Enabled = True
            lblAgregar.Enabled = True
        Else
            btnAgregar.Enabled = False
            lblAgregar.Enabled = False
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregarUsuarioProgramacionOpciones()
    End Sub
    Public Sub agregarUsuarioProgramacionOpciones()
        If Not cmbUsuario.Text = "" Then
            If mensajeConfirmar("Opciones de Configuración", "¿ Está seguro de guardar el usuario para ejecutar  programación automática ?") = Windows.Forms.DialogResult.OK Then
                opcionesProgramacionBU = New OpcionesProgramacionBU
                opcionesProgramacionBU.Agregar(cmbUsuario.SelectedValue)
                btnAgregar.Enabled = False
                lblAgregar.Enabled = False
                btnEliminar.Enabled = False
                lblEliminar.Enabled = False
                llenarCombo()
                llenarTablaUsuarios()
                mensajeExito("Opciones de Configuración", "Usuario agregado a programación automática exitosamente.")
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        With grdUsuarios
            If .ActiveRow Is Nothing Then
                Exit Sub
            End If

            If .ActiveRow.Index < 0 Then
                Exit Sub
            End If
            eliminarUsuarioProgramacionOpciones()
        End With
    End Sub
    Public Sub eliminarUsuarioProgramacionOpciones()
        If mensajeConfirmar("Opciones de Configuración", "¿ Está seguro de eliminar al usuario para ejecutar  programación automática ?") = Windows.Forms.DialogResult.OK Then
            opcionesProgramacionBU = New OpcionesProgramacionBU
            opcionesProgramacionBU.Eliminar(grdUsuarios.ActiveRow.Cells("ID_").Value)
            llenarCombo()
            llenarTablaUsuarios()
            mensajeExito("Opciones de Configuración", "Usuario eliminado de programación automática exitosamente.")
        End If
    End Sub


    Public Sub importarBloqueo()
        Dim objBloqueoBU As New Negocios.BloqueoBU
        objBloqueoBU.importarBloqueo()
    End Sub

    Public Sub llenarTablaBloqueo()
        Dim objBU As New Negocios.BloqueoBU
        Dim dt As New DataTable
        Dim datoFecha As String = ""

        datoFecha = objBU.fechaUltimaActualizacionTablaBloqueo
        lblUltimaActualizacion.Text = datoFecha

        dt = objBU.consultaTablaBloqueo

        grdClientesBloqueados.DataSource = dt

        With grdClientesBloqueados.DisplayLayout.Bands(0)
            .Columns("clie_nombregenerico").Header.Caption = "Cliente"
            .Columns("FCaptura").Header.Caption = "Fecha"
            .Columns("clie_nombregenerico").CellActivation = Activation.NoEdit
            .Columns("Motivo").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("FCaptura").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
        End With

        grdClientesBloqueados.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grdClientesBloqueados.DisplayLayout.Bands(0).Columns("clie_nombregenerico").Width = 350

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Está seguro de importar los datos de bloqueo?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            importarBloqueo()
            llenarTablaBloqueo()
            Me.Cursor = Cursors.Default
        End If
    End Sub

End Class