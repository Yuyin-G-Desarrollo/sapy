

Imports System.IO
Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Framework.Negocios
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Tools
Imports Tools.modMensajes

Public Class Programacion_ColocacionSemanal_MapaOcupacionForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim grupo As String
    Dim año As Integer
    Dim SemanaInicio As Integer
    Dim SemanaFin As Integer
    Dim añoFin As Integer
    Dim tabla As New DataTable
    Dim tablaEncabezado As New DataTable
    Dim spid As Integer
    Dim NumSemana As Integer
    Dim ListaNavesSeleccionadas As New List(Of Integer)
    Dim ListaSemanasSeleccionadas As New List(Of String)

    Dim dtResultadoConsultaCopia As New DataTable

    Structure semanaCapacidad
        Dim semana As Integer
        Dim capacidad As Integer
        Dim atr As Integer
        Dim año_semana As Integer
    End Structure
    Private Sub Programacion_ColocacionSemanal_MapaOcupacionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdVReporte.Bands.Clear()
        grdVReporte.Columns.Clear()
        WindowState = FormWindowState.Maximized
        NumSemana = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudAño.Value = DatePart(DateInterval.Year, Now)
        lblSemanaActual.Text = CStr(NumSemana)
        nudSemanaInicio.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaFinal.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        nudSemanaFinal.TextAlign = HorizontalAlignment.Center
        nudSemanaInicio.TextAlign = HorizontalAlignment.Center
        cmbNave.SelectedIndex = 0
        consultaUltimaSemanaDelAñoInicio(DatePart(DateInterval.Year, Now))
        consultaUltimaSemanaDelAñoFin(DatePart(DateInterval.Year, Now))
    End Sub

    Private Sub consultaUltimaSemanaDelAñoInicio(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            'nudSemanaFinal.Maximum = maximoSemana
            nudSemanaInicio.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub consultaUltimaSemanaDelAñoFin(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaFinal.Maximum = maximoSemana
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Public Sub consultaMapaOcupacion()
        Me.Cursor = Cursors.WaitCursor
        dtResultadoConsultaCopia = New DataTable()

        lblFechaUltimaActualización.Text = "-"
        Dim obj As New Programacion_MapaOcupacionBU

        If cmbNave.SelectedItem Is Nothing Or cmbNave.Text = "TODAS" Then
            grupo = ""
        Else
            grupo = cmbNave.SelectedItem
        End If
        año = nudAño.Value
        SemanaInicio = nudSemanaInicio.Value
        SemanaFin = nudSemanaFinal.Value
        añoFin = nudAñoFin.Value

        Try
            grdReporte.DataSource = Nothing
            grdVReporte.Columns.Clear()
            tabla = obj.consultaMapaOcupacion(grupo, año, SemanaInicio, SemanaFin, añoFin)
            dtResultadoConsultaCopia = tabla.Copy()
            If tabla.Rows.Count > 0 Then
                spid = tabla.Rows(0).Item("SPID").ToString()
                disenioGrigEncabezados(spid)
                grdReporte.DataSource = tabla
                lblFechaUltimaActualización.Text = Date.Now.ToString
            Else
                show_message("Advertencia", "No se encontraron datos por mostrar.")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
    Public Sub obtenerNavesSeleccionadas()
        ListaNavesSeleccionadas = New List(Of Integer)
        For Each x As Integer In grdVReporte.GetSelectedRows
            ListaNavesSeleccionadas.Add(Integer.Parse(grdVReporte.GetRowCellValue(x, "IdNave").ToString))
        Next
    End Sub
    Public Sub obtenerSemanasSeleccionadas()
        ListaSemanasSeleccionadas = New List(Of String)
        ListaNavesSeleccionadas = New List(Of Integer)
        For Each x As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
            ListaSemanasSeleccionadas.Add(obtenerSemana(x.Column.VisibleIndex))
            ListaNavesSeleccionadas.Add(grdVReporte.GetRowCellValue(x.RowHandle, "IdNave"))
        Next
    End Sub
    Private Function validarSemanasNavesSeleccionadas()
        Dim naveSemanaSeleccionada = False
        For Each x As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
            If x.Column.Caption <> "Nave" Then naveSemanaSeleccionada = True
        Next
        Return naveSemanaSeleccionada
    End Function
    Private Function obtenerSemanaNaveSeleccionada()
        Dim tabla As New DataTable
        Try
            Dim columna As New DataColumn
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Boolean")
            columna.ColumnName = " "
            columna.Caption = " "
            columna.ReadOnly = False
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los Id's de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "NaveId"
            columna.Caption = "NaveId"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los nombres de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.String")
            columna.ColumnName = "Nave"
            columna.Caption = "Nave"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los numeros de las semanas seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Semana"
            columna.Caption = "Semana"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para el año
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Año"
            columna.Caption = "Año"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para los numeros de las capacidades de las semanas seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Capacidad"
            columna.Caption = "Capacidad"
            columna.ReadOnly = False
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para los numeros de los pares artrasados de las semanas seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "ATR"
            columna.Caption = "ATR"
            columna.ReadOnly = False
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para los valores originales a editar (Capacidad)
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "CapacidadOriginal"
            columna.Caption = "CapacidadOriginal"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para los valores originales a editar (ATR)
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "ATROriginal"
            columna.Caption = "ATROriginal"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.String")
            columna.ColumnName = "OcupacionInicial"
            columna.Caption = "Ocupación Inicial"

            For Each x As Integer In grdVReporte.GetSelectedRows
                Dim listaSemanas As New List(Of semanaCapacidad)
                Dim naveId As Integer = grdVReporte.GetRowCellValue(x, "IdNave")
                Dim nombreNave As String = grdVReporte.GetRowCellValue(x, "Nave")
                For Each y As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
                    If y.RowHandle = x Then
                        Dim semana As String
                        Dim numeroSemana As Integer
                        numeroSemana = Int((y.Column.VisibleIndex - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
                        semana = grdVReporte.Bands.Item(numeroSemana).Name.ToString & "-SEMA"
                        If grdVReporte.GetRowCellValue(x, semana) = 1 Then
                            Dim obj As New semanaCapacidad
                            obj.semana = obtenerSemanaCerrar(y.Column.VisibleIndex)
                            obj.capacidad = obtenerCapacidad(y.Column.VisibleIndex, y.RowHandle)
                            obj.atr = obtenerATR(y.Column.VisibleIndex, y.RowHandle)
                            listaSemanas.Add(obj)
                        End If
                    End If
                Next

                For Each y As semanaCapacidad In listaSemanas.AsEnumerable.Distinct
                    Dim fila As DataRow
                    fila = tabla.NewRow
                    fila.Item(0) = False
                    fila.Item(1) = naveId
                    fila.Item(2) = nombreNave
                    fila.Item(3) = y.semana
                    fila.Item(4) = año
                    fila.Item(5) = y.capacidad
                    fila.Item(6) = y.atr
                    fila.Item(7) = y.capacidad
                    fila.Item(8) = y.atr
                    tabla.Rows.Add(fila)
                Next
            Next

        Catch ex As Exception

        End Try
        Return tabla
    End Function
    Private Function obtenerSemanaNavesACerrar()
        Dim tabla As New DataTable
        Try
            Dim columna As New DataColumn
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Boolean")
            columna.ColumnName = " "
            columna.Caption = " "
            columna.ReadOnly = False
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los Id's de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "NaveId"
            columna.Caption = "NaveId"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los nombres de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.String")
            columna.ColumnName = "Nave"
            columna.Caption = "Nave"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los numeros de las semanas seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Semana"
            columna.Caption = "Semana"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para el año
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Año"
            columna.Caption = "Año"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            For Each x As Integer In grdVReporte.GetSelectedRows
                Dim listaSemanas As New List(Of semanaCapacidad)
                Dim naveId As Integer = grdVReporte.GetRowCellValue(x, "IdNave")
                Dim nombreNave As String = grdVReporte.GetRowCellValue(x, "Nave")

                For Each y As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
                    If y.RowHandle = x Then
                        Dim semana As String
                        Dim numeroSemana As Integer
                        Dim objBU As New Programacion_MapaOcupacionBU
                        Dim SePuedeCerrar As Integer = 0

                        numeroSemana = Int((y.Column.VisibleIndex - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
                        semana = grdVReporte.Bands.Item(numeroSemana).Name.ToString & "-SEMA"

                        SePuedeCerrar = objBU.ValidarCierreNave(naveId)

                        If grdVReporte.GetRowCellValue(x, semana) = 1 And grdVReporte.GetRowCellValue(x, (semana & "ANT").ToString()) = 0 Or SePuedeCerrar = 1 Then
                            Dim obj As New semanaCapacidad
                            obj.semana = obtenerSemanaCerrar(y.Column.VisibleIndex)
                            obj.año_semana = obtenerAño(y.Column.VisibleIndex)
                            obj.capacidad = 0
                            obj.atr = 0
                            listaSemanas.Add(obj)
                        End If
                    End If
                Next

                For Each y As semanaCapacidad In listaSemanas.AsEnumerable.Distinct
                    Dim fila As DataRow
                    fila = tabla.NewRow
                    fila.Item(0) = False
                    fila.Item(1) = naveId
                    fila.Item(2) = nombreNave
                    fila.Item(3) = y.semana
                    fila.Item(4) = y.año_semana
                    tabla.Rows.Add(fila)
                Next
            Next

        Catch ex As Exception

        End Try
        Return tabla
    End Function
    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        If validarSemanasNavesSeleccionadas() Then
            Dim ventana As New Programacion_ColocacionSemanal_DetallesOcupacionSemanal
            obtenerSemanasSeleccionadas()
            Dim semanasTexto As String = String.Empty
            For Each semana As String In ListaSemanasSeleccionadas
                semanasTexto += semana
            Next
            If ListaSemanasSeleccionadas.Count = 0 Or semanasTexto = "" Then
                objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
                objAdvertencia.ShowDialog()
            Else
                ventana.listaSemanas = ListaSemanasSeleccionadas
                ventana.listaNaves = ListaNavesSeleccionadas
                ventana.Año = año
                ventana.ventanaPrincipal = Me
                ventana.MdiParent = Me.MdiParent
                ventana.Show()
            End If
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub btnCerrarSemanas_Click(sender As Object, e As EventArgs) Handles btnCerrarSemanas.Click
        If validarSemanasNavesSeleccionadas() Then
            Dim ventana As New Programacion_ColocacionSemanal_CerrarSemanasForm
            Dim objPlanFabricacion As New ConfirmarForm
            Dim objBU As New PlanFabricacionBU
            Dim dtObtienePlanFabricacion As New DataTable("dtPlanFabricacion")
            Dim objBUReporte As New ReportesBU
            Dim EntidadReporte As New Entidades.Reportes
            Dim MasterPlanFabricacion As New DataSet("MasterPlanFabricacion")

            ventana.tabla = obtenerSemanaNavesACerrar()
            ventana.año = año

            If ventana.tabla.Rows.Count > 0 And ventana.tabla.Rows.Count < 2 Then

                If ventana.ShowDialog() = DialogResult.OK Then
                    consultaMapaOcupacion()
                End If
            Else
                objAdvertencia.mensaje = "Seleccione una sola nave para realizar el proceso. Sin registros verifique que las semanas se encuentren abiertas y/o que la anterior se encuentre con plan autorizado."
                objAdvertencia.ShowDialog()
            End If
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
            objAdvertencia.ShowDialog()
        End If

    End Sub


    Private Sub EditarCapacidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarCapacidadToolStripMenuItem.Click
        'If validarSemanasNavesSeleccionadas() Then
        Dim ventana As New Programacion_ColocacionSemanal_EditarCapacidadesForm
        ventana.tabla = obtenerSemanaNaveSeleccionada()
        ventana.año = año
        'If ventana.tabla.Rows.Count > 0 Then
        ventana.StartPosition = FormStartPosition.CenterScreen
        If ventana.ShowDialog() = DialogResult.OK Then
            consultaMapaOcupacion()
        End If
        'Else
        '    objAdvertencia.mensaje = "Sin registros verifique que las semanas se encuentren abiertas."
        '    objAdvertencia.ShowDialog()
        'End If
        'Else
        '    objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
        '    objAdvertencia.ShowDialog()
        'End If

    End Sub

    Private Sub btnConfiguraciones_Click(sender As Object, e As EventArgs) Handles btnConfiguraciones.Click
        'Dim punto As Point
        'punto.X = btnConfiguraciones.Location.X + btnConfiguraciones.Width + pnlConfiguraciones.Location.X
        'punto.Y = btnConfiguraciones.Location.Y + btnConfiguraciones.Height
        'cmsConfiguraciones.Show(punto)
        cmsConfiguraciones.Show(MousePosition)
    End Sub

    Private Sub TamañoDeLoteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TamañoDeLoteToolStripMenuItem.Click
        Dim ventana As New Programacion_ColocacionSemanal_EditarTamañoLoteForm
        ventana.StartPosition = FormStartPosition.CenterScreen
        ventana.ShowDialog()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        consultaMapaOcupacion()
        If grdVReporte.RowCount Then pnlParametros.Height = 27
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Public Sub disenioGrigEncabezados(ByVal spid As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Dim bandPadre As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listHijo As New List(Of Object)
        Dim contadorColor As Integer = 1

        tablaEncabezado = obj.consultaSPID_Encabezados(spid)

        grdVReporte.Columns.Clear()
        grdVReporte.Bands.Clear()
        Dim list1 = tablaEncabezado.AsEnumerable.Select(Function(x) x.Item("Fecha")).Distinct.ToList

        For Each FilaEncabezados As String In list1
            Dim particiones As String() = FilaEncabezados.Split(New Char() {"-"c})
            bandPadre = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            bandPadre.Name = FilaEncabezados
            If FilaEncabezados <> "Nave" And FilaEncabezados <> "TOTAL" Then
                bandPadre.Caption = Replace(String.Join(vbCrLf, particiones(1), particiones(2), particiones(0).ToString), "$", "-")
                bandPadre.Caption = Replace(String.Join(vbCrLf, bandPadre.Caption), "*", " - ")
            Else bandPadre.Caption = particiones(0)
            End If
            bandPadre.RowCount = 3
            grdVReporte.Bands.Add(bandPadre)
            grdVReporte.Bands.Item(bandPadre.Name).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            listHijo = tablaEncabezado.AsEnumerable.Where(Function(x) x.Item("Fecha") = FilaEncabezados).Select(Function(x) x.Item("emcs_tipo")).Distinct.ToList
            For Each columna As String In listHijo
                If FilaEncabezados <> "Nave" And FilaEncabezados <> "IdNave" And FilaEncabezados <> "TOTAL" Then

                    grdVReporte.Columns.AddField(FilaEncabezados + "-" + columna)
                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).Name = FilaEncabezados + "-" + columna
                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).DisplayFormat.FormatString = "{0:n0}"
                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).Caption = columna
                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).OwnerBand = bandPadre
                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).Visible = True


                    If columna = "SEMA" Or columna = "SEMAANT" Or columna = "STSEMA" Then grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).Visible = False

                    grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

                    If contadorColor Mod 2 <> 0 Then grdVReporte.Columns.ColumnByFieldName(FilaEncabezados + "-" + columna).AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

                Else
                    grdVReporte.Columns.AddField(columna)
                    grdVReporte.Columns.ColumnByFieldName(columna).Name = columna
                    grdVReporte.Columns.ColumnByFieldName(columna).Caption = columna
                    grdVReporte.Columns.ColumnByFieldName(columna).OwnerBand = bandPadre
                    If columna = "IdNave" Then
                        grdVReporte.Columns.ColumnByFieldName(columna).Visible = False
                    Else
                        grdVReporte.Columns.ColumnByFieldName(columna).Visible = True
                    End If
                    If FilaEncabezados = "TOTAL" Then

                        grdVReporte.Columns.ColumnByFieldName(columna).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        grdVReporte.Columns.ColumnByFieldName(columna).DisplayFormat.FormatString = "{0:n0}"
                        grdVReporte.Columns.ColumnByFieldName(columna).Caption = Replace(columna, "T_", "")

                        If contadorColor Mod 2 <> 0 Then grdVReporte.Columns.ColumnByFieldName(columna).AppearanceCell.BackColor = Color.FromArgb(180, 198, 231)

                    End If
                    grdVReporte.Columns.ColumnByFieldName(columna).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                End If
            Next
            If FilaEncabezados <> "Nave" Then contadorColor = contadorColor + 1
        Next

        grdVReporte.Bands(0).Caption = ""
        grdVReporte.Bands(0).Fixed = Columns.FixedStyle.Left

        grdVReporte.OptionsView.EnableAppearanceEvenRow = False
        grdVReporte.OptionsSelection.EnableAppearanceFocusedCell = True
        grdVReporte.OptionsSelection.MultiSelect = True
        grdVReporte.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        grdVReporte.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus
        grdVReporte.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        grdVReporte.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        grdVReporte.Appearance.FocusedCell.ForeColor = Color.White
        grdVReporte.Appearance.SelectedRow.ForeColor = Color.White
        grdVReporte.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVReporte.Appearance.HideSelectionRow.ForeColor = Color.White
        grdVReporte.Appearance.HideSelectionRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVReporte.OptionsClipboard.AllowCopy = True
        grdVReporte.OptionsView.ShowFilterPanelMode = False

        grdVReporte.BestFitColumns()

        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
            If col.Caption <> "Nave" And col.Caption <> "PORC" Then
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = col.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                grdVReporte.GroupSummary.Add(item)
            End If
            If (col.Caption = "PORC") Then
                col.Caption = "%"
                col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                col.DisplayFormat.FormatString = "{0:f1} %"

                col.Summary.Add(DevExpress.Data.SummaryItemType.Custom, col.FieldName, "{0:f1} %")
                item = New DevExpress.XtraGrid.GridGroupSummaryItem
                item.FieldName = col.FieldName
                item.SummaryType = DevExpress.Data.SummaryItemType.Custom
                item.DisplayFormat = "{0:f1} %"
                grdVReporte.GroupSummary.Add(item)
            End If

        Next

        validarChecks()
    End Sub


    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New Tools.AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New Tools.AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New Tools.ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New Tools.ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New Tools.ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub
    Public Function validarChecks()
        Dim boolCapacidad As Boolean = False
        Dim boolParesColocados As Boolean = False
        Dim boolPorcentaje As Boolean = False
        Dim boolEquivalencia As Boolean = False
        Dim boolSemATR As Boolean = False
        If chkCapacidad.Checked = False And chkPrsColocados.Checked = False And chkEquivalencia.Checked = False And chkProcOcupacion.Checked = False And chkSemanaAtrasada.Checked = False Then
            Return False
        Else
            If grdVReporte.Columns.Count > 1 Then
                If (chkCapacidad.Checked) Then boolCapacidad = True
                If (chkPrsColocados.Checked) Then boolParesColocados = True
                If (chkEquivalencia.Checked) Then boolEquivalencia = True
                If (chkProcOcupacion.Checked) Then boolPorcentaje = True
                If (chkSemanaAtrasada.Checked) Then boolSemATR = True
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVReporte.Columns
                    If (col.Caption = "%") Then col.Visible = boolPorcentaje
                    If (col.Caption = "CAP") Then col.Visible = boolCapacidad
                    If (col.Caption = "PRS") Then col.Visible = boolParesColocados
                    If (col.Caption = "EQ") Then col.Visible = boolEquivalencia
                    If (col.Caption = "ATR") Then col.Visible = boolSemATR
                Next
            End If
            Return True
        End If
    End Function
    Public Function obtenerSemana(ByVal numColumna As Integer)
        If numColumna > 0 Then
            Dim semana As String = ""
            Dim colSemana As Integer = 0
            colSemana = Int((numColumna - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
            If grdVReporte.Bands.Item(colSemana).Caption.ToString() <> "TOTAL" Then
                semana = grdVReporte.Bands.Item(colSemana).Caption.ToString().Substring(grdVReporte.Bands.Item(colSemana).Caption.ToString().Length - 9)

                semana = Replace(Replace(semana, Chr(10), ""), Chr(13), "")
            End If

            Return semana
        End If
        Return numColumna
    End Function
    Public Function obtenerSemanaCerrar(ByVal numColumna As Integer)
        If numColumna > 0 Then
            Dim semana As String = ""
            Dim colSemana As Integer = 0
            colSemana = Int((numColumna - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
            semana = grdVReporte.Bands.Item(colSemana).Caption.ToString().Substring(grdVReporte.Bands.Item(colSemana).Caption.ToString().Length - 10)

            semana = Replace(Replace(semana, Chr(10), ""), Chr(13), "")

            semana = Split(semana, " - ")(1)

            Return semana
        End If
        Return numColumna
    End Function
    Public Function obtenerAño(ByVal numColumna As Integer)
        If numColumna > 0 Then
            Dim año_semana As String = ""
            Dim colAño_Semana As Integer = 0
            colAño_Semana = Int((numColumna - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
            año_semana = grdVReporte.Bands.Item(colAño_Semana).Caption.ToString().Substring(grdVReporte.Bands.Item(colAño_Semana).Caption.ToString().Length - 9)

            año_semana = Replace(Replace(año_semana, Chr(10), ""), Chr(13), "")

            año_semana = Split(año_semana, " - ")(0)

            Return año_semana
        End If
        Return numColumna
    End Function

    Public Function obtenerCapacidad(ByVal numColumna As Integer, ByVal fila As Integer)
        If numColumna > 0 Then
            Dim semana As Integer = 0
            Dim columnaCapacidad As String
            semana = Int((numColumna - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
            columnaCapacidad = grdVReporte.Bands.Item(semana).Name.ToString & "-CAP"
            Return grdVReporte.GetRowCellValue(fila, columnaCapacidad)
        End If
        Return numColumna
    End Function
    Public Function obtenerATR(ByVal numColumna As Integer, ByVal fila As Integer)
        If numColumna > 0 Then
            Dim semana As Integer = 0
            Dim columnaATR As String
            semana = Int((numColumna - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
            columnaATR = grdVReporte.Bands.Item(semana).Name.ToString & "-ATR"
            Return grdVReporte.GetRowCellValue(fila, columnaATR)
        End If
        Return numColumna
    End Function
    Private Sub grdVReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub chkCapacidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkCapacidad.CheckedChanged
        If validarChecks() = False Then
            If chkCapacidad.Checked = False Then chkCapacidad.Checked = True
        End If
    End Sub

    Private Sub chkPrsColocados_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrsColocados.CheckedChanged
        If validarChecks() = False Then
            If chkPrsColocados.Checked = False Then chkPrsColocados.Checked = True
        End If
    End Sub

    Private Sub chkUnidadesColocadas_CheckedChanged(sender As Object, e As EventArgs) Handles chkEquivalencia.CheckedChanged
        If validarChecks() = False Then
            If chkEquivalencia.Checked = False Then chkEquivalencia.Checked = True
        End If
    End Sub

    Private Sub chkProcOcupacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkProcOcupacion.CheckedChanged
        If validarChecks() = False Then
            If chkProcOcupacion.Checked = False Then chkProcOcupacion.Checked = True
        End If
    End Sub
    Private Sub grdVReporte_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles grdVReporte.RowCellStyle
        Dim view As GridView = sender
        If e.Column.VisibleIndex > 0 Then
            Dim semana As String
            Dim numeroSemana As Integer
            numeroSemana = Int((e.Column.VisibleIndex - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
            semana = grdVReporte.Bands.Item(numeroSemana).Name.ToString & "-SEMA"
            If e.RowHandle = view.FocusedRowHandle And e.Column.Equals(view.FocusedColumn) Then
                e.Appearance.BackColor = view.Appearance.FocusedCell.BackColor
                e.Appearance.ForeColor = view.Appearance.FocusedCell.ForeColor
            Else
                If e.Column.Caption = "%" And e.Appearance.ForeColor <> view.Appearance.FocusedCell.ForeColor Then
                    If e.CellValue <= 50 Then
                        e.Appearance.ForeColor = Color.Green
                    ElseIf e.CellValue > 50 And e.CellValue < 100 Then
                        e.Appearance.ForeColor = Color.OrangeRed
                    ElseIf e.CellValue >= 100 Then
                        e.Appearance.ForeColor = Color.Red
                    End If
                End If
            End If
            If e.Appearance.ForeColor = view.Appearance.FocusedCell.ForeColor Then
                e.Appearance.BackColor = view.Appearance.FocusedCell.BackColor
            End If
            If grdVReporte.GetRowCellValue(e.RowHandle, semana) = 0 Then
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Italic Or FontStyle.Bold)
            End If
            If grdVReporte.GetRowCellValue(e.RowHandle, grdVReporte.Bands.Item(numeroSemana).Name.ToString & "-STSEMA") = 404 Then
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Italic Or FontStyle.Bold Or FontStyle.Underline)
            End If
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If grdVReporte.DataRowCount > 0 Then
                nombreReporte = "Colocacion_Semanal_OcupacionSemanal_"
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If grdVReporte.GroupCount > 0 Then
                            grdVReporte.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            exportOptions.TextExportMode = TextExportMode.Text
                            exportOptions.ExportType = ExportType.WYSIWYG
                            exportOptions.ApplyFormattingToEntireColumn = DevExpress.Utils.DefaultBoolean.True
                            exportOptions.AllowConditionalFormatting = DevExpress.Utils.DefaultBoolean.True
                            exportOptions.AllowCellMerge = DevExpress.Utils.DefaultBoolean.False
                            '  AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            For Each x As DevExpress.XtraGrid.Views.BandedGrid.GridBand In grdVReporte.Bands
                                If x.Name <> "Nave" And x.Name <> "TOTAL" Then
                                    Dim encabezado As String() = x.Name.Split(New Char() {"-"c})
                                    x.Caption = Replace(String.Join("-", encabezado(1), encabezado(2), "(" & encabezado(0) & ")"), "$", "")
                                End If
                            Next

                            grdVReporte.ExportToXlsx(.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                            For Each x As DevExpress.XtraGrid.Views.BandedGrid.GridBand In grdVReporte.Bands
                                If x.Name <> "Nave" And x.Name <> "TOTAL" Then
                                    Dim encabezado As String() = x.Name.Split(New Char() {"-"c})
                                    x.Caption = Replace(String.Join(vbCrLf, encabezado(1), encabezado(2), encabezado(0).ToString), "$", "-")
                                End If
                            Next
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + "/" + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub

    Private Sub AsignaciónDeColeccionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignaciónDeColeccionesToolStripMenuItem.Click
        Dim ventana As New Programacion_ColocacionSemanal_Configuracion_NaveArticuloForm
        ventana.MdiParent = Me.MdiParent
        ventana.Show()
    End Sub

    Private Sub FamiliasPorNaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasPorNaveToolStripMenuItem.Click
        Dim ventana As New Programacion_ColocacionSemanal_Configuracion_NaveFamiliaForm
        ventana.MdiParent = Me.MdiParent
        ventana.Show()
    End Sub

    Private Sub chkSemanaAtrasada_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemanaAtrasada.CheckedChanged
        If validarChecks() = False Then
            If chkSemanaAtrasada.Checked = False Then chkSemanaAtrasada.Checked = True
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 136
    End Sub

    Private Sub nudSemanaInicio_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaInicio.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            nudSemanaFinal.Value = nudSemanaInicio.Value
        End If
    End Sub

    Private Sub nudSemanaFinal_ValueChanged(sender As Object, e As EventArgs) Handles nudSemanaFinal.ValueChanged
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            nudSemanaInicio.Value = nudSemanaFinal.Value
        End If
    End Sub

    Private Sub nudAño_ValueChanged(sender As Object, e As EventArgs) Handles nudAño.ValueChanged
        If nudAño.Value > nudAñoFin.Value Then
            nudAñoFin.Value = nudAño.Value
        End If
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            If nudSemanaInicio.Value <= nudSemanaFinal.Maximum Then
                nudSemanaFinal.Value = nudSemanaInicio.Value
            Else
                nudSemanaFinal.Value = nudSemanaFinal.Maximum
            End If
        End If
        consultaUltimaSemanaDelAñoInicio(nudAño.Value)
    End Sub
    Private Sub nudAñoFin_ValueChanged(sender As Object, e As EventArgs) Handles nudAñoFin.ValueChanged
        If nudAño.Value > nudAñoFin.Value Then
            nudAño.Value = nudAñoFin.Value
        End If
        If (nudSemanaInicio.Value > nudSemanaFinal.Value And nudAño.Value = nudAñoFin.Value) Then
            If nudSemanaFinal.Value <= nudSemanaInicio.Maximum Then
                nudSemanaInicio.Value = nudSemanaFinal.Value
            Else
                nudSemanaInicio.Value = nudSemanaInicio.Maximum
            End If
        End If
        consultaUltimaSemanaDelAñoFin(nudAñoFin.Value)
    End Sub

    Private Sub EditarParesAtrasadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarParesAtrasadosToolStripMenuItem.Click
        If validarSemanasNavesSeleccionadas() Then
            Dim ventana As New Programacion_ColocacionSemanal_EditarCapacidadesForm
            ventana.tabla = obtenerSemanaNaveSeleccionada()
            ventana.año = año
            ventana.accion = 1 'Accion 1 cuando se edita "ATR"
            If ventana.tabla.Rows.Count > 0 Then
                ventana.StartPosition = FormStartPosition.CenterScreen
                If ventana.ShowDialog() = DialogResult.OK Then
                    consultaMapaOcupacion()
                End If
            Else
                objAdvertencia.mensaje = "Sin registros verifique que las semanas se encuentren abiertas."
                objAdvertencia.ShowDialog()
            End If
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        grdVReporte.Columns.Clear()
        grdVReporte.Bands.Clear()
        chkCapacidad.Checked = True
        chkEquivalencia.Checked = True
        chkProcOcupacion.Checked = True
        chkPrsColocados.Checked = True
        chkSemanaAtrasada.Checked = True
        lblFechaUltimaActualización.Text = "-"
        cmbNave.SelectedIndex = 0
        NumSemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        nudAño.Value = DatePart(DateInterval.Year, Now)
        nudSemanaInicio.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        nudSemanaFinal.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
        consultaUltimaSemanaDelAñoInicio(DatePart(DateInterval.Year, Now))
        consultaUltimaSemanaDelAñoFin(DatePart(DateInterval.Year, Now))
    End Sub

    Private Sub BitacoraErrores_Click(sender As Object, e As EventArgs) Handles BitacoraErrores.Click
        Dim ventana As New Programacion_ColocacionSemanal_DetallesOcupacionSemanal
        ListaSemanasSeleccionadas.Clear()
        ListaSemanasSeleccionadas.Add(nudSemanaInicio.Value.ToString)
        ListaSemanasSeleccionadas.Add(nudSemanaFinal.Value.ToString)
        ventana.listaSemanas = ListaSemanasSeleccionadas
        ventana.Año = nudAño.Value
        ventana.accion = 1
        ventana.MdiParent = Me.MdiParent
        ventana.Show()
    End Sub

    Private Sub BitacoraMovimientos_Click(sender As Object, e As EventArgs) Handles BitacoraMovimientos.Click
        Dim ventana As New Programacion_ColocacionSemanal_DetallesOcupacionSemanal
        ListaSemanasSeleccionadas.Clear()
        ListaSemanasSeleccionadas.Add(nudSemanaInicio.Value.ToString)
        ListaSemanasSeleccionadas.Add(nudSemanaFinal.Value.ToString)
        ventana.Año = nudAño.Value
        ventana.accion = 2
        ventana.MdiParent = Me.MdiParent
        ventana.Show()
    End Sub

    Private Sub btnBitacoras_Click(sender As Object, e As EventArgs) Handles btnBitacoras.Click
        'Dim punto As Point
        'punto.X = btnBitacoras.Location.X + btnBitacoras.Width + btnBitacoras.Location.X + cmsBitacoras.Width
        'punto.Y = btnBitacoras.Location.Y + btnBitacoras.Height
        'cmsBitacoras.Show(punto)
        cmsBitacoras.Show(MousePosition)
    End Sub

    Private Sub ModelosPorNaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModelosPorNaveToolStripMenuItem.Click
        Dim ventana As New Programacion_ColocacionSemanal_Configuracion_NaveModeloForm
        ventana.MdiParent = Me.MdiParent
        ventana.Show()
    End Sub

    Private Sub grdVReporte_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles grdVReporte.CustomSummaryCalculate

        Dim vOcupacion As String
        Dim vCapacidad As String
        Dim vNumDividir As Decimal = 0
        Dim vNumDividir2 As Decimal = 0
        Dim vTotal As Decimal = 0

        If e.Item.FieldName.Contains("PORC") Then
            vOcupacion = e.Item.FieldName.Replace("PORC", "EQ")
            vCapacidad = e.Item.FieldName.Replace("PORC", "CAP")
            vNumDividir = (From x In dtResultadoConsultaCopia.AsEnumerable() Select x.Field(Of Integer)(vOcupacion)).Sum()
            vNumDividir2 = (From x In dtResultadoConsultaCopia.AsEnumerable() Select x.Field(Of Integer)(vCapacidad)).Sum()

            If vNumDividir = 0 Or vNumDividir2 = 0 Then
                e.TotalValue = 0
            Else
                vTotal = ((vNumDividir / vNumDividir2) * 100)
                e.TotalValue = CInt(vTotal)

            End If
        End If
    End Sub

    Private Sub BitácoraDeRegistrosCanceladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BitácoraDeRegistrosCanceladosToolStripMenuItem.Click
        Dim bitacoraCancelados As New Programacion_ColocacionSemanal_BitacoraPartidasCanceladas
        bitacoraCancelados.MdiParent = Me.MdiParent
        bitacoraCancelados.WindowState = FormWindowState.Maximized
        bitacoraCancelados.Show()
    End Sub

    Private Sub btnAutorizarPlan_Click(sender As Object, e As EventArgs) Handles btnAutorizarPlan.Click
        If validarSemanasNavesSeleccionadas() Then
            Dim ventana As New Programacion_ColocacionSemanal_AutorizarPlanFabricacion_Form
            ventana.tabla = obtenerPlanesAAutorizar()
            ventana.año = año
            If ventana.tabla.Rows.Count > 0 Then
                If ventana.ShowDialog() = DialogResult.OK Then
                    consultaMapaOcupacion()
                End If
            Else
                objAdvertencia.mensaje = "Sin registros verifique que las semanas se encuentren con plan por autorizar y/o que la anterior se encuentre con plan autorizado."
                objAdvertencia.ShowDialog()
            End If
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Function obtenerPlanesAAutorizar()
        Dim tabla As New DataTable
        Try
            Dim columna As New DataColumn
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Boolean")
            columna.ColumnName = " "
            columna.Caption = " "
            columna.ReadOnly = False
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los Id's de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "NaveId"
            columna.Caption = "NaveId"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los nombres de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.String")
            columna.ColumnName = "Nave"
            columna.Caption = "Nave"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los numeros de las semanas seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Semana"
            columna.Caption = "Semana"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para el año
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Año"
            columna.Caption = "Año"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            For Each x As Integer In grdVReporte.GetSelectedRows
                Dim listaSemanas As New List(Of semanaCapacidad)
                Dim naveId As Integer = grdVReporte.GetRowCellValue(x, "IdNave")
                Dim nombreNave As String = grdVReporte.GetRowCellValue(x, "Nave")
                For Each y As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
                    If y.RowHandle = x Then
                        Dim obj As New semanaCapacidad
                        obj.semana = obtenerSemanaCerrar(y.Column.VisibleIndex)
                        obj.año_semana = obtenerAño(y.Column.VisibleIndex)
                        obj.capacidad = 0
                        obj.atr = 0
                        listaSemanas.Add(obj)
                    End If
                Next

                For Each y As semanaCapacidad In listaSemanas.AsEnumerable.Distinct
                    Dim fila As DataRow
                    fila = tabla.NewRow
                    fila.Item(0) = False
                    fila.Item(1) = naveId
                    fila.Item(2) = nombreNave
                    fila.Item(3) = y.semana
                    fila.Item(4) = y.año_semana
                    tabla.Rows.Add(fila)
                Next
            Next

        Catch ex As Exception

        End Try
        Return tabla
    End Function


    Private Sub btnAbrirPlan_Click(sender As Object, e As EventArgs) Handles btnAbrirPlan.Click
        If validarSemanasNavesSeleccionadas() Then
            Dim ventana As New Programacion_ColocacionSemanal_ReAbrirPlan_Form
            ventana.tabla = obtenerPlanesAReabrir()
            ventana.año = año
            If ventana.tabla.Rows.Count > 0 Then
                If ventana.ShowDialog() = DialogResult.OK Then
                    consultaMapaOcupacion()
                End If
            Else
                objAdvertencia.mensaje = "Sin registros verifique que las semanas se encuentren con plan por autorizar y/o que la anterior se encuentre con plan autorizado."
                objAdvertencia.ShowDialog()
            End If
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Function obtenerPlanesAReabrir()
        Dim tabla As New DataTable
        Try
            Dim columna As New DataColumn
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Boolean")
            columna.ColumnName = " "
            columna.Caption = " "
            columna.ReadOnly = False
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los Id's de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "NaveId"
            columna.Caption = "NaveId"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los nombres de las naves seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.String")
            columna.ColumnName = "Nave"
            columna.Caption = "Nave"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)
            'Se crea la columna para los numeros de las semanas seleccionadas
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Semana"
            columna.Caption = "Semana"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            'Se crea la columna para el año
            columna = New DataColumn
            columna.DataType = System.Type.GetType("System.Int32")
            columna.ColumnName = "Año"
            columna.Caption = "Año"
            columna.ReadOnly = True
            columna.Unique = False
            tabla.Columns.Add(columna)

            For Each x As Integer In grdVReporte.GetSelectedRows
                Dim listaSemanas As New List(Of semanaCapacidad)
                Dim naveId As Integer = grdVReporte.GetRowCellValue(x, "IdNave")
                Dim nombreNave As String = grdVReporte.GetRowCellValue(x, "Nave")
                For Each y As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
                    If y.RowHandle = x Then
                        Dim semana As String
                        Dim numeroSemana As Integer
                        numeroSemana = Int((y.Column.VisibleIndex - 1) / Int(Int(grdVReporte.VisibleColumns.Count - 1) / Int(grdVReporte.Bands.Count - 1))) + 1
                        semana = grdVReporte.Bands.Item(numeroSemana).Name.ToString & "-STSEMA"
                        If grdVReporte.GetRowCellValue(x, (semana).ToString()) = "404" Then
                            Dim obj As New semanaCapacidad
                            obj.semana = obtenerSemanaCerrar(y.Column.VisibleIndex)
                            obj.año_semana = obtenerAño(y.Column.VisibleIndex)
                            obj.capacidad = 0
                            obj.atr = 0
                            listaSemanas.Add(obj)
                        End If
                    End If
                Next

                For Each y As semanaCapacidad In listaSemanas.AsEnumerable.Distinct
                    Dim fila As DataRow
                    fila = tabla.NewRow
                    fila.Item(0) = False
                    fila.Item(1) = naveId
                    fila.Item(2) = nombreNave
                    fila.Item(3) = y.semana
                    fila.Item(4) = y.año_semana
                    tabla.Rows.Add(fila)
                Next
            Next

        Catch ex As Exception

        End Try
        Return tabla
    End Function

    Private Sub PlanDeFabricaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanDeFabricaciónToolStripMenuItem.Click
        Dim ventana As New Programacion_PlanFabricacion
        ventana.MdiParent = Me.MdiParent
        ventana.Show()
    End Sub

    Private Sub btnFiltros_Click(sender As Object, e As EventArgs) Handles btnFiltros.Click
        MenuFiltros.Show(MousePosition)
    End Sub

    Private Sub bntVerPlanFabricacion_Click(sender As Object, e As EventArgs) Handles bntVerPlanFabricacion.Click

        If validarSemanasNavesSeleccionadas() Then

            Dim objBU As New PlanFabricacionBU
            Dim dtObtienePlanFabricacion As New DataTable("dtPlanFabricacion")
            Dim objBUReporte As New ReportesBU
            Dim EntidadReporte As New Entidades.Reportes
            Dim MasterPlanFabricacion As New DataSet("MasterPlanFabricacion")

            Dim TieneSAY As Boolean = False
            Dim NaveID As String = ""
            Dim Semana As String = ""
            Dim Nave As String = ""
            Dim Usuario As String = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            Dim reporte As New StiReport()
            Dim Año As Integer = 0
            Dim Contador As Integer = 0

            For Each x As Integer In grdVReporte.GetSelectedRows

                Contador += 1

                NaveID = grdVReporte.GetRowCellValue(x, "IdNave")
                Nave = grdVReporte.GetRowCellValue(x, "Nave")

                For Each y As DevExpress.XtraGrid.Views.Base.GridCell In grdVReporte.GetSelectedCells
                    If y.RowHandle = x Then

                        Semana = obtenerSemanaCerrar(y.Column.VisibleIndex)
                        Año = obtenerAño(y.Column.VisibleIndex)

                    End If
                Next
            Next

            If Contador > 1 Then
                show_message("Advertencia", "Seleccione una sola nave para realizar esta acción")
                Exit Sub
            End If

            TieneSAY = objBU.LaNaveTieneSAY(NaveID)

            dtObtienePlanFabricacion = objBU.ObtienePlanFabricacionReporte(NaveID, Semana, Str(Año))

            If dtObtienePlanFabricacion.Rows.Count > 0 Then

                dtObtienePlanFabricacion.Columns(10).ColumnName = 1
                dtObtienePlanFabricacion.Columns(11).ColumnName = 2
                dtObtienePlanFabricacion.Columns(12).ColumnName = 3
                dtObtienePlanFabricacion.Columns(13).ColumnName = 4


                MasterPlanFabricacion.Tables.Add(dtObtienePlanFabricacion)

                EntidadReporte = objBUReporte.LeerReporteporClave("RPT_PLANFABRICACION")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                                            EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)


                reporte.Load(archivo)
                reporte.Compile()
                reporte("Semana1") = Semana
                reporte("Semana2") = Str(Semana + 1)
                reporte("Semana3") = Str(Semana + 2)
                reporte("Semana4") = Str(Semana + 3)
                reporte("Nave") = Nave
                reporte("Usuario") = Usuario
                reporte("Fecha") = dtObtienePlanFabricacion.Rows(0).Item("Fecha")

                reporte.Dictionary.Clear()
                reporte.RegData(MasterPlanFabricacion)
                reporte.Dictionary.Synchronize()

                If TieneSAY = False Then
                    Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
                    Dim rutaPlanFabricacion As String = String.Empty

                    rutaPlanFabricacion = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\PlanFabricacion\NavesSinSAY"

                    If Not System.IO.Directory.Exists(rutaPlanFabricacion) Then
                        Directory.CreateDirectory(rutaPlanFabricacion)
                    End If

                    reporte.Render()
                    formatoExcel.ExportObjectFormatting = True
                    StiOptions.Export.Excel.ShowGridLines = False

                    reporte.ExportDocument(StiExportFormat.Excel, rutaPlanFabricacion + "\Plan Fabricacion Semana " + Semana + "-" + Año.ToString + " Nave " + Nave.ToUpperInvariant + ".xls")

                End If

                reporte.Show(True)

            Else
                show_message("Advertencia", "No se encontraron datos para generar Plan de Fabricación.")
                Exit Sub
            End If
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una columna de semana para realizar esta acción."
            objAdvertencia.ShowDialog()
        End If

    End Sub

    Private Sub FiltrosMapaOcupaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltrosMapaOcupaciónToolStripMenuItem.Click
        Dim PantallaFiltrosDetalles As New Programacion_FiltrosMapaOcupacion
        PantallaFiltrosDetalles.Show()
    End Sub

    Private Sub ParesColocadosPorTallaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ParesColocadosPorTallaToolStripMenuItem.Click
        Dim ParesColocadosporTalla As New Programacion_ColocacionSemanal_ParesColocadosPorTalla
        ParesColocadosporTalla.Show()
    End Sub

    Private Sub BitacoraPDesprogramados_Click(sender As Object, e As EventArgs) Handles BitacoraPDesprogramados.Click
        Dim bitacoraDesprogramadas As New Programacion_ColocacionSemanal_BitacoraPedidosDesprogramados With {
            .MdiParent = Me.MdiParent,
            .WindowState = FormWindowState.Maximized,
            .ventanaPrincipal = Me
        }
        bitacoraDesprogramadas.MostrarPedidosDesprogramados()
        If bitacoraDesprogramadas.dtResultadoReporte.Rows.Count > 0 Then
            bitacoraDesprogramadas.Show()
        End If
    End Sub


End Class