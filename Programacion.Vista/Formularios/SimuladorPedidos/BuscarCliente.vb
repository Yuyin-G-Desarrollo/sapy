Imports Programacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class BuscarCliente

    Public dvwClientes As DataView
    Public idCadena As Int32 = 0
    Public Cadena As String = ""
    Public Listo As Boolean = False




    Private Sub BuscarCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        chk_solo_especiales.Checked = True
        Listo = True
    End Sub



    Private Sub cargarDatos()
        Dim vEspacioReservadoBU As New EspacioReservadoBU
        grdBuscar.DataSource = vEspacioReservadoBU.obtenerClientes(chk_solo_especiales.Checked)
        formatoTabla()
    End Sub

    Public Sub formatoTabla()
        Dim band As UltraGridBand = Me.grdBuscar.DisplayLayout.Bands(0)
        With band
            .Columns("idCadena").CellActivation = Activation.NoEdit
            .Columns("Nombre").CellActivation = Activation.NoEdit
            .Columns("idCadena").CellAppearance.TextHAlign = HAlign.Right
            .Columns("idCadena").Header.Caption = "ID"
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With

        grdBuscar.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdBuscar.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdBuscar.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdBuscar.DisplayLayout.Override.RowSelectorWidth = 35
        grdBuscar.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        band.Columns("idCadena").Width = 35
    End Sub

    Private Sub chk_solo_especiales_CheckedChanged(sender As Object, e As EventArgs) Handles chk_solo_especiales.CheckedChanged
        If Not Listo Then Exit Sub
        cargarDatos()
    End Sub

    Private Sub BuscarCliente_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        cargarDatos()
        Listo = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        With grdBuscar
            If .ActiveRow Is Nothing Or .ActiveRow.Index < 0 Then
                Exit Sub
            Else
                Me.DialogResult = Windows.Forms.DialogResult.OK
                idCadena = grdBuscar.ActiveRow.Cells("idCadena").Value
                Cadena = grdBuscar.ActiveRow.Cells("nombre").Value
                Me.Close()
            End If
        End With

    End Sub

    Private Sub grdBuscar_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdBuscar.BeforeRowsDeleted
        e.Cancel = True
    End Sub
End Class