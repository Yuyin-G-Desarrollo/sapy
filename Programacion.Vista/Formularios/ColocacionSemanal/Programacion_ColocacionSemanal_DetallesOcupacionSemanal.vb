Imports DevExpress.Export
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools
Imports Tools.modMensajes

Public Class Programacion_ColocacionSemanal_DetallesOcupacionSemanal
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Public Año As Integer = 0
    Public listaNaves As New List(Of Integer)
    Public listaSemanas As New List(Of String)
    Public accion As Integer = 0
    Dim listaIndicesMarcados As New List(Of Integer)
    Dim eventoActivo As Boolean = False
    Dim dtSemanasConPlanAutorizado As DataTable
    Dim listaSemanasConPlanAutorizadoSeleccionadas As List(Of Integer)
    Dim paresMoverGlobal As Integer = 0
    Dim seleccionarTodo As Boolean = False
    Public tablaDetalles As New DataTable
    Dim listaRegistrosSeleccionados As New List(Of Integer)
    Public ventanaPrincipal As Programacion_ColocacionSemanal_MapaOcupacionForm = Nothing
    Dim Bitacora As Integer = 0
    Dim inicioCheck As Boolean = False
    Public ConsultaFiltros As Boolean = False

    Public FNave As String = String.Empty
    Public FCliente As String = String.Empty
    Public FPedidoSAY As String = String.Empty
    Public FPedidoSICY As String = String.Empty
    Public FMarca As String = String.Empty
    Public FColeccion As String = String.Empty
    Public FPiel As String = String.Empty
    Public FColor As String = String.Empty
    Public FCorrida As String = String.Empty
    Public FFamiliaV As String = String.Empty
    Public FTemporada As String = String.Empty
    Public FiltroFecha As Integer = 0
    Public FechaInicio As Date = Nothing
    Public FechaFin As Date = Nothing

    Dim Apartados As Boolean = False

