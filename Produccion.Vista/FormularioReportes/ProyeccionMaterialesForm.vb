Imports System.IO
Imports System.Net
Imports System.Threading
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Produccion.Negocios
Imports Stimulsoft.Report
Imports Tools

Public Class ProyeccionMaterialesForm

    Dim vFiltroProveedor As String = Nothing
    Dim vFiltroClasificacion As String = Nothing
    Dim vFiltroColeccion As String = Nothing
    Dim vFiltroModelo As String = Nothing
    Dim vFiltroPielColor As String = Nothing
    Dim vFiltroCorrida As String = Nothing
    Dim vFiltroFechaInicio As String = Nothing
    Dim vFiltroFechaFin As String = Nothing
    Dim vFiltroNave As Integer = 0
    Dim dtResultadoConsulta As New DataTable
    Dim vTipo As String = String.Empty
    Dim CriticosDias As Integer = 0
    Dim inyeva, distribuidora As Boolean
    Dim formatoPDF As Stimulsoft.Report.Export.StiPdfExportSettings

    Private Sub ProyeccionMaterialesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim numSemana As Integer
        If (Now.Year = 2021) Then
            numSemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
            numSemana -= 1
        Else
            numSemana = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)
        End If

        txtaño.Value = Date.Now.Year

        lblNoSemana.Text = numSemana.ToString()
        nudSemanaInicio.Value = DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Saturday, FirstWeekOfYear.Jan1)

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PPCP_INYEVA") Then
            inyeva = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PPCP_DISTRIBUIDORA") Then
            distribuidora = True
        End If
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "REPORTE_SEMANAL") Then
            chReporteSemanal.Visible = True
            grpReporte.Visible = True
        End If

        Me.Top = 0
        Me.Left = 0
        Me.WindowState = FormWindowState.Maximized
        chbSemana.Visible = False
        dtpFechaInicio.MinDate = "01/01/2018"
        'dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()

        cmbAgrupado.SelectedIndex = 0
        CargarNAves()

        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PPCP_LOTEADOS") Then

            chbColeccion.Visible = False
        Else

            chbColeccion.Visible = True
        End If



        If inyeva Or distribuidora Then
            If Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid <> 665 Then
                LlenarGridFiltro(grdProveedor, "Proveedor", 9)
                LlenarGridFiltro(grdMaterial, "Material", 8)
            End If
        End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PERMISO_CONIVA") Then
        '    MaterialesDirectosConIVA.Visible = True
        '    MaterialesSinteticosConIVA.Visible = True
        'Else
        '    MaterialesDirectosConIVA.Visible = False
        '    MaterialesSinteticosConIVA.Visible = False
        'End If

        'If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PERMISO_SINIVA") Then
        '    MaterialesDirectosSinIVA.Visible = True
        '    MaterialesSinteticosConIVA.Visible = True
        'Else
        '    MaterialesDirectosSinIVA.Visible = False
        '    MaterialesSinteticosConIVA.Visible = False
        'End If

    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        Cursor = Cursors.WaitCursor
        'Dim vTipo As String = cmbAgrupado.Text
        Dim obj As New ProyeccionMaterialBU
        Dim vSpid As Integer = 0
        vTipo = cmbAgrupado.Text
        dtResultadoConsulta.Clear()
        dtResultadoConsulta.Columns.Clear()
        obtenerFiltros()

        If chbCriDias.Checked Then
            CriticosDias = 1
        Else
            CriticosDias = 0
        End If

        Try
            If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PPCP_LOTEADOS") Then
                Select Case vTipo
                    Case "Por Programa"
                        dtResultadoConsulta = obj.ObtenerProyeccionMaterialProgramaLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    Case "Por Semana"
                        dtResultadoConsulta = obj.ObtenerProyeccionMaterialSemanalLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    Case "Por Mes"
                        dtResultadoConsulta = obj.ObtenerProyeccionMaterialMensualLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    Case "Por Año"
                        dtResultadoConsulta = obj.ObtenerProyeccionMaterialAnualLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    Case "Por Talla"
                        dtResultadoConsulta = obj.ObtieneProyeccionMaterialTallasLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                End Select
            Else
                If chbColeccion.Checked = True Then
                    Select Case vTipo
                        Case "Por Programa"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialProgramaColeccion(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Semana"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialSemanalColeccion(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Mes"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialMensualColeccion(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Año"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialAnualColeccion(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Talla"
                            dtResultadoConsulta = obj.ObtieneProyeccionMaterialTallasColeccion(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    End Select
                ElseIf chbLote.Checked Then
                    Select Case vTipo
                        Case "Por Programa"
                            dtResultadoConsulta = obj.ObtieneProyeccionMaterialProgramaLote(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Semana"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialSemanalLote(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Mes"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialMensualLote(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Año"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialAnualLote(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Talla"
                            dtResultadoConsulta = obj.ObtieneProyeccionMaterialTallasLote(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    End Select
                Else
                    Select Case vTipo
                        Case "Por Programa"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialPrograma(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Semana"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialSemanal(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Mes"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialMensual(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Año"
                            dtResultadoConsulta = obj.ObtenerProyeccionMaterialAnual(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                        Case "Por Talla"
                            dtResultadoConsulta = obj.ObtieneProyeccionMaterialTallas(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin, vFiltroColeccion, vFiltroModelo, vFiltroPielColor, vFiltroCorrida, vFiltroProveedor, vFiltroClasificacion, CriticosDias)
                    End Select
                End If
            End If
        Catch ex As Exception
            Dim mensajeAdvertencia As New AdvertenciaForm
            Dim mensaje_error As String = ex.Message
            mensaje_error = mensaje_error.Substring(0, 125)
            mensajeAdvertencia.mensaje = "Error al ejecutar la consulta. La información que intenta generar es muy extensa. Cambie el rango de fechas o el tipo de agrupación"
            mensajeAdvertencia.ShowDialog()

            Cursor = Cursors.Default()
            Exit Sub
        End Try


        If dtResultadoConsulta.Rows.Count > 0 Then
            OrdenTabla()
            grdReporte.DataSource = Nothing
            vwReporte.Columns.Clear()
            grdReporte.DataSource = dtResultadoConsulta
            DiseñoGrid()
            btnArriba_Click(Nothing, Nothing)
        Else
            Dim mensajeAdvertencia As New AdvertenciaForm
            mensajeAdvertencia.mensaje = "No hay datos para mostrar"
            mensajeAdvertencia.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub OrdenTabla()

        If dtResultadoConsulta.Rows.Count > 0 Then
            For Each row As DataRow In dtResultadoConsulta.Rows
                For Each col As DataColumn In dtResultadoConsulta.Columns
                    If col.ColumnName = "PROVEEDOR" Then
                        Dim V As String() = row(col).ToString().Split(CChar("-"))
                        If V.Count > 1 Then
                            row(col) = V(1)
                        End If
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub btnMaterial_Click(sender As Object, e As EventArgs) Handles btnMaterial.Click
        LlenarGridFiltro(grdMaterial, "Material", 8)
    End Sub


    Private Sub LlenarGridFiltro(pGrid As Infragistics.Win.UltraWinGrid.UltraGrid, ByVal pHeader As String, ByVal pTipoBusqueda As Integer)
        Dim listado As New ListadoParametrosFiltrado
        listado.tipo_busqueda = pTipoBusqueda
        listado.vIdNave = IIf(cmbNave.Text <> "", cmbNave.SelectedValue, Nothing)

        'CarlosMtz 'Filtro como permiso especial para las naves Inyeva y Distribuidora de suela (L.175-242)
        If ((inyeva Or distribuidora) And Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid <> 665) And pTipoBusqueda = 9 Then

            Dim tablan As New DataTable
            tablan.Columns.Add("parametro")
            tablan.Columns.Add("Valor")
            tablan.Columns.Add("Proveedor")

            If inyeva Then
                tablan.Rows.InsertAt(tablan.NewRow, 0)
                tablan.Rows(0).Item("parametro") = 704
                tablan.Rows(0).Item("Valor") = True
                tablan.Rows(0).Item("Proveedor") = "INYEVA,, S.A. DE C.V."
            End If
            If distribuidora Then
                tablan.Rows.InsertAt(tablan.NewRow, 0)
                tablan.Rows(0).Item("parametro") = 918
                tablan.Rows(0).Item("Valor") = True
                tablan.Rows(0).Item("Proveedor") = "SUELAS TRENTO S.A. DE C.V."
            End If
            pGrid.DataSource = tablan
            With pGrid
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
            End With
            gbProveedor.Enabled = False
        ElseIf ((inyeva Or distribuidora) And Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid <> 665) And pTipoBusqueda = 8 Then
            Dim tablan As New DataTable
            tablan.Columns.Add("parametro")
            tablan.Columns.Add("Valor")
            tablan.Columns.Add("Proveedor")

            tablan.Rows.InsertAt(tablan.NewRow, 0)

            tablan.Rows(0).Item("parametro") = 49
            tablan.Rows(0).Item("Valor") = True
            tablan.Rows(0).Item("Proveedor") = "SUELA"

            pGrid.DataSource = tablan

            With pGrid
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
            End With
            gbMaterial.Enabled = False
        Else
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

        End If

        'CarlosMtz '21-09-2020
        'Dim listado As New ListadoParametrosFiltrado
        'listado.tipo_busqueda = pTipoBusqueda
        'listado.vIdNave = IIf(cmbNave.Text <> "", cmbNave.SelectedValue, Nothing)
        'Dim listaParametroID As New List(Of String)
        'For Each row As UltraGridRow In pGrid.Rows
        '    Dim parametro As String = row.Cells(0).Text
        '    listaParametroID.Add(parametro)
        'Next
        'listado.listaParametroID = listaParametroID



        'listado.ShowDialog(Me)
        'If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        'If listado.listParametros.Rows.Count = 0 Then Return
        'pGrid.DataSource = listado.listParametros

        'With pGrid
        '    .DisplayLayout.Bands(0).Columns(0).Hidden = True
        '    .DisplayLayout.Bands(0).Columns(1).Hidden = True
        '    .DisplayLayout.Bands(0).Columns(2).Header.Caption = pHeader
        'End With


    End Sub

    Private Sub btnProveedor_Click(sender As Object, e As EventArgs) Handles btnProveedor.Click

        'If cmbNave.Text <> "" Then B 
        LlenarGridFiltro(grdProveedor, "Proveedor", 9)
        'Else
        '    Dim mensajeAdvertencia As New AdvertenciaForm
        '    mensajeAdvertencia.mensaje = "Seleccione una nave"
        '    mensajeAdvertencia.ShowDialog()
        'End If
    End Sub

    Private Sub btnColeccion_Click(sender As Object, e As EventArgs) Handles btnColeccion.Click
        LlenarGridFiltro(grdColeccion, "Colección", 2)
    End Sub

    Private Sub btnModelo_Click(sender As Object, e As EventArgs) Handles btnModelo.Click
        LlenarGridFiltro(grdModelo, "Modelo", 3)
    End Sub

    Private Sub btnPielColor_Click(sender As Object, e As EventArgs) Handles btnPielColor.Click
        LlenarGridFiltro(grdPielColor, "Piel / Color", 7)
    End Sub

    Private Sub btnCorrida_Click(sender As Object, e As EventArgs) Handles btnCorrida.Click
        LlenarGridFiltro(grdCorrida, "Corrida", 6)
    End Sub

    Private Sub btnLimProveedor_Click(sender As Object, e As EventArgs) Handles btnLimProveedor.Click
        grdProveedor.DataSource = Nothing
    End Sub

    Private Sub btnLimMaterial_Click(sender As Object, e As EventArgs) Handles btnLimMaterial.Click
        grdMaterial.DataSource = Nothing
    End Sub

    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        grdColeccion.DataSource = Nothing
    End Sub

    Private Sub btnLimModelo_Click(sender As Object, e As EventArgs) Handles btnLimModelo.Click
        grdModelo.DataSource = Nothing
    End Sub

    Private Sub btnLimPielColor_Click(sender As Object, e As EventArgs) Handles btnLimPielColor.Click
        grdPielColor.DataSource = Nothing
    End Sub

    Private Sub btnLimCorrida_Click(sender As Object, e As EventArgs) Handles btnLimCorrida.Click
        grdCorrida.DataSource = Nothing
    End Sub

    Private Sub CargarNAves()

        Dim lstNavesCombo As New List(Of Entidades.Naves)
        Dim lstNavesMostrar As New List(Of Integer)
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "LECTURA_FVO") Then
            cmbNave = Tools.Controles.ComboNavesSegunUsuario_Especial(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Else
            cmbNave = Tools.Controles.ComboNavesSegunUsuario(cmbNave, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        End If

        cmbNave.ValueMember = "PNaveId"
        cmbNave.DisplayMember = "PNombre"



    End Sub

    Private Sub chbPrograma_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrograma.CheckedChanged

        If chbPrograma.Checked = True Then
            If inyeva Or distribuidora Then
                pnlPdf.Visible = True
                dtpFechaFin.Enabled = False
                gbColeccion.Enabled = False
                gbCorrida.Enabled = False
                gbMaterial.Enabled = False
                gbModelo.Enabled = False
                gbPielColor.Enabled = False
                gbProveedor.Enabled = False
                grdColeccion.DataSource = Nothing
                grdCorrida.DataSource = Nothing
                grdModelo.DataSource = Nothing
                grdPielColor.DataSource = Nothing
                cmbAgrupado.Enabled = False
                cmbAgrupado.SelectedIndex = 0
                dtpFechaFin.Value = dtpFechaInicio.Value
                chbSemana.Checked = False
                chbSemana.Visible = False
            Else
                pnlPdf.Visible = True
                dtpFechaFin.Enabled = False
                gbColeccion.Enabled = False
                gbCorrida.Enabled = False
                gbMaterial.Enabled = False
                gbModelo.Enabled = False
                gbPielColor.Enabled = False
                gbProveedor.Enabled = False
                grdColeccion.DataSource = Nothing
                grdCorrida.DataSource = Nothing
                grdMaterial.DataSource = Nothing
                grdModelo.DataSource = Nothing
                grdPielColor.DataSource = Nothing
                grdProveedor.DataSource = Nothing
                cmbAgrupado.Enabled = False
                cmbAgrupado.SelectedIndex = 0
                dtpFechaFin.Value = dtpFechaInicio.Value
                chbSemana.Checked = False
                chbSemana.Visible = False
            End If

            'pnlPdf.Visible = True
            'dtpFechaFin.Enabled = False
            'gbColeccion.Enabled = False
            'gbCorrida.Enabled = False
            'gbMaterial.Enabled = False
            'gbModelo.Enabled = False
            'gbPielColor.Enabled = False
            'gbProveedor.Enabled = False
            'grdColeccion.DataSource = Nothing
            'grdCorrida.DataSource = Nothing
            'grdMaterial.DataSource = Nothing
            'grdModelo.DataSource = Nothing
            'grdPielColor.DataSource = Nothing
            'grdProveedor.DataSource = Nothing
            'cmbAgrupado.Enabled = False
            'cmbAgrupado.SelectedIndex = 0
            'dtpFechaFin.Value = dtpFechaInicio.Value
            'chbSemana.Checked = False
            'chbSemana.Visible = False
        Else
            pnlPdf.Visible = False
            dtpFechaFin.Enabled = True
            gbColeccion.Enabled = True
            gbCorrida.Enabled = True
            gbMaterial.Enabled = True
            gbModelo.Enabled = True
            gbPielColor.Enabled = True
            gbProveedor.Enabled = True
            cmbAgrupado.Enabled = True

        End If
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

    Private Sub grdProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdProveedor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdProveedor.DeleteSelectedRows(False)
    End Sub

    Private Sub grdMaterial_KeyDown(sender As Object, e As KeyEventArgs) Handles grdMaterial.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdMaterial.DeleteSelectedRows(False)
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
    End Sub
    Private Sub grdPielColor_KeyDown(sender As Object, e As KeyEventArgs) Handles grdPielColor.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdPielColor.DeleteSelectedRows(False)
    End Sub
    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub
    Private Sub grdModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles grdModelo.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdModelo.DeleteSelectedRows(False)
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

    Private Sub grdProveedor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdProveedor.InitializeLayout
        grid_diseño(grdProveedor)
    End Sub
    Private Sub grdMaterial_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdMaterial.InitializeLayout
        grid_diseño(grdMaterial)
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
    End Sub

    Private Sub grdPielColor_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdPielColor.InitializeLayout
        grid_diseño(grdPielColor)
    End Sub

    Private Sub grdCorrida_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
    End Sub

    Private Sub grdModelo_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdModelo.InitializeLayout
        grid_diseño(grdModelo)
    End Sub

    Private Sub dtpFechaInicio_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged

        If dtpFechaFin.MinDate > "31/12/" + dtpFechaInicio.Value.Year.ToString() Then
            dtpFechaFin.MinDate = dtpFechaInicio.Value
            'dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()
        Else
            'dtpFechaFin.MaxDate = "31/12/" + dtpFechaInicio.Value.Year.ToString()
            dtpFechaFin.MinDate = dtpFechaInicio.Value

            If chbPrograma.Checked = True Then
                dtpFechaFin.Value = dtpFechaInicio.Value
            End If
        End If



    End Sub

    Private Sub obtenerFiltros()

        vFiltroNave = If(cmbNave.SelectedIndex >= 0, cmbNave.SelectedValue, 0)
        vFiltroFechaInicio = dtpFechaInicio.Value
        vFiltroFechaFin = dtpFechaFin.Value
        vFiltroProveedor = Filtros(grdProveedor)
        vFiltroClasificacion = Filtros(grdMaterial)
        vFiltroColeccion = Filtros(grdColeccion)
        vFiltroCorrida = Filtros(grdCorrida)
        vFiltroPielColor = Filtros(grdPielColor)
        vFiltroModelo = Filtros(grdModelo)

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

    Private Sub vwReporte_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles vwReporte.CustomDrawCell
        Cursor = Cursors.WaitCursor
        If e.RowHandle >= 0 Then
            If e.Column.FieldName.Contains("TOTAL") Then
                e.Appearance.BackColor = Color.FromArgb(189, 215, 238)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub vwReporte_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles vwReporte.RowStyle
        If vwReporte.GetRowCellValue(e.RowHandle, "PROVEEDOR") = "TOTAL" Then
            e.Appearance.BackColor = Color.FromArgb(189, 215, 238)
        End If
    End Sub

    Private Sub DiseñoGrid()
        For Each vColumna As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns

            vColumna.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

            If vColumna.FieldName.Contains("PROVEEDORNM") = True Or vColumna.FieldName.Contains("orden") = True Then
                vColumna.Visible = False

            ElseIf vColumna.FieldName.Contains("NAVE") = True Then
                vColumna.Width = 100
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("PROVEEDOR") = True Then
                vColumna.Width = 250
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("ID") = True Then
                vColumna.Width = 50
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("MATERIAL") = True Then
                vColumna.Width = 370
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("SEM") = True Then
                vColumna.Width = 50
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("MaterialCritico") = True Then
                vColumna.Width = 80
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            ElseIf vColumna.FieldName.Contains("NaveId") = True Then
                vColumna.Visible = False

            ElseIf vColumna.FieldName.Contains("UNIDAD") = True Then
                vColumna.Width = 110
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                vColumna.Caption = "UNIDAD DE COMPRA"
            ElseIf vColumna.FieldName.Contains("TOTAL") = True Then
                vColumna.VisibleIndex = vwReporte.Columns.Count
            ElseIf vColumna.FieldName.Contains("COLECCION") = True Then
                vColumna.Width = 140
                vColumna.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                vColumna.Caption = "COLECCIÓN"
            ElseIf vColumna.FieldName.Contains("LOTE") = True Then
                vColumna.Width = 50
            Else
                vColumna.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                vColumna.DisplayFormat.FormatString = "##,##0.0"

            End If
        Next

        If (vTipo = "Por Talla") Then
            If chbSemana.Checked Then
                vwReporte.Columns("SEM").Visible = True
            ElseIf chbSemana.Checked = False Then
                vwReporte.Columns("SEM").Visible = False
            End If
        End If

        If chbCriDias.Checked = False Then
            vwReporte.Columns("MaterialCritico").Visible = False
            vwReporte.Columns("DiasEntrega").Visible = False
        Else
            vwReporte.Columns("MaterialCritico").Visible = True
            vwReporte.Columns("DiasEntrega").Visible = False
        End If

        If (vTipo = "Por Talla") And (chbSemana.Checked Or chbSemana.Checked = False) Then
            vwReporte.OptionsView.AllowCellMerge = True
        End If

        vwReporte.Columns("MaterialCritico").Caption = "MAT CRITICO"

        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwReporte.Columns
            col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains
        Next

    End Sub

    Private Sub gridVReporte_CellMerge(ByVal sender As Object, ByVal e As CellMergeEventArgs) Handles vwReporte.CellMerge
        Dim view1 As GridView = sender
        e.Handled = True

        If vTipo = "Por Talla" Then
            If (e.Column.FieldName = ("SEM")) Then
                Dim view = sender
                Dim previousCol As Object
                previousCol = view.Columns(view.Columns.IndexOf(e.Column)).FieldName
                If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                    e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                    e.Handled = True
                End If
            End If

            If (e.Column.FieldName = ("NAVE")) Then
                Dim view = sender
                Dim previousCol As Object
                previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 1).FieldName
                If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                    e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                    e.Handled = True
                End If
            End If

            If (e.Column.FieldName = ("PROVEEDOR")) Then
                Dim view = sender
                Dim previousCol As Object
                previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 2).FieldName
                If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                    e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                    e.Handled = True
                End If
            End If

            If (e.Column.FieldName = ("ID")) Then
                Dim view = sender
                Dim previousCol As Object
                previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 3).FieldName
                If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                    e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                    e.Handled = True
                End If
            End If

            If chbColeccion.Checked = False Then
                If (e.Column.FieldName = ("MATERIAL")) Then
                    Dim view = sender
                    Dim previousCol As Object
                    previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 4).FieldName
                    If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                        e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                        e.Handled = True
                    End If
                End If
            End If


            If (e.Column.FieldName = ("UNIDAD DE COMPRA")) Then
                Dim view = sender
                Dim previousCol As Object
                previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 5).FieldName
                If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                    e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                    e.Handled = True
                End If
            End If

            If chbColeccion.Checked = False Then
                If (e.Column.FieldName = ("COLECCION")) Then
                    Dim view = sender
                    Dim previousCol As Object
                    previousCol = view.Columns(view.Columns.IndexOf(e.Column) - 6).FieldName
                    If (Convert.ToString(view.GetRowCellValue(e.RowHandle1, previousCol)) = Convert.ToString(view.GetRowCellValue(e.RowHandle2, previousCol))) Then
                        e.Merge = Object.Equals(e.CellValue1, e.CellValue2)
                        e.Handled = True
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlParametros.Height = 339
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlParametros.Height = 27
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim fbdUbicacionArchivo As New FolderBrowserDialog
        Dim nombreReporte As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            If vwReporte.DataRowCount > 0 Then
                nombreReporte = "Proyeccion_de_Materiales_" + cmbAgrupado.SelectedText
                With fbdUbicacionArchivo
                    .Reset()
                    .Description = " Seleccione una carpeta "
                    .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    .ShowNewFolderButton = True

                    Dim ret As DialogResult = .ShowDialog
                    Dim fecha_hora As String = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString + Now.Second.ToString

                    If ret = Windows.Forms.DialogResult.OK Then

                        If vwReporte.GroupCount > 0 Then
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                        Else
                            Dim exportOptions = New XlsxExportOptionsEx()
                            AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
                            vwReporte.ExportToXlsx(.SelectedPath + nombreReporte + fecha_hora + ".xlsx", exportOptions)
                        End If
                        Tools.MostrarMensaje(Mensajes.Success, "Los datos se exportaron correctamente: " & nombreReporte & fecha_hora.ToString() & ".xlsx")
                        .Dispose()
                        Process.Start(fbdUbicacionArchivo.SelectedPath + nombreReporte + fecha_hora + ".xlsx")
                    End If
                End With
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "No hay datos para exportar.")
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Tools.MostrarMensaje(Mensajes.Warning, "No se encontró el archivo")
        End Try
    End Sub


    Private Sub exportOptions_CustomizeCell(ByVal e As DevExpress.Export.CustomizeCellEventArgs)

        If vwReporte.GetRowCellValue(e.RowHandle, "PROVEEDOR") = "TOTAL" Then
            e.Formatting.BackColor = Color.FromArgb(189, 215, 238)
        End If

        If e.ColumnFieldName.Contains("TOTAL") Then
            e.Formatting.BackColor = Color.FromArgb(189, 215, 238)
        End If

        e.Handled = True

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        MenuExplosionMateriales.Show(btnImprimir, New Point(0, btnImprimir.Height))
    End Sub

    Private Sub MaterialesDirectosSinIVA_Click(sender As Object, e As EventArgs) Handles MaterialesDirectosSinIVA.Click

        Cursor = Cursors.WaitCursor

        If cmbAgrupado.Text = "Por Semana" And chReporteSemanal.Checked Then

            Dim obj As New ProyeccionMaterialBU
            Dim dtresultado As DataTable
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim entReporte As New Entidades.Reportes
            Dim StiMaterialesDirectosSInIVA As New StiReport

            Dim detalleMaterialesDirectos As New DataTable("dtMateriales")

            Dim dsMaterialesDirectosSinIVA As New DataSet("DSMaterialesSINIVA")

            entReporte = objReporte.LeerReporteporClave("EXPLO_MATE_DIRE_SINIVA")

            obtenerFiltros()

            Dim año As Integer = txtaño.Value
            Dim semana = CInt(nudSemanaInicio.Value)
            Dim naveID = vFiltroNave
            Dim fechaInico As Date
            Dim fechafin As Date
            Dim costoDirecto As Double

            Dim sumaCostoTotal, diferenciaResumen As Decimal

            Dim CajaChica, Transferencia, paresEmbarcados, difereciaPares, Total As Integer

            Dim dtParesEmbarcados, dtCamposResumen As DataTable

            dtresultado = obj.ObtenerFEchaInicioFin(semana, año)

            If dtresultado Is Nothing OrElse dtresultado.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, "No se han programado esas fechas.")
                Return
            End If

            fechaInico = Date.Parse(dtresultado.Rows(0).Item(0))
            fechafin = Date.Parse(dtresultado.Rows(0).Item(1))

            detalleMaterialesDirectos = obj.GenerarReporteExplosionMaterialesDirectosSinIVA(naveID, fechaInico, fechafin, 1, semana, año)

            If detalleMaterialesDirectos.Columns.Cast(Of DataColumn)().Any(Function(col) col.ColumnName = "Bandera") Then
                Tools.MostrarMensaje(Mensajes.Notice, $"{detalleMaterialesDirectos.Rows(0).Item("Bandera")} - {detalleMaterialesDirectos.Rows(0).Item("Mensaje")}")
                Cursor = Cursors.Default
                Return
            End If

            dtParesEmbarcados = obj.GenerarReporteExplosionMaterialesDirectosSinIVA(naveID, fechaInico, fechafin, 2, semana, año)

            dtCamposResumen = obj.GenerarReporteExplosionMaterialesDirectosSinIVA(naveID, fechaInico, fechafin, 3, semana, año)

            sumaCostoTotal = detalleMaterialesDirectos.AsEnumerable().Sum(Function(x) x.Field(Of Decimal)("CostoTotal"))

            costoDirecto = Double.Parse(dtCamposResumen.Rows(0).Item("CostoDirectoSinIVA"))
            CajaChica = Integer.Parse(dtCamposResumen.Rows(0).Item("CajaChica"))
            Transferencia = Integer.Parse(dtCamposResumen.Rows(0).Item("TranferenciaSinIVA"))
            Total = Integer.Parse(dtCamposResumen.Rows(0).Item("TotalResumen"))

            paresEmbarcados = dtParesEmbarcados.Rows(0).Item("ParesEmbarcados")
            difereciaPares = detalleMaterialesDirectos.AsEnumerable().Sum(Function(x) x.Field(Of Decimal)("Pares"))
            difereciaPares = Integer.Parse((paresEmbarcados - difereciaPares))

            diferenciaResumen = sumaCostoTotal - Total

            Dim LogoNave = Tools.Controles.ObtenerLogoNave(naveID)

            dsMaterialesDirectosSinIVA.Tables.Add(detalleMaterialesDirectos)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

            Try
                StiMaterialesDirectosSInIVA.Load(archivo)
                StiMaterialesDirectosSInIVA.Compile()
                StiMaterialesDirectosSInIVA.RegData(dsMaterialesDirectosSinIVA)
                StiMaterialesDirectosSInIVA("semana") = semana
                StiMaterialesDirectosSInIVA("anio") = año.ToString
                StiMaterialesDirectosSInIVA("log") = LogoNave
                StiMaterialesDirectosSInIVA("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                StiMaterialesDirectosSInIVA("fechaHora") = "10/01/2025"
                StiMaterialesDirectosSInIVA("ParesEmbarcados") = paresEmbarcados
                StiMaterialesDirectosSInIVA("diferencia") = difereciaPares
                StiMaterialesDirectosSInIVA("CostoDirecto") = costoDirecto
                StiMaterialesDirectosSInIVA("CajaChica") = CajaChica
                StiMaterialesDirectosSInIVA("Transferencia") = Transferencia
                StiMaterialesDirectosSInIVA("Total") = Total
                StiMaterialesDirectosSInIVA("DiferenciaResumen") = diferenciaResumen
                StiMaterialesDirectosSInIVA.Dictionary.Clear()
                StiMaterialesDirectosSInIVA.Dictionary.Synchronize()
                StiMaterialesDirectosSInIVA.Show()
            Catch ex As Exception
                Tools.MostrarMensaje(Mensajes.Notice, "Error al cargar el reporte.")
                Cursor = Cursors.Default
                Return
            End Try

        Else
            Tools.MostrarMensaje(Mensajes.Notice, "No existe información para mostrar.")
            Cursor = Cursors.Default
            Return
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub MaterialesSinteticosSinIVA_Click(sender As Object, e As EventArgs) Handles MaterialesSinteticosSinIVA.Click

        Cursor = Cursors.WaitCursor

        Dim obj As New ProyeccionMaterialBU
        Dim dsMateriales As New DataSet("dsMateriales")
        Dim detalleMateriales As New DataTable("dtMateriales")
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim dtExpMateriales As New DataTable
        Dim año As Integer = 0

        año = txtaño.Value
        obtenerFiltros()

        If cmbAgrupado.Text = "Por Semana" Then

            'Dim semana = CInt(nudSemanaInicio.Value + 1)

            Dim semana = CInt(nudSemanaInicio.Value)

            Dim fecha As New DateTime(año, 1, 1)
            Dim fechafin As Date
            Dim fechaInico As Date
            Dim dtresultado As DataTable

            dtresultado = obj.ObtenerFEchaInicioFin(semana, año)

            fechaInico = dtresultado.Rows(0).Item(0)
            fechafin = dtresultado.Rows(0).Item(1)

            'If año = 2023 Then
            '    fechafin = DateAdd(DateInterval.WeekOfYear, semana, DateAdd(DateInterval.Day, -1, fecha))
            '    fechaInico = DateAdd(DateInterval.Day, (-fechafin.DayOfWeek) + 1, fechafin)
            'Else
            '    fechafin = DateAdd(DateInterval.WeekOfYear, semana, fecha)
            '    fechaInico = DateAdd(DateInterval.Day, (-fechafin.DayOfWeek) + 1, fechafin)
            'End If


            detalleMateriales = obj.ReporteProyeccionMateriales(vFiltroNave, fechaInico, fechafin, "45,53")

            If detalleMateriales(0)(0) <> "ERROR" Then

                'Dim filename As String
                'Dim SaveFileDialog As New SaveFileDialog()
                'SaveFileDialog.Filter = "pdf files (*.pdf)|*.pdf"
                'SaveFileDialog.FilterIndex = 2
                'SaveFileDialog.RestoreDirectory = True

                'If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                '    filename = SaveFileDialog.FileName

                detalleMateriales = Nothing

                detalleMateriales = obj.ReporteProyeccionMaterialesSinteticosCorte(vFiltroNave, fechaInico, fechafin, "45,53", semana, año)

                Dim ParesProgramados = detalleMateriales.Rows(0).Item("ParesProgramados")
                Dim ParesEmbarcados As Integer = obj.GenerarReporteExplosionMaterialesDirectosSinIVA(vFiltroNave, fechaInico, fechafin, 2, semana, año).Rows(0).Item("ParesEmbarcados")

                Dim diferencia As Integer = ParesEmbarcados - ParesProgramados

                EntidadReporte = objReporte.LeerReporteporClave("MATERIALES_SINTETICOS")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                Dim reporte As New StiReport
                Dim vFecha As Date = dtpFechaInicio.Value

                reporte.Load(archivo)
                reporte.Compile()
                reporte.Dictionary.Clear()
                reporte("log") = Tools.Controles.ObtenerLogoNave(vFiltroNave)
                reporte("semana") = semana
                reporte("fechaHora") = Date.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                reporte("ParesProgramados") = ParesProgramados
                reporte("ParesEmbarcados") = ParesEmbarcados
                reporte("diferencia") = diferencia
                reporte("anio") = Integer.Parse(año)

                reporte.RegData(detalleMateriales)
                reporte.Dictionary.Synchronize()
                reporte.Render()
                'reporte.ExportDocument(StiExportFormat.Pdf, filename)
                'reporte.Dispose()
                reporte.Show()

                'If System.IO.File.Exists(filename) Then
                '    Dim DialogResult As DialogResult = MessageBox.Show("El archivo ha sido guaradado en " & filename & vbNewLine & "¿Quieres abrirlo ahora?", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                '    If DialogResult = Windows.Forms.DialogResult.Yes Then
                '        System.Diagnostics.Process.Start(filename)
                '    End If
                'End If
                'End If

                'detalleMateriales.TableName = ""

            Else
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El reporte no puede ser generado porque no ha sido loteada la producción de la semana.")
            End If
        Else
            detalleMateriales = If(Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PPCP_LOTEADOS"),
                obj.ObtenerExplosionMaterialesLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin),
                obj.ObtenerExplosionMateriales(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin))

            dtExpMateriales = obj.ObtenerExplosionMateriales(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin)
            If dtExpMateriales.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, "No existe información para mostrar.")
                Cursor = Cursors.Default
                Return
            End If
            detalleMateriales.TableName = "dtMateriales"
            dsMateriales.Tables.Add(detalleMateriales)

            EntidadReporte = objReporte.LeerReporteporClave("PROYECCION_MATERIALES")
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

            Dim reporte As New StiReport
            Dim vFecha As DateTime = dtpFechaInicio.Value

            reporte.Load(archivo)
            reporte.Compile()
            reporte("dsMateriales") = "dsMateriales"
            reporte.Dictionary.Clear()
            reporte("log") = Tools.Controles.ObtenerLogoNave(vFiltroNave)
            reporte("fecha") = vFecha.ToString("dd") + " " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(vFecha.Month - 1).ToUpper() + " " + vFecha.ToString("yyyy")
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

            reporte.RegData(dsMateriales)
            reporte.Dictionary.Synchronize()
            reporte.Show()
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmbAgrupado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAgrupado.SelectedIndexChanged
        If cmbAgrupado.Text = "Por Talla" Then
            chbSemana.Visible = True
            'chbLote.Enabled = False
            'chbLote.Checked = False
            'ElseIf cmbAgrupado.Text = "Por Semana" And Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid = 21 Then
            'pnlPdf.Show()

            ' Label1.Visible = True
            'lblNoSemana.Visible = True
            'Label4.Visible = True
            'nudSemanaInicio.Visible = True

            'dtpFechaInicio.Visible = False
            'dtpFechaFin.Visible = False
            'Label2.Visible = False
            'Label3.Visible = False
        Else
            chbSemana.Visible = False
            chbLote.Enabled = True

            ''Label1.Visible = False
            'lblNoSemana.Visible = False
            'Label4.Visible = False
            'nudSemanaInicio.Visible = False

            dtpFechaInicio.Visible = True
            dtpFechaFin.Visible = True
            Label2.Visible = True
            Label3.Visible = True
        End If
    End Sub

    Private Sub chbSemana_CheckedChanged(sender As Object, e As EventArgs) Handles chbSemana.CheckedChanged
        If vwReporte.RowCount > 0 Then
            If chbSemana.Checked Then
                vwReporte.Columns("SEM").Visible = True
            ElseIf chbSemana.Checked = False Then
                vwReporte.Columns("SEM").Visible = False
            End If
        End If
    End Sub

    Private Sub chbColeccion_CheckedChanged(sender As Object, e As EventArgs) Handles chbColeccion.CheckedChanged
        If chbColeccion.Checked Then
            chbSemana.Checked = False
        End If
    End Sub

    Private Sub chbCriDias_CheckedChanged(sender As Object, e As EventArgs) Handles chbCriDias.CheckedChanged
        Try
            If chbCriDias.Checked = False Then
                vwReporte.Columns("MaterialCritico").Visible = False
                vwReporte.Columns("DiasEntrega").Visible = False
            Else
                vwReporte.Columns("MaterialCritico").Visible = True
                vwReporte.Columns("DiasEntrega").Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chReporteSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles chReporteSemanal.CheckedChanged
        If chReporteSemanal.Checked = False Then
            grpReporte.Enabled = False
            pnlPdf.Visible = False
            gbFecha.Enabled = True
        Else
            grpReporte.Enabled = True
            pnlPdf.Show()
            gbFecha.Enabled = False
        End If
    End Sub

    Private Sub MaterialesDirectosConIVA_Click(sender As Object, e As EventArgs) Handles MaterialesDirectosConIVA.Click

        Cursor = Cursors.WaitCursor

        If cmbAgrupado.Text = "Por Semana" And chReporteSemanal.Checked Then

            Dim obj As New ProyeccionMaterialBU
            Dim dtresultado As DataTable
            Dim objReporte As New Framework.Negocios.ReportesBU
            Dim entReporte As New Entidades.Reportes
            Dim StiMaterialesDirectosSInIVA As New StiReport

            Dim detalleMaterialesDirectos As New DataTable("dtMateriales")

            Dim dsMaterialesDirectosSinIVA As New DataSet("DSMaterialesSINIVA")

            entReporte = objReporte.LeerReporteporClave("EXPLO_MATE_DIRE_CONIVA")

            obtenerFiltros()

            Dim año As Integer = txtaño.Value
            Dim semana = CInt(nudSemanaInicio.Value)
            Dim naveID = vFiltroNave
            Dim fechaInico As Date
            Dim fechafin As Date
            Dim costoDirecto As Double

            Dim sumaCostoTotal, diferenciaResumen As Decimal

            Dim CajaChica, Transferencia, paresEmbarcados, difereciaPares, Total As Integer

            Dim dtParesEmbarcados, dtCamposResumen As DataTable

            dtresultado = obj.ObtenerFEchaInicioFin(semana, año)

            If dtresultado Is Nothing OrElse dtresultado.Rows.Count = 0 Then
                Tools.MostrarMensaje(Mensajes.Notice, "No se han programado esas fechas.")
                Return
            End If

            fechaInico = Date.Parse(dtresultado.Rows(0).Item(0))
            fechafin = Date.Parse(dtresultado.Rows(0).Item(1))

            Dim ParesProgramados As Integer = obj.ReporteProyeccionMateriales(vFiltroNave, fechaInico, fechafin, "45,53").Rows(0).Item("ParesProgramados")

            detalleMaterialesDirectos = obj.GenerarReporteExplosionMaterialesDirectosConIVA(naveID, fechaInico, fechafin, 1, semana, año)

            If detalleMaterialesDirectos.Columns.Cast(Of DataColumn)().Any(Function(col) col.ColumnName = "Bandera") Then
                Tools.MostrarMensaje(Mensajes.Notice, $"{detalleMaterialesDirectos.Rows(0).Item("Bandera")} - {detalleMaterialesDirectos.Rows(0).Item("Mensaje")}")
                Cursor = Cursors.Default
                Return
            End If

            dtParesEmbarcados = obj.GenerarReporteExplosionMaterialesDirectosConIVA(naveID, fechaInico, fechafin, 2, semana, año)

            dtCamposResumen = obj.GenerarReporteExplosionMaterialesDirectosConIVA(naveID, fechaInico, fechafin, 3, semana, año)

            sumaCostoTotal = detalleMaterialesDirectos.AsEnumerable().Sum(Function(x) x.Field(Of Decimal)("CostoTotalConIVA"))

            costoDirecto = Double.Parse(dtCamposResumen.Rows(0).Item("CostoDirectoConIVA"))
            CajaChica = Integer.Parse(dtCamposResumen.Rows(0).Item("CajaChica"))
            Transferencia = Integer.Parse(dtCamposResumen.Rows(0).Item("TranferenciaConIVA"))
            Total = Integer.Parse(dtCamposResumen.Rows(0).Item("TotalResumen"))

            paresEmbarcados = dtParesEmbarcados.Rows(0).Item("ParesEmbarcados")
            difereciaPares = Integer.Parse((paresEmbarcados - ParesProgramados))



            Dim PromedioIVA As Double = 0
            Dim ResultadoIVAxPares As Double = 0
            'Se calcula multiplicando el total de Pares x el IVA
            For Each row As DataRow In detalleMaterialesDirectos.Rows
                ResultadoIVAxPares += row.Item("IVA") * row.Item("Pares")
            Next
            Dim sumatoriaPares = detalleMaterialesDirectos.AsEnumerable().Sum(Function(x) x.Field(Of Decimal)("Pares"))
            PromedioIVA = ResultadoIVAxPares / sumatoriaPares




            Dim PromedioCostoMaterialDirecto As Double = 0
            Dim ResultadoCostoMaterialxPares As Double = 0
            'Se calcula multiplicando el total de Pares x el IVA
            For Each row As DataRow In detalleMaterialesDirectos.Rows
                ResultadoCostoMaterialxPares += row.Item("CostoMaterialDirecto") * row.Item("Pares")
            Next

            PromedioCostoMaterialDirecto = ResultadoCostoMaterialxPares / sumatoriaPares



            diferenciaResumen = sumaCostoTotal - Total

            Dim LogoNave = Tools.Controles.ObtenerLogoNave(naveID)

            dsMaterialesDirectosSinIVA.Tables.Add(detalleMaterialesDirectos)

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)

            Try
                StiMaterialesDirectosSInIVA.Load(archivo)
                StiMaterialesDirectosSInIVA.Compile()
                StiMaterialesDirectosSInIVA.RegData(dsMaterialesDirectosSinIVA)
                StiMaterialesDirectosSInIVA("semana") = semana
                StiMaterialesDirectosSInIVA("anio") = año.ToString
                StiMaterialesDirectosSInIVA("log") = LogoNave
                StiMaterialesDirectosSInIVA("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
                StiMaterialesDirectosSInIVA("fechaHora") = "10/01/2025"
                StiMaterialesDirectosSInIVA("ParesEmbarcados") = paresEmbarcados
                StiMaterialesDirectosSInIVA("ParesProgramados") = ParesProgramados
                StiMaterialesDirectosSInIVA("diferencia") = difereciaPares
                StiMaterialesDirectosSInIVA("CostoDirecto") = costoDirecto
                StiMaterialesDirectosSInIVA("CajaChica") = CajaChica
                StiMaterialesDirectosSInIVA("Transferencia") = Transferencia
                StiMaterialesDirectosSInIVA("Total") = Total
                StiMaterialesDirectosSInIVA("DiferenciaResumen") = diferenciaResumen
                StiMaterialesDirectosSInIVA("PromedioIVA") = PromedioIVA
                StiMaterialesDirectosSInIVA("PromedioCostoMaterialDirecto") = PromedioCostoMaterialDirecto
                StiMaterialesDirectosSInIVA.Dictionary.Clear()
                StiMaterialesDirectosSInIVA.Dictionary.Synchronize()
                StiMaterialesDirectosSInIVA.Show()
            Catch ex As Exception
                Tools.MostrarMensaje(Mensajes.Notice, "Error al cargar el reporte.")
                Cursor = Cursors.Default
                Return
            End Try

        Else
            Tools.MostrarMensaje(Mensajes.Notice, "No existe información para mostrar.")
            Cursor = Cursors.Default
            Return
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub MaterialesSinteticosConIVA_Click(sender As Object, e As EventArgs) Handles MaterialesSinteticosConIVA.Click

        Cursor = Cursors.WaitCursor

        Dim obj As New ProyeccionMaterialBU

        Dim dsMateriales As New DataSet("DTMaterialesSinteticos")
        Dim detalleMaterialesSinteticosConIVA As New DataTable("dtSinteticosConIVA")
        Dim dtProveedor As New DataTable("dtProveedor")

        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        Dim dtExpMateriales As New DataTable
        Dim año As Integer = 0

        año = txtaño.Value
        obtenerFiltros()

        If cmbAgrupado.Text = "Por Semana" Then

            Try

                Dim semana = CInt(nudSemanaInicio.Value)

                Dim fecha As New DateTime(año, 1, 1)
                Dim fechafin As Date
                Dim fechaInico As Date
                Dim dtresultado As DataTable

                dtresultado = obj.ObtenerFEchaInicioFin(semana, año)

                fechaInico = dtresultado.Rows(0).Item(0)
                fechafin = dtresultado.Rows(0).Item(1)

                detalleMaterialesSinteticosConIVA = obj.ReporteProyeccionMateriales(vFiltroNave, fechaInico, fechafin, "45,53")

                If detalleMaterialesSinteticosConIVA(0)(0) <> "ERROR" Then

                    detalleMaterialesSinteticosConIVA = Nothing

                    detalleMaterialesSinteticosConIVA = obj.ReporteProyeccionMaterialesSinteticosCorte(vFiltroNave, fechaInico, fechafin, "45,53", semana, año)

                    ' Agrupar proveedores y agregarlos a dtProveedor
                    dtProveedor.Columns.Add("Proveedor", GetType(String))
                    Dim proveedores = detalleMaterialesSinteticosConIVA.AsEnumerable().Select(Function(row) row.Field(Of String)("Proveedor")).Distinct()

                    For Each proveedor In proveedores
                        Dim newRow As DataRow = dtProveedor.NewRow()
                        newRow("Proveedor") = proveedor
                        dtProveedor.Rows.Add(newRow)
                    Next

                    ' Asegúrate de que los nombres de las tablas sean únicos
                    detalleMaterialesSinteticosConIVA.TableName = "dtSinteticosConIVA"
                    dtProveedor.TableName = "dtProveedor"

                    Dim ParesProgramados = detalleMaterialesSinteticosConIVA.Rows(0).Item("ParesProgramados")
                    Dim ParesEmbarcados As Integer = obj.GenerarReporteExplosionMaterialesDirectosSinIVA(vFiltroNave, fechaInico, fechafin, 2, semana, año).Rows(0).Item("ParesEmbarcados")

                    Dim diferencia As Integer = ParesEmbarcados - ParesProgramados

                    EntidadReporte = objReporte.LeerReporteporClave("EXPLO_MATE_SINTE_CONIVA")
                    Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                    My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                    Dim reporte As New StiReport
                    Dim vFecha As Date = dtpFechaInicio.Value

                    dsMateriales.Tables.Add(detalleMaterialesSinteticosConIVA)
                    dsMateriales.Tables.Add(dtProveedor)

                    reporte.Load(archivo)
                    reporte.Compile()
                    reporte.Dictionary.Clear()
                    reporte("log") = Tools.Controles.ObtenerLogoNave(vFiltroNave)
                    reporte("semana") = semana
                    reporte("fechaHora") = Date.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                    reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                    reporte("ParesProgramados") = ParesProgramados
                    reporte("ParesEmbarcados") = ParesEmbarcados
                    reporte("diferencia") = diferencia
                    reporte("anio") = Integer.Parse(año)
                    reporte.RegData(dsMateriales)
                    reporte.Dictionary.Synchronize()
                    reporte.Render()
                    reporte.Show()
                Else
                    Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El reporte no puede ser generado porque no ha sido loteada la producción de la semana.")
                End If

            Catch ex As Exception
                Utilerias.show_message(Utilerias.TipoMensaje.Aviso, "El reporte no puede ser generado porque no ha sido loteada la producción de la semana.")
            End Try

        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub PedidosMateriales_Click(sender As Object, e As EventArgs) Handles PedidosMateriales.Click

        If cmbAgrupado.Text <> "Por Semana" And chReporteSemanal.Checked = False Then

            Try

                Dim obj As New ProyeccionMaterialBU
                Dim dsMateriales As New DataSet("dsMateriales")
                Dim detalleMateriales As New DataTable("dtMateriales")
                Dim objReporte As New Framework.Negocios.ReportesBU
                Dim dtExpMateriales As New DataTable
                Dim EntidadReporte As Entidades.Reportes

                obtenerFiltros()

                detalleMateriales = If(Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("PROYECCION_MATERIALES", "PPCP_LOTEADOS"),
                                    obj.ObtenerExplosionMaterialesLoteado(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin),
                                    obj.ObtenerExplosionMateriales(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin))

                dtExpMateriales = obj.ObtenerExplosionMateriales(vFiltroNave, vFiltroFechaInicio, vFiltroFechaFin)
                If dtExpMateriales.Rows.Count = 0 Then
                    Tools.MostrarMensaje(Mensajes.Notice, "No existe información para mostrar.")
                    Cursor = Cursors.Default
                    Return
                End If
                detalleMateriales.TableName = "dtMateriales"
                dsMateriales.Tables.Add(detalleMateriales)

                EntidadReporte = objReporte.LeerReporteporClave("PROYECCION_MATERIALES")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)

                Dim reporte As New StiReport
                Dim vFecha As DateTime = dtpFechaInicio.Value

                reporte.Load(archivo)
                reporte.Compile()
                reporte("dsMateriales") = "dsMateriales"
                reporte.Dictionary.Clear()
                reporte("log") = Tools.Controles.ObtenerLogoNave(vFiltroNave)
                reporte("fecha") = vFecha.ToString("dd") + " " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames(vFecha.Month - 1).ToUpper() + " " + vFecha.ToString("yyyy")
                reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
                reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername

                reporte.RegData(dsMateriales)
                reporte.Dictionary.Synchronize()
                reporte.Show()

            Catch ex As Exception
                Tools.MostrarMensaje(Mensajes.Notice, ex.Message)
                Cursor = Cursors.Default
                Return
            End Try

        Else
            Tools.MostrarMensaje(Mensajes.Notice, "Verifica los filtros seleccionados.")
            Cursor = Cursors.Default
            Return
        End If

    End Sub

    Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged
        If chbLote.Checked Then
            chbPrograma.Checked = False
            chbPrograma.Enabled = False
            chbColeccion.Checked = False
            chbColeccion.Enabled = False
            'chbsemana.checked = false
            'chbsemana.enabled = false
            chbCriDias.Checked = False
            chbCriDias.Enabled = False
        Else
            chbPrograma.Enabled = True
            chbColeccion.Enabled = True
            chbSemana.Enabled = True
            chbCriDias.Enabled = True
        End If
    End Sub
End Class