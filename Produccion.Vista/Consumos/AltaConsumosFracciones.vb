Imports Entidades
Imports Produccion.Negocios
Imports System.Net
Imports Infragistics.Win.UltraWinGrid
Imports Tools
Imports Infragistics.Win
Imports Infragistics.Documents.Excel

Public Class AltaConsumosFracciones
    Public editar As Boolean = False

    Public idProducto As Integer = 0
    Public idEstiloProd As Integer = 0
    Public idNave As Integer = 0
    Public idNaveConsulta As Integer = 0
    Public productoEstiloId As Integer = 0
    Public ImportarConsumos As Boolean = False
    Public NAveDesarrollaID As Integer = 0
    Public modelo As String = ""
    Public accion As String = "" 'Desarrollo,Producción
    Dim exito As New ExitoForm
    Dim adv As New AdvertenciaForm
    Dim validaConsumo As Boolean = False
    Dim borrar As Boolean = False
    Dim mensaje As String = ""
    Dim codigoProd As String = ""
    Dim suela As String = ""
    Dim caja As String = ""
    Dim marca As String = ""
    Public tipoNave As String = ""
    Public naveDesarrolla As String = ""
    Public naves As String = ""
    Public estatusArticulo As String = ""
    Public permisoModificar As Boolean = False
    Public otroEstatus As String = ""
    Public nuevaAsignacion As Boolean = False
    Dim objAdvertencia As New Tools.AdvertenciaForm

    Public EsAlta As Boolean = False
    Public IdNaveAlta As Integer = -1

    Dim objconfirmacion As New Tools.ConfirmarForm

    Public listaComponentesCopiados As New List(Of Integer)
    Public listaFraccionesCopiadas As New List(Of Integer)

    Public consumosCopiados As New DataTable
    Public fraccionesCopiadas As New DataTable
    Public CambioConsumos As Boolean = False
    Public idFraccionOriginal As Integer
    Dim dtConsumos As DataTable
    Dim vLstMateriales As New List(Of MaterialConsumos)

    Public rutaImagenForm As String = ""



    Private Sub EstiloNave_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub llenarCampos()
        Dim datos As New DataTable
        Dim obj As New ConsumosBU
        Dim d As New DataTable
        Dim naveDes As New DataTable
        Dim naveDesa As String = ""
        naveDes = obj.getNaveDesarrolla(productoEstiloId)
        For Each row As DataRow In naveDes.Rows
            naveDesa = row("nave")
        Next

        Me.Text = "" & productoEstiloId & " Nave Desarrolla " & naveDesa & " - Alta/Modificación de Consumos y Fracciones "
        datos = obj.getDatosProducto(productoEstiloId)
        For Each row As DataRow In datos.Rows
            codigoProd = row("Código")
            lblMarca1.Text = row("Marca")
            idProducto = row("idProducto")
            idEstiloProd = row("idEstiloProd")
            If nuevaAsignacion = True Then
            Else
                idNave = row("idNave")
            End If
            lblColec.Text = row("Colección")
            lblTemp.Text = row("Temporada")
            lblCodcli.Text = row("CodigoCliente")
            lblHor.Text = row("Horma")
            lblPielCol.Text = row("PielColor")
            lblCli.Text = row("Cliente")
            lblCorrida.Text = row("Corrida")
            If row("FechaVigencia") = "1/1/1900 12:00:00 AM" Then
                lblFechaVIgenciac.Text = "-"
            Else
                lblFechaVIgenciac.Text = row("FechaVigencia")
            End If

            CargarImagenesArticulo(row("Imagen"), row("suela1"), row("caja"), row("Norma"))

            'leerimagen(row("Imagen"))
            'leerimagen2(row("suela1"))
            'leerimagen3(row("caja"))
            'leerimagen4(row("Norma"))
            lblModelo1.Text = modelo
        Next

        d = obj.validarNave(productoEstiloId, idNaveConsulta)
        For Each row As DataRow In d.Rows
            Try
                If row(0) = 2 Then
                    tipoNave = "Produccion"
                Else
                    tipoNave = "Desarrollo"
                    btnImportarConsumos.Visible = True
                    btnImportConsumos.Visible = True
                    lbl1.Visible = True
                    lblImportarConsumos.Visible = True
                    btnExportar.Visible = True
                    lblExportar.Visible = True
                End If
                'If row(0) = idNaveConsulta Then
                '    tipoNave = "Desarrollo"
                '    btnImportarConsumos.Visible = True
                '    btnImportConsumos.Visible = True
                '    lbl1.Visible = True
                '    lblImportarConsumos.Visible = True
                '    btnExportar.Visible = True
                '    lblExportar.Visible = True
                'Else
                '    tipoNave = "Produccion"
                'End If
            Catch ex As Exception
                tipoNave = "Desarrollo"
                btnImportarConsumos.Visible = True
                btnImportConsumos.Visible = True
                lbl1.Visible = True
                lblImportarConsumos.Visible = True
                btnExportar.Visible = True
                lblExportar.Visible = True
            End Try

        Next
    End Sub
    Public Sub pintarceldas()
        Dim conPrecio As Integer = 0
        Dim sinPrecio As Integer = 0
        Dim i As Integer = 0

        If CambioConsumos = False Then
            Do
                Try
                    If grdFracciones.Rows(i).Cells("Activo").Value = 0 Then
                        grdFracciones.Rows(i).Appearance.BackColor = Color.Salmon
                        grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.Salmon
                    Else
                        grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                        If i Mod 2 = 0 Then
                            grdFracciones.Rows(i).Appearance.BackColor = Color.White
                        Else
                            grdFracciones.Rows(i).Appearance.BackColor = Color.LightSteelBlue
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If grdFracciones.Rows(i).Cells("Activo").Value = 0 Then
                        grdFracciones.Rows(i).Appearance.BackColor = Color.Salmon
                        grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.Salmon
                    Else
                        grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                        grdFracciones.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                    End If
                Catch ex As Exception
                End Try
                i += 1
            Loop While i < grdFracciones.Rows.Count
            i = 0
            Do
                Try
                    If grdConsumos.Rows(i).Cells("Activo").Value = 0 Then
                        grdConsumos.Rows(i).Appearance.BackColor = Color.Salmon
                        grdConsumos.Rows(i).Cells("Activo").Appearance.BackColor = Color.Salmon
                    Else
                        grdConsumos.Rows(i).Cells("Activo").Appearance.BackColor = Color.YellowGreen
                        If i Mod 2 = 0 Then
                            grdConsumos.Rows(i).Appearance.BackColor = Color.White
                        Else
                            grdConsumos.Rows(i).Appearance.BackColor = Color.LightSteelBlue
                        End If
                    End If
                Catch ex As Exception
                End Try

                Try
                    If grdConsumos.Rows(i).Cells("Consumo").Value <= 0 Then
                        grdConsumos.Rows(i).Cells("Consumo").Appearance.BackColor = Color.Salmon
                    Else
                        grdConsumos.Rows(i).Cells("Consumo").Appearance.BackColor = Color.YellowGreen
                        grdConsumos.Rows(i).Cells("Consumo").Appearance.BackColor = Color.YellowGreen
                    End If
                Catch ex As Exception
                End Try
                i += 1
            Loop While i < grdConsumos.Rows.Count
        End If


    End Sub
    Private Sub AltaConsumosFracciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If EsAlta = True Then
            NAveDesarrollaID = IdNaveAlta
        End If
        Me.Cursor = Cursors.WaitCursor

        llenarCampos()
        getDatosConsumos()
        getDatosFracciones()
        pintarceldas()
        historial()

        Me.Cursor = Cursors.Default

        If Not tipoNave = "Desarrollo" Then
            'btnGuardar.Enabled = False
            btnImportConsumos.Enabled = False
            btnImportarConsumos.Enabled = True
            btnImportarConsumos.Visible = True
            lblImportarConsumos.Visible = True
            lblImportarConsumos.Text = "Importar Fracciones "
            btnAddMarca.Enabled = False
            btnQuitarMarca.Enabled = False
            btnAddCaja.Enabled = False
            btnQuitarCaja.Enabled = False
            btnAddSuela.Enabled = False
            btnQuitarSuela.Enabled = False
        End If

        If Not permisoModificar = True Then
            btnGuardar.Enabled = False
            btnImportConsumos.Enabled = False
            btnImportarConsumos.Enabled = False

        End If

        If tipoNave = "Desarrollo" Then
            If estatusArticulo.Trim = "DESCONTINUADO" Then
                btnImportarConsumos.Enabled = False
                btnImportConsumos.Enabled = False
                btnExportar.Enabled = False
                btnGuardar.Enabled = False
                btnAddMarca.Enabled = False
                btnQuitarMarca.Enabled = False
                btnAddCaja.Enabled = False
                btnQuitarCaja.Enabled = False
                btnAddSuela.Enabled = False
                btnQuitarSuela.Enabled = False
                btn_ExportarFracciones.Enabled = False
            End If
        ElseIf estatusArticulo.Trim = "DESCONTINUADO" Then
            btnImportarConsumos.Enabled = False
            btnImportConsumos.Enabled = False
            btnExportar.Enabled = False
            btnGuardar.Enabled = False
            btnAddMarca.Enabled = False
            btnQuitarMarca.Enabled = False
            btnAddCaja.Enabled = False
            btnQuitarCaja.Enabled = False
            btnAddSuela.Enabled = False
            btnQuitarSuela.Enabled = False
            btn_ExportarFracciones.Enabled = False
        Else
            If otroEstatus.Trim = "DP" Then
                btnImportarConsumos.Enabled = False
                btnImportConsumos.Enabled = False
                btnExportar.Enabled = False
                btnGuardar.Enabled = False
                btnAddMarca.Enabled = False
                btnQuitarMarca.Enabled = False
                btnAddCaja.Enabled = False
                btnQuitarCaja.Enabled = False
                btnAddSuela.Enabled = False
                btnQuitarSuela.Enabled = False
                btn_ExportarFracciones.Enabled = False
            End If
        End If
        calcularTotales()

        ' MsgBox(editar)

        If editar Then
            btnImportConsumos.Enabled = False
            btnImportarConsumos.Enabled = False
            btnExportar.Enabled = False
            btnAddCaja.Enabled = False
            btnAddSuela.Enabled = False
            btnAgregarFotografia.Enabled = False
            btnAddMarca.Enabled = False
            btnQuitarCaja.Enabled = False
            btnQuitarSuela.Enabled = False
            btnQuitarFotografia.Enabled = False
            btnQuitarMarca.Enabled = False
            'btnGuardar.Enabled = False
            btnGuardar.Visible = False
            lblGuardar.Visible = False
            btn_ExportarFracciones.Enabled = False
        End If

        If estatusArticulo.Trim = "INACTIVO NAVE" Then
            btnImportarConsumos.Enabled = False
        ElseIf estatusArticulo.Trim() = "DESCONTINUADO" Then
            btnImportarConsumos.Enabled = False
        End If

        btn_ExportarFracciones.Visible = True
        lbl_ExportarFracciones.Visible = True


        For Each columna As Infragistics.Win.UltraWinGrid.UltraGridColumn In grdConsumos.DisplayLayout.Bands(0).Columns
            ' Imprimir el nombre de la columna (key)
            Console.WriteLine(columna.Key)
        Next

        lblTotal.Visible = False
        calcularConsumosV2()

    End Sub
    Private Sub getDatosFracciones()
        Dim obj As New ConsumosBU
        grdFracciones.DataSource = obj.getfraccionesDes(productoEstiloId, idNaveConsulta)
        'If tipoNave = "Desarrollo" Then
        '    grdFracciones.DataSource = obj.getfraccionesDes(productoEstiloId)
        'Else
        '    grdFracciones.DataSource = obj.getfraccionesProd(productoEstiloId, idNaveConsulta)
        'End If
        Dim band As UltraGridBand = Me.grdFracciones.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2
        With grdFracciones.DisplayLayout.Bands(0)
            .Columns("idFraccDesActual").Hidden = True
            .Columns("idFraccion").Hidden = True
            .Columns("maquinaid").Hidden = True
            .Columns("idFraccDes").Hidden = True
            .Columns("Fracción").CellActivation = Activation.NoEdit
            .Columns("Costo").CellActivation = Activation.AllowEdit
            .Columns("Maquinaria").CellActivation = Activation.NoEdit
            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Activo").Style = ColumnStyle.CheckBox
            .Columns("Activo").Header.Caption = "Activo"
            .Columns("Sumar Costo").Header.Caption = "Sumar" & vbCrLf & "Costo"
            .Columns("Sumar Tiempo").Header.Caption = "Sumar" & vbCrLf & "Tiempo"
            .Columns("Costo").Format = "$ ##,##0.00"
            .Columns("Horas").Format = "##,##0"
            .Columns("Minutos").Format = "##,##0"
            .Columns("Segundos").Format = "##,##0"
            .Columns("Horas").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Minutos").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Segundos").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Pagar").CellActivation = Activation.AllowEdit

            .Columns("Activo").Width = 20
            .Columns("Orden").Width = 25
            .Columns("Pagar").Width = 25
            .Columns("Sumar Costo").Width = 30
            .Columns("Horas").Width = 30
            .Columns("Minutos").Width = 30
            .Columns("Segundos").Width = 35
            .Columns("Sumar Tiempo").Width = 30
            .Columns("Maquinaria").Width = 100
            .Columns("Costo").Width = 30
            .Columns("Fracción").Width = 100
            .Columns("Costo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Observaciones").Width = 150
            .Columns("Orden").CellActivation = Activation.NoEdit

            If estatusArticulo.Trim = "DESCONTINUADO" Then
                .Columns("Orden").CellActivation = Activation.NoEdit
                .Columns("Costo").CellActivation = Activation.NoEdit
                .Columns("Horas").CellActivation = Activation.NoEdit
                .Columns("Minutos").CellActivation = Activation.NoEdit
                .Columns("Segundos").CellActivation = Activation.NoEdit
                .Columns("Sumar Tiempo").CellActivation = Activation.NoEdit
                .Columns("Activo").CellActivation = Activation.NoEdit
                .Columns("Pagar").CellActivation = Activation.NoEdit
                .Columns("Sumar Costo").CellActivation = Activation.NoEdit
                .Columns("Observaciones").CellActivation = Activation.NoEdit
                grdFracciones.AllowDrop = False
                '.Columns("Pagar").CellActivation = Activation.NoEdit
            End If



            If tipoNave = "Desarrollo" Then
                If estatusArticulo.Trim = "INACTIVO NAVE" Then
                    .Columns("Orden").CellActivation = Activation.NoEdit
                    .Columns("Costo").CellActivation = Activation.AllowEdit
                    .Columns("Horas").CellActivation = Activation.NoEdit
                    .Columns("Minutos").CellActivation = Activation.NoEdit
                    .Columns("Segundos").CellActivation = Activation.NoEdit
                    .Columns("Sumar Tiempo").CellActivation = Activation.NoEdit
                    .Columns("Activo").CellActivation = Activation.NoEdit
                    .Columns("Pagar").CellActivation = Activation.NoEdit
                    .Columns("Sumar Costo").CellActivation = Activation.NoEdit
                    .Columns("Observaciones").CellActivation = Activation.NoEdit
                    grdFracciones.AllowDrop = False
                End If
            Else
                If estatusArticulo.Trim = "INACTIVO NAVE" Then
                    .Columns("Orden").CellActivation = Activation.NoEdit
                    .Columns("Costo").CellActivation = Activation.NoEdit
                    .Columns("Horas").CellActivation = Activation.NoEdit
                    .Columns("Minutos").CellActivation = Activation.NoEdit
                    .Columns("Segundos").CellActivation = Activation.NoEdit
                    .Columns("Sumar Tiempo").CellActivation = Activation.NoEdit
                    .Columns("Activo").CellActivation = Activation.NoEdit
                    .Columns("Pagar").CellActivation = Activation.NoEdit
                    .Columns("Sumar Costo").CellActivation = Activation.NoEdit
                    .Columns("Observaciones").CellActivation = Activation.NoEdit
                    grdFracciones.AllowDrop = False
                End If
            End If

            'MsgBox(editar)

            If editar = False Then
                .Columns("Activo").CellActivation = Activation.AllowEdit
            Else
                .Columns("Activo").CellActivation = Activation.NoEdit
            End If


            'If NAveDesarrollaID = idNaveConsulta Then
            '    .Columns("Activo").CellActivation = Activation.AllowEdit
            'Else
            '    .Columns("Activo").CellActivation = Activation.NoEdit
            'End If

        End With
        actualizarLista("")
        grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdFracciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex


        grdFracciones.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdFracciones.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing

        '        this.ultraGrid1.DisplayLayout.Override.RowSelectors = DefaultableBoolean.False;

        'grdFracciones.Rows(0).Cells("Sumar Tiempo").Value = 1
        'grdFracciones.Rows(0).Cells("Sumar Costo").Value = 1
    End Sub
    Public Sub actualizarLista(cadena As String)
        Dim obs As New DataTable
        Dim obj As New ConsumosBU
        Dim listobs As New ValueList
        obs = obj.getObservacionesFracciones(cadena)
        For Each row As DataRow In obs.Rows
            listobs.ValueListItems.Add(row("observacionFraccion"))
        Next
        With grdFracciones.DisplayLayout.Bands(0)
            .Columns("Observaciones").ValueList = listobs
            .Columns("Observaciones").Style = UltraWinGrid.ColumnStyle.DropDown
            .Columns("Observaciones").AutoCompleteMode = AutoCompleteMode.SuggestAppend
        End With
    End Sub


    Private Sub getDatosConsumosExcel()
        Dim obj As New ConsumosBU
        If tipoNave = "Desarrollo" Then
            grdExportarConsumos.DataSource = obj.getconsumosDesExcel(productoEstiloId)
        Else
            grdExportarConsumos.DataSource = obj.getconsumosProdExcel(productoEstiloId)
        End If
    End Sub
    Private Sub getDatosConsumos()
        Dim obj As New ConsumosBU
        dtConsumos = Nothing

        If tipoNave = "Desarrollo" Then
            dtConsumos = obj.getconsumosDes(productoEstiloId)

            If dtConsumos.Rows.Count = 0 Then

                Dim row As DataRow = dtConsumos.NewRow
                row("Activo") = 1
                row("Editado") = 0
                row("Bloqueado") = 0
                row("Explosionar") = 0
                row("Lotear") = 0
                row("Orden") = 1
                row("idComponente") = 0
                row("Componente") = ""
                row("idClasificacion") = 0
                row("Clasificación") = ""
                row("IdMaterial") = 0
                row("IdConsumo") = 0
                row("Consumo") = 0.00
                row("idUMC") = 0
                row("UMC") = ""
                row("idProveedor") = 0
                row("Proveedor") = ""
                row("Precio Compra") = 0.00
                row("idUMProd") = 0
                row("UMP") = ""
                row("Factor") = 0.0
                row("PrecioUM") = 0.0
                row("Costo X Par") = 0.0
                row("productoEstiloId") = 0

                dtConsumos.Rows.Add(row)
                grdConsumos.DataSource = dtConsumos
            Else
                grdConsumos.DataSource = obj.getconsumosDes(productoEstiloId)

            End If

            diseñoConsumos()
        Else
            If estatusArticulo = "INACTIVO NAVE" Then
                dtConsumos = obj.getconsumosProd(productoEstiloId, idNaveConsulta, 1)
                grdConsumos.DataSource = obj.getconsumosProd(productoEstiloId, idNaveConsulta, 1)
            Else
                dtConsumos = obj.getconsumosProd(productoEstiloId, idNaveConsulta)
                grdConsumos.DataSource = obj.getconsumosProd(productoEstiloId, idNaveConsulta)

            End If

            diseñoConsumosProd()
        End If
        Dim tablas As New DataTable
        tablas = obj.getconsumosDes(productoEstiloId)
        getDatosConsumosExcel()
    End Sub
    Private Sub diseñoConsumosProd()
        With grdConsumos.DisplayLayout.Bands(0)
            Try
                .Columns("productoEstiloId").Hidden = True
                .Columns("Editado").Hidden = True
                .Columns("idComponente").Hidden = True
                .Columns("idClasificacion").Hidden = True
                .Columns("IdMaterial").Hidden = True
                .Columns("idConsumo").Hidden = True
                .Columns("idProveedor").Hidden = True
                .Columns("idUMC").Hidden = True
                .Columns("idUMProd").Hidden = True
                .Columns("Bloqueado").Hidden = True

                .Columns("Lotear").Hidden = True
                .Columns("Explosionar").Hidden = True
                '.Columns("Orden").Hidden = True

                .Columns("Componente").CellActivation = Activation.NoEdit
                .Columns("Clasificación").CellActivation = Activation.NoEdit
                .Columns("IdMaterial").CellActivation = Activation.NoEdit
                .Columns("SKU").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("UMC").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Precio Compra").CellActivation = Activation.NoEdit
                .Columns("UMP").CellActivation = Activation.NoEdit
                .Columns("Factor").CellActivation = Activation.NoEdit
                .Columns("PrecioUM").CellActivation = Activation.NoEdit
                .Columns("Costo X Par").CellActivation = Activation.NoEdit

                .Columns("Bloqueado").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Bloqueado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Bloqueado").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Bloqueado").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Explosionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Explosionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Explosionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Explosionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Lotear").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Lotear").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Lotear").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Lotear").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                .Columns("Activo").Style = ColumnStyle.CheckBox
                .Columns("Activo").Header.Caption = "Activo"

                .Columns("Consumo").Format = "##,##0.00"
                .Columns("Precio Compra").Format = "##,##0.00"
                .Columns("PrecioUM").Format = "##,##0.00"
                .Columns("Costo X Par").Format = "##,###.##"
                .Columns("Consumo").CellActivation = Activation.NoEdit
                .Columns("Bloqueado").CellActivation = Activation.NoEdit
                .Columns("Explosionar").CellActivation = Activation.NoEdit
                .Columns("Lotear").CellActivation = Activation.NoEdit
                .Columns("Activo").CellActivation = Activation.NoEdit

                .Columns("UMC").Header.Caption = "UMC"
                .Columns("UMP").Header.Caption = "UMP"
                .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Orden").CellActivation = Activation.NoEdit

                .Columns("Orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("PrecioUM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Precio Compra").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Costo X Par").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Factor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Consumo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Consumo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Consumo").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                .Columns("Orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("PrecioUM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Precio Compra").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Costo X Par").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Factor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right


                .Columns("PrecioUM").Header.Caption = "Precio" & vbCrLf & "UMC"
                .Columns("Precio Compra").Header.Caption = "Precio" & vbCrLf & "Compra"
                If estatusArticulo.Trim = "DESCONTINUADO" Then
                    .Columns("Consumo").CellActivation = Activation.NoEdit
                    .Columns("Activo").CellActivation = Activation.NoEdit
                    grdConsumos.AllowDrop = False
                End If


                'MsgBox(tipoNave)

                If tipoNave = "Desarrollo" Then
                    If editar = False Then
                        .Columns("Activo").CellActivation = Activation.AllowEdit
                    Else
                        .Columns("Activo").CellActivation = Activation.NoEdit
                    End If
                End If



                'If NAveDesarrollaID = idNaveConsulta Then
                '    .Columns("Activo").CellActivation = Activation.AllowEdit
                'Else
                '    .Columns("Activo").CellActivation = Activation.NoEdit
                'End If
            Catch ex As Exception

            End Try

        End With
        grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdConsumos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        grdConsumos.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdConsumos.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing
    End Sub
    Private Sub diseñoConsumos()
        With grdConsumos.DisplayLayout.Bands(0)
            Try
                .Columns("productoEstiloId").Hidden = True
                .Columns("Editado").Hidden = True
                .Columns("idComponente").Hidden = True
                .Columns("idClasificacion").Hidden = True
                .Columns("IdMaterial").Hidden = True
                .Columns("idConsumo").Hidden = True
                .Columns("idProveedor").Hidden = True
                .Columns("idUMC").Hidden = True
                .Columns("idUMProd").Hidden = True
                .Columns("Bloqueado").Hidden = True
                .Columns("Lotear").Hidden = True
                .Columns("Explosionar").Hidden = True
                '.Columns("Orden").Hidden = True

                .Columns("Componente").CellActivation = Activation.NoEdit
                .Columns("Clasificación").CellActivation = Activation.NoEdit
                .Columns("IdMaterial").CellActivation = Activation.NoEdit
                .Columns("SKU").CellActivation = Activation.NoEdit
                .Columns("Material").CellActivation = Activation.NoEdit
                .Columns("UMC").CellActivation = Activation.NoEdit
                .Columns("Proveedor").CellActivation = Activation.NoEdit
                .Columns("Precio Compra").CellActivation = Activation.NoEdit
                .Columns("UMP").CellActivation = Activation.NoEdit
                .Columns("Factor").CellActivation = Activation.NoEdit
                .Columns("PrecioUM").CellActivation = Activation.NoEdit
                .Columns("Costo X Par").CellActivation = Activation.NoEdit

                .Columns("Bloqueado").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Bloqueado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Bloqueado").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Bloqueado").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Explosionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Explosionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Explosionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Explosionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Lotear").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Lotear").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Lotear").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
                .Columns("Lotear").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

                .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
                .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                .Columns("Activo").Style = ColumnStyle.CheckBox
                .Columns("Activo").Header.Caption = "Activo"

                .Columns("Consumo").Format = "##,##0.00"
                .Columns("Precio Compra").Format = "$ ##,##0.00"
                .Columns("PrecioUM").Format = "$ ##,##0.00"
                .Columns("Costo X Par").Format = "$ ##,##0.00"

                .Columns("UMC").Header.Caption = "UMC"
                .Columns("UMP").Header.Caption = "UMP"
                .Columns("Precio Compra").Header.Caption = "Precio" & vbCrLf & "Compra"
                .Columns("PrecioUM").Header.Caption = "Precio" & vbCrLf & "UMC"
                .Columns("Orden").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Orden").CellActivation = Activation.NoEdit

                .Columns("Orden").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("PrecioUM").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                '.Columns("Precio").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Precio Compra").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Costo X Par").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Factor").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right



                If estatusArticulo.Trim = "DESCONTINUADO" Then
                    .Columns("Consumo").CellActivation = Activation.NoEdit
                    .Columns("Activo").CellActivation = Activation.NoEdit
                    grdConsumos.AllowDrop = False
                End If


                If tipoNave = "Desarrollo" Then
                    If estatusArticulo.Trim = "INACTIVO NAVE" Then
                        .Columns("Consumo").CellActivation = Activation.NoEdit
                        .Columns("Activo").CellActivation = Activation.NoEdit
                    End If
                End If

                If NAveDesarrollaID = idNaveConsulta Then
                    .Columns("Activo").CellActivation = Activation.AllowEdit
                Else
                    .Columns("Activo").CellActivation = Activation.NoEdit
                End If

            Catch ex As Exception

            End Try

        End With
        grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdConsumos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdConsumos.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

    End Sub

    Public Sub disenioConsumos()
        With grdConsumos.DisplayLayout.Bands(0)
            .Columns("productoEstiloId").Hidden = True
            .Columns("Editado").Hidden = True
            .Columns("idComponente").Hidden = True
            .Columns("idClasificacion").Hidden = True
            .Columns("IdMaterial").Hidden = True
            .Columns("idConsumo").Hidden = True
            .Columns("idProveedor").Hidden = True
            .Columns("idUMC").Hidden = True
            .Columns("idUMProd").Hidden = True

            .Columns("Componente").CellActivation = Activation.NoEdit
            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("IdMaterial").CellActivation = Activation.NoEdit
            .Columns("SKU").CellActivation = Activation.NoEdit
            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("UMC").CellActivation = Activation.NoEdit
            .Columns("Proveedor").CellActivation = Activation.NoEdit
            .Columns("Precio Compra").CellActivation = Activation.NoEdit
            .Columns("UMP").CellActivation = Activation.NoEdit
            .Columns("Factor").CellActivation = Activation.NoEdit
            .Columns("PrecioUM").CellActivation = Activation.NoEdit
            .Columns("Costo X Par").CellActivation = Activation.NoEdit

            .Columns("Bloqueado").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Bloqueado").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Bloqueado").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Bloqueado").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Explosionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Explosionar").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Explosionar").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Explosionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Lotear").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Lotear").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Lotear").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .Columns("Lotear").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False

            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            '.Columns("Seleccion").Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Activo").Style = ColumnStyle.CheckBox
            .Columns("Activo").Header.Caption = "Activo"

            .Columns("Consumo").Format = "##,##0.00"
            .Columns("Precio Compra").Format = "##,##0.00"
            .Columns("PrecioUM").Format = "##,##0.00"
            .Columns("Costo X Par").Format = "##,##0.00"
            .Columns("Orden").CellActivation = Activation.NoEdit

        End With
        grdConsumos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdConsumos.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub
    Public Sub leerimagen2(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String


            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picSuela.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picSuela.Image = Image.FromStream(Stream)
                picSuela.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub
    Public Sub leerimagen3(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String


            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picCaja.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picCaja.Image = Image.FromStream(Stream)
                picCaja.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub
    Public Sub leerimagen4(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String


            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picMarca.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picMarca.Image = Image.FromStream(Stream)
                picMarca.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If

    End Sub
    Public Sub leerimagen(ByVal imagen As String)
        If imagen <> "" Then
            Dim rutaImagen As String
            Dim nombreImagen As String

            rutaImagen = imagen
            nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picFotografia.Image = Image.FromStream(Stream)
                'picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        ElseIf imagen = "" Then
            imagen = "noimage.jpg"
            Try
                'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
                'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")
                Dim objFTP As New Tools.TransferenciaFTP
                Dim Stream As System.IO.Stream
                Stream = objFTP.StreamFile("/Administracion/Proveedores/", imagen)
                picFotografia.Image = Image.FromStream(Stream)
                picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            Catch
            End Try
        End If
    End Sub


    Public Sub CargarImagenesArticulo(ByVal Fotografia As String, ByVal Suela As String, ByVal Caja As String, ByVal Marca As String)

        'NOTA: HOY 14-12-2020 SE COMENTARON LINEAS DE CODIGO PORQUE AL MOMENTO DE QUE NO SE REGISTRABAN Y SE ASIGNABA UNA IMAGEN QUE NO 
        'EXISTIA POR DEFECTO, ESTA NO SE ENCONTRABA EN LAS CARPETAS DEL FTP Y MARCABA ERROR Y NO TERMINABA DE VERIFICAR QUE LAS DEMÁS 
        'SI EXISTIERAN, POR TAL MOTIVO SE COMENTAN.

        'Dim request = DirectCast(WebRequest.Create("ftp://192.168.7.16"), FtpWebRequest)
        'request.Credentials = New NetworkCredential("prod\yuyinerp", "yuyinerp")

        Dim objFTP As New Tools.TransferenciaFTP
        Dim Stream As System.IO.Stream
        Dim rutaImagen As String = String.Empty
        Dim nombreImagen As String = String.Empty


        Try
            If Fotografia <> "" Then
                rutaImagen = Fotografia
                nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
                rutaImagenForm = rutaImagen
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picFotografia.Image = Image.FromStream(Stream)
            Else
                Fotografia = "noimage.jpg"
                'Stream = objFTP.StreamFile("/Administracion/Proveedores/", Fotografia)
                'picFotografia.Image = Image.FromStream(Stream)
                picFotografia.SizeMode = PictureBoxSizeMode.StretchImage
            End If

            rutaImagen = ""
            nombreImagen = ""

            If Suela <> "" Then
                rutaImagen = Suela
                nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picSuela.Image = Image.FromStream(Stream)
            Else
                Suela = "noimage.jpg"
                'Stream = objFTP.StreamFile("/Administracion/Proveedores/", Suela)
                'picSuela.Image = Image.FromStream(Stream)
                picSuela.SizeMode = PictureBoxSizeMode.StretchImage
            End If

            rutaImagen = ""
            nombreImagen = ""

            If Caja <> "" Then
                rutaImagen = Caja
                nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picCaja.Image = Image.FromStream(Stream)
            Else
                Caja = "noimage.jpg"
                'Stream = objFTP.StreamFile("/Administracion/Proveedores/", Caja)
                'picCaja.Image = Image.FromStream(Stream)
                picCaja.SizeMode = PictureBoxSizeMode.StretchImage
            End If


            rutaImagen = ""
            nombreImagen = ""

            If Marca <> "" Then
                rutaImagen = Marca
                nombreImagen = rutaImagen.Substring(rutaImagen.LastIndexOf("\") + 1)
                Stream = objFTP.StreamFile("Programacion/Modelos/", nombreImagen)
                picMarca.Image = Image.FromStream(Stream)
            Else
                Marca = "noimage.jpg"
                'Stream = objFTP.StreamFile("/Administracion/Proveedores/", Marca)
                'picMarca.Image = Image.FromStream(Stream)
                picMarca.SizeMode = PictureBoxSizeMode.StretchImage
            End If

        Catch ex As Exception

        End Try





    End Sub

    Private Sub grdConsumos_AfterRowActivate(sender As Object, e As EventArgs) Handles grdConsumos.AfterRowActivate


        'For Each fila As UltraGridRow In grdConsumos.Rows
        '    If fila.Activated = True Then

        '        For Each fila2 As UltraGridRow In grdConsumos.Rows
        '            If fila2.Activated = True Or fila2.Selected = True Then
        '                fila2.RowSelectorAppearance.BackColor = Drawing.Color.LightSkyBlue
        '                'fila.RowSelectorAppearance.BackColor = Nothing
        '            End If
        '        Next


        '    End If


        'Next
    End Sub



    Private Sub grdConsumos_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grdConsumos.ClickCell

        'If e.Cell.IsFilterRowCell = False Then
        '    If e.Cell.Column.Key = "Activo" Then
        '        calcularTotales()
        '    End If

        'End If

    End Sub

    Private Sub grdConsumos_DragDrop(sender As Object, e As DragEventArgs) Handles grdConsumos.DragDrop
        Dim dropIndex As Integer

        'Get the position on the grid where the dragged row(s) are to be dropped. 
        'get the grid coordinates of the row (the drop zone) 
        Dim uieOver As UIElement = grdConsumos.DisplayLayout.UIElement.ElementFromPoint(grdConsumos.PointToClient(New Point(e.X, e.Y)))

        'get the row that is the drop zone/or where the dragged row is to be dropped 
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index    'index/position of drop zone in grid 
            If dropIndex < 0 Then
                dropIndex = 0

            End If
            'get the dragged row(s)which are to be dragged to another position in the grid 
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
            'get the count of selected rows and drop each starting at the dropIndex 
            For Each aRow As UltraGridRow In SelRows
                'move the selected row(s) to the drop zone 
                grdConsumos.Rows.Move(aRow, dropIndex)
            Next
        End If
        ActualizarOrdenConsumos()
        grdConsumos.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
        grdConsumos.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdConsumos.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing
        LimpiarColorSeleccionado()
    End Sub

    Private Sub grdConsumos_DragOver(sender As Object, e As DragEventArgs) Handles grdConsumos.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.grdConsumos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.grdConsumos.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If

        'LimpiarColorSeleccionado()
    End Sub


    Private Sub grdConsumos_KeyUp(sender As Object, e As KeyEventArgs) Handles grdConsumos.KeyUp
        If editar = True Then
            Exit Sub
        End If

        Dim listaMateriales As New List(Of Integer)
        CambioConsumos = False
        For value = 0 To grdConsumos.Rows.Count - 1
            Try
                listaMateriales.Add(grdConsumos.Rows(value).Cells("idMaterial").Value)
            Catch ex As Exception

            End Try
        Next

        'vLstMateriales.Clear()

        If estatusArticulo.Trim <> "DESCONTINUADO" Then
            'If tipoNave = "Desarrollo" And permisoModificar = True Then
            If permisoModificar = True Then

                If e.KeyCode = Keys.F1 Then
                    Dim a As String = ""
                    If Not grdConsumos.ActiveRow.IsFilterRow Then
                        Try
                            If grdConsumos.ActiveCell.Column.ToString = "Componente" And tipoNave = "Desarrollo" Then
                                'Mostrar ventana de componente
                                Dim form As New ListaComponentesForm
                                form.ShowDialog()

                                If form.idComponente > 0 Then 'Mostrar Clasificación
                                    grdConsumos.ActiveRow.Cells("idComponente").Value = form.idComponente
                                    grdConsumos.ActiveRow.Cells("Componente").Value = form.Componente
                                    Dim form2 As New ListaClasificacionesForm
                                    form2.idcomponente = grdConsumos.ActiveRow.Cells("idComponente").Text
                                    form2.ShowDialog()
                                    grdConsumos.ActiveRow.Cells("idClasificacion").Value = form2.idClasificacion
                                    grdConsumos.ActiveRow.Cells("Clasificación").Value = form2.Clasificacion
                                    grdConsumos.ActiveRow.Cells("idMaterial").Value = 0
                                    grdConsumos.ActiveRow.Cells("Material").Value = ""
                                    grdConsumos.ActiveRow.Cells("SKU").Value = ""
                                    grdConsumos.ActiveRow.Cells("idUMC").Value = 0
                                    grdConsumos.ActiveRow.Cells("UMC").Value = ""
                                    grdConsumos.ActiveRow.Cells("idProveedor").Value = 0
                                    grdConsumos.ActiveRow.Cells("Proveedor").Value = ""
                                    grdConsumos.ActiveRow.Cells("idUMProd").Value = 0
                                    grdConsumos.ActiveRow.Cells("UMP").Value = ""
                                    grdConsumos.ActiveRow.Cells("Factor").Value = 0
                                    grdConsumos.ActiveRow.Cells("Precio Compra").Value = 0
                                    grdConsumos.ActiveRow.Cells("PrecioUM").Value = 0
                                    If form2.idClasificacion > 0 Then
                                        Dim form3 As New listaMaterialesForm
                                        form3.clasificacion = grdConsumos.ActiveRow.Cells("idClasificacion").Value
                                        form3.nave = idNave
                                        form3.lista = listaMateriales
                                        form3.accion = "Desarrollo"
                                        form3.ProductoEstiloID = productoEstiloId
                                        form3.ShowDialog()
                                        If validarMaterial(form3.materialNaveid) Then
                                            grdConsumos.ActiveRow.Cells("idMaterial").Value = form3.materialNaveid
                                            grdConsumos.ActiveRow.Cells("Material").Value = form3.Material
                                            grdConsumos.ActiveRow.Cells("SKU").Value = form3.SKU
                                            grdConsumos.ActiveRow.Cells("idUMC").Value = form3.idUMC
                                            grdConsumos.ActiveRow.Cells("UMC").Value = form3.UMC
                                            grdConsumos.ActiveRow.Cells("idProveedor").Value = 0
                                            grdConsumos.ActiveRow.Cells("Proveedor").Value = ""
                                            grdConsumos.ActiveRow.Cells("idUMProd").Value = 0
                                            grdConsumos.ActiveRow.Cells("UMP").Value = ""
                                            grdConsumos.ActiveRow.Cells("Factor").Value = 0
                                            grdConsumos.ActiveRow.Cells("Precio Compra").Value = 0
                                            grdConsumos.ActiveRow.Cells("PrecioUM").Value = 0
                                            grdConsumos.ActiveRow.Cells("idProveedor").Value = form3.idProveedor
                                            grdConsumos.ActiveRow.Cells("Proveedor").Value = form3.Provedor
                                            grdConsumos.ActiveRow.Cells("idUMProd").Value = form3.idUMP
                                            grdConsumos.ActiveRow.Cells("UMP").Value = form3.UMP
                                            grdConsumos.ActiveRow.Cells("Factor").Value = Math.Round(form3.equivalencia, 2)
                                            grdConsumos.ActiveRow.Cells("Precio Compra").Value = Math.Round(form3.precio, 2)
                                            grdConsumos.ActiveRow.Cells("PrecioUM").Value = Math.Round(CDbl((form3.precio / form3.equivalencia)), 2)

                                            grdConsumos.ActiveCell = grdConsumos.ActiveRow.Cells("Consumo")

                                            grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                                            grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0

                                            grdConsumos.PerformAction(UltraGridAction.EnterEditMode, True, True)
                                        Else
                                            adv.mensaje = "Ya existe el material " & form3.Material & " para este artículo."
                                            adv.StartPosition = FormStartPosition.CenterScreen
                                            adv.ShowDialog()
                                        End If
                                    End If
                                End If
                                'Else
                                'adv.mensaje = "Ya existe el componente " & form.Componente & " para este artículo."
                                ' adv.StartPosition = FormStartPosition.CenterScreen
                                'adv.ShowDialog()
                                'End If

                            End If
                            If grdConsumos.ActiveCell.Column.ToString = "Clasificación" And tipoNave = "Desarrollo" Then
                                'Mostrar ventana de clasificación
                                Dim form As New ListaClasificacionesForm
                                form.idcomponente = grdConsumos.ActiveRow.Cells("idComponente").Text
                                form.ShowDialog()
                                If form.idClasificacion > 0 Then
                                    grdConsumos.ActiveRow.Cells("idClasificacion").Value = form.idClasificacion
                                    grdConsumos.ActiveRow.Cells("Clasificación").Value = form.Clasificacion
                                    grdConsumos.ActiveRow.Cells("idMaterial").Value = 0
                                    grdConsumos.ActiveRow.Cells("Material").Value = ""
                                    grdConsumos.ActiveRow.Cells("SKU").Value = ""
                                    grdConsumos.ActiveRow.Cells("idUMC").Value = 0
                                    grdConsumos.ActiveRow.Cells("UMC").Value = ""
                                    grdConsumos.ActiveRow.Cells("idProveedor").Value = 0
                                    grdConsumos.ActiveRow.Cells("Proveedor").Value = ""
                                    grdConsumos.ActiveRow.Cells("idUMProd").Value = 0
                                    grdConsumos.ActiveRow.Cells("UMP").Value = ""
                                    grdConsumos.ActiveRow.Cells("Factor").Value = 0
                                    grdConsumos.ActiveRow.Cells("Precio Compra").Value = 0
                                    grdConsumos.ActiveRow.Cells("PrecioUM").Value = 0
                                    'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                                End If
                                '   grdConsumos.ActiveRow.Cells("Consumo").Appearance.BackColor = Color.Salmon

                                CambioConsumos = True
                                grdConsumos.ActiveRow.Cells("Consumo").Appearance.BackColor = Color.Salmon

                                If IsNumeric(grdConsumos.ActiveRow.Cells("Consumo").Value) = True And IsNumeric(grdConsumos.ActiveRow.Cells("PrecioUM").Value) Then
                                    grdConsumos.ActiveRow.Cells("Costo X Par").Value = Math.Round(CDbl(grdConsumos.ActiveRow.Cells("PrecioUM").Value), 2) * CDbl(grdConsumos.ActiveRow.Cells("Consumo").Value)
                                Else
                                    grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
                                End If


                                'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                                'grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
                            End If
                            If grdConsumos.ActiveCell.Column.ToString = "SKU" Or grdConsumos.ActiveCell.Column.ToString = "Material" Then
                                'Mostrar ventana de materiales
                                Dim form As New listaMaterialesForm
                                form.clasificacion = grdConsumos.ActiveRow.Cells("idClasificacion").Value
                                form.ProductoEstiloID = productoEstiloId
                                form.nave = idNave
                                form.naveConsulta = idNaveConsulta
                                form.tipoNave = tipoNave

                                If accion = "Desarrollo" Then
                                    form.accion = "Desarrollo"
                                    form.ShowDialog()
                                    If validarMaterial(form.materialNaveid) Then
                                        If form.materialNaveid > 0 Then
                                            grdConsumos.ActiveRow.Cells("idMaterial").Value = form.materialNaveid
                                            grdConsumos.ActiveRow.Cells("Material").Value = form.Material
                                            grdConsumos.ActiveRow.Cells("SKU").Value = form.SKU
                                            grdConsumos.ActiveRow.Cells("idUMC").Value = form.idUMC
                                            grdConsumos.ActiveRow.Cells("UMC").Value = form.UMC
                                            grdConsumos.ActiveRow.Cells("idProveedor").Value = 0
                                            grdConsumos.ActiveRow.Cells("Proveedor").Value = ""
                                            grdConsumos.ActiveRow.Cells("idUMProd").Value = 0
                                            grdConsumos.ActiveRow.Cells("UMP").Value = ""
                                            grdConsumos.ActiveRow.Cells("Factor").Value = 0
                                            grdConsumos.ActiveRow.Cells("Precio Compra").Value = 0
                                            grdConsumos.ActiveRow.Cells("PrecioUM").Value = 0
                                            'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                                            grdConsumos.ActiveRow.Cells("idProveedor").Value = form.idProveedor
                                            grdConsumos.ActiveRow.Cells("Proveedor").Value = form.Provedor
                                            grdConsumos.ActiveRow.Cells("idUMProd").Value = form.idUMP
                                            grdConsumos.ActiveRow.Cells("UMP").Value = form.UMP
                                            grdConsumos.ActiveRow.Cells("Factor").Value = form.equivalencia
                                            grdConsumos.ActiveRow.Cells("Precio Compra").Value = Math.Round(form.precio, 2)
                                            grdConsumos.ActiveRow.Cells("PrecioUM").Value = Math.Round((form.precio / form.equivalencia), 2)
                                            grdConsumos.ActiveCell = grdConsumos.ActiveRow.Cells("Consumo")
                                            grdConsumos.PerformAction(UltraGridAction.EnterEditMode, True, True)

                                            Dim vMateriales As MaterialConsumos = New MaterialConsumos

                                            vMateriales.PIdMaterial = form.materialNaveid
                                            vMateriales.PMaterial = form.Material
                                            vMateriales.PSKU = form.SKU
                                            vMateriales.PIdUMC = form.idUMC
                                            vMateriales.PUMC = form.UMC
                                            vMateriales.PIdProveedor = form.idProveedor
                                            vMateriales.PProveedor = form.Provedor
                                            vMateriales.PIdUmProduccion = form.idUMP
                                            vMateriales.PUMP = form.UMP
                                            vMateriales.PFactor = form.equivalencia
                                            vMateriales.PPrecioCompra = Math.Round(form.precio, 2)
                                            vMateriales.PPrecioUm = Math.Round((form.precio / form.equivalencia), 2)

                                            vLstMateriales.Add(vMateriales)

                                        End If
                                    Else
                                        adv.mensaje = "Ya existe el material " & form.Material & " para este artículo."
                                        adv.StartPosition = FormStartPosition.CenterScreen
                                        adv.ShowDialog()
                                    End If
                                Else
                                    form.accion = "Produccion"
                                    form.ShowDialog()
                                    If form.materialNaveid > 0 Then
                                        grdConsumos.ActiveRow.Cells("idMaterial").Value = form.materialNaveid
                                        grdConsumos.ActiveRow.Cells("Material").Value = form.Material
                                        grdConsumos.ActiveRow.Cells("SKU").Value = form.SKU
                                        grdConsumos.ActiveRow.Cells("idUMC").Value = form.idUMC
                                        grdConsumos.ActiveRow.Cells("UMC").Value = form.UMC
                                        grdConsumos.ActiveRow.Cells("idProveedor").Value = form.idProveedor
                                        grdConsumos.ActiveRow.Cells("Proveedor").Value = form.Provedor
                                        grdConsumos.ActiveRow.Cells("idUMProd").Value = form.idUMP
                                        grdConsumos.ActiveRow.Cells("UMP").Value = form.UMP
                                        grdConsumos.ActiveRow.Cells("Factor").Value = form.equivalencia
                                        grdConsumos.ActiveRow.Cells("Precio Compra").Value = Math.Round(form.precio, 2)
                                        grdConsumos.ActiveRow.Cells("PrecioUM").Value = Math.Round((form.precio / form.equivalencia), 2)


                                        'grdConsumos.ActiveRow.Cells("Consumo").Value = 0

                                        Dim vMateriales As MaterialConsumos = New MaterialConsumos

                                        vMateriales.PIdMaterial = form.materialNaveid
                                        vMateriales.PMaterial = form.Material
                                        vMateriales.PSKU = form.SKU
                                        vMateriales.PIdUMC = form.idUMC
                                        vMateriales.PUMC = form.UMC
                                        vMateriales.PIdProveedor = form.idProveedor
                                        vMateriales.PProveedor = form.Provedor
                                        vMateriales.PIdUmProduccion = form.idUMP
                                        vMateriales.PUMP = form.UMP
                                        vMateriales.PFactor = form.equivalencia
                                        vMateriales.PPrecioCompra = Math.Round(form.precio, 2)
                                        vMateriales.PPrecioUm = Math.Round((form.precio / form.equivalencia), 2)

                                        vLstMateriales.Add(vMateriales)



                                    End If

                                End If

                                CambioConsumos = True
                                grdConsumos.ActiveRow.Cells("Consumo").Appearance.BackColor = Color.Salmon

                                If IsNumeric(grdConsumos.ActiveRow.Cells("Consumo").Value) = True And IsNumeric(grdConsumos.ActiveRow.Cells("PrecioUM").Value) Then
                                    grdConsumos.ActiveRow.Cells("Costo X Par").Value = Math.Round(CDbl(grdConsumos.ActiveRow.Cells("PrecioUM").Value), 2) * CDbl(grdConsumos.ActiveRow.Cells("Consumo").Value)
                                Else
                                    grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
                                End If

                                'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                                'grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
                            End If
                            'If grdConsumos.ActiveCell.Column.ToString = "Proveedor" Then
                            '    'Mostrar ventana de proveedor
                            '    Dim form As New ListaProveedoresForm
                            '    form.materialNaveid = grdConsumos.ActiveRow.Cells("idMaterial").Value
                            '    form.nave = idNave
                            '    form.ShowDialog()
                            '    If form.idProveedor > 0 Then
                            '        grdConsumos.ActiveRow.Cells("idProveedor").Value = form.idProveedor
                            '        grdConsumos.ActiveRow.Cells("Proveedor").Value = form.Provedor
                            '        grdConsumos.ActiveRow.Cells("idUMProd").Value = form.idUMP
                            '        grdConsumos.ActiveRow.Cells("UMP").Value = form.UMP
                            '        grdConsumos.ActiveRow.Cells("Factor").Value = form.equivalencia
                            '        grdConsumos.ActiveRow.Cells("Precio Compra").Value = form.precio
                            '        grdConsumos.ActiveRow.Cells("PrecioUM").Value = (form.precio / form.equivalencia)
                            '        grdConsumos.ActiveCell = grdConsumos.ActiveRow.Cells("Consumo")
                            '        grdConsumos.PerformAction(UltraGridAction.EnterEditMode, True, True)
                            '    End If

                            '    grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                            '    grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
                            'End If
                        Catch ex As Exception

                        End Try
                    End If

                ElseIf e.KeyCode = Keys.Enter Then
                    Try
                        If grdConsumos.Rows(grdConsumos.Rows.Count - 1).Cells("idProveedor").Text <> "" And grdConsumos.Rows(grdConsumos.Rows.Count - 1).Cells("idComponente").Text <> "" And grdConsumos.Rows(grdConsumos.Rows.Count - 1).Cells("idMaterial").Text <> "" And tipoNave = "Desarrollo" Then
                            grdConsumos.DisplayLayout.Bands(0).AddNew()
                            grdConsumos.ActiveRow.Cells("Activo").Value = 1
                            grdConsumos.ActiveRow.Cells("Editado").Value = 0
                            grdConsumos.ActiveRow.Cells("idConsumo").Value = 0
                            grdConsumos.ActiveRow.Cells("Bloqueado").Value = CBool(False)
                            grdConsumos.ActiveRow.Cells("Explosionar").Value = CBool(False)
                            grdConsumos.ActiveRow.Cells("Lotear").Value = CBool(False)
                            grdConsumos.ActiveRow.Cells("Componente").Selected = True
                            grdConsumos.ActiveRow.Cells("Orden").Value = grdConsumos.Rows.Count
                        End If

                    Catch ex As Exception

                    End Try
                ElseIf e.KeyCode = Keys.Back Then
                    Try
                        If grdConsumos.ActiveRow.Selected = True Then
                            If grdConsumos.ActiveRow.Cells("idConsumo").Value = 0 Then
                                borrar = True
                                grdConsumos.ActiveRow.Delete()
                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    'Else
                    '    If IsNumeric(grdConsumos.ActiveRow.Cells("PrecioUM").Value) = True And IsNumeric(grdConsumos.ActiveRow.Cells("Consumo").Value) = True Then
                    '        grdConsumos.ActiveRow.Cells("Costo X Par").Value = (grdConsumos.ActiveRow.Cells("PrecioUM").Value * grdConsumos.ActiveRow.Cells("Consumo").Value)

                    '    End If

                End If
                'pintarceldas()
            End If

        ElseIf estatusArticulo.Trim() = "INACTIVO NAVE" Then


            If grdConsumos.ActiveCell.Column.ToString = "SKU" Or grdConsumos.ActiveCell.Column.ToString = "Material" Then
                'Mostrar ventana de materiales
                Dim form As New listaMaterialesForm
                form.clasificacion = grdConsumos.ActiveRow.Cells("idClasificacion").Value
                form.nave = idNave
                form.ProductoEstiloID = productoEstiloId
                If accion = "Desarrollo" Then
                    form.accion = "Desarrollo"
                    form.ShowDialog()
                    If validarMaterial(form.materialNaveid) Then
                        If form.materialNaveid > 0 Then
                            grdConsumos.ActiveRow.Cells("idMaterial").Value = form.materialNaveid
                            grdConsumos.ActiveRow.Cells("Material").Value = form.Material
                            grdConsumos.ActiveRow.Cells("SKU").Value = form.SKU
                            grdConsumos.ActiveRow.Cells("idUMC").Value = form.idUMC
                            grdConsumos.ActiveRow.Cells("UMC").Value = form.UMC
                            grdConsumos.ActiveRow.Cells("idProveedor").Value = 0
                            grdConsumos.ActiveRow.Cells("Proveedor").Value = ""
                            grdConsumos.ActiveRow.Cells("idUMProd").Value = 0
                            grdConsumos.ActiveRow.Cells("UMP").Value = ""
                            grdConsumos.ActiveRow.Cells("Factor").Value = 0
                            grdConsumos.ActiveRow.Cells("Precio Compra").Value = 0
                            grdConsumos.ActiveRow.Cells("PrecioUM").Value = 0
                            'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                            grdConsumos.ActiveRow.Cells("idProveedor").Value = form.idProveedor
                            grdConsumos.ActiveRow.Cells("Proveedor").Value = form.Provedor
                            grdConsumos.ActiveRow.Cells("idUMProd").Value = form.idUMP
                            grdConsumos.ActiveRow.Cells("UMP").Value = form.UMP
                            grdConsumos.ActiveRow.Cells("Factor").Value = form.equivalencia
                            grdConsumos.ActiveRow.Cells("Precio Compra").Value = form.precio
                            grdConsumos.ActiveRow.Cells("PrecioUM").Value = (form.precio / form.equivalencia)
                            grdConsumos.ActiveCell = grdConsumos.ActiveRow.Cells("Consumo")
                            grdConsumos.PerformAction(UltraGridAction.EnterEditMode, True, True)
                        End If
                    Else
                        adv.mensaje = "Ya existe el material " & form.Material & " para este artículo."
                        adv.StartPosition = FormStartPosition.CenterScreen
                        adv.ShowDialog()
                    End If
                Else
                    form.accion = "Produccion"
                    form.ShowDialog()
                    If form.materialNaveid > 0 Then
                        grdConsumos.ActiveRow.Cells("idMaterial").Value = form.materialNaveid
                        grdConsumos.ActiveRow.Cells("Material").Value = form.Material
                        grdConsumos.ActiveRow.Cells("SKU").Value = form.SKU
                        grdConsumos.ActiveRow.Cells("idUMC").Value = form.idUMC
                        grdConsumos.ActiveRow.Cells("UMC").Value = form.UMC
                        grdConsumos.ActiveRow.Cells("idProveedor").Value = 0
                        grdConsumos.ActiveRow.Cells("Proveedor").Value = ""
                        grdConsumos.ActiveRow.Cells("idUMProd").Value = 0
                        grdConsumos.ActiveRow.Cells("UMP").Value = ""
                        grdConsumos.ActiveRow.Cells("Factor").Value = 0
                        grdConsumos.ActiveRow.Cells("Precio Compra").Value = 0
                        grdConsumos.ActiveRow.Cells("PrecioUM").Value = 0
                        'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                    End If

                End If

                'grdConsumos.ActiveRow.Cells("Consumo").Value = 0
                grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
            End If


        End If
        calcularTotales()
    End Sub
    Private Function nuevoconsumo() As Boolean
        Dim d As New DataTable
        d = grdConsumos.DataSource

        For Each Fila As UltraGridRow In grdConsumos.Rows
            Try
                If Fila.Cells("idComponente").Value = 0 Then
                    Return False
                End If
                If Fila.Cells("idclasificacion").Value = 0 Then
                    Return False
                End If
                If Fila.Cells("IdMaterial").Value = 0 Then
                    Return False
                End If
                If Fila.Cells("idUMC").Value = 0 Then
                    Return False
                End If
                If Fila.Cells("idProveedor").Value = 0 Then
                    Return False
                End If
                If Fila.Cells("Consumo").Value <= 0 Then
                    Return False
                End If
            Catch ex As Exception
                Return True
            End Try
        Next

        'For Each row As DataRow In d.Rows
        '    Try
        '        If row("idComponente") = 0 Then
        '            Return False
        '        End If
        '        If row("idclasificacion") = 0 Then
        '            Return False
        '        End If
        '        If row("IdMaterial") = 0 Then
        '            Return False
        '        End If
        '        If row("idUMC") = 0 Then
        '            Return False
        '        End If
        '        If row("idProveedor") = 0 Then
        '            Return False
        '        End If
        '        If row("Consumo") <= 0 Then
        '            Return False
        '        End If
        '    Catch ex As Exception
        '        Return True
        '    End Try
        'Next

        Return True
    End Function
    Private Function ValidaHayFracciones() As Boolean
        Dim cuenta As Integer = 0

        For Each Fila As UltraGridRow In grdFracciones.Rows
            If Fila.Cells("Activo").Value Then
                cuenta += 1
            End If
        Next
        If cuenta = 0 Then
            Return False
        Else
            Return True
        End If
    End Function


    Private Function nuevofraccion() As Boolean
        Dim d As New DataTable

        d = grdFracciones.DataSource
        For Each Fila As UltraGridRow In grdFracciones.Rows
            Try
                If Fila.Cells("idFraccion").Value = 0 Then
                    Return False
                End If
            Catch ex As Exception
                Return True
            End Try
        Next

        'For Each row As DataRow In d.Rows
        '    Try
        '        If row("idFraccion") = 0 Then
        '            Return False
        '        End If
        '    Catch ex As Exception
        '        Return True
        '    End Try
        'Next
        Return True
    End Function
    Private Sub guardarFraccionesProduccion()
        Dim fraccion As New Fracciones
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Try
            datos = grdFracciones.DataSource
            Me.Cursor = Cursors.WaitCursor
            For value = 0 To grdFracciones.Rows.Count - 1
                Try
                    fraccion = New Fracciones
                    'consumo.bloqueado = CBool(row("Bloqueado"))
                    fraccion.productoEstiloId = productoEstiloId
                    fraccion.frap_fraccionid = grdFracciones.Rows(value).Cells("idFraccion").Text
                    fraccion.fraccionidProd = grdFracciones.Rows(value).Cells("idFraccDes").Text
                    fraccion.frap_precio = grdFracciones.Rows(value).Cells("Costo").Text
                    fraccion.frap_paga = Convert.ToInt32(grdFracciones.Rows(value).Cells("Pagar").Value)
                    fraccion.sumar_Costo = Convert.ToInt32(grdFracciones.Rows(value).Cells("Sumar Costo").Value)
                    fraccion.sumar_Tiempo = Convert.ToInt32(grdFracciones.Rows(value).Cells("Sumar Tiempo").Value)
                    If grdFracciones.Rows(value).Cells("Horas").Text = "" Then
                        fraccion.horas_ = 0
                    Else
                        fraccion.horas_ = grdFracciones.Rows(value).Cells("Horas").Text
                    End If
                    If grdFracciones.Rows(value).Cells("Minutos").ToString = "" Then
                        fraccion.minutos_ = 0
                    Else
                        fraccion.minutos_ = grdFracciones.Rows(value).Cells("Minutos").Text
                    End If
                    If grdFracciones.Rows(value).Cells("Segundos").ToString = "" Then
                        fraccion.segundos_ = 0
                    Else
                        fraccion.segundos_ = grdFracciones.Rows(value).Cells("Segundos").Text
                    End If
                    If CBool(grdFracciones.Rows(value).Cells("Activo").Text) Then
                        fraccion.frap_activo = 1
                    Else
                        fraccion.frap_activo = 0
                    End If
                    If grdFracciones.Rows(value).Cells("idFraccDes").Text = 0 Then
                        fraccion.accion = 1
                    Else
                        fraccion.accion = 2
                    End If
                    fraccion.frap_activo = grdFracciones.Rows(value).Cells("Activo").Value
                    obj.insertFraccionProd(fraccion)
                Catch ex As Exception

                End Try

            Next
            getDatosFracciones()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub

    Private Sub guardarFraccionesDesarrollo()
        Dim fraccion As New Fracciones
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        Dim fraccionActual As Integer = 0
        '  grdFracciones.DisplayLayout.Bands(0).AddNew()
        Try
            datos = grdFracciones.DataSource

            If validarFraccionRepetidaConObservaciones() Then
                Me.Cursor = Cursors.WaitCursor


                For Each Fila As UltraGridRow In grdFracciones.Rows
                    Try

                        fraccion = New Fracciones
                        'consumo.bloqueado = CBool(row("Bloqueado"))
                        fraccion.productoEstiloId = productoEstiloId
                        fraccion.frap_fraccionid = Fila.Cells("idFraccion").Value
                        fraccion.fraccionidProd = Fila.Cells("idFraccDes").Value
                        fraccion.frap_precio = Fila.Cells("Costo").Value
                        fraccion.frap_paga = Convert.ToInt32(Fila.Cells("Pagar").Value)
                        fraccion.sumar_Costo = Convert.ToInt32(Fila.Cells("Sumar Costo").Value)
                        fraccion.sumar_Tiempo = Convert.ToInt32(Fila.Cells("Sumar Tiempo").Value)
                        If Fila.Cells("Horas").Value.ToString = "" Then
                            fraccion.horas_ = 0
                        Else
                            fraccion.horas_ = Fila.Cells("Horas").Value.ToString
                        End If
                        If Fila.Cells("Minutos").Value.ToString = "" Then
                            fraccion.minutos_ = 0
                        Else
                            fraccion.minutos_ = Fila.Cells("Minutos").Value.ToString
                        End If
                        If Fila.Cells("Segundos").Value.ToString = "" Then
                            fraccion.segundos_ = 0
                        Else
                            fraccion.segundos_ = Fila.Cells("Segundos").Value.ToString
                        End If
                        If CBool(Fila.Cells("Activo").Value) Then
                            fraccion.frap_activo = 1
                        Else
                            fraccion.frap_activo = 0
                        End If
                        If Fila.Cells("idFraccDes").Value = 0 Then
                            fraccion.accion = 1
                        Else
                            fraccion.accion = 2
                        End If
                        fraccion.idNave = idNaveConsulta
                        Try
                            fraccion.observaciones = Fila.Cells("Observaciones").Value.ToString.ToUpper()
                        Catch ex As Exception
                            fraccion.observaciones = ""
                        End Try
                        Try
                            fraccion.maquinariaid = Fila.Cells("maquinaid").Value
                        Catch ex As Exception
                            fraccion.maquinariaid = 0
                        End Try
                        fraccionActual = IIf(IsDBNull(Fila.Cells("idFraccDesActual").Value), 0, Fila.Cells("idFraccDesActual").Value)
                        Dim dato As New DataTable
                        Dim elimFraccion As New DataTable


                        '20/05/2020
                        dato = obj.insertFraccionDesNueva(fraccion, fraccionActual)
                        '   dato = obj.insertFraccionDes(fraccion)


                        fraccion.noOrden = Fila.Cells("Orden").Value
                        If fraccion.fraccionidProd = 0 And fraccionActual = 0 Then
                            Try
                                fraccion.fraccionidProd = CInt(dato.Rows(0).Item(0).ToString)
                                obj.inserOrdenamientoFracion(fraccion)
                                ' elimFraccion = obj.EliminarFraccionOri(idFraccionOriginal, CInt(dato.Rows(0).Item(0).ToString), 2)
                            Catch ex As Exception
                            End Try
                        ElseIf fraccion.fraccionidProd = 0 And fraccionActual > 0 Then
                            Try
                                fraccion.fraccionidProd = CInt(dato.Rows(0).Item(0).ToString)
                                obj.inserOrdenamientoFracion(fraccion)
                                ' elimFraccion = obj.EliminarFraccionOri(idFraccionOriginal, CInt(dato.Rows(0).Item(0).ToString), 2)
                            Catch ex As Exception
                            End Try
                        Else
                            obj.inserOrdenamientoFracion(fraccion) '20/05/2020
                        End If
                    Catch ex As Exception

                    End Try
                Next

                getDatosFracciones()
                Me.Cursor = Cursors.Default

                'For value = 0 To grdFracciones.Rows.Count - 1
                '    Try
                '        fraccion = New Fracciones
                '        'consumo.bloqueado = CBool(row("Bloqueado"))
                '        fraccion.productoEstiloId = productoEstiloId
                '        fraccion.frap_fraccionid = grdFracciones.Rows(value).Cells("idFraccion").Value
                '        fraccion.fraccionidProd = grdFracciones.Rows(value).Cells("idFraccDes").Text
                '        fraccion.frap_precio = grdFracciones.Rows(value).Cells("Costo").Text
                '        fraccion.frap_paga = Convert.ToInt32(grdFracciones.Rows(value).Cells("Pagar").Value)
                '        fraccion.sumar_Costo = Convert.ToInt32(grdFracciones.Rows(value).Cells("Sumar Costo").Value)
                '        fraccion.sumar_Tiempo = Convert.ToInt32(grdFracciones.Rows(value).Cells("Sumar Tiempo").Value)
                '        If grdFracciones.Rows(value).Cells("Horas").Text = "" Then
                '            fraccion.horas_ = 0
                '        Else
                '            fraccion.horas_ = grdFracciones.Rows(value).Cells("Horas").Text
                '        End If
                '        If grdFracciones.Rows(value).Cells("Minutos").Text = "" Then
                '            fraccion.minutos_ = 0
                '        Else
                '            fraccion.minutos_ = grdFracciones.Rows(value).Cells("Minutos").Text
                '        End If
                '        If grdFracciones.Rows(value).Cells("Segundos").Text = "" Then
                '            fraccion.segundos_ = 0
                '        Else
                '            fraccion.segundos_ = grdFracciones.Rows(value).Cells("Segundos").Text
                '        End If
                '        If CBool(grdFracciones.Rows(value).Cells("Activo").Text) Then
                '            fraccion.frap_activo = 1
                '        Else
                '            fraccion.frap_activo = 0
                '        End If
                '        If grdFracciones.Rows(value).Cells("idFraccDes").Text = 0 Then
                '            fraccion.accion = 1
                '        Else
                '            fraccion.accion = 2
                '        End If
                '        fraccion.idNave = idNaveConsulta
                '        Try
                '            fraccion.observaciones = grdFracciones.Rows(value).Cells("Observaciones").Text.ToString.ToUpper()
                '        Catch ex As Exception
                '            fraccion.observaciones = ""
                '        End Try
                '        Try
                '            fraccion.maquinariaid = grdFracciones.Rows(value).Cells("maquinaid").Value
                '        Catch ex As Exception
                '            fraccion.maquinariaid = 0
                '        End Try

                '        Dim dato As New DataTable
                '        dato = obj.insertFraccionDes(fraccion)
                '        fraccion.noOrden = grdFracciones.Rows(value).Cells("Orden").Value
                '        If fraccion.fraccionidProd = 0 Then
                '            Try
                '                fraccion.fraccionidProd = CInt(dato.Rows(0).Item(0).ToString)
                '                obj.inserOrdenamientoFracion(fraccion)
                '            Catch ex As Exception
                '            End Try
                '        Else
                '            obj.inserOrdenamientoFracion(fraccion)
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'getDatosFracciones()
                'Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub
    Function validarFraccionRepetidaConObservaciones() As Boolean
        Dim d1, d2 As New DataTable
        d1 = grdFracciones.DataSource
        d2 = d1
        Dim bandera As Integer = 0

        For Each Fila As UltraGridRow In grdFracciones.Rows
            bandera = 0
            If Not IsDBNull(Fila.Cells("Activo").Value) Then
                If Fila.Cells("Activo").Value Then
                    If Not IsDBNull(Fila.Cells("idFraccion").Value) Then
                        If Fila.Cells("idFraccion").Value <> 0 Then

                            For Each Fila2 As UltraGridRow In grdFracciones.Rows
                                If Not IsDBNull(Fila2.Cells("Activo").Value) Then
                                    If Fila2.Cells("Activo").Value Then
                                        If Not IsDBNull(Fila2.Cells("idFraccion").Value) Then
                                            If Fila2.Cells("idFraccion").Value <> 0 Then
                                                If (Fila.Cells("idFraccion").Value = Fila2.Cells("idFraccion").Value And Fila.Cells("Observaciones").Value.ToString = Fila2.Cells("Observaciones").Value.ToString) Or (Fila.Cells("idFraccion").Value = Fila2.Cells("idFraccion").Value And Fila.Cells("Observaciones").Value.ToString <> Fila2.Cells("Observaciones").Value.ToString) Then
                                                    bandera += 1
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            End If

            If bandera = 2 Then
                adv.mensaje = "Existen fracciones repetidas."
                adv.ShowDialog()
                Return False
            End If

        Next

        'For Each row1 As DataRow In d1.Rows
        '    bandera = 0
        '    If Not IsDBNull(row1("Activo")) Then
        '        If row1("Activo") Then
        '            If Not IsDBNull(row1("idFraccion")) Then
        '                If row1("idFraccion") <> 0 Then
        '                    For Each row2 As DataRow In d2.Rows
        '                        If Not IsDBNull(row2("Activo")) Then
        '                            If row2("Activo") Then
        '                                If Not IsDBNull(row2("idFraccion")) Then
        '                                    If row2("idFraccion") <> 0 Then
        '                                        If row1("idFraccion") = row2("idFraccion") And row1("Observaciones").ToString = row2("Observaciones").ToString Then
        '                                            bandera += 1
        '                                        End If
        '                                    End If
        '                                End If
        '                            End If
        '                        End If
        '                    Next
        '                End If
        '            End If
        '        End If
        '    End If
        '    If bandera = 2 Then
        '        adv.mensaje = "Existen fracciones repetidas con las mismas observaciones."
        '        adv.ShowDialog()
        '        Return False
        '    End If
        'Next


        banderaGuardadoFRacciones = True
        Return True
    End Function

    Private Sub guardarConsumosDesarrollo()
        Dim consumo As New Consumo
        Dim obj As New ConsumosBU
        Dim datos As New DataTable
        ' grdConsumos.DisplayLayout.Bands(0).AddNew()
        Try

            Me.Cursor = Cursors.WaitCursor

            For Each Fila As UltraGridRow In grdConsumos.Rows
                Try
                    consumo = New Consumo
                    consumo.bloqueado = CBool(Fila.Cells("Bloqueado").Text)
                    consumo.explosionar = CBool(Fila.Cells("Explosionar").Text)
                    consumo.lotear = CBool(Fila.Cells("Lotear").Text)
                    consumo.componenteid = Fila.Cells("idComponente").Text
                    consumo.clasificacionid = Fila.Cells("idclasificacion").Text
                    consumo.materialId = Fila.Cells("IdMaterial").Text
                    consumo.idconsumo = Fila.Cells("idConsumo").Text
                    consumo.umproduccionid = Fila.Cells("idUMProd").Text   '-este ID pertenece al de producción
                    consumo.proveedorId = Fila.Cells("idProveedor").Text
                    consumo.costopar = Fila.Cells("Costo X Par").Text
                    consumo.productoEstiloId = productoEstiloId
                    consumo.consumo = Fila.Cells("Consumo").Text
                    consumo.umProveedorId = Fila.Cells("idUMC").Text '-este ID pertenece al de proveedor
                    consumo.precioumproduccion = Fila.Cells("PrecioUM").Text
                    consumo.factorconversion = Fila.Cells("Factor").Text
                    consumo.preciocompra = Fila.Cells("Precio Compra").Text


                    Dim x = Fila.Cells("Activo").Value
                    consumo.activo = Fila.Cells("Activo").Value
                    If Fila.Cells("idConsumo").Text = 0 Then
                        consumo.accion = 1
                    Else
                        consumo.accion = 2
                    End If
                    Dim dato As New DataTable
                    dato = obj.insertConsumo(consumo, idNaveConsulta) 'Trae el id que inserto si fue un insert en el consumo
                    consumo.noOrden = Fila.Cells("Orden").Text
                    If Fila.Cells("idConsumo").Text = 0 Then
                        Try
                            consumo.idconsumo = CInt(dato.Rows(0).Item(0).ToString)
                            obj.inserOrdenamientoConsumo(consumo)
                        Catch ex As Exception
                        End Try
                    Else
                        obj.inserOrdenamientoConsumo(consumo)
                    End If

                Catch ex As Exception

                End Try

            Next

            'For Each row As DataRow In datos.Rows
            '    Try
            '        consumo = New Consumo
            '        consumo.bloqueado = CBool(row("Bloqueado"))
            '        consumo.explosionar = CBool(row("Explosionar"))
            '        consumo.lotear = CBool(row("Lotear"))
            '        consumo.componenteid = row("idComponente")
            '        consumo.clasificacionid = row("idclasificacion")
            '        consumo.materialId = row("IdMaterial")
            '        consumo.idconsumo = row("idConsumo")
            '        consumo.umproduccionid = row("idUMProd") '-este ID pertenece al de producción
            '        consumo.proveedorId = row("idProveedor")
            '        consumo.costopar = row("Costo X Par")
            '        consumo.productoEstiloId = productoEstiloId
            '        consumo.consumo = row("Consumo")
            '        consumo.umProveedorId = row("idUMC") '-este ID pertenece al de proveedor
            '        consumo.precioumproduccion = row("PrecioUM")
            '        consumo.factorconversion = row("Factor")
            '        consumo.preciocompra = row("Precio Compra")

            '        Dim x = row("Activo")
            '        consumo.activo = row("Activo")
            '        If row("idConsumo") = 0 Then
            '            consumo.accion = 1
            '        Else
            '            consumo.accion = 2
            '        End If
            '        Dim dato As New DataTable
            '        dato = obj.insertConsumo(consumo) 'Trae el id que inserto si fue un insert en el consumo
            '        consumo.noOrden = row("Orden")
            '        If row("idConsumo") = 0 Then
            '            Try
            '                consumo.idconsumo = CInt(dato.Rows(0).Item(0).ToString)
            '                obj.inserOrdenamientoConsumo(consumo)
            '            Catch ex As Exception
            '            End Try
            '        Else
            '            obj.inserOrdenamientoConsumo(consumo)
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Next

            '=======================================================
            'datos = grdConsumos.DataSource
            'Me.Cursor = Cursors.WaitCursor
            'For Each row As DataRow In datos.Rows
            '    Try
            '        consumo = New Consumo
            '        consumo.bloqueado = CBool(row("Bloqueado"))
            '        consumo.explosionar = CBool(row("Explosionar"))
            '        consumo.lotear = CBool(row("Lotear"))
            '        consumo.componenteid = row("idComponente")
            '        consumo.clasificacionid = row("idclasificacion")
            '        consumo.materialId = row("IdMaterial")
            '        consumo.idconsumo = row("idConsumo")
            '        consumo.umproduccionid = row("idUMProd") '-este ID pertenece al de producción
            '        consumo.proveedorId = row("idProveedor")
            '        consumo.costopar = row("Costo X Par")
            '        consumo.productoEstiloId = productoEstiloId
            '        consumo.consumo = row("Consumo")
            '        consumo.umProveedorId = row("idUMC") '-este ID pertenece al de proveedor
            '        consumo.precioumproduccion = row("PrecioUM")
            '        consumo.factorconversion = row("Factor")
            '        consumo.preciocompra = row("Precio Compra")

            '        Dim x = row("Activo")
            '        consumo.activo = row("Activo")
            '        If row("idConsumo") = 0 Then
            '            consumo.accion = 1
            '        Else
            '            consumo.accion = 2
            '        End If
            '        Dim dato As New DataTable
            '        dato = obj.insertConsumo(consumo) 'Trae el id que inserto si fue un insert en el consumo
            '        consumo.noOrden = row("Orden")
            '        If row("idConsumo") = 0 Then
            '            Try
            '                consumo.idconsumo = CInt(dato.Rows(0).Item(0).ToString)
            '                obj.inserOrdenamientoConsumo(consumo)
            '            Catch ex As Exception
            '            End Try
            '        Else
            '            obj.inserOrdenamientoConsumo(consumo)
            '        End If
            '    Catch ex As Exception

            '    End Try
            'Next

            '=======================================================


            getDatosConsumos()
            pintarceldas()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
        End Try

    End Sub

    Private Sub grdConsumos_BeforeCellUpdate(sender As Object, e As BeforeCellUpdateEventArgs) Handles grdConsumos.BeforeCellUpdate
        If ImportarConsumos = False Then
            If e.Cell.Column.ToString = "Consumo" Or e.Cell.Column.ToString = "Costo X Par" Then
                Try
                    Convert.ToDouble(e.NewValue)
                    validaConsumo = True
                Catch ex As Exception
                    e.Cancel = True
                    validaConsumo = False
                    adv.mensaje = "Ingrese un número válido."
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                End Try
            End If
        End If

    End Sub

    Private Sub grdConsumos_KeyPress(sender As Object, e As KeyPressEventArgs)
        If grdConsumos.Rows.Count > 0 Then
            Try
                If Not grdConsumos.ActiveCell.IsFilterRowCell Then
                    If grdConsumos.ActiveCell.Column.ToString = "Orden" Then
                        If Char.IsDigit(e.KeyChar) Then
                            e.Handled = False
                        ElseIf Char.IsControl(e.KeyChar) Then
                            e.Handled = False
                        Else
                            e.Handled = True
                        End If

                    Else
                        If Char.IsDigit(e.KeyChar) Then
                            e.Handled = False
                        ElseIf Char.IsControl(e.KeyChar) Then
                            e.Handled = False
                        ElseIf e.KeyChar = "." Then
                            e.Handled = False
                        Else
                            e.Handled = True
                        End If
                    End If

                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Public Sub GuardarImagen()
        Try
            Dim obj As New ConsumosBU

            If suela.Length > 0 Then
                obj.ActualizarImagenes(codigoProd & "/" & suela, "",
                                  "", productoEstiloId)
            End If
            If caja.Length > 0 Then
                obj.ActualizarImagenes("", codigoProd & "/" & caja,
                                      "", productoEstiloId)
            End If
            If marca.Length > 0 Then
                obj.ActualizarImagenes("", "",
                                      codigoProd & "/" & marca, productoEstiloId)
            End If

            Dim objFTP As New Tools.TransferenciaFTP
            ''Crea la carpeta
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd & "/", "")

            'Copia las imagenes
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd & "/", txtSuela.Text)
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd, txtCaja.Text)
            objFTP.EnviarArchivo("Programacion/Modelos/" & codigoProd, txtMarca.Text)
        Catch ex As Exception
            mensaje += "Fotos"
        End Try
    End Sub
    'Private Sub guardarFraccionesProduccion()
    '    If Not nuevofraccion() Then
    '        Me.Cursor = Cursors.Default
    '        mensaje += " Fracciones" & vbCrLf
    '    End If
    '    GuardarImagen()
    '    If mensaje.Length > 0 Then
    '        Dim objMensaje As New Tools.ConfirmarForm
    '        objMensaje.mensaje = "La información incompleta no se guardará ¿Desea continuar?"
    '        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
    '            Me.Cursor = Cursors.WaitCursor
    '            guardarFraccionesDesarrollo()
    '            Me.Cursor = Cursors.Default
    '            exito.mensaje = "Se guardo correctamente la información del artículo."
    '            exito.ShowDialog()
    '            pintarceldas()
    '        End If
    '    Else
    '        Me.Cursor = Cursors.WaitCursor
    '        guardarFraccionesDesarrollo()
    '        Me.Cursor = Cursors.Default
    '        exito.mensaje = "Se guardo correctamente la información del artículo."
    '        exito.ShowDialog()
    '        pintarceldas()
    '    End If
    '    If mensaje.Length > 0 Then
    '        adv.mensaje = "Existe información sin completar" & vbCrLf
    '        adv.mensaje += mensaje
    '        adv.ShowDialog()
    '        mensaje = ""
    '    End If
    'End Sub

    Private Sub guardarFraccionesProd()
        If Not nuevofraccion() Then
            Me.Cursor = Cursors.Default
            mensaje += " Fracciones" & vbCrLf
        End If
        GuardarImagen()
        If mensaje.Length > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "La información incompleta no se guardará ¿Desea continuar?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                guardarFraccionesProduccion()
                Me.Cursor = Cursors.Default
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Se guardó correctamente la información del artículo."
                'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                'exito.mensaje = "Se guardó correctamente la información del artículo."
                'exito.StartPosition = FormStartPosition.CenterScreen
                'exito.ShowDialog()
                pintarceldas()
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            guardarFraccionesProduccion()
            Me.Cursor = Cursors.Default
            Dim objMensajeExito As New Tools.ExitoForm
            objMensajeExito.mensaje = "Se guardó correctamente la información del artículo."
            'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
            objMensajeExito.ShowDialog()
            'exito.mensaje = "Se guardó correctamente la información del artículo."
            'exito.StartPosition = FormStartPosition.CenterScreen
            'exito.ShowDialog()
            pintarceldas()
        End If
        If mensaje.Length > 0 Then
            adv.mensaje = "Existe información sin completar" & vbCrLf
            adv.mensaje += mensaje
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.ShowDialog()
            mensaje = ""
        End If
    End Sub
    Dim banderaGuardadoFRacciones As Boolean = False
    Private Sub guardarConsumos()
        mensaje = ""
        If Not nuevoconsumo() Then
            Me.Cursor = Cursors.Default
            mensaje += " Consumos" & vbCrLf
        End If
        If Not nuevofraccion() Then
            Me.Cursor = Cursors.Default
            mensaje += " Fracciones" & vbCrLf
        End If
        GuardarImagen()
        If mensaje.Length > 0 Then
            Dim objMensaje As New Tools.ConfirmarForm
            objMensaje.mensaje = "Falta completar información de " + mensaje + " ¿Desea continuar?"
            If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                guardarConsumosDesarrollo()
                guardarFraccionesDesarrollo()
                Me.Cursor = Cursors.Default
                If banderaGuardadoFRacciones Then
                    Dim objMensajeExito As New Tools.ExitoForm
                    objMensajeExito.mensaje = "Se guardó correctamente la información del artículo."
                    'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                    objMensajeExito.ShowDialog()
                    'exito.mensaje = "Se guardó correctamente la información del artículo."
                    'exito.StartPosition = FormStartPosition.CenterScreen
                    'exito.ShowDialog()
                End If
                pintarceldas()
                banderaGuardadoFRacciones = False
            End If
        Else
            Me.Cursor = Cursors.WaitCursor
            guardarConsumosDesarrollo()
            guardarFraccionesDesarrollo()
            Me.Cursor = Cursors.Default
            If banderaGuardadoFRacciones Then
                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Se guardó correctamente la información del artículo."
                'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                'exito.mensaje = "Se guardó correctamente la información del artículo."
                'exito.StartPosition = FormStartPosition.CenterScreen
                'exito.ShowDialog()
            End If
            pintarceldas()
            banderaGuardadoFRacciones = False
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim mensaje2 As String = String.Empty

        Try
            ActualizarOrdenConsumos()
            ActualizarOrdenFracciones()
            If tipoNave = "Desarrollo" Then
                Dim o As New ConsumosBU
                Dim n As New DataTable
                n = o.getNavesAfectadas(productoEstiloId)
                If n.Rows(0).Item(0).ToString.Length <= 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    guardarConsumos()
                    Me.Cursor = Cursors.Default
                Else
                    Dim m As New Tools.ConfirmarForm
                    m.mensaje = "Los cambios en consumos se verán reflejados también en las naves " & naves & ". ¿Desea continuar?"
                    If m.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.Cursor = Cursors.WaitCursor
                        guardarConsumos()
                        Me.Cursor = Cursors.Default
                    End If
                End If
            Else
                Dim m As New Tools.ConfirmarForm
                m.mensaje = "¿Esta seguro de guardar los cambios?"
                If m.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    'guardarFraccionesProd()

                    mensaje2 = ""

                    If Not nuevofraccion() Then
                        Me.Cursor = Cursors.Default
                        mensaje2 += " Fracciones" & vbCrLf
                    End If

                    If mensaje2.Length > 0 Then
                        Dim objMensaje As New Tools.ConfirmarForm
                        objMensaje.mensaje = "Falta completar información de " + mensaje2 + " ¿Desea continuar?"
                        If objMensaje.ShowDialog = Windows.Forms.DialogResult.OK Then
                            If ValidaHayFracciones() Then
                                Me.Cursor = Cursors.WaitCursor
                                guardarFraccionesDesarrollo()
                                Dim objMensajeExito As New Tools.ExitoForm
                                objMensajeExito.mensaje = "Se guardó correctamente la información del artículo."
                                'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                                objMensajeExito.ShowDialog()
                                'exito.mensaje = "Se guardó correctamente la información del artículo."
                                'exito.StartPosition = FormStartPosition.CenterScreen
                                'exito.Show()
                                Me.Cursor = Cursors.Default

                                pintarceldas()
                                banderaGuardadoFRacciones = False
                            Else
                                Dim objMensajeExito As New Tools.ExitoForm
                                objMensajeExito.mensaje = "El Modelo no se puede Guardar sin Fracciones."
                                'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                                objMensajeExito.ShowDialog()
                                Me.Cursor = Cursors.Default
                            End If

                        End If
                    Else
                        If validaHayFracciones() Then
                            Me.Cursor = Cursors.WaitCursor

                            If tipoNave = "Produccion" Then
                                GuardaConsumosNaveProduccion()
                            End If
                            guardarFraccionesDesarrollo()
                            Dim objMensajeExito As New Tools.ExitoForm
                            objMensajeExito.mensaje = "Se guardó correctamente la información del artículo."
                            'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                            objMensajeExito.ShowDialog()
                            Me.Cursor = Cursors.Default
                            'exito.mensaje = "Se guardó correctamente la información del artículo."
                            'exito.StartPosition = FormStartPosition.CenterScreen
                            'exito.Show()

                            pintarceldas()
                            banderaGuardadoFRacciones = False
                        Else
                            Dim objMensajeExito As New Tools.ExitoForm
                            objMensajeExito.mensaje = "El Modelo no se puede Guardar sin Fracciones."
                            'objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                            objMensajeExito.ShowDialog()
                            Me.Cursor = Cursors.Default
                        End If

                    End If
                        Me.Cursor = Cursors.Default
                End If


            End If

            calcularTotales()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            adv.mensaje = "Surgió algo inesperado: " & ex.Message
            adv.StartPosition = FormStartPosition.CenterScreen
            adv.Show()
        End Try
        Me.Hide()
    End Sub

    Private Sub ActualizarOrdenConsumos()
        Dim count As Integer = 0
        Try
            For Each Fila As UltraGridRow In grdConsumos.Rows
                If CBool(Fila.Cells("Activo").Value) = True Then
                    count = count + 1
                    Fila.Cells("Orden").Value = count
                Else
                    Fila.Cells("Orden").Value = 0
                End If


            Next
        Catch ex As Exception

        End Try

    End Sub


    Private Sub ActualizarOrdenFracciones()
        Dim count As Integer = 0
        Try
            For Each Fila As UltraGridRow In grdFracciones.Rows
                If CBool(Fila.Cells("Activo").Value) = True Then
                    count = count + 1
                    Fila.Cells("Orden").Value = count
                Else
                    Fila.Cells("Orden").Value = 0
                End If


            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub grdConsumos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdConsumos.AfterCellUpdate
        If ImportarConsumos = False Then
            If validaConsumo Then
                Try
                    '  grdConsumos.ActiveRow.Cells("Costo X Par").Value = (grdConsumos.ActiveRow.Cells("PrecioUM").Value * grdConsumos.ActiveRow.Cells("Consumo").Value)
                    'If e.Cell.IsFilterRowCell = False Then
                    '    If e.Cell.Column.Key = "Activo" Then
                    '        calcularTotales()
                    '    End If

                    'End If
                    calcularTotales()
                Catch ex As Exception

                End Try
            End If
            pintarceldas()
        End If


    End Sub

    Private Sub grdFracciones_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdFracciones.AfterCellUpdate
        'If IsNumeric((grdFracciones.ActiveRow.Cells("Costo").Value)) = True Then
        '    grdFracciones.ActiveRow.Cells("Costo").Value = CDbl(grdFracciones.ActiveRow.Cells("Costo").Value).ToString("C2")
        'End If
        If ImportarConsumos = False Then
            Try
                calcularTotales()
                pintarceldas()
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub grdConsumos_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdConsumos.BeforeRowsDeleted, grdFracciones.BeforeRowsDeleted
        If tipoNave = "Desarrollo" Then
            e.DisplayPromptMsg = False
            If borrar Then
                borrar = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnAddSuela.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picSuela.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            suela = ofdFoto.FileName
            Dim tabla() As String
            tabla = Split(suela, "\")
            For n = 0 To UBound(tabla, 1)

                If UBound(tabla) = n Then
                    suela = tabla(n)

                End If
            Next
            txtSuela.Text = ofdFoto.FileName
        End If
    End Sub

    Private Sub btnAgregarFotografia_Click(sender As Object, e As EventArgs) Handles btnAgregarFotografia.Click
        'ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        'If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        '    Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
        '    picFotografia.Image = Drawing.Image.FromFile(ofdFoto.FileName)

        '    txtFoto.Text = ofdFoto.FileName
        'End If
    End Sub

    Private Sub btnAddCaja_Click(sender As Object, e As EventArgs) Handles btnAddCaja.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picCaja.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            caja = ofdFoto.FileName
            Dim tabla() As String
            tabla = Split(caja, "\")
            For n = 0 To UBound(tabla, 1)

                If UBound(tabla) = n Then
                    caja = tabla(n)

                End If
            Next
            txtCaja.Text = ofdFoto.FileName
        End If
    End Sub

    Private Sub btnAddMarca_Click(sender As Object, e As EventArgs) Handles btnAddMarca.Click
        ofdFoto.Filter = "Image Files (JPEG,GIF,BMP,PNG,ICO)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;*ico"
        If ofdFoto.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim sr As New System.IO.StreamReader(ofdFoto.FileName)
            picMarca.Image = Drawing.Image.FromFile(ofdFoto.FileName)
            marca = ofdFoto.FileName
            Dim tabla() As String
            tabla = Split(marca, "\")
            For n = 0 To UBound(tabla, 1)

                If UBound(tabla) = n Then
                    marca = tabla(n)

                End If
            Next
            txtMarca.Text = ofdFoto.FileName
        End If
    End Sub
    Private Sub guardarImagenes()

    End Sub

    Private Sub grdFracciones_KeyUp(sender As Object, e As KeyEventArgs) Handles grdFracciones.KeyUp
        If editar = True Then
            Exit Sub
        End If

        If estatusArticulo.Trim <> "DESCONTINUADO" Then
            If estatusArticulo.Trim <> "INACTIVO NAVE" Then
                If e.KeyCode = Keys.F1 Then

                    If IsDBNull(grdFracciones.ActiveRow.Cells(3).Value) = False Then
                        idFraccionOriginal = CInt(grdFracciones.ActiveRow.Cells(3).Value)
                        Dim a As String = ""
                        If Not grdFracciones.ActiveRow.IsFilterRow Then
                            Try
                                If grdFracciones.ActiveCell.Column.ToString = "Fracción" Then
                                    'Mostrar ventana de componente
                                    Dim obj As New ConsumosBU
                                    Dim f As New DataTable
                                    Dim form As New listaFraccionesForm
                                    form.ShowDialog()
                                    Dim idFraccion As Integer = 0
                                    idFraccion = form.id
                                    If idFraccion > 0 Then
                                        If form.cerrado = False Then
                                            If True Then 'validarFraccion(idFraccion) Then
                                                f = obj.getFraccion(idFraccion)
                                                For Each row As DataRow In f.Rows
                                                    grdFracciones.ActiveRow.Cells("idFraccion").Value = row("frap_fraccionid")
                                                    grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0
                                                    grdFracciones.ActiveRow.Cells("Fracción").Value = row("frap_descripcion")
                                                    grdFracciones.ActiveRow.Cells("Costo").Value = row("frap_precio")
                                                    grdFracciones.ActiveRow.Cells("Pagar").Value = Convert.ToInt32(row("frap_paga"))
                                                    'grdFracciones.ActiveRow.Cells("Maquinaria").Value = row("mapr_descripcion")
                                                    grdFracciones.ActiveRow.Cells("Activo").Value = 1

                                                    grdFracciones.ActiveCell = grdFracciones.ActiveRow.Cells("Costo")
                                                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, True, True)
                                                Next
                                            Else
                                                adv.mensaje = "Ya existe la fracción para este artículo."
                                                adv.StartPosition = FormStartPosition.CenterScreen
                                                adv.ShowDialog()
                                            End If
                                        End If
                                    End If


                                ElseIf grdFracciones.ActiveCell.Column.ToString = "Maquinaria" Then
                                    Dim form As New ListaMaquinariaForm
                                    form.ShowDialog()
                                    If form.idMaquinaria > 0 Then
                                        grdFracciones.ActiveRow.Cells("Maquinaria").Value = form.descripcionMaquina
                                        grdFracciones.ActiveRow.Cells("maquinaid").Value = form.idMaquinaria
                                    End If
                                End If


                            Catch ex As Exception
                            End Try
                        End If
                    End If

                ElseIf e.KeyCode = Keys.Enter Then
                    Try
                        Dim comparador As String = ""

                        If grdFracciones.Rows(grdFracciones.Rows.Count - 1).Cells("Fracción").Text <> "" Then
                            grdFracciones.DisplayLayout.Bands(0).AddNew()
                            grdFracciones.ActiveRow.Cells("idFraccion").Value = 0
                            grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0
                            grdFracciones.ActiveRow.Cells("Costo").Value = 0
                            grdFracciones.ActiveRow.Cells("Pagar").Value = False
                            grdFracciones.ActiveRow.Cells("Activo").Value = 1
                            grdFracciones.ActiveRow.Cells("Sumar Costo").Value = 1
                            grdFracciones.ActiveRow.Cells("Sumar Tiempo").Value = 1
                            grdFracciones.ActiveRow.Cells("Orden").Value = grdFracciones.Rows.Count
                            'grdFracciones.ActiveCell = grdFracciones.ActiveRow.Cells("Costo")
                            grdFracciones.ActiveCell = grdFracciones.ActiveRow.Cells("Fracción")
                            grdFracciones.PerformAction(UltraGridAction.EnterEditMode, True, True)
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        calcularTotales()
                    Catch ex As Exception
                    End Try
                ElseIf e.KeyCode = Keys.Back Then
                    Try
                        If grdFracciones.ActiveRow.Selected = True Then
                            If grdFracciones.ActiveRow.Cells("idFraccDes").Value = 0 Then
                                borrar = True
                                grdFracciones.ActiveRow.Delete()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
                pintarceldas()
            End If


        End If
    End Sub


    Private Sub UltraGrid1_KeyDown(sender As Object, e As KeyEventArgs) Handles grdConsumos.KeyUp
        calcularConsumosV2()
    End Sub


    Public Sub calcularConsumosV2()
        ' Verificar si el resumen "SumCostoXPar" ya existe
        If grdConsumos.DisplayLayout.Bands(0).Summaries.Exists("SumCostoXPar") Then
            ' Si el resumen ya existe, lo removemos
            Dim summaryToRemove As Infragistics.Win.UltraWinGrid.SummarySettings = grdConsumos.DisplayLayout.Bands(0).Summaries("SumCostoXPar")
            grdConsumos.DisplayLayout.Bands(0).Summaries.Remove(summaryToRemove)
        End If

        ' Crear nuevamente el resumen después de remover el existente
        Dim costoXpar As Infragistics.Win.UltraWinGrid.SummarySettings
        costoXpar = grdConsumos.DisplayLayout.Bands(0).Summaries.Add("SumCostoXPar", Infragistics.Win.UltraWinGrid.SummaryType.Sum, grdConsumos.DisplayLayout.Bands(0).Columns("Costo X Par"))
        costoXpar.DisplayFormat = "{0:c2}" ' Formato de moneda
        costoXpar.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed

        ' Forzar la actualización del grid para recalcular los valores
        '' grdConsumos.UpdateData()
        grdConsumos.Refresh()

        ' Permitir que la interfaz de usuario procese otros eventos
        Application.DoEvents()

        ' Obtener el valor del resumen ya calculado
        Dim resumenValor As Infragistics.Win.UltraWinGrid.SummaryValue = grdConsumos.Rows.SummaryValues("SumCostoXPar")
        Dim sumatoriaCostoXpar As Decimal = CType(resumenValor.Value, Decimal)

        ' Asignar el valor de la sumatoria al Label
        lblTotal.Text = sumatoriaCostoXpar.ToString("C2")
        Lbltotalv2.Text = sumatoriaCostoXpar.ToString("C2") ' Formato de moneda en el Label
    End Sub




    Public Sub calcularTotales()
        Try
            Dim obj As New ConsumosBU
            lblTotalEtq.Text = "Total Consumos"
            Dim d As New DataTable
            Dim total As Double = 0
            Dim totalCasco As Double = 0
            Dim totalContra As Double = 0
            Dim totalCaja As Double = 0
            d = grdConsumos.DataSource

            'For Each fila As UltraGridRow In grdConsumos.Rows
            '    If CBool(fila.Cells("Activo").Value) = True Then
            '        total += fila.Cells("Costo X Par").Text
            '    End If
            'Next

            If tipoNave = "Desarrollo" Then
                d = obj.ObtenerTotalConsumoDesarrollo(productoEstiloId)
                total = d.Rows(0).Item("Costo X Par")
            Else
                If estatusArticulo = "INACTIVO NAVE" Then
                    d = obj.ObtenerTotalConsumoProduccion(productoEstiloId, idNaveConsulta, 1)
                Else
                    d = obj.ObtenerTotalConsumoProduccion(productoEstiloId, idNaveConsulta, 0)
                End If

                total = d.Rows(0).Item("Costo X Par")
            End If

            ''For Each fila As UltraGridRow In grdConsumos.Rows
            ''    If CBool(fila.Cells("Activo").Value) = True Then
            ''        If fila.Cells("Componente").Value = "CASCO" Or fila.Cells("Componente").Value = "CONTRAFUERTE" Or fila.Cells("Componente").Value = "CAJA" Then
            ''        Else
            ''            total += fila.Cells("Costo X Par").Text
            ''        End If
            ''    End If

            ''Next

            ''For Each row As DataRow In d.Rows
            ''    If row("Componente") = "CASCO" Or row("Componente") = "CONTRAFUERTE" Or row("Componente") = "CAJA" Then
            ''    Else
            ''        total += row("Costo X Par")
            ''    End If
            ''Next


            'For Each fila As UltraGridRow In grdConsumos.Rows
            '    If CBool(fila.Cells("Activo").Value) = True Then
            '        Dim x = fila.Cells("Componente").Text
            '        If fila.Cells("Componente").Text = "CASCO" Then
            '            Dim y = fila.Cells("Costo X Par").Text
            '            If totalCasco < fila.Cells("Costo X Par").Text Then
            '                totalCasco = fila.Cells("Costo X Par").Text
            '            End If
            '        End If
            '        If fila.Cells("Componente").Text = "CONTRAFUERTE" Then
            '            Dim y2 = fila.Cells("Costo X Par").Text
            '            If totalContra < fila.Cells("Costo X Par").Text Then
            '                totalContra = fila.Cells("Costo X Par").Text
            '            End If
            '        End If
            '        If fila.Cells("Componente").Text = "CAJA" Then
            '            Dim y3 = fila.Cells("Costo X Par").Text
            '            If totalCaja < fila.Cells("Costo X Par").Text Then
            '                totalCaja = fila.Cells("Costo X Par").Text
            '            End If
            '        End If
            '    End If
            'Next

            ''For Each row As DataRow In d.Rows
            ''    Dim x = row("Componente")
            ''    If row("Componente") = "CASCO" Then
            ''        Dim y = row("Costo X Par")
            ''        If totalCasco < row("Costo X Par") Then
            ''            totalCasco = row("Costo X Par")
            ''        End If
            ''    End If
            ''    If row("Componente") = "CONTRAFUERTE" Then
            ''        Dim y2 = row("Costo X Par")
            ''        If totalContra < row("Costo X Par") Then
            ''            totalContra = row("Costo X Par")
            ''        End If
            ''    End If
            ''    If row("Componente") = "CAJA" Then
            ''        Dim y3 = row("Costo X Par")
            ''        If totalCaja < row("Costo X Par") Then
            ''            totalCaja = row("Costo X Par")
            ''        End If
            ''    End If
            ''Next

            'total += totalCasco + totalContra + totalCaja

            'lblTotal.Visible = True
            'lblTotalEtq.Visible = True
            'lblTotal.Text = "$ " & total.ToString("##,##0.0#")
            'Try
            '    Dim d2 As New DataTable
            '    Dim total2 As Double = 0

            '    For value = 0 To grdConsumos.Rows.Count - 1
            '        If CBool(grdConsumos.Rows(value).Cells("Activo").Value) = True Then
            '            total = total + grdConsumos.Rows(value).Cells("Costo").Value
            '        End If
            '    Next
            '    lblTotalF.Text = "$ " & total2.ToString("##,##0.0#")
            'Catch ex As Exception
            'End Try

            'lblTotalEtq.Text = "Total Consumos"

            'For Each fila As UltraGridRow In grdConsumos.Rows
            '    If CBool(fila.Cells("Activo").Value) = True Then
            '        If fila.Cells("Componente").Text = "CASCO" Or fila.Cells("Componente").Text = "CONTRAFUERTE" Or fila.Cells("Componente").Text = "CAJA" Then
            '        Else
            '            total += fila.Cells("Costo X Par").Text
            '        End If
            '    End If

            'Next


            ''For Each row As DataRow In d.Rows
            ''    If row("Componente") = "CASCO" Or row("Componente") = "CONTRAFUERTE" Or row("Componente") = "CAJA" Then
            ''    Else
            ''        total += row("Costo X Par")
            ''    End If
            ''Next

            'For Each fila As UltraGridRow In grdConsumos.Rows
            '    If CBool(fila.Cells("Activo").Value) = True Then
            '        Dim x = fila.Cells("Componente").Text
            '        If fila.Cells("Componente").Text = "CASCO" Then
            '            Dim y = fila.Cells("Costo X Par").Text
            '            If totalCasco < fila.Cells("Costo X Par").Text Then
            '                totalCasco = fila.Cells("Costo X Par").Text
            '            End If
            '        End If
            '        If fila.Cells("Componente").Text = "CONTRAFUERTE" Then
            '            Dim y2 = fila.Cells("Costo X Par").Text
            '            If totalContra < fila.Cells("Costo X Par").Text Then
            '                totalContra = fila.Cells("Costo X Par").Text
            '            End If
            '        End If
            '        If fila.Cells("Componente").Text = "CAJA" Then
            '            Dim y3 = fila.Cells("Costo X Par").Text
            '            If totalCaja < fila.Cells("Costo X Par").Text Then
            '                totalCaja = fila.Cells("Costo X Par").Text
            '            End If
            '        End If
            '    End If

            'Next


            ''For Each row As DataRow In d.Rows
            ''    Dim x = row("Componente")
            ''    If row("Componente") = "CASCO" Then
            ''        Dim y = row("Costo X Par")
            ''        If totalCasco < row("Costo X Par") Then
            ''            totalCasco = row("Costo X Par")
            ''        End If
            ''    End If
            ''    If row("Componente") = "CONTRAFUERTE" Then
            ''        Dim y2 = row("Costo X Par")
            ''        If totalContra < row("Costo X Par") Then
            ''            totalContra = row("Costo X Par")
            ''        End If
            ''    End If
            ''    If row("Componente") = "CAJA" Then
            ''        Dim y3 = row("Costo X Par")
            ''        If totalCaja < row("Costo X Par") Then
            ''            totalCaja = row("Costo X Par")
            ''        End If
            ''    End If
            ''Next

            'total += totalCasco + totalContra + totalCaja
            'total = total / 2

            lblTotal.Visible = True
            lblTotalEtq.Visible = True
            'lblTotal.Text = "$ " & total.ToString("##,##0.00")
            lblTotal.Text = "$ " & total.ToString("##,###.##")
            Try
                Dim d2 As New DataTable
                Dim total2 As Double = 0
                d2 = grdFracciones.DataSource

                For value = 0 To grdFracciones.Rows.Count - 1
                    If CBool(grdFracciones.Rows(value).Cells("Activo").Value) = True Then
                        If grdFracciones.Rows(value).Cells("Sumar Costo").Value = True Then
                            total2 = total2 + grdFracciones.Rows(value).Cells("Costo").Text
                        End If
                    End If
                Next
                lblTotalF.Text = "$ " & total2.ToString("##,##0.000")
            Catch ex As Exception
                Dim valor As String = String.Empty
                valor = "cadena"
            End Try
        Catch ex As Exception
        End Try
        Try
            Dim Horas As Integer = 0
            Dim h1 As Integer = 0
            Dim Minutos As Integer = 0
            Dim m1 As Integer = 0
            Dim Segundos As Integer = 0
            Dim s1 As Integer = 0
            Dim tiempo As String = ""

            For value = 0 To grdFracciones.Rows.Count - 1

                If CBool(grdFracciones.Rows(value).Cells("Sumar Tiempo").Value) = True Then
                    If grdFracciones.Rows(value).Cells("Horas").Text <> "" Then
                        Horas = Horas + grdFracciones.Rows(value).Cells("Horas").Text
                    End If
                    If grdFracciones.Rows(value).Cells("Minutos").Text <> "" Then
                        Minutos = Minutos + grdFracciones.Rows(value).Cells("Minutos").Text
                    End If
                    If grdFracciones.Rows(value).Cells("Segundos").Text <> "" Then
                        Segundos = Segundos + grdFracciones.Rows(value).Cells("Segundos").Text
                    End If
                End If
            Next

            Horas = Horas * 3600
            Minutos = Minutos * 60
            Segundos = Segundos + Horas + Minutos

            h1 = Math.Floor(Segundos / 3600)
            m1 = Math.Floor((Segundos - h1 * 3600) / 60)
            s1 = Segundos - (h1 * 3600 + m1 * 60)
            Dim h As String = ""
            Dim m As String = ""
            Dim s As String = ""

            If h1.ToString.Length = 1 Then
                h = "0" + h1.ToString
            ElseIf h1.ToString.Length = 0 Then
                h = "00"
            Else
                h = h1.ToString
            End If
            If m1.ToString.Length = 1 Then
                m = "0" + m1.ToString
            ElseIf m1.ToString.Length = 0 Then
                m = "00"
            Else
                m = m1.ToString
            End If
            If s1.ToString.Length = 1 Then
                s = "0" + s1.ToString
            ElseIf s1.ToString.Length = 0 Then
                s = "00"
            Else
                s = s1.ToString
            End If
            tiempo = h.ToString + ":" + m.ToString + ":" + s.ToString
            lblTotalTiempo.Text = tiempo
        Catch ex As Exception
        End Try

    End Sub
    Private Sub tbcImagenesConsumosFracciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcImagenesConsumosFracciones.SelectedIndexChanged
        calcularTotales()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        'For Each row As UltraGridRow In grdConsumos.Rows
        '    row.Cells("Activo").Value = False
        'Next
        'If chkConsumos.Checked Then
        '    For Each row As UltraGridRow In grdConsumos.Rows.GetFilteredInNonGroupByRows
        '        row.Cells("Activo").Value = True
        '    Next
        'Else
        '    For Each row As UltraGridRow In grdConsumos.Rows.GetFilteredInNonGroupByRows
        '        row.Cells("Activo").Value = False
        '    Next
        'End If
        'Try
        '    Dim Seleccionados As Integer = 0
        '    For Each row As UltraGridRow In grdConsumos.Rows.GetFilteredInNonGroupByRows
        '        If CBool(row.Cells("Activo").Value) Then
        '            Seleccionados += 1
        '        End If
        '    Next
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub chkEliminar_CheckedChanged(sender As Object, e As EventArgs)
        'For Each row As UltraGridRow In grdFracciones.Rows
        '    row.Cells("Activo").Value = False
        'Next
        'If chkEliminar.Checked Then
        '    For Each row As UltraGridRow In grdFracciones.Rows.GetFilteredInNonGroupByRows
        '        row.Cells("Activo").Value = True
        '    Next
        'Else
        '    For Each row As UltraGridRow In grdFracciones.Rows.GetFilteredInNonGroupByRows
        '        row.Cells("Activo").Value = False
        '    Next
        'End If
        'Try
        '    Dim Seleccionados As Integer = 0
        '    For Each row As UltraGridRow In grdFracciones.Rows.GetFilteredInNonGroupByRows
        '        If CBool(row.Cells("Activo").Value) Then
        '            Seleccionados += 1
        '        End If
        '    Next
        '    pintarceldas()
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub grdFracciones_CellChange(sender As Object, e As CellEventArgs) Handles grdFracciones.CellChange

        If ImportarConsumos = False Then
            If e.Cell.Column.ToString = "Activo" Then
                If CBool(e.Cell.Value) Then
                    grdFracciones.ActiveRow.Cells("Activo").Value = False
                Else
                    grdFracciones.ActiveRow.Cells("Activo").Value = True
                End If
            End If

            If e.Cell.Column.ToString = "Sumar Tiempo" Then
                If CBool(e.Cell.Value) Then
                    grdFracciones.ActiveRow.Cells("Sumar Tiempo").Value = False
                Else
                    grdFracciones.ActiveRow.Cells("Sumar Tiempo").Value = True
                End If
            End If

            If e.Cell.Column.ToString = "Sumar Costo" Then
                If CBool(e.Cell.Value) Then
                    grdFracciones.ActiveRow.Cells("Sumar Costo").Value = False
                Else
                    grdFracciones.ActiveRow.Cells("Sumar Costo").Value = True
                End If
            End If

            If e.Cell.Column.ToString = "Costo" Then
                'If IsNumeric(e.Cell.Text) = True Then
                '    grdFracciones.ActiveRow.Cells("Costo").Value = CDbl(e.Cell.Text)
                'Else
                '    grdFracciones.ActiveRow.Cells("Costo").Value = 0
                'End If

                If e.Cell.Text <> "." Then
                    If IsNumeric(e.Cell.Text) = False Then
                        grdFracciones.ActiveRow.Cells("Costo").Value = 0
                    End If
                End If


            End If

            'If e.Cell.Column.ToString() = "Sumar Costo" Then
            '    If e.Cell.Value = True Then
            '        e.Cell.Value = False
            '    Else
            '        e.Cell.Value = True
            '    End If

            'End If

            calcularTotales()
            ActualizarOrdenFracciones()
            pintarceldas()
        End If

    End Sub


    Private Sub grdConsumos_CellChange(sender As Object, e As CellEventArgs) Handles grdConsumos.CellChange
        If ImportarConsumos = False Then
            If e.Cell.Column.ToString = "Activo" Then
                If CBool(e.Cell.Value) Then
                    grdConsumos.ActiveRow.Cells("Activo").Value = False
                Else
                    grdConsumos.ActiveRow.Cells("Activo").Value = True
                End If
            End If

            If e.Cell.Column.ToString = "Consumo" Then
                If IsNumeric(e.Cell.Text) = True And IsNumeric(grdConsumos.ActiveRow.Cells("PrecioUM").Value) Then
                    grdConsumos.ActiveRow.Cells("Costo X Par").Value = Math.Round(CDbl(grdConsumos.ActiveRow.Cells("PrecioUM").Value), 2) * CDbl(e.Cell.Text)
                Else
                    grdConsumos.ActiveRow.Cells("Costo X Par").Value = 0
                End If
            End If

            calcularTotales()
            ActualizarOrdenConsumos()
            pintarceldas()
        End If


    End Sub

    Private Sub btnImportConsumos_Click(sender As Object, e As EventArgs) Handles btnImportConsumos.Click
        ImportarExcel()
    End Sub
    Private Sub ImportarExcel()
        Dim datosExcel As DataTable
        datosExcel = Tools.Excel.LlenarTablaExcelListaTablas("", "", "")
        Dim consumos As New DataTable
        Dim c As New DataTable
        Dim r As DataRow
        c = grdConsumos.DataSource
        If datosExcel.Rows.Count > 0 Then
            Dim form As New DatosImportConsumos
            form.datos = datosExcel
            form.idNave = idNave
            form.productoEstiloId = productoEstiloId
            form.ShowDialog()
            consumos = form.consumos
            If form.guardar Then

                'NOTIFICAR QUE LOS MATERIALES A CARGAR NO ESTÁN YA CARGADOS
                Dim bandera As Boolean = False
                For Each row As DataRow In c.Rows
                    For Each row2 As DataRow In consumos.Rows
                        Try
                            If row("IdMaterial") = row2("IdMaterial") Then
                                bandera = True
                            End If
                        Catch ex As Exception

                        End Try

                    Next
                Next
                If bandera Then
                    adv.mensaje = "Algunos materiales que intenta cargar ya están en el artículo, estos consumos no se cargarán."
                    adv.StartPosition = FormStartPosition.CenterScreen
                    adv.ShowDialog()
                End If

                'FIN DE NOTIFICACIÓN
                Dim ban As Boolean = False
                For Each row2 As DataRow In consumos.Rows
                    ban = False
                    For Each row As DataRow In c.Rows
                        Try
                            If row("IdMaterial") = row2("IdMaterial") Then
                                ban = True
                            End If
                        Catch ex As Exception
                        End Try

                    Next
                    If Not ban Then
                        r = c.NewRow()
                        r("Activo") = 1
                        r("Editado") = 0
                        r("Bloqueado") = row2("Bloqueado")
                        r("Explosionar") = row2("Explosionar")
                        r("Lotear") = row2("Lotear")
                        r("idComponente") = row2("idComponente")
                        r("Componente") = row2("Componente")
                        r("idClasificacion") = row2("idClasificacion")
                        r("Clasificación") = row2("Clasificación")
                        r("IdMaterial") = row2("IdMaterial")
                        r("SKU") = row2("SKU")
                        r("Material") = row2("Material")
                        r("idConsumo") = 0
                        r("Consumo") = row2("Consumo")
                        r("idUMC") = row2("idUMC")
                        r("UMC") = row2("UMC")
                        r("idProveedor") = row2("idProveedor")
                        r("Proveedor") = row2("Proveedor")
                        r("Precio Compra") = row2("Precio Compra")
                        r("idUMProd") = row2("idUMProd")
                        r("UMP") = row2("UMP")
                        r("Factor") = row2("Factor")
                        r("PrecioUM") = row2("PrecioUM")
                        r("Costo X Par") = row2("Costo X Par")
                        r("productoEstiloId") = productoEstiloId
                        c.Rows.Add(r)
                    End If
                Next
            End If
        End If
        grdConsumos.DataSource = c
        If tipoNave = "Desarrollo" Then
            diseñoConsumos()
        Else
            diseñoConsumosProd()
        End If
        pintarceldas()
    End Sub

    Private Sub grdConsumos_KeyDown(sender As Object, e As KeyEventArgs) Handles grdConsumos.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Enter Then
                grdConsumos.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdConsumos.DisplayLayout.Bands(0)
                If grdConsumos.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdConsumos.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdConsumos.ActiveCell = nextRow.Cells(grdConsumos.ActiveCell.Column)
                    e.Handled = True
                    grdConsumos.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdConsumos.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdConsumos.DisplayLayout.Bands(0)
                If grdConsumos.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdConsumos.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdConsumos.ActiveCell = nextRow.Cells(grdConsumos.ActiveCell.Column)
                    e.Handled = True
                    grdConsumos.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdConsumos.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdConsumos.DisplayLayout.Bands(0)
                If grdConsumos.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdConsumos.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdConsumos.ActiveCell = nextRow.Cells(grdConsumos.ActiveCell.Column)
                    e.Handled = True
                    grdConsumos.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnQuitarSuela.Click
        suela = "..."
        picSuela.Image = Nothing
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnQuitarCaja.Click
        caja = "..."
        picCaja.Image = Nothing
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnQuitarMarca.Click
        marca = "..."
        picMarca.Image = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnImportarConsumos.Click
        Dim obj As New catalagosBU
        Dim form As New ListaModelosImportarConsumoFraccionForm
        'form.idNave = idNave
        form.idNave = idNaveConsulta
        form.articulo = productoEstiloId
        form.NaveDesarrollaId = NAveDesarrollaID
        form.EsAlta = EsAlta
        form.IdNaveAlta = IdNaveAlta


        If form.ShowDialog = Windows.Forms.DialogResult.OK Then
            listaComponentesCopiados = form.listaComponentesCopiados
            listaFraccionesCopiadas = form.listaFraccionesCopiadas
            consumosCopiados = obj.ConsumosSeleccionados(listaComponentesCopiados)
            'fraccionesCopiadas = obj.FraccionesSeleccionadss(listaFraccionesCopiadas)
            fraccionesCopiadas = form.TablaFracciones

            'grdConsumos.DataSource = consumosCopiados
            Try
                ImportarConsumos = True
                Me.Cursor = Cursors.WaitCursor
                AgregarConsumosImportados()
                disenioConsumos()
                AgregarFraccionesImportados()
                disenioFracciones()

                ImportarConsumos = False
                Me.Cursor = Cursors.Default
            Catch ex As Exception
                Me.Cursor = Cursors.Default
            End Try
        End If
        Try
            calcularTotales()
            ActualizarOrdenConsumos()
            ActualizarOrdenFracciones()
        Catch ex As Exception
        End Try
        Try
            pintarceldas()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub AgregarConsumosImportados()
        Dim tamaño As Integer = 0
        Dim CountFilas As Integer = 0
        Dim Fila As Integer = 0
        Dim reemplazafilaanterior As Boolean = False
        Dim NumeroFilas As Integer = 0
        NumeroFilas = grdConsumos.Rows.Count
        tamaño = grdConsumos.Rows.Count
        'If grdConsumos.Rows(tamaño - 1).Cells("Componente").Text = "" Then
        '    For value = 0 To consumosCopiados.Rows.Count - 1
        '        If validarMaterialRepetido(CInt(consumosCopiados.Rows(value).Item("idMaterial").ToString)) Then
        '            'grdConsumos.Rows(value + tamaño).Cells(" ").Value = CInt(consumosCopiados.Rows(value).Item(0).ToString)
        '            grdConsumos.Rows(value).Cells("Activo").Value = CBool(consumosCopiados.Rows(value).Item(1).ToString)
        '            grdConsumos.Rows(value).Cells("Editado").Value = CBool(consumosCopiados.Rows(value).Item(2).ToString)
        '            grdConsumos.Rows(value).Cells("Bloqueado").Value = CBool(consumosCopiados.Rows(value).Item(3).ToString)
        '            grdConsumos.Rows(value).Cells("Explosionar").Value = CBool(consumosCopiados.Rows(value).Item(4).ToString)
        '            grdConsumos.Rows(value).Cells("Lotear").Value = CBool(consumosCopiados.Rows(value).Item(5).ToString)
        '            grdConsumos.Rows(value).Cells("idComponente").Value = CInt(consumosCopiados.Rows(value).Item(6).ToString)
        '            grdConsumos.Rows(value).Cells("Componente").Value = consumosCopiados.Rows(value).Item(7).ToString
        '            grdConsumos.Rows(value).Cells("idClasificacion").Value = CInt(consumosCopiados.Rows(value).Item(8).ToString)
        '            grdConsumos.Rows(value).Cells("Clasificación").Value = consumosCopiados.Rows(value).Item(9).ToString
        '            grdConsumos.Rows(value).Cells("IdMaterial").Value = CInt(consumosCopiados.Rows(value).Item(10).ToString)
        '            grdConsumos.Rows(value).Cells("SKU").Value = consumosCopiados.Rows(value).Item(11).ToString
        '            grdConsumos.Rows(value).Cells("Material").Value = consumosCopiados.Rows(value).Item(12).ToString
        '            grdConsumos.Rows(value).Cells("idConsumo").Value = 0
        '            grdConsumos.Rows(value).Cells("Consumo").Value = consumosCopiados.Rows(value).Item(14).ToString
        '            grdConsumos.Rows(value).Cells("idUMC").Value = CInt(consumosCopiados.Rows(value).Item(15).ToString)
        '            grdConsumos.Rows(value).Cells("UMC").Value = consumosCopiados.Rows(value).Item(16).ToString
        '            grdConsumos.Rows(value).Cells("idProveedor").Value = CInt(consumosCopiados.Rows(value).Item(17).ToString)
        '            grdConsumos.Rows(value).Cells("Proveedor").Value = consumosCopiados.Rows(value).Item(18).ToString
        '            grdConsumos.Rows(value).Cells("Precio Compra").Value = CDbl(consumosCopiados.Rows(value).Item(19).ToString)
        '            grdConsumos.Rows(value).Cells("idUMProd").Value = CInt(consumosCopiados.Rows(value).Item(20).ToString)
        '            grdConsumos.Rows(value).Cells("UMP").Value = consumosCopiados.Rows(value).Item(21).ToString
        '            grdConsumos.Rows(value).Cells("Factor").Value = CInt(consumosCopiados.Rows(value).Item(22).ToString)
        '            grdConsumos.Rows(value).Cells("PrecioUM").Value = CDbl(consumosCopiados.Rows(value).Item(23).ToString)
        '            grdConsumos.Rows(value).Cells("Costo X Par").Value = CDbl(consumosCopiados.Rows(value).Item(24).ToString)
        '            grdConsumos.Rows(value).Cells("productoEstiloId").Value = CInt(consumosCopiados.Rows(value).Item(25).ToString)

        '        End If                
        '    Next
        'Else


        'For value = 0 To consumosCopiados.Rows.Count - 1
        '    tamaño = grdConsumos.Rows.Count
        '    If validarMaterialRepetido(CInt(consumosCopiados.Rows(value).Item("IdMaterial").ToString)) Then
        '        grdConsumos.DisplayLayout.Bands(0).AddNew()
        '        'grdConsumos.Rows(value + tamaño).Cells(" ").Value = CInt(consumosCopiados.Rows(value).Item(0).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Activo").Value = CBool(consumosCopiados.Rows(value).Item(1).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Editado").Value = CBool(consumosCopiados.Rows(value).Item(2).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Bloqueado").Value = CBool(consumosCopiados.Rows(value).Item(3).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Explosionar").Value = CBool(consumosCopiados.Rows(value).Item(4).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Lotear").Value = CBool(consumosCopiados.Rows(value).Item(5).ToString)
        '        grdConsumos.Rows(tamaño).Cells("idComponente").Value = CInt(consumosCopiados.Rows(value).Item(6).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Componente").Value = consumosCopiados.Rows(value).Item(7).ToString
        '        grdConsumos.Rows(tamaño).Cells("idClasificacion").Value = CInt(consumosCopiados.Rows(value).Item(8).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Clasificación").Value = consumosCopiados.Rows(value).Item(9).ToString
        '        grdConsumos.Rows(tamaño).Cells("IdMaterial").Value = CInt(consumosCopiados.Rows(value).Item(10).ToString)
        '        grdConsumos.Rows(tamaño).Cells("SKU").Value = consumosCopiados.Rows(value).Item(11).ToString
        '        grdConsumos.Rows(tamaño).Cells("Material").Value = consumosCopiados.Rows(value).Item(12).ToString
        '        grdConsumos.Rows(tamaño).Cells("idConsumo").Value = 0
        '        grdConsumos.Rows(tamaño).Cells("Consumo").Value = consumosCopiados.Rows(value).Item(14).ToString
        '        grdConsumos.Rows(tamaño).Cells("idUMC").Value = CInt(consumosCopiados.Rows(value).Item(15).ToString)
        '        grdConsumos.Rows(tamaño).Cells("UMC").Value = consumosCopiados.Rows(value).Item(16).ToString
        '        grdConsumos.Rows(tamaño).Cells("idProveedor").Value = CInt(consumosCopiados.Rows(value).Item(17).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Proveedor").Value = consumosCopiados.Rows(value).Item(18).ToString
        '        grdConsumos.Rows(tamaño).Cells("Precio Compra").Value = CDbl(consumosCopiados.Rows(value).Item(19).ToString)
        '        grdConsumos.Rows(tamaño).Cells("idUMProd").Value = CInt(consumosCopiados.Rows(value).Item(20).ToString)
        '        grdConsumos.Rows(tamaño).Cells("UMP").Value = consumosCopiados.Rows(value).Item(21).ToString
        '        grdConsumos.Rows(tamaño).Cells("Factor").Value = CInt(consumosCopiados.Rows(value).Item(22).ToString)
        '        grdConsumos.Rows(tamaño).Cells("PrecioUM").Value = CDbl(consumosCopiados.Rows(value).Item(23).ToString)
        '        grdConsumos.Rows(tamaño).Cells("Costo X Par").Value = CDbl(consumosCopiados.Rows(value).Item(24).ToString)
        '        grdConsumos.Rows(tamaño).Cells("productoEstiloId").Value = CInt(consumosCopiados.Rows(value).Item(25).ToString)
        '        Try
        '            'grdConsumos.Rows(tamaño).Cells("Orden").Value = CInt(consumosCopiados.Rows(grdConsumos.Rows.Count - 2).Item("orden").ToString) + 1

        '            grdConsumos.Rows(tamaño).Cells("Orden").Value = NumeroFilas + value

        '        Catch ex As Exception

        '        End Try

        '    End If
        'Next

        tamaño = grdConsumos.Rows.Count
        Fila = tamaño
        If Fila <> 0 And tamaño <> 0 Then
            If grdConsumos.Rows(tamaño - 1).Cells("Componente").Text = "" Then
                reemplazafilaanterior = True
            End If
        End If

        ''***********************************************

        Dim obj As New catalagosBU
        Dim DtConsumo As DataTable
        Dim contadorFila As Integer = 0
        Dim ElementoLista As Integer = 0
        If listaComponentesCopiados.Count > 0 Then

            For Each FilaConsumo As Integer In listaComponentesCopiados

                DtConsumo = obj.ConsumoSeleccionadId(FilaConsumo)
                If validarMaterialRepetido(CInt(DtConsumo.Rows(ElementoLista).Item("IdMaterial").ToString)) Then
                    Fila = NumeroFilas + CountFilas
                    If reemplazafilaanterior = True Then
                        Fila = Fila - 1
                    Else
                        grdConsumos.DisplayLayout.Bands(0).AddNew()
                    End If

                    'grdConsumos.ActiveRow.Cells("Editado").Value = 0
                    'grdConsumos.ActiveRow.Cells("idConsumo").Value = 0
                    'grdConsumos.ActiveRow.Cells("Bloqueado").Value = CBool(False)
                    'grdConsumos.ActiveRow.Cells("Explosionar").Value = CBool(False)
                    'grdConsumos.ActiveRow.Cells("Lotear").Value = CBool(False)
                    'grdConsumos.ActiveRow.Cells("Componente").Selected = True
                    'grdConsumos.Rows(value + tamaño).Cells(" ").Value = CInt(consumosCopiados.Rows(value).Item(0).ToString)
                    grdConsumos.Rows(Fila).Cells("Activo").Value = True
                    grdConsumos.Rows(Fila).Cells("Editado").Value = False
                    grdConsumos.Rows(Fila).Cells("Bloqueado").Value = CBool(DtConsumo.Rows(ElementoLista).Item("Bloqueado").ToString)
                    grdConsumos.Rows(Fila).Cells("Explosionar").Value = CBool(DtConsumo.Rows(ElementoLista).Item("Explosionar").ToString)
                    grdConsumos.Rows(Fila).Cells("Lotear").Value = CBool(DtConsumo.Rows(ElementoLista).Item("Lotear").ToString)
                    grdConsumos.Rows(Fila).Cells("idComponente").Value = CInt(DtConsumo.Rows(ElementoLista).Item("idComponente").ToString)
                    grdConsumos.Rows(Fila).Cells("Componente").Value = DtConsumo.Rows(ElementoLista).Item("Componente").ToString
                    grdConsumos.Rows(Fila).Cells("idClasificacion").Value = CInt(DtConsumo.Rows(ElementoLista).Item("idClasificacion").ToString)
                    grdConsumos.Rows(Fila).Cells("Clasificación").Value = DtConsumo.Rows(ElementoLista).Item("Clasificación").ToString
                    grdConsumos.Rows(Fila).Cells("IdMaterial").Value = CInt(DtConsumo.Rows(ElementoLista).Item("IdMaterial").ToString)
                    grdConsumos.Rows(Fila).Cells("SKU").Value = DtConsumo.Rows(ElementoLista).Item("SKU").ToString
                    grdConsumos.Rows(Fila).Cells("Material").Value = DtConsumo.Rows(ElementoLista).Item("Material").ToString
                    grdConsumos.Rows(Fila).Cells("idConsumo").Value = 0
                    grdConsumos.Rows(Fila).Cells("Consumo").Value = DtConsumo.Rows(ElementoLista).Item("Consumo").ToString
                    grdConsumos.Rows(Fila).Cells("idUMC").Value = CInt(DtConsumo.Rows(ElementoLista).Item("idUMC").ToString)
                    grdConsumos.Rows(Fila).Cells("UMC").Value = DtConsumo.Rows(ElementoLista).Item("UMC").ToString
                    grdConsumos.Rows(Fila).Cells("idProveedor").Value = CInt(DtConsumo.Rows(ElementoLista).Item("idProveedor").ToString)
                    grdConsumos.Rows(Fila).Cells("Proveedor").Value = DtConsumo.Rows(ElementoLista).Item("Proveedor").ToString
                    grdConsumos.Rows(Fila).Cells("Precio Compra").Value = CDbl(DtConsumo.Rows(ElementoLista).Item("Precio Compra").ToString)
                    grdConsumos.Rows(Fila).Cells("idUMProd").Value = CInt(DtConsumo.Rows(ElementoLista).Item("idUMProd").ToString)
                    grdConsumos.Rows(Fila).Cells("UMP").Value = DtConsumo.Rows(ElementoLista).Item("UMP").ToString
                    grdConsumos.Rows(Fila).Cells("Factor").Value = CInt(DtConsumo.Rows(ElementoLista).Item("Factor").ToString)
                    grdConsumos.Rows(Fila).Cells("PrecioUM").Value = CDbl(DtConsumo.Rows(ElementoLista).Item("PrecioUM").ToString)
                    grdConsumos.Rows(Fila).Cells("Costo X Par").Value = CDbl(DtConsumo.Rows(ElementoLista).Item("Costo X Par").ToString)
                    grdConsumos.Rows(Fila).Cells("productoEstiloId").Value = CInt(DtConsumo.Rows(ElementoLista).Item("productoEstiloId").ToString)
                    Try
                        'grdConsumos.Rows(tamaño).Cells("Orden").Value = CInt(consumosCopiados.Rows(grdConsumos.Rows.Count - 2).Item("orden").ToString) + 1

                        grdConsumos.Rows(Fila).Cells("Orden").Value = Fila + 1

                    Catch ex As Exception

                    End Try
                    If reemplazafilaanterior = True Then
                        reemplazafilaanterior = False
                    Else
                        CountFilas = CountFilas + 1
                    End If


                    contadorFila = contadorFila + 1

                End If

                ElementoLista = 0
            Next

        End If


        'For value = 0 To consumosCopiados.Rows.Count - 1



        '    If validarMaterialRepetido(CInt(consumosCopiados.Rows(value).Item("IdMaterial").ToString)) Then


        '        Fila = NumeroFilas + CountFilas

        '        If reemplazafilaanterior = True Then
        '            Fila = Fila - 1

        '        Else
        '            grdConsumos.DisplayLayout.Bands(0).AddNew()
        '        End If

        '        'grdConsumos.Rows(value + tamaño).Cells(" ").Value = CInt(consumosCopiados.Rows(value).Item(0).ToString)
        '        grdConsumos.Rows(Fila).Cells("Activo").Value = CBool(consumosCopiados.Rows(value).Item(1).ToString)
        '        grdConsumos.Rows(Fila).Cells("Editado").Value = CBool(consumosCopiados.Rows(value).Item(2).ToString)
        '        grdConsumos.Rows(Fila).Cells("Bloqueado").Value = CBool(consumosCopiados.Rows(value).Item(3).ToString)
        '        grdConsumos.Rows(Fila).Cells("Explosionar").Value = CBool(consumosCopiados.Rows(value).Item(4).ToString)
        '        grdConsumos.Rows(Fila).Cells("Lotear").Value = CBool(consumosCopiados.Rows(value).Item(5).ToString)
        '        grdConsumos.Rows(Fila).Cells("idComponente").Value = CInt(consumosCopiados.Rows(value).Item(6).ToString)
        '        grdConsumos.Rows(Fila).Cells("Componente").Value = consumosCopiados.Rows(value).Item(7).ToString
        '        grdConsumos.Rows(Fila).Cells("idClasificacion").Value = CInt(consumosCopiados.Rows(value).Item(8).ToString)
        '        grdConsumos.Rows(Fila).Cells("Clasificación").Value = consumosCopiados.Rows(value).Item(9).ToString
        '        grdConsumos.Rows(Fila).Cells("IdMaterial").Value = CInt(consumosCopiados.Rows(value).Item(10).ToString)
        '        grdConsumos.Rows(Fila).Cells("SKU").Value = consumosCopiados.Rows(value).Item(11).ToString
        '        grdConsumos.Rows(Fila).Cells("Material").Value = consumosCopiados.Rows(value).Item(12).ToString
        '        grdConsumos.Rows(Fila).Cells("idConsumo").Value = 0
        '        grdConsumos.Rows(Fila).Cells("Consumo").Value = consumosCopiados.Rows(value).Item(14).ToString
        '        grdConsumos.Rows(Fila).Cells("idUMC").Value = CInt(consumosCopiados.Rows(value).Item(15).ToString)
        '        grdConsumos.Rows(Fila).Cells("UMC").Value = consumosCopiados.Rows(value).Item(16).ToString
        '        grdConsumos.Rows(Fila).Cells("idProveedor").Value = CInt(consumosCopiados.Rows(value).Item(17).ToString)
        '        grdConsumos.Rows(Fila).Cells("Proveedor").Value = consumosCopiados.Rows(value).Item(18).ToString
        '        grdConsumos.Rows(Fila).Cells("Precio Compra").Value = CDbl(consumosCopiados.Rows(value).Item(19).ToString)
        '        grdConsumos.Rows(Fila).Cells("idUMProd").Value = CInt(consumosCopiados.Rows(value).Item(20).ToString)
        '        grdConsumos.Rows(Fila).Cells("UMP").Value = consumosCopiados.Rows(value).Item(21).ToString
        '        grdConsumos.Rows(Fila).Cells("Factor").Value = CInt(consumosCopiados.Rows(value).Item(22).ToString)
        '        grdConsumos.Rows(Fila).Cells("PrecioUM").Value = CDbl(consumosCopiados.Rows(value).Item(23).ToString)
        '        grdConsumos.Rows(Fila).Cells("Costo X Par").Value = CDbl(consumosCopiados.Rows(value).Item(24).ToString)
        '        grdConsumos.Rows(Fila).Cells("productoEstiloId").Value = CInt(consumosCopiados.Rows(value).Item(25).ToString)
        '        Try
        '            'grdConsumos.Rows(tamaño).Cells("Orden").Value = CInt(consumosCopiados.Rows(grdConsumos.Rows.Count - 2).Item("orden").ToString) + 1

        '            grdConsumos.Rows(Fila).Cells("Orden").Value = Fila + 1

        '        Catch ex As Exception

        '        End Try
        '        If reemplazafilaanterior = True Then
        '            reemplazafilaanterior = False
        '        Else
        '            CountFilas = CountFilas + 1
        '        End If

        '    End If
        'Next



        'End If

        'disenioConsumos()
    End Sub

    Public Sub AgregarFraccionesImportados()
        Dim obj As New catalagosBU
        Dim tamaño As Integer = 0
        Dim NumeroFilas As Integer = 0
        Dim CantidadFilas As Integer = 0
        tamaño = grdFracciones.Rows.Count
        NumeroFilas = grdFracciones.Rows.Count
        Try
            If grdFracciones.Rows(tamaño - 1).Cells("Fracción").Text = "" Then
                For value = 0 To fraccionesCopiadas.Rows.Count - 1
                    If validarFraccion(fraccionesCopiadas.Rows(value).Item("idFraccion").ToString, fraccionesCopiadas.Rows(value).Item("Observaciones").ToString) Then
                        If value = 0 Then
                        Else
                            grdFracciones.DisplayLayout.Bands(0).AddNew()
                        End If
                        grdFracciones.Rows(value).Cells("Activo").Value = True ' CBool(fraccionesCopiadas.Rows(value).Item("Activo").ToString)
                        grdFracciones.Rows(value).Cells("idFraccion").Value = fraccionesCopiadas.Rows(value).Item("idFraccion").ToString
                        grdFracciones.Rows(value).Cells("idFraccDes").Value = 0
                        grdFracciones.Rows(value).Cells("Fracción").Value = fraccionesCopiadas.Rows(value).Item("Fracción").ToString
                        grdFracciones.Rows(value).Cells("Costo").Value = CDbl(fraccionesCopiadas.Rows(value).Item("Costo").ToString)
                        grdFracciones.Rows(value).Cells("Pagar").Value = CBool(fraccionesCopiadas.Rows(value).Item("Pagar").ToString)
                        grdFracciones.Rows(value).Cells("Maquinaria").Value = fraccionesCopiadas.Rows(value).Item("Maquinaria").ToString
                        grdFracciones.Rows(value).Cells("maquinaid").Value = obj.getidMaquinaria(fraccionesCopiadas.Rows(value).Item("Maquinaria").ToString)
                        ''''''''''''''''''''''''''''''''''''''''''''
                        grdFracciones.Rows(value).Cells("Sumar Costo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Sumar Costo").ToString)
                        grdFracciones.Rows(value).Cells("Sumar Tiempo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Sumar Tiempo").ToString)
                        grdFracciones.Rows(value).Cells("Horas").Value = fraccionesCopiadas.Rows(value).Item("Horas").ToString
                        grdFracciones.Rows(value).Cells("Minutos").Value = fraccionesCopiadas.Rows(value).Item("Minutos").ToString
                        grdFracciones.Rows(value).Cells("Segundos").Value = fraccionesCopiadas.Rows(value).Item("Segundos").ToString
                        grdFracciones.Rows(value).Cells("Observaciones").Value = fraccionesCopiadas.Rows(value).Item("Observaciones").ToString

                        grdFracciones.Rows(value).Cells("Orden").Value = NumeroFilas + value


                    End If
                Next
            Else
                tamaño = grdFracciones.Rows.Count
                Dim Fila As Integer = 0

                For value = 0 To fraccionesCopiadas.Rows.Count - 1

                    If validarFraccion(fraccionesCopiadas.Rows(value).Item("idFraccion").ToString, fraccionesCopiadas.Rows(value).Item("Observaciones").ToString) Then
                        Fila = tamaño + CantidadFilas

                        grdFracciones.DisplayLayout.Bands(0).AddNew()
                        grdFracciones.Rows(Fila).Cells("Activo").Value = True ' CBool(fraccionesCopiadas.Rows(value).Item("Activo").ToString)
                        grdFracciones.Rows(Fila).Cells("idFraccion").Value = fraccionesCopiadas.Rows(value).Item("idFraccion").ToString
                        grdFracciones.Rows(Fila).Cells("idFraccDes").Value = 0
                        grdFracciones.Rows(Fila).Cells("Fracción").Value = fraccionesCopiadas.Rows(value).Item("Fracción").ToString
                        grdFracciones.Rows(Fila).Cells("Costo").Value = CDbl(fraccionesCopiadas.Rows(value).Item("Costo").ToString)
                        grdFracciones.Rows(Fila).Cells("Pagar").Value = CBool(fraccionesCopiadas.Rows(value).Item("Pagar").ToString)
                        grdFracciones.Rows(Fila).Cells("Maquinaria").Value = fraccionesCopiadas.Rows(value).Item("Maquinaria").ToString
                        grdFracciones.Rows(Fila).Cells("maquinaid").Value = obj.getidMaquinaria(fraccionesCopiadas.Rows(value).Item("Maquinaria").ToString)
                        ''''''''''''''''''''''''''''''''''''''''''''
                        grdFracciones.Rows(Fila).Cells("Sumar Costo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Sumar Costo").ToString)
                        grdFracciones.Rows(Fila).Cells("Sumar Tiempo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Sumar Tiempo").ToString)
                        grdFracciones.Rows(Fila).Cells("Horas").Value = fraccionesCopiadas.Rows(value).Item("Horas").ToString
                        grdFracciones.Rows(Fila).Cells("Minutos").Value = fraccionesCopiadas.Rows(value).Item("Minutos").ToString
                        grdFracciones.Rows(Fila).Cells("Segundos").Value = fraccionesCopiadas.Rows(value).Item("Segundos").ToString
                        grdFracciones.Rows(Fila).Cells("Observaciones").Value = fraccionesCopiadas.Rows(value).Item("Observaciones").ToString

                        grdFracciones.Rows(Fila).Cells("Orden").Value = NumeroFilas + CantidadFilas + 1
                        CantidadFilas = CantidadFilas + 1
                    End If
                Next

                'For value = 0 To fraccionesCopiadas.Rows.Count - 1
                '    tamaño = grdFracciones.Rows.Count
                '    If validarFraccion(fraccionesCopiadas.Rows(value).Item("idFraccion").ToString) Then
                '        grdFracciones.DisplayLayout.Bands(0).AddNew()
                '        grdFracciones.Rows(tamaño).Cells("Activo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Activo").ToString)
                '        grdFracciones.Rows(tamaño).Cells("idFraccion").Value = fraccionesCopiadas.Rows(value).Item("idFraccion").ToString
                '        grdFracciones.Rows(tamaño).Cells("idFraccDes").Value = 0
                '        grdFracciones.Rows(tamaño).Cells("Fracción").Value = fraccionesCopiadas.Rows(value).Item("Fracción").ToString
                '        grdFracciones.Rows(tamaño).Cells("Costo").Value = CDbl(fraccionesCopiadas.Rows(value).Item("Costo").ToString)
                '        grdFracciones.Rows(tamaño).Cells("Pagar").Value = CBool(fraccionesCopiadas.Rows(value).Item("Pagar").ToString)
                '        grdFracciones.Rows(tamaño).Cells("Maquinaria").Value = fraccionesCopiadas.Rows(value).Item("Maquinaria").ToString
                '        grdFracciones.Rows(value).Cells("maquinaid").Value = obj.getidMaquinaria(fraccionesCopiadas.Rows(value).Item("Maquinaria").ToString)
                '        ''''''''''''''''''''''''''''''''''''''''''''
                '        grdFracciones.Rows(value).Cells("Sumar Costo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Sumar Costo").ToString)
                '        grdFracciones.Rows(value).Cells("Sumar Tiempo").Value = CBool(fraccionesCopiadas.Rows(value).Item("Sumar Tiempo").ToString)
                '        grdFracciones.Rows(value).Cells("Horas").Value = fraccionesCopiadas.Rows(value).Item("Horas").ToString
                '        grdFracciones.Rows(value).Cells("Minutos").Value = fraccionesCopiadas.Rows(value).Item("Minutos").ToString
                '        grdFracciones.Rows(value).Cells("Segundos").Value = fraccionesCopiadas.Rows(value).Item("Segundos").ToString
                '        grdFracciones.Rows(value).Cells("Observaciones").Value = fraccionesCopiadas.Rows(value).Item("Observaciones").ToString

                '        grdFracciones.Rows(value).Cells("Orden").Value = NumeroFilas + value
                '    End If
                'Next
            End If
        Catch ex As Exception
        End Try

        disenioFracciones()
    End Sub

    Public Sub disenioFracciones()

        Dim band As UltraGridBand = Me.grdFracciones.DisplayLayout.Bands(0)
        band.ColHeaderLines = 2
        band.GroupHeaderLines = 2

        With grdFracciones.DisplayLayout.Bands(0)
            .Columns("idFraccion").Hidden = True
            .Columns("idFraccDes").Hidden = True
            '.Columns("Fracción").CellActivation = Activation.NoEdit
            '.Columns("Costo").CellActivation = Activation.NoEdit
            '.Columns("Maquinaria").CellActivation = Activation.NoEdit
            .Columns("Activo").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
            .Columns("Activo").CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            .Columns("Activo").Style = ColumnStyle.CheckBox
            .Columns("Activo").Header.Caption = "Activo"
            .Columns("Costo").Format = "####0.000"
            '.Columns("Pagar").CellActivation = Activation.NoEdit
            '''''''''''''''''''''''''''''''''''''''
            '.Columns("Sumar Costo").CellActivation = Activation.NoEdit
            '.Columns("Sumar Tiempo").CellActivation = Activation.NoEdit
            '.Columns("Horas").CellActivation = Activation.NoEdit
            '.Columns("Minutos").CellActivation = Activation.NoEdit
            '.Columns("Segundos").CellActivation = Activation.NoEdit

            '.Columns(" ").Width = 25
            .Columns("Activo").Width = 35
            .Columns("Pagar").Width = 35
            .Columns("Maquinaria").Width = 250
            .Columns("Costo").Width = 45
            .Columns("Fracción").Width = 250
            .Columns("Costo").CellAppearance.TextHAlign = HAlign.Right
            '''''''''''''''''''''''''''
            .Columns("Sumar Costo").Width = 35
            .Columns("Sumar Tiempo").Width = 35
            .Columns("Horas").Width = 35
            .Columns("Minutos").Width = 35
            .Columns("Segundos").Width = 35
            .Columns("Sumar Costo").Header.Caption = "Sumar" + vbCrLf + "Costo"
            .Columns("Sumar Tiempo").Header.Caption = "Sumar" + vbCrLf + "Tiempo"

            .Columns("Orden").CellActivation = Activation.NoEdit

        End With
        grdFracciones.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdFracciones.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex

        Try
            pintarceldas()
        Catch ex As Exception
        End Try
    End Sub

    Public Sub historial()
        Dim obj As New catalagosBU
        Dim tablaHistorial As DataTable
        tablaHistorial = obj.HistorialProductoEstilo(productoEstiloId)
        grdHistorial.DataSource = tablaHistorial
        disenioHistorial()
    End Sub

    Public Sub disenioHistorial()
        With grdHistorial.DisplayLayout.Bands(0)
            For value = 0 To grdHistorial.Rows.Count - 1
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "D" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "AD" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "AUTORIZADO DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "AP" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "AUTORIZADO PRODUCCIÓN"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "I" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "INACTIVO NAVE"
                End If
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "DP" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Value = "DESCONTINUADO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "D" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "AD" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "AUTORIZADO DESARROLLO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "AP" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "AUTORIZADO PRODUCCIÓN"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "I" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "INACTIVO NAVE"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "DP" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "DESCONTINUADO"
                End If
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "AN" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Value = "ASIGNADO A NAVE"
                End If
            Next

            For value = 0 To grdHistorial.Rows.Count - 1
                If grdHistorial.Rows(value).Cells("Estatus de").Text = "DESARROLLO" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")

                ElseIf grdHistorial.Rows(value).Cells("Estatus de").Text = "AUTORIZADO DESARROLLO" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")

                ElseIf grdHistorial.Rows(value).Cells("Estatus de").Text = "AUTORIZADO PRODUCCIÓN" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")

                ElseIf grdHistorial.Rows(value).Cells("Estatus de").Text = "INACTIVO NAVE" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")

                ElseIf grdHistorial.Rows(value).Cells("Estatus de").Text = "DESCONTINUADO" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")

                ElseIf grdHistorial.Rows(value).Cells("Estatus de").Text = "ASIGNADO A NAVE" Then
                    grdHistorial.Rows(value).Cells("Estatus de").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E2EFE")
                End If
            Next

            For value = 0 To grdHistorial.Rows.Count - 1
                If grdHistorial.Rows(value).Cells("Estatus a").Text = "DESARROLLO" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFBF00")

                ElseIf grdHistorial.Rows(value).Cells("Estatus a").Text = "AUTORIZADO DESARROLLO" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#31B404")

                ElseIf grdHistorial.Rows(value).Cells("Estatus a").Text = "AUTORIZADO PRODUCCIÓN" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E9AFE")

                ElseIf grdHistorial.Rows(value).Cells("Estatus a").Text = "INACTIVO NAVE" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#424242")

                ElseIf grdHistorial.Rows(value).Cells("Estatus a").Text = "DESCONTINUADO" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#DF0101")

                ElseIf grdHistorial.Rows(value).Cells("Estatus a").Text = "ASIGNADO A NAVE" Then
                    grdHistorial.Rows(value).Cells("Estatus a").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#2E2EFE")
                End If
            Next

            .Columns("Estatus de").CellActivation = Activation.NoEdit
            .Columns("Estatus a").CellActivation = Activation.NoEdit
            .Columns("Usuario").CellActivation = Activation.NoEdit
            .Columns("Fecha Cambio").CellActivation = Activation.NoEdit
            .Columns("Nave Asignada").CellActivation = Activation.NoEdit

        End With
        grdHistorial.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdHistorial.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
    End Sub

    Function validarMaterialRepetido(ByVal idMaterial As Integer) As Boolean
        Dim consumos As New DataTable
        consumos = grdConsumos.DataSource

        For Each row As DataRow In consumos.Rows
            If row("IdMaterial") = idMaterial Then
                Return False
            End If
        Next

        Return True
    End Function

    Function validarFraccion(idFraccion As Integer, ByVal Observaciones As String) As Boolean
        Dim d As New DataTable
        d = grdFracciones.DataSource
        For Each row As DataRow In d.Rows
            Try
                If row("idFraccion") <> 0 Then
                    If row("idFraccion") = idFraccion And row("Observaciones").ToString = Observaciones Then

                        Return False
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        Return True
    End Function

    Function validarMaterial(idMaterial As Integer) As Boolean
        Dim d As New DataTable
        d = grdConsumos.DataSource
        For Each row As DataRow In d.Rows
            Try
                If row("IdMaterial") <> 0 Then
                    If row("IdMaterial") = idMaterial Then
                        Return False
                    End If
                End If
            Catch ex As Exception
            End Try
        Next
        Return True
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If grdExportarConsumos.Rows.Count > 0 Then
            ExportarGridAExcel()
        End If
    End Sub
    Private Sub ExportarGridAExcel()

        Dim sfd As New SaveFileDialog
        'sfd.DefaultExt = "xlsx"
        'sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                ultExportGrid.Export(grdExportarConsumos, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub grdFracciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdFracciones.KeyPress ', grdConsumos.KeyPress

        Try
            If grdFracciones.ActiveCell.Column.ToString = "Horas" Then
                If grdFracciones.Rows.Count > 0 Then
                    Try
                        If Not grdFracciones.ActiveCell.IsFilterRowCell Then

                            If Char.IsDigit(e.KeyChar) Then
                                If grdFracciones.ActiveRow.Cells("Horas").Text = "" Then
                                    If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Then
                                        e.Handled = False
                                    Else
                                        e.Handled = True
                                    End If
                                ElseIf grdFracciones.ActiveRow.Cells("Horas").Text.Length = 1 Then
                                    If grdFracciones.ActiveRow.Cells("Horas").Text = 0 Then
                                        If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or
                                             e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "10" Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    Else
                                        If Char.IsDigit(e.KeyChar) Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    End If
                                ElseIf grdFracciones.ActiveRow.Cells("Horas").Text.Length = 2 Then
                                    e.Handled = True
                                End If
                            ElseIf Char.IsControl(e.KeyChar) Then
                                e.Handled = False
                            ElseIf e.KeyChar = "." Then
                                e.Handled = True
                            Else
                                e.Handled = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If

            If grdFracciones.ActiveCell.Column.ToString = "Minutos" Then
                If grdFracciones.Rows.Count > 0 Then
                    Try
                        If Not grdFracciones.ActiveCell.IsFilterRowCell Then

                            If Char.IsDigit(e.KeyChar) Then
                                If grdFracciones.ActiveRow.Cells("Minutos").Text = "" Then
                                    If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Then
                                        e.Handled = False
                                    Else
                                        e.Handled = True
                                    End If
                                ElseIf grdFracciones.ActiveRow.Cells("Minutos").Text.Length = 1 Then
                                    If grdFracciones.ActiveRow.Cells("Minutos").Text = 0 Then
                                        If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or
                                             e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "10" Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    Else
                                        If Char.IsDigit(e.KeyChar) Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    End If
                                ElseIf grdFracciones.ActiveRow.Cells("Minutos").Text.Length = 2 Then
                                    e.Handled = True
                                End If
                            ElseIf Char.IsControl(e.KeyChar) Then
                                e.Handled = False
                            ElseIf e.KeyChar = "." Then
                                e.Handled = True
                            Else
                                e.Handled = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If

            If grdFracciones.ActiveCell.Column.ToString = "Segundos" Then
                If grdFracciones.Rows.Count > 0 Then
                    Try
                        If Not grdFracciones.ActiveCell.IsFilterRowCell Then

                            If Char.IsDigit(e.KeyChar) Then
                                If grdFracciones.ActiveRow.Cells("Segundos").Text = "" Then
                                    If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Then
                                        e.Handled = False
                                    Else
                                        e.Handled = True
                                    End If
                                ElseIf grdFracciones.ActiveRow.Cells("Segundos").Text.Length = 1 Then
                                    If grdFracciones.ActiveRow.Cells("Segundos").Text = 0 Then
                                        If e.KeyChar = "0" Or e.KeyChar = "1" Or e.KeyChar = "2" Or e.KeyChar = "3" Or e.KeyChar = "4" Or e.KeyChar = "5" Or
                                             e.KeyChar = "6" Or e.KeyChar = "7" Or e.KeyChar = "8" Or e.KeyChar = "9" Or e.KeyChar = "10" Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    Else
                                        If Char.IsDigit(e.KeyChar) Then
                                            e.Handled = False
                                        Else
                                            e.Handled = True
                                        End If
                                    End If
                                ElseIf grdFracciones.ActiveRow.Cells("Segundos").Text.Length = 2 Then
                                    e.Handled = True
                                End If
                            ElseIf Char.IsControl(e.KeyChar) Then
                                e.Handled = False
                            ElseIf e.KeyChar = "." Then
                                e.Handled = True
                            Else
                                e.Handled = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                End If
            End If
            If grdFracciones.ActiveCell.Column.ToString = "Orden" Then
                If Char.IsDigit(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If
            If grdFracciones.ActiveCell.Column.ToString = "Observaciones" Then
                If Char.IsDigit(e.KeyChar) Or Char.IsLetter(e.KeyChar) Then
                    e.Handled = False
                ElseIf Char.IsControl(e.KeyChar) Then
                    e.Handled = False
                ElseIf e.KeyChar = "." Or e.KeyChar = "-" Or e.KeyChar = "/" Or e.KeyChar = "#" Then
                    e.Handled = False
                ElseIf e.KeyChar = " " Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            End If


        Catch ex As Exception
        End Try

        Try
            calcularTotales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub grdFracciones_KeyDown(sender As Object, e As KeyEventArgs) Handles grdFracciones.KeyDown

        Try
            If grdFracciones.ActiveCell.Column.ToString = "Horas" Then
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    Me.grdFracciones.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell)
                    Me.grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            ElseIf grdFracciones.ActiveCell.Column.ToString = "Minutos" Then
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    Me.grdFracciones.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell)
                    Me.grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            ElseIf grdFracciones.ActiveCell.Column.ToString = "Costo" Then
                If e.KeyCode = Windows.Forms.Keys.Enter Then
                    grdFracciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                    Dim banda As UltraGridBand = grdFracciones.DisplayLayout.Bands(0)
                    If grdFracciones.ActiveRow.HasNextSibling(True) Then
                        Dim nextRow As UltraGridRow = grdFracciones.ActiveRow.GetSibling(SiblingRow.Next, True)
                        grdFracciones.ActiveCell = nextRow.Cells(grdFracciones.ActiveCell.Column)
                        e.Handled = True
                        grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                    End If
                End If
            Else
                'grdFracciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                'Dim banda As UltraGridBand = grdFracciones.DisplayLayout.Bands(0)
                'If grdFracciones.ActiveRow.HasNextSibling(True) Then
                '    Dim nextRow As UltraGridRow = grdFracciones.ActiveRow.GetSibling(SiblingRow.Next, True)
                '    grdFracciones.ActiveCell = nextRow.Cells(grdFracciones.ActiveCell.Column)
                '    e.Handled = True
                '    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                'End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Up Then
                grdFracciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdFracciones.DisplayLayout.Bands(0)
                If grdFracciones.ActiveRow.HasPrevSibling(True) Then
                    Dim nextRow As UltraGridRow = grdFracciones.ActiveRow.GetSibling(SiblingRow.Previous, True)
                    grdFracciones.ActiveCell = nextRow.Cells(grdFracciones.ActiveCell.Column)
                    e.Handled = True
                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If e.KeyCode = Windows.Forms.Keys.Down Then
                grdFracciones.PerformAction(UltraGridAction.ExitEditMode, False, False)
                Dim banda As UltraGridBand = grdFracciones.DisplayLayout.Bands(0)
                If grdFracciones.ActiveRow.HasNextSibling(True) Then
                    Dim nextRow As UltraGridRow = grdFracciones.ActiveRow.GetSibling(SiblingRow.Next, True)
                    grdFracciones.ActiveCell = nextRow.Cells(grdFracciones.ActiveCell.Column)
                    e.Handled = True
                    grdFracciones.PerformAction(UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            If grdFracciones.ActiveCell.Column.ToString = "Observaciones" Then
                'actualizarLista(grdFracciones.ActiveCell.Value.ToString)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdFracciones_AfterExitEditMode(sender As Object, e As EventArgs) Handles grdFracciones.AfterExitEditMode
        Try
            If grdFracciones.ActiveCell.Column.ToString = "Horas" Or grdFracciones.ActiveCell.Column.ToString = "Minutos" Or
                grdFracciones.ActiveCell.Column.ToString = "Segundos" Or grdFracciones.ActiveCell.Column.ToString = "Sumar Tiempo" Then
                'calcularTotales()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub grdConsumos_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdConsumos.SelectionDrag

        If grdConsumos.AllowDrop = True Then
            For Each fila As UltraGridRow In grdConsumos.Rows
                If fila.Selected = True Then
                    fila.RowSelectorAppearance.BackColor = Drawing.Color.LightSkyBlue
                    'fila.RowSelectorAppearance.BackColor = Nothing
                End If
            Next
            grdConsumos.DoDragDrop(grdConsumos.Selected.Rows, DragDropEffects.Move)
        End If


    End Sub

    Private Sub LimpiarColorSeleccionado()

        For Each fila As UltraGridRow In grdConsumos.Rows
            If fila.Selected = True Then
                fila.RowSelectorAppearance.BackColor = Nothing
                'fila.RowSelectorAppearance.BackColor = Nothing
            End If
        Next
    End Sub

    Private Sub LimpiarColorSeleccionadoFracciones()

        For Each fila As UltraGridRow In grdFracciones.Rows
            If fila.Selected = True Then
                fila.RowSelectorAppearance.BackColor = Nothing
                'fila.RowSelectorAppearance.BackColor = Nothing
            End If
        Next
    End Sub

    Private Sub grdFracciones_SelectionDrag(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles grdFracciones.SelectionDrag

        If grdFracciones.AllowDrop = True Then
            For Each fila As UltraGridRow In grdFracciones.Rows
                If fila.Selected = True Then
                    fila.RowSelectorAppearance.BackColor = Drawing.Color.LightSkyBlue
                    'fila.RowSelectorAppearance.BackColor = Nothing
                End If
            Next

            grdFracciones.DoDragDrop(grdFracciones.Selected.Rows, DragDropEffects.Move)
        End If


    End Sub

    Private Sub grdFracciones_DragOver(sender As Object, e As DragEventArgs) Handles grdFracciones.DragOver
        e.Effect = DragDropEffects.Move
        Dim grid As UltraGrid = TryCast(sender, UltraGrid)
        Dim pointInGridCoords As Point = grid.PointToClient(New Point(e.X, e.Y))

        If pointInGridCoords.Y < 20 Then
            'Scroll up
            Me.grdFracciones.ActiveRowScrollRegion.Scroll(RowScrollAction.LineUp)
        ElseIf pointInGridCoords.Y > grid.Height - 20 Then
            'Scroll down
            Me.grdFracciones.ActiveRowScrollRegion.Scroll(RowScrollAction.LineDown)
        End If
    End Sub

    Private Sub grdFracciones_DragDrop(sender As Object, e As DragEventArgs) Handles grdFracciones.DragDrop
        Dim dropIndex As Integer

        'Get the position on the grid where the dragged row(s) are to be dropped. 
        'get the grid coordinates of the row (the drop zone) 
        Dim uieOver As UIElement = grdFracciones.DisplayLayout.UIElement.ElementFromPoint(grdFracciones.PointToClient(New Point(e.X, e.Y)))

        'get the row that is the drop zone/or where the dragged row is to be dropped 
        Dim ugrOver As UltraGridRow = TryCast(uieOver.GetContext(GetType(UltraGridRow), True), UltraGridRow)

        If ugrOver IsNot Nothing Then
            dropIndex = ugrOver.Index    'index/position of drop zone in grid 
            If dropIndex < 0 Then
                dropIndex = 0
            End If
            'get the dragged row(s)which are to be dragged to another position in the grid 
            Dim SelRows As SelectedRowsCollection = TryCast(DirectCast(e.Data.GetData(GetType(SelectedRowsCollection)), SelectedRowsCollection), SelectedRowsCollection)
            'get the count of selected rows and drop each starting at the dropIndex 
            For Each aRow As UltraGridRow In SelRows
                'move the selected row(s) to the drop zone 
                grdFracciones.Rows.Move(aRow, dropIndex)

            Next
        End If
        Dim ancho As Integer = grdFracciones.Rows(0).Height
        ActualizarOrdenFracciones()
        grdFracciones.ActiveRowScrollRegion.Scroll(RowScrollAction.Top)
        grdFracciones.DisplayLayout.RowSelectorImages.DataChangedImage = Nothing
        grdFracciones.DisplayLayout.RowSelectorImages.ActiveAndDataChangedImage = Nothing
        LimpiarColorSeleccionadoFracciones()
    End Sub

    Private Sub GuardaConsumosNaveProduccion()

        Try

            Dim vXmlMaterialesCambiar As XElement = New XElement("Materiales")

            For value = 0 To grdConsumos.Rows.Count - 1
                For Each item As MaterialConsumos In vLstMateriales
                    If item.PIdMaterial = grdConsumos.Rows(value).Cells("idMaterial").Value Then
                        If grdConsumos.Rows(value).Cells("Activo").Value = True Then
                            Dim vNodo As XElement = New XElement("Material")
                            vNodo.Add(New XAttribute("Bloqueado", grdConsumos.Rows(value).Cells("Bloqueado").Value))
                            vNodo.Add(New XAttribute("Explosionar", grdConsumos.Rows(value).Cells("Explosionar").Value))
                            vNodo.Add(New XAttribute("Lotear", grdConsumos.Rows(value).Cells("Lotear").Value))
                            vNodo.Add(New XAttribute("idComponente", grdConsumos.Rows(value).Cells("idComponente").Value))
                            vNodo.Add(New XAttribute("idUMProd", grdConsumos.Rows(value).Cells("idUMProd").Value))
                            vNodo.Add(New XAttribute("idProveedor", grdConsumos.Rows(value).Cells("idProveedor").Value))
                            vNodo.Add(New XAttribute("CostoXPar", grdConsumos.Rows(value).Cells("Costo X Par").Value))
                            vNodo.Add(New XAttribute("Consumo", grdConsumos.Rows(value).Cells("Consumo").Value))
                            vNodo.Add(New XAttribute("idUMC", grdConsumos.Rows(value).Cells("idUMC").Value))
                            vNodo.Add(New XAttribute("PrecioUM", grdConsumos.Rows(value).Cells("PrecioUM").Value))
                            vNodo.Add(New XAttribute("Factor", grdConsumos.Rows(value).Cells("Factor").Value))
                            vNodo.Add(New XAttribute("PrecioCompra", grdConsumos.Rows(value).Cells("Precio Compra").Value))
                            vNodo.Add(New XAttribute("idConsumo", grdConsumos.Rows(value).Cells("idConsumo").Value))
                            vNodo.Add(New XAttribute("Orden", grdConsumos.Rows(value).Cells("Orden").Value))
                            vNodo.Add(New XAttribute("IdMaterial", grdConsumos.Rows(value).Cells("IdMaterial").Value))

                            vXmlMaterialesCambiar.Add(vNodo)
                        End If
                    End If
                Next
            Next

            Dim obj As New ConsumosBU
            obj.ActualizarConsumosNaveProduccion(vXmlMaterialesCambiar.ToString(), productoEstiloId, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid, idNaveConsulta)

        Catch ex As Exception

            Dim mensajeAdvertencia As New ErroresForm
            mensajeAdvertencia.mensaje = ex.Message
            mensajeAdvertencia.ShowDialog()

        End Try
    End Sub

    Private Sub picFotografia_DoubleClick(sender As Object, e As EventArgs) Handles picFotografia.DoubleClick
        Try
            Dim form As New ImagenEstiloForm
            form.imagen = rutaImagenForm
            form.ShowDialog()
        Catch ex As Exception
            objAdvertencia.mensaje = "No se puede localizar el archivo."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        End Try
    End Sub

    Private Sub btn_ExportarFracciones_Click(sender As Object, e As EventArgs) Handles btn_ExportarFracciones.Click
        If grdFracciones.Rows.Count > 0 Then
            exportarFracciones()
        End If
    End Sub

    Private Sub exportarFracciones()
        Dim sfd As New SaveFileDialog
        Dim tablaDatos As DataTable
        Dim workbook As New Infragistics.Documents.Excel.Workbook
        Dim worksheet As Infragistics.Documents.Excel.Worksheet = workbook.Worksheets.Add("Fracciones")

        'tbaFracciones = recorrerYgenerarNuevaTablaFracciones()

        sfd.DefaultExt = "xls"
        sfd.Filter = "Excel Files|*.xls"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                Me.Cursor = Cursors.WaitCursor

                'ultExportGrid.Export(recorrerYgenerarNuevaTablaFracciones(), fileName)

                tablaDatos = recorrerYgenerarNuevaTablaFracciones()

                worksheet.Columns.Item(0).Width = 3650
                worksheet.Columns.Item(1).Width = 3650
                worksheet.Columns.Item(2).Width = 2920

                Dim inicio As Integer = 0

                worksheet.Rows.Item(inicio).Cells.Item(0).Value = tablaDatos.Columns(0).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(1).Value = tablaDatos.Columns(1).ColumnName.ToString()
                worksheet.Rows.Item(inicio).Cells.Item(2).Value = tablaDatos.Columns(2).ColumnName.ToString()

                For r As Integer = (0) To tablaDatos.Rows.Count - 1
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(0).Value = tablaDatos.Rows(r).Item("Orden").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(1).Value = tablaDatos.Rows(r).Item("Fracción").ToString()
                    worksheet.Rows.Item(r + inicio + 1).Cells.Item(2).Value = tablaDatos.Rows(r).Item("Costo").ToString()
                Next

                For i As Int16 = inicio To inicio Step 1
                    For j As Int16 = 0 To 2 Step 1
                        worksheet.Rows(i).Cells(j).CellFormat.Fill = New CellFillPattern(New WorkbookColorInfo(Color.LightGray), WorkbookColorInfo.Automatic, FillPatternStyle.Solid)
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i).Cells(j).CellFormat.Font.ColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next

                For i As Int16 = 0 To tablaDatos.Rows.Count - 1 Step 1
                    For j As Int16 = 0 To 2 Step 1

                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.VerticalCellAlignment.Center
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.Alignment = Infragistics.Documents.Excel.HorizontalCellAlignment.Center
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.LeftBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.RightBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.BottomBorderColorInfo = New WorkbookColorInfo(Color.Black)
                        worksheet.Rows(i + inicio + 1).Cells(j).CellFormat.TopBorderColorInfo = New WorkbookColorInfo(Color.Black)
                    Next
                Next


                workbook.Save(fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function recorrerYgenerarNuevaTablaFracciones()
        Dim tablaFracciones As New DataTable
        Dim tablaGridFracciones As DataTable


        tablaFracciones.Columns.Add("Orden")
        tablaFracciones.Columns.Add("Fracción")
        tablaFracciones.Columns.Add("Costo")
        tablaGridFracciones = grdFracciones.DataSource
        For i As Integer = 0 To tablaGridFracciones.Rows.Count - 1
            If tablaGridFracciones.Rows(i).Item("Orden").ToString() <> "" Then
                tablaFracciones.Rows.Add(New Object() {tablaGridFracciones.Rows(i).Item("Orden").ToString(), tablaGridFracciones.Rows(i).Item("Fracción").ToString(), tablaGridFracciones.Rows(i).Item("Costo").ToString()})
            End If
        Next
        Return tablaFracciones
    End Function

End Class