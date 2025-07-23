Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class pruebainfra
    Dim idEstatus As Int32

    Public Property Pestatus As Int32
        Get
            Return idEstatus
        End Get
        Set(value As Int32)
            idEstatus = value
        End Set
    End Property

    Public Sub llenarTablaModelos()
        Dim objModBU As New Negocios.ProductosBU
        Dim dtModelos As New DataTable
        dtModelos = objModBU.verModelosRegistrador(CBool(rdoActivo.Checked))
        grdModelos.DataSource = dtModelos

        grdModelos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdModelos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdModelos.DisplayLayout.Override.RowSelectorWidth = 45
        grdModelos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True

        With grdModelos.DisplayLayout.Bands(0)
            .Columns("marc_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prod_codigo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Familia Ventas").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("grpo_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("tica_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Subfamilia").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("temp_nombre").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fami_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("plmu_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("forr_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("linea_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("suel_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("horma_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("pres_codSicy").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("stpr_descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Clave SAT").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ModeloSICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("SuelaProgramacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ColorSuela").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Imagen").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("SuelaProgramacion").Header.Caption = "Suela Programación"
            .Columns("ColorSuela").Header.Caption = "Color Suela"
            .Columns("ModeloSICY").Header.Caption = "Modelo SICY"
            .Columns("prod_codigo").Header.Caption = "Modelo SAY"
            .Columns("prod_descripcion").Header.Caption = "Descripción"
            .Columns("grpo_descripcion").Header.Caption = "Grupo"
            .Columns("grpo_descripcion").Hidden = True '27/07/2020 no debe desaparecer
            .Columns("tica_descripcion").Hidden = True '27/07/2020
            .Columns("SubFamilia").Hidden = True '27/07/2020
            .Columns("fami_descripcion").Hidden = True
            .Columns("linea_descripcion").Hidden = True
            .Columns("pres_codSicy").Hidden = True
            .Columns("ColorSuela").Hidden = True
            ' .Columns("prod_descripcion").Hidden = True '03/08/2020
            '  .Columns("DescripcionCompleta").Header.Caption = "Descripción" '03/08/2020
            '.Columns("tica_descripcion").Header.Caption = "Tipo"
            .Columns("temp_nombre").Header.Caption = "Temporada"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            '.Columns("fami_descripcion").Header.Caption = "Familia"
            .Columns("talla_descripcion").Header.Caption = "Talla"
            .Columns("plmu_descripcion").Header.Caption = "Corte"
            .Columns("forr_descripcion").Header.Caption = "Forro"
            '.Columns("linea_descripcion").Header.Caption = "Linea"
            .Columns("suel_descripcion").Header.Caption = "Suela"
            .Columns("horma_descripcion").Header.Caption = "Horma"
            '.Columns("pres_codSicy").Header.Caption = "Sicy"
            .Columns("stpr_descripcion").Header.Caption = "Estatus"
            ' .Columns("SubFamilia").Header.Caption = "Aplicaciones"
            .Columns("Familia Ventas").Header.Caption = "Familia de Ventas"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        'grdModelos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

    End Sub

    Private Sub pruebainfra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rdoActivo.Checked = True
        'llenarTablaModelos()
        'Me.Opacity = 0.75
        'Dim objEstatus As New SeleccionEstatusProducto
        'If objEstatus.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Pestatus = objEstatus.PIdEstatus
        '    Dim objRegistrarProd As New RegistraProductosForm
        '    Me.Close()
        '    objRegistrarProd.ShowDialog()
        'Else
        '    Me.Close()
        'End If
    End Sub

    Private Sub UltraGrid1_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdModelos.InitializeLayout
        Me.grdModelos.DisplayLayout.GroupByBox.Prompt = "Arrastra columnas para agruparlas."
    End Sub

    Private Sub rdoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoActivo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        llenarTablaModelos()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub rdoInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoInactivo.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        llenarTablaModelos()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdModelos.Rows.Count > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xlsx"
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            'sfd.Filter = "XLS files (*.xls)|*.xls"
            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName
            If result = Windows.Forms.DialogResult.OK Then
                Try
                    Me.Cursor = Cursors.WaitCursor
                    Me.ultraExportEXL.Export(grdModelos, fileName)
                    Process.Start(fileName)
                    Me.Cursor = Cursors.Default
                Catch ex As Exception
                    MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento xlsx " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atención")

                End Try

            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class