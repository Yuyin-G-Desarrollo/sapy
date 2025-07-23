Imports DevExpress.XtraExport.Helpers
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Tools
Imports System.IO
Imports System.Xml
Imports DevExpress.Export
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel

Public Class CapacidadProduccionForm

    Dim datosExcel As New DataTable
    Dim anio As Integer = 0
    ''Dim datosSinGuardar As Boolean = 0 '' variable para saber si el excel se guardo

    Private Sub CapacidadProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnImpCod.Enabled = False
        btnExpImp.Enabled = False
        llenarComboAños()
        lblFechaUltimaActualización.Text = Date.Now.ToString
    End Sub



    Private Sub cmbAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnios.SelectedIndexChanged
        Dim anioActual As Integer = DateTime.Now.Year
        If (CInt(cmbAnios.SelectedItem.ToString)) = anioActual Then
            btnImpCod.Enabled = True
        Else
            btnImpCod.Enabled = False
        End If
    End Sub

    Private Sub DisenioDevGridBd()
        grdDatosCapacidadProduccion.IndicatorWidth = 50
        For Each col As Columns.GridColumn In grdDatosCapacidadProduccion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            DiseñoGrid.EstiloColumna(grdDatosCapacidadProduccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        Next
        grdDatosCapacidadProduccion.OptionsView.ColumnAutoWidth = True
        grdDatosCapacidadProduccion.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdDatosCapacidadProduccion.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N2"

        If IsNothing(grdDatosCapacidadProduccion.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            grdDatosCapacidadProduccion.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            grdDatosCapacidadProduccion.GroupSummary.Add(item)
        End If

    End Sub


    Private Sub DisenioDevGrid()
        grdDatosCapacidadProduccion.IndicatorWidth = 50
        For Each col As Columns.GridColumn In grdDatosCapacidadProduccion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
            DiseñoGrid.EstiloColumna(grdDatosCapacidadProduccion, col.FieldName, col.FieldName, True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        Next
        grdDatosCapacidadProduccion.Columns.ColumnByFieldName("SEM").Caption = "SEMANA"
        grdDatosCapacidadProduccion.Columns.ColumnByFieldName("DES").Caption = "DESCRIPCIÓN"
        grdDatosCapacidadProduccion.Columns.ColumnByFieldName("Ok").Visible = False
        grdDatosCapacidadProduccion.Columns.ColumnByFieldName("Renglon").Visible = False
        grdDatosCapacidadProduccion.OptionsView.ColumnAutoWidth = True

        If IsNothing(grdDatosCapacidadProduccion.Columns("DES").Summary.FirstOrDefault(Function(x) x.FieldName = "DES")) = True Then
            grdDatosCapacidadProduccion.Columns("DES").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DES", "{0:N0}")

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DES"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            grdDatosCapacidadProduccion.GroupSummary.Add(item)
        End If
    End Sub

    Private Sub ImportarExcel()
        Dim mensaje As String = "Registrados correctamente."
        'Dim objBU As New Negocios.CodigosEspecialesClienteBU

        Dim datosIds As New DataTable
        Dim NombreArchivo As String = ""
        Dim ban As Integer = 0
        Try
            Dim hoja As String = ""
            datosExcel = Tools.Excel.LlenarTablaExcelListaTablas(hoja, "", NombreArchivo)
            If datosExcel.Rows.Count > 0 Then
                grdCapacidadProduccion.DataSource = Nothing
                grdDatosCapacidadProduccion.Columns.Clear()
                grdCapacidadProduccion.DataSource = datosExcel
                DisenioDevGrid()
                lblRegistros.Text = datosExcel.Rows.Count
            Else
                grdCapacidadProduccion.DataSource = Nothing
                grdDatosCapacidadProduccion.Columns.Clear()
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar")
            End If

        Catch ex As Exception
            Dim objMensajeError As New Tools.ErroresForm
            objMensajeError.mensaje = ex.Message
            objMensajeError.ShowDialog()
        End Try
    End Sub

    Private Sub btnImpCod_Click(sender As Object, e As EventArgs) Handles btnImpCod.Click
        Me.Cursor = Cursors.WaitCursor
        ImportarExcel()
        btnExpImp.Enabled = True
        ''datosSinGuardados = 1
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Visible = True
    End Sub

    Private Sub grdDatosCapacidadProduccion_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdDatosCapacidadProduccion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiarGrid()
        btnExpImp.Enabled = False
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        llenarGridCapacidadProduccion(CInt(cmbAnios.SelectedItem.ToString))
        btnExpImp.Enabled = True
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim dtRespuesta As New DataTable
        Dim objBu As New Ventas.Negocios.CapacidadProduccionBU

        show_message("Advertencia", "Esta seguro de guardar los registros")

        Try
            If (grdDatosCapacidadProduccion.RowCount > 0) Then
                If datosExcel.Rows.Count > 0 Then
                    ''validamos que el combo años esteseleccionado con el año actual
                    If (CInt(cmbAnios.SelectedItem.ToString)) = DateTime.Now.Year Then
                        Dim vXmlProyecciones As XElement = New XElement("Proyecciones")
                        Dim fechaActual = Date.Now
                        If datosExcel.Rows.Count > 0 Then

                            For Each row As DataRow In datosExcel.Rows
                                If IsDBNull(row("DES")) Then
                                    row("DES") = 0
                                End If

                                Dim vNodo As XElement = New XElement("Proyeccion")
                                vNodo.Add(New XAttribute("semana", row(0)))
                                vNodo.Add(New XAttribute("anio", cmbAnios.Text))
                                vNodo.Add(New XAttribute("pares", row(1)))
                                ''vNodo.Add(New XAttribute("fecha", fechaActual))
                                vXmlProyecciones.Add(vNodo)
                            Next
                            dtRespuesta = objBu.registrarCapacidadProduccion(vXmlProyecciones.ToString)
                        End If

                        If dtRespuesta.Rows(0).Item("respuesta") = 0 Then
                            show_message("Error", dtRespuesta.Rows(0).Item("mensaje"))
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            limpiarGrid()
                        Else
                            show_message("Exito", "Se registraron correctamente la capacidad producción.")
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            limpiarGrid()
                            ''datosSinGuardados = 0
                        End If
                    Else
                        show_message("Advertencia", "Debe seleccionar el año actual")
                    End If
                Else
                    show_message("Advertencia", "Debe importar el excel")
                End If
            Else
                show_message("Advertencia", "No hay datos a registrar")
            End If
        Catch ex As Exception
            Dim objMensajeError As New Tools.ErroresForm
            objMensajeError.mensaje = ex.Message
            objMensajeError.ShowDialog()
        End Try


    End Sub
    Private Sub btnExpImp_Click(sender As Object, e As EventArgs) Handles btnExpImp.Click

        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        Try
            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True
                Dim exportOptions = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
                'AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    grdCapacidadProduccion.ExportToXlsx(.SelectedPath + "\Datos_CapacidadProduccion_" + fecha_hora + ".xlsx", exportOptions)

                    Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " + "\Datos_CapacidadProduccion_" + fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_CapacidadProduccion_" + fecha_hora + ".xlsx")
                End If
            End With

        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        '    If ''datosSinGuardados = 1 Then
        '        show_message("Advertencia", "Esta seguro de cerrar la ventana, los datos aun no se han guardado")
        '    End If
        Me.Close()
    End Sub


#Region "METODOS"
    Private Sub llenarGridCapacidadProduccion(Anio As Integer)
        Try
            limpiarGrid()
            Cursor = Cursors.WaitCursor
            Dim objBU As New Negocios.CapacidadProduccionBU
            Dim dtConsultarCapacidadProduccion As DataTable = objBU.consultarCapacidadProduccion(Anio)

            If dtConsultarCapacidadProduccion.Rows.Count > 0 Then
                grdCapacidadProduccion.DataSource = dtConsultarCapacidadProduccion
                DisenioDevGridBd()

                lblRegistros.Text = grdDatosCapacidadProduccion.RowCount
                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            show_message("Error", ex.ToString)
            Cursor = Cursors.Default
        End Try


    End Sub
    Private Sub llenarComboAños()
        Dim anio As Integer
        With cmbAnios
            For anio = 2018 To DateTime.Now.Year
                cmbAnios.Items.Add(anio)
            Next
            cmbAnios.SelectedIndex = 0
        End With
    End Sub

    Private Sub limpiarGrid()
        grdCapacidadProduccion.DataSource = Nothing
        grdDatosCapacidadProduccion.Columns.Clear()
        cmbAnios.SelectedIndex = 0
        lblRegistros.Text = "0"
        btnExpImp.Enabled = False
    End Sub
#Region "mensajes"
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
#End Region


    Private Sub exportOptions_CustomizeCell(e As CustomizeCellEventArgs)
        Throw New NotImplementedException()
    End Sub

    Private Sub grdDatosCapacidadProduccion_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles grdDatosCapacidadProduccion.RowCellStyle
        Try
            Dim currentView As GridView
            currentView = sender
            'If datosGuardados = 0 Then
            '    e.Appearance.ForeColor = Color.Purple
            'Else
            '    e.Appearance.BackColor = Color.Black
            'End If

        Catch ex As Exception

        End Try
    End Sub



#End Region
End Class