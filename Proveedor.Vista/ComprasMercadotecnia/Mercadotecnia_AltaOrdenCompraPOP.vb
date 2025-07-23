Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU
Imports Stimulsoft.Report
Imports Tools

Public Class Mercadotecnia_AltaOrdenCompraPOP
    Dim advertencia As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim confirmar As New ConfirmarForm
    Public Cliente As String
    Public MotivoSolicitud As String
    Public Estatus As String
    Public Observaciones As String
    Public Consultar As Integer
    Public SolicitudOrdenCompra As Integer
    Dim Actualizar As Integer = 0

    Private Sub Mercadotecnia_AltaOrdenCompraPOP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Consultar = 1 Then

            'llenarComboClientes()
            cmbCliente.Text = Cliente
            cmbCliente.Enabled = False

            txtMotivoSolicitud.Text = MotivoSolicitud
            txtMotivoSolicitud.Enabled = False

            txtObservaciones.Text = Observaciones
            txtObservaciones.Enabled = False
            'llenarComboEstatus()

            cmbEstatus.Text = Estatus
            cmbEstatus.Enabled = False

            cargaGridDetalle()

            btnBuscar.Enabled = False
            btnLimpiar.Enabled = False
            btnGuardar.Enabled = False

            txtMaterial.Enabled = False

            Me.grdSolicitudPOP.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect


        ElseIf Consultar = 2 Then

            llenarComboClientes()
            cmbCliente.Text = Cliente


            txtMotivoSolicitud.Text = MotivoSolicitud
            txtMotivoSolicitud.Enabled = False

            txtObservaciones.Text = Observaciones

            llenarComboEstatus()

            cmbEstatus.Text = Estatus


            cargaGridDetalle()
            Actualizar = 1

            For Each row In grdSolicitudPOP.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next


        Else
            SolicitudOrdenCompra = 0
            llenarComboClientes()
            llenarComboEstatus()
        End If




    End Sub

    Public Sub llenarComboClientes()
        Dim objBU As New MercadotecniaBU
        Dim dtClientes As New DataTable
        dtClientes = objBU.llenarComboClientes()
        dtClientes.Rows.InsertAt(dtClientes.NewRow, 0)
        cmbCliente.DataSource = dtClientes
        cmbCliente.DisplayMember = "Cliente"
        cmbCliente.ValueMember = "ClienteID"
    End Sub

    Public Sub llenarComboEstatus()
        Dim objBU As New MercadotecniaBU
        Dim dtEstatus As New DataTable
        dtEstatus = objBU.llenarComboEstatus()
        dtEstatus.Rows.InsertAt(dtEstatus.NewRow, 0)
        cmbEstatus.DataSource = dtEstatus
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "EstatusID"
    End Sub

    Public Sub cargaGridDetalle()
        Dim objBU As New MercadotecniaBU
        Dim dtObtieneDetalleCompra As New DataTable

        dtObtieneDetalleCompra = objBU.ObtieneOrdenesCompraDetalle(SolicitudOrdenCompra)

        grdSolicitudPOP.DataSource = dtObtieneDetalleCompra
        DiseñoGrid()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        GuardarSolicitudPOP()

    End Sub

    Public Sub GuardarSolicitudPOP()
        Dim objBU As New MercadotecniaBU
        Dim dtSolicitudesPOP As New DataTable
        Dim dtInsertarEncabezado As New DataTable
        Dim usuarioCreo As Integer
        Dim ClienteID As Integer
        Dim Observaciones As String
        Dim MotivoSolicitud As String
        Dim EstatusID As Integer
        Dim TotalGrid As Double = 0
        ' Dim SolicitudID As Integer = 0

        Try

            usuarioCreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

            If cmbCliente.SelectedIndex <> 0 Then
                ClienteID = cmbCliente.SelectedValue
            Else
                advertencia.mensaje = "Seleccione un Cliente de la Lista."
                advertencia.ShowDialog()
            End If

            If txtObservaciones.Text <> "" Then
                Observaciones = txtObservaciones.Text
            Else
                Observaciones = ""
            End If

            If txtMotivoSolicitud.Text <> "" Then
                MotivoSolicitud = txtMotivoSolicitud.Text
            Else
                MotivoSolicitud = ""
            End If

            If cmbEstatus.SelectedIndex <> 0 Then
                EstatusID = cmbEstatus.SelectedValue
            Else
                advertencia.mensaje = "Seleccione un Estatus para la Solcitud."
                advertencia.ShowDialog()
            End If

            confirmar.mensaje = "¿Está seguro de actualizar la información?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor

                For Each row As UltraGridRow In grdSolicitudPOP.Rows
                    If CBool(row.Cells(" ").Value) = True Then
                        TotalGrid += row.Cells("Total").Value
                    End If
                Next


                dtInsertarEncabezado = objBU.InsertarEncabezadoOrdenCompra(ClienteID, MotivoSolicitud, EstatusID, Observaciones, usuarioCreo, TotalGrid, SolicitudOrdenCompra)

                For Each row As DataRow In dtInsertarEncabezado.Rows
                    SolicitudOrdenCompra = dtInsertarEncabezado.Rows(0).Item(0)
                Next

                Dim VXmlCeldas As XElement = New XElement("Celdas")
                For Each rowGrd As UltraGridRow In grdSolicitudPOP.Rows
                    If CBool(rowGrd.Cells(" ").Value) = True Then
                        Dim vNodo As XElement = New XElement("Celda")

                        vNodo.Add(New XAttribute("PSolicitudID", SolicitudOrdenCompra))
                        vNodo.Add(New XAttribute("PMaterialID", rowGrd.Cells(1).Value))
                        vNodo.Add(New XAttribute("PCantidad", rowGrd.Cells(6).Value))
                        vNodo.Add(New XAttribute("PUnidadID", rowGrd.Cells(8).Value))
                        vNodo.Add(New XAttribute("PPrecio", rowGrd.Cells(5).Value))
                        vNodo.Add(New XAttribute("PTotal", rowGrd.Cells(7).Value))
                        vNodo.Add(New XAttribute("PActualizar", Actualizar))

                        VXmlCeldas.Add(vNodo)
                    End If
                Next

                dtSolicitudesPOP = objBU.GuardarSolicitudesPOP(VXmlCeldas.ToString())
                exito.mensaje = "Se realizaron las acciones con éxito."
                exito.ShowDialog()
            Else
                advertencia.mensaje = "Se canceló la actualización de los datos."
                advertencia.ShowDialog()
            End If
            Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception

        End Try


    End Sub

    'Public Sub ImprimirReciboEntrega()

    '    Try
    '        Dim objBU As New MercadotecniaBU
    '        Dim dtDetalleRecibo As New DataTable

    '        Dim dtEncabezadoReporte As New DataTable

    '        dtEncabezadoReporte = objBU.ObtieneEncabezadoReporte(SolicitudOrdenCompra, 1)
    '        dtDetalleRecibo = objBU.ObtieneEncabezadoReporte(SolicitudOrdenCompra, 2)

    '        If dtEncabezadoReporte.Rows.Count > 0 And dtDetalleRecibo.Rows.Count > 0 Then


    '            Dim objReporte As New Framework.Negocios.ReportesBU
    '            Dim entReporte As New Entidades.Reportes
    '            Dim dsReciboSalida As New DataSet("dsReciboSalidaEncabezado")

    '            dtEncabezadoReporte.TableName = "dtDetalleReciboEncabezado"
    '            dtDetalleRecibo.TableName = "dtDetallesPOP"
    '            dsReciboSalida.Tables.Add(dtEncabezadoReporte)
    '            dsReciboSalida.Tables.Add(dtDetalleRecibo)

    '            entReporte = objReporte.LeerReporteporClave("REC_POP_MERCA")
    '            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
    '            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)
    '            Dim reporte As New StiReport



    '            reporte.Load(archivo)
    '            reporte.Compile()
    '            reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserNombreReal.ToString.ToUpper
    '            reporte.Dictionary.Clear()
    '            reporte.RegData(dsReciboSalida)
    '            reporte.Dictionary.Synchronize()
    '            reporte.Show()
    '        Else
    '            advertencia.mensaje = "No hay datos para mostrar."
    '            advertencia.ShowDialog()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub btnCncelar_Click(sender As Object, e As EventArgs) Handles btnCncelar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        grdSolicitudPOP.DataSource = Nothing


        Try

            Dim dtMaterialesPOP As New DataTable
            Dim objBU As New MercadotecniaBU
            Dim Material As String = ""

            If txtMaterial.Text <> "" Then
                Material = txtMaterial.Text
            Else
                Material = " "
            End If

            dtMaterialesPOP = objBU.llenarGridMaterialesPOP(Material)

            If dtMaterialesPOP.Rows.Count > 0 Then
                grdSolicitudPOP.DataSource = dtMaterialesPOP
                DiseñoGrid()
            Else
                advertencia.mensaje = "No hay datos de mostrar."
                advertencia.ShowDialog()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Public Sub DiseñoGrid()
        With grdSolicitudPOP.DisplayLayout.Bands(0)
            .Columns("MaterialID").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("UnidadMedida").CellActivation = Activation.NoEdit
            .Columns("Precio").CellActivation = Activation.NoEdit

            If Consultar <> 1 And Consultar <> 2 Then
                .Columns("Existencia").CellActivation = Activation.NoEdit
                .Columns("Existencia").Header.Caption = "Existencia Inicial"
            End If



            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals


            .Columns("UnidadID").Hidden = True
            .Columns("MaterialID").Hidden = True
            .Columns("UnidadMedida").Header.Caption = "Unidad"


            .Columns("Precio").Format = "###,###,##0"

            Dim sumTotalImportes As SummarySettings = grdSolicitudPOP.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudPOP.DisplayLayout.Bands(0).Columns("Total"))
            sumTotalImportes.DisplayFormat = "{0:#,##0}"
            sumTotalImportes.Appearance.TextHAlign = HAlign.Right
            sumTotalImportes.Appearance.BackColor = Color.Salmon
            grdSolicitudPOP.DisplayLayout.Bands(0).SummaryFooterCaption = "Total"

            Dim sumTotalCantidad As SummarySettings = grdSolicitudPOP.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdSolicitudPOP.DisplayLayout.Bands(0).Columns("Cantidad"))
            sumTotalCantidad.DisplayFormat = "{0:#,##0}"
            sumTotalCantidad.Appearance.TextHAlign = HAlign.Right
            sumTotalCantidad.Appearance.BackColor = Color.GreenYellow
            grdSolicitudPOP.DisplayLayout.Bands(0).SummaryFooterCaption = "Cantidad"

        End With

        grdSolicitudPOP.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSolicitudPOP.DisplayLayout.Override.RowSelectorWidth = 20
        grdSolicitudPOP.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdSolicitudPOP.Rows(0).Selected = True
        grdSolicitudPOP.DisplayLayout.Bands(0).Columns(" ").Width = 40
        grdSolicitudPOP.DisplayLayout.Bands(0).Columns("Material").Width = 200
        grdSolicitudPOP.DisplayLayout.Bands(0).Columns("UnidadMedida").Width = 80
        grdSolicitudPOP.DisplayLayout.Bands(0).Columns("Precio").Width = 100
        grdSolicitudPOP.DisplayLayout.Bands(0).Columns("Cantidad").Width = 100
        grdSolicitudPOP.DisplayLayout.Bands(0).Columns("Total").Width = 100



    End Sub

    Private Sub grdSolicitudPOP_CellChange(sender As Object, e As CellEventArgs) Handles grdSolicitudPOP.CellChange
        Dim Total As Double = 0
        Dim Cantidad As Double = 0
        Dim Precio As Double = 0

        If e.Cell.Column.Key = " " And e.Cell.Row.Index <> grdSolicitudPOP.Rows.FilterRow.Index Then
            Dim contadorSeleccion As Int32 = 0
            For Each rowGR As UltraGridRow In grdSolicitudPOP.Rows
                If CBool(rowGR.Cells(" ").Text) = True Then
                    contadorSeleccion += 1
                End If
            Next
            lblTotalSeleccionados.Text = contadorSeleccion.ToString("N0")
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        If chboxSeleccionarTodo.Checked Then
            For Each row In grdSolicitudPOP.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdSolicitudPOP.Rows.GetFilteredInNonGroupByRows
                row.Cells(" ").Value = False
            Next
        End If

        Dim marcados As Integer
        For Each row As UltraGridRow In grdSolicitudPOP.Rows
            If CBool(row.Cells(" ").Value) Then
                marcados += 1
            End If
        Next
        lblTotalSeleccionados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub grdSolicitudPOP_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles grdSolicitudPOP.KeyUp
        If e.KeyCode = Keys.Enter Then
            If grdSolicitudPOP.ActiveRow.Cells("Material").Text <> "" Then
                Dim contador = 0
                For value = 0 To grdSolicitudPOP.Rows.Count - 1
                    If grdSolicitudPOP.Rows(value).Cells("Material").Text = "" Then
                        contador = 1
                    End If
                Next
                grdSolicitudPOP.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdSolicitudPOP.DisplayLayout.Bands(0)
                If grdSolicitudPOP.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdSolicitudPOP.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdSolicitudPOP.ActiveCell = nextRow.Cells(grdSolicitudPOP.ActiveCell.Column)
                    e.Handled = True
                    grdSolicitudPOP.ActiveCell = grdSolicitudPOP.ActiveRow.Cells("Material")
                    grdSolicitudPOP.PerformAction(UltraGridAction.EnterEditMode, True, True)
                    ActualizarTotalMaterialSeleccionado()
                End If

            End If
        End If
    End Sub

    Public Sub ActualizarTotalMaterialSeleccionado()
        Try
            If grdSolicitudPOP.ActiveCell.Column.ToString = "Cantidad" Or grdSolicitudPOP.ActiveCell.Column.ToString = "Material" Then
                Dim Precio = grdSolicitudPOP.ActiveRow.Cells("Precio").Value
                Dim Cantidad = grdSolicitudPOP.ActiveRow.Cells("Cantidad").Value
                Dim Total = Precio * Cantidad
                grdSolicitudPOP.ActiveRow.Cells("Total").Value = Total
                grdSolicitudPOP.ActiveRow.Cells("Total").Column.Format = " ##,##0.00"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSolicitudPOP_AfterExitEditMode(sender As Object, e As EventArgs) Handles grdSolicitudPOP.AfterExitEditMode
        ActualizarTotalMaterialSeleccionado()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtMaterial.Text = ""
        txtMotivoSolicitud.Text = ""
        txtObservaciones.Text = ""

        grdSolicitudPOP.DataSource = Nothing

    End Sub
End Class