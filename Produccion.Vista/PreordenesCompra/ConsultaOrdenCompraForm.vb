Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports System.Net
Imports Stimulsoft.Report.Components
Imports System.Drawing.Printing
Imports Tools

Public Class ConsultaOrdenCompraForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim tablaDatosNave As New DataTable
    Dim tablaOrdenCompra As New DataTable
    Dim TablaOrdenDeCompraDetalle As New DataTable

    Private Sub ConsultaOrdenCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        LlenarListasNaves()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cbxNave.SelectedValue = 0
    End Sub

    Public Sub LlenarListasNaves()
        cbxNave = Tools.Controles.ComboNavesSegunUsuario(cbxNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New PreordenCompraBU
        Dim OrdenesDeCompra As New DataTable

        'OrdenesDeCompra = obj.ConsultaOrdenCompra(cbxNave.SelectedValue, dtpPrograma.Value.ToShortDateString)
        grdOrdenCompra.DataSource = OrdenesDeCompra
        diseñoGrid()
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        Dim form As New DetalleOrdenDeCompraForm

        Dim contador = 0
        For value = 0 To grdOrdenCompra.Rows.Count - 1
            If grdOrdenCompra.Rows(value).Cells(" ").Value = 1 Then
                contador = contador + 1
            End If
        Next
        If contador = 0 Then
            objAdvertencia.mensaje = "Selecione una orden de compra"
            objAdvertencia.ShowDialog()
        ElseIf contador > 1 Then
            objAdvertencia.mensaje = "Solo puede seleccionar una orden de compra"
            objAdvertencia.ShowDialog()
        Else

            For value2 = 0 To grdOrdenCompra.Rows.Count - 1
                If grdOrdenCompra.Rows(value2).Cells(" ").Value = 1 Then
                    form.proveedor = grdOrdenCompra.Rows(value2).Cells("Idp").Value
                    form.nave = cbxNave.SelectedValue
                    form.OrdenCompra = grdOrdenCompra.Rows(value2).Cells("Idoc").Value
                    form.ShowDialog()
                End If
            Next
        End If

    End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor

        Dim band As UltraGridBand = Me.grdOrdenCompra.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdOrdenCompra.DisplayLayout.Bands(0)
            .Columns(" ").Width = 5
            .Columns("Orden").Width = 20
            .Columns("Proveedor").Width = 80
            .Columns("Fecha Entrega").Width = 20
            .Columns("Tipo Orden").Width = 20
            .Columns("Prioridad").Width = 20
            .Columns("Descuento").Width = 20
            .Columns("Observación").Width = 100
            .Columns("Numero Materiales").Width = 20
            .Columns("Total Pre Orden").Width = 30

            .Columns("Fecha Entrega").Header.Caption = "Fecha" & vbCrLf & "Entrega"
            .Columns("Tipo Orden").Header.Caption = "Tipo" & vbCrLf & "Orden"
            .Columns("Total Pre Orden").Header.Caption = "Total" & vbCrLf & "Orden"
            .Columns("Numero Materiales").Header.Caption = "Numero" & vbCrLf & "Materiales"

            .Columns("Estatus").Hidden = True
            .Columns("Idoc").Hidden = True
            .Columns("Idp").Hidden = True

            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Descuento").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Numero Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Pre Orden").CellAppearance.TextHAlign = HAlign.Right


            .Columns("Orden").CellActivation = Activation.NoEdit
            .Columns("Fecha Entrega").CellActivation = Activation.NoEdit
            .Columns("Observación").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Tipo Orden").CellActivation = Activation.NoEdit
            .Columns("Numero Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Pre Orden").CellActivation = Activation.NoEdit

            .Columns(" ").CellActivation = Activation.AllowEdit

            .Columns("Descuento").Format = "##,##0.00"
            .Columns("Total Pre Orden").Format = "##,##0.00"

            .Columns(" ").CellAppearance.FontData.Bold = DefaultableBoolean.False

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

        End With
        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim obj As New PreordenCompraBU
        Dim Ordenid As Integer
        Dim contador = 0

        tablaOrdenCompra = Nothing
        TablaOrdenDeCompraDetalle = Nothing

        For value = 0 To grdOrdenCompra.Rows.Count - 1
            If grdOrdenCompra.Rows(value).Cells(" ").Value = 1 Then
                contador = contador + 1
            End If
        Next

        If contador = 0 Then
            objAdvertencia.mensaje = "Selecione una orden de compra"
            objAdvertencia.ShowDialog()
        ElseIf contador > 1 Then
            objAdvertencia.mensaje = "Solo puede imprimir una orden de compra"
            objAdvertencia.ShowDialog()
        Else
            For value = 0 To grdOrdenCompra.Rows.Count - 1
                Ordenid = grdOrdenCompra.Rows(0).Cells("Idoc").Value
                tablaOrdenCompra = obj.ConsultarOrdenCompleta(Ordenid)
                TablaOrdenDeCompraDetalle = obj.ConsultarOrdenCompletaDetalle(Ordenid)
                tablaDatosNave = obj.ConsultarDatosNave(cbxNave.SelectedValue)
                CrearReporte()
            Next
        End If

    End Sub

    Public Sub CrearReporte()
        Dim subtotal As Double = 0
        Dim iva As Double = 0
        Dim total As Double = 0
        Dim descuento As Double = 0

        For value = 0 To TablaOrdenDeCompraDetalle.Rows.Count - 1
            subtotal += TablaOrdenDeCompraDetalle.Rows(value).Item("Importe")
        Next

        iva = subtotal * 0.16
        total = iva + subtotal

        Try
            descuento = tablaOrdenCompra.Rows(0).Item("Descuento")
            descuento = descuento * total
        Catch ex As Exception
        End Try

        total = total - descuento

        '*********************************************************************************************************************
        '' Dar formato a la fecha
        Dim dateValue As Date = dtpPrograma.Value.ToShortDateString
        Dim DAY = dateValue.DayOfWeek()
        Dim NUMEROMES = dateValue.Month()
        Dim dia As String = ""
        Dim mes As String = ""
        Dim fechaDias As String = ""
        Dim Logo As String = ""
        Logo = Tools.Controles.ObtenerLogoNave(cbxNave.SelectedValue)

        Select Case DAY
            Case 1
                dia = "Lunes"
            Case 2
                dia = "Martes"
            Case 3
                dia = "Miercoles"
            Case 4
                dia = "Jueves"
            Case 5
                dia = "Viernes"
            Case 6
                dia = "Sabado"
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

        '********************************Creación de reporte
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor
            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDEN_DE_COMPRA_EXPLOSION")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            'Dim ruta As String
            reporte.Load(archivo)
            reporte.Compile()
            reporte("log") = Logo
            reporte("fecha") = fechaDias
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("cadenacomercial") = tablaOrdenCompra.Rows(0).Item("Cadena comercial")
            reporte("proveedor") = tablaOrdenCompra.Rows(0).Item("Proveedor")
            reporte("telefono") = ""
            reporte("fechaprograma") = tablaOrdenCompra.Rows(0).Item("Fecha programa")
            reporte("fechaentrega") = tablaOrdenCompra.Rows(0).Item("Fecha entrega")
            reporte("urgencia") = tablaOrdenCompra.Rows(0).Item("prioridad")
            reporte("observacion") = tablaOrdenCompra.Rows(0).Item("Observacion")
            reporte("descuento") = tablaOrdenCompra.Rows(0).Item("Descuento")
            reporte("subtotal") = Format(subtotal, "##,##0.00")
            reporte("total") = Format(total, "##,##0.00")
            reporte("iva") = Format(iva, "##,##0.00")
            reporte("nave") = tablaDatosNave.Rows(0).Item("Nave")
            reporte("colonia") = tablaDatosNave.Rows(0).Item("Colonia")
            reporte("domicilio") = tablaDatosNave.Rows(0).Item("CaLLE")
            reporte("telnave") = ""
            reporte("cp") = tablaDatosNave.Rows(0).Item("CP")
            reporte("numeroorden") = tablaOrdenCompra.Rows(0).Item("Idoc")
            reporte.RegData(TablaOrdenDeCompraDetalle)
            reporte.Show()
            '*********************
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        '********************************Fin de creación de reporte
    End Sub

End Class