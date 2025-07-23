Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaProveedoresForm

    Public idProveedor As Integer = 0
    Public Provedor As String = ""
    Public nave As Integer = 0
    Public materialNaveid As Integer = 0
    Public UMP As String = ""
    Public idUMP As Integer = 0
    Public precio As Double = 0
    Public equivalencia As Double = 0
    Dim contador = 0

    Private Sub ListaProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerProveedores()
    End Sub

    Public Sub obtenerProveedores()
        Dim obj As New catalagosBU
        Dim listaProveedores As New DataTable
        listaProveedores = obj.listaProveedores(nave, materialNaveid)
        grdProveedores.DataSource = listaProveedores
        disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdProveedores.DisplayLayout.Bands(0)
            Try
                .Columns("idUnidad").Hidden = True
            Catch ex As Exception
            End Try
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns("Precio").Width = 50
            .Columns("UMP").Width = 50
            .Columns("Factor de Conversión").Width = 50
            .Columns("Proveedor").Width = 200

            .Columns("Factor de Conversión").Header.Caption = "Factor de" & vbCrLf & "Conversión"
        End With
        grdProveedores.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdProveedores_DoubleClick(sender As Object, e As EventArgs) Handles grdProveedores.DoubleClick
        idProveedor = grdProveedores.ActiveRow.Cells("ID").Value
        Provedor = grdProveedores.ActiveRow.Cells("Proveedor").Value
        UMP = grdProveedores.ActiveRow.Cells("UMP").Value
        precio = grdProveedores.ActiveRow.Cells("Precio").Value
        equivalencia = grdProveedores.ActiveRow.Cells("Factor de Conversión").Value
        idUMP = grdProveedores.ActiveRow.Cells("idUnidad").Value
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdProveedores_KeyUp(sender As Object, e As KeyEventArgs) Handles grdProveedores.KeyUp
        Dim valor = 0
        valor = e.KeyValue

        Dim renglon As Integer = 0
        renglon = grdProveedores.Rows.Count
        If valor = 40 Then 'abajo
            If contador = 0 Then
                grdProveedores.Rows(0).Cells("Proveedor").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 38 Then 'arriba
            If contador = 0 Then
                grdProveedores.Rows(0).Cells("Proveedor").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 13 Then
            Try
                idProveedor = grdProveedores.ActiveRow.Cells("ID").Value
                Provedor = grdProveedores.ActiveRow.Cells("Proveedor").Value
                UMP = grdProveedores.ActiveRow.Cells("UMP").Value
                precio = grdProveedores.ActiveRow.Cells("Precio").Value
                equivalencia = grdProveedores.ActiveRow.Cells("Factor de Conversión").Value
                idUMP = grdProveedores.ActiveRow.Cells("idUnidad").Value
                Me.Close()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ListaProveedoresForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class