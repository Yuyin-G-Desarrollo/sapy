Imports Tools
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReportesProduccionMaquilasForm
    Dim valida As Boolean = False
    'Dim Ruta As String = "C:\Naves\"
    Dim Ruta As String = ""

#Region "Inital Methods"
    Private Sub llenarTabla()
        'Dim listaTabla As New List(Of formatoTabla)
        Dim tabla As New DataTable
        Dim column As DataColumn
        Dim row As DataRow
        'Se crea la primera columna de nuestra tabla
        column = New DataColumn
        column.DataType = System.Type.GetType("System.Boolean")
        column.ColumnName = " "
        'Se agrega la columna a nuestra tabla
        tabla.Columns.Add(column)

        'Se crea la segunda columna de nuestra tabla
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "Reporte"
        'Se agrega la columna a nuestra tabla
        tabla.Columns.Add(column)

        Dim reportes As String = "Orden de Producción,Orden de Producción F/S,Desglosado de Suela,Reporte de Caja,Reporte de Suela,Concentrado de Suela P/Proveedor,Orden de Pedido Desglosado P/Corte,Concentrado de Planta P/Proveedor,Reporte de Planta,Reporte para herrajes,Reporte de casco y contrafuerte,Concentrado de casco,Concentrado de contrafuerte,Desglosado de casco,Desglosado de contrafuerte,Desglosado de planta"
        Dim reportesSplit As String() = CStr(reportes).Split(New Char() {","c})
        For Each reporte In reportesSplit
            row = tabla.NewRow
            If (reporte <> "Orden de Producción" And reporte <> "Orden de Producción F/S" And reporte <> "Desglosado de Suela" And reporte <> "Reporte de Caja" And
                reporte <> "Reporte de Suela" And reporte <> "Concentrado de Suela P/Proveedor" And reporte <> "Reporte de Planta" And
                reporte <> "Orden de Pedido Desglosado P/Corte" And reporte <> "Desglosado de planta") Then
                row.Item(0) = False
            Else
                row.Item(0) = True
            End If
            row.Item(1) = reporte
            tabla.Rows.Add(row)
        Next
        grdReporte.DataSource = tabla

        'Diseño Grid
        vwReporte.OptionsView.EnableAppearanceEvenRow = True
        vwReporte.OptionsView.ColumnAutoWidth = True
        vwReporte.OptionsView.EnableAppearanceOddRow = True
        vwReporte.OptionsSelection.EnableAppearanceFocusedCell = False
        vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        vwReporte.Appearance.SelectedRow.Options.UseBackColor = True
        vwReporte.Appearance.SelectedRow.BackColor = Color.FromArgb(0, 120, 215)
        vwReporte.Appearance.EvenRow.BackColor = Color.White
        vwReporte.Appearance.OddRow.BackColor = SystemColors.ActiveCaption
        vwReporte.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        vwReporte.Appearance.FocusedRow.ForeColor = Color.White
        vwReporte.Columns.ColumnByFieldName(" ").OptionsFilter.AllowAutoFilter = False
        vwReporte.Columns.ColumnByFieldName("Reporte").OptionsColumn.AllowEdit = False
        vwReporte.BestFitColumns()
    End Sub
    Private Sub imprimirReporte(ByVal nave As Integer, ByVal fecha As Date, ByVal reporte As String)
        Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\NavesReportesPDF"
        Select Case reporte
            Case "Orden de Producción"
                ImprimirOrdenDeProduccion(fecha, nave)
            Case "Orden de Producción F/S"
                ImprimirOrdenDeProduccionFacturadoRemisionado(fecha, nave)
            Case "Desglosado de Suela"
                ImprimirDesglosadoSuela(fecha, nave)
            Case "Reporte de Caja"
                ImprimirReporteCaja(fecha, nave)
            Case "Reporte de Suela"
                ImprimirReporteSuela(fecha, nave)
            Case "Concentrado de Suela P/Proveedor"
                ImprimirConcentradoSuelaPorProveedor(fecha, nave)
            Case "Orden de Pedido Desglosado P/Corte"
                ImprimirOrdenPedidoDesglosadoCorte(fecha, nave)
            Case "Concentrado de Planta P/Proveedor"
                ImprimirConcentradoPlantaPorProveedor(fecha, nave)
            Case "Reporte de Planta"
                ImprimirReportePlanta(fecha, nave)
                ''Nuevos
            Case "Reporte para herrajes"
                ImprimirReporteHerrajes(fecha, nave)
            Case "Reporte de casco y contrafuerte"
                ImprimirReporteCascoContrafuerte(fecha, nave)
            Case "Concentrado de casco"
                ImpimirConcentradoCascoPorProveedor(fecha, nave)
            Case "Concentrado de contrafuerte"
                ImprimirConcentradoContrafuerte(fecha, nave)
            Case "Desglosado de casco"
                ImprimirDesglosadoCasco(fecha, nave)
            Case "Desglosado de contrafuerte"
                ImprimirDesglosadoContrafuerte(fecha, nave)
            Case "Desglosado de planta"
                ImprimirDesglosadoPlanta(fecha, nave)
        End Select
    End Sub
    Private Sub reportesConCheck()
        'Utilizado anteiormente
        Dim nave As Integer = 0
        Dim fecha As Date = Nothing
        If chekOrdenProduccion.Checked = False And chekDesglosadoSuela.Checked = False And
                    chekReporteSuela.Checked = False And chekReporteCaja.Checked = False And
                    chekConcentradoSuelaporProveedor.Checked = False And chekOrdenPedidoDesglosadoCorte.Checked = False And
                    chekConcentradoPlantaporProveedor.Checked = False And chekReportedePlanta.Checked = False Then

            show_message("Advertencia", "Seleccione los reportes que se quieren imprimir")
        Else
            If chekConcentradoPlantaporProveedor.Checked = True Then
                ImprimirConcentradoPlantaPorProveedor(fecha, nave)
            End If
            If chekOrdenProduccion.Checked = True Then
                ImprimirOrdenDeProduccion(fecha, nave)
            End If
            If chekDesglosadoSuela.Checked = True Then
                ImprimirDesglosadoSuela(fecha, nave)
            End If
            If chekReporteSuela.Checked = True Then
                ImprimirReporteSuela(fecha, nave)
            End If
            If chekReporteCaja.Checked = True Then
                ImprimirReporteCaja(fecha, nave)
            End If
            If chekConcentradoSuelaporProveedor.Checked = True Then
                ImprimirConcentradoSuelaPorProveedor(fecha, nave)
            End If
            If chekOrdenPedidoDesglosadoCorte.Checked = True Then
                ImprimirOrdenPedidoDesglosadoCorte(fecha, nave)
            End If
            If chekConcentradoPlantaporProveedor.Checked = True Then
                ImprimirConcentradoPlantaPorProveedor(fecha, nave)
            End If
            If chekReportedePlanta.Checked = True Then
                ImprimirReportePlanta(fecha, nave)
            End If
            If valida Then
                show_message("Exito", "Se han exportado los reportes correctamente")
            End If
            valida = False
        End If
    End Sub
