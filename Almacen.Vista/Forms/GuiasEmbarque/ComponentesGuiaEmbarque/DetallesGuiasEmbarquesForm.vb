Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports Tools.Utilerias

Public Class DetallesGuiasEmbarquesForm
    Public embarqueid As String
    Dim objInstancia As New AdministradorDocumentosBU
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
        Dim tabla = objInstancia.ConsultarTiposEmpaquesOT
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

    Private Sub llenarInformacion(ByVal datos As Entidades.InformacionEmbarque)


        lblFolioEmbarque.Text = embarqueid
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

        If datos.Solitalla = 1 Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

        lblsession.Text = datos.Session
        lblclienteid.Text = datos.Clienteid

        diseñoCajas()
        ConsultarDocumentosEmbarque(embarqueid)

    End Sub

    Private Sub cbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPais.SelectedIndexChanged
        Dim value = cbPais.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        llenarComboEstado(cbPais.SelectedValue)

    End Sub
    Private Sub cbestados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestados.SelectedIndexChanged
        Dim value = cbPais.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        llenarComboCiudad(cbestados.SelectedValue)

    End Sub
    Private Sub DetallesGuiasEmbarquesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        llenarComboPais()
        llenarAllCombos()
        Dim datosEncabezado = objInstancia.ConsultarInformacionEmcabezado(embarqueid)
        llenarComboTrasporte(datosEncabezado.TiendaID)
        cbTransporte.SelectedValue = datosEncabezado.Transporte
        llenarInformacion(datosEncabezado)
    End Sub
    Private Sub diseñoCajas()
        'cmbCajas.Enabled = True
        Dim totalPares As Integer = 0

        grdCajas.DataSource = Nothing
        vwCajas.Columns.Clear()
        Dim talla As Boolean
        Dim result = objInstancia.EditarUnidadMedida(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
        Dim datos = objInstancia.ConsultarContenidoEmbarque(lblFolioEmbarque.Text, cmbCajas.SelectedValue)
        grdCajas.DataSource = datos

        DiseñoGrid.DiseñoBaseGrid(vwCajas)
        vwCajas.IndicatorWidth = 35
        vwCajas.OptionsView.ColumnAutoWidth = True
        For index = 0 To datos.Rows.Count - 1
            If CBool(datos.Rows(index).Item("TALLAS")) = True Then
                talla = True
                cmbCajas.Enabled = False
            End If
        Next
        If CheckBox1.Checked Then
            DiseñoGrid.EstiloColumna(vwCajas, "TALLAS", "TALLAS", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        Else
            DiseñoGrid.EstiloColumna(vwCajas, "TALLAS", "TALLAS", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        End If

        DiseñoGrid.EstiloColumna(vwCajas, "#", "TALLAS", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwCajas, " ", " ", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwCajas, "PARES", "PARES", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

        calcularPares()

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
    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwCajas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class