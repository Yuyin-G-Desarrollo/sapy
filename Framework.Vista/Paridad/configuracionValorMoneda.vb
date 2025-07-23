Imports Infragistics.Win.UltraWinGrid
Imports <xmlns:bm='http://www.banxico.org.mx/structure/key_families/dgie/sie/series/compact'>
Imports Infragistics.Win


Public Class configuracionValorMoneda
    Dim moduloID As Integer = 238
    Public moduloID2 As Integer
    Private WSActivo As Integer
    'Para mandar llamar el webService
    Dim objWs As New Framework.WebServices.mx.org.banxico.www.DgieWS
    Dim dbTC As Double
    Dim strTipoCambio As String
    Dim AltaModulo_Paridad As Boolean = True ''TRUE PARA PARIDAD, FALSE PARA MODULO

    Private Sub configuracionValorMoneda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Location = New Point(0, 0)

            Dim objadvertencia As New AdvertenciaForm
            objadvertencia.StartPosition = FormStartPosition.CenterScreen
            objadvertencia.mensaje = "Conectando con el Banco de México para recuperar paridad."
            objadvertencia.ShowDialog()

            'Revisamos sí hay conexión al WebService
            strTipoCambio = objWs.tiposDeCambioBanxico.ToString
            Dim doc As XElement = XElement.Parse(strTipoCambio)
            Dim queryTC As IEnumerable(Of XElement) = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF43718"
                                                         Select d
            For Each d As XElement In queryTC
                dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
            Next
            'txtPrueba.Text = dbTC.ToString
            LlenadoCombos()
            rdoActivo.Checked = True
            WSActivo = 1
            btnActualizar.Enabled = False
            lblFechaRecuperado.Visible = False
            lblRecuperado.Visible = False

            ocultaActualizacion()
            cargaModuloAlta()
            'rdoManual.Checked = True            
        Catch ex As Exception
            WSActivo = 0
            LlenadoCombos()
            rdoActivo.Checked = True
            'rdoManual.Checked = True
            cargaModuloAlta()

            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "Ocurrió un error inesperado." + vbCrLf + "Error: " + ex.Message
            objAdvertencia.ShowDialog()
        End Try

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FRWK_PARIDAD", "FRMWK_PARIDAD_ALTAMODULO") Then            

        Else
            tbtParidad.TabPages(1).Parent = Nothing
        End If
    End Sub

    Public Sub LlenadoCombos()
        Dim parCamBU As New Framework.Negocios.ParidadcambiariaBU
        Dim dtMonedas As New DataTable
        dtMonedas = parCamBU.cargaMoneda("")
        dtMonedas.Rows.InsertAt(dtMonedas.NewRow(), 0)
        cmbTipoMoneda.DataSource = dtMonedas
        cmbTipoMoneda.ValueMember = "mone_monedaid"
        cmbTipoMoneda.DisplayMember = "mone_nombre"

        Dim dtModulos As New DataTable
        dtModulos = parCamBU.cargaModuloActualizacion
        dtModulos.Rows.InsertAt(dtModulos.NewRow(), 0)
        cmbModulo.DataSource = dtModulos
        cmbModulo.ValueMember = "mopc_idmodulo"
        cmbModulo.DisplayMember = "modu_nombre"

        Dim dtModulosAlta As New DataTable
        dtModulosAlta = parCamBU.cargaModuloAlta
        dtModulosAlta.Rows.InsertAt(dtModulosAlta.NewRow(), 0)
        cmbModuloAlta.DataSource = dtModulosAlta
        cmbModuloAlta.ValueMember = "modu_moduloid"
        cmbModuloAlta.DisplayMember = "nombre"
    End Sub

    Public Function ValidarVacios() As Boolean
        If tbtParidad.SelectedTab.Name.ToString = "tbtParidadPestania" Then
            Dim monedaID As Int32 = 0
            Try
                monedaID = CInt(cmbTipoMoneda.SelectedValue)
                moduloID = CInt(cmbModulo.SelectedValue)

            Catch ex As Exception

            End Try
            If monedaID = 0 Or moduloID = 0 Or txtParidad.Value = 0 Then
                If monedaID = 0 Then
                    lblMoneda.ForeColor = Color.Red
                Else
                    lblMoneda.ForeColor = Color.Black
                End If
                If moduloID = 0 Then
                    lblModulo.ForeColor = Color.Red
                Else
                    lblModulo.ForeColor = Color.Black
                End If
                If txtParidad.Value = 0 Then
                    lblParidad.ForeColor = Color.Red
                Else
                    lblParidad.ForeColor = Color.Black
                End If
                Return False
            Else
                lblMoneda.ForeColor = Color.Black
                lblModulo.ForeColor = Color.Black
                lblParidad.ForeColor = Color.Black
            End If
        Else
            Dim modulo As Int32 = 0
            Try
                modulo = CInt(cmbModuloAlta.SelectedValue)

            Catch ex As Exception

            End Try
            If modulo = 0 Then
                lblModuloAlta.ForeColor = Color.Red
                Return False
            Else
                lblModuloAlta.ForeColor = Color.Black
            End If

        End If
        Return True
    End Function

    Public Sub guardaParidadManual()
        Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU
        Dim monedaID As Int32 = 0
        Try
            monedaID = CInt(cmbTipoMoneda.SelectedValue)

        Catch ex As Exception

        End Try
        If ValidarVacios() = True Then
            Dim objMensajeConfirmacion As New Tools.ConfirmarForm
            objMensajeConfirmacion.Text = "Atención"
            objMensajeConfirmacion.mensaje = "¿Desea guardar la paridad para la moneda " + LTrim(RTrim(cmbTipoMoneda.Text)) + "?"
            If objMensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                moduloID = CInt(cmbModulo.SelectedValue)
                objParidadBU.guardaParidadMoneda(monedaID, txtParidad.Value.ToString, moduloID, "MANUAL")
                Dim objMensajeValido As New Tools.AvisoForm
                objMensajeValido.Text = "Aviso"
                objMensajeValido.mensaje = "Paridad guardada exitosamente"
                objMensajeValido.ShowDialog()
                cmbTipoMoneda.SelectedIndex = 0
                cmbModulo.SelectedIndex = 0
                txtParidad.Value = 0
                rdoActivo.Checked = True
                cargaParidad()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.Text = "Advertencia"
            objMensaje.mensaje = "Complete los campos obligatorios"
            objMensaje.ShowDialog()
        End If

        'objParidadBU.guardaParidadMoneda()
    End Sub
    Public Sub cargaParidad()
        Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU
        Dim dtCargaParidad As New DataTable
        Dim activo As Boolean = CBool(rdoActivo.Checked)
        dtCargaParidad = objParidadBU.cargaParidad(activo)

        grdMoneda.DataSource = dtCargaParidad        
        diseñoGridModulo()
    End Sub
    Public Sub diseñoGridModulo()

        If grdMoneda.Rows.Count > 0 Then
            With grdMoneda.DisplayLayout.Bands(0)

                .Columns("paca_paridadcambiariaid").Hidden = True
                .Columns("paca_monedaid").Hidden = True
                .Columns("paca_moduloid").Hidden = True
                .Columns("mopc_automatica").Hidden = True
                .Columns("TipoActualizacion").Hidden = True

                .Columns("mone_nombre").Header.Caption = "Moneda"
                .Columns("paca_paridadpesos").Header.Caption = "Pesos"
                .Columns("modu_nombre").Header.Caption = "Módulo"
                '.Columns("TipoActualizacion").Header.Caption = "Actualización"
                .Columns("paca_fechacreacion").Header.Caption = "Fecha Alta"

                .Columns("mone_nombre").CellActivation = Activation.NoEdit
                .Columns("paca_paridadpesos").CellActivation = Activation.NoEdit
                .Columns("modu_nombre").CellActivation = Activation.NoEdit
                '.Columns("TipoActualizacion").CellActivation = Activation.NoEdit
                .Columns("paca_fechacreacion").CellActivation = Activation.NoEdit

                .Columns("paca_fechacreacion").Style = ColumnStyle.DateTime
                .Columns("paca_paridadpesos").CellAppearance.TextHAlign = HAlign.Right

                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With

            grdMoneda.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdMoneda.DisplayLayout.Bands(0).Columns("paca_paridadpesos").Style = ColumnStyle.DoubleNonNegative
            'PARA DARLE UN TAMAÑO ESPECIFICO A UNA COLUMNA
            'grdMoneda.DisplayLayout.Bands(0).Columns("prod_codigo").Width = 100            

            grdMoneda.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdMoneda.DisplayLayout.Override.RowSelectorWidth = 35
            grdMoneda.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdMoneda.Rows(0).Selected = True
            grdMoneda.Enabled = True

        Else
            'btnEnvioContp.Enabled = False
            grdMoneda.DataSource = Nothing
            grdMoneda.Enabled = False

            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.Text = "Advertencia"
            objMesj.mensaje = "No hay información para mostrar"
            objMesj.ShowDialog()

        End If
    End Sub
    Public Sub cargaModuloAlta()
        Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU
        Dim dtCargaModuloAlta As New DataTable

        dtCargaModuloAlta = objParidadBU.ModulosAlta()
        grdModuloCarga.DataSource = dtCargaModuloAlta
        DiseñoGridMA()
    End Sub
    Public Sub DiseñoGridMA()
        If grdModuloCarga.Rows.Count > 0 Then
            With grdModuloCarga.DisplayLayout.Bands(0)

                .Columns("mopc_moduloparidadcargaid").Hidden = True
                .Columns("mopc_idmodulo").Hidden = True
                .Columns("mopc_usuariocreo").Hidden = True                

                .Columns("nombre").Header.Caption = "Nombre Módulo"
                .Columns("user_username").Header.Caption = "Usuario alta"                
                .Columns("mopc_fechacreacion").Header.Caption = "Fecha creación"

                .Columns("mopc_fechacreacion").Style = ColumnStyle.DateTime
                .Columns("nombre").CellActivation = Activation.NoEdit
                .Columns("user_username").CellActivation = Activation.NoEdit                
                .Columns("mopc_fechacreacion").CellActivation = Activation.NoEdit


                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'grdModuloCarga.DisplayLayout.Bands(0).Columns.Add("Seleccion", "Seleccion")
            'Dim colSeleccionIva As UltraGridColumn = grdModuloCarga.DisplayLayout.Bands(0).Columns("mopc_automatica")
            'colSeleccionIva.DefaultCellValue = False
            'colSeleccionIva.Header.Caption = "Automática"
            'colSeleccionIva.Style = ColumnStyle.CheckBox

            '' ''For Each rowDT As UltraGridRow In grdModuloCarga.Rows
            '' ''    rowDT.Cells("mopc_automatica").Value = False
            '' ''Next

            grdModuloCarga.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            'PARA DARLE UN TAMAÑO ESPECIFICO A UNA COLUMNA
            'grdMoneda.DisplayLayout.Bands(0).Columns("prod_codigo").Width = 100            

            grdModuloCarga.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdModuloCarga.DisplayLayout.Override.RowSelectorWidth = 35
            grdModuloCarga.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdModuloCarga.Rows(0).Selected = True
            grdModuloCarga.Enabled = True


        Else
            'btnEnvioContp.Enabled = False
            grdMoneda.DataSource = Nothing
            grdMoneda.Enabled = False

            Dim objMesj As New Tools.AdvertenciaForm
            objMesj.Text = "Advertencia"
            objMesj.mensaje = "No hay información para mostrar"
            objMesj.ShowDialog()

        End If
    End Sub
    Private Sub cmbTipoMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMoneda.SelectedIndexChanged        
        Try
            'If cmbTipoMoneda.SelectedValue.ToString <> "" Then
            If cmbTipoMoneda.SelectedIndex <> 0 Then
                Dim parCamBU As New Framework.Negocios.ParidadcambiariaBU
                Dim dtMonedas As New DataTable
                dtMonedas = parCamBU.cargaMoneda(cmbTipoMoneda.SelectedValue.ToString)
                lblSimboloMoneda.Text = dtMonedas.Rows(0).Item("mone_simbolo").ToString
                lblSimboloMoneda2.Text = dtMonedas.Rows(0).Item("mone_simbolo").ToString
                MuestraBusqueda()
            Else
                lblSimboloMoneda.Text = ""
                lblSimboloMoneda2.Text = ""
            End If

            If txtValorAutomatico.Text <> "" Then
                grpValores2.Enabled = False
                txtValorAutomatico.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub
    Public Sub guardaModuloCarga()
        Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU
        Dim moduloID As Int32 = 0
        Try
            moduloID = CInt(cmbModuloAlta.SelectedValue)

        Catch ex As Exception

        End Try

        If ValidarVacios() = True Then
            Dim objMensajeConfirmacion As New Tools.ConfirmarForm
            objMensajeConfirmacion.mensaje = "¿Desea guardar la paridad para la moneda " + LTrim(RTrim(cmbTipoMoneda.Text)) + "?"
            If objMensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                'objParidadBU.guardaParidadMoneda(monedaID, txtParidad.Value.ToString, moduloID, "MANUAL")
                Dim objMensajeValido As New Tools.AvisoForm
                objMensajeValido.Text = "Atención"
                objMensajeValido.mensaje = "Paridad guardada exitosamente"
                objMensajeValido.ShowDialog()
                cmbTipoMoneda.SelectedIndex = 0
                cmbModulo.SelectedIndex = 0
                txtParidad.Value = 0
                rdoActivo.Checked = True
                cargaParidad()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.Text = "Advertencia"
            objMensaje.mensaje = "Complete los campos obligatorios"
            objMensaje.ShowDialog()
        End If

        'objParidadBU.guardaParidadMoneda()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If AltaModulo_Paridad = True Then
            If tbtParidad.SelectedTab.Name.ToString = "tbtParidadPestania" Then
                guardaParidadManual()
            Else

                Dim objMensajeConfirmacion As New Tools.ConfirmarForm
                objMensajeConfirmacion.Text = "Atención"
                objMensajeConfirmacion.mensaje = "¿Desea actualizar los modulos mostrados?"
                If objMensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    actualizarModuloAlta()
                End If
            End If

            txtParidad.Text = "1"
        Else
            guardaModuloAlta()
        End If
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        cargaParidad()
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        'cargaParidad()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If WSActivo = 0 Then
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.Text = "Advertencia"
            objMensaje.mensaje = " No hay conexión al servicio del webService de Banxico, favor de actualizar manualmente"
            objMensaje.ShowDialog()
            ocultaActualizacion()

        Else
            Dim objMensajeConfirmacion As New Tools.ConfirmarForm
            objMensajeConfirmacion.Text = "Atención"
            objMensajeConfirmacion.mensaje = "¿Desea actualizar las paridades de manera automática? "
            If objMensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU
                Dim monedaID As Int32 = 0
                Dim moduloID As Int32 = 0

                Try
                    monedaID = CInt(cmbTipoMoneda.SelectedValue)
                    'moduloID = CInt(cmbModulo.SelectedValue)
                Catch ex As Exception
                End Try
                If ValidarVacios() = True Then                    
                        Dim paridad_actualizacion As Double
                        moduloID = CInt(cmbModulo.SelectedValue)
                        paridad_actualizacion = CDbl(txtValorAutomatico.Text)
                        objParidadBU.guardaParidadMoneda(monedaID, paridad_actualizacion.ToString, moduloID, "AUTOMATICA")
                    Dim objMensajeValido As New Tools.AvisoForm
                    objMensajeValido.Text = "Aviso"
                    objMensajeValido.mensaje = "Paridad actualizada exitosamente"
                        objMensajeValido.ShowDialog()
                        cmbTipoMoneda.SelectedIndex = 0
                        cmbModulo.SelectedIndex = 0
                        txtParidad.Value = 0
                        rdoActivo.Checked = True
                        cargaParidad()
                        OcultaActualizacion()                    
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    objMensaje.Text = "Advertencia"
                    objMensaje.mensaje = "Complete los campos obligatorios"
                    objMensaje.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub rdoManual_CheckedChanged(sender As Object, e As EventArgs)
        cargaModuloAlta()
    End Sub
    
    Public Sub guardaModuloAlta()
        Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU


        Dim modulo As Int32 = 0
        Try
            modulo = CInt(cmbModuloAlta.SelectedValue)

        Catch ex As Exception

        End Try
        If ValidarVacios() = True Then
            Dim objMensajeConfirmacion As New Tools.ConfirmarForm
            objMensajeConfirmacion.Text = "Atención"
            objMensajeConfirmacion.mensaje = "¿Desea dar de alta el modulo " + LTrim(RTrim(cmbModuloAlta.Text)) + "?"
            If objMensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                'Dim tipoCarga As Boolean = CBool(chkAutomatico.Checked)
                Dim tipoCarga As Boolean = True

                objParidadBU.guardarCargaModulo(modulo, tipoCarga)
                Dim objMensajeValido As New Tools.AvisoForm
                objMensajeValido.Text = "Aviso"
                objMensajeValido.mensaje = "Modulo agregado exitosamente"
                objMensajeValido.ShowDialog()
                cmbModuloAlta.SelectedIndex = 0

                cargaModuloAlta()
                LlenadoCombos()
            End If
        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.Text = "Advertencia"
            objMensaje.mensaje = "Complete los campos obligatorios"
            objMensaje.ShowDialog()
        End If
    End Sub
    Public Sub actualizarModuloAlta()
        Dim objParidadBU As New Framework.Negocios.ParidadcambiariaBU
        Dim contadorColumnas As New Int32
        Dim contadorFilas As New Int32
        Dim valores() As String
        Dim indexModulo As Int32 = 0
        Dim indexTipoCarga As Int32 = 0

        contadorFilas = grdModuloCarga.Rows.Count - 1
        contadorColumnas = grdModuloCarga.DisplayLayout.Bands(0).Columns.Count - 1

        If grdModuloCarga.Rows.Count > 0 Then
            For index As Integer = 0 To contadorFilas
                ReDim valores(contadorColumnas)
                For index2 As Int32 = 1 To contadorColumnas
                    Dim row As UltraGridRow = grdModuloCarga.Rows(index)
                    Dim column As UltraGridColumn = grdModuloCarga.DisplayLayout.Bands(0).Columns(index2)
                    Dim cellVal2 As Object = row.GetCellValue(column)
                    valores(index2) = cellVal2.ToString
                Next
                indexModulo = grdModuloCarga.DisplayLayout.Bands(0).Columns("mopc_idmodulo").Index
                indexTipoCarga = grdModuloCarga.DisplayLayout.Bands(0).Columns("mopc_automatica").Index

                objParidadBU.actualizaCargaModulo(CInt(valores(indexModulo)), CBool(valores(indexTipoCarga)))
            Next

            Dim objMensaje As New Tools.AvisoForm
            objMensaje.Text = "Aviso"
            objMensaje.mensaje = "Módulos actualizados correctamente"
            objMensaje.ShowDialog()

            cargaModuloAlta()

        Else
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.Text = "Advertencia"
            objMensaje.mensaje = "No existen campos para actualizar"
            objMensaje.ShowDialog()
            cargaModuloAlta()
        End If

    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        Dim moneda As Int32 = 0

        Try
            moneda = CInt(cmbTipoMoneda.SelectedValue)
        Catch ex As Exception

        End Try



        If moneda = 0 Then
            Dim objMensaje As New Tools.AdvertenciaForm
            objMensaje.Text = "Advertencia"
            objMensaje.mensaje = "Debe seleccionar un moneda"
            objMensaje.ShowDialog()
            txtValorAutomatico.Text = ""
            Me.Cursor = Cursors.Default
        Else

            Try
                If grpValores2.Enabled = False Then
                    grpValores2.Enabled = True
                End If

                Dim parCamBU As New Framework.Negocios.ParidadcambiariaBU
                Dim dtValidacionModulo As New DataTable
                Dim row As DataRow
                Dim moduloparidadcargaid As Int32
                Dim serie_banxico As String = ""

                dtValidacionModulo = parCamBU.validaModuloActualizacionAutomatica(moneda)

                For contador As Int32 = 0 To dtValidacionModulo.Rows.Count - 1
                    row = dtValidacionModulo.Rows(contador)
                    moduloparidadcargaid = CInt(row("mopc_moduloparidadcargaid"))
                    If IsDBNull(row("mone_serieBanxico")) = False Then
                        serie_banxico = CStr(row("mone_serieBanxico")).Trim
                    End If
                Next

                If moduloparidadcargaid >= 1 Then


                    'Para mandar llamar el WebService
                    Dim doc As XElement
                    Dim queryTC As IEnumerable(Of XElement)

                    'Para mandar llamar el WebService
                    If serie_banxico = "SF43718" Then
                        txtValorAutomatico.Text = ""
                        strTipoCambio = objWs.tiposDeCambioBanxico.ToString
                        doc = XElement.Parse(strTipoCambio)
                        queryTC = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF43718"
                                                                     Select d
                        For Each d As XElement In queryTC
                            dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
                        Next
                        txtValorAutomatico.Text = CStr(Math.Round(dbTC, 2))
                        muestraActualizacion()
                        Cursor = Cursors.Default

                    ElseIf serie_banxico = "SF46410" Then
                        txtValorAutomatico.Text = ""
                        strTipoCambio = objWs.tiposDeCambioBanxico.ToString
                        doc = XElement.Parse(strTipoCambio)
                        queryTC = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF46410"
                                                                     Select d
                        For Each d As XElement In queryTC
                            dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
                        Next
                        'txtValorAutomatico.Text = dbTC.ToString
                        txtValorAutomatico.Text = CStr(Math.Round(dbTC, 2))
                        muestraActualizacion()
                        Cursor = Cursors.Default
                    ElseIf serie_banxico = "SF43718" Then
                        txtValorAutomatico.Text = ""
                        strTipoCambio = objWs.tiposDeCambioBanxico.ToString
                        doc = XElement.Parse(strTipoCambio)
                        queryTC = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF43718"
                                                                     Select d
                        For Each d As XElement In queryTC
                            dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
                        Next
                        'txtValorAutomatico.Text = dbTC.ToString
                        txtValorAutomatico.Text = CStr(Math.Round(dbTC, 2))
                        muestraActualizacion()
                        Cursor = Cursors.Default
                    ElseIf serie_banxico = "SF60632" Then
                        txtValorAutomatico.Text = ""
                        strTipoCambio = objWs.tiposDeCambioBanxico.ToString
                        doc = XElement.Parse(strTipoCambio)
                        queryTC = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF60632"
                                                                     Select d
                        For Each d As XElement In queryTC
                            dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
                        Next
                        'txtValorAutomatico.Text = dbTC.ToString
                        txtValorAutomatico.Text = CStr(Math.Round(dbTC, 2))
                        muestraActualizacion()
                        Cursor = Cursors.Default
                    ElseIf serie_banxico = "SF46406" Then
                        txtValorAutomatico.Text = ""
                        strTipoCambio = objWs.tiposDeCambioBanxico.ToString
                        doc = XElement.Parse(strTipoCambio)
                        queryTC = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF46406"
                                                                     Select d
                        For Each d As XElement In queryTC
                            dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
                        Next
                        'txtValorAutomatico.Text = dbTC.ToString
                        txtValorAutomatico.Text = CStr(Math.Round(dbTC, 2))
                        muestraActualizacion()
                        Cursor = Cursors.Default
                    ElseIf serie_banxico = "SF46407" Then
                        txtValorAutomatico.Text = ""
                        strTipoCambio = objWs.tiposDeCambioBanxico.ToString
                        doc = XElement.Parse(strTipoCambio)
                        queryTC = From d In doc.<bm:DataSet>.<bm:Series> Where d.@IDSERIE = "SF46407"
                                                                     Select d
                        For Each d As XElement In queryTC
                            dbTC = CDbl(d.<bm:Obs>.@OBS_VALUE)
                        Next
                        'txtValorAutomatico.Text = dbTC.ToString
                        txtValorAutomatico.Text = CStr(Math.Round(dbTC, 2))
                        muestraActualizacion()
                        Cursor = Cursors.Default
                    Else
                        Dim objMensaje As New Tools.AdvertenciaForm
                        objMensaje.Text = "Advertencia"
                        objMensaje.mensaje = " No existe la paridad para la moneda " & cmbTipoMoneda.Text.Trim & " en el WebService de Banxico, favor de agregar manualmente"
                        objMensaje.ShowDialog()
                        ocultaActualizacion()
                        Cursor = Cursors.Default
                    End If
                Else
                    Dim objMensaje As New Tools.AdvertenciaForm
                    'objMensaje.mensaje = " No se permite buscar la actualización de la paridad para la moneda " & cmbTipoMoneda.Text.Trim & " en el WebService de Banxico, favor de agregar manualmente"
                    objMensaje.Text = "Advertencia"
                    objMensaje.mensaje = " No existe la paridad para la moneda " & cmbTipoMoneda.Text.Trim & " en el WebService de Banxico, favor de agregar manualmente"
                    objMensaje.ShowDialog()
                    ocultaActualizacion()
                    Cursor = Cursors.Default
                End If

            Catch ex As Exception
                Dim objError As New ErroresForm
                objError.StartPosition = FormStartPosition.CenterScreen
                objError.mensaje = "Ocurrio un error inesperado. Error: " + ex.Message
                objError.ShowDialog()
            End Try
        End If

    End Sub
    Private Sub tbtParidad_Click(sender As Object, e As EventArgs) Handles tbtParidad.Click        
        btnActualizar.Enabled = False
        ocultaBusqueda()
        If tbtParidad.SelectedTab.Name.ToString = "tbtParidadPestania" Then
            rdoActivo.Visible = True
            rdoInactivo.Visible = True
            grpValores3.Visible = True
            AltaModulo_Paridad = True
        Else
            rdoActivo.Visible = False
            rdoInactivo.Visible = False
            grpValores3.Visible = False
            AltaModulo_Paridad = False
        End If

    End Sub
    Public Sub muestraBusqueda()
        btnBuscar.Enabled = True
    End Sub
    Public Sub ocultaBusqueda()
        btnActualizar.Enabled = False
        btnBuscar.Enabled = False
        txtValorAutomatico.Enabled = False
        txtValorAutomatico.Text = ""
        txtParidad.Enabled = True
        txtParidad.Text = "1"

        cmbModulo.Text = ""
        cmbTipoMoneda.Text = ""
        lblFechaRecuperado.Visible = False
        btnGuardar.Enabled = True

    End Sub
    Public Sub muestraActualizacion()
        'btnBuscar.Enabled = True
        txtValorAutomatico.Enabled = True
        btnActualizar.Enabled = True
        btnGuardar.Enabled = False
        txtParidad.Enabled = False
        lblRecuperado.Visible = True
        lblFechaRecuperado.Text = DateTime.Now.ToString()
        lblFechaRecuperado.Visible = True

    End Sub
    Public Sub ocultaActualizacion()
        btnActualizar.Enabled = False
        btnBuscar.Enabled = False
        txtValorAutomatico.Enabled = False
        txtValorAutomatico.Text = ""
        txtParidad.Enabled = True
        txtParidad.Text = "1"
        btnGuardar.Enabled = True

        lblRecuperado.Visible = False
        lblFechaRecuperado.Visible = False
    End Sub
    Private Sub txtParidad_ValueChanged(sender As Object, e As EventArgs) Handles txtParidad.ValueChanged
        txtParidad.Text = Format(CSng(txtParidad.Text), "###.##")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pnlAcciones_Paint(sender As Object, e As PaintEventArgs) Handles pnlAcciones.Paint

    End Sub
End Class