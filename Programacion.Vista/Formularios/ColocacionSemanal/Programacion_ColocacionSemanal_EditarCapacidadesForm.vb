Imports DevExpress.XtraGrid
Imports Infragistics.Win
Imports Programacion.Negocios


Public Class Programacion_ColocacionSemanal_EditarCapacidadesForm
    Public tabla As DataTable
    Public año As Integer
    Dim Naves As String = ""
    ReadOnly objExito As New Tools.ExitoForm
    ReadOnly objAdvertencia As New Tools.AdvertenciaForm
    Public accion As Integer = 0 'Accion para editar capacidad

    Private Sub Programacion_ColocacionSemanal_EditarCapacidadesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If accion = 1 Then 'EditarAtr por default es 0 para capacidad
            lblTitulo.Text = "Pares Atrasados Semana / Nave"
            Label2.Text = "Pares ATR:"
            lblTitulo.Location = New Point(lblTitulo.Location.X - 40, lblTitulo.Location.Y)
            Me.Text = "Pares Atrasados Semana / Nave"
        End If
        grdReporte.DataSource = tabla
        DiseñoGrid()

        Dim dtInfo As DataTable = (New MovimientosPPCPBU).ConsultarNavesAux()
        cmbUCNave.DataSource = dtInfo
        cmbUCNave.DisplayMember = "Nave"
        cmbUCNave.ValueMember = "NaveSAYId"

        nudAño.Value = Date.Now.Year
        nudAño.Minimum = Date.Now.Year

        chkGoblal.Checked = tabla.Rows.Count = 0
    End Sub

#Region "Panel de Parametros"

    Private Sub ChkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Dim activo As Boolean = False
        If chkSeleccionar.Checked Then activo = True
        For i = 0 To grdVReporte.RowCount
            grdVReporte.SetRowCellValue(i, " ", activo)
        Next
    End Sub

    Private Sub BtnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim listaFilasSeleccionadas As List(Of Integer) = ObtenerFilasSeleccionadas()
        If listaFilasSeleccionadas.Count > 0 Then
            Dim value As Integer = Integer.Parse(txtCapacidad.Text)
            For Each item As Integer In listaFilasSeleccionadas
                If accion = 0 Then
                    grdVReporte.SetRowCellValue(item, "Capacidad", value)
                Else
                    grdVReporte.SetRowCellValue(item, "ATR", value)
                End If
            Next
        Else
            objAdvertencia.mensaje = "No se ha seleccionado ninguna fila."
            objAdvertencia.ShowDialog()
        End If
    End Sub

    Private Sub ChkGoblal_CheckedChanged(sender As Object, e As EventArgs) Handles chkGoblal.CheckedChanged
        If chkGoblal.Checked Then
            grpboxGlobal.Enabled = True
            btnAsignar.Visible = False
            lblAsignar.Visible = False
            btnGuardar.Enabled = True
        Else
            grpboxGlobal.Enabled = False
            btnAsignar.Visible = True
            lblAsignar.Visible = True
            btnGuardar.Enabled = False
        End If
    End Sub

    Private Sub CmbUCNave_ValueChanged(sender As Object, e As EventArgs) Handles cmbUCNave.ValueChanged
        Dim dtDatosFiltrados As New DataTable

        Dim datosCombo As IList = cmbUCNave.Value
        Dim dtsCmbFiltro As IValueList = cmbUCNave.Items.ValueList

        If datosCombo IsNot Nothing Then
            Naves = ""
            For Each value As Object In datosCombo
                If Naves = "" Then
                    Naves += value.ToString
                Else
                    Naves += "," + value.ToString
                End If
            Next
        Else
            Naves = String.Empty
        End If
    End Sub

#End Region

