Imports System.IO
Imports System.Xml
Imports Entidades
Imports Infragistics.Win.UltraWinGrid
Imports Proveedores.BU

Public Class AgregarComprobanteMaquila
    Public fecha As New Date
    Public nave As Integer = 0
    Public nombreNave As String = ""
    Private datos As New DataTable
    Private datosNave As New DataTable
    Private remision As Double
    Private facturacion As Double
    Private tolerancia As Double
    Private Pesosremision As Double
    Private tmpPesosremision As Double
    Private Pesosfacturacion As Double
    Private tmpPesosfacturacion As Double
    Private subTotal As Double = 0
    Private totalRemisionado As Double = 0
    Private IVA As Double = 0
    Private totalFacturado As Double = 0
    Private totalDocumentos As Double = 0
    Private porDocumentar As Double = 0
    Private tmppares As Integer = 0
    Private pares As Integer = 0
    Private total As Double = 0
    Private paresf As Integer = 0
    Private totalf As Double = 0
    Private paresr As Integer = 0
    Private totalr As Double = 0
    Private ReadOnly tmptotal As Double = 0
    Private ReadOnly adv As New Tools.AdvertenciaForm
    Private ReadOnly exito As New Tools.ExitoForm
    Private paresRemison As Double = 0
    Private paresFactura As Double = 0
    Private paresCapturadosFac As Double = 0
    Private razonSocialEmisor As String
    Private rfcEmisor As String
    Private ReadOnly idConsecutivoRemsionMaquila As Integer
    Private idProveedor As Integer
    Private idNaveSICY As Integer
    Private consecutivoIdProveedor As DataTable
    Private ReadOnly comprobante As New Tools.AdvertenciaForm

    Private Sub BntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Close()
    End Sub

    Private Sub AgregarConprobanteMaquila_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCampos()
        LlenarGrid()
    End Sub

    Private Sub LlenarGrid()
        Dim table As New DataTable

        table.Columns.Add("Seleccionar", Type.GetType("System.Double"))
        table.Columns.Add("Tipo", Type.GetType("System.String"))
        table.Columns.Add("Folio", Type.GetType("System.String"))
        table.Columns.Add("RFC Emisor", Type.GetType("System.String"))
        table.Columns.Add("Razón social Emisor", Type.GetType("System.String"))
        table.Columns.Add("RFC Receptor", Type.GetType("System.String"))
        table.Columns.Add("Razón social Receptor", Type.GetType("System.String"))
        table.Columns.Add("Pares", Type.GetType("System.String"))
        table.Columns.Add("Subtotal", Type.GetType("System.Double"))
        table.Columns.Add("IVA", Type.GetType("System.Double"))
        table.Columns.Add("Total", Type.GetType("System.Double"))
        table.Columns.Add("UUID", Type.GetType("System.String"))
        table.Columns.Add("XML", Type.GetType("System.String"))
        table.Columns.Add("PDF", Type.GetType("System.String"))
        table.Columns.Add("FechaXML", Type.GetType("System.String"))
        table.Columns.Add("IdProv", Type.GetType("System.Int32"))
        table.Columns.Add("Consecutivo", Type.GetType("System.Int32"))

        grdComprobante.DataSource = table
        Diseño()
    End Sub

    Public Sub Diseño()
        Try
            With grdComprobante.DisplayLayout.Bands(0)
                .Columns("FechaXML").Hidden = True
                .Columns("IdProv").Hidden = True
                .Columns("Consecutivo").Hidden = True
                .Columns("Tipo").CellActivation = Activation.NoEdit
                .Columns("Folio").CellActivation = Activation.NoEdit
                .Columns("RFC Emisor").CellActivation = Activation.NoEdit
                .Columns("Razón social Emisor").CellActivation = Activation.NoEdit
                .Columns("RFC Receptor").CellActivation = Activation.NoEdit
                .Columns("Razón social Receptor").CellActivation = Activation.NoEdit
                .Columns("Pares").CellActivation = Activation.NoEdit
                .Columns("Subtotal").CellActivation = Activation.NoEdit
                .Columns("IVA").CellActivation = Activation.NoEdit
                .Columns("Total").CellActivation = Activation.NoEdit
                .Columns("UUID").CellActivation = Activation.NoEdit
                .Columns("XML").CellActivation = Activation.NoEdit
                .Columns("PDF").CellActivation = Activation.NoEdit
                .Columns("Seleccionar").Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Right
                .Columns("Total").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("Subtotal").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
                .Columns("IVA").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right

                .Columns("Seleccionar").CellActivation = Activation.AllowEdit
                .Columns("Seleccionar").Style = ColumnStyle.CheckBox
                .Columns("Seleccionar").Header.Caption = " "
                .Columns("Seleccionar").AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
                .Columns("Seleccionar").Width = 1
                .Columns("Tipo").Width = 70
                .Columns("XML").Width = 50
                .Columns("PDF").Width = 50
                .Columns("Tipo").Width = 80
                .Columns("UUID").Width = 200
                .Columns("Total").Format = "##,##0.00"
                .Columns("Subtotal").Format = "##,##0.00"
                .Columns("IVA").Format = "##,##0.00"
                .Columns("Pares").Format = "##,##0"
                .Columns("PDF").CellAppearance.ForeColor = Drawing.Color.RoyalBlue
                .Columns("XML").CellAppearance.ForeColor = Drawing.Color.RoyalBlue
                .Columns("PDF").CellAppearance.Cursor = Windows.Forms.Cursors.Hand
                .Columns("XML").CellAppearance.Cursor = Windows.Forms.Cursors.Hand

            End With
            grdComprobante.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            grdComprobante.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex
            grdComprobante.DisplayLayout.Bands(0).RowLayoutStyle = RowLayoutStyle.ColumnLayout
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarCampos()
        Dim obj As New ListaPreciosProdBU
        Dim obj2 As New AgregarComprobanteBU

        lblRazSoc.Text = obj.getRazSocReceptor(nave)
        lblFecha.Text = "Comprobantes correspondientes a entregas del " & fecha.ToString("dd-MMMM-yyyy")
        datos = obj.getProductoTerminadoMaquila(nave, fecha, fecha)
        datosNave = obj2.getFacturacionRemision(obj2.getNaveSIcy(nave))

        Contar()
    End Sub

    Private Sub Contar()
        For Each row As DataRow In datosNave.Rows
            remision = Convert.ToDouble(row("cpm_remision"))
            facturacion = Convert.ToDouble(row("cpm_factura"))
            tolerancia = Convert.ToDouble(row("cpm_tolerancia"))
            idNaveSICY = row("cpm_idNave")

        Next


        If datos.Rows.Count > 0 Then
            For Each row As DataRow In datos.Rows
                totalf += row("Total F")
                paresf += row("Pares F")

                totalr += row("Total D")
                paresr += row("Pares D")

            Next

            ''Asignar de manera diferente el valor de las variables:
            paresFactura = paresf
            Pesosfacturacion = Math.Round(totalf, 2)
            tmpPesosfacturacion = Math.Round(totalf, 2)
            total = Math.Round(totalf, 2) + Math.Round(totalr, 2)
            pares = paresf + paresr

            tmppares = paresf + paresr

            remision = Math.Round(paresr * 100 / pares, 0)
            facturacion = Math.Round(paresf * 100 / pares, 0)

            lblMontoSinIva.Text = "$ " & total.ToString("##,##0.00")
            lblTotalPares.Text = pares.ToString("##,##0")
            lblPorDocumentar.Text = total.ToString("##,##0.00")
            porDocumentar = total

            tmpPesosremision = Math.Round(totalr, 2)
            Pesosremision = Math.Round(totalr, 2)
            paresRemison = paresr

            'ASIGNAR VALORES A ETIQUTAS
            lblPorcF.Text = "" & facturacion & "%"
            lblPorcR.Text = "" & remision & "%"

            lblImpF.Text = "$ " & Pesosfacturacion.ToString("##,##0.00")
            lblImpR.Text = "$ " & Pesosremision.ToString("##,##0.00")

            lblParesF.Text = paresFactura.ToString("##,##0") & " Pares"
            lblParesR.Text = paresRemison.ToString("##,##0") & " Pares"

        Else
            adv.mensaje = "No existe producto ingresado para esta fecha."
            adv.ShowDialog()
            Close()
        End If

    End Sub

    Private Sub BtnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        GetDatosXML()
    End Sub

    Private Sub GetDatosXML()
        Dim obj As New AgregarComprobanteBU
        OpenFileDialog1.Filter = "xml files (*.xml)|*.xml"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        Dim folioXML As String = ""
        Dim serieXML As String = ""
        Dim totalXML As String = ""
        Dim subTotalXML As String = ""
        Dim rfcEmisorXML As String = ""
        Dim razonSocialEmisorXML As String = ""
        Dim rfcReceptorXML As String = ""
        Dim razonSocialReceptorXML As String = ""
        Dim paresXML As Integer = 0
        Dim IVAXML As String = ""
        Dim uuidXML As String = ""
        Dim fechaXML As String = ""
        Dim unidadxml As String = ""
        Dim Claveprodservxml As String = ""


        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If Path.GetExtension(OpenFileDialog1.FileName).ToUpper = ".XML" Then

                Dim reader As New XmlTextReader(OpenFileDialog1.FileName)
                Try
                    Do While (reader.Read())
                        'If reader.Name = "cfdi:Concepto" Then
                        '    If reader.HasAttributes Then
                        '        While reader.MoveToNextAttribute()
                        '            If reader.Name = "ClaveProdServ" Then
                        '                Claveprodservxml = reader.Value
                        '                If Claveprodservxml = "" Then
                        '                    Exit Do
                        '                End If
                        '            End If
                        '            If reader.Name = "ClaveUnidad" Then
                        '                unidadxml = reader.Value
                        '                If unidadxml <> "PR" Then
                        '                    Exit Do
                        '                Else

                        '                End If
                        '            End If

                        '        End While
                        '    End If
                        'End If

                        If reader.Name = "cfdi:Comprobante" Or reader.Name = "Comprobante" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name = "serie" Or reader.Name = "Serie" Then
                                        serieXML = reader.Value
                                    ElseIf reader.Name = "folio" Or reader.Name = "Folio" Then
                                        folioXML = reader.Value
                                    ElseIf reader.Name = "subTotal" Or reader.Name = "SubTotal" Then
                                        subTotalXML = reader.Value
                                    ElseIf reader.Name = "total" Or reader.Name = "Total" Then
                                        totalXML = reader.Value
                                    ElseIf reader.Name = "fecha" Or reader.Name = "Fecha" Then
                                        fechaXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Emisor" Or reader.Name = "Emisor" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name = "rfc" Or reader.Name = "Rfc" Then
                                        rfcEmisorXML = reader.Value
                                    ElseIf reader.Name = "nombre" Or reader.Name = "Nombre" Then
                                        razonSocialEmisorXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Receptor" Or reader.Name = "Receptor" Or reader.Name = "receptor" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name = "rfc" Or reader.Name = "Rfc" Then
                                        rfcReceptorXML = reader.Value
                                    ElseIf reader.Name = "nombre" Or reader.Name = "Nombre" Then
                                        razonSocialReceptorXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Traslado" Or reader.Name = "Traslado" Or reader.Name = "traslado" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name = "importe" Or reader.Name = "Importe" Then
                                        IVAXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "tfd:TimbreFiscalDigital" Or reader.Name = "TimbreFiscalDigital" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name = "UUID" Then
                                        uuidXML = reader.Value
                                    End If
                                End While
                            End If
                        End If
                        If reader.Name = "cfdi:Concepto" Or reader.Name = "Concepto" Or reader.Name = "Concepto" Then
                            If reader.HasAttributes Then
                                While reader.MoveToNextAttribute()
                                    If reader.Name = "cantidad" Or reader.Name = "Cantidad" Then
                                        paresXML += reader.Value
                                    ElseIf reader.Name = "ClaveProdServ" Then
                                        Claveprodservxml = reader.Value
                                        If Claveprodservxml = "" Then
                                            Exit Do
                                        End If
                                    ElseIf reader.Name = "ClaveUnidad" Then
                                        unidadxml = reader.Value
                                        If unidadxml <> "PR" Then
                                            Exit Do
                                        Else

                                        End If
                                    End If
                                End While
                            End If
                        End If

                    Loop
                Catch ex As Exception
                    comprobante.mensaje = "El archivo XML está dañado."
                    comprobante.ShowDialog()
                End Try

                If String.IsNullOrEmpty(Claveprodservxml) Then
                    Dim objMensajeAdv As New Tools.AdvertenciaForm With {
                    .mensaje = "Clave Producto está vacía."
                }
                    objMensajeAdv.ShowDialog()
                ElseIf unidadxml <> "PR" Then
                    Dim objMensajeAdv As New Tools.AdvertenciaForm With {
                    .mensaje = "Unidad es diferente de PR."
                }
                    objMensajeAdv.ShowDialog()

                Else
                    razonSocialEmisor = razonSocialEmisorXML
                    rfcEmisor = rfcEmisorXML
                    consecutivoIdProveedor = obj.consecutivoFolio(razonSocialEmisor, rfcEmisor)
                    Dim consecutivo As Integer = 0
                    If consecutivoIdProveedor.Rows.Count > 0 Then
                        idProveedor = consecutivoIdProveedor.Rows(0).Item("IdProveedor")
                        consecutivo = consecutivoIdProveedor.Rows(0).Item("consecutivoRemisionCompMaquila")
                    End If

                    AgregarXML(folioXML, serieXML, totalXML, subTotalXML, rfcEmisorXML, razonSocialEmisorXML,
                    rfcReceptorXML, razonSocialReceptorXML, paresXML, IVAXML, uuidXML, fechaXML, idProveedor, consecutivo)
                End If

            Else
                Dim objMensajeAdv As New Tools.AdvertenciaForm With {
                    .mensaje = "El archivo seleccionado no es un XML."
                }
                objMensajeAdv.ShowDialog()
            End If
        End If
    End Sub

    Private Sub AgregarXML(folioXML As String,
                           serieXML As String,
                           totalXML As String,
                           subTotalXML As String,
                           rfcEmisorXML As String,
                           razonSocialEmisorXML As String,
                           rfcReceptorXML As String,
                           razonSocialReceptorXML As String,
                           paresXML As Integer,
                           IVAXML As String,
                           uuidXML As String,
                           FechaXML As String,
                           idProv As Integer,
                           Consecutivo As Integer)

        Dim obj As New AgregarComprobanteBU
        If obj.verificarEmisor(obj.getNaveSIcy(nave), rfcEmisorXML) Then
            If Not obj.verificarUUID(uuidXML) Then
                Dim folioFinal = If(serieXML.Length > 0, serieXML & "-" & folioXML, folioXML)

                If VerificarFolio(folioFinal) Then
                    Dim r As DataTable = obj.verificarRazonSocialParaNave(obj.getNaveSIcy(nave), rfcReceptorXML)

                    If r.Rows.Count > 0 Then
                        If tmpPesosfacturacion <= 0.001 Or porDocumentar <= 0.001 Then
                            adv.mensaje = "Ya se subieron los comprobantes para el " & facturacion & "% facturado."
                            adv.ShowDialog()
                        Else
                            If subTotalXML = tmpPesosfacturacion Then
                                If paresXML = paresFactura Then

                                    subTotal += subTotalXML
                                    IVA += IVAXML
                                    totalFacturado += totalXML
                                    totalDocumentos += totalXML
                                    tmppares -= paresXML
                                    paresCapturadosFac += paresXML

                                    lblsubTotalFac.Text = "$ " & subTotal.ToString("##,##0.00")
                                    lblIVA.Text = "$ " & IVA.ToString("##,##0.00")
                                    lblTotalFac.Text = "$ " & totalFacturado.ToString("##,##0.00")
                                    lblTotalDocs.Text = "$ " & totalDocumentos.ToString("##,##0.00")

                                    Dim table As DataTable = grdComprobante.DataSource
                                    Dim datarow As DataRow = table.NewRow()
                                    datarow("Seleccionar") = 0
                                    datarow("Tipo") = "Factura"
                                    datarow("Folio") = folioFinal
                                    datarow("RFC Emisor") = rfcEmisorXML
                                    datarow("Razón social Emisor") = razonSocialEmisorXML
                                    datarow("RFC Receptor") = rfcReceptorXML
                                    datarow("Razón social Receptor") = razonSocialReceptorXML
                                    datarow("Pares") = paresXML
                                    datarow("Subtotal") = subTotalXML
                                    datarow("IVA") = IVAXML
                                    datarow("Total") = totalXML
                                    datarow("UUID") = uuidXML
                                    datarow("XML") = OpenFileDialog1.FileName
                                    datarow("PDF") = ""
                                    datarow("FechaXML") = FechaXML
                                    datarow("IdProv") = idProv
                                    datarow("Consecutivo") = Consecutivo

                                    table.Rows.Add(datarow)
                                    grdComprobante.DataSource = Nothing
                                    grdComprobante.DataSource = table
                                    Diseño()
                                    tmpPesosfacturacion -= subTotalXML
                                    porDocumentar -= subTotalXML
                                    lblPorDocumentar.Text = If(porDocumentar <= 0, "$ " & "0.00", "$ " & porDocumentar.ToString("##,##0.00"))
                                    VerificarGuardado()
                                Else
                                    adv.mensaje = "La factura tiene una diferencia de " + (paresXML - paresFactura).ToString("##,##0") + " pares."
                                    adv.ShowDialog()
                                End If
                            Else
                                adv.mensaje = "La factura tiene una diferencia de $" + (subTotalXML - tmpPesosfacturacion).ToString("#0.00") + "."
                                adv.ShowDialog()
                            End If
                        End If
                    Else
                        adv.mensaje = "No se configuró el receptor " & razonSocialReceptorXML & " para la maquila " & nombreNave & "."
                        adv.ShowDialog()
                    End If
                Else
                    adv.mensaje = "El folio ya existe en la tabla."
                    adv.ShowDialog()
                End If
            Else
                adv.mensaje = "Existe un registro con el UUID de la factura."
                adv.ShowDialog()
            End If
        Else
            adv.mensaje = "El proveedor " & razonSocialEmisorXML & " no está configurado para la maquila " & nombreNave
            adv.ShowDialog()
        End If
    End Sub

    Public Function VerificarFolio(folioFinal As String) As Boolean
        Dim table As DataTable = grdComprobante.DataSource
        For Each row As DataRow In table.Rows
            If row("Folio") = folioFinal Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub BtnRemision_Click(sender As Object, e As EventArgs) Handles btnRemision.Click
        Dim obj As New AgregarComprobanteBU
        Dim maquilaProveedores As DataTable
        Dim form As New CamposRemisionForm
        Dim fechaR As Date
        Dim rowSel As UltraGridRow

        If (tmpPesosfacturacion - tolerancia) <= 0.0 Or paresCapturadosFac = paresFactura Then
            If tmpPesosremision <= 0.001 Or porDocumentar <= 0.001 Then
                adv.mensaje = "Ya se subieron los comprobantes para el " & remision & "% de remisión."
                adv.ShowDialog()
            Else
                maquilaProveedores = obj.maquilaProveedores(idNaveSICY)
                form.proveedoresCamposRemision = maquilaProveedores
                If paresFactura <> 0 Then
                    rowSel = Nothing
                End If

                ''agregar monto y pares de remisión obtenidos
                form.monto = totalr
                form.pares = paresr

                form.ShowDialog()
                If form.cancelado = False Then
                    Dim monto As Double = Convert.ToDouble(form.txtMonto.Text)
                    Dim folio As String = form.txtFolio.Text
                    Dim paresPDF As String = form.txtPares.Text
                    fechaR = form.dtpFecha.Value

                    'If esVisible Then
                    idProveedor = If(form.cboxProveedores.SelectedValue > 0,
                        DirectCast(form.cboxProveedores.SelectedValue, Integer),
                        CInt(rowSel.Cells("IdProv").Value))

                    If (monto <= (porDocumentar + tolerancia)) Or paresPDF <= paresRemison Then
                        If (tmppares - paresPDF) < 0 Then
                            adv.mensaje = "La cantidad de pares faltantes son: " & tmppares
                            adv.ShowDialog()
                        Else
                            totalDocumentos += monto
                            tmppares -= paresPDF
                            lblTotalDocs.Text = "$ " & totalDocumentos.ToString("##,##0.00")

                            Dim table As DataTable = grdComprobante.DataSource
                            Dim datarow As DataRow = table.NewRow()
                            datarow("Seleccionar") = 0
                            datarow("Tipo") = "Remisión"
                            datarow("Folio") = folio
                            datarow("RFC Emisor") = rfcEmisor
                            datarow("Razón social Emisor") = ""
                            datarow("RFC Receptor") = ""
                            datarow("Razón social Receptor") = ""
                            datarow("Pares") = paresPDF
                            datarow("Subtotal") = monto
                            datarow("IVA") = 0
                            datarow("Total") = monto
                            datarow("UUID") = ""
                            datarow("XML") = ""
                            datarow("PDF") = ""
                            datarow("FechaXML") = fechaR
                            datarow("IdProv") = idProveedor
                            datarow("Consecutivo") = folio

                            table.Rows.Add(datarow)
                            grdComprobante.DataSource = Nothing
                            grdComprobante.DataSource = table
                            Diseño()
                            tmpPesosremision -= monto
                            porDocumentar -= monto
                            lblPorDocumentar.Text = If(porDocumentar <= 0, "$ " & "0.00", "$ " & porDocumentar.ToString("##,##0.00"))

                            totalRemisionado += monto
                            lblTotalRemisionado.Text = "$ " & totalRemisionado.ToString("##,##0.00")
                            VerificarGuardado()
                        End If
                    Else
                        adv.mensaje = "El monto sobrepasa con $" & (monto - porDocumentar).ToString("##,##0.00") & " la cantidad restante a remisionar."
                        adv.ShowDialog()
                    End If
                End If

            End If
        Else
            adv.mensaje = "No puede subir remisiones hasta que se haya completado el " & facturacion & "% de facturación"
            adv.ShowDialog()
        End If
    End Sub

    Public Function CopiarArchivos(ruta As String, nombreArchivo As String, ext As String) As String
        Try
            Dim rutaArchivos As String = SesionUsuario.ConfigRutas.PRutaComprobante_Maquilas
            Dim fecha As New Date
            fecha = Date.Today
            Dim fechaCarpeta As String = ConcatenarFecha(fecha)
            If Not Directory.Exists(rutaArchivos & nombreNave) Then
                Directory.CreateDirectory(rutaArchivos & nombreNave)
                If Not Directory.Exists(rutaArchivos & nombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutaArchivos & nombreNave & "\" & fechaCarpeta)
                    If ruta.Length > 0 Then
                        File.Copy(ruta, rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                End If
            Else
                If Not Directory.Exists(rutaArchivos & nombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutaArchivos & nombreNave & "\" & fechaCarpeta)
                Else
                    If ruta.Length > 0 Then
                        File.Copy(ruta, rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                    End If
                End If
            End If
            If ruta.Length > 0 Then
                Dim rutatmp As String = rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext
                Return rutatmp
            Else
                Return ""
            End If
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado al copiar el XML o PDF. Detalles: " & ex.Message
            adv.ShowDialog()
            Return ""
        End Try
    End Function

    Public Function ConcatenarFecha(fecha As Date)
        Dim cadena = If(fecha.Month < 10, "0" & fecha.Month & "" & fecha.Year, "" & fecha.Month & "" & fecha.Year)
        Return cadena
    End Function

    Private Sub VerificarGuardado()
        btnGuardar.Enabled = (tmpPesosfacturacion <= 0.001 Or porDocumentar <= 0.001) AndAlso (tmpPesosremision <= 0.001 Or porDocumentar <= 0.001) AndAlso tmppares = 0
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        Dim obj As New AgregarComprobanteBU
        Dim data As DataTable = grdComprobante.DataSource

        Dim idNaveSicy As Integer = obj.getNaveSIcy(nave)

        Dim form As New CamposRemisionForm

        Try
            For Each row As DataRow In data.Rows
                Dim datosPago As New DatosPago
                Dim m As New MaquilaComprobante With {
                    .tipo = If(row("Tipo") = "Factura", "F", "R"),
                    .folio = row("Folio"),
                    .proveedorid = row("IdProv")
                }

                Dim razonSoc As New DataTable
                razonSoc = obj.verificarRazonSocialParaNave(idNaveSicy, row("RFC Receptor"))
                If razonSoc.Rows.Count > 0 Then
                    m.receptorid = razonSoc.Rows(0).Item("IDRazSoc").ToString
                End If
                If m.proveedorid > 0 Then
                    Dim diasCredito As Integer = obj.getDiasCredito(m.proveedorid)
                    datosPago = GetFechaPago(Date.Now, diasCredito)
                    m.datosPagoCompra = datosPago
                End If
                m.pares = Convert.ToInt32(row("Pares"))
                m.subtotal = Convert.ToDouble(row("Subtotal"))
                m.iva = Convert.ToDouble(row("IVA"))
                m.total = Convert.ToDouble(row("Total"))
                m.uuid = row("UUID")
                m.rutaxml = CopiarArchivos(row("XML"), row("UUID"), "xml")
                m.rutapdf = CopiarArchivos(row("PDF"), row("Folio"), "pdf")
                m.usuariocreo = Entidades.SesionUsuario.UsuarioSesion.PUserUsername
                m.idNave = idNaveSicy
                m.fecha = fecha
                m.estatus = "C"
                Try
                    m.fechadocumento = Convert.ToDateTime(row("FechaXML"))
                Catch ex As Exception
                    m.fechadocumento = Date.Today
                End Try

                Dim idCom As DataTable = obj.insertComprobanteMaquila(m)

                If idCom.Rows.Count > 0 Then
                    m.idComprobante = Convert.ToInt32(idCom.Rows(0).Item(0).ToString)
                End If

                If datosPago.semanaPago > 0 Then
                    obj.updateComprobanteMaquila(m)
                End If

                If Not IsDBNull(m.proveedorid) Then
                    obj.ActualizaConsecutivoRemisionCompMaquila(m.proveedorid, row("Consecutivo"))
                End If

                If idCom.Rows.Count > 0 Then
                    obj.InsertaComprobanteDetalle(m)
                End If
            Next

            exito.mensaje = "Comprobantes registrados."
            exito.ShowDialog()
            Close()
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado. Detalles: " & ex.Message
            adv.ShowDialog()
        End Try
    End Sub

    Private Sub BtnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        QuitarRow()
    End Sub

    Public Sub QuitarRow()
        Try
            Dim rows As New DataTable
            rows = grdComprobante.DataSource
            For Each row As DataRow In rows.Rows
                If row("Seleccionar") Then
                    If row("Tipo") = "Factura" Then
                        subTotal -= row("Subtotal")
                        IVA -= row("IVA")
                        totalFacturado -= row("Total")
                        totalDocumentos -= row("Total")
                        tmppares += row("Pares")
                        paresCapturadosFac -= row("Pares")

                        lblsubTotalFac.Text = "$ " & subTotal.ToString("##,##0.00")
                        lblIVA.Text = "$ " & IVA.ToString("##,##0.00")
                        lblTotalFac.Text = "$ " & totalFacturado.ToString("##,##0.00")
                        lblTotalDocs.Text = "$ " & totalDocumentos.ToString("##,##0.00")
                        tmpPesosfacturacion += row("Subtotal")
                        porDocumentar += row("Subtotal")
                        lblPorDocumentar.Text = If(porDocumentar <= 0, "$ " & "0.00", "$ " & porDocumentar.ToString("##,##0.00"))
                        VerificarGuardado()
                        row.Delete()
                    ElseIf row("Tipo") = "Remisión" Then
                        totalDocumentos -= row("Total")
                        tmppares += row("Pares")
                        paresRemison -= row("Pares")
                        lblTotalDocs.Text = "$ " & totalDocumentos.ToString("##,##0.00")
                        tmpPesosremision += row("Total")
                        porDocumentar += row("Total")
                        lblPorDocumentar.Text = If(porDocumentar <= 0, "$ " & "0.00", "$ " & porDocumentar.ToString("##,##0.00"))
                        totalRemisionado -= row("Total")
                        lblTotalRemisionado.Text = "$ " & totalRemisionado.ToString("##,##0.00")
                        VerificarGuardado()
                        row.Delete()
                    End If
                End If
            Next
            grdComprobante.DataSource = rows
            Diseño()
        Catch ex As Exception
            QuitarRow()
        End Try
    End Sub

    Public Function ValidarSeleccionGrid() As Boolean
        Dim cont As Integer = 0
        For Each row As UltraGridRow In grdComprobante.Rows
            If row.Cells("Seleccionar").Value Then
                cont += 1
            End If
        Next

        Return cont = 1
    End Function

    Private Sub BtnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        If ValidarSeleccionGrid() Then
            Dim rows As New DataTable
            rows = grdComprobante.DataSource
            OpenFileDialog1.Filter = "pdf files (*.pdf)|*.pdf"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True
            If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                If Path.GetExtension(OpenFileDialog1.FileName).ToUpper = ".PDF" Then

                    For Each row As UltraGridRow In grdComprobante.Rows
                        If row.Cells("Seleccionar").Value Then
                            If row.Cells("Tipo").Value = "Factura" Then
                                If row.Cells("PDF").Value.ToString.Length > 0 Then
                                    Dim conf As New Tools.ConfirmarForm With {
                                        .mensaje = "Ya se agregó anteriormente un PDF, ¿Desea reemplazarlo?"
                                    }
                                    If conf.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                                        row.Cells("PDF").Value = OpenFileDialog1.FileName
                                        row.Cells("Seleccionar").Value = 0
                                        Return
                                    End If
                                    Return
                                Else
                                    row.Cells("PDF").Value = OpenFileDialog1.FileName
                                    row.Cells("Seleccionar").Value = 0
                                    Return
                                End If
                            End If
                            Return
                        End If
                    Next
                Else
                    Dim objMensajeAdv As New Tools.AdvertenciaForm With {
                        .mensaje = "El archivo seleccionado no es un PDF."
                    }
                    objMensajeAdv.ShowDialog()
                End If
            End If
        Else
            adv.mensaje = "Seleccione un registro para agregar el PDF."
            adv.ShowDialog()
        End If
    End Sub

    Private Sub GrdComprobante_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles grdComprobante.DoubleClickCell
        If grdComprobante.ActiveRow.Index > -1 Then
            Try
                If grdComprobante.ActiveCell.Column.ToString = "PDF" Or grdComprobante.ActiveCell.Column.ToString = "XML" Then
                    If grdComprobante.ActiveCell.Value.ToString.Length > 0 Then
                        Process.Start(grdComprobante.ActiveCell.Value.ToString)
                    End If
                End If
            Catch ex As Exception
                adv.mensaje = "No se puede localizar el archivo."
                adv.ShowDialog()
            End Try
        End If
    End Sub

    Public Function GetFechaPago(fInicio As Date, DiasCredito As Integer) As DatosPago
        Dim datosPago As New DatosPago
        Dim obj As New AgregarComprobanteBU
        Dim fFin As Date = fInicio.AddDays(DiasCredito)
        Dim datosCompra As DataTable

        Dim datosFechaPago As DataTable
        If obj.validarSiExistenDiasInhabiles(fInicio, fFin).Rows.Count > 5 Then 'Existen Dias no laborables
            fFin = GetFechaMasDiasInhabiles(fInicio, fFin)
            datosFechaPago = obj.getSemana(fFin)
            datosCompra = obj.getSemana(fInicio)
            If datosFechaPago.Rows.Count > 0 Then
                datosPago.añoPago = datosFechaPago.Rows(0).Item("numano").ToString
                datosPago.fechaPago = fFin
                datosPago.semanaPago = datosFechaPago.Rows(0).Item("numsem").ToString
                datosPago.semanaCompra = datosCompra.Rows(0).Item("numsem").ToString
                datosPago.añoCompra = datosCompra.Rows(0).Item("numano").ToString
            End If
        Else 'No hay días no laborales
            datosFechaPago = obj.getSemana(fFin)
            datosCompra = obj.getSemana(fInicio)
            If datosFechaPago.Rows.Count > 0 Then
                datosPago.añoPago = datosFechaPago.Rows(0).Item("numano").ToString
                datosPago.fechaPago = fFin
                datosPago.semanaPago = datosFechaPago.Rows(0).Item("numsem").ToString
                datosPago.semanaCompra = datosCompra.Rows(0).Item("numsem").ToString
                datosPago.añoCompra = datosCompra.Rows(0).Item("numano").ToString
            End If
        End If
        Return datosPago
    End Function

    Public Function GetFechaMasDiasInhabiles(fInicio As Date, fFin As Date) As Date
        Dim diasAgregar As Integer = 0
        Dim obj As New AgregarComprobanteBU
        Dim datosInhabiles As New DataTable
        Dim dias As Integer = DateDiff(DateInterval.Day, fInicio, fFin)
        If obj.validarSiExistenDiasInhabiles(fInicio, fFin).Rows.Count > 0 Then 'Existen Dias no laborables
            For index As Integer = 0 To dias
                If Not obj.validarSiesDiaHabil(DateAdd(DateInterval.Day, index, fInicio)) Then
                    diasAgregar += 1
                End If
            Next
            fFin = GetFechaMasDiasInhabiles(fFin, DateAdd(DateInterval.Day, diasAgregar, fFin))
        End If
        Return fFin
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GetFechaPago(Date.Now, 42)
    End Sub

    Private Sub pbYuyin_Click(sender As Object, e As EventArgs) Handles pbYuyin.Click

    End Sub
End Class