Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Entidades

Public Class ListadoModelosForm
    Dim idMarca As Integer = 0
    Dim idColecc As Integer = 0
    Dim adv As New AdvertenciaForm
    Public idNaveConsulta As Integer = 0
    Public nave As String = ""
    Public idNave As Integer = 0
    Dim entidad As New Consumos

    Public EsAltaProducto As Boolean = False
    Public IdNaveAlta As Integer = -1


    Private Sub ListadoModelosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbColeccion.DataSource = Nothing
        cmbMarca.DataSource = Nothing
        llenarMarcas(idNave)
        llenarColecciones(0, 0)
    End Sub
    Private Sub llenarGrid()
        Dim obj As New ConsumosBU
        If cmbColeccion.Text = "" Then
            idColecc = 0
        Else
            idColecc = cmbColeccion.SelectedValue
        End If
        If cmbMarca.Text = "" Then
            idMarca = 0
        Else
            idMarca = cmbMarca.SelectedValue
        End If
        grdListado.DataSource = obj.listadoProductosSinNave(idColecc, idNave, idMarca)
        Try
            With grdListado.DisplayLayout.Bands(0)
                .Columns("productoEstiloId").Hidden = True
                .Columns("pres_productoid").Hidden = True
                .Columns("espr_estiloproductoid").Hidden = True
                .Columns("idMarca").Hidden = True
                .Columns("idColeccion").Hidden = True
                .Columns("idPiel").Hidden = True
                .Columns("idColor").Hidden = True
                .Columns("idCliente").Hidden = True
                .Columns("idTalla").Hidden = True
                .Columns("Ruta").Hidden = True
                .Columns("Imagen").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
                .Columns("Imagen").Width = 130
                If Not chkImag.Checked Then
                    .Columns("Imagen").Hidden = True
                Else
                    .Columns("Imagen").Hidden = False
                End If
                .Columns("Modelo").Header.Caption = "Código"
                .Columns("Código").Header.Caption = "SICY"
            End With
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
            grdListado.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        Catch ex As Exception
        End Try
    End Sub
    Public Sub llenarMarcas(ByVal nave As Integer)
        'Dim obj As New ConsumosBU
        'Dim lst As New DataTable
        'lst = obj.getMarcas(idNave)
        'If Not lst.Rows.Count = 0 Then
        '    lst.Rows.InsertAt(lst.NewRow, 0)
        '    cmbMarca.DataSource = lst
        '    cmbMarca.DisplayMember = "Marca"
        '    cmbMarca.ValueMember = "IdMarca"
        'End If
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaMarcasPorAsignar(nave)
        If Not lista.Rows.Count = 0 Then
            lista.Rows.InsertAt(lista.NewRow, 0)
            cmbMarca.DataSource = lista
            cmbMarca.DisplayMember = "Marca"
            cmbMarca.ValueMember = "ID"
        End If
    End Sub
    Public Sub llenarColecciones(ByVal nave As Integer, ByVal marca As Integer)
        'Dim obj As New ConsumosBU
        'Dim lst As New DataTable
        'lst = obj.getColecciones(idMarca, idNave)
        'If Not lst.Rows.Count = 0 Then
        '    lst.Rows.InsertAt(lst.NewRow, 0)
        '    cmbColeccion.DataSource = lst
        '    cmbColeccion.DisplayMember = "cole_descripcion"
        '    cmbColeccion.ValueMember = "cole_coleccionid"
        'End If
        Dim obj As New catalagosBU
        Dim lista As New DataTable
        lista = obj.listaColeccionesSinAsignar(marca, nave)
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
        Try
            If cmbMarca.SelectedIndex > 0 Then
                idMarca = cmbMarca.SelectedValue
                llenarColecciones(idNave, cmbMarca.SelectedValue)
            ElseIf cmbMarca.SelectedValue = 0 Then
                cmbColeccion.DataSource = Nothing
            End If
        Catch ex As Exception
            idMarca = 0
            cmbColeccion.DataSource = Nothing
        End Try
        grdListado.DataSource = Nothing
    End Sub

    Private Sub cmbColeccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColeccion.SelectedIndexChanged
        Try
            If cmbColeccion.SelectedIndex > 0 Then
                idColecc = cmbColeccion.SelectedValue
            End If
        Catch ex As Exception
            idColecc = 0
            cmbColeccion.DataSource = Nothing
        End Try
        grdListado.DataSource = Nothing
    End Sub

    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If grdListado.Rows.Count > 0 Then
            If grdListado.ActiveRow.Selected Then
                Dim form As New AltaConsumosFracciones
                Dim cof As New ConfirmarForm
                Dim obj As New ConsumosBU
                Dim obj2 As New catalagosBU

                cof.mensaje = "¿Está seguro de asignar consumos y fracciones al artículo seleccionado?"
                If cof.ShowDialog = Windows.Forms.DialogResult.OK Then

                    form.idProducto = Convert.ToInt32(grdListado.ActiveRow.Cells("pres_productoid").Text)
                    form.idEstiloProd = Convert.ToInt32(grdListado.ActiveRow.Cells("espr_estiloproductoid").Text)
                    'Cambios 09-03-2022
                    'form.modelo = Convert.ToInt32(grdListado.ActiveRow.Cells("Modelo").Text)
                    form.modelo = grdListado.ActiveRow.Cells("Modelo").Text
                    form.idNave = idNave
                    form.permisoModificar = True
                    form.productoEstiloId = Convert.ToInt32(grdListado.ActiveRow.Cells("productoEstiloId").Text)
                    form.accion = "Desarrollo"
                    form.nuevaAsignacion = True
                    obj.actualizarProductos(idNave, Convert.ToInt32(grdListado.ActiveRow.Cells("productoEstiloId").Text))
                    entidad.hipe_productoestid = Convert.ToInt32(grdListado.ActiveRow.Cells("productoEstiloId").Text)
                    entidad.hipe_estatusde = " "
                    entidad.hipe_estatusa = "D"
                    entidad.hipe_usuarioid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    entidad.hipe_idnavehipe = idNave
                    entidad.hipe_naveasignadaid = idNave
                    obj2.ActualizarHistorialProductoEstilo(entidad)
                    form.idNaveConsulta = idNaveConsulta
                    form.EsAlta = EsAltaProducto
                    form.IdNaveAlta = IdNaveAlta
                    form.ShowDialog()
                    Me.Close()

                End If
            Else
                adv.mensaje = "Selecciona un artículo."
                adv.StartPosition = FormStartPosition.CenterScreen
                adv.ShowDialog()
            End If
        End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbMarca.Text = "" Then
            adv.mensaje = "Seleccione una marca para mostrar sus artículos."
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

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbColeccion.SelectedValue = 0
        cmbMarca.SelectedValue = 0
    End Sub
End Class