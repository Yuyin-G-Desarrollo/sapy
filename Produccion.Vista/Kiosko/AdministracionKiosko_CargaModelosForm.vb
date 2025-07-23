Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports Produccion.Negocios
Imports Tools
Imports Tools.modMensajes

Public Class AdministracionKiosko_CargaModelosForm
    Dim dtModelosImportado As DataTable = New DataTable
    Dim archivoSeleccionado As String = String.Empty

    Private Sub AdministracionKiosko_CargaModelosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InicializarFormulario()
    End Sub

    Private Sub InicializarFormulario()
        Try
            Dim objAdministracionKioskoBU As New AdministracionKioskoBU
            Cursor = Cursors.WaitCursor
            Dim dtModelos As DataTable = objAdministracionKioskoBU.ConsultarModelosImportadosVigentes()
            Cursor = Cursors.Default
            If dtModelos.Rows.Count > 0 Then
                lblUsuario.Text = dtModelos.Rows(0)("UsuarioImportacion")
                lblFecha.Text = dtModelos.Rows(0)("FechaImportacion")
            End If
            grdModelosImportados.DataSource = Nothing
            grdModelosImportados.DataSource = dtModelos
            lblRegistros.Text = Val(dtModelos.Rows.Count).ToString("N0")
            lblUltimaDistribucion.Text = Date.Now
            DiseñoGrid.AlternarColorEnFilas(grvModelosImportados)
            grvModelosImportados.BestFitColumns()
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un problema al inicializar la pantalla. Intente nuevamente")
        End Try
    End Sub

    Private Sub btnImportarInformacion_Click(sender As Object, e As EventArgs) Handles btnImportarInformacion.Click
        LeerArchivo()
    End Sub


    Private Sub LeerArchivo()
        Try
            'Generamos variables de la libreria de Excel
            Dim cnn As New OleDb.OleDbConnection
            Dim da As New OleDb.OleDbDataAdapter
            Dim cmd As New OleDb.OleDbCommand

            'Enviamos la alerta de selección de archivo
            Dim ofd As New OpenFileDialog
            ofd.Filter = "*.xlsx|*.xlsx|Excel|*.xls|Excel|*.xlsm"
            If ofd.ShowDialog() <> DialogResult.OK Then
                Tools.MostrarMensaje(Mensajes.Warning, "Debes seleccionar un archivo para realizar la importación")
                Return
            End If
            archivoSeleccionado = ofd.FileName
            'Generamos consulta a la información
            cnn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & archivoSeleccionado & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
            cmd.Connection = cnn
            cmd.CommandText = "SELECT * FROM [Pedidos$]"
            cmd.CommandType = CommandType.Text
            da.SelectCommand = cmd
            'Generamos la información del Excel en el DataTable
            dtModelosImportado = New DataTable
            da.Fill(dtModelosImportado)
            cnn.Close()

            If dtModelosImportado.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "No hay información que importar")
                Return
            End If

            'Generamos el nombrado de las nuevas columnas
            dtModelosImportado.Columns(3).ColumnName = "Modelo*"
            dtModelosImportado.Columns(4).ColumnName = "PielColor*"
            dtModelosImportado.Columns(5).ColumnName = "Coleccion*"
            dtModelosImportado.Columns(6).ColumnName = "Familia*"
            dtModelosImportado.Columns(9).ColumnName = "Temporada*"
            dtModelosImportado.Columns(10).ColumnName = "Corrida*"
            dtModelosImportado.Columns(22).ColumnName = "Marca*"

            Dim columnasAConservar As New List(Of String) From {
                "Modelo*", "PielColor*", "Coleccion*", "Familia*", "Temporada*", "Corrida*", "Marca*"
            }

            For Each columna As DataColumn In dtModelosImportado.Columns.Cast(Of DataColumn)().ToList()
                If Not columnasAConservar.Contains(columna.ColumnName) Then
                    dtModelosImportado.Columns.Remove(columna)
                End If
            Next

            For index = 0 To dtModelosImportado.Columns.Count - 1
                dtModelosImportado.Columns(index).ColumnName = dtModelosImportado.Columns(index).ColumnName.ToString.Replace("*", "")
            Next

            For index = 0 To dtModelosImportado.Columns.Count - 1
                If dtModelosImportado.Columns(index).DataType <> GetType(String) Then
                    Tools.MostrarMensaje(Mensajes.Warning, $"La columna {dtModelosImportado.Columns(index).ColumnName} tiene un tipo diferente a Texto")
                    Return
                End If
            Next

            Dim objAdministracionKioskoBU As New AdministracionKioskoBU
            Cursor = Cursors.WaitCursor
            Dim dtRespuestaImportacion = objAdministracionKioskoBU.InsertarImportacionModelos(archivoSeleccionado, dtModelosImportado)
            Cursor = Cursors.Default
            If dtRespuestaImportacion.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un problema al guardar la información. Intente nuevamente")
                Return
            End If

            If dtRespuestaImportacion.Rows(0)("BanderaRespuesta") <> 1 Then
                Tools.MostrarMensaje(Mensajes.Warning, dtRespuestaImportacion.Rows(0)("ErrorRespuesta"))
                Return
            End If
            Tools.MostrarMensaje(Mensajes.Success, dtRespuestaImportacion.Rows(0)("MensajeRespuesta"))
            InicializarFormulario()


        Catch ex As Exception
            Tools.MostrarMensaje(Mensajes.Warning, "Ocurrio un problema al generar la lectura del archivo" + ex.Message)
        End Try
    End Sub

    Private Sub grvModelosImportados_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles grvModelosImportados.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class