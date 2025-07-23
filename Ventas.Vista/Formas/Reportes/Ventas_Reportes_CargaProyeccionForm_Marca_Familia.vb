Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views
Imports DevExpress.XtraPrinting
Imports System.Data.OleDb
Imports DevExpress.Export

Public Class Ventas_Reportes_CargaProyeccionForm_Marca_Familia

    Dim lstInicial As New List(Of String)

    Dim filtro_AgenteIdSAY As String = ""
    Dim filtro_MarcaIdSAY As String = ""
    Dim filtro_FamiliaId As String = ""



    'Private listCeldasModificadas As New List(Of GridCell)
    Private listCeldasModificadas As New List(Of Entidades.DatosCargarProyeccion)
    Private importando As Boolean = False


    Dim listColumnasOcultarExportacion = New List(Of String)
    Dim listColumnasMostrarExportacion As New List(Of String)
    Dim lstMeses As New List(Of String)

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        Dim objBU As New Negocios.CargaProyeccionBU
        Dim dtSemanasCargadasPorAño As New DataTable

        dtSemanasCargadasPorAño = objBU.obtenerSemanasPorAño(nudAño.Value)

        nudSemanaDe.Minimum = dtSemanasCargadasPorAño.Rows(0).Item("PrimeraSemana")
        nudSemanaDe.Maximum = dtSemanasCargadasPorAño.Rows(0).Item("UltimaSemana")
        nudSemanaA.Minimum = nudSemanaDe.Minimum
        nudSemanaA.Maximum = nudSemanaDe.Maximum
    End Sub


    Private Sub nudSemanaDe_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaDe.ValueChanged
        nudSemanaA.Minimum = nudSemanaDe.Value
    End Sub

    Private Sub Ventas_Reportes_CargaProyeccionForm_Marca_Familia_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim objBU As New Negocios.CargaProyeccionBU
        Dim dtAñosCargados As New DataTable

        'Inicia datos de años y semanas

        dtAñosCargados = objBU.obtenerAñosGuardados()

        nudAño.Minimum = Integer.Parse(dtAñosCargados.Rows(0).Item("MenorAño").ToString())
        nudAño.Maximum = Integer.Parse(dtAñosCargados.Rows(0).Item("MayorAño").ToString())

        If Date.Now.Year >= nudAño.Minimum And Date.Now.Year <= nudAño.Maximum Then
            nudAño.Value = Date.Now.Year
        Else
            nudAño.Value = nudAño.Minimum
        End If

        nudSemanaDe.Value = nudSemanaDe.Minimum
        nudSemanaA.Value = nudSemanaA.Maximum

        'Termina datos de años y semanas

        grdAgentes.DataSource = lstInicial
        grdMarcas.DataSource = lstInicial
        grdFamilias.DataSource = lstInicial

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VNTAS_CTES_PROYECCION_VTAS_MARCA_FAMILIA", "ELIMINAR_PROYECCION") Then
            pnlEliminarProyeccion.Visible = True
            'btnEliminarProyeccion.Visible = True
            'lblEliminarProyeccion.Visible = True
        Else
            pnlEliminarProyeccion.Visible = False
            'btnEliminarProyeccion.Visible = False
            'lblEliminarProyeccion.Visible = False
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VNTAS_CTES_PROYECCION_VTAS_MARCA_FAMILIA", "EXPORTAR_ANUAL") Then
            pnlExportarAnual.Visible = True
        Else
            pnlExportarAnual.Visible = False
        End If

    End Sub

#Region "FILTROS"

    Private Sub btnAgentes_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New ListadoParametrosReportesForm


        listado.tipo_busqueda = 3

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdMarcas.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMarcas.DataSource = listado.listParametros
        With grdMarcas()
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Marca"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With

    End Sub

    Private Sub btnFamilia_Click(sender As Object, e As EventArgs) Handles btnFamilia.Click
        Dim listado As New ListadoParametrosApartadosForm
        listado.tipo_busqueda = 21
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFamilias.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFamilias.DataSource = listado.listParametros
        With grdFamilias
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Familia"
        End With
    End Sub


    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
    End Sub


    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout
        grid_diseño(grdMarcas)
        grdMarcas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marca"
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

    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFamilias_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilias.InitializeLayout
        grid_diseño(grdFamilias)
        grdFamilias.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Familia"
    End Sub

    Private Sub grdFamilias_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFamilias.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamilia.Click
        grdFamilias.DataSource = lstInicial
    End Sub

    Private Sub obtenerFiltros()
        filtro_AgenteIdSAY = ""
        filtro_MarcaIdSAY = ""
        filtro_FamiliaId = ""

        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_AgenteIdSAY <> "" Then
                filtro_AgenteIdSAY += ","
            End If
            filtro_AgenteIdSAY += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdMarcas.Rows
            If filtro_MarcaIdSAY <> "" Then
                filtro_MarcaIdSAY += ","
            End If
            filtro_MarcaIdSAY += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdFamilias.Rows
            If filtro_FamiliaId <> "" Then
                filtro_FamiliaId += ","
            End If
            filtro_FamiliaId += Row.Cells("Parametro").Value.ToString()
        Next

    End Sub

