Imports System.Data.SqlClient
Imports Infragistics.Win.UltraWinGrid
Imports System.Net
Imports Infragistics.Win
Imports Stimulsoft.Report
Imports Tools
Imports System.Globalization
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section



Public Class ListaPreciosClienteAlta
    Private incrementoPorcentaje As Decimal = 0
    Private incrementoMonto As Decimal = 0
    Private endEdit As Boolean = True
    Dim Paridad As Double
    Dim dtListaPrecioST As New DataTable

    Dim objFTP As New Tools.TransferenciaFTP
    Dim request = DirectCast(WebRequest.Create(objFTP.obtenerURL), FtpWebRequest)
    Dim Carpeta As String = "Programacion/Modelos/"

    Dim StreamFoto As System.IO.Stream

    Dim IdCliente As Integer
    Dim IdListaPrecioBase As Integer
    Dim idListaPrecioVenta As Integer
    Dim IdListaPrecioCliente As Integer
    Dim CodigoLVCP As String
    Dim NumeroLVCP As String
    Dim ParidadHOy As Double

    Private Sub ListaPreciosClienteAlta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = 2
        Me.Top = 0
        Me.Left = 0
        LlenarComboClientes()
        llenarComboListasBase()
        If Framework.Negocios.PermisosUsuarioBU.ConsultarPermiso("VE_LP_REPORTES", "BTN_IMPRIMIRPDF") Then
            Pnl_ExportarPDF.Visible = True
        Else
            Pnl_ExportarPDF.Visible = False
        End If
    End Sub

    Private Sub btnArriba_Click(sender As Object, e As EventArgs) Handles btnArriba.Click
        grpDatos.Height = 50
    End Sub

    Private Sub btnAbajo_Click(sender As Object, e As EventArgs) Handles btnAbajo.Click
        grpDatos.Height = 256
    End Sub

    Private Sub btnVolverCargarReporte_Click(sender As Object, e As EventArgs) Handles btnVolverCargarReporte.Click
        grdReporte.DataSource = Nothing

        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen

        Me.Cursor = Cursors.WaitCursor
        If cmbClientes.SelectedIndex <= 0 Then
            objAdvertencia.mensaje = "No hay ningún cliente seleccionado."
            Me.Cursor = Cursors.Default
            objAdvertencia.ShowDialog()
        ElseIf cmbListaVentasCliente.SelectedIndex <= 0 And RdoSimulador.Checked = False Then
            objAdvertencia.mensaje = "No hay ninguna lista de ventas de cliente seleccionada."
            Me.Cursor = Cursors.Default
            objAdvertencia.ShowDialog()
        Else
            If rdoListadePrecios.Checked = True Then
                If cmbMoneda.SelectedIndex <= 0 Then
                    objAdvertencia.mensaje = "Selecciona una moneda para poder consultar el reporte."
                    Me.Cursor = Cursors.Default
                    objAdvertencia.ShowDialog()
                    Return
                End If
                'PoblarListaPrecios(chkColecciones.Checked, chkFamilias.Checked)
                PoblarListaPrecios(True, False)
            ElseIf rdoModelaje.Checked = True Then
                If cmbMoneda.SelectedIndex <= 0 Then
                    objAdvertencia.mensaje = "Selecciona una moneda para poder consultar el reporte."
                    Me.Cursor = Cursors.Default
                    objAdvertencia.ShowDialog()
                    Return
                    'ElseIf cmbNumeracion.SelectedIndex <= 0 Then
                    '    objAdvertencia.mensaje = "Selecciona una país para la numeración de puntos, para poder consultar el reporte."
                    '    Me.Cursor = Cursors.Default
                    '    objAdvertencia.ShowDialog()
                    '    Return
                End If
                PoblarListaModelaje()
            ElseIf rdoListaPrecioSugerida.Checked = True Then
                If cmbRamos.SelectedIndex <= 0 Then
                    objAdvertencia.mensaje = "Selecciona un ramo para poder consultar el reporte."
                    Me.Cursor = Cursors.Default
                    objAdvertencia.ShowDialog()
                    Return
                    'ElseIf cmbNumeracion.SelectedIndex <= 0 Then
                    '    objAdvertencia.mensaje = "Selecciona una numeración de país para poder consultar el reporte."
                    '    Me.Cursor = Cursors.Default
                    '    objAdvertencia.ShowDialog()
                    '    Return
                End If
                PoblarListaPreciosSugerida(chkColecciones.Checked, chkFamilias.Checked)
            ElseIf RdoListaClaveSat.Checked = True Then
                If txtClaveSAT.Text.Length = 0 Then
                    objAdvertencia.mensaje = "El cliente no cuenta con una clave SAT."
                    Me.Cursor = Cursors.Default
                    objAdvertencia.ShowDialog()
                    Return
                End If
                reporteListaClaveSAT()
            Else
                If cmbMoneda.SelectedIndex <= 0 Then
                    objAdvertencia.mensaje = "Selecciona una moneda para poder consultar el reporte."
                    Me.Cursor = Cursors.Default
                    objAdvertencia.ShowDialog()
                    Return
                    'ElseIf cmbNumeracion.SelectedIndex <= 0 Then
                    '    objAdvertencia.mensaje = "Selecciona una numeración de país para poder consultar el reporte."
                    '    Me.Cursor = Cursors.Default
                    '    objAdvertencia.ShowDialog()
                    '    Return
                End If
                PoblarListaPreciosSimulador(True, False)
                'PoblarListaSimulador()
                ''RecuperarDiferencia_Simulador()
            End If
        End If


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub chkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionarTodo.CheckedChanged
        For Each row As UltraGridRow In grdAgentes.Rows
            row.Cells(" ").Value = chkSeleccionarTodo.Checked
        Next
    End Sub

