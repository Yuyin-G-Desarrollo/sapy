Imports DevExpress.Export
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Public Class DevolucionCliente_AdministradorDC_Form

    Public listaFiltroFolios As New List(Of String)
    Public listaFiltroPedidosSay As New List(Of String)
    Public listaFiltroPedidosSicy As New List(Of String)
    Public listaFiltroDocumentos As New List(Of String)

    Public objFiltros As New Entidades.FiltroAdministradorDevoluciones
    Public objDev As New Entidades.DevolucionCliente
    Public objPermisos As New Entidades.DevolucionCliente_PermisosPantallas

    Public ventanaExito As New Tools.ExitoForm
    Public ventanaError As New Tools.ErroresForm
    Public ventanaAdvertencias As New Tools.AdvertenciaForm
    Public ventanaConfirmacion As New Tools.ConfirmarForm
    Dim emptyEditor As RepositoryItem
    Public indexSeleccionado As Integer

    Public vistaResumne As Boolean = False

    Public Sub DiseñoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        With grid.DisplayLayout
            ' Todas las columnas se ajustan a su contenido
            .PerformAutoResizeColumns(True, AutoResizeColumnWidthOptions.IncludeCells)
            ' Se intercalan colores entre una fila y otra
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            ' Se muestra el índice (número de renglón)
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            ' Se define el ancho para la fila seleccionda
            .Override.RowSelectorWidth = 35
            ' Se define lo que se hará cuando se de clic sobre una celda
            .Override.CellClickAction = CellClickAction.CellSelect
            ' No se permite agregar nuevas filas
            .Override.AllowAddNew = AllowAddNew.No
            ' Mostrar ambas barras de desplazamienro (horizontal, vertical)
            '.Scrollbars = Scrollbars.Both
            ' No permite operaciones múltiples sobre las filas
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            ''.Override.SelectTypeRow = SelectType.Single
            ' Se define el número de líneas en las que se podrá mostrar el encabezado de la columna
            .Bands(0).ColHeaderLines = 1
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns

            ' Se habilitan los filtros
            .Override.AllowRowFiltering = DefaultableBoolean.False
        End With
    End Sub

    Public Function ObtenerFiltros(grid As UltraGrid)
        Dim filtro As String = ""
        For Each row As UltraGridRow In grid.Rows
            If filtro.Length > 0 Then
                filtro += ","
            End If
            If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
                filtro += row.Cells("Parámetro").Value.ToString
            Else
                filtro += row.Cells(0).Value.ToString
            End If

        Next
        Return filtro
    End Function

    Public Sub SumarColumnas(columna As String, formato As String)
        If IsNothing(bgvDevolucionesClientes.Columns(columna).Summary.FirstOrDefault(Function(x) x.FieldName = columna)) = True Then
            bgvDevolucionesClientes.Columns(columna).Summary.Add(DevExpress.Data.SummaryItemType.Sum, columna, formato)

            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = columna
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = formato
            bgvDevolucionesClientes.GroupSummary.Add(item)
        End If
    End Sub

    Public Sub DiseñoGridDevoluciones()
        Try
            bgvDevolucionesClientes.OptionsView.ColumnAutoWidth = False

            For Each col As DevExpress.XtraGrid.Columns.GridColumn In bgvDevolucionesClientes.Columns
                If col.FieldName <> " " Then
                    col.OptionsColumn.AllowEdit = False
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
                End If
            Next

            If objPermisos.VerMontos = False Then
                bgvDevolucionesClientes.Columns.ColumnByFieldName("Total").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("FolioNC").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("DoctoDeAplicaciónNC").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("TotalNC").Visible = False
            End If

            bgvDevolucionesClientes.Columns.ColumnByFieldName("EstatusID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("IdCliente").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioAtnCte").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsCapturaID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("SinDocumentos").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UnidadID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("IDMotivoInicial").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("PaqueteriaID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UbicaciónAlmacén").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("IDMotivoVentas").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioAlmacenModificaID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioAlmacenModifica").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FModAlmacén").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("DestinoProdID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("ReqAutorización").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("RutaAutorización").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("ResponsableDevID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasUsuarioModificaID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioIdSolicitaNC").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("CobranzaUsuarioModificaID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("DocumentosDetalles").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioPasaEmbarquesID").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioIDIngresaLote").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioIngresaLote").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("DíasTranscurridos").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("IndicaRecepción").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("RA").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioSolicitaNC").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FSolicitaProcAlmacén").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioPasaEmbarques").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FechaGeneraLote").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("LoteGenerados").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("ColaboradorRecibio").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Flete").Visible = False
            bgvDevolucionesClientes.Columns.ColumnByFieldName("AplicaNC").Visible = False

            If rdbVistaResumen.Checked = True Then
                bgvDevolucionesClientes.Columns.ColumnByFieldName("UsCaptura").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("FRecepción").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("Unidad").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesAlmacén").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("CobranzaFModificacion").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("CostoPaquetería").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("NúmGuia").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ModeloSAY").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ColoresSAY").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("CorridasSAY").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("FLímiteAcción").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ResponsableDev").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasUsuarioModifica").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasFModificacion").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesCobranza").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("Pedidos").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("Documentos").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesVentas").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("CobranzaUsuarioModifica").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("FSolicitaProcAlmacén").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("ProcedeAutoriza").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioPasaEmbarques").Visible = False
                bgvDevolucionesClientes.Columns.ColumnByFieldName("AgteActual").Visible = False

                If objPermisos.Area = "VENTAS" Then
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("UsCaptura").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FRecepción").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("NúmGuia").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FolioNC").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DoctoDeAplicaciónNC").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FSolicitaNC").Visible = False
                ElseIf objPermisos.Area = "COBRANZA" Then
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoInicial").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoVentas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FRevisión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DestinoProducto").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantidadAplicada").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantidadPorAplicar").Visible = False
                Else
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantidadAplicada").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantidadPorAplicar").Visible = False

                    If objPermisos.Area = "ALMACÉN" Then
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Rs").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("NC?").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Cantidad").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Total").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Documento").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FolioNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("TotalNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioGeneraNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("DoctoDeAplicaciónNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FSolicitaNC").Visible = False
                    End If

                End If
            Else
                If objPermisos.Area = "VENTAS" Then
                    'bgvDevolucionesClientes.Columns.ColumnByFieldName("SemRec").Visible = False
                    'bgvDevolucionesClientes.Columns.ColumnByFieldName("Paquetería").Visible = False
                    'bgvDevolucionesClientes.Columns.ColumnByFieldName("TFlete").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CostoPaquetería").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Pedidos").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ModeloSAY").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ColoresSAY").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CorridasSAY").Visible = False

                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Unidad").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").Visible = False
                    'bgvDevolucionesClientes.Columns.ColumnByFieldName("EnvíaRV").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Documentos").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ProcedeAutoriza").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesCobranza").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FLímiteAcción").Visible = False
                End If

                If objPermisos.Area = "VENTAS" Then
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FCaptura").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoInicial").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesAlmacén").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesVentas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoVentas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FRevisión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DestinoProducto").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("UsCaptura").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FRecepción").Visible = False
                    'bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").Visible = False
                    'bgvDevolucionesClientes.Columns.ColumnByFieldName("NúmGuia").Visible = False
                ElseIf objPermisos.Area = "COBRANZA" Then
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoInicial").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoVentas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FRevisión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DestinoProducto").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ProcedeAutoriza").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("UsCaptura").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FRecepción").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Unidad").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CostoPaquetería").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("NúmGuia").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ModeloSAY").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ColoresSAY").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CorridasSAY").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("FLímiteAcción").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ResponsableDev").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesVentas").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasUsuarioModifica").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasFModificacion").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesCobranza").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Pedidos").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("Documentos").Visible = False
                Else
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantidadAplicada").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("CantidadPorAplicar").Visible = False
                    bgvDevolucionesClientes.Columns.ColumnByFieldName("AgteActual").Visible = False
                    bgvDevolucionesClientes.Columns("TFlete").Caption = "Tipo Flete"

                    If objPermisos.Area = "ALMACÉN" Then
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Rs").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("AtnCteActual").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("UsCaptura").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FRecepción").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Recibió").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Pedidos").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("ModeloSAY").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("ColoresSAY").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("CorridasSAY").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FRevisión").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Documento").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Documentos").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Unidad").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("EnvíaRV").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FolioNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("TotalNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("UsuarioGeneraNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("DoctoDeAplicaciónNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("CobranzaFModificacion").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasFModificacion").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("CobranzaUsuarioModifica").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("ProcedeAutoriza").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FLímiteAcción").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("VentasUsuarioModifica").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("ObservacionesCobranza").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("FSolicitaNC").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("NC?").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("DProcesamiento").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("ResponsableDev").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").Visible = False
                        bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").Visible = False
                    End If
                    bgvDevolucionesClientes.Columns("Paquetería").Width = 180
                End If
            End If

            bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvDevolucionesClientes.Columns.ColumnByFieldName("TotalNC").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Importe Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            bgvDevolucionesClientes.Columns.ColumnByFieldName("% de Descuento").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            bgvDevolucionesClientes.Columns.ColumnByFieldName("CantCG").DisplayFormat.FormatString = "N0"
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Cajas").DisplayFormat.FormatString = "N0"
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Cantidad").DisplayFormat.FormatString = "N0"
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N2"
            bgvDevolucionesClientes.Columns.ColumnByFieldName("TotalNC").DisplayFormat.FormatString = "N2"
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Importe Total").DisplayFormat.FormatString = "N2"
            bgvDevolucionesClientes.Columns.ColumnByFieldName("% de Descuento").DisplayFormat.FormatString = "{0:n0} %"

            bgvDevolucionesClientes.Columns(" ").OptionsColumn.Printable = DefaultBoolean.False

            SumarColumnas("CantCG", "{0:N0}")
            SumarColumnas("Cajas", "{0:N0}")
            SumarColumnas("Cantidad", "{0:N0}")
            SumarColumnas("Total", "{0:N2}")
            SumarColumnas("TotalNC", "{0:N2}")
            SumarColumnas("Importe Total", "{0:N2}")


            'bgvDocumentos.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'bgvDocumentos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'bgvDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            'bgvDocumentos.Columns.ColumnByFieldName("F Captura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            'bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            bgvDevolucionesClientes.Columns.ColumnByFieldName("St").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Tipo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Cliente").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Rs").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FCaptura").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoInicial").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Ubicación").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("MotivoVentas").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FRevisión").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("DestinoProducto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FConclusión").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            'bgvDocumentos.Columns.ColumnByFieldName("Cancelados").DisplayFormat.FormatString = "N0"
            'bgvDocumentos.Columns.ColumnByFieldName("Total").DisplayFormat.FormatString = "N0"
            'bgvDocumentos.Columns.ColumnByFieldName("Monto").DisplayFormat.FormatString = "N2"

            'bgvDocumentos.Columns.ColumnByFieldName("Cliente").OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList


            'bgvDocumentos.Columns.ColumnByFieldName("F Captura").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            'bgvDocumentos.Columns.ColumnByFieldName("F Cancelación").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

            bgvDevolucionesClientes.IndicatorWidth = 40

            'bgvDocumentos.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

            bgvDevolucionesClientes.BestFitColumns()
            bgvDevolucionesClientes.Columns.ColumnByFieldName("St").Width = 20
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Rs").Width = 20
            bgvDevolucionesClientes.Columns.ColumnByFieldName("Documento").Width = 200
            bgvDevolucionesClientes.Columns.ColumnByFieldName("FolioNC").Width = 200
            bgvDevolucionesClientes.Columns.ColumnByFieldName("DoctoDeAplicaciónNC").Width = 200

            bgvDevolucionesClientes.Columns("NúmGuia").Width = 80
            bgvDevolucionesClientes.Columns("ObservacionesAlmacén").Width = 180
            bgvDevolucionesClientes.Columns("ObservacionesVentas").Width = 180
            bgvDevolucionesClientes.Columns("ObservacionFacturas").Visible = False
        Catch ex As Exception
            ventanaError.mensaje = ex.Message
            ventanaError.ShowDialog()
        End Try
    End Sub

    Public Sub DisenoGridFiltros(grid As UltraGrid, titulo As String)
        With grid.DisplayLayout.Bands(0)
            If .Columns.Count = 1 Then
                .Columns(0).Header.Caption = titulo
            End If
        End With

        With grid.DisplayLayout
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 35
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowRowFiltering = DefaultableBoolean.False
            .Override.AllowAddNew = AllowAddNew.No
            .Override.AllowUpdate = DefaultableBoolean.False
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.None
            .Override.SelectTypeRow = SelectType.Single
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

        If grid.DisplayLayout.Bands(0).Columns.Exists(" ") Then
            grid.DisplayLayout.Bands(0).Columns(" ").Hidden = True
        End If

        If grid.DisplayLayout.Bands(0).Columns.Exists("Parámetro") Then
            grid.DisplayLayout.Bands(0).Columns("Parámetro").Hidden = True
        End If

    End Sub

    Public Sub GenerarObjetoFiltros()
        objFiltros = New Entidades.FiltroAdministradorDevoluciones
        Dim resolucion As String = ""
        With objFiltros
            .TipoDevolucion = cmbTipoDevolucion.Text
            If rdbFechaRegistro.Checked = True Then
                .FechaRegistroInicio = CDate(dtpFechaInicio.Value)
                .FechaRegistroFin = CDate(dtpFechaFin.Value)
            ElseIf rdbFechaRecepcion.Checked = True Then
                .FechaRecepcionInicio = CDate(dtpFechaInicio.Value)
                .FechaRecepcionFin = CDate(dtpFechaFin.Value)
            ElseIf rdbFechaConclusion.Checked = True Then
                .FechaConclusionInicio = CDate(dtpFechaInicio.Value)
                .FechaConclusionFin = CDate(dtpFechaFin.Value)
            End If

            .CEDIS = cmbCEDIS.SelectedValue
            If cbnotasCredito.Checked = True Then
                objFiltros.ConNotaC = 1
            Else
                objFiltros.ConNotaC = 0
            End If

            If chkPendiente.Checked = True Then
                resolucion += "PENDIENTE"
            End If

            If chkProcede.Checked = True Then
                If resolucion.Length > 0 Then
                    resolucion += ","
                End If
                resolucion += "PROCEDE"
            End If

            If chkNoProcede.Checked = True Then
                If resolucion.Length > 0 Then
                    resolucion += ","
                End If
                resolucion += "NO PROCEDE"
            End If

            If chkAutorizada.Checked = True Then
                If resolucion.Length > 0 Then
                    resolucion += ","
                End If
                resolucion += "PROCEDE (AUTORIZADA)"
            End If

            .Estatus = ObtenerFiltros(grdStatusDev)
            .Resolucion = resolucion
            .FolioDev = ObtenerFiltros(grdFiltroFolioDev)
            .PedidoSAY = ObtenerFiltros(grdFiltroPedidoSAY)
            .PedidoSICY = ObtenerFiltros(grdFiltroPedidoSICY)
            .Documentos = ObtenerFiltros(grdFiltroDocumentos)
            If .Documentos.Trim.Length > 0 Then
                .AñoDocto = numAlmacen.Value
            Else
                .AñoDocto = 0
            End If
            .IdClientes = ObtenerFiltros(grdFiltroCliente)
            .IdAgenteVent = ObtenerFiltros(grdFiltroAgenteVentas)
            .IdAtnClientes = ObtenerFiltros(grdFiltroAtnClientes)
            .Marca = ObtenerFiltros(grdFiltroMarca)
            .Coleccion = ObtenerFiltros(grdFiltroColeccion)
            .Modelo = ObtenerFiltros(grdFiltroModelo)
            .Piel = ObtenerFiltros(grdFiltroPiel)
            .Color = ObtenerFiltros(grdFiltroColor)
            .Corrida = ObtenerFiltros(grdFiltroCorrida)
            If objPermisos.Area = "VENTAS" Or objPermisos.Area = "COBRANZA" Then
                .Vista = "RESUMEN"
            Else
                If rdbVistaResumen.Checked = True Then
                    .Vista = "RESUMEN"
                Else
                    .Vista = "DETALLADA" ' Modificado provicionalmente para mostrar columnas
                End If
            End If

            .Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        End With
    End Sub

    Public Sub PoblarGrid()
        Cursor = Cursors.WaitCursor
        Dim objBU As New Negocios.DevolucionClientesBU
        Dim dtBusqueda As New DataTable

        GenerarObjetoFiltros()
        dtBusqueda = objBU.ConsultarDevoluciones(objFiltros)

        If vistaResumne <> rdbVistaResumen.Checked Then bgvDevolucionesClientes.Columns.Clear()

        grdDevolucionesClientes.DataSource = Nothing
        grdDevolucionesClientes.DataSource = dtBusqueda
        If dtBusqueda.Rows.Count <= 0 Then
            Dim ventanaAdvertencia As New Tools.AdvertenciaForm
            ventanaAdvertencia.mensaje = "No existen registros con los criterios de búsqueda"
            ventanaAdvertencia.ShowDialog()
        End If
        DiseñoGridDevoluciones()
        Label32.Text = DateTime.Now
        lblTotalRegistros.Text = (bgvDevolucionesClientes.DataRowCount).ToString("N0")
        vistaResumne = rdbVistaResumen.Checked
        Cursor = Cursors.Default
    End Sub

    Public Function ConvertirEntero(parametro As Object)
        If IsDBNull(parametro) Then
            Return 0
        Else
            Return parametro
        End If
    End Function

    Public Sub HabilitarInhabilitarComponentes()
        'btnAgregar.Enabled = objPermisos.BtnAgregar
        'btnEditarDev.Enabled = objPermisos.BtnEditar_formAdmin
        'btnIntegrarProducto.Enabled = objPermisos.BtnIntegrarProducto
        'btnEntregarEmbarques.Enabled = objPermisos.BtnEntregaEmbarques
        'btnRecibirEnEmbarques.Enabled = objPermisos.BtnRecibirEnEmbarques
        'btnVerBitacora.Enabled = objPermisos.BtnVerBitacora
        'btnCancelar.Enabled = objPermisos.BtnCancelarDev

        pnlBtnAgregar.Visible = objPermisos.BtnAgregar
        pnlBtnEditar.Visible = objPermisos.BtnEditar_formAdmin
        pnlBtnIntegrarProducto.Visible = objPermisos.BtnIntegrarProducto
        pnlBtnEntregarEmbarques.Visible = objPermisos.BtnEntregaEmbarques
        pnlBtnRecibirEnEmbarques.Visible = objPermisos.BtnRecibirEnEmbarques
        pnlBtnVerBitacora.Visible = objPermisos.BtnVerBitacora
        pnlBtnCancelar.Visible = objPermisos.BtnCancelarDev
        pnlBtnEnviosNave.Visible = objPermisos.BtnEnviosNave
        pnlReportes.Visible = objPermisos.BtnReportes

    End Sub

    Public Sub LimpiarGrids()
        grdFiltroFolioDev.DataSource = New List(Of String)
        grdFiltroPedidoSAY.DataSource = New List(Of String)
        grdFiltroPedidoSICY.DataSource = New List(Of String)
        grdFiltroDocumentos.DataSource = New List(Of String)
        grdFiltroCliente.DataSource = New List(Of String)
        grdFiltroAgenteVentas.DataSource = New List(Of String)
        grdFiltroAtnClientes.DataSource = New List(Of String)
        grdFiltroMarca.DataSource = New List(Of String)
        grdFiltroColeccion.DataSource = New List(Of String)
        grdFiltroModelo.DataSource = New List(Of String)
        grdFiltroPiel.DataSource = New List(Of String)
        grdFiltroColor.DataSource = New List(Of String)
        grdFiltroCorrida.DataSource = New List(Of String)
        grdStatusDev.DataSource = New List(Of String)
    End Sub

    Private Sub DevolucionCliente_AdministradorDC_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        objPermisos = (New Negocios.DevolucionClientesBU).ValidaPermisosPantallas(0, "ADMINISTRADOR", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        dtpFechaInicio.Value = DateSerial(Year(Date.Now), Month(Date.Now), 1)
        LimpiarGrids()

        If cmbCEDIS.Items.Count = 0 Then
            Utilerias.ComboObtenerCEDISUsuario(cmbCEDIS)
        End If


        If objPermisos.Area = "COBRANZA" Or objPermisos.Area = "ALMACÉN" Then
            cbnotasCredito.Visible = True
            cbnotasCredito.Checked = False
        ElseIf objPermisos.Area = "VENTAS" Then
            cbnotasCredito.Visible = False
            cbnotasCredito.Checked = True
        Else
            cbnotasCredito.Visible = False
            cbnotasCredito.Checked = False
        End If

        Dim lista As New List(Of String)
        lista.Add("")
        lista.Add("MAYOREO")
        lista.Add("MENUDEO")
        cmbTipoDevolucion.DataSource = lista
        grdStatusDev.DataSource = (New Negocios.DevolucionClientesBU).ConsultaDatosFiltros("ESTATUS", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)

        dtpFechaInicio.Value = Date.Now.AddMonths(-6)
        dtpFechaInicio.MaxDate = Date.Now

        dtpFechaFin.Value = Date.Now
        dtpFechaFin.MaxDate = Date.Now

        PoblarGrid()

        HabilitarInhabilitarComponentes()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        rdbFechaRegistro.Enabled = chkFecha.Checked
        rdbFechaConclusion.Enabled = chkFecha.Checked
        rdbFechaRecepcion.Enabled = chkFecha.Checked
        dtpFechaFin.Enabled = chkFecha.Checked
        dtpFechaInicio.Enabled = chkFecha.Checked
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim nuevaDevolucion As New DevolucionCliente_CapturaGeneral_Tab_Form
        nuevaDevolucion.edicion = True
        nuevaDevolucion.administrador = True
        nuevaDevolucion.StartPosition = FormStartPosition.CenterParent
        'nuevaDevolucion.CEDIS = cmbCEDIS.SelectedValue
        nuevaDevolucion.ShowDialog()
        PoblarGrid()
    End Sub

    Public Function ValidarSeleccion()
        Dim NumeroFilas = bgvDevolucionesClientes.DataRowCount
        Dim seleccionados As Int16 = 0
        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(bgvDevolucionesClientes.GetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), " ")) = True Then
                seleccionados += 1

                If seleccionados > 1 Then
                    ventanaAdvertencias.mensaje = "Hay más de un registro seleccionado. Esta operación solo se puede realizar con un registro a la vez"
                    ventanaAdvertencias.ShowDialog()
                    Return False
                End If
                indexSeleccionado = index
            End If
        Next

        If seleccionados = 0 Then
            ventanaAdvertencias.mensaje = "Debe seleccionar un registro"
            ventanaAdvertencias.ShowDialog()
            Return False
        End If
        Return True
    End Function

    Private Sub btnVerDetallesArticulos_Click(sender As Object, e As EventArgs) Handles btnVerDetallesArticulos.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            Dim NumeroFilas = bgvDevolucionesClientes.DataRowCount
            Dim idCliente As Integer = 0
            Dim nombreCliente As String = ""
            Dim seleccionados As Integer = 0
            Dim foliosSeleccionados As String = ""
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(bgvDevolucionesClientes.GetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), " ")) = True Then
                    'If idCliente = 0 Then
                    '   idCliente = bgvDevolucionesClientes.GetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), "IdCliente")
                    '   nombreCliente = bgvDevolucionesClientes.GetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), "Cliente")
                    '   indexSeleccionado = index
                    'ElseIf idCliente <> bgvDevolucionesClientes.GetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), "IdCliente") Then
                    '    ventanaAdvertencias.mensaje = "Para ver el detalle de varias devoluciones seleccione registros pertenecientes al mismo cliente"
                    '    ventanaAdvertencias.ShowDialog()
                    '    Return
                    'End If

                    If foliosSeleccionados.ToString.Length > 0 Then
                        foliosSeleccionados += ","
                    End If
                    foliosSeleccionados += bgvDevolucionesClientes.GetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), "FolioSAY").ToString
                    indexSeleccionado = index
                    seleccionados += 1
                End If
            Next

            If seleccionados = 0 Then
                ventanaAdvertencias.mensaje = "Debe seleccionar al menos un registro para ver sus detalles"
                ventanaAdvertencias.ShowDialog()
            Else
                Dim FormDetallesArticulos As New DevolucionCliente_CapturaGeneral_DetallesArticulos
                FormDetallesArticulos.tipoDevolucion = cmbTipoDevolucion.Text
                If seleccionados = 1 Then
                    generarObjetoDevoluciones()
                    FormDetallesArticulos.objDevolucion = objDev
                Else
                    FormDetallesArticulos.variosFolios = True
                    FormDetallesArticulos.FoliosDev = foliosSeleccionados
                    FormDetallesArticulos.objDevolucion.Clienteid = idCliente
                    FormDetallesArticulos.lblFolioDevolucion.Text = "-"
                    FormDetallesArticulos.lblCliente.Text = nombreCliente
                End If

                Try
                    FormDetallesArticulos.StartPosition = FormStartPosition.CenterScreen
                    FormDetallesArticulos.ShowDialog(Me)
                    'PoblarGrid()
                Catch ex As Exception
                    ventanaError.mensaje = "Error: " + ex.Message
                    ventanaError.ShowDialog()
                End Try
            End If
        Else
            ventanaAdvertencias.mensaje = "Debe seleccionar al menos un registro para ver sus detalles"
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Private Sub grdStatusDev_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdStatusDev.InitializeLayout
        DisenoGridFiltros(grdStatusDev, "Estatus")
    End Sub

    Public Function GenerarListaSeleccionados(grid As UltraGrid)
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grid.Rows
            Dim parametro As String = row.Cells("Parámetro").Text
            listaParametroID.Add(parametro)
        Next
        Return listaParametroID
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        PoblarGrid()
        btnArriba_Click(Nothing, Nothing)
    End Sub

    Private Sub txtFiltroFolioDev_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroFolioDev.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroFolioDev.Text) Then Return
            listaFiltroFolios.Add(txtFiltroFolioDev.Text)
            grdFiltroFolioDev.DataSource = Nothing
            grdFiltroFolioDev.DataSource = listaFiltroFolios
            txtFiltroFolioDev.Text = String.Empty
            DisenoGridFiltros(grdFiltroFolioDev, "Folio Dev")
        End If
    End Sub

    Private Sub txtFiltroPedidoSAY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroPedidoSAY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroPedidoSAY.Text) Then Return
            listaFiltroPedidosSay.Add(txtFiltroPedidoSAY.Text)
            grdFiltroPedidoSAY.DataSource = Nothing
            grdFiltroPedidoSAY.DataSource = listaFiltroPedidosSay
            txtFiltroPedidoSAY.Text = String.Empty
            DisenoGridFiltros(grdFiltroPedidoSAY, "PedidoSAY")
        End If
    End Sub

    Private Sub txtFiltroPedidoSICY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroPedidoSICY.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroPedidoSICY.Text) Then Return
            listaFiltroPedidosSicy.Add(txtFiltroPedidoSICY.Text)
            grdFiltroPedidoSICY.DataSource = Nothing
            grdFiltroPedidoSICY.DataSource = listaFiltroPedidosSicy
            txtFiltroPedidoSICY.Text = String.Empty
            DisenoGridFiltros(grdFiltroPedidoSICY, "Pedido SICY")
        End If
    End Sub

    Private Sub txtFiltroDocumentos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroDocumentos.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Or e.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txtFiltroDocumentos.Text) Then Return
            listaFiltroDocumentos.Add(txtFiltroDocumentos.Text)
            grdFiltroDocumentos.DataSource = Nothing
            grdFiltroDocumentos.DataSource = listaFiltroDocumentos
            txtFiltroDocumentos.Text = String.Empty
            DisenoGridFiltros(grdFiltroDocumentos, "Documentos")
        End If
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "CLIENTES"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroCliente)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroCliente, "Cliente")
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns("Clasificación").Hidden = True
            .DisplayLayout.Bands(0).Columns("Ranking").Hidden = True
            .DisplayLayout.Bands(0).Columns("Bloqueado").Hidden = True
        End With
    End Sub

    Private Sub btnAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnAgenteVentas.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "AGENTE_DE_VENTAS"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroAgenteVentas)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroAgenteVentas.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroAgenteVentas, "Agente de Ventas")
    End Sub

    Private Sub btnAtnClientes_Click(sender As Object, e As EventArgs) Handles btnAtnClientes.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "ATENCIÓN_A_CLIENTES"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroAtnClientes)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroAtnClientes.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroAtnClientes, "Atn Clientes")
    End Sub

    Private Sub btnMarca_Click(sender As Object, e As EventArgs) Handles btnMarca.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "MARCAS"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroMarca)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroMarca.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroMarca, "Marca")
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "COLECCIONES"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroColeccion)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroColeccion.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroColeccion, "Colección")
        With grdFiltroColeccion
            .DisplayLayout.Bands(0).Columns("Temporada").Hidden = True
            .DisplayLayout.Bands(0).Columns("Año").Hidden = True
        End With
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "MODELOS"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroModelo)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroModelo.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroModelo, "Modelos")
        With grdFiltroModelo
            .DisplayLayout.Bands(0).Columns("Marca").Hidden = True
            .DisplayLayout.Bands(0).Columns("Colección").Hidden = True
            .DisplayLayout.Bands(0).Columns("Modelo SICY").Hidden = True

        End With
    End Sub

    Private Sub btnPiel_Click(sender As Object, e As EventArgs) Handles btnPiel.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "PIEL"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroPiel)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroPiel.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroPiel, "Piel")
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "COLOR"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroColor)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroColor.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroColor, "Color")
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "CORRIDA"

        listado.listaParametroID = GenerarListaSeleccionados(grdFiltroCorrida)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCorrida.DataSource = listado.listParametros
        DisenoGridFiltros(grdFiltroCorrida, "Corrida")
    End Sub

    Private Sub btnEstatusDev_Click(sender As Object, e As EventArgs) Handles btnEstatusDev.Click
        Dim listado As New DevolucionCliente_AdministradorDC_Parametros_Form
        listado.filtro = "ESTATUS"
        listado.listaParametroID = GenerarListaSeleccionados(grdStatusDev)
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdStatusDev.DataSource = listado.listParametros
        DisenoGridFiltros(grdStatusDev, "Estatus")
    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdFiltroCliente.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarAgenteVentas_Click(sender As Object, e As EventArgs) Handles btnLimpiarAgenteVentas.Click
        grdFiltroAgenteVentas.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarAtnClientes_Click(sender As Object, e As EventArgs) Handles btnLimpiarAtnClientes.Click
        grdFiltroAtnClientes.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarMarca.Click
        grdFiltroMarca.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarColeccion_Click(sender As Object, e As EventArgs) Handles btnLimpiarColeccion.Click
        grdFiltroColeccion.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarModelo_Click(sender As Object, e As EventArgs) Handles btnLimpiarModelo.Click
        grdFiltroModelo.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarPiel_Click(sender As Object, e As EventArgs) Handles btnLimpiarPiel.Click
        grdFiltroPiel.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarColor_Click(sender As Object, e As EventArgs) Handles btnLimpiarColor.Click
        grdFiltroColor.DataSource = New List(Of String)
    End Sub

    Private Sub btnLimpiarCorrida_Click(sender As Object, e As EventArgs) Handles btnLimpiarCorrida.Click
        grdFiltroCorrida.DataSource = New List(Of String)
    End Sub

    Private Sub grdFiltroFolioDev_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroFolioDev.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroPedidoSAY_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroPedidoSAY.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroPedidoSICY_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroPedidoSICY.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroDocumentos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroDocumentos.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroCliente_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroCliente.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroAgenteVentas_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroAgenteVentas.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroCorrida_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroCorrida.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroColor_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroColor.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroPiel_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroPiel.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroModelo_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroModelo.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroColeccion_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroColeccion.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroMarca_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroMarca.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdFiltroAtnClientes_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdFiltroAtnClientes.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub grdStatusDev_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdStatusDev.BeforeRowsDeleted
        e.DisplayPromptMsg = False
    End Sub

    Private Sub GridsFiltros(grid As UltraGrid)
        DisenoGridFiltros(grid, "Folio Dev")
    End Sub

    Private Sub grdFiltroFolioDev_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroFolioDev.InitializeLayout
        DisenoGridFiltros(grdFiltroFolioDev, "Folio Dev")
    End Sub

    Private Sub grdFiltroPedidoSAY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroPedidoSAY.InitializeLayout
        DisenoGridFiltros(grdFiltroPedidoSAY, "Pedidos SAY")
    End Sub

    Private Sub grdFiltroPedidoSICY_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroPedidoSICY.InitializeLayout
        DisenoGridFiltros(grdFiltroPedidoSICY, "Pedidos SICY")
    End Sub

    Private Sub grdFiltroDocumentos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroDocumentos.InitializeLayout
        DisenoGridFiltros(grdFiltroDocumentos, "Documentos")
    End Sub

    Private Sub grdFiltroCliente_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroCliente.InitializeLayout
        DisenoGridFiltros(grdFiltroCliente, "Clientes")
    End Sub

    Private Sub grdFiltroAgenteVentas_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroAgenteVentas.InitializeLayout
        DisenoGridFiltros(grdFiltroAgenteVentas, "Agente Ventas")
    End Sub

    Private Sub grdFiltroAtnClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroAtnClientes.InitializeLayout
        DisenoGridFiltros(grdFiltroAtnClientes, "Atn Clientes")
    End Sub

    Private Sub grdFiltroMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroMarca.InitializeLayout
        DisenoGridFiltros(grdFiltroMarca, "Marca")
    End Sub

    Private Sub grdFiltroColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroColeccion.InitializeLayout
        DisenoGridFiltros(grdFiltroColeccion, "Colección")
    End Sub

    Private Sub grdFiltroModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroModelo.InitializeLayout
        DisenoGridFiltros(grdFiltroModelo, "Modelos")
    End Sub

    Private Sub grdFiltroPiel_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroPiel.InitializeLayout
        DisenoGridFiltros(grdFiltroPiel, "Piel")
    End Sub

    Private Sub grdFiltroColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroColor.InitializeLayout
        DisenoGridFiltros(grdFiltroColor, "Color")
    End Sub

    Private Sub grdFiltroCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFiltroCorrida.InitializeLayout
        DisenoGridFiltros(grdFiltroCorrida, "Corrida")
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 24
        chboxSeleccionarTodo.Visible = True
        pnlParametros.AutoScroll = False
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 323
        pnlParametros.AutoScroll = True
        'chboxSeleccionarTodo.Visible = False
    End Sub

    Public Sub generarObjetoDevoluciones()
        objDev = New Entidades.DevolucionCliente
        Dim formularioEdicion As New DevolucionCliente_CapturaGeneral_Tab_Form

        objDev.Devolucionclienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY")
        objDev.Estatus = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "St")
        objDev.Tipodevolucion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Tipo")
        objDev.Clienteid = CInt(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IdCliente"))
        objDev.NombreCliente = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cliente")
        objDev.UsuarioAtnCte = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioAtnCte")
        objDev.Statusid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "EstatusID")))

        objDev.Resolucion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Rs")
        objDev.Procedeautoriza = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ProcedeAutoriza")
        objDev.Fechacaptura = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FCaptura")
        objDev.Usuariocapturaid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsCapturaID")
        objDev.Usuariocaptura = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsCaptura")
        objDev.Fecharecepcion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FRecepción")
        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FRevisión")) Then
            objDev.Ventas_fechaEnviadoRevision = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FRevisión")
        End If
        objDev.Colaboradorid_recibio = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ColaboradorRecibio")
        objDev.Cantidad_inicial = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CantCG")
        objDev.Unidadid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UnidadID")
        objDev.Unidad = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Unidad")
        objDev.Cajas = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cajas")
        objDev.Motivoinicialalmacen_statusid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IDMotivoInicial")))
        objDev.Motivoinicialalmacen = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "MotivoInicial")
        objDev.DiasProcesamiento = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DProcesamiento")

        objDev.Observaciones_almacen = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ObservacionesAlmacén")
        objDev.Paqueteria_proveedorid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "PaqueteriaID")
        objDev.Tipofleteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Flete")
        objDev.Costopaqueteria = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CostoPaquetería")
        objDev.Numeroguia = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "NúmGuia")
        objDev.Modelos_say = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ModeloSAY")
        objDev.Colores_say = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ColoresSAY")
        objDev.Corridas_say = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CorridasSAY")
        objDev.Almacen_actual_estatusid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UbicaciónAlmacén")))
        objDev.Almacen_usuariomodificaid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioAlmacenModificaID")))
        objDev.Almacen_usuariomodifica = ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioAlmacenModifica"))
        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FModAlmacén")) Then
            objDev.Almacen_fechamodificacion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FModAlmacén")
        End If

        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FLímiteAcción")) Then
            objDev.Fechalimiteaccion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FLímiteAcción")
        End If
        objDev.Dias_transcurridosventas = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DíasTranscurridos")))
        objDev.Indicarecepcion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IndicaRecepción").ToString
        objDev.Motivoventas_statusid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IDMotivoVentas")))
        objDev.Motivoventas = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "MotivoVentas")
        objDev.Destinoproducto = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DestinoProdID").ToString
        objDev.Requiereautorizacion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ReqAutorización")
        objDev.Rutaautorizacion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "RutaAutorización").ToString
        objDev.Aplicanotacredito = IIf(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "AplicaNC") = True, 1, 0)
        objDev.UsuarioSolicitaNCId = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioIdSolicitaNC")))
        objDev.UsuarioSolicitaNC = ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioSolicitaNC"))
        objDev.Responsabledevolucion_estatusid = ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ResponsableDevID"))
        objDev.Observaciones_ventas = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ObservacionesVentas").ToString
        objDev.Ventas_usuariomodificaid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "VentasUsuarioModificaID")))
        objDev.Ventas_usuariomodifica = ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "VentasUsuarioModifica"))
        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "VentasFModificacion")) Then
            objDev.Ventas_fechamodificacion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "VentasFModificacion")
        End If
        objDev.Observaciones_cobranza = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ObservacionesCobranza").ToString
        objDev.Cobranza_usuarioModificaid = CInt(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CobranzaUsuarioModificaID"))
        objDev.Cobranza_usuarioModifica = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CobranzaUsuarioModifica")
        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CobranzaFModificacion")) Then
            objDev.Cobranza_fechaMoficacion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CobranzaFModificacion")
        End If

        objDev.Cantidadtotal = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cantidad")))
        objDev.Total = ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Total"))
        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSICY")) Then
            objDev.Devolucionsicyid = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSICY")))
        End If

        objDev.Cantidad_aplicado = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CantidadAplicada")))
        objDev.Cantidad_poraplicar = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "CantidadPorAplicar")))
        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FConclusión")) Then
            objDev.FechaConclusion = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FConclusión")
        End If

        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Documentos")) Then
            objDev.IdentificadorDocumentos = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Documentos")
        End If

        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DocumentosDetalles")) Then
            objDev.Documentosdetalles = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DocumentosDetalles")
        End If

        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "SinDocumentos")) Then
            objDev.SinDocumentos = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "SinDocumentos")
        End If

        If Not IsDBNull(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Pedidos")) Then
            objDev.PedidosSAY = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Pedidos")
        Else
            objDev.PedidosSAY = ""
        End If

        objDev.UsuarioPasaEmbarquesID = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioPasaEmbarquesID")))
        objDev.UsuarioPasaEmbarques = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioPasaEmbarques")
        objDev.ObservacionFactura = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "ObservacionFacturas")
    End Sub

    Public Sub AbrirVentanaCaptura(edicion As Boolean)
        Try
            Dim formularioEdicion As New DevolucionCliente_CapturaGeneral_Tab_Form
            generarObjetoDevoluciones()
            formularioEdicion.objDev = objDev
            formularioEdicion.edicion = edicion
            formularioEdicion.NuevaDevolucion = False
            formularioEdicion.ShowDialog()
            'PoblarGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub grdDevolucionesClientes_DoubleClick(sender As Object, e As EventArgs) Handles grdDevolucionesClientes.DoubleClick
        'indexSeleccionado = bgvDevolucionesClientes.FocusedRowHandle
        'If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
        '    AbrirVentanaCaptura(False)
        'End If
    End Sub

    Private Sub bgvDevolucionesClientes_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles bgvDevolucionesClientes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub bgvDevolucionesClientes_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles bgvDevolucionesClientes.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)

        If bgvDevolucionesClientes.RowCount <= 0 Or e.RowHandle < 0 Then Return
        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "St" Then
                Dim StatusDev As String = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "St").ToString
                If StatusDev = "ABIERTA" Then
                    e.Appearance.BackColor = pnlEstatusAbierta.BackColor
                    e.Appearance.ForeColor = pnlEstatusAbierta.BackColor
                ElseIf StatusDev = "EN REVISIÓN" Then
                    e.Appearance.BackColor = pnlEstatusEnRevisionVentas.BackColor
                    e.Appearance.ForeColor = pnlEstatusEnRevisionVentas.BackColor
                ElseIf StatusDev = "SOLICITA DOCUMENTOS" Then
                    e.Appearance.BackColor = pnlEstatusSolicitaDoctos.BackColor
                    e.Appearance.ForeColor = pnlEstatusSolicitaDoctos.BackColor
                ElseIf StatusDev = "EN PROCESO" Then
                    e.Appearance.BackColor = pnlEstatusEnProcesoDevsCob.BackColor
                    e.Appearance.ForeColor = pnlEstatusEnProcesoDevsCob.BackColor
                ElseIf StatusDev = "RESUELTA PROCEDE" Then
                    e.Appearance.BackColor = pnlEstatusResuletaProcede.BackColor
                    e.Appearance.ForeColor = pnlEstatusResuletaProcede.BackColor
                ElseIf StatusDev = "RESUELTA NO PROCEDE" Then
                    e.Appearance.BackColor = pnlEstatusResueltaNoProcede.BackColor
                    e.Appearance.ForeColor = pnlEstatusResueltaNoProcede.BackColor
                ElseIf StatusDev = "CANCELADA" Then
                    e.Appearance.BackColor = pnlEstatusCancelada.BackColor
                    e.Appearance.ForeColor = pnlEstatusCancelada.BackColor
                ElseIf StatusDev = "PASAR A EMBARQUES" Then
                    e.Appearance.BackColor = pnlEstatusEntregaEmbarques.BackColor
                    e.Appearance.ForeColor = pnlEstatusEntregaEmbarques.BackColor
                ElseIf StatusDev = "RECIBIDO EN EMBARQUES" Then
                    e.Appearance.BackColor = pnlEstatusRecibidoEnEmbarques.BackColor
                    e.Appearance.ForeColor = pnlEstatusRecibidoEnEmbarques.BackColor
                End If
            ElseIf e.Column.FieldName = "Rs" Then
                Dim ResolucionDev As String = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "Rs").ToString
                If ResolucionDev = "PENDIENTE" Then
                    e.Appearance.BackColor = pnlRsPendiente.BackColor
                    e.Appearance.ForeColor = pnlRsPendiente.BackColor
                ElseIf ResolucionDev = "PROCEDE" Then
                    e.Appearance.BackColor = pnlRsProcede.BackColor
                    e.Appearance.ForeColor = pnlRsProcede.BackColor
                ElseIf ResolucionDev = "NO PROCEDE" Then
                    e.Appearance.BackColor = pnlRsNoProcede.BackColor
                    e.Appearance.ForeColor = pnlRsNoProcede.BackColor
                ElseIf ResolucionDev = "PROCEDE (AUTORIZADA)" Then
                    e.Appearance.BackColor = pnlRsProcedeAutorizada.BackColor
                    e.Appearance.ForeColor = pnlRsProcedeAutorizada.BackColor
                End If
            ElseIf e.Column.FieldName = "Cliente" Then
                Dim fechaCaptura As Date = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FCaptura").ToString
                Dim fechaRevision As Date
                If bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FRevisión").ToString().Length > 0 Then
                    fechaRevision = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FRevisión").ToString()
                Else
                    fechaRevision = Now()
                End If
                Dim diferenciaDias As Int16 = DateDiff(DateInterval.Day, fechaCaptura, fechaRevision)

                If diferenciaDias <= 2 Then
                    e.Appearance.BackColor = pnlOk.BackColor
                ElseIf diferenciaDias >= 3 And diferenciaDias <= 4 Then
                    e.Appearance.BackColor = pnlEnPorVencer.BackColor
                ElseIf diferenciaDias >= 6 Then
                    e.Appearance.BackColor = pnlExcedido.BackColor
                End If
            ElseIf e.Column.FieldName = "FolioSAY" Then
                Dim fechaEnviadoProc As Date
                Dim fechaConclusion As Date

                If bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FSolicitaProcAlmacén").ToString.Length > 0 Then
                    fechaEnviadoProc = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FSolicitaProcAlmacén").ToString
                Else
                    fechaEnviadoProc = Now()
                End If

                If bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FConclusión").ToString().Length > 0 Then
                    fechaConclusion = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "FConclusión").ToString()
                Else
                    fechaConclusion = Now()
                End If
                Dim diferenciaHoras As Int16 = DateDiff(DateInterval.Hour, fechaEnviadoProc, fechaConclusion)

                If diferenciaHoras <= 14 Then
                    e.Appearance.BackColor = pnlOk.BackColor
                ElseIf diferenciaHoras >= 15 And diferenciaHoras <= 23 Then
                    e.Appearance.BackColor = pnlEnPorVencer.BackColor
                ElseIf diferenciaHoras > 24 Then
                    e.Appearance.BackColor = pnlExcedido.BackColor
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            'MsgBox("Error" + ex.Message.ToString())
        End Try
    End Sub

    Private Sub bgvDevolucionesClientes_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles bgvDevolucionesClientes.CustomRowCellEdit
        'If e.Column.FieldName = " " Then
        '    emptyEditor = New RepositoryItem
        '    e.RepositoryItem = emptyEditor
        'End If
    End Sub

    Private Sub btnExportarExcelApartados_Click(sender As Object, e As EventArgs) Handles btnExportarExcelApartados.Click
        If bgvDevolucionesClientes.DataRowCount > 0 Then
            Dim fbdUbicacion As New FolderBrowserDialog
            Dim nombreReporte As String = String.Empty

            Try
                nombreReporte = "\Devoluciones_Clientes"
                With fbdUbicacion
                    .Reset()
                    .Description = "Selecciona una carpeta"
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        Dim exportOptions As New XlsxExportOptionsEx()
                        exportOptions.ExportType = ExportType.DataAware
                        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                        grdDevolucionesClientes.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

                        ventanaExito.mensaje = "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx"
                        ventanaExito.ShowDialog()
                        Process.Start(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If

                End With
            Catch ex As Exception
                ventanaError.mensaje = "Ocurrió un error: " + ex.Message.ToString
                ventanaError.ShowDialog()
            End Try
        Else
            ventanaAdvertencias.mensaje = "No hay datos para exportar"
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal e As CustomizeCellEventArgs)
        Try
            If e.ColumnFieldName = "St" Then
                Dim StatusDev As String = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "St").ToString
                If StatusDev = "ABIERTA" Then
                    e.Formatting.BackColor = pnlEstatusAbierta.BackColor
                    e.Formatting.Font.Color = pnlEstatusAbierta.BackColor
                ElseIf StatusDev = "EN REVISIÓN" Then
                    e.Formatting.BackColor = pnlEstatusEnRevisionVentas.BackColor
                    e.Formatting.Font.Color = pnlEstatusEnRevisionVentas.BackColor
                ElseIf StatusDev = "SOLICITA DOCUMENTOS" Then
                    e.Formatting.BackColor = pnlEstatusSolicitaDoctos.BackColor
                    e.Formatting.Font.Color = pnlEstatusSolicitaDoctos.BackColor
                ElseIf StatusDev = "EN PROCESO" Then
                    e.Formatting.BackColor = pnlEstatusEnProcesoDevsCob.BackColor
                    e.Formatting.Font.Color = pnlEstatusEnProcesoDevsCob.BackColor
                ElseIf StatusDev = "RESUELTA PROCEDE" Then
                    e.Formatting.BackColor = pnlEstatusResuletaProcede.BackColor
                    e.Formatting.Font.Color = pnlEstatusResuletaProcede.BackColor
                ElseIf StatusDev = "RESUELTA NO PROCEDE" Then
                    e.Formatting.BackColor = pnlEstatusResueltaNoProcede.BackColor
                    e.Formatting.Font.Color = pnlEstatusResueltaNoProcede.BackColor
                ElseIf StatusDev = "CANCELADA" Then
                    e.Formatting.BackColor = pnlEstatusCancelada.BackColor
                    e.Formatting.Font.Color = pnlEstatusCancelada.BackColor
                ElseIf StatusDev = "PASAR A EMBARQUES" Then
                    e.Formatting.BackColor = pnlEstatusEntregaEmbarques.BackColor
                    e.Formatting.Font.Color = pnlEstatusEntregaEmbarques.BackColor
                ElseIf StatusDev = "RECIBIDO EN EMBARQUES" Then
                    e.Formatting.BackColor = pnlEstatusRecibidoEnEmbarques.BackColor
                    e.Formatting.Font.Color = pnlEstatusRecibidoEnEmbarques.BackColor
                End If
            ElseIf e.ColumnFieldName = "Rs" Then
                Dim ResolucionDev As String = bgvDevolucionesClientes.GetRowCellValue(e.RowHandle, "Rs").ToString
                If ResolucionDev = "PENDIENTE" Then
                    e.Formatting.BackColor = pnlRsPendiente.BackColor
                    e.Formatting.Font.Color = pnlRsPendiente.BackColor
                ElseIf ResolucionDev = "PROCEDE" Then
                    e.Formatting.BackColor = pnlRsProcede.BackColor
                    e.Formatting.Font.Color = pnlRsProcede.BackColor
                ElseIf ResolucionDev = "NO PROCEDE" Then
                    e.Formatting.BackColor = pnlRsNoProcede.BackColor
                    e.Formatting.Font.Color = pnlRsNoProcede.BackColor
                ElseIf ResolucionDev = "PROCEDE (AUTORIZADA)" Then
                    e.Formatting.BackColor = pnlRsProcedeAutorizada.BackColor
                    e.Formatting.Font.Color = pnlRsProcedeAutorizada.BackColor
                End If
            End If

        Catch ex As Exception
            Cursor = Cursors.Default
            'MsgBox("Error" + ex.Message.ToString())
        End Try
        e.Handled = True
    End Sub

    Private Sub btnEditarDev_Click(sender As Object, e As EventArgs) Handles btnEditarDev.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            AbrirVentanaCaptura(True)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdDevolucionesClientes.DataSource = Nothing
        LimpiarGrids()
    End Sub

    Private Sub bgvDevolucionesClientes_ColumnFilterChanged(sender As Object, e As EventArgs) Handles bgvDevolucionesClientes.ColumnFilterChanged
        lblTotalRegistros.Text = bgvDevolucionesClientes.DataRowCount.ToString("N0")
    End Sub

    Private Sub btnVerBitacora_Click(sender As Object, e As EventArgs) Handles btnVerBitacora.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            objDev = New Entidades.DevolucionCliente With {
                .Devolucionclienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY"),
                .NombreCliente = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cliente"),
                .Clienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IdCliente")
            }

            Dim formBitacora As New DevolucionCliente_CapturaGeneral_BitacoraDev_Form
            formBitacora.objDev = objDev
            formBitacora.StartPosition = FormStartPosition.CenterScreen
            formBitacora.ShowDialog()

        End If
    End Sub

    Private Sub btnEntregarEmbarques_Click(sender As Object, e As EventArgs) Handles btnEntregarEmbarques.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            If bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "EstatusID") = 353 Then
                ventanaAdvertencias.mensaje = "El producto ya se encuentra entregado a embarques. Solicite al personal del área la recepción del mismo en el sistema."
                ventanaAdvertencias.ShowDialog()
                Return
            ElseIf bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "EstatusID") <> 305 Then
                ventanaAdvertencias.mensaje = "Solamente se pueden entregar a embarques las devoluciones con Status de 'EN PROCESO'"
                ventanaAdvertencias.ShowDialog()
                Return
            End If

            If bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DestinoProducto") = "ENTREGA (REFACTURAR)" Or bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DestinoProducto") = "RE-ENTREGA (MISMOS DOCUMENTOS)" Then
                ventanaConfirmacion.mensaje = "El producto se entregará a Embarques " + vbCrLf + "¿Desea continuar?" + vbCr + "(Solicite al personal del área la recepción del mismo en el sistema)"
                ventanaConfirmacion.ShowDialog()
                If ventanaConfirmacion.DialogResult <> DialogResult.OK Then Return
                Dim negocios As New Negocios.DevolucionClientesBU
                negocios.CambiarEstatusDevolucion(CInt(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY")), 353, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, objPermisos.Area)
                PoblarGrid()
            Else
                ventanaAdvertencias.mensaje = "No se puede entregar el producto a embarques debido a que el destino indicado por ventas requiere integrar el producto a Stock (" + bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DestinoProducto").ToString + ")"
                ventanaAdvertencias.ShowDialog()
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            Dim estatusID As Int64 = CInt(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "EstatusID"))
            Dim TipoDev As String = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Tipo")

            If estatusID = 308 Then
                ventanaAdvertencias.mensaje = "La devolución ya se encuentra cancelada"
                ventanaAdvertencias.ShowDialog()
                Return
            ElseIf estatusID <> 303 And estatusID <> 304 And estatusID <> 331 Then
                If TipoDev <> "MENUDEO" Then
                    ventanaAdvertencias.mensaje = "Solo se pueden cancelar devoluciones en estatus de: " + vbCrLf + "* ABIERTA" + vbCrLf + "* SOLICITA DOCUMENTOS" + vbCrLf + "* EN REVISIÓN"
                    ventanaAdvertencias.ShowDialog()
                    Return
                End If
            End If
            'JJGH, Agregue la validación para saber si el folio de DEV es de MENUDEO, que si permita cancelar la devolución.
            objDev = New Entidades.DevolucionCliente With {
                .Devolucionclienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY"),
                .NombreCliente = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cliente"),
                .Clienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IdCliente"),
                .Cantidadtotal = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cantidad")
            }

            Dim formCancelar As New DevolucionCliente_CancelarDevolucion_Form

            formCancelar.ObjDev = objDev
            formCancelar.StartPosition = FormStartPosition.CenterScreen
            formCancelar.ShowDialog()
            PoblarGrid()
        Else
            ventanaAdvertencias.mensaje = "Debe seleccionar un registro"
            ventanaAdvertencias.ShowDialog()
        End If
    End Sub

    Private Sub btnIntegrarProducto_Click(sender As Object, e As EventArgs) Handles btnIntegrarProducto.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return

            If bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "EstatusID") <> 305 Then
                ventanaAdvertencias.mensaje = "Solamente se puede integrar el producto de las devoluciones con Status de 'EN PROCESO'"
                ventanaAdvertencias.ShowDialog()
                Return
            End If

            If bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DestinoProdID") = 340 Then
                ventanaAdvertencias.mensaje = "El destino del producto indicado por ventas no aplica para integrar al inventario"
                ventanaAdvertencias.ShowDialog()
                Return
            End If

            objDev = New Entidades.DevolucionCliente With {
                .Devolucionclienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY"),
                .NombreCliente = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cliente"),
                .Clienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IdCliente"),
                .Cantidadtotal = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cantidad"),
                .Unidad = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Unidad"),
                .Destinoproducto = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "DestinoProducto"),
                .UsuarioGeneraLote = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioIngresaLote"),
                .LoteGenerado = CBool(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "LoteGenerados"))
            }


            '.FechaGeneraLote = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FechaGeneraLote"),

            Dim formIngresos As New DevolucionCliente_GenerarParesAGranel_Form

            formIngresos.objDev = objDev
            formIngresos.StartPosition = FormStartPosition.CenterScreen
            formIngresos.MdiParent = Me.MdiParent
            formIngresos.Show()
            PoblarGrid()
        Else
            ventanaAdvertencias.mensaje = "Debe seleccionar un registro"
            ventanaAdvertencias.ShowDialog()
        End If

    End Sub

    Private Sub btnRecibirEnEmbarques_Click(sender As Object, e As EventArgs) Handles btnRecibirEnEmbarques.Click
        If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
            If ValidarSeleccion() = False Then Return
            If bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "EstatusID") <> 353 Then
                ventanaAdvertencias.mensaje = "Solamente se pueden recibir los registros con estatus 'PASAR A EMBARQUES'"
                ventanaAdvertencias.ShowDialog()
                Return
            End If

            objDev = New Entidades.DevolucionCliente With {
                .Devolucionclienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY"),
                .NombreCliente = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cliente"),
                .Clienteid = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "IdCliente"),
                .Cantidadtotal = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Cantidad"),
                .Unidad = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "Unidad"),
                .UsuarioPasaEmbarques = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioPasaEmbarques"),
                .UsuarioIDGeneraLote = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioIDIngresaLote"),
                .UsuarioGeneraLote = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioIngresaLote"),
                .LoteGenerado = CBool(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "LoteGenerados")),
                .UsuarioPasaEmbarquesID = objDev.UsuarioPasaEmbarquesID = CInt(ConvertirEntero(bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "UsuarioPasaEmbarquesID")))
            }

            Dim formEntregaEmbarques As New DevolucionCliente_EntregaAEmbarques_Form
            formEntregaEmbarques.objDev = objDev
            formEntregaEmbarques.StartPosition = FormStartPosition.CenterScreen
            formEntregaEmbarques.ShowDialog()
            PoblarGrid()
        End If
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas = bgvDevolucionesClientes.DataRowCount
        If NumeroFilas = 0 Then Return

        If chboxSeleccionarTodo.Checked = True Then
            'Dim seleccionados As Int16 = 0
            For index As Integer = 0 To NumeroFilas Step 1
                bgvDevolucionesClientes.SetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), " ", True)
            Next
        Else
            'Dim seleccionados As Int16 = 0
            For index As Integer = 0 To NumeroFilas Step 1
                bgvDevolucionesClientes.SetRowCellValue(bgvDevolucionesClientes.GetVisibleRowHandle(index), " ", False)
            Next
        End If
    End Sub

    Private Sub btnEnviosNave_Click(sender As Object, e As EventArgs) Handles btnEnviosNave.Click
        Dim formEnvios As New DevolucionCliente_EntradaSalida_Naves_Administrador
        formEnvios.MdiParent = Me.MdiParent
        formEnvios.Show()
        Me.Close()
        'Dim form As New Consultas_Async
        'form.ShowDialog()
    End Sub

    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        Dim frmReportes As New DevolucionCliente_Reportes_Form
        frmReportes.MdiParent = Me.MdiParent
        frmReportes.Show()
    End Sub

    Private Sub bgvDevolucionesClientes_DoubleClick(sender As Object, e As EventArgs) Handles bgvDevolucionesClientes.DoubleClick
        Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
        Dim view As GridView = TryCast(sender, GridView)
        Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
        If info.InRow OrElse info.InRowCell Then
            indexSeleccionado = info.RowHandle
            Dim colCaption As String = If(info.Column Is Nothing, "N/A", info.Column.GetCaption())
            If colCaption = "Documento" Then
                Dim formDetallesDoctos = New DevolucionCliente_DetallesDocumentosSeleccionados_Form
                formDetallesDoctos.FolioDev = bgvDevolucionesClientes.GetRowCellValue(indexSeleccionado, "FolioSAY")
                formDetallesDoctos.StartPosition = FormStartPosition.CenterScreen
                formDetallesDoctos.ShowDialog()
            Else
                'indexSeleccionado = bgvDevolucionesClientes.FocusedRowHandle
                If bgvDevolucionesClientes.SelectedRowsCount > 0 Then
                    AbrirVentanaCaptura(False)
                End If
            End If
        End If
    End Sub
End Class