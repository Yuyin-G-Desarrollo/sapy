Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools

Public Class ConsultaDetalladaForm

    Public Operador As String = String.Empty
    Public Naves As String
    Public Piezas As String
    Public Clientes As String
    Public PedidosM As String
    Public Articulos As String
    Public Corridas As String
    Public tallas As String
    Public strFEntregaNave As String = ""
    Public strFEntregaCliente As String = ""
    Public strFEnvioDeNave As String = ""
    Public strFRecepcionComer As String = ""
    Public nombreCedis As String = ""

    Dim fecha1 As Date
    Dim fecha2 As Date
    Dim SATC As String
    Dim EATN As String
    Private _DataConsulta As DataTable
    Public Property DataConsulta() As DataTable
        Get
            Return _DataConsulta
        End Get
        Set(ByVal value As DataTable)
            _DataConsulta = value
        End Set
    End Property
    Private Sub ConsultaDetalladaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.WaitCursor
        grdDetallada.DataSource = _DataConsulta
        DiseñoGrid(grdVDetallada)
        CalcularPorcentaje(_DataConsulta)
        lblUltimaActualizacion.Text = Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
        lblcedis.Text = nombreCedis
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DiseñoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVDetallada_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        ' Grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

        Grid.OptionsView.ColumnAutoWidth = False
        Grid.BestFitColumns()
        Tools.DiseñoGrid.AjustarAltoEncabezados(Grid)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(Grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)
        Tools.DiseñoGrid.DeshabilitarEdicion(Grid)
        Tools.DiseñoGrid.FiltroContiene(Grid)


        Grid.Columns.ColumnByFieldName("nave_nombre").Caption = "Nave"
        Grid.Columns.ColumnByFieldName("FechaEnvío").Caption = "F Envío"
        Grid.Columns.ColumnByFieldName("FechaRecepción").Caption = "F Recepción"
        Grid.Columns.ColumnByFieldName("FEntregaCliente").Caption = "F Entrega" + vbCrLf + "Cliente"
        Grid.Columns.ColumnByFieldName("FEntregaNave").Caption = "F Entrega " + vbCrLf + "Nave"
        Grid.Columns.ColumnByFieldName("MarcaSAY").Caption = "Marca"
        Grid.Columns.ColumnByFieldName("ColeccionSAY").Caption = "Colección"
        Grid.Columns.ColumnByFieldName("ModeloSAY").Caption = "Modelo" + vbCrLf + "SAY"
        Grid.Columns.ColumnByFieldName("ModeloSICY").Caption = "Modelo" + vbCrLf + "SICY"
        Grid.Columns.ColumnByFieldName("OrdenProd").Caption = "Orden" + vbCrLf + "Prod"
        Grid.Columns.ColumnByFieldName("nave_nombre").Caption = "Nave"
        Grid.Columns.ColumnByFieldName("nave_nombre").Caption = "Nave"
        Grid.Columns.ColumnByFieldName("nave_nombre").Caption = "Nave"
        Grid.Columns.ColumnByFieldName("nave_nombre").Caption = "Nave"
        Grid.Columns.ColumnByFieldName("cedisId").Visible = False

        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        'If IsNothing(Grid.Columns("Cant.").Summary.FirstOrDefault(Function(x) x.FieldName = "Cant.")) = True Then
        '    Grid.Columns("Cant.").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cant.", "{0:N0}")
        '    ' Create and setup the first summary item.
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "Cant."
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    Grid.GroupSummary.Add(item)
        'End If



        If IsNothing(Grid.Columns("Pieza").Summary.FirstOrDefault(Function(x) x.FieldName = "Pieza")) = True Then
            Grid.Columns("Pieza").Summary.Add(DevExpress.Data.SummaryItemType.Count, "Pieza", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pieza"
            item.SummaryType = DevExpress.Data.SummaryItemType.Count
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If



    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdVDetallada_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVDetallada.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub
    Private Sub grdVDetallada_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdVDetallada.RowCellStyle

        Dim Grid As DevExpress.XtraGrid.Views.Grid.GridView = sender
        fecha1 = Nothing
        fecha2 = Nothing
        SATC = ""
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "FEntregaCliente" Then
                If IsDBNull(Grid.GetRowCellValue(e.RowHandle, "FEntregaNave")) Then Return
                If IsDBNull(Grid.GetRowCellValue(e.RowHandle, "FEntregaCliente")) Then Return
                fecha1 = Grid.GetRowCellValue(e.RowHandle, "FEntregaNave")
                fecha2 = Grid.GetRowCellValue(e.RowHandle, "FEntregaCliente")
                If fecha1 > fecha2 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "FEntregaNave" Then
                If IsDBNull(Grid.GetRowCellValue(e.RowHandle, "FechaRecepción")) Then Return
                If IsDBNull(Grid.GetRowCellValue(e.RowHandle, "FEntregaNave")) Then Return
                fecha1 = Grid.GetRowCellValue(e.RowHandle, "FechaRecepción")
                fecha2 = Grid.GetRowCellValue(e.RowHandle, "FEntregaNave")
                If fecha1 > fecha2 Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

            If e.Column.FieldName = "SATC" Then
                SATC = Grid.GetRowCellValue(e.RowHandle, "SATC")
                If SATC = "SI" Then
                    e.Appearance.ForeColor = Color.Green
                ElseIf SATC = "NO" Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If


            If e.Column.FieldName = "EATN" Then
                EATN = Grid.GetRowCellValue(e.RowHandle, "EATN")
                If EATN = "SI" Then
                    e.Appearance.ForeColor = Color.Green
                ElseIf EATN = "NO" Then
                    e.Appearance.ForeColor = Color.Red
                End If
            End If

        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If grdVDetallada.GroupCount > 0 Then
                        grdDetallada.ExportToXlsx(.SelectedPath + "\Datos_Detallada_" + fecha_hora + ".xlsx")
                        'grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdDetallada.ExportToXlsx(.SelectedPath + "\Datos_Detallada_" + fecha_hora + ".xlsx", exportOptions)

                    End If


                    Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente.")

                    .Dispose()

                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_Detallada_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        Try

            fecha1 = Nothing
            fecha2 = Nothing
            SATC = ""
            If e.RowHandle >= 0 Then

                If e.ColumnFieldName = "FEntregaCliente" Then
                    If IsDBNull(grdVDetallada.GetRowCellValue(e.RowHandle, "FEntregaNave")) Then Return
                    If IsDBNull(grdVDetallada.GetRowCellValue(e.RowHandle, "FEntregaCliente")) Then Return
                    fecha1 = grdVDetallada.GetRowCellValue(e.RowHandle, "FEntregaNave")
                    fecha2 = grdVDetallada.GetRowCellValue(e.RowHandle, "FEntregaCliente")
                    If fecha1 > fecha2 Then
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If
                If e.ColumnFieldName = "FEntregaNave" Then
                    If IsDBNull(grdVDetallada.GetRowCellValue(e.RowHandle, "FechaRecepción")) Then Return
                    If IsDBNull(grdVDetallada.GetRowCellValue(e.RowHandle, "FEntregaNave")) Then Return
                    fecha1 = grdVDetallada.GetRowCellValue(e.RowHandle, "FechaRecepción")
                    fecha2 = grdVDetallada.GetRowCellValue(e.RowHandle, "FEntregaNave")
                    If fecha1 > fecha2 Then
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If

                If e.ColumnFieldName = "SATC" Then
                    SATC = grdVDetallada.GetRowCellValue(e.RowHandle, "SATC")
                    If SATC = "SI" Then
                        e.Formatting.Font.Color = Color.Green
                    ElseIf SATC = "NO" Then
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If


                If e.ColumnFieldName = "EATN" Then
                    EATN = grdVDetallada.GetRowCellValue(e.RowHandle, "EATN")
                    If EATN = "SI" Then
                        e.Formatting.Font.Color = Color.Green
                    ElseIf EATN = "NO" Then
                        e.Formatting.Font.Color = Color.Red
                    End If
                End If
            End If


            e.Handled = True
        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
        End Try

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
        Dim dtDetallada As DataTable
        Dim strCedis As String = ""

        If nombreCedis = "COMERCIALIZADORA" Then
            strCedis = "43"
        Else
            strCedis = "82"
        End If

        dtDetallada = objBU.ConsultaDetallada(False, Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, tallas,
                                              strFEntregaNave, strFEntregaCliente, strFEnvioDeNave, strFRecepcionComer, strCedis)
        grdDetallada.DataSource = dtDetallada
        DiseñoGrid(grdVDetallada)
        CalcularPorcentaje(dtDetallada)
        lblUltimaActualizacion.Text = Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
    End Sub
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        grdDetallada.DataSource = Nothing
        lblPorcentajeSI.Text = "0%"
        lblPorcentajeNO.Text = "0%"

    End Sub

    Private Sub CalcularPorcentaje(ByVal data As DataTable)
        Dim contSI As Integer = 0
        Dim contNO As Integer = 0
        Dim Total As Integer = 0
        Dim Psi, Pno As Integer
        For Each row As DataRow In data.Rows
            If row.Item("EATN").ToString = "SI" Then
                contSI += 1
            ElseIf row.Item("EATN").ToString = "NO" Then
                contNO += 1
            End If
        Next
        Total = contSI + contNO

        If Total > 0 Then
            Psi = ((contSI * 100) / Total)
            Pno = ((contNO * 100) / Total)
            lblPorcentajeSI.Text = Psi.ToString + "%"
            lblPorcentajeNO.Text = Pno.ToString + "%"
        End If
    End Sub

End Class