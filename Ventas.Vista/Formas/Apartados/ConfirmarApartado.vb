Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools
Imports Stimulsoft.Report
Imports System.Media
Imports System.IO

Public Class ConfirmarApartado

    Public verDetalles As Boolean
    Public totalApartadosSeleccionados As Integer = 0
    Public cliente As String = String.Empty
    Public folioApartado As String = String.Empty
    Public pedidoSAY As Integer = 0
    Public pedidoSICY As Integer = 0
    Public ordenCliente As String = String.Empty
    Public fechaSolicitada As String = String.Empty
    Public fechaPreparacion As String = String.Empty
    Public entregaInmediata As Integer = 0
    Public totalApartadosClientesBloqueados As Integer = 0
    Public apartadoSICY As String = String.Empty
    Public statusApartado As String = String.Empty
    Public clienteBloqueado As Boolean = False
    Public tipoBloqueoCliente As String = String.Empty

    Dim totalParesApartado As Integer = 0
    Dim totalParesConfirmados As Integer = 0
    Dim totalParesPorConfirmar As Integer = 0
    Dim totalParesCancelados As Integer = 0

    Dim datosConsolidados As Boolean = False

    Dim EsAtado As Boolean = False
    Dim LecturaTerminal As Boolean = False
    Dim partidasCompletas As Integer = 0 '' guarda cuando una partida se completa
    Dim ParEscaneado As String
    Dim estatusEscaneado As String = "" 'estatusParEscaneado

    Dim arrApartadosEnArchivo As New ArrayList()

    Dim totalApartadoEnArchivo As Integer = 0
    Dim apartadoActual As Integer = 0
    Dim vueltaLectura As Integer = 1

    Dim rutaArchivoApartadosGlobal As String

    Dim verDisponibilidad As Integer = 0

    Dim TotalParesProgramarConfirmacionIncompleta As Integer = 0

    Public VentanaAdministrador As New AdministracionApartadosForm()

    Dim ListaCodigosInvalidos As New List(Of String)

    Dim TotalParesExcedentes As Integer = 0


    Dim ApartadosIdsEscaneadosArchivo As String = " "
    Dim arrApartadosIdsEscaneadosArchivo As New ArrayList()
    Dim CodigosEscaneadosArchivo As String = " "
    Dim TiposCodigosEscaneadosArchivo As String = " "

    Dim IdCadena As Integer = 0

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnTerminal_Click(sender As Object, e As EventArgs) Handles btnTerminal.Click
        LimpiarSinConfirmacion()
        'CargarArchivoLeerTerminal()
        CargarEnBDArchivoLeerTerminal(sender, e)

        If arrApartadosEnArchivo.Count > 0 Then
            btnTerminal.Enabled = False
            lblTerminal.Enabled = False

            btnCancelarConfirmacion.Enabled = True
            lblTextoCancelarConfirmacionActual.Enabled = True
        End If
    End Sub

    Private Sub ConfirmarApartado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        Me.WindowState = 2
        CargarDatos()
    End Sub

    Public Sub CargarDatos()
        If totalApartadosSeleccionados > 0 Then
            CargarDatosPartidasApartado(folioApartado, totalApartadosSeleccionados, 0, 0)
            CargarDatosParesConfirmadosAnteriormente(folioApartado)
        End If

        FormatoGridParesConfirmar()

        If verDetalles = True Then
            'btnIniciar.Enabled = False
            'lblIniciar.Enabled = False
            'btnDetener.Enabled = False
            'lblDetener.Enabled = False
            btnTerminal.Enabled = False
            lblTerminal.Enabled = False
            'btnQuitarPares.Enabled = False
            'lblQuitarPares.Enabled = False
            'dtDetalleConfirmado = objBU.VerDetallesGridConfirmacion(idOtCoppel)
            ''FormatoGridParesConfirmar()
            ''grdParesConfirmandoActualmente.DataSource = dtDetalleConfirmado
            ''AgregarRenglonGridDetalles()
            'grdParesConfirmadosAnteriormente.DataSource = dtDetalleConfirmado
            'FormatoGridParesConfirmadosAnteriormente()
            'AgregarRenglonGridParesConfirmadosAnteriormente()
            sPCParesConfirmar.SplitterDistance = 0
            sPCParesConfirmar.SplitterWidth = 1
            sPCParesConfirmar.IsSplitterFixed = True
            sPCParesConfirmar.Panel1.Hide()

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_ALMACEN") Then
                btnImprimirDetalles.Enabled = True
                lblTextoImprimirDetalles.Enabled = True
                If totalApartadosSeleccionados > 1 Then
                    btnConsolidar.Enabled = True
                    lblTextoConsolidar.Enabled = True
                End If
            End If

            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_VENTAS") Then
                btnImprimirDetalles.Enabled = True
                lblTextoImprimirDetalles.Enabled = True
            End If
            btnLimpiar.Enabled = False
            btnGuardar.Enabled = False
            lblLimpiar.Enabled = False
            lblGuardar.Enabled = False

            lblTextoCodigosInvalidos.Visible = False
            lblTotalCodigosInvalidos.Visible = False

            If totalApartadosSeleccionados = 1 Then
                btnExistenciaDisponible.Enabled = True
                lblTextoExistenciaDisponible.Enabled = True
            End If
        Else
            ''dtDetalleConfirmado = objBU.VerDetallesGridConfirmacion(idOtCoppel)
            ''grdParesConfirmadosAnteriormente.DataSource = dtDetalleConfirmado
            ''FormatoGridParesConfirmadosAnteriormente()
            ''AgregarRenglonGridParesConfirmadosAnteriormente()
            'If grdPartidasConfirmadasyPorConfirmar.Rows.Count > 0 Then
            '    btnExportarConfirmados.Enabled = True
            '    lblTextoExportarConfirmados.Enabled = True
            '    btnImprimirDetalles.Enabled = True
            '    lblTextoImprimirDetalles.Enabled = True
            'Else
            '    'btnExportar.Enabled = False
            '    'lblExportar.Enabled = False
            'End If
        End If



        If grdPartidasConfirmadasyPorConfirmar.Rows.Count > 0 Then
            btnExportarDetalles.Enabled = True
            lblTextoExportarDetalles.Enabled = True
        Else
            btnExportarDetalles.Enabled = False
            lblTextoExportarDetalles.Enabled = False
        End If

        If grdParesConfirmadosAnteriormente.Rows.Count > 0 Then
            btnExportarConfirmados.Enabled = True
            lblTextoExportarConfirmados.Enabled = True
        Else
            btnExportarConfirmados.Enabled = False
            lblTextoExportarConfirmados.Enabled = False
        End If


        If totalApartadosSeleccionados = 1 Then

            lblNombreCliente.Text = cliente.ToUpper()

            lblTextoCliente.Visible = True
            lblNombreCliente.Visible = True

            lblIdApartado.Text = folioApartado
            lblTextoFolioApartado.Visible = True
            lblIdApartado.Visible = True

            lblIdPedidoSAY.Text = pedidoSAY.ToString()
            lblTextoPedidoSAY.Visible = True
            lblIdPedidoSAY.Visible = True

            lblIdPedidoSICY.Text = pedidoSICY.ToString()
            lblTextoPedidoSICY.Visible = True
            lblIdPedidoSICY.Visible = True

            lblOrdenCliente.Text = ordenCliente.ToUpper()
            lblTextoOrdenCliente.Visible = True
            lblOrdenCliente.Visible = True

            lblFSolicitada.Text = fechaSolicitada
            lblTextoFSolicitada.Visible = True
            lblFSolicitada.Visible = True

            lblFPreparacion.Text = fechaPreparacion
            lblTextoFPreparacion.Visible = True
            lblFPreparacion.Visible = True

            If entregaInmediata = 1 Then
                lblEntregaInmediata.Visible = True
            End If

            lblTextoTotalApartadosSeleccionados.Visible = False
            lblTotalApartadosSeleccionados.Visible = False

            lblTextoApartadoSICY.Visible = True
            lblIdApartadoSICY.Text = apartadoSICY
            lblIdApartadoSICY.Visible = True
            lblEstatusApartado.Text = statusApartado
            lblEstatusApartado.Visible = True

            Dim ventanaAdministradorApartados As New AdministracionApartadosForm

            If statusApartado = "ACTIVO" Then
                lblEstatusApartado.ForeColor = ventanaAdministradorApartados.pnlEstatusActivo.BackColor
            ElseIf statusApartado = "CANCELADO" Then
                lblEstatusApartado.ForeColor = ventanaAdministradorApartados.pnlEstatusCancelado.BackColor
                btnExistenciaDisponible.Enabled = False
                lblTextoExistenciaDisponible.Enabled = False
            ElseIf statusApartado = "CONFIRMADO" Then
                lblEstatusApartado.ForeColor = ventanaAdministradorApartados.pnlEstatusConfirmado.BackColor
                btnExistenciaDisponible.Enabled = False
                lblTextoExistenciaDisponible.Enabled = False
            ElseIf statusApartado = "EN EJECUCIÓN" Then
                lblEstatusApartado.ForeColor = ventanaAdministradorApartados.pnlEstatusEnEjecucion.BackColor
            ElseIf statusApartado = "PARCIALMENTE CONFIRMADO" Then
                lblEstatusApartado.ForeColor = ventanaAdministradorApartados.pnlEstatusParcialmenteConfirmado.BackColor
            ElseIf statusApartado = "CONFIRMACIÓN INCOMPLETA" Then
                lblEstatusApartado.ForeColor = ventanaAdministradorApartados.pnlEstatusConfirmacionIncompleta.BackColor
                btnExistenciaDisponible.Enabled = False
                lblTextoExistenciaDisponible.Enabled = False
                btnVerPares.Enabled = False
                lblTextoVerPares.Enabled = False
                btnConfirmacionIncompleta.Enabled = False
                lblTextoConfirmacionIncompleta.Enabled = False
            End If

            If clienteBloqueado Then
                lblNombreCliente.ForeColor = Color.Red
            Else
                lblNombreCliente.ForeColor = Color.Black
            End If

        Else
            If totalApartadosSeleccionados <> 0 Then
                lblTotalApartadosSeleccionados.Text = totalApartadosSeleccionados.ToString()
                lblTextoTotalApartadosSeleccionados.Visible = True
                lblTotalApartadosSeleccionados.Visible = True
            End If
        End If
    End Sub

    Private Sub btnImprimirDetalles_Click(sender As Object, e As EventArgs) Handles btnImprimirDetalles.Click
        Dim objBu As New Negocios.ApartadosBU
        Dim UsuarioModifico As Int32 = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        If totalApartadosSeleccionados <> 0 Then
            Cursor = Cursors.WaitCursor
            imprimirApartado()
            objBu.editarDatosApartado(folioApartado, 5, "", 0, "", UsuarioModifico)
            Cursor = Cursors.Default
        Else
            show_message("Advertencia", "No hay datos para imprimir. Primero debe seleccionar un apartado.")
        End If
    End Sub

    Private Sub CargarDatosPartidasApartado(ByVal foliosApartados As String, ByVal totalApartados As Integer, ByVal consolidacion As Integer, ByVal conExistencia As Integer)
        Dim objBu As New Negocios.ApartadosBU
        Dim dtResultadoPartidasApartados As DataTable
        dtResultadoPartidasApartados = objBu.consultarDetallesPartidasApartados(foliosApartados, totalApartados, consolidacion, conExistencia)
        grdPartidasConfirmadasyPorConfirmar.DataSource = dtResultadoPartidasApartados
        gridPartidasDiseño(grdPartidasConfirmadasyPorConfirmar)
    End Sub

    Private Sub CargarDatosParesConfirmadosAnteriormente(ByVal foliosApartados As String)
        Dim objBu As New Negocios.ApartadosBU
        Dim dtResultadoParesApartados As DataTable
        Dim consolidacion As Integer = 0
        If datosConsolidados Then
            consolidacion = 1
        End If
        dtResultadoParesApartados = objBu.consultarDetallesParesApartados(foliosApartados, consolidacion)
        grdParesConfirmadosAnteriormente.DataSource = dtResultadoParesApartados
        gridParesDiseño(grdParesConfirmadosAnteriormente)
    End Sub

    Private Sub gridPartidasDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("partidaConfirmada").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("IdProducto").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Conf_Real").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Coleccion").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("Estatus").Hidden = True
        If datosConsolidados = False Then
            grid.DisplayLayout.Bands(0).Columns("ApartadoDetalleTalla").Hidden = True
        End If


        grid.DisplayLayout.Bands(0).Columns("#").Header.Caption = "#"
        grid.DisplayLayout.Bands(0).Columns("#").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("#").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("#").Format = "n0"

        If datosConsolidados = False Then
            grid.DisplayLayout.Bands(0).Columns("apartadoId").Header.Caption = "#Apartado"
            grid.DisplayLayout.Bands(0).Columns("apartadoId").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            grid.DisplayLayout.Bands(0).Columns("apartadoId").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grid.DisplayLayout.Bands(0).Columns("apartadoId").Format = "n0"

            If totalApartadosSeleccionados = 1 Then
                grid.DisplayLayout.Bands(0).Columns("apartadoId").Hidden = True
            End If
            If totalApartadosSeleccionados > 1 Then
                grid.DisplayLayout.Bands(0).Columns("Cliente").Header.Caption = "Cliente"
                grid.DisplayLayout.Bands(0).Columns("Cliente").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            grid.DisplayLayout.Bands(0).Columns("Tienda").Header.Caption = "Tienda"
            grid.DisplayLayout.Bands(0).Columns("Tienda").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        End If
        grid.DisplayLayout.Bands(0).Columns("Modelo").Header.Caption = "Modelo"
        grid.DisplayLayout.Bands(0).Columns("Modelo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
        grid.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Talla").Header.Caption = "Talla"
        grid.DisplayLayout.Bands(0).Columns("Talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Total").Header.Caption = "Total"
        grid.DisplayLayout.Bands(0).Columns("Total").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Total").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Conf").Header.Caption = "Conf"
        grid.DisplayLayout.Bands(0).Columns("Conf").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Conf").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Conf").Format = "n0"
        grid.DisplayLayout.Bands(0).Columns("Faltante").Header.Caption = "Faltante"
        grid.DisplayLayout.Bands(0).Columns("Faltante").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Faltante").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Faltante").Format = "n0"

        'If grid.DisplayLayout.Bands(0).Columns.Contains("ExistenciaTotal") Then
        grid.DisplayLayout.Bands(0).Columns("ExistenciaTotal").Hidden = True
        grid.DisplayLayout.Bands(0).Columns("ExistenciaTotal").Header.Caption = "Existencia"
        grid.DisplayLayout.Bands(0).Columns("ExistenciaTotal").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("ExistenciaTotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        'grid.DisplayLayout.Bands(0).Columns("ExistenciaTotal").Format = "n0"
        'End If

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


        grid.DisplayLayout.Bands(0).Columns("#").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Talla").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Total").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Conf").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Faltante").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Modelo").Width = 40


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        'If width > grid.Width Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        'Else
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        totalParesApartado = 0
        totalParesConfirmados = 0
        totalParesPorConfirmar = 0
        totalParesCancelados = 0

        Dim contador = 1
        For Each renglon As UltraGridRow In grdPartidasConfirmadasyPorConfirmar.Rows
            renglon.Cells("#").Value = contador
            totalParesApartado += renglon.Cells("Total").Value
            totalParesConfirmados += renglon.Cells("Conf").Value
            totalParesPorConfirmar += renglon.Cells("Faltante").Value
            totalParesCancelados += If(renglon.Cells("Estatus").Value = 46, renglon.Cells("Total").Value, 0)
            contador += 1
        Next

        lblTotalPares.Text = totalParesApartado.ToString("n0")
        lblTotalConfirmados.Text = totalParesConfirmados.ToString("n0")
        lblPorConfirmar.Text = totalParesPorConfirmar.ToString("n0")
        lblCancelados.Text = totalParesCancelados.ToString("n0")
    End Sub

    Private Sub grdPartidasConfirmadasyPorConfirmar_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdPartidasConfirmadasyPorConfirmar.InitializeRow
        If e.Row.Cells("partidaConfirmada").Value = 0 Then
            e.Row.Appearance.BackColor = pnlColorPartidaIncompleta.BackColor
            e.Row.Cells("ExistenciaTotal").Value = Replace(e.Row.Cells("ExistenciaTotal").Value, "-", "")
            If e.Row.Cells("ExistenciaTotal").Value = "0" And verDisponibilidad = 1 Then
                e.Row.Appearance.ForeColor = Color.Red
            End If
        Else
            e.Row.Cells("ExistenciaTotal").Value = ""
        End If

        If e.Row.Cells("Estatus").Value = 46 Then
            e.Row.Appearance.BackColor = pnlPartidaCancelada.BackColor
            e.Row.Cells("ExistenciaTotal").Value = ""
            e.Row.Cells("Faltante").Value = 0
        End If

    End Sub

    Private Sub btnExportarDetalles_Click(sender As Object, e As EventArgs) Handles btnExportarDetalles.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdPartidasConfirmadasyPorConfirmar
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then

            If datosConsolidados = False Then
                If totalApartadosSeleccionados = 1 Then
                    grid.DisplayLayout.Bands(0).Columns("apartadoId").Hidden = False
                    nombreDocumento = "\Detalles_Apartados_" + Replace(folioApartado, ",", "-") + "_"
                Else
                    nombreDocumento = "\Detalles_Apartados_"
                End If
            Else
                nombreDocumento = "\Detalles_Apartados_Consolidados_"
            End If


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    If datosConsolidados = False Then
                        With grid.DisplayLayout.Bands(0)
                            .Columns("apartadoId").Hidden = True
                        End With
                    End If
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        If datosConsolidados = False Then
            With grid.DisplayLayout.Bands(0)
                .Columns("apartadoId").Hidden = True
            End With
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnConsolidar_Click(sender As Object, e As EventArgs) Handles btnConsolidar.Click
        If totalApartadosClientesBloqueados = 0 Then
            Cursor = Cursors.WaitCursor
            datosConsolidados = True
            grdPartidasConfirmadasyPorConfirmar.DataSource = Nothing
            CargarDatosPartidasApartado(folioApartado, totalApartadosSeleccionados, 1, 0)
            CargarDatosParesConfirmadosAnteriormente(folioApartado)
            btnConsolidar.Enabled = False
            lblTextoConsolidar.Enabled = False
        Else
            show_message("Advertencia", "Hay seleccionados " + totalApartadosClientesBloqueados.ToString() + " apartados de clientes bloqueados, solo se pueden consolidar apartados de clientes no bloqueados, verifique por favor.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub gridParesDiseño(grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        grid.DisplayLayout.Bands(0).Columns("ApartadoId").Header.Caption = "#Apartado"
        grid.DisplayLayout.Bands(0).Columns("ApartadoId").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Atado").Header.Caption = "Atado"
        grid.DisplayLayout.Bands(0).Columns("Atado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Par").Header.Caption = "Par"
        grid.DisplayLayout.Bands(0).Columns("Par").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Descripcion").Header.Caption = "Descripción"
        grid.DisplayLayout.Bands(0).Columns("Descripcion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Renglon").Header.Caption = "Renglón"
        grid.DisplayLayout.Bands(0).Columns("Renglon").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Renglon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Talla").Header.Caption = "Talla"
        grid.DisplayLayout.Bands(0).Columns("Talla").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Lote").Header.Caption = "Lote"
        grid.DisplayLayout.Bands(0).Columns("Lote").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Lote").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("Nave").Header.Caption = "Nave"
        grid.DisplayLayout.Bands(0).Columns("Nave").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Año").Header.Caption = "Año"
        grid.DisplayLayout.Bands(0).Columns("Año").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Año").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        grid.DisplayLayout.Bands(0).Columns("FechaEntradaAlmacen").Header.Caption = "Entrada Almacén"
        grid.DisplayLayout.Bands(0).Columns("FechaEntradaAlmacen").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FechaEntradaAlmacen").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("FechaConfirmacion").Header.Caption = "Confirmación"
        grid.DisplayLayout.Bands(0).Columns("FechaConfirmacion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("FechaConfirmacion").Format = "dd/MM/yyyy HH:mm:ss"
        grid.DisplayLayout.Bands(0).Columns("ColaboradorConfirmo").Header.Caption = "Confirmó"
        grid.DisplayLayout.Bands(0).Columns("ColaboradorConfirmo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        grid.DisplayLayout.Bands(0).Columns("Status").Hidden = True

        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 20
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        If totalApartadosSeleccionados <= 1 Or datosConsolidados Then
            grid.DisplayLayout.Bands(0).Columns("ApartadoId").Hidden = True
        End If
        If datosConsolidados Then
            grid.DisplayLayout.Bands(0).Columns("#").Hidden = True
            grid.DisplayLayout.Bands(0).Columns("Renglon").Hidden = True
        Else
            grid.DisplayLayout.Bands(0).Columns("ApartadoDetalleTalla").Hidden = True
        End If


        Dim width As Integer
        For Each col As UltraGridColumn In grid.Rows.Band.Columns
            col.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            If Not col.Hidden Then
                width += col.Width
            End If
        Next

        'If width > grid.Width Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.None
        'Else
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If

        Dim contador = 1
        For Each renglon As UltraGridRow In grdParesConfirmadosAnteriormente.Rows
            renglon.Cells("#").Value = contador
            If renglon.Cells("Status").Value = "CANCELADO" Then
                renglon.Appearance.BackColor = pnlPartidaCancelada.BackColor
            End If
            contador += 1
        Next

        If datosConsolidados = False Then
            For Each renglonPartidas As UltraGridRow In grdPartidasConfirmadasyPorConfirmar.Rows
                For Each renglonPares As UltraGridRow In grdParesConfirmadosAnteriormente.Rows
                    If renglonPares.Cells("ApartadoDetalleTalla").Value = renglonPartidas.Cells("ApartadoDetalleTalla").Value Then
                        renglonPares.Cells("Renglon").Value = renglonPartidas.Cells("#").Value
                    End If
                Next
            Next
        End If

        grid.DisplayLayout.Bands(0).Columns("#").Width = 25
        grid.DisplayLayout.Bands(0).Columns("Renglon").Width = 60
        grid.DisplayLayout.Bands(0).Columns("Talla").Width = 40
        grid.DisplayLayout.Bands(0).Columns("Lote").Width = 40
        grid.DisplayLayout.Bands(0).Columns("Año").Width = 50
        grid.DisplayLayout.Bands(0).Columns("Nave").Width = 60
    End Sub

    Private Sub btnExportarConfirmados_Click(sender As Object, e As EventArgs) Handles btnExportarConfirmados.Click
        Cursor = Cursors.WaitCursor
        Dim gridExcelExporter As New ExcelExport.UltraGridExcelExporter
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim grid As New UltraGrid
        Dim nombreDocumento As String = String.Empty
        Dim advertencia As New AdvertenciaForm
        grid = grdParesConfirmadosAnteriormente
        If grid.Rows.GetFilteredInNonGroupByRows.Count > 0 Then

            grid.DisplayLayout.Bands(0).Columns("ApartadoId").Hidden = False
            If datosConsolidados = False Then
                nombreDocumento = "\Pares_Confirmados_Apartados_" + Replace(folioApartado, ",", "-") + "_"
            Else
                nombreDocumento = "\Pares_Confirmados_Apartados_Consolidados_"
            End If


            With fbdUbicacionArchivo

                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog

                If ret = Windows.Forms.DialogResult.OK Then

                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString
                    gridExcelExporter.Export(grid, .SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    With grid.DisplayLayout.Bands(0)
                        .Columns("ApartadoId").Hidden = True
                    End With
                    Dim mensajeExito As New ExitoForm
                    Cursor = Cursors.Default
                    mensajeExito.mensaje = "Los datos se exportaron correctamente"
                    mensajeExito.ShowDialog()

                End If
                .Dispose()
            End With
        Else
            Cursor = Cursors.Default
            advertencia.mensaje = "No hay datos para exportar "
            advertencia.ShowDialog()
        End If
        With grid.DisplayLayout.Bands(0)
            .Columns("ApartadoId").Hidden = True
        End With
        Cursor = Cursors.Default
    End Sub


    Public Sub imprimirApartado()
        Dim dsOrdenesApartado As New DataSet("dsOrdenApartado")
        Dim Apartado As New DataTable("Apartado")
        Dim detalleApartado As New DataTable("DetalleApartado")
        Dim Corridas As New DataTable("Corrida")
        Dim Tallas As New DataTable("Talla")
        Dim Talla1 As New DataTable("Talla1")
        Dim Talla2 As New DataTable("Talla2")
        Dim Talla3 As New DataTable("Talla3")
        Dim Talla4 As New DataTable("Talla4")
        Dim Talla5 As New DataTable("Talla5")
        Dim Talla6 As New DataTable("Talla6")
        Dim Talla7 As New DataTable("Talla7")
        Dim Talla8 As New DataTable("Talla8")
        Dim Talla9 As New DataTable("Talla9")
        Dim Talla10 As New DataTable("Talla10")
        Dim Talla11 As New DataTable("Talla11")
        Dim Talla12 As New DataTable("Talla12")
        Dim Talla13 As New DataTable("Talla13")
        Dim Talla14 As New DataTable("Talla14")
        Dim Talla15 As New DataTable("Talla15")
        Dim TallaBase As New DataTable("TallaBase")
        Dim obj As New Negocios.ApartadosBU
        Dim objBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim idApartado As Integer = 0
        Dim apartadosSeleccionados As String = String.Empty

        Dim tallas1 As String = String.Empty
        Dim ApartadosTallas1 As String = String.Empty
        Dim CorridasTallas1 As String = String.Empty
        Dim tallas2 As String = String.Empty
        Dim ApartadosTallas2 As String = String.Empty
        Dim CorridasTallas2 As String = String.Empty
        Dim tallas3 As String = String.Empty
        Dim ApartadosTallas3 As String = String.Empty
        Dim CorridasTallas3 As String = String.Empty
        Dim tallas4 As String = String.Empty
        Dim ApartadosTallas4 As String = String.Empty
        Dim CorridasTallas4 As String = String.Empty
        Dim tallas5 As String = String.Empty
        Dim ApartadosTallas5 As String = String.Empty
        Dim CorridasTallas5 As String = String.Empty
        Dim tallas6 As String = String.Empty
        Dim ApartadosTallas6 As String = String.Empty
        Dim CorridasTallas6 As String = String.Empty
        Dim tallas7 As String = String.Empty
        Dim ApartadosTallas7 As String = String.Empty
        Dim CorridasTallas7 As String = String.Empty
        Dim tallas8 As String = String.Empty
        Dim ApartadosTallas8 As String = String.Empty
        Dim CorridasTallas8 As String = String.Empty
        Dim tallas9 As String = String.Empty
        Dim ApartadosTallas9 As String = String.Empty
        Dim CorridasTallas9 As String = String.Empty
        Dim tallas10 As String = String.Empty
        Dim ApartadosTallas10 As String = String.Empty
        Dim CorridasTallas10 As String = String.Empty
        Dim tallas11 As String = String.Empty
        Dim ApartadosTallas11 As String = String.Empty
        Dim CorridasTallas11 As String = String.Empty
        Dim tallas12 As String = String.Empty
        Dim ApartadosTallas12 As String = String.Empty
        Dim CorridasTallas12 As String = String.Empty
        Dim tallas13 As String = String.Empty
        Dim ApartadosTallas13 As String = String.Empty
        Dim CorridasTallas13 As String = String.Empty
        Dim tallas14 As String = String.Empty
        Dim ApartadosTallas14 As String = String.Empty
        Dim CorridasTallas14 As String = String.Empty
        Dim tallas15 As String = String.Empty
        Dim ApartadosTallas15 As String = String.Empty
        Dim CorridasTallas15 As String = String.Empty

        If folioApartado <> "" Then

            apartadosSeleccionados = folioApartado

            detalleApartado = obj.imprimirOrdenApartado(apartadosSeleccionados, 2, datosConsolidados)
            detalleApartado.TableName = "DetalleApartado"
            Apartado = obj.imprimirOrdenApartado(apartadosSeleccionados, 1, datosConsolidados)
            Apartado.TableName = "Apartado"
            Corridas = obj.imprimirOrdenApartado(apartadosSeleccionados, 3, datosConsolidados)
            Corridas.TableName = "Corrida"
            Tallas = obj.imprimirOrdenApartado(apartadosSeleccionados, 4, datosConsolidados)
            Tallas.TableName = "Talla"
            Dim contador = 0
            For Each renglon As DataRow In Tallas.Rows

                If contador <> 0 Then
                    tallas1 += ","
                    ApartadosTallas1 += ","
                    CorridasTallas1 += ","
                End If
                tallas1 += "" + renglon.Item("Talla1") + ""
                If datosConsolidados Then
                    ApartadosTallas1 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas1 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas1 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas2 += ","
                    ApartadosTallas2 += ","
                    CorridasTallas2 += ","
                End If
                tallas2 += "" + renglon.Item("Talla2") + ""
                If datosConsolidados Then
                    ApartadosTallas2 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas2 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas2 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas3 += ","
                    ApartadosTallas3 += ","
                    CorridasTallas3 += ","
                End If
                tallas3 += "" + renglon.Item("Talla3") + ""
                If datosConsolidados Then
                    ApartadosTallas3 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas3 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas3 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas4 += ","
                    ApartadosTallas4 += ","
                    CorridasTallas4 += ","
                End If
                tallas4 += "" + renglon.Item("Talla4") + ""
                If datosConsolidados Then
                    ApartadosTallas4 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas4 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas4 += "" + renglon.Item("Corrida") + ""



                If contador <> 0 Then
                    tallas5 += ","
                    ApartadosTallas5 += ","
                    CorridasTallas5 += ","
                End If
                tallas5 += "" + renglon.Item("Talla5") + ""
                If datosConsolidados Then
                    ApartadosTallas5 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas5 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas5 += "" + renglon.Item("Corrida") + ""



                If contador <> 0 Then
                    tallas6 += ","
                    ApartadosTallas6 += ","
                    CorridasTallas6 += ","
                End If
                tallas6 += "" + renglon.Item("Talla6") + ""
                If datosConsolidados Then
                    ApartadosTallas6 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas6 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas6 += "" + renglon.Item("Corrida") + ""



                If contador <> 0 Then
                    tallas7 += ","
                    ApartadosTallas7 += ","
                    CorridasTallas7 += ","
                End If
                tallas7 += "" + renglon.Item("Talla7") + ""
                If datosConsolidados Then
                    ApartadosTallas7 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas7 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas7 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas8 += ","
                    ApartadosTallas8 += ","
                    CorridasTallas8 += ","
                End If
                tallas8 += "" + renglon.Item("Talla8") + ""
                If datosConsolidados Then
                    ApartadosTallas8 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas8 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas8 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas9 += ","
                    ApartadosTallas9 += ","
                    CorridasTallas9 += ","
                End If
                tallas9 += "" + renglon.Item("Talla9") + ""
                If datosConsolidados Then
                    ApartadosTallas9 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas9 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas9 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas10 += ","
                    ApartadosTallas10 += ","
                    CorridasTallas10 += ","
                End If
                tallas10 += "" + renglon.Item("Talla10") + ""
                If datosConsolidados Then
                    ApartadosTallas10 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas10 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas10 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas11 += ","
                    ApartadosTallas11 += ","
                    CorridasTallas11 += ","
                End If
                tallas11 += "" + renglon.Item("Talla11") + ""
                If datosConsolidados Then
                    ApartadosTallas11 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas11 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas11 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas12 += ","
                    ApartadosTallas12 += ","
                    CorridasTallas12 += ","
                End If
                tallas12 += "" + renglon.Item("Talla12") + ""
                If datosConsolidados Then
                    ApartadosTallas12 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas12 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas12 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas13 += ","
                    ApartadosTallas13 += ","
                    CorridasTallas13 += ","
                End If
                tallas13 += "" + renglon.Item("Talla13") + ""
                If datosConsolidados Then
                    ApartadosTallas13 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas13 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas13 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas14 += ","
                    ApartadosTallas14 += ","
                    CorridasTallas14 += ","
                End If
                tallas14 += "" + renglon.Item("Talla14") + ""
                If datosConsolidados Then
                    ApartadosTallas14 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas14 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas14 += "" + renglon.Item("Corrida") + ""


                If contador <> 0 Then
                    tallas15 += ","
                    ApartadosTallas15 += ","
                    CorridasTallas15 += ","
                End If
                tallas15 += "" + renglon.Item("Talla15") + ""
                If datosConsolidados Then
                    ApartadosTallas15 += "" + renglon.Item("NumeroApartadoReal").ToString() + ""
                Else
                    ApartadosTallas15 += "" + renglon.Item("NumeroApartado").ToString() + ""
                End If
                CorridasTallas15 += "" + renglon.Item("Corrida") + ""

                contador += 1
            Next


            TallaBase = obj.imprimirOrdenApartadoTotalUbicacionTallas(",,,", ",,,", datosConsolidados, ",,,")


            If Replace(tallas1, ",", "") <> "" Then
                Talla1 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas1, tallas1, datosConsolidados, CorridasTallas1)
            Else
                Talla1 = TallaBase.Clone()
            End If
            Talla1.TableName = "Talla1"
            If Replace(tallas2, ",", "") <> "" Then
                Talla2 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas2, tallas2, datosConsolidados, CorridasTallas2)
            Else
                Talla2 = TallaBase.Clone()
            End If
            Talla2.TableName = "Talla2"
            If Replace(tallas3, ",", "") <> "" Then
                Talla3 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas3, tallas3, datosConsolidados, CorridasTallas3)
            Else
                Talla3 = TallaBase.Clone()
            End If
            Talla3.TableName = "Talla3"
            If Replace(tallas4, ",", "") <> "" Then
                Talla4 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas4, tallas4, datosConsolidados, CorridasTallas4)
            Else
                Talla4 = TallaBase.Clone()
            End If
            Talla4.TableName = "Talla4"
            If Replace(tallas5, ",", "") <> "" Then
                Talla5 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas5, tallas5, datosConsolidados, CorridasTallas5)
            Else
                Talla5 = TallaBase.Clone()
            End If
            Talla5.TableName = "Talla5"
            If Replace(tallas6, ",", "") <> "" Then
                Talla6 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas6, tallas6, datosConsolidados, CorridasTallas6)
            Else
                Talla6 = TallaBase.Clone()
            End If
            Talla6.TableName = "Talla6"
            If Replace(tallas7, ",", "") <> "" Then
                Talla7 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas7, tallas7, datosConsolidados, CorridasTallas7)
            Else
                Talla7 = TallaBase.Clone()
            End If
            Talla7.TableName = "Talla7"
            If Replace(tallas8, ",", "") <> "" Then
                Talla8 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas8, tallas8, datosConsolidados, CorridasTallas8)
            Else
                Talla8 = TallaBase.Clone()
            End If
            Talla8.TableName = "Talla8"
            If Replace(tallas9, ",", "") <> "" Then
                Talla9 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas9, tallas9, datosConsolidados, CorridasTallas9)
            Else
                Talla9 = TallaBase.Clone()
            End If
            Talla9.TableName = "Talla9"
            If Replace(tallas10, ",", "") <> "" Then
                Talla10 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas10, tallas10, datosConsolidados, CorridasTallas10)
            Else
                Talla10 = TallaBase.Clone()
            End If
            Talla10.TableName = "Talla10"
            If Replace(tallas11, ",", "") <> "" Then
                Talla11 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas11, tallas11, datosConsolidados, CorridasTallas11)
            Else
                Talla11 = TallaBase.Clone()
            End If
            Talla11.TableName = "Talla11"
            If Replace(tallas12, ",", "") <> "" Then
                Talla12 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas12, tallas12, datosConsolidados, CorridasTallas12)
            Else
                Talla12 = TallaBase.Clone()
            End If
            Talla12.TableName = "Talla12"
            If Replace(tallas13, ",", "") <> "" Then
                Talla13 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas13, tallas13, datosConsolidados, CorridasTallas13)
            Else
                Talla13 = TallaBase.Clone()
            End If
            Talla13.TableName = "Talla13"
            If Replace(tallas14, ",", "") <> "" Then
                Talla14 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas14, tallas14, datosConsolidados, CorridasTallas14)
            Else
                Talla14 = TallaBase.Clone()
            End If
            Talla14.TableName = "Talla14"
            If Replace(tallas15, ",", "") <> "" Then
                Talla15 = obj.imprimirOrdenApartadoTotalUbicacionTallas(ApartadosTallas15, tallas15, datosConsolidados, CorridasTallas15)
            Else
                Talla15 = TallaBase.Clone()
            End If
            Talla15.TableName = "Talla15"

            dsOrdenesApartado.Tables.Clear()
            dsOrdenesApartado.Tables.Add(Apartado)
            dsOrdenesApartado.Tables.Add(detalleApartado)
            dsOrdenesApartado.Tables.Add(Corridas)
            dsOrdenesApartado.Tables.Add(Tallas)
            dsOrdenesApartado.Tables.Add(Talla1)
            dsOrdenesApartado.Tables.Add(Talla2)
            dsOrdenesApartado.Tables.Add(Talla3)
            dsOrdenesApartado.Tables.Add(Talla4)
            dsOrdenesApartado.Tables.Add(Talla5)
            dsOrdenesApartado.Tables.Add(Talla6)
            dsOrdenesApartado.Tables.Add(Talla7)
            dsOrdenesApartado.Tables.Add(Talla8)
            dsOrdenesApartado.Tables.Add(Talla9)
            dsOrdenesApartado.Tables.Add(Talla10)
            dsOrdenesApartado.Tables.Add(Talla11)
            dsOrdenesApartado.Tables.Add(Talla12)
            dsOrdenesApartado.Tables.Add(Talla13)
            dsOrdenesApartado.Tables.Add(Talla14)
            dsOrdenesApartado.Tables.Add(Talla15)

            If datosConsolidados Then
                EntidadReporte = objBU.LeerReporteporClave("ALM_APAR_ORDAPARTADO_CONSOLIDADO")
            Else
                EntidadReporte = objBU.LeerReporteporClave("ALM_APAR_ORDAPARTADO")
            End If
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport
            reporte.Load(archivo)

            reporte.Compile()
            reporte.Dictionary.Clear()
            reporte.RegData(dsOrdenesApartado)
            reporte.Dictionary.Synchronize()
            reporte.Show()

        Else

            show_message("Advertencia", "No hay datos para imprimir. Primero debe seleccionar un apartado")

        End If

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

