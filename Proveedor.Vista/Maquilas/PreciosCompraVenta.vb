Imports System.Drawing
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Tools

Public Class PreciosCompraVenta

#Region "Variables Globales"

    Private ReadOnly ADV As New AdvertenciaForm

#End Region

#Region "Eventos"

    Private Sub PreciosCompraVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComercializadora()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdListaPrecios.Rows.Count > 0 Then
            ExportarExcel(grdListaPrecios)
        Else
            Dim ventanaMensaje As New AdvertenciaForm With {
                .mensaje = "No hay información para exportar"
            }
            ventanaMensaje.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        Dim obj As New ListaPreciosProdBU

        If cmbComercializadora.SelectedIndex > 0 Then
            Dim filtro_Nave = String.Empty
            For Each Row As UltraGridRow In grdNaves.Rows
                If filtro_Nave <> "" Then
                    filtro_Nave += ","
                End If
                filtro_Nave += Row.Cells(0).Value.ToString()
            Next

            Dim datos As DataTable = obj.getDatosPreciosVentas(filtro_Nave, cmbComercializadora.SelectedValue)

            grdListaPrecios.DataSource = datos
            DisenioGrid()
        Else
            ADV.mensaje = "Seleccione una Comercializadora"
            ADV.ShowDialog()
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub BntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Close()
    End Sub

    Private Sub BtnNave_Click(sender As Object, e As EventArgs) Handles btnNave.Click
        Dim listado As New ListaParametrosForm

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.tipo_Nave = 0
        listado.listaPatametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listaParametros
        Grid_diseño(grdNaves)
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub BtnLimNave_Click(sender As Object, e As EventArgs) Handles btnLimNave.Click
        grdNaves.DataSource = Nothing
    End Sub

    Private Sub GrdNaves_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdNaves.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        grbParametros.Height = 167
    End Sub

    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        grbParametros.Height = 30
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub LlenarComercializadora()
        Dim obj As New ListaPreciosProdBU
        Dim lst As DataTable = obj.getcomercializadoras()
        If Not lst.Rows.Count = 0 Then
            lst.Rows.InsertAt(lst.NewRow, 0)
            cmbComercializadora.DataSource = lst
            cmbComercializadora.DisplayMember = "Nombre"
            cmbComercializadora.ValueMember = "Id"
            cmbComercializadora.SelectedIndex = 1
        End If
    End Sub

    Private Sub ExportarExcel(grid As UltraGrid)
        Dim sfd As New SaveFileDialog With {
            .DefaultExt = "xls",
            .Filter = "Excel Files|*.xls"
        }
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grid, fileName)
                Dim objMensajeExito As New Tools.ExitoForm With {
                    .mensaje = "Archivo exportado correctamente en la ubicación: " + fileName,
                    .StartPosition = FormStartPosition.CenterScreen
                }
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm With {
                    .mensaje = "El documento no pud o exportarse." + vbLf + ex.Message,
                    .StartPosition = FormStartPosition.CenterScreen
                }
                objMensajeError.ShowDialog()
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Grid_diseño(grid As UltraGrid)
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
        AsignaFormato_Columna(grid)
    End Sub

    Private Sub AsignaFormato_Columna(grid As UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub

    Public Sub DisenioGrid()
        Try
            With grdListaPrecios.DisplayLayout.Bands(0)
                .Columns("mere_empresaereceptoraidsay").Hidden = True
                .Columns("IdNave").Hidden = True
                .Columns("status").Hidden = True
                .Columns("IdColeccion").Hidden = True
                .Columns("IdMarca").Hidden = True
                .Columns("Precio Compra").Format = "####0.00"
                .Columns("Precio Venta").Format = "####0.00"
                .Columns("idPrecio").Hidden = True
                .Columns("idLista").Hidden = True
                .Columns("pres_activo").Hidden = True
                .PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)

                .Columns("Precio Compra").Width = 90
                .Columns("Precio Venta").Width = 90

                .Columns("Marca").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                grdListaPrecios.DisplayLayout.Scrollbars = UltraWinGrid.Scrollbars.Automatic
                .Columns("Colección").Width = 100

                .Columns("Inicio").Width = 62
                .Columns("Fin").Width = 62
                .Columns("FCreación").Width = 62
                .Columns("FAutorización").Width = 95
                .Columns("FModificación").Width = 90
                .Columns("FCreación").Style = UltraWinGrid.ColumnStyle.DateTime
                .Columns("FModificación").Style = UltraWinGrid.ColumnStyle.DateTime
                If .Columns.Exists("FAutorización") = True Then
                    .Columns("FAutorización").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
                End If
            End With

            grdListaPrecios.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        Catch ex As Exception
            Dim vError As New ErroresForm With {
                .mensaje = "Ocurrió un error: " & ex.Message
            }
            vError.ShowDialog()
        End Try
    End Sub

#End Region

End Class