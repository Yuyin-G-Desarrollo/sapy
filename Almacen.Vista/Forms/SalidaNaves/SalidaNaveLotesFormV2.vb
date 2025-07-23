Imports Almacen.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.IO
Imports Stimulsoft.Report
Imports Tools
Imports System.Media
Imports System.Text
Imports ToolServicios
Imports Facturacion.Negocios

Public Class SalidaNaveLotesFormV2

    Dim dtTablaGridCodigosParesEscaneados As New DataTable
    Dim lListaAcciones As New List(Of String)
    '
    Dim dtCodigosEscaneados As New List(Of String)
    Dim dtCodigosDeParALeer As New DataTable
    Dim dtCodigosDeAtadosALeer As New DataTable
    Dim dtLotesALeer As New DataTable

    Dim dtCodigosErroneos As New DataTable

    Dim IdSalidaNaves As Integer = 0
    Dim UsuarioID As Integer = 0
    Dim IdNave As Integer = 0

    Dim ObjBU As New SalidasAlmacenBU
    Dim EntSalidaNave As New Entidades.InfoSalidaNave

    Dim ListaDatosAtado As New List(Of Entidades.CapturaAtadoValido)
    Dim DatosAtado As New Entidades.CapturaAtadoValido 'Atado Actual
    Dim DatosLote As New Entidades.InformacionLoteSalidaNave 'Lote Actual

    Dim ListaAtadosPares As New List(Of Entidades.CapturaParValido)
    Dim ListaPares As New List(Of Entidades.CapturaParValido)
    Dim ListaAtadosPendientes As New List(Of Entidades.CapturaAtadoValido)
    Dim ListaParesErroneos As New List(Of Entidades.CodigosErroneos)
    Dim ListaLotesPiloto As New List(Of Integer)

    Dim dtParesALeer As New DataTable
    Dim dtAtadosALeer As New DataTable

    Dim CarritoActal As New Entidades.PlataformaEntrada
    Dim LotesDescartados As New List(Of String)
    Dim AtadosDescartados As Integer = 0
    Dim ParesDescartados As Integer = 0
    Dim reporte2 As New StiReport
    Dim reporte3 As New StiReport

    Dim ListaParesDescartados As New List(Of String)
    Dim ListaAtadosDescartados As New List(Of String)

    Enum ResultadosEscaneo
        CORRECTO = 1
        FALTANTE = 2
        SOBRANTE = 3
        MAL_FORMADO = 4
        SIN_TERMINAR = 5
        CORRECTO_SIN_TERMINAR = 6
        FALTANTE_SIN_TERMINAR = 7
        MAL_FORMADO_SIN_TERMINAR = 8
        NO_EMBARCADO = 9
        COMPLETO_NO_EMBARCADO = 10
        FALTANTE_NO_EMBARCADO = 11
        MAL_FORMADO_NO_EMBARCADO = 12
    End Enum

    Private Sub SalidaNaveLotesFormV2_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Location = New Point(0, 0)
        Me.WindowState = 2
        'lblCodigoOculto.Width = 0

        Try

            InicializarDatos()
            cmbNaves = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNaves, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) 'LLENA EL COMBO NAVES
            cmbNaves.SelectedIndex = 0
            btnDetener.Enabled = False
            'EntSalidaNave.LoteCompleto = False
            'DAR FORMATO A GRIDS
            DarFormatoDataTable_para_grid_Erroneos()
            DarFormatoDataTable_para_grid_Escaneados()
            'VERIFICA LOS PERMISOS DEL USUARIO LOGGEADO
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_ENTRADALOTES", "ALM_CAL_ENTRADA") _
            And Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_EMBARQUES_SALIDANAVES", "EMBARQUES_SALIDA") Then
                Me.Text = "Entrada Y Salida de Lotes"
                lblEncabezado.Text = "Entrada Y Salida de Lotes"
                lblEncabezado.Location = New Point(96, 24)

                lListaAcciones.Insert(0, "")
                lListaAcciones.Add("ENTRADA")
                lListaAcciones.Add("SALIDA")
                cmbProceso.DataSource = lListaAcciones
            ElseIf Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_ENTRADALOTES", "ALM_CAL_ENTRADA") Then
                Me.Text = "Entrada de Lotes"
                lblEncabezado.Text = "Entrada de Lotes"
                lListaAcciones.Add("ENTRADA")
                cmbProceso.DataSource = lListaAcciones

                lblParesAEmbarcar.Text = "Pares a Ingresar"
                lblAtadosAEmbarcar.Text = "Atados a Ingresar"
                lblLotesAEmbarcar.Text = "Lotes a Ingresar"




                lblTotalPares.ForeColor = Color.Black
                lblTotalAtados.ForeColor = Color.Black
                lblTotalLotes.ForeColor = Color.Black
            Else
                lListaAcciones.Add("SALIDA")

                cmbProceso.DataSource = lListaAcciones
                lblSinTerminarNoLeido.Text = "Lote sin terminar"
                lblPink.Visible = False
                lblChocolate.Visible = False
                lblOrangered.Visible = False
                lblLoteSinTerminarAtadoConFaltante.Visible = False
                lblLoteSinTerminarAtadoCorrecto.Visible = False
                lblLoteSinTerminarAtadoMalFormado.Visible = False

                pnlAcciones.Height = 39


                lblTotalPares.ForeColor = Color.Red
                lblTotalAtados.ForeColor = Color.Red
                lblTotalLotes.ForeColor = Color.Red

                grpNoEmbarcados.Visible = False
            End If
            'Me.Text = "Entrada Y Salida de Lotes"
            'lblEncabezado.Text = "Entrada Y Salida de Lotes"
            'lblEncabezado.Location = New Point(96, 24)

            'lListaAcciones.Insert(0, "")
            'lListaAcciones.Add("ENTRADA")
            'lListaAcciones.Add("SALIDA")
            'cmbProceso.DataSource = lListaAcciones

            grdIncorrecto.Size = New System.Drawing.Size((Me.Width / 2 - 10), 333)
            grdLectura.Size = New System.Drawing.Size((Me.Width / 2 - 10), 333)
            listado_naves()
            CrearTablas()

        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString)
        End Try

    End Sub
    Private Sub ActualizarGridPares()
        Dim ListaActualiza As New List(Of Entidades.CapturaParValido)
        Dim NumeroRegistros As Integer = 0
        ListaActualiza = ListaPares

        'For Each Par As Entidades.CapturaParValido In ListaAtadosPares
        '    ListaActualiza.Add(Par)
        'Next
        grdLectura.DataSource = Nothing
        grdLectura.DataSource = ListaActualiza
        DiseñoGridLecturaPares(grdLectura)
        ColorCodigosLeidos()

        Dim numerofilas As Integer = grdLectura.Rows.Count
        NumeroRegistros = CInt(numerofilas / 18)

        If numerofilas > 18 Then
            'grdLectura.DisplayLayout.RowScrollRegions(0).Scroll(RowScrollAction.Bottom)
            For index As Integer = 1 To NumeroRegistros
                grdLectura.DisplayLayout.RowScrollRegions(0).Scroll(RowScrollAction.PageDown)
            Next

        End If


    End Sub



    Private Sub InicializarDatos()

        With DatosAtado
            .PIdAtado = 0
            .PAño = 0
            .PDescripcion = ""
            .PIdCliente = 0
            .PIdNAve = 0
            .PLote = 0
            .PN_AtadoEscaneado = 0
            .PN_Pares = 0
            .Pn_ParesLeidos = 0
            .PStatusAtado = 0
        End With

        With DatosLote
            .Lote = 0
            .NaveSICYID = 0
            .ParesLote = 0
            .StatusLote = 0
        End With

        With EntSalidaNave
            .FolioCompleto = False
            .IdSalidaNave = 0
            .NaveSICYID = 0
        End With


    End Sub

    Private Sub listado_naves()
        Try
            'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            Dim objbu As New Almacen.Negocios.AlmacenBU
            Dim dtInformacionCentroDistribucion As DataTable
            Dim dtNumeroAlmacenes As DataTable

            Try
                cboxNaveAlmacen.Enabled = True
                cboxAlmacen.Enabled = True

                If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_ENTRADALOTES", "VER_ALM_ASIGNADO") Then
                    dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivosUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Else
                    dtInformacionCentroDistribucion = objbu.ConsultaCentroDistribucionActivos()
                End If

                cboxNaveAlmacen.DataSource = dtInformacionCentroDistribucion
                cboxNaveAlmacen.DisplayMember = "Nave"
                cboxNaveAlmacen.ValueMember = "NaveSAYID"

                cboxNaveAlmacen.SelectedIndex = 0

                If cboxNaveAlmacen.SelectedIndex = 0 Then
                    dtNumeroAlmacenes = objbu.ConsultaNumeroAlmacenes(cboxNaveAlmacen.SelectedValue)
                    cboxAlmacen.DataSource = dtNumeroAlmacenes
                    cboxAlmacen.ValueMember = "NumeroAlmacen"
                    cboxAlmacen.DisplayMember = "NumeroAlmacen"
                    cboxAlmacen.SelectedIndex = 0
                End If

                'Controles.ComboNavesConAlmacenSegunUsuario(cboxNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub DarFormatoDataTable_para_grid_Erroneos()
        Dim ColumnaQuitar As New DataColumn("Quitar")
        ColumnaQuitar.DataType = GetType(Boolean)

        Dim ColumnaLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Integer)

        Dim ColumnaNumeroEnLote As New DataColumn("# En lote")
        ColumnaNumeroEnLote.DataType = GetType(Integer)

        Dim ColumnaAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)

        Dim ColumnaDescripcion As New DataColumn("Descripción")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaEstado As New DataColumn("Estado")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaAño As New DataColumn("Año")
        ColumnaDescripcion.DataType = GetType(String)

        'dtTablaGridErrores.Columns.Add(ColumnaQuitar)
        'dtTablaGridErrores.Columns.Add(ColumnaLote)
        'dtTablaGridErrores.Columns.Add(ColumnaNumeroEnLote)
        'dtTablaGridErrores.Columns.Add(ColumnaAtado)
        'dtTablaGridErrores.Columns.Add(ColumnaDescripcion)
        'dtTablaGridErrores.Columns.Add(ColumnaEstado)
        'dtTablaGridErrores.Columns.Add(ColumnaAño)

        'grdIncorrecto.DataSource = Nothing
        'grdIncorrecto.DataSource = dtTablaGridErrores
        'grdIncorrecto.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grdIncorrecto.DisplayLayout.Override.RowSelectorWidth = 35


        Dim ColLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Integer)
        Dim ColNumero As New DataColumn("#")
        ColNumero.DataType = GetType(Integer)
        Dim ColAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)
        Dim ColDescripcion As New DataColumn("Descripción")
        ColumnaDescripcion.DataType = GetType(String)
        Dim ColAño As New DataColumn("Año")
        ColumnaDescripcion.DataType = GetType(String)

        'dtTablaAtados.Columns.Add(ColLote)
        'dtTablaAtados.Columns.Add(ColNumero)
        'dtTablaAtados.Columns.Add(ColAtado)
        'dtTablaAtados.Columns.Add(ColDescripcion)
        'dtTablaAtados.Columns.Add(ColAño)

    End Sub

    Public Sub DarFormatoDataTable_para_grid_Escaneados()

        Dim ColumnaNumero As New DataColumn("#")
        ColumnaNumero.DataType = GetType(Integer)

        Dim ColumnaNumeroEnLote As New DataColumn("# En lote")
        ColumnaNumero.DataType = GetType(Integer)


        Dim ColumnaLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Integer)

        Dim ColumnaAtado As New DataColumn("Atado")
        ColumnaAtado.DataType = GetType(String)

        Dim ColumnaPar As New DataColumn("Par")
        ColumnaPar.DataType = GetType(String)

        Dim ColumnaDescripcion As New DataColumn("Descripción")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaTalla As New DataColumn("Talla")
        ColumnaTalla.DataType = GetType(String)

        Dim ColumnaEstado As New DataColumn("Estado")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaAño As New DataColumn("Año")
        ColumnaDescripcion.DataType = GetType(String)

        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaNumero)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaNumeroEnLote)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaLote)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaAtado)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaPar)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaDescripcion)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaTalla)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaEstado)
        dtTablaGridCodigosParesEscaneados.Columns.Add(ColumnaAño)

        grdLectura.DataSource = Nothing
        grdLectura.DataSource = dtTablaGridCodigosParesEscaneados
        grdLectura.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdLectura.DisplayLayout.Override.RowSelectorWidth = 45
    End Sub


    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        Dim NaveID As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            LimpiarVariables()
            If ValidarCamposVacios() = True Then
                Return
            End If
            IdNave = cmbNaves.SelectedValue
            NaveID = IdNave
            EntSalidaNave.TipoProceso = cmbProceso.Text
            EntSalidaNave.NaveSICYID = cmbNaves.SelectedValue
            cboxAlmacen.Enabled = False
            cboxNaveAlmacen.Enabled = False

            If NaveID > 0 Then

                If ObjBU.ValidaParesNave(NaveID) = False Then
                    pgrGenerarDatos.Show()
                    pgrGenerarDatos.Refresh()

                    If ObjBU.GeneraParesNave(NaveID) = False Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se genero la información, vuelva a intentar.")
                        Return
                    End If

                    pgrGenerarDatos.Hide()
                End If

                '' CAMBIOS (10/08/2024) - Se agrega una validación para la solución de los códigos de par con misma configuración de atado.
                ObjBU.LimpiarTablaParesErroneos(NaveID)

            End If


            EntSalidaNave.ConfiguracionNave = ObjBU.ObtenerInformacionNave(IdNave, cmbProceso.Text)
            If EntSalidaNave.ConfiguracionNave.SistemaSay = False And EntSalidaNave.TipoProceso = "SALIDA" Then
                Tools.Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No es posible darle salida a una nave del tipo 'Maquiladora'")
                Return
            End If

            If EntSalidaNave.TipoProceso = "SALIDA" Then
                EntSalidaNave.IdSalidaNave = ValidarSalidasPendientes(EntSalidaNave.NaveSICYID)
                EntSalidaNave.NaveSICYID = EntSalidaNave.NaveSICYID

                If EntSalidaNave.IdSalidaNave > 0 Then
                    Tools.Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Existe un proceso de salida de lotes pendiente para esta nave, por favor terminelo para poder iniciar uno nuevo.")
                    ListaLotesPiloto = ObjBU.ObtenerLotesPilotoFolio(EntSalidaNave.IdSalidaNave)
                    '    ListaLotesPiloto.Add(1744)
                    RecuperarInformacionSalidaPendiente(EntSalidaNave.IdSalidaNave, EntSalidaNave.TipoProceso)
                    'RecuperarInformacionSalidaEnProceso()
                    lblFolio.Text = EntSalidaNave.IdSalidaNave.ToString()

                End If
                DeshabilitarBotonesInicioLectura()


            ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then

                IniciarProcesoEntrada()



            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString)
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub IniciarProcesoEntrada()
        Dim forma_IngresarFolio As New IngresarNumeroFolioEntradaForm
        Dim Nave_Valida As Boolean

        Try
            btnPlataformas.Visible = True
            lblPlataformas.Visible = True

            If EntSalidaNave.ConfiguracionNave.SistemaSay = True Then 'INDICA QUE EL TIPO DE NAVE ES NORMAL Y QUE SEGURAMENTE EXISTE UNA SALIDA DE NAVE EN ESTADO DE EMBARCADO
                forma_IngresarFolio.IdNave = IdNave
                forma_IngresarFolio.ComercilizadoraId = cboxNaveAlmacen.SelectedValue
                forma_IngresarFolio.StartPosition = FormStartPosition.CenterScreen
                forma_IngresarFolio.ShowDialog()
                If forma_IngresarFolio.DialogResult = DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    EntSalidaNave.IdSalidaNave = forma_IngresarFolio.folio
                    EntSalidaNave.StatusFolioID = forma_IngresarFolio.EstadoFolioSalidaNaveID
                    Nave_Valida = forma_IngresarFolio.Nave_Valida
                    lblFolio.Text = EntSalidaNave.IdSalidaNave.ToString()

                    ' 186 => En PROCESO, 189 => ENTREGAGO
                    If Nave_Valida = False Or EntSalidaNave.StatusFolioID = 189 Or EntSalidaNave.StatusFolioID = 186 Then
                        btnIniciar.Enabled = True
                        btnCodigosConErrores.Enabled = False
                        txtcapturacodigos.Enabled = False
                        btnDetener.Enabled = False
                        cmbOperador.Enabled = True
                        cmbProceso.Enabled = True
                        cmbNaves.Enabled = True
                        btnGuardar.Enabled = False
                        btnSalir.Enabled = True
                        ControlBox = True

                        cboxNaveAlmacen.Enabled = False
                        cboxAlmacen.Enabled = False

                        Me.Cursor = Cursors.Default
                        Return
                    Else

                        If EntSalidaNave.StatusFolioID = 187 Then ' 187 => Estatus EMBARCADO
                            ObjBU.ActualizarStatusFolioIngresando(EntSalidaNave.IdSalidaNave)
                        End If

                        'RecuperarInformacionSalidaPendiente(EntSalidaNave.IdSalidaNave)
                        RecuperarInformacionEntradaPendiente(EntSalidaNave.IdSalidaNave, EntSalidaNave.TipoProceso, cboxAlmacen.Text)

                        'ListaAtadosPendientes = ObjBU.RecuperarAtadosFolioEntrada(EntSalidaNave.IdSalidaNave)
                        'dtAtadosALeer = ObjBU.RecuperarAtadosFolioEntradaDataTable(EntSalidaNave.IdSalidaNave)
                        'txtcapturacodigos.Text = ""
                        'txtcapturacodigos.Focus()
                        'CargarAtadosPendientes()
                        'ActualizarGridPares()
                        'CargarResumenPares()

                        DeshabilitarBotonesInicioLectura()
                    End If
                End If
            Else
                EntSalidaNave.IdSalidaNave = ObjBU.ValidarEntradaPendienteNave(EntSalidaNave.NaveSICYID, cboxNaveAlmacen.SelectedValue) ' OAMB CAMBIOS (17-08-2023) Agregamos la comercializadora al SP que verifica los folios pendientes.
                If EntSalidaNave.IdSalidaNave > 0 Then 'Tiene entrada pendiente
                    EntSalidaNave.StatusFolioID = 188 'Status Ingresando
                    RecuperarInformacionEntradaPendiente(EntSalidaNave.IdSalidaNave, EntSalidaNave.TipoProceso, cboxAlmacen.Text)
                Else
                    EntSalidaNave.IdSalidaNave = ObjBU.InsertarFolioEntradaNaveMaquila(EntSalidaNave.NaveSICYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cboxNaveAlmacen.SelectedValue)   ' OAMB CAMBIOS (17-08-2023) Agregamos la comercializadora al SP que genera las salidas de naves.
                End If

                DeshabilitarBotonesInicioLectura()
            End If

            lblCodigoOculto.Focus()

        Catch ex As Exception
            Throw ex
        End Try


    End Sub

    Private Sub RecuperarInformacionSalidaPendiente(ByVal IdFolioSalida As Integer, ByVal TipoProceso As String)
        Dim EntAtadoAux As Entidades.CapturaAtadoValido
        Dim EntAtadoLeido As Entidades.CapturaAtadoValido
        Dim EntPArAux As Entidades.CapturaParValido
        Dim EntParLeido As Entidades.CapturaParValido
        Dim ListaAtadosErroneos As New List(Of Entidades.CapturaAtadoValido)
        Try
            dtAtadosALeer = ObjBU.RecuperarAtadosFolioSalida(IdFolioSalida, TipoProceso, 0)
            dtParesALeer = ObjBU.RecuperarParesFolioSalida(IdFolioSalida, 0)

            For Each Fila As DataRow In dtAtadosALeer.Rows
                EntAtadoAux = New Entidades.CapturaAtadoValido

                With EntAtadoAux
                    .PIdAtado = Fila.Item("Atado").ToString.Trim
                    .PAño = Fila.Item("Año").ToString.Trim
                    .PDescripcion = Fila.Item("Descripcion").ToString.Trim
                    .PIdCliente = Fila.Item("ClienteSICYID").ToString.Trim
                    .PIdNAve = Fila.Item("NaveSICYID").ToString.Trim
                    .PLote = Fila.Item("Lote").ToString.Trim
                    '.PN_AtadoEscaneado = Fila.Item("Atado").ToString.Trim
                    .PN_Pares = Fila.Item("ParesAtado").ToString.Trim
                    .Pn_ParesLeidos = 0 'Atado.Item("ParesLeidos").ToString.Trim
                    If EntSalidaNave.TipoProceso = "SALIDA" Then
                        .PStatusAtado = Fila.Item("ResultadoAtadoSalida").ToString.Trim
                    ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                        .PStatusAtado = Fila.Item("ResultadoAtadoEntrada").ToString.Trim
                    End If
                    .PValidacionEntradaPorPar = CBool(Fila.Item("ValidaEntradaPorPar").ToString.Trim)
                    .PValidacionSalidaPorPar = CBool(Fila.Item("ValidaSalidaPorPar").ToString.Trim)
                    .PLecturaPorCodigoCliente = CBool(Fila.Item("LecturaPorCodigoCliente").ToString.Trim)
                    .PNumeroAtado = Fila.Item("NumeroAtado")
                    .PTipoLectura = Fila.Item("TipoCodigo")
                End With

                EntSalidaNave.Atados.Add(EntAtadoAux)

                If Fila.Item("ResultadoAtadoSalida").ToString.Trim <> "0" Then
                    EntAtadoLeido = New Entidades.CapturaAtadoValido
                    With EntAtadoLeido
                        .PIdAtado = Fila.Item("Atado").ToString.Trim
                        .PAño = Fila.Item("Año").ToString.Trim
                        .PDescripcion = Fila.Item("Descripcion").ToString.Trim
                        .PIdCliente = Fila.Item("ClienteSICYID").ToString.Trim
                        .PIdNAve = Fila.Item("NaveSICYID").ToString.Trim
                        .PLote = Fila.Item("Lote").ToString.Trim
                        '.PN_AtadoEscaneado = Fila.Item("Atado").ToString.Trim
                        .PN_Pares = Fila.Item("ParesAtado").ToString.Trim
                        .Pn_ParesLeidos = 0 'Atado.Item("ParesLeidos").ToString.Trim
                        '.PStatusAtado = Fila.Item("ResultadoAtadoSalida").ToString.Trim
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            .PStatusAtado = Fila.Item("ResultadoAtadoSalida").ToString.Trim
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            .PStatusAtado = Fila.Item("ResultadoAtadoEntrada").ToString.Trim
                        End If
                        .PValidacionEntradaPorPar = CBool(Fila.Item("ValidaEntradaPorPar").ToString.Trim)
                        .PValidacionSalidaPorPar = CBool(Fila.Item("ValidaSalidaPorPar").ToString.Trim)
                        .PLecturaPorCodigoCliente = CBool(Fila.Item("LecturaPorCodigoCliente").ToString.Trim)
                        .PNumeroAtado = Fila.Item("NumeroAtado")
                        .PTipoLectura = Fila.Item("TipoCodigo")
                    End With

                    ListaDatosAtado.Add(EntAtadoLeido)
                End If

            Next

            ListaAtadosPendientes = EntSalidaNave.Atados
            EntSalidaNave.LotesFolio = ObjBU.RecuperarLotesFolioSalida(IdFolioSalida, EntSalidaNave.TipoProceso)

            For Each Fila As DataRow In dtParesALeer.Rows
                EntPArAux = New Entidades.CapturaParValido
                EntParLeido = New Entidades.CapturaParValido

                If Fila.Item("ResultadoParSalida").ToString = "1" Then
                    With EntPArAux
                        .Atado = Fila.Item("Atado").ToString
                        .NaveSICYID = Fila.Item("NaveSICYID").ToString
                        .Año = Fila.Item("Año").ToString
                        .Lote = Fila.Item("Lote").ToString
                        .ClienteSICYID = Fila.Item("ClienteSICYID").ToString
                        '.Fecha = Par.Item("Fecha").ToString
                        .Par = Fila.Item("Par").ToString
                        .CodigoPorLeer = Fila.Item("CodigoPorLeer").ToString
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            .Status = Fila.Item("ResultadoParSalida").ToString
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            .Status = Fila.Item("ResultadoParEntrada").ToString
                        End If
                        .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        .DescripcionCompleta = Fila.Item("DescripcionCompleta")
                    End With

                    EntSalidaNave.Pares.Add(EntPArAux)

                End If

                If EntPArAux.Status <> 0 Then
                    With EntParLeido
                        .Atado = Fila.Item("Atado").ToString
                        .NaveSICYID = Fila.Item("NaveSICYID").ToString
                        .Año = Fila.Item("Año").ToString
                        .Lote = Fila.Item("Lote").ToString
                        .ClienteSICYID = Fila.Item("ClienteSICYID").ToString
                        '.Fecha = Par.Item("Fecha").ToString
                        .Par = Fila.Item("Par").ToString
                        .CodigoPorLeer = Fila.Item("CodigoPorLeer").ToString
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            .Status = Fila.Item("ResultadoParSalida").ToString
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            .Status = Fila.Item("ResultadoParEntrada").ToString
                        End If
                        .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        .DescripcionCompleta = Fila.Item("DescripcionCompleta")
                    End With

                    ListaPares.Add(EntPArAux)
                End If

            Next

            '-txtcapturacodigos.Focus()
            lblCodigoOculto.Focus()
            ActualizarGridPares()
            CargarAtadosPendientes()
            CargarResumenPares()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub RecuperarInformacionEntradaPendiente(ByVal IdFolioSalida As Integer, ByVal TipoProceso As String, ByVal AlmacenId As Integer)
        Dim EntAtadoAux As Entidades.CapturaAtadoValido
        Dim EntAtadoLeido As Entidades.CapturaAtadoValido
        Dim EntPArAux As Entidades.CapturaParValido
        Dim EntParLeido As Entidades.CapturaParValido
        Dim DtParesDescartados As New DataTable
        Dim ListaAtadosErroneos As New List(Of Entidades.CapturaAtadoValido)
        Try
            dtAtadosALeer = ObjBU.RecuperarAtadosFolioSalida(IdFolioSalida, TipoProceso, AlmacenId)
            dtParesALeer = ObjBU.RecuperarParesFolioSalida(IdFolioSalida, AlmacenId)
            DtParesDescartados = ObjBU.ObtenerParesDescartados(IdFolioSalida, AlmacenId)

            For Each Fila As DataRow In DtParesDescartados.Rows
                ListaParesDescartados.Add(Fila.Item("CodigoPar").ToString)
            Next

            Dim ListaAtados = DtParesDescartados.AsEnumerable().Select(Function(X) X.Item("Atado")).Distinct.ToList
            For Each Fila As String In ListaAtados
                ListaAtadosDescartados.Add(Fila.ToString)
            Next

            Dim ListaLotesAux = DtParesDescartados.AsEnumerable().Select(Function(X) X.Item("Lote")).Distinct.ToList
            For Each Fila As String In ListaLotesAux
                LotesDescartados.Add(Fila.ToString)
            Next

            For Each Fila As DataRow In dtAtadosALeer.Rows
                EntAtadoAux = New Entidades.CapturaAtadoValido

                With EntAtadoAux
                    .PIdAtado = Fila.Item("Atado").ToString.Trim
                    .PAño = Fila.Item("Año").ToString.Trim
                    .PDescripcion = Fila.Item("Descripcion").ToString.Trim
                    .PIdCliente = Fila.Item("ClienteSICYID").ToString.Trim
                    .PIdNAve = Fila.Item("NaveSICYID").ToString.Trim
                    .PLote = Fila.Item("Lote").ToString.Trim
                    '.PN_AtadoEscaneado = Fila.Item("Atado").ToString.Trim
                    .PN_Pares = Fila.Item("ParesAtado").ToString.Trim
                    .Pn_ParesLeidos = 0 'Atado.Item("ParesLeidos").ToString.Trim
                    If EntSalidaNave.TipoProceso = "SALIDA" Then
                        .PStatusAtado = Fila.Item("ResultadoAtadoSalida").ToString.Trim
                    ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                        .PStatusAtado = Fila.Item("ResultadoAtadoEntrada").ToString.Trim
                    End If
                    .PValidacionEntradaPorPar = CBool(Fila.Item("ValidaEntradaPorPar").ToString.Trim)
                    .PValidacionSalidaPorPar = CBool(Fila.Item("ValidaSalidaPorPar").ToString.Trim)
                    .PLecturaPorCodigoCliente = CBool(Fila.Item("LecturaPorCodigoCliente").ToString.Trim)
                    .PIdCarrito = Fila.Item("CarritoID")
                    .PNumeroAtado = Fila.Item("NumeroAtado")
                    .PTipoLectura = Fila.Item("TipoCodigo")
                End With

                If EntAtadoAux.PStatusAtado.ToString = "1" Then
                    EntSalidaNave.Atados.Add(EntAtadoAux)
                End If

                ListaAtadosPendientes.Add(EntAtadoAux)




                If Fila.Item("ResultadoAtadoEntrada").ToString.Trim <> "0" Then
                    EntAtadoLeido = New Entidades.CapturaAtadoValido
                    With EntAtadoLeido
                        .PIdAtado = Fila.Item("Atado").ToString.Trim
                        .PAño = Fila.Item("Año").ToString.Trim
                        .PDescripcion = Fila.Item("Descripcion").ToString.Trim
                        .PIdCliente = Fila.Item("ClienteSICYID").ToString.Trim
                        .PIdNAve = Fila.Item("NaveSICYID").ToString.Trim
                        .PLote = Fila.Item("Lote").ToString.Trim
                        '.PN_AtadoEscaneado = Fila.Item("Atado").ToString.Trim
                        .PN_Pares = Fila.Item("ParesAtado").ToString.Trim
                        .Pn_ParesLeidos = 0 'Atado.Item("ParesLeidos").ToString.Trim
                        '.PStatusAtado = Fila.Item("ResultadoAtadoSalida").ToString.Trim
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            .PStatusAtado = Fila.Item("ResultadoAtadoSalida").ToString.Trim
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            .PStatusAtado = Fila.Item("ResultadoAtadoEntrada").ToString.Trim
                        End If
                        .PValidacionEntradaPorPar = CBool(Fila.Item("ValidaEntradaPorPar").ToString.Trim)
                        .PValidacionSalidaPorPar = CBool(Fila.Item("ValidaSalidaPorPar").ToString.Trim)
                        .PLecturaPorCodigoCliente = CBool(Fila.Item("LecturaPorCodigoCliente").ToString.Trim)
                        .PIdCarrito = Fila.Item("CarritoID")
                        .PNumeroAtado = Fila.Item("NumeroAtado")
                        .PTipoLectura = Fila.Item("TipoCodigo")
                    End With

                    ListaDatosAtado.Add(EntAtadoLeido)
                End If

            Next

            '            ListaAtadosPendientes = EntSalidaNave.Atados
            EntSalidaNave.LotesFolio = ObjBU.RecuperarLotesFolioSalida(IdFolioSalida, EntSalidaNave.TipoProceso)

            ListaAtadosErroneos = ObjBU.ConsultaAtadosErroneos(IdFolioSalida)

            For Each Fila As Entidades.CapturaAtadoValido In ListaAtadosErroneos
                ListaAtadosPendientes.Add(Fila)
            Next

            For Each Fila As DataRow In dtParesALeer.Rows
                EntPArAux = New Entidades.CapturaParValido
                EntParLeido = New Entidades.CapturaParValido

                If Fila.Item("ResultadoParEntrada").ToString = "1" Then
                    With EntPArAux
                        .Atado = Fila.Item("Atado").ToString
                        .NaveSICYID = Fila.Item("NaveSICYID").ToString
                        .Año = Fila.Item("Año").ToString
                        .Lote = Fila.Item("Lote").ToString
                        .ClienteSICYID = Fila.Item("ClienteSICYID").ToString
                        '.Fecha = Par.Item("Fecha").ToString
                        .Par = Fila.Item("Par").ToString
                        .CodigoPorLeer = Fila.Item("CodigoPorLeer").ToString
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            .Status = Fila.Item("ResultadoParSalida").ToString
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            .Status = Fila.Item("ResultadoParEntrada").ToString
                        End If
                        .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        .DescripcionCompleta = Fila.Item("DescripcionCompleta")
                    End With

                    EntSalidaNave.Pares.Add(EntPArAux)

                End If

                If EntPArAux.Status <> 0 Then
                    With EntParLeido
                        .Atado = Fila.Item("Atado").ToString
                        .NaveSICYID = Fila.Item("NaveSICYID").ToString
                        .Año = Fila.Item("Año").ToString
                        .Lote = Fila.Item("Lote").ToString
                        .ClienteSICYID = Fila.Item("ClienteSICYID").ToString
                        '.Fecha = Par.Item("Fecha").ToString
                        .Par = Fila.Item("Par").ToString
                        .CodigoPorLeer = Fila.Item("CodigoPorLeer").ToString
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            .Status = Fila.Item("ResultadoParSalida").ToString
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            .Status = Fila.Item("ResultadoParEntrada").ToString
                        End If
                        .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        .DescripcionCompleta = Fila.Item("DescripcionCompleta")
                    End With

                    ListaPares.Add(EntPArAux)
                End If

            Next

            'RECUPERAR PLATAFORMAS FOLIO
            EntSalidaNave.ListaPlataformas = ObjBU.ObtenerPlataformasFolio(IdFolioSalida)
            For Each Fila As Entidades.PlataformaEntrada In EntSalidaNave.ListaPlataformas
                Dim PlataformaAtados = ListaDatosAtado.Where(Function(x) x.PIdCarrito = Fila.IdPlataforma)
                For Each AtadoAux As Entidades.CapturaAtadoValido In PlataformaAtados
                    Fila.ListaAtados.Add(AtadoAux)
                Next
            Next

            lblCodigoOculto.Focus()
            ActualizarGridPares()
            CargarAtadosPendientes()
            CargarResumenPares()

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub DeshabilitarBotonesInicioLectura()
        btnIniciar.Enabled = False
        btnCodigosConErrores.Enabled = True
        txtcapturacodigos.Enabled = False
        lblCodigoOculto.Focus()
        'txtcapturacodigos.Enabled = True
        'txtcapturacodigos.Select()

        btnDetener.Enabled = True
        cmbOperador.Enabled = False
        cmbNaves.Enabled = False
        cmbProceso.Enabled = False
        btnGuardar.Enabled = False
        btnSalir.Enabled = False
        ControlBox = False
        btnDescartarLotes.Enabled = False
        btnImprimirReporte.Enabled = False

    End Sub

    Private Function ValidarCamposVacios() As Boolean
        Dim campos_vacios As Boolean = False

        If cmbProceso.Text = "" Then
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione una nave y el tipo de proceso para poder comenzar a escanear")
            campos_vacios = True
            lblTipo.ForeColor = Color.Red
            lblNave.ForeColor = Color.Red
        ElseIf cmbNaves.Text = "" Then
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione una nave para poder comenzar a escanear")
            campos_vacios = True
            lblTipo.ForeColor = Color.Black
            lblNave.ForeColor = Color.Red
            campos_vacios = True
        ElseIf cmbProceso.Text = "" Then
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione un proceso para poder comenzar a escanear")
            campos_vacios = True
            lblTipo.ForeColor = Color.Red
            lblNave.ForeColor = Color.Black
        Else
            lblTipo.ForeColor = Color.Black
            lblNave.ForeColor = Color.Black
            campos_vacios = False
        End If

        Return campos_vacios
    End Function

    Public Function ValidarSalidasPendientes(ByVal NaveSICYId As Integer) As Integer
        Dim IdSalidaNave As Integer = 0
        IdSalidaNave = ObjBU.ValidarSalidaPendienteNave(NaveSICYId)
        Return IdSalidaNave
    End Function


    'Private Sub btnIniciar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnIniciar.KeyPress
    '    Dim CadenaCapturada As String = String.Empty
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        If (LTrim(RTrim(txtcapturacodigos.Text))) = "" Then Return
    '        CadenaCapturada = (LTrim(RTrim(txtcapturacodigos.Text))).Replace("'", "-")
    '        If EntConfiguracionNave.TipoProceso = "SALIDA" Then
    '            CapturaParAtadosYuyin(CadenaCapturada)
    '        Else
    '            'CapturarParAtados_EntradaNave(CadenaCapturada)
    '        End If
    '        txtcapturacodigos.Text = ""
    '        txtcapturacodigos.Focus()
    '    End If
    'End Sub

    Private Function ValidaAtado(ByVal CodigoLeido As String) As Boolean
        Dim DatosAtadoAux As New Entidades.CapturaAtadoValido
        Dim AtadoValido As Boolean = False

        Try
            If CodigoLeido.Length >= 10 And CodigoLeido.Length <= 13 And IsNumeric(CodigoLeido) Then
                DatosAtadoAux = ValidarAtado(CodigoLeido)
                DatosAtado = DatosAtadoAux
                If DatosAtadoAux.PIdAtado = 0 Then 'Atado Invalido
                    'dtCodigosErroneos.Rows.Add(DatosLote.Lote, "", CodigoLeido, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, "El codigo no es un codigo de atado", Date.Now.ToLongDateString(), "", "")
                    RegistrarError(EntSalidaNave.IdSalidaNave, CodigoLeido, "", DatosLote.Lote, DatosLote.Año, DatosLote.NaveSICYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, "Entrada", "El codigo no es un codigo de atado")
                    AtadoValido = False
                Else
                    If DatosAtadoAux.PIdNAve = EntSalidaNave.NaveSICYID Then
                        If EntSalidaNave.Atados.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).Count = 0 Then
                            EntSalidaNave.Atados.Add(DatosAtadoAux)
                        End If

                        If ListaDatosAtado.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).Count = 0 Then
                            ListaDatosAtado.Add(DatosAtado)
                        Else
                            Dim AtadoAux = ListaDatosAtado.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                            If AtadoAux.PStatusAtado <> ResultadosEscaneo.CORRECTO Then
                                'AtadoAux.PStatusAtado = ResultadosEscaneo.CORRECTO
                                'DatosAtado.PStatusAtado = ResultadosEscaneo.CORRECTO

                                AtadoAux.PStatusAtado = ResultadosEscaneo.FALTANTE
                                DatosAtado.PStatusAtado = ResultadosEscaneo.FALTANTE

                            End If
                        End If
                        AtadoValido = True
                    Else
                        '                        dtCodigosErroneos.Rows.Add(DatosLote.Lote, "", CodigoLeido, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, "El codigo no es un codigo de atado", Date.Now.ToLongDateString(), "", "")
                        'dtCodigosErroneos.Rows.Add("0", "0", "0", "0", "El codigo no es un codigo de atado", "0", "0", "0")
                        InsertarAtadoInvalido(CodigoLeido)
                        RegistrarError(EntSalidaNave.IdSalidaNave, CodigoLeido, "", DatosLote.Lote, DatosLote.Año, DatosLote.NaveSICYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, "Entrada", "El codigo no es un codigo de atado")
                        AtadoValido = False
                    End If
                End If
            Else
                DatosAtado.PIdAtado = 0
                AtadoValido = False
            End If

            If AtadoValido = False Then
                ReproducrirSonidoError()
            End If

            If AtadoValido = True Then
                If DatosAtado.PStatusAtado <> ResultadosEscaneo.CORRECTO Then
                    'si el atado no esta correcto se borran los pares para volver a realizar la validacion
                    If EntSalidaNave.Atados.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 1).Count = 1 Then
                        Dim ParesABorrar = ListaPares.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count

                        For index As Integer = 1 To ParesABorrar
                            Dim index_borrar = ListaPares.FindIndex(Function(x) x.Atado = DatosAtado.PIdAtado)
                            ListaPares.RemoveAt(index_borrar)
                        Next
                    End If

                    LimpiarCodigoErroneo(DatosAtado.PIdAtado)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return AtadoValido

    End Function


    Private Function ValidarAtado(ByVal CodigoLeido As String) As Entidades.CapturaAtadoValido
        Dim DatosAtadoAux As New Entidades.CapturaAtadoValido
        Dim StatusId As Integer = 0

        Try
            If EntSalidaNave.Atados.Count() = 0 Then
                DatosAtadoAux = ObjBU.ValidarAtado(CodigoLeido)
            Else
                If dtAtadosALeer.AsEnumerable().Where(Function(x) x.Item("Atado").ToString.Trim() = CodigoLeido).Count = 1 Then
                    Dim Atado = dtAtadosALeer.AsEnumerable.Where(Function(x) x.Item("Atado").ToString.Trim() = CodigoLeido).FirstOrDefault

                    If ListaAtadosPendientes.Where(Function(x) x.PIdAtado = CodigoLeido And x.PStatusAtado <> 0).Count = 1 Then
                        Dim AtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = CodigoLeido).FirstOrDefault
                        StatusId = AtadoAux.PStatusAtado
                    Else
                        StatusId = ResultadosEscaneo.FALTANTE
                    End If

                    With DatosAtadoAux
                        .PIdAtado = Atado.Item("Atado").ToString.Trim
                        .PAño = Atado.Item("Año").ToString.Trim
                        .PDescripcion = Atado.Item("Descripcion").ToString.Trim
                        .PIdCliente = Atado.Item("ClienteSICYID").ToString.Trim
                        .PIdNAve = Atado.Item("NaveSICYID").ToString.Trim
                        .PLote = Atado.Item("Lote").ToString.Trim
                        .PNumeroAtado = Atado.Item("NumeroAtado").ToString.Trim
                        .PN_Pares = Atado.Item("ParesAtado").ToString.Trim
                        .Pn_ParesLeidos = 0 'Atado.Item("ParesLeidos").ToString.Trim
                        .PStatusAtado = StatusId 'ResultadosEscaneo.FALTANTE 'Atado.Item("StatusAtado").ToString.Trim
                        .PValidacionEntradaPorPar = CBool(Atado.Item("ValidaEntradaPorPar").ToString.Trim)
                        .PValidacionSalidaPorPar = CBool(Atado.Item("ValidaSalidaPorPar").ToString.Trim)
                        .PLecturaPorCodigoCliente = CBool(Atado.Item("LecturaPorCodigoCliente").ToString.Trim)
                        .PTipoLectura = Atado.Item("TipoCodigo")
                    End With
                Else
                    DatosAtadoAux = ObjBU.ValidarAtado(CodigoLeido)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return DatosAtadoAux
    End Function

    'AtadoValido.PIdAtado = row.Item("Atado")
    '               AtadoValido.PIdNAve = row.Item("Nave")
    '               AtadoValido.PLote = row.Item("Lote")
    '               AtadoValido.PAño = row.Item("Año")
    '               AtadoValido.PN_Pares = row.Item("n_Pares")
    '               AtadoValido.PDescripcion = row.Item("Descripción")
    '               AtadoValido.PIdCliente = row.Item("IdCliente")
    '               AtadoValido.PN_AtadoEscaneado = row.Item("No_Atado")
    Private Function InsertarInformacionLote(ByVal CodigoLeido As String) As Boolean
        Dim LoteValido As Boolean = False
        Dim dtResultado As New DataTable
        Dim dtLote As New DataTable
        Dim Mensaje As String = ""
        Dim ConfirmacionPorPar As Boolean = False
        Dim EsLotePiloto As Boolean = False
        Dim LoteEscaneado As String = String.Empty

        If DatosAtado.PIdAtado <> "0" Then
            If EntSalidaNave.IdSalidaNave = 0 Then
                EntSalidaNave.IdSalidaNave = ObjBU.InsertarFolioSalida(DatosAtado.PIdNAve, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                lblFolio.Text = EntSalidaNave.IdSalidaNave.ToString()
            End If

            If (EntSalidaNave.LotesFolio.Where(Function(x) x.Lote = DatosAtado.PLote And x.NaveSICYID = DatosAtado.PIdNAve).Count = 0 And (EntSalidaNave.TipoProceso = "SALIDA" Or (EntSalidaNave.TipoProceso = "ENTRADA" And EntSalidaNave.ConfiguracionNave.Maquila = True))) Then
                dtResultado = ObjBU.InsertarInformacionDelLote(DatosAtado.PIdAtado, DatosAtado.PIdNAve, EntSalidaNave.ConfiguracionNave.Maquila, EntSalidaNave.IdSalidaNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Mensaje = dtResultado.Rows(0).Item(0)
                If IsDBNull(dtResultado.Rows(0).Item(1)) Then
                    EsLotePiloto = 0
                Else
                    EsLotePiloto = CBool(dtResultado.Rows(0).Item(1))
                End If

                LoteEscaneado = CInt(dtResultado.Rows(0).Item(2))

                If EsLotePiloto = True Then
                    ListaLotesPiloto.Add(LoteEscaneado)
                End If

            Else
                Mensaje = "EXITO"
            End If

            If Mensaje = "EXITO" Then
                If EntSalidaNave.IdSalidaNave > 0 Then

                    If EntSalidaNave.LotesFolio.Where(Function(x) x.Lote = DatosAtado.PLote).Count = 0 Then
                        dtLote = ObjBU.ObtenerInformacionLote(EntSalidaNave.IdSalidaNave, DatosAtado.PLote)
                        If dtLote.Rows.Count > 0 Then
                            ConfirmacionPorPar = ObjBU.ConfirmacionPorPar(DatosAtado.PLote, DatosAtado.PIdNAve, DatosAtado.PAño)
                            With DatosLote
                                .Lote = dtLote.Rows(0).Item("Lote")
                                .NaveSICYID = dtLote.Rows(0).Item("NaveSICYID")
                                .ParesLote = dtLote.Rows(0).Item("TotalPares")
                                .StatusLote = dtLote.Rows(0).Item("StatusLote")
                                .Año = dtLote.Rows(0).Item("Año")
                                .ConfirmacionPorPar = ConfirmacionPorPar
                            End With

                            EntSalidaNave.LotesFolio.Add(DatosLote)
                            RecuperarParesLotes()
                            RecuperarAtadosLotes()
                            LoteValido = True
                        Else
                            LoteValido = False
                        End If
                    Else
                        LoteValido = True
                    End If

                    'dtLote = ObjBU.ObtenerInformacionLote(EntSalidaNave.IdSalidaNave, DatosAtado.PLote)
                    'If dtLote.Rows.Count > 0 Then
                    '    ConfirmacionPorPar = ObjBU.ConfirmacionPorPar(DatosAtado.PLote, DatosAtado.PIdNAve, DatosAtado.PAño)
                    '    With DatosLote
                    '        .Lote = dtLote.Rows(0).Item("Lote")
                    '        .NaveSICYID = dtLote.Rows(0).Item("NaveSICYID")
                    '        .ParesLote = dtLote.Rows(0).Item("TotalPares")
                    '        .StatusLote = dtLote.Rows(0).Item("StatusLote")
                    '        .Año = dtLote.Rows(0).Item("Año")
                    '        .ConfirmacionPorPar = ConfirmacionPorPar
                    '    End With
                    '    LoteValido = True

                    '    If EntSalidaNave.LotesFolio.Where(Function(x) x.Lote = DatosLote.Lote).Count = 0 Then
                    '        EntSalidaNave.LotesFolio.Add(DatosLote)
                    '        RecuperarParesLotes()
                    '        RecuperarAtadosLotes()
                    '    End If
                    'Else
                    '    LoteValido = False
                    'End If
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, Mensaje)
                LoteValido = False
            End If
        End If

        If LoteValido = False Then
            RegistrarError(EntSalidaNave.IdSalidaNave, CodigoLeido, DatosAtado.PIdAtado, DatosLote.Lote, DatosLote.Año, EntSalidaNave.NaveSICYID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, EntSalidaNave.TipoProceso, Mensaje)
            'dtCodigosErroneos.Rows.Add(DatosLote.Lote, DatosAtado.PIdAtado, CodigoLeido, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Mensaje, Date.Now.ToLongDateString(), ResultadosEscaneo.MAL_FORMADO.ToString, ResultadosEscaneo.MAL_FORMADO)            
            ReproducrirSonidoError()
        End If

        Return LoteValido

    End Function

    Private Sub InicializarAtado()
        'With DatosAtado
        '    .PAño = 0
        '    .PIdAtado = 0
        '    .PDescripcion = ""
        '    .PIdCliente = 0
        '    .PIdNAve = 0
        '    .PLote = 0
        '    .PN_AtadoEscaneado = 0
        '    .PN_Pares = 0
        '    .Pn_ParesLeidos = 0
        '    .PStatusAtado = 0
        'End With
    End Sub

    Private Sub ObtenerParesAtado(ByVal IdAtado As String)
        Dim EntPar As Entidades.CapturaParValido

        Try
            Dim Pares = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado)

            For Each Fila As DataRow In Pares
                EntPar = New Entidades.CapturaParValido
                With EntPar
                    .Atado = Fila.Item("Atado").ToString
                    .NaveSICYID = Fila.Item("NaveSICYID").ToString
                    .Año = Fila.Item("Año").ToString
                    .Lote = Fila.Item("Lote").ToString
                    .ClienteSICYID = Fila.Item("ClienteSICYID").ToString
                    '.Fecha = Par.Item("Fecha").ToString
                    .Par = Fila.Item("Par").ToString
                    .CodigoPorLeer = Fila.Item("CodigoPorLeer").ToString
                    .Status = ResultadosEscaneo.CORRECTO
                    .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                End With
                ListaAtadosPares.Add(EntPar)
                ListaPares.Add(EntPar)
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function ValidarPar(ByVal CodigoEscaneado As String) As Boolean
        Dim par_valido As Boolean
        Dim EntPar As New Entidades.CapturaParValido
        Dim CodigoPorLeer As String = String.Empty
        Try

            Dim codigo_split = LTrim(RTrim(CodigoEscaneado)).Split("-") ''parte la cadena

            If DatosAtado.PLecturaPorCodigoCliente = True Then  ' Si el código leído es código de cliente entonces vamos a tomar el código escaneado sin dividirlo en tres partes. OAMB 23/11/2023
                CodigoPorLeer = CodigoEscaneado
            Else    ' Si el código leído no es de cliente entonces lo dividimos
                If codigo_split.Length = 3 Then
                    'Codigo de Par
                    CodigoPorLeer = codigo_split(2)
                Else
                    'Codigo de Cliente
                    CodigoPorLeer = CodigoEscaneado
                End If
            End If

            'If codigo_split.Length = 3 Then
            '    'Codigo de Par
            '    CodigoPorLeer = codigo_split(2)
            'Else
            '    'Codigo de Cliente
            '    CodigoPorLeer = CodigoEscaneado
            'End If

            If dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.TrimStart("0") = CodigoPorLeer).Count >= 1 And DatosAtado.PLecturaPorCodigoCliente = True Then

                Dim Par = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.TrimStart("0") = CodigoPorLeer).FirstOrDefault()
                With EntPar
                    .Atado = Par.Item("Atado").ToString
                    .NaveSICYID = Par.Item("NaveSICYID").ToString
                    .Año = Par.Item("Año").ToString
                    .Lote = Par.Item("Lote").ToString
                    .ClienteSICYID = Par.Item("ClienteSICYID").ToString
                    '.Fecha = Par.Item("Fecha").ToString
                    .Par = Par.Item("Par").ToString
                    .CodigoPorLeer = Par.Item("CodigoPorLeer").ToString
                    .Status = ResultadosEscaneo.CORRECTO
                    .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    .DescripcionCompleta = Par.Item("DescripcionCompleta")
                End With

                Dim CodigosClienteALeerAtado = dtParesALeer.AsEnumerable().Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.TrimStart("0") = CodigoEscaneado).Count
                Dim CodigosClienteLeidos As Integer = ListaAtadosPares.Where(Function(x) x.Atado = DatosAtado.PIdAtado And x.CodigoPorLeer.Trim = CodigoEscaneado).Count

                If CodigosClienteALeerAtado > CodigosClienteLeidos Then
                    par_valido = True
                Else
                    par_valido = False
                    ReproducrirSonidoError()
                    EntPar.Status = ResultadosEscaneo.MAL_FORMADO
                    RegistrarError(EntSalidaNave.IdSalidaNave, CodigoEscaneado, DatosAtado.PIdAtado, DatosLote.Lote, DatosLote.Año, DatosLote.NaveSICYID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, EntSalidaNave.TipoProceso, "Codigo Invalido")
                End If

                ListaAtadosPares.Add(EntPar)
                ListaPares.Add(EntPar)
            ElseIf dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.Trim = CodigoPorLeer).Count = 1 And DatosAtado.PLecturaPorCodigoCliente = False Then

                Dim Par = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.Trim = CodigoPorLeer).FirstOrDefault()
                With EntPar
                    .Atado = Par.Item("Atado").ToString
                    .NaveSICYID = Par.Item("NaveSICYID").ToString
                    .Año = Par.Item("Año").ToString
                    .Lote = Par.Item("Lote").ToString
                    .ClienteSICYID = Par.Item("ClienteSICYID").ToString
                    '.Fecha = Par.Item("Fecha").ToString
                    .Par = Par.Item("Par").ToString
                    .CodigoPorLeer = Par.Item("CodigoPorLeer").ToString
                    .Status = ResultadosEscaneo.CORRECTO
                    .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    .DescripcionCompleta = Par.Item("DescripcionCompleta")
                End With

                'Codigo de Yuyin
                If DatosAtado.PLecturaPorCodigoCliente = False Then
                    If ListaAtadosPares.Where(Function(x) x.Par = EntPar.Par).Count = 0 Then
                        ListaAtadosPares.Add(EntPar)
                        ListaPares.Add(EntPar)
                    End If
                End If

                par_valido = True
            Else
                ReproducrirSonidoError()
                par_valido = False
                If dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.TrimStart("0") = CodigoPorLeer).Count >= 1 And DatosAtado.PLecturaPorCodigoCliente = True Then
                    Dim Par = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado And x.Item("CodigoPorLeer").ToString.TrimStart("0") = CodigoPorLeer).FirstOrDefault()
                    With EntPar
                        .Atado = Par.Item("Atado").ToString
                        .NaveSICYID = Par.Item("NaveSICYID").ToString
                        .Año = Par.Item("Año").ToString
                        .Lote = Par.Item("Lote").ToString
                        .ClienteSICYID = Par.Item("ClienteSICYID").ToString
                        '.Fecha = Par.Item("Fecha").ToString
                        .Par = Par.Item("Par").ToString
                        .CodigoPorLeer = Par.Item("CodigoPorLeer").ToString
                        .Status = ResultadosEscaneo.MAL_FORMADO
                        .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        .DescripcionCompleta = Par.Item("DescripcionCompleta")
                    End With
                    ListaAtadosPares.Add(EntPar)
                    ListaPares.Add(EntPar)
                Else
                    With EntPar
                        .Atado = DatosAtado.PIdAtado
                        .NaveSICYID = DatosAtado.PIdNAve
                        .Año = DatosAtado.PAño
                        .Lote = DatosAtado.PLote
                        .ClienteSICYID = DatosAtado.PIdCliente
                        '.Fecha = Par.Item("Fecha").ToString
                        .Par = CodigoEscaneado
                        .CodigoPorLeer = CodigoEscaneado
                        .Status = ResultadosEscaneo.MAL_FORMADO
                        .NombreEstatus = ResultadosEscaneo.MAL_FORMADO.ToString
                        .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        .UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        .DescripcionCompleta = ""
                    End With
                End If
                ListaAtadosPares.Add(EntPar)
                ListaPares.Add(EntPar)
                RegistrarError(EntSalidaNave.IdSalidaNave, CodigoEscaneado, DatosAtado.PIdAtado, DatosLote.Lote, DatosLote.Año, DatosLote.NaveSICYID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, EntSalidaNave.TipoProceso, "Codigo Invalido")
                'dtCodigosErroneos.Rows.Add(DatosLote.Lote, DatosAtado.PIdAtado, CodigoEscaneado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, "El codigo no es un codigo de PAR o de Cliente.", Date.Now.ToLongDateString(), ResultadosEscaneo.MAL_FORMADO.ToString)
            End If


        Catch ex As Exception
            Throw ex
            par_valido = False
        End Try

        Return par_valido
    End Function

    Private Sub RecuperarParesLotes()
        Dim dtParesAux As DataTable
        Try
            If dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = DatosLote.Lote And x.Item("NaveSICYID") = DatosLote.NaveSICYID).Count = 0 Then
                dtParesAux = ObjBU.RecuperarParesFolio(EntSalidaNave.IdSalidaNave, DatosLote.Lote, DatosLote.NaveSICYID, DatosLote.Año)
                If dtParesALeer.Rows.Count = 0 Then
                    dtParesALeer = dtParesAux.Copy()
                Else
                    For Each row As DataRow In dtParesAux.Rows
                        dtParesALeer.ImportRow(row)
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CopiarDataTableAListaAtadosPendientes(ByVal dtPares As DataTable)
        Dim entAtadoPendiente As New Entidades.CapturaAtadoValido

        Try
            For Each fila As DataRow In dtPares.Rows
                entAtadoPendiente = New Entidades.CapturaAtadoValido

                With entAtadoPendiente
                    .PAño = fila.Item("Año")
                    .PLote = fila.Item("Lote")
                    .PDescripcion = fila.Item("Descripcion")
                    .PIdAtado = fila.Item("Atado")
                    .PIdCliente = fila.Item("ClienteSICYID")
                    .PIdNAve = fila.Item("NaveSICYID")
                    .PLecturaPorCodigoCliente = CBool(fila.Item("LecturaPorCodigoCliente"))
                    .PNumeroAtado = fila.Item("NumeroAtado")
                    .PN_Pares = fila.Item("ParesAtado")
                    .Pn_ParesLeidos = 0
                    .PStatusAtado = 0
                    .PValidacionEntradaPorPar = CBool(fila.Item("ValidaEntradaPorPar"))
                    .PValidacionSalidaPorPar = CBool(fila.Item("ValidaSalidaPorPar"))
                    .PTipoLectura = fila.Item("TipoCodigo")
                End With
                If ListaAtadosPendientes.Where(Function(x) x.PIdAtado = entAtadoPendiente.PIdAtado).Count = 0 Then
                    ListaAtadosPendientes.Add(entAtadoPendiente)
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub RecuperarAtadosLotes()
        Dim dtAtadosALeerAux As DataTable
        Try
            If dtAtadosALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = DatosLote.Lote And x.Item("NaveSICYID") = DatosLote.NaveSICYID).Count = 0 Then
                dtAtadosALeerAux = ObjBU.RecuperarAtadosFolio(EntSalidaNave.IdSalidaNave, DatosLote.Lote, DatosLote.NaveSICYID, DatosLote.Año)
                If dtAtadosALeer.Rows.Count = 0 Then
                    dtAtadosALeer = dtAtadosALeerAux.Copy()
                    CopiarDataTableAListaAtadosPendientes(dtAtadosALeerAux)

                Else
                    For Each row As DataRow In dtAtadosALeerAux.Rows
                        dtAtadosALeer.ImportRow(row)
                    Next
                    CopiarDataTableAListaAtadosPendientes(dtAtadosALeerAux)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VerificarAtadoCompleto()
        Dim ParesLeidosAtado As Integer = 0
        Dim ParesAtado As Integer = 0
        Dim ParesCorrectos As Integer = 0

        Try
            If IsNothing(DatosAtado.PIdAtado) = False Then
                If grdIncorrecto.Rows.AsEnumerable.Where(Function(x) x.Cells("PIdAtado").Value.ToString.TrimStart("0") = DatosAtado.PIdAtado.TrimStart("0") And x.Cells("PNumeroAtado").Value.ToString = "0").Count = 0 Then

                    ParesLeidosAtado = ListaAtadosPares.Count
                    ParesAtado = dtParesALeer.AsEnumerable().Where(Function(x) x.Item("Atado") = DatosAtado.PIdAtado).Count

                    'Valida si el atado ya esta correcto
                    If ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 1).Count = 1 Then
                        If ParesLeidosAtado = ParesAtado Then
                            ParesCorrectos = ListaAtadosPares.Where(Function(x) x.Status = ResultadosEscaneo.CORRECTO).Count
                            If ParesCorrectos = ParesAtado Then
                                DatosAtado.PStatusAtado = ResultadosEscaneo.CORRECTO
                            Else
                                DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                                For Each Par As Entidades.CapturaParValido In ListaPares.Where(Function(x) x.Atado = DatosAtado.PIdAtado)
                                    Par.Status = ResultadosEscaneo.MAL_FORMADO
                                Next
                            End If
                        Else
                            If ParesLeidosAtado > ParesAtado Then
                                DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                            ElseIf ParesLeidosAtado < ParesAtado Then
                                DatosAtado.PStatusAtado = ResultadosEscaneo.FALTANTE_SIN_TERMINAR
                            Else
                                DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                            End If

                            For Each Par As Entidades.CapturaParValido In ListaPares.Where(Function(x) x.Atado = DatosAtado.PIdAtado)
                                Par.Status = DatosAtado.PStatusAtado
                            Next

                        End If


                        If DatosAtado.PStatusAtado = ResultadosEscaneo.CORRECTO Then
                            For Each Par As Entidades.CapturaParValido In ListaAtadosPares
                                EntSalidaNave.Pares.Add(Par)
                            Next
                            ListaAtadosPares.Clear()
                        End If

                        Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                        If IsNothing(EntAtadoAux) = False Then
                            EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                            EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                        End If

                        Dim entAtadosLeidos = ListaDatosAtado.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                        If IsNothing(entAtadosLeidos) = False Then
                            entAtadosLeidos.PStatusAtado = DatosAtado.PStatusAtado
                            entAtadosLeidos.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                        End If




                        'Actualiza Status Atado
                        If EntSalidaNave.TipoProceso = "SALIDA" Then
                            ObjBU.ActualizarStatusAtado(EntSalidaNave.IdSalidaNave, DatosAtado.PIdAtado, DatosAtado.PStatusAtado, DatosAtado.PLote)
                        ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                            ObjBU.ActualizaStatusAtadoEntrada(EntSalidaNave.IdSalidaNave, DatosAtado.PIdAtado, DatosAtado.PStatusAtado, DatosAtado.PLote, CarritoActal.IdPlataforma, cboxAlmacen.Text)
                        End If


                    End If

                End If
            End If




            ''Validar si el atado esta completo
            'If DatosAtado.PN_Pares = EntSalidaNave.Pares.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count Then
            '    DatosAtado.PStatusAtado = ResultadosEscaneo.CORRECTO
            'End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub VerificarLoteCompleto()
        Dim ParesLote As Integer = 0
        Dim ParesCorrectos As Integer = 0


        ParesLote = dtParesALeer.AsEnumerable().Where(Function(x) x.Item("Lote") = DatosLote.Lote And x.Item("NaveSICYID") = DatosLote.NaveSICYID).Count
        ParesCorrectos = EntSalidaNave.Pares.Where(Function(x) x.Lote = DatosLote.Lote And x.NaveSICYID = DatosLote.NaveSICYID).Count

        'Validar si el Lote Esta Completo
        If ParesLote = ParesCorrectos Then
            DatosLote.StatusLote = ResultadosEscaneo.CORRECTO
        End If

    End Sub
    Public Sub CapturaParAtadosYuyin(ByVal Cadena As String)
        Try
            Dim codigo_split = LTrim(RTrim(Cadena)).Split("-") ''parte la cadena

            If EntSalidaNave.Atados.Count = 0 Then
                If ValidaAtado(Cadena) = False Then
                    Return
                End If
                If DatosAtado.PIdAtado <> "0" Then
                    'Verifica si el lote se pudo insertar
                    If InsertarInformacionLote(Cadena) = False Then
                        InicializarAtado() 'Regresar el status del par
                        InsertarAtadoInvalido(Cadena)
                    Else
                        Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                        If IsNothing(EntAtadoAux) = False Then
                            EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                            EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                        End If

                        'RecuperarParesLotes()
                        'RecuperarAtadosLotes()

                        If DatosAtado.PValidacionSalidaPorPar = False Then
                            ObtenerParesAtado(DatosAtado.PIdAtado)
                        Else
                            ListaAtadosPares.Clear()
                        End If

                    End If

                End If
            Else

                If (DatosAtado.PIdAtado = 0 Or DatosAtado.PValidacionSalidaPorPar = False) Or ((Cadena.Length >= 10 And Cadena.Length <= 13 And IsNumeric(Cadena))) Then

                    If ObjBU.ValidarExisteAtado(Cadena, EntSalidaNave.NaveSICYID) = True Then '' OAMB CAMBIOS (04/07/2024)
                        VerificarAtadoCompleto()
                        VerificarLoteCompleto()

                        ListaAtadosPares.Clear()

                        If ValidaAtado(Cadena) = True Then
                            If DatosAtado.PIdAtado <> "0" Then
                                If InsertarInformacionLote(Cadena) = False Then
                                    InicializarAtado()
                                    InsertarAtadoInvalido(Cadena)
                                End If
                            ElseIf DatosAtado.PLote <> DatosLote.Lote Then
                                If InsertarInformacionLote(Cadena) = False Then
                                    InicializarAtado()
                                    InsertarAtadoInvalido(Cadena)
                                End If
                            End If

                            Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                            If IsNothing(EntAtadoAux) = False Then
                                EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                            End If

                            If DatosAtado.PValidacionSalidaPorPar = False Then
                                ObtenerParesAtado(DatosAtado.PIdAtado)
                            End If
                        Else

                        End If
                    Else
                        If ValidarPar(Cadena) = True Then
                        Else
                            DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                        End If
                    End If

                ElseIf (codigo_split.Length = 3) And DatosAtado.PLecturaPorCodigoCliente = False Then
                    If ValidarPar(Cadena) = True Then

                    Else
                        ' DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                    End If
                Else
                    If ValidarPar(Cadena) = True Then
                        ''Validar si el atado esta completo
                        'If DatosAtado.PN_Pares = EntSalidaNave.Pares.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count Then
                        '    DatosAtado.PStatusAtado = ResultadosEscaneo.CORRECTO
                        'End If

                        ''Validar si el Lote Esta Completo
                        'If DatosLote.ParesLote = EntSalidaNave.Pares.Where(Function(x) x.Lote = DatosLote.Lote).Count Then
                        '    DatosLote.StatusLote = ResultadosEscaneo.CORRECTO
                        'End If
                    Else
                        ' DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                    End If
                End If

            End If


        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Public Sub CapturaParAtadosYuyinEntrada(ByVal Cadena As String)
        Dim CarritoAux As String()
        Dim CarritoValido As Boolean = False
        'CarritoActal
        Try
            CarritoAux = Cadena.Split("-")

            If Cadena.Length >= 6 And Cadena.Length <= 8 And Not IsNumeric(Cadena) And Cadena.Contains("-") Then 'POSIBLE CODIGO DE CARRITO

                If CarritoAux.Length = 2 And CarritoAux(0) = "PLAT" Then
                    CarritoValido = ValidarCarritoPerteneciente_a_Nave(CInt(CarritoAux(1)), CInt(cboxNaveAlmacen.SelectedValue), (cboxAlmacen.SelectedValue))

                    If CarritoValido = False Then
                        ReproducrirSonidoError()
                        CarritoActal.IdPlataforma = 0
                        CarritoActal.Plataforma = ""
                        CarritoActal.ListaAtados.Clear()
                        Return
                    Else
                        'If AtadoActual <> "0" Then
                        '    ActualizarEstatusDeAtado()
                        '    AtadoActual = "0"
                        'End If

                        If EntSalidaNave.ListaPlataformas.Where(Function(x) x.IdPlataforma = CInt(CarritoAux(1))).Count = 0 Then
                            CarritoActal.IdPlataforma = CInt(CarritoAux(1))
                            CarritoActal.Plataforma = Cadena
                            EntSalidaNave.ListaPlataformas.Add(CarritoActal)
                            lblTotalCarritos.Text = EntSalidaNave.ListaPlataformas.Count.ToString("N0")
                        Else
                            Dim PlataformaAux = EntSalidaNave.ListaPlataformas.Where(Function(x) x.IdPlataforma = CInt(CarritoAux(1))).FirstOrDefault
                            CarritoActal = PlataformaAux
                        End If
                    End If
                End If
            Else
                If CarritoActal.IdPlataforma > 0 Then
                    If EntSalidaNave.Atados.Count = 0 Then
                        VerificarAtadoCompleto()
                        VerificarLoteCompleto()

                        If EntSalidaNave.ConfiguracionNave.Maquila = False Then

                            If ListaAtadosPendientes.Where(Function(x) x.PIdAtado = Cadena And x.PStatusAtado <> 11).Count = 0 Then
                                ReproducrirSonidoError()
                                InicializarAtado()
                                Dim AtadoLeido As New Entidades.CapturaAtadoValido
                                AtadoLeido = ValidarAtadoEntrada(Cadena)
                                If AtadoLeido.PIdAtado <> "0" Then
                                    AtadoLeido.PStatusAtado = 11
                                    ListaAtadosPendientes.Add(AtadoLeido)
                                    ObjBU.InsertarAtadoNoEmbarcado(EntSalidaNave.IdSalidaNave, AtadoLeido.PIdAtado, AtadoLeido.PAño, AtadoLeido.PDescripcion, AtadoLeido.PIdCliente, AtadoLeido.PIdNAve, AtadoLeido.PLote, AtadoLeido.PNumeroAtado, AtadoLeido.PN_Pares, AtadoLeido.PStatusAtado)
                                End If
                                Return
                            End If

                            ValidaAtado(Cadena)

                            Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 11).FirstOrDefault
                            If IsNothing(EntAtadoAux) = False Then
                                EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                            End If


                            If DatosAtado.PValidacionEntradaPorPar = False Then
                                ObtenerParesAtado(DatosAtado.PIdAtado)
                            Else
                                ListaAtadosPares.Clear()
                            End If

                            DatosLote = EntSalidaNave.LotesFolio.Where(Function(x) x.Lote = DatosAtado.PLote).FirstOrDefault
                        Else

                            If EntSalidaNave.ConfiguracionNave.Maquila = True Then

                                If ObjBU.ValidarExisteAtado(Cadena, EntSalidaNave.NaveSICYID) = True Then '' OAMB CAMBIOS (04/07/2024)
                                    VerificarAtadoCompleto()
                                    VerificarLoteCompleto()

                                    ListaAtadosPares.Clear()

                                    If ValidaAtado(Cadena) = True Then
                                        If DatosAtado.PIdAtado <> "0" Then
                                            If InsertarInformacionLote(Cadena) = False Then
                                                'InicializarAtado()
                                                InsertarAtadoInvalido(Cadena)
                                            End If
                                        ElseIf DatosAtado.PLote <> DatosLote.Lote Then
                                            If InsertarInformacionLote(Cadena) = False Then
                                                'InicializarAtado()
                                                InsertarAtadoInvalido(Cadena)
                                            End If
                                        End If

                                        Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 11).FirstOrDefault
                                        If IsNothing(EntAtadoAux) = False Then
                                            EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                            EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                                        End If


                                        If DatosAtado.PValidacionEntradaPorPar = False Then
                                            ObtenerParesAtado(DatosAtado.PIdAtado)
                                        End If

                                    Else

                                    End If
                                Else
                                    ValidarPar(Cadena)
                                End If

                                ''Verifica si el lote se pudo insertar
                                'If InsertarInformacionLote(Cadena) = False Then
                                '    InicializarAtado() 'Regresar el status del par
                                'Else
                                '    Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                                '    EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                '    EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                                '    'RecuperarParesLotes()
                                '    'RecuperarAtadosLotes()

                                '    If DatosAtado.PValidacionSalidaPorPar = False Then
                                '        ObtenerParesAtado(DatosAtado.PIdAtado)
                                '    Else
                                '        ListaAtadosPares.Clear()
                                '    End If

                                'End If
                            Else
                                If ListaAtadosPendientes.Where(Function(x) x.PIdAtado = Cadena And x.PStatusAtado <> 11).Count = 0 Then
                                    ReproducrirSonidoError()
                                    InicializarAtado()
                                    Dim AtadoLeido As New Entidades.CapturaAtadoValido
                                    AtadoLeido = ValidarAtadoEntrada(Cadena)
                                    If AtadoLeido.PIdAtado <> "0" Then
                                        AtadoLeido.PStatusAtado = 11
                                        ListaAtadosPendientes.Add(AtadoLeido)
                                        ObjBU.InsertarAtadoNoEmbarcado(EntSalidaNave.IdSalidaNave, AtadoLeido.PIdAtado, AtadoLeido.PAño, AtadoLeido.PDescripcion, AtadoLeido.PIdCliente, AtadoLeido.PIdNAve, AtadoLeido.PLote, AtadoLeido.PNumeroAtado, AtadoLeido.PN_Pares, AtadoLeido.PStatusAtado)
                                    End If
                                    Return
                                End If
                                ValidaAtado(Cadena)

                                Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 11).FirstOrDefault
                                If IsNothing(EntAtadoAux) = False Then
                                    EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                    EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                                End If


                                If DatosAtado.PValidacionEntradaPorPar = False Then
                                    ObtenerParesAtado(DatosAtado.PIdAtado)
                                Else
                                    ListaAtadosPares.Clear()
                                End If

                                DatosLote = EntSalidaNave.LotesFolio.Where(Function(x) x.Lote = DatosAtado.PLote).FirstOrDefault
                            End If

                        End If


                        'If DatosAtado.PIdAtado <> "0" Then
                        '    'Verifica si el lote se pudo insertar
                        '    If InsertarInformacionLote(Cadena) = False Then
                        '        InicializarAtado() 'Regresar el status del par
                        '    Else
                        '        Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                        '        EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                        '        EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                        '        'RecuperarParesLotes()
                        '        'RecuperarAtadosLotes()

                        '        If DatosAtado.PValidacionSalidaPorPar = False Then
                        '            ObtenerParesAtado(DatosAtado.PIdAtado)
                        '        Else
                        '            ListaAtadosPares.Clear()
                        '        End If

                        '    End If

                        'End If
                    Else
                        Dim AtadoValido As Boolean

                        If grdIncorrecto.Rows.AsEnumerable.Where(Function(x) x.Cells("PIdAtado").Value.ToString.TrimStart("0") = Cadena.TrimStart("0") And x.Cells("PNumeroAtado").Value.ToString = "0").Count = 1 Then
                            ReproducrirSonidoError()
                        Else
                            If (DatosAtado.PIdAtado = 0 Or DatosAtado.PValidacionEntradaPorPar = False Or EntSalidaNave.ConfiguracionNave.Maquila = True) Or ((Cadena.Length >= 10 And Cadena.Length <= 13 And IsNumeric(Cadena)) And dtAtadosALeer.AsEnumerable.Where(Function(x) x.Item("Atado") = Cadena).Count = 1) Then

                                VerificarAtadoCompleto()
                                VerificarLoteCompleto()

                                ListaAtadosPares.Clear()

                                If EntSalidaNave.ConfiguracionNave.Maquila = True Then
                                    If ObjBU.ValidarExisteAtado(Cadena, EntSalidaNave.NaveSICYID) = True Then '' OAMB CAMBIOS (04/07/2024)
                                        VerificarAtadoCompleto()
                                        VerificarLoteCompleto()

                                        ListaAtadosPares.Clear()
                                        AtadoValido = ValidaAtado(Cadena)
                                        If AtadoValido = True Then
                                            If DatosAtado.PIdAtado <> "0" Then
                                                If InsertarInformacionLote(Cadena) = False Then
                                                    InicializarAtado()
                                                    InsertarAtadoInvalido(Cadena)
                                                End If
                                            ElseIf DatosAtado.PLote <> DatosLote.Lote Then
                                                If InsertarInformacionLote(Cadena) = False Then
                                                    InicializarAtado()
                                                    InsertarAtadoInvalido(Cadena)
                                                End If
                                            End If

                                            Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 11).FirstOrDefault
                                            If IsNothing(EntAtadoAux) = False Then
                                                EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                                EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos
                                            End If


                                            If DatosAtado.PValidacionEntradaPorPar = False Then
                                                ObtenerParesAtado(DatosAtado.PIdAtado)
                                            End If
                                        Else

                                        End If
                                    Else
                                        If ValidarPar(Cadena) = False Then
                                            ReproducrirSonidoError()
                                        End If
                                    End If

                                    If AtadoValido = True Then
                                        VerificarAtadoCompleto()
                                        VerificarLoteCompleto()
                                    End If


                                Else
                                    If ListaAtadosPendientes.Where(Function(x) x.PIdAtado = Cadena And x.PStatusAtado <> 11).Count = 0 Then
                                        ReproducrirSonidoError()
                                        InicializarAtado()
                                        Dim AtadoLeido As New Entidades.CapturaAtadoValido
                                        AtadoLeido = ValidarAtadoEntrada(Cadena)
                                        If AtadoLeido.PIdAtado <> "0" Then
                                            AtadoLeido.PStatusAtado = 11
                                            ListaAtadosPendientes.Add(AtadoLeido)
                                            ObjBU.InsertarAtadoNoEmbarcado(EntSalidaNave.IdSalidaNave, AtadoLeido.PIdAtado, AtadoLeido.PAño, AtadoLeido.PDescripcion, AtadoLeido.PIdCliente, AtadoLeido.PIdNAve, AtadoLeido.PLote, AtadoLeido.PNumeroAtado, AtadoLeido.PN_Pares, AtadoLeido.PStatusAtado)
                                        End If

                                        Return
                                    End If
                                    ValidaAtado(Cadena)

                                    Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado And x.PStatusAtado <> 11).FirstOrDefault
                                    EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                    EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos

                                    If DatosAtado.PValidacionEntradaPorPar = False Then
                                        ObtenerParesAtado(DatosAtado.PIdAtado)
                                    Else
                                        ListaAtadosPares.Clear()
                                    End If

                                    DatosLote = EntSalidaNave.LotesFolio.Where(Function(x) x.Lote = DatosAtado.PLote).FirstOrDefault

                                    VerificarAtadoCompleto()
                                    VerificarLoteCompleto()

                                End If


                                'If ValidaAtado(Cadena) = True Then
                                '    If DatosAtado.PIdAtado <> "0" Then
                                '        If EntSalidaNave.ConfiguracionNave.Maquila = True Then
                                '            If InsertarInformacionLote(Cadena) = False Then
                                '                InicializarAtado()
                                '            End If
                                '        End If

                                '    ElseIf DatosAtado.PLote <> DatosLote.Lote Then
                                '        If EntSalidaNave.ConfiguracionNave.Maquila = True Then
                                '            If InsertarInformacionLote(Cadena) = False Then
                                '                InicializarAtado()
                                '            End If
                                '        End If
                                '    End If

                                '    Dim EntAtadoAux = ListaAtadosPendientes.Where(Function(x) x.PIdAtado = DatosAtado.PIdAtado).FirstOrDefault
                                '    EntAtadoAux.PStatusAtado = DatosAtado.PStatusAtado
                                '    EntAtadoAux.Pn_ParesLeidos = DatosAtado.Pn_ParesLeidos

                                '    If DatosAtado.PValidacionEntradaPorPar = False Then
                                '        ObtenerParesAtado(DatosAtado.PIdAtado)
                                '    End If
                                'Else

                                'End If
                            ElseIf CarritoAux.Length = 3 And DatosAtado.PLecturaPorCodigoCliente = False Then
                                If ValidarPar(Cadena) = True Then

                                Else
                                    ' DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                                End If
                            Else
                                If ValidarPar(Cadena) = True Then
                                    ''Validar si el atado esta completo
                                    'If DatosAtado.PN_Pares = EntSalidaNave.Pares.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count Then
                                    '    DatosAtado.PStatusAtado = ResultadosEscaneo.CORRECTO
                                    'End If

                                    ''Validar si el Lote Esta Completo
                                    'If DatosLote.ParesLote = EntSalidaNave.Pares.Where(Function(x) x.Lote = DatosLote.Lote).Count Then
                                    '    DatosLote.StatusLote = ResultadosEscaneo.CORRECTO
                                    'End If
                                Else
                                    ' DatosAtado.PStatusAtado = ResultadosEscaneo.MAL_FORMADO
                                End If
                            End If
                        End If



                    End If
                End If
            End If



        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Function ValidarCarritoPerteneciente_a_Nave(ByVal IdCarrito As Integer, ByVal IdNave As Integer, ByVal Id_Almacen As Integer) As Boolean
        Dim objBU As New Negocios.EntradaProductoBU
        Dim CarritoValido As Boolean

        Try
            CarritoValido = objBU.ValidarCarritoPerteneciente_a_Nave(IdCarrito, IdNave, Id_Almacen)
        Catch ex As Exception
            Throw ex
        End Try

        Return CarritoValido
    End Function

    Private Sub CrearTablas()
        dtCodigosErroneos = New DataTable
        dtCodigosErroneos.Columns.Add("Lote")
        dtCodigosErroneos.Columns.Add("Atado")
        dtCodigosErroneos.Columns.Add("CodigoLeido")
        dtCodigosErroneos.Columns.Add("Usuario")
        dtCodigosErroneos.Columns.Add("Descripcion")
        dtCodigosErroneos.Columns.Add("Fecha")
        dtCodigosErroneos.Columns.Add("Status")
        dtCodigosErroneos.Columns.Add("StatusID")


    End Sub

    Public Sub ReproducrirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub

    Private Sub txtcapturacodigos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcapturacodigos.KeyPress
        'Dim CadenaCapturada As String = String.Empty
        'If e.KeyChar = ChrW(Keys.Enter) Then


        '    If (LTrim(RTrim(txtcapturacodigos.Text))) = "" Then Return



        '    CadenaCapturada = (LTrim(RTrim(txtcapturacodigos.Text))).Replace("'", "-")
        '    CadenaCapturada = Replace(CadenaCapturada, "PC", "Y-000-")

        '    If CadenaCapturada.Substring(0, 1) = "0" Then
        '        'CadenaCapturada = CadenaCapturada.Substring(1, CadenaCapturada.Length - 1)
        '        CadenaCapturada = CadenaCapturada.TrimStart("0")
        '    End If


        '    If EntSalidaNave.TipoProceso = "SALIDA" Then
        '        CapturaParAtadosYuyin(CadenaCapturada)
        '    Else
        '        CapturaParAtadosYuyinEntrada(CadenaCapturada)
        '        'CapturarParAtados_EntradaNave(CadenaCapturada)
        '    End If
        '    txtcapturacodigos.Text = ""
        '    txtcapturacodigos.Focus()
        '    CargarAtadosPendientes()
        '    ActualizarGridPares()
        '    CargarResumenPares()



        'End If
    End Sub

    Private Sub LimpiarCodigoErroneo(ByVal IdAtado As String)

        Try
            If ListaParesErroneos.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count >= 1 Then

                Dim ParesABorrar = ListaParesErroneos.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count

                For index As Integer = 1 To ParesABorrar
                    Dim index_borrar = ListaParesErroneos.FindIndex(Function(x) x.Atado = DatosAtado.PIdAtado)
                    ListaParesErroneos.RemoveAt(index_borrar)
                Next

                ObjBU.LimpiarCodigoErrorAtado(EntSalidaNave.IdSalidaNave, IdAtado)
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub CargarAtadosPendientes()
        grdIncorrecto.DataSource = Nothing
        If IsNothing(dtAtadosALeer) = False Then
            If dtAtadosALeer.Rows.Count > 0 Then
                grdIncorrecto.DataSource = ListaAtadosPendientes.Where(Function(x) x.PStatusAtado <> 1).ToList
                DiseñoGridAtadosPendientes(grdIncorrecto)
                ColorGridAtadosPendientes()
            End If
        End If
    End Sub

    Private Sub DiseñoGridAtadosPendientes(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim Layout As UltraGridLayout = grid.DisplayLayout

        Try
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            grid.DisplayLayout.Bands(0).Columns("PIdCarrito").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PIdAtado").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("PIdNAve").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PLote").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("PAño").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("PDescripcion").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Pn_AtadoEscaneado").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Pn_ParesLeidos").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PStatusAtado").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PNombreStatusAtado").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PValidacionSalidaPorPar").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PValidacionEntradaPorPar").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PLecturaPorCodigoCliente").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PN_Pares").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PIdCliente").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("PNumeroAtado").Hidden = False

            grid.DisplayLayout.Bands(0).Columns("PIdAtado").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PIdNAve").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PLote").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PAño").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PDescripcion").CellAppearance.TextHAlign = HAlign.Left
            grid.DisplayLayout.Bands(0).Columns("Pn_AtadoEscaneado").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Pn_ParesLeidos").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PStatusAtado").CellAppearance.TextHAlign = HAlign.Left
            grid.DisplayLayout.Bands(0).Columns("PNombreStatusAtado").CellAppearance.TextHAlign = HAlign.Left
            grid.DisplayLayout.Bands(0).Columns("PValidacionSalidaPorPar").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PValidacionEntradaPorPar").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PLecturaPorCodigoCliente").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PN_Pares").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PIdCliente").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("PNumeroAtado").CellAppearance.TextHAlign = HAlign.Right

            grid.DisplayLayout.Bands(0).Columns("PIdAtado").Header.Caption = "Atado"
            grid.DisplayLayout.Bands(0).Columns("PIdNAve").Header.Caption = "IdNave"
            grid.DisplayLayout.Bands(0).Columns("PLote").Header.Caption = "Lote"
            grid.DisplayLayout.Bands(0).Columns("PAño").Header.Caption = "Año"
            grid.DisplayLayout.Bands(0).Columns("PDescripcion").Header.Caption = "Descripcion"
            grid.DisplayLayout.Bands(0).Columns("Pn_AtadoEscaneado").Header.Caption = "Atado Escaneado"
            grid.DisplayLayout.Bands(0).Columns("Pn_ParesLeidos").Header.Caption = "Pares Leidos"
            grid.DisplayLayout.Bands(0).Columns("PStatusAtado").Header.Caption = "StatusAtado"
            grid.DisplayLayout.Bands(0).Columns("PNombreStatusAtado").Header.Caption = "Status"
            grid.DisplayLayout.Bands(0).Columns("PValidacionSalidaPorPar").Header.Caption = "ValidacionSalidaPar"
            grid.DisplayLayout.Bands(0).Columns("PValidacionEntradaPorPar").Header.Caption = "ValidacionEntradaPar"
            grid.DisplayLayout.Bands(0).Columns("PLecturaPorCodigoCliente").Header.Caption = "LecturaPorCodigoCliente"
            grid.DisplayLayout.Bands(0).Columns("PN_Pares").Header.Caption = "Pares Atado"
            grid.DisplayLayout.Bands(0).Columns("PNumeroAtado").Header.Caption = "Atado"


            grid.DisplayLayout.Bands(0).Columns("PIdAtado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PIdNAve").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PLote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PAño").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PDescripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Pn_AtadoEscaneado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Pn_ParesLeidos").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PStatusAtado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PNombreStatusAtado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PValidacionSalidaPorPar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PValidacionEntradaPorPar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PLecturaPorCodigoCliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PN_Pares").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("PNumeroAtado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DiseñoGridLecturaPares(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim IndicePrimerColumna As Integer = 0
        Dim UltimaColumna As Integer = 0
        Dim Layout As UltraGridLayout = grid.DisplayLayout

        Try
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            grid.DisplayLayout.Bands(0).Columns("Atado").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Par").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Status").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("NombreEstatus").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Fecha").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Usuario").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Lote").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("Año").Hidden = False
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("CodigoPorLeer").Hidden = False

            grid.DisplayLayout.Bands(0).Columns("Atado").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Par").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Status").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("NombreEstatus").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Fecha").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Usuario").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Lote").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("Año").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").CellAppearance.TextHAlign = HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("CodigoPorLeer").CellAppearance.TextHAlign = HAlign.Right


            grid.DisplayLayout.Bands(0).Columns("Atado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Status").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("NombreEstatus").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Fecha").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("UsuarioID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("NaveSICYID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("Año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("ClienteSICYID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("CodigoPorLeer").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub grdIncorrecto_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdIncorrecto.InitializeLayout
        Dim dtTabla As New DataTable

        Dim row As UltraGridRow = grdIncorrecto.ActiveRow
        If row IsNot Nothing Then
            If IsDBNull(row.Cells("PStatusAtado").Value) = False Then
                If row.Cells("PStatusAtado").Value = 1 Then
                    row.CellAppearance.BackColor = Color.White
                ElseIf row.Cells("PStatusAtado").Value = 2 Then
                    row.CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
                ElseIf row.Cells("PStatusAtado").Value = 4 Then
                    row.CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
                ElseIf row.Cells("PStatusAtado").Value = 0 Then
                    row.CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
                ElseIf row.Cells("PStatusAtado").Value = 5 Then
                    row.CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
                ElseIf row.Cells("PStatusAtado").Value = 6 Then
                    row.CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
                ElseIf row.Cells("PStatusAtado").Value = 7 Then
                    row.CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
                ElseIf row.Cells("PStatusAtado").Value = 8 Then
                    row.CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
                ElseIf row.Cells("PStatusAtado").Value = 9 Then
                    row.CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
                ElseIf row.Cells("PStatusAtado").Value = 10 Then
                    row.CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
                ElseIf row.Cells("PStatusAtado").Value = 11 Then
                    row.CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
                ElseIf row.Cells("PStatusAtado").Value = 12 Then
                    row.CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
                ElseIf row.Cells("PStatusAtado").Value = 911 Then
                    row.CellAppearance.BackColor = Color.MediumSlateBlue '---------COLOR PARA ATADO SIN PRECIO

                End If
            End If



        End If
    End Sub

    Private Sub ColorGridAtadosPendientes()
        Dim dtTabla As New DataTable

        For Each Fila As UltraGridRow In grdIncorrecto.Rows
            If Fila.Cells("PStatusAtado").Value = 1 Then
                Fila.CellAppearance.BackColor = Color.White
            ElseIf Fila.Cells("PStatusAtado").Value = 2 Then
                Fila.CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
            ElseIf Fila.Cells("PStatusAtado").Value = 4 Then
                Fila.CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
            ElseIf Fila.Cells("PStatusAtado").Value = 0 Then
                Fila.CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
            ElseIf Fila.Cells("PStatusAtado").Value = 5 Then
                Fila.CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
            ElseIf Fila.Cells("PStatusAtado").Value = 6 Then
                Fila.CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
            ElseIf Fila.Cells("PStatusAtado").Value = 7 Then
                Fila.CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
            ElseIf Fila.Cells("PStatusAtado").Value = 8 Then
                Fila.CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
            ElseIf Fila.Cells("PStatusAtado").Value = 9 Then
                Fila.CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
            ElseIf Fila.Cells("PStatusAtado").Value = 10 Then
                Fila.CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
            ElseIf Fila.Cells("PStatusAtado").Value = 11 Then
                Fila.CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
            ElseIf Fila.Cells("PStatusAtado").Value = 12 Then
                Fila.CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
            ElseIf Fila.Cells("PStatusAtado").Value = 911 Then
                Fila.CellAppearance.BackColor = Color.MediumSlateBlue '---------COLOR PARA ATADO SIN PRECIO
            End If
        Next
    End Sub

    Private Sub ColorCodigosLeidos()
        Dim EntStatusAtado As Entidades.CapturaAtadoValido

        Try

            For Each row As UltraGridRow In grdLectura.Rows
                EntStatusAtado = ListaDatosAtado.Where(Function(x) x.PIdAtado = row.Cells("Atado").Value).FirstOrDefault
                If IsNothing(EntStatusAtado) = False Then
                    If EntStatusAtado.PStatusAtado = 1 Then
                        row.CellAppearance.BackColor = Color.White
                    ElseIf EntStatusAtado.PStatusAtado = 2 Then
                        row.CellAppearance.BackColor = Color.Khaki '-------COLOR PAEA ATADO CON FALTANTE
                    ElseIf EntStatusAtado.PStatusAtado = 4 Then
                        row.CellAppearance.BackColor = Color.LightSalmon '-COLOR PARA ATADO MAL FORMADO
                    ElseIf EntStatusAtado.PStatusAtado = 0 Then
                        row.CellAppearance.BackColor = Color.Silver '-------COLOR PAEA ATADO NO LEIDO
                    ElseIf EntStatusAtado.PStatusAtado = 5 Then
                        row.CellAppearance.BackColor = Color.Orange '------COLOR PARA LOTE SIN TERMINAR
                    ElseIf EntStatusAtado.PStatusAtado = 6 Then
                        row.CellAppearance.BackColor = Color.Pink '--------COLOR APRA ATADO CORRECTO DE LOTE SIN TERMINAR
                    ElseIf EntStatusAtado.PStatusAtado = 7 Then
                        row.CellAppearance.BackColor = Color.Chocolate '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN TERMINAR
                    ElseIf EntStatusAtado.PStatusAtado = 8 Then
                        row.CellAppearance.BackColor = Color.OrangeRed '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN TERMINAR
                    ElseIf EntStatusAtado.PStatusAtado = 9 Then
                        row.CellAppearance.BackColor = Color.SteelBlue  '------COLOR PARA LOTE NO EMBARCADO
                    ElseIf EntStatusAtado.PStatusAtado = 10 Then
                        row.CellAppearance.BackColor = Color.DodgerBlue '--------COLOR ATADO CORRECTO DE LOTE SIN EMBARCAR
                    ElseIf EntStatusAtado.PStatusAtado = 11 Then
                        row.CellAppearance.BackColor = Color.Aqua '---COLOR PARA ATADO CON FALTANTE DE LOTE SIN EMBARCAR
                    ElseIf EntStatusAtado.PStatusAtado = 12 Then
                        row.CellAppearance.BackColor = Color.CadetBlue '---------COLOR PARA ATADO MAL FORMADO DE LOTE SIN EMBARCAR
                    End If

                End If

            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CargarResumenPares()
        'Dim ListaDatosAtado As New List(Of Entidades.CapturaAtadoValido)
        'Dim DatosAtado As New Entidades.CapturaAtadoValido 'Atado Actual
        'Dim DatosLote As New Entidades.InformacionLoteSalidaNave 'Lote Actual

        'Dim ListaAtadosPares As New List(Of Entidades.CapturaParValido)
        'Dim ListaPares As New List(Of Entidades.CapturaParValido)
        'Dim ListaAtadosPendientes As New List(Of Entidades.CapturaAtadoValido)

        'Dim dtParesALeer As New DataTable
        'Dim dtAtadosALeer As New DataTable

        Try
            lblParesLeidos.Text = CDbl(ListaPares.Where(Function(x) x.Status <> 0).Count()).ToString("N0")
            lblAtadosLeidos.Text = CDbl(ListaDatosAtado.Where(Function(x) x.PStatusAtado <> 0).Count()).ToString("N0")
            lblLotesLeidos.Text = CDbl(EntSalidaNave.LotesFolio.Where(Function(x) x.StatusLote <> 0).Count()).ToString("N0")

            lblAtadosIncorrectos.Text = CDbl(ListaDatosAtado.Where(Function(x) x.PStatusAtado <> 1 And x.PStatusAtado <> 0).Count).ToString("N0")
            'lblParesIncorrectos.Text = CDbl(ListaPares.Where(Function(x) x.Status <> 1 And x.Status <> 0).Count).ToString("N0")

            lblPB.Text = CDbl(EntSalidaNave.Pares.Count()).ToString("N0")
            lblAB.Text = CDbl(EntSalidaNave.Atados.Where(Function(x) x.PStatusAtado = 1).Count()).ToString("N0")
            lblLB.Text = CDbl(EntSalidaNave.LotesFolio.Where(Function(x) x.StatusLote = 1).Count()).ToString("N0")

            lblParesIncorrectos.Text = CDbl(ListaParesErroneos.Count()).ToString("N0")

            lblTotalPares.Text = CDbl(dtParesALeer.Rows.Count).ToString("N0")
            lblTotalAtados.Text = CDbl(dtAtadosALeer.Rows.Count).ToString("N0")
            lblTotalLotes.Text = CDbl(dtAtadosALeer.AsEnumerable.Select(Function(x) x.Item("Lote")).Distinct.Count).ToString("N0")

            If EntSalidaNave.TipoProceso = "SALIDA" Then
                Panel1.Visible = True
                Panel17.Visible = True
                Panel18.Visible = True
                lblParesAEmbarcar.Visible = True
                lblAtadosAEmbarcar.Visible = True
                lblLotesAEmbarcar.Visible = True

                lblCarritos.Visible = False
                Panel22.Visible = False
                lblParesIngresados.Visible = False
                Panel19.Visible = False
                lblAtadosIngresados.Visible = False
                Panel21.Visible = False
                lblLotesIngresados.Visible = False
                Panel20.Visible = False

            ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                Panel1.Visible = False
                Panel17.Visible = False
                Panel18.Visible = False
                lblParesAEmbarcar.Visible = False
                lblAtadosAEmbarcar.Visible = False
                lblLotesAEmbarcar.Visible = False

                lblCarritos.Visible = True
                Panel22.Visible = True
                lblParesIngresados.Visible = True
                Panel19.Visible = True
                lblAtadosIngresados.Visible = True
                Panel21.Visible = True
                lblLotesIngresados.Visible = True
                Panel20.Visible = True



                lblTotalCarritos.Text = CDbl(EntSalidaNave.ListaPlataformas.Count()).ToString("N0")
                lblTotalParesIngresados.Text = CDbl(EntSalidaNave.Pares.Count()).ToString("N0")
                lblTotalAtadosIngresados.Text = CDbl(EntSalidaNave.Atados.Where(Function(x) x.PStatusAtado = 1).Count()).ToString("N0")
                lblTotalLotesIngresados.Text = CDbl(EntSalidaNave.LotesFolio.Where(Function(x) x.StatusLote = 1).Count()).ToString("N0")

            End If
            'ListaParesDescartados

            'Dim dtParesALeer As New DataTable
            'Dim dtAtadosALeer As New DataTable<

            lblParesDescartados.Text = CDbl(ListaParesDescartados.Count).ToString("N0")
            lblAtadosDescartados.Text = CDbl(ListaAtadosDescartados.Count).ToString("N0")
            lblLotesDescardatos.Text = CDbl(LotesDescartados.Count).ToString("N0")

        Catch ex As Exception
            Throw ex
        End Try




    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        Proceso_Detener()
    End Sub
    Private Sub Proceso_Detener()

        Try
            btnIniciar.Enabled = True
            btnDetener.Enabled = False
            txtcapturacodigos.Enabled = False
            cmbOperador.Enabled = False
            cmbNaves.Enabled = False
            btnGuardar.Enabled = True
            btnSalir.Enabled = True
            btnDescartarLotes.Enabled = True
            btnImprimirReporte.Enabled = True

            VerificarAtadoCompleto()
            VerificarLoteCompleto()
            cboxAlmacen.Enabled = True
            cboxNaveAlmacen.Enabled = True

            ActualizarGridPares()
            CargarAtadosPendientes()
            CargarResumenPares()
        Catch ex As Exception
            Throw ex
        End Try


        ''falta actualiar el estdo del atado n
        'If AtadoActual <> "0" Then
        '    If NparesAtadoActualLeeidos > 0 Or LecturaParXPar = False Then
        '        ActualizarEstatusDeAtado()
        '    End If

        '    AtadoActual = "0"
        '    LlenarEtiquetas()
        'End If

        'ControlBox = True

        'If lAtados.Count = 0 And llotes.Count = 0 And IdSalidaNave = 0 And lpares.Count = 0 Then
        '    cmbProceso.Enabled = True
        '    cmbNaves.Enabled = True
        'End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        'Dim formaConfirmacion As New ConfirmarForm
        'formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        'formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

        'If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    Me.Close()
        'End If
        Me.Close()
    End Sub

    Private Sub SalidaNaveLotesFormV2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"

        If formaConfirmacion.ShowDialog() <> Windows.Forms.DialogResult.OK Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Cursor = Cursors.WaitCursor
            ProgressPanel2.Show()
            ProgressPanel2.Refresh()


            btnGuardar.Enabled = False
            If EntSalidaNave.TipoProceso = "SALIDA" Then
                If grdIncorrecto.Rows.Count > 0 Then
                    Tools.Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Aun cuentas con faltante y/o errores en tu lectura, descarta los atados o termina de leer correctamente para poder guardar.")
                Else
                    ObjBU.ActualizarStatusSalida(EntSalidaNave.IdSalidaNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, EntSalidaNave.NaveSICYID)
                    Tools.Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El proceso de salida se finalizo correctamente")
                    ReporteSalida(EntSalidaNave.IdSalidaNave, EntSalidaNave.NaveSICYID)

                    Dim objBUTimbrado As New TrasladosBU
                    Try
                        Dim obj As New AdminCFDITrasladoBU

                        Dim resultado = obj.InsertarTraslado(EntSalidaNave.IdSalidaNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, True)

                        If resultado(0)(0) <> 0 Then
                            For index = 0 To resultado.Rows.Count - 1
                                objBUTimbrado.GenerarInformacionTimbrado(EntSalidaNave.IdSalidaNave, resultado(index)(2), True) 'lblFolio.Text
                                'Dim empresa = objBUTimbrado.ObtenerEmpresaFactura(FolioVerificacionId)
                                Dim ResultadoTimbrado = objBUTimbrado.TimbrarFactura(resultado(index)(0), resultado(index)(2), "TRASLADO")

                                If ResultadoTimbrado = True Then
                                    'Generar PDF                                                                        
                                    If objBUTimbrado.GenerarPDFFactura(resultado(index)(0), "TRASLADO") Then
                                        Dim RutaPDFFactura = objBUTimbrado.ConsultarRutaPDFFactura(resultado(index)(0))
                                        'AbrirPDFFactura(RutaPDFFactura)
                                    End If
                                End If
                            Next
                        End If
                    Catch ex As Exception
                        objBUTimbrado.InsertarError(EntSalidaNave.IdSalidaNave, "SALIDANAVE", ex.Message)
                    End Try

                    DesbloquearControlesGuardar()
                End If

            ElseIf EntSalidaNave.TipoProceso = "ENTRADA" Then
                If ListaAtadosPendientes.Where(Function(x) x.PStatusAtado <> 1).Count = 0 Then
                    If EntSalidaNave.Pares.Count > 0 Then
                        If ObjBU.FinalizarEntradaLote(EntSalidaNave.IdSalidaNave, cboxAlmacen.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, EntSalidaNave.ConfiguracionNave.Maquila, EntSalidaNave.NaveSICYID, cboxNaveAlmacen.SelectedValue) = True Then
                            ObjBU.actualizarEstatus(EntSalidaNave.IdSalidaNave, EntSalidaNave.NaveSICYID)
                            'ObjBU.EnviarAHistoricoFolio(EntSalidaNave.IdSalidaNave)

                            ImprimirReporte_Entrada_Almacen(EntSalidaNave.NaveSICYID, cboxAlmacen.Text, Date.Now, cboxNaveAlmacen.SelectedValue)
                            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El proceso de entrada se finalizo correctamente.")
                            DesbloquearControlesGuardar()

                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrio un error al momento de guardar,  por favor vuelva a guardar.")
                        End If
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay atados confirmados para su ingreso.")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se puede guardar el folio, hay atados pendientes de leer.")

                    'If EntSalidaNave.Pares.Count > 0 Then
                    '    If ObjBU.FinalizarEntradaLote(EntSalidaNave.IdSalidaNave, cboxAlmacen.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, EntSalidaNave.ConfiguracionNave.Maquila, EntSalidaNave.NaveSICYID) = True Then
                    '        'ObjBU.EnviarAHistoricoFolio(EntSalidaNave.IdSalidaNave)
                    '        ImprimirReporte_Entrada_Almacen(EntSalidaNave.NaveSICYID, cboxAlmacen.Text, Date.Now)
                    '        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El proceso de entrada se finalizo correctamente.")
                    '        DesbloquearControlesGuardar()
                    '    Else
                    '        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ocurrio un error al momento de guardar,  por favor vuelva a guardar.")
                    '    End If
                    'Else
                    '    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay atados confirmados para su ingreso.")
                    'End If
                End If
            End If
            LimpiarVariables()
            CargarResumenPares()
            ProgressPanel2.Hide()
            btnGuardar.Enabled = True
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            ProgressPanel2.Hide()
            btnGuardar.Enabled = True
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Ocurrio un error al momento de guardar, por favor vuelva a guardar.")
        End Try

    End Sub

    Private Sub LimpiarVariables()
        Try
            dtCodigosErroneos = New DataTable
            IdSalidaNaves = 0
            UsuarioID = 0
            IdNave = 0
            EntSalidaNave = New Entidades.InfoSalidaNave

            ListaDatosAtado.Clear()
            ListaDatosAtado = New List(Of Entidades.CapturaAtadoValido)
            DatosAtado = Nothing
            DatosLote = Nothing
            DatosAtado = New Entidades.CapturaAtadoValido 'Atado Actual
            DatosLote = New Entidades.InformacionLoteSalidaNave 'Lote Actual

            ListaAtadosPares.Clear()
            ListaPares.Clear()
            ListaAtadosPendientes.Clear()

            ListaAtadosPares = New List(Of Entidades.CapturaParValido)
            ListaPares = New List(Of Entidades.CapturaParValido)
            ListaAtadosPendientes = New List(Of Entidades.CapturaAtadoValido)

            dtParesALeer = Nothing
            dtAtadosALeer = Nothing

            dtParesALeer = New DataTable
            dtAtadosALeer = New DataTable
            LotesDescartados.Clear()
            ListaParesDescartados.Clear()
            ListaAtadosDescartados.Clear()
            CrearTablas()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub RegistrarError(ByVal FolioSalidaID As Integer, ByVal CodigoLeido As String, ByVal CodigoAtado As String, ByVal Lote As Integer, ByVal Año As Integer, ByVal NaveSICYID As Integer, ByVal UsuarioId As Integer, ByVal NombreUsuario As String, ByVal Proceso As String, ByVal DescripcionError As String)
        Dim CodigoErroneoLeido As New Entidades.CodigosErroneos

        Try
            With CodigoErroneoLeido
                .Atado = CodigoAtado
                .Año = Año
                .CodigoLeido = CodigoLeido
                .DescripcionError = DescripcionError
                .FolioSalidaID = FolioSalidaID
                .Lote = Lote
                .NaveSICYID = NaveSICYID
                .Proceso = Proceso
                .Usuario = NombreUsuario
                .UsuarioID = UsuarioId
            End With

            ListaParesErroneos.Add(CodigoErroneoLeido)

            ObjBU.InsertarErrorDeLectura(CodigoErroneoLeido)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnCodigosConErrores_Click(sender As Object, e As EventArgs) Handles btnCodigosConErrores.Click
        Dim CodigosErroneos As New CodigosErrorEntradaSalidaNaveForm
        Try
            CodigosErroneos.ListaCodigosError = ListaParesErroneos
            CodigosErroneos.TipoProceso = EntSalidaNave.TipoProceso
            CodigosErroneos.Plataformas = False
            CodigosErroneos.ShowDialog()
        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        'Dim OBJBU As New Framework.Negocios.ReportesBU
        'Dim EntidadReporte As Entidades.Reportes
        'EntidadReporte = OBJBU.LeerReporteporClave("PROD_SALIDANAVES_SALIDANAVES")
        'Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        '    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        'My.Computer.FileSystem.WriteAllText(archrivo, EntidadReporte.Pxml, False)
        ReporteSalida(113, 7)
    End Sub


    Private Sub ReporteSalida(ByVal FolioSalidaID As Integer, ByVal NaveId As Integer)

        Dim objBU_SalidasAlmacen As New SalidasAlmacenBU
        Dim dtParesAEmbarcar As New DataTable("dtTotalesSalida")
        Dim dtTotalesDelEmbarque As New DataTable
        Dim Fecha_Salida As DateTime
        Dim Hora_Salida As String
        Dim entrega As Integer
        Dim TotalParesEmbarcados As Integer
        Dim TotalAtadosEmbarcados As Integer
        Dim TotalLotesEmbarcados As Integer
        Dim dtTablaCantidadesProgramas
        Dim dtResumenFolio As DataTable
        Dim dtLoteAux As New DataTable

        Dim dtLotePilotoAux As New DataTable
        Dim reporte As New StiReport
        Dim DsReporteSalidas As New DataSet("dsLotes")

        Dim ParesProgramaBien As Integer = 0
        Dim AtadosProgramaBien As Integer = 0
        Dim LotesProgramaBien As Integer = 0
        Dim ParesProgramaMal As Integer = 0
        Dim AtadosProgramaMal As Integer = 0
        Dim LotesProgramaMal As Integer = 0

        Dim OBJBUReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes

        Dim archivo As String

        Me.Cursor = Cursors.WaitCursor

        Dim dtInformacion As New DataTable
        With dtParesAEmbarcar
            .Columns.Add("Lote", GetType(Integer))
            .Columns.Add("Cliente", GetType(String))
            .Columns.Add("Año", GetType(String))
            .Columns.Add("Atados", GetType(Integer))
            .Columns.Add("Pares", GetType(Integer))
            .Columns.Add("Modelo", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add("Corrida", GetType(String))
            .Columns.Add("Programa", GetType(String))
        End With

        Dim dtInformacionLotesPiloto As New DataTable
        With dtInformacionLotesPiloto
            .Columns.Add("Lote", GetType(Integer))
            .Columns.Add("Cliente", GetType(String))
            .Columns.Add("Año", GetType(String))
            .Columns.Add("Atados", GetType(Integer))
            .Columns.Add("Pares", GetType(Integer))
            .Columns.Add("Modelo", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add("Corrida", GetType(String))
            .Columns.Add("Programa", GetType(String))
        End With

        Dim dtLotesCompleto As New DataTable
        With dtLotesCompleto
            .Columns.Add("Lote", GetType(Integer))
            .Columns.Add("Cliente", GetType(String))
            .Columns.Add("Año", GetType(String))
            .Columns.Add("Atados", GetType(Integer))
            .Columns.Add("Pares", GetType(Integer))
            .Columns.Add("Modelo", GetType(String))
            .Columns.Add("Descripcion", GetType(String))
            .Columns.Add("Corrida", GetType(String))
            .Columns.Add("Programa", GetType(String))
        End With

        'Laura 14/07/2023
        objBU_SalidasAlmacen.ActualizacionTipoLotesSalidasNaves(FolioSalidaID)

        If NaveId = 65 Or NaveId = 11 Or NaveId = 2 Or NaveId = 3 Or NaveId = 6 Or NaveId = 10 Or NaveId = 15 Or NaveId = 16 Or NaveId = 53 Or NaveId = 57 Or NaveId = 63 Or NaveId = 64 Or NaveId = 65 Or NaveId = 1 Then


            'Laura 14/07/2023
            dtLotePilotoAux = ObjBU.ReporteObtenerResumenParesLotesPiloto(FolioSalidaID)
            dtLoteAux = ObjBU.ReporteObtenerResumeLotes(FolioSalidaID)


            ' Creamos una copia de la estructura de la DataTable original para mantener las columnas
            Dim dtOrdenada As DataTable = dtLoteAux.Clone()

            ' Utilizamos LINQ para ordenar la DataTable por la columna deseada, por ejemplo "NombreColumna"
            Dim filasOrdenadas = From fila As DataRow In dtLoteAux
                                 Order By fila("CLIENTE")

            ' Rellenamos la DataTable ordenada con las filas ordenadas
            For Each fila In filasOrdenadas
                dtOrdenada.ImportRow(fila)
            Next

            ' Asignamos la DataTable ordenada a la variable original
            dtLoteAux = dtOrdenada



            For Each Fila As DataRow In dtLoteAux.Rows
                dtParesAEmbarcar.Rows.Add(Fila.Item("LOTE"), Fila.Item("CLIENTE"), Fila.Item("AÑO"), Fila.Item("ATADOS"), Fila.Item("PARES"), Fila.Item("ModeloSAY"), Fila.Item("DESCRIPCION"), Fila.Item("CORRIDA"), CDate(Fila.Item("Programa")).ToShortDateString())
                dtLotesCompleto.Rows.Add(Fila.Item("LOTE"), Fila.Item("CLIENTE"), Fila.Item("AÑO"), Fila.Item("ATADOS"), Fila.Item("PARES"), Fila.Item("ModeloSAY"), Fila.Item("DESCRIPCION"), Fila.Item("CORRIDA"), CDate(Fila.Item("Programa")).ToShortDateString())
            Next

            For Each Fila As DataRow In dtLotePilotoAux.Rows
                dtInformacionLotesPiloto.Rows.Add(Fila.Item("LOTE"), Fila.Item("CLIENTE"), Fila.Item("AÑO"), Fila.Item("ATADOS"), Fila.Item("PARES"), Fila.Item("ModeloSAY"), Fila.Item("DESCRIPCION"), Fila.Item("CORRIDA"), CDate(Fila.Item("Programa")).ToShortDateString())
                dtLotesCompleto.Rows.Add(Fila.Item("LOTE"), Fila.Item("CLIENTE"), Fila.Item("AÑO"), Fila.Item("ATADOS"), Fila.Item("PARES"), Fila.Item("ModeloSAY"), Fila.Item("DESCRIPCION"), Fila.Item("CORRIDA"), CDate(Fila.Item("Programa")).ToShortDateString())
            Next

            dtParesAEmbarcar.TableName = "dtTotalesSalida"
            dtInformacionLotesPiloto.TableName = "dtLotesPiloto"
            DsReporteSalidas.Tables.Add(dtParesAEmbarcar)
            DsReporteSalidas.Tables.Add(dtInformacionLotesPiloto)

            dtResumenFolio = ObjBU.ReporteObtenerResumenFolio(FolioSalidaID)

            ''RECUPERAMOS LOS TOTALES DE EL EMBARQUE ASI COMO LA FECHA
            If dtResumenFolio.Rows.Count > 0 Then
                TotalParesEmbarcados = dtResumenFolio.Rows(0).Item("PARES_SALIDA")
                TotalAtadosEmbarcados = dtResumenFolio.Rows(0).Item("ATADOS_SALIDA")
                TotalLotesEmbarcados = dtResumenFolio.Rows(0).Item("LOTES_SALIDA")
                Fecha_Salida = dtResumenFolio.Rows(0).Item("FECHA_SALIDA")
                Hora_Salida = Fecha_Salida.Hour
                entrega = dtResumenFolio.Rows(0).Item("ENTREGA")
            End If

            '''RECUPERAMOS LOS TOTALES DE PARES SALIDOS CON ATRASO Y EN TIEMPO
            dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dtLotesCompleto, Fecha_Salida)


            ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
            AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
            LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
            ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
            AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
            LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")


            EntidadReporte = OBJBUReporte.LeerReporteporClave("REPORT_SLDNV_SLD_LP")
            archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"

            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()

            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNaveSICY(NaveId)
            reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(NaveId)
            reporte("NombreReporte") = "SAY: RESUMEN_SALIDA_NAVES.mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("Operador") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.Trim()
            Dim fechaimp As String = DateTime.Parse(Now).ToString("dd/MM/yyyy HH:mm:ss")
            reporte("Fecha_Impresion") = DateTime.Parse(Now).ToShortDateString.ToString
            reporte("Fecha_Salida") = Fecha_Salida.Date.ToString("dd/MM/yyyy")
            reporte("Hora_Salida") = Fecha_Salida.ToShortTimeString
            reporte("Folio") = FolioSalidaID
            reporte("TotalPares") = TotalParesEmbarcados
            reporte("TotalAtados") = TotalAtadosEmbarcados
            reporte("TotalLotes") = TotalLotesEmbarcados
            reporte("Entrega") = entrega
            reporte("ParesProgramaBien") = ParesProgramaBien
            reporte("AtadosProgramaBien") = AtadosProgramaBien
            reporte("LotesProgramaBien") = LotesProgramaBien
            reporte("ParesProgramaMal") = ParesProgramaMal
            reporte("AtadosProgramaMal") = AtadosProgramaMal
            reporte("LotesProgramaMal") = LotesProgramaMal

            reporte.Dictionary.Clear()
            reporte.RegData(DsReporteSalidas)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        Else

            ''Laura 21/07/2023
            dtLoteAux = ObjBU.ReporteObtenerResumenPares(FolioSalidaID)

            ' Creamos una copia de la estructura de la DataTable original para mantener las columnas
            Dim dtOrdenada As DataTable = dtLoteAux.Clone()

            ' Utilizamos LINQ para ordenar la DataTable por la columna deseada, por ejemplo "NombreColumna"
            Dim filasOrdenadas = From fila As DataRow In dtLoteAux
                                 Order By fila("CLIENTE")

            ' Rellenamos la DataTable ordenada con las filas ordenadas
            For Each fila In filasOrdenadas
                dtOrdenada.ImportRow(fila)
            Next

            ' Asignamos la DataTable ordenada a la variable original
            dtLoteAux = dtOrdenada


            For Each Fila As DataRow In dtLoteAux.Rows
                dtParesAEmbarcar.Rows.Add(Fila.Item("LOTE"), Fila.Item("CLIENTE"), Fila.Item("AÑO"), Fila.Item("ATADOS"), Fila.Item("PARES"), Fila.Item("ModeloSAY"), Fila.Item("DESCRIPCION"), Fila.Item("CORRIDA"), CDate(Fila.Item("Programa")).ToShortDateString())
            Next

            dtResumenFolio = ObjBU.ReporteObtenerResumenFolio(FolioSalidaID)

            ''RECUPERAMOS LOS TOTALES DE EL EMBARQUE ASI COMO LA FECHA
            If dtResumenFolio.Rows.Count > 0 Then
                TotalParesEmbarcados = dtResumenFolio.Rows(0).Item("PARES_SALIDA")
                TotalAtadosEmbarcados = dtResumenFolio.Rows(0).Item("ATADOS_SALIDA")
                TotalLotesEmbarcados = dtResumenFolio.Rows(0).Item("LOTES_SALIDA")
                Fecha_Salida = dtResumenFolio.Rows(0).Item("FECHA_SALIDA")
                Hora_Salida = Fecha_Salida.Hour
                entrega = dtResumenFolio.Rows(0).Item("ENTREGA")
            End If

            '''RECUPERAMOS LOS TOTALES DE PARES SALIDOS CON ATRASO Y EN TIEMPO
            dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dtParesAEmbarcar, Fecha_Salida)


            ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
            AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
            LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
            ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
            AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
            LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")


            EntidadReporte = OBJBUReporte.LeerReporteporClave("PROD_SALIDANAVES_SALIDANAVES")
            archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"

            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNaveSICY(NaveId)
            reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(NaveId)
            reporte("NombreReporte") = "SAY: RESUMEN_SALIDA_NAVES.mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("Operador") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.Trim()
            Dim fechaimp As String = DateTime.Parse(Now).ToString("dd/MM/yyyy HH:mm:ss")
            reporte("Fecha_Impresion") = DateTime.Parse(Now).ToShortDateString.ToString
            reporte("Fecha_Salida") = Fecha_Salida.Date.ToString("dd/MM/yyyy")
            reporte("Hora_Salida") = Fecha_Salida.ToShortTimeString
            reporte("Folio") = FolioSalidaID
            reporte("TotalPares") = TotalParesEmbarcados
            reporte("TotalAtados") = TotalAtadosEmbarcados
            reporte("TotalLotes") = TotalLotesEmbarcados
            reporte("Entrega") = entrega
            reporte("ParesProgramaBien") = ParesProgramaBien
            reporte("AtadosProgramaBien") = AtadosProgramaBien
            reporte("LotesProgramaBien") = LotesProgramaBien
            reporte("ParesProgramaMal") = ParesProgramaMal
            reporte("AtadosProgramaMal") = AtadosProgramaMal
            reporte("LotesProgramaMal") = LotesProgramaMal

            reporte.Dictionary.Clear()
            reporte.RegData(dtParesAEmbarcar)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        End If
        'Dim dtParesAEmbarcar As New DataTable("dtTotalesSalida")
        'Dim dtTotalesDelEmbarque As New DataTable
        'Dim Fecha_Salida As DateTime
        'Dim Hora_Salida As String
        'Dim entrega As Integer
        'Dim TotalParesEmbarcados As Integer
        'Dim TotalAtadosEmbarcados As Integer
        'Dim TotalLotesEmbarcados As Integer
        'Dim dtTablaCantidadesProgramas
        'Dim dtResumenFolio As DataTable
        'Dim dtLoteAux As New DataTable
        'Dim reporte As New StiReport

        'Dim ParesProgramaBien As Integer = 0
        'Dim AtadosProgramaBien As Integer = 0
        'Dim LotesProgramaBien As Integer = 0
        'Dim ParesProgramaMal As Integer = 0
        'Dim AtadosProgramaMal As Integer = 0
        'Dim LotesProgramaMal As Integer = 0

        'Dim OBJBUReporte As New Framework.Negocios.ReportesBU
        'Dim EntidadReporte As Entidades.Reportes

        'Dim archivo As String

        'Me.Cursor = Cursors.WaitCursor

        'Dim dtInformacion As New DataTable
        'With dtParesAEmbarcar
        '    .Columns.Add("Lote", GetType(Integer))
        '    .Columns.Add("Año", GetType(String))
        '    .Columns.Add("Atados", GetType(Integer))
        '    .Columns.Add("Pares", GetType(Integer))
        '    .Columns.Add("Modelo", GetType(String))
        '    .Columns.Add("Descripcion", GetType(String))
        '    .Columns.Add("Corrida", GetType(String))
        '    .Columns.Add("Programa", GetType(String))
        'End With

        'dtLoteAux = ObjBU.ReporteObtenerResumenPares(FolioSalidaID)

        'For Each Fila As DataRow In dtLoteAux.Rows
        '    dtParesAEmbarcar.Rows.Add(Fila.Item("LOTE"), Fila.Item("AÑO"), Fila.Item("ATADOS"), Fila.Item("PARES"), Fila.Item("ModeloSAY"), Fila.Item("DESCRIPCION"), Fila.Item("CORRIDA"), CDate(Fila.Item("Programa")).ToShortDateString())
        'Next

        'dtResumenFolio = ObjBU.ReporteObtenerResumenFolio(FolioSalidaID)

        '''RECUPERAMOS LOS TOTALES DE EL EMBARQUE ASI COMO LA FECHA
        'If dtResumenFolio.Rows.Count > 0 Then
        '    TotalParesEmbarcados = dtResumenFolio.Rows(0).Item("PARES_SALIDA")
        '    TotalAtadosEmbarcados = dtResumenFolio.Rows(0).Item("ATADOS_SALIDA")
        '    TotalLotesEmbarcados = dtResumenFolio.Rows(0).Item("LOTES_SALIDA")
        '    Fecha_Salida = dtResumenFolio.Rows(0).Item("FECHA_SALIDA")
        '    Hora_Salida = Fecha_Salida.Hour
        '    entrega = dtResumenFolio.Rows(0).Item("ENTREGA")
        'End If

        ''''RECUPERAMOS LOS TOTALES DE PARES SALIDOS CON ATRASO Y EN TIEMPO
        'dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dtParesAEmbarcar, Fecha_Salida)


        'ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
        'AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
        'LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
        'ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
        'AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
        'LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")


        'EntidadReporte = OBJBUReporte.LeerReporteporClave("PROD_SALIDANAVES_SALIDANAVES")
        'archivo = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
        '    LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"

        'My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

        'reporte.Load(archivo)
        'reporte.Compile()
        'reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNaveSICY(NaveId)
        'reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(NaveId)
        'reporte("NombreReporte") = "SAY: RESUMEN_SALIDA_NAVES.mrt"
        'reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        'reporte("Operador") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.Trim()
        'Dim fechaimp As String = DateTime.Parse(Now).ToString("dd/MM/yyyy HH:mm:ss")
        'reporte("Fecha_Impresion") = DateTime.Parse(Now).ToShortDateString.ToString
        'reporte("Fecha_Salida") = Fecha_Salida.Date.ToString("dd/MM/yyyy")
        'reporte("Hora_Salida") = Fecha_Salida.ToShortTimeString
        'reporte("Folio") = FolioSalidaID
        'reporte("TotalPares") = TotalParesEmbarcados
        'reporte("TotalAtados") = TotalAtadosEmbarcados
        'reporte("TotalLotes") = TotalLotesEmbarcados
        'reporte("Entrega") = entrega
        'reporte("ParesProgramaBien") = ParesProgramaBien
        'reporte("AtadosProgramaBien") = AtadosProgramaBien
        'reporte("LotesProgramaBien") = LotesProgramaBien
        'reporte("ParesProgramaMal") = ParesProgramaMal
        'reporte("AtadosProgramaMal") = AtadosProgramaMal
        'reporte("LotesProgramaMal") = LotesProgramaMal

        'reporte.Dictionary.Clear()
        'reporte.RegData(dtParesAEmbarcar)
        'reporte.Dictionary.Synchronize()
        'reporte.Show()





    End Sub
    Private Sub cmbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProceso.SelectedIndexChanged
        If cmbProceso.Text = "SALIDA" Then
            pnlAcciones.Height = 34
        ElseIf cmbProceso.Text = "ENTRADA" Then
            pnlAcciones.Height = 89
        End If
    End Sub

    Private Sub btnDescartarLotes_Click(sender As Object, e As EventArgs) Handles btnDescartarLotes.Click
        cmsDescartarLotes.Show(btnDescartarLotes, 0, btnDescartarLotes.Height)
    End Sub

    Private Sub LOTESCONERRORESOFALTANTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOTESCONERRORESOFALTANTEToolStripMenuItem.Click
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas eliminar los lotes marcados?"

        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DescartarLotes(1)
        End If


        'Dim objBUSalidas As New Negocios.SalidaNavesBU
        'Dim objBUEntradas As New Negocios.EntradaProductoBU
        'Dim dtTabla As New DataTable
        'Dim lLotesADescartar As New HashSet(Of String)

        'Dim formaConfirmacion As New ConfirmarForm
        'formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        'formaConfirmacion.mensaje = "¿Estas seguro que deseas eliminar los lotes marcados?"

        'If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    For Each row As UltraGridRow In grdIncorrecto.Rows
        '        If row.Cells("Quitar").Value = True Then
        '            lLotesADescartar.Add(row.Cells("Lote").Text + "-" + row.Cells("Año").Text + "-" + IdNave.ToString)
        '        End If
        '    Next

        '    If lLotesADescartar.Count = 0 Then Return

        '    If Proceso = "ENTRADA" Then
        '        objBUEntradas.DescarTarPares_Entrada_De_Producto(IdSalidaNave, lLotesADescartar, IdNave)
        '    Else
        '        objBUSalidas.EliminarParesDeAtadoDescartadoDeLaTablaSalidaNavesDetalles(IdSalidaNave, lLotesADescartar, IdNave)
        '    End If

        '    Dim lLotes_Descartados As New HashSet(Of String)

        '    'DESCARTAMOS LOS LOTES DE LA LISTA DE LOTES LEIDOS
        '    For cont = llotes.Count - 1 To 0 Step -1
        '        For Each item In lLotesADescartar
        '            If llotes(cont).StartsWith(item) = True Then
        '                lLotes_Descartados.Add(llotes(cont))
        '                llotes.Add(llotes(cont) + "-DESCARTADO")
        '            End If
        '        Next

        '    Next
        '    For Each item In lLotes_Descartados
        '        llotes.Remove(item)
        '    Next

        '    'ELIMINAR ATADOS DEL LOTE DEL GRID ERRONEOS
        '    For Each item In lLotesADescartar
        '        Dim Lote() As String
        '        Lote = item.Split("-")
        '        For cont = grdIncorrecto.Rows.Count - 1 To 0 Step -1
        '            If grdIncorrecto.Rows(cont).Cells("Lote").Text = Lote(0) And grdIncorrecto.Rows(cont).Cells("Año").Text = Lote(1) Then
        '                grdIncorrecto.Rows(cont).Delete(True)
        '            End If
        '        Next
        '    Next

        '    LlenarEtiquetas()

        '    Me.Cursor = Cursors.Default
        'End If

    End Sub

    Private Sub LOTESVALIDADOSCORRECTAMENTEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOTESVALIDADOSCORRECTAMENTEToolStripMenuItem.Click
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas eliminar los lotes marcados?"

        If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            DescartarLotes(2)
        End If

    End Sub

    Private Sub DescartarLotes(ByVal TipoOpcion As Integer)
        Dim LotesSeleccionados As New List(Of String)

        Try
            LotesSeleccionados = ObtenerLotesSeleccionadosPendientes(TipoOpcion)

            If LotesSeleccionados.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay lotes seleccionados.")
                Return
            End If


            For Each Fila As String In LotesSeleccionados
                EntSalidaNave.LotesFolio.RemoveAll(Function(x) x.Lote = Fila)
                EntSalidaNave.Pares.RemoveAll(Function(x) x.Lote = Fila)
                EntSalidaNave.Atados.RemoveAll(Function(x) x.PLote = Fila)

                ListaDatosAtado.RemoveAll(Function(x) x.PLote = Fila)
                ListaAtadosPares.RemoveAll(Function(x) x.Lote = Fila)
                ListaPares.RemoveAll(Function(x) x.Lote = Fila)
                ListaAtadosPendientes.RemoveAll(Function(x) x.PLote = Fila)
                ListaParesErroneos.RemoveAll(Function(x) x.Lote = Fila)

                AtadosDescartados = dtAtadosALeer.AsEnumerable().Where(Function(x) x.Item("Lote") = Fila).Count
                ParesDescartados = dtParesALeer.AsEnumerable().Where(Function(x) x.Item("Lote") = Fila).Count
                LotesDescartados.Add(Fila)

                'Dim FilasParesEliminar = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = Fila)
                'For Each Elemento As DataRow In FilasParesEliminar
                '    dtParesALeer.Rows.Remove(Elemento)
                'Next

                Dim FilasParesEliminar = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = Fila).Count
                For index As Integer = 1 To FilasParesEliminar

                    Dim index_borrar = dtParesALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = Fila).FirstOrDefault
                    ListaParesDescartados.Add(index_borrar.Item("Par").ToString)
                    dtParesALeer.Rows.Remove(index_borrar)

                Next



                'Dim ParesABorrar = ListaPares.Where(Function(x) x.Atado = DatosAtado.PIdAtado).Count

                'For index As Integer = 1 To ParesABorrar
                '    Dim index_borrar = ListaPares.FindIndex(Function(x) x.Atado = DatosAtado.PIdAtado)
                '    ListaPares.RemoveAt(index_borrar)
                'Next


                'Dim FilasAtadosEliminar = dtAtadosALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = Fila)
                'For Each Elemento As DataRow In FilasAtadosEliminar
                '    dtAtadosALeer.Rows.Remove(Elemento)
                'Next

                Dim FilasAtadosEliminar = dtAtadosALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = Fila).Count
                For index As Integer = 1 To FilasAtadosEliminar
                    Dim index_borrar = dtAtadosALeer.AsEnumerable.Where(Function(x) x.Item("Lote") = Fila).FirstOrDefault
                    ListaAtadosDescartados.Add(index_borrar.Item("Atado").ToString)
                    dtAtadosALeer.Rows.Remove(index_borrar)
                Next


                If EntSalidaNave.TipoProceso = "ENTRADA" Then
                    ObjBU.DescartarLotesEntrada(EntSalidaNave.IdSalidaNave, Fila)
                ElseIf EntSalidaNave.TipoProceso = "SALIDA" Then
                    ObjBU.DescartarLotes(EntSalidaNave.IdSalidaNave, Fila)
                End If


            Next

            txtcapturacodigos.Text = ""
            lblCodigoOculto.Text = ""
            lblCodigoOculto.Focus()
            CargarAtadosPendientes()
            ActualizarGridPares()
            CargarResumenPares()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function ObtenerLotesSeleccionadosPendientes(ByVal Opcion As Integer) As List(Of String)
        Dim Lista As New List(Of String)

        Try
            If Opcion = 1 Then 'LOTES CON ERRORES O FALTANTE 
                Dim FilasSeleccionadas = grdIncorrecto.Rows.Where(Function(x) CBool(x.Cells("PSeleccionar").Value) = True)

                For Each Fila As UltraGridRow In FilasSeleccionadas

                    If Lista.Exists(Function(x) x.ToString = Fila.Cells("PLote").Value) = False Then
                        Lista.Add(Fila.Cells("PLote").Value)
                    End If
                Next

            Else 'LOTES VALIDADOS CORRECTAMENTE 
                Dim FilasSeleccionadas = grdLectura.ActiveRow

                If Lista.Exists(Function(x) x.ToString = FilasSeleccionadas.Cells("Lote").Value) = False Then
                    Lista.Add(FilasSeleccionadas.Cells("Lote").Value)
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return Lista

    End Function

    Private Sub btnPlataformas_Click(sender As Object, e As EventArgs) Handles btnPlataformas.Click
        Dim PlataformasForm As New CodigosErrorEntradaSalidaNaveForm
        Try

            PlataformasForm.IdSalidaNave = EntSalidaNave.IdSalidaNave
            PlataformasForm.TipoProceso = EntSalidaNave.TipoProceso
            PlataformasForm.Plataformas = True
            PlataformasForm.ShowDialog()

        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnMuestras_Click(sender As Object, e As EventArgs) Handles btnMuestras.Click
        Dim EntradaSalidaMuestrasForm As New Programacion.Vista.PedidosMuestras_SalidasEntradas
        EntradaSalidaMuestrasForm.Show()

    End Sub

    Private Sub DesbloquearControlesGuardar()
        cmbNaves.Enabled = True
        cmbNaves.SelectedIndex = 0
        cmbProceso.Enabled = True
        cmbProceso.SelectedIndex = 0
        btnGuardar.Enabled = False

    End Sub

    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        If cmbProceso.Text = "SALIDA" Then
            cmsSalidaNaves.Show(btnImprimirReporte, 0, btnImprimirReporte.Height)
        ElseIf cmbProceso.Text = "ENTRADA" Then
            cmsEntradaProducto.Show(btnImprimirReporte, 0, btnImprimirReporte.Height)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleccione un proceso para mostrar las opciones de reportes disponibles.")
        End If
    End Sub

    Private Sub SalidaDeLotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalidaDeLotesToolStripMenuItem.Click
        Dim FormaMensaje As New ImprimirReporteSalidaNaveFormv2
        FormaMensaje.IdNave = cmbNaves.SelectedValue
        FormaMensaje.ShowDialog()

        If FormaMensaje.Imprimir = True Then
            ReporteSalida(FormaMensaje.IdSalidaNave, FormaMensaje.IdNave)
            'ImprimirReporte_Salida_Naves(FormaMensaje.IdSalidaNave, FormaMensaje.IdNave, FormaMensaje.NombreOperador)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SALIDADELOTESDENAVEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SALIDADELOTESDENAVEToolStripMenuItem.Click
        Dim FormaMensaje As New ImprimirReporteSalidaNaveFormv2
        FormaMensaje.IdNave = cmbNaves.SelectedValue
        FormaMensaje.ShowDialog()

        If FormaMensaje.Imprimir = True Then
            ReporteSalida(FormaMensaje.IdSalidaNave, FormaMensaje.IdNave)
            'ImprimirReporte_Salida_Naves(FormaMensaje.IdSalidaNave, FormaMensaje.IdNave, FormaMensaje.NombreOperador)
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RESULTADODEENTRADADEPRODUCTOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESULTADODEENTRADADEPRODUCTOToolStripMenuItem.Click
        ImprimirReporte_Entrada_Almacen()
    End Sub

    Private Sub ImprimirReporte_Entrada_Almacen()
        Dim dsTotalesDeSalidas As New DataSet
        Dim dtTotalesEntrada As New DataTable
        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalPares As Integer = 0
        Dim TotalAtados As Integer = 0
        Dim TotalLotes As Integer = 0
        Dim lProgramas As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim NumeroAlmacen As Integer = 0
        Dim nombreArchivo As String
        Dim Comercializadora_ID As Integer = 0

        Dim formaFecha As New InformacionSecundarioEntradaDeLotesForm
        formaFecha.StartPosition = FormStartPosition.CenterScreen
        formaFecha.Reporte = True
        formaFecha.IdNave = cmbNaves.SelectedValue
        formaFecha.NumeroAlmacen = cboxAlmacen.SelectedValue
        formaFecha.ShowDialog()

        Fecha_Inicio = formaFecha.fecha_Inicio
        Fecha_Fin = formaFecha.fecha_fin
        Id_Nave = formaFecha.IdNave
        NumeroAlmacen = formaFecha.NumeroAlmacen
        Comercializadora_ID = formaFecha.ComercializadoraId


        Me.Cursor = Cursors.WaitCursor
        If formaFecha.fecha_Inicio = "" Or formaFecha.IdNave = 0 Then
            Me.Cursor = Cursors.Default
            Return
        End If
        'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
        dsTotalesDeSalidas = Recuperar_Informacion_Reporte_Entradas(Fecha_Inicio, Fecha_Fin, Id_Nave, NumeroAlmacen, Comercializadora_ID)


        If dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows.Count = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontro información.")
            Me.Cursor = Cursors.Default
            Return
        End If

        'Recuperamos los totales
        For Each row As DataRow In dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows
            TotalPares = TotalPares + row.Item("Pares")
            TotalAtados = TotalAtados + row.Item("Atados")
            TotalLotes = TotalLotes + row.Item("lotes")
            lProgramas.Add(row.Item("Programa"))
        Next

        'Recuperar el Nombre del Operador
        Operador = ObjBU.ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)


        dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsTotalesDeSalidas.Tables("dtTotalesRecibidos"), Fecha_Inicio)
        Dim ParesProgramaBien As Integer = 0
        Dim AtadosProgramaBien As Integer = 0
        Dim LotesProgramaBien As Integer = 0
        Dim ParesProgramaMal As Integer = 0
        Dim AtadosProgramaMal As Integer = 0
        Dim LotesProgramaMal As Integer = 0

        ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
        AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
        LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
        ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
        AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
        LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")


        Dim OBJBU2 As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU2.LeerReporteporClave("ALM_ENTRADAS_RESUMEN")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(Comercializadora_ID)
        reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
        reporte("NombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Recibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
        reporte("Operador") = Operador
        reporte("fecha_inicio") = DateTime.Parse(Fecha_Inicio).ToShortDateString
        reporte("fecha_fin") = DateTime.Parse(Fecha_Inicio).ToShortDateString
        reporte("TotalPares") = TotalPares
        reporte("TotalAtados") = TotalAtados
        reporte("TotalLotes") = TotalLotes
        reporte("TotalProgramas") = lProgramas.Count
        reporte("ParesProgramaBien") = ParesProgramaBien
        reporte("AtadosProgramaBien") = AtadosProgramaBien
        reporte("LotesProgramaBien") = LotesProgramaBien
        reporte("ParesProgramaMal") = ParesProgramaMal
        reporte("AtadosProgramaMal") = AtadosProgramaMal
        reporte("LotesProgramaMal") = LotesProgramaMal

        reporte.Dictionary.Clear()
        reporte.RegData(dsTotalesDeSalidas)
        reporte.Dictionary.Synchronize()

        reporte.Render()



        Dim JoinReport2 As StiReport = New StiReport
        JoinReport2.NeedsCompiling = False
        JoinReport2.IsRendered = True
        JoinReport2.RenderedPages.Clear()

        If IsNothing(reporte.CompiledReport) = False Then

            For Each Page2 As Stimulsoft.Report.Components.StiPage In reporte.CompiledReport.RenderedPages
                Page2.Report = JoinReport2
                Page2.NewGuid()
                JoinReport2.RenderedPages.Add(Page2)
            Next
        End If



        Dim isnave = ObjBU.Consultar_Si_Es_Maquila(Id_Nave)

        If isnave.Rows.Count <> 0 Then
            EnviarCorrerREST(Id_Nave, NumeroAlmacen, Fecha_Inicio, Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString, Comercializadora_ID)
        End If

        reporte.Show()
        Me.Cursor = Cursors.Default


    End Sub

    Private Function Recuperar_Informacion_Reporte_Entradas(ByVal Fecha_Inicio As String, ByVal Fecha_Fin As String, ByVal IdNave As Integer, ByVal NumeroAlmacen As Integer, ByVal ComercializadoraId As Integer)

        Dim dsTotalesDeSalidas As New DataSet("dsTotalesDeSalidas")
        Dim dtTotalesRecibidos As New DataTable("dtTotalesRecibidos")
        Dim dtTotalesNoEmbarcadosLeidos As New DataTable("dtTotalesNoEmbarcadosLeidos")
        Dim dtTotalesFaltantes As New DataTable("dtTotalesFaltantes")

        dtTotalesRecibidos = ObjBU.ObtenerTotalParesRecibidos(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen, ComercializadoraId)
        dtTotalesNoEmbarcadosLeidos = ObjBU.ObtenerTotalParesNoEmbarcados(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen, ComercializadoraId)
        dtTotalesFaltantes = ObjBU.ObtenerTotalParesFaltantes(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen, ComercializadoraId)

        dtTotalesRecibidos.TableName = "dtTotalesRecibidos"
        dtTotalesNoEmbarcadosLeidos.TableName = "dtTotalesNoEmbarcadosLeidos"
        dtTotalesFaltantes.TableName = "dtTotalesFaltantes"

        dsTotalesDeSalidas.Tables.Add(dtTotalesRecibidos)
        dsTotalesDeSalidas.Tables.Add(dtTotalesNoEmbarcadosLeidos)
        dsTotalesDeSalidas.Tables.Add(dtTotalesFaltantes)

        Return dsTotalesDeSalidas
    End Function

    Private Function RecuperarCantidadesProgramasEnTiempoYAtrasados(ByVal dtTabla As DataTable, ByVal fecha_Salida As Date) As DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim Dias As Integer
        Dim programa As Date
        Dim ParesBien As Integer = 0
        Dim ParesMal As Integer = 0
        Dim AtadosBien As Integer = 0
        Dim AtadosMal As Integer = 0
        Dim LotesBien As Integer = 0
        Dim LotesMal As Integer = 0
        Dim diasTotales As Double = 0

        For Each row As DataRow In dtTabla.Rows
            programa = row.Item("Programa")
            Dias = (fecha_Salida - programa).TotalDays
            'borrar---------------------------------------------------------------------------
            Dias = DateDiff(DateInterval.Day, programa, fecha_Salida) 'dias que existen entre el rango de fechas
            For index As Integer = 1 To Dias
                If index = 1 Then
                    If programa.Month = 3 Then
                        If programa.Day = 21 Then
                        ElseIf programa.Day = 22 Then
                        ElseIf programa.Day = 23 Then
                        ElseIf programa.Day = 24 Then
                        ElseIf programa.Day = 25 Then
                        ElseIf programa.Day = 26 Then
                        ElseIf programa.Day = 27 Then
                            If Not programa.DayOfWeek = 0 Then
                                diasTotales = diasTotales + 1
                            End If
                        Else
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                End If
                If DateAdd(DateInterval.Day, index, programa).Month = 3 Then
                    If DateAdd(DateInterval.Day, index, programa).Day = 21 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 22 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 23 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 24 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 25 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 26 Then
                    ElseIf DateAdd(DateInterval.Day, index, programa).Day = 27 Then
                        If Not DateAdd(DateInterval.Day, index, programa).DayOfWeek = 0 Then
                            diasTotales = diasTotales + 1
                        End If
                    Else
                        diasTotales = diasTotales + 1
                    End If
                Else
                    diasTotales = diasTotales + 1
                End If
            Next
            Dias = diasTotales
            'borrar---------------------------------------------------------------------------
            'Dias = 14
            If Dias <= 5 Then
                ParesBien += row.Item("PARES")
                AtadosBien += row.Item("ATADOS")
                LotesBien += 1
            ElseIf Dias = 6 Then
                If (programa.DayOfWeek = 3 And fecha_Salida.DayOfWeek = 1) Or
                    (programa.DayOfWeek = 4 And fecha_Salida.DayOfWeek = 2) Or
                    (programa.DayOfWeek = 5 And fecha_Salida.DayOfWeek = 3) Or
                    (programa.DayOfWeek = 6 And fecha_Salida.DayOfWeek = 4) Then
                    ParesBien += row.Item("PARES")
                    AtadosBien += row.Item("ATADOS")
                    LotesBien += 1
                Else
                    ParesMal += row.Item("PARES")
                    AtadosMal += row.Item("ATADOS")
                    LotesMal += 1
                End If
            Else
                ParesMal += row.Item("PARES")
                AtadosMal += row.Item("ATADOS")
                LotesMal += 1
            End If
            diasTotales = 0
        Next

        Dim columns As DataColumnCollection = dtTablaCantidadesProgramas.Columns
        Dim columna0 As New DataColumn
        columna0.DataType = Type.GetType("System.Double")
        columna0.DefaultValue = 0
        columna0.ColumnName = "Pares"
        columns.Add(columna0)

        Dim columna1 As New DataColumn
        columna1.DataType = Type.GetType("System.Double")
        columna1.DefaultValue = 0
        columna1.ColumnName = "Atados"
        columns.Add(columna1)

        Dim columna2 As New DataColumn
        columna2.DataType = Type.GetType("System.Double")
        columna2.DefaultValue = 0
        columna2.ColumnName = "Lotes"
        columns.Add(columna2)

        Dim newCustomersRow As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow("Pares") = ParesBien
        newCustomersRow("Atados") = AtadosBien
        newCustomersRow("Lotes") = LotesBien
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow)

        Dim newCustomersRow1 As DataRow = dtTablaCantidadesProgramas.NewRow()
        newCustomersRow1("Pares") = ParesMal
        newCustomersRow1("Atados") = AtadosMal
        newCustomersRow1("Lotes") = LotesMal
        dtTablaCantidadesProgramas.Rows.Add(newCustomersRow1)

        dtTablaCantidadesProgramas.TableName = "dtTablaCantidadesProgramas"

        Return dtTablaCantidadesProgramas
    End Function



    Private Sub ImprimirReporte_Entrada_Almacen(ByVal NaveID As Integer, ByVal NumeroAlmacen As Integer, ByVal Fecha As Date, ByVal ComercializadoraId As Integer)
        Dim dsTotalesDeSalidas As New DataSet
        Dim dtTotalesEntrada As New DataTable
        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalPares As Integer = 0
        Dim TotalAtados As Integer = 0
        Dim TotalLotes As Integer = 0
        Dim lProgramas As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramas As New DataTable
        Dim nombreArchivo As String
        Try

            Fecha_Inicio = Fecha
            Fecha_Fin = Fecha
            Id_Nave = NaveID
            NumeroAlmacen = NumeroAlmacen

            Me.Cursor = Cursors.WaitCursor
            'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
            dsTotalesDeSalidas = Recuperar_Informacion_Reporte_Entradas(Fecha_Inicio, Fecha_Fin, Id_Nave, NumeroAlmacen, ComercializadoraId)


            If dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se encontro información.")
                Me.Cursor = Cursors.Default
                Return
            End If

            'Recuperamos los totales
            For Each row As DataRow In dsTotalesDeSalidas.Tables("dtTotalesRecibidos").Rows
                TotalPares = TotalPares + row.Item("Pares")
                TotalAtados = TotalAtados + row.Item("Atados")
                TotalLotes = TotalLotes + row.Item("lotes")
                lProgramas.Add(row.Item("Programa"))
            Next

            'Recuperar el Nombre del Operador
            Operador = ObjBU.ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramas = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsTotalesDeSalidas.Tables("dtTotalesRecibidos"), Fecha_Inicio)
            Dim ParesProgramaBien As Integer = 0
            Dim AtadosProgramaBien As Integer = 0
            Dim LotesProgramaBien As Integer = 0
            Dim ParesProgramaMal As Integer = 0
            Dim AtadosProgramaMal As Integer = 0
            Dim LotesProgramaMal As Integer = 0

            ParesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Pares")
            AtadosProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Atados")
            LotesProgramaBien = dtTablaCantidadesProgramas.Rows(0).Item("Lotes")
            ParesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Pares")
            AtadosProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Atados")
            LotesProgramaMal = dtTablaCantidadesProgramas.Rows(1).Item("Lotes")


            Dim OBJBU2 As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJBU2.LeerReporteporClave("ALM_ENTRADAS_RESUMEN")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(ComercializadoraId)
            reporte("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
            reporte("NombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte("Recibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
            reporte("Operador") = Operador
            reporte("fecha_inicio") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte("fecha_fin") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte("TotalPares") = TotalPares
            reporte("TotalAtados") = TotalAtados
            reporte("TotalLotes") = TotalLotes
            reporte("TotalProgramas") = lProgramas.Count
            reporte("ParesProgramaBien") = ParesProgramaBien
            reporte("AtadosProgramaBien") = AtadosProgramaBien
            reporte("LotesProgramaBien") = LotesProgramaBien
            reporte("ParesProgramaMal") = ParesProgramaMal
            reporte("AtadosProgramaMal") = AtadosProgramaMal
            reporte("LotesProgramaMal") = LotesProgramaMal

            reporte.Dictionary.Clear()
            reporte.RegData(dsTotalesDeSalidas)
            reporte.Dictionary.Synchronize()

            reporte.Render()

            Dim JoinReport As StiReport = New StiReport
            JoinReport.NeedsCompiling = False
            JoinReport.IsRendered = True
            JoinReport.RenderedPages.Clear()

            Dim JoinReport2 As StiReport = New StiReport
            JoinReport2.NeedsCompiling = False
            JoinReport2.IsRendered = True
            JoinReport2.RenderedPages.Clear()

            If IsNothing(reporte.CompiledReport) = False Then

                For Each Page2 As Stimulsoft.Report.Components.StiPage In reporte.CompiledReport.RenderedPages
                    Page2.Report = JoinReport2
                    Page2.NewGuid()
                    JoinReport2.RenderedPages.Add(Page2)
                Next
            End If



            Dim isnave = ObjBU.Consultar_Si_Es_Maquila(Id_Nave)

            If isnave.Rows.Count <> 0 Then
                EnviarCorrerREST(NaveID, NumeroAlmacen, Fecha_Inicio, Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString, Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString, ComercializadoraId)
            End If
            reporte.Show()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function ValidarAtadoEntrada(ByVal CodigoLeido As String) As Entidades.CapturaAtadoValido
        Dim DatosAtadoAux As New Entidades.CapturaAtadoValido
        Dim StatusId As Integer = 0

        Try
            DatosAtadoAux = ObjBU.ValidarAtadoEntrada(CodigoLeido)
        Catch ex As Exception
            Throw ex
        End Try

        Return DatosAtadoAux
    End Function

    Private Sub InsertarAtadoInvalido(ByVal Cadena As String)

        Dim AtadoLeido As New Entidades.CapturaAtadoValido
        AtadoLeido = ValidarAtadoEntrada(Cadena)
        If AtadoLeido.PIdAtado <> "0" Then
            AtadoLeido.PStatusAtado = 11
            AtadoLeido.PIdNAve = cmbNaves.SelectedValue
            ListaAtadosPendientes.Add(AtadoLeido)
            ObjBU.InsertarAtadoNoEmbarcado(EntSalidaNave.IdSalidaNave, AtadoLeido.PIdAtado, AtadoLeido.PAño, AtadoLeido.PDescripcion, AtadoLeido.PIdCliente, AtadoLeido.PIdNAve, AtadoLeido.PLote, AtadoLeido.PNumeroAtado, AtadoLeido.PN_Pares, AtadoLeido.PStatusAtado)
        End If

    End Sub

    Private Sub btnActualizarPrecios_Click(sender As Object, e As EventArgs) Handles btnActualizarPrecios.Click
        Try
            Cursor = Cursors.WaitCursor
            ObjBU.ActuallizarPrecio()
            Cursor = Cursors.Default
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han actualizado los precios.")
        Catch ex As Exception
            Tools.Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString)
        End Try


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Try
            Cursor = Cursors.WaitCursor
            If cmbNaves.Text <> "" Then
                ObjBU.LimpiarParesErrores(cmbNaves.SelectedValue)
            End If
            Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han limpiado los pares.")
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub lblCodigoOculto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lblCodigoOculto.KeyPress



        Dim CadenaCapturada As String = String.Empty

        If e.KeyChar = ChrW(Keys.Enter) Then

            ''''txtcapturacodigos.Text = lblCodigoOculto.Text.ToUpper

            ''''If (LTrim(RTrim(lblCodigoOculto.Text))) = "" Then Return
            '''''Ventas_Reportes_ReporteGeneralVentasAgenteForm



            '' CAMBIOS (10/08/2024) - Se agerga una validación para la solución de los códigos de par con misma configuración de atado.
            txtcapturacodigos.Text = lblCodigoOculto.Text.ToUpper
            Dim codigoRecuperado As String = ObjBU.VerficarAtadoPar(txtcapturacodigos.Text)

            If codigoRecuperado <> "" Then
                txtcapturacodigos.Text = codigoRecuperado.ToUpper
                lblCodigoOculto.Text = codigoRecuperado.ToUpper
            End If
            '' CAMBIOS (10/08/2024) - Se agrega una validación para la solución de los códigos de par con misma configuración de atado.



            CadenaCapturada = (LTrim(RTrim(lblCodigoOculto.Text.ToUpper))).Replace("'", "-")
            CadenaCapturada = Replace(CadenaCapturada, "PC", "Y-000-") 'CarlosMtz (Replace para codigos Coppel)
            If CadenaCapturada.Substring(0, 1) = "0" Then
                'CadenaCapturada = CadenaCapturada.Substring(1, CadenaCapturada.Length - 1)
                CadenaCapturada = CadenaCapturada.TrimStart("0").ToUpper()
            End If


            If EntSalidaNave.TipoProceso = "SALIDA" Then
                CapturaParAtadosYuyin(CadenaCapturada)
            Else
                CapturaParAtadosYuyinEntrada(CadenaCapturada)
                'CapturarParAtados_EntradaNave(CadenaCapturada)
            End If
            txtcapturacodigos.Text = ""
            lblCodigoOculto.Text = ""
            lblCodigoOculto.Focus()
            txtcapturacodigos.Focus()
            CargarAtadosPendientes()
            ActualizarGridPares()
            CargarResumenPares()

        Else
            lblCodigoOculto.Text += e.KeyChar.ToString().ToUpper
        End If

    End Sub

    'Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click
    '    lblCodigoOculto.Focus()


    'End Sub

    Private Sub lblCodigoOculto_TextChanged(sender As Object, e As EventArgs) Handles lblCodigoOculto.TextChanged

    End Sub



    Private Function ImprimirReporte_Facturacion_Remision(ByVal fechaInicio As String, ByVal fechafin As String, ByVal IdNave As Integer, ByVal Numero_Almacen As Integer, ByVal ComercializadoraId As Integer) As Integer

        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalParesf As Integer = 0
        Dim TotalAtadosf As Integer = 0
        Dim TotalLotesf As Integer = 0
        Dim lProgramasf As New HashSet(Of String)
        Dim TotalParesr As Integer = 0
        Dim TotalAtadosr As Integer = 0
        Dim TotalLotesr As Integer = 0
        Dim lProgramasr As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramasF As New DataTable
        Dim dtTablaCantidadesProgramasR As New DataTable
        Dim NumeroAlmacen As Integer = 0

        Try


            Fecha_Inicio = fechaInicio
            Fecha_Fin = fechafin
            Id_Nave = IdNave
            NumeroAlmacen = Numero_Almacen


            Me.Cursor = Cursors.WaitCursor
            'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
            Dim dsFacturacion As New DataSet("dsFacturados")
            Dim dsRemision As New DataSet("dsRemision")
            Dim dtFacturacion As New DataTable("dtFacturados")
            Dim dtRemision As New DataTable("dtRemision")

            dtFacturacion = ObjBU.ObtenerTotalParesFacturados_o_Remisionados(Id_Nave, Fecha_Inicio, 1, NumeroAlmacen, ComercializadoraId)
            dtRemision = ObjBU.ObtenerTotalParesFacturados_o_Remisionados(Id_Nave, Fecha_Inicio, 0, NumeroAlmacen, ComercializadoraId)
            ' dtTotalesFaltantes = ObjBU.ObtenerTotalParesFaltantes(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen)




            dtFacturacion.TableName = "dtFacturados"
            dtRemision.TableName = "dtRemision"
            'dtTotalesFaltantes.TableName = "dtTotalesFaltantes"

            dsFacturacion.Tables.Add(dtFacturacion)
            dsRemision.Tables.Add(dtRemision)
            'dsTotalesDeSalidas.Tables.Add(dtTotalesFaltantes)



            If dsFacturacion.Tables("dtFacturados").Rows.Count = 0 Then

                Me.Cursor = Cursors.Default
                Return 0
            End If

            'Recuperamos los totales
            For Each row As DataRow In dsFacturacion.Tables("dtFacturados").Rows
                TotalParesf = TotalParesf + row.Item("Pares")
                TotalAtadosf = TotalAtadosf + row.Item("Atados")
                TotalLotesf = TotalLotesf + row.Item("lotes")
                lProgramasf.Add(row.Item("Programa"))
            Next

            'Recuperamos los totales
            For Each row As DataRow In dsRemision.Tables("dtRemision").Rows
                TotalParesr = TotalParesr + row.Item("Pares")
                TotalAtadosr = TotalAtadosr + row.Item("Atados")
                TotalLotesr = TotalLotesr + row.Item("lotes")
                lProgramasr.Add(row.Item("Programa"))
            Next

            'Recuperar el Nombre del Operador
            Operador = ObjBU.ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramasF = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsFacturacion.Tables("dtFacturados"), Fecha_Inicio)
            Dim ParesProgramaBienF As Integer = 0
            Dim AtadosProgramaBienF As Integer = 0
            Dim LotesProgramaBienF As Integer = 0
            Dim ParesProgramaMalF As Integer = 0
            Dim AtadosProgramaMalF As Integer = 0
            Dim LotesProgramaMalF As Integer = 0

            ParesProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Pares")
            AtadosProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Atados")
            LotesProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Lotes")
            ParesProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Pares")
            AtadosProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Atados")
            LotesProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Lotes")

            'Recuperar el Nombre del Operador
            Operador = ObjBU.ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramasR = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsRemision.Tables("dtRemision"), Fecha_Inicio)
            Dim ParesProgramaBienR As Integer = 0
            Dim AtadosProgramaBienR As Integer = 0
            Dim LotesProgramaBienR As Integer = 0
            Dim ParesProgramaMalR As Integer = 0
            Dim AtadosProgramaMalR As Integer = 0
            Dim LotesProgramaMalR As Integer = 0

            ParesProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Pares")
            AtadosProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Atados")
            LotesProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Lotes")
            ParesProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Pares")
            AtadosProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Atados")
            LotesProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Lotes")



            Dim OBJBU2 As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            EntidadReporte = OBJBU2.LeerReporteporClave("REPORTE_ENTRADAS_FACT_REM")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte2.Load(archivo)
            reporte2.Compile()
            reporte2("urlImagenNave") = Tools.Controles.ObtenerLogoNave(ComercializadoraId)
            reporte2("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
            reporte2("nombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
            reporte2("nombreCreo") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte2("nombreRecibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
            reporte2("Operador") = Operador
            reporte2("fecha") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte2("fecha_impresion") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte2("TotalParesF") = TotalParesf
            reporte2("TotalAtadosF") = TotalAtadosf
            reporte2("TotalLotesF") = TotalLotesf
            reporte2("TotalProgramasF") = lProgramasf.Count
            reporte2("ParesProgramadosBienF") = ParesProgramaBienF
            reporte2("AtadosProgramadosBienF") = AtadosProgramaBienF
            reporte2("LotesProgramadosBienF") = LotesProgramaBienF
            reporte2("ParesProgramadosMalF") = ParesProgramaMalF
            reporte2("AtadosProgramadosMalF") = AtadosProgramaMalF
            reporte2("LotesProgramadosMalF") = LotesProgramaMalF
            reporte2("TotalParesR") = TotalParesr
            reporte2("TotalAtadosR") = TotalAtadosr
            reporte2("TotalLotesR") = TotalLotesr
            reporte2("TotalProgramasR") = lProgramasf.Count
            reporte2("ParesProgramadosBienR") = ParesProgramaBienR
            reporte2("AtadosProgramadosBienR") = AtadosProgramaBienR
            reporte2("LotesProgramadosBienR") = LotesProgramaBienR
            reporte2("ParesProgramadosMalR") = ParesProgramaMalR
            reporte2("AtadosProgramadosMalR") = AtadosProgramaMalR
            reporte2("LotesProgramadosMalR") = LotesProgramaMalR

            reporte2.Dictionary.Clear()
            reporte2.RegData(dsFacturacion)
            reporte2.RegData(dsRemision)
            reporte2.Dictionary.Synchronize()

            Return 1
            Me.Cursor = Cursors.Default



        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function ImprimirReporte_Facturacion_Remision_sin_precio(ByVal fechaInicio As String, ByVal fechafin As String, ByVal IdNave As Integer, ByVal Numero_Almacen As Integer, ByVal ComercializadoraId As Integer) As Integer

        Dim Fecha_Inicio As String
        Dim Fecha_Fin As String
        Dim Operador As String
        Dim TotalParesf As Integer = 0
        Dim TotalAtadosf As Integer = 0
        Dim TotalLotesf As Integer = 0
        Dim lProgramasf As New HashSet(Of String)
        Dim TotalParesr As Integer = 0
        Dim TotalAtadosr As Integer = 0
        Dim TotalLotesr As Integer = 0
        Dim lProgramasr As New HashSet(Of String)
        Dim Id_Nave As Integer
        Dim Tabla_dataSet_Recuperada As New DataTable
        Dim dtTablaCantidadesProgramasF As New DataTable
        Dim dtTablaCantidadesProgramasR As New DataTable
        Dim NumeroAlmacen As Integer = 0

        Try


            Fecha_Inicio = fechaInicio
            Fecha_Fin = fechafin
            Id_Nave = IdNave
            NumeroAlmacen = Numero_Almacen


            Me.Cursor = Cursors.WaitCursor
            'RECUPERAMOS LOS TOTALES DE LOS PARES EMBARCADOS DIVIDIDOS POR LOTES Y OBTENIENDOP DETALLES DE CADA LOTE PARA EL REPORTE
            Dim dsFacturacion As New DataSet("dsFacturados")
            Dim dsRemision As New DataSet("dsRemision")
            Dim dtFacturacion As New DataTable("dtFacturados")
            Dim dtRemision As New DataTable("dtRemision")

            dtFacturacion = ObjBU.ObtenerTotalParesFacturados_o_Remisionados(Id_Nave, Fecha_Inicio, 1, NumeroAlmacen, ComercializadoraId)
            dtRemision = ObjBU.ObtenerTotalParesFacturados_o_Remisionados(Id_Nave, Fecha_Inicio, 0, NumeroAlmacen, ComercializadoraId)
            ' dtTotalesFaltantes = ObjBU.ObtenerTotalParesFaltantes(IdNave, Fecha_Inicio, Fecha_Fin, NumeroAlmacen)




            dtFacturacion.TableName = "dtFacturados"
            dtRemision.TableName = "dtRemision"
            'dtTotalesFaltantes.TableName = "dtTotalesFaltantes"

            dsFacturacion.Tables.Add(dtFacturacion)
            dsRemision.Tables.Add(dtRemision)
            'dsTotalesDeSalidas.Tables.Add(dtTotalesFaltantes)



            If dsFacturacion.Tables("dtFacturados").Rows.Count = 0 Then

                Me.Cursor = Cursors.Default
                Return 0
            End If

            'Recuperamos los totales
            For Each row As DataRow In dsFacturacion.Tables("dtFacturados").Rows
                TotalParesf = TotalParesf + row.Item("Pares")
                TotalAtadosf = TotalAtadosf + row.Item("Atados")
                TotalLotesf = TotalLotesf + row.Item("lotes")
                lProgramasf.Add(row.Item("Programa"))
            Next

            'Recuperamos los totales
            For Each row As DataRow In dsRemision.Tables("dtRemision").Rows
                TotalParesr = TotalParesr + row.Item("Pares")
                TotalAtadosr = TotalAtadosr + row.Item("Atados")
                TotalLotesr = TotalLotesr + row.Item("lotes")
                lProgramasr.Add(row.Item("Programa"))
            Next

            'Recuperar el Nombre del Operador
            Operador = ObjBU.ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramasF = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsFacturacion.Tables("dtFacturados"), Fecha_Inicio)
            Dim ParesProgramaBienF As Integer = 0
            Dim AtadosProgramaBienF As Integer = 0
            Dim LotesProgramaBienF As Integer = 0
            Dim ParesProgramaMalF As Integer = 0
            Dim AtadosProgramaMalF As Integer = 0
            Dim LotesProgramaMalF As Integer = 0

            ParesProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Pares")
            AtadosProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Atados")
            LotesProgramaBienF = dtTablaCantidadesProgramasF.Rows(0).Item("Lotes")
            ParesProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Pares")
            AtadosProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Atados")
            LotesProgramaMalF = dtTablaCantidadesProgramasF.Rows(1).Item("Lotes")

            'Recuperar el Nombre del Operador
            Operador = ObjBU.ObtenerNombreOperadorReporteEntrada(Id_Nave, Fecha_Inicio, Fecha_Fin)
            dtTablaCantidadesProgramasR = RecuperarCantidadesProgramasEnTiempoYAtrasados(dsRemision.Tables("dtRemision"), Fecha_Inicio)
            Dim ParesProgramaBienR As Integer = 0
            Dim AtadosProgramaBienR As Integer = 0
            Dim LotesProgramaBienR As Integer = 0
            Dim ParesProgramaMalR As Integer = 0
            Dim AtadosProgramaMalR As Integer = 0
            Dim LotesProgramaMalR As Integer = 0

            ParesProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Pares")
            AtadosProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Atados")
            LotesProgramaBienR = dtTablaCantidadesProgramasR.Rows(0).Item("Lotes")
            ParesProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Pares")
            AtadosProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Atados")
            LotesProgramaMalR = dtTablaCantidadesProgramasR.Rows(1).Item("Lotes")



            Dim OBJBU2 As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes

            EntidadReporte = OBJBU2.LeerReporteporClave("REPORTE_ENTRADAS_FACT_REM_SP")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            reporte3.Load(archivo)
            reporte3.Compile()
            reporte3("urlImagenNave") = Tools.Controles.ObtenerLogoNave(ComercializadoraId)
            reporte3("nombreNave") = Tools.Controles.RecuperarNombreNave(Id_Nave)
            reporte3("nombreReporte") = "SAY: RESUMEN_ENTRADAS_ALMACEN.mrt"
            reporte3("nombreCreo") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
            reporte3("nombreRecibio") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString
            reporte3("Operador") = Operador
            reporte3("fecha") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte3("fecha_impresion") = DateTime.Parse(Fecha_Inicio).ToShortDateString
            reporte3("TotalParesF") = TotalParesf
            reporte3("TotalAtadosF") = TotalAtadosf
            reporte3("TotalLotesF") = TotalLotesf
            reporte3("TotalProgramasF") = lProgramasf.Count
            reporte3("ParesProgramadosBienF") = ParesProgramaBienF
            reporte3("AtadosProgramadosBienF") = AtadosProgramaBienF
            reporte3("LotesProgramadosBienF") = LotesProgramaBienF
            reporte3("ParesProgramadosMalF") = ParesProgramaMalF
            reporte3("AtadosProgramadosMalF") = AtadosProgramaMalF
            reporte3("LotesProgramadosMalF") = LotesProgramaMalF
            reporte3("TotalParesR") = TotalParesr
            reporte3("TotalAtadosR") = TotalAtadosr
            reporte3("TotalLotesR") = TotalLotesr
            reporte3("TotalProgramasR") = lProgramasf.Count
            reporte3("ParesProgramadosBienR") = ParesProgramaBienR
            reporte3("AtadosProgramadosBienR") = AtadosProgramaBienR
            reporte3("LotesProgramadosBienR") = LotesProgramaBienR
            reporte3("ParesProgramadosMalR") = ParesProgramaMalR
            reporte3("AtadosProgramadosMalR") = AtadosProgramaMalR
            reporte3("LotesProgramadosMalR") = LotesProgramaMalR

            reporte3.Dictionary.Clear()
            reporte3.RegData(dsFacturacion)
            reporte3.RegData(dsRemision)
            reporte3.Dictionary.Synchronize()

            Return 1
            Me.Cursor = Cursors.Default



        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EnviarCorrerREST(ByVal id_Nave As Integer, ByVal numeroAlmacen As Integer, ByVal fecha As String, ByVal nombreCreo As String, ByVal nombreRecibio As String, ByVal ComercializadoraID As Integer) As Boolean
        Dim Resultado As Boolean = False
        Dim llamarServicio As New ClienteRest(Of RespuestaRestArray)
        Dim Servidor As String = My.Settings.ServidorRest
        Dim dtResultado As DataTable
        Dim RutaREst As String = String.Empty
        Dim RutaCliente As String = String.Empty
        Dim RutaServidorSICY As String = String.Empty
        Try


            llamarServicio.url = Servidor & "Almacen/ImprimirReporte_Entrada_Almacen?naveid=" & id_Nave & "&numeroAlmacen=" & numeroAlmacen & "&fecha=" & fecha & "&usuarioCreo=" & nombreCreo & "&usuarioRecibio=" & nombreRecibio & "&ComercializadoraId=" & ComercializadoraID.ToString
            llamarServicio.metodo = "GET"
            Dim Respuesta As RespuestaRestArray = llamarServicio.ObtenerRESTArreglo


            If Respuesta.respuesta = 1 Then

                Return True
            Else
                Resultado = False
            End If
        Catch ex As Exception
            'Manejar errror en el proceso de las capas
            'MsgBox(ex.Message)

            Resultado = False
        Finally
            llamarServicio = Nothing
            dtResultado = Nothing
        End Try
        Return Resultado
    End Function

    Private Sub AbrirPDFFactura(ByVal RutaPDF As String)
        Try
            Process.Start(RutaPDF)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdIncorrecto_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdIncorrecto.InitializeRow

        If ListaLotesPiloto.Exists(Function(x) x.ToString = e.Row.Cells("PLote").Value) = True Then
            e.Row.Cells("PLote").Appearance.BackColor = Color.LightGreen

        End If

    End Sub
End Class