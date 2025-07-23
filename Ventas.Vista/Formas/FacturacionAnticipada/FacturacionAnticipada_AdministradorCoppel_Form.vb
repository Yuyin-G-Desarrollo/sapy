Imports System.Data.OleDb
Imports System.IO
Imports DevExpress
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid


Public Class FacturacionAnticipada_AdministradorCoppel_Form
#Region "Variables"
    Dim objFactAnticipadaBU As New Negocios.FacturacionAnticipadaBU
    Dim listPedidoSAY As New List(Of String)
    Dim listPedidoSICY As New List(Of String)
    Dim filaAnterior As Integer = -1
    Dim checkedRowIndex As Integer = -1
    Dim entCliente As Entidades.Cliente
    Dim ordenDeCliente As String = String.Empty
    Dim objBu As New Ventas.Negocios.FacturacionAnticipadaCoppelBU
    Dim ListaPedidoSAY As New List(Of String)
    Private WithEvents repositorioChkSeleccionar As New RepositoryItemCheckEdit
    Private idCliente As Integer = 763


    Private colorPendienteCap As Color = ColorTranslator.FromHtml("#FE9A2E")
    Private colorParcialmenteCap As Color = Color.FromArgb(247, 190, 129)
    Private colorCapturada As Color = ColorTranslator.FromHtml("#FE9A2E")
    Private colorAtrasoEntrega As Color = Color.FromArgb(255, 192, 203)
    Private colorAlertaEntrega As Color = Color.FromArgb(255, 255, 128)
    Private colorForeAlertaEntrega As Color = Color.FromArgb(154, 125, 10)
    Private colorPendienteEntrega As Color = Color.FromArgb(144, 238, 144)
#End Region

    Private Sub FacturacionAnticipada_AdministradorCoppel_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboCliente()

        chkBuscarPorFecha.Checked = False
        dtpFechaInicio.Value = DateTime.Now
        dtpFechaFin.Value = DateTime.Now

        chkDistribucionPendiente.Checked = True
        chkDistribucionCapturada.Checked = False

        lblUltimaActualizacion.Text = String.Empty

        Me.WindowState = FormWindowState.Maximized

        SeleccionPantallaCliente()
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCliente.SelectedIndexChanged
        Dim cmb As ComboBox = sender

        idCliente = CInt(cmb.SelectedValue.ToString)

        SeleccionPantallaCliente()
    End Sub

    Private Sub SeleccionPantallaCliente()
        If idCliente = 763 Then
            SeleccionCoppel()
        Else
            SeleccionBattaBatta()
        End If
    End Sub

    Private Sub SeleccionCoppel()
        pnlCancelar.Hide()
        pnlImprimir.Show()
        pnlVerOT.Show()
        chkDistribucionPendiente.Checked = True
        chkDistribucionCapturada.Checked = False
        grpFiltroFecha.Show()
    End Sub

    Private Sub SeleccionBattaBatta()
        pnlCancelar.Show()
        pnlImprimir.Hide()
        pnlVerOT.Hide()
        chkDistribucionPendiente.Checked = True
        chkDistribucionCapturada.Checked = True
        grpFiltroFecha.Hide()
    End Sub

    Private Sub CargarComboCliente()
        Dim listClientes As List(Of Entidades.Cliente)
        Try
            listClientes = objFactAnticipadaBU.ConsultarClientesDistribuciones
            cmbCliente.DataSource = Nothing
            cmbCliente.DataSource = listClientes
            'cmbCliente.SelectedIndex = 0
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub chkBuscarPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkBuscarPorFecha.CheckedChanged
        HabilitarDeshabilitarFiltroFecha()
    End Sub

    Private Sub HabilitarDeshabilitarFiltroFecha()
        If chkBuscarPorFecha.Checked Then
            dtpFechaInicio.Enabled = True
            dtpFechaFin.Enabled = True
        Else
            dtpFechaInicio.Enabled = False
            dtpFechaFin.Enabled = False
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub

    Private Sub ExportarExcel()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            If grdDatosDistribuciones.RowCount > 0 Then
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        'If grdDatosDistribuciones.GroupCount > 0 Then
                        '    grdDatosDistribuciones.ExportToXlsx(.SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx")
                        'Else
                        '    Dim exportOptions = New XlsxExportOptionsEx()
                        '    grdDatosDistribuciones.ExportToXlsx(.SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx", exportOptions)

                        'End If

                        'show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_DistribucionesCoppel_" & fecha_hora.ToString() & ".xlsx")

                        '.Dispose()

                        'Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx")

                        If grdDatosDistribuciones.RowCount > 0 Then

                            'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                            'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                            grdDatosDistribuciones.OptionsPrint.AutoWidth = False
                            grdDatosDistribuciones.OptionsPrint.UsePrintStyles = False
                            'Grid.OptionsPrint.EnableAppearanceEvenRow = True
                            'Grid.OptionsPrint.EnableAppearanceOddRow = True
                            'Grid.OptionsPrint.PrintHorzLines = False
                            'Grid.OptionsPrint.PrintVertLines = False

                            'Grid.OptionsPrint.PrintPreview = True

                            Dim FileName As String = .SelectedPath + "\Datos_DistribucionesCoppel_" + fecha_hora + ".xlsx"

                            'Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx
                            'exportOptions.AllowConditionalFormatting = True
                            'exportOptions.AllowFixedColumns = DevExpress.Utils.DefaultBoolean.True
                            'exportOptions.ExportType = DevExpress.Export.ExportType.DataAware
                            DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                            grdDatosDistribuciones.ExportToXlsx(FileName)

                            show_message("Exito", "Los datos se exportaron correctamente.")

                            Process.Start(FileName)

                        Else
                            show_message("Exito", "No hay registros para exportar.")
                        End If
                    End If
                End With
            Else
                show_message("Advertencia", "No hay datos para exportar")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

