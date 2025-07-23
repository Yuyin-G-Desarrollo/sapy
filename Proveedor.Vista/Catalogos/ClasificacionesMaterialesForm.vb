Imports Tools
Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Entidades

Public Class ClasificacionesMaterialesForm
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim id As Integer = 0
    Public lista As New List(Of Integer)
    Public listaColor As New List(Of Integer)
    Public listaTamano As New List(Of Integer)
    Public listaColores As New List(Of Integer)
    Public listaTamanos As New List(Of Integer)
    Public listaTamanosClas As New List(Of Integer)
    Dim listaId As List(Of Integer)
    Dim listaSelecciones As List(Of Boolean)
    Dim ListaIDCT As List(Of Integer)
    Dim IdClas As New Integer
    Dim listaColoresx As New DataTable
    Dim listaTamanosx As New DataTable

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim idClasificacion As Integer
    Dim busca As String
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            grdClasificacion.ActiveRow.Selected = True
            If grdClasificacion.Rows.Count > 0 Then
                If grdClasificacion.ActiveRow.Selected Then
                    actualizar()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub nuevo()
        Dim form As New AltaCampos
        form.ShowDialog()
    End Sub
    Public Sub actualizar()
        Dim obj As New ClasificacionesBU
        Dim form As New AltaCampos
        Dim idCategoria As DataTable

        form.lblsicy.Visible = False
        form.txtSicy.Visible = False
        form.lblClasificacion.Visible = False
        form.cmbClasificacion.Visible = False
        form.txtsku.MaxLength = 2
        form.sku = False
        form.lblClas.Visible = True
        form.lblDescripcion.Text = "Clasificación"
        form.pnlGrid.Visible = False
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.Panel3.Visible = True
        form.grdTamano.Visible = True
        form.gbxDirecto.Visible = True
        form.Panel3.Visible = True
        form.grdColor.Visible = True
        form.grdTamano.Visible = True
        'form.UltraPanel2.Visible = True
        form.Size = New Drawing.Size(423, 600)
        form.txtId.Text = grdClasificacion.ActiveRow.Cells("ID").Text
        idClasificacion = grdClasificacion.ActiveRow.Cells("ID").Text
        form.txtDescripcion.Text = grdClasificacion.ActiveRow.Cells("Clasificación").Text
        form.txtsku.Text = grdClasificacion.ActiveRow.Cells("SKU").Text
        idCategoria = obj.ObtenerCategoria(grdClasificacion.ActiveRow.Cells("ID").Text)
        Dim tipo As Integer
        If grdClasificacion.ActiveRow.Cells("Material").Text = "DIRECTO" Then
            form.rdoDirecto.Checked = True
            tipo = 1
        ElseIf grdClasificacion.ActiveRow.Cells("Material").Text = "INDIRECTO" Then
            form.rdoIndirecto.Checked = True
            tipo = 0
        End If

        listaColores.Clear()
        listaTamano.Clear()

        Dim listaColoresSeleccionados = obj.coloresSeleccionados2(grdClasificacion.ActiveRow.Cells("ID").Text)
        For Valor = 0 To listaColoresSeleccionados.Rows.Count - 1
            If listaColoresSeleccionados.Rows(Valor).Item(" ").ToString = 1 Then
                listaColores.Add(CInt(listaColoresSeleccionados.Rows(Valor).Item("ID").ToString))
            End If
        Next
        form.listaColoresSeleccionados = listaColores

        Dim listaTamanosSeleccionados = obj.tamanosSeleccionados2(grdClasificacion.ActiveRow.Cells("ID").Text)
        For Valor = 0 To listaTamanosSeleccionados.Rows.Count - 1
            If listaTamanosSeleccionados.Rows(Valor).Item("ID").ToString = 1 Then
                listaTamanos.Add(CInt(listaTamanosSeleccionados.Rows(Valor).Item("ID").ToString))
            End If
        Next
        form.listaTamanosSeleccionados = listaTamanos

        form.lblTitulo.Text = "Alta/Edición de Clasificaciones"
        form.lblTitulo.Location = New Point(100, 23)
        form.idCategoria = idCategoria.Rows(0).Item("ID cat")
        form.clasificacion = 1
        'form.cmbCategoria.SelectedValue = numero
        'form.cmbCategoria.Text = idCategoria.Rows(0).Item("Categoria")
        If grdClasificacion.ActiveRow.Cells("Activo").Value Then
            form.rdboActivo.Checked = True
            form.rdboInactivo.Checked = False
        Else
            form.rdboActivo.Checked = False
            form.rdboInactivo.Checked = True
        End If
        form.ShowDialog()
        Dim status As Integer = 1
        If form.rdboActivo.Checked Then
            status = 1
        Else
            status = 0
        End If
        If form.cerrado = 1 Then
            If form.rdoDirecto.Checked = True Then
                tipo = 1
            Else
                tipo = 0
            End If

            obj.updateClasificaciones(form.txtId.Text, form.txtDescripcion.Text, status, form.txtsku.Text.Trim, tipo)
            listaId = form.listclasificacionesid
            ListaIDCT = form.listaId
            Dim listaSelecciones = form.listaSelecciones
            listaColores = form.listaColores
            listaTamanos = form.listaTamanos

            actualizarColoresCategoria()
            actualizarTamanosCategoria()

            Dim listaSeleccionesColores = form.listaColoresSeleccionadosCambios
            ListaIDCT = form.listaId
            actualizarCategoriaColores()
            obj.updateColoresMateriales(form.txtId.Text, form.txtDescripcion.Text.Trim, form.txtsku.Text.Trim, status)
            ActualizarrCategoriaClasificacion(form.txtId.Text, form.cmbCategoria.SelectedValue)
            exito.mensaje = "Clasificación actualizada con éxito."
            exito.ShowDialog()
            llenarGrid()
        End If
    End Sub
    Public Sub actualizarCategoriaColores()
        Dim Entidad As New Entidades.ClasificacionColores
        Dim objbu As New ColoresMaterialesBU

        For Value = 0 To ListaIDCT.Count - 1
            If listaSelecciones.Item(Value).ToString = True Then
                Entidad.clco_estatus = "1"
            Else
                Entidad.clco_estatus = "0"
            End If
            Entidad.clco_idclasificacion = listaId.Item(Value).ToString
            'Entidad.clco_idcolor = listaClasificacionTamano.Rows(Value).Item(Value).ToString
            Entidad.clco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            Entidad.clco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            Entidad.clco_clasificacioncoloresid = ListaIDCT.Item(Value).ToString

            objbu.ActualizarColorClasificacion(Entidad)
        Next
    End Sub

    Public Sub actualizarColoresCategoria()
        Dim objbu As New ColoresMaterialesBU

        objbu.desactivarColores(idClasificacion)
        guardarColorClasificacion2()
        'For value = 0 To listaColores.Count - 1
        '    objbu.activarColores(idClasificacion, listaColores.Item(value))
        'Next

    End Sub

    Public Sub actualizarTamanosCategoria()
        Dim objbu As New ColoresMaterialesBU

        objbu.desactivarTamano(idClasificacion)
        guardarTamañosClasificaciones()

        'For value = 0 To listaTamanos.Count - 1
        '    objbu.activarTamano(idClasificacion, listaColores.Item(value))
        'Next

    End Sub

    Private Sub grdClasificacion_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdClasificacion.DoubleClickCell
        Try
            grdClasificacion.ActiveRow.Selected = True
            If grdClasificacion.Rows.Count > 0 Then
                If grdClasificacion.ActiveRow.Selected Then
                    actualizar()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New ClasificacionesBU
            grdClasificacion.DataSource = obj.getClasificaciones(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdClasificacion.DisplayLayout.Bands(0)
            .Columns("ID").Width = 50
        End With
        grdClasificacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClasificacion.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        insertar()
    End Sub
    Public Sub insertar()
        Dim obj As New ClasificacionesBU
        Dim form As New AltaCampos
        form.lblsicy.Visible = False
        form.txtSicy.Visible = False
        form.lblClasificacion.Visible = False
        form.cmbClasificacion.Visible = False
        form.txtsku.MaxLength = 2
        form.pnlGrid.Visible = False
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblClas.Visible = True
        form.gbxDirecto.Visible = True
        form.Panel3.Visible = True
        'form.UltraPanel2.Visible = True
        form.lblDescripcion.Text = "Clasificación"
        form.Size = New Drawing.Size(423, 600)
        'form.Size = New Drawing.Size(423, 290)
        form.grdColor.Visible = True
        form.grdTamano.Visible = True
        form.lblTitulo.Text = "Alta/Edición de Clasificaciones"
        form.lblTitulo.Location = New Point(100, 23)
        form.sku = False
        form.clasificacion = 1
        form.ShowDialog()

        If form.cerrado = 1 Then
            Dim palabra = form.txtDescripcion.Text
            Dim categoriaID As Integer = 0

            If palabra.Length > 3 Then
                busca = palabra.Substring(0, 3)
            End If

            If form.cmbCategoria.SelectedIndex <> 0 Then
                categoriaID = form.cmbCategoria.SelectedValue
            End If

            Dim clasificaciones = obj.ClasificacionRepetida(busca, categoriaID)
            Dim resultado As String = ""
            If clasificaciones.Rows.Count > 0 Then
                For value = 0 To clasificaciones.Rows.Count - 1
                    resultado = clasificaciones.Rows(value).Item("nombreClas").ToString + ", " + resultado
                Next
                objConfirmacion.mensaje = "Las siguientes clasificaciónes concuerdan con la captura " + resultado
                objConfirmacion.mensaje += " Es alguna de las mostradas"
                objConfirmacion.ShowDialog()
                If objConfirmacion.DialogResult = Windows.Forms.DialogResult.OK Then
                Else
                    listaColor = form.listaColores
                    listaTamano = form.listaTamanos
                    obj.inserClasificaciones(form.txtDescripcion.Text, form.txtsku.Text.Trim, form.directo)
                    IdClas = obj.UltimaClasificacion
                    GuardarCategoriaClasificacion(form.cmbCategoria.SelectedValue)
                    guardarTamañosClasificaciones()
                    guardarColorClasificacion()
                    exito.mensaje = "Clasificación registrada con éxito."
                    exito.ShowDialog()
                    Dim clasificacion = obj.UltimaClasificacion()
                    llenarGrid()
                End If
            Else
                listaColor = form.listaColores
                listaTamano = form.listaTamanos
                obj.inserClasificaciones(form.txtDescripcion.Text, form.txtsku.Text.Trim, form.directo)
                IdClas = obj.UltimaClasificacion
                GuardarCategoriaClasificacion(form.cmbCategoria.SelectedValue)
                guardarTamañosClasificaciones()
                guardarColorClasificacion()
                exito.mensaje = "Clasificación registrada con éxito."
                exito.ShowDialog()
                Dim clasificacion = obj.UltimaClasificacion()
                llenarGrid()
            End If

        End If
    End Sub

    Public Sub guardarColorClasificacion()
        Dim OBJ As New ColoresMaterialesBU
        Dim entidad As New ClasificacionColores

        For value = 0 To listaColor.Count - 1
            entidad.clco_idclasificacion = IdClas
            entidad.clco_idcolor = listaColor.Item(value)
            entidad.clco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clco_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clco_estatus = "1"
            OBJ.insertColoresMaterialesClasificacion(entidad)
        Next

    End Sub

    Public Sub guardarTamañosClasificaciones()
        Dim OBJ As New TamaniosMaterialesBU
        Dim obje As New ClasificacionesBU
        Dim entidad As New ClasificacionTamanovb

        For value = 0 To listaTamano.Count - 1
            entidad.clta_idclasificacion = IdClas
            entidad.clta_idtamano = listaTamano.Item(value)
            entidad.clta_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clta_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clta_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clta_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clta_estatus = "1"
            OBJ.isertarTamanosClasificacion(entidad)
        Next
    End Sub

    Public Sub guardarColorClasificacion2()
        Dim OBJ As New ColoresMaterialesBU
        Dim entidad As New ClasificacionColores

        For value = 0 To listaColores.Count - 1
            entidad.clco_idclasificacion = idClasificacion
            entidad.clco_idcolor = listaColores.Item(value)
            entidad.clco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clco_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clco_estatus = "1"
            OBJ.insertColoresMaterialesClasificacion(entidad)
        Next
        listaColores.Clear()
    End Sub

    Public Sub guardarTamañosClasificaciones2()
        Dim OBJ As New TamaniosMaterialesBU
        Dim obje As New ClasificacionesBU
        Dim entidad As New ClasificacionTamanovb

        For value = 0 To listaTamanos.Count - 1
            entidad.clta_idclasificacion = idClasificacion
            entidad.clta_idtamano = listaTamanos.Item(value)
            entidad.clta_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clta_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clta_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clta_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clta_estatus = "1"
            OBJ.isertarTamanosClasificacion(entidad)
        Next
        listaTamanos.Clear()
    End Sub

    Public Sub GuardarCategoriaClasificacion(ByRef categoria As Integer)
        Dim Entidad As New Entidades.CategoriaClasificacion
        Dim objbu As New ClasificacionesBU
        Dim ultimaClasificacion As Integer

        ultimaClasificacion = CInt(objbu.UltimaClasificacion)
        Entidad.calc_idcategoria = categoria
        Entidad.calc_idclasificacion = ultimaClasificacion
        Entidad.calc_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Entidad.calc_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        Entidad.calc_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Entidad.calc_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        Entidad.calc_estatus = "1"

        objbu.insertarCategoriaClasificaciones(Entidad)
    End Sub

    Public Sub ActualizarrCategoriaClasificacion(ByVal id As Integer, ByVal cat As Integer)
        Dim Entidad As New Entidades.CategoriaClasificacion
        Dim objbu As New ClasificacionesBU

        Entidad.calc_idclasificacion = id
        Entidad.calc_idcategoria = cat
        Entidad.calc_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Entidad.calc_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        Entidad.calc_estatus = "A"

        objbu.ActualizarCategoriaClasificaciones(Entidad)
    End Sub

    Private Sub grdClasificacion_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdClasificacion.ClickCell
        Try
            grdClasificacion.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ClasificacionesMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
End Class