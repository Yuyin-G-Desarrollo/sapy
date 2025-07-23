Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports System.Globalization
Imports System.Text

Public Class PedidosMuestras_EntradasSalidas_Consultas
    Dim listInicial As New List(Of String)
    Dim listPiezas As New List(Of String)
    Dim listPedidos As New List(Of Integer)
    Dim RestriccionNave As Boolean = False
    Dim NavesRestriccion As String = String.Empty


#Region "Boton Mostrar Mas"
    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "NAVES"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridNaves.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridNaves.DataSource = listado.listParametros
        With gridNaves
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim listado As New ListadoParametroForm
        If cboxNaveCedis.Text <> "" Then
            listado.tipo_busueda_str = "CLIENTES"
            listado.cedisId = cboxNaveCedis.SelectedValue
            Dim listaParametroID As New List(Of String)
            For Each row As UltraGridRow In gridClientes.Rows
                Dim parametro As String = row.Cells(1).Text
                listaParametroID.Add(parametro)
            Next
            listado.listaParametroID = listaParametroID
            listado.ShowDialog(Me)
            If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
            If listado.listParametros.Rows.Count = 0 Then Return
            gridClientes.DataSource = listado.listParametros
            With gridClientes
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Hidden = True

                .DisplayLayout.Bands(0).Columns(3).Header.Caption = "Clientes"
            End With
        Else
            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario seleccionar un cedis.")
        End If

    End Sub
    Private Sub bntArticulos_Click(sender As Object, e As EventArgs) Handles bntArticulos.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "ARTICULOS"
        Dim listaParametroID As New List(Of String)
        'For Each row As UltraGridRow In gridArticulos.Rows
        '    Dim parametro As String = row.Cells(1).Text
        '    listaParametroID.Add(parametro)
        'Next
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
    Private Sub btnCorridas_Click(sender As Object, e As EventArgs) Handles btnCorridas.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "CORRIDAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridCorridas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridCorridas.DataSource = listado.listParametros
        With gridCorridas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Corridas"
        End With
    End Sub
    Private Sub btnTallas_Click(sender As Object, e As EventArgs) Handles btnTallas.Click
        Dim listado As New ListadoParametroForm
        listado.tipo_busueda_str = "TALLAS"
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In gridTallas.Rows
            Dim parametro As String = row.Cells(1).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        gridTallas.DataSource = listado.listParametros
        With gridTallas
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            '.DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Tallas"
        End With
    End Sub
#End Region
#Region "Inicializa Layout"
    Private Sub gridNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridNaves.InitializeLayout
        grid_diseño(gridNaves)
        gridNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub
    Private Sub gridClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridClientes.InitializeLayout
        grid_diseño(gridClientes)
        gridClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub
    Private Sub gridArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridArticulos.InitializeLayout
        grid_diseño(gridArticulos)
        gridArticulos.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Articulos"
    End Sub
    Private Sub gridTallas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridTallas.InitializeLayout
        grid_diseño(gridTallas)
        gridTallas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tallas"

    End Sub
    Private Sub gridCorridas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCorridas.InitializeLayout
        grid_diseño(gridCorridas)
        gridCorridas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corridas"
    End Sub
    Private Sub gridCodigosDePiezas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridCodigosDePiezas.InitializeLayout
        grid_diseño(gridCodigosDePiezas)
        gridCodigosDePiezas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Código de pieza"
    End Sub
    Private Sub gridPedidosMuestras_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles gridPedidosMuestras.InitializeLayout
        grid_diseño(gridPedidosMuestras)
        gridPedidosMuestras.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedidos de Muestras"
    End Sub

#End Region
#Region "Eventos Presionar Tecla Grids"
    Private Sub gridNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles gridNaves.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridNaves.DeleteSelectedRows(False)
    End Sub
    Private Sub gridClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles gridClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridClientes.DeleteSelectedRows(False)
    End Sub
    Private Sub gridArticulos_KeyDown(sender As Object, e As KeyEventArgs) Handles gridArticulos.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridArticulos.DeleteSelectedRows(False)
    End Sub

    Private Sub gridTallas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridTallas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridTallas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCorridas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCorridas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCorridas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridCodigosDePiezas_KeyDown(sender As Object, e As KeyEventArgs) Handles gridCodigosDePiezas.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridCodigosDePiezas.DeleteSelectedRows(False)
    End Sub

    Private Sub gridPedidosMuestras_KeyDown(sender As Object, e As KeyEventArgs) Handles gridPedidosMuestras.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        gridPedidosMuestras.DeleteSelectedRows(False)
    End Sub