#Region "Mensajes"
    Public Function show_message(ByVal tipo As String, ByVal mensaje As String) As DialogResult
        Dim result As DialogResult

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
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

            result = mensajeExito.ShowDialog()
        End If

        Return result
    End Function
#End Region
    Private Sub txtPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSAY.Text) Then Return

            listPedidoSAY.Add(txtPedidoSAY.Text)
            grdPedidoSAY.DataSource = Nothing
            grdPedidoSAY.DataSource = listPedidoSAY

            txtPedidoSAY.Text = String.Empty

        End If
    End Sub


    Private Sub txtPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtPedidoSICY.Text) Then Return

            listPedidoSICY.Add(txtPedidoSICY.Text)
            grpPedidoSICY.DataSource = Nothing
            grpPedidoSICY.DataSource = listPedidoSICY

            txtPedidoSICY.Text = String.Empty

        End If
    End Sub

    Private Sub btnImportarDistribucion_Click(sender As Object, e As EventArgs) Handles btnImportarDistribucion.Click
        If idCliente = 763 Then
            ImportarExcel()
        Else
            ImportarExcelBatta()
        End If
    End Sub

    Private Sub ImportarExcel()
        Dim pedidoSay As Integer
        Dim pedidoSicy As Integer
        Dim paresPedido As Integer
        Dim estatusDistribucionID As Integer
        Dim objFacturacionAnticipadaDetalle As New FacturacionAnticipada_ImportarDistribucionTiendasCoppel_Form
        Dim ordenClienteArchivo As String
        Dim distribuciones As List(Of Entidades.DistribucionPedidoCoppel)
        Dim seleccionado As Boolean = False
        Dim paresPendientes As Integer

        ordenDeCliente = String.Empty

        If grdDatosDistribuciones.RowCount > 0 Then

            If checkedRowIndex > -1 Then
                seleccionado = Boolean.Parse(grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "Seleccionar").ToString)
            End If


            If checkedRowIndex >= 0 And seleccionado Then

                If ValidarPedidoImportacion(checkedRowIndex) Then
                    distribuciones = lecturaExcel()
                    paresPendientes = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "ParesPendientes")

                    ordenClienteArchivo = ordenDeCliente

                    If distribuciones.Count > 0 Then
                        pedidoSay = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSAY")
                        pedidoSicy = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSICY")
                        paresPedido = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "ParesPedido")
                        estatusDistribucionID = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "StatusID")

                        objFacturacionAnticipadaDetalle.LLenarInformacionPedido(pedidoSay,
                                                                        pedidoSicy,
                                                                        paresPedido,
                                                                        paresPendientes,
                                                                        "COPPEL",
                                                                        ordenClienteArchivo,
                                                                        distribuciones)
                        'objFacturacionAnticipadaDetalle.Parent = Me.Parent
                        objFacturacionAnticipadaDetalle.SetMdiParent(Me.MdiParent)
                        objFacturacionAnticipadaDetalle.ShowDialog()

                        Mostrar(False)
                    End If

                End If

                'If estatusDistribucionID <> 123 Then

                'Else
                '    show_message("Advertencia", "Este pedido ya tiene sus distribuciones capturadas.")
                'End If

                'Me.Cursor = Cursors.WaitCursor
                'Dim estatusDistribucionID As Integer

                'estatusDistribucionID = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "StatusID")

                'If estatusDistribucionID = 0 Then
                '    Dim viewImportarDistribuciones As New FacturacionAnticipada_ImportarDistribucionTiendas_Form
                '    Dim entDistribucion = New Entidades.DistribucionPedido
                '    grdDatosDistribuciones.ClearColumnsFilter()
                '    viewImportarDistribuciones.tipoArchivoImportado = entCliente.TipoArchivoDistribucionTiendas
                '    entDistribucion.Cliente = entCliente
                '    entDistribucion.PedidoSAY = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSAY")
                '    entDistribucion.PedidoSICY = CInt(grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSICY"))
                '    entDistribucion.ParesPedido = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "ParesPedido")
                '    entDistribucion.OrdenCliente = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "OrdenCliente")
                '    viewImportarDistribuciones.entDistribucion = entDistribucion

                '    ''VALIDA QUE NO TENGA YA GENERARDA OT EL PEDIDO PARA PODER GUARDAR LA DISTRIBUCIÓN
                '    Dim dtPedidoOT As DataTable
                'dtPedidoOT = objFactAnticipadaBU.validarPedidoSinOT(entDistribucion.PedidoSAY)

                '    If dtPedidoOT.Rows.Count > 0 Then
                '        show_message("Advertencia", "EL pedido " + dtPedidoOT.Rows(0).Item(0).ToString + " ya tiene una orden de trabajo en estatus " + dtPedidoOT.Rows(0).Item(1).ToString)
                '    Else
                '        viewImportarDistribuciones.ShowDialog()
                '    End If
                '    'btnMostrar_Click(Nothing, Nothing)
                '    checkedRowIndex = -1
                '    lblPedidoSeleccionado.Text = "0"
                'Else
                '    show_message("Advertencia", "Ya tiene cargada una distribución del pedido seleccionado, si quiere cargar una nueva, es necesario cancelar esta distribución (Solo puede hacerlo si se encuentra en estatus POR FACTURAS).")
                'End If
                'Me.Cursor = Cursors.Default
            Else
                show_message("Advertencia", "Debe seleccionar un pedido para cargar su distribución.")
                Cursor = Cursors.Default
            End If
        Else
            show_message("Advertencia", "Debe seleccionar un pedido para cargar su distribución.")
        End If
    End Sub

    Private Function lecturaExcel() As List(Of Entidades.DistribucionPedidoCoppel)
        Dim dtExcel As DataTable
        Dim distribuciones As New List(Of Entidades.DistribucionPedidoCoppel)
        Dim distribucion As Entidades.DistribucionPedidoCoppel

        Try
            Cursor = Cursors.WaitCursor
            dtExcel = leerArchivo()
            If Not dtExcel Is Nothing Then
                If dtExcel.Rows.Count > 0 Then

                    For Each row As DataRow In dtExcel.Rows
                        If String.IsNullOrEmpty(row(0).ToString) Then
                            Continue For
                        End If
                        distribucion = New Entidades.DistribucionPedidoCoppel
                        distribucion.CodigoRapidoCliente = row(0).ToString
                        distribucion.Modelo = row(1).ToString
                        distribucion.Talla = CInt(row(2).ToString)
                        distribucion.Costo = Single.Parse(row(3).ToString)
                        distribucion.Destino = row(4).ToString
                        distribucion.CantidadPedida = CInt(row(5).ToString)
                        distribucion.CantidadSurtida = CInt(row(6).ToString)
                        distribucion.Unidades = CInt(row(7).ToString)
                        distribucion.OrdenCliente = ordenDeCliente

                        distribuciones.Add(distribucion)
                    Next

                    'ordenClienteArchivo = dtExcel.Rows(0).Item(0)
                    'If ordenClienteArchivo <> String.Empty Or ordenClienteArchivo <> Nothing Then
                    '    If CLng(ordenClienteArchivo) = CLng(entDistribucion.OrdenCliente) Then
                    '        guardarDistribucionArchivo(dtExcel)
                    '    Else
                    '        capturarError("EL ARCHIVO SELECCIONADO CORRESPONDE A LA OC " + ordenClienteArchivo)
                    '    End If
                    'Else
                    '    capturarError("EL ARCHIVO SELECCIONADO NO TIENE EL FORMATO ESPERADO")
                    '    capturarError("EL ARCHIVO SELECCIONADO CORRESPONDE A LA OC " + ordenClienteArchivo)
                    'End If
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Advertencia", "No se ha podido leer el archivo")
        End Try

        Return distribuciones
    End Function

    Public Function leerArchivo() As DataTable
        Dim cnn As New OleDb.OleDbConnection
        Dim dtHojas As DataTable
        leerArchivo = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand
        Dim nombreArchivoDistribucion As String
        Dim rutaDis As String

        Dim ofd As New OpenFileDialog
        ofd.Multiselect = False
        ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
        'ofd.Filter = "CSV Files (*.csv)|*.csv"
        Dim file As String = String.Empty
        Dim OCPedido As String = String.Empty
        Dim fila As Integer = checkedRowIndex

        ofd.ShowDialog()

        file = ofd.FileName
        OCPedido = grdDatosDistribuciones.GetRowCellValue(fila, "OrdenCliente")

        If String.IsNullOrEmpty(file) Then
            Return Nothing
        End If

        Try
            rutaDis = Path.GetDirectoryName(file)
            nombreArchivoDistribucion = Path.GetFileName(file)
            ordenDeCliente = nombreArchivoDistribucion.Split(".")(0)

            If ordenDeCliente.Contains("_") Then
                ordenDeCliente = ordenDeCliente.Substring(0, ordenDeCliente.IndexOf("_"))
            End If

            If Not OCPedido.Equals(ordenDeCliente.Trim(" ")) Then
                show_message("Advertencia", "El nombre del archivo no coincide con la ORDEN DE CLIENTE")
                Return Nothing
            End If

            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & file & ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"

            cnn.Open()

            dtHojas = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            cmd.Connection = cnn
            cmd.CommandText = String.Format("SELECT * FROM [{0}]", dtHojas.Rows(0)("TABLE_NAME").ToString)
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(leerArchivo)

            leerArchivo.AcceptChanges()

            'Obtenemos el numero de compra

        Catch ex As Exception
            'show_message("Error", ex.Message)
            show_message("Advertencia", "No se ha podido leer el archivo" + ex.Message)
        Finally
            cnn.Close()
        End Try
    End Function

    Private Function ValidarPedidoImportacion(fila As Integer) As Boolean
        Dim pedido As Integer
        Dim estatus As String
        Dim validado As Boolean = False

        pedido = grdDatosDistribuciones.GetRowCellValue(fila, "PedidoSAY")
        estatus = grdDatosDistribuciones.GetRowCellValue(fila, "EstatusDistribucion").ToString

        If Not estatus.Equals("CAPTURADO") Then
            validado = True
        Else
            show_message("Advertencia", "Este pedido se encuentra en CAPTURADO")
            validado = False
        End If

        'If seleccionado Then
        '    If paresArchivo <= paresPedidoPendientes Then
        '        validado = True
        '    Else
        '        show_message("Advertencia", "Este archivo tiene más pares que los pares pendientes del pedido")
        '        validado = False
        '    End If

        '    If Not estatus.Equals("CAPTURADO") Then
        '        validado = True
        '    Else
        '        show_message("Advertencia", "Este pedido se encuentra en CAPTURADO")
        '        validado = False
        '    End If
        'Else
        '    show_message("Advertencia", "No se ha seleccionado un pedido")
        '    validado = False
        'End If

        Return validado
    End Function

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If idCliente = 763 Then
            Mostrar(True)
        Else
            MostrarBatta(True)
        End If
    End Sub

    ' Se agrega la variable limpiarColumnas ya que al ser columnas diferentes la informaciòn de Coppel y HermanosBatta,
    ' cada que se refresca la pantalla quita los filtros de la columna si es que habia busqueda por esto
    Private Sub Mostrar(limpiarColumnas As Boolean)
        Dim pedidos As String = String.Empty
        Dim pedidosSICY As String = String.Empty
        Dim fechaInicio As DateTime? = Nothing
        Dim fechaFin As DateTime? = Nothing
        Dim usuarioConsultaId As Int32
        Dim distribucionPendiente As Boolean = False
        Dim distribucionCapturada As Boolean = False
        Dim datos As New DataTable

        If limpiarColumnas Then
            grdDatosDistribuciones.Columns.Clear()
        End If

        grdDistribuciones.DataSource = Nothing

        If chkBuscarPorFecha.Checked Then
            fechaInicio = dtpFechaInicio.Value
            fechaFin = dtpFechaFin.Value
        End If

        usuarioConsultaId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        If chkDistribucionPendiente.Checked And chkDistribucionCapturada.Checked = False Then
            distribucionPendiente = True
        ElseIf chkDistribucionCapturada.Checked And chkDistribucionPendiente.Checked = False Then
            distribucionCapturada = True
        End If

        For Each row As UltraGridRow In grdPedidoSAY.Rows
            If row.Index = 0 Then
                pedidos += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                pedidos += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        For Each row As UltraGridRow In grpPedidoSICY.Rows
            If row.Index = 0 Then
                pedidosSICY += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                pedidosSICY += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next


        distribucionPendiente = chkDistribucionPendiente.Checked
        distribucionCapturada = chkDistribucionCapturada.Checked

        Cursor = Cursors.WaitCursor

        datos = objBu.ConsultarPedidosDistribucion(pedidos, pedidosSICY, fechaInicio, fechaFin, distribucionPendiente, distribucionCapturada)

        If datos.Rows.Count > 0 Then
            Dim v As DataView = datos.DefaultView
            'v.Sort = "FechaDocumento"
            grdDistribuciones.DataSource = datos
            DisenioGrid()
            OcultarFiltros()
        End If

        Cursor = Cursors.Default

        lblRegistros.Text = datos.Rows.Count.ToString
        lblUltimaActualizacion.Text = DateTime.Now.ToString
    End Sub

