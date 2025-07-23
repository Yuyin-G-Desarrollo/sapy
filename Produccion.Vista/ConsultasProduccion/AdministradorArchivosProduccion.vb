Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraPrinting
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Tools

Public Class AdministradorArchivosProduccion
    Public vLstIdEstilo As New List(Of EstiloArchivosTecnicos)
    Public vEsDepto As Boolean = False
    Public vIdNave As Integer?

    Private Sub AdministradorArchivosProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized

        If vEsDepto = False Then
            lblTituloT.Visible = False
            lblTituloOtros.Visible = True
            vwAdminArchivos.Columns(2).Caption = "Categorías"
            grdDescripcion.Visible = False
            gpbArticulos.Visible = False
        Else
            lblTituloT.Visible = True
            lblTituloOtros.Visible = False
            vwAdminArchivos.Columns(2).Caption = "Departamentos"

        End If

        EdicionGrdDescripcion()
        CargarDatos()

    End Sub

    Public Function ArmarXml() As String
        Dim vXmlEstilos As XElement = New XElement("ESTILOS")

        If vLstIdEstilo.Count > 0 Then
            For Each item In vLstIdEstilo
                Dim vNodo As XElement = New XElement("ESTILO")
                vNodo.Add(New XAttribute("idEstilo", item.PIdEstilo))
                vXmlEstilos.Add(vNodo)
            Next
        End If

        Return IIf(vLstIdEstilo.Count > 0, vXmlEstilos.ToString(), Nothing)
    End Function

    Public Sub CargarDatos()
        Dim obj As New AdministradorArchivosBU
        grdAdminArchivos.DataSource = obj.ObtieneArchivo(ArmarXml(), Nothing, IIf(vEsDepto = True, 0, 1), vIdNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
    End Sub

    Public Sub EdicionGrdDescripcion()
        If vLstIdEstilo.Count = 0 Then Return
        grdDescripcion.DataSource = vLstIdEstilo

        With grdDescripcion
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = False
            .DisplayLayout.Bands(0).Columns(1).Width = 100%
            .DisplayLayout.Bands(0).Columns(1).Header.Caption = "Descripción"
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

    End Sub

    Private Sub btnAlta_Click(sender As Object, e As EventArgs) Handles btnAlta.Click

        Dim form As New AltaDocumentosProduccion_Form
        form.vIdNave = vIdNave
        form.vEstiloId = ArmarXml()
        form.vEsDepto = vEsDepto
        form.vAdmonArchivosProduc = Me
        form.ShowDialog()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim vNum = vwAdminArchivos.DataRowCount
        Dim vIdArchivo As Integer = 0
        Dim vDocumento As String = String.Empty
        Dim vIdCategoria As Integer = 0
        Dim vNombreArchivo As String = String.Empty
        Dim vTipoDocumento As String = String.Empty

        If vwAdminArchivos.FocusedRowHandle >= 0 Then
            For item As Integer = 0 To vNum Step 1
                If CBool(vwAdminArchivos.IsRowSelected(vwAdminArchivos.GetVisibleRowHandle(item))) = True Then
                    vIdArchivo = vwAdminArchivos.GetRowCellValue(item, "IdArchivo").ToString()
                    vDocumento = vwAdminArchivos.GetRowCellValue(item, "Documento").ToString()
                    vIdCategoria = vwAdminArchivos.GetRowCellValue(item, "IdDepartamento").ToString()
                    vNombreArchivo = vwAdminArchivos.GetRowCellValue(item, "NombreDocumento").ToString()
                    vTipoDocumento = vwAdminArchivos.GetRowCellValue(item, "TipoDocumento").ToString()

                End If
            Next
            Dim form As New AltaDocumentosProduccion_Form
            form.vIdArchivo = vIdArchivo
            form.vDocumento = vDocumento
            form.vIdCategoria = vIdCategoria
            form.vEsDepto = vEsDepto
            form.vNombreDocumento = vNombreArchivo
            form.vTipoDocumento = vTipoDocumento
            form.vAdmonArchivosProduc = Me
            form.ShowDialog()
        Else
            Dim FormaError As New ErroresForm
            FormaError.mensaje = "Seleccione un archivo"
            FormaError.ShowDialog()
        End If

    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor

            If vwAdminArchivos.DataRowCount > 0 Then

                If vEsDepto = False Then
                    nombreReporte = "Produccion_AdministradorOtrosArchivos"
                Else
                    nombreReporte = "Produccion_AdministradorArchivosTecnicos"
                End If

                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then
                        If vwAdminArchivos.GroupCount > 0 Then
                            vwAdminArchivos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            vwAdminArchivos.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        show_message("Exito", "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                show_message("Advertencia", "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Advertencia", "No se encontro el archivo")
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 95
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 205
    End Sub

    Public Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        CargarDatos()
    End Sub

    Public Sub show_message(ByVal tipo As String, ByVal mensaje As String)

        If tipo.ToString.Equals("Advertencia") Then
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = mensaje
            mensajeAdvertencia.ShowDialog()
        End If

        If tipo.ToString.Equals("Aviso") Then
            Dim mensajeAviso As New AvisoForm
            mensajeAviso.mensaje = mensaje
            mensajeAviso.ShowDialog()
        End If

        If tipo.ToString.Equals("Error") Then
            Dim mensajeError As New ErroresForm
            mensajeError.mensaje = mensaje
            mensajeError.ShowDialog()
        End If

        If tipo.ToString.Equals("Exito") Then
            Dim mensajeExito As New ExitoForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()
        End If

        If tipo.ToString.Equals("Confirmar") Then
            Dim mensajeExito As New ConfirmarForm
            mensajeExito.mensaje = mensaje
            mensajeExito.ShowDialog()

        End If
    End Sub
End Class