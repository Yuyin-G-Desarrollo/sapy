Imports Infragistics.Win.UltraWinGrid

Public Class AñadirClientesFormvb
    Public ListaClientes As New List(Of Entidades.ClientesAlmacen)

    Private Sub AñadirClientesFormvb_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

       

    End Sub

    Private Sub AñadirClientesFormvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objbu As New Negocios.ClientesAlmacenBU
        grdClientes.DataSource = objbu.CargarClientes
        FormatearGrid()
    End Sub

    Private Sub FormatearGrid()
        Dim checkColumn As UltraGridColumn = grdClientes.DisplayLayout.Bands(0).Columns.Add("Seleccionar", "")
        checkColumn.Style = ColumnStyle.CheckBox
        checkColumn.CellActivation = Activation.AllowEdit
        'checkColumn.DataType = GetType(Boolean)
        checkColumn.Header.VisiblePosition = 1
        With grdClientes.DisplayLayout.Bands(0)
            .Columns("idCadena").Hidden = True
            .Columns("nombre").Header.Caption = "Nombre"
        End With
        grdClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If MessageBox.Show("¿Esta seguro que desea realizar los cambios?", "Añadir Clientes ", MessageBoxButtons.YesNo) = DialogResult.Yes Then

            For Each index As UltraGridRow In grdClientes.Rows

                If index.Cells("Seleccionar").Value = True Then
                    Dim cliente As New Entidades.ClientesAlmacen
                    cliente.IDAlmacen = index.Cells("idCadena").Value
                    cliente.NombreAlmacen = index.Cells("Nombre").Value
                    ListaClientes.Add(cliente)

                End If

            Next
            Me.Close()
        End If
    End Sub
End Class