#End Region
#Region "Eventos Presionar Tecla TextBox"
    Private Sub txtCodigosPieza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigosPieza.KeyPress
        'Verdadero no escribe
        e.Handled = ValidacionesDatos.soloNumeros(sender, e)
    End Sub
    Private Sub txtCodigosPieza_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigosPieza.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
            Dim dtResultado As DataTable
            Dim cedisid As Integer = 0
            If cboxNaveCedis.Text <> "" Then
                cedisid = cboxNaveCedis.SelectedValue
                dtResultado = objBU.ConsultaTablaFiltros("PIEZAS", cedisid, txtCodigosPieza.Text.Trim.ToString)
                If dtResultado.Rows.Count > 0 Then
                    If cedisid = dtResultado.Rows(0).Item(0) Then
                        listPiezas.Add(txtCodigosPieza.Text.Trim)
                        gridCodigosDePiezas.DataSource = Nothing
                        gridCodigosDePiezas.DataSource = listPiezas
                        txtCodigosPieza.Clear()
                    Else
                        Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La pieza no corresponde al cedis " + cboxNaveCedis.Text)
                        txtCodigosPieza.Text = ""
                    End If
                End If
            Else
                Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Es necesario seleccionar un cedis.")
                txtCodigosPieza.Text = ""
            End If
        End If
    End Sub
    Private Sub txtPedidosMuestra_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidosMuestra.KeyPress
        'Verdadero no escribe
        e.Handled = ValidacionesDatos.soloNumeros(sender, e)
    End Sub
    Private Sub txtPedidosMuestra_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPedidosMuestra.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
            Dim dtResultado As DataTable
            dtResultado = objBU.ConsultaTablaFiltros("PEDIDOS", txtPedidosMuestra.Text.Trim.ToString)
            If Not IsNothing(dtResultado) Then
                If dtResultado.Rows.Count > 0 Then
                    If CInt(dtResultado.Rows(0).Item("RESULTADO")) > 0 Then
                        listPedidos.Add(CInt(txtPedidosMuestra.Text.Trim))
                        gridPedidosMuestras.DataSource = Nothing
                        gridPedidosMuestras.DataSource = listPedidos
                        txtPedidosMuestra.Clear()
                    Else
                        Controles.Mensajes_Y_Alertas("INFORMACION", "Pedido de muestra invalido.")
                    End If
                End If
            End If
        End If
    End Sub
#End Region
#Region "Diseño Grid"
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
            .Override.AllowRowFiltering = DefaultableBoolean.True
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub
    ''Asigna formato a columnas de ultragrid
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

                If col.Header.Caption.Equals("TELÉFONO") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next

    End Sub