#Region "PoblarListas"
    ''LISTA PRECIOS______________________________________________________________________________
    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO PARA RECUPERAR LA LISTA DE PRECIOS DEL CLIENTE Y ASIGNAR LA INFORMACION AL GRID
    ''' </summary>
    ''' <param name="colecciones"></param>
    ''' <param name="Familias"></param>
    ''' <remarks></remarks>
    Public Sub PoblarListaPrecios(ByVal colecciones As Boolean, ByVal Familias As Boolean)
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosReporte As New DataTable
        Dim dtDatosReporteDepurado As New DataTable
        Dim cadenaAgentes As String = ""
        Dim Marcas As String = ""
        Dim idsMarcas As String = String.Empty

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                cadenaAgentes += row.Cells("cmfa_colaboradorid_agente").Value.ToString + ", "
                If Marcas = "" Then
                    Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                Else
                    Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                End If

                If idsMarcas = "" Then
                    idsMarcas = LTrim(RTrim(row.Cells("marc_marcaid").Value.ToString))
                Else
                    idsMarcas = idsMarcas + ", " + LTrim(RTrim(row.Cells("marc_marcaid").Value.ToString))
                End If

            End If
        Next


        cadenaAgentes += "0"
        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        If cadenaAgentes = "0" Then
            objAdvertencia.mensaje = "Selecciona al menos una marca para poder consultar la Lista de Precios."
            objAdvertencia.ShowDialog()
        Else
            If cmbClientes.SelectedIndex > 0 And cmbListaVentas.SelectedValue > 0 Then
                dtDatosReporte = objLCBU.consultaListaCliente(cmbListaVentasCliente.SelectedValue, cmbClientes.SelectedValue, cadenaAgentes, Familias,
                                                              colecciones, CBool(rdoModelosPedido.Checked), dttFechaInicio.Value.ToShortDateString,
                                                              dttFechaFin.Value.ToShortDateString, Marcas, cmbMoneda.SelectedValue, CDbl(lblParidad_Dato.Text), rdo_ModeloSAY.Checked, idsMarcas)

                If dtDatosReporte.Rows.Count > 0 Then
                    'dtDatosReporteDepurado = resumirTablaModelosPrecio(dtDatosReporte)
                    dtListaPrecioST = dtDatosReporte



                    'grdReporte.DataSource = dtDatosReporteDepurado
                    grdReporte.DataSource = dtDatosReporte
                    lblMensajeSinListaVentas.Visible = False
                Else
                    objAdvertencia.mensaje = "El cliente no tiene precios asignados."
                    objAdvertencia.ShowDialog()
                End If
            End If

        End If

    End Sub

    Public Sub PoblarListaPreciosSimulador(ByVal colecciones As Boolean, ByVal Familias As Boolean)
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosReporte As New DataTable
        Dim dtDatosReporteDepurado As New DataTable
        Dim cadenaAgentes As String = ""
        Dim Marcas As String = ""
        Dim idsMarcas As String = ""

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                cadenaAgentes += row.Cells("cmfa_colaboradorid_agente").Value.ToString + ", "
                If Marcas = "" Then
                    Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                Else
                    Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                End If

                If idsMarcas = "" Then
                    idsMarcas = row.Cells("marc_marcaid").Value.ToString
                Else
                    idsMarcas = idsMarcas + ", " + row.Cells("marc_marcaid").Value.ToString
                End If

            End If
        Next

        cadenaAgentes += "0"
        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        If cadenaAgentes = "0" Then
            objAdvertencia.mensaje = "Selecciona al menos una marca para poder consultar la Lista de Precios."
            objAdvertencia.ShowDialog()
        Else
            If cmbClientes.SelectedIndex > 0 And cmbListaVentas.SelectedValue > 0 Then
                Dim idListaCliente As Int32 = 0
                If Not cmbListaVentasCliente.SelectedValue Is Nothing Then
                    idListaCliente = cmbListaVentasCliente.SelectedValue
                End If
                dtDatosReporte = objLCBU.consultaListaPreciosSimulador(idListaCliente, cmbClientes.SelectedValue, cadenaAgentes, Familias,
                                                              colecciones, CBool(rdoModelosPedido.Checked), dttFechaInicio.Value.ToShortDateString,
                                                              dttFechaFin.Value.ToShortDateString, Marcas, cmbMoneda.SelectedValue, CDbl(lblParidad_Dato.Text), rdo_ModeloSAY.Checked, IdListaPrecioBase, idsMarcas)

                If dtDatosReporte.Rows.Count > 0 Then
                    'dtDatosReporteDepurado = resumirTablaModelosPrecio(dtDatosReporte)
                    dtListaPrecioST = simular(dtDatosReporte)

                    'grdReporte.DataSource = dtDatosReporteDepurado
                    grdReporte.DataSource = dtDatosReporte

                    lblMensajeSinListaVentas.Visible = False
                Else
                    objAdvertencia.mensaje = "El cliente no tiene precios asignados."
                    objAdvertencia.ShowDialog()
                End If
            End If

        End If

    End Sub

    Public Function simular(ByVal dt As DataTable) As DataTable
        Dim cantidad As Double = numPrecioIncrementoParActual.Value
        Dim paridadMon As Double = 0
        Dim simboloMon As String = "$ "
        Dim monedaM As String = "Pesos"
        Dim Acumulado As Double = 0
        Dim entero As Integer = 0
        Dim partedecimal As Double = 0

        If cmbMoneda.SelectedValue > 1 Then
            Dim dtParidad As New DataTable
            dtParidad = Recuperar_Paridad_Moneda(cmbMoneda.SelectedValue)
            paridadMon = dtParidad.Rows(0).Item("paca_paridadpesos")
            simboloMon = dtParidad.Rows(0).Item("mone_simbolo").ToString + " "
            monedaM = dtParidad.Rows(0).Item("mone_nombre").ToString + " "
        End If

        For Each row As DataRow In dt.Rows
            For i As Int32 = 3 To dt.Columns.Count - 1
                If rdoPrecioPorcentajeActual.Checked = True Then
                    If row.Item(i).ToString <> "" Then
                        Dim D As String = row.Item(i).ToString

                        If monedaM <> "Pesos" Then
                            'Console.WriteLine(row.Item(i))
                            Acumulado = (row.Item(i) + (row.Item(i) * (cantidad / 100)))
                            entero = Int(Acumulado)
                            partedecimal = Acumulado - entero

                            If partedecimal <= 0.49 Then
                                Acumulado = Math.Round(row.Item(i) + (row.Item(i) * (cantidad / 100)))
                            Else
                                Acumulado = Math.Ceiling(row.Item(i) + (row.Item(i) * (cantidad / 100)))
                            End If

                            row.Item(i) = simboloMon + Math.Round(((Acumulado) / paridadMon), 1, MidpointRounding.AwayFromZero).ToString("N2")
                        Else
                            row.Item(i) = simboloMon + Math.Ceiling(row.Item(i) + (row.Item(i) * (cantidad / 100))).ToString + ".00"
                        End If
                    End If
                Else
                    If row.Item(i).ToString <> "" Then
                        If monedaM <> "Pesos" Then
                            row.Item(i) = simboloMon + Math.Round((CDbl(((row.Item(i)) / paridadMon) + cantidad)), 1, MidpointRounding.AwayFromZero).ToString("N2")
                        Else
                            Dim D As String = row.Item(i).ToString
                            row.Item(i) = simboloMon + CDbl(row.Item(i) + cantidad).ToString("N2")
                        End If
                    End If
                End If
            Next
        Next
        For i As Int32 = dt.Columns.Count - 1 To 3 Step -1
            Dim vacio As Boolean = True
            For Each row As DataRow In dt.Rows
                If row.Item(i).ToString <> "" Then
                    vacio = False
                End If
            Next
            If vacio = True Then
                dt.Columns.Remove(dt.Columns(i).Caption.ToString)
            End If
        Next
        Return dt
    End Function


    ''LISTA MODELAJE_______________________________________________________________________________
    ''' <summary>
    ''' EJECUTA EL PROCEDIMIENTO PARA OPTENER LA LISTA DE CONFIRMACION DE MODELAJE Y ASIGNARLA AL ULTRAGRID
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PoblarListaModelaje()

        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen

        Dim objListaClienteBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtGridCatalogo As New DataTable
        Dim Marcas As String = ""
        Dim agentes As String = ""
        Dim idsMarcas As String = ""

        Dim cadenaAgentes As String = ""
        'Dim hsListaAgentes As New HashSet(Of Integer)

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                'hsListaAgentes.Add(row.Cells("cmfa_colaboradorid_agente").Value)
                If Marcas = "" Then
                    Marcas = "'" + row.Cells("Marca").Value + "'"
                Else
                    Marcas = Marcas + ",'" + row.Cells("Marca").Value + "'"
                End If

                If agentes = "" Then
                    agentes = row.Cells("cmfa_colaboradorid_agente").Value.ToString
                Else
                    agentes = agentes + ", " + row.Cells("cmfa_colaboradorid_agente").Value.ToString
                End If

                If idsMarcas = "" Then
                    idsMarcas = row.Cells("marc_marcaid").Value.ToString
                Else
                    idsMarcas = idsMarcas + ", " + row.Cells("marc_marcaid").Value.ToString
                End If
            End If
        Next

        If Marcas = "" Then
            objAdvertencia.mensaje = "Seleccione las marcas de los agentes disponibles para poder consultar el reporte."
            objAdvertencia.ShowDialog()
        Else
            'For Each item In hsListaAgentes
            '    If cadenaAgentes = "" Then
            '        cadenaAgentes = item.ToString
            '    Else
            '        cadenaAgentes += "," + item.ToString
            '    End If
            'Next



            dtGridCatalogo = objListaClienteBU.RecuperarCatalogo_De_Productos(cmbClientes.SelectedValue, cmbListaBase.SelectedValue,
                                                                               cmbListaVentasCliente.SelectedValue, Marcas,
                                                                               cmbMoneda.SelectedValue,
                                                                               rdoTodosLosModelos.Checked, dttFechaInicio.Value.ToShortDateString,
                                                                               dttFechaFin.Value.ToShortDateString, Paridad, agentes, idsMarcas)

            lblMensajeSinListaVentas.Visible = True
            grdReporte.DataSource = dtGridCatalogo

            If grdReporte.Rows.Count = 0 Then
                objAdvertencia.mensaje = "El cliente no tiene precios asignados."
                objAdvertencia.ShowDialog()
                lblMensajeSinListaVentas.Visible = True

            Else
                lblMensajeSinListaVentas.Visible = False
            End If

        End If

    End Sub

    ''' <summary>
    ''' ORDENA LA TABLA DE DATOS AGRUPANDO LOS DATOS QUE SEAN IGUALES PARA UNA CORRIDA EN ESPECIFICO
    ''' </summary>
    ''' <param name="dtTablaReporte"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function resumirTablaModelosPrecio(ByVal dtTablaReporte As DataTable) As DataTable
    '    Dim dtDatosAgrupados, dtDatosReporteDepurado As New DataTable
    '    Dim dtDatosDepuradosPasoDos As New DataTable
    '    Dim esIgualColumnas As Boolean = True
    '    Dim contColumns As Int32 = 0
    '    Dim contFilas As Int32
    '    Dim contColumnsTitulos As Int32 = 3


    '    contColumns = dtTablaReporte.Columns.Count - 1
    '    contFilas = dtTablaReporte.Rows.Count - 1
    '    'If chkColecciones.Checked = True Then
    '    '    contColumnsTitulos += 1
    '    'End If
    '    'If chkFamilias.Checked = True Then
    '    '    contColumnsTitulos += 1
    '    'End If
    '    contColumnsTitulos += 1

    '    For Each col As DataColumn In dtTablaReporte.Columns
    '        dtDatosAgrupados.Columns.Add(col.ColumnName.ToString)
    '        dtDatosReporteDepurado.Columns.Add(col.ColumnName.ToString)
    '    Next


    '    ''AGRUPAMOS LAS CANTIDADES
    '    For cont_Fila_reporte = 0 To dtTablaReporte.Rows.Count - 1 Step 1
    '        If dtDatosAgrupados.Rows.Count = 0 Then
    '            dtDatosAgrupados.ImportRow(dtTablaReporte.Rows(cont_Fila_reporte))
    '        Else
    '            If dtDatosAgrupados.Rows(dtDatosAgrupados.Rows.Count - 1).Item(0) = dtTablaReporte.Rows(cont_Fila_reporte).Item(0) And _
    '                dtDatosAgrupados.Rows(dtDatosAgrupados.Rows.Count - 1).Item(1) = dtTablaReporte.Rows(cont_Fila_reporte).Item(1) And _
    '                dtDatosAgrupados.Rows(dtDatosAgrupados.Rows.Count - 1).Item(2) = dtTablaReporte.Rows(cont_Fila_reporte).Item(2) And _
    '                dtDatosAgrupados.Rows(dtDatosAgrupados.Rows.Count - 1).Item(3) = dtTablaReporte.Rows(cont_Fila_reporte).Item(3) Then

    '                dtDatosAgrupados.Rows(dtDatosAgrupados.Rows.Count - 1).Item(4) += ", " + dtTablaReporte.Rows(cont_Fila_reporte).Item(4)
    '                For cont = 5 To dtTablaReporte.Columns.Count - 1 Step 1

    '                    If Not IsDBNull(dtTablaReporte.Rows(cont_Fila_reporte).Item(cont)) Then
    '                        dtDatosAgrupados.Rows(dtDatosAgrupados.Rows.Count - 1).Item(cont) = dtTablaReporte.Rows(cont_Fila_reporte).Item(cont)
    '                    End If
    '                Next
    '            Else
    '                dtDatosAgrupados.ImportRow(dtTablaReporte.Rows(cont_Fila_reporte))
    '            End If
    '        End If
    '    Next

    '    contFilas = dtDatosAgrupados.Rows.Count - 1


    '    Dim insertaU As Boolean = True
    '    Dim siinsertoU As Boolean = True
    '    For contFil As Int32 = contFilas To 0 Step -1
    '        insertaU = True
    '        siinsertoU = True

    '        If dtDatosReporteDepurado.Rows.Count = 0 Then
    '            dtDatosReporteDepurado.ImportRow(dtDatosAgrupados.Rows(contFil))
    '            dtDatosAgrupados.Rows(contFil).Delete()
    '        Else

    '            For contColDep As Int32 = 0 To dtDatosReporteDepurado.Rows.Count - 1
    '                insertaU = True

    '                For i = 0 To contColumnsTitulos - 2
    '                    Dim cosa As String = dtDatosAgrupados.Rows(contFil).Item(i).ToString
    '                    Dim cosa2 As String = dtDatosReporteDepurado.Rows(contColDep).Item(i).ToString
    '                    If dtDatosAgrupados.Columns(i).ColumnName.ToString <> "prod_codigo" _
    '                        And dtDatosAgrupados.Columns(i).ColumnName.ToString <> "idproducto" Then
    '                        If dtDatosAgrupados.Rows(contFil).Item(i).ToString <> dtDatosReporteDepurado.Rows(contColDep).Item(i).ToString Then
    '                            insertaU = False
    '                            Exit For
    '                        End If
    '                    End If
    '                Next

    '                If insertaU = True Then
    '                    For i = 0 To contColumns
    '                        Dim cosa As String = dtDatosReporteDepurado.Rows(contColDep).Item(i).ToString
    '                        Dim cosa2 As String = dtDatosAgrupados.Rows(contFil).Item(i).ToString

    '                        If i <> 4 And i <> 3 And i <> 3 Then
    '                            If dtDatosAgrupados.Rows(contFil).Item(i).ToString = dtDatosReporteDepurado.Rows(contColDep).Item(i).ToString _
    '                            Or dtDatosReporteDepurado.Rows(contColDep).Item(i).ToString = "" _
    '                            Or dtDatosAgrupados.Rows(contFil).Item(i).ToString = "" Then

    '                            Else
    '                                insertaU = False
    '                                Exit For
    '                            End If
    '                        End If
    '                    Next
    '                End If

    '                If insertaU = True Then
    '                    dtDatosReporteDepurado.Rows(contColDep).Item("prod_codigo") = dtDatosReporteDepurado.Rows(contColDep).Item("prod_codigo").ToString + ", " + dtDatosAgrupados.Rows(contFil).Item("prod_codigo").ToString
    '                    dtDatosReporteDepurado.Rows(contColDep).Item("idproducto") = dtDatosReporteDepurado.Rows(contColDep).Item("idproducto").ToString + ", " + dtDatosAgrupados.Rows(contFil).Item("prod_codigo").ToString

    '                    For i = contColumnsTitulos To contColumns
    '                        If dtDatosReporteDepurado.Rows(contColDep).Item(i).ToString = "" Then
    '                            dtDatosReporteDepurado.Rows(contColDep).Item(i) = dtDatosAgrupados.Rows(contFil).Item(i).ToString()
    '                        End If
    '                    Next
    '                    siinsertoU = True
    '                    dtDatosAgrupados.Rows(contFil).Delete()
    '                    Exit For
    '                Else
    '                    siinsertoU = False
    '                End If

    '            Next
    '            If siinsertoU = False Then
    '                dtDatosReporteDepurado.ImportRow(dtDatosAgrupados.Rows(contFil))
    '                dtDatosAgrupados.Rows(contFil).Delete()
    '            End If
    '        End If
    '    Next

    '    For Each col As DataColumn In dtDatosReporteDepurado.Columns
    '        dtDatosDepuradosPasoDos.Columns.Add(col.ColumnName.ToString)
    '    Next

    '    contColumns = dtDatosReporteDepurado.Columns.Count - 1
    '    contFilas = dtDatosReporteDepurado.Rows.Count - 1

    '    Dim insertaN As Boolean = True
    '    Dim siinsertoN As Boolean = True
    '    For contFil As Int32 = contFilas To 0 Step -1
    '        insertaN = True
    '        siinsertoN = True

    '        If dtDatosDepuradosPasoDos.Rows.Count = 0 Then
    '            dtDatosDepuradosPasoDos.ImportRow(dtDatosReporteDepurado.Rows(contFil))
    '            dtDatosReporteDepurado.Rows(contFil).Delete()
    '        Else
    '            For contColDep As Int32 = 0 To dtDatosDepuradosPasoDos.Rows.Count - 1
    '                insertaN = True

    '                ''For i = 0 To contColumnsTitulos
    '                For i = 0 To dtDatosReporteDepurado.Columns.Count - 1
    '                    If dtDatosReporteDepurado.Columns(i).ColumnName.ToString <> "prod_codigo" _
    '                        And dtDatosReporteDepurado.Columns(i).ColumnName.ToString <> "PIELCOLOR" Then
    '                        If dtDatosReporteDepurado.Rows(contFil).Item(i).ToString <> dtDatosDepuradosPasoDos.Rows(contColDep).Item(i).ToString Then
    '                            insertaN = False
    '                            Exit For
    '                        End If
    '                    End If
    '                Next

    '                If insertaN = True Then
    '                    For i = contColumnsTitulos To contColumns
    '                        If dtDatosReporteDepurado.Rows(contFil).Item(i).ToString = dtDatosDepuradosPasoDos.Rows(contColDep).Item(i).ToString _
    '                            Or dtDatosDepuradosPasoDos.Rows(contColDep).Item(i).ToString = "" Or dtDatosReporteDepurado.Rows(contFil).Item(i).ToString = "" Then

    '                        Else
    '                            insertaN = False
    '                            Exit For
    '                        End If
    '                    Next
    '                End If

    '                If insertaN = True Then
    '                    dtDatosDepuradosPasoDos.Rows(contColDep).Item("prod_codigo") = RTrim(LTrim(dtDatosDepuradosPasoDos.Rows(contColDep).Item("prod_codigo").ToString)) + "," + dtDatosReporteDepurado.Rows(contFil).Item("prod_codigo").ToString.Trim
    '                    dtDatosDepuradosPasoDos.Rows(contColDep).Item("PIELCOLOR") = dtDatosDepuradosPasoDos.Rows(contColDep).Item("PIELCOLOR").ToString.Trim + "," + dtDatosReporteDepurado.Rows(contFil).Item("PIELCOLOR").ToString.Trim
    '                    siinsertoN = True
    '                    dtDatosReporteDepurado.Rows(contFil).Delete()
    '                    Exit For
    '                Else
    '                    siinsertoN = False
    '                End If

    '            Next
    '            If siinsertoN = False Then
    '                dtDatosDepuradosPasoDos.ImportRow(dtDatosReporteDepurado.Rows(contFil))
    '                dtDatosReporteDepurado.Rows(contFil).Delete()
    '            End If
    '        End If
    '    Next

    '    Dim cadenaCodigos As String = ""
    '    Dim nuevaCadenaCods As String = ""
    '    Dim matrizCodigos() As String
    '    Dim existeCodigo As Boolean = False
    '    Dim tamCadComasCodigos As Integer

    '    Dim cadenaPielColor As String = ""
    '    Dim nuevaCadenaPielColor As String = ""
    '    Dim matrizPielColor() As String
    '    Dim existePielColor As Boolean = False
    '    Dim tamCadComasPielColor As Integer


    '    For Each rowDt As DataRow In dtDatosDepuradosPasoDos.Rows
    '        nuevaCadenaCods = ""
    '        nuevaCadenaPielColor = ""

    '        cadenaCodigos = rowDt.Item("prod_codigo").ToString
    '        matrizCodigos = Split((cadenaCodigos.Trim), ",")
    '        tamCadComasCodigos = UBound(matrizCodigos) 'era n
    '        Dim matrizTraspasoCodigo(tamCadComasCodigos) As String
    '        Dim contCods As Int32 = 0

    '        For i As Int32 = 0 To tamCadComasCodigos
    '            existeCodigo = False
    '            For j As Int32 = 0 To UBound(matrizTraspasoCodigo)
    '                If RTrim(LTrim(matrizCodigos(i))) = RTrim(LTrim(matrizTraspasoCodigo(j))) Then
    '                    existeCodigo = True
    '                End If
    '            Next
    '            If existeCodigo = False Then
    '                matrizTraspasoCodigo(contCods) = RTrim(LTrim(matrizCodigos(i)))
    '                contCods += 1
    '            End If
    '        Next

    '        For j As Int32 = 0 To UBound(matrizTraspasoCodigo)
    '            If Not matrizTraspasoCodigo(j) Is Nothing Then
    '                nuevaCadenaCods += matrizTraspasoCodigo(j) + ", "
    '            End If
    '        Next
    '        nuevaCadenaCods = nuevaCadenaCods.Substring(0, nuevaCadenaCods.Length - 2)
    '        rowDt.Item("prod_codigo") = nuevaCadenaCods

    '        cadenaPielColor = rowDt.Item("PIELCOLOR").ToString
    '        matrizPielColor = Split((cadenaPielColor.Trim), ",")
    '        tamCadComasPielColor = UBound(matrizPielColor)

    '        Dim matrizTraspasoPielColor(tamCadComasPielColor) As String
    '        Dim contPielColor As Int32 = 0

    '        For i As Int32 = 0 To tamCadComasPielColor
    '            existePielColor = False
    '            For j As Int32 = 0 To UBound(matrizTraspasoPielColor)
    '                If RTrim(LTrim(matrizPielColor(i))) = RTrim(LTrim(matrizTraspasoPielColor(j))) Then
    '                    existePielColor = True
    '                End If
    '            Next
    '            If existePielColor = False Then
    '                matrizTraspasoPielColor(contPielColor) = RTrim(LTrim(matrizPielColor(i)))
    '                contPielColor += 1
    '            End If
    '        Next

    '        For j As Int32 = 0 To UBound(matrizTraspasoPielColor)
    '            If Not matrizTraspasoPielColor(j) Is Nothing Then
    '                nuevaCadenaPielColor += matrizTraspasoPielColor(j) + ", "
    '            End If
    '        Next
    '        nuevaCadenaPielColor = nuevaCadenaPielColor.Substring(0, nuevaCadenaPielColor.Length - 2)
    '        rowDt.Item("PIELCOLOR") = nuevaCadenaPielColor

    '    Next

    '    'Dim dtDatosDepuradosPasoTres As New DataTable
    '    Dim quitarColumna As Boolean = False
    '    For i As Int32 = dtDatosDepuradosPasoDos.Columns.Count - 1 To contColumnsTitulos Step -1
    '        quitarColumna = True
    '        For Each row As DataRow In dtDatosDepuradosPasoDos.Rows
    '            If row.Item(i).ToString <> "" Then
    '                quitarColumna = False
    '                Exit For
    '            End If
    '        Next
    '        If quitarColumna = True Then
    '            dtDatosDepuradosPasoDos.Columns.Remove(dtDatosDepuradosPasoDos.Columns(i).Caption)
    '        End If
    '    Next

    '    For Each rowDt As DataRow In dtDatosDepuradosPasoDos.Rows
    '        rowDt.Item("cole_descripcion") = rowDt.Item("marc_descripcion") + " " + rowDt.Item("cole_descripcion") + " " + rowDt.Item("PIELCOLOR")

    '        Dim Modelos_split() As String
    '        Modelos_split = Split(rowDt.Item("prod_codigo"), ",")

    '        'METODO DE LA BURBUJA PARA ORDENAR LOS MODELOS
    '        Dim i As Integer
    '        Dim j As Integer
    '        For i = 1 To Modelos_split.Length Step 1
    '            For j = 0 To Modelos_split.Length - 2 Step 1
    '                If LTrim(RTrim(Modelos_split(j))) > LTrim(RTrim(Modelos_split(j + 1))) Then
    '                    Dim TEMP = Modelos_split(j)
    '                    Modelos_split(j) = Modelos_split(j + 1)
    '                    Modelos_split(j + 1) = TEMP
    '                End If
    '            Next
    '        Next

    '        For i = 0 To Modelos_split.Length - 1 Step 1
    '            If i = 0 Then
    '                rowDt.Item("prod_codigo") = Modelos_split(i)
    '            Else
    '                rowDt.Item("prod_codigo") = rowDt.Item("prod_codigo") + ", " + Modelos_split(i)
    '            End If
    '        Next
    '    Next



    '    Return dtDatosDepuradosPasoDos
    'End Function


    ''LISTA SIMULADOR______________________________________________________________________________
    ''' <summary>
    ''' METODO PARA CONSULTAR LA LISTA DE PRECIOS CON EL SIMULADOR DE PRECIOS Y POBLAR EL GRID CON LA INFORMACION RECUPERADA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PoblarListaSimulador()
        Dim objBU As New Negocios.ListaBaseBU
        Dim dtDatosReporte As New DataTable
        Dim dtDatosReporteDepurado As New DataTable
        Dim cadenaAgentes As String = ""
        Dim Marcas As String = ""
        Dim IncrementoPorcentajeCantidad As Boolean 'TRUE PARA PORCENTAJE, FALSE PARA CANTIDAD


        'RECUPERAMOS LAS MARCAS DE LOS PRODUCTOS A CONSULTAR Y LOS AGENTES DE LOS PRODUCTOS QUE SE CONSULTARAN
        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                If Marcas = "" Then
                    cadenaAgentes += row.Cells("cmfa_colaboradorid_agente").Value.ToString
                    Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                Else
                    cadenaAgentes += ", " + row.Cells("cmfa_colaboradorid_agente").Value.ToString
                    Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                End If
            End If
        Next

        'VALIDAMOS SÍ EL INCREMENTO SE CALCULARA EN PORCENTAJE O EN CANTIDAD
        If rdoPrecioPorcentajeActual.Checked = True Then
            IncrementoPorcentajeCantidad = True
        Else
            IncrementoPorcentajeCantidad = False
        End If


        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        If Marcas = "" Then
            objAdvertencia.mensaje = "Selecciona al menos una marca para poder consultar el Simulador de Lista de Precios."
            objAdvertencia.ShowDialog()
        Else
            If cmbClientes.SelectedIndex > 0 And cmbListaVentas.SelectedValue > 0 Then
                dtDatosReporte = objBU.consultarListaPreciosSimulador(cmbListaVentasCliente.SelectedValue, cmbClientes.SelectedValue, cadenaAgentes, False,
                                                              True, CBool(rdoModelosPedido.Checked), dttFechaInicio.Value.ToShortDateString,
                                                              dttFechaFin.Value.ToShortDateString, Marcas, cmbMoneda.SelectedValue, ParidadHOy,
                                                              numPrecioIncrementoParActual.Value, IncrementoPorcentajeCantidad)

                If dtDatosReporte.Rows.Count > 0 Then
                    'dtDatosReporteDepurado = resumirTablaModelosPrecio(dtDatosReporte)
                    dtListaPrecioST = dtDatosReporteDepurado
                    grdReporte.DataSource = dtDatosReporteDepurado
                    lblMensajeSinListaVentas.Visible = False
                Else
                    objAdvertencia.mensaje = "El cliente no tiene precios asignados."
                    objAdvertencia.ShowDialog()
                End If
            End If

        End If




        'Dim objLB As New Ventas.Negocios.ListaBaseBU
        'Dim dtDatosModelos As New DataTable

        'Dim mnNacionalExtranjera As Boolean
        'Dim IncrementoPorcentajeCantidad As Boolean

        'Dim Marcas As String
        'For Each row As UltraGridRow In grdAgentes.Rows
        '    If row.Cells(" ").Value = True Then

        '        If Marcas = "" Then
        '            Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
        '        Else
        '            Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
        '        End If
        '    End If
        'Next

        'Dim objAdvertencia As New AdvertenciaForm
        'objAdvertencia.StartPosition = FormStartPosition.CenterScreen

        'If Marcas = "" Then
        '    objAdvertencia.mensaje = "Selecciona al menos una marca para poder consultar la lista de precios."
        '    objAdvertencia.ShowDialog()
        'Else

        '    If cmbMoneda.SelectedValue = 1 Then
        '        mnNacionalExtranjera = True
        '    Else
        '        mnNacionalExtranjera = False
        '    End If

        '    If rdoPrecioPorcentajeActual.Checked = True Then
        '        IncrementoPorcentajeCantidad = True
        '    Else
        '        IncrementoPorcentajeCantidad = False
        '    End If

        '    dtDatosModelos = objLB.verDetallesListaPreciosClienteSOLOregistro(cmbListaBase.SelectedValue,
        '                                                                      cmbClientes.SelectedValue,
        '                                                                      cmbListaVentas.SelectedValue, numPrecioIncrementoParActual.Value,
        '                                                                      mnNacionalExtranjera,
        '                                                                      IncrementoPorcentajeCantidad, Paridad,
        '                                                                      Marcas,
        '                                                                      rdoTodosLosModelos.Checked,
        '                                                                      dttFechaInicio.Value.ToShortDateString,
        '                                                                      dttFechaFin.Value.ToShortDateString)
        '    If dtDatosModelos.Rows.Count > 0 Then
        '        grdReporte.DataSource = dtDatosModelos
        '    Else
        '        objAdvertencia.mensaje = "El cliente no tiene precios asignados."
        '        objAdvertencia.ShowDialog()
        '    End If
        'End If

        ''PoblarListaPrecios(True, False)

    End Sub


    Public Sub RecuperarDiferencia_Simulador()
        For Each row As UltraGridRow In grdReporte.Rows
            Dim DiferenciaParidad As Double = 0
            DiferenciaParidad = row.Cells("Precio").Value - row.Cells("P. Simulado").Value
            row.Cells("Diferencia").Value = DiferenciaParidad
            DiferenciaParidad = 0
            If cmbMoneda.SelectedValue > 1 Then
                DiferenciaParidad = row.Cells("P. Paridad").Value - row.Cells("P.P. Simulado").Value
                row.Cells("Dif. P.P. Simulado").Value = DiferenciaParidad
            End If
        Next

    End Sub

    ''LISTA PRECIOS SUGERIDA_______________________________________________________________________
    Public Sub PoblarListaPreciosSugerida(ByVal colecciones As Boolean, ByVal Familias As Boolean)
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosReporte As New DataTable
        Dim dtDatosReporteDepurado As New DataTable
        Dim cadenaAgentes As String = ""
        Dim Marcas As String = ""
        Dim idsMarcas As String = String.Empty
        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then

                If Marcas = "" Then
                    Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                Else
                    Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                End If


                If idsMarcas = "" Then
                    idsMarcas = LTrim(RTrim(row.Cells("marc_marcaid").Value.ToString))
                Else
                    idsMarcas = idsMarcas + ", " + LTrim(RTrim(row.Cells("marc_marcaid").Value.ToString))
                End If

            End If
        Next

        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        If Marcas = "" Then
            objAdvertencia.mensaje = "Selecciona al menos un agente para poder consultar la lista de precios."
            objAdvertencia.ShowDialog()
        Else
            If cmbClientes.SelectedIndex > 0 And cmbListaVentas.SelectedValue > 0 Then
                dtDatosReporte = objLCBU.consultaListaCliente(cmbListaVentas.SelectedValue, cmbClientes.SelectedValue, cadenaAgentes, Familias,
                                                              colecciones, CBool(rdoModelosPedido.Checked), dttFechaInicio.Value.ToShortDateString,
                                                              dttFechaFin.Value.ToShortDateString, Marcas, cmbMoneda.SelectedValue, Paridad,
                                                              rdo_ModeloSAY.Checked, idsMarcas)

                If dtDatosReporte.Rows.Count > 0 Then
                    'dtDatosReporteDepurado = resumirTablaModelosPrecio(dtDatosReporte)
                    grdReporte.DataSource = dtDatosReporteDepurado
                    AgregarPrecioVenta(dtDatosReporteDepurado)
                    grdReporte.DisplayLayout.Override.AllowColSizing = AllowColSizing.Synchronized
                Else
                    objAdvertencia.mensaje = "El cliente no tiene precios asignados."
                    objAdvertencia.ShowDialog()
                End If
            End If

        End If
    End Sub


    Public Sub AgregarPrecioVenta(ByVal dtTablaPrecios As DataTable)
        Dim ColumnaIndex As Integer
        Dim ColumnaNuevaIndex As Integer

        Dim dtTablaGrid As New DataTable
        Dim cont As Int16 = 0

        Dim objRamosBU As New Negocios.RamoBU
        Dim Marcaje As Integer

        If chkColecciones.Checked = True And chkFamilias.Checked = True Then
            ColumnaIndex = 5
        ElseIf chkColecciones.Checked = True Then
            ColumnaIndex = 4
        ElseIf chkFamilias.Checked = True Then
            ColumnaIndex = 4
        Else
            ColumnaIndex = 3
        End If

        Marcaje = objRamosBU.recuperarRamoMarcaje(cmbRamos.SelectedValue)
        ColumnaNuevaIndex = grdReporte.DisplayLayout.Bands(0).Columns.Count
        For cont = ColumnaIndex To grdReporte.DisplayLayout.Bands(0).Columns.Count - 1 Step 1
            grdReporte.DisplayLayout.Bands(0).Columns.Add(grdReporte.DisplayLayout.Bands(0).Columns(ColumnaIndex).Header.Caption + " Sugerido")
            grdReporte.DisplayLayout.Bands(0).Columns(ColumnaNuevaIndex).Header.VisiblePosition = _
                                                      grdReporte.DisplayLayout.Bands(0).Columns(ColumnaIndex).Header.VisiblePosition + 1
            ColumnaIndex += 1
            ColumnaNuevaIndex += 1
        Next

        If chkColecciones.Checked = True And chkFamilias.Checked = True Then
            ColumnaIndex = 5
        ElseIf chkColecciones.Checked = True Then
            ColumnaIndex = 4
        ElseIf chkFamilias.Checked = True Then
            ColumnaIndex = 4
        Else
            ColumnaIndex = 3
        End If

        For Each row As UltraGridRow In grdReporte.Rows
            For Each column As UltraGridColumn In grdReporte.DisplayLayout.Bands(0).Columns
                If column.Index >= ColumnaIndex Then
                    If column.Header.Caption.Contains(" Sugerido") = False Then
                        If IsDBNull(row.Cells(column.Header.Caption).Value) = False And row.Cells(column.Header.Caption).Text <> "" Then
                            row.Cells(column.Header.Caption + " Sugerido").Value = (CInt(row.Cells(column.Header.Caption).Value) * Marcaje / 100) + CInt(row.Cells(column.Header.Caption).Value)
                        End If
                    End If
                End If
            Next
        Next

        '' Agrupamos las columnas necesarias
        'grdReporte.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.GroupLayout
        'For cont = 0 To ColumnaIndex - 1 Step 1
        '    grdReporte.DisplayLayout.Bands(0).Columns(cont).Header.Caption = grdReporte.DisplayLayout.Bands(0).Columns(cont).Header.Caption
        'Next

        'Dim limitecolumnas As Int16 = (grdReporte.DisplayLayout.Bands(0).Columns.Count - ColumnaIndex) / 2 + ColumnaIndex - 1
        'For cont = ColumnaIndex To limitecolumnas Step 1
        '    Dim TituloGrupo = grdReporte.DisplayLayout.Bands(0).Columns(cont).Header.Caption
        '    grdReporte.DisplayLayout.Bands(0).Columns(cont).Header.Caption = "$ Compra"""
        '    grdReporte.DisplayLayout.Bands(0).Columns(TituloGrupo + " Venta").Header.Caption = "$ Sugerido"
        '    grdReporte.DisplayLayout.Bands(0).Groups.Add("Group" + TituloGrupo, TituloGrupo)
        '    grdReporte.DisplayLayout.Bands(0).Groups("Group" + TituloGrupo).Columns.Add(grdReporte.DisplayLayout.Bands(0).Columns(cont))
        '    grdReporte.DisplayLayout.Bands(0).Groups("Group" + TituloGrupo).Columns.Add(grdReporte.DisplayLayout.Bands(0).Columns(TituloGrupo + " Venta"))
        '    'band.Columns["Column 1"].RowLayoutColumnInfo.ParentGroup
        '    grdReporte.DisplayLayout.Bands(0).Columns(cont).RowLayoutColumnInfo.ParentGroup = grdReporte.DisplayLayout.Bands(0).Groups("Group" + TituloGrupo)
        '    grdReporte.DisplayLayout.Bands(0).Columns(TituloGrupo + " Venta").RowLayoutColumnInfo.ParentGroup = grdReporte.DisplayLayout.Bands(0).Groups("Group" + TituloGrupo)
        'Next






        formatoGridReporteListaDePrecios()

    End Sub



