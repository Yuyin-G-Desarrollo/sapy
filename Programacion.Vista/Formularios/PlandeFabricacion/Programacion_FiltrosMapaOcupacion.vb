Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios

Public Class Programacion_FiltrosMapaOcupacion
    Dim listaInicial As New List(Of String)
    Dim listPedidoSAY As New List(Of String)
    Dim listPedidoSICY As New List(Of String)

    Private Sub Programacion_FiltrosMapaOcupacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        grdNaves.DataSource = listaInicial
        grdCliente.DataSource = listaInicial
        grdPedidoSAY.DataSource = listaInicial
        grdPedidoSICY.DataSource = listaInicial
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        grdPiel.DataSource = listaInicial
        grdColor.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial
        grdFamilia.DataSource = listaInicial
        grdTemporada.DataSource = listaInicial
    End Sub

    Private Sub btnAgregarNave_Click(sender As Object, e As EventArgs) Handles btnAgregarNave.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 1

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listParametros
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimNave_Click(sender As Object, e As EventArgs) Handles btnLimNave.Click
        grdNaves.DataSource = listaInicial
    End Sub

    Private Sub grdNaves_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdNaves.InitializeLayout
        grid_diseño(grdNaves)
        grdNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Naves"
    End Sub

    Private Sub grdNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNaves.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNaves.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 5

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
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Clientes"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimCliente_Click(sender As Object, e As EventArgs) Handles btnLimCliente.Click
        grdCliente.DataSource = listaInicial
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Clientes"
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiarFiltroPedidoSAY_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroPedidoSAY.Click
        grdPedidoSAY.DataSource = Nothing
        listPedidoSAY.Clear()
        grdPedidoSAY.DataSource = listaInicial
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        grid_diseño(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
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

    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grdPedidoSICY.DataSource = Nothing
            grdPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub btnLimpiarPedidoSICY_Click(sender As Object, e As EventArgs) Handles btnLimpiarPedidoSICY.Click
        grdPedidoSICY.DataSource = Nothing
        listPedidoSICY.Clear()
        grdPedidoSICY.DataSource = listaInicial

    End Sub

    Private Sub grdPedidoSICY_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPedidoSICY.InitializeLayout
        grid_diseño(grdPedidoSICY)
        grdPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub bntAgregarMarca_Click(sender As Object, e As EventArgs) Handles bntAgregarMarca.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 4

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

    Private Sub btnLimpMarca_Click(sender As Object, e As EventArgs) Handles btnLimpMarca.Click
        grdMarca.DataSource = listaInicial
    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
        grdMarca.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 9

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
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarPiel_Click(sender As Object, e As EventArgs) Handles btnAgregarPiel.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 10

        For Each row As UltraGridRow In grdPiel.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdPiel.DataSource = listado.listParametros
        With grdPiel
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Piel"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimPiel_Click(sender As Object, e As EventArgs) Handles btnLimPiel.Click
        grdPiel.DataSource = listaInicial
    End Sub

    Private Sub grdPiel_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdPiel.InitializeLayout
        grid_diseño(grdPiel)
        grdPiel.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Piel"
    End Sub

    Private Sub grdPiel_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPiel.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarColor_Click(sender As Object, e As EventArgs) Handles btnAgregarColor.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 11

        For Each row As UltraGridRow In grdColor.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColor.DataSource = listado.listParametros
        With grdColor
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Color"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimColor_Click(sender As Object, e As EventArgs) Handles btnLimColor.Click
        grdColor.DataSource = listaInicial
    End Sub

    Private Sub grdColor_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdColor.InitializeLayout
        grid_diseño(grdColor)
        grdColor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Color"
    End Sub

    Private Sub grdColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColor.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 12

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
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimCorrida_Click(sender As Object, e As EventArgs) Handles btnLimCorrida.Click
        grdCorrida.DataSource = listaInicial
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarFamilia_Click(sender As Object, e As EventArgs) Handles btnAgregarFamilia.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 13

        For Each row As UltraGridRow In grdFamilia.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamilia.DataSource = listado.listParametros
        With grdFamilia
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimFamilia_Click(sender As Object, e As EventArgs) Handles btnLimFamilia.Click
        grdFamilia.DataSource = listaInicial
    End Sub

    Private Sub grdFamilia_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdFamilia.InitializeLayout
        grid_diseño(grdFamilia)
        grdFamilia.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub grdFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamilia.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamilia.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarTemporada_Click(sender As Object, e As EventArgs) Handles btnAgregarTemporada.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 14

        For Each row As UltraGridRow In grdTemporada.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTemporada.DataSource = listado.listParametros
        With grdTemporada
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Temporada"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimTemporada_Click(sender As Object, e As EventArgs) Handles btnLimTemporada.Click
        grdTemporada.DataSource = listaInicial
    End Sub

    Private Sub grdTemporada_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTemporada.InitializeLayout
        grid_diseño(grdTemporada)
        grdTemporada.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Temporada"
    End Sub

    Private Sub grdTemporada_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTemporada.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamilia.DeleteSelectedRows(False)
    End Sub

    Private Sub chFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chFecha.CheckedChanged
        If chFecha.Checked = False Then
            grpFecha.Enabled = False
        Else
            grpFecha.Enabled = True
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim FNave As String = String.Empty
        Dim FCliente As String = String.Empty
        Dim FPedidoSAY As String = String.Empty
        Dim FPedidoSICY As String = String.Empty
        Dim FMarca As String = String.Empty
        Dim FColeccion As String = String.Empty
        Dim FPiel As String = String.Empty
        Dim FColor As String = String.Empty
        Dim FCorrida As String = String.Empty
        Dim FFamiliaV As String = String.Empty
        Dim FTemporada As String = String.Empty
        Dim dtEnviaFiltrosParaOcupacionDetalle As New DataTable
        Dim objBU As New PlanFabricacionBU
        Dim FiltroFecha As Integer = 0
        Dim FechaInicio As Date = dtpFechaInicio.Value.ToShortDateString()
        Dim FechaFin As Date = dtpFechaFin.Value.ToShortDateString()



        Try
            Cursor = Cursors.WaitCursor

            FNave = ObtenerFiltrosGrid(grdNaves)
            FCliente = ObtenerFiltrosGrid(grdCliente)
            FPedidoSAY = ObtenerFiltrosGrid(grdPedidoSAY)
            FPedidoSICY = ObtenerFiltrosGrid(grdPedidoSICY)
            FMarca = ObtenerFiltrosGrid(grdMarca)
            FColeccion = ObtenerFiltrosGrid(grdColeccion)
            FPiel = ObtenerFiltrosGrid(grdPiel)
            FColor = ObtenerFiltrosGrid(grdColor)
            FCorrida = ObtenerFiltrosGrid(grdCorrida)
            FFamiliaV = ObtenerFiltrosGrid(grdFamilia)
            FTemporada = ObtenerFiltrosGrid(grdTemporada)


            If chFecha.Checked = True Then

                If FechaInicio > FechaFin Then
                    show_message("Advertencia", "La fecha inicio no puede ser mayor a la fecha fin.")
                    Exit Sub
                End If

                If rdoProgramacion.Checked = True Then
                    FiltroFecha = 1 'FechaProgramacion
                ElseIf rdoEntregaCliente.Checked = True Then
                    FiltroFecha = 2 'FechaEntregaCliente
                ElseIf rdoSolicitaCliente.Checked = True Then
                    FiltroFecha = 3 'FechaSolicitaCliente
                End If
            End If

            dtEnviaFiltrosParaOcupacionDetalle = objBU.ObtieneInformacionDetallesMapaOcupacion(FNave, FCliente, LTrim(RTrim(FPedidoSAY)),
                                                                                               LTrim(RTrim(FPedidoSICY)), FMarca, FColeccion, FPiel,
                                                                                               FColor, FCorrida, FFamiliaV, FTemporada,
                                                                                               FiltroFecha, FechaInicio, FechaFin)

            If dtEnviaFiltrosParaOcupacionDetalle.Rows.Count > 0 Then

                Me.Dispose()


                Dim DetallesOcupacionSemanal As New Programacion_ColocacionSemanal_DetallesOcupacionSemanal
                DetallesOcupacionSemanal.accion = 0
                DetallesOcupacionSemanal.ConsultaFiltros = True
                DetallesOcupacionSemanal.tablaDetalles = dtEnviaFiltrosParaOcupacionDetalle

                DetallesOcupacionSemanal.FNave = FNave
                DetallesOcupacionSemanal.FCliente = FCliente
                DetallesOcupacionSemanal.FPedidoSAY = FPedidoSAY
                DetallesOcupacionSemanal.FPedidoSICY = FPedidoSICY
                DetallesOcupacionSemanal.FMarca = FMarca
                DetallesOcupacionSemanal.FColeccion = FColeccion
                DetallesOcupacionSemanal.FPiel = FPiel
                DetallesOcupacionSemanal.FColor = FColor
                DetallesOcupacionSemanal.FCorrida = FCorrida
                DetallesOcupacionSemanal.FFamiliaV = FFamiliaV
                DetallesOcupacionSemanal.FTemporada = FTemporada
                DetallesOcupacionSemanal.FiltroFecha = FiltroFecha
                DetallesOcupacionSemanal.FechaInicio = FechaInicio
                DetallesOcupacionSemanal.FechaFin = FechaFin

                DetallesOcupacionSemanal.Show()

            Else
                show_message("Advertencia", "No hay información para mostrar.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdNaves.DataSource = listaInicial
        grdCliente.DataSource = listaInicial
        grdPedidoSAY.DataSource = listaInicial
        grdPedidoSICY.DataSource = listaInicial
        grdMarca.DataSource = listaInicial
        grdColeccion.DataSource = listaInicial
        grdPiel.DataSource = listaInicial
        grdColor.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial
        grdFamilia.DataSource = listaInicial
        grdTemporada.DataSource = listaInicial
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
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

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


End Class