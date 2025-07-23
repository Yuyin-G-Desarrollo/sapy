Imports Infragistics
Imports Infragistics.Win.UltraWinGrid

Public Class MensajeriaDestinosCostos
    Dim ValorCeldaCambio As Boolean = False
    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MensajeriaDestinosCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        WindowState = FormWindowState.Maximized
        'Dim checkColumn As UltraGridColumn = gridLista.DisplayLayout.Bands(0).Columns.Add("Seleccionar", "")
        'checkColumn.DataType = GetType(Boolean)
        'checkColumn.Header.VisiblePosition = 1

        llenarTabla()
    End Sub

    Private Sub btnAltas_Click(sender As Object, e As EventArgs) Handles btnAltas.Click
        Dim AltaDestinoMensajeria As New AltaEdicionMensajeriasDestinosCostos
        AltaDestinoMensajeria.ShowDialog()
        llenarTabla()
    End Sub
#Region "GRIDS"




    Public Sub llenarTabla()
        Dim objBU As New Negocios.MensajeriaDestinoCostos
        Dim ListaMensajeria As New List(Of Entidades.Mensajeria)
        ListaMensajeria = objBU.ConsultaMensajeriaDestinoCosto()
        Dim TablaTipoReembarque, TablaTipoUnidad As DataTable
        Dim vTipoEmbarque, vTipoUnidad As New Infragistics.Win.ValueList
        TablaTipoReembarque = objBU.ConsultarTipoEmbarque()
        TablaTipoUnidad = objBU.ConsultarTipoUnidad()

        For Each fila As DataRow In TablaTipoReembarque.Rows
            vTipoEmbarque.ValueListItems.Add(fila.Item("tire_tiporeembarqueid"), fila.Item("tire_nombre"))
        Next
        For Each fila As DataRow In TablaTipoUnidad.Rows
            vTipoUnidad.ValueListItems.Add(fila.Item("unid_unidadid"), fila.Item("unid_nombre"))
        Next
        gridLista.DataSource = ListaMensajeria
        gridLista.DataBind()


        ' Me.gridLista.DisplayLayout.Bands(0).Columns.Add("Seleccionar", "Seleccionar")
        With gridLista.DisplayLayout.Bands(0)
            .Columns("PConsecutivo").Header.Caption = "#"
            .Columns("PConsecutivo").Header.VisiblePosition = 1
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PConsecutivo").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
            .Columns("PConsecutivo").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PNombreProveedor").Header.Caption = "Mensajería"
            .Columns("PNombreProveedor").Header.VisiblePosition = 2
            .Columns("PNombreProveedor").CellActivation = Activation.NoEdit
            .Columns("PNombreProveedor").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
            .Columns("PNombrePoblacion").Header.Caption = "Población"
            .Columns("PNombrePoblacion").Header.VisiblePosition = 3
            .Columns("PNombrePoblacion").CellActivation = Activation.NoEdit
            .Columns("PNombreCiudad").Header.Caption = "Ciudad"
            .Columns("PNombreCiudad").Header.VisiblePosition = 4
            .Columns("PNombreCiudad").CellActivation = Activation.NoEdit
            .Columns("PAbrevEstado").Header.Caption = "Estado"
            .Columns("PAbrevEstado").Header.VisiblePosition = 5
            .Columns("PAbrevEstado").CellActivation = Activation.NoEdit
            .Columns("PAbrevPais").Header.Caption = "País"
            .Columns("PAbrevPais").Header.VisiblePosition = 6
            .Columns("PAbrevPais").CellActivation = Activation.NoEdit
            .Columns("PNombreUnidad").Header.Caption = "*Unidad"
            .Columns("PNombreUnidad").Header.VisiblePosition = 8
            .Columns("PNombreUnidad").ValueList = vTipoUnidad
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PReembarque").Header.Caption = "*Reembarque"
            .Columns("PReembarque").Header.VisiblePosition = 7
            .Columns("PReembarque").ValueList = vTipoEmbarque
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PNombreCiudadPoblacion").Header.Caption = "Ciudad Poblacion"
            .Columns("PNombreCiudadPoblacion").Header.VisiblePosition = 10
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PDiasMinEntregas").Header.Caption = "*Dias Mín. Entrega"
            .Columns("PDiasMinEntregas").Header.VisiblePosition = 11
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PDiasMinEntregas").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PDiasMinEntregas").Style = ColumnStyle.Integer
            .Columns("PDiasMaxEntregas").Header.Caption = "*Dias Max. Entrega"
            .Columns("PDiasMaxEntregas").Style = ColumnStyle.Integer
            .Columns("PDiasMaxEntregas").Header.VisiblePosition = 12
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PFechaAlta").Header.Caption = "Modificación"
            .Columns("PFechaAlta").Header.VisiblePosition = 13
            .Columns("PFechaAlta").Style = ColumnStyle.DateTime
            .Columns("PFechaAlta").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PUsuario").Header.Caption = "Usuario"
            .Columns("PUsuario").Header.VisiblePosition = 14
            .Columns("PUsuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("PDiasMaxEntregas").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PCostoUnidad").Header.Caption = "*Costo"
            .Columns("PCostoUnidad").Format = "n2"
            .Columns("PCostoUnidad").MaskInput = "nnn,nnn.nn"
            .Columns("PCostoUnidad").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PCostoUnidad").Header.VisiblePosition = 9
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit

            .Columns("PIDCostoMensajeria").CellActivation = Activation.NoEdit
            .Columns("PNombreCiudadPoblacion").Hidden = True
            .Columns("PFechaInicioVigencia").Hidden = True
            .Columns("PFechaFinVigencia").Hidden = True
            .Columns("PIDCostoMensajeria").Hidden = True
            .Columns("PIdDestinoMensajeria").Hidden = True
            .Columns("PIdPais").Hidden = True
            .Columns("PIdEstado").Hidden = True
            .Columns("PIdCiudad").Hidden = True
            .Columns("PIdPoblacion").Hidden = True
            .Columns("PIdProveedor").Hidden = True
            .Columns("PActivo").Header.Caption = "  Activo"
            .Columns("PActivo").Header.VisiblePosition = 16
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid
            '.Columns(1).CellActivation = Activation.NoEdit
            '.Columns(1).CellAppearance.TextHAlign = HAlign.Right
            '.Columns(1).Width = 100
        End With
        gridLista.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
        gridLista.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub


    Private Sub gridLista_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridLista.AfterCellUpdate
        If gridLista.Rows.FilterRow.Activated = False Then
                ValorCeldaCambio = True
        End If
    End Sub


    Private Sub gridLista_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles gridLista.BeforeCellUpdate
        Dim NuevoValorMin As String = Replace(gridLista.ActiveRow.Cells("PDiasMinEntregas").Text, "_", "")
        Dim NuevoValorMax As String = Replace(gridLista.ActiveRow.Cells("PDiasMaxEntregas").Text, "_", "")
        Dim objAdvertencia As New Tools.AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen

        If CInt(NuevoValorMin) > CInt(NuevoValorMax) Then
          
            objAdvertencia.mensaje = "El valor de días mínimos de entrega no puede ser mayor a días máximos de entrega."
            objAdvertencia.ShowDialog()
            e.Cancel = True
        Else
            Dim Unidad As String = gridLista.ActiveRow.Cells("PNombreUnidad").Text
            Dim Poblacion As String = gridLista.ActiveRow.Cells("PNombrePoblacion").Text
            Dim Ciudad As String = gridLista.ActiveRow.Cells("PNombreCiudad").Text
            Dim Estado As String = gridLista.ActiveRow.Cells("PAbrevEstado").Text
            Dim Pais As String = gridLista.ActiveRow.Cells("PAbrevPais").Text


            For Each row As UltraGridRow In gridLista.Rows
                If row.Index <> gridLista.ActiveRow.Index Then
                    If row.Cells("PNombreUnidad").Text = Unidad And row.Cells("PNombrePoblacion").Text = Poblacion And row.Cells("PNombreCiudad").Text = Ciudad _
                        And row.Cells("PAbrevEstado").Text = Estado And row.Cells("PAbrevPais").Text = Pais And row.Cells("PNombreProveedor").Text = gridLista.ActiveRow.Cells("PNombreProveedor").Text Then
                        objAdvertencia.mensaje = "Ya existe esta unidad para esta ruta."
                        objAdvertencia.ShowDialog()
                        e.Cancel = True
                        Return
                    End If
                End If
            Next
        End If



    End Sub

    Private Sub gridLista_AfterRowUpdate(sender As Object, e As RowEventArgs) Handles gridLista.AfterRowUpdate
        Dim objConfirmacion As New Tools.ConfirmarForm
        objConfirmacion.mensaje = "¿Esta seguro que desea modificar el contenido?"
        objConfirmacion.StartPosition = FormStartPosition.CenterScreen

        If MessageBox.Show("¿Esta seguro que desea modificar el contenido?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Dim OBJBU As New Negocios.MensajeriaDestinoCostos
            Dim Entidad As New Entidades.Mensajeria
            Dim row As UltraGridRow = gridLista.ActiveRow
            Entidad.PIDCostoMensajeria = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PIDCostoMensajeria").Value
            Entidad.PCostoUnidad = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PCostoUnidad").Value
            Entidad.PDiasMinEntregas = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PDiasMinEntregas").Value
            Entidad.PDiasMaxEntregas = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PDiasMaxEntregas").Value

            Entidad.PReembarque = row.Cells("PReembarque").Column.ValueList.GetValue(gridLista.ActiveRow.Cells("PReembarque").Value.ToString, 0)
            Entidad.PNombreUnidad = row.Cells("PNombreUnidad").Column.ValueList.GetValue(gridLista.ActiveRow.Cells("PNombreUnidad").Value.ToString, 0)

            Entidad.PActivo = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PActivo").Value
            OBJBU.ActualizarCostoDestino(Entidad, False)
            llenarTabla()
        Else
            llenarTabla()
        End If
    End Sub

    Private Sub gridLista_CellChange(sender As Object, e As CellEventArgs) Handles gridLista.CellChange

    End Sub

    Private Sub gridLista_TextChanged(sender As Object, e As EventArgs) Handles gridLista.TextChanged

    End Sub

#End Region

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        EnvProcedimiento()
    End Sub


    Public Sub EnvProcedimiento()
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                filter += 1
            End If

        Next
        MsgBox(filter)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ActualizacionMasiva As New ActualizacionMasivaMensajeriasDestinosCostos
        ActualizacionMasiva.Show()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

   
    Private Sub btnExpExcel_Click(sender As Object, e As EventArgs) Handles btnExpExcel.Click
        Dim ExportExcel As New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        SaveAs.Filter = " XLS Excel (*.xls*)|*.xls| XLSX |*.xlsx"
        If gridLista.Rows.Count > 0 Then
            With SaveAs
                .Title = "Guardar archivo como:"
                .Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*"
                .ShowDialog()
                If .FileName <> "" Then
                    ExportExcel.Export(gridLista, .FileName)
                    Dim objExcelWorkBook As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook
                    With objExcelWorkBook
                        .Worksheets.Add("Hoja 1")
                        ExportExcel.Export(gridLista, objExcelWorkBook)
                    End With
                    Try
                        System.Diagnostics.Process.Start(.FileName)
                    Catch ex As Exception
                        MsgBox(ex)
                    End Try
                End If
            End With
        Else
            MessageBox.Show("Seleccionar algo ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        llenarTabla()
    End Sub

   
   
    Private Sub gridLista_BeforeRowInsert(sender As Object, e As BeforeRowInsertEventArgs) Handles gridLista.BeforeRowInsert
        e.Cancel = True
    End Sub
End Class