#End Region
    Private Sub ReportesProduccionMaquilasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarNaves()
        llenarTabla()
        dtpFecha.Value = Now.ToShortDateString
        chekOrdenProduccion.Checked = True
        chekDesglosadoSuela.Checked = True
        chekReporteSuela.Checked = True
        chekReporteCaja.Checked = True
        chekConcentradoSuelaporProveedor.Checked = True
        'chekOrdenPedidoDesglosadoCorte.Checked = True
        'chekConcentradoPlantaporProveedor.Checked = True
        chekReportedePlanta.Checked = True
    End Sub

    Public Sub listarNaves()
        cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim obj As New ReportesBU
        Dim nave As Integer
        Dim fecha As Date

        Try
            Cursor = Cursors.WaitCursor
            If cmbNave.SelectedIndex > 0 Then
                '' Dar formato a la fecha
                Dim dateValue As Date = dtpFecha.Value.ToShortDateString
                Dim DAY = dateValue.DayOfWeek()
                Dim NUMEROMES = dateValue.Month()
                Dim dia As String = ""
                Dim mes As String = ""
                Dim fechaDias As String = ""
                Dim Logo As String = ""
                Logo = Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
                'Logo = Tools.Controles.ObtenerLogoNave(3)

                Select Case DAY
                    Case 1
                        dia = "Lunes"
                    Case 2
                        dia = "Martes"
                    Case 3
                        dia = "Miércoles"
                    Case 4
                        dia = "Jueves"
                    Case 5
                        dia = "Viernes"
                    Case 6
                        dia = "Sábado"
                End Select

                Select Case NUMEROMES
                    Case 1
                        mes = "Enero"
                    Case 2
                        mes = "Febrero"
                    Case 3
                        mes = "Marzo"
                    Case 4
                        mes = "Abril"
                    Case 5
                        mes = "Mayo"
                    Case 6
                        mes = "Junio"
                    Case 7
                        mes = "Julio"
                    Case 8
                        mes = "Agosto"
                    Case 9
                        mes = "Septiembre"
                    Case 10
                        mes = "Octubre"
                    Case 11
                        mes = "Noviembre"
                    Case 12
                        mes = "Diciembre"
                End Select

                fechaDias = dia & ",  " & dateValue.ToString("dd") & "  " & mes & " de " & dateValue.ToString("yyyy")

                nave = cmbNave.SelectedValue
                fecha = dtpFecha.Value.ToShortDateString

                Dim validarSeleccionados As Boolean = False
                For i As Integer = 0 To vwReporte.RowCount Step 1
                    Dim seleccionado As Boolean = vwReporte.GetRowCellValue(i, " ")
                    If seleccionado Then
                        validarSeleccionados = True
                        imprimirReporte(nave, fecha, vwReporte.GetRowCellValue(i, "Reporte"))
                    End If
                Next
                If validarSeleccionados Then
                    show_message("Exito", "Se han exportado los reportes correctamente")
                Else
                    show_message("Advertencia", "Seleccione los reportes que se quieren imprimir")
                End If
            Else
                show_message("Advertencia", "Seleccione la nave")
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
        Cursor = Cursors.Default

    End Sub
