Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class listaMaterialesForm

    Public nave As Integer = 0
    Public naveConsulta As Integer = 0
    Public tipoNave As String = String.Empty
    Public MaterialIDReemplazar As Integer = 0
    Public clasificacion As Integer = 0
    Public materialNaveid As Integer = 0
    Public idMaterial As Integer
    Public Material As String = ""
    Public EstatusMAterial As String = ""
    Public UMC As String = ""
    Public SKU As String = ""
    Public idUMC As Integer = 0
    Public accion As String = "" 'Desarrollo,Produccion
    'Public materialNaveID As Integer = 0
    Public idProveedor As Integer = 0
    Public Provedor As String = ""
    Public UMP As String = ""
    Public idUMP As Integer = 0
    Public precio As Double = 0
    Public equivalencia As Double = 0
    Public idClasificacion As Integer = 0
    Public materialNaveid2 As Integer = 0
    Public Clasificacionx As String = ""
    Public cambiosglobalesmaterial As Integer = 0
    Public cambiosglobalesProveedor As Integer = 0
    Public ProductoEstiloID As Integer = 0
    Dim contador = 0
    Public x = 0
    Public componente As Integer = 0
    Public lista As New List(Of Integer)

    Private Sub listaMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        obtenerMateriales()
        If grdMateriales.Rows.Count > 0 Then
            grdMateriales.Focus()
            grdMateriales.Rows(0).Selected = True
        End If
    End Sub

    'Public Sub obtenerMateriales()
    '    Dim obj As New catalagosBU
    '    Dim ListaMateriales As New DataTable
    '    If accion = "Desarrollo" Then
    '        ListaMateriales = obj.listaMaterialesParaDesarrollo(nave, clasificacion)
    '        grdMateriales.DataSource = ListaMateriales
    '        disenioGrid2()
    '    Else
    '        ListaMateriales = obj.listaMateriales(nave, clasificacion, cambiosglobalesmaterial)
    '        grdMateriales.DataSource = ListaMateriales
    '        disenioGrid()
    '    End If
    '    If x = 1 Then
    '        '''Lista de materiales generales filtrados por componente
    '        ListaMateriales = obj.listaMaterialesCompleta(nave, componente, cambiosglobalesmaterial)
    '        grdMateriales.DataSource = ListaMateriales
    '        disenioGrid3()
    '    ElseIf x = 2 Then
    '        '''Lista de materiales en uso en consumos
    '        ListaMateriales = obj.listaMaterialesEnConsumos(nave)
    '        grdMateriales.DataSource = ListaMateriales
    '        disenioGrid3()
    '    End If

    'End Sub

    Public Sub obtenerMateriales()
        Dim obj As New catalagosBU
        Dim ListaMateriales As New DataTable
        Dim EstatusEstilo As String = ""
        If x <> 1 And x <> 2 Then
            EstatusEstilo = obj.GETEstatusProductoEstilo(ProductoEstiloID)

            If tipoNave = "Produccion" Then
                ListaMateriales = CargarDatos(naveConsulta, EstatusEstilo)
            Else
                ListaMateriales = CargarDatos(nave, EstatusEstilo)
            End If
        End If

        If x = 1 Then
            ' '''Lista de materiales generales filtrados por componente
            ListaMateriales = obj.listaMaterialesCompleta(nave, componente, cambiosglobalesmaterial, MaterialIDReemplazar, cambiosglobalesProveedor)
            grdMateriales.DataSource = ListaMateriales
            disenioGrid3()
        ElseIf x = 2 Then
            ' '''Lista de materiales en uso en consumos
            ListaMateriales = obj.listaMaterialesEnConsumos(nave)
            grdMateriales.DataSource = ListaMateriales
            disenioGrid3()
        End If
    End Sub


    Private Function CargarDatos(ByVal pIdNave As Integer, ByVal pEstatusEstilo As String) As DataTable
        Dim ListaMateriales As New DataTable
        Dim obj As New catalagosBU

        If accion = "Desarrollo" Then
            ListaMateriales = obj.listaMaterialesParaDesarrollo(pIdNave, clasificacion, lista, pEstatusEstilo)
            grdMateriales.DataSource = ListaMateriales
            disenioGrid2()
        Else
            ListaMateriales = obj.listaMateriales(pIdNave, clasificacion, cambiosglobalesmaterial, pEstatusEstilo)
            grdMateriales.DataSource = ListaMateriales
            disenioGrid2()
        End If

        Return ListaMateriales

    End Function

    Public Sub disenioGrid2()
        Dim band As UltraGridBand = Me.grdMateriales.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdMateriales.DisplayLayout.Bands(0)
            .Columns("idUnidad").Hidden = True
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("SKU").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Hidden = True
            .Columns("SKU").Width = 80
            .Columns("UMC").Width = 50
            .Columns("Material").Width = 150
            .Columns("IDmn").Hidden = True
            .Columns("idUnidad1").Hidden = True
            .Columns("ID1").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("ID1").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID1").Hidden = True
            .Columns("Precio").Width = 50
            .Columns("UMP").Width = 50
            .Columns("Factor de Conversión").Width = 50
            .Columns("Proveedor").Width = 200
            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("UMP").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Factor de Conversión").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Precio").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("UMC").CellActivation = Activation.NoEdit
            .Columns("Factor de Conversión").CellActivation = Activation.NoEdit
            .Columns("UMP").CellActivation = Activation.NoEdit
            .Columns("mate_autorizado").Hidden = True

            Try
                .Columns("idclass").Hidden = True
                .Columns("Clasificación").CellActivation = Activation.NoEdit
                .Columns("Clasificación").Width = 50
            Catch ex As Exception

            End Try

            .Columns("UMC").Header.Caption = "UMC"
            .Columns("Precio").Header.Caption = "Precio UMC"
            .Columns("Factor de Conversión").Header.Caption = "Factor de" & vbCrLf & "Conversión"

            .Columns("mate_autorizado").Hidden = True

            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellAppearance.TextHAlign = HAlign.Left

        End With
        grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub
    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdMateriales.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdMateriales.DisplayLayout.Bands(0)
            .Columns("idUnidad").Hidden = True
            Try
                .Columns("idclass").Hidden = True
            Catch ex As Exception
            End Try
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Hidden = True
            .Columns("SKU").Width = 80
            .Columns("UMC").Width = 50
            .Columns("Material").Width = 200
            .Columns("IDmn").Hidden = True
            .Columns("SKU").CellActivation = Activation.NoEdit
            '.Columns("Precio").Header.Caption = "Precio UMP"
        End With
        grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub
    Public Sub disenioGrid3()
        With grdMateriales.DisplayLayout.Bands(0)
            .Columns("idUnidad").Hidden = True
            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Hidden = True
            .Columns("idclass").Hidden = True
            .Columns("MaterialNAve").Hidden = True
            .Columns("SKU").Width = 60
            .Columns("UMC").Width = 50
            .Columns("Clasificación").Width = 50
            .Columns("Material").Width = 150
            .Columns("IDmn").Hidden = True
            .Columns("idUnidad1").Hidden = True
            .Columns("ID1").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("ID1").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID1").Hidden = True
            .Columns("Precio").Width = 50
            .Columns("UMP").Width = 50
            .Columns("Factor de Conversión").Width = 70
            .Columns("Proveedor").Width = 200
            .Columns("mate_autorizado").Hidden = True

            .Columns("Factor de Conversión").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Estatus").CellActivation = Activation.NoEdit
            .Columns("Estatus").CellAppearance.TextHAlign = HAlign.Left
            .Columns("Precio").Header.Caption = "Precio UMC"
            .Columns("Factor de Conversión").Header.Caption = "Factor de" & vbCrLf & "Conversión"

        End With
        grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdMateriales.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns        
        'grdMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        grdMateriales.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing


    End Sub
    Private Sub grdmateriales_celldoubleclick(sender As Object, e As EventArgs) Handles grdMateriales.DoubleClickCell
        Try
            If accion = "Desarrollo" Then
                'If grdMateriales.ActiveCell.Column.ToString = "SKU" Or grdMateriales.ActiveCell.Column.ToString = "Material" Then
                idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
                Material = grdMateriales.ActiveRow.Cells("Material").Value
                materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
                UMC = grdMateriales.ActiveRow.Cells("UMC").Value
                SKU = grdMateriales.ActiveRow.Cells("SKU").Value
                idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
                idProveedor = grdMateriales.ActiveRow.Cells("ID1").Value
                Provedor = grdMateriales.ActiveRow.Cells("Proveedor").Value
                UMP = grdMateriales.ActiveRow.Cells("UMP").Value
                precio = grdMateriales.ActiveRow.Cells("Precio").Value
                equivalencia = grdMateriales.ActiveRow.Cells("Factor de Conversión").Value
                idUMP = grdMateriales.ActiveRow.Cells("idUnidad1").Value

                EstatusMAterial = grdMateriales.ActiveRow.Cells("mate_autorizado").Value
                Try
                    materialNaveid = grdMateriales.ActiveRow.Cells("MaterialNAve").Value
                Catch ex As Exception

                End Try
                Try
                    idClasificacion = grdMateriales.ActiveRow.Cells("idclass").Value
                    Clasificacionx = grdMateriales.ActiveRow.Cells("Clasificación").Value
                Catch ex As Exception

                End Try

                Me.Close()
                'End If

            Else
                'If grdMateriales.ActiveCell.Column.ToString = "SKU" Or grdMateriales.ActiveCell.Column.ToString = "Material" Then
                idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
                Material = grdMateriales.ActiveRow.Cells("Material").Value
                materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
                UMC = grdMateriales.ActiveRow.Cells("UMC").Value
                SKU = grdMateriales.ActiveRow.Cells("SKU").Value
                idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
                Try
                    idClasificacion = grdMateriales.ActiveRow.Cells("idclass").Value
                    Clasificacionx = grdMateriales.ActiveRow.Cells("Clasificación").Value
                Catch ex As Exception

                End Try
                Try
                    materialNaveid = grdMateriales.ActiveRow.Cells("MaterialNAve").Value
                Catch ex As Exception

                End Try
                idProveedor = grdMateriales.ActiveRow.Cells("ID1").Value
                Provedor = grdMateriales.ActiveRow.Cells("Proveedor").Value
                UMP = grdMateriales.ActiveRow.Cells("UMP").Value
                precio = grdMateriales.ActiveRow.Cells("Precio").Value
                equivalencia = grdMateriales.ActiveRow.Cells("Factor de Conversión").Value
                idUMP = grdMateriales.ActiveRow.Cells("idUnidad1").Value
                EstatusMAterial = grdMateriales.ActiveRow.Cells("mate_autorizado").Value
                'idClasificacion = grdMateriales.ActiveRow.Cells("idclass").Value
                'Clasificacionx = grdMateriales.ActiveRow.Cells("Clasificación").Value
                Me.Close()
                'End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    'Private Sub grdMateriales_DoubleClick(sender As Object, e As EventArgs) Handles grdMateriales.DoubleClick
    '    Try
    '        If accion = "Desarrollo" Then
    '            If grdMateriales.ActiveCell.Column.ToString = "SKU" Or grdMateriales.ActiveCell.Column.ToString = "Material" Then
    '                idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
    '                Material = grdMateriales.ActiveRow.Cells("Material").Value
    '                materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
    '                UMC = grdMateriales.ActiveRow.Cells("UMC").Value
    '                SKU = grdMateriales.ActiveRow.Cells("SKU").Value
    '                idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
    '                idProveedor = grdMateriales.ActiveRow.Cells("ID1").Value
    '                Provedor = grdMateriales.ActiveRow.Cells("Proveedor").Value
    '                UMP = grdMateriales.ActiveRow.Cells("UMP").Value
    '                precio = grdMateriales.ActiveRow.Cells("Precio").Value
    '                equivalencia = grdMateriales.ActiveRow.Cells("Factor de Conversión").Value
    '                idUMP = grdMateriales.ActiveRow.Cells("idUnidad1").Value
    '                Try
    '                    materialNaveid = grdMateriales.ActiveRow.Cells("MaterialNAve").Value
    '                Catch ex As Exception

    '                End Try
    '                Try
    '                    idClasificacion = grdMateriales.ActiveRow.Cells("idclass").Value
    '                    Clasificacionx = grdMateriales.ActiveRow.Cells("Clasificación").Value
    '                Catch ex As Exception

    '                End Try

    '                Me.Close()
    '            End If

    '        Else
    '            If grdMateriales.ActiveCell.Column.ToString = "SKU" Or grdMateriales.ActiveCell.Column.ToString = "Material" Then
    '                idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
    '                idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
    '                Material = grdMateriales.ActiveRow.Cells("Material").Value
    '                materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
    '                UMC = grdMateriales.ActiveRow.Cells("UMC").Value
    '                SKU = grdMateriales.ActiveRow.Cells("SKU").Value
    '                idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
    '                Try
    '                    idClasificacion = grdMateriales.ActiveRow.Cells("idclass").Value
    '                    Clasificacionx = grdMateriales.ActiveRow.Cells("Clasificación").Value
    '                Catch ex As Exception

    '                End Try
    '                Try
    '                    materialNaveid = grdMateriales.ActiveRow.Cells("MaterialNAve").Value
    '                Catch ex As Exception

    '                End Try
    '                idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
    '                Material = grdMateriales.ActiveRow.Cells("Material").Value
    '                materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
    '                UMC = grdMateriales.ActiveRow.Cells("UMC").Value
    '                SKU = grdMateriales.ActiveRow.Cells("SKU").Value
    '                idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
    '                idProveedor = grdMateriales.ActiveRow.Cells("ID1").Value
    '                Provedor = grdMateriales.ActiveRow.Cells("Proveedor").Value
    '                UMP = grdMateriales.ActiveRow.Cells("UMP").Value
    '                precio = grdMateriales.ActiveRow.Cells("Precio").Value
    '                equivalencia = grdMateriales.ActiveRow.Cells("Factor de Conversión").Value
    '                idUMP = grdMateriales.ActiveRow.Cells("idUnidad1").Value
    '                idClasificacion = grdMateriales.ActiveRow.Cells("idclass").Value
    '                Clasificacionx = grdMateriales.ActiveRow.Cells("Clasificación").Value
    '                Me.Close()
    '            End If
    '        End If

    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub grdMateriales_KeyUp(sender As Object, e As KeyEventArgs) Handles grdMateriales.KeyUp
        Dim valor = 0
        valor = e.KeyValue

        Dim renglon As Integer = 0
        renglon = grdMateriales.Rows.Count
        If valor = 40 Then 'abajo
            If contador = 0 Then
                grdMateriales.Rows(0).Cells("Material").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 38 Then 'arriba
            If contador = 0 Then
                grdMateriales.Rows(0).Cells("Material").Selected = True
                contador = contador + 1
            End If
        ElseIf valor = 13 Then
            Try
                If accion = "Desarrollo" Then
                    idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
                    Material = grdMateriales.ActiveRow.Cells("Material").Value
                    materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
                    UMC = grdMateriales.ActiveRow.Cells("UMC").Value
                    SKU = grdMateriales.ActiveRow.Cells("SKU").Value
                    idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
                    idProveedor = grdMateriales.ActiveRow.Cells("ID1").Value
                    Provedor = grdMateriales.ActiveRow.Cells("Proveedor").Value
                    UMP = grdMateriales.ActiveRow.Cells("UMP").Value
                    precio = grdMateriales.ActiveRow.Cells("Precio").Value
                    equivalencia = grdMateriales.ActiveRow.Cells("Factor de Conversión").Value
                    idUMP = grdMateriales.ActiveRow.Cells("idUnidad").Value

                    Me.Close()
                Else
                    idMaterial = grdMateriales.ActiveRow.Cells("ID").Value
                    Material = grdMateriales.ActiveRow.Cells("Material").Value
                    materialNaveid = grdMateriales.ActiveRow.Cells("IDmn").Value
                    UMC = grdMateriales.ActiveRow.Cells("UMC").Value
                    SKU = grdMateriales.ActiveRow.Cells("SKU").Value
                    idUMC = grdMateriales.ActiveRow.Cells("idUnidad").Value
                    Me.Close()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub grdMateriales_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMateriales.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdMateriales.ActiveRow.Selected = False
                grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
                If grdMateriales.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdMateriales.ActiveRow = nextRow
                    grdMateriales.ActiveRow.Selected = True
                    e.Handled = True
                    grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try

            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdMateriales.ActiveRow.Selected = False
                grdMateriales.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdMateriales.DisplayLayout.Bands(0)
                If grdMateriales.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdMateriales.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdMateriales.ActiveRow = nextRow
                    grdMateriales.ActiveRow.Selected = True
                    e.Handled = True
                    grdMateriales.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdMateriales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdMateriales.ClickCell
        Try
            grdMateriales.ActiveRow.Selected = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub listaMaterialesForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
End Class