#Region "Diseño Grid"
    Private Sub DisenioGrid()
        Tools.DiseñoGrid.DiseñoBaseGridSinBestFit(grdDatosDistribuciones)

        grdDatosDistribuciones.Columns(0).OptionsColumn.AllowEdit = True
        'For i = 1 To grdDatosDistribuciones.Columns.Count - 1
        '    grdDatosDistribuciones.Columns(i).OptionsColumn.AllowEdit = False
        'Next

        'grdDatosDistribuciones.Columns("DistribucionPedidoID").Visible = False
        'grdDatosDistribuciones.Columns("DistribucionPedidoDetalleID").Visible = False
        'grdDatosDistribuciones.Columns("Cliente").Visible = False
        'grdDatosDistribuciones.Columns("PedidoSAY").Visible = False
        'grdDatosDistribuciones.Columns("PedidoSICY").Visible = False
        'grdDatosDistribuciones.Columns("TiendaEmbarqueId").Visible = False
        'grdDatosDistribuciones.Columns("EstatusArchivo").Visible = False
        'grdDatosDistribuciones.Columns("NombreTiendaEmbarque").Visible = False

        repositorioChkSeleccionar.DisplayValueChecked = "Sí"
        repositorioChkSeleccionar.DisplayValueUnchecked = "No"
        grdDatosDistribuciones.Columns("Seleccionar").Caption = " "
        grdDatosDistribuciones.Columns("Seleccionar").BestFit()
        grdDatosDistribuciones.Columns("Color").Caption = " "
        grdDatosDistribuciones.Columns("Color").Width = 20
        grdDatosDistribuciones.Columns("EstatusPedido").Caption = "Estatus Pedido"
        grdDatosDistribuciones.Columns("PedidoSAY").Caption = "Pedido SAY"
        grdDatosDistribuciones.Columns("PedidoSICY").Caption = "Pedido SICY"
        grdDatosDistribuciones.Columns("OrdenCliente").Caption = "Orden Cliente"
        grdDatosDistribuciones.Columns("DiasEntrega").Caption = "Días Entrega"
        grdDatosDistribuciones.Columns("EstatusDistribucion").Caption = "Estatus Distribución"
        grdDatosDistribuciones.Columns("ParesPedido").Caption = "Pares Pedido"
        grdDatosDistribuciones.Columns("ParesCanceladosPedido").Caption = "Pares Cancelados Pedido"
        grdDatosDistribuciones.Columns("ParesArchivo").Caption = "Pares Archivo"
        grdDatosDistribuciones.Columns("ParesConfirmados").Caption = "Pares Confirmados"
        grdDatosDistribuciones.Columns("ParesConfirmados").Visible = False
        grdDatosDistribuciones.Columns("ParesPendientes").Caption = "Pares Pendientes"
        'grdDatosDistribuciones.Columns("ParesCancelados").Caption = "Pares Cancelados"
        grdDatosDistribuciones.Columns("CantidadOT").Caption = "Cantidad OT"
        grdDatosDistribuciones.Columns("FechaImportacion").Caption = "Fecha Importación"
        grdDatosDistribuciones.Columns("UsuarioImporto").Caption = "Usuario Importó"
        'grdDatosDistribuciones.Columns("CodigoRapidoCliente").Caption = "Código"
        'grdDatosDistribuciones.Columns("CantidadPedida").Caption = "Cant. Pedida"
        'grdDatosDistribuciones.Columns("CantidadSurtida").Caption = "Cant. Surtida"
        'grdDatosDistribuciones.Columns("OrdenCliente").Caption = "OC"
        'grdDatosDistribuciones.Columns("OrdenTrabajoID").Caption = "Orden Trabajo"

        grdDatosDistribuciones.Columns("ParesPedido").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosDistribuciones.Columns("ParesPedido").DisplayFormat.FormatString = "n0"
        'grdDatosDistribuciones.Columns("ParesCanceladosPedido").DisplayFormat.FormatType = Utils.FormatType.Numeric
        'grdDatosDistribuciones.Columns("ParesCanceladosPedido").DisplayFormat.FormatString = "n0"
        grdDatosDistribuciones.Columns("ParesArchivo").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosDistribuciones.Columns("ParesArchivo").DisplayFormat.FormatString = "n0"
        grdDatosDistribuciones.Columns("ParesPendientes").DisplayFormat.FormatType = Utils.FormatType.Numeric
        grdDatosDistribuciones.Columns("ParesPendientes").DisplayFormat.FormatString = "n0"

        CrearSummarAlPiePantalla()

        grdDatosDistribuciones.Columns("Seleccionar").ColumnEdit = repositorioChkSeleccionar
    End Sub

    Private Sub CrearSummarAlPiePantalla()
        grdDatosDistribuciones.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        grdDatosDistribuciones.GroupSummary.Clear()
        grdDatosDistribuciones.Columns("ParesPedido").Summary.Clear()
        grdDatosDistribuciones.Columns("ParesPendientes").Summary.Clear()
        grdDatosDistribuciones.Columns("ParesPedido").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesPedido", "{0:N0}")
        grdDatosDistribuciones.Columns("ParesPendientes").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ParesPendientes", "{0:N0}")


        Dim item As New GridGroupSummaryItem
        item.FieldName = "ParesPedido"
        item.ShowInGroupColumnFooter = grdDatosDistribuciones.Columns("c")
        item.SummaryType = Data.SummaryItemType.Sum
        item.DisplayFormat = "Total {0:N}"
        grdDatosDistribuciones.GroupSummary.Add(item)

        Dim item2 As New GridGroupSummaryItem
        item2.FieldName = "ParesPendientes"
        item2.SummaryType = Data.SummaryItemType.Sum
        item2.DisplayFormat = "Total {0:N}"
        item2.ShowInGroupColumnFooter = grdDatosDistribuciones.Columns("ParesPendientes")
        grdDatosDistribuciones.GroupSummary.Add(item2)
    End Sub


    Private Sub DisenioGrid_Filtros(grid As UltraGrid)
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

    End Sub
