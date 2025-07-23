Imports System.Media
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Stimulsoft.Report
Imports System.IO
Imports Tools
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid

Public Class PedidosMuestras_SalidasEntradas

    Dim NombreUsuario As String
    Dim UsuarioID As Integer
    Dim dtErrores As DataTable


    'VARIABLES ETIQUETAS
    Dim Leidas As Integer
    Dim CodigosCorrectos As Integer
    Dim InCorrectos As Integer
    Dim Descartadas As Integer
    Dim RegistrosSeleccionados As Integer
    Public FolioEnvio As Integer
    Dim Entrega As Integer
    Dim Total As Integer
    Dim Pendientes As Integer

    Dim PiezasSelecionadas_Descartar As Integer

    Dim ProcesoSeleccionado As Integer

    Dim NaveID As Integer
    Dim ComercializadoraID As Integer

    Dim Permiso_Envio_Piezas As Boolean
    Dim Permiso_Recepcion_Piezas As Boolean
    Dim cedisRealId As Integer
    Dim navepertenecienteId As Boolean = False
    Dim Externa As Boolean = False 'true - Tiene SAY | false - No tiene SAY
    Dim seVanPiezasEnReproceso As Boolean = False

    'Dim FolioEntrega As Integer

    Private Sub PedidosMuestras_SalidasEntradas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)

        NombreUsuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid


        Validar_Perfil_Usuario()
        CargaInicial()
    End Sub


    Private Sub Validar_Perfil_Usuario()
        btnCodigosConErrores.Enabled = False
        btnDescartarLotes.Enabled = False
        btnDetener.Enabled = False
        btnGuardar.Enabled = False
        btnImprimirReporte.Enabled = False
        btnIniciar.Enabled = False
        Permiso_Envio_Piezas = False
        Permiso_Recepcion_Piezas = False
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ENVIO_REC_MUESTRAS", "ENVIO_MUESTRAS_DE_NAVE") Then
            btnCodigosConErrores.Enabled = True
            btnDescartarLotes.Enabled = True
            btnDetener.Enabled = True
            btnGuardar.Enabled = True
            btnIniciar.Enabled = True
            Permiso_Envio_Piezas = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ENVIO_REC_MUESTRAS", "RECEPCION_MUESTRAS_EN_COMERCIALIZADORA") Then
            btnCodigosConErrores.Enabled = True
            btnDescartarLotes.Enabled = True
            btnDetener.Enabled = True
            btnGuardar.Enabled = True
            btnIniciar.Enabled = True
            Permiso_Recepcion_Piezas = True
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ENVIO_REC_MUESTRAS", "CONSULTA_FOLIOS_ENVIO_RECEPCION") Then
            btnImprimirReporte.Enabled = True
        End If

    End Sub

    Private Sub CargaInicial()



        btnDetener.Enabled = False
        btnDescartarLotes.Enabled = False
        btnCodigosConErrores.Enabled = False
        btnImprimirReporte.Enabled = True
        txtcapturacodigos.Enabled = False
        btnIniciar.Enabled = True
        btnGuardar.Enabled = False
        cmbNave.Enabled = True
        cmbProceso.Enabled = True
        Externa = False


        dtErrores = New DataTable

        dtErrores.Columns.Add("Pieza", Type.GetType("System.String"))
        dtErrores.Columns.Add("Talla", Type.GetType("System.String"))
        dtErrores.Columns.Add("UDM", Type.GetType("System.String"))
        dtErrores.Columns.Add("Artículo", Type.GetType("System.String"))
        dtErrores.Columns.Add("Tipo de Error", Type.GetType("System.String"))

        grdPiezasEnviadas.DataSource = Nothing
        grdPiezasRecibidas.DataSource = Nothing

        ReiniciarLecturasEtiquetas()


    End Sub

    Private Sub ReiniciarLecturasEtiquetas()
        Leidas = 0
        CodigosCorrectos = 0
        InCorrectos = 0
        Descartadas = 0
        RegistrosSeleccionados = 0
        FolioEnvio = 0
        Entrega = 0
        Total = 0
        Pendientes = 0

        dtErrores = New DataTable

        dtErrores.Columns.Add("Pieza", Type.GetType("System.String"))
        dtErrores.Columns.Add("Talla", Type.GetType("System.String"))
        dtErrores.Columns.Add("UDM", Type.GetType("System.String"))
        dtErrores.Columns.Add("Artículo", Type.GetType("System.String"))
        dtErrores.Columns.Add("Tipo de Error", Type.GetType("System.String"))

        AsignarValoresEtiquetas()
    End Sub

    ''' <summary>
    ''' METODO QUE VALIDA SI EXISTEN UN FOLIO CON EL ESTATUS : EN PROCESO
    ''' SI EXISTE UN FOLIO QUE ESTE ESTATUS SE CARGA AUTOMATICAMENTE PARA QUE SE CONTINUE ESCANENANDO DENTRO DEL FOLIO O PARA DETENER
    ''' EL ESCANEO Y GENERAR UN NUEVO FOLIO
    ''' </summary>
    Private Sub ValidarFolioEnProceso(NaveID As Integer)
        Dim objBu As New Negocios.EntradaSalidaMuestrasBU
        Dim dtFolioEnProceso As DataTable
        Dim msg_info As New Tools.AvisoForm
        Dim cedisNaveId As Integer = 0
        Dim idnaveBD As Integer = 0
        Try
            dtFolioEnProceso = objBu.ValidarFolioEnProceso(NaveID)
            If cboxNaveCedis.Text <> "" Then
                cedisNaveId = cboxNaveCedis.SelectedValue
            End If
            If dtFolioEnProceso.Rows.Count > 0 Then 'TIENE UN FOLIO EN PROCESO

                Externa = False

                ReiniciarLecturasEtiquetas()
                FolioEnvio = dtFolioEnProceso.Rows(0).Item(0)
                cedisRealId = dtFolioEnProceso.Rows(0).Item(5)
                idnaveBD = dtFolioEnProceso.Rows(0).Item(1)

                If cedisNaveId = cedisRealId And NaveID = idnaveBD Then '' valida la nave y cedis sean el mismo
                    msg_info.mensaje = "Actualmente hay un folio de envio con estatus EN PROCESO para la nave " + dtFolioEnProceso.Rows(0).Item(2)
                    msg_info.ShowDialog()

                    Dim dt As DataTable

                    IniciarLectura()

                    dt = CargarGrid(grdPiezasEnviadas, FolioEnvio, ProcesoSeleccionado)
                    DiseñoGridNoEditable(grdVPiezasEnviadas)
                    AplicarTamañosColumnas(grdVPiezasEnviadas)

                    Leidas = dt.Rows.Count
                    CodigosCorrectos = Leidas
                    AsignarValoresEtiquetas()
                    txtcapturacodigos.Clear()
                    txtcapturacodigos.Select()
                    btnGuardar.Enabled = True
                Else
                    'grdPiezasEnviadas.DataSource = Nothing
                    'grdVPiezasEnviadas.Columns.Clear()
                End If
            End If
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub

    Private Function ValidarFolioIngresando(NaveID As Integer, ComercializadoraID As Integer) As Boolean
        Dim objBu As New Negocios.EntradaSalidaMuestrasBU
        Dim dtFolioIngresando As DataTable
        Dim msg_info As New Tools.AvisoForm
        Dim TieneFolio As Boolean

        Try

            dtFolioIngresando = objBu.ValidarFolioIngresando(NaveID, ComercializadoraID)

            If dtFolioIngresando.Rows.Count > 0 Then
                TieneFolio = True

                IniciarLectura()

                Total = dtFolioIngresando.Rows(0).Item("pmer_piezasenviadas")
                Entrega = dtFolioIngresando.Rows(0).Item("pmer_consecutivodiario")
                FolioEnvio = dtFolioIngresando.Rows(0).Item("pmer_enviorecepcionid")

                msg_info.mensaje = "Actualmente hay un folio de envio con estatus INGRESANDO para la nave " + dtFolioIngresando.Rows(0).Item("nave_nombre")
                msg_info.ShowDialog()

                Dim dtEnvidas As DataTable
                Dim dtRecibidas As DataTable

                dtEnvidas = CargarGrid(grdPiezasEnviadas, FolioEnvio, 1)
                If dtEnvidas.Rows.Count > 0 Then
                    DiseñoGridNoEditable(grdVPiezasEnviadas)
                    AplicarTamañosColumnas(grdVPiezasEnviadas)

                    dtRecibidas = CargarGrid(grdPiezasRecibidas, FolioEnvio, 2)
                    If dtRecibidas.Rows.Count > 0 Then
                        DiseñoGridEditable(grdVPiezasRecibidas, " ")
                        AplicarTamañosColumnas(grdVPiezasRecibidas)
                    End If
                    Descartadas = dtRecibidas.Select("Estatus = 181").Count

                    Pendientes = Total - dtRecibidas.Rows.Count
                    Leidas = dtRecibidas.Rows.Count
                    CodigosCorrectos = Leidas

                    AsignarValoresEtiquetas()
                    txtcapturacodigos.Clear()
                    txtcapturacodigos.Select()
                End If
            Else
                TieneFolio = False
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Return TieneFolio
    End Function

    Private Function CargarGrid(Grid As DevExpress.XtraGrid.GridControl, Folio As Integer, ProcesoSeleccionado As Integer) As DataTable
        Dim objBU As New Negocios.EntradaSalidaMuestrasBU
        Dim dtPiezasEscaneadas As DataTable
        Dim dtCedisPieza As New DataTable
        Dim navecedisId As Integer = 0
        Dim naveembarqueId As Integer = 0
        Grid.DataSource = Nothing
        Try
            'navecedisId = cboxNaveCedis.SelectedValue
            If cboxNaveCedis.Text = "COMERCIALIZADORA" Then
                navecedisId = 43
            Else
                navecedisId = 82
            End If

            If ProcesoSeleccionado = 1 Then
                dtPiezasEscaneadas = objBU.ConsultarPiezasEscaneadas(Folio)
                If dtPiezasEscaneadas.Rows.Count > 0 Then
                    If navecedisId = dtPiezasEscaneadas.Rows(0).Item(9) Then
                        Grid.DataSource = dtPiezasEscaneadas
                        navepertenecienteId = False
                    End If
                End If

            Else
                dtPiezasEscaneadas = objBU.ConsultarPiezasRecibidas(Folio)
                If dtPiezasEscaneadas.Rows.Count > 0 Then
                    Grid.DataSource = dtPiezasEscaneadas
                    navepertenecienteId = False
                End If
            End If
            Return dtPiezasEscaneadas
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private Sub AplicarTamañosColumnas(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.Columns.ColumnByFieldName("Pieza").Width = 60
        Grid.Columns.ColumnByFieldName("Talla").Width = 30
        Grid.Columns.ColumnByFieldName("UDM").Width = 30
        Grid.Columns.ColumnByFieldName("Artículo").Width = 240
        Grid.Columns.ColumnByFieldName("Cliente").Width = 70
        Grid.Columns.ColumnByFieldName("Orden P").Width = 40
        Grid.Columns.ColumnByFieldName("Año").Width = 30
    End Sub

    Private Sub AsignarValoresEtiquetas()
        lblFolioEnvio.Text = FolioEnvio
        lblLeidas.Text = Leidas
        lblCorrectas.Text = CodigosCorrectos
        lblIncorrectas.Text = InCorrectos
        lblRegistrosSelecionados.Text = RegistrosSeleccionados
        lblEntrega.Text = Entrega
        lblTotal.Text = Total
        lblPendientes.Text = Pendientes
        lblDescartadas.Text = Descartadas
        'txtcapturacodigos.Clear()
        'txtcapturacodigos.Select()
    End Sub


    Public Sub DiseñoGridEditable(Grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal ParamArray ColumnasEditables As Object())

        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        'Grid.OptionsView.EnableAppearanceEvenRow = True
        'Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = False
        Grid.OptionsSelection.EnableAppearanceFocusedRow = False
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        Dim gridFormatRule As New GridFormatRule()
        Dim formatConditionRuleExpression As New FormatConditionRuleExpression()

        gridFormatRule.Column = grdVPiezasRecibidas.Columns.ColumnByFieldName(" ")
        gridFormatRule.ApplyToRow = True
        formatConditionRuleExpression.PredefinedName = "Red Fill"
        formatConditionRuleExpression.Expression = "[Estatus] = 181"
        gridFormatRule.Rule = formatConditionRuleExpression
        grdVPiezasRecibidas.FormatRules.Add(gridFormatRule)
        seVanPiezasEnReproceso = False

        'Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        'Grid.Appearance.EvenRow.BackColor = Color.White
        'Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        'Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next

        For i As Integer = 0 To ColumnasEditables.Length - 1
            Grid.Columns.ColumnByFieldName(ColumnasEditables(i)).OptionsColumn.AllowEdit = True
        Next

        Grid.Columns.ColumnByFieldName("Piezas Enviadas").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Piezas Enviadas").Visible = False
        Grid.Columns.ColumnByFieldName("Estatus").Visible = False
        Grid.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("cedisId").Visible = False

        Grid.MoveLast()
    End Sub

    Public Sub DiseñoGridNoEditable(Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 30

        'Grid.OptionsView.EnableAppearanceEvenRow = True
        'Grid.OptionsView.EnableAppearanceOddRow = True
        Grid.OptionsSelection.EnableAppearanceFocusedCell = False
        Grid.OptionsSelection.EnableAppearanceFocusedRow = False
        Grid.Appearance.SelectedRow.Options.UseBackColor = True

        'Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)

        'Grid.Appearance.EvenRow.BackColor = Color.White
        'Grid.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        'Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        'Grid.Appearance.FocusedRow.ForeColor = Color.White

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
        Next

        Grid.Columns.ColumnByFieldName("Piezas Enviadas").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName("Piezas Enviadas").Visible = False
        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = False
        Grid.Columns.ColumnByFieldName(" ").Visible = False
        Grid.Columns.ColumnByFieldName("cedisId").Visible = False

        Grid.MoveLast()

    End Sub

    ''SE DEBE MOSTRAR DE ACUERDO AL USUARIO QUE ACCEDE A LA PANTALLA CONFORME A LA TABLA DE PERMISOS
    Private Sub CargarComboBoxProceso()

        If Permiso_Envio_Piezas Then
            cmbProceso.Items.Add("ENVIO A CEDIS")
        End If

        If Permiso_Recepcion_Piezas Then
            cmbProceso.Items.Add("RECEPCIÓN")
        End If

    End Sub

    ''COMBO NAVE DE ACUERDO AL USUARIO Y PROCESO SELECCIONADO(CHECAR LOS PERFILES)
    ''' <summary>
    ''' Recibe como parametro el proceso seleccionado en base a eso cargar las naves del usuario
    ''' 1 - ENVIO A COMERCIALIZADORA
    ''' 2 - RECEPCION EN COMERCIALIZADORA
    ''' </summary>
    ''' <param name="ProcesoSeleccionado"></param>
    Private Sub CargarComboNaves(ProcesoSeleccionado As Integer)
        Dim objNeg As New Negocios.EntradaSalidaMuestrasBU
        Dim dtNaves As New DataTable
        Try
            dtNaves = objNeg.ConsultarNavesUsuario_EnvioRecepcion(NombreUsuario, ProcesoSeleccionado)
            dtNaves.Rows.InsertAt(dtNaves.NewRow, 0)
            cmbNave.DisplayMember = "NaveNombre"
            cmbNave.ValueMember = "NaveID"
            cmbNave.DataSource = dtNaves
            'cmbNave.SelectedIndex = 0
        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
    End Sub
    'Private Sub cargaComboCedis()
    '    Dim objNeg As New Negocios.EntradaSalidaMuestrasBU
    '    Dim dtCedis As New DataTable
    '    dtCedis = objNeg.obtenerCedisNaves
    '    dtCedis.Rows.InsertAt(dtCedis.NewRow, 0)
    '    If cboxNaveCedis.Text = "" Then
    '        cboxNaveCedis.DisplayMember = "cedis"
    '        cboxNaveCedis.ValueMember = "naveId"
    '        cboxNaveCedis.DataSource = dtCedis
    '    End If
    'End Sub
    Private Sub cmbProceso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProceso.SelectedIndexChanged
        If cmbProceso.SelectedItem.ToString = "ENVIO A CEDIS" Then
            ProcesoSeleccionado = 1
            'cargaComboCedis()
            'Utilerias.ComboObtenerCEDISUsuario(cboxNaveCedis)
            Utilerias.ComboObtenerCEDIS(cboxNaveCedis)
        End If

        If cmbProceso.SelectedItem.ToString = "RECEPCIÓN" Then
            ProcesoSeleccionado = 2
            Utilerias.ComboObtenerCEDISUsuario(cboxNaveCedis)
        End If
        CargarComboNaves(ProcesoSeleccionado)
        Mostrar_Ocultar_Botones_Etiquetas(ProcesoSeleccionado)
    End Sub

    Private Sub Mostrar_Ocultar_Botones_Etiquetas(ProcesoSeleccionado As Integer)
        btnGuardar.Enabled = False
        If ProcesoSeleccionado = 1 Or Externa = True Then

            lblTRegistros.Visible = False
            lblRegistrosSelecionados.Visible = False
            lblEntrega.Visible = False
            lblTEntrega.Visible = False
            lblTotal.Visible = False
            lblTTotal.Visible = False
            lblPendientes.Visible = False
            lblTPendientes.Visible = False
            lblTDescartadas.Visible = False
            lblDescartadas.Visible = False

            btnDescartarLotes.Enabled = False

        ElseIf ProcesoSeleccionado = 2 And Externa = False Then

            lblTRegistros.Visible = True
            lblRegistrosSelecionados.Visible = True
            lblEntrega.Visible = True
            lblTEntrega.Visible = True
            lblTotal.Visible = True
            lblTTotal.Visible = True
            lblPendientes.Visible = True
            lblTPendientes.Visible = True
            lblTDescartadas.Visible = True
            lblDescartadas.Visible = True

            btnDescartarLotes.Enabled = False

        End If

        If Externa = True Then
            lblTRegistros.Visible = True
            lblRegistrosSelecionados.Visible = True
            lblEntrega.Visible = True
            lblTEntrega.Visible = True
        End If

    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        If cmbProceso.SelectedIndex = -1 Or cmbProceso.SelectedIndex <> 1 And cmbProceso.SelectedIndex <> 0 Then
            show_message("Advertencia", "Seleccione un tipo de proceso")
        Else
            If cmbNave.SelectedIndex = -1 Or cmbNave.SelectedIndex = 0 Or cmbProceso.SelectedIndex <> 1 And cmbProceso.SelectedIndex <> 0 Then
                show_message("Advertencia", "Seleccione una nave válida")
            Else
                If cboxNaveCedis.SelectedIndex = -1 Or cboxNaveCedis.SelectedIndex = 0 And cmbProceso.SelectedIndex <> 1 And cmbProceso.SelectedIndex <> 0 Then
                    show_message("Advertencia", "Seleccione un cedis válido")
                Else
                    If cboxNaveCedis.Text = "" Then
                        show_message("Advertencia", "Seleccione un cedis válido")
                    Else
                        IniciarLectura()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub IniciarLectura()

        btnDetener.Enabled = True
        btnCodigosConErrores.Enabled = True
        btnImprimirReporte.Enabled = True
        txtcapturacodigos.Enabled = True
        btnIniciar.Enabled = False
        cmbNave.Enabled = False
        cmbProceso.Enabled = False
        btnGuardar.Enabled = False
        cboxNaveCedis.Enabled = False

        If ProcesoSeleccionado = 2 Then
            btnDescartarLotes.Enabled = False
        End If
        txtcapturacodigos.Text = ""
        txtcapturacodigos.Select()
    End Sub


    Private Sub txtcapturacodigos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcapturacodigos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim naveCedisId As Integer = 0
            Dim dtNaveCedis As New DataTable
            Dim objBU As New Negocios.EntradaSalidaMuestrasBU
            Dim navepertenece As String = ""
            If Trim(txtcapturacodigos.Text) <> String.Empty Then
                Dim CadenaCapturada As String = Trim(txtcapturacodigos.Text).Replace("'", "-")
                'naveCedisId = cboxNaveCedis.SelectedValue
                If cboxNaveCedis.Text = "COMERCIALIZADORA" Then
                    naveCedisId = 43
                ElseIf cboxNaveCedis.Text = "REEDITION" Then
                    naveCedisId = 82
                End If
                If cmbProceso.Text = "ENVIO A CEDIS" Then 'PROCESO DE ENVIO
                    dtNaveCedis = objBU.obtenerCedisCorrespondientePieza(CadenaCapturada)
                    If naveCedisId = dtNaveCedis.Rows(0).Item(0) Then
                        ValidarCodigoMuestraPiezas_Envio(CadenaCapturada, naveCedisId)
                    Else
                        ReproducirSonidoError()
                        txtcapturacodigos.Text = ""
                        If dtNaveCedis.Rows(0).Item(0) = 82 Then
                            navepertenece = "REEDITION"
                        Else
                            navepertenece = "COMERCIALIZADORA"
                        End If
                        show_message("Advertencia", "La pieza " + CadenaCapturada + " no pertenece al cedis " + cboxNaveCedis.Text + " favor de cambiar el cedis a " + navepertenece)
                    End If
                ElseIf cmbProceso.Text = "RECEPCIÓN" Then 'PROCESO DE RECEPCION
                    dtNaveCedis = objBU.obtenerCedisCorrespondientePieza(CadenaCapturada)
                    If naveCedisId = dtNaveCedis.Rows(0).Item(0) Then
                        If Externa = False Then
                            ValidarCodigoMuestraPiezas_Recepcion(CadenaCapturada)
                        Else
                            ValidarCodigoMuestraPiezas_Recepcion_NaveSinSAY(CadenaCapturada)
                        End If
                    Else
                        ReproducirSonidoError()
                        txtcapturacodigos.Text = ""
                        If dtNaveCedis.Rows(0).Item(0) = 82 Then
                            navepertenece = "REEDITION"
                        Else
                            navepertenece = "COMERCIALIZADORA"
                        End If
                        show_message("Advertencia", "La pieza " + CadenaCapturada + " no puede ser recepcionada por que no pertenece al cedis " + cboxNaveCedis.Text + " favor de cambiar el cedis a " + navepertenece)
                    End If
                End If
                btnGuardar.Enabled = False
            End If
        End If
    End Sub

    Private Sub ValidarCodigoMuestraPiezas_Envio(CadenaCodigo As String, ByVal cedisId As Integer)
        Dim objBU As New Negocios.EntradaSalidaMuestrasBU
        Dim dtMuestras As DataTable
        Dim NaveID As Integer
        'Dim CedisId As Integer = 0
        Dim msg_info As New Tools.AvisoForm
        Dim menssage As String = ""
        NaveID = cmbNave.SelectedValue
        'CedisId = cboxNaveCedis.SelectedValue

        Try
            dtMuestras = objBU.ValidarCodigoMuestra(CadenaCodigo.Trim, NaveID)

            If dtMuestras.Rows.Count > 0 Then
                If dtMuestras.Rows(0).Item("CodigoValido") = "VALIDA" Then 'CODIGO CORRECTO
                    If CodigosCorrectos = 0 Then 'ES EL PRIMER CODIGO LEIDO CORRECTO; SE INSERTA EL ENCABEZADO Y SE CREA UN FOLIO DE ENVIO
                        FolioEnvio = objBU.GuardarEncabezadoPrimerCodigoLeido(NaveID, UsuarioID, CadenaCodigo, cedisId).Rows(0).Item(0)
                    Else 'ES EL SEGUNDO O MAS DEL SEGUNDO : SOLO SE GUARDA LA PIEZA
                        objBU.GuardarPiezaMuestra(FolioEnvio, CadenaCodigo, UsuarioID, cedisId)
                    End If
                    CodigosCorrectos += 1
                    CargarGrid(grdPiezasEnviadas, FolioEnvio, ProcesoSeleccionado)
                    DiseñoGridNoEditable(grdVPiezasEnviadas)
                    ReproducirSonidoCorrecto()
                Else 'If dtMuestras.Rows(0).Item("CodigoValido") = 2 Then
                    InCorrectos += 1
                    ReproducirSonidoError()
                    menssage = dtMuestras.Rows(0).Item("CodigoValido")
                    msg_info.mensaje = menssage
                    msg_info.ShowDialog()
                    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), dtMuestras.Rows(0).Item("CodigoValido"))
                End If
            Else 'CODIGO NO VALIDO
                InCorrectos += 1
                ReproducirSonidoError()
                CapturarErrores(CadenaCodigo, "", "", "", "CÓDIGO INVÁLIDO")
            End If
        Catch ex As Exception
            InCorrectos += 1
            ReproducirSonidoError()
            CapturarErrores(CadenaCodigo, "", "", "", "ERROR AL ECANEAR EL CÓDIGO")
        End Try

        Leidas += 1
        AsignarValoresEtiquetas()
        txtcapturacodigos.Clear()
        txtcapturacodigos.Select()

    End Sub

    Private Sub ValidarCodigoMuestraPiezas_Recepcion_NaveSinSAY(CadenaCodigo As String)
        Dim objBU As New Negocios.EntradaSalidaMuestrasBU
        Dim dtMuestras As DataTable
        Dim NaveID As Integer
        Dim cedisid As Integer
        Try

            NaveID = cmbNave.SelectedValue
            cedisid = cboxNaveCedis.SelectedValue
            dtMuestras = objBU.ValidarCodigoMuestra(CadenaCodigo.Trim, NaveID)

            Leidas += 1

            If dtMuestras.Rows.Count > 0 Then

                If dtMuestras.Rows(0).Item("CodigoValido") = "VALIDA" Then 'CODIGO CORRECTO


                    If CodigosCorrectos = 0 Then 'ES EL PRIMER CODIGO LEIDO CORRECTO - ACTUALIZA EL ESTATUS DE LA PIEZA Y GENERA UNA ENTREGA DEL DIA

                        Dim dt As DataTable
                        dt = objBU.RecibirPrimerPiezaRecepcion_NaveExterna(NaveID, CadenaCodigo, UsuarioID, cedisid)

                        FolioEnvio = dt.Rows(0).Item(0)
                        Entrega = dt.Rows(0).Item(1)

                    Else 'ES EL SEGUNDO O MAS DEL SEGUNDO : SOLO SE ACTUALIZA LA PIEZA

                        objBU.ActualizaPiezaRecibidaComercializadora_NaveExterna(CadenaCodigo, UsuarioID, FolioEnvio, cedisid)

                    End If

                    Dim dtEnviados As DataTable
                    Dim dtRecibidos As DataTable

                    CodigosCorrectos += 1
                    dtEnviados = CargarGrid(grdPiezasEnviadas, FolioEnvio, 1)
                    If dtEnviados.Rows.Count > 0 Then
                        DiseñoGridNoEditable(grdVPiezasEnviadas)
                    End If

                    dtRecibidos = CargarGrid(grdPiezasRecibidas, FolioEnvio, 2)
                    If dtRecibidos.Rows.Count > 0 Then
                        DiseñoGridEditable(grdVPiezasRecibidas, " ")
                    End If
                    Pendientes = dtEnviados.Rows.Count
                    ReproducirSonidoCorrecto()

                Else 'If dtMuestras.Rows(0).Item("CodigoValido") = 2 Then
                    InCorrectos += 1
                    ReproducirSonidoError()
                    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), dtMuestras.Rows(0).Item("CodigoValido"))
                    'ElseIf dtMuestras.Rows(0).Item("CodigoValido") = 3 Then
                    '    InCorrectos += 1
                    '    ReproducirSonidoError()
                    '    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), "FOLIO INCORRECTO")
                    'ElseIf dtMuestras.Rows(0).Item("CodigoValido") = 4 Then
                    '    InCorrectos += 1
                    '    ReproducirSonidoError()
                    '    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), "NAVE INCORRECTA")
                End If



            Else 'CODIGO NO VALIDO

                InCorrectos += 1
                ReproducirSonidoError()
                CapturarErrores(CadenaCodigo, "", "", "", "CÓDIGO INVÁLIDO")

            End If
        Catch ex As Exception
            InCorrectos += 1
            ReproducirSonidoError()
            CapturarErrores(CadenaCodigo, "", "", "", "ERROR AL ECANEAR EL CÓDIGO")
        End Try

        AsignarValoresEtiquetas()
        txtcapturacodigos.Clear()
        txtcapturacodigos.Select()
    End Sub

    Private Sub ValidarCodigoMuestraPiezas_Recepcion(CadenaCodigo As String)
        Dim objBU As New Negocios.EntradaSalidaMuestrasBU
        Dim dtMuestras As DataTable
        Dim NaveID As Integer

        NaveID = cmbNave.SelectedValue

        Try

            dtMuestras = objBU.ValidarCodigoMuestra_Recepcion(CadenaCodigo.Trim, FolioEnvio, NaveID)

            Leidas += 1

            If dtMuestras.Rows.Count > 0 Then

                If dtMuestras.Rows(0).Item("CodigoValido") = "VALIDA" Then 'CODIGO CORRECTO

                    If CodigosCorrectos = 0 Then 'ES EL PRIMER CODIGO LEIDO CORRECTO - ACTUALIZA EL ESTATUS DE LA PIEZA Y GENERA UNA ENTREGA DEL DIA

                        Entrega = objBU.RecibirPrimerPiezaRecepcion(NaveID, CadenaCodigo, FolioEnvio, UsuarioID).Rows(0).Item(0)

                    Else 'ES EL SEGUNDO O MAS DEL SEGUNDO : SOLO SE ACTUALIZA LA PIEZA

                        objBU.ActualizaPiezaRecibidaComercializadora(CadenaCodigo, UsuarioID, FolioEnvio)

                    End If

                    Dim dtEnviados As DataTable
                    Dim dtRecibidos As DataTable

                    CodigosCorrectos += 1
                    dtEnviados = CargarGrid(grdPiezasEnviadas, FolioEnvio, 1)
                    If dtEnviados.Rows.Count > 0 Then
                        DiseñoGridNoEditable(grdVPiezasEnviadas)
                    End If
                    dtRecibidos = CargarGrid(grdPiezasRecibidas, FolioEnvio, 2)
                    If dtRecibidos.Rows.Count > 0 Then
                        DiseñoGridEditable(grdVPiezasRecibidas, " ")
                    End If
                    Pendientes = dtEnviados.Rows.Count
                    ReproducirSonidoCorrecto()
                Else 'If dtMuestras.Rows(0).Item("CodigoValido") = 2 Then
                    InCorrectos += 1
                    ReproducirSonidoError()
                    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), dtMuestras.Rows(0).Item("CodigoValido"))
                    'ElseIf dtMuestras.Rows(0).Item("CodigoValido") = 3 Then
                    '    InCorrectos += 1
                    '    ReproducirSonidoError()
                    '    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), "FOLIO INCORRECTO")
                    'ElseIf dtMuestras.Rows(0).Item("CodigoValido") = 4 Then
                    '    InCorrectos += 1
                    '    ReproducirSonidoError()
                    '    CapturarErrores(CadenaCodigo, dtMuestras.Rows(0).Item("pemp_talla"), dtMuestras.Rows(0).Item("unme_descripcion"), dtMuestras.Rows(0).Item("DescripcionCompleta"), "NAVE INCORRECTA")
                End If

            Else 'CODIGO NO VALIDO

                InCorrectos += 1
                ReproducirSonidoError()
                CapturarErrores(CadenaCodigo, "", "", "", "CÓDIGO INVÁLIDO")

            End If
        Catch ex As Exception
            InCorrectos += 1
            ReproducirSonidoError()
            CapturarErrores(CadenaCodigo, "", "", "", "ERROR AL ECANEAR EL CÓDIGO")
        End Try

        AsignarValoresEtiquetas()
        txtcapturacodigos.Clear()
        txtcapturacodigos.Select()

    End Sub

    Private Sub cmbNave_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedValueChanged
        ReiniciarLecturasEtiquetas()
        grdPiezasRecibidas.DataSource = Nothing
        grdPiezasEnviadas.DataSource = Nothing
        If cmbNave.SelectedIndex > 0 Then
            NaveID = cmbNave.SelectedValue
            ComercializadoraID = cboxNaveCedis.SelectedValue
            If ProcesoSeleccionado = 1 Then
                ValidarFolioEnProceso(NaveID)
            ElseIf ProcesoSeleccionado = 2 Then
                ValidarTipoNave_Recepcion(NaveID, ComercializadoraID)
            End If
        End If
    End Sub

    Private Sub grdVPiezasEnviadas_CustomUnboundColumnData(sender As Object, e As CustomColumnDataEventArgs) Handles grdVPiezasEnviadas.CustomUnboundColumnData
        If e.IsGetData Then
            e.Value = grdVPiezasEnviadas.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub grdVPiezasEnviadas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPiezasEnviadas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub GrdVPiezasRecibidas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVPiezasRecibidas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub ReproducirSonidoCorrecto()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub

    Private Sub ReproducirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_05)
        player.Play()
    End Sub

    Private Sub CapturarErrores(CodigoEscaneado As String, Talla As String, UDM As String, Articulo As String, TipoError As String)
        Dim Row = dtErrores.NewRow
        Row.Item("Pieza") = CodigoEscaneado
        Row.Item("Talla") = Talla
        Row.Item("UDM") = UDM
        Row.Item("Artículo") = Articulo
        Row.Item("Tipo de Error") = TipoError

        dtErrores.Rows.Add(Row)
    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click


        btnDetener.Enabled = False
        btnCodigosConErrores.Enabled = True
        btnImprimirReporte.Enabled = True
        txtcapturacodigos.Enabled = False
        btnIniciar.Enabled = True
        'cmbNave.Enabled = False
        'cmbProceso.Enabled = False
        cmbNave.Enabled = True
        cmbProceso.Enabled = True
        cboxNaveCedis.Enabled = True

        If ProcesoSeleccionado = 2 Then
            btnDescartarLotes.Enabled = True
        End If

        If cmbProceso.Text = "ENVIO A CEDIS" Then
            If FolioEnvio > 0 Then
                btnGuardar.Enabled = True
            End If
        ElseIf cmbProceso.Text = "RECEPCIÓN" Then
            If (Pendientes = 0 And CodigosCorrectos = Total And Total > 0) Or (Externa = True And FolioEnvio > 0) Then
                btnGuardar.Enabled = True
            Else
                btnGuardar.Enabled = True
            End If
            btnGuardar.Enabled = True
        End If
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)
        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then
            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()
        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.ShowDialog()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim msg_Confirmacion As New Tools.ConfirmarForm
        Dim objBU As New Negocios.EntradaSalidaMuestrasBU
        Dim msg_Exito As New Tools.ExitoForm
        Dim msg_ConfImprimir As New Tools.ConfirmarForm
        Dim dt As DataTable
        Dim msg_Error As New Tools.ErroresForm
        Dim cedisId2 As Integer = 0
        Dim idrepro As Integer
        Dim dttotalPiezasEnviadas As DataTable
        Dim piezasIguales As Integer = 0
        If ProcesoSeleccionado = 1 Then
            msg_Confirmacion.mensaje = "¿Desea cambiar el status del Folio de Envío #" + FolioEnvio.ToString + " a EMBARCADO? (Ya no podrá incluir más piezas en este folio)"
            msg_Exito.mensaje = "Se guardó correctamente el folio de envóo"
            msg_ConfImprimir.mensaje = "¿Desea imprimir el resumen del Folio de Envío  #" + FolioEnvio.ToString + "? (Posteriormente puede volver a imprimirlo)"
            idrepro = 0
        Else
            msg_Confirmacion.mensaje = "¿ Desea realizar la RECEPCIÓN EN " + cboxNaveCedis.Text + " del Folio de Envío #" + FolioEnvio.ToString + " ? "
            msg_Exito.mensaje = "El Folio de Envío #" + FolioEnvio.ToString + " ha sido recibido en" + cboxNaveCedis.Text + " exitosamente."
            msg_ConfImprimir.mensaje = "¿Desea imprimir el resumen del Folio de Recepción  #" + FolioEnvio.ToString + "? (Posteriormente puede volver a imprimirlo)"
        End If

        If msg_Confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

            Try

                If Externa = True Then
                    dt = objBU.ActualizarEstausEnvioRecepcionMuestras(FolioEnvio, UsuarioID, 3, seVanPiezasEnReproceso, idrepro)
                    objBU.actualizaPiezasReprocesos(FolioEnvio)
                Else
                    '' valida que las piezas recibas sean las mismas que las piezas que envian las naves
                    If ProcesoSeleccionado = 2 Then
                        If lblDescartadas.Text = "0" Then '' omite el proceso para las piezas descartadas ''
                            dttotalPiezasEnviadas = objBU.obtenerTotalPiezasEnviadas(FolioEnvio)
                            If dttotalPiezasEnviadas.Rows(0).Item(0) <> dttotalPiezasEnviadas.Rows(0).Item(1) Then
                                msg_Error.mensaje = "No coinciden las piezas enviadas con las piezas recibidas, favor de revisar!!"
                                msg_Error.ShowDialog()
                                piezasIguales = 1
                            End If
                            If dttotalPiezasEnviadas.Rows(0).Item(0) = dttotalPiezasEnviadas.Rows(0).Item(1) Then
                                If ProcesoSeleccionado = 2 Then '' solo el proceso de recepcion
                                    objBU.actualizaPiezasReprocesos(FolioEnvio)
                                End If
                            End If
                        End If
                    End If

                    If piezasIguales <> 1 Then
                        dt = objBU.ActualizarEstausEnvioRecepcionMuestras(FolioEnvio, UsuarioID, ProcesoSeleccionado, seVanPiezasEnReproceso, idrepro)
                    End If

                End If

                If Not (dt Is Nothing) Then
                    If dt.Rows.Count > 0 Then
                        msg_Error.mensaje = dt.Rows(0).Item(0).ToString
                        msg_Error.ShowDialog()
                        Return
                    End If
                Else
                    Return
                End If

                If dt.Rows.Count = 0 Then
                    msg_Exito.ShowDialog()
                    If msg_ConfImprimir.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If cmbProceso.Text = "ENVIO A CEDIS" Or cmbProceso.Text = "RECEPCIÓN" Then
                            Dim tipoReporte As String = String.Empty
                            cedisId2 = cboxNaveCedis.SelectedValue
                            If cmbProceso.Text = "ENVIO A CEDIS" Then
                                tipoReporte = "ENVIO"
                            Else
                                tipoReporte = "RECEPCIONADA"
                            End If
                            ImprimirReporte(FolioEnvio, cedisId2, tipoReporte)
                        End If
                    End If

                    CargaInicial()
                    CargarComboNaves(ProcesoSeleccionado)
                End If

            Catch ex As Exception
                msg_Error.mensaje = ex.Message
                msg_Error.ShowDialog()
            End Try

        End If
    End Sub

    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        If cboxNaveCedis.Text <> "" Then
            Dim tipoReporte As String = ""
            Dim Reporte_EnvioMuestrasForm As New PedidosMuestras_EntradasSalidas_Reporte
            Reporte_EnvioMuestrasForm.cedisId = cboxNaveCedis.SelectedValue
            Reporte_EnvioMuestrasForm.nombreCedis = cboxNaveCedis.Text
            If cmbProceso.Text = "ENVIO A CEDIS" Then
                tipoReporte = "ENVIO"
            Else
                tipoReporte = "RECEPCIONADO"
            End If
            Reporte_EnvioMuestrasForm.tipoReporte = tipoReporte
            Reporte_EnvioMuestrasForm.ShowDialog()
        Else
            show_message("Advertencia", "Favor de seleccionar un proceso y un cedis")
        End If
    End Sub

    Public Sub ImprimirReporte(Folio As Integer, ByVal cedisId As Integer, ByVal tipoReporte As String)
        Cursor = Cursors.WaitCursor
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes

        Dim dsMuestra As New DataSet("dsMuestras")

        Dim dtMuestra As New DataTable("dtMuestras")
        Dim dtDescartadas As New DataTable("dtDescartadas")
        Dim dtReprocesos As New DataTable("dtReproceso")
        Dim dtMuestrasReproceso As New DataTable("dtRecepcionReproceso")
        Dim dtEnviadosDeReprocesos As New DataTable("dtEnviadosDeReprocesos")

        Dim NombreNave As String = ""
        Dim Imagen As String = ""
        Dim Entrega As String = ""
        Dim FechaRecepcion As String = ""
        Dim Estatus As String = ""
        Dim FechaEnvio As String = ""
        Dim FechaImpresion As String = ""
        Dim UsuarioEntrego As String = ""
        Dim UsuarioRecibio As String = ""
        Dim TotalPiezas As String = ""
        Dim NombreCedis As String = ""
        Dim dtEncabezado As New DataTable
        Dim dtDescartadasAux As New DataTable
        Dim dtMuestrasAux As New DataTable
        Dim ReporteTallasLote As New StiReport
        Dim dtPiezasReproceso As New DataTable

        Dim dtEnviadosDeReprocesosAux As New DataTable

        Dim ObjBU As New Negocios.EntradaSalidaMuestrasBU
        Try
            dtMuestrasAux = ObjBU.ConsultarPiezasPorFolioEnvio_Reporte(Folio)
            dtEncabezado = ObjBU.ConsultarEncabezadoReporte(Folio, cedisId)

            dtPiezasReproceso = ObjBU.obtenerReportePiezasReproceso(Folio, tipoReporte)

            If dtEncabezado.Rows(0).Item("Estatus") = "ENTREGADO" Then

                dtDescartadasAux = ObjBU.ConsultarPiezasDescartadas(Folio)

                dtDescartadas = New DataTable("dtDescartadas")
                With dtDescartadas
                    .Columns.Add("OrdenProd")
                    .Columns.Add("FEntregaCliente")
                    .Columns.Add("FEntregaNave")
                    .Columns.Add("Cliente")
                    .Columns.Add("Modelo")
                    .Columns.Add("Corrida")
                    .Columns.Add("Talla")
                    .Columns.Add("UDM")
                    .Columns.Add("Pieza")
                End With

                For Each Fila As DataRow In dtDescartadasAux.Rows
                    dtDescartadas.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString, Fila.Item(3).ToString, Fila.Item(4).ToString, Fila.Item(5).ToString, Fila.Item(6).ToString, Fila.Item(7).ToString, Fila.Item(8).ToString)
                Next

                dtMuestrasReproceso = New DataTable("dtRecepcionReproceso")
                With dtMuestrasReproceso
                    .Columns.Add("OrdenProd")
                    .Columns.Add("FEntregaCliente")
                    .Columns.Add("FEntregaNave")
                    .Columns.Add("Cliente")
                    .Columns.Add("Modelo")
                    .Columns.Add("Corrida")
                    .Columns.Add("Piezas")
                    .Columns.Add("PzaReprocesada")
                End With

                For Each Fila As DataRow In dtPiezasReproceso.Rows
                    dtMuestrasReproceso.Rows.Add(Fila.Item("OrdenProd").ToString, Fila.Item("FEntregaCliente").ToString, Fila.Item("FEntregaNave").ToString, Fila.Item("Cliente").ToString, Fila.Item("Modelo").ToString, Fila.Item("Corrida").ToString, Fila.Item("Piezas").ToString, Fila.Item("PzaReprocesada").ToString)
                Next

                dsMuestra.Tables.Add(dtDescartadas)
                dsMuestra.Tables.Add(dtMuestrasReproceso)

                entReporte = objReporte.LeerReporteporClave("PROG_MUESTRAS_RECEPCION")

                Entrega = dtEncabezado.Rows(0).Item("Entrega").ToString

            Else

                dtEnviadosDeReprocesosAux = ObjBU.ConsultarPiezasPorFolioEnvio_Reporte_EnviadasDeReproceso(Folio)

                entReporte = objReporte.LeerReporteporClave("PROG_MUESTRAS_ENVIO")

            End If


            dtMuestra = New DataTable("dtMuestras")
            With dtMuestra
                .Columns.Add("OrdenProd")
                .Columns.Add("FEntregaCliente")
                .Columns.Add("FEntregaNave")
                .Columns.Add("Cliente")
                .Columns.Add("Modelo")
                .Columns.Add("Corrida")
                .Columns.Add("Piezas")
                .Columns.Add("FechaRecepción")
            End With

            Dim TotalPiezasAux As Integer = 0
            For Each Fila As DataRow In dtMuestrasAux.Rows
                TotalPiezasAux += Fila.Item("Piezas")
            Next

            For Each Fila As DataRow In dtMuestrasAux.Rows
                dtMuestra.Rows.Add(Fila.Item("OrdenProd").ToString, Fila.Item("FEntregaCliente").ToString, Fila.Item("FEntregaNave").ToString, Fila.Item("Cliente").ToString, Fila.Item("Modelo").ToString, Fila.Item("Corrida").ToString, Fila.Item("Piezas").ToString, Fila.Item("FechaRecepción").ToString)
            Next



            dtReprocesos = New DataTable("dtReproceso")
            With dtReprocesos
                .Columns.Add("OrdenProd")
                .Columns.Add("FEntregaCliente")
                .Columns.Add("FEntregaNave")
                .Columns.Add("Cliente")
                .Columns.Add("Modelo")
                .Columns.Add("Corrida")
                .Columns.Add("Piezas")
                .Columns.Add("PzaReprocesada")
            End With

            For Each Fila As DataRow In dtPiezasReproceso.Rows
                dtReprocesos.Rows.Add(Fila.Item("OrdenProd").ToString, Fila.Item("FEntregaCliente").ToString, Fila.Item("FEntregaNave").ToString, Fila.Item("Cliente").ToString, Fila.Item("Modelo").ToString, Fila.Item("Corrida").ToString, Fila.Item("Piezas").ToString, Fila.Item("PzaReprocesada").ToString)
            Next

            Dim TotalPiezasReproceso As Integer = 0
            For Each Fila As DataRow In dtReprocesos.Rows
                TotalPiezasReproceso += Fila.Item("Piezas")
            Next



            dtEnviadosDeReprocesos = New DataTable("dtEnviadosDeReprocesos")
            With dtEnviadosDeReprocesos
                .Columns.Add("OrdenProd")
                .Columns.Add("FEntregaCliente")
                .Columns.Add("FEntregaNave")
                .Columns.Add("Cliente")
                .Columns.Add("Modelo")
                .Columns.Add("Corrida")
                .Columns.Add("Piezas")
                .Columns.Add("PzaReprocesada")
            End With

            For Each Fila As DataRow In dtEnviadosDeReprocesosAux.Rows
                dtEnviadosDeReprocesos.Rows.Add(Fila.Item("OrdenProd").ToString, Fila.Item("FEntregaCliente").ToString, Fila.Item("FEntregaNave").ToString, Fila.Item("Cliente").ToString, Fila.Item("Modelo").ToString, Fila.Item("Corrida").ToString, Fila.Item("Piezas").ToString, Fila.Item("PzaReproceso").ToString)
            Next

            Dim TotalPiezasEnviadasDeReprocesos As Integer = 0
            For Each Fila As DataRow In dtEnviadosDeReprocesos.Rows
                TotalPiezasEnviadasDeReprocesos += Fila.Item("Piezas")
            Next



            dsMuestra.Tables.Add(dtMuestra)
            dsMuestra.Tables.Add(dtReprocesos)
            dsMuestra.Tables.Add(dtEnviadosDeReprocesos)

            Folio = dtEncabezado.Rows(0).Item("FolioEnvio")
            NombreNave = dtEncabezado.Rows(0).Item("Nave")
            FechaRecepcion = dtEncabezado.Rows(0).Item("FechaRecepción").ToString
            Estatus = dtEncabezado.Rows(0).Item("Estatus").ToString
            FechaEnvio = dtEncabezado.Rows(0).Item("FechaEnvío").ToString
            FechaImpresion = dtEncabezado.Rows(0).Item("FechaImpresion").ToString
            UsuarioEntrego = dtEncabezado.Rows(0).Item("Entrego").ToString
            TotalPiezas = TotalPiezasAux.ToString
            UsuarioRecibio = dtEncabezado.Rows(0).Item("Recibió")
            NombreCedis = dtEncabezado.Rows(0).Item("cedis")

            Imagen = Tools.Controles.ObtenerLogoNave(43)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

            ReporteTallasLote.Load(archivo)
            ReporteTallasLote.Compile()
            ReporteTallasLote.RegData(dsMuestra)
            ReporteTallasLote("NombreNave") = NombreNave
            ReporteTallasLote("FolioEnvio") = Folio.ToString
            ReporteTallasLote("urlImagenNave") = Imagen
            ReporteTallasLote("FechaEnvio") = FechaEnvio
            ReporteTallasLote("Entrega") = Entrega
            ReporteTallasLote("FechaRecepcion") = FechaRecepcion
            ReporteTallasLote("Estatus") = Estatus
            ReporteTallasLote("FechaImpresion") = FechaImpresion
            ReporteTallasLote("UsuarioEntrego") = UsuarioEntrego
            ReporteTallasLote("UsuarioRecibio") = UsuarioRecibio
            ReporteTallasLote("TotalPiezas") = TotalPiezas
            ReporteTallasLote("TotalPiezasReprocesos") = TotalPiezasReproceso.ToString
            ReporteTallasLote("TotalPiezasEnviadasDeReprocesos") = TotalPiezasEnviadasDeReprocesos.ToString
            ReporteTallasLote("cedis") = NombreCedis '
            ReporteTallasLote.Dictionary.Clear()
            ReporteTallasLote.Dictionary.Synchronize()
            'reporteUnaTienda.Render()
            ReporteTallasLote.Show()

        Catch ex As Exception
            Dim msg_error As New Tools.ErroresForm
            msg_error.mensaje = ex.Message
            msg_error.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCodigosConErrores_Click(sender As Object, e As EventArgs) Handles btnCodigosConErrores.Click
        Dim CodigosErrorForm As New CodigosConErrorForm
        CodigosErrorForm.dtCodigosError = dtErrores
        CodigosErrorForm.ShowDialog()
    End Sub

    Private Sub txtcapturacodigos_Leave(sender As Object, e As EventArgs) Handles txtcapturacodigos.Leave
        If btnDetener.Focused = False Then
            txtcapturacodigos.Focus()
        End If
    End Sub

    Private Sub PedidosMuestras_SalidasEntradas_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CargarComboBoxProceso()
    End Sub


    ''' <summary>
    ''' FUNCTION QUE VALIDA LAS NAVES QUE UTILIZAN SAY
    ''' </summary>
    ''' <param name="NaveID"></param>
    Private Sub ValidarTipoNave_Recepcion(NaveID As Integer, ComercializadoraID As Integer)
        Dim ObjBu As New Negocios.EntradaSalidaMuestrasBU
        Dim dtNave As DataTable

        Me.Cursor = Cursors.WaitCursor
        Try

            'CargaInicial()
            ReiniciarLecturasEtiquetas()

            dtNave = ObjBu.ValidarTipoNave_Recepcion(NaveID)

            If dtNave.Rows.Count > 0 Then 'NAVE QUE SI UTILIZA SAY

                Externa = False

            Else 'NAVE QUE NO UTILIZA SAY

                Externa = True

            End If

            If ValidarFolioIngresando(NaveID, ComercializadoraID) = False And Externa = False Then
                CargarFoliosEnviosNave(NaveID)
            End If
            Mostrar_Ocultar_Botones_Etiquetas(ProcesoSeleccionado)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

        Me.Cursor = Cursors.Default

    End Sub


    Private Sub CargarFoliosEnviosNave(NaveID As Integer)
        Dim dtFoliosEnviosNave As DataTable
        Dim ObjBu As New Negocios.EntradaSalidaMuestrasBU
        Dim NaveNombre As String = cmbNave.Text

        dtFoliosEnviosNave = ObjBu.ConsultarFoliosEnviosNaves_Recepcion(NaveID)
        If dtFoliosEnviosNave.Rows.Count > 0 Then

            If dtFoliosEnviosNave.Rows.Count = 1 Then 'SOLO HAY UN FOLIO PARA RECIBIR DE LA NAVE -- NO MOSTRAR PANTALLA DE FOLIOS

                FolioEnvio = dtFoliosEnviosNave.Rows(0).Item("FolioEnvío")

            Else 'HAY MAS DE UN FOLIO PARA RECIBIR DE LA NAVE -- SE DEBE MOSTRAR PANTALLA DE FOLIOS

                Dim FormFoliosEnvio As New PedidosMuestras_EntradasSalidas_FoliosEnvio

                FormFoliosEnvio.NaveID = NaveID
                FormFoliosEnvio.NaveNombre = NaveNombre
                FormFoliosEnvio.dtFoliosEnviadosNaves = dtFoliosEnviosNave
                FormFoliosEnvio.PedidosMuestras_SalidasEntradasForm = Me

                FormFoliosEnvio.ShowDialog()

            End If

            If FolioEnvio > 0 Then

                Dim dt As DataTable
                Dim dt2 As New DataTable

                dt = CargarGrid(grdPiezasEnviadas, FolioEnvio, 1)
                If navepertenecienteId = False Then
                    If grdVPiezasEnviadas.RowCount > 0 Then
                        DiseñoGridNoEditable(grdVPiezasEnviadas)
                        AplicarTamañosColumnas(grdVPiezasEnviadas)
                        lblFolioEnvio.Text = FolioEnvio
                    End If
                    dt2 = CargarGrid(grdPiezasRecibidas, FolioEnvio, 2)
                    If dt2.Rows.Count > 0 Then
                        DiseñoGridEditable(grdVPiezasRecibidas, " ")
                        AplicarTamañosColumnas(grdVPiezasRecibidas)
                        Total = dt.Rows(0).Item("Piezas Enviadas")
                        Pendientes = Total
                        IniciarLectura()
                        AsignarValoresEtiquetas()
                        txtcapturacodigos.Clear()
                        txtcapturacodigos.Select()
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub btnDescartarLotes_Click(sender As Object, e As EventArgs) Handles btnDescartarLotes.Click
        Dim objBU As New Negocios.EntradaSalidaMuestrasBU
        Dim msg_Conf As New ConfirmarForm
        Dim dtRecibidas As DataTable

        If PiezasSelecionadas_Descartar = 0 Then
            show_message("Advertencia", "Debe seleccionar las piezas que serán descartadas")
            Return
        End If

        msg_Conf.mensaje = "¿Desea descartar las piezas seleccionadas? (No deben ser recibidas en Comercializadora regresarán a estatus en PRODUCCIÓN)"
        If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Try
                For i As Integer = 0 To grdVPiezasRecibidas.RowCount - 1
                    If grdVPiezasRecibidas.GetRowCellValue(i, " ") = True Then
                        objBU.DescartarPiezas(grdVPiezasRecibidas.GetRowCellValue(i, "Pieza"), UsuarioID, FolioEnvio)
                    End If
                Next
                dtRecibidas = CargarGrid(grdPiezasRecibidas, FolioEnvio, ProcesoSeleccionado)
                DiseñoGridEditable(grdVPiezasRecibidas, " ")
                AplicarTamañosColumnas(grdVPiezasRecibidas)

                Descartadas = dtRecibidas.Select("Estatus = 181").Count

                AsignarValoresEtiquetas()
            Catch ex As Exception
                show_message("Error", ex.Message)
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GrdVPiezasRecibidas_CellValueChanging(sender As Object, e As CellValueChangedEventArgs) Handles grdVPiezasRecibidas.CellValueChanging
        If e.Column.GetCaption = " " Then
            ContarRegistrosSeleccionados(e.Value)
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged

        Dim valor As Boolean = chkSeleccionarTodo.Checked
        If valor Then
            PiezasSelecionadas_Descartar = 0
            For i As Integer = 0 To grdVPiezasRecibidas.RowCount - 1
                grdVPiezasRecibidas.SetRowCellValue(i, " ", valor)
                ContarRegistrosSeleccionados(valor)
            Next
        End If

    End Sub


    Private Sub ContarRegistrosSeleccionados(Valor As Boolean)
        If Valor = True Then
            PiezasSelecionadas_Descartar += 1
        Else
            PiezasSelecionadas_Descartar -= 1
            chkSeleccionarTodo.Checked = False
        End If
        lblRegistrosSelecionados.Text = PiezasSelecionadas_Descartar
    End Sub

    Private Sub cboxNaveCedis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxNaveCedis.SelectedIndexChanged
        grdPiezasEnviadas.DataSource = Nothing
        grdVPiezasEnviadas.Columns.Clear()
    End Sub

End Class