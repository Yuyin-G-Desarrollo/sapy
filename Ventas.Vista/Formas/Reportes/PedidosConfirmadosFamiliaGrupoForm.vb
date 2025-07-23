Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Vista
Imports Stimulsoft.Report
Imports Tools
Imports Tools.Utilerias
Imports Ventas.Negocios

Public Class PedidosConfirmadosFamiliaGrupoForm
    Dim vFiltroCliente As String = Nothing
    Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
    Dim tabla As New DataTable
    Private Sub PedidosConfirmadosFamiliaGrupoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDel.Value = Date.Now
        dtpFechaAl.Value = Date.Now
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)

    End Sub

    Private Sub btnAgregarNave_Click(sender As Object, e As EventArgs) Handles btnAgregarCliente.Click
        llenarGridFiltro(grdCliente, "Cliente", 13)
    End Sub

    Private Sub llenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltradoForm
        listado.tipo_busqueda = pTipoBusqueda


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In pGrid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        pGrid.DataSource = listado.listParametros

        With pGrid
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub grdNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
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

    End Sub

    Private Sub grdNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiarFiltroNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = Nothing
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New ReportePedidosFacturacionBU

        Dim cedis As Integer
        Dim fechadel As Date = dtpFechaDel.Value
        Dim fechaAl As Date = dtpFechaAl.Value
        Me.Cursor = Cursors.WaitCursor
        grdReporte.DataSource = Nothing
        obtenerFiltros()

        cedis = cmbCEDIS.SelectedValue

        tabla = obj.ReportePedidosFamiliaGrupo(fechadel, fechaAl, vFiltroCliente, cedis)
        If tabla.Rows.Count > 0 Then
            pnlFiltros.Visible = False
            grdReporte.DataSource = tabla
            disenioGrid()
            ActualizarRegistrosyFecha()
        Else
            ActualizarRegistrosyFecha()
            Tools.MostrarMensaje(Mensajes.Notice, "No existen registros para mostrar")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub obtenerFiltros()
        vFiltroCliente = Filtros(grdCliente)
    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim vDatosFiltrados As String = Nothing
        For Each Row As UltraGridRow In grid.Rows
            If vDatosFiltrados <> Nothing Then
                vDatosFiltrados += ","
            End If
            vDatosFiltrados += Row.Cells("Parametro").Value.ToString()
        Next
        Return vDatosFiltrados
    End Function

    Private Sub disenioGrid()
        Try

            grdVReporte.IndicatorWidth = 40
            grdVReporte.BestFitColumns()

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
                If col.FieldName = "NO" Then
                    col.Visible = False
                End If
                If col.FieldName = "ClienteId" Then
                    col.Visible = False
                End If
                If col.FieldName = "CLIENTE" Then
                    col.Caption = "CLIENTE"
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 300
                End If
                If col.FieldName = "PARESPEDIDO" Then
                    col.Caption = "PARES PEDIDO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "FVO" Then
                    col.Caption = "FVO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 70
                End If
                If col.FieldName = "RVO" Then
                    col.Caption = "RVO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 70
                End If
                If col.FieldName = "AGENTE" Then
                    col.Caption = "AGENTE"
                    col.OptionsColumn.AllowEdit = False
                    col.Width = 70
                End If
                If col.FieldName = "CASUAL NIÑO" Then
                    col.Caption = "CASUAL NIÑO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "CASUAL NIÑA" Then
                    col.Caption = "CASUAL NIÑA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "CASUAL DAMA" Then
                    col.Caption = "CASUAL DAMA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "BOTA DAMA" Then
                    col.Caption = "BOTA DAMA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "BOTA NIÑA / JOVENCITA" Then
                    col.Caption = "BOTA NIÑA / JOVENCITA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "SANDALIA NIÑO" Then
                    col.Caption = "SANDALIA NIÑO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "SANDALIA NIÑA" Then
                    col.Caption = "SANDALIA NIÑA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "SANDALIA DAMA" Then
                    col.Caption = "SANDALIA DAMA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "CABALLERO" Then
                    col.Caption = "CABALLERO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If

                If col.FieldName = "SANDALIA CABALLERO" Then
                    col.Caption = "SANDALIA CABALLERO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If

                If col.FieldName = "ESCOLAR NIÑO" Then
                    col.Caption = "ESCOLAR NIÑO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "ESCOLAR NIÑA" Then
                    col.Caption = "ESCOLAR NIÑA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "ESCOLAR DAMA" Then
                    col.Caption = "ESCOLAR DAMA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "ESCOLAR CABALLERO" Then
                    col.Caption = "ESCOLAR CABALLERO"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "TENIS COLEGIAL" Then
                    col.Caption = "TENIS COLEGIAL"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "SIN FAMILIA" Then
                    col.Caption = "SIN FAMILIA"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
                If col.FieldName = "CINTURÓN" Then
                    col.Caption = "CINTURÓN"
                    col.OptionsColumn.AllowEdit = False
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    col.DisplayFormat.FormatString = "{0:N0}"
                    col.Width = 100
                End If
            Next


            For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
                col.Summary.Remove(col.SummaryItem)
                If col.FieldName = "PARESPEDIDO" Or col.FieldName = "FVO" Or col.FieldName = "RVO" Or col.FieldName = "CASUAL NIÑO" Or col.FieldName = "CASUAL NIÑA" Or col.FieldName = "CASUAL DAMA" Or
                col.FieldName = "BOTA DAMA" Or col.FieldName = "BOTA NIÑA / JOVENCITA" Or col.FieldName = "SANDALIA NIÑO" Or col.FieldName = "SANDALIA NIÑA" Or col.FieldName = "SANDALIA DAMA" Or col.FieldName = "CABALLERO" Or
                col.FieldName = "ESCOLAR NIÑO" Or col.FieldName = "ESCOLAR NIÑA" Or col.FieldName = "ESCOLAR DAMA" Or col.FieldName = "ESCOLAR CABALLERO" Or col.FieldName = "SANDALIA CABALLERO" Or col.FieldName = "TENIS COLEGIAL" Or
                col.FieldName = "SIN FAMILIA" Or col.FieldName = "CINTURÓN" Then
                    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                End If

            Next

            Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVReporte)
            Tools.DiseñoGrid.AlternarColorEnFilasTenue(grdVReporte)


        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub ActualizarRegistrosyFecha()
        lblTotalRegistros.Text = grdVReporte.DataRowCount.ToString("n0")
        lblActualizacion.Text = Date.Now
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        Try
            If grdVReporte.DataRowCount > 0 Then
                Tools.Excel.ExportarExcel(grdVReporte, "ReportePedidosConfirmadosPorFamiliaGrupo")
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "No existen registros para exportar a Excel.")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim obj As New ReportePedidosFacturacionBU
        'Dim tabla As New DataTable
        Dim cedis As Integer
        Dim cedisNombre As String = String.Empty
        Dim numSemanade As Integer = 0
        Dim numSemanaA As Integer = 0
        Dim fechas As String = String.Empty
        Dim numSemanas As String = String.Empty
        Dim fechadel As Date = dtpFechaDel.Value
        Dim fechaAl As Date = dtpFechaAl.Value
        Dim casualnino As Integer = 0
        Dim casualnina As Integer = 0
        Dim casualdama As Integer = 0
        Dim botadama As Integer = 0
        Dim botaninajov As Integer = 0
        Dim sannino As Integer = 0
        Dim sannina As Integer = 0
        Dim sandama As Integer = 0
        Dim caballero As Integer = 0
        Dim escnino As Integer = 0
        Dim escnina As Integer = 0
        Dim escdama As Integer = 0
        Dim esccaba As Integer = 0
        Dim teniscolej As Integer = 0
        Dim sinfamilia As Integer = 0
        Dim cinturon As Integer = 0

        Dim totalCasual As Integer = 0
        Dim totalBota As Integer = 0
        Dim totalSandalia As Integer = 0
        Dim totalCaballero As Integer = 0
        Dim totalEscolar As Integer = 0
        Dim totalSinFamilia As Integer = 0
        Dim totalCinturon As Integer = 0

        Try
            Me.Cursor = Cursors.WaitCursor
            obtenerFiltros()
            cedis = cmbCEDIS.SelectedValue
            cedisNombre = cmbCEDIS.Text
            'DatePart(DateInterval.WeekOfYear, dtpFechaDel.Value, FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek)
            numSemanade = obj.ObtenerNumeroSemana(fechadel)
            numSemanaA = obj.ObtenerNumeroSemana(fechaAl)

            If numSemanade <> numSemanaA Then
                numSemanas = CStr(numSemanade) & "-" & CStr(numSemanaA)
            ElseIf numSemanade = numSemanaA Then
                numSemanas = CStr(numSemanade)
            End If

            fechas = fechadel.ToShortDateString & " - " & fechaAl.ToShortDateString
            'tabla = obj.ReportePedidosFamiliaGrupo(fechadel, fechaAl, vFiltroCliente, cedis)
            'tabla.TableName = ""


            If grdVReporte.RowCount = 0 Then
                Utilerias.show_message(TipoMensaje.Advertencia, "No existen registros para mostrar reporte.")
            Else
                'tabla = obj.ReportePedidosFamiliaGrupo(fechadel, fechaAl, vFiltroCliente, cedis)
                For index As Integer = 0 To tabla.Rows.Count
                    'CASUAL
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "CASUAL NIÑO")) = False Then
                        casualnino = casualnino + grdVReporte.GetRowCellValue(index, "CASUAL NIÑO")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "CASUAL NIÑA")) = False Then
                        casualnina = casualnina + grdVReporte.GetRowCellValue(index, "CASUAL NIÑA")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "CASUAL DAMA")) = False Then
                        casualdama = casualdama + grdVReporte.GetRowCellValue(index, "CASUAL DAMA")
                    End If
                    'BOTA
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "BOTA DAMA")) = False Then
                        botadama = botadama + grdVReporte.GetRowCellValue(index, "BOTA DAMA")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "BOTA NIÑA / JOVENCITA")) = False Then
                        botaninajov = botaninajov + grdVReporte.GetRowCellValue(index, "BOTA NIÑA / JOVENCITA")
                    End If
                    'SANDALIA
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "SANDALIA NIÑO")) = False Then
                        sannino = sannino + grdVReporte.GetRowCellValue(index, "SANDALIA NIÑO")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "SANDALIA NIÑA")) = False Then
                        sannina = sannina + grdVReporte.GetRowCellValue(index, "SANDALIA NIÑA")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "SANDALIA DAMA")) = False Then
                        sandama = sandama + grdVReporte.GetRowCellValue(index, "SANDALIA DAMA")
                    End If
                    'CABALLERO
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "CABALLERO")) = False Then
                        caballero = caballero + grdVReporte.GetRowCellValue(index, "CABALLERO")
                    End If
                    'ESCOLAR
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "ESCOLAR NIÑO")) = False Then
                        escnino = escnino + grdVReporte.GetRowCellValue(index, "ESCOLAR NIÑO")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "ESCOLAR NIÑA")) = False Then
                        escnina = escnina + grdVReporte.GetRowCellValue(index, "ESCOLAR NIÑA")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "ESCOLAR DAMA")) = False Then
                        escdama = escdama + grdVReporte.GetRowCellValue(index, "ESCOLAR DAMA")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "ESCOLAR CABALLERO")) = False Then
                        esccaba = esccaba + grdVReporte.GetRowCellValue(index, "ESCOLAR CABALLERO")
                    End If
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "TENIS COLEGIAL")) = False Then
                        teniscolej = teniscolej + grdVReporte.GetRowCellValue(index, "TENIS COLEGIAL")
                    End If
                    'SIN FAMILIA
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "SIN FAMILIA")) = False Then
                        sinfamilia = sinfamilia + grdVReporte.GetRowCellValue(index, "SIN FAMILIA")
                    End If
                    'CINTURÓN
                    If IsDBNull(grdVReporte.GetRowCellValue(index, "CINTURÓN")) = False Then
                        cinturon = cinturon + grdVReporte.GetRowCellValue(index, "CINTURÓN")
                    End If
                Next

                totalCasual = (casualnino + casualnina + casualdama)
                totalBota = (botadama + botaninajov)
                totalSandalia = (sannino + sannina + sandama)
                totalCaballero = caballero
                totalEscolar = (escnino + escnina + escdama + esccaba + teniscolej)
                totalSinFamilia = sinfamilia
                totalCinturon = cinturon

                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("PEDIDOS_CAPTURADOS_FAMILIA_GRUPO")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                reporte.Load(archivo)
                reporte.Compile()

                reporte("log") = GetRutaLogoPorNave(cedis)
                reporte("usuario") = Usuario
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("titulo") = "REPORTE"
                reporte("cedisNombre") = cedisNombre
                reporte("fecha") = fechas
                reporte("numSemana") = numSemanas
                reporte("TotalCasual") = totalCasual
                reporte("TotalBota") = totalBota
                reporte("TotalSandalia") = totalSandalia
                reporte("TotalCaballero") = totalCaballero
                reporte("TotalEscolar") = totalEscolar
                reporte("TotalSinFamilia") = totalSinFamilia
                reporte("TotalCinturon") = totalCinturon
                reporte.RegData(tabla)
                reporte.Show()

