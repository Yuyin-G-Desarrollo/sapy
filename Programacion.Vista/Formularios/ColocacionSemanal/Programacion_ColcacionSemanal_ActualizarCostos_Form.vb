Imports System.Globalization
Imports System.IO
Imports System.Net
Imports DevExpress.XtraGrid
Imports Programacion.Negocios
Imports Stimulsoft.Report
Imports Stimulsoft.Report.Export
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports Tools
Public Class Programacion_ColcacionSemanal_ActualizarCostos_Form
    Public IdNaveSay As Integer = 0
    Public NaveSay As Integer = 0
    Public marca As String = String.Empty
    Public NombreNave As String
    Public Colecciones As String = String.Empty
    Public marcadosActualmente As New List(Of Integer)
    Public accionForm As String
    Dim objAdvertencia As New Tools.AdvertenciaForm
    Dim objExito As New Tools.ExitoForm
    Dim objConfirmar As New Tools.ConfirmarForm
    Dim objError As New Tools.ErroresForm
    Dim exportar As Integer = 0
    Public tabla As New DataTable
    Public ProductoEstiloSeleccionados As String = String.Empty
    Public NaveIdSay As String = String.Empty
    Dim UsuarioId As Integer
    Dim Ruta = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL"
    Dim Existe As String = String.Empty
    Dim value As New Object
    Dim listaInicial As New List(Of String)
    Dim FColeccion As String = String.Empty
    Dim FCorrida As String = String.Empty
    Dim coleccion() As String
    Dim formatoExcel As StiExcelExportSettings = New StiExcelExportSettings()
    Dim ContadorArticulos As Integer = 0
    Dim NumeroFilas As Integer = 0
    Public inicio As Boolean = True
    Dim BanderaDescontinuar As Boolean = False

    Dim FechaGeneracionExcel As String = String.Empty

    Private Sub Programacion_ColcacionSemanal_ActualizarCostos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        Me.Location = New Point(0, 0)
        cmbNaveOrigen = Controles.ComboNavesSegunUsuario(cmbNaveOrigen, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Me.Text = "Actualizar Costos"
        lblTituloPantalla.Text = "Actualizar Costos"
        lblActualizar.Text = "Generar"
        LlenarNave()
        cmbNaveOrigen.Text = NombreNave
        chFiltarCorrida.Enabled = True
        chFiltarCorrida.Checked = False
        'cmbMarca.Enabled = false


    End Sub

    Private Sub LlenarNave()
        Dim DTNAves As DataTable
        Dim objBU As New ColeccionNaveBU

        DTNAves = objBU.ConsultarNavesAux()
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)

        cmbNaveOrigen.DataSource = DTNAves
        cmbNaveOrigen.DisplayMember = "Nave"
        cmbNaveOrigen.ValueMember = "NaveSAYId"


    End Sub


    Public Sub llenarMarcas()
        Dim obj As New ColeccionNaveBU
        Dim DTMarca As New DataTable
        '   If cmbComercializadora.SelectedValue > 0 Then
        If cmbNaveOrigen.SelectedValue.ToString <> "" And cmbNaveOrigen.Text.ToString <> "" Then
            DTMarca = obj.ConsultarNavesMarca(cmbNaveOrigen.SelectedValue)
            If Not DTMarca.Rows.Count = 0 Then
                DTMarca.Rows.InsertAt(DTMarca.NewRow, 0)
                cmbMarca.DataSource = DTMarca
                cmbMarca.DisplayMember = "Marca"
                ' cmbMarca.ValueMember = "IdMarca"

            End If

        End If
    End Sub



    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        IdNaveSay = cmbNaveOrigen.SelectedValue
        marca = cmbMarca.Text
        FColeccion = ObtenerFiltrosGrid(grdColeccion)
        FCorrida = ObtenerFiltrosGrid(grdCorrida)

        If cmbNaveOrigen.SelectedIndex > 0 Then
            IdNaveSay = cmbNaveOrigen.SelectedValue
            FColeccion = ObtenerFiltrosGrid(grdColeccion)
            FCorrida = ObtenerFiltrosGrid(grdCorrida)

            If FColeccion <> "" And FCorrida <> "" Then
                IdNaveSay = cmbNaveOrigen.SelectedValue
                marca = cmbMarca.Text
                FColeccion = ObtenerFiltrosGrid(grdColeccion)
                coleccion = Split(FColeccion, ",")

                FCorrida = ObtenerFiltrosGrid(grdCorrida)
                LlenarTablaArticulosTallas()

            End If


            If FColeccion <> "" And FCorrida = "" Then
                IdNaveSay = cmbNaveOrigen.SelectedValue
                marca = cmbMarca.Text
                FColeccion = ObtenerFiltrosGrid(grdColeccion)
                coleccion = Split(FColeccion, ",")
                FCorrida = ObtenerFiltrosGrid(grdCorrida)
                LlenarTablaArticulos()


            ElseIf cmbNaveOrigen.SelectedIndex > 0 And FColeccion = "" Then
                objAdvertencia.mensaje = "Seleccione al menos una Colección"
                objAdvertencia.ShowDialog()

            End If

        Else
            objAdvertencia.mensaje = "Seleccione la Nave."
            objAdvertencia.ShowDialog()


            Exit Sub
            Cursor = Cursors.Default
        End If


        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub DisenioGrid()
        vwActualizarPPCP.OptionsCustomization.AllowSort = True
        vwActualizarPPCP.OptionsCustomization.AllowFilter = True
        vwActualizarPPCP.IndicatorWidth = 30
        vwActualizarPPCP.OptionsView.ShowAutoFilterRow = True
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In vwActualizarPPCP.Columns
            col.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            col.OptionsFilter.AutoFilterCondition = Columns.AutoFilterCondition.Contains

        Next
        DiseñoGrid.AlternarColorEnFilas(vwActualizarPPCP)



    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chboxSeleccionarTodo.CheckedChanged
        Dim NumeroFilas As Integer = 0
        Try

            Cursor = Cursors.WaitCursor
            NumeroFilas = vwActualizarPPCP.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                vwActualizarPPCP.SetRowCellValue(vwActualizarPPCP.GetVisibleRowHandle(index), "Seleccionar", chboxSeleccionarTodo.Checked)
                lblNumFiltrados.Text = CDbl(vwActualizarPPCP.RowCount.ToString()).ToString("n0")
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function ObtenerProductoEstilosSeleccionados() As String
        Dim NumeroFilas As Integer = vwActualizarPPCP.DataRowCount
        Dim productoEstiloSeleccionados As String = String.Empty


        Cursor = Cursors.WaitCursor
        NumeroFilas = vwActualizarPPCP.DataRowCount
        For index As Integer = 0 To NumeroFilas Step 1

            If CBool(vwActualizarPPCP.GetRowCellValue(vwActualizarPPCP.GetVisibleRowHandle(index), "Seleccionar")) = True Then
                ContadorArticulos = ContadorArticulos + 1
                lblNumFiltrados.Text = CDbl(vwActualizarPPCP.RowCount.ToString()).ToString("n0")


                If productoEstiloSeleccionados <> "" Then
                    productoEstiloSeleccionados += ","
                End If


                productoEstiloSeleccionados += vwActualizarPPCP.GetRowCellValue(vwActualizarPPCP.GetVisibleRowHandle(index), "ProductoEstiloId").ToString
                NumeroFilas = vwActualizarPPCP.DataRowCount

            End If
        Next

        Cursor = Cursors.Default
        Return productoEstiloSeleccionados
    End Function


    Private Sub GenerarFormato(ByVal NaveIdSAY As Integer, ByVal ProductoEstiloSeleccionados As String)

        Dim objBU As New ColeccionNaveBU
        Dim MasterFormatoCostos As New DataSet("MasterFormato")
        Dim dtActualizarColecciones As New DataTable("ActualizarColecciones")
        Dim RutaMovimiento As String = String.Empty
        Dim idNaveDesarrolla As Integer = 0
        Dim idNAsignada As Integer = 0
        'Dim dsActualizarColecciones As New DataSet("dsActualizarColecciones")

        RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\ACTUALIZACIÓN"



        Try
            Cursor = Cursors.WaitCursor


            dtActualizarColecciones = objBU.CrearReporteActualizarCostos(NaveIdSAY, ProductoEstiloSeleccionados)

            If dtActualizarColecciones.Rows.Count > 0 Then
                Dim objBUReporte As New Framework.Negocios.ReportesBU
                Dim EntidadReporte As Entidades.Reportes

                MasterFormatoCostos.Tables.Add(dtActualizarColecciones)

                EntidadReporte = objBUReporte.LeerReporteporClave("PROG_CS_AC")
                Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" + EntidadReporte.Pnombre + ".mrt"
                My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)


                Dim reporte As New StiReport()



                idNAsignada = dtActualizarColecciones.Rows(0).Item("IdNaveSay")

                idNaveDesarrolla = objBU.ObtenerNaveDesarrolla(ProductoEstiloSeleccionados)

                reporte.Load(archivo)
                reporte.Compile()
                'reporte("MovimeintoColeccionCostos") = dsActualizarColecciones
                reporte("MasterFormato") = "MasterFormato"
                reporte("logo") = Tools.Controles.ObtenerLogoNave(idNAsignada)
                reporte("log") = Tools.Controles.ObtenerLogoNave(idNaveDesarrolla)
                reporte("NombreNave") = cmbNaveOrigen.Text
                'reporte("gerente") =
                reporte("fecha") = FormatDateTime(Date.Now, vbLongDate)
                'reporte("ColeccionSAY") =
                reporte("fechalarga") = Date.Now.ToLongDateString().ToString()
                'If Existe = True Then
                '    reporte("TipoMovimiento") = "DUPLICIDAD"
                'Else
                '    reporte("TipoMovimiento") = "ASIGNACIÓN"
                'End If

                reporte.Dictionary.Clear()
                reporte.RegData(MasterFormatoCostos)
                reporte.Dictionary.Synchronize()
                reporte.Render()
                formatoExcel.ExportObjectFormatting = True
                StiOptions.Export.Excel.ShowGridLines = False

                NombreNave = cmbNaveOrigen.Text

                FechaGeneracionExcel = Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + "_" + Now.Hour.ToString + Now.Minute.ToString
                If FCorrida <> "" Then
                    reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato Actualización Costos " + NombreNave + " " + coleccion(0) + " " + FCorrida + " " + FechaGeneracionExcel + ".xls")


                Else
                    reporte.ExportDocument(StiExportFormat.Excel, RutaMovimiento + "\Formato Actualización Costos " + NombreNave + " " + coleccion(0) + " " + FechaGeneracionExcel + ".xls")

                    'RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\ACTUALIZACIÓN"
                    'Cursor = Cursors.Default
                    'objExito.mensaje = "Datos guardados correctamente en Mis Documentos. "
                    'objExito.ShowDialog()
                    'Me.DialogResult = DialogResult.OK

                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        grdActualizarPPCP.DataSource = Nothing
        cmbNaveOrigen.SelectedIndex = 0
        cmbNaveOrigen.Enabled = True
        cmbMarca.SelectedIndex = 0
        grdColeccion.DataSource = listaInicial
        grdCorrida.DataSource = listaInicial

    End Sub


    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Try
            If vwActualizarPPCP.DataRowCount > 0 Then

                ContadorArticulos = 0
                Existe = False
                Dim RutaMovimiento As String = String.Empty
                Dim objBU As New ColeccionNaveBU
                Dim dtResultado As New DataTable

                ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()

                If ProductoEstiloSeleccionados <> "" Then



                    RutaMovimiento = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\MovimientoColeccionesEXCEL\ACTUALIZACIÓN"

                End If

                If Not System.IO.Directory.Exists(RutaMovimiento) Then
                    Directory.CreateDirectory(RutaMovimiento)
                End If

                GenerarFormato(IdNaveSay, ProductoEstiloSeleccionados)
                Cursor = Cursors.Default
                objExito.mensaje = "Datos guardados correctamente. "
                objExito.ShowDialog()
                Me.DialogResult = DialogResult.OK


                Exit Sub
            End If





        Catch ex As Exception


            Cursor = Cursors.Default
        End Try


    End Sub





    Private Sub cmbNaveOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNaveOrigen.SelectedIndexChanged
        If cmbNaveOrigen.SelectedIndex > 0 Then
            IdNaveSay = cmbNaveOrigen.SelectedValue
            cmbMarca.Enabled = True
            llenarMarcas()

        Else
            cmbMarca.Enabled = False
        End If
    End Sub


    Public Sub LlenarTablaArticulos()
        Dim objPBU As New Programacion.Negocios.ColeccionNaveBU
        Dim dtConsultaArticulosNoAsignados As DataTable
        Dim grdActualizar As New UltraGrid

        dtConsultaArticulosNoAsignados = objPBU.ObtieneArticulosNoAsignadosPorNave(IdNaveSay, marca, FColeccion)
        inicio = False
        grdActualizarPPCP.DataSource = dtConsultaArticulosNoAsignados
        ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
        DisenioGrid()
        lblNumFiltrados.Text = CDbl(vwActualizarPPCP.RowCount.ToString()).ToString("n0")
        cmbNaveOrigen.Enabled = False


    End Sub

    Public Sub LlenarTablaArticulosTallas()
        Dim objPBU As New Programacion.Negocios.ColeccionNaveBU
        Dim dtConsultaArticulosTallas As DataTable
        Dim grdActualizar As New UltraGrid


        dtConsultaArticulosTallas = objPBU.ObtieneArticulostallas(IdNaveSay, FColeccion, marca, FCorrida)
        inicio = False
        grdActualizarPPCP.DataSource = dtConsultaArticulosTallas
        ProductoEstiloSeleccionados = ObtenerProductoEstilosSeleccionados()
        DisenioGrid()
        lblNumFiltrados.Text = CDbl(vwActualizarPPCP.RowCount.ToString()).ToString("n0")
        cmbNaveOrigen.Enabled = False


    End Sub
    Private Sub btnLimColeccion_Click(sender As Object, e As EventArgs) Handles btnLimColeccion.Click
        grdColeccion.DataSource = listaInicial
    End Sub

    Private Sub btnLimCorrida_Click(sender As Object, e As EventArgs) Handles btnLimCorrida.Click
        grdCorrida.DataSource = listaInicial
    End Sub

    Private Sub grdColeccion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdColeccion.InitializeLayout
        grid_diseño(grdColeccion)
        grdColeccion.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Colección"
    End Sub

    Private Sub grdColeccion_KeyDown(sender As Object, e As KeyEventArgs) Handles grdColeccion.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdColeccion.DeleteSelectedRows(False)
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
            End If

            If col.DataType.Name.ToString.Equals("String") Then
                col.CellAppearance.TextHAlign = HAlign.Left
            End If
        Next
    End Sub
    Private Sub grdCorrida_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles grdCorrida.InitializeLayout
        grid_diseño(grdCorrida)
        grdCorrida.DisplayLayout.Bands(0).Columns(0).Header.Caption = "Corrida"
    End Sub

    Private Sub grdCorrida_KeyDown(sender As Object, e As KeyEventArgs) Handles grdCorrida.KeyDown
        If Not e.KeyCode = Keys.Delete Then Return
        grdCorrida.DeleteSelectedRows(False)
    End Sub

    Private Sub btnAgregarColeccion_Click(sender As Object, e As EventArgs) Handles btnAgregarColeccion.Click
        Dim listado As New FiltrosActualizarCostos
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 1
        listado.NaveSayId = cmbNaveOrigen.SelectedValue
        listado.Marca = cmbMarca.Text

        For Each row As UltraGridRow In grdColeccion.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdColeccion.DataSource = listado.listParametros
        With grdColeccion
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Colección"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Sub btnAgregarCorrida_Click(sender As Object, e As EventArgs) Handles btnAgregarCorrida.Click
        Dim listado As New FiltrosActualizarCostos
        Dim listaParametroID As New List(Of String)

        listado.tipo_busqueda = 2
        listado.NaveSayId = cmbNaveOrigen.SelectedValue
        listado.Marca = cmbMarca.Text
        listado.Colecciones = ObtenerFiltrosGrid(grdColeccion)
        For Each row As UltraGridRow In grdCorrida.Rows
            Dim parametro As String = row.Cells(0).Text
            listaParametroID.Add(parametro)
        Next
        listado.listaParametroID = listaParametroID
        listado.ShowDialog(Me)
        If Not listado.DialogResult = Windows.Forms.DialogResult.OK Then Return
        If listado.listParametros.Rows.Count = 0 Then Return
        grdCorrida.DataSource = listado.listParametros
        With grdCorrida
            .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Corrida"
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
        End With
    End Sub

    Private Function ObtenerFiltrosGrid(ByVal grid As UltraGrid) As String
        Dim Resultado As String = String.Empty
        For Each row As UltraGridRow In grid.Rows
            If row.Index = 0 Then
                Resultado += "" + Replace(row.Cells(0).Text, ",", "") + ""
            Else
                Resultado += "," + Replace(row.Cells(0).Text, ",", "") + ""
            End If
        Next
        Return Resultado
    End Function

    Private Function ObtenerColorEstatus(ByVal Estatus As String) As Color
        Dim TipoColor As Color = Color.Empty

        If Estatus = "VDES" Then
            TipoColor = pnlDescontinuado.BackColor
        ElseIf Estatus = "V1Y15" Then
            TipoColor = pnlde1a15dias.BackColor
        ElseIf Estatus = "V+15" Then
            TipoColor = pnlMayora15dias.BackColor
        Else
            TipoColor = Color.Empty
        End If

        Return TipoColor

    End Function

    Private Sub vwActualizarppcp_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles vwActualizarPPCP.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
    Private Sub vwActualizarppcp_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles vwActualizarPPCP.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        If vwActualizarPPCP.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If

    End Sub

    Private Sub gridview3_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles GridView3.CustomDrawCell
        Dim currentView As GridView = CType(sender, GridView)
        'If (e.RowHandle = currentView.FocusedRowHandle) Then Return


        If GridView3.DataRowCount > 0 Then
            If e.Column.FieldName = "ST" Then
                e.Appearance.BackColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
                e.Appearance.ForeColor = ObtenerColorEstatus(currentView.GetRowCellValue(e.RowHandle, "ST"))
            End If
        End If

    End Sub


    Private Sub desabilitarcorrida(sender As Object, e As EventArgs) Handles chFiltarCorrida.CheckedChanged
        If chFiltarCorrida.Checked = True Then
            btnAgregarCorrida.Enabled = True
            btnLimCorrida.Enabled = True

        ElseIf chFiltarCorrida.Checked = False Then
            btnAgregarCorrida.Enabled = False
            btnLimCorrida.Enabled = False
        End If
    End Sub

    Private Sub cmbmarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
        If cmbMarca.SelectedIndex > 0 Then
            marca = cmbMarca.Text

        End If
    End Sub

    Private Sub vwMovimientosPPCP_CustomDrawRowIndicator(sender As Object, e As Views.Grid.RowIndicatorCustomDrawEventArgs)
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        pnlActualizarPPCP.Visible = False
        pnlEncabezadoExpander.AutoSize = True
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        pnlActualizarPPCP.Visible = True
        pnlEncabezadoExpander.AutoSize = True
    End Sub
End Class