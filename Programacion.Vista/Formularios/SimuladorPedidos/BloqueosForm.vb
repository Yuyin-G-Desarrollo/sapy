Imports Framework.Negocios
Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class BloqueosForm

    Dim AlturaMaximaPanel As Int32 = 0
    Dim listInicial As New List(Of String)

    Private Sub form_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Dim vAdvertenciaForm As New AdvertenciaForm
        Me.WindowState = FormWindowState.Maximized
        ConfigurarSeguridad()
        vAdvertenciaForm.Text = "Clientes Bloqueados"
        vAdvertenciaForm.mensaje = "Cargando información de los clientes bloqueados, por favor espere…"
        vAdvertenciaForm.ShowDialog()
        InicializaFiltros() ''09052019
        LlenarTabla()
    End Sub
    Private Sub InicializaFiltros()
        chkActivos.Checked = True
        chkInactivos.Checked = False
        chkBloqueados.Checked = True
        chkNoBloqueados.Checked = False
        nudAnio.Value = Year(Today.Date)
        'nudNumSemana.Value = DateDiff(DateInterval.WeekOfYear, New DateTime(Date.Now.Year, 1, 1), Date.Now)
        If Today.Year = 2021 Then
            nudNumSemana.Value = DatePart(DateInterval.WeekOfYear, Today.Date)
            nudNumSemana.Value = nudNumSemana.Value - 1
        Else
            nudNumSemana.Value = DatePart(DateInterval.WeekOfYear, Today.Date)
        End If

        grdClientes.DataSource = listInicial
        grdAgentes.DataSource = listInicial

        grdDatos.DataSource = Nothing

    End Sub

    Private Sub ConfigurarSeguridad()
        'Dim permiso As Boolean

        'permiso = PermisosUsuarioBU.ConsultarPermiso("PRG_AUTORIZAR", "WRITE")
        'btnImportar.Visible = permiso
        'lblAutorizar.Visible = permiso
    End Sub

    Private Sub btnExportarExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportarExcel.Click
        ExportarExcel()
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        importarSICY()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        LlenarTabla()
    End Sub
    Public Sub importarSICY()
        Dim vBloqueo As New BloqueoBU
        Dim vErrorForm As New ErroresForm
        Dim vConfirmarForm As New ConfirmarForm
        Dim vExitoForm As New ExitoForm
        Try
            btnGenerar.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            vConfirmarForm.Text = "Fecha de entrega"
            vConfirmarForm.mensaje = "¿	Desea importar la información de clientes bloqueados de SICY ?"
            Dim vDialogResult As New DialogResult
            vDialogResult = vConfirmarForm.ShowDialog
            If vDialogResult = Windows.Forms.DialogResult.OK Then
                vBloqueo.InsertarSemana()
                LlenarTabla()
                vExitoForm.Text = "Fecha de entrega"
                vExitoForm.mensaje = "Clientes bloqueados importados con éxito"
                vExitoForm.ShowDialog()
            End If

        Catch ex As Exception
            vErrorForm.Text = "Clientes Bloqueados"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
            btnGenerar.Enabled = True
        End Try
    End Sub
    Private Sub LlenarTabla()
        Dim vBloqueo As New BloqueoBU
        Dim vErrorForm As New ErroresForm
        'AGREGAR LOS FITLROS 09052019
        Dim filtros As New Entidades.FiltrosBloqueos
        Dim lClientes As String = String.Empty
        Dim lAgentes As String = String.Empty

        For Each row As UltraGridRow In grdClientes.Rows
            If row.Index = 0 Then
                lClientes += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lClientes += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Index = 0 Then
                lAgentes += " '" + Replace(row.Cells(0).Text, ",", "") + "'"
            Else
                lAgentes += ", '" + Replace(row.Cells(0).Text, ",", "") + "'"
            End If
        Next

        With filtros
            .PActivo = If(chkActivos.Checked, 1, 0)
            .PInactivo = If(chkInactivos.Checked, 1, 0)
            .PBloqueados = If(chkBloqueados.Checked, 1, 0)
            .PNoBloqueados = If(chkNoBloqueados.Checked, 1, 0)
            .PAnio = nudAnio.Value
            .PNoSemana = nudNumSemana.Value
            .PClientes = lClientes
            .PAgentes = lAgentes
        End With

        Try
            Me.Cursor = Cursors.WaitCursor
            grdDatos.DataSource = vBloqueo.tabla(filtros) '09052019
            lblActualiza.Text = "Última actualización: " + Date.Now.ToString()
            formatotabla()
        Catch ex As Exception
            vErrorForm.Text = "Clientes Bloqueados"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ExportarExcel()
        Dim vErrorForm As New ErroresForm
        Dim vExitoForm As New ExitoForm
        Try
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = ".xls"
            sfd.Filter = "*.xls|*.xls"
            If sfd.ShowDialog = System.Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            If sfd.FileName.Trim = "" Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim nombre As String = sfd.FileName
            
            Me.UltraGridExcelExporter1.Export(grdDatos, nombre)
            System.Diagnostics.Process.Start(nombre)

            vExitoForm.Text = "Clientes Bloqueados"
            vExitoForm.mensaje = "Información exportada correctamente"
            vExitoForm.ShowDialog()

        Catch ex As Exception
            vErrorForm.Text = "Clientes Bloqueados"
            vErrorForm.mensaje = ex.Message
            vErrorForm.ShowDialog()
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Public Sub formatotabla()

        Dim band As UltraGridBand = Me.grdDatos.DisplayLayout.Bands(0)
        With band
            .Columns("idCliente").CellActivation = Activation.NoEdit
            .Columns("idSay").CellActivation = Activation.NoEdit
            .Columns("nombre").CellActivation = Activation.NoEdit
            .Columns("Activo").CellActivation = Activation.NoEdit
            .Columns("Agente").CellActivation = Activation.NoEdit
            .Columns("Año").CellActivation = Activation.NoEdit
            .Columns("Semana").CellActivation = Activation.NoEdit
            .Columns("motivo").CellActivation = Activation.NoEdit
            .Columns("Captura").CellActivation = Activation.NoEdit
            .Columns("Programacion").CellActivation = Activation.NoEdit
            .Columns("Entrega").CellActivation = Activation.NoEdit
            .Columns("Contado").CellActivation = Activation.NoEdit
            .Columns("Contado").CellActivation = Activation.NoEdit
            .Columns("bloq_fechamodificacion").CellActivation = Activation.NoEdit
            '.Columns("user_username").CellActivation = Activation.NoEdit
            .Columns("Bloqueado").CellActivation = Activation.NoEdit

            .Columns("PlazoPago").CellActivation = Activation.NoEdit
            .Columns("LimiteCredito").CellActivation = Activation.NoEdit
            .Columns("SaldoTotal").CellActivation = Activation.NoEdit
            .Columns("SaldoVencido").CellActivation = Activation.NoEdit


            .Columns("idCliente").Header.Caption = "ID SICY"
            .Columns("idSay").Header.Caption = "ID SAY"
            .Columns("nombre").Header.Caption = "Cliente" ''"Nombre"
            .Columns("motivo").Header.Caption = "Motivo" '"IDMotivo"
            .Columns("Programacion").Header.Caption = "Programación"
            .Columns("bloq_fechamodificacion").Header.Caption = "ReplicaEnSAY" ''"Modificación"
            '.Columns("user_username").Header.Caption = "Modificó "

            .Columns("PlazoPago").Header.Caption = "Plazo Pago"
            .Columns("LimiteCredito").Header.Caption = "Límite Crédito"
            .Columns("SaldoTotal").Header.Caption = "Saldo Total"
            .Columns("SaldoVencido").Header.Caption = "Saldo Vencido"



            .Columns("idCliente").CellAppearance.TextHAlign = HAlign.Right
            .Columns("idSay").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Año").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Semana").CellAppearance.TextHAlign = HAlign.Right
            '.Columns("motivo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Captura").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Programacion").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Entrega").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Contado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Activo").CellAppearance.TextHAlign = HAlign.Center
            .Columns("Bloqueado").CellAppearance.TextHAlign = HAlign.Center


            .Columns("PlazoPago").CellAppearance.TextHAlign = HAlign.Center
            .Columns("LimiteCredito").CellAppearance.TextHAlign = HAlign.Right
            .Columns("SaldoTotal").CellAppearance.TextHAlign = HAlign.Right
            .Columns("SaldoVencido").CellAppearance.TextHAlign = HAlign.Right

            .Columns("LimiteCredito").Format = "N0"
            .Columns("SaldoTotal").Format = "N0"
            .Columns("SaldoVencido").Format = "N0"

            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        For Each row As UltraGridRow In grdDatos.Rows
            If row.Cells("Activo").Value = "SI" Then
                row.Cells("Activo").Appearance.BackColor = Color.Green
                row.Cells("Activo").Appearance.ForeColor = Color.White
            Else
                row.Cells("Activo").Appearance.BackColor = Color.Red
                row.Cells("Activo").Appearance.ForeColor = Color.White
            End If

            If row.Cells("Bloqueado").Value = "SI" Then
                row.Cells("Bloqueado").Appearance.BackColor = Color.Red
                row.Cells("Bloqueado").Appearance.ForeColor = Color.White
            Else
                row.Cells("Bloqueado").Appearance.BackColor = Color.Green
                row.Cells("Bloqueado").Appearance.ForeColor = Color.White
            End If

            ''MANDAR LOS CEROS A VACÍO Y LOS QUE SI TENGAN DATO PONERLOS EN NARANJA
            If row.Cells("Captura").Value = "0" Then
                row.Cells("Captura").Value = DBNull.Value
            Else
                row.Cells("Captura").Appearance.BackColor = Color.PeachPuff
            End If

            If row.Cells("Programacion").Value = "0" Then
                row.Cells("Programacion").Value = DBNull.Value
            Else
                row.Cells("Programacion").Appearance.BackColor = Color.PeachPuff
            End If

            If row.Cells("Entrega").Value = "0" Then
                row.Cells("Entrega").Value = DBNull.Value
            Else
                row.Cells("Entrega").Appearance.BackColor = Color.PeachPuff
            End If

            If row.Cells("Contado").Value = "0" Then
                row.Cells("Contado").Value = DBNull.Value
            Else
                row.Cells("Contado").Appearance.BackColor = Color.PeachPuff
            End If

        Next


        Dim LimiteCredito As SummarySettings = grdDatos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatos.DisplayLayout.Bands(0).Columns("LimiteCredito"))
        Dim SaldoTotal As SummarySettings = grdDatos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatos.DisplayLayout.Bands(0).Columns("SaldoTotal"))
        Dim SaldoVencido As SummarySettings = grdDatos.DisplayLayout.Bands(0).Summaries.Add(SummaryType.Sum, grdDatos.DisplayLayout.Bands(0).Columns("SaldoVencido"))



        LimiteCredito.DisplayFormat = "{0:#,##0}"
        LimiteCredito.Appearance.TextHAlign = HAlign.Right
        SaldoTotal.DisplayFormat = "{0:#,##0}"
        SaldoTotal.Appearance.TextHAlign = HAlign.Right
        SaldoVencido.DisplayFormat = "{0:#,##0}"
        SaldoVencido.Appearance.TextHAlign = HAlign.Right
     

        grdDatos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"


        grdDatos.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDatos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdDatos.DisplayLayout.Override.RowSelectorWidth = 35
        grdDatos.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
        grdDatos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdDatos.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag


        band.Columns("idCliente").Width = 50
        band.Columns("idSay").Width = 60
        band.Columns("Semana").Width = 60
        band.Columns("motivo").Width = 210'65
        band.Columns("Captura").Width = 65
        band.Columns("Programacion").Width = 105
        band.Columns("Entrega").Width = 60
        band.Columns("Contado").Width = 65
        band.Columns("Año").Width = 50
        band.Columns("Activo").Width = 50
        band.Columns("bloq_fechamodificacion").Width = 150
        'band.Columns("user_username").Width = 100

    End Sub
    Private Sub grdDatos_BeforeRowsDeleted(sender As Object, e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles grdDatos.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdDatos_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdDatos.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next

    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grbFiltros.Visible = False
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grbFiltros.Visible = True
        pnlFiltros.AutoSize = True
    End Sub

    Private Sub btnAgente_Click(sender As Object, e As EventArgs) Handles btnAgente.Click
        Dim listado As New ListadoParametrosReportesForm
        listado.tipo_busqueda = 1

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdAgentes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdAgentes.DataSource = listado.listParametros
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Agente de Ventas"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        Dim listado As New ListadoParametrosReportesForm

        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdClientes.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next

        listado.tipo_busqueda = 2
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdClientes.DataSource = listado.listParametros
        With grdClientes
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Columns(3).Hidden = True
            .DisplayLayout.Bands(0).Columns(5).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True

            .DisplayLayout.Bands(0).Columns(4).Hidden = False

            .DisplayLayout.Bands(0).Columns(4).Header.Caption = "Cliente"
        End With
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        InicializaFiltros()
    End Sub

    Private Sub grdClientes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdClientes.InitializeLayout
        grid_diseño(grdClientes)
        grdClientes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Cliente"
    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        grid_diseño(grdAgentes)
        grdAgentes.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Agente"
    End Sub

    Private Sub grdCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles grdClientes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdClientes.DeleteSelectedRows(False)
    End Sub

    Private Sub grdAgentes_KeyDown(sender As Object, e As KeyEventArgs) Handles grdAgentes.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdAgentes.DeleteSelectedRows(False)
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 20
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
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

    'Asigna formato a columnas de ultragrid
    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns

            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then

                col.Style = ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("Decimal") Then

                col.Style = ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right

            End If

            If col.DataType.Name.ToString.Equals("String") Then

                col.CellAppearance.TextHAlign = HAlign.Left

            End If

        Next
    End Sub

    Private Sub UltraGridExcelExporter1_ExportStarted(sender As Object, e As ExcelExport.ExportStartedEventArgs) Handles UltraGridExcelExporter1.ExportStarted
        Dim ws As Infragistics.Documents.Excel.Worksheet
        ws = e.CurrentWorksheet.Workbook.Worksheets.Add("Tipos de Bloqueo")

        ws.Columns(1).Width = 3 * 256 '20 * 256
        ws.Columns(2).Width = 36 * 256 '20 * 256

        ws.Rows(1).Cells(1).Value = "ID"
        ws.Rows(2).Cells(1).Value = "1"
        ws.Rows(3).Cells(1).Value = "2"
        ws.Rows(4).Cells(1).Value = "3"
        ws.Rows(5).Cells(1).Value = "4"
        ws.Rows(6).Cells(1).Value = "5"
        ws.Rows(7).Cells(1).Value = "6"
        ws.Rows(8).Cells(1).Value = "7"
        ws.Rows(9).Cells(1).Value = "8"

        ws.Rows(1).Cells(2).Value = "Tipo de Bloqueo"
        ws.Rows(2).Cells(2).Value = "VENCIMIENTO DE DOCUMENTOS"
        ws.Rows(3).Cells(2).Value = "PLAZO DE PAGO"
        ws.Rows(4).Cells(2).Value = "CHEQUES DEVUELTOS"
        ws.Rows(5).Cells(2).Value = "SOLO CONTADO"
        ws.Rows(6).Cells(2).Value = "NO SE PUEDE LOCALIZAR"
        ws.Rows(7).Cells(2).Value = "DESCUENTOS IMPROCEDENTES"
        ws.Rows(8).Cells(2).Value = "EXCEDIÓ SU LÍMITE DE CRÉDITO"
        ws.Rows(9).Cells(2).Value = "EXCEDIÓ SU LÍMITE DE CRÉDITO PEDIDOS"

        'e.CurrentWorksheet.Workbook.WindowOptions.SelectedWorksheet = ws
    End Sub

End Class