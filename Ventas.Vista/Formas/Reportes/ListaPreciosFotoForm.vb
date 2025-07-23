Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraEditors.Repository
Imports System.Net
Imports Infragistics.Documents.Excel






Public Class ListaPreciosFotoForm

    Dim perfilUsuario As Integer = 0
    Dim listInicial As New List(Of String)
    Dim tipo_busqueda As New Integer
    Dim Vigencia As String = String.Empty
    Dim Temporada As String = String.Empty
    Dim msgValidaError As String = String.Empty


    Dim IdCliente As Integer
    Dim IdListaPrecioBase As Integer
    Dim idListaPrecioVenta As Integer
    Dim dtReporte As DataTable
    Dim emptyEditor As RepositoryItemPictureEdit
    Dim ruta As String = String.Empty
    Dim image As Image
    Dim StreamFoto As System.IO.Stream
    Dim objFTP As New Global.Tools.TransferenciaFTP

    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"


    Private Sub ListaPreciosFotoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Me.WindowState = 2
        Me.Top = 0
        Me.Left = 0
        LlenarComboClientes()
        llenarComboListasBase()
        cmbListaVentas.Visible = False
        cmbListaVentasCliente.Enabled = True


        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now


        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        pnPBar.Top = (Me.Height - pnPBar.Height) / 2


    End Sub


#Region "Boton Arriba-Abajo"

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 365
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub
#End Region

#Region "Mostrar Click"
    Private Sub btnColecciones_Click(sender As Object, e As EventArgs) Handles btnColecciones.Click
        Dim listado As New ListadoParametrosReportesForm

        If Not ValidaCargaVariablesForm(listado) Then
            Controles.Mensajes_Y_Alertas("ADVERTENCIA", msgValidaError)
            Exit Sub
        End If

        listado.tipo_busqueda = 2

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColecciones.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColecciones.DataSource = listado.listParametros
        With grdColecciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
        End With
    End Sub

    Private Sub btnFamilias_Click(sender As Object, e As EventArgs) Handles btnFamilias.Click
        Dim listado As New ListadoParametrosReportesForm
        If Not ValidaCargaVariablesForm(listado) Then
            Controles.Mensajes_Y_Alertas("ADVERTENCIA", msgValidaError)
            Exit Sub
        End If
        listado.tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamiliaDeVentas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamiliaDeVentas.DataSource = listado.listParametros
        With grdFamiliaDeVentas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia de Ventas"
        End With
    End Sub


    Private Sub btnArticulos_Click(sender As Object, e As EventArgs) Handles btnArticulos.Click
        Dim listado As New ListadoParametrosReportesForm
        If Not ValidaCargaVariablesForm(listado) Then
            Controles.Mensajes_Y_Alertas("ADVERTENCIA", msgValidaError)
            Exit Sub
        End If
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridArticulos.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        gridArticulos.DataSource = listado.listParametros
        With gridArticulos
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True

            '.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Articulos"
        End With
    End Sub


#End Region

#Region "Inicializar layout"
    Private Sub grdFamiliaDeVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamiliaDeVentas.InitializeLayout
        grid_diseño(grdFamiliaDeVentas)
        grdFamiliaDeVentas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia de Ventas"
    End Sub

    Private Sub grdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColecciones.InitializeLayout
        grid_diseño(grdColecciones)
        grdColecciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colecciones"
    End Sub

    Private Sub gridArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridArticulos.InitializeLayout
        grid_diseño(gridArticulos)
        gridArticulos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Articulos"
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(" ").Header.VisiblePosition = 1
            .DisplayLayout.Bands(0).Columns("cmfa_colaboradorid_agente").Hidden = True
            .DisplayLayout.Bands(0).Columns("AGENTE").CellActivation = Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("MARCA").CellActivation = Activation.NoEdit



            .DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        End With
    End Sub



#End Region

#Region "Limpiar Click"
    Private Sub btnLimpiarColecciones_Click(sender As Object, e As EventArgs) Handles btnLimpiarColecciones.Click
        grdColecciones.DataSource = listInicial
    End Sub

    Private Sub btnLimpiaFamilias_Click(sender As Object, e As EventArgs) Handles btnLimpiaFamilias.Click
        grdFamiliaDeVentas.DataSource = listInicial
    End Sub

    Private Sub btnLimpiaArticulos_Click(sender As Object, e As EventArgs) Handles btnLimpiaArticulos.Click
        gridArticulos.DataSource = listInicial
    End Sub

    Private Sub LimpiarFiltros()
        btnLimpiarColecciones_Click(Nothing, Nothing)
        btnLimpiaFamilias_Click(Nothing, Nothing)
        btnLimpiaArticulos_Click(Nothing, Nothing)
    End Sub


#End Region



    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        'For Each row In grid.Rows
        '    row.Activation = Activation.NoEdit
        'Next

        asignaFormato_Columna(grid)

    End Sub
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If
        Next
    End Sub

