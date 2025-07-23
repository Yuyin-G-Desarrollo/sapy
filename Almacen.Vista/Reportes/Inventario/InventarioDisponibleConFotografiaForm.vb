Imports System.Net
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Programacion.Vista
Imports Tools
Imports Almacen.Negocios
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports Infragistics.Documents.Excel
Imports DevExpress.XtraPrinting

Public Class InventarioDisponibleConFotografiaForm

    Public ReporteAgente As Boolean = False
    Dim vFiltroFamilia As String = Nothing
    Dim vFiltroMarca As String = Nothing
    Dim vFiltroColeccion As String = Nothing
    Dim vFiltroArticulo As String = Nothing
    Dim verFotografia As Integer
    Dim verTalla As Integer
    Dim dtReporte As New DataTable
    Dim ruta As String = String.Empty
    Dim image As Image
    Dim StreamFoto As System.IO.Stream
    Dim objFTP As New Global.Tools.TransferenciaFTP
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"
    Dim permisoVertodo As Boolean = 0



    Private Sub InventarioDisponibleConFotografiaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TipoReporte As String = Me.Text

        Me.WindowState = FormWindowState.Maximized
        ''If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("INVENTARIO_DISPONIBLE_CON_FOTOGRAFIA", "Agente2") Then
        If TipoReporte = "AGENTE" Then

            cboAtiguedad.Items.Insert(0, "Todos")
            cboAtiguedad.SelectedIndex = 0

            chkBloqueado.Enabled = False
            permisoVertodo = 0
        Else
            cboAtiguedad.Items.Add("Todos")
            cboAtiguedad.Items.Add("A 6 Meses")
            cboAtiguedad.Items.Add("A 1 Año")
            cboAtiguedad.Items.Add("Mas de 1 año")
            permisoVertodo = 1
        End If

        'cboAtiguedad.Items.Add("Todos")
        'cboAtiguedad.Items.Add("A 6 Meses")
        'cboAtiguedad.Items.Add("A 1 Año")
        'cboAtiguedad.Items.Add("Mas de 1 año")

        pnPBar.Left = (Me.Width - pnPBar.Width) / 2
        pnPBar.Top = (Me.Height - pnPBar.Height) / 2



    End Sub

    Private Sub btnAgregarFamilia_Click(sender As Object, e As EventArgs) Handles btnAgregarFamilia.Click
        llenarGridFiltro(grdFamilia, "Familia", 14)
    End Sub

    Private Sub btnAgregarMarca_Click(sender As Object, e As EventArgs) Handles btnAgregarMarca.Click
        llenarGridFiltro(grdMarca, "Marca", 1)
    End Sub

    Private Sub btnAgregarColecciones_Click(sender As Object, e As EventArgs) Handles btnAgregarColecciones.Click
        llenarGridFiltro(grdColeccion, "Colección", 2)
    End Sub

    Private Sub btnAgregarArticulo_Click(sender As Object, e As EventArgs) Handles btnAgregarArticulo.Click
        llenarGridFiltro(grdArticulo, "Articulo", 15)
    End Sub

    Private Sub llenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltradoForm
        listado.tipo_busqueda = pTipoBusqueda


        Dim listaParametroID As New List(Of String)
        For Each row As UltraGridRow In pGrid.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        pGrid.DataSource = listado.listParametros

        With pGrid
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        End With
    End Sub

    Private Sub grid_diseño(grid As UltraGrid)
        With grid.DisplayLayout
            .Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .Override.RowSelectorWidth = 15
            .Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .Override.CellClickAction = CellClickAction.RowSelect
            .Override.AllowAddNew = AllowAddNew.No
        End With

        For Each row In grid.Rows
            row.Activation = Activation.NoEdit
        Next

    End Sub

    Private Sub grdMarca_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMarca.InitializeLayout
        grid_diseño(grdMarca)
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
    End Sub

    Private Sub grdArticulo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdArticulo.InitializeLayout
        grid_diseño(grdArticulo)
    End Sub

    Private Sub grdFamilia_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdFamilia.InitializeLayout
        grid_diseño(grdFamilia)
    End Sub

    Private Sub btnLimpiarFiltroFamilia_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroFamilia.Click
        grdFamilia.DataSource = Nothing
    End Sub

    Private Sub btnLimpiarFiltroMarca_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroMarca.Click
        grdMarca.DataSource = Nothing
    End Sub

    Private Sub btnLimpiarFiltroColecciones_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroColecciones.Click
        grdColeccion.DataSource = Nothing
    End Sub

    Private Sub btnLimpiarFiltroArticulo_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltroArticulo.Click
        grdArticulo.DataSource = Nothing
    End Sub

    Private Sub grdFamilia_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFamilia.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdFamilia.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMarca.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMarca.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub

    Private Sub grdArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdArticulo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdArticulo.DeleteSelectedRows(False)
    End Sub

    Private Sub panelArriba_Click(sender As Object, e As EventArgs) Handles panelArriba.Click
        pnlFiltros.Height = 35
    End Sub

    Private Sub panelAbajo_Click(sender As Object, e As EventArgs) Handles panelAbajo.Click
        pnlFiltros.Height = 243
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Dim obj As New InventarioBU
        Dim tipoAntiguedad As Integer = 0
        Dim vigentes As Integer = 0
        Dim descontinuados As Integer = 0
        Dim varTalla As Integer = 0
        Dim Disponible As Integer
        Dim Bloqueados As Integer

        Try
            Me.Cursor = Cursors.WaitCursor
            If cboAtiguedad.SelectedIndex = -1 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione un tipo antigüedad.")
                Exit Sub
            Else
                tipoAntiguedad = cboAtiguedad.SelectedIndex()
            End If

            If chkDisponible.Checked Then
                Disponible = 1
            Else
                Disponible = 0
            End If

            If chkBloqueado.Checked Then
                Bloqueados = 1
            Else
                Bloqueados = 0
            End If

            If Disponible = 0 And Bloqueados = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione al menos un tipo de estado.")
                Exit Sub
            End If

            If chkVigentes.Checked Then
                vigentes = 1
            Else
                vigentes = 0
            End If

            If chkDescontinuados.Checked Then
                descontinuados = 1
            Else
                descontinuados = 0
            End If

            If chkVerTalla.Checked Then
                verTalla = 1
            Else
                verTalla = 0
            End If

            If descontinuados = 0 And vigentes = 0 Then
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "Seleccione al menos un estatus.")
                Exit Sub
            End If

            If (tipoAntiguedad = 0 And descontinuados = 1 And vigentes = 1 And Disponible = 1 And Bloqueados = 1) Or
                (Disponible = 1 And Bloqueados = 1) Then

                Dim confirmarDialog As New ConfirmarForm
                Dim resultadoDialog As New DialogResult
                confirmarDialog.mensaje = "La consulta podrá tardar" & vbCrLf & "¿Desea continuar?"
                resultadoDialog = confirmarDialog.ShowDialog
                If resultadoDialog = DialogResult.OK Then
                    Console.WriteLine("Ejecutar")
                Else
                    Exit Sub
                End If
            End If

            obtenerFiltros()

            grdConsulta.DataSource = Nothing
            grdVWConsulta.Columns.Clear()

            pnPBar.Visible = True
            lblInfo.Text = "Ejecutando consulta...."
            pBar.Minimum = 0
            pBar.ForeColor = Color.Blue
            System.Windows.Forms.Application.DoEvents()

            If permisoVertodo = 0 Then
                dtReporte = obj.InventarioDisponibleAG(tipoAntiguedad, vigentes, descontinuados, verTalla, vFiltroFamilia, vFiltroMarca, vFiltroColeccion, vFiltroArticulo, Disponible, Bloqueados)
            Else
                dtReporte = obj.InventarioDisponible(tipoAntiguedad, vigentes, descontinuados, verTalla, vFiltroFamilia, vFiltroMarca, vFiltroColeccion, vFiltroArticulo, Disponible, Bloqueados)
            End If





            If dtReporte.Rows.Count > 0 Then
                dtReporte.Columns.Add("Foto", GetType(Image))
                Dim Total As Integer = dtReporte.Rows.Count
                Dim Cont As Integer = 0

                pBar.Maximum = Total

                If chkVerFotografia.Checked Then
                    lblInfo.Text = "Descargando imágenes...."
                Else
                    lblInfo.Text = "Espere un momento por favor..."
                End If


                System.Windows.Forms.Application.DoEvents()
                Dim imagen As Image
                For Each row As DataRow In dtReporte.Rows
                    ruta = IIf(IsDBNull(row.Item("FotoModelo")), "", row.Item("FotoModelo").ToString.Trim)
                    If ruta.Length > 0 Then
                        Try
                            image = Nothing
                            'StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                            StreamFoto = objFTP.StreamFile(Carpeta, ruta)
                            imagen = Bitmap.FromStream(StreamFoto)

                            If imagen.Width > 2000 Then
                                image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.2, imagen.Height * 0.2))
                                row.Item("Foto") = image
                            Else
                                image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.4, imagen.Height * 0.4))
                                row.Item("Foto") = image
                            End If

                            'image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.5, imagen.Height * 0.5))
                            'row.Item("Foto") = image


                            ' image = System.Drawing.Image.FromStream(StreamFoto)

                            'imagen = Tools.TransferenciaFTP.RedimensionarImagen(imagen, 70, 70)
                            'row.Item("Foto") = image



                        Catch ex As Exception
                            Try
                                'StreamFoto = objFTP.StreamFileThumbNail(Carpeta, ruta)
                                'image = System.Drawing.Image.FromStream(StreamFoto)
                                'row.Item("Foto") = image
                                'image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.5, imagen.Height * 0.5))
                                'row.Item("Foto") = image

                                image = Nothing
                                StreamFoto = objFTP.StreamFile(Carpeta, ruta)
                                imagen = Bitmap.FromStream(StreamFoto)

                                If imagen.Width > 2000 Then
                                    image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.3, imagen.Height * 0.3))
                                    row.Item("Foto") = image
                                Else
                                    image = Image.FromStream(Tools.TransferenciaFTP.RedimensionarImagen(imagen, imagen.Width * 0.5, imagen.Height * 0.5))
                                    row.Item("Foto") = image
                                End If

                            Catch exe As Exception

                            End Try
                        End Try
                    Else
                        row.Item("Foto") = Nothing
                    End If
                    Cont += 1
                    pBar.Value = Cont
                Next
                System.Windows.Forms.Application.DoEvents()
                grdConsulta.DataSource = dtReporte
                disenioGrig()
                panelArriba_Click(Nothing, Nothing)
                System.Windows.Forms.Application.DoEvents()
                lblTotalRegistros.Text = grdVWConsulta.DataRowCount.ToString("n0")

        Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros en la consulta.")
                lblTotalRegistros.Text = "0"
        End If

        lblActualizacion.Text = Date.Now

        Catch ex As Exception
        Utilerias.show_message(Utilerias.TipoMensaje.Errores, "Error " & ex.Message)
        Finally
        Me.Cursor = Cursors.Default
        pBar.Value = pBar.Minimum
        pnPBar.Visible = False
        request = Nothing
        StreamFoto = Nothing
        image = Nothing
        End Try

    End Sub

    Private Sub obtenerFiltros()
        vFiltroFamilia = Filtros(grdFamilia)
        vFiltroMarca = Filtros(grdMarca)
        vFiltroColeccion = Filtros(grdColeccion)
        vFiltroArticulo = Filtros(grdArticulo)
    End Sub

    Private Function Filtros(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim vDatosFiltrados As String = Nothing
        For Each Row As UltraGridRow In grid.Rows
            If vDatosFiltrados <> Nothing Then
                vDatosFiltrados += ","
            End If
            vDatosFiltrados += Row.Cells("Parametro").Value.ToString()
        Next
        Return vDatosFiltrados
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub disenioGrig()
        Dim Contador As Int16 = 0
        Dim Foto As Int16 = dtReporte.Columns.IndexOf("Foto")
        Dim value As Object = 1
        grdVWConsulta.Columns.Clear()

        grdVWConsulta.IndicatorWidth = 40
        grdVWConsulta.BestFitColumns()

        For Each Columna As DataColumn In dtReporte.Columns
            If Contador = 0 Then
                grdVWConsulta.Columns.AddField((Columna.ColumnName).ToString())
                grdVWConsulta.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                grdVWConsulta.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
            End If
            Contador += 1
        Next
        Contador = 0
        For Each Columna As DataColumn In dtReporte.Columns
            If Contador = Foto Then
                grdVWConsulta.Columns.AddField((Columna.ColumnName).ToString())
                grdVWConsulta.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                grdVWConsulta.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
            End If
            Contador += 1
        Next
        Contador = 0
        For Each Columna As DataColumn In dtReporte.Columns
            If (TypeOf value Is Integer) Then
                Select Case value
                    Case 1
                        'If Contador = 1 Then
                        '    grdVWConsulta.Columns.AddField((Columna.ColumnName).ToString())
                        '    grdVWConsulta.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True 'False
                        '    grdVWConsulta.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                        'ElseIf Contador > 1 And Contador <> Foto Then
                        '    grdVWConsulta.Columns.AddField((Columna.ColumnName).ToString())
                        '    grdVWConsulta.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                        '    grdVWConsulta.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                        'End If
                        If Contador > 0 And Contador <> Foto Then
                            grdVWConsulta.Columns.AddField((Columna.ColumnName).ToString())
                            grdVWConsulta.Columns.ColumnByFieldName((Columna.ColumnName).ToString()).Visible = True
                            grdVWConsulta.Columns.ColumnByFieldName(Columna.ColumnName).Caption = Columna.ColumnName.ToString()
                        End If

                        Contador += 1
                End Select
            End If
        Next

        If permisoVertodo = 0 Then
            grdVWConsulta.Columns("Antiguedad").Visible = False
            grdVWConsulta.Columns("Bloqueado").Visible = False
        End If

        grdVWConsulta.Columns("FotoModelo").Visible = False

        grdVWConsulta.Columns("Pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

        grdVWConsulta.Columns("Pares").DisplayFormat.FormatString = "{0:N0}"
        'grdVWConsulta.Columns("Temporada").Width = 200
        'grdVWConsulta.Columns("Marca").Width = 100
        'grdVWConsulta.Columns("Familia").Width = 150
        'grdVWConsulta.Columns("Coleccion").Width = 200
        'grdVWConsulta.Columns("ModeloSAY").Width = 100
        'grdVWConsulta.Columns("ModeloSICY").Width = 100
        'grdVWConsulta.Columns("Piel").Width = 150
        'grdVWConsulta.Columns("Color").Width = 120
        'grdVWConsulta.Columns("Corrida").Width = 100
        'grdVWConsulta.Columns("Estatus").Width = 100
        'grdVWConsulta.Columns("Antiguedad").Width = 100

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWConsulta.Columns
            If col.FieldName = "Foto" Then
                col.Caption = "FOTO"
            End If
            If col.FieldName = "Temporada" Then
                col.Width = 200
                col.Caption = "TEMPORADA"
            End If
            If col.FieldName = "Marca" Then
                col.Width = 100
                col.Caption = "MARCA"
            End If
            If col.FieldName = "Familia" Then
                col.Width = 150
                col.Caption = "FAMILIA"
            End If
            If col.FieldName = "Coleccion" Then
                col.Width = 200
                col.Caption = "COLECCIÓN"
            End If
            If col.FieldName = "ModeloSAY" Then
                col.Width = 100
                col.Caption = "MODELO SAY"
            End If
            If col.FieldName = "ModeloSICY" Then
                col.Width = 100
                col.Caption = "MODELO SICY"
            End If
            If col.FieldName = "Piel" Then
                col.Width = 150
                col.Caption = "PIEL"
            End If
            If col.FieldName = "Color" Then
                col.Width = 120
                col.Caption = "COLOR"
            End If
            If col.FieldName = "Corrida" Then
                col.Width = 100
                col.Caption = "CORRIDA"
            End If
            If col.FieldName = "Estatus" Then
                col.Width = 100
                col.Caption = "ESTATUS"
            End If
            If col.FieldName = "Antiguedad" Then
                col.Width = 100
                col.Caption = "ANTIGÜEDAD"
            End If
            If col.FieldName = "Pares" Then
                col.Width = 80
                col.Caption = "PARES"
            End If
            If col.FieldName = "Bloqueado" Then
                col.Width = 80
                col.Caption = "BLOQUEADO"
            End If
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        Next

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWConsulta.Columns
            col.OptionsColumn.AllowEdit = False
            If col.FieldName <> "Foto" And
               col.FieldName <> "Temporada" And
               col.FieldName <> "Marca" And
               col.FieldName <> "Familia" And
               col.FieldName <> "Coleccion" And
               col.FieldName <> "ModeloSAY" And
               col.FieldName <> "ModeloSICY" And
               col.FieldName <> "Piel" And
               col.FieldName <> "Color" And
               col.FieldName <> "Corrida" And
               col.FieldName <> "Estatus" And
               col.FieldName <> "Antiguedad" And
               col.FieldName <> "Bloqueado" And
               col.FieldName <> "Pares" Then

                col.Width = 40

            End If
        Next

        'grdVWConsulta.Columns("Foto").Caption = "FOTO"
        'grdVWConsulta.Columns("Temporada").Caption = "TEMPORADA"
        'grdVWConsulta.Columns("Marca").Caption = "MARCA"
        'grdVWConsulta.Columns("Familia").Caption = "FAMILIA"
        'grdVWConsulta.Columns("Coleccion").Caption = "COLECCIÓN"
        'grdVWConsulta.Columns("ModeloSAY").Caption = "MODELO SAY"
        'grdVWConsulta.Columns("ModeloSICY").Caption = "MODELO SICY"
        'grdVWConsulta.Columns("Piel").Caption = "PIEL"
        'grdVWConsulta.Columns("Color").Caption = "COLOR"
        'grdVWConsulta.Columns("Corrida").Caption = "CORRIDA"
        'grdVWConsulta.Columns("Estatus").Caption = "ESTATUS"
        'grdVWConsulta.Columns("Antiguedad").Caption = "ANTIGÜEDAD"
        'grdVWConsulta.Columns("Pares").Caption = "PARES"

        If chkVerFotografia.Checked = False Then
            grdVWConsulta.Columns("Foto").Visible = False
            grdVWConsulta.ColumnPanelRowHeight = 10
            grdVWConsulta.RowHeight = 10
        Else
            grdVWConsulta.Columns("Foto").Visible = True
            grdVWConsulta.ColumnPanelRowHeight = 30
            grdVWConsulta.RowHeight = 50
        End If

        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grdVWConsulta)
        Tools.DiseñoGrid.AlternarColorEnFilasTenue(grdVWConsulta)

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWConsulta.Columns
            col.Summary.Remove(col.SummaryItem)
            If col.FieldName.Contains("#") Or col.FieldName.Contains("Pares") Then
                col.Summary.Add(DevExpress.Data.SummaryItemType.Sum, col.FieldName, "{0:N0}")
            End If
        Next


        grdVWConsulta.OptionsView.ColumnAutoWidth = False

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If grdVWConsulta.DataRowCount > 0 Then
                grdVWConsulta.Columns("Foto").Visible = False
                For Each col As DevExpress.XtraGrid.Columns.GridColumn In grdVWConsulta.Columns
                    col.AppearanceHeader.BackColor = Color.LightSkyBlue
                Next
                Tools.Excel.ExportarExcel(grdVWConsulta, "Reporte de Inventario")
            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportarExcelFoto_Click(sender As Object, e As EventArgs) Handles btnExportarExcelFoto.Click
        If grdVWConsulta.DataRowCount > 0 Then
            Dim sfd As New SaveFileDialog
            sfd.DefaultExt = "xls"
            sfd.Filter = "Excel Files|*.xls;*.xlsx" ';*.xlsm"

            Dim result As DialogResult = sfd.ShowDialog()
            Dim fileName As String = sfd.FileName

            Me.Cursor = Cursors.WaitCursor

            If result = Windows.Forms.DialogResult.OK Then

                pnPBar.Visible = True
                lblInfo.Text = "Ejecutando consulta...."
                pBar.Minimum = 0
                pBar.ForeColor = Color.Blue
                System.Windows.Forms.Application.DoEvents()

                Try
                    Dim workbook As New Infragistics.Documents.Excel.Workbook
                    Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Lista")

                    Dim Total As Integer = dtReporte.Rows.Count
                    Dim Cont As Integer = 0

                    pBar.Maximum = Total
                    lblInfo.Text = "Espere por favor..."
                    System.Windows.Forms.Application.DoEvents()

                    If grdVWConsulta.Columns.Count <= 15 Then
                        worksheet.Columns.Item(0).Width = 1825  'FotoModelo
                        worksheet.Columns.Item(1).Width = 3650  'Foto
                        worksheet.Columns.Item(2).Width = 9125  'Temporada
                        worksheet.Columns.Item(3).Width = 5475  'Marca
                        worksheet.Columns.Item(4).Width = 9125  'Familia
                        worksheet.Columns.Item(5).Width = 5840  'Coleccion
                        worksheet.Columns.Item(6).Width = 5000  'ModeloSAY
                        worksheet.Columns.Item(7).Width = 5000  'ModeloSICY
                        worksheet.Columns.Item(8).Width = 5475  'Peil
                        worksheet.Columns.Item(9).Width = 5475  'Color
                        worksheet.Columns.Item(10).Width = 2190 'Corrida
                        worksheet.Columns.Item(11).Width = 5475 'Estatus
                        If permisoVertodo Then
                            worksheet.Columns.Item(12).Width = 3000 'Antiguedad
                            worksheet.Columns.Item(13).Width = 5475 'Bloqueado
                        End If
                        'worksheet.Columns.Item(12).Width = 3000 'Antiguedad
                        'worksheet.Columns.Item(13).Width = 5475 'Bloqueado
                        worksheet.Columns.Item(14).Width = 2190 'Pares


                        Dim inicio As Integer = 2

                        worksheet.Rows.Item(inicio).Cells.Item(0).Value = grdVWConsulta.Columns(0).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(1).Value = grdVWConsulta.Columns(1).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(2).Value = grdVWConsulta.Columns(2).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(3).Value = grdVWConsulta.Columns(3).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(4).Value = grdVWConsulta.Columns(4).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(5).Value = grdVWConsulta.Columns(5).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(6).Value = grdVWConsulta.Columns(6).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(7).Value = grdVWConsulta.Columns(7).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(8).Value = grdVWConsulta.Columns(8).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(9).Value = grdVWConsulta.Columns(9).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(10).Value = grdVWConsulta.Columns(10).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(11).Value = grdVWConsulta.Columns(11).FieldName.ToString()
                        If permisoVertodo Then
                            worksheet.Rows.Item(inicio).Cells.Item(12).Value = grdVWConsulta.Columns(12).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(13).Value = grdVWConsulta.Columns(13).FieldName.ToString()
                        End If
                        'worksheet.Rows.Item(inicio).Cells.Item(12).Value = grdVWConsulta.Columns(12).FieldName.ToString()
                        'worksheet.Rows.Item(inicio).Cells.Item(13).Value = grdVWConsulta.Columns(13).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(14).Value = grdVWConsulta.Columns(14).FieldName.ToString()



                        For i As Int16 = inicio To inicio Step 1
                            For j As Int16 = 0 To 14 Step 1  '13
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSkyBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next

                        For r As Integer = (0) To grdVWConsulta.RowCount - 1 'grdCatalogo.Rows.Count - 1
                            worksheet.Rows.Item(r + inicio + 1).Height = 1505 '1145

                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(0).FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(2).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(3).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(4).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(5).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(6).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(7).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(8).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(9).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(10).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(11).FieldName.ToString())
                            If permisoVertodo Then
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(12).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(13).FieldName.ToString())
                            End If
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(12).FieldName.ToString())
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(13).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(14).FieldName.ToString())

                            If Not IsDBNull(grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(1).FieldName.ToString())) Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then
                                Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(1).FieldName.ToString()))

                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                Else
                                    Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                End If

                                ' The top-left corner of the image should be at the 
                                ' top-left corner of cell A1
                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                ' The bottom-right corner of the image should be at 
                                ' the bottom-right corner of cell A1
                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                worksheet.Shapes.Add(imageShape)

                            End If
                            Cont += 1
                            pBar.Value = Cont
                        Next

                        For i As Int16 = 0 To grdVWConsulta.RowCount - 1 Step 1
                            For j As Int16 = 0 To 14 Step 1 '13

                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next

                        'For r As Integer = (0) To grdVWConsulta.RowCount - 1
                        '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                        'Next

                        worksheet.Columns.Item(0).Hidden = True


                    Else
                        'MsgBox("Para las tallas")

                        worksheet.Columns.Item(0).Width = 1825  'FotoModelo
                        worksheet.Columns.Item(1).Width = 3650  'Foto
                        worksheet.Columns.Item(2).Width = 9125  'Temporada
                        worksheet.Columns.Item(3).Width = 5475  'Marca
                        worksheet.Columns.Item(4).Width = 9125  'Familia
                        worksheet.Columns.Item(5).Width = 5840  'Coleccion
                        worksheet.Columns.Item(6).Width = 5000  'ModeloSAY
                        worksheet.Columns.Item(7).Width = 5000  'ModeloSICY
                        worksheet.Columns.Item(8).Width = 5475  'Peil
                        worksheet.Columns.Item(9).Width = 5475  'Color
                        worksheet.Columns.Item(10).Width = 2190 'Corrida
                        worksheet.Columns.Item(11).Width = 5475 'Estatus
                        If permisoVertodo Then
                            worksheet.Columns.Item(12).Width = 3000 'Antiguedad
                            worksheet.Columns.Item(13).Width = 5475 'Bloqueado
                        End If
                        'worksheet.Columns.Item(12).Width = 3000 'Antiguedad
                        'worksheet.Columns.Item(13).Width = 5475 'Bloqueado
                        worksheet.Columns.Item(14).Width = 2190 'Pares

                        For i As Int16 = 15 To 60
                            worksheet.Columns.Item(i).Width = 1500 ' Tallas
                        Next

                        Dim inicio As Integer = 2

                        worksheet.Rows.Item(inicio).Cells.Item(0).Value = grdVWConsulta.Columns(0).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(1).Value = grdVWConsulta.Columns(1).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(2).Value = grdVWConsulta.Columns(2).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(3).Value = grdVWConsulta.Columns(3).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(4).Value = grdVWConsulta.Columns(4).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(5).Value = grdVWConsulta.Columns(5).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(6).Value = grdVWConsulta.Columns(6).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(7).Value = grdVWConsulta.Columns(7).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(8).Value = grdVWConsulta.Columns(8).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(9).Value = grdVWConsulta.Columns(9).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(10).Value = grdVWConsulta.Columns(10).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(11).Value = grdVWConsulta.Columns(11).FieldName.ToString()
                        If permisoVertodo Then
                            worksheet.Rows.Item(inicio).Cells.Item(12).Value = grdVWConsulta.Columns(12).FieldName.ToString()
                            worksheet.Rows.Item(inicio).Cells.Item(13).Value = grdVWConsulta.Columns(13).FieldName.ToString()
                        End If
                        'worksheet.Rows.Item(inicio).Cells.Item(12).Value = grdVWConsulta.Columns(12).FieldName.ToString()
                        'worksheet.Rows.Item(inicio).Cells.Item(13).Value = grdVWConsulta.Columns(13).FieldName.ToString()
                        worksheet.Rows.Item(inicio).Cells.Item(14).Value = grdVWConsulta.Columns(14).FieldName.ToString()

                        For i As Int16 = 15 To 60
                            worksheet.Rows.Item(inicio).Cells.Item(i).Value = grdVWConsulta.Columns(i).FieldName.ToString()
                        Next

                        For i As Int16 = inicio To inicio Step 1
                            For j As Int16 = 0 To grdVWConsulta.Columns.Count Step 1  '13
                                worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightSkyBlue), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                            Next
                        Next

                        For r As Integer = (0) To grdVWConsulta.RowCount - 1 'grdCatalogo.Rows.Count - 1
                            worksheet.Rows.Item(r + inicio + 1).Height = 1505 '1145

                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(0).FieldName.ToString()) 'grdCatalogo.Rows(r).Cells(c).Value
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(2).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(3).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(3).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(4).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(4).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(5).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(5).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(6).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(6).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(7).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(7).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(8).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(8).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(9).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(9).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(10).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(10).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(11).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(11).FieldName.ToString())
                            If permisoVertodo Then
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(12).FieldName.ToString())
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(13).FieldName.ToString())
                            End If
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(12).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(12).FieldName.ToString())
                            'worksheet.Rows.Item(r + inicio + 1).Cells.Item(13).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(13).FieldName.ToString())
                            worksheet.Rows.Item(r + inicio + 1).Cells.Item(14).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(14).FieldName.ToString())

                            For i As Int16 = 15 To 60
                                worksheet.Rows.Item(r + inicio + 1).Cells.Item(i).Value = grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(i).FieldName.ToString())
                            Next


                            If Not IsDBNull(grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(1).FieldName.ToString())) Then 'And Not bgvReporte.GetRowCellValue(r, bgvReporte.Columns(13).FieldName.ToString()) = "" Then
                                Dim imageShape As Infragistics.Documents.Excel.WorksheetImage =
                            New Infragistics.Documents.Excel.WorksheetImage(grdVWConsulta.GetRowCellValue(r, grdVWConsulta.Columns(1).FieldName.ToString()))

                                Dim Ancho As Double = imageShape.Image.Width
                                Dim alto As Double = imageShape.Image.Height

                                If imageShape.Image.Width > imageShape.Image.Height Then
                                    alto = (imageShape.Image.Height) * 100 / (imageShape.Image.Width)
                                Else
                                    Ancho = (imageShape.Image.Width) * 100 / (imageShape.Image.Height)
                                End If

                                ' The top-left corner of the image should be at the 
                                ' top-left corner of cell A1
                                imageShape.TopLeftCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                                imageShape.TopLeftCornerPosition = New PointF(0.0F, 0.0F)

                                ' The bottom-right corner of the image should be at 
                                ' the bottom-right corner of cell A1
                                imageShape.BottomRightCornerCell = worksheet.Rows.Item(r + inicio + 1).Cells.Item(1)
                                imageShape.BottomRightCornerPosition = New PointF(Ancho, alto)

                                imageShape.PositioningMode = ShapePositioningMode.MoveAndSizeWithCells

                                worksheet.Shapes.Add(imageShape)
                            End If
                            Cont += 1
                            pBar.Value = Cont
                            lblInfo.Text = "Exportando datos..." & Cont.ToString()
                            System.Windows.Forms.Application.DoEvents()

                        Next

                        lblInfo.Text = "Espere por favor..."
                        System.Windows.Forms.Application.DoEvents()

                        For i As Int16 = 0 To grdVWConsulta.RowCount - 1 Step 1
                            For j As Int16 = 0 To grdVWConsulta.Columns.Count Step 1 '13

                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                                worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                            Next

                            'lblInfo.Text = "Exportando datos..." & i.ToString()
                            'System.Windows.Forms.Application.DoEvents()
                        Next

                        'For r As Integer = (0) To grdVWConsulta.RowCount - 1
                        '    worksheet.Rows.Item(r + inicio + 1).Height = 1145
                        'Next

                        worksheet.Columns.Item(0).Hidden = True


                    End If
                    System.Windows.Forms.Application.DoEvents()


                    workbook.Save(fileName)

                    Dim objMensajeExito As New ExitoForm
                    objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.mensaje = "Los dastos se exportaron correctamente en la ubicacion " + fileName + "."
                    objMensajeExito.ShowDialog()
                    Process.Start(fileName)

                Catch ex As Exception
                    Dim objMensajeError As New ErroresForm
                    objMensajeError.StartPosition = FormStartPosition.CenterScreen
                    objMensajeError.mensaje = ex.Message
                    objMensajeError.ShowDialog()
                Finally
                    pBar.Value = pBar.Minimum
                    pnPBar.Visible = False
                    Me.Cursor = Cursors.Default
                End Try
            End If

        Else
            Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        End If

