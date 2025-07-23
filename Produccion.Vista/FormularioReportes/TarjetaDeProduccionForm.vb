Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports Stimulsoft.Report

Imports Tools
Imports Stimulsoft.Report.Components
Imports Microsoft.Reporting.WinForms
'Imports Microsoft.Reporting.WebForms

Public Class TarjetaDeProduccionForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    '-------------------------------------------------------
    Dim singleFile As New StiReport


    Public Sub LlenarListasNaves()
        cbxNave = Tools.Controles.ComboNavesSegunUsuario(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub TarjetaDeProduccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LlenarListasNaves()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cbxNave.SelectedValue = 0
        dtpPrograma.Value = Date.Today.ToString
        grdLotes.DataSource = Nothing
        chbTodo.Checked = False
        lblTotalLotesNumero.Text = 0
        lblTotalPares.Text = 0
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            If cbxNave.SelectedValue = 0 Then
                objAdvertencia.mensaje = "Seleccione una nave"
                objAdvertencia.ShowDialog()
            Else
                Me.Cursor = Cursors.WaitCursor
                Dim obj As New TarjetaProduccionBU
                Dim tabla As New DataTable
                Dim pares As Integer = 0

                tabla = obj.LotesPrograma(cbxNave.SelectedValue, dtpPrograma.Value.ToShortDateString)
                If tabla.Rows.Count = 0 Then
                    objAdvertencia.mensaje = "No hay información para ésta Fecha de Programa."
                    objAdvertencia.ShowDialog()
                Else

                    grdLotes.DataSource = tabla

                    disenioGrid()
                    lblTotalLotesNumero.Text = grdLotes.Rows.Count

                    For value = 0 To grdLotes.Rows.Count - 1
                        If CStr(grdLotes.Rows(value).Cells("Pares").Value) <> "" Then
                            pares = pares + grdLotes.Rows(value).Cells("Pares").Value
                        End If
                    Next

                    lblTotalPares.Text = pares

                End If
                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub disenioGrid()
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor

            With grdLotes.DisplayLayout.Bands(0)
                .Columns(" ").Width = 5
                .Columns("Lote").Width = 30
                .Columns("Colección").Width = 70
                .Columns("Pares").Width = 20
                .Columns("Corrida").Width = 30
                .Columns("Modelo").Width = 25
                .Columns("Corte").Width = 60
                .Columns("Horma").Width = 60
                .Columns("Suela").Width = 100
                .Columns("Cliente").Width = 100
                .Columns("Cortador Piel").Width = 30
                .Columns("Cortador Forro").Width = 30
                .Columns("DCM x Par").Width = 30
                .Columns("Costo Total").Width = 30
                .Columns("Tiempo").Width = 25

                .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Lote").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Pares").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Costo Total").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Tiempo").CellAppearance.TextHAlign = HAlign.Right
                .Columns("DCM x Par").CellAppearance.TextHAlign = HAlign.Right

                .Columns("Lote").CellActivation = Activation.NoEdit
                .Columns("Colección").CellActivation = Activation.NoEdit
                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Corrida").CellActivation = Activation.NoEdit
                .Columns("Cliente").CellActivation = Activation.NoEdit
                .Columns("Modelo").CellActivation = Activation.NoEdit
                .Columns("Corte").CellActivation = Activation.NoEdit
                .Columns("Horma").CellActivation = Activation.NoEdit
                .Columns("Suela").CellActivation = Activation.NoEdit

                .Columns("Cortador Piel").CellActivation = Activation.NoEdit
                .Columns("Cortador Forro").CellActivation = Activation.NoEdit
                .Columns("Costo Total").CellActivation = Activation.NoEdit
                .Columns("DCM x Par").CellActivation = Activation.NoEdit
                .Columns("Tiempo").CellActivation = Activation.NoEdit

                .Columns("Cortador Piel").Header.Caption = "Cortador" + vbCrLf + "Piel"
                .Columns("Cortador Forro").Header.Caption = "Cortador" + vbCrLf + "Forro"
                .Columns("DCM x Par").Header.Caption = "DCM" + vbCrLf + " X Par"
                .Columns("Costo Total").Header.Caption = "Costo" + vbCrLf + "Total"

                .Columns("Pe").Hidden = True

                .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Costo Total").Format = "#.##"

            End With
            grdLotes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdLotes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdLotes.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodo.CheckedChanged

        Try
            If chbTodo.Checked = True Then
                For value = 0 To grdLotes.Rows.Count - 1
                    grdLotes.Rows(value).Cells(" ").Value = 1
                Next
            Else
                For value = 0 To grdLotes.Rows.Count - 1
                    grdLotes.Rows(value).Cells(" ").Value = 0
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim sinreg As Boolean = False
        Try
            If grdLotes.Rows.Count = 0 Then
                objAdvertencia.mensaje = "No hay información para imprimir."
                objAdvertencia.ShowDialog()
            Else
                singleFile.NeedsCompiling = False
                singleFile.IsRendered = True
                singleFile.RenderedPages.Clear()

                For value = 0 To grdLotes.Rows.Count - 1
                    If grdLotes.Rows(value).Cells(" ").Value = 1 Then
                        Try
                            reporteTarjetaDeProduccion(grdLotes.Rows(value).Cells("Lote").Value, cbxNave.SelectedValue)
                            sinreg = True
                        Catch ex As Exception
                        End Try
                    End If
                Next

                singleFile.Show()

                If sinreg = False Then
                    objAdvertencia.mensaje = "Seleccione un registro."
                    objAdvertencia.ShowDialog()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Metodo para imprimir reportes
    ''' </summary>
    ''' <param name="L"></param>
    ''' <param name="N"></param>
    ''' <remarks></remarks>
    Public Sub reporteTarjetaDeProduccion(ByVal L As Integer, ByVal N As Integer)
        Dim obj As New ReportesBU
        Dim encabezado As New DataTable
        Dim numeracion As New DataTable
        Dim tabla As New DataTable
        Dim tablaPe As New DataTable
        Dim tablaDcm As New DataTable
        Dim tablaDcmSint As New DataTable
        Dim ds As New DataSet
        Dim nave As String = ""
        Dim lote As String = ""
        Dim año As String = ""
        Dim dcm As Double = 0
        Dim dcmSint As Double = 0
        Dim tiempo As String = "0"
        Dim costo As Double = 0
        Dim productoEstilo As Integer = 0
        Dim añolote As Integer = 0

        añolote = Year(dtpPrograma.Value)
        numeracion = obj.ReporteTarjetaProduccionNumeracion(L, N, añolote)
        tabla = obj.ReporteTarjetaProduccionFracciones(L, N, añolote)
        tablaPe = obj.ReporteTarjetaProduccionProductoEstilo(L, N, añolote)
        productoEstilo = tablaPe.Rows(0).Item(0)
        encabezado = obj.ReporteTarjetaProduccionEncabezado(L, N, añolote, productoEstilo)
        tablaDcm = obj.ReporteTarjetaProduccionTotalDCMComponentePiel(productoEstilo, N)
        tablaDcmSint = obj.ReporteTarjetaProduccionTotalDCMPielSintetica(productoEstilo, N)

        dcm = tablaDcm.Rows(0).Item(0)
        dcmSint = tablaDcmSint.Rows(0).Item(0)

        costo = encabezado.Rows(0).Item("Costo")
        tiempo = encabezado.Rows(0).Item("tiempo")
        'For value = 0 To tabla.Rows.Count - 1
        '    Try
        '        costo = costo + tabla.Rows(value).Item("precio")
        '    Catch ex As Exception
        '        costo = costo + 0
        '    End Try
        '    Try
        '        tiempo = tiempo + tabla.Rows(value).Item("tiempo")
        '    Catch ex As Exception
        '        tiempo = tiempo + 0
        '    End Try

        'Next

        Dim tabla1 = New DataTable
        tabla1.Clear()
        tabla1.Columns.Add("costo")
        tabla1.Columns.Add("tiempo")
        tabla1.Columns.Add("fraccion")
        tabla1.Columns.Add("observacion")
        tabla1.Columns.Add("codigo")
        tabla1.Columns.Add("numerocodigo")
        tabla1.Columns.Add("maquina")

        tabla1.Columns.Add("costo2")
        tabla1.Columns.Add("tiempo2")
        tabla1.Columns.Add("fraccion2")
        tabla1.Columns.Add("observacion2")
        tabla1.Columns.Add("codigo2")
        tabla1.Columns.Add("numerocodigo2")
        tabla1.Columns.Add("maquina2")

        tabla1.Columns.Add("costo3")
        tabla1.Columns.Add("tiempo3")
        tabla1.Columns.Add("fraccion3")
        tabla1.Columns.Add("observacion3")
        tabla1.Columns.Add("codigo3")
        tabla1.Columns.Add("numerocodigo3")
        tabla1.Columns.Add("maquina3")

        tabla1.Columns.Add("costo4")
        tabla1.Columns.Add("tiempo4")
        tabla1.Columns.Add("fraccion4")
        tabla1.Columns.Add("observacion4")
        tabla1.Columns.Add("codigo4")
        tabla1.Columns.Add("numerocodigo4")
        tabla1.Columns.Add("maquina4")

        tabla1.Columns.Add("costo5")
        tabla1.Columns.Add("tiempo5")
        tabla1.Columns.Add("fraccion5")
        tabla1.Columns.Add("observacion5")
        tabla1.Columns.Add("codigo5")
        tabla1.Columns.Add("numerocodigo5")
        tabla1.Columns.Add("maquina5")

        tabla1.Columns.Add("costo6")
        tabla1.Columns.Add("tiempo6")
        tabla1.Columns.Add("fraccion6")
        tabla1.Columns.Add("codigo6")
        tabla1.Columns.Add("numerocodigo6")
        tabla1.Columns.Add("maquina6")

        tabla1.Columns.Add("costo7")
        tabla1.Columns.Add("tiempo7")
        tabla1.Columns.Add("fraccion7")
        tabla1.Columns.Add("codigo7")
        tabla1.Columns.Add("numerocodigo7")
        tabla1.Columns.Add("maquina7")

        '*********************************************************************************************************************
        '' Dar formato a la fecha
        Try
            Dim dateValue As Date = encabezado.Rows(0).Item("programa").ToString
            Dim DAY = dateValue.DayOfWeek()
            Dim NUMEROMES = dateValue.Month()
            Dim dia As String = ""
            Dim mes As String = ""
            Dim fechaDias As String = ""
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
            ''******************************************************************************************************************
            Dim codigo As String = ""
            Dim codigoencabezado As String = ""
            Dim naves As String = ""

            naves = cbxNave.SelectedValue
            'naves = "01"

            Try

            Catch ex As Exception

            End Try
            'año = encabezado.Rows(0).Item("año").ToString.Trim.Replace("20", "")

            año = encabezado.Rows(0).Item("año").ToString.Trim.Substring(2, 2)

            If encabezado.Rows(0).Item("lote").ToString.Length = 1 Then
                lote = "0000" + encabezado.Rows(0).Item("lote").ToString
            ElseIf encabezado.Rows(0).Item("lote").ToString.Length = 2 Then
                lote = "000" + encabezado.Rows(0).Item("lote").ToString
            ElseIf encabezado.Rows(0).Item("lote").ToString.Length = 3 Then
                lote = "00" + encabezado.Rows(0).Item("lote").ToString
            ElseIf encabezado.Rows(0).Item("lote").ToString.Length = 4 Then
                lote = "0" + encabezado.Rows(0).Item("lote").ToString
            Else
                lote = encabezado.Rows(0).Item("lote").ToString
            End If

            If naves.Length = 1 Then
                naves = "0" + naves
            Else
                naves = naves
            End If

            codigo = "N" + naves + lote.ToString + año
            codigoencabezado = codigo

            For value = 0 To 4
                Dim rowc1 As DataRow = tabla1.NewRow()
                Try
                    rowc1("costo") = Format(tabla.Rows(value).Item("precio"), "N2")
                    rowc1("tiempo") = tabla.Rows(value).Item("tiempo1").ToString
                    rowc1("fraccion") = tabla.Rows(value).Item("fraccion").ToString
                    rowc1("observacion") = tabla.Rows(value).Item("observaciones").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value).Item("id").ToString
                    ElseIf tabla.Rows(value).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value).Item("id").ToString
                    End If
                    rowc1("codigo") = codigo + idfraccion
                    rowc1("numerocodigo") = codigo + "-" + idfraccion
                    rowc1("maquina") = tabla.Rows(value).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo2") = Format(tabla.Rows(value + 5).Item("precio"), "N2")
                    rowc1("tiempo2") = tabla.Rows(value + 5).Item("tiempo1").ToString
                    rowc1("fraccion2") = tabla.Rows(value + 5).Item("fraccion").ToString
                    rowc1("observacion2") = tabla.Rows(value + 5).Item("observaciones").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 5).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 5).Item("id").ToString
                    ElseIf tabla.Rows(value + 5).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 5).Item("id").ToString
                    ElseIf tabla.Rows(value + 5).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 5).Item("id").ToString
                    ElseIf tabla.Rows(value + 5).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 5).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 5).Item("id").ToString
                    End If
                    rowc1("codigo2") = codigo + idfraccion
                    rowc1("numerocodigo2") = codigo + "-" + idfraccion
                    rowc1("maquina2") = tabla.Rows(value + 5).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo3") = Format(tabla.Rows(value + 10).Item("precio"), "N2")
                    rowc1("tiempo3") = tabla.Rows(value + 10).Item("tiempo1").ToString
                    rowc1("fraccion3") = tabla.Rows(value + 10).Item("fraccion").ToString
                    rowc1("observacion3") = tabla.Rows(value + 10).Item("observaciones").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 10).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 10).Item("id").ToString
                    ElseIf tabla.Rows(value + 10).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 10).Item("id").ToString
                    ElseIf tabla.Rows(value + 10).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 10).Item("id").ToString
                    ElseIf tabla.Rows(value + 10).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 10).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 10).Item("id").ToString
                    End If
                    rowc1("codigo3") = codigo + idfraccion
                    rowc1("numerocodigo3") = codigo + "-" + idfraccion
                    rowc1("maquina3") = tabla.Rows(value + 10).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo4") = Format(tabla.Rows(value + 15).Item("precio"), "N2")
                    rowc1("tiempo4") = tabla.Rows(value + 15).Item("tiempo1").ToString
                    rowc1("fraccion4") = tabla.Rows(value + 15).Item("fraccion").ToString
                    rowc1("observacion4") = tabla.Rows(value + 15).Item("observaciones").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 15).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 15).Item("id").ToString
                    ElseIf tabla.Rows(value + 15).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 15).Item("id").ToString
                    ElseIf tabla.Rows(value + 15).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 15).Item("id").ToString
                    ElseIf tabla.Rows(value + 15).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 15).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 15).Item("id").ToString
                    End If
                    rowc1("codigo4") = codigo + idfraccion
                    rowc1("numerocodigo4") = codigo + "-" + idfraccion
                    rowc1("maquina4") = tabla.Rows(value + 15).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo5") = Format(tabla.Rows(value + 20).Item("precio"), "N2")
                    rowc1("tiempo5") = tabla.Rows(value + 20).Item("tiempo1").ToString
                    rowc1("fraccion5") = tabla.Rows(value + 20).Item("fraccion").ToString
                    rowc1("observacion5") = tabla.Rows(value + 20).Item("observaciones").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 20).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 20).Item("id").ToString
                    ElseIf tabla.Rows(value + 20).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 20).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 20).Item("id").ToString
                    End If
                    rowc1("codigo5") = codigo + idfraccion
                    rowc1("numerocodigo5") = codigo + "-" + idfraccion
                    rowc1("maquina5") = tabla.Rows(value + 20).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo6") = Format(tabla.Rows(value + 25).Item("precio"), "N2")
                    rowc1("tiempo6") = tabla.Rows(value + 25).Item("tiempo1").ToString
                    rowc1("fraccion6") = tabla.Rows(value + 25).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 25).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 25).Item("id").ToString
                    ElseIf tabla.Rows(value + 25).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 25).Item("id").ToString
                    ElseIf tabla.Rows(value + 25).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 25).Item("id").ToString
                    ElseIf tabla.Rows(value + 25).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 25).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 25).Item("id").ToString
                    End If
                    rowc1("codigo6") = codigo + idfraccion
                    rowc1("numerocodigo6") = codigo + "-" + idfraccion
                    rowc1("maquina6") = tabla.Rows(value + 25).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                Try
                    rowc1("costo7") = Format(tabla.Rows(value + 30).Item("precio"), "N2")
                    rowc1("tiempo7") = tabla.Rows(value + 30).Item("tiempo1").ToString
                    rowc1("fraccion7") = tabla.Rows(value + 30).Item("fraccion").ToString
                    Dim idfraccion As String = ""
                    If tabla.Rows(value + 30).Item("id").ToString.Length = 1 Then
                        idfraccion = "0000" + tabla.Rows(value + 30).Item("id").ToString
                    ElseIf tabla.Rows(value + 30).Item("id").ToString.Length = 2 Then
                        idfraccion = "000" + tabla.Rows(value + 30).Item("id").ToString
                    ElseIf tabla.Rows(value + 30).Item("id").ToString.Length = 3 Then
                        idfraccion = "00" + tabla.Rows(value + 30).Item("id").ToString
                    ElseIf tabla.Rows(value + 30).Item("id").ToString.Length = 4 Then
                        idfraccion = "0" + tabla.Rows(value + 30).Item("id").ToString
                    Else
                        idfraccion = tabla.Rows(value + 30).Item("id").ToString
                    End If
                    rowc1("codigo7") = codigo + idfraccion
                    rowc1("numerocodigo7") = codigo + "-" + idfraccion
                    rowc1("maquina7") = tabla.Rows(value + 30).Item("maquinaria").ToString

                Catch ex As Exception
                End Try
                tabla1.Rows.Add(rowc1)
            Next

            ds.Tables.Add(encabezado)
            ds.Tables.Add(numeracion)
            Try
                '**Llenado del reporte
                Me.Cursor = Cursors.WaitCursor
                Dim OBJReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes

                If tabla.Rows.Count() <= 30 Then
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_TRJETA_DE_PRODUCCION")
                Else
                    EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_TARJETA_PRODUCCION_MAS30")
                End If

                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                    EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                Dim reporte As New StiReport
                'Dim ruta As String
                reporte.Load(archivo)
                reporte.Compile()
                'variables para el encabezado del reporte
                reporte("log") = Tools.Controles.ObtenerLogoNave(N)
                reporte("coleccion") = encabezado.Rows(0).Item("coleccion").ToString + " " + encabezado.Rows(0).Item("modelo").ToString
                reporte("programa") = fechaDias 'encabezado.Rows(0).Item("programa").ToString
                reporte("fecha") = dateValue.ToShortDateString
                reporte("lote") = encabezado.Rows(0).Item("lote").ToString
                reporte("corte") = encabezado.Rows(0).Item("corte").ToString
                reporte("horma") = encabezado.Rows(0).Item("horma").ToString
                reporte("suela") = encabezado.Rows(0).Item("suela").ToString
                reporte("corrida") = encabezado.Rows(0).Item("corrida").ToString
                reporte("cpiel") = encabezado.Rows(0).Item("cortador p").ToString
                reporte("dcm") = dcm.ToString
                reporte("dcmSint") = dcmSint.ToString
                reporte("cforro") = encabezado.Rows(0).Item("cortador f").ToString

                Dim tablaRuta As DataTable
                Try
                    tablaRuta = obj.ObtenerRutaID(encabezado.Rows(0).Item("clienteid").ToString)
                    If tablaRuta.Rows(0).Item(0) = 14 Then
                        reporte("internacional") = "FOLIO INTERNACIONAL"
                    Else
                        reporte("internacional") = ""
                    End If
                Catch ex As Exception
                    reporte("internacional") = ""
                End Try

                'Dim tablaTiempoTotal As DataTable
                ' tablaTiempoTotal = obj.ReporteTarjetaProduccionTotalTiempoFracciones(tiempo)
                'reporte("tiempo") = tablaTiempoTotal.Rows(0).Item(0)
                'reporte("tiempo") = tiempo.ToString.Replace(".", ":")
                reporte("tiempo") = tiempo.ToString()
                Dim y = Format(costo, " ##,##00.00")
                reporte("costo") = y.ToString

                reporte("cliente") = encabezado.Rows(0).Item("cliente t").ToString
                Dim imagen As String = "http://192.168.2.158/yuyinerp/" + encabezado.Rows(0).Item("imagen").ToString
                reporte("imagen") = imagen
                reporte("modelo") = encabezado.Rows(0).Item("modelo").ToString
                reporte("code") = codigoencabezado
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                'Variables para armar la numeración por corrida y los pares por cada una de las tallas
                reporte("n1") = numeracion.Rows(0).Item("1").ToString
                reporte("n2") = numeracion.Rows(0).Item("2").ToString
                reporte("n3") = numeracion.Rows(0).Item("3").ToString
                reporte("n4") = numeracion.Rows(0).Item("4").ToString
                reporte("n5") = numeracion.Rows(0).Item("5").ToString
                reporte("n6") = numeracion.Rows(0).Item("6").ToString
                reporte("n7") = numeracion.Rows(0).Item("7").ToString
                reporte("n8") = numeracion.Rows(0).Item("8").ToString
                reporte("n9") = numeracion.Rows(0).Item("9").ToString
                reporte("n10") = numeracion.Rows(0).Item("10").ToString
                reporte("n11") = numeracion.Rows(0).Item("11").ToString
                reporte("n12") = numeracion.Rows(0).Item("12").ToString
                reporte("n13") = numeracion.Rows(0).Item("13").ToString
                reporte("n14") = numeracion.Rows(0).Item("14").ToString
                reporte("n15") = numeracion.Rows(0).Item("15").ToString
                reporte("n16") = numeracion.Rows(0).Item("16").ToString
                reporte("t1") = numeracion.Rows(0).Item("t1").ToString
                reporte("t2") = numeracion.Rows(0).Item("t2").ToString
                reporte("t3") = numeracion.Rows(0).Item("t3").ToString
                reporte("t4") = numeracion.Rows(0).Item("t4").ToString
                reporte("t5") = numeracion.Rows(0).Item("t5").ToString
                reporte("t6") = numeracion.Rows(0).Item("t6").ToString
                reporte("t7") = numeracion.Rows(0).Item("t7").ToString
                reporte("t8") = numeracion.Rows(0).Item("t8").ToString
                reporte("t9") = numeracion.Rows(0).Item("t9").ToString
                reporte("t10") = numeracion.Rows(0).Item("t10").ToString
                reporte("t11") = numeracion.Rows(0).Item("t11").ToString
                reporte("t12") = numeracion.Rows(0).Item("t12").ToString
                reporte("t13") = numeracion.Rows(0).Item("t13").ToString
                reporte("t14") = numeracion.Rows(0).Item("t14").ToString
                reporte("t15") = numeracion.Rows(0).Item("t15").ToString
                reporte("t16") = numeracion.Rows(0).Item("t16").ToString
                'total de pares
                reporte("pares") = numeracion.Rows(0).Item("pares").ToString
                If encabezado.Rows(0).Item("cliente t").ToString.Contains("CONCENTRADO") = False Then
                    reporte("clientecodigo") = encabezado.Rows(0).Item("clientecodigo").ToString
                Else
                    reporte("clientecodigo") = ""
                End If
                reporte.RegData(tabla1)
                reporte.Dictionary.Clear()
                reporte.Dictionary.Synchronize()
                reporte.Render()

                '***Imprimir Reporte directamente sin mostrar previsualización
                'Dim PrinterSettings As PrinterSettings = New PrinterSettings()
                'PrinterSettings.Copies = 1
                'reporte.Print(False, PrinterSettings)
                '************

                'reporte.Show()

                For Each page As StiPage In reporte.CompiledReport.RenderedPages
                    page.Report = singleFile
                    page.NewGuid()
                    singleFile.RenderedPages.Add(page)
                Next

                '*********************
                Me.Cursor = Cursors.Default
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class