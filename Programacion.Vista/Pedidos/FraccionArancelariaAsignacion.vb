Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section


Public Class FraccionArancelariaAsignacionForm


    Private Sub FraccionArancelariaAsignacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        lblFraccionArancelariaSeleccionada.Text = ""
        PoblarLista_CatalogoFraccionesArancelarias()

        gpbCatalogoFracciones.Width = (Me.Width / 100 * 57) - 10
        gpbAsignacion.Width = (Me.Width / 100 * 43) - 10
    End Sub

#Region "Acciones Group box"


    ' ''' <summary>
    ' ''' METODO EL CUAL REGRESA TODOS LOS CONTROLES AL TAMAÑO QUE SE TIENE CUANDO SE ABRE ESTA VENTANA
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub AjustarTodosLosPaneles_A_Normalidad()
    '    ''CATALOGO FRACIONES
    '    pnlFiltros.Height = 192
    '    gpbCatalogoFracciones.Dock = DockStyle.None
    '    gpbAsignacion.Visible = True
    '    gpbArticulos.Visible = True

    '    grdCatalogoFracciones.DisplayLayout.Bands(0).Columns("Activo").Hidden = False
    '    grdCatalogoFracciones.DisplayLayout.Bands(0).Columns("Modificación").Hidden = True
    '    grdCatalogoFracciones.DisplayLayout.Bands(0).Columns("Usuario").Hidden = True

    '    ''CATALOGO ASIGNACION
    '    gpbCatalogoFracciones.Visible = True
    '    gpbArticulos.Visible = True

    '    With grdAsignacion
    '        .DisplayLayout.Bands(0).Columns("Fracción Arancelaria").Hidden = True
    '        .DisplayLayout.Bands(0).Columns("Modificación").Hidden = True
    '        .DisplayLayout.Bands(0).Columns("Usuario").Hidden = True
    '    End With

    '    btnAbajo.PerformClick()

    'End Sub

    ''' <summary>
    ''' EVENTO DOBLE CLICK EN EL GROUPBOX GPBARTICULOS EL CUAL DEPENDIENDO DEL TAMAÑO CON EL QUE CUENTA EN EL MOMENTO EL GRUUPBOX, AGRANDA O REGRESA
    ''' A SU ESTADO ORIGINAL A ESTE CONTROL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gpbArticulos_DoubleClick(sender As Object, e As EventArgs) Handles gpbArticulos.DoubleClick
        If pnlFiltros.Height = 222 Then
            pnlFiltros.Height = 0
        Else
            pnlFiltros.Height = 192
        End If
    End Sub

    ''' <summary>
    ''' EVENTO DOBLE CLICK EN EL GROUPBOX GPBCATALOGOFRACCIONES EL CUAL AGRANDA O REGRESA A SU ESTADO ORIGINAL A ESTE CONTROL, DEPENDIENDO DEL TAMAÑO CON EL QUE
    ''' ESTA CONFIGURADO EL CONTROL AL MOMENTO DE RECIBIR EL EVENTO
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gpbCatalogoFracciones_DoubleClick(sender As Object, e As EventArgs) Handles gpbCatalogoFracciones.DoubleClick

        If gpbCatalogoFracciones.Dock = DockStyle.Fill Then
            gpbCatalogoFracciones.Dock = DockStyle.Left
            gpbCatalogoFracciones.Width = (Me.Width / 100 * 57) - 10
            gpbAsignacion.Width = (Me.Width / 100 * 43) - 10
            gpbAsignacion.Visible = True
            gpbArticulos.Visible = True
            pnlFiltros.Dock = DockStyle.Top
        Else
            gpbCatalogoFracciones.Dock = DockStyle.Fill
            pnlFiltros.Dock = DockStyle.Fill
            gpbAsignacion.Visible = False
            gpbArticulos.Visible = False

        End If

    End Sub

    ''' <summary>
    ''' EVENTO DOBLE CLICK EN EL GROUPBOX GPBASIGNACION EL CUAL AGRANDA O REGRESA A SU TAMÁÑO ORIGINAL A ESTE CONTROL, ESTO DEPENDIENDO DEL TAMAÑO
    ''' ASIGNADO AL CONTROL AL MOMENTO DE RECIBIRL EL DOBLECLICK
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub gpbAsignacion_DoubleClick(sender As Object, e As EventArgs) Handles gpbAsignacion.DoubleClick
        If gpbAsignacion.Dock = DockStyle.Fill Then
            gpbAsignacion.Dock = DockStyle.Right
            gpbCatalogoFracciones.Width = (Me.Width / 100 * 57) - 10
            gpbAsignacion.Width = (Me.Width / 100 * 43) - 10
            gpbCatalogoFracciones.Visible = True
            gpbArticulos.Visible = True
            pnlFiltros.Dock = DockStyle.Top
        Else
            gpbAsignacion.Dock = DockStyle.Fill
            pnlFiltros.Dock = DockStyle.Fill
            gpbCatalogoFracciones.Visible = False
            gpbArticulos.Visible = False

        End If
    End Sub

#End Region


#Region "Acciones Grids"

#Region "Poblar_Listas_Grids"

    ''' <summary>
    ''' RECUPERA LA LISTA DE LAS FRACCIONES ARANCELARIAS(ACTIVAS O INACTIVAS Y LA ASIGNA AL GRID GRDCATALOGOFRACCIOES
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PoblarLista_CatalogoFraccionesArancelarias()
        Me.Cursor = Cursors.WaitCursor

        Dim objBU As New Negocios.FraccionesArtancelariasBU
        Dim dtTaba As New DataTable

        dtTaba = objBU.Lista_Catalogo_FraccionesArancelarias(rdoActivoFraccionesSi.Checked)

        If dtTaba.Rows.Count > 0 Then
            grdCatalogoFracciones.DataSource = dtTaba

            If chkVerTodasLasFracciones.Checked = True Then
                PoblarLista_Asignacion(1, rdoActivoFraccionesSi.Checked)

            Else
                PoblarLista_Asignacion(3, rdoActivoFraccionesSi.Checked)

            End If
        Else
            Mensajes_Y_Alertas("INFORMACION", "No se encontraron registros.")
            grdCatalogoFracciones.DataSource = dtTaba
            PoblarLista_Asignacion(3, rdoActivoFraccionesSi.Checked)

        End If

        lblTotalSeleccionados.Text = "0"

        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' RECUPERA LA INFORMACION DE LOS DETALLES DE LAS FRACCIONE ARANCELARIAS SELECCIONADAS
    ''' </summary>
    ''' <param name="bandera">BARIABLE DEL TIPO INTEGER, 1 = CONSULTAR TODAS LAS FRACCIONES ARANCELARIAS (ACTIVAS O INACTIVAS), 2 = CONSULTAR SOLO UNA FRACCION ARANCELARIA</param>
    ''' <remarks></remarks>
    Private Sub PoblarLista_Asignacion(ByVal bandera As Integer, ByVal Activo As Boolean)
        Me.Cursor = Cursors.WaitCursor

        Dim objBU As New Negocios.FraccionesArtancelariasBU
        Dim dtAsignacionesFracciones As New DataTable
        Dim idsFracciones As String = String.Empty

        If bandera = 1 Then
            For Each row As UltraGridRow In grdCatalogoFracciones.Rows
                If idsFracciones = String.Empty Then
                    idsFracciones = row.Cells("Id").Text
                Else
                    idsFracciones += ", " + row.Cells("Id").Text
                End If
            Next
            dtAsignacionesFracciones = objBU.Lista_FraccionesArancelarias_Detalles(idsFracciones)
        ElseIf bandera = 2 Then
            dtAsignacionesFracciones = objBU.Lista_FraccionesArancelarias_Detalles(grdCatalogoFracciones.ActiveRow.Cells("Id").Value)
        Else
            dtAsignacionesFracciones = objBU.Lista_FraccionesArancelarias_Detalles(0)
        End If

        grdAsignacion.DataSource = dtAsignacionesFracciones

        PoblarLista_Articulos()

        lblTotalSeleccionados.Text = "0"

        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' RECUPERA LA INFORMACIÓN DE LOS ARTICULOS QUE COINCIDAN CON LA CONFIGURACION DE CADA UNO DE LOS DETALLES MOSTRADOS EN LL GRID GRDASIGNACIÓN Y LO ASIGNA AL GRID 
    ''' GRDARTICULOS
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PoblarLista_Articulos()
        Me.Cursor = Cursors.WaitCursor

        Dim objBU As New Negocios.FraccionesArtancelariasBU
        Dim dtArticulos As New DataTable
        Dim hsFraccionDetalle As New HashSet(Of Integer)

        If grdAsignacion.Rows.Count > 0 Then
            For Each row As UltraGridRow In grdAsignacion.Rows
                hsFraccionDetalle.Add(row.Cells("Id_Fraccion").Value)
            Next
        Else
            hsFraccionDetalle.Add(0)
        End If

        dtArticulos = objBU.Lista_Articulos(hsFraccionDetalle)
        dtArticulos = Depurar_Tabla_Articulos(dtArticulos)
        grdArticulos.DataSource = dtArticulos

        Me.Cursor = Cursors.Default
    End Sub

    ''' <summary>
    ''' RECORRE UN DATATABLE CON TODOS LOS ARTICULOS QUE CONCUERDAN CON LA CONFIGURACION DE LOS DETALLES DE CIERTAS FRACCIONES ARANCELARIAS, PARA LA CONSULTA DE ESTOS
    ''' ARTICULOS NO SE TOMA EN CUENTA LA CORRIDA ASI QUE EN ESTE METODO RECORRE REGISTRO POR REGISTRO EL GRID ASIGNACIONES BUSCANDO QUE FILAS DE LA TABLA DE ARTICULOS 
    ''' ENTRAN EN LA CONFIGURACION DE EL DETALLE TOMANDO EN CUENTA LA TALLA DEL DETALLE, AGREGA LA TALLA A LAS FILAS QUE CUMPLEN CON LA COMBINACION DE LA CONFIGURACION
    ''' DE LA FRACCION ARANCELARIA Y AL FINAL DEPURA LA TABLA ELIMINANDO TODOS LOS ARTICULOS QUE NO CUMPLIERON CON LA CONFIGURACION COMPLETA DE LOS DETALLES DE LAS
    ''' FRACCIONES ARANCELARIAS
    ''' </summary>
    ''' <param name="dtArticulos">DATATABLE CON LOS ARTICULOS QUE CUMPLEN CON LA CONDICION DE FAMILIA, FORRO, CORTE, TIPO Y SUELA DE LAS FILAS MOSTRADAS EN 
    ''' EL GRID GRDASIGNACION</param>
    ''' <returns>DATATABLE CON LA INFORMACIÓN DE LA TABLA DTARTICULOS DEPURADA</returns>
    ''' <remarks></remarks>
    Private Function Depurar_Tabla_Articulos(ByVal dtArticulos As DataTable) As DataTable
        Dim dtTallasFinal As New DataTable

        For Each row As UltraGridRow In grdAsignacion.Rows

            For Each fila As DataRow In dtArticulos.Rows
                Dim tallas_Corrida As String = fila("Tallas_c")

                If row.Cells("Código").Value = fila.Item("Código") And row.Cells("Id_Familia").Value = fila.Item("Id_Familia") And
                     row.Cells("Id_Corte").Value = fila.Item("Id_Corte") And row.Cells("Id_Forro").Value = fila.Item("Id_Forro") And
                      row.Cells("Id_Suela").Value = fila.Item("Id_Suela") And row.Cells("Id_Tipo").Value = fila.Item("Id_Tipo") And
                      tallas_Corrida.Contains(row.Cells("Talla").Text) = True Then

                    If fila.Item("Tallas") = "" Then
                        fila.Item("Tallas") = row.Cells("Talla").Text
                    Else
                        fila.Item("Tallas") += ", " + row.Cells("Talla").Text
                    End If
                End If
            Next
        Next

        For Each col As DataColumn In dtArticulos.Columns
            dtTallasFinal.Columns.Add(col.ColumnName)
        Next

        For Each row As DataRow In dtArticulos.Rows
            If row.Item("Tallas") <> "" Then
                dtTallasFinal.ImportRow(row)
            End If
        Next

        Return dtTallasFinal
    End Function

    Private Sub rdoActivoFraccionesSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivoFraccionesSi.CheckedChanged
        PoblarLista_CatalogoFraccionesArancelarias()

        lblFraccionArancelariaSeleccionada.Text = ""
    End Sub

    Private Sub chkVerTodasLasFracciones_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkVerTodasLasFracciones.CheckedChanged
        PoblarLista_CatalogoFraccionesArancelarias()
        lblFraccionArancelariaSeleccionada.Text = ""

    End Sub


