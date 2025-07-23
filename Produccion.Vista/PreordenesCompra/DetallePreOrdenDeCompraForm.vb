Imports Produccion.Negocios
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Tools

Public Class DetallePreOrdenDeCompraForm
    Public programa As String = ""
    Public nave As Integer = 0
    Public proveedor As Integer = 0
    Public idpo As Integer
    Public estatus As String = ""
    Public NuevoRegistro As Boolean
    Public proveedornombre As String = ""
    Public fechaprograma As String = ""
    Public fechaentrega As String = ""
    Public tipodeorden As String = ""
    Public descuento As Double = 0
    Public numeroorden As String = ""
    Public pares As String = ""
    Public observaciones As String = ""
    Public Manual As Integer = 0
    Public oc As String = String.Empty
    Public monedaID As Integer = 0


    Dim tablaDatosNave As New DataTable
    Dim tablaOrdenCompra As New DataTable
    Dim TablaOrdenDeCompraDetalle As New DataTable
    Dim simbolo As String
    Dim listaMateriales As New List(Of Integer)
    Dim filaBorrada As Integer = 0
    Dim objConfirmacion As New ConfirmarForm
    Dim TOTALIDAD As Double = 0
    Dim dtColumnasVacias As New DataTable


    Private Sub DetalleOrdenDeCompraForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New PreordenCompraBU

        If Manual = 1 And NuevoRegistro = True Then
            txtAño.Value = DatePart(DateInterval.Year, Now)
            txtSemana.Value = If(DatePart(DateInterval.Year, Now) = 2021, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) - 1, DatePart(DateInterval.WeekOfYear, Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1))

            LlenarListaProveedoresProgramaNave()
            dtColumnasVacias = obj.ObtieneColumnasParaGrid("", 0, 0, 0)
            grdOrdenCompra.DataSource = dtColumnasVacias
            diseñoGrid()

        ElseIf Manual = 0 And NuevoRegistro = False Then
            CargarMateriales()
            calcularClasificaciones()
            CalcularConIva()
            txtObservaciones.Text = observaciones
            Me.Cursor = Cursors.Default
            If estatus = "AUTORIZADA" Then
                btnAutorizar.Enabled = False
                lblNumeroOC.Visible = True
                lblNumeroOCText.Visible = True
                lblNumeroOCText.Text = numeroorden
            End If
        Else
                Me.Cursor = Cursors.WaitCursor
            CargarMateriales()
            grdOrdenCompra.DisplayLayout.Bands(0).AddNew()
            diseñoGrid2()
            LlenarListaProveedoresProgramaNave()
            CalcularConIva()
            calcularClasificaciones()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub LlenarListaProveedoresProgramaNave()
        Dim obj As New PreordenCompraBU
        Dim componentes As New DataTable
        componentes = obj.ConsultaProveedores(nave)

        If Not componentes.Rows.Count = 0 Then
            componentes.Rows.InsertAt(componentes.NewRow, 0)
            cbxProveedores.DataSource = componentes
            cbxProveedores.DisplayMember = "proveedor"
            cbxProveedores.ValueMember = "id"
        End If
        cbxProveedores.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
        cbxProveedores.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub


    Public Sub calcularClasificaciones()

        Dim obj As New PreordenCompraBU

        Dim componente As String = ""
        Dim clasificacion As String = ""
        Dim unidadmedida As String = ""
        Dim total As Double = 0
        Dim idclasificacion As Integer = 0
        Dim consumo As Double = 0

        Dim listaClasificaciones As New List(Of Integer)

        Dim Tabla As New DataTable
        Tabla.Columns.Add("Clasificación")
        Tabla.Columns.Add("Consumo")
        Tabla.Columns.Add("UMC")
        Tabla.Columns.Add("Total")

        Try
            For value = 0 To grdOrdenCompra.Rows.Count - 1
                Try
                    clasificacion = grdOrdenCompra.Rows(value).Cells("IDc").Value
                    If listaClasificaciones.Contains(clasificacion) Then
                    Else
                        listaClasificaciones.Add(clasificacion)
                    End If
                Catch ex As Exception

                End Try
            Next

            For x = 0 To listaClasificaciones.Count - 1
                consumo = 0
                total = 0
                Dim tablaclasificaciones = obj.ObtenerNombreClasificacion(listaClasificaciones.Item(x))
                clasificacion = tablaclasificaciones.Rows(0).Item(0).ToString

                For value = 0 To grdOrdenCompra.Rows.Count - 1
                    If grdOrdenCompra.Rows(value).Cells("IDc").Text = listaClasificaciones.Item(x).ToString Then
                        consumo = consumo + grdOrdenCompra.Rows(value).Cells("Total Pedir").Value
                        unidadmedida = grdOrdenCompra.Rows(value).Cells("UMC").Text
                        total = total + grdOrdenCompra.Rows(value).Cells("Total Compra").Value
                    End If
                Next

                Dim rowc As DataRow = Tabla.NewRow()
                rowc("Clasificación") = clasificacion
                rowc("Consumo") = Format(consumo, "##,##0.00")
                rowc("UMC") = unidadmedida
                rowc("Total") = Format(total, "" & simbolo & " ##,##0.00")
                Tabla.Rows.Add(rowc)

                If unidadmedida.Equals("PARES") Then
                    lblPares.Visible = True
                    lblParesText.Visible = True
                Else
                    lblPares.Visible = False
                    lblParesText.Visible = False
                End If

            Next

            grdClasificacion.DataSource = Tabla
            diseñoGridClasificacion()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub ActualizarPrecioProveedorSeleccionado() 
        Try
            If grdOrdenCompra.ActiveCell.Column.ToString = "Total Pedir" Then
                Dim obj As New PreordenCompraBU
                Dim precio As New DataTable
                Try
                    Dim MaterialNaveId = grdOrdenCompra.ActiveRow.Cells("IDmn").Value
                    precio = obj.ConsultaPrecio(MaterialNaveId, grdOrdenCompra.ActiveRow.Cells("IDp").Value)
                    Dim precioUnitario = precio.Rows(0).Item(0).ToString
                    simbolo = grdOrdenCompra.ActiveRow.Cells("mone_simbolo").Value
                    grdOrdenCompra.ActiveRow.Cells("Precio Unitario").Value = precioUnitario
                    grdOrdenCompra.ActiveRow.Cells("Precio Unitario").Column.Format = "" & simbolo & " ##,##0.00"
                    Dim total = precioUnitario * grdOrdenCompra.ActiveRow.Cells("Total Pedir").Value
                    grdOrdenCompra.ActiveRow.Cells("Total Compra").Value = total
                    grdOrdenCompra.ActiveRow.Cells("Total Compra").Column.Format = "" & simbolo & " ##,##0.00"
                    Dim idproveedorpedir = cbxProveedores.SelectedValue
                    diseñoGrid()
                    CalcularConIva()
                    calcularClasificaciones()
                Catch ex As Exception
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CargarMateriales()
        Dim obj As New PreordenCompraBU
        Dim tablas As New DataTable

        tablas = obj.ObtieneColumnasParaGrid(programa, nave, proveedor, idpo)

        If idpo <> 0 Then
            cmbProgramaPor.Text = tablas(0)("ProgramaPor").ToString()
            cmbTipoPago.Text = tablas(0)("Plazo").ToString()
            cmbMoneda.Text = tablas(0)("Moneda").ToString()
            monedaID = tablas(0)("IdMoneda").ToString()

            cmbProgramaPor.Enabled = False
            cmbTipoPago.Enabled = False
            cmbMoneda.Enabled = False

            If cmbProgramaPor.Text = "SEMANA" Then
                lblSemana.Visible = True
                txtSemana.Visible = True
                lblAño.Visible = True
                txtAño.Visible = True
                txtSemana.Text = tablas(0)("Semana")
                txtAño.Text = tablas(0)("Año")
            End If
        End If


        grdOrdenCompra.DataSource = tablas

        For value = 0 To tablas.Rows.Count - 1
            listaMateriales.Add(tablas.Rows(value).Item("IDmn"))
        Next

        diseñoGrid()
    End Sub

    Private Sub txtDescuento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim caracter As Char = e.KeyChar
        If (Char.IsNumber(caracter)) Or (caracter = ChrW(Keys.Back)) Or (caracter = ".") And (txtDescuento.Text.Contains(".") = False) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub CalcularConIva()
        Dim total As Double = 0
        Dim iva As Double = 0
        Dim subtotal As Double = 0
        Dim descuento As Double = 0
        Dim Totaldescuento As Double = 0

        If txtDescuento.Text = "" Then
            descuento = 0
        Else
            descuento = txtDescuento.Text
        End If
        Try
            Try
                For value = 0 To grdOrdenCompra.Rows.Count - 1
                    subtotal = subtotal + grdOrdenCompra.Rows(value).Cells("Total Compra").Value
                Next
            Catch ex As Exception
            End Try

            Totaldescuento = subtotal * (descuento / 100)
            TOTALIDAD = subtotal - Totaldescuento
            iva = TOTALIDAD * 0.16

            total = iva + TOTALIDAD


            txtIvaText.Text = Format(iva, "##,##0.00")
            txtSubtotalText.Text = Format(subtotal, "##,##0.00")
            txtTotalText.Text = Format(total, "##,##0.00")
            txtDecuentoText.Text = Format(Totaldescuento, "##,##0.00")
        Catch ex As Exception

        End Try

    End Sub

    Public Sub diseñoGrid()
        Me.Cursor = Cursors.WaitCursor

        With grdOrdenCompra.DisplayLayout.Bands(0)

            If idpo <> 0 Then
                .Columns("ProgramaPor").Hidden = True
                .Columns("Plazo").Hidden = True
                .Columns("Moneda").Hidden = True
                .Columns("Semana").Hidden = True
                .Columns("Año").Hidden = True
            End If

            .Columns("Material").Width = 80
            .Columns("Total Pedido").Width = 20
            .Columns("Precio Unitario").Width = 20
            .Columns("Almacen").Width = 20
            .Columns("Total Pedir").Width = 20
            .Columns("Total Compra").Width = 30
            .Columns("Por Recibir").Width = 20
            .Columns("Tipo Material").Width = 60

            .Columns("IDmn").Hidden = True
            .Columns("IDc").Hidden = True
            .Columns("idp").Hidden = True
            .Columns("idpp").Hidden = True
            .Columns("Tipo").Hidden = True
            .Columns("UMC").Hidden = True
            .Columns("IdMoneda").Hidden = True
            .Columns("mone_abreviatura").Hidden = True
            .Columns("mone_simbolo").Hidden = True

            .Columns("Total Pedido").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio Unitario").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Almacen").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Pedir").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Compra").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Por Recibir").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("Total Pedido").CellActivation = Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Activation.NoEdit
            .Columns("Almacen").CellActivation = Activation.NoEdit
            .Columns("Total Compra").CellActivation = Activation.NoEdit
            .Columns("Por Recibir").CellActivation = Activation.NoEdit
            .Columns("Tipo Material").CellActivation = Activation.NoEdit

            .Columns("Total Pedir").CellActivation = Activation.AllowEdit

            .Columns("Total Pedido").Format = "##,##0.00"
            .Columns("Almacen").Format = "##,##0.00"
            .Columns("Total Pedir").Format = "##,##0.00"
            .Columns("Por Recibir").Format = "##,##0.00"


            .Columns("Total Pedido").Header.Caption = "Total" & vbCrLf & "Pedido"
            .Columns("Precio Unitario").Header.Caption = "Precio" & vbCrLf & "Unitario"
            .Columns("Total Pedir").Header.Caption = "Total a" & vbCrLf & "Pedir"
            .Columns("Total Compra").Header.Caption = "Total" & vbCrLf & "Compra"
            .Columns("Almacen").Header.Caption = "Inventario"
            .Columns("Por Recibir").Header.Caption = "Por" & vbCrLf & "Recibir"

            For value = 0 To grdOrdenCompra.Rows.Count - 1
                Dim tablaProveedores As New DataTable
                Dim listaProveedores As New ValueList
                Dim obj As New PreordenCompraBU
                Try
                    tablaProveedores = obj.ConsultaProveedoresMaterial(grdOrdenCompra.Rows(value).Cells("IDmn").Value)
                Catch ex As Exception
                End Try
                Try
                    For value2 = 0 To tablaProveedores.Rows.Count - 1
                        listaProveedores.ValueListItems.Add(CInt(tablaProveedores.Rows(value2).Item("ID").ToString), tablaProveedores.Rows(value2).Item("Proveedor").ToString)
                    Next
                Catch ex As Exception
                End Try
            Next

            For value = 0 To grdOrdenCompra.Rows.Count - 1
                grdOrdenCompra.Rows(value).Cells("Total Pedir").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FF00")
                simbolo = grdOrdenCompra.Rows(value).Cells("mone_simbolo").Text
                grdOrdenCompra.Rows(value).Cells("Precio Unitario").Column.Format = "" & simbolo & " ##,##0.00"
                grdOrdenCompra.Rows(value).Cells("Total Compra").Column.Format = "" & simbolo & " ##,##0.00"
            Next

            If lblEstatus.Text = "AUTORIZADA" Or lblEstatus.Text = "CANCELADA" Then
                .Columns("Total Pedir").CellActivation = Activation.NoEdit
            End If

        End With
        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub diseñoGrid2()
        Me.Cursor = Cursors.WaitCursor

        With grdOrdenCompra.DisplayLayout.Bands(0)

            .Columns("Material").Width = 100
            .Columns("Total Pedido").Width = 20
            .Columns("Precio Unitario").Width = 20
            .Columns("Almacen").Width = 20
            .Columns("Total Pedir").Width = 20
            .Columns("Total Compra").Width = 20

            .Columns("IDmn").Hidden = True
            .Columns("IDc").Hidden = True
            .Columns("idp").Hidden = True
            .Columns("idpp").Hidden = True
            .Columns("IdMoneda").Hidden = True

            .Columns("Total Pedido").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio Unitario").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Almacen").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Pedir").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total Compra").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Material").CellActivation = Activation.NoEdit
            .Columns("Total Pedido").CellActivation = Activation.NoEdit
            .Columns("Precio Unitario").CellActivation = Activation.NoEdit
            .Columns("Almacen").CellActivation = Activation.NoEdit
            .Columns("Total Compra").CellActivation = Activation.NoEdit
            .Columns("Total Pedir").CellActivation = Activation.AllowEdit

            .Columns("Total Compra").Format = "##,##0.00"
            .Columns("Total Pedido").Format = "##,##0.00"
            .Columns("Precio Unitario").Format = "##,##0.00"
            .Columns("Almacen").Format = "##,##0.00"
            .Columns("Total Pedir").Format = "##,##0.00"


            .Columns("Total Pedido").Header.Caption = "Total" & vbCrLf & "Pedido"
            .Columns("Precio Unitario").Header.Caption = "Precio" & vbCrLf & "Unitario"
            .Columns("Total Pedir").Header.Caption = "Total a" & vbCrLf & "Pedir"
            .Columns("Total Compra").Header.Caption = "Total" & vbCrLf & "Compra"
            .Columns("Almacen").Header.Caption = "Inventario"
            .Columns("Por Recibir").Header.Caption = "Por" & vbCrLf & "Recibir"

            For value = 0 To grdOrdenCompra.Rows.Count - 1
                grdOrdenCompra.Rows(value).Cells("Total Pedir").Appearance.BackColor = System.Drawing.ColorTranslator.FromHtml("#00FF00")
                grdOrdenCompra.Rows(value).Cells("Precio Unitario").Column.Format = "" & simbolo & " ##,##0.00"
                grdOrdenCompra.Rows(value).Cells("Total Compra").Column.Format = "" & simbolo & " ##,##0.00"
            Next

        End With
        grdOrdenCompra.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdOrdenCompra.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdOrdenCompra.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Public Sub diseñoGridClasificacion()
        Me.Cursor = Cursors.WaitCursor

        With grdClasificacion.DisplayLayout.Bands(0)

            .Columns("Clasificación").Width = 50
            .Columns("Consumo").Width = 30
            .Columns("UMC").Width = 30
            .Columns("Total").Width = 30

            .Columns("Consumo").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Total").CellAppearance.TextHAlign = HAlign.Right

            .Columns("Clasificación").CellActivation = Activation.NoEdit
            .Columns("Consumo").CellActivation = Activation.NoEdit
            .Columns("UMC").CellActivation = Activation.NoEdit
            .Columns("Total").CellActivation = Activation.NoEdit

            .Columns("Consumo").Format = "##,##0.00"

        End With
        grdClasificacion.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdClasificacion.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdClasificacion.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub grdOrdenCompra_AfterExitEditMode(sender As Object, e As EventArgs) Handles grdOrdenCompra.AfterExitEditMode
        ActualizarPrecioProveedorSeleccionado()
        diseñoGrid()
    End Sub

    Private Sub btnAutorizar_Click(sender As Object, e As EventArgs) Handles btnAutorizar.Click
        Dim OrdenesCompra As New ExplosionMaterialesForm
        OrdenesCompra.btnAutorizar_Click(Nothing, Nothing)

    End Sub


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New PreordenCompraBU
        Dim contador = 0
        Dim TablaIdOrdenCompra As New DataTable

        TablaIdOrdenCompra = obj.ConsultaIdOrdenCompra(idpo)
        tablaOrdenCompra = Nothing
        TablaOrdenDeCompraDetalle = Nothing

        tablaOrdenCompra = obj.ConsultarOrdenCompleta(TablaIdOrdenCompra.Rows(0).Item(0))
        TablaOrdenDeCompraDetalle = obj.ConsultarOrdenCompletaDetalle(TablaIdOrdenCompra.Rows(0).Item(0))
        tablaDatosNave = obj.ConsultarDatosNave(nave)
        CrearReporte()
        Dim tablaImprimio As DataTable
        tablaImprimio = obj.ConsultaImprimio(idpo)
        If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
            obj.ActualizaImprimio(idpo, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        Else
            obj.ActualizaReimprimio(idpo, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Public Sub CrearReporte()
        Dim subtotal As Double = 0
        Dim iva As Double = 0
        Dim total As Double = 0
        Dim descuento As Double = 0
        Dim obj As New PreordenCompraBU
        Dim usuario As DataTable
        Dim totalidad As Double = 0

        For value = 0 To TablaOrdenDeCompraDetalle.Rows.Count - 1
                subtotal += TablaOrdenDeCompraDetalle.Rows(value).Item("Importe")
            Next
            Try
                descuento = tablaOrdenCompra.Rows(0).Item("Descuento")
                descuento = subtotal * (descuento / 100)
                totalidad = subtotal - descuento
            Catch ex As Exception
            End Try
            iva = totalidad * 0.16

            total = totalidad + iva

        Dim dateValue As Date = dtpFechaPrograma.Value.ToShortDateString
        Dim DAY = dateValue.DayOfWeek()
        Dim NUMEROMES = dateValue.Month()
        Dim dia As String = ""
        Dim mes As String = ""
        Dim fechaDias As String = ""
        Dim Logo As String = ""
        Logo = Tools.Controles.ObtenerLogoNave(nave)

        Select Case DAY
            Case 1
                dia = "Lunes"
            Case 2
                dia = "Martes"
            Case 3
                dia = "Miércoles"
            Case 4
                dia = "Jueves"
            Case 5
                dia = "Viernes"
            Case 6
                dia = "Sábado"
        End Select

        Select Case NUMEROMES
            Case 1
                mes = "Enero"
            Case 2
                mes = "Febrero"
            Case 3
                mes = "Marzo"
            Case 4
                mes = "Abril"
            Case 5
                mes = "Mayo"
            Case 6
                mes = "Junio"
            Case 7
                mes = "Julio"
            Case 8
                mes = "Agosto"
            Case 9
                mes = "Septiembre"
            Case 10
                mes = "Octubre"
            Case 11
                mes = "Noviembre"
            Case 12
                mes = "Diciembre"
        End Select

        fechaDias = dia & ",  " & dateValue.ToString("dd") & "  " & mes & " de " & dateValue.ToString("yyyy")
        ''******************************************************************************************************************
        usuario = obj.NombreDeUsuario(tablaOrdenCompra.Rows(0).Item("Usuario autorizo"))
        '********************************Creación de reporte
        Try
            '**Llenado del reporte
            Me.Cursor = Cursors.WaitCursor
            Dim OBJReporte As New Framework.Negocios.ReportesBU
            Dim EntidadReporte As Entidades.Reportes
            Dim tablaImprimio As DataTable
            tablaImprimio = obj.ConsultaImprimio(idpo)
            If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDEN_DE_COMPRA_EXPLOSION2")
            Else
                EntidadReporte = OBJReporte.LeerReporteporClave("REPORTE_ORDEN_DE_COMPRA_EXPLOSION")
            End If
            Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
                EntidadReporte.Pnombre + ".mrt"
            My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
            Dim reporte As New StiReport
            ' Dim ruta As String
            Dim numero As String = ""
            reporte.Load(archivo)
            reporte.Compile()
            reporte("log") = Logo
            reporte("fecha") = fechaDias
            reporte("fechaHora") = DateTime.Now.ToString("dd/MM/yyyy") + " " + Now.ToString("HH:mm:ss")
            reporte("usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
            reporte("cadenacomercial") = tablaOrdenCompra.Rows(0).Item("Cadena comercial")
            reporte("proveedor") = tablaOrdenCompra.Rows(0).Item("Proveedor")
            reporte("telefono") = ""
            Dim fp As Date = tablaOrdenCompra.Rows(0).Item("Fecha programa").ToString
            Dim fpp = fp.ToString("dd-MMM-yyyy")
            Dim fe As Date = tablaOrdenCompra.Rows(0).Item("Fecha entrega").ToString
            Dim fee = fe.ToString("dd-MMM-yyyy")
            reporte("fechaprograma") = fpp.Replace(".", "")
            reporte("fechaentrega") = fee.Replace(".", "")
            reporte("urgencia") = tablaOrdenCompra.Rows(0).Item("prioridad")
            reporte("observacion") = tablaOrdenCompra.Rows(0).Item("Observacion")
            reporte("descuento") = Format(descuento, "$ ##,##0.00").ToString
            reporte("subtotal") = Format(subtotal, "$ ##,##0.00").ToString
            reporte("total") = Format(total, "$ ##,##0.00").ToString
            reporte("iva") = Format(iva, "$ ##,##0.00").ToString
            reporte("nave") = tablaDatosNave.Rows(0).Item("Nave")
            reporte("colonia") = tablaDatosNave.Rows(0).Item("Colonia")
            reporte("domicilio") = tablaDatosNave.Rows(0).Item("CaLLE")
            reporte("telnave") = ""
            reporte("autorizo") = usuario.Rows(0).Item(0)
            reporte("facturar") = "FACTURAR"
            reporte("desc") = tablaOrdenCompra.Rows(0).Item("Descuento").ToString
            reporte("cp") = tablaDatosNave.Rows(0).Item("CP")
            If tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 1 Then
                numero = "0000" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 2 Then
                numero = "000" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 3 Then
                numero = "00" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 4 Then
                numero = "0" & tablaOrdenCompra.Rows(0).Item("Oc")
            ElseIf tablaOrdenCompra.Rows(0).Item("Oc").ToString.Length = 5 Then
                numero = tablaOrdenCompra.Rows(0).Item("Oc")
            End If
            reporte("numeroorden") = numero
            If tablaImprimio.Rows(0).Item(0).ToString.Length = 0 Then
                reporte("imp") = ""
            Else
                reporte("imp") = "REIMPRESIÓN"
            End If
            reporte.RegData(TablaOrdenDeCompraDetalle)
            reporte.Show()
            '*********************
            Me.Cursor = Cursors.Default
        Catch ex As Exception
        End Try
        '********************************Fin de creación de reporte
    End Sub

     Private Sub grdOrdenCompra_KeyUp(sender As Object, e As KeyEventArgs) Handles grdOrdenCompra.KeyUp
        Dim obj As New PreordenCompraBU


        If lblEstatus.Text = "AUTORIZADA" Then
        Else
            If e.KeyCode = Keys.Enter And filaBorrada = 0 Then
                If grdOrdenCompra.ActiveRow.Cells("Material").Text <> "" Then
                    Dim contador = 0
                    For value = 0 To grdOrdenCompra.Rows.Count - 1
                        If grdOrdenCompra.Rows(value).Cells("Material").Text = "" Then
                            contador = 1
                        End If
                    Next
                    grdOrdenCompra.PerformAction(UltraGridAction.ExitEditMode, False, False)
                    Dim banda As UltraGridBand = grdOrdenCompra.DisplayLayout.Bands(0)
                    If grdOrdenCompra.ActiveRow.HasNextSibling(True) Then
                        Dim nextRow As UltraGridRow = grdOrdenCompra.ActiveRow.GetSibling(SiblingRow.Next, True)
                        grdOrdenCompra.ActiveCell = nextRow.Cells(grdOrdenCompra.ActiveCell.Column)
                        e.Handled = True
                        grdOrdenCompra.ActiveCell = grdOrdenCompra.ActiveRow.Cells("Total Pedir")
                        grdOrdenCompra.PerformAction(UltraGridAction.EnterEditMode, True, True)
                        ActualizarPrecioProveedorSeleccionado()
                    End If

                    If contador = 0 Then
                        If grdOrdenCompra.ActiveRow.Index = grdOrdenCompra.Rows.Count - 1 Then
                            diseñoGrid2()
                            grdOrdenCompra.ActiveCell = grdOrdenCompra.ActiveRow.Cells("Total Pedir")
                            ActualizarPrecioProveedorSeleccionado()
                            grdOrdenCompra.ActiveCell = grdOrdenCompra.ActiveRow.Cells("Material")
                            grdOrdenCompra.PerformAction(UltraGridAction.EnterEditMode, True, True)

                        End If
                    End If
                End If
            End If
            If e.KeyCode = Keys.F1 And estatus <> "AUTORIZADA" Then
                Me.Cursor = Cursors.WaitCursor
                If cbxProveedores.SelectedIndex <> 0 Then
                    Try
                        If cmbMoneda.Text <> "" Then
                            Dim form As New AgregarMaterialOrdenCompraForm
                            form.nave = nave
                            form.proveedor = IIf(cbxProveedores.SelectedValue = 0, proveedor, cbxProveedores.SelectedValue)
                            form.ProveedorNombre = cbxProveedores.Text
                            form.fechaPrograma = dtpFechaPrograma.Value.ToShortDateString
                            form.idmoneda = monedaID
                            form.ShowDialog()
                            cmbMoneda.Enabled = False
                            cmbTipoPago.Enabled = False

                            Dim tablaMaterialesPorRecibir As DataTable
                            Dim porRecibir As Double = 0

                            tablaMaterialesPorRecibir = obj.CantidadPorRecibir(form.idmn, form.idp, form.nave)
                            For valuex = 0 To tablaMaterialesPorRecibir.Rows.Count - 1
                                porRecibir = porRecibir + tablaMaterialesPorRecibir.Rows(valuex).Item(0)
                            Next

                            Dim dtMaterialElegido As New DataTable
                            dtMaterialElegido = form.listParametros


                            For Each a As DataRow In dtMaterialElegido.Rows
                                Dim row As UltraGridRow = Me.grdOrdenCompra.DisplayLayout.Bands(0).AddNew()
                                row.Cells("Material").Value = a.Item("Material")
                                row.Cells("IDmn").Value = a.Item("idmn")
                                row.Cells("IDc").Value = a.Item("idc")
                                row.Cells("UMC").Value = a.Item("UMC")


                                row.Cells("Tipo Material").Value = a.Item("Tipo Material")
                                row.Cells("Precio Unitario").Value = a.Item("precio")
                                row.Cells("IDp").Value = a.Item("IDp")
                                row.Cells("Almacen").Value = a.Item("almacen")
                                row.Cells("Total Pedir").Value = 0
                                row.Cells("Total Compra").Value = 0
                                row.Cells("Por Recibir").Value = porRecibir
                                row.Cells("Tipo").Value = "MANUAL"
                                row.Cells("IdMoneda").Value = a.Item("idmoneda")
                                row.Cells("mone_simbolo").Value = a.Item("mone_simbolo")
                                row.Cells("mone_abreviatura").Value = a.Item("mone_abreviatura")
                                row.Cells("Precio Unitario").Column.Format = "" & a.Item("mone_simbolo") & " ##,##0.00"
                                row.Cells("Total Compra").Column.Format = "" & a.Item("mone_simbolo") & " ##,##0.00"
                                grdOrdenCompra.ActiveCell = grdOrdenCompra.ActiveRow.Cells("Total Pedir")
                                lblMoneAbreviatura.Text = a.Item("mone_abreviatura")
                            Next
                            grdOrdenCompra.PerformAction(UltraGridAction.EnterEditMode, True, True)
                            calcularClasificaciones()

                        Else
                            Tools.MostrarMensaje(Mensajes.Warning, "Selecciona un tipo de moneda.")
                        End If

                    Catch ex As Exception
                    End Try

                End If
                Me.Cursor = Cursors.Default
            End If
        End If

        filaBorrada = 0

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim FechaEntrega As Date = dtpEntrega.Value
        Dim fecha As New DateTime(Date.Now.Year, 1, 1)
        Dim fechafin As Date = DateAdd(DateInterval.WeekOfYear, txtSemana.Value, fecha)
        Dim fechaInico = DateAdd(DateInterval.Day, (-fechafin.DayOfWeek) + 1, fechafin)

        If txtSemana.Value <> 0 Then
            fechaprograma = fechaInico.ToShortDateString()
            If fechaInico.ToShortDateString() < FechaEntrega.ToShortDateString() Then
                If Weekday(FechaEntrega) = 1 Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Validar el día de entrega de la orden de compra.")
                    Exit Sub
                End If
                Tools.MostrarMensaje(Mensajes.Warning, "La fecha entrega no puede ser menor a la fecha programa.")
                Exit Sub
            Else
                If grdOrdenCompra.Rows.Count = 0 Or TOTALIDAD = 0 Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Falta capturar materiales ó el total a pedir de la Orden de Compra.")
                Else
                    GuardarCambios()
                    Me.Close()
                End If
            End If
        Else

            If FechaEntrega.ToShortDateString() < dtpFechaPrograma.Value.ToShortDateString() Then
                fechaprograma = dtpFechaPrograma.Value.ToShortDateString()
                If Weekday(FechaEntrega) = 1 Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Validar el día de entrega de la orden de compra.")
                    Exit Sub
                End If
                Tools.MostrarMensaje(Mensajes.Warning, "La fecha entrega no puede ser menor a la fecha programa.")
                Exit Sub
            Else
                If grdOrdenCompra.Rows.Count = 0 Or TOTALIDAD = 0 Then
                    Tools.MostrarMensaje(Mensajes.Warning, "Falta capturar materiales ó el total a pedir de la Orden de Compra.")
                Else
                    GuardarCambios()
                    Me.Close()
                End If
            End If
        End If


    End Sub

    Public Sub GuardarCambios()
        Dim obj As New PreordenCompraBU
        Dim dtEncabezadoOrden As New DataTable
        Dim Accion As Integer = 0
        Dim PreOrdenID As Integer = 0
        Dim dtDetallesOrden As New DataTable
        Dim vXmlCeldasModificadas As XElement = New XElement("Celdas")
        Dim vXmlCeldasModificadas2 As XElement = New XElement("Celdas")

        If cbxProveedores.Text = "" Then
            Tools.MostrarMensaje(Mensajes.Warning, "Seleccione un Proveedor.")
            Exit Sub
        Else
            If grdOrdenCompra.Rows.Count = 1 And grdOrdenCompra.Rows(0).Cells(0).Text = "" Then
                Tools.MostrarMensaje(Mensajes.Warning, "Agregue materiales a la Orden de Compra.")
                Exit Sub
            Else
                If lblIdoc.Text = "-" Then
                    NuevoRegistro = True
                Else
                    NuevoRegistro = False
                End If

                'Nueva Orden de compra
                If NuevoRegistro = True Then
                    Try

                        Dim vNodo As XElement = New XElement("Celda")
                        vNodo.Add(New XAttribute("NaveID", nave))
                        vNodo.Add(New XAttribute("FechaPrograma", fechaprograma))
                        vNodo.Add(New XAttribute("Proveedorid", cbxProveedores.SelectedValue))
                        vNodo.Add(New XAttribute("Descuento", txtDescuento.Text))
                        vNodo.Add(New XAttribute("Prioridad", cbxTipoDeOrden.Text))
                        vNodo.Add(New XAttribute("FechaEntrega", dtpEntrega.Value.ToShortDateString))
                        vNodo.Add(New XAttribute("Observacion", txtObservaciones.Text))
                        vNodo.Add(New XAttribute("MonedaID", grdOrdenCompra.Rows(0).Cells("IdMoneda").Value))
                        vNodo.Add(New XAttribute("TipoPago", cmbTipoPago.SelectedValue))
                        vNodo.Add(New XAttribute("PreOrdenCompraID", 0))
                        vNodo.Add(New XAttribute("PorSemana", IIf(txtSemana.Value <> 0, 1, 0)))
                        vXmlCeldasModificadas.Add(vNodo)


                        Accion = 1 'Encabezado

                        dtEncabezadoOrden = obj.GuardarPreOrdenCompra(Accion, vXmlCeldasModificadas.ToString())

                        If dtEncabezadoOrden.Rows.Count > 0 Then
                            PreOrdenID = dtEncabezadoOrden.Rows(0)("PreOrdenID")
                        End If

                    Catch ex As Exception
                    End Try

                    For value2 = 0 To grdOrdenCompra.Rows.Count

                        Try
                            Dim vNodo2 As XElement = New XElement("Celda")
                            vNodo2.Add(New XAttribute("PreOrdenID", PreOrdenID))
                            vNodo2.Add(New XAttribute("MaterialID", grdOrdenCompra.Rows(value2).Cells("IDmn").Value))
                            vNodo2.Add(New XAttribute("Cantidadrequerida", grdOrdenCompra.Rows(value2).Cells("Total Pedir").Value))
                            vNodo2.Add(New XAttribute("Cantidadinventario", grdOrdenCompra.Rows(value2).Cells("Almacen").Value))
                            vNodo2.Add(New XAttribute("Cantidadsolicitada", grdOrdenCompra.Rows(value2).Cells("Total Pedir").Value))
                            vNodo2.Add(New XAttribute("Precio", grdOrdenCompra.Rows(value2).Cells("Precio Unitario").Value))
                            vNodo2.Add(New XAttribute("Total", grdOrdenCompra.Rows(value2).Cells("Total Compra").Value))
                            vNodo2.Add(New XAttribute("PorRecibir", grdOrdenCompra.Rows(value2).Cells("Por Recibir").Value))
                            vXmlCeldasModificadas2.Add(vNodo2)

                            Accion = 2
                        Catch ex As Exception
                        End Try
                    Next
                    dtDetallesOrden = obj.GuardarPreOrdenCompra(Accion, vXmlCeldasModificadas2.ToString())
                    Tools.MostrarMensaje(Mensajes.Success, "Orden de Compra registrada")
                    lblIdoc.Text = PreOrdenID
                ElseIf NuevoRegistro = False Then

                    Dim vNodo As XElement = New XElement("Celda")

                    vNodo.Add(New XAttribute("FechaPrograma", fechaprograma))
                    vNodo.Add(New XAttribute("Descuento", txtDescuento.Text))
                    vNodo.Add(New XAttribute("Prioridad", cbxTipoDeOrden.Text))
                    vNodo.Add(New XAttribute("FechaEntrega", dtpEntrega.Value.ToShortDateString))
                    vNodo.Add(New XAttribute("Observacion", txtObservaciones.Text))
                    vNodo.Add(New XAttribute("PreOrdenCompraID", idpo))
                    vXmlCeldasModificadas.Add(vNodo)


                    Accion = 1 'Encabezado

                    dtEncabezadoOrden = obj.ActualizarPreOrdenCompra(Accion, vXmlCeldasModificadas.ToString())

                    For value2 = 0 To grdOrdenCompra.Rows.Count - 1
                        Try
                            Accion = 2 'Detalles 

                            Dim vNodo2 As XElement = New XElement("Celda")

                            vNodo2.Add(New XAttribute("MaterialID", grdOrdenCompra.Rows(value2).Cells("IDmn").Value))
                            vNodo2.Add(New XAttribute("Cantidadinventario", grdOrdenCompra.Rows(value2).Cells("Almacen").Value))
                            vNodo2.Add(New XAttribute("Cantidadsolicitada", grdOrdenCompra.Rows(value2).Cells("Total Pedir").Value))
                            vNodo2.Add(New XAttribute("Precio", grdOrdenCompra.Rows(value2).Cells("Precio Unitario").Value))
                            vNodo2.Add(New XAttribute("Total", grdOrdenCompra.Rows(value2).Cells("Total Compra").Value))
                            If listaMateriales.Contains(grdOrdenCompra.Rows(value2).Cells("IDmn").Value) Then
                                vNodo2.Add(New XAttribute("MaterialExiste", 1))
                            Else
                                vNodo2.Add(New XAttribute("MaterialExiste", 0))
                            End If
                            vNodo2.Add(New XAttribute("PreOrdenCompraID", idpo))
                            vXmlCeldasModificadas2.Add(vNodo2)

                        Catch ex As Exception

                        End Try
                    Next

                    dtDetallesOrden = obj.ActualizarPreOrdenCompra(Accion, vXmlCeldasModificadas2.ToString())

                    Tools.MostrarMensaje(Mensajes.Success, "Orden de Compra actualizada.")
                End If
            End If
        End If
        CalcularConIva()
        If TOTALIDAD = 0 Then
            pnlAutorizar.Visible = False
        Else
            pnlAutorizar.Visible = True
        End If
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        objConfirmacion.mensaje = "¿Está seguro de salir?"
        If objConfirmacion.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub txtDescuento_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtDescuento.KeyPress
        Dim contador = 0

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not txtDescuento.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
            contador = 1
        ElseIf txtDescuento.TextLength = 2 And Not txtDescuento.Text.IndexOf(".") Then
            e.Handled = True
        Else
            e.Handled = True
        End If

        If contador = 0 Then
            If txtDescuento.TextLength = 2 And Not txtDescuento.Text.Contains(".") Then
                e.Handled = True
            End If
        End If

        Dim tb As TextBox = DirectCast(sender, TextBox)
        Dim separadorDecimal As String = _
         Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim index As Integer = tb.Text.IndexOf(separadorDecimal)

        If ((e.KeyChar = "."c) OrElse (e.KeyChar = ","c) OrElse (e.KeyChar = ControlChars.Back)) Then
            ' Si en el control hay ya escrito un separador decimal, 
            ' deshechamos insertar otro separador más. 
            '
            If Char.IsControl(e.KeyChar) Then
                e.Handled = False
                Return
            End If
            If (tb.Text.IndexOf(separadorDecimal) >= 0) And Not (tb.SelectionLength <> 0) Then
                e.Handled = True
                Return

            Else
                If ((tb.TextLength = 0) OrElse (tb.SelectionLength > 0) OrElse _
                  ((tb.TextLength = 1) And (tb.Text.Chars(0) = "-"c))) Then
                    ' Si no hay ningún número, insertamos un cero
                    ' antes del separador decimal.
                    tb.SelectedText = "0"
                End If

                ' Insertamos el separador decimal. 
                '
                e.KeyChar = CChar(separadorDecimal)
                Return
            End If
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        End If

        If (index >= 0) Then
            Dim decimales As String = tb.Text.Substring(index + 1)
            e.Handled = (decimales.Length = 2)
        End If
    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged
        CalcularConIva()
        calcularClasificaciones()
    End Sub

    Private Sub cbxProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProveedores.SelectedIndexChanged
        txtIvaText.Text = 0
        txtDescuento.Text = 0
        txtTotalText.Text = 0
        txtSubtotalText.Text = 0
        txtRetenciones.Text = 0
        grdClasificacion.DataSource = Nothing

        CargarDatosProveedor()

    End Sub

    Private Sub CargarDatosProveedor()
        Dim objBU As New PreordenCompraBU
        Dim dtMoneda As New DataTable
        Dim dtPlazoPago As New DataTable

        If cbxProveedores.SelectedIndex <> 0 Then
            dtMoneda = objBU.ObtenerDatosProveedor(1, cbxProveedores.SelectedValue)
            If dtMoneda.Rows.Count > 0 Then
                cmbMoneda.DataSource = dtMoneda
                cmbMoneda.DisplayMember = "Moneda"
                cmbMoneda.ValueMember = "MonedaID"

                If dtMoneda.Rows.Count = 1 Then
                    cmbMoneda.Enabled = False
                End If
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Capture una moneda para el proveedor en el catálogo de Proveedores.")
                Exit Sub
            End If
            dtPlazoPago = objBU.ObtenerDatosProveedor(2, cbxProveedores.SelectedValue)
            If dtPlazoPago.Rows.Count > 0 Then
                cmbTipoPago.DataSource = dtPlazoPago
                cmbTipoPago.DisplayMember = "Plazo"
                cmbTipoPago.ValueMember = "PlazoID"

                If dtPlazoPago.Rows.Count = 1 Then
                    cmbTipoPago.Enabled = False
                End If
            Else
                Tools.MostrarMensaje(Mensajes.Warning, "Capture un plazo de pago para el proveedor en el catálogo de Proveedores.")
                Exit Sub
            End If
        End If
    End Sub


    Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
        If cmbMoneda.SelectedIndex > 0 Then
            If idpo = 0 Then
                Dim objMensaje As New Tools.ConfirmarForm
                objMensaje.mensaje = "¿Está seguro de seleccionar tipo de moneda " & cmbMoneda.Text & "?"
                If objMensaje.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    cmbMoneda.Enabled = False
                End If
            End If
        End If

    End Sub

    Private Sub grdOrdenCompra_BeforeRowsDeleted(sender As Object, e As BeforeRowsDeletedEventArgs) Handles grdOrdenCompra.BeforeRowsDeleted
        e.DisplayPromptMsg = False
        If MsgBox("¿Estás seguro de quitar la(s) fila(s) seleccionada(s)?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
            e.Cancel = False
            filaBorrada = 1
        Else
            e.Cancel = True
            filaBorrada = 0
        End If
    End Sub

    Private Sub cmbProgramaPor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProgramaPor.SelectedIndexChanged
        If cbxProveedores.SelectedIndex <> 0 Then
            If cmbProgramaPor.Text = "FECHA " Then
                lblFechaPrograma.Visible = True
                dtpFechaPrograma.Visible = True

                lblAño.Visible = False
                txtAño.Visible = False
                lblSemana.Visible = False
                txtSemana.Visible = False

            ElseIf cmbProgramaPor.Text = "SEMANA" Then
                lblAño.Visible = True
                txtAño.Visible = True
                lblSemana.Visible = True
                txtSemana.Visible = True

                lblFechaPrograma.Visible = False
                dtpFechaPrograma.Visible = False
            End If
        End If
    End Sub

    Private Sub txtSemana_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSemana.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub

    Private Sub txtAño_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAño.KeyPress
        e.Handled = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)
    End Sub
End Class