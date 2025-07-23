Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports System.Drawing
Imports System.Net
Imports Stimulsoft.Report
Imports Framework.Negocios

Public Class CompletarAltaColaboradorIMSSForm
    Public dtColabo As New DataTable
    Public idNave As Int32 = 0
    Public editaridColaborador As Int32 = 0
    Public idAlta As Int32 = 0

    Dim idPatron As Int32 = 0
    Dim idNomina As Int32 = 0

    Dim idColaborador As Int32 = 0
    Dim listaColaboradores As New List(Of Entidades.AltaColaboradorIMSS)
    Dim nombresPorValidar As String = String.Empty
    Dim validarGeneral As Boolean = True
    Dim validaRetencion As Boolean = True
    Dim listaRetencion As String = String.Empty
    Dim salariominimo As Double = 0
    Dim banderaSDI As Boolean = True
    Dim validaInfonavit As Boolean = True
    Dim mensajeInfonavit As String = String.Empty
    Dim directorio As String = String.Empty
    Dim SMD As Double = 0
    'Dim tipoMovimiento As Int32 = 0
    Public dtNombre As New DataTable
    Public editar As Boolean = False





    Public Sub cargarDatosIniciales()
        grdColaboradoresImss.DataSource = Nothing
        dtNombre.Columns.Add("nombre")
        dtNombre.Columns.Add("idColaborador")
        dtNombre.Columns.Add("idAlta")

        cargarCombosIniciales()
        llenarComboTipoDescuentos()
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtFecha As New DataTable
        Dim dtComplementa As New DataTable

        pnlArchivoCargado.Visible = False

        If Not dtColabo Is Nothing Then
            If dtColabo.Rows.Count > 0 Then
                grdColaboradoresImss.DataSource = dtColabo
                formatogrid()
            End If
        End If

        If editaridColaborador <> 0 Then ''para cuando es edicion
            Dim objBuE As New Negocios.ColaboradoresContabilidadBU
            Dim dtEditar As New DataTable

            dtEditar = objBu.consultaInformacionParaEditarImss(idAlta)
            cmbTipoJornada.Enabled = False
            cmbTipoSalario.Enabled = False
            cmbTipoSalario.Enabled = False
            'txtUMF.Enabled = False
            cmbUmf.Enabled = False
            cmbDeptoFiscal.Enabled = False
            cmbPuestoFiscal.Enabled = False
            dtpFechaAlta.Enabled = False
            rdoInfonavitNo.Enabled = False
            rdoInfonavitSI.Enabled = False
            cmbTipoTrabajador.Enabled = False
            txtValorDescuento.Enabled = False
            cmbTipoDes.Enabled = False
            txtNumeroCredito.Enabled = False
            btnPdfInfonavit.Enabled = False

            If dtEditar.Rows.Count > 0 Then

                If dtEditar.Rows(0).Item("infonavit") = 1 Then
                    rdoInfonavitSI.Checked = True
                Else
                    rdoInfonavitNo.Checked = True
                End If
                lblPatron.Text = dtEditar.Rows(0).Item("patron")
                idPatron = dtEditar.Rows(0).Item("patronid")

                ''Tipo Colaborador
                Dim dtTipoCola As New DataTable
                Dim objBuu As New Negocios.UtileriasBU
                dtTipoCola = objBuu.consultaTipoTrabajador(idPatron)

                If dtTipoCola.Rows.Count > 0 Then
                    cmbTipoTrabajador.DataSource = dtTipoCola
                    cmbTipoTrabajador.DisplayMember = "tipoColaborador"
                    cmbTipoTrabajador.ValueMember = "idTipoColaborador"
                    'cmbTipoTrabajador.SelectedIndex = 0
                End If

                lblCurp.Text = dtEditar.Rows(0).Item("curp")
                lblRfc.Text = dtEditar.Rows(0).Item("rfc")
                lblNombre.Text = dtEditar.Rows(0).Item("nombre")
                lblnss.Text = dtEditar.Rows(0).Item("nss")
                txtSDI.Text = dtEditar.Rows(0).Item("sdi")
                cmbTipoTrabajador.SelectedValue = dtEditar.Rows(0).Item("idtrabajador")
                cmbTipoSalario.SelectedValue = dtEditar.Rows(0).Item("tipoSalario")
                cmbTipoJornada.SelectedValue = dtEditar.Rows(0).Item("tipoJornada")
                dtpFechaAlta.Value = dtEditar.Rows(0).Item("fechaAlta")
                'txtUMF.Text = dtEditar.Rows(0).Item("umf")
                cmbUmf.SelectedValue = dtEditar.Rows(0).Item("umf")

                cargarComboDepartamentoFiscal()
                cargarComboPuestoFiscal()
                cmbDeptoFiscal.SelectedValue = dtEditar.Rows(0).Item("departamentoFiscalId")
                cmbPuestoFiscal.SelectedValue = dtEditar.Rows(0).Item("puestoFiscalId")

                ''infonavit
                If dtEditar.Rows(0).Item("infonavit") = 1 Then
                    rdoInfonavitSI.Checked = True
                Else
                    rdoInfonavitNo.Checked = True
                End If
                txtValorDescuento.Text = dtEditar.Rows(0).Item("valorD")
                txtNumeroCredito.Text = dtEditar.Rows(0).Item("numeroCredito")
                cmbTipoDes.SelectedValue = dtEditar.Rows(0).Item("tipoDescuento")
                If dtEditar.Rows(0).Item("archivo") = 1 Then
                    pnlArchivoCargado.Visible = True
                Else
                    pnlArchivoCargado.Visible = False
                End If
                lblCantidadDes.Text = dtEditar.Rows(0).Item("descuentoSema")

            End If
        Else
            For Each rowCola As DataRow In dtColabo.Rows
                Dim colaboImss As New Entidades.AltaColaboradorIMSS
                colaboImss.PColaboradorId = rowCola.Item("idColaborador")
                'colaboImss.PPAtronId = idPatron
                colaboImss.PPAtronId = rowCola.Item("patronId")
                colaboImss.PPatron = rowCola.Item("patron")
                colaboImss.PPeriodoNominaID = idNomina
                listaColaboradores.Add(colaboImss)


                ''obtener fecha de alta
                dtFecha = objBu.obtenerFechaAlta(idPatron)


                If dtFecha.Rows.Count > 0 Then
                    idNomina = dtFecha.Rows(0).Item("idPeriodo").ToString
                    dtpFechaAlta.Value = dtFecha.Rows(0).Item("fechaValue").ToString
                    dtpFechaAlta.MinDate = dtFecha.Rows(0).Item("fechaAlta").ToString
                    dtpFechaAlta.MaxDate = dtFecha.Rows(0).Item("fechaFinal").ToString
                Else
                    'Dim advertencia As New AdvertenciaForm
                    'advertencia.mensaje = "No existe configuración de periodos de nómina para la nave"
                    'advertencia.ShowDialog()
                    'btnGuardar.Enabled = False
                End If

                objBu = New Negocios.ColaboradoresContabilidadBU
                dtComplementa = objBu.consultaDatosComplementariosIMSS(rowCola.Item("idColaborador"))

                If Not dtComplementa Is Nothing Then
                    If dtComplementa.Rows.Count > 0 Then
                        colaboImss.PNombre = dtComplementa.Rows(0).Item("nombre")
                        colaboImss.PCurp = dtComplementa.Rows(0).Item("curp")
                        colaboImss.PRFC = dtComplementa.Rows(0).Item("rfc")
                        colaboImss.PNSS = dtComplementa.Rows(0).Item("nss")
                        colaboImss.PTieneCredito = dtComplementa.Rows(0).Item("infonavit")
                        'colaboImss.PAplicaTabla = dtComplementa.Rows(0).Item("aplicaTabla")

                        'colaboImss.PNumeroCredito = dtComplementa.Rows(0).Item("numeroCredito")
                        'colaboImss.PTipoDescuentoId = dtComplementa.Rows(0).Item("tipoDescuento")
                        'colaboImss.PCantidadDescontar = dtComplementa.Rows(0).Item("descontar").ToString
                        colaboImss.PSDI = dtComplementa.Rows(0).Item("sdi")
                        colaboImss.PTipoTrabajadorId = dtComplementa.Rows(0).Item("tipoTrabajador")
                        colaboImss.PUMF = dtComplementa.Rows(0).Item("umf")
                        colaboImss.PIdNave = idNave
                        colaboImss.PFechaAlta = dtpFechaAlta.Value.ToShortDateString
                        'colaboImss.PValorDescuento = dtComplementa.Rows(0).Item("valorDescuento")
                        colaboImss.PDepartamentoFiscalId = dtComplementa.Rows(0).Item("departamentoFiscalId")
                        colaboImss.PPuestoFiscalId = dtComplementa.Rows(0).Item("puestoFiscalId")
                        If colaboImss.PSDI = 0 Then
                            banderaSDI = False

                        End If
                    End If
                End If
            Next
        End If



    End Sub

    Public Sub cargarCombosIniciales()
        Dim objBu As New Contabilidad.Negocios.UtileriasBU
        ''TIPO DESCUENTO
        Dim dtTipoDescuento As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoDescuento = objBu.consultaTipoDescuento

        'If dtTipoDescuento.Rows.Count > 0 Then
        '    cmbTipoDes.DataSource = dtTipoDescuento
        '    cmbTipoDes.DisplayMember = "Descuento"
        '    cmbTipoDes.ValueMember = "idDescuento"
        '    cmbTipoDes.SelectedIndex = 0
        'End If



        ''tipo Salario
        Dim dtTipoSalario As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoSalario = objBu.consultaTipoSalario

        If dtTipoSalario.Rows.Count > 0 Then
            cmbTipoSalario.DataSource = dtTipoSalario
            cmbTipoSalario.DisplayMember = "TipoSalario"
            cmbTipoSalario.ValueMember = "IDTipoSalario"
            cmbTipoSalario.SelectedValue = 1
        End If

        ''tipoJornada
        Dim dtTipoJornada As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoJornada = objBu.consultaTipoJornada

        If dtTipoJornada.Rows.Count > 0 Then
            cmbTipoJornada.DataSource = dtTipoJornada
            cmbTipoJornada.DisplayMember = "TipoJornada"
            cmbTipoJornada.ValueMember = "IDTipoJornada"
            cmbTipoJornada.SelectedValue = 7
        End If

        objBu = New Negocios.UtileriasBU
        Dim dtPatronNave As New DataTable

        dtPatronNave = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, idNave)

        If Not dtPatronNave Is Nothing Then
            If dtPatronNave.Rows.Count > 0 Then
                'lblPatron.Text = dtPatronNave.Rows(1).Item("patron")
                'idPatron = dtPatronNave.Rows(1).Item("id")
            End If
        End If

        ''Tipo Colaborador
        Dim dtTipoCola As New DataTable
        objBu = New Negocios.UtileriasBU
        dtTipoCola = objBu.consultaTipoTrabajador(idPatron)

        If dtTipoCola.Rows.Count > 0 Then
            cmbTipoTrabajador.DataSource = dtTipoCola
            cmbTipoTrabajador.DisplayMember = "tipoColaborador"
            cmbTipoTrabajador.ValueMember = "idTipoColaborador"
            'cmbTipoTrabajador.SelectedValue = dtTipoCola.Rows(0)("tipoDefault").ToString
        End If

        ''UMF
        objBu = New Negocios.UtileriasBU
        Dim dtUmf As New DataTable
        dtUmf = objBu.consultaUnidadMedicaFamiliar()

        If dtUmf.Rows.Count > 0 Then
            cmbUmf.DataSource = dtUmf
            cmbUmf.DisplayMember = "umf"
            cmbUmf.ValueMember = "id"
        End If

    End Sub

    Public Sub formatogrid()
        With grdColaboradoresImss.DisplayLayout.Bands(0)

            .Columns("idColaborador").Hidden = True
            .Columns("seleccion").Hidden = True
            .Columns("umfId").Hidden = True
            .Columns("patronId").Hidden = True
            .Columns("patron").Hidden = True

            .Columns("Seleccion").Header.Caption = ""
            .Columns("apaterno").Header.Caption = "A.Paterno"
            .Columns("aMaterno").Header.Caption = "A.Materno"
            .Columns("nombre").Header.Caption = "Nombre"
            .Columns("curp").Header.Caption = "Curp"
            .Columns("rfc").Header.Caption = "RFC"
            .Columns("nss").Header.Caption = "NSS"
            .Columns("diasantiguedad").Header.Caption = "Días Antiguedad"
            .Columns("puesto").Header.Caption = "Puesto"
            .Columns("sdi").Header.Caption = "SDI"


            .Columns("apaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("aMaterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("curp").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("rfc").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("nss").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("diasantiguedad").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("puesto").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("sdi").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("sdi").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("diasantiguedad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("sdi").Format = "###,###,##0.00"
            .Columns("diasantiguedad").Format = "###,###,##0.00"

            .Columns("Seleccion").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            '.Columns("Seleccion").AllowRowFiltering = DefaultableBoolean.False


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdColaboradoresImss.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdColaboradoresImss.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdColaboradoresImss.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColaboradoresImss.DisplayLayout.Override.RowSelectorWidth = 35
        grdColaboradoresImss.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdColaboradoresImss.Rows(0).Selected = True

        grdColaboradoresImss.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        grdColaboradoresImss.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Public Sub cargarDatosColaboradorSeleccionado()
        Dim idSeleccionado As Int32 = 0
        Dim colSele As New Entidades.AltaColaboradorIMSS
        Dim objFTP As New Tools.TransferenciaFTP


        If idColaborador <> 0 Then
            Dim item As Integer = listaColaboradores.FindIndex(Function(c) c.PColaboradorId = idColaborador)
            directorio = rutaAcuses & idColaborador
            listaColaboradores.Item(item).PFechaAlta = dtpFechaAlta.Value.ToShortDateString
            If rdoInfonavitSI.Checked = True Then
                listaColaboradores.Item(item).PTieneCredito = True
            Else
                listaColaboradores.Item(item).PTieneCredito = False
            End If

            listaColaboradores.Item(item).PNumeroCredito = txtNumeroCredito.Text
            listaColaboradores.Item(item).PTipoDescuentoId = cmbTipoDes.SelectedValue

            If rdoDisminucionSI.Checked = True Then
                listaColaboradores.Item(item).PAplicaTabla = True
            Else
                listaColaboradores.Item(item).PAplicaTabla = False
            End If

            listaColaboradores.Item(item).PCantidadDescontar = lblCantidadDes.Text
            listaColaboradores.Item(item).PSDI = txtSDI.Text
            listaColaboradores.Item(item).PTipoTrabajadorId = cmbTipoTrabajador.SelectedValue
            listaColaboradores.Item(item).PTipoSalarioId = cmbTipoSalario.SelectedValue
            listaColaboradores.Item(item).PTipoJornadaID = cmbTipoJornada.SelectedValue
            'listaColaboradores.Item(item).PUMF = txtUMF.Text
            listaColaboradores.Item(item).PUMF = cmbUmf.SelectedValue
            listaColaboradores.Item(item).PDepartamentoFiscalId = cmbDeptoFiscal.SelectedValue
            listaColaboradores.Item(item).PPuestoFiscalId = cmbPuestoFiscal.SelectedValue
            listaColaboradores.Item(item).PValorDescuento = txtValorDescuento.Text

            If txtRutaRetencion.Text <> "" Then
                listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIRutaarchivoretencion = objFTP.obtenerURL & "/" & directorio & "/" & txtRutaRetencion.Text
                listaColaboradores.Item(item).PRutaArchivoRetencion = opfArchivoRetencion.FileName
                listaColaboradores.Item(item).PCargoRetencion = True
                pnlArchivoCargado.Visible = True
                listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIFechamovimiento = dtpFechaAlta.Value.ToShortDateString
            End If
        End If


        idSeleccionado = grdColaboradoresImss.ActiveRow.Cells("idColaborador").Value()

        If idSeleccionado <> 0 Then
            colSele = listaColaboradores.Find(Function(c) c.PColaboradorId = idSeleccionado)
            directorio = rutaAcuses & idSeleccionado
            lblNombre.Text = colSele.PNombre
            lblCurp.Text = colSele.PCurp
            lblRfc.Text = colSele.PRFC
            lblnss.Text = colSele.PNSS

            If colSele.PTieneCredito = True Then
                rdoInfonavitSI.Checked = True
            Else
                rdoInfonavitNo.Checked = True
            End If

            If colSele.PAplicaTabla = True Then
                rdoDisminucionSI.Checked = True
            Else
                rdoDisminucionNo.Checked = True
            End If
            If colSele.PFechaAlta >= dtpFechaAlta.MinDate And colSele.PFechaAlta < dtpFechaAlta.MaxDate Then
                dtpFechaAlta.Value = colSele.PFechaAlta
            End If

            txtNumeroCredito.Text = colSele.PNumeroCredito
            cmbTipoDes.SelectedValue = colSele.PTipoDescuentoId
            lblCantidadDes.Text = colSele.PCantidadDescontar
            txtSDI.Text = colSele.PSDI
            'cmbTipoTrabajador.SelectedValue = colSele.PTipoTrabajadorId
            'txtUMF.Text = colSele.PUMF
            lblPatron.Text = colSele.PPatron

            idPatron = colSele.PPAtronId
            cargarComboDepartamentoFiscal()
            cargarComboPuestoFiscal()
            cmbDeptoFiscal.SelectedValue = colSele.PDepartamentoFiscalId
            cmbPuestoFiscal.SelectedValue = colSele.PPuestoFiscalId
            cmbUmf.SelectedValue = colSele.PUMF
            txtValorDescuento.Text = colSele.PValorDescuento
            If colSele.PCargoRetencion = True Then
                pnlArchivoCargado.Visible = True
                'Dim ruta() As String
                'ruta = colSele.PEntidadCreditoInfonavit.CIRutaarchivoretencion.Split("/")
                txtRutaRetencion.Text = colSele.PRutaArchivoRetencion
            Else
                pnlArchivoCargado.Visible = False
                txtRutaRetencion.Text = ""
            End If
            idColaborador = idSeleccionado
            Panel2.Enabled = True
        End If

        cargarFechaAlta()
        If PermisosUsuarioBU.ConsultarPermiso("GEN_ALTAIMSS", "TODAS_FECHAS") Then
            dtpFechaAlta.Enabled = True
        Else
            dtpFechaAlta.Enabled = False
        End If
    End Sub

    Private Sub cargarFechaAlta()
        If (idPatron <> 0) Then
            Dim dtFecha As New DataTable
            Dim objBu As New Negocios.ColaboradoresContabilidadBU
            ''obtener fecha de alta
            dtFecha = objBu.obtenerFechaAlta(idPatron)

            If dtFecha.Rows.Count > 0 Then
                idNomina = dtFecha.Rows(0).Item("idPeriodo").ToString
                dtpFechaAlta.Value = dtFecha.Rows(0).Item("fechaValue").ToString
                'dtpFechaAlta.MinDate = dtFecha.Rows(0).Item("fechaAlta").ToString
                'dtpFechaAlta.MaxDate = dtFecha.Rows(0).Item("fechaFinal").ToString
            Else
                Dim advertencia As New AdvertenciaForm
                advertencia.mensaje = "No existe configuración de periodos de nómina para la nave"
                advertencia.ShowDialog()
                btnGuardar.Enabled = False
            End If
        End If
    End Sub

    Public Function validaCampos() As Boolean
        Dim advertencia As New AdvertenciaForm
        Dim idValidacion As Int32 = 0
        validarGeneral = True



        For Each colaborador As Integer In listaColaboradores.Select(Function(c) c.PColaboradorId).Distinct.ToList
            validaCampos = True
            idValidacion = colaborador
            Dim objCol As Entidades.AltaColaboradorIMSS = listaColaboradores.Find(Function(c) c.PColaboradorId = idValidacion)

            If objCol.PTieneCredito = True Then
                If objCol.PNumeroCredito.Length <= 0 Then
                    validaCampos = False
                ElseIf objCol.PNumeroCredito.Length < 10 Then
                    validaCampos = False
                    validaInfonavit = False
                    mensajeInfonavit = "El Número de Crédito debe tener 10 dígitos."
                End If

                If Not IsNumeric(objCol.PValorDescuento) Then
                    validaCampos = False
                    validaInfonavit = False
                    mensajeInfonavit = "Favor de ingresar Valor de Descuento válido."
                End If

                If Not IsNumeric(objCol.PNumeroCredito) Then
                    validaCampos = False
                    validaInfonavit = False
                    mensajeInfonavit = "Favor de ingresar un número de crédito válido."
                End If

                If objCol.PTipoDescuentoId <= 0 Then
                    validaCampos = False
                End If
                If Not objCol.PEntidadCreditoInfonavit Is Nothing Then
                    If objCol.PEntidadCreditoInfonavit.CIRutaarchivoretencion = "" Then
                        mensajeInfonavit = "Favor de cargar el archivo de Retención de Descuentos."
                        validaCampos = False
                        validaInfonavit = False
                    ElseIf objCol.PEntidadCreditoInfonavit.CIRutaarchivoretencion <> "" Then
                        If System.IO.Path.GetExtension(opfArchivoRetencion.FileName).ToUpper <> ".PDF" Then
                            mensajeInfonavit = "El archivo seleccionado no es un PDF."
                            validaCampos = False
                            validaInfonavit = False
                        Else

                        End If
                    End If
                End If

            Else
                If Not objCol.PNumeroCredito Is Nothing Then
                    If objCol.PNumeroCredito.Length > 0 Then
                        mensajeInfonavit = "Si cuenta con número de crédito el dato ""¿Cuenta con crédito INFONAVIT?"" debe estar en SI."
                        validaCampos = False
                        validaInfonavit = False
                    End If
                End If

            End If
            If objCol.PSDI.ToString.Length <= 0 Or objCol.PSDI = 0 Then
                validaCampos = False
            End If

            If objCol.PTipoTrabajadorId <= 0 Then
                validaCampos = False
            End If

            If objCol.PTipoSalarioId <= 0 Then
                validaCampos = False
            End If

            If objCol.PTipoJornadaID <= 0 Then
                validaCampos = False
            End If

            If objCol.PUMF <= 0 Then
                validaCampos = False
            End If

            If objCol.PDepartamentoFiscalId <= 0 Then
                validaCampos = False
            End If

            If objCol.PPuestoFiscalId <= 0 Then
                validaCampos = False
            End If

            If validaCampos = False Then
                validarGeneral = False
                nombresPorValidar = nombresPorValidar + objCol.PNombre + ","
            End If
        Next

        Return validarGeneral
    End Function

    Private Sub CompletarAltaColaboradorIMSSForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cargarDatosIniciales()
        Panel2.Enabled = False
        pnlInfonavil.Enabled = False
        btnPdfInfonavit.Enabled = False
        If editaridColaborador <> 0 Then
            btnGuardar.Enabled = False
        End If

        'obtenerTipoMovimientoSMD()

        If editar Then
            Panel2.Enabled = True
            cmbTipoJornada.Enabled = True
            cmbTipoSalario.Enabled = True
            cmbTipoSalario.Enabled = True
            cmbUmf.Enabled = True
            cmbDeptoFiscal.Enabled = True
            cmbPuestoFiscal.Enabled = True
            dtpFechaAlta.Enabled = True
            rdoInfonavitNo.Enabled = False
            rdoInfonavitSI.Enabled = False
            cmbTipoTrabajador.Enabled = True
            txtValorDescuento.Enabled = True
            cmbTipoDes.Enabled = True
            txtNumeroCredito.Enabled = True
            txtSDI.Enabled = True

            'If rdoInfonavitSI.Checked Then
            pnlInfonavil.Enabled = False
            btnPdfInfonavit.Enabled = False
            btnInfonavit.Enabled = False
            'End If
            btnGuardar.Enabled = True
        End If

        Me.Show()
        'If banderaSDI = False Then
        '    Dim advertencia As New AdvertenciaForm
        '    advertencia.mensaje = "No existe configuración de SDI para el puesto(s) del colaborador(es) "
        '    advertencia.ShowDialog()
        '    btnGuardar.Enabled = False
        'End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        gpbFiltro.Height = 40
        grdColaboradoresImss.Height = 370
        grdColaboradoresImss.Top = 130
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        gpbFiltro.Height = 225
        grdColaboradoresImss.Height = 240
        grdColaboradoresImss.Top = 240
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdColaboradoresImss_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdColaboradoresImss.ClickCell
        If editaridColaborador = 0 And grdColaboradoresImss.ActiveRow.Index >= 0 Then
            cargarDatosColaboradorSeleccionado()
        End If
    End Sub

    Private Sub btnTieneInfonavit_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("http://www.infonavit.org.mx:8070/wpEstadoSolicitudCreditoWeb/servlet/org.infonavit.estadosolicitud.controlador.Consulta")
    End Sub

    Private Sub btnAvisoRetencion_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start("http://portal.infonavit.org.mx/wps/portal/Infonavit/Servicios/Trabajadores/AvisoSuspensionRetencion/!ut/p/b1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOJNnIxMnJwMHQ0sLH0NDDyDPIMcfczCDA1MzIEKIpEVGJi5uBh4OoU6BgYbeBpbmBuSqj_AEqjfKyTAJNTCwsDAwJQ4_QY4gKMBIf3h-lGoSrD4AE0BqhODTQgoAPkBrACPI_088nNT9QtyQ0MjDDI9dR0VFQGpzomY/dl4/d5/L2dBISEvZ0FBIS9nQSEh/")
    End Sub

    Public Sub mostrarCalculoInfonavit()
        Dim objMensajeError As New Tools.ErroresForm
        Dim msjError As String = String.Empty
        Dim objCalcInfonavit As New CalculoInfonavit
        Dim credInfonavit As New Entidades.CreditoInfonavit

        If txtValorDescuento.Text <> "" And txtValorDescuento.Text <> "0" And idPatron <> "0" Then
            If CDbl(txtValorDescuento.Text) > 0 Then
                Dim porcentajeDescuento As Double = CDbl(txtValorDescuento.Text) / 100
                Select Case cmbTipoDes.SelectedValue.ToString
                    Case "0"
                    Case "1" 'PORCENTAJE
                        credInfonavit = objCalcInfonavit.calcularDescuentoPorcentaje(CDbl(txtSDI.Text), porcentajeDescuento, idPatron, dtpFechaAlta.Value)
                    Case "2" 'CUOTAFIJA
                        credInfonavit = objCalcInfonavit.calcularDescuentoCoutaFija(CDbl(txtValorDescuento.Text), idPatron, dtpFechaAlta.Value)
                    Case "3" 'VECES SALARIO MÍNIMO
                        credInfonavit = objCalcInfonavit.calcularDescuentoVecesSM(CDbl(txtValorDescuento.Text), idPatron, dtpFechaAlta.Value)
                End Select

                credInfonavit.CINumerocredito = txtNumeroCredito.Text
                credInfonavit.CIAplicatabladisminucion = rdoDisminucionSI.Checked
                credInfonavit.CITipodescuentoid = cmbTipoDes.SelectedValue
                credInfonavit.CIValordescuento = CDbl(txtValorDescuento.Text)
            End If
        End If

        If objCalcInfonavit.msjError <> "" Then
            objMensajeError.mensaje = objCalcInfonavit.msjError
            objMensajeError.ShowDialog()
        Else
            ''guarda los datos en la entidad de credito infonavit
            If idColaborador <> 0 Then
                Dim item As Integer = listaColaboradores.FindIndex(Function(c) c.PColaboradorId = idColaborador)
                Dim objBu As New Negocios.ColaboradoresContabilidadBU

                credInfonavit.CIColaboradorid = listaColaboradores.Item(item).PColaboradorId
                credInfonavit.CIPatronId = listaColaboradores.Item(item).PPAtronId
                credInfonavit.CIFechamovimiento = listaColaboradores.Item(item).PFechaAlta
                'credInfonavit.CISalarioMinimoDF = SMD
                'credInfonavit.CIMovimientoinfonavitid = tipoMovimiento
                credInfonavit.CIMovimientoinfonavitid = objBu.tipoMovimientoInfonavit(idColaborador, listaColaboradores.Item(item).PPAtronId)
                credInfonavit.CIFecharecepcion = Today
                'If Not credInfonavit.CIAPaterno Is Nothing Then
                listaColaboradores.Item(item).PEntidadCreditoInfonavit = credInfonavit
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CISalarioBimestral = credInfonavit.CISalarioBimestral
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIImporteretencionmensual = credInfonavit.CIImporteretencionmensual
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CISalarioMinimoDF = credInfonavit.CISalarioMinimoDF
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIRetencionMensual = credInfonavit.CIRetencionMensual
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIImporteretencionbimestral = credInfonavit.CIImporteretencionbimestral
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIImporteretenerbimestral = credInfonavit.CIImporteretenerbimestral
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CISeguroVivienda = credInfonavit.CISeguroVivienda
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIRetenciondiaria = credInfonavit.CIRetenciondiaria
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIRetencionsemanalfiscal = credInfonavit.CIRetencionsemanalfiscal
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CISemanasdescontaranual = credInfonavit.CISemanasdescontaranual
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIDescuentosemanal = credInfonavit.CIDescuentosemanal
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIDescuentoanterior = credInfonavit.CIDescuentoanterior
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIDiferencia = credInfonavit.CIDiferencia
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIMovimientodescontado = credInfonavit.CIMovimientodescontado
                'listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIFecharecepcion = credInfonavit.CIFecharecepcion
                'End If




            End If

            lblCantidadDes.Text = credInfonavit.CIDescuentosemanal.ToString("N2")
        End If


    End Sub

    Public Sub guardarSolicitudesColaborador()
        ''verifica ultimos campos actualizados
        Dim ultimoSeleccionado As Int32 = 0
        Dim idGuardar As Int32 = 0
        Dim advertencia As New AdvertenciaForm
        Dim exito As New ExitoForm
        Dim bandera As Boolean = True
        Dim objFTP As New Tools.TransferenciaFTP



        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ultimoSeleccionado = grdColaboradoresImss.ActiveRow.Cells("idColaborador").Value()
        Dim colUltimo As New Entidades.AltaColaboradorIMSS
        If ultimoSeleccionado <> 0 And idColaborador <> 0 Then
            Dim item As Integer = listaColaboradores.FindIndex(Function(c) c.PColaboradorId = idColaborador)
            directorio = rutaAcuses & idColaborador
            listaColaboradores.Item(item).PFechaAlta = dtpFechaAlta.Value.ToShortDateString
            If rdoInfonavitSI.Checked = True Then
                listaColaboradores.Item(item).PTieneCredito = True
            Else
                listaColaboradores.Item(item).PTieneCredito = False
            End If

            listaColaboradores.Item(item).PNumeroCredito = txtNumeroCredito.Text
            listaColaboradores.Item(item).PTipoDescuentoId = cmbTipoDes.SelectedValue

            If rdoDisminucionSI.Checked = True Then
                listaColaboradores.Item(item).PAplicaTabla = True
            Else
                listaColaboradores.Item(item).PAplicaTabla = False
            End If

            listaColaboradores.Item(item).PCantidadDescontar = lblCantidadDes.Text
            listaColaboradores.Item(item).PSDI = txtSDI.Text
            listaColaboradores.Item(item).PTipoTrabajadorId = cmbTipoTrabajador.SelectedValue
            listaColaboradores.Item(item).PTipoSalarioId = cmbTipoSalario.SelectedValue
            listaColaboradores.Item(item).PTipoJornadaID = cmbTipoJornada.SelectedValue
            'listaColaboradores.Item(item).PUMF = txtUMF.Text
            listaColaboradores.Item(item).PUMF = cmbUmf.SelectedValue
            listaColaboradores.Item(item).PDepartamentoFiscalId = cmbDeptoFiscal.SelectedValue
            listaColaboradores.Item(item).PPuestoFiscalId = cmbPuestoFiscal.SelectedValue
            listaColaboradores.Item(item).PValorDescuento = txtValorDescuento.Text
            If txtRutaRetencion.Text <> "" Then
                listaColaboradores.Item(item).PCargoRetencion = True
                listaColaboradores.Item(item).PRutaArchivoRetencion = opfArchivoRetencion.FileName
                listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIRutaarchivoretencion = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(opfArchivoRetencion.FileName)
                listaColaboradores.Item(item).PEntidadCreditoInfonavit.CIFechamovimiento = dtpFechaAlta.Value.ToShortDateString
            End If


        End If

        If validaCampos() Then
            ''valida retencion semanal
            If validaRetencionSemanal() Then
            Else
                advertencia.mensaje = "No se puede solicitar el alta del colaborador(es) " + listaRetencion + ". Cuenta con un abono a INFONAVIT 	que excede su salario semanal bruto"
                advertencia.ShowDialog()
                listaRetencion = ""
            End If

            ''valida salario diario integrado
            If validaSDIMinimo() Then
                Dim mensajeConfirmacion As New ConfirmarForm
                mensajeConfirmacion.mensaje = "¿Está seguro de guardar la(s) solicitud(es)? Posteriormente no podrán realizar cambios"

                If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each colaborador As Integer In listaColaboradores.Select(Function(c) c.PColaboradorId).Distinct.ToList

                        idGuardar = colaborador
                        Dim objCol As Entidades.AltaColaboradorIMSS = listaColaboradores.Find(Function(c) c.PColaboradorId = idGuardar)
                        Dim objBu As New Negocios.ColaboradoresContabilidadBU
                        Dim dtGuardar As New DataTable
                        Dim idAlta As Int32 = 0
                        dtGuardar = objBu.insertaAltaImss(objCol, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        If dtGuardar.Rows.Count > 0 Then
                            If dtGuardar.Rows(0).Item("resul") = "EXITO" Then
                                bandera = True
                                idAlta = dtGuardar.Rows(0).Item("idAlta")
                                If Not objCol.PEntidadCreditoInfonavit Is Nothing Then
                                    If objCol.PTieneCredito = True And objCol.PEntidadCreditoInfonavit.CIDescuentosemanal > 0 Then
                                        ''aqui guarda el alta de infonavit
                                        directorio = rutaAcuses & objCol.PColaboradorId
                                        Dim objBUIn As New Negocios.ColaboradoresContabilidadBU
                                        Dim dtResul As New DataTable
                                        Dim idInfonavit As Int32 = 0
                                        dtResul = objBUIn.altaMovimientoCreditoInfonavit(objCol.PEntidadCreditoInfonavit, directorio, IO.Path.GetFileName(opfArchivoRetencion.FileName))

                                        If dtResul.Rows(0).Item("mensaje") = "EXITO" Then
                                            ''actualizar idalta con el id de infonavit
                                            idInfonavit = dtResul.Rows(0).Item("idInfonavit")
                                            objBUIn = New Negocios.ColaboradoresContabilidadBU
                                            Dim resultado As String = objBUIn.ActualizaInfonavitALtaImss(idInfonavit, idAlta)

                                            If resultado = "EXITO" Then
                                                If subirArchivo(objCol.PRutaArchivoRetencion, objCol.PColaboradorId) Then
                                                    bandera = True
                                                Else

                                                    Dim objMensajeError As New AdvertenciaForm
                                                    objMensajeError.mensaje = "Error subir el archivo de Retención de Descuentos."
                                                    objMensajeError.ShowDialog()
                                                End If
                                            End If


                                        End If
                                    End If
                                Else
                                    Dim rowN As DataRow = dtNombre.NewRow
                                    rowN.Item("nombre") = objCol.PNombre
                                    rowN.Item("idColaborador") = objCol.PColaboradorId
                                    rowN.Item("idAlta") = idAlta
                                    dtNombre.Rows.Add(rowN)
                                End If

                            Else
                                bandera = False
                            End If
                        End If
                    Next

                    If bandera = True Then
                        exito.mensaje = "Se ha creado la solicitud(es) exitosamente"
                        exito.ShowDialog()
                        Me.Close()

                    Else
                        advertencia.mensaje = "Surgió un problema, por favor intentelo nuevamente"
                        advertencia.ShowDialog()
                    End If
                End If

            Else
                advertencia.mensaje = "El SDI no puede ser menor al SDI minimo configurado para la nave (" + salariominimo.ToString("N2") + ") "
                advertencia.ShowDialog()
            End If




        Else
            If validaInfonavit = True Then
                advertencia.mensaje = "Los campos marcados con * son obligatorios. Faltan datos por completar de los siguientes colaboradores " + nombresPorValidar
                advertencia.ShowDialog()
                nombresPorValidar = ""
            Else
                advertencia.mensaje = mensajeInfonavit + " Para el colaborador(es) " + nombresPorValidar
                advertencia.ShowDialog()
                validaInfonavit = True
                mensajeInfonavit = ""
                nombresPorValidar = ""
            End If

        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub


    Public Function validaSDIMinimo() As Boolean
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        salariominimo = 0
        Dim bandera As Boolean = True
        For Each colaborador As Entidades.AltaColaboradorIMSS In listaColaboradores
            salariominimo = objBu.validaSDIMinimo(colaborador.PColaboradorId)

            If CDbl(txtSDI.Text) >= salariominimo Then

            Else
                bandera = False
            End If
        Next

        Return bandera
    End Function

    Public Function validaSDIMinimoEditar(ByVal idColaborador As Int32) As Boolean
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        salariominimo = 0
        Dim bandera As Boolean = True

        salariominimo = objBu.validaSDIMinimo(idColaborador)

        If CDbl(txtSDI.Text) > salariominimo Then

        Else
            bandera = False
        End If


        Return bandera
    End Function

    Public Function validaRetencionSemanal() As Boolean
        Dim idValidacion As Int32 = 0
        validaRetencion = True
        For Each colaborador As Integer In listaColaboradores.Select(Function(c) c.PColaboradorId).Distinct.ToList
            validaRetencionSemanal = True
            idValidacion = colaborador
            Dim objCol As Entidades.AltaColaboradorIMSS = listaColaboradores.Find(Function(c) c.PColaboradorId = idValidacion)

            If objCol.PCantidadDescontar >= (objCol.PSDI * 7) Then
                validaRetencionSemanal = False
                listaRetencion = listaRetencion + objCol.PNombre + ","
                validaRetencion = False
            End If

        Next

        Return validaRetencion
    End Function

    Public Sub editarAltaImss()
        Dim sdi As Double = 0
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtEdicion As New DataTable
        Dim exito As New ExitoForm

        Dim advertencia As New AdvertenciaForm
        If txtSDI.Text.Length = 0 Or txtSDI.Text = "0" Then
            advertencia.mensaje = "Ingrese una cantidad en el SDI"
            advertencia.ShowDialog()
        Else
            ''valida salario minimo
            If validaSDIMinimoEditar(editaridColaborador) Then
                Dim mensajeConfirmacion As New ConfirmarForm
                mensajeConfirmacion.mensaje = "¿Está seguro de guardar la solicitud(es)? Posteriormente no podrán realizar cambios"

                If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'sdi = CDbl(txtSDI.Text)
                    Dim colaboradorImssEditar As New Entidades.AltaColaboradorIMSS
                    colaboradorImssEditar.PFechaAlta = dtpFechaAlta.Value
                    colaboradorImssEditar.PSDI = CDbl(txtSDI.Text)
                    colaboradorImssEditar.PTipoTrabajadorId = cmbTipoTrabajador.SelectedValue
                    colaboradorImssEditar.PTipoSalarioId = cmbTipoSalario.SelectedValue
                    colaboradorImssEditar.PTipoJornadaID = cmbTipoJornada.SelectedValue
                    colaboradorImssEditar.PUMF = cmbUmf.SelectedValue

                    dtEdicion = objBu.editarAltaImss(editaridColaborador, idAlta, colaboradorImssEditar, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

                    If dtEdicion.Rows.Count > 0 Then
                        If dtEdicion.Rows(0).Item("resul") = "EXITO" Then
                            exito.mensaje = "Se realizaron los cambios correctamente"
                            exito.ShowDialog()
                            Me.Close()
                        End If
                    End If
                End If

            Else
                advertencia.mensaje = "El SDI no puede ser menor al SDI minimo configurado para la nave (" + salariominimo.ToString("N2") + ") "
                advertencia.ShowDialog()
            End If



        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If editaridColaborador <> 0 Then
            ''aqui editar
            editarAltaImss()
        Else
            guardarSolicitudesColaborador()
        End If
    End Sub

    Private Sub btnInfonavit_Click(sender As Object, e As EventArgs) Handles btnInfonavit.Click
        System.Diagnostics.Process.Start("http://www.infonavit.org.mx:5052/wpEstadoSolicitudCreditoWeb/servlet/org.infonavit.estadosolicitud.controlador.Consulta")
    End Sub

    Private Sub btnPdfInfonavit_Click(sender As Object, e As EventArgs) Handles btnPdfInfonavit.Click
        opfArchivoRetencion.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        opfArchivoRetencion.Filter = "PDF|*.pdf;"
        opfArchivoRetencion.FilterIndex = 3
        opfArchivoRetencion.ShowDialog()
        If opfArchivoRetencion.FileName <> "" Then
            pnlArchivoCargado.Visible = True
            txtRutaRetencion.Text = IO.Path.GetFileName(opfArchivoRetencion.FileName)
        Else
            pnlArchivoCargado.Visible = False
            txtRutaRetencion.Text = ""
        End If
    End Sub

    Private Sub txtValorDescuento_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtValorDescuento.KeyPress
        Dim arreglo(2) As String

        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            If txtValorDescuento.Text.IndexOf(".") > 0 Then
                arreglo = Split(txtValorDescuento.Text, ".")

                If arreglo(1).Length >= 4 Then
                    e.Handled = True
                Else
                    e.Handled = False
                End If
            Else
                e.Handled = False
            End If
        ElseIf e.KeyChar = "." And txtValorDescuento.Text.IndexOf(".") > 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtValorDescuento_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtValorDescuento.KeyUp
        mostrarCalculoInfonavit()
    End Sub

    Private Sub cmbTipoDes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDes.SelectedIndexChanged
        If cmbTipoDes.SelectedIndex > 0 Then
            mostrarCalculoInfonavit()
        End If

    End Sub

    Private Sub llenarComboTipoDescuentos()
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim dtDescuentos As New DataTable

        dtDescuentos = objBU.obtenerListaTipoDescuentos()
        If Not dtDescuentos Is Nothing Then
            If dtDescuentos.Rows.Count > 0 Then
                cmbTipoDes.DataSource = dtDescuentos
                cmbTipoDes.ValueMember = "Id"
                cmbTipoDes.DisplayMember = "Descuento"
            Else
                cmbTipoDes.DataSource = Nothing
            End If
        Else
            cmbTipoDes.DataSource = Nothing
        End If
    End Sub

    Private Function subirArchivo(ByVal rutaArchivo As String, ByVal idColaborador As Int32) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & idColaborador

            If rutaArchivo <> "" Then
                objFTP.EnviarArchivo(directorio, rutaArchivo)
                rutaArchivo = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(rutaArchivo)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch
            Return False
        End Try
        Return True
    End Function

    'Public Sub obtenerTipoMovimientoSMD()
    '    Dim objBu As New Negocios.ColaboradoresContabilidadBU
    '    Dim dtDatos As New DataTable

    '    dtDatos = objBu.tipoMovimientoSMDInfonavit()

    '    If dtDatos.Rows.Count > 0 Then
    '        tipoMovimiento = dtDatos.Rows(0).Item("idMovimiento")
    '        SMD = dtDatos.Rows(0).Item("smd")
    '    End If
    'End Sub

    Private Sub txtNumeroCredito_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtNumeroCredito.KeyPress
        If Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub rdoInfonavitSI_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInfonavitSI.CheckedChanged
        If rdoInfonavitSI.Checked Then
            pnlInfonavil.Enabled = True
            btnPdfInfonavit.Enabled = True
        Else
            pnlInfonavil.Enabled = False
            btnPdfInfonavit.Enabled = False
            pnlArchivoCargado.Visible = False

            opfArchivoRetencion.FileName = String.Empty
            txtNumeroCredito.Text = String.Empty
            cmbTipoDes.SelectedIndex = 0
            txtValorDescuento.Text = String.Empty
            lblCantidadDes.Text = "0"
        End If
    End Sub

    Public Sub cargarComboDepartamentoFiscal()
        Dim dtDeptoFiscal As New DataTable
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable

        cmbDeptoFiscal.DataSource = Nothing
        If idPatron > 0 Then
            dtDeptoFiscal = objBu.consultaDepartamentosFiscales(idPatron)

            If dtDeptoFiscal.Rows.Count > 0 Then
                cmbDeptoFiscal.DataSource = dtDeptoFiscal
                cmbDeptoFiscal.DisplayMember = "deptoFiscal"
                cmbDeptoFiscal.ValueMember = "idDeptoFiscal"

                If dtDeptoFiscal.Rows.Count = 2 Then
                    cmbDeptoFiscal.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Public Sub cargarComboPuestoFiscal()
        Dim dtPuestos As New DataTable
        Dim objBu As New Negocios.UtileriasBU
        Dim dtSDI As New DataTable

        If idPatron > 0 Then
            dtPuestos = objBu.consultaPuestosFiscales(idPatron)
            cmbPuestoFiscal.DataSource = Nothing
            If dtPuestos.Rows.Count > 0 Then
                cmbPuestoFiscal.DataSource = dtPuestos
                cmbPuestoFiscal.DisplayMember = "Puesto"
                cmbPuestoFiscal.ValueMember = "IdPuesto"

                If dtPuestos.Rows.Count = 2 Then
                    cmbPuestoFiscal.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub cargarComboPuestos()
        Throw New NotImplementedException
    End Sub

End Class