Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Public Class AdministradorDeclaracionesComplementarias_Form
    Dim lstInicial As New List(Of String)
    Dim EmpresaId As String = String.Empty
    Dim Anio As Integer = 0

    Dim errormensaje As New ErroresForm
    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeExito As New Tools.ExitoForm
    Dim ObjBU As New Negocios.SolicitarCancelacionBU

    Private Sub AdministradorDeclaracionesComplementarias_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarFiltroEm_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEm.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 26
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdEmpresa.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdEmpresa.DataSource = listado.listParametros
        With grdEmpresa
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Empresa"
        End With
    End Sub

    Private Sub btnLimpiarFiltroE_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroE.Click
        grdEmpresa.DataSource = lstInicial
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        ''limpiarGrid()
        ConsultarDeclaraciones()
        lblFechaUltimaActualización.Text = DateTime.Now.ToString()
        Cursor = Cursors.Default
    End Sub



    Private Function ConsultarDeclaraciones()
        Try
            Anio = nupAño.Value
            Dim dtResultadoAdministrador As New DataTable
            If Anio > 0 Then
                EmpresaId = ObtenerFiltrosGrid(grdEmpresa)

                Dim dtActualiza As New DataTable
                Dim resultadoConsulta = 0
                dtResultadoAdministrador = ObjBU.ConsultarDeclaraciones(EmpresaId, Anio)
                grdDeclaraciones.DataSource = Nothing

                If dtResultadoAdministrador.Rows.Count > 0 Then
                    ''limpiarGrid()
                    DiseñoGrid()
                    grdDeclaraciones.DataSource = dtResultadoAdministrador
                Else
                    objMensajeValido.Text = "Aviso"
                    objMensajeValido.mensaje = "No hay datos para mostrar."
                    objMensajeValido.ShowDialog()
                End If

                lblTotalRegistros.Text = dtResultadoAdministrador.Rows.Count.ToString("N0")
            Else
                objMensajeValido.Text = "Aviso"
                objMensajeValido.mensaje = "Debe selecionar un año"
                objMensajeValido.ShowDialog()
            End If
        Catch ex As Exception
            errormensaje.Text = "Error"
            objMensajeValido.mensaje = ex.Message.ToString
            objMensajeValido.ShowDialog()
        End Try
    End Function

    Private Sub DiseñoGrid()

        bgvDeclaraciones.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDeclaraciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next


        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        bgvDeclaraciones.OptionsView.AllowCellMerge = True
        bgvDeclaraciones.Columns.Clear()
        'bgvDeclaraciones.Bands.Clear()

        band = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
        'band.Fixed = Columns.FixedStyle.Left
        band.Caption = ""

        bgvDeclaraciones.Columns.AddField("empresaid")
        'grdTarjetaAlmacen.Columns.ColumnByFieldName("empresaid").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("empresaid").Visible = False


        bgvDeclaraciones.Columns.AddField("nombre")
        'bgvDeclaraciones.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("nombre").Visible = True
        bgvDeclaraciones.Columns.ColumnByFieldName("nombre").OptionsColumn.AllowEdit = False
        bgvDeclaraciones.Columns.ColumnByFieldName("nombre").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True
        bgvDeclaraciones.Columns.ColumnByFieldName("nombre").Caption = "Empresa"
        bgvDeclaraciones.Columns.ColumnByFieldName("nombre").Width = 400
        bgvDeclaraciones.Columns.ColumnByFieldName("nombre").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvDeclaraciones.Columns.AddField("Mes")
        'bgvDeclaraciones.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("Mes").Visible = True
        bgvDeclaraciones.Columns.ColumnByFieldName("Mes").OptionsColumn.AllowEdit = False
        bgvDeclaraciones.Columns.ColumnByFieldName("Mes").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        bgvDeclaraciones.Columns.ColumnByFieldName("Mes").Caption = "Mes"
        bgvDeclaraciones.Columns.ColumnByFieldName("Mes").Width = 60
        bgvDeclaraciones.Columns.ColumnByFieldName("Mes").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


        bgvDeclaraciones.Columns.AddField("Año")
        'bgvDeclaraciones.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("Año").Visible = True
        bgvDeclaraciones.Columns.ColumnByFieldName("Año").OptionsColumn.AllowEdit = False
        bgvDeclaraciones.Columns.ColumnByFieldName("Año").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        bgvDeclaraciones.Columns.ColumnByFieldName("Año").Caption = "Año"
        bgvDeclaraciones.Columns.ColumnByFieldName("Año").Width = 40
        bgvDeclaraciones.Columns.ColumnByFieldName("Año").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


        bgvDeclaraciones.Columns.AddField("1RA")
        'bgvDeclaraciones.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("1RA").Visible = True
        bgvDeclaraciones.Columns.ColumnByFieldName("1RA").OptionsColumn.AllowEdit = False
        bgvDeclaraciones.Columns.ColumnByFieldName("1RA").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        bgvDeclaraciones.Columns.ColumnByFieldName("1RA").Caption = "1RA"
        bgvDeclaraciones.Columns.ColumnByFieldName("1RA").Width = 80
        bgvDeclaraciones.Columns.ColumnByFieldName("1RA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvDeclaraciones.Columns.AddField("2DA")
        'bgvDeclaraciones.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("2DA").Visible = True
        bgvDeclaraciones.Columns.ColumnByFieldName("2DA").OptionsColumn.AllowEdit = False
        bgvDeclaraciones.Columns.ColumnByFieldName("2DA").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        bgvDeclaraciones.Columns.ColumnByFieldName("2DA").Caption = "2DA"
        bgvDeclaraciones.Columns.ColumnByFieldName("2DA").Width = 80
        bgvDeclaraciones.Columns.ColumnByFieldName("2DA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvDeclaraciones.Columns.AddField("3RA")
        'bgvDeclaraciones.Columns.ColumnByFieldName("DescripcionCompleta").OwnerBand = band
        bgvDeclaraciones.Columns.ColumnByFieldName("3RA").Visible = True
        bgvDeclaraciones.Columns.ColumnByFieldName("3RA").OptionsColumn.AllowEdit = False
        bgvDeclaraciones.Columns.ColumnByFieldName("3RA").OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False
        bgvDeclaraciones.Columns.ColumnByFieldName("3RA").Caption = "3RA"
        bgvDeclaraciones.Columns.ColumnByFieldName("3RA").Width = 80
        bgvDeclaraciones.Columns.ColumnByFieldName("3RA").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'bgvDeclaraciones.Bands.Add(band)


        'grdVentas.Columns.ColumnByFieldName("Restriccion Facturación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'grdVentas.Columns.ColumnByFieldName("UsuarioCaptura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'grdVentas.Columns.ColumnByFieldName("Agente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'grdVentas.Columns.ColumnByFieldName("STATUS").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'grdVentas.Columns.ColumnByFieldName("PedidoSICY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        'grdVentas.Columns.ColumnByFieldName("PedidoSAY").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains


        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(bgvDeclaraciones)
        bgvDeclaraciones.IndicatorWidth = 40
    End Sub

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String

        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return Resultado

    End Function

    Private Sub grdEmpresa_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmpresa.InitializeLayout
        grid_diseño(grdEmpresa)
        grdEmpresa.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Empresa"
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

        asignaFormato_Columna(grid)

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
    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Try
            Dim FormularioAltaMotivosCancelacion As New AltasDeclaracionesComplementarias_Form
            FormularioAltaMotivosCancelacion.ShowDialog()
            btnAceptar_Click(Nothing, Nothing)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub bgvDeclaraciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvDeclaraciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

    Private Function Exportar()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Dim nombreReporteParaExportacion As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            If bgvDeclaraciones.DataRowCount > 0 Then
                nombreReporte = "\ReporteDeclaracionesComplementarias_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvDeclaraciones.GroupCount > 0 Then
                            bgvDeclaraciones.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            bgvDeclaraciones.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        End If
                        objMensajeExito.Text = "Exito"
                        objMensajeExito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        objMensajeExito.ShowDialog()
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                objMensajeValido.Text = "Aviso"
                objMensajeValido.mensaje = "No hay datos para exportar."
                objMensajeValido.ShowDialog()
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            objMensajeValido.Text = "Aviso"
            objMensajeValido.mensaje = "No hay datos para exportar."
            objMensajeValido.ShowDialog()
        End Try
    End Function

    Private Sub grdEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEmpresa.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEmpresa.DeleteSelectedRows(False)
    End Sub

    Private Sub AdministradorDeclaracionesComplementarias_Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F1 Then
            Try
                Dim FormularioAltaMotivosCancelacion As New AltasDeclaracionesComplementarias_Form
                FormularioAltaMotivosCancelacion.ShowDialog()
                btnAceptar_Click(Nothing, Nothing)
            Catch ex As Exception

            End Try
        End If
        If e.KeyData = Keys.F5 Then
            Cursor = Cursors.WaitCursor
            ''limpiarGrid()
            ConsultarDeclaraciones()
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()
            Cursor = Cursors.Default
        End If
        If e.KeyData = Keys.F9 Then
            Exportar()
        End If
        If e.KeyData = Keys.Escape Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If

    End Sub
End Class