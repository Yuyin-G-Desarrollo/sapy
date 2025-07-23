Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win

Public Class ListaModelosImportarConsumoFraccionForm
    Dim idMarca As Integer = 0
    Dim idColecc As Integer = 0
    Dim adv As New AdvertenciaForm
    Public nave As String = ""
    Public idNave As Integer = 0
    Public productoestiloid As Integer = 0
    Public articulo As Integer = 0
    Dim id As Integer = 0
    Public NaveDesarrollaId As Integer = 0
    Public listaComponentesCopiados As New List(Of Integer)
    Public listaFraccionesCopiadas As New List(Of Integer)
    Public TablaFracciones As DataTable
    Public EsAlta As Boolean = False
    Public IdNaveAlta As Integer = -1


    Private Sub ListaModelosImportarConsumoFraccionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenarGrid()
        llenarComoboMarcas2(idNave)
    End Sub

    Public Sub llenarComoboMarcas2(ByVal nave As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaDeMarcas(nave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "ID"
        End If
    End Sub

    Private Sub llenarGrid()
        Dim obj As New catalagosBU
        If cmbMarca.Text = "" Then
            idMarca = 0
        Else
            idMarca = cmbMarca.SelectedValue
        End If
        If cmbColeccion.Text = "" Then
            idColecc = 0
        Else
            idColecc = cmbColeccion.SelectedValue
        End If
        grdListado.DataSource = obj.VerListaProductosImportarConsumos2(idNave, idMarca, idColecc, articulo)
        OcultarFraccionesEnCero()
        Try
            disenioGridCopiarConsumos()
            'grdListado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        Catch ex As Exception
        End Try
        'disenioGrid()
    End Sub

    Public Sub OcultarFraccionesEnCero()
        Dim Ocultar As Boolean = False

        If EsAlta = True Then
            Ocultar = True
        Else
            If NaveDesarrollaId = idNave Then
                Ocultar = True
            Else
                Ocultar = False
            End If

        End If
        
        For Each Fila As UltraGridRow In grdListado.Rows
            If Ocultar = False Then
                If Fila.Cells("Total Fracciones").Text = "" Then
                    Fila.Hidden = True
                End If
                If IsNumeric(Fila.Cells("Total Fracciones").Text) = True Then
                    If CDbl(Fila.Cells("Total Fracciones").Text) = 0.0 Then
                        Fila.Hidden = True
                    End If
                End If

            Else
                If Fila.Cells("Total Fracciones").Text = "" And Fila.Cells("Total Materiales").Text = "" Then
                    Fila.Hidden = True
                End If

            End If
        Next
    End Sub

    Public Sub disenioGridCopiarConsumos()
        Dim band As UltraGridBand = Me.grdListado.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdListado.DisplayLayout.Bands(0)

            .Columns("Ruta").Hidden = True
            .Columns("Imagen").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
            .Columns("Imagen").Width = 130
            If Not chkImag.Checked Then
                .Columns("Imagen").Hidden = True
            Else
                .Columns("Imagen").Hidden = False
            End If

            grdListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            If chkImag.Checked Then
                With grdListado.DisplayLayout.Rows(0)
                    .Height = 70
                End With
            Else
                With grdListado.DisplayLayout.Rows(0)
                    .Height = 20
                End With
            End If

            .Columns("Código").CellActivation = Activation.NoEdit
            .Columns("Colección").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Total Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Fracciones").CellActivation = Activation.NoEdit
            .Columns("Asignación Producción").CellActivation = Activation.NoEdit
            .Columns("status").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit

            .Columns("Color").Hidden = True
            .Columns("Color").Hidden = True
            .Columns("Piel").Hidden = True
            .Columns("EstiloID").Hidden = True
            .Columns("status").Hidden = True
            .Columns("pres_productoestiloid").Hidden = True
            .Columns("NaveID").Hidden = True
            .Columns("ProductoNaveId").Hidden = True
            '.Columns("Total Fracciones").Hidden = True
            '.Columns("Fecha Asignación").Hidden = True

            .Columns("Código").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Fracciones").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Modelo SICY").CellAppearance.TextHAlign = HAlign.Right

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns(" ").Hidden = True
            '.Columns("EstiloID").Width = 50
            .Columns("Código").Width = 95
            .Columns("Colección").Width = 100
            .Columns("Modelo").Width = 50
            .Columns("Piel").Width = 60
            .Columns("Color").Width = 60
            .Columns("Corrida").Width = 80
            .Columns("Total Materiales").Width = 90
            .Columns("Total Fracciones").Width = 90
            .Columns("Asignación Producción").Width = 150
            .Columns("Estatus").Width = 20
            .Columns("Cliente").Width = 150
            .Columns("Piel Color").Width = 150

            .Columns("Estatus").Header.Caption = ""
            .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
            .Columns("Total Fracciones").Header.Caption = "Total" & vbCrLf & "Fracciones"
            .Columns("Asignación Producción").Header.Caption = "Asignación" & vbCrLf & " Producción"
            .Columns("Modelo").Header.Caption = "Código"
            .Columns("Código").Header.Caption = "SICY"
            .Columns("Código").CellAppearance.TextHAlign = HAlign.Left
            .Columns("Total Materiales").Format = "##,##0.00"
            .Columns("Total Fracciones").Format = "##,##0.000"

            For value = 0 To grdListado.Rows.Count - 1
                If grdListado.Rows(value).Cells("status").Text = "DESARROLLO" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")

                ElseIf grdListado.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")

                ElseIf grdListado.Rows(value).Cells("status").Text = "AUTORIZADO PRODUCCIÓN" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")

                ElseIf grdListado.Rows(value).Cells("status").Text = "INACTIVO NAVE" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000")

                ElseIf grdListado.Rows(value).Cells("status").Text = "DESCONTINUADO" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")

                End If
            Next

            For value = 0 To grdListado.Rows.Count - 1
                grdListado.Rows(value).Cells("Piel Color").Value = grdListado.Rows(value).Cells("Piel").Value + " " + grdListado.Rows(value).Cells("Color").Value
            Next
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListado.DisplayLayout.Bands(0).Columns("Total Materiales").Width = 100
        grdListado.DisplayLayout.Bands(0).Columns("Asignación Producción").Width = 100

    End Sub

    Public Sub disenioGrid()
        Dim band As UltraGridBand = Me.grdListado.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdListado.DisplayLayout.Bands(0)
            '.Columns("prod_productoid").Hidden = True
            '.Columns("prod_modelo").Header.Caption = "Modelo"

            '.Columns("productoEstiloId").Hidden = True
            '.Columns("pres_productoid").Hidden = True
            '.Columns("espr_estiloproductoid").Hidden = True
            '.Columns("idMarca").Hidden = True
            '.Columns("idColeccion").Hidden = True
            '.Columns("idPiel").Hidden = True
            '.Columns("idColor").Hidden = True
            '.Columns("idCliente").Hidden = True
            '.Columns("idTalla").Hidden = True
            .Columns("Ruta").Hidden = True
            .Columns("Imagen").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
            .Columns("Imagen").Width = 130
            If Not chkImag.Checked Then
                .Columns("Imagen").Hidden = True
            Else
                .Columns("Imagen").Hidden = False
            End If

            grdListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            If chkImag.Checked Then
                With grdListado.DisplayLayout.Rows(0)
                    .Height = 70
                End With
            Else
                With grdListado.DisplayLayout.Rows(0)
                    .Height = 20
                End With
            End If

            .Columns("Código").CellActivation = Activation.NoEdit
            .Columns("Colección").CellActivation = Activation.NoEdit
            .Columns("Modelo").CellActivation = Activation.NoEdit
            .Columns("Piel").CellActivation = Activation.NoEdit
            .Columns("Color").CellActivation = Activation.NoEdit
            .Columns("Corrida").CellActivation = Activation.NoEdit
            .Columns("Total Materiales").CellActivation = Activation.NoEdit
            .Columns("Total Fracciones").CellActivation = Activation.NoEdit
            .Columns("Asignación Producción").CellActivation = Activation.NoEdit
            .Columns("status").CellActivation = Activation.NoEdit
            .Columns("Cliente").CellActivation = Activation.NoEdit
            .Columns("Marca").CellActivation = Activation.NoEdit

            .Columns("Color").Hidden = True
            .Columns("Color").Hidden = True
            .Columns("Piel").Hidden = True
            .Columns("EstiloID").Hidden = True
            .Columns("status").Hidden = True
            .Columns("Total Fracciones").Hidden = True
            '.Columns("Fecha Asignación").Hidden = True

            .Columns("Código").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Modelo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Corrida").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Materiales").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Fracciones").CellAppearance.TextHAlign = HAlign.Right
            .Columns("NaveID").Hidden = True
            .Columns("ProductoNaveId").Hidden = True
            '.Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            '.Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            '.Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            '.Columns(" ").Width = 10
            '.Columns("EstiloID").Width = 50
            .Columns("Código").Width = 50
            .Columns("Colección").Width = 100
            .Columns("Modelo").Width = 50
            .Columns("Piel").Width = 60
            .Columns("Color").Width = 60
            .Columns("Corrida").Width = 80
            .Columns("Total Materiales").Width = 90
            .Columns("Total Fracciones").Width = 90
            .Columns("Asignación Producción").Width = 150
            .Columns("Estatus").Width = 20
            .Columns("Cliente").Width = 150
            .Columns("Piel Color").Width = 150

            .Columns("Estatus").Header.Caption = ""
            .Columns("Total Materiales").Header.Caption = "Total" & vbCrLf & "Materiales"
            .Columns("Total Fracciones").Header.Caption = "Total" & vbCrLf & "Fracciones"
            .Columns("Asignación Producción").Header.Caption = "Asignación" & vbCrLf & " Producción"

            .Columns("Total Materiales").Format = "##,##0.00"
            .Columns("Total Fracciones").Format = "##,##0.00"

            For value = 0 To grdListado.Rows.Count - 1
                If grdListado.Rows(value).Cells("status").Text = "DESARROLLO" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")

                ElseIf grdListado.Rows(value).Cells("status").Text = "AUTORIZADO DESARROLLO" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")

                ElseIf grdListado.Rows(value).Cells("status").Text = "AUTORIZADO PRODUCCIÓN" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")

                ElseIf grdListado.Rows(value).Cells("status").Text = "INACTIVO NAVE" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF8000")

                ElseIf grdListado.Rows(value).Cells("status").Text = "DESCONTINUADO" Then
                    grdListado.Rows(value).Cells("Estatus").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")

                End If
            Next

            For value = 0 To grdListado.Rows.Count - 1
                grdListado.Rows(value).Cells("Piel Color").Value = grdListado.Rows(value).Cells("Piel").Value + " " + grdListado.Rows(value).Cells("Color").Value
            Next
            '.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdListado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdListado.DisplayLayout.Bands(0).Columns("Total Materiales").Width = 100
        grdListado.DisplayLayout.Bands(0).Columns("Asignación Producción").Width = 100

    End Sub
    Public Sub llenarComoboMarcas(ByVal nave As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaMarcasImportarConsumos(nave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "ID"
        End If
    End Sub
    Public Sub llenarComboColeccion(ByVal nave As Integer, ByVal marca As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaColecciones(nave, marca)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccion.DataSource = lista
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "ID"
        End If
    End Sub
    Private Sub grdListado_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdListado.DoubleClickCell
        If grdListado.ActiveRow.Index > -1 Then
            Try
                If grdListado.ActiveCell.Column.ToString = "Imagen" Then
                    If grdListado.ActiveRow.Cells("Ruta").Text.Length > 0 Then
                        'Process.Start(grdListado.ActiveRow.Cells("Ruta").Text)
                        Dim form As New ImagenEstiloForm
                        form.imagen = grdListado.ActiveRow.Cells("Ruta").Text
                        form.ShowDialog()
                    End If
                Else
                    grdListado.ActiveRow.Selected = True
                End If
            Catch ex As Exception
                adv.mensaje = "No se puede localizar el archivo."
                adv.StartPosition = FormStartPosition.CenterScreen
                adv.ShowDialog()
            End Try
        End If
    End Sub

    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        cmbColeccion.SelectedValue = 0
        grdListado.DataSource = Nothing
        Try
            If cmbMarca.SelectedIndex > -1 Then
                idMarca = cmbMarca.SelectedValue
                llenarComboColeccionNaveDesarrolla(idNave, idMarca)
            End If
        Catch ex As Exception
            idMarca = 0
        End Try

    End Sub

    Public Sub llenarComboColeccionNaveDesarrolla(ByVal nave As Integer, ByVal marca As Integer)
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaColeccionesNaveDesarrolla(nave, marca)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbColeccion.DataSource = lista
            cmbColeccion.DisplayMember = "Coleccion"
            cmbColeccion.ValueMember = "ID"
        End If
    End Sub

    Private Sub cmbColeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccion.SelectedIndexChanged
        grdListado.DataSource = Nothing
        Try
            If cmbColeccion.SelectedIndex > -1 Then
                idColecc = cmbColeccion.SelectedValue
            End If
        Catch ex As Exception
            idColecc = 0

        End Try

    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If grdListado.Rows.Count > 0 Then
            If id <> 0 Then
                If grdListado.ActiveRow.Selected Then
                    Dim form As New CopiarConsumosFraccionesForm
                    form.productoEstiloId = grdListado.ActiveRow.Cells("EstiloID").Value
                    form.modelo = grdListado.ActiveRow.Cells("Modelo").Value
                    productoestiloid = grdListado.ActiveRow.Cells("EstiloID").Value
                    form.idNaveProduccion = grdListado.ActiveRow.Cells("NaveID").Value
                    form.NaveDesarrollaId = NaveDesarrollaId
                    form.NaveIDConsulta = idNave
                    form.EsAltaProducto = EsAlta
                    form.IdNaveAlta = IdNaveAlta
                    'form.PRoductoNaveID = grdListado.ActiveRow.Cells("ProductoNaveId").Value

                    form.accion = "Desarrollo"
                    If form.ShowDialog = Windows.Forms.DialogResult.OK Then
                        listaComponentesCopiados = form.listaComponentesCopiados
                        listaFraccionesCopiadas = form.listaFraccionesCopiadas
                        TablaFracciones = form.TABLA
                        DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
            Else
                adv.mensaje = "Seleccione un artículo"
                adv.StartPosition = FormStartPosition.CenterScreen
                adv.ShowDialog()
            End If

        End If
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbMarca.Text = "" Then
            adv.mensaje = "Seleccione una marca"
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        Else
            llenarGrid()
        End If

    End Sub

    Private Sub grdListado_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdListado.ClickCell
        If grdListado.ActiveRow.Index > -1 Then
            Try
                grdListado.ActiveRow.Selected = True
            Catch ex As Exception
                adv.mensaje = "No se puede localizar el archivo."
                adv.StartPosition = FormStartPosition.CenterScreen
                adv.ShowDialog()
            End Try
        End If

        Try
            id = grdListado.ActiveRow.Cells("EstiloID").Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdListado_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListado.InitializeRow
        If chkImag.Checked Then
            Dim imagen As System.Drawing.Image
            Dim StreamFoto As System.IO.Stream
            Dim objFTP As New Tools.TransferenciaFTP
            Dim Carpeta As String = "Programacion/Modelos/"

            Me.Cursor = Cursors.WaitCursor
            If e.Row.Cells.Exists("Imagen") Then
                e.Row.Cells("Imagen").Appearance.ImageBackground = Global.Produccion.Vista.My.Resources.Resources.imagen
            End If

            If e.Row.Cells.Exists("Imagen") Then
                e.Row.Cells("Imagen").Appearance.BackColor = Color.White
                Try
                    If IsDBNull(e.Row.Cells("Imagen")) = False Then
                        imagen = Nothing

                        If (e.Row.Cells("ruta").Value.ToString <> Nothing) Then
                            StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("Ruta").Value.ToString)
                            imagen = System.Drawing.Image.FromStream(StreamFoto)
                            e.Row.Cells("Imagen").Appearance.ImageBackground = imagen
                        End If
                    End If

                Catch ex As Exception
                    Try
                        StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("Ruta").Value.ToString)
                        imagen = System.Drawing.Image.FromStream(StreamFoto)

                        e.Row.Cells("Imagen").Appearance.ImageBackground = imagen
                    Catch exe As Exception

                    End Try
                End Try
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiat_Click(sender As Object, e As EventArgs) Handles btnLimpiat.Click
        cmbColeccion.SelectedValue = 0
        cmbMarca.SelectedValue = 0
        grdListado.DataSource = Nothing
        chkImag.Checked = False
    End Sub
End Class