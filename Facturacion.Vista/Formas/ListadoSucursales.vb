Imports Facturacion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Framework.Negocios

Public Class ListadoSucursales
    Public IdSucursal As Int32
    Dim auxiliar As Integer = 0 'Para validar cuando se carga por primera vez el form

    Private Sub ListadoSucursales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PermisosUsuarioBU.ConsultarPermiso("ConfigSucursales", "ALTASUCURSALF") Then
            btnNuevo.Visible = True
            lblNuevo.Visible = True
        Else
            btnNuevo.Visible = False
            lblNuevo.Visible = False
        End If

        If PermisosUsuarioBU.ConsultarPermiso("ConfigSucursales", "EDITARSUCURSALF") Then
            btnEditar.Visible = True
            lblEditar.Visible = True
        Else
            btnEditar.Visible = False
            lblEditar.Visible = False
        End If

        cargarDatos(True)
        auxiliar = 1
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim objForm As New AltaSucursal
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaSucursal
            formaAltas.permiso = True
            formaAltas.ShowDialog()
        End If
        rdbActivoSi.Checked = True
        cargarDatos(True)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar(True)
    End Sub

    Private Sub rdbActivoSi_CheckedChanged(sender As Object, e As EventArgs) Handles rdbActivoSi.CheckedChanged
        If auxiliar <> 0 Then
            If rdbActivoSi.Checked = True Then
                cargarDatos(True)
            Else
                cargarDatos(False)
            End If
        End If
    End Sub

    Private Sub grdSucursales_BeforeRowActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdSucursales.BeforeRowActivate
        Try
            If e.Row.Cells("NUM").Value <> 0 Then
                IdSucursal = CInt(e.Row.Cells("NUM").Value)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdSucursales_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdSucursales.DoubleClickCell
        If PermisosUsuarioBU.ConsultarPermiso("ConfigSucursales", "EDITARSUCURSALF") Then
            editar(True)
        Else
            editar(False)
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Public Sub cargarDatos(ByVal filtro As Boolean)
        Dim objBU As New Negocios.SucursalesBU
        Dim dtSucursales As New DataTable
        grdSucursales.DataSource = Nothing

        dtSucursales = objBU.getSucursales(filtro)
        If dtSucursales.Rows.Count > 0 Then
            grdSucursales.DataSource = dtSucursales
            disenioGrid()
        Else
            grdSucursales.DataSource = Nothing
        End If
    End Sub

    Public Sub disenioGrid()
        With grdSucursales.DisplayLayout.Bands(0)
            '.Columns("suc_sucursalid").Hidden = True

            .Columns("NUM").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("CIUDAD").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("FACTURA PRODUCTOS").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdSucursales.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .Columns("NUM").Width = 50
            .Columns("NOMBRE").Width = 200
            .Columns("CIUDAD").Width = 100
            .Columns("FACTURA PRODUCTOS").Width = 50

            .Columns("NUM").CharacterCasing = CharacterCasing.Upper
            .Columns("NOMBRE").CharacterCasing = CharacterCasing.Upper
            .Columns("CIUDAD").CharacterCasing = CharacterCasing.Upper
            .Columns("FACTURA PRODUCTOS").CharacterCasing = CharacterCasing.Upper
        End With

        grdSucursales.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdSucursales.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdSucursales.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdSucursales.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub editar(ByVal permiso As Boolean)
        If IdSucursal = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione una empresa valida"
            Advertencia.ShowDialog()
        Else
            Dim objForm As New AltaSucursal
            If Not CheckForm(objForm) Then

                Dim formaAltas As New AltaSucursal
                formaAltas.sucursalId = IdSucursal
                formaAltas.permiso = permiso
                formaAltas.ShowDialog()
            End If

            cargarDatos(True)
            rdbActivoSi.Checked = True
        End If
    End Sub

    Private Function CheckForm(_form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub btnPruebaXML_Click(sender As Object, e As EventArgs) Handles btnPruebaXML.Click
        Dim objForm As New PruebaFacturacion
        Dim formaPrueba As New PruebaFacturacion
        formaPrueba.ShowDialog()
    End Sub
End Class