#End Region

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdDatosProyeccion.DataSource = Nothing
        grdAgentes.DataSource = lstInicial
        grdFamilias.DataSource = lstInicial
        grdMarcas.DataSource = lstInicial

        'Inicia datos de años y semanas

        If Date.Now.Year >= nudAño.Minimum And Date.Now.Year <= nudAño.Maximum Then
            nudAño.Value = Date.Now.Year
        Else
            nudAño.Value = nudAño.Minimum
        End If

        nudSemanaDe.Value = nudSemanaDe.Minimum
        nudSemanaA.Value = nudSemanaA.Maximum

        'Termina datos de años y semanas

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        Cursor = Cursors.WaitCursor

        Dim objBU As New Negocios.CargaProyeccionBU
        Dim dtResultadoConsulta As New DataTable
        Dim filtro_Año As Integer = nudAño.Value
        Dim filtro_SemanaDe As Integer = nudSemanaDe.Value
        Dim filtro_SemanaA As Integer = nudSemanaA.Value
        'listCeldasModificadas = New List(Of GridCell)
        listCeldasModificadas = New List(Of Entidades.DatosCargarProyeccion)

        importando = False

        obtenerFiltros()

        dtResultadoConsulta = objBU.consultaDatosProyeccionMarcaFamilia(filtro_Año, filtro_SemanaDe, filtro_SemanaA, filtro_AgenteIdSAY, filtro_MarcaIdSAY, filtro_FamiliaId)
        If dtResultadoConsulta.Rows.Count > 0 Then

            diseñoGrid(dtResultadoConsulta)

            grdDatosProyeccion.DataSource = dtResultadoConsulta

        Else

            show_message("Advertencia", "No hay datos para mostrar")

        End If

        btnArriba_Click(Nothing, Nothing)

        Cursor = Cursors.Default


    End Sub


#Region "DISEÑO"

    Private Sub bgvDatosProyeccion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvDatosProyeccion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub diseñoGrid(ByVal dtResultado As DataTable)
        Dim band As New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem
        lstMeses = New List(Of String)
        listColumnasMostrarExportacion = New List(Of String)
        listColumnasOcultarExportacion = New List(Of String)

        lstMeses.Add("ENERO")
        lstMeses.Add("FEBRERO")
        lstMeses.Add("MARZO")
        lstMeses.Add("ABRIL")
        lstMeses.Add("MAYO")
        lstMeses.Add("JUNIO")
        lstMeses.Add("JULIO")
        lstMeses.Add("AGOSTO")
        lstMeses.Add("SEPTIEMBRE")
        lstMeses.Add("OCTUBRE")
        lstMeses.Add("NOVIEMBRE")
        lstMeses.Add("DICIEMBRE")

        grdDatosProyeccion.DataSource = Nothing
        bgvDatosProyeccion.Bands.Clear()
        bgvDatosProyeccion.Columns.Clear()

        band.Caption = ""
        listBands.Add(band)

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        band.Caption = "Semanas de proyección"
        listBands.Add(band)

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            For Each col As DataColumn In dtResultado.Columns
                If (IsNumeric(col.ColumnName) Or col.ColumnName = "Total" Or lstMeses.Contains(col.ColumnName)) And gridBand.Caption <> "" Then
                    bgvDatosProyeccion.Columns.AddField(col.ColumnName)
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).DisplayFormat.FormatString = "N0"
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsFilter.AllowFilter = False
                    If col.ColumnName <> "Total" And lstMeses.Contains(col.ColumnName) = False Then
                        bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = True
                    Else
                        bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = False
                    End If
                ElseIf IsNumeric(col.ColumnName) = False And col.ColumnName <> "Total" And gridBand.Caption = "" And lstMeses.Contains(col.ColumnName) = False Then
                    bgvDatosProyeccion.Columns.AddField(col.ColumnName)
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OwnerBand = gridBand
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).Visible = True
                    bgvDatosProyeccion.Columns.ColumnByFieldName(col.ColumnName).OptionsColumn.AllowEdit = False
                End If
            Next
            bgvDatosProyeccion.Bands.Add(gridBand)
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvDatosProyeccion.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next

        bgvDatosProyeccion.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

        listColumnasMostrarExportacion.Add("Id Agente")
        listColumnasMostrarExportacion.Add("SAY")
        listColumnasMostrarExportacion.Add("SICY")
        listColumnasMostrarExportacion.Add("Activo")
        listColumnasMostrarExportacion.Add("Id Marca")
        listColumnasMostrarExportacion.Add("MarcaSICY")
        listColumnasMostrarExportacion.Add("FamiliaId")
        listColumnasMostrarExportacion.Add("RutaIdSAY")
        listColumnasMostrarExportacion.Add("Año")
        listColumnasMostrarExportacion.Add("clasificacionTexto")
        listColumnasMostrarExportacion.Add("clasificacionId")

        listColumnasOcultarExportacion.Add("Total")

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvDatosProyeccion.Columns
            If IsNumeric(Col.FieldName) = False And Col.FieldName <> "Total" And lstMeses.Contains(Col.FieldName) = False Then
                bgvDatosProyeccion.Columns.ColumnByFieldName(Col.FieldName).OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
            End If
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            If IsNumeric(Col.FieldName) Then
                Col.Width = 60
            End If
            If lstMeses.Contains(Col.FieldName) Then
                Col.Width = 80
            End If
            If Col.FieldName = "SAY" Then
                Col.Width = 50
            End If
            If Col.FieldName = "SICY" Then
                Col.Width = 50
            End If
            If Col.FieldName = "Total" Then
                Col.Width = 80
            End If
            If Col.FieldName = "Cliente" Or Col.FieldName = "Agente" Then
                Col.Width = 210
            End If
            If Col.FieldName = "Activo" Then
                Col.Width = 50
            End If
            If Col.FieldName = "Familia" Then
                Col.Width = 130
            End If
            If Col.FieldName = "RutaIdSAY" Or Col.FieldName = "MarcaSICY" Or listColumnasMostrarExportacion.Contains(Col.FieldName) Then
                Col.Visible = False
            End If
            If IsNumeric(Col.FieldName) Or Col.FieldName = "Total" Or lstMeses.Contains(Col.FieldName) Then
                Col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, Col.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = Col.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                bgvDatosProyeccion.GroupSummary.Add(item)
            End If
        Next

        bgvDatosProyeccion.IndicatorWidth = 45

    End Sub

