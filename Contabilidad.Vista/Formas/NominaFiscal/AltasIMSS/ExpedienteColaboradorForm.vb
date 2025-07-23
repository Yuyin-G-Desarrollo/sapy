Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Framework.Negocios
Imports System.Net

Public Class ExpedienteColaboradorForm

    Public idColaborador As Int32
    Public colaborador As String = String.Empty
    Public nss As String = String.Empty
    Public Const rutaAcuses As String = "IMAGENES/"
    Dim directorio As String = String.Empty
    Dim idExpediente As Int32 = 0

    Public Sub consultarListadoExpediente()
        Dim objBu As New Negocios.ColaboradoresContabilidadBU
        Dim dtExpediente As New DataTable
        Dim advertencia As New AdvertenciaForm
        dtExpediente = objBu.consultaListadoExpedienteColaborador(idColaborador)
        lblColaborador.Text = colaborador
        lblNSS.Text = nss

        If Not dtExpediente Is Nothing Then
            If dtExpediente.Rows.Count > 0 Then
                grdExpediente.DataSource = Nothing

                grdExpediente.DataSource = dtExpediente
                formatoGrid()
            End If
        Else

        End If



    End Sub

    Public Sub formatoGrid()
        With grdExpediente.DisplayLayout.Bands(0)

            .Columns("carpeta").Hidden = True
            .Columns("idExpediente").Hidden = True
            .Columns("nombreArchivo").Hidden = True

            .Columns("titulo").Header.Caption = "Título"
            .Columns("fSubida").Header.Caption = "Fecha Movimiento"
            .Columns("usuario").Header.Caption = "Usuario"


            .Columns("titulo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("fSubida").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            .Columns("usuario").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit


            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)

        End With

        grdExpediente.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        grdExpediente.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdExpediente.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdExpediente.DisplayLayout.Override.RowSelectorWidth = 35
        grdExpediente.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdExpediente.Rows(0).Selected = True

        'grdColaboradores.DisplayLayout.Bands(0).Columns("SemanaBaja").Width = 50

        grdExpediente.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        grdExpediente.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
    End Sub

    Public Sub descargarArchivo()
        Dim objTransferencias As New Tools.TransferenciaFTP
        Dim objFTP As New Tools.TransferenciaFTP
        Dim nombreArchivo As String = String.Empty
        Dim rutaArchivo As String = String.Empty

        guardarArchivo.RestoreDirectory = True
        guardarArchivo.Title = "Guardar en:"

        guardarArchivo.Filter = "JPEG|*.jpg"

        nombreArchivo = grdExpediente.ActiveRow.Cells("nombreArchivo").Value()
        rutaArchivo = grdExpediente.ActiveRow.Cells("carpeta").Value()


        guardarArchivo.FileName = nombreArchivo
        Dim tabla() As String
        If guardarArchivo.ShowDialog = Windows.Forms.DialogResult.OK Then

            tabla = Split(guardarArchivo.FileName, "\")
            Dim Rutaguardar As String = ""
            For n = 0 To UBound(tabla, 1)
                If UBound(tabla) = n Then
                Else
                    Rutaguardar += tabla(n) + "\"
                End If
            Next

            Dim Origen As String = ""
            Origen = rutaArchivo
            objFTP.DescargarArchivo(Origen, Rutaguardar, nombreArchivo)

            Dim exito As New ExitoForm
            exito.mensaje = "Se descargó correctamente el archivo"
            exito.ShowDialog()
        End If
    End Sub

    Public Sub reemplazarArchivo()
        If idExpediente <> 0 Then
            Dim ruta As String = String.Empty
            Dim exito As New ExitoForm
            ofdReemplazar.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            ofdReemplazar.Filter = "PDF|*.pdf;"
            ofdReemplazar.FilterIndex = 3
            ofdReemplazar.ShowDialog()

            ruta = ofdReemplazar.FileName
            Dim mensajeConfirmacion As New ConfirmarForm
            mensajeConfirmacion.mensaje = "¿Está seguro de reemplazar el archivo? Posteriormente no podrán realizarse cambios"

            If mensajeConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
                If subirArchivo(ruta) Then
                    Dim objBu As New Negocios.ColaboradoresContabilidadBU
                    objBu.actualizarArchivoExpediente(idColaborador, idExpediente, IO.Path.GetFileName(ruta), Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
                    consultarListadoExpediente()
                    exito.mensaje = "Archivo reemplazado correctamente"
                    exito.ShowDialog()
                End If
            End If

        Else
            Dim advertencia As New AdvertenciaForm
            advertencia.mensaje = "Seleeccione un archivo valido"
            advertencia.ShowDialog()
        End If

    End Sub

    Private Function subirArchivo(ByVal ruta As String) As Boolean
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
            Dim rutaArchivo As String = String.Empty

            request.Credentials = New NetworkCredential(objFTP.obtenerUsuario, objFTP.obtenerContrasena)
            directorio = rutaAcuses & idColaborador

            If ruta <> "" Then
                objFTP.EnviarArchivo(directorio, ruta)
                rutaArchivo = objFTP.obtenerURL & "/" & directorio & "/" & IO.Path.GetFileName(ruta)

                If objFTP.FtpExisteArchivo(rutaArchivo) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch
            Return False
        End Try
    End Function

    Public Sub verificarPermisoReemplazar()
        If PermisosUsuarioBU.ConsultarPermiso("LISTA_COLABO", "REEMPLAZAR_ARCHIVO") Then
            pnlRemplazar.Visible = True
        Else
            pnlRemplazar.Visible = False
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub ExpedienteColaboradorForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        consultarListadoExpediente()
        verificarPermisoReemplazar()
    End Sub

    Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        descargarArchivo()
    End Sub

    Private Sub btnRemplazar_Click(sender As Object, e As EventArgs) Handles btnRemplazar.Click
        reemplazarArchivo()
    End Sub

    Private Sub grdExpediente_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdExpediente.ClickCell
        With grdExpediente
            If .ActiveRow Is Nothing Then Exit Sub
            If .ActiveRow.Index < 0 Then Exit Sub
        End With


        idExpediente = grdExpediente.ActiveRow.Cells("idExpediente").Value()
       
    End Sub

    Private Sub grdExpediente_DoubleClick(sender As Object, e As EventArgs) Handles grdExpediente.DoubleClick
        Dim rutaArchivo As String = String.Empty
        Dim nombreArchivo As String = String.Empty
        Dim rutaD As String = String.Empty
        Try
            nombreArchivo = grdExpediente.ActiveRow.Cells("nombreArchivo").Value()
            rutaArchivo = grdExpediente.ActiveRow.Cells("carpeta").Value()
            rutaD = rutaFTPHttp + rutaArchivo + "/" + nombreArchivo
            If rutaArchivo <> "" Then
                Process.Start(rutaD)
            End If
        Catch ex As Exception
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "No se encontro el archivo"
            advetencia.ShowDialog()
        End Try

    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click
        Dim rutaArchivo As String = String.Empty
        Dim nombreArchivo As String = String.Empty
        Dim rutaD As String = String.Empty
        Try
            nombreArchivo = grdExpediente.ActiveRow.Cells("nombreArchivo").Value()
            rutaArchivo = grdExpediente.ActiveRow.Cells("carpeta").Value()
            rutaD = rutaFTPHttp + rutaArchivo + "/" + nombreArchivo
            If rutaArchivo <> "" Then
                Process.Start(rutaD)
            End If
        Catch ex As Exception
            Dim advetencia As New AdvertenciaForm
            advetencia.mensaje = "No se encontro el archivo"
            advetencia.ShowDialog()
        End Try
    End Sub
End Class