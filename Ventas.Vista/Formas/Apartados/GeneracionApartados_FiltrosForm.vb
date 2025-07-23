Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class GeneracionApartados_FiltrosForm

    Dim listInicial As New List(Of String)
    Dim listPedidoSAY As New List(Of String)
    Dim listPedidoSICY As New List(Of String)
    Dim listFiltros As New List(Of UltraGrid)
    Dim listMaskedTexbox As New List(Of MaskedTextBox)
    Dim listCheckbox As New List(Of CheckBox)
    Dim disponibleGeneracionApartados As Integer = 0 '1 = Disponible para generar apartados, 0 = Disponible solo para consulta
    Dim tipoBloqueoGeneracionApartados As Integer = 0 '0 = Otro usuario apartado, 1 = mismo usuario apartando

    'Dim busquedaRealizada As Integer = 0 'Para saber si se cierra la ventana por cambio de ventana o cierre definitivo. 0 = Cierre, 1 = Busqueda realizada

    Private Sub GeneracionApartados_FiltrosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0

        Dim listInicial = New List(Of String)
        Dim listPedidoSAY = New List(Of String)
        Dim listPedidoSICY = New List(Of String)

        listFiltros.Clear()
        listMaskedTexbox.Clear()
        listCheckbox.Clear()

        grdPedidoSAY.DataSource = listInicial
        grdPedidoSICY.DataSource = listInicial
        grdCliente.DataSource = listInicial
        grdTienda.DataSource = listInicial
        grdNave.DataSource = listInicial
        grdMarca.DataSource = listInicial
        grdColeccion.DataSource = listInicial
        grdModelo.DataSource = listInicial
        grdCorrida.DataSource = listInicial
        grdRanking.DataSource = listInicial

        listFiltros.Add(grdPedidoSAY)
        listFiltros.Add(grdPedidoSICY)
        listFiltros.Add(grdCliente)
        listFiltros.Add(grdTienda)
        listFiltros.Add(grdNave)
        listFiltros.Add(grdMarca)
        listFiltros.Add(grdColeccion)
        listFiltros.Add(grdModelo)
        listFiltros.Add(grdCorrida)
        listFiltros.Add(grdRanking)

        listMaskedTexbox.Add(txtPedidoSAY)
        listMaskedTexbox.Add(txtPedidoSICY)

        listCheckbox.Add(chboxFiltrarFechaEntrega)
        listCheckbox.Add(chboxFiltrarFechaPrograma)
        listCheckbox.Add(chboxAtadoNon)
        listCheckbox.Add(chboxAtadoPar)
        listCheckbox.Add(chboxAtadoPunto)
        listCheckbox.Add(chboxDestallados)
        listCheckbox.Add(chboxDestallarAtadosNormales)
        listCheckbox.Add(chboxDestallarAtadosPunto)

        validaDisponibilidadRealizarApartados(1)

        dtpEntregaDel.Value = Date.Now
        dtpEntregaAl.Value = Date.Now.AddDays(7)
        dtpProgramaDel.Value = Date.Now
        dtpProgramaAl.Value = Date.Now.AddDays(7)

    End Sub

    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

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

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    'Asigna formato a columnas de ultragrid
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

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub


    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 15
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub btnTienda_Click(sender As Object, e As EventArgs) Handles btnTienda.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 5
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTienda.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTienda.DataSource = listado.listParametros
        With grdTienda
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            '.DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Tienda"
        End With
    End Sub

    Private Sub btnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.pantallaOrigen = 1
        listado.tipo_busqueda = 4
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdNave.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNave.DataSource = listado.listParametros
        With grdNave
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
        End With
    End Sub

    Private Sub btnColección_Click(sender As Object, e As EventArgs) Handles btnColección.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 3
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
        End With
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 11
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdModelo.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdModelo.DataSource = listado.listParametros
        With grdModelo
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Modelo"
        End With
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 7
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            '.DisplayLayout.Bands(0).Columns(3).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
        End With
    End Sub

    Private Sub btnRanking_Click(sender As Object, e As EventArgs) Handles btnRanking.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 8
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdRanking.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdRanking.DataSource = listado.listParametros
        With grdRanking
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Ranking"
        End With
    End Sub

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
        grdNave.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Nave"
    End Sub

    Private Sub grdTienda_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTienda.InitializeLayout
        grid_diseño(grdTienda)
        grdTienda.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tienda/Embarque/CEDIS"
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
        grdModelo.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Modelo"
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdRanking_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRanking.InitializeLayout
        grid_diseño(grdRanking)
        grdRanking.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Ranking"
    End Sub

    Private Sub grdTienda_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTienda.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTienda.DeleteSelectedRows(False)
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub grdRanking_KeyDown(sender As Object, e As KeyEventArgs) Handles grdRanking.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdRanking.DeleteSelectedRows(False)
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 1
        listado.pantallaOrigen = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarca.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarca.DataSource = listado.listParametros
        With grdMarca
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        For Each filtro As UltraGrid In listFiltros
            filtro.DataSource = Nothing
        Next

        For Each cajaTexto As MaskedTextBox In listMaskedTexbox
            cajaTexto.Text = ""
        Next

        For Each check As CheckBox In listCheckbox
            check.Checked = True
            If check.Name = "chboxFiltrarFechaEntrega" Then
                check.Checked = False
            End If
        Next

        rdbMostrarFinal.Checked = True
        rdbDescartar.Checked = False

        txtNumeroPares.Text = "8"
        txtNumeroTallas.Text = "3"

    End Sub

    Private Sub chboxFiltrarFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFiltrarFechaEntrega.CheckedChanged
        If chboxFiltrarFechaEntrega.Checked = False Then
            dtpEntregaDel.Enabled = False
            dtpEntregaAl.Enabled = False
        Else
            dtpEntregaDel.Enabled = True
            dtpEntregaAl.Enabled = True
        End If
    End Sub

    Private Sub chboxFiltrarFechaPrograma_CheckedChanged(sender As Object, e As EventArgs) Handles chboxFiltrarFechaPrograma.CheckedChanged
        If chboxFiltrarFechaPrograma.Checked = False Then
            dtpProgramaDel.Enabled = False
            dtpProgramaAl.Enabled = False
        Else
            dtpProgramaDel.Enabled = True
            dtpProgramaAl.Enabled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub dtpEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpEntregaDel.ValueChanged
        If dtpEntregaAl.Value < dtpEntregaDel.Value Then
            dtpEntregaAl.Value = dtpEntregaDel.Value
        End If
        dtpEntregaAl.MinDate = dtpEntregaDel.Value
    End Sub

    Private Sub dtpProgramaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpProgramaDel.ValueChanged
        If dtpProgramaAl.Value < dtpProgramaDel.Value Then
            dtpProgramaAl.Value = dtpProgramaDel.Value
        End If
        dtpProgramaAl.MinDate = dtpProgramaDel.Value
    End Sub

    Private Sub validaDisponibilidadRealizarApartados(ByVal estatusGenerandoApartado As Int32)
        'estatusGenerandoApartado -- 1 = Entrando, 2 salidendo
        Dim dtResultado As New DataTable
        Dim objBu As New Ventas.Negocios.ApartadosBU
        Dim mensajeDisponibilidad As String = String.Empty
        Dim splitMensajeDisponibilidad As String = String.Empty

        Dim usuario As New Entidades.Usuarios
        Dim idUsuario As Int32 = 0
        usuario = Entidades.SesionUsuario.UsuarioSesion
        If Not usuario Is Nothing Then
            idUsuario = usuario.PUserUsuarioid
            'DESCOMENTAR PARA PODER ASIGNAR LA SESION DE APARTADOS AL USUARIO O RESTRINGIR LA ENTRADA SI YA HAY ALGUIEN MAS EN LA SESION
            dtResultado = objBu.verificaDisponibilidadApartar(estatusGenerandoApartado, usuario.PUserUsername, "PPCP")

            If Not dtResultado Is Nothing Then
                If dtResultado.Rows.Count > 0 Then

                    For i As Int32 = 0 To dtResultado.Rows.Count - 1
                        mensajeDisponibilidad = dtResultado.Rows(i).Item("MensajeRespuesta").ToString()
                    Next

                Else
                End If
            Else
            End If

        End If

        If mensajeDisponibilidad <> "" Then
            splitMensajeDisponibilidad = Split(mensajeDisponibilidad, "de")(1).ToString()
            splitMensajeDisponibilidad = LTrim(RTrim(Split(splitMensajeDisponibilidad, "termine")(0).ToString()))
            mensajeDisponibilidad = Replace(mensajeDisponibilidad, " completar esta acción.", " generar apartados.")
            If splitMensajeDisponibilidad = "VENTAS" Then
                show_message("Advertencia", Replace(mensajeDisponibilidad, "Por favor ", "Por el momento solo se pueden realizar consultas, por favor "))
            End If
            If splitMensajeDisponibilidad = "PPCP" Then
                show_message("Advertencia", mensajeDisponibilidad)
                btnMostrar.Enabled = False
                lblAceptar.Enabled = False
                btnVistaPreviaClientes.Enabled = False
                lblVistaPreviaClientes.Enabled = False
            End If
            If splitMensajeDisponibilidad <> "VENTAS" And splitMensajeDisponibilidad <> "PPCP" Then
                show_message("Advertencia", mensajeDisponibilidad)
                btnMostrar.Enabled = False
                lblAceptar.Enabled = False
                btnVistaPreviaClientes.Enabled = False
                lblVistaPreviaClientes.Enabled = False
                tipoBloqueoGeneracionApartados = 1
            End If

            disponibleGeneracionApartados = 0
        Else
            disponibleGeneracionApartados = 1
        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim mensajeConfirmar As New ConfirmarForm
        mensajeConfirmar.mensaje = "Se recomienda usar al menos un filtro para agilizar la búsqueda. ¿Desea continuar?"
        If chboxFiltrarFechaEntrega.Checked Or chboxFiltrarFechaPrograma.Checked Or grdPedidoSAY.Rows.Count() > 0 Or grdPedidoSICY.Rows.Count() > 0 Or grdCliente.Rows.Count() > 0 Or grdTienda.Rows.Count() > 0 Or grdNave.Rows.Count() > 0 Or grdMarca.Rows.Count() > 0 Or grdColeccion.Rows.Count() > 0 Or grdModelo.Rows.Count() > 0 Or grdCorrida.Rows.Count() > 0 Or grdRanking.Rows.Count > 0 Then
            MostrarDatosFiltrosSeleccionados()
        Else
            If mensajeConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                MostrarDatosFiltrosSeleccionados()
            End If
        End If

    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub GeneracionApartados_FiltrosForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If busquedaRealizada = 0 Then
        If tipoBloqueoGeneracionApartados <> 1 Then
            validaDisponibilidadRealizarApartados(0)
        End If
        'End If
    End Sub

    Private Sub MostrarDatosFiltrosSeleccionados()
        Dim ventanaGeneracion As New GeneracionApartadosPPCP_Form()
        Dim filtrosGeneracion As New Entidades.FiltrosGeneracionApartadosPPCP()


        If chboxAtadoNon.Checked Or chboxAtadoPar.Checked Or chboxAtadoPunto.Checked Or chboxDestallados.Checked Or chboxDestallarAtadosNormales.Checked Or chboxDestallarAtadosPunto.Checked Then

            Dim lPedidoSAY As String = String.Empty
            Dim lPedidoSICY As String = String.Empty
            Dim lCliente As String = String.Empty
            Dim lTiendaEmbarqueCEDIS As String = String.Empty
            Dim lNave As String = String.Empty
            Dim lMarca As String = String.Empty
            Dim lColeccion As String = String.Empty
            Dim lModelo As String = String.Empty
            Dim lCorrida As String = String.Empty
            Dim lRanking As String = String.Empty
            Dim lNaveSICY As String = String.Empty

            filtrosGeneracion.PMostrarFechaEntrega = If(chboxFiltrarFechaEntrega.Checked, 1, 0)
            filtrosGeneracion.PFechaEntregaDel = If(chboxFiltrarFechaEntrega.Checked, dtpEntregaDel.Value.ToShortDateString(), "")
            filtrosGeneracion.PFechaEntregaAl = If(chboxFiltrarFechaEntrega.Checked, dtpEntregaAl.Value.ToShortDateString(), "")
            filtrosGeneracion.PMostrarFechaPrograma = If(chboxFiltrarFechaPrograma.Checked, 1, 0)
            filtrosGeneracion.PFechaProgramaDel = If(chboxFiltrarFechaPrograma.Checked, dtpProgramaDel.Value.ToShortDateString(), "")
            filtrosGeneracion.PFechaProgramaAl = If(chboxFiltrarFechaPrograma.Checked, dtpProgramaAl.Value.ToShortDateString(), "")
            filtrosGeneracion.PAtadoNON = If(chboxAtadoNon.Checked, 1, 0)
            filtrosGeneracion.PAtadoPAR = If(chboxAtadoPar.Checked, 1, 0)
            filtrosGeneracion.PAtadoPUNTO = If(chboxAtadoPunto.Checked, 1, 0)
            filtrosGeneracion.PParesDestallados = If(chboxDestallados.Checked, 1, 0)
            filtrosGeneracion.PDestallarNormales = If(chboxDestallarAtadosNormales.Checked, 1, 0)
            filtrosGeneracion.PDestallarPuntos = If(chboxDestallarAtadosPunto.Checked, 1, 0)
            filtrosGeneracion.PCantidadTallas = Integer.Parse(txtNumeroTallas.Text)
            filtrosGeneracion.PCantidadPares = Integer.Parse(txtNumeroPares.Text)
            filtrosGeneracion.PFinal_o_Descartar = If(rdbMostrarFinal.Checked, 1, (If(rdbDescartar.Checked, 2, 0)))

            For Each row As UltraGridRow In grdPedidoSAY.Rows
                If row.Index = 0 Then
                    lPedidoSAY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lPedidoSAY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PPedidoSAY = lPedidoSAY

            For Each row As UltraGridRow In grdPedidoSICY.Rows
                If row.Index = 0 Then
                    lPedidoSICY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lPedidoSICY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PPedidoSICY = lPedidoSICY

            For Each row As UltraGridRow In grdCliente.Rows
                If row.Index = 0 Then
                    lCliente += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lCliente += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PCliente = lCliente

            For Each row As UltraGridRow In grdTienda.Rows
                If row.Index = 0 Then
                    lTiendaEmbarqueCEDIS += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lTiendaEmbarqueCEDIS += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PTienda = lTiendaEmbarqueCEDIS

            For Each row As UltraGridRow In grdNave.Rows
                If row.Index = 0 Then
                    lNave += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lNave += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PNave = lNave

            For Each row As UltraGridRow In grdMarca.Rows
                If row.Index = 0 Then
                    lMarca += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lMarca += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PMarca = lMarca

            For Each row As UltraGridRow In grdColeccion.Rows
                If row.Index = 0 Then
                    lColeccion += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lColeccion += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PColeccion = lColeccion

            For Each row As UltraGridRow In grdModelo.Rows
                If row.Index = 0 Then
                    lModelo += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lModelo += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PModelo = lModelo

            For Each row As UltraGridRow In grdCorrida.Rows
                If row.Index = 0 Then
                    lCorrida += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lCorrida += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PCorrida = lCorrida

            For Each row As UltraGridRow In grdRanking.Rows
                If row.Index = 0 Then
                    lRanking += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lRanking += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PRanking = lRanking


            For Each row As UltraGridRow In grdNave.Rows
                If row.Index = 0 Then
                    lNaveSICY += " '" + Replace(row.Cells(3).Text, ",", "") + "'"
                Else
                    lNaveSICY += ", '" + Replace(row.Cells(3).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PNaveSICY = lNaveSICY


            'validaDisponibilidadRealizarApartados(1)
            ventanaGeneracion.MdiParent = Me.MdiParent
            ventanaGeneracion.disponibleApartar = disponibleGeneracionApartados
            ventanaGeneracion.disponibleApartar = 1
            ventanaGeneracion.filtrosGenerarApartados = filtrosGeneracion
            'busquedaRealizada = 1
            Me.WindowState = FormWindowState.Minimized
            ventanaGeneracion.Show()
        Else
            show_message("Advertencia", "Debe seleccionar al menos un tipo de atados para realizar la busqueda.")
        End If
    End Sub

    Private Sub btnVistaPreviaClientes_Click(sender As Object, e As EventArgs) Handles btnVistaPreviaClientes.Click
        Dim filtrosGeneracion As New Entidades.FiltrosGeneracionApartadosPPCP()
        Dim confirmacion As New confirmarFormGrande
        confirmacion.mensaje = "El sistema realizará un respaldo del inventario disponible en Almacén para indicar la disponibilidad de pares por cliente, esta acción puede tomar algunos minutos ¿Desea continuar?"

        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            Cursor = Cursors.WaitCursor

            Dim lPedidoSAY As String = String.Empty
            Dim lPedidoSICY As String = String.Empty
            Dim lCliente As String = String.Empty
            Dim lTiendaEmbarqueCEDIS As String = String.Empty
            Dim lNave As String = String.Empty
            Dim lMarca As String = String.Empty
            Dim lColeccion As String = String.Empty
            Dim lModelo As String = String.Empty
            Dim lCorrida As String = String.Empty
            Dim lRanking As String = String.Empty
            Dim lNaveSICY As String = String.Empty

            filtrosGeneracion.PMostrarFechaEntrega = If(chboxFiltrarFechaEntrega.Checked, 1, 0)
            filtrosGeneracion.PFechaEntregaDel = If(chboxFiltrarFechaEntrega.Checked, dtpEntregaDel.Value.ToShortDateString(), "")
            filtrosGeneracion.PFechaEntregaAl = If(chboxFiltrarFechaEntrega.Checked, dtpEntregaAl.Value.ToShortDateString(), "")
            filtrosGeneracion.PMostrarFechaPrograma = If(chboxFiltrarFechaPrograma.Checked, 1, 0)
            filtrosGeneracion.PFechaProgramaDel = If(chboxFiltrarFechaPrograma.Checked, dtpProgramaDel.Value.ToShortDateString(), "")
            filtrosGeneracion.PFechaProgramaAl = If(chboxFiltrarFechaPrograma.Checked, dtpProgramaAl.Value.ToShortDateString(), "")
            filtrosGeneracion.PAtadoNON = If(chboxAtadoNon.Checked, 1, 0)
            filtrosGeneracion.PAtadoPAR = If(chboxAtadoPar.Checked, 1, 0)
            filtrosGeneracion.PAtadoPUNTO = If(chboxAtadoPunto.Checked, 1, 0)
            filtrosGeneracion.PParesDestallados = If(chboxDestallados.Checked, 1, 0)
            filtrosGeneracion.PDestallarNormales = If(chboxDestallarAtadosNormales.Checked, 1, 0)
            filtrosGeneracion.PDestallarPuntos = If(chboxDestallarAtadosPunto.Checked, 1, 0)
            filtrosGeneracion.PCantidadTallas = Integer.Parse(txtNumeroTallas.Text)
            filtrosGeneracion.PCantidadPares = Integer.Parse(txtNumeroPares.Text)
            filtrosGeneracion.PFinal_o_Descartar = If(rdbMostrarFinal.Checked, 1, (If(rdbDescartar.Checked, 2, 0)))

            For Each row As UltraGridRow In grdPedidoSAY.Rows
                If row.Index = 0 Then
                    lPedidoSAY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lPedidoSAY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PPedidoSAY = lPedidoSAY

            For Each row As UltraGridRow In grdPedidoSICY.Rows
                If row.Index = 0 Then
                    lPedidoSICY += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lPedidoSICY += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PPedidoSICY = lPedidoSICY

            For Each row As UltraGridRow In grdCliente.Rows
                If row.Index = 0 Then
                    lCliente += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lCliente += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PCliente = lCliente

            For Each row As UltraGridRow In grdTienda.Rows
                If row.Index = 0 Then
                    lTiendaEmbarqueCEDIS += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lTiendaEmbarqueCEDIS += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PTienda = lTiendaEmbarqueCEDIS

            For Each row As UltraGridRow In grdNave.Rows
                If row.Index = 0 Then
                    lNave += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lNave += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PNave = lNave

            For Each row As UltraGridRow In grdMarca.Rows
                If row.Index = 0 Then
                    lMarca += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lMarca += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PMarca = lMarca

            For Each row As UltraGridRow In grdColeccion.Rows
                If row.Index = 0 Then
                    lColeccion += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lColeccion += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PColeccion = lColeccion

            For Each row As UltraGridRow In grdModelo.Rows
                If row.Index = 0 Then
                    lModelo += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lModelo += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PModelo = lModelo

            For Each row As UltraGridRow In grdCorrida.Rows
                If row.Index = 0 Then
                    lCorrida += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lCorrida += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PCorrida = lCorrida

            For Each row As UltraGridRow In grdRanking.Rows
                If row.Index = 0 Then
                    lRanking += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
                Else
                    lRanking += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
                End If
            Next

            filtrosGeneracion.PRanking = lRanking


            For Each row As UltraGridRow In grdNave.Rows
                If row.Index = 0 Then
                    lNaveSICY += " '" + Replace(row.Cells(3).Text, ",", "") + "'"
                Else
                    lNaveSICY += ", '" + Replace(row.Cells(3).Text, ",", "") + "'"
                End If
            Next


            filtrosGeneracion.PNaveSICY = lNaveSICY

            Dim ventanaVistaPrevia As New ResumenApartadosClientes_Form()
            ventanaVistaPrevia.filtrosGeneracion = filtrosGeneracion
            ventanaVistaPrevia.pantallaFiltrosApartados = Me
            ventanaVistaPrevia.MdiParent = Me.MdiParent
            Me.WindowState = FormWindowState.Minimized
            ventanaVistaPrevia.Show()
        End If
        Cursor = Cursors.Default
    End Sub
End Class