#Region "PRIVATE METHODS"
    Private Sub disenoGrid()
        If accion = 1 Then vwReporte.OptionsView.ColumnAutoWidth = True 'Bitacora de errores

        'vwReporte.OptionsView.EnableAppearanceEvenRow = True
        'vwReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        vwReporte.IndicatorWidth = 40
        vwReporte.OptionsView.ShowAutoFilterRow = True
        'vwReporte.OptionsView.RowAutoHeight = True
        vwReporte.OptionsClipboard.AllowCopy = True


        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

            If col.FieldName <> " " And col.FieldName.Contains("ParesMover") = False Then col.OptionsColumn.AllowEdit = False
            If col.FieldName.Contains("(SUM)") Then
                col.Caption = col.FieldName.Replace("(SUM)", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
            If col.FieldName.Contains("ParesColocados") Then
                col.Caption = col.FieldName.Replace("ParesColocados", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
            If col.FieldName.Contains("ParesPartida") Then
                col.Caption = col.FieldName.Replace("ParesPartida", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
            If col.FieldName.Contains("ParesMover") Then
                col.Caption = col.FieldName.Replace("ParesMover", "")
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
            'If col.FieldName.Contains("Pares") Then
            '    col.Caption = col.FieldName.Replace("ParesMover", "")
            '    col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            'End If
        Next


        vwReporte.Columns.ColumnByFieldName(" ").OptionsFilter.AllowAutoFilter = False
        vwReporte.Columns.ColumnByFieldName("Renglon").Visible = False

        If accion = 0 Then 'Consultar detalle de Semana
            vwReporte.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False
            vwReporte.Columns.ColumnByFieldName("OcupacionSemanaSetalleId").Visible = False
            vwReporte.Columns.ColumnByFieldName("NaveId").Visible = False
            vwReporte.Columns.ColumnByFieldName("SemanaOriginal").Visible = False
            vwReporte.Columns.ColumnByFieldName("NaveIdOriginal").Visible = False
            vwReporte.Columns.ColumnByFieldName("Captura").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            vwReporte.Columns.ColumnByFieldName("Captura").DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss"
            vwReporte.Columns.ColumnByFieldName("Confirmación").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            vwReporte.Columns.ColumnByFieldName("Confirmación").DisplayFormat.FormatString = "yyyy-MM-dd hh:mm:ss"
            vwReporte.Columns.ColumnByFieldName("ParesMover").Visible = False
            vwReporte.Columns.ColumnByFieldName("Semana").Visible = False
            vwReporte.Columns.ColumnByFieldName("Abierta").Visible = False

            vwReporte.Columns.ColumnByFieldName("PedidoSAY").Caption = "Pedido" + vbCrLf + "SAY"
            vwReporte.Columns.ColumnByFieldName("PedidoSICY").Caption = "Pedido" + vbCrLf + "SICY"
            vwReporte.Columns.ColumnByFieldName("ParesPartida").Caption = "Pares" + vbCrLf + "Partida"
            vwReporte.Columns.ColumnByFieldName("ParesColocados").Caption = "Pares" + vbCrLf + "Colocados"
            vwReporte.Columns.ColumnByFieldName("ParesPartida").Caption = "Pares" + vbCrLf + "Partida"
            vwReporte.Columns.ColumnByFieldName("NavePrograma").Caption = "Nave" + vbCrLf + "Programa"
            vwReporte.Columns.ColumnByFieldName("FechaEntrega").Caption = "Fecha " + vbCrLf + "Entrega"
            vwReporte.Columns.ColumnByFieldName("Sem FEntrega").Caption = "F Entrega" + vbCrLf + "Sem"
            vwReporte.Columns.ColumnByFieldName("Sem FCaptura").Caption = "F Captura" + vbCrLf + "Sem"
            vwReporte.Columns.ColumnByFieldName("Sem FConfirmación").Caption = "F Confirma" + vbCrLf + "Sem"
            vwReporte.Columns.ColumnByFieldName("Sem FEntrega C").Caption = "F Entrega" + vbCrLf + "Cliente Sem"
            vwReporte.Columns.ColumnByFieldName("Modelo SAY").Caption = "Modelo" + vbCrLf + "SAY"
            vwReporte.Columns.ColumnByFieldName("PielColor").Caption = "Piel" + vbCrLf + "Color"
            vwReporte.Columns.ColumnByFieldName("NavesAsignadas").Caption = "Naves" + vbCrLf + "Asignadas"
            vwReporte.Columns.ColumnByFieldName("Modelo SICY").Caption = "Modelo" + vbCrLf + "SICY"
            vwReporte.Columns.ColumnByFieldName("EntregaCliente").Caption = "Entrega" + vbCrLf + "Cliente"


            vwReporte.BestFitColumns()

        ElseIf accion = 1 Then 'Bitácora de Errores
            vwReporte.Columns.ColumnByFieldName("ProductoEstiloId").Visible = False
            vwReporte.Columns.ColumnByFieldName("IdUsuarioCreo").Visible = False
            vwReporte.Columns.ColumnByFieldName(" ").Width = 20
            vwReporte.Columns.ColumnByFieldName("PedidoSay").Width = 40
            vwReporte.Columns.ColumnByFieldName("Partida").Width = 35
            vwReporte.Columns.ColumnByFieldName("Pares(SUM)").Width = 35
            vwReporte.Columns.ColumnByFieldName("Colección").Width = 100
            vwReporte.Columns.ColumnByFieldName("ModeloSAY").Width = 40
            vwReporte.Columns.ColumnByFieldName("ModeloSICY").Width = 40
            vwReporte.Columns.ColumnByFieldName("Color").Width = 70
            vwReporte.Columns.ColumnByFieldName("Talla").Width = 40
            vwReporte.Columns.ColumnByFieldName("UsuarioCreo").Width = 60
            vwReporte.Columns.ColumnByFieldName("Error").Width = 150
            vwReporte.Columns.ColumnByFieldName("Apartado").Width = 50
            vwReporte.Columns.ColumnByFieldName("Pares Cancelados").Width = 50
            vwReporte.Columns.ColumnByFieldName("Fecha").Width = 50
            vwReporte.Columns.ColumnByFieldName("Prioridades").Width = 100
            vwReporte.Columns.ColumnByFieldName("FechaEntrega").Width = 60
            vwReporte.Columns.ColumnByFieldName("Sem FEntrega").Width = 40
            vwReporte.Columns.ColumnByFieldName("FechaEntrega").Caption = "Fecha " + vbCrLf + "Entrega"
            vwReporte.Columns.ColumnByFieldName("Sem FEntrega").Caption = "F Entrega" + vbCrLf + "Sem"
        End If
        'vwReporte.BestFitColumns()
    End Sub

    Private Function filasModificadas() As List(Of Integer)
        Dim listaFilasModificadas As New List(Of Integer)
        paresMoverGlobal = 0

        AddHandler vwReporte.RowCellStyle, AddressOf vwReporte_RowCellStyle

        Dim NumeroFilas As Integer = vwReporte.DataRowCount
        Try
            With vwReporte
                For index As Integer = 0 To NumeroFilas Step 1
                    Dim semana As String = .GetRowCellValue(index, "Semana")
                    Dim naveId As Integer = .GetRowCellValue(index, "NaveId")
                    Dim semanaOriginal As String = .GetRowCellValue(index, "SemanaOriginal")
                    Dim naveIdOriginal As Integer = .GetRowCellValue(index, "NaveIdOriginal")
                    Dim estaAbierta As Boolean = .GetRowCellValue(index, "Abierta")

                    listaSemanasConPlanAutorizadoSeleccionadas = New List(Of Integer)

                    If estaAbierta Then
                        If semana <> semanaOriginal Or naveId <> naveIdOriginal Then
                            If verificarSemanasPlanAutorizado(semana, naveId) = False Then

                                If IsDBNull(.GetRowCellValue(index, "ParesMover")) = False Then
                                    If .GetRowCellValue(index, "ParesMover").ToString <> "" And .GetRowCellValue(index, "ParesMover") <> "0" Then
                                        listaFilasModificadas.Add(.GetRowCellValue(index, "Renglon"))
                                        paresMoverGlobal += .GetRowCellValue(index, "ParesMover")
                                    End If
                                End If
                            Else
                                listaSemanasConPlanAutorizadoSeleccionadas.Add(.GetRowCellValue(index, "Renglon"))
                            End If
                        End If
                    End If
                Next
            End With
        Catch ex As Exception

        End Try

        Return listaFilasModificadas
    End Function

    Private Function generarXMLApartados()
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Dim NumeroFilas As Integer = vwReporte.DataRowCount

        With vwReporte
            For index As Integer = 0 To NumeroFilas Step 1
                If .GetRowCellValue(index, " ") Then
                    Dim vNodo As XElement = New XElement("Celda")
                    vNodo.Add(New XAttribute("ProductoEstiloId", vwReporte.GetRowCellValue(index, "ProductoEstiloId")))
                    vNodo.Add(New XAttribute("Partida", vwReporte.GetRowCellValue(index, "Partida")))
                    vNodo.Add(New XAttribute("PedidoSay", vwReporte.GetRowCellValue(index, "PedidoSay")))
                    'vNodo.Add(New XAttribute("PedidoSay", vwReporte.GetRowCellValue(index, "PedidoSay")))
                    vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                    If cmbNave.SelectedIndex <> 0 Then
                        vNodo.Add(New XAttribute("NuevaNave", cmbNave.SelectedValue)) 'Modificar este valor, siempre debe escoger la nave
                    Else
                        objAdvertencia.mensaje = "Seleccione una nave."
                        objAdvertencia.ShowDialog()
                        Return vXmlCeldasModificadas
                        Exit Function
                    End If
                    vNodo.Add(New XAttribute("NuevaSemana", nudSemanaInicio.Value))
                    vNodo.Add(New XAttribute("NuevoAño", nudAño.Value))
                    vNodo.Add(New XAttribute("ParesMover", vwReporte.GetRowCellValue(index, "Pares(SUM)")))
                    vNodo.Add(New XAttribute("Apartado", vwReporte.GetRowCellValue(index, "Apartado")))

                    vXmlCeldasModificadas.Add(vNodo)
                End If
            Next
        End With

        Return vXmlCeldasModificadas

    End Function

    Private Function generarXML(ByVal listaFilaModificadas As List(Of Integer))
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Dim NumeroFilas As Integer = vwReporte.DataRowCount

        With vwReporte
            For index As Integer = 0 To NumeroFilas Step 1
                If .GetRowCellValue(index, " ") Then
                    If listaFilaModificadas.Contains(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Renglon"))) Then
                        Dim vNodo As XElement = New XElement("Celda")
                        Dim particiones = vwReporte.GetRowCellValue(index, "Semana").ToString.Split(New Char() {"-"c})
                        Dim semana = Integer.Parse(particiones(0))
                        Dim año = Integer.Parse(particiones(1))
                        vNodo.Add(New XAttribute("OcupacionSemanaSetalleId", vwReporte.GetRowCellValue(index, "OcupacionSemanaSetalleId")))
                        vNodo.Add(New XAttribute("ProductoEstiloId", vwReporte.GetRowCellValue(index, "ProductoEstiloId")))
                        vNodo.Add(New XAttribute("Semana", vwReporte.GetRowCellValue(index, "SemanaOriginal")))
                        vNodo.Add(New XAttribute("Partida", vwReporte.GetRowCellValue(index, "Partida")))
                        vNodo.Add(New XAttribute("PedidoSAY", vwReporte.GetRowCellValue(index, "PedidoSAY")))
                        vNodo.Add(New XAttribute("NaveId", vwReporte.GetRowCellValue(index, "NaveIdOriginal")))

                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("NuevaNave", vwReporte.GetRowCellValue(index, "NaveId")))
                        vNodo.Add(New XAttribute("NuevaSemana", semana))
                        vNodo.Add(New XAttribute("NuevoAño", año))
                        vNodo.Add(New XAttribute("ParesMover", vwReporte.GetRowCellValue(index, "ParesMover")))
                        vXmlCeldasModificadas.Add(vNodo)
                    End If
                End If
            Next
        End With



        Return vXmlCeldasModificadas

    End Function

    Private Function filasSeleccionadas() As List(Of Integer)
        Dim listaFilasSeleccionadas As New List(Of Integer)
        For i = 0 To vwReporte.RowCount - 1 Step 1
            If vwReporte.GetRowCellValue(i, " ") Then listaFilasSeleccionadas.Add(i)
        Next
        Return listaFilasSeleccionadas
    End Function

#End Region
    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)
        If (e.RowHandle Mod 2 > 0) Then
            e.Formatting.BackColor = Color.LightSteelBlue
        End If
        e.Handled = True
    End Sub

    Private Sub validarChecksGrid(Optional evento As Boolean = True, Optional linea As Integer = -1, Optional asiContantitaPena As Boolean = True)
        RemoveHandler vwReporte.RowCellStyle, AddressOf vwReporte_RowCellStyle

        Dim pares As Integer = 0
        Dim paresN As Integer = 0
        Dim total As Integer = CInt(lblNumFiltrados.Text)

        Dim listaSemanas As New List(Of Integer)
        listaIndicesMarcados = New List(Of Integer)

        Dim NumeroFilas As Integer = vwReporte.DataRowCount


        If inicioCheck Then
            With vwReporte
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        If evento Then
                            pares = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(linea), ("ParesColocados"))
                            listaSemanas.Add(Integer.Parse(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                        Else
                            pares += vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("ParesColocados"))
                            listaSemanas.Add(Integer.Parse(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                        End If
                        listaIndicesMarcados.Add(1)
                        vwReporte.SetRowCellValue(index, "ParesMover", vwReporte.GetRowCellValue(index, "ParesColocados"))
                        listaRegistrosSeleccionados.Add(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Renglon")))
                    Else
                        If evento = False Then
                            paresN = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(linea), ("ParesColocados"))
                        End If
                        vwReporte.SetRowCellValue(index, "ParesMover", 0)
                        listaRegistrosSeleccionados.Remove(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Renglon")))
                    End If
                Next
            End With
        Else

            With vwReporte
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        If evento Then
                            If accion = 1 Then
                                pares += vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Pares(SUM)"))
                                listaSemanas.Add(Integer.Parse(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Sem FEntrega")).ToString))
                            Else
                                pares = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(linea), ("ParesColocados"))
                                listaSemanas.Add(Integer.Parse(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                            End If
                        Else
                            If accion = 1 Then
                                pares += vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Pares(SUM)"))
                                listaSemanas.Add(Integer.Parse(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Sem FEntrega")).ToString))
                            Else
                                pares += vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("ParesColocados"))
                                listaSemanas.Add(Integer.Parse(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                            End If
                        End If
                    Else
                        If evento = False Then
                            If accion = 1 Then
                                paresN = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(linea), ("Pares(SUM)"))
                            Else
                                paresN = vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(linea), ("ParesColocados"))
                            End If
                        End If
                    End If
                Next
            End With
        End If

        If asiContantitaPena Then
            If evento Then
                total += pares
            ElseIf evento = False And linea = -1 Then
                total += pares
            Else
                total -= paresN
            End If
        End If

        lblNumFiltrados.Text = If(total >= 1000, total.ToString("##,###"), total)
        lblNumSemanas.Text = listaSemanas.AsEnumerable.Distinct.Count

    End Sub

    Private Sub btnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
        If filasSeleccionadas.Count > 0 Then


            If Bitacora = 1 Then

                btnAsignar.Visible = False
                Label4.Visible = False
                btnGuardar.Visible = True
                lblGuardar.Visible = True
                lblGuardar.Enabled = True
                btnGuardar.Enabled = False 'Se habilita hasta que se va a mover el apartado. 


                Dim NumeroFilas = vwReporte.DataRowCount

                With vwReporte
                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") And IsDBNull(.GetRowCellValue(index, "Apartado")) Then
                            objAdvertencia.mensaje = "Únicamente se pueden mover los renglones de los apartados cancelados."
                            objAdvertencia.ShowDialog()
                            Apartados = False
                            Exit Sub
                        Else
                            Apartados = True
                        End If
                    Next
                End With
            End If

            If Apartados = True Then
                btnGuardar.Enabled = True
            End If


            pnlParametros.Height = 120
            inicioCheck = True
        Else
            pnlParametros.Height = 27
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            objAdvertencia.mensaje = "No se han seleccionado registros."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub consultarDetalleOcupacion()
        Dim obj As New Programacion_MapaOcupacionBU
        Dim objBU As New PlanFabricacionBU

        Me.Cursor = Cursors.WaitCursor
        Try

            Dim semanas As String = String.Empty
            Dim años As String = String.Empty
            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()

            If ConsultaFiltros = True Then
                tablaDetalles = objBU.ObtieneInformacionDetallesMapaOcupacion(FNave, FCliente, LTrim(RTrim(FPedidoSAY)),
                                                                                               LTrim(RTrim(FPedidoSICY)), FMarca, FColeccion, FPiel,
                                                                                               FColor, FCorrida, FFamiliaV, FTemporada,
                                                                                               FiltroFecha, FechaInicio, FechaFin)
            Else
                For Each semana As String In listaSemanas
                    If años <> "" Then
                        años += ","
                    End If
                    años += LTrim(RTrim(Split(semana, "-")(0).ToString()))

                    If semanas <> "" Then
                        semanas += ","
                    End If
                    semanas += LTrim(RTrim(Split(semana, "-")(1).ToString()))
                Next
                tablaDetalles = obj.consultaDetalleOcupacionSemanal(años, semanas, String.Join(",", listaNaves).ToString)
            End If

            If tablaDetalles.Rows.Count > 0 Then
                grdReporte.DataSource = tablaDetalles
                disenoGrid()
            Else
                objAdvertencia.mensaje = "No existen registros."
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            objErrores.mensaje = "Error:" + ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub consultarBitacoraErrores()
        Dim obj As New Programacion_MapaOcupacionBU
        Me.Cursor = Cursors.WaitCursor
        Try

            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            tablaDetalles = obj.consultarBitacoraErrores(Año)

            If tablaDetalles.Rows.Count > 0 Then
                grdReporte.DataSource = tablaDetalles
                disenoGrid()
                Bitacora = 1
            Else
                objAdvertencia.mensaje = "No existen registros."
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            objErrores.mensaje = "Error:" + ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub consultarBitacoraMovimientosManuales()
        Dim obj As New Programacion_MapaOcupacionBU
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim tabla As DataTable
            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            tabla = obj.consultarBitacoraMovimientosManuales(Año)

            If tabla.Rows.Count > 0 Then
                grdReporte.DataSource = tabla
                disenoGrid()
                Bitacora = 1
            Else
                objAdvertencia.mensaje = "No existen registros."
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
            objErrores.mensaje = "Error:" + ex.Message
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Programacion_ColocacionSemanal_DetallesOcupacionSemanal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        RemoveHandler vwReporte.RowCellStyle, AddressOf vwReporte_RowCellStyle
        AddHandler vwReporte.CellValueChanging, AddressOf vwReporte_CellValueChanging


        Dim objBU As New Programacion_MapaOcupacionBU
        dtSemanasConPlanAutorizado = New DataTable
        dtSemanasConPlanAutorizado = objBU.consultaPlanesAutorizados()
        nudAño.Value = Integer.Parse(Date.Now.Year)
        nudSemanaInicio.Value = If(Date.Now.Year = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
        consultaUltimaSemanaDelAñoInicio(DatePart(DateInterval.Year, Now))
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)


        If accion = 0 Then 'Detalles Por Semana
            If ConsultaFiltros = True Then
                consultarDetalleOcupacion()
                btnGuardar.Enabled = True
                lblGuardar.Enabled = True
            Else
                If listaNaves.Count <> 0 And listaSemanas.Count <> 0 Then
                    consultarDetalleOcupacion()
                    cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                Else
                    If listaNaves.Count = 0 Then objAdvertencia.mensaje = "Nave invalida."
                    If listaSemanas.Count = 0 Then objAdvertencia.mensaje = "Semana invalida."
                    If listaNaves.Count = 0 And listaSemanas.Count = 0 Then objAdvertencia.mensaje = "Nave y Semana invalidos."
                    objAdvertencia.ShowDialog()
                End If
            End If


        ElseIf accion = 1 Or accion = 2 Then 'Bitacora de Errores
            Me.Text = "Bitácora de Errores"
            lblTitulo.Text = "Bitácora de Errores"
            'Panel4.Visible = False
            If accion = 1 Then Panel6.Visible = True
            Label6.Visible = False
            Label7.Visible = False
            Label8.Visible = False
            Label11.Visible = False
            lblNumFiltrados.Visible = False
            Label1.Visible = False
            lblNumSemanas.Visible = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            btnDesprogramar.Visible = False
            Label12.Visible = False
            If accion = 1 Then
                consultarBitacoraErrores()
            ElseIf accion = 2 Then
                chkSeleccionar.Visible = False
                lblTitulo.Text = "Bitácora de Movimientos Manuales"
                lblTitulo.Location = New Point(lblTitulo.Location.X - 80, lblTitulo.Location.Y)
                consultarBitacoraMovimientosManuales()
            End If
        End If
    End Sub

    Private Sub consultaUltimaSemanaDelAñoInicio(ByVal añoSeleccionado As Integer)
        Dim obj As New Programacion_MapaOcupacionBU
        Try
            Dim maximoSemana As Integer = obj.ConsultarUltimaSemanaAño(añoSeleccionado)
            nudSemanaInicio.Maximum = maximoSemana
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim filename As String
        Try
            If vwReporte.RowCount > 0 Then
                Dim SaveFileDialog As New SaveFileDialog()
                SaveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx"
                SaveFileDialog.FilterIndex = 2
                SaveFileDialog.RestoreDirectory = True

                If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                    vwReporte.OptionsPrint.AutoWidth = True
                    vwReporte.OptionsPrint.EnableAppearanceEvenRow = True
                    vwReporte.OptionsPrint.PrintPreview = True
                    filename = SaveFileDialog.FileName

                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell

                    DevExpress.Export.ExportSettings.DefaultExportType = ExportType.Default
                    vwReporte.ExportToXlsx(filename, exportOptions)

                    If System.IO.File.Exists(filename) Then
                        Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido exportado a " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Exportar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If DialogResult = Windows.Forms.DialogResult.Yes Then
                            System.Diagnostics.Process.Start(filename)
                        End If
                    End If
                End If
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No existen registros para exportar")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim obj As New Programacion_MapaOcupacionBU

            If Apartados = True Then
                Dim vXmlCeldasModificadas As XElement = generarXMLApartados()
                Dim dtMovimientoDeApartadosCancelados As New DataTable

                If vXmlCeldasModificadas.IsEmpty = True Then
                    objAdvertencia.mensaje = "No hay datos para guardar."
                    objAdvertencia.ShowDialog()
                Else

                    objConfirmar.mensaje = "¿Se moverán los pares de semana/ año / nave seleccionados, Desea continuar.?"
                    If objConfirmar.ShowDialog = DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        dtMovimientoDeApartadosCancelados = obj.MoverApartadosCancelados(vXmlCeldasModificadas.ToString)

                        If dtMovimientoDeApartadosCancelados.Rows(0).Item("Respuesta").ToString() = "Exito" Then
                            objExito.mensaje = "Datos guardados correctamente."
                            objExito.ShowDialog()
                        Else
                            objAdvertencia.mensaje = dtMovimientoDeApartadosCancelados.Rows(0).Item("Respuesta").ToString()
                            objAdvertencia.ShowDialog()
                        End If

                    End If

                End If

            Else
                Dim listaFilaModificadas As List(Of Integer) = filasModificadas()
                If listaFilaModificadas.Count > 0 Then

                    inicioCheck = False

                    Dim vXmlCeldasModificadas As XElement = generarXML(listaFilaModificadas)
                    objConfirmar.mensaje = "Se moverán " + (listaIndicesMarcados.Count - listaSemanasConPlanAutorizadoSeleccionadas.Count).ToString + " partidas (" + paresMoverGlobal.ToString() + " pares) de nave y/o semana, ¿desea continuar? " 'a la nave " + cmbNave.Text
                    If objConfirmar.ShowDialog = DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        Dim dtRespuesta As New DataTable

                        dtRespuesta = obj.MoverDetalleOcupacionSemanal(vXmlCeldasModificadas.ToString)

                        If dtRespuesta.Rows(0).Item("Respuesta").ToString() = "Exitoso" Then
                            objExito.mensaje = "Datos guardados correctamente."
                            objExito.ShowDialog()
                        Else
                            'objAdvertencia.mensaje = dtRespuesta.Rows(0).Item("Respuesta").ToString()
                            'objAdvertencia.ShowDialog()

                            For index As Integer = 0 To dtRespuesta.Rows.Count Step 1
                                If dtRespuesta(index)(0).ToString() = "Exito" Then
                                    objExito.mensaje = "Datos guardados correctamente."
                                    objExito.ShowDialog()
                                    Exit For
                                End If
                            Next
                            Dim mensaje As New MensajeError With {
                                .Titulo = "Movimientos realizados",
                                .dtInformacion = dtRespuesta
                            }
                            mensaje.ShowDialog()
                        End If
                    End If
                Else
                    objAdvertencia.mensaje = "No hay datos para guardar"
                    objAdvertencia.ShowDialog()
                End If

            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
        btnGuardar.Enabled = False
        'Label7.Visible = False
        'Label6.Visible = False
        'lblNumFiltrados.Visible = False
        lblNumFiltrados.Text = "0"
        'Label8.Visible = False
        'Label11.Visible = False
        'lblNumSemanas.Visible = False
        lblNumSemanas.Text = "0"
        consultarDetalleOcupacion()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        If Bitacora = 1 Then
            Me.Dispose()
        Else
            If filasModificadas.Count > 0 Then
                objConfirmar.mensaje = "Todos los datos no guardados se perderán ¿Desea continuar?"
                If objConfirmar.ShowDialog = DialogResult.OK Then Me.Dispose()
            Else
                Me.Dispose()
            End If
        End If

    End Sub
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click

        Dim objBU As New Programacion_MapaOcupacionBU

        vwReporte.Columns.ColumnByFieldName("ParesMover").Visible = True

        If chkSemana.Checked Or chkNave.Checked Then

            inicioCheck = True

            Dim semana As String = nudSemanaInicio.Value & "-" & nudAño.Value
            Dim nombreNave As String = cmbNave.Text
            Dim naveId As String = cmbNave.SelectedValue

            Dim semanaNueva = nudSemanaInicio.Value
            Dim año = nudAño.Value
            Dim dtNuevaFechaEntrega As New DataTable

            If (chkNave.Checked = False) Or (nombreNave <> "" And chkNave.Checked) Then
                Me.Cursor = Cursors.WaitCursor

                Dim NumeroFilas As Integer = 0

                NumeroFilas = vwReporte.DataRowCount

                validarChecksGrid(asiContantitaPena:=False)

                With vwReporte

                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") Then

                            If listaRegistrosSeleccionados.Contains(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), ("Renglon"))) Then
                                If chkSemana.Checked Then
                                    Dim semanaOriginal As Integer = vwReporte.GetRowCellValue(index, "Semana").ToString.Split("-"c)(0)
                                    Dim fecha As Date = vwReporte.GetRowCellValue(index, "FechaEntrega")

                                    ' fecha = DateAdd(DateInterval.Day, (7 * (semana.ToString.Split("-"c)(0) - semanaOriginal)), fecha)

                                    If cmbNave.SelectedValue = 0 Then
                                        naveId = vwReporte.GetRowCellValue(index, "NaveId")
                                    End If

                                    dtNuevaFechaEntrega = objBU.ObtenerNuevaFechaEntrega(semanaNueva, año, naveId)

                                    Dim NuevaFechaEntrega As Date = dtNuevaFechaEntrega.Rows(0).Item("FechaEntregaNueva").ToString
                                    Dim CapacidadSemanaNueva As Integer = dtNuevaFechaEntrega.Rows(0).Item("Capacidad").ToString

                                    If CapacidadSemanaNueva = 0 Then
                                        objAdvertencia.mensaje = "Coloque la capacidad de la nave en la semana " + semanaNueva.ToString() + "-" + año.ToString()
                                        objAdvertencia.ShowDialog()
                                        Exit Sub
                                    End If

                                    If fecha < NuevaFechaEntrega Then
                                        fecha = NuevaFechaEntrega
                                        vwReporte.SetRowCellValue(index, "FechaEntrega", fecha)
                                    End If

                                    vwReporte.SetRowCellValue(index, "Semana", semana)

                                End If
                                If chkNave.Checked Then

                                    If cmbNave.SelectedValue = 0 Then
                                        naveId = vwReporte.GetRowCellValue(index, "NaveId")
                                    End If

                                    dtNuevaFechaEntrega = objBU.ObtenerNuevaFechaEntrega(semanaNueva, año, naveId)

                                    Dim CapacidadSemanaNueva As Integer = dtNuevaFechaEntrega.Rows(0).Item("Capacidad").ToString

                                    If CapacidadSemanaNueva = 0 Then
                                        objAdvertencia.mensaje = "Coloque la capacidad de la nave en la semana " + semanaNueva.ToString() + "-" + año.ToString()
                                        objAdvertencia.ShowDialog()
                                        Exit Sub
                                    End If

                                    vwReporte.SetRowCellValue(index, "NavePrograma", nombreNave)
                                    vwReporte.SetRowCellValue(index, "NaveId", naveId)
                                End If
                            End If
                            'Next
                        End If

                    Next
                End With

                vwReporte.RefreshData()
                vwReporte.Columns("ParesMover").VisibleIndex = 17
            Else
                objAdvertencia.mensaje = "No se ha seleccionado ninguna nave."
                objAdvertencia.ShowDialog()
            End If
            Me.Cursor = Cursors.Default
        Else
            objAdvertencia.mensaje = "Se debe seleccionar al menos una opción."
            objAdvertencia.ShowDialog()
        End If
        If filasModificadas.Count > 0 Then
            btnGuardar.Enabled = True
            lblGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        End If


    End Sub
    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged

        Cursor = Cursors.WaitCursor
        RemoveHandler vwReporte.RowCellStyle, AddressOf vwReporte_RowCellStyle
        'RemoveHandler vwReporte.CellValueChanging, AddressOf vwReporte_CellValueChanging

        Dim activar = False
        If (chkSeleccionar.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwReporte.RowCount) Step 1
                If vwReporte.GetRowCellValue(i, " ") Then
                    vwReporte.SetRowCellValue(i, " ", False)
                    validarChecksGrid(False, i)
                End If
            Next
            For i As Integer = 0 To (vwReporte.RowCount) Step 1
                vwReporte.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
            validarChecksGrid(False)
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub vwReporte_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) 'Handles vwReporte.RowCellStyle

        Dim view As GridView = sender
        If (view Is Nothing) Then Return
        If e.RowHandle >= 0 And eventoActivo = False Then
            If accion = 0 Then
                Dim semana As String = vwReporte.GetRowCellValue(e.RowHandle, "Semana")
                Dim naveId As Integer = vwReporte.GetRowCellValue(e.RowHandle, "NaveId")
                Dim semanaOriginal As String = vwReporte.GetRowCellValue(e.RowHandle, "SemanaOriginal")
                Dim naveIdOriginal As Integer = vwReporte.GetRowCellValue(e.RowHandle, "NaveIdOriginal")
                Dim paresColocadosOriginal As Integer = vwReporte.GetRowCellValue(e.RowHandle, "ParesColocados")
                Dim paresMover As Integer = If(IsDBNull(vwReporte.GetRowCellValue(e.RowHandle, "ParesMover")), 0, vwReporte.GetRowCellValue(e.RowHandle, "ParesMover"))

                If verificarSemanasPlanAutorizado(semana, naveId) = False Then
                    If e.Column.FieldName = "Sem" Then
                        If semana <> semanaOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = Color.DarkViolet
                        End If
                    ElseIf e.Column.FieldName = "NavePrograma" Then
                        If naveId <> naveIdOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = Color.DarkViolet
                        End If
                    ElseIf e.Column.FieldName = "FechaEntrega" Then
                        If semana <> semanaOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = Color.DarkViolet
                        End If
                    ElseIf e.Column.FieldName = "ParesMover" Then
                        If paresMover <> 0 Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = Color.DarkViolet
                        End If
                    End If
                Else
                    If e.Column.FieldName = "Semana" Then
                        If semana <> semanaOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    ElseIf e.Column.FieldName = "NavePrograma" Then
                        If naveId <> naveIdOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    ElseIf e.Column.FieldName = "FechaEntrega" Then
                        If semana <> semanaOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    ElseIf e.Column.FieldName = "ParesMover" Then
                        If paresMover <> paresColocadosOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub vwReporte_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) 'Handles vwReporte.CellValueChanged
        If e.Column.FieldName <> "ParesMover" And e.RowHandle >= 0 Then
            vwReporte.SetRowCellValue(e.RowHandle, " ", e.Value)

            If eventoActivo = False And accion = 0 Then validarChecksGrid(e.Value, e.RowHandle)
        End If

    End Sub

    Private Sub btnReenviar_Click(sender As Object, e As EventArgs) Handles btnReenviar.Click
        Dim listaFilasSeleccionadas As List(Of Integer) = filasSeleccionadas()
        Dim partida As Integer
        Dim pedidoSayId As Integer
        Dim respuesta As New DataTable
        If listaFilasSeleccionadas.Count > 0 Then
            Try

                Dim obj As New Programacion_MapaOcupacionBU
                objConfirmar.mensaje = "Se colocarán " + listaFilasSeleccionadas.Count.ToString + " nuevamente."
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    For Each item As Integer In listaFilasSeleccionadas

                        If IsDBNull(vwReporte.GetRowCellValue(item, "Apartado")) = False Then
                            objAdvertencia.mensaje = "Para mover apartados cancelados, seleccione semana-nave-año."
                            objAdvertencia.ShowDialog()
                            Exit Sub
                        Else
                            Dim productoEstiloId As Integer = vwReporte.GetRowCellValue(item, "ProductoEstiloId")
                            pedidoSayId = vwReporte.GetRowCellValue(item, "PedidoSay")
                            partida = vwReporte.GetRowCellValue(item, "Partida")
                            Dim paresColocar As Integer = vwReporte.GetRowCellValue(item, "Pares(SUM)")
                            Dim usuarioCreoId As Integer = vwReporte.GetRowCellValue(item, "IdUsuarioCreo")
                            respuesta = obj.ColocarPartidaEnSemanas(productoEstiloId, pedidoSayId, partida, paresColocar, usuarioCreoId)
                        End If
                    Next

                    If respuesta(0)("MENSAJE") = "EXITO" Then
                        objExito.mensaje = "Datos guardados correctamente."
                        objExito.ShowDialog()

                    Else
                        objAdvertencia.mensaje = "Verifique la asignación de los artículos a nave."
                        objAdvertencia.ShowDialog()
                    End If

                    chkSeleccionar.Checked = False

                    consultarBitacoraErrores()
                End If

            Catch ex As Exception
                objAdvertencia.mensaje = "Se produjo un error a partir de la partida " + partida.ToString + " del pedido " + pedidoSayId.ToString
                objAdvertencia.Show()
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            objAdvertencia.mensaje = "No se ha seleccionado ningun registro."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Function verificarSemanasPlanAutorizado(ByVal semana As String, ByVal naveId As Integer) As Boolean
        Dim existe As Boolean = False
        For i = 0 To dtSemanasConPlanAutorizado.Rows.Count - 1 Step 1
            If Integer.Parse(dtSemanasConPlanAutorizado.Rows(i)("NaveIDSAY").ToString()) = naveId Then
                If dtSemanasConPlanAutorizado.Rows(i)("Semana").ToString = semana Then
                    existe = True
                    Exit For
                End If
            End If
        Next

        Return existe

    End Function

    Private Sub chkNave_CheckedChanged(sender As Object, e As EventArgs) Handles chkNave.CheckedChanged
        If chkNave.Checked = True Then
            grpNave.Enabled = True
        Else
            grpNave.Enabled = False
        End If
    End Sub

    Private Sub chkSemana_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemana.CheckedChanged
        If chkSemana.Checked = True Then
            grpSemana.Enabled = True
        Else
            grpSemana.Enabled = False
        End If
    End Sub

    Private Sub Programacion_ColocacionSemanal_DetallesOcupacionSemanal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If IsNothing(ventanaPrincipal) = False Then
            ventanaPrincipal.consultaMapaOcupacion()
        End If
    End Sub

    Private Sub BtnDesprogramar_Click(sender As Object, e As EventArgs) Handles btnDesprogramar.Click
        Dim obj As New Programacion_MapaOcupacionBU
        Dim NumeroFilas As Integer = vwReporte.DataRowCount
        Dim lst_detalles = New List(Of Integer)

        If filasSeleccionadas.Count > 0 Then
            objConfirmar.mensaje = "Se desprogramarán las partidas seleccionadas, ¿desea continuar? " 'a la nave " + cmbNave.Text
            If objConfirmar.ShowDialog = DialogResult.OK Then
                For index As Integer = 0 To NumeroFilas Step 1
                    If CBool(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), " ")) = True Then
                        If CBool(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), "Abierta")) = True Then
                            obj.InsertarBitacoraDesprogramados(vwReporte.GetRowCellValue(vwReporte.GetVisibleRowHandle(index), "OcupacionSemanaSetalleId"))
                        Else
                            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "La semana no se encuentra abierta.")
                            Exit For
                        End If
                    End If
                Next
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Pares desprogramados correctamente.")
            End If
            consultarDetalleOcupacion()

            If IsNothing(ventanaPrincipal) = False Then
                ventanaPrincipal.consultaMapaOcupacion()
            End If

            btnCerrar_Click(sender, e)
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione una partida.")
        End If
    End Sub

    Private Sub lblGuardar_Click(sender As Object, e As EventArgs) Handles lblGuardar.Click

    End Sub
End Class