#Region "COMBOS"

    ''COMBO CLIENTES
    ''' <summary>
    ''' LLENA EL COMBO BOX PARA SELECCIONAR CLIENTES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LlenarComboClientes()
        Dim objCliente As New Negocios.ClientesBU
        Dim dtDatosClientes As New DataTable
        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Dim objBUEstadistico As New Negocios.EstadisticoPedidosBU
        Dim Tabla_ListadoParametros As New DataTable

        Try
            dtResultadoPerfil = objBU.reporteEstadisticaFamliasObtenerPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

            If dtResultadoPerfil.Rows.Count > 0 Then
                perfilUsuario = dtResultadoPerfil.Rows(0).Item("IdPerfil")
            End If
            If perfilUsuario <> 44 And perfilUsuario <> 74 Then
                tipo_busqueda = 2
            Else
                tipo_busqueda = 4
            End If

            If tipo_busqueda = 2 Then
                dtDatosClientes = objBUEstadistico.ListadoParametrosReportes(tipo_busqueda, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            ElseIf tipo_busqueda = 4 Then
                dtDatosClientes = objBUEstadistico.ListadoParametrosReportesClienteAgente(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
            End If

            If Not IsNothing(dtDatosClientes) Then
                If tipo_busqueda = 2 Then
                    'dtDatosClientes = objCliente.buscarClientesNombreComercial(0)
                    dtDatosClientes.Rows.InsertAt(dtDatosClientes.NewRow, 0)
                    cmbClientes.DataSource = dtDatosClientes
                    cmbClientes.DisplayMember = "Nombre"
                    cmbClientes.ValueMember = "Parametro"

                ElseIf tipo_busqueda = 4 Then
                    'dtDatosClientes = objCliente.buscarClientesNombreComercial(0)
                    dtDatosClientes.Rows.InsertAt(dtDatosClientes.NewRow, 0)
                    cmbClientes.DataSource = dtDatosClientes
                    cmbClientes.DisplayMember = "CLIENTE"
                    cmbClientes.ValueMember = "Parametro"
                End If
            End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' MANDA LLAMAR EL METODO PARA RECUPERAR LOS DATOS DEL CLIENTE SELECCIONADO, EN CASO DE NO HABER SELECCIONADO NINGUN CLIENTE, 
    ''' LIMPIARA LOS CONTROLES CON LA INFORMACION DE LOS CLIENTES.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        If cmbClientes.SelectedIndex > 0 Then
            limpiarCamposTextos()
            llenarDatosCliente()
            'txtAtn.Text = cmbClientes.Text
            'chkSeleccionarTodo.Checked = False
            'dtListaPrecioST = Nothing
            'rdoListadePrecios.Checked = True
        Else
            'dtListaPrecioST = Nothing
            'limpiarCampos()
            If Not IsNothing(cmbListaBase.DataSource) Then
                cmbListaBase.SelectedIndex = 0
            End If
            cmbListaVentasCliente.DataSource = Nothing
            cmbListaVentas.DataSource = Nothing
            ' rdoListadePrecios.Checked = True
            LimpiarFiltros()
            limpiarCamposTextos()
        End If
    End Sub

    ''' <summary>
    ''' RECUPERA LOS DATOS DEL CLIENTE SELECCIONADO EN EL COMBO BOX "CMBCLIENTE"
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub llenarDatosCliente()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbListaVentas.DataSource = Nothing
            IdCliente = CInt(cmbClientes.SelectedValue)

            Dim objClienteDatos As New Ventas.Negocios.ClientesDatosBU
            Dim objListaClt As New Ventas.Negocios.ListaPreciosVentaClienteBU

            Dim dtDatosClienteListaPreciosVentas As New DataTable
            Dim dtDatosModelos As New DataTable

            ''RECUPERAMOS LOS DATOS DEL CLIENTE
            'idListaVentasCliente = objListaClt.verListaVentasClienteActual(idCliente)
            dtDatosClienteListaPreciosVentas = objListaClt.consultaDatosClienteListaVentas(IdCliente)
            ''OBTENER DATO CLAVE SAT
            ' txtClaveSAT.Text = objListaClt.consultaClaveSATCliente(IdCliente)

            ''RAMOS
            'Tools.Controles.ComboRamosConMarcajeRegistradoPorCliente(cmbRamos, idCliente)

            'NUMERACION
            'Tools.Controles.ComboNumeracionPais(cmbNumeracion)
            'cmbNumeracion.SelectedValue = 1

            'MONEDA


            If dtDatosClienteListaPreciosVentas.Rows.Count = 0 Then
                cmbListaBase.SelectedIndex = 0
                '    Tools.Controles.ComboMonedaextranjeraMasMonedaPesos(cmbMoneda, 1)
                '    cmbMoneda.SelectedIndex = 1
            Else
                '    Tools.Controles.ComboMonedaextranjeraMasMonedaPesos(cmbMoneda, dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_monedaid"))
                '    cmbMoneda.SelectedValue = dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_monedaid")
            End If

            If dtDatosClienteListaPreciosVentas.Rows.Count > 0 Then
                lblMensajeSinListaVentas.Visible = False


                'PARIDAD
                'If dtDatosClienteListaPreciosVentas.Rows(0).Item("mone_nombre").ToString.Trim <> "PESOS" Then
                '    gboxParidad.Visible = True

                '    Dim dtParidadMoneda As New DataTable
                '    dtParidadMoneda = Recuperar_Paridad_Moneda(dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_monedaid"))

                '    If dtParidadMoneda.Rows.Count = 0 Then
                '        lblParidadFecha.Text = ""
                '        lblParidadMonedaValor.Text = "PESOS"
                '        lblParidadIgual.Text = "$ 1 = $ 1.00"
                '        ParidadHOy = 1
                '    Else
                '        For Each row As DataRow In dtParidadMoneda.Rows
                '            Dim pesos As Double = CStr(row.Item(3))
                '            Paridad = pesos
                '            lblParidadMonedaValor.Text = (row.Item(1))
                '            lblParidadFecha.Text = (row.Item(4))
                '            lblParidadIgual.Text = "1 " + (row.Item(2)) + " = $ " + pesos.ToString("0,0.00", CultureInfo.InvariantCulture)
                '            ParidadHOy = CDbl(row.Item(3))
                '        Next
                '    End If
                'Else
                '    Paridad = 1
                '    gboxParidad.Visible = False
                'End If
                grdReporte.DataSource = Nothing

                'If IsDBNull(dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_calcularpreciocondescuento")) Then
                '    chkDescuentoAplicado.Checked = False
                'Else
                '    chkDescuentoAplicado.Checked = dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_calcularpreciocondescuento")
                'End If


                IdListaPrecioBase = dtDatosClienteListaPreciosVentas.Rows(0).Item("lpba_listapreciosbaseid")
                cmbListaBase.SelectedValue = IdListaPrecioBase
                llenarComboListaVentas(IdListaPrecioBase)
                idListaPrecioVenta = dtDatosClienteListaPreciosVentas.Rows(0).Item("lpvt_listaprecioventaid")
                cmbListaVentas.SelectedValue = dtDatosClienteListaPreciosVentas.Rows(0).Item("lpvt_listaprecioventaid")
                lblListaVentas.Text = cmbListaVentas.Text

            Else
                lblMensajeSinListaVentas.Visible = True
                lblMensajeSinListaVentas.Text = " El cliente no tiene asignada una lista de ventas"
                'chkDescuentoAplicado.Checked = False
                'gboxParidad.Visible = False
                grdReporte.DataSource = Nothing
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'idListaVentasCliente = 0
            grdReporte.DataSource = Nothing
            lblMensajeSinListaVentas.Visible = True

            Dim objError As New ErroresForm
            objError.mensaje = "Ocurrio un error insepesrado. Error: " + ex.Message
            objError.StartPosition = FormStartPosition.CenterScreen
            objError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    ''COMBO "LISTA BASE"

    Public Sub llenarComboListasBase()
        Dim objLPVC As New Negocios.ListaBaseBU
        Dim dtDatosListaPrecios As New DataTable
        dtDatosListaPrecios = objLPVC.RecuperarListasBaseExistentes
        Dim newRow As DataRow = dtDatosListaPrecios.NewRow
        dtDatosListaPrecios.Rows.InsertAt(newRow, 0)
        cmbListaBase.DataSource = dtDatosListaPrecios
        cmbListaBase.DisplayMember = "LISTABASE"
        cmbListaBase.ValueMember = "lpba_listapreciosbaseid"
        cmbListaBase.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' LLENA EL COMBO LISTA DE VENTAS EN CASO DE QUE EL COMBO LISTA BASE TENGA UNA LISTA SELECCIONADA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbListaBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaBase.SelectedIndexChanged
        cmbListaVentas.DataSource = Nothing
        lblListaVentas.Text = "--"
        If cmbListaBase.SelectedIndex > 0 And cmbClientes.SelectedIndex > 0 Then
            llenarComboListaVentas(cmbListaBase.SelectedValue)
        Else
            cmbListaVentas.DataSource = Nothing
            cmbListaVentas.Items.Clear()
            lblListaVentas.Text = "--"
        End If
    End Sub

    ''COMBO  "ListaVentas"
    Public Sub llenarComboListaVentas(ByVal idListaBase As Int32)
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosListaVentas As New DataTable
        ' ''dtDatosListaVentas = objLVC.verListaVentasConsultaSimple(idListaBase)

        dtDatosListaVentas = objLVC.consultaListaVentas(idListaBase, cmbClientes.SelectedValue)
        If dtDatosListaVentas.Rows.Count > 0 Then
            dtDatosListaVentas.Rows.InsertAt(dtDatosListaVentas.NewRow, 0)
            cmbListaVentas.DataSource = dtDatosListaVentas
            cmbListaVentas.DisplayMember = "LISTAVENTAS"
            cmbListaVentas.ValueMember = "lpvt_listaprecioventaid"

            cmbListaVentas.SelectedIndex = 1
            lblListaVentas.Text = cmbListaVentas.Text
            'idListaCliente = dtDatosListaVentas.Rows(0).Item("lvcl_listaventasclienteid").ToString
            'verModelosListaPrecioCliente(idListaCliente)
            lblMensajeSinListaVentas.Visible = False
        Else
            cmbListaVentas.DataSource = Nothing
            grdReporte.DataSource = Nothing
            lblListaVentas.Text = "--"
            lblFechaInicioLista_Dato.Text = ""
            lblFechaFinListaDato.Text = ""

            lblMensajeSinListaVentas.Visible = True
            lblMensajeSinListaVentas.Text = " El cliente no tiene asignada una lista de ventas"
            'verModelosListaPrecioCliente(0)
        End If
    End Sub

    ''COME LISTAVENTASCLIENTEPRECIO
    Public Sub llenarComboListaVentasClientePrecio(ByVal idlistaventas As Integer)
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosListaVentas As New DataTable
        ' ''dtDatosListaVentas = objLVC.verListaVentasConsultaSimple(idListaBase)

        dtDatosListaVentas = objLVC.consultaListaVentasClientePrecio(idlistaventas, cmbClientes.SelectedValue)
        If dtDatosListaVentas.Rows.Count > 0 Then
            dtDatosListaVentas.Rows.InsertAt(dtDatosListaVentas.NewRow, 0)
            cmbListaVentasCliente.DataSource = dtDatosListaVentas
            cmbListaVentasCliente.ValueMember = "ID_LVClientePrecio"
            cmbListaVentasCliente.DisplayMember = "NOMBRE"
            cmbListaVentasCliente.SelectedIndex = 0
            'idListaCliente = dtDatosListaVentas.Rows(0).Item("lvcl_listaventasclienteid").ToString
            'verModelosListaPrecioCliente(idListaCliente)

            cmbListaVentasCliente.SelectedIndex = 1

            lblMensajeSinListaVentas.Visible = False
        Else
            cmbListaVentasCliente.DataSource = Nothing
            grdReporte.DataSource = Nothing

            lblMensajeSinListaVentas.Visible = True
            lblMensajeSinListaVentas.Text = " El cliente no tiene lista de precios"

        End If
    End Sub

    Private Sub cmbListaVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentas.SelectedIndexChanged
        If cmbListaVentas.SelectedIndex > 0 Then
            llenarComboListaVentasClientePrecio(cmbListaVentas.SelectedValue)
        Else
            cmbListaVentasCliente.DataSource = Nothing
            cmbListaVentasCliente.Items.Clear()
        End If
    End Sub


    Private Sub cmbListaVentasCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentasCliente.SelectedIndexChanged
        If cmbListaVentasCliente.SelectedIndex > 0 Then
            recuperarValoresDeListaVentaClientePrecio(cmbListaVentasCliente.SelectedValue)
            PoblarGridAgentes(IdCliente, cmbListaVentasCliente.SelectedValue)
        Else
            grdAgentes.DataSource = Nothing
            chkSeleccionarTodo.Checked = False
            lblListaVentas.Text = "--"
            lblFechaInicioLista_Dato.Text = ""
            lblFechaFinListaDato.Text = ""

        End If
    End Sub

#End Region

    Private Sub recuperarValoresDeListaVentaClientePrecio(ByVal IdListaPrecioVentaCliente As Integer)
        Dim objListaBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtLista As New DataTable
        Dim FechaInicio As Date
        Dim FechaFin As Date

        dtLista = objListaBU.recuperarValoresDeListaVentaClientePrecio(IdListaPrecioVentaCliente)

        FechaInicio = dtLista.Rows(0).Item("lvcp_vigenciainicio")
        FechaFin = dtLista.Rows(0).Item("lvcp_vigenciafin")

        lblFechaInicioLista_Dato.Text = FechaInicio.ToShortDateString
        lblFechaFinListaDato.Text = FechaFin.ToShortDateString
        If cmbListaVentas.SelectedValue > 0 Then
            lblListaVentas.Text = cmbListaVentas.Text
        End If


    End Sub



    Public Sub PoblarGridAgentes(ByVal Id_Cliente As Integer, ByVal IdListaVentaClientePrecio As Integer)
        Dim objClienteDatos As New Ventas.Negocios.ClientesDatosBU
        Dim dtAgentes As New DataTable
        Dim conlista As Boolean = True
        'If RadioButton1.Checked = True Or rdoModelaje.Checked = True Then
        '    conlista = True
        'Else
        '    conlista = False
        'End If

        Dim marcaConsAgente As Int32 = 0
        If IdCliente = 816 Then
            marcaConsAgente = 1
        Else
            marcaConsAgente = 7
        End If

        'dtAgentes = objClienteDatos.AgenteClienteMarcasListaPrecios(Id_Cliente, IdListaVentaClientePrecio, conlista, marcaConsAgente, IdListaPrecioBase)

        dtAgentes = objClienteDatos.FiltroMarcaAgente(IdCliente, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Dim columns As DataColumnCollection = dtAgentes.Columns
        Dim columna0 As New DataColumn
        columna0.DataType = Type.GetType("System.Boolean")
        columna0.DefaultValue = False
        columna0.ColumnName = " "
        columns.Add(columna0)
        For Each row As DataRow In dtAgentes.Rows
            row.Item(" ") = 0
        Next
        If dtAgentes.Rows.Count > 0 Then
            grdAgentes.DataSource = dtAgentes
            grdAgentes.DisplayLayout.Bands(0).Columns("cmfa_marcaid").Hidden = True
            grdAgentes.DisplayLayout.Bands(0).Columns("MarcaIDAgenteID").Hidden = True
        Else
            chkSeleccionarTodo.Checked = False
            grdAgentes.DataSource = Nothing
        End If

    End Sub


    Public Sub limpiarCamposTextos()

        ''VARIABLES
        IdCliente = 0
        IdListaPrecioBase = 0
        idListaPrecioVenta = 0
        'IdListaPrecioCliente = 0
        ''LISTA PRECIO(LISTA CLIENTE)
        lblFechaInicioLista_Dato.Text = ""
        lblFechaFinListaDato.Text = ""

        lblListaVentas.Text = "--"


        ''GRID
        grdReporte.DataSource = Nothing
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()


        ''MENSAJE DE ALERTA DE LISTA DE VENTAS ASIGNADA
        lblMensajeSinListaVentas.Visible = False

        ''FILTROS
        chkSeleccionarTodo.Checked = False
        grdAgentes.DataSource = Nothing
        LimpiarFiltros()

    End Sub


    Private Function ValidaCargaVariablesForm(ByVal form As ListadoParametrosReportesForm) As Boolean
        Dim cadenaMarcasAgentes As String = String.Empty
        Dim resultado As Boolean = True

        msgValidaError = String.Empty

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                cadenaMarcasAgentes += row.Cells("MarcaIDAgenteID").Value.ToString.trim + ","
            End If
        Next

        If cadenaMarcasAgentes.Length > 0 Then
            cadenaMarcasAgentes = cadenaMarcasAgentes.Remove(cadenaMarcasAgentes.Length - 1, 1)

        Else
            msgValidaError = "Es necesario seleccionar al menos una Marca-Agente."
            Return False

        End If
        If cmbListaVentasCliente.SelectedValue <= 0 Then
            msgValidaError = "Es necesario seleccionar al menos una lista de precios."
            Return False
        End If
        If cmbClientes.SelectedValue <= 0 Then
            msgValidaError = "Es necesario seleccionar al menos un cliente."
            Return False
        End If

        form.ListaPrecios = True
        form.ClienteID = cmbClientes.SelectedValue
        form.ListaPrecioClienteID = cmbListaVentasCliente.SelectedValue
        form.MarcasAgenteID = cadenaMarcasAgentes

        Return resultado

    End Function

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click



        Dim cadenaMarcasAgentes As String = String.Empty
        Dim cadenaColleccion As String = String.Empty
        Dim cadenaFamilias As String = String.Empty
        Dim cadenaProductoEstilo As String = String.Empty

        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU


        Try

            Me.Cursor = Cursors.WaitCursor

            For Each row As UltraGridRow In grdAgentes.Rows
                If row.Cells(" ").Value = True Then
                    cadenaMarcasAgentes += row.Cells("MarcaIDAgenteID").Value.ToString.Trim + ","
                End If
            Next

            For Each row As UltraGridRow In grdColecciones.Rows
                If row.Cells(" ").Value = True Then
                    cadenaColleccion += row.Cells("ColeccionMarcaID").Value.ToString.Trim + ","
                End If
            Next

            For Each row As UltraGridRow In grdFamiliaDeVentas.Rows
                If row.Cells(" ").Value = True Then
                    cadenaFamilias += row.Cells("cmfa_familiaproyeccionid").Value.ToString.Trim + ","
                End If
            Next

            For Each row As UltraGridRow In gridArticulos.Rows
                If row.Cells(" ").Value = True Then
                    cadenaProductoEstilo += row.Cells("ProductoEstiloID").Value.ToString.Trim + ","
                End If
            Next

            If cadenaColleccion.Length > 0 Then
                cadenaColleccion = cadenaColleccion.Remove(cadenaColleccion.Length - 1, 1)
            End If

            If cadenaFamilias.Length > 0 Then
                cadenaFamilias = cadenaFamilias.Remove(cadenaFamilias.Length - 1, 1)
            End If

            If cadenaProductoEstilo.Length > 0 Then
                cadenaProductoEstilo = cadenaProductoEstilo.Remove(cadenaProductoEstilo.Length - 1, 1)
            End If


            If cadenaMarcasAgentes.Length > 0 Then
                cadenaMarcasAgentes = cadenaMarcasAgentes.Remove(cadenaMarcasAgentes.Length - 1, 1)
            Else
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario seleccionar al menos una Marca-Agente.")
                Exit Sub
            End If
            If cmbListaVentasCliente.SelectedValue <= 0 Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario seleccionar al menos una lista de precios.")
                Exit Sub
            End If
            If cmbClientes.SelectedValue <= 0 Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario seleccionar al menos un cliente.")
                Exit Sub
            End If
            If CDate(dtpFechaInicio.Value.ToShortDateString) > CDate(dtpFechaFin.Value.ToShortDateString) Then
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial de pedidos capturados no puede ser mayor a la fecha final.")
                dtpFechaInicio.Focus()
                Exit Sub
            End If



            Dim tipoFiltro As Integer

            If rdbListaCompleta.Checked Then
                tipoFiltro = 1
            ElseIf rdbListaCapturada.Checked Then
                tipoFiltro = 2
            End If


            'grdReporte.DataSource = Nothing
            bgvReporte.Bands.Clear()
            bgvReporte.Columns.Clear()

            Cursor = Cursors.WaitCursor
            pnPBar.Visible = True
            lblInfo.Text = "Ejecutando consulta, espere un momento por favor..."
            pBar.Minimum = 0
            pBar.ForeColor = Color.Blue
            System.Windows.Forms.Application.DoEvents()


            dtReporte = objLVC.ListaPrecioFoto(cmbClientes.SelectedValue, cmbListaVentasCliente.SelectedValue, tipoFiltro, dtpFechaInicio.Value, dtpFechaFin.Value, cadenaMarcasAgentes, cadenaColleccion, cadenaFamilias, cadenaProductoEstilo)


            If Not IsNothing(dtReporte) Then
                If dtReporte.Rows.Count > 0 Then
                    dtReporte.Columns.Add("Foto", GetType(Image))
                    Dim Total As Integer = dtReporte.Rows.Count
                    Dim Cont As Integer = 0

                    pBar.Maximum = Total

                    lblInfo.Text = "Descargando imágenes...."
                    System.Windows.Forms.Application.DoEvents()
                    For Each row As DataRow In dtReporte.Rows
                        ruta = IIf(IsDBNull(row.Item("FOTOMODELO")), "", row.Item("FOTOMODELO").ToString.Trim())
                        If ruta.Length > 0 Then
                            Try
                                Image = Nothing
                                StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                                Image = System.Drawing.Image.FromStream(StreamFoto)
                                row.Item("Foto") = image
                            Catch ex As Exception
                                Try
                                    Image = Nothing
                                    StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                                    Image = System.Drawing.Image.FromStream(StreamFoto)
                                    row.Item("Foto") = image
                                Catch exe As Exception

                                End Try
                            End Try
                        Else
                            row.Item("Foto") = Nothing
                        End If
                        Cont += 1
                        pBar.Value = Cont
                    Next
                    System.Windows.Forms.Application.DoEvents()
                    diseñoGridResultado()
                    grdReporte.DataSource = dtReporte
                    btnArriba_Click(Nothing, Nothing)
                    System.Windows.Forms.Application.DoEvents()

                Else
                    Tools.Controles.Mensajes_Y_Alertas("INFORMACION", "No se encontraron datos con los filtros seleccionados.")
                End If
            Else

                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "No se encontraron datos con los filtros seleccionados.")
            End If


        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            pBar.Value = pBar.Minimum
            pnPBar.Visible = False
            request = Nothing
            StreamFoto = Nothing
            image = Nothing
        End Try

    End Sub

    Private Sub grdColecciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColecciones.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFamiliaDeVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamiliaDeVentas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub gridArticulos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles gridArticulos.BeforeRowsDeleted
        e.DisplayPromptMsg = False

    End Sub

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub diseñoGridResultado()
        Dim objBu As New Negocios.SeguimientoVentasBU

        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listBandsMarcas As New List(Of String)

        bgvReporte.OptionsView.AllowCellMerge = False
        bgvReporte.OptionsView.ColumnAutoWidth = True
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre
        Dim ListaPrimerBanda As New List(Of String)
        ListaPrimerBanda.Add("FechaActualizacion")
        Dim cadenas As String = ""

        For Each item As String In ListaPrimerBanda

            'listBandsTextos.Add(item.Trim())
            band = bgvReporte.Bands.Add
            band.AppearanceHeader.Options.UseBackColor = True
            'band.AppearanceHeader.BackColor = Color.RoyalBlue
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If item = "FechaActualizacion" Then
                band.Caption = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
            End If
            listBands.Add(band)
        Next

        'vwInventarioNave.Columns.ColumnByFieldName("Pares terminados").DisplayFormat.FormatString = "N0"
        Dim Contador As Int16 = 0
        Dim Foto As Int16 = dtReporte.Columns.IndexOf("Foto")
        Dim value As Object = 1

        For Each Columna As DataColumn In dtReporte.Columns
            If Contador = 0 Then
                bgvReporte.Columns.AddField((Columna.ColumnName).ToString())
                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).OwnerBand = listBands(0)
                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                'bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).AppearanceHeader.BackColor = Color.RoyalBlue
            End If
            Contador += 1
        Next
        Contador = 0
        For Each Columna As DataColumn In dtReporte.Columns
            If Contador = Foto Then
                bgvReporte.Columns.AddField((Columna.ColumnName).ToString())
                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).OwnerBand = listBands(0)
                bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                'bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).AppearanceHeader.BackColor = Color.RoyalBlue
            End If
            Contador += 1
        Next
        Contador = 0
        For Each Columna As DataColumn In dtReporte.Columns
            If (TypeOf value Is Integer) Then
                Select Case value
                    Case 1

                        If Contador = 1 Or Contador = 2 Then
                            bgvReporte.Columns.AddField((Columna.ColumnName).ToString())
                            bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).OwnerBand = listBands(0)
                            bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = False
                            bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                            ' bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).AppearanceHeader.BackColor = Color.RoyalBlue
                        ElseIf Contador > 2 And Contador <> Foto Then
                            bgvReporte.Columns.AddField((Columna.ColumnName).ToString())
                            bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).OwnerBand = listBands(0)
                            bgvReporte.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                            bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                            ' bgvReporte.Columns.ColumnByFieldName(Columna.ColumnName).AppearanceHeader.BackColor = Color.RoyalBlue
                        End If

                        Contador += 1
                End Select
            End If
        Next
        bgvReporte.ColumnPanelRowHeight = 30
        bgvReporte.RowHeight = 50
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(bgvReporte)
        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            If Col.FieldName = "#" Then
                Col.Width = 40
            End If
        Next
    End Sub
    Private Sub bgvReporte_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles bgvReporte.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "Foto" Then
                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = bgvReporte.GetRowCellValue(e.RowHandle, "FotoModelo")
                MostrarFoto.Marca = bgvReporte.GetRowCellValue(e.RowHandle, "Marca")
                MostrarFoto.Coleccion = bgvReporte.GetRowCellValue(e.RowHandle, "Colección")
                MostrarFoto.ModeloSicy = bgvReporte.GetRowCellValue(e.RowHandle, "Modelo")
                'MostrarFoto.ModleoSay = bgvReporte.GetRowCellValue(e.RowHandle, "ModeloSay")
                'MostrarFoto.Talla = bgvReporte.GetRowCellValue(e.RowHandle, "Corrida")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        bgvReporte.Bands.Clear()
        bgvReporte.Columns.Clear()
        'dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        'dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        cmbClientes.SelectedIndex = 0
        lblFechaUltimaActualización.Text = "-"
        btnAbajo_Click(sender, e)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReporte.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU
            Dim options = New XlsxExportOptionsEx()
            'Dim options As New DevExpress.XtraPrinting.XlsxExportOptions
            Try



                nombreReporte = "\Lista_Precios"
                nombreReporteParaExportacion = "LISTA DE PRECIOS"
                options.SheetName = "Hoja1"


                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvReporte.GroupCount > 0 Then
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", options)
                            'grdReporte.ExportToXlsx()

                        End If

                        Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        'objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If

                End With
            Catch ex As Exception
                Controles.Mensajes_Y_Alertas("ERROR", ex.Message.ToString())
            End Try
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar.")
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        For Each row As UltraGridRow In grdAgentes.Rows
            row.Cells(" ").Value = chkSeleccionarTodo.Checked
        Next
    End Sub

    Private Sub btnExportarConFoto_Click(sender As Object, e As EventArgs) Handles btnExportarConFoto.Click


        If bgvReporte.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    ' Folder = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + (txtNombreCliente.Text) + (txtTemporada.Text).ToUpper + (txtVigencia.Text).ToUpper + ".xls"

                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    worksheet.Columns.Item(0).Width = 1825
                    worksheet.Columns.Item(1).Width = 3650
                    worksheet.Columns.Item(2).Width = 2920
                    worksheet.Columns.Item(3).Width = 9125
                    worksheet.Columns.Item(4).Width = 2555
                    worksheet.Columns.Item(5).Width = 5840
                    worksheet.Columns.Item(6).Width = 5110
                    worksheet.Columns.Item(7).Width = 2555
                    worksheet.Columns.Item(8).Width = 6205
                    worksheet.Columns.Item(9).Width = 5475
                    worksheet.Columns.Item(10).Width = 2190
                    worksheet.Columns.Item(11).Width = 8030

                    worksheet.Rows.Item(0).Cells.Item(5).Value = "LISTA DE PRECIOS PARA CONFIRMACION DE MODELAJE"
                    For i As Int16 = 0 To 1 Step 1
                        For j As Int16 = 0 To 11 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.RoyalBlue)
                        Next
                    Next

                    worksheet.Rows(0).Cells(0).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center


                    RecuperarInformacion_ListaDeCliente()

                    worksheet.Rows.Item(2).Cells.Item(0).Value = "CLIENTE"
                    worksheet.Rows.Item(3).Cells.Item(0).Value = "TEMPORADA"
                    worksheet.Rows.Item(4).Cells.Item(0).Value = "VIGENCIA DE COSTOS"
                    worksheet.Rows.Item(2).Cells.Item(3).Value = cmbClientes.Text.ToUpper
                    worksheet.Rows.Item(3).Cells.Item(3).Value = (cmbListaVentasCliente.Text).ToUpper
                    worksheet.Rows.Item(4).Cells.Item(3).Value = "DEL " + lblFechaInicioLista_Dato.Text.ToString.Trim + " AL " + lblFechaFinListaDato.Text.ToString.Trim

                    For i As Int16 = 2 To 4 Step 1
                        For j As Int16 = 3 To 3 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next


                    For i As Int16 = 2 To 4 Step 1
                        For j As Int16 = 0 To 2 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next

                    worksheet.Rows.Item(3).Cells.Item(11).Value = "Fecha de impresión:"
                    worksheet.Rows.Item(4).Cells.Item(11).Value = DateTime.Now

                    For i As Int16 = 3 To 4 Step 1
                        For j As Int16 = 11 To 11 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        Next
                    Next

                    worksheet.Rows.Item(5).Cells.Item(3).Value = "Este precio aplica para pedidos cuya fecha de entrega indicada por Grupo Yuyin sea menor o igual al " + lblFechaFinListaDato.Text

                    worksheet.Rows.Item(5).Cells.Item(3).CellFormat.Font.Italic = ExcelDefaultableBoolean.True


                    Dim objListaClienteBU As New Negocios.ListaPreciosVentaClienteBU
                    Dim dtGridDescuentos As New DataTable
                    dtGridDescuentos = objListaClienteBU.RecuperarDescuentosDelCliente(cmbClientes.SelectedValue)

                    If Not IsNothing(dtGridDescuentos) Then
                        If dtGridDescuentos.Rows.Count > 0 Then
                            '____________________________________________________________________________________________________________________
                            '---PASAMOS LOS DATOS DEL GRID DESCUENTOS
                            '____________________________________________________________________________________________________________________

                            'EXPORTAMOS LOS DATOS DE LAS COLUMNAS
                            For c As Integer = 0 To dtGridDescuentos.Columns.Count - 1 'grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                                If c > 0 Then
                                    worksheet.Rows.Item(2).Cells.Item(c + 7).Value = dtGridDescuentos.Columns(c).ColumnName.ToString.ToUpper 'grdDescuentos.DisplayLayout.Bands(0).Columns(c).Header.Caption
                                Else
                                    worksheet.Rows.Item(2).Cells.Item(c + 6).Value = dtGridDescuentos.Columns(c).ColumnName.ToString.ToUpper
                                End If
                            Next

                        End If

                    End If

                    For i As Int16 = 2 To 2 Step 1
                        For j As Int16 = 6 To 9 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                            If j = 6 Then
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Right
                            Else
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            End If
                        Next
                    Next

                    For i = 3 To dtGridDescuentos.Rows.Count + 2 Step 1
                        For j = 6 To 7 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        Next
                    Next

                    For f As Integer = 0 To dtGridDescuentos.Rows.Count - 1
                        For cc As Integer = 0 To dtGridDescuentos.Columns.Count - 1 'grdDescuentos.DisplayLayout.Bands(0).Columns.Count - 1
                            If cc > 0 Then
                                worksheet.Rows.Item(f + 3).Cells.Item(cc + 7).Value = dtGridDescuentos.Rows(f).Item(cc) 'grdDescuentos.Rows(f).Cells(cc).Value
                            Else
                                worksheet.Rows.Item(f + 3).Cells.Item(cc + 6).Value = dtGridDescuentos.Rows(f).Item(cc)
                            End If
                        Next
                    Next

                    For i As Int16 = 3 To (dtGridDescuentos.Rows.Count) + 2 Step 1
                        For j As Int16 = 8 To 9 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    '____________________________________________________________________________________________________________________
                    '---PASAMOS LOS DATOS DEL GRID CATALOGO
                    '____________________________________________________________________________________________________________________

                    Dim inicio As Integer = 7

                    worksheet.Rows.Item(inicio).Cells.Item(0).Value = bgvReporte.Columns(0).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(1).Value = bgvReporte.Columns(1).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(2).Value = bgvReporte.Columns(4).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(3).Value = bgvReporte.Columns(5).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(4).Value = bgvReporte.Columns(6).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(5).Value = bgvReporte.Columns(7).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(6).Value = bgvReporte.Columns(8).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(7).Value = bgvReporte.Columns(9).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(8).Value = bgvReporte.Columns(10).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(9).Value = bgvReporte.Columns(11).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(10).Value = bgvReporte.Columns(12).FieldName.ToString()
                    worksheet.Rows.Item(inicio).Cells.Item(11).Value = bgvReporte.Columns(13).FieldName.ToString()

                    For i As Int16 = inicio To inicio Step 1
                        For j As Int16 = 0 To 11 Step 1
                            worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.RoyalBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.White)
                        Next
                    Next

                    For r As Integer = (0) To bgvReporte.RowCount - 1 'grdCatalogo.Rows.Count - 1
                        worksheet.Rows.Item(r + inicio + 1).Height = 1505

                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(0).FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(4).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(5).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(6).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(7).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(8).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(9).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(10).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(11).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(12).FieldName.ToString())
                        worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString())

                        If Not IsDBNull(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString())) Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then
                            Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                        New Infragistics.Documents.Excel.WorksheetImage(bgvReporte.GetRowCellValue(r, bgvReporte.Columns(1).FieldName.ToString()))

                            Dim Ancho As Double = imageShape.Image.Width
                            Dim alto As Double = imageShape.Image.Height

                            If imageShape.Image.Width > imageShape.Image.Height Then
                                alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                            Else
                                Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                            End If

                            ' The top-left corner of the image should be at the 
                            ' top-left corner of cell A1
                            imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                            imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                            ' The bottom-right corner of the image should be at 
                            ' the bottom-right corner of cell A1
                            imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                            imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                            worksheet.Shapes.Add(imageShape)
                        End If
                    Next


                    For i As Int16 = 0 To bgvReporte.RowCount - 1 Step 1
                        For j As Int16 = 0 To 11 Step 1

                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        Next
                    Next

                    For r As Integer = (0) To bgvReporte.RowCount - 1
                        worksheet.Rows.Item(r + inicio + 1).Height = 1145
                    Next
                    workbook.Save(fileName)



                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)
                Catch ex As Exception
                    Dim objMensajeError As New ErroresForm
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.mensaje = ex.Message
                    objMensajeError.ShowDialog()
                End Try

            End If
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar.")
        End If


    End Sub

    Private Sub RecuperarInformacion_ListaDeCliente()
        Dim objListaClienteBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtInformacion As New DataTable
        Try
            dtInformacion = objListaClienteBU.RecuperarInformacion_ListaDeCliente(cmbClientes.SelectedValue, cmbListaVentasCliente.SelectedValue)
            For Each row As DataRow In dtInformacion.Rows
                If IsDBNull(row.Item(0)) Then
                Else
                    Temporada = row.Item(0)
                End If
                Vigencia = row.Item(1)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class