#Region "Panel de Contenido"

    Private Sub GrdVReporte_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grdVReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub GrdVReporte_RowStyle(sender As Object, e As Views.Grid.RowStyleEventArgs) Handles grdVReporte.RowStyle
        If e.RowHandle >= 0 Then
            Dim Capacidad As Integer = Integer.Parse(grdVReporte.GetRowCellValue(e.RowHandle, "Capacidad"))
            Dim CapacidadOriginal As Integer = Integer.Parse(grdVReporte.GetRowCellValue(e.RowHandle, "CapacidadOriginal"))
            Dim ATR As Integer = Integer.Parse(grdVReporte.GetRowCellValue(e.RowHandle, "ATR"))
            Dim ATROriginal As Integer = Integer.Parse(grdVReporte.GetRowCellValue(e.RowHandle, "ATROriginal"))
            If Capacidad <> CapacidadOriginal Or ATR <> ATROriginal Then
                e.Appearance.ForeColor = Color.DarkViolet
                e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub GrdVReporte_CellValueChanged(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles grdVReporte.CellValueChanged
        If e.RowHandle >= 0 And e.Column.FieldName <> " " Then
            ValidarDatosEditados()
        End If
    End Sub

#End Region

#Region "Panel de Acciones"

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim obj As New Programacion_MapaOcupacionBU

        If chkGoblal.Checked And Naves <> "" And txtCapacidad.Text <> "" Then
            Dim año = CInt(nudAño.Value)
            Dim capacidad = CInt(txtCapacidad.Text)

            obj.EditarCapacidadesSemanaGlobal(Naves, año, capacidad)
        Else
            Dim vXmlCeldasModificadas As XElement = GenerarXML()
            If accion = 0 Then
                obj.EditarCapacidadesSemana(vXmlCeldasModificadas.ToString, año)
            ElseIf accion = 1 Then
                obj.EditarATRSemana(vXmlCeldasModificadas.ToString, año)
            End If
        End If


        objExito.mensaje = "Datos guardados correctamente."
        objExito.ShowDialog()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

#End Region

#Region "Metodos Privados"

    Private Sub DiseñoGrid()
        grdVReporte.OptionsView.ColumnAutoWidth = True
        grdVReporte.OptionsView.EnableAppearanceEvenRow = True
        grdVReporte.OptionsSelection.EnableAppearanceFocusedRow = True
        grdVReporte.IndicatorWidth = 30
        grdVReporte.OptionsView.ShowAutoFilterRow = True
        grdVReporte.OptionsView.RowAutoHeight = True
        grdVReporte.OptionsClipboard.AllowCopy = True

        For Each col As Columns.GridColumn In grdVReporte.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains
            If col.FieldName <> "Capacidad" And col.FieldName <> "ATR" And col.FieldName <> " " Then col.OptionsColumn.AllowEdit = False
            If col.FieldName = " " Then col.OptionsFilter.AllowAutoFilter = False
        Next

        grdVReporte.Columns.ColumnByFieldName("NaveId").Visible = False

        If accion = 0 Then
            grdVReporte.Columns.ColumnByFieldName("Capacidad").Caption = "*Capacidad"
            grdVReporte.Columns.ColumnByFieldName("ATR").Visible = False
        ElseIf accion = 1 Then
            grdVReporte.Columns.ColumnByFieldName("ATR").Caption = "*ATR"
            grdVReporte.Columns.ColumnByFieldName("Capacidad").Visible = False
        End If

        grdVReporte.Columns.ColumnByFieldName("CapacidadOriginal").Visible = False
        grdVReporte.Columns.ColumnByFieldName("ATROriginal").Visible = False
        grdVReporte.BestFitColumns()
    End Sub

    Private Function GenerarXML()
        Dim vXmlCeldasModificadas As New XElement("Celdas")
        For i = 0 To grdVReporte.RowCount - 1
            Dim vNodo As New XElement("Celda")
            vNodo.Add(New XAttribute("NaveId", grdVReporte.GetRowCellValue(i, "NaveId")))
            vNodo.Add(New XAttribute("Capacidad", grdVReporte.GetRowCellValue(i, "Capacidad")))
            vNodo.Add(New XAttribute("ATR", grdVReporte.GetRowCellValue(i, "ATR")))
            vNodo.Add(New XAttribute("Semana", grdVReporte.GetRowCellValue(i, "Semana")))
            vNodo.Add(New XAttribute("UsuarioModificoId", Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid))
            vXmlCeldasModificadas.Add(vNodo)
        Next
        Return vXmlCeldasModificadas
    End Function

    Private Function ObtenerFilasSeleccionadas()
        Dim listaFilasSeleccionadas As New List(Of Integer)

        For i = 0 To grdVReporte.RowCount - 1
            If grdVReporte.GetRowCellValue(i, " ") Then listaFilasSeleccionadas.Add(i)
        Next

        Return listaFilasSeleccionadas
    End Function

    Private Sub ValidarDatosEditados()
        Dim validar As Boolean = False

        For i = 0 To grdVReporte.RowCount - 1
            Dim Capacidad As Integer = Integer.Parse(grdVReporte.GetRowCellValue(i, "Capacidad"))
            Dim CapacidadOriginal As Integer = Integer.Parse(grdVReporte.GetRowCellValue(i, "CapacidadOriginal"))
            Dim ATR As Integer = Integer.Parse(grdVReporte.GetRowCellValue(i, "ATR"))
            Dim ATROriginal As Integer = Integer.Parse(grdVReporte.GetRowCellValue(i, "ATROriginal"))
            If Capacidad <> CapacidadOriginal Or ATR <> ATROriginal Then
                validar = True
            End If
        Next

        btnGuardar.Enabled = validar
    End Sub

#End Region

End Class