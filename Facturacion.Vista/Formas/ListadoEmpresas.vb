Imports Facturacion.Negocios
Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Framework.Negocios

Public Class ListadoEmpresas
    Public IdEmpresa As Int32

    Private Sub ListadoEmpresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnNuevo.Visible = PermisosUsuarioBU.ConsultarPermiso("configEmpresas", "ALTAEMPRESASF")
        lblNuevo.Visible = PermisosUsuarioBU.ConsultarPermiso("configEmpresas", "ALTAEMPRESASF")

        btnEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("configEmpresas", "EDITAREMPRESASF")
        lblEditar.Visible = PermisosUsuarioBU.ConsultarPermiso("configEmpresas", "EDITAREMPRESASF")

        FacturacionEmpresasArchivoWordToolStripMenuItem.Visible = PermisosUsuarioBU.ConsultarPermiso("configEmpresas", "MODIFWORDEMPRESASF")

        cargarDatos()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim objForm As New AltaEmpresa
        If Not CheckForm(objForm) Then

            Dim formaAltas As New AltaEmpresa
            formaAltas.permiso = True
            formaAltas.ShowDialog()
        End If

        cargarDatos()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editar(True)
    End Sub

    Private Sub grdEmpresas_BeforeRowActivate(sender As Object, e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles grdEmpresas.BeforeRowActivate
        Try
            If e.Row.Cells("empr_empresaid").Value <> 0 Then
                IdEmpresa = CInt(e.Row.Cells("empr_empresaid").Value)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdEmpresas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdEmpresas.DoubleClickCell
        If PermisosUsuarioBU.ConsultarPermiso("configEmpresas", "EDITAREMPRESASF") Then
            editar(True)
        Else
            editar(False)
        End If
    End Sub

    Public Sub cargarDatos()
        Dim objBU As New Negocios.EmpresasBU
        Dim dtEmpresas As New DataTable
        grdEmpresas.DataSource = Nothing

        dtEmpresas = objBU.getEmpresas()
        If dtEmpresas.Rows.Count > 0 Then
            grdEmpresas.DataSource = dtEmpresas
            disenioGrid()
        Else
            grdEmpresas.DataSource = Nothing
        End If
    End Sub

    Public Sub disenioGrid()
        With grdEmpresas.DisplayLayout.Bands(0)
            '.Columns("empr_empresaid").Hidden = True

            .Columns("empr_empresaid").Header.Caption = "Id"

            .Columns("empr_empresaid").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Razon Social").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RFC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("No. Certificado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Vigencia Inicio").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Vigencia Inicio").Format = "dd/MM/yyyy"
            .Columns("Vigencia Fin").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Vigencia Fin").Format = "dd/MM/yyyy"
            .Columns("Folio Actual").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Ruta PDF").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("Ruta XML").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            grdEmpresas.DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

            .Columns("empr_empresaid").Width = 40
            .Columns("Razon Social").Width = 250
            .Columns("RFC").Width = 100
            .Columns("No. Certificado").Width = 100
            .Columns("Vigencia Inicio").Width = 70
            .Columns("Vigencia Fin").Width = 70
            .Columns("Folio Actual").Width = 70
            .Columns("Ruta PDF").Width = 100
            .Columns("Ruta XML").Width = 100

            .Columns("Razon Social").CharacterCasing = CharacterCasing.Upper
            .Columns("RFC").CharacterCasing = CharacterCasing.Upper
            .Columns("No. Certificado").CharacterCasing = CharacterCasing.Upper
            .Columns("Vigencia Inicio").CharacterCasing = CharacterCasing.Upper
            .Columns("Vigencia Fin").CharacterCasing = CharacterCasing.Upper
            .Columns("Folio Actual").CharacterCasing = CharacterCasing.Upper
            .Columns("Ruta PDF").CharacterCasing = CharacterCasing.Upper
            .Columns("Ruta XML").CharacterCasing = CharacterCasing.Upper
        End With

        grdEmpresas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdEmpresas.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grdEmpresas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdEmpresas.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
    End Sub

    Private Sub editar(ByVal permiso As Boolean)
        If IdEmpresa = 0 Then
            Dim Advertencia As New AdvertenciaForm
            Advertencia.mensaje = "Seleccione una empresa valida"
            Advertencia.ShowDialog()
        Else
            Dim objForm As New AltaEmpresa
            If Not CheckForm(objForm) Then

                Dim formaAltas As New AltaEmpresa
                formaAltas.empresaId = IdEmpresa
                formaAltas.permiso = permiso
                formaAltas.ShowDialog()
            End If

            cargarDatos()
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

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        menuAyuda.Show(btnAyuda, 0, btnAyuda.Height)
    End Sub

    Private Sub FacturacionEmpresasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionEmpresasToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Facturacion/", "Descargas\Manuales\Facturacion", "FACT_MAUS_AltaEmpresa_Facturación_V1.pdf")
            Process.Start("Descargas\Manuales\Facturacion\FACT_MAUS_AltaEmpresa_Facturación_V1.pdf")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FacturacionEmpresasArchivoWordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FacturacionEmpresasArchivoWordToolStripMenuItem.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Facturacion/", "Descargas\Manuales\Facturacion", "FACT_MAUS_AltaEmpresa_Facturación_V1.docx")
            Process.Start("Descargas\Manuales\Facturacion\FACT_MAUS_AltaEmpresa_Facturación_V1.docx")
        Catch ex As Exception
        End Try
    End Sub
End Class
