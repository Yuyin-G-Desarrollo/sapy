Imports System.ComponentModel
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

Public Class GuiaEmbarqueDinamicoForm

    Dim objInstancia As New AdministradorDocumentosBU
    Public EmbarqueID As Integer = 0
    Dim datosEncabezado As Entidades.InformacionEmbarque
    Public DocumentosSeleccionadosId As String = String.Empty
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    Public SessionId As Integer = 0
    Dim DireccionTienda As String = ""
    Dim cmbTamañoCajas As New RepositoryItemLookUpEdit()

    Private Sub GuiaEmbarqueDinamicoForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblFolioEmbarque.Text = EmbarqueID.ToString()
        lblsession.Text = SessionId.ToString()
        llenarAllCombos()
        cargarVistaPreviaEmbarque(EmbarqueID)
    End Sub
    Private Sub llenarAllCombos()
        llenarComboTipoFleje()
        llenarComboOperador()
        llenarComboContenido()
        llenarcombocajas()
        llenarcomboRemitente()
        llenarcomboRFC()
        llenarComboPais()
        CmbRFC.SelectedIndex = 0
        CmbRFC_SelectedIndexChanged(Nothing, Nothing)

    End Sub

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
            Controles.ComboPaisesMayusculas(cbPais)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los Paises por favor comunicate con TI")
        End Try
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

    Private Sub llenarcombocajas()
        Dim tabla = objInstancia.ConsultarTiposEmpaquesNM
        With cmbCajas
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub llenarcomboRFC()
        Dim tabla = objInstancia.ObtenerRFCDocumentos(DocumentosSeleccionadosId)
        With CmbRFC
            .DataSource = tabla
            .DisplayMember = "RFC"
            .ValueMember = "RFCID"
        End With

    End Sub

    Private Sub llenarcomboTiendas(ByVal RFCId As Integer)
        Dim tabla = objInstancia.ObtenerTiendas(DocumentosSeleccionadosId, RFCId)
        With cmbTienda
            .DataSource = tabla
            .DisplayMember = "Tienda"
            .ValueMember = "TiendaID"
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

    Private Sub cargarVistaPreviaEmbarque(ByVal numEmbarque As Integer)

        Try

            datosEncabezado = objInstancia.ConsultarInformacionEmcabezado(CInt(lblFolioEmbarque.Text))

            'llenarInformacion(datosEncabezado)
            If cmbCajas.SelectedValue <> 0 Then
                diseñoCajas(cmbCajas.SelectedValue)
            Else
                grdCajas.DataSource = Nothing
                vwCajas.Columns.Clear()
            End If
            ConsultarDocumentosEmbarque(CInt(lblFolioEmbarque.Text))

            cbTransporte.SelectedValue = datosEncabezado.Transporte
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "No se consultaron los datos del embarque correctamente comunicate con TI")
        End Try

        'HabilitarDesabilitarDireccion(lblclienteid.Text)


    End Sub

    Private Sub llenarInformacion(ByVal datos As Entidades.InformacionEmbarque)

        Dim unidad = datos.UnidadMedida

        cbRemitente.SelectedValue = datos.RemitenteID
        'txtConsignatario.Text = datos.Tienda
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

    Private Sub diseñoCajas(action As Integer)
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

    Private Sub ConsultarDocumentosEmbarque(ByVal embarqueid As Integer)
        Try
            Dim listaDocumentos = objInstancia.ConsultarDocumentosEmbarque(CInt(lblFolioEmbarque.Text))
            If listaDocumentos.Error <> True Then
                grdDocumentos.DataSource = listaDocumentos.ListadoDocumentos
                txttotalPares.Text = listaDocumentos.TotalPares
                ' DiseñoGrid.DiseñoBaseGrid(vwDocumentos)
                vwDocumentos.IndicatorWidth = 35
                vwDocumentos.OptionsView.ColumnAutoWidth = True
                'No visibles
                ' DiseñoGrid.EstiloColumna(vwDocumentos, "ClienteID", "Error", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")

                'Visibles
                ' DiseñoGrid.EstiloColumna(vwDocumentos, "Pares", "Pares", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
                'DiseñoGrid.EstiloColumna(vwDocumentos, "Importe", "Importe", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 70, True, Nothing, "{0:0,0.00}")

            Else
                Utilerias.show_message(TipoMensaje.Advertencia, listaDocumentos.Mensaje)
            End If

        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub cmbTienda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTienda.SelectedIndexChanged
        Dim DomicilioTienda As Entidades.InformacionEmbarque
        If cmbTienda.ValueMember <> "" Then
            If IsNumeric(cmbTienda.SelectedValue = True) Then
                If cmbTienda.SelectedValue > 0 Then
                    DomicilioTienda = objInstancia.ObtenerDomicilioTienda(EmbarqueID, cmbTienda.SelectedValue, CmbRFC.SelectedValue)
                    llenarInformacionDomicilioTienda(DomicilioTienda)
                    llenarComboTrasporte(cmbTienda.SelectedValue)
                End If
            End If
        End If





    End Sub

    Private Sub CmbRFC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbRFC.SelectedIndexChanged
        If CmbRFC.ValueMember <> "" Then
            If CmbRFC.SelectedValue > 0 Then
                llenarcomboTiendas(CmbRFC.SelectedValue)
                cmbTienda_SelectedIndexChanged(Nothing, Nothing)
            End If
        End If


    End Sub


    Private Sub llenarInformacionDomicilioTienda(ByVal datos As Entidades.InformacionEmbarque)


        cbPais.SelectedValue = datos.PaisID
        cbestados.SelectedValue = datos.EstadoID
        cbciudades.SelectedValue = datos.CiudadID
        txtColonia.Text = datos.Colonia
        txtDireccion.Text = datos.Direccion
        txtNOEXT.Text = datos.NumExt
        txtNOINT.Text = datos.NumInt
        txtCP.Text = datos.CP
        txtDireccion.Text = datos.Calle
        cbFleje.SelectedValue = datos.Tipofleje
        txttelefono.Text = datos.Telefono
        DireccionTienda = datos.Domicilio
        lblformapago.Text = datos.FormaPago

    End Sub

    Private Sub cbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPais.SelectedIndexChanged
        If cbPais.ValueMember <> "" Then
            If cbPais.SelectedValue > 0 Then
                llenarComboEstado(cbPais.SelectedValue)
            End If
        End If

    End Sub

    Private Sub cbestados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestados.SelectedIndexChanged
        If cbestados.ValueMember <> "" Then
            If cbestados.SelectedValue > 0 Then
                llenarComboCiudad(cbestados.SelectedValue)
            End If
        End If

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim myDatatView As DataTable
        myDatatView = CType(grdCajas.DataSource, DataTable)
        Dim totalPares As Integer = 0
        If cmbCajas.Text <> "" Then
            Dim numeroCaja = objInstancia.ConsultarNumeroCaja(lblFolioEmbarque.Text)
            objInstancia.AgregarCaja(numeroCaja.Rows(0).Item("numero"), lblFolioEmbarque.Text, cmbCajas.SelectedValue, cmbTamañoCajas.GetDisplayValueByKeyValue("TAMAÑO CAJA"))
            Dim tabla = objInstancia.ConsultarContenidoEmbarque(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
            grdCajas.DataSource = tabla
            obtieneTamañoCajaEmbarque()
            errPais.Clear()
            calcularPares()
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona una unidad de medida")
        End If
    End Sub
    Private Sub vwCajas_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles vwCajas.CellValueChanged
        If CBool(vwCajas.GetRowCellValue(vwCajas.GetVisibleRowHandle(e.RowHandle), "TALLAS")) = True Then
            Utilerias.show_message(TipoMensaje.Advertencia, "Modificaste los pares a una caja que ya tenia registros con talla deberas modificar tambien los detalles de la talla")
        End If
        validaparesCajas()
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

    Private Sub vwCajas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwCajas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
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

    Private Sub vwCajas_RowClick(sender As Object, e As RowClickEventArgs) Handles vwCajas.RowClick
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

    Private Sub vwDocumentos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwDocumentos.CustomDrawCell
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardarEmbarque_Click(sender As Object, e As EventArgs) Handles btnGuardarEmbarque.Click
        Dim ObjInformacionGuiaEmbarque As New Entidades.InformacionEmbarque
        Dim objActualizaCaja As New AdministradorDocumentosBU
        Dim cajaId As Integer = 0
        Dim iddetalle As Integer = 0

        If ValidarCapturaCompleta() = True Then

            With ObjInformacionGuiaEmbarque
                .FolioEmbarque = EmbarqueID
                .Emisorid = cbRemitente.SelectedValue
                .RFCClienteID = CmbRFC.SelectedValue
                .TiendaID = cmbTienda.SelectedValue
                .Embarco = cbOperador.SelectedValue
                .PaisID = cbPais.SelectedValue
                .EstadoID = cbestados.SelectedValue
                .CiudadID = cbciudades.SelectedValue
                .Transporte = cbTransporte.SelectedValue
                .Tipofleje = cbFleje.SelectedValue
                .Pais = cbPais.Text
                .Estado = cbestados.Text
                .Ciudad = cbciudades.Text
                .FormaPago = lblformapago.Text
                .Direccion = DireccionTienda
                .Calle = txtDireccion.Text
                .Colonia = txtColonia.Text
                .CP = txtCP.Text
                .NumExt = txtNOEXT.Text
                .NumInt = txtNOINT.Text

            End With

            objInstancia.InsertarInformacionFaltanteGuiaEmbarqueDinamico(ObjInformacionGuiaEmbarque, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

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

                    Utilerias.show_message(TipoMensaje.Exito, "Se Genero correctamente el Embarque")
                    Me.Close()
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste una impresora las etiquetas no se imprimieron")
                End If
            Catch ex As Exception
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un Error no se mandaron a imprimir las etiquetas")
            End Try

        Else
            Utilerias.show_message(TipoMensaje.Aviso, "Falta información por capturar")
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
                Utilerias.show_message(TipoMensaje.Advertencia, "No hay información de los embarques")

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



    Public Function ValidarCapturaCompleta() As Boolean
        Dim ValidacionExitosa As Boolean = True

        If cbRemitente.SelectedValue < 0 Then
            ValidacionExitosa = False
        End If

        If CmbRFC.SelectedValue < 0 Then
            ValidacionExitosa = False
        End If

        If cbOperador.SelectedValue < 0 Then
            ValidacionExitosa = False
        End If

        If cmbTienda.SelectedValue < 0 Then
            ValidacionExitosa = False
        End If

        If cbTransporte.SelectedValue < 0 Then
            ValidacionExitosa = False
        End If

        If txtcajapares.Text <> txttotalPares.Text Then
            ValidacionExitosa = False
            ValidacionExitosa = False
        End If

        Return ValidacionExitosa

    End Function

    Private Sub GuiaEmbarqueDinamicoForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        objInstancia.CerrarSessionGuiaEmbarqueDinamico(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
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