#End Region
#Region "Eventos Form"
    Private Sub PedidosMuestras_EntradasSalidas_Consultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'gridNaves.DataSource = listInicial
        gridClientes.DataSource = listInicial
        gridArticulos.DataSource = listInicial
        gridCorridas.DataSource = listInicial
        gridTallas.DataSource = listInicial
        gridCodigosDePiezas.DataSource = listInicial
        gridPedidosMuestras.DataSource = listInicial

        Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
        Dim dtNaves As New DataTable
        Dim cedisId As Integer = 0
        'cargaComboCedis()
        'Utilerias.ComboObtenerCEDISUsuario(cboxNaveCedis)
        If cboxNaveCedis.Text = "COMERCIALIZADORA" Then
            cedisId = 43
        Else
            cedisId = 82
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CONSULTAS_DE_ENVIO_Y_RECEPCION_DE_MUESTRAS", "RESTRICCION_NAVES") Then
            RestriccionNave = True

            dtNaves = objBU.ConsultaTablaFiltros("NAVES", cedisId, Entidades.SesionUsuario.UsuarioSesion.PUserUsername)
            If Not IsNothing(dtNaves) Then
                If dtNaves.Rows.Count > 0 Then
                    NavesRestriccion = GeneraCadenaFiltro(dtNaves, 1)
                    gridNaves.DataSource = dtNaves
                    With gridNaves
                        .DisplayLayout.Bands(0).Columns(0).Hidden = True
                        .DisplayLayout.Bands(0).Columns(1).Hidden = True
                        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
                    End With

                End If
            End If
        Else
            gridNaves.DataSource = listInicial
        End If
    End Sub
    Private Sub cargaComboCedis()
        Dim objNeg As New Negocios.EntradaSalidaMuestrasBU
        Dim dtCedis As New DataTable
        dtCedis = objNeg.obtenerCedisNaves
        dtCedis.Rows.InsertAt(dtCedis.NewRow, 0)
        If cboxNaveCedis.Text = "" Then
            cboxNaveCedis.DisplayMember = "cedis"
            cboxNaveCedis.ValueMember = "naveId"
            cboxNaveCedis.DataSource = dtCedis
        End If
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        gridNaves.DataSource = Nothing
        gridClientes.DataSource = Nothing
        gridArticulos.DataSource = Nothing
        gridCorridas.DataSource = Nothing
        gridTallas.DataSource = Nothing
        gridCodigosDePiezas.DataSource = Nothing
        gridPedidosMuestras.DataSource = Nothing
        chkFentregaNave.Checked = False
        chkFentregaCliente.Checked = False
        chkFEnvioDeNave.Checked = False
        chkFRecepcionComer.Checked = False
        dtpFentregaNaveDel.Value = Date.Now
        dtpFEntregaNaveAl.Value = Date.Now
        dtpFEntregaClienteDel.Value = Date.Now
        dtpFEntregaClienteAl.Value = Date.Now
        dtpEnvioDeNaveDel.Value = Date.Now
        dtpEnvioDeNaveAl.Value = Date.Now
        dtpRecepcionComerDel.Value = Date.Now
        dtpRecepcionComerAl.Value = Date.Now

        chkMarcaColeccionTemp.Checked = False
        chkPielColor.Checked = False
        chkModelo.Checked = False
        chkCorrida.Checked = False


        gridNaves.DataSource = listInicial
        gridClientes.DataSource = listInicial
        gridArticulos.DataSource = listInicial
        gridCorridas.DataSource = listInicial
        gridTallas.DataSource = listInicial
        gridCodigosDePiezas.DataSource = listInicial
        gridPedidosMuestras.DataSource = listInicial
        cboxNaveCedis.Text = ""
        rdbMuestrasPorNave.Checked = False
        pnAgrupamiento.Visible = False
    End Sub
    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cboxNaveCedis.Text <> "" Then
            If chkFentregaNave.Checked Then
                If CDate(dtpFentregaNaveDel.Value.ToShortDateString) > CDate(dtpFEntregaNaveAl.Value.ToShortDateString) Then
                    Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                    dtpFentregaNaveDel.Focus()
                    Exit Sub
                End If
            End If
            If chkFentregaCliente.Checked Then
                If CDate(dtpFEntregaClienteDel.Value.ToShortDateString) > CDate(dtpFEntregaClienteAl.Value.ToShortDateString) Then
                    Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                    dtpFEntregaClienteDel.Focus()
                    Exit Sub
                End If
            End If
            If chkFentregaNave.Checked Then
                If CDate(dtpEnvioDeNaveDel.Value.ToShortDateString) > CDate(dtpEnvioDeNaveAl.Value.ToShortDateString) Then
                    Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                    dtpEnvioDeNaveDel.Focus()
                    Exit Sub
                End If
            End If
            If chkFRecepcionComer.Checked Then
                If CDate(dtpRecepcionComerDel.Value.ToShortDateString) > CDate(dtpRecepcionComerAl.Value.ToShortDateString) Then
                    Controles.Mensajes_Y_Alertas("ADVERTENCIA", "La fecha inicial no puede ser mayor a la fecha final.")
                    dtpRecepcionComerDel.Focus()
                    Exit Sub
                End If
            End If


            Dim Operador As String = String.Empty
            Dim Naves As String
            Dim Piezas As String
            Dim Clientes As String
            Dim PedidosM As String
            Dim Articulos As String
            Dim Corridas As String
            Dim tallas As String
            Dim strFEntregaNave As String = ""
            Dim strFEntregaCliente As String = ""
            Dim strFEnvioDeNave As String = ""
            Dim strFRecepcionComer As String = ""
            Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
            Dim cedisIdNave As String = ""

            Try
                Cursor = Cursors.WaitCursor
                If rdbY.Checked Then
                    Operador = "AND"
                ElseIf rdbO.Checked Then
                    Operador = "OR"
                End If

                If RestriccionNave Then
                    If gridNaves.Rows.Count > 0 Then
                        Naves = GeneraCadenaFiltro(gridNaves, 1)
                    Else
                        Naves = NavesRestriccion
                    End If
                Else
                    Naves = GeneraCadenaFiltro(gridNaves, 1)
                End If

                Piezas = GeneraCadenaFiltro(gridCodigosDePiezas, 0)
                Clientes = GeneraCadenaFiltro(gridClientes, 1)
                PedidosM = GeneraCadenaFiltro(gridPedidosMuestras, 0)
                Articulos = GeneraCadenaFiltro(gridArticulos, 1)
                Corridas = GeneraCadenaFiltro(gridCorridas, 1)
                tallas = GeneraCadenaFiltro(gridTallas, 1)
                If cboxNaveCedis.Text = "COMERCIALIZADORA" Then
                    cedisIdNave = 43
                ElseIf cboxNaveCedis.Text = "REEDITION" Then
                    cedisIdNave = 82

                End If


                If chkFentregaNave.Checked Then
                    strFEntregaNave = dtpFentregaNaveDel.Value.ToShortDateString + "," + dtpFEntregaNaveAl.Value.ToShortDateString
                End If
                If chkFentregaCliente.Checked Then
                    strFEntregaCliente = dtpFEntregaClienteDel.Value.ToShortDateString + "," + dtpFEntregaClienteAl.Value.ToShortDateString
                End If
                If chkFEnvioDeNave.Checked Then
                    strFEnvioDeNave = dtpEnvioDeNaveDel.Value.ToShortDateString + "," + dtpEnvioDeNaveAl.Value.ToShortDateString
                End If
                If chkFRecepcionComer.Checked Then
                    strFRecepcionComer = dtpRecepcionComerDel.Value.ToShortDateString + "," + dtpRecepcionComerAl.Value.ToShortDateString
                End If
                If rdbDetalladaPorPieza.Checked Then
                    Dim dtDetallada As DataTable
                    dtDetallada = objBU.ConsultaDetallada(False, Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, tallas,
                                                          strFEntregaNave, strFEntregaCliente, strFEnvioDeNave, strFRecepcionComer, cedisIdNave)
                    Cursor = Cursors.Default
                    If dtDetallada.Rows.Count > 0 Then
                        Dim form As New ConsultaDetalladaForm
                        form.DataConsulta = dtDetallada
                        form.Operador = Operador
                        form.Naves = Naves
                        form.Piezas = Piezas
                        form.Clientes = Clientes
                        form.PedidosM = PedidosM
                        form.Articulos = Articulos
                        form.Corridas = Corridas
                        form.tallas = tallas
                        form.strFEntregaNave = strFEntregaNave
                        form.strFEntregaCliente = strFEntregaCliente
                        form.strFEnvioDeNave = strFEnvioDeNave
                        form.strFRecepcionComer = strFRecepcionComer
                        form.nombreCedis = cboxNaveCedis.Text
                        form.ShowDialog()
                    Else
                        Controles.Mensajes_Y_Alertas("INFORMACION", "La consulta actual no contiene registros")
                    End If
                ElseIf rdbResumenDeProductos.Checked Then
                    Dim dtResumenP As DataTable
                    dtResumenP = objBU.ConsultaResumenProductos(Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, tallas,
                                                          strFEntregaNave, strFEntregaCliente, strFEnvioDeNave, strFRecepcionComer, cedisIdNave)
                    Cursor = Cursors.Default
                    If dtResumenP.Rows.Count > 0 Then
                        Dim form As New ResumenProductosForm
                        form.DataConsulta = dtResumenP
                        form.Operador = Operador
                        form.Naves = Naves
                        form.Piezas = Piezas
                        form.Clientes = Clientes
                        form.PedidosM = PedidosM
                        form.Articulos = Articulos
                        form.Corridas = Corridas
                        form.tallas = tallas
                        form.strFEntregaNave = strFEntregaNave
                        form.strFEntregaCliente = strFEntregaCliente
                        form.strFEnvioDeNave = strFEnvioDeNave
                        form.strFRecepcionComer = strFRecepcionComer
                        form.cedisNombre = cboxNaveCedis.Text
                        form.TipoConsulta = "RESUMEN_DE_PRODUCTOS"
                        form.ShowDialog()
                    Else
                        Controles.Mensajes_Y_Alertas("INFORMACION", "La consulta actual no contiene registros")
                    End If
                ElseIf rdbMuestrasPorNave.Checked Then
                    Dim dtMuestasPorNave As DataTable
                    dtMuestasPorNave = objBU.ConsultaMuestrasPorNave(chkMarcaColeccionTemp.Checked, chkModelo.Checked, chkPielColor.Checked, chkCorrida.Checked, Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, tallas,
                                                          strFEntregaNave, strFEntregaCliente, strFEnvioDeNave, strFRecepcionComer, cedisIdNave)
                    Cursor = Cursors.Default
                    If dtMuestasPorNave.Rows.Count > 0 Then
                        Dim form As New ResumenProductosForm
                        form.DataConsulta = dtMuestasPorNave
                        form.Operador = Operador
                        form.Naves = Naves
                        form.Piezas = Piezas
                        form.Clientes = Clientes
                        form.PedidosM = PedidosM
                        form.Articulos = Articulos
                        form.Corridas = Corridas
                        form.tallas = tallas
                        form.strFEntregaNave = strFEntregaNave
                        form.strFEntregaCliente = strFEntregaCliente
                        form.strFEnvioDeNave = strFEnvioDeNave
                        form.strFRecepcionComer = strFRecepcionComer
                        form.MarcaColeccionTemp = chkMarcaColeccionTemp.Checked
                        form.Modelo = chkModelo.Checked
                        form.PielColor = chkPielColor.Checked
                        form.Corrida = chkCorrida.Checked
                        form.cedisNombre = cboxNaveCedis.Text
                        form.TipoConsulta = "MUESTRAS_POR_NAVE"
                        form.ShowDialog()
                    Else
                        Controles.Mensajes_Y_Alertas("INFORMACION", "La consulta actual no contiene registros")
                    End If

                End If
            Catch ex As Exception
                Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
            Finally
                Cursor = Cursors.Default
            End Try
        Else
            Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Falta seleccionar un cedis")
        End If
    End Sub
    Private Sub rdbMuestrasPorNave_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMuestrasPorNave.CheckedChanged
        If pnAgrupamiento.Visible Then
            pnAgrupamiento.Visible = False
        Else
            pnAgrupamiento.Visible = True

        End If
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()

    End Sub
#End Region

    Private Function GeneraCadenaFiltro(ByVal grid As UltraGrid, ByVal index As Integer) As String
        Dim sb As New StringBuilder
        Try
            For Each row As UltraGridRow In grid.Rows
                sb.Append(row.Cells(index).Value.ToString)
                sb.Append(",")
            Next

            If sb.Length > 0 Then
                sb.Remove(sb.Length - 1, 1)
            End If
            GeneraCadenaFiltro = sb.ToString
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
            GeneraCadenaFiltro = ""
        End Try
    End Function


    Private Function GeneraCadenaFiltro(ByVal data As DataTable, ByVal index As Integer) As String
        Dim sb As New StringBuilder
        Try
            For Each row As DataRow In data.Rows
                sb.Append(row.Item(index).ToString)
                sb.Append(",")
            Next

            If sb.Length > 0 Then
                sb.Remove(sb.Length - 1, 1)
            End If
            GeneraCadenaFiltro = sb.ToString
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
            GeneraCadenaFiltro = ""
        End Try
    End Function



End Class