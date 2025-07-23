Imports Infragistics.Win.UltraWinDock
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Globalization
Imports Tools
Imports System.IO


Public Class AltaInventarioCiclicoForm
    Dim CamposVacios As Boolean
    Public IdOperador, Totalpares, Tpares, Tatados, Terroneos, IdInventarioCiclico, EstadoInventario, faltantes, encontrados, sobrantes As Integer
    Public Descripcion As String
    Dim dtTablaGeneralDescripcion As New DataTable
    Dim LenCadenaCombo As Integer = 0
    Public lPares, lAtados, lProductos, lClientes, lPedidos, lCorrida, lLote, AnioLote, lBahia, lNave, lPedidoOrigen, lColaborador, lAgente, lDescripcionBahia As String
    Public fechaInicio, fechaTermino, lColeccion, IdMarca, IdColeccion, IdTienda, nave_almacen As String
    Public bY_O, mostrar_todo, FechaSi_No As Boolean
    Public Editar As Boolean = False
    Public SoloConsulta As Boolean = False
    Public ResultadoDeInventario As Boolean = False
    Public dtGrid As DataTable
    Private NCliente, NAgente, NTienda, NProducto, NBahia, NCorrida, NMarca, NColeccion, NOperador As String
    'variables para agregar detalles al inventario con la colectora
    Public par_Atado As String = ""
    Dim estiba, estibaid As String
    Dim par_valido As Boolean = False
    Dim estibaValida As Boolean = False
    Dim IdOperadorLectora As String
    Dim Codigo As String
    Dim CodigoPar As String
    Dim arrCodigosErrores As New ArrayList
    Dim arrArchivoSinRepetidos As New ArrayList
    Dim arrParesDeAtato As New ArrayList
    Public dobleclick As Boolean = False




    Private Sub AltaInventarioCiclicoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.WaitCursor
        Tools.Controles.ComboOperadoresAlmacen(cmbOperador)
        verificarAgregarEditarResultado()
        Me.Cursor = Cursors.Default

        If ResultadoDeInventario = True Then
            pnlTotales.Visible = False
            pnlLocalizado.Visible = False
            pnlCantidadesInventarioFinalizado.Visible = True
            pnlEstadoPar.Visible = True
            pnlCantidadesInventarioFinalizado.Width = 717
        End If


        If LTrim(RTrim(par_Atado)) = "A" Then
            rdoAtado.Checked = True
        Else
            rdoPar.Checked = True
        End If
        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' VERIFICA SÍ EL INVENTARIOCICLICO ESTA EN ESTADO 1 PARA MOSTRAR LOS BOTONES QUE PÉRMITEN REALIZAR MODIFICAIONES A UN INVENTARIO CÍCLICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub VerificarPermisoDeEdicion()
        If EstadoInventario > 1 Then
            btnCancelar.Visible = False
            btnGuardarInventarioCiclico.Visible = False
            lblGuardar.Visible = False
            lblCancelar.Visible = False
            rdoAtado.Enabled = False
            rdoPar.Enabled = False
            txtDescripcion.Text = Descripcion
            txtDescripcion.Enabled = False
            cmbOperador.SelectedValue = IdOperador
            cmbOperador.Enabled = False
            dtpFechaEjecucion.Text = fechaInicio
            dtpFechaEjecucion.Enabled = False
            Me.Text = "Inventario Cíclico"
            'If EstadoInventario = 2 Then
            '    btnCargarLectura.Visible = True
            '    lblCargarArchivo.Visible = True
            '    btnGuardarInventarioCiclico.Visible = True
            '    lblGuardar.Visible = True
            '    lblGuardar.Text = "Finalizar"
            '    pnlTotales.Visible = False
            '    pnlCantidadesInventarioFinalizado.Visible = True
            '    CargarTotalParesInventarioEnProceso()
            'End If
        Else
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_CALIDAD_INVENTARIOCICLICO", "VER_BOTON_CICLICO") Then
                If dobleclick = False Then
                    btnCancelar.Visible = True
                    lblCancelar.Visible = True
                    txtDescripcion.Text = Descripcion
                    cmbOperador.SelectedValue = IdOperador
                    dtpFechaEjecucion.Text = fechaInicio
                    Me.Text = "Editar Inventario Cíclico"
                Else
                    btnCancelar.Visible = False
                    lblCancelar.Visible = False
                    btnGuardarInventarioCiclico.Visible = False
                    lblGuardar.Visible = False
                    txtDescripcion.Text = Descripcion
                    txtDescripcion.Enabled = False
                    cmbOperador.SelectedValue = IdOperador
                    cmbOperador.Enabled = False
                    dtpFechaEjecucion.Text = fechaInicio
                    dtpFechaEjecucion.Enabled = False
                    Me.Text = "Inventario Cíclico"
                End If
            Else
                btnCancelar.Visible = False
                lblCancelar.Visible = False
                btnGuardarInventarioCiclico.Visible = False
                lblGuardar.Visible = False
                txtDescripcion.Text = Descripcion
                txtDescripcion.Enabled = False
                cmbOperador.SelectedValue = IdOperador
                cmbOperador.Enabled = False
                dtpFechaEjecucion.Text = fechaInicio
                dtpFechaEjecucion.Enabled = False
                Me.Text = "Inventario Cíclico"
            End If
            End If
    End Sub

    ''' <summary>
    ''' VERIFICA SI LA VENTANA SE ABRIO PARA AGREGAR UN NUEVO INVENTARIO CÍCLCICO Ó PARA EDITAR ALGUN INVENTARIO CÍCLICO O PARA CONSULTAR UN 
    ''' RESULTADO DE INVENTARIO CÍCLICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub verificarAgregarEditarResultado()
        If Editar = True Then
            VerificarPermisoDeEdicion()
            If EstadoInventario = 2 Then
                pnlRojo.Visible = True
                pnlVerde.Visible = True
                btnCargarLectura.Visible = True
                lblCargarArchivo.Visible = True
                btnGuardarInventarioCiclico.Visible = True
                lblGuardar.Visible = True
                lblGuardar.Text = "Finalizar"
                pnlTotales.Visible = False
                pnlCantidadesInventarioFinalizado.Visible = True
                PoblarGridCiterioDeFiltros()
                PoblarGridParesInventarioConcluido()
                CargarTotalParesInventarioEnProceso()
            Else
                PoblarGridCiterioDeFiltros()
                poblarGridPares()
                ContarTotalParesYAtados()
            End If

        ElseIf ResultadoDeInventario = True Then
            VerificarPermisoDeEdicion()
            PoblarGridCiterioDeFiltros()
            PoblarGridParesInventarioConcluido()
            ContarTotalParesYAtados()

        Else
            btnCancelar.Visible = False
            lblCancelar.Visible = False
            GrdInventariosCiclicos.DataSource = dtGrid
            ContarTotalParesYAtados()
            llenarGridDescripcion()
        End If
    End Sub

#Region "POBLAR GRIDS"

    ''' <summary>
    ''' RECUPERA LA INFORMACIÓN DE LOS CRITERIOS TOMADOS EN CUENTA PARA LEVANTAR UN INVENTARIO CÍCLICO EN ESPECIFICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PoblarGridCiterioDeFiltros()
        grdCriterioDeFiltros.DataSource = Nothing
        Dim objBU As New Negocios.InventarioCiclicoBU
        grdCriterioDeFiltros.DataSource = objBU.ListaParametrosFiltradoEditar(IdInventarioCiclico)

    End Sub

    ''' <summary>
    ''' RECUPERA LA INFORMACIÓN DE LOS PARES CONTENIDOS EN UN INVENTARIO CICLICO ESTE EN EL ESTADO QUE ESTE.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub poblarGridPares()
        GrdInventariosCiclicos.DataSource = Nothing
        Dim objBu As New Negocios.InventarioCiclicoBU
        GrdInventariosCiclicos.DataSource = objBu.RecuperarDetalleInventario(IdInventarioCiclico, EstadoInventario)
    End Sub

    ''' <summary>
    ''' RECUPERA LOS PARES CONTENIDOS EN UN INVENTARIO CICLICO CONCLUIDO, ADEMAS DE INDICAR QUE PARES FALTARON, QUE PARES SOBRARON Y QUE PARES FUERON INVENTARIADOS CORRECTAMENTE.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PoblarGridParesInventarioConcluido()
        GrdInventariosCiclicos.DataSource = Nothing
        Dim objBU As New Negocios.InventarioCiclicoBU
        GrdInventariosCiclicos.DataSource = objBU.RecuperarListaParesInventarioConcluido(IdInventarioCiclico)
    End Sub

#Region "Recuperar filtros usados para levantar un inventario cíclico nuevo"

    Public Sub recuperarNombreCliente()
        If lClientes = String.Empty Then Return
        Dim dtClientes As New DataTable
        Dim objBU As New Negocios.InventarioCiclicoBU
        dtClientes = objBU.RecuperarNombreCliente(lClientes)
        dtTablaGeneralDescripcion.Merge(dtClientes)
    End Sub
    Public Sub RecuperarNombreAgente()
        If lAgente = String.Empty Then Return
        Dim dtNombreAgente As New DataTable
        Dim objAgenteBU As New Negocios.InventarioCiclicoBU
        dtNombreAgente = objAgenteBU.RecuperaNombreAgente(lAgente)
        dtTablaGeneralDescripcion.Merge(dtNombreAgente)
    End Sub
    Public Sub RecuperarNombreTienda()
        If IdTienda = String.Empty Then Return
        Dim dtNombreTienda As New DataTable
        Dim objTiendaBu As New Negocios.InventarioCiclicoBU
        dtNombreTienda = objTiendaBu.RecuperarNombreTienda(IdTienda)
        dtTablaGeneralDescripcion.Merge(dtNombreTienda)
    End Sub
    Public Sub RecuperarNombreProducto()
        If lProductos = String.Empty Then Return
        Dim dtNombreProducto As New DataTable
        Dim objProductoBU As New Negocios.InventarioCiclicoBU
        dtNombreProducto = objProductoBU.RecuperarNombreProducto(lProductos)
        dtTablaGeneralDescripcion.Merge(dtNombreProducto)
    End Sub
    Public Sub RecuperarNombreBahia()
        If lBahia = String.Empty Then Return
        Dim dtNombreBahia As New DataTable
        Dim objBahiaBU As New Negocios.InventarioCiclicoBU
        dtNombreBahia = objBahiaBU.RecuperarNombreBahia(lBahia)
        dtTablaGeneralDescripcion.Merge(dtNombreBahia)
    End Sub
    Public Sub RecuperarDescripcionCorrida()
        If lCorrida = String.Empty Then Return
        Dim dtCorrida As New DataTable
        Dim objCorridaBU As New Negocios.InventarioCiclicoBU
        dtCorrida = objCorridaBU.RecuperarDescripcionCorrida(lCorrida)
        dtTablaGeneralDescripcion.Merge(dtCorrida)
    End Sub
    Public Sub RecuperarMarca()
        If lProductos = String.Empty Then Return
        Dim dtMarca As New DataTable
        Dim objMArcasBU As New Negocios.InventarioCiclicoBU
        dtMarca = objMArcasBU.RecuperarMarca(lProductos)
        dtTablaGeneralDescripcion.Merge(dtMarca)
    End Sub
    Public Sub RecuperarColeccion()
        If lProductos = String.Empty Then Return
        Dim dtColeccion As New DataTable
        Dim objColeccionBU As New Negocios.InventarioCiclicoBU
        dtColeccion = objColeccionBU.RecuperarColeccion(lProductos)
        dtTablaGeneralDescripcion.Merge(dtColeccion)
    End Sub
    Public Sub recuperarPedido()
        If lPedidos = String.Empty Then Return
        Dim dtPedidos As New DataTable
        Dim objPedidosBU As New Negocios.InventarioCiclicoBU
        dtPedidos = objPedidosBU.RecuperarPedido(lPedidos)
        dtTablaGeneralDescripcion.Merge(dtPedidos)
    End Sub
#End Region

    ''' <summary>
    ''' LLENA EL GRID CRITERIODEFILTROS CUANDO EL INVENTARIO CICLICO ESTA POR LEVANTARSE
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub llenarGridDescripcion()

        dtTablaGeneralDescripcion.Clear()
        recuperarNombreCliente()
        RecuperarNombreAgente()
        RecuperarNombreProducto()
        recuperarPedido()
        RecuperarNombreTienda()
        RecuperarNombreBahia()
        RecuperarDescripcionCorrida()
        RecuperarMarca()
        RecuperarColeccion()

        grdCriterioDeFiltros.DataSource = Nothing
        If dtTablaGeneralDescripcion.Rows.Count = 0 Then
            Descripcion = "Almacen completo "
            'txtDescripcion.Text = Descripcion

        Else
            grdCriterioDeFiltros.DataSource = Nothing
            grdCriterioDeFiltros.DataSource = dtTablaGeneralDescripcion
        End If

    End Sub

#End Region

#Region "DAR FORMATO GRIDS Y FUNCIONALIDAD DE LOS GRIDS"

    Private Sub grdCriterioDeFiltros_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCriterioDeFiltros.InitializeLayout
        With grdCriterioDeFiltros
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns 'Ajusta todas las columnas a un tamaño igual.
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Bands(0).Columns("Identificador").Hidden = True
            .DisplayLayout.Bands(0).Columns("Tabla").Hidden = True


            For Each column As UltraGridColumn In grdCriterioDeFiltros.DisplayLayout.Bands(0).Columns
                If column.Header.Caption = "Campo" Then
                    .DisplayLayout.Bands(0).Columns("Campo").Hidden = True
                ElseIf column.Header.Caption = "IdCampo" Then
                    .DisplayLayout.Bands(0).Columns("IdCampo").Hidden = True
                End If
            Next
            
        End With
        If Editar = True Or ResultadoDeInventario = True Then
            RecuperarCaracteristica()
        End If
    End Sub

    Private Sub grdCriterioDeFiltros_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCriterioDeFiltros.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub GrdInventariosCiclicos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles GrdInventariosCiclicos.InitializeLayout
        With GrdInventariosCiclicos
            If (Editar = False) And (ResultadoDeInventario = False) Then
                .DisplayLayout.Bands(0).Columns.Add("Existencia")

                .DisplayLayout.Bands(0).Columns("Posicion").Hidden = True

                .DisplayLayout.Bands(0).Columns("D").Hidden = True
                .DisplayLayout.Bands(0).Columns("C").Hidden = True
                .DisplayLayout.Bands(0).Columns("A").Hidden = True
                .DisplayLayout.Bands(0).Columns("B").Hidden = True
                .DisplayLayout.Bands(0).Columns("R").Hidden = True
                .DisplayLayout.Bands(0).Columns("P").Hidden = True
                '.DisplayLayout.Bands(0).Columns("Origen").Hidden = True
                '.DisplayLayout.Bands(0).Columns("Origen Ant.").Hidden = True
                .DisplayLayout.Bands(0).Columns("Proceso").Hidden = True

                .DisplayLayout.Bands(0).Columns("Estiba").Hidden = True
                .DisplayLayout.Bands(0).Columns("Tienda").Header.VisiblePosition = 12
                '.DisplayLayout.Bands(0).Columns("tipo").Hidden = True
                .DisplayLayout.Bands(0).Columns("modelo").Hidden = True
                .DisplayLayout.Bands(0).Columns("Estiba ID").Hidden = True
                .DisplayLayout.Bands(0).Columns("Fecha Ubicación(hr)").CellActivation = Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Fecha Ubicación(hr)").Width = 58
            Else
                .DisplayLayout.Bands(0).Columns.Add("Tiendas", "Tienda")
                .DisplayLayout.Bands(0).Columns("Tienda").Hidden = True
                .DisplayLayout.Bands(0).Columns("Tiendas").Header.VisiblePosition = 12
                .DisplayLayout.Bands(0).Columns("Fecha").CellActivation = Activation.NoEdit
                .DisplayLayout.Bands(0).Columns("Fecha").Width = 58
            End If


            .DisplayLayout.Bands(0).Columns("Bahía ID").Hidden = True
            .DisplayLayout.Bands(0).Columns("Bloque").Hidden = True
            .DisplayLayout.Bands(0).Columns("Nivel").Hidden = True
            .DisplayLayout.Bands(0).Columns("Posicion").Hidden = True
            .DisplayLayout.Bands(0).Columns("color").Hidden = True


            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            .DisplayLayout.Bands(0).Columns("prs").Header.Caption = "#Pares"
            .DisplayLayout.Bands(0).Columns("prs").CellAppearance.TextHAlign = HAlign.Right
            '.DisplayLayout.Bands(0).Columns("Pedido").CellAppearance.TextHAlign = HAlign.Right

            .DisplayLayout.Bands(0).Columns("Apartado").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Lote").CellAppearance.TextHAlign = HAlign.Right
            '.DisplayLayout.Bands(0).Columns("agte").Header.Caption = "Agente"
            .DisplayLayout.Bands(0).Columns("P/A").Width = 20

            If (Editar = False And ResultadoDeInventario = False) Or EstadoInventario = 4 Or EstadoInventario = 1 Or (EstadoInventario = 3 And dobleclick = True) Then
                .DisplayLayout.Bands(0).Columns("Bahía").Width = 70
                'CAMBIAR DE ORDEN LAS COLUMNAS
                .DisplayLayout.Bands(0).Columns("P/A").Header.VisiblePosition = 1
                .DisplayLayout.Bands(0).Columns("Par").Header.VisiblePosition = 2
                .DisplayLayout.Bands(0).Columns("Atado").Header.VisiblePosition = 3
                .DisplayLayout.Bands(0).Columns("Bahía").Header.VisiblePosition = 4
                .DisplayLayout.Bands(0).Columns("Producto").Header.VisiblePosition = 5
                .DisplayLayout.Bands(0).Columns("Corrida").Header.VisiblePosition = 6
                .DisplayLayout.Bands(0).Columns("Talla").Header.VisiblePosition = 7
                .DisplayLayout.Bands(0).Columns("Cliente").Header.VisiblePosition = 8
                '.DisplayLayout.Bands(0).Columns("Pedido").Header.VisiblePosition = 9
                .DisplayLayout.Bands(0).Columns("Apartado").Header.VisiblePosition = 10
                ' .DisplayLayout.Bands(0).Columns("agte").Header.VisiblePosition = 11

                .DisplayLayout.Bands(0).Columns("Nave").Header.VisiblePosition = 13
                .DisplayLayout.Bands(0).Columns("Lote").Header.VisiblePosition = 14
                .DisplayLayout.Bands(0).Columns("prs").Header.VisiblePosition = 15

            ElseIf Editar = True And ResultadoDeInventario = False Then
                If EstadoInventario = 2 Then
                    .DisplayLayout.Bands(0).Columns("P/A").Header.VisiblePosition = 1
                    .DisplayLayout.Bands(0).Columns("Par").Header.VisiblePosition = 2
                    .DisplayLayout.Bands(0).Columns("Atado").Header.VisiblePosition = 3
                    .DisplayLayout.Bands(0).Columns("Ubicación Virtual").Header.VisiblePosition = 4
                    .DisplayLayout.Bands(0).Columns("Ubicación Real").Header.VisiblePosition = 5
                    .DisplayLayout.Bands(0).Columns("Producto").Header.VisiblePosition = 6
                    .DisplayLayout.Bands(0).Columns("Corrida").Header.VisiblePosition = 7
                    .DisplayLayout.Bands(0).Columns("Talla").Header.VisiblePosition = 8
                    .DisplayLayout.Bands(0).Columns("Cliente").Header.VisiblePosition = 9
                    '.DisplayLayout.Bands(0).Columns("Pedido").Header.VisiblePosition = 10
                    .DisplayLayout.Bands(0).Columns("Apartado").Header.VisiblePosition = 11
                    ' .DisplayLayout.Bands(0).Columns("agte").Header.VisiblePosition = 12
                    .DisplayLayout.Bands(0).Columns("Nave").Header.VisiblePosition = 13
                    .DisplayLayout.Bands(0).Columns("Lote").Header.VisiblePosition = 14
                    .DisplayLayout.Bands(0).Columns("prs").Header.VisiblePosition = 15
                Else
                    .DisplayLayout.Bands(0).Columns("P/A").Header.VisiblePosition = 1
                    .DisplayLayout.Bands(0).Columns("Par").Header.VisiblePosition = 2
                    .DisplayLayout.Bands(0).Columns("Atado").Header.VisiblePosition = 3

                    .DisplayLayout.Bands(0).Columns("Producto").Header.VisiblePosition = 5
                    .DisplayLayout.Bands(0).Columns("Corrida").Header.VisiblePosition = 6
                    .DisplayLayout.Bands(0).Columns("Talla").Header.VisiblePosition = 7
                    .DisplayLayout.Bands(0).Columns("Cliente").Header.VisiblePosition = 8
                    '.DisplayLayout.Bands(0).Columns("Pedido").Header.VisiblePosition = 9
                    .DisplayLayout.Bands(0).Columns("Apartado").Header.VisiblePosition = 10
                    ' .DisplayLayout.Bands(0).Columns("agte").Header.VisiblePosition = 11
                    .DisplayLayout.Bands(0).Columns("Nave").Header.VisiblePosition = 12
                    .DisplayLayout.Bands(0).Columns("Lote").Header.VisiblePosition = 13
                    .DisplayLayout.Bands(0).Columns("prs").Header.VisiblePosition = 14
                End If

            Else
                '.DisplayLayout.Bands(0).Columns("Sobra").Width = 40
                ''.DisplayLayout.Bands(0).Columns("Ubicación Virtual").Width = 75

                ''.DisplayLayout.Bands(0).Columns("Ubicación Real").Width = 75

            End If

            .DisplayLayout.Bands(0).Columns("prs").Width = 50
            .DisplayLayout.Bands(0).Columns("Operador").Width = 60
            .DisplayLayout.Bands(0).Columns("Par").Width = 85
            .DisplayLayout.Bands(0).Columns("Atado").Width = 85
            .DisplayLayout.Bands(0).Columns("Talla").Width = 30
            .DisplayLayout.Bands(0).Columns("Corrida").Width = 55

            '.DisplayLayout.Bands(0).Columns("Pedido").Width = 50
            '.DisplayLayout.Bands(0).Columns("agte").Width = 40
            .DisplayLayout.Bands(0).Columns("Nave").Width = 60
            .DisplayLayout.Bands(0).Columns("Lote").Width = 40

            .DisplayLayout.Bands(0).Columns("Existencia").Width = 40
            .DisplayLayout.Bands(0).Columns("prs").Width = 40
            .DisplayLayout.Bands(0).Columns("Apartado").Width = 50
            .DisplayLayout.Bands(0).Columns("P/A").Width = 20
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

            '    If ResultadoDeInventario = True Then
            '        .DisplayLayout.Bands(0).Columns("Sobra").Hidden = False
            '    End If

        End With

        'PINTAMOS LAS FILAS DEPENDIENDO SI ES PAR SOBRANTE, O FALTANTE PARA CUANDO SE CONSULTA EL RESULTADO DE UN INVENTARIO CICLICO
        If ResultadoDeInventario = True Then
            For Each row As UltraGridRow In GrdInventariosCiclicos.Rows
                If row.Cells("Existencia").Value = 0 And row.Cells("Sobra").Value = 0 Then
                    row.CellAppearance.BackColor = Color.Khaki
                ElseIf row.Cells("Sobra").Value = 1 Then
                    row.CellAppearance.BackColor = Color.LightSalmon
                End If
            Next
        End If



        'PINTAMOS EL GRID EN CASO DE QUE ESTE CONSULTANDO UN INVENTARIO EN PROCESO
        If EstadoInventario = 2 Then
            For Each row As UltraGridRow In GrdInventariosCiclicos.Rows
                If row.Cells("Existencia").Value = 0 And row.Cells("Sobra").Value = 0 Then
                    row.CellAppearance.BackColor = Color.Khaki
                ElseIf row.Cells("Sobra").Value = 1 Then
                    row.CellAppearance.BackColor = Color.LightSalmon
                End If
            Next
        End If


        'PINTAMOS LA CELDA P/A CUANDO LEVANTAMOS UN INVENTARIO CICLICO
        For Each row As UltraGridRow In GrdInventariosCiclicos.Rows
            If row.Cells("P/A").Text.Equals("P") Then
                row.Cells("P/A").Appearance.BackColor = Color.Khaki
            Else
                If row.Cells("P/A").Text.Equals("A") Then
                    row.Cells("P/A").Appearance.BackColor = Color.Aquamarine
                Else
                    row.Cells("P/A").Appearance.BackColor = Color.Orange
                End If
            End If
        Next

        Dim columnToSummarize As UltraGridColumn = GrdInventariosCiclicos.DisplayLayout.Bands(0).Columns("prs")
        Dim summary As SummarySettings = GrdInventariosCiclicos.DisplayLayout.Bands(0).Summaries.Add("TOTAL PARES", SummaryType.Sum, columnToSummarize)
        GrdInventariosCiclicos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
        summary.DisplayFormat = "{0:###,###,###,###}"
        summary.Appearance.TextHAlign = HAlign.Right
        PoblarTiendas()
    End Sub

    Private Sub GrdInventariosCiclicos_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles GrdInventariosCiclicos.AfterRowFilterChanged
        Dim pares, atados, totalPares, erroneos As Integer
        For Each row In GrdInventariosCiclicos.Rows.GetFilteredInNonGroupByRows

            If Not row.Cells("Par").Text.Equals("   --  ") Then
                If row.Cells("P/A").Text.Equals("P") Then
                    pares += 1
                Else
                    If row.Cells("P/A").Text.Equals("E") Then
                        erroneos += 1
                    End If
                End If
            End If

            If row.Cells("Par").Text.Equals("   --  ") Then
                atados += 1
            End If

            totalPares += CInt(row.Cells("Prs").Value)

        Next

        lblRecuperados.Text = GrdInventariosCiclicos.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
        lblAtados.Text = atados.ToString("N0", CultureInfo.InvariantCulture)
        lblPares.Text = pares.ToString("N0", CultureInfo.InvariantCulture)
        lblErroneos.Text = erroneos.ToString("N0", CultureInfo.InvariantCulture)
        lblTotalPares.Text = totalPares.ToString("N0", CultureInfo.InvariantCulture)

    End Sub

    ''' <summary>
    ''' RECUPERA EL NOMBRE DE LA TIENDA DE CADA PAR PARA AGREGARLO EN EL CAMPO CORRESPONDIENTE EN EL GRID GRDINVENTARIOCICLICO YA QUE NO SE RECUPERA }
    ''' ESA INFORMACIÓN EN LA CONSULTA PARA LEVANTAR UN INVENTARIO CÍCLICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PoblarTiendas()
        If Editar <> False Then
            Dim nfilas As Integer = 0
            Dim objBU As New Negocios.InventarioCiclicoBU
            For Each fila As UltraGridRow In GrdInventariosCiclicos.Rows
                If fila.Cells("Existencia").Text = "" Then
                    fila.Cells("Existencia").Value = "0"
                End If
                If IsNumeric(fila.Cells("Tienda").Text) Then
                    fila.Cells("Tienda").Activation = Activation.NoEdit
                    Dim dtTienda As New DataTable
                    Dim s As String = fila.Cells("Tienda").Text
                    dtTienda = objBU.RecuperarNombreTienda(s)
                    For Each row As DataRow In dtTienda.Rows
                        fila.Cells("Tiendas").Value = CStr(row.Item("Descripción"))
                    Next
                End If
            Next

        End If
    End Sub

    ''' <summary>
    ''' RECUPERA LA CARACTERISTICA CON LA CUAL SE LEVANTO UN INVENTARIO CICLICO TOMANDO EL NOMBRE DE LA TABLA, EL CAMPO Y EL ID DEL CAMPO DEL CUAL 
    ''' DEBERA RECUPERAR, EL NOMBRE O DESCIPCION DE LA CARACTERISTICA PARA DESPUES AGREGARLO AL GRID GRDCRITERIODEFILTROS
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RecuperarCaracteristica()
        With grdCriterioDeFiltros
            For Each row As UltraGridRow In grdCriterioDeFiltros.Rows
                If row.Cells("IdCampo").Text <> String.Empty Then
                    Dim CampoDesccripcion As String = row.Cells("Campo").Text
                    Dim Tabla As String = row.Cells("Tabla").Text
                    Dim IdCampo As String = row.Cells("IdCampo").Text
                    Dim CaracteristicaId As String = row.Cells("Característica").Text
                    Dim objBU As New Negocios.InventarioCiclicoBU
                    Dim dtCaracteristica As New DataTable
                    dtCaracteristica = objBU.RecuperarCaracteristica(CampoDesccripcion, Tabla, IdCampo, CaracteristicaId)
                    For Each rows As DataRow In dtCaracteristica.Rows
                        Dim propiedad As String = CStr(rows(0))
                        row.Cells("Característica").Value = propiedad
                    Next


                Else
                    If row.Cells("Criterio").Text = "UBICACIONES" Then
                        Dim PosicionGuion As Integer = InStr(CStr(row.Cells("Característica").Text), "-")
                        Dim texto = CStr(row.Cells("Característica").Text)
                        texto = texto.Substring(0, (PosicionGuion - 1))
                        row.Cells("Característica").Value = texto
                    End If
                End If
            Next

        End With
    End Sub

    Private Sub GrdInventariosCiclicos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles GrdInventariosCiclicos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

#End Region

    ''' <summary>
    ''' CUENTA LOS PARES CONTENIDOS DENTRO DE EL GRID GRDINVENTARIOSCICLICOS, Y EL NUMERO DE ATADOS DENTRO DEL MISMO GRID.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ContarTotalParesYAtados()
        If ResultadoDeInventario = True Then
            lblTotalInventario.Text = Totalpares
            lblTotalFaltantes.Text = faltantes
            lblTotalCorrectos.Text = encontrados
            lblTotalSobrantes.Text = sobrantes
            lblTotalLeidos.Text = (encontrados + sobrantes)
        Else
            For Each row As UltraGridRow In GrdInventariosCiclicos.Rows
                If Not row.Cells("Par").Text.Equals("   --  ") Then
                    If row.Cells("P/A").Text.Equals("P") Then
                        Tpares += 1
                    Else
                        If row.Cells("P/A").Text.Equals("E") Then
                            Terroneos += 1
                        End If
                    End If
                End If

                If row.Cells("Par").Text.Equals("   --  ") Then
                    Tatados += 1
                End If

                Totalpares += CInt(row.Cells("Prs").Value)

            Next

            lblRecuperados.Text = GrdInventariosCiclicos.Rows.Count.ToString("N0", CultureInfo.InvariantCulture)
            lblAtados.Text = Tatados.ToString("N0", CultureInfo.InvariantCulture)
            lblPares.Text = Tpares.ToString("N0", CultureInfo.InvariantCulture)
            lblErroneos.Text = Terroneos.ToString("N0", CultureInfo.InvariantCulture)
            lblTotalPares.Text = Totalpares.ToString("N0", CultureInfo.InvariantCulture)
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 32
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 294

    End Sub

    Public Sub ValidarCamposVacios()
        CamposVacios = False
        If cmbOperador.SelectedIndex < 1 Then
            lblOperador.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblOperador.ForeColor = Color.Black
        End If

        If dtpFechaEjecucion.Value < DateTime.Now.ToString("dd/MM/yyyy") Then
            lblFechaEjecucion.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblFechaEjecucion.ForeColor = Color.Black
        End If

        If txtDescripcion Is String.Empty Then
            lblDescricpcion.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblDescricpcion.ForeColor = Color.Black
        End If

        If txtDescripcion.Text = "" Then
            lblDescricpcion.ForeColor = Color.Red
            CamposVacios = True
        Else
            lblDescricpcion.ForeColor = Color.Black
        End If


        If CamposVacios = True Then
            Dim FormaError As New Tools.AdvertenciaForm
            FormaError.mensaje = "Campos vacíos "
            If dtpFechaEjecucion.Value < DateTime.Now.ToString("dd/MM/yyyy") Then
                FormaError.mensaje += ", la fecha de ejecución no puede ser menor a la fecha actual"
            End If
            FormaError.StartPosition = FormStartPosition.CenterScreen
            FormaError.ShowDialog()
        End If

    End Sub


    Private Sub btnGuardarInventarioCiclico_Click(sender As Object, e As EventArgs) Handles btnGuardarInventarioCiclico.Click

        Me.Cursor = Cursors.WaitCursor
        If EstadoInventario = 2 Then
            Me.Cursor = Cursors.WaitCursor
            Try
                FinalizarInventarioCiclico()
                show_message("Exito", "El inventaio se finalizó correctamente.")
            Catch ex As Exception
                show_message("Error", "Error inesperado, contacte al administrador y muestre el mensage: " + ex.Message)
            End Try
        Else
            Me.Cursor = Cursors.WaitCursor
            ValidarCamposVacios()
            If CamposVacios = True Then
                Me.Cursor = Cursors.Default
                Return
            End If
            Dim mensajeAdvertencia As New AvisoForm
            mensajeAdvertencia.mensaje = "Este proceso puede tardar dependiendo de los pares a agregar al inventario."
            mensajeAdvertencia.ShowDialog()

            Try
                If Editar = True Then
                    Me.Cursor = Cursors.WaitCursor
                    EditarInventarioCiclico()
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.WaitCursor
                    GuardarInventarioCiclico()
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
                show_message("Error", "Error inesperado, contacte al administrador y muestre el mensage: " + ex.Message)
            End Try
        End If

        Me.Cursor = Cursors.Default

        Me.Close()
    End Sub

    Public Sub EditarInventarioCiclico()
        Dim InventarioCiclico As New Entidades.InventariosCiclicos
        With InventarioCiclico
            .PEstado = 1
            .PIdInventario = IdInventarioCiclico
            .PDescripcion = txtDescripcion.Text
            .PIdOPerador = CInt(cmbOperador.SelectedValue)
            .PFechaProgramada = DateTime.Parse(dtpFechaEjecucion.Value.ToShortDateString).ToString("dd/MM/yyyy HH:mm:ss")
            If rdoPar.Checked = True Then
                .PPar_Atado = "P"
            ElseIf rdoAtado.Checked = True Then
                .PPar_Atado = "A"
            End If

        End With
        Dim objEditarInventario As New Negocios.InventarioCiclicoBU
        objEditarInventario.EditarInventarioCiclico(InventarioCiclico)
        Dim FormaExito As New Tools.ExitoForm
        FormaExito.mensaje = "El registro se actualizo con éxito."
        FormaExito.StartPosition = FormStartPosition.CenterScreen
        FormaExito.ShowDialog()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Dim InventarioCiclico As New Entidades.InventariosCiclicos
        With InventarioCiclico
            .PEstado = 4
            .PIdInventario = IdInventarioCiclico
            .PDescripcion = txtDescripcion.Text
            .PIdOPerador = CInt(cmbOperador.SelectedValue)
            .PFechaProgramada = DateTime.Parse(dtpFechaEjecucion.Value.ToShortDateString).ToString("dd/MM/yyyy HH:mm:ss")
            .PPar_Atado = "P"
        End With
        Dim objEditarInventario As New Negocios.InventarioCiclicoBU
        objEditarInventario.EditarInventarioCiclico(InventarioCiclico)
        Dim FormaExito As New Tools.ExitoForm
        FormaExito.mensaje = "El registro se actualizo con éxito"
        FormaExito.StartPosition = FormStartPosition.CenterScreen
        FormaExito.ShowDialog()
        Me.Close()
    End Sub

    Public Sub GuardarInventarioCiclico()
        IdInventarioCiclico = 0
        Dim InventarioCiclico As New Entidades.InventariosCiclicos
        With InventarioCiclico
            .PDescripcion = txtDescripcion.Text
            .PIdOPerador = CInt(cmbOperador.SelectedValue)
            .PFechaProgramada = DateTime.Parse(dtpFechaEjecucion.Value.ToShortDateString).ToString("dd/MM/yyyy HH:mm:ss")
            .PTotalPares = Totalpares
            If rdoPar.Checked = True Then
                .PPar_Atado = "P"
            ElseIf rdoAtado.Checked = True Then
                .PPar_Atado = "A"
            End If
        End With
        Dim objAltaInventarioCiclico As New Negocios.InventarioCiclicoBU
        Dim dtInvCi As New DataTable
        dtInvCi = objAltaInventarioCiclico.AgregarInventarioCiclico(InventarioCiclico)

        Try
            For Each row As DataRow In dtInvCi.Rows
                IdInventarioCiclico = CInt(row(0))
            Next
            GuardarInventarioCiclicoDetalles()
            GuardarCaracteristicasInventarioCiclico()
        Catch ex As Exception
        End Try

        Dim FormaExito As New Tools.ExitoForm
        FormaExito.StartPosition = FormStartPosition.CenterScreen
        FormaExito.mensaje = "El registro se guardo con éxito"
        FormaExito.ShowDialog()
    End Sub

    Public Sub GuardarCaracteristicasInventarioCiclico()
        Dim Caracteristicas As New Entidades.InvenatariosCiclicosCaracteristicas
        Dim objCaracteristicasInventarioBU As New Negocios.InventarioCiclicoBU

        For Each row As UltraGridRow In grdCriterioDeFiltros.Rows
            With Caracteristicas
                .PIdInventarioCiclico = IdInventarioCiclico
                If row.Cells("Etiqueta").Text = "CLIENTE" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 1
                ElseIf row.Cells("Etiqueta").Text = "TIENDA" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 2
                ElseIf row.Cells("Etiqueta").Text = "CORRIDAS" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 3
                ElseIf row.Cells("Etiqueta").Text = "PRODUCTO" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 4
                    'ElseIf row.Cells("Etiqueta").Text = "MARCA" Then
                    '    .PIdConfiguracionCaracteristicaInventarioCiclico = 5
                ElseIf row.Cells("Etiqueta").Text = "COLECCIÓN" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 6
                ElseIf row.Cells("Etiqueta").Text = "PEDIDO" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 7
                ElseIf row.Cells("Etiqueta").Text = "UBICACIÓN" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 8
                ElseIf row.Cells("Etiqueta").Text = "AGENTE" Then
                    .PIdConfiguracionCaracteristicaInventarioCiclico = 9
                End If
                .PCaracteristicaId = row.Cells("Identificador").Text

                objCaracteristicasInventarioBU.AgregarCaracteristicaInventarioCiclico(Caracteristicas)

            End With
        Next
    End Sub

    Public Sub GuardarInventarioCiclicoDetalles()
        Dim InventarioCiclicoDetalles As New Entidades.InventarioCiclicoDetalle
        Dim objInventarioCiclicoDetallesBU As New Negocios.InventarioCiclicoBU


        For Each row As UltraGridRow In GrdInventariosCiclicos.Rows
            With InventarioCiclicoDetalles
                .PInventarioId = IdInventarioCiclico
                .PIdPar = CStr(row.Cells("Par").Text)
                .PIdAtado = CStr(row.Cells("Atado").Text)
                .PUbicacionVirtual = CStr(row.Cells("Estiba").Text)
            End With
            objInventarioCiclicoDetallesBU.AgregarDetallesInventarioCiclico(InventarioCiclicoDetalles)
            'End If
        Next


    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        With fbdUbicacionArchivo
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True
            Dim ret As DialogResult = .ShowDialog

            If ret = Windows.Forms.DialogResult.OK Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                gridExcelExporter.Export(Me.GrdInventariosCiclicos, .SelectedPath + "\Datos_ListaUbicaciones_" + fecha_hora + ".xls")

            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default
            Dim MensageExito As New Tools.ExitoForm
            MensageExito.mensaje = "Los datos se exportaron correctamente"
            MensageExito.ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnUbicarMapa_Click(sender As Object, e As EventArgs) Handles btnUbicarMapa.Click
        If (Editar = False And ResultadoDeInventario = False) Or EstadoInventario = 4 Or EstadoInventario = 1 Or (EstadoInventario = 3 And dobleclick = True) Then
            Me.Cursor = Cursors.WaitCursor

            Dim listaBahias As New List(Of String)
            Dim listaBahiasLimpio As New List(Of String)
            Dim listaBahiasBuscar As New List(Of Entidades.Bahia)

            Dim mapa As New VerTodoslosNiveles

            For Each row In GrdInventariosCiclicos.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Bahía ID").Text <> "" Then
                    If Not listaBahias.Contains(row.Cells("Bahía ID").Text) Then
                        listaBahias.Add(row.Cells("Bahía ID").Text)
                        Dim bahia As New Entidades.Bahia
                        bahia.bahiaid = row.Cells("Bahía ID").Text
                        bahia.bahi_bloque = row.Cells("Bloque").Text
                        bahia.bahi_nivel = row.Cells("Nivel").Text
                        bahia.bahi_posicion = row.Cells("Posicion").Text
                        bahia.bahi_color = row.Cells("Color").Text

                        listaBahiasBuscar.Add(bahia)
                    End If
                End If
            Next

            mapa.BahiasBuscar = listaBahiasBuscar
            mapa.NavesAlmacen = nave_almacen
            mapa.externo = True
            mapa.ubicacion_producto = True

            mapa.ShowDialog()
            Me.Cursor = Cursors.Default
        Else

            cmsUbicarMapa.Show(btnUbicarMapa, 0, btnUbicarMapa.Height)

        End If

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then
            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()
        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm

            mensajeExito.ShowDialog()
        End If
    End Sub


    Private Sub CargarLectura_Click(sender As Object, e As EventArgs) Handles btnCargarLectura.Click
        show_message("Aviso", "Este proceso puede tardar dependiendo de la cantidad de pares a verificar")
        Dim myStream As Stream = Nothing
        Dim openFileDialog1 As New OpenFileDialog

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Try
                myStream = openFileDialog1.OpenFile()
                If (openFileDialog1.FileName IsNot Nothing) Then
                    Try
                        LeerArchivoDeTextoLineaPorLinea(openFileDialog1.FileName)
                        'VOLVEMOS A CARGAR EL GRID CON LOS DATOS ACTUALIZADOS
                        GrdInventariosCiclicos.DataSource = Nothing
                        PoblarGridParesInventarioConcluido()
                        CargarTotalParesInventarioEnProceso()
                    Catch ex As Exception
                        MsgBox("No es posible leer el archivo, Error:" + ex.Message, MsgBoxStyle.Exclamation)
                    End Try
                End If
            Catch Ex As Exception
                MessageBox.Show("No se puede leer el archivo en el disco. Error original: " & Ex.Message)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LeerArchivoDeTextoLineaPorLinea(ByVal Directorio As String)
        Dim objReader As New StreamReader(Directorio)
        Dim sLine As String = ""
        Dim arrArchivo As New ArrayList()

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                arrArchivo.Add(sLine)
            End If
        Loop Until sLine Is Nothing
        objReader.Close()




        If arrArchivo.Count > 0 Then
            btnCodigosConErrores.Visible = True
            lblCodigosConErrores.Visible = True
        End If

        Dim n As Integer = 0
        estiba = String.Empty
        estibaid = String.Empty
        par_valido = False
        estibaValida = False
        IdOperadorLectora = String.Empty
        Codigo = String.Empty
        CodigoPar = String.Empty

        'Agregar Arreglo a lista.
        Dim i = 1
        arrArchivoSinRepetidos.Clear()
        For Each item In arrArchivo
            If i < arrArchivo.Count Then
                If item <> arrArchivo(i) Then
                    arrArchivoSinRepetidos.Add(item.ToString)
                End If
                i += 1
            Else
                arrArchivoSinRepetidos.Add(item.ToString)
            End If
        Next




        Dim CodigoLeidoResultado As String = "Continuar"
        For Each item In arrArchivoSinRepetidos
            n += 1
            If CodigoLeidoResultado = "Continuar" Then
                CodigoLeidoResultado = AltaInventarioCiclicoDetalleLectora(item.ToString, n)
            End If
        Next
    End Sub

    Private Function AltaInventarioCiclicoDetalleLectora(ByVal Codigo As String, ByVal NumeroLinea As Integer)
        Codigo = LTrim(RTrim(Codigo))
        Dim codigo_split As String() = Codigo.Split("-") ''parte la cadena
        If NumeroLinea > 0 And NumeroLinea < 3 Then
            If Codigo.ToUpper.IndexOf("EM") = 0 And NumeroLinea = 1 Then
                If RTrim(LTrim(Codigo.ToUpper)) = ("EM" + IdOperador.ToString) Then
                    IdOperadorLectora = Codigo
                    Return "Continuar"
                Else
                    show_message("Advertencia", "El usuario que escaneo el archivo no es el asignado para realizar este inventario cíclico.")
                    arrCodigosErrores.Add(Codigo)
                    Return "Finalizar"
                End If
            ElseIf IsNumeric(Codigo) And NumeroLinea = 2 Then
                If LTrim(RTrim(Codigo)) <> IdInventarioCiclico.ToString Then
                    show_message("Advertencia", "El inventario cíclico escaneado no concuerda con el inventario cíclico seleccionado.")
                    arrCodigosErrores.Add(Codigo)
                    Return "Finalizar"
                Else
                    Return "Continuar"
                End If
                Return "Finalizar"
            Else
                show_message("Advertencia", "La credencial del operador y la hoja del inventario no se escanearón en el orden correcto, por lo tanto no se guardara ningún par en el inventario.")
                Return "Finalizar"
            End If

        Else

            ' una vez validados el colaborador y el inventario procedera a validar estiba hasta encobtrar una valida
            If estibaValida = False Then
                If Not IsNumeric(Codigo) Then ''verifica que el codigo sea numerico
                    If (LTrim(RTrim(Codigo))).ToUpper.Contains("ES") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
                        Try
                            verificar_estiba((LTrim(RTrim(Codigo))))
                        Catch ex As Exception
                            show_message("Error", "Algo resulto mal en la operación, error:" + ex.Message)
                        End Try
                    Else
                        arrCodigosErrores.Add(Codigo)
                    End If
                Else ''FIN If Not IsNumeric(codigo) Then
                    arrCodigosErrores.Add(Codigo)
                End If
            Else
                'UNA VEZ QUE YA ENCONTRO UNA ESTIBA VALIDA PROCEDE A AGREGAR PARES AL INVENTARIO CICLICO
                If Not IsNumeric(LTrim(RTrim(Codigo))) Then
                    If codigo_split.Length = 3 Then ''verifica "-" para posible par
                        Try
                            verificar_par((LTrim(RTrim(Codigo))))
                            If par_valido Then
                                GurdarParDetalleInventario()
                            End If
                            Return "Continuar"
                        Catch ex As Exception
                            arrCodigosErrores.Add(Codigo + " * " + estibaid)
                            show_message("Error", "Algo resulto mal en la operación, error:" + ex.Message)
                        End Try
                    Else
                        If Codigo.ToUpper.Contains("ES-") Then ''verifica que contenga la nomeclatura de la bahia "ESTIBA-
                            Try
                                verificar_estiba(Codigo)
                            Catch ex As Exception
                                arrCodigosErrores.Add(Codigo + " * " + estibaid)
                                show_message("Error", "Algo resulto mal en la operación, error:" + ex.Message)
                            End Try
                        Else
                            arrCodigosErrores.Add(Codigo + " * " + estibaid)
                        End If
                    End If
                Else
                    If LTrim(RTrim(par_Atado)) = "A" Then
                        If Len(LTrim(RTrim(Codigo))) >= 10 And Len(LTrim(RTrim(Codigo))) <= 13 Then
                            Dim AtadoValido As Boolean = VerificarAtado(LTrim(RTrim(Codigo)))
                            If AtadoValido = True Then
                                AgregarAtadoInventarioCiclico(LTrim(RTrim(Codigo)))
                            Else
                                arrCodigosErrores.Add(Codigo + " * " + estibaid)
                            End If
                        Else
                            arrCodigosErrores.Add(Codigo + " * " + estibaid)
                        End If
                    Else
                        arrCodigosErrores.Add(Codigo + " * " + estibaid)
                    End If

                End If

            End If
            Return "Continuar"
        End If
    End Function


    Public Sub AgregarAtadoInventarioCiclico(ByVal Codigo As String)
        Dim objBU As New Negocios.InventarioCiclicoBU
        Dim dtPares As New DataTable
        dtPares = objBU.RecuperarParesAtadoContenidoAtado(Codigo)
        If dtPares.Rows.Count < 1 Then
            dtPares = objBU.RecuperarParesAtadotmpDocenasPares(Codigo)
        End If
        For Each row As DataRow In dtPares.Rows()
            CodigoPar = row.Item(0)
            GurdarParDetalleInventario()
        Next
    End Sub

    ''' <summary>
    ''' VERIFICA EL CODIGO LEEIDO SEA UNA ESTIBA Y VALIDARLO CON LA BASE DE DATOS
    ''' </summary>
    ''' <param name="codigo">CODIGO A VALIDAR</param>
    ''' <remarks></remarks>
    Public Sub verificar_estiba(ByVal codigo As String)
        Dim objBU As New Negocios.InventarioCiclicoBU
        If codigo.ToUpper.IndexOf("ES") = 0 Then ''verifica que contenga los caracteres "EM" al inicio de la cadena de texto
            Dim codigo_split As String() = LTrim(RTrim(codigo)).Split("-")

            If objBU.Consulta_Estiba_Valido(codigo.Remove(0, 3)) Then ''verifica que la bahia exista en la base de datos
                estibaValida = True
                estiba = codigo_split(1)
                estibaid = codigo.Remove(0, 3)
            Else
                If estibaValida = False Then
                    estibaValida = False
                    estibaid = Nothing
                    arrCodigosErrores.Add(codigo)
                End If
            End If
        Else
            estibaValida = False
            estibaid = Nothing
            arrCodigosErrores.Add(codigo)
        End If
    End Sub

    Public Sub verificar_par(ByVal codigo As String)
        par_valido = False
        Dim codigo_split = LTrim(RTrim(codigo)).Split("-") ''parte la cadena
        If codigo_split.Length = 3 Then
            'Dim objInventarioBU As New InventariosCiclicosBU
            If codigo_split(2).Length >= 10 And codigo_split(2).Length <= 13 Then ''verifica que la extension del codigo conincida con la extension del codigo de pares
                Dim objBU As New Negocios.InventarioCiclicoBU
                If objBU.Consulta_Par_Valido_InventarioCilcicoDetalles(codigo_split(2), IdInventarioCiclico) Then
                    par_valido = True
                    CodigoPar = codigo_split(2)
                ElseIf objBU.Consulta_Par_Valido(codigo_split(2)) Then ''verifica que el codigo pertenesca a un par valido
                    CodigoPar = codigo_split(2)
                    par_valido = True
                ElseIf objBU.Consulta_Par_ContenidoAtados(codigo_split(2)) Then
                    par_valido = True
                    CodigoPar = codigo_split(2)
                ElseIf objBU.Consulta_Par_tmpErroresPares(codigo_split(2)) Then
                    par_valido = True
                    CodigoPar = codigo_split(2)
                Else
                    objBU.AgregarParAErroresStatusPar(codigo_split(2), estibaid, IdOperador)
                End If
                If par_valido = False Then
                    If objBU.Consulta_Par_tmpDocenasPares(codigo_split(2)) Then
                        par_valido = True
                        CodigoPar = codigo_split(2)
                    Else
                        arrCodigosErrores.Add(codigo)
                        par_valido = False
                        CodigoPar = String.Empty
                    End If
                End If
            End If
        Else
            par_valido = False
        End If
    End Sub

    Public Function VerificarAtado(ByVal codigo As String)
        par_valido = False
        Dim objBU As New Negocios.InventarioCiclicoBU
        If objBU.VerificarAtadoUbicacionAtados(codigo) = True Then
            Return True
        ElseIf objBU.VerificarAtadoLotesDocenas(codigo) = True Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub GurdarParDetalleInventario()
        Dim objBU As New Negocios.InventarioCiclicoBU
        Dim dtTotalesPares As New DataTable
        If CodigoPar <> String.Empty Then
            Try
                dtTotalesPares = objBU.ParEscaneadoInvCiclDetalle(IdInventarioCiclico, CodigoPar, estiba, IdOperador)
            Catch ex As Exception
                MsgBox("Ocurrió un error inesperado: " + ex.ToString)
            End Try
            'PoblarInventarioDetalles()
            Codigo = String.Empty
            CodigoPar = String.Empty
        End If
    End Sub

    Public Sub CargarTotalParesInventarioEnProceso()
        Dim objBU As New Negocios.InventarioCiclicoBU
        Dim dtTotalPares As New DataTable
        dtTotalPares = objBU.CargarTotalParesInventarioEnProceso(IdInventarioCiclico)
        For Each row As DataRow In dtTotalPares.Rows
            lblTotalInventario.Text = row.Item(0)
            lblTotalCorrectos.Text = row.Item(1)
            lblTotalFaltantes.Text = row.Item(2)
            lblTotalSobrantes.Text = row.Item(3)
            Dim TotalLectura = row.Item(1) + row.Item(3)
            lblTotalLeidos.Text = TotalLectura
        Next

    End Sub

    Private Sub btnCodigosConErrores_Click(sender As Object, e As EventArgs) Handles btnCodigosConErrores.Click
        Dim FormaListaErrores As New ListaErroresInventarioCiclicoForm
        FormaListaErrores.arrCodigosError = arrCodigosErrores
        FormaListaErrores.StartPosition = FormStartPosition.CenterScreen
        FormaListaErrores.ShowDialog()

        'Dim Cadenaerrores As String = ""
        'For Each Item In arrCodigosErrores
        '    Cadenaerrores += vbCrLf + Item.ToString
        'Next
        'MsgBox(Cadenaerrores)
    End Sub

    Public Sub FinalizarInventarioCiclico()
        Dim objBU As New Negocios.InventarioCiclicoBU

        Dim total As Integer = CInt(lblTotalInventario.Text)
        Dim Nbien As Integer = CInt(lblTotalCorrectos.Text)
        Dim NFaltante As Integer = CInt(lblTotalFaltantes.Text)
        Dim NSobrantes As Integer = CInt(lblTotalSobrantes.Text)

        objBU.CerrarInventarioCiclico(IdInventarioCiclico, total, Nbien, NFaltante, NSobrantes, IdOperador)
        objBU.CerrarInventarioCiclicoDetalle(IdInventarioCiclico)
    End Sub

  

    Public Function RecuperarDatosUbicacionReal(ByVal Estiba As String)
        Dim objBU As New Negocios.InventarioCiclicoBU
        Dim dtBahia As New DataTable
        dtBahia = objBU.RecuperarDatosUbicacionReal(Estiba)
        Return dtBahia
    End Function

    Private Sub UbicaciónRealToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbicaciónRealToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor

        Dim listaBahias As New List(Of String)
        Dim listaBahiasLimpio As New List(Of String)
        Dim listaBahiasBuscar As New List(Of Entidades.Bahia)

        Dim mapa As New VerTodoslosNiveles

        For Each rowx In GrdInventariosCiclicos.Rows.GetFilteredInNonGroupByRows
            If rowx.Cells("Ubicación Real").Text <> "" Then
                Dim dtbahia As New DataTable
                dtbahia = RecuperarDatosUbicacionReal(rowx.Cells("Ubicación Real").Text)
                For Each row As DataRow In dtbahia.Rows
                    If Not listaBahias.Contains(row.Item("Bahía ID")) Then
                        listaBahias.Add(row.Item("Bahía ID"))
                        Dim bahia As New Entidades.Bahia
                        bahia.bahiaid = row.Item("Bahía ID")
                        bahia.bahi_bloque = row.Item("Bloque")
                        bahia.bahi_nivel = row.Item("Nivel")
                        bahia.bahi_posicion = row.Item("Posicion")
                        bahia.bahi_color = row.Item("Color")
                        listaBahiasBuscar.Add(bahia)
                    End If
                Next
            End If
        Next
        mapa.BahiasBuscar = listaBahiasBuscar
        mapa.NavesAlmacen = nave_almacen
        mapa.externo = True
        mapa.ubicacion_producto = True

        mapa.ShowDialog()
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub UbicacionVIrtualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UbicacionVIrtualToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim listaBahias As New List(Of String)
        Dim listaBahiasLimpio As New List(Of String)
        Dim listaBahiasBuscar As New List(Of Entidades.Bahia)
        Dim mapa As New VerTodoslosNiveles
        For Each row In GrdInventariosCiclicos.Rows.GetFilteredInNonGroupByRows
            If row.Cells("Bahía ID").Text <> "" Then
                If Not listaBahias.Contains(row.Cells("Bahía ID").Text) Then
                    listaBahias.Add(row.Cells("Bahía ID").Text)
                    Dim bahia As New Entidades.Bahia
                    bahia.bahiaid = row.Cells("Bahía ID").Text
                    bahia.bahi_bloque = row.Cells("Bloque").Text
                    bahia.bahi_nivel = row.Cells("Nivel").Text
                    bahia.bahi_posicion = row.Cells("Posicion").Text
                    bahia.bahi_color = row.Cells("Color").Text
                    listaBahiasBuscar.Add(bahia)
                End If
            End If
        Next
        mapa.BahiasBuscar = listaBahiasBuscar
        mapa.NavesAlmacen = nave_almacen
        mapa.externo = True
        mapa.ubicacion_producto = True

        mapa.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    
End Class

