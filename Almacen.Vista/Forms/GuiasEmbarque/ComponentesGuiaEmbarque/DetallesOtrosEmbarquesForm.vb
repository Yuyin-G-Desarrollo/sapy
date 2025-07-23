Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports Tools
Imports Tools.Utilerias

Public Class DetallesOtrosEmbarquesForm
    Dim objInstancia As New AdministradorDocumentosBU
    Public embarqueid As Integer
    Private Sub cargarVistaPreviaEmbarque()


        Try

            Dim datosEncabezado = objInstancia.ConsultarInformacionEmcabezadoOtrosEmbarques(embarqueid)

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
        cbReembarque.Checked = datos.Rembarque
        txtlada.Text = datos.Lada
        txttelefono.Text = datos.Telefono
        txtobservaciones.Text = datos.Observaciones
        lblsessionid.Text = datos.Session
        txtCostoEnvio.Text = datos.CostoEnvio
        txtcontacto.Text = datos.Contacto
        cmbCajas.SelectedValue = datos.UnidadMedida
        diseñoCajas()

    End Sub
    Private Sub cbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPais.SelectedIndexChanged
        Dim value = cbPais.SelectedValue
        If (TypeOf value Is DataRowView Or TypeOf value Is Entidades.Paises) Then Return
        llenarComboEstado(cbPais.SelectedValue)
    End Sub

    Private Sub cbestados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbestados.SelectedIndexChanged
        llenarComboCiudad(cbestados.SelectedValue)
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
    Private Sub DetallesOtrosEmbarquesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblFolioEmbarque.Text = embarqueid
        llenarAllCombos()
        cargarVistaPreviaEmbarque()
    End Sub
    Private Sub viewcajas_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwCajas.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class