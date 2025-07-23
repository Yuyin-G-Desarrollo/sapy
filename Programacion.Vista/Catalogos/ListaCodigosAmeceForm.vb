Imports Tools.Controles
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.SupportDialogs.FilterUIProvider

Public Class ListaCodigosAmeceForm


    Private Sub ListaCodigosAmeceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        RecuperarUltimoCodigoAmeceGenerado()
        comboClientes_CodigosAMECE(cmbCliente)

    End Sub


    Private Sub RecuperarUltimoCodigoAmeceGenerado()
        Dim objBU As New Negocios.CodigosAMECEBU
        Dim dtCodigo As New DataTable
        Dim Codigo As String
        Dim Consecutivo As String

        dtCodigo = objBU.RecuperarUltimoCodigoAMECEGenerado()

        Codigo = dtCodigo.Rows(0).Item(0)

        lblCodigoAMECE.Text = Codigo

        Consecutivo = Codigo.Substring(7, 5)
        lblConsecutivo.Text = Consecutivo
    End Sub


    Public Function comboClientes_CodigosAMECE(ByVal ComboEntrada As ComboBox) As ComboBox
        Dim objBU As New Negocios.CodigosAMECEBU
        Dim dtClientes As New DataTable

        dtClientes = objBU.comboClientes_CodigosAMECE()
        dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)


        comboClientes_CodigosAMECE = New ComboBox
        comboClientes_CodigosAMECE = ComboEntrada

        comboClientes_CodigosAMECE.DataSource = dtClientes
        comboClientes_CodigosAMECE.ValueMember = "clie_clienteid"
        comboClientes_CodigosAMECE.DisplayMember = "clie_nombregenerico"
        Return comboClientes_CodigosAMECE
    End Function

    Private Function comboListaPrecioCliente_CodigosAMECE(ByVal ComboEntrada As ComboBox, ByVal IdCliente As Integer) As ComboBox
        Dim objBU As New Negocios.CodigosAMECEBU
        Dim dtListaPRecio As New DataTable

        dtListaPRecio = objBU.comboListaPrecioDeCliente_CodigosAMECE(IdCliente)
        dtListaPRecio.Rows.InsertAt(dtListaPRecio.NewRow, 0)


        comboListaPrecioCliente_CodigosAMECE = New ComboBox
        comboListaPrecioCliente_CodigosAMECE = ComboEntrada
        comboListaPrecioCliente_CodigosAMECE.ValueMember = "lvcp_listaventasclienteprecioid"
        comboListaPrecioCliente_CodigosAMECE.DisplayMember = "lvcp_descripcion"
        comboListaPrecioCliente_CodigosAMECE.DataSource = dtListaPRecio

        Return comboListaPrecioCliente_CodigosAMECE
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub cmbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedValueChanged
        If IsDBNull(cmbCliente.SelectedValue) Then Return


        If IsNumeric(cmbCliente.SelectedValue) Then
            If cmbCliente.SelectedValue = 0 Then
                cmbListaPrecio.DataSource = Nothing
            Else
                comboListaPrecioCliente_CodigosAMECE(cmbListaPrecio, cmbCliente.SelectedValue)
            End If

            dtpDel.Value = Today
            dtpAl.Value = Today


        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 115
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 27
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        LimpiarControles()
    End Sub

    Private Sub LimpiarControles()
        gridCodigosAMECE.DataSource = Nothing
        comboClientes_CodigosAMECE(cmbCliente)
        RecuperarUltimoCodigoAmeceGenerado()
        cmbListaPrecio.DataSource = Nothing

        dtpDel.Value = Today
        dtpAl.Value = Today

        rdoVProductos_PedidosConfirmados.Checked = True
        rdoCCAMECE_Si.Checked = True

        chkSeleccionarTodo.Checked = False

        lblTotalSeleccionados.Text = "0"

    End Sub

    Private Sub cmbListaPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaPrecio.SelectedIndexChanged
        If IsNumeric(cmbListaPrecio.SelectedValue) Then
            Dim dtLPVigencia As New DataTable

            dtLPVigencia = RecuperarVigenciaListaPrecio(cmbListaPrecio.SelectedValue)

            dtpDel.Value = dtLPVigencia.Rows(0).Item(0)
            dtpAl.Value = dtLPVigencia.Rows(0).Item(1)
        End If
    End Sub

    Private Function RecuperarVigenciaListaPrecio(ByVal IdListaPrecioCliente As Integer) As DataTable
        Dim objBU As New Negocios.CodigosAMECEBU

        RecuperarVigenciaListaPrecio = objBU.RecuperarVigenciaListaPrecio(IdListaPrecioCliente)

        Return RecuperarVigenciaListaPrecio
    End Function


    Private Sub btnVolverCargarReporte_Click(sender As Object, e As EventArgs) Handles btnVolverCargarReporte.Click
        Me.Cursor = Cursors.WaitCursor

        chkSeleccionarTodo.Checked = False
        lblTotalSeleccionados.Text = "0"

        If ValidarCamposVacios() = False Then
            Dim BanderaVerPor As Integer
            Dim BanderaConCodigo As Integer
            Dim ClienteId As Integer
            Dim ListaPrecioClienteId As Integer

            If rdoVProductos_PedidosConfirmados.Checked Then
                BanderaVerPor = 1
            ElseIf rdoVProductos_ListaDePrecios.Checked Then
                BanderaVerPor = 2
            ElseIf rdoVProductos_Todos.Checked Then
                BanderaVerPor = 3
            End If

            If rdoCCAMECE_Si.Checked Then
                BanderaConCodigo = 1
            ElseIf rdoCCAMECE_No.Checked Then
                BanderaConCodigo = 2
            ElseIf rdoCCAMECE_Todos.Checked Then
                BanderaConCodigo = 3
            End If

            If IsNumeric(cmbListaPrecio.SelectedValue) Then
                ListaPrecioClienteId = cmbListaPrecio.SelectedValue
            End If

            ClienteId = cmbCliente.SelectedValue

            CargarGridCodigos(BanderaVerPor, BanderaConCodigo, ClienteId, ListaPrecioClienteId)
        Else
            gridCodigosAMECE.DataSource = Nothing
        End If

        Me.Cursor = Cursors.Default
    End Sub


    Private Function ValidarCamposVacios() As Boolean
        ValidarCamposVacios = False

        If IsDBNull(cmbCliente.SelectedValue) Then
            ValidarCamposVacios = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione el cliente para poder consultar los códigos AMECE.")
            lblFiltroCliente.ForeColor = Color.Red
        ElseIf cmbCliente.SelectedValue <= 0 Then
            ValidarCamposVacios = True
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione el cliente para poder consultar los códigos AMECE.")
            lblFiltroCliente.ForeColor = Color.Red
        Else
            lblFiltroCliente.ForeColor = Color.Black
        End If

        If rdoVProductos_ListaDePrecios.Checked = True Then
            If IsNumeric(cmbListaPrecio.SelectedValue) Then
                If cmbListaPrecio.SelectedValue <= 0 Then
                    ValidarCamposVacios = True
                    Mensajes_Y_Alertas("ADVERTENCIA", "Ha seleccionado el filtro ""Ver productos por Lista de Precios"". Seleccione una lista de precios para poder consultar los códigos AMECE.")
                    lblFiltroListaPrecios.ForeColor = Color.Red
                Else
                    lblFiltroListaPrecios.ForeColor = Color.Black
                End If
            Else
                ValidarCamposVacios = True
                Mensajes_Y_Alertas("ADVERTENCIA", "Ha seleccionado el filtro ""Ver productos por Lista de Precios"". Seleccione una lista de precios para poder consultar los códigos AMECE.")
                lblFiltroListaPrecios.ForeColor = Color.Red
            End If
        End If

        Return ValidarCamposVacios
    End Function


    ''' <summary>
    ''' RECUPERA LA LISTA DE LOS PRODUCTOS QUE ESTAN EN "PEDIDOS CONFIRMADOS POR VENTAS" O EN "LISTA DE PRECIOS" O "TODOS" (OBLIGATORIO ELEGIR UNA DE LAS TRS OPCIONES); 
    ''' PRODUCTOS QUE TIENEN CODIGO AMECE O PRODUCTOS QUE NO TIENEN CODIGO AMECE O TODOS (OBLIGATORIO SELECCIONAR UNA DE LAS TRS OPCIONES);
    ''' PRODUCTOS ASIGNADOS A UN CLIENTE (FILTRO OBLIGATORIO); PRODUCTOS EN UNA LISTA DE PRECIOS DE CLIENTE(OPCIONAL, SOLO ES OBLIGATORIO CUANDO SE ELECCIONA EL FILTRO "VER
    ''' PRODUCTO DE LISTA DE PRECIOS")
    ''' </summary>
    ''' <param name="BanderaVerCodigosDe">
    ''' VARIABLE DEL TIPO ENTERO PARA SELECCIONAR UNA DE LAS TRES OPCIONES DEL FILTRO "VER PRODUCTOS EN":
    '''     1= VER PRODUCTOS EN PEDIDOS CONFIRMADOS POR VENTAS
    '''     2= VER PRODUCTOS EN LISTA DE PRECIOS
    '''     3= VER TODOS LOS PRODUCTOS
    ''' </param>
    ''' <param name="BanderaConCodigo">
    ''' VARIABLE DEL TIPO ENTERO PARA SELECCIONAR UNA DE LAS OPCIONES DEL FILTRO "CON CODIGO AMECE"
    '''     1= SI
    '''     2= NO
    '''     3= TODOS
    ''' </param>
    ''' <param name="IdClienteSAY"> ID DEL CLIENTE DEL CUAL SE CONSULTARAN LOS PRODUCTOS</param>
    ''' <param name="IdListaVentasClientePrecio">ID DE LA LISTA DE PRECIOS DE LA CUAL SE CONSULTARAN LOS PRODUCTOS</param>
    ''' <remarks></remarks>
    Private Sub CargarGridCodigos(ByVal BanderaVerCodigosDe As Integer, ByVal BanderaConCodigo As Integer, IdClienteSAY As Integer, ByVal IdListaVentasClientePrecio As Integer)
        Dim objBU As New Negocios.CodigosAMECEBU
        Dim dtListaCodigos As New DataTable

        dtListaCodigos = objBU.CargarListaCodigosPorCliente(BanderaVerCodigosDe, BanderaConCodigo, IdClienteSAY, IdListaVentasClientePrecio)

        If dtListaCodigos.Rows.Count = 0 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "No se encontro información.")
            gridCodigosAMECE.DataSource = Nothing
        Else
            gridCodigosAMECE.DataSource = dtListaCodigos
        End If

    End Sub


    Private Sub gridCodigosAMECE_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridCodigosAMECE.InitializeLayout
        With gridCodigosAMECE

            .DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue

            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 50
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.Black

            .DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No

            'Dim ugFilter As New UltraGridFilterUIProvider
            '.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.Cell
            '.DisplayLayout.Override.FilterOperandStyle = Infragistics.Win.UltraWinGrid.FilterOperandStyle.UseColumnEditor
            '.DisplayLayout.Override.FilterUIProvider = ugFilter
            '.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            '.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
            '.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            '.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains
            '.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.Hidden

            .DisplayLayout.Bands(0).Columns("Seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .DisplayLayout.Bands(0).Columns("AMECE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Colección").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("ModeloSAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("ModeloSICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Piel").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Corrida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Numeración").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Modificó").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Modificación").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Modificación").Width = 150

            .DisplayLayout.Bands(0).Columns("ProductoEstiloID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .DisplayLayout.Bands(0).Columns("ProductoEstiloID").Hidden = True

            .DisplayLayout.Bands(0).Columns("Seleccionar").Style = ColumnStyle.CheckBox
            .DisplayLayout.Bands(0).Columns("Seleccionar").Header.Caption = ""
            .DisplayLayout.Bands(0).Columns("Seleccionar").Width = 50

            .DisplayLayout.Bands(0).Columns("ModeloSAY").CellAppearance.TextHAlign = HAlign.Right
            .DisplayLayout.Bands(0).Columns("ModeloSICY").CellAppearance.TextHAlign = HAlign.Right

            .DisplayLayout.Bands(0).Columns("Colección").Width = 220
            .DisplayLayout.Bands(0).Columns("Piel").Width = 220
            .DisplayLayout.Bands(0).Columns("AMECE").Width = 120


            For Each row As UltraGridRow In gridCodigosAMECE.Rows
                If row.Cells("AMECE").Value = "" Then
                    row.Cells("Seleccionar").Activation = Activation.AllowEdit
                Else
                    row.Cells("Seleccionar").Activation = Activation.Disabled
                End If
            Next
        End With
    End Sub


    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        ExportarGridAExcel()
    End Sub

    Public Sub ExportarGridAExcel()
        Dim dtDatosReporte As New DataTable
        Dim dtDatosReporteDepurado As New DataTable
        Dim cadenaAgentes As String = ""
        Dim Marca As String = ""

        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                'Carpeta = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + +".xlsx"
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(gridCodigosAMECE, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Me.Cursor = Cursors.Default
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If

    End Sub

    Private Sub btnGenerarCodigos_Click(sender As Object, e As EventArgs) Handles btnGenerarCodigos.Click
        If lblTotalSeleccionados.Text = "0" Then
            Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione al menos un registro para generar un nuevo código AMECE.")
        ElseIf Mensajes_Y_Alertas("CONFIRMACION_G", "¿ Desea guardar los " + lblTotalSeleccionados.Text + " códigos AMECE generados ? (Los códigos" +
                                  " serán relacionados con los clientes que tengan estos artículos asignados en sus listas de precios, " +
                                  "una vez realizada esta operación no se podrá revertir)") Then
            Dim i As Integer = 0




            For Each row As UltraGridRow In gridCodigosAMECE.Rows
                If row.Cells("Seleccionar").Value = True Then
                    Try
                        GenerarCodigoAmece(row.Cells("ProductoEstiloID").Value, row.Cells("Numeración").Text, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, cmbCliente.SelectedValue)
                    Catch ex As Exception
                        i += 1
                    End Try
                End If
            Next

            If i > 0 Then
                Mensajes_Y_Alertas("ADVERTENCIA", "Algunos códigos AMECE no se generaron correctamente.")
            Else
                Mensajes_Y_Alertas("EXITO", "Se generaron correctamente los códigos AMECE para los productos seleccionados.")
            End If

            btnVolverCargarReporte.PerformClick()

            chkSeleccionarTodo.Checked = False
            lblTotalSeleccionados.Text = "0"
        End If



    End Sub

    Private Sub GenerarCodigoAmece(ByVal IdProductoEstilo As Integer, ByVal Talla As String, ByVal IdUsuario As Integer, ByVal ClienteId As Integer)
        Dim objBU As New Negocios.CodigosAMECEBU
        objBU.GenerarCodigoAmece(IdProductoEstilo, Talla, IdUsuario, ClienteId)
    End Sub


    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        For Each row As UltraGridRow In gridCodigosAMECE.Rows.GetFilteredInNonGroupByRows
            If row.Cells("AMECE").Value = "" Then
                row.Cells("Seleccionar").Value = chkSeleccionarTodo.Checked
            Else
                row.Cells("Seleccionar").Value = False
            End If
        Next

        ContarRegistrosSeleccionados()
    End Sub


    Private Sub gridCodigosAMECE_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridCodigosAMECE.ClickCell
        Dim seleccionados As Integer = 0
        If IsNothing(gridCodigosAMECE.ActiveRow) Then Return
        If IsNothing(gridCodigosAMECE.ActiveCell) Then Return

        If gridCodigosAMECE.ActiveCell.Column.ToString = "Seleccionar" And gridCodigosAMECE.ActiveRow.Cells("AMECE").Text = "" Then
            If Not Me.gridCodigosAMECE.ActiveRow.IsDataRow Then Return

            If IsNothing(gridCodigosAMECE.ActiveRow) Then Return

            If gridCodigosAMECE.ActiveRow.Cells("Seleccionar").Value Then

                gridCodigosAMECE.ActiveRow.Cells("Seleccionar").Value = False
            Else
                gridCodigosAMECE.ActiveRow.Cells("Seleccionar").Value = True
            End If

            For Each row As UltraGridRow In gridCodigosAMECE.Rows
                If CBool(row.Cells("Seleccionar").Value) Then
                    seleccionados += 1
                End If
            Next
            lblTotalSeleccionados.Text = Format(seleccionados, "###,###,##0")
        End If
    End Sub

    Private Sub ContarRegistrosSeleccionados()
        Dim Seleccionados As Integer = 0
        For Each row As UltraGridRow In gridCodigosAMECE.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                Seleccionados += 1
            End If
        Next
        lblTotalSeleccionados.Text = Format(Seleccionados, "###,###,##0")
    End Sub



End Class