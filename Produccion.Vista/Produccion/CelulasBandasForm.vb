Imports Entidades
Imports Produccion.Negocios
Imports System.Threading
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class CelulasBandasForm
    Dim lotesTot As Integer = 0
    Dim paresTot As Integer = 0
    Dim departamentos As New DataTable
    Private Sub CelulasBandasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarcomboNaves()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub getTodosDatos() 'No modificar el orden en como se llenan los componentes
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New CelulaBandaBU
        Dim lotesPares As New DataTable
        lotesPares = obj.getLotesyPares(cmbNave.SelectedValue, dtpFechaInicio.Value)
        For Each row As DataRow In lotesPares.Rows
            paresTot = row("Pares")
            lotesTot = row("Lotes")
            lblNoLote.Text = CInt(row("Lotes")).ToString("##,##0")
            lblNoPares.Text = CInt(row("Pares")).ToString("##,##0")
        Next
        departamentos = obj.getDepartamentosXNave(cmbNave.SelectedValue)
        setResumenPares()
        llenarGrid()
        llenarResumenCelulasBandas()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub llenarResumenCelulasBandas()
        Dim datos As New DataTable
        Dim celban As New DataTable
        Dim obj As New CelulaBandaBU
        datos = grdLotes.DataSource
        Dim cel1 As Integer = 0
        Dim cel2 As Integer = 0
        Dim cel3 As Integer = 0
        Dim ban1 As Integer = 0
        Dim ban2 As Integer = 0
        Dim contador As Integer = 0

        For Each row As DataRow In departamentos.Rows
            contador += 1
            celban = obj.getTotalCelulasyBandas(cmbNave.SelectedValue, dtpFechaInicio.Value, row("IdDepto"))
            For Each row2 As DataRow In celban.Rows
                If contador = 2 Then
                    If row2("Celula").ToString.Contains("1") Then
                        lblNomcel1.Text = row2("Celula")
                        cel1 += row2("Pares")
                    ElseIf row2("Celula").ToString.Contains("2") Then
                        lblNomcel2.Text = row2("Celula")
                        cel2 += row2("Pares")
                    ElseIf row2("Celula").ToString.Contains("3") Then
                        lblNomcel3.Text = row2("Celula")
                        cel3 += row2("Pares")
                    End If
                ElseIf contador = 3 Then
                    If row2("Celula").ToString.Contains("1") Then
                        lblNomban1.Text = row2("Celula")
                        ban1 += row2("Pares")
                    ElseIf row2("Celula").ToString.Contains("2") Then
                        lblNomban2.Text = row2("Celula")
                        ban2 += row2("Pares")
                    End If
                End If

            Next
        Next
        lblNoCelula1.Text = cel1.ToString("##,##0")
        lblNoCelula2.Text = cel2.ToString("##,##0")
        lblNoCelula3.Text = cel3.ToString("##,##0")
        lblNoBanda1.Text = ban1.ToString("##,##0")
        lblNoBanda2.Text = ban2.ToString("##,##0")
    End Sub
    Private Sub setResumenPares()
        Dim obj As New CelulaBandaBU
        Dim pares As New DataTable
        Dim contador As Integer = 0

        For Each dep As DataRow In departamentos.Rows
            contador += 1
            If contador = 1 Then
                pares = obj.getParesxDepartamento(cmbNave.SelectedValue, dtpFechaInicio.Value, dep("IdDepto"), "C")
                For Each dep1 As DataRow In pares.Rows
                    lbl1Cpares.Text = CInt(dep1("Pares")).ToString("##,##0")
                    lbl1Ppares.Text = CInt(paresTot - dep1("Pares")).ToString("##,##0")
                Next
            ElseIf contador = 2 Then
                pares = obj.getParesxDepartamento(cmbNave.SelectedValue, dtpFechaInicio.Value, dep("IdDepto"), "C")
                For Each dep1 As DataRow In pares.Rows
                    lbl2Cpares.Text = CInt(dep1("Pares")).ToString("##,##0")
                    lbl2Ppares.Text = CInt(paresTot - dep1("Pares")).ToString("##,##0")
                Next
            ElseIf contador = 3 Then
                pares = obj.getParesxDepartamento(cmbNave.SelectedValue, dtpFechaInicio.Value, dep("IdDepto"), "C")
                For Each dep1 As DataRow In pares.Rows
                    lbl3Cpares.Text = CInt(dep1("Pares")).ToString("##,##0")
                    lbl3Ppares.Text = CInt(paresTot - dep1("Pares")).ToString("##,##0")
                Next
            End If
        Next
        pares = obj.getParesxEmbarque(cmbNave.SelectedValue, dtpFechaInicio.Value, "C")
        For Each dep1 As DataRow In pares.Rows
            lbl4Cpares.Text = CInt(dep1("Pares")).ToString("##,##0")
        Next
        pares = obj.getParesxEmbarque(cmbNave.SelectedValue, dtpFechaInicio.Value, "P")
        For Each dep1 As DataRow In pares.Rows
            lbl4Ppares.Text = CInt(dep1("Pares")).ToString("##,##0")
        Next

    End Sub
    Private Sub llenarGrid()
        Dim obj As New CelulaBandaBU
        Dim celBan As New DataTable
        Dim contador As Integer = 0
        Dim listaDep1, listaDep2, listaDep3 As New ValueList
        Dim datos As New DataTable
        Dim datosConfig As New DataTable
        Dim idCorte As Integer = 0
        Dim idPes As Integer = 0
        Dim idMonAdo As Integer = 0
        Dim ban As Integer = 0
        Dim fechasEmbarque As New DataTable


        datos = obj.getDatosLotes(cmbNave.SelectedValue, dtpFechaInicio.Value)
        datosConfig = obj.getConfiguracion(cmbNave.SelectedValue, dtpFechaInicio.Value)

        For Each row As DataRow In departamentos.Rows
            ban += 1
            If ban = 1 Then
                idCorte = row("IdDepto")
            ElseIf ban = 2 Then
                idPes = row("IdDepto")
                For Each r As DataRow In datos.Rows
                    r("idConfigPes") = idPes
                Next
            ElseIf ban = 3 Then
                idMonAdo = row("IdDepto")
                For Each r As DataRow In datos.Rows
                    r("idConfigMonAdo") = idMonAdo
                Next
            End If
        Next


        For Each lotes As DataRow In datos.Rows
            For Each config As DataRow In datosConfig.Rows
                If lotes("Lote") = config("Lote") Then
                    If idCorte = config("IdConfiguracion") Then
                        lotes("EstadoCorte") = config("Estado")
                        lotes("ColorCorte") = config("Color")
                    End If
                    If idPes = config("IdConfiguracion") Then
                        lotes("Pespunte") = config("IdCelula")
                        lotes("IdLoteAvancePespunte") = config("IdLoteAvance")
                        lotes("idConfigPes") = config("IdConfiguracion")
                        lotes("EstadoPespunte") = config("Estado")
                        lotes("ColorPespunte") = config("Color")
                    End If
                    If idMonAdo = config("IdConfiguracion") Then
                        lotes("Montado y Adorno") = config("IdCelula")
                        lotes("IdLoteAvanceMontadoyAdorno") = config("IdLoteAvance")
                        lotes("idConfigMonAdo") = config("IdConfiguracion")
                        lotes("EstadoMontadoYAdorno") = config("Estado")
                        lotes("ColorMontado") = config("Color")
                    End If
                End If
            Next
        Next
        fechasEmbarque = obj.getFechasEmbarque(cmbNave.SelectedValue, dtpFechaInicio.Value)
        For Each lotes As DataRow In datos.Rows
            For Each fechas As DataRow In fechasEmbarque.Rows
                If fechas("Lote") = lotes("Lote") Then
                    lotes("Embarque") = fechas("fecha_salida").ToString()
                End If
            Next
        Next

        grdLotes.DataSource = Nothing
        grdLotes.DataSource = datos

        For Each dep As DataRow In departamentos.Rows
            contador += 1
            celBan = obj.getCelulasBandasDep(dep("IdDepto"))
            If contador = 1 Then
                For Each row As DataRow In celBan.Rows
                    listaDep1.ValueListItems.Add(row.Item("IdCelula"), row.Item("Celula").ToString.ToUpper.Trim)
                Next
            ElseIf contador = 2 Then
                Dim datosDep2 As New DataTable
                For Each row As DataRow In celBan.Rows
                    listaDep2.ValueListItems.Add(row.Item("IdCelula"), row.Item("Celula").ToString.ToUpper.Trim)
                Next
                cmbCel.DataSource = celBan
                cmbCel.DisplayMember = "Celula"
                cmbCel.ValueMember = "IdCelula"
            ElseIf contador = 3 Then
                Dim datosDep3 As New DataTable
                For Each row As DataRow In celBan.Rows
                    listaDep3.ValueListItems.Add(row.Item("IdCelula"), row.Item("Celula").ToString.ToUpper.Trim)
                Next
                cmbban.DataSource = celBan
                cmbban.DisplayMember = "Celula"
                cmbban.ValueMember = "IdCelula"
            End If
        Next
        With grdLotes.DisplayLayout.Bands(0)
            .Columns("Año").Hidden = True
            .Columns("Nave").Hidden = True
            .Columns("ColorCorte").Hidden = True
            .Columns("ColorPespunte").Hidden = True
            .Columns("ColorMontado").Hidden = True
            .Columns("EstadoPespunte").Hidden = True
            .Columns("EstadoCorte").Hidden = True
            .Columns("EstadoMontadoYAdorno").Hidden = True
            .Columns("IdLoteAvancePespunte").Hidden = True
            .Columns("IdLoteAvanceMontadoyAdorno").Hidden = True
            .Columns("idConfigPes").Hidden = True
            .Columns("idConfigMonAdo").Hidden = True
            .Columns("Pespunte").Style = UltraWinGrid.ColumnStyle.DropDown
            .Columns("Pespunte").ValueList = listaDep2
            .Columns("Montado y Adorno").Style = UltraWinGrid.ColumnStyle.DropDown
            .Columns("Montado y Adorno").ValueList = listaDep3
            .Columns("Lote").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Coleccion").CellActivation = Activation.NoEdit
            .Columns("Talla").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Pares").CellActivation = Activation.NoEdit
            .Columns("Corte").CellActivation = Activation.NoEdit
            .Columns("Embarque").CellActivation = Activation.NoEdit
            .Columns("Corte").Width = 40
            .Columns("Lote").Width = 50
            .Columns("Modelo").Width = 50
            .Columns("Talla").Width = 50
            .Columns("Pares").Width = 50
            .Columns("Coleccion").Header.Caption = "Colección"
            .Columns("Talla").Header.Caption = "Corrida"

            .Columns("Seleccion").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Seleccion").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Seleccion").Style = ColumnStyle.CheckBox
            .Columns("Seleccion").Header.Caption = " "
            .Columns("Seleccion").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
            .Columns("Seleccion").Width = 2
        End With
        grdLotes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdLotes.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub
    Private Sub llenarcomboNaves()
        cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbParametros.Height = 39
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbParametros.Height = 150
    End Sub

    Private Sub btnFiltrarSolicitud_Click(sender As Object, e As EventArgs) Handles btnFiltrarSolicitud.Click
        If cmbNave.SelectedValue > 0 Then
            getTodosDatos()
            Dim bandera As Boolean = False
            For Each row As UltraGridRow In grdLotes.Rows
                If row.Cells("Embarque").Value.ToString.Length <= 0 Then
                    bandera = True
                End If
            Next
            If bandera Then
                btnGuardar.Enabled = True
            Else
                btnGuardar.Enabled = False
            End If
        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleccione una nave."
            advertencia.ShowDialog()
        End If
    End Sub

    Private Sub grdLotes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdLotes.InitializeRow
        If e.Row.Cells("EstadoCorte").Value = "C" Then
            e.Row.Cells("Corte").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(e.Row.Cells("ColorCorte").Value.ToString)
        End If
        If e.Row.Cells("EstadoPespunte").Value = "C" Then
            e.Row.Cells("Pespunte").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(e.Row.Cells("ColorPespunte").Value.ToString)
            e.Row.Cells("Pespunte").Activation = Activation.NoEdit
        End If
        If e.Row.Cells("EstadoMontadoYAdorno").Value = "C" Then
            e.Row.Cells("Montado y Adorno").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml(e.Row.Cells("ColorMontado").Value.ToString)
            e.Row.Cells("Montado y Adorno").Activation = Activation.NoEdit
        End If

        If e.Row.Cells("Embarque").Value.ToString.Length > 0 Then
            e.Row.Cells("Embarque").Appearance.BackColor = Color.YellowGreen
        End If
    End Sub
    Private Sub guardar()
        Dim datos As New DataTable
        Dim obj As New CelulaBandaBU
        datos = grdLotes.DataSource
        For Each row As DataRow In datos.Rows
            If row("IdLoteAvancePespunte") = 0 Then
                If row("Pespunte").ToString.Length > 0 Then 'Insertar
                    obj.insertAvance(row("Nave"), row("Año"), row("idConfigPes"), row("Pespunte"), row("Pares"), "P", row("Lote"))

                End If
            Else
                If row("Pespunte").ToString.Length > 0 Then 'Actualizar
                    obj.updateAvance(row("IdLoteAvancePespunte"), row("Pespunte"))
                End If
            End If
            If row("IdLoteAvanceMontadoYAdorno") = 0 Then
                If row("Montado y Adorno").ToString.Length > 0 Then 'Insertar
                    obj.insertAvance(row("Nave"), row("Año"), row("idConfigMonAdo"), row("Montado y Adorno"), row("Pares"), "P", row("Lote"))

                End If
            Else
                If row("Montado y Adorno").ToString.Length > 0 Then 'Actualizar
                    obj.updateAvance(row("IdLoteAvanceMontadoYAdorno"), row("Montado y Adorno"))
                End If
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Me.Cursor = Cursors.WaitCursor
        guardar()
        If cmbNave.SelectedValue > 0 Then
            getTodosDatos()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdLotes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdLotes.KeyPress
        If grdLotes.Rows.Count > 0 Then
            Try
                If Not grdLotes.ActiveCell.IsFilterRowCell Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If grdLotes.Rows.Count > 0 Then
            exportarExcel()
        End If
    End Sub
    Public Sub exportarExcel()
        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"
        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grdLotes, fileName)
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkval_CheckedChanged(sender As Object, e As EventArgs) Handles chkval.CheckedChanged
        For Each row As UltraGridRow In grdLotes.Rows
            row.Cells("Seleccion").Value = False
        Next
        If chkval.Checked Then
            For Each row As UltraGridRow In grdLotes.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Embarque").Value.ToString.Length <= 0 Then
                    row.Cells("Seleccion").Value = True
                End If

            Next
        Else
            For Each row As UltraGridRow In grdLotes.Rows.GetFilteredInNonGroupByRows
                If row.Cells("Embarque").Value.ToString.Length <= 0 Then
                    row.Cells("Seleccion").Value = False
                End If
            Next
        End If

    End Sub

    Private Sub cmbCel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCel.SelectedIndexChanged
        Try
            If cmbCel.SelectedValue > 0 Then
                For Each row As UltraGridRow In grdLotes.Rows
                    If CBool(row.Cells("Seleccion").Value) Then
                        If row.Cells("Embarque").Value.ToString.Length <= 0 Then
                            If row.Cells("IdLoteAvancePespunte").Value = 0 Or row.Cells("EstadoPespunte").Value.ToString = "P" Then
                                row.Cells("Pespunte").Value = cmbCel.SelectedValue
                            End If
                        End If

                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbban_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbban.SelectedIndexChanged
        Try
            If cmbban.SelectedValue > 0 Then
                For Each row As UltraGridRow In grdLotes.Rows
                    If CBool(row.Cells("Seleccion").Value) Then
                        If row.Cells("Embarque").Value.ToString.Length <= 0 Then
                            If row.Cells("IdLoteAvanceMontadoyAdorno").Value = 0 Or row.Cells("EstadoMontadoyAdorno").Value.ToString = "P" Then
                                row.Cells("Montado y Adorno").Value = cmbban.SelectedValue
                            End If

                        End If
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub
    Public Sub limpiar()
        Try
            grdLotes.DataSource = Nothing
            cmbNave.SelectedIndex = 0
            dtpFechaInicio.Value = Date.Now
            lblNoLote.Text = 0
            lblNoPares.Text = 0
            lblNoBanda1.Text = 0
            lblNoBanda2.Text = 0
            lblNoCelula1.Text = 0
            lblNoCelula2.Text = 0
            lblNoCelula3.Text = 0
            lbl1Cpares.Text = 0
            lbl2Cpares.Text = 0
            lbl3Cpares.Text = 0
            lbl4Cpares.Text = 0
            lbl1Ppares.Text = 0
            lbl2Ppares.Text = 0
            lbl3Ppares.Text = 0
            lbl4Ppares.Text = 0
        Catch ex As Exception
        End Try
    End Sub
    Public Sub limpiar2()
        Try
            grdLotes.DataSource = Nothing
            dtpFechaInicio.Value = Date.Now
            lblNoLote.Text = 0
            lblNoPares.Text = 0
            lblNoBanda1.Text = 0
            lblNoBanda2.Text = 0
            lblNoCelula1.Text = 0
            lblNoCelula2.Text = 0
            lblNoCelula3.Text = 0
            lbl1Cpares.Text = 0
            lbl2Cpares.Text = 0
            lbl3Cpares.Text = 0
            lbl4Cpares.Text = 0
            lbl1Ppares.Text = 0
            lbl2Ppares.Text = 0
            lbl3Ppares.Text = 0
            lbl4Ppares.Text = 0
        Catch ex As Exception
        End Try
    End Sub
    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        limpiar2()
    End Sub

End Class