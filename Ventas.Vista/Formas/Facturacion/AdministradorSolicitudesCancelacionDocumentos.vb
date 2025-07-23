Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraPrinting
Imports ToolServicios

Public Class AdministradorSolicitudesCancelacionDocumentos
    Dim errormensaje As New ErroresForm
    Dim objMensajeValido As New Tools.AvisoForm
    Dim objMensajeExito As New Tools.ExitoForm

    Dim ObjBU As New Negocios.SolicitarCancelacionBU

    Dim lstFiltroFactura As New List(Of String)
    Dim lstInicial As New List(Of String)

    Private Sub AdministradorSolicitudesCancelacionDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Cursor = Cursors.WaitCursor
        ObtenerCEDISUsuario()

        dtpFechaInicio.Value = Date.Now
        dtpFechaFin.Value = Date.Now
        chkFecha_CheckedChanged(Nothing, Nothing)

        grdStatus.DataSource = lstInicial
        grdFactura.DataSource = lstInicial
        grdCliente.DataSource = lstInicial
        grdEmisor.DataSource = lstInicial
        grdReceptor.DataSource = lstInicial
        grdMotivoInterno.DataSource = lstInicial
        grdSolicitaInterno.DataSource = lstInicial
        grdFolioFactura.DataSource = lstInicial
        chkFecha.Checked = False
        Cursor = Cursors.Default

    End Sub





    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        If ConsultarSolicitudesCancelacion() = 1 Then
            btnArriba_Click(sender, e)
            DiseñoGridSolicitudCancelacion()
            lblFechaUltimaActualización.Text = DateTime.Now.ToString()
        End If

        Cursor = Cursors.Default
    End Sub


    Private Sub DiseñoGridSolicitudCancelacion()
        bgvCancelaciones.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvCancelaciones.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Next
        ''OCULTAR COLUMNAS 
        bgvCancelaciones.Columns.ColumnByFieldName("añoAnterior").Visible = False
        bgvCancelaciones.Columns.ColumnByFieldName("idMotivoInterno").Visible = False
        bgvCancelaciones.Columns.ColumnByFieldName("EstatusID").Visible = False
        'bgvDocumentos.Columns.ColumnByFieldName("Saldo").Visible = False

        ''FORMATO DE NUMERO
        bgvCancelaciones.Columns.ColumnByFieldName("Importe factura").DisplayFormat.FormatString = "###,##0.00"
        'bgvCancelaciones.Columns.ColumnByFieldName("Importe factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        ''FORMATO DE FECHA
        bgvCancelaciones.Columns.ColumnByFieldName("F.solicitud").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCancelaciones.Columns.ColumnByFieldName("F.Emision factura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCancelaciones.Columns.ColumnByFieldName("F. Autorización").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCancelaciones.Columns.ColumnByFieldName("F. Autorización").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"

        bgvCancelaciones.Columns.ColumnByFieldName("F.Rechazo").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        bgvCancelaciones.Columns.ColumnByFieldName("F.Rechazo").DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss"

        ''ANCHO
        bgvCancelaciones.Columns.ColumnByFieldName(" ").Width = 30
        bgvCancelaciones.Columns.ColumnByFieldName("ST").Width = 25
        bgvCancelaciones.Columns.ColumnByFieldName("Solicitud").Width = 50
        bgvCancelaciones.Columns.ColumnByFieldName("Estatus solicitud").Width = 150
        bgvCancelaciones.Columns.ColumnByFieldName("Se relaciona").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Cliente").Width = 250
        bgvCancelaciones.Columns.ColumnByFieldName("Factura").Width = 70
        bgvCancelaciones.Columns.ColumnByFieldName("Folio fiscal").Width = 250
        bgvCancelaciones.Columns.ColumnByFieldName("Estatus factura").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("F.solicitud").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario Creo").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("F.Emision factura").Width = 100
        bgvCancelaciones.Columns.ColumnByFieldName("Motivo cancelación").Width = 250
        bgvCancelaciones.Columns.ColumnByFieldName("Quien solicita").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Solicita").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("Observaciones solicitud").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("Emisor").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("RFC Emisor").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Receptor").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("RFC Receptor").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Importe factura").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Multa").Width = 150
        bgvCancelaciones.Columns.ColumnByFieldName("Folio fiscal nueva factura").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("Folio interno nueva factura").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Importe nueva factura").Width = 200
        bgvCancelaciones.Columns.ColumnByFieldName("F. Autorización").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario autorizo").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("F.Rechazo").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario rechazo").Width = 90
        bgvCancelaciones.Columns.ColumnByFieldName("Observaciones rechazo").Width = 300

        bgvCancelaciones.Columns.ColumnByFieldName(" ").OptionsColumn.AllowEdit = True
        bgvCancelaciones.Columns.ColumnByFieldName("ST").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Solicitud").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Estatus solicitud").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Se relaciona").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Cliente").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Folio fiscal").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Estatus factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("F.solicitud").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario Creo").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("F.Emision factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Motivo cancelación").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Quien solicita").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Solicita").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Observaciones solicitud").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Emisor").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("RFC Emisor").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Receptor").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("RFC Receptor").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Importe factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Multa").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Folio fiscal nueva factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Folio interno nueva factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Importe nueva factura").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("F. Autorización").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario autorizo").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("F.Rechazo").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario rechazo").OptionsColumn.AllowEdit = False
        bgvCancelaciones.Columns.ColumnByFieldName("Observaciones rechazo").OptionsColumn.AllowEdit = False

        bgvCancelaciones.Columns.ColumnByFieldName(" ").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("ST").OptionsFilter.AllowFilter = False
        bgvCancelaciones.Columns.ColumnByFieldName("Solicitud").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Estatus solicitud").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Se relaciona").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Folio fiscal").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Estatus factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("F.solicitud").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario Creo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("F.Emision factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Motivo cancelación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Quien solicita").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Solicita").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Observaciones solicitud").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Emisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("RFC Emisor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Receptor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("RFC Receptor").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Importe factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Multa").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Folio fiscal nueva factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Folio interno nueva factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Importe nueva factura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("F. Autorización").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario autorizo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("F.Rechazo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Usuario rechazo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
        bgvCancelaciones.Columns.ColumnByFieldName("Observaciones rechazo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

        bgvCancelaciones.IndicatorWidth = 40

    End Sub


    Private Function ConsultarSolicitudesCancelacion() As Integer
        Dim dtResultadoAdministrador As New DataTable
        Dim objFiltrosAdministrador = ObtenerFiltrosAdministradoSolicitudCancelacion()
        Dim dtActualiza As New DataTable
        Dim resultadoConsulta = 0
        dtResultadoAdministrador = ObjBU.ConsultarSolicitudesCancelacionFactura(objFiltrosAdministrador)
        grdCancelaciones.DataSource = Nothing

        If dtResultadoAdministrador.Rows.Count > 0 Then
            grdCancelaciones.DataSource = dtResultadoAdministrador
            ' DiseñoGridCancelaciones()
            resultadoConsulta = 1
        Else
            objMensajeValido.Text = "Aviso"
            objMensajeValido.mensaje = "No hay datos para mostrar."
            objMensajeValido.ShowDialog()
        End If

        lblTotalRegistros.Text = dtResultadoAdministrador.Rows.Count.ToString("N0")
        Return resultadoConsulta
    End Function

    Private Function ObtenerFiltrosAdministradoSolicitudCancelacion() As Entidades.FiltrosAdministradorSoliciturCancelacion
        Dim objFiltrosAdministrador As New Entidades.FiltrosAdministradorSoliciturCancelacion
        Dim tipoFecha As Integer = 0

        If chkFecha.Checked Then
            If rdoFechaSolicitud.Checked Then
                tipoFecha = 1
            Else
                If rdoFechaAutorizacion.Checked Then
                    tipoFecha = 2
                Else
                    If rbtnFechaRechazo.Checked Then
                        tipoFecha = 3
                    Else
                        If rbtnFechaFactura.Checked Then
                            tipoFecha = 4
                        End If
                    End If
                End If
            End If
        Else
            tipoFecha = 0
        End If


        objFiltrosAdministrador.TipoFecha = tipoFecha

        If chkFecha.Checked Then
            objFiltrosAdministrador.FechaInicio = dtpFechaInicio.Value.ToShortDateString()
            objFiltrosAdministrador.FechaFin = dtpFechaFin.Value.ToShortDateString()
        Else
            objFiltrosAdministrador.FechaInicio = ""
            objFiltrosAdministrador.FechaFin = ""
        End If
        objFiltrosAdministrador.StatusID = ObtenerFiltrosGrid(grdStatus)
        objFiltrosAdministrador.FacturaID = ObtenerFiltrosGrid(grdFactura)
        objFiltrosAdministrador.FacturaID = ObtenerFiltrosGrid(grdFactura)
        objFiltrosAdministrador.FolioFacturaID = ObtenerFiltrosGrid(grdFolioFactura)
        objFiltrosAdministrador.Clienteid = ObtenerFiltrosGrid(grdCliente)
        objFiltrosAdministrador.EmisorID = ObtenerFiltrosGrid(grdEmisor)
        objFiltrosAdministrador.ReceptorID = ObtenerFiltrosGrid(grdReceptor)
        objFiltrosAdministrador.MotivoInterno = ObtenerFiltrosGrid(grdMotivoInterno)
        objFiltrosAdministrador.SolicitaInterno = ObtenerFiltrosGrid(grdSolicitaInterno)
        objFiltrosAdministrador.CedisId = cmbCEDIS.SelectedValue


        Return objFiltrosAdministrador

    End Function

    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String

        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += Replace(row.Cells(0).Text, ",", "")
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "")
            End If
        Next

        Return Resultado

    End Function

    Private Sub txtFiltroFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFactura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFactura.Text) Then Return

            lstFiltroFactura.Add(txtFiltroFactura.Text)
            grdFactura.DataSource = Nothing
            grdFactura.DataSource = lstFiltroFactura

            txtFiltroFactura.Text = String.Empty

        End If
    End Sub

    Private Sub txtFiltroFolioFactura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioFactura.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioFactura.Text) Then Return

            lstFiltroFactura.Add(txtFiltroFolioFactura.Text)
            grdFolioFactura.DataSource = Nothing
            grdFolioFactura.DataSource = lstFiltroFactura

            txtFiltroFolioFactura.Text = String.Empty

        End If
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(4).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdCliente.DataSource = lstInicial
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroE.Click
        grdEmisor.DataSource = lstInicial
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        grdCliente.DataSource = lstInicial
    End Sub

    Private Sub btnAgregarFiltroEm_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroEm.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 14
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdEmisor.DataSource = listado.listParametros
        With grdEmisor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Emisor"
        End With
    End Sub

    Private Sub btnAgregarFiltroReceptor_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroReceptor.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 24
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdReceptor.DataSource = listado.listParametros
        With grdReceptor
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Receptor"
        End With
    End Sub

    Private Sub btnAgregarFiltroMotivo_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroMotivo.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 22
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdMotivoInterno.DataSource = listado.listParametros
        With grdMotivoInterno
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Motivo"
        End With
    End Sub

    Private Sub btnAgregarFiltroSolicita_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroSolicitaInterno.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        Dim tipoCliente As String = Nothing
        listado.tipo_busqueda = 25

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdSolicitaInterno.DataSource = listado.listParametros
        With grdSolicitaInterno
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colaboradores"
        End With

        ''listado.tipoCliente = "I"


        'Dim listaParametroID As New List(Of String)
        'For Each row As UltraGridRow In grdCliente.Rows
        '    Dim parametro As String = row.Cells(0).Text
        '    listaParametroID.Add(parametro)
        'Next
        'listado.listaParametroID = listaParametroID
        'listado.ShowDialog(Me)
        'If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        'If listado.listParametros.Rows.Count = 0 Then Return
        'grdCliente.DataSource = listado.listParametros
        'With grdCliente
        '    If listado.tipoCliente = "I" Then '''''''' clientes internos
        '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(1).Hidden = True
        '        '.DisplayLayout.Bands(0).Columns(3).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente Interno"
        '    Else '''' clientes externos
        '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(1).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(3).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(4).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(5).Hidden = True
        '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
        '    End If

        'End With

    End Sub

    Private Sub btnAgregarFiltroSolicitaExterno_Click(sender As Object, e As EventArgs)
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        Dim tipoCliente As String = Nothing

        listado.tipo_busqueda = 1
        listado.tipoCliente = "E"

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCliente.DataSource = listado.listParametros
        With grdCliente
            If listado.tipoCliente = "I" Then '''''''' clientes internos
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                '.DisplayLayout.Bands(0).Columns(3).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente Interno"
            Else '''' clientes externos
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(3).Hidden = True
                .DisplayLayout.Bands(0).Columns(4).Hidden = True
                .DisplayLayout.Bands(0).Columns(5).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Cliente"
            End If

        End With

    End Sub

    Private Sub btnAgregarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroStatus.Click
        Dim listado As New ListadoParametrosProyeccionEntregasForm
        listado.tipo_busqueda = 23
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatus.DataSource = listado.listParametros
        With grdStatus
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Status"
        End With

    End Sub

    Private Sub ObtenerCEDISUsuario()
        cmbCEDIS = Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)
    End Sub





    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If

            End If

        Next
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdStatus.DataSource = lstInicial
        grdFactura.DataSource = lstInicial
        grdCliente.DataSource = lstInicial
        grdEmisor.DataSource = lstInicial
        grdReceptor.DataSource = lstInicial
        grdMotivoInterno.DataSource = lstInicial
        grdSolicitaInterno.DataSource = lstInicial
        grdCancelaciones.DataSource = Nothing
        chkFecha.Checked = False
    End Sub

    Private Sub txtFiltroFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltroFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub txtFiltroFolioFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltroFolioFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub dtpFechaFin_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaFin.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 370
    End Sub


    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

        asignaFormato_Columna(grid)

    End Sub

    Private Sub grdStatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatus.InitializeLayout
        grid_diseño(grdStatus)
        grdStatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Status"
    End Sub

    Private Sub grdFactura_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFactura.InitializeLayout
        grid_diseño(grdFactura)
        grdFactura.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Factura"
    End Sub

    Private Sub grdFolioFactura_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFolioFactura.InitializeLayout
        grid_diseño(grdFolioFactura)
        grdFolioFactura.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Folio Factura"
    End Sub


    Private Sub grdCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCliente.InitializeLayout
        grid_diseño(grdCliente)
        grdCliente.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdEmisor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdEmisor.InitializeLayout
        grid_diseño(grdEmisor)
        grdEmisor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Emisor"
    End Sub

    Private Sub grdReceptor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdReceptor.InitializeLayout
        grid_diseño(grdReceptor)
        grdReceptor.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Receptor"
    End Sub

    Private Sub grdMotivoInterno_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMotivoInterno.InitializeLayout
        grid_diseño(grdMotivoInterno)
        grdMotivoInterno.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Motivo"
    End Sub

    Private Sub grdSolicitaInterno_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdSolicitaInterno.InitializeLayout
        grid_diseño(grdSolicitaInterno)
        grdSolicitaInterno.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Interno"
    End Sub

    Private Sub btnLimpiarFiltroReceptor_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroReceptor.Click
        grdReceptor.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroMotivo_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMotivo.Click
        grdMotivoInterno.DataSource = lstInicial
    End Sub
    Private Sub btnLimpiarFiltroSolicita_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroSolicitaInterno.Click
        grdSolicitaInterno.DataSource = lstInicial
    End Sub

    Private Sub btnLimpiarFiltroStatus_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroStatus.Click
        grdStatus.DataSource = lstInicial
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub bgvCancelaciones_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles bgvCancelaciones.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvCancelaciones_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles bgvCancelaciones.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Dim esdocumentoAñoAnterior As String = String.Empty
        Dim estatus As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorSolicitud(currentView.GetRowCellValue(e.RowHandle, "Estatus solicitud"))
            End If


            esdocumentoAñoAnterior = currentView.GetRowCellValue(e.RowHandle, "añoAnterior")
            If esdocumentoAñoAnterior = 1 Then
                e.Appearance.ForeColor = pnlSolicitudRechazada.BackColor
            End If

            If e.Column.FieldName = "Estatus solicitud" Then
                estatus = currentView.GetRowCellValue(e.RowHandle, "Estatus solicitud")
                If estatus = "ACTIVA" Then
                    e.Appearance.ForeColor = pnlSolicitudActiva.BackColor
                Else
                    If estatus = "AUTORIZADA" Then
                        e.Appearance.ForeColor = pnlSolicitudAutorizada.BackColor
                    Else
                        If estatus = "RECHAZADA" Then
                            e.Appearance.ForeColor = pnlSolicitudRechazada.BackColor
                        End If
                    End If

                End If

            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            errormensaje.mensaje = "Error" + ex.Message.ToString()
            errormensaje.ShowDialog()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Function ObtenerColorSolicitud(ByVal estatus As String) As Color
        Dim TipoColor As New Color

        If estatus = "ACTIVA" Then
            TipoColor = pnlSolicitudActiva.BackColor
        Else
            If estatus = "PENDIENTE CANCELAR" Then
                TipoColor = pnlSolicitudAutorizada.BackColor
            Else
                If estatus = "RECHAZADA" Then
                    TipoColor = pnlSolicitudRechazada.BackColor
                End If
            End If

        End If
        Return TipoColor

    End Function

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        MostrarPantallaAutorizar()
    End Sub

    Public Sub MostrarPantallaAutorizar()
        ''si la solicitud esta activa se puede autorizar 
        ''si el mes anterior cuenta con tres declaraciones no se puede autorizar         
        Try
            'Dim dtTotalDeclaraciones As New DataTable

            'Dim filasSeleccionadas As Integer
            'Dim indexRowSeleccionado As Integer
            'Dim DVListadoDocumento As DataView = CType(bgvCancelaciones.DataSource, DataView)
            'Dim DTResultado As DataTable = DVListadoDocumento.Table.Copy()

            'filasSeleccionadas = DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).Count
            'indexRowSeleccionado = DTResultado.Rows.IndexOf(DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).First)


            'If filasSeleccionadas > 1 Then
            '    objMensajeValido.Text = "Advertencia"
            '    objMensajeValido.mensaje = "Solo se permite editar un registro."
            '    objMensajeValido.ShowDialog()
            '    Return
            'ElseIf filasSeleccionadas = 0 Then
            '    objMensajeValido.Text = "Advertencia"
            '    objMensajeValido.mensaje = "Debe seleccionar un registro"
            '    objMensajeValido.ShowDialog()
            '    Return
            'End If

            Dim solicitudSeleccionada As New Entidades.Solicitud

            Dim FilaSeleccionada = ObtenerSolicitudSeleccionada()
            If IsNothing(FilaSeleccionada) = False Then
                solicitudSeleccionada = ObtnerInformacionSoliciudSeleccionada(FilaSeleccionada)
                If solicitudSeleccionada.Solicitudid > 0 Then
                    If ValidarSolicitudSeleccionada(solicitudSeleccionada) = True Then
                        MostrarAceptacion(solicitudSeleccionada)
                        btnAceptar_Click(Nothing, Nothing)
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solicitud Invalida")
                    End If
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Documento invalido.")
                End If
            End If
        Catch ex As Exception
            objMensajeValido.Text = "Advertencia"
            objMensajeValido.mensaje = ex.Message.ToString
            objMensajeValido.ShowDialog()
        End Try

        '    Dim dtEstatus As DataTable
        '    dtEstatus = ObjBU.ConsultarEstatusSolicitud(bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "Solicitud"))
        '    If dtEstatus.Rows(0).Item("estatus") = 469 Then ''SOLO SI ESTA EN ESTATUS 'ACTIVA' SE PUEDE AUTORIZAR LA SOLICITUD
        '        dtTotalDeclaraciones = ObjBU.ConsultarDeclaracionesAnteriores(bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "Solicitud"))
        '        If dtTotalDeclaraciones.Rows(0).Item("respuesta") >= 3 Then
        '            objMensajeValido.Text = "Advertencia"
        '            objMensajeValido.mensaje = "No se puede autorizar la cancelación, ya se encuentran 3 declaraciones."
        '            objMensajeValido.ShowDialog()
        '        Else
        '            Dim statusSolicitud = bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "Estatus solicitud").ToString
        '            If statusSolicitud = "ACTIVA" Then
        '                Dim FormularioAutorizacionSolicitud As New Ventas.Vista.AutorizacionSolicitud_Form With {
        '                    .idSolicitud = bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "Solicitud"),
        '                    .idMotivoCancelacion = bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "idMotivoInterno")
        '                }
        '                FormularioAutorizacionSolicitud.ShowDialog()
        '                btnAceptar_Click(Nothing, Nothing)
        '            Else
        '                objMensajeValido.Text = "Advertencia"
        '                objMensajeValido.mensaje = "La solicitud ya se encuentra autorizada"
        '                objMensajeValido.ShowDialog()
        '                btnAceptar_Click(Nothing, Nothing)
        '            End If

        '        End If
        '    Else
        '        objMensajeValido.Text = "Advertencia"
        '        objMensajeValido.mensaje = "La solicitud debe estar activa"
        '        objMensajeValido.ShowDialog()
        '    End If
        'Catch ex As Exception
        '    objMensajeValido.Text = "Advertencia"
        '    objMensajeValido.mensaje = ex.Message.ToString
        '    objMensajeValido.ShowDialog()
        'End Try
    End Sub

    Private Sub MostrarAceptacion(ByVal SolicitudSeleccionada As Entidades.Solicitud)
        Dim FormularioAutorizacionSolicitud As New AutorizacionSolicitud_Form

        FormularioAutorizacionSolicitud.idSolicitud = SolicitudSeleccionada.Solicitudid
        FormularioAutorizacionSolicitud.idMotivoCancelacion = SolicitudSeleccionada.IdMotivoInterno

        FormularioAutorizacionSolicitud.ShowDialog()
    End Sub
    Private Function ValidarSolicitudSeleccionada(ByVal SolicitudSeleccionada As Entidades.Solicitud) As Boolean

        Dim dtEstatus As DataTable
        Dim dtTotalDeclaraciones As DataTable
        Dim ResultadoValidacion As Boolean = False
        Try

            dtEstatus = ObjBU.ConsultarEstatusSolicitud(SolicitudSeleccionada.Solicitudid)

            If dtEstatus.Rows(0).Item("estatus") = 469 Then ''SOLO SI ESTA EN ESTATUS 'ACTIVA' SE PUEDE AUTORIZAR LA SOLICITUD
                dtTotalDeclaraciones = ObjBU.ConsultarDeclaracionesAnteriores(SolicitudSeleccionada.Solicitudid)
                If dtTotalDeclaraciones.Rows(0).Item("respuesta") >= 3 Then
                    Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se puede autorizar la cancelación, ya se encuentran 3 declaraciones.")
                Else
                    Dim statusSolicitud = SolicitudSeleccionada.Estatus
                    If statusSolicitud = "ACTIVA" Then
                        ResultadoValidacion = True
                        Return ResultadoValidacion
                    Else
                        Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La solicitud ya se encuentra autorizada")
                    End If

                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La solicitud debe estar activa")
            End If

            Return ResultadoValidacion
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
            Return ResultadoValidacion
        End Try

    End Function

    Private Function ObtnerInformacionSoliciudSeleccionada(ByVal RowSolicitudSelecionado As DataRow) As Entidades.Solicitud
        Dim EntidadSolicitud As New Entidades.Solicitud

        EntidadSolicitud.Solicitudid = RowSolicitudSelecionado.Item("Solicitud")
        EntidadSolicitud.Estatus = RowSolicitudSelecionado.Item("Estatus solicitud")
        EntidadSolicitud.IdMotivoInterno = RowSolicitudSelecionado.Item("idMotivoInterno")

        Return EntidadSolicitud
    End Function

    Private Function ObtenerSolicitudSeleccionada() As DataRow
        Dim FilaSeleccionada As DataRow
        Dim NumeroFilasSeleccionadas As Integer = 0

        Dim DVListadoDocumento As DataView = CType(bgvCancelaciones.DataSource, DataView)
        Dim DTResultado As DataTable = DVListadoDocumento.Table.Copy()

        NumeroFilasSeleccionadas = DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item(" ")) = True).Count

        If NumeroFilasSeleccionadas > 1 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Solo se permite editar un registro.")
            Return Nothing
        ElseIf NumeroFilasSeleccionadas = 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Debe seleccionar un registro")
            Return Nothing
        End If

        FilaSeleccionada = DTResultado.AsEnumerable().Where(Function(x) CBool(x.Item(" ")) = True).FirstOrDefault()
        Return FilaSeleccionada
    End Function


    Private Sub btnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        Try


            Dim filasSeleccionadas As Integer
            Dim indexRowSeleccionado As Integer
            Dim DVListadoDocumento As DataView = CType(bgvCancelaciones.DataSource, DataView)
            Dim DTResultado As DataTable = DVListadoDocumento.Table.Copy()

            filasSeleccionadas = DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).Count
            indexRowSeleccionado = DTResultado.Rows.IndexOf(DTResultado.AsEnumerable.Where(Function(x) CBool(x.Item(" ")) = True).First)


            If filasSeleccionadas > 1 Then
                objMensajeValido.Text = "Advertencia"
                objMensajeValido.mensaje = "Solo se permite editar un registro."
                objMensajeValido.ShowDialog()
                Return
            ElseIf filasSeleccionadas = 0 Then
                objMensajeValido.Text = "Advertencia"
                objMensajeValido.mensaje = "Debe seleccionar un registro"
                objMensajeValido.ShowDialog()
                Return
            End If

            Dim statusSolicitud = bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "EstatusID").ToString

            Dim dtEstatus As DataTable
            dtEstatus = ObjBU.ConsultarEstatusSolicitud(bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "Solicitud"))
            If dtEstatus.Rows(0).Item("estatus") = 469 Then ''SOLO SI ESTA EN ESTATUS 'ACTIVA' SE PUEDE RECHAZAR LA SOLICITUD
                Dim FormularioRechazarSolicitud As New Ventas.Vista.RechazarSolicitud_Form With {
                        .idSolicitud = bgvCancelaciones.GetRowCellValue(indexRowSeleccionado, "Solicitud")
                    }
                FormularioRechazarSolicitud.ShowDialog()
                btnAceptar_Click(Nothing, Nothing)
            Else
                objMensajeValido.Text = "Advertencia"
                objMensajeValido.mensaje = "La solicitud debe estar activa"
                objMensajeValido.ShowDialog()
                btnAceptar_Click(Nothing, Nothing)
            End If
        Catch ex As Exception
            objMensajeValido.Text = "Advertencia"
            objMensajeValido.mensaje = ex.Message.ToString
            objMensajeValido.ShowDialog()
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Exportar()
    End Sub

    Private Sub Exportar()
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty
        Dim nombreReporteParaExportacion As String = String.Empty
        Try
            Cursor = Cursors.WaitCursor
            If bgvCancelaciones.DataRowCount > 0 Then
                nombreReporte = "\ReporteSolicitudesDeCancelaciones_"

                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If bgvCancelaciones.GroupCount > 0 Then
                            bgvCancelaciones.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()

                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                            grdCancelaciones.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        objMensajeExito.Text = "Exito"
                        objMensajeExito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        objMensajeExito.ShowDialog()
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End Try
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        Try

            'Dim esdocumentoAñoAnterior As String = String.Empty
            'esdocumentoAñoAnterior = bgvCancelaciones.GetRowCellValue
            ''GetRowCellValue(e.RowHandle, ''currentView.GetRowCellValue(e.RowHandle, "añoAnterior")

            If e.RowHandle >= 0 Then


                Dim fila = bgvCancelaciones.GetDataRow(e.RowHandle)
                Dim esdocumentoAñoAnterior = fila.Item("añoAnterior")
                If e.ColumnFieldName <> "Estatus solicitud" Then
                    If esdocumentoAñoAnterior = 1 Then
                        e.Formatting.Font.Color = pnlSolicitudRechazada.BackColor
                    End If
                Else
                    If e.ColumnFieldName = "Estatus solicitud" Then
                        e.Formatting.Font.Color = ObtenerColorLetra(bgvCancelaciones.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                    End If
                End If


                'If e.ColumnFieldName <> "MARCA" And e.ColumnFieldName <> "INDICADOR" And e.ColumnFieldName <> "#" And e.ColumnFieldName <> "AGENTE" And e.ColumnFieldName <> "CLIENTE" And e.ColumnFieldName <> "RUTA" Then
                '    If IsDBNull(bgvCancelaciones.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Or IsNothing(bgvCancelaciones.GetRowCellValue(e.RowHandle, e.ColumnFieldName)) Then
                '        bgvCancelaciones.SetRowCellValue(e.RowHandle, e.ColumnFieldName, 0)
                '        e.Value = 0
                '    End If
                '    If bgvCancelaciones.GetRowCellValue(e.RowHandle, "INDICADOR").ToString().Contains("%") Then
                '        'e.Formatting.BackColor = ObtenerColorCelda(bgvCancelaciones.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                '        e.Formatting.Font.Color = ObtenerColorLetra(bgvCancelaciones.GetRowCellValue(e.RowHandle, e.ColumnFieldName))
                '        e.Value = (Integer.Parse(RTrim(LTrim(Replace(Replace(e.Value.ToString, ",", ""), "%", "")))) / 100).ToString("p0")
                '    End If
                'End If
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try

        e.Handled = True
    End Sub


    Private Function ObtenerColorCelda(ByVal Valor As Integer) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor < 100 Then
            TipoColor = Color.Pink
        ElseIf Valor >= 100 And Valor <= 120 Then
            TipoColor = Color.LightGreen
        ElseIf Valor > 120 Then
            TipoColor = Color.Thistle
        End If

        Return TipoColor

    End Function

    Private Function ObtenerColorLetra(ByVal Valor As String) As Color
        Dim TipoColor As Color = Color.Empty


        If Valor = "ACTIVA" Then
            TipoColor = pnlSolicitudActiva.BackColor
        ElseIf Valor = "AUTORIZADA" Then
            TipoColor = pnlSolicitudAutorizada.BackColor
        ElseIf Valor = "RECHAZADA" Then
            TipoColor = pnlSolicitudRechazada.BackColor
        End If
        Return TipoColor

    End Function


    Private Sub grdFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub grdFolioFactura_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFolioFactura.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFolioFactura.DeleteSelectedRows(False)
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCliente.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCliente.DeleteSelectedRows(False)
    End Sub

    Private Sub grdEmisor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdEmisor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdEmisor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdReceptor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdReceptor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdReceptor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMotivoInterno_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMotivoInterno.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMotivoInterno.DeleteSelectedRows(False)
    End Sub

    Private Sub grdStatus_KeyDown(sender As Object, e As KeyEventArgs) Handles grdStatus.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdStatus.DeleteSelectedRows(False)
    End Sub

    Private Sub grdSolicitaInterno_KeyDown(sender As Object, e As KeyEventArgs) Handles grdSolicitaInterno.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdSolicitaInterno.DeleteSelectedRows(False)
    End Sub

    Private Sub AdministradorSolicitudesCancelacionDocumentos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyData = Keys.F9 Then
            Exportar()
        End If

        If e.KeyData = Keys.Escape Then
            Dim confirmar As New ConfirmarForm
            confirmar.mensaje = "¿Está seguro de cerrar la ventana?"
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        End If

        If e.KeyData = Keys.F5 Then
            btnAceptar_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub btnActualizarCancelacion_Click(sender As Object, e As EventArgs) Handles btnActualizarCancelacion.Click
        Dim dt As DataTable
        Dim DocumentoID, empresaID As Integer
        Dim motivoidSat As String
        Dim cliente As Integer
        Dim UUID As String = String.Empty
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim ObjDocBU As New Negocios.AdministradorDocumentosBU
        Dim ObjCancelacionDocumentosBU As New Negocios.CancelacionDocumentosBU

        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim dtSolicitud As New DataTable
        Dim estatus As String = String.Empty
        Dim resultado As Int16 = 0

        Dim dtDocumneto As New DataTable

        Try
            Me.Cursor = Cursors.WaitCursor
            btnActualizarCancelacion.Enabled = False
            pnPBar.Left = (grdCancelaciones.Width - pnPBar.Width) / 2
            pnPBar.Top = (grdCancelaciones.Height - pnPBar.Height) / 2
            pnPBar.Visible = True
            lblInfo.Text = "Conectando a SAT... recuperando respuestas de cancelaciones en espera de aceptación…"

            'lblInfo.Left = (pnPBar.Width - lblInfo.Width) / 2
            'lblInfo.Top = (pnPBar.Height - lblInfo.Height) / 2
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)

            Dim listaErrores As New List(Of String)
            Dim listaErroresSat As New List(Of String)
            Dim listaCancelacionsOK As New List(Of String)

            dt = ObjDocBU.ConsultaCancelacionEstatusSAT ''obtenemos las facturas que pendientes de cancelara 
            For Each row As DataRow In dt.Rows
                motivoidSat = row.Item("claveSAT")

                If motivoidSat = "02" Then
                    CancelacionSinRelacion(motivoidSat, row)
                ElseIf motivoidSat = "01" Then
                    CancelacionConRelacion(motivoidSat, row) ''Con este metodo no debe de mandar los pares a refacturar ya que ya se facturaron con otra factura
                ElseIf motivoidSat = "03" Then
                    CancelacionOperacion(motivoidSat, row)
                End If
            Next
            ''REVISA TODAS LAS CANCELACIONES QUE YA FUERON ACEPTADAS (TBL_FacturacionCalzadoDocumento_Cancelacion) Y SI EL REGISTRO 'StatusIDSat' SE ACTUALIZO CON STATUS 103,202,107,106 
            ''EJECUTA UN PROCESO PARA ACTUALIZAR SAY 
            objCancelacion.EjecutaRevisionCancelacionesPendientes()
            System.Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
            pnPBar.Visible = False
            Controles.Mensajes_Y_Alertas("EXITO", "Proceso terminado.")
            btnAceptar_Click(Nothing, Nothing)
        Catch ex As Exception
            Controles.Mensajes_Y_Alertas("ERROR", ex.Message)
        Finally
            btnActualizarCancelacion.Enabled = True
            pnPBar.Visible = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#Region "METODOS PARA CANCELAR"
    Private Sub CancelacionSinRelacion(motivoidSat As String, row As DataRow)
        Dim DocumentoID, empresaID As Integer
        Dim cliente As Integer
        Dim UUID As String = String.Empty
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim ObjDocBU As New Negocios.AdministradorDocumentosBU
        Dim ObjCancelacionDocumentosBU As New Negocios.CancelacionDocumentosBU

        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim dtSolicitud As New DataTable
        Dim estatus As String = String.Empty
        Dim resultado As Int16 = 0


        Dim listaErrores As New List(Of String)
        Dim listaErroresSat As New List(Of String)
        Dim listaCancelacionsOK As New List(Of String)

        Dim dtDocumneto As New DataTable

        DocumentoID = 0
        empresaID = 0
        UUID = String.Empty
        DocumentoID = IIf(IsDBNull(row.Item("documentoid")), 0, row.Item("documentoid"))
        UUID = IIf(IsDBNull(row.Item("uuid")), "", row.Item("uuid"))
        empresaID = row.Item("EmpresaID") '- -IIf(IsDBNull(row.Item("EmpresaID")), 0, IsDBNull(row.Item("EmpresaID")))
        cliente = row.Item("clienteID")
        ''llenar dt consulta de solcitud para llenar el bjeto DocumentoCancelar
        dtSolicitud = ObjBU.ConsultarSolcitud(DocumentoID)
        dtRespuestaCancelacionTimbrada = objBUTimbrado.CancelarFacturaSolicitud4_0(DocumentoID, UUID, empresaID, "FACTURACALZADO", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, motivoidSat)
        If dtRespuestaCancelacionTimbrada.Rows.Count > 0 Then
            estatus = dtRespuestaCancelacionTimbrada.Rows(0).Item("Mensaje")
            resultado = dtRespuestaCancelacionTimbrada.Rows(0).Item("Resultado")
            If resultado = 1 Then
                Dim DocumentoCancelar As New Entidades.CancelacionDocumento
                dtDocumneto = ObjCancelacionDocumentosBU.consultaInformacionDocumentoCancelar(cliente, DocumentoID)
                DocumentoCancelar.DocumentoID = DocumentoID
                DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                DocumentoCancelar.Solicita = dtSolicitud.Rows(0).Item("solicita")
                DocumentoCancelar.MotivoID = dtSolicitud.Rows(0).Item("motivoid")
                DocumentoCancelar.Observaciones = dtSolicitud.Rows(0).Item("observacion")
                DocumentoCancelar.SustitucionInmediata = 0
                DocumentoCancelar.RequiereAutorizacionCliente = 0
                ''DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
                ''DocumentoCancelar.UsoCFDIID = If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
                DocumentoCancelar.UsoCFDIID = ""
                DocumentoCancelar.ProductoAlCancelar = dtSolicitud.Rows(0).Item("ubicacion")

                Dim respuestaCancelacion As RespuestaRestArray = CancelarFacturaSaySicyPares(DocumentoCancelar) ''CANCELAR SAY SICY Y PARES A REFACTURAR
                ''actualizar status de la solicitud 
                ObjBU.ActualizarEstatusSolicitud(DocumentoCancelar.DocumentoID, 472)

                If respuestaCancelacion.respuesta = 0 Then
                    ''guardamos los errores en una lista para mostrarlos despues del for
                    listaErrores.Add("Documento: " + DocumentoID.ToString + respuestaCancelacion.aviso)
                Else
                    listaCancelacionsOK.Add("EL Documento: " + DocumentoID.ToString + " se cancelo correctamente.")
                End If
            Else
                listaErroresSat.Add("El documento: " + DocumentoID.ToString + " no se cancelo ante el SAT: " + estatus.ToString)
            End If
        End If

        If listaCancelacionsOK.Count > 0 Then
            Controles.Mensajes_Y_Alertas("EXITO", "Documentos cancelados correctamente: " + String.Join(",", listaCancelacionsOK))
        End If

        If listaErroresSat.Count > 0 Then
            Controles.Mensajes_Y_Alertas("ERROR", "Documentos con error en el SAT: " + String.Join(",", listaErroresSat))
        End If

        If listaErrores.Count > 0 Then
            Controles.Mensajes_Y_Alertas("ERROR", "Documentos con error de cancelacion en sitema: " + String.Join(",", listaErrores))
        End If
    End Sub

    Private Sub CancelacionConRelacion(motivoidSat As String, row As DataRow)
        Dim DocumentoID, empresaID As Integer
        Dim cliente As Integer
        Dim UUID As String = String.Empty
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim ObjDocBU As New Negocios.AdministradorDocumentosBU
        Dim ObjCancelacionDocumentosBU As New Negocios.CancelacionDocumentosBU
        Dim FolioRelacionado As String = String.Empty


        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim dtSolicitud As New DataTable
        Dim estatus As String = String.Empty
        Dim resultado As Int16 = 0

        Dim listaErrores As New List(Of String)
        Dim listaErroresSat As New List(Of String)
        Dim listaCancelacionsOK As New List(Of String)

        Dim dtDocumneto As New DataTable

        DocumentoID = 0
        empresaID = 0
        UUID = String.Empty
        DocumentoID = IIf(IsDBNull(row.Item("documentoid")), 0, row.Item("documentoid"))
        UUID = IIf(IsDBNull(row.Item("uuid")), "", row.Item("uuid"))
        empresaID = row.Item("EmpresaID") '- -IIf(IsDBNull(row.Item("EmpresaID")), 0, IsDBNull(row.Item("EmpresaID")))
        cliente = row.Item("clienteID")
        FolioRelacionado = row.Item("folioRelacionado")
        ''llenar dt consulta de solcitud para llenar el bjeto DocumentoCancelar
        dtSolicitud = ObjBU.ConsultarSolcitud(DocumentoID)
        dtRespuestaCancelacionTimbrada = objBUTimbrado.CancelarFacturaSolicitud4_0(DocumentoID, UUID, empresaID, "FACTURACALZADO", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, motivoidSat, FolioRelacionado)
        If dtRespuestaCancelacionTimbrada.Rows.Count > 0 Then
            estatus = dtRespuestaCancelacionTimbrada.Rows(0).Item("Mensaje")
            resultado = dtRespuestaCancelacionTimbrada.Rows(0).Item("Resultado")
            If resultado = 1 Then
                Dim DocumentoCancelar As New Entidades.CancelacionDocumento
                dtDocumneto = ObjCancelacionDocumentosBU.consultaInformacionDocumentoCancelar(cliente, DocumentoID)
                DocumentoCancelar.DocumentoID = DocumentoID
                DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                DocumentoCancelar.Solicita = dtSolicitud.Rows(0).Item("solicita")
                DocumentoCancelar.MotivoID = dtSolicitud.Rows(0).Item("motivoid")
                DocumentoCancelar.Observaciones = dtSolicitud.Rows(0).Item("observacion")
                DocumentoCancelar.SustitucionInmediata = 0
                DocumentoCancelar.RequiereAutorizacionCliente = 0
                ''DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
                ''DocumentoCancelar.UsoCFDIID = If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
                DocumentoCancelar.UsoCFDIID = ""
                DocumentoCancelar.ProductoAlCancelar = dtSolicitud.Rows(0).Item("ubicacion")

                Dim respuestaCancelacion As RespuestaRestArray = CancelarFacturaSaySicy(DocumentoCancelar) ''CANCELAR SAY SICY Y PARES A REFACTURAR
                If respuestaCancelacion.respuesta = 0 Then
                    ''guardamos los errores en una lista para mostrarlos despues del for
                    listaErrores.Add("Documento: " + DocumentoID.ToString + respuestaCancelacion.aviso)
                Else
                    ObjBU.ActualizarEstatusSolicitud(DocumentoID, 472)
                    listaCancelacionsOK.Add("EL Documento: " + DocumentoID.ToString + " se cancelo correctamente.")
                End If
            Else
                listaErroresSat.Add("El documento: " + DocumentoID.ToString + " no se cancelo ante el SAT: " + estatus.ToString)
            End If
        End If

        If listaCancelacionsOK.Count > 0 Then
            Controles.Mensajes_Y_Alertas("EXITO", "Documentos cancelados correctamente: " + String.Join(",", listaCancelacionsOK))
        End If

        If listaErroresSat.Count > 0 Then
            Controles.Mensajes_Y_Alertas("ERROR", "Documentos con error en el SAT: " + String.Join(",", listaErroresSat))
        End If

        If listaErrores.Count > 0 Then
            Controles.Mensajes_Y_Alertas("ERROR", "Documentos con error de cancelacion en sitema: " + String.Join(",", listaErrores))
        End If
    End Sub

    Private Sub CancelacionOperacion(motivoidSat As String, row As DataRow)
        Dim DocumentoID, empresaID As Integer
        Dim cliente As Integer
        Dim UUID As String = String.Empty
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim ObjDocBU As New Negocios.AdministradorDocumentosBU
        Dim ObjCancelacionDocumentosBU As New Negocios.CancelacionDocumentosBU

        Dim dtRespuestaCancelacionTimbrada As New DataTable
        Dim dtSolicitud As New DataTable
        Dim estatus As String = String.Empty
        Dim resultado As Int16 = 0

        Dim listaErrores As New List(Of String)
        Dim listaErroresSat As New List(Of String)
        Dim listaCancelacionsOK As New List(Of String)

        Dim dtDocumneto As New DataTable

        DocumentoID = 0
        empresaID = 0
        UUID = String.Empty
        DocumentoID = IIf(IsDBNull(row.Item("documentoid")), 0, row.Item("documentoid"))
        UUID = IIf(IsDBNull(row.Item("uuid")), "", row.Item("uuid"))
        empresaID = row.Item("EmpresaID") '- -IIf(IsDBNull(row.Item("EmpresaID")), 0, IsDBNull(row.Item("EmpresaID")))
        cliente = row.Item("clienteID")
        ''llenar dt consulta de solcitud para llenar el bjeto DocumentoCancelar
        dtSolicitud = ObjBU.ConsultarSolcitud(DocumentoID)
        dtRespuestaCancelacionTimbrada = objBUTimbrado.CancelarFacturaSolicitud4_0(DocumentoID, UUID, empresaID, "FACTURACALZADO", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, motivoidSat)
        If dtRespuestaCancelacionTimbrada.Rows.Count > 0 Then
            estatus = dtRespuestaCancelacionTimbrada.Rows(0).Item("Mensaje")
            resultado = dtRespuestaCancelacionTimbrada.Rows(0).Item("Resultado")
            If resultado = 1 Then
                Dim DocumentoCancelar As New Entidades.CancelacionDocumento
                dtDocumneto = ObjCancelacionDocumentosBU.consultaInformacionDocumentoCancelar(cliente, DocumentoID)
                DocumentoCancelar.DocumentoID = DocumentoID
                DocumentoCancelar.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                DocumentoCancelar.Solicita = dtSolicitud.Rows(0).Item("solicita")
                DocumentoCancelar.MotivoID = dtSolicitud.Rows(0).Item("motivoid")
                DocumentoCancelar.Observaciones = dtSolicitud.Rows(0).Item("observacion")
                DocumentoCancelar.SustitucionInmediata = 0
                DocumentoCancelar.RequiereAutorizacionCliente = 0
                ''DocumentoCancelar.NuevoRFCID = If(cmbRFCNuevoDocumento.Visible, cmbRFCNuevoDocumento.SelectedValue, 0)
                ''DocumentoCancelar.UsoCFDIID = If(cmbUsoCFDI.Visible, cmbUsoCFDI.SelectedValue, "")
                DocumentoCancelar.UsoCFDIID = ""
                DocumentoCancelar.ProductoAlCancelar = dtSolicitud.Rows(0).Item("ubicacion")

                Dim respuestaCancelacion As RespuestaRestArray = CancelarFacturaSaySicyOperacion(DocumentoCancelar) ''CANCELAR SAY SICY Y PARES A REFACTURAR
                If respuestaCancelacion.respuesta = 0 Then
                    ''guardamos los errores en una lista para mostrarlos despues del for
                    listaErrores.Add("Documento: " + DocumentoID.ToString + respuestaCancelacion.aviso)
                Else
                    listaCancelacionsOK.Add("EL Documento: " + DocumentoID.ToString + " se cancelo correctamente.")
                End If
            Else
                listaErroresSat.Add("El documento: " + DocumentoID.ToString + " no se cancelo ante el SAT: " + estatus.ToString)
            End If
        End If

        If listaCancelacionsOK.Count > 0 Then
            Controles.Mensajes_Y_Alertas("EXITO", "Documentos cancelados correctamente: " + String.Join(",", listaCancelacionsOK))
        End If

        If listaErroresSat.Count > 0 Then
            Controles.Mensajes_Y_Alertas("ERROR", "Documentos con error en el SAT: " + String.Join(",", listaErroresSat))
        End If

        If listaErrores.Count > 0 Then
            Controles.Mensajes_Y_Alertas("ERROR", "Documentos con error de cancelacion en sitema: " + String.Join(",", listaErrores))
        End If
    End Sub
#End Region

    Private Function CancelarFacturaSaySicyPares(DocumentoCancelar As Entidades.CancelacionDocumento) As RespuestaRestArray
        Dim Respuesta As New RespuestaRestArray
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim dtinformacionMotivo As New DataTable
        Dim entCancelacionSICY As New Entidades.CancelacionDocumento

        Try
            'Cancelacion SAY
            objCancelacion.cancelarDocumento(DocumentoCancelar)
            objCancelacion.EnviarParesRefacturarOT(DocumentoCancelar.DocumentoID)
            'Cancelacion SICY                        
            'dtinformacionMotivo = objCancelacion.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
            dtinformacionMotivo = ObjBU.ConsultarMotivosInternoEditar(DocumentoCancelar.MotivoID)

            entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoCancelar.DocumentoID)

            entCancelacionSICY.DocumentoID = DocumentoCancelar.DocumentoID
            entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
            entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
            entCancelacionSICY.Año = entDatosFactura.Año
            entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoSICYID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("motivo")
            entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
            entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            'Descomentar para produccion
            objCancelacion.CancelarDocumentoSICY(entCancelacionSICY)
            Respuesta.respuesta = 1
            Respuesta.aviso = "Se cancelo correctamente"
        Catch ex As Exception
            Respuesta.respuesta = 0
            Respuesta.aviso = "ERROR AL CANCELAR SAY Y SYCY" + ex.Message
        End Try
        Return Respuesta
    End Function

    Private Function CancelarFacturaSaySicy(DocumentoCancelar As Entidades.CancelacionDocumento) As RespuestaRestArray
        Dim Respuesta As New RespuestaRestArray
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim dtinformacionMotivo As New DataTable
        Dim entCancelacionSICY As New Entidades.CancelacionDocumento

        Try
            'Cancelacion SAY
            objCancelacion.cancelarDocumento(DocumentoCancelar)
            'Cancelacion SICY                        
            'dtinformacionMotivo = objCancelacion.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
            dtinformacionMotivo = ObjBU.ConsultarMotivosInternoEditar(DocumentoCancelar.MotivoID)

            entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoCancelar.DocumentoID)

            entCancelacionSICY.DocumentoID = DocumentoCancelar.DocumentoID
            entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
            entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
            entCancelacionSICY.Año = entDatosFactura.Año
            entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoSICYID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("motivo")
            entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
            entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            'Descomentar para produccion
            objCancelacion.CancelarDocumentoSICY(entCancelacionSICY)
            Respuesta.respuesta = 1
            Respuesta.aviso = "Se cancelo correctamente"
        Catch ex As Exception
            Respuesta.respuesta = 0
            Respuesta.aviso = "ERROR AL CANCELAR SAY Y SYCY" + ex.Message
        End Try
        Return Respuesta
    End Function

    Private Function CancelarFacturaSaySicyOperacion(DocumentoCancelar As Entidades.CancelacionDocumento) As RespuestaRestArray
        Dim Respuesta As New RespuestaRestArray
        Dim objCancelacion As New Ventas.Negocios.CancelacionDocumentosBU
        Dim objBUTimbrado As New Facturacion.Negocios.TimbradoFacturasBU
        Dim entDatosFactura As New Entidades.DatosFactura
        Dim dtinformacionMotivo As New DataTable
        Dim entCancelacionSICY As New Entidades.CancelacionDocumento
        Dim dtRespuestaUbicacion As DataTable

        Try
            'Cancelacion SAY
            objCancelacion.cancelarDocumento(DocumentoCancelar)


            ''si la ot esta en almacen volver la ot a refacturar en caso contrario no hacer nada
            dtRespuestaUbicacion = objCancelacion.ConsultarUbicacionProducto(DocumentoCancelar.DocumentoID)
            If dtRespuestaUbicacion.Rows(0).Item("ubicacionProducto") <> "ENTREGADO" Then
                ObjBU.EnviarParesRefacturarOT(DocumentoCancelar.DocumentoID)
            End If

            objCancelacion.EnviarParesRefacturarOT(DocumentoCancelar.DocumentoID)

            'Cancelacion SICY                        
            'dtinformacionMotivo = objCancelacion.ObtenerInformacionMotivoCancelacionID(DocumentoCancelar.MotivoID)
            dtinformacionMotivo = ObjBU.ConsultarMotivosInternoEditar(DocumentoCancelar.MotivoID)

            entDatosFactura = objBUTimbrado.ConsultarInformacionDocumentoFactura(DocumentoCancelar.DocumentoID)

            entCancelacionSICY.DocumentoID = DocumentoCancelar.DocumentoID
            entCancelacionSICY.TipoComprobrante = entDatosFactura.TipoComprobante
            entCancelacionSICY.RemisionID = entDatosFactura.RemisionID
            entCancelacionSICY.Año = entDatosFactura.Año
            entCancelacionSICY.MotivoID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoSICYID = DocumentoCancelar.MotivoID
            entCancelacionSICY.MotivoCatalogo = dtinformacionMotivo.Rows(0).Item("motivo")
            entCancelacionSICY.Observaciones = DocumentoCancelar.Observaciones
            entCancelacionSICY.UserName = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            'Descomentar para produccion
            objCancelacion.CancelarDocumentoSICY(entCancelacionSICY)
            Respuesta.respuesta = 1
            Respuesta.aviso = "Se cancelo correctamente"
        Catch ex As Exception
            Respuesta.respuesta = 0
            Respuesta.aviso = "ERROR AL CANCELAR SAY Y SYCY" + ex.Message
        End Try
        Return Respuesta
    End Function

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        rdoFechaSolicitud.Enabled = chkFecha.Checked
        rdoFechaAutorizacion.Enabled = chkFecha.Checked
        rbtnFechaRechazo.Enabled = chkFecha.Checked
        rbtnFechaFactura.Enabled = chkFecha.Checked
        dtpFechaInicio.Enabled = chkFecha.Checked
        dtpFechaFin.Enabled = chkFecha.Checked
        lblEntregaAl.Enabled = chkFecha.Checked
        lblEntregaDel.Enabled = chkFecha.Checked
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim ws As New Facturacion.Negocios.mx.com.paxfacturacion.testCanc.wcfCancelaASMX
        Dim listauuid(0) As String
        Dim rfcemisor As String
        Dim ListRFCRecptor(0) As String
        Dim ListaTotales(0) As String
        Dim ListaMotivos(0) As String
        Dim FoliosSusstitucion(0) As String
        Dim Nombre As String
        Dim Contraseña As String

        Dim dtrespuesta As New DataTable
        dtrespuesta.Columns.Add("Resultado")
        dtrespuesta.Columns.Add("Mensaje")
        Dim Renglon As DataRow = dtrespuesta.NewRow()

        listauuid(0) = "dbfd9f2f-1b75-4e07-a865-082d0dbc7712"
        rfcemisor = "CACX7605101P8"
        ListRFCRecptor(0) = "AAA010101AAA"
        ListaTotales(0) = "10.77"
        ListaMotivos(0) = "01"
        FoliosSusstitucion(0) = ""
        Nombre = "wsdl_pax"
        Contraseña = "wrnDgcOvxYXEr8OKw6jDm8WDxYXCgzV5xLTEgMKoXk/EjcK5776k77+V77+QMu++qe++s++9se+8kw=="

        Try
            Dim reuslatodo = ws.fnCancelarXML20(listauuid, rfcemisor, ListRFCRecptor, ListaTotales, ListaMotivos, FoliosSusstitucion, Nombre, Contraseña)
            Dim cadena As String = ""
            cadena = "hola"
        Catch ex As Exception

        End Try


    End Sub
End Class