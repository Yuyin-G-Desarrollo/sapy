Imports Tools

Public Class EtiquetasLengua_ColeccionesSindiseñoForm

    Public NaveSICYID As Integer = 0
    Public LoteInicio As Integer = 0
    Public LoteFin As Integer = 0
    Public Año As Integer = 0
    Public TieneDatos As Boolean = False

    Dim objBU As New Programacion.Negocios.EtiquetasBU

    Private Sub EtiquetasLengua_ColeccionesSindiseñoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()
    End Sub


    Private Sub MostrarInformacion()
        Dim dt As DataTable
        dt = objBU.ValidacionDiseñoEtiquetaLengua(LoteInicio, LoteFin, NaveSICYID, Año)
        If dt.Rows.Count > 0 Then
            TieneDatos = True
        Else
            TieneDatos = False
        End If

        grdEtiquetasDetalles.DataSource = dt

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnClientesPruebaDetallesImprimir_Click(sender As Object, e As EventArgs) Handles btnClientesPruebaDetallesImprimir.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Try
            With fbdUbicacionArchivo
                .Reset()
                .Description = " Seleccione una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                .ShowNewFolderButton = True

                Dim ret As DialogResult = .ShowDialog
                Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                If ret = Windows.Forms.DialogResult.OK Then
                    grdEtiquetasDetalles.ExportToXlsx(.SelectedPath + "\Datos_EtiquetasLenguaSinDiseño_" + fecha_hora + ".xlsx")

                End If
                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los datos se exportaron correctamente: " & "Datos_EtiquetasLenguaSinDiseño_" + fecha_hora + ".xlsx")
                .Dispose()
                Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_EtiquetasLenguaSinDiseño_" + fecha_hora + ".xlsx")

            End With
        Catch ex As Exception
            Utilerias.show_message(Utilerias.TipoMensaje.Errores, ex.Message.ToString())
        End Try
    End Sub


End Class