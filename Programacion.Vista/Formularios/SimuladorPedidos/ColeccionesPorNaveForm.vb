Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ColeccionesPorNaveForm
    Dim tab As Integer = 0
    Dim tab2secundario As Integer = 0
    Dim bandera As Boolean = False
    Dim vHormasCapacidadesBU As HormasCapacidadesBU
    Dim valorActualOrden As Integer = 1
    Dim tipoTablaFormato As Integer = 1
    Dim tablaProce As Integer
    Dim ordenAnterior As Integer
    Dim MensajeGrande As Boolean
    Dim idHorma As Integer
    Dim idTalla As Integer

    Public Property vTablaProce
        Get
            Return tablaProce
        End Get
        Set(value)
            tablaProce = value
        End Set
    End Property
    Public Property vTipoTablaFormato
        Get
            Return tipoTablaFormato
        End Get
        Set(value)
            tipoTablaFormato = value
        End Set
    End Property

    Private Sub ColeccionesPorNaveForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Top = 0
        Me.Left = 0
        llenarComboNaves()
        bandera = True
        tab = tabPrincipal.ActiveTab.Index
        mostrarDatosPrincipales(tab)
    End Sub

    Public Sub llenarTablaCapacidades(ByVal idHormaSel As Int32, ByVal idTallaSel As Int32)
        grdCapacidadesCelulas.DataSource = Nothing
        Dim objBU As New Negocios.LineasProduccionBU
        Dim dt As New DataTable
        Dim idNaveSel As Int32 = 0
        idNaveSel = cmbNaves.SelectedValue
        dt = objBU.consultaCapacidadesCelulasHorma(idNaveSel, idHormaSel, idTallaSel)
        If dt.Rows.Count > 0 Then
            grdCapacidadesCelulas.DataSource = dt
            disenioGridCapacidades()
        End If
    End Sub

    Public Sub disenioGridCapacidades()
        If grdCapacidadesCelulas.Rows.Count > 0 Then
            Dim band As UltraGridBand = Me.grdCapacidadesCelulas.DisplayLayout.Bands(0)
            band.SummaryFooterCaption = "Total"
            With grdCapacidadesCelulas.DisplayLayout.Bands(0)
                .Columns("linp_linpID").Hidden = True
                .Columns("nave_naveid").Hidden = True
                .Columns("linp_capacidad_diaria").Hidden = True
                .Columns("nave_nombre").Hidden = True
                .Columns("linp_nombre").Header.Caption = "Célula"
                .Columns("nave_nombre").Header.Caption = "Nave"
                .Columns("horc_año").Header.Caption = "Año"
                .Columns("horc_semanaelimina").Header.Caption = "Semana Elimina"
                .Columns("horc_activo").Header.Caption = "Activo"
                .Columns("linp_nombre").CellActivation = Activation.NoEdit
                .Columns("nave_nombre").CellActivation = Activation.NoEdit
                .Columns("horc_año").CellActivation = Activation.NoEdit
                .Columns("horc_semanaelimina").CellActivation = Activation.NoEdit
                .Columns("horc_activo").CellActivation = Activation.NoEdit
                '.Columns("Capacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Capacidad").Format = "###,###,##0"
                .Columns("horc_año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("horc_semanaelimina").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            grdCapacidadesCelulas.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdCapacidadesCelulas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdCapacidadesCelulas.DisplayLayout.Override.RowSelectorWidth = 35
            grdCapacidadesCelulas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdCapacidadesCelulas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End If
    End Sub

    Public Sub disenioGridProductosCapCelulas()
        Dim band As UltraGridBand = Me.grdProductosCelulas.DisplayLayout.Bands(0)
        band.SummaryFooterCaption = "Total"
        With grdProductosCelulas.DisplayLayout.Bands(0)
            .Columns("linp_linpID").Hidden = True
            .Columns("nave_naveid").Hidden = True
            .Columns("linp_capacidad_diaria").Hidden = True
            .Columns("nave_nombre").Hidden = True
            .Columns("linp_nombre").Header.Caption = "Célula"
            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("proc_año").Header.Caption = "Año"
            .Columns("proc_semanaelimina").Header.Caption = "Semana Elimina"
            .Columns("proc_activo").Header.Caption = "Activo"
            .Columns("linp_nombre").CellActivation = Activation.NoEdit
            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("proc_año").CellActivation = Activation.NoEdit
            .Columns("proc_semanaelimina").CellActivation = Activation.NoEdit
            .Columns("proc_activo").CellActivation = Activation.NoEdit
            '.Columns("Capacidad").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            '.Columns("Capacidad").Format = "###,###,##0"
            .Columns("proc_semanaelimina").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("proc_año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdProductosCelulas.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdProductosCelulas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosCelulas.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosCelulas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductosCelulas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdProductosCelulas.DisplayLayout.Bands(0).Columns("proc_semanaelimina").Width = 35
        grdProductosCelulas.DisplayLayout.Bands(0).Columns("linp_nombre").Width = 100
        grdProductosCelulas.DisplayLayout.Bands(0).Columns("proc_año").Width = 75
        grdProductosCelulas.DisplayLayout.Bands(0).Columns("proc_semanaelimina").Width = 50

    End Sub

#Region "Datos Iniciales"
    Public Sub llenarComboNaves()
        Try
            Me.Cursor = Cursors.WaitCursor
            vHormasCapacidadesBU = New HormasCapacidadesBU
            Dim obj As New Framework.Negocios.NavesBU
            With cmbNaves
                .DataSource = vHormasCapacidadesBU.listaNaves
                .DisplayMember = "nave_nombre"
                .ValueMember = "id_"
            End With
            inicializarComboHormas(vHormasCapacidadesBU)
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub mostrarDatosPrincipales(ByVal tab As Integer)
        Try
            Me.Cursor = Cursors.WaitCursor
            Select Case tab
                Case 0
                    mostrarDatosHormas()
                    Dim objBU As New Negocios.LineasProduccionBU
                    objBU.inactivarHormasSemanaActual()
                    objBU.inactivarProductosSemanaActual()
                Case 1
                    chkCapacidad.Checked = False
                    txtCapacidadProducto.Value = "0"
                    chkOrden.Checked = False
                    mostrarDatosProductos()
                    Dim objBU As New Negocios.LineasProduccionBU
                    objBU.inactivarHormasSemanaActual()
                    objBU.inactivarProductosSemanaActual()
                Case 2
                    tab2secundario = tabSecundario.ActiveTab.Index
                    If tab2secundario = 0 Then
                        mostraAsignados()
                    ElseIf tab2secundario = 1 Then
                        mostrarNoAsignados()
                    Else
                        mensajeAdvertencia("Hormas y Productos por nave", "Pestaña no asignada")
                    End If
                Case Else
                    mensajeAdvertencia("Hormas y Productos por nave", "Pestaña no asignada")
            End Select
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub ExportarExcelDatos()

        Try
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xls"
            sfd.Filter = "*.xls|*.xls"
            If sfd.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If sfd.FileName.Trim = "" Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim nombre As String = sfd.FileName
            tab = tabPrincipal.ActiveTab.Index
            Dim grdDatos As UltraGrid = obtenerTablaExportar(tab)
            Me.UltraGridExcelExporter1.Export(grdDatos, nombre)
            System.Diagnostics.Process.Start(nombre)

            mensajeExito("Hormas y Productos por nave", "Informacion exportada con éxito")
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function obtenerTablaExportar(ByVal tab As Integer) As UltraGrid
        Dim grdDatos As UltraGrid
        Select Case tab
            Case 0
                grdDatos = grdDatosHormas
            Case 1
                grdDatos = grdDatosProducto
            Case 2
                tab2secundario = tabSecundario.ActiveTab.Index
                If tab2secundario = 0 Then
                    grdDatos = grdProductosTodoAsignado
                ElseIf tab2secundario = 1 Then
                    grdDatos = grdProductoNoAsignado
                Else
                    grdDatos = grdProductosTodoAsignado
                End If
            Case Else
                grdDatos = grdDatosHormas
        End Select
        Return grdDatos
    End Function
#End Region

#Region "Hormas"
#Region "datos"
    Public Sub mostrarDatosHormas()
        chkHormasTodo.Checked = False
        chkTodoHormaDatos.Checked = False
        vHormasCapacidadesBU = New HormasCapacidadesBU
        grdHormasDisponibles.DataSource = Nothing
        grdHormasDisponibles.DataSource = vHormasCapacidadesBU.TablaHormasDisponibles(cmbNaves.SelectedValue)
        formatoTablaHorma()
        mostrarDatosHormasAsignadas()
    End Sub
    Public Sub mostrarDatosHormasAsignadas()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        grdDatosHormas.DataSource = Nothing
        grdDatosHormas.DataSource = vHormasCapacidadesBU.TablaHormasAsignadas(cmbNaves.SelectedValue)
        formatoTablaHormaAsignada()
    End Sub
    Public Sub mostrarDatosNavesHormaAsignada()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        grdNavesHormas.DataSource = Nothing
        'Comentado Adriana         'grdNavesHormas.DataSource = vHormasCapacidadesBU.TablaHormasTodas(grdDatosHormas.ActiveRow.Cells("hona_hormaID").Value, grdDatosHormas.ActiveRow.Cells("hona_tallaid").Value)
        grdNavesHormas.DataSource = vHormasCapacidadesBU.TablaHormasTodas(idHorma, idTalla)
        formatoTablaHormaNave()
    End Sub
#End Region
#Region "Operaciones"
    Public Sub agregarHormaANave()
        Dim totalSeleccionados As Boolean = False
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdHormasDisponibles.Rows
                If rowGrd.Cells("Seleccion").Value Then
                    totalSeleccionados = True
                    Exit For
                End If
            Next
            If totalSeleccionados Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea agregar las hormas seleccionadas a la nave ?") = Windows.Forms.DialogResult.OK Then
                    For Each rowGrd As UltraGridRow In grdHormasDisponibles.Rows
                        If rowGrd.Cells("Seleccion").Value Then
                            vHormasCapacidadesBU.AsigarHorma(cmbNaves.SelectedValue, rowGrd.Cells("horma_hormaid").Value, rowGrd.Cells("talla_tallaid").Value, 0)
                        End If
                    Next
                    mostrarDatosHormas()
                    mensajeExito("Hormas y Productos por nave", "Hormas asignadas con éxito")
                    chkHormasTodo.Checked = False
                    chkTodoHormaDatos.Checked = False
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar al menos una horma")
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub cambiarCapacidad()
        Dim totalSeleccionados As Boolean = False
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
                If rowGrd.Cells("Seleccion").Value Then
                    totalSeleccionados = True
                    Exit For
                End If
            Next
            If totalSeleccionados Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea asignar la capacidad capturada a las hormas asignadas seleccionadas ?") = Windows.Forms.DialogResult.OK Then
                    For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
                        If rowGrd.Cells("Seleccion").Value Then
                            vHormasCapacidadesBU.actualizarCapacidasHormaAsignada(rowGrd.Cells("hona_hormaPorNaveID").Value, txtCapacidadHorma.Value)
                        End If
                    Next
                    mostrarDatosHormasAsignadas()
                    mensajeExito("Hormas y Productos por nave", "Capacidad actualizada con éxito")
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar las hormas disponibles a las que desea asignar la capacidad")
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub actualizarHorma()
        Me.Cursor = Cursors.WaitCursor
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea actualizar la capacidad de la horma ?") = Windows.Forms.DialogResult.OK Then
                vHormasCapacidadesBU.actualizarCapacidasHormaAsignada(grdDatosHormas.ActiveRow.Cells("hona_hormaPorNaveID").Value, grdDatosHormas.ActiveRow.Cells("hona_capacidad").Value)
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub quitarHormaANave()
        Dim totalSeleccionados As Boolean = False
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Dim banderaExistencia As Boolean = False
        Dim mensaje As String = ""
        MensajeGrande = False

        Try
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
                If rowGrd.Cells("Seleccion").Value Then
                    totalSeleccionados = True
                    Exit For
                End If
            Next
            If totalSeleccionados Then
                '''''''''''''''''''''''''''''''''''''''''
                'Validacio de si tiene productos la horma
                '''''''''''''''''''''''''''''''''''''''''
                mensaje = "Las siguientes hormas tienen productos asignados a la nave: " & vbCrLf
                For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
                    If rowGrd.Cells("Seleccion").Value Then
                        If vHormasCapacidadesBU.verificarHormaNave2(rowGrd.Cells("hona_hormaID").Value, cmbNaves.SelectedValue, rowGrd.Cells("hona_tallaid").Value) Then
                            banderaExistencia = True
                            ' horma_descripcion talla_descripcion
                            mensaje += "," + rowGrd.Cells("horma_descripcion").Value.ToString + " (" + rowGrd.Cells("talla_descripcion").Value.ToString + ") "
                        End If
                    End If
                Next
                mensaje += "" & vbCrLf
                mensaje += "El resto de las hormas seleccionadas no tiene productos asignados en la nave" & vbCrLf
                mensaje += "Nota: Al seleccionar NO, tampoco se eliminarán las hormas sin productos."
                MensajeGrande = True
                If Not banderaExistencia Then
                    mensaje = "¿Desea eliminar las hormas seleccionadas de la nave (ninguna tiene productos asignados)?"
                    MensajeGrande = False
                End If
                If MensajeGrande = True Then
                    If (mensajeConfirmarGrande("Hormas y Productos por nave", mensaje) = Windows.Forms.DialogResult.OK) Then
                        For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
                            If rowGrd.Cells("Seleccion").Value Then
                                vHormasCapacidadesBU.DesasignarColeccion(rowGrd.Cells("hona_hormaPorNaveID").Value, banderaExistencia, cmbNaves.SelectedValue, rowGrd.Cells("hona_tallaid").Value, rowGrd.Cells("hona_hormaID").Value)
                            End If
                        Next
                        mostrarDatosHormas()
                        mensajeExito("Hormas y Productos por nave", "Hormas eliminadas con éxito")
                        chkHormasTodo.Checked = False
                        chkTodoHormaDatos.Checked = False
                    End If
                End If

                If MensajeGrande = False Then
                    If mensajeConfirmar("Hormas y Productos por nave", mensaje) = Windows.Forms.DialogResult.OK Then
                        For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
                            If rowGrd.Cells("Seleccion").Value Then
                                vHormasCapacidadesBU.DesasignarColeccion(rowGrd.Cells("hona_hormaPorNaveID").Value, banderaExistencia, cmbNaves.SelectedValue, rowGrd.Cells("hona_tallaid").Value, rowGrd.Cells("hona_hormaID").Value)
                            End If
                        Next
                        mostrarDatosHormas()
                        mensajeExito("Hormas y Productos por nave", "Hormas eliminadas con éxito")
                        chkHormasTodo.Checked = False
                        chkTodoHormaDatos.Checked = False
                    End If
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar al menos una horma")
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region
#Region "diseño"
    Public Sub formatoTablaHormaAsignada()
        grdDatosHormas.DisplayLayout.Bands(0).Columns.Add("Seleccion", "")
        grdDatosHormas.DisplayLayout.Bands(0).Columns("Seleccion").Header.VisiblePosition = 0
        Dim band As UltraGridBand = Me.grdDatosHormas.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Activation.AllowEdit
            .Columns("hona_hormaPorNaveID").CellActivation = Activation.NoEdit
            .Columns("horma_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("hona_tallaid").CellActivation = Activation.NoEdit
            .Columns("hona_capacidad").CellActivation = Activation.AllowEdit
            .Columns("Celulas").CellActivation = Activation.NoEdit
            .Columns("ProductoAsignados").CellActivation = Activation.NoEdit
            .Columns("ProductosCapacidad").CellActivation = Activation.NoEdit
            .Columns("Elimina").CellActivation = Activation.NoEdit
            .Columns("semanaElimina").CellActivation = Activation.NoEdit
            .Columns("Elimina").CellAppearance.FontData.Bold = DefaultableBoolean.True
            .Columns("hona_capacidad").Style = ColumnStyle.IntegerNonNegative
            .Columns("hona_hormaPorNaveID").Hidden = True '
            .Columns("hona_tallaid").Hidden = True
            .Columns("hona_hormaID").Hidden = True
            .Columns("horma_descripcion").Header.Caption = "Horma"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("hona_capacidad").Header.Caption = "* Capacidad"
            .Columns("Celulas").Header.Caption = "Células"
            .Columns("ProductoAsignados").Header.Caption = "PrAsign"
            .Columns("ProductosCapacidad").Header.Caption = "Prc/Cap"
            .Columns("Elimina").Header.Caption = "¿Eliminar?"
            .Columns("hona_capacidad").Format = "##,##0"
            .Columns("semanaElimina").Header.Caption = "Semana"
            .Columns("Celulas").CellAppearance.TextHAlign = HAlign.Right
            .Columns("hona_capacidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ProductoAsignados").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ProductosCapacidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("semanaElimina").CellAppearance.TextHAlign = HAlign.Right
            .Columns("seleccion").Style = ColumnStyle.CheckBox
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdDatosHormas.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatosHormas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosHormas.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatosHormas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        ' grdHormasDisponibles.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdDatosHormas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        band.Columns("horma_descripcion").Width = 380
        band.Columns("talla_descripcion").Width = 80
        band.Columns("Seleccion").Width = 30
        band.Columns("Celulas").Width = 60
        band.Columns("hona_capacidad").Width = 100
        band.Columns("ProductoAsignados").Width = 60
        band.Columns("ProductosCapacidad").Width = 70
        band.Columns("Elimina").Width = 60
        For Each rowGrd As UltraGridRow In grdDatosHormas.Rows
            rowGrd.Cells("Seleccion").Value = False
            If rowGrd.Cells("ProductosCapacidad").Value = 0 And rowGrd.Cells("Celulas").Value = 0 Then
                rowGrd.Cells("Elimina").Value = "SI"
                rowGrd.Cells("Elimina").Appearance.ForeColor = Color.ForestGreen
            Else
                rowGrd.Cells("Elimina").Appearance.ForeColor = Color.Red
                rowGrd.Cells("Seleccion").Activation = Activation.NoEdit
            End If
        Next
    End Sub
    Public Sub formatoTablaHorma()
        grdHormasDisponibles.DisplayLayout.Bands(0).Columns.Add("Seleccion", "")
        grdHormasDisponibles.DisplayLayout.Bands(0).Columns("Seleccion").Header.VisiblePosition = 0
        Dim band As UltraGridBand = Me.grdHormasDisponibles.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Activation.AllowEdit
            .Columns("horma_hormaid").CellActivation = Activation.NoEdit
            .Columns("horma_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_tallaid").CellActivation = Activation.NoEdit
            .Columns("horma_hormaid").Hidden = True
            .Columns("talla_tallaid").Hidden = True
            .Columns("horma_descripcion").Header.Caption = "Horma"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("seleccion").Style = ColumnStyle.CheckBox
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdHormasDisponibles.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdHormasDisponibles.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdHormasDisponibles.DisplayLayout.Override.RowSelectorWidth = 35
        grdHormasDisponibles.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdHormasDisponibles.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        band.Columns("talla_descripcion").Width = 70
        band.Columns("Seleccion").Width = 25
        For Each rowGrd As UltraGridRow In grdHormasDisponibles.Rows
            rowGrd.Cells("Seleccion").Value = False
        Next
    End Sub
    Public Sub formatoTablaHormaNave()
        Dim band As UltraGridBand = Me.grdNavesHormas.DisplayLayout.Bands(0)
        With band
            .Columns("Nave").CellActivation = Activation.NoEdit
            .Columns("nave_orden").Hidden = True
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdNavesHormas.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdNavesHormas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNavesHormas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNavesHormas.DisplayLayout.Override.RowSelectorWidth = 35
        grdNavesHormas.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdNavesHormas.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub
#End Region

#End Region

#Region "Productos"
#Region "Datos"
    Public Sub mostrarDatosProductos()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        chkProductoTodo.Checked = False
        chkProductoTodoDatos.Checked = False
        inicializarComboHormas(vHormasCapacidadesBU)
        mostrarTablaProductoDisponible()
        mostrarTablaProductoAsignado()
        txtCapacidadProducto.Value = 0
        cmbOrdenProducto.SelectedItem = 1
        inicializarComboTallas()
    End Sub
    Public Sub mostrarTablaProductoDisponible()
        grdProductoDisponible.DataSource = Nothing
        grdProductoDisponible.DataSource = vHormasCapacidadesBU.TablaProductosDisponibles(CInt(cmbProductos.SelectedValue.ToString), cmbNaves.SelectedValue, cmbCorridas.SelectedValue)
        formatoTablaProductosDisPonibles()
    End Sub
    Public Sub mostrarTablaProductoAsignado()
        grdDatosProducto.DataSource = Nothing
        Dim idTallaSel As Int32 = 0
        If cmbCorridas.SelectedIndex > 0 Then
            idTallaSel = cmbCorridas.SelectedValue
        End If
        grdDatosProducto.DataSource = vHormasCapacidadesBU.TablaProductoAsignado(cmbNaves.SelectedValue, cmbProductos.SelectedValue, idTallaSel)
        formatoTablaProductosAsignados()
    End Sub
    Public Sub inicializarComboHormas(ByVal hormasCapacidadesBU As HormasCapacidadesBU)
        Dim tablaDatos As DataTable = Nothing
        tablaDatos = hormasCapacidadesBU.obtnerHormasNave(cmbNaves.SelectedValue)
        Dim R As DataRow = tablaDatos.NewRow
        R(0) = 0
        R(1) = ""
        RemoveHandler Me.cmbProductos.SelectedIndexChanged, AddressOf cmbProductos_SelectedIndexChanged
        tablaDatos.Rows.InsertAt(R, 0)
        'cmbProductos.DataSource = Nothing
        With cmbProductos
            .DataSource = tablaDatos
            .ValueMember = "horma_hormaid"
            .DisplayMember = "horma_descripcion"
        End With
        With cmbOrdenProducto
            .DataSource = hormasCapacidadesBU.obtenerOrdenNaves
            .ValueMember = "nave_orden"
            .DisplayMember = "nave_orden"
        End With
        AddHandler Me.cmbProductos.SelectedIndexChanged, AddressOf cmbProductos_SelectedIndexChanged
    End Sub
    Public Sub inicializarComboTallas()
        cmbCorridas.DataSource = Nothing
        Dim tablaDatos As DataTable
        vHormasCapacidadesBU = New HormasCapacidadesBU
        RemoveHandler Me.cmbCorridas.SelectedIndexChanged, AddressOf cmbCorridas_SelectedIndexChanged
        tablaDatos = vHormasCapacidadesBU.obtnerTallasHormas(cmbProductos.SelectedValue, cmbNaves.SelectedValue)
        Dim R As DataRow = tablaDatos.NewRow
        R(0) = 0
        R(1) = ""
        tablaDatos.Rows.InsertAt(R, 0)
        With cmbCorridas
            .DataSource = tablaDatos
            .ValueMember = "talla_tallaid"
            .DisplayMember = "talla_descripcion"
        End With
        AddHandler Me.cmbCorridas.SelectedIndexChanged, AddressOf cmbCorridas_SelectedIndexChanged

    End Sub
    Public Sub mostrardatosnaveorden(ByVal tipo)
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Dim objProdsCap As New Negocios.productosCapacidadBU
        vTablaProce = tipo
        grdNavesProducto.DataSource = Nothing
        If tipo = 1 Then
            Dim dtNP As New DataTable
            grdNavesProducto.DataSource = Nothing
            dtNP = vHormasCapacidadesBU.TablaProductoTodo(grdProductoDisponible.ActiveRow.Cells("v_prodID").Value, grdProductoDisponible.ActiveRow.Cells("v_productoEstiloID").Value, grdProductoDisponible.ActiveRow.Cells("v_tallaID").Value)
            If dtNP.Rows.Count > 0 Then
                grdNavesProducto.DataSource = dtNP
                formatoTablaNaveOrden()
            End If
            grdProductosCelulas.DataSource = Nothing
        Else
            Dim dtNP As New DataTable
            Dim dtHCP As New DataTable
            grdNavesProducto.DataSource = Nothing
            grdProductosCelulas.DataSource = Nothing
            dtNP = vHormasCapacidadesBU.TablaProductoTodo(grdDatosProducto.ActiveRow.Cells("v_prodID").Value, grdDatosProducto.ActiveRow.Cells("v_productoEstiloID").Value, grdDatosProducto.ActiveRow.Cells("v_tallaID").Value)
            dtHCP = objProdsCap.consultaProductosCelula(cmbNaves.SelectedValue, grdDatosProducto.ActiveRow.Cells("v_productoEstiloID").Value)

            If dtNP.Rows.Count > 0 Then
                grdNavesProducto.DataSource = dtNP
                formatoTablaNaveOrden()
            End If
            If dtHCP.Rows.Count > 0 Then
                grdProductosCelulas.DataSource = dtHCP
                disenioGridProductosCapCelulas()
            End If
        End If
        'mostrarTablaProductoAsignado()

    End Sub
#End Region
#Region "operaciones"
    Public Sub agregarProductoANave()
        Dim totalSeleccionados As Boolean = False
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Me.Cursor = Cursors.WaitCursor
        Try

            For Each rowGrd As UltraGridRow In grdProductoDisponible.Rows
                If rowGrd.Cells("Seleccion").Value Then
                    totalSeleccionados = True
                    Exit For
                End If
            Next
            If totalSeleccionados Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea agregar los productos seleccionados a la nave ?") = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    For Each rowGrd As UltraGridRow In grdProductoDisponible.Rows
                        If rowGrd.Cells("Seleccion").Value Then
                            vHormasCapacidadesBU.AsignarProducto(cmbNaves.SelectedValue, rowGrd.Cells("v_prodID").Value, rowGrd.Cells("v_productoEstiloID").Value, rowGrd.Cells("v_tallaID").Value, 0, 0)
                        End If
                    Next

                    mostrarTablaProductoAsignado()

                    mostrarTablaProductoDisponible()
                    Me.Cursor = Cursors.WaitCursor
                    mensajeExito("Hormas y Productos por nave", "Productos asignados con éxito")
                    chkProductoTodo.Checked = False
                    chkProductoTodoDatos.Checked = False
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar al menos un producto")
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally

        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub quitarProductoANave()
        Me.Cursor = Cursors.WaitCursor
        Dim totalSeleccionados As Boolean = False
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdDatosProducto.Rows
                If rowGrd.Cells("Seleccion").Value Then
                    totalSeleccionados = True
                    Exit For
                End If
            Next
            If totalSeleccionados Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea eliminar los productos seleccionados de la nave ?") = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    For Each rowGrd As UltraGridRow In grdDatosProducto.Rows
                        If rowGrd.Cells("Seleccion").Value Then
                            vHormasCapacidadesBU.DesasignarProducto(rowGrd.Cells("prna_prnaID").Value)
                        End If
                    Next
                    mostrarTablaProductoAsignado()
                    mostrarTablaProductoDisponible()
                    grdNavesProducto.DataSource = Nothing
                    ' Me.Cursor = Cursors.WaitCursor
                    mensajeExito("Hormas y Productos por nave", "Productos eliminados con éxito")
                    chkProductoTodo.Checked = False
                    chkProductoTodoDatos.Checked = False
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar al menos una horma")
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally

        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub guardarCapacidadOrdenProductos()
        Dim totalSeleccionados As Boolean = False
        Dim vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            If chkCapacidad.Checked = False And chkOrden.Checked = False Then
                mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar las acciones que va ha realizar (Orden y/o Capacidad)")
            Else
                Me.Cursor = Cursors.WaitCursor
                For Each rowGrd As UltraGridRow In grdDatosProducto.Rows
                    If rowGrd.Cells("Seleccion").Value Then
                        totalSeleccionados = True
                        Exit For
                    End If
                Next
                If totalSeleccionados Then
                    If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea actualizar el orden y/o capacidad del producto(s) en esta nave ?") = Windows.Forms.DialogResult.OK Then
                        For Each rowGrd As UltraGridRow In grdDatosProducto.Rows
                            If rowGrd.Cells("Seleccion").Value Then
                                vHormasCapacidadesBU.actualizarOrdenCantidadProducto(ordenAnterior, chkCapacidad.Checked, CInt(txtCapacidadProducto.Value), chkOrden.Checked, cmbOrdenProducto.SelectedValue, rowGrd.Cells("prna_prnaID").Value)
                            End If
                        Next
                        mostrarTablaProductoAsignado()
                        txtCapacidadProducto.Value = 0
                        cmbOrdenProducto.SelectedItem = 1
                        mensajeExito("Hormas y Productos por nave", "Productos actualizados con éxito")

                    End If
                Else
                    mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar los productos disponibles a las que desea asignar el Orden y/o Capacidad")
                End If
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub actualizarOrdenProducto()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ordenActualizado As Integer = grdDatosProducto.ActiveRow.Cells("prna_orden").Value
            If ordenActualizado > 0 And ordenActualizado < (cmbOrdenProducto.Items.Count + 1) Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea actualizar el orden de producción del producto ?") = Windows.Forms.DialogResult.OK Then
                    vHormasCapacidadesBU.actualizarOrdenProducto(ordenAnterior, grdDatosProducto.ActiveRow.Cells("prna_orden").Value, grdDatosProducto.ActiveRow.Cells("prna_prnaID").Value)
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "El orden debe de ser capturado en valores numericos mayores a 0 y menores a " + (cmbOrdenProducto.Items.Count + 1).ToString)
                'grdDatosProducto.ActiveRow.Cells("prna_orden").Value = valorActualOrden
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            mostrarTablaProductoAsignado()
            'vTipoTablaFormato = 1
            'mostrardatosnaveorden(2)
        End Try

    End Sub
    Public Sub actualizarCapacidadProducto()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea actualizar la capacidad del producto ?") = Windows.Forms.DialogResult.OK Then
                vHormasCapacidadesBU.actualizarCapacidadProducto(grdDatosProducto.ActiveRow.Cells("prna_capacidad").Value, grdDatosProducto.ActiveRow.Cells("prna_prnaID").Value)
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub actualizarEstatusMuestras()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea indicar que se fabrican muestras del producto de esta nave ?") = Windows.Forms.DialogResult.OK Then
                vHormasCapacidadesBU.actualizarMuestraProducto(grdDatosProducto.ActiveRow.Cells("prna_muestras").Value, grdDatosProducto.ActiveRow.Cells("prna_prnaID").Value)
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub actualizarOrdenesNaves()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            If mensajeConfirmar("Hormas y Productos por nave", "¿ Está seguro de actualizar el orden de las naves?") = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                For Each rowGrd As UltraGridRow In grdNavesProducto.Rows
                    vHormasCapacidadesBU.actualizarOrdenNaves(rowGrd.Cells("prna_prnaID").Value, rowGrd.Cells("nuevOrden").Value)
                Next
                vTipoTablaFormato = 1
                mostrardatosnaveorden(vTablaProce)
                btnGuardar.Enabled = False
                btnCancelar.Enabled = False
                btnActualizar.Enabled = True
                lblCancelar.Enabled = False
                lblGuardar.Enabled = False
                lblOrdenar.Enabled = True
                PanelProductosDisponibles.Enabled = True
                Panel12.Enabled = True
                grdDatosProducto.Enabled = True
                cmbNaves.Enabled = True
                tabPrincipal.Tabs(0).Enabled = True
                tabPrincipal.Tabs(2).Enabled = True
                btnExportarExcel.Enabled = True
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
#End Region
#Region "diseño"
    Public Sub formatoTablaProductosDisPonibles()
        grdProductoDisponible.DisplayLayout.Bands(0).Columns.Add("Seleccion", "")
        grdProductoDisponible.DisplayLayout.Bands(0).Columns("Seleccion").Header.VisiblePosition = 0
        Dim band As UltraGridBand = Me.grdProductoDisponible.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Activation.AllowEdit
            .Columns("ModSicy").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("v_prodID").CellActivation = Activation.NoEdit
            .Columns("v_productoEstiloID").CellActivation = Activation.NoEdit
            .Columns("v_tallaID").CellActivation = Activation.NoEdit

            '.Columns("hona_capacidad").Style = ColumnStyle.IntegerNonNegative

            .Columns("v_prodID").Hidden = True '
            .Columns("v_productoEstiloID").Hidden = True
            .Columns("v_tallaID").Hidden = True
            .Columns("ModSicy").Hidden = True

            .Columns("Modelo").Header.VisiblePosition = 1
            .Columns("Corrida").Header.VisiblePosition = 2
            .Columns("Piel").Header.VisiblePosition = 3
            .Columns("Color").Header.VisiblePosition = 4
            .Columns("Coleccion").Header.VisiblePosition = 5
            .Columns("Marca").Header.VisiblePosition = 6
            .Columns("Horma").Header.VisiblePosition = 7

            .Columns("Coleccion").Header.Caption = "Colección"
            '.Columns("hona_capacidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("seleccion").Style = ColumnStyle.CheckBox
            ' .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With


        ' grdProductoDisponible.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdProductoDisponible.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductoDisponible.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductoDisponible.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        ' grdHormasDisponibles.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        ' grdProductoDisponible.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        band.Columns("Modelo").Width = 55
        band.Columns("Corrida").Width = 55
        band.Columns("Seleccion").Width = 30


        For Each rowGrd As UltraGridRow In grdProductoDisponible.Rows
            rowGrd.Cells("Seleccion").Value = False
        Next
    End Sub
    Public Sub formatoTablaProductosAsignados()
        grdDatosProducto.DisplayLayout.Bands(0).Columns.Add("Seleccion", "")
        grdDatosProducto.DisplayLayout.Bands(0).Columns("Seleccion").Header.VisiblePosition = 0
        Dim band As UltraGridBand = Me.grdDatosProducto.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Activation.AllowEdit
            .Columns("prna_prnaID").CellActivation = Activation.NoEdit
            .Columns("ModSicy").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("prna_muestras").CellActivation = Activation.AllowEdit
            .Columns("prna_capacidad").CellActivation = Activation.AllowEdit
            .Columns("prna_orden").CellActivation = Activation.AllowEdit
            .Columns("v_hormaID").CellActivation = Activation.NoEdit
            .Columns("v_prodID").CellActivation = Activation.NoEdit
            .Columns("v_productoEstiloID").CellActivation = Activation.NoEdit
            .Columns("v_tallaID").CellActivation = Activation.NoEdit
            .Columns("celulasCap").CellActivation = Activation.NoEdit
            .Columns("Semana").CellActivation = Activation.NoEdit
            .Columns("puedeEliminar").CellActivation = Activation.NoEdit
            .Columns("puedeEliminar").CellAppearance.FontData.Bold = DefaultableBoolean.True

            .Columns("prna_capacidad").Style = ColumnStyle.IntegerNonNegative
            .Columns("prna_orden").Style = ColumnStyle.IntegerNonNegative
            .Columns("prna_capacidad").Format = "##,##0"
            .Columns("v_prodID").Hidden = True '
            .Columns("v_productoEstiloID").Hidden = True
            .Columns("v_tallaID").Hidden = True
            .Columns("ModSicy").Hidden = True
            .Columns("prna_prnaID").Hidden = True
            .Columns("v_hormaID").Hidden = True
            '.Columns("Horma").Hidden = True

            '.Columns("Modelo").Header.VisiblePosition = 1
            '.Columns("Corrida").Header.VisiblePosition = 2
            '.Columns("Piel").Header.VisiblePosition = 3
            '.Columns("Color").Header.VisiblePosition = 4
            '.Columns("prna_capacidad").Header.VisiblePosition = 5
            '.Columns("prna_orden").Header.VisiblePosition = 6
            '.Columns("Coleccion").Header.VisiblePosition = 7
            '.Columns("Marca").Header.VisiblePosition = 8
            '.Columns("Horma").Header.VisiblePosition = 9
            '.Columns("prna_muestras").Header.VisiblePosition = 10

            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("prna_capacidad").Header.Caption = "* Capacidad"
            .Columns("prna_orden").Header.Caption = "* Orden"
            .Columns("prna_muestras").Header.Caption = "* Muestra"
            .Columns("celulasCap").Header.Caption = "Células"
            .Columns("puedeEliminar").Header.Caption = "¿Elimina?"

            .Columns("prna_capacidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prna_orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("celulasCap").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Semana").CellAppearance.TextHAlign = HAlign.Right

            .Columns("seleccion").Style = ColumnStyle.CheckBox
            .Columns("prna_muestras").Style = ColumnStyle.CheckBox
            ' .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        'grdDatosProducto.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatosProducto.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatosProducto.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatosProducto.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatosProducto.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        'Me.grdDatosProducto.DisplayLayout.Bands(0).Columns("Coleccion").PerformAutoResize()

        ' grdHormasDisponibles.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        'band.Columns("Modelo").Width = 60
        'band.Columns("Corrida").Width = 50
        'band.Columns("prna_orden").Width = 50
        'band.Columns("Seleccion").Width = 40
        'band.Columns("prna_muestras").Width = 50
        'band.Columns("Coleccion").Width = 60
        'band.Columns("Semana").Width = 50
        'band.Columns("puedeEliminar").Width = 50

        band.Columns("Seleccion").Width = 30
        band.Columns("ModSicy").Width = 50
        band.Columns("Marca").Width = 70
        band.Columns("Coleccion").Width = 70
        band.Columns("Modelo").Width = 40
        band.Columns("Piel").Width = 75
        band.Columns("Color").Width = 70
        band.Columns("Corrida").Width = 50
        band.Columns("Horma").Width = 60
        band.Columns("prna_muestras").Width = 30
        band.Columns("prna_capacidad").Width = 35
        band.Columns("prna_orden").Width = 25
        band.Columns("celulasCap").Width = 30
        band.Columns("Semana").Width = 35
        band.Columns("puedeEliminar").Width = 30


        For Each rowGrd As UltraGridRow In grdDatosProducto.Rows
            rowGrd.Cells("Seleccion").Value = False
            If rowGrd.Cells("celulasCap").Value = 0 Then
                rowGrd.Cells("puedeEliminar").Value = "SI"
                rowGrd.Cells("puedeEliminar").Appearance.ForeColor = Color.ForestGreen
            Else
                rowGrd.Cells("puedeEliminar").Appearance.ForeColor = Color.Red
                rowGrd.Cells("seleccion").Activation = Activation.NoEdit
            End If
        Next
    End Sub
    Public Sub formatoTablaNaveOrden()
        grdNavesProducto.DisplayLayout.Bands(0).Columns.Add("nuevOrden", "Orden nuevo")
        Dim band As UltraGridBand = Me.grdNavesProducto.DisplayLayout.Bands(0)
        With band

            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("prna_orden").CellActivation = Activation.AllowEdit

            .Columns("prna_orden").Style = ColumnStyle.IntegerNonNegative

            .Columns("prna_prnaID").Hidden = True '
            .Columns("prna_naveID").Hidden = True '
            .Columns("prna_productoEstiloID").Hidden = True

            .Columns("nave_nombre").Header.Caption = "Nave"
            .Columns("prna_orden").Header.Caption = "Orden anterior"

            .Columns("prna_orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("nuevOrden").CellAppearance.TextHAlign = HAlign.Right

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        Dim contador As Integer = 1
        For Each rowGrd As UltraGridRow In grdNavesProducto.Rows
            rowGrd.Cells("nuevOrden").Value = contador
            contador += 1
        Next
        If vTipoTablaFormato = 1 Then
            formatoAdicional()
        Else
            formatoAdicionalOrdenamiento()
        End If
        band.Columns("nave_nombre").Width = 50
        band.Columns("prna_orden").Width = 40
        band.Columns("nuevOrden").Width = 40

    End Sub

    Public Sub formatoAdicional()
        grdNavesProducto.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdNavesProducto.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNavesProducto.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNavesProducto.DisplayLayout.Override.RowSelectorWidth = 35
        grdNavesProducto.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdNavesProducto.DisplayLayout.Override.SelectTypeRow = SelectType.Default
        grdNavesProducto.DisplayLayout.Override.AllowAddNew = AllowAddNew.Default
        grdNavesProducto.AllowDrop = False
        grdNavesProducto.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Default
        grdNavesProducto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Public Sub formatoAdicionalOrdenamiento()
        grdNavesProducto.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdNavesProducto.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNavesProducto.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNavesProducto.DisplayLayout.Override.RowSelectorWidth = 35
        grdNavesProducto.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdNavesProducto.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdNavesProducto.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdNavesProducto.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
        grdNavesProducto.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grdNavesProducto.AllowDrop = True
        grdNavesProducto.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
    End Sub

#End Region
#End Region

#Region "Global"
#Region "Asignados"
#Region "Datos"
    Public Sub mostraAsignados()
        mostrarAsignadosNaves()
        mostrarAsignadosProducto()
    End Sub
    Public Sub mostrarAsignadosNaves()
        Dim naves As New NavesBU
        grdNavesTodoAsignado.DataSource = Nothing
        grdNavesTodoAsignado.DataSource = naves.TablaNavesAuxAsignar
        formatoTablaHormaNaveAsignadas()
    End Sub
    Public Sub mostrarAsignadosProducto()
        'TablaProductosVerTodo
        vHormasCapacidadesBU = New HormasCapacidadesBU
        chkTodoProductoAsignado.Checked = False
        grdProductosTodoAsignado.DataSource = Nothing
        grdProductosTodoAsignado.DataSource = vHormasCapacidadesBU.TablaProductosVerTodo
        formatoTablaTodoProductosAsignados()
    End Sub
#End Region
#Region "Operaciones"
    Public Sub actualizarOrdenProductoGlobal()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ordenActualizado As Integer = grdProductosTodoAsignado.ActiveRow.Cells("prna_orden").Value
            If ordenActualizado > 0 And ordenActualizado < (cmbOrdenProducto.Items.Count + 1) Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea actualizar el orden de producción del producto ?") = Windows.Forms.DialogResult.OK Then
                    vHormasCapacidadesBU.actualizarOrdenProducto(ordenAnterior, grdProductosTodoAsignado.ActiveRow.Cells("prna_orden").Value, grdProductosTodoAsignado.ActiveRow.Cells("prna_prnaID").Value)
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "El orden debe de ser capturado en valores numericos mayores a 0 y menores a " + (cmbOrdenProducto.Items.Count + 1).ToString)
                'grdDatosProducto.ActiveRow.Cells("prna_orden").Value = valorActualOrden
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            mostrarAsignadosProducto()
        End Try

    End Sub
    Public Sub actualizarCapacidadProductoGlobal()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea actualizar la capacidad del producto ?") = Windows.Forms.DialogResult.OK Then
                vHormasCapacidadesBU.actualizarCapacidadProducto(grdProductosTodoAsignado.ActiveRow.Cells("prna_capacidad").Value, grdProductosTodoAsignado.ActiveRow.Cells("prna_prnaID").Value)
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub actualizarEstatusMuestrasGlobal()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Try
            Me.Cursor = Cursors.WaitCursor
            If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea indicar que se fabrican muestras del producto de esta nave ?") = Windows.Forms.DialogResult.OK Then
                vHormasCapacidadesBU.actualizarMuestraProducto(grdProductosTodoAsignado.ActiveRow.Cells("prna_muestras").Value, grdProductosTodoAsignado.ActiveRow.Cells("prna_prnaID").Value)
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub AsignarPorductoNaveGlobal()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        Dim vDialogResult As New DialogResult
        Dim totalSeleccionados As Boolean = False
        Dim totalSeleccionados2 As Boolean = False
        Dim totalProductos As Integer = 0
        Dim modeloValor As New ArrayList
        Dim idTallaValor As String = 0

        Dim tabladatos As New DataTable
        Dim band As UltraGridBand = grdProductosTodoAsignado.DisplayLayout.Bands(0)
        For Each column As UltraGridColumn In band.Columns
            tabladatos.Columns.Add(column.Key, column.DataType)
        Next

        Try
            Me.Cursor = Cursors.WaitCursor
            For Each rowGrd As UltraGridRow In grdProductosTodoAsignado.Rows
                If rowGrd.Cells("Seleccion").Value Then
                    totalSeleccionados = True

                End If
            Next
            For Each rowGrd As UltraGridRow In grdNavesTodoAsignado.Rows
                If rowGrd.Cells("Asignar").Value Then
                    totalSeleccionados2 = True
                    Exit For
                End If
            Next


            If totalSeleccionados And totalSeleccionados2 Then
                If mensajeConfirmar("Hormas y Productos por nave", "¿ Desea asignar los productos seleccionados a la nave seleccionada ?") = Windows.Forms.DialogResult.OK Then
                    Dim vConfirmarProductoForm As New ConfirmarProductoForm
                    For Each rowGrd2 As UltraGridRow In grdNavesTodoAsignado.Rows
                        If rowGrd2.Cells("Asignar").Value Then
                            For Each rowGrd As UltraGridRow In grdProductosTodoAsignado.Rows
                                If rowGrd.Cells("Seleccion").Value Then
                                    If modeloValor.Contains((Trim(rowGrd.Cells("Horma").Value.ToString) + Trim(rowGrd.Cells("Corrida").Value.ToString))) Then
                                    Else
                                        modeloValor.Add((Trim(rowGrd.Cells("Horma").Value.ToString) + Trim(rowGrd.Cells("Corrida").Value.ToString)))

                                        vConfirmarProductoForm.vCorrida = rowGrd.Cells("Corrida").Value
                                        vConfirmarProductoForm.vHorma = rowGrd.Cells("Horma").Value
                                        vConfirmarProductoForm.vIdHorma = rowGrd.Cells("v_hormaID").Value
                                        vConfirmarProductoForm.vIdNaveDestino = rowGrd2.Cells("ID_").Value
                                        vConfirmarProductoForm.vNaveDestino = rowGrd2.Cells("Nombre").Value
                                        vConfirmarProductoForm.vOrdenDestino = rowGrd2.Cells("Orden").Value
                                        vConfirmarProductoForm.vIdCorrida = rowGrd.Cells("prna_tallaID").Value
                                        vConfirmarProductoForm.vIdProducto = rowGrd.Cells("prna_productoID").Value
                                        vConfirmarProductoForm.vOrdendestinoMaximo = cmbOrdenProducto.Items.Count
                                        vConfirmarProductoForm.vIdProductoEstilo = rowGrd.Cells("prna_productoEstiloID").Value

                                        tabladatos = New DataTable
                                        For Each column As UltraGridColumn In band.Columns
                                            tabladatos.Columns.Add(column.Key, column.DataType)
                                        Next
                                        Dim modelov As New ArrayList
                                        Dim modelovalor2 As New ArrayList
                                        modelovalor2.Add((Trim(rowGrd.Cells("Horma").Value.ToString) + Trim(rowGrd.Cells("Corrida").Value.ToString)))
                                        totalProductos = 0
                                        For Each row As UltraGridRow In grdProductosTodoAsignado.Rows
                                            If row.Cells("Seleccion").Value And modelovalor2.Contains((Trim(row.Cells("Horma").Value.ToString) + Trim(row.Cells("Corrida").Value.ToString))) Then
                                                If modelov.Contains(Trim(row.Cells("Modelo").Value.ToString + Trim(row.Cells("Piel").Value.ToString) + Trim(row.Cells("Color").Value.ToString))) Then
                                                Else
                                                    modelov.Add(Trim(row.Cells("Modelo").Value.ToString + Trim(row.Cells("Piel").Value.ToString) + Trim(row.Cells("Color").Value.ToString)))
                                                    Dim cellValues As List(Of Object) = New List(Of Object)(row.Cells.Count)
                                                    For Each cell As UltraGridCell In row.Cells
                                                        cellValues.Add((cell.Value))
                                                    Next
                                                    totalProductos += 1
                                                    tabladatos.Rows.Add(cellValues.ToArray())
                                                End If
                                                'row.Delete(False)
                                                ' row.Hidden = True
                                            End If

                                        Next
                                        ' rowGrd.Hidden = True
                                        vConfirmarProductoForm.vProductosSeleccionados = totalProductos
                                        vConfirmarProductoForm.vTablaProductos = tabladatos
                                        vConfirmarProductoForm.ShowDialog()
                                        chkTodoProductoAsignado.Checked = False
                                    End If



                                End If
                            Next
                        End If
                    Next
                End If
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Debe de seleccionar la naves y los productos a asignar")
            End If
        Catch ex As Exception
            mensajeError("Hormas y Productos por nave", ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            mostrarAsignadosProducto()
        End Try
    End Sub
    Public Sub actualizarOrdenProductoGlobal2()
        Dim ordenActualizado As Integer = grdNavesTodoAsignado.ActiveRow.Cells("Orden").Value
        If ordenActualizado > 0 And ordenActualizado < (cmbOrdenProducto.Items.Count + 1) Then
        Else

            mensajeAdvertencia("Hormas y Productos por nave", "El orden debe de ser capturado en valores numericos mayores a 0 y menores a " + (cmbOrdenProducto.Items.Count + 1).ToString)
            mostrarAsignadosNaves()
        End If
    End Sub
#End Region
#Region "Diseño"
    Public Sub formatoTablaHormaNaveAsignadas()
        Dim band As UltraGridBand = Me.grdNavesTodoAsignado.DisplayLayout.Bands(0)
        With band
            .Columns("Nombre").CellActivation = Activation.NoEdit
            .Columns("Orden").CellActivation = Activation.AllowEdit
            .Columns("Asignar").CellActivation = Activation.AllowEdit
            .Columns("Orden").Style = ColumnStyle.IntegerNonNegative

            .Columns("ID_").Hidden = True

            .Columns("Nombre").Header.Caption = "Nave"
            .Columns("Orden").Header.Caption = "*Orden"
            .Columns("Asignar").Header.Caption = "*Asignar"

            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            ' .Columns("Asignar").EditorComponent = Me.UltraOptionSet1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdNavesTodoAsignado.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdNavesTodoAsignado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNavesTodoAsignado.DisplayLayout.Override.RowSelectorWidth = 35
        grdNavesTodoAsignado.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdNavesTodoAsignado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        band.Columns("Orden").Width = 70
        band.Columns("Asignar").Width = 70

        For Each rowGrd As UltraGridRow In grdNavesTodoAsignado.Rows
            rowGrd.Cells("Asignar").Value = False
        Next
    End Sub
    Public Sub formatoTablaTodoProductosAsignados()
        grdProductosTodoAsignado.DisplayLayout.Bands(0).Columns.Add("Seleccion", "")
        grdProductosTodoAsignado.DisplayLayout.Bands(0).Columns("Seleccion").Header.VisiblePosition = 0
        Dim band As UltraGridBand = Me.grdProductosTodoAsignado.DisplayLayout.Bands(0)
        With band
            .Columns("Seleccion").CellActivation = Activation.AllowEdit
            .Columns("prna_prnaID").CellActivation = Activation.NoEdit
            .Columns("ModSicy").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("prna_muestras").CellActivation = Activation.AllowEdit
            .Columns("prna_capacidad").CellActivation = Activation.AllowEdit
            .Columns("prna_orden").CellActivation = Activation.AllowEdit
            .Columns("v_hormaID").CellActivation = Activation.NoEdit
            .Columns("prna_productoID").CellActivation = Activation.NoEdit
            .Columns("prna_productoEstiloID").CellActivation = Activation.NoEdit
            .Columns("prna_tallaID").CellActivation = Activation.NoEdit
            .Columns("nave_nombre").CellActivation = Activation.NoEdit
            .Columns("prna_naveID").CellActivation = Activation.NoEdit

            .Columns("prna_capacidad").Style = ColumnStyle.IntegerNonNegative
            .Columns("prna_orden").Style = ColumnStyle.IntegerNonNegative
            .Columns("prna_capacidad").Format = "##,##0"
            .Columns("prna_productoID").Hidden = True '
            .Columns("prna_productoEstiloID").Hidden = True
            .Columns("prna_tallaID").Hidden = True
            .Columns("ModSicy").Hidden = True
            .Columns("prna_prnaID").Hidden = True
            .Columns("prna_naveID").Hidden = True
            .Columns("v_hormaID").Hidden = True

            .Columns("nave_nombre").Header.VisiblePosition = 1
            .Columns("Modelo").Header.VisiblePosition = 2
            .Columns("Corrida").Header.VisiblePosition = 3
            .Columns("Piel").Header.VisiblePosition = 4
            .Columns("Color").Header.VisiblePosition = 5
            .Columns("prna_capacidad").Header.VisiblePosition = 6
            .Columns("prna_orden").Header.VisiblePosition = 7
            .Columns("Coleccion").Header.VisiblePosition = 8
            .Columns("Marca").Header.VisiblePosition = 9
            .Columns("Horma").Header.VisiblePosition = 10
            .Columns("prna_muestras").Header.VisiblePosition = 11

            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("prna_capacidad").Header.Caption = "* Capacidad"
            .Columns("prna_orden").Header.Caption = "* Orden"
            .Columns("prna_muestras").Header.Caption = "* Muestra"
            .Columns("nave_nombre").Header.Caption = "Nave"

            .Columns("prna_capacidad").CellAppearance.TextHAlign = HAlign.Right
            .Columns("prna_orden").CellAppearance.TextHAlign = HAlign.Right

            .Columns("seleccion").Style = ColumnStyle.CheckBox
            .Columns("prna_muestras").Style = ColumnStyle.CheckBox
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With


        grdProductosTodoAsignado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductosTodoAsignado.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductosTodoAsignado.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        ' grdHormasDisponibles.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        band.Columns("Modelo").Width = 100
        band.Columns("Seleccion").Width = 40
        band.Columns("prna_muestras").Width = 60
        band.Columns("prna_orden").Width = 100
        For Each rowGrd As UltraGridRow In grdProductosTodoAsignado.Rows
            rowGrd.Cells("Seleccion").Value = False
        Next
    End Sub
#End Region

#End Region
#Region " No asignados"
#Region "datos"
    Public Sub mostrarNoAsignados()
        chkTodoProductoAsignado.Checked = False
        mostrarDatosGlobalesHormasNoAsignadas()
        mostrarDatosProductosGlobalesNoAsignados()
    End Sub
    Public Sub mostrarDatosGlobalesHormasNoAsignadas()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        grdNavesNoAsignado.DataSource = Nothing
        grdNavesNoAsignado.DataSource = vHormasCapacidadesBU.obtenerTodasHormas
        formatoHormasNoAsignado()
    End Sub
    Public Sub mostrarDatosProductosGlobalesNoAsignados()
        vHormasCapacidadesBU = New HormasCapacidadesBU
        grdProductoNoAsignado.DataSource = Nothing
        grdProductoNoAsignado.DataSource = vHormasCapacidadesBU.obtnerProductosDisponiblesGeneral
        formatoProductoNoAsignado()
    End Sub
#End Region
#Region "diseño"
    Public Sub formatoHormasNoAsignado()
        Dim band As UltraGridBand = Me.grdNavesNoAsignado.DisplayLayout.Bands(0)
        With band
            .Columns("horma_descripcion").CellActivation = Activation.NoEdit
            .Columns("horma_hormaid").Hidden = True
            .Columns("horma_descripcion").Header.Caption = "Hormas disponibles"
            ' .Columns("Asignar").EditorComponent = Me.UltraOptionSet1
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdNavesNoAsignado.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdNavesNoAsignado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdNavesNoAsignado.DisplayLayout.Override.RowSelectorWidth = 35
        grdNavesNoAsignado.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdNavesNoAsignado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdNavesNoAsignado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub
    Public Sub formatoProductoNoAsignado()
        Dim band As UltraGridBand = Me.grdProductoNoAsignado.DisplayLayout.Bands(0)
        With band

            .Columns("ModSicy").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Horma").CellActivation = Activation.NoEdit
            .Columns("v_productoEstiloID").CellActivation = Activation.NoEdit
            .Columns("v_prodID").CellActivation = Activation.NoEdit
            .Columns("v_tallaID").CellActivation = Activation.NoEdit


            .Columns("v_productoEstiloID").Hidden = True '
            .Columns("v_prodID").Hidden = True
            .Columns("v_tallaID").Hidden = True
            .Columns("ModSicy").Hidden = True

            .Columns("Modelo").Header.VisiblePosition = 1
            .Columns("Corrida").Header.VisiblePosition = 2
            .Columns("Piel").Header.VisiblePosition = 3
            .Columns("Color").Header.VisiblePosition = 4
            .Columns("Coleccion").Header.VisiblePosition = 5
            .Columns("Marca").Header.VisiblePosition = 6
            .Columns("Horma").Header.VisiblePosition = 7

            .Columns("Coleccion").Header.Caption = "Colección"


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With


        grdProductoNoAsignado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdProductoNoAsignado.DisplayLayout.Override.RowSelectorWidth = 35
        grdProductoNoAsignado.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdProductoNoAsignado.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdProductoNoAsignado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub
#End Region
#End Region
#End Region

#Region "Mensajes Programas"
    Public Sub mensajeAdvertencia(ByVal titulo As String, ByVal mensaje As String)
        Dim vAdvertenciaForm As New AdvertenciaForm
        vAdvertenciaForm.Text = titulo
        vAdvertenciaForm.mensaje = mensaje
        vAdvertenciaForm.ShowDialog()
        vAdvertenciaForm = Nothing
    End Sub
    Public Sub mensajeError(ByVal titulo As String, ByVal mensaje As String)
        Dim vErrorForm As New ErroresForm
        vErrorForm.Text = titulo
        vErrorForm.mensaje = mensaje
        vErrorForm.ShowDialog()
        vErrorForm = Nothing
    End Sub
    Public Sub mensajeExito(ByVal titulo As String, ByVal mensaje As String)
        Dim vExitoForm As New ExitoForm
        vExitoForm.Text = titulo
        vExitoForm.mensaje = mensaje
        vExitoForm.ShowDialog()
        vExitoForm = Nothing
    End Sub
    Public Function mensajeConfirmar(ByVal titulo As String, mensaje As String) As DialogResult
        Dim vConfirmarForm As New Tools.ConfirmarForm
        Dim vDialogResult As New DialogResult
        vConfirmarForm.Text = titulo
        vConfirmarForm.mensaje = mensaje
        vDialogResult = vConfirmarForm.ShowDialog
        Return vDialogResult
    End Function
    Public Function mensajeConfirmarGrande(ByVal titulo As String, mensaje As String) As DialogResult
        Dim vConfirmarForm As New Tools.confirmarFormGrande
        Dim vDialogResult As New DialogResult
        vConfirmarForm.Text = titulo
        vConfirmarForm.mensaje = mensaje
        vDialogResult = vConfirmarForm.ShowDialog
        Return vDialogResult
    End Function
#End Region

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If bandera Then
            tab = tabPrincipal.ActiveTab.Index
            mostrarDatosPrincipales(tab)
        End If
    End Sub

    Private Sub chkHormasTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkHormasTodo.CheckedChanged
        Dim estatuHorma As Boolean = False
        If chkHormasTodo.Checked = True Then
            estatuHorma = True
        End If
        For Each rowGrd As UltraGridRow In grdHormasDisponibles.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Seleccion").Value = estatuHorma
        Next
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click

        agregarHormaANave()
    End Sub

    Private Sub chkTodoHormaDatos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodoHormaDatos.CheckedChanged
        Dim estatuHorma As Boolean = False
        If chkTodoHormaDatos.Checked = True Then
            estatuHorma = True
        End If
        For Each rowGrd As UltraGridRow In grdDatosHormas.Rows.GetFilteredInNonGroupByRows
            If rowGrd.Cells("Elimina").Value.ToString = "SI" Then
                rowGrd.Cells("Seleccion").Value = estatuHorma
            End If
        Next
    End Sub

    Private Sub btnGuardarHorma_Click(sender As Object, e As EventArgs) Handles btnGuardarHorma.Click
        cambiarCapacidad()
    End Sub

    Private Sub btnQuitarColeccion_Click(sender As Object, e As EventArgs) Handles btnQuitarColeccion.Click
        quitarHormaANave()
    End Sub

    Private Sub grdDatosHormas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosHormas.AfterCellUpdate
        With grdDatosHormas
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        Select Case e.Cell.Column.Key.ToUpper.Trim
            Case "HONA_CAPACIDAD"
                actualizarHorma()
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub grdDatosHormas_AfterGroupPosChanged(sender As Object, e As AfterGroupPosChangedEventArgs) Handles grdDatosHormas.AfterGroupPosChanged

    End Sub

    Private Sub grdDatosHormas_AfterRowActivate(sender As Object, e As EventArgs) Handles grdDatosHormas.AfterRowActivate
        'With grdDatosHormas
        '    If .ActiveRow Is Nothing Then Exit Sub
        '    If .ActiveRow.Index < 0 Then Exit Sub
        'End With
        'If grdDatosHormas.ActiveRow.IsFilterRow = False Then 
        '    idHorma = grdDatosHormas.ActiveRow.Cells("hona_hormaID").Value
        '    idTalla = grdDatosHormas.ActiveRow.Cells("hona_tallaid").Value
        '    mostrarDatosNavesHormaAsignada()
        '    lblHormaSeleccionada.Text = grdDatosHormas.ActiveRow.Cells("horma_descripcion").Value & "    " & grdDatosHormas.ActiveRow.Cells("talla_descripcion").Value
        '    Dim idHormaSelSemana As Int32 = grdDatosHormas.ActiveRow.Cells("hona_hormaID").Value
        '    Dim idHormaTallaSelSemana As Int32 = grdDatosHormas.ActiveRow.Cells("hona_tallaid").Value
        '    llenarTablaCapacidades(idHormaSelSemana, idHormaTallaSelSemana)
        'End If
    End Sub

    Private Sub cmbNaves_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaves.SelectedIndexChanged
        If bandera Then
            tab = tabPrincipal.ActiveTab.Index
            mostrarDatosPrincipales(tab)
            lblHormaSeleccionada.Text = ""
            lblProductoSeleccionado.Text = ""
            grdNavesHormas.DataSource = Nothing
            grdCapacidadesCelulas.DataSource = Nothing
            grdNavesProducto.DataSource = Nothing
            grdProductosCelulas.DataSource = Nothing
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarExcelDatos()
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged
        inicializarComboTallas()
        mostrarTablaProductoDisponible()
        mostrarTablaProductoAsignado()
    End Sub

    Private Sub tabPrincipal_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabPrincipal.SelectedTabChanged
        If bandera Then
            tab = tabPrincipal.ActiveTab.Index
            mostrarDatosPrincipales(tab)
            lblHormaSeleccionada.Text = ""
            lblProductoSeleccionado.Text = ""
            grdNavesHormas.DataSource = Nothing
            grdCapacidadesCelulas.DataSource = Nothing
            grdNavesProducto.DataSource = Nothing
        End If
    End Sub

    Private Sub cmbCorridas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorridas.SelectedIndexChanged
        mostrarTablaProductoDisponible()
        mostrarTablaProductoAsignado()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRemoverProducto.Click
        quitarProductoANave()
    End Sub

    Private Sub chkProductoTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkProductoTodo.CheckedChanged
        Dim estatuHorma As Boolean = False
        If chkProductoTodo.Checked = True Then
            estatuHorma = True
        End If
        For Each rowGrd As UltraGridRow In grdProductoDisponible.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Seleccion").Value = estatuHorma
        Next
    End Sub

    Private Sub chkProductoTodoDatos_CheckedChanged(sender As Object, e As EventArgs) Handles chkProductoTodoDatos.CheckedChanged
        Dim estatuHorma As Boolean = False
        If chkProductoTodoDatos.Checked = True Then
            estatuHorma = True
        End If
        For Each rowGrd As UltraGridRow In grdDatosProducto.Rows.GetFilteredInNonGroupByRows
            If rowGrd.Cells("puedeEliminar").Value.ToString = "SI" Then
                rowGrd.Cells("Seleccion").Value = estatuHorma
            End If
        Next
    End Sub

    Private Sub btnGuardarProducto_Click(sender As Object, e As EventArgs) Handles btnGuardarProducto.Click
        guardarCapacidadOrdenProductos()
    End Sub

    Private Sub grdDatosProducto_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdDatosProducto.AfterCellUpdate
        With grdDatosProducto
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        If bandera Then
            Select Case e.Cell.Column.Key.ToUpper.Trim
                Case "PRNA_CAPACIDAD"
                    actualizarCapacidadProducto()
                Case "PRNA_ORDEN"
                    actualizarOrdenProducto()
                Case "PRNA_MUESTRAS"
                    actualizarEstatusMuestras()
                Case Else
                    Exit Sub
            End Select
            'vTipoTablaFormato = 1
            'mostrardatosnaveorden(2)
        End If

    End Sub

    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        agregarProductoANave()
    End Sub

    Private Sub grdProductoDisponible_AfterRowUpdate(sender As Object, e As RowEventArgs) Handles grdProductoDisponible.AfterRowUpdate

    End Sub

    Private Sub grdProductoDisponible_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdProductoDisponible.AfterSelectChange
        With grdProductoDisponible
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdProductoDisponible.Rows
                If r.Selected Then
                    r.Cells("Seleccion").Value = True
                Else
                    r.Cells("Seleccion").Value = False
                End If
            Next

            grdProductoDisponible.EndUpdate()

            If chkProductoTodo.Checked = True Then
                chkProductoTodo.Checked = False
            End If

        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdProductoDisponible_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdProductoDisponible.ClickCell
        'MostrarNaves relacionadas con el producto
        With grdProductoDisponible
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        lblProductoSeleccionado.Text = grdProductoDisponible.ActiveRow.Cells("Modelo").Value & "   " & grdProductoDisponible.ActiveRow.Cells("Piel").Value & "    " & grdProductoDisponible.ActiveRow.Cells("Color").Value & "   " & grdProductoDisponible.ActiveRow.Cells("Corrida").Value
        'lblProductoSeleccionado.Text = grdProductoDisponible.ActiveRow.Cells("v_prodID").Value & "   " & grdProductoDisponible.ActiveRow.Cells("v_productoEstiloID").Value & "    " & grdProductoDisponible.ActiveRow.Cells("v_tallaID").Value
        vTipoTablaFormato = 1
        mostrardatosnaveorden(1)

    End Sub

    Private Sub grdDatosProducto_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdDatosProducto.AfterSelectChange
        With grdDatosProducto
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdDatosProducto.Rows
                If r.Selected Then
                    If r.Cells("puedeEliminar").Value.ToString = "SI" Then
                        r.Cells("Seleccion").Value = True
                    Else
                        r.Cells("Seleccion").Value = False
                    End If
                Else
                    r.Cells("Seleccion").Value = False
                End If
            Next

            grdDatosProducto.EndUpdate()


            If chkProductoTodoDatos.Checked = True Then
                chkProductoTodoDatos.Checked = False
            End If

        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdDatosProducto_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdDatosProducto.BeforeCellUpdate
        'If bandera Then
        '    vTipoTablaFormato = 1
        '    mostrardatosnaveorden(2)
        'End If
        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.Key.ToUpper.Trim = "PRNA_ORDEN" Then
                ordenAnterior = e.Cell.Value()
                'Dim ordAnterior As String = ""
                'Dim ordNuevo As String = ""
                'ordenAnterior = e.Cell.Value.ToString()
                'ordNuevo = e.NewValue.ToString
            End If
        End If
    End Sub

    Private Sub grdDatosProducto_BeforeRowRegionScroll(sender As Object, e As BeforeRowRegionScrollEventArgs) Handles grdDatosProducto.BeforeRowRegionScroll

    End Sub

    Private Sub grdDatosProducto_Click(sender As Object, e As EventArgs) Handles grdDatosProducto.Click
        'With grdDatosProducto
        '    If .ActiveRow Is Nothing Then Exit Sub
        '    If .ActiveRow.Index < 0 Then Exit Sub
        'End With
        'If bandera Then
        '    vTipoTablaFormato = 1
        '    mostrardatosnaveorden(2)
        'End If
    End Sub

    Private Sub grdDatosProducto_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDatosProducto.ClickCell
        With grdDatosProducto
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        'lblProductoSeleccionado.Text = grdDatosProducto.ActiveRow.Cells("v_prodID").Value & "   " & grdDatosProducto.ActiveRow.Cells("v_productoEstiloID").Value & "   " & grdDatosProducto.ActiveRow.Cells("v_tallaID").Value
        lblProductoSeleccionado.Text = grdDatosProducto.ActiveRow.Cells("Modelo").Value & "   " & grdDatosProducto.ActiveRow.Cells("Piel").Value & "    " & grdDatosProducto.ActiveRow.Cells("Color").Value & "    " & grdDatosProducto.ActiveRow.Cells("Corrida").Value
        If bandera Then
            vTipoTablaFormato = 1
            mostrardatosnaveorden(2)
        End If
    End Sub

    Private Sub grdDatosProducto_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdDatosProducto.DoubleClickCell
        'MostrarNaves Relacionadas con el producto


    End Sub

    Private Sub grdNavesTodoAsignado_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdNavesTodoAsignado.AfterCellUpdate

        With grdNavesTodoAsignado
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        If bandera Then
            Select Case e.Cell.Column.Key.ToUpper.Trim
                Case "ORDEN"
                    If grdNavesTodoAsignado.ActiveRow.Cells("Asignar").Value Then
                        actualizarOrdenProductoGlobal2()
                    Else
                        mensajeAdvertencia("Hormas y Productos por nave", "Debe seleccionar la nave para asignar un orden de producción")
                        mostrarAsignadosNaves()
                    End If

                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub grdNavesTodoAsignado_CellChange(sender As Object, e As CellEventArgs) Handles grdNavesTodoAsignado.CellChange
        With grdNavesTodoAsignado
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        If bandera Then
            Select Case e.Cell.Column.Key.ToUpper.Trim
                Case "ASIGNAR"

                    For Each rowGrd As UltraGridRow In grdNavesTodoAsignado.Rows
                        rowGrd.Cells("Asignar").Value = False
                    Next
                    e.Cell.Value = True
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub grdProductosTodoAsignado_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdProductosTodoAsignado.AfterCellUpdate
        With grdProductosTodoAsignado
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        If bandera Then
            Select Case e.Cell.Column.Key.ToUpper.Trim
                Case "PRNA_CAPACIDAD"
                    actualizarCapacidadProductoGlobal()
                Case "PRNA_ORDEN"
                    actualizarOrdenProductoGlobal()
                Case "PRNA_MUESTRAS"
                    actualizarEstatusMuestrasGlobal()
                Case Else
                    Exit Sub
            End Select
        End If
    End Sub

    Private Sub btnAsignarProducto_Click(sender As Object, e As EventArgs) Handles btnAsignarProducto.Click
        AsignarPorductoNaveGlobal()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        vTipoTablaFormato = 2
        mostrardatosnaveorden(vTablaProce)
        btnGuardar.Enabled = True
        btnCancelar.Enabled = True
        lblCancelar.Enabled = True
        lblGuardar.Enabled = True

        btnActualizar.Enabled = False
        lblOrdenar.Enabled = False
        PanelProductosDisponibles.Enabled = False
        Panel12.Enabled = False
        grdDatosProducto.Enabled = False
        cmbNaves.Enabled = False
        tabPrincipal.Tabs(0).Enabled = False
        tabPrincipal.Tabs(2).Enabled = False
        btnExportarExcel.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        actualizarOrdenesNaves()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        vTipoTablaFormato = 1
        mostrardatosnaveorden(vTablaProce)
        btnGuardar.Enabled = False
        btnCancelar.Enabled = False
        btnActualizar.Enabled = True
        lblCancelar.Enabled = False
        lblGuardar.Enabled = False
        lblOrdenar.Enabled = True
        PanelProductosDisponibles.Enabled = True
        Panel12.Enabled = True
        grdDatosProducto.Enabled = True
        cmbNaves.Enabled = True
        tabPrincipal.Tabs(0).Enabled = True
        tabPrincipal.Tabs(2).Enabled = True
        btnExportarExcel.Enabled = True
    End Sub

    Private Sub grdNavesProducto_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdNavesProducto.SelectionDrag

        grdNavesProducto.DoDragDrop(grdNavesProducto.Selected.Rows, DragDropEffects.Move)

    End Sub

    Private Sub grdNavesProducto_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdNavesProducto.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            Me.grdNavesProducto.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            Me.grdNavesProducto.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdNavesProducto_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles grdNavesProducto.DragDrop
        Dim dropIndex As Integer = 0
        Dim uieOver As UIElement = grdNavesProducto.DisplayLayout.UIElement.ElementFromPoint(grdNavesProducto.PointToClient(New Point(e.X, e.Y)))
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index
            If dropIndex = -1 Then
                dropIndex = 0
            End If
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)

            For Each aRow As UltraGridRow In SelRows
                grdNavesProducto.Rows.Move(aRow, dropIndex)
            Next
            Dim contador As Integer = 1
            For Each rowGrd As UltraGridRow In grdNavesProducto.Rows
                rowGrd.Cells("nuevOrden").Value = contador
                contador = contador + 1
            Next

        End If
    End Sub

    Private Sub chkTodoProductoAsignado_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodoProductoAsignado.CheckedChanged
        Dim estatuHorma As Boolean = False
        If chkTodoProductoAsignado.Checked = True Then
            estatuHorma = True
        End If
        For Each rowGrd As UltraGridRow In grdProductosTodoAsignado.Rows.GetFilteredInNonGroupByRows
            rowGrd.Cells("Seleccion").Value = estatuHorma
        Next
    End Sub

    Private Sub tabSecundario_SelectedTabChanged(sender As Object, e As UltraWinTabControl.SelectedTabChangedEventArgs) Handles tabSecundario.SelectedTabChanged
        If bandera Then
            tab2secundario = tabSecundario.ActiveTab.Index
            If tab2secundario = 0 Then
                mostraAsignados()
            ElseIf tab2secundario = 1 Then
                mostrarNoAsignados()
            Else
                mensajeAdvertencia("Hormas y Productos por nave", "Pestaña no asignada")
            End If
        End If

    End Sub

    Private Sub grdHormasDisponibles_AfterRowActivate(sender As Object, e As EventArgs) Handles grdHormasDisponibles.AfterRowActivate
        'With grdHormasDisponibles
        '    If .ActiveRow Is Nothing Then Exit Sub
        '    If .ActiveRow.Index < 0 Then Exit Sub
        'End With
        'If grdHormasDisponibles.ActiveRow.IsFilterRow = False Then
        '    idHorma = grdHormasDisponibles.ActiveRow.Cells("horma_hormaid").Value
        '    idTalla = grdHormasDisponibles.ActiveRow.Cells("talla_tallaid").Value
        '    lblHormaSeleccionada.Text = grdHormasDisponibles.ActiveRow.Cells("horma_descripcion").Value & "    " & grdHormasDisponibles.ActiveRow.Cells("talla_descripcion").Value
        '    mostrarDatosNavesHormaAsignada()
        '    ' TAMBIEN MOSTRAR CAPACIDADES DE CELULAS
        'End If
    End Sub


    Private Sub grdHormasDisponibles_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdHormasDisponibles.AfterSelectChange
        With grdHormasDisponibles
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdHormasDisponibles.Rows
                If r.Selected Then
                    r.Cells("Seleccion").Value = True
                Else
                    r.Cells("Seleccion").Value = False
                End If
            Next

            grdHormasDisponibles.EndUpdate()

        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        If chkHormasTodo.Checked = True Then
            chkHormasTodo.Checked = False
        End If

    End Sub

    Private Sub grdDatosHormas_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdDatosHormas.AfterSelectChange
        With grdDatosHormas
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdDatosHormas.Rows
                If r.Selected Then
                    If r.Cells("Elimina").Value.ToString = "SI" Then
                        r.Cells("Seleccion").Value = True
                    Else
                        r.Cells("Seleccion").Value = False
                    End If
                Else
                    r.Cells("Seleccion").Value = False
                End If
            Next

            grdDatosHormas.EndUpdate()

            If chkTodoHormaDatos.Checked = True Then
                chkTodoHormaDatos.Checked = False
            End If

        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub grdProductosTodoAsignado_AfterSelectChange(sender As Object, e As AfterSelectChangeEventArgs) Handles grdProductosTodoAsignado.AfterSelectChange
        With grdProductosTodoAsignado
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With

        Try
            Me.Cursor = Cursors.WaitCursor

            For Each r In grdProductosTodoAsignado.Rows
                If r.Selected Then
                    r.Cells("Seleccion").Value = True
                Else
                    r.Cells("Seleccion").Value = False
                End If
            Next

            grdProductosTodoAsignado.EndUpdate()
            If chkTodoProductoAsignado.Checked = True Then
                chkTodoProductoAsignado.Checked = False
            End If
        Catch ex As Exception
            ' naim.app.Errores.Mostrar(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    'Private Sub grdDatosProducto_GotFocus(sender As Object, e As EventArgs) Handles grdDatosProducto.GotFocus
    '    'With grdDatosProducto
    '    '    If .ActiveRow Is Nothing Then Exit Sub
    '    '    If .ActiveRow.Index < 0 Then Exit Sub
    '    'End With
    '    'If bandera Then
    '    '    vTipoTablaFormato = 1
    '    '    mostrardatosnaveorden(2)
    '    'End If
    'End Sub


    Private Sub grdProductosTodoAsignado_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdProductosTodoAsignado.BeforeCellUpdate

        If e.Cell.Row.IsFilterRow = False Then
            If e.Cell.Column.Key.ToUpper.Trim = "PRNA_ORDEN" Then
                ordenAnterior = e.Cell.Value()
                'Dim ordAnterior As String = ""
                'Dim ordNuevo As String = ""
                'ordenAnterior = e.Cell.Value.ToString()
                'ordNuevo = e.NewValue.ToString
            End If
        End If

    End Sub

    Private Sub grdProductosTodoAsignado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProductosTodoAsignado.InitializeLayout

    End Sub

    Private Sub grdDatosProducto_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosProducto.InitializeLayout

    End Sub

    Private Sub grdDatosHormas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDatosHormas.ClickCell
        With grdDatosHormas
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        If grdDatosHormas.ActiveRow.IsFilterRow = False Then
            idHorma = grdDatosHormas.ActiveRow.Cells("hona_hormaID").Value
            idTalla = grdDatosHormas.ActiveRow.Cells("hona_tallaid").Value
            mostrarDatosNavesHormaAsignada()
            lblHormaSeleccionada.Text = grdDatosHormas.ActiveRow.Cells("horma_descripcion").Value & "    " & grdDatosHormas.ActiveRow.Cells("talla_descripcion").Value
            Dim idHormaSelSemana As Int32 = grdDatosHormas.ActiveRow.Cells("hona_hormaID").Value
            Dim idHormaTallaSelSemana As Int32 = grdDatosHormas.ActiveRow.Cells("hona_tallaid").Value
            llenarTablaCapacidades(idHormaSelSemana, idHormaTallaSelSemana)
        End If
    End Sub


    Private Sub grdDatosHormas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatosHormas.InitializeLayout

    End Sub

    Private Sub grdHormasDisponibles_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdHormasDisponibles.ClickCell
        With grdHormasDisponibles
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With
        If grdHormasDisponibles.ActiveRow.IsFilterRow = False Then
            idHorma = grdHormasDisponibles.ActiveRow.Cells("horma_hormaid").Value
            idTalla = grdHormasDisponibles.ActiveRow.Cells("talla_tallaid").Value
            lblHormaSeleccionada.Text = grdHormasDisponibles.ActiveRow.Cells("horma_descripcion").Value & "    " & grdHormasDisponibles.ActiveRow.Cells("talla_descripcion").Value
            mostrarDatosNavesHormaAsignada()
            grdCapacidadesCelulas.DataSource = Nothing
            ' TAMBIEN MOSTRAR CAPACIDADES DE CELULAS
        End If
    End Sub

    Private Sub grdProductoDisponible_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProductoDisponible.InitializeLayout

    End Sub

    Private Sub pcbTitulo_Click(sender As Object, e As EventArgs) Handles pcbTitulo.Click
        Dim cosa As New frmProductosNuevos
        cosa.Show()
    End Sub



End Class