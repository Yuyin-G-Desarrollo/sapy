Imports Tools
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
'Imports XtraReportSerialization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms

Public Class AgendaEntrega_Form

    Dim TipoPerfil As Integer = 0
    Dim EsYISTI As Boolean = False

    Dim primeraConsultaAgenda As Integer = 1

    Private Sub btnAgendar_Click(sender As Object, e As EventArgs) Handles btnAgendar.Click
        Dim ordenesTrabajoSeleccionadas As String = ""
        Dim ordenesConEmbarque As Integer = 0
        Cursor = Cursors.WaitCursor
        For index As Integer = 0 To grvAgendaLista.DataRowCount - 1
            If CBool(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grvAgendaLista.IsRowSelected(grvAgendaLista.GetVisibleRowHandle(index))) = True Then
                If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString <> "" Then
                    ordenesConEmbarque += 1
                Else
                    If ordenesTrabajoSeleccionadas <> "" Then
                        ordenesTrabajoSeleccionadas += ","
                    End If
                    ordenesTrabajoSeleccionadas += grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString()
                End If
            End If
        Next
        If ordenesTrabajoSeleccionadas <> "" Then
            If ordenesConEmbarque > 0 Then
                show_message("Advertencia", "Algunos de los registros seleccionados ya se encuentran agendados, verifique por favor.")
            Else
                Dim ventana As New AltaEmbarqueAgendaEntregaForm
                ventana.idOrdenesTrabajo = ordenesTrabajoSeleccionadas
                ventana.actualizarAgenda = Me
                ventana.ShowDialog()
            End If
        Else
            show_message("Advertencia", "Debe seleccionar al menos un registro.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CargarPerfil()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_VENTAS") Then
            TipoPerfil = 1
        End If

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_ALMACEN") Then
            TipoPerfil = 2
        End If

        If TipoPerfil = 1 Then
            btnAgendar.Enabled = False
            lblTextoAgendar.Enabled = False
            btnEditarAgenda.Enabled = False
            lblTextoEdittar.Enabled = False
            btnLiberarUnidad.Enabled = False
            lblTextoLiberarUnidad.Enabled = False
            btnCancelarApartado.Enabled = False
            lblTextoCancelarembarque.Enabled = False
        End If


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VENT_ADMIN_OT", "VENT_ADMIN_ORDENTRABAJO_YISTI") Then           
            EsYISTI = True
        End If

    End Sub

    Private Sub AgendaEntrega_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim Tabla_ListadoParametros As New DataTable

        WindowState = FormWindowState.Maximized
        spcTiposVistaAgenda.SplitterDistance = spcTiposVistaAgenda.Height
        dtpFechaEmbarqueDel.Value = Date.Now.AddDays((Date.Now.DayOfWeek - 1) * -1)
        dtpFechaEmbarqueAl.Value = dtpFechaEmbarqueDel.Value.AddDays(5)

        Tabla_ListadoParametros.Columns.Add("ID")
        Tabla_ListadoParametros.Columns.Add("Unidad")
        Tabla_ListadoParametros.Rows.Add("0", "TODAS")
        For Each row As DataRow In objBU.ConsultaUnidadesAltaEmbarquesAgenda().Rows
            Tabla_ListadoParametros.Rows.Add(row(0), row(1))
        Next
        Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbUnidad.DataSource = Tabla_ListadoParametros
        cmbUnidad.DisplayMember = "Unidad"
        cmbUnidad.ValueMember = "ID"

        Tabla_ListadoParametros = New DataTable
        Tabla_ListadoParametros.Columns.Add("ID")
        Tabla_ListadoParametros.Columns.Add("Tipo")
        Tabla_ListadoParametros.Rows.Add("1", "TODAS")
        Tabla_ListadoParametros.Rows.Add("568", "DOMICILIO INDICADO")
        Tabla_ListadoParametros.Rows.Add("570", "CLIENTE RECOGE")
        Tabla_ListadoParametros.Rows.Add("2", "PAQUETERÍA")
        'Tabla_ListadoParametros.Rows.InsertAt(Tabla_ListadoParametros.NewRow, 0)
        cmbTipoEntregaMercancia.DataSource = Tabla_ListadoParametros
        cmbTipoEntregaMercancia.DisplayMember = "Tipo"
        cmbTipoEntregaMercancia.ValueMember = "ID"

        cmbTipoEntregaMercancia.SelectedIndex = 1
        cmbUnidad.SelectedIndex = 1

        CargarPerfil()

        btnMostrar_Click(sender, e)



        primeraConsultaAgenda = 0
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub rdbLista_CheckedChanged(sender As Object, e As EventArgs) Handles rdbLista.CheckedChanged
        If rdbLista.Checked = True Then
            spcTiposVistaAgenda.SplitterDistance = spcTiposVistaAgenda.Height
            chboxSinAgendar.Checked = True
            chboxSinAgendar.Enabled = True
            chboxAgendado.Enabled = True
            grpFechaEmbarque.Visible = False
        Else
            spcTiposVistaAgenda.SplitterDistance = 0
            chboxSinAgendar.Checked = False
            chboxSinAgendar.Enabled = False
            chboxAgendado.Checked = True
            chboxAgendado.Enabled = False
            grpFechaEmbarque.Visible = True
        End If

        If primeraConsultaAgenda = 0 Then
            btnMostrar_Click(Nothing, Nothing)
        End If



    End Sub

    Public Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim objBu As New Negocios.OrdenTrabajoBU
        Dim tblConsultaAgenda As New DataTable
        Dim sinAgendar As Integer = 0
        Dim agendado As Integer = 0
        Dim tipoEntrega As Integer = 0
        Dim unidad As Integer = 0

        Cursor = Cursors.WaitCursor

        If rdbAgenda.Checked Then
            generarAgendaHTML()
        Else
            sinAgendar = If(chboxSinAgendar.Checked, 1, 0)
            agendado = If(chboxAgendado.Checked, 1, 0)
            tipoEntrega = Integer.Parse(cmbTipoEntregaMercancia.SelectedValue.ToString())
            unidad = If(cmbUnidad.SelectedValue.ToString() <> "", Integer.Parse(cmbUnidad.SelectedValue.ToString()), 0)
            tblConsultaAgenda = objBu.ConsultarCitasEmbarquesModoLista(sinAgendar, agendado, tipoEntrega, unidad, EsYISTI)
            grdAgendaTipoLista.DataSource = Nothing
            grdAgendaTipoLista.DataSource = tblConsultaAgenda
            DiseñoGrid()
            lblNumFiltrados.Text = grvAgendaLista.RowCount
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub cmbTipoEntregaMercancia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoEntregaMercancia.SelectedIndexChanged
        If cmbTipoEntregaMercancia.SelectedValue.ToString() <> "568" And cmbTipoEntregaMercancia.SelectedValue.ToString() <> "1" Then
            cmbUnidad.SelectedIndex = 0
            cmbUnidad.Enabled = False
        Else
            cmbUnidad.Enabled = True
            cmbUnidad.SelectedIndex = 1
        End If
    End Sub

    Private Sub rdbAgenda_CheckedChanged(sender As Object, e As EventArgs) Handles rdbAgenda.CheckedChanged
        If primeraConsultaAgenda = 0 Then
            btnMostrar_Click(Nothing, Nothing)
        End If

        'If rdbAgenda.Checked Then
        '    generarAgendaHTML()
        'End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 102
    End Sub

    Private Function ObtenerOrdenesTabajoSeleccionadas() As String

        Dim NumeroFilas As Integer = 0
        Dim NumeroOrdenesTrabajo As Integer = 0
        Dim OrdenTrabajoID As String = String.Empty
        Dim OrdenTrabajoSICYID As String = String.Empty

        Try
            NumeroFilas = grvAgendaLista.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                    NumeroOrdenesTrabajo += 1
                    If OrdenTrabajoID = String.Empty Then
                        OrdenTrabajoID = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OT").ToString()
                        OrdenTrabajoSICYID = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OTSICY").ToString()
                    Else
                        OrdenTrabajoID += "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OT").ToString()
                        OrdenTrabajoSICYID += "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OTSICY").ToString()
                    End If
                End If
            Next
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

        Return OrdenTrabajoID

    End Function

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("AdvertenciaGrande") Then

            Dim mensajeAdvertencia As New AdvertenciaFormGrande
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()

        End If

        If tipo.ToString.Equals("Aviso") Then

            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()

        End If

        If tipo.ToString.Equals("Error") Then

            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()

        End If

        If tipo.ToString.Equals("Exito") Then

            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

        If tipo.ToString.Equals("Confirmar") Then

            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If

    End Sub

    Private Sub DiseñoGrid()

        grvAgendaLista.OptionsView.BestFitMaxRowCount = 3

        'If IsNothing(grvAgendaLista.Columns.FirstOrDefault(Function(x) x.FieldName = "#")) = True Then
        'grvAgendaLista.Columns.AddVisible("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        grvAgendaLista.Columns.Item("#").UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        AddHandler grvAgendaLista.CustomUnboundColumnData, AddressOf grvAgendaLista_CustomUnboundColumnData
        grvAgendaLista.Columns.Item("#").OwnerBand = gridBand2
        grvAgendaLista.Columns.ColumnByFieldName("#").VisibleIndex = 0
        'End If




        grvAgendaLista.Columns.ColumnByFieldName("UnidadID").Visible = False

        grvAgendaLista.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grvAgendaLista.Columns.ColumnByFieldName("NumOper").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grvAgendaLista.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"
        grvAgendaLista.Columns.ColumnByFieldName("NumOper").DisplayFormat.FormatString = "N0"

        grvAgendaLista.Columns.ColumnByFieldName("#").Width = 25
        grvAgendaLista.Columns.ColumnByFieldName("Seleccionar").Width = 25

        grvAgendaLista.Columns.ColumnByFieldName("Seleccionar").Caption = " "
        grvAgendaLista.Columns.ColumnByFieldName("Cliente").Caption = "Cliente"
        grvAgendaLista.Columns.ColumnByFieldName("OrdenTrabajo").Caption = "OT"
        grvAgendaLista.Columns.ColumnByFieldName("Pares").Caption = "Pares"
        grvAgendaLista.Columns.ColumnByFieldName("tiem_nombre").Caption = "T Empaque"
        grvAgendaLista.Columns.ColumnByFieldName("FechaCita").Caption = "Fecha"

        grvAgendaLista.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList

        grvAgendaLista.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        If IsNothing(grvAgendaLista.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            grvAgendaLista.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            grvAgendaLista.GroupSummary.Add(item)
        End If

        actualizarDatosGridMostrar()

    End Sub

    Private Sub grvAgendaLista_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs)
        If e.IsGetData Then
            e.Value = grvAgendaLista.GetRowHandle(e.ListSourceRowIndex)
            e.Value = e.Value + 1
        End If
    End Sub

    Private Sub actualizarDatosGridMostrar()

        Dim NumeroFilas As Integer = 0
        Dim OtMostrar As String = ""

        Try
            NumeroFilas = grvAgendaLista.DataRowCount
            For index As Integer = 0 To NumeroFilas - 1 Step 1
                OtMostrar = ""

                If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString().Contains(",") = False Then
                    If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "Cliente").ToString().Contains("COPPEL") = True Then
                        OtMostrar = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajoCoppel").ToString()
                    Else
                        OtMostrar = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString()
                    End If
                Else
                    OtMostrar = "..."
                End If
                    grvAgendaLista.SetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OTMostrar", OtMostrar)

            Next
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try


    End Sub

    Private Sub grvAgendaLista_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles grvAgendaLista.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        If (e.RowHandle = currentView.FocusedRowHandle) Then Return

        If e.Column.FieldName = "Unidad" Then
            If CBool(currentView.GetRowCellValue(e.RowHandle, "UnidadOcupada")) = True Then
                e.Appearance.ForeColor = lblVehiculoEnRuta.ForeColor
            End If
        End If

    End Sub


    Private Sub btnEditarAgenda_Click(sender As Object, e As EventArgs) Handles btnEditarAgenda.Click
        Dim totalOrdenesTrabajoSeleccionadas As Integer = 0
        Dim ordenesTrabajoSeleccionadas As String = ""
        Dim fechaEntrega As String = ""
        Dim fechaRegreso As String = ""
        Dim paqueteriaId As Integer = 0
        Dim unidadId As Integer = 0
        Dim operadorId As Integer = 0
        Dim ordenesConEmbarque As Integer = 0
        Dim listEmbarques As New List(Of String)
        Dim confirmacion As New Tools.ConfirmarForm()
        Cursor = Cursors.WaitCursor
        For index As Integer = 0 To grvAgendaLista.DataRowCount - 1
            If CBool(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "Seleccionar")) = True Or CBool(grvAgendaLista.IsRowSelected(grvAgendaLista.GetVisibleRowHandle(index))) = True Then
                If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString <> "" Then
                    ordenesConEmbarque += 1
                    If listEmbarques.Contains(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString()) = False Then
                        listEmbarques.Add(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString())
                    End If
                End If
                totalOrdenesTrabajoSeleccionadas += 1
                If ordenesTrabajoSeleccionadas <> "" Then
                    ordenesTrabajoSeleccionadas += ","
                End If
                ordenesTrabajoSeleccionadas += grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString()

                If IsDate(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString()) Then

                    fechaEntrega = CDate(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString()).ToShortDateString + " " + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString()
                    fechaRegreso = CDate(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString()).ToShortDateString + " " + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEstimadaRegreso").ToString()

                End If

                paqueteriaId = Integer.Parse(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString())
                unidadId = Integer.Parse(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString())
                operadorId = Integer.Parse(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OperadorId").ToString())
            End If
        Next

        If totalOrdenesTrabajoSeleccionadas > 0 Then
            If ordenesConEmbarque <> totalOrdenesTrabajoSeleccionadas Then
                show_message("Advertencia", "Algunos de los registros seleccionados no se encuentran agendados, verifique por favor.")
            Else
                If listEmbarques.Count > 1 Then
                    confirmacion.mensaje = "Seleccionó embarques con diferentes datos, todos los registros seleccionados serán modificados. ¿Desea continuar?"
                    If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim ventana As New AltaEmbarqueAgendaEntregaForm
                        ventana.idOrdenesTrabajo = ordenesTrabajoSeleccionadas
                        ventana.actualizarAgenda = Me
                        ventana.ShowDialog()
                    End If
                Else
                    Dim ventana As New AltaEmbarqueAgendaEntregaForm
                    ventana.idOrdenesTrabajo = ordenesTrabajoSeleccionadas
                    ventana.fechaEntrega = fechaEntrega
                    ventana.FechaRegreso = fechaRegreso
                    ventana.paqueteriaId = paqueteriaId
                    ventana.unidadId = unidadId
                    ventana.operadorId = operadorId
                    ventana.actualizarAgenda = Me
                    ventana.ShowDialog()
                End If
            End If
        Else
            show_message("Advertencia", "Debe seleccionar al menos un registro.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnLiberarUnidad_Click(sender As Object, e As EventArgs) Handles btnLiberarUnidad.Click

        Dim totalOrdenesTrabajoSeleccionadas As Integer = 0
        Dim ordenesTrabajoSeleccionadas As String = ""
        Dim fechaEntrega As String = ""
        Dim ordenesConEmbarque As Integer = 0
        Dim listEmbarques As New List(Of String)
        Dim confirmacion As New Tools.ConfirmarForm()
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim unidadesAsignadas As Integer = 0
        Cursor = Cursors.WaitCursor
        For index As Integer = 0 To grvAgendaLista.DataRowCount - 1
            If CBool(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString <> "" Then
                    ordenesConEmbarque += 1
                    If listEmbarques.Contains(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString()) = False Then
                        listEmbarques.Add(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString())
                    End If
                End If
                If CBool(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadOcupada")) = True Then
                    unidadesAsignadas += 1
                End If

                totalOrdenesTrabajoSeleccionadas += 1
                If ordenesTrabajoSeleccionadas <> "" Then
                    ordenesTrabajoSeleccionadas += ","
                End If
                ordenesTrabajoSeleccionadas += grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString()
            End If
        Next

        If totalOrdenesTrabajoSeleccionadas > 0 Then
            If ordenesConEmbarque <> totalOrdenesTrabajoSeleccionadas Then
                show_message("Advertencia", "Algunos de los registros seleccionados no se encuentran agendados, verifique por favor.")
            Else
                If unidadesAsignadas <> totalOrdenesTrabajoSeleccionadas Then
                    show_message("Advertencia", "Algunos de los registros seleccionados no tienen unidades a liberar, verifique por favor.")
                Else
                    If listEmbarques.Count > 1 Then
                        confirmacion.mensaje = "Seleccionó embarques con diferentes datos, todos los registros seleccionados serán modificados. ¿Desea continuar?"
                        If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            objBU.LiberarUnidades(ordenesTrabajoSeleccionadas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            btnMostrar_Click(sender, e)
                        End If
                    Else
                        confirmacion.mensaje = "Este cambio no podrá revertirse ¿Desea continuar?"
                        If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                            objBU.LiberarUnidades(ordenesTrabajoSeleccionadas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                            btnMostrar_Click(sender, e)
                        End If
                    End If
                End If
            End If

        Else
            show_message("Advertencia", "Debe seleccionar al menos un registro.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelarApartado_Click(sender As Object, e As EventArgs) Handles btnCancelarApartado.Click
        Dim confirmacion As New Tools.ConfirmarForm
        Dim ordenesConEmbarque As Integer = 0
        Dim listEmbarques As New List(Of String)
        Dim totalOrdenesTrabajoSeleccionadas As Integer = 0
        Dim ordenesTrabajoSeleccionadas As String = ""
        Dim objBu As New Negocios.OrdenTrabajoBU
        Dim exito As New Tools.ExitoForm
        Dim advertencia As New Tools.AdvertenciaForm

        exito.mensaje = "Datos actualizados correctamente."
        advertencia.mensaje = "El proceso no se pudo completar, intente de nuevo."

       

        For index As Integer = 0 To grvAgendaLista.DataRowCount - 1
            If CBool(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString <> "" Then
                    ordenesConEmbarque += 1
                    If listEmbarques.Contains(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString()) = False Then
                        listEmbarques.Add(grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "UnidadID").ToString() + "," + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "PaqueteriaId").ToString())
                    End If
                End If
                totalOrdenesTrabajoSeleccionadas += 1
                If ordenesTrabajoSeleccionadas <> "" Then
                    ordenesTrabajoSeleccionadas += ","
                End If
                ordenesTrabajoSeleccionadas += grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString()
            End If
        Next

        If totalOrdenesTrabajoSeleccionadas > 0 Then
            If ordenesConEmbarque <> totalOrdenesTrabajoSeleccionadas Then
                show_message("Advertencia", "Algunos de los registros seleccionados no se encuentran agendados, verifique por favor.")
            Else
                If listEmbarques.Count > 1 Then
                    confirmacion.mensaje = "Seleccionó embarques con diferentes datos, todos los registros seleccionados serán modificados, este proceso no podrá revertirse. ¿Desea continuar?"
                Else
                    confirmacion.mensaje = "Este proceso no podrá revertirse. ¿Desea continuar?"
                End If
                If confirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Try
                        objBu.CancelarEmbarque(ordenesTrabajoSeleccionadas)
                        exito.ShowDialog()
                        btnMostrar_Click(sender, e)
                    Catch ex As Exception
                        advertencia.ShowDialog()
                    End Try
                End If
            End If
        Else
            show_message("Advertencia", "Debe seleccionar al menos un registro.")
        End If

    End Sub

    Private Sub dtpFechaEmbarqueDel_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaEmbarqueDel.ValueChanged
        If dtpFechaEmbarqueAl.Value < dtpFechaEmbarqueDel.Value Then
            dtpFechaEmbarqueAl.Value = dtpFechaEmbarqueDel.Value
        End If
        dtpFechaEmbarqueAl.MinDate = dtpFechaEmbarqueDel.Value
    End Sub

    Private Sub cmbHoraFechaEntregaInicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHoraFechaEntregaInicio.SelectedIndexChanged
        If cmbHoraFechaEntregaInicio.SelectedIndex > cmbHoraFechaEntregaFin.SelectedIndex Then
            cmbHoraFechaEntregaFin.SelectedIndex = cmbHoraFechaEntregaInicio.SelectedIndex
        End If
    End Sub

    Private Sub cmbHoraFechaEntregaFin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbHoraFechaEntregaFin.SelectedIndexChanged
        If cmbHoraFechaEntregaInicio.SelectedIndex > cmbHoraFechaEntregaFin.SelectedIndex Then
            cmbHoraFechaEntregaInicio.SelectedIndex = cmbHoraFechaEntregaFin.SelectedIndex
        End If
    End Sub

    Private Sub grdAgendaTipoLista_DoubleClick(sender As Object, e As EventArgs) Handles grdAgendaTipoLista.DoubleClick

    End Sub

    Private Sub grdAgendaTipoLista_MouseClick(sender As Object, e As MouseEventArgs) Handles grdAgendaTipoLista.MouseClick


        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim totalOrdenesTrabajoSeleccionadas As Integer = 0
            Dim ordenesTrabajoSeleccionadas As String = ""
            Dim fechaEntrega As String = ""
            Dim paqueteriaId As Integer = 0
            Dim unidadId As Integer = 0
            Dim operadorId As Integer = 0
            Dim ordenesConEmbarque As Integer = 0
            Dim listEmbarques As New List(Of String)
            Dim confirmacion As New Tools.ConfirmarForm()

            Dim FilasSeleccionadas As Integer = 0
            Dim FilasSinEmbarque As Integer = 0
            Dim FilasConEmbarque As Integer = 0
            Dim fechaEntregaAux As String = ""
            Dim FechaEmbarqueDiferenes As Boolean = False
            Dim EsOTAgrupado As Boolean = False
            Dim OtAgrupado As String = String.Empty


            Try
                Cursor = Cursors.WaitCursor

                For index As Integer = 0 To grvAgendaLista.DataRowCount - 1
                    If CBool(grvAgendaLista.IsRowSelected(grvAgendaLista.GetVisibleRowHandle(index))) = True Then
                        FilasSeleccionadas += 1

                        If FilasSeleccionadas = 1 Then
                            OtAgrupado = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString
                            Dim parts As String() = Split(OtAgrupado, ",")
                            If parts.Length > 1 Then
                                EsOTAgrupado = True
                            End If

                        End If

                        If grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString <> "" Then
                            FilasConEmbarque += 1
                        Else
                            FilasSinEmbarque += 1
                        End If

                        If fechaEntrega <> String.Empty Then
                            fechaEntrega = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + " " + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString()

                        Else
                            fechaEntregaAux = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "FechaEmbarque").ToString() + " " + grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "HoraEmbarque").ToString()
                            If fechaEntrega <> fechaEntregaAux Then
                                FechaEmbarqueDiferenes = True
                            End If
                        End If
                    End If
                Next

                If FilasSeleccionadas = FilasSinEmbarque Then
                    cmsSeleccionMultiple.Items(0).Visible = True
                    cmsSeleccionMultiple.Items(1).Visible = False
                ElseIf FilasSeleccionadas = FilasConEmbarque Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                Else
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = True
                End If

                If FilasSeleccionadas = 1 Then
                    cmsSeleccionMultiple.Items(2).Visible = EsOTAgrupado
                Else
                    cmsSeleccionMultiple.Items(2).Visible = False
                End If

                If TipoPerfil = 1 Then
                    cmsSeleccionMultiple.Items(0).Visible = False
                    cmsSeleccionMultiple.Items(1).Visible = False
                End If

                cmsSeleccionMultiple.Show(Control.MousePosition)
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                show_message("Error", ex.Message.ToString())
            End Try


        End If




    End Sub

    Private Sub tmsiAgendar_Click(sender As Object, e As EventArgs) Handles tmsiAgendar.Click
        btnAgendar_Click(sender, e)
    End Sub

    Private Sub tmsiEditarAgenda_Click(sender As Object, e As EventArgs) Handles tmsiEditarAgenda.Click
        btnEditarAgenda_Click(sender, e)
    End Sub

    Private Sub tmsiMostrarOTs_Click(sender As Object, e As EventArgs) Handles tmsiMostrarOTs.Click
        Dim Form As New OrdenesTrabajoAgrupadasForm
        Form.OrdenTrabajoID = ObtenerOTsAgrupadas()
        Form.ShowDialog()
    End Sub

    Private Function ObtenerOTsAgrupadas() As String
        Dim OrdenTrabajoAgrupadasID As String = String.Empty

        For index As Integer = 0 To grvAgendaLista.DataRowCount - 1
            If CBool(grvAgendaLista.IsRowSelected(grvAgendaLista.GetVisibleRowHandle(index))) = True Then
                OrdenTrabajoAgrupadasID = grvAgendaLista.GetRowCellValue(grvAgendaLista.GetVisibleRowHandle(index), "OrdenTrabajo").ToString
            End If
        Next

        Return OrdenTrabajoAgrupadasID

    End Function



    Private Sub grvAgendaLista_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles grvAgendaLista.RowCellClick
        'If TipoPerfil = 2 Then

        'End If

        If e.Clicks = 2 Then
            If e.Column.Name = "OTMostrar" Then
                Dim OtAgrupado = grvAgendaLista.GetRowCellValue(e.RowHandle, "OrdenTrabajo").ToString
                Dim parts As String() = Split(OtAgrupado, ",")
                If parts.Length > 1 Then
                    tmsiMostrarOTs_Click(Nothing, Nothing)
                End If

            End If
        End If


    End Sub

    Private Sub generarAgendaHTML()
        Dim fechaInicio As Date
        Dim fechaFin As Date
        Dim totalFechas As Integer
        Dim totalHoras As Integer
        Dim horaAgregar As String
        Dim tipoEntrega As Integer
        Dim unidad As Integer
        Dim tablaCita As String

        Dim listHoras As New List(Of String)
        Dim listFechas As New List(Of String)
        Dim objBu As New Negocios.OrdenTrabajoBU
        Dim tblResultadoAgenda As New DataTable
        Dim splitFechaEmbarque() As String
        Dim splitFechaEmbarqueRegreso() As String
        Dim numRenglon As Integer = 1

        Dim horaInicioAgenda As Integer
        Dim horaFinAgenda As Integer

        Dim diaSemana As String = ""

        Dim tblNumeroColumnasPorFecha As New DataTable
        Dim totalColumnasFecha As Integer = 1
        Dim encabezadoColumna As String = ""
        Dim listFechasMasdeUnaColumna As New List(Of String)
        Dim listTablasCitasDias As New List(Of String)
        Dim listTablasCitasDiasGlobal As New List(Of String)
        Dim contadorColumnasColores As Integer = 0

        Cursor = Cursors.WaitCursor

        horaInicioAgenda = cmbHoraFechaEntregaInicio.SelectedIndex
        horaFinAgenda = cmbHoraFechaEntregaFin.SelectedIndex

        tipoEntrega = Integer.Parse(cmbTipoEntregaMercancia.SelectedValue.ToString())
        unidad = If(cmbUnidad.SelectedValue.ToString() <> "", Integer.Parse(cmbUnidad.SelectedValue.ToString()), 0)
        fechaInicio = dtpFechaEmbarqueDel.Value
        fechaFin = dtpFechaEmbarqueAl.Value

        tblResultadoAgenda = objBu.ConsultarCitasEmbarquesModoAgenda(tipoEntrega, unidad, fechaInicio, fechaFin, horaInicioAgenda, horaFinAgenda, EsYISTI)
        tblNumeroColumnasPorFecha = objBu.ConsultarNumeroColumnasPorFecha()

        totalFechas = Math.Abs(DateDiff(VisualBasic.DateInterval.Day, Date.Parse(fechaFin), Date.Parse(fechaInicio)))
        totalHoras = horaFinAgenda - horaInicioAgenda

        For dias As Integer = 0 To totalFechas
            listFechas.Add(fechaInicio.AddDays(dias).ToShortDateString())
        Next

        For hora As Integer = horaInicioAgenda To horaFinAgenda
            horaAgregar = If(hora < 10, "0" + hora.ToString(), hora.ToString()).ToString() + ":00"
            listHoras.Add(horaAgregar)
        Next


        Dim html As String = "<html>"
        html += "<head>"
        html += "<style>"
        html += ".datagrid table { border-collapse: collapse; text-align: left; width: 100%; }"
        html += ".datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #006699; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }"
        html += ".datagrid table td, .datagrid table th { padding: 0px 0px; }"
        html += ".datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #006699), color-stop(1, #00557F) );background:-moz-linear-gradient( center top, #006699 5%, #00557F 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#006699', endColorstr='#00557F');background-color:#006699; color:#FFFFFF; font-size: 13px; font-weight: bold; border-left: 0px solid #0070A8;text-align:center; } "
        html += ".datagrid table thead th:first-child { border: none; }"
        html += ".datagrid table tbody td { color: #00557F; border-left: 1px solid #00557F;font-size: 12px;border-bottom: 1px solid #E1EEF4;font-weight: normal; }"
        html += ".datagrid table tbody .alt td { background: #E1EEf4; color: #00557F; border-left: 1px solid  #00557F; }"
        html += ".datagrid table tbody td:first-child { border-left: none; }"
        html += ".datagrid table tbody tr:last-child td { border-bottom: none; }"
        html += ".datagrid table tbody tr:hover {background: #000;color: #EEE;}"
        html += ".columnaHoras {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #006699), color-stop(1, #00557F) );background:-moz-linear-gradient( center top, #006699 5%, #00557F 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#006699', endColorstr='#00557F');background-color:#006699; color:#FFFFFF !important; font-size: 13px; font-weight: bold; border-left: 0px solid #0070A8; } "
        html += "</style>"
        html += "</head>"
        html += "<body>"
        html += "<div class='datagrid'>"
        html += "<table border='1' cellspacing=0 cellpadding=0 style='text-align: center;border:1px solid black;'>"
        html += "<thead>"
        html += "<tr style='height:30px'>"
        html += "<th style='width: 60'>&nbsp;</th>"

        For Each fecha As String In listFechas
            encabezadoColumna = ""
            Select Case DateTime.Parse(fecha).DayOfWeek
                Case 0
                    diaSemana = "Do"
                Case 1
                    diaSemana = "Lu"
                Case 2
                    diaSemana = "Ma"
                Case 3
                    diaSemana = "Mi"
                Case 4
                    diaSemana = "Ju"
                Case 5
                    diaSemana = "Vi"
                Case 6
                    diaSemana = "Sa"
            End Select



            For Each row As DataRow In tblNumeroColumnasPorFecha.Rows
                If Split(row.Item("fecha").ToString(), " ")(0).ToString() = fecha Then
                    If fecha = Date.Now.ToShortDateString() Then
                        encabezadoColumna = "<th colspan='" + row.Item("totalColumnas").ToString() + "' style='background-color:ActiveCaption' >" + diaSemana + " " + fecha + "</th>"
                    Else
                        encabezadoColumna = "<th colspan='" + row.Item("totalColumnas").ToString() + "'>" + diaSemana + " " + fecha + "</th>"
                    End If
                    listFechasMasdeUnaColumna.Add(Split(row.Item("fecha").ToString(), " ")(0))
                End If
            Next
            If encabezadoColumna = "" Then
                If fecha = Date.Now.ToShortDateString() Then
                    html += "<th style='background-color:ActiveCaption'>" + diaSemana + " " + fecha + "</th>"
                Else
                    html += "<th>" + diaSemana + " " + fecha + "</th>"
                End If
            Else
                html += encabezadoColumna
            End If
        Next

        html += "</tr>"
        html += "</thead>"
        html += "<tbody>"

        For Each hora As String In listHoras
            html += "<tr>"
            If Replace(hora, ":00", "") <> If(DateTime.Now.Hour < 10, "0" + DateTime.Now.Hour.ToString(), DateTime.Now.Hour.ToString()) Then
                html += "<td class='columnaHoras' >" + hora + "</td>"
            Else
                html += "<td style='background-color:ActiveCaption' class='columnaHoras' >" + hora + "</td>"
            End If
            contadorColumnasColores = 0
            For Each fecha As String In listFechas
                tablaCita = ""
                listTablasCitasDias.Clear()
                totalColumnasFecha = 1
                For Each row As DataRow In tblNumeroColumnasPorFecha.Rows
                    If Split(row.Item("fecha").ToString(), " ")(0).ToString() = fecha Then
                        totalColumnasFecha = Integer.Parse(row.Item("totalColumnas").ToString())
                    End If
                Next

                For Each row As DataRow In tblResultadoAgenda.Rows
                    splitFechaEmbarque = Split(row.Item("FechaEmbarque").ToString(), " ")
                    splitFechaEmbarqueRegreso = Split(row.Item("FechaRegresoEmbarque").ToString(), " ")
                    If (splitFechaEmbarque(0).ToString() = fecha And row.Item("HorarioEmbarque").ToString() = Replace(hora, ":00", "")) Or (Date.Parse(splitFechaEmbarque(0).ToString()) <= Date.Parse(fecha) And Date.Parse(fecha) <= Date.Parse(splitFechaEmbarqueRegreso(0).ToString()) And Integer.Parse(row.Item("HorarioRegresoEmbarque").ToString()) >= Integer.Parse(Replace(hora, ":00", "")) And Integer.Parse(row.Item("HorarioEmbarque").ToString()) <= Integer.Parse(Replace(hora, ":00", ""))) Then
                        tablaCita = "<td style='text-align:center; border:1px solid gray; background:#E1EEf4; color:black; font-size:9px; width: 120;' cellspacing=0 cellpadding=0 rowspan='" + row.Item("Duracion").ToString() + "' ><font style='font-weight:bold;" + If(row.Item("Ocupada").ToString() = "1", "color:#0101DF;'", "'") + ">" + row.Item("Unidad").ToString() + "</font><br>" + row.Item("Cliente").ToString() + "<br>" + Double.Parse(row.Item("Pares")).ToString("n0") + " Pares</td>"
                        If listTablasCitasDiasGlobal.Contains(tablaCita) = False Then
                            listTablasCitasDias.Add(tablaCita)
                            listTablasCitasDiasGlobal.Add(tablaCita)
                        Else
                            If Integer.Parse(row.Item("HorarioRegresoEmbarque").ToString()) = Integer.Parse(Replace(hora, ":00", "")) And Integer.Parse(row.Item("MinutoRegresoEmbarque").ToString()) = 0 Then
                            Else
                                listTablasCitasDias.Add("")
                            End If
                        End If
                        tablaCita = ""
                    End If
                Next
                While listTablasCitasDias.Count < totalColumnasFecha
                    If contadorColumnasColores Mod 2 <> 0 Then
                        listTablasCitasDias.Add("<td style='background-color:#E6E6E6 !important;'>&nbsp;</td>")
                    Else
                        listTablasCitasDias.Add("<td>&nbsp;</td>")
                    End If
                End While
                For Each cita As String In listTablasCitasDias
                    html += cita
                Next
                contadorColumnasColores += 1
            Next
            html += "</tr>"
        Next

        html += "</tbody>"
        html += "</table>"
        html += "</body>"
        html += "</html>"

        Dim webbrowserprueba As New WebBrowser

        If webbrowserprueba.Document Is Nothing Then
            webbrowserprueba.Navigate("About: ")
        End If
        webbrowserprueba.Document.Write(html)

        webbrowserprueba.Dock = DockStyle.Fill

        pnlAgendaCalendario.Controls.Clear()
        pnlAgendaCalendario.Controls.Add(webbrowserprueba)

        Cursor = Cursors.Default
    End Sub




End Class