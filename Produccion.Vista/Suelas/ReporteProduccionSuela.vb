Imports DevExpress.XtraGrid.Views.Grid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ReporteProduccionSuela
    Dim vFiltroNave As String
    Private Sub ReporteProduccionSuela_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub btnLimNave_Click(sender As Object, e As EventArgs) Handles btnLimNave.Click
        grdNave.DataSource = Nothing
    End Sub

    Private Sub btnAgregarNave_Click(sender As Object, e As EventArgs) Handles btnAgregarNave.Click
        LlenarGridFiltro(grdNave, "Nave", 12)
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdReporte.DataSource = Nothing
        vwReporte.Columns.Clear()
        lblParesResultado.Text = "0"
        lblLotesResultado.Text = "0"
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor
        Dim vReporte As String = cmbReporte.Text
        Select Case vReporte
            Case "PRODUCCION DE SUELA"
                ImprimirProduccionSuela()
            Case "CONCENTRADO DE SUELA"
                ImprimirConcentradoSuela()
            Case "DESGLOSADO DE SUELA"
                ImprimirDesglosadoSuela()
            Case ""
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Selecciona un reporte"
                mensajeAdvertencia.ShowDialog()
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ImprimirConcentradoSuela()
        Dim vFecha As String = dtpPrograma.Value.ToShortDateString
        Dim obj As New ReportesSuelaBU
        Dim vResultado As New DataTable
        Dim vReporte As String = cmbReporte.Text
        Dim vIdUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim tabla1 As New DataTable

        tabla1 = obj.ObtieneConcentradoSuela(vFecha, vFiltroNave, vIdUsuario)
        tabla1.TableName = "dtConcentradoSuela"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")

        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else

                    ' Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("CONCENTRADO_PRODUCCION_SUELA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = "" 'GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma()
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA SUELA"
                    reporte("TituloCelda") = "SUELA"
                    reporte.RegData(tabla1)
                    reporte.Show()

                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub
    Private Sub ImprimirProduccionSuela()
        Dim vFecha As String = dtpPrograma.Value.ToShortDateString
        Dim obj As New ReportesSuelaBU
        Dim vResultado As New DataTable
        Dim vReporte As String = cmbReporte.Text
        Dim vIdUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim tabla1 As New DataTable

        tabla1 = obj.ObtieneProduccionSuela(vFecha, vFiltroNave, vIdUsuario)
        tabla1.TableName = "dtProduccionSuela"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")

        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else

                    ' Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("PRODUCCION_SUELA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = "" 'GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma()
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA SUELA"
                    reporte("TituloCelda") = "SUELA"
                    reporte.RegData(tabla1)
                    reporte.Show()

                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub
    Private Sub ImprimirDesglosadoSuela()
        Dim vFecha As String = dtpPrograma.Value.ToShortDateString
        Dim obj As New ReportesSuelaBU
        Dim vResultado As New DataTable
        Dim vReporte As String = cmbReporte.Text
        Dim vIdUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        Dim tabla1 As New DataTable

        tabla1 = obj.ObtieneDesglosadoSuela(vFecha, vFiltroNave, vIdUsuario)
        tabla1.TableName = "dtConcentradoSuela"

        If tabla1.Rows.Count = 0 Then
            Tools.MostrarMensaje(Tools.Mensajes.Warning, "No hay información para generar el reporte.")

        Else
            Try
                If tabla1.Rows.Count = 0 Then
                Else

                    ' Me.Cursor = Cursors.WaitCursor
                    Dim OBJReporte As New Framework.Negocios.ReportesBU
                    Dim EntidadReporte As Entidades.Reportes
                    EntidadReporte = OBJReporte.LeerReporteporClave("DESGLOSADO_PRODUCCION_SUELA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                        EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
                    Dim reporte As New StiReport

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte("log") = "" 'GetRutaLogoPorNave(nave)
                    reporte("fecha") = GetFormatoFechaPrograma()
                    reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("titulo") = "REPORTE PARA SUELA"
                    reporte("TituloCelda") = "SUELA"
                    reporte.RegData(tabla1)
                    reporte.Show()

                    'Me.Cursor = Cursors.Default
                End If
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltrado
        listado.tipo_busqueda = pTipoBusqueda
        listado.vIdNave = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

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

    Private Sub grdNave_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdNave.InitializeLayout
        grid_diseño(grdNave)
    End Sub

    Private Sub grdNave_KeyDown(sender As Object, e As KeyEventArgs) Handles grdNave.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdNave.DeleteSelectedRows(False)
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
        asignaFormato_Columna(grid)

    End Sub

    Public Sub asignaFormato_Columna(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid)

        For Each col In grid.DisplayLayout.Bands(0).Columns
            If col.DataType.Name.ToString.Equals("Int32") Or col.DataType.Name.ToString.Equals("Int16") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Integer
                col.CellAppearance.TextHAlign = HAlign.Right
                col.Format = "N0"
            End If
            If col.DataType.Name.ToString.Equals("Decimal") Then
                col.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DoublePositive
                col.CellAppearance.TextHAlign = HAlign.Right
            End If
            If col.DataType.Name.ToString.Equals("String") Then
                If col.Header.Caption.Equals("Télefono") Then
                    col.MaskInput = "+## (###) ###-####"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                ElseIf col.Header.Caption.Equals("Extensión") Then
                    col.MaskInput = "ext: 9999"
                    col.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
                    col.CellAppearance.TextHAlign = HAlign.Right
                Else
                    col.CellAppearance.TextHAlign = HAlign.Left
                End If
            End If
        Next
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

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

        vFiltroNave = Filtros(grdNave)
        Dim vFecha As String = dtpPrograma.Value.ToShortDateString
        Dim obj As New ReportesSuelaBU
        Dim vResultado As New DataTable
        Dim vReporte As String = cmbReporte.Text
        Dim vIdUsuario As Integer = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid

        grdReporte.DataSource = Nothing
        vwReporte.Columns.Clear()
        Me.Cursor = Cursors.WaitCursor

        Try

            If vReporte = "" Then
                Dim mensajeAdvertencia As New AdvertenciaForm
                mensajeAdvertencia.mensaje = "Selecciona un reporte"
                mensajeAdvertencia.ShowDialog()
            Else
                Select Case vReporte
                    Case "PRODUCCION DE SUELA"
                        vResultado = obj.ObtieneProduccionSuela(vFecha, vFiltroNave, vIdUsuario)
                    Case "CONCENTRADO DE SUELA"
                        vResultado = obj.ObtieneConcentradoSuela(vFecha, vFiltroNave, vIdUsuario)
                    Case "DESGLOSADO DE SUELA"
                        vResultado = obj.ObtieneDesglosadoSuela(vFecha, vFiltroNave, vIdUsuario)
                End Select
                If vResultado.Rows.Count > 0 Then
                    grdReporte.DataSource = vResultado
                    DiseñoGrid()

                    Dim vLotes = (From x In vResultado
                                  Select x.Item("Lote")).Distinct()

                    Dim vPares = (From a In vResultado.AsEnumerable()
                                  Select a.Field(Of Integer)("Pares")).Sum()

                    If vReporte = "CONCENTRADO DE SUELA" Then
                        lblLotesResultado.Text = (From a In vResultado.AsEnumerable()
                                                  Select a.Field(Of Integer)("Lotes")).Sum().ToString()
                    Else
                        lblLotesResultado.Text = vResultado.Rows.Count()
                    End If

                    lblParesResultado.Text = vPares.ToString("n0")
                    btnUp_Click(Nothing, Nothing)

                Else
                    Dim mensajeAdvertencia As New AdvertenciaForm
                    mensajeAdvertencia.mensaje = "No hay datos para mostrar"
                    mensajeAdvertencia.ShowDialog()
                End If
            End If
        Catch EX As Exception
            Dim mensajeAdvertencia As New ErroresForm
            mensajeAdvertencia.mensaje = EX.Message

            mensajeAdvertencia.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub DiseñoGrid()

        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            vColumna.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            vColumna.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            If vColumna.FieldName.Contains("Nave") = True Then
                vColumna.Width = 150

            ElseIf vColumna.FieldName.Contains("Pares") = True Then
                vColumna.Width = 100
                vColumna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            ElseIf vColumna.FieldName.Contains("Lotes") = True Then
                vColumna.Width = 100
                vColumna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            ElseIf vColumna.FieldName.Contains("Coleccion") = True Then
                vColumna.Width = 350
                vColumna.Caption = "Colección"

            ElseIf vColumna.FieldName.Contains("Corrida") = True Then
                vColumna.Width = 100
                vColumna.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            ElseIf vColumna.FieldName.Contains("Material") = True Then
                vColumna.Width = 350


            ElseIf vColumna.FieldName.Contains("UrlLogo") = True Then
                vColumna.Visible = False

                'Else
                '    vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                '    vColumna.DisplayFormat.FormatString = "##,##0.0"
            End If
        Next
    End Sub

    Private Sub vwReporte_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle
        If e.RowHandle >= 0 Then
            If (e.RowHandle Mod 2 > 0) Then
                e.Appearance.BackColor = Color.LightSteelBlue
            End If
        End If
    End Sub

    Private Sub vwReporte_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles vwReporte.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Function GetFormatoFechaPrograma() As String
        Dim dateValue As Date = dtpPrograma.Value.ToShortDateString
        Return CapitalizarCadena(dateValue.ToString("dddd, dd ")) & CapitalizarCadena(dateValue.ToString("MMMM")) & " de " & dateValue.ToString("yyyy")
    End Function

    Private Function CapitalizarCadena(ByVal cadena As String) As String
        Dim curCulture As Globalization.CultureInfo = Threading.Thread.CurrentThread.CurrentCulture
        Dim tInfo As Globalization.TextInfo = curCulture.TextInfo()
        Return tInfo.ToTitleCase(cadena)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        pnlParametros.Height = 180
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        pnlParametros.Height = 27
    End Sub
End Class