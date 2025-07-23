Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class frmMoverHorma

    'Public Sub llenarComboArticulos()
    '    Dim objBU As New Negocios.ProductosBU
    '    Dim dt As New DataTable
    '    dt = objBU.verDetallesProducto(1)

    '    If dt.Rows.Count > 0 Then
    '        dt.Rows.InsertAt(dt.NewRow, 0)
    '        cmbArticulos.DataSource = dt
    '        cmbArticulos.DisplayMember = ""
    '        cmbArticulos.ValueMember = "pres_productoestiloid"
    '    End If

    'End Sub

    'Public Sub llenarComboHormas()
    '    Dim objBU As New Negocios.HormasBU
    '    Dim dt As New DataTable
    '    dt = objBU.verListaHormas("", "", 1)

    '    If dt.Rows.Count > 0 Then
    '        dt.Rows.InsertAt(dt.NewRow, 0)
    '        cmbHormas.DataSource = dt
    '        cmbHormas.DisplayMember = "horma_descripcion"
    '        cmbHormas.ValueMember = "horma_hormaid"
    '    End If

    'End Sub

    Public Sub inhabilitarBotones()
        If cmbSimulaciones.SelectedIndex > 0 Then
            If CBool(cmbSimulaciones.SelectedItem("ProcSimMae_Estatus")) = True Then
                grpProductosDatos.Enabled = True
                grpHormasDatos.Enabled = True
                btnEliminar.Enabled = True
                btnGuardar.Enabled = True
                btnGuardarOrdenamiento.Enabled = True
                lblQuitar.Enabled = True
                lblGuardar.Enabled = True
                lblGuardarOrden.Enabled = True
            Else
                grpProductosDatos.Enabled = False
                grpHormasDatos.Enabled = False
                btnEliminar.Enabled = False
                btnGuardar.Enabled = False
                btnGuardarOrdenamiento.Enabled = False
                lblQuitar.Enabled = False
                lblGuardar.Enabled = False
                lblGuardarOrden.Enabled = False
            End If
        Else
            grpProductosDatos.Enabled = True
            grpHormasDatos.Enabled = True
            btnEliminar.Enabled = True
            btnGuardar.Enabled = True
            btnGuardarOrdenamiento.Enabled = True
            lblQuitar.Enabled = True
            lblGuardar.Enabled = True
            lblGuardarOrden.Enabled = True
        End If
    End Sub

    Public Sub modificarOrdenNAvesArticulo()
        Dim objBU As New Negocios.productosCapacidadBU
        For Each rowGrd As UltraGridRow In grdOrdenNaves.Rows
            objBU.editarOrdenNaveArticuloSimulacion(rowGrd.Cells("ordenArtNaveSimId").Value, rowGrd.Cells("orden").Value)
        Next
        Dim objExito As New Tools.ExitoForm
        objExito.mensaje = "Registro correcto"
        objExito.ShowDialog()
    End Sub

    Public Sub editarTipoAlta(ByVal idSimCapArticulo As Int32,
                                                 ByVal idTipoAlta As Int32,
                                                 ByVal idLineaOrigen As Int32)
        Dim objBU As New Negocios.productosCapacidadBU
        objBU.editarTipoAltaCapacidadArticuloSimulacion(idSimCapArticulo, idTipoAlta, idLineaOrigen)
    End Sub

    Public Sub eliminarCapacidadArticulos()
        Dim objBU As New Negocios.productosCapacidadBU
        Dim objMensaje As New Tools.ConfirmarForm
        objMensaje.mensaje = "¿Esta seguro de quitar las capacidades?"
        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
            'For Each rowGrd As UltraGridRow In grdArticulosDestino.Rows
            '    If rowGrd.Cells("Sel").Value = True Then
            '        If rowGrd.Cells("articuloCapacidadId").Value > 0 Then
            '            objBU.inactivarArticuloCapacidadSimulacion(rowGrd.Cells("articuloCapacidadId").Value)
            '        Else

            '        End If
            '    End If
            'Next

            Dim cambioAlgo As Boolean = False

            For i As Int32 = grdArticulosDestino.Rows.Count - 1 To 0 Step -1
                If grdArticulosDestino.Rows(i).Cells("Sel").Value = True Then
                    If grdArticulosDestino.Rows(i).Cells("articuloCapacidadId").Value > 0 Then
                        objBU.inactivarArticuloCapacidadSimulacion(grdArticulosDestino.Rows(i).Cells("articuloCapacidadId").Value)
                        grdArticulosDestino.Rows(i).Delete()
                        cambioAlgo = True
                    Else
                        grdArticulosDestino.Rows(i).Delete()
                        cambioAlgo = True
                    End If
                End If
            Next

            ''inicializaTablaDestino()
            If cambioAlgo = True Then
                Dim objMsjExito As New Tools.ExitoForm
                objMsjExito.mensaje = "Registro exitoso"
                objMsjExito.ShowDialog()
            Else
                Dim objMsjExito As New Tools.AdvertenciaForm
                objMsjExito.mensaje = "No se realizó ningún cambio"
                objMsjExito.ShowDialog()
            End If

        End If
    End Sub

    Public Sub editarCapacidadArticuloSimulacion(ByVal idSimCapacidadArticulo As Int32,
                                                 ByVal semanaInicio As Int32,
                                                 ByVal semanaFin As Int32,
                                                 ByVal cantidad As Int32)
        Dim objBU As New Negocios.productosCapacidadBU
        objBU.editarCapacidadArticuloSimulacion(idSimCapacidadArticulo, semanaInicio, semanaFin, cantidad)
    End Sub

    Public Sub editarHoramaCapacidadSimulacion(ByVal idSimCapacidadHorma As Int32, ByVal semanaInicio As Int32,
                                               ByVal semanaFin As Int32, ByVal cantidad As Int32)
        Dim objBU As New Negocios.HormasCapacidadesBU
        objBU.editarHormaCapacidadSimulacion(idSimCapacidadHorma, semanaInicio, semanaFin, cantidad)
    End Sub

    Public Sub llenarGridHormas()
        If cmbSimulaciones.SelectedIndex > 0 Then
            Dim objBU As New Negocios.HormasCapacidadesBU
            Dim dt As New DataTable
            Dim idLinea As Int32 = 0
            If cmbLineaProduccion.SelectedIndex > 0 Then
                idLinea = cmbLineaProduccion.SelectedValue
            End If
            dt = objBU.consultaSimulacionHormasCapacidad(cmbSimulaciones.SelectedValue, idLinea)
            If dt.Rows.Count > 0 Then
                grdHormasCapacidadSimulacion.DataSource = dt
                With grdHormasCapacidadSimulacion.DisplayLayout.Bands(0)
                    .Columns("smhc_simulacionHormasCapacidadId").Hidden = True
                    .Columns("smhc_simulacionId").Hidden = True
                    .Columns("smhc_lineaId").Hidden = True
                    .Columns("smhc_hormaId").Hidden = True
                    .Columns("smhc_tipoAlta").Hidden = True
                    .Columns("smhc_hormaCapacidadCopiaId").Hidden = True
                    .Columns("smhc_hormaCapacidadCambioId").Hidden = True
                    .Columns("smhc_tallaid").Hidden = True
                    .Columns("horma_descripcion").Header.Caption = "Horma"
                    .Columns("smhc_anio").Header.Caption = "Año"
                    .Columns("Sel").Header.Caption = ""
                    .Columns("talla_descripcion").Header.Caption = "Talla"
                    .Columns("horma_descripcion").CellActivation = Activation.NoEdit
                    .Columns("smhc_anio").CellActivation = Activation.NoEdit
                    .Columns("talla_descripcion").CellActivation = Activation.NoEdit
                    For i As Int32 = 1 To 52
                        .Columns("smhc_" + i.ToString).Header.Caption = i.ToString
                        '.Columns("smhc_" + i.ToString).CellActivation = Activation.NoEdit
                        If CBool(cmbSimulaciones.SelectedItem("ProcSimMae_Estatus")) = False Then
                            .Columns("smhc_" + i.ToString).CellActivation = Activation.NoEdit
                        End If
                    Next
                    .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                End With
                grdHormasCapacidadSimulacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                grdHormasCapacidadSimulacion.DisplayLayout.Override.RowSelectorWidth = 35
                grdHormasCapacidadSimulacion.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            Else
                grdHormasCapacidadSimulacion.DataSource = Nothing
            End If
        Else
            grdHormasCapacidadSimulacion.DataSource = Nothing
        End If
    End Sub

    Public Sub guardarCapacidadesConfiguradas()
        Me.Cursor = Cursors.WaitCursor
        Dim objProdBU As New Negocios.productosCapacidadBU
        Dim objHormBU As New Negocios.HormasCapacidadesBU

        Dim entProdCap As New Entidades.ProductoCapacidad
        Dim entHormsCap As New Entidades.HormasCapacidad
        ' '' Tipo Alta Duplicar = 1 Traspasar = 2 Añadir = 3
        Dim tipoAlta As Int32 = 0, idCopia As Int32 = 0, idCambio As Int32
        Dim existeHorma As Int32 = 0
        For Each rowGrd As UltraGridRow In grdArticulosDestino.Rows
            entProdCap = New Entidades.ProductoCapacidad

            entProdCap.Id = rowGrd.Cells("articuloCapacidadId").Value
            entProdCap.Anio = rowGrd.Cells("anio").Value
            entProdCap.HormaId = rowGrd.Cells("horma").Value
            entProdCap.LineaId = IIf(rowGrd.Cells("IdLineaOrigen").Value.ToString <> "", rowGrd.Cells("IdLineaOrigen").Value, 0)
            entProdCap.ProductoEstiloId = rowGrd.Cells("IdPstilo").Value
            entProdCap.ProductoId = IIf(rowGrd.Cells("IdProducto").Value.ToString <> "", rowGrd.Cells("IdProducto").Value, 0)
            entProdCap.TallaId = rowGrd.Cells("Talla").Value
            entProdCap.Semana1 = rowGrd.Cells("sm1").Value
            entProdCap.Semana2 = rowGrd.Cells("sm2").Value
            entProdCap.Semana3 = rowGrd.Cells("sm3").Value
            entProdCap.Semana4 = rowGrd.Cells("sm4").Value
            entProdCap.Semana5 = rowGrd.Cells("sm5").Value
            entProdCap.Semana6 = rowGrd.Cells("sm6").Value
            entProdCap.Semana7 = rowGrd.Cells("sm7").Value
            entProdCap.Semana8 = rowGrd.Cells("sm8").Value
            entProdCap.Semana9 = rowGrd.Cells("sm9").Value
            entProdCap.Semana10 = rowGrd.Cells("sm10").Value
            entProdCap.Semana11 = rowGrd.Cells("sm11").Value
            entProdCap.Semana12 = rowGrd.Cells("sm12").Value
            entProdCap.Semana13 = rowGrd.Cells("sm13").Value
            entProdCap.Semana14 = rowGrd.Cells("sm14").Value
            entProdCap.Semana15 = rowGrd.Cells("sm15").Value
            entProdCap.Semana16 = rowGrd.Cells("sm16").Value
            entProdCap.Semana17 = rowGrd.Cells("sm17").Value
            entProdCap.Semana18 = rowGrd.Cells("sm18").Value
            entProdCap.Semana19 = rowGrd.Cells("sm19").Value
            entProdCap.Semana20 = rowGrd.Cells("sm20").Value
            entProdCap.Semana21 = rowGrd.Cells("sm21").Value
            entProdCap.Semana22 = rowGrd.Cells("sm22").Value
            entProdCap.Semana23 = rowGrd.Cells("sm23").Value
            entProdCap.Semana24 = rowGrd.Cells("sm24").Value
            entProdCap.Semana25 = rowGrd.Cells("sm25").Value
            entProdCap.Semana26 = rowGrd.Cells("sm26").Value
            entProdCap.Semana27 = rowGrd.Cells("sm27").Value
            entProdCap.Semana28 = rowGrd.Cells("sm28").Value
            entProdCap.Semana29 = rowGrd.Cells("sm29").Value
            entProdCap.Semana30 = rowGrd.Cells("sm30").Value
            entProdCap.Semana31 = rowGrd.Cells("sm31").Value
            entProdCap.Semana32 = rowGrd.Cells("sm32").Value
            entProdCap.Semana33 = rowGrd.Cells("sm33").Value
            entProdCap.Semana34 = rowGrd.Cells("sm34").Value
            entProdCap.Semana35 = rowGrd.Cells("sm35").Value
            entProdCap.Semana36 = rowGrd.Cells("sm36").Value
            entProdCap.Semana37 = rowGrd.Cells("sm37").Value
            entProdCap.Semana38 = rowGrd.Cells("sm38").Value
            entProdCap.Semana39 = rowGrd.Cells("sm39").Value
            entProdCap.Semana40 = rowGrd.Cells("sm40").Value
            entProdCap.Semana41 = rowGrd.Cells("sm41").Value
            entProdCap.Semana42 = rowGrd.Cells("sm42").Value
            entProdCap.Semana43 = rowGrd.Cells("sm43").Value
            entProdCap.Semana44 = rowGrd.Cells("sm44").Value
            entProdCap.Semana45 = rowGrd.Cells("sm45").Value
            entProdCap.Semana46 = rowGrd.Cells("sm46").Value
            entProdCap.Semana47 = rowGrd.Cells("sm47").Value
            entProdCap.Semana48 = rowGrd.Cells("sm48").Value
            entProdCap.Semana49 = rowGrd.Cells("sm49").Value
            entProdCap.Semana50 = rowGrd.Cells("sm50").Value
            entProdCap.Semana51 = rowGrd.Cells("sm51").Value
            entProdCap.Semana52 = rowGrd.Cells("sm52").Value

            If rowGrd.Cells("tipoAlta").Value = 1 Then
                tipoAlta = 1
                If rowGrd.Cells("articuloCapacidadId").Value <= 0 Then
                    idCopia = cmbLineasProduccionArticulos.SelectedValue
                Else
                    idCopia = rowGrd.Cells("IdLineaOrigen").Value
                End If
                idCambio = 0
            ElseIf rowGrd.Cells("tipoAlta").Value = 2 = True Then
                tipoAlta = 2
                idCopia = 0
                If rowGrd.Cells("articuloCapacidadId").Value <= 0 Then
                    idCambio = cmbLineasProduccionArticulos.SelectedValue
                Else
                    idCambio = rowGrd.Cells("IdLineaOrigen").Value
                End If

            ElseIf rowGrd.Cells("tipoAlta").Value = 3 Then
                tipoAlta = 3
                idCopia = 0
                idCambio = 0
            End If

            existeHorma = objHormBU.consultaValidaExisteHormaSimulacion(entProdCap, cmbLineaProduccion.SelectedValue)

            If existeHorma <= 0 Then
                Dim cantidadValorHorma As Int32 = IIf(rowGrd.Cells("sm1").Value.ToString <> "", rowGrd.Cells("sm1").Value, 0)
                Dim valorV As Int32 = 0
                For Each rowGrP As UltraGridRow In grdArticulosDestino.Rows
                    If rowGrP.Cells("horma").Value = rowGrd.Cells("horma").Value Then
                        For i As Int32 = 1 To 52
                            valorV = IIf(rowGrd.Cells("sm" + i.ToString).Value.ToString <> "", rowGrd.Cells("sm" + i.ToString).Value, 0)
                            If valorV > cantidadValorHorma Then
                                cantidadValorHorma = valorV
                            End If
                        Next
                    End If
                Next

                entHormsCap = New Entidades.HormasCapacidad
                entHormsCap.Anio = rowGrd.Cells("anio").Value
                entHormsCap.IdHorma = rowGrd.Cells("horma").Value
                entHormsCap.LineaId = IIf(rowGrd.Cells("IdLineaOrigen").Value.ToString <> "", rowGrd.Cells("IdLineaOrigen").Value, 0)
                entHormsCap.Talla = rowGrd.Cells("Talla").Value
                entHormsCap.Semana1 = cantidadValorHorma
                entHormsCap.Semana2 = cantidadValorHorma
                entHormsCap.Semana3 = cantidadValorHorma
                entHormsCap.Semana4 = cantidadValorHorma
                entHormsCap.Semana5 = cantidadValorHorma
                entHormsCap.Semana6 = cantidadValorHorma
                entHormsCap.Semana7 = cantidadValorHorma
                entHormsCap.Semana8 = cantidadValorHorma
                entHormsCap.Semana9 = cantidadValorHorma
                entHormsCap.Semana10 = cantidadValorHorma
                entHormsCap.Semana11 = cantidadValorHorma
                entHormsCap.Semana12 = cantidadValorHorma
                entHormsCap.Semana13 = cantidadValorHorma
                entHormsCap.Semana14 = cantidadValorHorma
                entHormsCap.Semana15 = cantidadValorHorma
                entHormsCap.Semana16 = cantidadValorHorma
                entHormsCap.Semana17 = cantidadValorHorma
                entHormsCap.Semana18 = cantidadValorHorma
                entHormsCap.Semana19 = cantidadValorHorma
                entHormsCap.Semana20 = cantidadValorHorma
                entHormsCap.Semana21 = cantidadValorHorma
                entHormsCap.Semana22 = cantidadValorHorma
                entHormsCap.Semana23 = cantidadValorHorma
                entHormsCap.Semana24 = cantidadValorHorma
                entHormsCap.Semana25 = cantidadValorHorma
                entHormsCap.Semana26 = cantidadValorHorma
                entHormsCap.Semana27 = cantidadValorHorma
                entHormsCap.Semana28 = cantidadValorHorma
                entHormsCap.Semana29 = cantidadValorHorma
                entHormsCap.Semana30 = cantidadValorHorma
                entHormsCap.Semana31 = cantidadValorHorma
                entHormsCap.Semana32 = cantidadValorHorma
                entHormsCap.Semana33 = cantidadValorHorma
                entHormsCap.Semana34 = cantidadValorHorma
                entHormsCap.Semana35 = cantidadValorHorma
                entHormsCap.Semana36 = cantidadValorHorma
                entHormsCap.Semana37 = cantidadValorHorma
                entHormsCap.Semana38 = cantidadValorHorma
                entHormsCap.Semana39 = cantidadValorHorma
                entHormsCap.Semana40 = cantidadValorHorma
                entHormsCap.Semana41 = cantidadValorHorma
                entHormsCap.Semana42 = cantidadValorHorma
                entHormsCap.Semana43 = cantidadValorHorma
                entHormsCap.Semana44 = cantidadValorHorma
                entHormsCap.Semana45 = cantidadValorHorma
                entHormsCap.Semana46 = cantidadValorHorma
                entHormsCap.Semana47 = cantidadValorHorma
                entHormsCap.Semana48 = cantidadValorHorma
                entHormsCap.Semana49 = cantidadValorHorma
                entHormsCap.Semana50 = cantidadValorHorma
                entHormsCap.Semana51 = cantidadValorHorma
                entHormsCap.Semana52 = cantidadValorHorma
                objHormBU.insertarCapacidadSimulacion(cmbLineaProduccion.SelectedValue, tipoAlta, idCopia, idCambio, cmbSimulaciones.SelectedValue, entHormsCap)
            End If

            If rowGrd.Cells("articuloCapacidadId").Value <= 0 Then
                Dim dtIdRegistro As New DataTable
                dtIdRegistro = objProdBU.insertarCapacidadSimulador(cmbLineaProduccion.SelectedValue, tipoAlta, idCopia, idCambio, cmbSimulaciones.SelectedValue, entProdCap)
                If dtIdRegistro.Rows.Count > 0 Then
                    If dtIdRegistro.Rows(0).Item(0).ToString <> "" Then
                        If CInt(dtIdRegistro.Rows(0).Item(0)) > 0 Then
                            rowGrd.Cells("articuloCapacidadId").Value = dtIdRegistro.Rows(0).Item(0)
                        End If
                    End If
                End If
            Else
                'Aqui va el de editar
            End If

            Dim dtOrden As New DataTable
            dtOrden = objProdBU.consultaOrdenProductoNaveSimulacion(cmbSimulaciones.SelectedValue, rowGrd.Cells("IdPstilo").Value, True, 0)
            If dtOrden.Rows.Count > 0 Then
                If rowGrd.Cells("articuloCapacidadId").Value <= 0 Then
                    Dim ordn As Int32 = dtOrden.Rows.Count + 1
                    objProdBU.insertarOrdenArticuloNaveSimulacion(cmbSimulaciones.SelectedValue, rowGrd.Cells("IdPstilo").Value, cmbLineaProduccion.SelectedItem("idNave"), ordn)
                Else
                    Dim existeNave As Boolean = False
                    For Each dtr As DataRow In dtOrden.Rows
                        If dtr.Item("naveId") = cmbLineaProduccion.SelectedItem("idNave") Then
                            existeNave = True
                        End If
                    Next
                    Dim ordn As Int32 = dtOrden.Rows.Count + 1
                    If existeNave = False Then
                        objProdBU.insertarOrdenArticuloNaveSimulacion(cmbSimulaciones.SelectedValue,
                                                                  rowGrd.Cells("IdPstilo").Value, cmbLineaProduccion.SelectedItem("idNave"), ordn)
                    End If
                End If
            Else
                dtOrden = New DataTable

                dtOrden = objProdBU.consultaOrdenProductoNaveSimulacion(cmbSimulaciones.SelectedValue, rowGrd.Cells("IdPstilo").Value, False, cmbLineaProduccion.SelectedItem("idNave"))
                Dim existeNave As Boolean = False
                For Each dtr As DataRow In dtOrden.Rows
                    If dtr.Item("naveId") = cmbLineaProduccion.SelectedItem("idNave") Then
                        existeNave = True
                    End If
                Next

                If existeNave = False Then
                    Dim filaDT As DataRow
                    filaDT = dtOrden.NewRow
                    filaDT.Item("ordenArtNaveSimId") = 0
                    filaDT.Item("simulacionId") = 0
                    filaDT.Item("productoEstiloId") = rowGrd.Cells("IdPstilo").Value
                    filaDT.Item("naveId") = cmbLineaProduccion.SelectedItem("idNave")
                    filaDT.Item("nave") = cmbLineaProduccion.Text
                    filaDT.Item("orden") = dtOrden.Rows.Count + 1
                    dtOrden.Rows.Add(filaDT)
                End If

                Dim ordn As Int32 = 1
                For Each rowDt As DataRow In dtOrden.Rows
                    objProdBU.insertarOrdenArticuloNaveSimulacion(cmbSimulaciones.SelectedValue,
                                                                    rowDt.Item("productoEstiloId"), rowDt.Item("naveId"), ordn)
                    ordn += 1
                Next
            End If

        Next
        inicializaTablaDestino()
        Me.Cursor = Cursors.Default
        Dim objMsjExito As New Tools.ExitoForm
        objMsjExito.mensaje = "Registro exitoso"
        objMsjExito.ShowDialog()
    End Sub

    Public Sub cambiarapacidadSeleccionados()
        Dim objBU As New Negocios.productosCapacidadBU
        Dim guardo As Boolean = False

        For Each rowGrd As UltraGridRow In grdArticulosDestino.Rows
            If CBool(rowGrd.Cells("Sel").Value) = True Then
                If rowGrd.Cells("articuloCapacidadId").Value > 0 Then
                    objBU.editarCapacidadArticuloSimulacion(rowGrd.Cells("articuloCapacidadId").Value, numSemPrdsInicio.Value, numSemPrdsFin.Value, numCamtidadProds.Value)
                Else
                    For i As Int32 = numSemPrdsInicio.Value To numSemPrdsFin.Value
                        rowGrd.Cells("sm" + i.ToString).Value = numCamtidadProds.Value
                    Next
                End If
                guardo = True
            End If
        Next
        inicializaTablaDestino()
        If guardo = True Then
            Dim objMsjExito As New Tools.ExitoForm
            objMsjExito.mensaje = "Registro exitoso"
            objMsjExito.ShowDialog()
        Else
            Dim objMsjEAdv As New Tools.ExitoForm
            objMsjEAdv.mensaje = "No se realizó ningún cambio"
            objMsjEAdv.ShowDialog()
        End If

    End Sub

    Public Sub inicializaTablaDestino()
        lblSeleccionado.Text = String.Empty
        grdArticulosDestino.DataSource = Nothing
        grdOrdenNaves.DataSource = Nothing
        If cmbSimulaciones.SelectedIndex > 0 And cmbLineaProduccion.SelectedIndex > 0 Then

            Dim objBU As New Negocios.productosCapacidadBU
            Dim dtArticulosCap As New DataTable
            Dim idLinea As Int32 = 0
            Dim idLineaOrigen As Int32 = 0
            Dim listaTipoAlta As New Infragistics.Win.ValueList

            If cmbLineasProduccionArticulos.SelectedIndex > 0 Then
                idLineaOrigen = cmbLineasProduccionArticulos.SelectedValue
            End If
            If cmbLineaProduccion.SelectedIndex > 0 Then
                idLinea = cmbLineaProduccion.SelectedValue
            End If

            dtArticulosCap = objBU.consultaArticulosConfigurados(cmbSimulaciones.SelectedValue, idLinea, idLineaOrigen)

            grdArticulosDestino.DataSource = dtArticulosCap

            listaTipoAlta = New Infragistics.Win.ValueList
            listaTipoAlta.ValueListItems.Add(1, "Duplicar")
            listaTipoAlta.ValueListItems.Add(2, "Traspasar")
            listaTipoAlta.ValueListItems.Add(3, "Añadir")

            For Each rowGrd As UltraGridRow In grdArticulosDestino.Rows
                rowGrd.Cells("tipoAlta").ValueList = listaTipoAlta
                If rowGrd.Cells("tipoAlta").Value = 3 Then
                    rowGrd.Cells("tipoAlta").Activation = Activation.NoEdit
                End If
            Next

            Dim banda As UltraGridBand = grdArticulosDestino.DisplayLayout.Bands(0)
            With banda
                .Columns("IdProducto").Hidden = True
                .Columns("IdPstilo").Hidden = True
                .Columns("IdLineaOrigen").Hidden = True
                .Columns("talla").Hidden = True
                .Columns("horma").Hidden = True
                .Columns("articuloCapacidadId").Hidden = True
                .Columns("tipoAlta").Header.Caption = "Tipo Alta"
                .Columns("anio").Header.Caption = "Año"
                .Columns("Descripcion").Header.Caption = "Descripción"
                .Columns("anio").CellActivation = Activation.NoEdit
                .Columns("articuloCapacidadId").CellActivation = Activation.NoEdit
                .Columns("Descripcion").CellActivation = Activation.NoEdit
                .Columns("Sel").Header.Caption = ""
                For i As Int32 = 1 To 52
                    .Columns("sm" + i.ToString).Header.Caption = i.ToString
                    If CBool(cmbSimulaciones.SelectedItem("ProcSimMae_Estatus")) = False Then
                        .Columns("sm" + i.ToString).CellActivation = Activation.NoEdit
                    End If
                Next
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            grdArticulosDestino.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdArticulosDestino.DisplayLayout.Override.RowSelectorWidth = 35
            grdArticulosDestino.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            'Else
            '    Dim objMsjAdv As New Tools.AdvertenciaForm
            '    objMsjAdv.mensaje = "Es necesario seleccionar una una simulación y una línea de producción."
            '    objMsjAdv.ShowDialog()
        End If
    End Sub

    Public Sub llenarDatosTablaOrigen(ByVal dt As DataTable)
        If cmbLineaProduccion.SelectedIndex > 0 And cmbSimulaciones.SelectedIndex > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim objPCBU As New Negocios.productosCapacidadBU
            Dim dtProdCap As New DataTable
            If dt.Rows.Count > 0 Then
                Dim listaTipoAlta As New Infragistics.Win.ValueList
                For Each rowDtArt As DataRow In dt.Rows
                    dtProdCap = New DataTable
                    If rdoDuplicar.Checked = True Or rdoTraspasar.Checked = True Then
                        dtProdCap = objPCBU.consultaListaProductosCapacidadCopiar(IIf(cmbLineasProduccionArticulos.SelectedIndex > 0, cmbLineasProduccionArticulos.SelectedValue, 0), rowDtArt.Item("horma"), rowDtArt.Item("talla"), rowDtArt.Item("idPEstilo"), numAnioProds.Value)
                    Else
                        dtProdCap.Columns.Add("proc_procID")
                        dtProdCap.Columns.Add("proc_linpID")
                        dtProdCap.Columns.Add("proc_hormaid")
                        dtProdCap.Columns.Add("proc_productoEstiloId")
                        dtProdCap.Columns.Add("codigo")
                        dtProdCap.Columns.Add("proc_tallaID")
                        dtProdCap.Columns.Add("proc_prodID")
                        dtProdCap.Columns.Add("proc_productonaveid")
                        dtProdCap.Columns.Add("proc_año")
                        dtProdCap.Columns.Add("proc_activo")
                        For i As Int32 = 1 To 52
                            dtProdCap.Columns.Add("proc_" + i.ToString)
                        Next

                        Dim rowNv As DataRow = dtProdCap.NewRow
                        rowNv.Item("proc_procID") = 0
                        rowNv.Item("proc_linpID") = cmbLineaProduccion.SelectedValue
                        rowNv.Item("proc_hormaid") = rowDtArt.Item("horma")
                        rowNv.Item("proc_productoEstiloId") = rowDtArt.Item("idPEstilo")
                        rowNv.Item("codigo") = rowDtArt.Item("codigo")
                        rowNv.Item("proc_tallaID") = rowDtArt.Item("talla")
                        rowNv.Item("proc_prodID") = rowDtArt.Item("idProducto")
                        rowNv.Item("proc_productonaveid") = 0
                        rowNv.Item("proc_año") = numAnioProds.Value
                        rowNv.Item("proc_activo") = True
                        For i As Int32 = 1 To 52
                            rowNv.Item("proc_" + i.ToString) = 0
                        Next
                        dtProdCap.Rows.Add(rowNv)

                    End If


                    If dtProdCap.Rows.Count > 0 Then
                        listaTipoAlta = New Infragistics.Win.ValueList
                        listaTipoAlta.ValueListItems.Add(1, "Duplicar")
                        listaTipoAlta.ValueListItems.Add(2, "Traspasar")
                        listaTipoAlta.ValueListItems.Add(3, "Añadir")

                        Dim rowEstilo As UltraGridRow = Me.grdArticulosDestino.DisplayLayout.Bands(0).AddNew()
                        rowEstilo.Cells("tipoAlta").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
                        rowEstilo.Cells("Sel").Value = False
                        rowEstilo.Cells("articuloCapacidadId").Value = 0
                        rowEstilo.Cells("Descripcion").Value = rowDtArt.Item("Descripcion")
                        rowEstilo.Cells("IdProducto").Value = dtProdCap.Rows(0).Item("proc_prodID")
                        rowEstilo.Cells("IdPstilo").Value = dtProdCap.Rows(0).Item("proc_productoEstiloId")
                        rowEstilo.Cells("codigo").Value = rowDtArt.Item("codigo")
                        rowEstilo.Cells("IdLineaOrigen").Value = IIf(cmbLineasProduccionArticulos.SelectedIndex > 0, cmbLineasProduccionArticulos.SelectedValue.ToString, 0)
                        For i As Int32 = 1 To 52
                            rowEstilo.Cells("sm" + i.ToString).Value = IIf(dtProdCap.Rows(0).Item("proc_" + i.ToString).ToString <> "", dtProdCap.Rows(0).Item("proc_" + i.ToString).ToString, 0)
                        Next
                        rowEstilo.Cells("anio").Value = numAnioProds.Value.ToString
                        rowEstilo.Cells("horma").Value = dtProdCap.Rows(0).Item("proc_hormaid")
                        rowEstilo.Cells("talla").Value = dtProdCap.Rows(0).Item("proc_tallaID")

                        rowEstilo.Cells("tipoAlta").ValueList = listaTipoAlta

                        If rdoDuplicar.Checked = True Then
                            rowEstilo.Cells("tipoAlta").Value = 1
                        ElseIf rdoTraspasar.Checked = True Then
                            rowEstilo.Cells("tipoAlta").Value = 2
                        ElseIf rdoAnadir.Checked = True Then
                            rowEstilo.Cells("tipoAlta").Value = 3
                            rowEstilo.Cells("tipoAlta").Activation = Activation.NoEdit
                        End If

                    End If
                Next
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub llenarComboSimulaciones()
        Dim objBU As New Negocios.SimulacionBU
        Dim dt As New DataTable
        dt = objBU.consultaSimulacionMaestro

        If dt.Rows.Count > 0 Then

            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbSimulaciones.DataSource = dt
            cmbSimulaciones.ValueMember = "ProcSimMae_ProcSimuladorID"
            cmbSimulaciones.DisplayMember = "ProcSimMae_Descripcion"

        End If

    End Sub

    Public Sub llenarComboLineas()
        Dim objBU As New Negocios.LineasProduccionBU
        Dim dt As New DataTable
        dt = objBU.comboLineas(1)

        If dt.Rows.Count > 0 Then

            dt.Rows.InsertAt(dt.NewRow, 0)
            cmbLineaProduccion.DataSource = dt
            cmbLineaProduccion.ValueMember = "ID"
            cmbLineaProduccion.DisplayMember = "Descripcion"

        End If

    End Sub

    Public Sub llenarComboLineasOtras()
        If cmbLineaProduccion.SelectedIndex > 0 Then
            Dim objBU As New Negocios.LineasProduccionBU
            Dim dt As New DataTable
            dt = objBU.consultarLineasDiferenteALaSeleccion(cmbLineaProduccion.SelectedItem("idNave"))

            If dt.Rows.Count > 0 Then

                dt.Rows.InsertAt(dt.NewRow, 0)
                cmbLineasProduccionArticulos.DataSource = dt
                cmbLineasProduccionArticulos.ValueMember = "ID"
                cmbLineasProduccionArticulos.DisplayMember = "Descripcion"
            Else
                cmbLineasProduccionArticulos.DataSource = Nothing
                cmbLineasProduccionArticulos.Items.Clear()
            End If
        Else
            cmbLineasProduccionArticulos.DataSource = Nothing
            cmbLineasProduccionArticulos.Items.Clear()
        End If
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If tbtDatos.SelectedTab.Name = tbtProductos.Name Then
            If ((rdoDuplicar.Checked = True Or rdoTraspasar.Checked = True) And cmbLineasProduccionArticulos.SelectedIndex > 0) Or rdoAnadir.Checked = True Then
                'If cmbLineasProduccionArticulos.SelectedIndex > 0 Then
                Dim objMnsConf As New Tools.ConfirmarForm
                objMnsConf.mensaje = "¿Está seguro de agregar las capacidades?"
                If objMnsConf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    guardarCapacidadesConfiguradas()
                End If
            Else
                Dim objMsjAdv As New Tools.AdvertenciaForm
                objMsjAdv.mensaje = "Es necesario seleccionar una línea de producción."
                objMsjAdv.ShowDialog()
            End If
        Else

        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpDatos.Height = 38
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpDatos.Height = 69
    End Sub

    Private Sub frmMoverHorma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        llenarComboSimulaciones()
        llenarComboLineas()
        inicializaTablaDestino()
        'llenarComboHormas()
    End Sub


    Private Sub rdoCopiarHorma_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub rdoCambiarDeNave_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub rdoAnadir_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnFiltrarHorma_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnFiltroRapidoArticulos_Click(sender As Object, e As EventArgs) Handles btnFiltroRapidoArticulos.Click
        If cmbLineaProduccion.SelectedIndex > 0 And cmbSimulaciones.SelectedIndex > 0 Then
            Dim frmArts As New frmFiltroArticulos
            If (rdoDuplicar.Checked = True Or rdoTraspasar.Checked = True) Then
                If cmbLineasProduccionArticulos.SelectedIndex > 0 Then
                    Dim cadenaPordExcl As String = "0"
                    For Each grdDt As UltraGridRow In grdArticulosDestino.Rows
                        If grdDt.Cells("anio").Value = numAnioProds.Value Then
                            cadenaPordExcl += ", " + grdDt.Cells("IdPstilo").Value.ToString
                        End If
                    Next
                    frmArts.idNave = cmbLineasProduccionArticulos.SelectedItem("idNave")
                    frmArts.idNaveDestino = cmbLineaProduccion.SelectedItem("idNave")
                    frmArts.verTodo = False
                    frmArts.idSimulacion = cmbSimulaciones.SelectedValue
                    frmArts.idLinea = cmbLineaProduccion.SelectedValue
                    frmArts.productosExcluir = cadenaPordExcl
                    frmArts.anioProducto = numAnioProds.Value
                    frmArts.ShowDialog()
                    If Not frmArts.dtArticulos Is Nothing Then
                        llenarDatosTablaOrigen(frmArts.dtArticulos)
                    End If
                Else
                    Dim objMsjAdv As New Tools.AdvertenciaForm
                    objMsjAdv.mensaje = "Debe elegir una línea de producción si se seleccionó duplicar o traspasar artículo."
                    objMsjAdv.ShowDialog()
                End If
            ElseIf rdoAnadir.Checked = True Then
                cmbLineasProduccionArticulos.SelectedIndex = 0
                Dim cadenaPordExcl As String = "0"
                For Each grdDt As UltraGridRow In grdArticulosDestino.Rows
                    cadenaPordExcl += ", " + grdDt.Cells("IdPstilo").Value.ToString
                Next
                frmArts.idNave = 0
                frmArts.idNaveDestino = cmbLineaProduccion.SelectedItem("idNave")
                frmArts.verTodo = True
                frmArts.idSimulacion = cmbSimulaciones.SelectedValue
                frmArts.idLinea = cmbLineaProduccion.SelectedValue
                frmArts.productosExcluir = cadenaPordExcl
                frmArts.anioProducto = numAnioProds.Value
                frmArts.ShowDialog()
                If Not frmArts.dtArticulos Is Nothing Then
                    llenarDatosTablaOrigen(frmArts.dtArticulos)
                End If
            End If
        Else
            Dim objMsjAdv As New Tools.AdvertenciaForm
            objMsjAdv.mensaje = "Seleccione una linea de producción y una simulación."
            objMsjAdv.ShowDialog()
        End If
    End Sub

    Private Sub cmbLineaProduccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLineaProduccion.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        inicializaTablaDestino()
        llenarComboLineasOtras()
        llenarGridHormas()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdArticulosDestino_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdArticulosDestino.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString <> "Sel" Then
                If e.Cell.Column.ToString.Substring(0, 2) = "sm" Or e.Cell.Column.ToString = "tipoAlta" Then
                    If IsNumeric(e.NewValue.ToString) Or (e.NewValue.ToString <> "") Then
                        If e.NewValue >= 0 Then
                            If e.Cell.Row.Cells("articuloCapacidadId").Value.ToString <> "" Then
                                If e.Cell.Row.Cells("articuloCapacidadId").Value > 0 Then
                                    If e.Cell.Column.ToString.Substring(0, 2) = "sm" Then

                                        Dim objMensaje As New Tools.ConfirmarForm
                                        objMensaje.mensaje = "¿Desea actualizar la capacidad del artículo?"
                                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                                            Me.Cursor = Cursors.WaitCursor
                                            Dim semana As Int32 = Replace(e.Cell.Column.ToString, "sm", "")
                                            editarCapacidadArticuloSimulacion(e.Cell.Row.Cells("articuloCapacidadId").Value, semana, semana, e.NewValue)
                                            Me.Cursor = Cursors.Default
                                        Else
                                            e.Cancel = True
                                        End If

                                    ElseIf e.Cell.Column.ToString = "tipoAlta" Then
                                        Dim objMensaje As New Tools.ConfirmarForm
                                        If e.Cell.Value < 3 Then
                                            objMensaje.mensaje = "¿Desea editar el registro?"
                                            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                                                editarTipoAlta(e.Cell.Row.Cells("articuloCapacidadId").Value, e.NewValue, e.Cell.Row.Cells("IdLineaOrigen").Value)
                                            End If
                                        Else
                                            Dim objMAdv As New Tools.AdvertenciaForm
                                            objMAdv.mensaje = "Para realizar duplicidad o el traspaso de capacidad se debe de tener una línea de producción origen; de la opción añadir a las opciones duplicar o traspasar es necesario quitar el registro y darlo nuevamente de alta para cargar la línea de producción origen."
                                            objMAdv.ShowDialog()
                                            e.Cancel = True
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            Dim objMAdv As New Tools.AdvertenciaForm
                            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                            objMAdv.ShowDialog()
                            e.Cancel = True
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                        objMAdv.ShowDialog()
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub grdArticulosDestino_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdArticulosDestino.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If e.Rows.Count = 1 Then
            For Each rowsE As UltraGridRow In e.Rows
                If rowsE.Cells("articuloCapacidadId").Value > 0 And rowsE.Cells("Sel").Value = False Then
                    e.Cancel = True
                End If
            Next
        ElseIf e.Rows.Count > 1 Then



            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "¿Esta seguro de quitar las capacidades?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim objBU As New Negocios.productosCapacidadBU
                Dim cambioAlgo As Boolean = False
                For i As Int32 = e.Rows.Count - 1 To 0 Step -1
                    If e.Rows(i).Cells("Sel").Value = True Then
                        If e.Rows(i).Cells("articuloCapacidadId").Value > 0 And e.Rows(i).Cells("Sel").Value = True Then
                            objBU.inactivarArticuloCapacidadSimulacion(e.Rows(i).Cells("articuloCapacidadId").Value)
                            cambioAlgo = True
                        ElseIf e.Rows(i).Cells("Sel").Value = True Then
                            cambioAlgo = True
                        End If
                    End If
                Next

                If cambioAlgo = True Then
                    Dim objMsjExito As New Tools.ExitoForm
                    objMsjExito.mensaje = "Registro exitoso"
                    objMsjExito.ShowDialog()
                Else
                    e.Cancel = True
                    Dim objMsjExito As New Tools.AdvertenciaForm
                    objMsjExito.mensaje = "No se realizó ningún cambio"
                    objMsjExito.ShowDialog()
                End If
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub grdArticulosDestino_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdArticulosDestino.ClickCell
        lblSeleccionado.Text = ""
        If cmbSimulaciones.SelectedIndex > 0 Then
            If e.Cell.Row.IsFilterRow = False Then
                Dim objBU As New Negocios.productosCapacidadBU
                Dim dt As New DataTable
                lblSeleccionado.Text = "(" + e.Cell.Row.Cells("codigo").Value.ToString + ")  - " + e.Cell.Row.Cells("Descripcion").Value.ToString
                dt = objBU.consultaOrdenProductoNaveSimulacion(cmbSimulaciones.SelectedValue, e.Cell.Row.Cells("IdPstilo").Value, True, 0)
                If dt.Rows.Count > 0 Then
                    If e.Cell.Row.Cells("articuloCapacidadId").Value <= 0 Then
                        Dim filaDT As DataRow
                        filaDT = dt.NewRow
                        filaDT.Item("ordenArtNaveSimId") = 0
                        filaDT.Item("simulacionId") = 0
                        filaDT.Item("productoEstiloId") = e.Cell.Row.Cells("IdPstilo").Value
                        filaDT.Item("naveId") = cmbLineaProduccion.SelectedItem("idNave")
                        filaDT.Item("nave") = cmbLineaProduccion.Text
                        filaDT.Item("orden") = dt.Rows.Count + 1
                        dt.Rows.Add(filaDT)
                    End If
                Else
                    If e.Cell.Row.Cells("articuloCapacidadId").Value > 0 Then
                        btnGuardarOrdenamiento.Enabled = True
                        lblGuardarOrden.Enabled = True
                        dt = objBU.consultaOrdenProductoNaveSimulacion(cmbSimulaciones.SelectedValue, e.Cell.Row.Cells("IdPstilo").Value, True, 0)
                    Else
                        btnGuardarOrdenamiento.Enabled = False
                        lblGuardarOrden.Enabled = False
                        dt = objBU.consultaOrdenProductoNaveSimulacion(cmbSimulaciones.SelectedValue, e.Cell.Row.Cells("IdPstilo").Value, False, cmbLineaProduccion.SelectedItem("idNave"))
                        Dim existeNave As Boolean = False
                        For Each rdt As DataRow In dt.Rows
                            If rdt.Item("naveId").ToString = cmbLineaProduccion.SelectedItem("idNave") Then
                                existeNave = True
                            End If
                        Next
                        If existeNave = False Then
                            Dim filaDT As DataRow
                            filaDT = dt.NewRow
                            filaDT.Item("ordenArtNaveSimId") = 0
                            filaDT.Item("simulacionId") = 0
                            filaDT.Item("productoEstiloId") = e.Cell.Row.Cells("IdPstilo").Value
                            filaDT.Item("naveId") = cmbLineaProduccion.SelectedItem("idNave")
                            filaDT.Item("nave") = cmbLineaProduccion.Text
                            filaDT.Item("orden") = dt.Rows.Count + 1
                            dt.Rows.Add(filaDT)
                        End If
                    End If
                End If
                If dt.Rows.Count > 0 Then
                    grdOrdenNaves.DataSource = dt
                    With grdOrdenNaves.DisplayLayout.Bands(0)
                        .Columns("ordenArtNaveSimId").Hidden = True
                        .Columns("simulacionId").Hidden = True
                        .Columns("productoEstiloId").Hidden = True
                        .Columns("naveId").Hidden = True
                        .Columns("nave").Header.Caption = "Nave"
                        .Columns("orden").Header.Caption = "Orden"
                        .Columns("nave").CellActivation = Activation.NoEdit
                        .Columns("orden").CellActivation = Activation.NoEdit
                    End With

                    grdOrdenNaves.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
                    grdOrdenNaves.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
                    grdOrdenNaves.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
                    grdOrdenNaves.DisplayLayout.Override.RowSelectorWidth = 35
                    grdOrdenNaves.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    grdOrdenNaves.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True

                    grdOrdenNaves.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
                    grdOrdenNaves.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
                    grdOrdenNaves.AllowDrop = True
                Else
                    grdOrdenNaves.DataSource = Nothing
                End If
            Else
                grdOrdenNaves.DataSource = Nothing
            End If
        Else
            grdOrdenNaves.DataSource = Nothing
        End If
    End Sub

    Private Sub grdArticulosDestino_Error(sender As Object, e As ErrorEventArgs) Handles grdArticulosDestino.Error
        If e.ErrorText = "Unable to update the data value: Value could not be converted to System.Int32." Then
            e.Cancel = True
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0. Presione ""Escape"" para salir"
            objMAdv.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdArticulosDestino_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdArticulosDestino.InitializeLayout

    End Sub

    Private Sub grdArticulosOrigen_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)

    End Sub

    Private Sub grdOrdenNaves_DragDrop(sender As Object, e As DragEventArgs) Handles grdOrdenNaves.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdOrdenNaves.DisplayLayout.UIElement.ElementFromPoint(grdOrdenNaves.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdOrdenNaves.Rows.Move(aRow, dropIndex)
            Next

            Dim nOrden As Int32 = 1
            For Each fila As UltraGridRow In grdOrdenNaves.Rows
                fila.Cells("orden").Value = nOrden
                nOrden += 1
            Next
        End If
    End Sub

    Private Sub grdOrdenNaves_DragOver(sender As Object, e As DragEventArgs) Handles grdOrdenNaves.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdOrdenNaves.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdOrdenNaves.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdOrdenNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOrdenNaves.InitializeLayout

    End Sub

    Private Sub rdoDuplicar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDuplicar.CheckedChanged

    End Sub

    Private Sub rdoTraspasar_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTraspasar.CheckedChanged

    End Sub

    Private Sub rdoAnadir_CheckedChanged_1(sender As Object, e As EventArgs) Handles rdoAnadir.CheckedChanged

    End Sub

    Private Sub btnCambiarCapacidadCeldas_Click(sender As Object, e As EventArgs) Handles btnCambiarCapacidadCeldas.Click
        cambiarapacidadSeleccionados()
    End Sub

    Private Sub btnCantidadHorma_Click(sender As Object, e As EventArgs) Handles btnCantidadHorma.Click
        Dim objMensaje As New Tools.ConfirmarForm
        Dim guardo As Boolean = False
        objMensaje.mensaje = "¿Desea actualizar la capacidad de la hormas seleccionadas?"
        If objMensaje.ShowDialog() = Windows.Forms.DialogResult.OK Then
            For Each rowGRD In grdHormasCapacidadSimulacion.Rows
                If rowGRD.Cells("Sel").Value = True Then
                    editarHoramaCapacidadSimulacion(rowGRD.Cells("smhc_simulacionHormasCapacidadId").Value,
                                                               numSemHormsInicio.Value, numSemHormsFin.Value, numCantidadHorms.Value)
                    guardo = True
                End If
            Next
            llenarGridHormas()
            If guardo = True Then
                Dim objMsjExito As New Tools.ExitoForm
                objMsjExito.mensaje = "Registro exitoso"
                objMsjExito.ShowDialog()
            Else
                Dim objMsjEAdv As New Tools.ExitoForm
                objMsjEAdv.mensaje = "No se realizó ningún cambio"
                objMsjEAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub cmbSimulaciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSimulaciones.SelectedIndexChanged
        inhabilitarBotones()
        inicializaTablaDestino()
        llenarGridHormas()
    End Sub

    Private Sub cmbLineasProduccionArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLineasProduccionArticulos.SelectedIndexChanged
        inicializaTablaDestino()
    End Sub

    Private Sub btnGuardarOrdenamiento_Click(sender As Object, e As EventArgs) Handles btnGuardarOrdenamiento.Click
        Dim objMsjConf As New Tools.ConfirmarForm
        objMsjConf.mensaje = "¿Está seguro de modificar el ordenamiento?"
        If objMsjConf.ShowDialog = Windows.Forms.DialogResult.OK Then
            modificarOrdenNAvesArticulo()
        End If
    End Sub

    Private Sub grdOrdenNaves_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdOrdenNaves.SelectionDrag
        grdOrdenNaves.DoDragDrop(grdOrdenNaves.Selected.Rows, DragDropEffects.Move)
    End Sub

    Private Sub grdHormasCapacidadSimulacion_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdHormasCapacidadSimulacion.BeforeCellUpdate
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.ToString <> "Sel" Then
                If IsNumeric(e.NewValue.ToString) Or (e.NewValue.ToString <> "") Then
                    If e.NewValue >= 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "¿Desea actualizar la capacidad de la horma?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Cursor = Cursors.WaitCursor
                            Dim semana As Int32 = Replace(e.Cell.Column.ToString, "smhc_", "")
                            editarHoramaCapacidadSimulacion(e.Cell.Row.Cells("smhc_simulacionHormasCapacidadId").Value, semana, semana, e.NewValue)
                            Me.Cursor = Cursors.Default
                        Else
                            e.Cancel = True
                        End If
                    Else
                        Dim objMAdv As New Tools.AdvertenciaForm
                        objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                        objMAdv.ShowDialog()
                        e.Cancel = True
                    End If
                Else
                    Dim objMAdv As New Tools.AdvertenciaForm
                    objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0."
                    objMAdv.ShowDialog()
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub grdHormasCapacidadSimulacion_Error(sender As Object, e As ErrorEventArgs) Handles grdHormasCapacidadSimulacion.Error
        If e.ErrorText = "Unable to update the data value: Value could not be converted to System.Int32." Then
            e.Cancel = True
            Dim objMAdv As New Tools.AdvertenciaForm
            objMAdv.mensaje = "La capacidad debe ser capturada con valores numéricos mayores o iguales a 0. Presione ""Escape"" para salir"
            objMAdv.ShowDialog()
            e.Cancel = True
        End If
    End Sub

    Private Sub grdHormasCapacidadSimulacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdHormasCapacidadSimulacion.InitializeLayout

    End Sub

    Private Sub grdHormasCapacidadSimulacion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdHormasCapacidadSimulacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            grdHormasCapacidadSimulacion.PerformAction(UltraGridAction.ExitEditMode, False, False)
            Dim banda As UltraGridBand = grdHormasCapacidadSimulacion.DisplayLayout.Bands(0)
            If grdHormasCapacidadSimulacion.ActiveRow.HasNextSibling(True) Then
                Dim nextRow As UltraGridRow = grdHormasCapacidadSimulacion.ActiveRow.GetSibling(SiblingRow.Next, True)
                grdHormasCapacidadSimulacion.ActiveCell = nextRow.Cells(grdHormasCapacidadSimulacion.ActiveCell.Column)
                e.Handled = True
                grdHormasCapacidadSimulacion.PerformAction(UltraGridAction.EnterEditMode, False, False)
            End If
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If tbtDatos.SelectedTab.Name = tbtProductos.Name Then
            eliminarCapacidadArticulos()
        Else
            Dim objMensajeAdv As New Tools.AdvertenciaForm
            objMensajeAdv.mensaje = "Para eliminar capacidades de artículos debe estar en la pestaña de productos."
            objMensajeAdv.ShowDialog()
        End If
    End Sub

    Private Sub grdArticulosDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles grdArticulosDestino.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not grdArticulosDestino.ActiveCell Is Nothing Then
                grdArticulosDestino.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdArticulosDestino.DisplayLayout.Bands(0)
                If grdArticulosDestino.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdArticulosDestino.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdArticulosDestino.ActiveCell = nextRow.Cells(grdArticulosDestino.ActiveCell.Column)
                    e.Handled = True
                    grdArticulosDestino.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        End If
    End Sub

    Private Sub chkTodosProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosProductos.CheckedChanged
        For Each rowGrd As UltraGridRow In grdArticulosDestino.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Sel").Value = chkTodosProductos.Checked
        Next
    End Sub

    Private Sub chkTodosHormas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosHormas.CheckedChanged
        For Each rowGrd As UltraGridRow In grdHormasCapacidadSimulacion.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Sel").Value = chkTodosHormas.Checked
        Next
    End Sub
End Class