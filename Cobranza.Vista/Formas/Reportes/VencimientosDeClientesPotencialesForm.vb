Imports DevExpress.XtraGrid.Views.Base
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports ScrollBars = System.Windows.Forms.ScrollBars

Public Class VencimientosDeClientesPotencialesForm

    Dim dtReporte As DataTable

    Public Sub MostrarReporte()
        Dim objBU As New Cobranza.Negocios.VencimientosDeClientesPotencialesBU
        Dim dtReporte As DataTable
        Dim filtro As String = ""

        For Each row As UltraGridRow In grdClientes.Rows
            If filtro.Length > 0 Then
                filtro += ","
            End If
            filtro += row.Cells(2).Value.ToString
        Next

        Dim negocios As New Negocios.VencimientosDeClientesPotencialesBU
        Try
            Cursor = Cursors.WaitCursor
            dtReporte = objBU.VencimientosDeClientesPotenciales(filtro, dtpFechaFin.Value, chboxVencido.Checked)
            grdReporte.DataSource = dtReporte
            diseñoGridResultado()
            lblFechaUltimaActualización.Text = DateTime.Now
        Catch ex As Exception

            MsgBox(ex.Message)
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If grdClientes.Rows.Count > 0 Then
            MostrarReporte()
            btnArriba_Click(Nothing, Nothing)
        Else
            Dim ventana As New Tools.AdvertenciaForm
            ventana.mensaje = "Debe seleccionar por lo menos un cliente para mostrar el reporte"
            ventana.ShowDialog()
        End If
    End Sub


    Private Sub diseñoGridResultado()
        'Dim objBu As New Negocios.SeguimientoVentasBU
        Dim band As DevExpress.XtraGrid.Views.BandedGrid.GridBand
        Dim listBandsTextos As New List(Of String)
        Dim listBands As New List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)


        bgvReporte.OptionsView.AllowCellMerge = False
        'bgvReporte.OptionsView.ColumnAutoWidth = True
        bgvReporte.Appearance.FocusedRow.BackColor = Color.FromArgb(234, 232, 232)
        bgvReporte.Appearance.SelectedRow.BackColor = Color.FromArgb(234, 232, 232)
        bgvReporte.Appearance.SelectedRow.Options.UseBackColor = True
        bgvReporte.Appearance.FocusedRow.ForeColor = Color.Black
        bgvReporte.Appearance.SelectedRow.ForeColor = Color.Black
        bgvReporte.Appearance.SelectedRow.Options.UseForeColor = True
        bgvReporte.Columns.Clear()
        bgvReporte.Bands.Clear()

        grdReporte.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin
        grdReporte.LookAndFeel.UseDefaultLookAndFeel = False

        'Primer Nivel Cuatrimestre
        Dim ListaPrimerBanda As New List(Of String)
        ListaPrimerBanda.Add("FechaActualizacion")
        ListaPrimerBanda.Add("VENTAS")
        ListaPrimerBanda.Add("TRES")
        ListaPrimerBanda.Add("COBRANZA")
        ListaPrimerBanda.Add("CINCO")
        ListaPrimerBanda.Add("SALDOVENCIDO")
        ListaPrimerBanda.Add("SEIS")
        ListaPrimerBanda.Add("DEVOLUCIONES")

        Dim cadenas As String = ""

        For Each item As String In ListaPrimerBanda

            listBandsTextos.Add(item.Trim())
            band = bgvReporte.Bands.Add
            band.AppearanceHeader.BorderColor = Color.Gray
            band.AppearanceHeader.Options.UseBackColor = True
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            band.AppearanceHeader.Font = New System.Drawing.Font(band.AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
            band.AppearanceHeader.BackColor = Color.LightGray

            If item = "FechaActualizacion" Then
                'band.Caption = "Ultima Actualización " & Date.Now.ToShortDateString + " " + Date.Now.ToShortTimeString

            ElseIf item = "VENTAS" Then
                'band.AppearanceHeader.BackColor = Color.FromArgb(220, 230, 241)

                band.Caption = "Ventas"
            ElseIf item = "TRES" Then
                ' band.AppearanceHeader.BackColor = Color.FromArgb(255, 185, 170)
                band.Caption = ""
            ElseIf item = "COBRANZA" Then
                band.Caption = "Cobranza"
            ElseIf item = "CINCO" Then
                band.Caption = ""
            ElseIf item = "SALDOVENCIDO" Then
                band.Caption = "Saldo Vencido"
            ElseIf item = "SEIS" Then
                band.Caption = ""
            ElseIf item = "DEVOLUCIONES" Then
                band.Caption = "Devoluciones"
            End If

            listBands.Add(band)
        Next

        listBands(0).Fixed = Columns.FixedStyle.Left

        bgvReporte.Columns.AddField(("#").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("#").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("#").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName(("#")).Caption = ("N.")
        bgvReporte.Columns.ColumnByFieldName("#").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("#").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("#").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("#").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("clie_idsicy").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).Caption = ("ClienteSICYID")
        bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName(("clie_idsicy").ToString().ToUpper).AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("CLIENTE").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("CLIENTE").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("CLIENTE").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName(("CLIENTE")).Caption = ("Cliente")
        bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("CLASIFICACION").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("CLASIFICACION").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("CLASIFICACION").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName(("CLASIFICACION")).Caption = ("Clasificacion")
        bgvReporte.Columns.ColumnByFieldName("CLASIFICACION").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("CLASIFICACION").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("CLASIFICACION").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("AGENTE").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("AGENTE").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("AGENTE").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("AGENTE").Caption = ("Agente")
        bgvReporte.Columns.ColumnByFieldName("AGENTE").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("AGENTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("AGENTE").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("AGENTE").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("RAZONSOCIAL").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("RAZONSOCIAL").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("RAZONSOCIAL").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("RAZONSOCIAL").Caption = ("Razón Social")
        bgvReporte.Columns.ColumnByFieldName("RAZONSOCIAL").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("RAZONSOCIAL").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("RAZONSOCIAL").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("PLAZONORMAL").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("PLAZONORMAL").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("PLAZONORMAL").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("PLAZONORMAL").Caption = ("Plazo Normal")
        bgvReporte.Columns.ColumnByFieldName("PLAZONORMAL").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("PLAZONORMAL").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("PLAZONORMAL").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("SALDOINICIAL").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("SALDOINICIAL").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("SALDOINICIAL").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").Caption = ("Saldo Inicial")
        bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("LIMITECREDITO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("LIMITECREDITO").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("LIMITECREDITO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("LIMITECREDITO").Caption = ("Limite de Credito")
        bgvReporte.Columns.ColumnByFieldName("LIMITECREDITO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("LIMITECREDITO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("LIMITECREDITO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("LIMITECREDITO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("LIMITECREDITO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("BLOQUEADO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("BLOQUEADO").ToString().ToUpper).OwnerBand = listBands(0)
        bgvReporte.Columns.ColumnByFieldName(("BLOQUEADO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("BLOQUEADO").Caption = ("Bloqueado")
        bgvReporte.Columns.ColumnByFieldName("BLOQUEADO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("SALDOINICIAL").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("BLOQUEADO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("BLOQUEADO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("PARES").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("PARES").ToString().ToUpper).OwnerBand = listBands(1)
        bgvReporte.Columns.ColumnByFieldName(("PARES").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("PARES").Caption = ("Pares")
        bgvReporte.Columns.ColumnByFieldName("PARES").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("PARES").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("PARES").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("PARES").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("PARES").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("PARES").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("VENTASIMPORTE").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("VENTASIMPORTE").ToString().ToUpper).OwnerBand = listBands(1)
        bgvReporte.Columns.ColumnByFieldName(("VENTASIMPORTE").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").Caption = ("Importe")
        bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("VENTASIMPORTE").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("NOTASDECARGO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("NOTASDECARGO").ToString().ToUpper).OwnerBand = listBands(2)
        bgvReporte.Columns.ColumnByFieldName(("NOTASDECARGO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").Caption = ("Notas de Cargo")
        bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("NOTASDECARGO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("DEPOSITADO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("DEPOSITADO").ToString().ToUpper).OwnerBand = listBands(3)
        bgvReporte.Columns.ColumnByFieldName(("DEPOSITADO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").Caption = ("Depositado")
        bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("SEMANAL").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("SEMANAL").ToString().ToUpper).OwnerBand = listBands(3)
        bgvReporte.Columns.ColumnByFieldName(("SEMANAL").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("SEMANAL").Caption = ("Semanal")
        bgvReporte.Columns.ColumnByFieldName("SEMANAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("SEMANAL").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("SEMANAL").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("DEPOSITADO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("SEMANAL").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("SEMANAL").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("PLAZOPROMEDIO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("PLAZOPROMEDIO").ToString().ToUpper).OwnerBand = listBands(3)
        bgvReporte.Columns.ColumnByFieldName(("PLAZOPROMEDIO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIO").Caption = ("Plazo Promedio")
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("CLIENTE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIO").AppearanceHeader.BackColor = Color.LightGray


        bgvReporte.Columns.AddField(("NOTASDECREDITO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("NOTASDECREDITO").ToString().ToUpper).OwnerBand = listBands(4)
        bgvReporte.Columns.ColumnByFieldName(("NOTASDECREDITO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").Caption = ("Notas de Crédito")
        bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("NOTASDECREDITO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("CANCELACIONDEFACTURAS").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("CANCELACIONDEFACTURAS").ToString().ToUpper).OwnerBand = listBands(4)
        bgvReporte.Columns.ColumnByFieldName(("CANCELACIONDEFACTURAS").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").Caption = ("Cancelación de Facturas")
        bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("CANCELACIONDEFACTURAS").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("SALDOFINAL").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("SALDOFINAL").ToString().ToUpper).OwnerBand = listBands(4)
        bgvReporte.Columns.ColumnByFieldName(("SALDOFINAL").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").Caption = ("Saldo Final")
        bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("SALDOFINAL").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("SALDOVENCIDO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("SALDOVENCIDO").ToString().ToUpper).OwnerBand = listBands(5)
        bgvReporte.Columns.ColumnByFieldName(("SALDOVENCIDO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").Caption = ("Importe")
        bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("SALDOVENCIDO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("PORCENTAJE").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("PORCENTAJE").ToString().ToUpper).OwnerBand = listBands(5)
        bgvReporte.Columns.ColumnByFieldName(("PORCENTAJE").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").Caption = ("%")
        bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("PLAZOPROMEDIOVENCIDO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("PLAZOPROMEDIOVENCIDO").ToString().ToUpper).OwnerBand = listBands(5)
        bgvReporte.Columns.ColumnByFieldName(("PLAZOPROMEDIOVENCIDO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIOVENCIDO").Caption = ("Plazo Promedio Vencido")
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIOVENCIDO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIOVENCIDO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("PLAZOPROMEDIOVENCIDO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("PVT").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("PVT").ToString().ToUpper).OwnerBand = listBands(5)
        bgvReporte.Columns.ColumnByFieldName(("PVT").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("PVT").Caption = ("PVT")
        bgvReporte.Columns.ColumnByFieldName("PVT").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("PORCENTAJE").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("PVT").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("PVT").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("FECHADOCUMENTO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("FECHADOCUMENTO").ToString().ToUpper).OwnerBand = listBands(5)
        bgvReporte.Columns.ColumnByFieldName(("FECHADOCUMENTO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("FECHADOCUMENTO").Caption = ("Fecha Documento")
        bgvReporte.Columns.ColumnByFieldName("FECHADOCUMENTO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("FECHADOCUMENTO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("FECHADOCUMENTO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("FECHADOCUMENTO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("DESCUENTOS").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("DESCUENTOS").ToString().ToUpper).OwnerBand = listBands(6)
        bgvReporte.Columns.ColumnByFieldName(("DESCUENTOS").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").Caption = ("Descuentos")
        bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("DESCUENTOS").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("MAYOREO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("MAYOREO").ToString().ToUpper).OwnerBand = listBands(7)
        bgvReporte.Columns.ColumnByFieldName(("MAYOREO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("MAYOREO").Caption = ("Mayoreo")
        bgvReporte.Columns.ColumnByFieldName("MAYOREO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("MAYOREO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("MAYOREO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("MAYOREO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("MAYOREO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("MAYOREO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.Columns.AddField(("MENUDEO").ToString().ToUpper)
        bgvReporte.Columns.ColumnByFieldName(("MENUDEO").ToString().ToUpper).OwnerBand = listBands(7)
        bgvReporte.Columns.ColumnByFieldName(("MENUDEO").ToString().ToUpper).Visible = True
        bgvReporte.Columns.ColumnByFieldName("MENUDEO").Caption = ("Menudeo")
        bgvReporte.Columns.ColumnByFieldName("MENUDEO").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        bgvReporte.Columns.ColumnByFieldName("MENUDEO").DisplayFormat.FormatString = "N0"
        bgvReporte.Columns.ColumnByFieldName("MENUDEO").AppearanceHeader.Font = New System.Drawing.Font(bgvReporte.Columns.ColumnByFieldName("MENUDEO").AppearanceHeader.Font, System.Drawing.FontStyle.Bold)
        bgvReporte.Columns.ColumnByFieldName("MENUDEO").AppearanceHeader.BorderColor = Color.Gray
        bgvReporte.Columns.ColumnByFieldName("MENUDEO").AppearanceHeader.BackColor = Color.LightGray

        bgvReporte.RowHeight = 35

        bgvReporte.BestFitColumns()

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            bgvReporte.Columns.ColumnByFieldName(col.FieldName).OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        Next

        bgvReporte.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(bgvReporte.Columns("SALDOINICIAL").Summary.FirstOrDefault(Function(x) x.FieldName = "SALDOINICIAL")) = True Then
            bgvReporte.Columns("SALDOINICIAL").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SALDOINICIAL", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "SALDOINICIAL"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("PARES").Summary.FirstOrDefault(Function(x) x.FieldName = "PARES")) = True Then
            bgvReporte.Columns("PARES").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PARES", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "PARES"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If


        If IsNothing(bgvReporte.Columns("VENTASIMPORTE").Summary.FirstOrDefault(Function(x) x.FieldName = "VENTASIMPORTE")) = True Then
            bgvReporte.Columns("VENTASIMPORTE").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "VENTASIMPORTE", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "VENTASIMPORTE"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If



        If IsNothing(bgvReporte.Columns("NOTASDECARGO").Summary.FirstOrDefault(Function(x) x.FieldName = "NOTASDECARGO")) = True Then
            bgvReporte.Columns("NOTASDECARGO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "NOTASDECARGO", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "NOTASDECARGO"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("DEPOSITADO").Summary.FirstOrDefault(Function(x) x.FieldName = "DEPOSITADO")) = True Then
            bgvReporte.Columns("DEPOSITADO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DEPOSITADO", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DEPOSITADO"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("NOTASDECREDITO").Summary.FirstOrDefault(Function(x) x.FieldName = "NOTASDECREDITO")) = True Then
            bgvReporte.Columns("NOTASDECREDITO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "NOTASDECREDITO", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "NOTASDECREDITO"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("CANCELACIONDEFACTURAS").Summary.FirstOrDefault(Function(x) x.FieldName = "CANCELACIONDEFACTURAS")) = True Then
            bgvReporte.Columns("CANCELACIONDEFACTURAS").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "CANCELACIONDEFACTURAS", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "CANCELACIONDEFACTURAS"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("SALDOFINAL").Summary.FirstOrDefault(Function(x) x.FieldName = "SALDOFINAL")) = True Then
            bgvReporte.Columns("SALDOFINAL").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SALDOFINAL", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "SALDOFINAL"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("SALDOVENCIDO").Summary.FirstOrDefault(Function(x) x.FieldName = "SALDOVENCIDO")) = True Then
            bgvReporte.Columns("SALDOVENCIDO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "SALDOVENCIDO", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "SALDOVENCIDO"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If




        If IsNothing(bgvReporte.Columns("DESCUENTOS").Summary.FirstOrDefault(Function(x) x.FieldName = "DESCUENTOS")) = True Then
            bgvReporte.Columns("DESCUENTOS").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "DESCUENTOS", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "DESCUENTOS"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("MAYOREO").Summary.FirstOrDefault(Function(x) x.FieldName = "MAYOREO")) = True Then
            bgvReporte.Columns("MAYOREO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MAYOREO", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "MAYOREO"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)
        End If

        If IsNothing(bgvReporte.Columns("MENUDEO").Summary.FirstOrDefault(Function(x) x.FieldName = "MENUDEO")) = True Then
            bgvReporte.Columns("MENUDEO").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "MENUDEO", "{0:N0}")
            ' Create and setup the first summary item.
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "MENUDEO"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            bgvReporte.GroupSummary.Add(item)

        End If

        For Each Col As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In bgvReporte.Columns
            Dim titulo As String = Col.Caption
            If titulo = "Notas de Cargo" Or titulo = "Pares" Or titulo = "Importe" Or titulo = "Plazo Normal" Or titulo = "Plazo Promedio" Then
                Col.Width = 80
            ElseIf titulo = "Cancelación de Facturas" Or titulo = "Saldo Final" Then
                Col.Width = 100
            ElseIf titulo = "Razón Social" Then
                Col.Width = 60
            ElseIf titulo = "Plazo Promedio Vencido" Then
                Col.Width = 90
            End If

        Next

        'Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(bgvReporte)

        'bgvReporte.OptionsView.RowAutoHeight = True

    End Sub

    Private Sub bgvReporte_CustomDrawFooterCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles bgvReporte.CustomDrawFooterCell
        e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)
        e.Graphics.FillRectangle(Brushes.Azure, e.Bounds)
        e.Appearance.DrawString(e.Cache, e.Info.DisplayText, e.Bounds)
        e.Handled = True
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If bgvReporte.DataRowCount > 0 Then

            Dim fbdUbicacionArchivo As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty
            Dim nombreReporteParaExportacion As String = String.Empty
            ' Dim objBU As New Negocios.EstadisticoPedidosBU
            Dim exportOptions = New XlsxExportOptionsEx()

            exportOptions.ExportType = DevExpress.Export.ExportType.DataAware

            Try

                nombreReporte = "\Vencimiento_Clientes_Potenciales"
                nombreReporteParaExportacion = "VENCIMIENTO CLIENTES POTENCIALES"
                exportOptions.SheetName = "VencimientoClientesPotenciales"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvReporte.GroupCount > 0 Then
                            bgvReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            grdReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                            'grdReporte.ExportToXlsx()

                        End If

                        'show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        Controles.Mensajes_Y_Alertas("EXITO", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()

                        'objBU.bitacoraExportacionExcel(Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, "EXCEL", "SAY", nombreReporteParaExportacion, dtpFechaEntregaDel.Value.ToShortDateString(), dtpFechaEntregaAl.Value.ToShortDateString())

                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If



                End With
            Catch ex As Exception
                Controles.Mensajes_Y_Alertas("ERROR", ex.Message.ToString())
            End Try
        Else
            Controles.Mensajes_Y_Alertas("INFORMACION", "No hay datos para exportar. " + vbCrLf + "Asegúrese de haber dado clic en el botón 'MOSTRAR' antes de exportar el reporte")

        End If
    End Sub

    Private Sub VencimientosDeClientesPotenciales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        dtpFechaFin.MaxDate = Date.Now
        dtpFechaFin.Value = "31/12/" + Date.Now.AddYears(-1).Year.ToString
    End Sub
    Private Sub bgvReporte_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvReporte.CustomDrawCell
        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "SALDOINICIAL" Then
                e.Appearance.BackColor = Color.FromArgb(234, 232, 232)
            End If
        End If

        If e.RowHandle >= 0 Then
            If e.Column.FieldName = "SALDOFINAL" Then
                e.Appearance.BackColor = Color.FromArgb(234, 232, 232)
            End If
        End If

        If e.Column.FieldName = "SALDOINICIAL" Then
            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)

        End If

        If e.Column.FieldName = "SALDOFINAL" Then
            e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Bold)
        End If

    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        'Dim EstatusID As Integer = grdVentas.GetRowCellValue(e.RowHandle, "EstatusID")
        'Dim Bloqueado As String = grdVentas.GetRowCellValue(e.RowHandle, "BE")
        'Dim TotalErrores As Integer = 0
        'Dim TotalIncidencias As Integer = 0
        'Dim index As Integer = 0
        Try


            If e.RowHandle >= 0 Then
                If e.ColumnFieldName = "SALDOINICIAL" Then
                    e.Formatting.BackColor = Color.FromArgb(234, 232, 232)
                    e.Formatting.Font.Bold = True
                End If
            End If

            If e.RowHandle >= 0 Then
                If e.ColumnFieldName = "SALDOFINAL" Then
                    e.Formatting.BackColor = Color.FromArgb(234, 232, 232)
                    e.Formatting.Font.Bold = True
                End If
            End If

            '    If EstatusID = 130 Then
            '        e.Formatting.BackColor = pnlEstatusRechazada.BackColor
            '    ElseIf Bloqueado = "SI" Then
            '        e.Formatting.BackColor = Color.Salmon
            '    Else
            '        'If e.ColumnFieldName = "ColorEstatus" Then
            '        '    e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

            '        'End If
            '    End If

            '    If e.ColumnFieldName = "ColorEstatus" Then
            '        e.Formatting.BackColor = ObtenerColorStatusOT(grdVentas.GetRowCellValue(e.RowHandle, "EstatusID"))

            '    End If

            '    If TipoPerfil = 2 Then

            '        If chkDetallada.Checked = False Then
            '            If e.ColumnFieldName = "TotalErrores" Then
            '                TotalErrores = grdVentas.GetRowCellValue(e.RowHandle, "TotalErrores")
            '                If TotalErrores > 0 Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Black
            '                End If
            '            End If
            '        End If



            '        If e.ColumnFieldName = "TotalIncidencias" Then
            '            TotalIncidencias = grdVentas.GetRowCellValue(e.RowHandle, "TotalIncidencias")

            '            If TotalIncidencias > 0 Then
            '                e.Formatting.Font.Color = Color.Red
            '            Else
            '                e.Formatting.Font.Color = Color.Black
            '            End If
            '        End If

            '        If e.ColumnFieldName = "FechaValidoAlmacen" Then
            '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
            '                If EstatusID = "129" Or EstatusID = "130" Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Green
            '                End If
            '            End If

            '        End If

            '        If e.ColumnFieldName = "UsuarioValidoAlmacen" Then
            '            If IsDBNull(grdVentas.GetRowCellValue(e.RowHandle, "UsuarioValidoAlmacen")) = False Then
            '                If EstatusID = "129" Or EstatusID = "130" Then
            '                    e.Formatting.Font.Color = Color.Red
            '                Else
            '                    e.Formatting.Font.Color = Color.Green
            '                End If
            '            End If

            '        End If


            '    End If

        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("Error", ex.Message.ToString())
        End Try



        e.Handled = True
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 206
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportes

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(2).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.StartPosition = FormStartPosition.CenterScreen
        listado.ShowDialog(Me)

        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listaParametros

        grdClientes.DisplayLayout.Bands(0).Columns(3).Header.Caption = "Cliente"

    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdClientes.DataSource = Nothing
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        With grdClientes.DisplayLayout
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.False
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single

            .Bands(0).ColHeaderLines = 2

            .Override.AllowAddNew = AllowAddNew.No
            .Scrollbars = ScrollBars.Vertical

            .Bands(0).Columns("IdSAY").Hidden = True
            .Bands(0).Columns("IdSICY").Hidden = True
            .Bands(0).Columns("Activo").Hidden = True
            .Bands(0).Columns(" ").Hidden = True
        End With
    End Sub

    Private Sub grdClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub
End Class