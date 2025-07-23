Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaNavesForm
    Dim adv As New AdvertenciaForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public idComponente As Integer = 0
    Public Componente As String = ""
    Public listaNavesYaAsginadas As New List(Of Integer)

    Public listaSelecciones As New List(Of Integer)

    Private Sub ListaNavesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerNaves()
        marcarSeleccionadas()
    End Sub

    Public Sub obtenerNaves()
        Dim obj As New catalagosBU
        Dim listaNaves As New DataTable
        listaNaves = obj.listaNavesNoSeleccioandas(listaNavesYaAsginadas)
        grdNaves.DataSource = listaNaves
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdNaves.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Nave").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns(" ").Width = 20
            .Columns("Nave").Width = 200

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        End With
        grdNaves.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Public Sub marcarSeleccionadas()
        For valor = 0 To grdNaves.Rows.Count - 1
            For value = 0 To listaNavesYaAsginadas.Count - 1
                If grdNaves.Rows(valor).Cells("ID").Value = listaNavesYaAsginadas.Item(value) Then
                    grdNaves.Rows(valor).Cells(" ").Value = 1
                End If
            Next
        Next
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        For value = 0 To grdNaves.Rows.Count - 1
            If grdNaves.Rows(value).Cells(" ").Text = 1 Then
                listaSelecciones.Add(grdNaves.Rows(value).Cells("ID").Text)
            End If
        Next
        If listaSelecciones.Count > 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            adv.mensaje = "Seleccione la o las naves"
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        objConfirmacion.mensaje = "¿Está seguro de salir sin seleccionar naves?"
        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Dim bol = objConfirmacion.ShowDialog = Windows.Forms.DialogResult.Yes
            Me.Close()
        End If
    End Sub

End Class