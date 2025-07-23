Imports Proveedores.BU
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports System.Windows.Forms


Public Class DepartamentosMaterialesForm
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
    Dim id As Integer
    Dim lista As New List(Of Integer)

    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub DepartamentosMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarGrid()
    End Sub
  
    Public Sub llenarGrid()
        Try
            Dim obj As New DepartamentosMaterialesBU
            'Dim cmbNave = Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
            grdDepartamentos.DataSource = obj.getDepartamentosMateriales(0)
            diseño()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al traer los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Public Sub diseño()
        With grdDepartamentos.DisplayLayout.Bands(0)
            .Columns("Código").Width = 35
            .Columns("idNave").Hidden = True
            .Columns("Código").Header.Caption = "ID"
        End With
        grdDepartamentos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdDepartamentos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub grdDepartamentos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdDepartamentos.ClickCell
        Try
            grdDepartamentos.ActiveRow.Selected = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            insertar()
            llenarGrid()
        Catch ex As Exception
            adv.mensaje = "Surgió un error al guardar los datos. Error: " + ex.Message
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub grdDepartamentos_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdDepartamentos.DoubleClickCell
        Try
            grdDepartamentos.ActiveRow.Selected = True
            If grdDepartamentos.Rows.Count > 0 Then
                If grdDepartamentos.ActiveRow.Selected Then
                    actualizar()
                    llenarGrid()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If grdDepartamentos.Rows.Count > 0 Then
            If grdDepartamentos.ActiveRow.Selected Then
                actualizar()
                llenarGrid()
            End If
        End If
    End Sub
    Public Sub insertar()
        Dim obj As New DepartamentosMaterialesBU
        Dim form As New AltaEditarDepartamento
        Dim datos As New DataTable
        form.lblTitulo.Text = "Alta/Edición Departamento"
        form.lblTitulo.Location = New Point(15, 23)
        form.ShowDialog()
        If form.cerrado = 1 Then
            datos = obj.validarNombreDepartamento(form.cmbNave.SelectedValue, form.txtDescripcion.Text)
            If datos.Rows.Count > 0 Then
                adv.mensaje = "El nombre del departamento ya está registrado para la nave."
                adv.ShowDialog()
            Else
                obj.insertDepartamentosMateriales(form.cmbNave.SelectedValue, form.txtDescripcion.Text)
                exito.mensaje = "Departamento registrado con éxito."
                exito.ShowDialog()
            End If
        End If
    End Sub
    Public Sub actualizar()
        Dim obj As New DepartamentosMaterialesBU
        Dim form As New AltaEditarDepartamento
        Dim datos As New DataTable
        form.txtId.Text = grdDepartamentos.ActiveRow.Cells("Código").Text
        form.txtDescripcion.Text = grdDepartamentos.ActiveRow.Cells("Departamento").Text
        form.idNave = Convert.ToInt32(grdDepartamentos.ActiveRow.Cells("idNave").Text)
        form.lblTitulo.Text = "Alta/Edición Departamento"
        form.lblTitulo.Location = New Point(15, 23)
        form.ShowDialog()
        Dim status As Integer = 1
        If form.rdboActivo.Checked Then
            status = 1
        Else
            status = 0
        End If
        If form.cerrado = 1 Then
            datos = obj.validarNombreDepartamentoEditado(form.cmbNave.SelectedValue, form.txtDescripcion.Text, form.txtId.Text)
            If datos.Rows.Count > 0 Then
                adv.mensaje = "El nombre del departamento ya está registrado para la nave."
                adv.ShowDialog()
            Else
                obj.updateDepartamentosMateriales(form.txtId.Text, form.cmbNave.SelectedValue, form.txtDescripcion.Text, status)
                exito.mensaje = "Departamento actualizado con éxito."
                exito.ShowDialog()
            End If
        End If
    End Sub

End Class