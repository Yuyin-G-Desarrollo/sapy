Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraPrinting
Imports Tools
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid

Public Class ResumenProductosForm

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
    Public TipoConsulta As String = String.Empty
    Public MarcaColeccionTemp, Modelo, PielColor, Corrida As Boolean
    Public cedisNombre As String = ""

    Dim fecha1 As Date
    Dim fecha2 As Date

    Private _DataConsulta As DataTable
    Public Property DataConsulta() As DataTable
        Get
            Return _DataConsulta
        End Get
        Set(ByVal value As DataTable)
            _DataConsulta = value
        End Set
    End Property

    Private Sub ResumenProductosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.Cursor = Cursors.WaitCursor
        grdConsulta.DataSource = _DataConsulta
        DiseñoGrid(grdVConsulta)
        lblUltimaActualizacion.Text = Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
        lblTitulo2.TextAlign = ContentAlignment.TopRight



        If TipoConsulta = "MUESTRAS_POR_NAVE" Then
            pnAgrupamiento.Visible = True
            lblTitulo2.Text = "Muestras Por Nave"
            chkMarcaColeccionTemp.Checked = MarcaColeccionTemp
            chkModelo.Checked = Modelo
            chkPielColor.Checked = PielColor
            chkCorrida.Checked = Corrida
            Me.Text = Me.Text + " (Muestras Por Nave)"
            lblnombrecedis.Text = cedisNombre
        ElseIf TipoConsulta = "RESUMEN_DE_PRODUCTOS" Then
            lblTitulo2.Text = "Resumen de Productos"
            Me.Text = Me.Text + " Resumen de Productos"
            lblnombrecedis.Text = cedisNombre
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub DiseñoGrid(ByVal Grid As DevExpress.XtraGrid.Views.Grid.GridView)
        If IsNothing(Grid.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
            Grid.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
            AddHandler Grid.CustomUnboundColumnData, AddressOf grdVResumenP_CustomUnboundColumnData
            Grid.Columns.Item("#").VisibleIndex = 0
        End If
        Grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()
        Tools.DiseñoGrid.AjustarAltoEncabezados(Grid)
        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(Grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(Grid)
        Tools.DiseñoGrid.DeshabilitarEdicion(Grid)
        Tools.DiseñoGrid.FiltroContiene(Grid)
        If TipoConsulta = "RESUMEN_DE_PRODUCTOS" Then
            Grid.Columns.ColumnByFieldName("MarcaSAY").Caption = "Marca"
            Grid.Columns.ColumnByFieldName("ColeccionSAY").Caption = "Colección"
        End If

        If TipoConsulta = "MUESTRAS_POR_NAVE" Then

        End If

        Grid.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(Grid.Columns("Piezas").Summary.FirstOrDefault(Function(x) x.FieldName = "Piezas")) = True Then
            Grid.Columns("Piezas").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Piezas", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Piezas"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            Grid.GroupSummary.Add(item)
        End If






    End Sub

    Private Sub grdVResumenP_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grdVConsulta.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreArchivo As String = String.Empty


        Try


            If TipoConsulta = "RESUMEN_DE_PRODUCTOS" Then
                nombreArchivo = "Resumen_Por_Productos"

            ElseIf TipoConsulta = "MUESTRAS_POR_NAVE" Then
                nombreArchivo = "Muestras_Por_Nave"
            End If




            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then

                    If grdVConsulta.GroupCount > 0 Then
                        grdVConsulta.ExportToXlsx(.SelectedPath + "\Datos_" + nombreArchivo + "_" + fecha_hora + ".xlsx")
                        'grdPedidosMuestras.ExportToXlsx(.SelectedPath + "\" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                        grdVConsulta.ExportToXlsx(.SelectedPath + "\Datos_" + nombreArchivo + "_" + fecha_hora + ".xlsx", exportOptions)

                    End If
                    Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente.")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_" + nombreArchivo + "_" + fecha_hora + ".xlsx")
                End If

            End With
        Catch ex As Exception
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = ex.Message
            mensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBU As New Negocios.EnvioRecepcionMuestrasBU
        Dim dtConsulta As DataTable = Nothing
        Dim cedisid As String = ""
        Try
            If cedisNombre = "COMERCIALIZADORA" Then
                cedisid = "43"
            Else
                cedisid = "82"
            End If

            If TipoConsulta = "RESUMEN_DE_PRODUCTOS" Then
                dtConsulta = objBU.ConsultaResumenProductos(Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, tallas,
                                                 strFEntregaNave, strFEntregaCliente, strFEnvioDeNave, strFRecepcionComer, cedisid)
            ElseIf TipoConsulta = "MUESTRAS_POR_NAVE" Then
                dtConsulta = objBU.ConsultaMuestrasPorNave(chkMarcaColeccionTemp.Checked, chkModelo.Checked, chkPielColor.Checked, chkCorrida.Checked, Operador, Naves, Piezas, Clientes, PedidosM, Articulos, Corridas, tallas,
                                          strFEntregaNave, strFEntregaCliente, strFEnvioDeNave, strFRecepcionComer, cedisid)
            End If
            If Not IsNothing(dtConsulta) Then
                If dtConsulta.Rows.Count > 0 Then
                    grdConsulta.DataSource = Nothing
                    grdVConsulta.Columns.Clear()
                    grdConsulta.DataSource = dtConsulta
                    DiseñoGrid(grdVConsulta)
                    lblUltimaActualizacion.Text = Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString
                End If
            End If
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class