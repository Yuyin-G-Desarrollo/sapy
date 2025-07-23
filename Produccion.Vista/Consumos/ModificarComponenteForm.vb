Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Tools

Public Class ModificarComponenteForm

    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objMensaje As New AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objErrores As New Tools.ErroresForm
    Dim objInformacion As New Tools.AvisoForm
    Dim objConfirmacion As New Tools.ConfirmarForm

    Dim ListaClasificacionesSeleccionadas As New DataTable

    Public id As Integer
    Public componente As String
    Public activo As Integer

    Private Sub ModificarComponenteForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtID.Text = id
        txtComponente.Text = componente
        If activo = 1 Then
            rdoSi.Checked = True
        Else
            rdoNo.Checked = True
        End If
        obtenerClasificaciones()
    End Sub

    Public Sub obtenerClasificaciones()
        Dim obj As New catalagosBU
        Dim ListaClasificaciones As New DataTable
        ListaClasificaciones = obj.listaClasificaciones
        grdClasificacion.DataSource = ListaClasificaciones
        disenioGrid()
    End Sub

    Public Sub obtenerClasificacionesSeleccionadas()
        Dim obj As New catalagosBU
        ListaClasificacionesSeleccionadas = obj.listaClasificacionesSeleccionadas(txtID.Text)
        'disenioGrid()
    End Sub

    Public Sub disenioGrid()
        With grdClasificacion.DisplayLayout.Bands(0)
            .Columns(" ").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns(" ").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns(" ").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns(" ").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("ID").CellActivation = Activation.NoEdit
            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("ID").CellAppearance.TextHAlign = HAlign.Right
            .Columns("ID").Width = 20
            .Columns(" ").Width = 10
            .Columns("Clasificación").Width = 200

            obtenerClasificacionesSeleccionadas()

            For value = 0 To grdClasificacion.Rows.Count.ToString - 1
                For value2 = 0 To ListaClasificacionesSeleccionadas.Rows.Count - 1
                    If grdClasificacion.Rows(value).Cells("ID").Value = ListaClasificacionesSeleccionadas.Rows(value2).Item("idc") Then
                        grdClasificacion.Rows(value).Cells(" ").Value = 1
                    End If
                Next
            Next

        End With
        grdClasificacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnGuardarComponente_Click(sender As Object, e As EventArgs) Handles btnGuardarComponente.Click
        Dim obj As New catalagosBU
        Dim cocl As New Entidades.ComponenteClasificacion
        Dim contador As Integer = 0
        Dim registrosSeleccionados As Int16 = 0

        For value = 0 To grdClasificacion.Rows.Count - 1
            If CBool(grdClasificacion.Rows(value).Cells(" ").Text) Then
                registrosSeleccionados += 1
            End If
        Next

        If registrosSeleccionados > 0 Or ListaClasificacionesSeleccionadas.Rows.Count > 0 Then
            ''If ListaClasificacionesSeleccionadas.Rows.Count > 0 Then
            Try
                Dim vXmlClasificaciones As XElement = New XElement("Clasificaciones")
                For value = 0 To grdClasificacion.Rows.Count - 1
                    Dim vNodo As XElement = New XElement("Clasificacion")
                    vNodo.Add(New XAttribute("IdComponente", txtID.Text))
                    vNodo.Add(New XAttribute("IdClasificacion", grdClasificacion.Rows(value).Cells("ID").Text))
                    vNodo.Add(New XAttribute("Activo", grdClasificacion.Rows(value).Cells(" ").Text))
                    vXmlClasificaciones.Add(vNodo)
                Next
                obj.InsertarActualizarComponenteClasificacion(vXmlClasificaciones.ToString(), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                objExito.mensaje = "Registros actualizados"
                objExito.StartPosition = FormStartPosition.CenterScreen
                objExito.ShowDialog()
                Me.Close()
            Catch ex As Exception
                objErrores.mensaje = ex.Message
                objErrores.StartPosition = FormStartPosition.CenterScreen
                objErrores.ShowDialog()
            End Try
        Else
            objAdvertencia.mensaje = "Seleccione una o más  clasificaciones para poder asignarlas al componente"
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End If
    End Sub

End Class