Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Tools.Utilerias
Imports Ventas.Vista

Public Class AdministradorDocumentosForm
    Dim objInstancia As New AdministradorDocumentosBU
    Dim ListaDocto As New List(Of String)
    Dim ListaFacturas As New List(Of String)
    Dim ListaClientesid As New List(Of String)
    Dim ListaClientesnombres As New List(Of String)
    Dim FilasSeleccionadas As Integer


    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 8
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 158
    End Sub

    Private Sub AdministradorDocumentosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtfechaIni.Value = Date.Now
        dtfechaFin.Value = Date.Now
        If cbfecha.Checked Then
            dtfechaIni.Enabled = True
            dtfechaFin.Enabled = True
        Else
            dtfechaIni.Enabled = False
            dtfechaFin.Enabled = False
        End If
        llenarCombo()
        ConsultarDocumentos()
    End Sub
    Private Sub llenarCombo()
        Dim datosRestricciones = objInstancia.ConsultarRestricciones()
        cbRestriccion.DataSource = datosRestricciones
        cbRestriccion.DisplayMember = "Restriccion"
        cbRestriccion.ValueMember = "ID"
    End Sub
    Public Sub ConsultarDocumentos()
        Cursor = Cursors.WaitCursor
        vwDocumentos.Columns.Clear()
        grdDocumentos.DataSource = Nothing
        Dim documnentos = ObtenerFiltrosGrid(grdDocto)
        Dim facturas = ObtenerFiltrosGrid(grdFolioCFDI)
        Dim clientes = ObtenerFiltrosGrid(grdCliente)
        Dim verCoppel As Integer
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FRM_GRD_ADM_DOCUMENTOS", "ADM_DOC_VER_COPPEL") Then
            verCoppel = 1
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FRM_GRD_ADM_DOCUMENTOS", "ADM_DOC_VER_OTROS_CLIENTES") Then
            verCoppel = 2
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("FRM_GRD_ADM_DOCUMENTOS", "ADM_DOC_VER_TODOS") Then
            verCoppel = 3
        End If

        Dim datos = objInstancia.ConsultarDocumentos(If(cbfecha.Checked, 1, 0), dtfechaIni.Value, dtfechaFin.Value, cbRestriccion.SelectedValue, documnentos, facturas, clientes, verCoppel)
        grdDocumentos.DataSource = datos
        vwDocumentos.OptionsView.ColumnAutoWidth = True
        DiseñoGrid.DiseñoBaseGrid(vwDocumentos)
        DiseñoGrid.EstiloColumna(vwDocumentos, " ", " ", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, True, True, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwDocumentos, "DocumentoSayId", "DocumentoSayId", False, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwDocumentos, "Tipo Documento", "Tipo" & vbCrLf & "Documento", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 80, False, Nothing, "#,0#")
        'DiseñoGrid.EstiloColumna(vwDocumentos, "Año Remisión", "Año" & vbCrLf & "Remisión", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwDocumentos, "Restricción de Facturación", "Restricción de" & vbCrLf & "Facturación", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 125, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwDocumentos, "Tienda de embarque", "Tienda de" & vbCrLf & "Embarque", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwDocumentos, "Dirección de embarque", "Dirección de" & vbCrLf & "Embarque", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, False, 250, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwDocumentos, "Fecha factura", "Fecha" & vbCrLf & "Factura", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "#,0#")
        'DiseñoGrid.EstiloColumna(vwDocumentos, "Fecha de timbrado", "Fecha" & vbCrLf & "Timbrado", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, False, Nothing, "#,0#")
        DiseñoGrid.EstiloColumna(vwDocumentos, "Pares facturados", "Pares" & vbCrLf & "Facturados", True, DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains, False, True, 60, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")

        vwDocumentos.IndicatorWidth = 40

        lblTotalParesProceso.Text = String.Format("{0:N0}", datos.Rows.Count)
        lblFechaUltimaActualizacion.Text = Date.Now
        Cursor = Cursors.Default
    End Sub

    Private Sub dtfechaIni_ValueChanged(sender As Object, e As EventArgs) Handles dtfechaIni.ValueChanged
        dtfechaFin.MinDate = dtfechaIni.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ConsultarDocumentos()
    End Sub

    Private Sub viewInventario_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwDocumentos.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle + 1
        End If

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
                    If vwDocumentos.GroupCount > 0 Then
                        vwDocumentos.ExportToXlsx(.SelectedPath + "\DocumentosEmbar_" + fecha_hora + ".xlsx", exportOptions)
                    Else
                        vwDocumentos.ExportToXlsx(.SelectedPath + "\DocumentosEmbar_" + fecha_hora + ".xlsx", exportOptions)
                    End If
                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "DocumentosEmbar_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\DocumentosEmbar_" + fecha_hora + ".xlsx")

                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtFiltroFolioFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroDocto.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroDocto.Text) Then Return

            ListaDocto.Add(txtFiltroDocto.Text)
            grdDocto.DataSource = Nothing
            grdDocto.DataSource = ListaDocto

            txtFiltroDocto.Text = String.Empty
            With grdDocto
                .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Documento"
            End With
        End If
    End Sub

    Private Sub txtFiltroFolioCFDI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioCFDI.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioCFDI.Text) Then Return

            ListaFacturas.Add(txtFiltroFolioCFDI.Text)

            grdFolioCFDI.DataSource = Nothing
            grdFolioCFDI.DataSource = ListaFacturas
            txtFiltroFolioCFDI.Text = String.Empty
            With grdFolioCFDI
                .DisplayLayout.Bands(0).Columns(0).Header.Caption = "Factura"
            End With
        End If
    End Sub
    Private Sub grdDocto_KeyDown(sender As Object, e As KeyEventArgs) Handles grdDocto.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdDocto.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioCFDI.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioCFDI.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
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
        'Dim objFiltroFrm As New frmFiltroClientes
        'objFiltroFrm.ShowDialog()

        'If String.IsNullOrEmpty(objFiltroFrm.nomCliente) Then Return

        'ListaClientesid.Add(objFiltroFrm.idCliente)
        'ListaClientesnombres.Add(objFiltroFrm.nomCliente)
        'grdCliente.DataSource = Nothing
        'grdCliente.DataSource = ListaClientesnombres

        'grdclientesid.DataSource = Nothing
        'grdclientesid.DataSource = ListaClientesid

        grid_diseño(grdCliente)

    End Sub

    'Public Sub formatoGridsgrdClientes()
    '    '	
    '    With grdCliente.DisplayLayout.Bands(0)
    '        .Columns("Value").Header.Caption = "Cliente"

    '        .Columns("Value").CellActivation = Activation.NoEdit

    '        .Columns("Value").CellAppearance.TextHAlign = HAlign.Center

    '    End With



    '    grdCliente.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
    '    grdCliente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    grdCliente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '    grdCliente.DisplayLayout.Override.RowSelectorWidth = 35
    '    grdCliente.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
    '    grdCliente.Rows(0).Selected = True

    '    grdCliente.DisplayLayout.Bands(0).Columns("Value").Width = 150
    'End Sub
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

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        ListaClientesid = New List(Of String)
        ListaClientesnombres = New List(Of String)
        grdCliente.DataSource = Nothing
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

    Private Sub cbfecha_CheckedChanged(sender As Object, e As EventArgs) Handles cbfecha.CheckedChanged
        If cbfecha.Checked Then
            dtfechaIni.Enabled = True
            dtfechaFin.Enabled = True
        Else
            dtfechaIni.Enabled = False
            dtfechaFin.Enabled = False
        End If
    End Sub

    Private Sub btnGenerarEmbarque_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        GenerarEmbarque()
        ConsultarDocumentos()
    End Sub

    Private Function GenerarEmbarque()
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        FilasSeleccionadas = 0

        Cursor = Cursors.WaitCursor

        Try
            Dim listaClientes As New List(Of String)
            Dim listaTiendas As New List(Of String)
            Dim listaPago As New List(Of String)
            Dim listaOrden As New List(Of String)
            Dim listaDocumentos As New List(Of Entidades.NivelDocumentos)
            NumeroFilas = vwDocumentos.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    documentosSeleccionados = documentosSeleccionados & "," & vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(index), "DocumentoSayId")

                End If
            Next
            If FilasSeleccionadas > 0 Then
                Dim resultados = objInstancia.ValidarDocumentos(documentosSeleccionados, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                If resultados(0).Documento <> "0" Then

                    Dim insta As New GuiaEmbarqueForm
                    insta.MdiParent = Me.MdiParent
                    insta.lista = resultados
                    insta.formDocumentos = Me
                    insta.Show()
                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, resultados(0).Error.Mensaje)
                End If
            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Debes Seleccionar por lo menos un Folio de Embarque")
            End If

        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message.ToString())
        End Try

        Cursor = Cursors.Default

        Return documentosSeleccionados

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cbRestriccion.SelectedValue = 0

        ListaDocto = New List(Of String)
        ListaFacturas = New List(Of String)
        ListaClientesid = New List(Of String)
        ListaClientesnombres = New List(Of String)

        grdCliente.DataSource = Nothing
        grdFolioCFDI.DataSource = Nothing
        grdDocto.DataSource = Nothing



        dtfechaIni.Value = Date.Now
        dtfechaFin.Value = Date.Now
        cbfecha.Checked = False
        If cbfecha.Checked Then
            dtfechaIni.Enabled = True
            dtfechaFin.Enabled = True
        Else
            dtfechaIni.Enabled = False
            dtfechaFin.Enabled = False
        End If
    End Sub
    Private Sub viewDocumento_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles vwDocumentos.CustomDrawCell


        Try
            'If e.RowHandle >= 0 Then
            If e.Column.FieldName = "Pares facturados" Then
                e.Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                e.Column.DisplayFormat.FormatString = "N0"
            End If

            'End If

        Catch ex As Exception
            Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnEmbarqueDinamico_Click(sender As Object, e As EventArgs) Handles btnEmbarqueDinamico.Click
        GenerarEmbarqueDinamico()
    End Sub


    Private Function GenerarEmbarqueDinamico()
        Dim documentosSeleccionados As String = String.Empty
        Dim NumeroFilas As Integer
        Dim Resultado As Boolean = False
        Dim EmbarqueId As Integer = 0
        FilasSeleccionadas = 0

        Try
            Dim listaClientes As New List(Of String)
            Dim listaTiendas As New List(Of String)
            Dim listaPago As New List(Of String)
            Dim listaOrden As New List(Of String)
            Dim listaDocumentos As New List(Of Entidades.NivelDocumentos)
            Dim objSessionGuiaEmbarque As New Entidades.SessionGuiaEmbarque

            NumeroFilas = vwDocumentos.DataRowCount

            Cursor = Cursors.WaitCursor

            For index As Integer = 0 To NumeroFilas Step 1

                If CBool(vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(index), " ")) = True Then
                    FilasSeleccionadas += 1
                    documentosSeleccionados = documentosSeleccionados & "," & vwDocumentos.GetRowCellValue(vwDocumentos.GetVisibleRowHandle(index), "DocumentoSayId")

                End If
            Next



            If FilasSeleccionadas > 0 Then
                Resultado = objInstancia.ValidarClientesGuiaEmbarqueDinamico(documentosSeleccionados)

                If Resultado = True Then
                    objSessionGuiaEmbarque = objInstancia.GenerarInformacionGuiaEmbarqueDinamico(documentosSeleccionados, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    If objSessionGuiaEmbarque.PEmbarqueID = 0 Then
                        Utilerias.show_message(TipoMensaje.Aviso, "Algun documento seleccionado esta en proceso de embarque.")
                    Else
                        Dim insta As New GuiaEmbarqueDinamicoForm
                        'insta.MdiParent = Me.MdiParent
                        'insta.lista = resultados
                        'insta.formDocumentos = Me
                        insta.EmbarqueID = objSessionGuiaEmbarque.PEmbarqueID
                        insta.SessionId = objSessionGuiaEmbarque.PSessionID
                        insta.DocumentosSeleccionadosId = documentosSeleccionados
                        insta.Show()
                    End If

                Else
                    Utilerias.show_message(TipoMensaje.Advertencia, "No se pueden combinar clientes diferentes")
                End If


            Else
                Utilerias.show_message(TipoMensaje.Advertencia, "Debes Seleccionar por lo menos un Folio de Embarque")
            End If

        Catch ex As Exception
            Utilerias.show_message(TipoMensaje.Advertencia, ex.Message.ToString())
        End Try

        Cursor = Cursors.Default

        Return documentosSeleccionados

    End Function


End Class