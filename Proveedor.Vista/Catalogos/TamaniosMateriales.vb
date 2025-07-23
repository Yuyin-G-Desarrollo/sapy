Imports Tools
Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports Entidades
Imports System.Drawing

Public Class TamaniosMateriales
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Public lista As New List(Of Integer)
    Dim listaClasificacionTamano As New DataTable
    Public listaTamanosClas As New List(Of Integer)
    Dim listaId As List(Of Integer)
    Dim listaSelecciones As List(Of Boolean)
    Dim ListaIDCT As List(Of Integer)

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim idta As Integer
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        insertar()
    End Sub
    Public Sub insertar()
        Dim form As New AltaCampos
        Dim obj As New TamaniosMaterialesBU
        Dim idtamano As DataTable
        form.txtSicy.Visible = False
        form.lblsicy.Visible = False
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.txtsku.MaxLength = 2
        form.pnlGrid.Visible = True
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.Size = New Drawing.Size(423, 600)
        form.sku = False
        form.lblTamano.Visible = True
        form.lblDescripcion.Text = "     Tamaño"
        form.lblTitulo.Text = "Alta/Edición Tamaños"
        form.lblTitulo.Location = New Point(160, 23)
        form.ShowDialog()
        If form.cerrado = 1 Then
            lista = form.list
            idtamano = obj.idtamanoinsertado

            Dim tamanos = obj.TamanosRepetidos(form.txtDescripcion.Text.ToUpper.Trim.Replace(" ", ""))
            Dim form2 As New listaCoincidenciasForm
            ''''
            ''''
            ''''
            form2.lblMensaje.Text = "Si el tamaño a capturar aparece en la lista, dar clic en salir." & vbCrLf & "De lo contrario dar clic en guardar Captura." & vbCrLf & "para guardar el tamaño capturado"
            If tamanos.Rows.Count > 0 Then
                form2.lista = tamanos
                form2.ShowDialog()
                If form2.DialogResult = Windows.Forms.DialogResult.Yes Then
                    obj.insertTamañosMateriales(form.txtDescripcion.Text.ToUpper.Trim.Replace(" ", ""), form.txtsku.Text.Trim)
                    Try
                        guardarTamañosClasificaciones(idtamano.Rows(0).Item("idTam") + 1)
                    Catch ex As Exception
                    End Try
                    exito.mensaje = "Tamaño registrado con éxito."
                    exito.ShowDialog()
                    llenarGrid()
                End If
                'objAdvertencia.mensaje = "Ya hay un tamano " + form.txtDescripcion.Text + " registrado, habilitelo para la clasificación"
                'objAdvertencia.ShowDialog()
            Else
                obj.insertTamañosMateriales(form.txtDescripcion.Text.ToUpper.Trim.Replace(" ", ""), form.txtsku.Text.Trim)
                Try
                    guardarTamañosClasificaciones(idtamano.Rows(0).Item("idTam") + 1)
                Catch ex As Exception

                End Try
                exito.mensaje = "Tamaño registrado con éxito."
                exito.ShowDialog()
                llenarGrid()
            End If
            
        End If
    End Sub

    Public Sub guardarTamañosClasificaciones(ByVal idTamano As Integer)
        Dim OBJ As New TamaniosMaterialesBU
        Dim entidad As New ClasificacionTamanovb

        For value = 0 To lista.Count - 1

            entidad.clta_idclasificacion = CInt(lista.Item(value))
            entidad.clta_idtamano = idTamano
            entidad.clta_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clta_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clta_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            entidad.clta_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
            entidad.clta_estatus = "1"
            OBJ.isertarTamanosClasificacion(entidad)

        Next
    End Sub

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub grdTams_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grdTams.ClickCell
        Try
            grdTams.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TamaniosMateriales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
    Public Sub llenarGrid()
        Try
            Dim obj As New TamaniosMaterialesBU
            grdTams.DataSource = obj.getTamañosMateriales(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdTams.DisplayLayout.Bands(0)
            .Columns("ID").Width = 35
            .Columns("ID").Width = 60
            .Columns("Activo").Width = 10
        End With
        grdTams.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        'grdTams.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdTams.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If grdTams.Rows.Count > 0 Then
            If grdTams.ActiveRow.Selected Then
                If grdTams.ActiveRow.Cells("SKU").Text <> "00" Then
                    actualizar()
                End If
            End If
        End If
    End Sub
    Public Sub actualizar()
        Dim form As New AltaCampos
        Dim obj As New TamaniosMaterialesBU
        Dim obj2 As New ClasificacionesBU
        form.txtSicy.Visible = False
        form.lblsicy.Visible = False
        form.lblCategoria.Visible = False
        form.cmbCategoria.Visible = False
        form.txtsku.MaxLength = 2
        form.pnlGrid.Visible = True
        form.MaximizeBox = False
        form.MinimizeBox = False
        form.lblTamano.Visible = True
        form.lblDescripcion.Text = "     Tamaño"
        form.Size = New Drawing.Size(423, 600)
        form.sku = False
        form.lblTitulo.Text = "Alta/Edición Tamaños"
        form.lblTitulo.Location = New Point(160, 23)
        form.txtId.Text = grdTams.ActiveRow.Cells("ID").Text
        form.idTam = grdTams.ActiveRow.Cells("ID").Text
        form.txtDescripcion.Text = grdTams.ActiveRow.Cells("Tamaño").Text
        form.txtsku.Text = grdTams.ActiveRow.Cells("SKU").Text
        listaClasificacionTamano = obj2.ClasificacionesSeleccionadasTamanos(grdTams.ActiveRow.Cells("ID").Text)
        form.lista = listaClasificacionTamano
        form.formulario = "tamaños"
        If grdTams.ActiveRow.Cells("Activo").Value Then
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

            listaId = form.listclasificacionesid
            listaSelecciones = form.listaSelecciones
            ListaIDCT = form.listaId
            actualizarCategoriaTamanos()
            obj.updateTamañosMateriales(form.txtId.Text, form.txtDescripcion.Text.Trim, form.txtsku.Text.Trim, status)
            listaTamanosClas = form.list
            exito.mensaje = "Tamaño actualizado con éxito."
            exito.ShowDialog()
            llenarGrid()
        End If
        idta = grdTams.ActiveRow.Cells("ID").Text
    End Sub

    Public Sub actualizarCategoriaTamanos()
        Dim Entidad As New Entidades.ClasificacionTamanovb
        Dim objbu As New TamaniosMaterialesBU
        Dim estatus, idclas, usumod, clasificaciontamid, idtam As Integer
        Dim fecha As Date
        For Value = 0 To listaSelecciones.Count - 1
            If listaSelecciones.Item(Value).ToString = True Then
                estatus = 1
            Else
                estatus = 0
            End If
            idclas = listaId.Item(Value).ToString
            idtam = grdTams.ActiveRow.Cells("ID").Text
            usumod = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            fecha = DateTime.Now.ToString("dd/MM/yyyy")
            clasificaciontamid = listaId.Item(Value).ToString

            objbu.ActualizarTamanoClasificacion(estatus, idclas, usumod, clasificaciontamid, fecha, idtam)
        Next
    End Sub

    Public Sub quitarSelecciones()

    End Sub

    Private Sub grdTams_DoubleClick(sender As Object, e As EventArgs) Handles grdTams.DoubleClick
        'Try
        '    If grdTams.Rows.Count > 0 Then
        '        If grdTams.ActiveRow.Selected Then
        '            actualizar()
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub grdTams_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdTams.DoubleClickCell

        Try
            If grdTams.Rows.Count > 0 Then
                If grdTams.ActiveRow.Selected Then
                    If grdTams.ActiveRow.Cells("SKU").Text <> "00" Then
                        actualizar()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class