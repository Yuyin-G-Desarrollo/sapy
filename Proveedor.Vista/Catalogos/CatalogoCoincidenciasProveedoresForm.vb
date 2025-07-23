Imports Proveedores.BU
Imports Tools
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports Infragistics.Win

Public Class CatalogoCoincidenciasProveedoresForm

    Public objAdvertencia As New Tools.AdvertenciaForm
    Public objConfirmacionGde As New Tools.confirmarFormGrande
    Public objMensaje As New AdvertenciaForm
    Public objExito As New Tools.ExitoForm
    Public objErrores As New Tools.ErroresForm
    Public objInformacion As New Tools.AvisoForm
    Public objConfirmacion As New Tools.ConfirmarForm

    Dim idProveedor As Integer

    Public objBu As New ProveedorBU
    Public busqueda As String
    Dim editar As Boolean
    Public naveid As Integer
    Public naveNombre As String
    Public respuesta As Boolean
    Public NAVEX As Integer = 0
    Public cerrar As Integer = 0

    Private FORM_ As AltaProveedoresForm
    Private FORMM_ As ModificarProveedoresForm
    Private FORM2_ As CatalogoProveedoresForm
    Dim altaproveedor As Integer = 0

    Private Sub CatalogoCoincidenciasProveedoresForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtListaContactosCobranza As New DataTable
        'Dim dtListaContactosCobranza2 As New DataTable
        'dtListaContactosCobranza = objBu.BuscaCoincidenciaNombre(busqueda)
        'dtListaContactosCobranza2 = objBu.BuscaCoincidenciaNombreDAGE(busqueda)

        ' If dtListaContactosCobranza.Rows.Count <> 0 Then
        LlenarTablaContactosCobranza()
        diseniogrdContactosCobranza()
        'ElseIf dtListaContactosCobranza2.Rows.Count <> 0 Then
        ' LlenarTablaCoincidenciasDage()
        ' diseniogrd2()
        'grdCoincidencias.Enabled = False
        Label6.Text = "Se encontraron los siguientes proveedores que coinciden con su captura."
        Label8.Text = "Si el proveedor que esta capturando aparece en la lista, de doble clic sobre el para activarlo en su nave."
        Label5.Text = "   Cerrar"
        Label9.Text = ""
        altaproveedor = 1
        ' End If


    End Sub

    Public Sub LlenarTablaContactosCobranza()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosCobranza As New DataTable
        grdCoincidencias.DataSource = Nothing
        dtListaContactosCobranza = objBU.BuscaCoincidenciaNombre(busqueda)
        grdCoincidencias.DataSource = dtListaContactosCobranza
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub LlenarTablaCoincidenciasDage()
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Dim objBU As New ProveedorBU
        Dim dtListaContactosCobranza As New DataTable
        grdCoincidencias.DataSource = Nothing
        dtListaContactosCobranza = objBU.BuscaCoincidenciaNombreDAGE(busqueda)
        grdCoincidencias.DataSource = dtListaContactosCobranza
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Public Sub diseniogrdContactosCobranza()

        editar = False
        With grdCoincidencias.DisplayLayout.Bands(0)
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            .Columns("ID SICY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RFC").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("RAZON SOCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID SAY").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NOMBRE COMERCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            '.Columns("GIRO").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID SICY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("ID SAY").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns("RFC").Width = 50
            '.Columns("GIRO").Width = 40
            .Columns("ID SICY").Width = 30
            .Columns("ID SAY").Width = 30
            ' grdCoincidencias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            '.PerformAutoResizeColumns(True, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            grdCoincidencias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            Me.Cursor = Windows.Forms.Cursors.Default
        End With
    End Sub

    Public Sub diseniogrd2()

        editar = False
        With grdCoincidencias.DisplayLayout.Bands(0)
            .Columns("NOMBRE COMERCIAL").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("ID").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("NAVE").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            .Columns("ID").Width = 40
            .Columns("ID").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            grdCoincidencias.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

            For value = 0 To grdCoincidencias.Rows.Count
                If busqueda = grdCoincidencias.Rows(value).Cells("NOMBRE COMERCIAL").Text Then
                    grdCoincidencias.Rows(value).Cells("NOMBRE COMERCIAL").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000")
                End If
            Next
            Me.Cursor = Windows.Forms.Cursors.Default
        End With
    End Sub

    Public Function AgregarNave()

        Dim objBU As New ProveedorBU
        Dim EntidadNave As New NaveProveedor
        EntidadNave.prna_activo = "SI"
        EntidadNave.dage_proveedorid = idProveedor
        EntidadNave.nave_naveid = naveid
        EntidadNave.prna_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadNave.prna_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        EntidadNave.prna_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
        EntidadNave.prna_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")
        objBU.AsignarNave(EntidadNave)

    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub grdCoincidencias_DoubleClick(sender As Object, e As EventArgs) Handles grdCoincidencias.DoubleClick
        Try
            asignarProveedor()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub asignarProveedor()
        Dim dtLista As New DataTable
        If altaproveedor = 0 Then

            idProveedor = CInt(grdCoincidencias.ActiveRow.Cells("ID SAY").Text)

            If idProveedor > 0 Then

                dtLista = objBu.BuscaUsuarNaveRepetida(naveid, idProveedor)

                If dtLista.Rows.Count > 0 Then
                    objAdvertencia.mensaje = "Esa nave ya fue asignada anteriormente."
                    objAdvertencia.ShowDialog()
                Else
                    objConfirmacion.mensaje = "¿Está seguro de activar este proveedor en la nave " + naveNombre.ToString + " ?"
                    If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        respuesta = True
                        objExito.mensaje = "Proveedor asignado a la nave correctamente."
                        objExito.ShowDialog()
                        AgregarNave()
                        Me.Close()
                        FORM_.Close()
                    End If
                End If
            Else
                objAdvertencia.mensaje = "Favor de seleccionar un RFC de la lista"
                objAdvertencia.ShowDialog()
            End If
        Else
            idProveedor = CInt(grdCoincidencias.ActiveRow.Cells("ID SAY").Text)
            If idProveedor > 0 Then
                Dim objBU As New ProveedorBU
                Dim EntidadNave As New NaveProveedor


                ' If NAVEX <> 0 Then

                Dim dtL = objBU.BuscaUsuarNaveRepetida(naveid, idProveedor)
                If dtL.Rows.Count > 0 Then
                    objAdvertencia.mensaje = "Ese proveedor ya esta asignado a esa nave."
                    objAdvertencia.ShowDialog()
                Else
                    EntidadNave.prna_activo = "SI"
                    EntidadNave.dage_proveedorid = idProveedor
                    EntidadNave.nave_naveid = naveid
                    EntidadNave.prna_usuariocreoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    EntidadNave.prna_usuariomodificoid = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
                    EntidadNave.prna_fechacreacion = DateTime.Now.ToString("dd/MM/yyyy")
                    EntidadNave.prna_fechamodificacion = DateTime.Now.ToString("dd/MM/yyyy")

                    objConfirmacion.mensaje = "¿Está seguro de activar este proveedor a su nave?"
                    If objConfirmacion.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        objBU.AsignarNave(EntidadNave)
                        objExito.mensaje = "Nave asignada con éxito."
                        objExito.ShowDialog()
                        cerrar = 1
                        Me.Close()
                        Dim form As New CatalogoProveedoresForm
                        form.actualizar()
                        Dim form2 As New AltaProveedoresForm
                        form2.Close()
                        form2.Hide()

                        'LlenarTablaNaveProveedor()
                        'diseniogrdNavesProveedor()
                    End If
                End If

                'End If

            Else
            End If
        End If
    End Sub

    Public Sub AsignarNave(ByVal f As AltaProveedoresForm)
        FORM_ = f
    End Sub

    Public Sub AsignarNaves(ByVal f As ModificarProveedoresForm)
        FORMM_ = f
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            asignarProveedor()
        Catch ex As Exception
        End Try
    End Sub

End Class