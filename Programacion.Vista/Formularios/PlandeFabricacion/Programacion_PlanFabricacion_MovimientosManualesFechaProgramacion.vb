Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_PlanFabricacion_MovimientosManualesFechaProgramacion
    Public PedidosSeleccionados As String = String.Empty
    Dim Accion As Integer = 0
    Dim VxmlCeldas As String = String.Empty
    Dim eventoActivo As Boolean = False

    Private Sub Programacion_PlanFabricacion_MovimientosManualesFechaProgramacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarPedidosPendientesAutorizar()
        lblSemanaActual.Text = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        CargarNavesAuxiliar()
    End Sub

    Private Sub CargarPedidosPendientesAutorizar()
        Dim objBU As New PlanFabricacionBU
        Dim dtObtienePedidosPendientesDeAutorizacion As New DataTable
        Dim NaveID As Integer = 0

        Try
            Cursor = Cursors.WaitCursor

            grdAutorizacionCambiosFechaProgramacion.DataSource = Nothing
            vwAutorizacionCambiosFechaProgramacion.Columns.Clear()

            If cmbNave.SelectedIndex <> 0 Then
                NaveID = cmbNave.SelectedValue
            End If

            dtObtienePedidosPendientesDeAutorizacion = objBU.ObtienePendientesPorAutorizar_FechaProgramacion(NaveID)

            If dtObtienePedidosPendientesDeAutorizacion.Rows.Count > 0 Then
                grdAutorizacionCambiosFechaProgramacion.DataSource = dtObtienePedidosPendientesDeAutorizacion
                DisenioGrid()
            Else
                show_message("Advertencia", "No hay datos para mostrar.")
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DisenioGrid()
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwAutorizacionCambiosFechaProgramacion.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> " " Then
                col.OptionsColumn.AllowEdit = False
            Else
                col.OptionsColumn.AllowEdit = True
            End If
        Next

        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName(" ").Width = 20
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SAY Origen").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SICY Origen").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Origen").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Fecha Entrega Cliente Origen").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Semana Origen").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Nave Origen").Width = 80


        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName(" ").Width = 20
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SAY Destino").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SICY Destino").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Destino").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Fecha Entrega Cliente Destino").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Semana Destino").Width = 60
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Nave Destino").Width = 80

        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SAY Origen").Caption = "Pedido" & vbCrLf & "SAY" & vbCrLf & "Origen"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SICY Origen").Caption = "Pedido" & vbCrLf & "SICY" & vbCrLf & "Origen"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Origen").Caption = "Pares" & vbCrLf & "Origen"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Fecha Entrega Cliente Origen").Caption = "FEntrega" & vbCrLf & "Cliente" & vbCrLf & "Origen"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Semana Origen").Caption = "Semana" & vbCrLf & "Origen"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Nave Origen").Caption = "Nave" & vbCrLf & "Origen"


        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SAY Destino").Caption = "Pedido" & vbCrLf & "SAY" & vbCrLf & "Destino"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pedido SICY Destino").Caption = "Pedido" & vbCrLf & "SICY" & vbCrLf & "Destino"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Destino").Caption = "Pares" & vbCrLf & "Destino"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Fecha Entrega Cliente Destino").Caption = "FEntrega" & vbCrLf & "Cliente" & vbCrLf & "Destino"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Semana Destino").Caption = "Semana" & vbCrLf & "Destino"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Nave Destino").Caption = "Nave" & vbCrLf & "Destino"


        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("NaveDestinoID").Visible = False
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("NaveOrigenID").Visible = False
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("AñoDestino").Visible = False
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("FechaEntregaNuevaColocar").Visible = False


        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Origen").DisplayFormat.FormatString = "{0:n0}"
        vwAutorizacionCambiosFechaProgramacion.Columns.ColumnByFieldName("Pares Destino").DisplayFormat.FormatString = "{0:n0}"


        vwAutorizacionCambiosFechaProgramacion.IndicatorWidth = 30
        DiseñoGrid.AlternarColorEnFilas(vwAutorizacionCambiosFechaProgramacion)


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
    End Sub

    Private Sub CargarNavesAuxiliar()
        Dim DTNAves As DataTable
        Dim objBU As New MovimientosPPCPBU
        DTNAves = objBU.ConsultarNavesAux()
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
        cmbNave.DataSource = DTNAves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "NaveSAYId"
    End Sub

    Private Function generaXML() As String

        Dim NumeroFilas As Integer = 0
        NumeroFilas = vwAutorizacionCambiosFechaProgramacion.DataRowCount

        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        For i As Integer = 0 To NumeroFilas Step 1
            If CBool(vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(vwAutorizacionCambiosFechaProgramacion.GetRowHandle(i), " ")) = True Then
                Dim vNodo As XElement = New XElement("Celda")
                vNodo.Add(New XAttribute("PedidoSAYDestino", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "Pedido SAY Destino")))
                vNodo.Add(New XAttribute("NaveDestinoID", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "NaveDestinoID")))
                vNodo.Add(New XAttribute("PedidoSAYOrigen", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "Pedido SAY Origen")))
                vNodo.Add(New XAttribute("NaveOrigenID", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "NaveOrigenID")))
                vNodo.Add(New XAttribute("SemanaDestinoID", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "Semana Destino")))
                vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                vNodo.Add(New XAttribute("AñoDestino", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "AñoDestino")))
                vNodo.Add(New XAttribute("FechaEntregaOrigen", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "Fecha Entrega Cliente Origen")))
                vNodo.Add(New XAttribute("FechaEntregaNuevaColocar", vwAutorizacionCambiosFechaProgramacion.GetRowCellValue(i, "FechaEntregaNuevaColocar")))

                vXmlCeldasModificadas.Add(vNodo)
            End If
        Next


        If vXmlCeldasModificadas.IsEmpty = False Then
            VxmlCeldas = vXmlCeldasModificadas.ToString()
        Else
            VxmlCeldas = ""
        End If

        Return VxmlCeldas

    End Function


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim objBU As New PlanFabricacionBU
        Dim dtAutorizarCambioFechaProgramacion As New DataTable
        Dim Confirmar As New ConfirmarForm

        Try

            If vwAutorizacionCambiosFechaProgramacion.DataRowCount > 0 Then

                Cursor = Cursors.WaitCursor

                Accion = 1 'Autorizar

                VxmlCeldas = generaXML()

                If VxmlCeldas <> "" Then
                    Confirmar.mensaje = "¿Desea autorizar los movimientos seleccionados?"
                    If Confirmar.ShowDialog() = DialogResult.OK Then
                        dtAutorizarCambioFechaProgramacion = objBU.CambiaEstatus_FechaProgramacion_PPCP(VxmlCeldas.ToString(), Accion)
                        If dtAutorizarCambioFechaProgramacion.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                            show_message("Exito", "Datos actualizados correctamente.")
                            CargarPedidosPendientesAutorizar()
                        Else
                            show_message("Advertencia", "Ocurrió un error, intente nuevamente.")
                        End If
                    End If
                End If
            Else
                show_message("Advertencia", "Seleccione un movimiento para autorizar.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub



    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Dim objBU As New PlanFabricacionBU
        Dim dtAutorizarCambioFechaProgramacion As New DataTable
        Dim Confirmar As New ConfirmarForm

        Try

            If vwAutorizacionCambiosFechaProgramacion.DataRowCount > 0 Then

                Accion = 2 'Rechazar

                VxmlCeldas = generaXML()

                If VxmlCeldas <> "" Then
                    Confirmar.mensaje = "¿Desea autorizar los movimientos seleccionados?"
                    If Confirmar.ShowDialog() = DialogResult.OK Then
                        dtAutorizarCambioFechaProgramacion = objBU.CambiaEstatus_FechaProgramacion_PPCP(VxmlCeldas, Accion)
                        If dtAutorizarCambioFechaProgramacion.Rows(0).Item("respuesta").ToString <> "ERROR" Then
                            show_message("Exito", "Datos actualizados correctamente.")
                            CargarPedidosPendientesAutorizar()
                        End If
                    End If
                End If
            Else
                show_message("Advertencia", "Seleccione un movimiento para autorizar.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarPedidosPendientesAutorizar()
    End Sub


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlBotonesExpander.AutoSize = True
        pnlFiltros.Visible = True
    End Sub

    Private Sub vwAutorizacionCambiosFechaProgramacion_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwAutorizacionCambiosFechaProgramacion.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        Dim activar = False
        If (chkSeleccionarTodo.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwAutorizacionCambiosFechaProgramacion.RowCount) Step 1
                vwAutorizacionCambiosFechaProgramacion.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
        End If
    End Sub


End Class