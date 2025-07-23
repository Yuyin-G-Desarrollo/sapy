Imports System.Globalization
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.IO
Imports Tools


Public Class ImpresionEtiquetasEspecialesForm

    Dim objBU As New Programacion.Negocios.EtiquetasBU    
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"

    Private Sub ImpresionEtiquetasLotesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        dtmFechaPrograma.Value = Date.Now
        lblFechaUltimaActualizacion.Visible = False
        CargarNaves()
        chkSeleccionar.Checked = False
        cmbResolucionImpresora.SelectedIndex = 0
    End Sub

    Private Sub CargarNaves()
        Dim DTNAves As DataTable
        DTNAves = objBU.ConsultarNavesSICY()
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
        cmbNave.DataSource = DTNAves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "IdNave"
    End Sub

    Private Sub CargarInformacion()
        Dim dtinformacion As DataTable

        Try
            Cursor = Cursors.WaitCursor
            grdLotes.DataSource = Nothing
            DisenoGrid(grdLotes)
            dtinformacion = objBU.ConsultarLotesPorPrograma(cmbNave.SelectedValue, dtmFechaPrograma.Value.ToShortDateString())
            grdLotes.DataSource = dtinformacion            
            lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            lblFechaUltimaActualizacion.Visible = True
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", ex.Message.ToString)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNave.SelectedIndex > 0 Then
            CargarInformacion()
        Else
            show_message("Advertencia", "No se ha seleccionado una nave.")
        End If
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


    Private Sub DisenoGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        grid.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grid.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
        grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grid.DisplayLayout.Override.RowSelectorWidth = 35
        grid.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
        '        grid.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect
        grid.DisplayLayout.Override.CellClickAction = CellClickAction.EditAndSelectText

        grid.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow

        grid.DisplayLayout.Override.AllowAddNew = AllowAddNew.No
        grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.Solid
        grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard

        AgregarColumna(grid, "año", "Año", False, True, Nothing, 60, False, False, HAlign.Right)
        AgregarColumna(grid, "nave", "Nave", False, False, Nothing, 30, False, False, HAlign.Right)
        AgregarColumna(grid, "lote", "Lote", False, True, Nothing, 40, False, False, HAlign.Right)
        AgregarColumna(grid, "IdModelo", "IdModelo", False, True, Nothing, 80, False, False, HAlign.Right)
        AgregarColumna(grid, "IdCodigo", "IdCodigo", False, True, Nothing, 100, False, False, HAlign.Left)
        AgregarColumna(grid, "Coleccion", "Coleccion", False, True, Nothing, 120, False, False, HAlign.Left)
        AgregarColumna(grid, "talla", "Talla", False, True, Nothing, 70, False, False, HAlign.Right)
        AgregarColumna(grid, "color", "Color", False, True, Nothing, 80, False, False, HAlign.Left)
        AgregarColumna(grid, "pares", "Pares", False, False, Nothing, 60, True, False, HAlign.Right, , , , SummaryType.Sum)
        AgregarColumna(grid, "cortador", "Cortador", False, True, Nothing, 90, , , HAlign.Left)
        AgregarColumna(grid, "cortador_Forro", "Cortador " & vbCrLf & " Forro", False, True, Nothing, 90, , , HAlign.Left)
        AgregarColumna(grid, "Cliente_texto", "Cliente", True, True, Nothing, 200, , , HAlign.Left)
        AgregarColumna(grid, "cliente_Nombre", "Cliente", False, True, Nothing, 200, , , HAlign.Left)
        AgregarColumna(grid, "TotalPares", "Total " & vbCrLf & " Pares", True, True, Nothing, 60, True, , HAlign.Right)
        AgregarColumna(grid, "TotalLotes", "Total " & vbCrLf & " Lotes", True, True, Nothing, 60, True, , HAlign.Right)
        AgregarColumna(grid, "primer_lote", "Primer " & vbCrLf & " Lote", True, True, Nothing, 60, False, , HAlign.Right)
        AgregarColumna(grid, "ultimo_lote", "Ultimo " & vbCrLf & " Lote", True, True, Nothing, 60, False, , HAlign.Right)
        
        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub AgregarColumna(ByRef grid As UltraGrid, ByVal Key As String, ByVal NombreColumna As String, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, ByVal ColorColumna As Color, Optional ByVal Width As Integer = -1, Optional ByVal SumarizarColumna As Boolean = False, Optional ByVal Edicion As Boolean = False, Optional ByVal Alineacion As HAlign = Nothing, Optional ByVal NEgrita As Boolean = False, Optional ByVal EsPorcentaje As Boolean = False, Optional ByVal Tooltip As String = "", Optional ByVal Operacion As SummaryType = SummaryType.Sum)
        With grid
            .DisplayLayout.Bands(0).Columns.Add(Key, NombreColumna)
            FormatoColumna(.DisplayLayout.Bands(0).Columns(Key), Ocultar, EsCadena, Width, EsPorcentaje)

            If IsNothing(ColorColumna) Then
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = Color.Black
            Else
                .DisplayLayout.Bands(0).Columns(Key).Header.Appearance.ForeColor = ColorColumna
            End If

            If SumarizarColumna = True Then
                SumarizarColumnaGrid(grid, Key, "Sumarizar " + Key, Operacion)
            End If

            If Tooltip <> "" Then
                grid.DisplayLayout.Bands(0).Columns(Key).Header.ToolTipText = Tooltip
            End If

            If IsNothing(Alineacion) = False Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.TextHAlign = Alineacion
            End If

            If NEgrita = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellAppearance.FontData.Bold = DefaultableBoolean.True
            End If

            If Edicion = True Then
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.AllowEdit
            Else
                .DisplayLayout.Bands(0).Columns(Key).CellActivation = Activation.NoEdit
            End If

        End With
    End Sub

    Private Sub FormatoColumna(ByRef columna As UltraGridColumn, ByVal Ocultar As Boolean, ByVal EsCadena As Boolean, Optional ByVal Width As Integer = -1, Optional ByVal EsPorcentaje As Boolean = False)
        Dim FormatoNumero As String = "###,###,##0"
        Dim FormatoPorcentaje As String = "##0%"
        columna.Hidden = Ocultar
        If EsCadena = True Then
            columna.CellAppearance.TextHAlign = HAlign.Left
        Else

            If EsPorcentaje = True Then
                columna.Format = FormatoPorcentaje
                columna.CellAppearance.TextHAlign = HAlign.Right
            Else
                columna.Format = FormatoNumero
                columna.CellAppearance.TextHAlign = HAlign.Right
            End If

        End If

        If Width <> -1 Then
            columna.Width = Width
        End If
    End Sub

    Private Sub SumarizarColumnaGrid(grid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal NombreColumna As String, ByVal Key As String, ByVal Operacion As SummaryType)
        Dim columnToSummarize As UltraGridColumn = grid.DisplayLayout.Bands(0).Columns(NombreColumna)
        Dim summary As SummarySettings = grid.DisplayLayout.Bands(0).Summaries.Add(Key, Operacion, columnToSummarize)
        summary.DisplayFormat = "{0:###,###,##0}"
        summary.Appearance.TextHAlign = HAlign.Right
        grid.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales"
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing        
        Dim dtInformacionEtiquetas As DataTable
        Dim LotesSeleccionados As String = String.Empty
        Dim PathArchivo As String

        Try
            Cursor = Cursors.WaitCursor
            For Each Fila As UltraGridRow In grdLotes.Rows
                If CBool(Fila.Cells(" ").Value) = True Then
                    If LotesSeleccionados = String.Empty Then
                        LotesSeleccionados = Fila.Cells("lote").Value
                    Else
                        LotesSeleccionados &= "," & Fila.Cells("lote").Value
                    End If
                End If
            Next

            If LotesSeleccionados <> String.Empty Then
                If cmbResolucionImpresora.SelectedIndex = 0 Then 'Resolucion 200dpi
                    dtInformacionEtiquetas = objBU.ImprimirEtiquetasSAY(LotesSeleccionados, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year)
                Else 'Resolucion de 300dpi
                    dtInformacionEtiquetas = objBU.ImprimirEtiquetasSAY300dpi(LotesSeleccionados, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year)
                End If


                If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                    System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
                End If

                PathArchivo = RutaArchivoEtiquetas ' Se determina el nombre del archivo con la fecha actual

                'verificamos si existe el archivo
                If File.Exists(PathArchivo) Then
                    File.Delete(PathArchivo)
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                    'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                Else
                    strStreamW = File.Create(PathArchivo) ' lo creamos
                End If

                strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                'Escribir la informacion de las etiquetas en el archivo
                For Each FILA As DataRow In dtInformacionEtiquetas.Rows
                    strStreamWriter.WriteLine(FILA.Item(0))
                Next

                strStreamWriter.Close()
                'Generar archivo bat para enviar a imprimir las etiquetas
                GenerarArchivoBat(LotesSeleccionados, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year)
                show_message("Exito", "Se ha enviado a imprimir.")
            Else
                show_message("Advertencia", "No se ha seleccionado un lote.")
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
        
    End Sub

    Private Sub GenerarArchivoBat(ByVal LotesSeleccionados As String, ByVal Nave As Integer, ByVal Año As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable


        Try
            Cursor = Cursors.WaitCursor
            dtArchivo = objBU.ComandosImprimirEtiquetasSAY(LotesSeleccionados, Nave, Año)

            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            'If System.IO.Directory.Exists("C:\PRN\") = False Then
            '    System.IO.Directory.CreateDirectory("C:\PRN\")
            'End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo) ' lo creamos
                'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
                'strStreamW = File.Open(PathArchivo, FileMode.Open) 'Abrimos el archivo
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura


            For Each FILA As DataRow In dtArchivo.Rows
                strStreamWriter.WriteLine(FILA.Item(0))
            Next



            ''Informacion del archivo bat
            'strStreamWriter.WriteLine("copy " & RutaArchivoEtiquetas & " C:\Users\SISTEMAS16\Desktop\Etiquetas2.txt")
            'strStreamWriter.WriteLine("exit")

            strStreamWriter.Close() ' cerrar

            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)

            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub

    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        For Each Fila As UltraGridRow In grdLotes.Rows
            Fila.Cells(" ").Value = chkSeleccionar.Checked
        Next
    End Sub

  

    
End Class