#Region "Metodos Anteriores para Cargar Archivo"
    'Public Sub CargarArchivoLeerTerminal()
    '    Dim myStream As Stream = Nothing
    '    Dim openFileDialog As New OpenFileDialog
    '    Dim MensajeError As New ErroresForm
    '    Dim MensajeAviso As New AvisoForm
    '    openFileDialog.InitialDirectory = "c:\"
    '    openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"
    '    openFileDialog.FilterIndex = 2
    '    openFileDialog.RestoreDirectory = True

    '    MensajeAviso.mensaje = "Este proceso puede tardar dependiendo de la cantidad de pares a validar"
    '    MensajeAviso.ShowDialog()
    '    If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        Me.Cursor = Cursors.WaitCursor
    '        Try
    '            myStream = openFileDialog.OpenFile()
    '            If (openFileDialog.FileName IsNot Nothing) Then

    '                LeerLineasArchivoCargado(openFileDialog.FileName, 1)
    '                rutaArchivoApartadosGlobal = openFileDialog.FileName
    '                apartadoActual = 1
    '                If totalApartadoEnArchivo = 1 Then
    '                    btnSiguienteApartado.Enabled = False
    '                    btnAnteriorApartado.Enabled = False
    '                    lblTextoApartadoSiguiente.Enabled = False
    '                    lblTextoApartadoAnterior.Enabled = False
    '                ElseIf totalApartadoEnArchivo > 1 Then
    '                    btnSiguienteApartado.Enabled = True
    '                    lblTextoApartadoSiguiente.Enabled = True
    '                End If

    '            End If
    '        Catch Ex As Exception
    '            MensajeError.mensaje = "No se puede leer el archivo. Error original: " & Ex.Message
    '            MensajeError.ShowDialog()
    '        Finally

    '            If (myStream IsNot Nothing) Then
    '                myStream.Close()
    '            End If
    '        End Try
    '        Me.Cursor = Cursors.Default
    '    End If
    'End Sub


    'Public Sub LeerLineasArchivoCargado(ByVal ruta As String, ByVal apartadoEnArchivo As Integer)
    '    Dim reader As New StreamReader(ruta)
    '    Dim linea As String = ""
    '    Dim arrArchivo As New ArrayList()
    '    Dim cadenaLectura As String = ""
    '    LecturaTerminal = True
    '    Dim codigosLectura As String()
    '    Dim Noatado As Integer = 0
    '    Dim validacionAtado As Integer = 0
    '    Dim numApartado As String = String.Empty
    '    Dim numLinea As Integer = 0
    '    Dim numApartadoBuscarEnArchivo As Integer = 0
    '    lblTotalCodigosInvalidos.Text = "0"
    '    ListaCodigosInvalidos.Clear()

    '    Do
    '        linea = reader.ReadLine
    '        If Not linea Is Nothing And Split(linea, "-")(0).ToUpper() = "AP" Then
    '            If vueltaLectura = 1 Then
    '                arrApartadosEnArchivo.Add(linea)
    '            End If
    '            numApartadoBuscarEnArchivo += 1
    '        End If
    '        If Not linea Is Nothing And numApartadoBuscarEnArchivo = apartadoEnArchivo Then
    '            arrArchivo.Add(linea)
    '        End If
    '    Loop Until linea Is Nothing
    '    reader.Close()

    '    If numApartadoBuscarEnArchivo > 0 Then

    '        numApartado = Split(arrArchivo(0).ToString, "-")(0).ToUpper()
    '        totalApartadoEnArchivo = arrApartadosEnArchivo.Count()

    '        If numApartado = "AP" Then

    '            CargarDatosApartadoLeido(arrArchivo(0))
    '            lblTextoCodigosInvalidos.Visible = True
    '            lblTotalCodigosInvalidos.Visible = True
    '            If folioApartado > 0 And lblNombreCliente.Visible = True Then

    '                Me.Cursor = Cursors.WaitCursor
    '                For cont = 1 To arrArchivo.Count - 1
    '                    If LTrim(RTrim(arrArchivo.Item(cont))) <> "" Then
    '                        If (LTrim(RTrim(arrArchivo.Item(cont)))).Length > 25 And (LTrim(RTrim(arrArchivo.Item(cont)))).Length < 30 Then
    '                            codigosLectura = (LTrim(RTrim(arrArchivo.Item(cont)))).Split("-")
    '                            If codigosLectura.Length = 1 Then
    '                                codigosLectura = (LTrim(RTrim(arrArchivo.Item(cont)))).Split("'")
    '                                If codigosLectura.Length = 1 Then
    '                                    ReproducirSonidoError()
    '                                End If
    '                            End If
    '                            cadenaLectura = codigosLectura(2)
    '                            Noatado = cadenaLectura.Substring(8, 1)
    '                            EsAtado = False
    '                            validaEstiloLectura(cadenaLectura, Noatado, False)
    '                            If TotalParesExcedentes = 1 Then
    '                                Exit Sub
    '                            End If

    '                        ElseIf (LTrim(RTrim(arrArchivo.Item(cont)))).Length = 11 Then
    '                            cadenaLectura = (LTrim(RTrim(arrArchivo.Item(cont))))
    '                            Noatado = cadenaLectura.Substring(8, 1)
    '                            EsAtado = True
    '                            validacionAtado = validaAtado(cadenaLectura)
    '                            If validacionAtado = 0 Then
    '                                validaEstiloLectura(cadenaLectura, Noatado, False)
    '                                If TotalParesExcedentes = 1 Then
    '                                    Exit Sub
    '                                End If
    '                            Else
    '                                lblTotalCodigosInvalidos.Text = Integer.Parse(lblTotalCodigosInvalidos.Text) + 1
    '                                ListaCodigosInvalidos.Add(arrArchivo.Item(cont) + " - " + If(validacionAtado = 3, "Atado no disponible", If(validacionAtado = 2, "Atado con pares confirmados anteriormente", "")))
    '                                ReproducirSonidoError()
    '                            End If
    '                            'validaEstiloLectura(cadenaLectura, Noatado, False)

    '                        Else
    '                            lblTotalCodigosInvalidos.Text = Integer.Parse(lblTotalCodigosInvalidos.Text) + 1
    '                            ListaCodigosInvalidos.Add(arrArchivo.Item(cont) + " - Código no reconocido")
    '                            ReproducirSonidoError()
    '                        End If
    '                    End If
    '                Next
    '                Me.Cursor = Cursors.Default
    '            End If
    '        Else
    '            show_message("Advertencia", "Es necesario leer el codigo del apartado a confirmar antes de los pares del mismo.")
    '        End If
    '    Else
    '        'show_message("Advertencia", "No hay datos en el archivo cargado o son incorrectos, verifique por favor.")
    '        show_message("Advertencia", "Es necesario leer el codigo del apartado a confirmar antes de los pares del mismo.")
    '    End If



    '    If Integer.Parse(lblTotalCodigosInvalidos.Text) > 0 Then
    '        Dim ventanaCodigosInvalidos As New CodigosInvalidosForm
    '        ventanaCodigosInvalidos.StartPosition = FormStartPosition.CenterScreen
    '        ventanaCodigosInvalidos.ListaCodigosInvalidos = ListaCodigosInvalidos
    '        ventanaCodigosInvalidos.numApartado = Integer.Parse(lblIdApartado.Text)
    '        mostrarVentanaCodigosInvalidos(ventanaCodigosInvalidos)
    '    End If

    'End Sub

    ''valida que el par leido pertenezca a los pares de la venta
    'Public Sub validaEstiloLectura(ByVal codigo As String, ByVal NumeroAtado As Integer, ByVal guardar As Boolean)
    '    Dim objBu As New Negocios.ApartadosBU
    '    Dim ListaDetallePar As New List(Of Entidades.ParesConfirmarApartado)
    '    Dim estatus As String = ""
    '    Dim cantidad, confirmado, renglon As Int32
    '    Dim idDetalleTalla As Int32 = 0

    '    Dim parRepetido As Int32 = 0

    '    ListaDetallePar = objBu.ValidarParLeidoConfirmacion(codigo, EsAtado)
    '    Dim total, totalActual As Integer
    '    total = grdParesConfirmandoActualmente.Rows.Count
    '    totalActual = 0
    '    For Each detallePar As Entidades.ParesConfirmarApartado In ListaDetallePar
    '        renglon = 0
    '        parRepetido = 0
    '        If detallePar.PPar <> Nothing Then
    '            If guardar = False Then
    '                For Each rowPar As UltraGridRow In grdParesConfirmandoActualmente.Rows
    '                    If rowPar.Cells("ID_Par").Value = detallePar.PPar Then
    '                        parRepetido += 1
    '                    End If
    '                Next
    '            End If
    '            If parRepetido = 0 Then
    '                For Each row As UltraGridRow In grdPartidasConfirmadasyPorConfirmar.Rows
    '                    'If (row.Cells("Estatus_Renglon").Value.Equals("I") Or IsDBNull(row.Cells("Estatus_Renglon").Value)) Or (guardar = True) Then
    '                    If (row.Cells("partidaConfirmada").Value = 0 Or IsDBNull(row.Cells("partidaConfirmada").Value)) And row.Cells("Estatus").Value <> 46 Then
    '                        If row.Cells("IdProducto").Value.ToString.Trim = detallePar.PIdProducto And row.Cells("Talla").Value.ToString.Trim = detallePar.PTalla Then
    '                            'And row.Cells("otcod_talla").Value = detallePar.PCalce Then
    '                            '
    '                            totalActual = totalActual + 1
    '                            estatus = "C" 'correcto
    '                            renglon = row.Cells("#").Value
    '                            If guardar = False Then
    '                                cantidad = row.Cells("Faltante").Value - 1
    '                                confirmado = row.Cells("Conf").Value + 1
    '                            Else
    '                                cantidad = row.Cells("faltante").Value
    '                                confirmado = row.Cells("conf").Value
    '                            End If
    '                            idDetalleTalla = row.Cells("ApartadoDetalleTalla").Value
    '                            Exit For
    '                        Else
    '                            If guardar = False Then
    '                                estatus = "I"
    '                                'ReproducirSonidoError()
    '                            End If
    '                        End If
    '                    Else
    '                        estatus = "I"
    '                    End If
    '                Next
    '            End If
    '        End If
    '        If estatus = "C" And estatusEscaneado <> "I" Then
    '            actualizarFaltanteGridPares(cantidad, idDetalleTalla, confirmado, detallePar, guardar)
    '        End If
    '        If parRepetido = 0 And guardar = False Then
    '            AgregarParGrid(detallePar, estatus, renglon, NumeroAtado, idDetalleTalla)
    '            If estatus = "I" Then
    '                TotalParesExcedentes = 1
    '                'txtCapturaCodigos.Enabled = False
    '                Exit For
    '            End If
    '        End If
    '    Next

    '    'If ListaDetallePar.Count = 0 Or parRepetido > 0 And guardar = False Then
    '    If ListaDetallePar.Count = 0 And guardar = False Then
    '        'lblMensajeCapturaCodigos.Visible = True
    '        lblTotalCodigosInvalidos.Text = Integer.Parse(lblTotalCodigosInvalidos.Text) + 1
    '        'ListaCodigosInvalidos.Add(codigo + " - " + If(ListaDetallePar.Count = 0, "Par no disponible", If(parRepetido > 0, "Par escaneado varias veces", "")))
    '        ReproducirSonidoError()
    '        ListaCodigosInvalidos.Add(codigo + " - " + If(ListaDetallePar.Count = 0, "Par no disponible", ""))
    '    End If
    'End Sub

    'Public Sub VerificarParYaEscaneado()
    '    estatusEscaneado = ""
    '    For cont = 0 To grdParesConfirmandoActualmente.Rows.Count - 1
    '        'If cont = 0 Then
    '        '    Exit For
    '        'End If
    '        If grdParesConfirmandoActualmente.Rows(cont).Cells("Par").Value.ToString.Trim = ParEscaneado Then
    '            ReproducirSonidoError()
    '            grdParesConfirmandoActualmente.Rows(cont).Cells("estatus").Value = "I"
    '            estatusEscaneado = "I"
    '            Exit For
    '        End If
    '    Next
    'End Sub

    ''valida que el atado leido este disponible para confirmar
    'Public Function validaAtado(ByVal NumeroAtado As String)
    '    Dim objBu As New Negocios.ApartadosBU
    '    Dim validacionAtado As Integer
    '    Dim tablaValidacion As DataTable
    '    tablaValidacion = objBu.validaAtadoLeidoConfirmacion(NumeroAtado)
    '    For Each row As DataRow In tablaValidacion.Rows
    '        validacionAtado = Integer.Parse(row.Item("validacionAtado"))
    '    Next
    '    Return validacionAtado
    'End Function

    'Public Sub AgregarParGrid(DetallePar As Entidades.ParesConfirmarApartado, ByVal estatus As String, ByVal renglon As Int32, ByVal NoAtado As Int32, ByVal idDetalleTalla As Integer)
    '    '   VerificarParYaEscaneado()
    '    Dim advertencia As New AdvertenciaFormSinBoton
    '    Dim rowPar As UltraGridRow = Me.grdParesConfirmandoActualmente.DisplayLayout.Bands(0).AddNew
    '    Dim totalExternos As Integer = 0
    '    Dim totalCorrectos As Integer = 0

    '    totalExternos = Integer.Parse(lblTotalExternos.Text)
    '    totalCorrectos = Integer.Parse(lblTotalCorrectos.Text)
    '    If estatusEscaneado = "I" Then
    '        ' rowPar.CellAppearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8080")
    '        rowPar.Cells("renglon").Value = 0
    '        rowPar.Cells("estatus").Value = estatusEscaneado
    '        rowPar.Cells("idDetalleTalla").Value = 0
    '    Else
    '        rowPar.Cells("renglon").Value = renglon
    '        rowPar.Cells("estatus").Value = estatus
    '        rowPar.Cells("idDetalleTalla").Value = idDetalleTalla
    '    End If

    '    rowPar.Cells("Producto").Value = DetallePar.PIdProducto
    '    'rowPar.Cells("PartidaPedido").Value = DetallePar.PPartidaPedido
    '    'rowPar.Cells("PartidaApartado").Value = DetallePar.PPartidaApartado
    '    rowPar.Cells("estatus").Value = estatus

    '    rowPar.Cells("ID_Docena").Value = DetallePar.PAtado

    '    rowPar.Cells("ID_Par").Value = DetallePar.PPar
    '    rowPar.Cells("NumeroAtado").Value = NoAtado
    '    rowPar.Cells("Lote").Value = DetallePar.PLote
    '    rowPar.Cells("Descripcion").Value = DetallePar.PDescripcion
    '    rowPar.Cells("Talla").Value = DetallePar.PTalla

    '    rowPar.Cells("nave").Value = DetallePar.PNave
    '    rowPar.Cells("EntradaAlmacen").Value = DetallePar.PEntradaAlmacen
    '    rowPar.Cells("Año").Value = DetallePar.PAño
    '    rowPar.Cells("IdNave").Value = DetallePar.PIdNave


    '    If rowPar.Cells("estatus").Value = "I" Then
    '        'rowPar.Cells("TipoPar").Value = ""
    '        rowPar.CellAppearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8080")
    '        btnGuardar.Enabled = False
    '        ReproducirSonidoError()
    '        advertencia.mensaje = "Se detectó producto que no se puede confirmar en este apartado, limpia y vuelve a leer"
    '        advertencia.ShowDialog()

    '        'Else
    '        '    If DetallePar.PTipoPar = "E" Then
    '        '        rowPar.Cells("TipoPar").Appearance.BackColor = Color.Red
    '        '        totalExternos += 1
    '        '        lblTotalExternos.Text = totalExternos.ToString()
    '        '    ElseIf DetallePar.PTipoPar = "C" Then
    '        '        rowPar.Cells("TipoPar").Appearance.BackColor = Color.Green
    '        '        totalCorrectos += 1
    '        '        lblTotalCorrectos.Text = totalCorrectos.ToString()
    '        '    End If

    '    End If




    '    EnumerarIndicesRenglonGrid()



    'End Sub

