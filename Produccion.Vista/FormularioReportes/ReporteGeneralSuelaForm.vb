Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.ExcelExport
Imports Produccion.Negocios
Imports Programacion.Negocio
Public Class ReporteGeneralSuelaForm
    Dim objAdvertencia As New Tools.AdvertenciaForm
    'Private ultExportGrid As Object
    'property

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        MostrarDatos()

    End Sub

    Private Sub ReporteGeneralSuelaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDel.Value = Date.Now
        dtpFechaAl.Value = Date.Now
        CargarNavesCheck()
    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDel.ValueChanged
        dtpFechaAl.MinDate = dtpFechaDel.Value
    End Sub

    Private Sub MostrarDatos()
        Dim obj As New ReportesBU
        Dim tblReporte As New DataTable
        Dim naves As String = String.Empty
        Dim fechaDel As Date = dtpFechaDel.Value.ToShortDateString()
        Dim fechaAl As Date = dtpFechaAl.Value.ToShortDateString()
        Dim idProveedor As Integer


        grdReportes.DataSource = Nothing



        naves = NavesConsultar()

        Dim pares As Integer = 0
        Dim lotes As Integer = 0

        Dim clasificacion As Integer = 0
        Dim tablaClasificacion As DataTable
        Dim listaComponentes As New List(Of Integer)

        Dim tabla1 As New DataTable

        If rdtrento.Checked Then

            idProveedor = 918

        End If

        If rdInyeva.Checked Then

            idProveedor = 704

        End If


        'Buscar id clasificación de suela
        listaComponentes.Clear()
        tablaClasificacion = obj.ObtenerClasificacion("SUELA")
        clasificacion = tablaClasificacion.Rows(0).Item(0)

        objAdvertencia.mensaje = "La consulta puede tardar un poco."
        objAdvertencia.ShowDialog()

        Me.Cursor = Cursors.WaitCursor

        tabla1 = obj.ReporteSuelasTrento(fechaDel, fechaAl, naves, clasificacion, idProveedor)

        If tabla1.Rows.Count = 0 Then
            objAdvertencia.mensaje = "No hay información para mostrar"
            objAdvertencia.ShowDialog()
            lblRegistros.Text = tabla1.Rows.Count
            Me.Cursor = Cursors.Default
            Exit Sub
        End If


        tabla1.TableName = ""
        Dim TablaReporteConcentrado = New DataTable
        TablaReporteConcentrado.Clear()
        TablaReporteConcentrado.Columns.Add("NO")
        TablaReporteConcentrado.Columns.Add("ID ETIQUETA")
        TablaReporteConcentrado.Columns.Add("NAVE")
        TablaReporteConcentrado.Columns.Add("MATERIAL")
        TablaReporteConcentrado.Columns.Add("MOLDE")
        TablaReporteConcentrado.Columns.Add("FAMILIA")
        TablaReporteConcentrado.Columns.Add("LOTES")
        TablaReporteConcentrado.Columns.Add("FECHA PROGRAMA")
        'TRENTO
        If idProveedor = 918 Then
            TablaReporteConcentrado.Columns.Add("TERMINADO")
            TablaReporteConcentrado.Columns.Add("FOLIO REGISTRO")
            TablaReporteConcentrado.Columns.Add("FECHA REGISTRO")
        End If
        TablaReporteConcentrado.Columns.Add("12")
        TablaReporteConcentrado.Columns.Add("12½")
        TablaReporteConcentrado.Columns.Add("13")
        TablaReporteConcentrado.Columns.Add("13½")
        TablaReporteConcentrado.Columns.Add("14")
        TablaReporteConcentrado.Columns.Add("14½")
        TablaReporteConcentrado.Columns.Add("15")
        TablaReporteConcentrado.Columns.Add("15½")
        TablaReporteConcentrado.Columns.Add("16")
        TablaReporteConcentrado.Columns.Add("16½")
        TablaReporteConcentrado.Columns.Add("17")
        TablaReporteConcentrado.Columns.Add("17½")
        TablaReporteConcentrado.Columns.Add("18")
        TablaReporteConcentrado.Columns.Add("18½")
        TablaReporteConcentrado.Columns.Add("19")
        TablaReporteConcentrado.Columns.Add("19½")
        TablaReporteConcentrado.Columns.Add("20")
        TablaReporteConcentrado.Columns.Add("20½")
        TablaReporteConcentrado.Columns.Add("21")
        TablaReporteConcentrado.Columns.Add("21½")
        TablaReporteConcentrado.Columns.Add("22")
        TablaReporteConcentrado.Columns.Add("22½")
        TablaReporteConcentrado.Columns.Add("23")
        TablaReporteConcentrado.Columns.Add("23½")
        TablaReporteConcentrado.Columns.Add("24")
        TablaReporteConcentrado.Columns.Add("24½")
        TablaReporteConcentrado.Columns.Add("25")
        TablaReporteConcentrado.Columns.Add("25½")
        TablaReporteConcentrado.Columns.Add("26")
        TablaReporteConcentrado.Columns.Add("26½")
        TablaReporteConcentrado.Columns.Add("27")
        TablaReporteConcentrado.Columns.Add("27½")
        TablaReporteConcentrado.Columns.Add("28")
        TablaReporteConcentrado.Columns.Add("28½")
        TablaReporteConcentrado.Columns.Add("29")
        TablaReporteConcentrado.Columns.Add("29½")
        TablaReporteConcentrado.Columns.Add("30")
        TablaReporteConcentrado.Columns.Add("PARES")
        Dim contador = 1

        For value = 0 To tabla1.Rows.Count - 1
            Dim row As DataRow = TablaReporteConcentrado.NewRow()
            row("NO") = contador
            row("ID ETIQUETA") = tabla1.Rows(value).Item("ID ETIQUETA")
            row("NAVE") = tabla1.Rows(value).Item("NAVE")
            row("MATERIAL") = tabla1.Rows(value).Item("Material")
            row("MOLDE") = tabla1.Rows(value).Item("MOLDE")
            row("FAMILIA") = tabla1.Rows(value).Item("FAMILIA")
            row("LOTES") = tabla1.Rows(value).Item("LOTE")
            row("FECHA PROGRAMA") = tabla1.Rows(value).Item("FECHA PROGRAMA")
            If idProveedor = 918 Then
                row("TERMINADO") = tabla1.Rows(value).Item("TERMINADO")
                row("FOLIO REGISTRO") = tabla1.Rows(value).Item("FOLIO REGISTRO")
                row("FECHA REGISTRO") = tabla1.Rows(value).Item("FECHA REGISTRO")
            End If
            row("PARES") = tabla1.Rows(value).Item("PARES")
            For value2 = 8 To 27
                Dim x = tabla1.Rows(value).Item(value2).ToString
                Select Case tabla1.Rows(value).Item(value2).ToString
                    Case "12"
                        row("12") = tabla1.Rows(value).Item(value2 + 20)
                    Case "12½"
                        row("12½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13"
                        row("13") = tabla1.Rows(value).Item(value2 + 20)
                    Case "13½"
                        row("13½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14"
                        row("14") = tabla1.Rows(value).Item(value2 + 20)
                    Case "14½"
                        row("14½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15"
                        row("15") = tabla1.Rows(value).Item(value2 + 20)
                    Case "15½"
                        row("15½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16"
                        row("16") = tabla1.Rows(value).Item(value2 + 20)
                    Case "16½"
                        row("16½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17"
                        row("17") = tabla1.Rows(value).Item(value2 + 20)
                    Case "17½"
                        row("17½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18"
                        row("18") = tabla1.Rows(value).Item(value2 + 20)
                    Case "18½"
                        row("18½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19"
                        row("19") = tabla1.Rows(value).Item(value2 + 20)
                    Case "19½"
                        row("19½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20"
                        row("20") = tabla1.Rows(value).Item(value2 + 20)
                    Case "20½"
                        row("20½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21"
                        row("21") = tabla1.Rows(value).Item(value2 + 20)
                    Case "21½"
                        row("21½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22"
                        row("22") = tabla1.Rows(value).Item(value2 + 20)
                    Case "22½"
                        row("22½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23"
                        row("23") = tabla1.Rows(value).Item(value2 + 20)
                    Case "23½"
                        row("23½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24"
                        row("24") = tabla1.Rows(value).Item(value2 + 20)
                    Case "24½"
                        row("24½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25"
                        row("25") = tabla1.Rows(value).Item(value2 + 20)
                    Case "25½"
                        row("25½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26"
                        row("26") = tabla1.Rows(value).Item(value2 + 20)
                    Case "26½"
                        row("26½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27"
                        row("27") = tabla1.Rows(value).Item(value2 + 20)
                    Case "27½"
                        row("27½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28"
                        row("28") = tabla1.Rows(value).Item(value2 + 20)
                    Case "28½"
                        row("28½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29") = tabla1.Rows(value).Item(value2 + 20)
                    Case "29"
                        row("29½") = tabla1.Rows(value).Item(value2 + 20)
                    Case "30"
                        row("30") = tabla1.Rows(value).Item(value2 + 20)
                End Select
            Next
            contador = contador + 1
            TablaReporteConcentrado.Rows.Add(row)


        Next


        Try

            grdReportes.DataSource = TablaReporteConcentrado

            With grdReportes.DisplayLayout.Bands(0)
                .Columns("NO").Width = 30
                .Columns("ID ETIQUETA").Width = 100
                .Columns("NAVE").Width = 100
                .Columns("MATERIAL").Width = 300
                .Columns("MOLDE").Width = 100
                .Columns("FAMILIA").Width = 100
                '.Columns("UNIDAD").Width = 100
                .Columns("LOTES").Width = 50
                .Columns("FECHA PROGRAMA").Width = 130
                .Columns("PARES").Width = 50
                .Columns("12").Width = 30
                .Columns("12½").Width = 30
                .Columns("13").Width = 30
                .Columns("13½").Width = 30
                .Columns("14").Width = 30
                .Columns("14½").Width = 30
                .Columns("15").Width = 30
                .Columns("15½").Width = 30
                .Columns("16").Width = 30
                .Columns("16½").Width = 30
                .Columns("17").Width = 30
                .Columns("17½").Width = 30
                .Columns("18").Width = 30
                .Columns("18½").Width = 30
                .Columns("19").Width = 30
                .Columns("19½").Width = 30
                .Columns("20").Width = 30
                .Columns("20½").Width = 30
                .Columns("21").Width = 30
                .Columns("21½").Width = 30
                .Columns("22").Width = 30
                .Columns("22½").Width = 30
                .Columns("23").Width = 30
                .Columns("23½").Width = 30
                .Columns("24").Width = 30
                .Columns("24½").Width = 30
                .Columns("25").Width = 30
                .Columns("25½").Width = 30
                .Columns("26").Width = 30
                .Columns("26½").Width = 30
                .Columns("27").Width = 30
                .Columns("27½").Width = 30
                .Columns("28").Width = 30
                .Columns("28½").Width = 30
                .Columns("29").Width = 30
                .Columns("29½").Width = 30
                .Columns("30").Width = 30

                .Columns("NO").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("ID ETIQUETA").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("NAVE").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("MATERIAL").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("MOLDE").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("FAMILIA").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("UNIDAD").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("LOTES").CellAppearance.TextHAlign = HAlign.Center
                '.Columns("FECHA PROGRAMA").CellAppearance.TextHAlign = HAlign.Center
                .Columns("PARES").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12").CellAppearance.TextHAlign = HAlign.Center
                .Columns("12½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13").CellAppearance.TextHAlign = HAlign.Center
                .Columns("13½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14").CellAppearance.TextHAlign = HAlign.Center
                .Columns("14½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15").CellAppearance.TextHAlign = HAlign.Center
                .Columns("15½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16").CellAppearance.TextHAlign = HAlign.Center
                .Columns("16½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17").CellAppearance.TextHAlign = HAlign.Center
                .Columns("17½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18").CellAppearance.TextHAlign = HAlign.Center
                .Columns("18½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19").CellAppearance.TextHAlign = HAlign.Center
                .Columns("19½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20").CellAppearance.TextHAlign = HAlign.Center
                .Columns("20½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21").CellAppearance.TextHAlign = HAlign.Center
                .Columns("21½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22").CellAppearance.TextHAlign = HAlign.Center
                .Columns("22½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23").CellAppearance.TextHAlign = HAlign.Center
                .Columns("23½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24").CellAppearance.TextHAlign = HAlign.Center
                .Columns("24½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25").CellAppearance.TextHAlign = HAlign.Center
                .Columns("25½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26").CellAppearance.TextHAlign = HAlign.Center
                .Columns("26½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27").CellAppearance.TextHAlign = HAlign.Center
                .Columns("27½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28").CellAppearance.TextHAlign = HAlign.Center
                .Columns("28½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29").CellAppearance.TextHAlign = HAlign.Center
                .Columns("29½").CellAppearance.TextHAlign = HAlign.Center
                .Columns("30").CellAppearance.TextHAlign = HAlign.Center

                .Columns("NO").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("ID ETIQUETA").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("NAVE").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("MATERIAL").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("MOLDE").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("FAMILIA").CellAppearance.TextHAlign = Activation.NoEdit
                '.Columns("UNIDAD").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("LOTES").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("FECHA PROGRAMA").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("PARES").CellAppearance.TextHAlign = Activation.NoEdit
                .Columns("12").CellActivation = Activation.NoEdit
                .Columns("12½").CellActivation = Activation.NoEdit
                .Columns("13").CellActivation = Activation.NoEdit
                .Columns("13½").CellActivation = Activation.NoEdit
                .Columns("14").CellActivation = Activation.NoEdit
                .Columns("14½").CellActivation = Activation.NoEdit
                .Columns("15").CellActivation = Activation.NoEdit
                .Columns("15½").CellActivation = Activation.NoEdit
                .Columns("16").CellActivation = Activation.NoEdit
                .Columns("16½").CellActivation = Activation.NoEdit
                .Columns("17").CellActivation = Activation.NoEdit
                .Columns("17½").CellActivation = Activation.NoEdit
                .Columns("18").CellActivation = Activation.NoEdit
                .Columns("18½").CellActivation = Activation.NoEdit
                .Columns("19").CellActivation = Activation.NoEdit
                .Columns("19½").CellActivation = Activation.NoEdit
                .Columns("20").CellActivation = Activation.NoEdit
                .Columns("20½").CellActivation = Activation.NoEdit
                .Columns("21").CellActivation = Activation.NoEdit
                .Columns("21½").CellActivation = Activation.NoEdit
                .Columns("22").CellActivation = Activation.NoEdit
                .Columns("22½").CellActivation = Activation.NoEdit
                .Columns("23").CellActivation = Activation.NoEdit
                .Columns("23½").CellActivation = Activation.NoEdit
                .Columns("24").CellActivation = Activation.NoEdit
                .Columns("24½").CellActivation = Activation.NoEdit
                .Columns("25").CellActivation = Activation.NoEdit
                .Columns("25½").CellActivation = Activation.NoEdit
                .Columns("26").CellActivation = Activation.NoEdit
                .Columns("26½").CellActivation = Activation.NoEdit
                .Columns("27").CellActivation = Activation.NoEdit
                .Columns("27½").CellActivation = Activation.NoEdit
                .Columns("28").CellActivation = Activation.NoEdit
                .Columns("28½").CellActivation = Activation.NoEdit
                .Columns("29").CellActivation = Activation.NoEdit
                .Columns("29½").CellActivation = Activation.NoEdit
                .Columns("30").CellActivation = Activation.NoEdit

                .Columns("NO").Hidden = True

            End With
            grdReportes.DisplayLayout.AutoFitStyle = AutoFitStyle.None
            grdReportes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdReportes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        Finally
            lblRegistros.Text = tabla1.Rows.Count
        End Try

    End Sub

    Private Sub CargarNavesCheck()
        Dim objBu As New Programacion.Negocios.EtiquetasBU
        Dim naves As New DataTable

        naves = objBu.ConsultarNavesSAY()
        cboNave2.DataSource = naves
        cboNave2.ValueMember = "nave_naveid"
        cboNave2.DisplayMember = "nave_nombre"

        For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
            item.CheckState = CheckState.Checked
        Next

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Function NavesConsultar() As String
        Dim navesId As String = String.Empty
        Dim navesNombre As String = String.Empty

        For Each item As Infragistics.Win.ValueListItem In cboNave2.Items
            If item.CheckState = CheckState.Checked Then
                If navesId = String.Empty Then
                    navesId = CStr(item.DataValue.ToString)
                    navesNombre = item.DisplayText
                Else
                    navesId = CStr(item.DataValue.ToString) + "," + navesId
                    navesNombre = item.DisplayText + "," + navesNombre
                End If
            End If
        Next

        Return navesId
    End Function

    Public Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If grdReportes.Rows.Count > 0 Then
            ExportarEXCEL()
        End If
    End Sub

    Public Sub ExportarEXCEL()
        Dim sfd As New SaveFileDialog
        Dim ultExportGrid As New UltraGridExcelExporter
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grdReportes, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub


End Class