#Region "Otra forma de exportar a Excel"
        '--------------------------------------------------------------------------------------------------------------------------
        '-------------------------- OTRA FORMA DE EXPORTAR                            ---------------------------------------------
        '--------------------------------------------------------------------------------------------------------------------------

        'If grdVWConsulta.DataRowCount > 0 Then

        '    Dim fbdUbicacionArchivo As New FolderBrowserDialog
        '    Dim nombreReporte As String = String.Empty
        '    Dim nombreReporteParaExportacion As String = String.Empty
        '    Dim exportOptions = New XlsxExportOptionsEx()

        '    grdVWConsulta.Columns("FotoModelo").Visible = False
        '    grdVWConsulta.Columns("Temporada").Width = 200
        '    grdVWConsulta.Columns("Marca").Width = 100
        '    grdVWConsulta.Columns("Familia").Width = 150
        '    grdVWConsulta.Columns("Coleccion").Width = 200
        '    grdVWConsulta.Columns("ModeloSAY").Width = 100
        '    grdVWConsulta.Columns("ModeloSICY").Width = 100
        '    grdVWConsulta.Columns("Piel").Width = 150
        '    grdVWConsulta.Columns("Color").Width = 120
        '    grdVWConsulta.Columns("Corrida").Width = 100
        '    grdVWConsulta.Columns("Estatus").Width = 100
        '    grdVWConsulta.Columns("Antiguedad").Width = 100
        '    grdVWConsulta.Columns("Pares").Width = 40

        '    exportOptions.ExportType = DevExpress.Export.ExportType.WYSIWYG
        '    nombreReporte = "Reporte de Inventario con Fotografia"

        '    Try

        '        With fbdUbicacionArchivo

        '            .Reset()
        '            .Description = " Seleccione una carpeta "
        '            .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        '            .ShowNewFolderButton = True

        '            Dim ret As DialogResult = .ShowDialog
        '            Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString


        '            If ret = Windows.Forms.DialogResult.OK Then

        '                If grdVWConsulta.GroupCount > 0 Then
        '                    grdVWConsulta.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
        '                Else

        '                    grdVWConsulta.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)

        '                End If

        '                Utilerias.show_message(Utilerias.TipoMensaje.Exito, "Los dastos se exportaron correctamente.")

        '                .Dispose()
        '                Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
        '            End If
        '        End With

        '    Catch ex As Exception
        '        MsgBox("Error", ex.Message.ToString())
        '    End Try
        'Else
        '    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "No se encontraron registros a exportar.")
        'End If
