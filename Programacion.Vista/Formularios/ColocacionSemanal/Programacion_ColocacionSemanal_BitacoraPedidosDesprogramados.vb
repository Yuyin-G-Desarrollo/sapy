Imports System.Globalization
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Programacion.Negocios
Imports Tools

Public Class Programacion_ColocacionSemanal_BitacoraPedidosDesprogramados

    ReadOnly objBU As New Programacion_MapaOcupacionBU

    Dim accion As Integer = 0
    Dim inicioCheck As Boolean = False
    Dim eventoActivo As Boolean = False
    Dim paresMoverGlobal As Integer = 0
    Dim objConfirmar As New ConfirmarForm
    Dim dtSemanasConPlanAutorizado As DataTable
    Public dtResultadoReporte As DataTable
    Dim listaIndicesMarcados As New List(Of Integer)
    Dim listaRegistrosSeleccionados As New List(Of Integer)
    Dim listaSemanasConPlanAutorizadoSeleccionadas As List(Of Integer)
    Public ventanaPrincipal As Programacion_ColocacionSemanal_MapaOcupacionForm = Nothing

    Private Sub Programacion_ColocacionSemanal_BitacoraPedidosDesprogramados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RemoveHandler vwDesprogramados.RowCellStyle, AddressOf VwReporte_RowCellStyle
        AddHandler vwDesprogramados.CellValueChanging, AddressOf VwReporte_CellValueChanging

        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)

        Inicializar()
        MostrarPedidosDesprogramados()
    End Sub

#Region "Panel Cabecera"

    Private Sub BtnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreDocumento = "\ReportePedidosDesprogramados_"

        If vwDesprogramados.RowCount > 0 Then
            Try
                With fbdUbicacionArchivo

                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True
                    Dim exportOptions = New XlsxExportOptionsEx()
                    AddHandler exportOptions.CustomizeCell, AddressOf ExportOptions_CustomizeCell

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwDesprogramados.GroupCount > 0 Then
                            grdDesprogramados.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)
                        Else
                            grdDesprogramados.ExportToXlsx(.SelectedPath + nombreDocumento + fecha_hora + ".xlsx", exportOptions)
                        End If

                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & nombreDocumento & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreDocumento + fecha_hora + ".xlsx")
                    End If
                End With

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para exportar.")
        End If
    End Sub

    Private Sub BtnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
        If FilasSeleccionadas.Count > 0 Then
            pnlParametros.Height = 120
            inicioCheck = True
            btnGuardar.Enabled = True
            lblGuardar.Enabled = True
        Else
            pnlParametros.Height = 25
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se han seleccionado registros.")
        End If
    End Sub

#End Region

