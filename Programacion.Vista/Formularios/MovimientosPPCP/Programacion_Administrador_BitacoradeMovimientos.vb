Imports System.IO
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools

Public Class Programacion_Administrador_BitacoradeMovimientos
    Dim listaInicial As New List(Of String)
    Dim advertencia As New AdvertenciaForm
    Public ProductoEstiloSeleccionados As String = String.Empty
    Dim NumeroFilas As Integer = 0
    Dim Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL"
    Dim objAdvertencia As AdvertenciaForm
    Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
    Dim FechaGeneracionExcel As String = String.Empty
    Dim RutaMovimiento As String = String.Empty
    Dim ProductoEstiloID As Integer = 0
    Dim NaveOrigen As Integer = 0
    Dim TipoMovimiento As String = String.Empty
    Dim ColeccionNombre As String = String.Empty
    Dim NaveDestino As String = String.Empty
    Dim FechaInicioProduccion As String = String.Empty
    Dim exito As New ExitoForm
    Dim NaveDestinoID As Integer = 0


    Dim dtObtieneInformacionMovimientos As New DataTable
    Private Sub Programacion_Administrador_BitacoradeMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        grdNaves.DataSource = listaInicial
        grdTipoMovimiento.DataSource = listaInicial
        lblRegistros.Text = 0
        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
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

    Private Sub btnAgregarTipoMovimiento_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoMovimiento.Click
        Dim listado As New ListadoParametros_MovimientosColecciones
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 2

        For Each row As UltraGridRow In grdTipoMovimiento.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTipoMovimiento.DataSource = listado.listParametros
        With grdTipoMovimiento
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Tipo Movimiento"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnLimTipoMovimiento_Click(sender As Object, e As EventArgs) Handles btnLimTipoMovimiento.Click
        grdTipoMovimiento.DataSource = listaInicial
    End Sub

    Private Sub grdNaves_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdNaves.InitializeLayout
        grid_diseño(grdNaves)
        grdNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Naves"
    End Sub

    Private Sub grdTipoMovimiento_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdTipoMovimiento.InitializeLayout
        grid_diseño(grdTipoMovimiento)
        grdTipoMovimiento.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Tipo Movimiento"
    End Sub

    Private Sub grdNaves_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNaves.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNaves.DeleteSelectedRows(False)
    End Sub

    Private Sub grdTipoMovimiento_KeyDown(sender As Object, e As KeyEventArgs) Handles grdTipoMovimiento.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdTipoMovimiento.DeleteSelectedRows(False)
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


    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New MovimientosPPCPBU
        '        Dim dtObtieneInformacionMovimientos As New DataTable
        Dim FNave As String = String.Empty
        Dim FTipoMovimiento As String = String.Empty
        Dim FechaInicio As Date = dtpFechaInicio.Value.ToShortDateString()
        Dim FechaFin As Date = dtpFechaFin.Value.ToShortDateString()

        Try
            Cursor = Cursors.WaitCursor

            If FechaInicio > FechaFin Then
                advertencia.mensaje = "La fecha de inicio no puede ser mayor a la de fin."
                advertencia.ShowDialog()
            Else

                vwAdministradorMovimientos.Columns.Clear()
                grdAdministradorMovimientos.DataSource = Nothing

                FNave = ObtenerFiltrosGrid(grdNaves)
                FTipoMovimiento = ObtenerFiltrosGrid(grdTipoMovimiento)

                dtObtieneInformacionMovimientos = objBU.ObtieneInformacionMovimientoColecciones(FNave, FTipoMovimiento, ObtenerTipoFecha(), FechaInicio, FechaFin)

                If dtObtieneInformacionMovimientos.Rows.Count > 0 Then
                    grdAdministradorMovimientos.DataSource = dtObtieneInformacionMovimientos
                    DisenioGrid()
                    lblRegistros.Text = CDbl(vwAdministradorMovimientos.RowCount.ToString()).ToString("n0")
                    lblUltimaActualizacion.Text = Date.Now
                    AddGridColumnButton()
                Else
                    advertencia.mensaje = "No hay datos para mostrar."
                    advertencia.ShowDialog()
                End If

            End If


            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub DisenioGrid()


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwAdministradorMovimientos.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains


            If col.FieldName <> "Seleccionar" And col.FieldName <> "Excel" Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwAdministradorMovimientos.Columns.ColumnByFieldName("Seleccionar").Caption = " "
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Excel").Caption = " "

        vwAdministradorMovimientos.Columns.ColumnByFieldName("Seleccionar").Width = 50
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Excel").Width = 30
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Marca").Width = 80
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Colección").Width = 180
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Modelo SAY").Width = 80
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Modelo SICY").Width = 80
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Piel Color").Width = 160
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Movimiento").Width = 100
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Nave Origen").Width = 90
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Nave Destino").Width = 90
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Usuario Creó").Width = 80
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Talla").Width = 60
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Exportado Enviado").Width = 100
        vwAdministradorMovimientos.Columns.ColumnByFieldName("Fecha Creación").Width = 130

        vwAdministradorMovimientos.Columns.ColumnByFieldName("ProductoEstiloID").Visible = False
        vwAdministradorMovimientos.Columns.ColumnByFieldName("NaveOrigenID").Visible = False
        vwAdministradorMovimientos.Columns.ColumnByFieldName("FechaInicioProduccion").Visible = False
        vwAdministradorMovimientos.Columns.ColumnByFieldName("FechaGeneracionExcel").Visible = False
        vwAdministradorMovimientos.Columns.ColumnByFieldName("DevolverHorma").Visible = False
        vwAdministradorMovimientos.Columns.ColumnByFieldName("NaveDestinoID").Visible = False



        DiseñoGrid.AlternarColorEnFilas(vwAdministradorMovimientos)

    End Sub

    Private Sub AddGridColumnButton()
        If grdAdministradorMovimientos Is Nothing Then Exit Sub
        If vwAdministradorMovimientos.Columns.Count < 1 Then Exit Sub

        Dim _RIButton As New RepositoryItemButtonEdit

        grdAdministradorMovimientos.RepositoryItems.Add(_RIButton)

        vwAdministradorMovimientos.Columns("Excel").ShowButtonMode = Views.Base.ShowButtonModeEnum.ShowAlways
        vwAdministradorMovimientos.Columns("Excel").UnboundType = DevExpress.Data.UnboundColumnType.Object
        vwAdministradorMovimientos.Columns("Excel").ColumnEdit = _RIButton
        _RIButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        _RIButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        _RIButton.Buttons(0).Image = My.Resources._1373583708_10

        _RIButton.Buttons(0).Width = vwAdministradorMovimientos.Columns("Excel").Width - (vwAdministradorMovimientos.Columns("Excel").Width / 4)
        AddHandler _RIButton.ButtonClick, AddressOf ColumnaXML_Click


    End Sub

    Private Sub ColumnaXML_Click(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        DescargarArchivoFormatoGenerado()
    End Sub

    Private Sub DescargarArchivoFormatoGenerado()

        Dim objBU As New MovimientosPPCPBU
        Dim MasterFormato As New DataSet("MasterFormato")
        Dim dtInformacionMovimientoColecciones As New DataTable("MovimientoColecciones")
        Dim tbl As New DataTable
        Dim cadenaPE As String = String.Empty
        Dim listMarca As New List(Of String)
        Dim listColeccion As New List(Of String)
        Dim listMovimiento As New List(Of String)
        Dim listFechaAplicacion As New List(Of String)
        Dim marca As String = String.Empty
        Dim cont As Integer = 0

        RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\" + TipoMovimiento
        NumeroFilas = vwAdministradorMovimientos.DataRowCount

        TipoMovimiento = 0
        NaveOrigen = 0
        ProductoEstiloID = 0

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(vwAdministradorMovimientos.IsRowSelected(vwAdministradorMovimientos.GetVisibleRowHandle(index))) = True = True Then
                TipoMovimiento = vwAdministradorMovimientos.GetRowCellValue(index, "Movimiento")
                NaveOrigen = vwAdministradorMovimientos.GetRowCellValue(index, "NaveOrigenID")
                ProductoEstiloID = vwAdministradorMovimientos.GetRowCellValue(index, "ProductoEstiloID")
                'NaveDestino = vwAdministradorMovimientos.GetRowCellValue(index, "Nave Destino")
                FechaGeneracionExcel = vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Year.ToString +
                    vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Month.ToString +
                    vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Day.ToString + "_" +
                    vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Hour.ToString +
                    vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Minute.ToString
            End If
        Next


        For i As Integer = 0 To vwAdministradorMovimientos.RowCount - 1
            If vwAdministradorMovimientos.GetRowCellValue(i, " ") Then
                cont += 1
            End If
        Next

        If cont > 0 Then
            tbl = dtObtieneInformacionMovimientos.AsEnumerable().Where(Function(x) x.Item("Seleccionar") = True).CopyToDataTable
        Else
            Tools.MostrarMensaje(Mensajes.Warning, "Debe seleccionar al menos una colección para descargar archivo.")
            Return
        End If


        If tbl.Rows.Count > 0 Then
            For index As Integer = 0 To tbl.Rows.Count - 1
                If cadenaPE = String.Empty Then
                    cadenaPE = tbl.Rows(index).Item("ProductoEstiloID")
                    listMarca.Add(tbl.Rows(index).Item("Marca"))
                    listColeccion.Add(tbl.Rows(index).Item("Colección"))
                    listMovimiento.Add(tbl.Rows(index).Item("Movimiento"))
                    listFechaAplicacion.Add(tbl.Rows(index).Item("Fecha Aplicación"))
                Else
                    cadenaPE = cadenaPE & "," & tbl.Rows(index).Item("ProductoEstiloID")
                    listMarca.Add(tbl.Rows(index).Item("Marca"))
                    listColeccion.Add(tbl.Rows(index).Item("Colección"))
                    listMovimiento.Add(tbl.Rows(index).Item("Movimiento"))
                    listFechaAplicacion.Add(tbl.Rows(index).Item("Fecha Aplicación"))
                End If
            Next
        End If

        listMarca = listMarca.Distinct().ToList()
        listColeccion = listColeccion.Distinct().ToList()
        listMovimiento = listMovimiento.Distinct().ToList()
        listFechaAplicacion = listFechaAplicacion.Distinct().ToList()

        If listMarca.Count = 1 Then
            If listMarca.Contains("DISCOVERY") Then
                If listColeccion.Count = 1 Then
                    If listMovimiento.Count = 1 Then
                        If listFechaAplicacion.Count = 1 Then
                            marca = "DISCOVERY"
                        Else
                            Tools.MostrarMensaje(Mensajes.Notice, "La fecha de aplicación debe se la misma entre los seleccionados.")
                            Return
                        End If
                    Else
                        Tools.MostrarMensaje(Mensajes.Notice, "El movimiento debe ser el mismo entre los seleccionados.")
                        Return
                    End If
                Else
                    Tools.MostrarMensaje(Mensajes.Notice, "Seleccione solo una colección")
                    Return
                End If
            Else
                If listColeccion.Count = 1 Then
                    If listMovimiento.Count = 1 Then
                        If listFechaAplicacion.Count = 1 Then
                            marca = ""
                        Else
                            Tools.MostrarMensaje(Mensajes.Notice, "La fecha de aplicación debe se la misma entre los seleccionados.")
                            Return
                        End If
                    Else
                        Tools.MostrarMensaje(Mensajes.Notice, "El movimiento debe ser el mismo entre los seleccionados.")
                        Return
                    End If
                Else
                    Tools.MostrarMensaje(Mensajes.Notice, "Seleccione solo una colección")
                    Return
                End If
            End If
        Else
            Tools.MostrarMensaje(Mensajes.Notice, "Seleccione solo una marca")
            Return
        End If



        If TipoMovimiento <> "" Then


            If Not System.IO.Directory.Exists(Ruta) Then
                Directory.CreateDirectory(Ruta)
            End If

            If Not System.IO.Directory.Exists(RutaMovimiento) Then
                Directory.CreateDirectory(RutaMovimiento)
            End If
            Try
                Select Case TipoMovimiento
                    Case "DESCONTINUAR"
                        Cursor = Cursors.WaitCursor
                        If marca <> "DISCOVERY" Then
                            dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientosGeneradosColecciones(TipoMovimiento, ProductoEstiloID, NaveOrigen)
                        Else
                            dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientosGeneradosColeccionesDiscovery(TipoMovimiento, cadenaPE, NaveOrigen)
                        End If

                        If dtInformacionMovimientoColecciones.Rows.Count > 0 Then
                            Dim objBUReporte As New Framework.Negocios.ReportesBU
                            Dim EntidadReporte As Entidades.Reportes

                            MasterFormato.Tables.Add(dtInformacionMovimientoColecciones)

                            EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_DESC")
                            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                            Dim reporte As New StiReport()

                            reporte.Load(archivo)
                            reporte.Compile()
                            reporte("MasterFormato") = "MasterFormato"
                            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                            reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)

                            reporte.Dictionary.Clear()
                            reporte.RegData(MasterFormato)
                            reporte.Dictionary.Synchronize()
                            reporte.Render()
                            formatoExcel.ExportObjectFormatting = True
                            StiOptions.Export.Excel.ShowGridLines = False
                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de \Formato de Aviso de Fin de Producción " + FechaGeneracionExcel + ".xls")

                            exito.mensaje = "Formato Generado correctamente en " + RutaMovimiento + "."
                            exito.ShowDialog()
                            btnMostrar_Click(Nothing, Nothing)
                        Else
                            objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                            objAdvertencia.ShowDialog()
                        End If
                    Case "TRASPASO"

                        Cursor = Cursors.WaitCursor
                        If marca <> "DISCOVERY" Then
                            dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientosGeneradosColecciones(TipoMovimiento, ProductoEstiloID, NaveOrigen)
                        Else
                            dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientosGeneradosColeccionesDiscovery(TipoMovimiento, cadenaPE, NaveOrigen)
                        End If


                        If dtInformacionMovimientoColecciones.Rows.Count > 0 Then
                            Dim objBUReporte As New Framework.Negocios.ReportesBU
                            Dim EntidadReporte As Entidades.Reportes

                            MasterFormato.Tables.Add(dtInformacionMovimientoColecciones)

                            EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_TRAS")
                            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                            Dim reporte As New StiReport()

                            reporte.Load(archivo)
                            reporte.Compile()
                            reporte("MasterFormato") = "MasterFormato"
                            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                            reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                            reporte("TipoMovimiento") = TipoMovimiento
                            reporte.Dictionary.Clear()
                            reporte.RegData(MasterFormato)
                            reporte.Dictionary.Synchronize()
                            reporte.Render()
                            formatoExcel.ExportObjectFormatting = True
                            StiOptions.Export.Excel.ShowGridLines = False
                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + " " + FechaGeneracionExcel + ".xls")


                            GenerarFormatoCostos(TipoMovimiento, marca, cadenaPE)
                            exito.mensaje = "Formato Generado correctamente en " + RutaMovimiento + "."
                            exito.ShowDialog()
                            btnMostrar_Click(Nothing, Nothing)
                        Else
                            objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                            objAdvertencia.ShowDialog()
                        End If

                    Case Else

                        Cursor = Cursors.WaitCursor

                        If marca <> "DISCOVERY" Then
                            dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientosGeneradosColecciones(TipoMovimiento, ProductoEstiloID, NaveOrigen)
                        Else
                            dtInformacionMovimientoColecciones = objBU.ObtenerInformacionMovimientosGeneradosColeccionesDiscovery(TipoMovimiento, cadenaPE, NaveOrigen)
                        End If



                        If dtInformacionMovimientoColecciones.Rows.Count > 0 Then
                            Dim objBUReporte As New Framework.Negocios.ReportesBU
                            Dim EntidadReporte As Entidades.Reportes

                            MasterFormato.Tables.Add(dtInformacionMovimientoColecciones)

                            EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES")
                            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                            Dim reporte As New StiReport()

                            reporte.Load(archivo)
                            reporte.Compile()
                            reporte("MasterFormato") = "MasterFormato"
                            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                            reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                            reporte("TipoMovimiento") = TipoMovimiento
                            reporte.Dictionary.Clear()
                            reporte.RegData(MasterFormato)
                            reporte.Dictionary.Synchronize()
                            reporte.Render()
                            formatoExcel.ExportObjectFormatting = True
                            StiOptions.Export.Excel.ShowGridLines = False


                            reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + " " + FechaGeneracionExcel + ".xls")

                            GenerarFormatoCostos(TipoMovimiento, marca, cadenaPE)

                            exito.mensaje = "Formato Generado correctamente en " + RutaMovimiento + "."
                            exito.ShowDialog()
                            btnMostrar_Click(Nothing, Nothing)
                        Else
                            objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                            objAdvertencia.ShowDialog()
                            btnMostrar_Click(Nothing, Nothing)
                        End If

                End Select
                Cursor = Cursors.Default

            Catch ex As Exception
                Cursor = Cursors.Default
                MessageBox.Show(ex.Message)
            End Try

        Else
            advertencia.mensaje = "Debe seleccionar al menos una colección para descargar archivo."
            advertencia.ShowDialog()
        End If



    End Sub


    Private Sub GenerarFormatoCostos(ByVal TipoMovimiento As String, ByVal marca As String, ByVal cadenaPE As String)
        Dim objBU As New MovimientosPPCPBU
        Dim MasterFormatoCostos As New DataSet("MasterFormatoCostos")
        Dim dtInformacionMovimientoCostos As New DataTable("dtInformacionMovimientoCostos")
        Try

            Select Case TipoMovimiento
                Case "TRASPASO"

                    If marca <> "DISCOVERY" Then
                        dtInformacionMovimientoCostos = objBU.ObtenerInformacionMovimientosGeneradosColecciones_Costos(TipoMovimiento, ProductoEstiloID, NaveOrigen)
                    Else
                        dtInformacionMovimientoCostos = objBU.ObtenerInformacionMovimientosGeneradosColecciones_CostosDiscovery(TipoMovimiento, cadenaPE, NaveOrigen)
                    End If


                    If dtInformacionMovimientoCostos.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormatoCostos.Tables.Add(dtInformacionMovimientoCostos)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_COSTOS")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormatoCostos") = "MasterFormatoCostos"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("MaterialDirecto") = 0
                        reporte("MaterialIndirecto") = 0
                        reporte("ManoObra") = 0
                        reporte("DepartamentoCalidad") = 0
                        reporte("GastosGenerales") = 0
                        reporte("Utilidad") = 0
                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormatoCostos)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False
                        reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + "_Costos " + FechaGeneracionExcel + ".xls")

                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()
                    End If

                Case Else

                    If marca <> "DISCOVERY" Then
                        dtInformacionMovimientoCostos = objBU.ObtenerInformacionMovimientosGeneradosColecciones_Costos(TipoMovimiento, ProductoEstiloID, NaveOrigen)
                    Else
                        dtInformacionMovimientoCostos = objBU.ObtenerInformacionMovimientosGeneradosColecciones_CostosDiscovery(TipoMovimiento, cadenaPE, NaveOrigen)
                    End If


                    If dtInformacionMovimientoCostos.Rows.Count > 0 Then
                        Dim objBUReporte As New Framework.Negocios.ReportesBU
                        Dim EntidadReporte As Entidades.Reportes

                        MasterFormatoCostos.Tables.Add(dtInformacionMovimientoCostos)

                        EntidadReporte = objBUReporte.LeerReporteporClave("RPT_MOV_COLECCIONES_COSTOS")
                        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                        Dim reporte As New StiReport()

                        reporte.Load(archivo)
                        reporte.Compile()
                        reporte("MasterFormatoCostos") = "MasterFormatoCostos"
                        reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                        reporte("MaterialDirecto") = 0
                        reporte("MaterialIndirecto") = 0
                        reporte("ManoObra") = 0
                        reporte("DepartamentoCalidad") = 0
                        reporte("GastosGenerales") = 0
                        reporte("Utilidad") = 0
                        reporte.Dictionary.Clear()
                        reporte.RegData(MasterFormatoCostos)
                        reporte.Dictionary.Synchronize()
                        reporte.Render()
                        formatoExcel.ExportObjectFormatting = True
                        StiOptions.Export.Excel.ShowGridLines = False
                        reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + "_Costos " + FechaGeneracionExcel + ".xls")
                    Else
                        objAdvertencia.mensaje = "No existe información del movimiento, intente nuevamente."
                        objAdvertencia.ShowDialog()

                    End If


            End Select
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try

    End Sub



    Private Function ObtenerProductoEstilosSeleccionados() As String
        Dim productoEstiloSeleccionados As String = String.Empty

        NumeroFilas = vwAdministradorMovimientos.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwAdministradorMovimientos.IsRowSelected(vwAdministradorMovimientos.GetVisibleRowHandle(index))) = True Then

                If productoEstiloSeleccionados <> "" Then
                    productoEstiloSeleccionados += ","
                End If

                productoEstiloSeleccionados += vwAdministradorMovimientos.GetRowCellValue(vwAdministradorMovimientos.GetVisibleRowHandle(index), "ProductoEstiloID").ToString

            End If
        Next

        Return productoEstiloSeleccionados
    End Function


    Private Function ObtenerTipoFecha() As Integer
        Dim Resultado As String = String.Empty

        If rdoCaptura.Checked = True Then
            Resultado = 1
        ElseIf rdoAplicacion.Checked = True Then
            Resultado = 2
        Else
            Resultado = 0
        End If

        Return Resultado

    End Function

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
        grdTipoMovimiento.DataSource = listaInicial
        grdAdministradorMovimientos.DataSource = Nothing
        lblRegistros.Text = "0"
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If vwAdministradorMovimientos.RowCount > 0 Then
            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty


            Try
                nombreReporte = "\Administrador_MovimientoColecciones"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = System.Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor

                        If vwAdministradorMovimientos.GroupCount > 0 Then
                            vwAdministradorMovimientos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            vwAdministradorMovimientos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")

                        .Dispose()

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If

        e.Handled = True
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim dtResultadoDatosCorreos As New DataTable
        Dim remitente As String = String.Empty
        Dim objBU As New MovimientosPPCPBU
        Dim rutaArchivoMovimientoCostos As String = String.Empty
        Dim rutaArchivoMovimiento As String = String.Empty
        Dim asuntoCorreo As String = String.Empty
        Dim cadenaCorreo As String = String.Empty
        Dim FechaGeneracion As String = String.Empty
        Dim lstArchivoAdjuntos As New List(Of System.Net.Mail.Attachment)
        Dim archivoAdjunto As System.Net.Mail.Attachment
        Dim entCorreo As New Entidades.DatosCorreo
        Dim CorreosDestinatario As String = "adesarrollo.ti@grupoyuyin.com.mx"
        Dim correo As New Tools.Correo
        Dim DevolverHorma As String = String.Empty
        Dim lstContadorColeccionesId As New List(Of String)
        Dim dtActualizarEstatusCorreo As DataTable
        Dim accionForm As String = String.Empty
        Dim Existe As Boolean = False

        TipoMovimiento = ""


        If vwAdministradorMovimientos.DataRowCount > 0 Then

            NumeroFilas = vwAdministradorMovimientos.DataRowCount

            dtResultadoDatosCorreos = objBU.consultaCorreosEnvioFactura("ENVIO_FACTURAS_CLIENTES")
            remitente = dtResultadoDatosCorreos.Rows(0).Item("CorreoEnvia").ToString()


            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(vwAdministradorMovimientos.GetRowCellValue(vwAdministradorMovimientos.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    If lstContadorColeccionesId.Contains(vwAdministradorMovimientos.GetRowCellValue(vwAdministradorMovimientos.GetVisibleRowHandle(index), "ProductoEstiloID").ToString()) = False Then
                        TipoMovimiento = vwAdministradorMovimientos.GetRowCellValue(index, "Movimiento")
                        NaveOrigen = vwAdministradorMovimientos.GetRowCellValue(index, "NaveOrigenID")
                        ProductoEstiloID = vwAdministradorMovimientos.GetRowCellValue(index, "ProductoEstiloID")
                        ColeccionNombre = vwAdministradorMovimientos.GetRowCellValue(index, "Colección")
                        NaveDestino = vwAdministradorMovimientos.GetRowCellValue(index, "Nave Destino")
                        FechaInicioProduccion = vwAdministradorMovimientos.GetRowCellValue(index, "FechaInicioProduccion")
                        FechaGeneracionExcel = vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Year.ToString +
                        vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Month.ToString +
                        vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Day.ToString + "_" +
                        vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Hour.ToString +
                        vwAdministradorMovimientos.GetRowCellValue(index, "FechaGeneracionExcel").Minute.ToString
                        DevolverHorma = vwAdministradorMovimientos.GetRowCellValue(index, "DevolverHorma")
                        NaveDestinoID = vwAdministradorMovimientos.GetRowCellValue(index, "NaveDestinoID")
                        lstContadorColeccionesId.Add(vwAdministradorMovimientos.GetRowCellValue(vwAdministradorMovimientos.GetVisibleRowHandle(index), "ProductoEstiloID").ToString())
                    End If
                End If
            Next

            If lstContadorColeccionesId.Count > 1 Then
                advertencia.mensaje = "Seleccione un solo registro para el envío."
                advertencia.ShowDialog()
                Exit sub
            End If

            Try

                If TipoMovimiento <> "" Then

                    Select Case TipoMovimiento
                        Case "ASIGNACIÓN"
                            accionForm = "Asignar Articulos"
                            Existe = False
                        Case "DUPLICIDAD"
                            accionForm = "Asignar Articulos"
                            Existe = True
                        Case "TRASPASO"
                            accionForm = "Transferir Articulos"
                        Case "DESCONTINUAR"
                            accionForm = "Desasignar Articulos"
                    End Select

                    rutaArchivoMovimiento = RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + " " + FechaGeneracionExcel + ".xls"
                    rutaArchivoMovimientoCostos = RutaMovimiento + "\Formato de Aviso de " + StrConv(TipoMovimiento, vbProperCase) + "_Costos " + FechaGeneracionExcel + ".xls"
                    asuntoCorreo = "Asunto: Aviso Formato de " + StrConv(TipoMovimiento, vbProperCase) + " y Costos"
                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\" + TipoMovimiento

                    Select Case TipoMovimiento
                        Case "DESCONTINUAR"

                            rutaArchivoMovimiento = RutaMovimiento + "\Formato de Aviso de Fin de Producción " + FechaGeneracionExcel + ".xls"

                            asuntoCorreo = "Asunto: Aviso Formato de Fin de Producción"
                            cadenaCorreo = "<html> " +
                                  " <head>" +
                                  " </head>"
                            cadenaCorreo += " <body> "
                            cadenaCorreo += " <br><p>Buen día: Les informo que a partir de la fecha " + FechaInicioProduccion + " la colección " + ColeccionNombre + "  se dejará de producir.  . .</p>"
                            If DevolverHorma = "SI" Then
                                cadenaCorreo += " <p>Por lo que les pido que les sea entregados los herramentales a la nave " + NaveDestino + ", en cuanto ya no los estén ocupando en la producción, para que realicen su resguardo.</p> "
                            Else
                                cadenaCorreo += " <p>Por lo que les pido que les sea entregados los suajes a la nave " + NaveDestino + ", en cuanto ya no los estén ocupando en la producción, para que realicen su resguardo.</p> "
                            End If
                            cadenaCorreo += " <br><p> Quedo a sus órdenes para cualquier duda o comentario. </p>"
                            cadenaCorreo += " <br><p> Saludos!!!! </p>"
                            cadenaCorreo += " <br><p> Atentamente Grupo Yuyin </p>"
                            cadenaCorreo += " </body> " +
                                        " </html> "

                            If rutaArchivoMovimiento <> String.Empty Then
                                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimiento)
                                lstArchivoAdjuntos.Add(archivoAdjunto)
                            End If

                            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

                            If entCorreo.CorreoEnviado = True Then
                                dtActualizarEstatusCorreo = objBU.ActualizarEstatusCorreoExportar(CStr(ProductoEstiloID), Existe, NaveDestinoID, accionForm)
                                exito.mensaje = "Correo enviado correctamente."
                                exito.ShowDialog()
                                btnMostrar_Click(Nothing, Nothing)
                            Else
                                objAdvertencia.mensaje = "Ocurrió un error al enviar el correo, intente nuevamente."
                                objAdvertencia.ShowDialog()
                            End If


                        Case Else


                            cadenaCorreo = "<html> " +
                                  " <head>" +
                                  " </head>"
                            cadenaCorreo += " <body> "
                            cadenaCorreo += " <br><p>Buen día: Les informo que se autorizó el movimiento de " + StrConv(TipoMovimiento, vbProperCase) + " de la colección " + ColeccionNombre + "  a Nave " + NaveDestino + " . .</p>"
                            cadenaCorreo += " <p>Esta planeado iniciar producción el " + FechaInicioProduccion + ", para que vayan anticipando lo necesario para su entrega y producción.</p>"
                            cadenaCorreo += " <p>Favor de coordinarse para que se cuente con lo necesario para producir esta colección en las fechas solicitadas.</p> "
                            cadenaCorreo += " <br><p> Quedo a sus órdenes para cualquier duda o comentario. </p>"
                            cadenaCorreo += " <br><p> Saludos!!!! </p>"
                            cadenaCorreo += " <br><p> Atentamente Grupo Yuyin </p>"
                            cadenaCorreo += " </body> " +
                                        " </html> "

                            If rutaArchivoMovimiento <> String.Empty Then
                                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimiento)
                                lstArchivoAdjuntos.Add(archivoAdjunto)
                            End If

                            If rutaArchivoMovimientoCostos <> String.Empty Then
                                archivoAdjunto = New System.Net.Mail.Attachment(rutaArchivoMovimientoCostos)
                                lstArchivoAdjuntos.Add(archivoAdjunto)
                            End If

                            entCorreo = correo.EnviarCorreoFacturasHtmlVariosArchivosAdjuntos(CorreosDestinatario, remitente, asuntoCorreo, cadenaCorreo, lstArchivoAdjuntos)

                            If entCorreo.CorreoEnviado = True Then
                                dtActualizarEstatusCorreo = objBU.ActualizarEstatusCorreoExportar(CStr(ProductoEstiloID), Existe, NaveDestinoID, accionForm)
                                exito.mensaje = "Correo enviado correctamente."
                                exito.ShowDialog()
                                btnMostrar_Click(Nothing, Nothing)
                            Else
                                objAdvertencia.mensaje = "Ocurrió un error al enviar el correo, intente nuevamente."
                                objAdvertencia.ShowDialog()
                            End If

                    End Select

                Else
                    advertencia.mensaje = "Debe seleccionar al menos una colección para enviar correo."
                    advertencia.ShowDialog()
                End If



            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            objAdvertencia.mensaje = "Seleccione un registro para realizar el envío."
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlFiltros.Visible = True
        pnlBotonesExpander.AutoSize = True
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlFiltros.Visible = False
        pnlBotonesExpander.AutoSize = True
    End Sub



    Private Sub vwAdministradorMovimientos_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwAdministradorMovimientos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class