#End Region
    End Sub

    Private Sub grdVWConsulta_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles grdVWConsulta.CustomDrawRowIndicator
        If (e.RowHandle >= 0) Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub grdVWConsulta_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles grdVWConsulta.RowCellClick
        If e.Clicks = 1 Then
            If e.Column.FieldName = "Foto" Then
                Dim MostrarFoto As New Programacion.Vista.FotoModeloForm
                MostrarFoto.NombreFoto = grdVWConsulta.GetRowCellValue(e.RowHandle, "FotoModelo")
                MostrarFoto.Marca = grdVWConsulta.GetRowCellValue(e.RowHandle, "Marca")
                MostrarFoto.Coleccion = grdVWConsulta.GetRowCellValue(e.RowHandle, "Coleccion")
                MostrarFoto.ModeloSicy = grdVWConsulta.GetRowCellValue(e.RowHandle, "ModeloSAY")
                'MostrarFoto.ModleoSay = bgvReporte.GetRowCellValue(e.RowHandle, "ModeloSay")
                'MostrarFoto.Talla = bgvReporte.GetRowCellValue(e.RowHandle, "Corrida")
                MostrarFoto.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        Try
            Dim objFTP As New Tools.TransferenciaFTP
            objFTP.DescargarArchivo("/ManualesUsuario/Ventas/", "Descargas\Manuales\Ventas", "COVE_MAUS_Reporte_de_Inventario_con_Fotografia_v1.pdf")
            Process.Start("Descargas\Manuales\Ventas\COVE_MAUS_Reporte_de_Inventario_con_Fotografia_v1.pdf")
        Catch ex As Exception

        End Try
    End Sub
End Class