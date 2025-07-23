Imports Infragistics.Win.UltraWinGrid
Imports Infragistics

Public Class ActualizacionMasivaMensajeriasDestinosCostos

    Private Sub ActualizacionMasivaMensajeriasDestinosCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        WindowState = FormWindowState.Maximized
        Dim checkColumn As UltraGridColumn = gridLista.DisplayLayout.Bands(0).Columns.Add("Seleccionar", "")
        checkColumn.DataType = GetType(Boolean)
        checkColumn.Header.VisiblePosition = 2

        cmbReembarque = ControlesEmbarque.ComboTipoEmbarque(cmbReembarque)
        llenarTabla()
        chkSeleccionarTodo.Checked = True
        For Each index As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            index.Cells("Seleccionar").Value = True

        Next
    End Sub


#Region "GRIDS"




    Public Sub llenarTabla()
        Dim objBU As New Negocios.MensajeriaDestinoCostos
        Dim ListaMensajeria As New List(Of Entidades.Mensajeria)
        ListaMensajeria = objBU.ConsultaMensajeriaDestinoCosto()
        Dim TablaTipoReembarque, TablaTipoUnidad As DataTable
        Dim vTipoEmbarque, vTipoUnidad As New Infragistics.Win.ValueList
        TablaTipoReembarque = objBU.ConsultarTipoEmbarque()
        TablaTipoUnidad = objBU.ConsultarTipoUnidad()

        For Each fila As DataRow In TablaTipoReembarque.Rows
            vTipoEmbarque.ValueListItems.Add(fila.Item("tire_tiporeembarqueid"), fila.Item("tire_nombre"))
        Next
        For Each fila As DataRow In TablaTipoUnidad.Rows
            vTipoUnidad.ValueListItems.Add(fila.Item("unid_unidadid"), fila.Item("unid_nombre"))
        Next
        gridLista.DataSource = ListaMensajeria
        gridLista.DataBind()


        ' Me.gridLista.DisplayLayout.Bands(0).Columns.Add("Seleccionar", "Seleccionar")
        With gridLista.DisplayLayout.Bands(0)
            .Columns("PConsecutivo").Header.Caption = "#"
            .Columns("PConsecutivo").Header.VisiblePosition = 0
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PConsecutivo").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
            .Columns("PConsecutivo").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PNombreProveedor").Header.Caption = "Mensajería"
            .Columns("PNombreProveedor").Header.VisiblePosition = 3
            .Columns("PNombreProveedor").CellActivation = Activation.NoEdit
            .Columns("PNombreProveedor").AutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand
            .Columns("PNombrePoblacion").Header.Caption = "Población"
            .Columns("PNombrePoblacion").Header.VisiblePosition = 4
            .Columns("PNombrePoblacion").CellActivation = Activation.NoEdit
            .Columns("PNombreCiudad").Header.Caption = "Ciudad"
            .Columns("PNombreCiudad").Header.VisiblePosition = 5
            .Columns("PNombreCiudad").CellActivation = Activation.NoEdit
            .Columns("PAbrevEstado").Header.Caption = "Estado"
            .Columns("PAbrevEstado").Header.VisiblePosition = 6
            .Columns("PAbrevEstado").CellActivation = Activation.NoEdit
            .Columns("PAbrevPais").Header.Caption = "País"
            .Columns("PAbrevPais").Header.VisiblePosition = 7
            .Columns("PAbrevPais").CellActivation = Activation.NoEdit
            .Columns("PNombreUnidad").Header.Caption = "Unidad"
            .Columns("PNombreUnidad").Header.VisiblePosition = 9
            .Columns("PNombreUnidad").ValueList = vTipoUnidad
            .Columns("PNombreUnidad").CellActivation = Activation.NoEdit
            .Columns("PReembarque").Header.Caption = "Reembarque"
            .Columns("PReembarque").Header.VisiblePosition = 10
            .Columns("PReembarque").ValueList = vTipoEmbarque
            .Columns("PReembarque").CellActivation = Activation.NoEdit
            .Columns("PNombreCiudadPoblacion").Header.Caption = "Ciudad Poblacion"
            .Columns("PNombreCiudadPoblacion").Header.VisiblePosition = 11
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PDiasMinEntregas").Header.Caption = "D. Mín. Entrega"
            .Columns("PDiasMinEntregas").Style = ColumnStyle.Integer
            .Columns("PDiasMinEntregas").Header.VisiblePosition = 12
            .Columns("PDiasMinEntregas").CellActivation = Activation.NoEdit
            .Columns("PDiasMinEntregas").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PDiasMaxEntregas").Header.Caption = "D. Máx. Entrega"
            .Columns("PDiasMaxEntregas").Style = ColumnStyle.Integer
            .Columns("PDiasMaxEntregas").CellActivation = Activation.NoEdit
            .Columns("PDiasMaxEntregas").Header.VisiblePosition = 13
            .Columns("PConsecutivo").CellActivation = Activation.NoEdit
            .Columns("PFechaAlta").Header.Caption = "Fecha de Alta"
            .Columns("PFechaAlta").Header.VisiblePosition = 14
            .Columns("PFechaAlta").CellActivation = Activation.NoEdit
            .Columns("PDiasMaxEntregas").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PCostoUnidad").Header.Caption = "Costo"
            .Columns("PCostoUnidad").MaskInput = "nnn,nnn.nn"
            .Columns("PCostoUnidad").CellAppearance.TextHAlign = Win.HAlign.Right
            .Columns("PCostoUnidad").Header.VisiblePosition = 8
            .Columns("PCostoUnidad").CellActivation = Activation.NoEdit

            .Columns("PIDCostoMensajeria").CellActivation = Activation.NoEdit
            .Columns("PNombreCiudadPoblacion").Hidden = True
            .Columns("PIDCostoMensajeria").Hidden = True
            .Columns("PActivo").Header.Caption = "  Activo"
            .Columns("PActivo").Header.VisiblePosition = 15
            .Columns("PFechaInicioVigencia").Hidden = True
            .Columns("PFechaFinVigencia").Hidden = True
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid
            '.Columns(1).CellActivation = Activation.NoEdit
            '.Columns(1).CellAppearance.TextHAlign = HAlign.Right
            '.Columns(1).Width = 100
        End With
        gridLista.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        gridLista.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.SortMulti
    End Sub

    Private Sub gridLista_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles gridLista.AfterCellUpdate
        If gridLista.Rows.FilterRow.Activated = False Then


        End If

    End Sub

    Private Sub gridLista_AfterRowUpdate(sender As Object, e As RowEventArgs) Handles gridLista.AfterRowUpdate






    End Sub


    Public Sub ActualizacionMasivaUpdate()
        Dim OBJBU As New Negocios.MensajeriaDestinoCostos
        Dim Entidad As New Entidades.Mensajeria
        Dim row As UltraGridRow = gridLista.ActiveRow

        If chkCostoUnidad.Checked = True Then
            Entidad.PCostoUnidad = txtCostoPorUnidad.Text
        Else
            Entidad.PCostoUnidad = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PCostoUnidad").Value
        End If
        If chkMinimo.Checked = True Then
            Entidad.PDiasMinEntregas = numMinimo.Value
        Else
            Entidad.PDiasMinEntregas = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PDiasMinEntregas").Value
        End If
        If chakMaximo.Checked = True Then
            Entidad.PDiasMaxEntregas = numMaximo.Value
        Else
            Entidad.PDiasMaxEntregas = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PDiasMaxEntregas").Value
        End If

        Entidad.PIDCostoMensajeria = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PIDCostoMensajeria").Value






        Entidad.PReembarque = row.Cells("PReembarque").Column.ValueList.GetValue(gridLista.ActiveRow.Cells("PReembarque").Value.ToString, 0)
        Entidad.PNombreUnidad = row.Cells("PNombreUnidad").Column.ValueList.GetValue(gridLista.ActiveRow.Cells("PNombreUnidad").Value.ToString, 0)

        Entidad.PActivo = gridLista.Rows(gridLista.ActiveRow.Index).Cells("PActivo").Value
        OBJBU.ActualizarCostoDestino(Entidad, True)
    End Sub

    Private Sub gridLista_CellChange(sender As Object, e As CellEventArgs) Handles gridLista.CellChange

    End Sub

    Private Sub gridLista_ClickCell(sender As Object, e As ClickCellEventArgs) Handles gridLista.ClickCell

        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub



    Private Sub gridLista_FilterCellValueChanged(sender As Object, e As FilterCellValueChangedEventArgs) Handles gridLista.FilterCellValueChanged

    End Sub

    Private Sub gridLista_FilterRow(sender As Object, e As FilterRowEventArgs) Handles gridLista.FilterRow
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub

    Private Sub gridLista_LostFocus(sender As Object, e As EventArgs) Handles gridLista.LostFocus
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub

    Private Sub gridLista_MouseClick(sender As Object, e As MouseEventArgs) Handles gridLista.MouseClick
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub

    Private Sub gridLista_MouseDown(sender As Object, e As MouseEventArgs) Handles gridLista.MouseDown
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub

    Private Sub gridLista_MouseHover(sender As Object, e As EventArgs) Handles gridLista.MouseHover
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub

    Private Sub gridLista_MouseMove(sender As Object, e As MouseEventArgs) Handles gridLista.MouseMove
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub



    Private Sub gridLista_TextChanged(sender As Object, e As EventArgs) Handles gridLista.TextChanged

    End Sub
