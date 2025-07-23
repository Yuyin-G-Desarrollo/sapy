Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AgenteMarcaFamiliaVentasForm
    Public idCliente As Int32 = 0
    Dim dtAsignacion As New DataTable
    Dim eliminarRelacion As Boolean = False
    Public Sub cargarComboMarcas()
        Dim dtMarcas As New DataTable
        Dim objDatosBu As New Negocios.ClientesDatosBU
        dtMarcas = objDatosBu.consultaComboMarcasParaFamilia(idCliente)

        If dtMarcas.Rows.Count > 0 Then
            Dim newRow As DataRow = dtMarcas.NewRow
            dtMarcas.Rows.InsertAt(newRow, 0)
            cmbMarcas.DataSource = dtMarcas
            cmbMarcas.ValueMember = "idmarca"
            cmbMarcas.DisplayMember = "descripcion"
            'If dtMarcas.Rows.Count = 2 Then
            '    cmbMarcas.SelectedIndex = 1
            'End If
        End If

        mostrarAsignacionAgenteMarcaFamilia()
    End Sub

    Public Sub cargarComboAgentes(ByVal idCliente As Int32, ByVal idMarca As Int32)
        Dim dtAgentes As New DataTable
        Dim objDatosBu As New Negocios.ClientesDatosBU
        dtAgentes = objDatosBu.consultaComboAgentesParaFamilia(idCliente, idMarca)

        If dtAgentes.Rows.Count > 0 Then
            Dim newrow As DataRow = dtAgentes.NewRow
            dtAgentes.Rows.InsertAt(newrow, 0)
            cmbAgente.DataSource = dtAgentes
            cmbAgente.ValueMember = "idAgente"
            cmbAgente.DisplayMember = "nombreAgente"
            If dtAgentes.Rows.Count = 2 Then
                cmbAgente.SelectedIndex = 1
            End If
        End If
    End Sub

    Public Sub cargarComboCoord()
        Dim dtCbxCoordinador As DataTable
        Dim objDatosBu As New Negocios.ClientesDatosBU
        dtCbxCoordinador = objDatosBu.verCoordinadores()

        If dtCbxCoordinador.Rows.Count > 0 Then
            Dim newrow As DataRow = dtCbxCoordinador.NewRow
            dtCbxCoordinador.Rows.InsertAt(newrow, 0)
            cmbAgente.DataSource = dtCbxCoordinador
            cmbAgente.ValueMember = "ID_COORD"
            cmbAgente.DisplayMember = "NOMBRE_COLABORADOR"
            If dtCbxCoordinador.Rows.Count = 2 Then
                cmbAgente.SelectedIndex = 1
            End If
        End If
    End Sub

    Public Sub mostrarAsignacionAgenteMarcaFamilia()
        'Dim dtAsignacion As New DataTable
        Dim objDatosBu As New Negocios.ClientesDatosBU
        lblTotalSeleccionados.Text = "0"

        dtAsignacion = objDatosBu.consultaAgenteMarcaFamiliaAsignados(idCliente)

        If dtAsignacion.Rows.Count > 0 Then
            grdMarcaFamilia.DataSource = dtAsignacion
            formatoGrid()
        Else
            'Dim mensajeAdvertencia As New AdvertenciaForm
            'mensajeAdvertencia.mensaje = "No existe ninguna Marca/Familia relacionada para el cliente"
            'mensajeAdvertencia.ShowDialog()
        End If
    End Sub

    Public Sub consultaAgenteSicy()
        Dim dtSicy As New DataTable
        Dim objDatosBu As New Negocios.ClientesDatosBU
        If cmbAgente.SelectedIndex > 0 Then
            dtSicy = objDatosBu.consultaAgenteSicy(cmbAgente.SelectedValue)

            If dtSicy.Rows.Count > 0 Then
                lblAgenteSicy.Text = dtSicy.Rows(0).Item("agenteSicy")
            Else
                lblAgenteSicy.Text = ""
            End If
        Else
            lblAgenteSicy.Text = ""
        End If
    End Sub

    Public Sub consultaMarcasPorAsignar()
        Dim dtProAsignar As New DataTable
        Dim objDatosBu As New Negocios.ClientesDatosBU
        lblTotalSeleccionados.Text = "0"
        If cmbMarcas.SelectedIndex > 0 Then
            dtProAsignar = objDatosBu.consultaMarcasFamiliasPorAsignar(idCliente, cmbMarcas.SelectedValue)
            If dtProAsignar.Rows.Count > 0 Then
                grdMarcaFamilia.DataSource = dtProAsignar
                formatoGrid()
            End If
        End If
    End Sub

    Public Sub guardarRelacionAgenteFamilia()
        Dim objBu As New Negocios.ClientesDatosBU
        Dim tipoOperacion As Int32 = 0
        Dim cont As Int32 = 0
        Dim mensajeAdvertencia As New AdvertenciaForm

        For Each rowgrd In grdMarcaFamilia.Rows
            If rowgrd.Cells("seleccion").Value = True Then
                cont = cont + 1
                Exit For
            End If
        Next
        Dim numRegistroSe As Int32 = CInt(lblTotalSeleccionados.Text)

        If cmbAgente.SelectedIndex > 0 Then

            If cont > 0 Then

                Dim objM As New Tools.ConfirmarForm
                objM.mensaje = "¿Está seguro de guardar la(s) relacion(s) de la(s) familias seleccionadas?"

                If objM.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each rowgrd In grdMarcaFamilia.Rows
                        If rowgrd.Cells("seleccion").Value = True Then
                            If rowgrd.Cells("idagente").Value <> 0 Then
                                ''actualiza el registro
                                tipoOperacion = 0
                            Else
                                ''inserta el registro
                                tipoOperacion = 1
                            End If

                            objBu.insertaActualizaRelacionMarcaFamilia(idCliente, cmbAgente.SelectedValue, rowgrd.Cells("idfamilia").Value, rowgrd.Cells("idMarca").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, tipoOperacion, cbxCoordinador.SelectedValue)
                            objBu.quitaAgenteComision(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, idCliente, rowgrd.Cells("idMarca").Value, cmbAgente.SelectedValue)

                            objBu.replica_ClienteMarcaAgentEmpresa_SAY_SICY(Entidades.SesionUsuario.UsuarioSesion.PUserUsername, idCliente)
                        End If
                    Next
                    Me.Cursor = Cursors.WaitCursor

                    'se ejecuta al final cuando ya se terminó de actualizar los datos
                    objBu.replica_ClienteMarcaFamiliaproyeccion_SAY_SICY()
                    objBu.actualizaProspecta()

                    Me.Cursor = Cursors.Default

                    If cmbMarcas.SelectedIndex > 0 Then
                        consultaMarcasPorAsignar()
                    Else
                        mostrarAsignacionAgenteMarcaFamilia()
                    End If

                End If

            Else
                mensajeAdvertencia.mensaje = "No existe ningún registro seleccionado"
                mensajeAdvertencia.ShowDialog()
            End If


        Else
            mensajeAdvertencia.mensaje = "Debe seleccionar un agente"
            mensajeAdvertencia.ShowDialog()
        End If

    End Sub

    Public Sub cargarComboTodosAgente()
        Dim dtAgentes As New DataTable
        Dim objAgt As New Negocios.AdministradorPedidosBU

        dtAgentes = objAgt.recuperarListaAgentesActivos()

        If dtAgentes.Rows.Count > 0 Then
            Dim newrow As DataRow = dtAgentes.NewRow
            dtAgentes.Rows.InsertAt(newrow, 0)
            cmbAgente.DataSource = dtAgentes
            cmbAgente.ValueMember = "cmae_colaboradorid_agente"
            cmbAgente.DisplayMember = "nombre"
            If dtAgentes.Rows.Count = 2 Then
                cmbAgente.SelectedIndex = 1
            End If
        End If
    End Sub

    Public Sub formatoGrid()
        With grdMarcaFamilia.DisplayLayout.Bands(0)

            .Columns("Id").Hidden = True
            .Columns("idMarca").Hidden = True
            .Columns("idAgente").Hidden = True
            .Columns("idFamilia").Hidden = True

            .Columns("seleccion").Header.Caption = ""
            .Columns("marca").Header.Caption = "Marca"
            .Columns("familia").Header.Caption = "Familia de Ventas"
            .Columns("agente").Header.Caption = "Agente"


            .Columns("marca").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("familia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("agente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("seleccion").Style = ColumnStyle.CheckBox

            .Columns("seleccion").AllowRowFiltering = DefaultableBoolean.False

            Dim colSeleccion As UltraGridColumn = grdMarcaFamilia.DisplayLayout.Bands(0).Columns("Seleccion")
            colSeleccion.DefaultCellValue = False
            colSeleccion.Header.Caption = ""
            colSeleccion.Header.VisiblePosition = 0
            colSeleccion.Style = ColumnStyle.CheckBox
            colSeleccion.Width = 50

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)


        End With


        grdMarcaFamilia.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdMarcaFamilia.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMarcaFamilia.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdMarcaFamilia.DisplayLayout.Override.RowSelectorWidth = 35
        grdMarcaFamilia.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdMarcaFamilia.Rows(0).Selected = True
        grdMarcaFamilia.DisplayLayout.Bands(0).Columns("seleccion").Width = 18
        grdMarcaFamilia.DisplayLayout.Bands(0).Columns("marca").Width = 80
        grdMarcaFamilia.DisplayLayout.Bands(0).Columns("familia").Width = 140
    End Sub

    Private Sub AgenteMarcaFamiliaVentasForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENTAS_VENT_FTC", "ELIMINAR_MAR_AG_VEN") Then
            btnEliminar.Visible = True
            lblEliminar.Visible = True
        Else
            btnEliminar.Visible = False
            lblEliminar.Visible = False
        End If

        cargarComboTodosAgente()
        cargarComboMarcas()
        cargarComboCoord()
    End Sub

    Private Sub cmbMarcas_DropDownClosed(sender As Object, e As EventArgs) Handles cmbMarcas.DropDownClosed
        If cmbMarcas.SelectedIndex > 0 Then
            cargarComboAgentes(idCliente, cmbMarcas.SelectedValue)
            consultaMarcasPorAsignar()
        Else
            cmbAgente.DataSource = Nothing

        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub



    Private Sub grdMarcaFamilia_CellChange(sender As Object, e As CellEventArgs) Handles grdMarcaFamilia.CellChange
        If e.Cell.Column.Key = "seleccion" And e.Cell.Row.Index <> grdMarcaFamilia.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0

            For Each rowGR As UltraGridRow In grdMarcaFamilia.Rows
                If CBool(rowGR.Cells("seleccion").Text) = True Then

                    contadorSeleccion += 1

                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        If Not grdMarcaFamilia.DataSource Is Nothing Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdMarcaFamilia.Rows.GetFilteredInNonGroupByRows
                rowGR.Cells("seleccion").Value = CBool(chkSeleccionarTodo.Checked)
                If CBool(rowGR.Cells("seleccion").Text) = True Then
                    contadorSeleccion += 1
                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub grdMarcaFamilia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcaFamilia.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next

    End Sub

    Private Sub grdMarcaFamilia_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdMarcaFamilia.InitializeRow
        e.Row.Cells("seleccion").Activation = Activation.AllowEdit
    End Sub

    Private Sub grdMarcaFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarcaFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdMarcaFamilia.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdMarcaFamilia.DisplayLayout.Bands(0)
            If grdMarcaFamilia.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdMarcaFamilia.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdMarcaFamilia.ActiveCell = nextRow.Cells(grdMarcaFamilia.ActiveCell.Column)
                e.Handled = True
                grdMarcaFamilia.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub btnMostrarTodo_Click(sender As Object, e As EventArgs) Handles btnMostrarTodo.Click
        cargarComboTodosAgente()
        mostrarAsignacionAgenteMarcaFamilia()
    End Sub

    Private Sub cmbAgente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgente.SelectedIndexChanged
        consultaAgenteSicy()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardarRelacionAgenteFamilia()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarRelacionAgenteFamilia()
    End Sub

    Private Sub EliminarRelacionAgenteFamilia()
        Dim obj As New Negocios.ClientesDatosBU
        Dim tbl As New DataTable
        Dim id As Integer = 0
        Dim tblPedidos As New DataTable
        Dim idpedido As Integer = 0
        Dim tblPedidosDetalles As New DataTable
        Dim idPE As Integer = 0
        Dim idMarca As Integer
        Dim idFamilia As Integer
        Dim idAgente As Integer
        Dim usuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        Dim eliminar As Integer
        Dim listaSiEliminar As New List(Of Integer)
        Dim listaNoEliminar As New List(Of Integer)

        tbl = dtAsignacion.AsEnumerable().Where(Function(x) x.Item("seleccion") = True).CopyToDataTable

        If tbl.Rows.Count > 0 Then
            Try
                Me.Cursor = Cursors.WaitCursor
                For index As Integer = 0 To tbl.Rows.Count - 1
                    id = tbl.Rows(index).Item("Id")
                    idMarca = tbl.Rows(index).Item("idMarca")
                    idFamilia = tbl.Rows(index).Item("idFamilia")
                    idAgente = tbl.Rows(index).Item("idAgente")
                    tblPedidos = obj.ConsultaPedidosCliente(idCliente)
                    If tblPedidos.Rows.Count > 0 Then
                        For p As Integer = 0 To tblPedidos.Rows.Count - 1
                            idpedido = tblPedidos.Rows(p).Item("IdPedido")
                            tblPedidosDetalles = obj.ConsultaPedidosDetalleCliente(idpedido)
                            If tblPedidosDetalles.Rows.Count > 0 Then
                                'For pd As Integer = 0 To tblPedidosDetalles.Rows.Count
                                'idPE = tblPedidosDetalles.Rows(pd).Item("ProductoEstiloId")
                                eliminar = ValidaEliminar(idpedido, idMarca, idFamilia)
                                If eliminar = 0 Then
                                    listaSiEliminar.Add(id)
                                Else
                                    listaNoEliminar.Add(id)
                                End If
                                'Next
                            End If
                        Next
                    End If
                Next

                Dim IdsEliminar As List(Of Integer) = listaSiEliminar.Distinct().ToList()
                Dim IdsNoEliminar As List(Of Integer) = listaNoEliminar.Distinct().ToList()

                Dim listN = listaSiEliminar.Except(listaNoEliminar).ToList()

                Dim t As New DataTable
                t.Columns.Add("Id")
                t.Columns.Add("idCliente")
                t.Columns.Add("idMarca")
                t.Columns.Add("idFamilia")
                t.Columns.Add("idAgente")
                t.Columns.Add("idUsuarioinactivo")

                If listN.Count > 0 Then
                    For i As Integer = 0 To listN.Count - 1
                        Dim renglon As DataRow = t.NewRow()
                        id = IdsEliminar(i)
                        renglon("id") = id

                        idMarca = tbl.AsEnumerable().Where(Function(x) x.Item("id") = id).Select(Function(y) y.Item("idMarca")).First
                        renglon("idMarca") = idMarca

                        renglon("idCliente") = idCliente

                        idFamilia = tbl.AsEnumerable().Where(Function(x) x.Item("id") = id).Select(Function(y) y.Item("idFamilia")).First
                        renglon("idFamilia") = idFamilia

                        idAgente = tbl.AsEnumerable().Where(Function(x) x.Item("id") = id).Select(Function(y) y.Item("idAgente")).First
                        renglon("idAgente") = idAgente

                        renglon("idUsuarioinactivo") = usuario

                        t.Rows.Add(renglon)
                    Next
                End If


                If listN.Count > 0 Then
                    Dim objM As New Tools.ConfirmarForm
                    objM.mensaje = "¿Está seguro de eliminar los registros seleccionados?"

                    If objM.ShowDialog = Windows.Forms.DialogResult.OK Then
                        EliminarRegistro(listN, t)
                        Dim objMe As New Tools.ExitoForm
                        objM.mensaje = "Se han eliminado correctamente."
                    End If
                Else
                    Tools.MostrarMensaje("Advertencia", "No es posible eliminar algunos registros")
                End If

                mostrarAsignacionAgenteMarcaFamilia()

            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try


        Else
            Tools.MostrarMensaje("Advertencia", "Seleccione al menos un registro.")
        End If

    End Sub


    Public Function ValidaEliminar(idPedido, idMarca, idFamilia) As Integer
        Dim obj As New Negocios.ClientesDatosBU
        Dim existen As Integer
        Dim tblexisten As New DataTable

        tblexisten = obj.ValidaExistenArticulos(idPedido, idMarca, idFamilia)
        existen = tblexisten.Rows(0).Item("Existen")
        Return existen
    End Function

    Public Sub EliminarRegistro(ByVal listaEliminar As List(Of Integer), ByVal tblId As DataTable)
        Dim obj As New Negocios.ClientesDatosBU
        Dim cadena As String = String.Empty
        Dim tblIDs As New DataTable

        For i As Integer = 0 To listaEliminar.Count - 1
            If cadena = String.Empty Then
                cadena = listaEliminar(i).ToString()
            Else
                cadena = listaEliminar(i).ToString() & "," & cadena
            End If
        Next

        obj.Eliminarregistro(cadena)

        tblIDs = tblId

        For i As Integer = 0 To tblIDs.Rows.Count - 1
            obj.GuardarBitacoraInactivos(
                    tblIDs.Rows(i).Item("Id"),
                    idCliente,
                    tblIDs.Rows(i).Item("idAgente"),
                    tblIDs.Rows(i).Item("idFamilia"),
                    tblIDs.Rows(i).Item("idAgente"),
                    Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    )
        Next

    End Sub


End Class