#End Region

#Region "Otras Funciones"

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
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

#End Region

#Region "FORMATO CELDAS AL MODIFICAR VALOR"

    Private Sub bgvDatosProyeccion_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles bgvDatosProyeccion.CellValueChanged
        If IsNumeric(e.Column.FieldName) Then

            Dim datosGuardarProyeccion As New Entidades.DatosCargarProyeccion

            datosGuardarProyeccion = New Entidades.DatosCargarProyeccion
            datosGuardarProyeccion.semana = Integer.Parse(e.Column.FieldName.ToString)
            datosGuardarProyeccion.año = nudAño.Value
            datosGuardarProyeccion.marcaSAY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "Id Marca")
            datosGuardarProyeccion.colaboradorAgenteId = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "Id Agente")
            datosGuardarProyeccion.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "SAY")
            datosGuardarProyeccion.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "SICY")
            datosGuardarProyeccion.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "RutaIdSAY")
            datosGuardarProyeccion.paresProyectar = If(IsDBNull(bgvDatosProyeccion.GetRowCellValue(e.RowHandle, e.Column)), -1, bgvDatosProyeccion.GetRowCellValue(e.RowHandle, e.Column))
            datosGuardarProyeccion.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            datosGuardarProyeccion.marcaSICY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "MarcaSICY")
            datosGuardarProyeccion.familiaProyeccion = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "FamiliaId")
            datosGuardarProyeccion.clasificacionId = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "clasificacionId")
            datosGuardarProyeccion.clasificacionTexto = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "clasificacionTexto")

            If (Not ExisteCelda(datosGuardarProyeccion)) Then
                'If (Not ExisteCelda(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
                'listCeldasModificadas.Add(New GridCell(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column))
                listCeldasModificadas.Add(datosGuardarProyeccion)
            End If

        End If
    End Sub

    ' Private Function ExisteCelda(ByVal sourceRowIndex As Integer, ByVal col As GridColumn) As Boolean
    Private Function ExisteCelda(ByVal datosGuardarProyeccion As Entidades.DatosCargarProyeccion) As Boolean
        ' Dim Resultado As GridCell = listCeldasModificadas.Where(Function(c) c.Column Is col AndAlso c.RowHandle = sourceRowIndex).FirstOrDefault()
        Dim celdasIguales As Integer = 0
        For Each celdaModificada As Entidades.DatosCargarProyeccion In listCeldasModificadas
            If datosGuardarProyeccion.semana = celdaModificada.semana And datosGuardarProyeccion.año = celdaModificada.año And
                datosGuardarProyeccion.marcaSAY = celdaModificada.marcaSAY And
                datosGuardarProyeccion.colaboradorAgenteId = celdaModificada.colaboradorAgenteId And
                datosGuardarProyeccion.idClienteSAY = celdaModificada.idClienteSAY And
                datosGuardarProyeccion.idClienteSICY = celdaModificada.idClienteSICY And
                datosGuardarProyeccion.idRutaSAY = celdaModificada.idRutaSAY And
                datosGuardarProyeccion.usuarioId = celdaModificada.usuarioId And
                datosGuardarProyeccion.marcaSICY = celdaModificada.marcaSICY And
                datosGuardarProyeccion.familiaProyeccion = celdaModificada.familiaProyeccion And
                datosGuardarProyeccion.clasificacionId = celdaModificada.clasificacionId And
                datosGuardarProyeccion.clasificacionTexto = celdaModificada.clasificacionTexto Then

                celdaModificada.paresProyectar = datosGuardarProyeccion.paresProyectar

                celdasIguales += 1

            End If

        Next

        Dim Resultado As Boolean = If(celdasIguales > 0, True, False)
        'Return Resultado IsNot Nothing
        Return Resultado
    End Function

    Private Sub bgvDatosProyeccion_RowCellStyle(sender As Object, e As Grid.RowCellStyleEventArgs) Handles bgvDatosProyeccion.RowCellStyle
        Dim datosGuardarProyeccion As New Entidades.DatosCargarProyeccion

        If IsNumeric(e.Column.FieldName) Then
            datosGuardarProyeccion = New Entidades.DatosCargarProyeccion
            datosGuardarProyeccion.semana = Integer.Parse(e.Column.FieldName.ToString)
            datosGuardarProyeccion.año = nudAño.Value
            datosGuardarProyeccion.marcaSAY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "Id Marca")
            datosGuardarProyeccion.colaboradorAgenteId = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "Id Agente")
            datosGuardarProyeccion.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "SAY")
            datosGuardarProyeccion.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "SICY")
            datosGuardarProyeccion.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "RutaIdSAY")
            datosGuardarProyeccion.paresProyectar = If(IsDBNull(bgvDatosProyeccion.GetRowCellValue(e.RowHandle, e.Column)) = False, bgvDatosProyeccion.GetRowCellValue(e.RowHandle, e.Column), -1)
            datosGuardarProyeccion.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            datosGuardarProyeccion.marcaSICY = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "MarcaSICY")
            datosGuardarProyeccion.familiaProyeccion = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "FamiliaId")
            datosGuardarProyeccion.clasificacionId = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "clasificacionId")
            datosGuardarProyeccion.clasificacionTexto = bgvDatosProyeccion.GetRowCellValue(e.RowHandle, "clasificacionTexto")

            If (ExisteCelda(datosGuardarProyeccion)) Then
                'If ExisteCelda(bgvDatosProyeccion.GetDataSourceRowIndex(e.RowHandle), e.Column) Then
                e.Appearance.ForeColor = lblTextoCambiosNoGuardados.ForeColor
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If
        End If
    End Sub

