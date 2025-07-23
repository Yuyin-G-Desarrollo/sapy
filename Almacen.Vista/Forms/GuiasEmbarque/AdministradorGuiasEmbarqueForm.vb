Imports System.IO
Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Stimulsoft.Report
Imports Tools
Imports Tools.Utilerias
Imports Ventas.Vista

Public Class AdministradorGuiasEmbarqueForm
    Dim objInstancia As New AdministradorDocumentosBU
    Dim ListaGuia As New List(Of String)
    Dim ListaPedido As New List(Of String)
    Dim ListaOT As New List(Of String)
    Dim ListaFactura As New List(Of String)
    Dim ListaRemison As New List(Of String)
    Dim ListaClientesid As New List(Of String)
    Dim ListaClientesnombres As New List(Of String)
    Dim ListaTransporteid As New List(Of String)
    Dim ListaTransportenombres As New List(Of String)
    Dim ListaAtnClienteid As New List(Of String)
    Dim ListaAtnNombres As New List(Of String)
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\Castores"
    Dim confirmar As New Tools.ConfirmarForm

    Private Sub AdministradorGuiasEmbarqueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        limpirarGrids()
        dtfechaIni.Value = Date.Now
        dtfechaFin.Value = Date.Now
        If cbfecha.Checked Then
            dtfechaIni.Enabled = True
            dtfechaFin.Enabled = True
        Else
            dtfechaIni.Enabled = False
            dtfechaFin.Enabled = False
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_SHOW_CLIEN_ASING") Then
            Dim datosAtn = objInstancia.ConsultarAtnClienteInfo(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser)
            grdAtnClientes.DataSource = datosAtn
            With grdAtnClientes
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Atn Clientes"
            End With
            grid_diseño(grdAtnClientes)
            gboxPlazoPago.Enabled = False
        End If

        PermisosPerfil()
        Try
            grdStatusDev.DataSource = objInstancia.consultarEstatusEmbarque(1)
            ConsultarDocumentos()
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "Sucedio un error al consultar los embarques")
        End Try

    End Sub
    Private Sub PermisosPerfil()
        Dim DTInformacionUsuario As New DataTable

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_IMP_ETI") Then
            pnlimpr.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_CANC_GUIA") Then
            pnlcancelar.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_CHANG_STA") Then
            pnlstatusenp.Visible = True
            pntestatusentre.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_REEM_GUIA") Then
            pnlreembar.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_CAPT_NUM") Then
            pnlnumGuia.Visible = True
            pnlimportacion.Visible = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_ARCHIVE_CAST") Then
            pnlArchivo.Visible = True
        End If
    End Sub
    Public Sub ConsultarDocumentos()
        Cursor = Cursors.WaitCursor
        vwGuiasEmbarque.Columns.Clear()
        grdGuiasEmbarque.DataSource = Nothing

        Dim datos As DataTable 'Variable que tendra los datos del grid'

        Dim estatus = ObtenerFiltrosGrid(grdStatusDev) 'Filtro Estatus
        Dim guiasEmbarque = ObtenerFiltrosGrid(grdFiltroGuiaE) 'Filtro Guias
        Dim clientes = ObtenerFiltrosGrid(grdCliente) 'Filtro cliente
        Dim transporte = ObtenerFiltrosGrid(grdTransporte) 'Filtro Transporte
        Dim AntCliente = ObtenerFiltrosGrid(grdAtnClientes)  'Filtro Atn Cliente
        Dim pedidos = ObtenerFiltrosGrid(grdPedido) 'Filtro pedidos
        Dim ot = ObtenerFiltrosGrid(grdOT)  'Filtro Ot
        Dim facturas = ObtenerFiltrosGrid(grdFactura) 'Filtro facturas
        Dim remision = ObtenerFiltrosGrid(grdRemision) 'Filtro remision


        Dim tipoempaque As Integer

        If rdTodos.Checked Then
            tipoempaque = 3
        ElseIf rdOtros.Checked Then
            tipoempaque = 2
        ElseIf rdNormal.Checked Then
            tipoempaque = 1
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("MDL_ADMIN_GUIAS_EMBA", "GUI_SHOW_CLIEN_ASING") Then
            datos = objInstancia.ConsultarGuiasEmbarque(If(cbfecha.Checked, 1, 0), dtfechaIni.Value, dtfechaFin.Value, guiasEmbarque, If(cbpendientes.Checked, 1, 0), If(cbconguia.Checked, 1, 0), clientes, tipoempaque, estatus, transporte, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, pedidos, ot, facturas, remision)

        Else
            datos = objInstancia.ConsultarGuiasEmbarque(If(cbfecha.Checked, 1, 0), dtfechaIni.Value, dtfechaFin.Value, guiasEmbarque, If(cbpendientes.Checked, 1, 0), If(cbconguia.Checked, 1, 0), clientes, tipoempaque, estatus, transporte, AntCliente, pedidos, ot, facturas, remision)
        End If

        grdGuiasEmbarque.DataSource = datos
        vwGuiasEmbarque.OptionsView.ColumnAutoWidth = True
        DiseñoGrid.DiseñoBaseGrid(vwGuiasEmbarque)
        DiseñoGrid.EstiloColumna(vwGuiasEmbarque, "Selección", "  ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, True, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwGuiasEmbarque, "CantidadCajasAtados", "Cantidad" & vbCrLf & "Cajas o Atados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 100, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwGuiasEmbarque, "StatusID", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 30, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwGuiasEmbarque, "TipoEmbarque", "TipoEmbarque", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 125, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwGuiasEmbarque, "Mensajeria", "Mensajería", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "#,0#")

        vwGuiasEmbarque.IndicatorWidth = 45
        lblFechaUltimaActualizacion.Text = Date.Now
        lblTotalParesProceso.Text = String.Format("{0:N0}", datos.Rows.Count)
        Cursor = Cursors.Default
    End Sub
    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                Resultado += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        Return Resultado
    End Function
    Private Sub viewGuiasEmbarque_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwGuiasEmbarque.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConsultarDocumentos()
    End Sub

    Private Sub cbfecha_CheckedChanged(sender As Object, e As EventArgs) Handles cbfecha.CheckedChanged
        If cbfecha.Checked Then
            dtfechaIni.Enabled = True
            dtfechaFin.Enabled = True
        Else
            dtfechaIni.Enabled = False
            dtfechaFin.Enabled = False
        End If
    End Sub

    Private Sub txtFiltroDocto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroGuia.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroGuia.Text) Then Return

            ListaGuia.Add(txtFiltroGuia.Text)
            grdFiltroGuiaE.DataSource = Nothing
            grdFiltroGuiaE.DataSource = ListaGuia

            txtFiltroGuia.Text = String.Empty
            With grdFiltroGuiaE
                .DisplayLayout.Bands(0).Columns(0).Header.Caption = "GuiaEmbarque"
            End With
        End If
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
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

        grid_diseño(grdCliente)
    End Sub

    Private Sub btnAgregarFiltroTransporte_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim listado As New FiltroTransporteForm

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdTransporte.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdTransporte.DataSource = listado.listParametros
        With grdTransporte
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Transporte"
        End With

        grid_diseño(grdTransporte)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
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
        If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
            grid.DisplayLayout.Bands(0).Columns("Parámetro").Hidden = True
        End If
        asignaFormato_Columna(grdCliente)

    End Sub
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
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


    Private Sub grdFiltroGuiaE_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFiltroGuiaE.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFiltroGuiaE.DeleteSelectedRows(False)
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        ListaClientesid = New List(Of String)
        ListaClientesnombres = New List(Of String)
        grdCliente.DataSource = Nothing
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub limpirarGrids()
        grdCliente.DataSource = New List(Of String)
        grdStatusDev.DataSource = objInstancia.consultarEstatusEmbarque(1)
        ListaClientesid = New List(Of String)
        ListaClientesnombres = New List(Of String)
        ListaGuia = New List(Of String)
        ListaTransportenombres = New List(Of String)
        ListaTransporteid = New List(Of String)
        ListaPedido = New List(Of String)
        grdPedido.DataSource = New List(Of String)

        ListaOT = New List(Of String)
        grdOT.DataSource = New List(Of String)

        ListaFactura = New List(Of String)
        grdFactura.DataSource = New List(Of String)

        ListaRemison = New List(Of String)
        grdRemision.DataSource = New List(Of String)


        grdTransporte.DataSource = New List(Of String)
        grdFiltroGuiaE.DataSource = New List(Of String)
        rdTodos.Checked = True
        cbfecha.Checked = False
        dtfechaIni.Value = Date.Now
        dtfechaFin.Value = Date.Now
        cbconguia.Checked = True
        cbpendientes.Checked = True

        'Clean Filtro AtnCliente
        ListaAtnClienteid = New List(Of String)
        ListaAtnNombres = New List(Of String)
        grdAtnClientes.DataSource = New List(Of String)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpirarGrids()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim instancia As New ImportacionArchivoGuiaForm
        instancia.StartPosition = FormStartPosition.CenterParent
        instancia.ShowDialog()
        ConsultarDocumentos()
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New XlsxExportOptionsEx()
                AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    If vwGuiasEmbarque.GroupCount > 0 Then
                        vwGuiasEmbarque.ExportToXlsx(.SelectedPath + "\GuiasEmbarque_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        vwGuiasEmbarque.ExportToXlsx(.SelectedPath + "\GuiasEmbarque_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "GuiasEmbarque_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\GuiasEmbarque_" + fecha_hora + ".xlsx")

                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btncancelar.Click
        cancelarEmbarque()
        ConsultarDocumentos()
    End Sub

    Private Sub cancelarEmbarque()

        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then
                FilasSeleccionadas += 1
                documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
            End If
        Next
        If FilasSeleccionadas > 0 Then
            confirmar.mensaje = "¿Estás segur(a) de CANCELAR el embarque?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim result = objInstancia.CalcelarEmbarque(documentosSeleccionados)
                If result.Rows(0).Item("mostrar") = 0 Then
                    Utilerias.show_message(TipoMensaje.Exito, "Se CANCELARON los embarques")
                Else
                    Dim mensaje As New MensajeBDEmbarquesForm
                    mensaje.mensajes = result
                    mensaje.StartPosition = FormStartPosition.CenterParent
                    mensaje.ShowDialog()
                End If
                Cursor = Cursors.Default
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un embarque")
        End If
    End Sub

    Private Sub PonerEnRutaEmbarque()
        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then
                FilasSeleccionadas += 1
                documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
            End If
        Next
        If FilasSeleccionadas > 0 Then
            Try
                confirmar.mensaje = "¿Está segur(a) de poner EN RUTA los embarques?"
                If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim result = objInstancia.PonerEnRutaEmbarque(documentosSeleccionados, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    If result.Rows(0).Item("mostrar") = 0 Then
                        Utilerias.show_message(TipoMensaje.Exito, "Se pusieron EN RUTA los embarques")
                    Else
                        Dim mensaje As New MensajeBDEmbarquesForm
                        mensaje.StartPosition = FormStartPosition.CenterParent
                        mensaje.mensajes = result
                        mensaje.ShowDialog()
                    End If
                    Cursor = Cursors.Default
                End If

            Catch ex As Exception
                Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error al poner el embarque en RUTA")
            End Try
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un embarque")
        End If
    End Sub

    Private Sub PonerEnEntregadoEmbarque()
        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then
                FilasSeleccionadas += 1
                documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
            End If
        Next
        If FilasSeleccionadas > 0 Then
            confirmar.mensaje = "¿Está segur(a) de cambiar a ENTREGADO los siguientes Embarques?"
            If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Dim result = objInstancia.PonerEnEntregadoEmbarque(documentosSeleccionados, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                If result.Rows(0).Item("mostrar") = 0 Then
                    Utilerias.show_message(TipoMensaje.Exito, "Se cambio a ENTREGADO los embarques")
                Else
                    Dim mensaje As New MensajeBDEmbarquesForm
                    mensaje.mensajes = result
                    mensaje.ShowDialog()
                End If
                Cursor = Cursors.Default
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un embarque")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = Cursors.WaitCursor
        generarArchivoCastores()
        Cursor = Cursors.Default
    End Sub

    Private Sub generarArchivoCastores()

        Dim RutaArchivoEtiquetas As String = "C:\SAY\Castores\\ArchivoGuiaCastores_" & Date.Now.Year & ".txt"
        Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim invalido As Boolean


        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0

        Dim EtiquetasAImprimir As String = String.Empty


        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then

                Dim mensajeria = Replace(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Mensajeria"), " ", "").ToString
                If mensajeria <> "TRANSPORTECASTORES" Then
                    Utilerias.show_message(TipoMensaje.Advertencia, "Uno o mas Folios no pertenecen a la mensajería TRANSPORTE CASTORES")
                    Return
                    ' invalido = True
                    'Exit For
                Else
                    FilasSeleccionadas += 1
                    documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                End If
            End If
        Next
        Try
            If FilasSeleccionadas > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    If ret = DialogResult.OK Then

                        Dim strStreamW As Stream = Nothing
                        Dim strStreamWriter As StreamWriter = Nothing

                        If invalido <> True Then
                            strStreamW = CrearRutasArchivo(.SelectedPath + "\GuiasEmbarque_" + fecha_hora & ".txt")
                            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                            Dim dt = objInstancia.GenerarArchivoCastores(documentosSeleccionados)
                            For Each FILA As DataRow In dt.Rows
                                EtiquetasAImprimir = FILA.Item(0)
                                strStreamWriter.WriteLine(EtiquetasAImprimir)
                            Next

                            strStreamWriter.Close()
                            objInstancia.ModificarBanderaGenerarArchivoCastores(documentosSeleccionados)
                            Utilerias.show_message(TipoMensaje.Exito, "Se genero el archivo correctamente")
                        End If
                    End If
                End With
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un Folio de Embarque")
            End If
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "No se genero el archivo")
        End Try

        ConsultarDocumentos()



    End Sub

    Private Function CrearRutasArchivo(ByVal Archivo As String) As Stream
        Dim strStreamW As Stream = Nothing

        Try
            'If System.IO.Directory.Exists(Carpeta) = False Then
            '    System.IO.Directory.CreateDirectory(Carpeta)
            'End If

            If File.Exists(Archivo) Then
                File.Delete(Archivo)
                strStreamW = File.Create(Archivo)
            Else
                strStreamW = File.Create(Archivo)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return strStreamW

    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PonerEnRutaEmbarque()
        ConsultarDocumentos()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        PonerEnEntregadoEmbarque()
        ConsultarDocumentos()

    End Sub

    Private Sub btnEstatusDev_Click(sender As Object, e As EventArgs) Handles btnEstatusDev.Click
        Dim listado As New FiltroEstatusEmbarqueForm
        listado.listaParametroID = GenerarListaSeleccionados(grdStatusDev)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusDev.DataSource = listado.listParametros
        grid_diseño(grdStatusDev)
    End Sub

    Public Function GenerarListaSeleccionados(grid As UltraGrid)
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grid.Rows
            Dim parametro As String = row.Cells("Parámetro").Text
            listaParametroID.Add(parametro)
        Next
        Return listaParametroID
    End Function

    Private Sub grdStatusDev_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusDev.InitializeLayout
        grid_diseño(grdStatusDev)
    End Sub
    Private Sub grdStatusDev_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdStatusDev.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdtransporte_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdTransporte.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdAtnClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdAtnClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdCliente_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdCliente.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'confirmar.mensaje = "¿Está seguro de Reembarcar este Folio?"
        'If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
        ReEmbarcarEmbarque()
        ConsultarDocumentos()
        'nd If
    End Sub
    Private Sub ReEmbarcarEmbarque()
        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim tipoEmbarque As Integer
        Dim FilasSeleccionadas As Integer = 0
        Dim pasas As Boolean = True
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then

                FilasSeleccionadas += 1

                If FilasSeleccionadas = 1 Then
                    tipoEmbarque = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "TipoEmbarque")
                    documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                Else
                    If tipoEmbarque = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Tipo Embarque") Then
                        documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                    Else
                        pasas = False
                    End If
                End If

            End If
        Next




        If FilasSeleccionadas > 0 Then

            If pasas <> True Then
                Utilerias.show_message(TipoMensaje.Advertencia, "Los embarques deben de ser del mismo tipo")
            Else
                confirmar.mensaje = "¿Está seguro de Reembarcar este Folio?"
                If confirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim motivoForm As New MotivoReembarqueForm
                    Dim motivo As String
                    motivoForm.StartPosition = FormStartPosition.CenterParent
                    If motivoForm.ShowDialog <> DialogResult.Cancel Then
                        motivo = motivoForm.motivo



                        Dim result = objInstancia.ReembarcarEmbarque(documentosSeleccionados, tipoEmbarque, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, motivo)

                        If result.Count > 0 And tipoEmbarque = 0 Then

                            Dim insta As New GuiaEmbarqueForm
                            insta.MdiParent = Me.MdiParent
                            insta.formEmbarques = Me
                            insta.lista = result
                            insta.Show()
                        Else
                            Dim insta As New GenerarOtrosEmbarquesForm
                            insta.MdiParent = Me.MdiParent
                            insta.formEmbarques = Me
                            insta.lista = result
                            insta.Show()
                        End If
                    End If
                End If
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un Folio de Embarque")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        AsignarNumerosRastreos()
        ConsultarDocumentos()
    End Sub
    Private Sub AsignarNumerosRastreos()
        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim mensajeria As String = String.Empty
        Dim FilasSeleccionadas As Integer = 0
        Dim pasas As Boolean = True
        Dim exisCancelado As Boolean = False

        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then
                FilasSeleccionadas += 1
                If FilasSeleccionadas = 1 Then
                    documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                    mensajeria = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Mensajeria")
                    If vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Estatus") = "CANCELADO" Then
                        exisCancelado = True
                    End If
                Else
                    Dim message = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Mensajeria")
                    If vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Estatus") = "CANCELADO" Then
                        exisCancelado = True
                    End If
                    If mensajeria = message Then
                        documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                    Else
                        pasas = False
                    End If
                End If


            End If
        Next
        If FilasSeleccionadas > 0 Then
            If exisCancelado <> True Then
                If pasas Then

                    Dim mensaje As New AsignarNumeroGuiaEmbarqueForm
                    mensaje.Numeroembarque = documentosSeleccionados
                    mensaje.Nombrepaqueteria = mensajeria
                    'mensaje.Parent = Parent
                    mensaje.StartPosition = FormStartPosition.CenterParent
                    mensaje.ShowDialog()
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona los embarques de una sola mensajería")
                End If
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "No puedes asignar numeros de rastreos a folios cancelados")
            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un Folio de Embarque")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnimpi.Click
        ImprimirEtiquetas()
    End Sub

    Private Sub ImprimirEtiquetas()
        Dim NumeroFilas = vwGuiasEmbarque.DataRowCount
        Dim documentosSeleccionados As String = String.Empty
        Dim cliente As String = String.Empty
        Dim tipo As Integer
        Dim FilasSeleccionadas As Integer = 0
        Dim pasas As Boolean = True
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Selección")) = True Then

                FilasSeleccionadas += 1

                If FilasSeleccionadas = 1 Then
                    tipo = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "TipoEmbarque")
                    cliente = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Cliente")
                    documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                Else
                    If cliente = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Cliente") Then
                        documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                    Else
                        pasas = False
                    End If
                    If tipo = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "Tipo Embarque") Then
                        documentosSeleccionados = documentosSeleccionados & "," & vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(index), "FolioEmbarque")
                    Else
                        pasas = False
                    End If
                End If

            End If
        Next




        If FilasSeleccionadas > 0 Then

            If pasas <> True Then
                Utilerias.show_message(TipoMensaje.Advertencia, "Los embarques deben de ser del mismo Cliente o del mismo Tipo de Embarque")
            Else
                Dim formm As New ImprimirEtiquetasEmbarqueForm
                formm.StartPosition = FormStartPosition.CenterParent
                formm.Cliente = cliente
                formm.Embarquesid = documentosSeleccionados
                formm.tipoEmbarque = tipo
                formm.ShowDialog()
                ConsultarDocumentos()

            End If
        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "Selecciona minimo un Folio de Embarque")
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 3
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 247
    End Sub
    Private Sub viewModelos_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwGuiasEmbarque.CustomDrawCell



        Dim status = vwGuiasEmbarque.GetRowCellValue(e.RowHandle, "StatusID")


        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "StatusID" Then
                If status = 388 Then
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.ForeColor = Color.Crimson
                ElseIf status = 387 Then
                    e.Appearance.BackColor = Color.Maroon
                    e.Appearance.ForeColor = Color.Maroon
                ElseIf status = 394 Then
                    e.Appearance.BackColor = Color.OrangeRed
                    e.Appearance.ForeColor = Color.OrangeRed
                ElseIf status = 385 Then
                    e.Appearance.BackColor = Color.Blue
                    e.Appearance.ForeColor = Color.Blue
                Else
                    e.Appearance.BackColor = Color.Aqua
                    e.Appearance.ForeColor = Color.Aqua
                End If
            End If

        End If


    End Sub

    Private Sub dtfechaIni_ValueChanged(sender As Object, e As EventArgs) Handles dtfechaIni.ValueChanged
        dtfechaFin.MinDate = dtfechaIni.Value
    End Sub

    Private Sub vwGuiasEmbarque_RowClick(sender As Object, e As RowClickEventArgs) Handles vwGuiasEmbarque.RowClick

        Try
            If e.Clicks = 2 Then
                Dim embarqueid = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(e.RowHandle), "FolioEmbarque")
                Dim tipoembarque = objInstancia.ConsultarTipoEmbarque(embarqueid)
                If tipoembarque.Rows(0).Item("TipoEmbarque") = 0 Then
                    Dim form As New DetallesGuiasEmbarquesForm
                    form.embarqueid = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(e.RowHandle), "FolioEmbarque")
                    form.MdiParent = Me.MdiParent
                    form.Show()
                Else
                    Dim form As New DetallesOtrosEmbarquesForm
                    form.embarqueid = vwGuiasEmbarque.GetRowCellValue(vwGuiasEmbarque.GetVisibleRowHandle(e.RowHandle), "FolioEmbarque")
                    form.MdiParent = Me.MdiParent
                    form.Show()
                End If
            End If
        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, "Ocurrio un error al consultar los detalles del embarque")
        End Try

    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click
        ListaTransporteid = New List(Of String)
        ListaTransportenombres = New List(Of String)
        grdTransporte.DataSource = Nothing
    End Sub

    Private Sub viewEmbarques_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwGuiasEmbarque.CustomDrawCell


        Try
            'If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Pares" Then
                e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                e.Column.DisplayFormat.FormatString = "##,##0"
            End If


        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim OBJBU2 As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim dsEmbarques As New DataSet("dsEmbarques")
        Dim dsTotales As New DataSet("dsTotales")
        Dim dtEmbarques As New DataTable("dtEmbarques")
        Dim dtTotales As New DataTable("dtTotales")
        EntidadReporte = OBJBU2.LeerReporteporClave("REPORTE_ESTADISTICA_EMBARQUES")

        Dim estatus = ObtenerFiltrosGrid(grdStatusDev)
        Dim guiasEmbarque = ObtenerFiltrosGrid(grdFiltroGuiaE)
        Dim clientes = ObtenerFiltrosGrid(grdCliente)
        Dim transporte = ObtenerFiltrosGrid(grdTransporte)
        Dim tipoempaque As Integer

        If rdTodos.Checked Then
            tipoempaque = 3
        ElseIf rdOtros.Checked Then
            tipoempaque = 2
        ElseIf rdNormal.Checked Then
            tipoempaque = 1
        End If



        dtEmbarques = objInstancia.ConsultarReporteEstadistica(If(cbfecha.Checked, 1, 0), dtfechaIni.Value, dtfechaFin.Value, guiasEmbarque, If(cbpendientes.Checked, 1, 0), If(cbconguia.Checked, 1, 0), clientes, tipoempaque, estatus, transporte)
        dtTotales = objInstancia.Consultar_ReporteEstadisticaTotalEmpaques(If(cbfecha.Checked, 1, 0), dtfechaIni.Value, dtfechaFin.Value, guiasEmbarque, If(cbpendientes.Checked, 1, 0), If(cbconguia.Checked, 1, 0), clientes, tipoempaque, estatus, transporte)
        Dim dtfechas = objInstancia.Consultar_ReporteEstadisticaFechas(If(cbfecha.Checked, 1, 0), dtfechaIni.Value, dtfechaFin.Value, guiasEmbarque, If(cbpendientes.Checked, 1, 0), If(cbconguia.Checked, 1, 0), clientes, tipoempaque, estatus, transporte)

        If dtEmbarques.Rows.Count > 0 Then

            dtEmbarques.TableName = "dtEmbarques"
            dtTotales.TableName = "dtTotales"

            dsEmbarques.Tables.Add(dtEmbarques)
            dsTotales.Tables.Add(dtTotales)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            LTrim(RTrim(EntidadReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport
            reporte.Load(archivo)
            reporte.Compile()
            reporte("fechaDel") = dtfechas.Rows(0).Item("FechaInicio")
            reporte("fechaAl") = dtfechas.Rows(0).Item("FechaFin")
            reporte("nombreCreo") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("nombreReporte") = "SAY: REPORTE_ESTADISTICA_EMBARQUES.mrt"
            reporte("semana") = CStr(dtfechas.Rows(0).Item("SemanaInicio")) + " A " + CStr(dtfechas.Rows(0).Item("SemanaFin"))

            reporte.Dictionary.Clear()
            reporte.RegData(dsEmbarques)
            reporte.RegData(dsTotales)
            reporte.Dictionary.Synchronize()
            reporte.Render()
            reporte.Show()

        Else
            Utilerias.show_message(TipoMensaje.Advertencia, "No se encontraron datos")
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Almacen/", "Descargas\Manuales\Almacen", "COVE_MAUS_GUIAS_EMBARQUE.pdf")
            Process.Start("Descargas\Manuales\Almacen\COVE_MAUS_GUIAS_EMBARQUE.pdf")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim listado As New FiltroAtnClienteForm
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAtnClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAtnClientes.DataSource = listado.listParametros
        With grdAtnClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Atn Clientes"
        End With

        grid_diseño(grdAtnClientes)
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        ListaAtnClienteid = New List(Of String)
        ListaAtnNombres = New List(Of String)
        grdAtnClientes.DataSource = Nothing
    End Sub

    Private Sub grdPedido_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedido.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedido.DeleteSelectedRows(False)
    End Sub

    Private Sub grdOT_KeyDown(sender As Object, e As KeyEventArgs) Handles grdOT.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdOT.DeleteSelectedRows(False)
    End Sub

    Private Sub grdRemision_KeyDown(sender As Object, e As KeyEventArgs) Handles grdRemision.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdRemision.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub txtFiltroPedido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroPedido.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroPedido.Text) Then Return
            ListaPedido.Add(txtFiltroPedido.Text)
            grdPedido.DataSource = Nothing
            grdPedido.DataSource = ListaPedido
            txtFiltroPedido.Text = String.Empty
            DisenoGridFiltros(grdPedido, "Pedido")
        End If
    End Sub

    Private Sub txtFiltroOt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroOt.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroOt.Text) Then Return
            ListaOT.Add(txtFiltroOt.Text)
            grdOT.DataSource = Nothing
            grdOT.DataSource = ListaOT
            txtFiltroOt.Text = String.Empty
            DisenoGridFiltros(grdOT, "OT")
        End If
    End Sub

    Private Sub txtFiltroRemision_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroRemision.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroRemision.Text) Then Return
            ListaRemison.Add(txtFiltroRemision.Text)
            grdRemision.DataSource = Nothing
            grdRemision.DataSource = ListaRemison
            txtFiltroRemision.Text = String.Empty
            DisenoGridFiltros(grdRemision, "Remisión")
        End If
    End Sub

    Private Sub txtFiltroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFactura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFactura.Text) Then Return
            ListaFactura.Add(txtFiltroFactura.Text)
            grdFactura.DataSource = Nothing
            grdFactura.DataSource = ListaFactura
            txtFiltroFactura.Text = String.Empty
            DisenoGridFiltros(grdFactura, "Factura")
        End If
    End Sub

    Public Sub DisenoGridFiltros(grid As UltraGrid, titulo As String)
        With grid.DisplayLayout.Bands(0)
            If .Columns.Count = 1 Then
                .Columns(0).Header.Caption = titulo
            End If
        End With

        With grid.DisplayLayout
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.False
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.False
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

        If grid.DisplayLayout.Bands(0).Columns.Exists(" ") Then
            grid.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        End If

        If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
            grid.DisplayLayout.Bands(0).Columns("Parámetro").Hidden = True
        End If

    End Sub

    Private Sub grdPedido_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedido.InitializeLayout
        DisenoGridFiltros(grdPedido, "Pedido")
    End Sub

    Private Sub grdOT_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdOT.InitializeLayout
        DisenoGridFiltros(grdOT, "OT")
    End Sub

    Private Sub grdRemision_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdRemision.InitializeLayout
        DisenoGridFiltros(grdRemision, "Remisión")
    End Sub

    Private Sub grdFactura_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFactura.InitializeLayout
        DisenoGridFiltros(grdFactura, "Factura")
    End Sub

    Private Sub grdFiltroGuiaE_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroGuiaE.InitializeLayout
        DisenoGridFiltros(grdFiltroGuiaE, "GuiaEmbarque")
    End Sub

    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        DisenoGridFiltros(grdCliente, "Cliente")
    End Sub

    Private Sub grdTransporte_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdTransporte.InitializeLayout
        DisenoGridFiltros(grdTransporte, "Transporte")
    End Sub

    Private Sub grdAtnClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAtnClientes.InitializeLayout
        DisenoGridFiltros(grdAtnClientes, "Atn cliente")
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub
End Class
