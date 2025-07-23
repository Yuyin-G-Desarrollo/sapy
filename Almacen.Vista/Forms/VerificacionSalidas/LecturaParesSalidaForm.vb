Imports Tools
Imports System.Media
Imports DevExpress.XtraPrinting
Imports Stimulsoft.Report
Imports DevExpress.XtraGrid.Views.Grid
Imports Facturacion.Negocios

Public Class LecturaParesSalidaForm

    Private ObjBU As New Negocios.VerificacionSalidasBU
    Public ColaboradorId As Integer = 0
    Dim Colaborador As String = ""
    Dim UsuarioID As Integer = 0
    Public FolioVerificacionId As Integer = 0
    Dim entFolio As New Entidades.InfoVerificacionFolio
    Dim TotalOT As Integer = 0
    Dim TotalPares As Integer = 0
    Dim ParesLeidos As Integer = 0
    Dim ParesPendientes As Integer = 0
    Dim ParesDescartados As Integer = 0
    Dim ListadodeParesFolioVerificacion As New DataTable
    Dim SeFinalizoFolio As Boolean = False
    Dim DescartarAtados As Boolean = False
    Public EsAndrea As Boolean = False
    Dim ParesConfirmadosAndrea As Integer = 0
    Dim ParesPendientesConfirmarAndrea As Integer = 0
    Dim ParesErrores As Integer = 0
    Dim dtParesConfirmadosAndrea As DataTable
    Dim dtParesPendientesAndrea As DataTable
    Dim MostrarVistaDeIndicadores As Boolean = False
    Dim ParesNoExiste As Integer = 0 'Registra el error de los pares que no existen de los documentos no seleccionados

    Dim ClienteID As Integer = 0


    Private Sub LecturaParesSalidaForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Hola
        UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        CargarPantalla()
        pnlDescartarPares.Visible = True
        pnlParesExcedente.Visible = False
        pnlParesLeidos.Visible = False
        pnlParesPendientes.Visible = False
        pnlAgregarOT.Visible = True
        pnlQuitarLotes.Visible = False

        If EsAndrea = True Then
            ClienteID = 816
            ActualizarPantalla_Andrea()
            ActualizarInformacion_Andrea()
            grdParesConfirmados.Visible = False
            SplitContainer1.Panel1.Visible = False
            SplitContainer1.Panel1Collapsed = True
            SplitContainer1.Panel2.MaximumSize = MaximumSize
            lblEtiquetaParesDescartados.Text = "Pares " & vbCrLf & "   Errores  "
            lblFolio.Text = FolioVerificacionId
            pnlDescartarOT.Visible = False
            pnlDescartarPares.Visible = False
            pnlTotalOT.Visible = False
            viewParesPendientes.Appearance.Empty.BackColor = Color.White
            pnlQuitarLotes.Visible = True
        Else
            ValidarSessionesActivas()
        End If

        SeFinalizoFolio = False
        lblDescartarPares.Visible = False

    End Sub

    Private Sub ValidarSessionesActivas()
        Try
            Cursor = Cursors.WaitCursor

            If ObjBU.ConsultaSessionActiva(ColaboradorId) = True Then
                FolioVerificacionId = ObjBU.ObtenerFolioVerificacionSession(ColaboradorId)
                ListadodeParesFolioVerificacion = ObjBU.ConsultarParesVerificacionFolio(FolioVerificacionId)

                'Obtener el cliente de la session activa
                If ListadodeParesFolioVerificacion.Rows.Count > 0 Then
                    ClienteID = ListadodeParesFolioVerificacion.AsEnumerable.Select(Function(x) x.Item("ClienteID")).FirstOrDefault
                End If

                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Ya existe una session activa.")
            Else
                With entFolio
                    .ColaboradorId = ColaboradorId
                    .FolioPaqueteria = ""
                    .Mensajeria = ""
                    .MensajeriaId = 0
                    .Operador = ""
                    .OperadorID = 0
                    .StatusID = 0
                    .Unidad = ""
                    .UnidadID = 0
                    .UsuarioID = UsuarioID
                End With

                FolioVerificacionId = ObjBU.InsertarFolio(entFolio)
            End If
            lblFolio.Text = FolioVerificacionId.ToString()
            ActualizarPantalla()

            HabilitarControles(True)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub CargarParesPendientes(ByVal Folio As Integer)
        Dim dtResultado As New DataTable
        Try
            Dim ListaParesPendientes = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("StatusPar") = "0" And x.Item("Descartado") = False)

            If ListaParesPendientes.Count > 0 Then
                grdParesPendientes.DataSource = ListaParesPendientes.AsDataView
                DiseñoGrid.PropiedadesGrid(viewParesPendientes, True, DevExpress.Utils.HorzAlignment.Center, True)
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "OrdenTrabajoID", "OT", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "CodigoAtado", "Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "CodigoPar", "Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "Talla", "Talla", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "ColeccionSAY", "Colección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "FechaConfirmacion", "Fecha Confirmación", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "Colaborador", "Colaborador", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, "StatusPar", "StatusPar", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                'DiseñoGrid.EstiloColumna(viewParesPendientes, " ", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Default, True, True, 100, False, DevExpress.Data.SummaryItemType.None, "")


            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub CargarParesConfirmados(ByVal Folio As Integer)
        Dim dtResultado As New DataTable
        Try
            Dim ListaParesConfirmados = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("StatusPar") = "1" And x.Item("Descartado") = False)
            If ListaParesConfirmados.Count > 0 Then
                grdParesConfirmados.DataSource = ListaParesConfirmados.AsDataView

                DiseñoGrid.PropiedadesGrid(viewParesConfirmados, True, DevExpress.Utils.HorzAlignment.Center, True)
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "OrdenTrabajoID", "OT", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "CodigoAtado", "Atado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "CodigoPar", "Par", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "Talla", "Talla", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "Cliente", "Cliente", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "ColeccionSAY", "Colección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "Lote", "Lote", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "Nave", "Nave", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "FechaConfirmacion", "Fecha Confirmación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "Colaborador", "Colaborador", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, "StatusPar", "StatusPar", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
                DiseñoGrid.EstiloColumna(viewParesConfirmados, " ", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Default, True, True, 100, False, DevExpress.Data.SummaryItemType.None, "")

                viewParesConfirmados.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True

                ' DiseñoGrid.DiseñoBaseGrid(viewParesConfirmados)
            End If

            'dtResultado = ObjBU.ParesPendientesDeConfirmar(Folio)
            'ParesLeidos = dtResultado.Rows.Count
            'TotalOT = dtResultado.AsEnumerable.Select(Function(x) x.Item("OrdenTrabajoID")).Distinct.Count

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Sub ActualizarInformacionEtiquetas()
        Try
            If DescartarAtados = False Then

                lblTotalOT.Text = CDbl(TotalOT.ToString).ToString("N0")
                lblTotalPares.Text = CDbl(TotalPares).ToString("N0")
                lblParesConfirmados.Text = CDbl(ParesLeidos).ToString("N0")
                lblParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
            Else

                lblTotalOT.Text = CDbl(TotalOT.ToString).ToString("N0")
                lblTotalPares.Text = CDbl(TotalPares).ToString("N0")
                lblParesConfirmados.Text = CDbl(ParesLeidos).ToString("N0")
                lblParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    'Private Sub btnIniciar_Click(sender As Object, e As EventArgs)
    '    If EsAndrea = False Then
    '        ValidarSessionesActivas()
    '    End If

    '    HabilitarControles(False)
    '    lblDescartarPares.Visible = DescartarAtados
    'End Sub

    Private Sub HabilitarControles(ByVal Activar As Boolean)
        If Activar = True Then
            btnIniciar.Enabled = True
            btnDetener.Enabled = False
            ' btnLimpiar.Enabled = True
            btnDescartarLote.Enabled = True
            txtLectura.Enabled = False
            'cmbMensajeria.Enabled = True
            'cmbOperador.Enabled = True
            'cmbUnidad.Enabled = True
            txtFolioPaqueteria.Enabled = True
            btnGuardar.Enabled = True
            btnCerrar.Enabled = True
            lblIniciar.Enabled = True
            lblDetener.Enabled = False
            ' lblLimpiar.Enabled = True
            lblDescartarLote.Enabled = True
            lblAceptar.Enabled = True
            lblCerrar.Enabled = True

        Else
            btnIniciar.Enabled = False
            btnDetener.Enabled = True
            '  btnLimpiar.Enabled = False
            btnDescartarLote.Enabled = False
            txtLectura.Enabled = True
            'cmbMensajeria.Enabled = False
            'cmbOperador.Enabled = False
            'cmbUnidad.Enabled = False
            txtFolioPaqueteria.Enabled = False
            btnGuardar.Enabled = False
            btnCerrar.Enabled = False
            lblIniciar.Enabled = False
            lblDetener.Enabled = True
            'lblLimpiar.Enabled = False
            lblDescartarLote.Enabled = False
            lblAceptar.Enabled = False
            lblCerrar.Enabled = False

        End If


    End Sub

    Private Sub ObtenerTotalParesOrdenTrabajo()

        'Consulta para obtener los pares totales de la OT
        TotalPares = 0

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnDetener_Click(sender As Object, e As EventArgs) Handles btnDetener.Click
        HabilitarControles(True)
        DescartarAtados = False
        pnlParesExcedente.Visible = False
        pnlParesLeidos.Visible = False
        pnlParesPendientes.Visible = False
        If EsAndrea = True Then
            grdParesConfirmados.Visible = False
            SplitContainer1.Panel1.Visible = False
            SplitContainer1.Panel1Collapsed = True
            SplitContainer1.Panel2.MaximumSize = MaximumSize
        Else
            pnlParesExcedente.Visible = False
            pnlParesLeidos.Visible = False
            pnlParesPendientes.Visible = False
        End If

        MostrarVistaDeIndicadores = False
    End Sub

    Public Sub AsignarCodigoColaboradorTiendaUnidad(ByVal CodigoCapturado As String)

        Dim ColaboradorEmbarqueID As Integer = 0
        Dim MensajeriaID As Integer = 0
        Dim MensajeriaSplit As String()
        Dim UnidadSplit As String()
        Dim UnidadId As Integer = 0
        Dim Colaborador As String = String.Empty

        'Es Usuario
        If CodigoCapturado.Contains("EM") = True Then
            Colaborador = txtLectura.Text.Replace("EM", "")
            ColaboradorEmbarqueID = Colaborador
            If cmbOperador.Enabled = True Then
                cmbOperador.SelectedValue = ColaboradorEmbarqueID
            End If

            'Es Mensajeria
        ElseIf CodigoCapturado.Contains("MSJ") = True Then
            CodigoCapturado = CodigoCapturado.Replace("?", "_")
            MensajeriaSplit = CodigoCapturado.Split("_")
            If cmbMensajeria.Enabled = True Then
                If MensajeriaSplit.Length = 3 Then
                    MensajeriaID = MensajeriaSplit(2).Trim()
                    cmbMensajeria.SelectedValue = MensajeriaID
                Else
                    ReproducirSonidoError()
                   
                End If
            End If

            'Es Unidad
        ElseIf CodigoCapturado.Contains("UND") = True Then
            CodigoCapturado = (CodigoCapturado).Replace("'", "_")
            UnidadSplit = CodigoCapturado.Split("_")

            If cmbUnidad.Enabled = True Then
                If UnidadSplit.Length = 3 Then
                    UnidadId = UnidadSplit(2).Trim()
                    cmbUnidad.SelectedValue = UnidadId
                Else
                    ReproducirSonidoError()
                End If
            End If
        End If

    End Sub

    Public Sub ValidarCodigoCapturadoPar(ByVal CodigoCapturado As String)

        'Validar si el codigo es un codigo de colaborador, mensajeria, unidad
        If CodigoCapturado.Contains("EM") = True Or CodigoCapturado.Contains("MSJ") = True Or CodigoCapturado.Contains("UND") = True Then
            AsignarCodigoColaboradorTiendaUnidad(CodigoCapturado)
        Else
            ValidarCodigoAtadoParCodigoCliente(CodigoCapturado)
        End If

    End Sub

    Public Sub ValidarCodigoAtadoParCodigoCliente(ByVal CodigoCapturado As String)

        CodigoCapturado = (CodigoCapturado).Replace("'", "-")

        If CodigoCapturado.Substring(0, 1) = "0" Then
            CodigoCapturado = CodigoCapturado.TrimStart("0")
        End If

        If EsAndrea = False Then
            If DescartarAtados = True Then
                DescartarPares(CodigoCapturado)
            Else
                ValidarCodigoCapturado(CodigoCapturado)
            End If
            ActualizarPantalla()
        Else
            ConfirmarParesAndrea(CodigoCapturado)
            ActualizarInformacion_Andrea()
        End If
    End Sub


    Private Sub txtLectura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLectura.KeyPress

        Try

            If e.KeyChar = ChrW(Keys.Enter) Then

                If txtLectura.Text.Trim() = "" Then
                    Throw New Exception("No se ha capturado ningun codigo.")
                End If

                ValidarCodigoCapturadoPar(txtLectura.Text.Trim())

                txtLectura.Text = ""
                txtLectura.Focus()

            End If
        Catch ex As Exception
            ReproducirSonidoError()
            'Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El codigo de ATADO es incorrecto.")
        End Try

    End Sub

    Public Sub ReproducirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub


    Public Sub ReproducirSonidoCorrecto()
        Dim player As New SoundPlayer(My.Resources.OK)
        player.Play()
    End Sub

    Public Function ConfirmarCodigoAtado(ByVal CodigoCapturado As String) As Boolean

        Dim DTParesOT As New DataTable

        If ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString.TrimStart("0") = CodigoCapturado).Count = 0 Then
            If ObjBU.ValidaCodigoCapturado(CodigoCapturado, False, FolioVerificacionId) = True Then
                ProgressPanel2.Show()
                ProgressPanel2.Refresh()



                DTParesOT = ObjBU.InsertarParesOT(CodigoCapturado.TrimStart("0"), False, FolioVerificacionId)
                If DTParesOT.Rows.Count > 0 Then
                    ClienteID = DTParesOT.AsEnumerable.Select(Function(x) x.Item("ClienteID")).FirstOrDefault()
                End If
                CopiarFilasDataTable(DTParesOT)
                ConfirmarParesVerificacion(CodigoCapturado, False)

                ProgressPanel2.Hide()
                Return True

            Else
                ReproducirSonidoError()
                Dim formaConfirmacion As New ConfirmarForm
                formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
                formaConfirmacion.mensaje = " El codigo de ATADO es incorrecto.Deseas Seguir Mostrando el mensaje ?" +
                "Codigo capturado: " + CodigoCapturado
                While formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK
                    formaConfirmacion.ShowDialog()

                End While
                'Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "4.El codigo de ATADO es incorrecto.")
                ParesErrores += 1
                Return False
            End If

        Else
            ConfirmarParesVerificacion(CodigoCapturado, False)
            Return True
        End If

    End Function
    Public Function ConfirmarCodigoCliente(ByVal CodigoCapturado As String) As Boolean
        Dim CodigoPar As String = String.Empty

        If (ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoCliente").ToString.Trim().TrimStart("0") = CodigoCapturado.TrimStart("0").Trim() And x.Item("StatusPar") = 0).Count) > 0 Then
            ProgressPanel2.Show()
            ProgressPanel2.Refresh()

            Dim ParCodigoCliente = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoCliente").ToString.Trim().TrimStart("0") = CodigoCapturado.TrimStart("0").Trim() And x.Item("StatusPar") = 0).FirstOrDefault
            ParCodigoCliente.Item("StatusPar") = 1
            ParCodigoCliente.Item("FechaConfirmacion") = Date.Now.ToLongDateString
            ParCodigoCliente.Item("Colaborador") = Colaborador
            CodigoPar = ParCodigoCliente.Item("CodigoPar").ToString.Trim()
            ObjBU.ConfirmarParesFolioVerificacion(FolioVerificacionId, True, CodigoPar, ColaboradorId)
            ProgressPanel2.Hide()
            Return True
        Else
            ReproducirSonidoError()
            'Dim formaConfirmacion As New ConfirmarForm
            'formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            'formaConfirmacion.mensaje = "5. El codigo de ATADO es incorrecto. Deseas Continuar?"
            ''Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El codigo de ATADO es incorrecto.")

            'If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    formaConfirmacion.ShowDialog()

            'Else
            '    formaConfirmacion.Hide()
            'End If
            ParesErrores += 1
            Return False
        End If

    End Function

    Public Function ConfirmarCodigoParYuyin(ByVal CodigoCapturado As String) As Boolean
        Dim DTParesOT As New DataTable


        If ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar") = CodigoCapturado).Count = 0 Then

            If ObjBU.ValidaCodigoCapturado(CodigoCapturado, True, FolioVerificacionId) = True Then
                ProgressPanel2.Show()
                ProgressPanel2.Refresh()

                DTParesOT = ObjBU.InsertarParesOT(CodigoCapturado, True, FolioVerificacionId)
                If DTParesOT.Rows.Count > 0 Then
                    ClienteID = DTParesOT.AsEnumerable.Select(Function(x) x.Item("ClienteID")).FirstOrDefault()
                End If

                CopiarFilasDataTable(DTParesOT)
                ConfirmarParesVerificacion(CodigoCapturado, True)
                ProgressPanel2.Hide()
                Return True
            Else
                ReproducirSonidoError()
                'Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El codigo de ATADO es incorrecto.")
                ParesErrores += 1
                Return False
            End If

        Else
            ConfirmarParesVerificacion(CodigoCapturado, True)
            Return True
        End If


    End Function

    Private Sub ValidarCodigoCapturado(ByVal CodigoCapturado As String)
        Dim CodigoCapturadoAux As String()
        Dim EsCodigoPar As Boolean = False
        Dim DTParesOT As New DataTable
        Dim CodigoPar As String = String.Empty

        Try
            CodigoCapturadoAux = CodigoCapturado.Split("-")

            If CodigoCapturadoAux.Length = 3 Then
                EsCodigoPar = True
            End If

            If EsCodigoPar = True Then
                ConfirmarCodigoParYuyin(CodigoCapturadoAux(2))
            Else

                If ConfirmarCodigoAtado(CodigoCapturado) = False Then
                    ConfirmarCodigoCliente(CodigoCapturado)
                End If
            End If

        Catch ex As Exception
            ReproducirSonidoError()
            'Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El codigo de ATADO es incorrecto."
        End Try

    End Sub




    Private Sub CopiarFilasDataTable(ByVal DtPares As DataTable)

        Try
            If ListadodeParesFolioVerificacion.Rows.Count = 0 Then
                ListadodeParesFolioVerificacion = DtPares.Copy()
            Else
                For Each row As DataRow In DtPares.Rows
                    ListadodeParesFolioVerificacion.ImportRow(row)
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub ConfirmarParesVerificacion(ByVal CodigoCapturado As String, ByVal EsCodigoPar As Boolean)

        Try
            If EsCodigoPar = True Then
                'vrf.vrsp_codigoatado As CodigoAtado,
                'vrf.vrsp_codigopar As CodigoPar,
                If ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar") = CodigoCapturado And x.Item("StatusPar") = "0").Count > 0 Then

                    Dim Fila = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar") = CodigoCapturado).FirstOrDefault
                    Fila.Item("StatusPar") = "1"
                    Fila.Item("FechaConfirmacion") = Date.Now.ToLongDateString
                    Fila.Item("Colaborador") = Colaborador

                    ObjBU.ConfirmarParesFolioVerificacion(FolioVerificacionId, EsCodigoPar, CodigoCapturado, ColaboradorId)

                ElseIf ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar") = CodigoCapturado And x.Item("StatusPar") = "1").Count > 0 Then
                    ReproducirSonidoError()
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El codigo de PAR ya fue leido anteriormente.")
                End If

            Else

                If ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString.TrimStart("0") = CodigoCapturado And x.Item("StatusPar") = "0").Count > 0 Then
                    Dim Filas = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString.TrimStart("0") = CodigoCapturado And x.Item("StatusPar") = "0").ToList

                    For Each Fila As DataRow In Filas
                        Fila.Item("StatusPar") = "1"
                        Fila.Item("FechaConfirmacion") = Date.Now.ToLongDateString
                        Fila.Item("Colaborador") = Colaborador
                    Next

                    ObjBU.ConfirmarParesFolioVerificacion(FolioVerificacionId, EsCodigoPar, CodigoCapturado, ColaboradorId)
                ElseIf ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString.TrimStart("0") = CodigoCapturado And x.Item("StatusPar") = "1").Count > 0 Then
                    ReproducirSonidoError()
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "El codigo de ATADO ya fue leido anteriormente.")

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub ActualizarPantalla()

        Try
            CargarParesConfirmados(FolioVerificacionId)
            CargarParesPendientes(FolioVerificacionId)

            TotalOT = ListadodeParesFolioVerificacion.AsEnumerable().Select(Function(x) x.Item("OrdenTrabajoID")).Distinct.Count
            TotalPares = ListadodeParesFolioVerificacion.Rows.Count
            ParesLeidos = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("StatusPar") = "1" And x.Item("Descartado") = False).Count
            ParesPendientes = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("StatusPar") = "0" And x.Item("Descartado") = False).Count
            ParesDescartados = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("Descartado") = True).Count

            If DescartarAtados = False Then
                lblPanelParesLeidos.Text = CDbl(ParesLeidos).ToString("N0")
                lblPanelParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
                'lblPanelParesExcedentes.Text = CDbl(ParesErrores + ParesNoExiste).ToString("N0")
                lblParesDescartados.Text = CDbl(ParesDescartados).ToString("N0")
                lblPanelParesExcedentes.Text = CDbl(ParesDescartados).ToString("N0")
                lblTextParesExcedentes.Text = "DESCARTADOS"

                pnlParesExcedente.BackColor = Color.Crimson
                pnlParesLeidos.BackColor = Color.ForestGreen
                pnlParesPendientes.BackColor = Color.Orange

                lblParesLeidos.Text = "LEÍDOS"


            Else

                lblPanelParesLeidos.Text = CDbl(ParesDescartados).ToString("N0")
                lblPanelParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
                lblPanelParesExcedentes.Text = CDbl(ParesLeidos).ToString("N0")

                lblParesDescartados.Text = CDbl(ParesDescartados).ToString("N0")
                lblTextParesExcedentes.Text = "DESCARTADOS"

                pnlParesExcedente.BackColor = Color.ForestGreen
                pnlParesLeidos.BackColor = Color.Crimson
                pnlParesPendientes.BackColor = Color.Orange

                lblParesLeidos.Text = "DESCARTAR"
                lblTextParesExcedentes.Text = "LEÍDOS"


            End If

            ActualizarInformacionEtiquetas()
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            ReproducirSonidoError()
        End Try

    End Sub

    Private Sub LecturaParesSalidaForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim formaConfirmacion As New ConfirmarForm
        formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
        formaConfirmacion.mensaje = "¿Estas seguro que deseas salir?"
        If SeFinalizoFolio = False Then
            If formaConfirmacion.ShowDialog() <> Windows.Forms.DialogResult.OK Then
                e.Cancel = True
            Else
                If FolioVerificacionId > 0 Then
                    ObjBU.ActualizarEncabezados(FolioVerificacionId)
                End If

            End If
        Else
            e.Cancel = False
        End If


    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim NombreOperador As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor

            If ValidarCamposCapturados() = True Then

                If RTrim(LTrim(cmbMensajeria.SelectedItem(1).ToString())) = "YUYIN (NOSOTROS MISMOS)" Then
                    NombreOperador = cmbOperador.Text
                Else
                    NombreOperador = txtNombreOperador.Text.Trim()
                End If

                If EsAndrea = True Then
                    If dtParesPendientesAndrea.AsEnumerable.Sum(Function(x) x.Item("ParesPendientes")) = 0 Then
                        Dim resultado = ObjBU.FinalizarFolioVerificacion(FolioVerificacionId, cmbMensajeria.SelectedValue, cmbMensajeria.Text, cmbOperador.SelectedValue, NombreOperador, cmbUnidad.SelectedValue, cmbUnidad.Text, txtFolioPaqueteria.Text)
                        SeFinalizoFolio = True
                        imprimirReporte()

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El Folio se ha guardado exitosamente.")
                        'Me.Close()

                        Dim objBUTimbrado As New TrasladosBU
                        Try
                            If resultado(0)(0) <> 0 Then
                                For index = 0 To resultado.Rows.Count - 1
                                    objBUTimbrado.GenerarInformacionTimbrado(FolioVerificacionId, resultado(index)(2), False) 'lblFolio.Text
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
                            objBUTimbrado.InsertarError(FolioVerificacionId, "EMBARQUE", ex.Message)
                        End Try

                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Aun faltan pares por leer.")
                    End If

                Else
                    Dim ListaParesPendientes = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("StatusPar") = "0")
                    If ListaParesPendientes.Count = 0 Then
                        Dim resultado = ObjBU.FinalizarFolioVerificacion(FolioVerificacionId, cmbMensajeria.SelectedValue, cmbMensajeria.Text, cmbOperador.SelectedValue, NombreOperador, cmbUnidad.SelectedValue, cmbUnidad.Text, txtFolioPaqueteria.Text)
                        SeFinalizoFolio = True

                        imprimirReporte()

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "El Folio se ha guardado exitosamente.")

                        ' Empieza integracion carta porte

                        Dim objBUTimbrado As New TrasladosBU
                        Try

                            If resultado(0)(0) <> 0 Then
                                For index = 0 To resultado.Rows.Count - 1
                                    objBUTimbrado.GenerarInformacionTimbrado(FolioVerificacionId, resultado(index)(2), False) 'lblFolio.Text
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
                            objBUTimbrado.InsertarError(FolioVerificacionId, "EMBARQUE", ex.Message)
                        End Try


                        'Me.Close()
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Aun faltan pares por leer.")
                    End If
                End If




            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Faltan campos por capturar.")
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub

    Private Function ValidarCamposCapturados() As Boolean
        Dim Resultado As Boolean = True
        Try
            If FolioVerificacionId = 0 Then
                Resultado = False
            End If

            If cmbMensajeria.SelectedIndex <= 0 Then
                Resultado = False
                lblTextoMensajeria.ForeColor = Color.Red
            Else
                lblTextoMensajeria.ForeColor = Color.Black
            End If

            If cmbOperador.Enabled = True Then
                If cmbOperador.SelectedIndex <= 0 Then
                    Resultado = False
                    lblOperador.ForeColor = Color.Red
                Else
                    lblOperador.ForeColor = Color.Black
                End If
            Else
                lblOperador.ForeColor = Color.Black
            End If

            If cmbUnidad.Enabled = True Then
                If cmbUnidad.SelectedIndex <= 0 Then
                    Resultado = False
                    lblTextoUnidad.ForeColor = Color.Red
                Else
                    lblTextoUnidad.ForeColor = Color.Black
                End If
            Else
                lblTextoUnidad.ForeColor = Color.Black
            End If


        Catch ex As Exception
            Resultado = False
        End Try


        Return Resultado
    End Function

    Private Sub btnDescartarLote_Click(sender As Object, e As EventArgs) Handles btnDescartarLote.Click
        Dim formaConfirmacion As New ConfirmarForm
        Dim NumeroFilas As Integer = 0
        Dim OT As String = String.Empty
        Dim ListaOt As New List(Of Integer)
        Dim OrdenTrabajo As Integer = 0

        Try
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "¿Estas seguro de descartar las OTs seleccionadas?"


            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor

                NumeroFilas = viewParesConfirmados.DataRowCount
                For index As Integer = 0 To NumeroFilas Step 1
                    OrdenTrabajo = viewParesConfirmados.GetRowCellValue(viewParesConfirmados.GetVisibleRowHandle(index), "OrdenTrabajoID")
                    If CBool(viewParesConfirmados.GetRowCellValue(viewParesConfirmados.GetVisibleRowHandle(index), " ")) = True Then
                        If ListaOt.AsEnumerable.Where(Function(x) x = OrdenTrabajo).Count = 0 Then
                            ListaOt.Add(OrdenTrabajo)
                            If OT = String.Empty Then
                                OT = viewParesConfirmados.GetRowCellValue(viewParesConfirmados.GetVisibleRowHandle(index), "OrdenTrabajoID").ToString
                            Else
                                OT = OT + "," + viewParesConfirmados.GetRowCellValue(viewParesConfirmados.GetVisibleRowHandle(index), "OrdenTrabajoID").ToString
                            End If
                        End If

                    End If
                Next

                NumeroFilas = viewParesPendientes.DataRowCount
                For index As Integer = 0 To NumeroFilas Step 1
                    OrdenTrabajo = viewParesPendientes.GetRowCellValue(viewParesPendientes.GetVisibleRowHandle(index), "OrdenTrabajoID")
                    If CBool(viewParesPendientes.GetRowCellValue(viewParesPendientes.GetVisibleRowHandle(index), " ")) = True Then
                        If ListaOt.AsEnumerable.Where(Function(x) x = OrdenTrabajo).Count = 0 Then
                            ListaOt.Add(OrdenTrabajo)
                            If OT = String.Empty Then
                                OT = viewParesPendientes.GetRowCellValue(viewParesPendientes.GetVisibleRowHandle(index), "OrdenTrabajoID").ToString
                            Else
                                OT = OT + "," + viewParesPendientes.GetRowCellValue(viewParesPendientes.GetVisibleRowHandle(index), "OrdenTrabajoID").ToString
                            End If

                        End If

                    End If
                Next

                If ListaOt.Count > 0 Then
                    For Each fila As Integer In ListaOt
                        ObjBU.DescartarOrdenTrabajo(FolioVerificacionId, fila)
                    Next

                    ListadodeParesFolioVerificacion.Rows.Clear()
                    ListadodeParesFolioVerificacion = ObjBU.ConsultarParesVerificacionFolio(FolioVerificacionId)
                    ActualizarPantalla()

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se han descartado las OTs.")
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una OT.")
                End If



            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub



    Public Sub CargarPantalla()
        Dim objBU As New Negocios.SalidasAlmacenBU
        Dim Tabla_ListadoParametros As New DataTable

        Try
            Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(1)
            Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
            cmbMensajeria.DataSource = Tabla_ListadoParametros
            cmbMensajeria.DisplayMember = "Nombre"
            cmbMensajeria.ValueMember = "ID"

            Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(2)
            Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
            cmbOperador.DataSource = Tabla_ListadoParametros
            cmbOperador.DisplayMember = "Operador"
            cmbOperador.ValueMember = "ID"

            Tabla_ListadoParametros = objBU.LlenarCombosGenerarEntrega(3)
            Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
            cmbUnidad.DataSource = Tabla_ListadoParametros
            cmbUnidad.DisplayMember = "Unidad"
            cmbUnidad.ValueMember = "ID"

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub cmbMensajeria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMensajeria.SelectedIndexChanged
        If RTrim(LTrim(cmbMensajeria.SelectedItem(1).ToString())) = "YUYIN (NOSOTROS MISMOS)" Then
            cmbOperador.Enabled = True
            cmbOperador.SelectedIndex = -1
            cmbUnidad.Enabled = True
            cmbUnidad.SelectedIndex = -1
            txtNombreOperador.Visible = False
            cmbOperador.Visible = True
        Else
            cmbOperador.Enabled = False
            cmbOperador.SelectedIndex = -1
            txtNombreOperador.Visible = True
            cmbOperador.Visible = False
            If RTrim(LTrim(cmbMensajeria.SelectedItem(1).ToString())) = "CLIENTE (RECOGE)" Then
                cmbUnidad.Enabled = False
                cmbUnidad.SelectedIndex = -1
            Else
                cmbUnidad.Enabled = True
                cmbUnidad.SelectedIndex = -1
            End If
        End If
    End Sub



    Private Sub btnCodigosConErrores_Click(sender As Object, e As EventArgs) Handles btnCodigosConErrores.Click
        Dim FrmCodigoError As New CodigosErrorFolioVerificacionForm
        FrmCodigoError.FolioVerificacionID = FolioVerificacionId
        FrmCodigoError.ShowDialog()
    End Sub

    Public Sub imprimirReporte()
        Dim dtFiniquitoFiscal As New DataTable
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsTotalEmbarque As New DataSet("dsTotalEmbarque")
        Dim dtTotalesEmbarque As New DataTable
        Dim dtInformacion As New DataTable
        Dim ReporteEmbarque As New StiReport
        Dim NumeroFilas As Integer = 0

        Dim tool As New Tools.Controles

        Try

            Cursor = Cursors.WaitCursor

            dtInformacion = ObjBU.ObtenerInformacionEncabezadoReporteFolio(FolioVerificacionId)
            dtTotalesEmbarque = ObjBU.ObtenerInformacionReporteFolio(FolioVerificacionId)

            entReporte = objReporte.LeerReporteporClave("ALM_REPORTE_FOLIO_EMBARQUE")
            dsTotalEmbarque.Tables.Add(dtTotalesEmbarque)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReporteEmbarque.Load(archivo)
            ReporteEmbarque.Compile()
            ReporteEmbarque.RegData(dsTotalEmbarque.Tables(0))
            ReporteEmbarque("TotalPares") = CDbl(dtInformacion.Rows(0).Item("TotalPares")).ToString("N0")
            ReporteEmbarque("TotalAtados") = CDbl(dtInformacion.Rows(0).Item("Atados")).ToString("N0")
            ReporteEmbarque("TotalOT") = dtInformacion.Rows(0).Item("TotalOT").ToString()
            ReporteEmbarque("Recibio") = dtInformacion.Rows(0).Item("Operador").ToString()
            ReporteEmbarque("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            ReporteEmbarque("NombreReporte") = "ReporteFolioEmbarque"
            ReporteEmbarque("FolioEmbarque") = FolioVerificacionId.ToString()
            ReporteEmbarque("Mensajeria") = dtInformacion.Rows(0).Item("Mensajeria").ToString()
            ReporteEmbarque("Operador") = dtInformacion.Rows(0).Item("Operador").ToString()
            ReporteEmbarque("Entrego") = dtInformacion.Rows(0).Item("Entrego").ToString()
            ReporteEmbarque("Transporte") = dtInformacion.Rows(0).Item("Unidad").ToString()
            ReporteEmbarque("FolioPaqueteria") = dtInformacion.Rows(0).Item("FolioPaqueteria").ToString()
            ReporteEmbarque("Cliente") = dtInformacion.Rows(0).Item("Cliente").ToString()
            ReporteEmbarque.Dictionary.Clear()
            ReporteEmbarque.Dictionary.Synchronize()
            ReporteEmbarque.Render()
            ReporteEmbarque.Show()


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub btnDescartarAtados_Click(sender As Object, e As EventArgs) Handles btnDescartarAtados.Click

        DescartarAtados = True
        lblDescartarPares.Visible = DescartarAtados
        txtLectura.Focus()

        ActualizarPantalla()
    End Sub

    Private Sub DescartarPares(ByVal CodigoCapturado As String)
        Dim CodigoCapturadoAux As String()
        Dim EsCodigoPar As Boolean = False
        Dim DTParesOT As New DataTable

        Try
            CodigoCapturadoAux = CodigoCapturado.Split("-")
            If CodigoCapturadoAux.Length = 3 Then
                EsCodigoPar = True
            End If

            If ListadodeParesFolioVerificacion.Rows.Count = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Ya no hay pares para descartar.")
            Else

                If EsCodigoPar = True Then
                    If ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar") = CodigoCapturadoAux(2)).Count > 0 Then

                        Dim ParDescartado = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar") = CodigoCapturadoAux(2)).FirstOrDefault()
                        ParDescartado.Item("Descartado") = True
                        'Actualizar en base de datos
                        ParesDescartados += 1
                        ObjBU.DescartarPares(FolioVerificacionId, CodigoCapturadoAux(2), EsCodigoPar)
                    Else
                        ReproducirSonidoError()


                    End If

                Else
                    If ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString.TrimStart("0") = CodigoCapturadoAux(0)).Count = 0 Then

                        Dim Filas = ListadodeParesFolioVerificacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado") = CodigoCapturadoAux(0)).ToList

                        For Each Fila As DataRow In Filas
                            Fila.Item("Descartado") = True
                            ParesDescartados += 1
                        Next
                        'Actualizar en base de datos
                        ObjBU.DescartarPares(FolioVerificacionId, CodigoCapturado, EsCodigoPar)
                    Else
                        ReproducirSonidoError()


                    End If

                End If
            End If


        Catch ex As Exception
            ReproducirSonidoError()


        End Try

    End Sub

    Private Sub CargarParesPendientesAndrea()
        Dim DtResultado As New DataTable

        Try
            Cursor = Cursors.WaitCursor
            dtParesConfirmadosAndrea = ObjBU.ConsultarParesAConfirmarAndrea(FolioVerificacionId)
            grdParesPendientes.DataSource = dtParesConfirmadosAndrea
            DiseñoGrid.PropiedadesGrid(viewParesPendientes, True, DevExpress.Utils.HorzAlignment.Center, True)
            DiseñoGrid.EstiloColumna(viewParesPendientes, "CodigoAndrea", "Codigo Andrea", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ColeccionSAY", "Colección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "DescripcionCompleta", "Artículo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try



    End Sub

    '*************************************************************************************
    '*****************  FABRICAS DE CALZADO ANDREA ***************************************
    '**************************************************************************************

    Private Sub CargarParesConfirmadosAndrea()
        Dim DtResultado As New DataTable

        Try
            Cursor = Cursors.WaitCursor

            dtParesPendientesAndrea = ObjBU.ConsultarParesAConfirmarAndrea(FolioVerificacionId)
            grdParesPendientes.DataSource = dtParesPendientesAndrea
            viewParesPendientes.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
            DiseñoGrid.PropiedadesGrid(viewParesPendientes, True, DevExpress.Utils.HorzAlignment.Center, True)
            DiseñoGrid.EstiloColumna(viewParesPendientes, "CodigoAndrea", "Codigo Andrea", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ColeccionSAY", "Colección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "DescripcionCompleta", "Artículo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ParesPendientes", "Pares " & vbCrLf & " Pendientes", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ParesConfirmados", "Pares" & vbCrLf & " Confirmados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewParesPendientes, "ParesErrores", "Pares" & vbCrLf & "Errores", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "")
            'DiseñoGrid.EstiloColumna(viewParesPendientes, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")

            viewParesPendientes.RowHeight = 30
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub ConsultarParesConfirmadosAndrea()
        Dim DtResultado As New DataTable

        Try
            Cursor = Cursors.WaitCursor

            DtResultado = ObjBU.ConsultarParesConfirmadosAndrea(FolioVerificacionId)
            grdParesConfirmados.DataSource = DtResultado
            viewParesConfirmados.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways
            DiseñoGrid.PropiedadesGrid(viewParesConfirmados, True, DevExpress.Utils.HorzAlignment.Center, True)
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "CodigoAndrea", "Codigo Andrea", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "ModeloSAY", "Modelo SAY", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "ColeccionSAY", "Colección", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "DescripcionCompleta", "Artículo", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "ParesPendientes", "Pares " & vbCrLf & " Pendientes", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "ParesConfirmados", "Pares" & vbCrLf & " Confirmados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "")
            DiseñoGrid.EstiloColumna(viewParesConfirmados, "ParesErrores", "Pares" & vbCrLf & "Errores", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "")

            'DiseñoGrid.EstiloColumna(viewParesConfirmados, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 100, False, DevExpress.Data.SummaryItemType.None, "")

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

    End Sub

    Private Sub ActualizarPantalla_Andrea()
        Dim ParesPendientes As Integer = 0
        Dim ParesConfirmados As Integer = 0
        Dim TotalPares As Integer = 0

        Try
            CargarParesConfirmadosAndrea()
            ConsultarParesConfirmadosAndrea()

            TotalOT = 0

            ParesPendientes = dtParesPendientesAndrea.AsEnumerable.Sum(Function(x) x.Item("ParesPendientes"))
            ParesConfirmados = dtParesPendientesAndrea.AsEnumerable.Sum(Function(x) x.Item("ParesConfirmados"))
            TotalPares = ParesPendientes + ParesConfirmados

            lblTotalPares.Text = CDbl(TotalPares).ToString("N0")
            lblParesConfirmados.Text = CDbl(ParesConfirmados).ToString("N0")
            lblParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
            lblParesDescartados.Text = CDbl(ParesErrores).ToString("N0")

            If ParesErrores > 0 Then
                lblParesDescartados.ForeColor = Color.Red
            Else
                lblParesDescartados.ForeColor = Color.Black
            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            ReproducirSonidoError()
        End Try

    End Sub

    Private Sub ActualizarInformacion_Andrea()
        Dim ParesPendientes As Integer = 0
        Dim ParesConfirmados As Integer = 0
        Dim TotalPares As Integer = 0

        Try

            TotalOT = 0

            ParesPendientes = dtParesPendientesAndrea.AsEnumerable.Sum(Function(x) x.Item("ParesPendientes"))
            ParesConfirmados = dtParesPendientesAndrea.AsEnumerable.Sum(Function(x) x.Item("ParesConfirmados"))
            ParesErrores = dtParesPendientesAndrea.AsEnumerable.Sum(Function(x) x.Item("ParesErrores"))

            TotalPares = ParesPendientes + ParesConfirmados

            lblTotalPares.Text = CDbl(TotalPares).ToString("N0")
            lblParesConfirmados.Text = CDbl(ParesConfirmados).ToString("N0")
            lblParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
            lblParesDescartados.Text = CDbl(ParesErrores + ParesNoExiste).ToString("N0")

            lblPanelParesLeidos.Text = CDbl(ParesConfirmados).ToString("N0")
            lblPanelParesPendientes.Text = CDbl(ParesPendientes).ToString("N0")
            lblPanelParesExcedentes.Text = CDbl(ParesErrores + ParesNoExiste).ToString("N0")

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            ReproducirSonidoError()
        End Try
    End Sub


    Private Sub ConfirmarParesAndrea(ByVal LecturaCodigo As String)
        Dim Codigo As String = String.Empty

        Try
            LecturaCodigo = LecturaCodigo.Substring(0, LecturaCodigo.Length - 1)

            If dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo.TrimStart("0")).Count > 0 Then

                If dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo.TrimStart("0") And x.Item("ParesPendientes") > 0).Count > 0 Then

                    Codigo = dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo.TrimStart("0")).Select(Function(y) y.Item("CodigoAndrea")).FirstOrDefault.ToString
                    ObjBU.ConfirmarParesAndrea(FolioVerificacionId, Codigo, ColaboradorId)

                    Dim CodigoPar = dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo.TrimStart("0")).FirstOrDefault
                    CodigoPar.Item("ParesPendientes") = CodigoPar.Item("ParesPendientes") - 1

                    Dim CodigoParConfirmado = dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo.TrimStart("0")).FirstOrDefault
                    CodigoParConfirmado.Item("ParesConfirmados") = CodigoParConfirmado.Item("ParesConfirmados") + 1

                    ParesConfirmadosAndrea += 1
                    ParesPendientesConfirmarAndrea = ParesPendientesConfirmarAndrea - 1

                    If (ParesConfirmadosAndrea Mod 5) = 0 Then
                        ReproducirSonidoCorrecto()
                    End If

                Else
                    ReproducirSonidoError()
                    ObjBU.InsertaCodigoErrorAndrea(FolioVerificacionId, LecturaCodigo, "Se ha superado el número de codigos a leer por estilo.")

                    Dim CodigoParError = dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo.TrimStart("0")).FirstOrDefault
                    CodigoParError.Item("ParesErrores") = CodigoParError.Item("ParesErrores") + 1
                    ParesErrores += 1
                End If

            Else
                ReproducirSonidoError()
                ObjBU.InsertaCodigoErrorAndrea(FolioVerificacionId, LecturaCodigo, "El codigo no existe.")
                ParesNoExiste += 1

            End If

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try


    End Sub

    Private Sub ActualizarDataSource()
        'Dim CodigoPar = dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo).FirstOrDefault
        'CodigoPar.Item("Pares") = CodigoPar.Item("Pares") - 1


        'Dim CodigoParConfirmado = dtParesConfirmadosAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = LecturaCodigo).FirstOrDefault
        'CodigoParConfirmado.Item("Pares") = CodigoParConfirmado.Item("Pares") + 1

    End Sub

    Private Sub viewParesPendientes_RowStyle(sender As Object, e As RowStyleEventArgs) Handles viewParesPendientes.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Try

                Cursor = Cursors.WaitCursor
                Dim ParesConfirmados As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ParesConfirmados"))
                Dim ParesPendientes As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ParesPendientes"))
                If ParesPendientes = 0 Then
                    e.Appearance.BackColor = Color.LightGreen
                Else
                    e.Appearance.BackColor = Color.White
                End If

                'e.Appearance.BackColor = ObtenerColorFila(Bloqueo, EstatusID)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                'show_message("Error", ex.Message.ToString())
            End Try


        End If
    End Sub

    Private Sub btnLimpiarPares_Click(sender As Object, e As EventArgs) Handles btnLimpiarPares.Click
        Dim formaConfirmacion As New ConfirmarForm
        Dim NumeroFilas As Integer = 0
        Dim OT As String = String.Empty
        Dim ListaOt As New List(Of Integer)
        Dim CodigoAndrea As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0

        Try
            formaConfirmacion.StartPosition = FormStartPosition.CenterScreen
            formaConfirmacion.mensaje = "¿Estas seguro de limpiar los pares?"


            If formaConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor

                NumeroFilas = viewParesPendientes.DataRowCount
                For index As Integer = 0 To NumeroFilas Step 1

                    If viewParesPendientes.IsRowSelected(viewParesPendientes.GetVisibleRowHandle(index)) = True Then
                        FilasSeleccionadas += 1
                        CodigoAndrea = viewParesPendientes.GetRowCellValue(viewParesPendientes.GetVisibleRowHandle(index), "CodigoAndrea")
                    End If
                Next

                If FilasSeleccionadas > 0 Then
                    ObjBU.LimpiarParesAndrea(FolioVerificacionId, CodigoAndrea)

                    Dim CodigoPar = dtParesPendientesAndrea.AsEnumerable.Where(Function(x) x.Item("CodigoAndrea").ToString.TrimStart("0") = CodigoAndrea.TrimStart("0")).FirstOrDefault
                    CodigoPar.Item("ParesPendientes") = CodigoPar.Item("ParesPendientes") + CodigoPar.Item("ParesConfirmados")
                    CodigoPar.Item("ParesConfirmados") = 0
                    CodigoPar.Item("ParesErrores") = 0

                    ActualizarInformacion_Andrea()
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Se ha reiniciado el contador de pares.")
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se ha seleccionado una fila.")
                End If


            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        If EsAndrea = False Then
            ValidarSessionesActivas()

            pnlParesExcedente.Visible = True
            pnlParesLeidos.Visible = True
            pnlParesPendientes.Visible = True

            'grdParesConfirmados.Visible = False
            'grdParesPendientes.Visible = False

        Else
            pnlParesExcedente.Visible = True
            pnlParesLeidos.Visible = True
            pnlParesPendientes.Visible = True

            grdParesConfirmados.Visible = False
            SplitContainer1.Panel1.Visible = True
            SplitContainer1.Panel1Collapsed = False
            'SplitContainer1.Panel2.MaximumSize = MaximumSize
        End If

        MostrarVistaDeIndicadores = True
        HabilitarControles(False)
        lblDescartarPares.Visible = DescartarAtados
        txtLectura.Focus()
    End Sub

    Private Sub viewParesPendientes_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles viewParesPendientes.RowCellStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Try
                If e.Column.FieldName = "ParesErrores" Then
                    If e.CellValue > 0 Then
                        e.Appearance.BackColor = Color.Red
                        e.Appearance.ForeColor = Color.White
                    Else
                        Dim ParesConfirmados As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ParesConfirmados"))
                        Dim ParesPendientes As Integer = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ParesPendientes"))
                        If ParesPendientes = 0 Then
                            e.Appearance.BackColor = Color.LightGreen
                        Else
                            e.Appearance.BackColor = Color.White
                        End If
                    End If
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        End If

    End Sub

    Private Sub btnCambiarVista_Click(sender As Object, e As EventArgs) Handles btnCambiarVista.Click

        MostrarVistaDeIndicadores = Not MostrarVistaDeIndicadores

        If EsAndrea = True Then
            If MostrarVistaDeIndicadores = True Then
                pnlParesExcedente.Visible = True
                pnlParesLeidos.Visible = True
                pnlParesPendientes.Visible = True

                grdParesConfirmados.Visible = False
                SplitContainer1.Panel1.Visible = True
                SplitContainer1.Panel1Collapsed = False


            Else
                grdParesConfirmados.Visible = False
                SplitContainer1.Panel1.Visible = False
                SplitContainer1.Panel1Collapsed = True
                SplitContainer1.Panel2.MaximumSize = MaximumSize

                pnlParesExcedente.Visible = False
                pnlParesLeidos.Visible = False
                pnlParesPendientes.Visible = False
            End If

        Else
            If MostrarVistaDeIndicadores = True Then
                pnlParesExcedente.Visible = True
                pnlParesLeidos.Visible = True
                pnlParesPendientes.Visible = True
            Else
                pnlParesExcedente.Visible = False
                pnlParesLeidos.Visible = False
                pnlParesPendientes.Visible = False
            End If

        End If


        txtLectura.Focus()
    End Sub

    Private Sub btnAgregarOT_Click(sender As Object, e As EventArgs) Handles btnAgregarOT.Click
        AgregarOT()
    End Sub

    Private Sub AgregarOT()
        If EsAndrea = True Then
            Dim form As New AndreaFechaEntregaForm
            'form.MdiParent = Me.MdiParent
            form._AgregarLote = True
            form._FolioVerificacionId = FolioVerificacionId
            If form.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                ActualizarPantalla_Andrea()
                ActualizarInformacion_Andrea()
                Cursor = Cursors.Default
            End If

        Else
            Dim AgregarForm As New AgregarOTForm
            AgregarForm.ClienteID = ClienteID
            AgregarForm.FolioVerificacion = FolioVerificacionId
            If AgregarForm.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                ListadodeParesFolioVerificacion = ObjBU.ConsultarParesVerificacionFolio(FolioVerificacionId)
                ActualizarPantalla()
                Cursor = Cursors.Default
            End If

        End If

    End Sub

    Private Sub btnQuitarDocumentosAndrea_Click(sender As Object, e As EventArgs) Handles btnQuitarDocumentosAndrea.Click
        Dim form As New LotesAndreaFolioVerificacionForm
        form.FolioVerificacionId = FolioVerificacionId
        form.ShowDialog()

        ActualizarPantalla_Andrea()
        ActualizarInformacion_Andrea()
    End Sub

    Private Sub AbrirPDFFactura(ByVal RutaPDF As String)
        Try
            Process.Start(RutaPDF)
        Catch ex As Exception
        End Try
    End Sub
End Class