#End Region


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 172
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim datosProyeccionGuardar As Entidades.DatosCargarProyeccion
        Dim dtResultadoGuardado As New DataTable
        Dim objBU As New Negocios.CargaProyeccionBU
        Dim confirmacion As New Tools.ConfirmarForm
        Dim totalCeldasConDatos As Integer = 0
        Dim familiaGuardarEditar As Integer = 0
        Dim clasificacionIdGuardarEditar As String = String.Empty
        Dim clasificacionTextoGuardarEditar As String = String.Empty

        Try
            'For Each celda As GridCell In listCeldasModificadas
            '    If IsDBNull(bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, celda.Column)) = False Then
            '        totalCeldasConDatos += 1
            '    End If
            'Next

            For Each datosModificados As Entidades.DatosCargarProyeccion In listCeldasModificadas
                If IsDBNull(datosModificados.paresProyectar) = False And If(datosModificados.paresProyectar = "", 0, datosModificados.paresProyectar) > 0 Then
                    totalCeldasConDatos += 1
                End If
            Next

            'If totalCeldasConDatos > 0 And importando = False Then
            If totalCeldasConDatos > 0 Then
                confirmacion.mensaje = "¿Desea guardar los cambios realizados?"
                If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Cursor = Cursors.WaitCursor

                    'If importando = False Then
                    'For Each celda As GridCell In listCeldasModificadas
                    '    If IsDBNull(bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, celda.Column)) = False Then
                    '        datosProyeccionGuardar = New Entidades.DatosCargarProyeccion
                    '        datosProyeccionGuardar.semana = Integer.Parse(celda.Column.FieldName.ToString)
                    '        datosProyeccionGuardar.año = nudAño.Value
                    '        datosProyeccionGuardar.marcaSAY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "Id Marca")
                    '        datosProyeccionGuardar.colaboradorAgenteId = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "Id Agente")
                    '        datosProyeccionGuardar.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "SAY")
                    '        datosProyeccionGuardar.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "SICY")
                    '        datosProyeccionGuardar.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "RutaIdSAY")
                    '        datosProyeccionGuardar.paresProyectar = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, celda.Column)
                    '        datosProyeccionGuardar.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    '        datosProyeccionGuardar.marcaSICY = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "MarcaSICY")
                    '        datosProyeccionGuardar.familiaProyeccion = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "FamiliaId")
                    '        datosProyeccionGuardar.clasificacionId = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "clasificacionId")
                    '        datosProyeccionGuardar.clasificacionTexto = bgvDatosProyeccion.GetRowCellValue(celda.RowHandle, "clasificacionTexto")
                    '        objBU.guardarEditarDatosProyeccionFamiliaAgente(datosProyeccionGuardar)
                    '    End If
                    'Next
                    ''For Each datosGuardar As Entidades.DatosCargarProyeccion In listCeldasModificadas
                    'objBU.guardarEditarDatosProyeccionFamiliaAgente(datosGuardar)
                    ''Next

                    Dim celdasM = From v In listCeldasModificadas Where If(v.paresProyectar = "", 0, v.paresProyectar) > 0

                    Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                    For Each item In celdasM
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("Semana", item.semana))
                        vNodo.Add(New XAttribute("Año", item.año))
                        vNodo.Add(New XAttribute("IdMarcaSay", item.marcaSAY))
                        vNodo.Add(New XAttribute("IdMarcaSicy", item.marcaSICY))
                        vNodo.Add(New XAttribute("IdColaboradorAgente", item.colaboradorAgenteId))
                        vNodo.Add(New XAttribute("IdClienteSay", item.idClienteSAY))
                        vNodo.Add(New XAttribute("IdClienteSicy", item.idClienteSICY))
                        vNodo.Add(New XAttribute("IdRuta", item.idRutaSAY))
                        vNodo.Add(New XAttribute("IdFamiliaProyeccion", item.familiaProyeccion))
                        vNodo.Add(New XAttribute("ParesProyectados", item.paresProyectar))
                        vNodo.Add(New XAttribute("UsuarioGuardandoId", item.usuarioId))
                        vNodo.Add(New XAttribute("ClasificacionId", item.clasificacionId))
                        vNodo.Add(New XAttribute("ClasificacionTexto", item.clasificacionTexto))
                        vXmlCeldasModificadas.Add(vNodo)
                    Next
                    objBU.guardarEditarDatosProyeccionFamiliaAgenteXml(vXmlCeldasModificadas.ToString())
                    objBU.ReplicarProyeccionVenta()

                    'End If
                    show_message("Exito", "Datos guardados correctamente")
                    btnMostrar_Click(sender, e)
                End If
                'ElseIf importando = True Then
                'Cursor = Cursors.WaitCursor
                'For x As Integer = 0 To bgvDatosProyeccion.DataRowCount - 1 Step 1
                '    For Each col As GridColumn In bgvDatosProyeccion.Columns
                '        If IsNumeric(col.FieldName.ToString) Then
                '            If IsDBNull(bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), col)) = False Then
                '                datosProyeccionGuardar = New Entidades.DatosCargarProyeccion
                '                datosProyeccionGuardar.semana = Integer.Parse(col.FieldName.ToString)
                '                datosProyeccionGuardar.año = nudAño.Value
                '                datosProyeccionGuardar.marcaSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "Id Marca")
                '                datosProyeccionGuardar.colaboradorAgenteId = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "Id Agente")
                '                datosProyeccionGuardar.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "SAY")
                '                datosProyeccionGuardar.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "SICY")
                '                datosProyeccionGuardar.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "RutaIdSAY")
                '                datosProyeccionGuardar.paresProyectar = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), col)
                '                datosProyeccionGuardar.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                '                datosProyeccionGuardar.marcaSICY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "MarcaSICY")
                '                datosProyeccionGuardar.familiaProyeccion = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "FamiliaId")
                '                datosProyeccionGuardar.clasificacionId = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "clasificacionId")
                '                datosProyeccionGuardar.clasificacionTexto = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "clasificacionTexto")
                '                objBU.guardarEditarDatosProyeccionFamiliaAgente(datosProyeccionGuardar)
                '            End If
                '        End If
                '    Next
                'Next

                '    For Each datosGuardar As Entidades.DatosCargarProyeccion In listCeldasModificadas
                '        objBU.guardarEditarDatosProyeccionFamiliaAgente(datosGuardar)
                '    Next
                '    show_message("Exito", "Datos guardados correctamente")
                '    btnMostrar_Click(sender, e)
            Else
                show_message("Advertencia", "No hay datos para guardar.")
            End If

        Catch ex As Exception
            show_message("Error", "Hubo un error al guardar, intente de nuevo.")
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub btnExportarExcelProyeccion_Click(sender As Object, e As EventArgs) Handles btnExportarExcelProyeccion.Click
        If bgvDatosProyeccion.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim lstListadoColumnas As New List(Of String)

            Try

                For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvDatosProyeccion.Columns
                    lstListadoColumnas.Add(Col.FieldName)
                Next

                nombreReporte = "\Proyeccion_ClienteMarcaFamiliaAgente_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvDatosProyeccion.GroupCount > 0 Then
                            bgvDatosProyeccion.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            For Each col As String In listColumnasMostrarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = True
                            Next
                            For Each col As String In lstMeses
                                If lstListadoColumnas.Contains(col) Then
                                    bgvDatosProyeccion.Columns(col).Visible = False
                                End If
                            Next
                            For Each col As String In listColumnasOcultarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = False
                            Next

                            bgvDatosProyeccion.OptionsView.ShowFooter = False

                            Dim exportOptions = New XlsxExportOptionsEx()
                            exportOptions.SheetName = "DATOS"

                            bgvDatosProyeccion.OptionsView.ShowBands = False
                            grdDatosProyeccion.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)


                            For Each col As String In listColumnasMostrarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = False
                            Next
                            For Each col As String In lstMeses
                                If lstListadoColumnas.Contains(col) Then
                                    bgvDatosProyeccion.Columns(col).Visible = True
                                End If
                            Next
                            For Each col As String In listColumnasOcultarExportacion
                                bgvDatosProyeccion.Columns(col).Visible = True
                            Next
                            bgvDatosProyeccion.OptionsView.ShowBands = True
                            bgvDatosProyeccion.Bands(0).Caption = ""
                            bgvDatosProyeccion.Bands(1).Caption = "Semanas de proyección"
                            bgvDatosProyeccion.OptionsView.ShowFooter = True

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()


                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")


                    End If



                End With
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        Else
            show_message("Aviso", "No hay datos para exportar.")
        End If
    End Sub



    Private Sub btnImportarExcelProyeccion_Click(sender As Object, e As EventArgs) Handles btnImportarExcelProyeccion.Click
        Cursor = Cursors.WaitCursor
        ImportarExcelv2()
        obtenerCeldasModificadasImportacion()
        Cursor = Cursors.Default
    End Sub

    Private Sub ImportarExcelv2()

        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumColumna As Integer = 0
        Dim totalRenglon As Integer = 0


        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString

            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As New DataTable
            Dim conn As OleDbConnection

            ' xSheet = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            conn = New OleDbConnection(
                          "Provider=Microsoft.ACE.OLEDB.12.0;" &
                          "data source=" & ExcelFile & "; " &
                         "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [Datos$]", conn)

                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")

                dt.Columns.Add("Total")


                NumRenglon = 0
                For Each row As DataRow In dt.Rows
                    NumColumna = 0
                    'dt.Rows.Add()
                    For columna As Integer = 0 To dt.Columns.Count - 2 Step 1
                        ' If row(columna).ToString() <> "" Then
                        If IsNumeric(row(columna)) Then
                            If CStr(row(columna)) <> "" Then
                                dt.Rows(NumRenglon)(columna) = Replace(Replace(row(columna), ",", ""), ".", "")
                            Else
                                dt.Rows(NumRenglon)(columna) = 0
                            End If
                        Else
                            dt.Rows(NumRenglon)(columna) = row(columna)
                        End If
                        'dt.Rows(NumRenglon - 1)(columna) = Replace(Replace(row(columna), ",", ""), ".", "")
                        'End If
                    Next
                    NumRenglon += 1
                Next
                For Each row As DataRow In dt.Rows
                    totalRenglon = 0
                    For Each col As DataColumn In dt.Columns
                        If IsNumeric(col.ColumnName) Then
                            totalRenglon += Integer.Parse(If(row(col).ToString = "", 0, row(col).ToString))
                        End If
                    Next
                    row("Total") = totalRenglon
                Next

                bgvDatosProyeccion.Columns.Clear()
                bgvDatosProyeccion.Bands.Clear()
                grdDatosProyeccion.DataSource = Nothing

                diseñoGrid(dt)

                grdDatosProyeccion.DataSource = dt
                importando = True

                nudAño.Value = Integer.Parse(dt.Rows(0)("Año").ToString)
                nudSemanaDe.Value = Integer.Parse(dt.Columns(15).ColumnName.ToString)
                nudSemanaA.Value = Integer.Parse(dt.Columns(dt.Columns.Count - 3).ColumnName.ToString)

                listCeldasModificadas.Clear()
            Catch ex As Exception
                If ex.Message = "The Microsoft Office Access database engine cannot open or write to the file ''. It is already opened exclusively by another user, or you need permission to view and write its data." Then
                    show_message("Error", "Cierra el documento Por Favor.")
                Else
                    show_message("Error", "Las cantidades de pares por semana deben ser números enteros. Favor de verificar.")
                End If
            Finally
                conn.Close()
            End Try
            MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")
        Else
            show_message("Advertencia", "No tienes modelos")
        End If
    End Sub
    Private Sub ImportarExcel()
        Dim datosExcel As New DataTable
        Dim NombreArchivo As String = ""
        Dim NumRenglon As Integer = 0
        Dim NumColumna As Integer = 0
        Dim dtDatosMostrar As New DataTable
        Dim NombreColumna As String = ""
        Dim totalRenglon As Integer = 0
        Dim listColumnasEnteros As New List(Of String)
        Try
            Dim hoja As String = "DATOS$"
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablasSinSeleccionarHoja(hoja, "", NombreArchivo)

            Cursor = Cursors.WaitCursor
            If IsNothing(datosExcel) = False Then
                If datosExcel.Rows.Count > 0 Then
                    For Each row As DataRow In datosExcel.Rows
                        If NumRenglon = 0 Then
                            For Each col As DataColumn In datosExcel.Columns
                                Select Case NumColumna
                                    Case 0
                                        NombreColumna = "Id Agente"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 1
                                        NombreColumna = "Agente"
                                    Case 2
                                        NombreColumna = "SAY"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 3
                                        NombreColumna = "SICY"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 4
                                        NombreColumna = "Cliente"
                                    Case 5
                                        NombreColumna = "Activo"
                                    Case 6
                                        NombreColumna = "Id Marca"
                                        listColumnasEnteros.Add(NombreColumna)
                                    Case 7
                                        NombreColumna = "MarcaSICY"
                                    Case 8
                                        NombreColumna = "Marca"
                                    Case 9
                                        NombreColumna = "FamiliaId"
                                    Case 10
                                        NombreColumna = "Familia"
                                    Case 11
                                        NombreColumna = "Año"
                                    Case 12
                                        NombreColumna = "RutaIdSAY"
                                    Case 13
                                        NombreColumna = "clasificacionId"
                                    Case 14
                                        NombreColumna = "clasificacionTexto"
                                    Case Else
                                        NombreColumna = col.ColumnName.ToString
                                        'NombreColumna = row(col).ToString()
                                        If (IsNumeric(NombreColumna)) Then
                                            listColumnasEnteros.Add(NombreColumna)
                                        End If
                                End Select
                                If NumColumna >= 0 Then
                                    dtDatosMostrar.Columns.Add(NombreColumna)
                                    If listColumnasEnteros.Contains(NombreColumna) Then
                                        dtDatosMostrar.Columns(NombreColumna).DataType = System.Type.GetType("System.Int32")
                                    End If
                                End If
                                NumColumna += 1
                            Next
                            dtDatosMostrar.Columns.Add("Total")
                            dtDatosMostrar.Columns("Total").DataType = System.Type.GetType("System.Int32")
                        ElseIf NumRenglon > 0 Then
                            dtDatosMostrar.Rows.Add()
                            For columna As Integer = 0 To dtDatosMostrar.Columns.Count - 2 Step 1
                                If row(columna).ToString() <> "" Then
                                    'If IsNumeric(columna) Then
                                    '    dtDatosMostrar.Rows(NumRenglon - 1)(columna) = Replace(Replace(row(columna), ",", ""), ".", "")
                                    'Else
                                    '    dtDatosMostrar.Rows(NumRenglon - 1)(columna) = row(columna)
                                    'End If
                                    dtDatosMostrar.Rows(NumRenglon - 1)(columna) = Replace(Replace(row(columna), ",", ""), ".", "")
                                End If
                            Next
                        End If
                        NumRenglon += 1
                    Next

                End If

                If dtDatosMostrar.Rows.Count > 0 Then


                    For Each row As DataRow In dtDatosMostrar.Rows
                        totalRenglon = 0
                        For Each col As DataColumn In dtDatosMostrar.Columns
                            If IsNumeric(col.ColumnName) Then
                                totalRenglon += Integer.Parse(If(row(col).ToString = "", 0, row(col).ToString))
                            End If
                        Next
                        row("Total") = totalRenglon
                    Next

                    bgvDatosProyeccion.Columns.Clear()
                    bgvDatosProyeccion.Bands.Clear()
                    grdDatosProyeccion.DataSource = Nothing

                    diseñoGrid(dtDatosMostrar)

                    grdDatosProyeccion.DataSource = dtDatosMostrar
                    importando = True

                    nudAño.Value = Integer.Parse(dtDatosMostrar.Rows(0)("Año").ToString)
                    nudSemanaDe.Value = Integer.Parse(dtDatosMostrar.Columns(15).ColumnName.ToString)
                    nudSemanaA.Value = Integer.Parse(dtDatosMostrar.Columns(dtDatosMostrar.Columns.Count - 3).ColumnName.ToString)

                    'cmboxAgente.SelectedValue = Integer.Parse(dtDatosMostrar.Rows(0)("Id Agente").ToString)
                    'For Each row As DataRow In dtAgentes.Rows
                    '    If row.Item("Parametro") = cmboxAgente.SelectedValue Then
                    '        cmboxAgente.Text = row.Item("Nombre")
                    '    End If
                    'Next
                    'cmboxMarca.SelectedValue = Integer.Parse(dtDatosMostrar.Rows(0)("Id Marca").ToString)

                    listCeldasModificadas.Clear()


                Else

                    show_message("Advertencia", "No hay datos para mostrar.")

                End If
            Else
                show_message("Advertencia", "El nombre del archivo a importar debe iniciar con: ""Proyección"".")
            End If
        Catch ex As Exception
            If ex.Message = "The Microsoft Office Access database engine cannot open or write to the file ''. It is already opened exclusively by another user, or you need permission to view and write its data." Then
                show_message("Error", "Cierra el documento Por Favor.")
            Else
                show_message("Error", "Las cantidades de pares por semana deben ser números enteros. Favor de verificar.")
            End If
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub obtenerCeldasModificadasImportacion()
        Dim datosProyeccionGuardar As New Entidades.DatosCargarProyeccion

        For x As Integer = 0 To bgvDatosProyeccion.DataRowCount - 1 Step 1
            For Each col As GridColumn In bgvDatosProyeccion.Columns
                If IsNumeric(col.FieldName.ToString) Then
                    If IsDBNull(bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), col)) = False Then
                        datosProyeccionGuardar = New Entidades.DatosCargarProyeccion
                        datosProyeccionGuardar.semana = Integer.Parse(col.FieldName.ToString)
                        datosProyeccionGuardar.año = nudAño.Value
                        datosProyeccionGuardar.marcaSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "Id Marca")
                        datosProyeccionGuardar.colaboradorAgenteId = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "Id Agente")
                        datosProyeccionGuardar.idClienteSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "SAY")
                        datosProyeccionGuardar.idClienteSICY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "SICY")
                        datosProyeccionGuardar.idRutaSAY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "RutaIdSAY")
                        datosProyeccionGuardar.paresProyectar = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), col)
                        datosProyeccionGuardar.usuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                        datosProyeccionGuardar.marcaSICY = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "MarcaSICY")
                        datosProyeccionGuardar.familiaProyeccion = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "FamiliaId")
                        datosProyeccionGuardar.clasificacionId = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "clasificacionId")
                        datosProyeccionGuardar.clasificacionTexto = bgvDatosProyeccion.GetRowCellValue(bgvDatosProyeccion.GetVisibleRowHandle(x), "clasificacionTexto")
                        listCeldasModificadas.Add(datosProyeccionGuardar)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_ProyeccionVentasMarcaFamilia_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_ProyeccionVentasMarcaFamilia_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEliminarProyeccion_Click(sender As Object, e As EventArgs) Handles btnEliminarProyeccion.Click
        Dim objBU As New Negocios.CargaProyeccionBU
        Dim msg_Conf As New Tools.ConfirmarForm
        Dim Año As Integer
        Dim SemanaInicio As Integer
        Dim SemanaFin As Integer


        Año = nudAño.Value
        SemanaInicio = nudSemanaDe.Value
        SemanaFin = nudSemanaA.Value
        Try
            If bgvDatosProyeccion.RowCount > 0 Then
                msg_Conf.mensaje = "La proyección de ventas del año " + Año.ToString + ", de la semana " + SemanaInicio.ToString + " a la " + SemanaFin.ToString + " será eliminada de forma permanente, No habrá forma de revertir los cambios realizados. ¿Está MUY seguro que desea continuar?"
                If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    show_message("Aviso", "Se realizará un respaldo de la información eliminada en formato de archivo de excel en su maquina")

                    Dim NombreArchivo As String = "Respaldo_Proyeccion_ClienteMarcaFamiliaAgente_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"

                    Dim SaveFileDialog As New SaveFileDialog
                    SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                    SaveFileDialog.FilterIndex = 2
                    SaveFileDialog.RestoreDirectory = True

                    SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"


                    bgvDatosProyeccion.OptionsPrint.AutoWidth = False
                    bgvDatosProyeccion.OptionsPrint.UsePrintStyles = False

                    Dim FileName As String = SaveFileDialog.FileName
                    DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                    bgvDatosProyeccion.ExportToXlsx(FileName)

                    objBU.EliminarProyeccionVenta(Año, SemanaInicio, SemanaFin)

                    ''System.Diagnostics.Process.Start(FileName)
                    show_message("Exito", "Se eliminó correctamente la proyección de ventas.")
                    btnMostrar_Click(sender, e)
                End If
            Else
                show_message("Advertencia", "No ha seleccionado un periodo de semanas.")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub btnExportarExcelProyeccionAnual_Click(sender As Object, e As EventArgs) Handles btnExportarExcelProyeccionAnual.Click
        Dim Obj As New Negocios.CargaProyeccionBU
        Dim dtAnual As New DataTable
        dtAnual = Obj.ConsultaProyeccionAnual(nudAño.Value)
        If dtAnual.Rows.Count > 0 Then
            grdAnual.DataSource = dtAnual
            Tools.Excel.ExportarExcel(grdVAnual, "ProyeccionAnual" & CStr(nudAño.Value))
        End If

    End Sub

    Private Sub exportOptions_CustomizeCell(e As CustomizeCellEventArgs)
        Throw New NotImplementedException()
    End Sub
End Class