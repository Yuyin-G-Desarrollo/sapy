Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Tools
Imports Entidades

Public Class AsignarDevolucionesForm
    Public idComprobante As Integer = 0
    Public fechaInicio As Date
    Public fechaFin As Date
    Public idNave As Integer = 0
    Public totalRemision As Double = 0
    Public totalFinal As Double = 0
    Dim datosComprobante As DataTable
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim estatusM As Boolean = False

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub AsignarDevolucionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
        getDatosComprobante()
    End Sub
    Private Sub getDatosComprobante()
        Dim obj As New DevolucionBU
        datosComprobante = obj.getDatosComprobante(idComprobante)
        For Each row As DataRow In datosComprobante.Rows
            lblTotalRem.Text = "$ " & Format(row("maco_total"), "##,##0.#0")
            lblNuevoTotal.Text = "$ " & Format(row("maco_total"), "##,##0.#0")
            lblNaves.Text = "" & row("Nave")
            lblFolio.Text = "" & row("maco_folio")
            lblFecha.Text = "" & Format(row("maco_fecha"), "dd/MM/yyyy")
            totalRemision = row("maco_total")
        Next
        totalFinal = CDbl(lblTotalRem.Text)
    End Sub
    Private Sub llenarGrid()
        Dim obj As New DevolucionBU
        grdDevoluciones.DataSource = obj.getDevoluciones(fechaInicio, fechaFin, idNave, False)
        disenioGrid()
    End Sub
    Public Sub disenioGrid()
        Try
            With grdDevoluciones.DisplayLayout.Bands(0)
                .Columns("seleccionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("seleccionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("seleccionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("seleccionar").Header.Caption = " "
                .Columns("seleccionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Seleccionar").Width = 12
                .Columns("Total").Format = "##,##0.00"
                .Columns("Precio").Format = "##,##0.00"

                .Columns("aplicadoMaquila").Hidden = True
                .Columns("IdTalla").Hidden = True
                .Columns("Nave").Hidden = True
                .Columns("IdDetalleDevolucion").Hidden = True
                .Columns("IdCadena").Hidden = True
                .Columns("TDevolucion").Hidden = True
                .Columns("IdDevolucion").Hidden = True
                .Columns("Pares").Width = 40
                .Columns("seleccionar").Width = 10
                '.Columns("codigo").Hidden = True
                .Columns("Modelo").Width = 50
                .Columns("Lote").Width = 50
                If estatusM Then
                    .Columns("Estatus").Hidden = False
                Else
                    .Columns("Estatus").Hidden = True
                End If
                If mostrarCamposOcultos Then
                    .Columns("IdDetalleDevolucion").Hidden = False
                    .Columns("IdTalla").Hidden = False
                End If

            End With
            grdDevoluciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdDevoluciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            'grdListas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
            Dim total As Double = 0
            For Each row As UltraGridRow In grdDevoluciones.Rows
                total += row.Cells("Total").Value
            Next
            lblDev.Text = "$ " & Format(total, "##,##0.#0")
            pintarCeldas()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub pintarCeldas()
        Try
            Dim i As Integer = 0
            Dim total As Double = 0.0
            Dim pares As Integer = 0
            Do
                If grdDevoluciones.Rows(i).Cells("Total").Value = 0 Then
                    grdDevoluciones.Rows(i).Cells("Total").Appearance.BackColor = Color.Salmon
                Else
                    grdDevoluciones.Rows(i).Cells("Total").Appearance.BackColor = Color.YellowGreen
                End If
                i = i + 1
            Loop While i < grdDevoluciones.Rows.Count
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDevoluciones_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDevoluciones.ClickCell
        Try
            If grdDevoluciones.ActiveRow.Cells("seleccionar").IsActiveCell Then
                grdDevoluciones.ActiveRow.Selected = False
            Else
                grdDevoluciones.ActiveRow.Selected = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdDevoluciones_CellChange(sender As Object, e As CellEventArgs) Handles grdDevoluciones.CellChange
        Try
            Dim total As Double = 0
            Dim listaIdDetalleDevolucion As New List(Of Integer)
            If e.Cell.Column.ToString = "seleccionar" Then
                If CBool(e.Cell.Value) Then
                    grdDevoluciones.ActiveRow.Cells("seleccionar").Value = False
                Else
                    grdDevoluciones.ActiveRow.Cells("seleccionar").Value = True
                End If
                Dim d As DataTable = grdDevoluciones.DataSource
                For Each row As DataRow In d.Rows
                    If Not listaIdDetalleDevolucion.Contains(row("IdDetalleDevolucion")) Then
                        listaIdDetalleDevolucion.Add(row("IdDetalleDevolucion"))
                        If CBool(row("seleccionar")) Then
                            If row("Total") > 0 Then
                                total += row("Total")
                            Else
                                '("seleccionar") = 0
                                adv.mensaje = "EL modelo " & row("Modelo") & " no tiene una lista de precio vigente."
                                adv.ShowDialog()
                                Return
                            End If
                        End If
                    End If
                Next
                lblDevSelc.Text = "$ " & Format(total, "##,##0.#0")
                lblNuevoTotal.Text = "$ " & (totalRemision - total).ToString("##,##0.#0")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodo.CheckedChanged
        For Each row As UltraGridRow In grdDevoluciones.Rows
            row.Cells("Seleccionar").Value = False
        Next
        If chkTodo.Checked Then
            For Each row As UltraGridRow In grdDevoluciones.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = True
            Next
        Else
            For Each row As UltraGridRow In grdDevoluciones.Rows.GetFilteredInNonGroupByRows
                row.Cells("Seleccionar").Value = False
            Next
        End If
        Dim total As Double = 0
        Dim d As DataTable = grdDevoluciones.DataSource
        Dim listaIdDetalleDevolucion As New List(Of Integer)
        For Each row As DataRow In d.Rows
            If CBool(row("seleccionar")) Then
                If Not listaIdDetalleDevolucion.Contains(row("IdDetalleDevolucion")) Then
                    listaIdDetalleDevolucion.Add(row("IdDetalleDevolucion"))
                    If row("Total") > 0 Then
                        total += row("Total")
                    Else
                        row("seleccionar") = 0
                        adv.mensaje = "EL modelo " & row("Modelo") & " no tiene una lista de precio vigente."
                        adv.ShowDialog()
                        Return
                    End If
                End If

            End If
        Next
        lblDevSelc.Text = "$ " & Format(total, "##,##0.#0")
        lblNuevoTotal.Text = "$ " & (totalRemision - total).ToString("##,##0.#0")
    End Sub
    Private Sub guardar()
        Dim diferencia = 0.00
        If totalRemision >= 0 Then
            Dim d As New DevolucionMaquila
            Dim obj As New DevolucionBU
            Dim data As New DataTable
            Dim listaIdDetalleDevolucion As New List(Of Integer)
            data = grdDevoluciones.DataSource
            For Each row As DataRow In data.Rows
                If CBool(row("seleccionar")) Then
                    If Not listaIdDetalleDevolucion.Contains(row("IdDetalleDevolucion")) Then
                        d = New DevolucionMaquila
                        d.codigo = row("Código")
                        d.descripcion = row("Descripción")
                        d.idCadena = row("IdCadena")
                        d.idComprobante = idComprobante
                        d.idDevolucionDetalle = row("IdDetalleDevolucion")
                        listaIdDetalleDevolucion.Add(row("IdDetalleDevolucion"))
                        d.pares = row("Pares")
                        d.precio = row("Precio")
                        d.total = row("Total")
                        d.usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                        diferencia = Math.Abs(totalFinal - d.total)
                        If d.total <= totalFinal Then
                            obj.aplicarDevolucion(d)
                        Else
                            If diferencia < 1 Then
                                obj.aplicarDevolucion(d)
                            Else
                                adv.mensaje = "El total de la devolucion no puede ser mayor al total del documento."
                                adv.ShowDialog()
                            End If
                        End If
                    End If
                End If
            Next
            exito.mensaje = "Remisión actualizada."
            exito.ShowDialog()
            Me.Close()
        Else
            adv.mensaje = "La remisión no debe quedar en negativos."
            adv.ShowDialog()
        End If
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub
    Function getPrecios(ByVal datosDev As DataTable) As DataTable
        Dim obj As New DevolucionBU
        Dim datosDetalles As New DataTable
        Dim datosFamilia As New DataTable
        Dim precio As New DataTable
        Dim precioFam As New DataTable
        Dim precios As Double = 0

        For Each row As DataRow In datosDev.Rows
            datosDetalles = obj.getDetalleDevolucionPares(row("idDetalleDevolucion"))
            precios = 0
            For Each row2 As DataRow In datosDetalles.Rows
                If row("Estatus") = "INACTIVO" Or row("Estatus") = "ELIMINADO" Or row("Estatus") = "DESCONTINUADO" Then
                    datosFamilia = obj.getFamiliaModelo(row("Modelo"), row("idTalla"))
                    Dim ban As Boolean = False
                    For Each row3 As DataRow In datosFamilia.Rows
                        precioFam = obj.getPrecioFamiliaTalla(row3("Familia"), row2("Talla"))
                        For Each row4 As DataRow In precioFam.Rows
                            row("Precio") = row4("precio")
                            precios += row4("precio") * row2("Cantidad")
                            If row4("precio") > 0 Then
                                ban = True
                            End If
                        Next
                    Next
                    If ban = False Then
                        precio = obj.getPrecioPorTalla(idNave, row2("Talla"))
                        For Each row3 As DataRow In precio.Rows
                            row("Precio") = row3("precio")
                            precios += row3("precio") * row2("Cantidad")
                        Next
                    End If
                    row("Total") = precios
                End If
            Next
        Next
        getPrecios = datosDev
    End Function
    Private Sub chkTodosModelos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosModelos.CheckedChanged
        If chkTodosModelos.Checked Then
            Dim obj As New DevolucionBU
            Dim datosDev As New DataTable
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            datosDev = obj.getDevoluciones(fechaInicio, fechaFin, idNave, True)
            grdDevoluciones.DataSource = getPrecios(datosDev)
            disenioGrid()
            Me.Cursor = Windows.Forms.Cursors.Default
        Else
            Dim obj As New DevolucionBU
            grdDevoluciones.DataSource = obj.getDevoluciones(fechaInicio, fechaFin, idNave, False)
            disenioGrid()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles chkEstatus.CheckedChanged
        If chkEstatus.Checked Then
            estatusM = True
        Else
            estatusM = False
        End If
        If chkTodosModelos.Checked Then
            Dim obj As New DevolucionBU
            Dim datosDev As New DataTable
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            datosDev = obj.getDevoluciones(fechaInicio, fechaFin, idNave, True)
            grdDevoluciones.DataSource = getPrecios(datosDev)
            disenioGrid()
            Me.Cursor = Windows.Forms.Cursors.Default
        Else
            Dim obj As New DevolucionBU
            grdDevoluciones.DataSource = obj.getDevoluciones(fechaInicio, fechaFin, idNave, False)
            disenioGrid()
        End If
    End Sub
    Dim mostrarCamposOcultos As Boolean = False
    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        If mostrarCamposOcultos Then
            mostrarCamposOcultos = False
        Else
            mostrarCamposOcultos = True
        End If

        If chkTodosModelos.Checked Then
            Dim obj As New DevolucionBU
            Dim datosDev As New DataTable
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            datosDev = obj.getDevoluciones(fechaInicio, fechaFin, idNave, True)
            grdDevoluciones.DataSource = getPrecios(datosDev)
            disenioGrid()
            Me.Cursor = Windows.Forms.Cursors.Default
        Else
            Dim obj As New DevolucionBU
            grdDevoluciones.DataSource = obj.getDevoluciones(fechaInicio, fechaFin, idNave, False)
            disenioGrid()
        End If
    End Sub
End Class