#End Region

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        OcultarFiltros()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        MostrarFiltros()
    End Sub

#Region "Acciones Botones Arriba Abajo"
    Private Sub OcultarFiltros()
        pnlFiltros.Height = 0
    End Sub

    Private Sub MostrarFiltros()
        pnlFiltros.Height = 137
    End Sub
#End Region

    Private Sub grdPedidoSAY_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPedidoSAY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPedidoSAY.DeleteSelectedRows(False)
    End Sub

    Private Sub grpPedidoSICY_KeyDown(sender As Object, e As KeyEventArgs) Handles grpPedidoSICY.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grpPedidoSICY.DeleteSelectedRows(False)
    End Sub

    Private Sub grdPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPedidoSAY.InitializeLayout
        DisenioGrid_Filtros(grdPedidoSAY)
        grdPedidoSAY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SAY"
    End Sub

    Private Sub grpPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grpPedidoSICY.InitializeLayout
        DisenioGrid_Filtros(grpPedidoSICY)
        grpPedidoSICY.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Pedido SICY"
    End Sub

    Private Sub grdDatosDistribuciones_CustomDrawRowIndicator(sender As Object, e As XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdDatosDistribuciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub MarcarSeleccionado(ByVal sender As Object, ByVal e As EventArgs) Handles repositorioChkSeleccionar.EditValueChanged
        Dim fila = grdDatosDistribuciones.FocusedRowHandle

        filaAnterior = checkedRowIndex
        If fila <> filaAnterior Then
            If idCliente = 763 Then
                grdDatosDistribuciones.SetRowCellValue(filaAnterior, "Seleccionar", False)
            Else
                grdDatosDistribuciones.SetRowCellValue(filaAnterior, " ", False)
            End If
        End If

        checkedRowIndex = fila
    End Sub

    ' Coloreamos el grid segun las condiciones en la fecha de entrega
    Private Sub grdDatosDistribuciones_CustomDrawCell(sender As Object, e As XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles grdDatosDistribuciones.CustomDrawCell
        'ColorearCeldas(e)
    End Sub

    Private Sub ColorearCeldas(e As RowCellStyleEventArgs)
        Dim filas As Integer = e.RowHandle
        Dim diasParaEntrega As Integer = grdDatosDistribuciones.GetRowCellValue(filas, "DiasEntrega")
        Dim auxEstatus As String = grdDatosDistribuciones.GetRowCellValue(filas, "EstatusDistribucion")

        If e.Column.FieldName.Equals("Color") And filas >= 0 Then
            If Not auxEstatus Is Nothing Then
                If auxEstatus.Equals("PENDIENTE") Then
                    e.Appearance.BackColor = colorPendienteCap
                ElseIf auxEstatus.Equals("PARCIALMENTE CAPTURADO") Then
                    e.Appearance.BackColor = colorParcialmenteCap
                ElseIf auxEstatus.Equals("CAPTURADO") Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = colorPendienteCap
                End If
            End If
        End If

        If e.Column.FieldName.Equals("DiasEntrega") And filas >= 0 Then
            If diasParaEntrega >= 15 Then
                e.Appearance.BackColor = colorPendienteEntrega
                e.Appearance.ForeColor = Color.Green
            ElseIf diasParaEntrega >= 1 Then
                e.Appearance.BackColor = colorAlertaEntrega
                e.Appearance.ForeColor = colorForeAlertaEntrega
            Else
                e.Appearance.BackColor = colorAtrasoEntrega
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btnImprimirReporte_Click(sender As Object, e As EventArgs) Handles btnImprimirReporte.Click
        AbrirPnlFiltroReporte()
    End Sub

    Private Sub AbrirPnlFiltroReporte()
        Dim reporte As New PanelFiltroReporte
        reporte.ShowDialog()
    End Sub

    Private Sub grdDatosDistribuciones_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdDatosDistribuciones.RowStyle
        Dim grid = TryCast(sender, GridView)
        If e.RowHandle > 0 Then
            If idCliente = 763 Then

            Else
                Dim estatus As String = grid.GetRowCellDisplayText(e.RowHandle, "Status")
                If estatus = "SIN DISTRIBUCIÓN ACTIVA" Then
                    e.Appearance.BackColor = Color.FromArgb(255, 204, 204)
                End If
            End If

        End If
    End Sub

    Private Sub grdDatosDistribuciones_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdDatosDistribuciones.RowCellStyle
        Dim grid = TryCast(sender, GridView)
        If e.RowHandle > -1 Then
            If idCliente = 763 Then
                ColorearCeldas(e)
            Else
                Dim estatus As String = grid.GetRowCellDisplayText(e.RowHandle, "Status")
                If e.Column.FieldName = "Status" Then
                    If estatus = "POR FACTURAR" Then
                        e.Appearance.ForeColor = Color.FromArgb(242, 102, 0)
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                    If estatus = "PARCIALMENTE CONFIRMADA" Then
                        e.Appearance.ForeColor = Color.FromArgb(162, 48, 160)
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                    If estatus = "CANCELADA" Then
                        e.Appearance.ForeColor = Color.FromArgb(255, 0, 0)
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                    If estatus = "FACTURADA" Then
                        e.Appearance.ForeColor = Color.FromArgb(49, 112, 192)
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                    If estatus = "ENTREGADA" Then
                        e.Appearance.ForeColor = Color.FromArgb(0, 176, 80)
                        e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnCancelarDistribucion_Click(sender As Object, e As EventArgs) Handles btnCancelarDistribucion.Click
        CancelarDistribucionBatta()
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        VerDetalle()
    End Sub

    Private Sub VerDetalle()
        Dim pedidoSAY As Integer = 0
        Dim seleccionado As Boolean = False
        Dim resultado As DataTable

        If grdDatosDistribuciones.RowCount > 0 Then

            If checkedRowIndex > -1 Then
                seleccionado = Boolean.Parse(grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "Seleccionar").ToString)
            End If

            If checkedRowIndex >= 0 And seleccionado Then
                pedidoSAY = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "PedidoSAY")
                resultado = objBu.ConsultarOTGeneradas(pedidoSAY)

                If resultado.Rows.Count > 0 Then
                    Dim reporte As New FacturacionAnticipada_ReporteParesTiendaCoppel_Form
                    reporte.PasarDatos(resultado)
                    reporte.ShowDialog()
                Else
                    show_message("Advertencia", "No se han generado OT para este pedido")
                End If
            Else
                show_message("Advertencia", "No se ha seleccionado ningún pedido")
            End If
        Else
            show_message("Advertencia", "No se ha seleccionado ningún pedido")
        End If

    End Sub