#End Region

#Region "Diseño Grids"

    Private Sub grdCatalogoFracciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCatalogoFracciones.InitializeLayout
        Diseno_Agrupacion_Headers(grdCatalogoFracciones, e)
        Diseno_Grid(grdCatalogoFracciones)

        With grdCatalogoFracciones
            .DisplayLayout.Bands(0).Columns("Modificación").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Código").Width = 150
            .DisplayLayout.Bands(0).Columns("Fracción Arancelaria").Width = 700

            .DisplayLayout.Bands(0).Columns("Activo").Width = 50
            .DisplayLayout.Bands(0).Columns("Modificación").Width = 100
            .DisplayLayout.Bands(0).Columns("Usuario").Width = 80


            '.DisplayLayout.Bands(0).Columns("Activo").Hidden = True
            '.DisplayLayout.Bands(0).Columns("Modificación").Hidden = True
            '.DisplayLayout.Bands(0).Columns("Usuario").Hidden = True

        End With

    End Sub

    Private Sub grdAsignacion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAsignacion.InitializeLayout
        Diseno_Agrupacion_Headers(grdAsignacion, e)
        Diseno_Grid(grdAsignacion)

        With grdAsignacion
            .DisplayLayout.Bands(0).Columns("Modificación").Style = ColumnStyle.DateTime
            .DisplayLayout.Bands(0).Columns("Modificación").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .DisplayLayout.Bands(0).Columns("Id").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Fraccion").Hidden = True
            .DisplayLayout.Bands(0).Columns("Código").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Familia").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Forro").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Corte").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Tipo").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Suela").Hidden = True

            '.DisplayLayout.Bands(0).Columns("Fracción Arancelaria").Hidden = True
            '.DisplayLayout.Bands(0).Columns("Modificación").Hidden = True
            '.DisplayLayout.Bands(0).Columns("Usuario").Hidden = True


            .DisplayLayout.Bands(0).Columns(" ").Width = 30
            .DisplayLayout.Bands(0).Columns("Familia").Width = 65
            .DisplayLayout.Bands(0).Columns("Forro").Width = 80
            .DisplayLayout.Bands(0).Columns("Corte").Width = 80
            .DisplayLayout.Bands(0).Columns("Tipo").Width = 80
            .DisplayLayout.Bands(0).Columns("Suela").Width = 70
            .DisplayLayout.Bands(0).Columns("Modificación").Width = 100
            .DisplayLayout.Bands(0).Columns("Talla").Width = 65
            .DisplayLayout.Bands(0).Columns("Fracción Arancelaria").Width = 370

        End With

        'AjustarTodosLosPaneles_A_Normalidad()

    End Sub

    Private Sub grdArticulos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdArticulos.InitializeLayout
        Diseno_Agrupacion_Headers(grdArticulos, e)
        Diseno_Grid(grdArticulos)

        With grdArticulos

            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            ''OCULTAR COLUMNAS
            .DisplayLayout.Bands(0).Columns("frar_fraccionarancelariaid").Hidden = True
            .DisplayLayout.Bands(0).Columns("Tallas_c").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Familia").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Corte").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Forro").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Suela").Hidden = True
            .DisplayLayout.Bands(0).Columns("Id_Tipo").Hidden = True

            ''RENOMBRAR COLUMNA
            .DisplayLayout.Bands(0).Columns("Código").Header.Caption = "Código FA"

            ' ''CAMBIAR TAMAÑOS
            '.DisplayLayout.Bands(0).Columns("Marca").Width = 65
            '.DisplayLayout.Bands(0).Columns("Corrida").Width = 60
            '.DisplayLayout.Bands(0).Columns("Modelo").Width = 60
            '.DisplayLayout.Bands(0).Columns("Familia").Width = 70
            '.DisplayLayout.Bands(0).Columns("Suela").Width = 50
            '.DisplayLayout.Bands(0).Columns("Tipo").Width = 70

        End With

    End Sub

    ''' <summary>
    ''' METODO PARA DARLE FORMATO GENERAL A LOS GRIDS DE LA PANTALLA
    ''' </summary>
    ''' <param name="Grid">ULTRAGRID AL CUAL SE LE DARA FORMATO</param>
    ''' <remarks></remarks>
    Private Sub Diseno_Grid(ByVal Grid As UltraGrid)
        With Grid

            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            .DisplayLayout.Override.FilterOperandDropDownItems = FilterOperandDropDownItems.All
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 30
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    ''' <summary>
    ''' LE CAMBIA LOS TITULOS DE INGRLES A ESPAÑOL A LA PROPIEDAD DEL GRID PARA AGRUPAR POR COLUMNAS
    ''' </summary>
    ''' <param name="Grid"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Diseno_Agrupacion_Headers(ByVal Grid As UltraGrid, e As InitializeLayoutEventArgs)
        Grid.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
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

#End Region


    Private Sub grdCatalogoFracciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCatalogoFracciones.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub grdAsignacion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAsignacion.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub grdArticulos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdArticulos.BeforeRowsDeleted
        e.Cancel = True
    End Sub


    Private Sub grdCatalogoFracciones_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdCatalogoFracciones.ClickCell
        If chkVerTodasLasFracciones.Checked = False Then
            If grdCatalogoFracciones.ActiveRow.IsDataRow Then
                chkChecarTodasLasAsignaciones.Checked = False
                lblFraccionArancelariaSeleccionada.Text = grdCatalogoFracciones.ActiveRow.Cells("Código").Text + " - " + grdCatalogoFracciones.ActiveRow.Cells("Fracción Arancelaria").Text
                PoblarLista_Asignacion(2, rdoActivoFraccionesSi.Checked)
            End If
        End If
    End Sub


    Private Sub grdAsignacion_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdAsignacion.ClickCell
        If grdAsignacion.ActiveRow.IsDataRow Then
            If grdAsignacion.ActiveRow.Cells(" ").Value Then
                grdAsignacion.ActiveRow.Cells(" ").Value = False
            Else
                grdAsignacion.ActiveRow.Cells(" ").Value = True
            End If
        End If

        contarRegistrosSeleccionado_ListaAsignacion()
    End Sub


#End Region

#Region "Botones"

    Private Sub gpbArticulos_Click(sender As Object, e As EventArgs) Handles gpbArticulos.Click
        pnlFiltros.Height = 0
    End Sub

    Private Sub chkChecarTodasLasAsignaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chkChecarTodasLasAsignaciones.CheckedChanged
        For Each row As UltraGridRow In grdAsignacion.Rows
            row.Cells(" ").Value = chkChecarTodasLasAsignaciones.Checked
        Next
        If chkChecarTodasLasAsignaciones.Checked Then
            lblTotalSeleccionados.Text = grdAsignacion.Rows.Count.ToString
        Else
            lblTotalSeleccionados.Text = "0"
        End If

    End Sub

    ''' <summary>
    ''' METODO PARA CONTAR LOS REGISTROS SELECCIONADOS EN EL GRID GRDASIGNACION
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub contarRegistrosSeleccionado_ListaAsignacion()
        Dim i As Integer = 0
        For Each row As UltraGridRow In grdAsignacion.Rows
            If row.Cells(" ").Value Then
                i += 1
            End If
        Next

        lblTotalSeleccionados.Text = i.ToString
    End Sub

    Private Sub btnAbajo_Click_1(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Height = 192

        pnlFiltros.Dock = DockStyle.Top
        gpbAsignacion.Dock = DockStyle.Right
        gpbCatalogoFracciones.Dock = DockStyle.Left

        gpbArticulos.Visible = True
        gpbAsignacion.Visible = True
        gpbCatalogoFracciones.Visible = True
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Height = 0

        pnlFiltros.Dock = DockStyle.Top
        gpbAsignacion.Dock = DockStyle.Right
        gpbCatalogoFracciones.Dock = DockStyle.Left

        gpbArticulos.Visible = True
        gpbAsignacion.Visible = True
        gpbCatalogoFracciones.Visible = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click
        Dim objAltaDetallesFraccion As New AltasAsignacionFraccionArancelariaForm
        objAltaDetallesFraccion.StartPosition = FormStartPosition.CenterScreen

        If grdCatalogoFracciones.Selected.Rows.Count > 0 And chkVerTodasLasFracciones.Checked = False Then
            objAltaDetallesFraccion.IdFraccion = grdCatalogoFracciones.Selected.Rows(0).Cells("Id").Text
        Else
            objAltaDetallesFraccion.IdFraccion = 0
        End If

        objAltaDetallesFraccion.ShowDialog()

        PoblarLista_CatalogoFraccionesArancelarias()

        lblFraccionArancelariaSeleccionada.Text = ""
    End Sub

#End Region


    ''' <summary>
    ''' METODO QUE MANDA A LLAMAR UN FORMULARIO DE MENSAJE DE TOOLS, SEGUN EL TIPO DE MENSAJE QUE SE HAYA ENVIADO COMO PARAMETRO
    ''' </summary>
    ''' <param name="Tipo">CADENA CON EL NOMBRE DEL TIPO DE MENSAJE A MOSTRAR "ADVERTENCIA" PARA EL FORMULARIO ADVERTENCIAFORM DE TOOLS,
    ''' "EXITO" PARA EL FORMULARIO EXITOFORM DE TOOLS, "ERROR" PARA EL FORMULARIO ERRORESFORM DE TOOLS, "INFORMACION" PARA EL FORMULARIO
    ''' "AVISOFORM" DE TOOLS, Y "CONFIRMACION" PARA EL FORMULARIO "CONFIRMARFORM" </param>
    ''' <param name="Mensaje">MENSAJE QUE SE MOSTRARA EN EL FORMULARIO SELECCIONADO</param>
    ''' <remarks></remarks>
    Private Function Mensajes_Y_Alertas(ByVal Tipo As String, ByVal Mensaje As String)
        If Tipo = "ADVERTENCIA" Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = Mensaje
            objAdvertencia.ShowDialog()
        ElseIf Tipo = "EXITO" Then
            Dim objExito As New Tools.ExitoForm
            objExito.StartPosition = FormStartPosition.CenterScreen
            objExito.mensaje = Mensaje
            objExito.ShowDialog()
        ElseIf Tipo = "ERROR" Then
            Dim objErrores As New Tools.ErroresForm
            objErrores.StartPosition = FormStartPosition.CenterScreen
            objErrores.mensaje = Mensaje
            objErrores.ShowDialog()
        ElseIf Tipo = "INFORMACION" Then
            Dim objInformacion As New Tools.AvisoForm
            objInformacion.StartPosition = FormStartPosition.CenterScreen
            objInformacion.mensaje = Mensaje
            objInformacion.ShowDialog()
        ElseIf Tipo = "CONFIRMACION" Then
            Dim objConfirmacion As New Tools.ConfirmarForm
            objConfirmacion.StartPosition = FormStartPosition.CenterScreen
            objConfirmacion.mensaje = Mensaje
            If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        cmsExportarExel.Show(btnExportar, 0, btnExportar.Height)

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lblTotalSeleccionados.Text <> "0" Then
            If Mensajes_Y_Alertas("CONFIRMACION", "¿Está seguro de eliminar las características seleccionadas de la fracción arancelaria a la que pertenecen?") Then
                Try
                    Dim objBU As New Negocios.FraccionesArtancelariasBU
                    Dim Ids_FraccionesDetalles As String

                    For Each row As UltraGridRow In grdAsignacion.Rows
                        If row.Cells(" ").Value = True Then
                            If Ids_FraccionesDetalles = "" Then
                                Ids_FraccionesDetalles = row.Cells("Id").Text
                            Else
                                Ids_FraccionesDetalles += ", " + row.Cells("Id").Text
                            End If
                        End If
                    Next

                    objBU.Eliminar_FraccionesDetalles(Ids_FraccionesDetalles)

                    Mensajes_Y_Alertas("EXITO", "Registros eliminados con éxito.")

                    If chkVerTodasLasFracciones.Checked = True Then
                        PoblarLista_CatalogoFraccionesArancelarias()
                    Else
                        PoblarLista_Asignacion(2, chkVerTodasLasFracciones.Checked)
                    End If

                Catch ex As Exception
                    Mensajes_Y_Alertas("ERROR", "Ocurrio un error inesperado. Error: " + ex.Message)
                End Try

            End If
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "Debe seleccionar al menos un registro del listado ASIGNACIÓN.")

        End If
    End Sub

    ''' <summary>
    ''' METODO PARA EXPORTAR UN ULTRAGRID A EXCEL
    ''' </summary>
    ''' <param name="grid"></param>
    ''' <remarks></remarks>
    Public Sub ExportarExcel(ByVal grid As UltraGrid)

        If grid.Rows.Count = 0 Then
            Mensajes_Y_Alertas("ADVERTENCIA", "No existen registros por exportar en el listado seleccionado.")

        Else
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xlsx"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    'Carpeta = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + +".xlsx"
                    Me.Cursor = Cursors.WaitCursor
                    ultExportGrid.Export(grid, fileName)

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

        End If


    End Sub

    Private Sub CatalogoDeFraccionesArancelariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CatalogoDeFraccionesArancelariasToolStripMenuItem.Click
        ExportarExcel(grdCatalogoFracciones)
    End Sub

    Private Sub AsignaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónToolStripMenuItem.Click
        ExportarExcel(grdAsignacion)
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem.Click
        ExportarExcel(grdArticulos)
    End Sub

    Private Sub FraccionArancelariaAsignacionForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        gpbCatalogoFracciones.Width = (Me.Width / 100 * 57) - 10
        gpbAsignacion.Width = (Me.Width / 100 * 43) - 10
    End Sub
End Class