Imports System.IO
Imports Almacen.Negocios
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Tools.Utilerias
Imports Ventas.Vista

Public Class GuiaEmbarqueForm

    Public lista As List(Of Entidades.NivelDocumentos)
    Dim confirmar As New Tools.ConfirmarForm
    Dim objInstancia As New AdministradorDocumentosBU
    Dim idcajasatados As Integer = 1
    Dim cajasTallas As Boolean = False
    Dim AtadosTallas As Boolean = False
    Dim cambio As Boolean = False
    Dim datosEncabezado As Entidades.InformacionEmbarque
    Dim salir As Integer
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    Dim DTImpresoras As DataTable
    Public formDocumentos As AdministradorDocumentosForm
    Public formEmbarques As AdministradorGuiasEmbarqueForm
    Dim clientdireespecial As Integer
    Dim cmbTamañoCajas As New RepositoryItemLookUpEdit()

    Private Sub llenarComboCiudad(estado As Integer)
        Try
            Controles.ComboCiudades(cbciudades, estado)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE CONTENIDO por favor comunicate con TI")
        End Try
    End Sub

    Private Sub llenarComboEstado(paisid As Integer)
        Try
            Controles.ComboEstados(cbestados, paisid)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE CONTENIDO por favor comunicate con TI")
        End Try
    End Sub

    Private Sub llenarComboPais()
        Try
            Controles.ComboPaises(cbPais)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los Paises por favor comunicate con TI")
        End Try
    End Sub

    Private Sub cargarVistaPreviaEmbarque(ByVal numEmbarque As Integer)

        If CInt(lblTotalDocumentos.Text) > CInt(lblNumeroDocumentoActual.Text) Then
            btnSiguiente.Enabled = True
            lblTextoSiguiente.Enabled = True
        Else
            btnSiguiente.Enabled = False
            lblTextoSiguiente.Enabled = False
        End If

        If CInt(lblNumeroDocumentoActual.Text) > 1 Then
            btnAnterior.Enabled = True
            lblTextoAnterior.Enabled = True
        Else
            btnAnterior.Enabled = False
            lblTextoAnterior.Enabled = False
        End If

        Try
            Dim result = From v In lista Where v.Nivel = lblNumeroDocumentoActual.Text
            lblFolioEmbarque.Text = result(0).Embarque
            datosEncabezado = objInstancia.ConsultarInformacionEmcabezado(CInt(lblFolioEmbarque.Text))

            llenarInformacion(datosEncabezado)
            If cmbCajas.SelectedValue <> 0 Then
                diseñoCajas(cmbCajas.SelectedValue)
            Else
                grdCajas.DataSource = Nothing
                vwCajas.Columns.Clear()
            End If
            ConsultarDocumentosEmbarque(CInt(lblFolioEmbarque.Text))
            llenarComboTrasporte(datosEncabezado.TiendaID)
            cbTransporte.SelectedValue = datosEncabezado.Transporte
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "No se consultaron los datos del embarque correctamente comunicate con TI")
        End Try

        HabilitarDesabilitarDireccion(lblclienteid.Text)


    End Sub


    Private Sub llenarInformacion(ByVal datos As Entidades.InformacionEmbarque)

        Dim unidad = datos.UnidadMedida

        cbRemitente.SelectedValue = datos.RemitenteID
        txtConsignatario.Text = datos.Tienda
        cbPais.SelectedValue = datos.PaisID
        cbestados.SelectedValue = datos.EstadoID
        cbciudades.SelectedValue = datos.CiudadID
        txtColonia.Text = datos.Colonia
        txtDireccion.Text = datos.Direccion
        txtNOEXT.Text = datos.NumExt
        txtNOINT.Text = datos.NumInt
        txtCP.Text = datos.CP
        cbFleje.SelectedValue = datos.Tipofleje
        lblformapago.Text = datos.FormaPago
        cbOperador.SelectedValue = datos.Embarco
        cmbCajas.SelectedValue = unidad
        txttelefono.Text = datos.Telefono
        If datos.Rembarque = 1 Then
            cbRembarque.Checked = True
        Else
            cbRembarque.Checked = False
        End If

        If unidad = 0 Then
            cmbCajas.Enabled = True
            Button3.Visible = False
        Else
            cmbCajas.Enabled = False
            Button3.Visible = True
        End If

        If datos.Solitalla = 1 Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

        lblsession.Text = datos.Session
        lblclienteid.Text = datos.Clienteid



    End Sub


    Private Sub llenarComboContenido()
        Try
            Controles.ComboContenidoEmarque(cbContenido)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE CONTENIDO por favor comunicate con TI")
        End Try
    End Sub
    Private Sub llenarComboTrasporte(tiendaid As Integer)
        Try
            Dim tabla = objInstancia.ConsultarPaqueterias(tiendaid)
            With cbTransporte
                .DataSource = tabla
                .DisplayMember = "Nombre"
                .ValueMember = "ID"
            End With
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE TRASPORTE por favor comunicate con TI")
        End Try
    End Sub
    Private Sub llenarComboOperador()
        Try
            Controles.ComboOperadoresAlmacen(cbOperador)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los OPERADORES por favor comunicate con TI")
        End Try
    End Sub
    Private Sub llenarComboTipoFleje()
        Try
            Controles.ComboTipoFleje(cbFleje)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPO DE FLEJE por favor comunicate con TI")
        End Try
    End Sub

    Private Sub llenarAllCombos()
        llenarComboTipoFleje()
        llenarComboOperador()
        llenarComboContenido()
        llenarcombocajas()
        llenarcomboRemitente()
    End Sub

    Private Sub llenarcombocajas()
        Dim tabla = objInstancia.ConsultarTiposEmpaquesNM
        With cmbCajas
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub llenarcomboRemitente()
        Dim tabla = objInstancia.ConsultarRemitentes
        With cbRemitente
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub GuiaEmbarqueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        llenarComboPais()

        lblNumeroDocumentoActual.Text = "1"
        lblTotalDocumentos.Text = lista(0).TotalNivel
        llenarAllCombos()
        dtfecha.Value = Date.Now
        cargarVistaPreviaEmbarque(CInt(lblNumeroDocumentoActual.Text))

    End Sub

    Private Sub diseñoCajas(action As Integer)
        'cmbCajas.Enabled = True
        Dim totalPares As Integer = 0

        grdCajas.DataSource = Nothing
        vwCajas.Columns.Clear()
        Dim talla As Boolean
        Dim result = objInstancia.EditarUnidadMedida(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
        Dim datos = objInstancia.ConsultarContenidoEmbarque(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
        grdCajas.DataSource = datos
        vwCajas.IndicatorWidth = 35
        vwCajas.OptionsView.ColumnAutoWidth = True
        For index = 0 To datos.Rows.Count - 1
            If CBool(datos.Rows(index).Item("TALLAS")) = True Then
                talla = True
                cmbCajas.Enabled = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwCajas.Columns
            If col.FieldName = " " Then
                col.Visible = False
            End If
            If col.FieldName = "#" Then
                col.Visible = False
            End If
            If col.FieldName = "TALLAS" Then
                col.Visible = False
            End If
            If col.FieldName = "tamañocajaid" Then
                col.Visible = False
            End If
            If col.FieldName = "UNIDAD" Then
                col.OptionsColumn.AllowEdit = False
            End If
        Next
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwCajas.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        calcularPares()

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim faltantes As Integer = 0

        If CheckBox1.Checked = True Then
            Dim NumeroFilas = vwCajas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                Dim cell = CBool(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(index), "TALLAS"))
                Dim pares = vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(index), "PARES")
                If cell = False And pares IsNot Nothing Then
                    faltantes = 1
                End If
            Next
        End If

        If faltantes > 0 Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Antes de cambiar de documento favor de asignar las tallas a todas sus cajas")
        Else
            If clientdireespecial = 1 Then
                ActualizarTienda()
            End If
            lblNumeroDocumentoActual.Text = (CInt(lblNumeroDocumentoActual.Text) + 1).ToString("n0")
            cargarVistaPreviaEmbarque(CInt(lblNumeroDocumentoActual.Text) - 1)
            calcularPares()
        End If


    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim faltantes As Integer = 0

        If CheckBox1.Checked = True Then
            Dim NumeroFilas = vwCajas.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                Dim cell = CBool(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(index), "TALLAS"))
                Dim pares = vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(index), "PARES")
                If cell = False And pares IsNot Nothing Then
                    faltantes = 1
                End If
            Next
        End If

        If faltantes > 0 Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Antes de cambiar de documento favor de asignar las tallas a todas sus cajas")
        Else
            If clientdireespecial = 1 Then
                ActualizarTienda()
            End If
            lblNumeroDocumentoActual.Text = (CInt(lblNumeroDocumentoActual.Text) - 1).ToString("n0")
            cargarVistaPreviaEmbarque(CInt(lblNumeroDocumentoActual.Text) - 1)
            calcularPares()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listado As New FiltroOperadoresAlmacenForm
        listado.todos = 0
        listado.StartPosition = FormStartPosition.CenterParent
        listado.ShowDialog(Me)
        If listado.listaParametroID <> 0 Then
            cbOperador.SelectedValue = listado.listaParametroID
        End If
    End Sub

    Private Sub GuiaEmbarqueForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If salir = 1 Then
        Else
            confirmar.mensaje = "¿Está seguro de salir perderas la informacion obtenida?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim result = objInstancia.EliminarDatosSession(0, lblsession.Text)
                If result.Error = 1 Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "No se eliminaron correctamente los datos de la session comunicate con TI")
                End If
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub ConsultarDocumentosEmbarque(ByVal embarqueid As Integer)
        Try
            Dim listaDocumentos = objInstancia.ConsultarDocumentosEmbarque(CInt(lblFolioEmbarque.Text))
            If listaDocumentos.Error <> True Then
                grdDocumentos.DataSource = listaDocumentos.ListadoDocumentos
                txttotalPares.Text = listaDocumentos.TotalPares
                DiseñoGrid.DiseñoBaseGrid(vwDocumentos)
                vwDocumentos.IndicatorWidth = 35
                vwDocumentos.OptionsView.ColumnAutoWidth = True
                'No visibles
                DiseñoGrid.EstiloColumna(vwDocumentos, "ClienteID", "Error", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")

                'Visibles
                DiseñoGrid.EstiloColumna(vwDocumentos, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                DiseñoGrid.EstiloColumna(vwDocumentos, "Importe", "Importe", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 70, True, Nothing, "{0:0,0.00}")

            Else
                Utilerias.show_message(TipoMensaje.Advertencia, listaDocumentos.Mensaje)
            End If

        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim myDatatView As DataTable
        myDatatView = CType(grdCajas.DataSource, DataTable)
        Dim totalPares As Integer = 0
        If cmbCajas.Text <> "" Then
            Dim numeroCaja = objInstancia.ConsultarNumeroCaja(lblFolioEmbarque.Text)
            objInstancia.AgregarCaja(numeroCaja.Rows(0).Item("numero"), lblFolioEmbarque.Text, cmbCajas.SelectedValue, 0)
            Dim tabla = objInstancia.ConsultarContenidoEmbarque(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
            grdCajas.DataSource = tabla
            obtieneTamañoCajaEmbarque()
            errPais.Clear()
            calcularPares()
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona una unidad de medida")
        End If
    End Sub

    Private Sub vwModelos_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles vwCajas.CellValueChanged
        If CBool(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(e.RowHandle), "TALLAS")) = True Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Modificaste los pares a una caja que ya tenia registros con talla deberas modificar tambien los detalles de la talla")
        End If
        validaparesCajas()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim myDatatView As DataTable
        myDatatView = CType(grdCajas.DataSource, DataTable)
        Dim elimino As Boolean = False
        Dim eliminados As Integer = 0
        Try
            For index2 = 0 To myDatatView.Rows.Count - 1
                If CBool(myDatatView.Rows(index2).Item(" ")) = True Then
                    Dim numCaja = myDatatView.Rows(index2).Item("#")
                    Dim EmbarqueID = lblFolioEmbarque.Text
                    Dim resultado = objInstancia.EliminarCaja(numCaja, EmbarqueID)
                    If resultado.Error <> 0 Then
                        Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error con la caja" & numCaja & "Intentalo de nuevo ERROR" & resultado.Mensaje)
                    End If
                End If

            Next
            diseñoCajas(cmbCajas.SelectedValue)
            validaparesCajas()
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error" & ex.Message)
        End Try

    End Sub
    Private Sub validaparesCajas()
        Try
            Dim myDatatView As DataTable
            myDatatView = CType(grdCajas.DataSource, DataTable)
            Dim totalPares As Integer = 0
            Dim cajas As Integer = 0
            If myDatatView.Rows.Count <> 0 Then
                For index = 0 To myDatatView.Rows.Count - 1
                    If myDatatView.Rows(index).RowState <> DataRowState.Deleted Then
                        Dim numCaja = myDatatView.Rows(index).Item("#")
                        Dim EmbarqueID = lblFolioEmbarque.Text
                        Dim pares = myDatatView.Rows(index).Item("PARES")
                        Dim resultado = objInstancia.EditarCaja(numCaja, EmbarqueID, pares)

                        If resultado.Error <> 0 Then
                            Utilerias.show_message(TipoMensaje.Advertencia, "No se actualizo los pares de la caja vuelve a introducir el valor en la celda")
                        End If
                        totalPares = totalPares + pares
                    End If
                Next
                If txttotalPares.Text >= totalPares Then
                    txtcajapares.Text = totalPares
                    txtcajacajas.Text = vwCajas.RowCount
                    errPais.Clear()
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, "La cantidad sobrepasa los pares del los documentos")
                    errPais.SetError(txtcajapares, "La cantidad sobrepasa los pares del los documentos")
                End If
            End If
            Dim filas() = vwCajas.GetSelectedRows
            For fila = 0 To filas.Count - 1
                vwCajas.FocusedRowHandle = vwCajas.GetRowHandle(filas(fila) + 1)
            Next
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        Dim myDatatView As DataTable
        myDatatView = CType(grdCajas.DataSource, DataTable)
        If myDatatView Is Nothing Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona primero una unidad de medida donde se empacaran los zapatos")
            Dim cb As CheckBox = DirectCast(sender, CheckBox)

            RemoveHandler cb.CheckedChanged, AddressOf CheckBox1_CheckedChanged

            cb.Checked = Not cb.Checked

            AddHandler cb.CheckedChanged, AddressOf CheckBox1_CheckedChanged
        Else
            If CheckBox1.Checked = True Then
                Dim result = objInstancia.Editartalla(lblFolioEmbarque.Text, 1)
                DiseñoGrid.EstiloColumna(vwCajas, "TALLAS", "TALLAS", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
            Else
                Dim result = objInstancia.Editartalla(lblFolioEmbarque.Text, 0)
                DiseñoGrid.EstiloColumna(vwCajas, "TALLAS", "TALLAS", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
            End If
        End If



    End Sub

    Private Sub vwCajas_RowClick(sender As Object, e As Views.Grid.RowClickEventArgs) Handles vwCajas.RowClick
        If CheckBox1.Checked = True Then
            If vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(e.RowHandle), "PARES") > 0 Then
                Dim instanciaTallas As New TallasGEForm
                instanciaTallas.embarqueID = lblFolioEmbarque.Text
                instanciaTallas.numeroCaja = vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(e.RowHandle), "#")
                instanciaTallas.totalPares = vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(e.RowHandle), "PARES")
                If CBool(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(e.RowHandle), "TALLAS")) = True Then
                    instanciaTallas.existenR = 1
                Else
                    instanciaTallas.existenR = 0
                End If
                instanciaTallas.ShowDialog()
                diseñoCajas(cmbCajas.SelectedValue)
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Ingresa primero cantidad de pares a la caja")
            End If

        End If
    End Sub

    Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
        Dim value = cmbCajas.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        If value <> 0 Then
            If CheckBox1.Checked Then
                objInstancia.Editartalla(lblFolioEmbarque.Text, 1)
            Else
                objInstancia.Editartalla(lblFolioEmbarque.Text, 0)
            End If

            diseñoCajas(cmbCajas.SelectedValue)
            cmbCajas.Enabled = False
            Button3.Visible = True
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        If formDocumentos IsNot Nothing Then
            formDocumentos.ConsultarDocumentos()
        End If
        If formEmbarques IsNot Nothing Then

            formEmbarques.ConsultarDocumentos()
        End If
    End Sub

    Private Sub cbOperador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOperador.SelectedIndexChanged
        Dim value = cbOperador.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        If cambio Then
            cambio = False
        Else
            If Not DBNull.Value.Equals(cbOperador.SelectedValue) Then

                Dim resultado = objInstancia.EditarOperadorEmbarco(lblFolioEmbarque.Text, cbOperador.SelectedValue)
                If resultado.Error <> 0 Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error al modificar el operador" & resultado.Mensaje)
                End If
            Else
                Dim resultado = objInstancia.EditarOperadorEmbarco(lblFolioEmbarque.Text, 0)
                If resultado.Error <> 0 Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error al modificar el operador" & resultado.Mensaje)
                End If
            End If
        End If
    End Sub
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwCajas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub cbTransporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTransporte.SelectedIndexChanged
        Dim value = cbTransporte.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        If cambio Then
            cambio = False
        Else
            If Not DBNull.Value.Equals(cbTransporte.SelectedValue) Then

                Dim resultado = objInstancia.EditarPaqueteria(lblFolioEmbarque.Text, cbTransporte.SelectedValue)
                If resultado.Error <> 0 Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error al modificar la paqueteria" & resultado.Mensaje)
                End If
            End If
        End If

    End Sub

    Private Sub calcularPares()
        Dim myDatatView As DataTable
        myDatatView = CType(grdCajas.DataSource, DataTable)
        Dim totalPares As Integer = 0
        Dim cajas As Integer = 0
        If vwCajas.RowCount > 0 Then
            For index = 0 To myDatatView.Rows.Count - 1
                Dim pares = myDatatView.Rows(index).Item("PARES")
                totalPares = totalPares + pares
            Next
            txtcajapares.Text = String.Format("{0:N0}", totalPares)
            txtcajacajas.Text = String.Format("{0:N0}", vwCajas.RowCount)
        Else
            txtcajapares.Text = 0
            txtcajacajas.Text = 0
        End If

    End Sub

    Private Sub cbRemitente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRemitente.SelectedIndexChanged
        Dim value = cbRemitente.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        If Not DBNull.Value.Equals(cbRemitente.SelectedValue) Then

            Dim resultado = objInstancia.EditarRemitente(lblFolioEmbarque.Text, cbRemitente.SelectedValue)
            If resultado.Error <> 0 Then
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error al modificar el remitente" & resultado.Mensaje)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pasascont As Integer = 0
        Dim mensajeError As String = ""
        Dim objActualizaCaja As New AdministradorDocumentosBU
        Dim cajaId As Integer = 0
        Dim iddetalle As Integer = 0

        If clientdireespecial = 1 Then
            pasascont = validarCampos()
            ActualizarTienda()
        End If

        Dim validacion = objInstancia.ValidarInformacionEmbarque(lblsession.Text)
        If validacion.Columns.Contains("mostrar") Then
            If validacion.Rows(0).Item("mostrar") = 0 Then
                pasascont = 1
            Else
                Dim mensaje As New MensajeBDEmbarquesForm
                mensaje.mensajes = validacion
                mensaje.StartPosition = FormStartPosition.CenterParent
                mensaje.ShowDialog()
                Return
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, validacion.Rows(0).Item("Error"))
            Return
        End If


        If pasascont = 1 Then
            Dim resultado = objInstancia.insertardatosfaltantes(lblsession.Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, If(cbRembarque.Checked, 1, 0))

            For x As Integer = 0 To vwCajas.RowCount - 1 '' ingresa los id de los tamaños de las cajas
                cajaId = CInt(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(x), "TAMAÑO CAJAS"))
                iddetalle = CInt(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(x), "#"))
                objActualizaCaja.actualizaTamañoCajaEmbarque(cajaId, lblFolioEmbarque.Text, iddetalle)
            Next

            Dim listado As New FiltroImpresoraForm
            listado.ShowDialog()
            Dim impresora = listado.listaParametroID

            Try
                If impresora <> 0 Then

                    GenerarImpresion(lblsession.Text, impresora)
                    objInstancia.InsertarBitacoraImprecionGE(lblsession.Text, "", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste una impresora las etiquetas no se imprimieron")
                End If
            Catch ex As Exception
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un Error no se mandaron a imprimir las etiquetas")
            End Try
            If resultado.Error <> 1 Then
                salir = 1
                If formDocumentos IsNot Nothing Then
                    formDocumentos.ConsultarDocumentos()
                End If
                If formEmbarques IsNot Nothing Then

                    formEmbarques.ConsultarDocumentos()
                End If
                Utilerias.show_message(TipoMensaje.Exito, "Se Genero correctamente el Embarque")
                Me.Close()
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error no se guardaron los datos correctamente")
            End If
        End If


    End Sub

    Private Sub GenerarImpresion(ByVal sessionid As Integer, ByVal impresoraID As Integer)

        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim dtInformacionEtiquetas As New DataTable
        Dim UsuarioID As Integer = 0
        Dim EtiquetasAImprimir As String = String.Empty
        Dim etiquetaEspecial As Integer = 0
        Try

            Dim Cliente = vwDocumentos.GetRowCellValue(vwCajas.GetVisibleRowHandle(0), "Cliente")

            Cursor = Cursors.WaitCursor
            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid



            dtInformacionEtiquetas = objInstancia.ConsultarEtiquetasEmbarque(sessionid, "", impresoraID, UsuarioID, etiquetaEspecial)
            If dtInformacionEtiquetas.Rows.Count = 0 Then
                show_message("Advertencia", "No hay información de los embarques")
                Return
            End If

            strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

            For Each FILA As DataRow In dtInformacionEtiquetas.Rows
                EtiquetasAImprimir &= FILA.Item(0)
            Next

            strStreamWriter.WriteLine(EtiquetasAImprimir)
            strStreamWriter.Close()

            GenerarArchivoBat(impresoraID)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try

    End Sub
    Private Function CrearRutasArchivo(ByVal Carpeta As String, ByVal Archivo As String) As Stream
        Dim strStreamW As Stream = Nothing

        Try
            If System.IO.Directory.Exists(Carpeta) = False Then
                System.IO.Directory.CreateDirectory(Carpeta)
            End If

            If File.Exists(Archivo) Then
                File.Delete(Archivo)
                strStreamW = File.Create(Archivo)
            Else
                strStreamW = File.Create(Archivo)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return strStreamW

    End Function

    Private Sub GenerarArchivoBat(ByVal impresoraid As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable


        Try
            Cursor = Cursors.WaitCursor

            dtArchivo = objInstancia.ComandosImprimirEtiquetaGuiasEmbarque(impresoraid)

            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each FILA As DataRow In dtArchivo.Rows
                strStreamWriter.WriteLine(FILA.Item(0))
            Next

            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub

    Private Sub viewInventario_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwDocumentos.CustomDrawCell


        Cursor = Cursors.WaitCursor
        Try
            'If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Importe" Then
                e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                e.Column.DisplayFormat.FormatString = "##,##0.00"
            End If

            Cursor = Cursors.Default
            'End If

        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbCajas.SelectedValue = 0 Then

        Else
            deleteCajas()
            diseñoCajas(cmbCajas.SelectedValue)
        End If

    End Sub

    Private Sub deleteCajas()
        Try
            objInstancia.BorrarCajas(lblFolioEmbarque.Text)
            cmbCajas.SelectedValue = 0
            cmbCajas.Enabled = True
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "No hay cajas que borrar")
        End Try
    End Sub

    Private Sub vwCajas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles vwCajas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If e.KeyChar = " " Then Return
            Dim filas() = vwCajas.GetSelectedRows
            For fila = 0 To filas.Count - 1
                vwCajas.FocusedRowHandle = vwCajas.GetRowHandle(filas(fila) + 1)
            Next

        End If
    End Sub

    Private Sub cbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPais.SelectedIndexChanged
        Dim value = cbPais.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        If cbPais.SelectedValue > 0 Then
            llenarComboEstado(cbPais.SelectedValue)
            errPais.Clear()
        Else
            errPais.SetError(cbPais, "Selecciona un Pais")
        End If
    End Sub

    Private Sub cbestados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestados.SelectedIndexChanged
        Dim value = cbPais.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        If cbestados.SelectedValue > 0 Then
            llenarComboCiudad(cbestados.SelectedValue)
            errEstado.Clear()
        Else
            errEstado.SetError(cbestados, "Selecciona un Estado")
        End If
    End Sub

    Private Sub HabilitarDesabilitarDireccion(clienteid As Integer)
        Dim clienteE = objInstancia.ConsultarClientesEspeciales(lblclienteid.Text)
        If clienteE.Rows.Count > 0 Then
            If CBool(clienteE.Rows(0).Item("ecommers")) = True Then
                cbPais.Enabled = True
                cbestados.Enabled = True
                cbciudades.Enabled = True
                txtCP.Enabled = True
                txtColonia.Enabled = True
                txtDireccion.Enabled = True
                txtNOEXT.Enabled = True
                txtNOINT.Enabled = True
                txttelefono.Enabled = True
                txtConsignatario.Enabled = True
                If txtConsignatario.Text = "CONOCIDO" Then
                    txtConsignatario.Text = ""
                End If
                clientdireespecial = 1
            End If
        Else
            cbPais.Enabled = False
            cbestados.Enabled = False
            cbciudades.Enabled = False
            txtCP.Enabled = False
            txtColonia.Enabled = False
            txtDireccion.Enabled = False
            txtNOEXT.Enabled = False
            txtNOINT.Enabled = False
            txttelefono.Enabled = False
            txtConsignatario.Enabled = False
            clientdireespecial = 0
        End If
    End Sub
    Private Sub ActualizarTienda()
        Try
            Dim guardo As Integer = 0
            Dim otroEmbarque As New Entidades.InformacionEmbarque

            otroEmbarque.FolioEmbarque = lblFolioEmbarque.Text
            otroEmbarque.PaisID = cbPais.SelectedValue
            otroEmbarque.Estado = cbestados.SelectedValue
            otroEmbarque.CiudadID = cbciudades.SelectedValue
            otroEmbarque.Colonia = txtColonia.Text
            otroEmbarque.CP = txtCP.Text
            otroEmbarque.Calle = txtDireccion.Text
            otroEmbarque.NumExt = txtNOEXT.Text
            otroEmbarque.NumInt = txtNOINT.Text
            otroEmbarque.Telefono = txttelefono.Text
            otroEmbarque.Consignatario = txtConsignatario.Text

            Dim resultado = objInstancia.ActualizarTiendaEmbarque(otroEmbarque)

            If resultado.Error = 0 Then
                guardo = 1
            Else
                guardo = 0
                salir = 0
                Utilerias.show_message(TipoMensaje.Advertencia, resultado.Mensaje)
            End If
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub cbciudades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbciudades.SelectedIndexChanged
        Dim value = cbciudades.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        If IsDBNull(value) Then
            errCiudad.SetError(cbciudades, "Selecciona una ciudad")
        Else
            errCiudad.Clear()
        End If
    End Sub

    Private Sub txtCP_TextChanged(sender As Object, e As EventArgs) Handles txtCP.TextChanged
        If txtCP.Text = "" Then
            errCP.SetError(txtCP, "Ingresa un codigo postal")
        Else
            errCP.Clear()
        End If
    End Sub

    Private Sub txtColonia_TextChanged(sender As Object, e As EventArgs) Handles txtColonia.TextChanged
        If txtColonia.Text = "" Then
            errColonia.SetError(txtColonia, "Ingresa una colonia")
        Else
            errColonia.Clear()
        End If
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        If txtDireccion.Text = "" Then
            errCalle.SetError(txtDireccion, "Ingresa una calle")
        Else
            errCalle.Clear()
        End If
    End Sub

    Private Sub txtNOEXT_TextChanged(sender As Object, e As EventArgs) Handles txtNOEXT.TextChanged
        If txtNOEXT.Text = "" Then
            errnumExt.SetError(txtNOEXT, "Ingresa un numero Exterior")
        Else
            errnumExt.Clear()
        End If
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        If Not IsNumeric(e.KeyChar) _
                    AndAlso Not Char.IsControl(e.KeyChar) _
                    AndAlso Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Function validarCampos() As Integer
        Dim pasas As Integer = 1
        If cbciudades.SelectedValue = 0 Or IsDBNull(cbciudades.SelectedValue) Then
            errCiudad.SetError(cbciudades, "Selecciona una ciudad")
            pasas = 0
        Else
            errCiudad.Clear()
        End If
        If txtCP.Text = "" Then
            pasas = 0
            errCP.SetError(txtCP, "Ingresa un codigo postal")
        Else
            errCP.Clear()
        End If
        If txtColonia.Text = "" Then
            errColonia.SetError(txtColonia, "Ingresa una colonia")
            pasas = 0
        Else
            errColonia.Clear()
        End If
        If txtDireccion.Text = "" Then
            errCalle.SetError(txtDireccion, "Ingresa una calle")
            pasas = 0
        Else
            errCalle.Clear()
        End If
        If txtNOEXT.Text = "" Then
            errnumExt.SetError(txtNOEXT, "Ingresa un numero exterior")
            pasas = 0
        Else
            errnumExt.Clear()
        End If
        If cbPais.SelectedValue = 0 Then

            errPais.SetError(cbPais, "Selecciona un Pais")
            pasas = 0
        Else
            errPais.Clear()
        End If
        If cbestados.SelectedValue = 0 Then
            errEstado.SetError(cbestados, "Selecciona un Estado")
            pasas = 0
        Else
            errEstado.Clear()
        End If
        If txttelefono.Text = "" Then
            errTelefono.SetError(txttelefono, "Ingresa un numero de Telefono")
            pasas = 0
        Else
            errTelefono.Clear()
        End If
        If txtConsignatario.Text = "" Then
            errConsignatario.SetError(txtConsignatario, "Ingresa un consignatario")
            pasas = 0
        Else
            errConsignatario.Clear()
        End If
        Return pasas
    End Function

    Private Sub txttelefono_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged
        If txttelefono.Text = "" Then
            errTelefono.SetError(txttelefono, "Ingresa un numero de Telefono")
        Else
            errTelefono.Clear()
        End If
    End Sub

    Private Sub txtConsignatario_TextChanged(sender As Object, e As EventArgs) Handles txtConsignatario.TextChanged
        If txtConsignatario.Text = "" Then
            errConsignatario.SetError(txtConsignatario, "Ingresa un consignatario")
        Else
            errConsignatario.Clear()
        End If
    End Sub
    Private Sub obtieneTamañoCajaEmbarque()
        Dim dtTamañoCajas As New DataTable
        dtTamañoCajas = objInstancia.obtenerTamañoCajasEmbarque
        cmbTamañoCajas.DataSource = dtTamañoCajas
        cmbTamañoCajas.DisplayMember = "descripcion"
        cmbTamañoCajas.ValueMember = "Id_caja"
        cmbTamañoCajas.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        cmbTamañoCajas.DropDownRows = dtTamañoCajas.Rows.Count
        cmbTamañoCajas.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete
        cmbTamañoCajas.AutoSearchColumnIndex = 1
        cmbTamañoCajas.PopulateColumns()
        cmbTamañoCajas.Columns("Id_caja").Visible = False
        cmbTamañoCajas.ShowHeader = False
        vwCajas.Columns("TAMAÑO CAJAS").ColumnEdit = cmbTamañoCajas
    End Sub
    Private Sub vwCajas_KeyDown(sender As Object, e As KeyEventArgs) Handles vwCajas.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Dim iddetalleEliminar As Integer = 0
            Dim objEliminaCaja As New Negocios.AdministradorDocumentosBU
            iddetalleEliminar = (vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(vwCajas.FocusedRowHandle), "#"))
            objEliminaCaja.eliminaDetalleCajaEmbarque(iddetalleEliminar)
            vwCajas.DeleteRow(vwCajas.FocusedRowHandle)
        End If
    End Sub
End Class