#Region "prueba"
                'casualnino = tabla.AsEnumerable.Sum(Function(x) x.Item("CASUAL NIÑO"))
                'casualnina = tabla.AsEnumerable.Sum(Function(x) x.Item("CASUAL NIÑA"))
                'casualdama = tabla.AsEnumerable.Sum(Function(x) x.Item("CASUAL DAMA"))
                'botadama = tabla.AsEnumerable.Sum(Function(x) x.Item("BOTA DAMA"))
                'botaninajov = tabla.AsEnumerable.Sum(Function(x) x.Item("BOTA NIÑA / JOVENCITA"))
                'sannino = tabla.AsEnumerable.Sum(Function(x) x.Item("SANDALIA NIÑO"))
                'sannina = tabla.AsEnumerable.Sum(Function(x) x.Item("SANDALIA NIÑA"))
                'sandama = tabla.AsEnumerable.Sum(Function(x) x.Item("SANDALIA DAMA"))
                'caballero = tabla.AsEnumerable.Sum(Function(x) x.Item("CABALLERO"))
                'escnino = tabla.AsEnumerable.Sum(Function(x) x.Item("ESCOLAR NIÑO"))
                'escnina = tabla.AsEnumerable.Sum(Function(x) x.Item("ESCOLAR NIÑA"))
                'escdama = tabla.AsEnumerable.Sum(Function(x) x.Item("ESCOLAR DAMA"))
                'esccaba = tabla.AsEnumerable.Sum(Function(x) x.Item("ESCOLAR CABALLERO"))
                'teniscolej = tabla.AsEnumerable.Sum(Function(x) x.Item("TENIS COLEGIAL"))
                'sinfamilia = tabla.AsEnumerable.Sum(Function(x) x.Item("SIN FAMILIA"))
                'cinturon = tabla.AsEnumerable.Sum(Function(x) x.Item("CINTURÓN"))
#End Region


            End If

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GetRutaLogoPorNave(ByVal idNave As Integer) As String
        Return Tools.Controles.ObtenerLogoNave(cmbCEDIS.SelectedValue)
    End Function

End Class