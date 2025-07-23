Imports Tools.Controles
Imports Infragistics.Win.UltraWinGrid
Imports System.Drawing
Imports Infragistics.Win
Imports System.IO
Imports System.Xml

Public Class ReemplazarXMLDañadosForm
    Public hsXMLDañados As New HashSet(Of String)

    Dim Archivos As New Entidades.ColaboradorExpediente
    Dim Poliza As New Entidades.Polizas

    Dim dtXMLDañados As New DataTable
    Dim RutaArchivoXML As String

    Private Sub ReemplazarXMLDañadosForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen

        If hsXMLDañados.Count > 0 Then
            Dim xmlSplit As String()
            Dim comprobanteSplit As String()

            dtXMLDañados.Columns.Add("TIPO", Type.GetType("System.String"))
            dtXMLDañados.Columns.Add("NOMBRE", Type.GetType("System.String"))
            dtXMLDañados.Columns.Add("XML", Type.GetType("System.String"))
            dtXMLDañados.Columns.Add("RUTA", Type.GetType("System.String"))
            dtXMLDañados.Columns.Add("REFERENCIA", Type.GetType("System.String"))
            dtXMLDañados.Columns.Add("COMPROBANTE", Type.GetType("System.String"))

            For Each item In hsXMLDañados
                xmlSplit = item.Split("|")
                comprobanteSplit = xmlSplit(0).Split("\")

                If xmlSplit.Length = 4 Then
                    Dim rwFila As DataRow = dtXMLDañados.NewRow()
                    rwFila("TIPO") = xmlSplit(1)
                    rwFila("NOMBRE") = xmlSplit(2)
                    rwFila("XML") = xmlSplit(0)
                    rwFila("REFERENCIA") = xmlSplit(3)
                    rwFila("COMPROBANTE") = comprobanteSplit(comprobanteSplit.Count - 1)


                    dtXMLDañados.Rows.Add(rwFila)
                End If
            Next

            grdComprobantesFiscales.DataSource = dtXMLDañados
        Else
            Mensajes_Y_Alertas("ADVERTENCIA", "No hay XML dañados en la lista")
            Me.Close()
        End If

    End Sub


    Private Sub grdComprobantesFiscales_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdComprobantesFiscales.InitializeLayout
        For Each col As UltraGridColumn In grdComprobantesFiscales.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = Activation.NoEdit
        Next

        With grdComprobantesFiscales
            .DisplayLayout.Bands(0).Columns("TIPO").Hidden = False
            .DisplayLayout.Bands(0).Columns("NOMBRE").Hidden = False
            .DisplayLayout.Bands(0).Columns("REFERENCIA").Hidden = False
            .DisplayLayout.Bands(0).Columns("XML").Hidden = True
            .DisplayLayout.Bands(0).Columns("COMPROBANTE").Hidden = False
            .DisplayLayout.Bands(0).Columns("XML").Style = ColumnStyle.Default

            .DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.RowSelectors = DefaultableBoolean.True
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 35
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
            .DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            .DisplayLayout.Override.AllowAddNew = AllowAddNew.No
            .DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        End With

    End Sub

    Private Sub btnXml_Click(sender As Object, e As EventArgs) Handles btnXml.Click
        If IsNothing(grdComprobantesFiscales.ActiveRow) = False Then
            If grdComprobantesFiscales.ActiveRow.IsDataRow Then
                If grdComprobantesFiscales.Selected.Rows.Count = 0 Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un registro para poder reempazar el XML")
                ElseIf grdComprobantesFiscales.Selected.Rows.Count > 1 Then
                    Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Hay mas de un registro seleccionado, seleccione solo un registro para poder reempazar el XML")
                ElseIf grdComprobantesFiscales.Selected.Rows.Count = 1 Then
                    Dim row As UltraGridRow = grdComprobantesFiscales.ActiveRow
                    If String.IsNullOrEmpty(row.Cells("RUTA").Value.ToString) Then
                        ofdComprobantesFiscales.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Recent)
                        ofdComprobantesFiscales.Filter = "XML|*.xml"
                        ofdComprobantesFiscales.Filter = "XML|*.xml"
                        ofdComprobantesFiscales.FilterIndex = 3
                        Dim ruta As String

                        If ofdComprobantesFiscales.ShowDialog() = Windows.Forms.DialogResult.OK Then

                            Dim pregunta As New ConfirmarForm
                            pregunta.mensaje = "¿Está seguro que el archivo seleccionado es correcto? Posteriormente no podrá realizar cambios."
                            If pregunta.ShowDialog = Windows.Forms.DialogResult.OK Then

                                ruta = ofdComprobantesFiscales.FileName

                                Dim archivo() As String
                                archivo = Split(ruta, "\")

                                For n = 0 To UBound(archivo, 1)
                                    If UBound(archivo) = n Then
                                        Archivos.PNombreArchivo = archivo(n)
                                    End If
                                Next

                                Poliza = extraerUUID(ruta)

                                If Poliza.PrutaXML = "Error" Then
                                    Mensajes_Y_Alertas("ADVERTENCIA", "El XML que tratas de usar cuenta con errores.")
                                    grdComprobantesFiscales.ActiveRow.Selected = False
                                    grdComprobantesFiscales.ActiveRow = Nothing

                                    Exit Sub
                                Else
                                    Dim spltRuta() As String
                                    Dim RutaArchivo As String = String.Empty

                                    spltRuta = CStr(row.Cells("XML").Value).Split("\")

                                    For i = 0 To spltRuta.Length - 2 Step 1
                                        RutaArchivo += spltRuta(i) + "\"
                                    Next

                                    RutaArchivoXML = CStr(row.Cells("XML").Value)

                                    Try
                                        File.Delete(RutaArchivoXML)
                                        File.Copy(Path.Combine(ruta), Path.Combine(RutaArchivoXML))

                                        grdComprobantesFiscales.ActiveRow.Appearance.BackColor = Drawing.Color.LightGreen
                                        row.Cells("RUTA").Value = RutaArchivoXML
                                        grdComprobantesFiscales.ActiveRow.Selected = False
                                        grdComprobantesFiscales.ActiveRow.Activated = False
                                    Catch copyError As IOException
                                        Mensajes_Y_Alertas("ADVERTENCIA", "Ocurrió un error al copiar el archivo. Consulte este error con el área de TI: " + copyError.Message)
                                    End Try
                                End If
                            Else
                                Exit Sub
                            End If
                        End If
                    Else
                        Mensajes_Y_Alertas("ADVERTENCIA", "Ya se agregó un archivo XML para este registro.")
                    End If
                End If
            Else
                Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un registro para poder reempazar el XML")
            End If
        Else
            Tools.Controles.Mensajes_Y_Alertas("ADVERTENCIA", "Seleccione un registro para poder reempazar el XML")
        End If


    End Sub


    Public Function extraerUUID(ByVal Ruta As String) As Entidades.Polizas

        Dim reader As XmlTextReader = New XmlTextReader(Ruta)
        Dim lista As New Entidades.Polizas

        Try
            Do While (reader.Read())

                Select Case reader.NodeType
                    Case XmlNodeType.Element 'Mostrar comienzo del elemento.                    
                        If reader.HasAttributes Then 'If attributes exist
                            While reader.MoveToNextAttribute()
                                If reader.Name = "UUID" Then
                                    lista.Puuid = reader.Value
                                End If

                                If reader.Name = "serie" Then
                                    lista.Pserie = reader.Value
                                End If

                                If reader.Name = "folio" Then
                                    lista.Pfolio = reader.Value
                                End If

                                If reader.Name = "fecha" Then
                                    lista.Pfecha = reader.Value
                                End If

                            End While
                        End If
                End Select
            Loop
        Catch ex As Exception
            lista.PrutaXML = "Error"
        End Try
        Return lista
        reader.Close()
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub ReemplazarXMLDañadosForm_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim c As Integer = 0
        For Each ROW As UltraGridRow In grdComprobantesFiscales.Rows
            If ROW.Cells("RUTA").Text = "" Then
                c += 1
            End If
        Next

        If c > 0 Then
            If Mensajes_Y_Alertas("CONFIRMACION", "Aún hay XML sin corregir,    ¿Estas seguro que deseas salir?") = False Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class