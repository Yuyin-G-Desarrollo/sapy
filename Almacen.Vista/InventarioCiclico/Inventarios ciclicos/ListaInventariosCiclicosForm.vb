Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports Stimulsoft.Report

Public Class ListaInventariosCiclicosForm
    Dim Cliente, Tienda, Pedido, Estado, Agente, Producto, Marca, Coleccion, Modelo, Corrida, Activo, Bahia, Operadores As String
    Dim IdClientes, IdTiendas, IdPedidos, IdEstados, IdAgentes, IdProductos, IdMarcas, IdColecciones, IdModelos, IdCorridas, IdBahias, IdOperadores As String
    Dim Y_O As Boolean
    Dim dtCliente, dtTienda, dtOperador, dtAgentes, dtBahias, dtCorridas, dtProductos As New DataTable
    Dim IdEstado As Integer
    Dim IdInventario As Integer
    Dim IdOperador As Integer
    Dim TotalPares, faltantes, Sobrantes, Encontrados As Integer
    Dim Desccripcion As String
    Dim NombreOperador As String
    Dim Fecha, FechaReal As DateTime
    Dim idnave As Integer = 43


    Private Sub ListaInventariosCiclicosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Me.WindowState = 2
        'LlenarListaInventarios()
        'listado_naves()
        Controles.UltraComboOperadoresAlmacen(cmbUOperador)
        Controles.UltraComboEstadosInventarioCiclico(cmbUEstado)
    End Sub

    ''' <summary>
    ''' LLENA CONTROL COMBO BOX CON LAS NAVES CON ALMACENES A LAS QUE TIENE ACCESO UN USUARIO
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub listado_naves()
        Try
            Controles.ComboNavesConAlmacenSegunUsuario(cmbNave, CInt(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid.ToString))
        Catch ex As Exception

        End Try
        If cmbNave.SelectedIndex = 1 Then
            listado_almacen()
        End If
    End Sub

    ''' <summary>
    ''' LLENA UN CONTROL COMBOBOX CON LA LISTA DE LOS ALMACENES A LOS QUE TIENE ACCESI UN USUARIO SEGUN LA NAVE SELECCIONADA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub listado_almacen()
        Try
            Controles.ComboAlmacenSegunNave(cmbAlmacen, CInt(cmbNave.SelectedValue))
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' METODO PARA POBLAR EL GRID "GRDINVENTARIOSCICLICOS" CON LOS DATOS DE CADA INVENTARIO CICLICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LlenarListaInventarios()
        grdInventariosCiclicos.DataSource = Nothing
        IdPedidos = txtPedido.Text

        Dim BusquedaInventario As New Entidades.InventarioCiclicoBusqueda
        Dim tbInventario As New DataTable
        Dim objBU As New Negocios.InventarioCiclicoBU

        'recuperamos los datos
        With BusquedaInventario
            .PAgente = IdAgentes
            .PCliente = IdClientes
            .PTienda = IdTiendas
            .PPedido = IdPedidos
            .PEstado = IdEstados
            .PProducto = IdProductos
            .PMarcas = IdMarcas
            .Pcoleccion = IdColecciones
            .PModelo = IdModelos
            .PCorridas = IdCorridas
            .POperador = IdOperadores
            .PUbicacion = IdBahias
            .PEstado = IdEstados
            If rdoCatalogoActivoSi.Checked = True Then
                .PActivo = True
            Else
                .PActivo = False
            End If
        End With
        If rdoY.Checked = True Then
            Y_O = True
        Else
            Y_O = False
        End If
        tbInventario = objBU.ListaInventariosCiclicos(BusquedaInventario, Y_O)
        grdInventariosCiclicos.DataSource = tbInventario
    End Sub


    Private Sub btnArriba_Click_1(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBuscar.Height = 35
    End Sub
    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBuscar.Height = 239
    End Sub
    Private Sub btnMostrar_Click_1(sender As Object, e As EventArgs) Handles btnMostrar.Click
        LlenarListaInventarios()
    End Sub

#Region "Filtros"
    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 2
        Dim listaParametroID As New List(Of String)
        For Each row As DataRow In dtCliente.Rows
            Dim parametro As String = CStr(row(0))
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        dtCliente = listado.listParametros
        IdClientes = String.Empty
        Cliente = String.Empty
        For Each row As DataRow In dtCliente.Rows
            If IdClientes = String.Empty Then
                IdClientes += CStr(row("Parámetro"))
                Cliente += CStr(row("Nombre"))
            Else
                IdClientes += ", " + CStr(row("Parámetro"))
                Cliente += ", " + CStr(row("Nombre"))
            End If
        Next
        txtCliente.Text = IdClientes
        lblClientes.Text = Cliente
    End Sub
    Private Sub btnTienda_Click(sender As Object, e As EventArgs) Handles btnTienda.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 9
        Dim listaParametroID As New List(Of String)
        For Each row As DataRow In dtTienda.Rows
            Dim parametro As String = CStr(row(0))
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        dtTienda = listado.listParametros
        IdTiendas = String.Empty
        Tienda = String.Empty
        For Each row As DataRow In dtTienda.Rows
            If IdTiendas = String.Empty Then
                IdTiendas += CStr(row("Parámetro"))
                Tienda += CStr(row("Cliente"))
            Else
                IdTiendas += ", " + CStr(row("Parámetro"))
                Tienda += ", " + CStr(row("Cliente"))
            End If
        Next
        txtTienda.Text = IdTiendas
        lblTiendas.Text = Tienda
    End Sub
    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 3
        Dim listaParametroID As New List(Of String)
        For Each row As DataRow In dtCorridas.Rows
            Dim parametro As String = CStr(row(0))
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        dtCorridas = listado.listParametros
        IdCorridas = String.Empty
        Corrida = String.Empty
        For Each row As DataRow In dtCorridas.Rows
            If IdCorridas = String.Empty Then
                IdCorridas += CStr(row("Parámetro"))
                Corrida += CStr(row("Talla"))
            Else
                IdCorridas += ", " + CStr(row("Parámetro"))
                Corrida += ", " + CStr(row("Talla"))
            End If
        Next
        txtCorrida.Text = IdCorridas
        lblCorridas.Text = Corrida
    End Sub
    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 7
        Dim listaParametroID As New List(Of String)
        For Each row As DataRow In dtAgentes.Rows
            Dim parametro As String = CStr(row(0))
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return

        dtAgentes = listado.listParametros
        IdAgentes = String.Empty
        Agente = String.Empty

        For Each row As DataRow In dtAgentes.Rows
            If IdAgentes = String.Empty Then
                IdAgentes += CStr(row("Parámetro"))
                Agente += CStr(row("Nombre"))
            Else
                IdAgentes += ", " + CStr(row("Parámetro"))
                Agente += ", " + CStr(row("Nombre"))
            End If
        Next
        txtAgente.Text = IdAgentes
        lblAgentes.Text = Agente
    End Sub
    Private Sub btnProducto_Click(sender As Object, e As EventArgs) Handles btnProducto.Click

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        Dim listaParamaetroModelo As New List(Of String)
        Dim listaParamaetroColeccion As New List(Of String)
        Dim listaParamaetroMarca As New List(Of String)
        For Each row As DataRow In dtProductos.Rows
            Dim parametro As String = CStr(row("Parámetro"))
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        dtProductos = listado.listParametros
        IdProductos = String.Empty
        Producto = String.Empty
        For Each row As DataRow In dtProductos.Rows
            If IdProductos = String.Empty Then
                IdProductos += CStr(row("Parámetro"))
                Producto += CStr(row("Descripción"))
            Else
                IdProductos += ", " + CStr(row("Parámetro"))
                Producto += ", " + CStr(row("Descripción"))
            End If
        Next


        For Each row As DataRow In dtProductos.Rows
            Dim ParametroModelo As String = CStr(row("Modelo"))
            listaParamaetroModelo.Add(ParametroModelo)
            Dim ParametroColeccion As String = CStr(row("Colección"))
            listaParamaetroColeccion.Add(ParametroColeccion)
            Dim ParemetrosMarca As String = CStr(row("Marca"))
            listaParamaetroMarca.Add(ParemetrosMarca)
        Next

        Coleccion = String.Empty
        For Each item In listaParamaetroColeccion
            If Coleccion = String.Empty Then
                Coleccion = item
            Else
                Dim i As Integer = 0
                i = InStr(1, Coleccion, item)
                If i = 0 Then
                    Coleccion += ", " + item
                End If
            End If
        Next

        Modelo = String.Empty
        For Each item In listaParamaetroModelo
            If Modelo = String.Empty Then
                Modelo = item
            Else
                Dim i As Integer = 0
                i = InStr(1, Modelo, item)
                If i = 0 Then
                    Modelo += ", " + item
                End If
            End If
        Next

        Marca = String.Empty
        For Each item In listaParamaetroMarca
            If Marca = String.Empty Then
                Marca = item
            Else
                Dim i As Integer = 0
                i = InStr(1, Marca, item)
                If i = 0 Then
                    Marca += ", " + item
                End If
            End If
        Next

        txtProduco.Text = IdProductos
        lblProductos.Text = Producto
        lblColecciones.Text = Coleccion
        lblModelos.Text = Modelo
        lblMarcas.Text = Marca


    End Sub
    Private Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        'If cmbNave.SelectedValue = 0 Or IsNothing(cmbNave.SelectedValue) Then
        '    show_message("Aviso", "Debe seleccionar un almacén")
        '    Return
        'End If

        Dim tablaNaves As New List(Of Entidades.Naves)
        Dim objNavesBU As New Framework.Negocios.NavesBU

        Dim listado As New ListadoParametroUbicacionForm
        listado.tipo_busqueda = 4
        'listado.id_parametros = CStr(cmbNave.SelectedValue) + "," + CStr(cmbAlmacen.Text)
        listado.id_parametros = "43, 1"
        Dim listaParametroID As New List(Of String)
        For Each row As DataRow In dtBahias.Rows
            Dim parametro As String = CStr(row(0))
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        dtBahias = listado.listParametros
        dtProductos = listado.listParametros
        IdBahias = String.Empty
        Bahia = String.Empty
        For Each row As DataRow In dtProductos.Rows
            If IdBahias = String.Empty Then
                IdBahias += CStr(row("Parámetro"))
                Bahia += CStr(row("Bahía"))
            Else
                IdBahias += ", " + CStr(row("Parámetro"))
                Bahia += ", " + CStr(row("Bahía"))
            End If
        Next
        txtUbicacion.Text = IdBahias
        lblUbicaciones.Text = Bahia
    End Sub
    Private Sub cboxNave_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbNave.SelectionChangeCommitted
        listado_almacen()
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
    Private Sub cmbUEstado_ValueChanged(sender As Object, e As EventArgs) Handles cmbUEstado.ValueChanged
        Dim dtDatosFiltrados As New DataTable
        Estado = cmbUEstado.Text
        Dim matriz() As String
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        matriz = Split(Trim(Estado), ",")
        Dim tamanoCadena As Integer
        tamanoCadena = UBound(matriz) + 1

        datosCombo = Me.cmbUEstado.Value
        dtsCmbFiltro = Me.cmbUEstado.Items.ValueList
        If Not datosCombo Is Nothing Then
            Dim index As Int32 = -1
            IdEstados = ""
            For Each value As Object In datosCombo
                Dim text As String = dtsCmbFiltro.GetText(value, index)
                IdEstados += value.ToString + ", 0"
            Next
        Else
            IdEstados = String.Empty
        End If

    End Sub
    Private Sub cmbUOperador_ValueChanged(sender As Object, e As EventArgs) Handles cmbUOperador.ValueChanged
        Dim dtDatosFiltrados As New DataTable
        Operadores = cmbUOperador.Text
        Dim datosCombo As System.Collections.IList = Nothing
        Dim dtsCmbFiltro As IValueList = Nothing

        datosCombo = Me.cmbUOperador.Value
        dtsCmbFiltro = Me.cmbUOperador.Items.ValueList
        If Not datosCombo Is Nothing Then
            Dim index As Int32 = -1
            IdOperadores = ""
            For Each value As Object In datosCombo
                Dim text As String = dtsCmbFiltro.GetText(value)
                IdOperadores += value.ToString + ", 0"
            Next
        Else
            IdOperadores = String.Empty
        End If


    End Sub
#End Region

#Region "Limpiar"

    ''' <summary>
    ''' LIMPIA TODAS LAS CAJAS DE TEXTO Y LAS ETIQUETAS EN EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub limpiarCajasYEstiquetas()
        lblAgentes.Text = " "
        txtAgente.Text = " "
        lblClientes.Text = " "
        txtCliente.Text = " "
        lblTiendas.Text = " "
        txtTienda.Text = " "
        lblUbicaciones.Text = " "
        txtUbicacion.Text = " "
        lblProductos.Text = " "
        txtProduco.Text = " "
        lblColecciones.Text = " "
        lblMarcas.Text = " "
        lblModelos.Text = " "
        lblCorridas.Text = " "
        txtCorrida.Text = " "
        txtPedido.Text = ""
    End Sub

    ''' <summary>
    ''' RESETEA LA MAYORIA DE LAS VARIABLES EN EL FORMULARIO,DE HECHO RESETEA TODAS LAS QUE PUDIERAN GENERAR ALGUN PROBLEMA AL DEJARLAS CON ALGUN VALOR
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LimpiarVariables()
        Cliente = String.Empty
        Tienda = String.Empty
        Pedido = String.Empty
        Estado = String.Empty
        Agente = String.Empty
        Producto = String.Empty
        Marca = String.Empty
        Coleccion = String.Empty
        Modelo = String.Empty
        Corrida = String.Empty
        Activo = String.Empty
        Bahia = String.Empty
        Operadores = String.Empty

        IdClientes = String.Empty
        IdTiendas = String.Empty
        IdPedidos = String.Empty
        IdEstados = String.Empty
        IdAgentes = String.Empty
        IdProductos = String.Empty
        IdMarcas = String.Empty
        IdColecciones = String.Empty
        IdModelos = String.Empty
        IdCorridas = String.Empty
        IdBahias = String.Empty
        IdOperadores = String.Empty

        IdEstado = 0
        TotalPares = 0
        Encontrados = 0
        faltantes = 0
        Sobrantes = 0
        IdInventario = 0
    End Sub

    ''' <summary>
    ''' LIMPIA TODOS LOS DATATABLES EN EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub limpiarDataTables()
        dtCliente.Clear()
        dtTienda.Clear()
        dtOperador.Clear()
        dtAgentes.Clear()
        dtBahias.Clear()
        dtCorridas.Clear()
        dtProductos.Clear()
    End Sub

    ''' <summary>
    ''' LIMPIA LOS ULTRACOMBOS EN EL FORMULARIO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LimpiarUltracombos()
        IdOperadores = String.Empty
        IdEstados = String.Empty
        Operadores = String.Empty
        Estado = String.Empty

        Dim contcmbUEstado As Int32 = cmbUEstado.CheckedItems.Count
        Dim contcmbUOperador As Int32 = cmbUOperador.CheckedItems.Count

        If contcmbUEstado = 1 Then
            cmbUEstado.SelectedItem.CheckState = CheckState.Unchecked
        ElseIf contcmbUEstado > 1 Then
            cmbUEstado.Clear()
        End If

        If contcmbUOperador = 1 Then
            cmbUOperador.SelectedItem.CheckState = CheckState.Unchecked
        ElseIf contcmbUOperador > 1 Then
            cmbUOperador.Clear()
        End If

    End Sub

    ''' <summary>
    ''' EJECUTA LOS METODOS PARA LIMPIAR VARIABLES, CAJAS DE TEXTO, ULTRACOMBOS Y DATATABLES
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarCajasYEstiquetas()
        LimpiarVariables()
        limpiarDataTables()
        LimpiarUltracombos()
        grdInventariosCiclicos.DataSource = Nothing
    End Sub
#End Region

#Region "Funcionalidad Grid"

    Private Sub grdInventariosCiclicos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdInventariosCiclicos.InitializeLayout
        With grdInventariosCiclicos
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.Bands(0).Columns("IdInventarioCiclico").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id Operador").Hidden = True
            .DisplayLayout.Bands(0).Columns("Estado").Hidden = True

            .DisplayLayout.Bands(0).Columns("Fecha Programada").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Fecha de Ejecución").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Fecha Programada").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Fecha de Ejecución").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Faltantes").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Sobrantes").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("Pares").Format = "N0"
            .DisplayLayout.Bands(0).Columns("Faltantes").Format = "N0"
            .DisplayLayout.Bands(0).Columns("Sobrantes").Format = "N0"
            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Bands(0).Columns("Pares").Width = 160
            .DisplayLayout.Bands(0).Columns("Faltantes").Width = 160
            .DisplayLayout.Bands(0).Columns("Sobrantes").Width = 160
            .DisplayLayout.Bands(0).Columns("Fecha Programada").Width = 300
            .DisplayLayout.Bands(0).Columns("Fecha Programada").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Fecha Programada").Format = "d"
            .DisplayLayout.Bands(0).Columns("Fecha Programada").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Fecha de Ejecución").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Fecha de Ejecución").Width = 300
            .DisplayLayout.Bands(0).Columns("Operador").Width = 500
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            'grid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.AliceBlue
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No


        End With
    End Sub

    Private Sub grdInventariosCiclicos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdInventariosCiclicos.ClickCell
        Dim row As UltraGridRow = grdInventariosCiclicos.ActiveRow
        If row.IsFilterRow Then Return
        IdInventario = CInt(row.Cells("IdInventarioCiclico").Text)
        NombreOperador = CStr(row.Cells("Operador").Text)
        IdOperador = CStr(row.Cells("Id Operador").Text)
        Desccripcion = CStr(row.Cells("Descripción").Value)
        Fecha = CDate(row.Cells("Fecha Programada").Text)
        If (row.Cells("Fecha de Ejecución").Text) <> "" Then
            FechaReal = CDate(row.Cells("Fecha de Ejecución").Text)
        End If
        IdEstado = CInt(row.Cells("Estado").Text)
        TotalPares = CInt(row.Cells("Pares").Text)
        If row.Cells("Faltantes").Text <> "" Then
            faltantes = CInt(row.Cells("Faltantes").Text)
            Encontrados = TotalPares - faltantes
        End If
        If row.Cells("Sobrantes").Text <> "" Then
            Sobrantes = CInt(row.Cells("Sobrantes").Text)

        End If

    End Sub

    Private Sub grdInventariosCiclicos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdInventariosCiclicos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdInventariosCiclicos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdInventariosCiclicos.DoubleClickCell
        Dim row As UltraGridRow = grdInventariosCiclicos.ActiveRow
        If row.IsFilterRow Then Return
        IdInventario = CInt(row.Cells("IdInventarioCiclico").Text)
        IdOperador = CStr(row.Cells("Id Operador").Text)
        Desccripcion = CStr(row.Cells("Descripción").Value)
        Fecha = CDate(row.Cells("Fecha Programada").Text)
        IdEstado = CInt(row.Cells("Estado").Text)

        Dim AgregarInventario As New AltaInventarioCiclicoForm
        With AgregarInventario
            '.nave_almacen = CStr(cmbNave.SelectedValue) + "," + CStr(cmbAlmacen.Text)
            .nave_almacen = "43, 1"
            .IdInventarioCiclico = IdInventario
            .Editar = True
            .EstadoInventario = IdEstado
            .Descripcion = Desccripcion
            .IdOperador = IdOperador
            .fechaInicio = Fecha.ToString
            .SoloConsulta = True
            .ShowDialog()
            grdInventariosCiclicos.DataSource = Nothing
            limpiarCajasYEstiquetas()
            LimpiarVariables()
            limpiarDataTables()
            LimpiarUltracombos()
            grdInventariosCiclicos.DataSource = Nothing
        End With
    End Sub