#End Region


#Region "COMBOS"

    ''COMBO CLIENTES
    ''' <summary>
    ''' LLENA EL COMBO BOX PARA SELECCIONAR CLIENTES
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LlenarComboClientes()
        Dim objCliente As New Negocios.ClientesBU
        Dim dtDatosClientes As New DataTable
        dtDatosClientes = objCliente.buscarClientesNombreComercial(True, 0, Entidades.SesionUsuario.UsuarioSesion.PUserUsuarioid)
        dtDatosClientes.Rows.InsertAt(dtDatosClientes.NewRow, 0)
        cmbClientes.DataSource = dtDatosClientes
        cmbClientes.DisplayMember = "clie_nombregenerico"
        cmbClientes.ValueMember = "clie_clienteid"
    End Sub

    ''' <summary>
    ''' MANDA LLAMAR EL METODO PARA RECUPERAR LOS DATOS DEL CLIENTE SELECCIONADO, EN CASO DE NO HABER SELECCIONADO NINGUN CLIENTE, 
    ''' LIMPIARA LOS CONTROLES CON LA INFORMACION DE LOS CLIENTES.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientes.SelectedIndexChanged
        If cmbClientes.SelectedIndex > 0 Then
            limpiarCamposTextos()
            llenarDatosCliente()
            txtAtn.Text = cmbClientes.Text
            chkSeleccionarTodo.Checked = False
            dtListaPrecioST = Nothing
            rdoListadePrecios.Checked = True
        Else
            dtListaPrecioST = Nothing
            'limpiarCampos()
            ''cmbListaBase.SelectedIndex = 0
            cmbListaVentasCliente.DataSource = Nothing
            cmbListaVentas.DataSource = Nothing
            rdoListadePrecios.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' RECUPERA LOS DATOS DEL CLIENTE SELECCIONADO EN EL COMBO BOX "CMBCLIENTE"
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub llenarDatosCliente()
        Try
            Me.Cursor = Cursors.WaitCursor
            cmbListaVentas.DataSource = Nothing
            IdCliente = CInt(cmbClientes.SelectedValue)

            Dim objClienteDatos As New Ventas.Negocios.ClientesDatosBU
            Dim objListaClt As New Ventas.Negocios.ListaPreciosVentaClienteBU

            Dim dtDatosClienteListaPreciosVentas As New DataTable
            Dim dtDatosModelos As New DataTable

            ''RECUPERAMOS LOS DATOS DEL CLIENTE
            'idListaVentasCliente = objListaClt.verListaVentasClienteActual(idCliente)
            dtDatosClienteListaPreciosVentas = objListaClt.consultaDatosClienteListaVentas(idCliente)


            ''OBTENER DATO CLAVE SAT
            txtClaveSAT.Text = objListaClt.consultaClaveSATCliente(IdCliente)

            ''RAMOS
            'Tools.Controles.ComboRamosConMarcajeRegistradoPorCliente(cmbRamos, idCliente)

            'NUMERACION
            'Tools.Controles.ComboNumeracionPais(cmbNumeracion)
            'cmbNumeracion.SelectedValue = 1

            'MONEDA
            If dtDatosClienteListaPreciosVentas.Rows.Count = 0 Then
                cmbListaBase.SelectedIndex = 0
                Tools.Controles.ComboMonedaextranjeraMasMonedaPesos(cmbMoneda, 1)
                cmbMoneda.SelectedIndex = 1
            Else
                Tools.Controles.ComboMonedaextranjeraMasMonedaPesos(cmbMoneda, dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_monedaid"))
                cmbMoneda.SelectedValue = dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_monedaid")
            End If

            If dtDatosClienteListaPreciosVentas.Rows.Count > 0 Then
                lblMensajeSinListaVentas.Visible = False


                'PARIDAD
                If dtDatosClienteListaPreciosVentas.Rows(0).Item("mone_nombre").ToString.Trim <> "PESOS" Then
                    gboxParidad.Visible = True

                    Dim dtParidadMoneda As New DataTable
                    dtParidadMoneda = Recuperar_Paridad_Moneda(dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_monedaid"))

                    If dtParidadMoneda.Rows.Count = 0 Then
                        lblParidadFecha.Text = ""
                        lblParidadMonedaValor.Text = "PESOS"
                        lblParidadIgual.Text = "$ 1 = $ 1.00"
                        ParidadHOy = 1
                    Else
                        For Each row As DataRow In dtParidadMoneda.Rows
                            Dim pesos As Double = CStr(row.Item(3))
                            Paridad = pesos
                            lblParidadMonedaValor.Text = (row.Item(1))
                            lblParidadFecha.Text = (row.Item(4))
                            lblParidadIgual.Text = "1 " + (row.Item(2)) + " = $ " + pesos.ToString("0,0.00", CultureInfo.InvariantCulture)
                            ParidadHOy = CDbl(row.Item(3))
                        Next
                    End If
                Else
                    Paridad = 1
                    gboxParidad.Visible = False
                End If
                grdReporte.DataSource = Nothing

                If IsDBNull(dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_calcularpreciocondescuento")) Then
                    chkDescuentoAplicado.Checked = False
                Else
                    chkDescuentoAplicado.Checked = dtDatosClienteListaPreciosVentas.Rows(0).Item("iccl_calcularpreciocondescuento")
                End If


                IdListaPrecioBase = dtDatosClienteListaPreciosVentas.Rows(0).Item("lpba_listapreciosbaseid")
                cmbListaBase.SelectedValue = IdListaPrecioBase
                llenarComboListaVentas(IdListaPrecioBase)
                idListaPrecioVenta = dtDatosClienteListaPreciosVentas.Rows(0).Item("lpvt_listaprecioventaid")
                cmbListaVentas.SelectedValue = dtDatosClienteListaPreciosVentas.Rows(0).Item("lpvt_listaprecioventaid")


            Else
                lblMensajeSinListaVentas.Visible = True
                lblMensajeSinListaVentas.Text = " El cliente no tiene asignada una lista de ventas"
                chkDescuentoAplicado.Checked = False
                gboxParidad.Visible = False
                grdReporte.DataSource = Nothing
            End If

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'idListaVentasCliente = 0
            grdReporte.DataSource = Nothing
            lblMensajeSinListaVentas.Visible = True

            Dim objError As New ErroresForm
            objError.mensaje = "Ocurrio un error insepesrado. Error: " + ex.Message
            objError.StartPosition = FormStartPosition.CenterScreen
            objError.ShowDialog()
        End Try
        Me.Cursor = Cursors.Default
    End Sub


    ''COMBO "LISTA BASE"

    Public Sub llenarComboListasBase()
        Dim objLPVC As New Negocios.ListaBaseBU
        Dim dtDatosListaPrecios As New DataTable
        dtDatosListaPrecios = objLPVC.RecuperarListasBaseExistentes
        Dim newRow As DataRow = dtDatosListaPrecios.NewRow
        dtDatosListaPrecios.Rows.InsertAt(newRow, 0)
        cmbListaBase.DataSource = dtDatosListaPrecios
        cmbListaBase.DisplayMember = "LISTABASE"
        cmbListaBase.ValueMember = "lpba_listapreciosbaseid"
        cmbListaBase.SelectedIndex = 0
    End Sub

    ''' <summary>
    ''' LLENA EL COMBO LISTA DE VENTAS EN CASO DE QUE EL COMBO LISTA BASE TENGA UNA LISTA SELECCIONADA
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmbListaBase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaBase.SelectedIndexChanged
        cmbListaVentas.DataSource = Nothing
        If cmbListaBase.SelectedIndex > 0 And cmbClientes.SelectedIndex > 0 Then
            llenarComboListaVentas(cmbListaBase.SelectedValue)
        Else
            cmbListaVentas.DataSource = Nothing
            cmbListaVentas.Items.Clear()
        End If
    End Sub

    ''COMBO  "ListaVentas"
    Public Sub llenarComboListaVentas(ByVal idListaBase As Int32)
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosListaVentas As New DataTable
        ' ''dtDatosListaVentas = objLVC.verListaVentasConsultaSimple(idListaBase)

        dtDatosListaVentas = objLVC.consultaListaVentas(idListaBase, cmbClientes.SelectedValue)
        If dtDatosListaVentas.Rows.Count > 0 Then
            dtDatosListaVentas.Rows.InsertAt(dtDatosListaVentas.NewRow, 0)
            cmbListaVentas.DataSource = dtDatosListaVentas
            cmbListaVentas.DisplayMember = "LISTAVENTAS"
            cmbListaVentas.ValueMember = "lpvt_listaprecioventaid"

            cmbListaVentas.SelectedIndex = 0
            'idListaCliente = dtDatosListaVentas.Rows(0).Item("lvcl_listaventasclienteid").ToString
            'verModelosListaPrecioCliente(idListaCliente)
            lblMensajeSinListaVentas.Visible = False
        Else
            cmbListaVentas.DataSource = Nothing
            grdReporte.DataSource = Nothing

            lblMensajeSinListaVentas.Visible = True
            lblMensajeSinListaVentas.Text = " El cliente no tiene asignada una lista de ventas"
            'verModelosListaPrecioCliente(0)
        End If
    End Sub

    ''COME LISTAVENTASCLIENTEPRECIO
    Public Sub llenarComboListaVentasClientePrecio(ByVal idlistaventas As Integer)
        Dim objLVC As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosListaVentas As New DataTable
        ' ''dtDatosListaVentas = objLVC.verListaVentasConsultaSimple(idListaBase)

        dtDatosListaVentas = objLVC.consultaListaVentasClientePrecio(idlistaventas, cmbClientes.SelectedValue)
        If dtDatosListaVentas.Rows.Count > 0 Then
            dtDatosListaVentas.Rows.InsertAt(dtDatosListaVentas.NewRow, 0)
            cmbListaVentasCliente.DataSource = dtDatosListaVentas
            cmbListaVentasCliente.ValueMember = "ID_LVClientePrecio"
            cmbListaVentasCliente.DisplayMember = "NOMBRE"
            cmbListaVentasCliente.SelectedIndex = 0
            'idListaCliente = dtDatosListaVentas.Rows(0).Item("lvcl_listaventasclienteid").ToString
            'verModelosListaPrecioCliente(idListaCliente)


            cmbListaVentasCliente.SelectedIndex = 1

            lblMensajeSinListaVentas.Visible = False
        Else
            cmbListaVentasCliente.DataSource = Nothing
            grdReporte.DataSource = Nothing

            lblMensajeSinListaVentas.Visible = True
            lblMensajeSinListaVentas.Text = " El cliente no tiene lista de precios"

        End If
    End Sub

    Private Sub cmbListaVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentas.SelectedIndexChanged
        If cmbListaVentas.SelectedIndex > 0 Then
            llenarComboListaVentasClientePrecio(cmbListaVentas.SelectedValue)
        Else
            cmbListaVentasCliente.DataSource = Nothing
            cmbListaVentasCliente.Items.Clear()
        End If
    End Sub


    Private Sub cmbListaVentasCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListaVentasCliente.SelectedIndexChanged
        If cmbListaVentasCliente.SelectedIndex > 0 Then
            recuperarValoresDeListaVentaClientePrecio(cmbListaVentasCliente.SelectedValue)
            PoblarGridAgentes(IdCliente, cmbListaVentasCliente.SelectedValue)
        Else
            grdAgentes.DataSource = Nothing
        End If
    End Sub


#End Region

#Region "FORMATOS GRID"

    Public Sub formatoGridReporteListaDePrecios()
        grdReporte.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdReporte.DisplayLayout.Bands(0).Columns("Marca").Header.Caption = "Marca"
        grdReporte.DisplayLayout.Bands(0).Columns("Marca").Width = 100
        grdReporte.DisplayLayout.Bands(0).Columns("Marca").CellActivation = Activation.NoEdit
        grdReporte.DisplayLayout.Bands(0).Columns("Marca").Hidden = True

        If grdReporte.DisplayLayout.Bands(0).Columns.Exists("ModelosSICY") Then
            grdReporte.DisplayLayout.Bands(0).Columns("ModelosSICY").Header.Caption = "Modelo"
            grdReporte.DisplayLayout.Bands(0).Columns("ModelosSICY").CellActivation = Activation.NoEdit
        Else
            grdReporte.DisplayLayout.Bands(0).Columns("Modelos").Header.Caption = "Modelo"
            grdReporte.DisplayLayout.Bands(0).Columns("Modelos").CellActivation = Activation.NoEdit
        End If

        If grdReporte.DisplayLayout.Bands(0).Columns.Exists("Colección") Then
            grdReporte.DisplayLayout.Bands(0).Columns("Colección").Width = 100
            grdReporte.DisplayLayout.Bands(0).Columns("Colección").Header.Caption = "Colección"
            grdReporte.DisplayLayout.Bands(0).Columns("Colección").CellActivation = Activation.NoEdit
        End If

        grdReporte.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

        With grdReporte.DisplayLayout.Bands(0)
            .Columns("Marca").Width = 100
            .Columns("Marca").CellActivation = Activation.NoEdit
            If grdReporte.DisplayLayout.Bands(0).Columns.Exists("ModelosSICY") Then
                .Columns("ModelosSICY").CellActivation = Activation.NoEdit
            Else
                .Columns("Modelos").CellActivation = Activation.NoEdit
            End If
            .Columns("Colección").CellActivation = Activation.NoEdit
        End With

        Dim simbolo As String = RecuperarSimboloMoneda(cmbMoneda.SelectedValue)
        For Each column As UltraGridCell In grdReporte.Rows(0).Cells
            If column.Column.Key <> "Colección" And
                column.Column.Key <> "Marca" And
                column.Column.Key <> "Modelos" And
                column.Column.Key <> "ModelosSICY" Then
                If cmbMoneda.SelectedValue <> 1 Or cmbClientes.Text.Contains("FABRICAS DE CALZADO ANDREA") Then
                    grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Format = "(C, en-US)"
                    If cmbMoneda.Text.Contains("PESO") Then
                        grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Format = "(C, en-US)"
                    ElseIf cmbMoneda.Text.Contains("YEN") Then
                        grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Format = "(C, ja-JP)"
                    ElseIf cmbMoneda.Text.Contains("EURO") Then
                        grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Format = "(C, fr-FR)"
                    ElseIf cmbMoneda.Text.Contains("DOLAR") Then
                        grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Format = "(C, en-US)"
                    Else
                        grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Format = "(C, en-US)"
                    End If
                End If
                grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).CellActivation = Activation.NoEdit
                grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).CellAppearance.TextHAlign = HAlign.Right
                grdReporte.DisplayLayout.Bands(0).Columns(column.Column.Key).Width = 100
            End If
        Next

    End Sub

    Private Function RecuperarSimboloMoneda(ByVal IdMoneda As Integer) As String
        Dim objBU As New Negocios.ListaPreciosVentaClienteBU
        Return objBU.RecuperarSimboloMoneda(IdMoneda)

    End Function


    Private Function RecuperarModelajeUSA_EURO(ByVal Corrida_principal As String, IdPais As Integer)
        Dim objBU As New Negocios.ListaPreciosVentaClienteBU
        Dim Corrida As String = String.Empty
        Corrida = objBU.RecuperarModelajeUSA_EURO(Corrida_principal, IdPais)
        Return Corrida
    End Function


    Public Sub FormatoGridModelaje()

        With grdReporte
            .DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle
            .DisplayLayout.Bands(0).Columns("Foto").Style = ColumnStyle.Image
            .DisplayLayout.Bands(0).Columns("Foto").CellMultiLine = Infragistics.Win.DefaultableBoolean.True
            .DisplayLayout.Bands(0).Columns("#").Hidden = True
            .DisplayLayout.Bands(0).Columns("Comentarios/Observaciones").Hidden = True

            .DisplayLayout.Bands(0).Columns("Marca").Width = 100


            'For Each row As UltraGridRow In grdReporte.Rows
            '    If (row.Cells("Precio").Value).Contains(".") Then
            '        row.Cells("Precio").Value = row.Cells("Precio").Value + "0"
            '    Else
            '        row.Cells("Precio").Value = row.Cells("Precio").Value + ".00"
            '    End If

            'Next
        End With
    End Sub

    Public Sub formatoSimulador()
        With grdReporte.DisplayLayout.Bands(0)

            .Columns("P. Base").CellAppearance.TextHAlign = HAlign.Right
            .Columns("P. Base").Style = ColumnStyle.DoubleWithSpin

            .Columns("P. Calculado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("P. Calculado").Style = ColumnStyle.DoubleWithSpin

            .Columns("Precio").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Precio").Style = ColumnStyle.DoubleWithSpin

            .Columns("P. Simulado").CellAppearance.TextHAlign = HAlign.Right
            .Columns("P. Simulado").Style = ColumnStyle.DoubleWithSpin

            .Columns("Diferencia").CellAppearance.TextHAlign = HAlign.Right
            .Columns("Diferencia").Style = ColumnStyle.DoubleWithSpin


            If cmbMoneda.SelectedValue > 1 Then
                .Columns("P. Paridad").CellAppearance.TextHAlign = HAlign.Right
                .Columns("P. Paridad").Style = ColumnStyle.DoubleWithSpin

                .Columns("P. Paridad Calcu").CellAppearance.TextHAlign = HAlign.Right
                .Columns("P. Paridad Calcu").Style = ColumnStyle.DoubleWithSpin

                .Columns("P.P. Simulado").CellAppearance.TextHAlign = HAlign.Right
                .Columns("P.P. Simulado").Style = ColumnStyle.DoubleWithSpin

                .Columns("Dif. P.P. Simulado").CellAppearance.TextHAlign = HAlign.Right
                .Columns("Dif. P.P. Simulado").Style = ColumnStyle.DoubleWithSpin
            End If
        End With


        'grdReporte.DisplayLayout.PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        'grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        grdReporte.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        grdReporte.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
        grdReporte.DisplayLayout.Override.RowSelectorWidth = 35
        grdReporte.DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        grdReporte.Rows(0).Selected = True
    End Sub

    Public Sub formatosGrid()

        With grdReporte.DisplayLayout.Bands(0)
            .Columns("prod_codigo").Header.Caption = "Código"
            .Columns("prod_descripcion").Header.Caption = "Modelo"
            .Columns("cole_descripcion").Header.Caption = "Colección"
            .Columns("marc_descripcion").Header.Caption = "Marca"
            .Columns("piel_descripcion").Header.Caption = "Piel"
            .Columns("color_descripcion").Header.Caption = "Color"
            .Columns("lpbp_precio").Header.Caption = "Precio"
            '.Columns("color_descripcion").Header.Caption = "Color"
            .Columns("talla_descripcion").Header.Caption = "Corrida"
            .Columns("prod_codigo").CellActivation = Activation.NoEdit
            .Columns("prod_descripcion").CellActivation = Activation.NoEdit
            .Columns("cole_descripcion").CellActivation = Activation.NoEdit
            .Columns("marc_descripcion").CellActivation = Activation.NoEdit
            .Columns("piel_descripcion").CellActivation = Activation.NoEdit
            .Columns("color_descripcion").CellActivation = Activation.NoEdit
            .Columns("talla_descripcion").CellActivation = Activation.NoEdit
            .Columns("lpbp_precio").CellActivation = Activation.NoEdit
            .Columns("pres_productoestiloid").Hidden = True
            .Columns("prod_codigo").Hidden = True
            .PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
        End With
        grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

    Private Sub grdReporte_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdReporte.InitializeLayout

        If grdReporte.DisplayLayout.Bands(0).Columns.Count <= 11 And chkColecciones.Checked = False And chkFamilias.Checked = False Then
            grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        ElseIf grdReporte.DisplayLayout.Bands(0).Columns.Count <= 11 Then
            grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        ElseIf rdoModelaje.Checked = True Then
            grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
        Else
            grdReporte.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns

        End If


        With grdReporte
            .DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.LightSteelBlue
            .DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
            .DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorWidth = 45
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = DefaultableBoolean.True
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
        End With

        If rdoModelaje.Checked = True Then
            FormatoGridModelaje()
            grdReporte.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect
        ElseIf rdoListadePrecios.Checked = True Then
            formatoGridReporteListaDePrecios()
        ElseIf RdoSimulador.Checked = True Then
            e.Layout.Override.CellMultiLine = DefaultableBoolean.False
            formatoGridReporteListaDePrecios()
        ElseIf RdoListaClaveSat.Checked = True Then
            formatoGridReporteListaClaveSAT()
        End If

        'If rdoListaPrecioSugerida.Checked = True Then
        e.Layout.Override.CellMultiLine = DefaultableBoolean.True
        'End If

        lblUltimaActualizacion.Text = "Ultima Actualización: " + Now.ToString("g")

        If rdoListadePrecios.Checked = True Or RdoSimulador.Checked = True Then

            Dim IndicePrimerColumna As Integer
            Dim Cantidad_Grupos As Integer = 0

            'GUARDAMOS EL DISEÑO Y LA BANDA EN VARIABLES PARA HACER REFERENCIA A ELLOS MAS FACIL "AJOY"
            Dim Layout As UltraGridLayout = e.Layout
            Dim rootBand As UltraGridBand = Layout.Bands(0)

            rootBand.RowLayoutStyle = RowLayoutStyle.GroupLayout

            'Validamos cuantas columnas de informacion hay en el grid, pasa despues determinar la cantidad de columnas de corridas
            IndicePrimerColumna = 3

            Cantidad_Grupos = rootBand.Columns.Count - IndicePrimerColumna

            'FOR PARA AGREGAR LOS RESPECTIVOS GRUPOS 
            For n = 0 To rootBand.Columns.Count - 1 Step 1

                If n < IndicePrimerColumna Then
                    ' If rootBand.Columns(n).Header.Caption <> "Piel/Color" And rootBand.Columns(n).Header.Caption <> "Marca" And rootBand.Columns(n).Header.Caption <> "proes" Then
                    If rootBand.Columns(n).Header.Caption <> "Marca" Then
                        Dim grupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption, " ")
                        Dim Subgrupo As UltraGridGroup = rootBand.Groups.Add(rootBand.Columns(n).Header.Caption + n.ToString, " ")

                        Subgrupo.RowLayoutGroupInfo.ParentGroup = grupo
                        Subgrupo.RowLayoutGroupInfo.OriginX = n

                        rootBand.Columns(n).RowLayoutColumnInfo.ParentGroup = Subgrupo
                    End If
                Else
                    ''RECUPERAMOS EL NOMBRE DE LA COLUMNA PARA ENUMERACION EUROPEA
                    Dim NombreColumna As String
                    NombreColumna = RecuperarModelajeUSA_EURO(grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption, 17)

                    Dim NombreColumna2 As String
                    NombreColumna2 = RecuperarModelajeUSA_EURO(grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption, 4)
                    'If rootBand.Groups.Exists(NombreColumna) Then
                    '    Console.WriteLine("Existe")
                    'Else
                    '    Console.WriteLine("No Existe")
                    'End If

                    'If rootBand.Groups.Exists(NombreColumna) Then
                    'ElseIf rootBand.Groups.Exists(NombreColumna2) Then
                    'Else
                    Dim Grupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna, NombreColumna.Split("_").ElementAt(1))
                    Dim SubGrupo As UltraGridGroup = rootBand.Groups.Add(NombreColumna2, NombreColumna2.Split("_").ElementAt(1))
                    SubGrupo.RowLayoutGroupInfo.ParentGroup = Grupo
                        SubGrupo.RowLayoutGroupInfo.OriginX = n
                        rootBand.Columns(IndicePrimerColumna).RowLayoutColumnInfo.ParentGroup = SubGrupo
                    'End If

                    IndicePrimerColumna += 1
                End If
            Next


            'Dim band As UltraGridBand = grdReporte.DisplayLayout.Bands(0)
            'band.RowLayoutStyle = RowLayoutStyle.ColumnLayout
            'For n = grdReporte.DisplayLayout.Bands(0).Columns.Count To grdReporte.DisplayLayout.Bands(0).Columns.Count + (grdReporte.DisplayLayout.Bands(0).Columns.Count - IndicePrimerColumna - 1) Step 1


            'Next

            '    Dim column As UltraGridColumn
            '    Dim info As RowLayoutColumnInfo

            '    Dim NombreColumna As String
            '    NombreColumna = RecuperarModelajeUSA_EURO(grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption, 17)


            '    column = band.Columns.Add(NombreColumna, NombreColumna)
            '    info = column.RowLayoutColumnInfo

            '    info.LabelPosition = LabelPosition.LabelOnly  '' can use this code for to display only col header w/o any cell space or below three line of code..

            '    info.ActualCellSize = New Size(1, 1)
            '    info.MinimumCellSize = New Size(1, 1)

            '    info.PreferredCellSize = New Size(1, 1)

            '    info.OriginX = n + 4
            '    info.SpanX = 1
            '    info.OriginY = 0
            '    info.SpanY = 1

            '    'SEGUNDO NIVEL

            '    Dim Nombre2daCol As String
            '    Nombre2daCol = RecuperarModelajeUSA_EURO(grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption, 4)

            '    Dim column1 As UltraGridColumn
            '    column1 = band.Columns.Add(Nombre2daCol, Nombre2daCol)

            '    info = band.Columns(Nombre2daCol).RowLayoutColumnInfo
            '    info.OriginX = n + 4
            '    info.SpanX = 1
            '    info.OriginY = 1
            '    info.SpanY = 1


            '    ''SEGUNDO NIVEL

            '    'Dim Nombre3raCol As String
            '    'Nombre3raCol = grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption + IndicePrimerColumna.ToString

            '    'Dim column3 As UltraGridColumn
            '    'column3 = band.Columns.Add(Nombre3raCol, grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption)

            '    'info = band.Columns(Nombre3raCol).RowLayoutColumnInfo
            '    'info.OriginX = n + 4
            '    'info.SpanX = 1
            '    'info.OriginY = 1
            '    'info.SpanY = 1
            '    ' ''TERCER NIVEL
            '    info = band.Columns(grdReporte.DisplayLayout.Bands(0).Columns(IndicePrimerColumna).Header.Caption).RowLayoutColumnInfo
            '    info.OriginX = n + 4
            '    info.SpanX = 1
            '    info.OriginY = 2
            '    info.SpanY = 1

            '    IndicePrimerColumna += 1
            'Next


        End If

    End Sub

    Private Sub grdReporte_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grdReporte.InitializeRow
        If rdoModelaje.Checked = True Then

            If e.Row.IsFilterRow = True Then
                e.Row.Height = 20
            Else
                e.Row.Height = 100
                e.Row.CellAppearance.TextVAlign = VAlign.Middle
            End If
            Dim imagen As System.Drawing.Image
            Me.Cursor = Cursors.WaitCursor
            If e.Row.Cells.Exists("FOTO") Then
                e.Row.Cells("FOTO").Appearance.BackColor = Color.White
                Try
                    If IsDBNull(e.Row.Cells("FOTO")) = False Then
                        imagen = Nothing

                        If Not e.Row.Cells("FOTO").Value Is Nothing Then
                            StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("FOTO").Value.ToString)
                            imagen = System.Drawing.Image.FromStream(StreamFoto)
                            e.Row.Cells("FOTO").Appearance.ImageBackground = imagen
                        End If
                    End If

                Catch ex As Exception
                    Try
                        StreamFoto = objFTP.StreamFileThumbNail(Carpeta, e.Row.Cells("FOTO").Value.ToString)
                        imagen = System.Drawing.Image.FromStream(StreamFoto)

                        e.Row.Cells("FOTO").Appearance.ImageBackground = imagen
                    Catch exe As Exception

                    End Try
                End Try
            End If


            If e.Row.Index = grdReporte.Rows.Count - 1 Then
                Me.Cursor = Cursors.Default
            Else
                If lblMensajeSinListaVentas.Visible = False Then
                    Me.Cursor = Cursors.Default
                End If
            End If

        End If

    End Sub

    Private Sub grdAgentes_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grdAgentes.InitializeLayout
        With grdAgentes
            .DisplayLayout.Bands(0).Columns(" ").Header.VisiblePosition = 1
            .DisplayLayout.Bands(0).Columns("cmfa_colaboradorid_agente").Hidden = True
            .DisplayLayout.Bands(0).Columns("AGENTE").CellActivation = Activation.NoEdit

            .DisplayLayout.Bands(0).PerformAutoResizeColumns(False, Infragistics.Win.UltraWinGrid.PerformAutoSizeType.AllRowsInBand, True)
            .DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.VisibleIndex
            .DisplayLayout.Override.RowSelectorAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        End With
    End Sub

    Public Sub PoblarGridAgentes(ByVal Id_Cliente As Integer, ByVal IdListaVentaClientePrecio As Integer)
        Dim objClienteDatos As New Ventas.Negocios.ClientesDatosBU
        Dim dtAgentes As New DataTable
        Dim conlista As Boolean = True
        If rdoListadePrecios.Checked = True Or rdoModelaje.Checked = True Then
            conlista = True
        Else
            conlista = False
        End If

        Dim marcaConsAgente As Int32 = 0
        If IdCliente = 816 Then
            marcaConsAgente = 1
        Else
            marcaConsAgente = 7
        End If

        dtAgentes = objClienteDatos.AgenteClienteMarcasListaPrecios(Id_Cliente, IdListaVentaClientePrecio, conlista, marcaConsAgente, IdListaPrecioBase)

        Dim columns As DataColumnCollection = dtAgentes.Columns
        Dim columna0 As New DataColumn
        columna0.DataType = Type.GetType("System.Boolean")
        columna0.DefaultValue = False
        columna0.ColumnName = " "
        columns.Add(columna0)
        For Each row As DataRow In dtAgentes.Rows
            row.Item(" ") = 0
        Next
        If dtAgentes.Rows.Count > 0 Then
            grdAgentes.DataSource = dtAgentes
            grdAgentes.DisplayLayout.Bands(0).Columns("marc_marcaid").Hidden = True
        Else
            grdAgentes.DataSource = Nothing
        End If

    End Sub


    Public Sub formatoGridReporteListaClaveSAT()
        grdReporte.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
        grdReporte.DisplayLayout.Bands(0).Columns("Marca").Header.Caption = "Marca"
        grdReporte.DisplayLayout.Bands(0).Columns("Marca").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("ModeloSICY").Header.Caption = "Modelo SICY"
        grdReporte.DisplayLayout.Bands(0).Columns("ModeloSICY").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("Coleccion").Header.Caption = "Colección"
        grdReporte.DisplayLayout.Bands(0).Columns("Coleccion").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("temporada").Header.Caption = "Temporada"
        grdReporte.DisplayLayout.Bands(0).Columns("temporada").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("familia").Header.Caption = "Familia"
        grdReporte.DisplayLayout.Bands(0).Columns("familia").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("ModeloSAY").Header.Caption = "Modelo SAY"
        grdReporte.DisplayLayout.Bands(0).Columns("ModeloSAY").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("Piel").Header.Caption = "Piel"
        grdReporte.DisplayLayout.Bands(0).Columns("Piel").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("Color").Header.Caption = "Color"
        grdReporte.DisplayLayout.Bands(0).Columns("Color").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("Corrida").Header.Caption = "Corrida"
        grdReporte.DisplayLayout.Bands(0).Columns("Corrida").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("claveSat").Header.Caption = "Clave SAT"
        grdReporte.DisplayLayout.Bands(0).Columns("claveSat").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.Bands(0).Columns("descripcionSat").Header.Caption = "Descripción Clave SAT"
        grdReporte.DisplayLayout.Bands(0).Columns("descripcionSat").CellActivation = Activation.NoEdit

        grdReporte.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

    End Sub

#End Region

#Region "REPORTES"

#Region "EXCEL"

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If grdReporte.Rows.Count = 0 Then
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.mensaje = "No hay registros que exportar."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
        Else
            llenarReporteListaClienteExportarExcel()
        End If
    End Sub

    Public Sub llenarReporteListaClienteExportarExcel()

        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtDatosReporte As New DataTable
        Dim dtDatosReporteDepurado As New DataTable
        Dim cadenaAgentes As String = ""
        Dim Marca As String = ""


        Dim sfd As New SaveFileDialog
        sfd.DefaultExt = "xlsx"
        sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"

        Dim result As DialogResult = sfd.ShowDialog()
        Dim fileName As String = sfd.FileName
        If result = Windows.Forms.DialogResult.OK Then
            Try
                'Carpeta = My.Computer.FileSystem.SpecialDirectories.Desktop + "\" + +".xlsx"
                Me.Cursor = Cursors.WaitCursor
                ultExportGrid.Export(grdReporte, fileName)

                Dim objMensajeExito As New Tools.ExitoForm
                objMensajeExito.mensaje = "Archivo exportado correctamente en la ubicación: " + fileName
                objMensajeExito.StartPosition = FormStartPosition.CenterScreen
                objMensajeExito.ShowDialog()
                Me.Cursor = Cursors.Default
                Process.Start(fileName)
            Catch ex As Exception
                Dim objMensajeError As New Tools.ErroresForm
                objMensajeError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objMensajeError.StartPosition = FormStartPosition.CenterScreen
                objMensajeError.ShowDialog()
            End Try
        End If

    End Sub

#End Region

#Region "Stimulsoft"

    Private Sub ImprimirReporteStimulsoft(ByVal dtTablaDatos As DataTable, ByVal IdListaVentas As Integer, ByVal IdCliente As Integer, ByVal FechaInicioLista As String, ByVal Atn As String, ByVal CodigoParidad As String)

        If IsNothing(dtTablaDatos) Then
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "Consulte la lista de precios para poder imprimir el reporte."
            objAdvertencia.ShowDialog()
            Return
        End If
        If dtTablaDatos.Rows.Count = 0 Then
            Dim objAdvertencia As New AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No hay datos para mostrar el reporte el reporte."
            objAdvertencia.ShowDialog()
            Return
        End If

        Dim dsResultado As New DataSet
        dsResultado = recuperarTablaParaReporte(dtTablaDatos)

        Dim nota As String
        Dim objFTC As New FichaTecnicaClienteForm
        nota = objFTC.LlenarDetalleNotaListaPrecio(IdListaVentas, IdCliente)


        Dim objBU As New Framework.Negocios.ReportesBU
        Dim EntidadReporte As Entidades.Reportes
        EntidadReporte = objBU.LeerReporteporClave("VENTAS_LISTAPRECIOS")
        Dim archivo As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\" +
            EntidadReporte.Pnombre + ".mrt"
        My.Computer.FileSystem.WriteAllText(archivo, EntidadReporte.Pxml, False)
        Dim reporte As New StiReport
        reporte.Load(archivo)
        reporte.Compile()
        reporte("NombreReporte") = "SAY: Lista de precios.mrt"
        reporte("Usuario") = Entidades.SesionUsuario.UsuarioSesion.PUserUsername.ToString
        reporte("Inicio") = FechaInicioLista
        reporte("urlImagenNave") = Tools.Controles.ObtenerLogoNave(43)
        reporte("NombreNave") = "Comercializadora"
        reporte("atn") = Atn
        reporte("Nota") = nota
        If RdoSimulador.Checked = True Then
            reporte("cod_paridad") = "Propuesta"
        Else
            reporte("cod_paridad") = CodigoParidad
        End If

        reporte.Dictionary.Clear()
        reporte.RegData(dsResultado.DataSetName, dsResultado)
        reporte.Dictionary.Synchronize()
        reporte.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function recuperarTablaParaReporte(ByVal dtTablaDatos As DataTable)
        Dim dsResultado As New DataSet
        Dim dtListaPrecio As New DataTable
        Dim dtMarcas As New DataTable
        Dim dtLista1 As New DataTable
        Dim dtListaSoloPrecio As New DataTable
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU

        Dim dtHeaders As New DataTable
        Dim dtHeadersAme As New DataTable
        Dim dtHeadersEur As New DataTable
        'RECUPERAMOS LOS AGENTES SELECCIONADOS
        Dim cadenaAgentes As String = ""
        Dim Marcas As String = ""
        Dim k As Integer = 0

        For Each column As DataColumn In dtTablaDatos.Columns
            If k = 2 Then
                dtLista1.Columns.Add("Piel/Color")
                dtLista1.Columns.Add(column.Caption)
            Else
                dtLista1.Columns.Add(column.Caption)
            End If
            k += 1
        Next

        For Each row In dtTablaDatos.Rows
            dtLista1.Rows.Add()
            For cont = 0 To dtTablaDatos.Columns.Count - 1 Step 1
                If cont < 2 Then
                    dtLista1.Rows(dtLista1.Rows.Count - 1).Item(cont) = row.item(cont)
                ElseIf cont = 2 Then
                    dtLista1.Rows(dtLista1.Rows.Count - 1).Item(cont) = ""
                    dtLista1.Rows(dtLista1.Rows.Count - 1).Item(cont + 1) = row.item(cont)
                ElseIf cont > 2 Then
                    dtLista1.Rows(dtLista1.Rows.Count - 1).Item(cont + 1) = row.item(cont)
                End If
            Next
        Next

        dtListaSoloPrecio = dtLista1.Copy()

        dtListaSoloPrecio.Columns.Add("NoMarca")
        dtMarcas.Columns.Add("NoMarca")
        dtMarcas.Columns.Add("Marca")
        Dim m = 1

        For CONT = 0 To dtLista1.Rows.Count - 1 Step 1
            If CONT = 0 Then
                dtListaSoloPrecio.Rows(CONT).Item("NoMarca") = m

                Dim Fila As DataRow = dtMarcas.NewRow
                Fila("NoMarca") = m
                Fila("Marca") = CStr(dtListaSoloPrecio.Rows(CONT).Item("Marca"))
                dtMarcas.Rows.InsertAt(Fila, 0)
            Else
                Dim marc1 As String
                Dim marc2 As String
                marc1 = dtListaSoloPrecio.Rows(CONT).Item("Marca").ToString
                marc2 = dtListaSoloPrecio.Rows(CONT - 1).Item("Marca").ToString
                If dtListaSoloPrecio.Rows(CONT).Item("Marca") = dtListaSoloPrecio.Rows(CONT - 1).Item("Marca") Then
                    dtListaSoloPrecio.Rows(CONT).Item("NoMarca") = m
                Else
                    m += 1
                    dtListaSoloPrecio.Rows(CONT).Item("NoMarca") = m

                    Dim Fila As DataRow = dtMarcas.NewRow
                    Fila("NoMarca") = m
                    Fila("Marca") = CStr(dtListaSoloPrecio.Rows(CONT).Item("Marca"))
                    dtMarcas.Rows.InsertAt(Fila, 0)
                End If
            End If
        Next

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                cadenaAgentes += row.Cells("cmfa_colaboradorid_agente").Value.ToString + ","
                If Marcas = "" Then
                    Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                Else
                    Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                End If
            End If
        Next
        cadenaAgentes += "0"

        Dim ColumnasEncontradas As Integer
        ColumnasEncontradas = dtLista1.Columns.Count

        Dim n As Integer = 1
        Dim columns As DataColumnCollection = dtHeaders.Columns
        Dim columns1 As DataColumnCollection = dtListaPrecio.Columns
        Dim ColAmerica As DataColumnCollection = dtHeadersAme.Columns
        Dim ColEur As DataColumnCollection = dtHeadersEur.Columns

        For Each column In dtListaSoloPrecio.Columns
            If n < dtListaSoloPrecio.Columns.Count Then
                Dim columna0 As New DataColumn
                columna0.DataType = Type.GetType("System.String")
                columna0.DefaultValue = False
                columna0.ColumnName = "H" + n.ToString
                columns.Add(columna0)

                Dim columna0Ame As New DataColumn
                columna0Ame.DataType = Type.GetType("System.String")
                columna0Ame.DefaultValue = False
                columna0Ame.ColumnName = "H" + n.ToString
                ColAmerica.Add(columna0Ame)

                Dim columna0Eur As New DataColumn
                columna0Eur.DataType = Type.GetType("System.String")
                columna0Eur.DefaultValue = False
                columna0Eur.ColumnName = "H" + n.ToString
                ColEur.Add(columna0Eur)

                Dim columna_0 As New DataColumn
                columna_0.DataType = Type.GetType("System.String")
                columna_0.DefaultValue = False
                columna_0.ColumnName = "D" + n.ToString
                columns1.Add(columna_0)
            Else
                Dim columna0 As New DataColumn
                columna0.DataType = Type.GetType("System.String")
                columna0.DefaultValue = False
                columna0.ColumnName = "NoMarca"
                columns.Add(columna0)

                Dim columna0Ame As New DataColumn
                columna0Ame.DataType = Type.GetType("System.String")
                columna0Ame.DefaultValue = False
                columna0Ame.ColumnName = "NoMarca"
                ColAmerica.Add(columna0Ame)

                Dim columna0Eur As New DataColumn
                columna0Eur.DataType = Type.GetType("System.String")
                columna0Eur.DefaultValue = False
                columna0Eur.ColumnName = "NoMarca"
                ColEur.Add(columna0Eur)

                Dim columna_0 As New DataColumn
                columna_0.DataType = Type.GetType("System.String")
                columna_0.DefaultValue = False
                columna_0.ColumnName = "NoMarca"
                columns1.Add(columna_0)
            End If
            n += 1
        Next

        Dim columna1 As New DataColumn
        columna1.DataType = Type.GetType("System.String")
        columna1.DefaultValue = False
        columna1.ColumnName = "NUMERACION"
        columns.Add(columna1)

        Dim columna1Ame As New DataColumn
        columna1Ame.DataType = Type.GetType("System.String")
        columna1Ame.DefaultValue = False
        columna1Ame.ColumnName = "NUMERACION"
        ColAmerica.Add(columna1Ame)

        Dim columna1Eur As New DataColumn
        columna1Eur.DataType = Type.GetType("System.String")
        columna1Eur.DefaultValue = False
        columna1Eur.ColumnName = "NUMERACION"
        ColEur.Add(columna1Eur)


        For Each ROW As DataRow In dtMarcas.Rows
            For i = 1 To 3 Step 1
                If i = 3 Then
                    ''Agrega la corrida europea a la tabla de corridas
                    Dim FilaEur As DataRow = dtHeadersEur.NewRow
                    dtHeadersEur.Rows.InsertAt(FilaEur, 0)

                    For cont As Integer = 0 To dtListaSoloPrecio.Columns.Count Step 1
                        If cont = dtListaSoloPrecio.Columns.Count Then
                            dtHeadersEur.Rows(0).Item(cont) = "EURO"
                        Else
                            If dtListaSoloPrecio.Columns(cont).Caption = "Marca" Then
                                dtHeadersEur.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "Colección" Then
                                dtHeadersEur.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "ModelosSICY" Then
                                dtHeadersEur.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "Modelos" Then
                                dtHeadersEur.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "NoMarca" Then
                                dtHeadersEur.Rows(0).Item(cont) = ROW.Item("NoMarca")
                            Else
                                Dim NumEuro As String
                                NumEuro = RecuperarModelajeUSA_EURO(dtListaSoloPrecio.Columns(cont).Caption, 17)
                                dtHeadersEur.Rows(0).Item(cont) = NumEuro
                            End If
                        End If
                    Next
                ElseIf i = 2 Then
                    ''AGREGA LAS CORRIDAS AMERICANAS A LA TABLA DE CORRIDAS
                    Dim FilaAme As DataRow = dtHeadersAme.NewRow
                    dtHeadersAme.Rows.InsertAt(FilaAme, 0)

                    For cont As Integer = 0 To dtListaSoloPrecio.Columns.Count Step 1
                        If cont = dtListaSoloPrecio.Columns.Count Then
                            dtHeadersAme.Rows(0).Item(cont) = "USA"
                        Else
                            If dtListaSoloPrecio.Columns(cont).Caption = "Marca" Then
                                dtHeadersAme.Rows(0).Item(cont) = "Marca"
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "Colección" Then
                                dtHeadersAme.Rows(0).Item(cont) = "Colección"
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "ModelosSICY" Then
                                dtHeadersAme.Rows(0).Item(cont) = "Modelo"
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "Modelos" Then
                                dtHeadersAme.Rows(0).Item(cont) = "Modelo"
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "NoMarca" Then
                                dtHeadersAme.Rows(0).Item(cont) = ROW.Item("NoMarca")
                            Else
                                Dim NumUsa As String
                                NumUsa = RecuperarModelajeUSA_EURO(dtListaSoloPrecio.Columns(cont).Caption, 4)
                                dtHeadersAme.Rows(0).Item(cont) = NumUsa
                            End If
                        End If
                    Next
                Else

                    'AGREGA LA CORRIDA MEXICANA A LA TABLA DE CABECERAS
                    Dim Fila As DataRow = dtHeaders.NewRow
                    dtHeaders.Rows.InsertAt(Fila, 0)

                    For cont As Integer = 0 To dtListaSoloPrecio.Columns.Count Step 1
                        If cont = dtListaSoloPrecio.Columns.Count Then
                            dtHeaders.Rows(0).Item(cont) = "MEX"
                        Else
                            If dtListaSoloPrecio.Columns(cont).Caption = "Marca" Then
                                dtHeaders.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "Colección" Then
                                dtHeaders.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "ModelosSICY" Then
                                dtHeaders.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "Modelos" Then
                                dtHeaders.Rows(0).Item(cont) = ""
                            ElseIf dtListaSoloPrecio.Columns(cont).Caption = "NoMarca" Then
                                dtHeaders.Rows(0).Item(cont) = ROW.Item("NoMarca")
                            Else
                                dtHeaders.Rows(0).Item(cont) = dtListaSoloPrecio.Columns(cont).Caption
                            End If
                        End If
                    Next
                End If
            Next
        Next

        For cont = 0 To dtListaSoloPrecio.Rows.Count - 1
            Dim Fila As DataRow = dtListaPrecio.NewRow
            For cont1 = 1 To dtListaSoloPrecio.Columns.Count Step 1
                If cont1 < dtListaSoloPrecio.Columns.Count Then
                    Fila("D" + cont1.ToString) = dtListaSoloPrecio.Rows(cont).Item(cont1 - 1)
                Else
                    Fila("NoMarca") = dtListaSoloPrecio.Rows(cont).Item(cont1 - 1)
                End If

            Next
            dtListaPrecio.Rows.InsertAt(Fila, 0)
        Next

        'If dtListaSoloPrecio.Columns(1).Caption = "GRUPFAM" And dtListaSoloPrecio.Columns(2).Caption = "cole_descripcion" Then
        '    dtListaPrecio.TableName = "dt3-" + (ColumnasEncontradas - 5).ToString
        '    dtHeaders.TableName = "dth3-" + (ColumnasEncontradas - 5).ToString
        'ElseIf dtListaSoloPrecio.Columns(1).Caption = "GRUPFAM" Or dtListaSoloPrecio.Columns(1).Caption = "cole_descripcion" Then
        '    dtListaPrecio.TableName = "dt2-" + (ColumnasEncontradas - 4).ToString
        '    dtHeaders.TableName = "dth2-" + (ColumnasEncontradas - 4).ToString
        'Else
        '    dtListaPrecio.TableName = "dt1-" + (ColumnasEncontradas - 3).ToString
        '    dtHeaders.TableName = "dth1-" + (ColumnasEncontradas - 3).ToString
        'End If

        dtListaPrecio.TableName = "dt2-" + (ColumnasEncontradas - 4).ToString
        dtHeadersAme.TableName = "dth2-" + (ColumnasEncontradas - 4).ToString + "Ame"
        dtHeadersEur.TableName = "dth2-" + (ColumnasEncontradas - 4).ToString + "EUR"
        dtHeaders.TableName = "dth2-" + (ColumnasEncontradas - 4).ToString
        dtMarcas.TableName = "dtMarcas2-" + (ColumnasEncontradas - 4).ToString

        dsResultado.Tables.Add(dtListaPrecio)
        dsResultado.Tables.Add(dtHeaders)
        dsResultado.Tables.Add(dtHeadersAme)
        dsResultado.Tables.Add(dtHeadersEur)
        dsResultado.Tables.Add(dtMarcas)

        Return dsResultado
    End Function

#End Region

#Region "PDF"
    Private Sub btnGenerarReportePDF_Click(sender As Object, e As EventArgs) Handles btnGenerarReportePDF.Click
        If grdReporte.Rows.Count > 0 Then
            exportarPDF()
        Else
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.mensaje = "No hay registros que exportar"
            objAdvertencia.ShowDialog()

        End If
    End Sub

    Public Sub exportarPDF()

        Dim sfd As New SaveFileDialog
        Dim ugde As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter()
        sfd.DefaultExt = "pdf"
        sfd.Filter = "PDF files (*.pdf)|*.pdf"
        Dim result As DialogResult = sfd.ShowDialog()
        '----------------------------------------------------------------------------------
        If result = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Dim fileName As String = sfd.FileName
            ugde.AutoSize = Infragistics.Win.UltraWinGrid.DocumentExport.AutoSize.SizeColumnsToContent
            ugde.TargetPaperOrientation = PageOrientation.Portrait
            ugde.TargetPaperSize = PageSizes.A4
            Dim r As Report = New Report()

            Dim sec As ISection = r.AddSection()
            Dim img As Infragistics.Documents.Reports.Graphics.Image = New Infragistics.Documents.Reports.Graphics.Image(Global.Ventas.Vista.My.Resources.Resources.GRUPOYUYIN)

            Dim sectionHeader As Infragistics.Documents.Reports.Report.Section.ISectionHeader = sec.AddHeader()
            sectionHeader.Repeat = True
            sectionHeader.Height = 100

            Dim sectionHeaderImg As Infragistics.Documents.Reports.Report.IImage = sectionHeader.AddImage(img, 0, 0)
            sectionHeaderImg.Paddings.All = 10

            If rdoListadePrecios.Checked = True Then
                Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 20)
                sectionHeaderText.Paddings.Top = 10
                sectionHeaderText.Alignment = New TextAlignment(Alignment.Justify)
                sectionHeaderText.Style.Font.Bold = True
                sectionHeaderText.AddContent("                          Listas de Precios                       Impresión: " + DateTime.Now.ToString("G"))
            ElseIf rdoListaPrecioSugerida.Checked = True Then
                Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 20)
                sectionHeaderText.Paddings.Top = 10
                sectionHeaderText.Alignment = New TextAlignment(Alignment.Justify)
                sectionHeaderText.Style.Font.Bold = True
                sectionHeaderText.AddContent("                      Listas de Precios Sugerida                  Impresión: " + DateTime.Now.ToString("G"))
            ElseIf RdoSimulador.Checked = True Then
                Dim sectionHeaderText As Infragistics.Documents.Reports.Report.Text.IText = sectionHeader.AddText(350, 20)
                sectionHeaderText.Paddings.Top = 10
                sectionHeaderText.Alignment = New TextAlignment(Alignment.Justify)
                sectionHeaderText.Style.Font.Bold = True
                sectionHeaderText.AddContent("                     Simulador de Lista de Precios                   Impresión: " + DateTime.Now.ToString("G"))
            End If


            Dim sectionFooter As Infragistics.Documents.Reports.Report.Section.ISectionFooter = sec.AddFooter()
            sectionFooter.Repeat = True
            sectionFooter.Height = 60

            Dim NombreArchivo() As String
            Dim archivo As String
            NombreArchivo = sfd.FileName.Split("\")

            For Each item In NombreArchivo
                If item.Contains(".pd") Then
                    archivo = item
                End If
            Next
            Dim sectionFooterText As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooterText.Alignment = New TextAlignment(Alignment.Left)
            sectionFooterText.AddContent(archivo)

            Dim sectionFooter2Text As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooter2Text.Alignment = New TextAlignment(Alignment.Center)
            sectionFooter2Text.AddContent("Página: ")
            sectionFooter2Text.AddPageNumber(PageNumberFormat.Decimal)

            Dim sectionFooter3Text As Infragistics.Documents.Reports.Report.Text.IText = sectionFooter.AddText(0, 0)
            sectionFooter3Text.Alignment = New TextAlignment(Alignment.Right)
            sectionFooter3Text.AddContent(Entidades.SesionUsuario.UsuarioSesion.PUserUsername)

            'ultExportGrid.Export(grdReporte, fileName)
            ugde.Export(grdReporte, sec)

            Me.Cursor = Cursors.Default
            Try
                Dim objExito As New Tools.ExitoForm
                objExito.mensaje = "El archivo se exportó correctamente en la ubicación: " + sfd.FileName
                objExito.StartPosition = FormStartPosition.CenterScreen
                r.Publish(fileName, FileFormat.PDF)

                objExito.ShowDialog()
                Process.Start(fileName)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                Dim objError As New Tools.ErroresForm
                objError.mensaje = "El documento no pudo exportarse." + vbLf + ex.Message
                objError.StartPosition = FormStartPosition.CenterScreen
                objError.ShowDialog()
            End Try
        End If
        '----------------------------------------------------------------------------------
    End Sub

#End Region

#End Region

    Public Sub limpiarCampos()
        cmbClientes.SelectedIndex = -1
        cmbListaBase.SelectedIndex = -1
        cmbListaVentas.SelectedIndex = -1

        ''VARIABLES
        IdCliente = 0
        IdListaPrecioBase = 0
        idListaPrecioVenta = 0
        IdListaPrecioCliente = 0

        ''GBOX LISTA VENTAS
        lblIncrementoXPar_Dato.Text = ""
        lblDescuento_Dato.Text = ""
        lblFactuacion_Dato.Text = ""
        lblIVA_Dato.Text = ""
        lblFlete_Dato.Text = ""

        ''LISTA PRECIO(LISTA CLIENTE)
        lblFechaInicioLista_Dato.Text = ""
        lblFechaFinListaDato.Text = ""
        lblINCOTERM_DATO.Text = ""
        lblMoneda_Dato.Text = ""
        lblParidad_Dato.Text = ""


        ''GRID
        grdReporte.DataSource = Nothing


        ''CALCULAR PRECIOS CON DESCUENTO APLICADO
        chkDescuentoAplicado.Checked = False

        ''CON ATENCION
        txtAtn.Text = ""

        ''MENSAJE DE ALERTA DE LISTA DE VENTAS ASIGNADA
        lblMensajeSinListaVentas.Visible = False

        ''FILTROS
        grdAgentes.DataSource = Nothing
        chkSeleccionarTodo.Checked = False
        cmbMoneda.DataSource = Nothing
        gboxParidad.Visible = False
        rdoTodosLosModelos.Checked = True
        dttFechaInicio.Value = Today
        dttFechaFin.Value = Today

        chkColecciones.Checked = False
        chkFamilias.Checked = False

        'REPORTES
        numPrecioIncrementoParActual.Value = 0
        rdoPrecioPorcentajeActual.Checked = True
        rdoListadePrecios.Checked = True
    End Sub

    Public Sub limpiarCamposTextos()

        ''VARIABLES
        IdCliente = 0
        IdListaPrecioBase = 0
        idListaPrecioVenta = 0
        IdListaPrecioCliente = 0

        ''GBOX LISTA VENTAS
        lblIncrementoXPar_Dato.Text = ""
        lblDescuento_Dato.Text = ""
        lblFactuacion_Dato.Text = ""
        lblIVA_Dato.Text = ""
        lblFlete_Dato.Text = ""

        ''LISTA PRECIO(LISTA CLIENTE)
        lblFechaInicioLista_Dato.Text = ""
        lblFechaFinListaDato.Text = ""
        lblINCOTERM_DATO.Text = ""
        lblMoneda_Dato.Text = ""
        lblParidad_Dato.Text = ""


        ''GRID
        grdReporte.DataSource = Nothing


        ''CALCULAR PRECIOS CON DESCUENTO APLICADO
        chkDescuentoAplicado.Checked = False

        ''CON ATENCION
        txtAtn.Text = ""

        ''MENSAJE DE ALERTA DE LISTA DE VENTAS ASIGNADA
        lblMensajeSinListaVentas.Visible = False

        ''FILTROS
        grdAgentes.DataSource = Nothing
        chkSeleccionarTodo.Checked = False
        cmbMoneda.DataSource = Nothing
        gboxParidad.Visible = False
        rdoTodosLosModelos.Checked = True
        dttFechaInicio.Value = Today
        dttFechaFin.Value = Today

        chkColecciones.Checked = False
        chkFamilias.Checked = False

        'REPORTES
        numPrecioIncrementoParActual.Value = 0
        rdoPrecioPorcentajeActual.Checked = True
        rdoListadePrecios.Checked = True
    End Sub

    Private Function Recuperar_Paridad_Moneda(ByVal IdMonneda As Integer) As DataTable
        Dim objBUPrecio As New Negocios.PrecioBU
        Recuperar_Paridad_Moneda = objBUPrecio.Recuperar_Paridad_Moneda(IdMonneda)
        Return Recuperar_Paridad_Moneda
    End Function

#Region "HISTORICO"
    Private Sub btnHistorico_Click(sender As Object, e As EventArgs) Handles btnHistorico.Click
        If cmbClientes.SelectedIndex <= 0 Then
            Dim objAdvertencia As New Tools.AdvertenciaForm
            objAdvertencia.Tamaño_Letra = 16
            objAdvertencia.mensaje = "Debes seleccionar un cliente para consultar su histórico."
            objAdvertencia.StartPosition = FormStartPosition.CenterScreen
            objAdvertencia.ShowDialog()
            Return
        End If

        Dim objHistoricoPorProducto As New HistorialPrecioArticulo
        objHistoricoPorProducto.Text = "Historial de precios por cliente - Lista de Precios del Cliente"
        objHistoricoPorProducto.lblTitulo.Text = "Historial de precios por cliente - Lista de Precios del Cliente"
        objHistoricoPorProducto.StartPosition = FormStartPosition.CenterScreen

        objHistoricoPorProducto.Historial_Precio_Articulo = False
        objHistoricoPorProducto.NombreCliente = cmbClientes.Text
        objHistoricoPorProducto.IdCliente = cmbClientes.SelectedValue

        objHistoricoPorProducto.ShowDialog()
    End Sub


#End Region


#Region "RADIOBUTONS PARA ATRIBUTOS DE LOS REPORTES"
    Private Sub rdoTodosLosModelos_CheckedChanged(sender As Object, e As EventArgs) Handles rdoTodosLosModelos.CheckedChanged
        dttFechaInicio.Enabled = False
        dttFechaFin.Enabled = False
    End Sub

    Private Sub rdoModelosPedido_CheckedChanged(sender As Object, e As EventArgs) Handles rdoModelosPedido.CheckedChanged
        dttFechaInicio.Enabled = True
        dttFechaFin.Enabled = True
    End Sub

    Private Sub rdoListadePrecios_CheckedChanged(sender As Object, e As EventArgs) Handles rdoListadePrecios.CheckedChanged
        chkSeleccionarTodo.Checked = False
        If rdoListadePrecios.Checked = True Then
            chkColecciones.Enabled = True
            chkFamilias.Enabled = True

            cmbRamos.Enabled = False
            rdoPrecioPorcentajeActual.Enabled = False
            rdoPrecioPesosActual.Enabled = False
            numPrecioIncrementoParActual.Enabled = False
            btnImprimir.Enabled = True
            lblImprimir.Enabled = True
            txtAtn.Enabled = True
            txtClaveSAT.Enabled = False
            btnGenerarReportePDF.Enabled = True
            lblExportarPDF.Enabled = True

            recuperarValoresDeListaVentaClientePrecio(cmbListaVentasCliente.SelectedValue)
            PoblarGridAgentes(IdCliente, cmbListaVentasCliente.SelectedValue)

        End If
    End Sub

    Private Sub rdoModelaje_CheckedChanged(sender As Object, e As EventArgs) Handles rdoModelaje.CheckedChanged
        chkSeleccionarTodo.Checked = False
        If rdoModelaje.Checked = True Then
            chkColecciones.Enabled = False
            chkFamilias.Enabled = False
            cmbRamos.Enabled = False
            rdoPrecioPorcentajeActual.Enabled = False
            rdoPrecioPesosActual.Enabled = False
            numPrecioIncrementoParActual.Enabled = False
            btnImprimir.Enabled = True
            lblImprimir.Enabled = True
            txtAtn.Enabled = False
            txtClaveSAT.Enabled = False
            btnGenerarReportePDF.Enabled = True
            lblExportarPDF.Enabled = True

            recuperarValoresDeListaVentaClientePrecio(cmbListaVentasCliente.SelectedValue)
            PoblarGridAgentes(IdCliente, cmbListaVentasCliente.SelectedValue)

        End If
    End Sub

    Private Sub rdoListaPrecioSugerida_CheckedChanged(sender As Object, e As EventArgs) Handles rdoListaPrecioSugerida.CheckedChanged
        If rdoListaPrecioSugerida.Checked = True Then
            chkColecciones.Enabled = True
            chkFamilias.Enabled = True
            cmbRamos.Enabled = True
            rdoPrecioPorcentajeActual.Enabled = False
            rdoPrecioPesosActual.Enabled = False
            numPrecioIncrementoParActual.Enabled = False
            btnImprimir.Enabled = False
            lblImprimir.Enabled = False
        End If
    End Sub

    Private Sub RdoSimulador_CheckedChanged(sender As Object, e As EventArgs) Handles RdoSimulador.CheckedChanged
        chkSeleccionarTodo.Checked = False
        If RdoSimulador.Checked = True Then
            chkColecciones.Enabled = False
            chkFamilias.Enabled = False
            cmbRamos.Enabled = False
            rdoPrecioPorcentajeActual.Enabled = True
            rdoPrecioPesosActual.Enabled = True
            numPrecioIncrementoParActual.Enabled = True
            btnImprimir.Enabled = True
            lblImprimir.Enabled = True
            txtAtn.Enabled = True
            txtClaveSAT.Enabled = False
            btnGenerarReportePDF.Enabled = True
            lblExportarPDF.Enabled = True

            recuperarValoresDeListaVentaClientePrecio(cmbListaVentasCliente.SelectedValue)
            PoblarGridAgentes(IdCliente, cmbListaVentasCliente.SelectedValue)
            If lblIncrementoXPar_Dato.Text.Trim <> "" Then
                numPrecioIncrementoParActual.Value = ((lblIncrementoXPar_Dato.Text).Replace(" %", "")).Replace(" $", "")
            Else
                numPrecioIncrementoParActual.Value = 0
            End If
        End If
    End Sub

    Private Sub rdoPrecioPorcentajeActual_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPrecioPorcentajeActual.CheckedChanged
        numPrecioIncrementoParActual.Maximum = 100
    End Sub

    Private Sub rdoPrecioPesosActual_CheckedChanged(sender As Object, e As EventArgs) Handles rdoPrecioPesosActual.CheckedChanged
        numPrecioIncrementoParActual.Maximum = 1000
    End Sub

#End Region


    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Me.Cursor = Cursors.WaitCursor
        If cmbClientes.SelectedIndex > 0 Then
            If rdoListadePrecios.Checked = True Or RdoSimulador.Checked = True Then
                If txtAtn.Text = "" Then
                    Dim objadvertencia As New AdvertenciaForm
                    objadvertencia.mensaje = "Captura el nombre de la persona a quien va dirigida la lista en el campo 'AT´N'"
                    objadvertencia.StartPosition = FormStartPosition.CenterScreen
                    objadvertencia.ShowDialog()
                Else
                    ImprimirReporteStimulsoft(dtListaPrecioST, cmbListaVentas.SelectedValue, cmbClientes.SelectedValue, lblFechaInicioLista_Dato.Text, txtAtn.Text, CodigoLVCP)
                End If
            ElseIf rdoModelaje.Checked = True Then
                If cmbClientes.SelectedIndex <= 0 Then
                    Dim objAdvertencia As New Tools.AdvertenciaForm
                    objAdvertencia.mensaje = "Selecciona un cliente antes de consultar la confirmación de modelaje."
                    objAdvertencia.ShowDialog()
                ElseIf LTrim(RTrim(txtAtn.Text)) = "" Then
                    Dim objAdvertencia As New Tools.AdvertenciaForm
                    objAdvertencia.mensaje = "Selecciona un cliente antes de consultar la confirmación de modelaje."
                    objAdvertencia.ShowDialog()
                Else
                    Dim Marcas As String = String.Empty
                    Dim agentes As String = String.Empty
                    Dim idsMarcas As String = String.Empty

                    For Each row As UltraGridRow In grdAgentes.Rows
                        If row.Cells(" ").Value = True Then
                            If Marcas = "" Then
                                Marcas = "'" + row.Cells("Marca").Value + "'"
                            Else
                                Marcas = Marcas + ",'" + row.Cells("Marca").Value + "'"
                            End If

                            If agentes = "" Then
                                agentes = row.Cells("cmfa_colaboradorid_agente").Value.ToString
                            Else
                                agentes = agentes + ", " + row.Cells("cmfa_colaboradorid_agente").Value
                            End If

                            If idsMarcas = "" Then
                                idsMarcas = row.Cells("marc_marcaid").Value.ToString
                            Else
                                idsMarcas = idsMarcas + ", " + row.Cells("marc_marcaid").Value.ToString
                            End If

                        End If
                    Next

                    Dim objExportar As New ExportarAExcelForm
                    objExportar.Text = "Lista de precios para la confirmación de modelaje"
                    objExportar.lblTitulo.Text = "Lista de precios para la confirmación de modelaje"
                    objExportar.IdCliente = cmbClientes.SelectedValue
                    objExportar.NombreCliente = cmbClientes.Text
                    objExportar.Marcas = Marcas
                    objExportar.agentes = agentes
                    objExportar.idsMarcas = idsMarcas
                    'objExportar.IdPais = cmbNumeracion.SelectedValue
                    objExportar.IdListaPrecioBase = cmbListaBase.SelectedValue
                    objExportar.IdListaVentasClientePrecio = cmbListaVentasCliente.SelectedValue
                    objExportar.IdMoneda = cmbMoneda.SelectedValue
                    'objExportar.IdPaisMoneda = cmbNumeracion.SelectedValue
                    objExportar.ListaCompleta_O_Pedidos = rdoTodosLosModelos.Checked
                    objExportar.FechaInicioPedido = dttFechaInicio.Value
                    objExportar.FechaFinPedido = dttFechaFin.Value
                    objExportar.Paridad = Paridad

                    objExportar.ShowDialog()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbClientes.SelectedIndex = 0


    End Sub

    Private Sub recuperarValoresDeListaVentaClientePrecio(ByVal IdListaPrecioVentaCliente As Integer)
        Dim objListaBU As New Negocios.ListaPreciosVentaClienteBU
        Dim dtLista As New DataTable
        Dim FechaInicio As Date
        Dim FechaFin As Date

        dtLista = objListaBU.recuperarValoresDeListaVentaClientePrecio(IdListaPrecioVentaCliente)

        CodigoLVCP = ""
        If dtLista.Rows.Count = 0 Then Return

        CodigoLVCP = dtLista.Rows(0).Item("NT_LISTAPRECIO")

        If dtLista.Rows(0).Item("lvpc_porcentaje") = True Then
            lblIncrementoXPar_Dato.Text = CStr(dtLista.Rows(0).Item("lvcp_incrementoporpar")) + " %"
        Else
            lblIncrementoXPar_Dato.Text = CStr(dtLista.Rows(0).Item("lvcp_incrementoporpar")) + " $"
        End If

        lblDescuento_Dato.Text = CStr(dtLista.Rows(0).Item("lvcp_descuento")) + " %"
        lblFactuacion_Dato.Text = CStr(dtLista.Rows(0).Item("lvcp_facturacion")) + " %"
        lblIVA_Dato.Text = dtLista.Rows(0).Item("tiva_nombre")
        lblFlete_Dato.Text = dtLista.Rows(0).Item("tifl_nombre")


        FechaInicio = dtLista.Rows(0).Item("lvcp_vigenciainicio")
        FechaFin = dtLista.Rows(0).Item("lvcp_vigenciafin")

        lblFechaInicioLista_Dato.Text = FechaInicio.ToShortDateString
        lblFechaFinListaDato.Text = FechaFin.ToShortDateString
        lblINCOTERM_DATO.Text = dtLista.Rows(0).Item("INCOTERM")
        lblMoneda_Dato.Text = dtLista.Rows(0).Item("mone_nombre")
        lblParidad_Dato.Text = CStr(dtLista.Rows(0).Item("PARIDAD"))

    End Sub



    'Private Sub btnCargarPreciosSeleccionados_Click(sender As Object, e As EventArgs)

    '    If (grdDatosProductos.DataSource Is Nothing) Then
    '        Dim objConfirm As New Tools.ConfirmarForm
    '        objConfirm.mensaje = "Se cargaran todos los modelos activos."
    '        objConfirm.ShowDialog()
    '        If (objConfirm.DialogResult = DialogResult.OK) Then
    '            grdDatosProductos.DataSource = Nothing
    '            endEdit = True
    '            'llenarListaDePrecios()
    '        End If
    '    ElseIf (grdDatosProductos IsNot Nothing) Then
    '        Dim objConfirm As New Tools.ConfirmarForm
    '        objConfirm.mensaje = "Se quitaran todos los modelos de la lista."
    '        objConfirm.ShowDialog()
    '        If (objConfirm.DialogResult = DialogResult.OK) Then
    '            endEdit = True
    '            grdDatosProductos.DataSource = Nothing
    '        End If
    '    End If
    'End Sub

    'Private Sub grdDatosProductos_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs)

    '    'Me.grdDatosProductos.DisplayLayout.Bands(0).Columns("seleccion").Header.ResetCheckBoxVisibility()

    '    Me.grdDatosProductos.DisplayLayout.Bands(0).Columns("seleccion").Header.ResetCaption()

    'End Sub


    Public Sub RecuperarInformacionLVCP_ImPrimirReporteExterno(ByVal IdCliente As Integer, ByVal IdListaVentas As Integer, ByVal FechaInicioLista As String,
                                                               ByVal Atn As String, ByVal Codigo_Paridad As String,
                                                               ByVal IdLista_Ventas_Cliente_Precio As Integer, ByVal Id_Monedas As Integer, ByVal ParidadCCIL As Double)
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim objClienteDatos As New Ventas.Negocios.ClientesDatosBU
        Dim dtImprimirReporteExterno As New DataTable
        Dim DTAgentes As New DataTable
        Dim CadenaAgentes As String = String.Empty
        Dim CadenaMarcas As String = String.Empty
        Dim idsMarcas As String = String.Empty

        Dim marcaConsAgente As Int32 = 0
        If IdCliente = 816 Then
            marcaConsAgente = 1
        Else
            marcaConsAgente = 7
        End If

        DTAgentes = objClienteDatos.AgenteClienteMarcasListaPrecios(IdCliente, IdLista_Ventas_Cliente_Precio, True, marcaConsAgente, IdListaPrecioBase)

        For Each row As DataRow In DTAgentes.Rows
            If DTAgentes.Rows.Count = 1 Then
                CadenaAgentes += CStr(row.Item("cmfa_colaboradorid_agente"))
                CadenaMarcas += "'" + row.Item("MARCA") + "'"
            Else
                If CadenaAgentes = "" Then
                    CadenaAgentes += CStr(row.Item("cmfa_colaboradorid_agente"))
                    CadenaMarcas += "'" + row.Item("MARCA") + "'"
                Else
                    CadenaAgentes += "," + CStr(row.Item("cmfa_colaboradorid_agente"))
                    CadenaMarcas += ",'" + row.Item("MARCA") + "'"
                End If

                If idsMarcas = "" Then
                    idsMarcas = LTrim(RTrim(row.Item("marc_marcaid").ToString))
                Else
                    idsMarcas = idsMarcas + ", " + LTrim(RTrim(row.Item("marc_marcaid").ToString))
                End If

            End If
        Next

        dtImprimirReporteExterno = objLCBU.consultaListaCliente(IdLista_Ventas_Cliente_Precio, IdCliente, CadenaAgentes, False,
                                                              True, False, Today.ToShortDateString, Today.ToShortDateString,
                                                              CadenaMarcas, Id_Monedas, ParidadCCIL, False, idsMarcas)

        ImprimirReporteStimulsoft(dtImprimirReporteExterno, IdListaVentas, IdCliente, FechaInicioLista, Atn, Codigo_Paridad)

    End Sub


    Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
        If cmbMoneda.SelectedIndex > 0 Then
            If cmbMoneda.SelectedValue > 1 Then
                Dim dtParidad As New DataTable
                dtParidad = Recuperar_Paridad_Moneda(cmbMoneda.SelectedValue)
                'rdoPrecioPesosActual.Text = dtParidad.Rows(0).Item("mone_simbolo") + " (" + LTrim(RTrim((dtParidad.Rows(0).Item("mone_nombre")))).ToUpper + ")"
                rdoPrecioPesosActual.Text = "Indice (" + LTrim(RTrim((dtParidad.Rows(0).Item("mone_nombre")))).ToUpper + ")"
            Else
                'rdoPrecioPesosActual.Text = "$ (PESOS)"
                rdoPrecioPesosActual.Text = "Indice (PESOS)"
            End If
        Else
            'rdoPrecioPesosActual.Text = "$ (PESOS)"
            rdoPrecioPesosActual.Text = "Indice (PESOS)"
        End If
    End Sub


    Private Sub btnFiltroCliente_Click(sender As Object, e As EventArgs) Handles btnFiltroCliente.Click
        Dim idCliente As Int32 = 0
        Dim objFiltroFrm As New frmFiltroClientes
        objFiltroFrm.accion = "REPORTE"
        objFiltroFrm.ShowDialog()
        idCliente = objFiltroFrm.idCliente
        cmbClientes.SelectedValue = idCliente
    End Sub

    Public Sub limpiarCamposCambioCliente()

    End Sub

    Private Sub RdoListaClaveSat_CheckedChanged(sender As Object, e As EventArgs) Handles RdoListaClaveSat.CheckedChanged
        chkSeleccionarTodo.Checked = False
        If RdoListaClaveSat.Checked = True Then
            chkColecciones.Enabled = False
            chkFamilias.Enabled = False
            cmbRamos.Enabled = False
            rdoPrecioPorcentajeActual.Enabled = False
            rdoPrecioPesosActual.Enabled = False
            numPrecioIncrementoParActual.Enabled = False
            btnImprimir.Enabled = False
            lblImprimir.Enabled = False
            btnGenerarReportePDF.Enabled = False
            lblExportarPDF.Enabled = False
            txtAtn.Enabled = False
            txtClaveSAT.Enabled = False


        End If
    End Sub

    Public Sub reporteListaClaveSAT()
        Dim cadenaAgentes As String = ""
        Dim Marcas As String = ""
        Dim idsMarcas As String = String.Empty
        Dim dtDatosReporte As New DataTable
        Dim objLCBU As New Negocios.ListaPreciosVentaClienteBU
        Dim claveGeneral As Boolean = True

        For Each row As UltraGridRow In grdAgentes.Rows
            If row.Cells(" ").Value = True Then
                cadenaAgentes += row.Cells("cmfa_colaboradorid_agente").Value.ToString + ", "
                If Marcas = "" Then
                    Marcas = "'" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                Else
                    Marcas = Marcas + ", '" + LTrim(RTrim(row.Cells("Marca").Value.ToString)) + "'"
                End If

                If idsMarcas = "" Then
                    idsMarcas = LTrim(RTrim(row.Cells("marc_marcaid").Value.ToString))
                Else
                    idsMarcas = idsMarcas + ", " + LTrim(RTrim(row.Cells("marc_marcaid").Value.ToString))
                End If

            End If
        Next

        cadenaAgentes += "0"
        Dim objAdvertencia As New AdvertenciaForm
        objAdvertencia.StartPosition = FormStartPosition.CenterScreen
        If cadenaAgentes = "0" Then
            objAdvertencia.mensaje = "Selecciona al menos una marca para poder consultar la Lista de Claves SAT."
            objAdvertencia.ShowDialog()
        Else
            If txtClaveSAT.Text = "DETALLADA" Then
                claveGeneral = False
            End If

            If cmbClientes.SelectedIndex > 0 And cmbListaVentas.SelectedValue > 0 Then
                dtDatosReporte = objLCBU.consultaReporteClaveSAT(cmbListaVentasCliente.SelectedValue, idsMarcas, claveGeneral)

                If dtDatosReporte.Rows.Count > 0 Then

                    grdReporte.DataSource = dtDatosReporte

                End If
            End If

        End If

    End Sub
End Class