#Region "Importación Batta"
    Dim emptyEditor As RepositoryItem

    Private Sub ImportarExcelBatta()

        If checkedRowIndex > -1 Then
            Me.Cursor = Cursors.WaitCursor
            Dim estatusDistribucionID As Integer


            estatusDistribucionID = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "StatusID")

            If estatusDistribucionID = 0 Then
                Dim viewImportarDistribuciones As New FacturacionAnticipada_ImportarDistribucionTiendas_Form
                Dim entDistribucion = New Entidades.DistribucionPedido
                grdDatosDistribuciones.ClearColumnsFilter()
                viewImportarDistribuciones.tipoArchivoImportado = entCliente.TipoArchivoDistribucionTiendas
                entDistribucion.Cliente = entCliente
                entDistribucion.PedidoSAY = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSAY")
                entDistribucion.PedidoSICY = CInt(grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "PedidoSICY"))
                entDistribucion.ParesPedido = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "ParesPedido")
                entDistribucion.OrdenCliente = grdDatosDistribuciones.GetRowCellValue(grdDatosDistribuciones.GetVisibleRowHandle(checkedRowIndex), "OrdenCliente")
                viewImportarDistribuciones.entDistribucion = entDistribucion

                ''VALIDA QUE NO TENGA YA GENERARDA OT EL PEDIDO PARA PODER GUARDAR LA DISTRIBUCIÓN
                Dim dtPedidoOT As DataTable
                dtPedidoOT = objFactAnticipadaBU.validarPedidoSinOT(entDistribucion.PedidoSAY)

                If dtPedidoOT.Rows.Count > 0 Then
                    show_message("Advertencia", "EL pedido " + dtPedidoOT.Rows(0).Item(0).ToString + " ya tiene una orden de trabajo en estatus " + dtPedidoOT.Rows(0).Item(1).ToString)
                Else
                    viewImportarDistribuciones.ShowDialog()
                End If
                MostrarBatta(False)
                checkedRowIndex = -1
            Else
                show_message("Advertencia", "Ya tiene cargada una distribución del pedido seleccionado, si quiere cargar una nueva, es necesario cancelar esta distribución (Solo puede hacerlo si se encuentra en estatus POR FACTURAS).")
            End If
            Me.Cursor = Cursors.Default
        Else
            show_message("Advertencia", "Debe seleccionar un pedido para cargar su distribución.")
        End If
    End Sub

    Private Sub MostrarBatta(limpiarColumnas As Boolean)
        Me.Cursor = Cursors.WaitCursor
        Dim sinDistribucion As Boolean
        Dim conDistribucion As Boolean
        Dim dtDistribucionesPedidos As DataTable
        Dim pedidosSAY As String = String.Empty
        Dim pedidosSICY As String = String.Empty

        If limpiarColumnas Then
            grdDatosDistribuciones.Columns.Clear()
        End If

        grdDistribuciones.DataSource = Nothing

        sinDistribucion = chkDistribucionPendiente.Checked
        conDistribucion = chkDistribucionCapturada.Checked

        lblUltimaActualizacion.Text = Date.Now

        entCliente = TryCast(cmbCliente.SelectedItem, Entidades.Cliente)

        conDistribucion = chkDistribucionCapturada.Checked
        sinDistribucion = chkDistribucionPendiente.Checked


        If Not conDistribucion And Not sinDistribucion Then
            show_message("Advertencia", "Debe seleccionar un filtro valido.")
            Cursor = Cursors.Default
            Return
        End If

        For Each row As UltraGridRow In grdPedidoSAY.Rows
            If row.Index = 0 Then
                pedidosSAY += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                pedidosSAY += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        For Each row As UltraGridRow In grpPedidoSICY.Rows
            If row.Index = 0 Then
                pedidosSICY += " " + Replace(row.Cells(0).Text, ",", "")
            Else
                pedidosSICY += ", " + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Try
            dtDistribucionesPedidos = objBu.ConsultarPedidosDistribucionHermanosBatta(entCliente.clienteid, conDistribucion, sinDistribucion, pedidosSAY, pedidosSICY)

            grdDistribuciones.DataSource = dtDistribucionesPedidos
            DiseñarGridBatta(grdDatosDistribuciones)
            'AplicarReglasFormatoGrid(grdVDistribuciones)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DiseñarGridBatta(Grid As GridView)
        'Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 40

        For Each col As Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
        Next

        Grid.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        Grid.Columns.ColumnByFieldName("StatusID").Visible = False

        Grid.Columns.ColumnByFieldName("distribucionPedidoID").Caption = "IdDist"

        Grid.Columns.ColumnByFieldName("ParesPedido").SummaryItem.SummaryType = Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("ParesArchivo").SummaryItem.SummaryType = Data.SummaryItemType.Sum
        Grid.Columns.ColumnByFieldName("ParesPedido").SummaryItem.DisplayFormat = "{0:N0}"
        Grid.Columns.ColumnByFieldName("ParesArchivo").SummaryItem.DisplayFormat = "{0:N0}"
        Grid.Columns.ColumnByFieldName("FImportación").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FImportación").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"
        Grid.Columns.ColumnByFieldName("FCancelación").DisplayFormat.FormatType = FormatType.DateTime
        Grid.Columns.ColumnByFieldName("FCancelación").DisplayFormat.FormatString = "dd/MM/yyyy h:mm:ss tt"
        Grid.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatType = FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesPedido").DisplayFormat.FormatString = "N0"
        Grid.Columns.ColumnByFieldName("ParesArchivo").DisplayFormat.FormatType = FormatType.Numeric
        Grid.Columns.ColumnByFieldName("ParesArchivo").DisplayFormat.FormatString = "N0"

        Grid.Columns(" ").ColumnEdit = repositorioChkSeleccionar
    End Sub

    Private Sub CancelarDistribucionBatta()
        Me.Cursor = Cursors.WaitCursor
        If checkedRowIndex > -1 Then
            Dim estatusDistribucionID As Integer
            Dim estatusDistribucion As String
            Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Dim entDistribucion = New Entidades.DistribucionPedido

            estatusDistribucionID = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "StatusID")
            estatusDistribucion = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "Status")

            If estatusDistribucionID = 325 Then
                Dim msg_Conf As New Tools.ConfirmarForm
                entDistribucion.Cliente = entCliente
                entDistribucion.PedidoSAY = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "PedidoSAY")
                entDistribucion.PedidoSICY = CInt(grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "PedidoSICY"))
                entDistribucion.ParesPedido = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "ParesPedido")
                entDistribucion.OrdenCliente = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "OrdenCliente")
                entDistribucion.OrdenTrabajoID = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "OTSay")
                entDistribucion.DistribucionPedidoID = grdDatosDistribuciones.GetRowCellValue(checkedRowIndex, "distribucionPedidoID")
                msg_Conf.mensaje = "Al cancelar la distribución " + entDistribucion.DistribucionPedidoID.ToString + " se cancelará también la OT " + entDistribucion.OrdenTrabajoID.ToString + " por " + entDistribucion.ParesPedido.ToString + " pares, ¿ Desea continuar ?"
                If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Try
                        objFactAnticipadaBU.CancelarDistribucionPedido(entDistribucion, usuarioID)
                        show_message("Exito", "Se canceló correctamente la Distribución y la Orden de trabajo.")
                    Catch ex As Exception
                        show_message("Error", ex.Message)
                    End Try
                    MostrarBatta(False)
                    checkedRowIndex = -1
                End If
            Else
                show_message("Advertencia", "No se puede cancelar la distribución con estatus " + estatusDistribucion + ", únicamente puede cancelarlas estando en status POR FACTURAR.")
            End If
        Else
            show_message("Advertencia", "Debe seleccionar un pedido para cancelar la distribución.")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) 
        Dim bodegas As New FacturacionAnticipada_CatalogoBodegaTiendaCoppel_Form
        bodegas.ShowDialog()
    End Sub

    Private Sub btnVerManual_Click(sender As Object, e As EventArgs) Handles btnVerManual.Click
        VerManual()
    End Sub

    Private Sub VerManual()
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Importacion_Distribucion_Coppel_V1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Importacion_Distribucion_Coppel_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class