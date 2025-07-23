Imports System.Threading
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.ThemedWindow
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools


Public Class TarjetaProduccionSuelas_Form

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim listaInicial As New List(Of String)
    Dim vXmlAgrupar As XElement = New XElement("TARJETAS")
    Dim fgSeleccion As Boolean = False
    Dim vFgValida As Boolean = False
    Dim vFgAgrupado As Boolean = False

    Private Sub TarjetaProduccionSuelas_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        dtpFechaInicio.Value = Date.Now
        'dtpFechaFin.Value = DateAdd(DateInterval.Day, 3, dtpFechaInicio.Value)
        dtpFechaFin.Value = Date.Now
        grdNaves.DataSource = listaInicial
        CargaComboEstatus()
        'grdEstatus.DataSource = listaInicial
    End Sub

    Private Sub CargaComboEstatus()
        Dim objBU As New Negocios.ArticulosSuelaBU
        Dim dtEstatus = New DataTable
        Dim DT As New DataTable
        dtEstatus.Columns.Add("Parámetro")
        dtEstatus.Columns.Add(" ")
        dtEstatus.Columns.Add("Estatus")

        Dim ROW As DataRow
        ROW = dtEstatus.NewRow()
        ROW.Item(0) = "0"
        ROW.Item(2) = "TODOS"
        dtEstatus.Rows.Add(ROW)

        DT = objBU.ListadoParametroArticulos(3, 6)

        For Each X As DataRow In DT.Rows
            Dim nRow As DataRow
            nRow = dtEstatus.NewRow()
            nRow = X
            dtEstatus.ImportRow(nRow)
        Next

        cmbEstatus.DataSource = dtEstatus
        cmbEstatus.DisplayMember = "Estatus"
        cmbEstatus.ValueMember = "Parámetro"
        cmbEstatus.SelectedIndex = 0

    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        If dtpFechaFin.Value < dtpFechaInicio.Value Then
            dtpFechaFin.Value = dtpFechaInicio.Value
        End If
        dtpFechaFin.MinDate = dtpFechaInicio.Value
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdCntrlTarjeta.DataSource = Nothing
        'grdEstatus.DataSource = listaInicial
        grdNaves.DataSource = listaInicial
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim fechainicio As Date
        Dim fechafin As Date
        Dim FEstatus As String = String.Empty
        Dim FNave As String = String.Empty
        Dim UsuarioId As Integer

        grdCntrlTarjeta.DataSource = Nothing
        MVTarjeta.Columns.Clear()

        Try
            If fechainicio > fechafin Then
                objAdvertencia.mensaje = "La fecha inicio no puede ser mayor a la de fin."
            Else
                Cursor = Cursors.WaitCursor
                Dim obj As New TarjetaProduccionSuelasBU
                Dim dtConsultaTarjeta As New DataTable
                Dim dtConsultaTarjetaCopia As New DataTable

                fechainicio = dtpFechaInicio.Value.ToShortDateString()
                fechafin = dtpFechaFin.Value.ToShortDateString()

                'FEstatus = ObtenerFiltrosGrid(grdEstatus)
                FNave = ObtenerFiltrosGrid(grdNaves)
                UsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

                FEstatus = If(IsDBNull(cmbEstatus.SelectedValue), "", cmbEstatus.SelectedValue.ToString)
                If FEstatus = "0" Then
                    FEstatus = ""
                End If
                dtConsultaTarjeta = obj.ObtenerProgramaPorDia(dtpFechaInicio.Value.ToShortDateString, dtpFechaFin.Value.ToShortDateString, FEstatus, FNave, UsuarioId)
                dtConsultaTarjetaCopia = dtConsultaTarjeta.Copy()


                If dtConsultaTarjeta.Rows.Count > 0 Then
                    grdCntrlTarjeta.DataSource = dtConsultaTarjeta
                    grdCntrolTarjetaOriginal.DataSource = dtConsultaTarjetaCopia
                    disenioGrid()
                    btnArriba_Click(Nothing, Nothing)
                Else
                    objAdvertencia.mensaje = "No hay información con las fechas seleccionadas."
                    objAdvertencia.ShowDialog()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

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

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim objBU As New TarjetaProduccionSuelasBU
        Dim NumeroFilas As Integer = MVTarjeta.DataRowCount
        Dim TarjetasSeleccionadas As String = String.Empty
        Dim lstTarjetas As List(Of String)


        Cursor = Cursors.WaitCursor
        Try
            lstTarjetas = obtenerTarjetasSeleccionadas()

            If lstTarjetas.Count > 0 Then
                objConfirmar.mensaje = "¿Está seguro de cambiar el estatus de la Tarjeta a Finalizado?"
                If objConfirmar.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For Each Tarjeta As String In lstTarjetas
                        If TarjetasSeleccionadas <> "" Then
                            TarjetasSeleccionadas += ","
                        End If
                        TarjetasSeleccionadas += Tarjeta.ToString
                    Next
                    objBU.FinalizarTarjetaProduccion(TarjetasSeleccionadas, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    objExito.mensaje = "Se actualizó el estatus de la Tarjeta a Finalizado."
                    objExito.ShowDialog()
                    btnMostrar_Click(Nothing, Nothing)
                Else
                    objAdvertencia.mensaje = "Debe seleccionar al menos una Tarjeta"
                End If
            End If

        Catch ex As Exception
            objErrores.mensaje = ex.Message.ToString
            objErrores.ShowDialog()
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim objBU As New Produccion.Negocios.TarjetaProduccionSuelasBU
        Dim lstRenglonesEditados As New List(Of Entidades.TarjetaProduccion)
        Dim exito As New ExitoForm
        Dim advertencia As New AdvertenciaForm
        Dim UsuarioID As Integer = 0
        Dim confirmar As New ConfirmarForm

        Try
            lstRenglonesEditados = obtenerRenglonesEditados()

            If lstRenglonesEditados.Count > 0 Then

                confirmar.mensaje = "¿Está seguro de actualizar los datos?"
                If confirmar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor

                    Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
                    For Each item In lstRenglonesEditados
                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("IdSAY", item.PIdTarjetaSuela))
                        vNodo.Add(New XAttribute("Prioridad", item.PPrioridad))
                        vNodo.Add(New XAttribute("Máquina", item.PMaquina))
                        vNodo.Add(New XAttribute("UsuarioId", item.PUsuarioId))
                        vXmlCeldasModificadas.Add(vNodo)
                    Next
                    objBU.ActualizarPrioridadMaquina(vXmlCeldasModificadas.ToString())
                    exito.mensaje = "Datos guardados correctamente."
                    exito.ShowDialog()
                    btnMostrar_Click(Nothing, Nothing)
                End If
            Else
                advertencia.mensaje = "No hay datos para actualizar."
                advertencia.ShowDialog()
            End If

        Catch ex As Exception
            objErrores.mensaje = "Ocurrió un error al guardar, intente de nuevo."
            objErrores.ShowDialog()
        End Try
        Cursor = Cursors.Default

    End Sub

    Private Function obtenerTarjetasSeleccionadas() As List(Of String)
        Dim NumeroFilas As Integer = MVTarjeta.DataRowCount
        Dim lstTarjetasSeleccionadas As New List(Of String)

        For index As Integer = 0 To NumeroFilas Step 1
            If CBool(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), " ")) = True Then
                lstTarjetasSeleccionadas.Add(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "IdSAY"))
            End If
        Next
        Return lstTarjetasSeleccionadas
    End Function

    Private Function obtenerRenglonesEditados() As List(Of Entidades.TarjetaProduccion)
        Dim NumeroFilas As Integer = MVTarjeta.DataRowCount
        Dim lstRenglonesEditados As New List(Of Entidades.TarjetaProduccion)
        Dim datosTarjeta As Entidades.TarjetaProduccion

        Try

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "ModificadoPrioridad")) Or CBool(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "ModificadoMaquina")) = True Then
                    datosTarjeta = New Entidades.TarjetaProduccion
                    datosTarjeta.PIdTarjetaSuela = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "IdSAY")
                    datosTarjeta.PMaquina = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Máquina")
                    datosTarjeta.PPrioridad = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Prioridad")
                    datosTarjeta.PUsuarioId = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    lstRenglonesEditados.Add(datosTarjeta)
                End If

            Next

        Catch ex As Exception

        End Try
        Return lstRenglonesEditados
    End Function




    Public Sub disenioGrid()

        MVTarjeta.OptionsView.ColumnAutoWidth = False

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In MVTarjeta.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

        Next

        MVTarjeta.Columns.ColumnByFieldName("ColorSuela").Caption = "Color Suela"
        MVTarjeta.Columns.ColumnByFieldName("Prioridad").Caption = "* PRI"
        MVTarjeta.Columns.ColumnByFieldName("Máquina").Caption = "* MAQ"
        MVTarjeta.Columns.ColumnByFieldName("Estatus").Caption = "ST"
        MVTarjeta.Columns.ColumnByFieldName("IdSAY").Caption = "ID"

        MVTarjeta.Columns.ColumnByFieldName("FechaPrograma").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("FechaProgramaSuela").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Pares").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Suela").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("ColorSuela").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Estatus").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Corrida").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Naves").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Familia").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Acabado").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("IdSAY").OptionsColumn.AllowEdit = False
        MVTarjeta.Columns.ColumnByFieldName("Grupo").OptionsColumn.AllowEdit = False



        MVTarjeta.Columns.ColumnByFieldName(" ").Width = 30
        MVTarjeta.Columns.ColumnByFieldName("IdSAY").Width = 100
        MVTarjeta.Columns.ColumnByFieldName("Estatus").Width = 30
        MVTarjeta.Columns.ColumnByFieldName("FechaPrograma").Width = 125
        MVTarjeta.Columns.ColumnByFieldName("FechaProgramaSuela").Width = 125
        MVTarjeta.Columns.ColumnByFieldName("Pares").Width = 60
        MVTarjeta.Columns.ColumnByFieldName("Suela").Width = 150
        MVTarjeta.Columns.ColumnByFieldName("ColorSuela").Width = 200
        MVTarjeta.Columns.ColumnByFieldName("Corrida").Width = 100
        MVTarjeta.Columns.ColumnByFieldName("Naves").Width = 100
        MVTarjeta.Columns.ColumnByFieldName("Prioridad").Width = 40
        MVTarjeta.Columns.ColumnByFieldName("Máquina").Width = 40
        MVTarjeta.Columns.ColumnByFieldName("Familia").Width = 150
        MVTarjeta.Columns.ColumnByFieldName("Acabado").Width = 150
        MVTarjeta.Columns.ColumnByFieldName("Grupo").Width = 60

        MVTarjeta.Columns.ColumnByFieldName(" ").OptionsFilter.AllowFilter = False

        MVTarjeta.Columns.ColumnByFieldName("FechaPrograma").OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Equals
        MVTarjeta.Columns.ColumnByFieldName("FechaProgramaSuela").OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Equals
        MVTarjeta.Columns.ColumnByFieldName("Pares").OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Equals

        MVTarjeta.Columns.ColumnByFieldName("Prioridad").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("Máquina").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("SuelaId").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("TallaId").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("Imagen").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t1").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t2").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t3").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t4").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t5").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t6").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t7").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t8").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t9").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t10").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t11").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t12").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t13").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t14").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t15").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t16").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t17").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t18").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t19").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("t20").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT1").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT2").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT3").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT4").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT5").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT6").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT7").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT8").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT9").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT10").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT11").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT12").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT13").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT14").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT15").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT16").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT17").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT18").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT19").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("NT20").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("EstatusID").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("Editable").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("ModificadoPrioridad").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("ModificadoMaquina").Visible = False
        MVTarjeta.Columns.ColumnByFieldName("taps_naveid").Visible = False



        MVTarjeta.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        MVTarjeta.Columns.ColumnByFieldName("Pares").DisplayFormat.FormatString = "N0"
        MVTarjeta.OptionsView.ShowAutoFilterRow = True
        MVTarjeta.IndicatorWidth = 35
        MVTarjeta.OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways

        If IsNothing(MVTarjeta.Columns("Pares").Summary.FirstOrDefault(Function(x) x.FieldName = "Pares")) = True Then
            MVTarjeta.Columns("Pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pares", "{0:N0}")
            Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
            item.FieldName = "Pares"
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
            item.DisplayFormat = "{0}"
            MVTarjeta.GroupSummary.Add(item)
        End If

    End Sub

    Private Function ObtenerColorStatusTarjeta(ByVal EstatusID As Integer) As Color
        Dim TipoColor As New Color

        '203: ACTIVA
        '204: TERMINADA

        If EstatusID = "203" Then
            TipoColor = pnlActiva.BackColor
        ElseIf EstatusID = "204" Then
            TipoColor = pnlTerminada.BackColor
        End If

        Return TipoColor

    End Function




    Private Sub MVTarjeta_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles MVTarjeta.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        Try
            Cursor = Cursors.WaitCursor
            If e.Column.FieldName = "Estatus" Then
                e.Appearance.BackColor = ObtenerColorStatusTarjeta(currentView.GetRowCellValue(e.RowHandle, "EstatusID"))
                e.Appearance.ForeColor = ObtenerColorStatusTarjeta(currentView.GetRowCellValue(e.RowHandle, "EstatusID"))
            End If
            If e.Column.FieldName = "Prioridad" Then
                If MVTarjeta.GetRowCellValue(e.RowHandle, "ModificadoPrioridad") Then
                    e.Appearance.ForeColor = Color.Purple
                End If
            End If
            If e.Column.FieldName = "Máquina" Then
                If MVTarjeta.GetRowCellValue(e.RowHandle, "ModificadoMaquina") Then
                    e.Appearance.ForeColor = Color.Purple
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub MVTarjeta_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles MVTarjeta.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpParametros.Height = 118
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpParametros.Height = 30
    End Sub

    Private Sub btnImprimirTP_Click(sender As Object, e As EventArgs) Handles btnImprimirTP.Click
        Dim NumeroFilas As Integer = 0
        Dim objBU As New TarjetaProduccionBU
        Dim dsTarjeta As New DataSet("dsRegistrosProduccion")
        Dim RegistrosTarjeta As New DataTable("dtRegistrosProduccion")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes

        Try
            Cursor = Cursors.WaitCursor

            RegistrosTarjeta.Columns.Add("Consecutivo")
            RegistrosTarjeta.Columns.Add("IdSAY")
            RegistrosTarjeta.Columns.Add("FechaPrograma")
            RegistrosTarjeta.Columns.Add("Pares")
            RegistrosTarjeta.Columns.Add("Suela")
            RegistrosTarjeta.Columns.Add("SuelaId")
            RegistrosTarjeta.Columns.Add("TallaId")
            RegistrosTarjeta.Columns.Add("Acabado")
            RegistrosTarjeta.Columns.Add("Familia")
            RegistrosTarjeta.Columns.Add("ColorSuela")

            RegistrosTarjeta.Columns.Add("Corrida")
            RegistrosTarjeta.Columns.Add("Imagen")
            RegistrosTarjeta.Columns.Add("t1")
            RegistrosTarjeta.Columns.Add("t2")
            RegistrosTarjeta.Columns.Add("t3")
            RegistrosTarjeta.Columns.Add("t4")
            RegistrosTarjeta.Columns.Add("t5")
            RegistrosTarjeta.Columns.Add("t6")
            RegistrosTarjeta.Columns.Add("t7")
            RegistrosTarjeta.Columns.Add("t8")
            RegistrosTarjeta.Columns.Add("t9")
            RegistrosTarjeta.Columns.Add("t10")
            RegistrosTarjeta.Columns.Add("t11")
            RegistrosTarjeta.Columns.Add("t12")
            RegistrosTarjeta.Columns.Add("t13")
            RegistrosTarjeta.Columns.Add("t14")
            RegistrosTarjeta.Columns.Add("t15")
            RegistrosTarjeta.Columns.Add("t16")
            RegistrosTarjeta.Columns.Add("t17")
            RegistrosTarjeta.Columns.Add("t18")
            RegistrosTarjeta.Columns.Add("t19")
            RegistrosTarjeta.Columns.Add("t20")
            RegistrosTarjeta.Columns.Add("NT1")
            RegistrosTarjeta.Columns.Add("NT2")
            RegistrosTarjeta.Columns.Add("NT3")
            RegistrosTarjeta.Columns.Add("NT4")
            RegistrosTarjeta.Columns.Add("NT5")
            RegistrosTarjeta.Columns.Add("NT6")
            RegistrosTarjeta.Columns.Add("NT7")
            RegistrosTarjeta.Columns.Add("NT8")
            RegistrosTarjeta.Columns.Add("NT9")
            RegistrosTarjeta.Columns.Add("NT10")
            RegistrosTarjeta.Columns.Add("NT11")
            RegistrosTarjeta.Columns.Add("NT12")
            RegistrosTarjeta.Columns.Add("NT13")
            RegistrosTarjeta.Columns.Add("NT14")
            RegistrosTarjeta.Columns.Add("NT15")
            RegistrosTarjeta.Columns.Add("NT16")
            RegistrosTarjeta.Columns.Add("NT17")
            RegistrosTarjeta.Columns.Add("NT18")
            RegistrosTarjeta.Columns.Add("NT19")
            RegistrosTarjeta.Columns.Add("NT20")
            RegistrosTarjeta.Columns.Add("Naves")
            RegistrosTarjeta.Columns.Add("FechaProgramaSuela")


            NumeroFilas = MVTarjeta.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), " ")) = True Then

                    RegistrosTarjeta.Rows.Add(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Consecutivo"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "IdSAY"),
                                              If(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "FechaPrograma") = "...", MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "FechaPrograma"), CDate(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "FechaPrograma")).ToLongDateString().ToUpper),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Pares"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Suela"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "SuelaId"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "TallaId"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Acabado"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Familia"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "ColorSuela"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Corrida"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Imagen"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t1"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t2"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t3"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t4"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t5"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t6"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t7"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t8"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t9"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t10"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t11"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t12"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t13"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t14"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t15"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t16"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t17"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t18"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t19"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "t20"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT1"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT2"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT3"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT4"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT5"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT6"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT7"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT8"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT9"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT10"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT11"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT12"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT13"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT14"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT15"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT16"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT17"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT18"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT19"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "NT20"),
                                              MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "Naves"),
                                             CDate(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), "FechaProgramaSuela")).ToLongDateString().ToUpper)

                End If
            Next

            Cursor = Cursors.WaitCursor

            If RegistrosTarjeta.Rows.Count > 0 Then


                RegistrosTarjeta.TableName = "dtRegistrosProduccion"
                dsTarjeta.Tables.Add(RegistrosTarjeta)

                EntidadReporte = objReporte.LeerReporteporClave("PROD_RPT_TARJ_PROD_SUELA_PRUEBA")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                Dim reporte As New StiReport

                reporte.Load(archivo)
                reporte.Compile()
                reporte("dsReporteVentas") = "dsReporteVentas"
                reporte("NbUsuarioReal") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte.Dictionary.Clear()

                reporte.RegData(dsTarjeta)
                reporte.Dictionary.Synchronize()
                reporte.Show()

            Else
                objAdvertencia.mensaje = "Debe seleccionar al menos una tarjeta para imprimir."
                objAdvertencia.ShowDialog()
            End If

            Cursor = Cursors.Default


        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub chboxSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = MVTarjeta.RowCount

            For index As Integer = 0 To NumeroFilas Step 1
                MVTarjeta.SetRowCellValue(MVTarjeta.GetVisibleRowHandle(index), " ", chboxSeleccionarTodo.Checked)
            Next
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub MVTarjeta_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles MVTarjeta.RowStyle
        Dim View As GridView = sender
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
                If IsDBNull(MVTarjeta.GetRowCellValue(e.RowHandle, "Editable")) = False Then
                    If MVTarjeta.GetRowCellValue(e.RowHandle, "Editable") = 0 Then
                        e.Appearance.BackColor = Color.LightSteelBlue
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub MVTarjeta_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles MVTarjeta.CellValueChanged

        Dim Prioridad As Integer = 0


        If MVTarjeta.GetRowCellValue(e.RowHandle, "Editable") = True Then
            If e.Column.FieldName = "Prioridad" Then
                If MVTarjeta.GetRowCellValue(e.RowHandle, e.Column) <> MVTarjetaOriginal.GetRowCellValue(e.RowHandle, e.Column) Then
                    MVTarjeta.SetRowCellValue(e.RowHandle, "ModificadoPrioridad", True)
                Else
                    MVTarjeta.SetRowCellValue(e.RowHandle, "ModificadoPrioridad", False)
                End If

            End If

            If e.Column.FieldName = "Máquina" Then
                If MVTarjeta.GetRowCellValue(e.RowHandle, e.Column) <> MVTarjetaOriginal.GetRowCellValue(e.RowHandle, e.Column) Then
                    MVTarjeta.SetRowCellValue(e.RowHandle, "ModificadoMaquina", True)
                Else
                    MVTarjeta.SetRowCellValue(e.RowHandle, "ModificadoMaquina", False)
                End If

            End If

        End If
    End Sub

    Private Sub MVTarjeta_ShowingEditor(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MVTarjeta.ShowingEditor

        Dim view As GridView = sender
        Dim ST As String

        If (view.FocusedColumn.FieldName.Contains("Prioridad") Or view.FocusedColumn.FieldName.Contains("Máquina")) And
                view.GetRowCellValue(view.FocusedRowHandle, view.Columns("Estatus")) = "TER" Then
            e.Cancel = True
        End If

    End Sub

    'Private Sub btnEstatus_Click(sender As Object, e As EventArgs)
    '    Dim listado As New ListadoParametrosSuelaForm
    '    listado.tipo_busqueda = 3

    '    Dim listaParametroID As New List(Of String)
    '    For Each row As UltraGridRow In grdEstatus.Rows
    '        Dim parametro As String = row.Cells(0).Text
    '        listaParametroID.Add(parametro)
    '    Next
    '    listado.listaParametroID = listaParametroID
    '    listado.ShowDialog(Me)
    '    If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
    '    If listado.listaParametros.Rows.Count = 0 Then Return
    '    grdEstatus.DataSource = listado.listaParametros
    '    With grdEstatus
    '        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Estatus"
    '        .DisplayLayout.Bands(0).Columns(0).Hidden = True
    '        .DisplayLayout.Bands(0).Columns(1).Hidden = True
    '    End With
    'End Sub
    Private Sub btnNaves_Click(sender As Object, e As EventArgs) Handles btnNaves.Click
        Dim listado As New ListadoParametrosSuelaForm
        listado.tipo_busqueda = 4

        Dim listaParametroID As New List(Of String)

        For Each row As UltraGridRow In grdNaves.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listaParametros.Rows.Count = 0 Then Return
        grdNaves.DataSource = listado.listaParametros
        With grdNaves
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Naves"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    'Private Sub btnLimpiarEstatus_Click(sender As Object, e As EventArgs)
    '    grdEstatus.DataSource = listaInicial
    'End Sub

    Private Sub btnLimpiarNave_Click(sender As Object, e As EventArgs) Handles btnLimpiarNave.Click
        grdNaves.DataSource = listaInicial
    End Sub
    'Private Sub grdEstatus_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
    '    grid_diseño(grdEstatus)
    '    grdEstatus.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Estatus"
    'End Sub

    Private Sub grdNaves_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNaves.InitializeLayout
        grid_diseño(grdNaves)
        grdNaves.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Naves"
    End Sub
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With
    End Sub

    Private Sub btnVerDetalles_Click(sender As Object, e As EventArgs) Handles btnVerDetalles.Click
        Dim NumeroFilas As Integer = 0
        Dim Tarjetasseleccionadas As String = String.Empty
        Dim PantallaDetalles As New DetallesTarjetaProduccionSuelas_Form
        fgSeleccion = False
        Cursor = Cursors.WaitCursor
        vXmlAgrupar = New XElement("TARJETAS")
        GeneraXml()

        If fgSeleccion = True Then
            PantallaDetalles.TarjetasId = vXmlAgrupar.ToString()
            PantallaDetalles.ShowDialog()
        Else
            objAdvertencia.mensaje = "Debe seleccionar al menos una tarjeta."
            objAdvertencia.ShowDialog()
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub btnConcentradoSuelas_Click(sender As Object, e As EventArgs) Handles btnConcentradoSuelas.Click
        Dim ventanaConcentrado As New Produccion_Suela_ConcentradoSuela_Form
        ventanaConcentrado.MdiParent = Me.MdiParent
        ventanaConcentrado.FechaInicioReporte = dtpFechaInicio.Value.ToShortDateString
        ventanaConcentrado.FechaFinReporte = dtpFechaFin.Value.ToShortDateString
        ventanaConcentrado.ProveedorSuela = 1211
        ventanaConcentrado.Show()
    End Sub

    Private Sub btnAgrupar_Click(sender As Object, e As EventArgs) Handles btnAgrupar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim objBU As New Produccion.Negocios.TarjetaProduccionSuelasBU
            fgSeleccion = False
            vFgValida = False
            vXmlAgrupar = New XElement("TARJETAS")
            GeneraXml()

            If fgSeleccion = True Then

                If vFgValida = True Then
                    objBU.InsertaAgrupamientoTarjetaSuela(vXmlAgrupar.ToString(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    btnMostrar_Click(Nothing, Nothing)
                    Dim FormaError As New ExitoForm
                    FormaError.mensaje = "Las tarjetas se agruparon correctamente."
                    FormaError.ShowDialog()
                Else
                    Dim FormaError As New AdvertenciaForm
                    FormaError.mensaje = "La selección de tarjetas no es correcta."
                    FormaError.ShowDialog()
                End If

            Else
                    Dim FormaError As New AdvertenciaForm
                FormaError.mensaje = "Seleccione una tarjeta."
                FormaError.ShowDialog()
            End If

            Cursor = Cursors.Default

        Catch ex As Exception
            Dim FormaError As New AdvertenciaForm
            FormaError.mensaje = "Error al agrupar tarjetas."
            FormaError.ShowDialog()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnDesagrupar_Click(sender As Object, e As EventArgs) Handles btnDesagrupar.Click
        Try
            Cursor = Cursors.WaitCursor
            Dim objBU As New Produccion.Negocios.TarjetaProduccionSuelasBU
            vXmlAgrupar = New XElement("TARJETAS")
            fgSeleccion = False
            GeneraXml()
            Cursor = Cursors.Default

            If fgSeleccion = True Then

                If vFgAgrupado = True Then

                    objBU.DesagrupaTarjetaSuela(vXmlAgrupar.ToString())
                    btnMostrar_Click(Nothing, Nothing)
                    Dim FormaError As New ExitoForm
                    FormaError.mensaje = "Las tarjetas fueron desagrupadas."
                    FormaError.ShowDialog()

                Else

                    Dim FormaError As New AdvertenciaForm
                    FormaError.mensaje = "Tarjeta seleccionada no agrupada."
                    FormaError.ShowDialog()

                End If
            Else
                Dim FormaError As New AdvertenciaForm
                FormaError.mensaje = "Seleccione una tarjeta."
                FormaError.ShowDialog()
            End If

        Catch ex As Exception
            Dim FormaError As New AdvertenciaForm
            FormaError.mensaje = "Error al desagrupar tarjetas."
            FormaError.ShowDialog()
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub GeneraXml()
        Dim vNumFilas As Integer = 0
        vNumFilas = MVTarjeta.DataRowCount
        Dim vSuela As String = String.Empty
        Dim vFamilia As String = String.Empty
        Dim vAcabado As String = String.Empty
        Dim vColor As String = String.Empty

        For Index As Integer = 0 To vNumFilas Step 1
            If CBool(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), " ")) = True Then
                fgSeleccion = True

                If vSuela = "" And vFamilia = "" And vAcabado = "" And vColor = "" Then
                    vSuela = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Suela")
                    vAcabado = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Acabado")
                    vFamilia = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Familia")
                    vColor = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "ColorSuela")
                Else
                    If vSuela = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Suela") And vFamilia = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Familia") And vAcabado = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Acabado") And vColor = MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "ColorSuela") Then
                        vFgValida = True
                    Else
                        vFgValida = False
                    End If
                End If

                If IsDBNull(MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "Grupo")) Then
                    vFgAgrupado = False
                Else
                    vFgAgrupado = True
                End If

                Dim vNodo As XElement = New XElement("TARJETA")
                    vNodo.Add(New XAttribute("TarjetaId", MVTarjeta.GetRowCellValue(MVTarjeta.GetVisibleRowHandle(Index), "IdSAY")))
                    vXmlAgrupar.Add(vNodo)
                End If
        Next
    End Sub

End Class