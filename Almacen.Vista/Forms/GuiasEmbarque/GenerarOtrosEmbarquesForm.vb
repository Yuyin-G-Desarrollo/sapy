Imports System.IO
Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports Tools.Utilerias

Public Class GenerarOtrosEmbarquesForm
    Dim objInstancia As New AdministradorDocumentosBU
    Dim confirmar As New Tools.ConfirmarForm
    Dim salir As Integer
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    Public embarqueid As Integer
    Dim datosEncabezado As Entidades.InformacionEmbarque
    Public formEmbarques As AdministradorGuiasEmbarqueForm
    Public lista As New List(Of Entidades.NivelDocumentos)


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
            datosEncabezado = objInstancia.ConsultarInformacionEmcabezadoOtrosEmbarques(CInt(lblFolioEmbarque.Text))

            llenarInformacion(datosEncabezado)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "No se consultaron los datos del embarque correctamente comunicate con TI")
        End Try



    End Sub

    Private Sub llenarcombocajas()
        Dim tabla = objInstancia.ConsultarTiposEmpaquesOT
        With cmbCajas
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub llenarComboContenido()
        Try
            Controles.ComboContenidoEmarque(cbContenido)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE CONTENIDO por favor comunicate con TI")
        End Try
    End Sub
    Private Sub llenarcomboRemitente()
        Dim tabla = objInstancia.ConsultarRemitentes
        With cbRemitente
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
        End With
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
            Controles.ComboPaises(cbPais)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los Paises por favor comunicate con TI")
        End Try
    End Sub

    Private Sub llenarComboFlete()
        Try
            Controles.ComboTipoFlete(cbFleje)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Aviso, "No se consultaron bien los TIPOS DE CONTENIDO por favor comunicate con TI")
        End Try
    End Sub

    'Private Sub llenarcomboOpcionesRembarque()
    '    Dim tabla = objInstancia.ConsultarOpcionesRembarque
    '    With cbRembarque
    '        .DataSource = tabla
    '        .DisplayMember = "Nombre"
    '        .ValueMember = "ID"
    '    End With
    'End Sub

    Private Sub llenarcomboColaboradores()
        Dim tabla = objInstancia.ConsultarTodosLosOperadores()
        With cbSolicita
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "Parámetro"
        End With
    End Sub

    Private Sub llenarcomboOpcioneMensajeria()
        Dim tabla = objInstancia.ConsultarOpcionesMensajerias
        With cbTransporte
            .DataSource = tabla
            .DisplayMember = "Nombre"
            .ValueMember = "ID"
        End With
    End Sub

    Private Sub llenarAllCombos()
        llenarComboPais()
        llenarcomboOpcioneMensajeria()
        'llenarcomboOpcionesRembarque()
        llenarComboContenido()
        llenarComboFlete()
        llenarcomboRemitente()
        llenarcomboColaboradores()
        llenarcombocajas()

        cbPais.SelectedValue = 1
        cbestados.SelectedValue = 1
        cbciudades.SelectedValue = 1
    End Sub

    Private Sub llenarInformacion(ByVal datos As Entidades.InformacionEmbarque)



        If datos.Contenido = 5 Then
            Dim tamaño As New Size
            tamaño.Width = 145
            tamaño.Height = 21

            cbContenido.Size = tamaño
            lblespesifica.Visible = True
            txtespecifica.Visible = True
            txtespecifica.Text = datos.Especifica

        Else
            Dim tamaño As New Size
            tamaño.Width = 271
            tamaño.Height = 21

            cbContenido.Size = tamaño
            lblespesifica.Visible = False
            txtespecifica.Visible = False
            txtespecifica.Text = ""
        End If
        txtConsignatario.Text = datos.Consignatario
        cbContenido.SelectedValue = datos.Contenido
        txtespecifica.Text = datos.Especifica
        cbSolicita.SelectedValue = datos.Solicita
        cbPais.SelectedValue = datos.PaisID
        cbestados.SelectedValue = datos.EstadoID
        cbciudades.SelectedValue = datos.CiudadID
        txtColonia.Text = datos.Colonia
        txtDireccion.Text = datos.Calle
        txtNOEXT.Text = datos.NumExt
        txtNOINT.Text = datos.NumInt
        txtCP.Text = datos.CP
        cbFleje.SelectedValue = datos.Tipofleje
        cbTransporte.SelectedValue = datos.Transporte
        cbReembarque.Checked = True
        txtlada.Text = datos.Lada
        txttelefono.Text = datos.Telefono
        txtobservaciones.Text = datos.Observaciones
        lblsessionid.Text = datos.Session
        txtCostoEnvio.Text = datos.CostoEnvio
        txtcontacto.Text = datos.Contacto
        cmbCajas.SelectedValue = datos.UnidadMedida
        diseñoCajas()

    End Sub


    Private Sub GenerarOtrosEmbarquesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.MdiParent = ParentForm
        llenarAllCombos()
        Button3.Visible = False
        If lista.Count <> 0 Then
            lblNumeroDocumentoActual.Text = "1"
            lblTotalDocumentos.Text = lista(0).TotalNivel
            'llenarAllCombos()
            dtfecha.Value = Date.Now
            cargarVistaPreviaEmbarque(CInt(lblNumeroDocumentoActual.Text))
            gpboxNavegacionDocumentos.Visible = True
        Else
            Dim folio = objInstancia.ConsultarFolioFinal(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            lblFolioEmbarque.Text = folio.Rows(0).Item("Folio")
            lblsessionid.Text = folio.Rows(0).Item("SessionID")
            gpboxNavegacionDocumentos.Visible = False
        End If




    End Sub

    Private Sub GenerarOtrosEmbarquesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If salir = 1 Then
        Else
            confirmar.mensaje = "¿Está seguro de salir perderas la informacion obtenida?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim result = objInstancia.EliminarDatosSession(0, lblsessionid.Text)
                If formEmbarques IsNot Nothing Then
                    formEmbarques.ConsultarDocumentos()
                End If
                If result.Error = 1 Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "No se eliminaron correctamente los datos de la session comunicate con TI")
                End If
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GuardarEmbarque()
    End Sub

    Private Sub GuardarEmbarque()

        Dim pasas = validarDatos()

        If pasas = 1 Then
            If vwCajas.RowCount <> 0 Then


                Dim otroEmbarque As New Entidades.InformacionEmbarque

                otroEmbarque.FolioEmbarque = lblFolioEmbarque.Text
                otroEmbarque.Contenido = cbContenido.SelectedValue
                otroEmbarque.Consignatario = txtConsignatario.Text
                otroEmbarque.RemitenteID = cbRemitente.SelectedValue
                otroEmbarque.Remitente = cbRemitente.SelectedText
                otroEmbarque.Solicita = cbSolicita.SelectedValue
                otroEmbarque.Estado = cbestados.SelectedValue
                otroEmbarque.CiudadID = cbciudades.SelectedValue
                otroEmbarque.Colonia = txtColonia.Text
                otroEmbarque.CP = txtCP.Text
                otroEmbarque.Calle = txtDireccion.Text
                otroEmbarque.NumExt = txtNOEXT.Text
                otroEmbarque.NumInt = txtNOINT.Text
                otroEmbarque.Transporte = cbTransporte.SelectedValue
                otroEmbarque.FormaPago = cbFleje.SelectedValue
                otroEmbarque.Rembarque = If(cbReembarque.Checked, 1, 0)
                otroEmbarque.Observaciones = txtobservaciones.Text
                otroEmbarque.Consignatario = txtConsignatario.Text
                otroEmbarque.DescripcionContenido = txtespecifica.Text
                otroEmbarque.CostoEnvio = txtCostoEnvio.Text
                otroEmbarque.Lada = txtlada.Text
                otroEmbarque.Telefono = txttelefono.Text
                otroEmbarque.Contacto = txtcontacto.Text
                otroEmbarque.UnidadMedida = cmbCajas.SelectedValue

                Dim resultado = objInstancia.GuardarGuiaOtrosEmbarques(otroEmbarque)

                If resultado.Error = 0 Then
                    Dim listado As New FiltroImpresoraForm
                    listado.ShowDialog()
                    Dim impresora = listado.listaParametroID
                    Try
                        If impresora <> 0 Then

                            GenerarImpresion(lblFolioEmbarque.Text, impresora)
                            objInstancia.InsertarBitacoraImprecionGE(lblsessionid.Text, "", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                        Else
                            Utilerias.show_message(TipoMensaje.Advertencia, "No seleccionaste una impresora las etiquetas no se imprimieron")
                        End If
                    Catch ex As Exception
                        Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un Error no se mandaron a imprimir las etiquetas")
                    End Try
                    salir = 1
                    If formEmbarques IsNot Nothing Then
                        formEmbarques.ConsultarDocumentos()
                    End If
                    Utilerias.show_message(TipoMensaje.Exito, "Se Genero correctamente el Embarque")
                    Me.Close()
                Else
                    salir = 0
                    Utilerias.show_message(TipoMensaje.Advertencia, resultado.Mensaje)
                End If
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Falta QUE AGREGUES LAS CAJAS QUE ENVIARAS")
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Falta informacion que llenes")
        End If


    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        If formEmbarques IsNot Nothing Then
            formEmbarques.ConsultarDocumentos()
        End If
        Me.Close()
    End Sub

    Private Sub cbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPais.SelectedIndexChanged
        Dim value = cbPais.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        llenarComboEstado(cbPais.SelectedValue)
    End Sub

    Private Sub cbestados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestados.SelectedIndexChanged
        llenarComboCiudad(cbestados.SelectedValue)
    End Sub

    Private Sub cbContenido_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbContenido.SelectedIndexChanged
        Dim value = cbContenido.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        If cbContenido.SelectedValue = 5 Then
            Dim tamaño As New Size
            tamaño.Width = 145
            tamaño.Height = 21

            cbContenido.Size = tamaño
            lblespesifica.Visible = True
            txtespecifica.Visible = True
        Else
            Dim tamaño As New Size
            tamaño.Width = 271
            tamaño.Height = 21

            cbContenido.Size = tamaño
            lblespesifica.Visible = False
            txtespecifica.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim listado As New FiltroOperadoresAlmacenForm
        listado.todos = 1
        listado.StartPosition = FormStartPosition.CenterParent
        listado.ShowDialog(Me)
        If listado.listaParametroID <> 0 Then
            cbSolicita.SelectedValue = listado.listaParametroID
        End If
    End Sub

    Private Sub GenerarImpresion(ByVal embarqueid As Integer, ByVal impresoraID As Integer)

        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim dtInformacionEtiquetas As New DataTable
        Dim UsuarioID As Integer = 0
        Dim EtiquetasAImprimir As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor
            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid


            dtInformacionEtiquetas = objInstancia.ConsultarEtiquetasOtrosEmbarque(lblsessionid.Text, "", 0, impresoraID, UsuarioID)
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

    Private Sub diseñoCajas()
        grdCajas.DataSource = Nothing
        vwCajas.Columns.Clear()
        'Dim result = objInstancia.EditarUnidadMedida(lblFolioEmbarque.Text, 1)
        Dim datos = objInstancia.ConsultarContenidoEmbarque(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
        grdCajas.DataSource = datos

        DiseñoGrid.DiseñoBaseGrid(vwCajas)
        vwCajas.IndicatorWidth = 35
        vwCajas.OptionsView.ColumnAutoWidth = True


        DiseñoGrid.EstiloColumna(vwCajas, "#", "TALLAS", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwCajas, "TALLAS", "TALLAS", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwCajas, " ", " ", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwCajas, "PARES", "PARES", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim myDatatView As DataTable
        myDatatView = CType(grdCajas.DataSource, DataTable)
        Dim totalPares As Integer = 0

        Dim numeroCaja = objInstancia.ConsultarNumeroCaja(lblFolioEmbarque.Text)
        objInstancia.AgregarCaja(numeroCaja.Rows(0).Item("numero"), lblFolioEmbarque.Text, cmbCajas.SelectedValue, 0)
        diseñoCajas()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If vwCajas.RowCount <> 0 Then
            escondercampos(1)
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "No hay Datos que borrar")
        End If
    End Sub

    Private Sub btnCalcelar_Click(sender As Object, e As EventArgs) Handles btnCalcelar.Click
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
            diseñoCajas()
            escondercampos(0)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error" & ex.Message)
        End Try
    End Sub
    Private Sub escondercampos(action As Integer)
        If action = 1 Then
            DiseñoGrid.EstiloColumna(vwCajas, " ", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, False, Nothing, "{0:N0}")
            btnCalcelar.Visible = True
            btneliminar2.Visible = True
            btnAgregar.Visible = False
            lblAgregar.Visible = False
            btnEliminar.Visible = False
            lblEliminar.Visible = False
        Else
            btnCalcelar.Visible = False
            btneliminar2.Visible = False
            btnAgregar.Visible = True
            lblAgregar.Visible = True
            btnEliminar.Visible = True
            lblEliminar.Visible = True
            DiseñoGrid.EstiloColumna(vwCajas, " ", " ", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, False, 60, False, Nothing, "{0:N0}")
        End If
    End Sub

    Private Sub btneliminar2_Click(sender As Object, e As EventArgs) Handles btneliminar2.Click
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
            diseñoCajas()
            escondercampos(0)
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error" & ex.Message)
        End Try

    End Sub

    Private Sub viewcajas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwCajas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub txtConsignatario_TextChanged(sender As Object, e As EventArgs) Handles txtConsignatario.TextChanged
        If txtConsignatario.Text = "" Then
            errConsignatario.SetError(txtConsignatario, "Debes de ingresar un consignatario")
        Else
            errConsignatario.Clear()
        End If
    End Sub

    Private Sub cbSolicita_TextChanged(sender As Object, e As EventArgs) Handles cbSolicita.TextChanged
        If cbSolicita.Text = "" Then
            errSolicita.SetError(cbSolicita, "Debes ingresar quien solicita el embarque")
        Else
            errSolicita.Clear()
        End If
    End Sub

    Private Sub txtCP_TextChanged(sender As Object, e As EventArgs) Handles txtCP.TextChanged
        If txtCP.Text = "" Then
            errCP.SetError(txtCP, "Debes ingresar un codigo Postal")
        Else
            errCP.Clear()
        End If
    End Sub

    Private Sub txtColonia_TextChanged(sender As Object, e As EventArgs) Handles txtColonia.TextChanged
        If txtColonia.Text = "" Then
            errColonia.SetError(txtColonia, "Debes ingresar una colonia")
        Else
            errColonia.Clear()
        End If
    End Sub

    Private Sub txtDireccion_TextChanged(sender As Object, e As EventArgs) Handles txtDireccion.TextChanged
        If txtDireccion.Text = "" Then
            errCalle.SetError(txtDireccion, "Debes ingresar una calle")
        Else
            errCalle.Clear()
        End If
    End Sub

    Private Sub txtNOEXT_TextChanged(sender As Object, e As EventArgs) Handles txtNOEXT.TextChanged
        If txtNOEXT.Text = "" Then
            errNoExt.SetError(txtNOEXT, "Debes ingresar una calle")
        Else
            errNoExt.Clear()
        End If
    End Sub

    Private Sub cbTransporte_TextChanged(sender As Object, e As EventArgs) Handles cbTransporte.TextChanged
        If cbTransporte.Text = "" Then
            errTransporte.SetError(cbTransporte, "Debes ingresar que mensajeria usaras")
        Else
            errTransporte.Clear()
        End If
    End Sub

    Private Sub cbFleje_TextChanged(sender As Object, e As EventArgs) Handles cbFleje.TextChanged
        If cbFleje.Text = "" Then
            errTipoFlete.SetError(cbFleje, "Debes ingresar que mensajeria usaras")
        Else
            errTipoFlete.Clear()
        End If
    End Sub

    Private Sub txtlada_TextChanged(sender As Object, e As EventArgs) Handles txtlada.TextChanged
        If txtlada.Text = "" Then
            errLada.SetError(txtlada, "Debes ingresar una lada")
        Else
            errLada.Clear()
        End If
    End Sub

    Private Sub txttelefono_TextChanged(sender As Object, e As EventArgs) Handles txttelefono.TextChanged
        If txttelefono.Text = "" Then
            errTelefono.SetError(txttelefono, "Debes ingresar un telefono")
        Else
            errTelefono.Clear()
        End If
    End Sub

    Private Function validarDatos() As Integer

        Dim pasas As Integer = 1

        If txtConsignatario.Text = "" Then
            errConsignatario.SetError(txtConsignatario, "Debes de ingresar un consignatario")
            pasas = 0
        Else
            errConsignatario.Clear()
        End If

        If cbSolicita.Text = "" Then
            errSolicita.SetError(cbSolicita, "Debes ingresar quien solicita el embarque")
            pasas = 0
        Else
            errSolicita.Clear()
        End If

        If txtCP.Text = "" Then
            errCP.SetError(txtCP, "Debes ingresar un codigo Postal")
            pasas = 0
        Else
            errCP.Clear()
        End If

        If txtColonia.Text = "" Then
            errColonia.SetError(txtColonia, "Debes ingresar una colonia")
            pasas = 0
        Else
            errColonia.Clear()
        End If

        If txtDireccion.Text = "" Then
            errCalle.SetError(txtDireccion, "Debes ingresar una calle")
            pasas = 0
        Else
            errCalle.Clear()
        End If

        If txtNOEXT.Text = "" Then
            errNoExt.SetError(txtNOEXT, "Debes ingresar una calle")
            pasas = 0
        Else
            errNoExt.Clear()
        End If

        If cbTransporte.Text = "" Then
            errTransporte.SetError(cbTransporte, "Debes ingresar que mensajeria usaras")
            pasas = 0
        Else
            errTransporte.Clear()
        End If

        If cbFleje.Text = "" Then
            errTipoFlete.SetError(cbFleje, "Debes ingresar que mensajeria usaras")
            pasas = 0
        Else
            errTipoFlete.Clear()
        End If

        If txtlada.Text = "" Then
            errLada.SetError(txtlada, "Debes ingresar una lada")
            pasas = 0
        Else
            errLada.Clear()
        End If

        If txttelefono.Text = "" Then
            errTelefono.SetError(txttelefono, "Debes ingresar un telefono")
            pasas = 0
        Else
            errTelefono.Clear()
        End If
        If txtcontacto.Text = "" Then
            errContacto.SetError(txtcontacto, "Debes ingresar un contacto")
            pasas = 0
        Else
            errContacto.Clear()
        End If

        Return pasas
    End Function

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim guardo = guardarultimofolio()
        If guardo = 1 Then
            lblNumeroDocumentoActual.Text = (CInt(lblNumeroDocumentoActual.Text) + 1).ToString("n0")
            cargarVistaPreviaEmbarque(CInt(lblNumeroDocumentoActual.Text) - 1)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim guardo = guardarultimofolio()
        If guardo = 1 Then
            lblNumeroDocumentoActual.Text = (CInt(lblNumeroDocumentoActual.Text) - 1).ToString("n0")
            cargarVistaPreviaEmbarque(CInt(lblNumeroDocumentoActual.Text) - 1)
        End If
    End Sub

    Private Function guardarultimofolio() As Integer

        Dim pasas = validarDatos()
        Dim guardo As Integer = 0
        If pasas = 1 Then
            If vwCajas.RowCount <> 0 Then


                Dim otroEmbarque As New Entidades.InformacionEmbarque

                otroEmbarque.FolioEmbarque = lblFolioEmbarque.Text
                otroEmbarque.Contenido = cbContenido.SelectedValue
                otroEmbarque.Consignatario = txtConsignatario.Text
                otroEmbarque.RemitenteID = cbRemitente.SelectedValue
                otroEmbarque.Remitente = cbRemitente.SelectedText
                otroEmbarque.Solicita = cbSolicita.SelectedValue
                otroEmbarque.Estado = cbestados.SelectedValue
                otroEmbarque.CiudadID = cbciudades.SelectedValue
                otroEmbarque.Colonia = txtColonia.Text
                otroEmbarque.CP = txtCP.Text
                otroEmbarque.Calle = txtDireccion.Text
                otroEmbarque.NumExt = txtNOEXT.Text
                otroEmbarque.NumInt = txtNOINT.Text
                otroEmbarque.Transporte = cbTransporte.SelectedValue
                otroEmbarque.FormaPago = cbFleje.SelectedValue
                otroEmbarque.Rembarque = 0
                otroEmbarque.Observaciones = txtobservaciones.Text
                otroEmbarque.Consignatario = txtConsignatario.Text
                otroEmbarque.DescripcionContenido = txtespecifica.Text
                otroEmbarque.CostoEnvio = txtCostoEnvio.Text
                otroEmbarque.Lada = txtlada.Text
                otroEmbarque.Telefono = txttelefono.Text
                otroEmbarque.Contacto = txtcontacto.Text

                Dim resultado = objInstancia.GuardarGuiaOtrosEmbarques(otroEmbarque)

                If resultado.Error = 0 Then
                    guardo = 1
                Else
                    guardo = 0
                    salir = 0
                    Utilerias.show_message(TipoMensaje.Advertencia, resultado.Mensaje)
                End If
            Else
                guardo = 0
                Utilerias.show_message(TipoMensaje.Advertencia, "Falta QUE AGREGUES LAS CAJAS QUE ENVIARAS")
            End If
        Else
            guardo = 0
            Utilerias.show_message(TipoMensaje.Advertencia, "Falta informacion que llenes")
        End If

        Return guardo
    End Function

    Private Sub txtcontacto_TextChanged(sender As Object, e As EventArgs) Handles txtcontacto.TextChanged
        If txtcontacto.Text = "" Then
            errContacto.SetError(txtcontacto, "Debes ingresar un contacto")
        Else
            errContacto.Clear()
        End If
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        If Not IsNumeric(e.KeyChar) _
                    AndAlso Not Char.IsControl(e.KeyChar) _
                    AndAlso Not Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbCajas.SelectedValue = 0 Then

        Else
            deleteCajas()
            diseñoCajas()
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

    Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
        Dim value = cmbCajas.SelectedValue
        If (TypeOf value Is DataRowView) Then Return
        cmbCajas.Enabled = False
        Button3.Visible = True
    End Sub
End Class