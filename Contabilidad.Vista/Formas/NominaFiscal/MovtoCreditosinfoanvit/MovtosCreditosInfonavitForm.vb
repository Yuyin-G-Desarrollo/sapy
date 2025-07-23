Imports System.Windows.Forms
Imports Framework.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.IO
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports System.Net

Public Class MovtosCreditosInfonavitForm
    Dim perfilContabilidad As Boolean = False
    Dim directorio As String = String.Empty
    Dim sPDF As String = String.Empty

    Private pPatronId As Integer
    Public Property prPatronId() As Integer
        Get
            Return pPatronId
        End Get
        Set(ByVal value As Integer)
            pPatronId = value
        End Set
    End Property

    Private pEstatusId As Integer
    Public Property prEstatusId() As Integer
        Get
            Return pEstatusId
        End Get
        Set(ByVal value As Integer)
            pEstatusId = value
        End Set
    End Property

    Private pNaveId As Integer
    Public Property prNaveId() As Integer
        Get
            Return pNaveId
        End Get
        Set(ByVal value As Integer)
            pNaveId = value
        End Set
    End Property

    Private Sub MovtosCreditosInfonavitForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized

        configuracionPerfil()
        configuracionPermisosBotones()
        llenarComboNave()
        llenarComboEstatus()

        If pNaveId <> 0 And cmbNave.Items.Count > 0 Then
            cmbNave.SelectedValue = pNaveId
            If pPatronId <> 0 And cmbEmpresa.Items.Count > 0 Then
                cmbEmpresa.SelectedValue = pPatronId
                If pEstatusId <> 0 Then
                    cmbEstatus.SelectedValue = pEstatusId
                End If
                cargarListado()
            End If
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Height = 43
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Height = 114
    End Sub

    Private Sub configuracionPermisosBotones()
        If perfilContabilidad Then
            If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "ALTA_MOVTOCI") Then
                pnlAltas.Visible = True
            Else
                pnlAltas.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "EDITAR_MOVTOCI") Then
                pnlEditar.Visible = True
            Else
                pnlEditar.Visible = False
            End If

            'If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "APLICAR_MOVTOCI") Then
            '    pnlAplicar.Visible = True
            'Else
            '    pnlAplicar.Visible = False
            'End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "GENERARTXT_MOVTOCI") Then
                pnlGenerarTxt.Visible = True
            Else
                pnlGenerarTxt.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "CONSULTAR_MOVTOCI") Then
                pnlVer.Visible = True
            Else
                pnlVer.Visible = False
            End If

            'If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "IMPRIMIR_MOVTOCI") Then
            '    pnlReporte.Visible = True
            'Else
            '    pnlReporte.Visible = False
            'End If
        Else
            If PermisosUsuarioBU.ConsultarPermiso("MOVTOSCREDINFONAVITN", "ALTA_MOVTOCI") Then
                pnlAltas.Visible = True
            Else
                pnlAltas.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("MOVTOSCREDINFONAVITN", "EDITAR_MOVTOCI") Then
                pnlEditar.Visible = True
            Else
                pnlEditar.Visible = False
            End If

            If PermisosUsuarioBU.ConsultarPermiso("MOVTOSCREDINFONAVITN", "CONSULTAR_MOVTOCI") Then
                pnlVer.Visible = True
            Else
                pnlVer.Visible = False
            End If

            pnlGenerarTxt.Visible = False
        End If
    End Sub

    Private Sub llenarComboNave()
        Tools.Controles.ComboNavesSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        cmbEmpresa.DataSource = Nothing
        If cmbNave.SelectedIndex > 0 Then
            Dim objBu As New Contabilidad.Negocios.UtileriasBU
            Dim dtEmpresa As New DataTable

            dtEmpresa = objBu.consultaPatronPorNave(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbNave.SelectedValue)
            If dtEmpresa.Rows.Count > 0 Then
                If dtEmpresa.Rows.Count = 1 Then
                    Dim dtRow As DataRow = dtEmpresa.NewRow
                    dtRow("ID") = 0
                    dtRow("PATRON") = ""
                    dtEmpresa.Rows.InsertAt(dtRow, 0)
                End If

                cmbEmpresa.DataSource = dtEmpresa
                cmbEmpresa.DisplayMember = "Patron"
                cmbEmpresa.ValueMember = "ID"

                If dtEmpresa.Rows.Count = 2 Then
                    cmbEmpresa.SelectedIndex = 1
                End If
            End If
        End If
    End Sub

    Private Sub llenarComboEstatus()
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim dtEstatus As New DataTable

        dtEstatus = objBU.obtenerEstatusCreditoInfonavit
        If Not dtEstatus Is Nothing Then
            If dtEstatus.Rows.Count > 0 Then
                cmbEstatus.DataSource = dtEstatus
                cmbEstatus.ValueMember = "esta_estatusid"
                cmbEstatus.DisplayMember = "esta_nombre"
                cmbEstatus.SelectedValue = 97
            Else
                cmbEstatus.DataSource = Nothing
            End If
        Else
            cmbEstatus.DataSource = Nothing
        End If
    End Sub

    Private Sub configuracionPerfil()
        Try
            Dim objBU As New Negocios.UtileriasBU
            perfilContabilidad = objBU.validarPerfilContabilidad()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged
        If chkPeriodo.Checked Then
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True
        Else
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click, lblMostrar.Click
        cargarListado()
    End Sub

    Private Sub cargarListado()
        Dim objMensajeError As New Tools.ErroresForm
        Try
            If validarFiltros() Then
                Dim objBu As New Negocios.CreditoInfonavitBU
                Dim dtListado As New DataTable

                Dim patronId As Integer = cmbEmpresa.SelectedValue
                Dim estatusId As Integer = cmbEstatus.SelectedValue
                Dim naveId As Integer = cmbNave.SelectedValue
                Dim nombre As String = txtNombre.Text
                Dim periodo As Boolean = chkPeriodo.Checked
                Dim fInicio As String = dtpFechaInicio.Value.ToShortDateString
                Dim fFin As String = dtpFechaFin.Value.ToShortDateString

                dtListado = objBu.consultarListaMovimientosCreditoInfonavit(patronId, estatusId, naveId, nombre, periodo, fInicio, fFin)
                If dtListado.Rows.Count > 0 Then
                    grdListadoMovimientos.DataSource = dtListado
                    disenioGrid()
                Else
                    grdListadoMovimientos.DataSource = Nothing
                End If
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al cargar listado de movimientos de créditos de Infonavit."
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function validarFiltros() As Boolean
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        If cmbEmpresa.Items.Count > 1 And cmbEmpresa.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar una Empresa."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If cmbEstatus.Items.Count > 1 And cmbEstatus.SelectedIndex = 0 Then
            objMensajeAdv.mensaje = "Favor de seleccionar un Estatus."
            objMensajeAdv.ShowDialog()
            Return False
            Exit Function
        End If

        If chkPeriodo.Checked Then
            Dim entFechaInicio As Integer = 0
            Dim entFechaFin As Integer = 0
            entFechaInicio = CInt(dtpFechaInicio.Value.ToString("yyyyMMdd"))
            entFechaFin = CInt(dtpFechaFin.Value.ToString("yyyyMMdd"))

            If entFechaFin < entFechaInicio Then
                objMensajeAdv.mensaje = "La fecha inicial no puede ser mayor a la fecha final del filtro por periodo."
                objMensajeAdv.ShowDialog()
                Return False
                Exit Function
            End If
        End If

        Return True
    End Function

    Public Sub disenioGrid()
        With grdListadoMovimientos.DisplayLayout.Bands(0)
            .Columns("ID").Hidden = True
            .Columns("ColaboradorId").Hidden = True
            .Columns("Color").Hidden = True
            .Columns("UsuarioCreoId").Hidden = True

            .Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("A. Paterno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("A. Materno").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nombre(s)").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NSS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Fecha Movimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Movimiento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Núm. Crédito").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tipo Descuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Descuento").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("Selección").Header.VisiblePosition = 0
            .Columns("Selección").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Fecha Movimiento").Format = "dd/MM/yyyy"
            .Columns("Descuento").Format = "$##,##0.00"

            .Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Descuento").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            grdListadoMovimientos.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            '.Columns("Selección").Width = 50

            .Columns("#").CharacterCasing = CharacterCasing.Upper
            .Columns("A. Paterno").CharacterCasing = CharacterCasing.Upper
            .Columns("A. Materno").CharacterCasing = CharacterCasing.Upper
            .Columns("Nombre(s)").CharacterCasing = CharacterCasing.Upper
            .Columns("Nave").CharacterCasing = CharacterCasing.Upper
            .Columns("NSS").CharacterCasing = CharacterCasing.Upper
            .Columns("Fecha Movimiento").CharacterCasing = CharacterCasing.Upper
            .Columns("Movimiento").CharacterCasing = CharacterCasing.Upper
            .Columns("Núm. Crédito").CharacterCasing = CharacterCasing.Upper
            .Columns("Tipo Descuento").CharacterCasing = CharacterCasing.Upper
            .Columns("Descuento").CharacterCasing = CharacterCasing.Upper
        End With

        grdListadoMovimientos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListadoMovimientos.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdListadoMovimientos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdListadoMovimientos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        formatoColorFila()
    End Sub

    Private Sub formatoColorFila()
        Try
            For Each row As UltraGridRow In grdListadoMovimientos.Rows
                If row.Cells("Color").Value = "RED" Then
                    row.Appearance.ForeColor = Color.Red
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click, lblLimpiar.Click
        limpiarFiltros()
    End Sub

    Private Sub limpiarFiltros()
        cmbNave.SelectedValue = 0
        cmbEmpresa.SelectedIndex = 0
        txtNombre.Text = String.Empty
        dtpFechaInicio.Value = Now
        dtpFechaFin.Value = Now
        chkPeriodo.Checked = False
        grdListadoMovimientos.DataSource = Nothing
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click, lblAltas.Click
        abrirPantallaAltas(False, 0, False)
    End Sub

    Private Sub abrirPantallaAltas(ByVal edicion As Boolean, ByVal creditoId As Integer, ByVal consulta As Boolean)
        If PermisosUsuarioBU.ConsultarPermiso("LIST_MOVCREDINF", "VERCALCULO_MOVTOCI", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid) And perfilContabilidad Then
            abrirPantallaAltasContabilidad(edicion, creditoId, consulta)
        Else
            abrirPantallaAltasNaves(edicion, creditoId, consulta)
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub abrirPantallaAltasNaves(ByVal edicion As Boolean, ByVal creditoId As Integer, ByVal consulta As Boolean)
        Dim objForm As New AltaMovCreditoInfonavitNaveForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaMovCreditoInfonavitNaveForm
            formaAltas.editar = edicion
            formaAltas.consulta = consulta
            formaAltas.lblCreditoId.Text = creditoId
            formaAltas.ShowDialog()

            If formaAltas.guardado Then
                cargarListado()
            End If
        End If
    End Sub


    Private Sub abrirPantallaAltasContabilidad(ByVal edicion As Boolean, ByVal creditoId As Integer, ByVal consulta As Boolean)
        Dim objForm As New AltaMovCreditoInfonavitContForm
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaMovCreditoInfonavitContForm
            formaAltas.editar = edicion
            formaAltas.consulta = consulta
            formaAltas.lblCreditoId.Text = creditoId
            formaAltas.ShowDialog()

            If formaAltas.guardado Then
                cargarListado()
            End If
        End If
    End Sub

    Private Function validarEstatus(ByVal opcEstatus As Int16, ByVal idsCredito() As Integer) As Boolean
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim resultado As String = String.Empty

        For item As Integer = 0 To idsCredito.Length - 1
            resultado = objBU.validarEstatus(idsCredito(item), opcEstatus)
            If resultado <> "CORRECTO" Then
                Return False
                Exit Function
            End If
        Next

        Return True
    End Function

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click, lblEditar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim contSeleccionadas As Integer = 0
        Dim creditoId As Integer = 0
        Dim usuarioCreoId As Integer = 0

        For Each row As UltraGridRow In grdListadoMovimientos.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                creditoId = row.Cells("ID").Value
                usuarioCreoId = row.Cells("usuarioCreoId").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
            'ElseIf usuarioCreoId <> Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid Then
            '    objMensajeAdv.mensaje = "Solo el usuario que creo el movimiento puede editarlo."
            '    objMensajeAdv.ShowDialog()
        Else
            Dim idsCredito(0) As Integer
            idsCredito(0) = creditoId
            If validarEstatus(3, idsCredito) Then
                abrirPantallaAltas(True, creditoId, False)
            Else
                objMensajeAdv.mensaje = "El movimiento de Crédito Infonavit debe de estar en estatus CAPTURADO o APLICADO para Editarla. Favor de esperar a que Contabilidad termine el proceso."
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click, lblVer.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim contSeleccionadas As Integer = 0
        Dim creditoId As Integer = 0
        Dim usuarioCreoId As Integer = 0

        For Each row As UltraGridRow In grdListadoMovimientos.Rows
            If row.Cells("Selección").Value Then
                contSeleccionadas += 1
                creditoId = row.Cells("ID").Value
                usuarioCreoId = row.Cells("usuarioCreoId").Value
            End If
        Next

        If contSeleccionadas = 0 Then
            objMensajeAdv.mensaje = "Favor de selecionar un registro."
            objMensajeAdv.ShowDialog()
        ElseIf contSeleccionadas > 1 Then
            objMensajeAdv.mensaje = "Favor de selecionar solo un registro."
            objMensajeAdv.ShowDialog()
        Else
            abrirPantallaAltas(True, creditoId, True)
        End If
    End Sub

    Private Sub btnGenerarTxt_Click(sender As Object, e As EventArgs) Handles btnGenerarTxt.Click, lblGenerarTxt.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim contSeleccionadas As Integer = 0
        Dim idsCreditos() As Integer
        Dim creditoIds As String = String.Empty

        Try
            For Each row As UltraGridRow In grdListadoMovimientos.Rows
                If row.Cells("Selección").Value Then
                    'ReDim Preserve idsCreditos(contSeleccionadas)
                    'idsCreditos(contSeleccionadas) = row.Cells("ID").Value
                    creditoIds &= row.Cells("ID").Value & ","
                    contSeleccionadas += 1
                End If
            Next

            If contSeleccionadas > 0 Then
                'If validarEstatus(2, idsCreditos) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de aplicar los " & contSeleccionadas & " movimientos seleccionados? Esta acción no se podrá revertir."

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.CreditoInfonavitBU
                    Dim dtInformacion As New DataTable
                    Dim fecha As String = Date.Now.ToString("ddMMyyyHmm")
                    Dim resultado As String = String.Empty
                    Dim contAplicadas As Integer = 0
                    Dim aplicaDif As Boolean = False

                    creditoIds = creditoIds.Substring(0, creditoIds.Length - 1)
                    dtInformacion = objBU.consultarInformacionSUA(creditoIds)
                    If Not dtInformacion Is Nothing Then
                        If dtInformacion.Rows.Count > 0 Then
                            Dim pathArchivo As String = String.Empty
                            pathArchivo = generarTXT(dtInformacion, fecha)
                            If pathArchivo <> "" Then
                                pathArchivo = Path.GetFileName(pathArchivo)

                                Try
                                    ReDim idsCreditos(dtInformacion.Rows.Count - 1)
                                    For i As Integer = 0 To dtInformacion.Rows.Count - 1
                                        idsCreditos(i) = CInt(dtInformacion.Rows(i)("CreditoId").ToString())
                                    Next

                                    For item As Integer = 0 To idsCreditos.Length - 1
                                        Dim credinfonavit As New Entidades.CreditoInfonavit
                                        Dim montoMinimo As Double = 0
                                        Dim cartaGenerada As Boolean = True
                                        Try
                                            credinfonavit = objBU.consultarMovimientoCreditoInfonavit(idsCreditos(item))

                                            If Not credinfonavit Is Nothing Then
                                                montoMinimo = objBU.obtenerMontoMinimo(credinfonavit.CIPatronId)
                                                If credinfonavit.CIDiferencia > montoMinimo Then
                                                    aplicaDif = True
                                                    If generarCartaDescuento(credinfonavit) Then
                                                        'enviar_correo(credinfonavit)
                                                    Else
                                                        cartaGenerada = False
                                                    End If
                                                End If

                                                If cartaGenerada Then
                                                    resultado = objBU.aplicarMovimientoCreditoInfonavit(idsCreditos(item), directorio, IO.Path.GetFileName(sPDF))
                                                    If resultado = "EXITO" Then
                                                        enviar_correo(credinfonavit, aplicaDif)
                                                        contAplicadas += 1
                                                    End If
                                                Else
                                                    resultado = "ERROR"
                                                End If
                                            Else
                                                resultado = "ERROR"
                                            End If
                                        Catch ex As Exception
                                            resultado = "ERROR"
                                        End Try
                                    Next
                                Catch ex As Exception
                                    objMensajeError.mensaje = "Error al aplicar movimientos."
                                    objMensajeError.ShowDialog()
                                End Try

                                If contSeleccionadas = contAplicadas Then
                                    objMensajeExito.mensaje = "Movimientos de Crédito Infonavit aplicados correctamente." '"El archivo se generó correctamente con nombre: " & pathArchivo & "."
                                    objMensajeExito.ShowDialog()
                                    cargarListado()
                                ElseIf contAplicadas = 0 Then
                                    objMensajeError.mensaje = "Error no se pudieron aplicar los movimientos seleccionados."
                                    objMensajeError.ShowDialog()
                                ElseIf contSeleccionadas > contAplicadas Then
                                    objMensajeError.mensaje = "Algunos movimientos seleccionados no se pudieron aplicar, el listado se actualizará favor de intentarlo nuevamente."
                                    objMensajeError.ShowDialog()
                                    cargarListado()
                                End If
                            Else
                                objMensajeError.mensaje = "No se pudo generar el TXT de los movimientos seleccionados, favor de revisar los datos."
                                objMensajeError.ShowDialog()
                            End If
                        Else
                            objMensajeAdv.mensaje = "La consulta de la información para el archivo no arrojó ningún resultado, favor de revisar los datos."
                            objMensajeAdv.ShowDialog()
                        End If
                    Else
                        objMensajeAdv.mensaje = "La consulta de la información para el archivo no arrojó ningún resultado, favor de revisar los datos."
                        objMensajeAdv.ShowDialog()
                    End If
                    'Else
                    '    objMensajeAdv.mensaje = "Los movimientos de Crédito Infonavit deben de estar en estatus EN PROCESO o APLICADO para Aplicarlos."
                    '    objMensajeAdv.ShowDialog()
                    'End If
                End If
            Else
                objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
                objMensajeAdv.ShowDialog()
            End If
        Catch ex As Exception
            objMensajeError.mensaje = "Error al Generar los TXT's"
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Function generarTXT(ByVal dtInformacion As DataTable, ByVal fecha As String) As String
        Dim archivoTXT As String = String.Empty
        Dim informacion As String = String.Empty

        archivoTXT = dtInformacion.Rows(0)("rutaDescarga").ToString & "movtoInfonavitSUA_" & dtInformacion.Rows(0)("patr_nopatronal").ToString & "_" & fecha & ".txt"
        If Not existeArchivo(IO.Path.GetDirectoryName(archivoTXT)) Then
            crearCarpeta(IO.Path.GetDirectoryName(archivoTXT))
        End If

        For Each item As DataRow In dtInformacion.Rows
            informacion &= item("patr_nopatronal").ToString
            informacion &= item("cono_nss").ToString
            informacion &= item("crInf_numerocredito").ToString
            informacion &= item("catMov_clave").ToString
            informacion &= item("fechaMovimiento").ToString
            informacion &= item("catDes_clave").ToString
            informacion &= item("valordescuento").ToString
            informacion &= item("aplicaDisminucion").ToString
            informacion &= vbCrLf
        Next

        File.WriteAllText(archivoTXT, informacion.ToUpper)
        If existeArchivo(archivoTXT) Then
            Return archivoTXT
        Else
            Return ""
        End If
    End Function

    Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click, lblAplicar.Click
        Dim objMensajeAdv As New Tools.AdvertenciaForm
        Dim objMensajeError As New Tools.ErroresForm
        Dim objMensajeExito As New Tools.ExitoForm
        Dim idsCreditos() As Integer
        Dim contSeleccionadas As Integer = 0

        For Each row As UltraGridRow In grdListadoMovimientos.Rows
            If row.Cells("Selección").Value Then
                ReDim Preserve idsCreditos(contSeleccionadas)
                idsCreditos(contSeleccionadas) = row.Cells("ID").Value
                contSeleccionadas += 1
            End If
        Next

        If contSeleccionadas > 0 Then
            If validarEstatus(2, idsCreditos) Then
                Dim objMensajeConf As New Tools.ConfirmarForm
                objMensajeConf.mensaje = "¿Está seguro de aplicar los " & contSeleccionadas & " movimientos seleccionados? Posteriormente no podrán realizarse cambios."

                If objMensajeConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim objBU As New Negocios.CreditoInfonavitBU
                    Dim resultado As String = String.Empty
                    Dim contAplicadas As Integer = 0

                    Try
                        For item As Integer = 0 To idsCreditos.Length - 1
                            Dim credinfonavit As New Entidades.CreditoInfonavit
                            Try
                                credinfonavit = objBU.consultarMovimientoCreditoInfonavit(idsCreditos(item))

                                If credinfonavit.CICreditoInfonavitId <> 0 Then
                                    If generarCartaDescuento(credinfonavit) Then
                                        enviar_correo(credinfonavit, True)
                                        resultado = objBU.aplicarMovimientoCreditoInfonavit(idsCreditos(item), directorio, IO.Path.GetFileName(sPDF))
                                        'resultado = "EXITO"
                                        If resultado = "EXITO" Then
                                            contAplicadas += 1
                                        End If
                                    Else
                                        resultado = "ERROR"
                                    End If
                                Else
                                    resultado = "ERROR"
                                End If
                            Catch ex As Exception
                                resultado = "ERROR"
                            End Try
                        Next

                        If contSeleccionadas = contAplicadas Then
                            objMensajeExito.mensaje = "Movimientos de Crédito Infonavit aplicados correctamente."
                            objMensajeExito.ShowDialog()
                            cargarListado()
                        ElseIf contAplicadas = 0 Then
                            objMensajeError.mensaje = "Error no se pudieron aplicar los movimientos seleccionados."
                            objMensajeError.ShowDialog()
                        ElseIf contSeleccionadas > contAplicadas Then
                            objMensajeError.mensaje = "Algunos movimientos seleccionados no se pudieron aplicar, el listado se actualizará favor de intentarlo nuevamente."
                            objMensajeError.ShowDialog()
                            cargarListado()
                        End If
                    Catch ex As Exception
                        objMensajeError.mensaje = "Error al aplicar movimientos."
                        objMensajeError.ShowDialog()
                    End Try
                End If
            Else
                objMensajeAdv.mensaje = "Los movimientos de Crédito Infonavit deben de estar en estatus EN PROCESO o APLICADO para Aplicarlos."
                objMensajeAdv.ShowDialog()
            End If
        Else
            objMensajeAdv.mensaje = "Favor de selecionar al menos un registro."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Function generarCartaDescuento(ByVal credInfonavit As Entidades.CreditoInfonavit) As Boolean
        If credInfonavit.CIMovimientoinfonavitid <> 2 Then
            Try
                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                Dim reporte As New StiReport
                Dim pdfSettings = New StiPdfExportSettings()
                EntidadReporte = objReporte.LeerReporteporClave("CARTA_DESC_INFONAVIT")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\" & EntidadReporte.Pnombre & ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim descuentoMensual As String = String.Empty
                Dim descuentoBimestral As String = String.Empty


                sPDF = rutaTmp & "CARTA_DESC_INFONAVIT" & credInfonavit.CIColaboradorid & "_" & Date.Now.ToString("ddMMyyyHmm") & ".pdf"
                If Not existeCarpeta(rutaTmp) Then
                    crearCarpeta(rutaTmp)
                End If

                reporte.Load(archivo)
                reporte.Compile()

                Select Case credInfonavit.CITipoDescuentoStr
                    Case "PORCENTAJE"
                        descuentoMensual = credInfonavit.CISalarioBase.ToString("C2") & " (salario base) * " & diasBimestre & " (días del bimestre) = " & credInfonavit.CISalarioBimestral.ToString("C2") & " * " & credInfonavit.CIValordescuento.ToString("N4") & " porcentaje = " & credInfonavit.CIImporteretencionmensual.ToString("C2") & " (bimestral)"
                        descuentoBimestral = "Descuento bimestral de " & credInfonavit.CIImporteretenerbimestral.ToString("C2") & " + " & credInfonavit.CISeguroVivienda.ToString("C2") & " Seguro para vivienda = " & credInfonavit.CIImporteretenerbimestral.ToString("C2")
                    Case "CUOTA FIJA"
                        descuentoMensual = credInfonavit.CIValordescuento.ToString("C2") & " (mensual)"
                        descuentoBimestral = CDbl(credInfonavit.CIValordescuento * 2).ToString("C2") & " (bimestral)"
                    Case "VECES DE SM"
                        descuentoMensual = credInfonavit.CISalarioMinimoDF.ToString("C2") & " (salario mínimo del DF) * " & credInfonavit.CIValordescuento.ToString("N4") & " veces = " & credInfonavit.CIRetencionMensual.ToString("N2") & " (mensual)"
                        descuentoBimestral = "Descuento bimestral de " & credInfonavit.CIImporteretencionbimestral.ToString("C2") & " + " & credInfonavit.CISeguroVivienda.ToString("C2") & " Seguro para vivienda = " & credInfonavit.CIImporteretenerbimestral.ToString("C2")
                End Select

                Dim credito = New DataTable("dtCredito")
                With credito
                    .Columns.Add("Nombre")
                    .Columns.Add("NumCredito")
                    .Columns.Add("TipoDescuento")
                    .Columns.Add("CalculoMensual")
                    .Columns.Add("CalculoBimestral")
                    .Columns.Add("DescuentoSemanal")
                End With

                credito.Rows.Add( _
                    credInfonavit.CIColaborador, _
                    credInfonavit.CINumerocredito, _
                    credInfonavit.CITipoDescuentoStr, _
                    descuentoMensual, _
                    descuentoBimestral, _
                    credInfonavit.CIDescuentosemanal _
                )

                reporte("Logo") = credInfonavit.CILogoNave
                reporte.RegData(credito)
                'reporte.Show()
                reporte.Render()
                reporte.ExportDocument(StiExportFormat.Pdf, sPDF, pdfSettings)
                reporte.Dispose()

                If subirArchivo(sPDF, credInfonavit.CIColaboradorid) Then
                    eliminaArchivo(sPDF)
                    Return True
                Else
                    eliminaArchivo(sPDF)
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        Else
            Return True
        End If
    End Function

    Private Function subirArchivo(ByVal ruta As String, ByVal colaboradorId As Integer) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & colaboradorId

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorio, ruta)
                rutaArchivo = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(ruta)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    directorio = String.Empty
                    Return False
                End If
            Else
                directorio = String.Empty
                Return False
            End If
        Catch
            directorio = String.Empty
            Return False
        End Try
    End Function

    Private Sub enviar_correo(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal aplicaDif As Boolean)
        Dim enviosCorreoBU As New Framework.Negocios.EnviosCorreoBU
        Dim objBU As New Negocios.CreditoInfonavitBU
        Dim dtDatosCorreo As New DataTable
        Dim destinatarios As String = String.Empty
        Dim correoEnvia As String = String.Empty
        Dim mensaje As String = String.Empty
        Dim asunto As String = String.Empty
        Dim correo As New Tools.Correo

        dtDatosCorreo = objBU.consultaDatosCorreo(credInfonavit.CICreditoInfonavitId)
        If Not dtDatosCorreo Is Nothing Then
            If dtDatosCorreo.Rows().Count > 0 Then
                If dtDatosCorreo.Rows(0)("destinatarios").ToString <> "" Then
                    mensaje = cuerpoCorreo(credInfonavit, aplicaDif)
                    asunto = "Confirmación de Movimiento de crédito Infonavit de " & credInfonavit.CIColaborador
                    destinatarios = dtDatosCorreo.Rows(0)("destinatarios").ToString
                    correoEnvia = dtDatosCorreo.Rows(0)("correoEnvia").ToString

                    correo.EnviarCorreoHtml(destinatarios, correoEnvia, asunto, mensaje)
                End If
            End If
        End If
    End Sub

    Private Function cuerpoCorreo(ByVal credInfonavit As Entidades.CreditoInfonavit, ByVal aplicaDif As Boolean) As String
        Dim mensaje As String = String.Empty
        Dim objMensajeAdv As New Tools.AdvertenciaForm

        mensaje = "<html>"
        mensaje &= "<head>"
        mensaje &= "<style type ='text/css'>" &
                "body {display:block; margin:8px; background:#FFFFFF;}" &
                "#header {position:fixed; height:62px; top:0; left:0; right:0; color:#003366; font-family:Arial, Helvetica, sans-serif; font-size:18px; font-weight: bold;}" &
                "#leftcolumn {float:left; position:fixed; width:2%; margin:1%; padding-top:3%; top:0; left:0; right:0;}" &
                "#content {width:90%; position:fixed; margin:1% 5%; padding-top:3%; padding-bottom:1%;}" &
                "#rightcolumn {float:right; width:5%; margin:1%; padding-top:3%;}" &
                "#footer {position:fixed; width:100%; heigt:5%; bottom:0; margin:0; padding:0; color:#FFFFFF;}" &
                "table.tableizer-table {font-family:Arial, Helvetica, sans-serif; font-size:9px;} " &
                ".tableizer-table td {padding:4px; margin:0px; border:1px solid #FFFFFF;	border-color: #FFFFFF; border:1px solid #CCCCCC; width:200px;}" &
                ".tableizer-table tr {padding: 4px; margin:0; color:#003366; font-weight:bold; background-color:#transparent; opacity:1;}" &
                ".tableizer-table th {background-color: #003366; color:#FFFFFF; font-weight:bold; height:30px; font-size:10px;}" &
                "A:link {text-decoration:none; color:#FFFFFF;}" &
                "A:visited {text-decoration:none; color:#FFFFFF;}" &
                "A:active {text-decoration:none; color:#FFFFFF;}" &
                "A:hover {text-decoration:none;color:#006699;} "
        mensaje &= "</style>"
        mensaje &= "</head>"
        mensaje &= "<body>"
        mensaje &= "<div id='wrapper'>" &
                "<div id='header'>" &
                "<img src='http://grupoyuyin.com.mx/images/SAY170.jpg' style='vertical-align:middle' height='57' widht='125'>Movimiento de Crédito Infonavit" &
                "</div>" &
                "<div id='leftcolumn'></div>" &
                "<div id='rightcolumn'></div>"
        mensaje &= "<div id='content'>"

        If credInfonavit.CIMovimientoinfonavitid <> 2 Then
            If aplicaDif Then
                mensaje &= "<p>Se ha confirmado el movimiento de crédito Infonavit. Se aplicarán los siguientes descuentos a partir de la siguiente elaboración de nómina:</p>"
            Else
                mensaje &= "<p>El trabajador sufrió una modificación de descuento. Se aplicarán los siguientes descuentos a partir de la siguiente elaboración de nómina:</p>"
            End If
        Else
            mensaje &= "<p>Se ha confirmado el movimiento de crédito Infonavit.</p>"
        End If

        mensaje &= "<table id='tblInformacion' class='tableizer-table'>" &
                "<thead>" &
                "<tr class='tableizer-firstrow'>" &
                "<th>NSS</th>" &
                "<th>A PATERNO</th>" &
                "<th>A MATERNO</th>" &
                "<th>NOMBRE</th>" &
                "<th>FECHA<br />MOVIMIENTO</th>" &
                "<th>MOVIMIENTO</th>" &
                "<th>NÚM<br />CRÉDITO</th>" &
                "<th>TIPO<br />DESCUENTO</th>" &
                "<th>DESCUENTO<br />INFONAVIT</th>"
        If Not aplicaDif Then
            mensaje &= "<th>DESCUENTO<br />ANTERIOR</th>" &
                    "<th>DIFERENCIA</th>"
        End If
        mensaje &= "</tr>" &
                "</thead>"
        mensaje &= "<tbody>" &
                "<tr>" &
                "<td>" & credInfonavit.CINss & "</td>" &
                "<td>" & credInfonavit.CIAPaterno & "</td>" &
                "<td>" & credInfonavit.CIAMaterno & "</td>" &
                "<td>" & credInfonavit.CINombre & "</td>" &
                "<td>" & CDate(credInfonavit.CIFechamovimiento).ToString("dd/MM/yyyy") & "</td>" &
                "<td>" & credInfonavit.CIMovimientoinfonavitStr & "</td>" &
                "<td>" & credInfonavit.CINumerocredito & "</td>" &
                "<td>" & credInfonavit.CITipoDescuentoStr & "</td>" &
                "<td style='text-align:right;'>" & Math.Round(credInfonavit.CIDescuentosemanal).ToString("C2") & "</td>"
        If Not aplicaDif Then
            mensaje &= "<td style='text-align:right;'>" & Math.Round(credInfonavit.CIDescuentoanterior).ToString("C2") & "</td>" &
                    "<td style='text-align:right;'>" & Math.Round(credInfonavit.CIDiferencia).ToString("C2") & "</td>"
        End If
        mensaje &= "</tr>"
        mensaje &= "</tbody>"
        mensaje &= "</table>"

        If credInfonavit.CIMovimientoinfonavitid <> 2 Then
            If aplicaDif Then
                mensaje &= "<p>Para descargar la carta de descuento vaya a la ficha del colaborador, en su expediente encontrará disponible el archivo correspondiente.</p>"
            Else
                mensaje &= "<p>Para diferencias menores de $10.00 no se genera carta de descuento, el aviso de retención de descuento lo encontrará en el expediente del trabajador.</p>"
            End If
        End If

        mensaje &= "</div>"
        mensaje &= "<div id='footer'></div>"
        mensaje &= "</div>"
        mensaje &= "</body>"
        mensaje &= "</html>"

        Return mensaje
    End Function

    Private Sub btnbtnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click, lblReporte.Click
        Dim objForm As New ReporteMvoNoDescontadosForm
        If Not CheckForm(objForm) Then
            objForm.ShowDialog()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class