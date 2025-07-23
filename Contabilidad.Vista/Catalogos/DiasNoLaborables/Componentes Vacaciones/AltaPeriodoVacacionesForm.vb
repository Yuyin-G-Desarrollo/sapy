Imports System.Drawing
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class AltaPeriodoVacacionesForm

    Public itemn As Integer
    Private Sub AltaPeriodoVacacionesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFISS.Value = Date.Now
        dtpFFN.Value = Date.Now
        dtpFIN.Value = Date.Now
        dtpFFSS.Value = Date.Now
        dtpFISS.MinDate = Date.Now
        dtpFFN.MinDate = Date.Now
        dtpFIN.MinDate = Date.Now
        dtpFFSS.MinDate = Date.Now
        llenarcomboFechas()
        For index = 0 To cmbAnio.Items.Count - 1
            Dim anio As String = Date.Now.Year
            If cmbAnio.Items.Item(index).Value.Equals(anio) Then
                cmbAnio.SelectedIndex = index

            End If
        Next
    End Sub

    Public Sub llenarcomboFechas()
        Dim valoresCombo As New System.Collections.Generic.Dictionary(Of Integer, String)
        Dim anioActual As Integer = Date.Now.Year

        For index = anioActual To anioActual + 4

            Dim fecha = Convert.ToString(index)
            valoresCombo.Add(index, fecha)
        Next
        cmbAnio.DisplayMember = "Value"
        cmbAnio.ValueMember = "Key"
        cmbAnio.DataSource = valoresCombo.ToArray

    End Sub


    Public Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty

        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += " " + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += ", " + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next

        Return Resultado
    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim entidad As New Entidades.DiasNoLaborales
        Dim Filtropatrones As String = String.Empty
        Filtropatrones = ObtenerFiltrosGrid(grdFiltroCliente)

        If Date.Compare(dtpFISS.Value.ToShortDateString, dtpFFSS.Value.ToShortDateString) >= 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor que la fin.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If

        If cmbAnio.Text <> dtpFISS.Value.Year Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text)
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If cmbAnio.Text <> dtpFFSS.Value.Year Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text)
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If

        If cmbAnio.Text <> dtpFIN.Value.Year Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text)
            lblN.ForeColor = Drawing.Color.Red
            Return
        Else
            lblN.ForeColor = Drawing.Color.Black
        End If
        If cmbAnio.Text <> dtpFFN.Value.Year Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Seleciona una fecha del año" + " " + cmbAnio.Text)
            lblN.ForeColor = Drawing.Color.Red
            Return
        Else
            lblN.ForeColor = Drawing.Color.Black
        End If

        If Date.Compare(dtpFISS.Value.ToShortDateString, dtpFIN.Value.ToShortDateString) >= 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de semana santa no puede ser mayor a la de navidad.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If Date.Compare(dtpFFSS.Value.ToShortDateString, dtpFFN.Value.ToShortDateString) >= 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de semana santa no puede ser mayor a la de navidad.")
            lblSS.ForeColor = Drawing.Color.Red
            Return
        Else
            lblSS.ForeColor = Drawing.Color.Black
        End If
        If Date.Compare(dtpFIN.Value.ToShortDateString, dtpFFN.Value.ToShortDateString) >= 0 Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "La fecha de inicio no puede ser mayor que la fin.")
            lblN.ForeColor = Drawing.Color.Red
            Return
        Else
            lblN.ForeColor = Drawing.Color.Black
        End If
        If Filtropatrones = String.Empty Then
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, "Selecciona por lo menos un patron")
            Return

        End If
        entidad.Mensaje = Filtropatrones
        entidad.FechaISS = dtpFISS.Value
        entidad.FechaFSS = dtpFFSS.Value
        entidad.FechaIN = dtpFIN.Value
        entidad.FechaFN = dtpFFN.Value
        entidad.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        entidad.Anio = cmbAnio.Text
        insertarPeriodo(entidad)
    End Sub

    Private Sub insertarPeriodo(ByVal entidad As Entidades.DiasNoLaborales)

        Try
            Dim ObjB2 As New Contabilidad.Negocios.CatalogoDiasNoLaboralesBU
            Dim success = ObjB2.InsertarVacaciones(entidad)
            If success.Resp > 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, success.Mensaje)
                Me.Close()
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, success.Mensaje)
            End If
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Advertencia, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnAgregarFiltroCliente.Click
        Dim listado As New FiltroPatronesForm
        'listado.tipo_busqueda = 1
        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In grdFiltroCliente.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdFiltroCliente.DataSource = listado.listParametros
        With grdFiltroCliente
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True

            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Patron"
        End With
        grid_diseño(grdFiltroCliente)
    End Sub
    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            '.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

    End Sub

    Private Sub btnLimpiarFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroCliente.Click
        grdFiltroCliente.DataSource = Nothing
    End Sub
End Class