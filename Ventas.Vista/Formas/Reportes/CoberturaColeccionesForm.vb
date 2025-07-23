Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.BandedGrid

Public Class CoberturaColeccionesForm

    Dim listInicial As New List(Of String)
    Dim filtro_Agente As String = String.Empty
    Dim filtro_Marca As String = String.Empty
    Dim filtro_Cliente As String = String.Empty
    Dim filtro_Coleccion As String = String.Empty
    Dim filtro_FechaInicio As String = String.Empty
    Dim filtro_FechaFin As String = String.Empty
    Dim tipoReporte As Integer = 0
    Dim perfilUsuario As Integer = 0
    Dim ListaColumnasGrid As New List(Of String)
    Dim objBU As New Negocios.CoberturaColeccionesBU
    Dim DTEncabezadoCobertura As DataTable

    Private Sub CoberturaColeccionesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dtResultadoPerfil As New DataTable
        Dim objBU As New Negocios.EstadisticaVentasFamiliaBU
        Dim objResumenVentasBU As New Negocios.ResumenVentasSemanalBU

        'dtpFechaEntregaDel.MinDate = Date.Parse("01/01/2012")
        'dtpFechaEntregaAl.MinDate = Date.Parse("01/01/2012")
        'dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        ''dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        'dtpFechaEntregaAl.Value = New Negocios.ResumenVentasSemanalBU().ConsultarFechaFinEstadVentas_Semanal()

        dtpFechaEntregaDel.Value = objResumenVentasBU.ConsultarFechaInicioEstadVentas_Semanal()
        dtpFechaEntregaAl.Value = objResumenVentasBU.ConsultarFechaFinEstadVentas_Semanal()


        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        grdAgentes.DataSource = listInicial
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdColecciones.DataSource = listInicial

        dtResultadoPerfil = objBU.reporteEstadisticaFamliasObtenerPerfilUsuario(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoPerfil.Rows.Count > 0 Then
            perfilUsuario = dtResultadoPerfil.Rows(0).Item("IdPerfil")
            If dtResultadoPerfil.Rows(0).Item("IdPerfil") = 44 Then
                grpboxagente.Enabled = False
                Dim objeBU As New Negocios.EstadisticoPedidosBU
                Dim Tabla_ListadoParametros As New DataTable

                Tabla_ListadoParametros = objeBU.ListadoParametrosReportes(8, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
                grdAgentes.DataSource = Tabla_ListadoParametros

                With grdAgentes
                    .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(1).Hidden = True
                End With

                Exit Sub
            End If
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub dtpFechaEntregaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEntregaDel.ValueChanged
        If dtpFechaEntregaAl.MinDate > "31/12/" + dtpFechaEntregaDel.Value.Year.ToString() Then
            dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
            dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
        Else
            dtpFechaEntregaAl.MaxDate = "31/12/" + dtpFechaEntregaDel.Value.Year.ToString()
            dtpFechaEntregaAl.MinDate = dtpFechaEntregaDel.Value
        End If
    End Sub

    Private Sub btnLimpiarFiltroAgente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroAgente.Click
        grdAgentes.DataSource = listInicial
    End Sub

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
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

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarcas.DataSource = listInicial
    End Sub

    Private Sub btnMarcas_Click(sender As Object, e As EventArgs) Handles btnMarcas.Click
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

    Private Sub btnLimpiarColecciones_Click(sender As Object, e As EventArgs) Handles btnLimpiarColecciones.Click
        grdColecciones.DataSource = listInicial
    End Sub

    Private Sub btnColecciones_Click(sender As Object, e As EventArgs) Handles btnColecciones.Click
        Dim listado As New ListadoParametrosReportesForm
        If perfilUsuario <> 44 Then
            listado.tipo_busqueda = 5
        Else
            listado.tipo_busqueda = 6
        End If

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdColecciones.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColecciones.DataSource = listado.listParametros
        With grdColecciones
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            '.DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colecciones"
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = listInicial
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportesForm
        If perfilUsuario <> 44 And perfilUsuario <> 74 Then
            listado.tipo_busqueda = 2
        Else
            listado.tipo_busqueda = 4
        End If


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        bgvReporte.Bands.Clear()
        bgvReporte.Columns.Clear()
        If perfilUsuario <> 44 Then
            grdAgentes.DataSource = listInicial
        End If
        grdMarcas.DataSource = listInicial
        grdClientes.DataSource = listInicial
        grdColecciones.DataSource = listInicial
        dtpFechaEntregaAl.Value = Date.Parse("31/12/" + Date.Now.Year.ToString())
        dtpFechaEntregaDel.Value = Date.Parse("01/01/" + Date.Now.Year.ToString())
        lblFechaUltimaActualización.Text = "-"        
        btnAbajo_Click(sender, e)
    End Sub

  
    Private Sub grdAgentes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAgentes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdColecciones_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdColecciones.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdMarcas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdMarcas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente de Ventas"
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

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdColecciones_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColecciones.InitializeLayout
        grid_diseño(grdColecciones)
        grdColecciones.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colecciones"
    End Sub

    Private Sub grdMarcas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarcas.InitializeLayout
        grid_diseño(grdMarcas)
        grdMarcas.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Marcas"
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReporte.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            Dim objBU As New Negocios.EstadisticoPedidosBU
            Dim exportOptions = New XlsxExportOptionsEx()
            Try
                nombreReporte = "\CoberturaColecciones_"
                nombreReporteParaExportacion = "COBERTURA DE COLECCIONES"
                exportOptions.SheetName = "CoberturaColecciones"

               
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvReporte.GroupCount > 0 Then
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else

                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

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

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Dim PorcentajeCliente As String = ""
        Dim FilaAnterior As Integer = 0
        Dim PorcentajeCoberturaCliente As Integer = 0
        Dim PorcentajeCoberturaActual As Integer = 0


        Try
            If e.RowHandle < 3 Then
                If DTEncabezadoCobertura.AsEnumerable().Where(Function(x) x.Item("ColumnaOrigen") = e.Value.ToString).Count > 0 Then
                    Dim NombreColumna = DTEncabezadoCobertura.AsEnumerable().FirstOrDefault(Function(x) x.Item("ColumnaOrigen") = e.Value)
                    e.Value = NombreColumna.Item("NombreColumna")
                End If
            End If

            If IsDBNull(e.Value) = False Then
                If IsNumeric(e.Value) = False Then
                    If e.Value = "COLECCIONES NUEVAS" Then
                        e.Formatting.BackColor = Color.FromArgb(198, 224, 180)
                    ElseIf e.Value = "COLECCIONES VIGENTES" Then
                        e.Formatting.BackColor = Color.FromArgb(255, 242, 204)
                    End If
                End If


            End If



            If bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE") = "TOTAL GENERAL" Then
                e.Formatting.BackColor = Color.FromArgb(221, 235, 247)
                e.Formatting.Font.Bold = True
            Else
                'Poner Ceros a los espacios vacíos
                If IsDBNull(bgvReporte.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) = True Then
                    If e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "CIUDAD" AndAlso e.ColumnFieldName <> "EDO" AndAlso e.ColumnFieldName <> "CLASIF" AndAlso e.ColumnFieldName <> "TDAS" Then

                        PorcentajeCliente = bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE")

                        If PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = True OrElse PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True OrElse PorcentajeCliente.Contains("CLASIFICACIÓN DE LA COLECCIÓN") = True OrElse PorcentajeCliente.Contains("CLIENTES EN COBERTURA") = True Then
                            If e.ColumnFieldName.Contains("TOTAL") = False And e.ColumnFieldName.Contains("PORC") = False And e.ColumnFieldName.Contains("CTE") = False Then
                                e.Value = 0
                            End If
                            'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        Else
                            e.Formatting.BackColor = Color.Pink
                            e.Formatting.Font.Color = Color.Red

                            If e.ColumnFieldName.Contains("CTE") = True Then
                                e.Value = "0.00%"
                            Else
                                e.Value = "0"
                            End If

                            'e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        End If
                    End If
                Else
                    If e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "CIUDAD" AndAlso e.ColumnFieldName <> "EDO" AndAlso e.ColumnFieldName <> "CLASIF" AndAlso e.ColumnFieldName <> "TDAS" Then
                        If IsNumeric(e.Value) = True Then
                            PorcentajeCliente = bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE")

                            If PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = False AndAlso PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = False AndAlso PorcentajeCliente.Contains("CLASIFICACIÓN DE LA COLECCIÓN") = False Then
                                If e.Value = 0 Then
                                    e.Formatting.BackColor = Color.Pink
                                    e.Formatting.Font.Color = Color.Red
                                End If
                            End If

                        End If

                    End If
                End If

            End If


            If e.ColumnFieldName <> "CLIENTE" AndAlso e.ColumnFieldName <> "RUTA" AndAlso e.ColumnFieldName.Contains("CTE") = False Then

                If IsNumeric(e.Value) = True Then

                    e.Value = CDbl(e.Value).ToString("N0")
                End If

                PorcentajeCliente = bgvReporte.GetRowCellValue(e.RowHandle, "CLIENTE")

                If (PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = True Or PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True) And IsDBNull(e.Value) = False Then
                    If e.Value.ToString.Contains("%") = False Then
                        e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                    End If

                End If

                If e.ColumnFieldName.Contains("PORC") = True AndAlso IsDBNull(e.Value) = False Then
                    If e.Value.ToString.Contains("%") = False Then
                        e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                    End If

                End If

                If PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True AndAlso e.ColumnFieldName.Contains("TOTAL") = False AndAlso e.ColumnFieldName.Contains("PORC") = False Then
                    FilaAnterior = e.RowHandle - 1

                    If IsDBNull(e.Value) = True Then
                        PorcentajeCoberturaActual = 0
                    Else
                        If e.Value.ToString.Contains("%") = True Then
                            PorcentajeCoberturaActual = e.Value.ToString.Replace("%", "").Trim
                        Else
                            PorcentajeCoberturaActual = e.Value
                        End If

                    End If

                    If IsDBNull(bgvReporte.GetRowCellValue(FilaAnterior, e.ColumnFieldName)) = True Then
                        PorcentajeCoberturaCliente = 0
                    Else
                        PorcentajeCoberturaCliente = bgvReporte.GetRowCellValue(FilaAnterior, e.ColumnFieldName)
                    End If

                    If PorcentajeCoberturaActual >= PorcentajeCoberturaCliente Then
                        e.Formatting.BackColor = Color.LightGreen
                        e.Formatting.Font.Color = Color.Green
                    Else

                        e.Formatting.BackColor = Color.Pink
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If

            End If

            'Formato porcentaje con decimales columna CTE
            If e.ColumnFieldName.Contains("CTE") = True AndAlso IsDBNull(e.Value) = False Then
                If e.Value.ToString.Contains("%") = False Then
                    e.Value = e.Value & "%"
                End If

                'e.Formatting.Alignment.HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Right
            End If

        Catch ex As Exception
            'show_message("Error", ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor        
        ListaColumnasGrid.Clear()
        CoberturaColecciones()

        Cursor = Cursors.Default
    End Sub

    Private Sub CoberturaColecciones()

        Dim dtResultadoReporte As New DataTable
        Dim spid As Integer = 0

        If obtenerFiltros() = False Then
            Return
        End If
        dtResultadoReporte = objBU.ReporteCoberturaColecciones(filtro_FechaInicio, filtro_FechaFin, filtro_Agente, filtro_Marca, filtro_Cliente, filtro_Coleccion, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        If dtResultadoReporte.Rows.Count > 0 Then

            'lblNumRegistros.Text = Integer.Parse(grvReportePedidos.RowCount.ToString()).ToString("n0")
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()

            grdReporte.DataSource = Nothing
            spid = Integer.Parse(dtResultadoReporte.Rows(0).Item("spid").ToString())
            diseñoGridResultado(spid)

            grdReporte.DataSource = dtResultadoReporte

            'For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            '    If Col.FieldName <> "RUTA" AndAlso Col.FieldName <> "CLIENTE" AndAlso Col.FieldName <> "CIUDAD" AndAlso Col.FieldName <> "EDO" AndAlso Col.FieldName <> "CLASIF" AndAlso Col.FieldName <> "TDAS" Then

            '        Col.BestFit()

            '        If Col.FieldName.Contains("TOTAL") = True Then
            '            Col.Width = 70
            '        End If
            '    End If

            '    If Col.FieldName = "TDAS" Then
            '        Col.BestFit()
            '    End If

            'Next

            btnArriba_Click(Nothing, Nothing)
        Else
            grdReporte.DataSource = Nothing
            bgvReporte.Bands.Clear()
            bgvReporte.Columns.Clear()
            show_message("Aviso", "No hay datos para mostrar.")
        End If
    End Sub

    Private Function obtenerFiltros() As Boolean
        filtro_Agente = ""
        filtro_Marca = ""
        filtro_Cliente = ""
        filtro_Coleccion = ""

        filtro_FechaInicio = dtpFechaEntregaDel.Value.ToShortDateString()
        filtro_FechaFin = dtpFechaEntregaAl.Value.ToShortDateString()

        For Each Row As UltraGridRow In grdAgentes.Rows
            If filtro_Agente <> "" Then
                filtro_Agente += ","
            End If
            filtro_Agente += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdMarcas.Rows
            If filtro_Marca <> "" Then
                filtro_Marca += ","
            End If
            filtro_Marca += Row.Cells("Parametro").Value.ToString()
        Next
        For Each Row As UltraGridRow In grdClientes.Rows
            If filtro_Cliente <> "" Then
                filtro_Cliente += ","
            End If
            filtro_Cliente += Row.Cells("Parametro").Value.ToString()
        Next

        For Each Row As UltraGridRow In grdColecciones.Rows
            If filtro_Coleccion <> "" Then
                filtro_Coleccion += ","
            End If
            filtro_Coleccion += Row.Cells("Parametro").Value.ToString()
        Next

        If perfilUsuario = 74 Then
            If filtro_Agente <> "" And filtro_Cliente <> "" Then
                Return True
            Else
                show_message("Advertencia", "Se debe seleccionar al menos un agente y un cliente")
                Return False
            End If
        End If
        Return True
    End Function

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

    Private Sub diseñoGridResultado(ByVal spid As Integer)

        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)
        Dim listBandsMarcas As New List(Of String)
        Dim bandMarca As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim BandaAux As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim dtEncabezados As New DataTable
        dtEncabezados = objBU.CoberturaColeccionesObtenerEncabezadosTabla(spid)



        If IsNothing(DTEncabezadoCobertura) = True Then
            DTEncabezadoCobertura = dtEncabezados.Copy()
        Else
            DTEncabezadoCobertura = Nothing
            DTEncabezadoCobertura = dtEncabezados.Copy()
        End If
        bgvReporte.OptionsView.AllowCellMerge = True
        bgvReporte.OptionsView.ColumnAutoWidth = False
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre
        Dim ListaBandaCuatrimestre = dtEncabezados.AsEnumerable().Select(Function(x) x.Item("Cuatrimestre")).Distinct.ToList

        Dim cadenas As String = ""
        For Each item As String In ListaBandaCuatrimestre

            listBandsTextos.Add(item.Trim())
            band = bgvReporte.Bands.Add
            band.AppearanceHeader.Options.UseBackColor = True


            If item = "COLECCIONES NUEVAS" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(198, 224, 180)
            ElseIf item = "COLECCIONES VIGENTES" Then
                band.AppearanceHeader.BackColor = Color.FromArgb(255, 242, 204)
            End If

            band.Caption = item.Trim()
            'Marcas asociadas al cuatrimestre
            Dim ListaBandaMarcas = dtEncabezados.AsEnumerable().Where(Function(x) x.Item("Cuatrimestre") = item.Trim()).Select(Function(y) y.Item("Marca")).Distinct.ToList

            For Each itemmarca As String In ListaBandaMarcas
                bandMarca = band.Children.Add()
                bandMarca.Caption = itemmarca.Trim
                bandMarca.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                listBands.Add(bandMarca)
            Next
        Next

        For Each row As DataRow In dtEncabezados.Rows
            ListaColumnasGrid.Add(row.Item("ColumnaOrigen").ToString())
            BandaAux = listBands.AsEnumerable().FirstOrDefault(Function(x) x.Caption = row.Item("Marca") And x.ParentBand.Caption = row.Item("Cuatrimestre"))

            bgvReporte.Columns.AddField(row.Item("ColumnaOrigen").ToString().ToUpper)
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OwnerBand = BandaAux
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).Visible = True
            bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen")).Caption = row.Item("NombreColumna")

            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
            End If
            If row.Item("ColumnaOrigen").ToString().ToUpper <> "MARCA" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "INDICADOR" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "AGENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "CLIENTE" AndAlso row.Item("ColumnaOrigen").ToString().ToUpper <> "RUTA" Then
                bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom

                If row.Item("ColumnaOrigen").ToString().Contains("CTE") = False Then
                    bgvReporte.Columns.ColumnByFieldName(row.Item("ColumnaOrigen").ToString().ToUpper).DisplayFormat.FormatString = "N0"
                Else
                    Dim valor As String = ""
                    valor = row.Item("ColumnaOrigen").ToString()


                End If

            End If

        Next

        For Each gridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand In listBands
            If gridBand.Caption = "" Then
                gridBand.Caption = "Última actualización: " + lblFechaUltimaActualización.Text
            End If
            If gridBand.Caption = "-" Then
                gridBand.Caption = ""
            End If
            'If gridBand.Caption.ToUpper.Contains("TOTAL") Then
            '    gridBand.Caption = ""
            'End If
        Next

        For Each gridband As DevExpress.XtraGrid.Views.BandedGrid.GridBand In bgvReporte.Bands
            gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            gridband.AppearanceHeader.Options.UseBackColor = True
           

        Next

        bgvReporte.Bands(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        bgvReporte.ColumnPanelRowHeight = 50

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            Col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            'Col.BestFit()
            If Col.FieldName = "#" Then
                Col.Width = 30
            End If

            If Col.FieldName = "INDICADOR" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 175
                Else
                    Col.Width = 185
                End If
            End If
            If Col.FieldName = "MARCA" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 100
                Else
                    Col.Width = 90
                End If
            End If
            If Col.FieldName = "TOTAL" Then
                Col.Width = 100
            End If
            If Col.FieldName = "AGENTE" Then
                If tipoReporte <> 4 And tipoReporte <> 6 Then
                    Col.Width = 170
                Else
                    Col.Width = 185
                End If
            End If
            If Col.FieldName = "CLIENTE" Then
                Col.Width = 300

            End If

            If Col.FieldName = "CIUDAD" Then
                Col.Width = 140
                'Col.BestFit()
            End If

            If Col.FieldName = "RUTA" Then
                Col.Width = 120
            End If

            If Col.FieldName = "TDAS" Then
                Col.Width = 45
            End If

            If Col.FieldName = "CLASIF" Then
                Col.Width = 45
            End If

            If Col.FieldName = "EDO" Then
                Col.Width = 45
            End If

        Next

    End Sub

   
    Private Sub bgvReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReporte.CustomDrawCell
        Dim currentView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = CType(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        Dim PorcentajeCliente As String = ""
        Dim FilaAnterior As Integer = 0
        Dim PorcentajeCoberturaCliente As Integer = 0
        Dim PorcentajeCoberturaActual As Integer = 0

        'Formato porcentaje con decimales columna CTE
        If e.Column.FieldName.Contains("CTE") = True AndAlso e.DisplayText <> "" Then
            If e.DisplayText.Contains("%") = False Then
                e.DisplayText = e.DisplayText.ToString + "%"
            End If

            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        End If


        If currentView.GetRowCellValue(e.RowHandle, "CLIENTE") = "TOTAL GENERAL" Then
            e.Appearance.BackColor = Color.FromArgb(221, 235, 247)
            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
        Else

            'Poner Ceros a los espacios vacíos
            If IsDBNull(currentView.GetRowCellValue(e.RowHandle, e.Column.FieldName)) = True Then
                If e.Column.FieldName <> "RUTA" AndAlso e.Column.FieldName <> "CLIENTE" AndAlso e.Column.FieldName <> "CIUDAD" AndAlso e.Column.FieldName <> "EDO" AndAlso e.Column.FieldName <> "CLASIF" AndAlso e.Column.FieldName <> "TDAS" Then

                    PorcentajeCliente = currentView.GetRowCellValue(e.RowHandle, "CLIENTE")

                    If PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = True OrElse PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True OrElse PorcentajeCliente.Contains("CLASIFICACIÓN DE LA COLECCIÓN") = True OrElse PorcentajeCliente.Contains("CLIENTES EN COBERTURA") = True Then
                        If e.Column.FieldName.Contains("TOTAL") = False And e.Column.FieldName.Contains("PORC") = False And e.Column.FieldName.Contains("CTE") = False Then
                            e.DisplayText = "0"
                        End If
                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    Else
                        e.Appearance.BackColor = Color.Pink
                        e.Appearance.ForeColor = Color.Red

                        If e.Column.FieldName.Contains("CTE") = True Then
                            e.DisplayText = "0.00%"
                        Else
                            e.DisplayText = "0"
                        End If

                        e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                    End If
                End If
            Else
                If e.Column.FieldName <> "RUTA" AndAlso e.Column.FieldName <> "CLIENTE" AndAlso e.Column.FieldName <> "CIUDAD" AndAlso e.Column.FieldName <> "EDO" AndAlso e.Column.FieldName <> "CLASIF" AndAlso e.Column.FieldName <> "TDAS" Then
                    If IsNumeric(e.CellValue) = True Then
                        PorcentajeCliente = currentView.GetRowCellValue(e.RowHandle, "CLIENTE")

                        If PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = False AndAlso PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = False AndAlso PorcentajeCliente.Contains("CLASIFICACIÓN DE LA COLECCIÓN") = False Then
                            If e.CellValue = 0 Then
                                e.Appearance.BackColor = Color.Pink
                                e.Appearance.ForeColor = Color.Red
                            End If
                        End If

                    End If

                End If

            End If
        End If




        If e.Column.FieldName <> "CLIENTE" AndAlso e.Column.FieldName <> "RUTA" AndAlso e.Column.FieldName.Contains("CTE") = False Then
            If IsNumeric(e.CellValue) = True Then
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                e.DisplayText = CDbl(e.CellValue).ToString("N0")
            End If

            PorcentajeCliente = currentView.GetRowCellValue(e.RowHandle, "CLIENTE")

            If (PorcentajeCliente.Contains("COBERTURA IDEAL DE CLIENTES") = True Or PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True) And e.DisplayText <> "" Then
                e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
            End If

            If e.Column.FieldName.Contains("PORC") = True AndAlso e.DisplayText <> "" Then
                e.DisplayText = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.DisplayText.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
            End If




            If PorcentajeCliente.Contains("COBERTURA ACTUAL DE CLIENTES") = True AndAlso e.Column.FieldName.Contains("TOTAL") = False AndAlso e.Column.FieldName.Contains("PORC") = False Then


                FilaAnterior = e.RowHandle - 1

                If IsDBNull(e.CellValue) = True Then
                    PorcentajeCoberturaActual = 0
                Else
                    PorcentajeCoberturaActual = e.CellValue
                End If

                If IsDBNull(currentView.GetRowCellValue(FilaAnterior, e.Column.FieldName)) = True Then
                    PorcentajeCoberturaCliente = 0
                Else
                    PorcentajeCoberturaCliente = currentView.GetRowCellValue(FilaAnterior, e.Column.FieldName)
                End If

                If PorcentajeCoberturaActual >= PorcentajeCoberturaCliente Then
                    e.Appearance.BackColor = Color.LightGreen
                    e.Appearance.ForeColor = Color.Green
                Else

                    e.Appearance.BackColor = Color.Pink
                    e.Appearance.ForeColor = Color.Red
                End If


            End If

        End If






    End Sub

    Private Function ObtenerColorCelda(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Pink
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.LightGreen
        ElseIf Valor > 120 Then
            TipoColor = Color.Thistle
        End If

        Return TipoColor

    End Function


    Private Function ObtenerColorLetra(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Red
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.Green
        ElseIf Valor > 120 Then
            TipoColor = Color.Purple
        End If

        Return TipoColor

    End Function

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_CoberturaColecciones_Ventas_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_CoberturaColecciones_Ventas_V1.pdf")
        Catch ex As Exception
        End Try

    End Sub

   
End Class