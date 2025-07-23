Imports System.IO
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Tools

Public Class EscaneoMasivoEtiquetasForm
    Dim tbl_CodigosLeidos As New DataTable
    Dim tbl_EtiquetasOrdenadas As New DataTable
    Dim existeEtiqueta As Boolean = False

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles btnImprimirEtiquetas.Click
        'VERIFICAR
        If cmbImpresion.Text = "" Or chkCaja.Checked = False And chkSuela.Checked = False And chkColgante.Checked = False Then
            Dim Alerta As New AdvertenciaForm
            Alerta.mensaje = "Debe seleccionar tipo de impresión o de etiqueta"
            Alerta.ShowDialog()
            Exit Sub
        End If

        Dim accion As Integer = 0
        Dim obj As New Object
        Dim archivo As New Object
        Dim ruta As String = "C:\SAY\Etiquetas.txt"
        Dim sArchivoOrigen As String = "C:\SICY\Etiquetas.bat"
        Dim sRutaDestino As String = "C:\SAY\Etiquetas.bat"
        Dim ArchivoBat As String = "C:\SAY\Etiquetas.bat"

        Dim var_Etiqueta As String = String.Empty
        Dim var_Coleccion As String = String.Empty
        Dim var_UDM As String = String.Empty
        Dim var_TipoImpresion As String = String.Empty

        Dim fsBat As Stream = File.Create(ArchivoBat)
        Dim swBat As New System.IO.StreamWriter(fsBat)

        obj = CreateObject("Scripting.FileSystemObject")

        archivo = obj.CreateTextFile(ruta, True)

        Try

            For Each rowEt As UltraGridRow In grdEtiquetas.Rows

                var_Etiqueta = rowEt.Cells(3).Text.Trim
                var_Coleccion = rowEt.Cells(10).Text.Trim
                var_UDM = rowEt.Cells(12).Text.Trim
                var_TipoImpresion = cmbImpresion.Text

                If chkCaja.Checked = True And chkSuela.Checked = True Then
                    accion = 4
                ElseIf chkCaja.Checked = True Then
                    accion = 2
                ElseIf chkSuela.Checked = True Then
                    accion = 3
                ElseIf chkColgante.Checked = True Then
                    accion = 1
                End If

                If accion <> 0 Then
                    Dim existe As Boolean
                    Dim objNegocios As New Negocios.PedidosMuestrasOP
                    existe = System.IO.Directory.Exists("C:\SAY")
                    If Not existe Then
                        System.IO.Directory.CreateDirectory("C:\SAY")
                    End If

                    If existe = System.IO.Directory.Exists("C:\SAY\Etiquetas.txt") Then
                        System.IO.Directory.CreateDirectory("Etiquetas.txt")
                    End If

                    Dim dt As DataTable
                    dt = objNegocios.VerListaEtiquetasMuestras(var_Etiqueta, accion, var_TipoImpresion)
                    For Each row As DataRow In dt.Rows
                        archivo.WriteLine(row.Item("ZPL").ToString.Trim)
                    Next
                    archivo.WriteLine("" + vbLf)
                End If
            Next
            archivo.close()

            swBat.WriteLine("COPY C:\SAY\ETIQUETAS.TXT C:\PRN")
            swBat.Close()
            Shell("C:\SAY\Etiquetas.bat")

            Dim mensaje As New ExitoForm
            mensaje.mensaje = "El registro se realizó con éxito."
            mensaje.ShowDialog()
            cmbImpresion.SelectedIndex = 0
            grdEtiquetas.DataSource = Nothing
            'grdLecturaCodigos.DataSource = Nothing
            chkColgante.Checked = False
            chkCaja.Checked = False
            chkSuela.Checked = False
            btnCerrar_Click(sender, e)

        Catch ex As Exception
            Dim mensaje As New ErroresForm
            mensaje.mensaje = ex.Message.ToString
            mensaje.ShowDialog()
            archivo.close()
        End Try
    End Sub

    Private Sub txtModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEtiqueta.KeyDown
        If e.KeyCode <> Keys.Enter Then
            Return
        End If
        If e.KeyCode = Keys.Enter Then
            'llenarTablaCodigosLeidos(txtEtiqueta.Text)
            verificaEtiquetaUnica(txtEtiqueta.Text)
            llenarTablaDeEtiquetasPorEscaneo(txtEtiqueta.Text)
            txtEtiqueta.Text = ""
        End If
    End Sub

    Public Sub verificaEtiquetaUnica(ByVal etiqueta As String)
        If grdEtiquetas.Rows.Count > 0 Then
            For Each row As UltraGridRow In grdEtiquetas.Rows
                If etiqueta = row.Cells(3).Text Then
                    existeEtiqueta = True
                    Exit Sub
                Else
                    existeEtiqueta = False
                End If
            Next
        End If
    End Sub

    'Public Sub llenarTablaCodigosLeidos(ByVal Codigo As String)
    '    Dim nuevoCodigo As String = String.Empty
    '    nuevoCodigo = Codigo
    '    If nuevoCodigo = "" Or nuevoCodigo = String.Empty Then
    '        Exit Sub
    '    Else
    '        If tbl_CodigosLeidos.Rows.Count = 0 Then
    '            tbl_CodigosLeidos.Columns.Add("Etiqueta")
    '        End If
    '        tbl_CodigosLeidos.Rows.Add(New Object() {nuevoCodigo})
    '        grdLecturaCodigos.DataSource = tbl_CodigosLeidos
    '    End If


    'End Sub

    Public Function QuitarCaracteres(ByVal cadena As String, Optional ByVal chars As String = "#.:<>{}[]^+,;_-/*?¿!$%&/¨Ññ()='áéíóúÁÉÍÓÚ¡|@Ã› " + Chr(34)) As String
        Dim i As Integer
        Dim nCadena As String

        nCadena = cadena
        For i = 1 To Len(chars)
            nCadena = Replace(nCadena, Mid(chars, i, 1), "")
        Next i

        QuitarCaracteres = nCadena
    End Function

    Private Sub txtModelo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtEtiqueta.KeyUp
        txtEtiqueta.Text = QuitarCaracteres(txtEtiqueta.Text)
    End Sub

    'Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
    '    Dim objBU As New Negocios.PedidosMuestrasOP
    '    Dim Etiquetas As String = String.Empty

    '    If grdLecturaCodigos.Rows.Count > 0 Then

    '        For Each row As UltraGridRow In grdLecturaCodigos.Rows
    '            If row.Index = 0 Then
    '                Etiquetas += "" + row.Cells(0).Text.Trim + ""
    '            Else
    '                Etiquetas += ", " + row.Cells(0).Text.Trim + ""
    '            End If
    '        Next

    '        grdEtiquetas.DataSource = objBU.verListaInventariosPorEtiqueta(Etiquetas)

    '    End If
    'End Sub

    Public Sub llenarTablaDeEtiquetasPorEscaneo(ByVal Etiqueta As String)
        Dim objBU As New Negocios.PedidosMuestrasOP
        Dim Etiquetas As String = String.Empty
        Dim tbl_tablaOrdenamiento As DataTable = Nothing
        tbl_EtiquetasOrdenadas = Nothing

        'If grdLecturaCodigos.Rows.Count > 0 Then

        '    For Each row As UltraGridRow In grdLecturaCodigos.Rows
        '        If row.Index = 0 Then
        '            Etiquetas += "" + row.Cells(0).Text.Trim + ""
        '        Else
        '            Etiquetas += ", " + row.Cells(0).Text.Trim + ""
        '        End If
        '    Next
        If Etiqueta = "" Or Etiqueta = String.Empty Then
            Exit Sub
        Else
            If tbl_CodigosLeidos.Rows.Count = 0 Then
                tbl_CodigosLeidos.Columns.Add("Etiqueta")
            End If

            tbl_CodigosLeidos.Rows.Add(New Object() {Etiqueta})

            For I As Integer = 0 To tbl_CodigosLeidos.Rows.Count - 1
                If tbl_CodigosLeidos.Rows(I).Item("Etiqueta").ToString() <> "" Then
                    If Etiquetas = String.Empty Then
                        Etiquetas += "" + tbl_CodigosLeidos.Rows(I).Item("Etiqueta").ToString().Trim() + ""
                    Else
                        Etiquetas += ", " + tbl_CodigosLeidos.Rows(I).Item("Etiqueta").ToString().Trim() + ""
                    End If
                End If
            Next

            grdEtiquetas.DataSource = objBU.verListaInventariosPorEtiqueta(Etiquetas)
        End If

        'End If
    End Sub

    Private Sub EscaneoMasivoEtiquetasForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'diseñoGridLeerCodigos()
        txtEtiqueta.Select()
        diseñogridEtiquetas()
    End Sub

    'Public Sub diseñoGridLeerCodigos()
    '    grdLecturaCodigos.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
    '    grdLecturaCodigos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    '    grdLecturaCodigos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    '    grdLecturaCodigos.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
    '    'grdLecturaCodigos.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

    '    For Each row In grdLecturaCodigos.Rows
    '        row.Activation = Activation.NoEdit
    '    Next

    '    grdLecturaCodigos.DisplayLayout.Override.AllowAddNew = AllowAddNew.No


    'End Sub

    Public Sub diseñogridEtiquetas()
        grdEtiquetas.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdEtiquetas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdEtiquetas.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
        grdEtiquetas.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        'grdEtiquetas.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect

        For Each row In grdEtiquetas.Rows
            row.Activation = Activation.NoEdit
        Next

        grdEtiquetas.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
    End Sub

    Private Sub chkColgante_CheckedChanged(sender As Object, e As EventArgs) Handles chkColgante.CheckedChanged
        If chkColgante.Checked Then
            chkCaja.Checked = False
            chkSuela.Checked = False
        End If
    End Sub

    Private Sub chkCaja_CheckedChanged(sender As Object, e As EventArgs) Handles chkCaja.CheckedChanged
        If chkCaja.Checked Then
            chkColgante.Checked = False
        End If
    End Sub

    Private Sub chkSuela_CheckedChanged(sender As Object, e As EventArgs) Handles chkSuela.CheckedChanged
        If chkSuela.Checked Then
            chkColgante.Checked = False
        End If
    End Sub

    'Private Sub txtEtiqueta_Leave(sender As Object, e As EventArgs) Handles txtEtiqueta.Leave
    '    Me.txtEtiqueta.Focus()
    'End Sub
End Class