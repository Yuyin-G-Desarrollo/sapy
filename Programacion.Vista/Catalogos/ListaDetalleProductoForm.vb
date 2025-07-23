Imports System.Net
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ListaDetalleProductoForm
    Dim tituloFoto As String
    Dim idprod As Int32


    Public Sub LlenarTablaDetalles(ByVal idProducto As String, ByVal codigo As String, ByVal descripcion As String,
        ByVal marca As String, ByVal coleccion As String, ByVal temporada As String, ByVal anio As String,
        ByVal subfamilia As String, ByVal foto As String, ByVal dibujo As String, ByVal categoria As String)


        llenarTabla(idProducto)
        lblCodigoNombre.Text = codigo
        lbldescripcionNombre.Text = descripcion
        lblMarcaNombre.Text = marca
        lblColeccionNombre.Text = coleccion
        lblTemporadaNombre.Text = temporada
        lblCategoriaNombre.Text = categoria
        lblSubfamiliaNombre.Text = subfamilia

        Dim objProductoBU As New Negocios.ProductosBU
        Dim datoClienteProp As String

        datoClienteProp = objProductoBU.verClientePropietarioModelo(idProducto)
        If datoClienteProp <> "" Then
            lblNombreCliente.Visible = True
            lblClientePropietario.Visible = True
            lblNombreCliente.Text = datoClienteProp
        End If

        Try
            'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
            'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")

            Dim Carpeta As String = "Programacion/Modelos/"
            Dim objFTP As New Tools.TransferenciaFTP
            Dim StreamFoto As System.IO.Stream
            Dim StreamDibujo As System.IO.Stream


            If (foto <> Nothing) Then
                StreamFoto = objFTP.StreamFile(Carpeta, foto)
                picFoto.Image = Image.FromStream(StreamFoto)
                StreamFoto.Close()
            End If
            If (dibujo <> Nothing) Then
                StreamDibujo = objFTP.StreamFile(Carpeta, dibujo)
                picDibujo.Image = Image.FromStream(StreamDibujo)
            End If
            tituloFoto = foto

            idprod = idProducto

        Catch ex As Exception

        End Try

    End Sub

    Public Sub llenarTabla(ByVal idProducto As String)
        grdListaDetallesProd.DataSource = Nothing
        Dim objPBU As New Programacion.Negocios.ProductosBU
        Dim dtListaDetallesProducto As DataTable
        Dim objHorma As New Programacion.Negocios.HormasBU
        Dim dtDatoHorma As New DataTable
        dtListaDetallesProducto = objPBU.verDetallesProducto(idProducto)
        grdListaDetallesProd.DataSource = dtListaDetallesProducto

        If grdListaDetallesProd.Rows.Count > 0 Then


            grdListaDetallesProd.DisplayLayout.Bands(0).Columns.Add("selectImagen", "")
            grdListaDetallesProd.DisplayLayout.Bands(0).Columns.Add("ImagenLogo", "")
            Dim imgEstilo As UltraGridColumn = grdListaDetallesProd.DisplayLayout.Bands(0).Columns("selectImagen")
            Dim imgLogo As UltraGridColumn = grdListaDetallesProd.DisplayLayout.Bands(0).Columns("ImagenLogo")
            imgEstilo.Style = ColumnStyle.Image
            imgEstilo.CellActivation = Activation.AllowEdit
            imgLogo.Style = ColumnStyle.Image
            imgLogo.CellActivation = Activation.AllowEdit

            With grdListaDetallesProd.DisplayLayout.Bands(0)
                .Columns("selectImagen").Header.Caption = "Imagen"
                .Columns("ImagenLogo").Header.Caption = "Logo Marca"
                .Columns("pres_productoestiloid").Header.Caption = "Id Estilo"
                .Columns("stpr_descripcion").Header.Caption = "Estatus"
                .Columns("piel_descripcion").Header.Caption = "Piel"
                .Columns("color_descripcion").Header.Caption = "Color"
                .Columns("fami_descripcion").Header.Caption = "Familia"
                .Columns("talla_descripcion").Header.Caption = "Corrida"
                .Columns("plmu_descripcion").Header.Caption = "Corte"
                .Columns("forr_descripcion").Header.Caption = "Forro"
                .Columns("suel_descripcion").Header.Caption = "Suela"
                .Columns("horma_descripcion").Header.Caption = "Horma"
                .Columns("pres_codSicy").Header.Caption = "SICY"
                .Columns("linea_descripcion").Header.Caption = "Linea"
                .Columns("pres_imagen").Hidden = True
                .Columns("pres_productoestiloid").Hidden = True
                .Columns("pres_productoestiloid").CellActivation = Activation.NoEdit
                .Columns("piel_descripcion").CellActivation = Activation.NoEdit
                .Columns("color_descripcion").CellActivation = Activation.NoEdit
                .Columns("fami_descripcion").CellActivation = Activation.NoEdit
                .Columns("talla_descripcion").CellActivation = Activation.NoEdit
                .Columns("plmu_descripcion").CellActivation = Activation.NoEdit
                .Columns("forr_descripcion").CellActivation = Activation.NoEdit
                .Columns("suel_descripcion").CellActivation = Activation.NoEdit
                .Columns("horma_descripcion").CellActivation = Activation.NoEdit
                .Columns("pres_codSicy").CellActivation = Activation.NoEdit
                .Columns("linea_descripcion").CellActivation = Activation.NoEdit
                .Columns("stpr_descripcion").CellActivation = Activation.NoEdit
                .Columns("talla_descripcion").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("pres_codSicy").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            End With
            grdListaDetallesProd.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdListaDetallesProd.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdListaDetallesProd.DisplayLayout.Override.RowSelectorWidth = 35
            grdListaDetallesProd.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
            grdListaDetallesProd.Rows(0).Selected = True
        End If
    End Sub

    Private Sub ListaDetalleProductoForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ListaDetalleProductoForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROG_CAT_PROD", "PROD_EDT_IMGEST") Then
            btnCargarImagenesMultiple.Visible = True
            lblSeleccionImagenMultiple.Visible = True
        Else
            btnCargarImagenesMultiple.Visible = False
            lblSeleccionImagenMultiple.Visible = False
        End If
    End Sub


    Private Sub picFoto_DoubleClick(sender As Object, e As EventArgs) Handles picFoto.DoubleClick
        Dim objFotoImagen As New FotoModelo
        objFotoImagen.pcbFotoMax.Image = picFoto.Image
        objFotoImagen.ShowDialog()
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub grdListaDetallesProd_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdListaDetallesProd.BeforeRowsDeleted
        e.Cancel = True
    End Sub

    Private Sub grdListaDetallesProd_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdListaDetallesProd.DoubleClickCell
        If e.Cell.Column.Key = "selectImagen" Then
            Dim objImagen As New agregarImagenEstilo
            Dim dtidEstiloSeleccion As New DataTable
            Dim foto As String = ""
            Dim Descripcion As String
            Dim Renglon As Integer
            dtidEstiloSeleccion.Columns.Add("idEstilo")
            Dim estiloIdRow As DataRow = dtidEstiloSeleccion.NewRow
            estiloIdRow.Item("idEstilo") = grdListaDetallesProd.Rows(e.Cell.Row.Index).Cells("pres_productoestiloid").Value.ToString
            foto = grdListaDetallesProd.Rows(e.Cell.Row.Index).Cells("pres_imagen").Value.ToString
            Renglon = grdListaDetallesProd.ActiveCell.Row.Index.ToString()
            dtidEstiloSeleccion.Rows.Add(estiloIdRow)
            If dtidEstiloSeleccion.Rows.Count > 0 Then
                objImagen.dtEstilosEditarImagen = dtidEstiloSeleccion
                objImagen.codigoProducto = lblCodigoNombre.Text
                objImagen.foto = foto
                objImagen.Descripcion = Descripcion
                objImagen.Renglon = Renglon '12/09/2020
                objImagen.lblTitulo.Text = "Fotografía del Artículo"
                objImagen.Show()
                llenarTabla(idprod)
            End If
        End If

        If e.Cell.Column.Key = "ImagenLogo" Then
            Dim objImagen As New agregarImagenEstilo
            Dim dtidEstiloSeleccion As New DataTable
            Dim foto As String = ""
            Dim Descripcion As String
            dtidEstiloSeleccion.Columns.Add("idEstilo")
            Dim estiloIdRow As DataRow = dtidEstiloSeleccion.NewRow
            estiloIdRow.Item("idEstilo") = grdListaDetallesProd.Rows(e.Cell.Row.Index).Cells("pres_productoestiloid").Value.ToString
            foto = grdListaDetallesProd.Rows(e.Cell.Row.Index).Cells("pres_imagenlogomarcacliente").Value.ToString
            dtidEstiloSeleccion.Rows.Add(estiloIdRow)
            If dtidEstiloSeleccion.Rows.Count > 0 Then
                objImagen.dtEstilosEditarImagen = dtidEstiloSeleccion
                objImagen.codigoProducto = lblCodigoNombre.Text
                objImagen.foto = foto '12/09/2020
                objImagen.lblTitulo.Text = "Logo Marca Cliente"
                objImagen.Show()
                llenarTabla(idprod)
            End If
        End If
    End Sub

    Private Sub grdListaDetallesProd_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdListaDetallesProd.InitializeRow
        If e.Row.Cells.Exists("selectImagen") Then
            e.Row.Cells("selectImagen").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.imagen
        End If
        If e.Row.Cells.Exists("ImagenLogo") Then
            e.Row.Cells("ImagenLogo").Appearance.ImageBackground = Global.Programacion.Vista.My.Resources.Resources.imagen
        End If
    End Sub

    Private Sub btnCargarImagenesMultiple_Click(sender As Object, e As EventArgs) Handles btnCargarImagenesMultiple.Click
        Dim dtFilasSeleccionadas As New DataTable
        dtFilasSeleccionadas.Columns.Add("idEstilo")
        For Each rowDT As UltraGridRow In grdListaDetallesProd.Selected.Rows
            Dim estiloIdRow As DataRow = dtFilasSeleccionadas.NewRow
            estiloIdRow.Item("idEstilo") = rowDT.Cells("pres_productoestiloid").Value.ToString
            dtFilasSeleccionadas.Rows.Add(estiloIdRow)
        Next

        If dtFilasSeleccionadas.Rows.Count > 0 Then
            Dim objImagen As New agregarImagenEstilo
            objImagen.dtEstilosEditarImagen = dtFilasSeleccionadas
            objImagen.codigoProducto = lblCodigoNombre.Text
            objImagen.Show()
            llenarTabla(idprod)
        End If
    End Sub

    Private Sub grdListaDetallesProd_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdListaDetallesProd.InitializeLayout
        Dim valueList As ValueList = e.Layout.FilterOperatorsValueList
        Dim item As ValueListItem
        For Each item In valueList.ValueListItems
            Dim filterOperator As FilterComparisionOperator = DirectCast(item.DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Contains = filterOperator Then
                item.DisplayText = "CONTIENE"
            ElseIf FilterComparisionOperator.DoesNotEndWith = filterOperator Then
                item.DisplayText = "NO TERMINA CON"
            ElseIf FilterComparisionOperator.DoesNotStartWith = filterOperator Then
                item.DisplayText = "NO COMIENZA CON"
            ElseIf FilterComparisionOperator.EndsWith = filterOperator Then
                item.DisplayText = "TERMINA CON"
            ElseIf FilterComparisionOperator.Equals = filterOperator Then
                item.DisplayText = "IGUAL"
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                item.DisplayText = "MAYOR QUE"
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                item.DisplayText = "MAYOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                item.DisplayText = "MENOR QUE"
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                item.DisplayText = "MENOR O IGUAL QUE"
            ElseIf FilterComparisionOperator.NotEquals = filterOperator Then
                item.DisplayText = "DIFERENTE A"
            ElseIf FilterComparisionOperator.StartsWith = filterOperator Then
                item.DisplayText = "COMIENZA CON"
            End If
        Next

        Dim cont As Integer
        For cont = valueList.ValueListItems.Count - 1 To 0 Step -1
            Dim filterOperator As FilterComparisionOperator = DirectCast(valueList.ValueListItems.Item(cont).DataValue, FilterComparisionOperator)
            If FilterComparisionOperator.Custom = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotContain = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.DoesNotMatch = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Like = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.Match = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.NotLike = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.LessThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThan = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            ElseIf FilterComparisionOperator.GreaterThanOrEqualTo = filterOperator Then
                valueList.ValueListItems.RemoveAt(cont)
            End If
        Next
    End Sub

    Private Sub btnLogoMarcaMultiple_Click(sender As Object, e As EventArgs) Handles btnLogoMarcaMultiple.Click
        Dim dtFilasSeleccionadas As New DataTable
        dtFilasSeleccionadas.Columns.Add("idEstilo")
        For Each rowDT As UltraGridRow In grdListaDetallesProd.Selected.Rows
            Dim estiloIdRow As DataRow = dtFilasSeleccionadas.NewRow
            estiloIdRow.Item("idEstilo") = rowDT.Cells("pres_productoestiloid").Value.ToString
            dtFilasSeleccionadas.Rows.Add(estiloIdRow)
        Next

        If dtFilasSeleccionadas.Rows.Count > 0 Then
            Dim objImagen As New agregarImagenEstilo
            objImagen.dtEstilosEditarImagen = dtFilasSeleccionadas
            objImagen.codigoProducto = lblCodigoNombre.Text
            objImagen.lblTitulo.Text = "Logo Marca Cliente"
            objImagen.Show()
            llenarTabla(idprod)
        End If
    End Sub


End Class