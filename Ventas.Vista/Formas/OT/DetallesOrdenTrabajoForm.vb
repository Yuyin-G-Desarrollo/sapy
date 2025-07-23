Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet

Public Class DetallesOrdenTrabajoForm

    Public OrdenTrabajoID As String = String.Empty
    Public OrdenTrabajoSICYID As String = String.Empty
    Public NumeroOrdenesTrabajo As Integer = 0
    Public EsConfirmacion As Boolean = False
    Public EsCancelacion As Boolean = False
    Public administrador As New AdministradorOT_Form
    Public CancelarOTDesasignacion As String = String.Empty
    Public TipoOT As String = String.Empty

    Dim objBU As New Ventas.Negocios.OrdenTrabajoBU
    Dim objEnt As New Entidades.OrdenTrabajo
    Dim CodigosInvalidos As Integer = 0
    Dim EsAndrea As Boolean = False
    Dim IndiceListaOT As Integer = 0
    Dim DTAtadosIncompletos As DataTable
    Dim ListaParesInvalidos As New List(Of DataTable)
    Dim ListaParesOT As New List(Of DataTable)
    Dim ListaOTs As New List(Of Integer)
    Dim EsYISTI As Boolean = False

    Dim dtResultadoCancelacionOTDesasignacionActualizarPedidos As New DataTable

    Private Sub DetallesOrdenTrabajoForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblTotalSeleccionados.Visible = False
        lblTextoTotalApartadosSeleccionados.Visible = False
        btnAnteriorOT.Enabled = False
        lblTextoOTAnterior.Enabled = False
        btnSiguienteOT.Enabled = False
        lblTextoOTSiguiente.Enabled = False

        DTAtadosIncompletos = CrearTablaAtadosIncompletos()

        If EsCancelacion = False Then
            btnCancelarPartidasOT.Visible = False
            lblCancelarPartidas.Visible = False
            chboxSeleccionarTodo.Visible = False
        Else
            sPCConfirmacionOrdenesTrabajo.SplitterDistance = sPCConfirmacionOrdenesTrabajo.Width
        End If


        If EsConfirmacion = True Then
            Me.Text = "Confirmación de OTs"
            lblTitulo.Text = "Confirmación de OTs"
            btnGenerarXML.Visible = False
            lblGenerarXML.Visible = False

            btnTerminal.Visible = True
            lblTerminal.Visible = True
            'btnCancelarConfirmacion.Visible = True
            'lblTextoCancelarConfirmacionActual.Visible = True

            btnCancelarConfirmacion.Visible = False
            lblTextoCancelarConfirmacionActual.Visible = False
        Else
            btnTerminal.Visible = False
            lblTerminal.Visible = False
            btnCancelarConfirmacion.Visible = False
            lblTextoCancelarConfirmacionActual.Visible = False

            Me.Text = "Consulta Detalles OT"
            lblTitulo.Text = "Consulta Detalles OT"
            btnCancelarConfirmacion.Enabled = False
            lblTextoCancelarConfirmacionActual.Enabled = False

            btnSiguienteOT.Visible = False
            lblTextoOTSiguiente.Visible = False
            btnAnteriorOT.Visible = False
            lblTextoOTAnterior.Visible = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            CargarPartidas()
            CargarPares(OrdenTrabajoID, 0)

            If NumeroOrdenesTrabajo > 1 Then
                lblTotalSeleccionados.Text = NumeroOrdenesTrabajo.ToString()
                lblTotalSeleccionados.Visible = True
                lblTextoTotalApartadosSeleccionados.Visible = True

                CargarTotalesVariasOTs()
                lblTextoCliente.Visible = False
                lblNombreCliente.Visible = False
                lblTextoPedidoSAY.Visible = False
                lblTextoPedidoSICY.Visible = False
                lblIdPedidoSAY.Visible = False
                lblIdPedidoSICY.Visible = False
                lblTextoOrdenCliente.Visible = False
                lblOrdenCliente.Visible = False
                lblTextoFSolicitada.Visible = False
                lblFSolicitada.Visible = False
                lblTextoFPreparacion.Visible = False
                lblFPreparacion.Visible = False
                lblOTSICY.Visible = False
                lblOTSAY.Visible = False
                lblTextoOTSAY.Visible = False
                lbltextoOTSICY.Visible = False
                btnGenerarXML.Visible = False
                lblGenerarXML.Visible = False

            End If

            If NumeroOrdenesTrabajo = 1 Then
                CargarInformacion()
                btnVerDetalle.Visible = objEnt.FacturacionAnticipada
                lblVerDistribucion.Visible = objEnt.FacturacionAnticipada
            Else
                btnVerDetalle.Visible = False
                lblVerDistribucion.Visible = False
            End If

            sPCParesConfirmar.SplitterDistance = 0
            sPCParesConfirmar.SplitterWidth = 1
            sPCParesConfirmar.IsSplitterFixed = True
            sPCParesConfirmar.Panel1.Hide()

        End If

    End Sub

    Private Sub CargarPartidasOTArchivo(ByVal OTSAYID As Integer)

        Dim DTInformacion As DataTable

        Try
            CargarInformacionOTArchivo(OTSAYID)
            DTInformacion = objBU.ConsultarPartidasOrdenTrabajo(OTSAYID)
            grdPartidas.DataSource = Nothing
            grdPartidas.DataSource = DTInformacion
            DiseñoGridPartidas(grdPartidas)

            CargarPares(OTSAYID, 0)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try

    End Sub


    Private Sub CargarTotalesVariasOTs()
        objEnt = objBU.ObtenerTotalesOT(OrdenTrabajoID)
        lblTotalPares.Text = objEnt.TotalPares.ToString()
        lblTotalConfirmados.Text = objEnt.TotalParesConfirmados.ToString()
        lblPorConfirmar.Text = objEnt.TotalParesPorConfirmar.ToString()
        lblCancelados.Text = objEnt.TotalParesCancelados.ToString()

    End Sub

    Private Sub CargarInformacionOTArchivo(ByVal OTSAYID As Integer)
        Dim FechaNula As Date = Nothing
        objEnt = objBU.ConsultarInformacionOT(OTSAYID)
        lblNombreCliente.Text = objEnt.Cliente
        lblOTSAY.Text = OTSAYID.ToString()
        lblOTSICY.Text = OrdenTrabajoSICYID.ToString()
        lblIdPedidoSAY.Text = objEnt.PedidoSAYID.ToString()
        lblIdPedidoSICY.Text = objEnt.PedidoSICYID.ToString()
        lblOrdenCliente.Text = objEnt.OrdenCliente.ToString()
        lblTotalPares.Text = objEnt.TotalPares.ToString()
        lblTotalConfirmados.Text = objEnt.TotalParesConfirmados.ToString()
        lblPorConfirmar.Text = objEnt.TotalParesPorConfirmar.ToString()
        lblCancelados.Text = objEnt.TotalParesCancelados.ToString()

        If objEnt.FechaCaptura <> FechaNula Then
            lblFSolicitada.Text = objEnt.FechaCaptura.ToShortDateString()
        Else
            lblFPreparacion.Text = "-"
        End If

        If objEnt.FechaPreparacion <> FechaNula Then
            lblFPreparacion.Text = objEnt.FechaPreparacion.ToShortDateString()
        Else
            lblFPreparacion.Text = "-"
        End If

        lblEstatusID.Text = objEnt.EstatusID.ToString()

        If objEnt.ClienteSAYID = 816 Then
            EsAndrea = True
            ValidarAtadosCompletos()
            lblAtadosIncompletos.Visible = True
            lblCantidadAtadosIncompletos.Visible = True
        Else
            EsAndrea = False
            lblAtadosIncompletos.Visible = False
            lblCantidadAtadosIncompletos.Visible = False
        End If

    End Sub

    Private Sub CargarInformacion()
        Dim FechaNula As Date = Nothing
        objEnt = objBU.ConsultarInformacionOT(OrdenTrabajoID)
        lblNombreCliente.Text = objEnt.Cliente
        lblOTSAY.Text = OrdenTrabajoID.ToString()
        lblOTSICY.Text = OrdenTrabajoSICYID.ToString()
        lblIdPedidoSAY.Text = objEnt.PedidoSAYID.ToString()
        lblIdPedidoSICY.Text = objEnt.PedidoSICYID.ToString()
        lblOrdenCliente.Text = objEnt.OrdenCliente.ToString()
        lblTotalPares.Text = objEnt.TotalPares.ToString()
        lblTotalConfirmados.Text = objEnt.TotalParesConfirmados.ToString()
        lblPorConfirmar.Text = objEnt.TotalParesPorConfirmar.ToString()
        lblCancelados.Text = objEnt.TotalParesCancelados.ToString()

        If objEnt.FacturacionAnticipada And NumeroOrdenesTrabajo = 1 Then
            btnVerDetalle.Visible = True
            lblVerDistribucion.Visible = True
        Else
            btnVerDetalle.Visible = False
            lblVerDistribucion.Visible = False
        End If

        If objEnt.FechaCaptura <> FechaNula Then
            lblFSolicitada.Text = objEnt.FechaCaptura.ToShortDateString()
        Else
            lblFPreparacion.Text = "-"
        End If

        If objEnt.FechaPreparacion <> FechaNula Then
            lblFPreparacion.Text = objEnt.FechaPreparacion
        Else
            lblFPreparacion.Text = "-"
        End If

        If objEnt.ClienteSAYID = 816 Then 'ANDREA
            'btnGenerarXML.Visible = True
            'lblGenerarXML.Visible = True
        Else
            btnGenerarXML.Visible = False
            lblGenerarXML.Visible = False
        End If

    End Sub

    Private Sub CargarPartidas()
        Dim DTInformacion As DataTable

        Try
            DTInformacion = objBU.ConsultarPartidasOrdenTrabajo(OrdenTrabajoID)
            grdPartidas.DataSource = Nothing
            grdPartidas.DataSource = DTInformacion
            DiseñoGridPartidas(grdPartidas)


            If EsCancelacion Then
                For Each row As UltraGridRow In grdPartidas.Rows
                    If row.Cells("StatusID").Value = 119 Or row.Cells("StatusID").Value = 130 Then
                        row.Cells("Seleccionar").Hidden = False
                    Else
                        'OT Coppel DistribucionTiendas
                        If CInt(row.Cells("ClienteSAYID").Value.ToString) <> 763 Then
                            row.Cells("Seleccionar").Hidden = True
                        End If
                        'row.Cells("Seleccionar").Hidden = True
                    End If
                Next
            End If

        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
    End Sub

    Private Sub CargarPares(ByVal OTID As String, ByVal Partida As Integer)
        Dim DTInformacion As DataTable

        Try
            DTInformacion = objBU.ConsultarParesPartidasOrdenTrabajo(OTID, Partida)
            grdParesConfirmados.DataSource = Nothing
            grdParesConfirmados.DataSource = DTInformacion
            DiseñoGridPares(grdParesConfirmados)
        Catch ex As Exception
            show_message("Error", ex.Message)
        End Try
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


    Private Sub DiseñoGridParesConfirmar(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Empty
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        AgregarColumna(grid, "OTID", "OTID", True, True, Nothing, 120, , False, HAlign.Left)
        AgregarColumna(grid, "Estiba", "Estiba", True, True, Nothing, 120, , False, HAlign.Left)
        AgregarColumna(grid, "CodigoAtado", "Atado", False, True, Nothing, 120, , False, HAlign.Right)

        If EsAndrea = True Then
            'AgregarColumna(grid, "CodidoPar", "CodidoPar", False, True, Nothing, 120, , False, HAlign.Left)
            AgregarColumna(grid, "CodigoPar", "Código Andrea", False, True, Nothing, 120, , False, HAlign.Right)
        Else
            AgregarColumna(grid, "CodigoPar", "Par", False, True, Nothing, 120, , False, HAlign.Right)
        End If

        AgregarColumna(grid, "Talla", "Talla", False, True, Nothing, 35, False, False, HAlign.Right)
        AgregarColumna(grid, "Articulo", "Articulo", False, True, Nothing, 100, False, False, HAlign.Left)
        AgregarColumna(grid, "ResultadoID", "ResultadoID", True, True, Nothing, 60, False, False, HAlign.Left)
        AgregarColumna(grid, "Valido", "Resultado", True, True, Nothing, 60, False, False, HAlign.Left)
        AgregarColumna(grid, "Operador", "Operador", True, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "FechaConfirmacion", "FConfirmación", False, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "StatusPartida", "StatusPartida", True, True, Nothing, 60, , False, HAlign.Left)
        AgregarColumna(grid, "TipoCodigo", "TipoCodigo", True, True, Nothing, 60, , False, HAlign.Right)
        AgregarColumna(grid, "ClienteID", "ClienteID", True, True, Nothing, 60, , False, HAlign.Right)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub DiseñoGridPares(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Empty
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grid.DisplayLayout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
        grid.DisplayLayout.GroupByBox.Hidden = False
        grid.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna para agrupar por ese concepto"


        'AgregarColumna(grid, "OrdenTrabajoDetalleID", "OrdenTrabajoDetalleID", True, True, Nothing, 240, , False, HAlign.Left)
        If NumeroOrdenesTrabajo = 1 Then
            OcultarColumna(grid, "OrdenTrabajoSAYID")
        Else
            'AgregarColumna(grid, "OrdenTrabajoSAYID", "OT " & vbCrLf & "SAY", True, True, Nothing, 25, , False, HAlign.Right)
        End If

        OcultarColumna(grid, "OrdenTrabajoDetalleID")
        OcultarColumna(grid, "StatusID")
        OcultarColumna(grid, "Status")
        OcultarColumna(grid, "EstatusPartidaID")

        'AgregarColumna(grid, "Partida", "Partida", False, True, Nothing, 25, , False, HAlign.Left)
        'AgregarColumna(grid, "CodigoAtado", "Atado", False, True, Nothing, 90, , False, HAlign.Right)
        'AgregarColumna(grid, "CodigoPar", "Par", False, True, Nothing, 90, False, False, HAlign.Right)
        'AgregarColumna(grid, "Articulo", "Artículo", False, True, Nothing, 120, False, False, HAlign.Left)
        'AgregarColumna(grid, "Calce", "Talla", False, True, Nothing, 40, , False, HAlign.Right)
        'AgregarColumna(grid, "Marca", "Marca", False, True, Nothing, 40, , False, HAlign.Right)
        'AgregarColumna(grid, "MarcaYuyin", "MarcaYuyin", False, True, Nothing, 40, , False, HAlign.Right)
        'AgregarColumna(grid, "Lote", "Lote", False, True, Nothing, 40, , False, HAlign.Right)
        'AgregarColumna(grid, "Nave", "Nave", False, True, Nothing, 60, , False, HAlign.Left)
        'AgregarColumna(grid, "Año", "Año", False, True, Nothing, 40, , False, HAlign.Right)
        'AgregarColumna(grid, "StatusID", "StatusID", True, True, Nothing, 60, , False, HAlign.Right)
        'AgregarColumna(grid, "Status", "Status", True, True, Nothing, 60, , False, HAlign.Left)
        'AgregarColumna(grid, "FechaConfirmo", "FConfirmación", False, True, Nothing, 140, True, False, HAlign.Left, , , , , True)
        'AgregarColumna(grid, "OperadorConfirmo", "Confirmo", False, True, Nothing, 70, True, False, HAlign.Left)
        'AgregarColumna(grid, "EstatusPartidaID", "EstatusPartidaID", True, True, Nothing, 70, True, False, HAlign.Left)

        grid.DisplayLayout.Bands(0).Columns("CodigoAtado").Header.Caption = "Atado"
        grid.DisplayLayout.Bands(0).Columns("CodigoPar").Header.Caption = "Par"
        grid.DisplayLayout.Bands(0).Columns("Calce").Header.Caption = "Talla"
        grid.DisplayLayout.Bands(0).Columns("FechaConfirmo").Header.Caption = "FConfirmación"
        grid.DisplayLayout.Bands(0).Columns("OperadorConfirmo").Header.Caption = "Confirmó"
        grid.DisplayLayout.Bands(0).Columns("MarcaYuyin").Header.Caption = "Marca" & vbCrLf & "Yuyin"
        grid.DisplayLayout.Bands(0).Columns("OrdenTrabajoSAYID").Header.Caption = "OT" & vbCrLf & "SAY"

        SumarColumnas(grid, "CodigoAtado",4)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        grid.DisplayLayout.PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
        asignaFormato_Columna(grid)
    End Sub

    Public Sub OcultarColumna(grid As UltraGrid, columna As String)
        If grid.DisplayLayout.Bands(0).Columns.Exists(columna) Then
            grid.DisplayLayout.Bands(0).Columns(columna).Hidden = True
        End If
    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        ' Se recorre cada columna del Grid
        For Each col In grid.DisplayLayout.Bands(0).Columns
            ' Se valida si la columna es de tipo entero
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            ' Se valida si la columna es de tipo Decimal
            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            ' Se valida si la columna es de tipo String
            If col.DataType.Name.ToString.Equals("String") Then
                ' Si el encabezado de la columna es 'TELÉFONO'
                If col.Header.Caption.Equals("TELÉFONO") Then
                    ' Se genera una máscara de entrada
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                    ' Si el encbezado de la columna es 'EXTENSIÓN'
                ElseIf col.Header.Caption.Equals("EXTENSIÓN") Then
                    ' Se genera una máscara de entrada
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
    End Sub

    Public Sub SumarColumnas(grid As UltraGrid, columna As String, tipoSuma As Int16)
        With grid.DisplayLayout.Bands(0)
            ' Validamos que la columna exista
            If .Columns.Exists(columna) Then
                ' Si en el Grid ya se configuró una suma, termina el método para no duplicar renglones
                If .Summaries.Exists(tipoSuma) = True Then Return
                ' Perimitimos operaciones sobre la columna
                .Columns(columna).AllowRowSummaries = AllowRowSummaries.True
                ' Se genera una nueva configuración para la operación
                Dim configuracionDeSuma As SummarySettings = .Summaries.Add(tipoSuma, grid.DisplayLayout.Bands(0).Columns(columna))
                ' Se define el formato con el que se mostrará el resultado de la operación
                configuracionDeSuma.DisplayFormat = "{0}"
                ' Se define la alineación del texto
                configuracionDeSuma.Appearance.TextHAlign = HAlign.Right
                ' Texto que aparecerá al final del Grid
                .SummaryFooterCaption = "Total:"
            End If
        End With
    End Sub

    Private Sub DiseñoGridPartidas(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim Ocultar As Boolean = False
        Dim OcultarSeleccion As Boolean = True
        'grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        'grid.DisplayLayout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)

        'grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.Empty
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        'grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect

        'AgregarColumna(grid, "OrdenTrabajoDetalleID", "OrdenTrabajoDetalleID", True, True, Nothing, 240, , False, HAlign.Left)

        If NumeroOrdenesTrabajo > 1 Then
            Ocultar = False
        Else
            Ocultar = True
        End If

        If EsCancelacion Then
            OcultarSeleccion = False
        End If

        OcultarColumna(grid, "StatusID")
        OcultarColumna(grid, "OrdenTrabajoSICYID")
        OcultarColumna(grid, "FechaCaptura")
        OcultarColumna(grid, "FechaPreparacion")
        OcultarColumna(grid, "Cliente")
        OcultarColumna(grid, "Status")
        OcultarColumna(grid, "ParesCancelados")
        OcultarColumna(grid, "ParesIncidencias")
        OcultarColumna(grid, "UsuarioCancelo")
        OcultarColumna(grid, "FechaCancelo")
        OcultarColumna(grid, "ClienteSAYID")
        OcultarColumna(grid, "OrdenTrabajoDetalleID")

        If Ocultar = True Then
            'OcultarColumna(grid, "OrdenTrabajoSAYID")
            'OcultarColumna(grid, "PedidoSAYID")
            'OcultarColumna(grid, "PedidoSICYID")
        End If

        If OcultarSeleccion = True Then
            OcultarColumna(grid, "Selecciona")
            OcultarColumna(grid, "Seleccionar")
        End If

        grid.DisplayLayout.Bands(0).Columns("OrdenTrabajoSAYID").Header.Caption = "OT" & vbCrLf & "SAY"
        grid.DisplayLayout.Bands(0).Columns("OrdenTrabajoSICYID").Header.Caption = "OT " & vbCrLf & " SICY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSAYID").Header.Caption = "Pedido " & vbCrLf & " SAY"
        grid.DisplayLayout.Bands(0).Columns("PedidoSICYID").Header.Caption = "Pedido " & vbCrLf & "SICY"
        grid.DisplayLayout.Bands(0).Columns("FechaCaptura").Header.Caption = "FCaptura"
        grid.DisplayLayout.Bands(0).Columns("FechaPreparacion").Header.Caption = "FPreparacion"
        grid.DisplayLayout.Bands(0).Columns("OrdenCliente").Header.Caption = "Orden " & vbCrLf & " Cliente"
        grid.DisplayLayout.Bands(0).Columns("TotalPares").Header.Caption = "Total"
        grid.DisplayLayout.Bands(0).Columns("ParesConfirmados").Header.Caption = "Confirmados"
        grid.DisplayLayout.Bands(0).Columns("ParesPorConfirmar").Header.Caption = "Por" & vbCrLf & " Confirmar"
        grid.DisplayLayout.Bands(0).Columns("ParesCancelados").Header.Caption = "Cancelados"
        grid.DisplayLayout.Bands(0).Columns("ParesIncidencias").Header.Caption = "Incidencias"
        grid.DisplayLayout.Bands(0).Columns("UsuarioCancelo").Header.Caption = "Canceló"
        grid.DisplayLayout.Bands(0).Columns("FechaCancelo").Header.Caption = "FCanceló"
        grid.DisplayLayout.Bands(0).Columns("MarcaYuyin").Header.Caption = "Marca" & vbCrLf & " Yuyin"

        SumarColumnas(grid, "TotalPares", 1)
        SumarColumnas(grid, "ParesConfirmados", 1)
        SumarColumnas(grid, "ParesPorConfirmar", 1)
        'AgregarColumna(grid, "Seleccionar", "", OcultarSeleccion, False, Nothing, 25, , True, HAlign.Default)
        'AgregarColumna(grid, "OrdenTrabajoSAYID", "OT " & vbCrLf & " SAY", Ocultar, True, Nothing, 60, , False, HAlign.Right)
        'AgregarColumna(grid, "OrdenTrabajoSICYID", "OT " & vbCrLf & " SICY", True, True, Nothing, 60, , False, HAlign.Right)
        'AgregarColumna(grid, "PedidoSAYID", "Pedido " & vbCrLf & " SAY", Ocultar, True, Nothing, 50, , False, HAlign.Right)
        'AgregarColumna(grid, "PedidoSICYID", "Pedido " & vbCrLf & "SICY", Ocultar, True, Nothing, 50, , False, HAlign.Right)
        'AgregarColumna(grid, "Partida", "Partida", False, False, Nothing, 40, False, False, HAlign.Right)
        'AgregarColumna(grid, "FechaCaptura", "FCaptura ", True, True, Nothing, 100, , False, HAlign.Left)
        'AgregarColumna(grid, "FechaPreparacion", "FPreparación", True, True, Nothing, 90, , False, HAlign.Left)
        'AgregarColumna(grid, "Cliente", "Cliente", True, True, Nothing, 150, , False, HAlign.Left)

        'AgregarColumna(grid, "Tienda", "Tienda", False, False, Nothing, 120, False, False, HAlign.Left)
        'AgregarColumna(grid, "Articulo", "Articulo", False, False, Nothing, 140, False, False, HAlign.Left)
        'AgregarColumna(grid, "Marca", "Marca", False, False, Nothing, 140, False, False, HAlign.Left)
        'AgregarColumna(grid, "MarcaYuyin", "MarcaYuyin", False, False, Nothing, 140, False, False, HAlign.Left)
        'AgregarColumna(grid, "Observación", "Observación", False, False, Nothing, 140, False, False, HAlign.Left)
        'AgregarColumna(grid, "OrdenCliente", "Orden " & vbCrLf & " Cliente", False, True, Nothing, 100, , False, HAlign.Left)
        'AgregarColumna(grid, "StatusID", "StatusID", True, True, Nothing, 60, , False, HAlign.Right)
        'AgregarColumna(grid, "Status", "Status", True, True, Nothing, 60, , False, HAlign.Left)
        'AgregarColumna(grid, "TotalPares", "Total", False, False, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "ParesConfirmados", "Confirmados", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "ParesPorConfirmar", "Por" & vbCrLf & " Confirmar", False, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "ParesCancelados", "Cancelados", True, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "ParesIncidencias", "Incidencias", True, True, Nothing, 70, True, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "UsuarioCancelo", "Canceló", True, True, Nothing, 70, False, False, HAlign.Left)
        'AgregarColumna(grid, "FechaCancelo", "FCanceló", True, True, Nothing, 70, False, False, HAlign.Left)
        'AgregarColumna(grid, "ClienteSAYID", "ClienteSAYID", True, True, Nothing, 70, False, False, HAlign.Left)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        'If Ocultar = True Then
        '    grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'End If
        grid.DisplayLayout.PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
        asignaFormato_Columna(grid)
    End Sub



    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum, Optional ByVal EsFecha As Boolean = False)
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje, EsFecha)
            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If
            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key, Operacion)
            End If
            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            'If Alineacion <> HAlign.Default Then
            '    .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            'End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If
            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If


            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal EsFechas As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        Dim FormatoFecha As String = "dd/MM/yyyy HH:mm:ss"


        columna.Hidden = Ocultar
        If EsCadena = True Then
            If EsFechas = True Then
                columna.Format = FormatoFecha

            End If
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub

    Private Sub grdPartidas_Click(sender As Object, e As EventArgs) Handles grdPartidas.Click


        'For Each row As UltraGridRow In grdPartidas.Rows.Where(Function(x) x.Cells("Seleccionar").Selected = True)
        '    row.Cells("Seleccionar").Value = False
        'Next

        'For Each row As UltraGridRow In grdPartidas.Rows.Where(Function(x) x.Cells("Seleccionar").Selected = False)
        '    row.Cells("Seleccionar").Value = True
        'Next

        'Dim FilaSeleccionada = grdPartidas.Rows.FirstOrDefault(Function(x) x.Selected = True)

        'If IsNothing(FilaSeleccionada) = False Then
        '    '            CargarPares(FilaSeleccionada.Cells("OrdenTrabajoSAYID").Value, FilaSeleccionada.Cells("Partida").Value)
        '    btnCancelarConfirmacion.Enabled = True
        '    lblTextoCancelarConfirmacionActual.Enabled = True
        '    btnTerminal.Enabled = True
        '    lblTerminal.Enabled = True

        'End If

    End Sub


    Private Function CrearTablaParesAConfirmar() As DataTable
        Dim DTInformacion As New DataTable

        DTInformacion.Columns.Add("OTID", GetType(Integer))
        DTInformacion.Columns.Add("Estiba", GetType(String))
        DTInformacion.Columns.Add("CodigoAtado", GetType(String))
        DTInformacion.Columns.Add("CodigoPar", GetType(String))
        DTInformacion.Columns.Add("Talla", GetType(String))
        DTInformacion.Columns.Add("Articulo", GetType(String))
        DTInformacion.Columns.Add("ResultadoID", GetType(Integer))
        DTInformacion.Columns.Add("Valido", GetType(String))
        DTInformacion.Columns.Add("Operador", GetType(String))
        DTInformacion.Columns.Add("FechaConfirmacion", GetType(Date))
        DTInformacion.Columns.Add("StatusPartida", GetType(String))
        DTInformacion.Columns.Add("TipoCodigo", GetType(String))
        DTInformacion.Columns.Add("ClienteID", GetType(String))
        Return DTInformacion
    End Function

    Private Function CrearTablaParesInvalidos() As DataTable
        Dim DTInformacion As New DataTable

        DTInformacion.Columns.Add("OTID", GetType(Integer))
        DTInformacion.Columns.Add("Estiba", GetType(String))
        DTInformacion.Columns.Add("CodigoAtado", GetType(String))
        DTInformacion.Columns.Add("CodigoPar", GetType(String))
        DTInformacion.Columns.Add("Talla", GetType(String))
        DTInformacion.Columns.Add("Articulo", GetType(String))
        DTInformacion.Columns.Add("ResultadoID", GetType(Integer))
        DTInformacion.Columns.Add("Valido", GetType(String))
        DTInformacion.Columns.Add("Operador", GetType(String))
        DTInformacion.Columns.Add("FechaConfirmacion", GetType(Date))
        DTInformacion.Columns.Add("StatusPartida", GetType(String))
        Return DTInformacion
    End Function


    Private Function CrearTablaAtadosIncompletos() As DataTable
        Dim DTInformacion As New DataTable

        DTInformacion.Columns.Add("OTID", GetType(Integer))
        DTInformacion.Columns.Add("CodigoAtado", GetType(String))
        DTInformacion.Columns.Add("Valido", GetType(String))

        Return DTInformacion
    End Function

    Private Sub LimpiarDatos()
        CodigosInvalidos = 0

        ListaParesOT.Clear()
        ListaParesInvalidos.Clear()
        ListaOTs.Clear()
        DTAtadosIncompletos.Clear()

        lblTextoCodigosInvalidos.Visible = True
        lblTotalCodigosInvalidos.Visible = True
        lblNotaCodigoInvalido.Visible = True
        IndiceListaOT = 0
        lblTotalCodigosInvalidos.Text = "0"
        lblTotalPares.Text = "0"
        lblTotalConfirmados.Text = "0"
        lblPorConfirmar.Text = "0"
        lblCancelados.Text = "0"
        lblNombreCliente.Text = "-"
        lblOTSAY.Text = "-"
        lblOTSICY.Text = "-"
        lblIdPedidoSAY.Text = "-"
        lblIdPedidoSICY.Text = "-"
        lblOrdenCliente.Text = "-"
        lblEstatusID.Text = "0"
        lblFSolicitada.Text = "-"
        lblFPreparacion.Text = "-"

        grdParesAConfirmar.DataSource = Nothing
        grdPartidas.DataSource = Nothing
        grdParesConfirmados.DataSource = Nothing

        btnSiguienteOT.Enabled = False
        lblTextoOTSiguiente.Enabled = False
        btnAnteriorOT.Enabled = False
        lblTextoOTAnterior.Enabled = False
        btnGuardar.Enabled = False
        lblGuardar.Enabled = False


    End Sub

    Private Sub btnTerminal_Click(sender As Object, e As EventArgs) Handles btnTerminal.Click
        Dim BuscarArchivo As New OpenFileDialog
        Dim fileReader As System.IO.StreamReader
        Dim stringReader As String = String.Empty
        Dim Atado As String = String.Empty
        Dim CodigoPar As String = String.Empty
        Dim DTInformacion As New DataTable
        Dim DTResultado As New DataTable
        Dim Resultado As String = String.Empty
        Dim Codigo As String()
        Dim OTID As Integer = 0
        Dim Estiba As String = String.Empty
        Dim ExisteOT As Boolean = False
        Dim ContadorPares As Integer = 0
        Dim CodigoAndrea As String = String.Empty
        Dim dtinformacionAndrea As DataTable
        Dim dtParesInvalidos As New DataTable
        Dim confirmar As New Tools.ConfirmarForm
        Dim ResultadoCancelacion As Boolean = False
        Dim DTInformacionCliente As DataTable
        Dim ClienteID As Integer = 0
        Dim DTCodigosAndreaPorAtado As DataTable
        Dim DtInformacionCodigoAndrea As DataTable
        Dim TamañoCadena As Integer = 0
        Dim AtadoConCeros As String = String.Empty

        BuscarArchivo.Filter = "txt files (*.txt)|*.txt|dat files (*.dat)|*.dat"

        If ListaOTs.Count > 0 Then
            ResultadoCancelacion = CancelarConfirmacion("Ya hay datos cargados ¿desea cancelar la confirmación?.")
        Else
            ResultadoCancelacion = True
        End If

        If ResultadoCancelacion = False Then
            Return
        End If

        LimpiarDatos()

        Try

            If BuscarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                fileReader = My.Computer.FileSystem.OpenTextFileReader(BuscarArchivo.FileName)

                Try
                    While (fileReader.EndOfStream) = False
                        stringReader = fileReader.ReadLine()
                        Codigo = stringReader.Split(New Char() {"-"c})

                        If ExisteOT = False Then
                            'OT a confirmar
                            If Codigo.Length = 2 Then
                                OTID = CInt(Codigo(1))
                                Atado = String.Empty
                                CodigoAndrea = String.Empty
                                Estiba = String.Empty
                                ListaOTs.Add(OTID)
                                DTInformacion = CrearTablaParesAConfirmar()
                                dtParesInvalidos = CrearTablaParesInvalidos()

                                DTInformacionCliente = objBU.ObtenerClienteOT(OTID)
                                ExisteOT = True
                                If DTInformacionCliente.Rows.Count > 0 Then
                                    ClienteID = DTInformacionCliente.Rows(0).Item(0).ToString()
                                    If DTInformacionCliente.Rows(0).Item(0).ToString() = "816" Then
                                        EsAndrea = True
                                        DTAtadosIncompletos.Rows.Clear()
                                        DTCodigosAndreaPorAtado = objBU.ObtenerCodigosAndreaPorAtado(OTID, Atado)

                                    ElseIf DTInformacionCliente.Rows(0).Item(0).ToString() = "1132" Then
                                        EsYISTI = True
                                        DTAtadosIncompletos.Rows.Clear()
                                    Else
                                        EsAndrea = False
                                        DTAtadosIncompletos.Rows.Clear()
                                    End If
                                Else
                                    ClienteID = 0
                                End If
                            End If
                        Else

                            If Codigo.Length = 2 Then
                                OTID = CInt(Codigo(1))
                                Atado = String.Empty
                                Estiba = String.Empty
                                ListaOTs.Add(OTID)
                                ListaParesOT.Add(DTInformacion)
                                ListaParesInvalidos.Add(dtParesInvalidos)
                                DTInformacion = CrearTablaParesAConfirmar()
                                dtParesInvalidos = CrearTablaParesInvalidos()
                                DTInformacionCliente = objBU.ObtenerClienteOT(OTID)
                                If DTInformacionCliente.Rows.Count > 0 Then
                                    ClienteID = DTInformacionCliente.Rows(0).Item(0).ToString()
                                    If DTInformacionCliente.Rows(0).Item(0).ToString() = "816" Then
                                        EsAndrea = True
                                        DTCodigosAndreaPorAtado = objBU.ObtenerCodigosAndreaPorAtado(OTID, Atado)
                                    ElseIf DTInformacionCliente.Rows(0).Item(0).ToString() = "1132" Then
                                        EsYISTI = True
                                        DTAtadosIncompletos.Rows.Clear()
                                    Else
                                        EsAndrea = False
                                    End If
                                Else
                                    ClienteID = 0
                                End If

                                '    ElseIf Codigo.Length = 4 Then
                                '        Estiba = stringReader.Replace("ES-", "")

                            ElseIf Codigo.Length = 4 Then
                                Estiba = stringReader.Replace("ES-", "")
                            ElseIf stringReader.Trim.Length = 11 Or Codigo.Length = 1 Then

                                If Codigo(0).Length < 11 Then
                                    TamañoCadena = 11 - Codigo(0).Length

                                    For j As Integer = 1 To TamañoCadena
                                        AtadoConCeros += "0"
                                    Next j

                                    Codigo(0) = AtadoConCeros & Codigo(0)
                                End If

                                Atado = Codigo(0)

                                If DTInformacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString = Codigo(0)).Count = 0 Then
                                    DTResultado = objBU.ValidacionPares(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 2, Atado, Estiba)

                                    Resultado = ObtenerMensajeValidacionPar(2, DTResultado.Rows(0).Item("TipoResultado").ToString())

                                    If DTResultado.Rows(0).Item("TipoResultado").ToString() = "1" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "2" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "3" Then
                                        DTInformacion.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), "", DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), DTResultado.Rows(0).Item("StatusPartida").ToString(), 2, ClienteID.ToString)
                                    Else
                                        dtParesInvalidos.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), "", DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, DTResultado.Rows(0).Item("StatusPartida").ToString())
                                    End If
                                Else
                                    dtParesInvalidos.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), "", DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, "-1", "Repetido", Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, "")
                                End If

                            ElseIf stringReader.Trim().Length > 25 And stringReader.Trim().Length < 30 Or Codigo.Length = 3 Then

                                DTResultado = objBU.ValidacionPares(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 1, Codigo(2).ToString().Trim(), Estiba)

                                Resultado = ObtenerMensajeValidacionPar(1, DTResultado.Rows(0).Item("TipoResultado").ToString())

                                If DTResultado.Rows(0).Item("TipoResultado").ToString() = "1" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "2" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "3" Then
                                    DTInformacion.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), Codigo(2).ToString.Trim(), DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), DTResultado.Rows(0).Item("StatusPartida").ToString(), 1, ClienteID.ToString())
                                Else
                                    dtParesInvalidos.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), Codigo(2).ToString.Trim(), DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, DTResultado.Rows(0).Item("StatusPartida").ToString())
                                End If

                            Else
                                CodigosInvalidos += 1
                            End If

                        End If

                        '    ElseIf Codigo.Length = 4 Then
                        '        Estiba = stringReader.Replace("ES-", "")


                        'If EsAndrea = True Then

                        '    If stringReader.Trim.Length = 11 And Codigo.Length = 1 Then
                        '        Atado = Codigo(0)
                        '        '                                    DTCodigosAndreaPorAtado = objBU.ObtenerCodigosAndreaPorAtado(OTID, Atado)
                        '    ElseIf Codigo.Length = 1 Then

                        '        Try
                        '            CodigoAndrea = Codigo(0)


                        '            If DTCodigosAndreaPorAtado.AsEnumerable().Where(Function(X) X.Item("CodigoAndrea") = CodigoAndrea And X.Item("ID_Docena") = Atado).Count > 0 Then
                        '                Dim CantidadCodigosAndrea As Integer = DTCodigosAndreaPorAtado.AsEnumerable().Where(Function(X) X.Item("CodigoAndrea") = CodigoAndrea And X.Item("ID_Docena") = Atado).Sum(Function(row) row.Field(Of Integer)("CantidadCodigos"))
                        '                Dim CantidadParesLeidos As Integer = DTInformacion.AsEnumerable().Where(Function(x) x.Item("CodigoPar").ToString = CodigoAndrea And x.Item("CodigoAtado") = Atado).Count()

                        '                If CantidadCodigosAndrea > CantidadParesLeidos Then
                        '                    dtinformacionAndrea = objBU.ValidacionParesANDREA(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Atado, CodigoAndrea, Estiba)

                        '                    If CBool(dtinformacionAndrea.Rows(0).Item("AtadoConfirmado")) = False Then
                        '                        If dtinformacionAndrea.Rows(0).Item("Resultado").ToString = "1" Then
                        '                            Resultado = "Par Correcto"
                        '                        ElseIf dtinformacionAndrea.Rows(0).Item("Resultado").ToString = "2" Then
                        '                            Resultado = "Incidencia de ubicación"
                        '                        ElseIf dtinformacionAndrea.Rows(0).Item("Resultado").ToString = "3" Then
                        '                            Resultado = "EL codigo no pertenece a la OT"
                        '                        ElseIf dtinformacionAndrea.Rows(0).Item("Resultado").ToString = "6" Then
                        '                            Resultado = "El codigo no pertenece al atado"
                        '                        End If

                        '                        If dtinformacionAndrea.Rows(0).Item("Resultado").ToString = "1" Or dtinformacionAndrea.Rows(0).Item("Resultado").ToString = "2" Then
                        '                            DTInformacion.Rows.Add(OTID, Estiba, Atado, CodigoAndrea, dtinformacionAndrea.Rows(0).Item("Talla").ToString, dtinformacionAndrea.Rows(0).Item("Articulo").ToString, dtinformacionAndrea.Rows(0).Item("Resultado").ToString, Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), "0", 2, ClienteID.ToString)
                        '                        Else
                        '                            DTInformacion.Rows.Add(OTID, Estiba, Atado, CodigoAndrea, dtinformacionAndrea.Rows(0).Item("Talla").ToString, dtinformacionAndrea.Rows(0).Item("Articulo").ToString, dtinformacionAndrea.Rows(0).Item("Resultado").ToString, Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), "0", 2, ClienteID.ToString)
                        '                            'dtParesInvalidos.Rows.Add(OTID, Estiba, Atado.ToString.Trim(), Codigo(0).ToString.Trim(), DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, DTResultado.Rows(0).Item("StatusPartida").ToString())
                        '                        End If
                        '                    Else
                        '                        dtParesInvalidos.Rows.Add(OTID, Estiba, Atado.ToString.Trim(), Codigo(0).ToString.Trim(), dtinformacionAndrea.Rows(0).Item("Talla").ToString, dtinformacionAndrea.Rows(0).Item("Articulo").ToString, "0", "Atado ya confirmado", Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, "")

                        '                    End If

                        '                Else
                        '                    dtParesInvalidos.Rows.Add(OTID, Estiba, Atado.ToString.Trim(), Codigo(0).ToString.Trim(), "", "", "0", "Repetido", Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, "")
                        '                End If

                        '            Else

                        '                DtInformacionCodigoAndrea = objBU.InformacionCodigoAndrea(CodigoAndrea)
                        '                If DtInformacionCodigoAndrea.Rows.Count > 0 Then
                        '                    DTInformacion.Rows.Add(OTID, Estiba, Atado, CodigoAndrea, DtInformacionCodigoAndrea.Rows(0).Item("Talla").ToString, DtInformacionCodigoAndrea.Rows(0).Item("Articulo").ToString, "6", "El código de ANDREA no pertenece al atado", Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), "0", 2, ClienteID.ToString)
                        '                Else
                        '                    DTInformacion.Rows.Add(OTID, Estiba, Atado, CodigoAndrea, "", "", "6", "El código de ANDREA no pertenece al atado", Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), "0", 2, ClienteID.ToString)
                        '                End If


                        '                ' dtParesInvalidos.Rows.Add(OTID, Estiba, Atado.ToString.Trim(), Codigo(0).ToString.Trim(), "", "", "0", Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, "")
                        '            End If
                        '        Catch ex As Exception
                        '            show_message("Error", ex.Message.ToString())
                        '        End Try



                        '    ElseIf Codigo.Length = 2 Then
                        '        OTID = CInt(Codigo(1))
                        '        Atado = String.Empty
                        '        CodigoAndrea = String.Empty
                        '        Estiba = String.Empty
                        '        ListaOTs.Add(OTID)
                        '        ListaParesOT.Add(DTInformacion)
                        '        ListaParesInvalidos.Add(dtParesInvalidos)
                        '        DTInformacion = CrearTablaParesAConfirmar()
                        '        dtParesInvalidos = CrearTablaParesInvalidos()
                        '        DTInformacionCliente = objBU.ObtenerClienteOT(OTID)
                        '        DTAtadosIncompletos.Rows.Clear()
                        '        If DTInformacionCliente.Rows.Count > 0 Then
                        '            ClienteID = DTInformacionCliente.Rows(0).Item(0).ToString()
                        '            If DTInformacionCliente.Rows(0).Item(0).ToString() = "816" Then
                        '                EsAndrea = True
                        '                DTCodigosAndreaPorAtado = objBU.ObtenerCodigosAndreaPorAtado(OTID, Atado)
                        '            Else
                        '                EsAndrea = False
                        '            End If
                        '        Else
                        '            ClienteID = 0
                        '        End If
                        '    ElseIf Codigo.Length = 4 Then
                        '        Estiba = stringReader.Replace("ES-", "")
                        '    Else
                        '        CodigosInvalidos += 1
                        '    End If



                        'Else

                        '    If Codigo.Length = 2 Then
                        '        OTID = CInt(Codigo(1))
                        '        Atado = String.Empty
                        '        Estiba = String.Empty
                        '        ListaOTs.Add(OTID)
                        '        ListaParesOT.Add(DTInformacion)
                        '        ListaParesInvalidos.Add(dtParesInvalidos)
                        '        DTInformacion = CrearTablaParesAConfirmar()
                        '        dtParesInvalidos = CrearTablaParesInvalidos()
                        '        DTInformacionCliente = objBU.ObtenerClienteOT(OTID)
                        '        If DTInformacionCliente.Rows.Count > 0 Then
                        '            ClienteID = DTInformacionCliente.Rows(0).Item(0).ToString()
                        '            If DTInformacionCliente.Rows(0).Item(0).ToString() = "816" Then
                        '                EsAndrea = True
                        '                DTCodigosAndreaPorAtado = objBU.ObtenerCodigosAndreaPorAtado(OTID, Atado)
                        '            Else
                        '                EsAndrea = False
                        '            End If
                        '        Else
                        '            ClienteID = 0
                        '        End If

                        '    ElseIf Codigo.Length = 4 Then
                        '        Estiba = stringReader.Replace("ES-", "")

                        '    ElseIf stringReader.Trim.Length = 11 Or Codigo.Length = 1 Then
                        '        Atado = Codigo(0)

                        '        If DTInformacion.AsEnumerable().Where(Function(x) x.Item("CodigoAtado").ToString = Codigo(0)).Count = 0 Then
                        '            DTResultado = objBU.ValidacionPares(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 2, Atado, Estiba)

                        '            Resultado = ObtenerMensajeValidacionPar(2, DTResultado.Rows(0).Item("TipoResultado").ToString())

                        '            If DTResultado.Rows(0).Item("TipoResultado").ToString() = "1" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "2" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "3" Then
                        '                DTInformacion.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), "", DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), DTResultado.Rows(0).Item("StatusPartida").ToString(), 2, ClienteID.ToString)
                        '            Else
                        '                dtParesInvalidos.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), "", DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, DTResultado.Rows(0).Item("StatusPartida").ToString())
                        '            End If
                        '        Else
                        '            dtParesInvalidos.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), "", DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, "-1", "Repetido", Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, "")
                        '        End If

                        '    ElseIf stringReader.Trim().Length > 25 And stringReader.Trim().Length < 30 Or Codigo.Length = 3 Then

                        '        DTResultado = objBU.ValidacionPares(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, 1, Codigo(2).ToString().Trim(), Estiba)

                        '        Resultado = ObtenerMensajeValidacionPar(1, DTResultado.Rows(0).Item("TipoResultado").ToString())

                        '        If DTResultado.Rows(0).Item("TipoResultado").ToString() = "1" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "2" Or DTResultado.Rows(0).Item("TipoResultado").ToString() = "3" Then
                        '            DTInformacion.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), Codigo(2).ToString.Trim(), DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Date.Now.ToString(), DTResultado.Rows(0).Item("StatusPartida").ToString(), 1, ClienteID.ToString())
                        '        Else
                        '            dtParesInvalidos.Rows.Add(OTID, Estiba, DTResultado.Rows(0).Item("Atado").ToString(), Codigo(2).ToString.Trim(), DTResultado.Rows(0).Item("Talla").ToString, DTResultado.Rows(0).Item("Articulo").ToString, DTResultado.Rows(0).Item("TipoResultado").ToString(), Resultado, Entidades.SesionUsuario.UsuarioSesion.PUserUsername, Nothing, DTResultado.Rows(0).Item("StatusPartida").ToString())
                        '        End If

                        '    Else
                        '        CodigosInvalidos += 1

                        '    End If
                        'End If

                        'End If

                    End While

                    fileReader.Close()
                Catch ex As Exception
                    show_message("Error", ex.Message.ToString())
                    fileReader.Close()
                End Try


                ListaParesOT.Add(DTInformacion)
                ListaParesInvalidos.Add(dtParesInvalidos)


                If ListaParesOT.Count > 0 Then
                    IndiceListaOT = 0
                    CargarInformacionOTArchivo(ListaOTs(IndiceListaOT))
                    CargarParesAConfirmar()
                Else
                    IndiceListaOT = -1
                End If

                If ListaOTs.Count > 0 Then
                    CargarPartidasOTArchivo(ListaOTs(IndiceListaOT))
                End If


                If IndiceListaOT >= 0 Then
                    HabilitarBotonGuardar()
                Else
                    btnGuardar.Enabled = False
                    lblGuardar.Enabled = False
                End If


                HabilitarBotonGuardar()
                HabilitarBotonSiguienteOrden(ListaParesOT)

                Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Cursor = Cursors.Default

            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Function ObtenerMensajeValidacionPar(ByVal TipoCodigo As Integer, ByVal Resultado As Integer) As String
        Dim Mensaje As String = String.Empty

        If TipoCodigo = 1 Then
            If Resultado = "1" Then
                Mensaje = "Par Correcto"
            ElseIf Resultado = "2" Then
                Mensaje = "Par con incidencia"
            ElseIf Resultado = "3" Then
                Mensaje = "Par Erroneo"
                CodigosInvalidos += 1
            ElseIf Resultado = "4" Then
                Mensaje = "Par ya confirmado"
            ElseIf Resultado = "5" Then
                Mensaje = "Par invalido"
                CodigosInvalidos += 1
            ElseIf Resultado = "6" Then
                Mensaje = "No pertenece a la OT"
                CodigosInvalidos += 1
            ElseIf Resultado = "7" Then
                Mensaje = "Atado no pertenece completamente a la OT"
                CodigosInvalidos += 1
            End If
        ElseIf TipoCodigo = 2 Then

            If Resultado = "1" Then
                Mensaje = "Atado Correcto."
            ElseIf Resultado = "2" Then
                Mensaje = "Atado con incidencia."
            ElseIf Resultado = "3" Then
                Mensaje = "Atado Erroneo."
                CodigosInvalidos += 1
            ElseIf Resultado = "4" Then
                Mensaje = "Atado ya confirmado."
            ElseIf Resultado = "5" Then
                Mensaje = "Atado invalido."
                CodigosInvalidos += 1
            ElseIf Resultado = "6" Then
                Mensaje = "No pertenece a la OT."
                CodigosInvalidos += 1
            ElseIf Resultado = "7" Then
                Mensaje = "Atado no pertenece completamente a la OT."
                CodigosInvalidos += 1
            ElseIf Resultado = "8" Then
                Mensaje = "Atado Incompleto."
            ElseIf Resultado = "9" Then
                Mensaje = "El atado se encuentra separado en varias estibas."
            End If
        End If

        Return Mensaje

    End Function

    Private Sub CargarParesAConfirmar()
        grdParesAConfirmar.DataSource = Nothing
        DiseñoGridParesConfirmar(grdParesAConfirmar)
        If ListaParesOT.Count > 0 Then
            grdParesAConfirmar.DataSource = ListaParesOT(IndiceListaOT)
        Else
            IndiceListaOT = -1
        End If

        lblTotalCodigosInvalidos.Text = ListaParesInvalidos(IndiceListaOT).Rows.Count

    End Sub


    Private Sub HabilitarBotonSiguienteOrden(ByVal Lista As List(Of DataTable))

        If Lista.Count = 0 Or Lista.Count = 1 Then
            btnAnteriorOT.Enabled = False
            lblTextoOTAnterior.Enabled = False
            btnSiguienteOT.Enabled = False
            lblTextoOTSiguiente.Enabled = False
        Else
            btnAnteriorOT.Enabled = False
            lblTextoOTAnterior.Enabled = False
            btnSiguienteOT.Enabled = True
            lblTextoOTSiguiente.Enabled = True
        End If


    End Sub


    Private Sub grdPartidas_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdPartidas.InitializeRow
        If IsNothing(grdPartidas.DataSource) = False Then
            If e.Row.Index >= 0 Then
                e.Row.Appearance.BackColor = AsignarColorPartida(e.Row.Cells("TotalPares").Value, e.Row.Cells("ParesConfirmados").Value, e.Row.Cells("StatusID").Value)
            End If
        End If
    End Sub

    Private Function AsignarColorPartida(ByVal TotalPares As Integer, ByVal ParesConfirmados As Integer, ByVal EstatusId As Integer) As Color

        Dim TipoColor As New Color

        If EstatusId = "129" Then
            TipoColor = Color.RosyBrown
        ElseIf EstatusId = "130" Then
            TipoColor = lblColorRechazada.BackColor
        ElseIf EstatusId = "122" Then
            TipoColor = Color.Thistle
        Else
            If TotalPares = ParesConfirmados Then
                TipoColor = Color.Empty
            ElseIf TotalPares > ParesConfirmados Then
                TipoColor = Color.Gold
            ElseIf ParesConfirmados > TotalPares Then
                TipoColor = Color.Tomato
            Else
                TipoColor = Color.Empty
            End If

        End If

        Return TipoColor

    End Function

    Private Function AsignarColorPares(ByVal EstatusPartida As Integer, ByVal EstatusIdPar As Integer) As Color

        Dim TipoColor As New Color

        If EstatusPartida = "129" Then
            TipoColor = Color.RosyBrown
        ElseIf EstatusPartida = "130" Then
            TipoColor = lblColorRechazada.BackColor
        Else
            If EstatusIdPar = 1 Then
                TipoColor = Color.Empty
            Else
                TipoColor = Color.Gold
            End If
        End If

        Return TipoColor

    End Function


    Private Sub grdParesAConfirmar_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdParesAConfirmar.InitializeRow
        If IsNothing(grdParesAConfirmar.DataSource) = False Then
            If e.Row.Index >= 0 Then
                e.Row.Appearance.BackColor = AsignarColorParesAConfirmar(e.Row.Cells("ResultadoID").Value, e.Row.Cells("StatusPartida").Value)
                If e.Row.Appearance.BackColor = Color.Tomato Then
                    'e.Row.Hidden = True
                End If
            End If
        End If
    End Sub

    Private Function AsignarColorParesAConfirmar(ByVal TipoResultado As Integer, ByVal StatusPartidaId As Integer) As Color
        Dim TipoColor As New Color

        If TipoResultado = 1 Then '"Par Correcto"
            TipoColor = Color.Green
        ElseIf TipoResultado = 2 Then '"Par con incidencia"
            TipoColor = Color.Green
        ElseIf TipoResultado = 3 Then '"Par Erroneo"
            TipoColor = Color.Tomato
        ElseIf TipoResultado = 4 Then '"Par ya confirmado"
            TipoColor = Color.Gold
        ElseIf TipoResultado = 5 Then '"Par invalido"
            TipoColor = Color.Tomato
        ElseIf TipoResultado = 6 Then '"No pertenece a la OT"
            TipoColor = Color.Tomato
        ElseIf TipoResultado = 7 Then '"Atado no pertenece completamente a la OT"
            TipoColor = Color.Tomato

        End If

        'If StatusPartidaId = 122 Then
        '    TipoColor = Color.Orange
        'Else

        'End If

        Return TipoColor

    End Function

    Private Sub btnExportarDetalles_Click(sender As Object, e As EventArgs) Handles btnExportarDetalles.Click
        exportarExcel(grdPartidas)
    End Sub


    'UltraGridExcelExporter

    Public Sub exportarExcel(ByVal grd As UltraGrid)
        Dim sfd As New SaveFileDialog
        Dim NombreArchivo As String = String.Empty

        If IsNothing(grd) = False Then
            If grd.Rows.Count = 0 Then
                show_message("Advertencia", "No hay informacion para exportar a excel.")
                Return
            End If
        End If

        Dim fbdUbicacionArchivo As New FolderBrowserDialog

        With fbdUbicacionArchivo
            .Reset()
            .Description = " Seleccione una carpeta "
            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            .ShowNewFolderButton = True

            Dim ret As DialogResult = .ShowDialog
            Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

            If ret = Windows.Forms.DialogResult.OK Then
                Try
                    Me.Cursor = Cursors.WaitCursor

                    If grdPartidas.Name = grd.Name Then
                        NombreArchivo = .SelectedPath + "\DetallesPartidas_OrdenTrabajo_" + fecha_hora + ".xlsx"
                    ElseIf grdParesConfirmados.Name = grd.Name Then
                        NombreArchivo = .SelectedPath + "\DetallesParesPartidas_OrdenTrabajo_" + fecha_hora + ".xlsx"
                    End If

                    UltraGridExcelExporter1.Export(grd, NombreArchivo)
                    show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + NombreArchivo)
                    Process.Start(NombreArchivo)
                    Me.Cursor = Cursors.Default

                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atencion")
                End Try
            End If
        End With



        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        'Dim result As DialogResult = sfd.ShowDialog()
        'Dim fileName As String = sfd.FileName


        'If result = Windows.Forms.DialogResult.OK Then
        '    Try
        '        Me.Cursor = Cursors.WaitCursor
        '        UltraGridExcelExporter1.Export(grd, fileName)
        '        show_message("Exito", "El archivo se ha exportado correctamente en la ruta " + fileName)
        '        Process.Start(fileName)
        '        Me.Cursor = Cursors.Default


        '    Catch ex As Exception
        '        Me.Cursor = Cursors.Default
        '        MsgBox("El documento no pudo exportarse." + vbLf + "Revise que no tenga otro documento XLS " + vbLf + "abierto con el mismo nombre.", MsgBoxStyle.Critical, "Atencion")
        '    End Try
        'End If


    End Sub


    Private Sub btnExportarConfirmados_Click(sender As Object, e As EventArgs) Handles btnExportarConfirmados.Click
        exportarExcel(grdParesConfirmados)
    End Sub


    Private Function CancelarConfirmacion(ByVal Mensaje As String) As Boolean
        Dim confirmar As New Tools.ConfirmarForm
        Dim Resultado As Boolean = False

        Try

            confirmar.mensaje = Mensaje

            Cursor = Cursors.WaitCursor
            If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Resultado = True
                LimpiarDatos()

            Else
                Resultado = False
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString())
        End Try

        Return Resultado

    End Function

    Private Sub btnCancelarConfirmacion_Click(sender As Object, e As EventArgs) Handles btnCancelarConfirmacion.Click


        If CancelarConfirmacion("¿Esta seguro de cancelar la partida?") = True Then
            LimpiarDatos()
        End If


        'Dim confirmar As New Tools.ConfirmarForm
        'Dim PartidaSeleccionada = grdPartidas.Rows.FirstOrDefault(Function(x) x.Selected = True)
        'Dim EstatusPartida As Integer = 0

        'Try
        '    If IsNothing(PartidaSeleccionada) = False Then
        '        EstatusPartida = PartidaSeleccionada.Cells("StatusID").Value
        '    Else
        '        show_message("Advertencia", "Se debe de seleccionar una partida.")
        '        Return
        '    End If

        '    If EstatusPartida = 119 Or EstatusPartida = 120 Or EstatusPartida = 121 Or EstatusPartida = 123 Then
        '        confirmar.mensaje = "¿Esta seguro de cancelar la partida?"
        '        Cursor = Cursors.WaitCursor
        '        If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '            objBU.CancelarPartidaOT(PartidaSeleccionada.Cells("OrdenTrabajoSAYID").Value, PartidaSeleccionada.Cells("Partida").Value, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        '            show_message("Exito", "La Partida se ha cancelado.")

        '            CargarPartidas()

        '            If NumeroOrdenesTrabajo = 1 Then
        '                CargarInformacion()
        '            Else
        '                CargarTotalesVariasOTs()
        '            End If

        '            CargarPares(OrdenTrabajoID, 0)
        '        End If
        '        Cursor = Cursors.Default
        '    ElseIf EstatusPartida = 129 Or EstatusPartida = 130 Then
        '        show_message("Advertencia", "La partida ya se encuentra cancelada.")
        '    Else
        '        show_message("Advertencia", "No se puede cancelar la partida debido a que se encuentra en ejecución o ya esta confirmada.")
        '    End If

        'Catch ex As Exception
        '    Cursor = Cursors.Default
        'End Try

    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdParesAConfirmar.DataSource = Nothing
        lblTotalCodigosInvalidos.Text = "0"
        lblTotalCodigosInvalidos.Visible = False
        lblTextoCodigosInvalidos.Visible = False
        lblNotaCodigoInvalido.Visible = False
        IndiceListaOT = 0
        ListaParesInvalidos.Clear()
        ListaParesOT.Clear()
        ListaOTs.Clear()
        btnSiguienteOT.Enabled = False
        lblTextoOTSiguiente.Enabled = False
        btnAnteriorOT.Enabled = False
        lblTextoOTAnterior.Enabled = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim CodigoPar As String = String.Empty
        Dim EstatusPartida As Integer = 0
        Dim OTID As Integer = 0
        Dim CodigoAtado As String = String.Empty
        Dim Estiba As String = String.Empty
        Dim ParesCorrectos As Integer = 0
        Dim ParesAConfirmar As Integer = 0
        Dim EntgInformacionOT As Entidades.OrdenTrabajo

        Try
            Cursor = Cursors.WaitCursor
            EntgInformacionOT = objBU.ConsultarInformacionOT(ListaOTs(IndiceListaOT))

            If EntgInformacionOT.EstatusID = 121 OrElse EntgInformacionOT.EstatusID = 122 OrElse EntgInformacionOT.EstatusID = 123 Then
                ParesCorrectos = grdParesAConfirmar.Rows.Where(Function(x) x.Appearance.BackColor = Color.Green).Count()
                ParesAConfirmar = grdParesAConfirmar.Rows.Count()

                If grdParesAConfirmar.Rows.Count > 0 Then
                    OTID = grdParesAConfirmar.Rows(0).Cells("OTID").Value
                    objBU.IniciarTiempoEjecucionOperador(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, OTID)
                End If

                If grdParesAConfirmar.Rows.Count > 0 Then
                    If CInt(lblTotalCodigosInvalidos.Text) = 0 And (ParesCorrectos = ParesAConfirmar) Then
                        For Each Fila As UltraGridRow In grdParesAConfirmar.Rows

                            CodigoPar = Fila.Cells("CodigoPar").Value
                            ' OTID = Fila.Cells("OTID").Value
                            Estiba = Fila.Cells("Estiba").Value
                            CodigoAtado = Fila.Cells("CodigoAtado").Value

                            If EsAndrea = True Then
                                objBU.ConfirmacionParesANDREA(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, CodigoAtado, CodigoPar, Estiba)
                            Else
                                If Fila.Cells("TipoCodigo").Value = 1 Then
                                    objBU.ConfirmacionPares(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Fila.Cells("TipoCodigo").Value, CodigoPar, Estiba)
                                ElseIf Fila.Cells("TipoCodigo").Value = 2 Then
                                    objBU.ConfirmacionPares(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, Fila.Cells("TipoCodigo").Value, CodigoAtado, Estiba)
                                End If
                            End If
                        Next

                        'objBU.ActualizarEncabezadosOrdenTrabajo()
                        objBU.ActualizarEstatusPartidaOrdenTrabajo(ListaOTs(IndiceListaOT))

                        ListaParesOT(IndiceListaOT).Rows.Clear()
                        objBU.FinalizarTiempoEjecucionOperador(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, OTID)
                        CargarPartidasOTArchivo(ListaOTs(IndiceListaOT))
                        EnviarAFacturacionOT(ListaOTs(IndiceListaOT))


                        'If OrdenTrabajoID = String.Empty Then
                        '    CargarPartidasOTArchivo(ListaOTs(IndiceListaOT))
                        'Else
                        '    objBU.FinalizarTiempoEjecucionOperador(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, OTID)
                        '    CargarPartidas()

                        '    If NumeroOrdenesTrabajo = 1 Then
                        '        CargarInformacion()
                        '    Else
                        '        CargarTotalesVariasOTs()
                        '    End If

                        '    CargarPares(OrdenTrabajoID, 0)
                        'End If

                        show_message("Exito", "Se han confirmado los pares.")
                        ListaOTs.Remove(IndiceListaOT)
                    Else
                        show_message("Advertencia", "No se puede confirmar debido que hay códigos inválidos o ya fueron confirmados  los pares.")
                    End If
                End If
            Else
                show_message("Advertencia", "La OT tiene que estar Aceptada, En ejecución o Parcialmente Confirmada,  para confirmar los pares.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            If grdParesAConfirmar.Rows.Count > 0 Then
                objBU.FinalizarTiempoEjecucionOperador(Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, grdParesAConfirmar.Rows(0).Cells("OTID").Value)
            End If

            Cursor = Cursors.Default
            show_message("Error", ex.Message)
        End Try

    End Sub

    Private Function EnviarAFacturacionOT(ByVal OTID As Integer) As Boolean
        Dim objbu As New Ventas.Negocios.OrdenTrabajoBU
        Dim dtInformacionOT As DataTable
        Dim Valor As String = String.Empty

        dtInformacionOT = objbu.ObtenerParesConfirmadosOT(OTID)
        If IsNothing(dtInformacionOT) = False AndAlso dtInformacionOT.Rows.Count > 0 Then
            If CInt(dtInformacionOT.Rows(0).Item("ParesPorConfirmar").ToString()) = 0 Then
                objbu.EnviarAFacturarOT(OTID, Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser, CInt(dtInformacionOT.Rows(0).Item("TotalPares").ToString()))
                objbu.ActualizarAPorFacturarOT(OTID)
            End If
        End If

        Return True
    End Function

    Private Sub grdParesConfirmados_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdParesConfirmados.InitializeRow
        If IsNothing(grdParesConfirmados.DataSource) = False Then
            If e.Row.Index >= 0 Then
                e.Row.Appearance.BackColor = AsignarColorPares(e.Row.Cells("EstatusPartidaID").Value, e.Row.Cells("StatusID").Value)
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Function ValidarAtadosCompletos() As Boolean
        Dim Resultado As Boolean = False
        Dim grupo = grdParesAConfirmar.Rows.GroupBy(Function(x) x.Cells("CodigoAtado").Value)
        Dim AtadosIncompletos = grupo.Where(Function(y) y.Count < 5 Or y.Count > 5)
        Dim cantidad As Integer = AtadosIncompletos.Count
        DTAtadosIncompletos.Rows.Clear()

        For Each grp In AtadosIncompletos
            DTAtadosIncompletos.Rows.Add(grp(0).Cells("OTID").Value, grp(0).Cells("CodigoAtado").Value, "Atado incompleto")
        Next
        lblCantidadAtadosIncompletos.Text = cantidad.ToString()

        If cantidad > 0 Then
            Resultado = False
        Else
            Resultado = True
        End If

        Return Resultado

    End Function

    Private Sub btnSiguienteApartado_Click(sender As Object, e As EventArgs) Handles btnSiguienteOT.Click
        DTAtadosIncompletos.Rows.Clear()

        IndiceListaOT += 1
        CargarInformacionOTArchivo(ListaOTs(IndiceListaOT))
        CargarParesAConfirmar()
        btnAnteriorOT.Enabled = True
        lblTextoOTAnterior.Enabled = True
        CargarPartidasOTArchivo(ListaOTs(IndiceListaOT))
        lblTotalCodigosInvalidos.Text = ListaParesInvalidos(IndiceListaOT).Rows.Count

        If ListaParesOT.Count - 1 > IndiceListaOT Then
            btnSiguienteOT.Enabled = True
            lblTextoOTSiguiente.Enabled = True

        Else
            btnSiguienteOT.Enabled = False
            lblTextoOTSiguiente.Enabled = False
        End If

        HabilitarBotonGuardar()

    End Sub

    Private Sub HabilitarBotonGuardar()
        Dim ParesCorrectos = grdParesAConfirmar.Rows.Where(Function(x) x.Appearance.BackColor = Color.Green).Count()
        Dim ParesAConfirmar = grdParesAConfirmar.Rows.Count()


        If ListaParesInvalidos(IndiceListaOT).Rows.Count > 0 Then
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        ElseIf DTAtadosIncompletos.Rows.Count > 0 Then
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        Else
            If ParesCorrectos <> ParesAConfirmar Then
                btnGuardar.Enabled = False
                lblGuardar.Enabled = False
            Else
                If objEnt.EstatusID = "121" Or objEnt.EstatusID = "122" Or objEnt.EstatusID = "123" Or objEnt.EstatusID = "124" Then
                    btnGuardar.Enabled = True
                    lblGuardar.Enabled = True
                Else
                    btnGuardar.Enabled = False
                    lblGuardar.Enabled = False
                    show_message("Advertencia", "Solo las OTs que han sido aceptadas se pueden confirmar.")
                End If
            End If

        End If
    End Sub

    Private Sub btnAnteriorApartado_Click(sender As Object, e As EventArgs) Handles btnAnteriorOT.Click
        DTAtadosIncompletos.Rows.Clear()
        IndiceListaOT -= 1
        CargarInformacionOTArchivo(ListaOTs(IndiceListaOT))
        CargarParesAConfirmar()
        CargarPartidasOTArchivo(ListaOTs(IndiceListaOT))
        lblTotalCodigosInvalidos.Text = ListaParesInvalidos(IndiceListaOT).Rows.Count

        btnSiguienteOT.Enabled = True
        lblTextoOTSiguiente.Enabled = True

        If IndiceListaOT > 0 Then
            btnAnteriorOT.Enabled = True
            lblTextoOTAnterior.Enabled = True
        Else
            btnAnteriorOT.Enabled = False
            lblTextoOTAnterior.Enabled = False
        End If

        HabilitarBotonGuardar()

    End Sub


    Private Sub lblTotalCodigosInvalidos_DoubleClick(sender As Object, e As EventArgs) Handles lblTotalCodigosInvalidos.DoubleClick
        MostrarParesInvalidos()
    End Sub

    Private Sub MostrarParesInvalidos()
        Dim ParesInvalidos As New ParesInvalidosForm
        Dim ESClienteAndreaSAYID As Integer = 0

        ESClienteAndreaSAYID = grdPartidas.Rows.Where(Function(x) x.Cells("ClienteSAYID").Value = "816").Count()

        ParesInvalidos.DTParesInvalidosOT = ListaParesInvalidos(IndiceListaOT)
        ParesInvalidos.DTAtadosIncompletos = DTAtadosIncompletos
        If ESClienteAndreaSAYID > 0 Then
            ParesInvalidos.EsAndrea = True
        Else
            ParesInvalidos.EsAndrea = False
        End If

        ParesInvalidos.ShowDialog()
    End Sub


    Private Sub lblCantidadAtadosIncompletos_DoubleClick(sender As Object, e As EventArgs) Handles lblCantidadAtadosIncompletos.DoubleClick
        MostrarParesInvalidos()
    End Sub

    Private Sub btnGenerarXML_Click(sender As Object, e As EventArgs) Handles btnGenerarXML.Click
        Dim Form As New LotesAndreaGenerarXML_form
        Form.ordenTrabajo = OrdenTrabajoID
        Form.ShowDialog()
    End Sub

    Private Sub btnImprimirDetalles_Click(sender As Object, e As EventArgs) Handles btnImprimirDetalles.Click

    End Sub

    Private Sub btnCancelarPartidasOT_Click(sender As Object, e As EventArgs) Handles btnCancelarPartidasOT.Click
        Dim partidasSeleccionadas As String = ""
        Dim totalPartidasSeleccionadas As Integer = 0
        Dim objBU As New Negocios.OrdenTrabajoBU
        Dim dtResultadoCancelacion As New DataTable
        Dim confirmacion As New Tools.ConfirmarForm
        Dim Split_OT_Desasignacion As String()
        'Dim objCancelacionPedido As New Ventas.Negocios.CancelacionPedidosBU
        Dim PartidaSeleccionada As Boolean = False



        For Each row As UltraGridRow In grdPartidas.Rows
            If CBool(row.Cells("Seleccionar").Value) Then
                PartidaSeleccionada = True
            End If
        Next

        If PartidaSeleccionada = False Then
            show_message("Advertencia", "Debe seleccionar al menos una partida a cancelar.")
            Return
        End If

        confirmacion.mensaje = "Se cancelarán las partidas seleccionadas, este proceso no se puede revertir. ¿Desea continuar?"
        If confirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then

            Try
                Cursor = Cursors.WaitCursor

                If TipoOT.Equals("DESASIGNACION") Then
                    For Each rowGrd As UltraGridRow In grdPartidas.Rows
                        If CBool(rowGrd.Cells("Seleccionar").Value) Then
                            OrdenTrabajoID = rowGrd.Cells("OrdenTrabajoSAYID").Value
                            partidasSeleccionadas = rowGrd.Cells("Partida").Value.ToString()

                            If CancelarOrdenTrabajoDesasignacion(OrdenTrabajoID, partidasSeleccionadas) = False Then
                                show_message("Advertencia", "No se cancelaron las partidas seleccionadas, vuelva a intentar.")
                            Else

                                CancelacionOTDesasignacionActualizarPedidos(OrdenTrabajoID, partidasSeleccionadas)

                                If dtResultadoCancelacionOTDesasignacionActualizarPedidos.Rows(0).Item("respuesta") = "ERROR" Then
                                    show_message("Advertencia", "No se actualizaron los pedidos , vuelva a intentar.")

                                Else

                                End If

                            End If
                        End If
                    Next

                    'For Each row As UltraGridRow In grdPartidas.Rows
                    '    If CBool(row.Cells("Seleccionar").Value) Then
                    '        If partidasSeleccionadas <> "" Then
                    '            partidasSeleccionadas += ","
                    '        End If
                    '        partidasSeleccionadas += row.Cells("Partida").Value.ToString()
                    '        totalPartidasSeleccionadas += 1
                    '    End If
                    'Next



                    'CancelarOrdenTrabajoDesasignacion(OrdenTrabajoID, partidasSeleccionadas)
                    'CancelacionOTDesasignacionActualizarPedidos(OrdenTrabajoID, partidasSeleccionadas)

                    show_message("Exito", "Se cancelaron correctamente las partidas seleccionadas.")
                    administrador.MostrarInformacion(sender, e)
                    btnSalir_Click(sender, e)
                Else

                    For Each row As UltraGridRow In grdPartidas.Rows
                        If CBool(row.Cells("Seleccionar").Value) Then
                            If partidasSeleccionadas <> "" Then
                                partidasSeleccionadas += ","
                            End If
                            partidasSeleccionadas += row.Cells("OrdenTrabajoDetalleID").Value.ToString()
                            totalPartidasSeleccionadas += 1
                        End If
                    Next

                    If totalPartidasSeleccionadas > 0 Then
                        dtResultadoCancelacion = objBU.CancelarPartidasOT(OrdenTrabajoID, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, partidasSeleccionadas)
                        If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                            dtResultadoCancelacion = objBU.CancelarParesDeOTSICY(OrdenTrabajoID)
                            If dtResultadoCancelacion.Rows(0).Item("resultadoCancelacion").ToString() = 1 Then
                                objBU.ElimnarOtsInWork(OrdenTrabajoID)

                                'Si hay partidas a cancelar de OT de Desasignacion
                                Split_OT_Desasignacion = Split(CancelarOTDesasignacion, ",")

                                'For Each item As String In Split_OT_Desasignacion
                                '    'ReversaCancelacionPedidos
                                '    objCancelacionPedido.ReversaCancelacionPedidos(item)
                                'Next


                                show_message("Exito", "Se cancelaron correctamente las partidas seleccionadas.")
                                administrador.MostrarInformacion(sender, e)
                                btnSalir_Click(sender, e)
                            Else
                                show_message("Advertencia", "No se cancelaron las partidas seleccionadas, vuelva a intentar.")
                            End If
                        Else
                            show_message("Advertencia", "No se cancelaron las partidas seleccionadas, vuelva a intentar.")
                        End If
                    Else
                        show_message("Advertencia", "Debe seleccionar al menos una partida a cancelar.")
                    End If

                End If

            Catch ex As Exception
                show_message("Advertencia", "No se cancelaron las partidas seleccionadas, vuelva a intentar.")
            End Try
            'CargarPartidas()
            'CargarPares(OrdenTrabajoID, 0)
            'CargarTotalesVariasOTs()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        For Each row As UltraGridRow In grdPartidas.Rows

            If EsCancelacion Then
                If row.Cells("StatusID").Value = 119 Then ' Or row.Cells("StatusID").Value = 130 Then
                    row.Cells("Seleccionar").Value = chboxSeleccionarTodo.Checked
                Else
                    row.Cells("Seleccionar").Value = False
                End If

            Else
                If row.Cells("Seleccionar").Hidden = False Then
                    If chboxSeleccionarTodo.Checked Then
                        row.Cells("Seleccionar").Value = True
                    Else
                        row.Cells("Seleccionar").Value = False
                    End If
                End If
            End If

        Next
    End Sub

    Private Sub grdPartidas_MouseClick(sender As Object, e As MouseEventArgs) Handles grdPartidas.MouseClick
        Dim partidasSeleccionadas As Integer = 0
        Dim partidasMarcadas As Integer = 0

        If e.Button = Windows.Forms.MouseButtons.Right Then
            If EsCancelacion Then

                For Each row As UltraGridRow In grdPartidas.Rows.Where(Function(x) x.Cells("Seleccionar").Selected = True Or x.Cells("Partida").Selected = True Or x.Cells("Tienda").Selected = True Or x.Cells("Articulo").Selected = True Or x.Cells("TotalPares").Selected = True Or x.Cells("ParesConfirmados").Selected = True Or x.Cells("ParesPorConfirmar").Selected = True)
                    If row.Cells("Seleccionar").Hidden = False Then
                        partidasSeleccionadas += 1
                        If CBool(row.Cells("Seleccionar").Value) = True Then
                            partidasMarcadas += 1
                        End If
                    End If
                Next

                If partidasSeleccionadas > 0 Then
                    If partidasMarcadas = partidasSeleccionadas Then
                        cmsSeleccionarVariasPartidas.Items(0).Visible = False
                        cmsSeleccionarVariasPartidas.Items(1).Visible = True
                    ElseIf partidasMarcadas = 0 Then
                        cmsSeleccionarVariasPartidas.Items(0).Visible = True
                        cmsSeleccionarVariasPartidas.Items(1).Visible = False
                    Else
                        cmsSeleccionarVariasPartidas.Items(0).Visible = True
                        cmsSeleccionarVariasPartidas.Items(1).Visible = True
                    End If

                    cmsSeleccionarVariasPartidas.Show(Control.MousePosition)
                End If
            End If
        End If


        'If e.Button = Windows.Forms.MouseButtons.Right Then

        'End If
    End Sub

    Private Sub SeleccionarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionarToolStripMenuItem.Click
        For Each row As UltraGridRow In grdPartidas.Rows.Where(Function(x) x.Cells("Seleccionar").Selected = True Or x.Cells("Partida").Selected = True Or x.Cells("Tienda").Selected = True Or x.Cells("Articulo").Selected = True Or x.Cells("TotalPares").Selected = True Or x.Cells("ParesConfirmados").Selected = True Or x.Cells("ParesPorConfirmar").Selected = True)
            If row.Cells("Seleccionar").Hidden = False Then
                row.Cells("Seleccionar").Value = True
            End If
        Next
    End Sub

    Private Sub QuitarSelecciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarSelecciónToolStripMenuItem.Click
        For Each row As UltraGridRow In grdPartidas.Rows.Where(Function(x) x.Cells("Seleccionar").Selected = True Or x.Cells("Partida").Selected = True Or x.Cells("Tienda").Selected = True Or x.Cells("Articulo").Selected = True Or x.Cells("TotalPares").Selected = True Or x.Cells("ParesConfirmados").Selected = True Or x.Cells("ParesPorConfirmar").Selected = True)
            If row.Cells("Seleccionar").Hidden = False Then
                row.Cells("Seleccionar").Value = False
            End If
        Next
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        Dim viewImportarDistribuciones As New FacturacionAnticipada_ImportarDistribucionTiendas_Form
        Dim entDistribucion = New Entidades.DistribucionPedido
        entDistribucion.OrdenTrabajoID = CInt(OrdenTrabajoID)
        entDistribucion.Cliente = New Entidades.Cliente
        entDistribucion.Cliente.nombregenerico = objEnt.Cliente
        entDistribucion.PedidoSAY = objEnt.PedidoSAYID
        entDistribucion.PedidoSICY = objEnt.PedidoSICYID
        entDistribucion.ParesPedido = objEnt.TotalPares
        entDistribucion.OrdenCliente = objEnt.OrdenCliente
        viewImportarDistribuciones.entDistribucion = entDistribucion
        viewImportarDistribuciones.soloConsulta = True
        viewImportarDistribuciones.ShowDialog()
    End Sub


    Private Function CancelarOrdenTrabajoDesasignacion(ordenTrabajo As Integer, partidas As String) As Boolean
        Dim correcto As Boolean = False
        Dim objBuReasignacionOt As New Negocios.ReasignacionOTBU

        correcto = objBuReasignacionOt.CancelarOrdenTrabajoDesasignacion(ordenTrabajo, partidas)

        objBuReasignacionOt.CancelarOrdenTrabajoDesasignacionSICY(ordenTrabajo, partidas)
        Return correcto

    End Function

    Private Function CancelacionOTDesasignacionActualizarPedidos(ordenTrabajo As Integer, partidas As String)
        Dim objBuReasignacionOt As New Negocios.ReasignacionOTBU


        dtResultadoCancelacionOTDesasignacionActualizarPedidos = objBuReasignacionOt.CancelacionOTDesasignacionActualizarPedidos(ordenTrabajo, partidas)

        Return dtResultadoCancelacionOTDesasignacionActualizarPedidos
    End Function

    Private Sub grdPartidas_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdPartidas.ClickCell
        If e.Cell.Column.ToString() = "Seleccionar" Then

            Dim FilasSeleccionadas = grdPartidas.Rows.Where(Function(x) x.Cells("OrdenTrabajoDetalleID").Value = e.Cell.Row.Cells("OrdenTrabajoDetalleID").Value)

            For Each Fila As UltraGridRow In FilasSeleccionadas

                If Fila.Cells("Seleccionar").Value = False Then
                    Fila.Cells("Seleccionar").Value = True
                Else
                    Fila.Cells("Seleccionar").Value = False
                End If

            Next

        End If
    End Sub



End Class