#End Region

    ''sonido de error 
    Public Sub ReproducirSonidoError()
        Dim player As New SoundPlayer(My.Resources.beep_04)
        player.Play()
    End Sub


    Public Sub actualizarFaltanteGridPares(ByVal cantidad As Int32, ByVal idDetalleTalla As Int32, ByVal confirmado As Int32, ByVal detallePar As Entidades.ParesConfirmarApartado, ByVal guardar As Boolean)
        Dim totalPares As Integer = 0
        Dim totalConfirmar As Integer = 0
        Dim totalFaltante As Integer = 0
        Dim totalCancelado As Integer = 0
        Dim estatusTienda As String = ""
        For cont = 0 To grdPartidasConfirmadasyPorConfirmar.Rows.Count - 1
            If grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("ApartadoDetalleTalla").Value = idDetalleTalla Then
                If guardar = False Then
                    grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Faltante").Value = cantidad
                    grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Conf").Value = confirmado
                End If
                estatusTienda = "PC"
                If grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Total").Value = grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Conf").Value Then
                    If guardar = False Then
                        grdPartidasConfirmadasyPorConfirmar.Rows(cont).CellAppearance.BackColor = DefaultBackColor
                        grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("partidaConfirmada").Value = 1
                    End If
                    partidasCompletas = partidasCompletas + 1
                    If partidasCompletas >= grdPartidasConfirmadasyPorConfirmar.Rows.Count Then
                        estatusTienda = "C"
                    End If
                End If
                If grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Total").Value = grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Conf_Real").Value Then
                    If guardar = False Then
                        grdPartidasConfirmadasyPorConfirmar.Rows(cont).CellAppearance.BackColor = DefaultBackColor
                        grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("partidaConfirmada").Value = 1
                    End If
                    partidasCompletas = partidasCompletas + 1
                    If partidasCompletas >= grdPartidasConfirmadasyPorConfirmar.Rows.Count Then
                        estatusTienda = "C"
                    End If
                End If
            End If
            'If guardar = True Then
            '    guardarPar(detallePar, idDetalleTalla, idOtCoppel, confirmado, estatusTienda)
            'End If
            totalPares = totalPares + grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Total").Value
            totalConfirmar = totalConfirmar + grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Conf").Value
            totalFaltante = totalFaltante + grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Faltante").Value
            totalCancelado = totalCancelado + If(grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Estatus").Value = 46, grdPartidasConfirmadasyPorConfirmar.Rows(cont).Cells("Total").Value, 0)
        Next
        lblTotalPares.Text = totalPares.ToString("n0")
        lblPorConfirmar.Text = totalFaltante.ToString("n0")
        lblTotalConfirmados.Text = totalConfirmar.ToString("n0")
        lblCancelados.Text = totalCancelado.ToString("n0")

    End Sub




    Public Sub EnumerarIndicesRenglonGrid()
        For cont = grdParesConfirmandoActualmente.Rows.Count - 1 To 0 Step -1
            If grdParesConfirmandoActualmente.Rows.Count = 1 Then
                grdParesConfirmandoActualmente.Rows(cont).Cells("#").Value = 1
                cont = 0
            Else
                grdParesConfirmandoActualmente.Rows(cont).Cells("#").Value = grdParesConfirmandoActualmente.Rows(cont - 1).Cells("#").Value + 1
                cont = 0
            End If
        Next
    End Sub

    Public Sub CargarDatosApartadoLeido(ByVal Apartado As String)
        Dim idApartado As String = String.Empty
        Dim dtDatosApartado As New DataTable
        Dim ObjBu As New Negocios.ApartadosBU
        'Dim ClienteBloqueado As String = String.Empty
        Dim EntregaIn As Boolean = False

        idApartado = Split(Apartado, "-")(1)
        folioApartado = idApartado
        dtDatosApartado = ObjBu.consultarDatosApartadoAConfirmar(idApartado)

        If dtDatosApartado.Rows.Count > 0 Then
            totalApartadosSeleccionados = 1

            cliente = dtDatosApartado.Rows(0).Item("Cliente").ToString()
            folioApartado = idApartado
            pedidoSAY = dtDatosApartado.Rows(0).Item("PedidoSay").ToString()
            pedidoSICY = dtDatosApartado.Rows(0).Item("PedidoSICY").ToString()
            ordenCliente = dtDatosApartado.Rows(0).Item("OrdenCliente").ToString()
            fechaSolicitada = dtDatosApartado.Rows(0).Item("FSolicitada").ToString()
            fechaPreparacion = dtDatosApartado.Rows(0).Item("FPreparacion").ToString()
            EntregaIn = dtDatosApartado.Rows(0).Item("EntregaInmediata")
            If EntregaIn Then
                entregaInmediata = 1
            Else
                entregaInmediata = 0
            End If
            apartadoSICY = dtDatosApartado.Rows(0).Item("ApartadoSICY").ToString()
            statusApartado = dtDatosApartado.Rows(0).Item("Estatus").ToString()

            IdCadena = Integer.Parse(dtDatosApartado.Rows(0).Item("IdCadena").ToString())

            tipoBloqueoCliente = dtDatosApartado.Rows(0).Item("BLOQUEADOAPARTADO").ToString()
            If tipoBloqueoCliente <> "" Then
                totalApartadosClientesBloqueados = 1
                clienteBloqueado = True
            Else
                clienteBloqueado = False
            End If

            CargarDatos()
        Else
            show_message("Advertencia", "No se encuentra el apartado, verifique el archivo.")
        End If
    End Sub

    Private Sub grdParesConfirmandoActualmente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdParesConfirmandoActualmente.InitializeLayout
        With grdParesConfirmandoActualmente.DisplayLayout.Bands(0)

            '.Columns("PartidaApartado").Hidden = True
            '.Columns("PartidaPedido").Hidden = True
            '.Columns("Nave").Hidden = True
            .Columns("Producto").Hidden = True
            '.Columns("Atado").Hidden = True
            .Columns("NumeroAtado").Hidden = True
            .Columns("idDetalleTalla").Hidden = True
            .Columns("IdNave").Hidden = True

            .Columns("Talla").Header.Caption = "Talla"
            .Columns("Renglon").Header.Caption = "Renglón"
            .Columns("#").Header.Caption = "#"
            .Columns("ID_Par").Header.Caption = "Par"
            .Columns("ID_Docena").Header.Caption = "Atado"
            .Columns("Lote").Header.Caption = "Lote"
            .Columns("Descripcion").Header.Caption = "Descripción"
            .Columns("EntradaAlmacen").Header.Caption = "Entrada Almacén"
            .Columns("idDetalleTalla").Header.Caption = "idDetalleTalla"
            .Columns("#").CellActivation = Activation.NoEdit
            .Columns("ID_Par").CellActivation = Activation.NoEdit
            .Columns("ID_Docena").CellActivation = Activation.NoEdit
            .Columns("Lote").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .Columns("Renglon").CellActivation = Activation.NoEdit
            .Columns("Talla").CellActivation = Activation.NoEdit
            .Columns("EntradaAlmacen").CellActivation = Activation.NoEdit

            .Columns("EntradaAlmacen").Format = "dd/MM/yyyy HH:mm:ss"

            .Columns("idDetalleTalla").CellActivation = Activation.NoEdit
            .Columns("IdNave").CellActivation = Activation.NoEdit

            '.Columns("NumeroAtado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Talla").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Renglon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With

        grdParesConfirmandoActualmente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdParesConfirmandoActualmente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdParesConfirmandoActualmente.DisplayLayout.Override.RowSelectorWidth = 25

        grdParesConfirmandoActualmente.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        grdParesConfirmandoActualmente.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdParesConfirmandoActualmente.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grdParesConfirmandoActualmente.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        grdParesConfirmandoActualmente.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdParesConfirmandoActualmente.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdParesConfirmandoActualmente.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grdParesConfirmandoActualmente.DisplayLayout.GroupByBox.Hidden = False
        grdParesConfirmandoActualmente.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"

        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("#").Width = 25
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("ID_Par").Width = 90
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("ID_Docena").Width = 90
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("Lote").Width = 60
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("Nave").Width = 60
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("Año").Width = 50
        'grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("NumeroAtado").Width = 30
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("Renglon").Width = 60
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("Talla").Width = 40
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("Descripcion").Width = 220
        grdParesConfirmandoActualmente.DisplayLayout.Bands(0).Columns("EntradaAlmacen").Width = 120
    End Sub

    ''Se crean las columnas con el formato que tendra el grid de los pares de la lectura
    Public Sub FormatoGridParesConfirmar()


        Dim dtParesConfirmar As New DataTable

        Dim ColumnaLote As New DataColumn("Lote")
        ColumnaLote.DataType = GetType(Int32)

        Dim ColumnaAtado As New DataColumn("ID_Docena")
        ColumnaAtado.DataType = GetType(String)

        Dim ColumnaPar As New DataColumn("ID_Par")
        ColumnaPar.DataType = GetType(String)

        Dim ColumnaRenglon As New DataColumn("Renglon")
        ColumnaRenglon.DataType = GetType(Int32)

        Dim ColumnaCalce As New DataColumn("Talla")
        ColumnaCalce.DataType = GetType(String)

        Dim ColumnaProducto As New DataColumn("Producto")
        ColumnaProducto.DataType = GetType(String)

        Dim ColumnaDescripcion As New DataColumn("Descripcion")
        ColumnaDescripcion.DataType = GetType(String)

        Dim ColumnaNumero As New DataColumn("#")
        ColumnaNumero.DataType = GetType(Int32)

        Dim columnaNave As New DataColumn("Nave")
        columnaNave.DataType = GetType(String)

        Dim columnaEntradaAlmacen As New DataColumn("EntradaAlmacen")
        columnaEntradaAlmacen.DataType = GetType(DateTime)

        Dim columnaAño As New DataColumn("Año")
        columnaAño.DataType = GetType(String)

        Dim columnaEstatus As New DataColumn("Estatus")
        columnaEstatus.DataType = GetType(String)

        Dim ColumnaNoAtado As New DataColumn("NumeroAtado")
        ColumnaNoAtado.DataType = GetType(Int32)

        Dim ColumnaIdDetalleTalla As New DataColumn("idDetalleTalla")
        ColumnaIdDetalleTalla.DataType = GetType(Int32)

        Dim ColumnaIdNave As New DataColumn("IdNave")
        ColumnaIdNave.DataType = GetType(Int32)

        dtParesConfirmar.Columns.Add(ColumnaNumero)
        dtParesConfirmar.Columns.Add(ColumnaAtado)
        dtParesConfirmar.Columns.Add(ColumnaPar)
        dtParesConfirmar.Columns.Add(ColumnaDescripcion)
        dtParesConfirmar.Columns.Add(ColumnaRenglon)
        dtParesConfirmar.Columns.Add(ColumnaCalce)
        dtParesConfirmar.Columns.Add(ColumnaLote)
        dtParesConfirmar.Columns.Add(columnaNave)
        dtParesConfirmar.Columns.Add(columnaAño)
        dtParesConfirmar.Columns.Add(columnaEntradaAlmacen)
        dtParesConfirmar.Columns.Add(ColumnaIdDetalleTalla)
        dtParesConfirmar.Columns.Add(ColumnaIdNave)

        dtParesConfirmar.Columns.Add(columnaEstatus)

        dtParesConfirmar.Columns.Add(ColumnaProducto)

        dtParesConfirmar.Columns.Add(ColumnaNoAtado)

        grdParesConfirmandoActualmente.DataSource = Nothing
        grdParesConfirmandoActualmente.DataSource = dtParesConfirmar
        grdParesConfirmandoActualmente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdParesConfirmandoActualmente.DisplayLayout.Override.RowSelectorWidth = 35

        With grdParesConfirmandoActualmente.DisplayLayout.Bands(0)

            '.Columns("PartidaApartado").Hidden = True
            '.Columns("PartidaPedido").Hidden = True
            '.Columns("Nave").Hidden = True
            .Columns("Producto").Hidden = True
            .Columns("Estatus").Hidden = True
            '.Columns("Atado").Hidden = True
            .Columns("NumeroAtado").Hidden = True
            .Columns("idDetalleTalla").Hidden = True
            .Columns("IdNave").Hidden = True

            .Columns("Talla").Header.Caption = "Talla"
            .Columns("Renglon").Header.Caption = "Renglón"
            .Columns("#").Header.Caption = "#"
            .Columns("ID_Par").Header.Caption = "Par"
            .Columns("ID_Docena").Header.Caption = "Atado"
            .Columns("Lote").Header.Caption = "Lote"
            .Columns("Descripcion").Header.Caption = "Descripción"
            .Columns("EntradaAlmacen").Header.Caption = "Entrada Almacén"
            .Columns("idDetalleTalla").Header.Caption = "idDetalleTalla"
            .Columns("idDetalleTalla").CellActivation = Activation.NoEdit
            .Columns("IdNave").CellActivation = Activation.NoEdit
            .Columns("#").CellActivation = Activation.NoEdit
            .Columns("ID_Par").CellActivation = Activation.NoEdit
            .Columns("ID_Docena").CellActivation = Activation.NoEdit
            .Columns("Lote").CellActivation = Activation.NoEdit
            .Columns("Descripcion").CellActivation = Activation.NoEdit
            .Columns("Renglon").CellActivation = Activation.NoEdit
            .Columns("Talla").CellActivation = Activation.NoEdit
            .Columns("EntradaAlmacen").CellActivation = Activation.NoEdit

            '.Columns("NumeroAtado").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Talla").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("Renglon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
        End With


    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

        Dim confirmacion As New ConfirmarForm
        Dim mensajeConfirmacion As String = String.Empty

        'If grdParesConfirmandoActualmente.Rows.Count > 0 Then
        mensajeConfirmacion = "Todos los datos no guardados se perderán ¿Está seguro que desea limpiar la pantalla?"
        confirmacion.mensaje = mensajeConfirmacion
        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            LimpiarSinConfirmacion()
            'lblTextoCliente.Visible = False
            'lblTextoApartadoSICY.Visible = False
            'lblTextoFolioApartado.Visible = False
            'lblTextoPedidoSAY.Visible = False
            'lblTextoPedidoSICY.Visible = False
            'lblTextoOrdenCliente.Visible = False
            'lblTextoFSolicitada.Visible = False
            'lblTextoFPreparacion.Visible = False
            'lblEntregaInmediata.Visible = False
            'lblEstatusApartado.Visible = False
            'lblNombreCliente.Visible = False
            'cliente = ""
            'lblIdApartado.Visible = False
            'folioApartado = ""
            'lblIdApartadoSICY.Visible = False
            'apartadoSICY = 0
            'lblIdPedidoSAY.Visible = False
            'pedidoSAY = 0
            'lblIdPedidoSICY.Visible = False
            'pedidoSICY = 0
            'lblOrdenCliente.Visible = False
            'ordenCliente = ""
            'lblFSolicitada.Visible = False
            'fechaSolicitada = ""
            'lblFPreparacion.Visible = False
            'fechaPreparacion = ""
            'lblTextoTotalApartadosSeleccionados.Visible = False
            'lblTotalApartadosSeleccionados.Visible = False
            'totalApartadosSeleccionados = 0

            'totalApartadosClientesBloqueados = 0
            'statusApartado = ""
            'entregaInmediata = 0

            'grdPartidasConfirmadasyPorConfirmar.DataSource = Nothing
            'grdParesConfirmadosAnteriormente.DataSource = Nothing
            'grdParesConfirmandoActualmente.DataSource = Nothing
            'lblTotalPares.Text = "0"
            'lblTotalConfirmados.Text = "0"
            'lblPorConfirmar.Text = "0"

            'btnImprimirDetalles.Enabled = False
            'lblTextoImprimirDetalles.Enabled = False
            'btnExportarConfirmados.Enabled = False
            'lblTextoExportarConfirmados.Enabled = False
            'btnExportarDetalles.Enabled = False
            'lblTextoExportarDetalles.Enabled = False

            'btnGuardar.Enabled = True
            'lblGuardar.Enabled = True
        End If
        'Else
        'LimpiarSinConfirmacion()
        'End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Cursor = Cursors.WaitCursor
        Dim totalPares As Integer
        Dim totalParesConfirmados As Integer
        Dim totalParesFaltantes As Integer
        Dim totalParesCancelados As Integer
        Dim confirmacion As New ConfirmarForm
        Dim mensajeConfirmacion As String = String.Empty
        Dim parConfirmar As New Entidades.ParesConfirmarApartado
        Dim objBu As New Negocios.ApartadosBU
        Dim colaboradorConfirmaId As Integer
        Dim tablaParesConfirmandoSinAgrupar As New DataTable
        If grdPartidasConfirmadasyPorConfirmar.Rows.Count > 0 Then
            If grdParesConfirmandoActualmente.Rows.Count > 0 Then
                If clienteBloqueado = False Then
                    If statusApartado <> "ACTIVO" And statusApartado <> "PARCIALMENTE CONFIRMADO" Then
                        show_message("Advertencia", "Solo se pueden confirmar apartados ""ACTIVOS"" y ""PARCIALMENTE CONFIRMADOS"" ")
                    Else
                        totalPares = Integer.Parse(Replace(lblTotalPares.Text, ",", ""))
                        totalParesConfirmados = Integer.Parse(Replace(lblTotalConfirmados.Text, ",", ""))
                        totalParesFaltantes = Integer.Parse(Replace(lblPorConfirmar.Text, ",", ""))
                        totalParesCancelados = Integer.Parse(Replace(lblCancelados.Text, ",", ""))
                        If totalParesFaltantes > 0 And totalParesConfirmados > 0 Then
                            mensajeConfirmacion = "El apartado quedará parcialmente confirmado. ¿Está seguro que desea guardar?"
                        ElseIf totalParesFaltantes = 0 And totalParesConfirmados = totalPares - totalParesCancelados Then
                            mensajeConfirmacion = "¿Está seguro que desea guardar?"
                        End If
                        colaboradorConfirmaId = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser
                        confirmacion.mensaje = mensajeConfirmacion
                        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            btnGuardar.Enabled = False
                            lblGuardar.Enabled = False
                            tablaParesConfirmandoSinAgrupar = grdParesConfirmandoActualmente.DataSource
                            Try
                                objBu.ActualizaPartidasYApartadosAntesDeConfirmacion(Integer.Parse(lblIdApartado.Text))
                                For Each renglon As DataRow In tablaParesConfirmandoSinAgrupar.Rows
                                    parConfirmar = New Entidades.ParesConfirmarApartado
                                    parConfirmar.PPar = renglon.Item("ID_Par").ToString()
                                    parConfirmar.PAtado = renglon.Item("ID_Docena").ToString()
                                    parConfirmar.PIdNave = Integer.Parse(renglon.Item("IdNave").ToString())
                                    parConfirmar.PLote = renglon.Item("Lote").ToString()
                                    parConfirmar.PAño = renglon.Item("Año").ToString()
                                    parConfirmar.PFechaEntradaAlmacen = renglon.Item("EntradaAlmacen").ToString()
                                    objBu.InsertarParConfirmado(parConfirmar, Integer.Parse(renglon.Item("idDetalleTalla").ToString()), colaboradorConfirmaId, Integer.Parse(lblIdApartadoSICY.Text), Integer.Parse(lblIdPedidoSICY.Text), IdCadena)
                                Next
                                objBu.ActualizaPartidasYApartadosDespuesDeConfirmacion(folioApartado, colaboradorConfirmaId)
                                CargarDatosParesConfirmadosAnteriormente(lblIdApartado.Text)
                                CargarDatosApartadoLeido("AP-" + lblIdApartado.Text)
                                CargarDatosPartidasApartado(lblIdApartado.Text, 1, 0, 0)
                                show_message("Exito", "Datos guardados correctamente.")
                            Catch ex As Exception
                                show_message("Advertencia", "Error al guardar los datos, intente de nuevo. " + ex.Message)
                            End Try
                        End If
                    End If
                Else
                    show_message("Advertencia", "El cliente se encuentra bloqueado por Cobranza (" + tipoBloqueoCliente + "), por lo que no puede confirmar este apartado.")
                End If
            Else
                show_message("Advertencia", "No hay pares cargados para confirmar")
            End If
        Else
            show_message("Advertencia", "No hay apartados cargados para confirmar")
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LimpiarSinConfirmacion()
        lblTextoCliente.Visible = False
        lblTextoApartadoSICY.Visible = False
        lblTextoFolioApartado.Visible = False
        lblTextoPedidoSAY.Visible = False
        lblTextoPedidoSICY.Visible = False
        lblTextoOrdenCliente.Visible = False
        lblTextoFSolicitada.Visible = False
        lblTextoFPreparacion.Visible = False
        lblEntregaInmediata.Visible = False
        lblEstatusApartado.Visible = False
        lblNombreCliente.Visible = False
        cliente = ""
        lblIdApartado.Visible = False
        folioApartado = ""
        lblIdApartadoSICY.Visible = False
        apartadoSICY = 0
        lblIdPedidoSAY.Visible = False
        pedidoSAY = 0
        lblIdPedidoSICY.Visible = False
        pedidoSICY = 0
        lblOrdenCliente.Visible = False
        ordenCliente = ""
        lblFSolicitada.Visible = False
        fechaSolicitada = ""
        lblFPreparacion.Visible = False
        fechaPreparacion = ""
        lblTextoTotalApartadosSeleccionados.Visible = False
        lblTotalApartadosSeleccionados.Visible = False
        totalApartadosSeleccionados = 0

        totalApartadosClientesBloqueados = 0
        statusApartado = ""
        entregaInmediata = 0

        grdPartidasConfirmadasyPorConfirmar.DataSource = Nothing
        grdParesConfirmadosAnteriormente.DataSource = Nothing
        grdParesConfirmandoActualmente.DataSource = Nothing
        lblTotalPares.Text = "0"
        lblTotalConfirmados.Text = "0"
        lblPorConfirmar.Text = "0"
        lblCancelados.Text = "0"

        btnImprimirDetalles.Enabled = False
        lblTextoImprimirDetalles.Enabled = False
        btnExportarConfirmados.Enabled = False
        lblTextoExportarConfirmados.Enabled = False
        btnExportarDetalles.Enabled = False
        lblTextoExportarDetalles.Enabled = False

        btnGuardar.Enabled = True
        lblGuardar.Enabled = True

        btnCancelarConfirmacion.Enabled = False
        lblTextoCancelarConfirmacionActual.Enabled = False

        btnTerminal.Enabled = True
        lblTerminal.Enabled = True

        arrApartadosEnArchivo = New ArrayList()

        totalApartadoEnArchivo = 0
        apartadoActual = 0
        vueltaLectura = 1

        rutaArchivoApartadosGlobal = ""

        btnAnteriorApartado.Enabled = False
        btnSiguienteApartado.Enabled = False
        lblTextoApartadoAnterior.Enabled = False
        lblTextoApartadoSiguiente.Enabled = False

        lblTextoCodigosInvalidos.Visible = False
        lblTotalCodigosInvalidos.Visible = False

        TotalParesExcedentes = 0

        ListaCodigosInvalidos.Clear()

    End Sub

    Private Sub btnCancelarConfirmacion_Click(sender As Object, e As EventArgs) Handles btnCancelarConfirmacion.Click
        Dim mensajeConfirmacion As String = String.Empty
        Dim confirmacion As New ConfirmarForm

        mensajeConfirmacion = "¿Está seguro que desea cancelar la confirmación actual?"
        confirmacion.mensaje = mensajeConfirmacion

        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            LimpiarSinConfirmacion()
        End If
    End Sub

    Private Sub btnSiguienteApartado_Click(sender As Object, e As EventArgs) Handles btnSiguienteApartado.Click
        Dim objBU As New Negocios.ApartadosBU
        Dim tablaInvalidos As New DataTable
        Dim advertencia As New AdvertenciaFormSinBoton
        Cursor = Cursors.WaitCursor
        ListaCodigosInvalidos.Clear()
        TotalParesExcedentes = 0
        apartadoActual += 1
        If apartadoActual <= totalApartadoEnArchivo Then
            'LeerLineasArchivoCargado(rutaArchivoApartadosGlobal, apartadoActual)
            LeerLineasArchivoCargadoParaBD("", 2, arrApartadosIdsEscaneadosArchivo(apartadoActual - 1))
            CargarDatosApartadoLeido("AP-" + arrApartadosIdsEscaneadosArchivo(apartadoActual - 1).ToString())
            CargarDatosParesConfirmadosAnteriormente(arrApartadosIdsEscaneadosArchivo(apartadoActual - 1))
            grdParesConfirmandoActualmente.DataSource = objBU.validarParesPorConfirmarArchivoCargado(CodigosEscaneadosArchivo, ApartadosIdsEscaneadosArchivo, TiposCodigosEscaneadosArchivo, 2)
            NumerarRenglones()
            actualizarDatosParesConfirmandoActualmente()
            tablaInvalidos = objBU.validarParesPorConfirmarArchivoCargado("", arrApartadosIdsEscaneadosArchivo(apartadoActual - 1).ToString(), "", 4)

            If tablaInvalidos.Rows.Count > 0 Then
                For Each renglon In tablaInvalidos.Rows
                    ListaCodigosInvalidos.Add(renglon.Item("CodigoInvalido"))
                Next
                lblTotalCodigosInvalidos.Text = tablaInvalidos.Rows.Count.ToString()
                lblTotalCodigosInvalidos.Visible = True
                lblTextoCodigosInvalidos.Visible = True
                lblTotalCodigosInvalidos_DoubleClick(sender, e)
            Else
                lblTotalCodigosInvalidos.Text = 0
                lblTotalCodigosInvalidos.Visible = False
                lblTextoCodigosInvalidos.Visible = False
            End If
            If apartadoActual + 1 > totalApartadoEnArchivo Then
                btnSiguienteApartado.Enabled = False
                lblTextoApartadoSiguiente.Enabled = False
            End If
            If apartadoActual - 1 >= 0 Then
                btnAnteriorApartado.Enabled = True
                lblTextoApartadoAnterior.Enabled = True
            End If
            If grdParesConfirmandoActualmente.Rows.Count > 0 Then
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
            End If
            If TotalParesExcedentes > 0 Then
                advertencia.mensaje = "Se detectó producto que no se puede confirmar en este apartado, limpia y vuelve a leer"
                advertencia.ShowDialog()
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
            Else
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAnteriorApartado_Click(sender As Object, e As EventArgs) Handles btnAnteriorApartado.Click
        Dim objBU As New Negocios.ApartadosBU
        Dim tablaInvalidos As New DataTable
        Dim advertencia As New AdvertenciaFormSinBoton
        Cursor = Cursors.WaitCursor
        ListaCodigosInvalidos.Clear()
        TotalParesExcedentes = 0
        apartadoActual -= 1
        If apartadoActual >= 0 Then
            'LeerLineasArchivoCargado(rutaArchivoApartadosGlobal, apartadoActual)
            LeerLineasArchivoCargadoParaBD("", 2, arrApartadosIdsEscaneadosArchivo(apartadoActual - 1))
            CargarDatosApartadoLeido("AP-" + arrApartadosIdsEscaneadosArchivo(apartadoActual - 1).ToString())
            CargarDatosParesConfirmadosAnteriormente(arrApartadosIdsEscaneadosArchivo(apartadoActual - 1))
            grdParesConfirmandoActualmente.DataSource = objBU.validarParesPorConfirmarArchivoCargado(CodigosEscaneadosArchivo, ApartadosIdsEscaneadosArchivo, TiposCodigosEscaneadosArchivo, 2)
            NumerarRenglones()
            actualizarDatosParesConfirmandoActualmente()
            tablaInvalidos = objBU.validarParesPorConfirmarArchivoCargado("", arrApartadosIdsEscaneadosArchivo(apartadoActual - 1).ToString(), "", 4)
            If tablaInvalidos.Rows.Count > 0 Then
                For Each renglon In tablaInvalidos.Rows
                    ListaCodigosInvalidos.Add(renglon.Item("CodigoInvalido"))
                Next
                lblTotalCodigosInvalidos.Text = tablaInvalidos.Rows.Count.ToString()
                lblTotalCodigosInvalidos.Visible = True
                lblTextoCodigosInvalidos.Visible = True
                lblTotalCodigosInvalidos_DoubleClick(sender, e)
            Else
                lblTotalCodigosInvalidos.Text = 0
                lblTotalCodigosInvalidos.Visible = False
                lblTextoCodigosInvalidos.Visible = False
            End If
            If apartadoActual - 1 = 0 Then
                btnAnteriorApartado.Enabled = False
                lblTextoApartadoAnterior.Enabled = False
            End If
            If apartadoActual + 1 <= totalApartadoEnArchivo Then
                btnSiguienteApartado.Enabled = True
                lblTextoApartadoSiguiente.Enabled = True
            End If
            If grdParesConfirmandoActualmente.Rows.Count > 0 Then
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            Else
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
            End If
            If TotalParesExcedentes > 0 Then
                advertencia.mensaje = "Se detectó producto que no se puede confirmar en este apartado, limpia y vuelve a leer"
                advertencia.ShowDialog()
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
            Else
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExistenciaDisponible_Click(sender As Object, e As EventArgs) Handles btnExistenciaDisponible.Click
        Dim partidasIncompletas As Integer = 0
        Dim partidasIncompletasSinExistencia As Integer = 0
        verDisponibilidad = 1
        Cursor = Cursors.WaitCursor
        CargarDatosPartidasApartado(folioApartado, totalApartadosSeleccionados, 0, 1)
        gridPartidasDiseño(grdPartidasConfirmadasyPorConfirmar)

        grdPartidasConfirmadasyPorConfirmar.DisplayLayout.Bands(0).Columns("ExistenciaTotal").Hidden = False

        For Each row As UltraGridRow In grdPartidasConfirmadasyPorConfirmar.Rows

            If row.Appearance.BackColor = pnlColorPartidaIncompleta.BackColor Then
                partidasIncompletas += 1
            End If

            If row.Cells("ExistenciaTotal").Value = "0" And row.Appearance.BackColor = pnlColorPartidaIncompleta.BackColor Then
                row.Appearance.ForeColor = Color.Red
                partidasIncompletasSinExistencia += 1
                TotalParesProgramarConfirmacionIncompleta += Integer.Parse(row.Cells("faltante").Value)
            End If
        Next

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("ALM_ADMON_APARTADOS", "ALM_ADMON_APARTADOS_ALMACEN") Then
            If partidasIncompletas = partidasIncompletasSinExistencia Then
                If lblEstatusApartado.Text <> "CONFIRMADO" And lblEstatusApartado.Text <> "CONFIRMACIÓN INCOMPLETA" And lblEstatusApartado.Text <> "EN EJECUCIÓN" And lblEstatusApartado.Text <> "CANCELADO" And lblEstatusApartado.Text <> "ACTIVO" Then
                    btnConfirmacionIncompleta.Enabled = True
                    lblTextoConfirmacionIncompleta.Enabled = True
                End If
            End If
        End If

        btnVerPares.Enabled = True
        lblTextoVerPares.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub btnVerPares_Click(sender As Object, e As EventArgs) Handles btnVerPares.Click
        Cursor = Cursors.WaitCursor
        Dim ventanaPares As New VerParesDisponibleApartadoForm
        ventanaPares.ApartadoId = folioApartado
        ventanaPares.MdiParent = Me.MdiParent
        ventanaPares.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnConfirmacionIncompleta_Click(sender As Object, e As EventArgs) Handles btnConfirmacionIncompleta.Click
        Dim ventanaConfIncompleta As New ConfirmacionIncompletaForm()
        ventanaConfIncompleta.MdiParent = Me.MdiParent
        ventanaConfIncompleta.NumApartado = Integer.Parse(folioApartado)
        ventanaConfIncompleta.ventanaAnterior = Me
        ventanaConfIncompleta.TotalParesProgramar = TotalParesProgramarConfirmacionIncompleta
        ventanaConfIncompleta.ventanaAdministrador = VentanaAdministrador
        Me.WindowState = 1
        ventanaConfIncompleta.Show()
    End Sub

    Public Sub terminaConfirmacionIncompleta()
        Me.WindowState = 2
    End Sub

    Private Sub lblTotalCodigosInvalidos_DoubleClick(sender As Object, e As EventArgs) Handles lblTotalCodigosInvalidos.DoubleClick
        If Integer.Parse(lblTotalCodigosInvalidos.Text) > 0 Then
            Dim ventanaCodigosInvalidos As New CodigosInvalidosForm
            ventanaCodigosInvalidos.StartPosition = FormStartPosition.CenterScreen
            ventanaCodigosInvalidos.ListaCodigosInvalidos = ListaCodigosInvalidos
            ventanaCodigosInvalidos.numApartado = Integer.Parse(lblIdApartado.Text)
            mostrarVentanaCodigosInvalidos(ventanaCodigosInvalidos)
        End If
    End Sub

    Private Sub mostrarVentanaCodigosInvalidos(CodigosInvalidos As CodigosInvalidosForm)
        CodigosInvalidos.ShowDialog()
        If CodigosInvalidos.DialogResult = Windows.Forms.DialogResult.OK Then
            mostrarVentanaCodigosInvalidos(CodigosInvalidos)
        End If
    End Sub


    Public Sub CargarEnBDArchivoLeerTerminal(sender As Object, e As EventArgs)
        Dim myStream As Stream = Nothing
        Dim openFileDialog As New OpenFileDialog
        Dim MensajeError As New ErroresForm
        Dim MensajeAviso As New AvisoForm
        Dim objBU As New Negocios.ApartadosBU
        Dim tablaInvalidos As New DataTable
        openFileDialog.InitialDirectory = "c:\"
        openFileDialog.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"
        openFileDialog.FilterIndex = 2
        openFileDialog.RestoreDirectory = True

        MensajeAviso.mensaje = "Este proceso puede tardar dependiendo de la cantidad de pares a validar"
        MensajeAviso.ShowDialog()
        If openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            'Try
            myStream = openFileDialog.OpenFile()
            If (openFileDialog.FileName IsNot Nothing) Then

                'LeerLineasArchivoCargado(openFileDialog.FileName, 1)
                LeerLineasArchivoCargadoParaBD(openFileDialog.FileName, 1, 0)
                rutaArchivoApartadosGlobal = openFileDialog.FileName
                apartadoActual = 1
                CargarDatosApartadoLeido("AP-" + arrApartadosIdsEscaneadosArchivo(apartadoActual - 1).ToString())
                'grdParesConfirmandoActualmente.DataSource = objBU.validarParesPorConfirmarArchivoCargado(CodigosEscaneadosArchivo, ApartadosIdsEscaneadosArchivo, TiposCodigosEscaneadosArchivo, 1)
                objBU.validarParesPorConfirmarArchivoCargado(CodigosEscaneadosArchivo, ApartadosIdsEscaneadosArchivo, TiposCodigosEscaneadosArchivo, 1)
                LeerLineasArchivoCargadoParaBD("", 2, arrApartadosIdsEscaneadosArchivo(apartadoActual - 1))
                grdParesConfirmandoActualmente.DataSource = objBU.validarParesPorConfirmarArchivoCargado(CodigosEscaneadosArchivo, ApartadosIdsEscaneadosArchivo, TiposCodigosEscaneadosArchivo, 2)
                NumerarRenglones()
                actualizarDatosParesConfirmandoActualmente()
                tablaInvalidos = objBU.validarParesPorConfirmarArchivoCargado("", arrApartadosIdsEscaneadosArchivo(apartadoActual - 1).ToString(), "", 4)
                ListaCodigosInvalidos.Clear()
                If tablaInvalidos.Rows.Count > 0 Then
                    For Each renglon In tablaInvalidos.Rows
                        ListaCodigosInvalidos.Add(renglon.Item("CodigoInvalido"))
                    Next
                    lblTotalCodigosInvalidos.Text = tablaInvalidos.Rows.Count.ToString()
                    lblTotalCodigosInvalidos.Visible = True
                    lblTextoCodigosInvalidos.Visible = True
                    lblTotalCodigosInvalidos_DoubleClick(sender, e)
                Else
                    lblTotalCodigosInvalidos.Text = "0"
                    lblTotalCodigosInvalidos.Visible = False
                    lblTextoCodigosInvalidos.Visible = False
                End If

                If totalApartadoEnArchivo = 1 Then
                    btnSiguienteApartado.Enabled = False
                    btnAnteriorApartado.Enabled = False
                    lblTextoApartadoSiguiente.Enabled = False
                    lblTextoApartadoAnterior.Enabled = False
                ElseIf totalApartadoEnArchivo > 1 Then
                    btnSiguienteApartado.Enabled = True
                    lblTextoApartadoSiguiente.Enabled = True
                End If

            End If
            'Catch Ex As Exception
            'MensajeError.mensaje = "No se puede leer el archivo. Error original: " & Ex.Message
            'MensajeError.ShowDialog()
            'Finally

            If (myStream IsNot Nothing) Then
                myStream.Close()
            End If
            'End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Public Sub LeerLineasArchivoCargadoParaBD(ByVal ruta As String, ByVal tipoConsulta As Integer, ByVal idApartado As Integer)

        Dim linea As String = ""
        Dim arrArchivo As New ArrayList()
        Dim cadenaLectura As String = ""
        LecturaTerminal = True
        Dim Noatado As Integer = 0
        Dim validacionAtado As Integer = 0
        Dim numApartado As String = String.Empty
        Dim numLinea As Integer = 0
        Dim numApartadoBuscarEnArchivo As Integer = 0

        If tipoConsulta = 1 Then 'Insersión y consulta de datos
            Dim reader As New StreamReader(ruta)
            lblTotalCodigosInvalidos.Text = "0"
            ListaCodigosInvalidos.Clear()
            arrApartadosIdsEscaneadosArchivo.Clear()
            CodigosEscaneadosArchivo = " "
            ApartadosIdsEscaneadosArchivo = " "
            TiposCodigosEscaneadosArchivo = " "
            Do
                linea = reader.ReadLine
                If Not linea Is Nothing And Split(linea, "-")(0).ToUpper() = "AP" Then
                    arrApartadosIdsEscaneadosArchivo.Add(LTrim(RTrim(Replace(Split(linea, "-")(1), "	", ""))))
                    numApartadoBuscarEnArchivo += 1
                Else
                    If arrApartadosIdsEscaneadosArchivo.Count > 0 Then
                        If Not linea Is Nothing Then
                            If LTrim(RTrim(linea)) <> "" Then
                                If Split(linea, "-").Length = 3 Then
                                    CodigosEscaneadosArchivo = CodigosEscaneadosArchivo + "," + LTrim(RTrim(Replace(Split(linea, "-")(2), "	", "")))
                                    ApartadosIdsEscaneadosArchivo = ApartadosIdsEscaneadosArchivo + "," + arrApartadosIdsEscaneadosArchivo(arrApartadosIdsEscaneadosArchivo.Count - 1)
                                    TiposCodigosEscaneadosArchivo = TiposCodigosEscaneadosArchivo + "," + "PAR"
                                ElseIf (LTrim(RTrim(linea))).Length = 11 Then
                                    CodigosEscaneadosArchivo = CodigosEscaneadosArchivo + "," + LTrim(RTrim(Replace(linea, "	", "")))
                                    ApartadosIdsEscaneadosArchivo = ApartadosIdsEscaneadosArchivo + "," + arrApartadosIdsEscaneadosArchivo(arrApartadosIdsEscaneadosArchivo.Count - 1)
                                    TiposCodigosEscaneadosArchivo = TiposCodigosEscaneadosArchivo + "," + "ATADO"
                                Else
                                    CodigosEscaneadosArchivo = CodigosEscaneadosArchivo + "," + LTrim(RTrim(Replace(linea, "	", "")))
                                    ApartadosIdsEscaneadosArchivo = ApartadosIdsEscaneadosArchivo + "," + arrApartadosIdsEscaneadosArchivo(arrApartadosIdsEscaneadosArchivo.Count - 1)
                                    TiposCodigosEscaneadosArchivo = TiposCodigosEscaneadosArchivo + "," + "NO RECONOCIDO"
                                End If
                            End If
                        End If
                    Else
                        show_message("Advertencia", "Es necesario leer el codigo del apartado a confirmar antes de los pares del mismo.")
                        Exit Do
                    End If
                End If

            Loop Until linea Is Nothing
            reader.Close()


            CodigosEscaneadosArchivo = LTrim(RTrim(Replace(CodigosEscaneadosArchivo, " ,", "")))
            ApartadosIdsEscaneadosArchivo = LTrim(RTrim(Replace(ApartadosIdsEscaneadosArchivo, " ,", "")))
            TiposCodigosEscaneadosArchivo = LTrim(RTrim(Replace(TiposCodigosEscaneadosArchivo, " ,", "")))

            totalApartadoEnArchivo = arrApartadosIdsEscaneadosArchivo.Count
            arrApartadosEnArchivo = arrApartadosIdsEscaneadosArchivo.Clone()

        ElseIf tipoConsulta = 2 Then ' Actualización y consulta
            CodigosEscaneadosArchivo = ""
            ApartadosIdsEscaneadosArchivo = idApartado.ToString()
            TiposCodigosEscaneadosArchivo = ""
        End If


    End Sub



    Public Sub actualizarDatosParesConfirmandoActualmente()
        Dim advertencia As New AdvertenciaFormSinBoton
        Dim detallePar As New Entidades.ParesConfirmarApartado

        For Each par As UltraGridRow In grdParesConfirmandoActualmente.Rows
            For Each row As UltraGridRow In grdPartidasConfirmadasyPorConfirmar.Rows
                If (row.Cells("partidaConfirmada").Value = 0 Or IsDBNull(row.Cells("partidaConfirmada").Value)) And row.Cells("Estatus").Value <> 46 And row.Cells("Faltante").Value > 0 Then
                    If row.Cells("IdProducto").Value.ToString.Trim = par.Cells("Producto").Value And row.Cells("Talla").Value.ToString.Trim = par.Cells("Talla").Value And par.Cells("Renglon").Value = "" Then
                        par.Cells("Renglon").Value = row.Cells("#").Value
                        par.Cells("idDetalleTalla").Value = row.Cells("ApartadoDetalleTalla").Value

                        actualizarFaltanteGridPares(Integer.Parse(row.Cells("Faltante").Value) - 1, par.Cells("idDetalleTalla").Value, Integer.Parse(row.Cells("Conf").Value) + 1, detallePar, False)
                    End If
                End If
            Next

            If IsDBNull(par.Cells("Renglon").Value) Or par.Cells("Renglon").Value = "" Or par.Cells("Renglon").Value = "0" Then
                par.Appearance.BackColor = pnlParExcedente.BackColor
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
                ReproducirSonidoError()
                advertencia.mensaje = "Se detectó producto que no se puede confirmar en este apartado, limpia y vuelve a leer"
                TotalParesExcedentes += 1
                'advertencia.ShowDialog()
                'Exit Sub
            End If
        Next
    End Sub


    Public Sub NumerarRenglones()
        Dim contador As Integer = 0
        For Each row As UltraGridRow In grdParesConfirmandoActualmente.Rows
            row.Cells("#").Value = (contador + 1).ToString()
            contador += 1
        Next

    End Sub

End Class