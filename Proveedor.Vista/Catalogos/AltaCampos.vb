Imports Tools
Imports Proveedores.BU
Imports Infragistics.Win.UltraWinGrid
Imports Entidades

Public Class AltaCampos
    Public cerrado As Integer = 0
    Public sku As Boolean = False
    Dim adv As New AdvertenciaForm
    Public idCategoria = 0
    Public lista As DataTable = Nothing
    Public list As New List(Of Integer)
    Public listaColores As New List(Of Integer)
    Public listaTamanos As New List(Of Integer)
    Public listclasificacionesid As New List(Of Integer)
    Public listaSelecciones As New List(Of Boolean)
    Public listaId As New List(Of Integer)
    Public idColor As Integer
    Public idTam As Integer
    Public formulario As String
    Public directo As String
    Public clasificacion As Integer
    Public listaColoresSeleccionados As New List(Of Integer)
    Public listaTamanosSeleccionados As New List(Of Integer)
    Public listaColoresSeleccionadosCambios As New List(Of Integer)
    Public listaTamanosSeleccionadosCambios As New List(Of Integer)

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validarCampos() Then
            cerrado = 1
            Me.Close()
        End If
        Try
            listaClasificaciones()
        Catch ex As Exception
        End Try

        Try
            If formulario = "tamaños" Then
                listaClasificaciones2()
            End If
        Catch ex As Exception
        End Try

        Try
            If formulario = "colores" Then
                listaClasificaciones3()
            End If
        Catch ex As Exception
        End Try

        If rdoDirecto.Checked = True Then
            directo = 1
        End If

        If rdoIndirecto.Checked = True Then
            directo = 0
        End If
        listaTamanosClasificacion()
        listaColoresClasificacion()
        listaColoresSeleccionados2()
        listaTamanosSeleccionados2()

    End Sub

    Public Sub listaColoresSeleccionados2()
        For value = 0 To grdColor.Rows.Count - 1

            If grdColor.Rows(value).Cells(" ").Value = 1 Then
                listaColoresSeleccionadosCambios.Add(grdColor.Rows(value).Cells("ID").Text)
            End If
        Next
    End Sub

    Public Sub listaTamanosSeleccionados2()
        For value = 0 To grdTamano.Rows.Count - 1

            If grdTamano.Rows(value).Cells(" ").Value = 1 Then
                listaTamanosSeleccionadosCambios.Add(grdTamano.Rows(value).Cells("ID").Text)
            End If

        Next
    End Sub

    Public Sub listaClasificaciones()
        For value = 0 To grdClasificaciones.Rows.Count - 1

            If grdClasificaciones.Rows(value).Cells(" ").Value = 1 Then
                list.Add(grdClasificaciones.Rows(value).Cells("ID").Text)
            End If
        Next
    End Sub

    Public Sub listaColoresClasificacion()
        For value = 0 To grdColor.Rows.Count - 1

            If grdColor.Rows(value).Cells(" ").Value = 1 Then
                listaColores.Add(grdColor.Rows(value).Cells("ID").Text)
            End If
        Next
    End Sub

    Public Sub listaTamanosClasificacion()
        For value = 0 To grdTamano.Rows.Count - 1

            If grdTamano.Rows(value).Cells(" ").Value = 1 Then
                listaTamanos.Add(grdTamano.Rows(value).Cells("ID").Text)
            End If
        Next
    End Sub

    Public Sub listaClasificaciones2()
        Try
            For value = 0 To grdClasificaciones.Rows.Count - 1

                If grdClasificaciones.Rows(value).Cells("idCT").Text = "" Then
                    Dim OBJ As New TamaniosMaterialesBU
                    Dim entidad As New ClasificacionTamanovb

                    entidad.clta_idclasificacion = grdClasificaciones.Rows(value).Cells("ID").Text
                    entidad.clta_idtamano = idTam
                    entidad.clta_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    entidad.clta_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
                    entidad.clta_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    entidad.clta_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
                    entidad.clta_estatus = "1"
                    OBJ.isertarTamanosClasificacion(entidad)
                Else
                    listaId.Add(grdClasificaciones.Rows(value).Cells("idCT").Text)
                End If
                listclasificacionesid.Add(grdClasificaciones.Rows(value).Cells("ID").Text)
                listaSelecciones.Add(grdClasificaciones.Rows(value).Cells(" ").Text)

            Next
        Catch ex As Exception
        End Try
    End Sub

    Public Sub listaClasificaciones3()
        Try
            For value = 0 To grdClasificaciones.Rows.Count - 1

                If grdClasificaciones.Rows(value).Cells("idCT").Text = "" Then
                    Dim OBJ As New ColoresMaterialesBU
                    Dim entidad As New ClasificacionColores

                    entidad.clco_idclasificacion = grdClasificaciones.Rows(value).Cells("ID").Text
                    entidad.clco_idcolor = idColor
                    entidad.clco_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    entidad.clco_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
                    entidad.clco_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    entidad.clco_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
                    entidad.clco_estatus = "1"
                    OBJ.insertColoresMaterialesClasificacion(entidad)
                Else
                    listaId.Add(grdClasificaciones.Rows(value).Cells("idCT").Text)
                End If
                listclasificacionesid.Add(grdClasificaciones.Rows(value).Cells("ID").Text)
                listaSelecciones.Add(grdClasificaciones.Rows(value).Cells(" ").Text)

            Next
        Catch ex As Exception
        End Try
    End Sub

    Function validarCampos() As Boolean
        If txtDescripcion.Text.Trim.Length = 0 Then
            adv.mensaje = "La descripción es obligatoria."
            adv.ShowDialog()
            Return False
        End If
        'If sku = True Then
        '    If Not txtsku.Text.Trim.Length = 2 Then
        '        adv.mensaje = "El sku es obligatorio. El sku debe contener dos caracteres."
        '        adv.ShowDialog()
        '        Return False
        '    End If
        'End If
        Return True
    End Function

    Public Sub llenarComboCategorias()
        Dim obj As New MaterialesBU
        Dim lstCateg As DataTable
        Dim UsuarioID As Integer = Entidades.SesionUsuario.UsuarioSesion.PIDColaboradorUser

        If rdoDirecto.Checked Then
            lstCateg = obj.getCategorias(1, UsuarioID)
        Else
            lstCateg = obj.getCategorias(0, UsuarioID)
        End If

        If Not lstCateg.Rows.Count = 0 Then
            lstCateg.Rows.InsertAt(lstCateg.NewRow, 0)
            cmbCategoria.DataSource = lstCateg
            cmbCategoria.DisplayMember = "nombre"
            cmbCategoria.ValueMember = "idCat"
        End If
      End Sub

    Public Sub llenarGridCategorias()
        Dim obj As New ColoresMaterialesBU
        Dim lstCateg, lstColores, lstTamanos As DataTable
        If lista Is Nothing Then
            lstCateg = obj.Clasificaciones
            lstColores = obj.ListaColores
            lstTamanos = obj.ListaTamanos
            grdClasificaciones.DataSource = lstCateg
            grdColor.DataSource = lstColores
            grdTamano.DataSource = lstTamanos
            If clasificacion = 0 Then
                DISENIOGRID()
            ElseIf clasificacion = 1 Then
                DISENIOGRID3()
                DISENIOGRID4()
            End If

        Else
            grdClasificaciones.DataSource = lista
            If clasificacion = 0 Then
                DISENIOGRID2()
            Else
            End If
        End If

    End Sub

    Public Sub DISENIOGRID()
        grdClasificaciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With grdClasificaciones.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLASIFICACION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("ID").Width = 40
            .Columns("CLASIFICACION").Width = 200
            .Columns("CATEGORIA").Width = 200
            .Columns(" ").Width = 10

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        End With
    End Sub

    Public Sub DISENIOGRID3()
        With grdColor.DisplayLayout.Bands(0)

            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Color").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

            .Columns("ID").Width = 40
            .Columns("Color").Width = 100
            .Columns(" ").Width = 10

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            For value = 0 To grdColor.Rows.Count - 1
                For value2 = 0 To listaColoresSeleccionados.Count - 1
                    If grdColor.Rows(value).Cells("ID").Value = listaColoresSeleccionados.Item(value2) Then
                        grdColor.Rows(value).Cells(" ").Value = True
                    End If

                Next
            Next

            grdColor.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub DISENIOGRID4()
        With grdTamano.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Tamaño").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID").Width = 40
            .Columns("Tamaño").Width = 100
            .Columns(" ").Width = 10

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            For value = 0 To grdTamano.Rows.Count - 1
                For value2 = 0 To listaTamanosSeleccionados.Count - 1
                    If grdTamano.Rows(value).Cells("ID").Value = listaTamanosSeleccionados.Item(value2) Then
                        grdTamano.Rows(value).Cells(" ").Value = True
                    End If

                Next
            Next

            grdTamano.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With
    End Sub

    Public Sub DISENIOGRID2()
        grdClasificaciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        With grdClasificaciones.DisplayLayout.Bands(0)
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CLASIFICACION").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("idCT").Hidden = True
            .Columns("ID").Width = 40
            .Columns("CLASIFICACION").Width = 200
            .Columns("CATEGORIA").Width = 200
            .Columns(" ").Width = 10

            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
        End With
        grdClasificaciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub


    Private Sub AltaCon3Campos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboCategorias()
        llenarGridCategorias()

        If sku = False Then
            txtsku.Enabled = False
        End If

        If idCategoria <> 0 Then
            cmbCategoria.SelectedValue = idCategoria
        End If

        If clasificacion = 1 Then

        End If

    End Sub

    Private Sub AltaCon3Campos_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If cerrado = 1 Then
            cerrado = 1 'se sabe que oprimió en el botón guardar
        Else
            cerrado = 0 ' se sabe que oprimió el boton cerrar
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        Dim strAcentos As String = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç"

        If strAcentos.IndexOf(e.KeyChar) > 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub rdoDirecto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoDirecto.CheckedChanged
        llenarComboCategorias()
    End Sub

    Private Sub rdoIndirecto_CheckedChanged(sender As Object, e As EventArgs) Handles rdoIndirecto.CheckedChanged
        llenarComboCategorias()
    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class