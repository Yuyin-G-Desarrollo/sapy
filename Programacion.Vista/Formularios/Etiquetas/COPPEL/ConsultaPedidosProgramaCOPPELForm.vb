Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports Tools
Imports System.IO
Imports Stimulsoft.Report

Public Class ConsultaPedidosProgramaCOPPELForm

    Dim objBu As New Programacion.Negocios.EtiquetasBU

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCargarArchivo_Click(sender As Object, e As EventArgs) Handles btnCargarArchivo.Click
        Dim EtiquetaCOPPEL As New ImpresionEtiquetasCOPPELForm
        'Asigna a los texbox lo correspondiente de la consulta
        If grdVConsultaDeLotes.FocusedRowHandle >= 0 Then
            EtiquetaCOPPEL.PedidoSAY = grdVConsultaDeLotes.GetFocusedRowCellValue("PedidoSAY")
            EtiquetaCOPPEL.PedidoSICY = grdVConsultaDeLotes.GetFocusedRowCellValue("PedidoSICY")
            EtiquetaCOPPEL.PedidoCliente = grdVConsultaDeLotes.GetFocusedRowCellValue("Orden")
            EtiquetaCOPPEL.Programado = grdVConsultaDeLotes.GetFocusedRowCellValue("Programado")
            EtiquetaCOPPEL.FechaPrograma = CDate(dtmFechaInicioPrograma.Value)
            EtiquetaCOPPEL.NaveSICYId = grdVConsultaDeLotes.GetFocusedRowCellValue("IdNave")
            EtiquetaCOPPEL.ShowDialog()
        Else
            show_message("Advertencia", "No se ha seleccionado un pedido.")
        End If

        
    End Sub

    Private Sub ConsultaPedidosProgramaCOPPELForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim dt As DataTable
        'Dim objNegocio As Programacion.Negocios.EtiquetasBU
        'objNegocio = New Programacion.Negocios.EtiquetasBU
        'dt = objNegocio.ConsultarNavesSICY()
        'cmbNave.DataSource = dt
        'cmbNave.ValueMember = "idNave"
        'cmbNave.DisplayMember = "nave"

        dtmFechaInicioPrograma.Value = Now.ToShortDateString
        dtmFechaFinPrograma.Value = Now.ToShortDateString
        lblTotalSeleccionados.Text = "0"
        cargarNaves()
        CargarGrid()
        DiseñoGrid()
        WindowState = FormWindowState.Maximized

    End Sub

    Private Sub CargarNaves()
        Dim DTNAves As DataTable
        DTNAves = objBU.ConsultarNavesProduccion()
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
        cmbNave.DataSource = DTNAves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "NaveSICYID"

    End Sub

    'Private Sub cargarNaves()

    '    'cmbNave = Tools.Controles.ComboNavesSegunUsuarioConIdSIcy(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


    'End Sub

    Public Sub CargarGrid()
        Dim dtInformacion As DataTable
        If cmbNave.SelectedIndex = 0 Then
            dtInformacion = objBu.EtiquetasPedidosCoppel(dtmFechaInicioPrograma.Value, 0) 'dtmFechaFinPrograma.Value,
        Else
            dtInformacion = objBu.EtiquetasPedidosCoppel(dtmFechaInicioPrograma.Value, cmbNave.SelectedValue) 'dtmFechaFinPrograma.Value,
        End If

        grdConsultaDeLotes.DataSource = dtInformacion

        lblTotalSeleccionados.Text = CDbl(grdVConsultaDeLotes.DataRowCount).ToString("N0")
        'Asigna fecha actual a lbl de actualizacion
        lblFechaUltimaActualizacion.Text = Date.Now.ToString()

    End Sub


    Public Sub DiseñoGrid()
        'acomoda las columnas del ancho automaticamente
        grdVConsultaDeLotes.BestFitColumns()

        'Cambio de color por cada Row
        'Para funcionamiento hay que asignarle el color desde el grid (RunDesinger Aparence *EvenRow = White *OddRow = ActiveCaption)
        grdVConsultaDeLotes.OptionsView.EnableAppearanceEvenRow = True
        grdVConsultaDeLotes.OptionsView.EnableAppearanceOddRow = True

        grdVConsultaDeLotes.Appearance.EvenRow.BackColor = Color.White
        grdVConsultaDeLotes.Appearance.OddRow.BackColor = SystemColors.ActiveCaption

        grdVConsultaDeLotes.Appearance.FocusedRow.BackColor = Color.FromArgb(0, 120, 215)
        grdVConsultaDeLotes.Appearance.FocusedRow.ForeColor = Color.White

        grdVConsultaDeLotes.Appearance.FocusedCell.BackColor = Color.FromArgb(0, 120, 215)
        grdVConsultaDeLotes.Appearance.FocusedCell.ForeColor = Color.White


        'Esconde idColumnas
        grdVConsultaDeLotes.Columns(" ").Visible = False
        grdVConsultaDeLotes.Columns("PedidoSICY").Visible = True
        grdVConsultaDeLotes.Columns("PedidoSAY").Visible = True
        grdVConsultaDeLotes.Columns("Orden").Visible = True
        grdVConsultaDeLotes.Columns("Cliente").Visible = True
        grdVConsultaDeLotes.Columns("Cantidad").Visible = True
        grdVConsultaDeLotes.Columns("Nave").Visible = True
        grdVConsultaDeLotes.Columns("Programado").Visible = True
        grdVConsultaDeLotes.Columns("stPedido").Visible = True
        grdVConsultaDeLotes.Columns("Fecha").Visible = False
        grdVConsultaDeLotes.Columns("EntregaCliente").Visible = True
        grdVConsultaDeLotes.Columns("FechaPrograma").Visible = True
        grdVConsultaDeLotes.Columns("IdNave").Visible = False

        'habilita si se van a editar o no los valores de la columna con el nombre que tiene        
        grdVConsultaDeLotes.Columns("PedidoSICY").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("PedidoSAY").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("Orden").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("Cliente").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("Cantidad").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("Nave").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("Programado").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("stPedido").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("EntregaCliente").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("FechaPrograma").OptionsColumn.AllowEdit = False
        grdVConsultaDeLotes.Columns("IdNave").OptionsColumn.AllowEdit = False

        'acomoda el nombre de la columna centrado
        grdVConsultaDeLotes.Columns("PedidoSICY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("PedidoSAY").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("Orden").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("Cliente").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("Nave").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("Cantidad").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("Programado").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("stPedido").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("EntregaCliente").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
        grdVConsultaDeLotes.Columns("FechaPrograma").AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center

        ''Para que haga la busqueda por lo que contiene        
        grdVConsultaDeLotes.Columns("PedidoSICY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdVConsultaDeLotes.Columns("PedidoSAY").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdVConsultaDeLotes.Columns("Orden").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdVConsultaDeLotes.Columns("Cliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdVConsultaDeLotes.Columns("Nave").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        grdVConsultaDeLotes.Columns("EntregaCliente").OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains



        ''Asigna nombre a la Columna
        grdVConsultaDeLotes.Columns("PedidoSICY").Caption = "P.SICY"
        grdVConsultaDeLotes.Columns("PedidoSAY").Caption = "P.SAY"
        grdVConsultaDeLotes.Columns("Orden").Caption = "Ped. Cliente"
        grdVConsultaDeLotes.Columns("Cliente").Caption = "Cliente"
        grdVConsultaDeLotes.Columns("Nave").Caption = "Nave"
        grdVConsultaDeLotes.Columns("Cantidad").Caption = "Cantidad Pares"
        grdVConsultaDeLotes.Columns("Programado").Caption = "Programado"
        grdVConsultaDeLotes.Columns("stPedido").Caption = "Estatus Pedido"
        grdVConsultaDeLotes.Columns("EntregaCliente").Caption = "F.Entrega"
        grdVConsultaDeLotes.Columns("FechaPrograma").Caption = "F.Programado"



        ''Realiza la suma, conteo del registro por columna--------------------------------------------------------------------
        grdVConsultaDeLotes.OptionsView.ShowFooter = GroupFooterShowMode.Hidden
        If IsNothing(grdVConsultaDeLotes.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
            grdVConsultaDeLotes.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
        End If

        If IsNothing(grdVConsultaDeLotes.Columns("Programado").Summary.FirstOrDefault(Function(x) x.FieldName = "Programado")) = True Then
            grdVConsultaDeLotes.Columns("Programado").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Programado", "{0:N0}")
        End If

        'If IsNothing(grdVConsultaDeLotes.Columns("PedidoSICY").Summary.FirstOrDefault(Function(x) x.FieldName = "PedidoSICY")) = True Then
        '    grdVConsultaDeLotes.Columns("PedidoSICY").Summary.Add(DevExpress.Data.SummaryItemType.Count, "PedidoSICY", "{0:N0}")
        'End If

        ''Dar formato de numeros (Numeric)
        grdVConsultaDeLotes.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        grdVConsultaDeLotes.Columns.ColumnByFieldName("Programado").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        ''Dar formato de , entre numeros
        grdVConsultaDeLotes.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
        grdVConsultaDeLotes.Columns.ColumnByFieldName("Programado").DisplayFormat.FormatString = "N0"

        grdVConsultaDeLotes.Columns.ColumnByFieldName("Cantidad").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        grdVConsultaDeLotes.Columns.ColumnByFieldName("Programado").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        'Footer para sumatorias
        grdVConsultaDeLotes.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


        'If IsNothing(grdVConsultaDeLotes.Columns("Cantidad").Summary.FirstOrDefault(Function(x) x.FieldName = "Cantidad")) = True Then
        '    grdVConsultaDeLotes.Columns("Cantidad").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Cantidad", "{0:N0}")
        '    Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        '    item.FieldName = "Cantidad"
        '    item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '    item.DisplayFormat = "{0}"
        '    grdVConsultaDeLotes.GroupSummary.Add(item)
        'End If

        'Pone el color de fondo salteado de color blacno y azul
        'For i As Integer = 1 To grdVConsultaDeLotes.RowCount - 1
        '    If i Mod 2 = 0 Then
        '        'GridView1.OptionsView.EnableAppearanceOddRow = Color.LightSteelBlue
        '        'grdVConsultaDeLotes.Appearance.EvenRow.BackColor = Color.LightSteelBlue
        '        grdVConsultaDeLotes.Appearance.EvenRow.BackColor = Color.DarkBlue
        '        grdVConsultaDeLotes.OptionsView.EnableAppearanceOddRow = True
        '        grdVConsultaDeLotes.Invalidate()
        '    End If
        'Next

        'Agrupamiento por columna
        'grdVConsultaDeLotes.OptionsView.AllowCellMerge = True
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Try
            Cursor = Cursors.WaitCursor
            grdConsultaDeLotes.DataSource = Nothing
            CargarGrid()
            DiseñoGrid()

            If grdVConsultaDeLotes.DataRowCount = 0 Then
                show_message("Advertencia", "No existe información para mostrar en el rango de fecha seleccionada.")
            End If
            'Asigna cantidad de renglones del grid

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al cargar la información.")
        End Try

    End Sub

    Private Sub dtpFechaDel_ValueChanged(sender As Object, e As EventArgs) Handles dtmFechaInicioPrograma.ValueChanged
        'No permite poner fecha previa de la seleccionada
        dtmFechaFinPrograma.MinDate = dtmFechaInicioPrograma.Value
        grdConsultaDeLotes.DataSource = Nothing
        lblTotalSeleccionados.Text = "0"
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then

            Dim mensajeAdvertencia As New AdvertenciaForm
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



    'Public Sub imprimirReporte()
    '    Dim objReporte As New Framework.Negocios.ReportesBU
    '    Dim entReporte As New Entidades.Reportes
    '    Dim dsPedidosCOPPEL As New DataSet("dsPedidosCOPPEL")
    '    Dim dtProgramas As DataTable
    '    Dim dtNavesPrograma As DataTable
    '    Dim dtPedidosCOPPEL As DataTable
    '    Dim dtDetallesPedidoCOPPEL As DataTable
    '    Dim dtParesPedidoCOPPEL As DataTable
    '    Dim dtParesNaveProgramaCOPPEL As DataTable
    '    Dim ReportePedidoCOPPEL As New StiReport
    '    'Dim objbu As New Programacion.Negocios.EtiquetasCOPPELBU

    '    Dim dtProgramasAux As DataTable
    '    Dim dtNavesProgramaAux As DataTable
    '    Dim dtPedidosCOPPELAux As DataTable
    '    Dim dtDetallesPedidoCOPPELAux As DataTable
    '    Dim dtParesPedidoCOPPELAux As DataTable
    '    Dim dtParesNaveProgramaCOPPELAux As DataTable
    '    Dim NaveId As Integer = 0
    '    Dim DTNAves As DataTable
    '    Dim NaveSAY As Integer = 0
    '    Try

    '        Cursor = Cursors.WaitCursor


    '        DTNAves = objBu.ConsultarNavesProduccion()

    '        Dim tool As New Tools.Controles

    '        If cmbNave.SelectedIndex > 0 Then
    '            NaveId = cmbNave.SelectedValue
    '        Else
    '            NaveId = 0
    '        End If


    '        dtProgramas = New DataTable("dtProgramas")
    '        With dtProgramas
    '            .Columns.Add("ProgramaID")
    '            .Columns.Add("Programa")
    '        End With

    '        dtProgramasAux = objBu.ReporteCOPPEL_ConsultaProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value)

    '        For Each Fila As DataRow In dtProgramasAux.Rows
    '            dtProgramas.Rows.Add(Fila.Item(0).ToString, FormatoFechaPrograma(Fila.Item(1).ToString))
    '        Next

    '        dtNavesPrograma = New DataTable("dtNavesPrograma")
    '        With dtNavesPrograma
    '            .Columns.Add("ProgramaID")
    '            .Columns.Add("NaveId")
    '            .Columns.Add("NombreNave")
    '            .Columns.Add("TotalPares")
    '        End With

    '        dtNavesProgramaAux = objBu.ReporteCOPPEL_ConsultaNaveProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

    '        For Each Fila As DataRow In dtNavesProgramaAux.Rows
    '            dtNavesPrograma.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), Fila.Item(3).ToString())
    '        Next

    '        dtParesNaveProgramaCOPPEL = New DataTable("dtParesNaveProgramaCOPPEL")
    '        With dtParesNaveProgramaCOPPEL
    '            .Columns.Add("ProgramaID")
    '            .Columns.Add("NaveID")
    '            .Columns.Add("TotalPares")
    '        End With

    '        dtParesNaveProgramaCOPPELAux = objBu.ReporteCOPPEL_ConsultaParesNaveProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

    '        For Each Fila As DataRow In dtParesNaveProgramaCOPPELAux.Rows
    '            dtParesNaveProgramaCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, CDbl(Fila.Item(2).ToString()).ToString("N0"))
    '        Next

    '        dtPedidosCOPPEL = New DataTable("dtPedidosCOPPEL")
    '        With dtPedidosCOPPEL
    '            .Columns.Add("ProgramaID")
    '            .Columns.Add("NaveID")
    '            .Columns.Add("PedidoCliente")
    '            .Columns.Add("PedidoSAY")
    '            .Columns.Add("PedidoSICY")
    '            .Columns.Add("TotalPares")
    '        End With

    '        dtPedidosCOPPELAux = objBu.ReporteCOPPEL_ConsultaPedidosProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

    '        For Each Fila As DataRow In dtPedidosCOPPELAux.Rows
    '            dtPedidosCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), Fila.Item(3).ToString, Fila.Item(4).ToString(), Fila.Item(5).ToString())
    '        Next

    '        dtParesPedidoCOPPEL = New DataTable("dtParesPedidoCOPPEL")
    '        With dtParesPedidoCOPPEL
    '            .Columns.Add("ProgramaID")
    '            .Columns.Add("NaveID")
    '            .Columns.Add("PedidoCliente")
    '            .Columns.Add("TotalPares")
    '        End With

    '        dtParesPedidoCOPPELAux = objBu.ReporteCOPPEL_ConsultaParesPedidosProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

    '        For Each Fila As DataRow In dtParesPedidoCOPPELAux.Rows
    '            dtParesPedidoCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), CDbl(Fila.Item(3).ToString).ToString("N0"))
    '        Next

    '        dtDetallesPedidoCOPPEL = New DataTable("dtDetallesPedidoCOPPEL")
    '        With dtDetallesPedidoCOPPEL
    '            .Columns.Add("ProgramaID")
    '            .Columns.Add("NaveID")
    '            .Columns.Add("PedidoCliente")
    '            .Columns.Add("CodigoCliente")
    '            .Columns.Add("ColeccionModelo")
    '            .Columns.Add("Linea")
    '            .Columns.Add("Tallas")
    '            .Columns.Add("Pares")
    '            .Columns.Add("EtiquetasImpresas")
    '        End With

    '        dtDetallesPedidoCOPPELAux = objBu.ReporteCOPPEL_ConsultaDetallesPedidosProgramas(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value, NaveId)

    '        For Each Fila As DataRow In dtDetallesPedidoCOPPELAux.Rows
    '            dtDetallesPedidoCOPPEL.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString, Fila.Item(2).ToString(), Fila.Item(3).ToString, Fila.Item(4).ToString, Fila.Item(5).ToString, Fila.Item(6).ToString, Fila.Item(7).ToString, Fila.Item(8).ToString)
    '        Next

    '        dsPedidosCOPPEL.Tables.Add(dtProgramas)
    '        dsPedidosCOPPEL.Tables.Add(dtNavesPrograma)
    '        dsPedidosCOPPEL.Tables.Add(dtPedidosCOPPEL)
    '        dsPedidosCOPPEL.Tables.Add(dtDetallesPedidoCOPPEL)
    '        dsPedidosCOPPEL.Tables.Add(dtParesPedidoCOPPEL)
    '        dsPedidosCOPPEL.Tables.Add(dtParesNaveProgramaCOPPEL)

    '        entReporte = objReporte.LeerReporteporClave("PROG_ETIQUETAS_PEDIDO_COPPEL")

    '        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
    '            LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
    '        My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


    '        ReportePedidoCOPPEL.Load(archivo)
    '        ReportePedidoCOPPEL.Compile()
    '        ReportePedidoCOPPEL.RegData(dsPedidosCOPPEL)
    '        ReportePedidoCOPPEL("UsuarioImprimio") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString()
    '        ReportePedidoCOPPEL("FechaImpresion") = FormatoFechaPrograma(Date.Now)
    '        ReportePedidoCOPPEL("FechasRangoPrograma") = ObtenerTituloInforme(dtmFechaInicioPrograma.Value, dtmFechaFinPrograma.Value)
    '        If cmbNave.SelectedIndex = 0 Then
    '            ReportePedidoCOPPEL("RutaImagenNave") = Tools.Controles.ObtenerLogoNave(43)
    '        Else
    '            NaveSAY = DTNAves.AsEnumerable.Where(Function(x) x.Item("NaveSICYID") = cmbNave.SelectedValue).Select(Function(y) y.Item("NaveSAYId")).FirstOrDefault()

    '            ReportePedidoCOPPEL("RutaImagenNave") = Tools.Controles.ObtenerLogoNave(NaveSAY)
    '        End If

    '        ReportePedidoCOPPEL.Dictionary.Clear()
    '        ReportePedidoCOPPEL.Dictionary.Synchronize()
    '        'reporteUnaTienda.Render()
    '        ReportePedidoCOPPEL.Show()


    '        Cursor = Cursors.Default
    '    Catch ex As Exception
    '        Cursor = Cursors.Default
    '        show_message("Error", ex.Message.ToString())
    '    End Try

    'End Sub

    'Private Function FormatoFechaPrograma(ByVal Fecha As Date) As String
    '    Dim FormatoFecha As String = String.Empty
    '    Dim NombreDia As String = String.Empty
    '    Dim NombreMes As String = String.Empty

    '    If Fecha.DayOfWeek = DayOfWeek.Sunday Then
    '        NombreDia = "Domingo"
    '    ElseIf Fecha.DayOfWeek = DayOfWeek.Monday Then
    '        NombreDia = "Lunes"
    '    ElseIf Fecha.DayOfWeek = DayOfWeek.Tuesday Then
    '        NombreDia = "Martes"
    '    ElseIf Fecha.DayOfWeek = DayOfWeek.Wednesday Then
    '        NombreDia = "Miércoles"
    '    ElseIf Fecha.DayOfWeek = DayOfWeek.Thursday Then
    '        NombreDia = "Jueves"
    '    ElseIf Fecha.DayOfWeek = DayOfWeek.Friday Then
    '        NombreDia = "Viernes"
    '    ElseIf Fecha.DayOfWeek = DayOfWeek.Saturday Then
    '        NombreDia = "Sabado"
    '    End If

    '    If Fecha.Month = 1 Then
    '        NombreMes = "enero"
    '    ElseIf Fecha.Month = 2 Then
    '        NombreMes = "febrero"
    '    ElseIf Fecha.Month = 3 Then
    '        NombreMes = "marzo"
    '    ElseIf Fecha.Month = 4 Then
    '        NombreMes = "abril"
    '    ElseIf Fecha.Month = 5 Then
    '        NombreMes = "mayo"
    '    ElseIf Fecha.Month = 6 Then
    '        NombreMes = "junio"
    '    ElseIf Fecha.Month = 7 Then
    '        NombreMes = "julio"
    '    ElseIf Fecha.Month = 8 Then
    '        NombreMes = "agosto"
    '    ElseIf Fecha.Month = 9 Then
    '        NombreMes = "septiembre"
    '    ElseIf Fecha.Month = 10 Then
    '        NombreMes = "octubre"
    '    ElseIf Fecha.Month = 11 Then
    '        NombreMes = "noviembre"
    '    ElseIf Fecha.Month = 12 Then
    '        NombreMes = "diciembre"
    '    End If

    '    FormatoFecha = NombreDia & ", " & Fecha.Day.ToString & " de " & NombreMes & " de " & Fecha.Year.ToString()


    '    Return FormatoFecha

    'End Function

    'Private Function ObtenerTituloInforme(ByVal FechaInicio As Date, ByVal FechaFin As Date) As String
    '    Dim FormatoFecha As String = String.Empty
    '    Dim NombreDia As String = String.Empty
    '    Dim NombreMes As String = String.Empty

    '    Dim NombreDiaFin As String = String.Empty
    '    Dim NombreMesFin As String = String.Empty

    '    If FechaInicio.DayOfWeek = DayOfWeek.Sunday Then
    '        NombreDia = "Domingo"
    '    ElseIf FechaInicio.DayOfWeek = DayOfWeek.Monday Then
    '        NombreDia = "Lunes"
    '    ElseIf FechaInicio.DayOfWeek = DayOfWeek.Tuesday Then
    '        NombreDia = "Martes"
    '    ElseIf FechaInicio.DayOfWeek = DayOfWeek.Wednesday Then
    '        NombreDia = "Miércoles"
    '    ElseIf FechaInicio.DayOfWeek = DayOfWeek.Thursday Then
    '        NombreDia = "Jueves"
    '    ElseIf FechaInicio.DayOfWeek = DayOfWeek.Friday Then
    '        NombreDia = "Viernes"
    '    ElseIf FechaInicio.DayOfWeek = DayOfWeek.Saturday Then
    '        NombreDia = "Sabado"
    '    End If

    '    If FechaInicio.Month = 1 Then
    '        NombreMes = "enero"
    '    ElseIf FechaInicio.Month = 2 Then
    '        NombreMes = "febrero"
    '    ElseIf FechaInicio.Month = 3 Then
    '        NombreMes = "marzo"
    '    ElseIf FechaInicio.Month = 4 Then
    '        NombreMes = "abril"
    '    ElseIf FechaInicio.Month = 5 Then
    '        NombreMes = "mayo"
    '    ElseIf FechaInicio.Month = 6 Then
    '        NombreMes = "junio"
    '    ElseIf FechaInicio.Month = 7 Then
    '        NombreMes = "julio"
    '    ElseIf FechaInicio.Month = 8 Then
    '        NombreMes = "agosto"
    '    ElseIf FechaInicio.Month = 9 Then
    '        NombreMes = "septiembre"
    '    ElseIf FechaInicio.Month = 10 Then
    '        NombreMes = "octubre"
    '    ElseIf FechaInicio.Month = 11 Then
    '        NombreMes = "noviembre"
    '    ElseIf FechaInicio.Month = 12 Then
    '        NombreMes = "diciembre"
    '    End If

    '    If FechaFin.DayOfWeek = DayOfWeek.Sunday Then
    '        NombreDiaFin = "Domingo"
    '    ElseIf FechaFin.DayOfWeek = DayOfWeek.Monday Then
    '        NombreDiaFin = "Lunes"
    '    ElseIf FechaFin.DayOfWeek = DayOfWeek.Tuesday Then
    '        NombreDiaFin = "Martes"
    '    ElseIf FechaFin.DayOfWeek = DayOfWeek.Wednesday Then
    '        NombreDiaFin = "Miércoles"
    '    ElseIf FechaFin.DayOfWeek = DayOfWeek.Thursday Then
    '        NombreDiaFin = "Jueves"
    '    ElseIf FechaFin.DayOfWeek = DayOfWeek.Friday Then
    '        NombreDiaFin = "Viernes"
    '    ElseIf FechaFin.DayOfWeek = DayOfWeek.Saturday Then
    '        NombreDiaFin = "Sabado"
    '    End If

    '    If FechaFin.Month = 1 Then
    '        NombreMesFin = "enero"
    '    ElseIf FechaFin.Month = 2 Then
    '        NombreMesFin = "febrero"
    '    ElseIf FechaFin.Month = 3 Then
    '        NombreMesFin = "marzo"
    '    ElseIf FechaFin.Month = 4 Then
    '        NombreMesFin = "abril"
    '    ElseIf FechaFin.Month = 5 Then
    '        NombreMesFin = "mayo"
    '    ElseIf FechaFin.Month = 6 Then
    '        NombreMesFin = "junio"
    '    ElseIf FechaFin.Month = 7 Then
    '        NombreMesFin = "julio"
    '    ElseIf FechaFin.Month = 8 Then
    '        NombreMesFin = "agosto"
    '    ElseIf FechaFin.Month = 9 Then
    '        NombreMesFin = "septiembre"
    '    ElseIf FechaFin.Month = 10 Then
    '        NombreMesFin = "octubre"
    '    ElseIf FechaFin.Month = 11 Then
    '        NombreMesFin = "noviembre"
    '    ElseIf FechaFin.Month = 12 Then
    '        NombreMesFin = "diciembre"
    '    End If

    '    FormatoFecha = "Del " & NombreDia & ", " & FechaInicio.Day.ToString() & " de " & NombreMes & " del " & FechaInicio.Year.ToString() & " al " & NombreDiaFin.ToString() & ", " & FechaFin.Day.ToString & " de " & NombreMesFin & " del " & FechaFin.Year.ToString
    '    Return FormatoFecha
    'End Function

    Private Sub btnImprimirReportePedidos_Click(sender As Object, e As EventArgs) Handles btnImprimirReportePedidos.Click
        Dim ReporteCoppel As New ReporteCoppelForm
        ReporteCoppel.ShowDialog()
        'imprimirReporte()
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdConsultaDeLotes.DataSource = Nothing
        lblTotalSeleccionados.Text = "0"
    End Sub

    Private Sub btnConfigurar_Click(sender As Object, e As EventArgs) Handles btnConfigurar.Click
        Dim obj As New ConfigurarClienteColeccionEtiquetaCoppelForm
        obj.MdiParent = Me.MdiParent
        obj.Show()
    End Sub
End Class