#Region "Panel de Parametros"

    Private Sub BtnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim objBU As New Programacion_MapaOcupacionBU
        vwDesprogramados.Columns.ColumnByFieldName("ParesMover").Visible = True

        If chkSemana.Checked Or chkNave.Checked Then

            inicioCheck = True

            Dim semana As String = nudSemanaInicio.Value & "-" & nudAño.Value
            Dim nombreNave As String = cmbNave.Text
            Dim naveId As String = cmbNave.SelectedValue
            If (chkNave.Checked = False) Or (nombreNave <> "" And chkNave.Checked) Then
                Me.Cursor = Cursors.WaitCursor

                Dim NumeroFilas As Integer = 0

                NumeroFilas = vwDesprogramados.DataRowCount

                ValidarChecksGrid(asiContantitaPena:=False)

                With vwDesprogramados

                    For index As Integer = 0 To NumeroFilas Step 1
                        If .GetRowCellValue(index, " ") Then

                            If listaRegistrosSeleccionados.Contains(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Renglon"))) Then
                                If chkSemana.Checked Then
                                    Dim semanaOriginal As Integer = Integer.Parse(vwDesprogramados.GetRowCellValue(index, "Semana").ToString.Split("-"c)(0))
                                    Dim fecha As Date = vwDesprogramados.GetRowCellValue(index, "FechaEntrega")
                                    fecha = DateAdd(DateInterval.Day, (7 * (semana.ToString.Split("-"c)(0) - semanaOriginal)), fecha)
                                    vwDesprogramados.SetRowCellValue(index, "Semana", semana)
                                    vwDesprogramados.SetRowCellValue(index, "FechaEntrega", fecha)
                                End If
                                If chkNave.Checked Then
                                    vwDesprogramados.SetRowCellValue(index, "NavePrograma", nombreNave)
                                    vwDesprogramados.SetRowCellValue(index, "NaveId", naveId)
                                End If
                            End If
                            'Next
                        End If

                    Next
                End With

                vwDesprogramados.RefreshData()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No se ha seleccionado ninguna nave.")
            End If
            Me.Cursor = Cursors.Default
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Se debe seleccionar al menos una opción.")
        End If

        If FilasModificadas.Count > 0 Then
            btnGuardar.Enabled = True
            lblGuardar.Enabled = True
        Else
            btnGuardar.Enabled = False
            lblGuardar.Enabled = False
        End If
    End Sub

    Private Sub ChkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Cursor = Cursors.WaitCursor
        RemoveHandler vwDesprogramados.RowCellStyle, AddressOf VwReporte_RowCellStyle
        'RemoveHandler vwReporte.CellValueChanging, AddressOf vwReporte_CellValueChanging

        Dim activar = False
        If (chkSeleccionar.Checked) Then
            activar = True
        End If
        If (eventoActivo = False) Then
            eventoActivo = True
            For i As Integer = 0 To (vwDesprogramados.RowCount) Step 1
                If vwDesprogramados.GetRowCellValue(i, " ") Then
                    vwDesprogramados.SetRowCellValue(i, " ", False)
                    ValidarChecksGrid(False, i)
                End If
            Next
            For i As Integer = 0 To (vwDesprogramados.RowCount) Step 1
                vwDesprogramados.SetRowCellValue(i, " ", activar)
            Next
            eventoActivo = False
            ValidarChecksGrid(False)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub ChkSemana_CheckedChanged(sender As Object, e As EventArgs) Handles chkSemana.CheckedChanged
        grpSemana.Enabled = chkSemana.Checked = True
    End Sub

    Private Sub ChkNave_CheckedChanged(sender As Object, e As EventArgs) Handles chkNave.CheckedChanged
        grpNave.Enabled = chkNave.Checked = True
    End Sub

#End Region

#Region "Panel de Acciones"

    Private Sub BtnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Inicializar()
        MostrarPedidosDesprogramados()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Cursor = Cursors.WaitCursor
        Dim listaFilaModificadas As List(Of Integer) = FilasModificadas()
        If listaFilaModificadas.Count > 0 Then
            Try
                inicioCheck = False

                Dim obj As New Programacion_MapaOcupacionBU
                Dim vXmlCeldasModificadas As XElement = generarXML(listaFilaModificadas)

                objConfirmar.mensaje = "Se moverán " + (listaIndicesMarcados.Count - listaSemanasConPlanAutorizadoSeleccionadas.Count).ToString + " partidas (" + paresMoverGlobal.ToString() + " pares) de nave y/o semana, ¿desea continuar? " 'a la nave " + cmbNave.Text
                If objConfirmar.ShowDialog = DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim dtRespuesta As New DataTable

                    dtRespuesta = obj.MoverDetalleOcupacionSemanal(vXmlCeldasModificadas.ToString, True)

                    If dtRespuesta.Rows(0).Item("Respuesta").ToString() = "Exitoso" Then
                        Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Datos guardados correctamente.")
                    Else
                        For index As Integer = 0 To dtRespuesta.Rows.Count - 1 Step 1
                            If dtRespuesta(index)(0).ToString() = "Exito" Then
                                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Datos guardados correctamente.")
                                Exit For
                            End If
                        Next
                        Dim mensaje As New MensajeError With {
                                .Titulo = "Movimientos no realizados",
                                .dtInformacion = dtRespuesta
                            }
                        mensaje.ShowDialog()
                    End If

                    Me.Cursor = Cursors.Default

                    If IsNothing(ventanaPrincipal) = False Then
                        ventanaPrincipal.consultaMapaOcupacion()
                    End If

                    BtnCancelar_Click(sender, e)
                End If
            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "No hay datos para guardar")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub Inicializar()

        grdDesprogramados.DataSource = Nothing
        vwDesprogramados.Columns.Clear()

        lblNumFiltrados.Text = "0"

        dtSemanasConPlanAutorizado = New DataTable
        dtSemanasConPlanAutorizado = objBU.consultaPlanesAutorizados()

        dtResultadoReporte = New DataTable

        chkSemana.Checked = False
        chkNave.Checked = False

        pnlParametros.Height = 25
        btnGuardar.Enabled = False
        lblGuardar.Enabled = False

        nudAño.Value = Integer.Parse(Date.Now.Year)
        nudSemanaInicio.Value = If(Date.Now.Year = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))
    End Sub

    Private Sub DiseñoDevGrid()
        vwDesprogramados.IndicatorWidth = 50
        For Each col As Columns.GridColumn In vwDesprogramados.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            col.OptionsColumn.AllowEdit = False
        Next

        DiseñoGrid.EstiloColumna(vwDesprogramados, " ", " ", True, Columns.AutoFilterCondition.Contains, True, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Renglon", "Renglon", False, Columns.AutoFilterCondition.Contains, True, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "NaveId", "NaveId", False, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "OcupacionSemanaSetalleId", "OcupacionSemanaSetalleId", False, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "ProductoEstiloId", "ProductoEstiloId", False, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "NavePrograma", "Nave Programa", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Semana", "Semana", False, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Sem", "Sem", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Año", "Año", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Cliente", "Cliente", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "PedidoSAY", "Pedido SAY", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "PedidoSICY", "Pedido SICY", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Partida", "Partida", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "ParesPartida", "Pares Partida", True, Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "ParesColocados", "Pares Colocados", True, Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "FechaEntrega", "Fecha Entrega", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "ParesMover", "Pares Mover", False, Columns.AutoFilterCondition.Contains, False, True, 100, True, DevExpress.Data.SummaryItemType.Sum, "{0:N0}")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Sem FEntrega", "F Entrega Sem", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Captura", "F Captura", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Sem FCaptura", "F Captura Sem", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Confirmación", "F Confirmación", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Sem FConfirmación", "F Confirmación Sem", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "EntregaCliente", "F Entrega Cliente", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Sem FEntrega C", "F Entrega Cliente Sem", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Colección", "Colección", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Familia", "Familia", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Modelo SAY", "Modelo SAY", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Modelo SICY", "Modelo SICY", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "PielColor", "Piel Color", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "Corrida", "Corrida", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "NavesAsignadas", "Naves Asignadas", True, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "SemanaOriginal", "SemanaOriginal", False, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        DiseñoGrid.EstiloColumna(vwDesprogramados, "NaveIdOriginal", "NaveIdOriginal", False, Columns.AutoFilterCondition.Contains, False, True, 100, False, Nothing, "")
        'vwDesprogramados.OptionsView.ColumnAutoWidth = True
    End Sub

    Private Sub ValidarChecksGrid(Optional evento As Boolean = True, Optional linea As Integer = -1, Optional asiContantitaPena As Boolean = True)
        RemoveHandler vwDesprogramados.RowCellStyle, AddressOf VwReporte_RowCellStyle

        Dim pares As Integer = 0
        Dim paresN As Integer = 0
        Dim total As Integer = CInt(lblNumFiltrados.Text)

        Dim listaSemanas As New List(Of Integer)
        listaIndicesMarcados = New List(Of Integer)

        Dim NumeroFilas As Integer = vwDesprogramados.DataRowCount

        If inicioCheck Then
            With vwDesprogramados
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        If evento Then
                            pares = vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(linea), ("ParesColocados"))
                            listaSemanas.Add(Integer.Parse(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                        Else
                            pares += vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("ParesColocados"))
                            listaSemanas.Add(Integer.Parse(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                        End If
                        listaIndicesMarcados.Add(1)
                        vwDesprogramados.SetRowCellValue(index, "ParesMover", vwDesprogramados.GetRowCellValue(index, "ParesColocados"))
                        listaRegistrosSeleccionados.Add(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Renglon")))
                    Else
                        If evento = False Then
                            paresN = vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(linea), ("ParesColocados"))
                        End If
                        vwDesprogramados.SetRowCellValue(index, "ParesMover", 0)
                        listaRegistrosSeleccionados.Remove(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Renglon")))
                    End If
                Next
            End With
        Else

            With vwDesprogramados
                For index As Integer = 0 To NumeroFilas Step 1
                    If .GetRowCellValue(index, " ") Then
                        If evento Then
                            pares = vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(linea), ("ParesColocados"))
                            listaSemanas.Add(Integer.Parse(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                        Else
                            pares += vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("ParesColocados"))
                            listaSemanas.Add(Integer.Parse(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Semana")).ToString.Split(New Char() {"-"c})(0)))
                        End If
                    Else
                        If evento = False Then
                            paresN = vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(linea), ("ParesColocados"))
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
        'lblNumSemanas.Text = listaSemanas.AsEnumerable.Distinct.Count

    End Sub

    Public Sub MostrarPedidosDesprogramados()

        Cursor = Cursors.WaitCursor

        dtResultadoReporte = objBU.consultarBitacoraDesprogramadas()

        If dtResultadoReporte.Rows.Count > 0 Then
            grdDesprogramados.DataSource = Nothing
            vwDesprogramados.Columns.Clear()

            grdDesprogramados.DataSource = dtResultadoReporte
            DiseñoGrid.DiseñoBaseGrid(vwDesprogramados)
            DiseñoDevGrid()

            'lblNumFiltrados.Text = dtResultadoReporte.Rows.Count
        Else
            grdDesprogramados.DataSource = Nothing
            vwDesprogramados.Columns.Clear()
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No hay datos para mostrar.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Function generarXML(ByVal listaFilaModificadas As List(Of Integer))
        Dim vXmlCeldasModificadas As New XElement("Celdas")
        Dim NumeroFilas As Integer = vwDesprogramados.DataRowCount

        With vwDesprogramados
            For index As Integer = 0 To NumeroFilas Step 1
                If .GetRowCellValue(index, " ") Then
                    If listaFilaModificadas.Contains(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), ("Renglon"))) Then
                        Dim vNodo As New XElement("Celda")
                        Dim particiones = vwDesprogramados.GetRowCellValue(index, "Semana").ToString.Split(New Char() {"-"c})
                        Dim semana = Integer.Parse(particiones(0))
                        Dim año = Integer.Parse(particiones(1))
                        vNodo.Add(New XAttribute("OcupacionSemanaSetalleId", vwDesprogramados.GetRowCellValue(index, "OcupacionSemanaSetalleId")))
                        vNodo.Add(New XAttribute("ProductoEstiloId", vwDesprogramados.GetRowCellValue(index, "ProductoEstiloId")))
                        vNodo.Add(New XAttribute("Semana", vwDesprogramados.GetRowCellValue(index, "SemanaOriginal")))
                        vNodo.Add(New XAttribute("Partida", vwDesprogramados.GetRowCellValue(index, "Partida")))
                        vNodo.Add(New XAttribute("PedidoSAY", vwDesprogramados.GetRowCellValue(index, "PedidoSAY")))
                        vNodo.Add(New XAttribute("NaveId", vwDesprogramados.GetRowCellValue(index, "NaveIdOriginal")))

                        vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
                        vNodo.Add(New XAttribute("NuevaNave", vwDesprogramados.GetRowCellValue(index, "NaveId")))
                        vNodo.Add(New XAttribute("NuevaSemana", semana))
                        vNodo.Add(New XAttribute("NuevoAño", año))
                        vNodo.Add(New XAttribute("ParesMover", vwDesprogramados.GetRowCellValue(index, "ParesMover")))
                        vXmlCeldasModificadas.Add(vNodo)
                    End If
                End If
            Next
        End With

        Return vXmlCeldasModificadas

    End Function

    Private Function FilasModificadas() As List(Of Integer)
        Dim listaFilasModificadas As New List(Of Integer)
        paresMoverGlobal = 0

        AddHandler vwDesprogramados.RowCellStyle, AddressOf VwReporte_RowCellStyle

        Dim NumeroFilas As Integer = vwDesprogramados.DataRowCount
        Try
            With vwDesprogramados
                For index As Integer = 0 To NumeroFilas Step 1
                    Dim semana As String = .GetRowCellValue(index, "Semana")
                    Dim naveId As Integer = .GetRowCellValue(index, "NaveId")
                    Dim semanaOriginal As String = .GetRowCellValue(index, "SemanaOriginal")
                    Dim naveIdOriginal As Integer = .GetRowCellValue(index, "NaveIdOriginal")

                    listaSemanasConPlanAutorizadoSeleccionadas = New List(Of Integer)
                    If CBool(vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(index), " ")) = True Then
                        If VerificarSemanasPlanAutorizado(semana, naveId) = False Then

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
                Next
            End With
        Catch ex As Exception

        End Try

        Return listaFilasModificadas
    End Function

    Private Function FilasSeleccionadas() As List(Of Integer)
        Dim listaFilasSeleccionadas As New List(Of Integer)
        For i = 0 To vwDesprogramados.RowCount - 1 Step 1
            If vwDesprogramados.GetRowCellValue(i, " ") Then listaFilasSeleccionadas.Add(i)
        Next
        Return listaFilasSeleccionadas
    End Function

    Private Function VerificarSemanasPlanAutorizado(ByVal semana As String, ByVal naveId As Integer) As Boolean
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

    Private Sub ExportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

    End Sub

    Private Sub VwDesprogramados_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwDesprogramados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub VwDesprogramados_Click(sender As Object, e As EventArgs) Handles vwDesprogramados.Click
        'If vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(vwDesprogramados.FocusedRowHandle), " ") Then
        '    vwDesprogramados.SetFocusedRowCellValue(" ", False)
        'Else
        '    vwDesprogramados.SetFocusedRowCellValue(" ", True)
        'End If

        'Dim marcados As Integer
        'Dim NumeroFilas As Integer = vwDesprogramados.DataRowCount

        'For index As Integer = 0 To NumeroFilas Step 1
        '    If vwDesprogramados.GetRowCellValue(vwDesprogramados.GetVisibleRowHandle(vwDesprogramados.FocusedRowHandle), " ") Then
        '        marcados += 1
        '    End If
        'Next
        'lblNumFiltrados.Text = marcados.ToString("N0", CultureInfo.InvariantCulture)
    End Sub

    Private Sub VwReporte_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) 'Handles vwReporte.RowCellStyle

        Dim view As GridView = sender
        If (view Is Nothing) Then Return
        If e.RowHandle >= 0 And eventoActivo = False Then
            If accion = 0 Then
                Dim semana As String = vwDesprogramados.GetRowCellValue(e.RowHandle, "Semana")
                Dim naveId As Integer = vwDesprogramados.GetRowCellValue(e.RowHandle, "NaveId")
                Dim semanaOriginal As String = vwDesprogramados.GetRowCellValue(e.RowHandle, "SemanaOriginal")
                Dim naveIdOriginal As Integer = vwDesprogramados.GetRowCellValue(e.RowHandle, "NaveIdOriginal")
                Dim paresColocadosOriginal As Integer = vwDesprogramados.GetRowCellValue(e.RowHandle, "ParesColocados")
                Dim paresMover As Integer = If(IsDBNull(vwDesprogramados.GetRowCellValue(e.RowHandle, "ParesMover")), 0, vwDesprogramados.GetRowCellValue(e.RowHandle, "ParesMover"))

                If VerificarSemanasPlanAutorizado(semana, naveId) = False Then
                    If e.Column.FieldName = "Semana" Then
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
                            'e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    ElseIf e.Column.FieldName = "NavePrograma" Then
                        If naveId <> naveIdOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            'e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    ElseIf e.Column.FieldName = "FechaEntrega" Then
                        If semana <> semanaOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            'e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    ElseIf e.Column.FieldName = "ParesMover" Then
                        If paresMover <> paresColocadosOriginal Then
                            e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
                            'e.Appearance.ForeColor = lblNoMover.ForeColor
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub VwReporte_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) 'Handles vwReporte.CellValueChanged
        If e.Column.FieldName <> "ParesMover" And e.RowHandle >= 0 Then
            vwDesprogramados.SetRowCellValue(e.RowHandle, " ", e.Value)

            If eventoActivo = False And accion = 0 Then ValidarChecksGrid(e.Value, e.RowHandle)
        End If

    End Sub

#End Region

End Class