#End Region

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim BusquedaPares As New BusquedaParAtadoForm
        BusquedaPares.MdiParent = Me.MdiParent
        BusquedaPares.Location = New Point(0, 0)
        BusquedaPares.inventariociclico = True
        BusquedaPares.Show()
        grdInventariosCiclicos.DataSource = Nothing
        limpiarCajasYEstiquetas()
        LimpiarVariables()
        limpiarDataTables()
        LimpiarUltracombos()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If IdInventario < 1 Then
            Dim formaAdvetencia As New AdvertenciaForm
            formaAdvetencia.mensaje = "Debes seleccionar un inventario antes de dar click en editar"
            formaAdvetencia.StartPosition = FormStartPosition.CenterScreen
            formaAdvetencia.ShowDialog()
        ElseIf IdEstado > 1 Then
            Dim formaAdvetencia As New AdvertenciaForm
            If IdEstado = 2 Then
                formaAdvetencia.mensaje = "Este inventario está en proceso, no es posible editarlo"
            ElseIf IdEstado = 3 Then
                formaAdvetencia.mensaje = "Este inventario fue finalizado, no es posible editarlo"
            Else
                formaAdvetencia.mensaje = "Este inventario fue cancelado, es imposible editarlo"
            End If
            formaAdvetencia.StartPosition = FormStartPosition.CenterScreen
            formaAdvetencia.ShowDialog()
        Else
            Dim AgregarInventario As New AltaInventarioCiclicoForm
            With AgregarInventario
                '.nave_almacen = CStr(cmbNave.SelectedValue) + "," + CStr(cmbAlmacen.Text)
                .nave_almacen = "43, 1"
                .IdInventarioCiclico = IdInventario
                .Descripcion = Desccripcion
                .IdOperador = IdOperador
                .fechaInicio = Fecha
                .Editar = True
                .ShowDialog()
                grdInventariosCiclicos.DataSource = Nothing
                limpiarCajasYEstiquetas()
                LimpiarVariables()
                limpiarDataTables()
                LimpiarUltracombos()
                grdInventariosCiclicos.DataSource = Nothing
            End With

            limpiarCajasYEstiquetas()
            LimpiarVariables()
            limpiarDataTables()
            LimpiarUltracombos()
            LlenarListaInventarios()
        End If



    End Sub

    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        cmsImprimir.Show(btnImprimirReporte, 0, btnImprimirReporte.Height)
    End Sub


    ''' <summary>
    ''' FUNCION QUE SUMA LOS TOTALES EN LAS COLUMNAS DE PARES EN EL DATATABLE RECUPERADO PARA POBLAR EL GRID, Y ASIGNARLO A LA COLUMNA DE TOTALES ENCONTRADOS
    ''' </summary>
    ''' <param name="dtInventario">DATATABLE EN EL CULA SE RECUPERAN LOS DATOS Y SE AGREGARA LA SUMATORIA DE LOS PARES ENCONTRADOS</param>
    ''' <returns>DATATABLE MODIFICADO</returns>
    ''' <remarks></remarks>
    Public Function AgregarTotalParesAlReporte(ByVal dtInventario As DataTable)
        Dim TotalesPares As Integer = 0
        For Each row As DataRow In dtInventario.Rows
            TotalesPares = row.Item("12") + row.Item("12½") + row.Item("13") + row.Item("13½") + row.Item("14") + row.Item("14½") + row.Item("15") + row.Item("15½") + row.Item("16") + row.Item("16½") + row.Item("17") + _
            row.Item("17½") + row.Item("18") + row.Item("18½") + row.Item("19") + row.Item("19½") + row.Item("20") + row.Item("20½") + row.Item("21") + row.Item("21½") + row.Item("22") + row.Item("22½") + row.Item("23") + _
            row.Item("23½") + row.Item("24") + row.Item("24½") + row.Item("25") + row.Item("25½") + row.Item("26") + row.Item("26½") + row.Item("27") + row.Item("27½") + row.Item("28") + row.Item("28½") + row.Item("29") + _
            row.Item("29½") + row.Item("30") + row.Item("30½") + row.Item("31") + row.Item("31½") + row.Item("32")
            row.Item(4) = TotalesPares.ToString
            TotalesPares = 0
        Next
        Return dtInventario
    End Function

    ''' <summary>
    ''' FUNCION QUE PERMITE RECUPERAR TABLA CON EL TOTAL DE PARES ENCONTRADOS EN UN INVENTARIO Y ASIGNARLO A UN DATASET
    ''' </summary>
    ''' <returns>DATASET CON LA TABLA CON LOS DATOS DE PARES Y TOTALES ENCONTRADOS PARA CREAR EL REPORTE DE RESUMEN DE INVENTARIO</returns>
    ''' <remarks></remarks>
    Private Function ResumenInventario()
        'Dim dtRecuperar As New DataTable
        Dim dtInventarioCiclico As New DataTable
        'Dim dtCorridasAVerificar As New DataTable
        Dim objBU As New Negocios.InventarioCiclicoBU
        Dim dsDetalles As New DataSet("dsInventario")
        dtInventarioCiclico = objBU.ResumenInventario(IdInventario)
        dtInventarioCiclico.TableName = "dtCorrida5"
        dtInventarioCiclico = AgregarTotalParesAlReporte(dtInventarioCiclico)
        dsDetalles.Tables.Add(dtInventarioCiclico)
        Return dsDetalles
    End Function

    ''' <summary>
    ''' METODO PARA IMPRIMIR EL REPORTE DE RESUMEN DE UBICACION DE INVENTARIO CÍCLICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ImprimirResumenInventario()
        Dim dsInventario As New DataSet
        dsInventario = ResumenInventario()
        Me.Cursor = Cursors.WaitCursor
        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("ALM_INV_RES")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        'reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idnave)
        'reporte("nombreNave") = cmbNave.Text
        reporte("nombreNave") = "Comercializadora"
        reporte("NombreReporte") = "SAY: RESUMEN_UBICACION_ICI.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Operador") = NombreOperador
        reporte("Fecha de Ejecucion") = Fecha
        reporte("InventarioCiclicoNombre") = Desccripcion
        reporte("IdInventario") = IdInventario.ToString
        reporte("TotalPares") = TotalPares
        reporte("inv_n") = "*" + IdInventario.ToString + "*"
        reporte("Inventario_n") = "no. " + IdInventario.ToString
        reporte.Dictionary.Clear()
        reporte.RegData(dsInventario.DataSetName, dsInventario)
        reporte.Dictionary.Synchronize()

        reporte.Show()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub RESUMENUBICACIONPARESINVENTARIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RESUMENUBICACIONPARESINVENTARIOToolStripMenuItem.Click
        If IdInventario <= 0 Then
            show_message("Advertencia", "Selecciona un inventario cíclico para poder imprimir el resumen de ubicación de sus pares.")
        Else
            Dim dtResumen As New DataTable
            ImprimirResumenInventario()
        End If

    End Sub

    Private Sub tsmReporteInventario_Click(sender As Object, e As EventArgs) Handles tsmReporteInventario.Click
        If IdInventario <= 0 Then
            show_message("Advertencia", "Selecciona un inventario cíclico para poder imprimir el reporte de resultado del inventario.")
        ElseIf IdEstado = 3 Then
            ImprimirResultadoInventario()
        Else
            show_message("Advertencia", "Solo se puede generar este reporte para inventarios concluidos.")
        End If
    End Sub

    ''' <summary>
    ''' METODO PARA IMPRIMIR EL REPORTE DE RESUMEN DE RESULTADOS DE INVENTARIO CÍCLICO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ImprimirResultadoInventario()
        Dim dsResultadoInventario As New DataSet
        Me.Cursor = Cursors.WaitCursor
        dsResultadoInventario = InventarioResultado(dsResultadoInventario)

        Dim OBJBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = OBJBU.LeerReporteporClave("ALM_INV_RESULTADO")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        'reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idnave)
        'reporte("nombreNave") = cmbNave.Text
        reporte("nombreNave") = "Comercializadora"
        reporte("NombreReporte") = "SAY: RESUMEN_RESULTADO_ICI.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Operador") = NombreOperador
        reporte("Fecha de ejecución") = FechaReal
        reporte("Descripción") = Desccripcion
        reporte("IdInventario") = IdInventario.ToString
        reporte("TotalPares") = TotalPares
        reporte("Faltantes") = faltantes
        reporte("Sobrantes") = Sobrantes
        reporte("TotalEncontrado") = Encontrados

        reporte.Dictionary.Clear()
        reporte.RegData(dsResultadoInventario.DataSetName, dsResultadoInventario)
        reporte.Dictionary.Synchronize()
        reporte.Show()

        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' FUNCION PARA RECUPERAR LA TABLA DE PARES BIEN Y LA TABLA DE PARES MAL DE UN INVENTARIO Y AGREGARLOS A UN DATASET PARA USARLOS EN LA CREACION DEL REPORTE
    ''' DE RESUMEN DE RESULTADO DE INVENTARIO CÍCLICO
    ''' </summary>
    ''' <param name="dsResultadoInventario"></param>
    ''' <returns>DATASET CON LA TABLA DE PARES BIEN Y LA TABLA DE PARES MAL</returns>
    ''' <remarks></remarks>
    Public Function InventarioResultado(ByVal dsResultadoInventario As DataSet)
        Dim objBU As New Negocios.InventarioCiclicoBU
        Dim dtResultadoInventario As New DataTable
        Dim dtSobrantesInventario As New DataTable
        'Recuperamos el resultado de los pares pertenecientes al inventario
        dtResultadoInventario = objBU.ImprimirReporteResultadoInventario(IdInventario)
        dtResultadoInventario = AgregarTotal_Encontrados(dtResultadoInventario)
        dtResultadoInventario.TableName = "dtResultadoInventario"
        dsResultadoInventario.Tables.Add(dtResultadoInventario)

        'recuperamos los datos de los pares que sobraron en el inventario
        dtSobrantesInventario = objBU.ImprimirSobrantesInventario(IdInventario)
        dtSobrantesInventario = AgregarTotal_Encontrados(dtSobrantesInventario)
        dtSobrantesInventario.TableName = "dtSobrantesInventario"
        dsResultadoInventario.Tables.Add(dtSobrantesInventario)
        Return dsResultadoInventario
    End Function

    ''' <summary>
    ''' FUNCION PARA SUMAR EL TOTAL DE PARES ENCONTRADOS POR CORRIDAS EN UN INVENTARIO CICLICO , PARES FALTANTES Y PARES QUE SE SUPONE QUE DEBERIA DE ENCONTRAR, 
    ''' Y AGREGARLO A LA COLUMNA DE TOTALES ENCONTRADOS DEL DATATABLE
    ''' </summary>
    ''' <param name="dtInventario">ID DEL INVENTARIO EN EL QUE SE BUSCARAN LOS PARES POR CORRIDA</param>
    ''' <returns>TABLA MODIFICADA CON EL CAMPO DE TOTALES ENCONTRADOS (POR CORRIDA) DE DETERMINADO INVENTARIO CÍCLICO</returns>
    ''' <remarks></remarks>
    Public Function AgregarTotal_Encontrados(ByVal dtInventario As DataTable) As DataTable
        Dim totalesParesDDC As Integer = 0
        For Each row As DataRow In dtInventario.Rows
            Dim objBU As New Negocios.InventarioCiclicoBU
            Dim dtEncontrados As New DataTable
            Dim Ubicacion As String = row.Item("Ubicación")
            Dim atado As String = row.Item("Atado")
            Dim Faltantes As Integer = 0
            ''Sumamos los tales de pares que se supone deberia de haber en cada corrida
            totalesParesDDC = row.Item("12") + row.Item("12½") + row.Item("13") + row.Item("13½") + row.Item("14") + row.Item("14½") + row.Item("15") + row.Item("15½") + row.Item("16") + row.Item("16½") + row.Item("17") + _
            row.Item("17½") + row.Item("18") + row.Item("18½") + row.Item("19") + row.Item("19½") + row.Item("20") + row.Item("20½") + row.Item("21") + row.Item("21½") + row.Item("22") + row.Item("22½") + row.Item("23") + _
            row.Item("23½") + row.Item("24") + row.Item("24½") + row.Item("25") + row.Item("25½") + row.Item("26") + row.Item("26½") + row.Item("27") + row.Item("27½") + row.Item("28") + row.Item("28½") + row.Item("29") + _
            row.Item("29½") + row.Item("30") + row.Item("30½") + row.Item("31") + row.Item("31½") + row.Item("32")
            ''Asignamos los pares a su campo correspondiente
            row.Item("total") = totalesParesDDC.ToString

            ''Recuperamos el codigo de par en caso de que sea un par lo que regreso la consulta
            If totalesParesDDC = 1 Then
                Dim CodigoPar As String = objBU.RecuperarCodigoPar(IdInventario, atado, Ubicacion)
                row.Item("Par").GetType()
                row.Item("Par") = CodigoPar
            End If

            ''recuperamos los totales encontrados en realidad.
            Dim Encontrados As Integer = objBU.RecuperarEncontrados(IdInventario, atado, Ubicacion)
            row.Item("Encontrados") = Encontrados
            ''Calculamos los faltantes
            Faltantes = totalesParesDDC - Encontrados
            row.Item("Faltantes") = Faltantes.ToString
        Next

        Return dtInventario
    End Function

    Private Sub tsmReporteInventarios_Click(sender As Object, e As EventArgs) Handles tsmReporteInventarios.Click
        Dim dsResumenInventarios As New DataSet
        'LLENA EL DATASET
        dsResumenInventarios = RecuperarTablasReporteTartaInventarios()
        'IMPRIME EL REPORTE
        Imprimir_ReporteIndicadoresDeInventatiosCiclicos(dsResumenInventarios)
    End Sub

    ''' <summary>
    ''' RECUPERA DOS TABLAS QUE SE UTILZARAN EN EL "REPORTE DE INDICADORES DE INVENTARIOS CICLICOS" LA PRIMERA PARA EL 
    ''' GRAFICO DE RESULTADOS POR INVENTARIO Y LA SEGUNDA PARA LA GRAFICA DE RESULTADOS POR PARES 
    ''' </summary>
    ''' <returns>DATASET CON DOS TABLAS PARA LA ELABORACION DE LAS GRAFICAS EN EL REPORTE</returns>
    ''' <remarks></remarks>
    Private Function RecuperarTablasReporteTartaInventarios() As DataSet
        Dim dsResumenInventarios As New DataSet
        Dim dtInventarios As New DataTable
        Dim dtPares As New DataTable
        Dim IdInventarios As String
        Dim objBU As New Negocios.InventarioCiclicoBU
        dtInventarios = objBU.TotaLInventariosLevantados
        dtInventarios.TableName = "dtInventarios"
        'CALCULAR PROCENTAJES DE LAS CANTIDADES OBTENIDAS
        For Each row As DataRow In dtInventarios.Rows
            If row.Item(0) > 0 Then
                row.Item(2) = (100 / row.Item(0) * row.Item(1))
                row.Item(4) = (100 / row.Item(0) * row.Item(3))
            End If
        Next

        dsResumenInventarios.Tables.Add(dtInventarios)
        'Recuperamos los ids de los inventarios ciclicos que estan en estado "Concluido" para recuperar los pares que contiene cada inventario
        IdInventarios = objBU.RecuperarIdsInvCi
        'Consultamos los pares de los inventarios ciclicos recuperados
        dtPares = objBU.TotalParesConsultados(IdInventarios)
        'CALCULAR PROCENTAJES DE LAS CANTIDADES OBTENIDAS
        For Each row As DataRow In dtPares.Rows
            row.Item(2) = (100 / row.Item(0) * row.Item(1))
            row.Item(4) = (100 / row.Item(0) * row.Item(3))
        Next
        dtPares.TableName = ("dtPares")
        dsResumenInventarios.Tables.Add(dtPares)
        Return dsResumenInventarios
    End Function

    Public Sub Imprimir_ReporteIndicadoresDeInventatiosCiclicos(ByVal dsResumenInventarios As DataSet)
        Dim objBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = objBU.LeerReporteporClave("ALM_INV_REPORTEINDICADORES")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreReporte") = "SAY: REPORTE_DE_INDICADORES_INVCI.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Operador") = NombreOperador
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(idnave)
        reporte("nombreNave") = "Comercializadora"
        reporte.Dictionary.Clear()
        reporte.RegData(dsResumenInventarios.DataSetName, dsResumenInventarios)
        reporte.Dictionary.Synchronize()
        reporte.Show()
        Me.Cursor = Cursors.Default
       
    End Sub

    Private Sub btnResultados_Click(sender As Object, e As EventArgs) Handles btnResultados.Click
        If IdEstado <> 3 Then
            show_message("Advertencia", "Selecciona un inventario finalizado para poder abrir la ventana de resultados.")
        Else
            Dim AgregarInventario As New AltaInventarioCiclicoForm
            With AgregarInventario
                '.nave_almacen = CStr(cmbNave.SelectedValue) + "," + CStr(cmbAlmacen.Text)
                .nave_almacen = "43, 1"
                .IdInventarioCiclico = IdInventario
                .EstadoInventario = IdEstado
                .Descripcion = Desccripcion
                .IdOperador = IdOperador
                .fechaInicio = FechaReal.ToString
                .ResultadoDeInventario = True
                .Totalpares = TotalPares
                .faltantes = faltantes
                .encontrados = Encontrados
                .sobrantes = Sobrantes
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub btnIniciar_Click(sender As Object, e As EventArgs) Handles btnIniciar.Click
        If IdEstado < 1 Then
            show_message("Advertencia", "Seleccione un inventario para poder iniciarlo.")
        ElseIf IdEstado > 1 Then
            Dim mensaje As String
            If IdEstado = 2 Then
                mensaje = "Este inventario está en proceso, no es posible iniciarlo."
            ElseIf IdEstado = 3 Then
                mensaje = "Este inventario fue finalizado, no es posible iniciarlo."
            Else
                mensaje = "Este inventario fue cancelado, es imposible iniciarlo."
            End If
            show_message("Advertencia", mensaje)
        Else
            Dim frmConfirmar As New ConfirmarForm
            frmConfirmar.mensaje = "¿Estas seguro que deseas iniciar este Inventario Cíclico?."
            frmConfirmar.StartPosition = FormStartPosition.CenterScreen
            If frmConfirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                IniciarInventarioCiclico()
                Me.Cursor = Cursors.Default
                limpiarCajasYEstiquetas()
                limpiarDataTables()
                LimpiarUltracombos()
                LimpiarVariables()
                grdInventariosCiclicos.DataSource = Nothing
            End If
        End If
    End Sub

    ''' <summary>
    ''' PRIMERO VERIFICA QUE EL USUARIO QUE TRATA DE INICIAR UN INVENTARIO CICLICO NO TENGO MAS INVENTARIOS EN PROCESO Y DESPUES DE VALIDAR QUE NO TIENE
    ''' INVENTARIO PENDIENTES VERIFICA QUE EL USUARIO QUE TRATA DE INICIAR ESTE ASIGNADO PARA EL USUARIO LOGGEADO
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IniciarInventarioCiclico()
        Dim objBU As New Negocios.InventarioCiclicoBU
        If objBU.VerificarInventariosEnProcesoUsuarioLoggueado() = False Then
            Dim UsuarioCalificado As Boolean
            Try
                UsuarioCalificado = objBU.IniciarInventarioCiclico(IdInventario)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            If UsuarioCalificado = False Then
                show_message("Advertencia", "No esta calificado para iniciar este inventario ya que esta asignado a otro operador.")
            End If
        Else
            show_message("Advertencia", "No es posible iniciar este inventario ya que aun tiene un inventario cíclico por concluir.")
        End If
    End Sub

End Class