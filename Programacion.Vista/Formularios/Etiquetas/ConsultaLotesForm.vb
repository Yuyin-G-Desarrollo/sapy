Imports Tools
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Drawing.Printing
Imports System.Globalization
Imports System.Data
Imports System.Data.DataTable
Imports System.Data.DataSet
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.ReportGeneration
Imports Stimulsoft.Report
Imports System.IO

Public Class ConsultaLotesForm

    Dim objBU As New Programacion.Negocios.EtiquetasBU
    Dim CarpetaUbicacionArchivos As String = "C:\SAY\"
    Dim RutaArchivoEtiquetas As String = "C:\SAY\\ETIQUETAS.txt"
    Dim RutaArchivoBat As String = "C:\SAY\\Etiquetas.bat"
    Dim DTImpresoras As DataTable

    Private Sub ConsultaLotesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim NombreEquipo As String = String.Empty
        CargarNaves()
        CargarImpresoras()
        ObtenerImpresoraAsignada()
        dtmFechaPrograma.Value = Date.Now
        chkSeleccionar.Checked = False
        CargarNaves()
        PermisosImpresionPrueba()

        NombreEquipo = My.Computer.Name
    End Sub

    Private Sub ObtenerImpresoraAsignada()
        Dim dtInformacionImpresora As DataTable
        Dim NombreImpresora As String = String.Empty
        Dim ImpresoraId As Integer = 0
        Dim Index As Integer = 0

        Try
            dtInformacionImpresora = objBU.ConsultarImpresoraEquipo(My.Computer.Name)

            If IsNothing(dtInformacionImpresora) = False Then
                If dtInformacionImpresora.Rows.Count > 0 Then
                    ImpresoraId = dtInformacionImpresora.Rows(0).Item(0)
                    NombreImpresora = dtInformacionImpresora.Rows(0).Item(1)
                    If ImpresoraId > 0 Then
                        Index = cmbImpresoras.FindString(NombreImpresora)
                        cmbImpresoras.SelectedIndex = Index
                    End If
                End If
            End If
        Catch ex As Exception
            show_message("Error", "Ocurrio un error al cargar la impresora por default.")
        End Try
    End Sub

    Private Sub CargarNaves()
        Dim DTNAves As DataTable
        DTNAves = objBU.ConsultarNavesProduccion()
        DTNAves.Rows.InsertAt(DTNAves.NewRow, 0)
        cmbNave.DataSource = DTNAves
        cmbNave.DisplayMember = "Nave"
        cmbNave.ValueMember = "NaveSICYID"
    End Sub

    Private Sub CargarImpresoras()
        DTImpresoras = objBU.ListaImpresoras()
        cmbImpresoras.DataSource = DTImpresoras
        cmbImpresoras.DisplayMember = "Nombre"
        cmbImpresoras.ValueMember = "IdImpresora"
    End Sub

    Private Sub btnImprimirEtiquetas_Click(sender As Object, e As EventArgs) Handles btnImprimirEtiquetas.Click
        Dim lista As New List(Of Integer)
        If ViewConsultaDeLotes.DataRowCount > 0 Or IIf(IsDBNull(cmbNave.SelectedValue), 0, cmbNave.SelectedValue) = 4 Then
            For i As Integer = 0 To ViewConsultaDeLotes.DataRowCount - 1
                lista.Add(CInt(IIf(IsDBNull(ViewConsultaDeLotes.GetRowCellValue(i, "lote")), 0, ViewConsultaDeLotes.GetRowCellValue(i, "lote"))))
            Next i
            Dim f As New ImpresionEtiquetasForm
            f.idNave = cmbNave.SelectedValue
            f.Nave = cmbNave.Text.Trim
            f.Lista = lista
            f.fechaPrograma = dtmFechaPrograma.Value
            f.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            f.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            f.Accion = 1
            f.ShowDialog()
        Else
            show_message("Advertencia", "Debes seleccionar datos de un programa.")
        End If

    End Sub



    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
        If cmbNave.SelectedIndex > 0 Then
            CargarInformacion()
            chkSeleccionar.Checked = False
        Else
            show_message("Advertencia", "No se ha seleccionado una nave.")
        End If
    End Sub


    Private Sub CargarInformacion()
        Dim dtinformacion As DataTable

        Try
            Cursor = Cursors.WaitCursor
            grdConsultaLotes.DataSource = Nothing

            dtinformacion = objBU.ConsultarImpresionLotesPorPrograma(cmbNave.SelectedValue, dtmFechaPrograma.Value.ToShortDateString())
            grdConsultaLotes.DataSource = dtinformacion
            DiseñoGrid(ViewConsultaDeLotes)
            'lblFechaUltimaActualizacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()
            'lblFechaUltimaActualizacion.Visible = True
            Cursor = Cursors.Default
        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        Finally
            Cursor = Cursors.Default
            lblTotalLotes.Text = dtinformacion.Rows.Count
        End Try

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

        'AgregarColumna(grid, "año", "Año", False, True, Nothing, 60, False, False, HAlign.Right)
        'AgregarColumna(grid, "nave", "Nave", False, False, Nothing, 30, False, False, HAlign.Right)
        'AgregarColumna(grid, "lote", "Lote", False, True, Nothing, 40, False, False, HAlign.Right)
        'AgregarColumna(grid, "IdModelo", "IdModelo", False, True, Nothing, 80, False, False, HAlign.Right)
        'AgregarColumna(grid, "IdCodigo", "IdCodigo", False, True, Nothing, 100, False, False, HAlign.Left)
        'AgregarColumna(grid, "Coleccion", "Coleccion", False, True, Nothing, 120, False, False, HAlign.Left)
        'AgregarColumna(grid, "talla", "Talla", False, True, Nothing, 70, False, False, HAlign.Right)
        'AgregarColumna(grid, "color", "Color", False, True, Nothing, 80, False, False, HAlign.Left)
        'AgregarColumna(grid, "pares", "Pares", False, False, Nothing, 60, True, False, HAlign.Right, , , , SummaryType.Sum)
        'AgregarColumna(grid, "cortador", "Cortador", False, True, Nothing, 90, , , HAlign.Left)
        'AgregarColumna(grid, "cortador_Forro", "Cortador " & vbCrLf & " Forro", False, True, Nothing, 90, , , HAlign.Left)
        'AgregarColumna(grid, "Cliente_texto", "Cliente", True, True, Nothing, 200, , , HAlign.Left)
        'AgregarColumna(grid, "cliente_Nombre", "Cliente", False, True, Nothing, 200, , , HAlign.Left)
        'AgregarColumna(grid, "TotalPares", "Total " & vbCrLf & " Pares", True, True, Nothing, 60, True, , HAlign.Right)
        'AgregarColumna(grid, "TotalLotes", "Total " & vbCrLf & " Lotes", True, True, Nothing, 60, True, , HAlign.Right)
        'AgregarColumna(grid, "primer_lote", "Primer " & vbCrLf & " Lote", True, True, Nothing, 60, False, , HAlign.Right)
        'AgregarColumna(grid, "ultimo_lote", "Ultimo " & vbCrLf & " Lote", True, True, Nothing, 60, False, , HAlign.Right)

        Dim band As UltraGridBand = grid.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub




    Private Sub DiseñoGrid(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView)
        grid.IndicatorWidth = 40

        grid.OptionsView.ColumnAutoWidth = False
        grid.BestFitColumns()
        grid.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True


        Tools.DiseñoGrid.AlinearTextoEncabezadoColumnas(grid)
        Tools.DiseñoGrid.AlternarColorEnFilas(grid)

        With grid
            .Columns.ColumnByFieldName("año").Visible = True
            .Columns.ColumnByFieldName("nave").Visible = False
            .Columns.ColumnByFieldName("lote").Visible = True
            .Columns.ColumnByFieldName("IdModelo").Visible = True
            .Columns.ColumnByFieldName("IdCodigo").Visible = True
            .Columns.ColumnByFieldName("Coleccion").Visible = True
            .Columns.ColumnByFieldName("talla").Visible = True
            .Columns.ColumnByFieldName("color").Visible = True
            .Columns.ColumnByFieldName("pares").Visible = True
            .Columns.ColumnByFieldName("cortador").Visible = True
            .Columns.ColumnByFieldName("cortador_Forro").Visible = True
            .Columns.ColumnByFieldName("Cliente_texto").Visible = True
            .Columns.ColumnByFieldName("cliente_Nombre").Visible = True
            .Columns.ColumnByFieldName("TotalPares").Visible = False
            .Columns.ColumnByFieldName("TotalLotes").Visible = False
            .Columns.ColumnByFieldName("primer_lote").Visible = False
            .Columns.ColumnByFieldName("ultimo_lote").Visible = False
            .Columns.ColumnByFieldName("Usuario").Visible = True
            .Columns.ColumnByFieldName("FechaImpresion").Visible = True
            .Columns.ColumnByFieldName("NumeroImpresiones").Visible = True



            .Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns.ColumnByFieldName("TotalLotes").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            .Columns.ColumnByFieldName("pares").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

            .Columns.ColumnByFieldName("nave").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("IdModelo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("IdCodigo").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Coleccion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("talla").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("cortador").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Cliente_texto").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("cliente_Nombre").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("Usuario").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("FechaImpresion").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains
            .Columns.ColumnByFieldName("NumeroImpresiones").OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains

            .Columns.ColumnByFieldName("TotalPares").DisplayFormat.FormatString = "N0"
            .Columns.ColumnByFieldName("TotalLotes").DisplayFormat.FormatString = "N0"
            .Columns.ColumnByFieldName("pares").DisplayFormat.FormatString = "N0"

            .Columns.ColumnByFieldName(" ").Width = 30
            .Columns.ColumnByFieldName("año").Width = 45
            .Columns.ColumnByFieldName("nave").Width = 60
            .Columns.ColumnByFieldName("lote").Width = 45
            .Columns.ColumnByFieldName("IdModelo").Width = 60
            .Columns.ColumnByFieldName("IdCodigo").Width = 100
            .Columns.ColumnByFieldName("Coleccion").Width = 180
            .Columns.ColumnByFieldName("talla").Width = 60
            .Columns.ColumnByFieldName("color").Width = 90
            .Columns.ColumnByFieldName("pares").Width = 50
            .Columns.ColumnByFieldName("cortador").Width = 70
            .Columns.ColumnByFieldName("cortador_Forro").Width = 70
            .Columns.ColumnByFieldName("Cliente_texto").Width = 200
            .Columns.ColumnByFieldName("cliente_Nombre").Width = 200
            .Columns.ColumnByFieldName("TotalPares").Width = 45
            .Columns.ColumnByFieldName("TotalLotes").Width = 45
            .Columns.ColumnByFieldName("primer_lote").Width = 45
            .Columns.ColumnByFieldName("ultimo_lote").Width = 45
            .Columns.ColumnByFieldName("Usuario").Width = 70
            .Columns.ColumnByFieldName("FechaImpresion").Width = 80
            .Columns.ColumnByFieldName("NumeroImpresiones").Width = 90

            .Columns.ColumnByFieldName("año").Caption = "Año"
            .Columns.ColumnByFieldName("nave").Caption = "Nave"
            .Columns.ColumnByFieldName("lote").Caption = "Lote"
            .Columns.ColumnByFieldName("IdModelo").Caption = "Modelo"
            .Columns.ColumnByFieldName("IdCodigo").Caption = "Codigo SICY"
            .Columns.ColumnByFieldName("Coleccion").Caption = "Colección"
            .Columns.ColumnByFieldName("talla").Caption = "Talla"
            .Columns.ColumnByFieldName("color").Caption = "Color"
            .Columns.ColumnByFieldName("pares").Caption = "Pares"
            .Columns.ColumnByFieldName("cortador").Caption = "Cortador"
            .Columns.ColumnByFieldName("cortador_Forro").Caption = "Cortador " & vbCrLf & "Forro"
            .Columns.ColumnByFieldName("Cliente_texto").Caption = "Cliente"
            .Columns.ColumnByFieldName("cliente_Nombre").Caption = "Descripción"
            .Columns.ColumnByFieldName("TotalPares").Caption = "Total Pares"
            .Columns.ColumnByFieldName("TotalLotes").Caption = "Total Lotes"
            .Columns.ColumnByFieldName("primer_lote").Caption = "Primer " & vbCrLf & "Lote"
            .Columns.ColumnByFieldName("ultimo_lote").Caption = "Ultimo " & vbCrLf & "Lote"
            .Columns.ColumnByFieldName("Usuario").Caption = "Usuario"
            .Columns.ColumnByFieldName("FechaImpresion").Caption = "Fecha ult." & vbCrLf & " Impresión"
            .Columns.ColumnByFieldName("NumeroImpresiones").Caption = "Número " & vbCrLf & " Impresiones"

            .Columns.ColumnByFieldName("año").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("nave").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("lote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("talla").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("color").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("pares").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("cortador").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("cortador_Forro").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Cliente_texto").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("cliente_Nombre").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("TotalLotes").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("primer_lote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("ultimo_lote").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("Usuario").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowSize = True
            .Columns.ColumnByFieldName("NumeroImpresiones").OptionsColumn.AllowSize = True

            .Columns.ColumnByFieldName("año").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("nave").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("lote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("IdModelo").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("IdCodigo").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Coleccion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("talla").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("color").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("pares").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("cortador").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("cortador_Forro").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Cliente_texto").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("cliente_Nombre").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("TotalPares").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("TotalLotes").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("primer_lote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("ultimo_lote").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("Usuario").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("FechaImpresion").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("NumeroImpresiones").OptionsColumn.AllowEdit = False
            .Columns.ColumnByFieldName("F.Imp.EtiqLengua").OptionsColumn.AllowEdit = False

            .OptionsView.ShowFooter = GroupFooterShowMode.VisibleAlways


            If IsNothing(.Columns("TotalPares").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalPares")) = True Then
                .Columns("TotalPares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalPares", "{0:N0}")
                Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
                item.FieldName = "TotalPares"
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0}"
                .GroupSummary.Add(item)
            End If

            If IsNothing(.Columns("TotalLotes").Summary.FirstOrDefault(Function(x) x.FieldName = "TotalLotes")) = True Then
                .Columns("TotalLotes").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalLotes", "{0:N0}")
                Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
                item2.FieldName = "TotalLotes"
                item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item2.DisplayFormat = "{0}"
                .GroupSummary.Add(item2)
            End If

            If IsNothing(.Columns("pares").Summary.FirstOrDefault(Function(x) x.FieldName = "pares")) = True Then
                .Columns("pares").Summary.Add(DevExpress.Data.SummaryItemType.Sum, "pares", "{0:N0}")
                Dim item2 As GridGroupSummaryItem = New GridGroupSummaryItem()
                item2.FieldName = "pares"
                item2.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item2.DisplayFormat = "{0}"
                .GroupSummary.Add(item2)
            End If

        End With


    End Sub


    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged
        Dim NumeroFilas As Integer = 0

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewConsultaDeLotes.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                ViewConsultaDeLotes.SetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), " ", chkSeleccionar.Checked)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            If cmbNave.SelectedIndex <= 0 Then
                show_message("Advertencia", "No se ha seleccionado una nave.")
            Else
                If ViewConsultaDeLotes.DataRowCount = 0 Then
                    show_message("Advertencia", "No hay datos para imprimir.")
                Else
                    If ValidarLotesSeleccionados() = False Then
                        show_message("Advertencia", "No se han seleccionado lotes para imprimir.")
                    Else
                        If ValidarInformacionEtiquetas() = False Then
                            ' show_message("Advertencia", "Hay información incompleta de las etiquetas.")
                        Else
                            If ValidarTallasExtranjerasPorLote() = True Then
                                GenerarImpresion()
                                CargarInformacion()
                                chkSeleccionar.Checked = False
                            Else
                                show_message("Advertencia", "Hay información incompleta de las tallas extranjeras.")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            show_message("Advertencia", "Ocurrio un error al cargar la información.")
        End Try
    End Sub

    ''' <summary>
    ''' Valida que la informacion de la etiqueta este completa
    ''' </summary>
    ''' <returns>TRUE => Si la informacion esta completa, FALSE => Si esta incompleta.</returns>
    ''' <remarks></remarks>
    Private Function ValidarInformacionEtiquetas() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim HayLotesSeleccionados As Boolean = False
        Dim LotesSeleccionados As String = String.Empty
        Dim NaveSeleccionada As Integer = 0
        Dim AñoPrograma As Integer = 0
        Dim dtInformacion As New DataTable
        Dim InformacionIncompleta As Boolean = True
        Dim EtiquetasIncompletas As String = String.Empty
        Dim VentanaDetalles As New VistaDetallesImpresionEtiquetasForm
        Dim dtZPLCapturados As New DataTable
        Dim FaltaZPLPorCargar As Integer = 0
        Dim ClientesPendienteCargarZPL As String = String.Empty

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewConsultaDeLotes.DataRowCount
            LotesSeleccionados = ObtenerLotesSeleccionados()
            NaveSeleccionada = cmbNave.SelectedValue
            AñoPrograma = dtmFechaPrograma.Value.Year

            'Validar que las etiquetas Yuyin esten autorizadas para su impresión
            If objBU.ValidarEtiquetasYUYIN(LotesSeleccionados, AñoPrograma, NaveSeleccionada) = False Then
                show_message("Advertencia", "Las etiquetas de Lote, Amarre o Par no han sido autorizadas para su impresión.")
                InformacionIncompleta = False
                Return InformacionIncompleta
            End If


            dtZPLCapturados = objBU.ValidarZplCargado(LotesSeleccionados, AñoPrograma, NaveSeleccionada)

            If dtZPLCapturados.Rows.Count > 0 Then
                FaltaZPLPorCargar = dtZPLCapturados.Rows(0).Item(0)
                For Each Fila As DataRow In dtZPLCapturados.Rows
                    If ClientesPendienteCargarZPL = String.Empty Then
                        ClientesPendienteCargarZPL = Fila.Item(1).ToString
                    Else
                        ClientesPendienteCargarZPL &= "," & Fila.Item(1).ToString
                    End If
                Next
            End If

            If FaltaZPLPorCargar > 0 Then
                show_message("Advertencia", "Falta por cargar ZPL del cliente: " & ClientesPendienteCargarZPL & ".")
                InformacionIncompleta = False
            Else
                dtInformacion = objBU.ValidaInformacionImpresionLote(LotesSeleccionados, AñoPrograma, NaveSeleccionada)
                If dtInformacion.Rows.Count > 0 Then
                    If dtInformacion.AsEnumerable().Where(Function(x) x.Item("ResultadoValidacion") > 0).Count > 0 Then
                        InformacionIncompleta = False
                    End If
                End If

                If InformacionIncompleta = False Then
                    Dim Etiquetas = dtInformacion.AsEnumerable.Where(Function(y) y.Item("ResultadoValidacion") > 0).Select(Function(x) x.Item("EtiquetaId")).Distinct()
                    For Each Fila As Integer In Etiquetas
                        If EtiquetasIncompletas = String.Empty Then
                            EtiquetasIncompletas = Fila.ToString
                        Else
                            EtiquetasIncompletas &= "," & Fila.ToString
                        End If
                    Next

                    VentanaDetalles.Lotes = ObtenerLotesSeleccionados()
                    VentanaDetalles.NaveSICYId = cmbNave.SelectedValue
                    VentanaDetalles.FechaPrograma = dtmFechaPrograma.Value
                    VentanaDetalles.EtiquetaId = EtiquetasIncompletas
                    VentanaDetalles.Año = dtmFechaPrograma.Value.Year
                    VentanaDetalles.ImpresoraId = cmbImpresoras.SelectedValue
                    VentanaDetalles.Show()

                End If

                If InformacionIncompleta = False Then
                    show_message("Advertencia", "Hay información incompleta para la impresión de etiquetas.")
                End If

            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try
        Return InformacionIncompleta
    End Function




    Private Function ValidarLotesSeleccionados() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim HayLotesSeleccionados As Boolean = False
        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewConsultaDeLotes.DataRowCount

            For index As Integer = 0 To NumeroFilas Step 1
                If ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), " ") = True Then
                    HayLotesSeleccionados = True
                End If
            Next

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
        End Try
        Return HayLotesSeleccionados
    End Function


    Private Sub GenerarImpresion()
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim dtInformacionEtiquetas As New DataTable
        Dim LotesSeleccionados As String = String.Empty
        Dim ImpresoraSeleccionada As Integer = 0
        Dim NaveSeleccionada As Integer = 0
        Dim AñoPrograma As Integer = 0
        Dim UsuarioID As Integer = 0
        Dim FechaPrograma As Date
        Dim EtiquetasAImprimir As String = String.Empty
        Dim HayEtiquetasDiferenteTamaño As Integer = 0
        Dim dtInformacionEtiquetasDiferenteTamaño As New DataTable
        Dim VentanaEtiquetasDiferenteTamaño As New ListadoEtiquetasDiferenteTamañoForm
        Dim LotesSeleccionadosBatta As String = String.Empty
        Dim LotesSeleccionadosCoppel As String = String.Empty

        Try

            Cursor = Cursors.WaitCursor
            LotesSeleccionados = ObtenerLotesSeleccionadosSinHermanosBattayCoppel()
            ImpresoraSeleccionada = cmbImpresoras.SelectedValue
            NaveSeleccionada = cmbNave.SelectedValue
            AñoPrograma = dtmFechaPrograma.Value.Year
            UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
            FechaPrograma = CDate(dtmFechaPrograma.Value)
            LotesSeleccionadosBatta = ObtenerLotesSeleccionadosHermanosBatta()
            LotesSeleccionadosCoppel = ObtenerLotesSeleccionadosCoppel()


            If LotesSeleccionados <> String.Empty Then
                If DTImpresoras.AsEnumerable().Where(Function(x) x.Item("IdImpresora") = ImpresoraSeleccionada).Select(Function(y) y.Item("Software")).FirstOrDefault() <> "NICELABEL" Then
                    dtInformacionEtiquetas = objBU.ImpresionEtiquetasLote(LotesSeleccionados, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year, ImpresoraSeleccionada, UsuarioID, FechaPrograma)
                    If dtInformacionEtiquetas.Rows.Count = 0 Then
                        show_message("Advertencia", "No hay información de los lotes")
                        Return
                    End If

                    'Etiquetas de diferente tamaño
                    HayEtiquetasDiferenteTamaño = CInt(dtInformacionEtiquetas.Rows(0).Item(1))
                    If HayEtiquetasDiferenteTamaño > 0 Then
                        VentanaEtiquetasDiferenteTamaño.Lotes = LotesSeleccionados
                        VentanaEtiquetasDiferenteTamaño.Año = AñoPrograma
                        VentanaEtiquetasDiferenteTamaño.FechaPrograma = FechaPrograma
                        VentanaEtiquetasDiferenteTamaño.NaveSICYID = NaveSeleccionada
                        VentanaEtiquetasDiferenteTamaño.Show()
                        show_message("Advertencia", "Hay etiquetas de diferente tamaño. Imprimir desde opciones avanzadas.")
                    End If

                    strStreamW = CrearRutasArchivo(CarpetaUbicacionArchivos, RutaArchivoEtiquetas)

                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

                    'Escribir la informacion de las etiquetas en el archivo
                    For Each FILA As DataRow In dtInformacionEtiquetas.Rows
                        EtiquetasAImprimir &= FILA.Item(0)
                    Next
                    strStreamWriter.WriteLine(EtiquetasAImprimir)

                    strStreamWriter.Close()
                    'Generar archivo bat para enviar a imprimir las etiquetas
                    GenerarArchivoBat(LotesSeleccionados, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year)
                    'Guardar Bitacora de Impresion
                    objBU.GuardarBitacoraImpresionLotes(LotesSeleccionados, cmbNave.SelectedValue, FechaPrograma, UsuarioID, AñoPrograma)
                    show_message("Exito", "Se ha enviado a imprimir.")
                Else
                    show_message("Advertencia", "No puede enviar a imprimir con la impresora seleccionada.")
                End If

            End If

            '***************************Etiquetas BATTA***********************************************
            If LotesSeleccionadosBatta <> String.Empty Then
                Dim dtValidacion As New DataTable
                Dim ModelosSinImagenform As New ValidacionImagenesBattaForm

                dtValidacion = objBU.ValidarImagenesBatta(LotesSeleccionadosBatta, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year)

                If dtValidacion.Rows.Count = 0 Then
                    If CopiarImagenesBatta(LotesSeleccionadosBatta, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year) = True Then
                        If DTImpresoras.AsEnumerable().Where(Function(x) x.Item("IdImpresora") = ImpresoraSeleccionada).Select(Function(y) y.Item("Software")).FirstOrDefault() = "NICELABEL" Then
                            dtInformacionEtiquetas = objBU.ImpresionEtiquetasBATTA(LotesSeleccionadosBatta, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year, ImpresoraSeleccionada, UsuarioID, FechaPrograma)
                            objBU.GuardarBitacoraImpresionLotes(LotesSeleccionadosBatta, cmbNave.SelectedValue, FechaPrograma, UsuarioID, AñoPrograma)
                        Else
                            'show_message("Advertencia", "Se debe de seleccionar una impresora a color para etiquetas Hermanos Batta.")
                        End If
                    End If
                Else
                    ModelosSinImagenform.dtModelosSinCargarImagen = dtValidacion
                    ModelosSinImagenform.ShowDialog()
                End If
            End If

            '***************************Etiquetas COPPEL***********************************************
            If LotesSeleccionadosCoppel <> String.Empty Then
                Dim dtValidacion As New DataTable
                Dim ModelosSinImagenform As New ValidacionImagenesBattaForm

                dtValidacion = objBU.ValidarImagenesCoppel(LotesSeleccionadosCoppel, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year)

                If dtValidacion.Rows.Count = 0 Then
                    If CopiarImagenesCoppel(LotesSeleccionadosCoppel, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year) = True Then
                        If DTImpresoras.AsEnumerable().Where(Function(x) x.Item("IdImpresora") = ImpresoraSeleccionada).Select(Function(y) y.Item("Software")).FirstOrDefault() = "NICELABEL" Then
                            dtInformacionEtiquetas = objBU.ImpresionEtiquetasCoppel(LotesSeleccionadosCoppel, cmbNave.SelectedValue, dtmFechaPrograma.Value.Year, ImpresoraSeleccionada, UsuarioID, FechaPrograma)
                            objBU.GuardarBitacoraImpresionLotes(LotesSeleccionadosCoppel, cmbNave.SelectedValue, FechaPrograma, UsuarioID, AñoPrograma)
                        Else
                            'show_message("Advertencia", "Se debe de seleccionar una impresora a color para etiquetas Coppel.")
                        End If
                    End If
                Else
                    ModelosSinImagenform.dtModelosSinCargarImagen = dtValidacion
                    ModelosSinImagenform.ShowDialog()
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try

    End Sub

    Private Function ObtenerLotesSeleccionados() As String
        Dim NumeroFilas As Integer = 0
        Dim LotesSeleccionados As String = String.Empty

        Try
            NumeroFilas = ViewConsultaDeLotes.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), " ")) = True Then
                    If LotesSeleccionados = String.Empty Then
                        LotesSeleccionados = ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                    Else
                        LotesSeleccionados &= "," & ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return LotesSeleccionados

    End Function

    Private Function CrearRutasArchivo(ByVal Carpeta As String, ByVal Archivo As String) As Stream
        Dim strStreamW As Stream = Nothing

        Try
            If System.IO.Directory.Exists(Carpeta) = False Then
                System.IO.Directory.CreateDirectory(Carpeta)
            End If

            If File.Exists(Archivo) Then
                File.Delete(Archivo)
                strStreamW = File.Create(Archivo)
            Else
                strStreamW = File.Create(Archivo)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        Return strStreamW

    End Function

    Private Sub GenerarArchivoBat(ByVal LotesSeleccionados As String, ByVal Nave As Integer, ByVal Año As Integer)
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String
        Dim dtArchivo As DataTable
        Dim ImpresoraId As Integer = 0


        Try
            Cursor = Cursors.WaitCursor
            ImpresoraId = cmbImpresoras.SelectedValue

            dtArchivo = objBU.ComandosImprimirEtiquetasSAY_V2(LotesSeleccionados, Nave, Año, ImpresoraId)

            If System.IO.Directory.Exists(CarpetaUbicacionArchivos) = False Then
                System.IO.Directory.CreateDirectory(CarpetaUbicacionArchivos)
            End If

            PathArchivo = RutaArchivoBat ' Se determina el nombre del archivo con la fecha actual

            'verificamos si existe el archivo
            If File.Exists(PathArchivo) Then
                File.Delete(PathArchivo)
                strStreamW = File.Create(PathArchivo)
            Else
                strStreamW = File.Create(PathArchivo) ' lo creamos
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura

            For Each FILA As DataRow In dtArchivo.Rows
                strStreamWriter.WriteLine(FILA.Item(0))
            Next

            strStreamWriter.Close() ' cerrar
            'Ejecutar el archivo bat
            Shell(RutaArchivoBat)
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Throw ex
            'show_message("Error", "Ocurrio un error al generar el archivo, vuelva a intentar.")
        End Try
    End Sub


    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
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
                    If ViewConsultaDeLotes.GroupCount > 0 Then
                        grdConsultaLotes.ExportToXlsx(.SelectedPath + "\Datos_ConsultaLotes_" + fecha_hora + ".xlsx")
                    Else
                        Dim exportOptions = New XlsxExportOptionsEx()
                        grdConsultaLotes.ExportToXlsx(.SelectedPath + "\Datos_ConsultaLotes_" + fecha_hora + ".xlsx")
                    End If
                    show_message("Exito", "Los datos se exportaron correctamente: " & "Datos_ConsultaLotes_" & fecha_hora.ToString() & ".xlsx")
                    .Dispose()
                    Process.Start(fbdUbicacionArchivo.SelectedPath + "\Datos_ConsultaLotes_" + fecha_hora + ".xlsx")
                End If
            End With
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub btnEtiquetaPruebas_Click(sender As Object, e As EventArgs) Handles btnEtiquetaPruebas.Click
        Dim f As New ImpresionEtiquetasForm
        Dim lista As New List(Of Integer)
        For i As Integer = 0 To ViewConsultaDeLotes.DataRowCount - 1
            lista.Add(CInt(IIf(IsDBNull(ViewConsultaDeLotes.GetRowCellValue(i, "lote")), 0, ViewConsultaDeLotes.GetRowCellValue(i, "lote"))))
        Next i

        f.idNave = IIf(IsDBNull(cmbNave.SelectedValue), 0, cmbNave.SelectedValue)
        f.Nave = cmbNave.Text.Trim
        f.Lista = lista
        f.fechaPrograma = dtmFechaPrograma.Value
        f.UsuarioID = Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid
        f.Usuario = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
        f.Accion = 2
        f.ShowDialog()
    End Sub


    Private Sub cmbNave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNave.SelectedIndexChanged
        grdConsultaLotes.DataSource = Nothing
    End Sub

    Private Sub dtmFechaPrograma_ValueChanged(sender As Object, e As EventArgs) Handles dtmFechaPrograma.ValueChanged
        grdConsultaLotes.DataSource = Nothing
    End Sub

    Private Function ValidarTallasExtranjerasPorLote() As Boolean
        Dim NumeroFilas As Integer = 0
        Dim HayLotesSeleccionados As Boolean = False
        Dim LotesSeleccionados As String = String.Empty
        Dim NaveSeleccionada As Integer = 0
        Dim AñoPrograma As Integer = 0
        Dim Resultado As Boolean = False

        Try
            Cursor = Cursors.WaitCursor
            NumeroFilas = ViewConsultaDeLotes.DataRowCount
            LotesSeleccionados = ObtenerLotesSeleccionados()
            NaveSeleccionada = cmbNave.SelectedValue
            AñoPrograma = dtmFechaPrograma.Value.Year

            If objBU.ValidarTallasExtranjerasPorLote(LotesSeleccionados, NaveSeleccionada, AñoPrograma, dtmFechaPrograma.Value) = False Then
                Resultado = False
            Else
                Resultado = True
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            Resultado = False
            Throw ex
        End Try
        Return Resultado


    End Function

    Private Sub GenerarImpresionHermanosBATTA(ByVal LotesBatta As String, ByVal NaveSICYID As Integer, ByVal AñoPrograma As Integer, ByVal ImpresoraId As Integer, ByVal UsuarioId As Integer, ByVal FechaPrograma As Date)
        Dim dtResultado As New DataTable
        Try
            dtResultado = objBU.ImpresionEtiquetasBATTA(LotesBatta, NaveSICYID, AñoPrograma, ImpresoraId, UsuarioId, FechaPrograma)

            If dtResultado.Rows.Count = 0 Then
                show_message("Advertencia", "No se envío a imprimir las etiquetas de Batta")
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString)
        End Try
    End Sub

    Private Function ObtenerLotesSeleccionadosHermanosBatta() As String
        Dim NumeroFilas As Integer = 0
        Dim LotesSeleccionados As String = String.Empty

        Try
            NumeroFilas = ViewConsultaDeLotes.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), " ")) = True Then
                    If ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "Cliente_texto").ToString().Contains("HERMANOS BATTA") = True Then
                        If LotesSeleccionados = String.Empty Then
                            LotesSeleccionados = ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                        Else
                            LotesSeleccionados &= "," & ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return LotesSeleccionados

    End Function

    Private Function ObtenerLotesSeleccionadosSinHermanosBattayCoppel() As String
        Dim NumeroFilas As Integer = 0
        Dim LotesSeleccionados As String = String.Empty

        Try
            NumeroFilas = ViewConsultaDeLotes.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), " ")) = True Then
                    If (ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "Cliente_texto").ToString().Contains("HERMANOS BATTA")) = False Then 'Or
                        '(ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "Cliente_texto").ToString().Contains("COPPEL")) = False Then
                        If LotesSeleccionados = String.Empty Then
                            LotesSeleccionados = ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                        Else
                            LotesSeleccionados &= "," & ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return LotesSeleccionados

    End Function


    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    'Dim ImagenModelo As String = String.Empty
    '    'Dim CarpetaDestino As String = "\\192.168.2.2\ImagenesBatta\"
    '    'Dim Archivo As String = String.Empty
    '    'Dim NombreArchivo As String = String.Empty

    '    'Try
    '    '    ImagenModelo = objBU.ObtenerLogoEmpresa("Programacion/Modelos/12032/THUMBNAIL_ANDREA BOSKI MOCASIN  7834 FLOR ENTERA negro.JPG")
    '    '    NombreArchivo = Path.GetFileName(ImagenModelo)
    '    '    Archivo = CarpetaDestino + NombreArchivo
    '    '    If File.Exists(Archivo) = False Then
    '    '        File.Copy(ImagenModelo, Archivo)
    '    '    End If
    '    'Catch ex As Exception
    '    '    show_message("Error", ex.Message.ToString())
    '    'End Try

    '    Dim dtValidacion As New DataTable
    '    Dim ModelosSinImagenform As New ValidacionImagenesBattaForm

    '    dtValidacion = objBU.ValidarImagenesBatta("3230,3235,3236,3237,3238,3239,3240,3241,3242,3278,3279,3012,3013,3014,3015,3016", 3, 2018)

    '    If dtValidacion.Rows.Count = 0 Then
    '        CopiarImagenesBatta("3230,3235,3236,3237,3238,3239,3240,3241,3242,3278,3279,3012,3013,3014,3015,3016", 3, 2018)
    '    Else
    '        ModelosSinImagenform.dtModelosSinCargarImagen = dtValidacion
    '        ModelosSinImagenform.ShowDialog()
    '    End If


    'End Sub

    Private Function CopiarImagenesBatta(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As Boolean
        Dim dtImagenes As New DataTable
        Dim CarpetaDestino As String = String.Empty
        Dim RutaImagenCompletaTemporal As String = String.Empty
        Dim NombreImagenTemporal As String = String.Empty
        Dim RutaCompletaSICY As String = String.Empty
        Dim RutaFTP As String = String.Empty
        Dim RutaCompletaLocal As String = String.Empty
        Dim Resultado As Boolean = False

        Try
            dtImagenes = objBU.ConsultaImagenesBatta(Lotes, NaveSICYID, Año)

            For Each Fila As DataRow In dtImagenes.Rows
                CarpetaDestino = Fila.Item("Carpeta")
                RutaImagenCompletaTemporal = Fila.Item("RutaNoExite")
                RutaFTP = Fila.Item("RutaFTP")

                NombreImagenTemporal = Path.GetFileName(RutaImagenCompletaTemporal)
                RutaCompletaSICY = CarpetaDestino + NombreImagenTemporal
                If File.Exists(RutaCompletaSICY) = False Then
                    RutaCompletaLocal = objBU.DescargarImagenBatta(RutaFTP)
                    File.Copy(RutaCompletaLocal, RutaCompletaSICY)
                End If
            Next

            Resultado = True
        Catch ex As Exception
            Resultado = False
            show_message("Advertencia", ex.Message.ToString())
        End Try

        Return Resultado

    End Function

    Private Sub btnReporteTallasLote_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub GenerarReporte()
        Dim objReporte As New Framework.Negocios.ReportesBU
        Dim entReporte As New Entidades.Reportes
        Dim dsClientesLote As New DataSet("dsClientesLote")
        Dim dtCliente As DataTable
        Dim dtTiendasClientes As DataTable
        Dim dtPartidasTienda As DataTable
        Dim dtEncabezadoTallas As DataTable
        Dim dtParesTalla As DataTable
        Dim ReporteTallasLote As New StiReport

        Dim dtClienteAux As DataTable
        Dim dtTiendasClientesAux As DataTable
        Dim dtPartidasTiendaAux As DataTable
        Dim dtEncabezadoTallasAux As DataTable
        Dim dtParesTallaAux As DataTable

        Dim dtPartidasPorTienda As DataTable
        Dim NaveSICYID As Integer = 0
        Dim FechaPrograma As Date
        Dim Lotes As Integer = 0
        Dim NombreLote As String = String.Empty
        Dim ParesLote As String = String.Empty
        Dim NombreNave As String = String.Empty
        Dim AñoLote As String = String.Empty
        Dim nave As String = String.Empty
        Try
            NaveSICYID = cmbNave.SelectedValue
            FechaPrograma = dtmFechaPrograma.Value
            NombreNave = cmbNave.Text.ToString()


            Lotes = ViewConsultaDeLotes.GetFocusedRowCellValue("lote").ToString
            NombreLote = ViewConsultaDeLotes.GetFocusedRowCellValue("Cliente_texto").ToString
            ParesLote = ViewConsultaDeLotes.GetFocusedRowCellValue("pares").ToString
            nave = ViewConsultaDeLotes.GetFocusedRowCellValue("nave").ToString
            AñoLote = ViewConsultaDeLotes.GetFocusedRowCellValue("año").ToString

            dtCliente = New DataTable("dtClientes")
            With dtCliente
                .Columns.Add("ClienteId")
                .Columns.Add("NombreCliente")
            End With


            dtTiendasClientes = New DataTable("dtTiendasCliente")
            With dtTiendasClientes
                .Columns.Add("TiendaID")
                .Columns.Add("NombreTienda")
                .Columns.Add("ClienteID")
            End With

            dtPartidasTienda = New DataTable("dtPartidasTienda")
            With dtPartidasTienda
                .Columns.Add("PartidaID")
                .Columns.Add("TiendaID")
                .Columns.Add("ClienteID")
                .Columns.Add("Partida")
                .Columns.Add("Estilo")
                .Columns.Add("Pares")
            End With

            dtEncabezadoTallas = New DataTable("dtEncabezadoTallas")
            With dtEncabezadoTallas
                .Columns.Add("PartidaID")
                .Columns.Add("TiendaID")
                .Columns.Add("ClienteID")
                .Columns.Add("Talla1")
                .Columns.Add("Talla2")
                .Columns.Add("Talla3")
                .Columns.Add("Talla4")
                .Columns.Add("Talla5")
                .Columns.Add("Talla6")
                .Columns.Add("Talla7")
                .Columns.Add("Talla8")
                .Columns.Add("Talla9")
                .Columns.Add("Talla10")
                .Columns.Add("TallaID")
            End With

            dtParesTalla = New DataTable("dtParesPartida")
            With dtParesTalla
                .Columns.Add("PartidaID")
                .Columns.Add("ClienteID")
                .Columns.Add("EstiloID")
                .Columns.Add("Pares1")
                .Columns.Add("Pares2")
                .Columns.Add("Pares3")
                .Columns.Add("Pares4")
                .Columns.Add("Pares5")
                .Columns.Add("Pares6")
                .Columns.Add("Pares7")
                .Columns.Add("Pares8")
                .Columns.Add("Pares9")
                .Columns.Add("Pares10")
                .Columns.Add("TallaID")
                .Columns.Add("TiendaID")
            End With

            dtClienteAux = objBU.ReporteTallasLoteCliente(Lotes, NaveSICYID, FechaPrograma)

            For Each Fila As DataRow In dtClienteAux.Rows
                dtCliente.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString())
            Next

            dtTiendasClientesAux = objBU.ReporteTallasLoteClienteTienda(Lotes, NaveSICYID, FechaPrograma)

            For Each Fila As DataRow In dtTiendasClientesAux.Rows
                dtTiendasClientes.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString(), Fila.Item(2).ToString())
            Next

            dtPartidasTiendaAux = objBU.ReporteTallasLotePartidasTienda(Lotes, NaveSICYID, FechaPrograma)

            For Each Fila As DataRow In dtPartidasTiendaAux.Rows
                dtPartidasTienda.Rows.Add(Fila.Item(0).ToString, Fila.Item(1).ToString(), Fila.Item(2).ToString(), Fila.Item(3).ToString(), Fila.Item(4).ToString(), Fila.Item(5).ToString())
            Next

            dtEncabezadoTallasAux = objBU.ReporteTallasLoteEncabezadoTallas(Lotes, NaveSICYID, FechaPrograma)

            Dim Partidas = dtEncabezadoTallasAux.AsEnumerable().Select(Function(x) x.Item("PartidaID")).Distinct()
            Dim Puntos(10) As String
            Dim indice As Integer = 0
            Dim ClienteId As Integer = 0
            Dim TallaId As String = String.Empty

            For Each NumeroPartida In Partidas

                TallaId = dtEncabezadoTallasAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("idtblTalla")).FirstOrDefault


                Dim Tiendas = dtEncabezadoTallasAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("TiendaID")).Distinct()

                For Each TiendaId In Tiendas
                    ClienteId = dtEncabezadoTallasAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida And x.Item("TiendaID") = TiendaId).Select(Function(y) y.Item("ClienteID")).FirstOrDefault
                    Dim PuntosPartida = dtEncabezadoTallasAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida And x.Item("TiendaID") = TiendaId).Select(Function(y) y.Item("Calce")).ToList

                    Puntos(0) = ""
                    Puntos(1) = ""
                    Puntos(2) = ""
                    Puntos(3) = ""
                    Puntos(4) = ""
                    Puntos(5) = ""
                    Puntos(6) = ""
                    Puntos(7) = ""
                    Puntos(8) = ""
                    Puntos(9) = ""

                    For Each Punto In PuntosPartida.ToList
                        If indice = 0 Then
                            Puntos(0) = Punto
                        ElseIf indice = 1 Then
                            Puntos(1) = Punto
                        ElseIf indice = 2 Then
                            Puntos(2) = Punto
                        ElseIf indice = 3 Then
                            Puntos(3) = Punto
                        ElseIf indice = 4 Then
                            Puntos(4) = Punto
                        ElseIf indice = 5 Then
                            Puntos(5) = Punto
                        ElseIf indice = 6 Then
                            Puntos(6) = Punto
                        ElseIf indice = 7 Then
                            Puntos(7) = Punto
                        ElseIf indice = 8 Then
                            Puntos(8) = Punto
                        ElseIf indice = 9 Then
                            Puntos(9) = Punto
                        End If

                        indice = indice + 1
                    Next

                    dtEncabezadoTallas.Rows.Add(NumeroPartida, TiendaId, ClienteId, Puntos(0), Puntos(1), Puntos(2), Puntos(3), Puntos(4), Puntos(5), Puntos(6), Puntos(7), Puntos(8), Puntos(9), TallaId)
                    indice = 0

                Next


            Next


            dtParesTallaAux = objBU.ReporteTallasLoteParesPartidaTallas(Lotes, NaveSICYID, FechaPrograma)

            Dim PartidasTallas = dtParesTallaAux.AsEnumerable().Select(Function(x) x.Item("PartidaID")).Distinct()
            Dim ParesTallas As String = String.Empty
            Dim Estilo As String = String.Empty


            For Each NumeroPartida In Partidas
                'Dim PuntosPartida = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("Calce")).ToList
                'TiendaId = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("TiendaID")).FirstOrDefault
                TallaId = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("idtblTalla")).FirstOrDefault

                Estilo = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("Descripcion")).FirstOrDefault

                Dim TiendasPares = dtEncabezadoTallasAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida).Select(Function(y) y.Item("TiendaID")).Distinct()

                For Each TiendaId In TiendasPares
                    ClienteId = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida And x.Item("TiendaID") = TiendaId).Select(Function(y) y.Item("ClienteID")).FirstOrDefault
                    Dim PuntosPartida = dtEncabezadoTallasAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida And x.Item("TiendaID") = TiendaId).Select(Function(y) y.Item("Calce")).ToList
                    ParesTallas = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida And x.Item("TiendaID") = TiendaId).Select(Function(y) y.Item("ParesTalla")).FirstOrDefault
                    Puntos(0) = ""
                    Puntos(1) = ""
                    Puntos(2) = ""
                    Puntos(3) = ""
                    Puntos(4) = ""
                    Puntos(5) = ""
                    Puntos(6) = ""
                    Puntos(7) = ""
                    Puntos(8) = ""
                    Puntos(9) = ""
                    Dim Pares As String = String.Empty
                    indice = 0

                    For Each Punto In PuntosPartida.ToList

                        Pares = dtParesTallaAux.AsEnumerable().Where(Function(x) x.Item("PartidaID") = NumeroPartida And x.Item("Calce") = Punto).Select(Function(y) y.Item("ParesTalla")).FirstOrDefault()

                        If indice = 0 Then
                            Puntos(0) = Pares
                        ElseIf indice = 1 Then
                            Puntos(1) = Pares
                        ElseIf indice = 2 Then
                            Puntos(2) = Pares
                        ElseIf indice = 3 Then
                            Puntos(3) = Pares
                        ElseIf indice = 4 Then
                            Puntos(4) = Pares
                        ElseIf indice = 5 Then
                            Puntos(5) = Pares
                        ElseIf indice = 6 Then
                            Puntos(6) = Pares
                        ElseIf indice = 7 Then
                            Puntos(7) = Pares
                        ElseIf indice = 8 Then
                            Puntos(8) = Pares
                        ElseIf indice = 9 Then
                            Puntos(9) = Pares
                        End If

                        indice = indice + 1
                    Next

                    dtParesTalla.Rows.Add(NumeroPartida, ClienteId, Estilo, Puntos(0), Puntos(1), Puntos(2), Puntos(3), Puntos(4), Puntos(5), Puntos(6), Puntos(7), Puntos(8), Puntos(9), TallaId, TiendaId)
                    indice = 0
                Next
            Next

            dsClientesLote.Tables.Add(dtCliente)
            dsClientesLote.Tables.Add(dtTiendasClientes)
            dsClientesLote.Tables.Add(dtPartidasTienda)
            dsClientesLote.Tables.Add(dtEncabezadoTallas)
            dsClientesLote.Tables.Add(dtParesTalla)

            entReporte = objReporte.LeerReporteporClave("PROG_TALLAS_LOTE")

            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                LTrim(RTrim(entReporte.Pnombre)) + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, entReporte.Pxml, False)


            ReporteTallasLote.Load(archivo)
            ReporteTallasLote.Compile()
            ReporteTallasLote.RegData(dsClientesLote)
            ReporteTallasLote("NombreLote") = NombreLote
            ReporteTallasLote("ParesLote") = ParesLote
            ReporteTallasLote("Lote") = Lotes.ToString
            ReporteTallasLote("Nave") = NombreNave
            ReporteTallasLote("AñoLote") = AñoLote
            ReporteTallasLote.Dictionary.Clear()
            ReporteTallasLote.Dictionary.Synchronize()
            'reporteUnaTienda.Render()
            ReporteTallasLote.Show()

        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try
    End Sub

    Private Sub ViewConsultaDeLotes_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles ViewConsultaDeLotes.RowCellClick
        Try
            If e.RowHandle >= 0 Then
                If e.Clicks = 2 Then
                    If e.Column.FieldName.ToString = "cliente_Nombre" Then
                        Cursor = Cursors.WaitCursor
                        GenerarReporte()
                        Cursor = Cursors.Default
                    End If

                End If
            End If
        Catch ex As Exception
            show_message("Error", ex.Message.ToString())
        End Try

    End Sub

    Private Sub PermisosImpresionPrueba()


        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("CONSULTA_LOTES", "PROG_IMPRESION_ETIQUETAS_PRUEBA") Then
            btnEtiquetaPruebas.Visible = True
            lblEtiquetasPrueba.Visible = True
        Else
            btnEtiquetaPruebas.Visible = False
            lblEtiquetasPrueba.Visible = False
        End If

    End Sub

    Private Function ObtenerLotesSeleccionadosCoppel() As String
        Dim NumeroFilas As Integer = 0
        Dim LotesSeleccionados As String = String.Empty

        Try
            NumeroFilas = ViewConsultaDeLotes.DataRowCount
            For index As Integer = 0 To NumeroFilas Step 1
                If CBool(ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), " ")) = True Then
                    If ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "Cliente_texto").ToString().Contains("COPPEL") = True Then
                        If LotesSeleccionados = String.Empty Then
                            LotesSeleccionados = ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                        Else
                            LotesSeleccionados &= "," & ViewConsultaDeLotes.GetRowCellValue(ViewConsultaDeLotes.GetVisibleRowHandle(index), "lote").ToString()
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return LotesSeleccionados

    End Function

    Private Function CopiarImagenesCoppel(ByVal Lotes As String, ByVal NaveSICYID As Integer, ByVal Año As Integer) As Boolean
        Dim dtImagenes As New DataTable
        Dim CarpetaDestino As String = String.Empty
        Dim RutaImagenCompletaTemporal As String = String.Empty
        Dim NombreImagenTemporal As String = String.Empty
        Dim RutaCompletaSICY As String = String.Empty
        Dim RutaFTP As String = String.Empty
        Dim RutaCompletaLocal As String = String.Empty
        Dim Resultado As Boolean = False
        Dim RutaImagenLogoMarcaClienteTemporal As String = String.Empty
        Dim NombreImagenLogoMarcaClienteTemporal As String = String.Empty
        Dim RutaCompletaLocalLogo As String = String.Empty
        Dim RutaCompletaSICYCoppel As String = String.Empty
        Dim RutaCompletaLocalCoppel As String = String.Empty
        Dim RutaFTPLogoMarca As String = String.Empty

        Try
            dtImagenes = objBU.ConsultaImagenesCoppel(Lotes, NaveSICYID, Año)

            For Each Fila As DataRow In dtImagenes.Rows
                CarpetaDestino = Fila.Item("Carpeta")
                RutaImagenCompletaTemporal = Fila.Item("RutaNoExite")
                RutaFTP = Fila.Item("RutaFTP")

                If Fila.Item("RutaNoExiteMarcaCliente") = Nothing Then
                Else
                    RutaImagenLogoMarcaClienteTemporal = Fila.Item("RutaNoExiteMarcaCliente")
                    If Fila.Item("RutaFTPLogoMarcaCliente") = Nothing Then
                    Else

                        RutaFTPLogoMarca = Fila.Item("RutaFTPLogoMarcaCliente")
                        NombreImagenLogoMarcaClienteTemporal = Path.GetFileName(RutaImagenLogoMarcaClienteTemporal)
                        RutaCompletaSICYCoppel = CarpetaDestino + NombreImagenLogoMarcaClienteTemporal
                        If File.Exists(RutaCompletaSICYCoppel) = False Then
                            RutaCompletaLocalCoppel = objBU.DescargarImagenBatta(RutaFTPLogoMarca)
                            File.Copy(RutaCompletaLocalCoppel, RutaCompletaSICYCoppel)
                        End If

                    End If
                End If


                NombreImagenTemporal = Path.GetFileName(RutaImagenCompletaTemporal)
                RutaCompletaSICY = CarpetaDestino + NombreImagenTemporal
                If File.Exists(RutaCompletaSICY) = False Then
                    RutaCompletaLocal = objBU.DescargarImagenBatta(RutaFTP)
                    File.Copy(RutaCompletaLocal, RutaCompletaSICY)
                End If
            Next

            Resultado = True
        Catch ex As Exception
            Resultado = False
            show_message("Advertencia", ex.Message.ToString())
        End Try

        Return Resultado

    End Function

    Private Sub btnLotesGrfImagen_Click(sender As Object, e As EventArgs) Handles btnLotesGrfImagen.Click
        Dim form As New ConsultaLotesSinGrfImagenForm
        form.MdiParent = Me.MdiParent
        form.Show()
    End Sub

    Private Sub ViewConsultaDeLotes_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles ViewConsultaDeLotes.CustomDrawRowIndicator
        If (e.Info.IsRowIndicator And e.RowHandle >= 0) Then
            e.Info.DisplayText = e.RowHandle.ToString() + 1
        End If
    End Sub
End Class
