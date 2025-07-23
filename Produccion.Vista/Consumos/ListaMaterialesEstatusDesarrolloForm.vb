Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ListaMaterialesEstatusDesarrolloForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Public materialid As Integer
    Public materialnaveid As Integer
    Public productoEstiloId As Integer
    Public listaMaterialesEstatusDesarrollo As DataTable
    Public nave As String = ""

    Public listaMaterialesAutorizar As New List(Of Integer)

    Private Sub ListaMaterialesEstatusDesarrolloForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grdMateriales.DataSource = listaMaterialesEstatusDesarrollo
        DisenioListaMateriales()
    End Sub

    Public Sub listaMateriales()
        Dim obj As New catalagosBU
        Dim tablaMateriales As New DataTable
        tablaMateriales = obj.ListaMaterialesConsumosProductoEstilo(productoEstiloId)
        grdMateriales.DataSource = tablaMateriales
    End Sub

    Public Sub DisenioListaMateriales()
        With grdMateriales.DisplayLayout.Bands(0)

            .Columns("ID").Hidden = True

            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("SKU").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit

            .Columns("Material").Width = 120
            .Columns("SKU").Width = 40
            .Columns(" ").Width = 10
            .Columns("Proveedor").Width = 120
            .Columns("Id Producto Estilo").Width = 40
            .Columns("Id Producto Estilo").Header.Caption = "Prod Estilo"

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdMateriales.Rows.Count - 1
                grdMateriales.Rows(value).Cells(" ").Value = False
            Next

        End With
        grdMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        objConfirmacion.mensaje = "¿Está seguro de salir sin autorizar materiales?"
        objConfirmacion.StartPosition = FormStartPosition.CenterScreen
        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        Dim obj As New catalagosBU
        Dim contador As Integer = 0
        Dim tablas As New DataTable
        Dim lista As New List(Of Integer)
        Dim d As New DataTable
        Dim advertencia As New AdvertenciaForm
        Dim auxiliar As Integer = 0
        For value = 0 To grdMateriales.Rows.Count - 1
            If grdMateriales.Rows(value).Cells(" ").Value = True Then
                contador = contador + 1
            End If
        Next

        Try
            If contador > 0 Then
                objConfirmacion.mensaje = "¿Está seguro de autorizar el material?"
                If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                    For value = 0 To grdMateriales.Rows.Count - 1
                        If grdMateriales.Rows(value).Cells(" ").Value = True Then
                            listaMaterialesAutorizar.Add(CInt(grdMateriales.Rows(value).Cells("ID").Text))
                            contador = contador + 1
                        End If
                        'RECUPERAR IDMATERIALNAVE PARA VERIFICAR QUE TODOS TENGAN PRECIOS Y NOTIFICAR QUE ALGUNOS MATERIALES
                        For value3 = 0 To listaMaterialesAutorizar.Count - 1
                            d = obj.validarPrecioActivoMaterialNave(CInt(grdMateriales.Rows(value3).Cells("ID").Text))
                            If Not d.Rows.Count > 0 Then
                                advertencia.mensaje = "Algunos materiales no pueden estar en producción si no cuentan con un precio capturado, verifique los materiales del artículo."
                                advertencia.StartPosition = FormStartPosition.CenterScreen
                                advertencia.ShowDialog()
                                Me.Close()
                            End If
                        Next

                        tablas = obj.ListaMAterialesNaveObtenerMaterialID(listaMaterialesAutorizar)
                        For value2 = 0 To tablas.Rows.Count - 1
                            lista.Add(tablas.Rows(value2).Item("ID"))
                        Next
                    Next
                    obj.EstatusProduccionMateriales(lista)
                    If contador > 0 Then
                        objExito.mensaje = "Se Autorizaron " & lista.Count & " materiales a Producción de " & lista.Count & " seleccionados"
                        objExito.StartPosition = FormStartPosition.CenterScreen
                        objExito.ShowDialog()
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                Else

                End If
            Else
                objAdvertencia.mensaje = "Debe seleccionar algun material para poderlo autorizar"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
                btnSeleccionar.DialogResult = Windows.Forms.DialogResult.No
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub validarSeleccion()
        Try
            If grdMateriales.ActiveRow.Cells(" ").IsActiveCell And grdMateriales.ActiveRow.Cells("Nave Desarrolla").Text = nave Then
                grdMateriales.ActiveRow.Cells(" ").Value = 0
            Else
                objAdvertencia.mensaje = "No puede seleccionar este material para autorizarlo. Favor de ponerse en contacto con la nave que lo desarrolla"
                objAdvertencia.StartPosition = FormStartPosition.CenterScreen
                objAdvertencia.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdMateriales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdMateriales.ClickCell
        validarSeleccion()
    End Sub

End Class