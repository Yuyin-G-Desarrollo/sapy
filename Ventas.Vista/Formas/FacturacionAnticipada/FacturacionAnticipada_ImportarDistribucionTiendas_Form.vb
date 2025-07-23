Imports System.ComponentModel
Imports System.IO
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FacturacionAnticipada_ImportarDistribucionTiendas_Form
    Dim objFactAnticipadaBU As New Negocios.FacturacionAnticipadaBU
    Public tipoArchivoImportado As String = ""
    Public entDistribucion As Entidades.DistribucionPedido
    Dim dtErrores As DataTable
    Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
    Dim archivoDistribucionID As Integer
    Dim distribucionGuardada As Boolean = False
    Public soloConsulta As Boolean = False

    Private Sub FacturacionAnticipada_ImportarDistribucionTiendas_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        lblCliente.Text = entDistribucion.Cliente.nombregenerico
        lblPedidoSAY.Text = entDistribucion.PedidoSAY
        lblPedidoSICY.Text = entDistribucion.PedidoSICY
        lblParesPedido.Text = entDistribucion.ParesPedido
        lblOrdenCompra.Text = entDistribucion.OrdenCliente
        lblOTGeneradaSAY.Text = entDistribucion.OrdenTrabajoID

        If soloConsulta Then
            Dim dtDistribucionOT_Detalle As DataTable
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            lblPanelColor.Visible = False
            pnlColorSinTienda.Visible = False
            lblEtiquetasParesArchivo.Visible = False
            lblStatusImportacion.Visible = False
            lblParesArchivo.Visible = False
            lblTextoOT.Text = "OT SAY"
            dtDistribucionOT_Detalle = objFactAnticipadaBU.consultarDistribucionOT_Detalle(entDistribucion.OrdenTrabajoID)
            lblTotalTiendas.Text = dtDistribucionOT_Detalle.Rows.Count
            grdImportacionDistribucion.DataSource = dtDistribucionOT_Detalle
            diseñoGridDistribucion(grdVImportacionDistribucion, "NORMAL")
            lblTitle.Text = "Distribución de OT por Tienda"
            Me.Text = "Distribución de OT por Tienda"
            lblTitle.Location = New Point(254, 24)
        Else

            dtErrores = New DataTable
            dtErrores.Columns.Add("Error", Type.GetType("System.String"))

            Select Case tipoArchivoImportado
                Case "BATTA"
                    lecturaBATTA()
                    If dtErrores.Rows.Count > 0 Then
                        btnGuardar.Enabled = False
                        lblStatusImportacion.Text = "ARCHIVO INCORRECTO"
                        lblStatusImportacion.ForeColor = Color.FromArgb(255, 0, 0)
                        grdImportacionDistribucion.DataSource = dtErrores
                        diseñoGridDistribucion(grdVImportacionDistribucion, "ERROR")
                    Else
                        lblStatusImportacion.Text = "ARCHIVO CORRECTO"
                        lblStatusImportacion.ForeColor = Color.FromArgb(0, 128, 0)
                        diseñoGridDistribucion(grdVImportacionDistribucion, "NORMAL")
                    End If
            End Select
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub guardarDistribucionArchivo(dtDistribucion As DataTable)

        Dim codigoRapido As String
        Dim tienda As String
        Dim pares As Integer
        Dim talla As String

        Try

            entDistribucion.ParesArchivo = dtDistribucion.AsEnumerable().Sum(Function(x) x.Item(26))
            archivoDistribucionID = objFactAnticipadaBU.insertarDistribucionArchivo_Encabezado(entDistribucion, usuarioID)
            If archivoDistribucionID > 0 Then
                For Each row As DataRow In dtDistribucion.Rows
                    codigoRapido = row.Item(19)
                    tienda = row.Item(20)
                    pares = row.Item(26)
                    talla = row.Item(33)
                    objFactAnticipadaBU.insertarDistribucionArchivo_Detalle(archivoDistribucionID, codigoRapido, tienda, pares, talla)
                Next

                Dim dtArchivoValido As DataTable
                dtArchivoValido = objFactAnticipadaBU.validarDatosArchivoImportado(archivoDistribucionID, entDistribucion.PedidoSAY)

                If dtArchivoValido.Rows.Count > 0 Then
                    If dtArchivoValido.Rows(0).Item(0).ToString = "EL ARCHIVO NO ES VALIDO" Then
                        capturarError("EL ARCHIVO NO ES VALIDO, LA CANTIDAD DE PARES NO COINCIDE CON EL PEDIDO.")
                        lblParesArchivo.Text = dtArchivoValido.Rows(0).Item("ParesTotal")
                        lblParesArchivo.ForeColor = Color.FromArgb(255, 0, 0)
                    Else
                        grdImportacionDistribucion.DataSource = dtArchivoValido
                        lblParesArchivo.Text = dtArchivoValido.AsEnumerable().Sum(Function(x) x.Item("TOTAL"))
                        lblTotalTiendas.Text = dtArchivoValido.Rows.Count
                        validarTiendasEmbarques()
                    End If
                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub


    Private Sub lecturaBATTA()
        Dim dtExcelBATTA As DataTable
        Dim ordenClienteArchivo As String
        Try
            dtExcelBATTA = leerArchivoBATTA()
            If dtExcelBATTA.Rows.Count > 0 And dtErrores.Rows.Count <= 0 Then

                ordenClienteArchivo = dtExcelBATTA.Rows(0).Item(0)
                If ordenClienteArchivo <> String.Empty Or ordenClienteArchivo <> Nothing Then
                    If CLng(ordenClienteArchivo) = CLng(entDistribucion.OrdenCliente) Then
                        guardarDistribucionArchivo(dtExcelBATTA)
                    Else
                        capturarError("EL ARCHIVO SELECCIONADO CORRESPONDE A LA OC " + ordenClienteArchivo)
                    End If
                Else
                    capturarError("EL ARCHIVO SELECCIONADO NO TIENE EL FORMATO ESPERADO")
                    capturarError("EL ARCHIVO SELECCIONADO CORRESPONDE A LA OC " + ordenClienteArchivo)
                End If
            Else
                Return
            End If
        Catch ex As Exception
            capturarError("EL ARCHIVO SELECCIONADO NO TIENE EL FORMATO ESPERADO")
        End Try

    End Sub

    Public Function leerArchivoBATTA() As DataTable
        Dim cnn As New OleDb.OleDbConnection
        leerArchivoBATTA = New DataTable
        Dim da As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand

        Dim ofd As New OpenFileDialog
        'ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm|CSV Files (*.csv)|*.csv"
        ofd.Filter = "CSV Files (*.csv)|*.csv"
        Dim file As String = ""

        ofd.ShowDialog()

        file = ofd.FileName

        If file = "" Then
            capturarError("NO SELECCIONO NINGUN ARCHIVO")
        End If

        Dim nombreArchivoDistribucion As String
        Dim rutaDis As String

        Try

            rutaDis = Path.GetDirectoryName(file)
            nombreArchivoDistribucion = Path.GetFileName(file)

            cnn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & rutaDis & ";Extended Properties=""text;HDR=No;FMT=Delimited"";" '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\brunoc\Desktop\Projects.accdb;Persist Security Info=False"
            cnn.Open()

            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [" & nombreArchivoDistribucion & "]"
            cmd.CommandType = CommandType.Text

            da.SelectCommand = cmd
            da.Fill(leerArchivoBATTA)

            leerArchivoBATTA.AcceptChanges()

        Catch ex As Exception
            'show_message("Error", ex.Message)
            capturarError("EL ARCHIVO SELECCIONADO NO TIENE EL FORMATO ESPERADO")
        Finally
            cnn.Close()
        End Try
    End Function

    Private Sub diseñoGridDistribucion(Grid As GridView, tipoGrid As String) 'NORMAL || ERROR

        If tipoGrid = "NORMAL" Then

            Grid.Columns.ColumnByFieldName("Artículo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("Tienda").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            Grid.Columns.ColumnByFieldName("imad_tiendaid").Visible = False

            If soloConsulta Then

            End If

        Else

            Grid.OptionsView.EnableAppearanceEvenRow = True
            Grid.OptionsView.EnableAppearanceOddRow = True
            Grid.OptionsSelection.EnableAppearanceFocusedCell = True
            Grid.OptionsSelection.EnableAppearanceFocusedRow = True
            Grid.Appearance.SelectedRow.Options.UseBackColor = True

            Grid.Appearance.SelectedRow.BackColor = Color.FromArgb(255, 204, 204)

            Grid.Appearance.FocusedRow.BackColor = Color.FromArgb(255, 204, 204)
            Grid.Appearance.FocusedRow.ForeColor = Color.Black

            Grid.Appearance.EvenRow.BackColor = Color.FromArgb(255, 204, 204)
            Grid.Appearance.OddRow.BackColor = Color.FromArgb(255, 204, 204)

        End If

        Grid.OptionsView.BestFitMaxRowCount = -1
        Grid.OptionsView.ColumnAutoWidth = True
        Grid.BestFitColumns()

        Grid.IndicatorWidth = 40

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In Grid.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsColumn.AllowEdit = False
            col.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            If tipoGrid = "NORMAL" Then
                If col.VisibleIndex > 2 Then
                    col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    col.SummaryItem.DisplayFormat = "{0:N0}"
                End If
            End If
        Next

        Grid.BestFitColumns()

    End Sub

    Private Sub validarTiendasEmbarques()
        Dim tiendaSinTiendaEmbrauqeSAY As Integer
        For i As Integer = 0 To grdVImportacionDistribucion.RowCount - 1
            If grdVImportacionDistribucion.GetRowCellValue(i, "imad_tiendaid") = 0 Then
                tiendaSinTiendaEmbrauqeSAY += 1
            End If
        Next
        If tiendaSinTiendaEmbrauqeSAY > 0 Then

            btnGuardar.Enabled = False
        Else
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        objFactAnticipadaBU = New Negocios.FacturacionAnticipadaBU
        Dim usuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim dtDistribucionPedidoID As DataTable

        Try

            ''VALIDA QUE NO TENGA YA GENERARDA OT EL PEDIDO PARA PODER GUARDAR LA DISTRIBUCIÓN
            Dim dtPedidoOT As DataTable
            dtPedidoOT = objFactAnticipadaBU.validarPedidoSinOT(entDistribucion.PedidoSAY)

            If dtPedidoOT.Rows.Count > 0 Then
                show_message("Advertencia", "EL pedido " + dtPedidoOT.Rows(0).Item(0).ToString + " ya tiene una orden de trabajo en estatus " + dtPedidoOT.Rows(0).Item(1))
                Return
            End If

            Dim msg_Conf = New Tools.ConfirmarForm
            msg_Conf.mensaje = "¿Esta seguro de guardar las distribución por " + lblTotalTiendas.Text + " tiendas y generar la Orden de Trabajo?"
            If msg_Conf.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                dtDistribucionPedidoID = objFactAnticipadaBU.insertarDistribucionPedido(entDistribucion, archivoDistribucionID)
                If dtDistribucionPedidoID.Rows.Count > 0 Then
                    show_message("Exito", "Se guardó correctamente las distribución y se generó la Orden de Trabajo " + dtDistribucionPedidoID.Rows(0).Item(0).ToString)
                    lblOTGeneradaSAY.Text = dtDistribucionPedidoID.Rows(0).Item(0).ToString
                    btnGuardar.Enabled = False
                    distribucionGuardada = True
                    Me.Cursor = Cursors.Default
                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Try
            ExportarAExcel(grdVImportacionDistribucion, "DistribucionesPorTienda")
        Catch ex As Exception
            show_message("Error", "Ocurrió un error al exportar la información. " + ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
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
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub capturarError(mensajeError As String)
        Dim Row = dtErrores.NewRow
        Row.Item("Error") = mensajeError

        dtErrores.Rows.Add(Row)
    End Sub

    Private Sub grdVImportacionDistribucion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVImportacionDistribucion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Public Sub ExportarAExcel(Grid As DevExpress.XtraGrid.Views.Grid.GridView, NombreArchivo As String)
        'PREGUNTA AL USUARIO DONDE GUARDAR EL ARCHIVO
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
        SaveFileDialog.FilterIndex = 2
        SaveFileDialog.RestoreDirectory = True

        'ASIGNAMOS UN NOMBRE AL ARCHIVO
        SaveFileDialog.FileName = NombreArchivo + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString + ".xlsx"
        If Grid.RowCount > 0 Then
            If SaveFileDialog.ShowDialog = DialogResult.OK Then

                'ESTO ES NECESARIO PARA QUE EL EXCEL NO HAGA QUE TODAS LAS CUADRICULAS SEAN MUY PEQUEÑAS.
                'ESTO EXPORTARÁ TODAS LAS CUADRICULAS ESPACIADAS UNIFORMENTE.
                Grid.OptionsPrint.AutoWidth = False
                Grid.OptionsPrint.UsePrintStyles = False

                Dim FileName As String = SaveFileDialog.FileName
                DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG
                Grid.ExportToXlsx(FileName)

                show_message("Exito", "Los datos se exportaron correctamente.")

                System.Diagnostics.Process.Start(FileName)
            End If
        Else
            show_message("Exito", "No hay registros para exportar.")
        End If
    End Sub

    Private Sub FacturacionAnticipada_ImportarDistribucionTiendas_Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim confirmar As New Tools.ConfirmarForm
        'If btnGuardar.Visible = True And distribucionGuardada = False Then
        confirmar.mensaje = "Los datos no guardados se borrarán ¿Desea continuar?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                objFactAnticipadaBU = New Negocios.FacturacionAnticipadaBU
                Try
                    objFactAnticipadaBU.borrarDatosImportacion(archivoDistribucionID, entDistribucion.PedidoSAY)
                Catch ex As Exception
                    show_message("Error", ex.Message)
                End Try
            Else
                e.Cancel = True
            End If
        'End If
    End Sub


    Private Sub grdVImportacionDistribucion_RowStyle(sender As Object, e As RowStyleEventArgs) Handles grdVImportacionDistribucion.RowStyle
        Dim grid As GridView = CType(sender, GridView)
        If e.RowHandle < 0 Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            If grid.GetRowCellValue(e.RowHandle, "imad_tiendaid") = 0 And grid.Columns.Count > 2 Then
                e.Appearance.BackColor = pnlColorSinTienda.BackColor
                e.Appearance.ForeColor = Color.White
                lblStatusImportacion.Text = "ARCHIVO INCORRECTO"
                lblStatusImportacion.ForeColor = Color.FromArgb(255, 0, 0)
                btnGuardar.Enabled = False
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub grdVImportacionDistribucion_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdVImportacionDistribucion.RowCellStyle
        Dim grid As GridView = CType(sender, GridView)
        If e.RowHandle < 0 Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            If grid.GetRowCellValue(e.RowHandle, "imad_tiendaid") = 0 And grid.Columns.Count > 2 Then
                e.Appearance.BackColor = pnlColorSinTienda.BackColor
                e.Appearance.ForeColor = Color.White
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub
End Class