#Region "Impresion de reportes"
    Public Sub ImprimirOrdenDeProduccion(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteOrdenesDeProduccionfake(fecha, nave, clasificacion)
        'tabla1 = obj.ReporteOrdenesDeProduccion(fecha, nave, clasificacion)

        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el reporte Orden de Producción.")
        Else

            For value = 0 To tabla1.Rows.Count - 1
                Dim x = tabla1.Rows(value).Item("Suela").ToString
                tabla1.Rows(value).Item("Suela") = x.Trim.Replace("SUELA ", "")
            Next
            'Concatenar Cortador1 con cortador2
            tabla1.TableName = ""
            '********************************Creación de reporte
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    ''**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    'Dim reporteExportar As MemoryStream = New MemoryStream()

                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PRODUCCION")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(tabla1)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + "Orden de Produccion.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Orden de Produccion " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True

                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
                show_message("Error", ex.Message.ToString())
            End Try
        End If
    End Sub

    Public Sub ImprimirOrdenDeProduccionFacturadoRemisionado(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable

        tabla1 = obj.ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(fecha, nave, "S")
        tabla2 = obj.ReporteOrdenesDeProduccion_FacturadoYRemisionadoPorTipo(fecha, nave, "P")

        If tabla1.Rows.Count = 0 And tabla2.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            'Concatenar Cortador1 con cortador2
            tabla1.TableName = "tablaOrdenesdeProduccion"
            tabla2.TableName = "tablaOrdenesdeProduccionPreventa"
            '********************************Creación de reporte
            Try
                If tabla1.Rows.Count = 0 And tabla2.Rows.Count = 0 Then
                Else
                    ''**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PRODUCCION_FACTURAREMISION")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(tabla1)
                    reporte.RegData(tabla2)
                    reporte.Render()


                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Orden de Produccion F_S " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")



                    'reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirDesglosadoSuela(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosada(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el reporte Desglosado de Suela.")
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("C5")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("C5") = tabla1.Rows(value).Item("C5")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("RELACION_DESGLOSADA_FORMATO4")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "SUELA"
                    reporte("tituloC5") = "COLECCIÓN"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Desglosado de Suela.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Desglosado de Suela " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True
                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirReporteCaja(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de caja
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CAJA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteMaterialesFormato2Planta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el Reporte para Caja.")
        Else
            Try
                '**Llenado del reporte
                'Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_FORMATO2CAJA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("titulo") = "REPORTE PARA CAJA"
                reporte("tituloCelda") = "COLECCIÓN"
                reporte.RegData(tabla1)
                reporte.Render()

                Ruta = Ruta + "\" + cmbNave.Text
                If Not System.IO.Directory.Exists(Ruta) Then
                    Directory.CreateDirectory(Ruta)
                End If
                'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Reporte de Caja.pdf")
                reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Reporte de Caja " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                valida = True
                'reporte.Show()
                '*********************
                'Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirReporteSuela(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        ' listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Obtener los id de los componentes Suela1, Suela2, etc
        ''tablaComponentes = obj.ObtenerComponentes("SUELA", "")
        'For value = 0 To tablaComponentes.Rows.Count - 1
        'listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        ' Next
        tabla1 = obj.ConsultaReporteSuelas1N(fecha, nave)
        tabla1.TableName = "tablaOrdenesdeProduccion"
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el Reporte de Suela.")
        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_SUELAS123")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA SUELA"
                    reporte("TituloCelda") = "SUELA"
                    reporte.RegData(tabla1)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Reporte de Suela.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Reporte de Suela " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True
                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoSuelaPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)

        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el reporte Concentrado de Suela por Proveedor.")
        Else

            Dim tablaRelacionDesglosadaDeSuela = New DataTable
            tablaRelacionDesglosadaDeSuela.Clear()
            tablaRelacionDesglosadaDeSuela.Columns.Add("NO")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PARES")
            tablaRelacionDesglosadaDeSuela.Columns.Add("LOTE")
            tablaRelacionDesglosadaDeSuela.Columns.Add("MATERIAL")
            tablaRelacionDesglosadaDeSuela.Columns.Add("COLECCIÓN")
            tablaRelacionDesglosadaDeSuela.Columns.Add("CORRIDA")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PROVEEDOR")

            tablaRelacionDesglosadaDeSuela.Columns.Add("tl1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl20")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t20")


            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = tablaRelacionDesglosadaDeSuela.NewRow()
                row("NO") = tabla1.Rows(value).Item("No")
                row("PARES") = tabla1.Rows(value).Item("Pares")
                row("LOTE") = tabla1.Rows(value).Item("Lotes")
                row("MATERIAL") = tabla1.Rows(value).Item("Material")
                row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
                row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
                row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                tablaRelacionDesglosadaDeSuela.Rows.Add(row)
            Next

            Try
                If tablaRelacionDesglosadaDeSuela.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_SUELA_POR_PROVEEDOR2")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "SUELA"
                    reporte.RegData(tablaRelacionDesglosadaDeSuela)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Suela por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Concentrado de Suela por Proveedor " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True
                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirOrdenPedidoDesglosadoCorte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        'Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        listaComponentes.Clear()
        tabla1 = obj.ConsultaOrdenDePedidoDesglosadoPAraCorte1(fecha, nave)
        tabla2 = obj.ConsultaOrdenDePedidoDesglosadoPAraCorte2(fecha, nave)

        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el reporte Orden de Pedido Desglosado para Corte.")
        Else

            Try
                For value = 0 To tabla1.Rows.Count - 1
                    Dim contador = 1
                    For value2 = 29 To 47
                        Dim aux = tabla2.Rows(value).Item(contador)
                        tabla1.Rows(value).Item(value2) = aux
                        contador = contador + 1
                    Next
                Next
                For value = 0 To tabla1.Rows.Count - 1
                    For value2 = 7 To 26
                        If tabla1.Rows(value).Item(value2).ToString = "" And tabla1.Rows(value).Item(value2 + 20).ToString = "0" Then
                            tabla1.Rows(value).Item(value2 + 20) = ""
                        End If
                    Next
                Next
            Catch ex As Exception
            End Try
            tabla1.TableName = ""
            '********************************Creación de reporte
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("ORDEN_DE_PEDIDO_DESGLOSADO_PARA_CORTE")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CASCO Y CONTRAFUERTE"
                    reporte("tituloC5") = "MATERIAL 2"
                    reporte("Proveedor") = "COTEXCA"
                    reporte.RegData(tabla1)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Orden de Pedido Desglosado para Corte.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Orden de Pedido Desglosado para Corte " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True
                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub ImprimirConcentradoPlantaPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        ' Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ConcentradoFormato5(fecha, nave, clasificacion)
        tabla1.TableName = "tablaConcentradoPlanta"

        If tabla1.Rows.Count = 0 Then
            show_message("Advertencia", "No hay información para generar el reporte Concentrado de Planta por Proveedor.")
        Else

            Dim tablaRelacionDesglosadaDeSuela = New DataTable
            tablaRelacionDesglosadaDeSuela.Clear()
            tablaRelacionDesglosadaDeSuela.Columns.Add("NO")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PARES")
            tablaRelacionDesglosadaDeSuela.Columns.Add("LOTE")
            tablaRelacionDesglosadaDeSuela.Columns.Add("MATERIAL")
            tablaRelacionDesglosadaDeSuela.Columns.Add("COLECCIÓN")
            tablaRelacionDesglosadaDeSuela.Columns.Add("CORRIDA")
            tablaRelacionDesglosadaDeSuela.Columns.Add("PROVEEDOR")


            tablaRelacionDesglosadaDeSuela.Columns.Add("tl1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("tl20")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t1")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t2")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t3")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t4")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t5")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t6")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t7")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t8")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t9")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t10")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t11")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t12")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t13")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t14")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t15")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t16")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t17")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t18")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t19")
            tablaRelacionDesglosadaDeSuela.Columns.Add("t20")


            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = tablaRelacionDesglosadaDeSuela.NewRow()
                row("NO") = tabla1.Rows(value).Item("No")
                row("PARES") = tabla1.Rows(value).Item("Pares")
                row("LOTE") = tabla1.Rows(value).Item("Lotes")
                row("MATERIAL") = tabla1.Rows(value).Item("Material")
                row("COLECCIÓN") = tabla1.Rows(value).Item("Coleccion")
                row("CORRIDA") = tabla1.Rows(value).Item("Corrida")
                row("PROVEEDOR") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 7 To 26
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                tablaRelacionDesglosadaDeSuela.Rows.Add(row)
            Next

            Try
                If tablaRelacionDesglosadaDeSuela.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_PLANTA_POR_PROVEEDOR2")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "PLANTA"
                    reporte.RegData(tablaRelacionDesglosadaDeSuela)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Concentrado de Planta por Proveedor " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True
                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub


    Public Sub ImprimirReportePlanta(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable


        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteMaterialesFormatoPlanta(fecha, nave, clasificacion)
        tabla1.TableName = ""
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte de Planta.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    'Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_PLANTA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA PLANTA"
                    reporte("tituloCelda") = "HORMA"
                    reporte.RegData(tabla1)

                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Preporte de Planta.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Preporte de Planta " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    valida = True
                    'reporte.Show()
                    '*********************
                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirReporteHerrajes(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de herraje
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("HERRAJE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Obtener los id de los componentes Herraje1, Herraje2, etc
        tablaComponentes = obj.ObtenerComponentes("HERRAJE", "")

        For value = 0 To tablaComponentes.Rows.Count - 1
            listaComponentes.Add(tablaComponentes.Rows(value).Item(0))
        Next
        tabla1 = obj.ConsultaReporteHerrajesImpresion(fecha, nave, listaComponentes)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Dim listaLotes As New List(Of Integer)
            Dim Tabla = New DataTable
            Tabla.Clear()
            Tabla.Columns.Add("No")
            Tabla.Columns.Add("Pares")
            Tabla.Columns.Add("Lote")
            Tabla.Columns.Add("Modelo")
            Tabla.Columns.Add("ModeloSAY")
            Tabla.Columns.Add("Corrida")
            Tabla.Columns.Add("Coleccion")
            Tabla.Columns.Add("Proveedor")
            Tabla.Columns.Add("IdConsumo1")
            Tabla.Columns.Add("Herraje1")
            Tabla.Columns.Add("CantidadHerraje1")
            Tabla.Columns.Add("IdConsumo2")
            Tabla.Columns.Add("Herraje2")
            Tabla.Columns.Add("CantidadHerraje2")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = Tabla.NewRow()
                Dim contador = 0
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Modelo") = tabla1.Rows(value).Item("Modelo")
                row("ModeloSAY") = tabla1.Rows(value).Item("ModeloSAY")
                'row("Material") = tabla1.Rows(value).Item("Material")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                row("Coleccion") = tabla1.Rows(value).Item("Coleccion")
                row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                row("IdConsumo1") = tabla1.Rows(value).Item("IdConsumo1")
                row("Herraje1") = tabla1.Rows(value).Item("Herraje1")
                row("CantidadHerraje1") = tabla1.Rows(value).Item("CantidadHerraje1")
                row("IdConsumo2") = tabla1.Rows(value).Item("IdConsumo2")
                row("Herraje2") = tabla1.Rows(value).Item("Herraje2")
                row("CantidadHerraje2") = tabla1.Rows(value).Item("CantidadHerraje2")
                'If listaLotes.Count > 0 Then
                '    For valor = 0 To listaLotes.Count - 1
                '        If tabla1.Rows(value).Item("Lote") = listaLotes.Item(valor) Then
                '            contador = contador + 1
                '        End If
                '        If contador > 0 Then
                '            row("Herraje") = "HERRAJE 2"
                '        Else
                '            row("Herraje") = "HERRAJE 1"
                '        End If
                '    Next
                'Else
                '    row("Herraje") = "HERRAJE 1"
                'End If
                'For value2 = 9 To 22
                '    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                '        row(value2) = tabla1.Rows(value).Item(value2)
                '    End If
                'Next
                listaLotes.Add(tabla1.Rows(value).Item("Lote"))
                Tabla.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If Tabla.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_MATERIAL_HERRAJES_NUEVO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(Tabla)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Reporte para herrajes " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    'reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirReporteCascoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
        tabla1 = obj.ConsultaReporteDesglosado(fecha, nave, clasificacion, clasificacion2)
        'tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        'tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        'tabla2 = obj.ConsultaContrafuerte1(fecha, nave, clasificacion)
        'tablaB = obj.ConsultaContrafuerte2(fecha, nave, clasificacion)
        tabla1.TableName = "tablaOrdenesdeProduccion"
        '********************************Creación de reporte
        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_PARA_CASCO_Y_CONTRAFUERTE2")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                reporte("log") = GetRutaLogoPorNave(nave)
                reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.RegData(tabla1)
                reporte.Render()

                Ruta = Ruta + "\" + cmbNave.Text
                If Not System.IO.Directory.Exists(Ruta) Then
                    Directory.CreateDirectory(Ruta)
                End If
                'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Reporte de casco y contrafuerte " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                ' reporte.Show()
                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImpimirConcentradoCascoPorProveedor(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        ' Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Casco")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                ' Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lotes").ToString
                rowc("Casco") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 5 To 20

                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "14"
                            Dim o = tablaA.Rows(value).Item(value)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t1 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "15"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "16"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "17"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t2 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "18"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "19"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t3 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "20"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "21"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t4 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "22"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "23"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "24"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t5 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "25"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "26"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "27"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t6 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "28"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "29"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "30"
                            Dim o = tablaA.Rows(value).Item(value2)
                            If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                t8 += tablaA.Rows(value).Item(cont)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                    End Select
                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next

            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_CASCO_POR_PROVEEDOR")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Concentrado de casco " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    'reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirConcentradoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        tabla1 = obj.ConsultaCasco1(fecha, nave, clasificacion)
        tablaA = obj.ConsultaCasco2(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Contrafuerte")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                'Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lotes").ToString
                rowc("Contrafuerte") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 0 To 19
                    If value2 < 5 Then
                    Else
                        Dim x = tabla1.Rows(value).Item(value2).ToString
                        Dim y = x.Trim.Replace("½", "")
                        Select Case y
                            Case "12"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t1 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t1") = t1
                            Case "13"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t1 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t1") = t1
                            Case "14"
                                Dim o = tablaA.Rows(value).Item(value)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t1 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t1") = t1
                            Case "15"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t2 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t2") = t2
                            Case "16"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t2 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t2") = t2
                            Case "17"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t2 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t2") = t2
                            Case "18"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t3 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t3") = t3
                            Case "19"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t3 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t3") = t3
                            Case "20"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t4 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t4") = t4
                            Case "21"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t4 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t4") = t4
                            Case "22"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t5 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t5") = t5
                            Case "23"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t5 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t5") = t5
                            Case "24"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t5 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t5") = t5
                            Case "25"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t6 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t6") = t6
                            Case "26"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t6 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t6") = t6
                            Case "27"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t6 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t6") = t6
                            Case "28"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t8 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t8") = t8
                            Case "29"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t8 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t8") = t8
                            Case "30"
                                Dim o = tablaA.Rows(value).Item(value2)
                                If IsDBNull(tablaA.Rows(value).Item(cont)) = False Then
                                    t8 += tablaA.Rows(value).Item(cont)
                                End If
                                cont = cont + 1
                                rowc("t8") = t8
                        End Select
                    End If

                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next

            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_DE_CONTRAFUERTE_POR_PROVEEDOR")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Concentrado de contrafuerte " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    ' reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirDesglosadoCasco(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        'tablaClasificacion2 = obj.ObtenerClasificacion("CONTRAFUERTE")
        'clasificacion2 = tablaClasificacion2.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            'Dim TablaReporteConcentrado = New DataTable
            'TablaReporteConcentrado.Clear()
            'TablaReporteConcentrado.Columns.Add("No")
            'TablaReporteConcentrado.Columns.Add("Pares")
            'TablaReporteConcentrado.Columns.Add("Lote")
            'TablaReporteConcentrado.Columns.Add("Material")
            'TablaReporteConcentrado.Columns.Add("C5")
            'TablaReporteConcentrado.Columns.Add("Corrida")
            'TablaReporteConcentrado.Columns.Add("Proveedor")
            'TablaReporteConcentrado.Columns.Add("tl1")
            'TablaReporteConcentrado.Columns.Add("tl2")
            'TablaReporteConcentrado.Columns.Add("tl3")
            'TablaReporteConcentrado.Columns.Add("tl4")
            'TablaReporteConcentrado.Columns.Add("tl5")
            'TablaReporteConcentrado.Columns.Add("tl6")
            'TablaReporteConcentrado.Columns.Add("tl7")
            'TablaReporteConcentrado.Columns.Add("tl8")
            'TablaReporteConcentrado.Columns.Add("tl9")
            'TablaReporteConcentrado.Columns.Add("tl10")
            'TablaReporteConcentrado.Columns.Add("tl11")
            'TablaReporteConcentrado.Columns.Add("tl12")
            'TablaReporteConcentrado.Columns.Add("tl13")
            'TablaReporteConcentrado.Columns.Add("tl14")
            'TablaReporteConcentrado.Columns.Add("tl15")
            'TablaReporteConcentrado.Columns.Add("tl16")
            'TablaReporteConcentrado.Columns.Add("tl17")
            'TablaReporteConcentrado.Columns.Add("tl18")
            'TablaReporteConcentrado.Columns.Add("tl19")
            'TablaReporteConcentrado.Columns.Add("tl20")
            'TablaReporteConcentrado.Columns.Add("t1")
            'TablaReporteConcentrado.Columns.Add("t2")
            'TablaReporteConcentrado.Columns.Add("t3")
            'TablaReporteConcentrado.Columns.Add("t4")
            'TablaReporteConcentrado.Columns.Add("t5")
            'TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            'TablaReporteConcentrado.Columns.Add("t8")
            'TablaReporteConcentrado.Columns.Add("t9")
            'TablaReporteConcentrado.Columns.Add("t10")
            'TablaReporteConcentrado.Columns.Add("t11")
            'TablaReporteConcentrado.Columns.Add("t12")
            'TablaReporteConcentrado.Columns.Add("t13")
            'TablaReporteConcentrado.Columns.Add("t14")
            'TablaReporteConcentrado.Columns.Add("t15")
            'TablaReporteConcentrado.Columns.Add("t16")
            'TablaReporteConcentrado.Columns.Add("t17")
            'TablaReporteConcentrado.Columns.Add("t18")
            'TablaReporteConcentrado.Columns.Add("t19")
            'TablaReporteConcentrado.Columns.Add("t20")

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = TablaReporteConcentrado.NewRow()
            '    row("No") = tabla1.Rows(value).Item("No")
            '    row("Pares") = tabla1.Rows(value).Item("Pares")
            '    row("Lote") = tabla1.Rows(value).Item("Lote")
            '    row("Material") = tabla1.Rows(value).Item("Material")
            '    row("C5") = tabla1.Rows(value).Item("C5")
            '    row("Corrida") = tabla1.Rows(value).Item("Corrida")
            '    row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
            '            row(value2) = tabla1.Rows(value).Item(value2)
            '            Dim X = value2 + 20
            '            row(X) = tabla1.Rows(value).Item(value2 + 20)
            '        End If
            '    Next
            '    TablaReporteConcentrado.Rows.Add(row)
            'Next
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Casco")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                'Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lote").ToString
                rowc("Casco") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 7 To 26

                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "14"
                            Dim o = tabla1.Rows(value).Item(value)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1 'Corrida 12-14½
                        Case "15"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "16"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "17"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "18"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "19"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "20"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "21"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "22"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "23"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "24"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "25"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "26"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "27"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "28"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "29"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "30"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                    End Select
                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSADO_DE_CASCO")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CASCO Y CONTRAFUERTE"
                    reporte("tituloC5") = "CONTRAFUERTE"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Desglosado de casco " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    'reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirDesglosadoContrafuerte(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        ' Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de casco
        listaComponentes.Clear()
        'tablaClasificacion = obj.ObtenerClasificacion("CASCO")
        'clasificacion = tablaClasificacion.Rows(0).Item(0)
        'Buscar id clasificación de contrafuerte
        tablaClasificacion = obj.ObtenerClasificacion("CONTRAFUERTE")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDeCascoYContrafuerte(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else

            'Dim TablaReporteConcentrado = New DataTable
            'TablaReporteConcentrado.Clear()
            'TablaReporteConcentrado.Columns.Add("No")
            'TablaReporteConcentrado.Columns.Add("Pares")arodr
            'TablaReporteConcentrado.Columns.Add("Lote")
            'TablaReporteConcentrado.Columns.Add("Material")
            'TablaReporteConcentrado.Columns.Add("C5")
            'TablaReporteConcentrado.Columns.Add("Corrida")
            'TablaReporteConcentrado.Columns.Add("Proveedor")
            'TablaReporteConcentrado.Columns.Add("tl1")
            'TablaReporteConcentrado.Columns.Add("tl2")
            'TablaReporteConcentrado.Columns.Add("tl3")
            'TablaReporteConcentrado.Columns.Add("tl4")
            'TablaReporteConcentrado.Columns.Add("tl5")
            'TablaReporteConcentrado.Columns.Add("tl6")
            'TablaReporteConcentrado.Columns.Add("tl7")
            'TablaReporteConcentrado.Columns.Add("tl8")
            'TablaReporteConcentrado.Columns.Add("tl9")
            'TablaReporteConcentrado.Columns.Add("tl10")
            'TablaReporteConcentrado.Columns.Add("tl11")
            'TablaReporteConcentrado.Columns.Add("tl12")
            'TablaReporteConcentrado.Columns.Add("tl13")
            'TablaReporteConcentrado.Columns.Add("tl14")
            'TablaReporteConcentrado.Columns.Add("tl15")
            'TablaReporteConcentrado.Columns.Add("tl16")
            'TablaReporteConcentrado.Columns.Add("tl17")
            'TablaReporteConcentrado.Columns.Add("tl18")
            'TablaReporteConcentrado.Columns.Add("tl19")
            'TablaReporteConcentrado.Columns.Add("tl20")
            'TablaReporteConcentrado.Columns.Add("t1")
            'TablaReporteConcentrado.Columns.Add("t2")
            'TablaReporteConcentrado.Columns.Add("t3")
            'TablaReporteConcentrado.Columns.Add("t4")
            'TablaReporteConcentrado.Columns.Add("t5")
            'TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            'TablaReporteConcentrado.Columns.Add("t8")
            'TablaReporteConcentrado.Columns.Add("t9")
            'TablaReporteConcentrado.Columns.Add("t10")
            'TablaReporteConcentrado.Columns.Add("t11")
            'TablaReporteConcentrado.Columns.Add("t12")
            'TablaReporteConcentrado.Columns.Add("t13")
            'TablaReporteConcentrado.Columns.Add("t14")
            'TablaReporteConcentrado.Columns.Add("t15")
            'TablaReporteConcentrado.Columns.Add("t16")
            'TablaReporteConcentrado.Columns.Add("t17")
            'TablaReporteConcentrado.Columns.Add("t18")
            'TablaReporteConcentrado.Columns.Add("t19")
            'TablaReporteConcentrado.Columns.Add("t20")

            'For value = 0 To tabla1.Rows.Count - 1
            '    Dim row As DataRow = TablaReporteConcentrado.NewRow()
            '    row("No") = tabla1.Rows(value).Item("No")
            '    row("Pares") = tabla1.Rows(value).Item("Pares")
            '    row("Lote") = tabla1.Rows(value).Item("Lote")
            '    row("Material") = tabla1.Rows(value).Item("Material")
            '    row("C5") = tabla1.Rows(value).Item("C5")
            '    row("Corrida") = tabla1.Rows(value).Item("Corrida")
            '    row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
            '    For value2 = 7 To 26
            '        If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
            '            row(value2) = tabla1.Rows(value).Item(value2)
            '            Dim X = value2 + 20
            '            row(X) = tabla1.Rows(value).Item(value2 + 20)
            '        End If
            '    Next
            '    TablaReporteConcentrado.Rows.Add(row)
            'Next
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lotes")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            'TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")

            For value = 0 To tabla1.Rows.Count - 1
                Dim t1 As Integer? = Nothing
                Dim t2 As Integer? = Nothing
                Dim t3 As Integer? = Nothing
                Dim t4 As Integer? = Nothing
                Dim t5 As Integer? = Nothing
                Dim t6 As Integer? = Nothing
                'Dim t7 As Integer? = Nothing
                Dim t8 As Integer? = Nothing
                Dim rowc As DataRow = TablaReporteConcentrado.NewRow()
                'rowc("No") = tabla1.Rows(value).Item("No").ToString
                rowc("Pares") = tabla1.Rows(value).Item("Pares").ToString
                rowc("Lotes") = tabla1.Rows(value).Item("Lote").ToString
                rowc("Material") = tabla1.Rows(value).Item("Material").ToString
                rowc("Corrida") = tabla1.Rows(value).Item("Corrida").ToString
                rowc("Proveedor") = tabla1.Rows(value).Item("Proveedor").ToString
                Dim cont = 4
                For value2 = 7 To 26

                    Dim x = tabla1.Rows(value).Item(value2).ToString
                    Dim y = x.Trim.Replace("½", "")
                    Select Case y
                        Case "12"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "13"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1
                        Case "14"
                            Dim o = tabla1.Rows(value).Item(value)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t1 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t1") = t1 'Corrida 12-14½
                        Case "15"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "16"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "17"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t2 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t2") = t2
                        Case "18"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "19"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t3 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t3") = t3
                        Case "20"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "21"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t4 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t4") = t4
                        Case "22"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "23"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "24"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t5 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t5") = t5
                        Case "25"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "26"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "27"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t6 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t6") = t6
                        Case "28"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "29"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                        Case "30"
                            Dim o = tabla1.Rows(value).Item(value2)
                            If IsDBNull(tabla1.Rows(value).Item(value2 + 20)) = False Then
                                t8 += tabla1.Rows(value).Item(value2 + 20)
                            End If
                            cont = cont + 1
                            rowc("t8") = t8
                    End Select
                Next
                TablaReporteConcentrado.Rows.Add(rowc)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSADO_DE_CONTRAFUERTE")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "CASCO Y CONTRAFUERTE"
                    reporte("tituloC5") = "CONTRAFUERTE"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Desglosado de contrafuerte " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    ' reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub ImprimirDesglosadoPlanta(ByVal fecha As String, ByVal nave As Integer)
        Dim obj As New ReportesBU

        Dim tablaClasificacion As DataTable
        Dim clasificacion As Integer = 0
        'Dim tablaClasificacion2 As DataTable
        Dim clasificacion2 As Integer = 0

        Dim listaComponentes As New List(Of Integer)
        Dim tablaComponentes As New DataTable
        Dim tabla1 As New DataTable
        Dim tabla2 As New DataTable
        Dim tablaA As New DataTable
        Dim tablaB As New DataTable
        'Dim idSicy As DataTable

        '*********************************************************************************************************************
        'Buscar id clasificación de planta
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("PLANTA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)
        tabla1 = obj.ReporteRelacionDesglosadaDePlanta(fecha, nave, clasificacion)
        tabla1.TableName = ""

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")
            'objAdvertencia.mensaje = "No hay información para generar el reporte."
            'objAdvertencia.ShowDialog()
        Else
            Dim TablaReporteConcentrado = New DataTable
            TablaReporteConcentrado.Clear()
            TablaReporteConcentrado.Columns.Add("No")
            TablaReporteConcentrado.Columns.Add("Pares")
            TablaReporteConcentrado.Columns.Add("Lote")
            TablaReporteConcentrado.Columns.Add("Material")
            TablaReporteConcentrado.Columns.Add("C5")
            TablaReporteConcentrado.Columns.Add("Corrida")
            TablaReporteConcentrado.Columns.Add("Proveedor")
            TablaReporteConcentrado.Columns.Add("tl1")
            TablaReporteConcentrado.Columns.Add("tl2")
            TablaReporteConcentrado.Columns.Add("tl3")
            TablaReporteConcentrado.Columns.Add("tl4")
            TablaReporteConcentrado.Columns.Add("tl5")
            TablaReporteConcentrado.Columns.Add("tl6")
            TablaReporteConcentrado.Columns.Add("tl7")
            TablaReporteConcentrado.Columns.Add("tl8")
            TablaReporteConcentrado.Columns.Add("tl9")
            TablaReporteConcentrado.Columns.Add("tl10")
            TablaReporteConcentrado.Columns.Add("tl11")
            TablaReporteConcentrado.Columns.Add("tl12")
            TablaReporteConcentrado.Columns.Add("tl13")
            TablaReporteConcentrado.Columns.Add("tl14")
            TablaReporteConcentrado.Columns.Add("tl15")
            TablaReporteConcentrado.Columns.Add("tl16")
            TablaReporteConcentrado.Columns.Add("tl17")
            TablaReporteConcentrado.Columns.Add("tl18")
            TablaReporteConcentrado.Columns.Add("tl19")
            TablaReporteConcentrado.Columns.Add("tl20")
            TablaReporteConcentrado.Columns.Add("t1")
            TablaReporteConcentrado.Columns.Add("t2")
            TablaReporteConcentrado.Columns.Add("t3")
            TablaReporteConcentrado.Columns.Add("t4")
            TablaReporteConcentrado.Columns.Add("t5")
            TablaReporteConcentrado.Columns.Add("t6")
            TablaReporteConcentrado.Columns.Add("t7")
            TablaReporteConcentrado.Columns.Add("t8")
            TablaReporteConcentrado.Columns.Add("t9")
            TablaReporteConcentrado.Columns.Add("t10")
            TablaReporteConcentrado.Columns.Add("t11")
            TablaReporteConcentrado.Columns.Add("t12")
            TablaReporteConcentrado.Columns.Add("t13")
            TablaReporteConcentrado.Columns.Add("t14")
            TablaReporteConcentrado.Columns.Add("t15")
            TablaReporteConcentrado.Columns.Add("t16")
            TablaReporteConcentrado.Columns.Add("t17")
            TablaReporteConcentrado.Columns.Add("t18")
            TablaReporteConcentrado.Columns.Add("t19")
            TablaReporteConcentrado.Columns.Add("t20")

            For value = 0 To tabla1.Rows.Count - 1
                Dim row As DataRow = TablaReporteConcentrado.NewRow()
                row("No") = tabla1.Rows(value).Item("No")
                row("Pares") = tabla1.Rows(value).Item("Pares")
                row("Lote") = tabla1.Rows(value).Item("Lote")
                row("Material") = tabla1.Rows(value).Item("Material")
                row("C5") = tabla1.Rows(value).Item("C5")
                row("Corrida") = tabla1.Rows(value).Item("Corrida")
                'row("Proveedor") = tabla1.Rows(value).Item("Proveedor")
                For value2 = 6 To 25
                    If tabla1.Rows(value).Item(value2).ToString <> "" Then ' And tabla1.Rows(value).Item(value2 + 20).ToString = "0"
                        row(value2) = tabla1.Rows(value).Item(value2)
                        Dim X = value2 + 20
                        row(X) = tabla1.Rows(value).Item(value2 + 20)
                    End If
                Next
                TablaReporteConcentrado.Rows.Add(row)
            Next
            '********************************Creación de reporte
            Try
                If TablaReporteConcentrado.Rows.Count = 0 Then
                Else
                    '**Llenado del reporte
                    Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("RELACION_DESGLOSADA_FORMATO4")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport
                    'Dim ruta As String
                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma() 'fechaDias
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("material") = "PLANTA"
                    reporte("tituloC5") = "HORMA"
                    reporte.RegData(TablaReporteConcentrado)
                    reporte.Render()

                    Ruta = Ruta + "\" + cmbNave.Text
                    If Not System.IO.Directory.Exists(Ruta) Then
                        Directory.CreateDirectory(Ruta)
                    End If
                    'reporte.ExportDocument(StiExportFormat.Pdf, My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + cmbNave.Text + " Concentrado de Planta por Proveedor.pdf")
                    reporte.ExportDocument(StiExportFormat.Pdf, Ruta + "\Desglosado de planta " + dtpFecha.Value.ToString("dd_MM_yyyy") + ".pdf")
                    'reporte.Show()
                    '*********************
                    Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region
    Private Function GetRutaLogoPorNave(ByVal idNave As Integer) As String
        Return Tools.Controles.ObtenerLogoNave(cmbNave.SelectedValue)
    End Function

    Private Function GetFormatoFechaPrograma() As String
        Dim dateValue As Date = dtpFecha.Value.ToShortDateString
        Return CapitalizarCadena(dateValue.ToString("dddd, dd ")) & CapitalizarCadena(dateValue.ToString("MMMM")) & " de " & dateValue.ToString("yyyy")
    End Function

    Private Function CapitalizarCadena(ByVal cadena As String) As String
        Dim curCulture As Globalization.CultureInfo = Threading.Thread.CurrentThread.CurrentCulture
        Dim tInfo As Globalization.TextInfo = curCulture.TextInfo()
        Return tInfo.ToTitleCase(cadena)
    End Function
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

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim activar = False
        If (chkSeleccionarTodo.Checked) Then
            activar = True
        End If
        For i As Integer = 0 To (vwReporte.RowCount) Step 1
            vwReporte.SetRowCellValue(i, " ", activar)
        Next
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class