Imports Proveedores.BU
Imports System.Xml
Imports Tools
Imports System.IO

Public Class SustituirDocMaquila
    Public idComprobante As Integer = 0
    Public datos As New DataTable
    Dim fechaDocumento As Date
    Dim rfcReceptor As String
    Dim rfcEmisor As String
    Dim folio As String
    Dim total As Double
    Dim proveedor As String
    Dim contribuyente As String
    Dim tipo As String
    Dim adv As New AdvertenciaForm
    Dim exito As New ExitoForm
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
    Dim idReceptor As Integer = 0
    Dim idNave As Integer = 0 'Poner tambien el nombre de la nave
    Dim guardar As Boolean = False
    Dim nombreNave As String
    Dim unidadxml As String = ""
    Dim ClaveProdServxml As String = ""

    Public accion As String = ""

    Public banderaAccion As Integer = 0 '0 si cerro,1 si guardo primero

    Private Sub SustituirDocMaquila_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarDatos()
    End Sub
    Public Sub llenarDatos()
        If idComprobante > 0 Then
            Dim obj As New SustituirComprobanteBU
            datos = obj.getComprobante(idComprobante)
            For Each row As DataRow In datos.Rows
                fechaDocumento = row("maco_fechadocumento")
                folio = row("maco_folio")
                total = row("maco_total")
                proveedor = row("Proveedor")
                contribuyente = row("Receptor")
                tipo = row("maco_tipo")
                idNave = row("maco_naveid")
                rfcReceptor = row("RFCReceptor")
                rfcEmisor = row("RFCEmisor")
                nombreNave = row("Nave")
            Next
            lblFechaOri.Text = fechaDocumento.ToString("dd/MM/yyyy")
            lblFolioOri.Text = folio
            lblImporteOri.Text = total.ToString("##,###.#0")
            lblProvOri.Text = proveedor
            lblRazSocOri.Text = contribuyente
            If tipo = "F" Then
                lblTipoOri.Text = "Factura"
                lblTipoNuevo.Text = "Factura"
                txtFolioNuevo.Enabled = False
            Else
                lblTipoOri.Text = "Remisión"
                lblTipoNuevo.Text = "Remisión"
                btnXML.Enabled = False
                txtXML.Enabled = False
                btnPDF.Enabled = False
                txtPDF.Enabled = False
                lblFechaNueva.Text = fechaDocumento.ToString("dd/MM/yyyy")
                txtFolioNuevo.Text = folio
                lblImporteNuevo.Text = total.ToString("##,###.#0")
                lblProvNuevo.Text = proveedor
                lblRazSocNueva.Text = contribuyente
            End If

        End If
    End Sub
    Private Sub bntSalir_Click(sender As Object, e As EventArgs) Handles bntSalir.Click
        Me.Close()
    End Sub

    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        guardar = False
        OpenFileDialog1.Filter = "xml files (*.xml)|*.xml"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        folioXML = ""
        serieXML = ""
        totalXML = ""
        subTotalXML = ""
        rfcEmisorXML = ""
        razonSocialEmisorXML = ""
        rfcReceptorXML = ""
        razonSocialReceptorXML = ""
        paresXML = 0
        IVAXML = ""
        uuidXML = ""
        fechaXML = ""
        idReceptor = 0
        unidadxml = ""
        ClaveProdServxml = ""

        Dim cuantos As Integer = 0
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim reader As XmlTextReader = New XmlTextReader(OpenFileDialog1.FileName)
            txtXML.Text = OpenFileDialog1.FileName
            Do While (reader.Read())
                'If reader.Name = "cfdi:Concepto" Then
                '    If reader.HasAttributes Then
                '        While reader.MoveToNextAttribute()
                '            If reader.Name = "ClaveProdServ" Then
                '                ClaveProdServxml = reader.Value
                '                If ClaveProdServxml = "" Then
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
                If reader.Name = "cfdi:Comprobante" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name = "Serie" Then
                                serieXML = reader.Value
                            ElseIf reader.Name = "Folio" Then
                                folioXML = reader.Value
                            ElseIf reader.Name = "SubTotal" Then
                                subTotalXML = reader.Value
                            ElseIf reader.Name = "Total" Then
                                totalXML = reader.Value
                            ElseIf reader.Name = "Fecha" Then
                                fechaXML = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Emisor" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name = "Rfc" Then
                                rfcEmisorXML = reader.Value
                            ElseIf reader.Name = "Nombre" Then
                                razonSocialEmisorXML = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Receptor" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name = "Rfc" Then
                                rfcReceptorXML = reader.Value
                            ElseIf reader.Name = "Nombre" Then
                                razonSocialReceptorXML = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Traslado" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name = "Importe" Then
                                IVAXML = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "tfd:TimbreFiscalDigital" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name = "UUID" Then
                                uuidXML = reader.Value
                            End If
                        End While
                    End If
                End If
                If reader.Name = "cfdi:Concepto" Then
                    If reader.HasAttributes Then
                        While reader.MoveToNextAttribute()
                            If reader.Name = "Cantidad" Then
                                paresXML += reader.Value
                                'End If
                            ElseIf reader.Name = "ClaveProdServ" Then
                                ClaveProdServxml = reader.Value
                                If ClaveProdServxml = "" Then
                                    Exit Do
                                End If
                                'End If
                            ElseIf reader.Name = "ClaveUnidad" Then
                                unidadxml = reader.Value
                                If unidadxml <> "PR" Then
                                    Exit Do
                                End If
                            End If
                        End While
                    End If
                End If
            Loop
            validarFactura()
        End If
    End Sub
    Private Sub validarFactura()
        If tipo = "R" Then
            If txtPDF.Text.Length > 0 Then
                If txtMotivo.Text.Length > 0 Then
                    guardar = True
                Else
                    adv.mensaje = "Ingresa un motivo."
                    adv.ShowDialog()
                    guardar = False
                End If
            Else
                adv.mensaje = "Selecciona un pdf para sustituir."
                adv.ShowDialog()
                guardar = False
            End If
        Else

            If String.IsNullOrEmpty(ClaveProdServxml) Then

                adv.mensaje = "ClaveProdServ está vacío"
                adv.ShowDialog()
                guardar = False
            Else

                If unidadxml = "PR" Then

                    If txtXML.Text.Length > 0 Then
                        If totalXML = total Then
                            If quitarGuionyEspacios(rfcEmisorXML) = quitarGuionyEspacios(rfcEmisor) Then
                                Dim obj As New AgregarComprobanteBU
                                If obj.verificarEmisor(idNave, rfcEmisorXML) Then
                                    If Not obj.verificarUUID(uuidXML) Then
                                        Dim r As New DataTable
                                        r = obj.verificarRazonSocialParaNave(idNave, rfcReceptorXML)
                                        If r.Rows.Count > 0 Then
                                            If r.Rows.Count > 0 Then
                                                idReceptor = r.Rows(0).Item("IDRazSoc").ToString
                                            End If
                                            lblFechaNueva.Text = Convert.ToDateTime(fechaXML).ToString("dd/MM/yyyy")
                                            txtFolioNuevo.Text = folioXML
                                            lblImporteNuevo.Text = Convert.ToDouble(totalXML).ToString("##,###.#0")
                                            lblProvNuevo.Text = razonSocialEmisorXML
                                            lblRazSocNueva.Text = razonSocialReceptorXML
                                            If tipo = "F" Then
                                                lblTipoNuevo.Text = "Factura"
                                            Else
                                                lblTipoNuevo.Text = "Remisión"
                                            End If
                                            lblTipoNuevo.Text = "Factura"
                                            txtXML.Text = OpenFileDialog1.FileName
                                            guardar = True
                                        Else
                                            adv.mensaje = "El Receptor no esta configurado para la maquila."
                                            adv.ShowDialog()
                                            txtXML.Text = ""
                                            guardar = False
                                        End If
                                    Else
                                        adv.mensaje = "Existe un registro con el UUID de la factura."
                                        adv.ShowDialog()
                                        txtXML.Text = ""
                                        guardar = False
                                    End If
                                Else
                                    adv.mensaje = "El proveedor " & razonSocialEmisorXML & " no está configurado para la maquila." 'Poner nombre de la nave
                                    adv.ShowDialog()
                                    txtXML.Text = ""
                                    guardar = False
                                End If
                            Else
                                adv.mensaje = "El proveedor no coincide con la factura original."
                                adv.ShowDialog()
                                txtXML.Text = ""
                                guardar = False
                            End If
                        Else
                            adv.mensaje = "La factura seleccionada no corresponde con la cantidad a remplazar."
                            adv.ShowDialog()
                            txtXML.Text = ""
                            guardar = False
                        End If
                    Else
                        adv.mensaje = "Seleccione un xml."
                        adv.ShowDialog()
                        guardar = False
                    End If
                Else
                    adv.mensaje = "ClaveUnidad es diferente de PR"
                    adv.ShowDialog()
                    guardar = False
                End If

            End If
        End If

    End Sub

    Private Sub btnPDF_Click(sender As Object, e As EventArgs) Handles btnPDF.Click
        OpenFileDialog1.Filter = "pdf files (*.pdf)|*.pdf"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtPDF.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Function quitarGuionyEspacios(ByVal cadena As String) As String
        Dim tmp As String = ""
        tmp = cadena.Replace("-", "")
        tmp = tmp.Replace(" ", "")
        Return tmp
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtMotivo.Text.Length > 0 Then
            If tipo = "F" Then
                If guardar = True Then
                    If txtXML.Text.Length > 0 Then
                        sustituir()
                        banderaAccion = 1
                        Return
                    Else
                        adv.mensaje = "Necesita seleccionar el XML de la factura."
                        adv.ShowDialog()
                        Return
                    End If
                Else
                    validarFactura()
                End If
            End If
            If tipo = "R" Then
                If txtFolioNuevo.Text.Length > 0 Then
                    sustituir()
                    Return
                Else
                    adv.mensaje = "Necesita un folio para la remisión."
                    adv.ShowDialog()
                    Return
                End If
            End If
        Else
            adv.mensaje = "El campo de motivo es obligatorio."
            adv.ShowDialog()
        End If

    End Sub
    Private Sub sustituir()
        Try
            Dim obj As New SustituirComprobanteBU
            Dim xml As String = ""
            Dim pdf As String = ""
            If txtXML.Text.Length > 0 Then
                xml = CopiarArchivos(txtXML.Text, uuidXML & "(V2)", "xml")
            End If
            If txtPDF.Text.Length > 0 Then
                pdf = CopiarArchivos(txtPDF.Text, uuidXML & "(V2)", "pdf")
            End If
            If tipo = "F" Then
                If accion = "sustituir" Then
                    obj.updateComprobanteMaquila(idComprobante, idReceptor, txtMotivo.Text, fechaXML, uuidXML, xml, pdf, "")
                Else
                    obj.updateComprobanteMaquila(idComprobante, idReceptor, txtMotivo.Text, fechaXML, uuidXML, xml, pdf, "C")
                End If

                exito.mensaje = "Factura actualizada."
                exito.ShowDialog()
                Me.Close()
            Else
                If accion = "sustituir" Then
                    obj.updateComprobanteMaquilaRemision(idComprobante, pdf, txtMotivo.Text.Trim, "", txtFolioNuevo.Text)
                Else
                    obj.updateComprobanteMaquilaRemision(idComprobante, pdf, txtMotivo.Text.Trim, "C", txtFolioNuevo.Text)
                End If

                exito.mensaje = "PDF actualizado."
                exito.ShowDialog()
                Me.Close()
            End If
        Catch ex As Exception
            adv.mensaje = "Surgió algo inesperado al copiar el XML o PDF. Detalles: " & ex.Message
            adv.ShowDialog()
        End Try
    End Sub
    Function CopiarArchivos(ByVal ruta As String, ByVal nombreArchivo As String, ByVal ext As String) As String
        '\\192.168.2.2\bin\TASFE\COMPRAS\[nave]\mesaño\
        'C:\Users\SISTEMAS13\Desktop\test.pdf
        Try
            Dim rutaArchivos As String = Entidades.SesionUsuario.ConfigRutas.PRutaComprobante_Maquilas
            Dim fecha As New Date
            fecha = Date.Today
            Dim fechaCarpeta As String = concatenarFecha(fecha)
            If Not Directory.Exists(rutaArchivos & nombreNave) Then
                Directory.CreateDirectory(rutaArchivos & nombreNave)
                If Not Directory.Exists(rutaArchivos & nombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutaArchivos & nombreNave & "\" & fechaCarpeta)
                    If ruta.Length > 0 Then
                        If nombreArchivo.Length > 4 Then
                            System.IO.File.Copy(ruta, rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                        Else
                            System.IO.File.Copy(ruta, rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & folio & "." & ext, True)
                        End If
                    End If
                End If
            Else
                If Not Directory.Exists(rutaArchivos & nombreNave & "\" & fechaCarpeta) Then
                    Directory.CreateDirectory(rutaArchivos & nombreNave & "\" & fechaCarpeta)
                Else
                    If ruta.Length > 0 Then
                        If nombreArchivo.Length > 4 Then
                            System.IO.File.Copy(ruta, rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext, True)
                        Else
                            System.IO.File.Copy(ruta, rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & folio & "." & ext, True)
                        End If
                    End If
                End If
            End If
            If ruta.Length > 0 Then
                Dim rutatmp As String = ""
                If nombreArchivo.Length > 4 Then
                    rutatmp = rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & nombreArchivo & "." & ext
                Else
                    rutatmp = rutaArchivos & nombreNave & "\" & fechaCarpeta & "\" & folio & "." & ext
                End If

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
    Function concatenarFecha(ByVal fecha As Date)
        Dim cadena As String
        If fecha.Month < 10 Then
            cadena = "0" & fecha.Month & "" & fecha.Year
        Else
            cadena = "" & fecha.Month & "" & fecha.Year
        End If
        Return cadena
    End Function

End Class