#End Region

    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        EnvProcedimiento()
    End Sub


    Public Sub EnvProcedimiento()
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                filter += 1
            End If

        Next
        MsgBox(filter)

    End Sub


    Private Sub chkCostoUnidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkCostoUnidad.CheckedChanged
        If chkCostoUnidad.Checked = True Then
            txtCostoPorUnidad.Enabled = True
        Else
            txtCostoPorUnidad.Enabled = False
        End If
    End Sub

    Private Sub chkMinimo_CheckedChanged(sender As Object, e As EventArgs) Handles chkMinimo.CheckedChanged
        If chkMinimo.Checked = True Then
            numMinimo.Enabled = True
        Else
            numMinimo.Enabled = False
        End If
    End Sub

    Private Sub chkReembarque_CheckedChanged(sender As Object, e As EventArgs) Handles chkReembarque.CheckedChanged
        If chkReembarque.Checked = True Then
            cmbReembarque.Enabled = True
        Else
            cmbReembarque.Enabled = False
        End If
    End Sub

    Private Sub chakMaximo_CheckedChanged(sender As Object, e As EventArgs) Handles chakMaximo.CheckedChanged
        If chakMaximo.Checked = True Then
            numMaximo.Enabled = True
        Else
            numMaximo.Enabled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If numMinimo.Value > numMaximo.Value Then
            MsgBox("El numero minimo de dias de entrega supera al máximo", MsgBoxStyle.Critical)
        Else


            Dim Valor As String

            Valor = InputBox("¿Desea actualizar los registros seleccionados? " + vbCrLf + "Para continuar escriba la palabra ACTUALIZAR" _
                              , "ADVERTENCIA")
            ' If MsgBox("¿Esta completamente seguro que desea modificar los registros?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            If Valor = "ACTUALIZAR" Then
                ActualizacionMasiva()
                llenarTabla()
                For Each index As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
                    index.Cells("Seleccionar").Value = True
                Next
            End If
        End If

        ' End If
    End Sub


    Public Sub ActualizacionMasiva()
        Dim indice As Int32
        indice = 0
        For Each index As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            Dim OBJBU As New Negocios.MensajeriaDestinoCostos
            Dim Entidad As New Entidades.Mensajeria
            Dim row As UltraGridRow
            Dim change As Boolean = False
            row = gridLista.Rows(indice)
            If chkCostoUnidad.Checked = True And txtCostoPorUnidad.Text.Length > 0 Then

                Entidad.PCostoUnidad = txtCostoPorUnidad.Text
                change = True

            Else
                Entidad.PCostoUnidad = gridLista.Rows(indice).Cells("PCostoUnidad").Value
            End If
            If chkMinimo.Checked = True Then
                Entidad.PDiasMinEntregas = numMinimo.Value
                change = True
            Else
                Entidad.PDiasMinEntregas = gridLista.Rows(indice).Cells("PDiasMinEntregas").Value
            End If

            If chakMaximo.Checked = True Then
                Entidad.PDiasMaxEntregas = numMaximo.Value
                change = True
            Else
                Entidad.PDiasMaxEntregas = gridLista.Rows(indice).Cells("PDiasMaxEntregas").Value
            End If

            If chkReembarque.Checked = True And cmbReembarque.SelectedIndex > 0 Then

                Entidad.PReembarque = cmbReembarque.SelectedValue
                change = True
            Else
                Entidad.PReembarque = index.Cells("PReembarque").Column.ValueList.GetValue(gridLista.Rows(indice).Cells("PReembarque").Value.ToString, 0)

            End If

            Entidad.PIDCostoMensajeria = gridLista.Rows(indice).Cells("PIDCostoMensajeria").Value






            Entidad.PNombreUnidad = index.Cells("PNombreUnidad").Column.ValueList.GetValue(gridLista.Rows(indice).Cells("PNombreUnidad").Value.ToString, 0)

            Entidad.PActivo = gridLista.Rows(indice).Cells("PActivo").Value

            If row.IsFilteredOut = False And index.Cells("Seleccionar").Value = True And change = True Then
                OBJBU.ActualizarCostoDestino(Entidad, True)
            End If

            indice += 1
        Next



    End Sub


    Public Function txtNumerico(ByVal txtControl As TextBox, ByVal caracter As Char, ByVal decimales As Boolean) As Boolean
        If (Char.IsNumber(caracter, 0) = True) Or caracter = Convert.ToChar(8) Or caracter = "." Then
            If caracter = "." Then
                If decimales = True Then
                    If txtControl.Text.IndexOf(".") <> -1 Then Return True
                Else : Return True
                End If
            End If
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub txtCostoPorUnidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCostoPorUnidad.KeyPress
        e.Handled = txtNumerico(txtCostoPorUnidad, e.KeyChar, True)
    End Sub

    Private Sub chkReembarque_MouseHover(sender As Object, e As EventArgs) Handles chkReembarque.MouseHover

    End Sub

    Private Sub chkReembarque_MouseUp(sender As Object, e As MouseEventArgs) Handles chkReembarque.MouseUp

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    row.Cells("Seleccionar").Value = False
                Else
                    row.Cells("Seleccionar").Value = True
                End If
            End If
        Next
        Dim filter As New Int32
        filter = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In gridLista.Rows
            If row.IsFilteredOut = False Then
                If row.Cells("Seleccionar").Value = True Then
                    filter += 1
                End If

            End If

        Next
        lblNumFiltrados.Text = (filter)
    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        llenarTabla()
        chkCostoUnidad.Checked = False
        txtCostoPorUnidad.Text = ""
        chkMinimo.Checked = False
        numMinimo.Value = 0
        chkReembarque.Checked = False
        cmbReembarque.SelectedIndex = 0
        chkMinimo.Checked = False
        numMaximo.Value = 0
        chakMaximo.Checked = False
    End Sub


End Class