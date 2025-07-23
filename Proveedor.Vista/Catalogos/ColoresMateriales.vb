Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Entidades
Imports System.Drawing

Public Class ColoresMateriales
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Public lista As New List(Of Integer)
    Dim listaClasificacionColor As DataTable
    Dim listaClasificacionTamano As New DataTable
    Public listaTamanosClas As New List(Of Integer)
    Dim listaId As List(Of Integer)
    Dim listaSelecciones As List(Of Boolean)
    Dim ListaIDCT As List(Of Integer)
    Dim idcol As Integer

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub ColoresMateriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New ColoresMaterialesBU
            grdColoresMateriales.DataSource = obj.getColoresMateriales(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdColoresMateriales.DisplayLayout.Bands(0)
            .Columns("ID").Width = 40
            .Columns("Activo").Width = 30

            .Columns("skuSistema").Hidden = True
        End With
        grdColoresMateriales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdColoresMateriales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdColoresMateriales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        insertar()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If grdColoresMateriales.Rows.Count > 0 Then
            If grdColoresMateriales.ActiveRow.Selected Then
                If grdColoresMateriales.ActiveRow.Cells("SKU").Text <> "00" Then
                    actualizar()
                End If

            End If
        End If
    End Sub

    Private Sub grdColoresMateriales_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdColoresMateriales.ClickCell
        Try
            grdColoresMateriales.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdColoresMateriales_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdColoresMateriales.DoubleClickCell
        Try
            If grdColoresMateriales.Rows.Count > 0 Then
                If grdColoresMateriales.ActiveRow.Selected Then
                    If grdColoresMateriales.ActiveRow.Cells("SKU").Text <> "00" Then
                        actualizar()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub actualizar()
        Dim form As New AltaCampos
        Dim obj As New ColoresMaterialesBU
        Dim obj2 As New ClasificacionesBU
        form.txtSicy.Visible = False
        form.lblsicy.Visible = False
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.txtsku.MaxLength = 2
        form.pnlGrid.Visible = True
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblColor.Visible = True
        form.Size = New Drawing.Size(425, 600)
        form.sku = True
        form.lblDescripcion.Text = "      Color"
        form.idColor = grdColoresMateriales.ActiveRow.Cells("ID").Text
        form.txtId.Text = grdColoresMateriales.ActiveRow.Cells("ID").Text
        form.txtDescripcion.Text = grdColoresMateriales.ActiveRow.Cells("Color").Text
        form.txtsku.Text = grdColoresMateriales.ActiveRow.Cells("SKU").Text
        listaClasificacionColor = obj2.ClasificacionesSeleccionadasColores(grdColoresMateriales.ActiveRow.Cells("ID").Text)
        form.lista = listaClasificacionColor
        form.formulario = "colores"
        form.lblTitulo.Text = "Alta/Edición de Colores"
        form.lblTitulo.Location = New Point(160, 23)
        form.grdColor.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        form.ShowDialog()
        Dim status As Integer = 1
        If form.rdboActivo.Checked Then
            status = 1
        Else
            status = 0
        End If
        If form.cerrado = 1 Then
            listaId = form.listclasificacionesid
            listaSelecciones = form.listaSelecciones
            ListaIDCT = form.listaId
            actualizarCategoriaColores()
            obj.updateColoresMateriales(form.txtId.Text, form.txtDescripcion.Text.Trim, form.txtsku.Text.Trim, status)
            exito.mensaje = "Color actualizado con éxito."
            exito.ShowDialog()
            llenarGrid()
        End If
        'idcol = grdColoresMateriales.ActiveRow.Cells("ID").Text
    End Sub

    Public Sub actualizarCategoriaColores()
        idcol = grdColoresMateriales.ActiveRow.Cells("ID").Text
        Dim Entidad As New Entidades.ClasificacionColores
        Dim objbu As New ColoresMaterialesBU
        Dim estatus, idclas, usumod, clasificaciontamid, idtam As Integer
        Dim fecha As Date
        For Value = 0 To listaSelecciones.Count - 1
            If listaSelecciones.Item(Value).ToString = True Then
                estatus = 1
            Else
                estatus = 0
            End If
            idclas = listaId.Item(Value).ToString
            usumod = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            fecha = DateTime.Now.ToString("dd/MM/yyyy")
            clasificaciontamid = listaId.Item(Value).ToString
            objbu.ActualizarColoresClasificacion(estatus, idclas, usumod, clasificaciontamid, fecha, idcol)
        Next
    End Sub

    Public Sub insertar()
        Dim form As New AltaCampos
        Dim obj As New ColoresMaterialesBU
        Dim idcolor As DataTable

        form.txtSicy.Visible = False
        form.lblsicy.Visible = False
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.txtsku.MaxLength = 2
        form.pnlGrid.Visible = True
        'form.pnlGrid.Visible = True
        form.MaximizeBox = False
        form.lblColor.Visible = True
        form.MinimizeBox = False
        form.lblDescripcion.Text = "      Color"
        form.Size = New Drawing.Size(425, 600)
        form.sku = True
        form.lblTitulo.Text = "Alta/Edición de Colores"
        form.lblTitulo.Location = New Point(160, 23)
        form.grdColor.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        form.ShowDialog()
        If form.cerrado = 1 Then
            Dim form2 As New listaCoincidenciasForm
            Dim color = obj.ColoresRepetidos(form.txtDescripcion.Text)
            If color.Rows.Count > 0 Then
                form2.lista = color
                'objAdvertencia.mensaje = "El color " + form.txtDescripcion.Text + " ya esta registrado, habilitelo para su clasificación"
                'objAdvertencia.ShowDialog()
                form2.ShowDialog()
                If form2.DialogResult = Windows.Forms.DialogResult.Yes Then
                    obj.insertColoresMateriales(form.txtDescripcion.Text.Trim, form.txtsku.Text.Trim)
                    idcolor = obj.idColorInsertado()
                    lista = form.list
                    guardarColorClasificacion(idcolor.Rows(0).Item("mcol_idcolor"))
                    exito.mensaje = "Color registrado con éxito."
                    exito.ShowDialog()
                    llenarGrid()
                End If

            Else
                obj.insertColoresMateriales(form.txtDescripcion.Text.Trim, form.txtsku.Text.Trim)
                idcolor = obj.idColorInsertado()
                lista = form.list
                guardarColorClasificacion(idcolor.Rows(0).Item("mcol_idcolor"))
                exito.mensaje = "Color registrado con éxito."
                exito.ShowDialog()
                llenarGrid()
            End If
        End If

    End Sub

    Public Sub guardarColorClasificacion(ByVal color As Integer)
        Dim OBJ As New ColoresMaterialesBU
        Dim entidad As New ClasificacionColores

        For value = 0 To lista.Count - 1

            entidad.clco_idclasificacion = CInt(lista.Item(value))
            entidad.clco_idcolor = color
            entidad.clco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clco_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clco_estatus = "1"
            OBJ.insertColoresMaterialesClasificacion(entidad)

        Next
    End Sub

    Public Sub GuardaClasificacionColor()
        Dim Entidad As New ClasificacionColores
        Dim objbu As New ColoresMaterialesBU

        Entidad.clco_idclasificacion = ""
        Entidad.clco_idcolor = ""
        Entidad.clco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Entidad.clco_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        Entidad.clco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Entidad.clco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        Entidad.clco_estatus = "A"

        objbu.insertColoresMaterialesClasificacion(Entidad)
    End Sub

End Class